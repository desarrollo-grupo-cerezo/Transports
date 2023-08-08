Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class frmServiciosXUnidad
    Private Sub frmServiciosXUnidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            C1List2.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A' AND (CVE_ALM <> 3)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List2.AddItem(dr("CVE_ALM") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using

            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_LIN, DESC_LIN FROM CLIN" & Empresa & " WHERE ISNULL(STATUS, 'A') = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_LIN") & ";" & dr("DESC_LIN") & Space(20))
                        i = i + 1
                    End While
                End Using
            End Using
            Me.C1List2.Splits(0).DisplayColumns(0).Width = 50
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'F1.Value = "01/08/2021"
        'F2.Value = "31/08/2021"
    End Sub
    Private Sub frmServiciosXUnidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Servicios x unidad")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim LINEA As String, DESCR As String, j As Integer = 0
            Dim L1 As String = "^8^", L2 As String = "^8^", L3 As String = "^8^", L4 As String = "^8^", L5 As String = "^8^"
            Dim L6 As String = "^8^", L7 As String = "^8^", L8 As String = "^8^", L9 As String = "^8^", L10 As String = "^8^"
            Dim L11 As String = "^8^", L12 As String = "^8^", L13 As String = "^8^", L14 As String = "^8^", L15 As String = "^8^"
            Dim L16 As String = "^8^", L17 As String = "^8^", L18 As String = "^8^", L19 As String = "^8^", L20 As String = "^8^"

            Dim L21 As String = "^8^", L22 As String = "^8^", L23 As String = "^8^", L24 As String = "^8^", L25 As String = "^8^"
            Dim L26 As String = "^8^", L27 As String = "^8^", L28 As String = "^8^", L29 As String = "^8^", L30 As String = "^8^"
            Dim L31 As String = "^8^", L32 As String = "^8^", L33 As String = "^8^", L34 As String = "^8^", L35 As String = "^8^"
            Dim L36 As String = "^8^", L37 As String = "^8^", L38 As String = "^8^", L39 As String = "^8^", L40 As String = "^8^"
            Dim A1 As Integer = -1, A2 As Integer = -1, A3 As Integer = -1, A4 As Integer = -1, A5 As Integer = -1
            Dim A6 As Integer = -1, A7 As Integer = -1, A8 As Integer = -1, A9 As Integer = -1, A10 As Integer = -1
            Dim A11 As Integer = -1, A12 As Integer = -1, A13 As Integer = -1, A14 As Integer = -1, A15 As Integer = -1
            Dim A16 As Integer = -1, A17 As Integer = -1, A18 As Integer = -1, A19 As Integer = -1, A20 As Integer = -1
            Dim TRACTOR As Integer = -1, TANQUE As Integer = -1, DOLLY As Integer = -1


            DESCR = "'"
            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                If C1List1.GetSelected(row) Then
                    LINEA = cellValue.ToString
                    'DESCR = cellValue1.ToString
                    DESCR = DESCR & LINEA & "','"
                    j = j + 1
                    Select Case j
                        Case 1
                            L1 = LINEA
                        Case 2
                            L2 = LINEA
                        Case 3
                            L3 = LINEA
                        Case 4
                            L4 = LINEA
                        Case 5
                            L5 = LINEA
                        Case 6
                            L6 = LINEA
                        Case 7
                            L7 = LINEA
                        Case 8
                            L8 = LINEA
                        Case 9
                            L9 = LINEA
                        Case 10
                            L10 = LINEA
                        Case 11
                            L11 = LINEA
                        Case 12
                            L12 = LINEA
                        Case 13
                            L13 = LINEA
                        Case 14
                            L14 = LINEA
                        Case 15
                            L15 = LINEA
                        Case 16
                            L16 = LINEA
                        Case 17
                            L17 = LINEA
                        Case 18
                            L18 = LINEA
                        Case 19
                            L19 = LINEA
                        Case 20
                            L20 = LINEA
                        Case 21
                            L21 = LINEA
                        Case 22
                            L22 = LINEA
                        Case 23
                            L23 = LINEA
                        Case 24
                            L24 = LINEA
                        Case 25
                            L25 = LINEA
                        Case 26
                            L26 = LINEA
                        Case 27
                            L27 = LINEA
                        Case 28
                            L28 = LINEA
                        Case 29
                            L29 = LINEA
                        Case 30
                            L30 = LINEA
                        Case 31
                            L31 = LINEA
                        Case 32
                            L32 = LINEA
                        Case 33
                            L33 = LINEA
                        Case 34
                            L34 = LINEA
                        Case 35
                            L35 = LINEA
                        Case 36
                            L36 = LINEA
                        Case 37
                            L37 = LINEA
                        Case 38
                            L38 = LINEA
                        Case 39
                            L39 = LINEA
                        Case 40
                            L40 = LINEA

                    End Select
                End If
            Next
            If j = 0 Then
                MsgBox("Por favor seleccione al menos una linea")
                tCVE_UNI.Select()
                Return
            End If
            j = 0
            DESCR = DESCR & "'---"
            For row As Integer = 0 To C1List2.ListCount - 1
                Dim cellValue As Object = C1List2.GetDisplayText(row, 0)
                Dim cellValue1 As Object = C1List2.GetDisplayText(row, 1)

                If C1List2.GetSelected(row) Then
                    LINEA = cellValue.ToString
                    DESCR = DESCR & LINEA & ","
                    j = j + 1
                    Select Case Val(LINEA)
                        Case 1
                            A1 = LINEA
                        Case 2
                            A2 = LINEA
                        Case 3
                            A3 = LINEA
                        Case 4
                            A4 = LINEA
                        Case 5
                            A5 = LINEA
                        Case 6
                            A6 = LINEA
                        Case 7
                            A7 = LINEA
                        Case 8
                            A8 = LINEA
                        Case 9
                            A9 = LINEA
                        Case 10
                            A10 = LINEA
                        Case 11
                            A11 = LINEA
                        Case 12
                            A12 = LINEA
                        Case 13
                            A13 = LINEA
                        Case 14
                            A14 = LINEA
                        Case 15
                            A15 = LINEA
                        Case 16
                            A16 = LINEA
                        Case 17
                            A17 = LINEA
                        Case 18
                            A18 = LINEA
                        Case 19
                            A19 = LINEA
                        Case 20
                            A20 = LINEA
                    End Select
                End If
            Next
            If j = 0 Then
                MsgBox("Por favor seleccione al menos un almacén")
                tCVE_UNI.Select()
                Return
            End If
            If ChTractor.Checked Then
                TRACTOR = 1
            End If
            If ChTanque.Checked Then
                TANQUE = 2
            End If
            If ChDolly.Checked Then
                DOLLY = 3
            End If
            If TRACTOR = -1 And TANQUE = -1 And DOLLY = -1 Then
                MsgBox("Por favor seleccione al menos un tipo de unidad")
                Return
            End If

            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportServiciosXUnidad.mrt"
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

            StiReport1.Item("UNI1") = tCVE_UNI.Text
            If tCVE_UNI.Text.Trim.Length > 0 Then
                StiReport1.Item("UNI2") = tCVE_UNI.Text
            Else
                StiReport1.Item("UNI2") = "XXXXXXX"
            End If
            StiReport1.Item("L1") = L1
            StiReport1.Item("L2") = L2
            StiReport1.Item("L3") = L3
            StiReport1.Item("L4") = L4
            StiReport1.Item("L5") = L5
            StiReport1.Item("L6") = L6
            StiReport1.Item("L7") = L7
            StiReport1.Item("L8") = L8
            StiReport1.Item("L9") = L9
            StiReport1.Item("L10") = L10
            StiReport1.Item("L11") = L11
            StiReport1.Item("L12") = L12
            StiReport1.Item("L13") = L13
            StiReport1.Item("L14") = L14
            StiReport1.Item("L15") = L15
            StiReport1.Item("L16") = L16
            StiReport1.Item("L17") = L17
            StiReport1.Item("L18") = L18
            StiReport1.Item("L19") = L19
            StiReport1.Item("L20") = L20

            StiReport1.Item("L21") = L21
            StiReport1.Item("L22") = L22
            StiReport1.Item("L23") = L23
            StiReport1.Item("L24") = L24
            StiReport1.Item("L25") = L25
            StiReport1.Item("L26") = L26
            StiReport1.Item("L27") = L27
            StiReport1.Item("L28") = L28
            StiReport1.Item("L29") = L29
            StiReport1.Item("L30") = L30
            StiReport1.Item("L31") = L31
            StiReport1.Item("L32") = L32
            StiReport1.Item("L33") = L33
            StiReport1.Item("L34") = L34
            StiReport1.Item("L35") = L35
            StiReport1.Item("L36") = L36
            StiReport1.Item("L37") = L37
            StiReport1.Item("L38") = L38
            StiReport1.Item("L39") = L39
            StiReport1.Item("L40") = ""

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


            StiReport1.Item("TRACTOR") = TRACTOR
            StiReport1.Item("TANQUE") = TANQUE
            StiReport1.Item("DOLLY") = DOLLY

            StiReport1("F3") = F1.Value.ToString.Substring(0, 10)
            StiReport1("F4") = F2.Value.ToString.Substring(0, 10)
            StiReport1("UNIDAD") = tCVE_UNI.Text
            '================================================================================================
            '================================================================================================
            '================================================================================================
            '================================================================================================

            'GASTOS RENOVADOS
            StiReport1.Item("GF1") = F1.Value
            StiReport1.Item("GF2") = F2.Value

            StiReport1.Item("GUNI1") = tCVE_UNI.Text
            If tCVE_UNI.Text.Trim.Length > 0 Then
                StiReport1.Item("GUNI2") = tCVE_UNI.Text
            Else
                StiReport1.Item("GUNI2") = "XXXXXXX"
            End If
            StiReport1.Item("GL1") = L1
            StiReport1.Item("GL2") = L2
            StiReport1.Item("GL3") = L3
            StiReport1.Item("GL4") = L4
            StiReport1.Item("GL5") = L5
            StiReport1.Item("GL6") = L6
            StiReport1.Item("GL7") = L7
            StiReport1.Item("GL8") = L8
            StiReport1.Item("GL9") = L9
            StiReport1.Item("GL10") = L10
            StiReport1.Item("GL11") = L11
            StiReport1.Item("GL12") = L12
            StiReport1.Item("GL13") = L13
            StiReport1.Item("GL14") = L14
            StiReport1.Item("GL15") = L15
            StiReport1.Item("GL16") = L16
            StiReport1.Item("GL17") = L17
            StiReport1.Item("GL18") = L18
            StiReport1.Item("GL19") = L19
            StiReport1.Item("GL20") = L20

            StiReport1.Item("GL21") = L21
            StiReport1.Item("GL22") = L22
            StiReport1.Item("GL23") = L23
            StiReport1.Item("GL24") = L24
            StiReport1.Item("GL25") = L25
            StiReport1.Item("GL26") = L26
            StiReport1.Item("GL27") = L27
            StiReport1.Item("GL28") = L28
            StiReport1.Item("GL29") = L29
            StiReport1.Item("GL30") = L30
            StiReport1.Item("GL31") = L31
            StiReport1.Item("GL32") = L32
            StiReport1.Item("GL33") = L33
            StiReport1.Item("GL34") = L34
            StiReport1.Item("GL35") = L35
            StiReport1.Item("GL36") = L36
            StiReport1.Item("GL37") = L37
            StiReport1.Item("GL38") = L38
            StiReport1.Item("GL39") = L39
            StiReport1.Item("GL40") = ""

            StiReport1.Item("GALM1") = A9

            StiReport1.Item("GTRACTOR") = TRACTOR
            StiReport1.Item("GTANQUE") = TANQUE
            StiReport1.Item("GDOLLY") = DOLLY

            StiReport1("GF3") = F1.Value.ToString.Substring(0, 10)
            StiReport1("GF4") = F2.Value.ToString.Substring(0, 10)
            StiReport1("GUNIDAD") = tCVE_UNI.Text
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

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var3
                L2.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
                    L2.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    L2.Text = ""
                    tCVE_UNI.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboAlmacen_DropDownClosed(sender As Object, e As DropDownClosedEventArgs)
        Try
            tCVE_UNI.Select()
        Catch ex As Exception
        End Try
    End Sub
End Class
