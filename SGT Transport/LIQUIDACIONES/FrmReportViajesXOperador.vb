Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Themes
Public Class FrmReportViajesXOperador
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmReportViajesXOperador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub FrmReportViajesXOperador_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Dim CADENA As String = "", CADENA_OPER As String = "", CADENA_CVE_ART As String = "", CADENA_ORDER As String = ""
        Dim TON1 As Decimal = 0, TON2 As Decimal = 0, CADENA_CLIENTE As String = ""
        Dim CVE_ART As String = "", DESCR As String = "", FEC1 As Date, FEC2 As Date, PORFECHA As String = "", KM As Decimal = 0
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow
        DataSet1.Clear()

        Try
            CADENA = "V.FECHA >= '" & FSQL(F1.Value) & "' AND V.FECHA <= '" & FSQL(F2.Value) & "'"
            PORFECHA = "Por fecha de viaje"

            If TCVE_OPER.Text.Trim.Length > 0 Then CADENA_OPER = " AND V.CVE_OPER = '" & TCVE_OPER.Text & "'"
            If TCLIENTE.Text.Trim.Length > 0 Then CADENA_CLIENTE = " AND CP.CLIENTE = '" & TCLIENTE.Text & "'"
            If TCVE_ART.Text.Trim.Length > 0 Then CADENA_CVE_ART = " AND CP.CVE_ART = '" & TCVE_ART.Text & "'"

            CADENA_ORDER = "V.FECHA, V.CVE_OPER"

            FEC1 = F1.Value
            FEC2 = F2.Value

            SQL = "SELECT V.CVE_VIAJE, V.CVE_DOC, V.FECHA, V.CVE_ST_VIA, V.CVE_TRACTOR, V.CVE_TANQUE1, V.CVE_TANQUE2, 
                ISNULL(F.DOCUMENT,'') AS PORTE1, ISNULL(F.DOCUMENT2,'') AS PORTE2, ISNULL(RECOGER.DESCR,'') AS ORIGEN, 
                ISNULL(ENTREGAR.DESCR,'') AS DESTINO, O.NOMBRE AS OPERADOR, V.FECHA_CARGA, V.FECHA_DESCARGA, 
                ISNULL(V.KM_RECORRIDOS,0) AS KM_REC, F.FECHAELAB, CP.CLIENTE, ISNULL(LP.SUELDO,0) AS SUELDO_OP,
                R1.KMS AS KMS_RUTAS
                FROM CFDI F
                LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = F.DOCUMENT
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = CP.CLIENTE
                LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_CAP1 = F.DOCUMENT
                LEFT JOIN GCTAB_RUTAS_F R1 ON R1.CVE_CON = V.CVE_CON
                LEFT JOIN GCLIQ_PARTIDAS LP ON LP.CVE_VIAJE = V.CVE_VIAJE 
                LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN RECOGER ON V.RECOGER_EN = RECOGER.CVE_REG 
                LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN ENTREGAR ON V.ENTREGAR_EN = ENTREGAR.CVE_REG 
                LEFT JOIN dbo.GCOPERADOR O ON V.CVE_OPER = O.CLAVE 
                WHERE ISNULL(F.ESTATUS,'') <> 'C' AND V.CVE_ST_VIA = '5' AND ISNULL(F.DOCUMENT,'') <> '' AND ISNULL(F.TIMBRADO,'') = 'S' AND 
                F.FECHAELAB BETWEEN '" & FSQL(F1.Value) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59'
                " & CADENA_OPER & CADENA_CLIENTE & CADENA_CVE_ART & " ORDER BY " & CADENA_ORDER
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TON1 = 0 : TON2 = 0 : CVE_ART = "" : DESCR = ""
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_ART, ISNULL(PESO_BRUTO1,0) AS B1, ISNULL(TARA1,0) AS T1, ISNULL(DESCR,'') AS DES,
                                      ISNULL(KM_RECORRIDOS,0) AS KM  
                                      FROM GCCARTA_PORTE P 
                                      LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                                      WHERE CVE_FOLIO = '" & dr("PORTE1") & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        TON1 = dr2("B1")
                                        CVE_ART = dr2("CVE_ART")
                                        DESCR = dr2("DES")
                                        KM = dr2("KM")
                                    End If
                                End Using
                            End Using
                            If dr("PORTE1").ToString.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT CVE_MAT, ISNULL(PESO_BRUTO1,0) AS B1, ISNULL(TARA1,0) AS T1
                                         FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & dr("PORTE2") & "'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            TON2 = dr2("B1")
                                        End If
                                    End Using
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        r = t.NewRow()
                        r("CVE_VIAJE") = dr("CVE_VIAJE")
                        r("SUELDO") = dr("SUELDO_OP")
                        r("CLIENTE") = dr("CLIENTE")
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
                        r("FECHA_DOC") = dr("FECHAELAB")
                        r("KMS_RUTAS") = dr("KMS_RUTAS")
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
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesPorOperador.mrt"
            ElseIf RadAgrupadoXOper.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesXOperAgrupado.mrt"
            ElseIf RadAgrupadoXUnidad.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesPorOperAgrupaUnidad.mrt"
            End If

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor


            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.ReportName = Me.Text
            StiReport1.Render()

            If PASS_GRUPOCE = "BUS" Then
                StiReport1.Design()
            Else
                StiReport1.Show()
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
                TCVE_OPER.Focus()
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
        If e.KeyCode = Keys.Enter Then
            TCVE_ART.Focus()
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
    Private Sub BtnCVE_ART_Click(sender As Object, e As EventArgs) Handles BtnCVE_ART.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtDescr.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCLIENTE.Focus()
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCVE_ART_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCLIENTE.Focus()
        End If
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text, False)
                If DESCR <> "" Then
                    LtDescr.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTnCliente_Click(sender As Object, e As EventArgs) Handles BTnCliente.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Select()
            Else
                TCLIENTE.Text = ""
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BTnCliente_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCVE_OPER.Focus()
        End If
    End Sub

    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                    TCLIENTE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    TCLIENTE.Select()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_OPER.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            TCVE_ART.Focus()
        End If
    End Sub

    Private Sub TCVE_ART_TextChanged(sender As Object, e As EventArgs) Handles TCVE_ART.TextChanged
        If TCVE_ART.Text = String.Empty Then
            LtDescr.Text = ""
        End If
    End Sub

    Private Sub TCLIENTE_TextChanged(sender As Object, e As EventArgs) Handles TCLIENTE.TextChanged
        If TCLIENTE.Text = String.Empty Then
            LtNombre.Text = ""
        End If
    End Sub

    Private Sub TCVE_OPER_TextChanged(sender As Object, e As EventArgs) Handles TCVE_OPER.TextChanged
        If TCVE_OPER.Text = String.Empty Then
            L2.Text = ""
        End If
    End Sub
End Class
