Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports Stimulsoft.Report.StiOptions.Export

Public Class FrmCartaPorte
    Private NRow As Long = 0
    Private N_TOP As String = "TOP 1000"
    Private CADENA As String
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmCartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub

    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        TAB1.Dock = DockStyle.Fill
        Fg.Redraw = False
        Fg.DrawMode = DrawModeEnum.OwnerDraw
        Fg.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue

        Fg.FocusRect = FocusRectEnum.Solid
        Fg.Styles("Alternate").BackColor = Color.PowderBlue
        Fg.Styles("Highlight").BackColor = Color.CornflowerBlue
        Fg.Styles("Focus").BackColor = Color.White
        Fg.Styles("Focus").Border.Color = Color.Red
        Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
        Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

        Try
            F1.Value = Date.Today
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            Me.WindowState = FormWindowState.Maximized
            C1SuperTooltip1.SetToolTip(barNuevo, "F2 - Nuevo")
            C1SuperTooltip1.SetToolTip(barEdit, "F3 - Edit")
            C1SuperTooltip1.SetToolTip(barEliminar, "F4 - Eliminar")
            C1SuperTooltip1.SetToolTip(barSalir, "F5 - Salir")
            Me.KeyPreview = True
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With

            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1

            Fg.DrawMode = DrawModeEnum.OwnerDraw

            Fg.Rows(0).Height = 40
            Fg2.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Lt1.Left = 50
            Lt1.Top = Fg.Top + Fg.Height + 10

            DERECHOS()

            CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"

            Try
                C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
            Catch ex As Exception
            End Try

            DESPLEGAR()

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
            End If

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
            Try
                'C1FlexGridSearchPanel1.ActiveControl.Text = ""
            Catch ex As Exception
            End Try
            Dim cmd As New SqlCommand With {.Connection = cnSAE}

            SQL = "SELECT " & N_TOP & " P.CVE_FOLIO, ISNULL(ST.DESCR,'EDICION') AS ST_CARTAP,  P.ORDEN_DE,  P.CVE_VIAJE, P.CVE_DOCP, 
                CASE ISNULL(P.CVE_DOCR,'') WHEN '0' THEN '' WHEN '' THEN '' ELSE P.CVE_DOCR END, R.CVE_TAB, 
                '(' + LTRIM(RTRIM(P.CLIENTE)) + ') ' + C.NOMBRE, F.FACTURA, F.SUBTOTAL, F.IVA, F.RETENCION, F.IMPORTE, 
                P.FECHAELAB, (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI,
                (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE AS OPER, P.CVE_TRACTOR,
                P.CVE_TANQUE1, P.CVE_TANQUE2, P.CVE_DOLLY, RE.DESCR AS RECEN, EE.DESCR AS ENTEN, 
                (CASE P.CONCILIADO WHEN 1 THEN 'Conciliado' ELSE '' END) AS CONCI, 
                ISNULL(CVE_MAT,'') AS CVE_MAT, ISNULL(VALOR_DECLARADO,0) AS VAL_CLA, P.CLIENTE, 
                (CAST(I.CVE_ESQIMPU AS VARCHAR(2)) + ' ' + PU.DESCRIPESQ) as 'Esquema impuesto', 
                CASE WHEN ISNULL(CP_VIRTUAL,0) = 1 THEN 'Virtual' ELSE '' END AS 'Carta porte virtual'
                FROM GCCARTA_PORTE P
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = P.CVE_CON
                LEFT JOIN CFDI F ON (F.DOCUMENT = P.CVE_FOLIO or F.DOCUMENT2 = P.CVE_FOLIO) AND ISNULL(F.ESTATUS,'A') <> 'C'
                LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = P.ST_CARTA_PORTE
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_MAT
                LEFT JOIN IMPU" & Empresa & " PU ON PU.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                CADENA
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt

            If TAB1.SelectedIndex = 0 Then
                Fg.DataSource = BindingSource1.DataSource

                Fg(0, 1) = "Folio"
                Dim cc1 As Column = Fg.Cols(1)
                cc1.DataType = GetType(Int32)

                Fg(0, 2) = "Estatus carta porte"
                Dim c2 As Column = Fg.Cols(2)
                c2.DataType = GetType(String)
                c2.TextAlign = TextAlignEnum.CenterCenter

                Fg(0, 3) = "Orden de"
                Dim c3 As Column = Fg.Cols(3)
                c3.DataType = GetType(String)

                Fg(0, 4) = "Viaje"
                Dim c4 As Column = Fg.Cols(4)
                c4.DataType = GetType(String)

                Fg(0, 5) = "Pedido"
                Dim c5 As Column = Fg.Cols(5)
                c5.DataType = GetType(String)

                Fg(0, 6) = "Remisión"
                Dim c6 As Column = Fg.Cols(6)
                c6.DataType = GetType(String)

                Fg(0, 7) = "Tabulador de ruta"
                Dim cc6 As Column = Fg.Cols(7)
                cc6.DataType = GetType(String)

                Fg(0, 8) = "Cliente"
                Dim c8 As Column = Fg.Cols(8)
                c8.DataType = GetType(String)

                Fg(0, 9) = "FACTURA"
                Dim c7 As Column = Fg.Cols(9)
                c7.DataType = GetType(String)

                Fg(0, 10) = "Subtotal"
                Dim c21 As Column = Fg.Cols(10)
                c21.DataType = GetType(Decimal)
                c21.Format = "N2"

                Fg(0, 11) = "IVA"
                Dim c10 As Column = Fg.Cols(11)
                c10.DataType = GetType(Decimal)
                c10.Format = "N2"

                Fg(0, 12) = "Retencion"
                Dim c11 As Column = Fg.Cols(12)
                c11.DataType = GetType(Decimal)
                c11.Format = "N2"

                Fg(0, 13) = "Importe"
                Dim c12 As Column = Fg.Cols(13)
                c12.DataType = GetType(Decimal)
                c12.Format = "N2"

                Fg(0, 14) = "Fecha"
                Dim c9 As Column = Fg.Cols(14)
                c9.DataType = GetType(DateTime)
                c9.Format = "G"

                Fg(0, 15) = "Tipo unidad"
                Dim c14 As Column = Fg.Cols(15)
                c14.DataType = GetType(Int32)

                Fg(0, 16) = "Tipo viaje"
                Dim c15 As Column = Fg.Cols(16)
                c15.DataType = GetType(Int32)

                Fg(0, 17) = "Nombre operador"
                Dim c16 As Column = Fg.Cols(17)
                c16.DataType = GetType(Int32)

                Fg(0, 18) = "Tractor"
                Dim c13 As Column = Fg.Cols(18)
                c13.DataType = GetType(String)

                Fg(0, 19) = "Tanque1"
                Dim c18 As Column = Fg.Cols(19)
                c18.DataType = GetType(String)

                Fg(0, 20) = "Tanque2"
                Dim c19 As Column = Fg.Cols(20)
                c19.DataType = GetType(String)

                Fg(0, 21) = "Dolly"
                Dim c20 As Column = Fg.Cols(21)
                c20.DataType = GetType(String)

                Fg(0, 22) = "Recoger en"
                Dim c17 As Column = Fg.Cols(22)
                c17.DataType = GetType(String)

                Fg(0, 23) = "Entregar en"
                Dim c22 As Column = Fg.Cols(23)
                c22.DataType = GetType(String)

                Fg(0, 24) = "Conciliado"
                Dim c23 As Column = Fg.Cols(24)
                c23.DataType = GetType(String)

                Fg(0, 25) = "Producto"
                Dim c24 As Column = Fg.Cols(25)
                c24.DataType = GetType(String)

                Fg(0, 26) = "Valor declarado"
                Dim c25 As Column = Fg.Cols(26)
                c25.DataType = GetType(Decimal)
                c25.Format = "N2"

                Fg(0, 27) = "Cliente"
                Dim c26 As Column = Fg.Cols(27)
                c26.DataType = GetType(String)

                Fg(0, 29) = "Carta porte virtual"
                Dim c28 As Column = Fg.Cols(29)
                c28.DataType = GetType(String)

                If NRow > 0 Then
                    'Fg.Row = NRow
                    Fg.TopRow = NRow
                    Fg.Row = NRow
                End If

                '  Clear existing subtotals.
                Fg.Subtotal(AggregateEnum.Clear)

                '  Get a Grand total (use -1 instead of column index).
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")

                '  Total per Product (column 0).
                'Fg.Subtotal(AggregateEnum.Sum, 0, 0, 3, "Total {0}")

                '  Total per Region (column 1).
                'Fg.Subtotal(AggregateEnum.Sum, 1, 1, 9, "Total {0}")

                '  Set styles for subtotals.
                Dim cs As CellStyle
                cs = Fg.Styles(CellStyleEnum.GrandTotal)
                cs.BackColor = Color.Black
                cs.ForeColor = Color.White
                cs.Font = New Font(Font, FontStyle.Bold)

                Lt1.Text = "Registros encontrados " & Fg.Rows.Count - 1

                Try
                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg, C1FlexGridSearchPanel1)
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try

                Fg.AutoSizeCols()

            Else
                Fg2.DataSource = BindingSource1.DataSource

                Fg2(0, 1) = "Folio"
                Dim cc1 As Column = Fg2.Cols(1)
                cc1.DataType = GetType(Int32)

                Fg2(0, 2) = "Estatus carta porte"
                Dim c2 As Column = Fg2.Cols(2)
                c2.DataType = GetType(String)

                Fg2(0, 3) = "Orden de"
                Dim c3 As Column = Fg2.Cols(3)
                c3.DataType = GetType(String)

                Fg2(0, 4) = "Viaje"
                Dim c4 As Column = Fg2.Cols(4)
                c4.DataType = GetType(String)

                Fg2(0, 5) = "Pedido"
                Dim c5 As Column = Fg2.Cols(5)
                c5.DataType = GetType(String)

                Fg2(0, 6) = "Remisión"
                Dim c6 As Column = Fg2.Cols(6)
                c6.DataType = GetType(String)

                Fg2(0, 7) = "Cliente"
                Dim c8 As Column = Fg2.Cols(7)
                c8.DataType = GetType(String)

                Fg2(0, 8) = "FACTURA"
                Dim c7 As Column = Fg2.Cols(8)
                c7.DataType = GetType(String)

                Fg2(0, 9) = "Subtotal"
                Dim c21 As Column = Fg2.Cols(9)
                c21.DataType = GetType(Decimal)
                c21.Format = "N2"

                Fg2(0, 10) = "IVA"
                Dim c10 As Column = Fg2.Cols(10)
                c10.DataType = GetType(Decimal)
                c10.Format = "N2"

                Fg2(0, 11) = "Retencion"
                Dim c11 As Column = Fg2.Cols(11)
                c11.DataType = GetType(Decimal)
                c11.Format = "N2"

                Fg2(0, 12) = "Importe"
                Dim c12 As Column = Fg2.Cols(12)
                c12.DataType = GetType(Decimal)
                c12.Format = "N2"

                Fg2(0, 13) = "Fecha"
                Dim c9 As Column = Fg2.Cols(13)
                c9.DataType = GetType(DateTime)
                c9.Format = "G"

                Fg2(0, 14) = "Tipo unidad"
                Dim c14 As Column = Fg2.Cols(14)
                c14.DataType = GetType(Int32)

                Fg2(0, 15) = "Tipo viaje"
                Dim c15 As Column = Fg2.Cols(15)
                c15.DataType = GetType(Int32)

                Fg2(0, 16) = "Nombre operador"
                Dim c16 As Column = Fg2.Cols(16)
                c16.DataType = GetType(Int32)

                Fg2(0, 17) = "Tractor"
                Dim c13 As Column = Fg2.Cols(17)
                c13.DataType = GetType(String)

                Fg2(0, 18) = "Tanque1"
                Dim c18 As Column = Fg2.Cols(18)
                c18.DataType = GetType(String)

                Fg2(0, 19) = "Tanque2"
                Dim c19 As Column = Fg2.Cols(19)
                c19.DataType = GetType(String)

                Fg2(0, 20) = "Dolly"
                Dim c20 As Column = Fg2.Cols(20)
                c20.DataType = GetType(String)

                Fg2(0, 21) = "Recoger en"
                Dim c17 As Column = Fg2.Cols(21)
                c17.DataType = GetType(String)

                Fg2(0, 22) = "Entregar en"
                Dim c22 As Column = Fg2.Cols(22)
                c22.DataType = GetType(String)

                Fg2(0, 23) = "Conciliado"
                Dim c23 As Column = Fg2.Cols(23)
                c23.DataType = GetType(String)

                Fg2(0, 24) = "Producto"
                Dim c24 As Column = Fg2.Cols(24)
                c24.DataType = GetType(String)

                Fg2(0, 25) = "Valor declarado"
                Dim c25 As Column = Fg2.Cols(25)
                c25.DataType = GetType(Decimal)
                c25.Format = "N2"

                Fg2(0, 26) = "Cliente"
                Dim c26 As Column = Fg2.Cols(26)
                c26.DataType = GetType(String)

                If NRow > 0 Then
                    'Fg.Row = NRow
                    Fg2.TopRow = NRow
                    Fg2.Row = NRow
                End If

                Lt1.Text = "Registros encontrados " & Fg2.Rows.Count - 1

                Try
                    C1FlexGridSearchPanel1.SetC1FlexGridSearchPanel(Fg2, C1FlexGridSearchPanel1)
                    'C1FlexGridSearchPanel1.ActiveControl.Text = ""
                Catch ex As Exception
                End Try

                Fg2.Cols(5).Width = 50
                Fg2.Cols(6).Width = 50
                Fg2.Cols(7).Width = 260
                Fg2.Cols(8).Width = 40
                Fg2.Cols(9).Width = 40
                Fg2.Cols(10).Width = 40
                Fg2.Cols(11).Width = 40
                Fg2.Cols(12).Width = 40

            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                barNuevo.Visible = False
                barEdit.Visible = False
                barEliminar.Visible = False

                BarRepDifPeso.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                CLAVE >= 22500 AND CLAVE <= 22590"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 22510 'NUEVO
                                    barNuevo.Visible = True
                                Case 22520 'EDIT
                                    barEdit.Visible = True
                                Case 22530 'CANCELAR
                                    barEliminar.Visible = True
                                Case 22534 'TIMBRAR CARTA PORTE

                                Case 22536 'REPORTE DE DIF DE PESO
                                    BarRepDifPeso.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmCartaPorte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Carta Porte")
        Me.Dispose()
    End Sub

    Private Sub FrmCartaPorte_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F2
                    BarNuevo_Click(Nothing, Nothing)
                Case Keys.F3
                    BarEdit_Click(Nothing, Nothing)
                Case Keys.F4
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F5
                    MnuSalir_Click(Nothing, Nothing)
                Case Else
                    If (e.KeyCode = Keys.W AndAlso e.Modifiers = Keys.Control) Then
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles barNuevo.Click
        Try
            NRow = 0
            Var1 = "Nuevo"

            CREA_TAB(FrmCartaPorteAE, "Movimientos Carta Porte")

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles barEdit.Click
        If Fg.Row > 0 Then


            NRow = Fg.Row
            Var1 = "Edit"
            If TAB1.SelectedIndex = 0 Then
                Var2 = Fg(Fg.Row, 1)
            Else
                Var2 = Fg2(Fg2.Row, 1)
            End If

            CREA_TAB(FrmCartaPorteAE, "Movimientos Carta Porte")
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 2) <> "EDICION" And Fg(Fg.Row, 2) <> "REGRESO" Then
                    MsgBox("No es posible cancelar la carta porte por que se encuentra ACEPTADA o REGRESO")
                    Return
                End If
                If Fg(Fg.Row, 6) <> "" Then
                    MsgBox("No es posible cancelar la carta porte porque tienen una remisión asignada")
                    Return
                End If
            Else
                MsgBox("Por favor seleccione una carta porte a cancelar")
                Return
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If MsgBox("Realmente desea cancelar la carta porte " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then

                Var4 = ""
                'FrmMotivoBaja.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    'Dim CVE_MTC As Long = 0
                    Try
                        'CVE_MTC = GRABA_MOTIVO_CANC("CARTA PORTE", Var4)
                    Catch ex As Exception
                        Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    'SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 5, CVE_DOCP = '', CVE_MTC = " & CVE_MTC & " WHERE CVE_FOLIO = '" & Fg(Fg.Row, 1) & "'"
                Else
                    'Dim ResultMensaje As String
                    'ResultMensaje = MensajeBox("Cancelación abortada ¡¡¡¡¡", "Proceso finalizado", "Error")
                End If

                SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 5, CVE_DOCP = '' WHERE CVE_FOLIO = '" & Fg(Fg.Row, 1) & "'"

                Dim cmd As New SqlCommand With {
                        .Connection = cnSAE,
                        .CommandTimeout = 120,
                        .CommandText = SQL
                    }
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        Try
                            Dim CVE_DOC As String, CVE_CAP As String
                            'CARTA PORTE 
                            CVE_CAP = Fg(Fg.Row, 1)
                            'PEDIDO
                            CVE_DOC = Fg(Fg.Row, 5)

                            SQL = "UPDATE GCPEDIDOS SET NUM_TALON = '' WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_TALON = '" & CVE_CAP & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                            SQL = "UPDATE GCPEDIDOS SET NUM_TALON2 = '' WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_TALON2 = '" & CVE_CAP & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        MsgBox("La carta porte se cancelo correctamente")

                        CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"

                        DESPLEGAR()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click

        If TAB1.SelectedIndex = 0 Then
            CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"
        Else
            CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY P.FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            If TAB1.SelectedIndex = 0 Then
                EXPORTAR_EXCEL_TRANSPORT(Fg, "CARTA PORTE")
            Else
                EXPORTAR_EXCEL_TRANSPORT(Fg2, "CARTA PORTE CANCELADOS")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarRepDifPeso_Click_1(sender As Object, e As EventArgs) Handles BarRepDifPeso.Click
        Try
            Var4 = "DifPeso"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarRepCartaPorte_Click_1(sender As Object, e As EventArgs) Handles BarRepCartaPorte.Click
        Try
            Var4 = "Carta porte"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCPTransferidas_Click(sender As Object, e As EventArgs) Handles BarCPTransferidas.Click
        Try
            Var4 = "Cartas porte transferidas"
            FrmReporteDifPeso.ShowDialog()
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            Dim sStyleName As String
            sStyleName = "RowStyle"

            Dim cs1 As CellStyle
            cs1 = Fg.Styles.Add("CS1")
            cs1.BackColor = Color.LightGreen
            cs1.Font = New Font(ChrW(23655) & ChrW(23765), 12, FontStyle.Regular, GraphicsUnit.Point, 134)

            Dim cs2 As CellStyle
            cs2 = Fg.Styles.Add("CS2")
            cs2.BackColor = Color.CornflowerBlue

            Dim cs3 As CellStyle
            cs3 = Fg.Styles.Add("CS3")
            cs3.BackColor = Color.Blue
            cs3.ForeColor = Color.White

            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()

                Select Case Fg(e.Row, 2)
                    Case "EDICION"
                        Fg.SetCellStyle(e.Row, 2, cs1)
                        Dim rg As C1.Win.C1FlexGrid.CellRange = Fg.GetCellRange(Fg.Row, Fg.Col, Fg.Row, Fg.Col + 1)
                        rg.Style = Fg.Styles(sStyleName)
                    Case "TRANSFERIDO"
                        Fg.SetCellStyle(e.Row, 2, cs3)
                End Select
                Select Case Fg(e.Row, 29)
                    Case "Virtual"
                        Fg.SetCellStyle(e.Row, 1, cs2)
                        Fg.SetCellStyle(e.Row, 2, cs2)
                        Fg.SetCellStyle(e.Row, 3, cs2)
                        Fg.SetCellStyle(e.Row, 4, cs2)
                        Fg.SetCellStyle(e.Row, 5, cs2)
                        Fg.SetCellStyle(e.Row, 6, cs2)
                        Fg.SetCellStyle(e.Row, 7, cs2)
                        Fg.SetCellStyle(e.Row, 8, cs2)
                        Fg.SetCellStyle(e.Row, 9, cs2)
                        Fg.SetCellStyle(e.Row, 10, cs2)
                        Fg.SetCellStyle(e.Row, 11, cs2)
                        Fg.SetCellStyle(e.Row, 12, cs2)
                        Fg.SetCellStyle(e.Row, 13, cs2)
                        Fg.SetCellStyle(e.Row, 14, cs2)
                        Fg.SetCellStyle(e.Row, 15, cs2)
                        Fg.SetCellStyle(e.Row, 16, cs2)
                        Fg.SetCellStyle(e.Row, 17, cs2)
                        Fg.SetCellStyle(e.Row, 18, cs2)
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        N_TOP = ""
        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' AND ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"
        Else
            CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' AND ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY P.FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        N_TOP = ""

        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "' AND ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"
        Else
            CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "' AND ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY P.FECHAELAB DESC"
        End If


        DESPLEGAR()
    End Sub

    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""

        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " AND ISNULL(P.ST_CARTA_PORTE,1) <> 5 
                    ORDER BY FECHAELAB DESC"
        Else
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " AND ISNULL(P.ST_CARTA_PORTE,1) = 5 
                    ORDER BY FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""

        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " AND ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY FECHAELAB DESC"
        Else
            CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " AND ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""

        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY FECHAELAB DESC"
        Else
            CADENA = " WHERE ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub

    Private Sub BtnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        N_TOP = ""

        If TAB1.SelectedIndex = 0 Then
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND ISNULL(P.ST_CARTA_PORTE,1) <> 5 
                    ORDER BY FECHAELAB DESC"
        Else
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND ISNULL(P.ST_CARTA_PORTE,1) = 5 
                    ORDER BY FECHAELAB DESC"
        End If

        DESPLEGAR()
    End Sub

    Private Sub TAB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged
        Try
            If TAB1.SelectedIndex = 0 Then
                barEliminar.Visible = True

                If Fg.Rows.Count = 1 Then
                    CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) <> 5 ORDER BY P.FECHAELAB DESC"
                    DESPLEGAR()
                End If
            Else
                barEliminar.Visible = False

                If Fg2.Rows.Count = 1 Then
                    CADENA = "WHERE ISNULL(P.ST_CARTA_PORTE,1) = 5 ORDER BY P.FECHAELAB DESC"
                    DESPLEGAR()
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
