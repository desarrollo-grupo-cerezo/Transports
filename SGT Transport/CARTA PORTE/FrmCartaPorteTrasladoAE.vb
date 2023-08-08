Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports org.BouncyCastle.Bcpg

Public Class FrmCartaPorteTrasladoAE
    Private TIPO_VENTA_LOCAL As String = "T"
    Private SERIE_CP As String

    Private USO_CFDI As String
    Private MONEDA As String
    Private METODODEPAGO As String
    Private FORMAPAGO As String
    Private EMISOR_RAZON_SOCIAL As String
    Private CP_SAT As String
    Private RFC_EMISOR As String
    Private NoseCargoTea As Boolean = True


    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmCartaPorteTrasladoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not NoseCargoTea Then
            MsgBox("Por favor capture la conección a la base TEA")
            Me.Close()
            Return

        End If

        If Not NoseCargoTea Then
            MsgBox("Imposible conectarse a la base TEA verfique por favor")
            Me.Close()
            Return
        End If

        Dim SPOR1 As Decimal

        SPOR1 = ((TKMRecorridos.Top + TKMRecorridos.Height + BarraMENU.Height) / Me.Height) * 100
        Split1.SizeRatio = SPOR1

        Split2.SizeRatio = 100 - Split1.SizeRatio

    End Sub

    Sub CARGAR_DATOS1()
        Dim SERVIDOR_TEA As String = "", BASE_TEA As String = "", USUARIO_TEA As String = "", PASS_TEA As String = ""

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            BtnTEA.FlatStyle = FlatStyle.Flat
            BtnTEA.FlatAppearance.BorderSize = 0
            BtnTractor.FlatStyle = FlatStyle.Flat
            BtnTractor.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
        Catch ex As Exception
        End Try

        Try
            Me.WindowState = FormWindowState.Maximized
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With

            SplitM1.Dock = DockStyle.Fill
            SplitM1.BorderWidth = 1
            SplitM1.SplitterWidth = 1

            Fg.Dock = DockStyle.Fill

            TKMRecorridos.Value = 0

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM CFDI_CFG"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                            CP_SAT = dr.ReadNullAsEmptyString("CP")
                            RFC_EMISOR = dr("EMISOR_RFC")

                            If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                                LtTimbrado.Text = "TIMBRADO SAT"
                            Else
                                LtTimbrado.Text = "TIMBRADO DEMO"
                            End If

                        End If
                    End Using
                End Using

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM GCPARAMTRANSCG"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TConfigVehicular.Text = dr.ReadNullAsEmptyString("CONFIGVEHICULAR")

                            LTConfigVehicular.Text = BUSCA_CAT2("ConfigVehicular", TConfigVehicular.Text)

                        End If
                    End Using
                End Using

            Catch ex As Exception
                BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            LtCliente.Text = ""
            LtSucOrigen.Tag = "0"
            LtSucDestino.Tag = "0"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(SERIE_CP_TRASLADO,'') AS SERIE_CP_TRAS, ISNULL(CVE_CLIE,'') AS CLIENTE,
                    ISNULL(NOMBRE,'') AS NOMB, ISNULL(RFC,'') AS RF, ISNULL(USO_CFDI,'') AS USOCFDI
                    FROM CFDI_SERIES S
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = S.CVE_CLIE"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_CP = dr("SERIE_CP_TRAS")
                        LtCliente.Text = dr("CLIENTE")
                        LtNombre.Text = dr("NOMB")
                        LtRFC.Text = dr("RF")
                        LtUsoCFDI.Text = dr("USOCFDI")
                    End If
                End Using
            End Using
            If LtCliente.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el cliente en parámetros CFDI")
                Me.Close()
                Return
            End If

            Fg.DrawMode = DrawModeEnum.OwnerDraw
            Fg.Rows.Count = 1

            Fg.Cols(0).Width = 40 : Fg.Cols(1).Width = 90 : Fg.Cols(2).Width = 0 : Fg.Cols(3).Width = 90
            Fg.Cols(4).Width = 340 : Fg.Cols(5).Width = 90 : Fg.Cols(6).Width = 90

            Using cmd As SqlCommand = cnSAROCE.CreateCommand
                SQL = "SELECT SERVIDOR, BASE, USUARIO, PASS FROM TEA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERVIDOR_TEA = dr("SERVIDOR")
                        BASE_TEA = dr("BASE")
                        USUARIO_TEA = dr("USUARIO")
                        PASS_TEA = dr("PASS")
                    End If
                End Using
            End Using


            If SERVIDOR_TEA.Trim.Length = 0 Or BASE_TEA.Trim.Length = 0 Or USUARIO_TEA.Trim.Length = 0 Or PASS_TEA.Trim.Length = 0 Then
                NoseCargoTea = False
            End If

            If Not OpenSAE(SERVIDOR_TEA, BASE_TEA, USUARIO_TEA, PASS_TEA) Then
                NoseCargoTea = False
            End If

            If Var2 = "Nuevo" Then
                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA("T", SERIE_CP)
                DOC_NEW = True
                BarCancelar.Enabled = False
            Else
                DOC_NEW = False
                TFOLIO_TEA.Text = Var12
                TFOLIO_TEA.Enabled = False

                BarTimbrarCartaPorteTraslado.Enabled = False

                BarSerie.Enabled = False

                BtnTEA.Enabled = False
                BtnTractor.Enabled = False
                BtnOper.Enabled = False
                TCVE_OPER.Enabled = False
                TCVE_TRACTOR.Enabled = False

                BUSCAR_CARATA_PORTE_TRASLADO(Var12)

            End If

            CboTransInter.Items.Add("No")
            CboTransInter.Items.Add("Si")
            CboTransInter.SelectedIndex = 0


            AJUSTA_COLUMNAS_FG(Fg, 0)
        Catch ex As Exception
            BITACORATPV("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_CARATA_PORTE_TRASLADO(FCVE_DOC As String)
        Dim PREC As Single, IEPS As Single, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single, Sigue As Boolean, s As String, j As Integer
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If Not Valida_Conexion() Then
            Return
        End If

        cmd.Connection = cnSAE
        Try

            SQL = "SELECT P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA,
                        NUM_PAR, P.CVE_DOC, ISNULL(F.NUM_ALMA,1) AS NUMALM1, ISNULL(F.NUM_ALM_DES,1) AS NUMALM2, ISNULL(P.DESC1,0) AS D1, 
                        F.FECHA_DOC, F.CVE_CLPV, C.NOMBRE, C.RFC, F.STATUS, ISNULL(CVE_UNI,'') AS UNI, ISNULL(CVE_OPER,0) AS OPER,
                        ISNULL(KMS_RECORRIDOS,0) AS KMS
                        FROM CFDI_CPT_PAR P
                        LEFT JOIN CFDI_CPT F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Sigue = True
            Do While dr.Read
                If Sigue Then
                    Try
                        LtCVE_DOC.Text = dr("CVE_DOC")
                        If dr("STATUS") = "C" Then
                            LtCanc.Visible = True
                        Else
                            LtCanc.Visible = False
                        End If
                        LtCliente.Text = dr("CVE_CLPV")

                        LtNombre.Text = dr("NOMBRE").ToString
                        LtRFC.Text = dr("RFC").ToString
                        TCVE_TRACTOR.Text = dr("UNI")
                        LtTractor.Text = BUSCA_CAT("Unidades", TCVE_TRACTOR.Text)

                        TCVE_OPER.Text = dr("OPER")
                        LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

                        TKMRecorridos.Value = dr("KMS")
                        F1.Value = dr("FECHA_DOC")

                        LtSucOrigen.Text = dr("NUMALM1") & " " & BUSCA_EN_CFDI_UBICACIONES(dr("NUMALM1"))
                        LtSucDestino.Text = dr("NUMALM2") & " " & BUSCA_EN_CFDI_UBICACIONES(dr("NUMALM2"))
                    Catch ex As Exception
                        BITACORATPV("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Sigue = False
                End If
                PREC = dr("PREC")
                PREC = Math.Round(PREC, 4)
                DESCP = PREC * dr("DESC1") / 100
                IEPS = dr("IMPU1")
                cIEPS = (PREC - DESCP - DESCP2) * IEPS / 100
                IMPU = dr("IMPU4")
                cIMPU = (PREC - DESCP - DESCP2 + cIEPS) * IMPU / 100
                PrecioVenta = PREC - DESCP - DESCP2
                s = dr("CANT") & vbTab '1
                s &= dr("NUMALM1") & vbTab '2
                s &= dr("CVE_ART") & vbTab '3
                s &= dr("DESCR") & vbTab '4
                s &= dr("PREC") & vbTab '5
                s &= dr("CANT") * dr("PREC")

                Fg.AddItem("" & vbTab & s)
                j += 1
            Loop

        Catch ex As Exception
            BITACORATPV("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCA_EN_CFDI_UBICACIONES(FALM As Integer) As String
        Dim NOMB As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(NOMBRE,'') AS NOMB FROM CFDI_UBICACIONES WHERE CVE_ALM = " & FALM
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NOMB = dr("NOMB")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return NOMB
    End Function
    Sub BUSCAR_FOLIO_TEA(FFOLIO_TEA As String)
        Dim SIGUE As Boolean = True

        Fg.Rows.Count = 1

        Try
            SQL = "SELECT id, serie, folio, cantidad, costo, precio, articulo, descrip, sucentrega, sucsolicita, f_entrega, 
                f_recepcion, estado1, estatus, cancelado, estacion3, hora, hora2, succamion, estatus, alm1, solicita as origen, 
                recibe as destino    
                 FROM movs M WHERE succamion = '" & FFOLIO_TEA & "'"

            Try
                Using cmd As SqlCommand = cnSQL.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            If SIGUE Then
                                SIGUE = False
                                LtSucOrigen.Text = dr("sucentrega")
                                LtSucOrigen.Tag = dr("origen")
                                LtSucDestino.Text = dr("sucsolicita")
                                LtSucDestino.Tag = dr("destino")

                                Try
                                    TFechaCarga.Value = dr("f_entrega") & " " & dr("hora")
                                    TFechaDescarga.Value = dr("f_entrega") & " " & dr("hora")
                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                            End If

                            Fg.AddItem("" & vbTab & dr("cantidad") & vbTab & "" & vbTab & dr("articulo") & vbTab &
                                       dr("descrip") & vbTab & dr("precio") & vbTab & dr("cantidad") * dr("precio"))
                        End While
                    End Using
                End Using
                LtNpart.Text = "Núm. partidas: " & Fg.Rows.Count - 1
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Dim ALM1 As Integer = 0, ALM2 As String = 0

            If IsNumeric(LtSucOrigen.Tag) Then ALM1 = LtSucOrigen.Tag
            If IsNumeric(LtSucDestino.Tag) Then ALM2 = LtSucDestino.Tag

            SQL = "SELECT CVE_ALM, KMS_RECORRIDOS
                FROM CFDI_UBICACIONES
                WHERE CVE_ALM = " & ALM2
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            If ALM2 = dr("CVE_ALM") Then
                                TKMRecorridos.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")
                            End If
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCartaPorteTrasladoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            cnSQL.Close()

            If Form_Open(FrmCartaPorteTraslado) Then
                FrmCartaPorteTraslado.DESPLEGAR()
            End If

        Catch ex As Exception
        End Try
        Me.Dispose()
        CloseTab("Carta porte traslado")
    End Sub

    Private Sub BarTimbrarCartaPorteTraslado_Click(sender As Object, e As EventArgs) Handles BarTimbrarCartaPorteTraslado.Click

        Dim CANT As Decimal
        Dim FOLIO As Integer, CLIENTE As String, CVE_ART As String, PRECIO As Decimal, PREC As Decimal, DESC1 As Decimal, DESC2 As Decimal
        Dim DESC3 As Decimal, ALMACEN As Integer, NUM_ALM_DES As Integer, TIP_DOC As String, E_LTPD As Integer, DES_FIN As Decimal
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim cImpu1 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu4 As Decimal
        Dim SUBTOTAL As Decimal, ImporteConDes As Decimal, DES_TOT As Decimal, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, IMPORTE As Decimal, COM_TOT As Decimal
        Dim CVE_DOC As String = "", STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim CAN_TOT As Decimal, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal
        Dim CONDICION As String, CVE_OBS As Long, NUM_ALMA As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Long, TIPCAMB As Decimal, NUM_PAGOS As Long, PRIMERPAGO As Decimal, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String, CVE_BITA As Long
        Dim Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, COM_TOT_PORC As Decimal
        'variables partidas
        Dim NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Integer, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer
        Dim CVE_ESQ As Integer, COST As Decimal, COMI As Decimal, APAR As Decimal, ACT_INV As String, POLIT_APLI As String, TIP_CAM As Decimal
        Dim TIPO_PROD As String, REG_SERIE As Long, TIPO_ELEM As String, TOT_PARTIDA As Decimal
        Dim APL_MAN_IEPS As String, MTO_PORC As Integer, MTO_CUOTA As Integer
        'MOVSINV
        Dim DESDE_INVE As String, FORMADEPAGOSAT As String, UNI_MED As String, DETEC_ERROR_VIOLATION_KEY As Boolean
        Dim COSTO_PROM As Decimal, UUID As String, SIGUE As Boolean, FOLIO_ASIGNADO As Boolean, PESOBRUTOTOTAL As Decimal = 0, PESO_PRODUCTO As Decimal


        Try
            TKMRecorridos.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
            Try
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR = "" Then
                    MsgBox("Operador inexistente")
                    TCVE_OPER.Focus()
                    Return
                End If
            Catch ex As Exception
                BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione el operador")
            TCVE_OPER.Focus()
            Return
        End If

        If TCVE_TRACTOR.Text.Trim.Length > 0 Then
            Try
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR = "" Then
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Focus()
                End If
            Catch ex As Exception
                BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione la unidad")
            TCVE_TRACTOR.Focus()
            Return
        End If

        If TConfigVehicular.Text.Trim.Length = 0 Then
            MsgBox("Por favor la configración vehicular")
            Return
        End If

        If TKMRecorridos.Value = 0 Then
            MsgBox("Por favor capture los kilómetros recorridos")
            Return
        End If

        If MsgBox("Realmente desea grabar la carta porte traslado?", vbYesNo) = vbNo Then
            Return
        End If

        If Not Valida_Conexion() Then
            Return
        End If


        TFOLIO_TEA.Enabled = False
        BtnTEA.Enabled = False
        TCVE_TRACTOR.Enabled = False
        LtTractor.Enabled = False
        TCVE_OPER.Enabled = False
        LtOper.Enabled = False


        TIPO_VENTA_LOCAL = "T"

        Try
            SIGUE = True
            FOLIO_ASIGNADO = False
            ' Toma el siguiente folio tabla FOLIOSF
            FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, SERIE_CP)

            Do While SIGUE
                If SERIE_CP.Trim.Length = 0 Or SERIE_CP = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                Else
                    CVE_DOC = SERIE_CP & Format(FOLIO_VENTA, "0000000000")
                End If

                If EXISTE_CARTA_PORTA_TRASLADO(CVE_DOC) Then
                    FOLIO_VENTA += 1
                    FOLIO_ASIGNADO = True
                Else
                    SIGUE = False
                End If
            Loop
        Catch ex As Exception
            BITACORATPV("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
            TFOLIO_TEA.Enabled = True
            BtnTEA.Enabled = True
            TCVE_TRACTOR.Enabled = True
            LtTractor.Enabled = True
            TCVE_OPER.Enabled = True
            LtOper.Enabled = True

            Return
        End Try

        FOLIO = FOLIO_VENTA
        SERIE = SERIE_CP

        NUM_ALMA = Convert.ToInt16(LtSucOrigen.Tag)
        NUM_ALM_DES = Convert.ToInt16(LtSucDestino.Tag)
        UNI_MED = "" : TIP_CAM = 1 : REG_SERIE = 0 : E_LTPD = 0 : DAT_MOSTR = 0
        CLIENTE = LtCliente.Text
        CVE_VEND = ""

        '███████████████████████████████████████████████████████████████████████████████████████
        '                                 INICIA LA GRABACION DE LAS CABEZAS

        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
        Try

            IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0
            CONDICION = "" : CVE_OBS = 0 : ACT_CXC = "S" : ACT_COI = "A" : ENLAZADO = "O"
            TIPCAMB = 1 : NUM_PAGOS = 1
            CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
            FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
            DAT_ENVIO = 0 : COM_TOT_PORC = 0 : IMPORTE = 0
            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC = "T" : TIP_DOC_ANT = "" : DOC_ANT = ""
            STATUS = "E" : DESDE_INVE = "N" : TIP_CAM = 1 : E_LTPD = 0 : UUID = "" : SUBTOTAL = 0

            NUM_MONED = 1
            METODODEPAGO = ""
            USO_CFDI = LtUsoCFDI.Text
            FORMADEPAGOSAT = ""

            TIP_DOC_E = "T"
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            DESC2 = 0
            DESC3 = 0

            For k = 1 To Fg.Rows.Count - 1

                For w = 1 To 5
                    If Valida_Conexion() Then
                        Exit For
                    End If
                Next

                Try
                    CANT = Fg(k, 1)
                    CVE_ART = Fg(k, 3)
                Catch ex As Exception
                    CANT = 0 : ALMACEN = 1 : CVE_ART = ""
                End Try

                If CANT > 0 And CVE_ART.Trim.Length > 0 Then

                    CONTADO = "N"
                    METODODEPAGO = "PPD"
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    TIP_DOC = "T"
                    PESO_PRODUCTO = 0
                    Try
                        SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS UCOSTO, ISNULL(I.COSTO_PROM,0) AS CPROM, ISNULL(P.IMPUESTO1,0) AS IMPU1,
                            ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3, ISNULL(P.IMPUESTO4,0) AS IMPU4, ISNULL(P.IMP1APLICA,0) AS IMP1APLA,
                            ISNULL(P.IMP2APLICA,0) AS IMP2APLA, ISNULL(P.IMP3APLICA,0) AS IMP3APLA, ISNULL(P.IMP4APLICA,0) AS IMP4APLA,
                            ISNULL(TIPO_ELE,'') AS TIP_ELE, ISNULL(I.PESO,0) AS PESO_PROD
                            FROM INVE" & Empresa & " I
                            LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                            WHERE CVE_ART = '" & CVE_ART & "'"

                        Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                            cmdF2.CommandText = SQL
                            Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                                If drF2.Read Then
                                    'COST = drF2("UCOSTO").ToString
                                    COST = 0 'Math.Round(COST, 2)
                                    COSTO_PROM = drF2("CPROM").ToString
                                    IMPU1 = drF2("IMPU1")
                                    IMPU2 = drF2("IMPU2")
                                    IMPU3 = drF2("IMPU3")
                                    IMPU4 = drF2("IMPU4")
                                    IMP1APLA = drF2("IMP1APLA")
                                    IMP2APLA = drF2("IMP2APLA")
                                    IMP3APLA = drF2("IMP3APLA")
                                    IMP4APLA = drF2("IMP4APLA")
                                    CVE_ESQ = drF2("CVE_ESQIMPU")
                                    UNI_MED = drF2("UNI_MED")
                                    TIPO_PROD = drF2("TIP_ELE") '= "K"
                                    PESO_PRODUCTO = drF2("PESO_PROD")
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("640. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    PESOBRUTOTOTAL += CANT * IIf(PESO_PRODUCTO = 0, 1, PESO_PRODUCTO)

                    DESC1 = 0 'Fg(k, 8)
                    PRECIO = 0 'Fg(k, 5)
                    PREC = 0 'PRECIO
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
                    IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                End If
            Next
            CAN_TOT = SUBTOTAL
            DES_TOT_PORC = DESC1
            COM_TOT = 0
            PRIMERPAGO = 0
            DES_TOT = DES_TOT
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            CVE_OBS = 0

            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

            CVE_PEDI = TCVE_TRACTOR.Text
            DAT_ENVIO = TCVE_OPER.Text

            CONDICION = ""
            PRIMERPAGO = IMPORTE
            RFC = LtRFC.Text

            CVE_OBS = 0




            Try '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                Dim RegDuplicado As Boolean = False
                Dim SQLF As String

                SQLF = SQL
                DETEC_ERROR_VIOLATION_KEY = False
                For k = 1 To 5

                    If DOC_NEW Then
                        SQL = "INSERT INTO CFDI_CPT (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, 
                            FECHA_VEN, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, NUM_ALMA, 
                            ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, CTLPOL, ESCFD, 
                            AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, 
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, UUID, VERSION_SINC, 
                            FORMADEPAGOSAT, USO_CFDI, NUM_ALM_DES, TIP_TRASLADO, FECHA_CARGA, FECHA_DESCARGA, KMS_RECORRIDOS, CVE_UNI, CVE_OPER,
                            TRANSPINTERNAC, CONFIGVEHICULAR, PESOBRUTOTOTAL) VALUES(
                            'T', @CVE_DOC, @CVE_CLPV, 'A', @DAT_MOSTR, @CVE_VEND, @CVE_PEDI, @FECHA_DOC, @FECHA_ENT, @FECHA_VEN, @CAN_TOT, 
                            @IMP_TOT1, @IMP_TOT2, @IMP_TOT3, @IMP_TOT4, @DES_TOT, @DES_FIN, @COM_TOT, @CONDICION, @CVE_OBS, @NUM_ALMA, 
                            @ACT_CXC, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @PRIMERPAGO, @RFC, @CTLPOL, 
                            @ESCFD, @AUTORIZA, @SERIE, @FOLIO, @AUTOANIO, @DAT_ENVIO, @CONTADO, @CVE_BITA, @BLOQ, @FORMAENVIO, @DES_FIN_PORC, 
                            @DES_TOT_PORC, @IMPORTE, @COM_TOT_PORC, @METODODEPAGO, @NUMCTAPAGO, @TIP_DOC_ANT, @DOC_ANT, @TIP_DOC_SIG, @DOC_SIG, 
                            NEWID(), GETDATE(), @FORMADEPAGOSAT, @USO_CFDI, @NUM_ALM_DES, @TIP_TRASLADO, @FECHA_CARGA, @FECHA_DESCARGA, 
                            @KMS_RECORRIDOS, @CVE_UNI, @CVE_OPER, @TRANSPINTERNAC, @CONFIGVEHICULAR, @PESOBRUTOTOTAL)"

                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CLIENTE
                                cmd.Parameters.Add("@DAT_MOSTR", SqlDbType.Int).Value = DAT_MOSTR
                                cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = CVE_VEND
                                cmd.Parameters.Add("@CVE_PEDI", SqlDbType.VarChar).Value = CVE_PEDI
                                cmd.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = F1.Value
                                cmd.Parameters.Add("@FECHA_ENT", SqlDbType.DateTime).Value = F1.Value
                                cmd.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = F1.Value
                                cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = CAN_TOT
                                cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = IMP_TOT1
                                cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = IMP_TOT2
                                cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = IMP_TOT3
                                cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = IMP_TOT4
                                cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                                cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = DES_FIN
                                cmd.Parameters.Add("@COM_TOT", SqlDbType.Float).Value = COM_TOT
                                cmd.Parameters.Add("@CONDICION", SqlDbType.VarChar).Value = CONDICION
                                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                                cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = NUM_ALMA
                                cmd.Parameters.Add("@ACT_CXC", SqlDbType.VarChar).Value = ACT_CXC
                                cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = ACT_COI
                                cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = ENLAZADO
                                cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = TIP_DOC_E
                                cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = NUM_MONED
                                cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = TIPCAMB
                                cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = NUM_PAGOS
                                cmd.Parameters.Add("@PRIMERPAGO", SqlDbType.Float).Value = PRIMERPAGO
                                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RFC
                                cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = CTLPOL
                                cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = ESCFD
                                cmd.Parameters.Add("@AUTORIZA", SqlDbType.Int).Value = AUTORIZA
                                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE
                                cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                                cmd.Parameters.Add("@AUTOANIO", SqlDbType.VarChar).Value = AUTOANIO
                                cmd.Parameters.Add("@DAT_ENVIO", SqlDbType.Int).Value = DAT_ENVIO
                                cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                                cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = 0
                                cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = Bloq
                                cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = FORMAENVIO
                                cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = DES_FIN_PORC
                                cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = DES_TOT_PORC
                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPORTE
                                cmd.Parameters.Add("@COM_TOT_PORC", SqlDbType.Float).Value = COM_TOT_PORC
                                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                                cmd.Parameters.Add("@NUMCTAPAGO", SqlDbType.VarChar).Value = NUMCTAPAGO
                                cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = TIP_DOC_ANT
                                cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = DOC_ANT
                                cmd.Parameters.Add("@TIP_DOC_SIG", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMADEPAGOSAT
                                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                                cmd.Parameters.Add("@NUM_ALM_DES", SqlDbType.Int).Value = NUM_ALM_DES
                                cmd.Parameters.Add("@TIP_TRASLADO", SqlDbType.VarChar).Value = "T"
                                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = TFechaCarga.Value
                                cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = TFechaDescarga.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMRecorridos.Value
                                cmd.Parameters.Add("@PESOBRUTOTOTAL", SqlDbType.Float).Value = PESOBRUTOTOTAL
                                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                                cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = TCVE_OPER.Text
                                cmd.Parameters.Add("@TRANSPINTERNAC", SqlDbType.VarChar).Value = CboTransInter.Text
                                cmd.Parameters.Add("@CONFIGVEHICULAR", SqlDbType.VarChar).Value = TConfigVehicular.Text

                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Exit For
                                    End If
                                End If
                            End Using
                        Catch ex As SqlException
                            ' Log the original exception here
                            For Each sqlError As SqlError In ex.Errors

                                BITACORASQL(sqlError.Number & ", " & sqlError.ToString)

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
                        Catch ex As Exception
                            BITACORATPV("693. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If Not Valida_Conexion() Then
                        End If

                        If DETEC_ERROR_VIOLATION_KEY Then
                            Try
                                SIGUE = True
                                FOLIO_ASIGNADO = False
                                FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA("T", SERIE_CP)
                                Do While SIGUE
                                    If SERIE_CP.Trim.Length = 0 Or SERIE_CP = "STAND." Then
                                        CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                                    Else
                                        CVE_DOC = SERIE_CP & Format(FOLIO_VENTA, "0000000000")
                                    End If

                                    If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                                        FOLIO_VENTA += 1
                                        FOLIO_ASIGNADO = True
                                    Else
                                        SIGUE = False
                                    End If
                                Loop
                            Catch ex As Exception
                                MsgBox("693. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    Else
                        SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM CFDI_CPT WHERE CVE_DOC = '" & CVE_DOC & "')
                            INSERT INTO CFDI_CPT (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, DAT_MOSTR, CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, 
                            FECHA_VEN, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, CONDICION, CVE_OBS, NUM_ALMA, 
                            ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, PRIMERPAGO, RFC, CTLPOL, ESCFD, 
                            AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, 
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, UUID, VERSION_SINC, 
                            FORMADEPAGOSAT, USO_CFDI, NUM_ALM_DES, TIP_TRASLADO, FECHA_CARGA, FECHA_DESCARGA, KMS_RECORRIDOS, CVE_UNI, 
                            TRANSPINTERNAC) VALUES(
                            'T', @CVE_DOC, @CVE_CLPV, 'A', @DAT_MOSTR, @CVE_VEND, @CVE_PEDI, @FECHA_DOC, @FECHA_ENT, @FECHA_VEN, @CAN_TOT, 
                            @IMP_TOT1, @IMP_TOT2, @IMP_TOT3, @IMP_TOT4, @DES_TOT, @DES_FIN, @COM_TOT, @CONDICION, @CVE_OBS, @NUM_ALMA, 
                            @ACT_CXC, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @PRIMERPAGO, @RFC, @CTLPOL, 
                            @ESCFD, @AUTORIZA, @SERIE, @FOLIO, @AUTOANIO, @DAT_ENVIO, @CONTADO, @CVE_BITA, @BLOQ, @FORMAENVIO, @DES_FIN_PORC, 
                            @DES_TOT_PORC, @IMPORTE, @COM_TOT_PORC, @METODODEPAGO, @NUMCTAPAGO, @TIP_DOC_ANT, @DOC_ANT, @TIP_DOC_SIG, @DOC_SIG, 
                            NEWID(), GETDATE(), @FORMADEPAGOSAT, @USO_CFDI, @NUM_ALM_DES, @TIP_TRASLADO, @FECHA_CARGA, @FECHA_DESCARGA, 
                            @KMS_RECORRIDOS, @CVE_UNI, @TRANSPINTERNAC)"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CLIENTE
                            cmd.Parameters.Add("@DAT_MOSTR", SqlDbType.Int).Value = DAT_MOSTR
                            cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = CVE_VEND
                            cmd.Parameters.Add("@CVE_PEDI", SqlDbType.VarChar).Value = CVE_PEDI
                            cmd.Parameters.Add("@FECHA_DOC", SqlDbType.DateTime).Value = F1.Value
                            cmd.Parameters.Add("@FECHA_ENT", SqlDbType.DateTime).Value = F1.Value
                            cmd.Parameters.Add("@FECHA_VEN", SqlDbType.DateTime).Value = F1.Value
                            cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = CAN_TOT
                            cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = IMP_TOT1
                            cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = IMP_TOT2
                            cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = IMP_TOT3
                            cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = IMP_TOT4
                            cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                            cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = DES_FIN
                            cmd.Parameters.Add("@COM_TOT", SqlDbType.Float).Value = COM_TOT
                            cmd.Parameters.Add("@CONDICION", SqlDbType.VarChar).Value = CONDICION
                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = NUM_ALMA
                            cmd.Parameters.Add("@ACT_CXC", SqlDbType.VarChar).Value = ACT_CXC
                            cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = ACT_COI
                            cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = ENLAZADO
                            cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = TIP_DOC_E
                            cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = NUM_MONED
                            cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = TIPCAMB
                            cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = NUM_PAGOS
                            cmd.Parameters.Add("@PRIMERPAGO", SqlDbType.Float).Value = PRIMERPAGO
                            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RFC
                            cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = CTLPOL
                            cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = ESCFD
                            cmd.Parameters.Add("@AUTORIZA", SqlDbType.Int).Value = AUTORIZA
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                            cmd.Parameters.Add("@AUTOANIO", SqlDbType.VarChar).Value = AUTOANIO
                            cmd.Parameters.Add("@DAT_ENVIO", SqlDbType.Int).Value = DAT_ENVIO
                            cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = Bloq
                            cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = FORMAENVIO
                            cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = DES_FIN_PORC
                            cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = DES_TOT_PORC
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPORTE
                            cmd.Parameters.Add("@COM_TOT_PORC", SqlDbType.Float).Value = COM_TOT_PORC
                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                            cmd.Parameters.Add("@NUMCTAPAGO", SqlDbType.VarChar).Value = NUMCTAPAGO
                            cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = TIP_DOC_ANT
                            cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = DOC_ANT
                            cmd.Parameters.Add("@TIP_DOC_SIG", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMADEPAGOSAT
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@NUM_ALM_DES", SqlDbType.Int).Value = NUM_ALM_DES
                            cmd.Parameters.Add("@TIP_TRASLADO", SqlDbType.VarChar).Value = "T"
                            cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = TFechaCarga.Value
                            cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = TFechaDescarga.Value
                            cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMRecorridos.Value
                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                            cmd.Parameters.Add("@TRANSPINTERNAC", SqlDbType.VarChar).Value = CboTransInter.Text
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Exit For
                                End If
                            End If
                        End Using
                    End If
                Next
                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                If DOC_NEW Then
                    Try
                        If SERIE_CP = "" Or SERIE_CP = "STAND." Then
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = 'F' AND SERIE = 'STAND.'"
                        Else
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = 'F' AND SERIE = '" & SERIE_CP & "'"
                        End If
                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                            cmd3.CommandText = SQL
                            returnValue = cmd3.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORATPV("715. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    Debug.Print("")
                End If
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
        NUM_PAR = 1 : CVE_ART = ""
        SUBTOTAL = 0 : DES_TOT = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : MAN_IEPS = "" : APL_MAN_IEPS = ""

        For k = 1 To Fg.Rows.Count - 1

            For w = 1 To 5
                If Valida_Conexion() Then
                    Exit For
                End If
            Next

            Try
                CANT = Fg(k, 1)
                If ALMACEN = 0 Then ALMACEN = 1
                CVE_ART = Fg(k, 3)

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

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                'COST = dr2("ULTCOSTO")
                                COST = 0 'Math.Round(COST, 2)
                                COSTO_PROM = dr2("COSTOPROM").ToString
                                IMPU1 = dr2("IMPU1")
                                IMPU2 = dr2("IMPU2")
                                IMPU3 = dr2("IMPU3")
                                IMPU4 = dr2("IMPU4")
                                IMP1APLA = dr2("IMP1APLA")
                                IMP2APLA = dr2("IMP2APLA")
                                IMP3APLA = dr2("IMP3APLA")
                                IMP4APLA = dr2("IMP4APLA")
                                CVE_ESQ = dr2("CVE_ESQIMPU")
                                UNI_MED = dr2("UNI_MED")
                                Select Case dr2("TIP_ELE")
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
                    DESC1 = 0
                    'PRECIO = Fg(k, 5)
                    PREC = 0 'PRECIO
                    DESC2 = 0 : DESC3 = 0

                    SUBTOTAL += CANT * PREC
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
                    'If Fg(k, 22).ToString.Trim.Length > 0 Then
                    'CVE_OBS = Val(Fg(k, 21))
                    'CVE_OBS = INSERT_UPDATE_OBS_FAC(CVE_OBS, Fg(k, 22))
                    'CVE_OBS = INSERT_UPDATE_OBS_FAC(Val(Fg(k, 21)), Fg(k, 22))
                    '            End If
                Catch ex As Exception
                    BITACORATPV("765. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM CFDI_CPT_PAR WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                        INSERT INTO CFDI_CPT_PAR (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1,
                        IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2,
                        DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD,
                        TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC,
                        MTO_CUOTA, DESCR_ART, CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & CVE_ART & "','" & CANT & "','" &
                        CANT & "','" & PREC & "','" & COST & "','" & IMPU1 & "','" & IMPU2 & "','" & IMPU3 & "','" & IMPU4 & "','" &
                        IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" & TOTIMP1 & "','" & TOTIMP2 & "','" &
                        TOTIMP3 & "','" & TOTIMP4 & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" &
                        ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" &
                        CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','0','" & TOT_PARTIDA & "','S',GETDATE(),'" &
                        MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" &
                        "" & "','" & CVE_ESQ & "',NEWID())"
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
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      
                    NUM_PAR += 1
                Catch ex As Exception
                    BITACORATPV("765. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If 'CANT >0
        Next
        'FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  FIN  FIN  FIN  FIN  FIN  

        Try
            SQL = "UPDATE movs SET docto = '" & CVE_DOC & "', pag = 'S' WHERE succamion = '" & TFOLIO_TEA.Text & "'"
            Using cmd2 As SqlCommand = cnSQL.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            BITACORATPV("765. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        GRABA_BITA("", CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, " Carta porte traslado ", CVE_DOC)

        PassData1 = "CARTA PORTE TRASLADO"
        Var4 = CVE_DOC
        Var5 = ""
        Var18 = ""
        Var16 = ""

        '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
        ' INICA PROCESO DE TIMBRAR 
        FrmTimbrarCdeP.LtNombre.Text = EMISOR_RAZON_SOCIAL
        FrmTimbrarCdeP.LtRFC.Text = RFC_EMISOR
        FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
        FrmTimbrarCdeP.LtRegimenReceptor.Text = "06"
        FrmTimbrarCdeP.LtCP.Text = CP_SAT

        FrmTimbrarCdeP.ShowDialog()

        Me.Close()

        If Var18 = "SI" Then
            FILE_PDF = Var16
            If File.Exists(Var16) Then
                CTA_PORT1 = CVE_DOC
                FrmOPenPDFGrapecity.Show()
            End If
        End If
        'TFOLIO_TEA.Enabled = True
        'BtnTEA.Enabled = True
        'TCVE_TRACTOR.Enabled = True
        'LtTractor.Enabled = True
        'TCVE_OPER.Enabled = True
        'LtOper.Enabled = True


    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Try
            If Not DOC_NEW Then
                If Fg.Row > 0 Then
                    IMPRIMIR_CFDI_40(LtCVE_DOC.Text, "CARTA PORTE TRASLADO")
                Else
                    MsgBox("Por favor seleccione el documento a timbrar")
                End If
            Else
                MsgBox("Por favor primero genere la carta porte traslado")
            End If
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var5
                'LtPlaca1.Text = Var8
                'LtMarca1.Text = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub BtnTractor_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnTractor.KeyDown

    End Sub
    Private Sub BtnTractor_Validated(sender As Object, e As EventArgs) Handles BtnTractor.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                    'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                    'Var6 = dr.ReadNullAsEmptyString("DES").ToString'
                    'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                    'Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString
                    Var3 = ""
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Text = ""
                    LtTractor.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LtOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_TRACTOR.Focus()
            Else
                TCVE_OPER.Text = ""
                LtOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String, OPER As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    OPER = ""
                    LtOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_TRACTOR.Focus()
                Else
                    MsgBox("Operador inexistente")
                    LtOper.Text = ""
                    TCVE_OPER.Text = ""
                End If
            Else
                LtOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTEA_Click(sender As Object, e As EventArgs) Handles BtnTEA.Click
        Try
            Var2 = "Folios TEA"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItemTEA.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TFOLIO_TEA.Text = Var4
                LtSucOrigen.Text = Var5
                LtSucDestino.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""

                BUSCAR_FOLIO_TEA(TFOLIO_TEA.Text)

                TCVE_TRACTOR.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TFOLIO_TEA_KeyDown(sender As Object, e As KeyEventArgs) Handles TFOLIO_TEA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TFOLIO_TEA_Validated(sender As Object, e As EventArgs) Handles TFOLIO_TEA.Validated
        Try
            If TFOLIO_TEA.Text.Length > 0 Then

                If Fg.Rows.Count > 1 Then
                    If MsgBox("Desea volver a cargar nuevamente las partidas", vbYesNo) = vbYes Then
                        BUSCAR_FOLIO_TEA(TFOLIO_TEA.Text)
                    End If
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub BtnConfigVehicular_Click(sender As Object, e As EventArgs) Handles BtnConfigVehicular.Click
        Try
            Var2 = "ConfigVehicular"
            Var4 = "" : Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TConfigVehicular.Text = Var4
                LTConfigVehicular.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                CboTransInter.Focus()
            Else
                TConfigVehicular.Text = ""
                LTConfigVehicular.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TConfigVehicular_KeyDown(sender As Object, e As KeyEventArgs) Handles TConfigVehicular.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnConfigVehicular_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TConfigVehicular_Validated(sender As Object, e As EventArgs) Handles TConfigVehicular.Validated
        Try
            Dim DESCR As String
            If TConfigVehicular.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT2("ConfigVehicular", TConfigVehicular.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LTConfigVehicular.Text = DESCR
                Else
                    MsgBox("Unidad inexistente")
                    TConfigVehicular.Text = ""
                    LTConfigVehicular.Text = ""
                End If
            Else
                LTConfigVehicular.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click


        Try

            Var2 = LtCVE_DOC.Text ' Fg(Fg.Row, 2) 'FACTURA
            Var3 = "N"  'CATA PORTE 1
            Var4 = "N"  'CATA PORTE 2
            Var6 = "FCPT"  'FACTURA CARTA PORTE TRASLADO
            Var10 = "4.0" 'VERSION

            Var5 = ""

            FrmCFDICancFAC.ShowDialog()
            If Var5 = "ok" Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        EXPORTAR_EXCEL_TRANSPORT(Fg, "Carta porter traslado " & LtCVE_DOC.Text)
    End Sub
End Class