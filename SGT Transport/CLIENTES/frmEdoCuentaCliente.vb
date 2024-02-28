Imports System.IO
Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmEdoCuentaCliente
    Private CADENA As String = ""

    Private Sub FrmEdoCuentaCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        'Fg.Tree.Column = 1
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

        Catch ex As Exception
        End Try

        'LtSaldo.Text = Format(Var49, "###,###,###,##0.00")

        SplitP.Dock = DockStyle.Fill

        SplitP.SplitterWidth = 1

        Fg.Rows.Count = 1
        Fg.Height = Me.Height - 175

        Fg.Tree.Column = 1
        Fg.Tree.Show(1)

        Fg.Tree.Style = TreeStyleFlags.Complete ' .SimpleLeaf
        Fg.Tree.LineColor = Color.DarkBlue

        Fg.Cols(1).AllowEditing = True
        Fg.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None
        Fg.Styles.Normal.TextAlign = TextAlignEnum.LeftCenter
        Fg.Styles.Normal.WordWrap = False

        Fg.Rows(0).Height = 40
        Fg.Cols(2).Visible = False
        Fg.Cols(10).Visible = False
        Fg.Cols(11).Visible = False
        Fg.Cols(12).Visible = False


        ' Establecer el tamaño de estrella para las columnas
        Fg.Cols(1).StarWidth = "2*" 'DOCUMENTO
        'Fg.Cols(2).StarWidth = "*"'CLIENTE
        Fg.Cols(3).StarWidth = "2*" 'CONCEPTO
        Fg.Cols(4).StarWidth = "2*" 'NUM
        Fg.Cols(5).StarWidth = "*" 'FECHA APLI
        Fg.Cols(6).StarWidth = "*" 'FECHA VENC
        Fg.Cols(7).StarWidth = "*" 'ABONO
        Fg.Cols(8).StarWidth = "*" 'SALDO
        ' Establecer la propiedad MinWidth para evitar que la columna se vuelva demasiado estrecha
        Fg.Cols(1).MinWidth = 120

        ' Create style used to show negative values.
        'Fg.Styles.Add("Red").ForeColor = Color.Red
        ' Create style used to show values >= 1000.
        'Fg.Styles.Add("Yellow").ForeColor = Color.RosyBrown
        'Fg.Styles.Add("Blue").ForeColor = Color.Blue
        'Fg.Styles.Add("Magenta").ForeColor = Color.Magenta
        'Fg.Styles.Add("Gold").ForeColor = Color.Brown


        ' Enable OwnerDraw by setting the DrawMode property.
        Fg.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw

        LtClave.Text = Var4
        LtNombre.Text = Var5

        CADENA = ""
        DESPLEGAR()


    End Sub
    Sub DESPLEGAR()
        Dim IMPORTE As Decimal, SALDO As Decimal, Level As Integer = 0, i As Integer, CADENA_SALDO As String
        Dim r As Row, REFER As String, SIGUE As Boolean, ABONOS As Decimal = 0
        Dim t As DataTable = DataSet1.Tables(0)
        Dim r2 As DataRow

        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        DataSet1.Clear()

        Try
            If chSaldo.Checked Then
                CADENA_SALDO = " AND M.IMPORTE + ISNULL((SELECT SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " 
                            WHERE CVE_CLIE = M.CVE_CLIE AND REFER = M.REFER),0) > 0.1 "
            Else
                CADENA_SALDO = ""
            End If

            SQL = "SELECT M.CVE_CLIE, E.NOMBRE, CALLE, NUMEXT, CODIGO, E.RFC, LIMCRED, DIASCRED, SALDO, CLASIFIC, M.REFER, 
                (M.IMPORTE * M.SIGNO) AS IMPORTE_M, M.NUM_CPTO As CPTO_M, C.DESCR AS DESCR_CONCEP_M, M.NO_FACTURA As NO_FAC_M,
                D.NO_FACTURA As NO_FAC_D, M.DOCTO As DOCTO_M, D.DOCTO As DOCTO_D, M.NUM_CARGO As NUM_CARGO_M, M.FECHA_APLI As FAPLI_M,
                M.FECHA_VENC As FVENC_M, M.SIGNO As SIGNO_M, ISNULL(D.NO_PARTIDA,0) AS NO_PAR,
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND SIGNO = -1 And REFER = M.REFER),0) As ABONOS, 
                ISNULL((Select SUM(IMPORTE*SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE AND SIGNO = 1 AND REFER = M.REFER),0) As CARGOS,
                ISNULL(D.FECHA_APLI,'') AS F_APLI_D, ISNULL(D.FECHA_VENC,'') AS F_VENC_D, ISNULL(D.SIGNO,1) As SIGNO_D, 
                ISNULL((D.IMPORTE * D.SIGNO),0) AS IMPORTE_D, ISNULL(D.NUM_CPTO,0) As CPTO_D, ISNULL(C2.DESCR,'') As DES_CONC_D
                FROM CUEN_M" & Empresa & " M
                LEFT JOIN CFDI ON CFDI.FACTURA = M.REFER
                LEFT JOIN CLIE" & Empresa & " E ON E.CLAVE = M.CVE_CLIE
                LEFT JOIN CUEN_DET" & Empresa & " D On M.CVE_CLIE = D.CVE_CLIE And M.REFER = D.REFER And M.NUM_CPTO = D.ID_MOV And M.NUM_CARGO = D.NUM_CARGO
                LEFT JOIN CONC" & Empresa & " C On C.NUM_CPTO = M.NUM_CPTO
                LEFT JOIN CONC" & Empresa & " C2 On C2.NUM_CPTO = D.NUM_CPTO
                WHERE M.CVE_CLIE = '" & Var4 & "' AND ISNULL(CFDI.ESTATUS,'A') <> 'C'
                " & CADENA_SALDO & CADENA & "
                ORDER BY M.REFER, M.FECHA_APLI"

            Fg.AddItem("" & vbTab)
            Dim row As Row
            row = Fg.Rows(Fg.Rows.Count - 1)
            row.IsNode = True

            Dim nd As Node
            nd = row.Node
            nd.Level = Level
            REFER = ""
            SIGUE = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Level = 1
                    i = 1
                    Fg.Rows.Count = 1
                    While dr.Read
                        Try
                            If REFER <> dr("REFER") Or SIGUE Then
                                SIGUE = False
                                Try
                                    Fg.AddItem("" & vbTab & dr("REFER") & vbTab & "" & vbTab & dr("DESCR_CONCEP_M") & vbTab & dr("NO_FAC_M") & vbTab &
                                       dr("FAPLI_M") & vbTab & dr("FVENC_M") & vbTab & Format(dr("IMPORTE_M"), "###,###,###,##0.00") & vbTab & "" & vbTab &
                                       Format((CDec(dr("IMPORTE_M")) + CDec(dr("ABONOS")) + CDec(dr("CARGOS"))), "###,###,###,##0.00"))

                                Catch ex As Exception
                                End Try


                                r2 = t.NewRow()
                                r2("CLIENTE") = dr("CVE_CLIE")
                                r2("NOMBRE") = dr("NOMBRE")
                                r2("CALLE") = "Calle " & dr("CALLE") & ", " & dr("NUMEXT")
                                r2("CP") = dr("CODIGO")
                                r2("RFC") = dr("RFC")
                                r2("CLASIFICACION") = dr("CLASIFIC")
                                r2("DIAS_CREDITO") = dr("DIASCRED")
                                r2("LIMITE_CREDITO") = dr("LIMCRED")
                                r2("SALDO_GEN") = dr("SALDO")
                                r2("CLAVE") = dr("CVE_CLIE")
                                r2("CVE_DOC") = dr("REFER")
                                r2("NUM") = "1"
                                r2("FECHA_APLI") = dr("FAPLI_M")
                                r2("FECHA_VENC") = dr("FVENC_M")
                                r2("CARGOS") = dr("IMPORTE_M")
                                r2("ABONOS") = dr("ABONOS") + dr("CARGOS")
                                r2("SALDO") = (dr("IMPORTE_M") + dr("ABONOS") + dr("CARGOS"))
                                t.Rows.Add(r2)

                                IMPORTE += dr("IMPORTE_M")
                                ABONOS += dr("ABONOS") + dr("CARGOS")
                                SALDO += dr("IMPORTE_M") + dr("ABONOS")

                                r = Fg.Rows(Fg.Rows.Count - 1)
                                r.IsNode = True
                                If Not IsNothing(r.Node) Then
                                    r.Node.Level = 0
                                End If
                                Fg.AddItem("" & vbTab & "Documento" & vbTab & "Concepto" & vbTab & "Forma de pago" & vbTab &
                                    "Documento de abono" & vbTab & "Fecha de abono" & vbTab & "fecha venc." & vbTab & "Importe" & vbTab &
                                    "folio" & vbTab & "Estatus" & vbTab & "10" & vbTab & "11")

                                Dim NewStyle1 As CellStyle
                                NewStyle1 = Fg.Styles.Add("NewStyle1")
                                NewStyle1.BackColor = Color.SkyBlue
                                NewStyle1.ForeColor = Color.Black
                                Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1

                                For k = 1 To Fg.Cols.Count - 1
                                    Fg.Styles.Focus.Border.Color = Color.Red
                                    Fg.Styles.Focus.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Fillet
                                    Fg.GetCellRange(Fg.Rows.Count - 1, k).StyleNew.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Groove
                                    Fg.GetCellRange(Fg.Rows.Count - 1, k).StyleNew.Border.Color = Color.Gray
                                Next
                                r = Fg.Rows(Fg.Rows.Count - 1)
                                r.IsNode = False
                                If Not IsNothing(r.Node) Then
                                    r.Node.Level = 0
                                End If
                            End If
                            If dr("IMPORTE_D") <> 0 Then
                                Fg.AddItem("-" & vbTab & dr("REFER") & vbTab & "" & vbTab & dr("DES_CONC_D") & vbTab & dr("DOCTO_D") & vbTab & dr("F_APLI_D") & vbTab &
                                           dr("F_VENC_D") & vbTab & "" & vbTab & Format(dr("IMPORTE_D"), "###,###,###,##0.00") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & dr("NO_PAR"))
                                r = Fg.Rows(Fg.Rows.Count - 1)
                                r.IsNode = False
                                If Not IsNothing(r.Node) Then
                                    r.Node.Level = 0
                                End If
                                Level += 1
                            End If
                            Level = 1
                            i += 1
                            REFER = dr("REFER")
                        Catch ex As Exception
                            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While

                    Lt1.Text = Format(IMPORTE, "##,###,###,##0.00")
                    Lt2.Text = Format(ABONOS, "##,###,###,##0.00")
                    Lt3.Text = Format(IMPORTE + ABONOS, "##,###,###,##0.00")

                    LtSaldo.Text = Lt3.Text

                    'Try
                    '    If Var49 <> IMPORTE + ABONOS Then
                    '        SQL = "UPDATE CLIE" & Empresa & " SET SALDO = " & IMPORTE + ABONOS & " WHERE CLAVE = '" & Var4 & "'"
                    '        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    '            cmd2.CommandText = SQL
                    '            returnValue = cmd2.ExecuteNonQuery().ToString
                    '            If returnValue IsNot Nothing Then
                    '                If returnValue = "1" Then
                    '                End If
                    '            End If
                    '        End Using
                    '    End If
                    'Catch ex As Exception
                    'End Try

                End Using
            End Using
            For k = 1 To Fg.Rows.Count - 1
                Dim r1 As Row = Fg.Rows(k)
                Try
                    r1.Node.Collapsed = True
                Catch ex As Exception
                    'Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next

            'If PASS_GRUPOCE = "BUS" Then
            'For k = 1 To Fg.Cols.Count - 1
            'Fg(0, k) = k & ". " & Fg(0, k)
            'Next
            'End If

            'Fg.AutoSizeCols()
            'Fg.Cols(2).Width = 0 : Fg.Cols(10).Width = 0 : Fg.Cols(11).Width = 0 : Fg.Cols(12).Width = 0
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FrmEdoCuentaCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Edo. cuenta clientes")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String = ""
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportEstaCuenClie.mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

            StiReport1.RegData(DataSet1)

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Render()
            If PASS_GRUPOCE = "BUS" Then
                StiReport1.Design()
            Else
                StiReport1.Show()
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarEliminarPago_Click(sender As Object, e As ClickEventArgs) Handles BarEliminarPago.Click
        Dim IMPORTE As Decimal = 0, REFER As String, NO_PARTIDA As Integer = 0

        Try
            If Fg.Row = 0 Then
                MsgBox("Por favor seleccione un pago a eliminar")
                Return
            End If
            If MsgBox("Realmente desea eliminar el pago?", vbYesNo) = vbYes Then

                REFER = Fg(Fg.Row, 1)
                '                   IMPORTE
                If Not IsNothing(Fg(Fg.Row, 8)) Then
                    If IsNumeric(Fg(Fg.Row, 8)) Then

                        IMPORTE = Fg(Fg.Row, 8)
                        IMPORTE = Math.Abs(IMPORTE)
                        NO_PARTIDA = Fg(Fg.Row, 12)
                    End If
                End If

                If REFER.Trim.Length > 0 And IMPORTE > 0 And NO_PARTIDA > 0 Then
                    SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND 
                        CVE_CLIE = '" & LtClave.Text & "' AND NO_PARTIDA = " & NO_PARTIDA
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using

                    UPDATE_DATOS_CLIE(IMPORTE, REFER, LtClave.Text, " + ")

                    DESPLEGAR()

                Else
                    MsgBox("No se logro eliminar el pago")
                End If

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        ' Check that the row and column contain integer data.
        Try
            Debug.Print(Fg(e.Row, e.Col))
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                'Dim value As Decimal = CDec(Fg(e.Row, 8))
                'If value < 0 Then
                '    Dim cs1 As CellStyle
                '    cs1 = Fg.Styles.Add("cs1")
                '    cs1.BackColor = Color.White
                '    cs1.ForeColor = Color.Red
                '    Fg.SetCellStyle(e.Row, 8, cs1)
                'End If
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmEdoCuentaCliente_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            'Dim Ancho As Integer = 0
            'For k = 0 To 9
            'Ancho += Fg.Cols(k).Width
            'Next
            'Lt3.Left = Ancho + 120
            'Lt2.Left = Lt3.Left - Lt3.Width
            'Lt1.Left = Lt2.Left - Lt2.Width
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) Handles BtnFiltro.Click
        Try
            CADENA = " AND M.FECHA_APLI >= '" & FSQL(F1.Value) & "' AND M.FECHA_APLI <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR()

        Catch ex As Exception
        End Try

    End Sub
End Class
