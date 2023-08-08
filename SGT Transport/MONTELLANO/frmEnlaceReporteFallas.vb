Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmEnlaceReporteFallas
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CadenaSQL As String = ""
    Private Sub frmEnlaceReporteFallas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)

            CadenaSQL = " WHERE F.STATUS <> 'B' AND ISNULL(P.CVE_UNI,'') <> '' AND ISNULL(P.CVE_ORD,'') = ''"
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT P.CVE_FALLA, F.FECHA, P.CVE_UNI, C.DESCR, P.DESCR_FALLA, (CASE P.FALLA WHEN 1 THEN 'Si' ELSE 'No' END) AS F1, P.UUID " &
                 "FROM GCREPORTE_FALLAS_PAR P " &
                 "INNER JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " & 
                 "LEFT JOIN GCREPORTE_FALLAS F ON F.CVE_FALLA = P.CVE_FALLA " &
                 "LEFT JOIN GCCLASIFIC_SERVICIOS C ON C.CVE_CLA = P.CVE_CLAS " &
                 CadenaSQL & " ORDER BY  CAST(P.CVE_FALLA AS INT) DESC "

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Lt.Text = "Registros encontrados " & Fg.Rows.Count - 1

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Fecha"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(DateTime)

            Fg(0, 3) = "Unidad"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Clase servicio"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Descripcion de la falla"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Falla"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg.Cols(7).Width = 0
            Fg.AutoSizeCols()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmEnlaceReporteFallas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarSeleccionar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSeleccionar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 7)
                Me.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarActualizar.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)

            tBox.Text = ""

            CadenaSQL = " WHERE F.STATUS <> 'B' AND ISNULL(P.CVE_UNI,'') <> '' AND FECHA >= '" & FSQL(dt) & "'"
            DESPLEGAR()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CadenaSQL = " WHERE (P.CVE_UNI LIKE '%" & tBox.Text & "%' OR C.DESCR LIKE '%" & tBox.Text & "%' OR " &
                   "P.DESCR_FALLA LIKE '%" & tBox.Text & "%') AND F.STATUS <> 'B' AND ISNULL(P.CVE_UNI,'') <> '' AND P.CVE_ORD = '' "
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                BarSeleccionar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception

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
