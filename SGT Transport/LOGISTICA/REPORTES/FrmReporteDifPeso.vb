Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Imports Stimulsoft.Report

Public Class FrmReporteDifPeso
    Private NomReport As String
    Private Sub FrmReporteDifPeso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            BtnUnidades.FlatStyle = FlatStyle.Flat
            BtnUnidades.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            BtnProd.FlatStyle = FlatStyle.Flat
            BtnProd.FlatAppearance.BorderSize = 0

            AssignValidation(Me.TCVE_OPER, ValidationType.Only_Numbers)
            AssignValidation(Me.TCVE_ART, ValidationType.Only_Numbers)

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            NomReport = Var4

            If NomReport = "Carta porte" Then
                Me.Text = "Reporte carta porte"
            End If
            Select Case NomReport
                Case "Carta porte"
                    Me.Text = "Reporte carta porte"
                Case "DifPeso"
                    Me.Text = "Reporte carta porte diferencia de peso"
                Case "Cartas porte transferidas"
                    Me.Text = "Cartas porte transferidas"
            End Select

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year
            F1.Value = D1
            F2.Value = D2
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmReporteDifPeso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim Reporte As New StiReport
            Dim RUTA_FORMATOS As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            Select Case NomReport
                Case "Carta porte"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCartaPorteGen.mrt"
                Case "DifPeso"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCartaPorteDifPeso.mrt"
                Case "Cartas porte transferidas"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCartaPorteTrans.mrt"
            End Select

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            BarImprimir.Enabled = False

            Reporte.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte.Item("F1") = F1.Value
            Reporte.Item("F2") = F2.Value

            Select Case NomReport
                Case "Carta porte"
                Case "DifPeso"
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        Reporte.Item("TRACTOR1") = TCVE_TRACTOR.Text
                        Reporte.Item("TRACTOR2") = TCVE_TRACTOR.Text
                        Reporte("UNIDAD") = "Unidad: " & TCVE_TRACTOR.Text
                    Else
                        Reporte.Item("TRACTOR1") = ""
                        Reporte.Item("TRACTOR2") = "XXXXXXX"
                        Reporte("UNIDAD") = ""
                    End If
                    If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                        Reporte.Item("CVE_TANQUE1") = TCVE_TANQUE1.Text
                        Reporte.Item("CVE_TANQUE2") = TCVE_TANQUE1.Text
                        Reporte("TANQUE1") = "Tanque: " & TCVE_TANQUE1.Text
                    Else
                        Reporte.Item("CVE_TANQUE1") = ""
                        Reporte.Item("CVE_TANQUE2") = "XXXXXXX"
                        Reporte("TANQUE1") = ""
                    End If

                    If TCVE_OPER.Text.Trim.Length > 0 Then
                        Reporte.Item("CVE_OPER1") = TCVE_OPER.Text
                        Reporte.Item("CVE_OPER2") = TCVE_OPER.Text
                        Reporte("OPER") = "Operador: (" & TCVE_OPER.Text & ") " & LOper.Text
                    Else
                        Reporte.Item("CVE_OPER1") = 0
                        Reporte.Item("CVE_OPER2") = 9999
                        Reporte("OPER") = ""
                    End If
                    If TCVE_ART.Text.Trim.Length > 0 Then
                        Reporte.Item("CVE_ART1") = TCVE_ART.Text
                        Reporte.Item("CVE_ART2") = TCVE_ART.Text
                        Reporte("MAT") = "Producto: (" & TCVE_ART.Text & ") " & LtDescr.Text
                    Else
                        Reporte.Item("CVE_ART1") = 0
                        Reporte.Item("CVE_ART2") = 9999
                        Reporte("MAT") = ""
                    End If

                Case "Cartas porte transferidas"
            End Select


            Reporte("F3") = F1.Value.ToString.Substring(0, 10)
            Reporte("F4") = F2.Value.ToString.Substring(0, 10)

            Reporte.Render()
            'Reporte.Show()
            VisualizaReporte(Reporte)
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidades_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART.Focus()
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_ART.Focus()
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProd_Click(sender As Object, e As EventArgs) Handles BtnProd.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtDescr.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProd_Click(Nothing, Nothing)
            Return
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
    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TANQUE1.Text = Var5
                LtTanque1.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TTANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TTANQUE1_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtTanque1.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
