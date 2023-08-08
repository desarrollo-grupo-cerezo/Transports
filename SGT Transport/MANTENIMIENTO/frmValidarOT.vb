Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmValidarOT
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CadenaSQL As String = ""
    Private Sub frmValidarOT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Fg.Rows.Count = 1
        Fg.Cols.Count = 15

        Fg.Rows(0).Height = 40
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - BarraMenu.Height

    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT O.CVE_ORD, CASE WHEN O.STATUS = 'C' THEN 'Cancelada' ELSE O.ESTATUS END AS 'Estatus', O.FECHA AS 'Fecha', " &
                "CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END AS 'Tipo servicio', O.CVE_UNI AS 'Unidad', " &
                "T.DESCR AS 'Tipo', P.NOMBRE AS 'Nombre', O.LUGAR_REP AS 'Lugar de reparación', O.NOTA AS 'Nota', " &
                "ISNULL(STUFF((SELECT ',' + TIEMPO_REAL FROM GCORDEN_TRA_SER_EXT S WHERE S.CVE_ORD = O.CVE_ORD AND CVE_ART = 'TOT' FOR XML PATH ('')),1,1, ''),'') AS TOT, " &
                "O.DOC_ANTR AS 'Remision' " &
                "FROM GCORDEN_TRABAJO_EXT O " &
                "LEFT JOIN GCUNIDADES U On U.CLAVE = O.CVE_UNI " &
                "LEFT JOIN CLIE" & Empresa & " P On P.CLAVE = O.CVE_PROV " &
                "LEFT JOIN GCTIPO_UNIDAD T On T.CVE_UNI = O.CVE_TIPO " &
                CadenaSQL & " ORDER BY CAST(O.CVE_ORD AS INT) DESC"

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

            Lt1.Text = "Ordenes de trabajo " & Fg.Rows.Count - 1

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmValidarOT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click

    End Sub
End Class
