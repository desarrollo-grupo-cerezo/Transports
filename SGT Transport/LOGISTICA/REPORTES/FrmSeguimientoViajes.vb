Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmSeguimientoViajes
    Private Sub FrmSeguimientoViajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Dim N = DateTime.Now.AddMonths(-1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        SplitM1.Dock = DockStyle.Fill
        SplitM2.Dock = DockStyle.Fill
        Fg.Dock = DockStyle.Fill
        Fg2.Dock = DockStyle.Fill

        SplitM1.BorderWidth = 1
        SplitM1.SplitterWidth = 1
        SplitM1.FixedLineWidth = 1
        SplitM1.HeaderLineWidth = 1

        SplitM2.BorderWidth = 1
        SplitM2.SplitterWidth = 1
        SplitM2.FixedLineWidth = 1
        SplitM2.HeaderLineWidth = 1

        BtnFlecha1.FlatStyle = FlatStyle.Flat
        BtnFlecha1.FlatAppearance.BorderSize = 0
        BtnFlecha2.FlatStyle = FlatStyle.Flat
        BtnFlecha2.FlatAppearance.BorderSize = 0

        BtnFlecha3.FlatStyle = FlatStyle.Flat
        BtnFlecha3.FlatAppearance.BorderSize = 0
        BtnFlecha4.FlatStyle = FlatStyle.Flat
        BtnFlecha4.FlatAppearance.BorderSize = 0

        Dim SPOR1 As Decimal

        SPOR1 = ((F1.Top + F1.Height) / Me.Height) * 100
        SplitM2P1.SizeRatio = SPOR1 + 1
        SplitM2P2.SizeRatio = 100 - SplitM2P1.SizeRatio

        SPOR1 = ((F3.Top + F3.Height) / Me.Height) * 100
        SplitM1P2.SizeRatio = SPOR1 + 1
        SplitM1P3.SizeRatio = 100 - SplitM1P2.SizeRatio


        Try
            F1.Value = d1
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            'F1.Clear()

            F2.Value = d2
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"
            'F2.Clear()

            F3.Value = d1
            F3.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F3.CustomFormat = "dd/MM/yyyy"
            F3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F3.EditFormat.CustomFormat = "dd/MM/yyyy"
            'F3.Clear()

            F4.Value = d2
            F4.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F4.CustomFormat = "dd/MM/yyyy"
            F4.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F4.EditFormat.CustomFormat = "dd/MM/yyyy"
            'F4.Clear()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnFlecha1_Click(sender As Object, e As EventArgs) Handles BtnFlecha1.Click

        Dim dtp As Date = F1.Value

        Dim N = dtp.AddMonths(-1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F1.Value = d1
        F2.Value = d2

    End Sub

    Private Sub BtnFlecha2_Click(sender As Object, e As EventArgs) Handles BtnFlecha2.Click

        Dim dtp As Date = F1.Value

        Dim N = dtp.AddMonths(1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F1.Value = d1
        F2.Value = d2

    End Sub
    Private Sub FrmSeguimientoViajes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Seguimiento viajes")
    End Sub
    Sub DESPLEGAR(FFILTRO As String)
        Dim CADENA As String

        BarImprimir.Enabled = False
        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        Try

            If FFILTRO = "CARGA" Then
                Fg.Rows.Count = 1
                CADENA = "V.FECHA_CARGA >= '" & FSQL(F1.Value) & "' AND V.FECHA_CARGA <= '" & FSQL(F2.Value) & "'"
            Else
                Fg2.Rows.Count = 1
                CADENA = "V.FECHA_DESCARGA >= '" & FSQL(F1.Value) & "' AND V.FECHA_DESCARGA <= '" & FSQL(F2.Value) & "'"
            End If

            SQL = "SELECT V.CVE_VIAJE, V.CVE_DOC, V.FECHA, V.CVE_ST_VIA, V.CVE_TRACTOR, V.CVE_TANQUE1, V.CVE_TANQUE2, 
                O.NOMBRE AS NOMBRE_OPER, V.FECHA_CARGA, V.FECHA_DESCARGA, C.NOMBRE AS NOMBRE_CLIE, ISNULL(RECOGER.DESCR,'') AS ORIGEN 
                FROM GCASIGNACION_VIAJE V
                LEFT JOIN dbo.GCRECOGER_EN_ENTREGAR_EN RECOGER ON V.RECOGER_EN = RECOGER.CVE_REG    
                LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = V.CVE_CAP1
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = CP.CLIENTE
                LEFT JOIN dbo.GCOPERADOR O ON V.CVE_OPER = O.CLAVE 
                WHERE V.CVE_ST_VIA  <> 7 AND " & CADENA
            'UNIDAD, TANQUE, OPERADOR, ORIGEN, CLIENTE
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If FFILTRO = "CARGA" Then
                            Fg.AddItem("" & vbTab & dr("CVE_TRACTOR") & vbTab & dr("CVE_TANQUE1") & IIf(dr("CVE_TANQUE2").ToString.Trim.Length > 0, " / ", "") &
                                       dr("CVE_TANQUE2") & vbTab & dr("NOMBRE_OPER") & vbTab & dr("ORIGEN") & vbTab & dr("NOMBRE_CLIE"))
                        Else
                            Fg2.AddItem("" & vbTab & dr("CVE_TRACTOR") & vbTab & dr("CVE_TANQUE1") & IIf(dr("CVE_TANQUE2").ToString.Trim.Length > 0, " / ", "") &
                                        dr("CVE_TANQUE2") & vbTab & dr("NOMBRE_OPER") & vbTab & dr("ORIGEN") & vbTab & dr("NOMBRE_CLIE"))
                        End If
                    End While
                End Using
            End Using

            If FFILTRO = "CARGA" Then
                Fg.AutoSizeCols()
                Fg.Focus()
            Else
                Fg2.AutoSizeCols()
                Fg2.Focus()
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True
        Fg.Redraw = True
        Me.Cursor = Cursors.Default

        MsgBox("Proceso terminado")

    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        DESPLEGAR("CARGA")
    End Sub
    Private Sub BarDesplegar2_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar2.Click
        DESPLEGAR("DESCARGA")
    End Sub
    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        PrinterMRT("ReportSeguimientoViajesC")
    End Sub
    Private Sub BarDiseñador2_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador2.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg2, "Seguimiento viajes2")
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        IMPRIMIR("CARGA")
    End Sub
    Private Sub BarImprimir2_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir2.Click
        IMPRIMIR("DESCARGA")
    End Sub
    Sub IMPRIMIR(FTIPO As String)
        Try
            Dim RUTA_FORMATOS As String
            BarImprimir.Enabled = False

            If FTIPO = "CARGA" Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSeguimientoViajesC.mrt"
            Else
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSeguimientoViajesD.mrt"
            End If

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

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BarImprimir.Enabled = True
    End Sub
    Private Sub BtnFlecha3_Click(sender As Object, e As EventArgs) Handles BtnFlecha3.Click

        Dim dtp As Date = F3.Value

        Dim N = dtp.AddMonths(-1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F3.Value = d1
        F4.Value = d2
    End Sub

    Private Sub BtnFlecha4_Click(sender As Object, e As EventArgs) Handles BtnFlecha4.Click

        Dim dtp As Date = F3.Value

        Dim N = dtp.AddMonths(1), d1 As String, d2 As String
        d1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        d2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F3.Value = d1
        F4.Value = d2
    End Sub

    Private Sub BarExcel2_Click(sender As Object, e As ClickEventArgs) Handles BarExcel2.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Seguimiento viajes1")
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Seguimiento viajes1")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarSalir2_Click(sender As Object, e As ClickEventArgs) Handles BarSalir2.Click
        Me.Close()
    End Sub

End Class