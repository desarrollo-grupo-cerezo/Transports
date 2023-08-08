Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmPedidos
    Private CADENA As String = ""
    Private N_TOP As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '20 FEB 20
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

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

            DERECHOS()

            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg.Rows.Count = 1
            Fg.Cols.Count = 14

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg.AllowFiltering = True

            N_TOP = "TOP 5000"
            CADENA = " ORDER BY P.FECHAELAB DESC"

            DESPLEGAR()

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
            End If


        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False

            SQL = "SELECT " & N_TOP & " P.CVE_DOC, ISNULL(P.CVE_VIAJE,'') AS 'VIAJE', CASE WHEN P.STATUS = 'C' THEN 'CANCELADO' ELSE '' END, 
                P.NUM_TALON, P.NUM_TALON2, CT.NO_CONTRATO, C3.NOMBRE AS NOMBRE_CLIENTE, I.DESCR, I2.DESCR, P.FECHA, O.NOMBRE AS NOMBRE_OPER, P.CVE_TRACTOR, 
                P.CVE_TANQUE1, P.CVE_TANQUE2, RE.DESCR AS RECEN, EE.DESCR AS ENTEN, P.FECHA_CARGA, P.FECHA_DESCARGA,
                (SELECT IMPORTE FROM GCVALOR_DECLARADO E WHERE CLAVE = P.VALOR_DECLA) As 'Valor declarado', 
                ISNULL((SELECT TOP 1 TIMBRADA FROM GCCARTA_PORTE WHERE CVE_DOCP = P.CVE_DOC AND ISNULL(TIMBRADA,'') = 'S'),'') AS 'TIMBRADA',
                ISNULL((SELECT TOP 1 CASE WHEN CVE_DOCR = '0' THEN '' ELSE CVE_DOCR END AS CP FROM GCCARTA_PORTE WHERE CVE_FOLIO = P.NUM_TALON),'') AS 'Remisión',
                ISNULL((SELECT TOP 1 CASE WHEN CVE_DOCR = '0' THEN '' ELSE CVE_DOCR END AS CP  FROM GCCARTA_PORTE WHERE CVE_FOLIO = P.NUM_TALON2),'') AS 'Remisión',
                CASE WHEN ISNULL(CP_VIRTUAL,0) = 1 THEN 'Virtual' ELSE '' END AS 'Carta porte virtual'
                FROM GCPEDIDOS P 
                LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = P.NUM_TALON
                LEFT JOIN GCCONTRATO CT ON CT.CVE_CON = P.CVE_CON 
                LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = CT.CVE_ART 
                LEFT JOIN GCPRODUCTOS I2 ON I2.CVE_PROD = P.CVE_ART 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                LEFT JOIN GCCLIE_OP C3 ON C3.CLAVE = CT.NO_CONTRATO 
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN 
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN 
                " & CADENA
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg.AutoSizeCols()
            TITULOS()

            LtNUm.Text = "Registros encontrados " & Fg.Rows.Count - 1

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub TITULOS()
        Try
            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Viaje asignado"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estatus"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Carta porte"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Carta porte 2"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Cliente"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Nombre"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Producto en contrato"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Producto en pedido"
            Dim cc8 As Column = Fg.Cols(9)
            cc8.DataType = GetType(DateTime)

            Fg(0, 10) = "Fecha"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "Operador"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(String)

            Fg(0, 12) = "Tractor"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "Tanque1 "
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(String)

            Fg(0, 14) = "Tanque2"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(String)

            Fg(0, 15) = "Reecoger En"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "Entregar En"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(String)

            Fg(0, 17) = "Fecha de carga"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(DateTime)

            Fg(0, 18) = "Fecha de descarga"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(DateTime)

            Fg(0, 19) = "Flete mensual"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"


        Catch ex As Exception
        End Try
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarNuevo.Visible = False
                BarEdit.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                CLAVE >= 24000 AND CLAVE <= 24200"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 24040 'NUEVO
                                    BarNuevo.Visible = True
                                Case 24045 'EDIT
                                    BarEdit.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmPedidos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Pedidos")
        Me.Dispose()
    End Sub
    Private Sub frmPedidos_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4

                Case Keys.F5
                    barSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Try
            Var1 = "Nuevo"
            Var3 = ""
            FrmPedidosAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        Try
            Dim Nrow As Integer
            If Fg.Row > 0 Then
                Var1 = "Edit"
                Var2 = Fg(Fg.Row, 1) 'CVE_DOC PEDIDO
                Var3 = Fg(Fg.Row, 2) 'Viaje asignado
                Nrow = Fg.Row

                FrmPedidosAE.ShowDialog()
                DESPLEGAR()
                'Fg.TopRow = Nrow
                Fg.Row = Nrow
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PEDIDOS")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarRefrescar_Click(sender As Object, e As EventArgs) Handles BarRefrescar.Click
        N_TOP = "TOP 500"

        CADENA = " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
        DESPLEGAR()
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        N_TOP = ""
        CADENA = " WHERE FECHA = '" & FSQL(Date.Now) & "' ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " WHERE FECHA = '" & FSQL(dt) & "' ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""
        CADENA = " ORDER BY P.FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub ApplyAndFilter()
        Dim strArr As String() = Nothing
        Dim count As Integer = 0
        Dim splitchar As Char() = {" "c}

        If C1FlexGridSearchPanel1.Controls(0).Text.Contains(" ") Then
            strArr = C1FlexGridSearchPanel1.Controls(0).Text.Split(splitchar)

            For row As Integer = 1 To Fg.Rows.Count - 1
                Dim temp As Integer = 0

                For count = 0 To strArr.Length - 1

                    For col As Integer = 1 To Fg.Cols.Count - 1
                        Dim str As String = Fg(row, col).ToString().ToLower()

                        If str.Contains(strArr(count).ToLower()) Then
                            temp += 1
                            Exit For
                        End If
                    Next
                Next

                If temp <> 2 Then
                    Fg.Rows(row).Visible = False
                End If
            Next
        End If
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()

            Dim cs2 As CellStyle
            cs2 = Fg.Styles.Add("CS2")
            cs2.BackColor = Color.CornflowerBlue

            Select Case Fg(e.Row, 23)
                Case "Virtual"
                    Fg.SetCellStyle(e.Row, 1, cs2)
                    Fg.SetCellStyle(e.Row, 2, cs2)
                    Fg.SetCellStyle(e.Row, 3, cs2)
                    Fg.SetCellStyle(e.Row, 4, cs2)
                    Fg.SetCellStyle(e.Row, 5, cs2)
                    Fg.SetCellStyle(e.Row, 6, cs2)
                    Fg.SetCellStyle(e.Row, 7, cs2)
                    Fg.SetCellStyle(e.Row, 8, cs2)
                    Fg.SetCellStyle(e.Row, 9, cs2)
                    Fg.SetCellStyle(e.Row, 10, cs2)
                    Fg.SetCellStyle(e.Row, 11, cs2)
                    Fg.SetCellStyle(e.Row, 12, cs2)
                    Fg.SetCellStyle(e.Row, 13, cs2)
                    Fg.SetCellStyle(e.Row, 14, cs2)
                    Fg.SetCellStyle(e.Row, 15, cs2)
                    Fg.SetCellStyle(e.Row, 16, cs2)
                    Fg.SetCellStyle(e.Row, 17, cs2)
                    Fg.SetCellStyle(e.Row, 18, cs2)
            End Select
        End If
    End Sub
End Class
