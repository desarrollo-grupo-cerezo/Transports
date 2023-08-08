Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command

Public Class FrmRepOTExternas
    Private Sub FrmRepOTExternas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.CenterToScreen()
    End Sub

    Private Sub FrmRepOTExternas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("O.T.Externas")
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""

            If Not ChTractor.Checked And Not ChTanque.Checked And Not ChDolly.Checked And Not ChUtilitario.Checked Then
                MsgBox("Por favor seleccione al menos un tipo de unidad")
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportOTExterna.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")

                Return
            End If
            BarImprimir.Enabled = False
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Item("F1") = F1.Value
            StiReport1.Item("F2") = F2.Value
            StiReport1.Item("TRACTO") = IIf(ChTractor.Checked, 1, 0)
            StiReport1.Item("TANQUE") = IIf(ChTanque.Checked, 2, 0)
            StiReport1.Item("DOLLY") = IIf(ChDolly.Checked, 3, 0)
            StiReport1.Item("UTILITARIO") = IIf(ChUtilitario.Checked, 7, 0)

            StiReport1.Item("TRACTO2") = IIf(ChTractor.Checked, 1, 0)
            StiReport1.Item("TANQUE2") = IIf(ChTanque.Checked, 2, 0)
            StiReport1.Item("DOLLY2") = IIf(ChDolly.Checked, 3, 0)
            StiReport1.Item("UTILITARIO2") = IIf(ChUtilitario.Checked, 7, 0)

            StiReport1.Item("F3") = F1.Value
            StiReport1.Item("F4") = F2.Value

            'StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            'StiReport1("F4") = F2.Value.ToString.Substring(0, 10)


            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()
            StiReport1.Show()
            'StiReport1.Design()

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
