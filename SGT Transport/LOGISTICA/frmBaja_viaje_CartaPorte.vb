Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmBaja_viaje_CartaPorte
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private SERIE_REM_CP As String = ""
    Private SERIE_CAP_FAC As String = ""
    Private CVE_ART_CP As String
    Private CC1 As String
    Private CC2 As String
    Private VALOR_DECLA_DESDE_SAE As Integer
    Private CADENA As String = ""
    Private N_TOP As String = ""
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGA_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGA_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            BarTimbrarCPConPrecios.Text = "Timbrar carta porte" & vbNewLine & "con precios"

            Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.UserPaint, True)
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 40
            'Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            'Fg.Height = Me.Height - 150

            Fg.Dock = DockStyle.Fill

            DERECHOS()

            N_TOP = "TOP 3000"
            CADENA = ""
            CARGA_PARAM_INVENT()

            DESPLEGAR()
        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmBaja_viaje_CartaPorte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarRF.Visible = False
                BarTimbrarCPConPrecios.Visible = False
                BarCFDI.Visible = False
                BarReactivar.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "'AND  CLAVE >= 23500 AND CLAVE < 23600"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 23510  '
                                    BarRF.Visible = True
                                Case 23520  '
                                Case 23530  '
                                    BarTimbrarCPConPrecios.Visible = True
                                Case 23535
                                    BarReactivar.Visible = True
                                Case 23540  '
                                    BarCFDI.Visible = True
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
    Sub CARGA_PARAM_INVENT()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            SQL = "SELECT ISNULL(SERIE_CARTA_PORTE, '') AS SERIE_REM, CVE_ART_CP, ISNULL(SERIE_CAP_FACTURA,'') AS SER_CAP_FAC FROM GCPARAMVENTAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_REM_CP = dr("SERIE_REM")
                        SERIE_CAP_FAC = dr("SER_CAP_FAC")
                        CVE_ART_CP = dr.ReadNullAsEmptyString("CVE_ART_CP")
                    Else
                        SERIE_REM_CP = ""
                        CVE_ART_CP = ""
                    End If
                End Using
            End Using

            Try
                SQL = "SELECT ISNULL(IEPS,4)AS RET, VALOR_DECLA_DESDE_SAE FROM GCPARAMTRANSCG"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            VALOR_DECLA_DESDE_SAE = dr.ReadNullAsEmptyInteger("VALOR_DECLA_DESDE_SAE")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If VALOR_DECLA_DESDE_SAE = 0 Then
                CC1 = "CVE_VAL_DECLA"
                CC2 = "VALOR_DECLARADO"
            Else
                CC1 = "CVE_MAT"
                CC2 = "VALOR_DECLARADO"
            End If

        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor

        Try
            LtCliente.Text = ""
            Fg.Redraw = False
            '2 CARTA PORTE
            '3 VIAJE
            '4 REMISION
            '5 CLIENTE
            '6 CVE_DOCP PEDIDO
            '7 TIMBRADO
            '8 FECHA
            '9 FULL SENCILLO
            '10 CARGADO VACIO
            '11 NOMBRE OPERADOR
            '12 CVE_TRACTOR
            '13 CVE_TANQUE1
            '14 CVE_TANQUE2
            '15 RECOGER EN
            '16 ENTREGAR 
            '17 STATUS CARTA PORTE
            '18 REM CARGA 1
            '19 NETO1
            '20 REM CARGA2
            '21 NETO2
            '22 REM CARGA3
            '23 NETO3
            '24 REM CARGA4
            '25 NETO 4
            '26 DESCR VALOR DECLARADO
            '27 VALOR DECLARADO

            'ST_CARTA_PORTE = 4 REGRESO
            'ST_CARTA_PORTE = 2 ACEPTADA
            'ST_CARTA_PORTE = 3 TRANSFERIDO
            SQL = "SELECT " & N_TOP & " ISNULL(SELECCIONE,0) AS SELE, CVE_FOLIO, CVE_VIAJE, CASE WHEN P.CVE_DOCR = '0' THEN '' ELSE ISNULL(P.CVE_DOCR,'') END, 
                '(' + ISNULL(RIGHT('     '+ISNULL(LTRIM(RTRIM(P.CLIENTE)),''),5),'') + ')   ' + ISNULL(C.NOMBRE,''), P.CVE_DOCP, 
                ISNULL((SELECT TOP 1 FACTURA FROM CFDI WHERE DOCUMENT = P.CVE_FOLIO OR DOCUMENT2 = P.CVE_FOLIO),'') AS 'Factura',
                CASE WHEN ISNULL(TIMBRADA,'') = 'S' THEN 'Timbrado' ELSE '' END AS 'Timbrado',
                P.FECHA_DOC, (CASE P.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, 
                (CASE P.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, O.NOMBRE AS OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, 
                P.CVE_TANQUE2, RE.DESCR AS RECEN, EE.DESCR AS ENTEN, ISNULL(ST.DESCR,'') AS DESCR_ST, REM_CARGA1, (PESO_BRUTO1 - TARA1) AS NETO1, REM_CARGA2, 
                (PESO_BRUTO2 - TARA2) AS NETO2, REM_CARGA3, (PESO_BRUTO3 - TARA3) AS NETO3, REM_CARGA4, (PESO_BRUTO4 - TARA4) AS NETO4, 
                '(' + CAST(CVE_VAL_DECLA AS VARCHAR(5)) + ')  ' + V.DESCR, VALOR_DECLARADO
                FROM GCCARTA_PORTE P
                LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = P.ST_CARTA_PORTE
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CLIENTE
                LEFT JOIN GCOPERADOR O ON O.CLAVE = P.CVE_OPER
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = P.RECOGER_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = P.ENTREGAR_EN
                LEFT JOIN GCVALOR_DECLARADO V ON V.CLAVE = P.CVE_VAL_DECLA
                WHERE P.STATUS = 'A' AND 
                (ISNULL(ST_CARTA_PORTE,-1) = 2 OR ISNULL(ST_CARTA_PORTE,-1) = -1 OR ISNULL(ST_CARTA_PORTE,-1) = 3) 
                " & CADENA & " ORDER BY P.FECHAELAB DESC"
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource


            Fg(0, 1) = "Seleccione"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Boolean)
            cc1.AllowEditing = True

            Fg(0, 2) = "Folio"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "Viaje"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Remisión"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Nombre"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Pedido"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)

            Fg(0, 7) = "Factura"
            Dim cc6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "Estatus CFDI"
            Dim cc7 As Column = Fg.Cols(8)
            cc7.DataType = GetType(String)

            Fg(0, 9) = "Fecha"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(DateTime)
            c8.Format = "d"

            Fg(0, 10) = "Tipo unidad"
            Dim cc9 As Column = Fg.Cols(10)
            cc9.DataType = GetType(Int32)

            Fg(0, 11) = "Tipo viaje"
            Dim cc10 As Column = Fg.Cols(11)
            cc10.DataType = GetType(Int32)

            Fg(0, 12) = "Nombre operador"
            Dim cc11 As Column = Fg.Cols(12)
            cc11.DataType = GetType(Int32)

            Fg(0, 13) = "Tractor"
            Dim cc12 As Column = Fg.Cols(13)
            cc12.DataType = GetType(String)

            Fg(0, 14) = "Tanque1"
            Dim cc13 As Column = Fg.Cols(14)
            cc13.DataType = GetType(String)

            Fg(0, 15) = "Tanque2"
            Dim cc14 As Column = Fg.Cols(15)
            cc14.DataType = GetType(String)

            Fg(0, 16) = "Recoger en"
            Dim cc15 As Column = Fg.Cols(16)
            cc15.DataType = GetType(String)

            Fg(0, 17) = "Entregar en"
            Dim cc16 As Column = Fg.Cols(17)
            cc16.DataType = GetType(String)

            Fg(0, 18) = "Estatus carta porte"
            Dim cc17 As Column = Fg.Cols(18)
            cc17.DataType = GetType(String)

            Fg(0, 19) = "Remision carga 1"
            Dim cc18 As Column = Fg.Cols(19)
            cc18.DataType = GetType(String)

            Fg(0, 20) = "Peso neto"
            Dim cc19 As Column = Fg.Cols(20)
            cc19.DataType = GetType(Decimal)
            cc19.Format = "N4"

            Fg(0, 21) = "Remision carga 2"
            Dim cc20 As Column = Fg.Cols(21)
            cc20.DataType = GetType(String)

            Fg(0, 22) = "Peso neto"
            Dim cc21 As Column = Fg.Cols(22)
            cc21.DataType = GetType(Decimal)
            cc21.Format = "N4"

            Fg(0, 23) = "Remision carga 3"
            Dim cc22 As Column = Fg.Cols(23)
            cc22.DataType = GetType(String)

            Fg(0, 24) = "Peso neto"
            Dim cc23 As Column = Fg.Cols(24)
            cc23.DataType = GetType(Decimal)
            cc23.Format = "N4"

            Fg(0, 25) = "Remision carga 4"
            Dim cc24 As Column = Fg.Cols(25)
            cc24.DataType = GetType(String)

            Fg(0, 26) = "Peso neto"
            Dim cc25 As Column = Fg.Cols(26)
            cc25.DataType = GetType(Decimal)
            cc25.Format = "N4"

            Fg(0, 27) = "Descripcion valor declarado"
            Dim cc26 As Column = Fg.Cols(27)
            cc26.DataType = GetType(String)

            Fg(0, 28) = "Valor declarado"
            Dim cc27 As Column = Fg.Cols(28)
            cc27.DataType = GetType(Decimal)
            cc27.Format = "N2"

            If PASS_GRUPOCE = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
            End If

            'Fg.AutoSizeCols()
            Fg.Cols(5).Width = 300

            If Fg.Row > 0 Then
                Fg.Row = 1
            End If

        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub FrmBaja_viaje_CartaPorte_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Baja carta porte")
        Me.Dispose()
    End Sub

    Private Sub BarConsultar_Click(sender As Object, e As EventArgs) Handles BarConsultar.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"
            Var2 = Fg(Fg.Row, 2)
            'CREA_TAB(FrmCartaPorteAE, "Movimientos Carta Porte")
        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub
    Private Sub BarRF_Click(sender As Object, e As EventArgs) Handles BarRF.Click
        Dim NO_EXIST_ART As Boolean = False, z As Integer = 0

        For k = 1 To Fg.Rows.Count - 1
            If Fg(k, 1) Then
                z += 1
            End If
        Next
        If z = 0 Then
            MsgBox("Por favor seleccione la ó las cartas porte a remisionar")
            Return
        End If

        If Not Valida_Conexion() Then
            MsgBox("Imposible conectarse a la base de datos")
            Return
        End If
        If Not Valida_Conexion_SAROCE() Then
            MsgBox("Imposible conectarse a la base de configuración")
            Return
        End If

        If CVE_ART_CP = "" Then
            MsgBox("Por favor capture la clave del servicio de la carta porte, en configuración-parámetros del sistema-ventas")
            If MsgBox("Desea capturar la clave del servicio en este momento?", vbYesNo) = vbYes Then
                frmParamVentas.ShowDialog()
                CARGA_PARAM_INVENT()

            End If
            Return
        End If

        If SERIE_REM_CP = "" Then
            MsgBox("Por favor capture la serie de la remisión de la carta porte, en configuración-parámetros del sistema-ventas")
            If MsgBox("Desea capturar la serie en este momento?", vbYesNo) = vbYes Then
                frmParamVentas.ShowDialog()
                CARGA_PARAM_INVENT()
            End If
            Return
        End If

        Dim ImporteConDes As Single, SUBTOTAL As Single
        Dim TIP_DOC As String, CVE_DOC As String, CVE_CLPV As String = "", STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim FECHA_DOC As String, FECHA_VEN As String, CAN_TOT As Single, IMP_TOT1 As Single, IMP_TOT2 As Single, IMP_TOT3 As Single
        Dim IMP_TOT4 As Single, DES_TOT As Single, DES_FIN As Single, COM_TOT As Single, UNI_VENTA As String
        Dim CONDICION As String, CVE_OBS As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Long, TIPCAMB As Single, NUM_PAGOS As Long, PRIMERPAGO As Single, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, FOLIO As Long, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String
        Dim CVE_BITA As Long, Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Single, DES_TOT_PORC As Single, COM_TOT_PORC As Single
        Dim METODODEPAGO As String, NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Long, IMPORTE As Single
        Dim CVE_ART As String = "", CANT As Single, PRECIO As Decimal, PXS As Single, PREC As Single, COST As Single, IMPU1 As Single, IMPU2 As Single
        Dim IMPU3 As Single, IMPU4 As Single, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer, TOTIMP1 As Single
        Dim TOTIMP2 As Single, TOTIMP3 As Single, TOTIMP4 As Single, DESC1 As Single, Desc2 As Single, Desc3 As Single, COMI As Single, APAR As Single
        Dim ACT_INV As String, NUM_ALM As Integer, POLIT_APLI As String, TIP_CAM As Single = 1, TIPO_PROD As String, REG_SERIE As Long, E_LTPD As Long
        Dim TIPO_ELEM As String, TOT_PARTIDA As Single, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer, APL_MAN_IEPS As String
        Dim MTO_PORC As Integer, MTO_CUOTA As Integer, ULT_COSTO As Single, COSTO_PROM As Single, CVE_ESQIMPU As Integer = 1, DESCR As String, UNI_MED As String
        'MOVSINV
        Dim FOLIO_ASIGNADO As Boolean, SIGUE As Boolean, Existe As Boolean, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Dim CVE_FOLIO As String,USO_CFDI As String
        Dim TONELADAS As Decimal = 0, REMISION As String = "", TALON_EMBARQUE As String, UNIDAD As String = "", FECHA As String = ""

        Dim cmdOT As New SqlCommand

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader


        If Fg.Row <= 0 Then
            MsgBox("Por favor seleccione una carta porte")
            Return
        End If

        If Fg(Fg.Row, 5) = "" Or Fg(Fg.Row, 5).ToString.Replace(" ", "") = "()" Then
            MsgBox("La carta porte no tiene capturado el cliente fiscal, verifique por favor")
            Return
        End If

        CVE_PEDI = "CARTA PORTE"
        UNI_MED = "" : MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
        IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0 : CONDICION = "Contado"
        CVE_OBS = 0 : ACT_CXC = "S" : ACT_COI = "N" : ENLAZADO = "O" : TIP_DOC_E = "O" : NUM_MONED = 1 : TIPCAMB = 1 : NUM_PAGOS = 1
        RFC = "" : CTLPOL = 0 : ESCFD = "N" : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
        FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
        DAT_ENVIO = 0 : USO_CFDI = "" : COM_TOT_PORC = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC_ANT = "" : DOC_ANT = ""
        STATUS = "E"

        Try
            Dim dt As DateTime = Now

            FECHA_DOC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")
        Catch ex As Exception
            FECHA_DOC = Date.Now.Year & Format(Date.Now.Month, "00") & Format(Date.Now.Day, "00")
        End Try
        FECHA_VEN = FECHA_DOC
        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180
        Catch ex As Exception
            Bitacora("1700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        TIP_DOC = "R"
        TIPO_VENTA = "R"
        CVE_DOC = ""

        If MsgBox("Realmente desea grabar la Remisión?", vbYesNo, "Serie: " & SERIE_REM_CP) = vbNo Then
            Exit Sub
        End If

        Dim LETRA_VENTA As String, FOLIO_VENTA As Long

        Try
            SIGUE = True
            FOLIO_ASIGNADO = False
            LETRA_VENTA = SERIE_CAP_FAC

            FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA, LETRA_VENTA)

            Do While SIGUE
                If LETRA_VENTA.Trim.Length = 0 Or LETRA_VENTA = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                Else
                    CVE_DOC = LETRA_VENTA & FOLIO_VENTA
                End If

                If EXISTE_VENTA(TIPO_VENTA, CVE_DOC) Then
                    FOLIO_VENTA += 1
                    FOLIO_ASIGNADO = True
                Else
                    SIGUE = False
                End If
            Loop
        Catch ex As Exception
            Bitacora("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        If MULTIALMACEN = 1 Then
            Try
                NUM_ALM = 1
            Catch ex As Exception
                NUM_ALM = 1
            End Try
        Else
            NUM_ALM = 1
        End If

        Me.Cursor = Cursors.WaitCursor

        SERIE = SERIE_VENTA
        FOLIO = FOLIO_VENTA
        IMPORTE = 0 : CAN_TOT = 0

        If Not Valida_Conexion() Then
            Return
        End If

        cmdOT.Connection = cnSAE
        cmdOT.CommandTimeout = 180

        'YA NO SE TOMA LA CLAE DEL ARTICULO DESDE LA CLAVE DE CONFIGURACION
        'CVE_ART = CVE_ART_CP

        For k = 1 To Fg.Rows.Count - 1

            CANT = 1
            CVE_FOLIO = Fg(k, 2)

            If Fg(k, 1) Then

                Try
                    NUM_ALM = 1
                Catch ex As Exception
                    NUM_ALM = 1
                End Try
                Try
                    'OBTENER DATOS DE LA CARTA PORTE
                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT C.CLIENTE, C.FLETE, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, ddmmyyyy = convert(varchar(10), FECHA_DOC, 103), 
                                ISNULL(C.REM_CARGA1,'') AS REM1, ISNULL(C.PESO_BRUTO1,0) AS P1, ISNULL(C.TARA1,0) AS T1, 
                                ISNULL(C.REM_CARGA2,'') AS REM2, ISNULL(C.PESO_BRUTO2,0) AS P2, ISNULL(C.TARA2,0) AS T2, 
                                ISNULL(C.REM_CARGA3,'') AS REM3, ISNULL(C.PESO_BRUTO3,0) AS P3, ISNULL(C.TARA3,0) AS T3, 
                                ISNULL(C.REM_CARGA4,'') AS REM4, ISNULL(C.PESO_BRUTO4,0) AS P4, ISNULL(C.TARA4,0) AS T4, 
                                C.REM_CARGA, CVE_MAT, ISNULL(CANT,1) AS CANTIDAD
                                FROM GCCARTA_PORTE C
                                WHERE CVE_FOLIO = '" & CVE_FOLIO & "'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    'DOCUMENTO
                                    CVE_CLPV = dr2("CLIENTE")

                                    CANT = dr2("CANTIDAD")
                                    If CANT = 0 Then
                                        CANT = 1
                                    End If

                                    CVE_ART = dr2("CVE_MAT")
                                    If CVE_ART = "0" Then
                                        CVE_ART = ""
                                    End If

                                    PRECIO = dr2("FLETE")
                                    Select Case dr2.ReadNullAsEmptyInteger("REM_CARGA")
                                        Case 1
                                            TONELADAS = dr2("P1") - dr2("T1") '1
                                            REMISION = dr2("REM1") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 2
                                            TONELADAS = dr2("P2") - dr2("T2") '1
                                            REMISION = dr2("REM1") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 3
                                            TONELADAS = dr2("P3") - dr2("T3") '1
                                            REMISION = dr2("REM1") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 4
                                            TONELADAS = dr2("P4") - dr2("T4") '1
                                            REMISION = dr2("REM1") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case Else
                                            TONELADAS = dr2("P1") - dr2("T1") '1
                                            REMISION = dr2("REM1") '2
                                    End Select
                                    TALON_EMBARQUE = CVE_FOLIO  '3
                                    UNIDAD = dr2("CVE_TRACTOR").ToString.Replace("-", "")
                                    If dr2("CVE_TANQUE1").ToString.Length > 0 Then
                                        UNIDAD = UNIDAD & "-" & dr2("CVE_TANQUE1").ToString.Replace("-", "")
                                        If dr2("CVE_TANQUE2").ToString.Length > 0 Then
                                            UNIDAD = UNIDAD & "-" & dr2("CVE_TANQUE2").ToString.Replace("-", "")
                                        End If
                                    End If
                                    Try
                                        FECHA = dr2("ddmmyyyy").ToString().Replace("/", "")  '5
                                    Catch ex As Exception
                                        Bitacora("1800. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("1820. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1820. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        SQL = "SELECT ISNULL(TIPO_ELE,'') AS TIPOELE, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM,
                            ISNULL(CVE_ESQIMPU,1) AS CVEESQIMPU, ISNULL(UNI_MED,'') AS UNIMED, ISNULL(DESCR,'') AS DES, ISNULL(PRECIO,0) AS P1
                            FROM INVE" & Empresa & " I
                            LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                            WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULTCOSTO")
                                COSTO_PROM = dr("COSTOPROM")
                                CVE_ESQIMPU = dr("CVEESQIMPU")
                                DESCR = dr("DES")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNIMED")
                                TIPO_PROD = dr("TIPOELE")
                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Me.Cursor = Cursors.Default
                        Return
                    End Try
                    If Existe Then
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                IMPU1 = CSng(dr("IMPUESTO1"))
                                IMPU2 = CSng(dr("IMPUESTO2"))
                                IMPU3 = CSng(dr("IMPUESTO3"))
                                IMPU4 = CSng(dr("IMPUESTO4"))
                                IMP1APLA = CInt(dr("IMP1APLICA"))
                                IMP2APLA = CInt(dr("IMP2APLICA"))
                                IMP3APLA = CInt(dr("IMP3APLICA"))
                                IMP4APLA = CInt(dr("IMP4APLICA"))
                            End If
                            dr.Close()
                        Catch ex As Exception
                            Bitacora("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                            Me.Cursor = Cursors.Default
                            Return
                        End Try
                        If CVE_ESQIMPU = 1 Then
                            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                        Else
                            MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                        End If
                        Try
                            DESC1 = 0
                        Catch ex As Exception
                            DESC1 = 0
                        End Try
                        Try
                            PRECIO = Math.Round(CDec(PRECIO), 8)
                            PREC = PRECIO

                            Desc2 = 0 : Desc3 = 0
                            SUBTOTAL += (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT += (CANT * PREC * DESC1 / 100)
                            DES_TOT += (DES_TOT * Desc2 / 100)

                            If IMP4APLA = 1 Then
                                cIeps = ImporteConDes * IMPU1 / 100
                                cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                                cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                                cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cIeps = ImporteConDes * IMPU1 / 100
                                cImpu2 = ImporteConDes * IMPU2 / 100
                                cImpu3 = ImporteConDes * IMPU3 / 100
                                cImpu = ImporteConDes * IMPU4 / 100
                            End If

                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 += TOTIMP1
                            IMP_TOT2 += TOTIMP2
                            IMP_TOT3 += TOTIMP3
                            IMP_TOT4 += TOTIMP4
                            TOT_PARTIDA = CANT * PREC
                            CAN_TOT += TOT_PARTIDA

                            IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                            If CVE_ESQIMPU = 1 Then
                                MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                            Else
                                MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                            End If
                        Catch ex As Exception
                            Bitacora("1840. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1840. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("La clave del articulo no existe, verifique por favor")
                        NO_EXIST_ART = True
                    End If

                Catch ex As Exception
                    Bitacora("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1860. " & ex.Message & vbNewLine & ex.StackTrace)
                    Me.Cursor = Cursors.Default
                    Return
                End Try
            End If
        Next

        If NO_EXIST_ART Then
            Me.Cursor = Cursors.Default
            Return
        End If

        For w = 1 To 5
            If Valida_Conexion() Then
                Exit For
            End If
        Next

        PRIMERPAGO = IMPORTE
        METODODEPAGO = ""
        CVE_VEND = ""

        cmd.Connection = cnSAE
        cmd.CommandTimeout = 180
        Try
            SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM FACT" & TIPO_VENTA & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "') " &
                "INSERT INTO FACT" & TIPO_VENTA & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " &
                "IMP_TOT1, IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, " &
                "RFC, AUTORIZA, FOLIO, SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, " &
                "DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, " &
                "CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, " &
                "METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, UUID) VALUES('"
            SQL = SQL & CVE_CLPV & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_DOC & "','" & FECHA_VEN & "','" &
                Math.Round(IMP_TOT1, 6) & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                TIPCAMB & "','" & IMP_TOT3 & "','" & Math.Round(IMP_TOT4, 6) & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALM & "','" & ACT_CXC & "','" &
                TIP_DOC & "','" & CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" &
                NUM_PAGOS & "','" & DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" &
                CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" &
                DES_FIN_PORC & "','" & DES_TOT_PORC & "','" & Math.Round(IMPORTE, 6) & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" &
                NUMCTAPAGO & "','" & TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "',NEWID()) "
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            Bitacora("1870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1870. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '================================================================================================================
        '       PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS 
        '================================================================================================================
        NUM_PAR = 1
        returnValue = "0"
        IMPORTE = 0
        For k = 1 To Fg.Rows.Count - 1

            For w = 1 To 5
                If Valida_Conexion() Then
                    Exit For
                End If
            Next

            CANT = 1
            CVE_FOLIO = Fg(k, 2)
            Try
                If Fg(k, 1) Then
                    Try
                        NUM_ALM = 1
                    Catch ex As Exception
                        NUM_ALM = 1
                    End Try
                    'OBTENER DATOS DE LA CARTA PORTE
                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT C.FLETE, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, ddmmyyyy = convert(varchar(10), FECHA_CARGA, 103), 
                                    ISNULL(C.REM_CARGA1,'') AS REM1, ISNULL(C.PESO_BRUTO1,0) AS P1, ISNULL(C.TARA1,0) AS T1, 
                                    ISNULL(C.REM_CARGA2,'') AS REM2, ISNULL(C.PESO_BRUTO2,0) AS P2, ISNULL(C.TARA2,0) AS T2, 
                                    ISNULL(C.REM_CARGA3,'') AS REM3, ISNULL(C.PESO_BRUTO3,0) AS P3, ISNULL(C.TARA3,0) AS T3, 
                                    ISNULL(C.REM_CARGA4,'') AS REM4, ISNULL(C.PESO_BRUTO4,0) AS P4, ISNULL(C.TARA4,0) AS T4, 
                                    C.REM_CARGA, CVE_MAT, ISNULL(CANT,1) AS CANTIDAD
                                    FROM GCCARTA_PORTE C
                                    WHERE CVE_FOLIO = '" & CVE_FOLIO & "'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    'DOCUMENTO
                                    'RFCOperador = dr2("") '2
                                    'NUM_LICENCIA = dr2("") '3
                                    'NUM_REG_IDTRIBOPERADOR = dr2("") '4
                                    'RESIDENCIA_FISCAL_OPERADOR = dr2("") '5
                                    'CALLE_OPERADOR = dr2("") '6
                                    'COLONIA_OPERADOR = dr2("") '7
                                    'LOCALIDAD_OPERADOR = dr2("") '8
                                    'MUNICIPIO_OPERADOR = dr2("") '9
                                    'ESTADO_OPERADOR = dr2("") '10
                                    'LOCALIDAD_ORIGEN = dr2("") '11
                                    'CP_OPERADOR = dr2("") '12
                                    'RFC_PROPIETARIO = dr2("") '13
                                    'MUNICIPIO_ORIGEN = dr2("") '14
                                    'RESIDENCIA_FISCAL_PROPIETARIO = dr2("") '15
                                    'CALLE_PROPIETARIO = dr2("") '16
                                    'COLONIA_PROPIETARIO = dr2("") '17
                                    'LOCALIDAD_PROPIETARIO = dr2("") '18
                                    'MUNICIPIO_PROPIETARIO = dr2("") '19
                                    'ESTADO_PROPIETARIO = dr2("") '20
                                    'ESTADO_ORIGEN = dr2("") '21
                                    'CP_PROPIETARIO = dr2("") '22
                                    'RFC_ARRENDATARIO = dr2("") '23
                                    'PARTIDAS
                                    CANT = dr2("CANTIDAD")
                                    If CANT = 0 Then
                                        CANT = 1
                                    End If

                                    CVE_ART = dr2("CVE_MAT")
                                    PRECIO = dr2("FLETE")
                                    Select Case dr2.ReadNullAsEmptyInteger("REM_CARGA")
                                        Case 1
                                            TONELADAS = dr2("P1") - dr2("T1") '1
                                            REMISION = dr2("REM1") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 2
                                            TONELADAS = dr2("P2") - dr2("T2") '1
                                            REMISION = dr2("REM2") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 3
                                            TONELADAS = dr2("P3") - dr2("T3") '1
                                            REMISION = dr2("REM3") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case 4
                                            TONELADAS = dr2("P4") - dr2("T4") '1
                                            REMISION = dr2("REM4") '2
                                            PRECIO *= TONELADAS
                                            CANT = 1
                                        Case Else
                                            TONELADAS = dr2("P1") - dr2("T1") '1
                                            REMISION = dr2("REM1") '2
                                    End Select
                                    TALON_EMBARQUE = CVE_FOLIO  '3

                                    UNIDAD = dr2("CVE_TRACTOR").ToString.Replace("-", "")
                                    If dr2("CVE_TANQUE1").ToString.Length > 0 Then
                                        UNIDAD = UNIDAD & "-" & dr2("CVE_TANQUE1").ToString.Replace("-", "")
                                        If dr2("CVE_TANQUE2").ToString.Length > 0 Then
                                            UNIDAD = UNIDAD & "-" & dr2("CVE_TANQUE2").ToString.Replace("-", "")
                                        End If
                                    End If
                                    Try
                                        FECHA = dr2("ddmmyyyy").ToString().Replace("/", "")  '5
                                        FECHA = FECHA.Substring(0, 4) & FECHA.Substring(6, 2)
                                    Catch ex As Exception
                                        Bitacora("1920. " & ex.Message & vbNewLine & ex.StackTrace)
                                        FECHA = dr2("ddmmyyyy").ToString().Replace("/", "")  '5
                                    End Try
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("1940. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1940. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        SQL = "SELECT ISNULL(TIPO_ELE,'P') AS TIPOELE, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, " &
                        "ISNULL(CVE_ESQIMPU,1) AS CVEESQIMPU, ISNULL(UNI_MED,'') AS UNIMED, ISNULL(DESCR,'') AS DES, ISNULL(PRECIO,0) AS P1 " &
                        "FROM INVE" & Empresa & " I " &
                        "LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1 " &
                        "WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULTCOSTO")
                                COSTO_PROM = dr("COSTOPROM")
                                CVE_ESQIMPU = dr("CVEESQIMPU")
                                DESCR = dr("DES")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNIMED")
                                TIPO_PROD = dr("TIPOELE")
                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("1890. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1890. " & ex.Message & vbNewLine & ex.StackTrace)
                        Me.Cursor = Cursors.Default
                        Return
                    End Try
                    If Existe Then
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                IMPU1 = CSng(dr("IMPUESTO1"))
                                IMPU2 = CSng(dr("IMPUESTO2"))
                                IMPU3 = CSng(dr("IMPUESTO3"))
                                IMPU4 = CSng(dr("IMPUESTO4"))
                                IMP1APLA = CInt(dr("IMP1APLICA"))
                                IMP2APLA = CInt(dr("IMP2APLICA"))
                                IMP3APLA = CInt(dr("IMP3APLICA"))
                                IMP4APLA = CInt(dr("IMP4APLICA"))
                            End If
                            dr.Close()
                        Catch ex As Exception
                            Bitacora("1900. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1900. " & ex.Message & vbNewLine & ex.StackTrace)
                            Me.Cursor = Cursors.Default
                            Return
                        End Try
                        If CVE_ESQIMPU = 1 Then
                            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                        Else
                            MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                        End If

                        Try
                            DESC1 = 0
                        Catch ex As Exception
                            DESC1 = 0
                        End Try

                        Try
                            PRECIO = Math.Round(CDec(PRECIO), 8)
                            PREC = PRECIO

                            Desc2 = 0 : Desc3 = 0
                            SUBTOTAL += (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT += (CANT * PREC * DESC1 / 100)
                            DES_TOT += (DES_TOT * Desc2 / 100)

                            If IMP4APLA = 1 Then
                                cIeps = ImporteConDes * IMPU1 / 100
                                cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                                cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                                cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cIeps = ImporteConDes * IMPU1 / 100
                                cImpu2 = ImporteConDes * IMPU2 / 100
                                cImpu3 = ImporteConDes * IMPU3 / 100
                                cImpu = ImporteConDes * IMPU4 / 100
                            End If

                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 += TOTIMP1
                            IMP_TOT2 += TOTIMP2
                            IMP_TOT3 += TOTIMP3
                            IMP_TOT4 += TOTIMP4
                            TOT_PARTIDA = CANT * PREC
                            IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                            If CVE_ESQIMPU = 1 Then
                                MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                            Else
                                MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                            End If
                        Catch ex As Exception
                            Bitacora("1960. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1960. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("1. La clave del articulo no existe")
                    End If
                    PXS = CANT
                    UNI_VENTA = UNI_MED
                    COST = COSTO_PROM

                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA & Empresa & " WHERE " &
                        "CVE_DOC = '" & CVE_DOC & "' AND CVE_ART = '" & CVE_ART & "' AND NUM_PAR = " & NUM_PAR & ") " &
                        "INSERT INTO PAR_FACT" & TIPO_VENTA & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " &
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " &
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, " &
                        "REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, " &
                        "CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, CVE_ESQ, DESCR_ART, UUID) " &
                        "VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & CVE_ART & "','" &
                        CANT & "','" & PXS & "','" & Math.Round(PREC, 8) & "','" & Math.Round(COST, 6) & "','" & IMPU1 & "','" & IMPU2 & "','" &
                        IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" &
                        IMP4APLA & "','" & Math.Round(TOTIMP1, 6) & "','" & TOTIMP2 & "','" & TOTIMP3 & "','" & Math.Round(TOTIMP4, 6) & "','" &
                        DESC1 & "','" & Desc2 & "','" & Desc3 & "','" & COMI & "','" & APAR & "','" & ACT_INV & "','" &
                        NUM_ALM & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','" & TIPO_PROD & "','" &
                        CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "',(" &
                        "SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & Math.Round(TOT_PARTIDA, 6) &
                        "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" &
                        APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & CVE_ESQIMPU & "',' ',NEWID())"

                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                            GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Grabar REMISION partida Articulo " & CVE_ART &
                                       " Partida: " & NUM_PAR & " Cant & " & CANT)

                            Try '------------------                DATOS TOMADOS DE LA CARTA PORTE
                                SQL = "INSERT INTO PAR_FACTR_CLIB" & Empresa & " (CLAVE_DOC, NUM_PART, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB4, CAMPLIB5) 
                                    VALUES ('" & CVE_DOC & " ','" & NUM_PAR & "','" & TONELADAS & "','" & REMISION & "','" & CVE_FOLIO & "','" &
                                    UNIDAD & "','" & FECHA & "')"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("2480. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 3, CVE_DOCR = '" & CVE_DOC & "' WHERE CVE_FOLIO = '" & CVE_FOLIO & "'"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using

                            Catch ex As Exception
                                Bitacora("2500. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                    NUM_PAR += 1
                End If

            Catch ex As Exception
                Bitacora("2600. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2600. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
        Try
            If LETRA_VENTA = "" Or LETRA_VENTA = "STAND." Then
                SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA & "' AND SERIE = 'STAND.'"
            Else
                SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA & "' AND SERIE = '" & LETRA_VENTA & "'"
            End If
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            MsgBox("2660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Se creo la remision " & CVE_DOC)

        Me.Cursor = Cursors.Default

        IMPRIMIR_VENTA(CVE_DOC)

        DESPLEGAR()

    End Sub

    Private Sub BarReactivar_Click(sender As Object, e As EventArgs) Handles BarReactivar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea reactivar la carta porte " & Fg(Fg.Row, 2) & "?", vbYesNo) = vbYes Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        'STATUS CARTA PORTE 4 = REGRESO
                        SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 4, CONCILIADO = 0 WHERE CVE_FOLIO = '" & Fg(Fg.Row, 2) & "'"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "DELETE FROM GCCONCI_CARTA_PORTE_PAR WHERE CVE_FOLIO = '" & Fg(Fg.Row, 2) & "'"
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("2680. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                MsgBox("La carta porte se reactivó satisfactoriamente")
                                Fg.RemoveItem(Fg.Row)
                                DESPLEGAR()
                            Else
                                MsgBox("NO se logro reactivar la carta porte")
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("2690. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2690. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_VENTA(FCVE_DOC As String)
        Dim Rreporte_MRT As String
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
            Rreporte_MRT = "ReportRemisionCAP" & Empresa & ".mrt"
            Rreporte_MRT = RUTA_FORMATOS & "\ReportRemisionCAP.mrt"

            If Not File.Exists(Rreporte_MRT) Then
                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                Return
            End If

            StiReport1.Load(Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = FCVE_DOC
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("2700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As EventArgs) Handles BarActualizar.Click
        CADENA = ""
        DESPLEGAR()
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "CARTA PORTE")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarRT_Click(sender As Object, e As EventArgs) Handles BarRT.Click
        'MsgBox("Este todavia no hace nada")
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If Fg(Fg.Row, 4).ToString.Length > 1 Then
                MsgBox("La carta porte ya fue remisionada verifique por favor")
                Fg(Fg.Row, 1) = False
                e.Cancel = True
            Else
                If LtCliente.Text.Trim.Length > 0 Then
                    If Fg(Fg.Row, 1) Then
                        If Not IsNothing(Fg(Fg.Row, 5)) Then
                            If Fg(Fg.Row, 5) <> LtCliente.Text Then
                                MsgBox("Las cartas portes deben ser del mismo cliente, vcerifique por favor")
                                Fg(Fg.Row, 1) = False
                            End If
                        End If
                    Else
                        If Not HAY_MAS_CHECK Then
                            LtCliente.Text = ""
                        End If
                    End If
                Else
                    If Fg(Fg.Row, 1) Then
                        If Not IsNothing(Fg(Fg.Row, 5)) Then
                            LtCliente.Text = Fg(Fg.Row, 5)
                        End If
                    Else
                        If Not HAY_MAS_CHECK() Then
                            LtCliente.Text = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("2720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function HAY_MAS_CHECK() As Boolean
        Dim SiHay As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    SiHay = True
                End If
            Next
            Return SiHay
        Catch ex As Exception
            Bitacora("2720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2720. " & ex.Message & vbNewLine & ex.StackTrace)
            Return SiHay
        End Try
    End Function
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 1 Then

                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("2800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCFDI_Click(sender As Object, e As EventArgs) Handles BarCFDI.Click
        CREA_TAB(FrmCFDICartaPorteConcen, "Concentrado CFDI carta porte")
    End Sub
    Private Sub TBox_TextChanged(sender As Object, e As EventArgs) Handles TBox.TextChanged
        Try
            N_TOP = ""
            CADENA = " AND (UPPER(CVE_FOLIO) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(CVE_VIAJE) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(P.CVE_DOCR) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(P.CLIENTE) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(C.NOMBRE) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(O.NOMBRE) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(P.CVE_TRACTOR) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(P.CVE_TANQUE1) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(P.CVE_TANQUE2) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(RE.DESCR) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(EE.DESCR) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(ST.DESCR) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(REM_CARGA1) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(REM_CARGA2) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           UPPER(CVE_VAL_DECLA) LIKE '%" & TBox.Text.ToUpper & "%' OR UPPER(V.DESCR) LIKE '%" & TBox.Text.ToUpper & "%' OR
                           VALOR_DECLARADO LIKE '%" & TBox.Text.ToUpper & "%')"
            DESPLEGAR()

        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarTimbrarCPConPrecios_Click(sender As Object, e As EventArgs) Handles BarTimbrarCPConPrecios.Click
        Try
            If Fg.Row > 0 Then

                If Fg(Fg.Row, 18) = "CANCELADO" Then
                    MsgBox("La carta porte esta cancelada")
                    Return
                End If

                If Fg(Fg.Row, 18) <> "ACEPTADO" And Fg(Fg.Row, 18) <> "TRANSFERIDO" Then
                    MsgBox("La carta porte debe estar como estatus ACEPTADA o TRANFEREIDO, verifique por favor")
                    Return
                End If

                If PASS_GRUPOCE <> "BUS" Then
                    If Fg(Fg.Row, 8) = "Timbrado" Then
                        'MsgBox("La carta porte ya fue timbrada, verifique por favor")
                        If MsgBox("La carta porte ya fue timbrada desea volver a timbrarla?", vbYesNo) = vbNo Then
                            Return
                        End If
                        If MsgBox("Al volver a timbrar la carta porte deberá seleccionar el documento relacionado, Desea continuar?", vbYesNo) = vbNo Then
                            Return
                        End If

                        Dim msg As Object
                        msg = New VtlMessageBox(5)
                        Dim Result As String
                        With msg
                            '.AddImageToMoreText("gridImage", img)
                            .MessageText = "Este proceso se grabará en la bitácora"
                            '.MoreText = "-----"
                            .AddStandardButtons(MessageBoxButtons.OK)
                            .Caption = "Información"
                            .Icon = MessageBoxIcon.Information

                            .MessageBoxPosition = FormStartPosition.CenterScreen
                            Result = .Show()
                        End With
                    End If
                End If

                Var18 = "SIN PRECIOS"
                '      TRACTOR                                  TANQUE1                                        TANQUE2 
                If Fg(Fg.Row, 13).ToString.Trim.Length > 0 And Fg(Fg.Row, 14).ToString.Trim.Length > 0 And Fg(Fg.Row, 15).ToString.Trim.Length > 0 Then
                    Var19 = Fg(Fg.Row, 6) 'PEDIDO
                Else
                    Var19 = ""
                End If
                PassDoc_Timbrado = Fg(Fg.Row, 8)    'Fg(Fg.Row, 8) = "Timbrado"
                Var14 = Fg(Fg.Row, 2)               'CVE_FOLIO ES LA CARTA PORTE

                CREA_TAB(Principal, "Generar CFDI 4.0")
            Else
                MsgBox("Por favor seleccione una carta porte")
            End If
        Catch ex As Exception
            Bitacora("2800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Clipboard.Clear()
                Clipboard.SetText(Fg(Fg.Row, Fg.Col))
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BHoy_Click(sender As Object, e As EventArgs) Handles BHoy.Click
        N_TOP = ""
        CADENA = " AND FECHA_DOC = '" & FSQL(Date.Now) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BAyer_Click(sender As Object, e As EventArgs) Handles BAyer.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddDays(-1)
        N_TOP = ""
        CADENA = " AND FECHA_DOC = '" & FSQL(dt) & "'"
        DESPLEGAR()
    End Sub
    Private Sub BEsteMes_Click(sender As Object, e As EventArgs) Handles BEsteMes.Click
        Dim dt As DateTime = Date.Today
        N_TOP = ""
        CADENA = " AND MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
        DESPLEGAR()
    End Sub
    Private Sub BMesAnterior_Click(sender As Object, e As EventArgs) Handles BMesAnterior.Click
        Dim dt As DateTime = Date.Today
        dt = dt.AddMonths(-1)
        N_TOP = ""
        CADENA = " AND MONTH(FECHA_DOC) = " & dt.Month & " AND YEAR(FECHA_DOC) = " & dt.Year
        DESPLEGAR()
    End Sub
    Private Sub BTodos_Click(sender As Object, e As EventArgs) Handles BTodos.Click
        N_TOP = ""
        CADENA = ""
        DESPLEGAR()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
                Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
                e.Text = rowNumber.ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TBox.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
