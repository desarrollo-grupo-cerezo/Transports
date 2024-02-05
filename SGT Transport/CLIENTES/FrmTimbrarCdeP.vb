Imports Stimulsoft.Report
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports System.ServiceModel

Public Class FrmTimbrarCdeP
    Private _comprobante As Comprobante
    Private _DocumentosRelacionados As List(Of PDoctoRelacionado)
    Public _cartaPorte As CartaPorte
    Public _ComercioExterior As ComercioExterior
    Private _retencionesDR As RetencionesDR
    Private Mat_peligroso As String = ""
    Private _impuestosDR As List(Of ImpuestosDR)
    Private _TrasladosDR As List(Of TrasladosDR)
    Private _ImpuestosP As List(Of ImpuestosP)
    Private _Destinatario As List(Of CCE11Destinario)
    Private _mercancia As List(Of CCE11Mercancia) = New List(Of CCE11Mercancia)()
    Public Mercancia As List(Of CCE11Mercancia) = New List(Of CCE11Mercancia)()

    Private _descripcionesEspecificas As List(Of CCE11DescripcionesEspecificas)


    Private TIMBRADO_OK As Boolean = False
    Private ADDENDA_CE As Integer = 0
    Private UsoCFD As String, CVE_DOC As String, RUTA_XML As String, RUTA_PDF As String, EMISOR_RAZON_SOCIAL As String = "", EMISOR_LUGAR_EXPEDICION As String = ""
    Private EMISOR_REGIMEN_FISCAL As String = "", EmisorRfcCFD As String, SerieCFD As String, FolioCFD As String, FechaEmision As String
    Private TotalCFD As Decimal, SubtotalCFD As Decimal, IVAcfd As Decimal, RETcfd As Decimal, VersionCFD As String, MonedaCFD As String
    Private FormaPagoCFD As String, UsoCFDICFD As String, TipoComprobanteCFD As String
    Private TIMBRADO_DEMO As String = "No", gUSUARIO_PAC As String, gPASS_PAC As String, EMISOR_RFC As String
    Private PolizaMedAmbiente As String, AseguraMedAmbiente As String, CP_POLIZAMEDAMBIENTE As String, CP_ASEGURAMEDAMBIENTE As String
    Private TCALLE As String, TNUMEXT As String, TNUMINT As String, TCP As String

    Private TCOLONIA_SAT As String, TLOCALIDAD_SAT As String, TMUNICIPIO_SAT As String
    Private TCOLONIA As String, TLOCALIDAD As String, TMUNICIPIO As String
    Private TESTADO As String, TPAIS As String, PERMSCT As String, NUMPERMISOSCT As String, TREFERENCIA As String
    Private PlacaVM As String, ConfigVehicular As String, PolizaRespCivil As String = "", AseguraRespCivil As String = ""
    Private Tanque1 As String = "", Placa1 As String, SubTipoRem1 As String
    Private Tanque2 As String = "", Placa2 As String, SubTipoRem2 As String
    Private AnioModeloVM As Integer, AnioModelo1 As String, AnioModelo2 As String
    Private NombreOrigen As String, RFCOrigen As String, CalleOrigen As String
    Private MunicipioOrigen As String, NumIntOrigen As String, NumExtOrigen As String, ColoniaOrigen As String, CPOrigen As String
    Private LocalidadOrigen As String, MunicOrigen As String, EstadoOrigen As String, PaisOrigen As String, NombreDestino As String
    Private RFCDestino As String, CalleDestino As String, MunicDest As String, NumIntDestino As String, NumExtDestino As String
    Private ColoniaDestino As String, CPDestino As String, LocalidadDestino As String, MunicipioDestino As String, EstadoDestino As String
    Private PaisDestino As String, NombreOper As String, RFCOper As String, LicenciaOper As String, Municipio As String, CalleOper As String
    Private NumIntOper As String, NumExtOper As String, ColoniaOper As String, CPOper As String, LocalidadOper As String, MunicipioOper As String
    Private EstadoOper As String, PaisOper As String
    Private CVE_DOC_GC As String, QUITAR_MAT_PELI As Boolean = False

    Private c_ As Integer

    Private Sub FrmTimbrarCdeP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        Select Case PassData1
            Case "PAGO COMPLEMENTO"
                Me.Text = "Timbrar complemento de pago"
                Lt1.Text = "TIMBRANDO COMPLEMENTO DE PAGO 4.0"
            Case "FACTURA"
                Me.Text = "Timbrado factura"
                Lt1.Text = "TIMBRANDO FACTURA 4.0"
            Case "CARTA PORTE TRASLADO"
                Me.Text = "Timbrado carta porte traslado"
                Lt1.Text = "TIMBRANDO CARTA PORTE TRASLADO 4.0"
            Case "FACTURA GLOBAL"
                Me.Text = "Timbrado factura global"
                Lt1.Text = "TIMBRANDO FACTURA GLOBAL FACTURA 4.0"
            Case "CARTA PORTE BUENO"
                Me.Text = "Timbrado carta porte"
                Lt1.Text = "TIMBRANDO CARTA PORTE 4.0"
        End Select

        EMISOR_RAZON_SOCIAL = ""
        EMISOR_RFC = ""
        EMISOR_LUGAR_EXPEDICION = ""
        EMISOR_REGIMEN_FISCAL = ""
        gRutaXML_NO_TIMBRADO = ""
        gRutaXML_TIMBRADO = ""
        gRutaXML_TIMBRADO_CON_PRECIOS = ""
        gRutaCertificado = ""
        gRutaPFX = ""
        gContraPFX = ""
        Var2 = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then


                        'USUARIO PAC DIGIBOX
                        gUSUARIO_PAC = dr.ReadNullAsEmptyString("USUARIO")
                        'CONTRASENA PAC DIGIBOX
                        gPASS_PAC = Desencriptar(dr.ReadNullAsEmptyString("PASS"))

                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                            TIMBRADO_SAT = "No"
                            Lt2.Text = "Timbrado SAT"
                        Else
                            TIMBRADO_DEMO = "Si"
                            TIMBRADO_SAT = "Si"
                            Lt2.Text = "Timbrado DEMO"
                        End If

                        EMISOR_RAZON_SOCIAL = dr.ReadNullAsEmptyString("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr.ReadNullAsEmptyString("EMISOR_RFC")
                        EMISOR_LUGAR_EXPEDICION = dr.ReadNullAsEmptyString("EMISOR_LUGAR_EXPEDICION")
                        EMISOR_REGIMEN_FISCAL = dr.ReadNullAsEmptyString("EMISOR_REGIMEN_FISCAL")
                        gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                        gRutaXML_TIMBRADO_CON_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")

                        gRutaCertificado = dr.ReadNullAsEmptyString("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr.ReadNullAsEmptyString("FILE_PFX").ToString '.KEY
                        'CONTRASENA SELLO SAT SAT ENDEJO   PASS_PFX
                        gContraPFX = Desencriptar(dr.ReadNullAsEmptyString("PASS_PFX").ToString)  'contrasena del certificado

                        '=============================
                        TCALLE = dr.ReadNullAsEmptyString("CALLE")
                        TNUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                        TNUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        TCP = dr.ReadNullAsEmptyString("CP")

                        TCOLONIA_SAT = dr.ReadNullAsEmptyString("COLONIA")
                        TLOCALIDAD_SAT = dr.ReadNullAsEmptyString("LOCALIDAD")
                        TMUNICIPIO_SAT = dr.ReadNullAsEmptyString("MUNICIPIO")

                        TCOLONIA = dr.ReadNullAsEmptyString("COLONIA_NOSAT")
                        TLOCALIDAD = dr.ReadNullAsEmptyString("LOCALIDAD_NOSAT")
                        TMUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO_NOSAT")

                        PassData6 = TCALLE & ", Num. ext. " & TNUMEXT & ", CP " & TCP

                        TESTADO = dr.ReadNullAsEmptyString("ESTADO")
                        TPAIS = dr.ReadNullAsEmptyString("PAIS")
                        TREFERENCIA = dr.ReadNullAsEmptyString("REFERENCIA")

                        PERMSCT = dr.ReadNullAsEmptyString("PERMSCT")
                        NUMPERMISOSCT = dr.ReadNullAsEmptyString("NUMPERMISOSCT")

                        CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")

                        '==============================
                        LtRegimenEmisor.Text = EMISOR_REGIMEN_FISCAL

                        PolizaMedAmbiente = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        AseguraMedAmbiente = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                        CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                        ADDENDA_CE = dr.ReadNullAsEmptyInteger("ADDENDA_CE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
        End Try
        ChEnviarXCorreo.Visible = False
        ChImprimir.Visible = False
        BtnAceptar.Visible = False
        BtnCancelar.Visible = False

        CVE_DOC = Var4
        LtCVE_DOC.Text = CVE_DOC
        TCORREO_CTE.Text = Var5



        Timer1.Start()

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Application.DoEvents()

            Timer1.Enabled = False

            Select Case PassData1
                Case "PAGO COMPLEMENTO"
                    PROCESO_TIMBRE_CP()
                Case "FACTURA"
                    PROCESO_CFD_FACTURA_40()
                Case "CARTA PORTE TRASLADO"
                    PROCESO_CFD_CARTA_PORTE_TRASLADO_40()
                Case "FACTURA GLOBAL"
                    PROCESO_CFD_FACTURA_GLOBAL()
                Case "CARTA PORTE BUENO"

                    QUITAR_MAT_PELI = False

                    PROCESO_CFD_CARTA_PORTE_BUENO_40()

                    If Not TIMBRADO_OK Then
                        If MsgBox("Reintentar timbrado?", vbYesNo) = vbYes Then
                            QUITAR_MAT_PELI = True
                            PROCESO_CFD_CARTA_PORTE_BUENO_40()
                        End If
                    End If
            End Select
        Catch ex As Exception
            BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub PROCESO_CFD_CARTA_PORTE_TRASLADO_40()
        Dim Descripcion As String = "", ClaveUnidad As String = "", Cantidad As Decimal, PesoEnKg As Decimal, DescripEmbalaje As String = ""
        Dim EMBALAJE As String = "", CveMaterialPeligroso As String = "", MaterialPeligroso As String = "", BienesTransp As String = ""
        Dim ClaveProdServ As String = "", Precio As Decimal, NoIdentificacion As String = "", KMRECORRIDOS As Decimal = 0
        Dim MetodoPago As String, FormaPago As String, MONEDA As String, USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim CVE_BITA As Long, UUID_TIMBRADO As String, FECHA_T1 As DateTime, FECHA_T2 As String = Now
        Dim CVE_CLIE As String = "", NOMBRE As String = "", USO_CFDI As String = "", REG_FISC As String = "", RFC_RECEP As String = ""
        Dim CP_RECEP As String = "", CALLE As String, DETEC_ERROR_VIOLATION_KEY As Boolean = False

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(CVE_CLIE ,'') AS CLIENTE FROM CFDI_SERIES"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_CLIE = dr("CLIENTE")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            If CVE_CLIE.Trim.Length = 0 Then
                MsgBox("Por favor capture el cliente en parametros CFDI")
                Return
            End If

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(NOMBRE,'') AS NOMB, ISNULL(USO_CFDI,'') AS USOCFDI, ISNULL(REG_FISC,'') AS REGFISC,
                        RFC, CODIGO AS CP, CALLE
                        FROM CLIE" & Empresa & " WHERE CLAVE = '" & CVE_CLIE & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            NOMBRE = dr("NOMB")
                            USO_CFDI = dr("USOCFDI")
                            REG_FISC = dr("REGFISC")
                            RFC_RECEP = dr("RFC")
                            CP_RECEP = dr("CP")
                            CALLE = dr("CALLE")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            If NOMBRE.Trim.Length = 0 Or USO_CFDI.Trim.Length = 0 Or REG_FISC.Trim.Length = 0 Then
                MsgBox("Por favor verifique los datos NOMBRE, USO_CFDI, REG_FISC del cliente " & CVE_CLIE)
                Return
            End If
            Me.Cursor = Cursors.WaitCursor

            CP_OBSER_CFDI = ""

            RefreshDataBindings() 'SERIE Y FOLIO

            CPConceptoAgregar() 'CONCEPTOS DATOS DEL ARTICULO

            GetCamposCombox(USO_CFDI, NOMBRE, RFC_RECEP, CP_RECEP, REG_FISC, "T") 'DATOS EMISOR Y RECEPTOR

            Datos_carta_porte()

            Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & CVE_DOC & ".xml"
            Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & CVE_DOC & ".xml"

            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\XML_BAK") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\XML_BAK")
                End If
                XML_BK = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".xml"
            Catch ex As Exception
            End Try

            Dim rutaPFX As String = gRutaPFX
            Dim rutaCertificado As String = gRutaCertificado

            Dim rutaPDF As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".pdf"
            Dim rutaPDF2 As String = gRutaXML_TIMBRADO_SIN_PRECIOS & "\" & CVE_DOC & ".pdf"

            Dim errorC As CError = _comprobante.EsInfoCorrecta()

            If TIMBRADO_DEMO = "Si" Then
                USUAARIO_TIMB = "demo2"
                PASS_TIMB = "123456789"
            Else
                USUAARIO_TIMB = gUSUARIO_PAC
                PASS_TIMB = gPASS_PAC
            End If
            CFDI_XML_DIGIBOX = ""
            If Not errorC.HayError Then
                ' Asi se agregaria la addenda al comprobante
                If Not IO.File.Exists(rutaPFX) Then
                    MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
                    Return
                End If
                If Not IO.File.Exists(rutaCertificado) Then
                    MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                    Return
                End If
                Var46 = "" 'NOCERTIFICADO
                CFDI_XML_DIGIBOX = ""
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_CON_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_SIN_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                Dim xml As XmlDocument = GenerarXML.ObtenerXML(_comprobante, rutaPFX, gContraPFX, rutaCertificado)
                xml.Save(RutaXML_NO_TIMBRADO)

                'GenerarXML.GuardarXML(_c, RutaXML_NO_TIMBRADO, rutaPFX, gContraPFX, rutaCertificado)

                If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
                    TimbreOK = True

                    MsgBox("Documento timbrado")

                Else
                    MsgBox("------------------  Documento no timbrado  ------------------")
                End If
            Else
                MessageBox.Show(errorC.Error, "Validando información...")
            End If
            Try
                If TimbreOK Then
                    Dim MensaDia As String = ""

                    RUTA_XML = RutaXML_TIMBRADO
                    RUTA_PDF = rutaPDF

                    If Not Valida_Conexion() Then
                    End If

                    BACKUPTXT("CFDICP", CVE_DOC & "," & CVE_DOC & "," & CVE_DOC & "," & Now & "," & CFDI_XML_DIGIBOX & ",S," & USER_GRUPOCE)
                    BACKUPTXT("CFDICP", vbNewLine & "-----------------------------------------------------------------------------------------------" & vbNewLine)

                    MetodoPago = ""
                    FormaPago = ""
                    MONEDA = "XXX"

                    Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = "" : Var12 = "" : Var13 = "" : Var14 = "" : Var15 = ""
                    UUID_TIMBRADO = BUSCAR_CAMPOS_CFDI40(RutaXML_TIMBRADO)
                    Try
                        Var7 = Var10.Substring(8, 2) & "/" & Var10.Substring(5, 2) & "/" & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
                        Var8 = Var10.Substring(0, 4) & Var10.Substring(5, 2) & Var10.Substring(8, 2) & " " & Var10.Substring(11, Var10.Length - 11)
                        Dim oDate1 As DateTime = DateTime.ParseExact(Var7, "dd/MM/yyyy HH:mm:ss", Nothing)

                        FECHA_T1 = oDate1
                        FECHA_T2 = Var8

                    Catch ex As Exception
                        MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    If Var10.Trim.Length < 10 Then
                        FECHA_T2 = Now
                    End If
                    'Var9 = NO_CERTIFICADO
                    'Var10 = FECHA_TIMBRADO
                    'Var11 = FECHA_EXP
                    'Var12 = SELLO_SAT
                    'Var13 = NO_CERTIFICADO_SAT
                    'Var14 = SELLO_CFD
                    'Var15 = RfcProvCertif
                    SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                        CLIENTE,SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID, 
                        NO_CERTIFICADO, SELLO_SAT, SELLO_CFD, NO_CERTIFICADO_SAT, RFCPROVCERTIF, UUID_CFDI, FECHA_TIMBRADO, FECHA_CFDI) 
                        VALUES (
                        @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                        @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID(), 
                        @NO_CERTIFICADO, @SELLO_SAT, @SELLO_CFD, @NO_CERTIFICADO_SAT, @RFCPROVCERTIF, @UUID_CFDI, @FECHA_TIMBRADO, @FECHA_CFDI)"
                    For k = 1 To 5
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = CVE_DOC
                                cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "T"
                                cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = GET_ONLY_LETTER(CVE_DOC)
                                cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Var10
                                cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                                cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CVE_CLIE
                                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = MetodoPago
                                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FormaPago
                                cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                                cmd.Parameters.Add("@NO_CERTIFICADO", SqlDbType.VarChar).Value = Var9
                                cmd.Parameters.Add("@SELLO_SAT", SqlDbType.VarChar).Value = Var12 'mal
                                cmd.Parameters.Add("@SELLO_CFD", SqlDbType.VarChar).Value = Var14
                                cmd.Parameters.Add("@NO_CERTIFICADO_SAT", SqlDbType.VarChar).Value = Var13
                                cmd.Parameters.Add("@RFCPROVCERTIF", SqlDbType.VarChar).Value = Var15
                                cmd.Parameters.Add("@UUID_CFDI", SqlDbType.VarChar).Value = UUID_TIMBRADO
                                cmd.Parameters.Add("@FECHA_TIMBRADO", SqlDbType.VarChar).Value = Var10
                                cmd.Parameters.Add("@FECHA_CFDI", SqlDbType.DateTime).Value = FECHA_T1
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
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
                            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try

                        If Not Valida_Conexion() Then
                        End If

                    Next

                    'GRBADO DE DATOS XML EN TABLA
                    '███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                    Try
                        KMRECORRIDOS = 0
                    Catch ex As Exception
                        BITACORACFDI("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM CFDI_CONC_LV WHERE CVE_DOC = @CVE_DOC)
                        BEGIN
                            INSERT INTO CFDI_CONC_LV (CVE_DOC, STATUS, CARTA_PORTE1, CARTA_PORTE2, SERIE, FOLIO, FECHA, XML, FILE_XML, TIMBRADO, USUARIO, CLIENTE,
                            NOMBRE, RFC, USO_CFDI, TRANS_INTER, KM_RECORRI, UNIDAD_PESO, FECHA_CARGA, FECHA_DESCARGA, PERMISO_SCT, ANO_MODELO, PLACA_VM,
                            NUM_PER_SCT, CONFIG_VEHI, POLIZA_MED_AMB, ASEG_MED_AMB, POL_RESP_CIVIL, ASEG_RESP_CIVIL, TANQUE1, T1_PLACA, T1_SUB_TIPO_REM, TANQUE2,
                            T2_PLACA, T2_SUB_TIPO_REM, O_NOMBRE, O_RFC, O_CALLE, O_MUNICIPIO, O_NUM_INT, O_NUM_EXT, O_COL, O_CP, O_LOC, O_MUN, O_EST, O_PAIS,
                            D_NOMBRE, D_RFC, D_CALLE, D_MUNICIPIO, D_NUM_INT, D_NUM_EXT, D_COL, D_CP, D_LOC, D_MUN, D_EST, D_PAIS, OP_NOMBRE, OP_RFC, OP_LIC,
                            OP_MUNICIPIO, OP_CALLE, OP_NUM_INT, OP_NUM_EXT, OP_COL, OP_CP, OP_LOC, OP_MUN, OP_EST, OP_PAIS, SUBTOTAL, RET, IVA, IMPORTE,
                            METODODEPAGO, FORMADEPAGOSAT, MONEDA) 
                            VALUES (
                            @CVE_DOC, 'E', @CARTA_PORTE1, @CARTA_PORTE2, @SERIE, @FOLIO, @FECHA, @XML, @FILE_XML, @TIMBRADO, @USUARIO, @CLIENTE, @NOMBRE, 
                            @RFC, @USO_CFDI, @TRANS_INTER, @KM_RECORRI, @UNIDAD_PESO, @FECHA_CARGA, @FECHA_DESCARGA, @PERMISO_SCT, @ANO_MODELO, @PLACA_VM, 
                            @NUM_PER_SCT, @CONFIG_VEHI, @POLIZA_MED_AMB, @ASEG_MED_AMB, @POL_RESP_CIVIL, @ASEG_RESP_CIVIL, @TANQUE1, @T1_PLACA, 
                            @T1_SUB_TIPO_REM, @TANQUE2, @T2_PLACA, @T2_SUB_TIPO_REM, @O_NOMBRE, @O_RFC, @O_CALLE, @O_MUNICIPIO, @O_NUM_INT, @O_NUM_EXT, 
                            @O_COL, @O_CP, @O_LOC, @O_MUN, @O_EST, @O_PAIS, @D_NOMBRE, @D_RFC, @D_CALLE, @D_MUNICIPIO, @D_NUM_INT, @D_NUM_EXT, @D_COL, 
                            @D_CP, @D_LOC, @D_MUN, @D_EST, @D_PAIS, @OP_NOMBRE, @OP_RFC, @OP_LIC, @OP_MUNICIPIO, @OP_CALLE, @OP_NUM_INT, @OP_NUM_EXT,
                            @OP_COL, @OP_CP, @OP_LOC, @OP_MUN, @OP_EST, @OP_PAIS, @SUBTOTAL, @RET, @IVA, @IMPORTE, @METODODEPAGO, @FORMADEPAGOSAT, @MONEDA)
                        END"

                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@CARTA_PORTE1", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@CARTA_PORTE2", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = GET_ONLY_LETTER(CVE_DOC)
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = GetNumeric(CVE_DOC)
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = Var8
                            cmd.Parameters.Add("@FILE_XML", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "Si"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CVE_CLIE
                            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE
                            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RFC_RECEP
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@TRANS_INTER", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@KM_RECORRI", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@UNIDAD_PESO", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = Now
                            cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = Now
                            cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = PERMSCT
                            cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = AnioModeloVM
                            cmd.Parameters.Add("@PLACA_VM", SqlDbType.VarChar).Value = PlacaVM
                            cmd.Parameters.Add("@NUM_PER_SCT", SqlDbType.VarChar).Value = NUMPERMISOSCT
                            cmd.Parameters.Add("@CONFIG_VEHI", SqlDbType.VarChar).Value = ConfigVehicular
                            cmd.Parameters.Add("@POLIZA_MED_AMB", SqlDbType.VarChar).Value = PolizaMedAmbiente
                            cmd.Parameters.Add("@ASEG_MED_AMB", SqlDbType.VarChar).Value = AseguraMedAmbiente
                            cmd.Parameters.Add("@POL_RESP_CIVIL", SqlDbType.VarChar).Value = PolizaRespCivil
                            cmd.Parameters.Add("@ASEG_RESP_CIVIL", SqlDbType.VarChar).Value = AseguraRespCivil
                            cmd.Parameters.Add("@TANQUE1", SqlDbType.VarChar).Value = Tanque1
                            cmd.Parameters.Add("@T1_PLACA", SqlDbType.VarChar).Value = Placa1
                            cmd.Parameters.Add("@T1_SUB_TIPO_REM", SqlDbType.VarChar).Value = SubTipoRem1
                            cmd.Parameters.Add("@TANQUE2", SqlDbType.VarChar).Value = Tanque2
                            cmd.Parameters.Add("@T2_PLACA", SqlDbType.VarChar).Value = Placa2
                            cmd.Parameters.Add("@T2_SUB_TIPO_REM", SqlDbType.VarChar).Value = SubTipoRem2
                            cmd.Parameters.Add("@O_NOMBRE", SqlDbType.VarChar).Value = NombreOrigen
                            cmd.Parameters.Add("@O_RFC", SqlDbType.VarChar).Value = RFCOrigen
                            cmd.Parameters.Add("@O_CALLE", SqlDbType.VarChar).Value = CalleOrigen
                            cmd.Parameters.Add("@O_MUNICIPIO", SqlDbType.VarChar).Value = MunicipioOrigen
                            cmd.Parameters.Add("@O_NUM_INT", SqlDbType.VarChar).Value = NumIntOrigen
                            cmd.Parameters.Add("@O_NUM_EXT", SqlDbType.VarChar).Value = NumExtOrigen
                            cmd.Parameters.Add("@O_COL", SqlDbType.VarChar).Value = ColoniaOrigen
                            cmd.Parameters.Add("@O_CP", SqlDbType.VarChar).Value = CPOrigen
                            cmd.Parameters.Add("@O_LOC", SqlDbType.VarChar).Value = LocalidadOrigen
                            cmd.Parameters.Add("@O_MUN", SqlDbType.VarChar).Value = MunicOrigen
                            cmd.Parameters.Add("@O_EST", SqlDbType.VarChar).Value = EstadoOrigen
                            cmd.Parameters.Add("@O_PAIS", SqlDbType.VarChar).Value = PaisOrigen
                            cmd.Parameters.Add("@D_NOMBRE", SqlDbType.VarChar).Value = NombreDestino
                            cmd.Parameters.Add("@D_RFC", SqlDbType.VarChar).Value = RFCDestino
                            cmd.Parameters.Add("@D_CALLE", SqlDbType.VarChar).Value = CalleDestino
                            cmd.Parameters.Add("@D_MUNICIPIO", SqlDbType.VarChar).Value = MunicDest
                            cmd.Parameters.Add("@D_NUM_INT", SqlDbType.VarChar).Value = NumIntDestino
                            cmd.Parameters.Add("@D_NUM_EXT", SqlDbType.VarChar).Value = NumExtDestino
                            cmd.Parameters.Add("@D_COL", SqlDbType.VarChar).Value = ColoniaDestino
                            cmd.Parameters.Add("@D_CP", SqlDbType.VarChar).Value = CPDestino
                            cmd.Parameters.Add("@D_LOC", SqlDbType.VarChar).Value = LocalidadDestino
                            cmd.Parameters.Add("@D_MUN", SqlDbType.VarChar).Value = MunicipioDestino
                            cmd.Parameters.Add("@D_EST", SqlDbType.VarChar).Value = EstadoDestino
                            cmd.Parameters.Add("@D_PAIS", SqlDbType.VarChar).Value = PaisDestino
                            cmd.Parameters.Add("@OP_NOMBRE", SqlDbType.VarChar).Value = NombreOper
                            cmd.Parameters.Add("@OP_RFC", SqlDbType.VarChar).Value = RFCOper
                            cmd.Parameters.Add("@OP_LIC", SqlDbType.VarChar).Value = LicenciaOper
                            cmd.Parameters.Add("@OP_MUNICIPIO", SqlDbType.VarChar).Value = Municipio
                            cmd.Parameters.Add("@OP_CALLE", SqlDbType.VarChar).Value = CalleOper
                            cmd.Parameters.Add("@OP_NUM_INT", SqlDbType.VarChar).Value = NumIntOper
                            cmd.Parameters.Add("@OP_NUM_EXT", SqlDbType.VarChar).Value = NumExtOper
                            cmd.Parameters.Add("@OP_COL", SqlDbType.VarChar).Value = ColoniaOper
                            cmd.Parameters.Add("@OP_CP", SqlDbType.VarChar).Value = CPOper
                            cmd.Parameters.Add("@OP_LOC", SqlDbType.VarChar).Value = LocalidadOper
                            cmd.Parameters.Add("@OP_MUN", SqlDbType.VarChar).Value = MunicipioOper
                            cmd.Parameters.Add("@OP_EST", SqlDbType.VarChar).Value = EstadoOper
                            cmd.Parameters.Add("@OP_PAIS", SqlDbType.VarChar).Value = PaisOper
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@RET", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = 0
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = 0

                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = MetodoPago
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FormaPago
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    'GRABAR PARTIDAS

                                    Try
                                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "SELECT I.DESCR, I.CVE_ART, P.CANT, P.PREC, P.UNI_VENTA, I.PESO, I.CVE_PRODSERV, I.CVE_UNIDAD,
                                                MAT_PELIGROSO, CVE_MAT_PELIGROSO, EMBALAJE, UNIDADPESO, BIENESTRANSP
                                                FROM CFDI_CPT_PAR P
                                                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                                                LEFT JOIN INVE_CP CP ON CP.CVE_ART = P.CVE_ART
                                                WHERE CVE_DOC = '" & CVE_DOC & "'"
                                            cmd3.CommandText = SQL
                                            Using dr As SqlDataReader = cmd3.ExecuteReader
                                                While dr.Read
                                                    Try
                                                        NoIdentificacion = dr("CVE_ART")
                                                        Descripcion = dr("DESCR")
                                                        ClaveUnidad = dr("UNI_VENTA")
                                                        Cantidad = dr("CANT")
                                                        Precio = dr("PREC")
                                                        PesoEnKg = dr.ReadNullAsEmptyDecimal("PESO")
                                                        ClaveProdServ = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                                        ClaveUnidad = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                                                        BienesTransp = dr.ReadNullAsEmptyString("BIENESTRANSP")
                                                        MaterialPeligroso = dr.ReadNullAsEmptyString("MAT_PELIGROSO")
                                                        CveMaterialPeligroso = dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO")
                                                        EMBALAJE = dr.ReadNullAsEmptyString("EMBALAJE")
                                                        DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))

                                                        If NoIdentificacion.Trim.Length > 0 And Cantidad > 0 And PesoEnKg > 0 And BienesTransp.Trim.Length > 0 Then
                                                            If Not Valida_Conexion() Then
                                                            End If

                                                            SQL = "SET ansi_warnings OFF
                                                                INSERT INTO CFDI_CONC_LV_PAR (CVE_DOC, NUM_PAR, CVE_ART, DESCR, CANT, PRECIO, PESO_ENKG,
                                                                CVE_PRODSERV, CVE_UNIDAD, BIENES_TRANSP, MAT_PELIGROSO, CVE_MAT_PEL, EMBALAJE, DESCR_EMBALAJE) 
                                                                VALUES(@CVE_DOC, ISNULL((SELECT ISNULL(MAX(NUM_PAR),0) + 1 FROM CFDI_CONC_LV_PAR),1), @CVE_ART,
                                                                @DESCR, @CANT, @PRECIO, @PESO_ENKG, @CVE_PRODSERV, @CVE_UNIDAD, @BIENES_TRANSP, @MAT_PELIGROSO,
                                                                @CVE_MAT_PEL, @EMBALAJE, @DESCR_EMBALAJE)"
                                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                                cmd2.CommandText = SQL
                                                                cmd2.Parameters.Clear()
                                                                cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                                                cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = NoIdentificacion
                                                                cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = Descripcion
                                                                cmd2.Parameters.Add("@CANT", SqlDbType.Float).Value = Cantidad
                                                                cmd2.Parameters.Add("@PRECIO", SqlDbType.Float).Value = Precio
                                                                cmd2.Parameters.Add("@PESO_ENKG", SqlDbType.Float).Value = PesoEnKg
                                                                cmd2.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = ClaveProdServ
                                                                cmd2.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = ClaveUnidad
                                                                cmd2.Parameters.Add("@BIENES_TRANSP", SqlDbType.VarChar).Value = BienesTransp
                                                                cmd2.Parameters.Add("@MAT_PELIGROSO", SqlDbType.VarChar).Value = MaterialPeligroso
                                                                cmd2.Parameters.Add("@CVE_MAT_PEL", SqlDbType.VarChar).Value = CveMaterialPeligroso
                                                                cmd2.Parameters.Add("@EMBALAJE", SqlDbType.VarChar).Value = EMBALAJE
                                                                cmd2.Parameters.Add("@DESCR_EMBALAJE", SqlDbType.VarChar).Value = DescripEmbalaje
                                                                returnValue = cmd2.ExecuteNonQuery().ToString
                                                                If returnValue IsNot Nothing Then
                                                                    If returnValue = "1" Then
                                                                    End If
                                                                End If
                                                            End Using
                                                        End If
                                                    Catch ex As Exception
                                                        BITACORACFDI("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                                    End Try
                                                End While
                                            End Using
                                        End Using
                                    Catch ex As Exception
                                        BITACORACFDI("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    Var8 = ""

                    CVE_BITA = GRABA_BITA(CVE_CLIE, CVE_DOC, 0, "X", "Carta porte traslado se le generó un CFDI")


                    Dim msg As Object

                    Me.Cursor = Cursors.Default
                    msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
                    Dim Result As String
                    With msg
                        '.AddImageToMoreText("gridImage", img)

                        .MessageText = "Carta porte traslado TIMBRADA"

                        '.MoreText = "-----"
                        .AddStandardButtons(MessageBoxButtons.OK)
                        .Caption = "Proceso terminado"
                        .Icon = MessageBoxIcon.Information

                        .MessageBoxPosition = FormStartPosition.CenterScreen
                        Result = .Show()
                    End With

                    LtT.Visible = True
                    ChEnviarXCorreo.Checked = False
                    ChEnviarXCorreo.Visible = False
                    ChImprimir.Visible = True
                    BtnAceptar.Visible = True
                    BtnCancelar.Visible = True

                    'Dim rutaPDF As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".pdf"
                    'Dim rutaPDF2 As String = gRutaXML_TIMBRADO_SIN_PRECIOS & "\" & CVE_DOC & ".pdf"

                    Var2 = "TIMBRADA"
                    Var18 = "SI"

                    'CARATA PORTE TRASLADO TIMBRADA      CARATA PORTE TRASLADO TIMBRADA      CARATA PORTE TRASLADO TIMBRADA      
                    'CARATA PORTE TRASLADO TIMBRADA      CARATA PORTE TRASLADO TIMBRADA      CARATA PORTE TRASLADO TIMBRADA      
                    '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                    '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                    '◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘◘
                    '███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                Else
                    'CARTA PORTE TRASLADO NO NO NOOOOOOOOOOOOOOO  TIMBRADA
                    Me.Cursor = Cursors.Default
                    Dim msg As Object
                    msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                    Dim Result As String
                    With msg
                        .MessageText = "Carta porte NO timbrado"
                        .AddStandardButtons(MessageBoxButtons.OK)
                        .Caption = "Proceso terminado"
                        .Icon = MessageBoxIcon.Error

                        .MessageBoxPosition = FormStartPosition.CenterScreen
                        Result = .Show()

                        Var2 = ""
                        Me.Close()
                    End With
                    Var2 = ""
                End If
            Catch ex As Exception
                BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORACFDI("970. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default

        If TimbreOK Then
            'Me.Close()
        End If

    End Sub
    Public Sub RefreshDataBindings()
        Try
            _comprobante = New Comprobante()
            If _comprobante.Fecha.Year < 1973 Then _comprobante.Fecha = DateTime.Now

            _comprobante.Serie = GET_ONLY_LETTER(CVE_DOC)
            _comprobante.Folio = GetNumeric(CVE_DOC)

            ObtenerCamposConfiguracion()
            'bsComprobante.DataSource = _c

        Catch ex As Exception
            BITACORACFDI("590. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("590. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ObtenerCamposConfiguracion()
        _comprobante.Emisor.Nombre = EMISOR_RAZON_SOCIAL
        _comprobante.Emisor.Rfc = EMISOR_RFC
        _comprobante.LugarExpedicion = EMISOR_LUGAR_EXPEDICION

    End Sub


    Private Sub CPConceptoAgregar()

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT I.DESCR, I.CVE_ART, P.CANT, P.UNI_VENTA, I.PESO, I.CVE_PRODSERV, I.CVE_UNIDAD
                        FROM CFDI_CPT_PAR P
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                        LEFT JOIN INVE_CP CP ON CP.CVE_ART = P.CVE_ART
                        WHERE CVE_DOC = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Dim C As New Concepto With {
                            .Cantidad = dr("CANT"),
                            .ClaveProdServ = dr("CVE_PRODSERV"),
                            .ClaveUnidad = dr("CVE_UNIDAD"),
                            .Descripcion = dr("DESCR"),
                            .Descuento = 0,
                            .Importe = 0,
                            .NoIdentificacion = dr("CVE_ART"),
                            .Unidad = dr("UNI_VENTA"),
                            .ValorUnitario = 0,
                            .ObjetoImp = "01"
                        }
                        _comprobante.Conceptos.Concepto.Add(C)
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        CalculaTotalesCFDI()
        'limpiarCampos()
    End Sub
    Private Sub GetCamposCombox(FUSO_CFDI As String, FRECEPTOR_NOMBRE As String, FRECEPTOR_RFC As String,
                                FRECEPTOR_CP As String, FRECEPTOR_REG_FISC As String, FTIPOCOMPROBANTE As String)
        Try
            _comprobante.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL
            _comprobante.TipoDeComprobante = FTIPOCOMPROBANTE

            _comprobante.Moneda = "XXX"
            _comprobante.MetodoPago = ""
            _comprobante.FormaPago = ""
            _comprobante.Exportacion = "01"
            _comprobante.SubTotal = "0"
            _comprobante.Descuento = "0"
            _comprobante.Total = "0"

            _comprobante.Receptor.Nombre = FRECEPTOR_NOMBRE
            _comprobante.Receptor.Rfc = FRECEPTOR_RFC

            _comprobante.Receptor.DomicilioFiscalReceptor = EMISOR_LUGAR_EXPEDICION 'FRECEPTOR_CP
            'DomicilioFiscalReceptor
            _comprobante.Receptor.RegimenFiscalReceptor = FRECEPTOR_REG_FISC

            _comprobante.Receptor.UsoCFDI = FUSO_CFDI
        Catch ex As Exception
            BITACORACFDI("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Datos_carta_porte()
        Dim FECHA_CARGA As Date, FECHA_DESCARGA As Date, KMS_RECORRIDOS As Decimal, CVE_UNI As String = "", TRANSPINTERNAC As String
        Dim NUM_ALM_DES As Integer, TotalMercancias As Integer, PESO_KG As Decimal, PESO_UNIDAD As String, MAT_PELIGROSO As String = ""
        Dim NUM_ALMA As String = 1
        Dim O_RFC As String = "", O_NOMBRE As String = "", O_PAIS As String = "", O_CP As String = "", O_ESTADO As String = "", O_MUNICIPIO As String = ""
        Dim O_LOCALIDAD As String = "", O_COLONIA As String = "", O_CALLE As String = "", O_NUMINT As String = "", O_NUMEXT As String = ""

        Dim D_RFC As String = "", D_NOMBRE As String = "", D_PAIS As String = "", D_CP As String = "", D_ESTADO As String = "", D_MUNICIPIO As String = ""
        Dim D_LOCALIDAD As String = "", D_COLONIA As String = "", D_CALLE As String = "", D_NUMINT As String = "", D_NUMEXT As String = ""
        Dim TOTAL_MERCANCIAS As Decimal = 0

        Dim NOMBRE_OPERADOR As String = "", RFC_OPERADOR As String = ""
        Dim CALLE_OPERADOR As String = "", NUMEXT_OPERADOR As String, COLONIA_OPERADOR As String, LICENCIA As String = ""
        Dim LOCALIDAD_OPERADOR As String = "", CODIGOPOSTAL_OPERADOR As String = "", ESTADO_OPERADOR As String = "", MUNICIPIO_OPERADOR As String = "", PAIS_OPERADOR As String
        Dim CVE_OPER As Integer

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT F.NUM_ALMA, FECHA_CARGA, FECHA_DESCARGA, KMS_RECORRIDOS, CVE_UNI, TRANSPINTERNAC, NUM_ALM_DES,
                        I.DESCR, I.CVE_ART, P.CANT, P.UNI_VENTA, I.PESO, F.CONFIGVEHICULAR, F.CVE_OPER
                        FROM CFDI_CPT_PAR P
                        LEFT JOIN CFDI_CPT F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                        LEFT JOIN INVE_CP CP ON CP.CVE_ART = P.CVE_ART
                        WHERE P.CVE_DOC = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("PESO") > 0 Then
                            PESO_KG += dr("CANT") * dr("PESO")
                        Else
                            PESO_KG += dr("CANT")
                        End If

                        FECHA_CARGA = dr("FECHA_CARGA")
                        FECHA_DESCARGA = dr("FECHA_DESCARGA")
                        KMS_RECORRIDOS = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")
                        CVE_UNI = dr("CVE_UNI")
                        CVE_OPER = dr.ReadNullAsEmptyInteger("CVE_OPER")
                        TRANSPINTERNAC = dr("TRANSPINTERNAC")
                        NUM_ALM_DES = dr("NUM_ALM_DES")
                        NUM_ALMA = dr("NUM_ALMA")
                        TOTAL_MERCANCIAS += 1
                        ConfigVehicular = dr.ReadNullAsEmptyString("CONFIGVEHICULAR")
                    End While
                End Using
            End Using
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCOPERADOR WHERE CLAVE = " & CVE_OPER
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    If dr2.Read Then
                        NOMBRE_OPERADOR = dr2.ReadNullAsEmptyString("NOMBRE")
                        RFC_OPERADOR = dr2.ReadNullAsEmptyString("RFC")
                        CALLE_OPERADOR = dr2.ReadNullAsEmptyString("CALLE")
                        NUMEXT_OPERADOR = dr2.ReadNullAsEmptyString("NUM_EXT")
                        COLONIA_OPERADOR = dr2.ReadNullAsEmptyString("COLONIA_SAT")
                        LOCALIDAD_OPERADOR = dr2.ReadNullAsEmptyString("POBLACION_SAT")
                        CODIGOPOSTAL_OPERADOR = dr2.ReadNullAsEmptyString("CP_SAT")
                        ESTADO_OPERADOR = dr2.ReadNullAsEmptyString("ESTADO_SAT")
                        MUNICIPIO_OPERADOR = dr2.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        PAIS_OPERADOR = dr2.ReadNullAsEmptyString("PAIS_SAT")
                        LICENCIA = dr2.ReadNullAsEmptyString("LICENCIA")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(SUBTIPOREM,'') AS SUTIREM1,
                    ISNULL(U.ANO_MODELO,'') AS ANO_MOD, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL 
                    FROM GCUNIDADES U 
                    LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                    WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        PlacaVM = dr("PLACAS_MEX_TRACTOR")
                        Placa1 = dr("PLACAS_MEX_TANQUE1")
                        Placa2 = dr("PLACAS_MEX_TANQUE2")

                        AnioModeloVM = dr.ReadNullAsEmptyInteger("ANO_MOD")
                        SubTipoRem1 = dr.ReadNullAsEmptyString("SUTIREM1")
                        SubTipoRem2 = dr.ReadNullAsEmptyString("SUTIREM2")

                        PolizaRespCivil = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                        AseguraRespCivil = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT RFC, NOMBRE, PAIS, CP, ESTADO, MUNICIPIO,LOCALIDAD, COLONIA, CALLE, NUMINT, NUMEXT
                    FROM CFDI_UBICACIONES 
                    WHERE CVE_ALM = " & NUM_ALMA
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        O_RFC = dr.ReadNullAsEmptyString("RFC")
                        O_NOMBRE = dr.ReadNullAsEmptyString("NOMBRE")
                        O_PAIS = dr.ReadNullAsEmptyString("PAIS")
                        O_CP = dr.ReadNullAsEmptyString("CP")
                        O_ESTADO = dr.ReadNullAsEmptyString("ESTADO")
                        O_MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO")
                        O_LOCALIDAD = dr.ReadNullAsEmptyString("LOCALIDAD")
                        O_COLONIA = dr.ReadNullAsEmptyString("COLONIA")
                        O_CALLE = dr.ReadNullAsEmptyString("CALLE")
                        O_NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        O_NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT RFC, NOMBRE, PAIS, CP, ESTADO, MUNICIPIO,LOCALIDAD, COLONIA, CALLE, NUMINT, NUMEXT
                    FROM CFDI_UBICACIONES 
                    WHERE CVE_ALM = " & NUM_ALM_DES
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        D_RFC = dr.ReadNullAsEmptyString("RFC")
                        D_NOMBRE = dr.ReadNullAsEmptyString("NOMBRE")
                        D_PAIS = dr.ReadNullAsEmptyString("PAIS")
                        D_CP = dr.ReadNullAsEmptyString("CP")
                        D_ESTADO = dr.ReadNullAsEmptyString("ESTADO")
                        D_MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO")
                        D_LOCALIDAD = dr.ReadNullAsEmptyString("LOCALIDAD")
                        D_COLONIA = dr.ReadNullAsEmptyString("COLONIA")
                        D_CALLE = dr.ReadNullAsEmptyString("CALLE")
                        D_NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        D_NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            If (_cartaPorte Is Nothing) Then
                _cartaPorte = New CartaPorte
            End If

            _comprobante.Complemento = New Complemento With {.CartaPorte20 = _cartaPorte}
            _cartaPorte.Version = "2.0"
            _cartaPorte.TotalDistRec = KMS_RECORRIDOS 'TOTAL DISTANCIA RECORRIDA
            _cartaPorte.TranspInternac = "No"

            'ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  
            Dim ubicaciones As New Ubicaciones()
            Dim ubicacionOrigen As New Ubicacion With {
                .TipoUbicacion = "Origen",
                .RFCRemitenteDestinatario = O_RFC,
                .NombreRemitenteDestinatario = O_NOMBRE,
                .FechaHoraSalidaLlegada = FECHA_CARGA,
                .IDUbicacion = "OR" & Format(NUM_ALMA, "000000")
            }
            Dim domicilioOrigen As New Domicilio With {
                .Calle = O_CALLE}

            domicilioOrigen.NumeroExterior = O_NUMEXT
            domicilioOrigen.NumeroInterior = O_NUMINT

            If O_COLONIA.Trim.Length > 0 Then domicilioOrigen.Colonia = O_COLONIA
            domicilioOrigen.Localidad = O_LOCALIDAD
            domicilioOrigen.CodigoPostal = O_CP

            domicilioOrigen.Estado = O_ESTADO
            domicilioOrigen.Municipio = O_MUNICIPIO
            domicilioOrigen.Pais = O_PAIS
            ubicacionOrigen.Domicilio = domicilioOrigen

            'DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    

            Dim ubicacionDestino As New Ubicacion With {
                .TipoUbicacion = "Destino",
                .RFCRemitenteDestinatario = D_RFC,
                .NombreRemitenteDestinatario = D_NOMBRE,
                .FechaHoraSalidaLlegada = FECHA_DESCARGA,
                .IDUbicacion = "DE" & Format(NUM_ALM_DES, "000000"),
                .DistanciaRecorrida = KMS_RECORRIDOS
            }
            Dim domicilioDestino As New Domicilio With {
                .Calle = D_CALLE,
                .NumeroExterior = D_NUMEXT
            }
            domicilioDestino.NumeroInterior = D_NUMINT
            If D_COLONIA.Trim.Length > 0 Then domicilioDestino.Colonia = D_COLONIA

            domicilioDestino.Localidad = D_LOCALIDAD
            domicilioDestino.CodigoPostal = D_CP

            domicilioDestino.Estado = D_ESTADO
            domicilioDestino.Municipio = D_MUNICIPIO
            domicilioDestino.Pais = D_PAIS

            'SE AGREGA AL OBJETO
            ubicacionDestino.Domicilio = domicilioDestino

            ubicaciones.Ubicacion.Add(ubicacionOrigen)
            ubicaciones.Ubicacion.Add(ubicacionDestino)
            _cartaPorte.Ubicaciones = ubicaciones
            'FIN QUITE LAS 3 LINEAS

            TotalMercancias = TOTAL_MERCANCIAS

            'MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1                
            Dim mercancias As New Mercancias With {.NumTotalMercancias = TotalMercancias}

            PESO_UNIDAD = "KGM"

            mercancias.UnidadPeso = PESO_UNIDAD
            mercancias.PesoBrutoTotal = PESO_KG

            '███████████████████████████████████████

            Try
                Dim PESOKG As Decimal = 0

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT DESCR, P.CVE_ART, CANT, I.PESO, ISNULL(I.CVE_PRODSERV,'') AS CVE_PRODSER, I.CVE_UNIDAD,
                        MAT_PELIGROSO, CVE_MAT_PELIGROSO, EMBALAJE, UNIDADPESO, BIENESTRANSP
                        FROM CFDI_CPT_PAR P
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                        LEFT JOIN INVE_CP CP ON CP.CVE_ART = P.CVE_ART
                        WHERE CVE_DOC = '" & CVE_DOC & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            If dr("PESO") > 0 Then
                                PESOKG = dr("PESO") * dr("CANT")
                            Else
                                PESOKG = dr("CANT")
                            End If

                            Dim Mercancia1 As New Mercancia With {
                                .Descripcion = dr("DESCR"),
                                .ClaveUnidad = dr("CVE_UNIDAD"),
                                .Cantidad = dr("CANT"),
                                .PesoEnKg = PESOKG}

                            If dr.ReadNullAsEmptyString("MAT_PELIGROSO") = "Sí" Then
                                Mercancia1.DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))
                                Mercancia1.Embalaje = dr.ReadNullAsEmptyString("EMBALAJE")
                                Mercancia1.CveMaterialPeligroso = dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO")
                                Mercancia1.MaterialPeligroso = GET_MAT_PELIGROSO(dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO"))
                                MAT_PELIGROSO = "Sí"
                            End If

                            Mercancia1.BienesTransp = dr.ReadNullAsEmptyString("CVE_PRODSER")
                            'mercancia1.Unidad = "Pieza"            'mercancia1.Dimensiones = "59/40/36plg"            'mercancia1.Moneda = "MXN"
                            'mercancia1.ValorMercancia = 150000
                            mercancias.Mercancia.Add(Mercancia1)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            'MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2
            'mercancia2.Moneda = "MXN"            'mercancia2.ValorMercancia = 150000
            'Dim cantidadTransporta As CantidadTransporta = New CantidadTransporta()
            'CantidadTransporta.Cantidad = 8            'CantidadTransporta.IDOrigen = "OR458563"
            'CantidadTransporta.IDDestino = "DE458563"            'mercancia2.CantidadTransporta.Add(cantidadTransporta)

            'FIN CICLO MERCACNIAS
            '=-=============================================================================================

            Dim Autotransporte As New Autotransporte With {
                .NumPermisoSCT = NUMPERMISOSCT,
                .PermSCT = PERMSCT}

            Dim IdentificacionVehicular As New IdentificacionVehicular With {
                .AnioModeloVM = AnioModeloVM,
                .PlacaVM = PlacaVM,
                .ConfigVehicular = ConfigVehicular}

            If PolizaRespCivil.Trim.Length > 0 And AseguraRespCivil.Trim.Length > 0 Then
                Dim Seguros As New Seguros()
                If MAT_PELIGROSO = "Sí" Then
                    If PolizaMedAmbiente.Trim.Length > 0 Then Seguros.PolizaMedAmbiente = PolizaMedAmbiente
                    If AseguraMedAmbiente.Trim.Length > 0 Then Seguros.AseguraMedAmbiente = AseguraMedAmbiente
                End If

                If PolizaRespCivil.Trim.Length > 0 Then Seguros.PolizaRespCivil = PolizaRespCivil
                If AseguraRespCivil.Trim.Length > 0 Then Seguros.AseguraRespCivil = AseguraRespCivil
                'seguros.AseguraCarga = "Seguros Afirme"
                'seguros.PolizaCarga = "NUMPOLIZASEGURO"
                'seguros.PrimaSeguro = 1200
                Autotransporte.Seguros = Seguros
            End If

            If Tanque1.Trim.Length > 0 Or Tanque2.Trim.Length > 0 Then
                Dim remolques As New Remolques()
                Dim remolque1 As New Remolque()
                Dim remolque2 As New Remolque()

                If Tanque1.Trim.Length > 0 Then
                    remolque1.Placa = Placa1
                    remolque1.SubTipoRem = SubTipoRem1
                    remolques.Remolque.Add(remolque1)
                End If

                If Tanque2.Trim.Length > 0 Then
                    remolque2.Placa = Placa2
                    remolque2.SubTipoRem = SubTipoRem2
                    remolques.Remolque.Add(remolque2)
                End If
                Autotransporte.Remolques = remolques
            End If

            Autotransporte.IdentificacionVehicular = IdentificacionVehicular
            mercancias.Autotransporte = Autotransporte

            _cartaPorte.Mercancias = mercancias

            Dim figuraTransporte As New FiguraTransporte()
            '01 Operador
            '02 Propietario
            '03 Arrendador
            '04 Notificado
            Dim tiposFigura As New TiposFigura With {
                .TipoFigura = "01",
                .RFCFigura = RFC_OPERADOR,
                .NumLicencia = LICENCIA,
                .NombreFigura = NOMBRE_OPERADOR
            }

            Dim DomicilioTipoFigura As New Domicilio With {
                .Calle = CALLE_OPERADOR,
                .Localidad = LOCALIDAD_OPERADOR,
                .Municipio = MUNICIPIO_OPERADOR
            }
            'DomicilioTipoFigura.Colonia = COLONIA_OPERADOR

            If CODIGOPOSTAL_OPERADOR.Trim.Length > 0 Then
                DomicilioTipoFigura.CodigoPostal = CODIGOPOSTAL_OPERADOR
            End If

            DomicilioTipoFigura.Pais = "MEX"
            DomicilioTipoFigura.Estado = ESTADO_OPERADOR

            tiposFigura.Domicilio = DomicilioTipoFigura

            figuraTransporte.TiposFigura.Add(tiposFigura)

            _cartaPorte.FiguraTransporte = figuraTransporte
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK


        Catch ex As Exception
            BITACORACFDI("1200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub PROCESO_CFD_FACTURA_40()
        Dim d1 As DateTime = Now
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")
        Dim aCORREOS(0) As String
        Dim rutaPFX As String = gRutaPFX
        Dim rutaCertificado As String = gRutaCertificado
        Dim DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, CVE_PRODSERV As String = ""
        Dim CVE_UNIDAD As String = "", DESCR As String = "", UNI_MED As String = "", CVE_ART As String
        Dim MONEDA As String = "", USO_CFDI As String = "", FORMADEPAGOSAT As String = "", REG_FISC As String = ""
        Dim METODODEPAGO As String = "", RFC As String = "", NOMBRE_CLIENTE As String = "", CP As String = ""
        Dim CAN_TOT As Decimal = 0, IMP_TOT1 As Decimal = 0, IMP_TOT2 As Decimal = 0, IMP_TOT3 As Decimal = 0, IMP_TOT4 As Decimal = 0, IMPORTE As Decimal = 0
        Dim CLAVE As String = "", SERIE_F As String = "", FOLIO_F As Long = 0, ObjetoImp As String = ""
        Dim USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean, TIPCAMB As Decimal

        _comprobante = New Comprobante()

        Application.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.AppStarting

        Try
            Try
                SQL = "SELECT P.CVE_ART, P.CANT, P.PREC, P.NUM_PAR, ISNULL(I.DESCR,'') AS DES, I.UNI_MED, P.IMPU1, P.IMPU2, P.IMPU3, P.IMPU4, P.TOT_PARTIDA,
                    I.CVE_PRODSERV, I.CVE_UNIDAD, M.CVE_MONED, F.TIPCAMB, F.USO_CFDI, F.FORMADEPAGOSAT, F.METODODEPAGO, C.NOMBRE, C.CODIGO, C.REG_FISC, F.RFC, 
                    C.CLAVE, F.SERIE, F.FOLIO, F.CAN_TOT, F.IMP_TOT1, F.IMP_TOT1, F.IMP_TOT1, F.IMP_TOT1, F.IMPORTE, ISNULL(C.EMAILPRED,'') AS CORREO
                    FROM PAR_FACTF" & Empresa & " P
                    LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                    LEFT JOIN MONED" & Empresa & " M ON M.NUM_MONED = F.NUM_MONED
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                    LEFT JOIN IMPU" & Empresa & " T ON T.CVE_ESQIMPU = I.CVE_ESQIMPU
                    WHERE P.CVE_DOC = '" & CVE_DOC & "' ORDER BY P.NUM_PAR"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Application.DoEvents()

                            SERIE_F = dr("SERIE")
                            FOLIO_F = dr("FOLIO")

                            CAN_TOT = dr("CAN_TOT")
                            IMPORTE = dr("IMPORTE")
                            IMP_TOT1 = dr("IMP_TOT1")
                            IMP_TOT2 = dr("IMP_TOT1")
                            IMP_TOT3 = dr("IMP_TOT1")
                            IMP_TOT4 = dr("IMP_TOT1")

                            MONEDA = dr.ReadNullAsEmptyString("CVE_MONED")
                            TIPCAMB = dr("TIPCAMB")

                            USO_CFDI = dr.ReadNullAsEmptyString("USO_CFDI")
                            FORMADEPAGOSAT = dr.ReadNullAsEmptyString("FORMADEPAGOSAT")
                            METODODEPAGO = dr.ReadNullAsEmptyString("METODODEPAGO")
                            CLAVE = dr("CLAVE")
                            NOMBRE_CLIENTE = dr.ReadNullAsEmptyString("NOMBRE")
                            RFC = dr.ReadNullAsEmptyString("RFC")
                            REG_FISC = dr.ReadNullAsEmptyString("REG_FISC")
                            CP = dr.ReadNullAsEmptyString("CODIGO")

                            CVE_ART = dr.ReadNullAsEmptyString("CVE_ART")
                            DESCR = dr.ReadNullAsEmptyString("DES")
                            UNI_MED = dr.ReadNullAsEmptyString("UNI_MED")
                            IMPU1 = dr("IMPU1")
                            IMPU2 = dr("IMPU2")
                            IMPU3 = dr("IMPU3")
                            IMPU4 = dr("IMPU4")
                            CVE_PRODSERV = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            CVE_UNIDAD = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            DESC1 = 0
                            PRECIO = dr.ReadNullAsEmptyDecimal("PREC")

                            If IMPU1 = 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 = 0 Then
                                ObjetoImp = "01"
                            Else
                                ObjetoImp = "02"
                            End If

                            Dim c As New Concepto With {
                                .Cantidad = dr("CANT"),
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = DESCR,
                                .Descuento = DESC1,
                                .Importe = dr("TOT_PARTIDA"),
                                .NoIdentificacion = CVE_ART,
                                .Unidad = UNI_MED,
                                .ValorUnitario = PRECIO,
                                .Impuestos = GetImpuestosConcepto(PRECIO, dr("CANT"), DESC1, IMPU1, IMPU2, IMPU3, IMPU4),
                                .ObjetoImp = ObjetoImp
                            }
                            _comprobante.Conceptos.Concepto.Add(c)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)

                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False
                Return
            End Try

            CalculaTotalesCFDI()
            _comprobante.Emisor.Nombre = EMISOR_RAZON_SOCIAL
            _comprobante.Emisor.Rfc = EMISOR_RFC
            _comprobante.LugarExpedicion = EMISOR_LUGAR_EXPEDICION
            _comprobante.Fecha = FECHA_CERT
            _comprobante.Serie = SERIE_F
            _comprobante.Folio = FOLIO_F
            _comprobante.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL

            _comprobante.TipoDeComprobante = "I"
            _comprobante.Moneda = MONEDA
            If MONEDA <> "MXN" Then
                _comprobante.TipoCambio = TIPCAMB
            End If

            _comprobante.MetodoPago = METODODEPAGO
            If METODODEPAGO = "PPD" Then
                _comprobante.FormaPago = "99"
            Else
                _comprobante.FormaPago = FORMADEPAGOSAT
            End If

            _comprobante.Exportacion = "01"

            _comprobante.Receptor.Nombre = NOMBRE_CLIENTE
            _comprobante.Receptor.Rfc = RFC

            _comprobante.Receptor.DomicilioFiscalReceptor = CP
            _comprobante.Receptor.RegimenFiscalReceptor = REG_FISC
            _comprobante.Receptor.UsoCFDI = USO_CFDI

            AGREGA_CFDIRELACIONADOS(LtCVE_DOC.Text)

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If TIMBRADO_DEMO = "Si" Then
            USUAARIO_TIMB = "demo2"
            PASS_TIMB = "123456789"
        Else
            USUAARIO_TIMB = gUSUARIO_PAC
            PASS_TIMB = gPASS_PAC
        End If
        Var8 = ""

        Dim errorC As CError = _comprobante.EsInfoCorrecta()
        Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".pdf"
        Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO_CON_PRECIOS As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & RFC & "_" & CVE_DOC & ".xml"
        Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".xml"

        XML_BK = RutaXML_TIMBRADO_CON_PRECIOS

        Try
            If File.Exists(RutaXML_NO_TIMBRADO) = True Then
                File.Delete(RutaXML_NO_TIMBRADO)
            End If
            If File.Exists(RutaXML_TIMBRADO) = True Then
                File.Delete(RutaXML_TIMBRADO)
            End If
            If File.Exists(rutaPDF) = True Then
                File.Delete(rutaPDF)
            End If

            If Not File.Exists(rutaPFX) Then
                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False

                MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
                Return
            End If

            If Not File.Exists(rutaCertificado) Then
                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False

                MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                Return
            End If
        Catch ex As Exception
        End Try

        Try
            CFDI_XML_DIGIBOX = ""

            Dim xml As XmlDocument = GenerarXML.ObtenerXML(_comprobante, rutaPFX, gContraPFX, rutaCertificado)
            xml.Save(RutaXML_NO_TIMBRADO)

            CFDI_DEC = 2

            If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then

                TimbreOK = True

                RUTA_XML = RutaXML_TIMBRADO
                RUTA_PDF = rutaPDF

                SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                    CLIENTE, SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID) 
                    VALUES (
                    @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                    @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID())"

                For k = 1 To 5
                    Application.DoEvents()
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "F"
                            cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_F
                            cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = FOLIO_F
                            cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Now.ToString("yyyy-MM-ddTHH:mm:ss")
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLAVE
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)

                            cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                            cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                            cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMADEPAGOSAT
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Exit For
                                End If
                            End If
                        End Using
                    Catch SQLex As SqlException
                        Dim SSS As SqlError, Sqlcadena As String = ""
                        'MsgBox("Count = " & SQLex.Errors.Count)
                        For Each SSS In SQLex.Errors
                            Sqlcadena += SSS.Message & vbNewLine
                        Next
                        BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                    Catch ex As Exception
                        BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Next

                SQL = "UPDATE FACTF" & Empresa & " SET TIMBRADO = 'S' WHERE CVE_DOC = '" & CVE_DOC & "'"
                EXECUTE_QUERY_NET(SQL)

                Dim msg As Object

                Me.Cursor = Cursors.Default
                msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
                Dim Result As String
                With msg
                    '.AddImageToMoreText("gridImage", img)

                    If PassData1 = "PAGO COMPLEMENTO" Then
                        .MessageText = "Complemento TIMBRADO"
                    Else
                        .MessageText = "Factura TIMBRADA"
                    End If
                    '.MoreText = "-----"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Proceso terminado"
                    .Icon = MessageBoxIcon.Information

                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()
                End With

                LtT.Visible = True
                ChEnviarXCorreo.Visible = True
                ChImprimir.Visible = True
                BtnAceptar.Visible = True
                BtnCancelar.Visible = True

                Var2 = "TIMBRADA"
            Else
                Me.Cursor = Cursors.Default
                Dim msg As Object
                msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                Dim Result As String
                With msg
                    '.AddImageToMoreText("gridImage", img)

                    If PassData1 = "PAGO COMPLEMENTO" Then
                        .MessageText = "Complemento de pago NO timbrado"
                    Else
                        .MessageText = "Factura NO timbrado"
                    End If
                    '.MoreText = "-----"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Proceso terminado"
                    .Icon = MessageBoxIcon.Error

                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()

                    Var2 = ""
                    Me.Close()
                End With
                Var2 = ""
            End If
        Catch ex As Exception
            BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Application.UseWaitCursor = False
        Me.UseWaitCursor = False

    End Sub
    Private Function GetImpuestosConcepto(FPRECIO As Decimal, FCANT As Decimal, FDESC As Decimal,
                     FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal, Optional FFAC_GLOBAL As Boolean = False) As ImpuestosC
        Dim Impuesto As ImpuestosC = New ImpuestosC()

        Try
            If FIMPU1 > 0 Then
                FIMPU1 /= 100
                If FFAC_GLOBAL Then
                    Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "003", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 6), .TipoFactor = "Tasa"})
                Else
                    Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "003", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 2), .TipoFactor = "Tasa"})
                End If
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "001", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 /= 100
                If FFAC_GLOBAL Then
                    Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU4, 6), .TipoFactor = "Tasa"})
                Else
                    Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU4, 2), .TipoFactor = "Tasa"})
                End If
            End If
        Catch ex As Exception
            BITACORATPV("1750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return Impuesto

    End Function

    Sub PROCESO_CFD_FACTURA_GLOBAL()
        Dim d1 As DateTime = Now
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")
        Dim aCORREOS(0) As String
        Dim rutaPFX As String = gRutaPFX
        Dim rutaCertificado As String = gRutaCertificado
        Dim DESC1 As Decimal = 0, IMPU2 As Decimal, IMPU3 As Decimal, CVE_PRODSERV As String = ""
        Dim CVE_UNIDAD As String = "", DESCR As String = "", UNI_MED As String = "", MONEDA As String = "MXN", USO_CFDI As String = ""
        Dim FORMADEPAGOSAT As String = "", REG_FISC As String = "", METODODEPAGO As String = "", RFC As String = "", NOMBRE_CLIENTE As String = "", CP As String = ""
        Dim CAN_TOT As Decimal = 0, IMP_TOT1 As Decimal = 0, IMP_TOT2 As Decimal = 0, IMP_TOT3 As Decimal = 0, IMP_TOT4 As Decimal = 0, IMPORTE As Decimal = 0
        Dim CLAVE As String = "", SERIE_F As String = "", FOLIO_F As Long = 0, ObjetoImp As String = "", USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean
        Dim CLIENTE_MOSTRADOR As String = "", CVE_ART_FG As String = "", ISFACGLOBAL As Boolean = False, IEPS As Decimal = 0, IVA4 As Decimal = 0
        Dim CVE_ESQ As Integer, CVE_ESQ1 As Integer, CVE_ESQ2 As Integer, CVE_ESQ3 As Integer, SUMAIEPS As Decimal = 0, SUMAIVA4 As Decimal = 0
        Dim CVE_DOC_G As String, IVA0 As Decimal, TOT_PARTIDA As Decimal, TIMPU1 As Decimal, TIMPU4 As Decimal

        _comprobante = New Comprobante()

        Application.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.AppStarting


        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLIE_MOSTR, CVE_ART_FG FROM GCPARAMVENTAS"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CLIENTE_MOSTRADOR = dr.ReadNullAsEmptyString("CLIE_MOSTR")
                        CVE_ART_FG = dr.ReadNullAsEmptyString("CVE_ART_FG")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_PRODSERV, CVE_UNIDAD 
                    FROM INVE" & Empresa & " 
                    WHERE CVE_ART = '" & CVE_ART_FG & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_PRODSERV = dr("CVE_PRODSERV")
                        CVE_UNIDAD = dr("CVE_UNIDAD")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NOMBRE, RFC, USO_CFDI, REG_FISC, FORMADEPAGOSAT, CODIGO
                    FROM CLIE" & Empresa & " 
                    WHERE CLAVE = '" & CLIENTE_MOSTRADOR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NOMBRE_CLIENTE = dr("NOMBRE")
                        RFC = dr("RFC")
                        USO_CFDI = dr("USO_CFDI")
                        REG_FISC = dr("REG_FISC")
                        FORMADEPAGOSAT = dr("FORMADEPAGOSAT")
                        CP = dr("CODIGO")
                    End If
                End Using
            End Using

            IMPORTE = 0
            SERIE_F = GET_ONLY_LETTER(CVE_DOC)
            FOLIO_F = GetNumeric(CVE_DOC)

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Try
                SQL = "SELECT F.CVE_DOC 
                    FROM FACTV" & Empresa & " F 
                    WHERE F.DOC_SIG = '" & CVE_DOC & "' 
                    GROUP BY F.CVE_DOC
                    ORDER BY F.CVE_DOC"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            IEPS = 0 : IVA4 = 0 : SUMAIEPS = 0 : SUMAIVA4 = 0 : IVA0 = 0 : TOT_PARTIDA = 0
                            CVE_ESQ1 = 0 : CVE_ESQ2 = 0 : CVE_ESQ3 = 0 : TIMPU1 = 0 : TIMPU4 = 0

                            CVE_DOC_G = dr("CVE_DOC")
                            CVE_DOC_GC = CVE_DOC_G

                            'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CANT, NUM_PAR, (PREC * CANT) AS TOT_PAR, (COST * CANT) AS COSTO, IMPU1, IMPU2, IMPU3, IMPU4,
                                    TOTIMP1 AS TIMP1, TOTIMP2 AS TIMP2, TOTIMP3 AS TIMP3, TOTIMP4 AS TIMP4, CVE_ESQ
                                    FROM PAR_FACTV" & Empresa & " P
                                    LEFT JOIN FACTV" & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                                    WHERE P.CVE_DOC = '" & CVE_DOC_G & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read 'PARTIDAS   PARTIDAS   PARTIDAS   PARTIDAS  PARTIDAS
                                        If dr2("IMPU1") > 0 Then
                                            IEPS += dr2("TOT_PAR") * dr2("IMPU1") / 100
                                            CVE_ESQ1 = dr2("CVE_ESQ")
                                            SUMAIEPS += dr2("TOT_PAR")
                                            TIMPU1 = dr2("IMPU1")
                                        End If
                                        If dr2("IMPU4") > 0 Then
                                            IVA4 += dr2("TOT_PAR") * dr2("IMPU4") / 100
                                            CVE_ESQ2 = dr2("CVE_ESQ")
                                            SUMAIVA4 += dr2("TOT_PAR")
                                            TIMPU4 = dr2("IMPU4")
                                        End If
                                        If dr2("IMPU1") = 0 And dr2("IMPU4") = 0 Then
                                            CVE_ESQ3 = dr2("CVE_ESQ")
                                            IVA0 += dr2("TOT_PAR")
                                        End If
                                        TOT_PARTIDA += dr2("TOT_PAR")

                                        CAN_TOT += dr2("TOT_PAR")
                                        IMP_TOT1 += dr2("TOT_PAR") * dr2("IMPU1") / 100
                                        IMP_TOT4 += dr2("TOT_PAR") * dr2("IMPU4") / 100

                                        IMPORTE += dr2("TOT_PAR") + IMP_TOT1 + IMP_TOT4

                                        If CVE_DOC_G = "BB15566" Then
                                            Debug.Print("")
                                        End If
                                    End While
                                End Using
                                If CVE_ESQ1 > 0 Then
                                    CVE_ESQ = CVE_ESQ1
                                ElseIf CVE_ESQ2 > 0 Then
                                    CVE_ESQ = CVE_ESQ2
                                Else
                                    CVE_ESQ = CVE_ESQ3
                                End If
                            End Using
                            ObjetoImp = "02"

                            Dim c As New Concepto With {
                                .Cantidad = 1,
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = "Venta",
                                .Descuento = DESC1,
                                .Importe = Math.Round(TOT_PARTIDA, 2),
                                .NoIdentificacion = CVE_DOC_G,
                                .ValorUnitario = Math.Round(TOT_PARTIDA, 2),
                                .Impuestos = GetImpuestosConceptoFacGlobal(SUMAIEPS, SUMAIVA4, TIMPU1, IMPU2, IMPU3, TIMPU4, IEPS, IVA4, IVA0),
                                .ObjetoImp = ObjetoImp
                            }
                            _comprobante.Conceptos.Concepto.Add(c)
                            '                                .Unidad = UNI_MED,
                            If CVE_DOC_G = "BB15566" Then
                                Debug.Print("")
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)

                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False
                Return
            End Try

            CalculaTotalesCFDI_G()

            _comprobante.Emisor.Nombre = EMISOR_RAZON_SOCIAL
            _comprobante.Emisor.Rfc = EMISOR_RFC
            _comprobante.LugarExpedicion = EMISOR_LUGAR_EXPEDICION
            _comprobante.Fecha = FECHA_CERT
            _comprobante.Serie = SERIE_F
            _comprobante.Folio = FOLIO_F
            _comprobante.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL

            _comprobante.TipoDeComprobante = "I"
            _comprobante.Moneda = MONEDA
            _comprobante.MetodoPago = "PUE"

            _comprobante.FormaPago = "01"

            _comprobante.Exportacion = "01"

            _comprobante.Receptor.Nombre = NOMBRE_CLIENTE
            _comprobante.Receptor.Rfc = RFC

            _comprobante.Receptor.DomicilioFiscalReceptor = EMISOR_LUGAR_EXPEDICION 'CP
            _comprobante.Receptor.RegimenFiscalReceptor = REG_FISC
            _comprobante.Receptor.UsoCFDI = USO_CFDI

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If TIMBRADO_DEMO = "Si" Then
            USUAARIO_TIMB = "demo2"
            PASS_TIMB = "123456789"
        Else
            USUAARIO_TIMB = gUSUARIO_PAC
            PASS_TIMB = gPASS_PAC
        End If
        Var8 = ""

        Dim errorC As CError = _comprobante.EsInfoCorrecta()
        Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".pdf"
        Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO_CON_PRECIOS As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & RFC & "_" & CVE_DOC & ".xml"
        Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & RFC & "_" & CVE_DOC & ".xml"

        XML_BK = RutaXML_TIMBRADO_CON_PRECIOS

        Try
            If File.Exists(RutaXML_NO_TIMBRADO) = True Then
                File.Delete(RutaXML_NO_TIMBRADO)
            End If
            If File.Exists(RutaXML_TIMBRADO) = True Then
                File.Delete(RutaXML_TIMBRADO)
            End If
            If File.Exists(rutaPDF) = True Then
                File.Delete(rutaPDF)
            End If

            If Not File.Exists(rutaPFX) Then
                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False

                MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
                Return
            End If

            If Not File.Exists(rutaCertificado) Then
                Me.Cursor = Cursors.Default
                Application.UseWaitCursor = False
                Me.UseWaitCursor = False

                MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                Return
            End If
        Catch ex As Exception
        End Try

        Try
            CFDI_XML_DIGIBOX = ""

            CFDI_DEC = 6
            ISFAC_GLOBAL = True

            Dim xml As XmlDocument = GenerarXML.ObtenerXML(_comprobante, rutaPFX, gContraPFX, rutaCertificado)
            xml.Save(RutaXML_NO_TIMBRADO)

            ISFAC_GLOBAL = False
            CFDI_DEC = 2

            If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then

                TimbreOK = True

                RUTA_XML = RutaXML_TIMBRADO
                RUTA_PDF = rutaPDF

                SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                    CLIENTE, SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID) 
                    VALUES (
                    @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                    @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID())"

                For k = 1 To 5
                    Application.DoEvents()
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "F"
                            cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_F
                            cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = FOLIO_F
                            cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Now.ToString("yyyy-MM-ddTHH:mm:ss")
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLAVE
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)

                            cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                            cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                            cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMADEPAGOSAT
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Exit For
                                End If
                            End If
                        End Using
                    Catch SQLex As SqlException
                        Dim SSS As SqlError, Sqlcadena As String = ""
                        'MsgBox("Count = " & SQLex.Errors.Count)
                        For Each SSS In SQLex.Errors
                            Sqlcadena += SSS.Message & vbNewLine
                        Next
                        BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                    Catch ex As Exception
                        BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Next

                Dim msg As Object

                Me.Cursor = Cursors.Default
                msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
                Dim Result As String
                With msg
                    '.AddImageToMoreText("gridImage", img)

                    .MessageText = "Factura global TIMBRADA"

                    '.MoreText = "-----"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Proceso terminado"
                    .Icon = MessageBoxIcon.Information

                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()
                End With

                LtT.Visible = True
                ChEnviarXCorreo.Visible = True
                ChImprimir.Visible = True
                BtnAceptar.Visible = True
                BtnCancelar.Visible = True

                Var2 = "TIMBRADA"
            Else
                Me.Cursor = Cursors.Default
                Dim msg As Object
                msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                Dim Result As String
                With msg
                    '.AddImageToMoreText("gridImage", img)

                    If PassData1 = "PAGO COMPLEMENTO" Then
                        .MessageText = "Complemento de pago NO timbrado"
                    Else
                        .MessageText = "Factura NO timbrado"
                    End If
                    '.MoreText = "-----"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Proceso terminado"
                    .Icon = MessageBoxIcon.Error

                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()

                    Var2 = ""
                    Me.Close()
                End With
                Var2 = ""
            End If
        Catch ex As Exception
            BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Application.UseWaitCursor = False
        Me.UseWaitCursor = False

    End Sub
    Private Function GetImpuestosCFDI_G(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As New Traslado()
        Dim retencion As New Retencion()
        Dim traslados As New List(Of Traslado)()
        Dim retenciones As New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As New Impuestos()

        'BACKUPTXT("fac global", "Paso,traslados(index).Importe,t.Importe,t.TasaOCuota,t.TipoFactor, tImpuesto, traslados(index).Base,tBase")

        For Each c As Concepto In conceptos
            For Each t As TrasladoC In c.Impuestos.Traslados

                If (traslados.Exists(Function(x) (x.Impuesto = t.Impuesto) AndAlso (x.TasaOCuota = t.TasaOCuota))) Then

                    index = traslados.FindIndex(Function(x) x.Impuesto = t.Impuesto AndAlso (x.TasaOCuota = t.TasaOCuota))
                    traslados(index).Importe = traslados(index).Importe + t.Importe
                    traslados(index).Base = traslados(index).Base + t.Base
                    BACKUPTXT("fac global", "Paso1:," & traslados(index).Importe & "," & t.Importe & "," & t.TasaOCuota & "," & t.TipoFactor & "," & t.Impuesto & "," & traslados(index).Base & "," & t.Base)
                Else
                    traslado = New Traslado()

                    traslado.Base += t.Base
                    traslado.Importe = t.Importe
                    traslado.Impuesto = t.Impuesto
                    traslado.TasaOCuota = t.TasaOCuota
                    traslado.TipoFactor = t.TipoFactor
                    traslados.Add(traslado)
                    BACKUPTXT("fac global", "Paso2:," & traslado.Importe & "," & t.Importe & "," & t.TasaOCuota & "," & t.TipoFactor & "," & t.Impuesto & "," & traslado.Base & "," & t.Base)
                End If
            Next

            For Each r As RetencionC In c.Impuestos.Retenciones
                If (retenciones.Exists(Function(x) (x.Impuesto = r.Impuesto))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = r.Impuesto)
                    retenciones(index).Importe = retenciones(index).Importe + r.Importe
                Else
                    retencion = New Retencion With {
                        .Importe = r.Importe,
                        .Impuesto = r.Impuesto
                    }

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos += r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados += t.Importe
        Next

        If totalImpuestosRetenidos > 0 Then
            impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        End If
        If totalImpuestosTrasladados > 0 Then
            impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        End If
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function
    Private Sub CalculaTotalesCFDI_G()
        _comprobante.Impuestos = GetImpuestosCFDI_G(_comprobante.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _comprobante.Conceptos.Concepto
            subtotal += c.Importe
            descuento = c.Descuento
        Next

        _comprobante.SubTotal = subtotal
        _comprobante.Descuento = descuento
        _comprobante.Total = subtotal - _comprobante.Impuestos.TotalImpuestosRetenidos + _comprobante.Impuestos.TotalImpuestosTrasladados
        _comprobante.TotalLetra = New Numalet().ToCustomString(_comprobante.Total)

    End Sub
    Private Function GetImpuestosConceptoFacGlobal(FSUMA_IEPS As Decimal, FSUMA_IVA As Decimal,
                     FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal,
                     FIEPS As Decimal, FIVA As Decimal, FIVA0 As Decimal) As ImpuestosC

        Dim Impuesto As New ImpuestosC()

        Try
            If FIMPU1 > 0 Then
                FIMPU1 /= 100
                Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = Math.Round(FSUMA_IEPS, 6), .Impuesto = "003", .Importe = Math.Round(FIEPS, 6), .TipoFactor = "Tasa"})
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = Math.Round(FSUMA_IVA, 6), .Impuesto = "001", .Importe = Math.Round(FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 /= 100
                Impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = Math.Round(FSUMA_IVA, 6), .Impuesto = "002", .Importe = Math.Round(FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 /= 100
                Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = Math.Round(FSUMA_IVA, 6), .Impuesto = "002", .Importe = Math.Round(FIVA, 6), .TipoFactor = "Tasa"})
            End If
            If FIVA0 > 0 Then
                Impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = 0, .Base = Math.Round(FIVA0, 6), .Impuesto = "002", .Importe = 0, .TipoFactor = "Tasa"})
            End If
        Catch ex As Exception
            BITACORATPV("1750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return Impuesto

    End Function


    Sub AGREGA_CFDIRELACIONADOS(FCVE_DOC As String)
        Dim TIPO_REL As String = ""
        Dim _cfdiRelacionados As New CfdiRelacionados
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT UUID, TIP_REL FROM CFDI_REL" & Empresa & " WHERE CVE_DOC = '" & FCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TIPO_REL = dr("TIP_REL")
                        Dim c As New CfdiRelacionado With {.UUID = dr("UUID")}
                        _cfdiRelacionados.CfdiRelacionado.Add(c)
                    End While
                End Using
                _cfdiRelacionados.TipoRelacion = TIPO_REL
                _comprobante.CfdiRelacionados = _cfdiRelacionados
            End Using
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Function GetImpuestosCFDI(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As New Traslado()
        Dim retencion As New Retencion()
        Dim traslados As New List(Of Traslado)()
        Dim retenciones As New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As New Impuestos()

        For Each c As Concepto In conceptos
            For Each t As TrasladoC In c.Impuestos.Traslados

                If (traslados.Exists(Function(x) (x.Impuesto = t.Impuesto) AndAlso (x.TasaOCuota = t.TasaOCuota))) Then

                    index = traslados.FindIndex(Function(x) x.Impuesto = t.Impuesto AndAlso (x.TasaOCuota = t.TasaOCuota))
                    traslados(index).Importe = traslados(index).Importe + t.Importe
                    traslados(index).Base = traslados(index).Base + t.Base
                Else
                    traslado = New Traslado()

                    traslado.Base += t.Base
                    traslado.Importe = t.Importe
                    traslado.Impuesto = t.Impuesto
                    traslado.TasaOCuota = t.TasaOCuota
                    traslado.TipoFactor = t.TipoFactor

                    traslados.Add(traslado)
                End If
            Next

            For Each r As RetencionC In c.Impuestos.Retenciones
                If (retenciones.Exists(Function(x) (x.Impuesto = r.Impuesto))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = r.Impuesto)
                    retenciones(index).Importe = retenciones(index).Importe + r.Importe
                Else
                    retencion = New Retencion With {
                        .Importe = r.Importe,
                        .Impuesto = r.Impuesto
                    }

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos += r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados += t.Importe
        Next

        If totalImpuestosRetenidos > 0 Then
            impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        End If
        If totalImpuestosTrasladados > 0 Then
            impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        End If
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function

    Private Function GetImpuestos(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As New Traslado()
        Dim retencion As New Retencion()
        Dim traslados As New List(Of Traslado)()
        Dim retenciones As New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As New Impuestos()

        For Each c As Concepto In conceptos
            For Each t As TrasladoC In c.Impuestos.Traslados
                If (traslados.Exists(Function(x) (x.Impuesto = t.Impuesto) AndAlso (x.TasaOCuota = t.TasaOCuota))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = t.Impuesto AndAlso (x.TasaOCuota = t.TasaOCuota))
                    traslados(index).Importe = traslados(index).Importe + t.Importe
                Else
                    traslado = New Traslado With {
                        .Importe = t.Importe,
                        .Impuesto = t.Impuesto,
                        .TasaOCuota = t.TasaOCuota,
                        .TipoFactor = t.TipoFactor
                    }
                    traslados.Add(traslado)
                End If
            Next

            For Each r As RetencionC In c.Impuestos.Retenciones
                If (retenciones.Exists(Function(x) (x.Impuesto = r.Impuesto))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = r.Impuesto)
                    retenciones(index).Importe = retenciones(index).Importe + r.Importe
                Else
                    retencion = New Retencion With {
                        .Importe = r.Importe,
                        .Impuesto = r.Impuesto
                    }

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos += r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados += t.Importe
        Next

        impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function
    Sub PROCESO_TIMBRE_CP()

        Dim TimbreOK As Boolean = False, XML_TABLA As String = "", FILE_XML As String = ""
        Dim CER64 As String, KEY64 As String, USUAARIO_TIMB As String = "", PASS_TIMB As String = "", CVE_OBS As Long = 0
        Dim CVE_BITA As Long = 0, REFER As String = "", FORMA_PAGO_SAT As String = "", CVE_MONED As String = "", CTA_BAN_ORD As String = ""
        Dim RFC_ORD As String = "", BANCO_ORD As String = "", CTA_BAN_BEN As String = "", RFC_BEN As String = "", NUM_OPER As String = ""
        Dim Continua As Boolean = False, Continua_Par As Boolean = False, IMPORTE As Decimal = 0, TipoCambio As Decimal = 0
        Dim CALCULO_INVERSO As Decimal = 0, TOTAL_MXN As Decimal = 0, CALC_IVA As Decimal = 0, CALC_RET As Decimal = 0
        Dim ObjetoImpDR As String = "002", Impuesto_DR As String, Impuesto_RET As String, BASE_PT As Decimal = 0, BASE_PR As Decimal = 0
        Dim IMP_IVA As Decimal = 0, IMP_RET As Decimal = 0, SUBT As Decimal = 0
        Dim TOTALTRASLADOSBASEIVAEXENTO As Decimal = 0, TOTALTRASLADOSIMPUESTOIVA0 As Decimal = 0, TOTALTRASLADOSBASEIVA0 As Decimal = 0
        Dim TOTALTRASLADOSIMPUESTOIVA8 As Decimal = 0, TOTALTRASLADOSBASEIVA8 As Decimal = 0, TOTALTRASLADOSIMPUESTOIVA16 As Decimal = 0
        Dim TOTALTRASLADOSBASEIVA16 As Decimal = 0, TOTALRETENCIONESIEPS As Decimal = 0, TOTALRETENCIONESISR As Decimal = 0, TOTALRETENCIONESIVA As Decimal = 0
        Dim IMPPAGADO As Decimal = 0, SALDO_ANT As Decimal, SALDO_INSOLUTO As Decimal, ISUSD As String = "MXN"
        Dim aUUID(0) As String, ListaUUID As New List(Of String)
        Dim d As DateTime = DateTime.Now
        Dim UUID As String = "", x As Integer = 0, nDR As Integer = 0, NDR_UUID As Integer = 0
        Dim FACTURA As String = "", Texto As String = "", Texto2 As String = "", Texto3 As String = ""
        Dim IVA_SUM As Decimal, RET_SUM As Decimal
        Dim xdoc As New XmlDocument()

        Dim IVA As Decimal = 0, RET As Decimal = 0

        Me.Refresh()

        If Not Valida_Conexion() Then
            Return
        End If

        Application.UseWaitCursor = True
        Me.Cursor = Cursors.WaitCursor
        Me.UseWaitCursor = True
        Me.Cursor = Cursors.AppStarting


        Try
            _comprobante = New Comprobante With {
            .Fecha = Date.Now
        }
            _comprobante.Conceptos.Concepto.Add(GetConcepto())
            _comprobante.Emisor.Nombre = EMISOR_RAZON_SOCIAL
            _comprobante.Emisor.Rfc = EMISOR_RFC
            _comprobante.LugarExpedicion = EMISOR_LUGAR_EXPEDICION
            _comprobante.SubTotal = 0
            _comprobante.Total = 0
            _comprobante.Emisor.RegimenFiscal = LtRegimenEmisor.Text
            _comprobante.TipoDeComprobante = "P"
            _comprobante.Exportacion = "01"
            _comprobante.Moneda = "XXX"

            _comprobante.Complemento = New Complemento With {.Pagos = New Pagos}

            _comprobante.Receptor.Nombre = LtNombre.Text
            _comprobante.Receptor.Rfc = LtRFC.Text
            _comprobante.Receptor.UsoCFDI = LtUSO_CFDI.Text
            _comprobante.Receptor.RegimenFiscalReceptor = LtRegimenReceptor.Text
            _comprobante.Receptor.DomicilioFiscalReceptor = LtCP.Text

            AGREGA_CFDIRELACIONADOS(LtCVE_DOC.Text)

            If TIMBRADO_DEMO = "Si" Then
                USUAARIO_TIMB = "demo2"
                PASS_TIMB = "123456789"
            Else
                USUAARIO_TIMB = gUSUARIO_PAC
                PASS_TIMB = gPASS_PAC
            End If

            CER64 = ConvertFileToBase64(gRutaCertificado)
            KEY64 = ConvertFileToBase64(gRutaPFX)
        Catch ex As Exception
            BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Dim pago As New Pago()
        Dim _documentosRelacionados As New List(Of PDoctoRelacionado)
        Dim _ImpuestosP As New List(Of ImpuestosP)

        'CVE_DOC = Var4  AHORA LO ASIGNA DESDE EL FORM_LOAD
        SQL = "SELECT FD.CVE_DOC, FD.TIPO_COMPROBANTE, FD.NUM_PAR, FD.REFER, FD.ESTATUS, FD.FORMAPAGOSAT, FD.FACTURA, FD.FECHA, 
            FD.FECHA_PAGO, FD.IMPORTE, FD.CVE_OBS, FD.CVE_MONED, FD.TCAMBIO, FD.CTA_ORD, FD.RFC_ORD, FD.BANCO_ORD, FD.CTA_BEN, 
            FD.RFC_BEN, FD.NUM_OPERACION, FD.NO_PARTIDA, ISNULL(F.SUBTOTAL,0) AS SUBT, ISNULL(F.IVA,0) AS IV, ISNULL(RETENCION,0) AS RET
            FROM CFDI_COMPAGO_PAR FD
            LEFT JOIN CFDI F ON F.FACTURA = FD.REFER
            WHERE FD.CVE_DOC = '" & CVE_DOC & "'"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Try

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT DR.CVE_DOC, DR.REFER, DR.FECHA, DR.IMPSALDOANT, DR.IMPPAGADO, DR.IMPSALDOINSOLUTO, DR.NUMPARCIALIDAD, 
                                    DR.MONEDADR, DR.EQUIVALENCIADR, DR.FOLIO, DR.SERIE, DR.OBJETOIMP_DR, DR.IDDOCUMENTO, DR.FORMADEPAGOSAT, 
                                    DR.TCAMBIO, ISNULL(F.SUBTOTAL,0) AS SUBT, ISNULL(F.IVA,0) AS IV, ISNULL(F.RETENCION,0) AS RET, 
                                    ISNULL(F.XML,'') AS XML_DOC, F.RETENCION AS IMP_TOT3, F.IVA AS IMP_TOT4, F.SUBTOTAL AS CAN_TOT, F.IMPORTE, 
                                    ISNULL(FC.XML_DOC,'') AS XML_FAC 
                                    FROM CFDI_COMPAGO_PAR_DR DR
                                    LEFT JOIN CFDI F ON F.FACTURA = DR.REFER
                                    LEFT JOIN CFDI" & Empresa & " FC ON FC.CVE_DOC = DR.REFER
                                    WHERE DR.CVE_DOC = '" & CVE_DOC & "' AND DOCTO = '" & dr("REFER") & "' ORDER BY NUMPARCIALIDAD"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        'impuesto 001 – ISR, impuesto 002 – IVA, impuesto 003 – IEPS.
                                        'TRASLADO                           RETENCION
                                        'IMP_TOT1 = 003 IEPS                IMP_TOT1 = 0
                                        'IMP_TOT2 = 0                       IMP_TOT2 = 001 ISR
                                        'IMP_TOT3 = 0                       IMP_TOT3 = 002 RETENCION     
                                        'IMP_TOT4 = 002 IVA                 IMP_TOT4 = 002 IVA

                                        If dr("TCAMBIO") <> 1 Then
                                            pago.CtaBeneficiario = dr("CTA_BEN")
                                            pago.RfcEmisorCtaBen = dr("RFC_BEN")

                                            pago.CtaOrdenante = dr("CTA_ORD")
                                            pago.RfcEmisorCtaOrd = dr("RFC_ORD")

                                            pago.Monto += dr2("CAN_TOT")

                                            ISUSD = "USD"
                                        Else
                                            pago.Monto += dr2("IMPORTE")
                                            ISUSD = "MXN"
                                        End If
                                        TipoCambio = dr("TCAMBIO")

                                        pago.NumOperacion = dr("NUM_OPERACION")
                                        pago.TipoCambioP = dr("TCAMBIO")
                                        pago.MonedaP = dr("CVE_MONED")
                                        pago.FormaDePagoP = dr("FORMAPAGOSAT")
                                        pago.FechaPago = dr2("FECHA")

                                        If dr("TCAMBIO") <> 1 Then
                                            TOTAL_MXN += dr2("SUBT") * TipoCambio
                                        Else
                                            TOTAL_MXN = 0
                                        End If

                                        SUBT = dr2("SUBT")
                                        IVA = dr2("IV")
                                        RET = Math.Abs(dr2("RET"))
                                        '_comprobante.Complemento.Pagos.Pago          montoTotalPagos += p.Monto * p.TipoCambioP

                                        If IVA = 0 Then
                                            If dr2("XML_DOC").ToString.Trim.Length > 0 Then
                                                UUID = OBTENER_UUID_XML(dr2("XML_DOC"))
                                                'TotalCFD   SubtotalCFD
                                                SUBT = SubtotalCFD
                                                IVA = IVAcfd
                                                RET = RETcfd
                                            Else
                                                SUBT = dr2("CAN_TOT")
                                                RET = dr2("IMP_TOT3")
                                                IVA = dr2("IMP_TOT4")
                                                RET = Math.Abs(RET)

                                                If IVA = 0 Then
                                                    If dr2("XML_FAC").ToString.Trim.Length > 0 Then
                                                        UUID = OBTENER_UUID_XML(dr2("XML_DOC"))
                                                        'TotalCFD   SubtotalCFD
                                                        SUBT = SubtotalCFD
                                                        IVA = IVAcfd
                                                        RET = RETcfd
                                                        RET = Math.Abs(RET)
                                                    End If
                                                End If
                                            End If
                                            SQL = "UPDATE CFDI SET SUBTOTAL = " & SUBT & ", RETENCION = " & RET & ", IVA = " & IVA & " 
                                                WHERE FACTURA = '" & dr2("REFER") & "'"
                                            'EXECUTE_QUERY_NET(SQL)
                                        End If
                                        IVA_SUM += IVA
                                        RET_SUM += RET

                                        SALDO_ANT = dr2.ReadNullAsEmptyDecimal("IMPSALDOANT")
                                        SALDO_INSOLUTO = dr2.ReadNullAsEmptyDecimal("IMPSALDOINSOLUTO")

                                        If SALDO_INSOLUTO <= 0 Then
                                            SALDO_INSOLUTO = 0
                                        End If

                                        Impuesto_DR = "002"
                                        Impuesto_RET = "002"

                                        If IVA = 0 And RET = 0 Then
                                            ObjetoImpDR = "02"
                                        Else
                                            ObjetoImpDR = "02"
                                        End If

                                        If dr2("MONEDADR") = "USD" Then
                                            SALDO_ANT = dr2("CAN_TOT")
                                            SALDO_INSOLUTO = 0
                                            IMPPAGADO = dr2("CAN_TOT")
                                            TipoCambio = 1
                                        Else
                                            SALDO_ANT = dr2("IMPPAGADO")
                                            IMPPAGADO = dr2("IMPPAGADO")
                                        End If
                                        '_comprobante.Complemento.Pagos.Pago          montoTotalPagos += p.Monto * p.TipoCambioP

                                        Dim Tdr As New PDoctoRelacionado With {
                                            .Folio = dr2("REFER"),
                                            .IdDocumento = dr2("IDDOCUMENTO"),
                                            .ImpPagado = IMPPAGADO,
                                            .ImpSaldoAnt = SALDO_ANT,
                                            .ImpSaldoInsoluto = SALDO_INSOLUTO,
                                            .ObjetoImpDR = ObjetoImpDR,
                                            .MonedaDR = dr2("MONEDADR"),
                                            .NumParcialidad = dr2("NUMPARCIALIDAD"),
                                            .Serie = dr2("SERIE"),
                                            .EquivalenciaDR = TipoCambio}

                                        Dim ImpuestosDR As New ImpuestosDR
                                        Dim TrasladosDR As New TrasladosDR
                                        Dim ImpuestoDr As New TrasladoDR
                                        'TRASLADOS
                                        If IVA > 0 And RET > 0 Then
                                            CALCULO_INVERSO = CALCULA_CALC_INVERSO(dr2("IMPPAGADO"), 0.16, -0.04)
                                        ElseIf RET > 0 Then
                                            CALCULO_INVERSO = CALCULA_CALC_INVERSO(dr2("IMPPAGADO"), 0.16, 0)
                                        Else
                                            CALCULO_INVERSO = 0
                                        End If

                                        CALC_IVA += Math.Round(CALCULO_INVERSO, 2)
                                        'CALC_RET += CALCULO_INVERSO

                                        If IVA > 0 Then
                                            'SUMA TOTAL IMPUESO IVA TRASLAOD
                                            BASE_PT += Math.Round(CALCULO_INVERSO, 2)
                                            'TOTAL TRASLADO   AQUI ERROR
                                            IMP_IVA += Math.Round(CALCULO_INVERSO * 0.16, 2)

                                            ImpuestoDr.ImporteDR = Math.Round(CALCULO_INVERSO * 0.16, 2)
                                            ImpuestoDr.TasaOCuotaDR = 0.16
                                            ImpuestoDr.TipoFactorDR = "Tasa"
                                            ImpuestoDr.ImpuestoDR = Impuesto_DR
                                            ImpuestoDr.BaseDR = Math.Round(CALCULO_INVERSO, 2)

                                            Dim TrasladoDr As New List(Of TrasladoDR) From {ImpuestoDr}
                                            TrasladosDR.TrasladoDR = TrasladoDr
                                            ImpuestosDR.TrasladosDR = TrasladosDR
                                        End If
                                        'RETENCIONES
                                        If RET > 0 Then
                                            Dim RetencionesDR As New RetencionesDR
                                            Dim RetImpuestoDr As New RetencionDR

                                            IMP_RET += Math.Round(CALCULO_INVERSO * 0.04, 2)

                                            RetImpuestoDr.ImporteDR = Math.Round(CALCULO_INVERSO * 0.04, 2)
                                            RetImpuestoDr.TasaOCuotaDR = 0.04
                                            RetImpuestoDr.TipoFactorDR = "Tasa"
                                            RetImpuestoDr.ImpuestoDR = Impuesto_RET
                                            RetImpuestoDr.BaseDR = Math.Round(CALCULO_INVERSO, 2)

                                            Dim RetencionDR As New List(Of RetencionDR)
                                            Dim _RetencionesDR As New List(Of RetencionesDR)

                                            RetencionDR.Add(RetImpuestoDr)
                                            RetencionesDR.RetencionDR = RetencionDR
                                            ImpuestosDR.RetencionesDR = RetencionesDR
                                            'FIN RETENCIONES
                                        End If  '_ImpuestosDR.Add(ImpuestosDR)

                                        '_comprobante.Complemento.Pagos.Pago          montoTotalPagos += p.Monto * p.TipoCambioP
                                        If IVA = 0 And RET = 0 Then
                                            ImpuestoDr.ImporteDR = "0.00"
                                            ImpuestoDr.TasaOCuotaDR = "0.000000"
                                            ImpuestoDr.TipoFactorDR = "Tasa"
                                            ImpuestoDr.ImpuestoDR = Impuesto_DR

                                            If dr2("MONEDADR") = "USD" Then
                                                ImpuestoDr.BaseDR = SUBT
                                            Else
                                                ImpuestoDr.BaseDR = dr2("IMPPAGADO")
                                            End If

                                            Dim TrasladoDr As New List(Of TrasladoDR) From {ImpuestoDr}
                                            TrasladosDR.TrasladoDR = TrasladoDr
                                            ImpuestosDR.TrasladosDR = TrasladosDR
                                        End If

                                        If dr2("MONEDADR") = "USD" Then
                                            IMPORTE += dr2("CAN_TOT")
                                        Else
                                            IMPORTE += dr2("IMPPAGADO")
                                        End If
                                        Tdr.ImpuestosDR = ImpuestosDR

                                        Try
                                            SQL1 = "UPDATE CFDI_COMPAGO_PAR_DR SET OBJETOIMPDR = '" & ObjetoImpDR & "', 
                                                TIMPORTEDR = " & (dr2("IMPPAGADO") * 0.16) & ", TTASAOCUOTADR = 0.16, 
                                                TTIPOFACTORDR = 'Tasa', TIMPUESTODR = '" & Impuesto_DR & "',
                                                TBASEDR = " & dr2("IMPPAGADO") & ", RIMPORTEDR = " & dr2("IMPPAGADO") * 0.04 & ",
                                                RTASAOCUOTADR = 0.04, RTIPOFACTORDR = 'Tasa', RIMPUESTODR = '" & Impuesto_RET & "',
                                                RBASEDR = " & dr2("IMPPAGADO") & " WHERE 
                                                CVE_DOC = '" & CVE_DOC & "' AND NUMPARCIALIDAD = " & dr2("NUMPARCIALIDAD")
                                            EXECUTE_QUERY_NET(SQL1)
                                        Catch ex As Exception
                                            BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        '_ImpuestosP.Add(ImpuestosP)
                                        _documentosRelacionados.Add(Tdr)
                                        pago.DoctoRelacionado = _documentosRelacionados
                                        'pago.Impuestos = RetencionesTP
                                        '_ImpuestosP.Add(ImpuestosP)
                                        'pago.Impuestos.RetencionesP
                                        'pago.Impuestos = ImpuestosP
                                        '▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End While

                    'AQUI SE AGREGA LOS IMPUESTOS P

                    '▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
                    Dim ImpuestosP As New ImpuestosP
                    Dim TrasladoP As New List(Of TrasladoP)
                    Dim ITrasladoP As New TrasladoP
                    Dim TrasladosP As New TrasladosP
                    'IMPUESTOP TRASLADO     PARTIDA 1 
                    If IVA_SUM = 0 Then
                        ITrasladoP.TipoFactorP = "Tasa"
                        ITrasladoP.ImpuestoP = "002"

                        ITrasladoP.BaseP = IMPORTE

                        TrasladoP.Add(ITrasladoP)
                    End If
                    If IVA_SUM > 0 Then
                        ITrasladoP.ImporteP = IMP_IVA
                        ITrasladoP.TasaOCuotaP = "0.160000"
                        ITrasladoP.TipoFactorP = "Tasa"
                        ITrasladoP.ImpuestoP = "002"
                        ITrasladoP.BaseP = CALC_IVA
                        TrasladoP.Add(ITrasladoP)
                    End If

                    TrasladosP.TrasladoP = TrasladoP
                    ImpuestosP.TrasladosP = TrasladosP
                    If RET_SUM > 0 Then 'IMPUESTOP RETENCIONES
                        Dim RetencionP As New List(Of RetencionP)
                        Dim IRetencionP As New RetencionP
                        Dim RetencionesP As New RetencionesP
                        'Dim RetencionesP As New RetencionesP 'TOTALRETENCIONESIEPS
                        IRetencionP.ImporteP = IMP_RET
                        IRetencionP.ImpuestoP = "002"
                        RetencionP.Add(IRetencionP)

                        'TOTALRETENCIONESISR 'TOTALRETENCIONESIVA
                        RetencionesP.RetencionP = RetencionP
                        ImpuestosP.RetencionesP = RetencionesP
                    End If

                    pago.Impuestos = ImpuestosP

                    _comprobante.Complemento.Pagos.Pago.Add(pago)

                    TOTALTRASLADOSBASEIVAEXENTO += 0
                    TOTALTRASLADOSIMPUESTOIVA0 += 0


                    TOTALTRASLADOSBASEIVA0 += TOTAL_MXN

                    TOTALTRASLADOSIMPUESTOIVA8 += 0
                    TOTALTRASLADOSBASEIVA8 += 0
                    TOTALTRASLADOSIMPUESTOIVA16 += IMP_IVA
                    TOTALTRASLADOSBASEIVA16 += BASE_PT

                    TOTALRETENCIONESIEPS += 0
                    TOTALRETENCIONESISR += 0
                    TOTALRETENCIONESIVA += Math.Abs(IMP_RET)

                    'PROCESO FINAL
                    'TOTALES Y IMPUESTOS
                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosBaseIVAExento = TOTALTRASLADOSBASEIVAEXENTO
                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosBaseIVA0 = TOTALTRASLADOSBASEIVA0
                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosBaseIVA8 = TOTALTRASLADOSBASEIVA8
                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosBaseIVA16 = TOTALTRASLADOSBASEIVA16

                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosImpuestoIVA0 = TOTALTRASLADOSIMPUESTOIVA0

                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosImpuestoIVA8 = TOTALTRASLADOSIMPUESTOIVA8
                    _comprobante.Complemento.Pagos.Totales.TotalTrasladosImpuestoIVA16 = IMP_IVA

                    _comprobante.Complemento.Pagos.Totales.TotalRetencionesIEPS = 0
                    _comprobante.Complemento.Pagos.Totales.TotalRetencionesISR = TOTALRETENCIONESISR
                    _comprobante.Complemento.Pagos.Totales.TotalRetencionesIVA = IMP_RET

                    '_comprobante.Complemento.Pagos.Pago.Add(pago)

                    CalculaTotales()

                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Dim errorC As New CError()

        If Not errorC.HayError Then

        End If

        'pollo

        PassData9 = ISUSD

        _comprobante.Serie = GET_ONLY_LETTER(CVE_DOC)
        _comprobante.Folio = GetNumeric(CVE_DOC)

        Dim rutaPFX As String = gRutaPFX
        Dim rutaCertificado As String = gRutaCertificado

        Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\PAGO-" & LtRFC.Text & "-" & CVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\PAGO-" & LtRFC.Text & "-" & CVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO_CON_PRECIOS As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\PAGO-" & LtRFC.Text & "-" & CVE_DOC & ".xml"

        XML_BK = RutaXML_TIMBRADO_CON_PRECIOS

        RUTA_PDF = gRutaXML_TIMBRADO & "\" & LtRFC.Text & "-" & CVE_DOC & ".pdf"

        Dim xml As XmlDocument = GenerarXML.ObtenerXML(_comprobante, rutaPFX, gContraPFX, rutaCertificado)
        xml.Save(RutaXML_NO_TIMBRADO)

        Dim q As New BasicHttpBinding(BasicHttpSecurityMode.None) With {.MaxBufferSize = 2147483646, .MaxBufferPoolSize = 2147483646, .MaxReceivedMessageSize = 2147483646}
        q.ReaderQuotas.MaxArrayLength = 2147483646
        q.ReaderQuotas.MaxBytesPerRead = 2147483646
        q.ReaderQuotas.MaxDepth = 2147483646
        q.ReaderQuotas.MaxNameTableCharCount = 2147483646
        q.ReaderQuotas.MaxStringContentLength = 2147483646

        If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
            TimbreOK = True
            RUTA_XML = RutaXML_TIMBRADO

            'Dim rutaPDF As String = gRutaXML_NO_TIMBRADO & "\" & LtRFC.Text & "-" & CVE_DOC.Trim & ".pdf"
            'CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF, Application.StartupPath & "\logo.jpg", False)
            For k = 1 To 5
                SQL = "UPDATE CFDI_COMPAGO SET ESTATUS = 'T', XML = '" & CFDI_XML_DIGIBOX & "', FECHA_TIMBRADO = GETDATE() WHERE CVE_DOC = @CVE_DOC"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue = "1" Then
                            Exit For
                        End If
                    End Using
                Catch ex As Exception
                    BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                End Try
                If Not Valida_Conexion() Then
                End If
            Next

            Var17 = "OK"

            Me.Cursor = Cursors.Default

            MsgBox("Documento timbrado")

            LtT.Visible = True
            ChEnviarXCorreo.Visible = True
            ChImprimir.Visible = True
            BtnAceptar.Visible = True
            BtnCancelar.Visible = True
        Else
            Me.Cursor = Cursors.Default
            Dim msg As Object

            msg = New VtlMessageBox(VisualStyle.Office2010Blue)
            Dim Result As String
            With msg
                '.AddImageToMoreText("gridImage", img)
                .MessageText = "Complemento de pago NO timbrado"
                '.MoreText = "-----"
                .AddStandardButtons(MessageBoxButtons.OK)
                .Caption = "Proceso terminado"
                .Icon = MessageBoxIcon.Error

                .MessageBoxPosition = FormStartPosition.CenterScreen
                Result = .Show()

                Me.Close()

            End With
        End If

        Me.Cursor = Cursors.Default
        Application.UseWaitCursor = False
        Me.UseWaitCursor = False

    End Sub
    Private Function CALCULA_CALC_INVERSO(FMONTO As Decimal, FIVA As Decimal, FRET As Decimal) As Decimal
        Dim CALCULO As Decimal = 0
        Try
            'X + X(-0.04 + 0.16) = 60
            CALCULO = 1 + (FIVA + FRET)
            CALCULO = FMONTO / CALCULO
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CALCULO
    End Function
    Private Sub CalculaTotales()
        Try
            Dim montoTotalPagos As Decimal = 0, TrasBaseIVAExento As Decimal = 0

            For Each p As Pago In _comprobante.Complemento.Pagos.Pago

                montoTotalPagos += p.Monto * p.TipoCambioP

            Next

            _comprobante.Complemento.Pagos.Totales.MontoTotalPagos = montoTotalPagos
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub IMPRIMIR_CFDI(FCVE_DOC As String, Optional FPDF As String = "", Optional FCVE_VIAJE As String = "")
        Try
            Dim UUID As String, RUTA_PDF_PRECIOS As String = ""
            Try
                Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""

                RUTA_FORMATOS = GET_RUTA_FORMATOS()

                Select Case PassData1
                    Case "PAGO COMPLEMENTO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\PAGO-" & LtRFC.Text & "-" & CVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\PAGO-" & LtRFC.Text & "-" & CVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIPAGO" & Empresa & ".mrt"

                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIPAGO.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        UUID = BUSCAR_UUID_CFDI_PAGO(FCVE_DOC)
                    Case "FACTURA"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & LtRFC.Text & "-" & CVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & LtRFC.Text & "-" & CVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIFACTURA" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIFACTURA.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        UUID = BUSCAR_UUID_CFDI40(FCVE_DOC)
                    Case "CARTA PORTE TRASLADO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & LtRFC.Text & "-" & CVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & LtRFC.Text & "-" & CVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                    Case "CARTA PORTE BUENO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & CVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                End Select
                'Var10 = FECHA_TIMBRADO
                'Var11 = FECHA_EXP
                'Var12 = SELLO_SAT
                'Var13 = NO_CERTIFICADO_SAT
                'Var14 = SELLO_CFD
                StiReport1.Load(ARCHIVO_MRT)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
                StiReport1.Compile()

                Select Case PassData1
                    Case "PAGO COMPLEMENTO"
                        StiReport1("CVE_DOC") = FCVE_DOC
                        StiReport1.ReportName = "Complemento de pago 4.0"
                    Case "FACTURA"
                        StiReport1.Item("CVE_DOC") = FCVE_DOC
                        StiReport1.ReportName = "Factura CFDI 4.0"
                    Case "CARTA PORTE TRASLADO"
                        StiReport1.Item("CVE_DOC") = FCVE_DOC
                        StiReport1.ReportName = "Carta porte traslado"
                    Case "CARTA PORTE BUENO"

                        Dim IMPORTE As Decimal = 0, CVE_MONED As String = "MXN", TIPO_CAMBIO As Decimal = 0
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT IMPORTE, CVE_MONED, TIPCAMB 
                                FROM FACTF" & Empresa & " F
                                LEFT JOIN MONED" & Empresa & " M ON M.NUM_MONED = F.NUM_MONED 
                                WHERE CVE_DOC = '" & FCVE_DOC & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        IMPORTE = dr("IMPORTE")
                                        CVE_MONED = dr("CVE_MONED")
                                        TIPO_CAMBIO = dr("TIPCAMB")
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            BITACORACFDI("360. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Dim entero As Integer = Int(IMPORTE)
                        Dim decimales As Double = IMPORTE - entero
                        Dim NUMTOLET As String
                        NUMTOLET = "** ( " + Num2Text(entero) + " PESOS " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + "/100 M.N.)**"


                        StiReport1("CVE_VIAJE") = FCVE_VIAJE
                        StiReport1("CVE_DOC") = FCVE_DOC
                        StiReport1("NUMTOLETRA") = NUMTOLET
                        StiReport1.ReportName = "Carta porte"
                End Select
                If PassData1 = "FACTURA" Then
                    StiReport1.Item("CVE_DOC_REL") = FCVE_DOC
                End If
                StiReport1.Render()

                If FPDF = "PDF" Then
                    StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                Else
                    StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                    StiReport1.Show()
                End If
            Catch ex As Exception
                MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function GetConcepto() As Concepto
        Dim c As New Concepto With {
            .ClaveProdServ = "84111506",
            .ClaveUnidad = "ACT",
            .ValorUnitario = 0,
            .Importe = 0,
            .Cantidad = 1,
            .Descripcion = "Pago",
            .ObjetoImp = "01"
        }
        Return c
    End Function
    Private Sub CalculaTotalesCFDI()
        _comprobante.Impuestos = GetImpuestosCFDI(_comprobante.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _comprobante.Conceptos.Concepto
            subtotal += c.Importe
            descuento = c.Descuento
        Next

        _comprobante.SubTotal = subtotal
        _comprobante.Descuento = descuento
        _comprobante.Total = subtotal - _comprobante.Impuestos.TotalImpuestosRetenidos + _comprobante.Impuestos.TotalImpuestosTrasladados
        _comprobante.TotalLetra = New Numalet().ToCustomString(_comprobante.Total)

    End Sub
    Private Sub FrmTimbrarCdeP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String, strMetodoPago As String
        Dim strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String
        Dim strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String
        Dim NoCertificadoSAT As String, UUID As String = "", UUIDR As String, FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String
        Dim Monto As String, FormaDePagoP As String, FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String
        Dim ImpPagado As String, ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String
        Dim concepto As XmlNodeList, Elemento As XmlNode, subnodo As XmlElement, IdDocumento As String
        Dim XML As String, xDoc As XmlDocument, xNodo As XmlNodeList, xAtt As XmlElement, Comprobante As XmlNode, Impuestos As XmlNode = Nothing
        Dim totalImpuestosTrasladados As Decimal, TotalImpuestosRetenidos As Decimal, vsTIT As Decimal, k As Integer


        'aqui
        If fFILE_XML.Trim.Length = 0 Then
            Return ""
        End If

        XML = Application.StartupPath & "\TEMPOLXML.xml"
        File.WriteAllText(XML, fFILE_XML)

        If Not File.Exists(XML) Then
            Return ""
        End If

        strEmisorRfc = ""
        strTipoComprobante = "" : strUsoCFDI = ""

        xDoc = New XmlDocument

        Try
            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try

                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")
                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")

                            SerieCFD = VarXml(xAtt, "Serie")
                            FolioCFD = VarXml(xAtt, "Folio")

                            FechaEmision = strFechaEmision
                            TotalCFD = strTotal
                            SubtotalCFD = strSubtotal

                            VersionCFD = strVersion
                            MonedaCFD = strMoneda
                            FormaPagoCFD = BUSCAR_FORMA_PAGO(strFormaPago)
                            VersionCFD = strVersion
                            UsoCFDICFD = strUsoCFDI
                            TipoComprobanteCFD = IIf(strTipoComprobante = "I", "Ingreso", "Egreso")
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo

                                strEmisorRfc = VarXml(xAtt, "rfc")
                                Try
                                    If strEmisorRfc.Trim.Length = 0 Then
                                        strEmisorRfc = VarXml(xAtt, "Rfc")
                                    End If
                                Catch ex As Exception
                                    Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                strEmisorNombre = VarXml(xAtt, "nombre")
                                Try
                                    If strEmisorNombre.Trim.Length = 0 Then
                                        strEmisorNombre = VarXml(xAtt, "Nombre")
                                    End If
                                Catch ex As Exception
                                    Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            EmisorRfcCFD = strEmisorRfc
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        If Not IsNothing(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados")) Then
                            totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados").Value)
                        End If
                    Catch ex As Exception
                        totalImpuestosTrasladados = 0
                    End Try
                    If totalImpuestosTrasladados = 0 Then
                        Try
                            Impuestos = Comprobante("cfdi:Impuestos")
                            If Not IsNothing(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados")) Then
                                totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados").Value)
                            End If
                        Catch ex As Exception
                            totalImpuestosTrasladados = 0
                        End Try
                    End If
                    Try
                        If totalImpuestosTrasladados = 0 Then
                            vsTIT = 0
                            k = 1
                            For Each vRegIT As XmlElement In Impuestos.ChildNodes
                                If vRegIT.Name = "cfdi:Traslados" Then
                                    If Not IsNothing(vRegIT.FirstChild.Attributes("importe")) Then
                                        vsTIT += CDec(vRegIT.FirstChild.Attributes("importe").Value)
                                    End If
                                End If
                            Next
                        Else
                            vsTIT = totalImpuestosTrasladados
                        End If
                    Catch ex As Exception
                        'Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    IVAcfd = totalImpuestosTrasladados


                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        If Not IsNothing(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos")) Then
                            TotalImpuestosRetenidos = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosRetenidos").Value)
                        End If
                    Catch ex As Exception
                        TotalImpuestosRetenidos = 0
                    End Try

                    RETcfd = TotalImpuestosRetenidos


                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                                UsoCFD = strUsoCFDI
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try

        Return UUID

    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function
    Private Sub TCORREO_CTE_Leave(sender As Object, e As EventArgs) Handles TCORREO_CTE.Leave
        Try
            If TCORREO_CTE.Text.Trim.Length > 0 Then
                If Validar_Mail(LCase(TCORREO_CTE.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                        por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TCORREO_CTE.Focus()
                    TCORREO_CTE.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCORREO1_Leave(sender As Object, e As EventArgs) Handles TCORREO1.Leave
        Try
            If TCORREO1.Text.Trim.Length > 0 Then
                If Validar_Mail(LCase(TCORREO1.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                        por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TCORREO1.Focus()
                    TCORREO1.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCORREO2_Leave(sender As Object, e As EventArgs) Handles TCORREO2.Leave
        Try
            If TCORREO2.Text.Trim.Length > 0 Then
                If Validar_Mail(LCase(TCORREO2.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                        por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TCORREO2.Focus()
                    TCORREO2.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCORREO3_Leave(sender As Object, e As EventArgs) Handles TCORREO3.Leave
        Try
            If TCORREO3.Text.Trim.Length > 0 Then
                If Validar_Mail(LCase(TCORREO3.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                        por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TCORREO3.Focus()
                    TCORREO3.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCORREO3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO3.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TCORREO_CTE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO_CTE.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub
    Private Sub TCORREO1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO1.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        Ruta_Framework = ""
        Try
            If ChEnviarXCorreo.Checked Then
                Try
                    IMPRIMIR_CFDI(CVE_DOC, "PDF")

                    Dim MensaDia As String = ""
                    Dim aCorreo As New ArrayList From {RUTA_PDF, RUTA_XML}
                    Dim horaActual As String
                    horaActual = DateTime.Now.ToString("HH:mm")
                    If horaActual >= "24:00" And horaActual <= "12:00" Then
                        MensaDia = "Buenos Días"
                    ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                        MensaDia = "Buenas Tardes"
                    ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                        MensaDia = "Buenas Noches"
                    End If

                    If TCORREO_CTE.Text.Length > 0 Or TCORREO1.Text.Length > 0 Or TCORREO2.Text.Length > 0 Or TCORREO3.Text.Length > 0 Then

                        SendEmail(TCORREO_CTE.Text, "Comprobamte CFDI",
                            MensaDia & vbCrLf & vbCrLf &
                            "Documento " & CVE_DOC & vbCrLf &
                            "Ajunto se envia representacion CFDI " &
                            IIf(PassData1 = "PAGO COMPLEMENTO", " complemento de pago", "Factura en formato PDF") & vbCrLf & vbCrLf &
                             EMISOR_RAZON_SOCIAL, aCorreo, TCORREO_CTE.Text, TCORREO1.Text, TCORREO2.Text, TCORREO3.Text)
                    End If
                Catch ex As Exception
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Else
                IMPRIMIR_CFDI(CVE_DOC, "PDF", PassData8)
            End If

            If ChImprimir.Checked Then
                Var18 = "SI"
                Var16 = RUTA_PDF
                Ruta_Framework = "SI"
            Else
                Var18 = ""
            End If
            Me.Close()

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CREA_PDF_STI(FREPORT As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\" & FREPORT & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                Return
            End If

            StiReport1.Load(ARCHIVO_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                       Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.ReportName = "Complemento de pago"

            StiReport1.Compile()
            StiReport1.Item("CVE_DOC") = LtCVE_DOC.Text

            StiReport1.Render()
            StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
        Catch ex As Exception
            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click

        Me.Close()
    End Sub

    Private Sub TCORREO2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO2.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub
    Private Sub FrmTimbrarCdeP_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

        Me.BringToFront()

    End Sub


    Sub PROCESO_CFD_CARTA_PORTE_BUENO_40()
        Dim Descripcion As String = "", ClaveUnidad As String = "", DescripEmbalaje As String = "", EMBALAJE As String = "", CveMaterialPeligroso As String = ""
        Dim MaterialPeligroso As String = "", BienesTransp As String = "", ClaveProdServ As String = "", NoIdentificacion As String = "", KMRECORRIDOS As Decimal = 0
        Dim MetodoPago As String, FormaPago As String, USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim CVE_BITA As Long, UUID_TIMBRADO As String, FECHA_T1 As DateTime, FECHA_T2 As String = Now, USO_CFDI As String = "", REG_FISC As String = ""
        Dim RFC_RECEP As String = "", CP_RECEP As String = "", CALLE As String, DETEC_ERROR_VIOLATION_KEY As Boolean = False, CVE_PRODSERV As String = ""
        Dim CVE_UNIDAD As String = "", NOMBRE_CLIENTE As String = "", CLIENTE As String = "", FECHA_CARGA As String = "", FECHA_DESCARGA As String = ""
        Dim CVE_MONED As String = "", NUM_MONED As Integer, TIPO_CAMBIO As Decimal, FORMADEPAGOSAT As String = "", METODODEPAGO As String = "", SERIE_BUENO As String
        Dim FOLIO_BUENO As Long, CVE_ESQIMPU As Integer, NOM_OPER As String, LICENCIA As String = "", VIGENCIA As String, CVE_OPER As Integer, ObjetoImp As String
        Dim CVE_TRACTOR As String = "", CVE_DOLLY As String, CVE_VIAJE As String, CLAVE_O As String = "", CLAVE_D As String = ""
        Dim SUB_TOTAL As Decimal, IVA As Decimal, RET As Decimal, NETO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal
        Dim INCOTERM As String = "", CLAVEPEDIMENTO As String = "", FDTIPOOPERACION As String, CVE_TAB_RUTA As String
        Dim NOMBRE_OPERADOR As String = "", RFC_OPERADOR As String = "", CALLE_OPERADOR As String = ""
        Dim COLONIA_OPERADOR As String = "", LOCALIDAD_OPERADOR As String = "", CODIGOPOSTAL_OPERADOR As String = ""
        Dim ESTADO_OPERADOR As String = "", MUNICIPIO_OPERADOR As String = "", PAIS_OPERADOR As String = ""

        If Not Valida_Conexion() Then
            Return
        End If

        CVE_VIAJE = PassData8

        SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.FECHA_CARGA, A.FECHA_DESCARGA, A.STATUS, 
            ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, ISNULL(CVE_ST_VALE,1) AS STATUS_VALE, 
            ISNULL(A.CVE_ST_UNI,0) AS STATUS_UNI, A.TIPO_UNI, A.TIPO_VIAJE, A.CVE_OPER, A.CVE_CON, 
            A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA, 
            ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, ISNULL(A.CVE_TAB, '') AS CVETAB, 
            ISNULL(A.CVE_TAB_VIAJE,0) AS TAB_VIAJE, ISNULL(R.CVE_TAB,'') AS CVE_TAB_RUTA, A.CLIENTE, 
            C.NOMBRE AS NOMBRE_CLIE, A.CVE_MONED, A.VOLUMEN_PESO, PRECIO_VIAJE_TONE, IMPORTE_CONCEP, CVE_COBRO,  
			ISNULL(SUBTOTAL,0) AS SUBT, ISNULL(IVA,0) AS IV, ISNULL(RETENCION,0) AS RET, ISNULL(NETO,0) AS NET, 
            ISNULL(CANT,0) AS CANTIDAD, ISNULL(A.FLETE,0) AS FLET, ISNULL(A.CVE_ESQIMPU,0) AS CVE_ESQ, C.FORMADEPAGOSAT, 
            C.USO_CFDI, C.METODODEPAGO, SERIE, FOLIO, A.CVE_COBRO, CVE_PRODSERV, R.KMS, CVE_UNIDAD, A.TIPO_CAMBIO,
            ISNULL(A.TIPO_FACTURACION,'') AS TIPO_FAC
            FROM GCASIGNACION_VIAJE A 
            LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = A.CVE_TAB
            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = A.CLIENTE
            WHERE A.CVE_VIAJE = '" & CVE_VIAJE & "'"

        Try
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Try
                            CLAVE_O = dr("ORIGEN")
                            CLAVE_D = dr("DESTINO")

                            FECHA_CARGA = dr("FECHA_CARGA").ToString
                            FECHA_DESCARGA = dr("FECHA_DESCARGA").ToString
                            CLIENTE = dr.ReadNullAsEmptyString("CLIENTE")
                            NOMBRE_CLIENTE = dr("NOMBRE_CLIE")
                            NUM_MONED = dr.ReadNullAsEmptyInteger("CVE_MONED")
                            KMRECORRIDOS = dr.ReadNullAsEmptyDecimal("KMS")
                            CVE_TAB_RUTA = dr("CVE_TAB_RUTA")
                            If NUM_MONED = "0" Then
                                NUM_MONED = 1
                            End If
                            If NUM_MONED > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand

                                    SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED  FROM MONED" & Empresa & " WHERE NUM_MONED = " & NUM_MONED
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            CVE_MONED = dr2("CVE_MONED")
                                        End If
                                    End Using
                                End Using

                                TIPO_CAMBIO = dr.ReadNullAsEmptyDecimal("TIPO_CAMBIO")

                            Else
                                CVE_MONED = "MXN"
                                TIPO_CAMBIO = 1
                            End If
                            FORMADEPAGOSAT = dr("FORMADEPAGOSAT")
                            USO_CFDI = dr("USO_CFDI")
                            METODODEPAGO = dr("METODODEPAGO")
                            SERIE_BUENO = dr.ReadNullAsEmptyString("SERIE")
                            FOLIO_BUENO = dr.ReadNullAsEmptyLong("FOLIO")

                            If dr("TIPO_FAC") = "3" Then
                                CVE_DOC = PassData4
                            Else
                                CVE_DOC = SERIE_BUENO & FOLIO_BUENO
                            End If
                            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                            CVE_OPER = dr("CVE_OPER")
                            If CVE_OPER.ToString.Trim.Length > 0 Then

                                NOM_OPER = BUSCA_CAT("Operador", dr("CVE_OPER").ToString)

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT ISNULL(NOMBRE,'') AS DES, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE CLAVE = '" & dr("CVE_OPER") & "' AND STATUS  = 'A'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            LICENCIA = dr2("LICENCIA")
                                            VIGENCIA = dr2("LIC_VENC")
                                        End If
                                        dr2.Close()
                                    End Using
                                End Using
                            End If
                            CVE_TRACTOR = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                            Tanque1 = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                            Tanque2 = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString
                            CVE_DOLLY = dr.ReadNullAsEmptyString("CVE_DOLLY").ToString

                            CVE_PRODSERV = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            CVE_UNIDAD = dr.ReadNullAsEmptyString("CVE_UNIDAD")

                            CVE_ESQIMPU = dr("CVE_ESQ")

                            'SUB_TOTAL = dr("SUBT")
                            'RET = dr("RET")
                            'IVA = dr("IV")
                            'NETO = dr("NET")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End Using
            End Using
            If KMRECORRIDOS = 0 Then
                MsgBox("Km recorrido no capturados en el la ruta " & CVE_TAB_RUTA)
                Return
            End If
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4
                        FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        IMPU1 = dr("IMPUESTO1")
                        IMPU2 = dr("IMPUESTO2")
                        IMPU3 = dr("IMPUESTO3")
                        IMPU4 = dr("IMPUESTO4")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(NOMBRE,'') AS NOMB, ISNULL(USO_CFDI,'') AS USOCFDI, ISNULL(REG_FISC,'') AS REGFISC,
                        RFC, CODIGO AS CP, CALLE
                        FROM CLIE" & Empresa & " WHERE CLAVE = '" & CLIENTE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NOMBRE_CLIENTE = dr("NOMB")
                        USO_CFDI = dr("USOCFDI")
                        REG_FISC = dr("REGFISC")
                        RFC_RECEP = dr("RFC")
                        CP_RECEP = dr("CP")
                        CALLE = dr("CALLE")
                    End If
                End Using
            End Using
            If NOMBRE_CLIENTE.Trim.Length = 0 Or USO_CFDI.Trim.Length = 0 Or REG_FISC.Trim.Length = 0 Then
                MsgBox("Por favor verifique los datos NOMBRE, USO_CFDI, REG_FISC del cliente " & CLIENTE)
                Return
            End If

            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCOPERADOR WHERE CLAVE = " & CVE_OPER
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    If dr2.Read Then
                        NOMBRE_OPERADOR = dr2.ReadNullAsEmptyString("NOMBRE")
                        RFC_OPERADOR = dr2.ReadNullAsEmptyString("RFC")
                        CALLE_OPERADOR = dr2.ReadNullAsEmptyString("CALLE")
                        COLONIA_OPERADOR = dr2.ReadNullAsEmptyString("COLONIA_SAT")
                        CODIGOPOSTAL_OPERADOR = dr2.ReadNullAsEmptyString("CP_SAT")
                        ESTADO_OPERADOR = dr2.ReadNullAsEmptyString("ESTADO_SAT")
                        MUNICIPIO_OPERADOR = dr2.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        LICENCIA = dr2.ReadNullAsEmptyString("LICENCIA")
                    Else
                        PAIS_OPERADOR = "NO EXIXTE"
                    End If
                End Using
            End Using

            If RFC_OPERADOR.Trim.Length = 0 Then
                MsgBox("Por favor capture el RFC del Operador")
                Return
            End If
            If LICENCIA.Trim.Length = 0 Then
                MsgBox("Por favor capture la licencia")
                Return
            End If
            If NOMBRE_OPERADOR.Trim.Length = 0 Then
                MsgBox("Por favor capture el NOMBRE del operador")
                Return
            End If
            If CALLE_OPERADOR.Trim.Length = 0 Then
                MsgBox("por favor capture la CALLE del operador")
                Return
            End If

            If MUNICIPIO_OPERADOR.Trim.Length = 0 Then
                MsgBox("Por favor capture el MUNICIPIO del operador")
                Return
            End If
            If COLONIA_OPERADOR.Trim.Length = 0 Then
                MsgBox("Por favor capture la COLONIA del operador")
                Return
            End If
            If ESTADO_OPERADOR.Trim.Length = 0 Then
                MsgBox("Por favor capture el ESTADO del operador")
                Return
            End If

            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CAN_TOT, IMP_TOT3, IMP_TOT4, IMPORTE
                     FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NETO = dr("IMPORTE")
                        IVA = dr("IMP_TOT4")
                        RET = dr("IMP_TOT3")
                        SUB_TOTAL = dr("CAN_TOT")
                    End If
                End Using
            End Using
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            Me.Cursor = Cursors.WaitCursor
            CP_OBSER_CFDI = ""
            RefreshDataBindings() 'SERIE Y FOLIO

            ObjetoImp = "02"
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
            If PassData3 = "222222" Then
                Try
                    Dim VIMPU1 As Decimal, VIMPU2 As Decimal, VIMPU3 As Decimal, VIMPU4 As Decimal

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT CVE_VIAJE, CVE_ESQIMPU, CVE_PRODSERV, CVE_UNIDAD, SUBTOTAL, IVA, RETENCION, NETO
                            FROM GCASIGNACION_BUENO A
                            WHERE CVE_DOC = '" & PassData4 & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4
                                        FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & dr.ReadNullAsEmptyInteger("CVE_ESQIMPU")
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            VIMPU1 = dr2("IMPUESTO1")
                                            VIMPU2 = dr2("IMPUESTO2")
                                            VIMPU3 = dr2("IMPUESTO3")
                                            VIMPU4 = dr2("IMPUESTO4")
                                        End If
                                    End Using
                                End Using

                                If IMPU1 = 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 = 0 Then
                                    ObjetoImp = "01"
                                Else
                                    ObjetoImp = "02"
                                End If

                                Dim c As New Concepto With {
                                .Cantidad = 1,
                                .ClaveProdServ = dr.ReadNullAsEmptyString("CVE_PRODSERV"),
                                .ClaveUnidad = dr.ReadNullAsEmptyString("CVE_UNIDAD"),
                                .Descripcion = "FLETE",
                                .Descuento = 0,
                                .Importe = dr.ReadNullAsEmptyDecimal("SUBTOTAL"),
                                .NoIdentificacion = dr.ReadNullAsEmptyString("CVE_VIAJE"),
                                .Unidad = "SERVICIO",
                                .ValorUnitario = dr.ReadNullAsEmptyDecimal("SUBTOTAL"),
                                .Impuestos = GetImpuestosConcepto(dr.ReadNullAsEmptyDecimal("SUBTOTAL"), 1, 0, 0, 0, VIMPU3, VIMPU4),
                                .ObjetoImp = "" & ObjetoImp & ""}
                                _comprobante.Conceptos.Concepto.Add(c)
                            End While
                        End Using
                    End Using

                    CalculaTotalesCFDI()
                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            Else
                Try
                    Dim c As New Concepto With {
                                .Cantidad = 1,
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = "FLETE",
                                .Descuento = 0,
                                .Importe = SUB_TOTAL,
                                .NoIdentificacion = "",
                                .Unidad = "SERVICIO",
                                .ValorUnitario = SUB_TOTAL,
                                .Impuestos = GetImpuestosConcepto(SUB_TOTAL, 1, 0, 0, 0, IMPU3, IMPU4),
                                .ObjetoImp = "02"}
                    _comprobante.Conceptos.Concepto.Add(c)

                    CalculaTotalesCFDI()

                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO

            ASIG_CFD_EMISOR_RECEPTOR(CVE_MONED, METODODEPAGO, FORMADEPAGOSAT, SUB_TOTAL, 0, NETO, USO_CFDI, NOMBRE_CLIENTE, RFC_RECEP, CP_RECEP, REG_FISC, "I", TIPO_CAMBIO) 'DATOS EMISOR Y RECEPTOR

            DATOS_CARTA_PORTE_BUENO(CVE_VIAJE, FECHA_CARGA, FECHA_DESCARGA, CVE_TRACTOR, Tanque1, Tanque2, CVE_OPER, CLAVE_O, CLAVE_D, KMRECORRIDOS)


            CLAVEPEDIMENTO = "A1"
            FDTIPOOPERACION = "2"

            'AGREGAR_ADDENDA_COMERCIO_EXTERIOR(CVE_VIAJE, NETO, TIPO_CAMBIO, INCOTERM, CLAVEPEDIMENTO, FDTIPOOPERACION, CLAVE_O, CLAVE_D)
            'AGREGAR_ADDENDA_COMERCIO_EXTERIOR(FTOTALUSD As Decimal, FTIPOCAMBIO As Decimal, FINCOTERM As String, FCLAVEPEDIMENTO As String,FDTIPOOPERACION As String)

            Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & CVE_DOC & ".xml"
            Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & CVE_DOC & ".xml"

            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\XML_BAK") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\XML_BAK")
                End If
                XML_BK = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".xml"
            Catch ex As Exception
            End Try

            Dim rutaPFX As String = gRutaPFX
            Dim rutaCertificado As String = gRutaCertificado

            Dim rutaPDF As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_DOC & ".pdf"
            Dim rutaPDF2 As String = gRutaXML_TIMBRADO_SIN_PRECIOS & "\" & CVE_DOC & ".pdf"

            Dim errorC As CError = _comprobante.EsInfoCorrecta()

            If TIMBRADO_DEMO = "Si" Then
                USUAARIO_TIMB = "demo2"
                PASS_TIMB = "123456789"
            Else
                USUAARIO_TIMB = gUSUARIO_PAC
                PASS_TIMB = gPASS_PAC
            End If
            CFDI_XML_DIGIBOX = ""
            'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
            If Not errorC.HayError Then

                If Not IO.File.Exists(rutaPFX) Then
                    MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
                    Return
                End If
                If Not IO.File.Exists(rutaCertificado) Then
                    MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                    Return
                End If
                Var46 = "" 'NOCERTIFICADO
                CFDI_XML_DIGIBOX = ""
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_CON_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_SIN_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                Dim xml As XmlDocument = GenerarXML.ObtenerXML(_comprobante, rutaPFX, gContraPFX, rutaCertificado)
                xml.Save(RutaXML_NO_TIMBRADO)

                'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO

                TIMBRADO_OK = False

                If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
                    TimbreOK = True
                    TIMBRADO_OK = True

                    Var2 = "TIMBRADA"
                    Var18 = "SI"

                    MsgBox("Documento timbrado")

                Else
                    MsgBox("------------------  Documento no timbrado  ------------------")
                End If
            Else
                MessageBox.Show(errorC.Error, "Validando información...")
            End If
            Ruta_Framework = ""
            Try
                If TimbreOK Then
                    Dim MensaDia As String = ""

                    RUTA_XML = RutaXML_TIMBRADO
                    RUTA_PDF = rutaPDF


                    If Not Valida_Conexion() Then
                    End If

                    BACKUPTXT("CFDICP", CVE_DOC & "," & CVE_DOC & "," & CVE_DOC & "," & Now & "," & CFDI_XML_DIGIBOX & ",S," & USER_GRUPOCE)
                    BACKUPTXT("CFDICP", vbNewLine & "-----------------------------------------------------------------------------------------------" & vbNewLine)

                    MetodoPago = ""
                    FormaPago = ""
                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                    Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = "" : Var12 = "" : Var13 = "" : Var14 = "" : Var15 = ""
                    UUID_TIMBRADO = BUSCAR_CAMPOS_CFDI40(RutaXML_TIMBRADO)
                    Try
                        Var7 = Var10.Substring(8, 2) & "/" & Var10.Substring(5, 2) & "/" & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
                        Var8 = Var10.Substring(0, 4) & Var10.Substring(5, 2) & Var10.Substring(8, 2) & " " & Var10.Substring(11, Var10.Length - 11)
                        Dim oDate1 As DateTime = DateTime.ParseExact(Var7, "dd/MM/yyyy HH:mm:ss", Nothing)

                        FECHA_T1 = oDate1
                        FECHA_T2 = Var8

                    Catch ex As Exception
                        MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                    If Var10.Trim.Length < 10 Then
                        FECHA_T2 = Now
                    End If
                    'Var9 = NO_CERTIFICADO
                    'Var10 = FECHA_TIMBRADO
                    'Var11 = FECHA_EXP
                    'Var12 = SELLO_SAT
                    'Var13 = NO_CERTIFICADO_SAT
                    'Var14 = SELLO_CFD
                    'Var15 = RfcProvCertif
                    SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                        CLIENTE,SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID, 
                        NO_CERTIFICADO, SELLO_SAT, SELLO_CFD, NO_CERTIFICADO_SAT, RFCPROVCERTIF, UUID_CFDI, FECHA_TIMBRADO, FECHA_CFDI) 
                        VALUES (
                        @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                        @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID(), 
                        @NO_CERTIFICADO, @SELLO_SAT, @SELLO_CFD, @NO_CERTIFICADO_SAT, @RFCPROVCERTIF, @UUID_CFDI, @FECHA_TIMBRADO, @FECHA_CFDI)"
                    For k = 1 To 5
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = CVE_DOC
                                cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "T"
                                cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = GET_ONLY_LETTER(CVE_DOC)
                                cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Var10
                                cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                                cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLIENTE
                                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = SUB_TOTAL
                                cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = RET
                                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = IVA
                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = NETO
                                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = MetodoPago
                                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FormaPago
                                cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = CVE_MONED
                                cmd.Parameters.Add("@NO_CERTIFICADO", SqlDbType.VarChar).Value = Var9
                                cmd.Parameters.Add("@SELLO_SAT", SqlDbType.VarChar).Value = Var12 'mal
                                cmd.Parameters.Add("@SELLO_CFD", SqlDbType.VarChar).Value = Var14
                                cmd.Parameters.Add("@NO_CERTIFICADO_SAT", SqlDbType.VarChar).Value = Var13
                                cmd.Parameters.Add("@RFCPROVCERTIF", SqlDbType.VarChar).Value = Var15
                                cmd.Parameters.Add("@UUID_CFDI", SqlDbType.VarChar).Value = UUID_TIMBRADO
                                cmd.Parameters.Add("@FECHA_TIMBRADO", SqlDbType.VarChar).Value = Var10
                                cmd.Parameters.Add("@FECHA_CFDI", SqlDbType.DateTime).Value = FECHA_T1
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                                'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
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
                            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                        If Not Valida_Conexion() Then
                        End If
                    Next
                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                    KMRECORRIDOS = 0
                    Var8 = ""

                    CVE_BITA = GRABA_BITA(CLIENTE, CVE_DOC, 0, "X", "Carta porte traslado se le generó un CFDI")

                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO

                    Dim msg As Object
                    Me.Cursor = Cursors.Default
                    msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
                    Dim Result As String
                    With msg
                        '.AddImageToMoreText("gridImage", img)
                        .MessageText = "Carta porte TIMBRADA"

                        '.MoreText = "-----"
                        .AddStandardButtons(MessageBoxButtons.OK)
                        .Caption = "Proceso terminado"
                        .Icon = MessageBoxIcon.Information

                        .MessageBoxPosition = FormStartPosition.CenterScreen
                        Result = .Show()
                    End With

                    LtT.Visible = True
                    ChEnviarXCorreo.Checked = False
                    ChEnviarXCorreo.Visible = True
                    ChImprimir.Visible = True
                    BtnAceptar.Visible = True
                    BtnCancelar.Visible = True

                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO

                    'CARATA PORTE TIMBRADA      CARATA PORTE TRASLADO       CARATA PORTE TRASLADO 
                    'CARATA PORTE TIMBRADA      CARATA PORTE TRASLADO       CARATA PORTE TRASLADO 

                    'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO

                Else
                    'CARTA PORTE TRASLADO NO NO NOOOOOOOOOOOOOOO  TIMBRADA
                    Me.Cursor = Cursors.Default
                    Dim msg As Object
                    msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                    Dim Result As String
                    With msg
                        .MessageText = "Carta porte NO timbrado"
                        .AddStandardButtons(MessageBoxButtons.OK)
                        .Caption = "Proceso terminado"
                        .Icon = MessageBoxIcon.Error

                        .MessageBoxPosition = FormStartPosition.CenterScreen
                        Result = .Show()

                        Var2 = ""

                        If QUITAR_MAT_PELI Then
                            Me.Close()
                        End If
                        'CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO               CARTA PORTE BUENO
                    End With
                    Var2 = ""
                End If
            Catch ex As Exception
                BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORACFDI("970. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default

        If TimbreOK Then
            'Me.Close()
        End If
    End Sub
    Sub AGREGAR_ADDENDA_COMERCIO_EXTERIOR(FCVE_VIAJE As String, FTOTALUSD As Decimal, FTIPOCAMBIO As Decimal, FINCOTERM As String, FCLAVEPEDIMENTO As String,
                                          FDTIPOOPERACION As String, FCLAVE_O As String, FCLAVE_D As String)

        Dim O_RFC As String = "", O_NOMBRE As String = "", O_PAIS As String = "", O_CP As String = "", O_ESTADO As String = "", O_MUNICIPIO As String = ""
        Dim O_LOCALIDAD As String = "", O_COLONIA As String = "", O_CALLE As String = "", O_NUMINT As String = "", O_NUMEXT As String = ""
        Dim D_RFC As String = "", D_NOMBRE As String = "", D_PAIS As String = "", D_CP As String = "", D_ESTADO As String = "", D_MUNICIPIO As String = ""
        Dim D_LOCALIDAD As String = "", D_COLONIA As String = "", D_CALLE As String = "", D_NUMINT As String = "", D_NUMEXT As String = ""

        If (_ComercioExterior Is Nothing) Then
            _ComercioExterior = New ComercioExterior
        End If

        '_comprobante.Complemento = New Complemento With {.CartaPorte20 = _cartaPorte}
        '_comprobante.Complemento = New Complemento With {.ComercioExterior = _ComercioExterior}

        _ComercioExterior.Version = "1.1"
        _ComercioExterior.Incoterm = "EXW"

        _ComercioExterior.TotalUSD = FTOTALUSD
        _ComercioExterior.TipoCambioUSD = FTIPOCAMBIO
        _ComercioExterior.Subdivision = 0
        _ComercioExterior.CertificadoOrigen = "0"
        _ComercioExterior.ClaveDePedimento = FCLAVEPEDIMENTO
        _ComercioExterior.TipoOperacion = FDTIPOOPERACION

        Try
            SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.NUMEXT, NUMINT, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                C.COLONIA_SAT, C.POBLACION, C.MUNICIPIO, C.MUNICIPIO_SAT, C.POBLACION, C.POBLACION_SAT, C.ESTADO, C.ESTADO_SAT, C.PAIS_SAT 
                FROM GCCLIE_OP C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                WHERE C.CLAVE = '" & FCLAVE_O & "'"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        O_RFC = dr.ReadNullAsEmptyString("RFC")
                        O_NOMBRE = dr.ReadNullAsEmptyString("NOMBRE")
                        O_PAIS = dr.ReadNullAsEmptyString("PAIS_SAT")
                        O_CP = dr.ReadNullAsEmptyString("CP")
                        O_ESTADO = dr.ReadNullAsEmptyString("ESTADO_SAT")
                        O_MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        O_LOCALIDAD = dr.ReadNullAsEmptyString("POBLACION_SAT")
                        O_COLONIA = dr.ReadNullAsEmptyString("COLONIA_SAT")
                        O_CALLE = dr.ReadNullAsEmptyString("DOMICILIO")
                        O_NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        O_NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    Private Sub ASIG_CFD_EMISOR_RECEPTOR(FMONEDA As String, FMETODODEPAGO As String, FFORMADEPAGO As String, FSUBTOTAL As Decimal,
                FDESCUENTO As Decimal, FTOTAL As Decimal, FUSO_CFDI As String, FRECEPTOR_NOMBRE As String, FRECEPTOR_RFC As String,
                FRECEPTOR_CP As String, FRECEPTOR_REG_FISC As String, FTIPOCOMPROBANTE As String, FTIPO_CAMBIO As Decimal)
        Try
            _comprobante.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL
            _comprobante.TipoDeComprobante = FTIPOCOMPROBANTE

            _comprobante.Moneda = FMONEDA
            _comprobante.MetodoPago = FMETODODEPAGO
            _comprobante.FormaPago = FFORMADEPAGO
            _comprobante.TipoCambio = FTIPO_CAMBIO

            If FMONEDA = "MXN" Then
                _comprobante.Exportacion = "01"
            Else
                _comprobante.Exportacion = "01"
            End If
            _comprobante.Receptor.Nombre = FRECEPTOR_NOMBRE
            _comprobante.Receptor.Rfc = FRECEPTOR_RFC
            _comprobante.Receptor.UsoCFDI = FUSO_CFDI
            '_comprobante.Receptor.NumRegIdTrib = "GB396664788"
            '_comprobante.Receptor.ResidenciaFiscal = "GBR"
            _comprobante.Receptor.RegimenFiscalReceptor = FRECEPTOR_REG_FISC
            _comprobante.Receptor.DomicilioFiscalReceptor = FRECEPTOR_CP

        Catch ex As Exception
            BITACORACFDI("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CPConceptoBueno()
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT M.DESCR_MARCANCIA AS DESCR, I.ID_MERCANCIA AS CVE_PRODSERV, M.CANT, M.ID_UNIDAD AS CVE_UNIDAD, M.PESO 
                        FROM GCMERCANCIAS M
                        LEFT JOIN INVE_CP CP ON CP.CVE_ART = P.CVE_ART
                        WHERE CVE_DOC = '" & CVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        '.Impuestos = GetImpuestosConcepto(1)

                        If dr.ReadNullAsEmptyDecimal("CANT") > 0 Then
                            Dim C As New Concepto With {
                            .Cantidad = 1,
                            .ClaveProdServ = dr("CVE_PRODSERV"),
                            .ClaveUnidad = dr("CVE_UNIDAD"),
                            .Descripcion = dr("DESCR"),
                            .Descuento = 0,
                            .Importe = 0,
                            .NoIdentificacion = "",
                            .Unidad = "SERVICIO",
                            .ValorUnitario = 0,
                            .ObjetoImp = "01"
                        }
                            _comprobante.Conceptos.Concepto.Add(C)
                        End If
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        CalculaTotalesCFDI()
        'limpiarCampos()
    End Sub

    Private Sub DATOS_CARTA_PORTE_BUENO(FCVE_VIAJE As String, FECHA_CARGA As String, FECHA_DESCARGA As String, FUNIDAD As String,
                FCVE_TANQUE1 As String, FCVE_TANQUE2 As String, FCVE_OPER As Integer, CLAVE_O As String, CLAVE_D As String, FKMSRECORRIDOS As Decimal)

        Dim KMS_RECORRIDOS As Decimal, TotalMercancias As Integer, PESO_KG As Decimal, PESO_UNIDAD As String, MAT_PELIGROSO As String = ""
        Dim O_RFC As String = "", O_NOMBRE As String = "", O_PAIS As String = "", O_CP As String = "", O_ESTADO As String = "", O_MUNICIPIO As String = ""
        Dim O_LOCALIDAD As String = "", O_COLONIA As String = "", O_CALLE As String = "", O_NUMINT As String = "", O_NUMEXT As String = ""

        Dim D_RFC As String = "", D_NOMBRE As String = "", D_PAIS As String = "", D_CP As String = "", D_ESTADO As String = "", D_MUNICIPIO As String = ""
        Dim D_LOCALIDAD As String = "", D_COLONIA As String = "", D_CALLE As String = "", D_NUMINT As String = "", D_NUMEXT As String = ""
        Dim TOTAL_MERCANCIAS As Decimal = 0, NOMBRE_OPERADOR As String = "", RFC_OPERADOR As String = "", CALLE_OPERADOR As String = "", NUMEXT_OPERADOR As String
        Dim COLONIA_OPERADOR As String = "", LICENCIA As String = "", LOCALIDAD_OPERADOR As String = "", CODIGOPOSTAL_OPERADOR As String = ""
        Dim ESTADO_OPERADOR As String = "", MUNICIPIO_OPERADOR As String = "", PAIS_OPERADOR As String

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT M.CANT, M.PESO
                      FROM GCMERCANCIAS M
                      WHERE M.CVE_VIAJE = '" & FCVE_VIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        PESO_KG += dr("CANT") * dr("PESO")

                        'TRANSPINTERNAC = dr("TRANSPINTERNAC")
                        TOTAL_MERCANCIAS += 1
                        'ConfigVehicular = dr.ReadNullAsEmptyString("CONFIGVEHICULAR")
                    End While
                End Using
            End Using

            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCOPERADOR WHERE CLAVE = " & FCVE_OPER
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    If dr2.Read Then
                        NOMBRE_OPERADOR = dr2.ReadNullAsEmptyString("NOMBRE")
                        RFC_OPERADOR = dr2.ReadNullAsEmptyString("RFC")
                        CALLE_OPERADOR = dr2.ReadNullAsEmptyString("CALLE")
                        NUMEXT_OPERADOR = dr2.ReadNullAsEmptyString("NUM_EXT")
                        COLONIA_OPERADOR = dr2.ReadNullAsEmptyString("COLONIA_SAT")
                        LOCALIDAD_OPERADOR = dr2.ReadNullAsEmptyString("POBLACION_SAT")
                        CODIGOPOSTAL_OPERADOR = dr2.ReadNullAsEmptyString("CP_SAT")
                        ESTADO_OPERADOR = dr2.ReadNullAsEmptyString("ESTADO_SAT")
                        MUNICIPIO_OPERADOR = dr2.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        PAIS_OPERADOR = dr2.ReadNullAsEmptyString("PAIS_SAT")
                        LICENCIA = dr2.ReadNullAsEmptyString("LICENCIA")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(SUBTIPOREM,'') AS SUTIREM1,
                    ISNULL(U.ANO_MODELO,'') AS ANO_MOD, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL 
                    FROM GCUNIDADES U 
                    LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                    WHERE CLAVEMONTE = '" & FUNIDAD & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        PlacaVM = dr("PLACAS_MEX_TRACTOR")
                        If IsNumeric(dr.ReadNullAsEmptyString("ANO_MOD")) Then
                            AnioModeloVM = Convert.ToInt32(dr("ANO_MOD"))
                        Else
                            AnioModeloVM = 0
                        End If

                        SubTipoRem1 = dr.ReadNullAsEmptyString("SUTIREM1")
                        PolizaRespCivil = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                        AseguraRespCivil = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1, ISNULL(SUBTIPOREM,'') AS SUTIREM1, ISNULL(U.ANO_MODELO,'') AS ANO_MOD
                    FROM GCUNIDADES U 
                    WHERE CLAVEMONTE = '" & FCVE_TANQUE1 & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Placa1 = dr("PLACAS_MEX_TANQUE1")
                        If IsNumeric(dr.ReadNullAsEmptyString("ANO_MOD")) Then
                            AnioModelo1 = Convert.ToInt32(dr("ANO_MOD"))
                        Else
                            AnioModelo1 = 0
                        End If
                        SubTipoRem1 = dr.ReadNullAsEmptyString("SUTIREM1")
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(SUBTIPOREM,'') AS SUTIREM1, ISNULL(U.ANO_MODELO,'') AS ANO_MOD
                    FROM GCUNIDADES U 
                    WHERE CLAVEMONTE = '" & FCVE_TANQUE2 & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Placa2 = dr("PLACAS_MEX_TANQUE2")
                        If IsNumeric(dr.ReadNullAsEmptyString("ANO_MOD")) Then
                            AnioModelo2 = Convert.ToInt32(dr("ANO_MOD"))
                        Else
                            AnioModelo2 = 0
                        End If
                        SubTipoRem2 = dr.ReadNullAsEmptyString("SUTIREM1")
                    End While
                End Using
            End Using

            If FUNIDAD.Trim.Length > 0 And FCVE_TANQUE1.Trim.Length > 0 And FCVE_TANQUE2.Trim.Length > 0 Then
                ConfigVehicular = "T3S2R4"
            Else
                ConfigVehicular = "C3R3"
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.NUMEXT, NUMINT, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                C.COLONIA_SAT, C.POBLACION, C.MUNICIPIO, C.MUNICIPIO_SAT, C.POBLACION, C.POBLACION_SAT, C.ESTADO, C.ESTADO_SAT, C.PAIS_SAT 
                FROM GCCLIE_OP C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                WHERE C.CLAVE = '" & CLAVE_O & "'"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        'tDOMICILIO2.Text = dr("DOMICILIO2").ToString
                        O_RFC = dr.ReadNullAsEmptyString("RFC")
                        O_NOMBRE = dr.ReadNullAsEmptyString("NOMBRE")
                        O_PAIS = dr.ReadNullAsEmptyString("PAIS_SAT")
                        O_CP = dr.ReadNullAsEmptyString("CP")
                        O_ESTADO = dr.ReadNullAsEmptyString("ESTADO_SAT")
                        O_MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        O_LOCALIDAD = dr.ReadNullAsEmptyString("POBLACION_SAT")
                        O_COLONIA = dr.ReadNullAsEmptyString("COLONIA_SAT")
                        O_CALLE = dr.ReadNullAsEmptyString("DOMICILIO")
                        O_NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        O_NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.NUMEXT, NUMINT, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                C.COLONIA_SAT, C.POBLACION, C.MUNICIPIO, C.MUNICIPIO_SAT, C.POBLACION, C.POBLACION_SAT, C.ESTADO, C.ESTADO_SAT, C.PAIS_SAT 
                FROM GCCLIE_OP C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                WHERE C.CLAVE = '" & CLAVE_D & "'"

            'LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = C.CVE_ESTADO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        D_RFC = dr.ReadNullAsEmptyString("RFC")
                        D_NOMBRE = dr.ReadNullAsEmptyString("NOMBRE")
                        D_PAIS = dr.ReadNullAsEmptyString("PAIS_SAT")
                        D_CP = dr.ReadNullAsEmptyString("CP")
                        D_ESTADO = dr.ReadNullAsEmptyString("ESTADO_SAT")
                        D_MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")
                        D_LOCALIDAD = dr.ReadNullAsEmptyString("POBLACION_SAT")
                        D_COLONIA = dr.ReadNullAsEmptyString("COLONIA_SAT")
                        D_CALLE = dr.ReadNullAsEmptyString("DOMICILIO")
                        D_NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        D_NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        KMS_RECORRIDOS = FKMSRECORRIDOS
        Try
            If (_cartaPorte Is Nothing) Then
                _cartaPorte = New CartaPorte
            End If

            _comprobante.Complemento = New Complemento With {.CartaPorte20 = _cartaPorte}
            _cartaPorte.Version = "2.0"
            _cartaPorte.TotalDistRec = KMS_RECORRIDOS 'TOTAL DISTANCIA RECORRIDA
            _cartaPorte.TranspInternac = "No"

            'ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  ORIGEN  
            Dim ubicaciones As New Ubicaciones()
            Dim ubicacionOrigen As New Ubicacion With {
                .TipoUbicacion = "Origen",
                .RFCRemitenteDestinatario = O_RFC,
                .NombreRemitenteDestinatario = O_NOMBRE,
                .FechaHoraSalidaLlegada = FECHA_CARGA,
                .IDUbicacion = "OR000001"
            }
            Dim domicilioOrigen As New Domicilio With {
                .Calle = O_CALLE,
                .NumeroExterior = O_NUMEXT,
                .NumeroInterior = O_NUMINT
            }

            If O_COLONIA.Trim.Length > 0 Then domicilioOrigen.Colonia = O_COLONIA
            domicilioOrigen.Localidad = O_LOCALIDAD
            domicilioOrigen.CodigoPostal = O_CP

            domicilioOrigen.Estado = O_ESTADO
            domicilioOrigen.Municipio = O_MUNICIPIO
            domicilioOrigen.Pais = O_PAIS
            ubicacionOrigen.Domicilio = domicilioOrigen

            'DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    DESTINO    

            Dim ubicacionDestino As New Ubicacion With {
                .TipoUbicacion = "Destino",
                .RFCRemitenteDestinatario = D_RFC,
                .NombreRemitenteDestinatario = D_NOMBRE,
                .FechaHoraSalidaLlegada = FECHA_DESCARGA,
                .IDUbicacion = "DE000002",
                .DistanciaRecorrida = KMS_RECORRIDOS
            }
            Dim domicilioDestino As New Domicilio With {
                .Calle = D_CALLE,
                .NumeroExterior = D_NUMEXT,
                .NumeroInterior = D_NUMINT
            }
            If D_COLONIA.Trim.Length > 0 Then domicilioDestino.Colonia = D_COLONIA

            domicilioDestino.Localidad = D_LOCALIDAD
            domicilioDestino.CodigoPostal = D_CP

            domicilioDestino.Estado = D_ESTADO
            domicilioDestino.Municipio = D_MUNICIPIO
            domicilioDestino.Pais = D_PAIS

            'SE AGREGA AL OBJETO
            ubicacionDestino.Domicilio = domicilioDestino

            ubicaciones.Ubicacion.Add(ubicacionOrigen)
            ubicaciones.Ubicacion.Add(ubicacionDestino)
            _cartaPorte.Ubicaciones = ubicaciones
            'FIN QUITE LAS 3 LINEAS

            TotalMercancias = TOTAL_MERCANCIAS

            'MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1
            '
            Dim mercancias As New Mercancias With {.NumTotalMercancias = TotalMercancias}

            PESO_UNIDAD = "KGM"

            mercancias.UnidadPeso = PESO_UNIDAD
            mercancias.PesoBrutoTotal = PESO_KG

            '███████████████████████████████████████

            Try
                Dim PESOKG As Decimal = 0

                SQL = "SELECT M.DESCR_MERCANCIA AS DESCR, M.CANT, M.PESO, ISNULL(M.ID_MERCANCIA,'') AS CVE_PRODSERV, M.ID_UNIDAD AS CVE_UNIDAD,
                    MAT_PELIGROSO, CVE_MAT_PELIGROSO, ID_EMBALAJE AS EMBALAJE
                    FROM GCMERCANCIAS M
                    WHERE CVE_VIAJE = '" & FCVE_VIAJE & "'"


                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            PESOKG = dr("PESO") * dr("CANT")

                            If PESOKG > 0 Then

                                Dim Mercancia1 As New Mercancia With {
                                .Descripcion = dr("DESCR"),
                                .ClaveUnidad = dr("CVE_UNIDAD"),
                                .Cantidad = dr("CANT"),
                                .PesoEnKg = PESOKG}

                                Select Case MAT_PELI_01(dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO"))
                                    Case "0,1"
                                        If dr.ReadNullAsEmptyString("MAT_PELIGROSO") = "Sí" Or dr.ReadNullAsEmptyString("MAT_PELIGROSO") = "Si" Or
                                            dr.ReadNullAsEmptyString("MAT_PELIGROSO") = "SÍ" Or dr.ReadNullAsEmptyString("MAT_PELIGROSO") = "SI" Then

                                            Mercancia1.DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))
                                            Mercancia1.Embalaje = dr.ReadNullAsEmptyString("EMBALAJE")
                                            'GET_MAT_PELIGROSO(
                                            Mercancia1.CveMaterialPeligroso = dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO")
                                            Mercancia1.MaterialPeligroso = "Sí"
                                            MAT_PELIGROSO = "Sí"
                                        Else
                                            'Mercancia1.DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))
                                            'Mercancia1.Embalaje = dr.ReadNullAsEmptyString("EMBALAJE")
                                            Mercancia1.MaterialPeligroso = "No"
                                        End If
                                    Case "1"
                                        Mercancia1.DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))
                                        Mercancia1.Embalaje = dr.ReadNullAsEmptyString("EMBALAJE")
                                        'GET_MAT_PELIGROSO(
                                        Mercancia1.CveMaterialPeligroso = dr.ReadNullAsEmptyString("CVE_MAT_PELIGROSO")
                                        Mercancia1.MaterialPeligroso = "Sí"
                                        MAT_PELIGROSO = "Sí"
                                    Case "0"
                                        'Mercancia1.DescripEmbalaje = GET_MAT_EMBALAJE(dr.ReadNullAsEmptyString("EMBALAJE"))
                                        'Mercancia1.Embalaje = dr.ReadNullAsEmptyString("EMBALAJE")
                                        If QUITAR_MAT_PELI Then
                                            Mercancia1.MaterialPeligroso = "No"
                                        End If
                                End Select


                                Mercancia1.BienesTransp = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                'mercancia1.Unidad = "Pieza"            'mercancia1.Dimensiones = "59/40/36plg"            'mercancia1.Moneda = "MXN"
                                'mercancia1.ValorMercancia = 150000
                                mercancias.Mercancia.Add(Mercancia1)
                            End If

                        End While
                    End Using
                End Using

            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            'MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2
            'mercancia2.Moneda = "MXN"            'mercancia2.ValorMercancia = 150000
            'Dim cantidadTransporta As CantidadTransporta = New CantidadTransporta()
            'CantidadTransporta.Cantidad = 8            'CantidadTransporta.IDOrigen = "OR458563"
            'CantidadTransporta.IDDestino = "DE458563"            'mercancia2.CantidadTransporta.Add(cantidadTransporta)

            'FIN CICLO MERCACNIAS
            '=-=============================================================================================

            'CONFIG CFDI
            'PERMSCT = dr("PERMSCT")
            'NUMPERMISOSCT = dr("NUMPERMISOSCT")
            'CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
            'CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
            'PolizaMedAmbiente = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
            'AseguraMedAmbiente = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
            Dim Autotransporte As New Autotransporte With {
                .NumPermisoSCT = NUMPERMISOSCT,
                .PermSCT = PERMSCT}

            'UNIDAD
            'PlacaVM = dr("PLACAS_MEX_TRACTOR")
            'Placa1 = "" 'dr("PLACAS_MEX_TANQUE1")
            'Placa2 = "" 'dr("PLACAS_MEX_TANQUE2")

            'AnioModeloVM = dr.ReadNullAsEmptyInteger("ANO_MOD")
            'SubTipoRem1 = dr.ReadNullAsEmptyString("SUTIREM1")
            'SubTipoRem2 = "" 'dr.ReadNullAsEmptyString("SUTIREM2")

            'PolizaRespCivil = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
            'AseguraRespCivil = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")

            Dim IdentificacionVehicular As New IdentificacionVehicular With {
                .AnioModeloVM = AnioModeloVM,
                .PlacaVM = PlacaVM,
                .ConfigVehicular = ConfigVehicular}

            If PolizaRespCivil.Trim.Length > 0 And AseguraRespCivil.Trim.Length > 0 Then
                Dim Seguros As New Seguros()

                If MAT_PELIGROSO = "Sí" Then
                    If PolizaMedAmbiente.Trim.Length > 0 Then Seguros.PolizaMedAmbiente = PolizaMedAmbiente
                    If AseguraMedAmbiente.Trim.Length > 0 Then Seguros.AseguraMedAmbiente = AseguraMedAmbiente
                End If

                If PolizaRespCivil.Trim.Length > 0 Then Seguros.PolizaRespCivil = PolizaRespCivil
                If AseguraRespCivil.Trim.Length > 0 Then Seguros.AseguraRespCivil = AseguraRespCivil
                'seguros.AseguraCarga = "Seguros Afirme"
                'seguros.PolizaCarga = "NUMPOLIZASEGURO"
                'seguros.PrimaSeguro = 1200
                Autotransporte.Seguros = Seguros
            End If
            'PlacaVM = dr("PLACAS_MEX_TRACTOR")
            'Placa1 = "" 'dr("PLACAS_MEX_TANQUE1")
            'Placa2 = "" 'dr("PLACAS_MEX_TANQUE2")
            'AnioModeloVM = dr.ReadNullAsEmptyInteger("ANO_MOD")
            'SubTipoRem1 = dr.ReadNullAsEmptyString("SUTIREM1")
            'SubTipoRem2 = "" 'dr.ReadNullAsEmptyString("SUTIREM2")
            'PolizaRespCivil = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
            'AseguraRespCivil = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
            If Tanque1.Trim.Length > 0 Or Tanque2.Trim.Length > 0 Then
                Dim remolques As New Remolques()
                Dim remolque1 As New Remolque()
                Dim remolque2 As New Remolque()

                If Tanque1.Trim.Length > 0 Then
                    remolque1.Placa = Placa1
                    remolque1.SubTipoRem = SubTipoRem1
                    remolques.Remolque.Add(remolque1)
                End If

                If Tanque2.Trim.Length > 0 Then
                    remolque2.Placa = Placa2
                    remolque2.SubTipoRem = SubTipoRem2
                    remolques.Remolque.Add(remolque2)
                End If
                Autotransporte.Remolques = remolques
            End If

            Autotransporte.IdentificacionVehicular = IdentificacionVehicular
            mercancias.Autotransporte = Autotransporte

            _cartaPorte.Mercancias = mercancias

            Dim figuraTransporte As New FiguraTransporte()
            '01 Operador
            '02 Propietario
            '03 Arrendador
            '04 Notificado
            Dim tiposFigura As New TiposFigura With {
                .TipoFigura = "01",
                .RFCFigura = RFC_OPERADOR,
                .NumLicencia = LICENCIA,
                .NombreFigura = NOMBRE_OPERADOR}

            Dim DomicilioTipoFigura As New Domicilio With {
                .Calle = CALLE_OPERADOR,
                .Localidad = LOCALIDAD_OPERADOR,
                .Municipio = MUNICIPIO_OPERADOR,
                .Colonia = COLONIA_OPERADOR}

            If CODIGOPOSTAL_OPERADOR.Trim.Length > 0 Then
                DomicilioTipoFigura.CodigoPostal = CODIGOPOSTAL_OPERADOR
            End If

            DomicilioTipoFigura.Pais = "MEX"
            DomicilioTipoFigura.Estado = ESTADO_OPERADOR

            tiposFigura.Domicilio = DomicilioTipoFigura

            figuraTransporte.TiposFigura.Add(tiposFigura)

            _cartaPorte.FiguraTransporte = figuraTransporte
            'Me.DialogResult = System.Windows.Forms.DialogResult.OK


        Catch ex As Exception
            BITACORACFDI("1200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function MAT_PELI_01(FMAT_PELIGROSO As String) As String
        Dim REGRESA_MAT01 As String = "0"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT matpeligroso FROM tblClaveProdServCP WHERE clave = '" & FMAT_PELIGROSO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        REGRESA_MAT01 = dr("matpeligroso")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return REGRESA_MAT01

    End Function

End Class