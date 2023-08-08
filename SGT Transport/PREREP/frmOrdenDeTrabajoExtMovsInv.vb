Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmOrdenDeTrabajoExtMovsInv
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CadenaSQL As String = ""
    Private QueOT As String
    Private Sub frmOrdenDeTrabajoExtMovsInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            If Var16 = "OT" Then
                BarGenMinveOT.Visible = False
            Else
                BarGenMinveOT.Visible = True
            End If
            Me.KeyPreview = True

            Fg.Rows.Count = 1
            Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150
            'ORDE DE TRABAJO
            'Var15 = "EXTTOT"
            'Var16 = "OT"
            'GEN MINVE OT
            'Var15 = "EXTTOT"
            'Var16 = "MIOT"
            QueOT = Var16

            CadenaSQL = " WHERE FECHA = '" & FSQL(Date.Now) & "'"
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
                "CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END , O.CVE_UNI, " &
                "T.DESCR, P.NOMBRE, O.LUGAR_REP, O.NOTA, O.DOC_ANT, O.DOC_SIG " &
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

            Fg(0, 8) = "Lugar rep."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Nota"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Orden de compra"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Documento compra"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmOrdenDeTrabajoExtMovsInv_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Movs. Ordenes de Trabajo")
        Me.Dispose()
    End Sub
    Private Sub BarGenMinveOT_Click(sender As Object, e As EventArgs) Handles BarGenMinveOT.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var15 = "TOTEXT"
            Var2 = Fg(Fg.Row, 1)
            If Fg(Fg.Row, 2) = "CANCELADA" Then
                MsgBox("La orden de trabajo se encuentra cancelada")
            Else
                Try
                    If FORM_IS_OPEN("frmOrdenDeTrabajoExtAE") Then
                        If frmOrdenDeTrabajoExtAE.tCVE_ORD.Text = Var2 Then
                            frmOrdenDeTrabajoExtAE.Close()
                            'MainRibbonForm.Tab1.SelectedTab = frmMovsInvOT.frm
                        End If
                    End If
                Catch ex As Exception
                End Try

                BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                CREA_TAB(FrmMovsInvOT, "Movs. Inv. TOT")
            End If
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BarConsulTOT_Click(sender As Object, e As EventArgs) Handles BarConsulTOT.Click
        If Fg.Row > 0 Then
            Var1 = "Consul"
            Var15 = "TOTEXT"
            Var2 = Fg(Fg.Row, 1)
            If Fg(Fg.Row, 2) = "Cancelada" Then
                MsgBox("La orden de trabajo se encuentra cancelada")
            Else
                BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                CREA_TAB(FrmMovsInvOT, "Movs. Inv. TOT")
            End If
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        CadenaSQL = " WHERE FECHA = '" & FSQL(Date.Now) & "'"
        DESPLEGAR()
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        CadenaSQL = " WHERE FECHA = '" & FSQL(dt) & "'"
        DESPLEGAR()
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year
        DESPLEGAR()
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)

        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        CadenaSQL = ""
        DESPLEGAR()
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then

                Var1 = "Edit"
                Var15 = "TOTEXT"
                Var2 = Fg(Fg.Row, 1)
                If Fg(Fg.Row, 2) = "Cancelada" Then
                    MsgBox("La orden de trabajo se encuentra cancelada")
                Else
                    BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                    CREA_TAB(FrmMovsInvOT, "Movs. Inv. TOT")
                End If
            Else
                MsgBox("Por favor seleccione un registro")
            End If
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
               "DOC_ANTR LIKE '%" & tBox.Text & "%')"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRefrescar_Click(sender As Object, e As EventArgs) Handles BarRefrescar.Click
        DESPLEGAR()
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
