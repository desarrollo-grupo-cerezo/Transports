Imports System.IO
Imports C1.Win.C1Themes
Imports Stimulsoft.Report

Public Class FrmReportLiq
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmReportLiq_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Try
            FC1.Value = d1
            FC1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC1.CustomFormat = "dd/MM/yyyy"
            FC1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC1.EditFormat.CustomFormat = "dd/MM/yyyy"
            FC1.Clear()
        Catch ex As Exception
        End Try
        Try
            FC2.Value = d2
            FC2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC2.CustomFormat = "dd/MM/yyyy"
            FC2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FC2.EditFormat.CustomFormat = "dd/MM/yyyy"
            FC2.Clear()
        Catch ex As Exception
        End Try
        Try
            FD1.Value = d1
            FD1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD1.CustomFormat = "dd/MM/yyyy"
            FD1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD1.EditFormat.CustomFormat = "dd/MM/yyyy"
            FD1.Clear()
        Catch ex As Exception
        End Try
        Try
            FD2.Value = d2
            FD2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD2.CustomFormat = "dd/MM/yyyy"
            FD2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FD2.EditFormat.CustomFormat = "dd/MM/yyyy"
            FD2.Clear()
        Catch ex As Exception
        End Try


    End Sub
    Private Sub FrmReportLiq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""
            Dim Reporte As New StiReport

            BarImprimir.Enabled = False


            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportLiquidaciones.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Reporte.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Reporte.Dictionary.Databases.Clear()
            Reporte.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            Reporte.ReportName = Me.Text
            Reporte.Compile()
            Reporte.Dictionary.Synchronize()

            Reporte.Item("F1") = F1.Value
            Reporte.Item("F2") = F2.Value
            Reporte.Item("FC1") = FC1.Value
            Reporte.Item("FC2") = FC2.Value
            Reporte.Item("FD1") = FD1.Value
            Reporte.Item("FD2") = FD2.Value


            If F1.Text = "" Then
                Reporte("V1") = ""
            Else
                Reporte("V1") = F1.Value.ToString.Substring(0, 10)
            End If
            If F2.Text = "" Then
                Reporte("V2") = ""
            Else
                Reporte("V2") = F2.Value.ToString.Substring(0, 10)
            End If

            If FC1.Text = "" Then
                Reporte("VC1") = ""
            Else
                Reporte("VC1") = FC1.Value.ToString.Substring(0, 10)
            End If
            If FC2.Text = "" Then
                Reporte("VC2") = ""
            Else
                Reporte("VC2") = FC2.Value.ToString.Substring(0, 10)
            End If

            If FD1.Text = "" Then
                Reporte("VD1") = ""
            Else
                Reporte("VD1") = FD1.Value.ToString.Substring(0, 10)
            End If

            If FD2.Text = "" Then
                Reporte("VD2") = ""
            Else
                Reporte("VD2") = FD2.Value.ToString.Substring(0, 10)
            End If

            Reporte.Render()
            'Reporte.Show()
            VisualizaReporte(Reporte)
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()

    End Sub
End Class
