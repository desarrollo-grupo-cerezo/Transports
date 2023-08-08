Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Globalization

Public Class Principal

    Public _cartaPorte As CartaPorte
    Private _c As Comprobante
    Private _documentosRelacionados As List(Of PDoctoRelacionado)
    Private bs As BindingSource = New BindingSource()

    Private msg As VtlMessageBox

    Private TIENE_DOC_RELACIONADOS As Boolean
    Private FACTURA As String = "", SERIE_FAC_CP As String = "", CVE_VIAJE As String, TIMBRADO_DEMO As String = "No"
    Private CVE_FOLIO_CP As String = "", CVE_FOLIO_CP2 As String = "", CVE_ESQ1 As Integer, CVE_ESQ2 As Integer
    Private PESO_KG_SINO As String = "", ADDENDA_CODIGO_POSTAL As String, SERIE_CP As String = "", gUSUARIO_PAC As String, gPASS_PAC As String
    Private IMPU1_1 As Decimal, IMPU2_1 As Decimal, IMPU3_1 As Decimal, IMPU4_1 As Decimal
    Private IMPU1_2 As Decimal, IMPU2_2 As Decimal, IMPU3_2 As Decimal, IMPU4_2 As Decimal
    Private VALOR_DECLARADO As Decimal, CVE_ART As String, CVE_MAT As String, CORREO1 As String, CORREO2 As String

    Private ENVIAR_MAIL As String, CORREO_CLIENTE As String, USO_CFDI As String = ""
    Private POLIZARESPCIVIL As String, ASEGURARESPCIVIL As String

    Private CVE_DOCR As String = "", CVE_PEDIDO As String = "", ORDEN_DE As String = "", EMBARQUE As String = "", CARGA_ANTERIOR As String = ""
    Private CANT As String = "", CLIENTE As String = ""
    Private FECHA_DOC As String = "", CVE_OPER As Integer, CVE_TRACTOR As String = "", CVE_TANQUE1 As String = "", CVE_TANQUE2 As String = ""
    Private RECOGER_EN As String = "", ENTREGAR_EN As String = "", CLAVE_O As String = "", CLAVE_D As String = ""
    Private FECHA_CARGA As Date, FECHA_DESCARGA As Date

    Private PESO_BRUTO1 As Decimal = 0, TARA1 As Decimal = 0, PESO_BRUTO2 As Decimal = 0, TARA2 As Decimal = 0, PESO_BRUTO3 As Decimal = 0
    Private TARA3 As Decimal = 0, PESO_BRUTO4 As Decimal = 0, TARA4 As Decimal = 0, PESONETO1 As Decimal = 0, PESONETO2 As Decimal = 0
    Private PESONETO3 As Decimal = 0, PESONETO4 As Decimal = 0
    Private PESO_BRUTO21 As Decimal = 0, TARA21 As Decimal = 0, PESO_BRUTO22 As Decimal = 0, TARA22 As Decimal = 0, PESO_BRUTO23 As Decimal = 0, TARA23 As Decimal
    Private PESO_BRUTO24 As Decimal = 0, TARA24 As Decimal = 0, PESONETO21 As Decimal = 0, PESONETO22 As Decimal = 0, PESONETO23 As Decimal = 0, PESONETO24 As Decimal = 0

    Private FLETE As Decimal, SUBTOTAL1 As Decimal, IVA1 As Decimal, RET As Decimal, NETO As Decimal, PLACAS_MEX As String
    Private TCALLE As String, TNUMEXT As String, TNUMINT As String, TCP As String

    Private TCOLONIA_SAT As String, TLOCALIDAD_SAT As String, TMUNICIPIO_SAT As String
    Private TCOLONIA As String, TLOCALIDAD As String, TMUNICIPIO As String

    Private TESTADO As String, TPAIS As String, PLACAS_MEX_TRACTOR As String, PLACAS_MEX_TANQUE1 As String, PLACAS_MEX_TANQUE2 As String

    Private CALLE_DESTINO As String, NUMEROEXTERIOR_DESTINO As String, NUMEROINTERIOR_DESTINO As String, COLONIA_DESTINO As String
    Private LOCALIDAD_DESTINO As String, CODIGOPOSTAL_DESTINO As String, ESTADO_DESTINO As String, MUNICIPIO_DESTINO As String, PAIS_DESTINO As String

    Private NOMBRE_OPERADOR As String, RFC_OPERADOR As String, REG_FISC As String
    Private CALLE_OPERADOR As String, NUMEXT_OPERADOR As String, NUMINT_OPERADOR As String, COLONIA_OPERADOR As String, LICENCIA As String
    Private LOCALIDAD_OPERADOR As String, CODIGOPOSTAL_OPERADOR As String, ESTADO_OPERADOR As String, MUNICIPIO_OPERADOR As String, PAIS_OPERADOR As String
    Private bsComprobante As BindingSource = New BindingSource()
    Public Sub Principal()
        InitializeComponent()
        'RefreshDataBindings()
    End Sub
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        'RefreshDataBindings()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim EMISOR_REGIMEN_FISCAL As String = "", IVA As Decimal = 0

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            ProcessControls(Me)

            BtnUnidadPeso.FlatStyle = FlatStyle.Flat
            BtnUnidadPeso.FlatAppearance.BorderSize = 0
            BtnBienesTransp.FlatStyle = FlatStyle.Flat
            BtnBienesTransp.FlatAppearance.BorderSize = 0
            BtnCveMaterialPeligroso.FlatStyle = FlatStyle.Flat
            BtnCveMaterialPeligroso.FlatAppearance.BorderSize = 0
            BtnEmbalaje.FlatStyle = FlatStyle.Flat
            BtnEmbalaje.FlatAppearance.BorderSize = 0
            BtnPermSCT.FlatStyle = FlatStyle.Flat
            BtnPermSCT.FlatAppearance.BorderSize = 0
            BtnConfigVehicular.FlatStyle = FlatStyle.Flat
            BtnConfigVehicular.FlatAppearance.BorderSize = 0
            BtnUnidadPeso2.FlatStyle = FlatStyle.Flat
            BtnUnidadPeso2.FlatAppearance.BorderSize = 0
            BtnBienesTransp2.FlatStyle = FlatStyle.Flat
            BtnBienesTransp2.FlatAppearance.BorderSize = 0
            BtnCveMaterialPeligroso2.FlatStyle = FlatStyle.Flat
            BtnCveMaterialPeligroso2.FlatAppearance.BorderSize = 0
            BtnEmbalaje2.FlatStyle = FlatStyle.Flat
            BtnEmbalaje2.FlatAppearance.BorderSize = 0
            BtnSubTipoRem1.FlatStyle = FlatStyle.Flat
            BtnSubTipoRem1.FlatAppearance.BorderSize = 0
            BtnSubTipoRem2.FlatStyle = FlatStyle.Flat
            BtnSubTipoRem2.FlatAppearance.BorderSize = 0

            Fg.Rows.Count = 1
            Fg.Dock = DockStyle.Fill
        Catch ex As Exception
        End Try

        Try
            TKMRecorridos.Value = 0
            TCorreoPer.Tag = ""

            BtnRefreshDestino.Visible = True
            BtnRefreshOrigen.Visible = True
            BtnRefreshOper.Visible = True

            PassData5 = ""
            ReDim aDATA(0, 1)

            'tbConceptoDescripcion.Tag = ""
            'tbConceptoDescripcion2.Tag = ""
            CP_OBSER_CFDI = ""
            CP_RECOGER_EN = ""
            CP_ENTREGAR_EN = ""

            If Var18 = "SIN PRECIOS" Then
                CP_IMPRIME_IMPORTES = False
                LtConPrec.Text = "Formato Carta porte sin precios"
            Else
                CP_IMPRIME_IMPORTES = True
                LtConPrec.Text = "Formato Carta porte con precios"
            End If
        Catch ex As Exception
            BITACORACFDI("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        'Var14 = Fg(Fg.Row, 1)       'CVE_FOLIO
        'Var15 = Fg(Fg.Row, 19)      'PRODUCTO CVE_ART	
        'Var16 = Fg(Fg.Row, 20)      'VALOR DECLARADO
        'Var17 = Fg(Fg.Row, 21)      'CLIENTE
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE_CARTA_PORTE, ULT_DOC_CARTA_PORTE FROM GCPARAMTRANSCG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_CP = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        gUSUARIO_PAC = dr("USUARIO")
                        gPASS_PAC = Desencriptar(dr("PASS"))
                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                            LTimbrado.Text = "TIMBRADO SAT"
                            TIMBRADO_SAT = "No"
                        Else
                            TIMBRADO_DEMO = "Si"
                            LTimbrado.Text = "TIMBRADO DEMO"
                            TIMBRADO_SAT = "Si"
                        End If



                        If CP_IMPRIME_IMPORTES Then
                            'CON PRECIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        '--------------CAMPO NUEVO
                        gRutaXML_TIMBRADO_CON_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                        '--------------CAMPO NUEVO
                        gRutaXML_TIMBRADO_SIN_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")


                        gRutaPFX = dr("FILE_PFX")
                        gContraPFX = dr("PASS_PFX")
                        gRutaCertificado = dr("FILE_CER")


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
                        TPermSCT.Text = dr("PERMSCT")
                        TNumPermisoSCT.Text = dr("NUMPERMISOSCT")

                        tbEmisorRFC.Text = dr("EMISOR_RFC")
                        LTFACTURA.Text = dr("EMISOR_RFC")

                        tbEmisorRazonSocial.Text = dr("EMISOR_RAZON_SOCIAL")
                        LtRazonSocialEmisor.Text = dr("EMISOR_RAZON_SOCIAL")

                        tbLugarExpedicion.Text = dr("EMISOR_LUGAR_EXPEDICION")
                        cbRegimenesFiscales.Text = dr("EMISOR_REGIMEN_FISCAL")
                        EMISOR_REGIMEN_FISCAL = dr("EMISOR_REGIMEN_FISCAL")
                        CORREO1 = dr.ReadNullAsEmptyString("CORREO1")
                        CORREO2 = dr.ReadNullAsEmptyString("CORREO2")

                        TPolizaMedAmbiente.Text = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        TAseguraMedAmbiente.Text = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                        SERIE_FAC_CP = dr.ReadNullAsEmptyString("SERIE_CP")

                        CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")

                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        If gRutaXML_TIMBRADO = "" Then
            MsgBox("Ruta para almacenar los documentos timbrados no esta configurada, verifique por favor")
        End If
        If gRutaXML_NO_TIMBRADO = "" Then
            MsgBox("Ruta para almacenar los documentos no timbrados no esta configurada, verifique por favor")
        End If

        CargarDatosDB()

        FgV.Rows.Count = 1
        FgV.Cols(0).Width = 0
        FgV.Cols(1).StarWidth = "*"

        For k = 0 To aDOCS.Length - 1
            FgV.AddItem("" & vbTab & aDOCS(k))

        Next

        CVE_VIAJE = FgV(1, 1) 'CVE_VIAJE
        'LtCAP1.Text = CVE_FOLIO_CP
        FgV.Height = (FgV.Rows.DefaultSize * aDOCS.Length) + 23


        OBTENER_CARTA_PORTE(CVE_VIAJE, 1)


        TabMercancias2.Enabled = False

        Try
            For k = 0 To cbRegimenesFiscales.Items.Count - 1
                cbRegimenesFiscales.SelectedIndex = k
                If (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal = EMISOR_REGIMEN_FISCAL Then
                    cbRegimenesFiscales.SelectedIndex = k
                    Exit For
                End If
            Next
        Catch ex As Exception
            BITACORACFDI("480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            For k = 0 To cbMoneda.Items.Count - 1
                cbMoneda.SelectedIndex = k                'EMISOR_REGIMEN_FISCAL = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda
                If (CType(cbMoneda.SelectedItem, cMoneda)).Moneda = "MXN" Then
                    cbMoneda.SelectedIndex = k
                    Exit For
                End If
            Next
            'TCVE_ART.Tag = "" : TCVE_UNIDAD.Tag = "" :
            IMPU1_1 = 0 : IMPU2_1 = 0 : IMPU3_1 = 0 : IMPU4_1 = 0
            IMPU1_2 = 0 : IMPU2_2 = 0 : IMPU3_2 = 0 : IMPU4_2 = 0

            Try
                If CVE_ESQ1 > 0 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(IMPUESTO1,0) AS IMPU1, ISNULL(IMPUESTO2,0) AS IMPU2, ISNULL(IMPUESTO3,0) AS IMPU3, ISNULL(IMPUESTO4,0) AS IMPU4 
                            FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQ1
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                IMPU1_1 = dr.ReadNullAsEmptyDecimal("IMPU1")
                                IMPU2_1 = dr.ReadNullAsEmptyDecimal("IMPU2")
                                IMPU3_1 = dr.ReadNullAsEmptyDecimal("IMPU3")
                                IMPU4_1 = dr.ReadNullAsEmptyDecimal("IMPU4")
                            End If
                        End Using
                    End Using
                End If
            Catch ex As Exception
                BITACORACFDI("480. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            ENVIAR_MAIL = ""
            CORREO_CLIENTE = ""
            Try
                If TCVE_CLIE.Text.Trim.Length > 0 Then

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT CLAVE, NOMBRE, RFC, NUMINT, NUMEXT, CALLE, COLONIA, LOCALIDAD, CODIGO, ESTADO, MUNICIPIO, USO_CFDI, CVE_PAIS_SAT,
                                ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(ADIC1,'') AS D1, ISNULL(ADIC2,'') AS D2, ISNULL(MAIL,'') AS ENVIAR_CORREO, 
                                ISNULL(EMAILPRED,'') AS CORREO, REG_FISC
                                FROM CLIE" & Empresa & " C
                                LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE =  C.CLAVE
                                LEFT JOIN CLIE_ADIC A ON A.CLIENTE =  C.CLAVE
                                WHERE CLAVE = '" & TCVE_CLIE.Text & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                LtNombreReceptor.Text = dr.ReadNullAsEmptyString("NOMBRE")
                                LtRFCReceptor.Text = dr.ReadNullAsEmptyString("RFC")
                                CALLE_DESTINO = dr.ReadNullAsEmptyString("CALLE")
                                NUMEROEXTERIOR_DESTINO = dr.ReadNullAsEmptyString("NUMEXT")
                                NUMEROINTERIOR_DESTINO = dr.ReadNullAsEmptyString("NUMINT")
                                COLONIA_DESTINO = dr.ReadNullAsEmptyString("COLONIA")
                                LOCALIDAD_DESTINO = dr.ReadNullAsEmptyString("LOCALIDAD")
                                CODIGOPOSTAL_DESTINO = dr.ReadNullAsEmptyString("CODIGO")
                                ESTADO_DESTINO = dr.ReadNullAsEmptyString("ESTADO")
                                MUNICIPIO_DESTINO = dr.ReadNullAsEmptyString("MUNICIPIO")
                                PAIS_DESTINO = dr.ReadNullAsEmptyString("CVE_PAIS_SAT")
                                USO_CFDI = dr.ReadNullAsEmptyString("USO_CFDI")
                                CP_NUM_PROV = dr.ReadNullAsEmptyString("LIB1")
                                REG_FISC = dr.ReadNullAsEmptyString("REG_FISC")
                                PassData7 = CALLE_DESTINO
                                If CODIGOPOSTAL_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", CP " & CODIGOPOSTAL_DESTINO
                                End If
                                If COLONIA_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Colonia " & COLONIA_DESTINO
                                End If
                                If LOCALIDAD_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Localidad " & LOCALIDAD_DESTINO
                                End If
                                If MUNICIPIO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Municipio " & MUNICIPIO_DESTINO
                                End If
                                If ESTADO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Estado " & ESTADO_DESTINO
                                End If

                                PESO_KG_SINO = dr.ReadNullAsEmptyString("D1")
                                If PESO_KG_SINO = "S" Then
                                    L2.BackColor = Color.LightGreen
                                End If

                                ADDENDA_CODIGO_POSTAL = ""

                                ENVIAR_MAIL = dr("ENVIAR_CORREO")
                                CORREO_CLIENTE = dr("CORREO")

                                Try
                                    TCORREO1.Text = dr("LIB7")
                                    TCORREO2.Text = dr("LIB8")
                                    TCORREO3.Text = dr("LIB9")
                                Catch ex As Exception
                                    BITACORACFDI("490. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                REG_FISC = ""
                            End If
                        End Using

                        If ENVIAR_MAIL = "N" Then
                            LCorreo.Visible = False
                            LtCorreo.Visible = False
                        Else
                            LtCorreo.Text = CORREO_CLIENTE
                        End If
                    End Using
                Else
                    REG_FISC = ""
                End If
            Catch ex As Exception
                BITACORACFDI("490. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("490. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If USO_CFDI.Trim.Length > 0 Then
                    For k = 0 To cbUsoCfdi.Items.Count - 1
                        cbUsoCfdi.SelectedIndex = k
                        If (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI = USO_CFDI Then
                            cbUsoCfdi.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If
                cbRegimenesFiscalesReceptor.SelectedIndex = -1
                If REG_FISC.Trim.Length > 0 Then
                    Try
                        For k = 0 To cbRegimenesFiscalesReceptor.Items.Count - 1
                            cbRegimenesFiscalesReceptor.SelectedIndex = k
                            If (CType(cbRegimenesFiscalesReceptor.SelectedItem, cRegimenFiscal)).RegimenFiscal = REG_FISC Then
                                cbRegimenesFiscalesReceptor.SelectedIndex = k
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        BITACORACFDI("480. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                BITACORACFDI("500. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            CboTransInter.Items.Add("No")
            CboTransInter.Items.Add("Si")
            CboTransInter.SelectedIndex = 0

            TCveMaterialPeligroso_Validated(Nothing, Nothing)
            TEmbalaje_Validated(Nothing, Nothing)
            TPermSCT_Validated(Nothing, Nothing)

            FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA("F", SERIE_FAC_CP)

            If SERIE_FAC_CP.Trim.Length = 0 Or SERIE_FAC_CP = "STAND." Then
                FACTURA = Space(10) & Format(FOLIO_VENTA, "0000000000")
            Else
                FACTURA = SERIE_FAC_CP & FOLIO_VENTA
            End If

            LTFACTURA.Text = FACTURA
            LtReceptorCP.Text = CODIGOPOSTAL_DESTINO

            If TCVE_CLIE.Text.Trim.Length = 0 Then
                MsgBox("Carta porte sin cliente fiscal verifique por favor")
            End If

            CALCULAR_TOTALES_CON_IMPUESTOS()
            TKMRecorridos.Focus()

        Catch ex As Exception
            BITACORACFDI("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_TOTALES_CON_IMPUESTOS()

        Dim PREC As Decimal, cImpu1 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu4 As Decimal
        Dim SUBTOTAL As Decimal, IVA As Decimal, IEPS As Decimal, RET As Decimal
        Try
            PREC = FLETE 'nudConceptoValorUnitario.Value

            PREC = Math.Round(PREC, 6)

            cImpu1 = PREC * IMPU1_1 / 100
            cImpu2 = PREC * IMPU2_1 / 100
            cImpu3 = PREC * IMPU3_1 / 100
            cImpu4 = PREC * IMPU4_1 / 100

            SUBTOTAL += PREC
            IVA += cImpu4
            IEPS += cImpu1
            RET += cImpu2 + cImpu3

            'PREC = nudConceptoValorUnitario2.Value

            PREC = Math.Round(PREC, 6)

            cImpu1 = PREC * IMPU1_2 / 100
            cImpu2 = PREC * IMPU2_2 / 100
            cImpu3 = PREC * IMPU3_2 / 100
            cImpu4 = PREC * IMPU4_2 / 100

            SUBTOTAL += PREC
            IEPS += cImpu1
            IVA += cImpu4
            RET += cImpu2 + cImpu3

            LtSubtotal.Text = Format(SUBTOTAL, "###,###,###.00")
            LtIVA.Text = Format(IVA, "###,###,###.00")
            LtRetencion.Text = Format(RET, "###,###,###.00")
            LtTotal.Text = Format(SUBTOTAL + IVA + IEPS + RET, "###,###,##0.00")
        Catch ex As Exception
            BITACORACFDI("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Principal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BtnRefreshRegFisc_Click(sender As Object, e As EventArgs) Handles BtnRefreshRegFisc.Click
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NOMBRE, RFC, ISNULL(REG_FISC,'') AS REGFISC
                    FROM CLIE" & Empresa & "
                    WHERE CLAVE = '" & TCVE_CLIE.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LtNombreReceptor.Text = dr.ReadNullAsEmptyString("NOMBRE")
                        LtRFCReceptor.Text = dr.ReadNullAsEmptyString("RFC")
                        REG_FISC = dr.ReadNullAsEmptyString("REGFISC")
                    End If
                End Using
            End Using

            If REG_FISC.Trim.Length > 0 Then
                For k = 0 To cbRegimenesFiscalesReceptor.Items.Count - 1
                    cbRegimenesFiscalesReceptor.SelectedIndex = k
                    If (CType(cbRegimenesFiscalesReceptor.SelectedItem, cRegimenFiscal)).RegimenFiscal = REG_FISC Then
                        cbRegimenesFiscalesReceptor.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub ObtenerCamposConfiguracion()
        _c.Emisor.Nombre = tbEmisorRazonSocial.Text
        _c.Emisor.Rfc = tbEmisorRFC.Text
        _c.LugarExpedicion = tbLugarExpedicion.Text
        bsComprobante.ResetBindings(False)
    End Sub
    Private Sub CargarDatosDB()
        Try
            If Not DB.ProbarConexion() Then Return
            cbRegimenesFiscales.DataSource = DB.obtenerRegimenesFiscales()
            cbRegimenesFiscalesReceptor.DataSource = DB.obtenerRegimenesFiscales()

            cbTipoComprobante.DataSource = DB.obtenerTiposComprobante()
            cbFormaPago.DataSource = DB.obtenerFormasPago()
            cbMoneda.DataSource = DB.obtenerMonedas()

            cbMetodoPago.DataSource = DB.obtenerMetodosPago()
            cbUsoCfdi.DataSource = DB.obtenerUsosCfdi()

        Catch ex As Exception
            BITACORACFDI("590. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("590. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Sub RefreshDataBindings()
        Try
            _c = New Comprobante()
            If _c.Fecha.Year < 1973 Then _c.Fecha = DateTime.Now

            _c.Serie = SERIE_FAC_CP
            _c.Folio = FOLIO_VENTA

            obtenerCamposConfiguracion()
            bsComprobante.DataSource = _c

        Catch ex As Exception
            BITACORACFDI("590. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("590. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnRefreshOrigen_Click(sender As Object, e As EventArgs) Handles BtnRefreshOrigen.Click
        Try
            If LtClave_O.Text.Trim.Length > 0 Then
                SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.DOMICILIO2, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                C.COLONIA_SAT, C.POBLACION, P1.CLAVE_SAT_LOC, C.MUNICIPIO, P1.CLAVE_SAT_MUN, C.ESTADO, E.CLAVE_SAT_EST, E.CLAVE_SAT_PAIS, C.PAIS_SAT, 
                ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                FROM GCCLIE_OP C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                WHERE C.CLAVE = '" & LtClave_O.Text & "'"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LtNombreOrigen.Text = dr("NOMBRE").ToString
                            LtCalleOrigen.Text = dr.ReadNullAsEmptyString("DOMICILIO").ToString & " " & dr.ReadNullAsEmptyString("DOMICILIO2").ToString.Trim
                            'tDOMICILIO2.Text = dr("DOMICILIO2").ToString
                            LtRFCOrigen.Text = dr("RFC").ToString.Replace("-", "")
                            LtCPOrigen.Text = dr.ReadNullAsEmptyString("CP_SAT")
                            LtColoniaOrigen.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")

                            LtLocalidadOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                            LtMunicipioOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")
                            LtEstadoOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                            If LtEstadoDestino.Text = "VERACRUZ" Then LtEstadoDestino.Text = "VER"
                            LtPaisOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                            If LtPaisDestino.Text <> "MEX" Then LtPaisDestino.Text = "MEX"
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRefreshDestino_Click(sender As Object, e As EventArgs) Handles BtnRefreshDestino.Click
        Try
            If LtClave_D.Text.Trim.Length > 0 Then
                SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.DOMICILIO2, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                C.COLONIA_SAT, C.POBLACION, P1.CLAVE_SAT_LOC, C.MUNICIPIO, P1.CLAVE_SAT_MUN, C.ESTADO, E.CLAVE_SAT_EST, E.CLAVE_SAT_PAIS, C.PAIS_SAT, 
                ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                FROM GCCLIE_OP C 
                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                WHERE C.CLAVE = '" & LtClave_D.Text & "'"

                'LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = C.CVE_ESTADO
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LtNombreDestino.Text = dr("NOMBRE").ToString
                            LtCalleDestino.Text = dr.ReadNullAsEmptyString("DOMICILIO").ToString & " " & dr.ReadNullAsEmptyString("DOMICILIO2").ToString.Trim
                            'tDOMICILIO2.Text = dr("DOMICILIO2").ToString
                            LtRFCDestino.Text = dr("RFC").ToString.Replace("-", "")
                            LtCPDestino.Text = dr.ReadNullAsEmptyString("CP_SAT")
                            LtColoniaDestino.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")

                            LtLocalidadDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                            LtMunicipioDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")

                            LtEstadoDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                            If LtEstadoDestino.Text = "VERACRUZ" Then LtEstadoDestino.Text = "VER"
                            LtPaisDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                            If LtPaisDestino.Text <> "MEX" Then LtPaisDestino.Text = "MEX"

                            'TLOCALIDAD_SAT.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                            'tMUNICIPIO_SAT.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")
                            'TPAIS.Text = dr.ReadNullAsEmptyString("PAIS")
                            'tPAIS_SAT.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")

                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CLIE_TextChanged(sender As Object, e As EventArgs) Handles TCVE_CLIE.TextChanged

    End Sub

    Private Sub BtnRefreshOper_Click(sender As Object, e As EventArgs) Handles BtnRefreshOper.Click
        Try
            If LtCve_oper.Text.Trim.Length > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM GCOPERADOR WHERE CLAVE = " & LtCve_oper.Text
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        If dr2.Read Then
                            NOMBRE_OPERADOR = dr2.ReadNullAsEmptyString("NOMBRE")
                            RFC_OPERADOR = dr2.ReadNullAsEmptyString("RFC")
                            CALLE_OPERADOR = dr2.ReadNullAsEmptyString("CALLE")
                            NUMEXT_OPERADOR = dr2.ReadNullAsEmptyString("NUM_EXT")
                            'NUMINT_OPERADOR = dr2("NUM_INT")
                            COLONIA_OPERADOR = dr2.ReadNullAsEmptyString("COLONIA_SAT")
                            LOCALIDAD_OPERADOR = dr2.ReadNullAsEmptyString("POBLACION_SAT")
                            CODIGOPOSTAL_OPERADOR = dr2.ReadNullAsEmptyString("CP_SAT")
                            ESTADO_OPERADOR = dr2.ReadNullAsEmptyString("ESTADO_SAT")
                            MUNICIPIO_OPERADOR = dr2.ReadNullAsEmptyString("MUNICIPIO_SAT")
                            PAIS_OPERADOR = dr2.ReadNullAsEmptyString("PAIS_SAT")
                            LICENCIA = dr2.ReadNullAsEmptyString("LICENCIA")

                            LtCve_oper.Text = CVE_OPER
                            LtRFCOper.Text = RFC_OPERADOR
                            LtNombreOper.Text = NOMBRE_OPERADOR
                            LtCalleOper.Text = CALLE_OPERADOR
                            'LtNumIntR.Text = 
                            LtNumExtOper.Text = NUMEXT_OPERADOR
                            LtColoniaOper.Text = COLONIA_OPERADOR
                            LtLocalidadOper.Text = LOCALIDAD_OPERADOR
                            LtCPOper.Text = CODIGOPOSTAL_OPERADOR
                            LtEstadoOper.Text = ESTADO_OPERADOR
                            LtMunicipioOper.Text = MUNICIPIO_OPERADOR

                            If PAIS_OPERADOR = "52" Or PAIS_OPERADOR = "052" Or PAIS_OPERADOR = "MEXICO" Or PAIS_OPERADOR = "" Then
                                LtPaisOper.Text = "MEX"
                            Else
                                LtPaisOper.Text = PAIS_OPERADOR
                            End If
                            LtLicenciaOper.Text = LICENCIA
                            TCorreoPer.Text = dr2.ReadNullAsEmptyString("CORREO_PER")
                            TCorreoPer.Tag = TCorreoPer.Text
                        Else
                            NOMBRE_OPERADOR = ""
                            RFC_OPERADOR = ""
                            CALLE_OPERADOR = ""
                            NUMEXT_OPERADOR = ""
                            NUMINT_OPERADOR = ""
                            COLONIA_OPERADOR = ""
                            LOCALIDAD_OPERADOR = ""
                            CODIGOPOSTAL_OPERADOR = ""
                            ESTADO_OPERADOR = ""
                            MUNICIPIO_OPERADOR = ""
                            PAIS_OPERADOR = ""
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            BITACORACFDI("1240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

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

        impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Me.Close()

    End Sub

    Private Sub NudValorUnitario_ValueChanged(sender As Object, e As EventArgs)
        'nudConceptoImporte.Value = nudConceptoCantidad.Value * nudConceptoValorUnitario.Value
    End Sub

    Private Sub BtnCFDIRelacionados_Click(sender As Object, e As EventArgs) Handles BtnCFDIRelacionados.Click
        Dim z As Integer = 0

        Lt2.Visible = False
        Var47 = "Carta porte"

        FrmCFDIRelacionados.ShowDialog()
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                Lt2.Visible = True
                Lt2.Text = "Documentos relacionados"
            Else
                Lt2.Text = ""
                Lt2.Visible = False
            End If

        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Function HayErrorConcepto() As Boolean
        Dim hayError As Boolean = False
        'If TCVE_ART.Text.Trim.Length = 0 Then
        'lError.Text = "El campo Clave de producto es obligatorio"
        'hayError = True
        'If TCVE_UNIDAD.Text.Trim.Length = 0 Then
        'lError.Text = "El campo Clave de unidad es obligatorio"
        'hayError = True
        'ElseIf tbConceptoDescripcion.Text.Trim() = String.Empty Then
        'lError.Text = "El campo Descripción es obligatorio"
        'hayError = True
        'ElseIf nudConceptoImporte.Value <= -1 Then
        'lError.Text = "El importe debe ser mayor que cero"
        'hayError = True
        'End If

        If hayError Then
            'tlpError.Visible = True
            timer1.Enabled = True
        End If

        Return hayError
    End Function

    Private Function GetImpuestosConcepto(FCAP As Integer) As ImpuestosC
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal
        Dim Impuesto As New ImpuestosC()
        Try
            If FCAP = 1 Then
                'impuesto 001 – ISR, impuesto 002 – IVA, impuesto 003 – IEPS.
                'TRASLADO
                'IMP_TOT1 = 003 IEPS
                'IMP_TOT2 = 0
                'IMP_TOT3 = 0
                'IMP_TOT4 = 002 IVA
                'RETENCION
                'IMP_TOT1 = 0
                'IMP_TOT2 = 001 ISR
                'IMP_TOT3 = 002 RETENCION 
                'IMP_TOT4 = 002 IVA
                IMPU1 = IMPU1_1 / 100
                IMPU2 = IMPU2_1 / 100
                IMPU3 = IMPU3_1 / 100
                IMPU4 = IMPU4_1 / 100

                If IMPU1_1 > 0 Then
                    'impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = IMPU1, .Base = (nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value) * IMPU1, 2), .TipoFactor = "Tasa"})
                End If
                If IMPU2_1 < 0 Then
                    IMPU2 = Math.Abs(IMPU2)
                    'impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = IMPU2, .Base = (nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value) * IMPU2, 2), .TipoFactor = "Tasa"})
                End If
                If IMPU3_1 < 0 Then
                    IMPU3 = Math.Abs(IMPU3)
                    'impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = IMPU3, .Base = (nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value) * IMPU3, 2), .TipoFactor = "Tasa"})
                End If
                If IMPU4_1 > 0 Then
                    'impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = IMPU4, .Base = (nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value) * IMPU4, 2), .TipoFactor = "Tasa"})
                End If
            Else
                IMPU1 = IMPU1_2 / 100
                IMPU2 = IMPU2_2 / 100
                IMPU3 = IMPU3_2 / 100
                IMPU4 = IMPU4_2 / 100
                'impuesto 001 – ISR, impuesto 002 – IVA, impuesto 003 – IEPS.
                'TRASLADO
                'IMP_TOT1 = 003 IEPS
                'IMP_TOT2 = 0
                'IMP_TOT3 = 0
                'IMP_TOT4 = 002 IVA
                'RETENCION
                'IMP_TOT1 = 0
                'IMP_TOT2 = 001 ISR
                'IMP_TOT3 = 002 RETENCION 
                'IMP_TOT4 = 002 IVA
                If IMPU1_2 > 0 Then
                    'impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = IMPU1, .Base = (nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value) * IMPU1, 2), .TipoFactor = "Tasa"})
                End If
                If IMPU2_2 < 0 Then
                    IMPU2 = Math.Abs(IMPU2)
                    'impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = IMPU2, .Base = (nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario.Value * nudConceptoCantidad.Value) - nudConceptoDescuento.Value) * IMPU2, 2), .TipoFactor = "Tasa"})
                End If
                If IMPU3_2 < 0 Then
                    IMPU3 = Math.Abs(IMPU3)
                    'impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = IMPU3, .Base = (nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value) * IMPU3, 2), .TipoFactor = "Tasa"})
                End If

                If IMPU4_2 > 0 Then
                    'impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = IMPU4, .Base = (nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value, .Impuesto = "002", .Importe = Math.Round(((nudConceptoValorUnitario2.Value * nudConceptoCantidad2.Value) - nudConceptoDescuento2.Value) * IMPU4, 2), .TipoFactor = "Tasa"})
                End If
            End If

        Catch ex As Exception
            BITACORACFDI("620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return impuesto
    End Function
    Private Sub CalculaTotales()

        If IsNothing(_c) Then
            Return
        End If

        _c.Impuestos = GetImpuestos(_c.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _c.Conceptos.Concepto
            subtotal += c.Importe
            descuento = c.Descuento
        Next

        If _c.TipoDeComprobante = "I" Then

        End If
        _c.SubTotal = subtotal
        _c.Descuento = descuento
        _c.Total = _c.SubTotal - _c.Impuestos.TotalImpuestosRetenidos + _c.Impuestos.TotalImpuestosTrasladados
        _c.TotalLetra = New Numalet().ToCustomString(_c.Total)
        bsComprobante.ResetBindings(False)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        'tlpError.Visible = False
        'lError.Text = String.Empty
        timer1.Enabled = False
    End Sub
    Private Sub GetCamposCombox()
        Dim USOCFDI As String
        Try
            If cbRegimenesFiscales.SelectedItem IsNot Nothing Then _c.Emisor.RegimenFiscal = (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal
            If cbTipoComprobante.SelectedItem IsNot Nothing Then _c.TipoDeComprobante = (CType(cbTipoComprobante.SelectedItem, cTipoComprobante)).TipoComprobante

            If (CType(cbTipoComprobante.SelectedItem, cTipoComprobante)).TipoComprobante = "I" Then
                If cbMoneda.SelectedItem IsNot Nothing Then _c.Moneda = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda
                If cbMetodoPago.SelectedItem IsNot Nothing Then _c.MetodoPago = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
                If cbFormaPago.SelectedItem IsNot Nothing Then _c.FormaPago = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago
                _c.Exportacion = "01"
                '_c.SubTotal = "0"
                '_c.Descuento = "0"
                '_c.Total = "0"
            Else
                _c.Moneda = "XXX"
                If cbMetodoPago.SelectedItem IsNot Nothing Then _c.MetodoPago = "" '(CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
                If cbFormaPago.SelectedItem IsNot Nothing Then _c.FormaPago = "" '(CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago
                _c.Exportacion = "01"
                _c.SubTotal = "0"
                _c.Descuento = "0"
                _c.Total = "0"
            End If
            'If cbClientes.SelectedItem IsNot Nothing Then
            '_c.Receptor.Nombre = (CType(cbClientes.SelectedItem, Cliente)).RazonSocial
            '_c.Receptor.Rfc = (CType(cbClientes.SelectedItem, Cliente)).RFC


            _c.Receptor.Nombre = LtNombreReceptor.Text
            _c.Receptor.Rfc = LtRFCReceptor.Text

            _c.Receptor.DomicilioFiscalReceptor = CODIGOPOSTAL_DESTINO
            _c.Receptor.RegimenFiscalReceptor = (CType(cbRegimenesFiscalesReceptor.SelectedItem, cRegimenFiscal)).RegimenFiscal

            USOCFDI = (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI
            _c.Receptor.UsoCFDI = USOCFDI

        Catch ex As Exception
            BITACORACFDI("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUnidadPeso2_Click(sender As Object, e As EventArgs) Handles BtnUnidadPeso2.Click
        Try
            Var2 = "tblcclaveunidadpeso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUnidadPeso2.Text = Var4
                LTUnidadPeso2.Text = Var5
                TBienesTransp2.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnBienesTransp2_Click(sender As Object, e As EventArgs) Handles BtnBienesTransp2.Click
        Try
            Var2 = "SAT_CLAVEPROD_SERVCP"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TBienesTransp2.Text = Var4
                LTBienesTransp2.Text = Var5
                If LtMat_peligroso2.Text = "No" Then
                Else
                    TCveMaterialPeligroso2.Focus()
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("1320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCveMaterialPeligroso2_Click(sender As Object, e As EventArgs) Handles BtnCveMaterialPeligroso2.Click
        Try
            Var2 = "tblcmaterialpeligroso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCveMaterialPeligroso2.Text = Var4
                LTCveMaterialPeligroso2.Text = Var5
                TEmbalaje2.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEmbalaje2_Click(sender As Object, e As EventArgs) Handles BtnEmbalaje2.Click
        Try
            Var2 = "tblctipoembalaje"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TEmbalaje2.Text = Var4
                LTEmbalaje2.Text = Var5
            End If
        Catch ex As Exception
            BITACORACFDI("1290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        'tbConceptoUnidad.Text = String.Empty
        'tbConceptoNoIdentificacion.Text = String.Empty
        'tbConceptoDescripcion.Text = String.Empty
        'nudConceptoDescuento.Value = 0
        'nudConceptoValorUnitario.Value = 0
        'nudConceptoCantidad.Value = 0
        'nudConceptoImporte.Value = 0
    End Sub

    Private Function VALIDA_CAMPOS() As Boolean
        Dim HayError As Boolean = False

        Try
            'TABULADOR DATOS
            If TKMRecorridos.Value = 0 Then
                MsgBox("Por favor capture los kilometros recorridos")
                HayError = True
            End If
            'TABULADOR MERCANCIA
            If TUnidadPeso.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture los unidad de peso")
                HayError = True
            End If
            If TBienesTransp.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture Bienes transporte ")
                HayError = True
            End If
            '----------------MATERIA PELIGROSO
            If LtMat_peligroso.Text = "Sí" Then
                If TCveMaterialPeligroso.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture Material peligroso ")
                    HayError = True
                End If
                If TEmbalaje.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture Embalaje ")
                    HayError = True
                End If
                If TPolizaRespCivil.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture poliza de responsabilidad civil ")
                    HayError = True
                End If
                If TAseguraRespCivil.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture aseguradora civil")
                    HayError = True
                End If

            End If
            If TPermSCT.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture permiso de secretaría de comunicación y transporte ")
                HayError = True
            End If
            If TAnioModeloVM.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture Año modelo ")
                HayError = True
            End If
            If TNumPermisoSCT.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture num. de permiso de la secretaría de comunicación y transporte ")
                HayError = True
            End If
            If TConfigVehicular.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture configuración vehicular ")
                HayError = True
            End If
            'TABULADDOR SEGUROS Y REMOLQUES

            If CVE_TANQUE1.Trim.Length > 0 Then
                If TPlaca1.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture placa del remolque 1")
                    HayError = True
                End If
                If TSubTipoRem1.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture tipo de remolque 1")
                    HayError = True
                End If
            End If
            If CVE_TANQUE2.Trim.Length > 0 Then
                If TPlaca2.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture placa del remolque 2")
                    HayError = True
                End If
                If TSubTipoRem2.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture tipo de remolque 2")
                    HayError = True
                End If

            End If
            'TABULADOR CLIENTE ORIGEN
            If LtNombreOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture nombre origen")
                HayError = True
            End If
            If LtRFCOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture R.F.C. origen")
                HayError = True
            End If
            If LtCalleOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture calle origen")
                HayError = True
            End If
            'If LtNumIntR.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture num. int. origen")
            'HayError = True
            'End If
            'If LtNumExtR.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture num. ext. origen")
            'HayError = True
            'End If
            If LtLocalidadOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture localidad origen")
                HayError = True
            End If
            If LtMunicipioOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture municipio origen")
                HayError = True
            End If
            If LtEstadoOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture estado origen")
                HayError = True
            End If
            If LtPaisOrigen.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture pais origen")
                HayError = True
            End If
            'TABULADOR CLIENTE DESTINO
            If LtNombreDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture nombre destino")
                HayError = True
            End If
            If LtRFCDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture R.F.C. destino")
                HayError = True
            End If
            If LtCalleDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture calle destino")
                HayError = True
            End If
            'If LtNumIntDestino.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture num. int. destino")
            'HayError = True
            'End If
            'If LtNumExtDestino.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture num. ext. destino")
            'HayError = True
            'End If
            'If LtColoniaDestino.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture colonia destino")
            'HayError = True
            'End If
            'If LtLocalidadDestino.Text.Trim.Length = 0 Then
            'MsgBox("Por favor capture localidad destino")
            'HayError = True
            'End If
            If LtMunicipioDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture municipio destino")
                HayError = True
            End If
            If LtEstadoDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture estado destino")
                HayError = True
            End If
            If LtPaisDestino.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture pais destino")
                HayError = True
            End If
            'TABULADOR OPERADOR
            If LtNombreOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture nombre operador")
                HayError = True
            End If
            If LtRFCOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture R.F.C. operador")
                HayError = True
            End If
            If LtLicenciaOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture licencia operador")
                HayError = True
            End If
            If LtCPOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture codigo postal operador")
                HayError = True
            End If
            If LtEstadoOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture estado operador")
                HayError = True
            End If
            If LtPaisOper.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture pais operador")
                HayError = True
            End If
            Return HayError
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
            Return HayError
        End Try
    End Function
    Sub AGREGA_CFDIRELACIONADOS()
        Dim z As Integer
        Dim _cfdiRelacionados As New CfdiRelacionados

        Try
            z = 0
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                _cfdiRelacionados.TipoRelacion = PassData5
                '
                For k = 0 To aDATA.GetLength(0) - 1
                    If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                        If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then

                            Dim c As New CfdiRelacionado With {
                                .UUID = aDATA(k, 1)
                            }
                            '_c.CfdiRelacionados.CfdiRelacionado.Add(c)
                            _cfdiRelacionados.CfdiRelacionado.Add(c)
                            TIENE_DOC_RELACIONADOS = True
                        End If
                    End If
                Next
                _c.CfdiRelacionados = _cfdiRelacionados
            End If
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
            Var44 = -9
        End Try
    End Sub

    Private Sub BtnTimbrarDigiBox_Click(sender As Object, e As EventArgs) Handles btnTimbrarDigiBox.Click
        Dim Descripcion As String = "", ClaveUnidad As String = "", Cantidad As Decimal, PesoEnKg As Decimal, DescripEmbalaje As String = ""
        Dim EMBALAJE As String = "", CveMaterialPeligroso As String = "", MaterialPeligroso As String = "", BienesTransp As String = ""
        Dim ClaveProdServ As String = "", Precio As Decimal, NoIdentificacion As String = "", CVE_DOC As String = "", KMRECORRIDOS As Decimal = 0
        Dim MetodoPago As String, FormaPago As String, MONEDA As String
        Dim USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim CVE_BITA As Long, UUID_TIMBRADO As String
        Dim FECHA_T1 As DateTime
        Dim FECHA_T2 As String = dtpFecha.Text

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If VALIDA_CAMPOS() Then
                Return
            End If

            CP_CLIENTE = "(" & TCVE_CLIE.Text.ToString.Trim & ")"

            CP_OBSER_CFDI = TOBSER.Text
            RefreshDataBindings() 'SERIE Y FOLIO
            Var44 = 0
            TIENE_DOC_RELACIONADOS = False

            AGREGA_CFDIRELACIONADOS()
            If Var44 = -9 Then
                Return
            End If

            If PassDoc_Timbrado = "Timbrado" Then
                Dim Result As String


                If Not TIENE_DOC_RELACIONADOS Then
                    MsgBox("La CORTA PORTE se esta volviendo a timbrar, debe de seleccionar el documento relacionado, verifique por favor")

                    Me.Cursor = Cursors.Default
                    msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                    With msg
                        '.AddImageToMoreText("gridImage", img)
                        .MessageText = "Carta porte NO timbrado"
                        '.MoreText = "-----"
                        .AddStandardButtons(MessageBoxButtons.OK)
                        .Caption = "Proceso terminado"
                        .Icon = MessageBoxIcon.Error

                        .MessageBoxPosition = FormStartPosition.CenterScreen
                        Result = .Show()
                    End With
                    Return
                End If

                'msg = New VtlMessageBox(5)
                msg = New VtlMessageBox(VisualStyle.Office2010Blue)
                With msg
                    .MessageText = "Este mensaje se cerrara en 20 segundos. <br> <br> Timbrando nuevamente CARTA PORTE " & CVE_FOLIO_CP & " <br> <br> Realmente desea continuar?."
                    .Caption = "Timbrado carta porte"
                    .SecondsToAutoClose = 20
                    .AutoCloseResult = AutoCloseResult.TimedOut
                    .Icon = MessageBoxIcon.Question
                    .AddStandardButtons(MessageBoxButtons.YesNo)
                    Result = .Show
                    If Result = "No" Or Result = "TimedOut" Then
                        Me.Cursor = Cursors.Default
                        MsgBox("------------------  Documento no timbrado  ------------------")
                        Return
                    End If
                End With

            End If

            btnTimbrarDigiBox.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            CPConceptoAgregar() 'CONCEPTOS DATOS DEL ARTICULO
            GetCamposCombox() 'DATOS EMISOR Y RECEPTOR
            Datos_carta_porte()
            Try 'AgregarAddenda()
                Dim SIGUE As Boolean
                SIGUE = True
                FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA("F", SERIE_FAC_CP)

                Do While SIGUE
                    If SERIE_FAC_CP.Trim.Length = 0 Or SERIE_FAC_CP = "STAND." Then
                        FACTURA = Space(10) & Format(FOLIO_VENTA, "0000000000")
                    Else
                        FACTURA = SERIE_FAC_CP & FOLIO_VENTA
                    End If

                    If EXIST_CARTA_PORTE(FACTURA) Then
                        FOLIO_VENTA += 1
                    Else
                        SIGUE = False
                    End If
                Loop
            Catch ex As Exception
                BITACORACFDI("410. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
                Me.Cursor = Cursors.Default
                btnTimbrarDigiBox.Enabled = True
                Return
            End Try

            Dim aCORREOS(0) As String
            Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & CVE_FOLIO_CP & "-" & FACTURA & ".xml"
            Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & CVE_FOLIO_CP & "-" & FACTURA & ".xml"

            Try
                If Not IO.Directory.Exists(Application.StartupPath & "\XML_BAK") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\XML_BAK")
                End If
                XML_BK = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_FOLIO_CP & "-" & FACTURA & ".xml"
            Catch ex As Exception
            End Try

            Dim rutaPFX As String = gRutaPFX
            Dim rutaCertificado As String = gRutaCertificado

            Dim rutaPDF As String = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & CVE_FOLIO_CP & "-" & FACTURA & ".pdf"
            Dim rutaPDF2 As String = gRutaXML_TIMBRADO_SIN_PRECIOS & "\" & CVE_FOLIO_CP & "-" & FACTURA & ".pdf"

            Dim errorC As CError = _c.EsInfoCorrecta()

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
                    btnTimbrarDigiBox.Enabled = True
                    Return
                End If
                If Not IO.File.Exists(rutaCertificado) Then
                    MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                    btnTimbrarDigiBox.Enabled = True
                    Return
                End If
                _c.Addenda = New Addenda
                If ADDENDA_CODIGO_POSTAL = "S" Then
                    _c.Addenda.CodigoPostal = CODIGOPOSTAL_DESTINO
                Else
                    _c.Addenda.CodigoPostal = ""
                End If
                Var46 = "" 'NOCERTIFICADO
                CFDI_XML_DIGIBOX = ""
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_CON_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                '--------------CAMPO NUEVO
                'gRutaXML_TIMBRADO_SIN_PRECIOS = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                Dim xml As XmlDocument = GenerarXML.ObtenerXML(_c, rutaPFX, gContraPFX, rutaCertificado)
                xml.Save(RutaXML_NO_TIMBRADO)

                'GenerarXML.GuardarXML(_c, RutaXML_NO_TIMBRADO, rutaPFX, gContraPFX, rutaCertificado)

                If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
                    TimbreOK = True

                    MsgBox("Documento timbrado")

                    Try
                        CP_IMPRIME_IMPORTES = True
                        CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF, Application.StartupPath & "\logo.jpg", False)

                        CP_IMPRIME_IMPORTES = False
                        CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF2, Application.StartupPath & "\logo.jpg", False)

                    Catch ex As Exception
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Else
                    MsgBox("------------------  Documento no timbrado  ------------------")
                End If
            Else
                MessageBox.Show(errorC.Error, "Validando información...")
            End If
            Try
                If TimbreOK Then
                    Dim MensaDia As String = ""
                    'SUBTOTAL1 = SUBTOTAL1 + dr.ReadNullAsEmptyDecimal("SUBTOTAL")
                    'IVA1 = IVA1 + dr.ReadNullAsEmptyDecimal("IVA")
                    'RET = RET + dr.ReadNullAsEmptyDecimal("RETENCION")
                    'NETO = NETO + dr.ReadNullAsEmptyDecimal("NETO")

                    If Not Valida_Conexion() Then
                    End If

                    BACKUPTXT("CFDI", FACTURA & "," & CVE_FOLIO_CP & "," & CVE_FOLIO_CP2 & "," & SERIE_CP & "," & dtpFecha.Text & "," &
                                      CFDI_XML_DIGIBOX & ",S," & USER_GRUPOCE)
                    BACKUPTXT("CFDI", vbNewLine & "-----------------------------------------------------------------------------------------------" & vbNewLine)

                    MetodoPago = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
                    FormaPago = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago
                    MONEDA = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda

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
                        FECHA_T2 = dtpFecha.Text
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
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FACTURA
                            cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "CP"
                            cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = CVE_FOLIO_CP
                            cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = CVE_FOLIO_CP2
                            cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_CP
                            cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Var10
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCVE_CLIE.Text
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL1, 6)
                            cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(RET, 6)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA1, 6)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(NETO, 6)
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
                    Catch exception As SqlException
                        If exception.Number = 2601 Then
                            Return
                        Else
                            Throw
                        End If
                    Catch ex As Exception
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    CVE_DOC = FACTURA
                    Try

                        CVE_BITA = GRABA_BITA(TCVE_CLIE.Text, FACTURA, NETO, "X", "Cuenta x cobrar generada desde emisión CFDI Carta porte")

                        SQL = "INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, FECHA_APLI, FECHA_VENC, 
                            AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, CVE_BITA, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS, 
                            UUID, VERSION_SINC) VALUES('" & TCVE_CLIE.Text & "','" & FACTURA & "',1,1,0,'" & FACTURA & "','" & FACTURA & "','" & Math.Round(NETO, 6) &
                            "', CONVERT(varchar, GETDATE(), 112), CONVERT(varchar, GETDATE(), 112), 'A',' ',1,1,'" & Math.Round(NETO, 6) & "',GETDATE(),'C','" &
                            CVE_BITA & "',1,'" & CLAVE_SAE & "','S',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If Not Valida_Conexion() Then
                    End If
                    'GRBADO DE DATOS XML EN TABLA
                    '███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                    Try
                        TKMRecorridos.UpdateValueWithCurrentText()
                        KMRECORRIDOS = TKMRecorridos.Value
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
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = FACTURA
                            cmd.Parameters.Add("@CARTA_PORTE1", SqlDbType.VarChar).Value = CVE_FOLIO_CP
                            cmd.Parameters.Add("@CARTA_PORTE2", SqlDbType.VarChar).Value = CVE_FOLIO_CP2
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_FAC_CP
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO_VENTA
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = dtpFecha.Value
                            cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = Var8
                            cmd.Parameters.Add("@FILE_XML", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "Si"
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCVE_CLIE.Text
                            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = LtNombreReceptor.Text
                            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = LtRFCReceptor.Text
                            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                            cmd.Parameters.Add("@TRANS_INTER", SqlDbType.VarChar).Value = CboTransInter.Text
                            cmd.Parameters.Add("@KM_RECORRI", SqlDbType.Float).Value = TKMRecorridos.Value
                            cmd.Parameters.Add("@UNIDAD_PESO", SqlDbType.VarChar).Value = TUnidadPeso.Text
                            cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = FechaCarga.Value
                            cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = FechaDescarga.Value
                            cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = TPermSCT.Text
                            cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = TAnioModeloVM.Text
                            cmd.Parameters.Add("@PLACA_VM", SqlDbType.VarChar).Value = TPlacaVM.Text
                            cmd.Parameters.Add("@NUM_PER_SCT", SqlDbType.VarChar).Value = TNumPermisoSCT.Text
                            cmd.Parameters.Add("@CONFIG_VEHI", SqlDbType.VarChar).Value = TConfigVehicular.Text
                            cmd.Parameters.Add("@POLIZA_MED_AMB", SqlDbType.VarChar).Value = TPolizaMedAmbiente.Text
                            cmd.Parameters.Add("@ASEG_MED_AMB", SqlDbType.VarChar).Value = TAseguraMedAmbiente.Text
                            cmd.Parameters.Add("@POL_RESP_CIVIL", SqlDbType.VarChar).Value = TPolizaRespCivil.Text
                            cmd.Parameters.Add("@ASEG_RESP_CIVIL", SqlDbType.VarChar).Value = TAseguraRespCivil.Text
                            cmd.Parameters.Add("@TANQUE1", SqlDbType.VarChar).Value = LtTanque1.Text
                            cmd.Parameters.Add("@T1_PLACA", SqlDbType.VarChar).Value = TPlaca1.Text
                            cmd.Parameters.Add("@T1_SUB_TIPO_REM", SqlDbType.VarChar).Value = TSubTipoRem1.Text
                            cmd.Parameters.Add("@TANQUE2", SqlDbType.VarChar).Value = LtTanque2.Text
                            cmd.Parameters.Add("@T2_PLACA", SqlDbType.VarChar).Value = TPlaca2.Text
                            cmd.Parameters.Add("@T2_SUB_TIPO_REM", SqlDbType.VarChar).Value = TSubTipoRem2.Text
                            cmd.Parameters.Add("@O_NOMBRE", SqlDbType.VarChar).Value = LtNombreOrigen.Text
                            cmd.Parameters.Add("@O_RFC", SqlDbType.VarChar).Value = LtRFCOrigen.Text
                            cmd.Parameters.Add("@O_CALLE", SqlDbType.VarChar).Value = LtCalleOrigen.Text
                            cmd.Parameters.Add("@O_MUNICIPIO", SqlDbType.VarChar).Value = LtMunicipioOrigen.Text
                            cmd.Parameters.Add("@O_NUM_INT", SqlDbType.VarChar).Value = LtNumIntOrigen.Text
                            cmd.Parameters.Add("@O_NUM_EXT", SqlDbType.VarChar).Value = LtNumExtOrigen.Text
                            cmd.Parameters.Add("@O_COL", SqlDbType.VarChar).Value = LtColoniaOrigen.Text
                            cmd.Parameters.Add("@O_CP", SqlDbType.VarChar).Value = LtCPOrigen.Text
                            cmd.Parameters.Add("@O_LOC", SqlDbType.VarChar).Value = LtLocalidadOrigen.Text
                            cmd.Parameters.Add("@O_MUN", SqlDbType.VarChar).Value = LtMunicOrigen.Text
                            cmd.Parameters.Add("@O_EST", SqlDbType.VarChar).Value = LtEstadoOrigen.Text
                            cmd.Parameters.Add("@O_PAIS", SqlDbType.VarChar).Value = LtPaisOrigen.Text
                            cmd.Parameters.Add("@D_NOMBRE", SqlDbType.VarChar).Value = LtNombreDestino.Text
                            cmd.Parameters.Add("@D_RFC", SqlDbType.VarChar).Value = LtRFCDestino.Text
                            cmd.Parameters.Add("@D_CALLE", SqlDbType.VarChar).Value = LtCalleDestino.Text
                            cmd.Parameters.Add("@D_MUNICIPIO", SqlDbType.VarChar).Value = LtMunicDest.Text
                            cmd.Parameters.Add("@D_NUM_INT", SqlDbType.VarChar).Value = LtNumIntDestino.Text
                            cmd.Parameters.Add("@D_NUM_EXT", SqlDbType.VarChar).Value = LtNumExtDestino.Text
                            cmd.Parameters.Add("@D_COL", SqlDbType.VarChar).Value = LtColoniaDestino.Text
                            cmd.Parameters.Add("@D_CP", SqlDbType.VarChar).Value = LtCPDestino.Text
                            cmd.Parameters.Add("@D_LOC", SqlDbType.VarChar).Value = LtLocalidadDestino.Text
                            cmd.Parameters.Add("@D_MUN", SqlDbType.VarChar).Value = LtMunicipioDestino.Text
                            cmd.Parameters.Add("@D_EST", SqlDbType.VarChar).Value = LtEstadoDestino.Text
                            cmd.Parameters.Add("@D_PAIS", SqlDbType.VarChar).Value = LtPaisDestino.Text
                            cmd.Parameters.Add("@OP_NOMBRE", SqlDbType.VarChar).Value = LtNombreOper.Text
                            cmd.Parameters.Add("@OP_RFC", SqlDbType.VarChar).Value = LtRFCOper.Text
                            cmd.Parameters.Add("@OP_LIC", SqlDbType.VarChar).Value = LtLicenciaOper.Text
                            cmd.Parameters.Add("@OP_MUNICIPIO", SqlDbType.VarChar).Value = LtMunicipio.Text
                            cmd.Parameters.Add("@OP_CALLE", SqlDbType.VarChar).Value = LtCalleOper.Text
                            cmd.Parameters.Add("@OP_NUM_INT", SqlDbType.VarChar).Value = LtNumIntOper.Text
                            cmd.Parameters.Add("@OP_NUM_EXT", SqlDbType.VarChar).Value = LtNumExtOper.Text
                            cmd.Parameters.Add("@OP_COL", SqlDbType.VarChar).Value = LtColoniaOper.Text
                            cmd.Parameters.Add("@OP_CP", SqlDbType.VarChar).Value = LtCPOper.Text
                            cmd.Parameters.Add("@OP_LOC", SqlDbType.VarChar).Value = LtLocalidadOper.Text
                            cmd.Parameters.Add("@OP_MUN", SqlDbType.VarChar).Value = LtMunicipioOper.Text
                            cmd.Parameters.Add("@OP_EST", SqlDbType.VarChar).Value = LtEstadoOper.Text
                            cmd.Parameters.Add("@OP_PAIS", SqlDbType.VarChar).Value = LtPaisOper.Text
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL1, 6)
                            cmd.Parameters.Add("@RET", SqlDbType.Float).Value = Math.Round(RET, 6)
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA1, 6)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(NETO, 6)

                            cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = MetodoPago
                            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FormaPago
                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    'GRABAR PARTIDAS
                                    For k = 1 To 2
                                        Try
                                            If k = 1 Then
                                                'NoIdentificacion = tbConceptoNoIdentificacion.Text
                                                'Descripcion = tbConceptoDescripcion.Text
                                                'ClaveUnidad = ""
                                                'Cantidad = nudConceptoCantidad.Value
                                                'Precio = nudConceptoValorUnitario.Value
                                                'PesoEnKg = PESONETO1 * 1000
                                                'ClaveProdServ = TCVE_ART.Text
                                                'ClaveUnidad = TCVE_UNIDAD.Text
                                                'BienesTransp = TBienesTransp.Text
                                                'MaterialPeligroso = TCveMaterialPeligroso.Text
                                                'CveMaterialPeligroso = TCveMaterialPeligroso.Text
                                                'EMBALAJE = TEmbalaje.Text
                                                'DescripEmbalaje = LTEmbalaje.Text
                                            Else
                                                'NoIdentificacion = tbConceptoNoIdentificacion2.Text
                                                'Descripcion = tbConceptoDescripcion2.Text
                                                'ClaveUnidad = ""
                                                'Cantidad = nudConceptoCantidad2.Value
                                                'Precio = nudConceptoValorUnitario2.Value
                                                'PesoEnKg = PESONETO21 * 1000
                                                'ClaveProdServ = TCVE_ART2.Text
                                                'ClaveUnidad = TCVE_UNIDAD2.Text
                                                BienesTransp = TBienesTransp2.Text
                                                MaterialPeligroso = TCveMaterialPeligroso2.Text
                                                CveMaterialPeligroso = TCveMaterialPeligroso2.Text
                                                EMBALAJE = TEmbalaje2.Text
                                                DescripEmbalaje = LTEmbalaje2.Text
                                            End If

                                        Catch ex As Exception
                                            BITACORACFDI("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        Try
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
                                                    cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = FACTURA
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
                                            'MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    Next
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        'MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        BITACORACFDI("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    '███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
                    Var8 = ""

                    Try
                        Dim aCorreo As New ArrayList From {rutaPDF, RutaXML_TIMBRADO}
                        Try
                            Dim horaActual As String
                            horaActual = DateTime.Now.ToString("HH:mm")
                            If horaActual >= "24:00" And horaActual <= "12:00" Then
                                'Label1.Text = "Buenos Días"
                            ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                                'Label1.Text = "Buenas Tardes"
                            ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                                'Label1.Text = "Buenas Noches"
                            End If
                            MensaDia = horaActual
                        Catch ex As Exception
                            BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If CORREO_CLIENTE.Trim.Length > 0 Or TCorreoPer.Text.Length > 0 Or TCORREO1.Text.Length > 0 Or TCORREO2.Text.Length > 0 Or TCORREO3.Text.Length > 0 Then

                            If CORREO_CLIENTE.Trim.Length = 0 Then
                                If TCorreoPer.Text.Length > 0 Then
                                    CORREO_CLIENTE = TCorreoPer.Text
                                ElseIf TCORREO1.Text.Length > 0 Then
                                    CORREO_CLIENTE = TCORREO1.Text
                                ElseIf TCORREO2.Text.Length > 0 Then
                                    CORREO_CLIENTE = TCORREO2.Text
                                ElseIf TCORREO3.Text.Length > 0 Then
                                    CORREO_CLIENTE = TCORREO3.Text
                                End If
                            End If

                            If CORREO_CLIENTE.Trim.Length > 0 Then
                                SendEmail(CORREO_CLIENTE, "CFDI Carta porte",
                                    MensaDia & vbCrLf & vbCrLf &
                                    "CFDI Carta porte " & CVE_FOLIO_CP & vbCrLf &
                                    "Adjunto se envía representación CFDI Carta porte en formato PDF" & vbCrLf & vbCrLf &
                                     LtRazonSocialEmisor.Text, aCorreo, TCorreoPer.Text, TCORREO1.Text, TCORREO2.Text, TCORREO3.Text)
                            End If
                        End If
                    Catch ex As Exception
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    Try
                        If TCorreoPer.Text <> TCorreoPer.Tag Then
                            ACTUALIZA_CORREO_OPERADOR(LtCve_oper.Text, TCorreoPer.Text)
                        End If

                        If TCORREO1.Text.Trim.Length > 0 Or TCORREO2.Text.Trim.Length > 0 Or TCORREO3.Text.Trim.Length > 0 Then
                            SQL1 = "UPDATE CLIE_CLIB" & Empresa & " SET 
                                CAMPLIB7 = '" & TCORREO1.Text & "', CAMPLIB8 = '" & TCORREO2.Text & "', CAMPLIB9 = '" & TCORREO3.Text & "'
                                WHERE CLAVE = '" & TCVE_CLIE.Text & "'"
                            If EXECUTE_QUERY_NET(SQL) Then
                            End If
                        End If
                    Catch ex As Exception
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    Try
                        Dim FECHA_C As String = ""
                        Try
                            Dim FECHA_CAR As String = FechaCarga.Value.ToString("yyyy-MM-dd HH:mm:ss")
                            Dim F_CARGA As String = DateTime.ParseExact(FECHA_CAR, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyyMMdd HH:mm:ss")
                            FECHA_C = F_CARGA
                        Catch ex As Exception
                            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try 'FECHA_C = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")

                        If CVE_FOLIO_CP2.Trim.Length > 0 Then
                            SQL = "UPDATE GCCARTA_PORTE SET TIMBRADA = 'S', OBSER_CFDI = '" & TOBSER.Text & "', 
                                KM_RECORRIDOS = " & KMRECORRIDOS & ", FECHA_TIMBRE = '" & FECHA_T2 & "', 
                                FECHA_CARGA_TIMBRE = '" & FECHA_C & "'
                                WHERE 
                                CVE_FOLIO = '" & CVE_FOLIO_CP & "' OR CVE_FOLIO = '" & CVE_FOLIO_CP2 & "'"
                        Else
                            SQL = "UPDATE GCCARTA_PORTE SET TIMBRADA = 'S', OBSER_CFDI = '" & TOBSER.Text & "', 
                                KM_RECORRIDOS = " & KMRECORRIDOS & ", FECHA_TIMBRE = '" & FECHA_T2 & "', 
                                FECHA_CARGA_TIMBRE = '" & FECHA_C & "'
                                WHERE
                                CVE_FOLIO = '" & CVE_FOLIO_CP & "'"
                        End If

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("2500. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        SQL = "UPDATE GCASIGNACION_VIAJE SET KM_RECORRIDOS = " & KMRECORRIDOS & " WHERE CVE_VIAJE = '" & CVE_VIAJE & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("2500. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If PassDoc_Timbrado = "Timbrado" Then
                        CVE_BITA = GRABA_BITA(TCVE_CLIE.Text, FACTURA, NETO, "X", "Carta porte se le generó un CFDI")
                    Else
                        CVE_BITA = GRABA_BITA(TCVE_CLIE.Text, FACTURA, NETO, "X", "Carta porte se le generó nuevamemte un CFDI")
                    End If

                    Try
                        If SERIE_FAC_CP = "" Or SERIE_FAC_CP = "STAND." Then
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = ULT_DOC + 1 WHERE TIP_DOC = 'F' AND SERIE = 'STAND.'"
                        Else
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = ULT_DOC + 1 WHERE TIP_DOC = 'F' AND SERIE = '" & SERIE_FAC_CP & "'"
                        End If
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using

                        FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA("F", SERIE_FAC_CP)

                        If SERIE_FAC_CP.Trim.Length = 0 Or SERIE_FAC_CP = "STAND." Then
                            FACTURA = Space(10) & Format(FOLIO_VENTA, "0000000000")
                        Else
                            FACTURA = SERIE_FAC_CP & FOLIO_VENTA
                        End If

                        LTFACTURA.Text = FACTURA

                    Catch ex As Exception
                        BITACORACFDI("2500. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
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

            CP_IMPRIME_IMPORTES = True
            IMPRIMIR_CFDI(CVE_DOC, "CARTA PORTE")

            CP_IMPRIME_IMPORTES = False
            IMPRIMIR_CFDI(CVE_DOC, "CARTA PORTE", 2)

            Me.Close()
        Else
            btnTimbrarDigiBox.Enabled = True
        End If
    End Sub
    Sub ACTUALIZA_CORREO_OPERADOR(fCVE_OPER As String, fCORREO_OPER As String)
        Try
            If IsNumeric(fCVE_OPER) Then
                SQL = "UPDATE GCOPERADOR SET CORREO_PER = '" & fCORREO_OPER & "' WHERE CLAVE = " & CInt(fCVE_OPER)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            BITACORACFDI("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAgregarCliente_Click_1(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Try
            Try
                Var2 = "CLIE"
                Var4 = ""
                Var5 = ""
                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                    'Var5 = Fg(Fg.Row, 2).ToString 'NOMBRE
                    'Var6 = Fg(Fg.Row, 3).ToString 'rfc
                    'Var7 = Fg(Fg.Row, 4).ToString 'calle
                    'Var8 = Fg(Fg.Row, 5).ToString 'municipio

                    TCVE_CLIE.Text = Var4
                    LtNombreReceptor.Text = Var5
                    LtRFCReceptor.Text = Var6
                    Var2 = ""
                    Var4 = ""
                    Var5 = ""
                Else
                    TCVE_CLIE.Text = ""
                    LtNombreReceptor.Text = ""
                    LtRFCReceptor.Text = ""
                End If
            Catch Ex As Exception
                MsgBox("980. " & Ex.Message & vbNewLine & Ex.StackTrace)
                BITACORACFDI("980. " & Ex.Message & vbNewLine & Ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORACFDI("990. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("990. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CPConceptoAgregar()
        If HayErrorConcepto() Then Return
        'If cbClaveProdServ.SelectedItem IsNot Nothing Then c.ClaveProdServ = (CType(cbClaveProdServ.SelectedItem, cClaveProdServ)).ClaveProdServ
        'If cbClaveUnidad.SelectedItem IsNot Nothing Then c.ClaveUnidad = (CType(cbClaveUnidad.SelectedItem, cClaveUnidad)).ClaveUnidad
        'Dim c As Concepto = New Concepto With {
        '.Cantidad = nudConceptoCantidad.Value,
        '.ClaveProdServ = TCVE_ART.Text,
        '.ClaveUnidad = tbConceptoUnidad.Text,
        '.Descripcion = tbConceptoDescripcion.Text.Trim(),
        '.Descuento = nudConceptoDescuento.Value,
        '.Importe = nudConceptoImporte.Value,
        '.NoIdentificacion = tbConceptoNoIdentificacion.Text,
        '.Unidad = tbConceptoUnidad.Text,
        '.ValorUnitario = nudConceptoValorUnitario.Value,
        '.Impuestos = GetImpuestosConcepto(1)
        '}
        Try
            If IMPU1_1 = 0 And IMPU2_1 = 0 And IMPU3_1 = 0 And IMPU4_1 = 0 And IMPU1_2 = 0 And
                IMPU2_2 = 0 And IMPU3_2 = 0 And IMPU4_2 = 0 Then
                'c.ObjetoImp = "01"
            Else
                'c.ObjetoImp = "02"
            End If
        Catch ex As Exception
            BITACORACFDI("990. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        '_c.Conceptos.Concepto.Add(c)

        If CVE_FOLIO_CP2.Trim.Length > 0 Then
            'Dim c2 As Concepto = New Concepto With {
            '.Cantidad = nudConceptoCantidad2.Value,
            '.ClaveProdServ = TCVE_ART2.Text,
            '.ClaveUnidad = TCVE_UNIDAD.Text,
            '.Descripcion = tbConceptoDescripcion2.Text.Trim(),
            '.Descuento = nudConceptoDescuento2.Value,
            '.Importe = nudConceptoImporte2.Value,
            '.NoIdentificacion = tbConceptoNoIdentificacion2.Text,
            '.Unidad = TCVE_UNIDAD2.Text,
            '.ValorUnitario = nudConceptoValorUnitario2.Value,
            '.Impuestos = GetImpuestosConcepto(2)
            '}
            Try
                If IMPU1_1 = 0 And IMPU2_1 = 0 And IMPU3_1 = 0 And IMPU4_1 = 0 And IMPU1_2 = 0 And
                IMPU2_2 = 0 And IMPU3_2 = 0 And IMPU4_2 = 0 Then
                    'c2.ObjetoImp = "01"
                Else
                    'c2.ObjetoImp = "02"
                End If
            Catch ex As Exception
                BITACORACFDI("990. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            '_c.Conceptos.Concepto.Add(c2)
        End If

        bs.ResetBindings(False)
        CalculaTotales()
        'limpiarCampos()
    End Sub
    Private Sub Datos_carta_porte()
        Try
            Dim TotalMercancias As Integer, PESO_KG As Decimal, PESO_UNIDAD As String = ""

            If (_cartaPorte Is Nothing) Then
                _cartaPorte = New CartaPorte
            End If

            Try
                TKMRecorridos.UpdateValueWithCurrentText()
            Catch ex As Exception
            End Try

            _c.Complemento = New Complemento With {
                .CartaPorte20 = _cartaPorte
            }
            _cartaPorte.Version = "2.0"
            _cartaPorte.TotalDistRec = TKMRecorridos.Value
            _cartaPorte.TranspInternac = CboTransInter.Text

            Dim ubicaciones As New Ubicaciones()
            Dim ubicacionOrigen As New Ubicacion With {
                .TipoUbicacion = "Origen",
                .RFCRemitenteDestinatario = LtRFCOrigen.Text,
                .NombreRemitenteDestinatario = LtNombreOrigen.Text,
                .FechaHoraSalidaLlegada = FECHA_CARGA
            }
            Dim domicilioOrigen As New Domicilio With {
                .Calle = LtCalleOrigen.Text
            }

            If LtNumExtOrigen.Text.Trim.Length > 0 Then domicilioOrigen.NumeroExterior = LtNumExtOrigen.Text
            If LtNumIntOrigen.Text.Trim.Length > 0 Then domicilioOrigen.NumeroInterior = LtNumIntOrigen.Text

            'domicilioOrigen.Colonia = LtColoniaOrigen.Text
            domicilioOrigen.Localidad = LtLocalidadOrigen.Text
            If LtCPOrigen.Text.Trim.Length > 0 Then
                domicilioOrigen.CodigoPostal = LtCPOrigen.Text
            End If

            domicilioOrigen.Estado = LtEstadoOrigen.Text
            domicilioOrigen.Municipio = LtMunicipioOrigen.Text
            domicilioOrigen.Pais = LtPaisOrigen.Text
            ubicacionOrigen.Domicilio = domicilioOrigen

            'ubicacionDestino.IDUbicacion = "DE458563"
            Dim ubicacionDestino As New Ubicacion With {
                .TipoUbicacion = "Destino",
                .RFCRemitenteDestinatario = LtRFCDestino.Text,
                .NombreRemitenteDestinatario = LtNombreDestino.Text,
                .FechaHoraSalidaLlegada = FECHA_DESCARGA,
                .DistanciaRecorrida = TKMRecorridos.Value
            }
            Dim domicilioDestino As New Domicilio With {
                .Calle = LtCalleDestino.Text,
                .NumeroExterior = LtNumIntDestino.Text
            }

            If LtNumIntDestino.Text.Trim.Length > 0 Then domicilioDestino.NumeroInterior = LtNumIntDestino.Text
            'If LtColoniaDestino.Text.Trim.Length > 0 Then domicilioDestino.Colonia = LtColoniaDestino.Text

            If LtLocalidadDestino.Text.Trim.Length > 0 Then
                domicilioDestino.Localidad = LtLocalidadDestino.Text
            End If

            If LtCPDestino.Text.Trim.Length > 0 Then
                domicilioDestino.CodigoPostal = LtCPDestino.Text
            End If

            domicilioDestino.Estado = IIf(LtEstadoDestino.Text.Length > 3, LtEstadoDestino.Text.Substring(0, 3), LtEstadoDestino.Text)
            domicilioDestino.Municipio = LtMunicipioDestino.Text
            domicilioDestino.Pais = LtPaisDestino.Text

            'SE AGREGA AL OBJETO
            ubicacionDestino.Domicilio = domicilioDestino

            ubicaciones.Ubicacion.Add(ubicacionOrigen)
            ubicaciones.Ubicacion.Add(ubicacionDestino)
            _cartaPorte.Ubicaciones = ubicaciones
            'FIN QUITE LAS 3 LINEAS

            If LtCAP1.Text.Trim.Length > 0 And LtCAP2.Text.Trim.Length > 0 Then
                TotalMercancias = 2
            Else
                TotalMercancias = 1
            End If

            'MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1                MERCANCIAS 1                
            Dim mercancias As New Mercancias With {
                .NumTotalMercancias = TotalMercancias
            }
            '███████████████████████████████████████

            If PESO_KG_SINO = "S" Then
                PESO_KG = (PESONETO1 + PESONETO21) * 1000
                PESO_UNIDAD = "KGM"
            Else
                PESO_KG = PESONETO1 + PESONETO21
                PESO_UNIDAD = TUnidadPeso.Text
            End If

            mercancias.UnidadPeso = PESO_UNIDAD
            mercancias.PesoBrutoTotal = PESO_KG

            '███████████████████████████████████████
            Dim mercancia1 As New Mercancia 'With {
            '.Descripcion = tbConceptoDescripcion.Tag,
            '.ClaveUnidad = TCVE_UNIDAD.Text,
            '.Cantidad = 1
            '.PesoEnKg = PESONETO1 * 1000
            '}
            If LtMat_peligroso.Text = "Sí" Then
                mercancia1.DescripEmbalaje = LTEmbalaje.Text
                mercancia1.Embalaje = TEmbalaje.Text
                mercancia1.CveMaterialPeligroso = TCveMaterialPeligroso.Text
                mercancia1.MaterialPeligroso = LtMat_peligroso.Text
            End If
            mercancia1.BienesTransp = TBienesTransp.Text
            'mercancia1.Unidad = "Pieza"            'mercancia1.Dimensiones = "59/40/36plg"            'mercancia1.Moneda = "MXN"
            'mercancia1.ValorMercancia = 150000
            mercancias.Mercancia.Add(mercancia1)

            'MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2                MERCANCIAS 2

            If CVE_FOLIO_CP2.Trim.Length > 0 Then
                'mercancia2.Unidad = "Pieza"            'mercancia2.Dimensiones = "59/40/36plg"
                '███████████████████████████████████████
                Dim mercancia2 As New Mercancia 'With {
                '.Descripcion = tbConceptoDescripcion2.Tag,
                '.ClaveUnidad = TCVE_UNIDAD2.Text,
                '.Cantidad = 1,
                '.PesoEnKg = PESONETO21 * 1000
                '}
                If LtMat_peligroso2.Text = "Sí" Then
                    mercancia2.DescripEmbalaje = LTEmbalaje2.Text
                    mercancia2.Embalaje = TEmbalaje2.Text
                    mercancia2.CveMaterialPeligroso = TCveMaterialPeligroso2.Text
                    mercancia2.MaterialPeligroso = LtMat_peligroso2.Text
                End If
                mercancia2.BienesTransp = TBienesTransp2.Text
                mercancias.Mercancia.Add(mercancia2)
            End If

            'mercancia2.Moneda = "MXN"            'mercancia2.ValorMercancia = 150000
            'Dim cantidadTransporta As CantidadTransporta = New CantidadTransporta()
            'CantidadTransporta.Cantidad = 8            'CantidadTransporta.IDOrigen = "OR458563"
            'CantidadTransporta.IDDestino = "DE458563"            'mercancia2.CantidadTransporta.Add(cantidadTransporta)
            Dim autotransporte As New Autotransporte With {
                .NumPermisoSCT = TNumPermisoSCT.Text,
                .PermSCT = TPermSCT.Text
            }

            Dim identificacionVehicular As New IdentificacionVehicular With {
                .AnioModeloVM = TAnioModeloVM.Text,
                .PlacaVM = TPlacaVM.Text,
                .ConfigVehicular = TConfigVehicular.Text
            }


            If TPolizaRespCivil.Text.Trim.Length > 0 And TAseguraRespCivil.Text.Trim.Length > 0 Then

                Dim seguros As New Seguros()
                If TPolizaMedAmbiente.Text.Trim.Length > 0 Then seguros.PolizaMedAmbiente = TPolizaMedAmbiente.Text
                If TAseguraMedAmbiente.Text.Trim.Length > 0 Then seguros.AseguraMedAmbiente = TAseguraMedAmbiente.Text
                If TPolizaRespCivil.Text.Trim.Length > 0 Then seguros.PolizaRespCivil = TPolizaRespCivil.Text
                If TAseguraRespCivil.Text.Trim.Length > 0 Then seguros.AseguraRespCivil = TAseguraRespCivil.Text
                'seguros.AseguraCarga = "Seguros Afirme"
                'seguros.PolizaCarga = "NUMPOLIZASEGURO"
                'seguros.PrimaSeguro = 1200
                autotransporte.Seguros = seguros
            End If

            If CVE_TANQUE1.Trim.Length > 0 Or CVE_TANQUE2.Trim.Length > 0 Then
                Dim remolques As New Remolques()
                Dim remolque1 As New Remolque()
                Dim remolque2 As New Remolque()

                If CVE_TANQUE1.Trim.Length > 0 Then
                    remolque1.Placa = TPlaca1.Text
                    remolque1.SubTipoRem = TSubTipoRem1.Text
                    remolques.Remolque.Add(remolque1)
                End If

                If CVE_TANQUE2.Trim.Length > 0 Then
                    remolque2.Placa = TPlaca2.Text
                    remolque2.SubTipoRem = TSubTipoRem2.Text
                    remolques.Remolque.Add(remolque2)
                End If
                autotransporte.Remolques = remolques
            End If

            autotransporte.IdentificacionVehicular = identificacionVehicular
            mercancias.Autotransporte = autotransporte

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

            DomicilioTipoFigura.Pais = "MEX" 'PAIS_OPERADOR
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
    Sub OBTENER_CARTA_PORTE(FCVE_FOLIO As String, FNumCartaPorte As Integer)

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT C.CVE_FOLIO, C.CVE_VIAJE, C.CVE_DOCR, C.CLIENTE, C.FECHA_DOC, C.TIPO_VIAJE, C.CVE_OPER, C.CLAVE_O, C.CLAVE_D, C.CVE_TRACTOR, 
                C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, C.CVE_PLAZA1, C.CVE_PLAZA2, ISNULL(PESO_BRUTO1,0) AS PESO1, 
                ISNULL(TARA1,0) AS T1, ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, ISNULL(PESO_BRUTO3,'0') AS PESO3, ISNULL(TARA3,'0') AS T3,
                ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4, C.CVE_MAT, FLETE, C.FECHA_CARGA, C.FECHA_DESCARGA, CVE_DOCP, C.ORDEN_DE, 
                C.EMBARQUE, C.CARGA_ANTERIOR, C.REM_CARGA, VALOR_DECLARADO, SUBTOTAL, IVA, RETENCION, NETO, ISNULL(CANT,0) AS CANTIDAD, 
                ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1, ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, 
                ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2, ISNULL(U.ANO_MODELO,'') AS ANO_MOD,
                STUFF(CONVERT(VARCHAR(50), C.FECHAELAB, 127), 20, 4, '') AS FELAB, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL, C.CVE_ART, 
                ISNULL(P.DESCR,'') AS DESCR_MAT, ISNULL(PEDIMENTO,'') AS CP_PEDIMENTO, R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN,
                ISNULL(C.CVE_ESQIMPU,0) AS CVE_ESQ, ISNULL(R.KMS,0) AS KM, ISNULL(TP.DESCR,'') AS DESCR_TIPO_OPE, I.DESCR AS DESCR_INVE, 
                ISNULL(TP.CVE_TIPO,0) AS TPCVE_OPE, ISNULL(R.CVE_TIPO_OPE,0) AS CPCVE_TIPO_OPE
                FROM GCCARTA_PORTE C 
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = C.RECOGER_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = C.ENTREGAR_EN
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = C.CVE_TRACTOR
                LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = C.CVE_TANQUE1
                LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = C.CVE_TANQUE2
                LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = CAST(C.CVE_ART AS INT)
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = C.CVE_MAT
                LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = R.CVE_TIPO_OPE
                WHERE CVE_FOLIO = '" & FCVE_FOLIO & "' AND C.STATUS = 'A'"



            SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.FECHA_CARGA, A.FECHA_DESCARGA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, 
                ISNULL(CVE_ST_VALE,1) AS STATUS_VALE, ISNULL(A.CVE_ST_UNI,0) AS STATUS_UNI, A.TIPO_UNI, A.TIPO_VIAJE, A.CVE_OPER, 
                A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA, 
                ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, 
                ISNULL(A.CVE_TAB, '') AS CVETAB, A.RUTA_SEN_VAC, A.RUTA_SE_CAR, A.RUTA_FULL_VAC, A.RUTAL_FULL_CAR, A.NOTA, 
                A.CVE_CAP1, A.CVE_CAP2, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR, ISNULL(A.CVE_TAB_VIAJE,0) AS TAB_VIAJE, ISNULL(R.CVE_TAB,'') AS CVE_TAB_RUTA,
                A.CLIENTE, A.CVE_MONED, A.VOLUMEN_PESO, STUFF(CONVERT(VARCHAR(50), A.FECHAELAB, 127), 20, 4, '') AS FELAB,
                ISNULL(REM_CARGA1,'') AS REM1, ISNULL(PESO_BRUTO1,0) AS PESO1, ISNULL(TARA1,0) AS T1, 
                ISNULL(REM_CARGA2,'') AS REM2, ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, 
                ISNULL(REM_CARGA3,'') AS REM3, ISNULL(PESO_BRUTO3,'0') AS PESO3, ISNULL(TARA3,'0') AS T3, 
                ISNULL(REM_CARGA4,'') AS REM4, ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4, 
			    ISNULL(SUBTOTAL,0) AS SUBT, ISNULL(IVA,0) AS IV, ISNULL(RETENCION,0) AS RET, ISNULL(NETO,0) AS NET, ISNULL(CANT,0) AS CANTIDAD, 
                ISNULL(REM_CARGA,0) AS REM_CAR, ISNULL(FLETE,0) AS FLET, ISNULL(CVE_ESQIMPU,0) AS CVE_ESQ, ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, 
                ISNULL(U.ANO_MODELO,'') AS ANO_MOD, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1, ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, 
                ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2, ISNULL(R.KMS,0) AS KM,
                R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN, AA.POLIZARESPCIVIL, AA.ASEGURARESPCIVIL, 
                ISNULL(TP.CVE_TIPO,0) AS TPCVE_OPE, ISNULL(R.CVE_TIPO_OPE,0) AS CPCVE_TIPO_OPE
                FROM GCASIGNACION_VIAJE A 
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = A.CVE_CON
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = A.CVE_TRACTOR
                LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = A.CVE_TANQUE1
                LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = A.CVE_TANQUE2
                LEFT JOIN GCASEGURADORAS AA ON AA.CLAVE = U.SE_ASEGURADORA
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = A.RECOGER_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = A.ENTREGAR_EN
                LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = R.CVE_TIPO_OPE
                WHERE A.CVE_VIAJE = '" & CVE_VIAJE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    'CVE_DOCR = dr.ReadNullAsEmptyString("CVE_DOCR")
                    'CVE_PEDIDO = dr.ReadNullAsEmptyString("CVE_DOCP")
                    ORDEN_DE = dr.ReadNullAsEmptyString("ORDEN_DE")
                    EMBARQUE = dr.ReadNullAsEmptyString("EMBARQUE")

                    CP_ORDEN_DE = ORDEN_DE
                    CP_EMBARQUE = EMBARQUE

                    CARGA_ANTERIOR = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                    CANT = dr("CANTIDAD")
                    'CLIETE FISCAL

                    CLIENTE = dr("CLIENTE").ToString
                    TCVE_CLIE.Text = CLIENTE

                    'FIN CLIENTE FISCAL
                    If IsDate(dr("FELAB")) Then
                        FECHA_DOC = dr("FELAB")
                    Else
                        FECHA_DOC = Now.ToString("yyyy-MM-ddTHH:mm:ss")
                    End If
                    PLACAS_MEX_TRACTOR = dr("PLACAS_MEX_TRACTOR")
                    PLACAS_MEX_TANQUE1 = dr("PLACAS_MEX_TANQUE1")
                    PLACAS_MEX_TANQUE2 = dr("PLACAS_MEX_TANQUE2")

                    CVE_OPER = dr.ReadNullAsEmptyLong("CVE_OPER")

                    POLIZARESPCIVIL = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                    ASEGURARESPCIVIL = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")

                    'CVE_ART = dr.ReadNullAsEmptyString("CVE_MAT") '                       TABLA GCPRODUCTOS
                    'CVE_MAT = dr.ReadNullAsEmptyString("CVE_ART") 'TABLA INVE01

                    'VALOR_DECLARADO = dr("VALOR_DECLARADO")

                    If CLIENTE.Trim.Length > 0 Then
                        TCVE_CLIE.Text = CLIENTE
                    End If                    'CP_PEDIMENTO = dr("CP_PEDIMENTO")                    'If CP_PEDIMENTO = "0" Then CP_PEDIMENTO = ""
                    TKMRecorridos.Value = dr("KM")

                    CVE_ESQ1 = dr("CVE_ESQ")

                Catch ex As Exception
                    BITACORACFDI("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM GCOPERADOR WHERE CLAVE = " & CVE_OPER
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                NOMBRE_OPERADOR = dr2.ReadNullAsEmptyString("NOMBRE")
                                RFC_OPERADOR = dr2.ReadNullAsEmptyString("RFC")
                                CALLE_OPERADOR = dr2.ReadNullAsEmptyString("CALLE")
                                NUMEXT_OPERADOR = dr2.ReadNullAsEmptyString("NUM_EXT")
                                'NUMINT_OPERADOR = dr2("NUM_INT")
                                COLONIA_OPERADOR = dr2.ReadNullAsEmptyString("COLONIA_SAT")
                                LOCALIDAD_OPERADOR = dr2.ReadNullAsEmptyString("POBLACION_SAT")
                                CODIGOPOSTAL_OPERADOR = dr2.ReadNullAsEmptyString("CP_SAT")
                                ESTADO_OPERADOR = dr2.ReadNullAsEmptyString("ESTADO_SAT")
                                MUNICIPIO_OPERADOR = dr2.ReadNullAsEmptyString("MUNICIPIO_SAT")
                                PAIS_OPERADOR = dr2.ReadNullAsEmptyString("PAIS_SAT")
                                LICENCIA = dr2.ReadNullAsEmptyString("LICENCIA")

                                LtCve_oper.Text = CVE_OPER
                                LtRFCOper.Text = RFC_OPERADOR
                                LtNombreOper.Text = NOMBRE_OPERADOR
                                LtCalleOper.Text = CALLE_OPERADOR
                                'LtNumIntR.Text = 
                                LtNumExtOper.Text = NUMEXT_OPERADOR
                                LtColoniaOper.Text = COLONIA_OPERADOR
                                LtLocalidadOper.Text = LOCALIDAD_OPERADOR
                                LtCPOper.Text = CODIGOPOSTAL_OPERADOR
                                LtEstadoOper.Text = ESTADO_OPERADOR
                                LtMunicipioOper.Text = MUNICIPIO_OPERADOR
                                LtMunicipio.Text = dr2.ReadNullAsEmptyString("MUNICIPIO")

                                If PAIS_OPERADOR = "52" Or PAIS_OPERADOR = "052" Or PAIS_OPERADOR = "MEXICO" Or PAIS_OPERADOR = "" Then
                                    LtPaisOper.Text = "MEX"
                                Else
                                    LtPaisOper.Text = PAIS_OPERADOR
                                End If
                                LtLicenciaOper.Text = LICENCIA
                                TCorreoPer.Text = dr2.ReadNullAsEmptyString("CORREO_PER")
                                TCorreoPer.Tag = TCorreoPer.Text
                            Else
                                NOMBRE_OPERADOR = "" : RFC_OPERADOR = "" : CALLE_OPERADOR = "" : NUMEXT_OPERADOR = "" : NUMINT_OPERADOR = "" : COLONIA_OPERADOR = ""
                                LOCALIDAD_OPERADOR = "" : CODIGOPOSTAL_OPERADOR = "" : ESTADO_OPERADOR = "" : MUNICIPIO_OPERADOR = "" : PAIS_OPERADOR = ""
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORACFDI("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                CVE_TRACTOR = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                CVE_TANQUE1 = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                CVE_TANQUE2 = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString

                RECOGER_EN = dr.ReadNullAsEmptyString("RECOGER").ToString
                ENTREGAR_EN = dr.ReadNullAsEmptyString("ENTREGAR").ToString

                CP_RECOGER_EN = dr.ReadNullAsEmptyString("DESCR_RECOGER_EN")
                CP_ENTREGAR_EN = dr.ReadNullAsEmptyString("DESCR_ENTREGAR_EN")

                CLAVE_O = dr.ReadNullAsEmptyString("ORIGEN")
                CLAVE_D = dr.ReadNullAsEmptyString("DESTINO")

                LtClave_O.Text = CLAVE_O
                LtClave_D.Text = CLAVE_D

                LtTractor.Text = CVE_TRACTOR
                LtTanque1.Text = CVE_TANQUE1
                LtTanque2.Text = CVE_TANQUE2

                TPlacaVM.Text = PLACAS_MEX_TRACTOR
                TPlaca1.Text = PLACAS_MEX_TANQUE1
                TPlaca2.Text = PLACAS_MEX_TANQUE2
                TAnioModeloVM.Text = dr.ReadNullAsEmptyString("ANO_MOD")
                TSubTipoRem1.Text = dr.ReadNullAsEmptyString("SUTIREM1")
                TSubTipoRem2.Text = dr.ReadNullAsEmptyString("SUTIREM2")

                TPolizaRespCivil.Text = POLIZARESPCIVIL
                TAseguraRespCivil.Text = ASEGURARESPCIVIL

                If LtTanque1.Text.Trim.Length = 0 Then
                    LRemolque1.Visible = False
                    LR1.Visible = False
                    LR2.Visible = False
                    LR3.Visible = False
                    LR4.Visible = False
                    LtTanque1.Visible = False
                    TPlaca1.Visible = False
                    TSubTipoRem1.Visible = False
                    BtnSubTipoRem1.Visible = False
                    LTSubTipoRem1.Visible = False
                End If

                If LtTanque2.Text.Trim.Length = 0 Then
                    LRemolque2.Visible = False
                    LR21.Visible = False
                    LR22.Visible = False
                    LR23.Visible = False
                    LR24.Visible = False
                    LtTanque2.Visible = False
                    TPlaca2.Visible = False
                    TSubTipoRem2.Visible = False
                    BtnSubTipoRem2.Visible = False
                    LTSubTipoRem2.Visible = False
                End If

                Try
                    'string sFechaSAT= Fecha.ToString("yyyy-MM-ddTHH:mm:ss");
                    'FECHA_CARGA = dr("FECHA_CARGA").ToString("yyyy-MM-ddTHH:mm:ss")
                    'FECHA_DESCARGA = dr("FECHA_DESCARGA").ToString("yyyy-MM-ddTHH:mm:ss")
                    FECHA_CARGA = dr("FECHA_CARGA")
                    FECHA_DESCARGA = dr("FECHA_DESCARGA")

                    FechaCarga.Value = dr("FECHA_CARGA") '.ToString("yyyy-MM-ddTHH:mm:ss")
                    FechaDescarga.Value = dr("FECHA_DESCARGA") '.ToString("yyyy-MM-ddTHH:mm:ss")
                Catch ex As Exception
                    BITACORACFDI("1250. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                CP_ORDEN_DE = ORDEN_DE
                CP_EMBARQUE = EMBARQUE

                CP_TRACTOR = CVE_TRACTOR
                CP_TANQUE1 = CVE_TANQUE1
                CP_TANQUE2 = CVE_TANQUE2

                CP_PLACAS_TRACTOR = PLACAS_MEX_TRACTOR
                CP_PLACAS_TANQUE1 = PLACAS_MEX_TANQUE1
                CP_PLACAS_TANQUE2 = PLACAS_MEX_TANQUE2

                CP_POLIZARESPCIVIL = POLIZARESPCIVIL
                CP_ASEGURARESPCIVIL = ASEGURARESPCIVIL
                '              TP                 CP
                Debug.Print(dr("TPCVE_OPE"), dr("CPCVE_TIPO_OPE"))

                PESO_BRUTO1 = dr("PESO1")
                TARA1 = dr("T1")
                PESO_BRUTO2 = dr("PESO2")
                TARA2 = dr("T2")
                PESO_BRUTO3 = dr("PESO3")
                TARA3 = dr("T3")
                PESO_BRUTO4 = dr("PESO4")
                TARA4 = dr("T4")

                PESONETO1 = PESO_BRUTO1 - TARA1
                PESONETO2 = PESO_BRUTO2 - TARA2
                PESONETO3 = PESO_BRUTO3 - TARA3
                PESONETO4 = PESO_BRUTO4 - TARA4

                'tbConceptoNoIdentificacion.Text = dr.ReadNullAsEmptyString("CVE_MAT").ToString
                'nudConceptoCantidad.Value = 1
                'nudConceptoValorUnitario.Value = dr.ReadNullAsEmptyDecimal("SUBTOTAL")
                'nudConceptoImporte.Value = dr.ReadNullAsEmptyDecimal("SUBTOTAL")

                'SE CAMBIO LA DESCRIPCION DEL PRODUCTO 29 JULIO 2022

                'If dr.ReadNullAsEmptyString("DESCR_TIPO_OPE").ToString.Trim.Length > 0 Then
                'tbConceptoDescripcion.Text = dr.ReadNullAsEmptyString("DESCR_TIPO_OPE")
                'Else
                'tbConceptoDescripcion.Text = dr.ReadNullAsEmptyString("DESCR_INVE")
                'End If
                'tbConceptoDescripcion.Tag = dr.ReadNullAsEmptyString("DESCR_MAT")

                'ISNULL(SUBTOTAL,0) AS SUBT, ISNULL(IVA,0) AS IV, ISNULL(RETENCION,0) AS RET, ISNULL(NETO,0) AS NET, ISNULL(CANT,0) AS CANTIDAD, 
                'ISNULL(REM_CARGA, 0) As REM_CAR, ISNULL(FLETE,0) As FLET, ISNULL(CVE_ESQIMPU,0) As CVE_ESQ, ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, 
                FLETE = dr.ReadNullAsEmptyDecimal("FLET")
                SUBTOTAL1 += dr.ReadNullAsEmptyDecimal("SUBT")
                IVA1 += dr.ReadNullAsEmptyDecimal("IV")
                RET += dr.ReadNullAsEmptyDecimal("RET")
                NETO += dr.ReadNullAsEmptyDecimal("NET")

                LtSubtotal.Text = Format(SUBTOTAL1, "###,###,##0.0000")
                LtIVA.Text = Format(IVA1, "###,###,##0.0000")
                LtRetencion.Text = Format(RET, "###,###,##0.0000")
                LtTotal.Text = Format(NETO, "###,###,##0.0000")
                'AQUI SLO UNA VEZ X QUE ES CARTA PORTE X EL MISMO TRACTOR
            End If
            dr.Close()

            If CVE_TRACTOR.Trim.Length > 0 And CVE_TANQUE1.Trim.Length > 0 And CVE_TANQUE2.Trim.Length > 0 Then
                TConfigVehicular.Text = "T3S2R4"
            Else
                TConfigVehicular.Text = "C3R3"
            End If

            TConfigVehicular_Validated(Nothing, Nothing)

        Catch ex As Exception
            BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If FNumCartaPorte = 1 Then
            Try
                If CLAVE_O.Trim.Length > 0 Then
                    SQL = "Select C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.DOMICILIO2, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                        C.COLONIA_SAT, C.POBLACION, P1.CLAVE_SAT_LOC, C.MUNICIPIO, P1.CLAVE_SAT_MUN, C.ESTADO, E.CLAVE_SAT_EST, E.CLAVE_SAT_PAIS, C.PAIS_SAT, 
                        ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                        FROM GCCLIE_OP C 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                        LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                        WHERE C.CLAVE = '" & CLAVE_O & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                LtNombreOrigen.Text = dr.ReadNullAsEmptyString("NOMBRE").ToString
                                LtCalleOrigen.Text = dr.ReadNullAsEmptyString("DOMICILIO").ToString & " " & dr.ReadNullAsEmptyString("DOMICILIO2").ToString.Trim
                                'tDOMICILIO2.Text = dr("DOMICILIO2").ToString
                                LtRFCOrigen.Text = dr.ReadNullAsEmptyString("RFC").ToString.Replace("-", "")
                                LtCPOrigen.Text = dr.ReadNullAsEmptyString("CP_SAT")
                                LtColoniaOrigen.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")

                                LtLocalidadOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                                LtMunicipioOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")

                                LtEstadoOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                                If LtEstadoDestino.Text = "VERACRUZ" Then LtEstadoDestino.Text = "VER"
                                LtPaisOrigen.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                                If LtPaisDestino.Text <> "MEX" Then LtPaisDestino.Text = "MEX"
                                LtMunicOrigen.Text = dr.ReadNullAsEmptyString("MUNICIPIO")

                            End If
                        End Using
                    End Using
                End If
            Catch ex As Exception
                BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CLAVE_D.Trim.Length > 0 Then
                    SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.DOMICILIO2, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                        C.COLONIA_SAT, C.POBLACION, C.ESTADO, 
                        ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, P1.CLAVE_SAT_LOC, C.MUNICIPIO, P1.CLAVE_SAT_MUN, E.CLAVE_SAT_EST, E.CLAVE_SAT_PAIS, 
                        ISNULL(P1.STATUS,'A') AS ST_PLAZA
                        FROM GCCLIE_OP C 
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA
                        LEFT JOIN GCESTADOS E ON E.CVE_ESTADO = P1.CVE_ESTADO
                        WHERE C.CLAVE = '" & CLAVE_D & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                LtNombreDestino.Text = dr.ReadNullAsEmptyString("NOMBRE").ToString
                                LtCalleDestino.Text = dr.ReadNullAsEmptyString("DOMICILIO").ToString & " " & dr.ReadNullAsEmptyString("DOMICILIO2").ToString.Trim
                                'tDOMICILIO2.Text = dr("DOMICILIO2").ToString
                                LtRFCDestino.Text = dr.ReadNullAsEmptyString("RFC").ToString.Replace("-", "")
                                LtCPDestino.Text = dr.ReadNullAsEmptyString("CP_SAT")
                                LtColoniaDestino.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")

                                LtLocalidadDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_LOC")
                                LtMunicipioDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_MUN")

                                LtEstadoDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_EST")
                                If LtEstadoDestino.Text = "VERACRUZ" Then LtEstadoDestino.Text = "VER"
                                LtPaisDestino.Text = dr.ReadNullAsEmptyString("CLAVE_SAT_PAIS")
                                If LtPaisDestino.Text <> "MEX" Then LtPaisDestino.Text = "MEX"
                                LtMunicDest.Text = dr.ReadNullAsEmptyString("MUNICIPIO")
                            End If
                        End Using
                    End Using
                End If
            Catch ex As Exception
                BITACORACFDI("1260. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        'If CVE_MAT.Trim.Length > 0 Then
    End Sub

    Private Sub CbTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoComprobante.SelectedIndexChanged
        Try
            'lista.Add(New cTipoComprobante(1, "I", "Ingreso"))
            'lista.Add(New cTipoComprobante(1, "E", "Egreso"))
            'lista.Add(New cTipoComprobante(1, "T", "Traslado"))
            'lista.Add(New cTipoComprobante(1, "N", "Nomina"))
            'lista.Add(New cTipoComprobante(1, "P", "Pago"))

            Select Case (CType(cbTipoComprobante.SelectedItem, cTipoComprobante)).TipoComprobante
                Case "I"
                    'nudConceptoCantidad.Value = 1
                    'nudConceptoValorUnitario.Value = FLETE
                    'nudConceptoImporte.Value = FLETE
                Case "E"
                    'nudConceptoCantidad.Value = 1
                    'nudConceptoImporte.Value = FLETE
                Case "T"
                    'nudConceptoCantidad.Value = 1
                    'nudConceptoValorUnitario.Value = 0
                    'nudConceptoImporte.Value = 0
                Case "N"
                    'nudConceptoCantidad.Value = 1
                    'nudConceptoValorUnitario.Value = 0
                    'nudConceptoImporte.Value = 0
                Case "P"
                    'nudConceptoCantidad.Value = 1
                    'nudConceptoValorUnitario.Value = 0
                    'nudConceptoImporte.Value = 0
            End Select

            CPConceptoAgregar()

        Catch ex As Exception
            BITACORACFDI("1270. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Generar CFDI 4.0")
        Me.Dispose()
    End Sub
    Private Sub BtnUnidadPeso_Click(sender As Object, e As EventArgs) Handles BtnUnidadPeso.Click
        Try
            Var2 = "tblcclaveunidadpeso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUnidadPeso.Text = Var4
                LTUnidadPeso.Text = Var5
                TBienesTransp.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEmbalaje_Click(sender As Object, e As EventArgs) Handles BtnEmbalaje.Click
        Try
            Var2 = "tblctipoembalaje"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TEmbalaje.Text = Var4
                LTEmbalaje.Text = Var5
                TPermSCT.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCveMaterialPeligroso_Click(sender As Object, e As EventArgs) Handles BtnCveMaterialPeligroso.Click
        Try
            Var2 = "tblcmaterialpeligroso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCveMaterialPeligroso.Text = Var4
                LTCveMaterialPeligroso.Text = Var5
                TEmbalaje.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBienesTransp_Click(sender As Object, e As EventArgs) Handles BtnBienesTransp.Click
        Try
            Var2 = "SAT_CLAVEPROD_SERVCP"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TBienesTransp.Text = Var4
                LTBienesTransp.Text = Var5
                If LtMat_peligroso.Text = "No" Then
                    TPermSCT.Focus()
                Else
                    TCveMaterialPeligroso.Focus()
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("1320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPermSCT_Click(sender As Object, e As EventArgs) Handles BtnPermSCT.Click
        Try
            Var2 = "PermSCT"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPermSCT.Text = Var4
                LTPermSCT.Text = Var5
                TAnioModeloVM.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1340. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSubTipoRem2_Click(sender As Object, e As EventArgs) Handles BtnSubTipoRem2.Click
        Try
            Var2 = "SubTipoRem"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TSubTipoRem2.Text = Var4
                LTSubTipoRem2.Text = Var5
                'TCVE_ART.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSubTipoRem1_Click(sender As Object, e As EventArgs) Handles BtnSubTipoRem1.Click
        Try
            Var2 = "SubTipoRem"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TSubTipoRem1.Text = Var4
                LTSubTipoRem1.Text = Var5
                TPlaca2.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1360. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnConfigVehicular_Click(sender As Object, e As EventArgs) Handles BtnConfigVehicular.Click
        Try
            Var2 = "ConfigVehicular"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TConfigVehicular.Text = Var4
                LTConfigVehicular.Text = Var5
                TPolizaMedAmbiente.Focus()
            End If
        Catch ex As Exception
            BITACORACFDI("1370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TUnidadPeso_Validated(sender As Object, e As EventArgs) Handles TUnidadPeso.Validated
        Try
            If TUnidadPeso.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcclaveunidadpeso WHERE clave = '" & TUnidadPeso.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTUnidadPeso.Text = dr("nombre")
                            TBienesTransp.Focus()
                        Else
                            MsgBox("Unidad de peso inexistente")
                            LTUnidadPeso.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTUnidadPeso.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEmbalaje_Validated(sender As Object, e As EventArgs) Handles TEmbalaje.Validated
        Try
            If TEmbalaje.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblctipoembalaje WHERE clave = '" & TEmbalaje.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTEmbalaje.Text = dr("descripcion")
                            TPermSCT.Focus()
                        Else
                            MsgBox("Embalaje inexistente")
                            LTEmbalaje.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTEmbalaje.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCveMaterialPeligroso_Validated(sender As Object, e As EventArgs) Handles TCveMaterialPeligroso.Validated
        Try
            If TCveMaterialPeligroso.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcmaterialpeligroso WHERE clave = '" & TCveMaterialPeligroso.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTCveMaterialPeligroso.Text = dr("descripcion")
                            TEmbalaje.Focus()
                        Else
                            MsgBox("Material peligroso inexistente")
                            LTCveMaterialPeligroso.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTCveMaterialPeligroso.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPermSCT_Validated(sender As Object, e As EventArgs) Handles TPermSCT.Validated
        Try
            If TPermSCT.Text.Trim.Length > 0 Then
                Select Case TPermSCT.Text
                    Case "TPAF01"
                        LTPermSCT.Text = "Autotransporte Federal de carga general."
                        TAnioModeloVM.Focus()
                    Case "TPAF02"
                        LTPermSCT.Text = "Transporte privado de carga."
                        TAnioModeloVM.Focus()
                    Case "TPAF03"
                        LTPermSCT.Text = "Autotransporte Federal de Carga Especializada de materiales y residuos peligrosos."
                        TAnioModeloVM.Focus()
                    Case Else
                        MsgBox("Permiso inexistente")
                        LTPermSCT.Text = ""
                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("1430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TConfigVehicular_Validated(sender As Object, e As EventArgs) Handles TConfigVehicular.Validated
        Try
            If TConfigVehicular.Text.Trim.Length > 0 Then
                Select Case TConfigVehicular.Text
                    Case "C2"
                        LTConfigVehicular.Text = "Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)"
                    Case "C3"
                        LTConfigVehicular.Text = "Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)"
                    Case "C2R2"
                        LTConfigVehicular.Text = "Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)"
                    Case "C3R2"
                        LTConfigVehicular.Text = "Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)"
                    Case "C2R3"
                        LTConfigVehicular.Text = "Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)"
                    Case "C3R3"
                        LTConfigVehicular.Text = "Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)"
                    Case "T2S1"
                        LTConfigVehicular.Text = "Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)"
                    Case "T2S2"
                        LTConfigVehicular.Text = "Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)"
                    Case "T2S3"
                        LTConfigVehicular.Text = "Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)"
                    Case "T3S1"
                        LTConfigVehicular.Text = "Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)"
                    Case "T3S2"
                        LTConfigVehicular.Text = "Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)"
                    Case "T3S3"
                        LTConfigVehicular.Text = "Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)"
                    Case "T2S1R2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
                    Case "T2S2R2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
                    Case "T2S1R3"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
                    Case "T3S1R2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
                    Case "T3S1R3"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
                    Case "T3S2R2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
                    Case "T3S2R3"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)"
                    Case "T3S2R4"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)"
                    Case "T2S2S2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
                    Case "T3S2S2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
                    Case "T3S3S2"
                        LTConfigVehicular.Text = "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
                    Case "OTROEV"
                        LTConfigVehicular.Text = "Especializado de Voluminoso"
                    Case "OTROEGP"
                        LTConfigVehicular.Text = "Especializado de Gran Peso"
                    Case "OTROSG"
                        LTConfigVehicular.Text = "Servicio de Grúas"
                    Case Else
                        MsgBox("Permiso inexistente")
                        LTConfigVehicular.Text = ""
                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("1440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TSubTipoRem1_Validated(sender As Object, e As EventArgs) Handles TSubTipoRem1.Validated
        Try
            If TSubTipoRem1.Text.Trim.Length > 0 Then
                Select Case TSubTipoRem1.Text
                    Case "CTR001"
                        LTSubTipoRem1.Text = "Caballete"
                    Case "CTR002"
                        LTSubTipoRem1.Text = "Caja"
                    Case "CTR003"
                        LTSubTipoRem1.Text = "Caja Abierta"
                    Case "CTR004"
                        LTSubTipoRem1.Text = "Caja Cerrada"
                    Case "CTR005"
                        LTSubTipoRem1.Text = "Caja De Recolección Con Cargador Frontal"
                    Case "CTR006"
                        LTSubTipoRem1.Text = "Caja Refrigerada"
                    Case "CTR007"
                        LTSubTipoRem1.Text = "Caja Seca"
                    Case "CTR008"
                        LTSubTipoRem1.Text = "Caja Transferencia"
                    Case "CTR009"
                        LTSubTipoRem1.Text = "Cama Baja o Cuello Ganso"
                    Case "CTR010"
                        LTSubTipoRem1.Text = "Chasis Portacontenedor"
                    Case "CTR011"
                        LTSubTipoRem1.Text = "Convencional De Chasis"
                    Case "CTR012"
                        LTSubTipoRem1.Text = "Equipo Especial"
                    Case "CTR013"
                        LTSubTipoRem1.Text = "Estacas"
                    Case "CTR014"
                        LTSubTipoRem1.Text = "Góndola Madrina"
                    Case "CTR015"
                        LTSubTipoRem1.Text = "Grúa Industrial"
                    Case "CTR016"
                        LTSubTipoRem1.Text = "Grúa "
                    Case "CTR017"
                        LTSubTipoRem1.Text = "Integral"
                    Case "CTR018"
                        LTSubTipoRem1.Text = "Jaula"
                    Case "CTR019"
                        LTSubTipoRem1.Text = "Media Redila"
                    Case "CTR020"
                        LTSubTipoRem1.Text = "Pallet o Celdillas"
                    Case "CTR021"
                        LTSubTipoRem1.Text = "Plataforma"
                    Case "CTR022"
                        LTSubTipoRem1.Text = "Plataforma Con Grúa"
                    Case "CTR023"
                        LTSubTipoRem1.Text = "Plataforma Encortinada"
                    Case "CTR024"
                        LTSubTipoRem1.Text = "Redilas"
                    Case "CTR025"
                        LTSubTipoRem1.Text = "Refrigerador"
                    Case "CTR026"
                        LTSubTipoRem1.Text = "Revolvedora"
                    Case "CTR027"
                        LTSubTipoRem1.Text = "Semicaja"
                    Case "CTR028"
                        LTSubTipoRem1.Text = "Tanque"
                    Case "CTR029"
                        LTSubTipoRem1.Text = "Tolva"
                    Case "CTR030"
                        LTSubTipoRem1.Text = "Tractor"
                    Case "CTR031"
                        LTSubTipoRem1.Text = "Volteo"
                    Case "CTR032"
                        LTSubTipoRem1.Text = "Volteo Desmontable"
                    Case Else
                        MsgBox("Sub tipo 1 inexistente")
                        LTSubTipoRem1.Text = ""
                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("1450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TSubTipoRem2_Validated(sender As Object, e As EventArgs) Handles TSubTipoRem2.Validated
        Try
            If TSubTipoRem2.Text.Trim.Length > 0 Then
                Select Case TSubTipoRem2.Text
                    Case "CTR001"
                        LTSubTipoRem2.Text = "Caballete"
                    Case "CTR002"
                        LTSubTipoRem2.Text = "Caja"
                    Case "CTR003"
                        LTSubTipoRem2.Text = "Caja Abierta"
                    Case "CTR004"
                        LTSubTipoRem2.Text = "Caja Cerrada"
                    Case "CTR005"
                        LTSubTipoRem2.Text = "Caja De Recolección Con Cargador Frontal"
                    Case "CTR006"
                        LTSubTipoRem2.Text = "Caja Refrigerada"
                    Case "CTR007"
                        LTSubTipoRem2.Text = "Caja Seca"
                    Case "CTR008"
                        LTSubTipoRem2.Text = "Caja Transferencia"
                    Case "CTR009"
                        LTSubTipoRem2.Text = "Cama Baja o Cuello Ganso"
                    Case "CTR010"
                        LTSubTipoRem2.Text = "Chasis Portacontenedor"
                    Case "CTR011"
                        LTSubTipoRem2.Text = "Convencional De Chasis"
                    Case "CTR012"
                        LTSubTipoRem2.Text = "Equipo Especial"
                    Case "CTR013"
                        LTSubTipoRem2.Text = "Estacas"
                    Case "CTR014"
                        LTSubTipoRem2.Text = "Góndola Madrina"
                    Case "CTR015"
                        LTSubTipoRem2.Text = "Grúa Industrial"
                    Case "CTR016"
                        LTSubTipoRem1.Text = "Grúa "
                    Case "CTR017"
                        LTSubTipoRem2.Text = "Integral"
                    Case "CTR018"
                        LTSubTipoRem2.Text = "Jaula"
                    Case "CTR019"
                        LTSubTipoRem2.Text = "Media Redila"
                    Case "CTR020"
                        LTSubTipoRem2.Text = "Pallet o Celdillas"
                    Case "CTR021"
                        LTSubTipoRem2.Text = "Plataforma"
                    Case "CTR022"
                        LTSubTipoRem2.Text = "Plataforma Con Grúa"
                    Case "CTR023"
                        LTSubTipoRem2.Text = "Plataforma Encortinada"
                    Case "CTR024"
                        LTSubTipoRem2.Text = "Redilas"
                    Case "CTR025"
                        LTSubTipoRem2.Text = "Refrigerador"
                    Case "CTR026"
                        LTSubTipoRem2.Text = "Revolvedora"
                    Case "CTR027"
                        LTSubTipoRem2.Text = "Semicaja"
                    Case "CTR028"
                        LTSubTipoRem2.Text = "Tanque"
                    Case "CTR029"
                        LTSubTipoRem2.Text = "Tolva"
                    Case "CTR030"
                        LTSubTipoRem2.Text = "Tractor"
                    Case "CTR031"
                        LTSubTipoRem2.Text = "Volteo"
                    Case "CTR032"
                        LTSubTipoRem2.Text = "Volteo Desmontable"
                    Case Else
                        MsgBox("Sub tipo 1 inexistente")
                        LTSubTipoRem2.Text = ""
                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("1450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles TUnidadPeso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidadPeso_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TEmbalaje_KeyDown(sender As Object, e As KeyEventArgs) Handles TEmbalaje.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEmbalaje_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCveMaterialPeligroso_KeyDown(sender As Object, e As KeyEventArgs) Handles TCveMaterialPeligroso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCveMaterialPeligroso_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TBienesTransp_KeyDown(sender As Object, e As KeyEventArgs) Handles TBienesTransp.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBienesTransp_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TPermSCT_KeyDown(sender As Object, e As KeyEventArgs) Handles TPermSCT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPermSCT_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TConfigVehicular_KeyDown(sender As Object, e As KeyEventArgs) Handles TConfigVehicular.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnConfigVehicular_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TSubTipoRem1_KeyDown(sender As Object, e As KeyEventArgs) Handles TSubTipoRem1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnSubTipoRem1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TSubTipoRem2_KeyDown(sender As Object, e As KeyEventArgs) Handles TSubTipoRem2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnSubTipoRem2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TBienesTransp_Validated(sender As Object, e As EventArgs) Handles TBienesTransp.Validated
        Try
            If TBienesTransp.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM SAT_CLAVEPROD_SERVCP WHERE CLAVE_PROD = '" & TBienesTransp.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTBienesTransp.Text = dr("DESCR")
                            If LtMat_peligroso.Text = "No" Then
                                TPermSCT.Focus()
                            Else
                                TCveMaterialPeligroso.Focus()
                            End If
                        Else
                            MsgBox("Bienes transporte inexistente")
                            LTBienesTransp.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTBienesTransp.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TUnidadPeso2_KeyDown(sender As Object, e As KeyEventArgs) Handles TUnidadPeso2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidadPeso2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TUnidadPeso2_Validated(sender As Object, e As EventArgs) Handles TUnidadPeso2.Validated
        Try
            If TUnidadPeso2.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcclaveunidadpeso WHERE clave = '" & TUnidadPeso2.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTUnidadPeso2.Text = dr("nombre")
                            TBienesTransp2.Focus()
                        Else
                            MsgBox("Unidad de peso inexistente")
                            LTUnidadPeso2.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTUnidadPeso2.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBienesTransp2_KeyDown(sender As Object, e As KeyEventArgs) Handles TBienesTransp2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBienesTransp2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TBienesTransp2_Validated(sender As Object, e As EventArgs) Handles TBienesTransp2.Validated
        Try
            If TBienesTransp2.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM SAT_CLAVEPROD_SERVCP WHERE CLAVE_PROD = '" & TBienesTransp2.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTBienesTransp2.Text = dr("DESCR")
                            If LtMat_peligroso2.Text = "No" Then
                            Else
                                TCveMaterialPeligroso2.Focus()
                            End If
                        Else
                            MsgBox("Bienes transporte inexistente")
                            LTBienesTransp2.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTBienesTransp2.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCveMaterialPeligroso2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCveMaterialPeligroso2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCveMaterialPeligroso2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCveMaterialPeligroso2_Validated(sender As Object, e As EventArgs) Handles TCveMaterialPeligroso2.Validated
        Try
            If TCveMaterialPeligroso2.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcmaterialpeligroso WHERE clave = '" & TCveMaterialPeligroso2.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTCveMaterialPeligroso2.Text = dr("descripcion")
                            TEmbalaje2.Focus()
                        Else
                            MsgBox("Material peligroso inexistente")
                            LTCveMaterialPeligroso2.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTCveMaterialPeligroso2.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TEmbalaje2_KeyDown(sender As Object, e As KeyEventArgs) Handles TEmbalaje2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEmbalaje2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TEmbalaje2_Validated(sender As Object, e As EventArgs) Handles TEmbalaje2.Validated
        Try
            If TEmbalaje2.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblctipoembalaje WHERE clave = '" & TEmbalaje2.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTEmbalaje2.Text = dr("descripcion")
                        Else
                            MsgBox("Embalaje inexistente")
                            LTEmbalaje2.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTEmbalaje2.Text = ""
            End If
        Catch ex As Exception
            BITACORACFDI("1400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Label51_DoubleClick(sender As Object, e As EventArgs) Handles Label51.DoubleClick
        Dim FECHA As String
        Try
            Dim FECHA_CAR As String = FechaCarga.Value.ToString("yyyy-MM-dd HH:mm:ss")

            Dim F_CARGA As String = DateTime.ParseExact(FECHA_CAR, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("yyyyMMdd HH:mm:ss")

            'FECHA = F_CARGA
            FECHA = DateTime.Now.ToString("yyyyMMdd HH:mm:ss")
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
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
                    TCORREO1.Focus()
                    TCORREO1.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCORREO3_Leave(sender As Object, e As EventArgs) Handles TCORREO3.Leave
        Try
            If TCORREO3.Text.Trim.Length > 0 Then
                If validar_Mail(LCase(TCORREO3.Text)) = False Then
                    MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                        por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TCORREO1.Focus()
                    TCORREO1.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCORREO1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO1.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TCORREO2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO2.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TCORREO3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCORREO3.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnTimbrarDigiBox_CausesValidationChanged(sender As Object, e As EventArgs) Handles btnTimbrarDigiBox.CausesValidationChanged

    End Sub
End Class
