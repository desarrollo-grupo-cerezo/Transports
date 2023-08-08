Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class frmCotizador
    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub frmCotizador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            If Not Valida_Conexion() Then
                Me.Close()
                Return
            End If
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - 75

            SQL = ""
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmCotizador_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Cotizador")
        Me.Dispose()    
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            If SQL.Trim.Length = 0 Then
                SQL = "SELECT TOP 200 CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA, NUM_CIRCUITOS, FLETE_MENSUAL, " &
                    "(COSTO_OP_MENSUAL + COSTO_FIJO + DEPRECIACION) AS COSTO_TOTAL, UTILIDAD_NETA_MES, KMS_MENSUAL " &
                    "FROM GCCOTIZADOR F " &
                    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                    "ORDER BY FECHAELAB DESC"
            End If
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource
            ENCABEZADO()
            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ENCABEZADO()
        Try
            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Cliente"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Nombre"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Num. circuitos"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Flete mensual"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Costo total"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Utilidad neta mensual"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Kms. mensual"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                  "FROM GCCOTIZADOR F " &
                  "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                  "WHERE FECHA = '" & FSQL(Date.Now) & "' " &
                  "ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)
            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                "FROM GCCOTIZADOR F " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                "WHERE FECHA = '" & FSQL(dt) & "' " &
                "ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today

            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                "FROM GCCOTIZADOR F " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                "WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year &
                " ORDER BY FECHAELAB DESC"

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)
            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                "FROM GCCOTIZADOR F " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                "WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year &
                " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                "FROM GCCOTIZADOR F " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                "ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Nuevo"
                    Try
                        Var1 = "Nuevo"
                        SQL1 = SQL
                        BACKUPTXT("XTAB_CAPTION", "frmCotizaAE" & vbNewLine)
                        CREA_TAB(frmCotizaAE, "Cotización")
                    Catch ex As Exception
                        MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "Edit"
                    If Fg.Row > 0 Then
                        Var1 = "Edit"
                        Var2 = Fg(Fg.Row, 1)
                        Var3 = Fg(Fg.Row, 2) 'ESTATUS
                        SQL1 = SQL
                        If Var3 = "C" Then
                            MsgBox("Documento cancelado",, "Advertencia")
                        End If
                        BACKUPTXT("XTAB_CAPTION", "frmCotizaAE" & vbNewLine)
                        CREA_TAB(frmCotizaAE, "Cotización")
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case "Excel"
                    Try
                        EXPORTAR_EXCEL_TRANSPORT(Fg, "Cotizador")
                    Catch ex As Exception
                    End Try
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            SQL = "SELECT CVE_COT, F.STATUS, CLIENTE, NOMBRE, FECHA " &
                 "FROM GCCOTIZADOR F " &
                 "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE " &
                 "WHERE (CVE_COT LIKE '%" & tBox.Text & "%' OR CLIENTE LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%') " &
                 "ORDER BY FECHAELAB DESC"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
