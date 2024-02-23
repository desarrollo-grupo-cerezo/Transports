Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Imports Stimulsoft.Report

Public Class FrmReporte44
    Private Sub FrmReporte44_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String
            D1 = "01/" & Format(N.Month, "00") & "/" & N.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & N.Year

            F1.Value = D1
            F2.Value = D2

            If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                BarDiseno.Visible = True
            Else
                BarDiseno.Visible = False
            End If

            Me.Text = "Reporte " & VarFORM2
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub FrmReporte44_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim Reporte As New StiReport
            Dim RUTA_FORMATOS As String = ""

            Select Case VarFORM2
                Case "1"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteF1.mrt"
                Case "2"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteF2.mrt"
                Case "3"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteF3.mrt"
                Case "4"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteF4.mrt"
                Case "5"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteF5.mrt"
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

            Dim formatString As String = "yyyyMMdd HHmmss"
            Dim sample As String = "20100611221912"
            'Dim dt As DateTime = DateTime.ParseExact(sample, formatString, Nothing)


            Dim dt As DateTime = F1.Value
            Dim dt2 As DateTime = F2.Value
            Dim FF1 As String
            Dim FF2 As String

            FF1 = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00") & " 00:00:00"
            FF2 = dt2.Year & Format(dt2.Month, "00") & Format(dt2.Day, "00") & " 23:59:59"

            'Reporte.Item("FF1") = FSQL(F1.Value)
            'Reporte.Item("FF2") = FSQL(F2.Value)

            Reporte("F1") = FF1
            Reporte("F2") = FF2

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

    Private Sub BarDiseno_Click(sender As Object, e As ClickEventArgs) Handles BarDiseno.Click
        'Diseñador
        Select Case VarFORM2
            Case "1"
                PrinterMRT("ReporteF1")
            Case "2"
                PrinterMRT("ReporteF2")
            Case "3"
                PrinterMRT("ReporteF3")
            Case "4"
                PrinterMRT("ReporteF4")
            Case "5"
                PrinterMRT("ReporteF5")
        End Select
    End Sub
End Class