Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class frmServiciosXUnidadMinve
    Private Sub FrmServiciosXUnidadMinve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A' AND CVE_ALM <> 9"
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
    Private Sub FrmServiciosXUnidadMinve_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Servicios x unidad")
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim LINEA As String, j As Integer = 0
            Dim A1 As Integer = -1, A2 As Integer = -1, A3 As Integer = -1, A4 As Integer = -1, A5 As Integer = -1
            Dim A6 As Integer = -1, A7 As Integer = -1, A8 As Integer = -1, A9 As Integer = -1, A10 As Integer = -1
            Dim A11 As Integer = -1, A12 As Integer = -1, A13 As Integer = -1, A14 As Integer = -1, A15 As Integer = -1
            Dim A16 As Integer = -1, A17 As Integer = -1, A18 As Integer = -1, A19 As Integer = -1, A20 As Integer = -1
            Dim TRACTOR As Integer = -1, TANQUE As Integer = -1, DOLLY As Integer = -1, UTILITARIO As Integer = -1, CADENA_LINEAS As String
            Dim UNI2 As String, SUMA As Decimal = 0, CVE_ALM1 As Integer, SUM1 As Decimal = 0, MONTO As Decimal, REFER As String
            Dim CADENA2 As String
            Dim t As DataTable = DataSet1.Tables(0)
            Dim t2 As DataTable = DataSet1.Tables(1)
            Dim r As DataRow
            Dim r2 As DataRow

            DataSet1.Clear()

            CADENA_LINEAS = ""
            'LINEAS
            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                If C1List1.GetSelected(row) Then
                    LINEA = cellValue.ToString
                    CADENA_LINEAS = CADENA_LINEAS & LINEA & "','"
                    j = j + 1
                End If
            Next
            If j = 0 Then
                MsgBox("Por favor seleccione al menos una linea")
                tCVE_UNI.Select()
                Return
            End If

            If CADENA_LINEAS.Trim.Length > 0 Then
                CADENA_LINEAS = "'" & CADENA_LINEAS.Substring(0, CADENA_LINEAS.Length - 3) & "'"
            End If

            j = 0
            Dim CADENA_ALM As String = "", ALM As Integer, AALM(50) As Integer
            'ALAMCENES SELECCIONADOS
            For row As Integer = 0 To C1List2.ListCount - 1
                Dim cellValue As Object = C1List2.GetDisplayText(row, 0)
                Dim cellValue1 As Object = C1List2.GetDisplayText(row, 1)

                If C1List2.GetSelected(row) Then
                    ALM = cellValue.ToString
                    AALM(j) = ALM
                    j = j + 1
                    CADENA_ALM = CADENA_ALM & ALM & ","
                End If
            Next
            If j = 0 Then
                MsgBox("Por favor seleccione al menos un almacén")
                tCVE_UNI.Select()
                Return
            End If
            If CADENA_ALM.Trim.Length > 0 Then
                CADENA_ALM = CADENA_ALM.Substring(0, CADENA_ALM.Length - 1)
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
            If ChUtilitario.Checked Then
                UTILITARIO = 7
            End If
            If TRACTOR = -1 And TANQUE = -1 And DOLLY = -1 And UTILITARIO = -1 Then
                MsgBox("Por favor seleccione al menos un tipo de unidad")
                Return
            End If

            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            If tCVE_UNI.Text.Trim.Length > 0 Then
                UNI2 = tCVE_UNI.Text
            Else
                UNI2 = "XXXXXXX"
            End If

            CADENA2 = " FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND FECHA_DOCU <= '" & FSQL(F2.Value) & "'"

            SQL = "SELECT P.CVE_ORD, O.CVE_UNI AS CVE_TRAC, P.CVE_ART, I.DESCR AS DES, I.LIN_PROD, P.CANT, U.CVE_TIPO_UNI, 
                P.CVE_ALM, ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.IMPORTE AS IMPORT, A.DESCR AS DESCR_ALM,
                ISNULL((SELECT SUM(CANT * COSTO * SIGNO) FROM MINVE" & Empresa & " WHERE " & CADENA2 & " AND REFER LIKE '%OT' + P.CVE_ORD + '%' AND
                CVE_FOLIO = P.CVE_PROV),0) AS RESULT, P.IMPORTE
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
                LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.TIEMPO_REAL    
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.CVE_ALM
                WHERE ISNULL(A_M,'') <> 'M' AND O.STATUS <> 'C' AND O.FECHA >=  '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "' AND 
                O.CVE_UNI >= '" & tCVE_UNI.Text & "' AND O.CVE_UNI <= '" & UNI2 & "' AND 
                (ISNULL(L.CVE_LIN,'') in (" & CADENA_LINEAS & ") OR ISNULL(L.CVE_LIN,'') = '') AND 
                ISNULL(P.CVE_ALM,0) in (" & CADENA_ALM & ")  AND 
                (U.CVE_TIPO_UNI = " & TRACTOR & " OR U.CVE_TIPO_UNI = " & TANQUE & " OR 
                U.CVE_TIPO_UNI = " & DOLLY & " OR U.CVE_TIPO_UNI = " & UTILITARIO & ")
                ORDER BY O.CVE_UNI"

            SQL = "SELECT P.CVE_ORD, O.CVE_UNI AS CVE_TRAC, P.CVE_ART, I.DESCR AS DES, I.LIN_PROD, P.CANT, U.CVE_TIPO_UNI, 
                P.CVE_ALM, ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.IMPORTE AS IMPORT, A.DESCR AS DESCR_ALM, 
                (M.CANT * M.COSTO * M.SIGNO) AS IMPORTE_M, M.FECHA_DOCU, M.REFER, P.IMPORTE, O.FECHA
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN MINVE" & Empresa & " M ON M.CVE_ART = P.CVE_ART AND M.CVE_FOLIO = P.CVE_PROV
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = I.LIN_PROD
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.CVE_ALM
                WHERE ISNULL(A_M,'') <> 'M' AND O.STATUS <> 'C' AND M.FECHA_DOCU >=  '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' AND 
                O.CVE_UNI >= '" & tCVE_UNI.Text & "' AND O.CVE_UNI <= '" & UNI2 & "' AND 
                (ISNULL(L.CVE_LIN,'') in (" & CADENA_LINEAS & ") OR ISNULL(L.CVE_LIN,'') = '') AND 
                ISNULL(P.CVE_ALM,0) in (" & CADENA_ALM & ")  AND 
                (U.CVE_TIPO_UNI = " & TRACTOR & " OR U.CVE_TIPO_UNI = " & TANQUE & " OR 
                U.CVE_TIPO_UNI = " & DOLLY & " OR U.CVE_TIPO_UNI = " & UTILITARIO & ") AND REFER LIKE '%OT' + P.CVE_ORD + '%'
                ORDER BY O.CVE_UNI"

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            MONTO = Math.Abs(dr("IMPORTE_M"))

                            If MONTO > 0 Then

                                Try
                                    If dr("REFER").ToString.IndexOf("-") > -1 Then
                                        REFER = dr("REFER").ToString.Substring(0, dr("REFER").ToString.IndexOf("-"))
                                    Else
                                        REFER = dr("REFER")
                                    End If
                                Catch ex As Exception
                                    REFER = dr("REFER")
                                End Try

                                r = t.NewRow()
                                r("CVE_ORD") = REFER
                                r("CVE_TRAC") = dr("CVE_TRAC")
                                r("CVE_ART") = dr("CVE_ART")
                                r("LINEA") = dr("LIN_PROD")
                                r("CANT") = dr("CANT")
                                r("DESCR") = dr("DES") & " - " & dr("REFER")
                                r("CVE_ALM") = dr("CVE_ALM")
                                r("DESCR_ALM") = dr("DESCR_ALM")
                                r("DOC_OT") = dr("DOC_OT")
                                r("IMPORTE") = MONTO

                                'BACKUPTXT("SERVCIOMNATE", dr("CVE_ORD") & "," & Math.Abs(dr("RESULT")))
                                t.Rows.Add(r)
                                SUMA = SUMA + MONTO

                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            'RONOVADOS      164647.6031    164647.6031
            Try
                SQL = "SELECT MAX(CVE_UNI) AS CVEUNI, MAX(NUM_ALM) AS NUMALM, 
                    SUM(COSTO) AS COST, MAX(O1.DESCR) AS DES_DOC, MAX(O2.DESCR) AS DES_PAR
                    FROM GCGASTOS_RENOVADO G
                    LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = G.CVE_UNI 
                    LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                    LEFT JOIN GCOBS O2 ON O2.CVE_OBS = G.CVE_OBS_PAR
                    WHERE ISNULL(G.STATUS,'A') = 'A' AND FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' AND 
                    ISNULL(G.NUM_ALM,0) in (" & CADENA_ALM & ") 
                    GROUP BY CVE_UNI"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                CVE_ALM1 = dr("NUMALM")

                                r2 = t2.NewRow()
                                r2("CVE_UNI") = dr("CVEUNI")
                                r2("NUM_ALM") = CVE_ALM1
                                r2("COSTO") = dr("COST")
                                r2("DESCR") = dr("DES_DOC")
                                r2("DESCR_PAR") = dr("DES_PAR")
                                SUMA = SUMA + dr("COST")
                                t2.Rows.Add(r2)
                            Catch ex As Exception
                                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportServiXUniMinve.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1("Total") = SUMA

            StiReport1.Render()
            'StiReport1.Design()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Function ALMACEN_SELECCIOADO(FALM As Integer, FAALM() As Integer) As Boolean
        Dim Result As Boolean = False
        Try
            For k = 0 To FAALM.Count - 1
                If FAALM(k) > 0 Then
                    Result = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Result
    End Function
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
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
    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnUnidades_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
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
