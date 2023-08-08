Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Themes
Public Class FrmReporteViajesRealizados
    Private Sub FrmReporteViajesRealizados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BtnArt1.FlatStyle = FlatStyle.Flat
            BtnArt1.FlatAppearance.BorderSize = 0
            BTnCliente1.FlatStyle = FlatStyle.Flat
            BTnCliente1.FlatAppearance.BorderSize = 0
            BTnCliente2.FlatStyle = FlatStyle.Flat
            BTnCliente2.FlatAppearance.BorderSize = 0

            Me.CenterToScreen()

            ToolStrip1.BackColor = Color.FromArgb(207, 221, 238)

            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then BtnDisenador1.Visible = True
            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then BtnDisenador2.Visible = True
            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then BtnDisenador3.Visible = True
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
        Catch ex As Exception
        End Try
        Try
            F2.Value = d2
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmReporteViajesRealizados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click

        If RadAgrupadoXUnidad.Checked Then
            REPORTAGRUPADOXUNIDAD
        Else
            REPORT_NORMAL_CLIENTE
        End If
    End Sub
    Sub REPORTAGRUPADOXUNIDAD()
        Try
            Dim RUTA_FORMATOS As String = ""
            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesRealizadosXUnidad.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.ReportName = Me.Text
            StiReport1("FSQL1") = FSQL(F1.Value)
            StiReport1("FSQL2") = FSQL(F2.Value)
            StiReport1.Render()

            'If PASS_GRUPOCE = "BUS" Then
            'StiReport1.Design()
            'Else
            StiReport1.Show()
            'End If

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True
    End Sub
    Sub REPORT_NORMAL_CLIENTE()
        Dim CADENA As String, CADENA_OPER As String = "", CADENA_CVE_ART As String = "", CADENA_ORDER As String
        Dim TON1 As Decimal, TON2 As Decimal, CADENA_CLIENTE As String
        Dim CVE_ART As String, DESCR As String, FEC1 As Date, FEC2 As Date, PORFECHA As String, KM As Decimal = 0
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow
        DataSet1.Clear()

        Try
            CADENA = "V.FECHA_CARGA >= '" & FSQL(F1.Value) & "' AND V.FECHA_CARGA <= '" & FSQL(F2.Value) & "'"
            PORFECHA = "Por fecha de viaje"

            If TCLIENTE1.Text.Trim.Length > 0 And TCLIENTE2.Text.Trim.Length > 0 Then
                CADENA_CLIENTE = " AND CP.CLIENTE >= '" & TCLIENTE1.Text & "' AND CP.CLIENTE <= '" & TCLIENTE2.Text & "' "

            ElseIf TCLIENTE1.Text.Trim.Length > 0 And TCLIENTE2.Text.Trim.Length = 0 Then
                CADENA_CLIENTE = " AND CP.CLIENTE >= '" & TCLIENTE1.Text & "'"
            ElseIf TCLIENTE1.Text.Trim.Length = 0 And TCLIENTE2.Text.Trim.Length > 0 Then
                CADENA_CLIENTE = " AND CP.CLIENTE <= '" & TCLIENTE2.Text & "'"
            Else
                CADENA_CLIENTE = ""
            End If
            If TCVE_ART1.Text.Trim.Length > 0 And TCVE_ART2.Text.Trim.Length > 0 Then
                CADENA_CVE_ART = " AND CP.CVE_ART >= '" & TCVE_ART1.Text & "' AND CP.CVE_ART <= '" & TCVE_ART2.Text & "'"
            ElseIf TCVE_ART1.Text.Trim.Length > 0 And TCVE_ART2.Text.Trim.Length = 0 Then
                CADENA_CVE_ART = " AND CP.CVE_ART >= '" & TCVE_ART1.Text & "'"
            ElseIf TCVE_ART1.Text.Trim.Length = 0 And TCVE_ART2.Text.Trim.Length > 0 Then
                CADENA_CVE_ART = " AND CP.CVE_ART <= '" & TCVE_ART2.Text & "'"
            Else

            End If

            CADENA_ORDER = "V.FECHA, CP.CLIENTE"

            FEC1 = F1.Value
            FEC2 = F2.Value

            SQL = "SELECT V.CVE_VIAJE, V.CVE_DOC, V.FECHA, V.CVE_ST_VIA, V.CVE_TRACTOR, V.CVE_TANQUE1, V.CVE_TANQUE2, 
                ISNULL(F.DOCUMENT,'') AS PORTE1, ISNULL(F.DOCUMENT2,'') AS PORTE2, ISNULL(RECOGER.DESCR,'') AS ORIGEN, 
                ISNULL(ENTREGAR.DESCR,'') AS DESTINO, O.NOMBRE AS NOMBRE_OPER, V.FECHA_CARGA, V.FECHA_DESCARGA, 
                ISNULL(V.KM_RECORRIDOS,0) AS KM_REC, F.FECHAELAB, CP.CLIENTE, ISNULL(R1.KMS,0) AS KMS_RUTAS, 
                C.NOMBRE AS NOMBRE_CLIE, F.FACTURA, ISNULL(V.TIPO_UNI,0) AS TIP_UNI
                FROM GCASIGNACION_VIAJE V
                LEFT JOIN CFDI F ON F.DOCUMENT = V.CVE_CAP1 OR F.DOCUMENT2 = V.CVE_CAP1
                LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = F.DOCUMENT
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = CP.CLIENTE
                LEFT JOIN GCTAB_RUTAS_F R1 ON R1.CVE_CON = V.CVE_CON
                LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN RECOGER ON V.RECOGER_EN = RECOGER.CVE_REG 
                LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN ENTREGAR ON V.ENTREGAR_EN = ENTREGAR.CVE_REG 
                LEFT JOIN dbo.GCOPERADOR O ON V.CVE_OPER = O.CLAVE 
                WHERE V.CVE_ST_VIA  <> 7 AND  ISNULL(F.DOCUMENT,'') <> '' AND ISNULL(F.ESTATUS,'') <> 'C' AND
                V.FECHA BETWEEN '" & FSQL(F1.Value) & "' AND '" & FSQL(F2.Value) & "' AND V.CVE_CAP1 <> ''
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

                        If dr("CVE_VIAJE").ToString.IndexOf("6464") > -1 Then
                            Debug.Print("")
                        End If
                        If dr("KMS_RUTAS") > 0 Then
                            KM = dr("KMS_RUTAS")
                        End If
                        'Viajes realizados, cliente, fecha, material, tonelaje y kilometraje fecha carga y descarga
                        r = t.NewRow()
                        r("CVE_VIAJE") = dr("CVE_VIAJE")
                        r("FACTURA") = dr("FACTURA")
                        r("CLIENTE") = dr("CLIENTE")
                        r("NOMBRE_CLIE") = dr("NOMBRE_CLIE")
                        r("CVE_TRACTOR") = dr("CVE_TRACTOR")
                        r("CVE_TANQUE1") = dr("CVE_TANQUE1")
                        r("CVE_TANQUE2") = dr("CVE_TANQUE2")
                        r("CARTA_PORTE1") = dr("PORTE1")
                        r("CARTA_PORTE2") = dr("PORTE2")
                        r("FECHA_VIAJE") = dr("FECHA")
                        r("FECHA_CARGA") = dr("FECHA_CARGA")
                        r("FECHA_DESCARGA") = dr("FECHA_DESCARGA")
                        r("NOMBRE_OPER") = dr("NOMBRE_OPER")
                        r("ORIGEN") = dr("ORIGEN")
                        r("DESTINO") = dr("DESTINO")
                        r("KM_RECORRIDO") = KM
                        r("TON_TANQUE1") = TON1
                        r("TON_TANQUE2") = TON2
                        r("TONELADAS") = TON1 + TON2
                        r("PRODUCTO") = DESCR
                        r("PORFECHA") = PORFECHA
                        r("FEC1") = FEC1
                        r("FEC2") = FEC2
                        r("FECHA_DOC") = dr("FECHAELAB")
                        r("KMS_RUTAS") = dr("KMS_RUTAS")
                        r("TIPO_UNI") = IIf(dr("TIP_UNI") = 1, "Full", "Sencillo")

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
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesRealizados.mrt"
            ElseIf RadAgrupadoXCliente.Checked Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportViajesRealizadosCliente.mrt"
            End If
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)
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
    Private Sub BtnDisenador1_Click(sender As Object, e As EventArgs) Handles BtnDisenador1.Click
        PrinterMRT("ReportViajesRealizados")
    End Sub
    Private Sub BtnDisenador2_Click(sender As Object, e As EventArgs) Handles BtnDisenador2.Click
        PrinterMRT("ReportViajesRealizadosCliente")
    End Sub
    Private Sub BtnDisenador3_Click(sender As Object, e As EventArgs) Handles BtnDisenador3.Click
        PrinterMRT("ReportViajesRealizadosXUnidad")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BTnCliente1_Click(sender As Object, e As EventArgs) Handles BTnCliente1.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE1.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART1.Select()
            Else
                TCLIENTE1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BTnCliente1_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCLIENTE2.Focus()
        End If
    End Sub

    Private Sub TCLIENTE1_Validated(sender As Object, e As EventArgs) Handles TCLIENTE1.Validated
        Try
            If TCLIENTE1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE1.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE1.Text.Trim.Length) & TCLIENTE1.Text.Trim
                    TCLIENTE1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE1.Text)
                If DESCR <> "" Then

                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE1.Text = ""
                    TCLIENTE1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BTnCliente2_Click(sender As Object, e As EventArgs) Handles BTnCliente2.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE2.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART1.Select()
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BTnCliente1_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCVE_ART1.Focus()
        End If
    End Sub

    Private Sub TCLIENTE2_Validated(sender As Object, e As EventArgs) Handles TCLIENTE2.Validated
        Try
            If TCLIENTE2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE2.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE2.Text.Trim.Length) & TCLIENTE2.Text.Trim
                    TCLIENTE2.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE2.Text)
                If DESCR <> "" Then

                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE2.Text = ""
                    TCVE_ART1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnArt1_Click(sender As Object, e As EventArgs) Handles BtnArt1.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_ART2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnART1_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCVE_ART2.Focus()
        End If
    End Sub

    Private Sub TCVE_ART1_Validated(sender As Object, e As EventArgs) Handles TCVE_ART1.Validated
        Try
            If TCVE_ART1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART1.Text, False)
                If DESCR <> "" Then

                Else
                    MsgBox("Articulo inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnArt2_Click(sender As Object, e As EventArgs) Handles BtnArt2.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART2_Validated(sender As Object, e As EventArgs) Handles TCVE_ART2.Validated
        Try
            If TCVE_ART2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART2.Text, False)
                If DESCR <> "" Then

                Else
                    MsgBox("Articulo inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class