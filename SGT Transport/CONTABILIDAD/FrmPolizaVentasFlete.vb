Imports C1.Win.C1Themes
Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient

Public Class FrmPolizaVentasFlete

    Private RUTA_MODELO As String = ""
    Private Sub FrmPolizaVentasFlete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

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

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height
            Fg.Height = Me.Height - Panel1.Height - Panel1.Height

            Fg.Cols.Count = 17
            Fg.Rows.Count = 1
            Fg(0, 1) = "Fecha Factura"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)
            c1.Name = "FechaFactura"

            Fg(0, 2) = "Factura"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)
            c2.Name = "Factura"

            Fg(0, 3) = "Tipo Facturacion"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)
            c3.Name = "TipoFacturacion"

            Fg(0, 4) = "Fecha Viaje"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)
            c4.Name = "FechaViaje"

            Fg(0, 5) = "Viaje"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)
            c5.Name = "Viaje"

            Fg(0, 6) = "Formato Columnas Importes"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)
            c6.Name = "Formato"

            Fg(0, 7) = "Orden"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)
            c7.Name = "Orden"

            Fg(0, 8) = "Tipo Póliza"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)
            c8.TextAlignFixed = TextAlignEnum.CenterCenter
            c8.Name = "TipoPoliza"

            Fg(0, 9) = "Núm. Póliza / No. Cuenta"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)
            c9.TextAlignFixed = TextAlignEnum.CenterCenter
            c9.Name = "NumPoliza"

            Fg(0, 10) = "Concepto Póliza  / Depto."
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)
            c10.TextAlignFixed = TextAlignEnum.CenterCenter
            c10.Name = "Concepto"

            Fg(0, 11) = "Fecha / Concepto Mov."
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)
            c11.TextAlignFixed = TextAlignEnum.CenterCenter
            c11.Name = "Mov"

            Fg(0, 12) = "Tipo de Cambio"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)
            c12.TextAlignFixed = TextAlignEnum.CenterCenter
            c12.Name = "TipoCambio"

            Fg(0, 13) = "Debe"
            Dim c13 As Column = Fg.Cols(13)
            'c13.DataType = GetType(Decimal)
            'c13.Format = "###,###,##0.00"
            c13.TextAlignFixed = TextAlignEnum.CenterCenter
            c13.TextAlign = TextAlignEnum.RightCenter
            c13.Name = "Debe"

            Fg(0, 14) = "Haber"
            Dim c14 As Column = Fg.Cols(14)
            'c14.DataType = GetType(Decimal)
            'c14.Format = "###,###,##0.00"
            c14.TextAlignFixed = TextAlignEnum.CenterCenter
            c14.TextAlign = TextAlignEnum.RightCenter
            c14.Name = "Haber"

            Fg(0, 15) = "Centro de Costos"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)
            c15.TextAlignFixed = TextAlignEnum.CenterCenter
            c15.TextAlign = TextAlignEnum.RightCenter
            c15.Name = "CC"

            Fg(0, 16) = "Proyecto"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)
            c16.TextAlignFixed = TextAlignEnum.CenterCenter
            c16.Name = "Proyecto"

            GET_RUTA_MODELO()

            Fg.Cols(1).Visible = False
            Fg.Cols(2).Visible = False
            Fg.Cols(3).Visible = False
            Fg.Cols(4).Visible = False
            Fg.Cols(5).Visible = False
            Fg.Cols(6).Visible = False
            Fg.Cols(7).Visible = False


            TPOLIZA.Text = "Poliza ventas flete " & DateTime.Now.ToString("MMMM")

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaVentasFlete_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Poliza ventas flete")
    End Sub

    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Dim Debe As Decimal, Haber As Decimal
        Dim Filtro As String
        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black
        NewStyle1.DataType = GetType(Decimal)
        NewStyle1.Format = "###,###,##0.00"

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Red
        NewStyle2.ForeColor = Color.White
        NewStyle2.DataType = GetType(Decimal)
        NewStyle2.Format = "###,###,##0.00"

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Fg.Focus()

        Fg.Rows.Count = 1
        Fg.Redraw = False

        Filtro = String.Format("WHERE {0} BETWEEN '{1:yyyyMMdd}' AND '{2:yyyyMMdd}'", IIf(RadFechaCarga.Checked, "FechaViaje", "FechaFactura"), F1.Value, F2.Value)

        Try
            SQL = String.Format("SELECT FechaFactura, Factura, TipoFacturacion, FechaViaje, Viaje, FormatoColumnasImportes, Orden, TipoPoliza, NoPolizaCuenta, ConceptoPolizaDepto, DiaConceptoMov, TipoCambio, Debe, Haber, CentroCostos, Proyecto
                   FROM VT_CTB_POLIZA_FACTURAS {0} ORDER BY FechaFactura, Factura, Orden", Filtro)
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " ")
                    Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " ")
                    While dr.Read


                        Try

                            Fg.AddItem("" & vbTab & dr("FechaFactura") & vbTab & dr("Factura") & vbTab & dr("TipoFacturacion") & vbTab & dr("FechaViaje") & vbTab &
                                       dr("Viaje") & vbTab & dr("FormatoColumnasImportes") & vbTab & dr("Orden") & vbTab & dr("TipoPoliza") & vbTab & dr("NoPolizaCuenta") & vbTab &
                                       dr("ConceptoPolizaDepto") & vbTab & dr("DiaConceptoMov") & vbTab & dr("TipoCambio") & vbTab & dr("Debe") & vbTab & dr("Haber") & vbTab &
                                       dr("CentroCostos") & vbTab & dr("Proyecto"))

                            If dr("Orden").ToString().Equals("2") Or dr("Orden").ToString().Equals("6") Then
                                Debe += Convert.ToDecimal(dr("Debe").ToString().Replace(",", ""))
                            End If
                            If dr("Orden").ToString().Equals("7") Or dr("Orden").ToString().Equals("8") Then
                                Haber += Convert.ToDecimal(dr("Haber").ToString().Replace(",", ""))
                            End If

                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using
            Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & "99" & vbTab & " " & vbTab & " " & vbTab &
                                       " " & vbTab & " " & vbTab & " " & vbTab & String.Format("{0:n4}", Debe) & vbTab & String.Format("{0:n4}", Haber) & vbTab &
                                       " " & vbTab & " ")
            Fg.SetCellStyle(Fg.Rows.Count - 1, 13, IIf(Debe = Haber, NewStyle1, NewStyle2))
            Fg.SetCellStyle(Fg.Rows.Count - 1, 14, IIf(Debe = Haber, NewStyle1, NewStyle2))
            Fg.AutoSizeCols()

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default

        MsgBox("Proceso terminado")

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            Fg.FilterDefinition = "<ColumnFilters><ColumnFilter ColumnIndex='6' ColumnName='Orden' DataType='System.String'><ConditionFilter AndConditions='True'><Condition Operator='DoesNotContain' Parameter='99' /></ConditionFilter></ColumnFilter></ColumnFilters>"
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Poliza ventas flete", True)
            Fg.FilterDefinition = ""
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPOLIZA.KeyPress

        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub

    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub


End Class
