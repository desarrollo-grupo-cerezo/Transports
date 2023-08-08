Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.Globalization

Public Class FrmTesoreria
    Private ST_GAS As String
    Private SELFECHA As String
    Private CADENA As String
    Private Sub FrmTesoreria_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(BarAutoriza, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(BarDepositar, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(BarCancelar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
            Me.KeyPreview = True

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg2.DrawMode = DrawModeEnum.OwnerDraw
            FgA.DrawMode = DrawModeEnum.OwnerDraw

            Fg.Styles(CellStyleEnum.Normal).WordWrap = True
            Fg2.Styles(CellStyleEnum.Normal).WordWrap = True
            FgA.Styles(CellStyleEnum.Normal).WordWrap = True

            Fg.Rows.Count = 1
            Fg.Cols.Count = 11
            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            FgA.Rows.Count = 1
            FgA.Cols.Count = 14
            FgA.Rows(0).Height = 40
            FgA.Width = Screen.PrimaryScreen.Bounds.Width - 25
            FgA.Height = Me.Height - 150
            FgA.Rows.DefaultSize = 40

            FgA.Styles.Normal.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter
            FgA.Styles.Normal.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterBottom


            Fg2.Rows.Count = 1
            Fg2.Cols.Count = 10
            Fg2.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg2.Height = Me.Height - 150

            FgF.DrawMode = DrawModeEnum.OwnerDraw

        Catch ex As Exception
        End Try

        DERECHOS()
        If BarAutoriza.Enabled Then
            BarDepositar.Visible = False
            Tab1.SelectedIndex = 0
        Else
            If BarDepositar.Enabled Then
                Tab1.SelectedIndex = 2
            Else
                Tab1.SelectedIndex = 1
            End If
        End If
    End Sub
    Private Sub BarDepTrafico_Click(sender As Object, e As EventArgs) Handles BarDepTrafico.Click
        Var2 = ""
        Var3 = ""
        Var4 = ""
        Var5 = ""
        Var7 = ""

        FrmFiltroTesoreria.ShowDialog()
        If Var4 <> "CANCEL" Then
            'Var4 = "DEPOSITADO"
            'Var4 = "AUTORIZADO"
            'Var4 = "ACEPTADO"
            'Var5 = " AND P.FECHA >= '" & FSQL(F1.Value) & "' AND P.FECHA <= '" & FSQL(F2.Value) & "' AND " &
            'IIf(chIncluirCanc.Checked, "", "AND P.STATUS <> 'C'")

            BarAutoriza.Visible = False
            BarDepositar.Visible = False
            BarCancelar.Visible = False

            c1Buscar.SetC1FlexGridSearchPanel(FgF, c1Buscar)

            DESPLEGAR_GASTOS()
        End If
    End Sub

    Sub DESPLEGAR_GASTOS()
        Dim IMPORTE As Decimal = 0, s As String, Sigue As Boolean = False, PF1 As String = "", PF2 As String = ""
        Me.Cursor = Cursors.WaitCursor
        Fg.Redraw = False : Fg2.Redraw = False : FgA.Redraw = False
        Try
            If File.Exists(Application.StartupPath & "\lapiz21.png") Then
                Sigue = True
            End If
        Catch ex As Exception
        End Try
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    SQL = "Select TOP 500 P.FOLIO, Convert(varchar, P.FECHAELAB, 103) As FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR,
                        P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN,
                        CASE WHEN ISNULL(TIPO_PAGO, -1) = -1 THEN '' WHEN ISNULL(TIPO_PAGO, 0) = 0 THEN 'TRANSFERENCIA' ELSE 'EFECTIVO' END AS TPAGO
                        FROM GCASIGNACION_VIAJE_GASTOS P 
                        LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                        LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        WHERE V.STATUS = 'A' AND P.STATUS <> 'C' AND P.ST_GASTOS <> 'EDICION' AND FECHA_AUT IS NULL AND FECHA_DEP IS NULL " & CADENA & "
                        ORDER BY P.FECHAELAB DESC"

                    ST_GAS = "ACEPTADO"
                Case 1
                    SQL = "SELECT TOP 500 P.FOLIO, convert(varchar, P.FECHAELAB, 103) AS FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR, 
                        P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN, P.FECHA_AUT,
                        CASE WHEN ISNULL(TIPO_PAGO, -1) = -1 THEN '' WHEN ISNULL(TIPO_PAGO, 0) = 0 THEN 'TRANSFERENCIA' ELSE 'EFECTIVO' END AS TPAGO
                        FROM GCASIGNACION_VIAJE_GASTOS P 
                        LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                        LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        WHERE V.STATUS = 'A' AND P.STATUS <> 'C' AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NULL " & CADENA & "
                        ORDER BY P.FECHAELAB DESC"
                    ST_GAS = "AUTORIZADO"
                Case 2
                    SQL = "SELECT TOP 500 P.FOLIO, convert(varchar, P.FECHAELAB, 103) AS FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR, 
                        P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN, P.FECHA_AUT, 
                        P.FECHA_DEP, CVE_LIQ, 
                        CASE WHEN ISNULL(TIPO_PAGO, -1) = -1 THEN '' WHEN ISNULL(TIPO_PAGO, 0) = 0 THEN 'TRANSFERENCIA' ELSE 'EFECTIVO' END AS TPAGO
                        FROM GCASIGNACION_VIAJE_GASTOS P 
                        LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                        LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        WHERE V.STATUS = 'A' AND P.STATUS <> 'C' AND FECHA_AUT IS NOT NULL AND FECHA_DEP IS NOT NULL " & CADENA & "
                        ORDER BY P.FECHAELAB DESC"
                    ST_GAS = "DEPOSITADO"
                Case 3

                    FgF.Rows.Count = 1
                    ST_GAS = ""
                    SQL = "SELECT TOP 50 P.FOLIO, P.STATUS, convert(varchar, P.FECHAELAB, 103) AS FECHA_G, P.CVE_VIAJE, P.CVE_NUM, O.NOMBRE, DESCR, 
                        P.IMPORTE, P.ST_GASTOS, ISNULL(AUTORIZADO,'') AS AUTORI, USUARIO1, ISNULL(REF_BAN,'') AS REFBAN, P.FECHA_AUT, P.FECHA_DEP
                        FROM GCASIGNACION_VIAJE_GASTOS P 
                        LEFT JOIN GCASIGNACION_VIAJE V ON V.CVE_VIAJE = P.CVE_VIAJE 
                        LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = P.CVE_NUM 
                        LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER 
                        WHERE V.STATUS = 'A' " & Var5 & CADENA & "
                        ORDER BY P.FECHAELAB DESC"
                    PF1 = Var2
            End Select
            Select Case ST_GAS
                Case "ACEPTADO"
                    Fg.Rows.Count = 1
                Case "DEPOSITADO"
                    Fg2.Rows.Count = 1
                Case "AUTORIZADO"
                    FgA.Rows.Count = 1
            End Select
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case ST_GAS
                            Case "ACEPTADO"
                                s = "" & vbTab & "" & vbTab & dr("FOLIO") & vbTab & dr("FECHA_G") & vbTab & dr("CVE_VIAJE") & vbTab & dr("NOMBRE") & vbTab &
                                    dr("DESCR") & vbTab & dr("IMPORTE") & vbTab & dr("ST_GASTOS") & vbTab &
                                    IIf(dr.ReadNullAsEmptyString("USUARIO1") = "0", "", dr.ReadNullAsEmptyString("USUARIO1")) & vbTab & dr("REFBAN") & vbTab & dr("TPAGO")
                                Fg.AddItem(s)
                            Case "DEPOSITADO"
                                s = "" & vbTab & dr("FOLIO") & vbTab & dr("FECHA_G") & vbTab & dr("FECHA_AUT") & vbTab & dr("FECHA_DEP") & vbTab &
                                    dr("CVE_VIAJE") & vbTab & dr("NOMBRE") & vbTab & dr("DESCR") & vbTab & dr("IMPORTE") & vbTab &
                                    dr("ST_GASTOS") & vbTab & IIf(dr.ReadNullAsEmptyString("USUARIO1") = "0", "", dr.ReadNullAsEmptyString("USUARIO1")) & vbTab & dr("REFBAN") & vbTab &
                                    dr("CVE_LIQ") & vbTab & dr("TPAGO")
                                Fg2.AddItem(s)
                            Case "AUTORIZADO"
                                s = "" & vbTab & "" & vbTab & dr("FOLIO") & vbTab & dr("FECHA_G") & vbTab & dr("FECHA_AUT") & vbTab & dr("CVE_VIAJE") & vbTab & dr("NOMBRE") & vbTab &
                                    dr("DESCR") & vbTab & dr("IMPORTE") & vbTab & dr("ST_GASTOS") & vbTab &
                                    IIf(dr.ReadNullAsEmptyString("USUARIO1") = "0", "", dr.ReadNullAsEmptyString("USUARIO1")) & vbTab & dr("REFBAN") & vbTab & "" & vbTab & dr("TPAGO")
                                FgA.AddItem(s)

                                If Sigue Then
                                    FgA.SetCellImage(FgA.Rows.Count - 1, 11, My.Resources.lapiz21)
                                End If
                            Case Else
                                s = "" & vbTab & dr("FOLIO") & vbTab & dr("STATUS") & vbTab & dr("FECHA_G") & vbTab & dr("FECHA_AUT") & vbTab &
                                    dr("FECHA_DEP") & vbTab & dr("CVE_VIAJE") & vbTab & dr("NOMBRE") & vbTab & dr("DESCR") & vbTab &
                                    dr("IMPORTE") & vbTab & dr("ST_GASTOS") & vbTab & IIf(dr.ReadNullAsEmptyString("USUARIO1") = "0", "", dr.ReadNullAsEmptyString("USUARIO1")) & vbTab & dr("REFBAN")
                                FgF.AddItem(s)
                        End Select
                        If dr("AUTORI") Then
                            IMPORTE += dr("IMPORTE")
                        End If
                    End While
                End Using
            End Using
            Select Case ST_GAS
                Case "ACEPTADO"
                    If Fg.Rows.Count > 1 Then
                        'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & IMPORTE)
                        Fg.AutoSizeRows()
                        Fg.Rows(1).Selected = True
                    End If
                    Fg.SubtotalPosition = SubtotalPositionEnum.BelowData
                    Fg.Subtotal(AggregateEnum.Clear)
                    Fg.Subtotal(AggregateEnum.Sum, -1, -1, 6, "Grand Total")
                Case "DEPOSITADO"
                    If Fg2.Rows.Count > 1 Then
                        'Fg2.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & IMPORTE)
                        Fg2.AutoSizeRows()
                        Fg2.Rows(1).Selected = True
                    End If
                    Fg2.SubtotalPosition = SubtotalPositionEnum.BelowData
                    Fg2.Subtotal(AggregateEnum.Clear)
                    Fg2.Subtotal(AggregateEnum.Sum, -1, -1, 8, "Grand Total")
                Case "AUTORIZADO"
                    If FgA.Rows.Count > 1 Then
                        'FgA.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & IMPORTE)
                        FgA.AutoSizeRows()
                        FgA.Rows(1).Selected = True
                    End If
                    FgA.SubtotalPosition = SubtotalPositionEnum.BelowData
                    FgA.Subtotal(AggregateEnum.Clear)
                    FgA.Subtotal(AggregateEnum.Sum, -1, -1, 7, "Grand Total")
                Case Else
                    FgF.SubtotalPosition = SubtotalPositionEnum.BelowData
                    FgF.Subtotal(AggregateEnum.Clear)
                    FgF.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            End Select
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        SELFECHA = ""
        Fg.Redraw = True
        Fg2.Redraw = True
        FgA.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Tab1_SelectedTabChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedTabChanged
        Try
            BarDepTrafico.Visible = False
            Select Case Tab1.SelectedIndex
                Case 0
                    BarAutoriza.Visible = True
                    BarDepositar.Visible = False
                    Try
                        c1Buscar.SetC1FlexGridSearchPanel(Fg, c1Buscar)
                    Catch ex As Exception
                    End Try
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    BarAutoriza.Visible = False
                    BarDepositar.Visible = True
                    Try
                        c1Buscar.SetC1FlexGridSearchPanel(FgA, c1Buscar)
                    Catch ex As Exception
                    End Try
                    ST_GAS = "AUTORIZADO"
                    TITULOS_AUTORIZADOS()
                    DESPLEGAR_GASTOS()
                Case 2
                    BarAutoriza.Visible = False
                    BarDepositar.Visible = False
                    Try
                        c1Buscar.SetC1FlexGridSearchPanel(Fg2, c1Buscar)
                    Catch ex As Exception
                    End Try
                    ST_GAS = "DEPOSITADO"
                    TITULOS_DEPOSITADOS()
                    DESPLEGAR_GASTOS()
                Case 3
                    BarDepTrafico.Visible = True
                    FgF.Rows.Count = 1
                    TITULOS_FILTRO()
            End Select
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Pag1.Enabled = False
            Pag2.Enabled = False
            Pag3.Enabled = False
            BarAutoriza.Enabled = False
            BarDepositar.Enabled = False
            BarCancelar.Enabled = False
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                (CLAVE >= 30000 AND CLAVE < 40000)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 30500  'autorizacion

                                Case 30520  'autorizacion
                                    Pag1.Enabled = True
                                    BarAutoriza.Enabled = True
                                Case 30530  'depositados
                                    Pag2.Enabled = True
                                Case 30540  'Gastos autorizados
                                    Pag3.Enabled = True
                                    BarDepositar.Enabled = True
                                Case 30560  'cancelar
                                    BarCancelar.Enabled = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub FrmTesoreria_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Tesoreria")
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub BarAutoriza_Click(sender As Object, e As EventArgs) Handles BarAutoriza.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea autorizar el gasto de viaje?", vbYesNo) = vbYes Then

                    For k = 1 To Fg.Rows.Count - 1

                        If Fg(k, 1) Then
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET AUTORIZADO = 1, ST_GASTOS = 'AUTORIZADO', USUARIO1 = '" & USER_GRUPOCE & "',
                                    FECHA_AUT = '" & Date.Now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' 
                                    WHERE CVE_VIAJE = '" & Fg(k, 4) & "' AND FOLIO = '" & Fg(k, 2) & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Fg(k, 8) = "AUTORIZADO"
                                        Fg(k, 9) = USER_GRUPOCE

                                        GRABA_BITA(Fg(k, 4), Fg(k, 2), 0, "A", "Autorización gasto de viaje folio " & Fg(k, 2) & ", Viaje " & Fg(k, 4))
                                    End If
                                End If
                            End Using
                        End If
                    Next

                    MsgBox("Los gastos se autorizaron correctamente")

                    DESPLEGAR_GASTOS()

                End If
            Else
                MsgBox("Por favor seleccione un gasto a viaje")
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarDepositar_Click(sender As Object, e As EventArgs) Handles BarDepositar.Click
        Try
            If FgA.Row > 0 Then

                'If FgA(FgA.Row, 8) = "DEPOSITADO" Then
                'MsgBox("El gasto de viaje ya fue depositado")
                'Return
                'End If

                Var4 = ""
                FrmTesoreriaCapFechaDeposito.ShowDialog()
                If Var4.Trim.Length > 0 Then

                    For k = FgA.Rows.Count - 1 To 1 Step -1

                        Try
                            If FgA(k, 1) Then

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET AUTORIZADO = 2, ST_GASTOS = 'DEPOSITADO', USUARIO2 = '" & USER_GRUPOCE & "',
                                    FECHA_DEP = '" & FSQL(Var4) & "' 
                                    WHERE CVE_VIAJE = '" & FgA(k, 5) & "' AND FOLIO = '" & FgA(k, 2) & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            FgA(k, 9) = "DEPOSITADO"
                                            FgA(k, 10) = USER_GRUPOCE

                                            GRABA_BITA(FgA(k, 5), FgA(k, 2), 0, "A", "Depósito de gasto de viaje folio " & FgA(k, 2) & ", Viaje " & FgA(k, 5))

                                        Else
                                            MsgBox("No se logro realizar el depósito del gasto de viaje")
                                        End If
                                    Else
                                        MsgBox("No se logro realizar el depósito del gasto de viaje")
                                    End If
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Next

                    TITULOS_AUTORIZADOS()

                    BarAutoriza.Visible = False
                    BarDepositar.Visible = True
                    c1Buscar.SetC1FlexGridSearchPanel(FgA, c1Buscar)
                    ST_GAS = "AUTORIZADO"
                    DESPLEGAR_GASTOS()


                    MsgBox("El depósito del gasto se autorizo satisfactoriamente")

                End If
            Else
                MsgBox("Por favor seleccione un gasto a viaje")
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    If Fg.Row > 0 Then

                        If Fg(Fg.Row, 8).ToString.ToUpper = "DEPOSITADO" Then
                            MsgBox("No es posible cancelar un gasto depositado")
                            Return
                        End If
                        If MsgBox("Realmente desea cancelar la autorización de gasto de viaje " & Fg(Fg.Row, 2) & "?", vbYesNo) = vbNo Then
                            Return
                        End If
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET AUTORIZADO = 0, ST_GASTOS = 'EDICION', USUARIO1 = ''
                                WHERE CVE_VIAJE = '" & Fg(Fg.Row, 4) & "' AND FOLIO = '" & Fg(Fg.Row, 2) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    MsgBox("El gasto quedo con estatus ACEPTADO")
                                    Fg(Fg.Row, 8) = ""
                                    Fg(Fg.Row, 9) = ""


                                    BarAutoriza.Visible = True
                                    BarDepositar.Visible = False

                                    c1Buscar.SetC1FlexGridSearchPanel(Fg, c1Buscar)
                                    ST_GAS = "ACEPTADO"

                                    TITULOS1()

                                    DESPLEGAR_GASTOS()
                                Else
                                    MsgBox("No se logro cancelar el gasto")
                                End If
                            Else
                                MsgBox("No se logro cancelar el gasto")
                            End If
                        End Using
                    Else
                        MsgBox("Por favor seleccione un gasto a viaje a cancelar")
                    End If
                Case 1

                    If FgA.Row > 0 Then
                        If FgA(FgA.Row, 9).ToString.ToUpper = "DEPOSITADO" Then
                            MsgBox("No es posible cancelar un gasto depositado")
                            Return
                        End If
                        If MsgBox("Realmente desea cancelar la autorización del gasto de viaje " & FgA(FgA.Row, 2) & "?", vbYesNo) = vbNo Then
                            Return
                        End If
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET AUTORIZADO = 0, ST_GASTOS = 'ACEPTADO', USUARIO1 = '', FECHA_AUT = NULL WHERE
                                CVE_VIAJE = '" & FgA(FgA.Row, 5) & "' AND FOLIO = '" & FgA(FgA.Row, 2) & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    MsgBox("El gasto quedo con estatus ACEPTADO")
                                    FgA(FgA.Row, 9) = ""
                                    FgA(FgA.Row, 10) = ""

                                    TITULOS_AUTORIZADOS()

                                    BarAutoriza.Visible = False
                                    BarDepositar.Visible = True
                                    c1Buscar.SetC1FlexGridSearchPanel(FgA, c1Buscar)
                                    ST_GAS = "AUTORIZADO"
                                    DESPLEGAR_GASTOS()

                                Else
                                    MsgBox("No se logro cancelar el gasto")
                                End If
                            Else
                                MsgBox("No se logro cancelar el gasto")
                            End If
                        End Using
                    Else
                        MsgBox("Por favor seleccione un gasto a viaje a cancelar")
                    End If
            End Select
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Select Case Tab1.SelectedIndex
            Case 0
                Try
                    EXPORTAR_EXCEL_TRANSPORT(Fg, "Documentos autorizados")
                Catch ex As Exception
                End Try
            Case 1
                Try
                    EXPORTAR_EXCEL_TRANSPORT(FgA, "Gastos autorizados")
                Catch ex As Exception
                End Try
            Case 2
                Try
                    EXPORTAR_EXCEL_TRANSPORT(Fg2, "Documentos depositados")
                Catch ex As Exception
                End Try
            Case 3
                Try
                    EXPORTAR_EXCEL_TRANSPORT(FgF, "Gastos filtrados")
                Catch ex As Exception
                End Try
        End Select
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles barImprimir.Click
        IMPRIMIR_MRT()
    End Sub
    Sub IMPRIMIR_MRT()
        barImprimir.Enabled = False
        Try
            Dim VAR_ST_GASTOS As String = ""

            Select Case Tab1.SelectedIndex
                Case 0
                    ST_GAS = "ACEPTADO"
                    DESPLEGAR_GASTOS()
                Case 1
                    ST_GAS = "AUTORIZADO"
                    DESPLEGAR_GASTOS()

                Case 2
                    ST_GAS = "DEPOSITADO"
                    DESPLEGAR_GASTOS()
            End Select
            Select Case Tab1.SelectedIndex
                Case 0
                    VAR_ST_GASTOS = "AUTORIZACION"
                Case 1
                    VAR_ST_GASTOS = "GASTOS AUTORIZADOS"

                Case 2
                    VAR_ST_GASTOS = "DEPOSITOS"
            End Select

            Var10 = ST_GAS
            Var11 = VAR_ST_GASTOS

            FrmTesoreriaReporte.ShowDialog()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        barImprimir.Enabled = True
    End Sub
    Private Sub BarActualizar_Click_1(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            CADENA = ""

            DESPLEGAR_GASTOS()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgA_Click(sender As Object, e As EventArgs) Handles FgA.Click
        Try
            If FgA.Col = 11 Then
                Var1 = FgA(FgA.Row, 2)
                Var2 = FgA(FgA.Row, 11)
                Var4 = ""
                FrmTesoreriaRefBan.ShowDialog()
                If Var4 <> "-" Then
                    FgA(FgA.Row, 11) = Var4
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS1()
        Try

            Fg(0, 1) = "Seleccione"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Boolean)

            Fg(0, 2) = "Folio gasto"
            Dim cc2 As Column = Fg.Cols(2)
            cc2.DataType = GetType(String)

            Fg(0, 3) = "Fecha"
            Dim c2 As Column = Fg.Cols(3)
            c2.DataType = GetType(DateTime)

            Fg(0, 4) = "No. Viaje"
            Dim c3 As Column = Fg.Cols(4)
            c3.DataType = GetType(String)

            Fg(0, 5) = "Operador"
            Dim c4 As Column = Fg.Cols(5)
            c4.DataType = GetType(String)

            Fg(0, 6) = "Concepto gasto"
            Dim c5 As Column = Fg.Cols(6)
            c5.DataType = GetType(String)

            Fg(0, 7) = "Importe"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(Single)
            c6.Format = "###,###,##0.00"

            Fg(0, 8) = "Estatus"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "Usuario"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "Referencia bancaria"
            Dim c19 As Column = Fg.Cols(10)
            c19.DataType = GetType(String)

            Fg(0, 11) = "Forma de pago"
            Dim cd10 As Column = Fg.Cols(11)
            cd10.DataType = GetType(String)

            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & k
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub TITULOS_DEPOSITADOS()
        Try 'DEPOSITADOS
            Fg2.Rows.Count = 1
            Fg2.Cols.Count = 15

            Fg2(0, 1) = "Folio gasto"
            Dim cd1 As Column = Fg2.Cols(1)
            cd1.DataType = GetType(String)

            Fg2(0, 2) = "Fecha"
            Dim cd2 As Column = Fg2.Cols(2)
            cd2.DataType = GetType(DateTime)

            Fg2(0, 3) = "Fecha autorización"
            Dim cd3 As Column = Fg2.Cols(3)
            cd3.DataType = GetType(DateTime)

            Fg2(0, 4) = "Fecha depositado"
            Dim cd4 As Column = Fg2.Cols(4)
            cd4.DataType = GetType(DateTime)

            Fg2(0, 5) = "No. Viaje"
            Dim cd5 As Column = Fg2.Cols(5)
            cd5.DataType = GetType(String)

            Fg2(0, 6) = "Operador"
            Dim cd6 As Column = Fg2.Cols(6)
            cd6.DataType = GetType(String)

            Fg2(0, 7) = "Concepto gasto"
            Dim cd7 As Column = Fg2.Cols(7)
            cd7.DataType = GetType(String)

            Fg2(0, 8) = "Importe"
            Dim cd8 As Column = Fg2.Cols(8)
            cd8.DataType = GetType(Single)
            cd8.Format = "###,###,##0.00"

            Fg2(0, 9) = "Estatus"
            Dim cd9 As Column = Fg2.Cols(9)
            cd9.DataType = GetType(String)

            Fg2(0, 10) = "Usuario"
            Dim cd10 As Column = Fg2.Cols(10)
            cd10.DataType = GetType(String)

            Fg2(0, 11) = "Referencia bancaria"
            Dim cd11 As Column = Fg2.Cols(11)
            cd11.DataType = GetType(String)

            Fg2(0, 12) = "Liquidación"
            Dim cd12 As Column = Fg2.Cols(12)
            cd12.DataType = GetType(String)

            Fg2(0, 13) = "Forma de pago"
            Dim cd13 As Column = Fg2.Cols(13)
            cd13.DataType = GetType(String)

            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg2.Cols.Count - 1
                    Fg2(0, k) = Fg2(0, k) & " " & k
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub
    Sub TITULOS_AUTORIZADOS()
        'AUTORIZADOS
        Try

            FgA(0, 1) = "Seleccione"
            Dim cc1 As Column = FgA.Cols(1)
            cc1.DataType = GetType(Boolean)

            FgA(0, 2) = "Folio gasto"
            Dim ca1 As Column = FgA.Cols(2)
            ca1.DataType = GetType(String)

            FgA(0, 3) = "Fecha"
            Dim ca2 As Column = FgA.Cols(3)
            ca2.DataType = GetType(DateTime)

            FgA(0, 4) = "Fecha autorización"
            Dim ca3 As Column = FgA.Cols(4)
            ca3.DataType = GetType(DateTime)

            FgA(0, 5) = "No. Viaje"
            Dim ca4 As Column = FgA.Cols(5)
            ca4.DataType = GetType(String)

            FgA(0, 6) = "Operador"
            Dim ca5 As Column = FgA.Cols(6)
            ca5.DataType = GetType(String)

            FgA(0, 7) = "Concepto gasto"
            Dim ca6 As Column = FgA.Cols(7)
            ca6.DataType = GetType(String)

            FgA(0, 8) = "Importe"
            Dim ca7 As Column = FgA.Cols(8)
            ca7.DataType = GetType(Single)
            ca7.Format = "###,###,##0.00"

            FgA(0, 9) = "Estatus"
            Dim ca8 As Column = FgA.Cols(9)
            ca8.DataType = GetType(String)

            FgA(0, 10) = "Usuario"
            Dim ca9 As Column = FgA.Cols(10)
            ca9.DataType = GetType(String)

            FgA(0, 11) = "Referencia bancaria"
            Dim ca10 As Column = FgA.Cols(11)
            ca10.DataType = GetType(String)

            FgA(0, 12) = "..."
            Dim ca11 As Column = FgA.Cols(12)
            ca11.DataType = GetType(String)

            FgA(0, 13) = "Forma de pago"
            Dim cd12 As Column = FgA.Cols(13)
            cd12.DataType = GetType(String)

            '*************************************************************************************************************************************
            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For f = 1 To FgA.Cols.Count - 1
                    FgA(0, f) = FgA(0, f) & " " & f
                Next
            End If

            ST_GAS = "ACEPTADO"
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub TITULOS_FILTRO()
        Try 'DEPOSITADOS
            FgF.Rows.Count = 1
            FgF.Cols.Count = 14

            FgF(0, 1) = "Folio gasto"
            Dim cd1 As Column = FgF.Cols(1)
            cd1.DataType = GetType(String)

            FgF(0, 2) = "Estatus gasto"
            Dim cd14 As Column = FgF.Cols(2)
            cd14.DataType = GetType(String)

            FgF(0, 3) = "Fecha"
            Dim cd2 As Column = FgF.Cols(3)
            cd2.DataType = GetType(DateTime)

            FgF(0, 4) = "Fecha autorización"
            Dim cd3 As Column = FgF.Cols(4)
            cd3.DataType = GetType(DateTime)

            FgF(0, 5) = "Fecha depositado"
            Dim cd4 As Column = FgF.Cols(5)
            cd4.DataType = GetType(DateTime)

            FgF(0, 6) = "No. Viaje"
            Dim cd5 As Column = FgF.Cols(6)
            cd5.DataType = GetType(String)

            FgF(0, 7) = "Operador"
            Dim cd6 As Column = FgF.Cols(7)
            cd6.DataType = GetType(String)

            FgF(0, 8) = "Concepto gasto"
            Dim cd7 As Column = FgF.Cols(8)
            cd7.DataType = GetType(String)

            FgF(0, 10) = "Importe"
            Dim cd8 As Column = FgF.Cols(9)
            cd8.DataType = GetType(Single)
            cd8.Format = "###,###,##0.00"

            FgF(0, 11) = "Estatus gasto"
            Dim cd9 As Column = FgF.Cols(10)
            cd9.DataType = GetType(String)

            FgF(0, 12) = "Usuario"
            Dim cd10 As Column = FgF.Cols(11)
            cd10.DataType = GetType(String)

            FgF(0, 13) = "Referencia bancaria"
            Dim cd11 As Column = FgF.Cols(12)
            cd11.DataType = GetType(String)

            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To FgF.Cols.Count - 1
                    FgF(0, k) = FgF(0, k) & " " & k
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgF_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgF.OwnerDrawCell
        If e.Row >= FgF.Rows.Fixed And e.Col = FgF.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - FgF.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub Fg2_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg2.OwnerDrawCell
        If e.Row >= Fg2.Rows.Fixed And e.Col = Fg2.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg2.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub FgA_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles FgA.OwnerDrawCell
        If e.Row >= FgA.Rows.Fixed And e.Col = FgA.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - FgA.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND P.FECHA = '" & FSQL(Date.Now) & "' "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    CADENA = " AND P.FECHA = '" & FSQL(Date.Now) & "' "
                    ST_GAS = "AUTORIZADO"
                    TITULOS_AUTORIZADOS()
                    DESPLEGAR_GASTOS()
                Case 2
                    CADENA = " AND P.FECHA = '" & FSQL(Date.Now) & "'"
                    ST_GAS = "DEPOSITADO"
                    TITULOS_DEPOSITADOS()
                    DESPLEGAR_GASTOS()
                Case 3
            End Select
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddMonths(-1)
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    DESPLEGAR_GASTOS()
                Case 2
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    DESPLEGAR_GASTOS()
                Case 3
            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = ""
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    CADENA = ""
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 2
                    CADENA = ""
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 3
            End Select
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Try
            Dim dt As DateTime = Date.Today
            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 2
                    CADENA = " AND MONTH(P.FECHA) = " & dt.Month & " AND YEAR(P.FECHA) = " & dt.Year & " "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 3
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Try
            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(-1)

            Select Case Tab1.SelectedIndex
                Case 0
                    CADENA = " AND P.FECHA = '" & FSQL(dt) & "' "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 1
                    CADENA = " AND P.FECHA = '" & FSQL(dt) & "' "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 2
                    CADENA = " AND P.FECHA = '" & FSQL(dt) & "' "
                    ST_GAS = "ACEPTADO"
                    TITULOS1()
                    DESPLEGAR_GASTOS()
                Case 3
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgA_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgA.BeforeEdit
        Try
            If FgA.Row > 0 Then
                If FgA.Col <> 1 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class