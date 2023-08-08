Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command
Public Class RibbonImprimiDisenador
    Private Sub RibbonForm5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub BarImprimir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarImprimir.Click
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

    Private Sub BarDisenador_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportResumenMovsInv")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub RibbonForm5_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

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

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var3
                LtDescUnidad.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
            End If
        Catch Ex As Exception
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    LtDescUnidad.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    LtDescUnidad.Text = ""
                    tCVE_UNI.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv1_Click(sender As Object, e As EventArgs) Handles btnProv1.Click
        Try
            Var2 = "Prov"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV1.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                TCVE_PROV2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_PROV1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV1.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnProv1_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_PROV1_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV1.Validated
        Try
            If tCVE_PROV1.Text.Trim.Length > 0 Then
                Dim DESCR As String, CLAVE = tCVE_PROV1.Text
                If IsNumeric(tCVE_PROV1.Text) Then
                    CLAVE = Space(10 - tCVE_PROV1.Text.Trim.Length) & tCVE_PROV1.Text.Trim
                End If
                DESCR = BUSCA_CAT("Prov", CLAVE)
                If DESCR <> "" Then
                    tCVE_PROV1.Text = CLAVE
                Else
                    MsgBox("Proveedor inexistente")
                    tCVE_PROV1.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv2_Click(sender As Object, e As EventArgs) Handles btnProv2.Click
        Try
            Var2 = "Prov"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PROV2.Text = Var4
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                TCVE_PROV2.Focus()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_PROV2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PROV2.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then

                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_PROV2_Validated(sender As Object, e As EventArgs) Handles TCVE_PROV2.Validated
        Try
            If TCVE_PROV2.Text.Trim.Length > 0 Then
                Dim DESCR As String, CLAVE = TCVE_PROV2.Text
                If IsNumeric(TCVE_PROV2.Text) Then
                    CLAVE = Space(10 - TCVE_PROV2.Text.Trim.Length) & TCVE_PROV2.Text.Trim
                End If
                DESCR = BUSCA_CAT("Prov", CLAVE)
                If DESCR <> "" Then
                    TCVE_PROV2.Text = CLAVE
                Else
                    MsgBox("Proveedor inexistente")
                    TCVE_PROV2.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnClie1_Click(sender As Object, e As EventArgs) Handles BtnClie1.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE1.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCLIENTE1_Validated(sender As Object, e As EventArgs) Handles TCLIENTE1.Validated
        Try
            If TCLIENTE1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCLIENTE1.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE1.Text.Trim.Length) & TCLIENTE1.Text.Trim
                    TCLIENTE1.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE1.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnClie2_Click(sender As Object, e As EventArgs) Handles BtnClie2.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE2.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCLIENTE2_Validated(sender As Object, e As EventArgs) Handles TCLIENTE2.Validated
        Try
            If TCLIENTE2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCLIENTE2.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE2.Text.Trim.Length) & TCLIENTE2.Text.Trim
                    TCLIENTE2.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE2.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub C1Button1_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUnidades_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TANQUE1.Text = Var5
                LtTanque1.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtTanque1.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ART.Focus()
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_ART.Focus()
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProd_Click(sender As Object, e As EventArgs) Handles BtnProd.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtDescr.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProd_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text, False)
                If DESCR <> "" Then
                    LtDescr.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class