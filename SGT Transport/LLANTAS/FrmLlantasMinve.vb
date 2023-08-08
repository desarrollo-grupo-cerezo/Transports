Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmLlantasMinve
    Private BindingSource1 As BindingSource = New BindingSource
    Private Sub FrmLlantasMinve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 1

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 100
            FgPanelBuscar.Left = Me.Width - FgPanelBuscar.Width - 100
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmLlantasMinve_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        DESPLEGAR2()

        Fg.Cols(1).Width = 90
        Fg.Cols(11).Width = 0
    End Sub
    Sub DESPLEGAR2()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            BarDesplegar.Enabled = False
            Fg.Cursor = Cursors.WaitCursor
            Me.Cursor = Cursors.WaitCursor
            Fg.Redraw = False

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            SQL = "SELECT TOP 10000 CASE M.TIP_DOC WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' ELSE 'Movs. inv.' END AS 'Tipo movimiento', 
                M.CVE_DOC as 'Documento', M.FECHA as 'Fecha', LL.CVE_ART as 'Artículo', I.DESCR as 'Descripción', M.CVE_UNI AS 'Unidad', 
                M.NUM_ECONOMICO as 'Num. económico', CASE TIP_DOC WHEN 'c' THEN ISNULL(M.SIGNO,1) ELSE ISNULL(M.SIGNO,-1) END AS 'Cantidad', 
                M.COSTO as 'Costo', C.DESCR AS 'Estatus llanta',
                M.USUARIO as 'Usuario', M.UUID 
                FROM GCLLANTAS_MINVE M
                LEFT JOIN GCLLANTAS LL ON LL.NUM_ECONOMICO = M.NUM_ECONOMICO
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = LL.CVE_ART
                LEFT JOIN GCLLANTAS_CONM C ON C.CVE_CPTO = M.CVE_CPTO
                ORDER BY M.FECHAELAB DESC"

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Try
                Dim c9 As Column = Fg.Cols(9)
                c9.DataType = GetType(Decimal)

                Fg.Cols(9).Format = "###,###,##0.00"
                Fg.Cols(11).Width = 0
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        BarDesplegar.Enabled = True
        'Me.Refresh()
    End Sub
    Private Sub FrmLlantasMinve_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Movs. inv. llantas")
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Movimientos al inventario llantas")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click
        Try
            FrmLlantasMinveAE.ShowDialog()
            DESPLEGAR2()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        DESPLEGAR2()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR2()
    End Sub
End Class
