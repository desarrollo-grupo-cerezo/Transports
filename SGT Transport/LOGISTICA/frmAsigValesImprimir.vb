Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Input
Imports Stimulsoft.Report
Imports C1.Win.C1Themes
Imports Stimulsoft.Base.Design


Public Class frmAsigValesImprimir
    Private Sub frmAsigValesImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
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

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Clave", GetType(System.String))
            dt.Columns.Add("Descripcion", GetType(System.String))
            'dt.Columns.Add("BANCO", GetType(System.String))

            dt.Rows.Add(0, "TODOS")

            cboStatus.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, STATUS, DESCR FROM GCCAT_STATUS_VIAJE WHERE STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CLAVE"), dr("DESCR"))
                    End While
                End Using
            End Using

            cboStatus.TextDetached = True
            cboStatus.ItemsDataSource = dt.DefaultView
            cboStatus.ItemsDisplayMember = "Descripcion"
            cboStatus.ItemsValueMember = "Clave"
            cboStatus.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            cboStatus.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"
            'cboStatus.HtmlPattern = "<table><tr><td width=30>{NUM.}</td><td width=150>{CUENTA}</td><td width=170>{BANCO}</td><td width=220></tr></table>"

            'F1.Value = "23/04/2021"
            'F2.Value = "27/04/2021"
            'tCVE_VIAJE.Text = "00000010"
            'tCVE_VIAJE2.Text = "00000011"
            cboStatus.SelectedIndex = 0


            cboStGastos.Items.Clear()
            cboStGastos.Items.Add("TODOS")
            cboStGastos.Items.Add("EDICION")
            cboStGastos.Items.Add("ACEPTADO")

            cboStGastos.SelectedIndex = 0

            AssignValidation(Me.tCVE_GAS, ValidationType.Only_Numbers)
            AssignValidation(Me.tCVE_GAS2, ValidationType.Only_Numbers)

            AssignValidation(Me.TCVE_OPER1, ValidationType.Only_Numbers)
            AssignValidation(Me.TCVE_OPER2, ValidationType.Only_Numbers)

        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAsigValesImprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r As DataRow

        DataSet1.Clear()

        Try
            Dim RUTA_FORMATOS As String = "", CVE_STATUS As Integer, CVE_STATUS2 As Integer, CVE_ST As String, ST_GASTOS As String, ST_GASTOS2 As String, CVE_VIAJE2 As String
            Dim VAR_ST_GASTOS As String, CVE_GAS1 As Integer, CVE_GAS2 As Integer, PDF As String
            Dim CVE_OPER1 As Integer, CVE_OPER2 As Integer

            Try
                If tCVE_GAS.Text.Trim.Length = 0 And tCVE_GAS2.Text.Trim.Length = 0 Then
                    CVE_GAS1 = 0
                    CVE_GAS2 = 9999
                Else
                    If CInt(tCVE_GAS.Text.Trim) >= 0 And tCVE_GAS2.Text.Trim.Length >= 0 Then
                        CVE_GAS1 = tCVE_GAS.Text
                        CVE_GAS2 = tCVE_GAS2.Text
                    Else
                        If CInt(tCVE_GAS.Text.Trim) >= 0 And tCVE_GAS2.Text.Trim.Length = 0 Then
                            CVE_GAS1 = tCVE_GAS.Text
                            CVE_GAS2 = 9999
                        Else
                            CVE_GAS1 = 0
                            CVE_GAS2 = tCVE_GAS2.Text

                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If tCVE_VIAJE2.Text.Trim.Length = 0 Then
                CVE_VIAJE2 = "ZZZZZZZZ"
            Else
                CVE_VIAJE2 = tCVE_VIAJE2.Text
            End If

            CVE_STATUS = CInt(cboStatus.Items(cboStatus.SelectedIndex))

            If cboStatus.SelectedIndex = 0 Then
                CVE_STATUS = 0
                CVE_STATUS2 = 9999
            Else
                CVE_STATUS = CInt(cboStatus.Items(cboStatus.SelectedIndex))
                CVE_STATUS2 = CVE_STATUS
            End If

            CVE_ST = cboStatus.Text

            If cboStGastos.SelectedIndex = 0 Then
                ST_GASTOS = " "
                ST_GASTOS2 = "ZZZZZZZZ"
            Else
                ST_GASTOS = cboStGastos.Items(cboStGastos.SelectedIndex)
                ST_GASTOS2 = ST_GASTOS
            End If
            VAR_ST_GASTOS = cboStGastos.Text

            Try
                If TCVE_OPER1.Text.Trim.Length = 0 And TCVE_OPER2.Text.Trim.Length = 0 Then
                    CVE_OPER1 = 0
                    CVE_OPER2 = 9999
                Else
                    If CInt(TCVE_OPER1.Text.Trim) >= 0 And TCVE_OPER2.Text.Trim.Length >= 0 Then
                        CVE_OPER1 = TCVE_OPER1.Text
                        CVE_OPER2 = TCVE_OPER2.Text
                    Else
                        If CInt(TCVE_OPER1.Text.Trim) >= 0 And TCVE_OPER2.Text.Trim.Length = 0 Then
                            CVE_OPER1 = TCVE_OPER1.Text
                            CVE_OPER2 = 9999
                        Else
                            CVE_OPER1 = 0
                            CVE_OPER2 = TCVE_OPER2.Text

                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportValesDeViajeG.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Dim FECHA As Date, FDB As String

            SQL = "SELECT A.CVE_DOC, A.FECHA AS FECHA_VIAJE, V.FECHA_TRASPASO, O.NOMBRE, A.CVE_OPER, A.CVE_VIAJE, V.FOLIO, 
                    V.FECHA AS FECHA_VALE, V.CVE_GAS, V.LITROS,  V.LITROS_REALES,  V.P_X_LITRO, V.SUBTOTAL, V.IVA, V.IEPS, V.IMPORTE, 
                    V.FACTURA, V.ST_VALES, G.DESCR, A.CVE_TRACTOR
                    FROM dbo.GCASIGNACION_VIAJE A
                    LEFT JOIN dbo.GCOPERADOR O ON A.CVE_OPER = O.CLAVE 
                    LEFT JOIN dbo.GCASIGNACION_VIAJE_VALES V ON A.CVE_VIAJE = V.CVE_VIAJE 
                    LEFT JOIN dbo.GCGASOLINERAS G ON V.CVE_GAS = G.CVE_GAS
                    WHERE 
                    A.CVE_VIAJE >= '" & tCVE_VIAJE.Text & "' AND A.CVE_VIAJE <= '" & CVE_VIAJE2 & "' AND 
                    ((V.FECHA >= '" & FSQL(F1.Value) & "' AND V.FECHA <= '" & FSQL(F2.Value) & "' AND V.FECHA_TRASPASO IS NULL) OR 
                    (V.FECHA_TRASPASO >= '" & FSQL(F1.Value) & "' AND V.FECHA_TRASPASO <= '" & FSQL(F2.Value) & "')) AND 
                    A.CVE_ST_VIA >= " & CVE_STATUS & " And A.CVE_ST_VIA <= " & CVE_STATUS2 & " And
                    V.ST_VALES >= '" & ST_GASTOS & "' AND  V.ST_VALES <= '" & ST_GASTOS2 & "' AND
                    A.STATUS <> 'C' AND  V.STATUS <> 'C' AND 
                    TRY_PARSE(V.CVE_GAS As INT) >= " & CVE_GAS1 & " And TRY_PARSE(V.CVE_GAS As INT) <= " & CVE_GAS2 & " AND 
                    V.CVE_OPER >= " & CVE_OPER1 & " And V.CVE_OPER <= " & CVE_OPER2 & " 
                    ORDER BY FOLIO DESC"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            r = t.NewRow()
                            r("CVE_DOC") = dr("CVE_DOC")
                            r("FECHA_VIAJE") = dr("FECHA_VIAJE")
                            If IsDBNull(dr("FECHA_TRASPASO")) Then
                                r("FECHA_TRASPASO") = ""
                            Else
                                FECHA = dr("FECHA_TRASPASO")
                                FDB = FECHA.ToString("dd/MM/yyyy")
                                r("FECHA_TRASPASO") = FDB
                            End If
                            r("NOMBRE_OPER") = dr("NOMBRE")
                            r("CVE_OPER") = dr("CVE_OPER")
                            r("CVE_VIAJE") = dr("CVE_VIAJE")
                            r("FOLIO") = dr("FOLIO")
                            r("FECHA_VALE") = dr("FECHA_VALE")
                            r("CVE_GAS") = dr("CVE_GAS")
                            r("LITROS") = dr("LITROS")
                            r("LITROS_REALES") = dr("LITROS_REALES")
                            r("P_X_LITRO") = dr("P_X_LITRO")
                            r("SUBTOTAL") = dr("SUBTOTAL")
                            r("IVA") = dr("IVA")
                            r("IEPS") = dr("IEPS")
                            r("IMPORTE") = dr("IMPORTE")
                            r("FACTURA") = dr("FACTURA")
                            r("ST_VALES") = dr("ST_VALES")
                            r("DESCR") = dr("DESCR")
                            r("CVE_TRACTOR") = dr("CVE_TRACTOR")
                            r("F1") = F1.Value
                            r("F2") = F2.Value
                            r("CVE_VIAJE1") = tCVE_VIAJE.Text
                            r("CVE_VIAJE2") = CVE_VIAJE2

                            r("CVE_STATUS1") = CVE_ST
                            r("ST_GASTOS1") = VAR_ST_GASTOS
                            r("CVE_GAS1") = CVE_GAS1
                            r("CVE_GAS2") = CVE_GAS2
                            r("CVE_OPER1") = CVE_OPER1
                            r("CVE_OPER2") = CVE_OPER2
                            t.Rows.Add(r)
                        End While
                    End Using
                End Using
            Catch ex As SqlException
                Dim errSQL As String = ""
                For i As Integer = 0 To ex.Errors.Count - 1
                    errSQL = ("Index #" & i & vbLf & "Message: " & ex.Errors(i).Message & vbLf & "
							        LineNumber: " & ex.Errors(i).LineNumber.ToString & vbLf & "Source: " + ex.Errors(i).Source & vbLf & "
							        Procedure: " & ex.Errors(i).Procedure & vbLf)
                Next
                Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & errSQL)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Dim Reporte As New StiReport

            Reporte.Load(RUTA_FORMATOS)

            'Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
            'Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            ''Reporte.Dictionary.Databases.Clear()
            'Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            Reporte.RegData(DataSet1)
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte.Render()
            'Reporte.Show()

            VisualizaReporte(Reporte)

            If chEnviaXCorreo.Checked Then
                Try

                    PDF = GET_RUTA_FORMATOS() & "\ReportValesDeViajeG.pdf"

                    Dim aCorreo As New ArrayList From {PDF}

                    Reporte.ExportDocument(StiExportFormat.Pdf, PDF)
                    SendEmail(tCORREO.Text, "Reporte vale de combustible", "Buen dia " & vbNewLine &
                                 "Adjunto se envia el reporte de vale de combustible" & vbNewLine & "Gracias", aCorreo)

                Catch ex As Exception
                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'Reporte.Item("CVE_VIAJE") = tCVE_VIAJE.Text
            'Reporte.Item("CVE_VIAJE2") = CVE_VIAJE2
            ''Reporte.Item("FECHA1") = F1.Value
            'Reporte.Item("FECHA2") = F2.Value
            'Reporte.Item("FECHA_TRANS1") = F1.Value
            'Reporte.Item("FECHA_TRANS2") = F2.Value
            'Reporte.Item("CVE_ESTATUS") = CVE_STATUS
            'Reporte.Item("CVE_ESTATUS2") = CVE_STATUS2
            'Reporte.Item("ST_GASTOS") = ST_GASTOS
            'Reporte.Item("ST_GASTOS2") = ST_GASTOS2

            'Reporte.Item("CVE_GAS1") = CVE_GAS1
            'Reporte.Item("CVE_GAS2") = CVE_GAS2

            'Reporte("CVE_VIAJE_V1") = tCVE_VIAJE.Text
            'Reporte("CVE_VIAJE_V2") = tCVE_VIAJE2.Text
            'Reporte("F1") = F1.Value.ToString.Substring(0, 10)
            'Reporte("F2") = F2.Value.ToString.Substring(0, 10)
            'Reporte("CVE_ST") = CVE_ST
            'Reporte("VAR_ST_GASTOS") = VAR_ST_GASTOS
            'Reporte("VAR_GAS1") = tCVE_GAS.Text
            'Reporte("VAR_GAS2") = tCVE_GAS2.Text
            '
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNoViaje_Click(sender As Object, e As EventArgs) Handles btnNoViaje.Click
        Try
            Var2 = "Asignacion viajes todos"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_VIAJE.Text = Var4
                'DESPLEGAR_ASIGNACION_VIAJE(tCVE_VIAJE.Text)
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNoViaje2_Click(sender As Object, e As EventArgs) Handles btnNoViaje2.Click
        Try
            Var2 = "Asignacion viajes todos"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_VIAJE2.Text = Var4
                DESPLEGAR_ASIGNACION_VIAJE(tCVE_VIAJE2.Text)
                Var2 = "" : Var4 = "" : Var5 = ""
                cboStatus.Select()
            End If
        Catch ex As Exception
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_VIAJE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnNoViaje_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                tCVE_VIAJE.Select()
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_VIAJE_Validated(sender As Object, e As EventArgs) Handles tCVE_VIAJE.Validated
        Try
            If tCVE_VIAJE.Text.Trim.Length > 0 Then
                If tCVE_VIAJE.Text <> tCVE_VIAJE.Tag Then
                    tCVE_VIAJE.Tag = tCVE_VIAJE.Text

                    DESPLEGAR_ASIGNACION_VIAJE(tCVE_VIAJE.Text)
                End If
            End If
        Catch ex As Exception
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_VIAJE2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_VIAJE2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnNoViaje2_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                cboStatus.Select()
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_VIAJE2_Validated(sender As Object, e As EventArgs) Handles tCVE_VIAJE2.Validated

    End Sub
    Sub DESPLEGAR_ASIGNACION_VIAJE(fCVE_VIAJE As String)
        If fCVE_VIAJE.Trim.Length = 0 Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, ISNULL(A.CVE_ST_UNI,0) AS STATUS_INI, A.TIPO_UNI, " &
                "A.TIPO_VIAJE, A.CVE_OPER, A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA, " &
                "ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(C.RECOGER_EN,'') AS RECOGER2, ISNULL(C.ENTREGAR_EN,'') AS ENTREGAR2, " &
                "ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, ISNULL(A.CVE_TAB,0) AS CVETAB, A.RUTA_SEN_VAC, A.RUTA_SE_CAR, A.RUTA_FULL_VAC, " &
                "A.RUTAL_FULL_CAR, ISNULL(A.NOTA,'') AS NTA, ISNULL(P.FECHA_CARGA,'') AS F_CARGA, ISNULL(P.FECHA_DESCARGA,'') AS F_DESCARGA, " &
                "ISNULL(C.CVE_ART,'') AS CVEART, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR " &
                "FROM GCASIGNACION_VIAJE A " &
                "LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = A.CVE_VIAJE " &
                "LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON " &
                "WHERE A.CVE_VIAJE = '" & fCVE_VIAJE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                'LtCVE_DOC.Text = dr("CVE_DOC")  PEDIDO
            Else
                MsgBox("Asignacion de viaje inexistente")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub cboStatus_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles cboStatus.DropDownClosed
        Try
            If cboStatus.SelectedIndex > -1 Then
                Dim CVE_ST As String
                CVE_ST = cboStatus.Items(cboStatus.SelectedIndex)
                'LtStatus.Text = "Estatus:" & CVE_ST
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGas1_Click(sender As Object, e As EventArgs) Handles BtnGas1.Click
        Try
            Var2 = "Gasolinera"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_GAS.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGas1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_GAS_Validated(sender As Object, e As EventArgs) Handles tCVE_GAS.Validated
        Try
            Dim DESCR As String
            If tCVE_GAS.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", tCVE_GAS.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    'If tCVE_GAS.Text < tCVE_GAS2.Text Then
                    'MsgBox("La clave no puede ser meyor a la clave segunda clave de la gasolinera")
                    'tCVE_GAS.Text = ""
                    'tCVE_GAS.Select()
                    'End If
                Else
                    MsgBox("Gasolinera inexistente")
                    tCVE_GAS.Text = ""
                End If
            Else
                tCVE_GAS.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGas2_Click(sender As Object, e As EventArgs) Handles BtnGas2.Click
        Try
            Var2 = "Gasolinera"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'If Var4 < tCVE_GAS.Text Then
                'MsgBox("La clave no puede ser menor a la clave primera clave de la gasolinera")
                'Else
                tCVE_GAS2.Text = Var4
                'End If
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_GAS2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GAS2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGas2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_GAS2_Validated(sender As Object, e As EventArgs) Handles tCVE_GAS2.Validated
        Try
            Dim DESCR As String
            If tCVE_GAS2.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", tCVE_GAS2.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    'If tCVE_GAS2.Text < tCVE_GAS.Text Then
                    'MsgBox("La clave no puede ser menor a la clave primera clave de la gasolinera")
                    'tCVE_GAS2.Text = ""
                    'tCVE_GAS2.Select()
                    'End If
                Else
                    MsgBox("Gasolinera inexistente")
                    tCVE_GAS2.Text = ""
                End If
            Else
                tCVE_GAS.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub cboStGastos_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles cboStGastos.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                F2.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnOper1_Click(sender As Object, e As EventArgs) Handles BtnOper1.Click
        Try
            Var2 = "Operador" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER1.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER2.Focus()
            End If
        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_OPER1_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER1.Validated
        Try
            If TCVE_OPER1.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER1.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", TCVE_OPER1.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Operador inexistente")
                    TCVE_OPER1.Text = ""
                    TCVE_OPER1.Select()
                End If
            Else
                TCVE_OPER1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnOper2_Click(sender As Object, e As EventArgs) Handles BtnOper2.Click
        Try
            Var2 = "Operador" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER2.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                tCORREO.Focus()

            End If
        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER2_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER2.Validated
        Try
            If TCVE_OPER2.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER2.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", TCVE_OPER2.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Operador inexistente")
                    TCVE_OPER2.Text = ""
                    TCVE_OPER2.Select()
                End If
            Else
                TCVE_OPER2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
