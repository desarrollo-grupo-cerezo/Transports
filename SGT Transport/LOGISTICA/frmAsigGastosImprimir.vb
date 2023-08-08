Imports C1.Win.C1Themes
Imports Stimulsoft.Report
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class frmAsigGastosImprimir
    Private Sub frmAsigGastosImprimir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)


            BtnNoViaje.FlatStyle = FlatStyle.Flat
            BtnNoViaje.FlatAppearance.BorderSize = 0
            BtnNoViaje2.FlatStyle = FlatStyle.Flat
            BtnNoViaje2.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0

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
            cboStGastos.Items.Add("DEPOSITADO")
            cboStGastos.Items.Add("AUTORIZADO")

            cboStGastos.SelectedIndex = 0

        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmAsigGastosImprimir_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub btnNoViaje_Click(sender As Object, e As EventArgs) Handles BtnNoViaje.Click
        Try
            Var2 = "Asignacion viajes todos"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
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
    Private Sub btnNoViaje2_Click(sender As Object, e As EventArgs) Handles BtnNoViaje2.Click
        Try
            Var2 = "Asignacion viajes todos"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
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
    Sub DESPLEGAR_ASIGNACION_VIAJE(fCVE_VIAJE As String)
        If fCVE_VIAJE.Trim.Length = 0 Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE
            SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, ISNULL(A.CVE_ST_UNI,0) AS STATUS_INI, A.TIPO_UNI,
                A.TIPO_VIAJE, A.CVE_OPER, A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA,
                ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(C.RECOGER_EN,'') AS RECOGER2, 
                ISNULL(C.ENTREGAR_EN,'') AS ENTREGAR2, ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, ISNULL(A.CVE_TAB,0) AS CVETAB,
                A.RUTA_SEN_VAC, A.RUTA_SE_CAR, A.RUTA_FULL_VAC, A.RUTAL_FULL_CAR, ISNULL(A.NOTA,'') AS NTA, ISNULL(P.FECHA_CARGA,'') AS F_CARGA, 
                ISNULL(P.FECHA_DESCARGA,'') AS F_DESCARGA, ISNULL(C.CVE_ART,'') AS CVEART, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR
                FROM GCASIGNACION_VIAJE A
                LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = A.CVE_VIAJE
                LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON
                WHERE A.CVE_VIAJE = '" & fCVE_VIAJE & "'"
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

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Try
                Dim RUTA_FORMATOS As String, CVE_STATUS As Integer, CVE_STATUS2 As Integer, CVE_ST As String, ST_GASTOS As String, ST_GASTOS2 As String
                Dim CVE_VIAJE2 As String, VAR_ST_GASTOS As String, PDF As String, CVE_OPER1 As Integer = 0, CVE_OPER2 As Integer = 0


                If tCVE_OPER.Text.Trim.Length = 0 Then
                    CVE_OPER1 = 0
                    CVE_OPER2 = 30000
                Else
                    If IsNumeric(tCVE_OPER.Text.Trim) Then
                        CVE_OPER1 = tCVE_OPER.Text.Trim
                        CVE_OPER2 = tCVE_OPER.Text.Trim
                    Else
                        CVE_OPER1 = 0
                        CVE_OPER2 = 30000
                    End If
                End If

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
                    ST_GASTOS2 = "ZZZZZZZ"
                Else
                    ST_GASTOS = cboStGastos.Items(cboStGastos.SelectedIndex)
                    ST_GASTOS2 = ST_GASTOS
                End If
                VAR_ST_GASTOS = cboStGastos.Text

                BarImprimir.Enabled = False

                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportGastosDeViajeG.mrt"
                If Not File.Exists(RUTA_FORMATOS) Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                    Return
                End If
                FrmAsignacionViaje.StiReport1.Load(RUTA_FORMATOS)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                FrmAsignacionViaje.StiReport1.Dictionary.Databases.Clear()
                FrmAsignacionViaje.StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                FrmAsignacionViaje.StiReport1.Compile()
                FrmAsignacionViaje.StiReport1.ReportName = Me.Text

                FrmAsignacionViaje.StiReport1.Dictionary.Synchronize()

                FrmAsignacionViaje.StiReport1.Item("CVE_VIAJE") = tCVE_VIAJE.Text
                FrmAsignacionViaje.StiReport1.Item("CVE_VIAJE2") = CVE_VIAJE2
                FrmAsignacionViaje.StiReport1.Item("FECHA1") = F1.Value
                FrmAsignacionViaje.StiReport1.Item("FECHA2") = F2.Value
                FrmAsignacionViaje.StiReport1.Item("CVE_ESTATUS") = CVE_STATUS
                FrmAsignacionViaje.StiReport1.Item("CVE_ESTATUS2") = CVE_STATUS2
                FrmAsignacionViaje.StiReport1.Item("ST_GASTOS") = ST_GASTOS
                FrmAsignacionViaje.StiReport1.Item("ST_GASTOS2") = ST_GASTOS2
                FrmAsignacionViaje.StiReport1.Item("CVE_OPER1") = CVE_OPER1
                FrmAsignacionViaje.StiReport1.Item("CVE_OPER2") = CVE_OPER2

                FrmAsignacionViaje.StiReport1("CVE_VIAJE_V1") = tCVE_VIAJE.Text
                FrmAsignacionViaje.StiReport1("CVE_VIAJE_V2") = tCVE_VIAJE2.Text
                FrmAsignacionViaje.StiReport1("F1") = F1.Value.ToString.Substring(0, 10)
                FrmAsignacionViaje.StiReport1("F2") = F2.Value.ToString.Substring(0, 10)
                FrmAsignacionViaje.StiReport1("CVE_ST") = CVE_ST
                FrmAsignacionViaje.StiReport1("VAR_ST_GASTOS") = VAR_ST_GASTOS
                FrmAsignacionViaje.StiReport1("OPERADOR") = LOper.Text

                FrmAsignacionViaje.StiReport1.Render()
                FrmAsignacionViaje.StiReport1.Show()


                Try
                    If chEnviaXCorreo.Checked Then
                        Try
                            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportGastosDeViajeG.mrt"

                            If Not File.Exists(RUTA_FORMATOS) Then
                                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                                Return
                            End If
                            PDF = GET_RUTA_FORMATOS() & "\ReportGastosDeViajeG.pdf"

                            Dim aCorreo As New ArrayList From {
                                PDF
                            }

                            FrmAsignacionViaje.StiReport1.ExportDocument(StiExportFormat.Pdf, PDF)
                            SendEmail(tCORREO.Text, "Reporte vale de combustible", "Buen dia " & vbNewLine &
                                 "Adjunto se envia el reporte de vale de combustible" & vbNewLine & "Gracias", aCorreo)

                        Catch ex As Exception
                            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                BarImprimir.Enabled = True
            Catch ex As Exception
                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub cboStatus_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles cboStatus.DropDownClosed
        Try
            If cboStatus.SelectedIndex > -1 Then
                Dim CVE_ST As String
                CVE_ST = cboStatus.Items(cboStatus.SelectedIndex)
                LtStatus.Text = "Estatus:" & CVE_ST
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                tCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_OPER_Validated(sender As Object, e As EventArgs) Handles tCVE_OPER.Validated
        Try
            If tCVE_OPER.Text.Trim.Length > 0 And IsNumeric(tCVE_OPER.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                End If
            Else
                LOper.Text = ""
                tCVE_OPER.Text = ""
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
