Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmAltaCxC
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmAltaCxC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Fg.Redraw = False

            SQL = "SELECT TOP 3000 D.CVE_CLIE, P.NOMBRE, D.REFER, D.REFER, CASE D.SIGNO WHEN 1 THEN 'Cargo' ELSE 'Abono' END, D.IMPORTE, D.FECHA_APLI, " &
                "CON_REFER, D.NUM_CPTO, DESCR " &
                "FROM CUEN_DET" & Empresa & " D " &
                "LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE " &
                "LEFT JOIN CONP" & Empresa & " C ON C.NUM_CPTO = D.NUM_CPTO " &
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

        Fg.Redraw = True
    End Sub
    Sub ENCABEZADO()
        Try
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 100

            Fg(0, 1) = "Cliente"
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
    Private Sub frmAltaCxC_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    barNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    barEdit_Click(Nothing, Nothing)
                Case Keys.F5
                    barSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAltaCxC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Alta CxC")
        Me.Dispose()
    End Sub

    Private Sub barNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            Var1 = "Nuevo"

            FrmPagoMultidocCxC.ShowDialog()
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEdit_Click(sender As Object, e As EventArgs)
        'If Fg.Row > 0 Then
        '    Var1 = "Edit"
        '    Var2 = Fg(Fg.Row, 1)
        '    frmAltaCxCAE.ShowDialog()
        '    DESPLEGAR()
        'Else
        '    MsgBox("Por favor seleccione un registro")
        'End If
    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub

    Private Sub BarRefresch_Click(sender As Object, e As EventArgs) Handles BarRefresch.Click
        DESPLEGAR()
    End Sub
End Class
