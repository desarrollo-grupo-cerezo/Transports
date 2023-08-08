Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmControlLlantas
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmControlLlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub FrmControlLlantas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        DESPLEGAR
    End Sub
    Sub DESPLEGAR()
        Try
            SQL = "SELECT CVE_UNI AS 'Unidad', NUM_ECONOMICO AS 'Núm. económico', POSICION AS 'Posición', CVE_LLANTA AS 'Clave llanta', 
                CASE TIPO_MOV WHEN 1 THEN 'Montada' WHEN 2 THEN 'Desmontada' ELSE '' END AS 'Estado', 
                USUARIO AS 'Usuario', FORMAT(FECHAELAB ,'dd/MM/yyyy hh:mm:ss') AS 'Fecha' FROM GCLLANTAS_ASIG ORDER BY NUM_ECONOMICO, FECHAELAB"

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

        Catch ex As Exception
            MessageBox.Show("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarXls_Click(sender As Object, e As EventArgs) Handles BarXls.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Llantas control")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmControlLlantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Control llantas")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        DESPLEGAR()
    End Sub
End Class
