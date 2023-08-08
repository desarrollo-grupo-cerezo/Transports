Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command

Public Class FrmResumenMovsInv
    Private Sub FrmResumenMovsInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Return
        End If
        Me.CenterToScreen()

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


            BtnArt1.FlatStyle = FlatStyle.Flat
            BtnArt1.FlatAppearance.BorderSize = 0
            BtnArt2.FlatStyle = FlatStyle.Flat
            BtnArt2.FlatAppearance.BorderSize = 0


        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.C1List1.SelectionMode = C1.Win.C1List.SelectionModeEnum.CheckBox

        DESPLEGAR("T")

    End Sub
    Sub DESPLEGAR(FOPC As String)
        Try
            C1List1.ClearItems()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                Select Case FOPC
                    Case "T"
                        SQL = "SELECT CVE_CPTO, DESCR, SIGNO FROM CONM" & Empresa & " WHERE STATUS = 'A'"
                    Case "E"
                        SQL = "SELECT CVE_CPTO, DESCR, SIGNO FROM CONM" & Empresa & " WHERE STATUS = 'A' AND SIGNO = 1"
                    Case "S"
                        SQL = "SELECT CVE_CPTO, DESCR, SIGNO FROM CONM" & Empresa & " WHERE STATUS = 'A' AND SIGNO = -1"
                End Select
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_CPTO") & ";" & dr("DESCR") & ";" & dr("SIGNO"))
                    End While
                End Using
            End Using

            C1List1.Splits(0).DisplayColumns(0).Width = 40
            C1List1.Splits(0).DisplayColumns(1).Width = 200
            C1List1.Splits(0).DisplayColumns(2).Width = 0
            C1List1.Splits(0).DisplayColumns(2).Visible = False

            For row As Integer = 0 To C1List1.ListCount - 1
                C1List1.SetSelected(row, True)
            Next

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmResumenMovsInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim j As Integer = 0
        Dim CADENA As String = ""
        Dim RUTA_FORMATOS As String

        Try
            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                If C1List1.GetSelected(row) Then
                    j += 1
                    CADENA += cellValue & ","
                End If
            Next

            If CADENA <> "" Then
                CADENA = CADENA.Substring(0, CADENA.Length - 1)
            End If

            If j = 0 Then
                MsgBox("Por favor seleccione al menos un concepto")
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportResumenMovsInv.mrt"
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

            StiReport1.Item("F1") = F1.Value
            StiReport1.Item("F2") = F2.Value
            If TCVE_ART1.Text.Trim.Length > 0 And TCVE_ART1.Text.Trim.Length > 0 Then
                StiReport1.Item("CVE_ART1") = TCVE_ART1.Text
                StiReport1.Item("CVE_ART2") = TCVE_ART2.Text
            Else
                If TCVE_ART1.Text.Trim.Length > 0 And TCVE_ART2.Text.Trim.Length = 0 Then
                    StiReport1.Item("CVE_ART1") = TCVE_ART1.Text
                    StiReport1.Item("CVE_ART2") = "XXXXXXXXXX"
                Else
                    If TCVE_ART1.Text.Trim.Length = 0 And TCVE_ART2.Text.Trim.Length > 0 Then
                        StiReport1.Item("CVE_ART1") = ""
                        StiReport1.Item("CVE_ART2") = TCVE_ART2.Text
                    Else
                        StiReport1.Item("CVE_ART1") = ""
                        StiReport1.Item("CVE_ART2") = "xxxxxxxxxxxx"
                    End If
                End If
            End If
            StiReport1("CPTO") = CADENA

            StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            StiReport1("F4") = F2.Value.ToString.Substring(0, 10)

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub ChEntradas_CheckedChanged(sender As Object, e As EventArgs) Handles ChEntradas.CheckedChanged
        Dim Stado As Boolean

        If ChEntradas.Checked Then
            Stado = True
        Else
            Stado = False
        End If

        For row As Integer = 0 To C1List1.ListCount - 1
            Dim cellValue As Object = C1List1.GetDisplayText(row, 2)

            If cellValue = "1" Then
                C1List1.SetSelected(row, Stado)
            End If
        Next
    End Sub
    Private Sub ChSalidas_CheckedChanged(sender As Object, e As EventArgs) Handles ChSalidas.CheckedChanged
        Dim Stado As Boolean

        If ChSalidas.Checked Then
            Stado = True
        Else
            Stado = False
        End If

        For row As Integer = 0 To C1List1.ListCount - 1
            Dim cellValue As Object = C1List1.GetDisplayText(row, 2)

            If cellValue = "-1" Then
                C1List1.SetSelected(row, Stado)
            End If
        Next
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As ClickEventArgs) Handles BarDisenador.Click

        PrinterMRT("ReportResumenMovsInv")

    End Sub

    Private Sub BtnArt1_Click(sender As Object, e As EventArgs) Handles BtnArt1.Click
        Try
            Var2 = "Articulo"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = ""
                TCVE_ART2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART1_Validated(sender As Object, e As EventArgs) Handles TCVE_ART1.Validated
        Try
            Dim DESCR As String
            If TCVE_ART1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Inven", TCVE_ART1.Text)
                If DESCR = "" Then
                    MsgBox("Articulo inexistente")
                    TCVE_ART1.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnArt2_Click(sender As Object, e As EventArgs) Handles BtnArt2.Click
        Try
            Var2 = "Articulo"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART2_Validated(sender As Object, e As EventArgs) Handles TCVE_ART2.Validated
        Try
            Dim DESCR As String
            If TCVE_ART2.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Inven", TCVE_ART2.Text)
                If DESCR = "" Then
                    MsgBox("Articulo inexistente")
                    TCVE_ART2.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class