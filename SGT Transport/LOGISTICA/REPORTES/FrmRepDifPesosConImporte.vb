Imports C1.Win.C1Themes
Imports System.IO
Imports C1.Win.C1Command
Imports Stimulsoft.Report.StiOptions.Designer
Imports System.Globalization

Public Class FrmRepDifPesosConImporte
    Private Sub FrmRepDifPesosConImporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try

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
    Private Sub FrmRepDifPesosConImporte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCartaPorteDifPesoImportes.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            BarImprimir.Enabled = False

            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Dim Date1 As String = F1.Value.year & Format(F1.Value.month, "00") & Format(F1.Value.daY, "00") & " 00:00:00"
            Dim Date2 As String = F2.Value.year & Format(F2.Value.month, "00") & Format(F2.Value.daY, "00") & " 23:59:59"


            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text

            If TCLIENTE.Text.Trim.Length > 0 Then
                StiReport1.Item("CLIENTE1") = TCLIENTE.Text
                StiReport1.Item("CLIENTE2") = TCLIENTE.Text
            Else
                StiReport1.Item("CLIENTE1") = ""
                StiReport1.Item("CLIENTE2") = "XXXXXXX"
            End If

            StiReport1("F1") = Date1
            StiReport1("F2") = Date2

            StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

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

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = "1" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtClie.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            Dim DESCR As String
            If TCLIENTE.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    TCLIENTE.Text = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtClie.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtClie.Text = ""
                End If
            Else
                LtClie.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class