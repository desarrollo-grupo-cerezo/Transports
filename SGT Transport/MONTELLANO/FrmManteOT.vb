Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmManteOT
    Private CADENA As String = ""

    Private Sub FrmManteOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
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

            LkGenMinveOT.Text = "Generar " & vbCrLf & "movs. inv. OT"
            Me.WindowState = FormWindowState.Maximized

            Fg.Rows.Count = 1
            Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - 50

            Fg.Cols.Count = 16

            TITULOS()

            Fg.FocusRect = FocusRectEnum.Solid


        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmManteOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Mantenimiento OT")
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor
        Fg.Rows.Count = 1

        Try
            SQL = "SELECT CVE_ORD, O.FECHA, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(O.COSTO,0) AS COST,
                ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa & " WHERE REFER LIKE '%OT' + O.CVE_ORD + '%' AND CVE_ART = O.CVE_ART AND 
                CVE_FOLIO = O.CVE_PROV),0) AS CANT_ENT,
                ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa & " WHERE REFER LIKE 'CCOT'+ O.CVE_ORD + '%' AND CVE_ART = O.CVE_ART AND 
                CVE_FOLIO = O.CVE_PROV),0) AS CANT_CANC, ISNULL(CVE_PROV,'') AS CVE_FOLIO, ISNULL(TIEMPO_REAL, '') AS REFER, ISNULL(O.STATUS, '') AS ST, 
                ISNULL(O.UUID,'') AS UID, O.CVE_ALM, A.DESCR AS DESCR_ALM
                FROM GCORDEN_TRA_SER_EXT O
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = O.CVE_ALM
                LEFT JOIN GCMECANICOS M ON M.CVE_MEC = O.CVE_MEC
                WHERE FECHA >= '" & FSQL(F1.Value) & "' AND FECHA <= '" & FSQL(F2.Value) & "' " & CADENA & " ORDER BY FECHAELAB"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ORD") & vbTab & dr("FECHA") & vbTab & dr("CLAVE") & vbTab & dr("DES") & vbTab & dr("CANTI") & vbTab &
                                   dr("CANT_ENT") & vbTab & dr("CANT_CANC") & vbTab & dr("COST") & vbTab & dr("CVE_FOLIO") & vbTab & dr("REFER") & vbTab &
                                   dr("ST") & vbTab & dr("UID") & vbTab & dr("CVE_ALM") & " " & dr("DESCR_ALM"))
                    End While
                End Using
            End Using

            Lt.Text = "Ordenes de trabajo " & Fg.Rows.Count - 1

            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "MANTE OT")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarGenMinveOT_Click(sender As Object, e As ClickEventArgs) Handles BarGenMinveOT.Click

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Sub TITULOS()

        Fg(0, 1) = "Clave"
        Dim cc1 As Column = Fg.Cols(1)
        cc1.DataType = GetType(String)

        Fg(0, 2) = "Fecha"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(DateTime)

        Fg(0, 3) = "Articulo"
        Dim c5 As Column = Fg.Cols(3)
        c5.DataType = GetType(String)

        Fg(0, 4) = "Descripcion"
        Dim c6 As Column = Fg.Cols(4)
        c6.DataType = GetType(String)

        Fg(0, 5) = "Cantidad"
        Dim c7 As Column = Fg.Cols(5)
        c7.DataType = GetType(Decimal)

        Fg(0, 6) = "Cantidad Minve"
        Dim c8 As Column = Fg.Cols(6)
        c8.DataType = GetType(Decimal)

        Fg(0, 7) = "Cantidad Minve. Canc."
        Dim c9 As Column = Fg.Cols(7)
        c9.DataType = GetType(Decimal)

        Fg(0, 8) = "Costo"
        Dim c10 As Column = Fg.Cols(8)
        c10.DataType = GetType(Decimal)
        Fg.Cols(8).Format = "###,###,##0.00"

        Fg(0, 9) = "Folio"
        Dim c11 As Column = Fg.Cols(9)
        c11.DataType = GetType(String)

        Fg(0, 10) = "Referencia"
        Dim c12 As Column = Fg.Cols(10)
        c12.DataType = GetType(String)

        Fg(0, 11) = "Estatus"
        Dim c13 As Column = Fg.Cols(11)
        c13.DataType = GetType(String)

        Fg(0, 12) = "UUID"
        Dim c14 As Column = Fg.Cols(12)
        c14.DataType = GetType(String)

        Fg(0, 13) = "Almacen"
        Dim c15 As Column = Fg.Cols(13)
        c15.DataType = GetType(String)


    End Sub

    Private Sub BarKardex_Click(sender As Object, e As ClickEventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 3) 'CVE_ART
                Var5 = Fg(Fg.Row, 5) 'CVE_ART
                If Var4.Trim.Length > 0 Then
                    frmKardex.ShowDialog()
                Else
                    MessageBox.Show("Por favor seleccione un artículo")
                End If
            End If
        Catch ex As Exception
            Bitacora("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CADENA = " AND (CVE_ORD LIKE '%" & tBox.Text & "%' OR UPPER(O.CVE_ART) LIKE '%" & tBox.Text & "%' OR 
               UPPER(I.DESCR) LIKE '%" & tBox.Text & "%' OR
               UPPER(O.CVE_PROV) LIKE '%" & tBox.Text & "%')"

            BarDesplegar_Click(Nothing, Nothing)

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
