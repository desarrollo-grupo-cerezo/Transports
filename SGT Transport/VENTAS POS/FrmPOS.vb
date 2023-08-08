Imports System.IO
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Public Class FrmPOS
    Private Mcolor1 As Color
    Private Mcolor2 As Color
    Private LISTA_PRECIO_CTE As Integer = 1
    Private DESCUENTO_CTE As Decimal = 0
    'Private OCULTAR_CRE_ENG As Integer
    'Private OCULTAR_CREDITO As Integer
    'Private NOVALIDAR_LIM_CRED As Integer
    'Private HABILITAR_DESC As Integer
    Private PER_VEND_ABA_MIN As Integer
    Private PER_VEND_ABA_COST As Integer
    'Private ACTIVAR_POLITICAS As Integer
    'Private ACTIVAR_GAD As Integer
    'Private ART_CON_IMP_INCLU As Integer
    'Private VENDER_SIN_EXIST As Integer
    'Private BLOQEAR_LISTA_PREC As Integer
    'Private UTILIZAR_LECTOR_HUELLA As Integer
    'Private ALTA_CTE_POS As Integer
    'Private ALTA_PROD_POS As Integer
    Private CLIE_MOSTR As String
    Private TIPO_VENTA_LOCAL As String
    Private SERIE_POS As String
    Private NUM_ALM As Integer
    Private REPORTE_POS As String

    Private LISTAPRECPRED As Integer
    ReadOnly AllowedKeys As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,/\|()*@#$%-_.[]{}<>ñÑ"

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TIPO_VENTA_LOCAL = "V"

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CARGAR_DATOS1()
        Try
            Fg.Rows.Count = 1
            Fg.Cols(0).Width = 10
            Fg.Cols(1).Visible = False
            Fg.Cols(3).Visible = False
            Fg.Cols(5).Visible = False
            Fg.Cols(7).Visible = False
            Fg.Cols(8).Visible = False
            Fg.Cols(9).Visible = False
            Fg.Cols(10).Visible = False
            Fg.Cols(11).Visible = False
            Fg.Cols(12).Visible = False
            Fg.Cols(14).Visible = False
            Fg.Cols(15).Visible = False
            Fg.Cols(17).Visible = False
            Fg.Cols(19).Visible = False
            Fg.Cols(20).Visible = False
            Fg.Cols(21).Visible = False
            Fg.Cols(22).Visible = False
            Fg.Cols(23).Visible = False
            Fg.Cols(24).Visible = False
            Fg.Cols(25).Visible = False
            Fg.Cols(26).Visible = False

            Fg.Styles.Fixed.WordWrap = True
            Fg.Rows(0).Height = 50
            'Establecer el tamaño de estrella para las columnas
            Fg.Cols(2).StarWidth = "*"
            Fg.Cols(4).StarWidth = "*"
            Fg.Cols(6).StarWidth = "3*"
            Fg.Cols(13).StarWidth = "*"
            Fg.Cols(16).StarWidth = "2*"
            Fg.Cols(18).StarWidth = "2*"
            ' Establecer la propiedad MinWidth para evitar que la columna se vuelva demasiado estrecha
            Fg.Cols(2).MinWidth = 100

            SplitM1.Dock = DockStyle.Fill
            SplitM3.Dock = DockStyle.Fill
            SplitM2.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill
            Pic.Dock = DockStyle.Fill

            SplitM1.SplitterWidth = 0
            SplitM2.SplitterWidth = 0
            SplitM3.SplitterWidth = 0

            SplitM1.HeaderLineWidth = 0
            SplitM2.HeaderLineWidth = 0
            SplitM3.HeaderLineWidth = 0


            TARTICULO.Dock = DockStyle.Fill
            LtMonto.Dock = DockStyle.Fill

            LtMonto.Value = "0.00"
            LtNombre.Text = ""
            LtNombre.Tag = "" 'CORREO
            BtnCliente.Tag = "" 'VENDEDOR
            LISTA_PRECIO_CTE = 1
            DESCUENTO_CTE = 0

            Me.KeyPreview = True
            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

            TCLIENTE.Enabled = False
            BtnCliente.Enabled = False
            'TARTICULO.BackColor = Color.LightSeaGreen
            'TXTN.PostValidation.Validation = C1.Win.C1Input.PostValidationTypeEnum.ValuesAndIntervals
            TXTN.PostValidation.Validation = PostValidationTypeEnum.PostValidatingEvent
            'TXTN.PostValidation.Intervals.AddRange(New C1.Win.C1Input.ValueInterval() {New C1.Win.C1Input.ValueInterval(
            '                                       New Decimal(New Integer() {1, 0, 0, 0}),
            '                                       New Decimal(New Integer() {100, 0, 0, 0}), True, True)})
            Mcolor1 = Color.White
            Mcolor2 = Color.RoyalBlue

            Mycolor1 = Color.White
            Mycolor2 = Color.Gold

            If PASS_GRUPOCE = "BUS" Then
                'For k = 1 To Fg.Cols.Count - 1
                'Fg(0, k) = k & "." & Fg(0, k)
                'Next
            End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        LISTAPRECPRED = 1

        Try
            SQL = "SELECT ISNULL(ALMACEN, 0) AS C_ALM, OCULTAR_CRE_ENG, OCULTAR_CREDITO, NOVALIDAR_LIM_CRED, HABILITAR_DESC, 
                PER_VEND_ABA_MIN, PER_VEND_ABA_COST, ACTIVAR_POLITICAS, ACTIVAR_GAD, ART_CON_IMP_INCLU, VENDER_SIN_EXIST, 
                BLOQEAR_LISTA_PREC, UTILIZAR_LECTOR_HUELLA, ALTA_CTE_POS, ALTA_PROD_POS, CLIE_MOSTR, ISNULL(LISTAPRECPRED,1) AS LISPRECPRED
                FROM GCPARAMVENTAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL

                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        'NUEVAS OPCIONES POS DIC 20022
                        'OCULTAR_CRE_ENG = dr.ReadNullAsEmptyInteger("OCULTAR_CRE_ENG")
                        'OCULTAR_CREDITO = dr.ReadNullAsEmptyInteger("OCULTAR_CREDITO")
                        'NOVALIDAR_LIM_CRED = dr.ReadNullAsEmptyInteger("NOVALIDAR_LIM_CRED")
                        'HABILITAR_DESC = dr.ReadNullAsEmptyInteger("HABILITAR_DESC")
                        PER_VEND_ABA_MIN = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_MIN")
                        PER_VEND_ABA_COST = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_COST")
                        'ACTIVAR_POLITICAS = dr.ReadNullAsEmptyInteger("ACTIVAR_POLITICAS")
                        'ACTIVAR_GAD = dr.ReadNullAsEmptyInteger("ACTIVAR_GAD")
                        'ART_CON_IMP_INCLU = dr.ReadNullAsEmptyInteger("ART_CON_IMP_INCLU")
                        'VENDER_SIN_EXIST = dr.ReadNullAsEmptyInteger("VENDER_SIN_EXIST")
                        'BLOQEAR_LISTA_PREC = dr.ReadNullAsEmptyInteger("BLOQEAR_LISTA_PREC")
                        'UTILIZAR_LECTOR_HUELLA = dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA")
                        'ALTA_CTE_POS = dr.ReadNullAsEmptyInteger("ALTA_CTE_POS")
                        'ALTA_PROD_POS = dr.ReadNullAsEmptyInteger("ALTA_PROD_POS")
                        CLIE_MOSTR = dr.ReadNullAsEmptyString("CLIE_MOSTR")

                        LISTAPRECPRED = dr.ReadNullAsEmptyInteger("LISPRECPRED")
                        If LISTAPRECPRED < 1 Then LISTAPRECPRED = 1
                    Else
                        'OCULTAR_CRE_ENG = 0
                        'OCULTAR_CREDITO = 0
                        'NOVALIDAR_LIM_CRED = 0
                        'HABILITAR_DESC = 0
                        PER_VEND_ABA_MIN = 0
                        PER_VEND_ABA_COST = 0
                        'ACTIVAR_POLITICAS = 0
                        'ACTIVAR_GAD = 0
                        'ART_CON_IMP_INCLU = 0
                        'VENDER_SIN_EXIST = 0
                        'BLOQEAR_LISTA_PREC = 0
                        'UTILIZAR_LECTOR_HUELLA = 0
                        'ALTA_CTE_POS = 0
                        'ALTA_PROD_POS = 0
                        CLIE_MOSTR = "MOSTR"

                        LISTAPRECPRED = 1
                    End If
                End Using
            End Using

            If CLIE_MOSTR.Trim.Length > 0 Then
                TCLIENTE.Text = CLIE_MOSTR
                LtNombre.Text = BUSCA_CAT("Cliente", TCLIENTE.Text)
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            NUM_ALM = 1
            SERIE_POS = "STAND."

            SQL = "SELECT ISNULL(TIPO_DOC,'') AS TIP_DOC, ISNULL(SERIE,'') AS SER FROM GCUSUARIOS_PARAM WHERE USUARIO = '" & USER_GRUPOCE & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr("TIP_DOC")
                            Case "V"
                                SERIE_POS = dr("SER")
                            Case "a"
                                If IsNumeric(dr("SER")) Then
                                    NUM_ALM = Convert.ToInt16(dr("SER"))
                                Else
                                    NUM_ALM = 1
                                End If
                        End Select
                    End While
                End Using
            End Using
            If NUM_ALM < 1 Or NUM_ALM > 999 Then
                NUM_ALM = 1
            End If

            REPORTE_POS = ""
            SQL = "SELECT FTPEMISION FROM PARAM_FOLIOSF" & Empresa & " WHERE TIPODOCTO = 'V' AND SERIE = '" & SERIE_POS & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        REPORTE_POS = Path.GetFileName(dr("FTPEMISION"))
                    End If
                End Using
            End Using

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub FrmPOS_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyValue
                Case 27
                    TARTICULO.Focus()

                Case Keys.F1
                Case Keys.F3
                Case Keys.F3
                    BtnCobrar_Click(Nothing, Nothing)
                Case Keys.F4
                Case Keys.F5
                Case Keys.F6
                Case Keys.F7
                    Try
                        If TCLIENTE.Text.Trim.Length > 0 Then
                            Var1 = "Edit"
                            Var2 = TCLIENTE.Text
                            Var4 = ""
                            Using options = New FrmDatosCliente
                                If DialogResult.OK = options.ShowDialog() Then
                                    TCLIENTE.Text = Var10

                                End If
                            End Using
                        End If
                    Catch ex As Exception
                    End Try
                Case Keys.F8
                    Try
                        Var1 = "Nuevo"
                        Var2 = "" : Var4 = ""
                        Using options = New FrmDatosCliente
                            If DialogResult.OK = options.ShowDialog() Then
                                TCLIENTE.Text = Var10

                            End If
                        End Using
                    Catch ex As Exception
                    End Try
                Case Keys.F9
                Case Keys.F10
                Case Keys.F11
                Case Keys.F12

            End Select
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCobrar_Click(sender As Object, e As EventArgs) Handles BtnCobrar.Click
        Dim EFECTIVO As Decimal = 0, TARJ_CREDITO As Decimal, TARJ_DEBITO As Decimal, TRANS As Decimal, VALES As Decimal, DOLARES As Decimal
        Dim FacturarVenta As Boolean, ContadoCredito As Boolean, MONTO As Decimal, CAMBIO As Decimal, OBS As String = "", SEGRABA_VENTA As Boolean = False

        Try
            If IsNumeric(LtMonto.Text.Replace(",", "")) Then
                MONTO = Convert.ToDecimal(LtMonto.Text.Replace(",", ""))
            Else
                MONTO = 0
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If MONTO = 0 Then
            Dim result = RJMessageBox.Show("El importe de la venta no puede ser cero", "Advertencia", MessageBoxButtons.OK)
            Return
        End If

        Try
            FORM_LOAD_KEY = True

            Using options = New FrmPosCobro22(MONTO, TCLIENTE.Text)

                If DialogResult.OK = options.ShowDialog() Then

                    Try
                        If Not IsNothing(options) Then
                            EFECTIVO = options.MyEfectivo
                            TARJ_CREDITO = options.MyTarjcredito
                            TARJ_DEBITO = options.MyTarjdebito
                            TRANS = options.MyTrans
                            VALES = options.MyVales
                            DOLARES = options.MyDolares

                            FacturarVenta = options.MyFacturarVenta
                            ContadoCredito = options.MyTipoVenta
                            CAMBIO = options.MyCambio

                            If Not IsNothing(options.MyObs) Then
                                OBS = options.MyObs
                            Else
                                OBS = ""
                            End If

                            SEGRABA_VENTA = True
                        End If
                    Catch ex As Exception
                        MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End Using

            If SEGRABA_VENTA Then
                GRABAR(EFECTIVO, TARJ_CREDITO, TARJ_DEBITO, TRANS, VALES, DOLARES, FacturarVenta, ContadoCredito, CAMBIO, OBS)
            End If

        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GRABAR(FEFECTIVO As Decimal, FTARJ_CREDITO As Decimal, FTARJ_DEBITO As Decimal, FTRANS As Decimal, FVALES As Decimal,
               FDOLARES As Decimal, FFACTURARVENTA As Boolean, FCONTADOCREDITO As Boolean, FCAMBIO As Decimal, FOBS As String)

        Dim COSTO_PROM_GRAL As Decimal
        Dim NUM_MOV As Long, NUM_MOV_KIT As Long, CANT As Decimal
        Dim FOLIO As Integer, CLIENTE As String, CVE_ART As String, EXIST As Decimal, CVE_DOC_ENLAZADO As String
        Dim NUM_PAR_KIT As Integer, CANT_KIT As Decimal, PRECIO_KIT As Decimal, CVE_PROD As String
        Dim PRECIO As Decimal, PREC As Decimal, DESC1 As Decimal, DESC2 As Decimal, DESC3 As Decimal, ALMACEN As Integer, MULTIALMACEN As Integer
        Dim TIP_DOC As String, TIP_DOC_E As String = "", E_LTPD As Integer, DES_FIN As Decimal
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim cImpu1 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu4 As Decimal
        Dim SUBTOTAL As Decimal, ImporteConDes As Decimal, DES_TOT As Decimal, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, IMPORTE As Decimal, COM_TOT As Decimal
        Dim CVE_DOC As String, STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim CAN_TOT As Decimal, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal
        Dim CONDICION As String, CVE_OBS As Long, NUM_ALMA As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String
        Dim NUM_MONED As Long, TIPCAMB As Decimal, NUM_PAGOS As Long, PRIMERPAGO As Decimal, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String, CVE_BITA As Long
        Dim Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, COM_TOT_PORC As Decimal
        'variables partidas
        Dim NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Integer, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer
        Dim CVE_ESQ As Integer, COST As Decimal, COMI As Decimal, APAR As Decimal, ACT_INV As String, POLIT_APLI As String, TIP_CAM As Decimal
        Dim TIPO_PROD As String, TIPO_PROD2 As String = "", REG_SERIE As Long, TIPO_ELEM As String, TOT_PARTIDA As Decimal
        Dim APL_MAN_IEPS As String, MTO_PORC As Integer, MTO_CUOTA As Integer
        'MOVSINV
        Dim CVE_CPTO As Integer, FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, FORMADEPAGOSAT As String, UNI_MED As String
        Dim COSTO_PROM As Decimal, UUID As String, SIGUE As Boolean, FOLIO_ASIGNADO As Boolean
        Dim cIEPS As Decimal, cIMPU As Decimal, UNI_VENTA As String
        Dim METODODEPAGO As String, USO_CFDI As String, FOLIO_POS As Long, DETEC_ERROR_VIOLATION_KEY As String


        Dim result = RJMessageBox.Show("Realmente desea grabar la nota de venta?", "Question Icon", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return
        End If

        Try
            Dim hoy As DateTime = Date.Now.ToString("dd/MM/yyyy")
            CVE_DOC = hoy
        Catch ex As Exception
            BITACORATPV("390. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("390. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If MULTIALMACEN = 0 Then
                NUM_ALMA = 1
            Else
                NUM_ALMA = NUM_ALM
            End If
        Catch ex As Exception
            BITACORATPV("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CVE_DOC = "" : CVE_CPTO = 51

        UNI_MED = "" : TIP_CAM = 1 : FACTOR_CON = 1 : REG_SERIE = 0 : E_LTPD = 0 : MOV_ENLAZADO = 0
        DAT_MOSTR = 0 : NUM_MOV = 0

        CLIENTE = TCLIENTE.Text
        CVE_VEND = ""

        Try
            SIGUE = True
            FOLIO_ASIGNADO = False

            FOLIO_POS = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, SERIE_POS)

            Do While SIGUE
                If SERIE_POS.Trim.Length = 0 Or SERIE_POS = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_POS, "0000000000")
                Else
                    If TIPO_VENTA_LOCAL = "F" Then
                        CVE_DOC = SERIE_POS & Format(FOLIO_POS, "0000000000")
                    Else
                        CVE_DOC = SERIE_POS & FOLIO_POS
                    End If
                End If

                If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                    FOLIO_POS += 1
                    FOLIO_ASIGNADO = True
                Else
                    SIGUE = False
                End If
            Loop
        Catch ex As Exception
            BITACORATPV("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        '███████████████████████████████████████████████████████████████████████████████████████

        '                                 INICIA LA GRABACION DE LAS CABEZAS

        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

        Try
            TIP_DOC = TIPO_VENTA_LOCAL

            IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0
            CONDICION = "" : CVE_OBS = 0 : NUM_ALMA = 1 : ACT_CXC = "S" : ACT_COI = "A" : ENLAZADO = "O"
            TIPCAMB = 1 : NUM_PAGOS = 1
            RFC = "" : CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
            FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
            DAT_ENVIO = 0 : COM_TOT_PORC = 0 : IMPORTE = 0
            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC_ANT = "" : DOC_ANT = ""
            STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N" : SIGNO = -1 : TIP_CAM = 1 : E_LTPD = 0 : UUID = "" : SUBTOTAL = 0
            NUM_MONED = 1

            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            DESC2 = 0
            DESC3 = 0
            FOLIO = FOLIO_VENTA
            SERIE = LETRA_VENTA
            ALMACEN = NUM_ALM

            For k = 1 To Fg.Rows.Count - 1

                For w = 1 To 5
                    If Valida_Conexion() Then
                        Exit For
                    End If
                Next

                Try
                    CANT = Fg(k, 2)
                    CVE_ART = Fg(k, 4)
                Catch ex As Exception
                    CANT = 0 : ALMACEN = 1 : CVE_ART = ""
                End Try

                If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                    EXIST = 0
                    Try
                        If TIPO_VENTA_LOCAL = "V" Then
                            If FCONTADOCREDITO Then
                                CONTADO = "N"
                                METODODEPAGO = "PPD"
                            Else
                                CONTADO = "S"
                                METODODEPAGO = "PPD"
                            End If
                        Else
                            CONTADO = "N"
                        End If
                        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    Catch ex As Exception
                        BITACORATPV("620. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS UCOSTO, ISNULL(I.COSTO_PROM,0) AS CPROM, ISNULL(P.IMPUESTO1,0) AS IMPU1,
                            ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3, ISNULL(P.IMPUESTO4,0) AS IMPU4, ISNULL(P.IMP1APLICA,0) AS IMP1APLA,
                            ISNULL(P.IMP2APLICA,0) AS IMP2APLA, ISNULL(P.IMP3APLICA,0) AS IMP3APLA, ISNULL(P.IMP4APLICA,0) AS IMP4APLA,
                            ISNULL(TIPO_ELE,'') AS TIP_ELE
                            FROM INVE" & Empresa & " I
                            LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                            WHERE CVE_ART = '" & CVE_ART & "'"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    COST = dr("UCOSTO").ToString
                                    COST = Math.Round(COST, 2)
                                    COSTO_PROM = dr("CPROM").ToString
                                    IMPU1 = dr("IMPU1")
                                    IMPU2 = dr("IMPU2")
                                    IMPU3 = dr("IMPU3")
                                    IMPU4 = dr("IMPU4")
                                    IMP1APLA = dr("IMP1APLA")
                                    IMP2APLA = dr("IMP2APLA")
                                    IMP3APLA = dr("IMP3APLA")
                                    IMP4APLA = dr("IMP4APLA")
                                    CVE_ESQ = dr("CVE_ESQIMPU")
                                    UNI_MED = dr("UNI_MED")
                                    TIPO_PROD = dr("TIP_ELE") '= "K"
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("640. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    DESC1 = Fg(k, 10)
                    PRECIO = Fg(k, 9)
                    PREC = PRECIO
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    SUBTOTAL += (CANT * PREC)
                    ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                    'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      
                    DES_TOT += (CANT * PREC * DESC1 / 100)
                    DES_TOT += (DES_TOT * DESC2 / 100)

                    cImpu1 = ImporteConDes * IMPU1 / 100
                    cImpu2 = (ImporteConDes + cImpu1) * IMPU2 / 100
                    cImpu3 = (ImporteConDes + cImpu1 + cImpu2) * IMPU3 / 100
                    cImpu4 = (ImporteConDes + cImpu1 + cImpu2 + cImpu3) * IMPU4 / 100
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    TOTIMP1 = cImpu1
                    TOTIMP2 = cImpu2
                    TOTIMP3 = cImpu3
                    TOTIMP4 = cImpu4
                    IMP_TOT1 += TOTIMP1
                    IMP_TOT2 += TOTIMP2
                    IMP_TOT3 += TOTIMP3
                    IMP_TOT4 += TOTIMP4
                    IMPORTE += ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                End If
            Next
            CAN_TOT = SUBTOTAL
            DES_TOT_PORC = DESC1
            COM_TOT = 0

            PRIMERPAGO = 0
            DES_TOT = DES_TOT
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            CVE_PEDI = ""
            CONDICION = ""
            PRIMERPAGO = IMPORTE
            RFC = ""

            Try
                CVE_OBS = 0
                If FOBS.Trim.Length > 0 Then
                    CVE_OBS = INSERT_UPDATE_OBS_FAC(CVE_OBS, FOBS)
                End If
            Catch ex As Exception
                BITACORATPV("680. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                Dim RegDuplicado As Boolean = False

                METODODEPAGO = ""
                USO_CFDI = ""
                FORMADEPAGOSAT = ""

                DETEC_ERROR_VIOLATION_KEY = False

                For k = 1 To 5

                    SQL = "INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                        IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                        SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                        CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                        IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                        VERSION_SINC) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),
                        CONVERT(varchar, GETDATE(), 112),'" &
                        Math.Round(IMP_TOT1, 6) & "','" & Math.Round(IMP_TOT2, 6) & "','" & Math.Round(DES_FIN, 6) & "','" &
                        Math.Round(COM_TOT, 6) & "','" & ACT_COI & "','" & NUM_MONED & "','" & TIPCAMB & "','" & Math.Round(IMP_TOT3, 6) & "','" &
                        Math.Round(IMP_TOT4, 6) & "','" & Math.Round(PRIMERPAGO, 6) & "','" & RFC & "','" & AUTORIZA & "','" &
                        FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                        CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" & CVE_VEND & "','" & Math.Round(DES_TOT, 6) & "','" & ENLAZADO & "','" &
                        NUM_PAGOS & "','" & DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" &
                        CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" &
                        Math.Round(DES_TOT_PORC, 6) & "','" & Math.Round(IMPORTE, 6) & "','" & Math.Round(COM_TOT_PORC, 6) & "','" &
                        METODODEPAGO & "','" & NUMCTAPAGO & "','" & TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" &
                        FORMADEPAGOSAT & "',NEWID(), GETDATE())"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                        Exit For
                    Catch SQLex As SqlException
                        ' Log the original exception here
                        For Each sqlError As SqlError In SQLex.Errors
                            Debug.Print(sqlError.Number & ", " & sqlError.ToString)
                            Select Case sqlError.Number
                                Case 207 ' 207 = InvalidColumn
                                    'do your Stuff here
                                    Exit Select
                                Case 547 ' 547 = (Foreign) Key violation
                                    'do your Stuff here
                                    DETEC_ERROR_VIOLATION_KEY = True
                                    Exit Select
                                Case 2601, 2627 ' 2601 = (Primary) key violation
                                    'do your Stuff here
                                    DETEC_ERROR_VIOLATION_KEY = True
                                    Exit Select
                                Case 3621
                                    'The statement has been terminated.
                                Case Else                        'do your Stuff here
                                    Exit Select
                            End Select
                        Next
                        BITACORATPV("690. " & SQLex.Message & vbNewLine & SQLex.StackTrace)
                    Catch ex As Exception
                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If DETEC_ERROR_VIOLATION_KEY Then
                        Try
                            SIGUE = True
                            FOLIO_ASIGNADO = False

                            FOLIO_POS = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, SERIE_POS)

                            Do While SIGUE
                                If SERIE_POS.Trim.Length = 0 Or SERIE_POS = "STAND." Then
                                    CVE_DOC = Space(10) & Format(FOLIO_POS, "0000000000")
                                Else
                                    CVE_DOC = SERIE_POS & Format(FOLIO_POS, "0000000000")
                                End If

                                If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                                    FOLIO_POS = +1
                                    FOLIO_ASIGNADO = True
                                Else
                                    SIGUE = False
                                End If
                            Loop
                        Catch ex As Exception
                            BITACORATPV("693. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("693. " & ex.Message & vbNewLine & ex.StackTrace)
                            Return
                        End Try
                    Else
                        If Not Valida_Conexion() Then
                        End If
                    End If
                Next

                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                'CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   
                If Not Valida_Conexion() Then
                End If

                If TIPO_VENTA_LOCAL = "V" Then


                    'CUEN M
                    CUEN_M(CVE_DOC, CLIENTE, IMPORTE, CVE_VEND, CVE_BITA)

                    If Not FCONTADOCREDITO Then
                        'RUTIANA CONTADO  
                        'CUEN DET 
                        'RUTIANA CONTADO  
                        Try
                            If FEFECTIVO > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FEFECTIVO, 10, CVE_VEND)
                            End If
                            If FTARJ_CREDITO > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FTARJ_CREDITO, 23, CVE_VEND)
                            End If
                            If FTARJ_DEBITO > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FTARJ_DEBITO, 24, CVE_VEND)
                            End If
                            If FTRANS > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FTRANS, 22, CVE_VEND)
                            End If
                            If FVALES > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FVALES, 10, CVE_VEND)
                            End If
                            If FDOLARES > 0 Then
                                CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, FDOLARES, 10, CVE_VEND)
                            End If
                        Catch ex As Exception
                            BITACORATPV("695. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("695. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & Math.Round(IMPORTE, 6) & ", 
                                FCH_ULTCOM = CONVERT(varchar, GETDATE(), 112)
                                WHERE CLAVE = '" & CLIENTE & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("700. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & Math.Round(IMPORTE, 6) & ",
                                ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & Math.Round(IMPORTE, 6) &
                                ", FCH_ULTCOM = CONVERT(varchar, GETDATE(), 112) WHERE CLAVE = '" & CLIENTE & "'"

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("705. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("705. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    If TIPO_VENTA_LOCAL = "R" And DOC_NEW Then
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", 
                                FCH_ULTCOM = CONVERT(varchar, GETDATE(), 112)
                               WHERE CLAVE = '" & CLIENTE & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("710. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("710. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                Try
                    If LETRA_VENTA = "" Or LETRA_VENTA = "STAND." Then
                        SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = 'STAND.'"
                    Else
                        SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & LETRA_VENTA & "'"
                    End If
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
                    BITACORATPV("715. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Catch ex As Exception
                BITACORATPV("720. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("730. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        '████████████████████████████████████████████████████████████████████████████████████



        'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
        NUM_PAR = 1 : CVE_ART = "" : CVE_VEND = "" : COSTEADO = "S" : DESDE_INVE = "N"
        SUBTOTAL = 0 : DES_TOT = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : MAN_IEPS = "" : APL_MAN_IEPS = ""

        CVE_DOC_ENLAZADO = ""
        ALMACEN = NUM_ALM

        If ALMACEN = 0 Then ALMACEN = 1


        For k = 1 To Fg.Rows.Count - 1

            For w = 1 To 5
                If Valida_Conexion() Then
                    Exit For
                End If
            Next

            Try
                CANT = Fg(k, 2)
                CVE_ART = Fg(k, 4)

            Catch ex As Exception
                BITACORATPV("740. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
            If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                Try
                    SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS ULTCOSTO, ISNULL(I.COSTO_PROM,0) AS COSTOPROM, " &
                        "COALESCE(P.IMPUESTO1,0) AS IMPU1, COALESCE(P.IMPUESTO2,0) AS IMPU2, COALESCE(P.IMPUESTO3,0) AS IMPU3, " &
                        "COALESCE(P.IMPUESTO4,0) AS IMPU4, COALESCE(P.IMP1APLICA,0) AS IMP1APLA, COALESCE(P.IMP2APLICA,0) AS IMP2APLA, " &
                        "COALESCE(P.IMP3APLICA,0) AS IMP3APLA, COALESCE(P.IMP4APLICA,0) AS IMP4APLA, ISNULL(TIPO_ELE,'') AS TIP_ELE " &
                        "FROM INVE" & Empresa & " I " &
                        "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                        "WHERE CVE_ART = '" & CVE_ART & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                COST = dr("ULTCOSTO")
                                COST = Math.Round(COST, 2)
                                COSTO_PROM = dr("COSTOPROM").ToString
                                IMPU1 = dr("IMPU1")
                                IMPU2 = dr("IMPU2")
                                IMPU3 = dr("IMPU3")
                                IMPU4 = dr("IMPU4")
                                IMP1APLA = dr("IMP1APLA")
                                IMP2APLA = dr("IMP2APLA")
                                IMP3APLA = dr("IMP3APLA")
                                IMP4APLA = dr("IMP4APLA")
                                CVE_ESQ = dr("CVE_ESQIMPU")
                                UNI_MED = dr("UNI_MED")
                                TIPO_PROD2 = dr("TIP_ELE")
                                Select Case dr("TIP_ELE")
                                    Case "K"
                                        TIPO_PROD = "K"
                                        TIPO_ELEM = "N"
                                    Case "S"
                                        TIPO_PROD = "S"
                                        TIPO_ELEM = "S"
                                    Case Else
                                        TIPO_PROD = "P"
                                        TIPO_ELEM = "N"
                                End Select
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    DESC1 = Fg(k, 10)
                    PRECIO = Fg(k, 9)
                    PREC = PRECIO

                    DESC2 = 0 : DESC3 = 0
                    SUBTOTAL += (CANT * PREC)
                    ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)

                    'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      

                    DES_TOT += (CANT * PREC * DESC1 / 100)
                    DES_TOT += (DES_TOT * DESC2 / 100)
                    cImpu1 = ImporteConDes * IMPU1 / 100
                    cImpu2 = (ImporteConDes + cImpu1) * IMPU2 / 100
                    cImpu3 = (ImporteConDes + cImpu1 + cImpu2) * IMPU3 / 100
                    cImpu4 = (ImporteConDes + cImpu1 + cImpu2 + cImpu3) * IMPU4 / 100
                    TOTIMP1 = cImpu1
                    TOTIMP2 = cImpu2
                    TOTIMP3 = cImpu3
                    TOTIMP4 = cImpu4

                    TOT_PARTIDA = CANT * PREC
                    IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                    If CVE_ESQ = 1 Then
                        MAN_IEPS = "N"
                        APL_MAN_IMP = 1
                        CUOTA_IEPS = 0
                        APL_MAN_IEPS = "C"
                        MTO_PORC = 0
                        MTO_CUOTA = 0
                    Else
                        MAN_IEPS = ""
                        APL_MAN_IMP = 0
                        CUOTA_IEPS = 0
                        APL_MAN_IEPS = ""
                        MTO_PORC = 0
                        MTO_CUOTA = 0
                    End If
                Catch ex As Exception
                    BITACORATPV("760. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                '==========================================================================================================
                'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                '==========================================================================================================
                'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER     
                CVE_OBS = 0
                Try
                    If Not IsNothing(Fg(k, 26)) Then
                        If Fg(k, 26).ToString.Trim.Length > 0 Then

                            CVE_OBS = INSERT_UPDATE_OBS_FAC(0, Fg(k, 26))

                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("765. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try


                '█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                '                                                 MOVIMIENTOS AL INVENTARIO
                '█████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                If TIPO_PROD2 <> "K" Then
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & ", FCH_ULTVTA = CONVERT(varchar, GETDATE(), 112)
                                 WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("820. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If MULTIALMACEN = 1 Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("830. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("830. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    SIGNO = -1
                    COSTO_PROM_INI = COST
                    COSTO_PROM_FIN = COST
                    COSTO_PROM_GRAL = COST

                    'PARTIDAS REALES   NO NO KIT
                    SQL = "IF NOT EXISTS(SELECT REFER FROM MINVE" & Empresa & " WHERE
                        REFER = '" & CVE_DOC & "' AND CVE_ART = '" & CVE_ART & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & ALMACEN & ")
                        INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                        VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                        FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL)
                        VALUES('" & CVE_ART & "','" & ALMACEN & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                        CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" & TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" &
                        CVE_VEND & "','" & Math.Round(CANT, 6) & "','" & Math.Round(CANT, 6) & "','" & Math.Round(PREC, 6) & "','" &
                        Math.Round(COST, 6) & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                        "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                    If MULTIALMACEN = 1 Then
                        SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                    Else
                        SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                    End If
                    SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                SIGNO & "','" & COSTEADO & "','" & Math.Round(COSTO_PROM_INI, 6) & "','" & Math.Round(COSTO_PROM_FIN, 6) & "','" &
                                DESDE_INVE & "','" & MOV_ENLAZADO & "','" & Math.Round(COSTO_PROM_GRAL, 6) & "')"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("840. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If

                Try
                    SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE
                        CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                        INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, 
                        IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, 
                        APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, 
                        TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, DESCR_ART, 
                        CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & CVE_ART & "','" & Math.Round(CANT, 6) & "','" &
                        Math.Round(CANT, 6) & "','" & Math.Round(PREC, 6) & "','" & Math.Round(COST, 6) & "','" & IMPU1 & "','" & IMPU2 & "','" &
                        IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" &
                        Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" & Math.Round(TOTIMP3, 6) & "','" &
                        Math.Round(TOTIMP4, 6) & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" &
                        ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" &
                        CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','" & NUM_MOV & "','" &
                        Math.Round(TOT_PARTIDA, 6) & "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" &
                        APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & CVE_DOC_ENLAZADO & "','" & CVE_ESQ & "',NEWID())"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("840. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    If TIPO_PROD = "K" And DOC_NEW Then
                        NUM_PAR += 1
                        NUM_PAR_KIT = NUM_PAR
                        TIPO_PROD = "P"
                        TIPO_ELEM = "K"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT ISNULL(CVE_PROD,'') AS CVEPROD, ISNULL(PORCEN,0) AS PORCEN1, ISNULL(CANTIDAD,0) AS CANT, 
                                ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(IMPUESTO1,0) AS IMPU1, ISNULL(IMPUESTO4,0) AS IMPU4, ISNULL(IMP1APLICA,0) AS IMP1APLA,
                                UNI_MED, ISNULL(IMP2APLICA,0) AS IMP2APLA, ISNULL(IMP3APLICA,0) AS IMP3APLA, ISNULL(IMP4APLICA,0) AS IMP4APLA
                                FROM KITS" & Empresa & " K
                                INNER JOIN INVE" & Empresa & " I  ON I.CVE_ART = K.CVE_PROD
                                INNER JOIN IMPU" & Empresa & " P  ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                                WHERE K.CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    CANT_KIT = dr("CANT") * CANT
                                    PRECIO_KIT = PREC * dr("PORCEN1") / dr("CANT")
                                    IMPU1 = dr("IMPU1")
                                    IMPU2 = 0
                                    IMPU3 = 0
                                    IMPU4 = dr("IMPU4")
                                    IMP1APLA = dr("IMP1APLA")
                                    IMP2APLA = dr("IMP2APLA")
                                    IMP3APLA = dr("IMP3APLA")
                                    IMP4APLA = dr("IMP4APLA")
                                    CVE_PROD = dr("CVEPROD")

                                    ImporteConDes = (CANT_KIT * PRECIO_KIT) - (CANT_KIT * PRECIO_KIT * DESC1 / 100)

                                    cIEPS = ImporteConDes * IMPU1 / 100
                                    If dr("IMP4APLA") = 1 Then
                                        cIMPU = (ImporteConDes + cIEPS) * IMPU4 / 100
                                    Else
                                        cIMPU = (ImporteConDes * IMPU4) / 100
                                    End If
                                    UNI_VENTA = "" & dr("UNI_MED")

                                    TOTIMP1 = cIEPS
                                    TOTIMP2 = 0
                                    TOTIMP3 = 0
                                    TOTIMP4 = cIMPU
                                    '**************************************************************
                                    'INICIA GRABADO DE PARTIDAS         KITS         KITS      
                                    '**************************************************************
                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa &
                                         " WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR_KIT & ") 
                                         INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1,
                                         IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1,
                                         DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE,
                                         E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS,
                                         MTO_PORC, MTO_CUOTA, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR_KIT & "','" & CVE_PROD & "','" &
                                         CANT_KIT & "','" & CANT_KIT & "','" & PRECIO_KIT & "','" & Math.Round(dr("ULTCOSTO"), 6) & "','" & IMPU1 & "','" &
                                         IMPU2 & "','" & IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" &
                                         IMP4APLA & "','" & Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" & Math.Round(TOTIMP3, 6) & "','" &
                                         Math.Round(TOTIMP4, 6) & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" &
                                         APAR & "','" & ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','P','" &
                                         CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','0','" & Math.Round(ImporteConDes, 6) &
                                         "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" &
                                         MTO_PORC & "','" & MTO_CUOTA & "',NEWID())"
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                        NUM_MOV_KIT = returnValue
                                    End Using
                                    NUM_PAR_KIT += 1

                                    If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                                        'AFECTANDO INVENTARIO MINVE Y INVE

                                        '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT_KIT &
                                                    ", FCH_ULTVTA = CONVERT(varchar, GETDATE(), 112) WHERE CVE_ART = '" & CVE_PROD & "'"
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("790. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("790. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try

                                        Try
                                            If MULTIALMACEN = 1 Then
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT_KIT &
                                                       " WHERE CVE_ART = '" & CVE_PROD & "' AND CVE_ALM = " & ALMACEN
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        Catch ex As Exception
                                            BITACORATPV("800. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        'MINVE KITES
                                        SIGNO = -1
                                        COSTO_PROM_INI = COST
                                        COSTO_PROM_FIN = COST
                                        COSTO_PROM_GRAL = COST

                                        SQL = "IF NOT EXISTS(SELECT REFER FROM MINVE" & Empresa & " WHERE REFER = '" & CVE_DOC & "' AND CVE_ART = '" &
                                            CVE_PROD & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & ALMACEN & ")
                                            INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL)
                                            VALUES ('" & CVE_PROD & "','" & ALMACEN & "','" & NUM_MOV_KIT & "','" & CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" &
                                            TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" & CANT_KIT & "','" &
                                            CANT_KIT & "','" & PRECIO_KIT & "','" & COST & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                            "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "')," 'EXIST_G
                                        If MULTIALMACEN = 1 Then
                                            SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "' AND 
                                                CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                                        Else
                                            SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "'),'"  'EXISTENCIA
                                        End If
                                        SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " 
                                            WHERE ID_TABLA = 32),'" &
                                             SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" &
                                             MOV_ENLAZADO & "','" & COSTO_PROM_GRAL & "')"
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("810. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        'FIN MINVE KITS
                                    End If
                                End While
                            End Using
                        End Using
                        NUM_PAR = NUM_PAR_KIT
                    End If



                Catch ex As Exception
                    BITACORATPV("880. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("880. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      
                NUM_PAR += 1
            End If 'CANT >0
        Next

        If Not Valida_Conexion() Then
        End If

        Try
            SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT COALESCE(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0)
                 FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            BITACORATPV("890. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("890. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT COALESCE(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            BITACORATPV("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  FIN  FIN  FIN  FIN  FIN  

        GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, "V", " venta ", "")

        IMPRIMIR_VENTA(CVE_DOC)

        LIMPIAR()

    End Sub
    Sub CUEN_M(FCVE_DOC As String, FCLAVE As String, FIMPORTE As Decimal, FCVE_VEND As String, FCVE_BITA As Long)

        Dim CVE_CLIE As String, REFER As String, NUM_CPTO As Integer, CVE_OBS As Long, NO_FACTURA As String, DOCTO As String, IMPORTE As Decimal
        Dim AFEC_COI As String, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, ENTREGADA As String
        Dim cmd As New SqlCommand
        Dim cmdT As New SqlCommand

        Try
            CVE_CLIE = FCLAVE
            REFER = FCVE_DOC
            NO_FACTURA = REFER
            DOCTO = REFER
            IMPORTE = FIMPORTE
            IMPMON_EXT = FIMPORTE

            SIGNO = 1
            NUM_CPTO = 2
            CVE_OBS = 0 : AFEC_COI = "S" : STRCVEVEND = FCVE_VEND : NUM_MONED = 1 : TCAMBIO = 1
            CVE_FOLIO = "" : TIPO_MOV = "C" : ENTREGADA = "S"

            SQL = "IF NOT EXISTS(SELECT REFER FROM CUEN_M" & Empresa & " WHERE
                REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND NUM_CPTO = " & NUM_CPTO & " AND NUM_CARGO = 1)
                INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO,
                IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV,
                CVE_BITA, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" &
                REFER & "','" & NUM_CPTO & "','1','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(FIMPORTE, 6) &
                "',CONVERT(varchar, GETDATE(), 112)," & "CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" &
                NUM_MONED & "','" & TCAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & FCVE_BITA & "','" &
                SIGNO & "','" & CLAVE_SAE & "','" & ENTREGADA & "',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"

            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If
        Catch ex As Exception
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_DET(FCVE_DOC As String, FDOCTO As String, FCLAVE As String, FIMPORTE As Decimal, FNUM_CPTO_PAGO As Integer, FCVE_VEND As String)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim DOCTO As String, IMPORTE As Decimal, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, NO_PARTIDA As Integer, AFEC_COI As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim cmdT As New SqlCommand

        CVE_CLIE = FCLAVE
        REFER = FCVE_DOC
        NO_FACTURA = REFER

        If FNUM_CPTO_PAGO = 0 Then
            NUM_CPTO = 10
        Else
            NUM_CPTO = FNUM_CPTO_PAGO
        End If

        If TIPO_VENTA_LOCAL = "F" Then
            ID_MOV = 1
        Else
            ID_MOV = 2
        End If

        CVE_OBS = 0 : DOCTO = FDOCTO : NUM_MONED = 1 : TCAMBIO = 1 : AFEC_COI = "S"
        IMPORTE = FIMPORTE
        STRCVEVEND = FCVE_VEND
        IMPMON_EXT = IMPORTE

        CVE_FOLIO = "" : TIPO_MOV = "A" : NO_PARTIDA = 1 : NUM_CARGO = 1
        SIGNO = -1

        cmd.Connection = cnSAE
        SQL = "SELECT COALESCE(MAX(NO_PARTIDA),0) + 1 AS NO_PAR FROM CUEN_DET" & Empresa & " 
            WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "'"
        Try
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                NO_PARTIDA = dr("NO_PAR")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("2030. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2030. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "IF NOT EXISTS (SELECT REFER FROM CUEN_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND " &
            "ID_MOV = " & ID_MOV & " AND NUM_CPTO = " & NUM_CPTO & " AND NO_PARTIDA = " & NO_PARTIDA & ") " &
            "INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, " &
            "FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, SIGNO, " &
            "CVE_AUT, USUARIO, NO_PARTIDA, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & ID_MOV & "','" & NUM_CPTO & "','" &
            NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(FIMPORTE, 6) &
            "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" &
            TCAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'0','" & CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','0','" & CLAVE_SAE & "','" &
            NO_PARTIDA & "',NEWID(), GETDATE())"
        Try
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub IMPRIMIR_VENTA(FCVE_DOC As String)

        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0
            If MsgBox("Realmente desea imprimir el reporte?", vbYesNo, "") = vbNo Then
                Return
            End If

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportSolPagoProv.mrt"
            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS)

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
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub LIMPIAR()
        Try
            Fg.Rows.Count = 1
            TCLIENTE.Text = CLIE_MOSTR
            LtMonto.Value = ""
            Pic.Image = PicFoto.Image
            LtPrecioXProducto.Text = ""
            LtArticulo.Text = ""

        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPOS_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp

    End Sub
    Private Sub FrmPOS_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'AJUSTA_ANCHO_FG()
        SplitM1P2.Collapsed = False
    End Sub
    Private Sub FrmPOS_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'AJUSTA_ANCHO_FG()
    End Sub
    Sub AJUSTA_ANCHO_FG()
        Try
            Dim ANCHO As Integer

            ANCHO = SplitM3P2.Width

            Debug.Print(Fg.Cols.Count - 1)

            If Fg.Cols.Count - 1 > 10 Then
                Fg.Cols(2).Width = ANCHO * 0.09 'CANT
                Fg.Cols(6).Width = ANCHO * 0.42 'DESCR
                Fg.Cols(13).Width = ANCHO * 0.1 'DESC
                Fg.Cols(16).Width = ANCHO * 0.15 'PRECIO NETO
                Fg.Cols(18).Width = ANCHO * 0.2 'IMPORTE
            End If
        Catch ex As Exception
            BITACORATPV("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPOS_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TARTICULO_KeyDown(sender As Object, e As KeyEventArgs) Handles TARTICULO.KeyDown
        If e.KeyCode = 13 Then
            If TARTICULO.Text.Trim.Length > 0 Then

                If TARTICULO.Text = "11111" Then
                    TARTICULO.Text = ""
                    SplitM1P2.Collapsed = True
                    TCLIENTE.Enabled = True
                    BtnCliente.Enabled = True
                    TCLIENTE.Focus()
                    Return
                End If

                GRID_ARTICULO(TARTICULO.Text.Trim)
                TARTICULO.Text = ""
            Else
                'e.Handled = False
                e.SuppressKeyPress = True
            End If
        End If
        If e.KeyCode = Keys.Down Then
            Fg.Col = 2

            Fg.Select()
            Fg.Focus()
        End If
    End Sub
    Private Sub TARTICULO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TARTICULO.PreviewKeyDown
        If e.KeyCode = 9 Then
            If TARTICULO.Text.Trim.Length > 0 Then
                GRID_ARTICULO(TARTICULO.Text.Trim)
                TARTICULO.Text = ""
            Else
                e.IsInputKey = True
            End If
        End If
    End Sub
    Private Sub TARTICULO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TARTICULO.KeyPress
        Try
            Select Case e.KeyChar

                Case Convert.ToChar(Keys.Enter) ' Enter is pressed
                    ' Call method here...

                Case Convert.ToChar(Keys.Back) ' Backspace is pressed
                    e.Handled = False ' Delete the character

                Case Convert.ToChar(Keys.Capital Or Keys.RButton) ' CTRL+V is pressed
                    ' Paste clipboard content only if contains allowed keys
                    e.Handled = Not Clipboard.GetText().All(Function(c) AllowedKeys.Contains(c))

                Case Else ' Other key is pressed
                    e.Handled = Not AllowedKeys.Contains(e.KeyChar)
            End Select
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GRID_ARTICULO(FCVE_ART As String)
        Dim CVE_ALM As Int16 = 1, EXISTECI As Decimal = 0, CVE_ART As String = "", DESCR As String = "", P1 As Decimal, P2 As Decimal, EXIS As Boolean = False
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, CIMPU1 As Decimal, CIMPU2 As Decimal, CIMPU3 As Decimal, CIMPU4 As Decimal
        Dim IMPORTE As Decimal, PRECIO_NETO As Decimal, CANT As Decimal = 1, DESC1 As Decimal, DESC2 As Decimal, MONTO_DESC1 As Decimal, MONTO_DESC2 As Decimal
        Dim IMPORTESINDES As Decimal, IMPORTEIEPS As Decimal, IMPORTEIMPU2 As Decimal, IMPORTEIMPU3 As Decimal, IMPORTEIVA As Decimal, IMAGEN As String = ""
        Dim EXIST_ART As Boolean = False

        If LISTA_PRECIO_CTE = 0 Then LISTA_PRECIO_CTE = 1

        Try
            FCVE_ART = FCVE_ART.Replace("'", "")
            FCVE_ART = FCVE_ART.Trim

            If FCVE_ART.Trim.Length = 0 Then
                Return
            End If

            If MULTIALMACEN = 0 Then
                SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PRECIO_CTE & "),0) AS P1,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1,
                    ISNULL(EXIST,0) AS EXIS, ISNULL(CVE_IMAGEN,'') AS CVE_IMAG, ISNULL(P.IMP1APLICA,0) AS APLA1, 
                    ISNULL(P.IMP2APLICA,0) AS APLA2, ISNULL(P.IMP3APLICA,0) AS APLA3, ISNULL(P.IMP4APLICA,0) AS APLA4,
                    ISNULL(RANGO11,0) AS R11, ISNULL(RANGO12,0) AS R12, ISNULL(RANGO21,0) AS R21, ISNULL(RANGO22,0) AS R22,
                    ISNULL(RANGO31,0) AS R31, ISNULL(RANGO32,0) AS R32, ISNULL(RANGO41,0) AS R41, ISNULL(RANGO42,0) AS R42,
                    ISNULL(RANGO51,0) AS R51, ISNULL(RANGO52,0) AS R52, ISNULL(PORC1,0) AS P1, ISNULL(PORC2,0) AS P2,
                    ISNULL(PORC3,0) AS P3, ISNULL(PORC4,0) AS P4, ISNULL(PORC5,0) AS P5, ISNULL(LP1,0) AS L1,
                    ISNULL(LP2,0) AS L2, ISNULL(LP3,0) AS L3, ISNULL(LP4,0) AS L4, ISNULL(LP5,0) AS L5, ISNULL(PM.TIPO, -1) AS TIPO_PROM
                    FROM INVE" & Empresa & " I
                    LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                    LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                    LEFT JOIN GCPROMOCIONES PM ON PM.CVE_ART = I.CVE_ART
                    WHERE (I.CVE_ART = '" & FCVE_ART & "' OR ISNULL(A.CVE_ALTER,'') = '" & FCVE_ART & "')"
            Else
                SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PRECIO_CTE & "),0) AS P1,
                    ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1,
                    ISNULL(M.EXIST,0) AS EXIS, ISNULL(CVE_IMAGEN,'') AS CVE_IMAG, ISNULL(P.IMP1APLICA,0) AS APLA1, 
                    ISNULL(P.IMP2APLICA,0) AS APLA2, ISNULL(P.IMP3APLICA,0) AS APLA3, ISNULL(P.IMP4APLICA,0) AS APLA4,
                    ISNULL(RANGO11,0) AS R11, ISNULL(RANGO12,0) AS R12, ISNULL(RANGO21,0) AS R21, ISNULL(RANGO22,0) AS R22,
                    ISNULL(RANGO31,0) AS R31, ISNULL(RANGO32,0) AS R32, ISNULL(RANGO41,0) AS R41, ISNULL(RANGO42,0) AS R42,
                    ISNULL(RANGO51,0) AS R51, ISNULL(RANGO52,0) AS R52, ISNULL(PORC1,0) AS P1, ISNULL(PORC2,0) AS P2,
                    ISNULL(PORC3,0) AS P3, ISNULL(PORC4,0) AS P4, ISNULL(PORC5,0) AS P5, ISNULL(LP1,0) AS L1,
                    ISNULL(LP2,0) AS L2, ISNULL(LP3,0) AS L3, ISNULL(LP4,0) AS L4, ISNULL(LP5,0) AS L5, ISNULL(PM.TIPO, -1) AS TIPO_PROM
                    FROM MULT" & Empresa & " M
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART
                    LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                    LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                    LEFT JOIN GCPROMOCIONES PM ON PM.CVE_ART = I.CVE_ART
                    WHERE M.CVE_ALM = " & CVE_ALM & " AND 
                    (M.CVE_ART = '" & FCVE_ART & "' OR ISNULL(A.CVE_ALTER,'') = '" & FCVE_ART & "')"
            End If
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            EXIST_ART = True

                            EXISTECI = dr("EXIS")
                            CVE_ART = dr("CVE_ART")
                            DESCR = dr("DESCR")
                            DESC1 = DESCUENTO_CTE
                            DESC2 = 0
                            P1 = dr("P1")
                            P2 = dr("P2")

                            If P1 = 0 Then
                                P1 = dr("PL1")
                            End If

                            IMPU1 = dr("IMPUESTO1")
                            IMPU2 = dr("IMPUESTO2")
                            IMPU3 = dr("IMPUESTO3")
                            IMPU4 = dr("IMPUESTO4")

                            PRECIO_NETO = P1 - (P1 * DESC1 / 100)
                            PRECIO_NETO -= (PRECIO_NETO * DESC2 / 100)

                            MONTO_DESC1 = (CANT * PRECIO_NETO * DESC1 / 100)
                            MONTO_DESC2 = (CANT * PRECIO_NETO * DESC2 / 100)

                            CIMPU1 = PRECIO_NETO * IMPU1 / 100
                            If dr("APLA2") = 2 Or dr("APLA2") = 1 Then
                                CIMPU2 = (PRECIO_NETO + CIMPU1) * IMPU2 / 100
                            Else
                                CIMPU2 = PRECIO_NETO * IMPU2 / 100
                            End If

                            If dr("APLA3") = 2 Or dr("APLA3") = 1 Then
                                CIMPU3 = (PRECIO_NETO + CIMPU1 + CIMPU2) * IMPU3 / 100
                            Else
                                CIMPU3 = PRECIO_NETO * IMPU3 / 100
                            End If

                            If dr("APLA4") = 1 Or dr("APLA4") = 2 Then
                                CIMPU4 = (PRECIO_NETO + CIMPU1 + CIMPU2 + CIMPU3) * IMPU4 / 100
                            Else
                                CIMPU4 = PRECIO_NETO * IMPU4 / 100
                            End If

                            IMPORTEIEPS += (PRECIO_NETO * CANT * IMPU1 / 100)
                            IMPORTEIMPU2 += (PRECIO_NETO * CANT * IMPU2 / 100)
                            IMPORTEIMPU3 += (PRECIO_NETO * CANT * IMPU3 / 100)
                            IMPORTEIVA += (PRECIO_NETO * CANT * IMPU4 / 100)

                            IMPORTESINDES += (CANT * (P1 + CIMPU1 + CIMPU2 + CIMPU3 + CIMPU4))

                            IMPORTE += (CANT * (PRECIO_NETO + CIMPU1 + CIMPU2 + CIMPU3 + CIMPU4))

                            If dr("CVE_IMAG").ToString.Trim.Length > 0 Then

                                If File.Exists(Application.StartupPath & "\IMAGENES\" & dr("CVE_IMAG")) Then

                                    IMAGEN = Application.StartupPath & "\IMAGENES\" & dr("CVE_IMAG")

                                    Pic.Image = Image.FromFile(Application.StartupPath & "\IMAGENES\" & dr("CVE_IMAG"))
                                Else
                                    Pic.Image = PicFoto.Image
                                End If
                            Else
                                Pic.Image = PicFoto.Image
                            End If
                        End If
                    End Using
                End Using

                If EXIST_ART Then
                    If EXISTECI <= 0 Then

                        Var10 = "Advertencia"
                        Var11 = "Existencia insuficiente"

                        Dim result = RJMessageBox.Show("Existencia insuficiente", "Advertencia", MessageBoxButtons.OK)

                        Pic.Image = PicFoto.Image

                    Else
                        For k = 1 To Fg.Rows.Count - 1
                            If Fg(k, 4) = CVE_ART Then
                                Fg(k, 2) += 1
                                EXIS = True
                                Exit For
                            End If
                        Next
                        If Not EXIS Then
                            Dim s As String

                            s = "" & vbTab '1
                            s &= "1" & vbTab '2 ----- VISIBLE
                            s &= "" & vbTab '3
                            s &= CVE_ART & vbTab '4
                            s &= "" & vbTab '5
                            s &= DESCR & vbTab '6 ----- VISIBLE
                            s &= "" & vbTab '7 unidad
                            s &= P2 & vbTab '8   PRECIO MINIMO
                            s &= P1 & vbTab '9
                            s &= DESC1 & vbTab  '10
                            s &= DESC2 & vbTab  '11
                            s &= 0 & vbTab  '12
                            s &= Math.Round(MONTO_DESC1, 2) & vbTab  '13 ----- VISIBLE
                            s &= Math.Round(MONTO_DESC2, 2) & vbTab  '14
                            s &= 0 & vbTab  '15
                            s &= PRECIO_NETO & vbTab '16 ----- VISIBLE
                            s &= IMPORTESINDES & vbTab '17
                            s &= IMPORTE & vbTab '18 ----- VISIBLE
                            s &= LISTA_PRECIO_CTE & vbTab '19
                            s &= IMAGEN '20

                            Fg.AddItem("" & vbTab & s)
                        End If

                        CALCULAR_IMPORTES(Fg.Rows.Count - 1)

                        Fg.Row = Fg.Rows.Count - 1

                        Fg_Click(Nothing, Nothing)
                    End If
                Else
                    Dim result = RJMessageBox.Show("Artículo inexistente", "Advertencia", MessageBoxButtons.OK)
                End If

            Catch ex As Exception
                BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If TCLIENTE.Enabled Then
            TCLIENTE.Enabled = False
            BtnCliente.Enabled = False
        End If

        TARTICULO.Focus()

    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then

                LtPrecioXProducto.Text = "Precio $ " & Format(Fg(Fg.Row, 16), "###,###,##0.00")

                LtArticulo.Text = Fg(Fg.Row, 4)

                If Not IsNothing(Fg(Fg.Row, 20)) Then
                    If Fg(Fg.Row, 20).ToString.Trim.Length > 0 Then

                        If File.Exists(Fg(Fg.Row, 20)) Then
                            Pic.Image = Image.FromFile(Fg(Fg.Row, 20))
                        Else
                            Pic.Image = PicFoto.Image
                        End If
                    Else
                        Pic.Image = PicFoto.Image
                    End If
                Else
                    Pic.Image = PicFoto.Image
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Sub CALCULAR_IMPORTES(Optional FROW As Integer = 0)
        Dim IMPORTE As Decimal, DESCUENTO1 As Decimal, DESCUENTO2 As Decimal, DESC1 As Decimal, DESC2 As Decimal, CVE_ESQIMPU As Integer
        Dim DES_TOT As Decimal, PRECIO_CON_DESC As Decimal, PRECIO_NETO As Decimal, PRECIO_SIN_DESC As Decimal, PRECIO_MINIMO As Decimal, PRECIO_COSTO As Decimal

        Dim cIeps As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu As Decimal
        Dim cI1 As Decimal, cI2 As Decimal, cI3 As Decimal, cI4 As Decimal
        Dim cIP1 As Decimal, cIP2 As Decimal, cIP3 As Decimal, cIP4 As Decimal
        Dim cIM1 As Decimal, cIM2 As Decimal, cIM3 As Decimal, cIM4 As Decimal
        Dim cIC1 As Decimal, cIC2 As Decimal, cIC3 As Decimal, cIC4 As Decimal

        Dim IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer
        Dim TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal
        Dim CANT As Decimal, CVE_ART As String, UNI_MED As String, ULT_COSTO As Decimal, P1 As Decimal, P2 As Decimal
        Dim P_LISTA1 As Decimal, PRECIO_POS As Decimal, PRECIO_PUBLICO As Decimal, Continua As Boolean
        Dim LISTA_PREC_PROMO As Decimal, DESC_PROMO As Decimal, DESC_VTA As Decimal, LISTA_PREC_VTA As Integer
        Try
            Fg.FinishEditing()

            DES_TOT = 0 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            If LISTA_PRECIO_CTE = 0 Then LISTA_PRECIO_CTE = 1

            For i As Integer = 1 To Fg.Rows.Count - 1

                If FROW = 98989898 Then
                    Continua = False
                Else
                    If FROW = 0 Then
                        Continua = True
                    Else
                        If i = FROW Then
                            Continua = True
                        Else
                            Continua = False
                        End If
                    End If
                End If

                If Continua Then
                    Try
                        CVE_ART = Fg(i, 4).ToString.Trim
                        CVE_ART = CVE_ART.Replace("'", "")

                        CANT = 0
                        If Not IsNothing(Fg(i, 2)) Then
                            If IsNumeric(Fg(i, 2)) Then
                                CANT = Fg(i, 2)
                            End If
                        End If
                    Catch ex As Exception
                        CVE_ART = ""
                    End Try

                    SUB_PROMOCIONES(CVE_ART, CANT, LISTA_PREC_PROMO, DESC_PROMO)

                    DESC_VTA = DESCUENTO_CTE
                    LISTA_PREC_VTA = LISTA_PRECIO_CTE

                    If LISTA_PREC_PROMO > 0 Or DESC_PROMO > 0 Then
                        If LISTA_PREC_PROMO > 0 Then
                            If LISTA_PREC_PROMO > 0 Then
                                LISTA_PREC_VTA = LISTA_PREC_PROMO
                            End If
                        Else
                            If DESC_PROMO > 0 Then
                                DESC_VTA = DESC_PROMO
                            End If
                        End If
                    End If

                    Try
                        If CVE_ART.Length > 0 And CANT > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT I.CVE_ART, ULT_COSTO, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1,
                                ISNULL(P.IMP1APLICA,0) AS APLA1, ISNULL(P.IMP2APLICA,0) AS APLA2, ISNULL(P.IMP3APLICA,0) AS APLA3, ISNULL(P.IMP4APLICA,0) AS APLA4
                                FROM INVE" & Empresa & " I
                                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                                WHERE (I.CVE_ART = '" & CVE_ART & "' OR ISNULL(A.CVE_ALTER,'') = '" & CVE_ART & "')"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then

                                        P_LISTA1 = dr("PL1")
                                        P1 = dr("P1")
                                        P2 = dr("P2")

                                        If P1 = 0 Then
                                            P1 = P_LISTA1
                                        End If

                                        CVE_ESQIMPU = dr("CVE_ESQIMPU")
                                        UNI_MED = dr("IMPUESTO1")
                                        ULT_COSTO = dr("ULT_COSTO")

                                        IMPU1 = dr("IMPUESTO1")
                                        IMPU2 = dr("IMPUESTO2")
                                        IMPU3 = dr("IMPUESTO3")
                                        IMPU4 = dr("IMPUESTO4")
                                        IMP1APLA = dr("APLA1")
                                        IMP2APLA = dr("APLA2")
                                        IMP3APLA = dr("APLA3")
                                        IMP4APLA = dr("APLA4")
                                    Else
                                        Debug.Print("")
                                    End If
                                End Using
                            End Using

                            DESC1 = DESC_VTA
                            DESC2 = Fg(i, 11)

                            Fg(i, 9) = P1
                            Fg(i, 10) = DESC1
                            Fg(i, 19) = LISTA_PREC_VTA


                            PRECIO_CON_DESC = P1 - (P1 * DESC1 / 100)
                            DESCUENTO1 = (CANT * P1 * DESC1 / 100)
                            DESCUENTO2 = (CANT * P1 * DESC2 / 100)

                            DES_TOT = DESCUENTO1 + DESCUENTO2

                            '------    IMPUESTOS PRECIO SIN DESCUENTO
                            cIP1 = P1 * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cIP2 = (P1 + cIP1) * IMPU2 / 100
                            Else
                                cIP2 = P1 * IMPU2 / 100
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cIP3 = (P1 + cIP1 + cIP2) * IMPU3 / 100
                            Else
                                cIP3 = P1 * IMPU3 / 100
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cIP4 = (P1 + cIP1 + cIP2 + cIP3) * IMPU4 / 100
                            Else
                                cIP4 = P1 * IMPU4 / 100
                            End If

                            '------    IMPUESTOS PRECIO PUBLICO
                            cI1 = P_LISTA1 * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cI2 = (P_LISTA1 + cI1) * IMPU2 / 100
                            Else
                                cI2 = P_LISTA1 * IMPU2 / 100
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cI3 = (P_LISTA1 + cI1 + cI2) * IMPU3 / 100
                            Else
                                cI3 = P_LISTA1 * IMPU3 / 100
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cI4 = (P_LISTA1 + cI1 + cI2 + cI3) * IMPU4 / 100
                            Else
                                cI4 = P_LISTA1 * IMPU4 / 100
                            End If

                            '------    IMPUESTOS PRECIO MINIMO
                            cIM1 = P2 * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cIM2 = (P2 + cIM1) * IMPU2 / 100
                            Else
                                cIM2 = P2 * IMPU2 / 100
                            End If
                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cIM3 = (P2 + cIM1 + cIM2) * IMPU3 / 100
                            Else
                                cIM3 = P2 * IMPU3 / 100
                            End If
                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cIM4 = (P2 + cIM1 + cIM2 + cIM3) * IMPU4 / 100
                            Else
                                cIM4 = P2 * IMPU4 / 100
                            End If

                            '------    IMPUESTOS ULTIMO COSTO
                            cIC1 = ULT_COSTO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cIC2 = (ULT_COSTO + cIC1) * IMPU2 / 100
                            Else
                                cIC2 = ULT_COSTO * IMPU2 / 100
                            End If
                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cIC3 = (ULT_COSTO + cIC1 + cIC2) * IMPU3 / 100
                            Else
                                cIC3 = ULT_COSTO * IMPU3 / 100
                            End If
                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cIC4 = (ULT_COSTO + cIC1 + cIC2 + cIC3) * IMPU4 / 100
                            Else
                                cIC4 = ULT_COSTO * IMPU4 / 100
                            End If

                            '------    IMPUESTOS CON DESCUENTO
                            cIeps = PRECIO_CON_DESC * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = (PRECIO_CON_DESC + cIeps) * IMPU2 / 100
                            Else
                                cImpu2 = PRECIO_CON_DESC * IMPU2 / 100
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = (PRECIO_CON_DESC + cIeps + cImpu2) * IMPU3 / 100
                            Else
                                cImpu3 = PRECIO_CON_DESC * IMPU3 / 100
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (PRECIO_CON_DESC + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = PRECIO_CON_DESC * IMPU4 / 100
                            End If

                            'PRECIO NETO
                            PRECIO_NETO = PRECIO_CON_DESC + cIeps + cImpu2 + cImpu3 + cImpu
                            'PRECIO SIN DESCUENTO
                            PRECIO_SIN_DESC = P1 + cIP1 + cIP2 + cIP3 + cIP4
                            'PRECIO PUBLICO
                            PRECIO_PUBLICO = P_LISTA1 + cI1 + cI2 + cI3 + cI4
                            'PRECIO MINIMO
                            PRECIO_MINIMO = P2 + cIM1 + cIM2 + cIM3 + cIM4
                            'PRECIO COSTO
                            PRECIO_COSTO = ULT_COSTO + cIC1 + cIC2 + cIC3 + cIC4
                            PRECIO_POS = PRECIO_NETO

                            Fg(i, 13) = Math.Round(DES_TOT, 3)
                            Fg(i, 16) = PRECIO_NETO  'PRECIO UNITARIO CON IMPUESTOS
                            Fg(i, 17) = CANT * PRECIO_SIN_DESC 'IMPORTE VENTA SIN DESCUENTO
                            Fg(i, 18) = CANT * PRECIO_NETO  'IMPORTE VENTA X PARTIDA

                            If PRECIO_COSTO > PRECIO_NETO Then
                                If PER_VEND_ABA_COST = 0 Then
                                    MsgBox("1. El precio no puede ser menor al costo")
                                    PRECIO_NETO = PRECIO_PUBLICO
                                    PRECIO_SIN_DESC = P_LISTA1 + cI1 + cI2 + cI3 + cI4
                                    Fg(i, 9) = P_LISTA1
                                    Fg(i, 10) = 0
                                    Fg(i, 13) = 0
                                    PRECIO_POS = PRECIO_PUBLICO
                                End If
                            Else
                                If PER_VEND_ABA_MIN = 0 Then
                                    If PRECIO_MINIMO > PRECIO_NETO Then

                                        Dim result = RJMessageBox.Show("El precio """ & CVE_ART & """ no puede ser menor al precio mínimo " & vbNewLine &
                                           "Precio minimo: $" & Format(PRECIO_MINIMO, "###,###,##0.00") & vbNewLine &
                                           "Precio venta : $" & Format(PRECIO_NETO, "###,###,##0.00"), "Advertencia", MessageBoxButtons.OK)


                                        PRECIO_NETO = PRECIO_PUBLICO
                                        Fg(i, 9) = P_LISTA1
                                        Fg(i, 10) = 0
                                        Fg(i, 13) = 0
                                        PRECIO_POS = PRECIO_PUBLICO
                                    End If
                                End If
                            End If

                            IMPORTE += CANT * PRECIO_POS

                            Fg(i, 16) = PRECIO_NETO  'PRECIO UNITARIO CON IMPUESTOS
                            Fg(i, 17) = CANT * PRECIO_SIN_DESC 'IMPORTE VENTA SIN DESCUENTO
                            Fg(i, 18) = CANT * PRECIO_NETO  'IMPORTE VENTA X PARTIDA
                        End If
                    Catch ex As Exception
                        MsgBox("243. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                            BITACORATPV("243. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        IMPORTE += Fg(i, 18)
                End If
            Next

            LtMonto.Value = Format(IMPORTE, "###,##0.00")
            Var13 = ""
        Catch ex As Exception
            BITACORATPV("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub SUB_PROMOCIONES(ByVal FFCVE_ART As String, ByVal FCANT As Decimal, ByRef FLISTA_PREC As Integer, ByRef FPORC As Decimal)

        FLISTA_PREC = 0
        FPORC = 0

        Try
            SQL = "SELECT ISNULL(PM.TIPO, -1) AS TIPO_PROM, ISNULL(PORC1,0) AS P1, ISNULL(PORC2,0) AS P2,
                ISNULL(PORC3,0) AS P3, ISNULL(PORC4,0) AS P4, ISNULL(PORC5,0) AS P5, ISNULL(LP1,0) AS L1,
                ISNULL(LP2,0) AS L2, ISNULL(LP3,0) AS L3, ISNULL(LP4,0) AS L4, ISNULL(LP5,0) AS L5, 
                CASE WHEN ISNULL(PM.TIPO, -1) = 0 
                THEN
                    CASE WHEN " & FCANT & " >= ISNULL(RANGO51,0) AND ISNULL(RANGO51,0) > 0 THEN ISNULL(LP5,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO41,0) AND ISNULL(RANGO41,0) > 0 THEN ISNULL(LP4,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO31,0) AND ISNULL(RANGO31,0) > 0 THEN ISNULL(LP3,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO21,0) AND ISNULL(RANGO21,0) > 0 THEN ISNULL(LP2,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO11,0) AND ISNULL(RANGO11,0) > 0 THEN ISNULL(LP1,0) ELSE 0 END
                ELSE
                    CASE WHEN " & FCANT & " >= ISNULL(RANGO51,0) AND ISNULL(RANGO51,0) > 0 THEN ISNULL(PORC5,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO41,0) AND ISNULL(RANGO41,0) > 0 THEN ISNULL(PORC4,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO31,0) AND ISNULL(RANGO31,0) > 0 THEN ISNULL(PORC3,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO21,0) AND ISNULL(RANGO21,0) > 0 THEN ISNULL(PORC2,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO11,0) AND ISNULL(RANGO11,0) > 0 THEN ISNULL(PORC1,0) ELSE 0 END
                END AS RESULT
                FROM GCPROMOCIONES PM 
                WHERE 
                PM.CVE_ART = '" & FFCVE_ART & "' AND ISNULL(RANGO11,0) > 0  AND ISNULL(RANGO21,0) > 0  AND 
                ISNULL(RANGO31,0) > 0  AND ISNULL(RANGO41,0) > 0  AND ISNULL(RANGO51,0) > 0 AND 
                ISNULL(PM.TIPO, -1) > -1 AND ISNULL(PM.TIPO, -1) < 2"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        If dr("TIPO_PROM") = 0 Then
                            FLISTA_PREC = dr("RESULT")
                        Else
                            FPORC = dr("RESULT")
                        End If

                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "CTE_POS"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                'Var6 = Fg(Fg.Row, 3).ToString 'rfc
                'Var7 = Fg(Fg.Row, 4).ToString 'LISTA PREC
                'Var8 = Fg(Fg.Row, 5).ToString 'DESC
                'Var9 = Fg(Fg.Row, 6).ToString 'calle
                'Var10 = Fg(Fg.Row, 7).ToString 'USO CFDI
                'Var11 = Fg(Fg.Row, 8).ToString 'RES FISC
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
                LLENA_CAMPOS(Var4)
                Var2 = ""
                Var4 = ""
                Var5 = ""

                TARTICULO.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            TARTICULO.Focus()
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            Dim DATO As String = ""
            If TCLIENTE.Text.Trim.Length = 0 Then
                Return
            End If

            If IsNumeric(TCLIENTE.Text.Trim) Then
                TCLIENTE.Text = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
            End If

            DATO = BUSCA_CAT("Cliente", TCLIENTE.Text)

            If DATO = "" Then
                MsgBox("Cliente inexistente", "1", "2")
            Else

                'TCLIENTE.Enabled = False
                'BtnCliente.Enabled = False

                LLENA_CAMPOS(TCLIENTE.Text)

                CALCULAR_IMPORTES()

            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENA_CAMPOS(ByVal fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim EXISTE As Boolean = False

            If IsNumeric(fCLAVE.Trim) Then
                fCLAVE = Space(10 - fCLAVE.Trim.Length) & fCLAVE.Trim
                TCLIENTE.Text = fCLAVE
            End If

            cmd.Connection = cnSAE
            SQL = "SELECT NOMBRE, CALLE, COLONIA, NUMINT, NUMEXT, CODIGO, RFC, MUNICIPIO, ESTADO, ISNULL(CVE_VEND,'') AS VEND,
                ISNULL(LISTA_PREC,1) AS LIST_PREC, ISNULL(USO_CFDI,'') AS USOCFDI, REG_FISC, ISNULL(DESCUENTO,0) AS DESC1,
                ISNULL(FORMADEPAGOSAT,'') AS FPAGOSAT, ISNULL(METODODEPAGO,'') AS METPAGO, ISNULL(EMAILPRED,'') AS CORREO
                FROM CLIE" & Empresa & " WHERE CLAVE  = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                LtNombre.Text = dr("NOMBRE").ToString
                LtNombre.Tag = dr("CORREO").ToString
                BtnCliente.Tag = dr("VEND")

                LISTA_PRECIO_CTE = dr("LIST_PREC")

                If LISTA_PRECIO_CTE = 0 Then
                    LISTA_PRECIO_CTE = 1
                End If

                DESCUENTO_CTE = dr("DESC1")
                EXISTE = True
            Else
                MsgBox("Cliente inexistente")

                LtNombre.Text = ""
                LtNombre.Tag = ""
                BtnCliente.Tag = ""
                LISTA_PRECIO_CTE = LISTAPRECPRED
                DESCUENTO_CTE = 0

                TCLIENTE.Text = ""
                TCLIENTE.Select()
            End If
            dr.Close()

        Catch ex As Exception
            BITACORATPV("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TARTICULO_GotFocus(sender As Object, e As EventArgs) Handles TARTICULO.GotFocus
        TARTICULO.BackColor = Mcolor1
    End Sub
    Private Sub TARTICULO_LostFocus(sender As Object, e As EventArgs) Handles TARTICULO.LostFocus
        TARTICULO.BackColor = Mcolor2
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        'Mycolor1 = Fg.BackColor
    End Sub
    Private Sub BtnCheque_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnCliente_GotFocus(sender As Object, e As EventArgs) Handles BtnCliente.GotFocus
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnEfectivo_GotFocus(sender As Object, e As EventArgs) Handles BtnCobrar.GotFocus
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnTarjetaCredito_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnTarjetaDebito_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnTiempoAire_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnTrans_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnValesDespensa_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub BtnVentaCredito_GotFocus(sender As Object, e As EventArgs)
        'Mycolor1 = BtnEfectivo.BackColor
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                If e.Col <> 2 And e.Col <> 9 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        'If e.KeyData = 13 Then
        'Fg.FinishEditing()
        'TARTICULO.Focus()
        'End If
    End Sub
    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If e.KeyCode = 9 Then
            'TARTICULO.Select()
            TARTICULO.Focus()
        End If
    End Sub
    Private Sub Fg_LeaveCell(sender As Object, e As EventArgs) Handles Fg.LeaveCell
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown

        Select Case e.KeyCode
            Case 13
                TARTICULO.Focus()
            Case Keys.Up
                If Fg.Row = 1 Then
                    TARTICULO.Focus()
                End If
            Case Keys.Left
                If Fg.Col = 2 Then
                    TARTICULO.Focus()
                End If
            Case 46
                If Fg.Row > 0 Then
                    Dim result = RJMessageBox.Show("Realmente desea eliminar la partida?", "Question Icon", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Fg.RemoveItem(Fg.Row)

                        CALCULAR_IMPORTES(98989898)

                        TARTICULO.Focus()
                    End If
                End If
        End Select

    End Sub

    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        If Fg.Row = 1 Then
            If e.KeyCode = Keys.Up Then
                TARTICULO.Focus()
            End If
        End If
    End Sub

    Private Sub TXTN_Validating(sender As Object, e As CancelEventArgs) Handles TXTN.Validating


    End Sub
    Private Sub TXTN_PostValidating(sender As Object, e As PostValidationEventArgs) Handles TXTN.PostValidating
        'Dim DATO As Decimal
        If Fg.Row > 0 Then
            'Decimal.TryParse(TXTN.Text, DATO)
            If Fg.Col = 2 Then 'cantidad
                If (CType(e.Value, Decimal) >= 0) And (CType(e.Value, Decimal) <= 999999) Then

                Else
                    e.ErrorInfo.ErrorMessage = "Por favor capture una dato valido"
                    e.GetHashCode()
                End If
            End If

            If Fg.Col = 9 Then ' descuento
                If (CType(e.Value, Decimal) >= 0) And (CType(e.Value, Decimal) <= 100) Then

                Else
                    e.ErrorInfo.ErrorMessage = "Por favor capture una dato valido"
                    e.Succeeded = False
                    TXTN.Value = 0
                End If
            End If
        End If
    End Sub
    Private Sub TXTN_Leave(sender As Object, e As EventArgs) Handles TXTN.Leave
        If Fg.Row > 0 Then
            If Fg.Col = 2 Or Fg.Col = 10 Or Fg.Col = 11 Then
                CALCULAR_IMPORTES(Fg.Row)

                LtPrecioXProducto.Text = "Precio $ " & Format(Fg(Fg.Row, 16), "###,###,##0.00")

            End If
        End If
    End Sub
    Private Sub TXTN_KeyUp(sender As Object, e As KeyEventArgs) Handles TXTN.KeyUp

    End Sub
    Private Sub TXTN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTN.KeyPress

    End Sub
    Private Sub TXTN_Enter(sender As Object, e As EventArgs) Handles TXTN.Enter

    End Sub
    Private Sub Fg_RowColChange(sender As Object, e As EventArgs) Handles Fg.RowColChange
        Try
            If Fg.Row > 0 Then

                LtPrecioXProducto.Text = "Precio $ " & Format(Fg(Fg.Row, 16), "###,###,##0.00")

                If Not IsNothing(Fg(Fg.Row, 20)) Then
                    If Fg(Fg.Row, 20).ToString.Trim.Length > 0 Then

                        If File.Exists(Fg(Fg.Row, 20)) Then
                            Pic.Image = Image.FromFile(Fg(Fg.Row, 20))
                        Else
                            Pic.Image = PicFoto.Image
                        End If
                    Else
                        Pic.Image = PicFoto.Image
                    End If
                Else
                    Pic.Image = PicFoto.Image
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnClienteDatos_Click(sender As Object, e As EventArgs) Handles BtnClienteDatos.Click

        Try
            If TCLIENTE.Text.Trim.Length > 0 Then

                Var1 = "Consulta"
                Var2 = TCLIENTE.Text
                Using options = New FrmDatosCliente
                    If DialogResult.OK = options.ShowDialog() Then

                    End If
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class

