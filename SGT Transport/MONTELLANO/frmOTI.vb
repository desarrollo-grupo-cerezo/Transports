Imports System.Data.SqlClient
Imports C1.Win.C1Command
Public Class frmOTI
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private CadenaSQL As String = ""
    Private QueOT As String
    Private N_TOP As String
    Private SQLOT As String
    Private Sub frmOTI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try

            LkGenMinveOT.Text = "Generar " & vbCrLf & "movs. inv. OT"
            Me.WindowState = FormWindowState.Maximized
            If Var16 = "OT" Then
                BarGenMinveOT.Visible = False
            Else
                BarNuevo.Visible = False
                BarEdit.Visible = False
                BarGenMinveOT.Visible = True
            End If
            Me.KeyPreview = True

            Fg.Rows.Count = 1
            Fg.Cols.Count = 15

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - 50

            'BarGenMinveOT.Text = "Generar movs. inv.OT"

            QueOT = Var16 '= "MIOT"

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-7)

            N_TOP = " TOP 1500 "

            'CadenaSQL = " WHERE FECHA >= '" & FSQL(dt) & "' AND ISNULL(A_M,'') <> 'M'"
            CadenaSQL = " WHERE ISNULL(A_M,'') <> 'M'"

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
            ',STUFF((SELECT ',' + TIEMPO_REAL FROM GCORDEN_TRA_SER_EXT S WHERE S.CVE_ORD = O.CVE_ORD AND CVE_ART = 'TOT' FOR XML PATH ('')),1,1, '') AS TOT,
            'o.DOC_ANTR AS 'Remision'

            SQLOT = "SELECT " & N_TOP & " O.CVE_ORD as 'Orden', CASE WHEN O.STATUS = 'C' THEN 'Cancelada' ELSE O.ESTATUS END AS 'Estatus', O.FECHA AS 'Fecha',
                CASE WHEN O.TIPO_SERVICIO = 0 THEN 'Preventivo' ELSE 'Correctivo' END AS 'Tipo servicio', O.CVE_UNI AS 'Unidad',
                T.DESCR AS 'Tipo', P.NOMBRE AS 'Nombre', O.LUGAR_REP AS 'Lugar de reparación', O.NOTA AS 'Nota'
                FROM GCORDEN_TRABAJO_EXT O
                LEFT JOIN GCUNIDADES U On U.CLAVE = O.CVE_UNI
                LEFT JOIN CLIE" & Empresa & " P On P.CLAVE = O.CVE_PROV
                LEFT JOIN GCTIPO_UNIDAD T On T.CVE_UNI = O.CVE_TIPO " &
                CadenaSQL & " ORDER BY TRY_PARSE(O.CVE_ORD AS INT) DESC"

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQLOT, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Lt.Text = "Ordenes de trabajo " & Fg.Rows.Count - 1

            Fg.AutoSizeCols()

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmOTI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Ordenes de Trabajo")
        Me.Dispose()
    End Sub
    Private Sub BarCorregirMinveOT_Click(sender As Object, e As ClickEventArgs) Handles BarManteOT.Click
        CREA_TAB(FrmManteOT, "Mantenimiento OT")

    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Nuevo"
                    Try
                        Var1 = "Nuevo"
                        Var3 = ""
                        'If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                        CREA_TAB(frmOTI_GMAE, "Orden de Trabajo")
                        'Else
                        'CREA_TAB(frmOTIAE, "Orden de Trabajo")
                        'End If

                    Catch ex As Exception
                        MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "Edit"
                    If Fg.Row > 0 Then
                        Var1 = "Edit"
                        Var2 = Fg(Fg.Row, 1)
                        Var3 = Fg(Fg.Row, 2)

                        If Fg(Fg.Row, 2) = "Cancelada" Then
                            MsgBox("La orden de trabajo se encuentra cancelada")
                        Else
                            Try
                                If FORM_IS_OPEN("frmMovsInvOT") Then
                                    If FrmMovsInvOT.tCVE_ORD.Text = Var2 Then
                                        FrmMovsInvOT.Close()
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        End If

                        'If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then
                        CREA_TAB(frmOTI_GMAE, "Orden de Trabajo")
                        'Else
                        'CREA_TAB(frmOTIAE, "Orden de Trabajo")
                        'End If
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case "Generar movs. inv.  OT"
                    If Fg.Row > 0 Then
                        Var1 = "Edit"
                        Var15 = "TOTEXT"
                        Var2 = Fg(Fg.Row, 1)
                        If Fg(Fg.Row, 2) = "CANCELADA" Then
                            MsgBox("La orden de trabajo se encuentra cancelada")
                        Else
                            BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                            CREA_TAB(FrmMovsInvOT, "Movs. Inv. TOT")
                        End If
                    Else
                        MsgBox("Por favor seleccione un registro")
                    End If
                Case "Refrescar"
                    Dim dt As DateTime = Date.Today
                    dt = dt.AddDays(-7)

                    N_TOP = " TOP 1500 "
                    tBox.Text = ""
                    CadenaSQL = " WHERE ISNULL(A_M,'') <> 'M'"
                    DESPLEGAR()
                Case "Consulta TOT"
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
                Case "Excel"
                    Try
                        EXPORTAR_EXCEL_TRANSPORT(Fg, "ORDENES DE TRABAJO")
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
    Private Function ORDEN_DE_TRABAJO_COMPRA_GENERADA(fCVE_DOC_RECEP As String) As String
        Dim DOC As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_DOC FROM COMPC" & Empresa & " WHERE DOC_ANT = '" & fCVE_DOC_RECEP & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        DOC = dr("CVE_DOC")
                    End If
                End Using
            End Using
            Return DOC
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return DOC
        End Try
    End Function
    Private Function RECEPCION_ORDEN_DE_TRABAJO(fCVE_DOC_RECEP As String) As String
        Dim DOC As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(STATUS,'') AS ST FROM COMPR" & Empresa & " WHERE DOC_DOC = '" & fCVE_DOC_RECEP & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        DOC = dr("STATUS")
                    End If
                End Using
            End Using
            Return DOC
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Return DOC
        End Try
    End Function
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        N_TOP = ""
        CadenaSQL = " WHERE FECHA = '" & FSQL(Date.Now) & "' AND ISNULL(A_M,'') <> 'M'"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-7)
        N_TOP = ""
        CadenaSQL = " WHERE FECHA = '" & FSQL(dt) & "' AND ISNULL(A_M,'') <> 'M'"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " AND ISNULL(A_M,'') <> 'M'"
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""
        CadenaSQL = " WHERE MONTH(FECHA) = " & dt.Month & " AND YEAR(FECHA) = " & dt.Year & " AND ISNULL(A_M,'') <> 'M'"
        DESPLEGAR()
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""
        CadenaSQL = " WHERE ISNULL(A_M,'') <> 'M'"
        DESPLEGAR()
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                If QueOT = "OT" Then
                    Var1 = "Edit"
                    Var2 = Fg(Fg.Row, 1)
                    Var3 = Fg(Fg.Row, 2)
                    If Fg(Fg.Row, 2) = "Cancelada" Then
                        MsgBox("La orden de trabajo se encuentra cancelada")
                    End If
                    CREA_TAB(FrmOTIAE, "Orden de Trabajo")

                Else
                    Var1 = "Edit"
                    Var15 = "TOTEXT"
                    Var2 = Fg(Fg.Row, 1)
                    If Fg(Fg.Row, 2) = "Cancelada" Then
                        MsgBox("La orden de trabajo se encuentra cancelada")
                    Else
                        BACKUPTXT("XTAB_CAPTION", "Tabuladores Inventario-movs al inv." & vbNewLine)
                        CREA_TAB(FrmMovsInvOT, "Movs. Inv. TOT")
                    End If
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
            N_TOP = ""
            CadenaSQL = " WHERE (CVE_ORD LIKE '%" & tBox.Text & "%' OR UPPER(O.CVE_UNI) LIKE '%" & tBox.Text & "%' OR 
               UPPER(O.ESTATUS) LIKE '%" & tBox.Text & "%' OR
               UPPER(T.DESCR) LIKE '%" & tBox.Text & "%' OR UPPER(NOMBRE) LIKE '%" & tBox.Text & "%' OR
               UPPER(LUGAR_REP) LIKE '%" & tBox.Text & "%' OR UPPER(NOTA) LIKE '%" & tBox.Text & "%' OR
               UPPER(DOC_ANTR) LIKE '%" & tBox.Text & "%')  AND ISNULL(A_M,'') <> 'M'"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Private Sub Fg_KeyUp(sender As Object, e As KeyEventArgs) Handles Fg.KeyUp
        If e.KeyCode = Keys.Left Then
            tBox.Focus()
        End If
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As ClickEventArgs) Handles BarEdit.Click

    End Sub

    Private Sub BarNuevo_Click(sender As Object, e As ClickEventArgs) Handles BarNuevo.Click

    End Sub
End Class
