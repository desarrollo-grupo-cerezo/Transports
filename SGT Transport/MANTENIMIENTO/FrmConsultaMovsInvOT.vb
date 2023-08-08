Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmConsultaMovsInvOT
    Private Sub FrmConsultaMovsInvOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            SplitM.Dock = DockStyle.Fill

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

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmConsultaMovsInvOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Consulta movs. inv. OT")
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            Dim SUMA As Decimal = 0
            Fg.Redraw = False
            Me.Cursor = Cursors.WaitCursor
            Fg.Rows.Count = 1

            SQL = "SELECT P.CVE_ORD, M.REFER, ISNULL(O.CVE_UNI,'') AS CVE_TRAC, ISNULL(M.ALMACEN,0) AS CVE_ALM_ART, 
                ISNULL(TIEMPO_REAL,'') AS DOC_OT, P.DESCR,
                M.CVE_ART, M.CANT, M.COSTO, (M.CANT * M.COSTO * M.SIGNO) AS IMPORTE_M, O.FECHA, M.FECHA_DOCU
                FROM GCORDEN_TRA_SER_EXT P
                LEFT JOIN MINVE" & Empresa & " M ON M.CVE_ART = P.CVE_ART AND M.CVE_FOLIO = P.CVE_PROV
                LEFT JOIN COMPO" & Empresa & " F ON F.CVE_DOC = P.TIEMPO_REAL    
                LEFT JOIN GCORDEN_TRABAJO_EXT O ON O.CVE_ORD = P.CVE_ORD
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = O.CVE_UNI
                WHERE ISNULL(A_M,'') <> 'M' AND 
                M.FECHA_DOCU >= '" & FSQL(F1.Value) & "' AND M.FECHA_DOCU <= '" & FSQL(F2.Value) & "' AND 
                O.STATUS <> 'C' AND REFER LIKE '%OT' + P.CVE_ORD + '%'
                ORDER BY P.CVE_ORD"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("IMPORTE_M") < 0 Then
                            Fg.AddItem("" & vbTab & dr("CVE_ORD") & vbTab & dr("REFER") & vbTab & Math.Abs(dr("IMPORTE_M")) & vbTab & dr("FECHA") & vbTab &
                                       dr("FECHA_DOCU") & vbTab & dr("DESCR") & vbTab & dr("CANT") & vbTab &
                                       dr("COSTO") & vbTab & dr("CVE_ART") & vbTab & dr("CVE_ALM_ART"))
                            SUMA += Math.Abs(dr("IMPORTE_M"))
                        End If
                    End While
                End Using
                Fg.AddItem("" & vbTab & "" & vbTab & "TOTAL" & vbTab & SUMA)
                Fg.AutoSizeCols()

            End Using
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        Fg.Redraw = True

        MsgBox("Proceso terminado")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Consulta minve OT")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
