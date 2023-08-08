Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmValidaFacturas
    Dim CADENA As String
    Private Sub frmValidaFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

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

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 20
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 100

            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "'"

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If Not pwPoder Then
                'barNueva.Visible = IIf(C21, True, False)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR(fOp As Integer)
        If Not Valida_Conexion() Then
            Return
        End If
        Fg.Rows.Count = 1
        Try
            SQL = "SELECT C.CVE_DOC, C.CVE_CLPV, NOMBRE, CASE C.STATUS WHEN 'E' THEN 'Emitida' WHEN 'O' THEN 'Emitida' WHEN 'C' THEN 'Cancelada' END AS ST, " &
                "C.CVE_PEDI, C.FECHA_DOC, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.DES_TOT, " &
                "C.IMPORTE " &
                "FROM FACTF" & Empresa & " C " &
                "LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                "LEFT JOIN FACTF" & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = C.CVE_DOC " &
                CADENA & " ORDER BY FECHAELAB DESC"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab & dr("ST") & vbTab & dr("CVE_PEDI") & vbTab &
                                   dr("FECHA_DOC") & vbTab & dr("CAN_TOT") & vbTab &
                                   dr("IMP_TOT1") & vbTab & dr("IMP_TOT2") & vbTab & dr("IMP_TOT3") & vbTab & dr("IMP_TOT4") & vbTab & dr("DES_TOT") & vbTab &
                                   dr("IMPORTE") & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "")
                        BUSCAR_VENTA(dr("CVE_DOC"), Fg.Rows.Count - 1)
                    End While
                End Using
            End Using

            Fg(0, 1) = "Documento"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Cliente"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Referencia"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Subtotal"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Impuesto1"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Impuesto2"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Impuesto 3"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Impuesto 4"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Descuento"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Importe"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Sub-total"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "IEPS"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "IVA"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Importe"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg.Cols(1).Width = 110 : Fg.Cols(2).Width = 50 : Fg.Cols(4).Width = 60 : Fg.Cols(5).Width = 70 : Fg.Cols(6).Width = 70 : Fg.Cols(7).Width = 70 : Fg.Cols(8).Width = 60
            Fg.Cols(9).Width = 40 : Fg.Cols(10).Width = 40 : Fg.Cols(11).Width = 60 : Fg.Cols(12).Width = 50 : Fg.Cols(13).Width = 90

            Dim CustomStyle As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add("CustomStyle")
            CustomStyle.BackColor = Color.Orange

            Dim s1 As Decimal, s2 As Decimal
            Dim i11 As Decimal, i12 As Decimal
            Dim i41 As Decimal, i42 As Decimal
            Dim t1 As Decimal, t2 As Decimal
            Dim Sigue As Boolean

            For k = 1 To Fg.Rows.Count - 1
                s1 = Math.Truncate(Fg(k, 7) * 100 / 100)
                s2 = Math.Truncate(Fg(k, 14) * 100 / 100)
                i11 = Math.Truncate(Fg(k, 8) * 100 / 100)
                i12 = Math.Truncate(Fg(k, 15) * 100 / 100)
                i41 = Math.Truncate(Fg(k, 11) * 100 / 100)
                i42 = Math.Truncate(Fg(k, 16) * 100 / 100)
                t1 = Math.Truncate(Fg(k, 13) * 100 / 100)
                t2 = Math.Truncate(Fg(k, 17) * 100 / 100)
                Sigue = False
                If s1 <> s2 Then
                    If Math.Abs(s1 - s2) > 1 Then
                        Fg.SetCellStyle(k, 7, CustomStyle)
                        Sigue = True
                    End If
                End If
                If i11 <> i12 Then
                    If Math.Abs(i11 - i12) > 1 Then
                        Fg.SetCellStyle(k, 8, CustomStyle)
                        Sigue = True
                    End If
                End If
                If i41 <> i42 Then
                    If Math.Abs(i41 - i42) > 1 Then
                        Fg.SetCellStyle(k, 11, CustomStyle)
                        Sigue = True
                    End If
                End If
                If t1 <> t2 Then
                    If Math.Abs(t1 - t2) > 1 Then
                        Fg.SetCellStyle(k, 13, CustomStyle)
                        Sigue = True
                    End If
                End If
                If fOp = 2 Then
                    If Not Sigue Then
                        Fg.Rows(k).Visible = False
                    Else
                        Fg(k, 18) = ">"
                    End If
                End If
            Next

            Fg.AutoSizeRows()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmValidaFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Validar facturas")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "DOCUMENTOS")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub btnDesplegar_Click(sender As Object, e As EventArgs) Handles btnDesplegar.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR(1)
        Catch ex As Exception
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub BUSCAR_VENTA(fCVE_DOC As String, frow As Integer)
        Dim PREC As Single, IEPS As Single, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single
        Dim IMPORTE As Decimal = 0, CAN_TOT As Decimal = 0, IMP_TOT1 As Decimal = 0, IMP_TOT4 As Decimal = 0

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.Connection = cnSAE
        Try
            SQL = "SELECT P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA, EXIST, " &
                "ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, NUM_PAR, ISNULL(PXS,0) AS P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM,1) AS NUMALM, " &
                "ISNULL(P.DESC1,0) AS D1, ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, F.FECHA_DOC, F.FECHAELAB, " &
                "F.CVE_CLPV, C.NOMBRE, C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,  " &
                "ISNULL(CAMPLIB1, '') AS LIB1, ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, " &
                "ISNULL(F.CVE_OBS,0) AS CVE_OBS_DOC, ISNULL(O.STR_OBS,'') AS S_OBS_DOC, ISNULL(P.CVE_OBS,0) AS CVE_OBS_PAR, ISNULL(O2.STR_OBS,'') AS S_OBS_PAR " &
                "FROM PAR_FACTF" & Empresa & " P " &
                "LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC " &
                "LEFT JOIN FACTF" & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = P.CVE_DOC " &
                "LEFT JOIN OBS_DOCF" & Empresa & " O ON O.CVE_OBS = F.CVE_OBS " &
                "LEFT JOIN OBS_DOCF" & Empresa & " O2 ON O2.CVE_OBS = P.CVE_OBS " &
                "LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR " &
                "LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV " &
                "LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                PREC = dr("PREC")
                PREC = Math.Round(PREC, 4)
                DESCP = PREC * dr("DESC1") / 100
                IEPS = dr("IMPU1")
                cIEPS = (PREC - DESCP - DESCP2) * IEPS / 100
                IMPU = dr("IMPU4")
                cIMPU = (PREC - DESCP - DESCP2 + cIEPS) * IMPU / 100
                PrecioVenta = PREC - DESCP - DESCP2 + cIEPS + cIMPU

                IMPORTE = IMPORTE + (PrecioVenta * dr("CANT"))
                CAN_TOT = CAN_TOT + (PREC * dr("CANT"))
                IMP_TOT1 = IMP_TOT1 + (cIEPS * dr("CANT"))
                IMP_TOT4 = IMP_TOT4 + (cIMPU * dr("CANT"))
            Loop
            Try
                Fg(frow, 14) = Math.Truncate(CAN_TOT / 1000 * 1000)
                Fg(frow, 15) = Math.Truncate(IMP_TOT1 / 1000 * 1000)
                Fg(frow, 16) = Math.Truncate(IMP_TOT4 / 1000 * 1000)
                Fg(frow, 17) = Math.Truncate(IMPORTE / 1000 * 1000)

            Catch ex As Exception
            End Try
        Catch ex As Exception
            Bitacora("61. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDesplegar2_Click(sender As Object, e As EventArgs) Handles BtnDesplegar2.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            DESPLEGAR(2)
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Try
            If MsgBox("Realmente desea actualizar las facturas incorrectas?", vbYesNo) = vbNo Then
                Return
            End If
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 18) = ">" Then
                    Try
                        SQL = "UPDATE FACTF" & Empresa & " SET CAN_TOT = " & Fg(k, 14) & ",IMP_TOT1 = " & Fg(k, 15) & ",IMP_TOT4 = " & Fg(k, 16) &
                            ",IMPORTE = " & Fg(k, 17) & " WHERE CVE_DOC = '" & Fg(k, 1) & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Fg(k, 19) = "OK"
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            Bitacora("450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarOT_Click(sender As Object, e As EventArgs) Handles BarOT.Click

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Fg.Rows.Count = 1
        Fg.Cols.Count = 15
        DESPLEGAR()

    End Sub

    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_ORD As String, CADENA As String, CVE_ART As String

        Try
            SQL = "SELECT O.CVE_ORD, O.STATUS, FECHAELAB, CVE_ART, CANT " &
                "FROM GCORDEN_TRA_SER_EXT O " &
                "WHERE FECHAELAB BETWEEN '" & FSQL(F1.Value) & " 00:00:00' AND '" & FSQL(F2.Value) & " 23:59:59' AND STATUS = ''"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CVE_ORD = dr("CVE_ORD")
                        CVE_ART = dr("CVE_ART")
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand

                            SQL = "SELECT * FROM MINVE" & Empresa & " WHERE REFER Like '%" & CVE_ORD & "' AND CVE_ART = '" & CVE_ART & "'"

                            cmd2.CommandText = SQL
                            CADENA = ""
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                While dr2.Read
                                    CADENA = CADENA & "->" & dr2.ReadNullAsEmptyString("REFER") & vbTab & dr2.ReadNullAsEmptyString("CVE_ART")
                                End While
                            End Using
                        End Using
                        If CADENA.Trim.Length > 0 Then
                            Fg.AddItem("" & vbTab & dr("CVE_ORD") & vbTab & dr("STATUS") & vbTab & dr("FECHAELAB") & vbTab & dr("CVE_ART") & vbTab & dr("CANT") & vbTab & CADENA)
                        End If
                    End While
                End Using
            End Using

            Lt1.Text = "Ordenes de trabajo " & Fg.Rows.Count - 1

            Fg.AutoSizeCols()

            MsgBox("Proceso terminado")
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class
