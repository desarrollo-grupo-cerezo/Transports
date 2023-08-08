Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmRelacionACobranza
    Private CVE_REL As String = ""
    Private Sub FrmRelacionACobranza_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.CenterToScreen()

            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Fg.Cols(9).Visible = False

            Dim SPOR1 As Decimal
            SPOR1 = ((L1.Height + L1.Top) / Me.Height) * 100
            SplitM1.SizeRatio = SPOR1 + 4
            SplitM2.SizeRatio = 100 - SplitM1.SizeRatio

            SplitM.BorderWidth = 0
            SplitM.FixedLineWidth = 0
            SplitM.HeaderLineWidth = 0
            SplitM.SplitterWidth = 0

            SplitM1.BorderWidth = 0
            SplitM2.BorderWidth = 0


            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

            Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
            Fg.Styles("Focus").BackColor = Color.PowderBlue
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double
            Fg.FocusRect = FocusRectEnum.Solid
            'Fg.Transpose()
            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            Fg.Styles.Fixed.WordWrap = True
            Fg.Rows(0).Height = 40
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg.Cols(1).StarWidth = "*"
            Fg.Cols(2).StarWidth = "*"
            Fg.Cols(3).StarWidth = "*"
            Fg.Cols(4).StarWidth = "*"
            Fg.Cols(5).StarWidth = "*"
            Fg.Cols(6).StarWidth = "*"
            Fg.Cols(7).StarWidth = "*"
            Fg.Cols(8).StarWidth = "*"

            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            If Var2 = "Nuevo" Then
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

                TCVE_REL.Text = GET_MAX_TRY("GCREL_FACTURAS", "CVE_REL")
                TCVE_REL.Enabled = False
                TCLIENTE.Text = ""
                Fg.Rows.Count = 1

                TCLIENTE.Select()

            Else
                TCVE_REL.Text = Var3
                TCVE_REL.Enabled = False
                TCLIENTE.Enabled = False
                BtnCliente.Enabled = False

                DESPLEGAR_REL_FACTURAS()
            End If

            F1.Enabled = False

            Fg.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_REL_FACTURAS()
        Dim S1 As Decimal, S2 As Decimal, S3 As Decimal, S4 As Decimal
        Try
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT R.CVE_REL, R.CLIENTE, C.NOMBRE, R.FECHA, R.FECHA_ENVIO, R.FECHA_RECEP, FECHA_MODIF, 
                    R.SUBTOTAL, R.IVA, R.RET, R.TOTAL, R.GUIA
                    FROM GCREL_FACTURAS  R
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = R.CLIENTE
                    WHERE R.CVE_REL  = '" & TCVE_REL.Text & "'
                    ORDER BY R.FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            TCVE_REL.Text = dr.ReadNullAsEmptyString("CVE_REL")
                            TCLIENTE.Text = dr.ReadNullAsEmptyString("CLIENTE")
                            LtNombre.Text = dr.ReadNullAsEmptyString("NOMBRE")
                            TGUIA.Text = dr.ReadNullAsEmptyString("GUIA")
                            F1.Value = dr("FECHA")
                            If Year(dr("FECHA_ENVIO")) <> 1900 Then
                                F2.Value = dr("FECHA_ENVIO")
                            End If
                            If Year(dr("FECHA_RECEP")) <> 1900 Then
                                F3.Value = dr("FECHA_RECEP")
                            End If
                            If Year(dr("FECHA_MODIF")) <> 1900 Then
                                F4.Value = dr("FECHA_MODIF")
                            End If
                        Catch ex As Exception
                        End Try
                    End While
                End Using
            End Using

            DESPLEGAR()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT R.CVE_REL, R.CVE_DOC, V.CLIENTE, C.NOMBRE, R.FECHA_DOC, ISNULL(R.SUBTOTAL,0) AS SUBT, 
                    ISNULL(R.IVA,0) AS IV, ISNULL(R.RET,0) AS RETENCION, ISNULL(R.TOTAL,0) AS TOT, R.MONEDA, R.UUID
                    FROM GCREL_FACTURAS_PAR  R
                    LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_DOC = R.CVE_DOC
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = V.CLIENTE
                    WHERE R.CVE_REL  = '" & TCVE_REL.Text & "'
                    ORDER BY R.FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "1" & vbTab & dr.ReadNullAsEmptyString("CVE_DOC") & vbTab & dr("FECHA_DOC") & vbTab &
                                   dr("SUBT") & vbTab & dr("IV") & vbTab & dr("RETENCION") & vbTab &
                                   dr("TOT") & vbTab & dr("MONEDA") & vbTab & dr("UUID"))
                        S1 += dr("SUBT")
                        S2 += dr("IV")
                        S3 += dr("RETENCION")
                        S4 += dr("TOT")
                    End While
                End Using
            End Using
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab & S2 & vbTab & S3 & vbTab & S4)

            Fg.Focus()
            Fg.Select()
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR()
        Try
            Dim z As Integer = 0, ExistDoc As Boolean, x As Integer = 0

            Fg.Rows.Count = 1

            If TCLIENTE.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT FACTURA, CLIENTE, FECHAELAB, ISNULL(SUBTOTAL,0) AS SUBT, ISNULL(IVA,0) AS IV, 
                        ISNULL(RETENCION,0) AS RET, ISNULL(IMPORTE,0) AS IMPORT, MONEDA 
                        FROM CFDI 
                        WHERE ISNULL(ESTATUS,'') <> 'C' AND ISNULL(CVE_REL,'') = '' AND CLIENTE = '" & TCLIENTE.Text & "'
                        ORDER BY FECHAELAB"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            ExistDoc = False
                            For k = 1 To Fg.Rows.Count - 1
                                If Fg(k, 2) = dr("FACTURA") Then
                                    ExistDoc = True
                                    x = k
                                End If
                            Next

                            If Not ExistDoc Then
                                Fg.AddItem("" & vbTab & "" & vbTab & dr.ReadNullAsEmptyString("FACTURA") & vbTab & dr("FECHAELAB") & vbTab &
                                    dr("SUBT") & vbTab & dr("IV") & vbTab & dr("RET") & vbTab & dr("IMPORT") & vbTab & dr("MONEDA") & vbTab & "")

                            End If
                            z += 1
                        End While
                    End Using
                End Using
            Else
                MsgBox("Por favor capture la clave de un cliente o búsquelo haciendo click en la lupa")
                TCLIENTE.Focus()
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmRelacionACobranza_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim SUBTOTAL As Decimal, RET As Decimal, IVA As Decimal, TOTAL As Decimal, HayError As Boolean = False, z As Integer = 0

        If MsgBox("Realmente desea generar la relación de cobranza?", vbYesNo) = vbNo Then
            Return
        End If

        If Fg.Rows.Count = 1 Then
            MsgBox("No existen documentos para poder realizar la relación de cobranza")
            Return
        End If

        For k = 1 To Fg.Rows.Count - 1
            Try
                If Fg(k, 1) Then
                    If Not IsNothing(Fg(k, 2)) Then
                        'Fg.AddItem("" & vbTab & "1" & vbTab & dr("CVE_DOC") & vbTab & dr("CLIENTE") & vbTab & dr("FECHA_DOC") & vbTab &
                        '  dr("FECHA_ENVIO") & vbTab & dr("FECHA_RECEP") & vbTab & dr("FECHA_MODIF") & vbTab &
                        '  dr("SUBTOTAL") & vbTab & dr("IVA") & vbTab & dr("RET") & vbTab & dr("TOTAL") & vbTab & dr("MONEDA"))
                        SQL = "IF EXISTS (SELECT CVE_REL FROM GCREL_FACTURAS_PAR WHERE UUID = @UUID)
                            UPDATE GCREL_FACTURAS_PAR SET SUBTOTAL = @SUBTOTAL, IVA = @IVA, RET = @RET, TOTAL = @TOTAL, 
                            MONEDA = @MONEDA
                            WHERE UUID = @UUID
                            ELSE
                            INSERT INTO GCREL_FACTURAS_PAR (CVE_REL, NUM_PAR, CVE_DOC, FECHA_DOC, SUBTOTAL, IVA, RET, TOTAL, 
                            MONEDA, FECHAELAB, UUID) 
                            VALUES 
                            (@CVE_REL, ISNULL((SELECT MAX(CAST(NUM_PAR AS INT)) + 1 FROM GCREL_FACTURAS_PAR WHERE CVE_REL = @CVE_REL),1), 
                            @CVE_DOC, @FECHA_DOC, @SUBTOTAL, @IVA, @RET, @TOTAL, @MONEDA, GETDATE(), NEWID())"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_REL", SqlDbType.VarChar).Value = TCVE_REL.Text
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = Fg(k, 2)
                            cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = Fg(k, 3)
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Fg(k, 4)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Fg(k, 5)
                            cmd.Parameters.Add("@RET", SqlDbType.Float).Value = Fg(k, 6)
                            cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = Fg(k, 7)
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = Fg(k, 8)
                            cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = Fg(k, 9)
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                            SUBTOTAL += Fg(k, 4)
                            IVA += Fg(k, 5)
                            RET += Fg(k, 6)
                            TOTAL += Fg(k, 7)

                            SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_REL = " & Convert.ToInt64(TCVE_REL.Text) & " WHERE CVE_DOC = '" & Fg(k, 2) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                            SQL = "UPDATE CFDI SET CVE_REL = " & Convert.ToInt64(TCVE_REL.Text) & " WHERE FACTURA = '" & Fg(k, 2) & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        End Using
                    End If
                Else
                    'ESTA DESMARCADA O SE DESMARCO
                    SQL = "DELETE FROM GCREL_FACTURAS_PAR WHERE UUID = '" & Fg(k, 9) & "'"
                    returnValue2 = EXECUTE_QUERY_NET(SQL)

                    SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_REL = " & Convert.ToInt64(TCVE_REL.Text) & " WHERE CVE_DOC = '" & Fg(k, 2) & "'"
                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                    SQL = "UPDATE CFDI SET CVE_REL = '' WHERE FACTURA = '" & Fg(k, 2) & "'"
                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                    CALCULA_MONTOS()

                End If
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                HayError = True
            End Try
        Next

        Try
            If IsDBNull(F2.Value) Then F2.Value = "01/01/1900"
            If IsDBNull(F3.Value) Then F3.Value = "01/01/1900 00:00:00"
            F4.Value = Now

            SQL = "IF EXISTS (SELECT CVE_REL FROM GCREL_FACTURAS WHERE CVE_REL = @CVE_REL)
                UPDATE GCREL_FACTURAS SET FECHA_ENVIO = @FECHA_ENVIO, FECHA_RECEP = @FECHA_RECEP, 
                FECHA_MODIF = @FECHA_MODIF, SUBTOTAL = @SUBTOTAL, IVA = @IVA, RET = @RET, TOTAL = @TOTAL, 
                GUIA = @GUIA 
                WHERE CVE_REL = @CVE_REL
                ELSE
                INSERT INTO GCREL_FACTURAS (CVE_REL, CLIENTE, STATUS, GUIA, FECHA, FECHA_ENVIO, FECHA_RECEP, 
                SUBTOTAL, IVA, RET, TOTAL, FECHAELAB, UUID, USUARIO) 
                VALUES 
                (@CVE_REL, @CLIENTE, 'A', @GUIA, @FECHA, @FECHA_ENVIO, @FECHA_RECEP, @SUBTOTAL, @IVA, @RET, 
                @TOTAL, GETDATE(), NEWID(), @USUARIO)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_REL", SqlDbType.VarChar).Value = TCVE_REL.Text
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@GUIA", SqlDbType.VarChar).Value = TGUIA.Text
                cmd.Parameters.Add("@FECHA_ENVIO", SqlDbType.Date).Value = F2.Value
                cmd.Parameters.Add("@FECHA_RECEP", SqlDbType.Date).Value = F3.Value
                cmd.Parameters.Add("@FECHA_MODIF", SqlDbType.Date).Value = F4.Value
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = SUBTOTAL
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = IVA
                cmd.Parameters.Add("@RET", SqlDbType.Float).Value = RET
                cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = TOTAL
                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            F3.Visible = False
            F4.Visible = False

            MsgBox("Las relaciones de cobranza se grabaron correctamente")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Me.Close()

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try

            Var2 = "CTE_POS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5

                DESPLEGAR()


                TGUIA.Focus()

                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
        Catch ex As Exception
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            TGUIA.Focus()
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                    TCLIENTE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text, False)
                If DESCR <> "" Then
                    LtNombre.Text = DESCR
                    DESPLEGAR()
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    Fg.Rows.Count = 1
                End If
            Else
                Fg.Rows.Count = 1
                TCLIENTE.Text = ""
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))
            Else
                If Fg.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then Fg.SetCellCheck(0, 1, CheckEnum.Unchecked)

                If Fg(e.Row, 1) Then
                    CALCULA_MONTOS()
                End If
            End If
            CALCULA_MONTOS
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULA_MONTOS()
        Try
            Dim S1 As Decimal, S2 As Decimal, S3 As Decimal, S4 As Decimal
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    S1 += Fg(k, 4)
                    S2 += Fg(k, 5)
                    S3 += Fg(k, 6)
                    S4 += Fg(k, 7)
                End If
            Next
            Fg(Fg.Rows.Count - 1, 4) = S1
            Fg(Fg.Rows.Count - 1, 5) = S2
            Fg(Fg.Rows.Count - 1, 6) = S3
            Fg(Fg.Rows.Count - 1, 7) = S4
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, 1, state)
        Next
    End Sub

    Private Sub F3_KeyDown(sender As Object, e As KeyEventArgs) Handles F3.KeyDown
        If e.KeyCode = 13 Then
            Fg.Focus()
        End If
    End Sub

    Private Sub TGUIA_KeyDown(sender As Object, e As KeyEventArgs) Handles TGUIA.KeyDown
        If e.KeyCode = 13 Then
            F1.Focus()
        End If
    End Sub
    Private Sub F1_KeyDown(sender As Object, e As KeyEventArgs) Handles F1.KeyDown
        If e.KeyCode = 13 Then
            F2.Focus()
        End If
    End Sub
    Private Sub F2_KeyDown(sender As Object, e As KeyEventArgs) Handles F2.KeyDown
        If e.KeyCode = 13 Then
            F3.Focus()
        End If
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click

        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportRelCobranza.mrt"
            If Not IO.File.Exists(RUTA_FORMATOS) Then
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
            StiReport1.Item("CVE_REL") = TCVE_REL.Text

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            If Fg.Rows.Count > 1 Then
                EXPORTAR_EXCEL_TRANSPORT(Fg, "Relación a cobranza " & TCVE_REL.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarDisenador_Click(sender As Object, e As ClickEventArgs) Handles BarDisenador.Click
        PrinterMRT("ReportRelCobranza")
    End Sub
End Class