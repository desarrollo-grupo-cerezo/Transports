Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports Stimulsoft.Report

Public Class FrmCobEfecClie
    Private Sub FrmCobEfecClie_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

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

            SplitM1.Dock = DockStyle.Fill
            Fg.BringToFront()
            Fg.Dock = DockStyle.Fill

            Fg.Cols(1).Width = 80
            Fg.Cols(2).Width = 80
            Fg.Cols(3).Width = 80
            Fg.Cols(4).Width = 80
            Fg.Cols(5).Width = 80
            Fg.Cols(6).Width = 80
            Fg.Cols(7).Width = 120
            Fg.Cols(8).Width = 280

            Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
            Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
            Fg.Styles.Normal.WordWrap = False

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2

            If PASS_GRUPOCE.ToUpper <> "BUS" And PASS_GRUPOCE.ToUpper <> "BR3FRAJA" Then
                BarDiseñador.Visible = False
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmCobEfecClie_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Cobranza efectuada por cliente")
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Dim CADENA As String, CLIENTE As String, CLAVE As String = ""
        Dim S1 As Decimal, S2 As Decimal, S3 As Decimal
        Dim SM1 As Decimal, SM2 As Decimal, SM3 As Decimal

        Fg.Rows.Count = 1
        Cursor.Current = Cursors.Default
        Fg.Redraw = False
        Fg.BeginUpdate()

        Try
            If TCLIENTE1.Text.Trim.Length > 0 And TCLIENTE2.Text.Trim.Length > 0 Then
                CLIENTE = " AND M.CVE_CLIE >= '" & TCLIENTE1.Text & "' AND M.CVE_CLIE <= '" & TCLIENTE2.Text & "'"
            Else
                If TCLIENTE1.Text.Trim.Length > 0 And TCLIENTE2.Text.Trim.Length = 0 Then
                    CLIENTE = " AND M.CVE_CLIE >= '" & TCLIENTE1.Text & "'"
                Else
                    If TCLIENTE1.Text.Trim.Length = 0 And TCLIENTE2.Text.Trim.Length > 0 Then
                        CLIENTE = " AND M.CVE_CLIE <= '" & TCLIENTE2.Text & "'"
                    Else
                        CLIENTE = ""
                    End If
                End If
            End If

            CADENA = " AND (M.IMPORTE * M.SIGNO) + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " 
                    WHERE CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO AND REFER = M.REFER),0) > 1 "

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT M.CVE_CLIE, C.NOMBRE, M.FECHA_APLI, M.IMPORTE, D.IMPORTE, D.DOCTO, CFD.UUID_CFDI, M.REFER,
                    ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO And SIGNO = -1 And REFER = M.REFER),0) As CARGOS, 
                    ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND ID_MOV = M.NUM_CPTO And SIGNO = 1 AND REFER = M.REFER),0) As ABONOS
                    FROM CUEN_M" & Empresa & " M
                    LEFT JOIN CLIE" & Empresa & " C ON M.CVE_CLIE = C.CLAVE
                    LEFT JOIN CUEN_DET" & Empresa & " D ON M.CVE_CLIE = D.CVE_CLIE AND M.REFER = D.REFER AND M.NUM_CPTO = D.NUM_CARGO
                    LEFT JOIN CFDI CFD ON M.REFER = CFD.FACTURA
                    WHERE D.FECHA_APLI >= '" & FSQL(F1.Value) & "' AND D.FECHA_APLI <= '" & FSQL(F2.Value) & "' " & CADENA & CLIENTE & "
                    ORDER BY M.CVE_CLIE, M.REFER"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If CLAVE <> dr("CVE_CLIE") Then
                            If S1 > 0 Then
                                Fg.AddItem("" & vbTab & "" & vbTab & Nothing & vbTab & "" & vbTab & S1 & vbTab & S2 & vbTab & S3)
                                S1 = 0 : S2 = 0 : S3 = 0
                            End If
                            Fg.AddItem("" & vbTab & BUSCA_CAT("Cliente", dr("CVE_CLIE")))
                        End If

                        Fg.AddItem("" & vbTab & dr("CVE_CLIE") & vbTab & dr("FECHA_APLI") & vbTab & dr("REFER") & vbTab & dr("IMPORTE") & vbTab &
                                   Math.Abs(dr("CARGOS") + dr("ABONOS")) & vbTab & dr("IMPORTE") + (dr("CARGOS") + dr("ABONOS")) & vbTab &
                                   dr("DOCTO") & vbTab & dr("UUID_CFDI"))
                        S1 += dr("IMPORTE")
                        S2 += Math.Abs(dr("CARGOS") + dr("ABONOS"))
                        S3 += dr("IMPORTE") + (dr("CARGOS") + dr("ABONOS"))

                        SM1 += dr("IMPORTE")
                        SM2 += Math.Abs(dr("CARGOS") + dr("ABONOS"))
                        SM3 += dr("IMPORTE") + (dr("CARGOS") + dr("ABONOS"))

                        CLAVE = dr("CVE_CLIE")
                    End While
                End Using
                Fg.AddItem("" & vbTab & "" & vbTab & Nothing & vbTab & "" & vbTab & SM1 & vbTab & SM2 & vbTab & SM3)
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Cursor.Current = Cursors.Default
        Fg.Redraw = True
        Fg.EndUpdate()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Cobranza efectuada por cliente")
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnClie1_Click(sender As Object, e As EventArgs) Handles BtnClie1.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
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
            FrmSelItem.ShowDialog()
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
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String, j As Integer = 0, NOMBRE1 As String, NOMBRE2 As String
            Dim Report1 As New StiReport

            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportCobEfecClie.mrt"
            If Not IO.File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            Report1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            Report1.Dictionary.Databases.Clear()
            Report1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
            Report1.Compile()
            Report1.Dictionary.Synchronize()
            Report1.ReportName = Me.Text
            Report1("F1") = FSQL(F1.Value)
            Report1("F2") = FSQL(F2.Value)

            If TCLIENTE1.Text.Trim.Length > 0 Then
                Report1("CLIENTE1") = TCLIENTE1.Text
            Else
                Report1("CLIENTE1") = ""
            End If

            If TCLIENTE2.Text.Trim.Length > 0 Then
                Report1("CLIENTE2") = TCLIENTE2.Text
            Else
                Report1("CLIENTE2") = "zzzzzzzzzzzz"
            End If

            Report1.Render()
            VisualizaReporte(Report1)

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub

    Private Sub BarDiseñador_Click(sender As Object, e As ClickEventArgs) Handles BarDiseñador.Click
        PrinterMRT("ReportCobEfecClie")
    End Sub
End Class