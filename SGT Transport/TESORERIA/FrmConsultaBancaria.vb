Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmConsultaBancaria
    Private Sub FrmConsultaBancaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG

                ProcessControls(Me)

            Catch ex As Exception
            End Try

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

            Fg.Rows.Count = 1
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - F1.Top - F1.Height - 50
            Fg.Rows(0).Height = 50

            Fg.DrawMode = DrawModeEnum.OwnerDraw

            SplitM1.Dock = DockStyle.Fill
            SplitM1.BorderWidth = 1
            SplitM1.SplitterWidth = 1

            Fg.Dock = DockStyle.Fill
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("NUM.", GetType(System.String))
            dt.Columns.Add("CUENTA", GetType(System.String))
            dt.Columns.Add("BANCO", GetType(System.String))

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT TRY_PARSE(ISNULL(CLAVE,'0') AS INT) AS CLAVE_CTA, CUENTA_BANCARIA, ISNULL(NOMBRE_BANCO,'') AS NOMBRE
                    FROM CUENTA_BENEF" & Empresa & " WHERE ISNULL(STATUS,'A') = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CLAVE_CTA"), dr("CUENTA_BANCARIA"), dr("NOMBRE"))
                    End While
                End Using
            End Using

            CboCuentabancaria.TextDetached = True
            CboCuentabancaria.ItemsDataSource = dt.DefaultView
            CboCuentabancaria.ItemsDisplayMember = "CUENTA"
            CboCuentabancaria.ItemsValueMember = "NUM."
            CboCuentabancaria.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboCuentabancaria.HtmlPattern = "<table><tr><td width=30>{NUM.}</td><td width=150>{CUENTA}</td><td width=170>{BANCO}</td><td width=220></tr></table>"

        Catch ex As Exception
            Bitacora("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("40. ex.Message: " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmConsultaBancaria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Consulta bancaria")
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Dim SUMA As Decimal = 0, TOTAL_CARGOS As Decimal = 0, TOTAL_ABONOS As Decimal = 0, SALDO As Decimal, SALDO_INICIAL As Decimal = 0
        Dim TOTAL_CARGOS_A As Decimal = 0, TOTAL_ABONOS_A As Decimal = 0, CTA_BANCARIA As Decimal, SALDO_FINAL As Decimal = 0

        'Fg.Styles(CellStyleEnum.Normal).WordWrap = True
        If CboCuentabancaria.SelectedIndex = -1 Then
            MsgBox("Por favor selecciones una cuenta bancaria")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        C1ToolBar1.Enabled = False
        Fg.Redraw = False
        Fg.Rows.Count = 1


        Try
            CTA_BANCARIA = CboCuentabancaria.Text

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(SALDO,0) AS SALD
                    FROM CUENTA_BENEF" & Empresa & " WHERE CUENTA_BANCARIA = '" & CTA_BANCARIA & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SALDO = dr("SALD")
                    End If
                End Using
            End Using


            SQL = "TRUNCATE TABLE GCCONSULTA_BANCARIA"
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘

        Try
            'TESORERIA DEPOSITADOS
            SQL = "SELECT TOP 500 P.FOLIO, convert(varchar, P.FECHAELAB, 103) AS FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR, 
                P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN, P.FECHA_AUT, 
                P.FECHA_DEP, CVE_LIQ
                FROM GCASIGNACION_VIAJE_GASTOS P 
                LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                WHERE V.STATUS = 'A' AND P.STATUS <> 'C' AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NOT NULL AND
                FECHA_AUT < '" & FSQL(F1.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TOTAL_CARGOS_A += dr("IMPORTE") * -1
                    End While
                End Using
            End Using

            'ALTAS CXC
            SQL = "SELECT D.CVE_CLIE, P.NOMBRE, D.REFER, D.REFER, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI,
                CON_REFER, D.NUM_CPTO, DESCR
                FROM CUEN_DET" & Empresa & " D
                LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE
                LEFT JOIN CONC" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO
                WHERE FECHA_APLI < '" & FSQL(F1.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TOTAL_ABONOS_A += dr("IMPORTE")
                    End While
                End Using
            End Using
            'ALTA CXP
            SQL = "SELECT D.CVE_PROV, P.NOMBRE, D.REFER, D.REFER, D.DOCTO, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI,
                CON_REFER, D.NUM_CPTO, DESCR, NO_PARTIDA
                FROM PAGA_DET" & Empresa & " D
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = D.CVE_PROV
                LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO
                WHERE FECHA_APLI < '" & FSQL(F1.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TOTAL_CARGOS_A += dr("IMPORTE") * -1
                    End While
                End Using
            End Using

            'LIQUIDACIONES
            SQL = "SELECT L.CVE_LIQ, L.FECHA, L.CVE_OPER, O.NOMBRE, L.CVE_UNI, L.CVE_RES, ISNULL(S.DESCR,'EDICION') AS DESCR_ST_LIQ, IMPORTE
                FROM GCLIQUIDACIONES L
                LEFT JOIN GCSTATUS_LIQUIDACION S ON S.CVE_LIQ = L.CVE_ST_LIQ
                LEFT JOIN GCOPERADOR O ON O.CLAVE = L.CVE_OPER 
                WHERE L.STATUS <> 'C' AND 
                L.FECHA < '" & FSQL(F1.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TOTAL_CARGOS_A += dr("IMPORTE") * -1
                    End While
                End Using
            End Using

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        SALDO_INICIAL = SALDO + TOTAL_CARGOS_A + TOTAL_ABONOS_A

        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
        Try
            'TESORERIA DEPOSITADOS
            SQL = "SELECT TOP 500 P.FOLIO, convert(varchar, P.FECHAELAB, 103) AS FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR, 
                P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN, P.FECHA_AUT, 
                P.FECHA_DEP, CVE_LIQ
                FROM GCASIGNACION_VIAJE_GASTOS P 
                LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                WHERE V.STATUS = 'A' AND P.STATUS <> 'C' AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NOT NULL AND
                FECHA_AUT >= '" & FSQL(F1.Value) & "' AND FECHA_AUT <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            TOTAL_CARGOS += dr("IMPORTE") * -1
                            SQL = "INSERT INTO GCCONSULTA_BANCARIA (TIPO_MOV, FECHA, IMPORTE, CONCEPTO) VALUES ('DEPOSITOS','" &
                                FSQL(dr("FECHA_AUT")) & "','" & (dr("IMPORTE") * -1) & "','Viaje:" &
                                dr("CVE_VIAJE") & " Gasto:" & dr("FOLIO") & " Operador:" & dr("NOMBRE") & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            'ALTAS CXC
            SQL = "SELECT D.CVE_CLIE, P.NOMBRE, D.REFER, D.REFER, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI,
                CON_REFER, D.NUM_CPTO, DESCR
                FROM CUEN_DET" & Empresa & " D
                LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE
                LEFT JOIN CONC" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO
                WHERE FECHA_APLI >= '" & FSQL(F1.Value) & "' AND FECHA_APLI <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        'Fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("FECHA_APLI") & vbTab & dr("IMPORTE") & vbTab & dr("REFER"))
                        Try
                            TOTAL_ABONOS += dr("IMPORTE")

                            SQL = "INSERT INTO GCCONSULTA_BANCARIA (TIPO_MOV, FECHA, IMPORTE, CONCEPTO) VALUES ('" &
                                "CXC " & dr("DESCR") & "','" & FSQL(dr("FECHA_APLI")) & "','" & dr("IMPORTE") & "','" &
                                "Cliente:" & dr("NOMBRE") & " Factura:" & dr("REFER") & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            'ALTA CXP
            SQL = "SELECT D.CVE_PROV, P.NOMBRE, D.REFER, D.REFER, D.DOCTO, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI,
                CON_REFER, D.NUM_CPTO, DESCR, NO_PARTIDA
                FROM PAGA_DET" & Empresa & " D
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = D.CVE_PROV
                LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO
                WHERE FECHA_APLI >= '" & FSQL(F1.Value) & "' AND FECHA_APLI <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        'Fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("FECHA_APLI") & vbTab & (dr("IMPORTE") * -1) & vbTab & dr("REFER"))
                        Try
                            TOTAL_CARGOS += dr("IMPORTE") * -1
                            SQL = "INSERT INTO GCCONSULTA_BANCARIA (TIPO_MOV, FECHA, IMPORTE, CONCEPTO) VALUES ('" &
                                "CXP " & dr("DESCR") & "','" & FSQL(dr("FECHA_APLI")) & "','" & (dr("IMPORTE") * -1) & "','" &
                                "Prov." & dr("NOMBRE") & " Docto:" & dr("DOCTO") & " Factura:" & dr("REFER") & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            'LIQUIDACIONES
            SQL = "SELECT L.CVE_LIQ, L.FECHA, L.CVE_OPER, O.NOMBRE, L.CVE_UNI, L.CVE_RES, ISNULL(S.DESCR,'EDICION') AS DESCR_ST_LIQ, IMPORTE
                FROM GCLIQUIDACIONES L
                LEFT JOIN GCSTATUS_LIQUIDACION S ON S.CVE_LIQ = L.CVE_ST_LIQ
                LEFT JOIN GCOPERADOR O ON O.CLAVE = L.CVE_OPER 
                WHERE L.STATUS <> 'C' AND 
                L.FECHA >= '" & FSQL(F1.Value) & "' AND L.FECHA <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        'Fg.AddItem("" & vbTab & "LIQ. " & dr("CVE_LIQ") & vbTab & dr("FECHA") & vbTab & (dr("IMPORTE") * -1) & vbTab & dr("NOMBRE"))
                        Try
                            TOTAL_CARGOS += dr("IMPORTE") * -1

                            SQL = "INSERT INTO GCCONSULTA_BANCARIA (TIPO_MOV, FECHA, IMPORTE, CONCEPTO) VALUES ('" &
                                "LIQUIDACION" & "','" & FSQL(dr("FECHA")) & "','" & (dr("IMPORTE") * -1) & "','Liq.:" & dr("CVE_LIQ") &
                                "  Operador:" & dr("NOMBRE") & "')"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            'CONSULTA BANCARIA
            SQL = "SELECT TIPO_MOV, FECHA, IMPORTE, CONCEPTO
                FROM GCCONSULTA_BANCARIA L 
                ORDER BY FECHA"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("TIPO_MOV") & vbTab & dr("FECHA") & vbTab &
                                   dr("IMPORTE") & vbTab & dr("CONCEPTO"))
                        SUMA += dr("IMPORTE")
                    End While
                End Using
            End Using

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & SUMA & vbTab & "")

            Fg.AutoSizeCols()
            Fg.Rows(0).Height = 50

            Me.Refresh()

            SALDO_FINAL = SALDO_INICIAL + TOTAL_CARGOS + TOTAL_ABONOS

            LTotalCargos.Text = Format(TOTAL_CARGOS, "###,###,###,##0.00")
            LTotalAbonos.Text = Format(TOTAL_ABONOS, "###,###,###,##0.00")
            LSaldoFinal.Text = Format(SALDO_FINAL, "###,###,###,##0.00")
            LSaldoInicial.Text = Format(SALDO_INICIAL, "###,###,###,##0.00")

            C1ToolBar1.Enabled = True
            Me.Cursor = Cursors.Default
            Fg.Redraw = True

            MsgBox("Proceso terminado")

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        C1ToolBar1.Enabled = True
        Me.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click

        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "CONSULTA BANCARIA")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
End Class
