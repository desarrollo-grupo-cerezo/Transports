Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmTabRutas
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmTabRutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True
            Fg.Rows.Count = 1
            Fg.Cols.Count = 17

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCTAB_RUTAS SET CVE_RUTA = ORIGEN WHERE ISNULL(CVE_RUTA,-1) = -1"
                cmd.CommandText = SQL
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Bitacora("14.1 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14.1 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, P1.CIUDAD AS ORIG, P2.CIUDAD AS DEST, " &
                "('(' + LTRIM(RTRIM(T.CLIENTE)) + ')  ' + ISNULL(NOMBRE,'')) AS NOMB, T.KM_RECO, T.COSTO_CASETAS, T.EJES, T.FLETE, T.SUELDO_OPER, 
                T.RENDIMIENTO, T.P_X_LITRO, T.LITROS_RUTA, T.COSTO_DISEL, (CASE T.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE,
                T.OBSER AS 'Observaciones'
                FROM GCTAB_RUTAS T
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.ORIGEN
                LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.DESTINO
                LEFT JOIN GCCLIE_OP C ON C.CLAVE = LTRIM(RTRIM(T.CLIENTE))
                WHERE T.STATUS = 'A' ORDER BY CVE_TAB DESC"
            '                "LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA " &
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Fecha"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(DateTime)

            Fg(0, 3) = "Tipo unidad"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Origen"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Destino"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Cliente"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "KM recorridos"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Fg(0, 8) = "Costo casetas"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Ejes"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Integer)

            Fg(0, 10) = "Flete"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Sueldo operador"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Rendimiento"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "P_X_LITRO"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "Litros x ruta"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Costo disel"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Tipo viaje"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)

            Fg.AutoSizeCols()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmTabRutas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Tabulador de rutas")
        Me.Dispose()
    End Sub
    Private Sub frmTabRutas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    barSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            msgbox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmTabRutasAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmTabRutasAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar el registro?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCTAB_RUTAS SET STATUS = 'B' WHERE CVE_TAB = " & Fg(Fg.Row, 1)
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se elimino satisfactoriamente")
                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Tabulador de rutas")
        Catch ex As Exception
        End Try
    End Sub
End Class
