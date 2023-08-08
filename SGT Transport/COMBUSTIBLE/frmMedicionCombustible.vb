Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmMedicionCombustible
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmMedicionCombustible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
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
            'Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - barSalir.Height - 40

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

        Fg.Redraw = False
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT M.CLAVE, U.CLAVEMONTE, O.NOMBRE, M.STATUS, M.FECHA, 
                CASE ISNULL(TIPO_LITROS, -1) WHEN 0 THEN 'Litros Entrada' WHEN 1 THEN 'Litros salida' ELSE '' END AS TIP_LITROS, 
                ISNULL(LITROS,0) AS LTS, M.TANQUE1_CM, M.TANQUE1_LT, M.TANQUE2_CM, M.TANQUE2_LT, M.SUMA, CVE_RES 
                FROM GCMEDICIONCOMBUSTIBLE M 
                LEFT JOIN GCUNIDADES U ON U.CLAVE = M.CVE_UNI 
                LEFT JOIN GCOPERADOR O ON O.CLAVE = M.CVE_OPER 
                WHERE M.STATUS = 'A' ORDER BY CLAVE DESC"
            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            TITULOS()

            Fg.Cols(1).Width = 40 : Fg.Cols(2).Width = 55 : Fg.Cols(3).Width = 250 : Fg.Cols(4).Width = 45 : Fg.Cols(5).Width = 70
            Fg.Cols(6).Width = 80 : Fg.Cols(7).Width = 70 : Fg.Cols(8).Width = 70 : Fg.Cols(9).Width = 70 : Fg.Cols(10).Width = 70
            Fg.Cols(11).Width = 70 : Fg.Cols(12).Width = 70 : Fg.Cols(13).Width = 70

            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Sub TITULOS()
        Try
            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int16)

            Fg(0, 2) = "Unidad"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Operador"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)
            c4.TextAlign = TextAlignEnum.CenterCenter

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)
            c5.TextAlign = TextAlignEnum.CenterCenter

            '------ 2 nuevas columnas
            Fg(0, 6) = "Tipo litros"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Litros"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"
            '-----fin 2 columnas

            Fg(0, 8) = "Tanque 1 cm"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg(0, 9) = "Tanque 1 Lts."
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Tanque 2 cm"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Tanque 2 Lts"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Total litros"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "######0"

            Fg(0, 13) = "Clave reseteo"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "######0"

        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmMedicionCombustible_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Medición de Combustible")
        Me.Dispose()
    End Sub

    Private Sub frmMedicionCombustible_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            If TIPO_MEDICION_COMBUSTIBLE = 0 Then
                frmMedicionCombustibleAE.ShowDialog()
            Else
                frmMedCombus2021AE.ShowDialog()
            End If

            DESPLEGAR()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)

            If TIPO_MEDICION_COMBUSTIBLE = 0 Then
                frmMedicionCombustibleAE.ShowDialog()
            Else
                frmMedCombus2021AE.ShowDialog()
            End If
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg(Fg.Row, 15).ToString.Length > 0 Then
                MsgBox("La medición de combustible actualmente se encuentra enlazado a un reseteo, no es posible cancelar")
                Return
            End If
        Catch ex As Exception
        End Try
        Try
            If Fg(Fg.Row, 2).ToString = "FINALIZADA" Then
                MsgBox("La medición de combustible actualmente se encuentra Finalizada, no es posible cancelar")
                Return
            End If
        Catch ex As Exception
        End Try

        Try
            If MsgBox("Realmente desea cancelar la medición de combustible?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET STATUS = 'B', CVE_RES = 0 WHERE CLAVE = '" & Fg(Fg.Row, 1) & "'"
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
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "MEDICION COMBUSTIBLE")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
