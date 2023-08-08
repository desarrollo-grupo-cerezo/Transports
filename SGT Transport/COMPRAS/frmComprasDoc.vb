Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class frmComprasDoc
    Private CADENA As String
    Private TIPO_COMPRA_LOCAL As String
    Private N_TOP As String = " TOP 2000 "
    Private CVE_ART_RNBDO As String
    Private CVE_ART_REPARA As String
    Private CVE_CPTO_RENOVADO As Integer = 0
    Private CVE_CPTO_RENOVADO_ENT As Integer = 0
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub frmComprasDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub

    Sub CARGAR_DATOS1()
        Dim ThemeLocal As String

        Me.WindowState = FormWindowState.Maximized
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        SplitM.BorderWidth = 1
        SplitM.Dock = DockStyle.Fill
        Fg.Dock = DockStyle.Fill
        Try
            F1.Value = Date.Today
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            TIPO_COMPRA_LOCAL = TIPO_COMPRA

            ThemeLocal = ThemeElekos

            BarXML.Visible = False
            Select Case TIPO_COMPRA_LOCAL
                Case "c"
                    LtCompras.Text = "Compras"
                    BarXML.Visible = True

                    ThemeLocal = "Office2007Blue"

                Case "o"
                    LtCompras.Text = "Orden de Compra"
                Case "r"
                    LtCompras.Text = "Recepción"
                Case "q"
                    LtCompras.Text = "Requisición"
                Case "d"
                    LtCompras.Text = "Devolución compras"
                Case "p"
                    LtCompras.Text = "Pre-Orden de compra"
            End Select

            Try
                Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeLocal, True)
                C1ThemeController.ApplyThemeToControlTree(Me, theme)
                Fg.Styles.EmptyArea.BackColor = ColoFondoFG
            Catch ex As Exception
            End Try

            CARGA_PARAM_INVENT()

            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50

            Fg.FocusRect = FocusRectEnum.Solid
            Fg.SelectionMode = SelectionModeEnum.ListBox
            Fg.AutoClipboard = True
            Fg.ClipboardCopyMode = ClipboardCopyModeEnum.DataAndColumnHeaders

            Fg.Styles("Focus").ForeColor = Color.White
            Fg.Styles("Focus").BackColor = Color.CornflowerBlue
            Fg.Styles("Focus").Border.Color = Color.Red
            Fg.Styles("Focus").Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Both
            Fg.Styles("Focus").Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.Double

            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData

            DERECHOS()

            TITULOS()
            CADENA = "  ORDER BY FECHAELAB DESC"
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
        Fg.Rows.Count = 1
        Fg.Redraw = False
        Dim S1 As Decimal = 0, S2 As Decimal = 0, S3 As Decimal = 0, S4 As Decimal = 0, S5 As Decimal = 0, S6 As Decimal = 0

        Try
            If TIPO_COMPRA_LOCAL = "p" Then
                SQL = "SELECT " & N_TOP & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.STATUS, C.SU_REFER, C.FECHA_DOC, C.FECHA_REC, C.FECHA_PAG, 
                    C.FECHA_CANCELA, C.CAN_TOT, C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, 
                    C.FECHAELAB, C.IMPORTE, C.TIP_DOC_ANT  AS TIPO_D_ANT, ISNULL(C.DOC_ANT,'') AS DOCANT, C.TIP_DOC_SIG AS TIPO_D_SIG, 
                    ISNULL(C.DOC_SIG,'') AS DOCSIG, TIP_DOC AS OT
                    FROM COMPO_PRE C
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                    CADENA
            Else
                SQL = "SELECT " & N_TOP & " C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.STATUS, C.SU_REFER, C.FECHA_DOC, C.FECHA_REC, C.FECHA_PAG, C.FECHA_CANCELA, C.CAN_TOT, 
                    C.IMP_TOT1, C.IMP_TOT2, C.IMP_TOT3, C.IMP_TOT4, C.DES_TOT, C.DES_FIN, C.NUM_ALMA, C.FECHAELAB, C.IMPORTE, 
                    CASE ISNULL(C.TIP_DOC_ANT,'') WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' WHEN 'r' THEN 'Recepción' WHEN 'q' THEN 'Requsición' ELSE C.TIP_DOC_ANT END AS TIPO_D_ANT, 
                    ISNULL(C.DOC_ANT,'') AS DOCANT, 
                    CASE ISNULL(C.TIP_DOC_SIG,'') WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' WHEN 'r' THEN 'Recepción' WHEN 'q' THEN 'Requsición' ELSE C.TIP_DOC_SIG END AS TIPO_D_SIG, 
                    ISNULL(C.DOC_SIG,'') AS DOCSIG, 
                    CASE WHEN TIP_DOC = 'o' THEN (SELECT TOP 1 CVE_ORD FROM GCORDEN_TRA_SER_EXT WHERE TIEMPO_REAL = C.CVE_DOC) ELSE '' END AS OT
                    FROM COMP" & TIPO_COMPRA_LOCAL.ToUpper & Empresa & " C
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV " &
                    CADENA
            End If
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE").ToString.Trim & vbTab &
                                dr("STATUS") & vbTab & dr("SU_REFER") & vbTab & dr("FECHA_DOC") & vbTab & dr("FECHA_REC") & vbTab &
                                dr("FECHA_PAG") & vbTab & dr("FECHA_CANCELA") & vbTab & dr("CAN_TOT") & vbTab & dr("IMP_TOT1") & vbTab &
                                dr("IMP_TOT2") & vbTab & dr("IMP_TOT3") & vbTab & dr("IMP_TOT4") & vbTab & dr("IMPORTE") & vbTab &
                                dr("DES_TOT") & vbTab & dr("DES_FIN") & vbTab & dr("NUM_ALMA") & vbTab & dr("FECHAELAB") & vbTab &
                                dr("TIPO_D_ANT") & vbTab & dr("DOCANT") & vbTab & dr("TIPO_D_SIG") & vbTab & dr("DOCSIG") & vbTab &
                                dr("OT"))
                            'S1 += dr("CAN_TOT")
                            'S2 += dr("IMP_TOT1")
                            'S3 += dr("IMP_TOT2")
                            'S4 += dr("IMP_TOT3")
                            'S5 += dr("IMP_TOT4")
                            'S6 += dr("IMPORTE")
                        End While

                        Fg.Subtotal(AggregateEnum.Clear)
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
                        Fg.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")

                        'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                        '            "" & vbTab & S1 & vbTab & S2 & vbTab & S3 & vbTab & S4 & vbTab & S5 & vbTab & S6)
                    End Using
                End Using
            Catch SQLex As SqlException
                Dim SSS As SqlError, Sqlcadena As String = ""
                For Each SSS In SQLex.Errors
                    Sqlcadena += SSS.Message & vbNewLine
                Next
                BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Fg.AutoSizeCols()

            Fg.Cols(3).Width = 400
            Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter
            N_TOP = " TOP 1000 "
            LtNUm.Text = "Registros : " & Fg.Rows.Count - 1
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub Fg_AfterFilter(sender As Object, e As EventArgs) Handles Fg.AfterFilter

        Try
            If Fg.Rows.Count > 1 Then
                Fg.Subtotal(AggregateEnum.Clear)
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 11, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 12, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 13, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 14, "Grand Total")
                Fg.Subtotal(AggregateEnum.Sum, -1, -1, 15, "Grand Total")
            End If
        Catch ex As Exception
            'Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DERECHOS()
        Dim z As Integer = 0

        If Not pwPoder Then
            Try
                barNueva.Visible = False
                barModificar.Visible = False
                barCancelar.Visible = False
            Catch ex As Exception
            End Try

            Select Case TIPO_COMPRA_LOCAL
                Case "c"
                    Try
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 70100 AND CLAVE < 70500"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    Select Case dr("CLAVE")
                                        Case 70101
                                            barNueva.Visible = True
                                        Case 70130
                                            barModificar.Visible = True
                                        Case 70160
                                            barCancelar.Visible = True
                                    End Select
                                    z = z + 1
                                End While
                            End Using
                        End Using
                        If z = 0 Then
                            barNueva.Visible = True
                            barModificar.Visible = True
                            barCancelar.Visible = True
                        End If
                    Catch ex As Exception
                        Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "r"
                    Try
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 70500 AND CLAVE < 71000"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    Select Case dr("CLAVE")
                                        Case 70501
                                            barNueva.Visible = True
                                        Case 70530
                                            barModificar.Visible = True
                                        Case 70560
                                            barCancelar.Visible = True
                                    End Select
                                    z = z + 1
                                End While
                            End Using
                        End Using
                        If z = 0 Then
                            barNueva.Visible = True
                            barModificar.Visible = True
                            barCancelar.Visible = True
                        End If

                    Catch ex As Exception
                        Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                Case "o"
                    Try
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 71000 AND CLAVE < 71500"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    Select Case dr("CLAVE")
                                        Case 71001
                                            barNueva.Visible = True
                                        Case 71030
                                            barModificar.Visible = True
                                        Case 71060
                                            barCancelar.Visible = True
                                    End Select
                                    z = z + 1
                                End While
                            End Using
                        End Using
                        If z = 0 Then
                            barNueva.Visible = True
                            barModificar.Visible = True
                            barCancelar.Visible = True
                        End If
                    Catch ex As Exception
                        Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "q"
                    Try
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 71500 AND CLAVE < 80000"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    Select Case dr("CLAVE")
                                        Case 71501
                                            barNueva.Visible = True
                                        Case 71530
                                            barModificar.Visible = True
                                        Case 71560
                                            barCancelar.Visible = True
                                    End Select
                                    z = z + 1
                                End While
                            End Using
                        End Using
                        If z = 0 Then
                            barNueva.Visible = True
                            barModificar.Visible = True
                            barCancelar.Visible = True
                        End If

                    Catch ex As Exception
                        Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case "d"
                    Try
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 71700 AND CLAVE < 71800"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    Select Case dr("CLAVE")
                                        Case 71710
                                            barNueva.Visible = True
                                        Case 71720
                                            barModificar.Visible = True
                                        Case 71730
                                            barCancelar.Visible = True
                                    End Select
                                    z = z + 1
                                End While
                            End Using
                        End Using
                        If z = 0 Then
                            'barNueva.Visible = True
                            'barModificar.Visible = True
                            'barCancelar.Visible = True
                        End If

                    Catch ex As Exception
                        Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
        End If
    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(CVE_ART_RNBDO,'') AS ART_RBDO, ISNULL(CVE_ART_REPARA,'') AS ART_REPARA, 
                ISNULL(CVE_CPTO_RENOVADO,0) AS CVE_CPTO_REN, ISNULL(CVE_CPTO_RENOVADO_ENT,0) AS CVE_CPTO_REN_ENT
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                CVE_ART_RNBDO = dr("ART_RBDO")
                CVE_ART_REPARA = dr("ART_REPARA")

                CVE_CPTO_RENOVADO = dr("CVE_CPTO_REN")
                CVE_CPTO_RENOVADO_ENT = dr("CVE_CPTO_REN_ENT")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub barSalir_Click(sender As Object, e As EventArgs) Handles barSalir.Click
        Me.Close()
    End Sub
    Private Sub frmComprasDoc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Select Case TIPO_COMPRA_LOCAL
                Case "c"
                    CloseTab("Compras")
                Case "o"
                    CloseTab("Orden de Compra")
                Case "r"
                    CloseTab("Recepciones")
                Case "q"
                    CloseTab("Requisición")
                Case "d"
                    CloseTab("Devolución compras")
            End Select
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(Date.Now) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        tBox.Text = ""
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC = '" & FSQL(dt) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year & " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub

    Private Sub BarNueva_Click(sender As Object, e As EventArgs) Handles barNueva.Click
        Var17 = ""
        Var11 = "nueva"
        Var12 = ""
        Var13 = ""

        CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

        Try
            If FORM_IS_OPEN("frmComprasTrans") Then
                frmComprasTrans.Close()
                frmComprasTrans.Dispose()
            Else
                If OPEN_TAB("Compras") Or OPEN_TAB("Recepciones") Or OPEN_TAB("Orden de Compra") Or OPEN_TAB("Requisición") Or OPEN_TAB("Devolución compras") Then
                    frmComprasTrans.Close()
                    frmComprasTrans.Dispose()
                End If
            End If
        Catch ex As Exception
        End Try


        Select Case TIPO_COMPRA_LOCAL
            Case "c"
                CREA_TAB(frmComprasTrans, "Captura Compra")
            Case "o"
                CREA_TAB(frmComprasTrans, "Captura Orden de Compra")
            Case "r"
                CREA_TAB(frmComprasTrans, "Captura Recepcion")
            Case "q"
                CREA_TAB(frmComprasTrans, "Captura Requisición")
            Case "d"
                CREA_TAB(frmComprasTrans, "Captura devolución compras")
        End Select
    End Sub
    Private Sub barModificar_Click(sender As Object, e As EventArgs) Handles barModificar.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 4) = "C" Then
                    Var6 = "C"
                Else
                    Var6 = ""
                End If
                Var11 = "edit"
                Var12 = Fg(Fg.Row, 1)
                Var13 = Fg(Fg.Row, 23) 'DOCUMENTO SIGUIENTE
                Var14 = Fg(Fg.Row, 20) 'DOCUMENTO ANTERIOR
                Var17 = ""
                If Var12.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione un documento")
                    Return
                End If

                CloseTab("Captura Compra", "Captura Recepcion", "Captura Orden de Compra", "Captura Requisición", "Captura devolución compras")

                Select Case TIPO_COMPRA_LOCAL
                    Case "c"
                        CREA_TAB(frmComprasTrans, "Captura Compra")
                    Case "o"
                        CREA_TAB(frmComprasTrans, "Captura Orden de Compra")
                    Case "r"
                        CREA_TAB(frmComprasTrans, "Captura Recepcion")
                    Case "q"
                        CREA_TAB(frmComprasTrans, "Captura Requisición")
                    Case "d"
                        CREA_TAB(frmComprasTrans, "Captura devolución compras")
                End Select
            Else
                MsgBox("Por favor seleccione un documento")
            End If
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles barCancelar.Click
        Try
            Dim EXIST_G As String, CADENA_EXIST As String, CVE_DOC As String, PAR_COMP_ANT As Integer
            'MOVSINV
            Dim NUM_ALM As Integer, CVE_CPTO As Integer, TIPO_DOC As String, REFER As String, CLAVE_CLPV As String, CVE_VEND As String, CANT_COST As Single
            Dim COSTO As Single, AFEC_COI As String, FACTOR_CON As Single, CVE_FOLIO As String, SIGNO As Integer, COSTEADO As String
            Dim COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String, MOV_ENLAZADO As Integer, CVE_OBS As Long
            Dim REG_SERIE As Integer, UNI_VENTA As String, E_LTPD As Integer, TIPO_PROD As String, CTLPOL As Integer
            Dim DOC_SIG As String = "", TIP_DOC_SIG As String = "", TIP_DOC_ANT As String = "", DOC_ANT As String = "", CANT As Decimal
            Dim NUM_MOV As Long, CVE_ART As String, EXISTEN_ABONOS As Boolean = False, TIP_DOC_ANT2 As String = ""


            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            Dim dr As SqlDataReader


            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120
            cmd2.Connection = cnSAE
            cmd2.CommandTimeout = 120
            'FIN MOVSINV

            If Fg.Row <= 0 Then
                MsgBox("Por favor seleccione una compra")
                Return
            End If

            CVE_DOC = Fg(Fg.Row, 1)
            CLAVE_CLPV = Fg(Fg.Row, 2)
            Try
                DOC_SIG = Fg(Fg.Row, 23)
                DOC_ANT = Fg(Fg.Row, 21)
            Catch ex As Exception
            End Try

            Try
                Select Case Fg(Fg.Row, 22).ToString
                    Case "Orden de compra"
                        TIP_DOC_SIG = "O"
                    Case "Recepción"
                        TIP_DOC_SIG = "R"
                    Case "Requsición"
                        TIP_DOC_SIG = "Q"
                End Select
            Catch ex As Exception
                Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                Select Case Fg(Fg.Row, 20).ToString
                    Case "Orden de compra"
                        TIP_DOC_ANT = "O"
                    Case "Recepción"
                        TIP_DOC_ANT = "R"
                    Case "Requsición"
                        TIP_DOC_ANT = "Q"
                    Case Else
                        TIP_DOC_ANT = "O"
                        TIP_DOC_ANT2 = Fg(Fg.Row, 20).ToString
                End Select
            Catch ex As Exception
                Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If DOC_SIG.Trim.Length > 0 Then
                MsgBox("El folio " & CVE_DOC & " se le genero el documento " & DOC_SIG & TIP_DOC_SIG & " no se puede cancelar")
                Exit Sub
            End If

            If MsgBox("Realmente desea cancelar documento " & CVE_DOC & "?", vbYesNo) = vbNo Then
                Exit Sub
            End If

            If Fg(Fg.Row, 4) = "C" Then
                MsgBox("El documento ya se encuentra cancelado")
                Exit Sub
            End If


            If TIPO_COMPRA_LOCAL.ToUpper = "C" Then
                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT REFER FROM PAGA_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                    cmd3.CommandText = SQL
                    Using dr3 As SqlDataReader = cmd3.ExecuteReader
                        If dr3.Read Then
                            EXISTEN_ABONOS = True
                        End If
                    End Using
                End Using

                If EXISTEN_ABONOS Then
                    MsgBox("La compra tiene abonos, no es posible realizar la cancelación, verifique por favor")
                    Return
                End If
            End If

            SQL = "UPDATE COMP" & TIPO_COMPRA_LOCAL.ToUpper & Empresa & " SET 
                FECHA_CANCELA = CONVERT(varchar, GETDATE(), 112), STATUS = 'C', ENLAZADO = 'O', TIP_DOC_ANT = '', DOC_ANT = '' 
                WHERE CVE_DOC = '" & CVE_DOC & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            If TIP_DOC_ANT2 = "p" Then
                SQL = "UPDATE COMPO_PRE SET ENLAZADO = 'O', TIP_DOC_SIG = '', DOC_SIG = '' WHERE CVE_DOC = '" & DOC_ANT & "'"
                EXECUTE_QUERY_NET(SQL)
            End If

            If TIPO_COMPRA_LOCAL.ToUpper = "C" Or TIPO_COMPRA_LOCAL.ToUpper = "D" Then
                SQL = "DELETE FROM PAGA_M" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                SQL = "DELETE FROM PAGA_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End If
            '====================================
            If TIP_DOC_ANT.Trim.Length > 0 Then
                SQL = "UPDATE COMP" & TIP_DOC_ANT & Empresa & " SET ENLAZADO = 'O', DOC_SIG = '', TIP_DOC_SIG = '' WHERE DOC_SIG = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End If
            '====================================================

            If TIPO_COMPRA_LOCAL.ToUpper = "C" Or TIPO_COMPRA_LOCAL.ToUpper = "R" Or TIPO_COMPRA_LOCAL.ToUpper = "D" Then

                SQL = "SELECT P.CVE_ART, P.NUM_ALM, P.CANT, I.TIPO_ELE, P.NUM_PAR, P.PREC, P.COST, P.UNI_VENTA
                    FROM PAR_COMP" & TIPO_COMPRA_LOCAL.ToUpper & Empresa & " P
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                    WHERE P.CVE_DOC = '" & CVE_DOC & "' AND I.TIPO_ELE = 'P'"

                cmd2.CommandText = SQL
                dr = cmd2.ExecuteReader
                Do While dr.Read

                    NUM_ALM = dr("NUM_ALM")
                    CANT = dr.ReadNullAsEmptyDecimal("CANT")
                    CVE_ART = dr("CVE_ART")

                    Try
                        If DOC_ANT.Trim.Length > 0 Then

                            PAR_COMP_ANT = BUSCAR_PARTIDA_DOCTOSIGC(CVE_DOC, DOC_ANT, dr("NUM_PAR"))

                            If PAR_COMP_ANT > 0 Then
                                SQL = "UPDATE PAR_COMP" & TIP_DOC_ANT.ToUpper & Empresa & " SET PXR = " & CANT & " WHERE
                                        CVE_DOC = '" & DOC_ANT & "' AND NUM_PAR = " & PAR_COMP_ANT
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If TIP_DOC_ANT <> "R" Then


                        If TIPO_COMPRA_LOCAL.ToUpper = "D" Then
                            SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & dr("CANT") & " WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If

                            If MULTIALMACEN = 1 Then
                                SQL = "UPDATE MULT" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & CANT & " 
                            WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End If
                            SIGNO = 1
                            CVE_CPTO = 5
                        Else
                            SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & dr("CANT") & " WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If

                            If MULTIALMACEN = 1 Then
                                SQL = "UPDATE MULT" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & CANT & " 
                            WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End If
                            SIGNO = -1
                            CVE_CPTO = 57
                        End If

                        'MOVSINV
                        TIPO_DOC = "c" : REFER = CVE_DOC : COSTO = dr("COST") : CANT_COST = COSTO * CANT : AFEC_COI = "" : CVE_OBS = 0 : REG_SERIE = 0
                        UNI_VENTA = dr("UNI_VENTA").ToString : E_LTPD = 0 : TIPO_PROD = "P" : FACTOR_CON = 1 : CTLPOL = 0 : COSTEADO = "S"

                        COSTO_PROM_INI = CANT_COST
                        COSTO_PROM_FIN = CANT_COST : DESDE_INVE = "S" : MOV_ENLAZADO = 0 : CVE_VEND = "" : CVE_FOLIO = ""

                        EXIST_G = "ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)" 'EXIST_G

                        If MULTIALMACEN = 1 Then
                            CADENA_EXIST = "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM & "),0)"   'EXISTENCIA
                        Else
                            CADENA_EXIST = "COALESCE((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)"  'EXISTENCIA
                        End If

                        SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO) 
                            OUTPUT Inserted.NUM_MOV VALUES('" &
                            CVE_ART & "','" & NUM_ALM & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & CVE_CPTO &
                            "',Convert(varchar, GETDATE(), 112),'" & TIPO_COMPRA_LOCAL & "','" & REFER & "','" & CLAVE_CLPV & "','" &
                            CVE_VEND & "','" & CANT & "','" & CANT_COST & "','" & dr("PREC") & "','" & COSTO & "','" & REG_SERIE & "','" &
                            UNI_VENTA & "','" & E_LTPD & "'," & EXIST_G & "," & CADENA_EXIST & ",'" & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE()" &
                            ",(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                            SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "')"
                        Try
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteScalar().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                            Try
                                NUM_MOV = returnValue
                            Catch ex As Exception
                            End Try
                        Catch ex As Exception
                            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                Loop
                dr.Close()
            End If
            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA
            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA
            'TERMINA LA CANCELACION DE LAS PARTIDAS DE LA COMPRA

            'INICIO LLANTAS MINVE
            'COMPRAS LLANTAS MINVE
            If TIPO_COMPRA_LOCAL = "o" Or TIPO_COMPRA_LOCAL = "c" Then
                Try
                    Dim CVE_LLANTA As String, CVE_UNI As String
                    UNI_VENTA = ""

                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(LL.COSTO_LLANTA_MN,0) AS COST, M.CVE_LLANTA, M.NUM_ECONOMICO, M.NUM_PAR, ISNULL(M.CVE_UNI,'') AS UNIDAD, 
                        ISNULL(M.POSICION,0) AS POS
                        FROM GCLLA_REN_COMP M 
                        LEFT JOIN GCLLANTAS LL ON LL.NUM_ECONOMICO = M.NUM_ECONOMICO
                        WHERE M.CVE_DOC = '" & CVE_DOC & "' AND M.TIPO_DOC = '" & TIPO_COMPRA_LOCAL & "'"
                        cmd3.CommandText = SQL
                        Using dr3 As SqlDataReader = cmd3.ExecuteReader
                            While dr3.Read
                                Try
                                    If TIPO_COMPRA_LOCAL = "o" Then

                                        CVE_UNI = dr3("UNIDAD").ToString

                                        If CVE_UNI.Trim.Length > 0 Then

                                            CVE_LLANTA = dr3("CVE_LLANTA")

                                            If dr3("POS") = 1 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL1 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("POS") = 2 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL2 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("POS") = 3 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL3 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("POS") = 4 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL4 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("POS") = 5 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL5 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("POS") = 6 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL6 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL7") = 7 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL7 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL8") = 8 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL8 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL9") = 9 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL9 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL10") = 10 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL10 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL11") = 11 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL11 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            ElseIf dr3("CHLL12") = 12 Then
                                                SQL = "UPDATE GCUNIDADES SET CHLL12 = '" & CVE_LLANTA & "' WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                            End If
                                            Try
                                                Using cmd5 As SqlCommand = cnSAE.CreateCommand
                                                    cmd5.CommandText = SQL
                                                    returnValue = cmd5.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                                MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                            'ASIGNADA
                                            SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = 1, TIPO_NUEVA_RENO = 1 WHERE NUM_ECONOMICO = '" & dr3("NUM_ECONOMICO") & "'"
                                        Else
                                            'PARA RENOVAR
                                            SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = 4, TIPO_NUEVA_RENO = 1 WHERE NUM_ECONOMICO = '" & dr3("NUM_ECONOMICO") & "'"
                                        End If
                                    Else
                                        'CANCELACION COMPRA
                                        'PENDIENTE X ASIGNAR
                                        SQL = "UPDATE GCLLANTAS SET STATUS_LLANTA = 4, TIPO_NUEVA_RENO = 1 WHERE NUM_ECONOMICO = '" & dr3("NUM_ECONOMICO") & "'"
                                    End If
                                    Using cmd5 As SqlCommand = cnSAE.CreateCommand
                                        cmd5.CommandText = SQL
                                        returnValue = cmd5.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                    MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                GRABA_BITA(CLAVE_CLPV, CVE_DOC, COSTO, "M", " Movs. inv. cancelacion compra renovada llanta num. economico " &
                                                            dr3("NUM_ECONOMICO"))
                            End While
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'FINNNNNNN      COMPRAS LLANTAS MINVE
                'FIN  LLANTAS MINVE
            End If

            Try
                SQL = "DELETE FROM GCORDEN_TRA_SER_EXT WHERE TIEMPO_REAL = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                Bitacora("115. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("115. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'Fg(Fg.Row, 4) = "C"
            N_TOP = " TOP 1000 "
            CADENA = "  ORDER BY FECHAELAB DESC"
            DESPLEGAR()
            MsgBox("El documento se cancelo satisfactoriamente")
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCA_ARTICULO_EN_LLANTAS(FNUM_ECONOMICO As String) As String
        Dim ART As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ART FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ART = dr("CVE_ART")
                    End If
                End Using
            End Using
            Return ART
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ART
        End Try
    End Function
    Private Function BUSCAR_PARTIDA_DOCTOSIGC(fCVE_DOC As String, fDOC_ANT As String, fNUM_PAR As Integer) As Integer
        Dim PARTIDA As Integer = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT PART_E FROM DOCTOSIGC" & Empresa & " WHERE 
                    CVE_DOC = '" & fCVE_DOC & "' AND CVE_DOC_E = '" & fDOC_ANT & "' AND PARTIDA = " & fNUM_PAR
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PARTIDA = dr("PART_E")
                    End If
                End Using
            End Using
            Return PARTIDA
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            Return PARTIDA
        End Try
    End Function

    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles tBox.TextChanged
        Try
            CADENA = "WHERE (UPPER(CVE_DOC) LIKE '%" & tBox.Text & "%' OR CVE_CLPV LIKE '%" & tBox.Text & "%' OR 
                    UPPER(NOMBRE) LIKE '%" & tBox.Text & "%') ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, 1))
        Catch ex As Exception
        End Try
        Try
            barModificar_Click(Nothing, Nothing)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tBox.KeyPress
        Try
            If e.KeyChar.ToString() = "'" Or e.KeyChar.ToString() = "[" Or e.KeyChar.ToString() = "]" Or e.KeyChar.ToString() = "'" Then
                e.KeyChar = " "
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarXML_Click(sender As Object, e As EventArgs) Handles BarXML.Click
        Var17 = "C"
        CREA_TAB(frmComprasXML, "Documentos XML")
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        Try
            N_TOP = " TOP 1000 "
            CADENA = " ORDER BY FECHAELAB DESC"
            DESPLEGAR()
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        tBox.Text = ""
        N_TOP = ""
        CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' ORDER BY FECHAELAB DESC"
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, LtCompras.Text)
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg.Cols.Count = 24
            Fg(0, 1) = "Documento"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Proveedor"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Nombre"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Estatus"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Su refer."
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(DateTime)

            Fg(0, 7) = "Fecha rec."
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Fecha pag."
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(DateTime)

            Fg(0, 9) = "Fecha cancelada"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(DateTime)

            Fg(0, 10) = "Sub. tottal"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "IEPS"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Retención ISR"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Retención IVA"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(Decimal)
            Fg.Cols(13).Format = "###,###,##0.00"

            Fg(0, 14) = "IVA"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(Decimal)
            Fg.Cols(14).Format = "###,###,##0.00"

            Fg(0, 15) = "Importe"
            Dim c19 As Column = Fg.Cols(15)
            c19.DataType = GetType(Decimal)
            Fg.Cols(15).Format = "###,###,##0.00"

            Fg(0, 16) = "Descuento"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Des. fin."
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Almacen"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Int32)

            Fg(0, 19) = "Fecha elab."
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(DateTime)

            Fg(0, 20) = "Tipo documento anterior"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(String)

            Fg(0, 21) = "Documento anterior"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(String)

            Fg(0, 22) = "Tipo documento siguiente"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(String)

            Fg(0, 23) = "Documento siguiente"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(String)

            Fg(0, 24) = "Orden de trabajo"
            Dim c24 As Column = Fg.Cols(24)
            c24.DataType = GetType(String)
            c24.TextAlign = TextAlignEnum.CenterCenter

            Fg.Cols(9).Width = 80
            Fg.Cols(20).Width = 100
            'Fg.Cols(21).Width = 130
            'Fg.Cols(23).Width = 130
            Fg.Cols(22).Width = 100
            Fg.Cols(24).Width = 60

            Fg.Cols(9).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(20).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(22).TextAlign = TextAlignEnum.CenterCenter
        Catch ex As Exception
        End Try
    End Sub
End Class
