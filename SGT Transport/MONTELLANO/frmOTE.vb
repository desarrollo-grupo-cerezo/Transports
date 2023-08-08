Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmOTE
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CadenaSQL As String = ""
    Private QueOT As String
    Private SQLOT As String
    Private Sub frmOTE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            Me.WindowState = FormWindowState.Maximized
            Fg.Rows.Count = 1
            Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            QueOT = Var16 '= "MIOT"

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-15)

            CadenaSQL = " WHERE FECHA >= '" & FSQL(dt) & "' AND ISNULL(A_M,'') = 'M'"
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
            SQL = "SELECT O.CVE_ORD, CASE WHEN O.STATUS = 'C' THEN 'Cancelada' ELSE O.ESTATUS END, O.FECHA, " &
                "CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END , O.CVE_UNI AS UNIDAD, T.DESCR AS DESCRIP, P.NOMBRE, O.LUGAR_REP, O.NOTA, " &
                "ISNULL(STUFF((SELECT ',' + TIEMPO_REAL FROM GCORDEN_TRA_SER_EXT S WHERE S.CVE_ORD = O.CVE_ORD AND CVE_ART = 'TOT' FOR XML PATH ('')),1,1, ''),'') AS TOT, " &
                "O.DOC_ANTR, O.DOC_SIG, CASE WHEN ISNULL(A_M,'') = 'M' THEN 'Mantenimiento' ELSE '' END 'Tipo servicio', " &
                "(SELECT SU_REFER FROM COMPO" & Empresa & " WHERE CVE_DOC = " &
                "(SELECT TOP 1 TIEMPO_REAL FROM GCORDEN_TRA_SER_EXT S WHERE S.CVE_ORD = O.CVE_ORD And CVE_ART = 'TOT')) AS TOT " &
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

            Lt.Text = "Ordenes de trabajo " & Fg.Rows.Count - 1

            Fg(0, 1) = "Clave"
            Dim c1 As Column = Fg.Cols(1)
            c1.DataType = GetType(String)

            Fg(0, 2) = "Estatus"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Fecha"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(DateTime)

            Fg(0, 4) = "Tipo servicio"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int16)

            Fg(0, 5) = "Unidad"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Tipo"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Cliente"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Lugar de recepción"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Odómetro"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "TOT"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Remision"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "Doc. enlazado"
            Dim c12 As Column = Fg.Cols(11)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Tipo de servicio"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            Fg(0, 14) = "Factura prov."
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.BackColor = Color.Magenta
            NewStyle1.ForeColor = Color.Black

            'For k = 1 To Fg.Rows.Count - 1
            'If Fg(k, 13) = "Mantenimiento" Then
            'Fg.Rows(k).Style = NewStyle1
            'End If
            'Next
            Fg.AutoSizeCols()


        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmOTE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Mantenimiento Externo")
        Me.Dispose()
    End Sub

    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Nuevo"
                    Try
                        Var1 = "Nuevo"
                        Var3 = ""

                        CREA_TAB(frmOTEAE, "Orden de Trabajo Externa")
                    Catch ex As Exception
                        MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "Edit"
                    BarEdit_Click(Nothing, Nothing)

                Case "Refrescar"
                    Try
                        Dim dt As DateTime = Date.Today
                        dt = dt.AddDays(-15)

                        CadenaSQL = " WHERE FECHA >= '" & FSQL(dt) & "' AND ISNULL(A_M,'') = 'M'"
                        DESPLEGAR()
                    Catch ex As Exception

                    End Try
                Case "Excel"
                    Try
                        EXPORTAR_EXCEL_TRANSPORT(Fg, "MANTENIMIENTO EXTERNO")
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

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        CadenaSQL = " WHERE FECHA = '" & FSQL(Date.Now) & "' And ISNULL(A_M,'') = 'M'"
        DESPLEGAR()
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        CadenaSQL = " WHERE FECHA = '" & FSQL(dt) & "' AND ISNULL(A_M,'') = 'M'"
        DESPLEGAR()
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " AND ISNULL(A_M,'') = 'M'"
        DESPLEGAR()
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)

        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " AND ISNULL(A_M,'') = 'M'"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        CadenaSQL = " WHERE ISNULL(A_M,'') = 'M'"
        DESPLEGAR()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            BarEdit_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CadenaSQL = " WHERE (CVE_ORD LIKE '%" & tBox.Text & "%' OR O.CVE_UNI LIKE '%" & tBox.Text & "%' OR " &
               "T.DESCR LIKE '%" & tBox.Text & "%' OR NOMBRE LIKE '%" & tBox.Text & "%' OR " &
               "LUGAR_REP LIKE '%" & tBox.Text & "%' OR NOTA LIKE '%" & tBox.Text & "%' OR " &
               "DOC_ANTR LIKE '%" & tBox.Text & "%')  AND ISNULL(A_M,'') = 'M'"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 1)
            Var3 = Fg(Fg.Row, 2)

            If Fg(Fg.Row, 2) = "Cancelada" Then
                MsgBox("La orden de trabajo se encuentra cancelada")
            End If
            CREA_TAB(frmOTEAE, "Orden de Trabajo Externa")
        Else
            MsgBox("Por favor seleccione un registro")
        End If
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
