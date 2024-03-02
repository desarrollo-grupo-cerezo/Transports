Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmConciValesCombus
    Private BarNuevoD As Boolean = False, BarEditD As Boolean = False, BarCambioStatusD As Boolean = False, BarImprimirD As Boolean = False
    Private CADENA As String, Entra_Search As Boolean = False, NRow As Integer = 0, ROW_VALOR As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmConciValesCombus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Catch ex As Exception
            End Try

            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True

            Fg3.Rows(0).Height = 40
            Fg3.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg3.Height = Me.Height - 150

            Fg1.Cols(17).Width = 0
            Fg1.Cols(15).ComboList = "EDICION|CAPTURADO|ACEPTADO|"
            Fg1.Rows(0).Height = 40

            Fg2.Rows(0).Height = 40

            BarNuevo.Visible = False
            BarImprimirVehiUtil.Visible = False
            BarPolizaValesDiesel.Visible = False

            Fg1.DrawMode = DrawModeEnum.OwnerDraw
            Fg2.DrawMode = DrawModeEnum.OwnerDraw
            Fg3.DrawMode = DrawModeEnum.OwnerDraw
            FgU.DrawMode = DrawModeEnum.OwnerDraw

            BarImprimirConciIEPS.Visible = False

            BarEdit.Visible = True
            BarEdit.Text = "Edit"
            BarCambioStatus.Visible = True

            CADENA = ""
            DESPLEGAR1()
            DESPLEGAR2()

            Fg1.Select()

        Catch ex As Exception
            'MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        DERECHOS()
    End Sub

    Sub DERECHOS()

        If Not pwPoder Then
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarCambioStatus.Visible = False
                BarImprimirConciIEPS.Visible = False
                Tab1.Controls.Item(0).Enabled = False 'Vales capturados
                Tab1.Controls.Item(1).Enabled = False 'Consulta de vales
                Tab1.Controls.Item(2).Enabled = False 'Conciliaciones
                Tab1.Controls.Item(3).Enabled = False 'Conciliación vehiculos utilitarios

            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND ((CLAVE >= 23600 And CLAVE < 24000) OR
                       (CLAVE >= 2361020 And CLAVE < 2382040))"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 23610
                                    Tab1.Controls.Item(0).Enabled = True
                                Case 2361020
                                    BarEdit.Visible = True
                                    BarEditD = True
                                Case 2361040
                                    BarCambioStatus.Visible = True
                                    BarCambioStatusD = True
                                Case 23640
                                    Tab1.Controls.Item(1).Enabled = True
                                Case 2364020
                                    BarCambioStatus.Visible = True
                                    BarCambioStatusD = True
                                Case 23740
                                    Tab1.Controls.Item(2).Enabled = True
                                Case 2374020
                                    BarNuevo.Visible = True
                                    BarNuevoD = True
                                Case 2374040
                                    BarEdit.Visible = True
                                    BarEditD = True
                                Case 2374060
                                    BarImprimirConciIEPS.Visible = True
                                    BarImprimirD = True
                                Case 23820
                                    Tab1.Controls.Item(3).Enabled = True
                                Case 2382020
                                    BarNuevo.Visible = True
                                    BarNuevoD = True
                                Case 2382040
                                    BarEdit.Visible = True
                                    BarEditD = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR_UTILITARIOS()
        Try
            FgU.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            SQL = "SELECT TOP 5000 GV.FOLIO AS 'Folio', ISNULL(GV.ST_VALES,'EDICION') AS 'Estatus vale', 
                ISNULL(GV.CVE_OPER,0) AS 'Operador', ISNULL(O.NOMBRE,'') AS 'Nombre operador', ISNULL(GV.CVE_TRACTOR,'') AS 'Unidad',
                ISNULL(GV.FECHA,'') AS 'Fecha', ISNULL(FECHA_CARGA,'') AS 'Fecha de carga',
                ISNULL(GV.CVE_GAS,'') AS 'Clave', '('  + ISNULL(GV.CVE_GAS,'') + ')   ' + ISNULL(G.DESCR,'') AS 'Gasolinera', 
                ISNULL(GV.LTS_INICIALES,0) AS 'Litros iniciales', ISNULL(GV.LITROS_REALES,0) AS 'Litros reales', ISNULL(GV.P_X_LITRO,0) AS 'P. X litro',
                ISNULL(GV.SUBTOTAL,0) AS 'Subtotal', ISNULL(GV.IVA,0) AS 'IVA', ISNULL(GV.IEPS,0) AS 'IEPS', ISNULL(GV.IMPORTE,0) AS 'Importe', 
                ISNULL(GV.FACTURA,'') AS 'Factura', ISNULL(GV.OBS,'') AS 'Observaciones', GV.UUID AS 'Id', 
                CASE WHEN ISNULL(POL_GEN,'') = 'S' THEN 'Generada' ELSE '' END AS 'Poliza'
                FROM GCASIGNACION_VALES_UTIL GV
                LEFT JOIN GCOPERADOR O ON O.CLAVE = GV.CVE_OPER
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                WHERE (GV.ST_VALES = 'EDICION' OR GV.ST_VALES = 'ACEPTADO' OR GV.ST_VALES = 'CONCILIADO') " &
                CADENA & " 
                ORDER BY RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) DESC"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            FgU.DataSource = BindingSource1.DataSource

            If NRow > 0 Then
                SET_ROW()
            Else
                If FgU.Rows.Count > 1 Then
                    FgU.Row = 1
                End If
            End If

            FgU.Cols(3).Width = 0
            FgU.Cols(8).Width = 0

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To FgU.Cols.Count - 1
                    FgU(0, k) = FgU(0, k) & k
                Next
            End If

            FgU.Subtotal(AggregateEnum.Clear)
            FgU.SubtotalPosition = SubtotalPositionEnum.BelowData
            '  Get a Grand total (use -1 instead of column index).
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
            FgU.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")

            FgU.Redraw = True
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        FgU.Redraw = True
    End Sub
    Sub SET_ROW()
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    For k = 1 To Fg1.Rows.Count - 1
                        If Fg1(k, 2) = ROW_VALOR Then
                            Fg1.Row = k
                            Exit For
                        End If
                    Next
                Case 1
                    For k = 1 To Fg2.Rows.Count - 1
                        If Fg2(k, 2) = ROW_VALOR Then
                            Fg2.Row = k
                            Exit For
                        End If
                    Next
                Case 2
                    For k = 1 To Fg3.Rows.Count - 1
                        If Fg3(k, 1) = ROW_VALOR Then
                            Fg3.Row = k
                            Exit For
                        End If
                    Next
            End Select
            ROW_VALOR = ""
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR1()
        Try
            Fg1.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            '0000003031
            'GCASIGNACION_VIAJE_VALES FECHA_CARGA

            SQL = "SELECT TOP 5000 ISNULL(GV.CVE_VIAJE,'') AS 'Num. viaje', RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) AS 'Folio', 
                ISNULL(GV.ST_VALES,'EDICION') AS 'Estatus vale',
                ISNULL(V.CVE_TRACTOR,'') AS 'Unidad', ISNULL(O.NOMBRE,'') AS 'Operador', ISNULL(GV.FECHA,'') AS 'Fecha', 
                ISNULL(V.FECHA_CARGA,'') AS 'Fecha carga', 
                '(' + RTRIM(LTRIM(ISNULL(G.CVE_PROV,''))) + ') ' + ISNULL(P.NOMBRE,'') AS 'Proveedor', 
                ISNULL(GV.CVE_GAS,'') AS 'Clave', '('  + ISNULL(GV.CVE_GAS,'') + ')   ' + ISNULL(G.DESCR,'') AS 'Gasolinera', 
                ISNULL(GV.LITROS,0) AS 'Litros iniciales', ISNULL(GV.LITROS_REALES,0) AS 'Litros reales', 
                ISNULL(GV.P_X_LITRO,0) AS 'P. X litro', 
                ISNULL(GV.SUBTOTAL,0) AS 'Subtotal', ISNULL(GV.IVA,0) AS 'IVA', ISNULL(GV.IEPS,0) AS 'IEPS', 
                ISNULL(GV.IMPORTE,0) AS 'Importe', ISNULL(GV.FACTURA,'') AS 'Factura', 
                CASE WHEN GV.STATUS = 'C' THEN 'Cancelado' ELSE 'Emitido' END AS 'Estatus', 
                ISNULL(GV.OBS,'') AS 'Observaciones', GV.UUID AS 'Id'
                FROM GCASIGNACION_VIAJE_VALES GV
                LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = GV.CVE_VIAJE                
                LEFT JOIN GCOPERADOR O ON O.CLAVE = V.CVE_OPER 
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV
                WHERE ST_VALES = 'CAPTURADO' AND GV.STATUS <> 'C' " & CADENA & " 
                ORDER BY RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) DESC"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg1.DataSource = BindingSource1.DataSource
            Fg1.Redraw = True

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg1.Cols.Count - 1
                    Fg1(0, k) = Fg1(0, k) & k
                Next
            End If
            Fg1.Redraw = True
            If Fg1.Rows.Count > 1 Then
                Fg1.AutoSizeRows()
                Fg1.Cols(9).Width = 0
                Fg1.Cols(3).TextAlign = TextAlignEnum.CenterCenter
                Fg1.Rows(0).Height = 40

                'Fg1.Styles.Fixed.WordWrap = True
                Fg1.Styles.Normal.WordWrap = True

                Dim c6 As Column = Fg1.Cols(14)
                c6.DataType = GetType(Decimal)
                Fg1.Cols(14).Format = "###,###,##0.00"

                Dim c15 As Column = Fg1.Cols(15)
                c15.DataType = GetType(Decimal)
                Fg1.Cols(15).Format = "###,###,##0.00"

                Dim c16 As Column = Fg1.Cols(16)
                c16.DataType = GetType(Decimal)
                Fg1.Cols(16).Format = "###,###,##0.00"

                Dim c17 As Column = Fg1.Cols(17)
                c17.DataType = GetType(Decimal)
                Fg1.Cols(17).Format = "###,###,##0.00"

                Fg1.Cols(3).Width = 90
                Fg1.Cols(4).Width = 60

                Fg1.Cols(11).Width = 70
                Fg1.Cols(12).Width = 70
                Fg1.Cols(13).Width = 70

                Fg1.Cols(14).Width = 80
                Fg1.Cols(15).Width = 80
                Fg1.Cols(16).Width = 80
                Fg1.Cols(17).Width = 80
                Fg1.Cols(21).Width = 0

                Fg1.Subtotal(AggregateEnum.Clear)
                Fg1.SubtotalPosition = SubtotalPositionEnum.BelowData
                '  Get a Grand total (use -1 instead of column index).
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")
                Fg1.Subtotal(AggregateEnum.Sum, -1, -1, 17, "Grand Total")

                If NRow > 0 Then
                    Fg1.Row = NRow
                Else
                    Fg1.Row = 1
                End If
            End If
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR2()
        Try
            Fg2.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT TOP 5000 GV.CVE_VIAJE AS 'Num. viaje', RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) AS 'Folio', 
                CASE WHEN GV.STATUS = 'C' THEN 'Cancelado' ELSE 'Emitido' END AS 'Estatus',
                V.CVE_OPER AS 'Operador', O.NOMBRE AS 'Nombre', V.CVE_TRACTOR AS 'Unidad', GV.FECHA AS 'Fecha', GV.FECHA_CARGA AS 'Fecha carga', 
                G.CVE_PROV + ' ' + P.NOMBRE AS 'Proveedor', GV.CVE_GAS AS 'Clave', '(' + GV.CVE_GAS + ')   ' + G.DESCR AS 'Gasolinera', 
                GV.LITROS AS 'Litros iniciales', GV.LITROS_REALES AS 'Litros reales', GV.P_X_LITRO AS 'P. X litro', GV.SUBTOTAL+ GV.IEPS AS 'Subtotal', 
                GV.IVA AS 'IVA', GV.IEPS AS 'IEPS', GV.IMPORTE AS 'Importe', GV.FACTURA AS 'Factura', ISNULL(GV.ST_VALES,'EDICION') AS 'Estatus vale', 
                (SELECT TOP 1 REFER FROM PAGA_M" & Empresa & " WHERE NO_FACTURA = GV.FACTURA) AS 'Referencia', GV.OBS AS 'Observaciones' 
                FROM GCASIGNACION_VIAJE_VALES GV
				LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = GV.CVE_VIAJE
                LEFT JOIN GCOPERADOR O ON O.CLAVE = V.CVE_OPER
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = G.CVE_PROV " &
                CADENA & " 
                ORDER BY RIGHT('0000000000'+ISNULL(GV.FOLIO,''),10) DESC"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg2.DataSource = BindingSource1.DataSource

            If NRow > 0 Then
                Fg2.Row = NRow
            Else
                If Fg2.Rows.Count > 1 Then
                    Fg2.Row = 1

                    Fg2.Cols(3).TextAlign = TextAlignEnum.CenterCenter

                    Dim c12 As Column = Fg2.Cols(12)
                    c12.DataType = GetType(Decimal)
                    Fg2.Cols(12).Format = "###,###,##0.00"

                    Dim c13 As Column = Fg2.Cols(13)
                    c13.DataType = GetType(Decimal)
                    Fg2.Cols(13).Format = "###,###,##0.00"

                    Dim c6 As Column = Fg2.Cols(14)
                    c6.DataType = GetType(Decimal)
                    Fg2.Cols(14).Format = "###,###,##0.00"

                    Dim c15 As Column = Fg2.Cols(15)
                    c15.DataType = GetType(Decimal)
                    Fg2.Cols(15).Format = "###,###,##0.00"

                    Dim c16 As Column = Fg2.Cols(16)
                    c16.DataType = GetType(Decimal)
                    Fg2.Cols(16).Format = "###,###,##0.00"

                    Dim c17 As Column = Fg2.Cols(17)
                    c17.DataType = GetType(Decimal)
                    Fg2.Cols(17).Format = "###,###,##0.00"

                    Dim c18 As Column = Fg2.Cols(18)
                    c18.DataType = GetType(Decimal)
                    Fg2.Cols(18).Format = "###,###,##0.00"

                    Fg2.Cols(3).Width = 90
                    Fg2.Cols(4).Width = 60
                    Fg2.Cols(6).Width = 60

                    Fg2.Cols(11).Width = 70
                    Fg2.Cols(12).Width = 80
                    Fg2.Cols(13).Width = 70

                    Fg2.Cols(14).Width = 80
                    Fg2.Cols(15).Width = 80
                    Fg2.Cols(16).Width = 80
                    Fg2.Cols(17).Width = 80

                    Fg2.Subtotal(AggregateEnum.Clear)
                    Fg2.SubtotalPosition = SubtotalPositionEnum.BelowData
                    '  Get a Grand total (use -1 instead of column index).
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 16, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 17, "Grand Total")
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 18, "Grand Total")


                End If
            End If

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg2.Cols.Count - 1
                    Fg2(0, k) = Fg2(0, k) & k
                Next
            End If

            Fg2.Cols(21).Width = 120
            Fg2.Cols(10).Width = 0
            Fg2.Redraw = True
            NRow = 0
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR3()
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
            ' CONCILIACIONES     CONCILIACIONES     CONCILIACIONES     CONCILIACIONES     CONCILIACIONES
            '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
            Fg3.Redraw = False
            SQL = "SELECT TOP 5000 V.CVE_COVC, CASE V.STATUS 
                WHEN 'A' THEN 'Activo' 
                WHEN 'T' THEN 'Cuentas por pagar' 
                WHEN 'F' THEN 'Cerrada' 
                ELSE 'Cancelado' 
                END AS 'ESTATUS', 
                V.CVE_PROV, NOMBRE, V.CVE_DOC, V.SERIE_CFDI, V.FOLIO_CFDI, V.FECHA_DOC, V.SUBTOTAL, V.IVA, V.NETO, 
                ISNULL((SELECT COUNT(*) FROM GCCONCI_VALES_COMBUS_PAR P WHERE ISNULL(P.STATUS,'A') = 'A' AND P.CVE_COVC = V.CVE_COVC),0) AS Vales,
                CASE WHEN ISNULL(V.POL_GEN,'') = 'S' THEN 'Generada' ELSE '' END AS 'Poliza',
                CASE WHEN ISNULL((SELECT TOP 1 CVE_VIAJE FROM GCCONCI_VALES_COMBUS_PAR C WHERE CVE_COVC = V.CVE_COVC AND ISNULL(CVE_VIAJE,'') <> ''),'') <> '' 
                THEN
                (SELECT SUM(LITROS_REALES) AS LTS_INICIALES FROM GCCONCI_VALES_COMBUS_PAR C 
                LEFT JOIN GCASIGNACION_VIAJE_VALES A ON A.FOLIO = C.CVE_FOLIO 
                WHERE ISNULL(C.STATUS,'A') <> 'C' AND C.CVE_COVC = V.CVE_COVC AND ISNULL(A.STATUS,'') <> 'C') 
                ELSE
				(SELECT SUM(U.LITROS_REALES) FROM GCASIGNACION_VALES_UTIL U 
                LEFT JOIN GCCONCI_VALES_COMBUS_PAR A ON A.CVE_FOLIO = U.FOLIO
                LEFT JOIN GCCONCI_VALES_COMBUS VC ON VC.CVE_COVC = A.CVE_COVC
				WHERE ISNULL(A.STATUS,'A') <> 'C' AND ISNULL(VC.STATUS,'A') <> 'C' AND U.FACTURA = V.CVE_DOC AND A.CVE_GAS = U.CVE_GAS) END AS LITROS,
                ISNULL((SELECT TOP 1 CVE_VIAJE FROM GCCONCI_VALES_COMBUS_PAR C WHERE CVE_COVC = V.CVE_COVC AND ISNULL(CVE_VIAJE,'') <> ''),'') AS 'Num. Viaje'
                FROM GCCONCI_VALES_COMBUS V
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = V.CVE_PROV
                " & CADENA & " ORDER BY TRY_CAST(CVE_COVC As INT) DESC"
            'GCCONCI_VALES_COMBUS 
            'MOSTRAR TODOS MENOS LOS QUE ESTAN EN EDICION
            'CAMBIAR EL STATUS DE VALE A CAPTURADO Y QUITAR DE ESTA PESTANA Y ENVIARLO A LA PRIMERA PESTANA

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg3.DataSource = BindingSource1.DataSource


            If NRow > 0 Then
                Fg3.Row = NRow
            Else
                If Fg3.Rows.Count > 1 Then
                    Fg3.Row = 1
                End If
            End If

            Fg3.Subtotal(AggregateEnum.Clear)
            Fg3.SubtotalPosition = SubtotalPositionEnum.BelowData
            '  Get a Grand total (use -1 instead of column index).
            Fg3.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            Fg3.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
            Fg3.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
            Fg3.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
            Fg3.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")

            Fg3(0, 1) = "Folio conci."
            Dim cc1 As Column = Fg3.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg3(0, 2) = "Estatus"
            Dim c2 As Column = Fg3.Cols(2)
            c2.DataType = GetType(String)

            Fg3(0, 3) = "Clave"
            Dim c3 As Column = Fg3.Cols(3)
            c3.DataType = GetType(String)

            Fg3(0, 4) = "Proveedor"
            Dim c4 As Column = Fg3.Cols(4)
            c4.DataType = GetType(String)

            Fg3(0, 5) = "Factura"
            Dim c5 As Column = Fg3.Cols(5)
            c5.DataType = GetType(String)

            Fg3(0, 6) = "Serie"
            Dim c6 As Column = Fg3.Cols(6)
            c6.DataType = GetType(String)

            Fg3(0, 7) = "Folio"
            Dim c7 As Column = Fg3.Cols(7)
            c7.DataType = GetType(String)

            Fg3(0, 8) = "Fecha factura"
            Dim c8 As Column = Fg3.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg3(0, 9) = "SubTotal"
            Dim c9 As Column = Fg3.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg3.Cols(9).Format = "###,###,##0.00"

            Fg3(0, 10) = "IVA"
            Dim c10 As Column = Fg3.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg3.Cols(10).Format = "###,###,##0.00"

            Fg3(0, 11) = "Neto"
            Dim c11 As Column = Fg3.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg3.Cols(11).Format = "###,###,##0.00"

            Fg3(0, 12) = "Litros reales"
            Dim c12 As Column = Fg3.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg3.Cols(12).Format = "###,###,##0.00"

            Fg3(0, 14) = "Total litros"
            Dim c14 As Column = Fg3.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg3.Cols(14).Format = "###,###,##0.00"

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg3.Cols.Count - 1
                    Fg3(0, k) = Fg3(0, k) & k
                Next
            End If
            Fg3.AutoSizeCols()

            Fg3.Redraw = True
            NRow = 0
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub frmConciValesCombus_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Conciliación Vales Combustible")
        Me.Dispose()
    End Sub

    Private Sub frmConciValesCombus_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4

                Case Keys.F5
                    barSalir_Click(Nothing, Nothing)
                Case Keys.Enter
                    If Entra_Search Then
                        barEdit_Click(Nothing, Nothing)
                        Entra_Search = False
                    End If
                Case Keys.Escape
                    TBUSCAR.Focus()
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Select Case Tab1.SelectedIndex
            Case 3
                Try
                    Var1 = "Nuevo"
                    NRow = 0
                    Var47 = Fg3(Fg3.Row, 15)

                    FrmConciValesUtilitario.ShowDialog()
                    CADENA = ""
                    DESPLEGAR_UTILITARIOS()
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case Else
                Try
                    Var1 = "Nuevo"
                    NRow = 0
                    Var47 = ""

                    FrmConciValesCombusAE.ShowDialog()
                    CADENA = ""
                    DESPLEGAR3()
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
        End Select

    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    If Fg1.Row > 0 Then
                        Try
                            If Fg1.Row > 0 Then
                                If Fg1(Fg1.Row, 3) = "Cancelado" Then
                                    MsgBox("El vale de combustible se encuentra como 'CANCELADO' no es posible modificarlo, verifique por favor")
                                    Return
                                End If
                            End If

                            If Fg1.Row > 0 Then
                                If Fg1(Fg1.Row, 19) = "ACEPTADO" Then
                                    MsgBox("El vale de combustible se encuentra como 'ACEPTADO' no es posible modificarlo, verifique por favor")
                                    Return
                                End If
                            End If

                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        '       1             2        3            4         5             6            7
                        'GV.CVE_VIAJE, GV.FOLIO, S.CVE_TRACTOR, o.NOMBRE, GV.FECHA, GV.FECHA_CARGA, G.CVE_PROV + ' ' + P.NOMBRE AS 'Proveedor', 
                        '      8                                  9          10             11             12           13  
                        'GV.CVE_GAS, '('  + GV.CVE_GAS + ')' + G.DESCR, GV.LITROS, GV.LITROS_REALES, GV.P_X_LITRO, GV.SUBTOTAL, 
                        '  14       15           16        17           18        19      20 
                        'GV.IVA, GV.IEPS, GV.IMPORTE, GV.FACTURA, GV.ST_VALES, GV.OBS, GV.UUID

                        Var1 = "Edit"
                        Var2 = Fg1(Fg1.Row, 1)
                        frmConciValesComEdit.LtViaje.Text = Fg1(Fg1.Row, 1) 'GV.CVE_VIAJE
                        frmConciValesComEdit.TFOLIO.Text = Fg1(Fg1.Row, 2) 'GV.FOLIO
                        Try
                            frmConciValesComEdit.FECHA.Value = Fg1(Fg1.Row, 6) 'GC.FECHA
                        Catch ex As Exception
                        End Try

                        frmConciValesComEdit.TCVE_GAS.Text = Fg1(Fg1.Row, 9) 'GV.CVE_GAS
                        frmConciValesComEdit.LtGas.Text = Fg1(Fg1.Row, 10) 'G.DESCR
                        Try
                            frmConciValesComEdit.LtLts_Inic.Text = Format(CDec(Fg1(Fg1.Row, 11)), "###,###,##0.000") 'GC.LITROS
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        frmConciValesComEdit.TLTS_REALES.Value = Fg1(Fg1.Row, 12) 'GV.LITROS_REALES
                        frmConciValesComEdit.TPRECIO_X_LTS.Value = Fg1(Fg1.Row, 13) 'GV.P_X_LITRO
                        'FgV.Cols(15).ComboList = "EDICION|CAPTURADO|ACEPTADO|"
                        Select Case Fg1(Fg1.Row, 19)'GV.ST_VALES
                            Case "EDICION"
                                frmConciValesComEdit.CboStatus.SelectedIndex = 0
                            Case "CAPTURADO"
                                frmConciValesComEdit.CboStatus.SelectedIndex = 1
                            Case "ACEPTADO"
                                frmConciValesComEdit.CboStatus.SelectedIndex = 2
                            Case Else
                                frmConciValesComEdit.CboStatus.SelectedIndex = 0
                        End Select
                        frmConciValesComEdit.TObs.Text = Fg1(Fg1.Row, 20) 'GV.OBS

                        NRow = Fg1.Row
                        ROW_VALOR = Fg1(Fg1.Row, 2)


                        frmConciValesComEdit.ShowDialog()
                        CADENA = ""

                        DESPLEGAR1()

                        NRow = 0
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case 2
                    If Fg3.Row > 0 Then
                        Var1 = "Edit"
                        Var2 = Fg3(Fg3.Row, 1)

                        Var47 = Fg3(Fg3.Row, 15)

                        If Fg3(Fg3.Row, 2) = "Cancelado" Then
                            MsgBox("La conciliación se encuentra cancelada")
                            Return
                        End If

                        NRow = Fg3.Row
                        ROW_VALOR = Fg3(Fg3.Row, 2)


                        frmConciValesCombusAE.ShowDialog()

                        Var47 = ""
                        CADENA = ""
                        DESPLEGAR3()

                        NRow = 0
                        If TBUSCAR.Text.Trim.Length > 0 Then
                            TBUSCAR_TextChanged(Nothing, Nothing)
                        End If


                    Else
                        MsgBox("Por favor seleccione un registro")

                    End If
                Case 3
                    If FgU.Row > 0 Then
                        Var1 = "Edit"
                        Var2 = FgU(FgU.Row, 1)
                        'FACTURA
                        Var3 = FgU(FgU.Row, 17)
                        Var24 = FgU(FgU.Row, 2)

                        If FgU(FgU.Row, 2) = "C" Then
                            MsgBox("La conciliación se encuentra cancelada")
                        End If

                        NRow = FgU.Row
                        ROW_VALOR = FgU(FgU.Row, 2)


                        FrmConciValesUtilitario.ShowDialog()
                        CADENA = ""
                        DESPLEGAR_UTILITARIOS()

                        NRow = 0
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
            End Select
            TBUSCAR.Text = ""
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Tab1_SelectedTabChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedTabChanged
        Entra_Search = False
        Try
            BarImprimirConciIEPS.Visible = False
            Select Case Tab1.SelectedIndex
                Case 0
                    BarImprimirVehiUtil.Visible = False
                    BarNuevo.Visible = False
                    BarPolizaValesDiesel.Visible = False
                    If pwPoder Then
                        BarCambioStatus.Visible = True
                        BarEdit.Visible = True
                    Else
                        If BarCambioStatusD Then BarCambioStatus.Visible = True
                        If BarEditD Then BarEdit.Visible = True
                    End If
                    BarEdit.Text = "Edit"
                    CADENA = ""
                    DESPLEGAR1()
                Case 1
                    BarPolizaValesDiesel.Visible = False
                    If pwPoder Then
                        BarCambioStatus.Visible = True
                    Else
                        If BarCambioStatusD Then BarCambioStatus.Visible = True
                    End If

                    BarNuevo.Visible = False
                    BarEdit.Visible = False
                    BarImprimirVehiUtil.Visible = False
                    CADENA = ""
                    DESPLEGAR2()
                Case 2

                    BarPolizaValesDiesel.Visible = True
                    If pwPoder Then
                        BarImprimirConciIEPS.Visible = True
                        BarNuevo.Visible = True
                        BarEdit.Visible = True
                    Else
                        If BarImprimirD Then BarImprimirConciIEPS.Visible = True
                        If BarNuevoD Then BarNuevo.Visible = True
                        If BarEditD Then BarEdit.Visible = True
                    End If

                    BarEdit.Text = "Edit"
                    BarCambioStatus.Visible = False
                    BarImprimirVehiUtil.Visible = True
                    CADENA = ""
                    DESPLEGAR3()
                Case 3 'VEHICULOS UTILITARIOS

                    BarCambioStatus.Visible = True
                    BarPolizaValesDiesel.Visible = True
                    If pwPoder Then
                        BarNuevo.Visible = True
                        BarEdit.Visible = True
                    Else
                        If BarNuevoD Then BarNuevo.Visible = True
                        If BarEditD Then BarEdit.Visible = True
                    End If
                    BarImprimirVehiUtil.Visible = False

                    BarEdit.Text = "Edit"

                    CADENA = ""
                    DESPLEGAR_UTILITARIOS()

            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND GV.STATUS = 'A' AND GV.FECHA = '" & FSQL(Date.Now) & "' "
                    DESPLEGAR1()
                Case 1
                    CADENA = " WHERE GV.FECHA = '" & FSQL(Date.Now) & "' "
                    DESPLEGAR2()
                Case 2
                    CADENA = " WHERE V.FECHA_DOC = '" & FSQL(Date.Now) & "'"
                    DESPLEGAR3()
                Case 3
                    CADENA = " AND GV.FECHA = '" & FSQL(Date.Now) & "' "
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)

            NRow = 0
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND GV.STATUS = 'A' AND GV.FECHA = '" & FSQL(dt) & "' "
                    DESPLEGAR1()
                Case 1
                    CADENA = " WHERE V.FECHA = '" & FSQL(dt) & "' "
                    DESPLEGAR2()
                Case 2
                    CADENA = " WHERE V.FECHA_DOC = '" & FSQL(dt) & "' "
                    DESPLEGAR3()
                Case 3
                    CADENA = " AND GV.FECHA = '" & FSQL(dt) & "' "
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today
            NRow = 0
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND GV.STATUS = 'A' AND MONTH(GV.FECHA) = " & dt.Month & " AND YEAR(GV.FECHA) = " & dt.Year & " "
                    DESPLEGAR1()
                Case 1
                    CADENA = " WHERE MONTH(V.FECHA) = " & dt.Month & " AND YEAR(V.FECHA) = " & dt.Year & " "
                    DESPLEGAR2()
                Case 2
                    CADENA = " WHERE MONTH(V.FECHA_DOC) = " & dt.Month & " AND YEAR(V.FECHA_DOC) = " & dt.Year & " "
                    DESPLEGAR3()
                Case 3
                    CADENA = " AND MONTH(GV.FECHA) = " & dt.Month & " AND YEAR(GV.FECHA) = " & dt.Year & " "
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            NRow = 0
            dt = dt.AddMonths(-1)
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND V.STATUS = 'A' AND GV.STATUS = 'A' AND MONTH(GV.FECHA) = " & dt.Month & " AND YEAR(GV.FECHA) = " & dt.Year & " "
                    DESPLEGAR1()
                Case 1
                    CADENA = " WHERE V.STATUS = 'A' AND GV.STATUS = 'A' AND MONTH(GV.FECHA) = " & dt.Month & " AND YEAR(GV.FECHA) = " & dt.Year & " "
                    DESPLEGAR2()
                Case 2
                    CADENA = " WHERE MONTH(V.FECHA_DOC) = " & dt.Month & " AND YEAR(V.FECHA_DOC) = " & dt.Year & " "
                    DESPLEGAR3()
                Case 3
                    CADENA = " AND MONTH(GV.FECHA) = " & dt.Month & " AND YEAR(GV.FECHA) = " & dt.Year & " "
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            NRow = 0
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = ""
                    DESPLEGAR1()
                Case 1
                    CADENA = ""
                    DESPLEGAR2()
                Case 2
                    CADENA = ""
                    DESPLEGAR3()
                Case 3
                    CADENA = ""
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            Dim Archivo As String = ""
            Select Case Tab1.SelectedIndex
                Case 0
                    EXPORTAR_EXCEL_TRANSPORT(Fg1, "VALES")
                Case 1
                    EXPORTAR_EXCEL_TRANSPORT(Fg2, "VALES ACEPTADOS")
                Case 2
                    EXPORTAR_EXCEL_TRANSPORT(Fg3, "CONCILIACIONESACEPTADOS")
            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            NRow = 0
            CADENA = ""
            Select Case Tab1.SelectedIndex
                Case 0
                    DESPLEGAR1()
                Case 1
                    DESPLEGAR2()
                Case 2
                    DESPLEGAR3()
                Case 3
                    DESPLEGAR_UTILITARIOS()

            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCambioStatus_Click(sender As Object, e As EventArgs) Handles BarCambioStatus.Click
        Select Case Tab1.SelectedIndex
            Case 1
                Try

                    If Fg2(Fg2.Row, 3) = "Cancelado" Then
                        MsgBox("La conciliación se encuentra cancelada, verifique por por favor")
                        Return
                    End If

                    If Fg2(Fg2.Row, 20) = "CONCILIADO" Then
                        MsgBox("El vale de combustible se encuentra conciliado no es posible cambiar su estatus")
                    Else
                        If Fg2(Fg2.Row, 20) = "EDICION" Or Fg2(Fg2.Row, 20) = "CAPTURADO" Then
                            MsgBox("No es posible cambiar su estatus porque se encuentra con estatus de Edición o Capturado")
                            Return
                        End If
                        If MsgBox("Realmente desea cambiar el estatus a capturado?", vbYesNo) = vbYes Then
                            Try

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET ST_VALES = 'CAPTURADO' WHERE 
                                    CVE_VIAJE = '" & Fg2(Fg2.Row, 1) & "' AND FOLIO = '" & Fg2(Fg2.Row, 2) & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using

                                MsgBox("Proceso terminado")

                                NRow = 0
                                DESPLEGAR2()
                                CADENA = ""
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 0
                Try
                    If Fg1(Fg1.Row, 3) = "Cancelado" Then
                        MsgBox("El vale de combustible se encuentra cancelada no es posible cambiar el estatus, verifique por por favor")
                        Return
                    End If

                    If MsgBox("Realmente desea cambiar el estatus a edición?", vbYesNo) = vbYes Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET ST_VALES = 'EDICION' WHERE UUID = '" & Fg1(Fg1.Row, 21) & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using

                            MsgBox("Proceso terminado")
                            NRow = 0
                            DESPLEGAR1()
                            CADENA = ""
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 3 'VEHICULOS UTILITARIOS
                Try
                    If FgU(FgU.Row, 2) = "CONCILIADO" Then
                        MsgBox("El vale se encuentra CONCILIADO no es posible cambiar estatus")
                        Return
                    End If

                    If MsgBox("Realmente desea cambiar el estatus de vales utilitarios a edición?", vbYesNo) = vbYes Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCASIGNACION_VALES_UTIL SET ST_VALES = 'EDICION' WHERE UUID = '" & FgU(FgU.Row, 19) & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using

                            MsgBox("Proceso terminado")
                            NRow = 0
                            DESPLEGAR_UTILITARIOS()
                            CADENA = ""
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
        End Select
    End Sub
    Private Sub Fg1_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles Fg1.ComboCloseUp
        Try
            If Fg1.Row > 0 Then
                If Fg1.Editor.Text <> Fg1(Fg1.Row, 19) Then
                    If MsgBox("Realmente desea cambiar el estatus del vale?", vbYesNo) = vbYes Then
                        SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET ST_VALES = '" & Fg1.Editor.Text & "' 
                            WHERE CVE_VIAJE = '" & Fg1(Fg1.Row, 1) & "' AND FOLIO = '" & Fg1(Fg1.Row, 2) & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    MsgBox("El estatus del vale de actualizo satisfactoriamente")
                                    CADENA = ""
                                    NRow = 0
                                    DESPLEGAR1()
                                End If
                            End If
                        End Using
                    Else
                        Fg1.Editor.Text = Fg1(Fg1.Row, 19)
                    End If
                End If
            Else
                MsgBox("Por favor seleccione un vale de viaje")
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimirVehiUtil_Click(sender As Object, e As EventArgs) Handles BarImprimirVehiUtil.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim FACTURA As String

            If Fg3(Fg3.Row, 15).ToString.Length > 0 Then
                MsgBox("No es vehiculo utilitario")
                Return
            End If

            If Fg3.Row > 0 Then

                FACTURA = Fg3(Fg3.Row, 5)

                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportVehiculosUtil.mrt"
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
                StiReport1.Item("FACTURA") = FACTURA
                StiReport1.Render()
                'StiReport1.Print(True)
                StiReport1.Show()
            Else
                MsgBox("Por favor seleccione una folio")
            End If

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarPolizaValesDiesel_Click(sender As Object, e As EventArgs) Handles BarPolizaValesDiesel.Click
        Try
            If Tab1.SelectedIndex = 2 Then
                If Fg3.Row > 0 Then
                    If Fg3(Fg3.Row, 2) = "Cerrada" Or Fg3(Fg3.Row, 2) = "Cuentas por pagar" Then

                        If Fg3(Fg3.Row, 13) = "Generada" Then
                            If MsgBox("A esta conciliación ya se genero la poliza modelo, ¿Realmente desea continuar?", vbYesNo) = vbNo Then
                                Return
                            End If
                        End If


                        Var46 = Fg3(Fg3.Row, 1)
                        Var47 = Fg3(Fg3.Row, 15)

                        'Var47 = "VALES COMBUSTIBLE"

                        If FORM_IS_OPEN("FrmPolizaValesDiesel") Then
                            FrmPolizaValesDiesel.Close()
                        End If

                        CREA_TAB(FrmPolizaValesDiesel, "Poliza vales diesel")

                    Else
                        MsgBox("Para poder generar la póliza debe de cerrar la conciliación, verifique por favor")
                    End If
                Else
                    MsgBox("Por favor seleccione una conciliación")
                End If
            Else
                If FgU.Row > 0 Then
                    If FgU(FgU.Row, 2) = "ACEPTADO" Then

                        If FgU(FgU.Row, 20) = "Generada" Then
                            If MsgBox("A esta conciliación ya se genero la poliza modelo, ¿Realmente desea continuar?", vbYesNo) = vbNo Then
                                Return
                            End If
                        End If

                        Var46 = FgU(FgU.Row, 1)
                        Var47 = "UTILITARIOS"

                        If FORM_IS_OPEN("FrmPolizaValesDiesel") Then
                            FrmPolizaValesDiesel.Close()
                        End If
                        CREA_TAB(FrmPolizaValesDiesel, "Poliza vales diesel")

                    Else
                        MsgBox("Para poder generar la póliza debe de cerrar la conciliación, verifique por favor")
                    End If
                Else
                    MsgBox("Por favor seleccione una conciliación")
                End If
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg3_DoubleClick(sender As Object, e As EventArgs) Handles Fg3.DoubleClick
        If Fg3.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg3(Fg3.Row, 1)

            Var46 = Fg3(Fg3.Row, 6)
            Var47 = Fg3(Fg3.Row, 15)

            If Fg3(Fg3.Row, 2) = "C" Then
                MsgBox("La conciliación se encuentra cancelada")
            End If

            NRow = Fg3.Row

            frmConciValesCombusAE.ShowDialog()
            CADENA = ""
            DESPLEGAR3()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub Fg1_DoubleClick(sender As Object, e As EventArgs) Handles Fg1.DoubleClick
        If Fg1.Row > 0 Then

            barEdit_Click(Nothing, Nothing)

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Sub IMPRIMIR_UTILS_VIA_IEPS(FFACTURA As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportVehiculosUtil.mrt"
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
            StiReport1.Item("FACTURA") = FFACTURA
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarImprimirConciIEPS_Click(sender As Object, e As EventArgs) Handles BarImprimirConciIEPS.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim CVE_COVC As Long, FACTURA As String

            If Fg3.Row > 0 Then
                FACTURA = Fg3(Fg3.Row, 5)
                If FACTURA.Trim.Length = 0 Then
                    MsgBox("Por favor capture la factura de la concilaición")
                    Return
                End If
                If Fg3(Fg3.Row, 15).ToString.Trim.Length = 0 Then
                    IMPRIMIR_UTILS_VIA_IEPS(FACTURA)
                Else
                    CVE_COVC = Fg3(Fg3.Row, 1)

                    RUTA_FORMATOS = GET_RUTA_FORMATOS()
                    If Not File.Exists(RUTA_FORMATOS & "\ReportConciValesCombusIEPS.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportConciValesCombusIEPS.mrt, verifique por favor")
                        Return
                    End If
                    StiReport1.Load(RUTA_FORMATOS & "\ReportConciValesCombusIEPS.mrt")

                    Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                    StiReport1.Dictionary.Databases.Clear()
                    StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                    StiReport1.Compile()
                    StiReport1.Dictionary.Synchronize()
                    StiReport1.ReportName = Me.Text
                    StiReport1.Item("CVE_COVC") = CVE_COVC
                    StiReport1.Item("FACTURA") = FACTURA


                    StiReport1.Render()
                    'StiReport1.Print(True)
                    StiReport1.Show()
                End If
            Else
                MsgBox("Por favor seleccione una conciliacion")
            End If

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg1_SearchApplied(sender As Object, e As SearchAppliedEventArgs) Handles Fg1.SearchApplied
        Dim data() As String = New String() {}
        Dim n As Long = 0, Sigue As Boolean = True

        Dim i As Integer
        For i = 1 To Fg1.Rows.Count - 1
            If (Not (Fg1(i, 2)) Is Nothing) Then
                If Fg1(i, 2).ToString.Contains(e.Text) Then
                    n = i
                    Exit For
                    'n = n + 1
                    'Array.Resize(data, n)
                    'data(n - 1) = Fg1(i, 1).ToString
                End If
            End If
        Next
        Fg1.Row = n
        'Dim f As C1.Win.C1FlexGrid.ValueFilter = New C1.Win.C1FlexGrid.ValueFilter
        'f.ShowValues = data
        'Fg1.Cols(1).Filter = f
        'Fg1.ApplyFilters()
    End Sub
    Private Sub TBUSCAR_TextChanged(sender As Object, e As EventArgs) Handles TBUSCAR.TextChanged
        Try

            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND (GV.CVE_VIAJE LIKE '%" & TBUSCAR.Text & "%' OR GV.FOLIO LIKE '%" & TBUSCAR.Text & "%' OR 
                        V.CVE_TRACTOR LIKE '%" & TBUSCAR.Text & "%' OR O.NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR  G.CVE_PROV LIKE '%" & TBUSCAR.Text & "%' OR
                        P.NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR G.DESCR LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.LITROS LIKE '%" & TBUSCAR.Text & "%' OR GV.LITROS_REALES LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.P_X_LITRO LIKE '%" & TBUSCAR.Text & "%' OR GV.FACTURA LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.ST_VALES LIKE '%" & TBUSCAR.Text & "%' OR GV.OBS LIKE '%" & TBUSCAR.Text & "%')"
                    DESPLEGAR1()
                Case 1
                    CADENA = " WHERE (GV.CVE_VIAJE LIKE '%" & TBUSCAR.Text & "%' OR GV.FOLIO LIKE '%" & TBUSCAR.Text & "%' OR 
                        V.CVE_TRACTOR LIKE '%" & TBUSCAR.Text & "%' OR O.NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR  G.CVE_PROV LIKE '%" & TBUSCAR.Text & "%' OR
                        P.NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR G.DESCR LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.LITROS LIKE '%" & TBUSCAR.Text & "%' OR GV.LITROS_REALES LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.P_X_LITRO LIKE '%" & TBUSCAR.Text & "%' OR GV.FACTURA LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.ST_VALES LIKE '%" & TBUSCAR.Text & "%' OR GV.OBS LIKE '%" & TBUSCAR.Text & "%')"
                    DESPLEGAR2()
                Case 2
                    CADENA = " WHERE (V.CVE_COVC LIKE '%" & TBUSCAR.Text & "%' OR V.CVE_PROV LIKE '%" & TBUSCAR.Text & "%' OR 
                        NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR  V.CVE_DOC LIKE '%" & TBUSCAR.Text & "%')"
                    DESPLEGAR3()
                Case 3
                    CADENA = " AND (GV.FOLIO LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.CVE_TRACTOR LIKE '%" & TBUSCAR.Text & "%' OR O.NOMBRE LIKE '%" & TBUSCAR.Text & "%' OR 
                        G.DESCR LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.LTS_INICIALES LIKE '%" & TBUSCAR.Text & "%' OR GV.LITROS_REALES LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.P_X_LITRO LIKE '%" & TBUSCAR.Text & "%' OR GV.FACTURA LIKE '%" & TBUSCAR.Text & "%' OR 
                        GV.ST_VALES LIKE '%" & TBUSCAR.Text & "%' OR GV.OBS LIKE '%" & TBUSCAR.Text & "%')"
                    DESPLEGAR_UTILITARIOS()
            End Select
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBUSCAR_KeyDown(sender As Object, e As KeyEventArgs) Handles TBUSCAR.KeyDown
        Try
            If e.KeyCode = 13 Then
                barEdit_Click(Nothing, Nothing)
            End If
            If e.KeyCode = Keys.Down Then
                Select Case Tab1.SelectedIndex
                    Case 0
                        Fg1.Select()
                    Case 1
                        Fg2.Select()
                    Case 2
                        Fg3.Select()
                    Case 3
                        FgU.Select()
                End Select
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBUSCAR_GotFocus(sender As Object, e As EventArgs) Handles TBUSCAR.GotFocus
        TBUSCAR.BorderStyle = BorderStyle.Fixed3D
        TBUSCAR.BorderColor = Color.Red
        TBUSCAR.SelectAll()
    End Sub
    Private Sub TBUSCAR_LostFocus(sender As Object, e As EventArgs) Handles TBUSCAR.LostFocus
        TBUSCAR.BorderColor = Color.FromArgb(179, 199, 209)
    End Sub
    Private Sub Fg1_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg1.OwnerDrawCell
        Try
            Dim cs1 As CellStyle
            cs1 = Fg1.Styles.Add("CS1")
            cs1.BackColor = Color.White
            cs1.ForeColor = Color.Black
            cs1.Font = New Font("Tahoma", 9, FontStyle.Bold)

            Dim cs2 As CellStyle
            cs2 = Fg1.Styles.Add("CS2")
            cs2.BackColor = Color.Red
            cs2.ForeColor = Color.White
            cs2.Font = New Font("Tahoma", 10, FontStyle.Bold)

            If e.Row >= Fg1.Rows.Fixed And e.Col = Fg1.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg1.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                Select Case Fg1(e.Row, 3)
                    Case "Cancelado"
                        Fg1.SetCellStyle(e.Row, 3, cs2)
                    Case Else
                        Fg1.SetCellStyle(e.Row, 3, cs1)
                End Select
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg2_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg2.OwnerDrawCell
        Try
            Dim cs2 As CellStyle
            cs2 = Fg2.Styles.Add("CS2")
            cs2.BackColor = Color.Red
            cs2.ForeColor = Color.White
            cs2.Font = New Font(Font, FontStyle.Bold)

            If e.Row >= Fg2.Rows.Fixed And e.Col = Fg2.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg2.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                Select Case Fg2(e.Row, 3)
                    Case "Cancelado"
                        Fg2.SetCellStyle(e.Row, 3, cs2)
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarFiltro_Click(sender As Object, e As EventArgs) Handles BarFiltro.Click
        Dim CADENA_PROV As String = ""

        If Tab1.SelectedIndex = 3 Then
            Var8 = "UTILITARIOS"
        Else
            Var8 = ""
        End If

        Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
        FrmFiltroConciValCombus.ShowDialog()
        If Var2.Trim.Length > 0 Then

            Select Case Tab1.SelectedIndex
                Case 0, 1
                    If Var4.Trim.Length > 0 And Var5.Trim.Length > 0 Then
                        CADENA_PROV = " AND G.CVE_PROV >= '" & Var4 & "' AND G.CVE_PROV <= '" & Var5 & "'"
                    Else
                        If Var4.Trim.Length > 0 And Var5.Trim.Length = 0 Then
                            CADENA_PROV = " AND G.CVE_PROV >= '" & Var4 & "'"
                        Else
                            If Var4.Trim.Length = 0 And Var5.Trim.Length > 0 Then
                                CADENA_PROV = " AND G.CVE_PROV <= '" & Var5 & "'"
                            End If
                        End If
                    End If
                Case 2
                    If Var4.Trim.Length > 0 And Var5.Trim.Length > 0 Then
                        CADENA_PROV = " AND V.CVE_PROV >= '" & Var4 & "' AND V.CVE_PROV <= '" & Var5 & "'"
                    Else
                        If Var4.Trim.Length > 0 And Var5.Trim.Length = 0 Then
                            CADENA_PROV = " AND V.CVE_PROV >= '" & Var4 & "'"
                        Else
                            If Var4.Trim.Length = 0 And Var5.Trim.Length > 0 Then
                                CADENA_PROV = " AND V.CVE_PROV <= '" & Var5 & "'"
                            End If
                        End If
                    End If
                Case 3

            End Select

            Try
                Select Case Tab1.SelectedIndex
                    Case 0 'V.STATUS = 'A' AND GV.STATUS = 'A' AND 
                        CADENA = " AND V.STATUS = 'A' AND GV.STATUS = 'A' AND GV.FECHA >= '" & Var2 & "' AND GV.FECHA <= '" & Var3 & "'" & CADENA_PROV
                        DESPLEGAR1()
                    Case 1 'V.STATUS = 'A' AND GV.STATUS = 'A' 
                        CADENA = " WHERE V.STATUS = 'A' AND GV.STATUS = 'A' AND GV.FECHA >= '" & Var2 & "' AND GV.FECHA <= '" & Var3 & "'" & CADENA_PROV
                        DESPLEGAR2()
                    Case 2
                        CADENA = " WHERE V.STATUS <> 'C' AND V.FECHA_DOC >= '" & Var2 & "' AND V.FECHA_DOC <= '" & Var3 & "'" & CADENA_PROV
                        DESPLEGAR3()
                    Case 3
                        CADENA = " AND GV.FECHA >= '" & Var2 & "' AND GV.FECHA <= '" & Var3 & "'"
                        DESPLEGAR_UTILITARIOS()
                End Select
            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg3_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg3.OwnerDrawCell
        Try
            Dim cs1 As CellStyle
            cs1 = Fg1.Styles.Add("CS1")
            cs1.BackColor = Color.Violet
            cs1.ForeColor = Color.Black
            cs1.Font = New Font("Tahoma", 9, FontStyle.Bold)

            Dim cs2 As CellStyle
            cs2 = Fg3.Styles.Add("CS2")
            cs2.BackColor = Color.Red
            cs2.ForeColor = Color.White
            cs2.Font = New Font(Font, FontStyle.Bold)

            If e.Row >= Fg3.Rows.Fixed And e.Col = Fg3.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg3.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                Select Case Fg3(e.Row, 2)
                    Case "Cancelado"
                        Fg3.SetCellStyle(e.Row, 2, cs2)
                End Select
                If Not IsNothing(Fg3(e.Row, 15)) Then
                    If Fg3(e.Row, 15).ToString.Trim.Length = 0 Then
                        Fg3.SetCellStyle(e.Row, 1, cs1)
                        Fg3.SetCellStyle(e.Row, 2, cs1)
                        Fg3.SetCellStyle(e.Row, 3, cs1)
                        Fg3.SetCellStyle(e.Row, 4, cs1)
                        Fg3.SetCellStyle(e.Row, 5, cs1)
                        Fg3.SetCellStyle(e.Row, 6, cs1)
                        Fg3.SetCellStyle(e.Row, 7, cs1)
                        Fg3.SetCellStyle(e.Row, 8, cs1)
                        Fg3.SetCellStyle(e.Row, 9, cs1)
                        Fg3.SetCellStyle(e.Row, 9, cs1)
                        Fg3.SetCellStyle(e.Row, 10, cs1)
                        Fg3.SetCellStyle(e.Row, 11, cs1)
                        Fg3.SetCellStyle(e.Row, 12, cs1)
                        Fg3.SetCellStyle(e.Row, 13, cs1)
                        Fg3.SetCellStyle(e.Row, 14, cs1)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgU_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgU.OwnerDrawCell
        Try
            If e.Row >= FgU.Rows.Fixed And e.Col = FgU.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - FgU.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg1_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg1.KeyDown
        Try
            If e.KeyCode = 13 Then
                barEdit_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg2_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg2.KeyDown
        Try
            If e.KeyCode = 13 Then
                barEdit_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg3_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg3.KeyDown
        Try
            If e.KeyCode = 13 Then
                barEdit_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TBUSCAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBUSCAR.KeyPress
        Try
            If e.KeyChar = "'" Then
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgU_DoubleClick(sender As Object, e As EventArgs) Handles FgU.DoubleClick
        barEdit_Click(Nothing, Nothing)
    End Sub
End Class
