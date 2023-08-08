Imports System.IO
Imports C1.Win.C1Themes
Public Class FrmReporteValesViking
    Private Sub FrmReporteValesViking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                BarDisenador.Visible = True
            Else
                BarDisenador.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmReporteValesViking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                L2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            Else
                TCVE_OPER.Text = ""
                L2.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    L2.Text = ""
                End If
            Else
                L2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGas_Click(sender As Object, e As EventArgs) Handles BtnGas.Click
        Try
            Var2 = "Gasolinera"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_GAS.Text = Var4
                LtGas.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_GAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGas_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_GAS_Validated(sender As Object, e As EventArgs) Handles TCVE_GAS.Validated
        Try
            Dim DESCR As String
            If TCVE_GAS.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", TCVE_GAS.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtGas.Text = DESCR
                Else
                    MsgBox("Gasolinera inexistente")
                    TCVE_GAS.Text = "" : LtGas.Text = ""
                End If
            Else
                TCVE_GAS.Text = "" : LtGas.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String, CVE_OPER1 As Integer, CVE_OPER2 As Integer, CVE_GAS1 As String, CVE_GAS2 As String
            Dim j As Integer = 0

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportConviValesViking.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            If TCVE_OPER.Text.Trim.Length > 0 Then
                CVE_OPER1 = TCVE_OPER.Text
                CVE_OPER2 = TCVE_OPER.Text
            Else
                CVE_OPER1 = 0
                CVE_OPER2 = 999999
            End If
            If TCVE_GAS.Text.Trim.Length > 0 Then
                CVE_GAS1 = TCVE_GAS.Text
                CVE_GAS2 = TCVE_GAS.Text
            Else
                CVE_GAS1 = ""
                CVE_GAS2 = "XXXXX"
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("F1") = F1.Value
            StiReport1.Item("F2") = F2.Value
            StiReport1.Item("CVE_GAS1") = CVE_GAS1
            StiReport1.Item("CVE_GAS2") = CVE_GAS2
            StiReport1.Item("CVE_OPER1") = CVE_OPER1
            StiReport1.Item("CVE_OPER2") = CVE_OPER2
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As EventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportConviValesViking")
    End Sub
End Class