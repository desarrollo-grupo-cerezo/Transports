Imports System.Data.SqlClient
Imports C1.Win.C1Themes
Imports System.IO
Public Class FrmPrecursores
    Private Sub FrmPrecursores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PROD, DESCR FROM GCPRODUCTOS WHERE STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_PROD") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

            If PASS_GRUPOCE.ToUpper = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                BarDisenador.Visible = True
            Else
                BarDisenador.Visible = False
            End If
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

    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = "", CADENA_PROD As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportPrecursores.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            BarImprimir.Enabled = False

            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                If C1List1.GetSelected(row) Then
                    CADENA_PROD += cellValue.ToString & "','"
                    j += 1
                End If
            Next

            If j = 0 Then
                MsgBox("Por favor seleccione al menos un producto")
                Return
            End If

            CADENA_PROD = CADENA_PROD.Substring(0, CADENA_PROD.Length - 3)

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


            StiReport1("PRODUCTOS") = CADENA_PROD
            StiReport1("F1") = Date1
            StiReport1("F2") = Date2
            If ChIncluirCanceladas.Checked Then
                StiReport1("ESTATUS") = "C"
            Else
                StiReport1("ESTATUS") = "A"
            End If

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmPrecursores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportPrecursores")
    End Sub
End Class