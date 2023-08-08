Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmEstadoCuentaClie
    Private Sub frmEstadoCuentaClie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        'Fg.Tree.Column = 1
        Fg.Rows.Count = 1
        Fg.Height = Me.Height - 175

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
    End Sub
    Sub DESPLEGAR()
        Dim IMPORTE As Decimal, SALDO As Decimal, ABONOS As Decimal, z As Integer
        Dim Level As Integer, i As Integer, Sigue As Boolean, CLIENTE As String
        Dim CADENA As String = "", CADENA_CLIE As String = "", CADENA_FECHA As String = "", CADENA_SALDO As String = ""
        Dim CARGOS As Decimal, Continua As Boolean, DIF As Decimal

        Try
            CADENA_CLIE = ""
            If tCLAVE1.Text.Trim.Length > 0 And tCLAVE2.Text.Trim.Length > 0 Then
                CADENA_CLIE = " AND M.CVE_CLIE >= '" & tCLAVE1.Text & "' AND M.CVE_CLIE <= '" & tCLAVE2.Text & "'"
            Else
                If tCLAVE1.Text.Trim.Length > 0 And tCLAVE2.Text.Trim.Length = 0 Then
                    CADENA_CLIE = " AND M.CVE_CLIE >= '" & tCLAVE1.Text & "'"
                Else
                    If tCLAVE1.Text.Trim.Length = 0 And tCLAVE2.Text.Trim.Length > 0 Then
                        CADENA_CLIE = "AND M.CVE_CLIE <= '" & tCLAVE2.Text & "'"
                    End If
                End If
            End If
            Try
                If IsNothing(F1.Value) Then
                    F1.Value = Date.Today
                Else
                    If IsDBNull(F1.Value) Then
                        F1.Value = Date.Today
                    End If
                End If
                If IsNothing(F2.Value) Then
                    F2.Value = Date.Today
                Else
                    If IsDBNull(F2.Value) Then
                        F2.Value = Date.Today
                    End If
                End If
            Catch ex As Exception
                Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Dim d1 As DateTime = F1.Value
                Dim d2 As DateTime = F2.Value

                CADENA_FECHA = "WHERE C.TIPO = 'C'"

                If d1.Year > 1001 And d2.Year > 1001 Then
                    CADENA_FECHA = " WHERE C.TIPO = 'C' AND M.FECHA_APLI >= '" & FSQL(F1.Value) & "' AND M.FECHA_APLI <= '" & FSQL(F2.Value) & "' "
                Else
                    If d1.Year > 1001 And d2.Year = 1001 Then
                        CADENA_FECHA = " WHERE TIPO = 'C' AND M.FECHA_APLI >= '" & FSQL(F1.Value) & "'"
                    Else
                        If d1.Year = 1001 And d2.Year > 1001 Then
                            CADENA_FECHA = " WHERE TIPO = 'C' AND M.FECHA_APLI <= '" & FSQL(F2.Value) & "'"
                        End If
                    End If
                End If
                CADENA = ""
                If CADENA_CLIE.Trim.Length > 0 And CADENA_FECHA.Trim.Length > 0 Then
                    'CADENA = " AND C.CON_REFER <> 'N' AND " & CADENA_CLIE & CADENA_FECHA
                Else
                    If CADENA_CLIE.Trim.Length > 0 And CADENA_FECHA.Trim.Length = 0 Then
                        'CADENA = " WHERE C.CON_REFER <> 'N' AND " & CADENA_CLIE
                    Else
                        If CADENA_CLIE.Trim.Length = 0 And CADENA_FECHA.Trim.Length > 0 Then
                            'CADENA = " WHERE C.CON_REFER <> 'N' AND " & CADENA_FECHA
                        End If
                    End If
                End If
                CADENA = CADENA_FECHA & CADENA_CLIE

                If chSaldo.Checked Then
                    CADENA_SALDO = " HAVING(MAX(M.IMPORTE) - ISNULL(SUM(D.IMPORTE * D.SIGNO), 0)) > 0.1 "
                Else
                    CADENA_SALDO = ""
                End If
                Fg.Redraw = False
            Catch ex As Exception
                Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


            SQL = "SELECT M.CVE_CLIE, M.REFER, M.IMPORTE As IMPORT, M.NUM_CPTO As CPTO, C.DESCR As DS, M.NO_FACTURA As NO_FAC,
                M.DOCTO As DOCT, M.NUM_CARGO As NCARGO, M.FECHA_APLI As FAPLI, M.FECHA_VENC As FVENC, T.NOMBRE, NUM_CARGO,
                ISNULL((Select SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " WHERE ID_MOV = M.NUM_CPTO And SIGNO = -1 And REFER = M.REFER),0) As ABONOS, 
                ISNULL((Select SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " WHERE ID_MOV = M.NUM_CPTO And SIGNO = 1 AND REFER = M.REFER),0) As CARGOS
                FROM CUEN_M" & Empresa & " M
                LEFT JOIN CLIE" & Empresa & " T ON T.CLAVE  = M.CVE_CLIE
                LEFT JOIN CONC" & Empresa & " C On C.NUM_CPTO = M.NUM_CPTO " &
                CADENA &
                " ORDER BY M.CVE_CLIE, M.FECHA_APLI DESC"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Level = 1 : i = 1 : z = 0
                    Fg.Rows.Count = 1
                    CLIENTE = ""
                    Sigue = False
                    While dr.Read

                        'Application.DoEvents()

                        If CLIENTE <> dr("CVE_CLIE") Then
                            If Sigue Then
                                Sigue = False
                                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & IMPORTE & vbTab & ABONOS & vbTab & SALDO)
                            End If
                            Fg.AddItem("" & vbTab & dr("CVE_CLIE") & vbTab & vbTab & dr("NOMBRE"))
                            IMPORTE = 0 : ABONOS = 0 : SALDO = 0
                            Sigue = True
                        End If
                        CARGOS = dr("CARGOS")
                        IMPORTE = IMPORTE + dr("IMPORT") + CARGOS
                        ABONOS = ABONOS + dr("ABONOS")
                        DIF = (dr("IMPORT") + CARGOS + dr("ABONOS"))
                        DIF = Math.Round(DIF, 2)
                        SALDO = SALDO + (dr("IMPORT") + CARGOS + dr("ABONOS"))
                        If SALDO < 0 Then SALDO = 0

                        Continua = True

                        If chSaldo.Checked Then
                            If DIF <> 0 Then
                                Continua = True
                            Else
                                Continua = False
                            End If
                        End If
                        If Continua Then
                            Fg.AddItem("-" & vbTab & dr("REFER") & vbTab & dr("CVE_CLIE") & vbTab & dr("CPTO") & " " & dr("DS") & vbTab &
                                   dr("NUM_CARGO") & vbTab & dr("FAPLI") & vbTab & dr("FVENC") & vbTab & (dr("IMPORT") + CARGOS) & vbTab &
                                   (CARGOS + dr("ABONOS")) & vbTab & (dr("IMPORT") + CARGOS + dr("ABONOS")))
                            Level = Level + 1
                            i = i + 1
                        End If
                        CLIENTE = dr("CVE_CLIE")
                    End While
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & IMPORTE & vbTab & ABONOS & vbTab & SALDO)
                End Using
            End Using
            Fg.Redraw = True

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR2()
        Dim IMPORTE As Decimal
        Dim SALDO As Decimal
        Dim Level As Integer
        Dim i As Integer
        Dim CADENA As String
        Dim CADENA_CLIE As String
        Dim CADENA_FECHA As String
        Dim CADENA_SALDO As String

        Try
            CADENA_CLIE = ""
            If tCLAVE1.Text.Trim.Length > 0 And tCLAVE2.Text.Trim.Length > 0 Then
                CADENA_CLIE = "M.CVE_CLIE >= '" & tCLAVE1.Text & "' AND M.CVE_CLIE <= '" & tCLAVE2.Text & "'"
            Else
                If tCLAVE1.Text.Trim.Length > 0 And tCLAVE2.Text.Trim.Length = 0 Then
                    CADENA_CLIE = "M.CVE_CLIE >= '" & tCLAVE1.Text & "'"
                Else
                    If tCLAVE1.Text.Trim.Length = 0 And tCLAVE2.Text.Trim.Length > 0 Then
                        CADENA_CLIE = "M.CVE_CLIE <= '" & tCLAVE2.Text & "'"
                    End If
                End If
            End If
            If IsNothing(F1.Value) Then
                F1.Value = "01/01/1001"
            Else
                If IsDBNull(F1.Value) Then
                    F1.Value = "01/01/1001"
                End If
            End If
            If IsNothing(F2.Value) Then
                F2.Value = "01/01/1001"
            Else
                If IsDBNull(F2.Value) Then
                    F2.Value = "01/01/1001"
                End If
            End If

            Dim d1 As DateTime = F1.Value
            Dim d2 As DateTime = F2.Value

            CADENA_FECHA = ""

            If d1.Year > 1001 And d2.Year > 1001 Then
                CADENA_FECHA = "M.FECHA_APLI >= '" & FSQL(F1.Value) & "' AND M.FECHA_APLI <= '" & FSQL(F2.Value) & "'"
            Else
                If d1.Year > 1001 And d2.Year = 1001 Then
                    CADENA_FECHA = "M.FECHA_APLI >= '" & FSQL(F1.Value) & "'"
                Else
                    If d1.Year = 1001 And d2.Year > 1001 Then
                        CADENA_FECHA = "M.FECHA_APLI <= '" & FSQL(F2.Value) & "'"
                    End If
                End If
            End If
            CADENA = ""
            If CADENA_CLIE.Trim.Length > 0 And CADENA_FECHA.Trim.Length > 0 Then
                CADENA = " WHERE " & CADENA_CLIE & " AND " & CADENA_FECHA
            Else
                If CADENA_CLIE.Trim.Length > 0 And CADENA_FECHA.Trim.Length = 0 Then
                    CADENA = " WHERE " & CADENA_CLIE
                Else
                    If CADENA_CLIE.Trim.Length = 0 And CADENA_FECHA.Trim.Length > 0 Then
                        CADENA = " WHERE " & CADENA_FECHA
                    End If
                End If
            End If

            If chSaldo.Checked Then
                CADENA_SALDO = " HAVING(MAX(M.IMPORTE) - ISNULL(SUM(D.IMPORTE * D.SIGNO), 0)) > 0.1 "
            Else
                CADENA_SALDO = ""
            End If
            F1.Value = vbNull
            F2.Value = vbNull

            SQL = "Select M.CVE_CLIE, M.REFER, MAX(M.IMPORTE) As IMPORT, MAX(M.NUM_CPTO) As CPTO, MAX(C.DESCR) As DS,
              MAX(M.NO_FACTURA) As NO_FAC, MAX(M.DOCTO) As DOCT, MAX(M.NUM_CARGO) As NCARGO, MAX(M.FECHA_APLI) As FAPLI,
              MAX(M.FECHA_VENC) As FVENC, MAX(M.SIGNO) As SIG, ISNULL(SUM(D.IMPORTE * D.SIGNO),0) As SUM1,
              ISNULL((Select SUM(IMPORTE * SIGNO) FROM CUEN_DET" & Empresa & " WHERE CVE_CLIE = M.CVE_CLIE And REFER = M.REFER),0) As SUM2
              FROM CUEN_M" & Empresa & " M
              LEFT JOIN CUEN_DET" & Empresa & " D On M.CVE_CLIE = D.CVE_CLIE And M.REFER = D.REFER And M.NUM_CPTO = D.ID_MOV And M.NUM_CARGO = D.NUM_CARGO
              LEFT JOIN CONC" & Empresa & " C On C.NUM_CPTO = M.NUM_CPTO " &
              CADENA & " GROUP BY M.CVE_CLIE, M.REFER
              ORDER BY MAX(M.FECHA_APLI) DESC"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Level = 1
                    i = 1
                    Fg.Rows.Count = 1
                    While dr.Read

                        Application.DoEvents()

                        Fg.Rows.InsertNode(i, Level)
                        IMPORTE = IMPORTE + dr("IMPORT")
                        SALDO = SALDO + (dr("IMPORT") * dr("SIG") + dr("SUM1"))
                        If SALDO < 0 Then SALDO = 0
                        Fg(i, 1) = dr("NO_FAC")
                        Fg(i, 2) = dr("DS")
                        Fg(i, 3) = dr("DOCT")
                        Fg(i, 4) = dr("NCARGO")
                        Fg(i, 5) = dr("FAPLI")
                        Fg(i, 6) = dr("FVENC")
                        Fg(i, 7) = (dr("Import") * dr("SIG"))
                        Fg(i, 8) = ((dr("Import") * dr("SIG")) + dr("SUM1"))
                        Fg(i, 9) = dr("REFER")
                        Fg(i, 10) = dr("CPTO")
                        Fg(i, 11) = "CUEN_M"
                        Fg(i, 12) = dr("SIG")

                        Fg.AddItem("" & vbTab & "Factura" & vbTab & "Concepto" & vbTab & "Documento" & vbTab &
                            "" & vbTab & "Fecha Apli." & vbTab & "fecha venc." & vbTab & "Importe" & vbTab &
                            "folio" & vbTab & "Estatus" & vbTab & "10" & vbTab & "11")

                        SQL = "SELECT D.NUM_CPTO, C.DESCR, D.REFER, D.NO_FACTURA , D.FECHA_APLI, D.FECHA_VENC, " &
                             "D.IMPORTE, D.SIGNO, D.NO_PARTIDA " &
                             "FROM CUEN_DET" & Empresa & " D " &
                             "LEFT JOIN CONC" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO " &
                             "WHERE CVE_CLIE = '" & dr("CVE_CLIE") & "' AND REFER = '" & dr("REFER") & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                While dr2.Read

                                    Application.DoEvents()

                                    Fg.AddItem("-" & vbTab & dr2("NO_FACTURA") & vbTab & dr2("DESCR") & vbTab & dr2("REFER") & vbTab &
                                        "" & vbTab & dr2("FECHA_APLI") & vbTab & dr2("FECHA_VENC") & vbTab & (dr2("IMPORTE") * dr2("SIGNO")) &
                                        vbTab & "" & vbTab & dr2("REFER") & vbTab & dr2("NO_PARTIDA") & vbTab & "PAGA_DET" & vbTab & dr2("SIGNO"))
                                    Level = Level + 1
                                End While
                            End Using
                        End Using
                        Level = 1
                        i = i + 1
                    End While
                End Using
            End Using
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmEstadoCuentaClie_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Estado de cuenta")
    End Sub
    Private Sub barDesplegar_Click(sender As Object, e As EventArgs) Handles barDesplegar.Click
        DESPLEGAR()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnClie1_Click(sender As Object, e As EventArgs) Handles btnClie1.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLAVE1.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnClie2_Click(sender As Object, e As EventArgs) Handles btnClie2.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLAVE2.Text = Var4
                Var2 = "" : Var4 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCLAVE1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClie1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCLAVE1_Validated(sender As Object, e As EventArgs) Handles tCLAVE1.Validated
        Try
            If tCLAVE1.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(tCLAVE1.Text.Trim) Then
                    DESCR = Space(10 - tCLAVE1.Text.Trim.Length) & tCLAVE1.Text.Trim
                    tCLAVE1.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", tCLAVE1.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCLAVE2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClie2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCLAVE2_Validated(sender As Object, e As EventArgs) Handles tCLAVE2.Validated
        Try
            If tCLAVE2.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(tCLAVE2.Text.Trim) Then
                    DESCR = Space(10 - tCLAVE2.Text.Trim.Length) & tCLAVE2.Text.Trim
                    tCLAVE2.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", tCLAVE2.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barExcel_Click(sender As Object, e As EventArgs) Handles barExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Edo. cuenta clientes")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception

        End Try
    End Sub
End Class
