Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Public Class FrmDetalladoComprasJulio
    Private CADENA As String
    Private N_TOP As String = "TOP 5000"
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmDetalladoComprasJulio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FrmDetalladoComprasJulio_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.WindowState = FormWindowState.Maximized
        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150
        Fg.Rows.Count = 1
        Fg.Cols.Count = 9

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

        TITULOS()

        Dim N = DateTime.Now.AddMonths(-1)
        Dim D1 As String, D2 As String

        D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
        D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

        F1.Value = d1
        F2.Value = d2

        CADENA = "WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"

        DESPLEGAR()

    End Sub
    Private Sub FrmDetalladoComprasJulio_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Resumen de compras")
        Me.Dispose()
    End Sub
    Sub DESPLEGAR()
        Try
            Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0
            Dim S5 As Decimal = 0, S6 As Decimal = 0

            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            SQL = "SELECT " & N_TOP & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.SU_REFER, C.FECHA_DOC, C.CAN_TOT, 
                C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.IMPORTE 
                FROM COMPC" & Empresa & " C
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                CADENA
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab &
                                       dr("SU_REFER") & vbTab & dr("FECHA_DOC") & vbTab & dr("CAN_TOT") & vbTab & dr("IMP_TOT1") & vbTab &
                                       dr("IMP_TOT2") & vbTab & dr("IMP_TOT3") & vbTab & dr("IMP_TOT4") & vbTab & dr("IMPORTE"))
                            S1 += dr("CAN_TOT")
                            S2 += dr("IMP_TOT1")
                            S3 += dr("IMP_TOT2")
                            S4 += dr("IMP_TOT3")
                            S5 += dr("IMP_TOT4")
                            S6 += dr("IMPORTE")
                        End While
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab &
                                   S2 & vbTab & S3 & vbTab & S4 & vbTab & S5 & vbTab & S6)
                    End Using
                End Using
            Catch SQLex As SqlException
                Dim SSS As SqlError, Sqlcadena As String = ""
                For Each SSS In SQLex.Errors
                    Sqlcadena += SSS.Message & vbNewLine
                Next
                BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()

            N_TOP = " TOP 5000 "

            LtNUm.Text = "Registros : " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("180. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        N_TOP = ""
        CADENA = "WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Resumen de compras")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click

        N_TOP = ""
        CADENA = ""
        DESPLEGAR()
    End Sub

    Sub TITULOS()

        Fg.Cols.Count = 12

        Fg(0, 1) = "Documento"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Proveedor"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Nombre"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Su refer."
        Dim c5 As Column = Fg.Cols(4)
        c5.DataType = GetType(String)

        Fg(0, 5) = "Fecha"
        Dim c6 As Column = Fg.Cols(5)
        c6.DataType = GetType(DateTime)

        Fg(0, 6) = "Sub. total"
        Dim c10 As Column = Fg.Cols(6)
        c10.DataType = GetType(Decimal)
        Fg.Cols(6).Format = "###,###,##0.00"

        Fg(0, 7) = "IEPS"
        Dim c11 As Column = Fg.Cols(7)
        c11.DataType = GetType(Decimal)
        Fg.Cols(7).Format = "###,###,##0.00"

        Fg(0, 8) = "Retención ISR"
        Dim c12 As Column = Fg.Cols(8)
        c12.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Retención IVA"
        Dim c13 As Column = Fg.Cols(9)
        c13.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 10) = "IVA"
        Dim c14 As Column = Fg.Cols(10)
        c14.DataType = GetType(Decimal)
        Fg.Cols(10).Format = "###,###,##0.00"

        Fg(0, 11) = "Importe"
        Dim c19 As Column = Fg.Cols(11)
        c19.DataType = GetType(Decimal)
        Fg.Cols(11).Format = "###,###,##0.00"
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportResumenCompras.mrt"

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
End Class
