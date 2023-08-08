Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Public Class FrmDetalladoCompras
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmDetalladoCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
    Private Sub FrmDetalladoCompras_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.WindowState = FormWindowState.Maximized
        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - 150
        Fg.Rows.Count = 1
        Fg.Cols.Count = 9

        BarDesplegar_Click(Nothing, Nothing)

        TITULOS()

    End Sub
    Private Sub FrmDetalladoCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Detallado compras")
        Me.Dispose()
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            Fg.Rows.Count = 1
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT CASE TIP_DOC WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' ELSE 'Recepción' END, 
                 CVE_DOC, ANT_SIG, CASE TIP_DOC_E WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Oeden de compra' ELSE 'Recepción' END, 
                 CVE_DOC_E, PARTIDA, PART_E, CANT_E 
                 FROM DOCTOSIGC" & Empresa & " ORDER BY CVE_DOC"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

        Catch ex As Exception
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("180. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try

            Fg(0, 1) = "Tipo documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Documento"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Anterior/Siguiente"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Tipo documento siguiente"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Documento siguiente"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Partida"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(Int32)

            Fg(0, 7) = "Partida siguiente"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(Int32)

            Fg(0, 8) = "Cantida siguiente"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Fg.Cols(6).Width = 80
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Detallado compras")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        BarDesplegar_Click(Nothing, Nothing)
    End Sub
End Class
