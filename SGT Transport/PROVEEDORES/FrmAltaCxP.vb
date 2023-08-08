Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmAltaCxP
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CADENA As String

    Private Sub frmAltaCxP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True

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


            CADENA = ""

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try

            SQL = "SELECT TOP 500 D.CVE_PROV, P.NOMBRE, D.REFER, D.REFER, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI, " &
                "CON_REFER, D.NUM_CPTO, DESCR, NO_PARTIDA " &
                "FROM PAGA_DET" & Empresa & " D " &
                "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = D.CVE_PROV " &
                "LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO " &
                CADENA &
                "ORDER BY FECHAELAB DESC"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            ENCABEZADO()

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ENCABEZADO()
        Try
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 100

            Fg(0, 1) = "Proveedor"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Nombre"
            Dim c2 As Column = Fg.Cols(1)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Documento"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Referencia"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Tipo de movimiento"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Importe"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Decimal)
            Fg.Cols(6).Format = "###,###,##0.00"

            Fg(0, 7) = "Fecha"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Con referencia"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Int32)

            Fg(0, 9) = "Concepto"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Int32)

            Fg(0, 10) = "Descripción"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Int32)


        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"
            frmAltaCxPAE.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            msgbox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs)
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            frmAltaCxPAE.ShowDialog()
            DESPLEGAR()
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub frmAltaCxP_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    barCancelar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmAltaCxP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Alta CxP")
        Me.Dispose()
    End Sub
    Private Sub barActualizar_Click(sender As Object, e As EventArgs) Handles barActualizar.Click
        Try
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barCancelar_Click(sender As Object, e As EventArgs) Handles barCancelar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea cancelar el abono del proveedor?", vbYesNo) = vbYes Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "DELETE FROM PAGA_DET" & Empresa &
                            " WHERE CVE_PROV = '" & Fg(Fg.Row, 1) & "' AND REFER = '" & Fg(Fg.Row, 3) & "' AND NO_PARTIDA = " & Fg(Fg.Row, 11)
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                '                   IMPORTE       FACTURA        PROV
                                UPDATE_DATOS_PROV(Fg(Fg.Row, 6), Fg(Fg.Row, 3), Fg(Fg.Row, 1), " + ")

                                MsgBox("El abono de cancelo satisfactoriamente")
                                DESPLEGAR()
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        CADENA = " WHERE FECHA_APLI = '" & FSQL(Date.Now) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        CADENA = " WHERE FECHA_APLI = '" & FSQL(dt) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today

        CADENA = " WHERE MONTH(FECHA_APLI) = " & dt.Month & " AND YEAR(FECHA_APLI) = " & dt.Year
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)

        CADENA = " WHERE MONTH(FECHA_APLI) = " & dt.Month & " AND YEAR(FECHA_APLI) = " & dt.Year
        DESPLEGAR()
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        CADENA = ""
        DESPLEGAR()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            CADENA = "WHERE A.FECHA_APLI >= '" & FSQL(F1.Value) & "' AND A.FECHA_APLI <= '" & FSQL(F2.Value) & "'"

            DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
