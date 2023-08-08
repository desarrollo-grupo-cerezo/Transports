Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command
Public Class FrmReportConsolidado
    Private Sub FrmReportConsolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Dim i As Integer = 1
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

            Me.CenterToScreen()

            If PASS_GRUPOCE = "BUS" Then
                F1.Value = "01/04/2022"
                F2.Value = "30/04/2022"
            End If
            Fg.Rows.Count = 1

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmReportConsolidado_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String = "", SUMA As Decimal = 0, SUMA1 As Decimal = 0, SUMA2 As Decimal = 0, SUMA3 As Decimal = 0
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow

        If Fg.Rows.Count = 1 Then
            MsgBox("Por favor despliegue el consolidado")
            Return
        End If

        RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportConsolidado.mrt"
        If Not File.Exists(RUTA_FORMATOS) Then
            MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
            Return
        End If

        BarImprimir.Enabled = False

        Try
            DataSet1.Clear()

            r = t.NewRow()
            r("DESCR") = Fg(1, 1)
            r("IMPORTE") = Fg(1, 2)
            t.Rows.Add(r)

            r = t.NewRow()
            r("DESCR") = Fg(2, 1)
            r("IMPORTE") = Fg(2, 2)
            t.Rows.Add(r)

            r = t.NewRow()
            r("DESCR") = Fg(3, 1)
            r("IMPORTE") = Fg(3, 2)
            t.Rows.Add(r)

            r = t.NewRow()
            r("DESCR") = Fg(4, 1)
            r("IMPORTE") = Fg(4, 2)
            t.Rows.Add(r)

            r = t.NewRow()
            r("DESCR") = Fg(5, 1)
            r("IMPORTE") = Fg(5, 2)
            t.Rows.Add(r)

            StiReport1.Load(RUTA_FORMATOS)
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1("FF1") = F1.Value
            StiReport1("FF2") = F2.Value
            StiReport1.RegData("Datos1", DataSet1)
            StiReport1.Render()
            'StiReport1.Design()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try

        BarImprimir.Enabled = True
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim SUMA As Decimal = 0, SUMA1 As Decimal = 0, SUMA2 As Decimal = 0, SUMA3 As Decimal = 0
        Dim CADENA_UNIDAD As String = "", CADENA_UNIDAD2 As String = "", CADENA2 As String

        Me.Cursor = Cursors.WaitCursor
        Fg.Rows.Count = 1

        '(U.CVE_TIPO_UNI = " & TRACTOR & " OR U.CVE_TIPO_UNI = " & TANQUE & " OR U.CVE_TIPO_UNI = " & DOLLY & " OR 
        'u.CVE_TIPO_UNI = " & UTILITARIO & ") AND 

        If ChTractor.Checked Then
            CADENA_UNIDAD = "U.CVE_TIPO_UNI = 1 OR "
            CADENA_UNIDAD2 = "dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 1 OR "
        End If
        If ChTanque.Checked Then
            CADENA_UNIDAD += "U.CVE_TIPO_UNI = 2 OR "
            CADENA_UNIDAD2 += "dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 2 OR "
        End If
        If ChDolly.Checked Then
            CADENA_UNIDAD += "U.CVE_TIPO_UNI = 3 OR "
            CADENA_UNIDAD2 += "dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 3 OR "
        End If
        If ChUtilitario.Checked Then
            CADENA_UNIDAD += "U.CVE_TIPO_UNI = 7 OR "
            CADENA_UNIDAD2 += "dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 7 OR "
        End If

        If Not ChTractor.Checked And Not ChTanque.Checked And Not ChDolly.Checked And Not ChUtilitario.Checked Then
            CADENA_UNIDAD = ""
        Else
            CADENA_UNIDAD = CADENA_UNIDAD.Substring(0, CADENA_UNIDAD.Length - 4)
            CADENA_UNIDAD = " AND (" & CADENA_UNIDAD & ")"

            CADENA_UNIDAD2 = CADENA_UNIDAD2.Substring(0, CADENA_UNIDAD2.Length - 4)
            CADENA_UNIDAD2 = " AND (" & CADENA_UNIDAD2 & ")"
        End If


        'REPORTE DE SALIDAS X UNIDAD CON MOVIMIENTOS AL INVENTARIO  ALAMCENES 1, 2 Y 8
        Try
            CADENA2 = " FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND FECHA_DOCU <= '" & FSQL(F2.Value) & "'"

            SQL = "SELECT P.CVE_ORD, O.CVE_UNI AS CVE_TRAC, P.CVE_ART, I.DESCR AS DES, I.LIN_PROD, P.CANT, U.CVE_TIPO_UNI,
                P.CVE_ALM, ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.IMPORTE AS IMPORT, A.DESCR AS DESCR_ALM,
                ISNULL((SELECT SUM(CANT * COSTO * SIGNO) FROM MINVE" & Empresa & " WHERE " & CADENA2 & " AND 
                REFER LIKE '%OT' + P.CVE_ORD + '%' AND CVE_ART = P.CVE_ART AND CVE_FOLIO = P.CVE_PROV),0) AS RESULT
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
                LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.TIEMPO_REAL    
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.CVE_ALM
                WHERE O.STATUS <> 'C' AND O.FECHA >=  '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "'" &
                CADENA_UNIDAD & " AND ISNULL(P.CVE_ALM,0) in (1,2,8)
                ORDER BY O.CVE_UNI"

            SQL = "SELECT P.CVE_ORD, O.CVE_UNI AS CVE_TRAC, P.CVE_ART, I.DESCR AS DES, I.LIN_PROD, P.CANT, U.CVE_TIPO_UNI,
                P.CVE_ALM, ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.IMPORTE AS IMPORT, A.DESCR AS DESCR_ALM,                
                (M.CANT * M.COSTO * M.SIGNO) AS IMPORTE_M
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN MINVE" & Empresa & " M ON M.CVE_ART = P.CVE_ART AND M.CVE_FOLIO = P.CVE_PROV
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
                LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.TIEMPO_REAL    
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.CVE_ALM
                WHERE O.STATUS <> 'C' AND M.FECHA_DOCU >=  '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "'" &
                CADENA_UNIDAD & " AND ISNULL(P.CVE_ALM,0) in (1,2,8) AND REFER LIKE '%OT' + P.CVE_ORD + '%'
                ORDER BY O.CVE_UNI"

            Try '1
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            If dr("IMPORTE_M") < 0 Then
                                SUMA += Math.Abs(dr("IMPORTE_M"))
                            End If
                        End While
                    End Using
                End Using
                Fg.AddItem("1" & vbTab & "ORDENES INTERNAS" & vbTab & SUMA)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            'RONOVADOS
            Try '2
                SQL = "SELECT MAX(CVE_UNI) AS CVEUNI, MAX(NUM_ALM) AS NUMALM, 
                    SUM(COSTO) AS COST, MAX(O1.DESCR) AS DES_DOC, MAX(O2.DESCR) AS DES_PAR
                    FROM GCGASTOS_RENOVADO G
                    LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = G.CVE_UNI 
                    LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                    LEFT JOIN GCOBS O2 ON O2.CVE_OBS = G.CVE_OBS_PAR
                    WHERE ISNULL(G.STATUS,'A') = 'A' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'" &
                    CADENA_UNIDAD & " AND  ISNULL(G.NUM_ALM,0) in (3) 
                    GROUP BY CVE_UNI"
                SUMA = 0
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            SUMA += dr("COST")
                        End While
                    End Using
                End Using
                Fg.AddItem("2" & vbTab & "RENOVADOS" & vbTab & SUMA)
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'SALIDAS X UNIDAD CON MOVIMIENTOS AL INVENTARIO ALMACENES 3,4,5,6,7 Y 10
        'SALIDAS X UNIDAD CON MOVIMIENTOS AL INVENTARIO ALMACENES 3,4,5,6,7 Y 10
        '████████████████████████████████████████████████████████████████████████

        CADENA2 = " FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND FECHA_DOCU <= '" & FSQL(F2.Value) & "'"

        SQL = "SELECT P.CVE_ORD, O.CVE_UNI AS CVE_TRAC, P.CVE_ART, I.DESCR AS DES, I.LIN_PROD, P.CANT, U.CVE_TIPO_UNI,
            P.CVE_ALM, ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.IMPORTE AS IMPORT, A.DESCR AS DESCR_ALM,
            ISNULL((SELECT SUM(CANT * COSTO * SIGNO) FROM MINVE" & Empresa & " WHERE " & CADENA2 & " AND 
            REFER LIKE '%OT' + P.CVE_ORD + '%' AND CVE_FOLIO = P.CVE_PROV),0) AS RESULT
            FROM GCORDEN_TRA_SER_EXT P
            LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
            LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
            LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.TIEMPO_REAL    
            LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
            LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
            LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.CVE_ALM
            WHERE O.STATUS <> 'C' AND O.FECHA >=  '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "'" &
            CADENA_UNIDAD & " AND  ISNULL(P.CVE_ALM,0) in (4,5,6,7,10)
            ORDER BY O.CVE_UNI"
        SUMA = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If dr("RESULT") < 0 Then
                            SUMA += Math.Abs(dr("RESULT"))
                        End If
                    End While
                End Using
            End Using
            Fg.AddItem("3" & vbTab & "LLANTAS Y RHINES" & vbTab & SUMA)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        'RONOVADOS
        Try
            SQL = "SELECT MAX(CVE_UNI) AS CVEUNI, MAX(NUM_ALM) AS NUMALM, 
                SUM(COSTO) AS COST, MAX(O1.DESCR) AS DES_DOC, MAX(O2.DESCR) AS DES_PAR
                FROM GCGASTOS_RENOVADO G
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = G.CVE_UNI 
                LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                LEFT JOIN GCOBS O2 ON O2.CVE_OBS = G.CVE_OBS_PAR
                WHERE ISNULL(G.STATUS,'A') = 'A' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "'" &
                CADENA_UNIDAD & " AND 
                ISNULL(G.NUM_ALM,0) in (3)
                GROUP BY CVE_UNI"
            SUMA = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA += dr("COST")
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'ORDENES DE TRABAJO EXTERNAS
        Try
            SQL = "SELECT (M.COSTO * M.CANT) AS IMPORTE
                FROM MINVE" & Empresa & " M
                LEFT JOIN GCMECANICOS ON GCMECANICOS.CVE_MEC = M.CLAVE_CLPV
                WHERE M.FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' AND 
                M.CVE_CPTO = 62 AND ISNULL(M.CLAVE_CLPV, '') <> '' AND 
                ISNULL(dbo.GCMECANICOS.STATUS, 'A') = 'A'"
            SUMA1 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA1 += dr("IMPORTE")
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT (M.COSTO * M.CANT) AS IMPORTE
                FROM MINVE" & Empresa & " M
                LEFT JOIN dbo.GCOPERADOR ON dbo.GCOPERADOR.CLAVE = M.CLAVE_CLPV
                WHERE M.FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' AND 
                M.CVE_CPTO = 63 AND ISNULL(CLAVE_CLPV,'') <> '' AND ISNULL(dbo.GCOPERADOR.STATUS,'A') = 'A'"
            SUMA2 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA2 += dr("IMPORTE")
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT (M.COSTO * M.CANT) AS IMPORTE
                FROM MINVE" & Empresa & " M 
                WHERE M.FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' AND 
                (M.CVE_CPTO = 64 OR M.CVE_CPTO = 65 OR M.CVE_CPTO = 68 OR M.CVE_CPTO = 70)"
            SUMA3 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA3 += dr("IMPORTE")
                    End While
                End Using

            End Using
            If ChTractor.Checked And ChTanque.Checked And ChDolly.Checked And ChUtilitario.Checked Then
                Fg.AddItem("4" & vbTab & "SALIDAS DE ALMACEN DIRECTAS" & vbTab & 0)
            Else
                Fg.AddItem("4" & vbTab & "SALIDAS DE ALMACEN DIRECTAS" & vbTab & SUMA1 + SUMA2 + SUMA3)
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        'OT 9
        Try
            SQL = "SELECT GCORDEN_TRA_SER_EXT.CVE_ORD, GCORDEN_TRA_SER_EXT.CVE_ART,  GCORDEN_TRA_SER_EXT.IMPORTE, GCORDEN_TRA_SER_EXT.DESCR,
                GCORDEN_TRA_SER_EXT.CANT, GCORDEN_TRA_SER_EXT.COSTO, GCORDEN_TRA_SER_EXT.TIEMPO_REAL, dbo.GCORDEN_TRABAJO_EXT.FECHA,
                dbo.GCORDEN_TRABAJO_EXT.CVE_UNI, GCORDEN_TRA_SER_EXT.NO_PARTE,  dbo.COMPC" & Empresa & ".FECHAELAB AS F_ELAB_CO, dbo.COMPC" & Empresa & ".IMPORTE AS IMPORTE_CO,
                dbo.COMPO" & Empresa & ".FECHAELAB AS F_ELAB_OC, dbo.COMPC" & Empresa & ".CVE_DOC AS CVE_DOC_CO, GCORDEN_TRA_SER_EXT.CVE_ALM, dbo.COMPO" & Empresa & ".IMPORTE AS IMPORTE_OC,
                CASE WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 1 THEN 'TRACTOR' WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 2 THEN 'TANQUE' 
                WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 3 THEN 'DOLLY' ELSE 'UTILITARIO' END AS TIP_UNI
                FROM GCORDEN_TRA_SER_EXT 
                LEFT JOIN dbo.GCORDEN_TRABAJO_EXT ON GCORDEN_TRA_SER_EXT.CVE_ORD = dbo.GCORDEN_TRABAJO_EXT.CVE_ORD 
                LEFT JOIN dbo.COMPO" & Empresa & " ON GCORDEN_TRA_SER_EXT.TIEMPO_REAL = dbo.COMPO" & Empresa & ".CVE_DOC 
                LEFT JOIN dbo.COMPC" & Empresa & " ON dbo.COMPO" & Empresa & ".CVE_DOC = dbo.COMPC" & Empresa & ".DOC_ANT
                WHERE GCORDEN_TRA_SER_EXT.CVE_ALM = 9 AND dbo.GCORDEN_TRABAJO_EXT.STATUS <> 'C' AND dbo.GCORDEN_TRABAJO_EXT.A_M = 'M'" &
                CADENA_UNIDAD2 & " AND dbo.GCORDEN_TRABAJO_EXT.FECHA >=  '" & FSQL(F1.Value) & "' AND dbo.GCORDEN_TRABAJO_EXT.FECHA <= '" & FSQL(F2.Value) & "'"
            SUMA2 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA2 += dr("IMPORTE")
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'OT <> 9
        Try
            SQL = "SELECT GCORDEN_TRA_SER_EXT.CVE_ORD, GCORDEN_TRA_SER_EXT.CVE_ART, GCORDEN_TRA_SER_EXT.IMPORTE, GCORDEN_TRA_SER_EXT.DESCR,
                GCORDEN_TRA_SER_EXT.CANT, GCORDEN_TRA_SER_EXT.COSTO, GCORDEN_TRA_SER_EXT.TIEMPO_REAL, dbo.GCORDEN_TRABAJO_EXT.FECHA,
                dbo.GCORDEN_TRABAJO_EXT.CVE_UNI, GCORDEN_TRA_SER_EXT.NO_PARTE, dbo.COMPC" & Empresa & ".FECHAELAB AS F_ELAB_CO, dbo.COMPC" & Empresa & ".IMPORTE AS IMPORTE_CO,
                dbo.COMPO" & Empresa & ".FECHAELAB AS F_ELAB_OC, dbo.COMPC" & Empresa & ".CVE_DOC AS CVE_DOC_CO, GCORDEN_TRA_SER_EXT.CVE_ALM, dbo.COMPO" & Empresa & ".IMPORTE AS IMPORTE_OC,
                CASE WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 1 THEN 'TRACTOR' WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 2 THEN 'TANQUE' 
                WHEN dbo.GCORDEN_TRABAJO_EXT.CVE_TIPO = 3 THEN 'DOLLY' ELSE 'UTILITARIO' END AS TIP_UNI
                FROM GCORDEN_TRA_SER_EXT 
                LEFT JOIN dbo.GCORDEN_TRABAJO_EXT ON GCORDEN_TRA_SER_EXT.CVE_ORD = dbo.GCORDEN_TRABAJO_EXT.CVE_ORD 
                LEFT JOIN dbo.COMPO" & Empresa & " ON GCORDEN_TRA_SER_EXT.TIEMPO_REAL = dbo.COMPO" & Empresa & ".CVE_DOC 
                LEFT JOIN dbo.COMPC" & Empresa & " ON dbo.COMPO" & Empresa & ".CVE_DOC = dbo.COMPC" & Empresa & ".DOC_ANT
                WHERE GCORDEN_TRA_SER_EXT.CVE_ALM <> 9 AND dbo.GCORDEN_TRABAJO_EXT.STATUS <> 'C' AND dbo.GCORDEN_TRABAJO_EXT.A_M = 'M'" &
                CADENA_UNIDAD2 & " AND
                dbo.GCORDEN_TRABAJO_EXT.FECHA >= '" & FSQL(F1.Value) & "' AND dbo.GCORDEN_TRABAJO_EXT.FECHA <= '" & FSQL(F2.Value) & "'"
            SUMA = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SUMA += dr("IMPORTE")
                    End While
                End Using
            End Using
            Fg.AddItem("5" & vbTab & "ORDENES EXTERNAS" & vbTab & SUMA + SUMA2)

            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                SUMA += Fg(k, 2)
            Next
            Fg.AddItem("" & vbTab & "Total" & vbTab & SUMA)
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            If Fg.Rows.Count = 1 Then
                MsgBox("Por favor despliegue el consolidado")
                Return
            End If

            EXPORTAR_EXCEL_TRANSPORT(Fg, "Consolidado")
        Catch ex As Exception
        End Try
    End Sub
End Class
