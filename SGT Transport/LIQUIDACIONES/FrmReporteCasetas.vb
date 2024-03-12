Imports C1.Win.C1Command
Imports Stimulsoft.Report

Public Class FrmReporteCasetas
    Private Sub FrmReporteCasetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE = "BR3FRAJA" Then
                BarDisenador.Visible = True
            Else
                BarDisenador.Visible = False
            End If


        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReporteLiquidacionesCasetas")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim Reporte As New StiReport
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporteLiquidacionesCasetas.mrt"
            If Not IO.File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" & Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()

            Reporte("F1") = FSQL(F1.Value)
            Reporte("F2") = FSQL(F2.Value)

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
End Class