Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Themes
Imports Stimulsoft
Imports Stimulsoft.Report

Public Class FrmReportViajesLiq
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmReportViajesLiq_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

    End Sub
    Sub CARGAR_DATOS()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Dim N = DateTime.Now.AddMonths(-1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        Try
            F1.Value = d1
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            F1.Clear()
        Catch ex As Exception
        End Try
        Try
            F2.Value = d2
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"
            F2.Clear()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FrmReportViajesLiq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Dim CADENA As String = "", CADENA_OPER As String = "", CADENA_ORDER As String = "", TON1 As Decimal = 0, TON2 As Decimal = 0
        Dim CVE_ART As String = "", DESCR As String = "", FEC1 As Date, FEC2 As Date, PORFECHA As String = "", KM As Decimal = 0
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow
        Dim Reporte As New StiReport
        DataSet1.Clear()

        Try
            If RadViaje.Checked Then
                CADENA = "V.FECHA >= '" & FSQL(F1.Value) & "' AND V.FECHA <= '" & FSQL(F2.Value) & "'"
                CADENA_ORDER = "V.FECHA"
                PORFECHA = "Por fecha de viaje"
            ElseIf RadCarga.Checked Then
                CADENA = "V.FECHA_CARGA >= '" & FSQL(F1.Value) & "' AND V.FECHA_CARGA <= '" & FSQL(F2.Value) & "'"
                CADENA_ORDER = "V.FECHA_CARGA"
                PORFECHA = "Por fecha de carga"
            ElseIf RadCargaCartaPorte.Checked Then
                CADENA = "CP.FECHA_CARGA >= '" & FSQL(F1.Value) & "' AND CP.FECHA_CARGA <= '" & FSQL(F2.Value) & "'"
                CADENA_ORDER = "CP.FECHA_CARGA"
                PORFECHA = "Por fecha de carga carta porte"
            Else
                CADENA = "L.FECHA >= '" & FSQL(F1.Value) & "' AND L.FECHA <= '" & FSQL(F2.Value) & "'"
                CADENA_ORDER = "L.FECHA"
                PORFECHA = "Por fecha de liquidación"
            End If

            If TCVE_OPER.Text.Trim.Length > 0 Then
                CADENA_OPER = " AND V.CVE_OPER = '" & TCVE_OPER.Text & "'"
            End If
            CADENA_ORDER = CADENA_ORDER & ", V.CVE_OPER"

            FEC1 = F1.Value
            FEC2 = F2.Value


            If RadCargaCartaPorte.Checked Then
                SQL = "SELECT V.CVE_VIAJE, V.CVE_DOC, V.FECHA, V.CVE_ST_VIA, V.CVE_TRACTOR, V.CVE_TANQUE1, V.CVE_TANQUE2,
                    ISNULL(V.CVE_CAP1,'') AS PORTE1, ISNULL(V.CVE_CAP2,'') AS PORTE2, ISNULL(RECOGER.DESCR,'') AS ORIGEN, ISNULL(ENTREGAR.DESCR,'') AS DESTINO,
                    O.NOMBRE AS OPERADOR, V.FECHA_CARGA, V.FECHA_DESCARGA, ISNULL(V.KM_RECORRIDOS,0) AS KM_REC, CP.FECHA_DOC, ISNULL(LP.SUELDO,0) AS SUELDO_OP
                    FROM GCASIGNACION_VIAJE V
                    LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = V.CVE_CAP1
                    LEFT JOIN GCLIQ_PARTIDAS LP ON LP.CVE_VIAJE = V.CVE_VIAJE 
                    LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LP.CVE_LIQ
                    LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN RECOGER ON V.RECOGER_EN = RECOGER.CVE_REG 
                    LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN ENTREGAR ON V.ENTREGAR_EN = ENTREGAR.CVE_REG 
                    LEFT JOIN dbo.GCOPERADOR O ON V.CVE_OPER = O.CLAVE 
                    WHERE V.CVE_ST_VIA = '5' AND LP.STATUS = 'A' AND " & CADENA & CADENA_OPER & "
                    ORDER BY " & CADENA_ORDER
            Else
                SQL = "SELECT V.CVE_VIAJE, V.CVE_DOC, V.FECHA, V.CVE_ST_VIA, V.CVE_TRACTOR, V.CVE_TANQUE1, V.CVE_TANQUE2,
                    ISNULL(V.CVE_CAP1,'') AS PORTE1, ISNULL(V.CVE_CAP2,'') AS PORTE2, ISNULL(RECOGER.DESCR,'') AS ORIGEN, ISNULL(ENTREGAR.DESCR,'') AS DESTINO,
                    O.NOMBRE AS OPERADOR, V.FECHA_CARGA, V.FECHA_DESCARGA, ISNULL(V.KM_RECORRIDOS,0) AS KM_REC, CP.FECHA_DOC, ISNULL(LP.SUELDO,0) AS SUELDO_OP
                    FROM GCASIGNACION_VIAJE V
                    LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = V.CVE_CAP1
                    LEFT JOIN GCLIQ_PARTIDAS LP ON LP.CVE_VIAJE = V.CVE_VIAJE 
                    LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LP.CVE_LIQ
                    LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN RECOGER ON V.RECOGER_EN = RECOGER.CVE_REG 
                    LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN ENTREGAR ON V.ENTREGAR_EN = ENTREGAR.CVE_REG 
                    LEFT JOIN dbo.GCOPERADOR O ON V.CVE_OPER = O.CLAVE 
                    WHERE V.CVE_ST_VIA = '5' AND LP.STATUS = 'A' AND " & CADENA & CADENA_OPER & "
                    ORDER BY " & CADENA_ORDER
            End If


            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        TON1 = 0 : TON2 = 0 : CVE_ART = "" : DESCR = ""
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_ART, ISNULL(PESO_BRUTO2,0) AS B2, ISNULL(TARA2,0) AS T2, ISNULL(DESCR,'') AS DES
                                        FROM GCCARTA_PORTE P 
                                        LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                                        WHERE CVE_FOLIO = '" & dr("PORTE1") & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        TON1 = dr2("B2") - dr2("T2")
                                        CVE_ART = dr2("CVE_ART")
                                        DESCR = dr2("DES")
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            If dr("PORTE1").ToString.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT CVE_MAT, ISNULL(PESO_BRUTO2,0) AS B2, ISNULL(TARA2,0) AS T2
                                            FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & dr("PORTE2") & "'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            TON2 = dr2("B2") - dr2("T2")
                                        End If
                                    End Using
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        KM = dr("KM_REC")
                        Try
                            If KM = 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT ISNULL(KM,0) AS KM_R
                                         FROM GCRUTAS_FRAJA WHERE ORIGEN = '" & dr("ORIGEN") & "' AND DESTINO = '" & dr("DESTINO") & "'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            KM = dr2("KM_R")

                                            If KM > 0 Then
                                                Try
                                                    SQL = "UPDATE GCASIGNACION_VIAJE SET KM_RECORRIDOS = " & KM & " WHERE CVE_VIAJE = '" & dr("CVE_VIAJE") & "'"
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQL
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                                Try
                                                    SQL = "UPDATE GCCARTA_PORTE SET KM_RECORRIDOS = " & KM & " 
                                                    WHERE CVE_FOLIO = '" & dr("PORTE1") & "' OR CVE_FOLIO = '" & dr("PORTE2") & "'"
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQL
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End If

                                        Else
                                            SQL = "IF NOT EXISTS (SELECT KM FROM GCRUTAS_FRAJA WHERE ORIGEN = '" & dr("ORIGEN") & "' AND 
                                                DESTINO = '" & dr("DESTINO") & "')
                                                INSERT INTO GCRUTAS_FRAJA (ORIGEN, DESTINO, KM) VALUES ('" & dr("ORIGEN") & "', '" &
                                                dr("DESTINO") & "'," & KM & ")"
                                            Try
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End Using
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        r = t.NewRow()
                        r("CVE_TRACTOR") = dr("CVE_TRACTOR")
                        r("CVE_TANQUE1") = dr("CVE_TANQUE1")
                        r("CVE_TANQUE2") = dr("CVE_TANQUE2")
                        r("CARTA_PORTE1") = dr("PORTE1")
                        r("CARTA_PORTE2") = dr("PORTE2")
                        r("FECHA_CARGA") = dr("FECHA_CARGA")
                        r("FECHA_DESCARGA") = dr("FECHA_DESCARGA")
                        r("NOMBRE_OPER") = dr("OPERADOR")
                        r("ORIGEN") = dr("ORIGEN")
                        r("DESTINO") = dr("DESTINO")
                        r("KM_RECORRIDO") = KM
                        r("TON_TANQUE1") = TON1
                        r("TON_TANQUE2") = TON2
                        r("PRODUCTO") = DESCR
                        r("PORFECHA") = PORFECHA
                        r("FEC1") = FEC1
                        r("FEC2") = FEC2
                        r("FECHA_DOC") = dr("FECHA_DOC")
                        r("SUELDO") = dr("SUELDO_OP")

                        t.Rows.Add(r)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim RUTA_FORMATOS As String = ""
            BarImprimir.Enabled = False

            If RadNormal.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesLiquidados.mrt"
            ElseIf RadAgrupadoXOper.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesLiqAgrupaOper.mrt"
            ElseIf RadAgrupadoXUnidad.Checked Or RadCargaCartaPorte.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesLiqAgrupaUnidad.mrt"
            End If

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.RegData(DataSet1)

            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte.Render()

            If PASS_GRUPOCE = "BUS" Then
                Reporte.Design()
            Else
                'Reporte.Show()
                VisualizaReporte(Reporte)
            End If

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()

    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                L2.Text = Var5

                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                L2.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    L2.Text = ""
                End If
            Else
                L2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
