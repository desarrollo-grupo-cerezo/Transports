Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command

Public Class frmExistAUnaFecha
    Private NameRep As String
    Private Sub frmExistAUnaFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_ALM") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

            Me.Height = 250
            NameRep = Var4
            Me.Text = NameRep
            Select Case NameRep
                Case "Existencia a una fecha"
                    L1.Text = "Seleccione fecha"
                    L1.Left = L1.Left - 50
                    LtDel.Visible = False
                    LtAl.Visible = False
                    F2.Visible = False
                    tCVE_UNI.Visible = False
                    LtDescUnidad.Visible = False
                    LtUnidad.Visible = False
                    btnUnidades.Visible = False

                    'PROVEEDORES
                    Lt5.Visible = False
                    Lt6.Visible = False
                    Lt7.Visible = False

                    btnProv1.Visible = False
                    tCVE_PROV1.Visible = False
                    btnProv2.Visible = False
                    TCVE_PROV2.Visible = False
                    'FIN 'PROVEEDORES

                    C1List1.Visible = False

                Case "Reporte de compras"
                    LtAl.Visible = True
                    F2.Visible = True
                    LtDel.Visible = True

                    tCVE_UNI.Visible = False
                    LtDescUnidad.Visible = False
                    LtUnidad.Visible = False
                    btnUnidades.Visible = False

                    Lt5.Visible = False
                    Lt6.Visible = False
                    Lt7.Visible = False

                    btnProv1.Visible = False
                    tCVE_PROV1.Visible = False
                    btnProv2.Visible = False
                    TCVE_PROV2.Visible = False
                    C1List1.Visible = True
                    C1List1.Top = F1.Top + F1.Height + 50
                    Me.Height = 400
                Case "Compras por proveedor"
                    LtAl.Visible = True
                    F2.Visible = True
                    LtDel.Visible = True

                    tCVE_UNI.Visible = False
                    LtDescUnidad.Visible = False
                    LtUnidad.Visible = False
                    btnUnidades.Visible = False

                    Me.Height = 500

                Case "Salida de llantas por unidad"
                    Lt5.Visible = False
                    Lt6.Visible = False
                    Lt7.Visible = False

                    btnProv1.Visible = False
                    tCVE_PROV1.Visible = False
                    btnProv2.Visible = False
                    TCVE_PROV2.Visible = False
                    C1List1.Visible = False
                Case "Detallado de ordenes de compra"
                    Me.Height = tCVE_PROV1.Top + tCVE_PROV1.Height + 50
                Case Else
                    Lt5.Visible = False
                    Lt6.Visible = False
                    Lt7.Visible = False

                    btnProv1.Visible = False
                    tCVE_PROV1.Visible = False
                    btnProv2.Visible = False
                    TCVE_PROV2.Visible = False
                    C1List1.Visible = False
            End Select
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.CenterToScreen()
    End Sub

    Private Sub frmExistAUnaFecha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab(NameRep)
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = "", CVE_ALM As String, j As Integer = 0
            Dim A1 As Integer = -1, A2 As Integer = -1, A3 As Integer = -1, A4 As Integer = -1, A5 As Integer = -1
            Dim A6 As Integer = -1, A7 As Integer = -1, A8 As Integer = -1, A9 As Integer = -1, A10 As Integer = -1
            Dim A11 As Integer = -1, A12 As Integer = -1, A13 As Integer = -1, A14 As Integer = -1, A15 As Integer = -1
            Dim A16 As Integer = -1, A17 As Integer = -1, A18 As Integer = -1, A19 As Integer = -1, A20 As Integer = -1
            BarImprimir.Enabled = False

            chSoloExist.Select()

            Select Case NameRep
                Case "Existencia a una fecha"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportExistALaFecha.mrt"
                Case "Reporte de compras"
                    For row As Integer = 0 To C1List1.ListCount - 1
                        Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                        If C1List1.GetSelected(row) Then
                            CVE_ALM = cellValue.ToString
                            j = j + 1
                            Select Case CVE_ALM
                                Case 1
                                    A1 = CVE_ALM
                                Case 2
                                    A2 = CVE_ALM
                                Case 3
                                    A3 = CVE_ALM
                                Case 4
                                    A4 = CVE_ALM
                                Case 5
                                    A5 = CVE_ALM
                                Case 6
                                    A6 = CVE_ALM
                                Case 7
                                    A7 = CVE_ALM
                                Case 8
                                    A8 = CVE_ALM
                                Case 9
                                    A9 = CVE_ALM
                                Case 10
                                    A10 = CVE_ALM
                                Case 11
                                    A11 = CVE_ALM
                                Case 12
                                    A12 = CVE_ALM
                                Case 13
                                    A13 = CVE_ALM
                                Case 14
                                    A14 = CVE_ALM
                                Case 15
                                    A15 = CVE_ALM
                                Case 16
                                    A16 = CVE_ALM
                                Case 17
                                    A17 = CVE_ALM
                                Case 18
                                    A18 = CVE_ALM
                                Case 19
                                    A19 = CVE_ALM
                                Case 20
                                    A20 = CVE_ALM
                            End Select
                        End If
                    Next
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDeCompras.mrt"
                Case "Compras por proveedor"

                    For row As Integer = 0 To C1List1.ListCount - 1
                        Dim cellValue As Object = C1List1.GetDisplayText(row, 0)

                        If C1List1.GetSelected(row) Then
                            CVE_ALM = cellValue.ToString
                            j = j + 1
                            Select Case CVE_ALM
                                Case 1
                                    A1 = CVE_ALM
                                Case 2
                                    A2 = CVE_ALM
                                Case 3
                                    A3 = CVE_ALM
                                Case 4
                                    A4 = CVE_ALM
                                Case 5
                                    A5 = CVE_ALM
                                Case 6
                                    A6 = CVE_ALM
                                Case 7
                                    A7 = CVE_ALM
                                Case 8
                                    A8 = CVE_ALM
                                Case 9
                                    A9 = CVE_ALM
                                Case 10
                                    A10 = CVE_ALM
                                Case 11
                                    A11 = CVE_ALM
                                Case 12
                                    A12 = CVE_ALM
                                Case 13
                                    A13 = CVE_ALM
                                Case 14
                                    A14 = CVE_ALM
                                Case 15
                                    A15 = CVE_ALM
                                Case 16
                                    A16 = CVE_ALM
                                Case 17
                                    A17 = CVE_ALM
                                Case 18
                                    A18 = CVE_ALM
                                Case 19
                                    A19 = CVE_ALM
                                Case 20
                                    A20 = CVE_ALM
                            End Select
                        End If
                    Next

                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportComprasXProveedor.mrt"
                Case "Salida de llantas por unidad"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSalidasDetalleLlantasXUni.mrt"
                Case "Detallado de ordenes de compra"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDetalladoOdeC.mrt"
                Case "Detallado compras"
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDetalladoCompras.mrt"
            End Select
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            Select Case NameRep
                Case "Existencia a una fecha"
                    'CVE_ART DESCR EXIST COSTO IMPORTE
                    DESPLEGAR()
                    StiReport1.RegData(DataSet1)

                Case "Compras por proveedor"
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value
                    If tCVE_PROV1.Text.Trim.Length > 0 And TCVE_PROV2.Text.Trim.Length > 0 Then
                        StiReport1.Item("PROV1") = tCVE_PROV1.Text
                        StiReport1.Item("PROV2") = TCVE_PROV2.Text
                    Else
                        If tCVE_PROV1.Text.Trim.Length > 0 And TCVE_PROV2.Text.Trim.Length = 0 Then
                            StiReport1.Item("PROV1") = tCVE_PROV1.Text
                            StiReport1.Item("PROV2") = "xxxxxxxxxxxx"
                        Else
                            If tCVE_PROV1.Text.Trim.Length = 0 And TCVE_PROV2.Text.Trim.Length > 0 Then
                                StiReport1.Item("PROV1") = ""
                                StiReport1.Item("PROV2") = TCVE_PROV2.Text
                            Else
                                StiReport1.Item("PROV1") = ""
                                StiReport1.Item("PROV2") = "xxxxxxxxxxxx"
                            End If
                        End If
                    End If

                    StiReport1.Item("ALM1") = A1
                    StiReport1.Item("ALM2") = A2
                    StiReport1.Item("ALM3") = A3
                    StiReport1.Item("ALM4") = A4
                    StiReport1.Item("ALM5") = A5
                    StiReport1.Item("ALM6") = A6
                    StiReport1.Item("ALM7") = A7
                    StiReport1.Item("ALM8") = A8
                    StiReport1.Item("ALM9") = A9
                    StiReport1.Item("ALM10") = A10
                    StiReport1.Item("ALM11") = A11
                    StiReport1.Item("ALM12") = A12
                    StiReport1.Item("ALM13") = A13
                    StiReport1.Item("ALM14") = A14
                    StiReport1.Item("ALM15") = A15
                    StiReport1.Item("ALM16") = A16
                    StiReport1.Item("ALM17") = A17
                    StiReport1.Item("ALM18") = A18
                    StiReport1.Item("ALM19") = A19
                    StiReport1.Item("ALM20") = A20
                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
                    StiReport1("P1") = tCVE_PROV1.Text
                    StiReport1("P2") = TCVE_PROV2.Text

                Case "Reporte de compras"

                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value

                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
                    StiReport1("UNIDAD") = tCVE_UNI.Text
                    StiReport1.Item("ALM1") = A1
                    StiReport1.Item("ALM2") = A2
                    StiReport1.Item("ALM3") = A3
                    StiReport1.Item("ALM4") = A4
                    StiReport1.Item("ALM5") = A5
                    StiReport1.Item("ALM6") = A6
                    StiReport1.Item("ALM7") = A7
                    StiReport1.Item("ALM8") = A8
                    StiReport1.Item("ALM9") = A9
                    StiReport1.Item("ALM10") = A10
                    StiReport1.Item("ALM11") = A11
                    StiReport1.Item("ALM12") = A12
                    StiReport1.Item("ALM13") = A13
                    StiReport1.Item("ALM14") = A14
                    StiReport1.Item("ALM15") = A15
                    StiReport1.Item("ALM16") = A16
                    StiReport1.Item("ALM17") = A17
                    StiReport1.Item("ALM18") = A18
                    StiReport1.Item("ALM19") = A19
                    StiReport1.Item("ALM20") = A20

                Case "Salida de llantas por unidad"
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value
                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
                    StiReport1("UNI1") = tCVE_UNI.Text
                    If tCVE_UNI.Text.Trim.Length > 0 Then
                        StiReport1("UNI2") = tCVE_UNI.Text
                    Else
                        StiReport1("UNI2") = "XXXXXXX"
                    End If
                    StiReport1("UNIDAD") = tCVE_UNI.Text

                Case "Detallado de ordenes de compra"
                    '====================================================================================================

                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value
                    StiReport1.Item("UNI1") = tCVE_UNI.Text.Trim
                    If tCVE_UNI.Text.Trim.Length > 0 Then
                        StiReport1.Item("UNI2") = tCVE_UNI.Text
                    Else
                        StiReport1.Item("UNI2") = "XXXXXXX"
                    End If
                    If tCVE_PROV1.Text.Trim.Length > 0 And TCVE_PROV2.Text.Trim.Length > 0 Then
                        StiReport1.Item("PROV1") = tCVE_PROV1.Text
                        StiReport1.Item("PROV2") = TCVE_PROV2.Text
                    Else
                        If tCVE_PROV1.Text.Trim.Length > 0 And TCVE_PROV2.Text.Trim.Length = 0 Then
                            StiReport1.Item("PROV1") = tCVE_PROV1.Text
                            StiReport1.Item("PROV2") = "xxxxxxxxxxxx"
                        Else
                            If tCVE_PROV1.Text.Trim.Length = 0 And TCVE_PROV2.Text.Trim.Length > 0 Then
                                StiReport1.Item("PROV1") = ""
                                StiReport1.Item("PROV2") = TCVE_PROV2.Text
                            Else
                                StiReport1.Item("PROV1") = ""
                                StiReport1.Item("PROV2") = "xxxxxxxxxxxx"
                            End If
                        End If
                    End If

                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
                    StiReport1("UNIDAD") = tCVE_UNI.Text
                    StiReport1("P1") = tCVE_PROV1.Text
                    StiReport1("P2") = TCVE_PROV2.Text
                    'RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportDetalladoOdeC.mrt"
                    '====================================================================================================
                Case "Detallado compras"
                    StiReport1.Item("F1") = F1.Value
                    StiReport1.Item("F2") = F2.Value

                    StiReport1.Item("UNI1") = tCVE_UNI.Text
                    If tCVE_UNI.Text.Trim.Length > 0 Then
                        StiReport1.Item("UNI2") = tCVE_UNI.Text
                    Else
                        StiReport1.Item("UNI2") = "xxxxxxxxxx"
                    End If
                    StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
                    StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
                    StiReport1("UNIDAD") = tCVE_UNI.Text

            End Select

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()
            StiReport1.Show()
            'StiReport1.Design()

            DataSet1.Clear()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Sub DESPLEGAR()
        Try
            Dim NUM_ALM As Integer, SUMA As Decimal = 0, COSTO_PROM_FIN As Decimal = 0
            Dim CVE_ART As String = "", DESCR As String = "", DESCR_ALM As String = ""
            Dim t As DataTable = DataSet1.Tables(0)
            Dim r As DataRow
            DataSet1.Clear()

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT M.CVE_ART, ISNULL(SUM(CANT * SIGNO),0) AS EXIS, ISNULL(MAX(I.DESCR),'') AS DES,
                        ISNULL(M.ALMACEN,1) AS CVE_ALM, ISNULL(MAX(A.DESCR),'') AS DESCR_ALM
                        FROM MINVE" & Empresa & " M
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                        LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = M.ALMACEN
                        WHERE M.FECHA_DOCU <= '" & FSQL(F1.Value) & "' AND I.TIPO_ELE = 'P'
                        GROUP BY M.ALMACEN, M.CVE_ART"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                CVE_ART = dr("CVE_ART")
                                DESCR = dr("DES")
                                NUM_ALM = dr("CVE_ALM")
                                DESCR_ALM = dr("DESCR_ALM")
                            Catch ex As Exception
                                Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            SUMA = 0 : COSTO_PROM_FIN = 0
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT M.CVE_ART, ISNULL(CANT * SIGNO,0) AS EXIS, ISNULL(COSTO_PROM_FIN,0) AS C_PROM_FIN 
                                    FROM MINVE" & Empresa & " M
                                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                                    LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = M.ALMACEN
                                    WHERE M.FECHA_DOCU <= '" & FSQL(F1.Value) & "' AND M.CVE_ART = '" & CVE_ART & "'
                                    ORDER BY FECHAELAB"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        Try
                                            SUMA += dr2("EXIS")
                                            COSTO_PROM_FIN = dr2("C_PROM_FIN")
                                        Catch ex As Exception
                                            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End While
                                End Using
                            End Using
                            Try
                                If SUMA > 0 Then
                                    r = t.NewRow()
                                    r("CVE_ART") = CVE_ART
                                    r("DESCR") = DESCR
                                    r("EXIST") = SUMA
                                    r("COSTO") = COSTO_PROM_FIN
                                    r("IMPORTE") = Math.Round(SUMA * COSTO_PROM_FIN, 6)
                                    r("NUM_ALM") = NUM_ALM
                                    r("ALMACEN") = DESCR_ALM
                                    r("FECHA") = F1.Value.ToString.Substring(0, 10)
                                    t.Rows.Add(r)
                                End If
                            Catch ex As Exception
                                Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
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
                    CboAlmacen.Focus()
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
End Class
