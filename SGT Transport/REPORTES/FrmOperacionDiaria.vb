Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Imports System.Data.SqlClient
Imports Stimulsoft
Imports Stimulsoft.Report

Public Class FrmOperacionDiaria

    Private Sub FrmOperacionDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            TDIAS_TRABAJADOS1.Value = 0
            TDIAS_MES1.Value = 0
            TDIAS_TRABAJADOSP.Value = 0
            TDIAS_MESP.Value = 0
            TINGRESO_DIARIOP.Value = 0
            TINGRESO_ACUMULADOP.Value = 0

            TUNIDADES_DIAP.Value = 0
            TUNIDADES_MESP.Value = 0

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT DIAS_TRABAJADOS1, DIAS_MES1, DIAS_TRABAJADOSP, DIAS_MESP, 
                        INGRESO_DIARIOP, INGRESO_ACUMULADOP, UNIDADES_DIAP, UNIDADES_MESP
                        FROM GCPARAMTRANSCG"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TDIAS_TRABAJADOS1.Value = dr.ReadNullAsEmptyDecimal("DIAS_TRABAJADOS1")
                            TDIAS_MES1.Value = dr.ReadNullAsEmptyDecimal("DIAS_MES1")
                            TDIAS_TRABAJADOSP.Value = dr.ReadNullAsEmptyDecimal("DIAS_TRABAJADOSP")
                            TDIAS_MESP.Value = dr.ReadNullAsEmptyDecimal("DIAS_MESP")
                            TINGRESO_DIARIOP.Value = dr.ReadNullAsEmptyDecimal("INGRESO_DIARIOP")
                            TINGRESO_ACUMULADOP.Value = dr.ReadNullAsEmptyDecimal("INGRESO_ACUMULADOP")
                            TUNIDADES_DIAP.Value = dr.ReadNullAsEmptyDecimal("UNIDADES_DIAP")
                            TUNIDADES_MESP.Value = dr.ReadNullAsEmptyDecimal("UNIDADES_MESP")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmOperacionDiaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            Try
                TDIAS_TRABAJADOS1.UpdateValueWithCurrentText()
                TDIAS_MES1.UpdateValueWithCurrentText()
                TDIAS_TRABAJADOSP.UpdateValueWithCurrentText()
                TDIAS_MESP.UpdateValueWithCurrentText()
                TINGRESO_DIARIOP.UpdateValueWithCurrentText()
                TINGRESO_ACUMULADOP.UpdateValueWithCurrentText()

                TUNIDADES_DIAP.UpdateValueWithCurrentText()
                TUNIDADES_MESP.UpdateValueWithCurrentText()

                SQL = "UPDATE GCPARAMTRANSCG SET DIAS_TRABAJADOS1 = " & TDIAS_TRABAJADOS1.Value & ", DIAS_MES1 =  " & TDIAS_MES1.Value & ", 
                    DIAS_TRABAJADOSP = " & TDIAS_TRABAJADOSP.Value & ", DIAS_MESP = " & TDIAS_MESP.Value & ", 
                    INGRESO_DIARIOP = " & TINGRESO_DIARIOP.Value & ", INGRESO_ACUMULADOP = " & TINGRESO_ACUMULADOP.Value & ", 
                    UNIDADES_DIAP = " & TUNIDADES_DIAP.Value & ", UNIDADES_MESP = " & TUNIDADES_MESP.Value

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Dim D1 As Date
            Dim FFCH As Date = F1.Value
            Dim Reporte As New StiReport

            D1 = "01/" & Format(FFCH.Month, "00") & "/" & FFCH.Year

            'D2 = Format(DateTime.DaysInMonth(N.Year, N.MoSnth), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReporReporteOperacion.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()
            Reporte.ReportName = Me.Text
            Reporte("F1") = FSQL(F1.Value) & " 00:00:00"
            Reporte("F2") = FSQL(F2.Value) & " 23:59:59"

            Reporte("F3") = FSQL(D1) & " 00:00:00"
            Reporte("F4") = FSQL(F2.Value) & " 23:59:59"

            Reporte("DIAS_TRABAJADOS1") = TDIAS_TRABAJADOS1.Value
            Reporte("DIAS_MES1") = TDIAS_MES1.Value
            Reporte("DIAS_TRABAJADOSP") = TDIAS_TRABAJADOSP.Value
            Reporte("DIAS_MESP") = TDIAS_MESP.Value
            Reporte("INGRESO_DIARIOP") = TINGRESO_DIARIOP.Value
            Reporte("INGRESO_ACUMULADOP") = TINGRESO_ACUMULADOP.Value

            Reporte("UNIDADES_DIAP") = TUNIDADES_DIAP.Value
            Reporte("UNIDADES_MESP") = TUNIDADES_MESP.Value

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
