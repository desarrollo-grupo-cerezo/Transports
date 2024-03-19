Imports Stimulsoft
Imports Stimulsoft.Report
Imports System.Data.SqlClient
Imports System.IO
Module ModCFDI
    Private TIPO_CFDI As String 'FACTURAS ó CARTA PORTE TRASLADO"

    Sub IMPRIMIR_CFDI(FCVE_DOC As String, FTIPO_CFDI As String, Optional FNUM_FORM As Integer = 1)

        '                                 FACTURAS ó CARTA PORTE TRASLADO"

        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String = "", PDF As String = ""
        Dim CALLE_DESTINO As String, NUMEROEXTERIOR_DESTINO As String, COLONIA_DESTINO As String
        Dim LOCALIDAD_DESTINO As String, CODIGOPOSTAL_DESTINO As String, ESTADO_DESTINO As String, MUNICIPIO_DESTINO As String
        Dim ENVIAR_MAIL As String, CORREO_CLIENTE As String, EXISTE_CP As Boolean = False, EXISTE_CFDI As Boolean = False
        Dim ERROR_LOAD_PDF As Boolean = False

        TIPO_CFDI = FTIPO_CFDI ' FACTURAS ó CARTA PORTE TRASLADO"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        PassData6 = dr("CALLE") & ", Num. ext. " & dr("NUMEXT") & ", CP " & dr("CP")

                        If CP_IMPRIME_IMPORTES Then
                            'CON PRECIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = Desencriptar(dr("PASS_PFX").ToString)  'contrasena del certificado

                        CP_PERMSCT = dr.ReadNullAsEmptyString("PERMSCT")
                        CP_NUMPERMISOSCT = dr.ReadNullAsEmptyString("NUMPERMISOSCT")

                        CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                        CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            CVE_DOC = FCVE_DOC

            Select Case TIPO_CFDI
                Case "CARTA PORTE BUENO"
                    IMPRIMIR_CFDI_40(CVE_DOC, TIPO_CFDI) ' FACTURAS ó CARTA PORTE TRASLADO)
                Case "PAGO COMPLEMENTO"

                Case "FACTURA"
                    IMPRIMIR_CFDI_40(CVE_DOC, TIPO_CFDI) ' FACTURAS ó CARTA PORTE TRASLADO)

                Case "CARTA PORTE TRASLADO"
                    IMPRIMIR_CFDI_40(CVE_DOC, TIPO_CFDI) ' FACTURAS ó CARTA PORTE TRASLADO)
                Case "CARTA PORTE"
                    Try
                        SQL = "SELECT TDOC, DOCUMENT, DOCUMENT2, XML, FILE_XML FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    XML = dr("XML")
                                    CTA_PORT1 = dr("DOCUMENT")
                                    CTA_PORT2 = dr("DOCUMENT2")
                                    EXISTE_CFDI = True
                                Else
                                    XML = ""
                                    CTA_PORT1 = ""
                                    CTA_PORT2 = ""
                                    EXISTE_CFDI = False
                                End If
                            End Using
                        End Using
                        CP_ORDEN_DE = "" : CP_EMBARQUE = "" : CP_RECOGER_EN = "" : CP_ENTREGAR_EN = "" : CP_TRACTOR = "" : CP_TANQUE1 = ""
                        CP_TANQUE2 = "" : CP_PLACAS_TRACTOR = "" : CP_PLACAS_TANQUE1 = "" : CP_PLACAS_TANQUE2 = ""
                        CP_POLIZARESPCIVIL = "" : CP_ASEGURARESPCIVIL = "" : CP_NUM_PROV = "" : CP_PEDIMENTO = "" : CP_OBSER_CFDI = ""

                        If EXISTE_CFDI Then
                            If CTA_PORT1.Trim.Length > 0 Then
                                Try
                                    SQL = "SELECT C.CVE_DOCR, C.CLIENTE, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, 
                                CVE_DOCP, C.ORDEN_DE, C.EMBARQUE, ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1,
                                ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2,
                                ISNULL(U.ANO_MODELO,'') AS ANO_MOD, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL, C.CVE_ART, ISNULL(P.DESCR,'') AS DESCR_MAT, 
                                ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(PEDIMENTO,'') AS CP_PEDIMENTO, ISNULL(C.OBSER_CFDI,'') AS OBS_CFDI, 
                                R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN, SC.CALLE, SC.NUMEXT, SC.COLONIA, SC.LOCALIDAD, SC.MUNICIPIO, SC.CODIGO,
                                SC.ESTADO, ISNULL(SC.MAIL,'') AS ENVIAR_CORREO, ISNULL(SC.EMAILPRED,'') AS CORREO, ISNULL(TP.DESCR,'') AS DESCR_TIPO_OPE
                                FROM GCCARTA_PORTE C 
                                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = C.RECOGER_EN
                                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = C.ENTREGAR_EN
                                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = C.CVE_TRACTOR
                                LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = C.CVE_TANQUE1
                                LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = C.CVE_TANQUE2
                                LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                                LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = CAST(C.CVE_ART AS INT)
                                LEFT JOIN CLIE" & Empresa & " SC ON SC.CLAVE =  C.CLIENTE
                                LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE =  SC.CLAVE
                                LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = C.CVE_TIPO_OPE
                                WHERE CVE_FOLIO = '" & CTA_PORT1 & "'"
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        cmd.CommandText = SQL
                                        Using dr As SqlDataReader = cmd.ExecuteReader
                                            If dr.Read Then
                                                EXISTE_CP = True
                                                CP_ORDEN_DE = dr.ReadNullAsEmptyString("ORDEN_DE")
                                                CP_EMBARQUE = dr.ReadNullAsEmptyString("EMBARQUE")

                                                CP_RECOGER_EN = dr.ReadNullAsEmptyString("DESCR_RECOGER_EN")
                                                CP_ENTREGAR_EN = dr.ReadNullAsEmptyString("DESCR_ENTREGAR_EN")

                                                CP_TRACTOR = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                                                CP_TANQUE1 = dr.ReadNullAsEmptyString("CVE_TANQUE1")
                                                CP_TANQUE2 = dr.ReadNullAsEmptyString("CVE_TANQUE2")
                                                CP_PLACAS_TRACTOR = dr.ReadNullAsEmptyString("PLACAS_MEX_TRACTOR")
                                                CP_PLACAS_TANQUE1 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE1")
                                                CP_PLACAS_TANQUE2 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE2")

                                                CP_POLIZARESPCIVIL = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                                                CP_ASEGURARESPCIVIL = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                                                CP_NUM_PROV = dr.ReadNullAsEmptyString("LIB1")
                                                CP_PEDIMENTO = dr.ReadNullAsEmptyString("CP_PEDIMENTO")
                                                If CP_PEDIMENTO = "0" Then CP_PEDIMENTO = ""
                                                CP_OBSER_CFDI = dr.ReadNullAsEmptyString("OBS_CFDI")

                                                CALLE_DESTINO = dr.ReadNullAsEmptyString("CALLE")
                                                NUMEROEXTERIOR_DESTINO = dr.ReadNullAsEmptyString("NUMEXT")
                                                COLONIA_DESTINO = dr.ReadNullAsEmptyString("COLONIA")
                                                LOCALIDAD_DESTINO = dr.ReadNullAsEmptyString("LOCALIDAD")
                                                CODIGOPOSTAL_DESTINO = dr.ReadNullAsEmptyString("CODIGO")
                                                ESTADO_DESTINO = dr.ReadNullAsEmptyString("ESTADO")
                                                MUNICIPIO_DESTINO = dr.ReadNullAsEmptyString("MUNICIPIO")

                                                PassData7 = CALLE_DESTINO
                                                If NUMEROEXTERIOR_DESTINO.Trim.Length > 0 Then
                                                    PassData7 = PassData7 & ", Num. ext. " & NUMEROEXTERIOR_DESTINO
                                                End If
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

                                                ENVIAR_MAIL = dr("ENVIAR_CORREO")
                                                CORREO_CLIENTE = dr("CORREO")

                                                CP_CLIENTE = "(" & dr("CLIENTE").ToString.Trim & ")"
                                            Else
                                                CP_ORDEN_DE = "" : CP_EMBARQUE = "" : CP_RECOGER_EN = "" : CP_ENTREGAR_EN = "" : CP_TRACTOR = "" : CP_TANQUE1 = ""
                                                CP_TANQUE2 = "" : CP_PLACAS_TRACTOR = "" : CP_PLACAS_TANQUE1 = "" : CP_PLACAS_TANQUE2 = ""
                                                CP_POLIZARESPCIVIL = "" : CP_ASEGURARESPCIVIL = "" : CP_NUM_PROV = "" : CP_PEDIMENTO = "" : CP_OBSER_CFDI = ""
                                            End If
                                        End Using
                                    End Using
                                Catch ex As Exception
                                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                EXISTE_CP = False
                                'MsgBox("Carta porte no encontrada")
                            End If

                            If EXISTE_CP Then
                                Dim RUTA_DISCOC As String
                                'ESTA ES LA RUTA DE TEMPORALES
                                'RUTA_DISCOC = System.IO.Path.GetTempPath()
                                If CP_IMPRIME_IMPORTES Then
                                    'CON PRECIOS CARAJO
                                    RUTA_DISCOC = "C:\TRANS PDF\CON PRECIOS"
                                Else
                                    RUTA_DISCOC = "C:\TRANS PDF\SIN PRECIOS"
                                End If
                                Try
                                    If Not Directory.Exists(RUTA_DISCOC) Then
                                        Directory.CreateDirectory("C:\TRANS PDF")
                                        Directory.CreateDirectory(RUTA_DISCOC)
                                    End If
                                Catch ex As Exception
                                    RUTA_DISCOC = gRutaXML_TIMBRADO
                                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Dim rutaPDF As String = RUTA_DISCOC & "\" & CTA_PORT1 & "-" & CVE_DOC & ".pdf"
                                PDF = rutaPDF

                                FILE_XML = RUTA_DISCOC & "\" & CTA_PORT1 & "-" & CVE_DOC & ".xml"
                                File.WriteAllText(FILE_XML, XML)
                                '                                   String.Empty
                                CreaPDF.Generar(FILE_XML, rutaPDF, Application.StartupPath & "\logo.jpg", False)

                                FILE_PDF = rutaPDF 'ESTA ES LA VARIABLE PUBLICA QUE UTILIZA FrmPrintPDF para imprimir el pdf

                                '999 PARA QUE NO IMPRIMA NINGUNA CARTA PORTE CUANDO ES IMPRESION MASIVA

                                If FNUM_FORM <> 999 Then
                                    If FNUM_FORM = 1 Then
                                        FrmOPenPDFGrapecity.Show()
                                    Else
                                        FrmOpenPDFGrapecity2.Show()
                                    End If
                                End If
                            Else
                                ERROR_LOAD_PDF = False
                                MsgBox("Documento no encontrado")
                            End If
                        Else
                            ERROR_LOAD_PDF = False
                            MsgBox("Documento no encontrado")
                        End If
                    Catch ex As Exception
                        BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & FILE_XML & vbNewLine & "PDF:" & PDF)
                        ERROR_LOAD_PDF = True
                    End Try

                    If EXISTE_CP Then
                        If ERROR_LOAD_PDF Then
                            Process.Start(FILE_PDF)
                        End If
                    End If

            End Select

        Catch ex As Exception
            BITACORACFDI("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_CFDI_40(FCVE_DOC As String, FCFDI As String, Optional FCVE_VIAJE As String = "")
        Try
            Dim StiReport1 As New Report.StiReport
            Dim UUID As String
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""

            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            If FCFDI.Trim.Length = 0 Then
                FCFDI = ""
            End If

            Select Case FCFDI
                Case "FACTURA"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIFACTURA" & Empresa & ".mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIFACTURA.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If
                Case "CARTA PORTE TRASLADO"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT" & Empresa & ".mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If
                Case "CARTA PORTE BUENO"

                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40" & Empresa & ".mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If

                Case "NOTA DE CREDITO"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDINOTADECREDITO" & Empresa & ".mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDINOTADECREDITO.mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                            Return
                        End If
                    End If
                    'PassData1 = "CFDI Nota de crédito"
                    'IMPRIMIR_CFDI_40(FCVE_DOC, "NOTA DE CREDITO")
            End Select

            UUID = BUSCAR_UUID_CFDI40(FCVE_DOC)
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
                    StiReport1.Item("CVE_DOC_REL") = FCVE_DOC
                    StiReport1.Item("CVE_DOC") = FCVE_DOC
                    StiReport1.ReportName = "Complemento de pago 4.0"
                Case "FACTURA"
                    StiReport1("CVE_DOC") = FCVE_DOC
                    StiReport1.ReportName = "Factura 4.0"

                Case "CFDI Nota de crédito"
                    StiReport1("CVE_DOC") = FCVE_DOC
                    StiReport1.ReportName = "Nota de crédito"

                Case "CARTA PORTE TRASLADO"
                    StiReport1.Item("CVE_DOC_REL") = FCVE_DOC
                    StiReport1.Item("CVE_DOC") = FCVE_DOC
                    StiReport1.ReportName = "Carta porte traslado 4.0"
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

                    If CVE_MONED = "MXN" Then
                        NUMTOLET = "** ( " + Num2Text(entero) + " PESOS " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + "/100 M.N.)**"
                    Else
                        NUMTOLET = "** ( " + Num2Text(entero) + " USD " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + ")**"
                    End If


                    StiReport1("CVE_VIAJE") = FCVE_VIAJE
                    StiReport1("CVE_DOC") = FCVE_DOC
                    StiReport1("NUMTOLETRA") = NUMTOLET


                    StiReport1.ReportName = "Carta porte 4.0"
            End Select


            StiReport1.Render()

            VisualizaReporte(StiReport1)
            'StiReport1.Show()
        Catch ex As Exception
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine)
            MsgBox("No tiene derechos para reimprimir CFDI 4.0")
        End Try
    End Sub

    Public Sub IMPRIMIR_CFDI_DIRECTO(FCVE_DOC As String, Optional FPDF As String = "", Optional FCVE_VIAJE As String = "", Optional FRFC As String = "")
        Try
            Dim UUID As String, RUTA_PDF_PRECIOS As String = ""
            Dim Report As New StiReport, RUTA_PDF As String = ""

            Try
                Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""

                RUTA_FORMATOS = GET_RUTA_FORMATOS()

                Select Case PassData1
                    Case "PAGO COMPLEMENTO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\PAGO-" & FRFC & "-" & FCVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\PAGO-" & FRFC & "-" & FCVE_DOC & ".pdf"

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
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & FRFC & "-" & FCVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & FRFC & "-" & FCVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportFACTURA_DIRECTA" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportFACTURA_DIRECTA.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        UUID = BUSCAR_UUID_CFDI40(FCVE_DOC)
                    Case "CARTA PORTE TRASLADO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & FRFC & "-" & FCVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & FRFC & "-" & FCVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                    Case "CARTA PORTE BUENO"
                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & FCVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & FCVE_DOC & ".pdf"

                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                    Case "DEVOLUCION CFDI"

                        RUTA_PDF = gRutaXML_TIMBRADO & "\" & FRFC & "_" & FCVE_DOC & ".pdf"
                        RUTA_PDF_PRECIOS = gRutaXML_TIMBRADO_CON_PRECIOS & "\" & FRFC & "_" & FCVE_DOC & ".pdf"


                        ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDINOTADECREDITO" & Empresa & ".mrt"
                        If Not File.Exists(ARCHIVO_MRT) Then
                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDINOTADECREDITO.mrt"
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
                Report.Load(ARCHIVO_MRT)

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                Report.Dictionary.Databases.Clear()
                Report.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
                Report.Compile()

                Select Case PassData1
                    Case "PAGO COMPLEMENTO"
                        Report("CVE_DOC") = FCVE_DOC
                        Report.ReportName = "Complemento de pago 4.0"
                    Case "FACTURA"
                        Report.Item("CVE_DOC") = FCVE_DOC
                        Report.ReportName = "Factura CFDI 4.0"
                    Case "DEVOLUCION CFDI"
                        Report.Item("CVE_DOC") = FCVE_DOC
                        Report.ReportName = "Nota de crédito"
                    Case "CARTA PORTE TRASLADO"
                        Report.Item("CVE_DOC") = FCVE_DOC
                        Report.ReportName = "Carta porte traslado"
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


                        Report("CVE_VIAJE") = FCVE_VIAJE
                        Report("CVE_DOC") = FCVE_DOC
                        Report("NUMTOLETRA") = NUMTOLET
                        Report.ReportName = "Carta porte"
                End Select
                If PassData1 = "FACTURA" Then
                    Report.Item("CVE_DOC_REL") = FCVE_DOC
                End If
                Report.Render()

                If FPDF = "PDF" Then
                    Report.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                Else
                    Report.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                    Report.Show()
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

End Module
