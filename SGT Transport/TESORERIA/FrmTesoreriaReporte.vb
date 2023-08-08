Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Public Class FrmTesoreriaReporte
    Private Sub FrmTesoreriaReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmTesoreriaReporte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        BarImprimir.Enabled = False
        Try
            Dim RUTA_FORMATOS As String, VAR_ST_GASTOS As String = "", ST_GAS As String = ""

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\TESORERIA.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                BarImprimir.Enabled = True
                Return
            End If
            FrmAsignacionViaje.StiReport1.Load(RUTA_FORMATOS)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            FrmAsignacionViaje.StiReport1.Dictionary.Databases.Clear()
            FrmAsignacionViaje.StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            FrmAsignacionViaje.StiReport1.Compile()
            FrmAsignacionViaje.StiReport1.Dictionary.Synchronize()
            FrmAsignacionViaje.StiReport1.ReportName = Me.Text
            FrmAsignacionViaje.StiReport1.Item("F1") = F1.Value
            FrmAsignacionViaje.StiReport1.Item("F2") = F2.Value

            FrmAsignacionViaje.StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            FrmAsignacionViaje.StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

            If TREF_BAN.Text.Trim.Length > 0 Then
                FrmAsignacionViaje.StiReport1("REF_BAN1") = TREF_BAN.Text
                FrmAsignacionViaje.StiReport1("REF_BAN2") = TREF_BAN.Text
            Else
                FrmAsignacionViaje.StiReport1("REF_BAN1") = ""
                FrmAsignacionViaje.StiReport1("REF_BAN2") = "ZZZZZZZZZZZZZZZ"
            End If

            FrmAsignacionViaje.StiReport1.Render()

            'FrmAsignacionViaje.StiReport1.Design()
            FrmAsignacionViaje.StiReport1.Show()

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
