Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmGastosManteXUni
    Private Sub FrmGastosManteXUni_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

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

            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmGastosManteXUni_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            Dim SUM_T1 As Decimal = 0, SUM_T23 As Decimal = 0, SUM_TOT1 As Decimal = 0, SUM_TOT23 As Decimal = 0
            Dim PAR_IMPORTE_T1 As Decimal = 0, PAR_IMPORTE_T23 As Decimal = 0, SUM_EXT1 As Decimal, SUM_EXT23 As Decimal
            Fg.Select()

            Fg.Rows.Count = 1
            'ORDENES DE TRABAJO INTERNAS
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CASE WHEN O.CVE_TIPO = 1 AND P.CVE_ART <> 'TOT' THEN P.IMPORTE ELSE 0 END AS SUM_T1, 
                        CASE WHEN (O.CVE_TIPO = 2 OR O.CVE_TIPO = 3) AND P.CVE_ART <> 'TOT' THEN (P.IMPORTE) ELSE 0 END AS SUM_T23
                        FROM GCORDEN_TRA_SER_EXT P
                        LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                        WHERE O.STATUS <> 'C' AND O.ESTATUS = 'AUTORIZADA' AND ISNULL(A_M,'') = '' AND 
                        O.FECHA >= '" & FSQL(F1.Value) & "' AND O.FECHA <= '" & FSQL(F2.Value) & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            SUM_T1 = SUM_T1 + dr("SUM_T1")
                            SUM_T23 = SUM_T23 + dr("SUM_T23")
                            'SUM_TOT1 = SUM_TOT1 + dr("SUM_TOT1")
                            'SUM_TOT23 = SUM_TOT23 + dr("SUM_TOT23")
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            'ORDENES DE COMPRA
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT P.CVE_ART, TRY_PARSE(ISNULL(O.CVE_TIPO,1) AS INT) AS TIPO_UNIDAD, PO.NUM_ALM, P.CVE_ALM, (PO.CANT * PO.COST) AS PAR_IMPORTE_T1 
                        FROM GCORDEN_TRA_SER_EXT P
                        LEFT JOIN PAR_COMPO" & Empresa & " PO ON  PO.CVE_DOC = P.TIEMPO_REAL
                        LEFT JOIN COMPO" & Empresa & " C ON C.CVE_DOC = PO.CVE_DOC
                        LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                        WHERE C.STATUS <> 'C' AND ISNULL(A_M,'') = 'M' AND (PO.CVE_ART = 'S1731' OR 
                        PO.NUM_ALM = 4 OR PO.NUM_ALM = 5 OR PO.NUM_ALM = 6 OR PO.NUM_ALM = 7 OR PO.NUM_ALM = 9 OR PO.NUM_ALM = 10) AND 
                        C.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND C.FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            If dr.ReadNullAsEmptyInteger("TIPO_UNIDAD") = 1 Then
                                SUM_EXT1 = SUM_EXT1 + dr.ReadNullAsEmptyDecimal("PAR_IMPORTE_T1")
                            Else
                                 SUM_EXT23 = SUM_EXT23 + dr.ReadNullAsEmptyDecimal("PAR_IMPORTE_T1")
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'ORDENES DE COMPRA RENOVADO
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT P.CVE_ART, P.NUM_ALM, (P.CANT * P.COST) AS PAR_IMPORTE_T1 
                        FROM PAR_COMPO" & Empresa & " P
                        LEFT JOIN COMPO" & Empresa & " C ON C.CVE_DOC = P.CVE_DOC
                        WHERE C.STATUS <> 'C' AND P.NUM_ALM = 10 AND 
                        C.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND C.FECHA_DOC <= '" & FSQL(F2.Value) & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            SUM_EXT1 = SUM_EXT1 + dr.ReadNullAsEmptyDecimal("PAR_IMPORTE_T1")
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Fg.AddItem("" & vbTab & "GASTO TOTAL DE MANTENIMINETO A TRACTORES" & vbTab & SUM_T1 + SUM_TOT1)
            Fg.AddItem("" & vbTab & "GASTO TOTAL DE MANTENIMINETO A TANQUES" & vbTab & SUM_T23 + SUM_TOT23)
            Fg.AddItem("" & vbTab & "GASTO TOTAL DE MANTENIMINETO A TRACTORES (LLANTAS Y RHINES)" & vbTab & SUM_EXT1)
            Fg.AddItem("" & vbTab & "GASTO TOTAL DE MANTENIMINETO A TANQUES (LLANTAS Y RHINES)" & vbTab & SUM_EXT23)

        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Repote gastos por mantenimiento de unidades")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
