Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command

Public Class frmAsigGastosDieselImprimir
    Private Sub frmImprimirGastosDiesel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmImprimirGastosDiesel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDieselGastosG.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            frmAsignacionViaje.StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            frmAsignacionViaje.StiReport1.Dictionary.Databases.Clear()
            frmAsignacionViaje.StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            frmAsignacionViaje.StiReport1.Compile()
            frmAsignacionViaje.StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            FrmAsignacionViaje.StiReport1.Item("FECHA1") = F1.Value
            frmAsignacionViaje.StiReport1.Item("FECHA2") = F2.Value

            frmAsignacionViaje.StiReport1("F1") = F1.Value.ToString.Substring(0, 10)
            frmAsignacionViaje.StiReport1("F2") = F2.Value.ToString.Substring(0, 10)

            frmAsignacionViaje.StiReport1.Render()
            frmAsignacionViaje.StiReport1.Show()

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
