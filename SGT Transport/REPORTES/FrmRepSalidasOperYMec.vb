Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command

Public Class FrmRepSalidasOperYMec
    Private Sub FrmRepSalidasOperYMec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Almacén", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))

            CboOperMec.Items.Clear()
            CboOperMec.Items.Add("Todos")
            CboOperMec.Items.Add("Operadores")
            CboOperMec.Items.Add("Mecánicos")
            CboOperMec.SelectedIndex = 0

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'F1.Value = "01/08/2021"
        'F2.Value = "31/08/2021"
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If
            '7. Salidas generales, operadores y mecánicos
            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSalidasOperYMec.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            '7. Salidas generales, operadores y mecánicos
            StiReport1.Item("F1") = F1.Value
            StiReport1.Item("F2") = F2.Value
            StiReport1.Item("OPF1") = F1.Value
            StiReport1.Item("OPF2") = F2.Value
            If CboOperMec.SelectedIndex = 0 Then                'TODOS
                StiReport1.Item("NUM_CPTO") = 62
                StiReport1.Item("OPNUM_CPTO") = 63
            Else
                If CboOperMec.SelectedIndex = 1 Then                    'OPERADORES
                    StiReport1.Item("NUM_CPTO") = 0
                    StiReport1.Item("OPNUM_CPTO") = 63
                Else                    'MECANICOS
                    StiReport1.Item("NUM_CPTO") = 62
                    StiReport1.Item("OPNUM_CPTO") = 0
                End If
            End If
            StiReport1.Item("GCVE_CPTO1") = 64
            StiReport1.Item("GCVE_CPTO2") = 65
            StiReport1.Item("GCVE_CPTO3") = 68
            StiReport1.Item("GCVE_CPTO4") = 70
            StiReport1("GF1") = F1.Value.ToString.Substring(0, 10)
            StiReport1("GF2") = F2.Value.ToString.Substring(0, 10)
            '7. Salidas generales, operadores y mecánicos
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRepSalidasOperYMec_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
End Class
