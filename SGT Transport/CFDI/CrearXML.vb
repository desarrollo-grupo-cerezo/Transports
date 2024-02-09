
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates

Public NotInheritable Class GenerarXML
    Private Shared NAMESPACE_CFD As String = "http://www.sat.gob.mx/cfd/4"
    Private Shared NAMESPACE_COMERCIO_EXTERIOR As String = "http://www.sat.gob.mx/ComercioExterior11"
    Private Shared NAMESPACE_NOMINA As String = "http://www.sat.gob.mx/nomina12"
    Private Shared NAMESPACE_PAGOS As String = "http://www.sat.gob.mx/Pagos20"
    Private Shared NAMESPACE_CARTA_PORTE As String = "http://www.sat.gob.mx/CartaPorte20"
    Private Shared NAMESPACE_IMPUESTOLOCAL As String = "http://www.sat.gob.mx/implocal"
    Private Shared NAMESPACE_HINGRESOSHIDROCARBUROS As String = "http://www.sat.gob.mx/IngresosHidrocarburos10"
    Private Shared NAMESPACE_GASTOSHIDROCARBUROS As String = " http://www.sat.gob.mx/GastosHidrocarburos10"
    Private Shared SCHEMALOCATION_COMERCIOEXTERIOR As String = "http://www.sat.gob.mx/ComercioExterior11 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior11/ComercioExterior11.xsd"
    Private Shared SCHEMALOCATION_CFD As String = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd"
    Private Shared SCHEMALOCATION_CARTA_PORTE As String = "http://www.sat.gob.mx/CartaPorte20 http://www.sat.gob.mx/sitio_internet/cfd/CartaPorte/CartaPorte20.xsd"
    Private Shared SCHEMALOCATION_NOMINA As String = "http://www.sat.gob.mx/nomina12 http://www.sat.gob.mx/sitio_internet/cfd/nomina/nomina12.xsd"
    Private Shared SCHEMALOCATION_PAGOS As String = "http://www.sat.gob.mx/Pagos20 http://www.sat.gob.mx/sitio_internet/cfd/Pagos/Pagos20.xsd"
    Private Shared SCHEMALOCATION_INGRESOSHIDROCARBUROS As String = "http://www.sat.gob.mx/IngresosHidrocarburos10 http://www.sat.gob.mx/sitio_internet/cfd/ IngresosHidrocarburos10/ IngresosHidrocarburos.xsd"
    Private Shared SCHEMALOCATION_GASTOSHIDROCARBUROS As String = "http://www.sat.gob.mx/GastosHidrocarburos10 http://www.sat.gob.mx/sitio_internet/cfd/GastosHidrocarburos10/GastosHidrocarburos10.xsd"

    Public Shared Function ObtenerXML(ByVal c As Comprobante, ByVal rutaPFX As String, ByVal passwordPFX As String, ByVal rutaCertificado As String) As XmlDocument
        Dim documento As XmlDocument = New XmlDocument()
        Try
            documento.AppendChild(documento.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'"))

            documento.AppendChild(AgregarNodoComprobante(c, documento, documento.CreateElement("cfdi", "Comprobante", NAMESPACE_CFD), rutaPFX, passwordPFX, rutaCertificado))

            Dim elementos As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")

            DirectCast(elementos.Item(0), XmlElement).SetAttribute("Sello", ObtenerSelloPorCertificado(documento, rutaPFX, passwordPFX))

        Catch ex As Exception

            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Return documento
    End Function
    Public Shared Function ObtenerSelloPorCertificado(ByVal xml As XmlDocument, ByVal rutaArchivoClavePrivada As String, ByVal lPassword As String) As String

        Try
            Dim ClavePrivada As Byte() = File.ReadAllBytes(rutaArchivoClavePrivada)
            Dim bytesFirmados As Byte() = Nothing
            Dim bCadenaOriginal As Byte() = Nothing
            Dim CadenaOriginal As String = GetCadenaOriginal(xml.InnerXml)
            Dim lSecStr As System.Security.SecureString = New System.Security.SecureString()
            Dim sham As SHA256Managed = New SHA256Managed()
            lSecStr.Clear()

            For Each c As Char In lPassword.ToCharArray()
                lSecStr.AppendChar(c)
            Next

            Dim lrsa As RSACryptoServiceProvider = Opensslkey.DecodeEncryptedPrivateKeyInfo(ClavePrivada, lSecStr)

            bCadenaOriginal = Encoding.UTF8.GetBytes(CadenaOriginal)

            Try
                bytesFirmados = lrsa.SignData(Encoding.UTF8.GetBytes(CadenaOriginal), sham)
            Catch ex As NullReferenceException
                Throw New NullReferenceException("Clave privada incorrecta, revisa que la clave que escribes corresponde a los sellos digitales cargados")
            End Try

            Dim sellodigital As String = Convert.ToBase64String(bytesFirmados)

            Return sellodigital

        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return ""
        End Try

    End Function
    Public Shared Function GuardarXmlPorPFX(ByVal c As Comprobante, ByVal rutaPFX As String, ByVal passwordPFX As String, ByVal rutaCertificado As String) As XmlDocument
        Dim documento As XmlDocument = New XmlDocument()
        documento.AppendChild(documento.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'"))
        documento.AppendChild(AgregarNodoComprobante(c, documento, documento.CreateElement("cfdi", "Comprobante", NAMESPACE_CFD), rutaPFX, passwordPFX, rutaCertificado))
        Dim elementos As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
        DirectCast(elementos.Item(0), XmlElement).SetAttribute("Sello", ObtenerSelloPorPFX(documento, rutaPFX, passwordPFX))
        Return documento
    End Function
    'Public Shared Function ObtenerXML1(ByVal c As Comprobante, ByVal rutaArchivoClavePrivada As String, ByVal passwordPFX As String, ByVal rutaCertificado As String) As XmlDocument
    '    Dim documento As XmlDocument = New XmlDocument()
    '    documento.AppendChild(documento.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'"))
    '    documento.AppendChild(AgregarNodoComprobante(c, documento, documento.CreateElement("cfdi", "Comprobante", NAMESPACE_CFD), rutaArchivoClavePrivada, passwordPFX, rutaCertificado))
    '    Dim elementos As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
    '    DirectCast(elementos(0), XmlElement).SetAttribute("Sello", ObtenerSelloPorCertificado(documento, rutaArchivoClavePrivada, passwordPFX))
    '    Return documento
    'End Function
    Public Shared Sub GuardarXML(ByVal c As Comprobante, ByVal rutaXML As String, ByVal rutaPFX As String, ByVal passwordPFX As String, ByVal rutaCertificado As String)
        Dim documento As XmlDocument = New XmlDocument()
        documento.AppendChild(documento.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'"))
        documento.AppendChild(AgregarNodoComprobante(c, documento, documento.CreateElement("cfdi", "Comprobante", NAMESPACE_CFD), rutaPFX, passwordPFX, rutaCertificado))
        Dim elementos As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")

        DirectCast(elementos(0), XmlElement).SetAttribute("Sello", ObtenerSelloPorPFX(documento, rutaPFX, passwordPFX))

        documento.Save(rutaXML)
    End Sub
    Private Shared Function ObtenerSelloPorPFX(ByVal xml As XmlDocument, ByVal rutaPFX As String, ByVal passwordPFX As String) As String

        Try
            Dim privateCert As X509Certificate2 = New X509Certificate2(rutaPFX, passwordPFX, X509KeyStorageFlags.MachineKeySet)
            Dim privateKey As RSACryptoServiceProvider = CType(privateCert.PrivateKey, RSACryptoServiceProvider)
            Dim privateKey1 As RSACryptoServiceProvider = New System.Security.Cryptography.RSACryptoServiceProvider()
            privateKey1.ImportParameters(privateKey.ExportParameters(True))
            Dim bytesFirmados As Byte() = privateKey1.SignData(System.Text.Encoding.UTF8.GetBytes(GetCadenaOriginal(xml.InnerXml)), "SHA256")
            Return Convert.ToBase64String(bytesFirmados)
        Catch ex As Exception
            BITACORACFDI(ex.Message & vbNewLine & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & vbNewLine & ex.StackTrace & rutaPFX & " " & passwordPFX)
            Return ""
        End Try
    End Function

    'Public Shared Sub GuardarXML1(ByVal c As Comprobante, ByVal rutaXML As String, ByVal rutaPFX As String, ByVal passwordPFX As String, ByVal rutaCertificado As String)
    '    Dim documento As XmlDocument = New XmlDocument()
    '    documento.AppendChild(documento.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'"))
    '    documento.AppendChild(AgregarNodoComprobante(c, documento, documento.CreateElement("cfdi", "Comprobante", NAMESPACE_CFD), rutaPFX, passwordPFX, rutaCertificado))
    '    Dim elementos As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
    '    DirectCast(elementos(0), XmlElement).SetAttribute("Sello", ObtenerSelloPorPFX(documento, rutaPFX, passwordPFX))
    '    documento.Save(rutaXML)
    'End Sub

    Private Shared Function AgregarNodoComprobante(ByVal c As Comprobante, ByVal documento As XmlDocument, ByVal nComprobante As XmlElement, ByVal rutaPFX As String, ByVal passwordPFX As String, ByVal rutaCertificado As String) As XmlElement
        Dim nodoComprobante As XmlElement = nComprobante
        nodoComprobante.SetAttribute("Version", c.Version)
        If Not String.IsNullOrEmpty(c.Serie) Then nodoComprobante.SetAttribute("Serie", c.Serie)
        If Not String.IsNullOrEmpty(c.Folio) Then nodoComprobante.SetAttribute("Folio", c.Folio)
        nodoComprobante.SetAttribute("Fecha", c.Fecha.ToString("s"))
        nodoComprobante.SetAttribute("Sello", c.Sello)
        If Not String.IsNullOrEmpty(c.FormaPago) Then nodoComprobante.SetAttribute("FormaPago", c.FormaPago)
        Dim certificado As String = String.Empty
        Dim NoCertificado As String = String.Empty
        ObtenerCertificadoYNoCertificado(rutaCertificado, certificado, NoCertificado)
        nodoComprobante.SetAttribute("NoCertificado", NoCertificado)
        nodoComprobante.SetAttribute("Certificado", certificado)
        If Not String.IsNullOrEmpty(c.CondicionesDePago) Then nodoComprobante.SetAttribute("CondicionesDePago", c.CondicionesDePago)
        If c.Descuento > 0 Then nodoComprobante.SetAttribute("Descuento", c.Descuento.ToString("F2"))
        nodoComprobante.SetAttribute("Moneda", c.Moneda)
        If c.TipoCambio > 0 Then nodoComprobante.SetAttribute("TipoCambio", c.TipoCambio.ToString("F4"))

        If c.TipoDeComprobante = "P" Or c.TipoDeComprobante = "T" Then
            nodoComprobante.SetAttribute("SubTotal", "0")
            nodoComprobante.SetAttribute("Total", "0")
        Else
            nodoComprobante.SetAttribute("SubTotal", c.SubTotal.ToString("F2"))
            nodoComprobante.SetAttribute("Total", c.Total.ToString("F2"))
        End If

        nodoComprobante.SetAttribute("TipoDeComprobante", c.TipoDeComprobante)

        nodoComprobante.SetAttribute("Exportacion", c.Exportacion)

        If Not String.IsNullOrEmpty(c.MetodoPago) Then nodoComprobante.SetAttribute("MetodoPago", c.MetodoPago)
        nodoComprobante.SetAttribute("LugarExpedicion", c.LugarExpedicion)
        If Not String.IsNullOrEmpty(c.Confirmacion) Then nodoComprobante.SetAttribute("Confirmacion", c.Confirmacion)


        Dim schemaLocation As XmlAttribute = documento.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
        schemaLocation.Value = SCHEMALOCATION_CFD
        nodoComprobante.SetAttribute("xmlns:cfdi", NAMESPACE_CFD)

        If c.Complemento IsNot Nothing Then
            If c.Complemento.Nomina IsNot Nothing Then
                nodoComprobante.SetAttribute("xmlns:nomina12", NAMESPACE_NOMINA)
                schemaLocation.Value += " " & SCHEMALOCATION_NOMINA
            End If

            If c.Complemento.CartaPorte20 IsNot Nothing Then
                nodoComprobante.SetAttribute("xmlns:cartaporte20", NAMESPACE_CARTA_PORTE)
                schemaLocation.Value += " " & SCHEMALOCATION_CARTA_PORTE
            End If

            If c.Complemento.Pagos IsNot Nothing Then
                'CAMBIO AQUI xmlns:pagos POR xmlns:pago20 
                nodoComprobante.SetAttribute("xmlns:pago20", NAMESPACE_PAGOS)
                schemaLocation.Value += " " & SCHEMALOCATION_PAGOS
            End If

            If c.Complemento.ComercioExterior IsNot Nothing Then
                nodoComprobante.SetAttribute("xmlns:cce11", NAMESPACE_COMERCIO_EXTERIOR)
                schemaLocation.Value += " " & NAMESPACE_COMERCIO_EXTERIOR
            End If
        End If


        nodoComprobante.SetAttributeNode(schemaLocation)

        Try
            'ObtenerNodoCFDIRelacionados()
            If c.CfdiRelacionados IsNot Nothing Then
                If c.CfdiRelacionados.TipoRelacion IsNot Nothing Then
                    If c.CfdiRelacionados.TipoRelacion.ToString.Trim.Length > 0 Then
                        nodoComprobante.AppendChild(AgregarNodoCFDIRelacionados(c.CfdiRelacionados, documento))
                    End If
                End If
            End If

        Catch ex As Exception
            BITACORACFDI("410. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        nodoComprobante.AppendChild(AgregarNodoEmisor(c.Emisor, documento.CreateElement("cfdi", "Emisor", NAMESPACE_CFD)))
        nodoComprobante.AppendChild(AgregarNodoReceptor(c.Receptor, documento.CreateElement("cfdi", "Receptor", NAMESPACE_CFD)))

        'nodoComprobante.AppendChild(AgregarNodoCfdiRelacionados(c.CfdiRelacionados, documento))

        nodoComprobante.AppendChild(AgregarNodoConceptos(c.Conceptos, documento))

        Dim informacionGlobal As XmlElement = AgregarNodoInformacionGlobal(c.InformacionGlobal, documento)
        If informacionGlobal IsNot Nothing Then nodoComprobante.AppendChild(informacionGlobal)

        Dim impuestos As XmlElement = AgregarNodoImpuestos(c.Impuestos, documento)
        If impuestos IsNot Nothing Then nodoComprobante.AppendChild(impuestos)

        Dim complemento As XmlElement = AgregarNodoComplemento(c.Complemento, documento)
        If complemento IsNot Nothing Then nodoComprobante.AppendChild(complemento)

        Try
            If c.Addenda IsNot Nothing Then
                If c.Addenda.CodigoPostal IsNot Nothing Then
                    If c.Addenda.CodigoPostal.ToString.Trim.Length > 0 Then
                        Dim addenda As XmlElement = AgregarNodoAddenda(c.Addenda, documento)
                        If c.Addenda IsNot Nothing Then nodoComprobante.AppendChild(addenda)
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Return nodoComprobante
    End Function
    Private Shared Function AgregarNodoInformacionGlobal(ByVal informacionGlobal As InformacionGlobal, ByVal documento As XmlDocument) As XmlElement
        If informacionGlobal Is Nothing Then Return Nothing
        Dim nodoInformacionGlobal As XmlElement = documento.CreateElement("cfdi", "InformacionGlobal", NAMESPACE_CFD)
        If Not String.IsNullOrEmpty(informacionGlobal.Periodicidad) Then nodoInformacionGlobal.SetAttribute("Periodicidad", informacionGlobal.Periodicidad)
        If Not String.IsNullOrEmpty(informacionGlobal.Meses) Then nodoInformacionGlobal.SetAttribute("Meses", informacionGlobal.Meses)
        If informacionGlobal.Ano > 0 Then nodoInformacionGlobal.SetAttribute("Año", informacionGlobal.Ano.ToString())
        Return nodoInformacionGlobal
    End Function
    Private Shared Function AgregarNodoEmisor(ByVal emisor As Emisor, ByVal nEmisor As XmlElement) As XmlElement
        Dim nodoEmisor As XmlElement = nEmisor
        nodoEmisor.SetAttribute("Rfc", emisor.Rfc)
        nodoEmisor.SetAttribute("Nombre", emisor.Nombre)
        nodoEmisor.SetAttribute("RegimenFiscal", emisor.RegimenFiscal)
        If Not String.IsNullOrEmpty(emisor.FacAtrAdquirente) Then nodoEmisor.SetAttribute("FacAtrAdquirente", emisor.FacAtrAdquirente)
        Return nodoEmisor
    End Function
    Private Shared Function AgregarNodoReceptor(ByVal receptor As Receptor, ByVal nReceptor As XmlElement) As XmlElement
        Dim nodoReceptor As XmlElement = nReceptor
        nodoReceptor.SetAttribute("Rfc", receptor.Rfc)
        nodoReceptor.SetAttribute("Nombre", receptor.Nombre)
        nodoReceptor.SetAttribute("DomicilioFiscalReceptor", receptor.DomicilioFiscalReceptor)
        If Not String.IsNullOrEmpty(receptor.ResidenciaFiscal) Then nodoReceptor.SetAttribute("ResidenciaFiscal", receptor.ResidenciaFiscal)
        If Not String.IsNullOrEmpty(receptor.NumRegIdTrib) Then nodoReceptor.SetAttribute("NumRegIdTrib", receptor.NumRegIdTrib)
        nodoReceptor.SetAttribute("RegimenFiscalReceptor", receptor.RegimenFiscalReceptor)
        nodoReceptor.SetAttribute("UsoCFDI", receptor.UsoCFDI)
        Return nodoReceptor
    End Function

    Private Shared Function AgregarNodoCFDIRelacionados(ByVal CFDIRelacionados As CfdiRelacionados, ByVal documento As XmlDocument) As XmlElement
        If CFDIRelacionados Is Nothing Then Return Nothing
        Dim nodoCFDIRelacionados As XmlElement = documento.CreateElement("cfdi", "CfdiRelacionados", NAMESPACE_CFD)

        nodoCFDIRelacionados.SetAttribute("TipoRelacion", CFDIRelacionados.TipoRelacion)

        For Each CFDIRelacionado In CFDIRelacionados.CfdiRelacionado
            Dim nodoMercancia As XmlElement = AgregarAgregarnodoCFDIRelacionado(CFDIRelacionado, documento)
            If nodoMercancia IsNot Nothing Then nodoCFDIRelacionados.AppendChild(nodoMercancia)
        Next
        Return nodoCFDIRelacionados
    End Function

    Private Shared Function AgregarAgregarnodoCFDIRelacionado(ByVal CFDIRelacionado As CfdiRelacionado, ByVal documento As XmlDocument) As XmlElement
        If CFDIRelacionado Is Nothing Then Return Nothing
        Dim nodoCFDIRelacionado As XmlElement = documento.CreateElement("cfdi", "CfdiRelacionado", NAMESPACE_CFD)

        If Not String.IsNullOrEmpty(CFDIRelacionado.UUID) Then nodoCFDIRelacionado.SetAttribute("UUID", CFDIRelacionado.UUID)
        Return nodoCFDIRelacionado
    End Function



    Private Shared Function AgregarNodoConceptos(ByVal conceptos As Conceptos, ByVal documento As XmlDocument) As XmlElement
        If conceptos.Concepto.Count() = 0 Then Return Nothing
        Dim nodoConceptos As XmlElement = documento.CreateElement("cfdi", "Conceptos", NAMESPACE_CFD)

        For Each concepto As Concepto In conceptos.Concepto
            Dim nodoConcepto As XmlElement = documento.CreateElement("cfdi", "Concepto", NAMESPACE_CFD)

            nodoConcepto.SetAttribute("ClaveProdServ", concepto.ClaveProdServ)
            If Not String.IsNullOrEmpty(concepto.NoIdentificacion) Then nodoConcepto.SetAttribute("NoIdentificacion", concepto.NoIdentificacion)
            If (concepto.Cantidad = 1) Then nodoConcepto.SetAttribute("Cantidad", "1") Else nodoConcepto.SetAttribute("Cantidad", concepto.Cantidad.ToString("F2"))
            If (concepto.ValorUnitario = 0) Then nodoConcepto.SetAttribute("ValorUnitario", "0") Else nodoConcepto.SetAttribute("ValorUnitario", concepto.ValorUnitario.ToString("F2"))

            If (concepto.Importe = 0) Then nodoConcepto.SetAttribute("Importe", "0") Else nodoConcepto.SetAttribute("Importe", concepto.Importe.ToString("F2"))

            nodoConcepto.SetAttribute("ClaveUnidad", concepto.ClaveUnidad)
            If Not String.IsNullOrEmpty(concepto.Unidad) Then nodoConcepto.SetAttribute("Unidad", concepto.Unidad)
            nodoConcepto.SetAttribute("Descripcion", concepto.Descripcion)

            If concepto.Descuento > 0 Then nodoConcepto.SetAttribute("Descuento", concepto.Descuento.ToString("F2"))

            nodoConcepto.SetAttribute("ObjetoImp", concepto.ObjetoImp)

            Dim impuestos As XmlElement = ObtenerNodoImpuestosConcepto(concepto.Impuestos, documento)
            If impuestos IsNot Nothing Then nodoConcepto.AppendChild(impuestos)

            Dim aCuentaTerceros As XmlElement = ObtenerNodoACuentaTerceros(concepto.ACuentaTerceros, documento)
            If (aCuentaTerceros IsNot Nothing) Then nodoConcepto.AppendChild(aCuentaTerceros)

            For Each cp As CuentaPredialC In concepto.CuentaPredial
                Dim cuentaPredial As XmlElement = ObtenerNodoCuentaPredialC(cp, documento)
                If cuentaPredial IsNot Nothing Then nodoConcepto.AppendChild(cuentaPredial)
            Next
            For Each ia As InformacionAduaneraC In concepto.InformacionAduanera
                Dim informacionAduanera As XmlElement = ObtenerNodoInformacionAduaneraC(ia, documento)
                If informacionAduanera IsNot Nothing Then nodoConcepto.AppendChild(informacionAduanera)
            Next

            Dim parte As XmlElement = ObtenerNodoParteC(concepto.Parte, documento)
            If parte IsNot Nothing Then nodoConcepto.AppendChild(parte)
            nodoConceptos.AppendChild(nodoConcepto)
        Next

        Return nodoConceptos
    End Function
    Private Shared Function ObtenerNodoImpuestosConcepto(ByVal impuestos As ImpuestosC, ByVal documento As XmlDocument) As XmlElement

        'IMPUESTOS X PARTIDA

        If impuestos Is Nothing Then Return Nothing
        If impuestos.Retenciones.Count = 0 AndAlso impuestos.Traslados.Count = 0 Then Return Nothing
        Dim nodoImpuestos As XmlElement = documento.CreateElement("cfdi", "Impuestos", NAMESPACE_CFD)

        If impuestos.Traslados IsNot Nothing AndAlso impuestos.Traslados.Count > 0 Then
            Dim nodoTraslados As XmlElement = documento.CreateElement("cfdi", "Traslados", NAMESPACE_CFD)

            For Each traslado As TrasladoC In impuestos.Traslados
                Dim nodoTraslado As XmlElement = documento.CreateElement("cfdi", "Traslado", NAMESPACE_CFD)
                nodoTraslado.SetAttribute("Base", traslado.Base.ToString("F6"))
                nodoTraslado.SetAttribute("Impuesto", traslado.Impuesto)
                nodoTraslado.SetAttribute("TipoFactor", traslado.TipoFactor)

                If Not ISFAC_GLOBAL Then
                    nodoTraslado.SetAttribute("TasaOCuota", traslado.TasaOCuota.ToString("F6"))
                    nodoTraslado.SetAttribute("Importe", traslado.Importe.ToString("F2"))
                Else
                    nodoTraslado.SetAttribute("TasaOCuota", traslado.TasaOCuota.ToString("F6"))
                    nodoTraslado.SetAttribute("Importe", traslado.Importe.ToString("F6"))
                End If

                nodoTraslados.AppendChild(nodoTraslado)
            Next

            nodoImpuestos.AppendChild(nodoTraslados)
        End If

        If impuestos.Retenciones IsNot Nothing AndAlso impuestos.Retenciones.Count > 0 Then
            Dim nodoRetenciones As XmlElement = documento.CreateElement("cfdi", "Retenciones", NAMESPACE_CFD)

            For Each retencion As RetencionC In impuestos.Retenciones
                Dim nodoRetencion As XmlElement = documento.CreateElement("cfdi", "Retencion", NAMESPACE_CFD)
                nodoRetencion.SetAttribute("Base", retencion.Base.ToString("F6"))
                nodoRetencion.SetAttribute("Impuesto", retencion.Impuesto)
                nodoRetencion.SetAttribute("TipoFactor", retencion.TipoFactor)
                nodoRetencion.SetAttribute("TasaOCuota", retencion.TasaOCuota.ToString("F6"))
                nodoRetencion.SetAttribute("Importe", retencion.Importe.ToString("F2"))
                nodoRetenciones.AppendChild(nodoRetencion)
            Next

            nodoImpuestos.AppendChild(nodoRetenciones)
        End If

        Return nodoImpuestos
    End Function
    Private Shared Function ObtenerNodoACuentaTerceros(ByVal aCuentaTerceros As ACuentaTercerosC, ByVal documento As XmlDocument) As XmlElement
        If aCuentaTerceros Is Nothing Then Return Nothing
        Dim nodoACuentaTerceros As XmlElement = documento.CreateElement("cfdi", "ACuentaTerceros", NAMESPACE_CFD)
        If Not String.IsNullOrEmpty(aCuentaTerceros.DomicilioFiscalACuentaTerceros) Then nodoACuentaTerceros.SetAttribute("DomicilioFiscalACuentaTerceros", aCuentaTerceros.DomicilioFiscalACuentaTerceros)
        If Not String.IsNullOrEmpty(aCuentaTerceros.NombreACuentaTerceros) Then nodoACuentaTerceros.SetAttribute("NombreACuentaTerceros", aCuentaTerceros.NombreACuentaTerceros)
        If Not String.IsNullOrEmpty(aCuentaTerceros.RegimenFiscalACuentaTerceros) Then nodoACuentaTerceros.SetAttribute("RegimenFiscalACuentaTerceros", aCuentaTerceros.RegimenFiscalACuentaTerceros)
        If Not String.IsNullOrEmpty(aCuentaTerceros.RfcACuentaTerceros) Then nodoACuentaTerceros.SetAttribute("RfcACuentaTerceros", aCuentaTerceros.RfcACuentaTerceros)

        Return nodoACuentaTerceros
    End Function
    Private Shared Function ObtenerNodoInformacionAduaneraC(ByVal informacionAduanera As InformacionAduaneraC, ByVal documento As XmlDocument) As XmlElement
        If informacionAduanera Is Nothing Then Return Nothing
        Dim nodoInformacionAduanera As XmlElement = documento.CreateElement("cfdi", "InformacionAduanera", NAMESPACE_CFD)
        nodoInformacionAduanera.SetAttribute("NumeroPedimento", informacionAduanera.NumeroPedimento)
        nodoInformacionAduanera.AppendChild(nodoInformacionAduanera)
        Return nodoInformacionAduanera
    End Function
    Private Shared Function ObtenerNodoCuentaPredialC(ByVal cuentapredial As CuentaPredialC, ByVal documento As XmlDocument) As XmlElement
        If cuentapredial Is Nothing Then Return Nothing
        Dim nodoCuentaPredialC As XmlElement = documento.CreateElement("cfdi", "CuentaPredial", NAMESPACE_CFD)
        nodoCuentaPredialC.SetAttribute("Numero", cuentapredial.Numero)
        nodoCuentaPredialC.AppendChild(nodoCuentaPredialC)
        Return nodoCuentaPredialC
    End Function
    Private Shared Function ObtenerNodoParteC(ByVal parte As List(Of ParteC), ByVal documento As XmlDocument) As XmlElement
        If parte Is Nothing OrElse parte.Count() = 0 Then Return Nothing
        Dim nodoParte As XmlElement = documento.CreateElement("cfdi", "Parte", NAMESPACE_CFD)

        For Each p As ParteC In parte
            nodoParte.SetAttribute("ClaveProdServ", p.ClaveProdServ)
            If p.NoIdentificacion <> String.Empty Then nodoParte.SetAttribute("NoIdentificacion", p.NoIdentificacion)
            nodoParte.SetAttribute("Cantidad", p.Cantidad.ToString("F1"))
            If p.Unidad <> String.Empty Then nodoParte.SetAttribute("Unidad", p.Unidad)
            nodoParte.SetAttribute("Descripcion", p.Descripcion)
            nodoParte.SetAttribute("ValorUnitario", p.ValorUnitario.ToString("F2"))
            If p.Importe > 0 Then nodoParte.SetAttribute("Importe", p.Importe.ToString("F2"))
            For Each ia As InformacionAduaneraC In p.InformacionAduanera
                Dim informacionAduanera As XmlElement = ObtenerNodoInformacionAduaneraC(ia, documento)
                If informacionAduanera IsNot Nothing Then nodoParte.AppendChild(informacionAduanera)
            Next
        Next

        Return nodoParte
    End Function
    Private Shared Function AgregarNodoImpuestos(ByVal impuestos As Impuestos, ByVal documento As XmlDocument) As XmlElement


        If impuestos Is Nothing Then Return Nothing
        If impuestos.Retenciones.Count = 0 AndAlso impuestos.Traslados.Count = 0 Then Return Nothing
        Dim nodoImpuestos As XmlElement = documento.CreateElement("cfdi", "Impuestos", NAMESPACE_CFD)

        If impuestos.TotalImpuestosRetenidos > 0 Then nodoImpuestos.SetAttribute("TotalImpuestosRetenidos", impuestos.TotalImpuestosRetenidos.ToString("F2"))

        'If impuestos.TotalImpuestosTrasladados > 0 Then nodoImpuestos.SetAttribute("TotalImpuestosTrasladados", impuestos.TotalImpuestosTrasladados.ToString("F2"))
        nodoImpuestos.SetAttribute("TotalImpuestosTrasladados", impuestos.TotalImpuestosTrasladados.ToString("F2"))

        If impuestos.Retenciones IsNot Nothing AndAlso impuestos.Retenciones.Count > 0 Then
            Dim nodoRetenciones As XmlElement = documento.CreateElement("cfdi", "Retenciones", NAMESPACE_CFD)

            For Each retencion As Retencion In impuestos.Retenciones
                Dim nodoRetencion As XmlElement = documento.CreateElement("cfdi", "Retencion", NAMESPACE_CFD)
                nodoRetencion.SetAttribute("Impuesto", retencion.Impuesto)
                If Not ISFAC_GLOBAL Then
                    nodoRetencion.SetAttribute("Importe", retencion.Importe.ToString("F2"))
                Else
                    nodoRetencion.SetAttribute("Importe", retencion.Importe.ToString("F2"))
                End If
                nodoRetenciones.AppendChild(nodoRetencion)
            Next

            nodoImpuestos.AppendChild(nodoRetenciones)
        End If

        If impuestos.Traslados IsNot Nothing AndAlso impuestos.Traslados.Count > 0 Then
            Dim nodoTraslados As XmlElement = documento.CreateElement("cfdi", "Traslados", NAMESPACE_CFD)

            For Each traslado As Traslado In impuestos.Traslados
                Dim nodoTraslado As XmlElement = documento.CreateElement("cfdi", "Traslado", NAMESPACE_CFD)
                nodoTraslado.SetAttribute("Base", traslado.Base.ToString("F2"))
                nodoTraslado.SetAttribute("Impuesto", traslado.Impuesto)
                nodoTraslado.SetAttribute("TipoFactor", traslado.TipoFactor)

                If Not ISFAC_GLOBAL Then
                    nodoTraslado.SetAttribute("TasaOCuota", traslado.TasaOCuota.ToString("F6"))
                    nodoTraslado.SetAttribute("Importe", traslado.Importe.ToString("F2"))
                Else
                    nodoTraslado.SetAttribute("TasaOCuota", traslado.TasaOCuota.ToString("F6"))
                    nodoTraslado.SetAttribute("Importe", traslado.Importe.ToString("F2"))
                End If
                nodoTraslados.AppendChild(nodoTraslado)
            Next

            nodoImpuestos.AppendChild(nodoTraslados)
        End If

        Return nodoImpuestos
    End Function
    Private Shared Function AgregarNodoComplemento(ByVal complemento As Complemento, ByVal documento As XmlDocument) As XmlElement
        If complemento Is Nothing Then Return Nothing
        If complemento.Nomina Is Nothing AndAlso complemento.Pagos Is Nothing AndAlso complemento.TimbreFiscalDigital Is Nothing AndAlso complemento.CartaPorte20 Is Nothing Then Return Nothing
        Dim nodoComplemento As XmlElement = documento.CreateElement("cfdi", "Complemento", NAMESPACE_CFD)
        Dim nomina As XmlElement = AgregarNodoNominaComplemento(complemento.Nomina, documento)
        If nomina IsNot Nothing Then nodoComplemento.AppendChild(nomina)

        Dim pagos As XmlElement = AgregarNodoPagos(complemento.Pagos, documento)
        If pagos IsNot Nothing Then nodoComplemento.AppendChild(pagos)

        'Dim generaElement As CartaPorte20.GenerarElement
        Dim eCartaPorte20 As XmlElement = ObtenerNodoCartaPorte20(complemento.CartaPorte20, documento)
        If eCartaPorte20 IsNot Nothing Then nodoComplemento.AppendChild(eCartaPorte20)

        Dim nodoComercioExterior As XmlElement = ObtenerNodoComercioExterior(complemento.ComercioExterior, documento)
        If nodoComercioExterior IsNot Nothing Then nodoComplemento.AppendChild(nodoComercioExterior)

        Return nodoComplemento
    End Function
    Private Shared Function AgregarNodoAddenda(ByVal addenda As Addenda, ByVal documento As XmlDocument) As XmlElement
        If addenda Is Nothing Then Return Nothing
        Dim nodoAddenda As XmlElement = documento.CreateElement("cfdi", "Addenda", NAMESPACE_CFD)
        Dim nodoInnophos As XmlElement = documento.CreateElement("cfdi", "Innophos", NAMESPACE_CFD)
        If addenda.CodigoPostal <> String.Empty Then nodoInnophos.SetAttribute("Codigopostal", addenda.CodigoPostal)
        If addenda.Direccion <> String.Empty Then nodoInnophos.SetAttribute("Direccion", addenda.Direccion)
        nodoAddenda.AppendChild(nodoInnophos)
        Return nodoAddenda
    End Function
#Region "Complementos"
#Region "Comercio exterior 11"

    Public Shared Function ObtenerNodoComercioExterior(ByVal comercioExterior As ComercioExterior, ByVal documento As XmlDocument) As XmlElement
        If comercioExterior Is Nothing Then Return Nothing
        Dim nodoCartaPorte As XmlElement = documento.CreateElement("cce11", "ComercioExterior", NAMESPACE_COMERCIO_EXTERIOR)

        nodoCartaPorte.SetAttribute("Version", comercioExterior.Version)
        If Not String.IsNullOrEmpty(comercioExterior.MotivoTraslado) Then nodoCartaPorte.SetAttribute("MotivoTraslado", comercioExterior.MotivoTraslado)
        nodoCartaPorte.SetAttribute("TipoOperacion", comercioExterior.TipoOperacion)
        If Not String.IsNullOrEmpty(comercioExterior.ClaveDePedimento) Then nodoCartaPorte.SetAttribute("ClaveDePedimento", comercioExterior.ClaveDePedimento)
        nodoCartaPorte.SetAttribute("CertificadoOrigen", comercioExterior.CertificadoOrigen.ToString())
        If Not String.IsNullOrEmpty(comercioExterior.NumCertificadoOrigen) Then nodoCartaPorte.SetAttribute("NumCertificadoOrigen", comercioExterior.NumCertificadoOrigen)
        If Not String.IsNullOrEmpty(comercioExterior.NumeroExportadorConfiable) Then nodoCartaPorte.SetAttribute("NumeroExportadorConfiable", comercioExterior.NumeroExportadorConfiable)
        If Not String.IsNullOrEmpty(comercioExterior.Incoterm) Then nodoCartaPorte.SetAttribute("Incoterm", comercioExterior.Incoterm)
        nodoCartaPorte.SetAttribute("Subdivision", comercioExterior.Subdivision.ToString())
        If Not String.IsNullOrEmpty(comercioExterior.Observaciones) Then nodoCartaPorte.SetAttribute("Observaciones", comercioExterior.Observaciones)
        If Not String.IsNullOrEmpty(comercioExterior.TipoCambioUSD) Then nodoCartaPorte.SetAttribute("TipoCambioUSD", comercioExterior.TipoCambioUSD)
        nodoCartaPorte.SetAttribute("TotalUSD", comercioExterior.TotalUSD.ToString("F2"))
        Dim Emisor As XmlElement = CCE11AgregarNodoEmisor(comercioExterior.Emisor, documento)

        If Emisor IsNot Nothing Then nodoCartaPorte.AppendChild(Emisor)

        For Each propietario In comercioExterior.Propietario
            Dim nPropietario As XmlElement = CCE11AgregarNodoPropietario(propietario, documento)
            If nPropietario IsNot Nothing Then nodoCartaPorte.AppendChild(nPropietario)
        Next

        Dim Receptor As XmlElement = CCE11AgregarNodoReceptor(comercioExterior.Receptor, documento)
        If Receptor IsNot Nothing Then nodoCartaPorte.AppendChild(Receptor)

        For Each destinario In comercioExterior.Destinario
            Dim nDestinario As XmlElement = CCE11AgregarNodoDestinario(destinario, documento)
            If nDestinario IsNot Nothing Then nodoCartaPorte.AppendChild(nDestinario)
        Next

        Dim Mercancias As XmlElement = CCE11AgregarNodoMercancias(comercioExterior.Mercancias, documento)
        If Mercancias IsNot Nothing Then nodoCartaPorte.AppendChild(Mercancias)
        Return nodoCartaPorte
    End Function

    Private Shared Function CCE11AgregarNodoEmisor(ByVal emisor As CCE11Emisor, ByVal documento As XmlDocument) As XmlElement
        If emisor Is Nothing Then Return Nothing
        Dim nodoEmisor As XmlElement = documento.CreateElement("cce11", "Emisor", NAMESPACE_COMERCIO_EXTERIOR)
        If Not String.IsNullOrEmpty(emisor.Curp) Then nodoEmisor.SetAttribute("Curp", emisor.Curp)
        Dim Domicilio As XmlElement = CCE11AgregarNodoDomicilio(emisor.Domicilio, documento)
        If Domicilio IsNot Nothing Then nodoEmisor.AppendChild(Domicilio)
        Return nodoEmisor
    End Function

    Private Shared Function CCE11AgregarNodoDomicilio(ByVal domicilio As CCE11Domicilio, ByVal documento As XmlDocument) As XmlElement
        If domicilio Is Nothing Then Return Nothing
        Dim nodoDomicilio As XmlElement = documento.CreateElement("cce11", "Domicilio", NAMESPACE_COMERCIO_EXTERIOR)
        If Not String.IsNullOrEmpty(domicilio.Calle) Then nodoDomicilio.SetAttribute("Calle", domicilio.Calle)
        If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then nodoDomicilio.SetAttribute("NumeroExterior", domicilio.NumeroExterior)
        If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then nodoDomicilio.SetAttribute("NumeroInterior", domicilio.NumeroInterior)
        If Not String.IsNullOrEmpty(domicilio.Colonia) Then nodoDomicilio.SetAttribute("Colonia", domicilio.Colonia)
        If Not String.IsNullOrEmpty(domicilio.Localidad) Then nodoDomicilio.SetAttribute("Localidad", domicilio.Localidad)
        If Not String.IsNullOrEmpty(domicilio.Referencia) Then nodoDomicilio.SetAttribute("Referencia", domicilio.Referencia)
        If Not String.IsNullOrEmpty(domicilio.Municipio) Then nodoDomicilio.SetAttribute("Municipio", domicilio.Municipio)
        If Not String.IsNullOrEmpty(domicilio.Estado) Then nodoDomicilio.SetAttribute("Estado", domicilio.Estado)
        If Not String.IsNullOrEmpty(domicilio.Pais) Then nodoDomicilio.SetAttribute("Pais", domicilio.Pais)
        If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then nodoDomicilio.SetAttribute("CodigoPostal", domicilio.CodigoPostal)
        Return nodoDomicilio
    End Function

    Private Shared Function CCE11AgregarNodoPropietario(ByVal propietario As CCE11Propietario, ByVal documento As XmlDocument) As XmlElement
        If propietario Is Nothing Then Return Nothing
        Dim nodoPropietario As XmlElement = documento.CreateElement("cce11", "Propietario", NAMESPACE_COMERCIO_EXTERIOR)
        nodoPropietario.SetAttribute("NumRegIdTrib", propietario.NumRegIdTrib)
        nodoPropietario.SetAttribute("ResidenciaFiscal", propietario.ResidenciaFiscal)
        Return nodoPropietario
    End Function

    Private Shared Function CCE11AgregarNodoReceptor(ByVal receptor As CCE11Receptor, ByVal documento As XmlDocument) As XmlElement
        If receptor Is Nothing Then Return Nothing
        Dim nodoReceptor As XmlElement = documento.CreateElement("cce11", "Receptor", NAMESPACE_COMERCIO_EXTERIOR)
        Dim Domicilio As XmlElement = CCE11AgregarNodoDomicilio(receptor.Domicilio, documento)
        If Domicilio IsNot Nothing Then nodoReceptor.AppendChild(Domicilio)
        If Not String.IsNullOrEmpty(receptor.NumRegIdTrib) Then nodoReceptor.SetAttribute("NumRegIdTrib", receptor.NumRegIdTrib)
        Return nodoReceptor
    End Function

    Private Shared Function CCE11AgregarNodoDestinario(ByVal destinario As CCE11Destinario, ByVal documento As XmlDocument) As XmlElement
        If destinario Is Nothing Then Return Nothing
        Dim nodoDestinario As XmlElement = documento.CreateElement("cce11", "Destinatario", NAMESPACE_COMERCIO_EXTERIOR)
        Dim Domicilio As XmlElement = CCE11AgregarNodoDomicilio(destinario.Domicilio, documento)
        If Domicilio IsNot Nothing Then nodoDestinario.AppendChild(Domicilio)
        If Not String.IsNullOrEmpty(destinario.Nombre) Then nodoDestinario.SetAttribute("Nombre", destinario.Nombre)
        If Not String.IsNullOrEmpty(destinario.NumRegIdTrib) Then nodoDestinario.SetAttribute("NumRegIdTrib", destinario.NumRegIdTrib)

        Return nodoDestinario
    End Function

    Private Shared Function CCE11AgregarNodoMercancias(ByVal mercancias As CCE11Mercancias, ByVal documento As XmlDocument) As XmlElement
        If mercancias Is Nothing Then Return Nothing
        Dim nodoMercancias As XmlElement = documento.CreateElement("cce11", "Mercancias", NAMESPACE_COMERCIO_EXTERIOR)

        For Each mercancia In mercancias.Mercancia
            Dim nodoMercancia As XmlElement = CCE11AgregarNodoMercancia(mercancia, documento)
            If nodoMercancia IsNot Nothing Then nodoMercancias.AppendChild(nodoMercancia)
        Next

        Return nodoMercancias
    End Function

    Private Shared Function CCE11AgregarNodoMercancia(ByVal mercancia As CCE11Mercancia, ByVal documento As XmlDocument) As XmlElement
        If mercancia Is Nothing Then Return Nothing
        Dim nodoMercancia As XmlElement = documento.CreateElement("cce11", "Mercancia", NAMESPACE_COMERCIO_EXTERIOR)

        For Each descipcionesEspecificas In mercancia.DescripcionesEspecificas
            Dim nodoDescripcionesEspecificas As XmlElement = AgregarNodoDescripcionesEspecificas(descipcionesEspecificas, documento)
            If nodoMercancia IsNot Nothing Then nodoMercancia.AppendChild(nodoDescripcionesEspecificas)
        Next

        nodoMercancia.SetAttribute("NoIdentificacion", mercancia.NoIdentificacion)
        If Not String.IsNullOrEmpty(mercancia.FraccionArancelaria) Then nodoMercancia.SetAttribute("FraccionArancelaria", mercancia.FraccionArancelaria)
        nodoMercancia.SetAttribute("CantidadAduana", mercancia.CantidadAduana.ToString("F2"))
        If Not String.IsNullOrEmpty(mercancia.UnidadAduana) Then nodoMercancia.SetAttribute("UnidadAduana", mercancia.UnidadAduana)
        nodoMercancia.SetAttribute("ValorUnitarioAduana", mercancia.ValorUnitarioAduana.ToString("F2"))
        nodoMercancia.SetAttribute("ValorDolares", mercancia.ValorDolares.ToString("F2"))
        Return nodoMercancia
    End Function

    Private Shared Function AgregarNodoDescripcionesEspecificas(ByVal descripcionesEspecificas As CCE11DescripcionesEspecificas, ByVal documento As XmlDocument) As XmlElement
        If descripcionesEspecificas Is Nothing Then Return Nothing
        Dim nodoDescripcionesEspecificas As XmlElement = documento.CreateElement("cce11", "DescripcionesEspecificas", NAMESPACE_COMERCIO_EXTERIOR)
        nodoDescripcionesEspecificas.SetAttribute("Marca", descripcionesEspecificas.Marca)
        If Not String.IsNullOrEmpty(descripcionesEspecificas.Modelo) Then nodoDescripcionesEspecificas.SetAttribute("Modelo", descripcionesEspecificas.Modelo)
        If Not String.IsNullOrEmpty(descripcionesEspecificas.SubModelo) Then nodoDescripcionesEspecificas.SetAttribute("SubModelo", descripcionesEspecificas.SubModelo)
        If Not String.IsNullOrEmpty(descripcionesEspecificas.NumeroSerie) Then nodoDescripcionesEspecificas.SetAttribute("NumeroSerie", descripcionesEspecificas.NumeroSerie)
        Return nodoDescripcionesEspecificas
    End Function
#End Region
#Region "Carta porte 2.0"
    Public Shared Function ObtenerNodoCartaPorte20(ByVal cartaPorte As CartaPorte, ByVal documento As XmlDocument) As XmlElement
        If cartaPorte Is Nothing Then Return Nothing
        Dim nodoCartaPorte As XmlElement = documento.CreateElement("cartaporte20", "CartaPorte", NAMESPACE_CARTA_PORTE)
        nodoCartaPorte.SetAttribute("Version", cartaPorte.Version)
        nodoCartaPorte.SetAttribute("TranspInternac", cartaPorte.TranspInternac)
        If Not String.IsNullOrEmpty(cartaPorte.EntradaSalidaMerc) Then nodoCartaPorte.SetAttribute("EntradaSalidaMerc", cartaPorte.EntradaSalidaMerc)
        If Not String.IsNullOrEmpty(cartaPorte.PaisOrigenDestino) Then nodoCartaPorte.SetAttribute("PaisOrigenDestino", cartaPorte.PaisOrigenDestino)
        If Not String.IsNullOrEmpty(cartaPorte.ViaEntradaSalida) Then nodoCartaPorte.SetAttribute("ViaEntradaSalida", cartaPorte.ViaEntradaSalida)
        If cartaPorte.TotalDistRec > 0 Then nodoCartaPorte.SetAttribute("TotalDistRec", cartaPorte.TotalDistRec.ToString("f2"))
        Dim ubicaciones As XmlElement = CP20AgregarNodoUbicaciones(cartaPorte.Ubicaciones, documento)
        If ubicaciones IsNot Nothing Then nodoCartaPorte.AppendChild(ubicaciones)
        Dim mercancias As XmlElement = CP20AgregarNodoMercancias(cartaPorte.Mercancias, documento)
        If mercancias IsNot Nothing Then nodoCartaPorte.AppendChild(mercancias)
        Dim figuraTransporte As XmlElement = CP20AgregarNodoFiguraTransporte(cartaPorte.FiguraTransporte, documento)
        If figuraTransporte IsNot Nothing Then nodoCartaPorte.AppendChild(figuraTransporte)
        Return nodoCartaPorte
    End Function

    Private Shared Function CP20AgregarNodoUbicaciones(ByVal ubicaciones As Ubicaciones, ByVal documento As XmlDocument) As XmlElement
        If ubicaciones Is Nothing Then Return Nothing
        Dim nodoUbicaciones As XmlElement = documento.CreateElement("cartaporte20", "Ubicaciones", NAMESPACE_CARTA_PORTE)

        For Each ubicacion As Ubicacion In ubicaciones.Ubicacion
            Dim nodoUbicacion As XmlElement = documento.CreateElement("cartaporte20", "Ubicacion", NAMESPACE_CARTA_PORTE)
            Dim nodoDomicilio As XmlElement = CP20AgregarNodoDomicilio(ubicacion.Domicilio, documento)
            If nodoDomicilio IsNot Nothing Then nodoUbicacion.AppendChild(nodoDomicilio)
            nodoUbicacion.SetAttribute("TipoUbicacion", ubicacion.TipoUbicacion)
            If Not String.IsNullOrEmpty(ubicacion.IDUbicacion) Then nodoUbicacion.SetAttribute("IDUbicacion", ubicacion.IDUbicacion)
            nodoUbicacion.SetAttribute("RFCRemitenteDestinatario", ubicacion.RFCRemitenteDestinatario)
            If Not String.IsNullOrEmpty(ubicacion.NombreRemitenteDestinatario) Then nodoUbicacion.SetAttribute("NombreRemitenteDestinatario", ubicacion.NombreRemitenteDestinatario)
            If Not String.IsNullOrEmpty(ubicacion.NumRegIdTrib) Then nodoUbicacion.SetAttribute("NumRegIdTrib", ubicacion.NumRegIdTrib)
            If Not String.IsNullOrEmpty(ubicacion.ResidenciaFiscal) Then nodoUbicacion.SetAttribute("ResidenciaFiscal", ubicacion.ResidenciaFiscal)
            If Not String.IsNullOrEmpty(ubicacion.NumEstacion) Then nodoUbicacion.SetAttribute("NumEstacion", ubicacion.NumEstacion)
            If Not String.IsNullOrEmpty(ubicacion.NombreEstacion) Then nodoUbicacion.SetAttribute("NombreEstacion", ubicacion.NombreEstacion)
            If Not String.IsNullOrEmpty(ubicacion.NavegacionTrafico) Then nodoUbicacion.SetAttribute("NavegacionTrafico", ubicacion.NavegacionTrafico)
            nodoUbicacion.SetAttribute("FechaHoraSalidaLlegada", ubicacion.FechaHoraSalidaLlegada.ToString("s"))
            If Not String.IsNullOrEmpty(ubicacion.TipoEstacion) Then nodoUbicacion.SetAttribute("TipoEstacion", ubicacion.TipoEstacion)
            If ubicacion.DistanciaRecorrida > 0 Then nodoUbicacion.SetAttribute("DistanciaRecorrida", ubicacion.DistanciaRecorrida.ToString())
            nodoUbicaciones.AppendChild(nodoUbicacion)
        Next

        Return nodoUbicaciones
    End Function

    Private Shared Function CP20AgregarNodoDomicilio(ByVal domicilio As Domicilio, ByVal documento As XmlDocument) As XmlElement
        If domicilio Is Nothing Then Return Nothing
        Dim nodoDomicilio As XmlElement = documento.CreateElement("cartaporte20", "Domicilio", NAMESPACE_CARTA_PORTE)
        If Not String.IsNullOrEmpty(domicilio.Calle) Then nodoDomicilio.SetAttribute("Calle", domicilio.Calle)
        If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then nodoDomicilio.SetAttribute("NumeroExterior", domicilio.NumeroExterior)
        If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then nodoDomicilio.SetAttribute("NumeroInterior", domicilio.NumeroInterior)
        If Not String.IsNullOrEmpty(domicilio.Colonia) Then nodoDomicilio.SetAttribute("Colonia", domicilio.Colonia)
        If Not String.IsNullOrEmpty(domicilio.Localidad) Then nodoDomicilio.SetAttribute("Localidad", domicilio.Localidad)
        If Not String.IsNullOrEmpty(domicilio.Referencia) Then nodoDomicilio.SetAttribute("Referencia", domicilio.Referencia)
        If Not String.IsNullOrEmpty(domicilio.Municipio) Then nodoDomicilio.SetAttribute("Municipio", domicilio.Municipio)
        If Not String.IsNullOrEmpty(domicilio.Estado) Then nodoDomicilio.SetAttribute("Estado", domicilio.Estado)
        If Not String.IsNullOrEmpty(domicilio.Pais) Then nodoDomicilio.SetAttribute("Pais", domicilio.Pais)
        If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then nodoDomicilio.SetAttribute("CodigoPostal", domicilio.CodigoPostal)
        Return nodoDomicilio
    End Function

    Private Shared Function CP20AgregarNodoMercancias(ByVal mercancias As Mercancias, ByVal documento As XmlDocument) As XmlElement
        If mercancias Is Nothing Then Return Nothing
        Dim nodoMercancias As XmlElement = documento.CreateElement("cartaporte20", "Mercancias", NAMESPACE_CARTA_PORTE)

        For Each mercancia In mercancias.Mercancia
            Dim nodoMercancia As XmlElement = CP20AgregarNodoMercancia(mercancia, documento)
            If nodoMercancia IsNot Nothing Then nodoMercancias.AppendChild(nodoMercancia)
        Next

        Dim nodoAutotransporte As XmlElement = CP20AgregarNodoAutotransporte(mercancias.Autotransporte, documento)
        Dim nodoTransporteMaritimo As XmlElement = CP20AgregarNodoTransporteMaritimo(mercancias.TransporteMaritimo, documento)
        Dim nodoTransporteAereo As XmlElement = CP20AgregarNodoTransporteAereo(mercancias.TransporteAereo, documento)
        Dim nodoTransporteFerroviario As XmlElement = CP20AgregarNodoTransporteFerroviario(mercancias.TransporteFerroviario, documento)
        If nodoAutotransporte IsNot Nothing Then nodoMercancias.AppendChild(nodoAutotransporte)
        If nodoTransporteMaritimo IsNot Nothing Then nodoMercancias.AppendChild(nodoTransporteMaritimo)
        If nodoTransporteAereo IsNot Nothing Then nodoMercancias.AppendChild(nodoTransporteAereo)
        If nodoTransporteFerroviario IsNot Nothing Then nodoMercancias.AppendChild(nodoTransporteFerroviario)
        nodoMercancias.SetAttribute("PesoBrutoTotal", mercancias.PesoBrutoTotal.ToString("F2"))
        nodoMercancias.SetAttribute("UnidadPeso", mercancias.UnidadPeso)
        If mercancias.PesoNetoTotal > 0 Then nodoMercancias.SetAttribute("PesoNetoTotal", mercancias.PesoNetoTotal.ToString("F2"))
        If mercancias.NumTotalMercancias > 0 Then nodoMercancias.SetAttribute("NumTotalMercancias", mercancias.NumTotalMercancias.ToString())
        If mercancias.CargoPorTasacion > 0 Then nodoMercancias.SetAttribute("CargoPorTasacion", mercancias.CargoPorTasacion.ToString("F2"))
        Return nodoMercancias
    End Function

    Private Shared Function CP20AgregarNodoMercancia(ByVal mercancia As Mercancia, ByVal documento As XmlDocument) As XmlElement
        If mercancia Is Nothing Then Return Nothing
        Dim nodoMercancia As XmlElement = documento.CreateElement("cartaporte20", "Mercancia", NAMESPACE_CARTA_PORTE)

        For Each pedimento In mercancia.Pedimentos
            Dim nodoPedimentos As XmlElement = CP20AgregarNodoPedimentos(pedimento, documento)
            If nodoPedimentos IsNot Nothing Then nodoMercancia.AppendChild(nodoPedimentos)
        Next

        For Each guiasIdentificacion In mercancia.GuiasIdentificacion
            Dim nodoGuiasIdentificacion As XmlElement = CP20AgregarNodoGuiasIdentificacion(guiasIdentificacion, documento)
            If nodoGuiasIdentificacion IsNot Nothing Then nodoMercancia.AppendChild(nodoGuiasIdentificacion)
        Next

        For Each cantidadTransporta In mercancia.CantidadTransporta
            Dim nodoCantidadTransporta As XmlElement = CP20AgregarNodoCantidadTransporta(cantidadTransporta, documento)
            If nodoCantidadTransporta IsNot Nothing Then nodoMercancia.AppendChild(nodoCantidadTransporta)
        Next

        Dim nodoDetalleMercancia As XmlElement = CP20AgregarNodoDetalleMercancia(mercancia.DetalleMercancia, documento)
        nodoMercancia.SetAttribute("BienesTransp", mercancia.BienesTransp)
        If Not String.IsNullOrEmpty(mercancia.ClaveSTCC) Then nodoMercancia.SetAttribute("ClaveSTCC", mercancia.ClaveSTCC)
        If Not String.IsNullOrEmpty(mercancia.Descripcion) Then nodoMercancia.SetAttribute("Descripcion", mercancia.Descripcion)
        If mercancia.Cantidad > 0 Then nodoMercancia.SetAttribute("Cantidad", mercancia.Cantidad.ToString("F2"))
        If Not String.IsNullOrEmpty(mercancia.ClaveUnidad) Then nodoMercancia.SetAttribute("ClaveUnidad", mercancia.ClaveUnidad)
        If Not String.IsNullOrEmpty(mercancia.Unidad) Then nodoMercancia.SetAttribute("Unidad", mercancia.Unidad)
        If Not String.IsNullOrEmpty(mercancia.Dimensiones) Then nodoMercancia.SetAttribute("Dimensiones", mercancia.Dimensiones)
        If Not String.IsNullOrEmpty(mercancia.MaterialPeligroso) Then nodoMercancia.SetAttribute("MaterialPeligroso", mercancia.MaterialPeligroso)
        If Not String.IsNullOrEmpty(mercancia.CveMaterialPeligroso) Then nodoMercancia.SetAttribute("CveMaterialPeligroso", mercancia.CveMaterialPeligroso)
        If Not String.IsNullOrEmpty(mercancia.Embalaje) Then nodoMercancia.SetAttribute("Embalaje", mercancia.Embalaje)
        If Not String.IsNullOrEmpty(mercancia.DescripEmbalaje) Then nodoMercancia.SetAttribute("DescripEmbalaje", mercancia.DescripEmbalaje)
        If mercancia.PesoEnKg > 0 Then nodoMercancia.SetAttribute("PesoEnKg", mercancia.PesoEnKg.ToString("F3"))
        If mercancia.ValorMercancia > 0 Then nodoMercancia.SetAttribute("ValorMercancia", mercancia.ValorMercancia.ToString("F2"))
        If Not String.IsNullOrEmpty(mercancia.Moneda) Then nodoMercancia.SetAttribute("Moneda", mercancia.Moneda)
        If Not String.IsNullOrEmpty(mercancia.FraccionArancelaria) Then nodoMercancia.SetAttribute("FraccionArancelaria", mercancia.FraccionArancelaria)
        If Not String.IsNullOrEmpty(mercancia.UUIDComercioExt) Then nodoMercancia.SetAttribute("UUIDComercioExt", mercancia.UUIDComercioExt)
        Return nodoMercancia
    End Function

    Private Shared Function CP20AgregarNodoPedimentos(ByVal pedimentos As Pedimentos, ByVal documento As XmlDocument) As XmlElement
        If pedimentos Is Nothing Then Return Nothing
        Dim nodoPedimentos As XmlElement = documento.CreateElement("cartaporte20", "Pedimentos", NAMESPACE_CARTA_PORTE)
        nodoPedimentos.SetAttribute("Pedimento", pedimentos.Pedimento)
        Return nodoPedimentos
    End Function

    Private Shared Function CP20AgregarNodoGuiasIdentificacion(ByVal guiasIdentificacion As GuiasIdentificacion, ByVal documento As XmlDocument) As XmlElement
        If guiasIdentificacion Is Nothing Then Return Nothing
        Dim nodoGuiasIdentificacion As XmlElement = documento.CreateElement("cartaporte", "GuiasIdentificacion", NAMESPACE_CARTA_PORTE)
        nodoGuiasIdentificacion.SetAttribute("NumeroGuiaIdentificacion", guiasIdentificacion.NumeroGuiaIdentificacion)
        nodoGuiasIdentificacion.SetAttribute("DescripGuiaIdentificacion", guiasIdentificacion.DescripGuiaIdentificacion)
        nodoGuiasIdentificacion.SetAttribute("PesoGuiaIdentificacion", guiasIdentificacion.PesoGuiaIdentificacion.ToString("F3"))
        Return nodoGuiasIdentificacion
    End Function

    Private Shared Function CP20AgregarNodoCantidadTransporta(ByVal cantidadTransporta As CantidadTransporta, ByVal documento As XmlDocument) As XmlElement
        If cantidadTransporta Is Nothing Then Return Nothing
        Dim nodocantidadTransporta As XmlElement = documento.CreateElement("cartaporte20", "CantidadTransporta", NAMESPACE_CARTA_PORTE)
        If cantidadTransporta.Cantidad > 0 Then nodocantidadTransporta.SetAttribute("Cantidad", cantidadTransporta.Cantidad.ToString("F6"))
        If Not String.IsNullOrEmpty(cantidadTransporta.IDOrigen) Then nodocantidadTransporta.SetAttribute("IDOrigen", cantidadTransporta.IDOrigen)
        If Not String.IsNullOrEmpty(cantidadTransporta.IDDestino) Then nodocantidadTransporta.SetAttribute("IDDestino", cantidadTransporta.IDDestino)
        Return nodocantidadTransporta
    End Function

    Private Shared Function CP20AgregarNodoDetalleMercancia(ByVal detalleMercancia As DetalleMercancia, ByVal documento As XmlDocument) As XmlElement
        If detalleMercancia Is Nothing Then Return Nothing
        Dim nodoDetalleMercancia As XmlElement = documento.CreateElement("cartaporte20", "DetalleMercancia", NAMESPACE_CARTA_PORTE)
        nodoDetalleMercancia.SetAttribute("UnidadPesoMerc", detalleMercancia.UnidadPesoMerc)
        nodoDetalleMercancia.SetAttribute("PesoBruto", detalleMercancia.PesoBruto.ToString("F3"))
        nodoDetalleMercancia.SetAttribute("PesoNeto", detalleMercancia.PesoNeto.ToString("F3"))
        nodoDetalleMercancia.SetAttribute("PesoTara", detalleMercancia.PesoNeto.ToString("F3"))
        If detalleMercancia.NumPiezas > 0 Then nodoDetalleMercancia.SetAttribute("NumPiezas", detalleMercancia.NumPiezas.ToString())
        Return nodoDetalleMercancia
    End Function

    Private Shared Function CP20AgregarNodoAutotransporte(ByVal autotransporte As Autotransporte, ByVal documento As XmlDocument) As XmlElement
        If autotransporte Is Nothing Then Return Nothing
        Dim nodoAutoTranporte As XmlElement = documento.CreateElement("cartaporte20", "Autotransporte", NAMESPACE_CARTA_PORTE)
        Dim nodoIdentificacionVehicular As XmlElement = CP20AgregarNodoIdentificacionVehicular(autotransporte.IdentificacionVehicular, documento)
        Dim nodoSeguros As XmlElement = CP20AgregarNodoSeguros(autotransporte.Seguros, documento)
        Dim nodoRemolques As XmlElement = CP20AgregarNodoRemolques(autotransporte.Remolques, documento)
        If nodoIdentificacionVehicular IsNot Nothing Then nodoAutoTranporte.AppendChild(nodoIdentificacionVehicular)
        If nodoSeguros IsNot Nothing Then nodoAutoTranporte.AppendChild(nodoSeguros)
        If nodoRemolques IsNot Nothing Then nodoAutoTranporte.AppendChild(nodoRemolques)
        nodoAutoTranporte.SetAttribute("PermSCT", autotransporte.PermSCT)
        nodoAutoTranporte.SetAttribute("NumPermisoSCT", autotransporte.NumPermisoSCT)
        Return nodoAutoTranporte
    End Function

    Private Shared Function CP20AgregarNodoIdentificacionVehicular(ByVal identificacionVehicular As IdentificacionVehicular, ByVal documento As XmlDocument) As XmlElement
        If identificacionVehicular Is Nothing Then Return Nothing
        Dim nodoIdentificacionVehicular As XmlElement = documento.CreateElement("cartaporte20", "IdentificacionVehicular", NAMESPACE_CARTA_PORTE)
        nodoIdentificacionVehicular.SetAttribute("ConfigVehicular", identificacionVehicular.ConfigVehicular)
        nodoIdentificacionVehicular.SetAttribute("PlacaVM", identificacionVehicular.PlacaVM)
        nodoIdentificacionVehicular.SetAttribute("AnioModeloVM", identificacionVehicular.AnioModeloVM.ToString())
        Return nodoIdentificacionVehicular
    End Function

    Private Shared Function CP20AgregarNodoSeguros(ByVal seguros As Seguros, ByVal documento As XmlDocument) As XmlElement
        If seguros Is Nothing Then Return Nothing
        Dim nodoSeguros As XmlElement = documento.CreateElement("cartaporte20", "Seguros", NAMESPACE_CARTA_PORTE)
        nodoSeguros.SetAttribute("AseguraRespCivil", seguros.AseguraRespCivil)
        nodoSeguros.SetAttribute("PolizaRespCivil", seguros.PolizaRespCivil)
        If Not String.IsNullOrEmpty(seguros.AseguraMedAmbiente) Then nodoSeguros.SetAttribute("AseguraMedAmbiente", seguros.AseguraMedAmbiente)
        If Not String.IsNullOrEmpty(seguros.PolizaMedAmbiente) Then nodoSeguros.SetAttribute("PolizaMedAmbiente", seguros.PolizaMedAmbiente)
        If Not String.IsNullOrEmpty(seguros.AseguraCarga) Then nodoSeguros.SetAttribute("AseguraCarga", seguros.AseguraCarga)
        If Not String.IsNullOrEmpty(seguros.PolizaCarga) Then nodoSeguros.SetAttribute("PolizaCarga", seguros.PolizaCarga)
        If seguros.PrimaSeguro > 0 Then nodoSeguros.SetAttribute("PrimaSeguro", seguros.PrimaSeguro.ToString("F2"))
        Return nodoSeguros
    End Function

    Private Shared Function CP20AgregarNodoRemolques(ByVal remolques As Remolques, ByVal documento As XmlDocument) As XmlElement
        If remolques Is Nothing Then Return Nothing
        Dim nodoRemolques As XmlElement = documento.CreateElement("cartaporte20", "Remolques", NAMESPACE_CARTA_PORTE)

        For Each remolque In remolques.Remolque
            Dim nodoRemolque As XmlElement = CP20AgregarNodoRemolque(remolque, documento)
            If nodoRemolque IsNot Nothing Then nodoRemolques.AppendChild(nodoRemolque)
        Next

        Return nodoRemolques
    End Function

    Private Shared Function CP20AgregarNodoRemolque(ByVal remolque As Remolque, ByVal documento As XmlDocument) As XmlElement
        If remolque Is Nothing Then Return Nothing
        Dim nodoRemolque As XmlElement = documento.CreateElement("cartaporte20", "Remolque", NAMESPACE_CARTA_PORTE)
        nodoRemolque.SetAttribute("SubTipoRem", remolque.SubTipoRem)
        nodoRemolque.SetAttribute("Placa", remolque.Placa)
        Return nodoRemolque
    End Function

    Private Shared Function CP20AgregarNodoTransporteMaritimo(ByVal transporteMaritimo As TransporteMaritimo, ByVal documento As XmlDocument) As XmlElement
        If transporteMaritimo Is Nothing Then Return Nothing
        Dim nodoTransporteMaritimo As XmlElement = documento.CreateElement("cartaporte20", "TransporteMaritimo", NAMESPACE_CARTA_PORTE)

        For Each contenedor In transporteMaritimo.Contenedor
            Dim nodoContenedor As XmlElement = CP20AgregarNodoContenedor(contenedor, documento)
            If nodoContenedor IsNot Nothing Then nodoContenedor.AppendChild(nodoContenedor)
        Next

        If Not String.IsNullOrEmpty(transporteMaritimo.PermSCT) Then nodoTransporteMaritimo.SetAttribute("PermSCT", transporteMaritimo.PermSCT)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumPermisoSCT) Then nodoTransporteMaritimo.SetAttribute("NumPermisoSCT", transporteMaritimo.NumPermisoSCT)
        If Not String.IsNullOrEmpty(transporteMaritimo.NombreAseg) Then nodoTransporteMaritimo.SetAttribute("NombreAseg", transporteMaritimo.NombreAseg)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumPolizaSeguro) Then nodoTransporteMaritimo.SetAttribute("NumPolizaSeguro", transporteMaritimo.NumPolizaSeguro)
        If Not String.IsNullOrEmpty(transporteMaritimo.TipoEmbarcacion) Then nodoTransporteMaritimo.SetAttribute("TipoEmbarcacion", transporteMaritimo.TipoEmbarcacion)
        If Not String.IsNullOrEmpty(transporteMaritimo.Matricula) Then nodoTransporteMaritimo.SetAttribute("Matricula", transporteMaritimo.Matricula)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumeroOMI) Then nodoTransporteMaritimo.SetAttribute("NumeroOMI", transporteMaritimo.NumeroOMI)
        If transporteMaritimo.AnioEmbarcacion > 0 Then nodoTransporteMaritimo.SetAttribute("AnioEmbarcacion", transporteMaritimo.AnioEmbarcacion.ToString())
        If Not String.IsNullOrEmpty(transporteMaritimo.NombreEmbarc) Then nodoTransporteMaritimo.SetAttribute("NombreEmbarc", transporteMaritimo.NombreEmbarc)
        If Not String.IsNullOrEmpty(transporteMaritimo.NacionalidadEmbarc) Then nodoTransporteMaritimo.SetAttribute("NacionalidadEmbarc", transporteMaritimo.NacionalidadEmbarc)
        nodoTransporteMaritimo.SetAttribute("UnidadesDeArqBruto", transporteMaritimo.UnidadesDeArqBruto.ToString("F3"))
        If Not String.IsNullOrEmpty(transporteMaritimo.TipoCarga) Then nodoTransporteMaritimo.SetAttribute("TipoCarga", transporteMaritimo.TipoCarga)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumCertITC) Then nodoTransporteMaritimo.SetAttribute("NumCertITC", transporteMaritimo.NumCertITC)
        If transporteMaritimo.Eslora > 0 Then nodoTransporteMaritimo.SetAttribute("Eslora", transporteMaritimo.Eslora.ToString())
        If transporteMaritimo.Manga > 0 Then nodoTransporteMaritimo.SetAttribute("Manga", transporteMaritimo.Manga.ToString())
        If transporteMaritimo.Calado > 0 Then nodoTransporteMaritimo.SetAttribute("Calado", transporteMaritimo.Calado.ToString())
        If Not String.IsNullOrEmpty(transporteMaritimo.LineaNaviera) Then nodoTransporteMaritimo.SetAttribute("LineaNaviera", transporteMaritimo.LineaNaviera)
        nodoTransporteMaritimo.SetAttribute("NombreAgenteNaviero", transporteMaritimo.NombreAgenteNaviero)
        nodoTransporteMaritimo.SetAttribute("NumAutorizacionNaviero", transporteMaritimo.NumAutorizacionNaviero)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumViaje) Then nodoTransporteMaritimo.SetAttribute("NumViaje", transporteMaritimo.NumViaje)
        If Not String.IsNullOrEmpty(transporteMaritimo.NumConocEmbarc) Then nodoTransporteMaritimo.SetAttribute("NumConocEmbarc", transporteMaritimo.NumConocEmbarc)
        Return nodoTransporteMaritimo
    End Function

    Private Shared Function CP20AgregarNodoContenedor(ByVal contenedor As Contenedor, ByVal documento As XmlDocument) As XmlElement
        If contenedor Is Nothing Then Return Nothing
        Dim nodoContenedor As XmlElement = documento.CreateElement("cartaporte20", "Contenedor", NAMESPACE_CARTA_PORTE)
        nodoContenedor.SetAttribute("MatriculaContenedor", contenedor.MatriculaContenedor)
        nodoContenedor.SetAttribute("TipoContenedor", contenedor.TipoContenedor)
        If Not String.IsNullOrEmpty(contenedor.NumPrecinto) Then nodoContenedor.SetAttribute("NumPrecinto", contenedor.NumPrecinto)
        Return nodoContenedor
    End Function

    Private Shared Function CP20AgregarNodoTransporteAereo(ByVal transporteAereo As TransporteAereo, ByVal documento As XmlDocument) As XmlElement
        If transporteAereo Is Nothing Then Return Nothing
        Dim nodoTransporteAereo As XmlElement = documento.CreateElement("cartaporte20", "TransporteAereo", NAMESPACE_CARTA_PORTE)
        If Not String.IsNullOrEmpty(transporteAereo.PermSCT) Then nodoTransporteAereo.SetAttribute("PermSCT", transporteAereo.PermSCT)
        If Not String.IsNullOrEmpty(transporteAereo.NumPermisoSCT) Then nodoTransporteAereo.SetAttribute("NumPermisoSCT", transporteAereo.NumPermisoSCT)
        If Not String.IsNullOrEmpty(transporteAereo.MatriculaAeronave) Then nodoTransporteAereo.SetAttribute("MatriculaAeronave", transporteAereo.MatriculaAeronave)
        If Not String.IsNullOrEmpty(transporteAereo.NombreAseg) Then nodoTransporteAereo.SetAttribute("NombreAseg", transporteAereo.NombreAseg)
        If Not String.IsNullOrEmpty(transporteAereo.NumPolizaSeguro) Then nodoTransporteAereo.SetAttribute("NumPolizaSeguro", transporteAereo.NumPolizaSeguro)
        If Not String.IsNullOrEmpty(transporteAereo.NumeroGuia) Then nodoTransporteAereo.SetAttribute("NumeroGuia", transporteAereo.NumeroGuia)
        If Not String.IsNullOrEmpty(transporteAereo.LugarContrato) Then nodoTransporteAereo.SetAttribute("LugarContrato", transporteAereo.LugarContrato)
        If Not String.IsNullOrEmpty(transporteAereo.CodigoTransportista) Then nodoTransporteAereo.SetAttribute("CodigoTransportista", transporteAereo.CodigoTransportista)
        If Not String.IsNullOrEmpty(transporteAereo.RFCEmbarcador) Then nodoTransporteAereo.SetAttribute("RFCEmbarcador", transporteAereo.RFCEmbarcador)
        If Not String.IsNullOrEmpty(transporteAereo.NumRegIdTribEmbarc) Then nodoTransporteAereo.SetAttribute("NumRegIdTribEmbarc", transporteAereo.NumRegIdTribEmbarc)
        If Not String.IsNullOrEmpty(transporteAereo.ResidenciaFiscalEmbarc) Then nodoTransporteAereo.SetAttribute("ResidenciaFiscalEmbarc", transporteAereo.ResidenciaFiscalEmbarc)
        If Not String.IsNullOrEmpty(transporteAereo.NombreEmbarcador) Then nodoTransporteAereo.SetAttribute("NombreEmbarcador", transporteAereo.NombreEmbarcador)
        Return nodoTransporteAereo
    End Function

    Private Shared Function CP20AgregarNodoTransporteFerroviario(ByVal transporteFerroviario As TransporteFerroviario, ByVal documento As XmlDocument) As XmlElement
        If transporteFerroviario Is Nothing Then Return Nothing
        Dim nodoTransporteFerroviario As XmlElement = documento.CreateElement("cartaporte20", "TransporteFerroviario", NAMESPACE_CARTA_PORTE)

        For Each derechosDePaso In transporteFerroviario.DerechosDePaso
            Dim nodoDerechosDePaso As XmlElement = CP20AgregarNodoDerechosDePaso(derechosDePaso, documento)
            If nodoDerechosDePaso IsNot Nothing Then nodoTransporteFerroviario.AppendChild(nodoDerechosDePaso)
        Next

        For Each carro In transporteFerroviario.Carro
            Dim nodoCarro As XmlElement = CP20AgregarNodoCarro(carro, documento)
            If nodoCarro IsNot Nothing Then nodoTransporteFerroviario.AppendChild(nodoCarro)
        Next

        nodoTransporteFerroviario.SetAttribute("TipoDeServicio", transporteFerroviario.TipoDeServicio)
        nodoTransporteFerroviario.SetAttribute("TipoDeTrafico", transporteFerroviario.TipoDeTrafico)
        If Not String.IsNullOrEmpty(transporteFerroviario.NombreAseg) Then nodoTransporteFerroviario.SetAttribute("NombreAseg", transporteFerroviario.NombreAseg)
        If Not String.IsNullOrEmpty(transporteFerroviario.NumPolizaSeguro) Then nodoTransporteFerroviario.SetAttribute("NumPolizaSeguro", transporteFerroviario.NumPolizaSeguro)
        Return nodoTransporteFerroviario
    End Function

    Private Shared Function CP20AgregarNodoDerechosDePaso(ByVal derechosDePaso As DerechosDePaso, ByVal documento As XmlDocument) As XmlElement
        If derechosDePaso Is Nothing Then Return Nothing
        Dim nodoDerechosDePaso As XmlElement = documento.CreateElement("cartaporte20", "DerechosDePaso", NAMESPACE_CARTA_PORTE)
        nodoDerechosDePaso.SetAttribute("TipoDerechoDePaso", derechosDePaso.TipoDerechoDePaso)
        nodoDerechosDePaso.SetAttribute("KilometrajePagado", derechosDePaso.KilometrajePagado.ToString("F2"))
        Return nodoDerechosDePaso
    End Function

    Private Shared Function CP20AgregarNodoCarro(ByVal carro As Carro, ByVal documento As XmlDocument) As XmlElement
        If carro Is Nothing Then Return Nothing
        Dim nodoCarro As XmlElement = documento.CreateElement("cartaporte20", "Carro", NAMESPACE_CARTA_PORTE)

        For Each contenedor In carro.Contenedor
            Dim nodoContenedor As XmlElement = CP20AgregarNodoContenedor(contenedor, documento)
            If nodoContenedor IsNot Nothing Then nodoCarro.AppendChild(nodoContenedor)
        Next

        nodoCarro.SetAttribute("TipoCarro", carro.TipoCarro)
        nodoCarro.SetAttribute("MatriculaCarro", carro.MatriculaCarro)
        nodoCarro.SetAttribute("GuiaCarro", carro.GuiaCarro)
        nodoCarro.SetAttribute("ToneladasNetasCarro", carro.ToneladasNetasCarro.ToString("F3"))
        Return nodoCarro
    End Function

    Private Shared Function CP20AgregarNodoContenedor(ByVal contenedor As CarroContenedor, ByVal documento As XmlDocument) As XmlElement
        If contenedor Is Nothing Then Return Nothing
        Dim nodoContenedor As XmlElement = documento.CreateElement("cartaporte20", "Contenedor", NAMESPACE_CARTA_PORTE)
        nodoContenedor.SetAttribute("TipoContenedor", contenedor.TipoContenedor)
        nodoContenedor.SetAttribute("PesoContenedorVacio", contenedor.PesoContenedorVacio.ToString("F3"))
        nodoContenedor.SetAttribute("PesoNetoMercancia", contenedor.PesoNetoMercancia.ToString("F3"))
        Return nodoContenedor
    End Function

    Private Shared Function CP20AgregarNodoFiguraTransporte(ByVal figuraTransporte As FiguraTransporte, ByVal documento As XmlDocument) As XmlElement
        If figuraTransporte Is Nothing Then Return Nothing
        Dim nodoFiguraTransporte As XmlElement = documento.CreateElement("cartaporte20", "FiguraTransporte", NAMESPACE_CARTA_PORTE)

        For Each tiposFigura In figuraTransporte.TiposFigura
            Dim nodoPartesTransporte As XmlElement = CP20AgregarNodoTiposFigura(tiposFigura, documento)
            If nodoPartesTransporte IsNot Nothing Then nodoFiguraTransporte.AppendChild(nodoPartesTransporte)
        Next

        Return nodoFiguraTransporte
    End Function

    Private Shared Function CP20AgregarNodoTiposFigura(ByVal tiposFigura As TiposFigura, ByVal documento As XmlDocument) As XmlElement
        If tiposFigura Is Nothing Then Return Nothing
        Dim nodoTiposFigura As XmlElement = documento.CreateElement("cartaporte20", "TiposFigura", NAMESPACE_CARTA_PORTE)

        For Each tipoFigura In tiposFigura.PartesTransporte
            Dim nodoPartesTransporte As XmlElement = CP20AgregarNodoPartesTransporte(tipoFigura, documento)
            If nodoPartesTransporte IsNot Nothing Then nodoTiposFigura.AppendChild(nodoPartesTransporte)
        Next
        Dim nodoDomicilio As XmlElement = CP20AgregarNodoDomicilio(tiposFigura.Domicilio, documento)
        If nodoDomicilio IsNot Nothing Then nodoTiposFigura.AppendChild(nodoDomicilio)

        nodoTiposFigura.SetAttribute("TipoFigura", tiposFigura.TipoFigura)
        If Not String.IsNullOrEmpty(tiposFigura.RFCFigura) Then nodoTiposFigura.SetAttribute("RFCFigura", tiposFigura.RFCFigura)
        If Not String.IsNullOrEmpty(tiposFigura.NumLicencia) Then nodoTiposFigura.SetAttribute("NumLicencia", tiposFigura.NumLicencia)
        If Not String.IsNullOrEmpty(tiposFigura.NombreFigura) Then nodoTiposFigura.SetAttribute("NombreFigura", tiposFigura.NombreFigura)
        If Not String.IsNullOrEmpty(tiposFigura.NumRegIdTribFigura) Then nodoTiposFigura.SetAttribute("NumRegIdTribFigura", tiposFigura.NumRegIdTribFigura)
        If Not String.IsNullOrEmpty(tiposFigura.ResidenciaFiscalFigura) Then nodoTiposFigura.SetAttribute("ResidenciaFiscalFigura", tiposFigura.ResidenciaFiscalFigura)
        Return nodoTiposFigura
    End Function

    Private Shared Function CP20AgregarNodoPartesTransporte(ByVal partesTransporte As PartesTransporte, ByVal documento As XmlDocument) As XmlElement
        If partesTransporte Is Nothing Then Return Nothing
        Dim nodoPartesTransporte As XmlElement = documento.CreateElement("cartaporte20", "PartesTransporte", NAMESPACE_CARTA_PORTE)
        nodoPartesTransporte.SetAttribute("ParteTransporte", partesTransporte.ParteTransporte)
        Return nodoPartesTransporte
    End Function

#End Region
#Region "Nomina 1.2"
    Private Shared Function AgregarNodoNominaComplemento(ByVal nomina As Nomina, ByVal documento As XmlDocument) As XmlElement
        If nomina Is Nothing Then Return Nothing
        Dim nodoNomina As XmlElement = documento.CreateElement("nomina12", "Nomina", NAMESPACE_NOMINA)
        nodoNomina.SetAttribute("Version", nomina.Version)
        nodoNomina.SetAttribute("TipoNomina", nomina.TipoNomina)
        nodoNomina.SetAttribute("FechaPago", nomina.FechaPago.ToString("yyyy-MM-dd"))
        nodoNomina.SetAttribute("FechaInicialPago", nomina.FechaInicialPago.ToString("yyyy-MM-dd"))
        nodoNomina.SetAttribute("FechaFinalPago", nomina.FechaFinalPago.ToString("yyyy-MM-dd"))
        If nomina.NumDiasPagados > 0 Then nodoNomina.SetAttribute("NumDiasPagados", nomina.NumDiasPagados.ToString("F3"))
        If nomina.TotalPercepciones > 0 Then nodoNomina.SetAttribute("TotalPercepciones", nomina.TotalPercepciones.ToString("F2"))
        If nomina.TotalDeducciones > 0 Then nodoNomina.SetAttribute("TotalDeducciones", nomina.TotalDeducciones.ToString("F2"))
        If nomina.TotalOtrosPagos > 0 Then nodoNomina.SetAttribute("TotalOtrosPagos", nomina.TotalOtrosPagos.ToString("F2"))
        Dim emisor As XmlElement = AgregarNodoNEmisor(nomina.Emisor, documento)
        If emisor IsNot Nothing Then nodoNomina.AppendChild(emisor)
        Dim receptor As XmlElement = AgregarNodoNReceptor(nomina.Receptor, documento)
        If receptor IsNot Nothing Then nodoNomina.AppendChild(receptor)
        Dim percepciones As XmlElement = AgregarNodoNPercepciones(nomina.Percepciones, documento)
        If percepciones IsNot Nothing Then nodoNomina.AppendChild(percepciones)
        Dim deducciones As XmlElement = AgregarNodoNDeducciones(nomina.Deducciones, documento)
        If deducciones IsNot Nothing Then nodoNomina.AppendChild(deducciones)
        Dim otrosPagos As XmlElement = AgregarNodoNOtrosPagos(nomina.OtrosPagos, documento)
        If otrosPagos IsNot Nothing Then nodoNomina.AppendChild(otrosPagos)
        Dim incapacidades As XmlElement = AgregarNodoNIncapacidades(nomina.Incapacidades, documento)
        If incapacidades IsNot Nothing Then nodoNomina.AppendChild(otrosPagos)
        Dim schemaLocation As XmlAttribute = documento.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
        schemaLocation.Value = SCHEMALOCATION_NOMINA
        nodoNomina.SetAttributeNode(schemaLocation)
        Return nodoNomina
    End Function

    Private Shared Function AgregarNodoNEmisor(ByVal emisor As NEmisor, ByVal documento As XmlDocument) As XmlElement
        If emisor Is Nothing Then Return Nothing
        Dim nodoNEmisor As XmlElement = documento.CreateElement("nomina12", "Emisor", NAMESPACE_NOMINA)
        If emisor.Curp <> String.Empty Then nodoNEmisor.SetAttribute("Curp", emisor.Curp)
        If emisor.RegistroPatronal <> String.Empty Then nodoNEmisor.SetAttribute("RegistroPatronal", emisor.RegistroPatronal)
        If emisor.RfcPatronOrigen <> String.Empty Then nodoNEmisor.SetAttribute("RfcPatronOrigen", emisor.RfcPatronOrigen)
        Dim entidadSNCF As XmlElement = ObtenerNodoNEntidadSNCF(emisor.EntidadSNCF, documento)
        If entidadSNCF IsNot Nothing Then nodoNEmisor.AppendChild(entidadSNCF)
        Return nodoNEmisor
    End Function

    Private Shared Function ObtenerNodoNEntidadSNCF(ByVal entidadSNCF As NEntidadSNCF, ByVal documento As XmlDocument) As XmlElement
        If entidadSNCF Is Nothing Then Return Nothing
        Dim nodoNEntidadSNCF As XmlElement = documento.CreateElement("Nomina12", "EntidadSNCF", NAMESPACE_NOMINA)
        nodoNEntidadSNCF.SetAttribute("OrigenRecurso", entidadSNCF.OrigenRecurso)
        If entidadSNCF.MontoRecursoPropio > 0 Then nodoNEntidadSNCF.SetAttribute("MontoRecursoPropio", entidadSNCF.MontoRecursoPropio.ToString())
        Return nodoNEntidadSNCF
    End Function

    Private Shared Function AgregarNodoNReceptor(ByVal receptor As NReceptor, ByVal documento As XmlDocument) As XmlElement
        If receptor Is Nothing Then Return Nothing
        Dim nodoNReceptor As XmlElement = documento.CreateElement("nomina12", "Receptor", NAMESPACE_NOMINA)
        nodoNReceptor.SetAttribute("Curp", receptor.Curp)
        If receptor.NumSeguridadSocial <> String.Empty Then nodoNReceptor.SetAttribute("NumSeguridadSocial", receptor.NumSeguridadSocial)
        If receptor.FechaInicioRelLaboral <> DateTime.Now Then nodoNReceptor.SetAttribute("FechaInicioRelLaboral", receptor.FechaInicioRelLaboral.ToString("yyyy-MM-dd"))
        If receptor.Antiguedad <> String.Empty Then nodoNReceptor.SetAttribute("Antigüedad", receptor.Antiguedad)
        nodoNReceptor.SetAttribute("TipoContrato", receptor.TipoContrato)
        If receptor.Sindicalizado <> String.Empty Then nodoNReceptor.SetAttribute("Sindicalizado", receptor.Sindicalizado)
        If receptor.TipoJornada <> String.Empty Then nodoNReceptor.SetAttribute("TipoJornada", receptor.TipoJornada)
        nodoNReceptor.SetAttribute("TipoRegimen", receptor.TipoRegimen)
        nodoNReceptor.SetAttribute("NumEmpleado", receptor.NumEmpleado)
        If receptor.Departamento <> String.Empty Then nodoNReceptor.SetAttribute("Departamento", receptor.Departamento)
        If receptor.Puesto <> String.Empty Then nodoNReceptor.SetAttribute("Puesto", receptor.Puesto)
        If receptor.RiesgoPuesto <> String.Empty Then nodoNReceptor.SetAttribute("RiesgoPuesto", receptor.RiesgoPuesto)
        nodoNReceptor.SetAttribute("PeridiocidadPago", receptor.PeriodicidadPago)
        If receptor.Banco <> String.Empty Then nodoNReceptor.SetAttribute("Banco", receptor.Banco)
        If receptor.CuentaBancaria <> String.Empty Then nodoNReceptor.SetAttribute("CuentaBancaria", receptor.CuentaBancaria)
        If receptor.SalarioBaseCotApor > 0 Then nodoNReceptor.SetAttribute("SalarioBaseCotApor", receptor.SalarioBaseCotApor.ToString("F2"))
        If receptor.SalarioDiarioIntegrado > 0 Then nodoNReceptor.SetAttribute("SalarioDiarioIntegrado", receptor.SalarioDiarioIntegrado.ToString("F2"))
        nodoNReceptor.SetAttribute("ClaveEntFed", receptor.ClaveEntFed)
        Dim subContratacion As XmlElement = ObtenerNodoNSubContratacion(receptor.SubContratacion, documento)
        If subContratacion IsNot Nothing Then nodoNReceptor.AppendChild(subContratacion)
        Return nodoNReceptor
    End Function

    Private Shared Function ObtenerNodoNSubContratacion(ByVal subContratacion As List(Of NSubContratacion), ByVal documento As XmlDocument) As XmlElement
        If subContratacion Is Nothing OrElse subContratacion.Count() = 0 Then Return Nothing
        Dim nodoNSubContratacion As XmlElement = documento.CreateElement("nomina12", "SubContratacion", NAMESPACE_NOMINA)

        For Each sc As NSubContratacion In subContratacion
            nodoNSubContratacion.SetAttribute("RfcLabora", sc.RfcLabora)
            If sc.PorcentajeTiempo > 0 Then nodoNSubContratacion.SetAttribute("PorcentajeTiempo", sc.PorcentajeTiempo.ToString())
        Next

        Return nodoNSubContratacion
    End Function

    Private Shared Function AgregarNodoNPercepciones(ByVal percepciones As NPercepciones, ByVal documento As XmlDocument) As XmlElement
        If percepciones Is Nothing Then Return Nothing
        Dim nodoNPercepciones As XmlElement = documento.CreateElement("nomina12", "Percepciones", NAMESPACE_NOMINA)
        If percepciones.TotalSueldos > 0 Then nodoNPercepciones.SetAttribute("TotalSueldos", percepciones.TotalSueldos.ToString("F2"))
        If percepciones.TotalSeparacionIndemnizacion > 0 Then nodoNPercepciones.SetAttribute("TotalSeparacionIndemnizacion", percepciones.TotalSeparacionIndemnizacion.ToString("F2"))
        If percepciones.TotalJubilacionPensionRetiro > 0 Then nodoNPercepciones.SetAttribute("TotalJubilacionPensionRetiro", percepciones.TotalJubilacionPensionRetiro.ToString("F2"))
        nodoNPercepciones.SetAttribute("TotalGravado", percepciones.TotalGravado.ToString("F2"))
        nodoNPercepciones.SetAttribute("TotalExento", percepciones.TotalExento.ToString("F2"))

        If percepciones.Percepcion IsNot Nothing AndAlso percepciones.Percepcion.Count() > 0 Then

            For Each p As NPercepcion In percepciones.Percepcion
                Dim nodoNPercepcion As XmlElement = documento.CreateElement("nomina12", "Percepcion", NAMESPACE_NOMINA)
                nodoNPercepcion.SetAttribute("TipoPercepcion", p.TipoPercepcion)
                nodoNPercepcion.SetAttribute("Clave", p.Clave)
                nodoNPercepcion.SetAttribute("Concepto", p.Concepto)
                nodoNPercepcion.SetAttribute("ImporteGravado", p.ImporteGravado.ToString("F2"))
                nodoNPercepcion.SetAttribute("ImporteExento", p.ImporteExento.ToString("F2"))
                Dim accionesOTitulos As XmlElement = ObtenerNodoNAccionesOTitulos(p.AccionesOTitulos, documento)
                If accionesOTitulos IsNot Nothing Then nodoNPercepcion.AppendChild(accionesOTitulos)
                Dim horasExtra As XmlElement = ObtenerNodoNHorasExtras(p.HorasExtras, documento)
                If horasExtra IsNot Nothing Then nodoNPercepcion.AppendChild(horasExtra)
                nodoNPercepciones.AppendChild(nodoNPercepcion)
            Next
        End If

        Dim jubilacionPensionRetiro As XmlElement = ObtenerNodoNJubilacionPensionRetiro(percepciones.JubilacionPensionRetiro, documento)
        If jubilacionPensionRetiro IsNot Nothing Then nodoNPercepciones.AppendChild(jubilacionPensionRetiro)
        Dim separacionIndemizacion As XmlElement = ObtenerNodoNSeparacionIndemnizacion(percepciones.SeparacionIndeminzacion, documento)
        If separacionIndemizacion IsNot Nothing Then nodoNPercepciones.AppendChild(separacionIndemizacion)
        Return nodoNPercepciones
    End Function

    Private Shared Function ObtenerNodoNAccionesOTitulos(ByVal accionesOTitulos As NAccionesOTitulos, ByVal documento As XmlDocument) As XmlElement
        If accionesOTitulos Is Nothing Then Return Nothing
        Dim nodoNAccionesOTitulos As XmlElement = documento.CreateElement("nomina12", "AccionesOTitulos", NAMESPACE_NOMINA)
        nodoNAccionesOTitulos.SetAttribute("ValorMercado", accionesOTitulos.ValorMercado)
        nodoNAccionesOTitulos.SetAttribute("PrecioAlOtorgarse", accionesOTitulos.PrecioAlOtorgarse.ToString("F6"))
        Return nodoNAccionesOTitulos
    End Function

    Private Shared Function ObtenerNodoNHorasExtras(ByVal horasExtra As List(Of NHorasExtra), ByVal documento As XmlDocument) As XmlElement
        If horasExtra Is Nothing OrElse horasExtra.Count() = 0 Then Return Nothing
        Dim nodoNHorasExtra As XmlElement = documento.CreateElement("nomina12", "HoraExtra", NAMESPACE_NOMINA)

        For Each he As NHorasExtra In horasExtra
            nodoNHorasExtra.SetAttribute("Dias", he.Dias.ToString())

            nodoNHorasExtra.SetAttribute("TipoHoras", he.TipoHoras.ToString("F2"))
            nodoNHorasExtra.SetAttribute("HorasExtra", he.HorasExtra.ToString("F2"))
            nodoNHorasExtra.SetAttribute("ImportePagado", he.ImportePagado.ToString("F2"))
        Next

        Return nodoNHorasExtra
    End Function

    Private Shared Function ObtenerNodoNJubilacionPensionRetiro(ByVal jubilacionPensionRetiro As NJubilacionPensionRetiro, ByVal documento As XmlDocument) As XmlElement
        If jubilacionPensionRetiro Is Nothing Then Return Nothing
        Dim nodoNJubilacionPesionRetiro As XmlElement = documento.CreateElement("nomina12", "JubulacionesPensionRetiro", NAMESPACE_NOMINA)
        If jubilacionPensionRetiro.TotalUnaExhibicion > 0 Then nodoNJubilacionPesionRetiro.SetAttribute("TotalUnaExhibicion", jubilacionPensionRetiro.TotalUnaExhibicion.ToString("F2"))
        If jubilacionPensionRetiro.TotalParcialidad > 0 Then nodoNJubilacionPesionRetiro.SetAttribute("TotalParcialidad", jubilacionPensionRetiro.TotalParcialidad.ToString("F2"))
        If jubilacionPensionRetiro.MontoDiario > 0 Then nodoNJubilacionPesionRetiro.SetAttribute("MontoDiario", jubilacionPensionRetiro.MontoDiario.ToString("F2"))
        nodoNJubilacionPesionRetiro.SetAttribute("IngresoAcumulable", jubilacionPensionRetiro.IngresoAcumulable.ToString("F2"))
        nodoNJubilacionPesionRetiro.SetAttribute("IngresoNoAcumulable", jubilacionPensionRetiro.IngresoNoAcumulable.ToString("F2"))
        Return nodoNJubilacionPesionRetiro
    End Function

    Private Shared Function ObtenerNodoNSeparacionIndemnizacion(ByVal separacionIndemnizacion As NSeparacionIndemnizacion, ByVal documento As XmlDocument) As XmlElement
        If separacionIndemnizacion Is Nothing Then Return Nothing
        Dim nodoNSeparacionIndemnizacion As XmlElement = documento.CreateElement("nomina12", "SeparacionIndemnizacion", NAMESPACE_NOMINA)
        nodoNSeparacionIndemnizacion.SetAttribute("SeparacionIndemnizacion", separacionIndemnizacion.TotalPagado.ToString("F2"))
        nodoNSeparacionIndemnizacion.SetAttribute("NumAnosServicio", separacionIndemnizacion.NumAnosServicio.ToString("F2"))
        nodoNSeparacionIndemnizacion.SetAttribute("UltimoSueldoMensOrd", separacionIndemnizacion.UltimoSueldoMensOrd.ToString("F2"))
        nodoNSeparacionIndemnizacion.SetAttribute("IngresoAcumulado", separacionIndemnizacion.IngresoAcumulable.ToString("F2"))
        nodoNSeparacionIndemnizacion.SetAttribute("IngresoNoAcumulable", separacionIndemnizacion.IngresoNoAcumulable.ToString("F2"))
        Return nodoNSeparacionIndemnizacion
    End Function

    Private Shared Function AgregarNodoNDeducciones(ByVal deducciones As NDeducciones, ByVal documento As XmlDocument) As XmlElement
        If deducciones Is Nothing Then Return Nothing
        Dim nodoNDeducciones As XmlElement = documento.CreateElement("nomina12:Deducciones", NAMESPACE_NOMINA)
        If deducciones.TotalOtrasDeducciones > 0 Then nodoNDeducciones.SetAttribute("TotalOtrasDeducciones", deducciones.TotalOtrasDeducciones.ToString("F2"))
        If deducciones.TotalImpuestosRetenidos > 0 Then nodoNDeducciones.SetAttribute("TotalImpuestosRetenidos", deducciones.TotalImpuestosRetenidos.ToString("F2"))

        If deducciones.Deduccion IsNot Nothing AndAlso deducciones.Deduccion.Count() > 0 Then

            For Each d As NDeduccion In deducciones.Deduccion
                Dim nodoDeduccion As XmlElement = documento.CreateElement("nomina12", "Deduccion", NAMESPACE_NOMINA)
                nodoDeduccion.SetAttribute("TipoDeduccion", d.TipoDeduccion)
                nodoDeduccion.SetAttribute("Clave", d.Clave)
                nodoDeduccion.SetAttribute("Concepto", d.Concepto)
                nodoDeduccion.SetAttribute("Importe", d.Importe.ToString("F2"))
                nodoNDeducciones.AppendChild(nodoDeduccion)
            Next
        End If

        Return nodoNDeducciones
    End Function

    Private Shared Function AgregarNodoNOtrosPagos(ByVal otrosPagos As NOtrosPagos, ByVal documento As XmlDocument) As XmlElement
        If otrosPagos Is Nothing Then Return Nothing
        Dim nodoNOtrosPagos As XmlElement = documento.CreateElement("nomina12", "OtrosPagos", NAMESPACE_NOMINA)

        For Each op As NOtroPago In otrosPagos.OtroPago
            Dim nodoNOtroPago As XmlElement = documento.CreateElement("nomina12", "OtroPago", NAMESPACE_NOMINA)
            nodoNOtroPago.SetAttribute("TipoOtroPago", op.TipoOtroPago)
            nodoNOtroPago.SetAttribute("Clave", op.Clave)
            nodoNOtroPago.SetAttribute("Concepto", op.Concepto)
            nodoNOtroPago.SetAttribute("Importe", op.Importe.ToString("F2"))
            Dim nsubsidioAlEmpleo As XmlElement = ObtenerNodoNSubsidioAlEmpleo(op.SubsidioAlEmpleo, documento)
            If nsubsidioAlEmpleo IsNot Nothing Then nodoNOtroPago.AppendChild(nsubsidioAlEmpleo)
            Dim ncompensacionSaldosAFavor As XmlElement = ObtenerNodoNCompensacionSaldosAFavor(op.CompensacionSaldosAFavor, documento)
            If ncompensacionSaldosAFavor IsNot Nothing Then nodoNOtroPago.AppendChild(ncompensacionSaldosAFavor)
            nodoNOtrosPagos.AppendChild(nodoNOtroPago)
        Next

        Return nodoNOtrosPagos
    End Function

    Private Shared Function ObtenerNodoNSubsidioAlEmpleo(ByVal nSubsidioAlEmpleo As NSubsidioAlEmpleo, ByVal documento As XmlDocument) As XmlElement
        If nSubsidioAlEmpleo Is Nothing Then Return Nothing
        Dim nodoNSubsidioAlEmpleo As XmlElement = documento.CreateElement("nomina12", "SubsidioAlEmpleo", NAMESPACE_NOMINA)
        nodoNSubsidioAlEmpleo.SetAttribute("SubsidioCausado", nSubsidioAlEmpleo.SubsidioCausado.ToString("F2"))
        Return nodoNSubsidioAlEmpleo
    End Function

    Private Shared Function ObtenerNodoNCompensacionSaldosAFavor(ByVal ncompensacionSaldosAFavor As NCompensacionSaldosAFavor, ByVal documento As XmlDocument) As XmlElement
        If ncompensacionSaldosAFavor Is Nothing Then Return Nothing
        Dim nodoNCompensacionSaldosAFavor As XmlElement = documento.CreateElement("nomina12", "CompensacionSaldosAFavor", NAMESPACE_NOMINA)
        nodoNCompensacionSaldosAFavor.SetAttribute("SaldoAFavor", ncompensacionSaldosAFavor.SaldoAFavor.ToString("F2"))
        nodoNCompensacionSaldosAFavor.SetAttribute("Año", ncompensacionSaldosAFavor.Ano)
        nodoNCompensacionSaldosAFavor.SetAttribute("RemanenteSalFav", ncompensacionSaldosAFavor.RemanenteSalFav.ToString("F2"))
        Return nodoNCompensacionSaldosAFavor
    End Function

    Private Shared Function AgregarNodoNIncapacidades(ByVal incapacidades As NIncapacidades, ByVal documento As XmlDocument) As XmlElement
        If incapacidades Is Nothing Then Return Nothing
        Dim nodoNIncapacidades As XmlElement = documento.CreateElement("nomina12", "Incapacidades", NAMESPACE_NOMINA)

        For Each i As NIncapacidad In incapacidades.Incapacidad
            Dim nodoNIncapacidad As XmlElement = documento.CreateElement("nomina12", "Incapacidad", NAMESPACE_NOMINA)
            nodoNIncapacidad.SetAttribute("DiasIncapacidad", i.DiasIncapacidad.ToString("F2"))
            nodoNIncapacidad.SetAttribute("TipoIncapacidad", i.TipoIncapacidad)
            nodoNIncapacidad.SetAttribute("ImporteMonetario", i.ImporteMonetario.ToString("F2"))
            nodoNIncapacidad.AppendChild(nodoNIncapacidad)
        Next

        Return nodoNIncapacidades
    End Function
#End Region
#Region "Pagos 2.0"
    Private Shared Function AgregarNodoPagos(ByVal pagos As Pagos, ByVal documento As XmlDocument) As XmlElement
        If pagos Is Nothing Then Return Nothing
        Dim nodoPagos As XmlElement = documento.CreateElement("pago20", "Pagos", NAMESPACE_PAGOS)
        nodoPagos.SetAttribute("Version", pagos.Version)
        nodoPagos.AppendChild(ObteneNodoPTotales(pagos.Totales, documento))

        If pagos.Pago IsNot Nothing AndAlso pagos.Pago.Count() > 0 Then

            For Each pg As Pago In pagos.Pago
                Dim nodoPago As XmlElement = documento.CreateElement("pago20", "Pago", NAMESPACE_PAGOS)
                nodoPago.SetAttribute("FechaPago", pg.FechaPago.ToString("s"))
                nodoPago.SetAttribute("FormaDePagoP", pg.FormaDePagoP)
                nodoPago.SetAttribute("MonedaP", pg.MonedaP)
                If pg.TipoCambioP > 0 Then nodoPago.SetAttribute("TipoCambioP", pg.TipoCambioP.ToString("F6"))
                nodoPago.SetAttribute("Monto", pg.Monto.ToString("F2"))
                If Not String.IsNullOrEmpty(pg.NumOperacion) Then nodoPago.SetAttribute("NumOperacion", pg.NumOperacion)
                If Not String.IsNullOrEmpty(pg.RfcEmisorCtaOrd) Then nodoPago.SetAttribute("RfcEmisorCtaOrd", pg.RfcEmisorCtaOrd)
                If Not String.IsNullOrEmpty(pg.NomBancoOrdExt) Then nodoPago.SetAttribute("NomBancoOrdExt", pg.NomBancoOrdExt)
                If Not String.IsNullOrEmpty(pg.CtaOrdenante) Then nodoPago.SetAttribute("CtaOrdenante", pg.CtaOrdenante)
                If Not String.IsNullOrEmpty(pg.RfcEmisorCtaBen) Then nodoPago.SetAttribute("RfcEmisorCtaBen", pg.RfcEmisorCtaBen)
                If Not String.IsNullOrEmpty(pg.CtaBeneficiario) Then nodoPago.SetAttribute("CtaBeneficiario", pg.CtaBeneficiario)
                If Not String.IsNullOrEmpty(pg.TipoCadPago) Then nodoPago.SetAttribute("TipoCadPago", pg.TipoCadPago)
                If Not String.IsNullOrEmpty(pg.CertPago) Then nodoPago.SetAttribute("CertPago", pg.CertPago)
                If Not String.IsNullOrEmpty(pg.CadPago) Then nodoPago.SetAttribute("CadPago", pg.CadPago)
                If Not String.IsNullOrEmpty(pg.SelloPago) Then nodoPago.SetAttribute("SelloPago", pg.SelloPago)

                For Each sr As PDoctoRelacionado In pg.DoctoRelacionado
                    Dim doctoRelacionado As XmlElement = ObtenerNodoPDoctoRelacionado(sr, documento)
                    If doctoRelacionado IsNot Nothing Then nodoPago.AppendChild(doctoRelacionado)
                Next
                Dim pImpuestos As XmlElement = ObtenerNodoImpuestosP(pg.Impuestos, documento)
                If pImpuestos IsNot Nothing Then nodoPago.AppendChild(pImpuestos)
                nodoPagos.AppendChild(nodoPago)
            Next

        End If

        Return nodoPagos
    End Function

    Private Shared Function ObteneNodoPTotales(ByVal totales As PTotales, ByVal documento As XmlDocument) As XmlElement
        Dim nodoTotales As XmlElement = documento.CreateElement("pago20", "Totales", NAMESPACE_PAGOS)
        If totales.MontoTotalPagos > 0 Then nodoTotales.SetAttribute("MontoTotalPagos", totales.MontoTotalPagos.ToString("F2"))
        If totales.TotalRetencionesIEPS > 0 Then nodoTotales.SetAttribute("TotalRetencionesIEPS", totales.TotalRetencionesIEPS.ToString("F2"))
        If totales.TotalRetencionesISR > 0 Then nodoTotales.SetAttribute("TotalRetencionesISR", totales.TotalRetencionesISR.ToString("F2"))
        If totales.TotalRetencionesIVA > 0 Then nodoTotales.SetAttribute("TotalRetencionesIVA", totales.TotalRetencionesIVA.ToString("F2"))

        If PassData9 = "USD" Then
            'If totales.TotalTrasladosBaseIVA0 > 0 Then
            nodoTotales.SetAttribute("TotalTrasladosBaseIVA0", totales.TotalTrasladosBaseIVA0.ToString("F2"))
            'If totales.TotalTrasladosImpuestoIVA0 > 0 Then
            nodoTotales.SetAttribute("TotalTrasladosImpuestoIVA0", totales.TotalTrasladosImpuestoIVA0.ToString("F2"))
        Else
            If totales.TotalTrasladosBaseIVA0 > 0 Then nodoTotales.SetAttribute("TotalTrasladosBaseIVA0", totales.TotalTrasladosBaseIVA0.ToString("F2"))
            If totales.TotalTrasladosImpuestoIVA0 > 0 Then nodoTotales.SetAttribute("TotalTrasladosImpuestoIVA0", totales.TotalTrasladosImpuestoIVA0.ToString("F2"))
        End If


        If totales.TotalTrasladosBaseIVA16 > 0 Then nodoTotales.SetAttribute("TotalTrasladosBaseIVA16", totales.TotalTrasladosBaseIVA16.ToString("F2"))
        If totales.TotalTrasladosBaseIVA8 > 0 Then nodoTotales.SetAttribute("TotalTrasladosBaseIVA8", totales.TotalTrasladosBaseIVA8.ToString("F2"))
        If totales.TotalTrasladosBaseIVAExento > 0 Then nodoTotales.SetAttribute("TotalTrasladosBaseIVAExento", totales.TotalTrasladosBaseIVAExento.ToString("F2"))
        If totales.TotalTrasladosImpuestoIVA16 > 0 Then nodoTotales.SetAttribute("TotalTrasladosImpuestoIVA16", totales.TotalTrasladosImpuestoIVA16.ToString("F2"))
        If totales.TotalTrasladosImpuestoIVA8 > 0 Then nodoTotales.SetAttribute("TotalTrasladosImpuestoIVA8", totales.TotalTrasladosImpuestoIVA8.ToString("F2"))
        Return nodoTotales
    End Function

    Private Shared Function ObtenerNodoPDoctoRelacionado(ByVal dr As PDoctoRelacionado, ByVal documento As XmlDocument) As XmlElement
        If dr Is Nothing Then Return Nothing
        Dim nodoPDoctoRelacionado As XmlElement = documento.CreateElement("pago20", "DoctoRelacionado", NAMESPACE_PAGOS)

        nodoPDoctoRelacionado.SetAttribute("IdDocumento", dr.IdDocumento)
        If dr.Serie <> String.Empty Then nodoPDoctoRelacionado.SetAttribute("Serie", dr.Serie)
        If dr.Folio <> String.Empty Then nodoPDoctoRelacionado.SetAttribute("Folio", dr.Folio)
        nodoPDoctoRelacionado.SetAttribute("MonedaDR", dr.MonedaDR)
        If dr.EquivalenciaDR > 0 Then nodoPDoctoRelacionado.SetAttribute("EquivalenciaDR", dr.EquivalenciaDR.ToString("F6"))
        If dr.NumParcialidad <> String.Empty Then nodoPDoctoRelacionado.SetAttribute("NumParcialidad", dr.NumParcialidad)

        nodoPDoctoRelacionado.SetAttribute("ImpSaldoAnt", dr.ImpSaldoAnt.ToString("F2"))
        'If dr.ImpSaldoAnt > 0 Then 

        If dr.ImpPagado > 0 Then nodoPDoctoRelacionado.SetAttribute("ImpPagado", dr.ImpPagado.ToString("F2"))

        'If dr.ImpSaldoInsoluto > 0 OrElse dr.ImpSaldoInsoluto = 0 Then
        nodoPDoctoRelacionado.SetAttribute("ImpSaldoInsoluto", dr.ImpSaldoInsoluto.ToString("F2"))

        If Not String.IsNullOrEmpty(dr.ObjetoImpDR) Then nodoPDoctoRelacionado.SetAttribute("ObjetoImpDR", dr.ObjetoImpDR)
        Dim impuestosDR As XmlElement = ObtenerNodoImpuestosDR(dr.ImpuestosDR, documento)
        If impuestosDR IsNot Nothing Then nodoPDoctoRelacionado.AppendChild(impuestosDR)

        Return nodoPDoctoRelacionado
    End Function

    Private Shared Function ObtenerNodoImpuestosDR(ByVal impuestosDR As ImpuestosDR, ByVal documento As XmlDocument) As XmlElement
        If impuestosDR Is Nothing Then Return Nothing
        Dim nodoPImpuestosDR As XmlElement = documento.CreateElement("pago20", "ImpuestosDR", NAMESPACE_PAGOS)

        If impuestosDR.RetencionesDR IsNot Nothing Then
            Dim nodoPRetenciones As XmlElement = documento.CreateElement("pago20", "RetencionesDR", NAMESPACE_PAGOS)

            For Each retencion As RetencionDR In impuestosDR.RetencionesDR.RetencionDR
                Dim nodoPRetencion As XmlElement = documento.CreateElement("pago20", "RetencionDR", NAMESPACE_PAGOS)
                nodoPRetencion.SetAttribute("BaseDR", retencion.BaseDR.ToString("F2"))
                nodoPRetencion.SetAttribute("ImpuestoDR", retencion.ImpuestoDR)
                nodoPRetencion.SetAttribute("TipoFactorDR", retencion.TipoFactorDR)
                nodoPRetencion.SetAttribute("TasaOCuotaDR", retencion.TasaOCuotaDR.ToString("F6"))
                nodoPRetencion.SetAttribute("ImporteDR", retencion.ImporteDR.ToString("F6"))
                nodoPRetenciones.AppendChild(nodoPRetencion)
            Next

            nodoPImpuestosDR.AppendChild(nodoPRetenciones)
        End If

        If impuestosDR.TrasladosDR IsNot Nothing Then
            Dim nodoPTraslados As XmlElement = documento.CreateElement("pago20", "TrasladosDR", NAMESPACE_PAGOS)

            For Each traslado As TrasladoDR In impuestosDR.TrasladosDR.TrasladoDR
                Dim nodoPTraslado As XmlElement = documento.CreateElement("pago20", "TrasladoDR", NAMESPACE_PAGOS)
                nodoPTraslado.SetAttribute("BaseDR", traslado.BaseDR.ToString("F2"))
                nodoPTraslado.SetAttribute("ImpuestoDR", traslado.ImpuestoDR)
                nodoPTraslado.SetAttribute("TipoFactorDR", traslado.TipoFactorDR)
                nodoPTraslado.SetAttribute("TasaOCuotaDR", traslado.TasaOCuotaDR.ToString("F6"))
                nodoPTraslado.SetAttribute("ImporteDR", traslado.ImporteDR.ToString("F6"))
                nodoPTraslados.AppendChild(nodoPTraslado)
            Next

            nodoPImpuestosDR.AppendChild(nodoPTraslados)
        End If

        Return nodoPImpuestosDR
    End Function

    Private Shared Function ObtenerNodoImpuestosP(ByVal impuestosP As ImpuestosP, ByVal documento As XmlDocument) As XmlElement
        If impuestosP Is Nothing Then Return Nothing
        Dim nodoPImpuestos As XmlElement = documento.CreateElement("pago20", "ImpuestosP", NAMESPACE_PAGOS)

        If impuestosP.RetencionesP IsNot Nothing Then
            Dim nodoPRetenciones As XmlElement = documento.CreateElement("pago20", "RetencionesP", NAMESPACE_PAGOS)

            For Each retencion As RetencionP In impuestosP.RetencionesP.RetencionP
                Dim nodoPRetencion As XmlElement = documento.CreateElement("pago20", "RetencionP", NAMESPACE_PAGOS)
                nodoPRetencion.SetAttribute("ImpuestoP", retencion.ImpuestoP)
                nodoPRetencion.SetAttribute("ImporteP", retencion.ImporteP.ToString("F2"))
                nodoPRetenciones.AppendChild(nodoPRetencion)
            Next

            nodoPImpuestos.AppendChild(nodoPRetenciones)
        End If
        'AQU SE CAMBIO NAMESPACE_CFD X NAMESPACE_PAGOS
        If impuestosP.TrasladosP IsNot Nothing Then
            Dim nodoPTraslados As XmlElement = documento.CreateElement("pago20", "TrasladosP", NAMESPACE_PAGOS)

            For Each traslado As TrasladoP In impuestosP.TrasladosP.TrasladoP
                Dim nodoPTraslado As XmlElement = documento.CreateElement("pago20", "TrasladoP", NAMESPACE_PAGOS)
                nodoPTraslado.SetAttribute("BaseP", traslado.BaseP.ToString("F2"))
                nodoPTraslado.SetAttribute("ImpuestoP", traslado.ImpuestoP)
                nodoPTraslado.SetAttribute("TipoFactorP", traslado.TipoFactorP)
                nodoPTraslado.SetAttribute("TasaOCuotaP", traslado.TasaOCuotaP.ToString("F6"))
                nodoPTraslado.SetAttribute("ImporteP", traslado.ImporteP.ToString("F2"))
                nodoPTraslados.AppendChild(nodoPTraslado)
            Next

            nodoPImpuestos.AppendChild(nodoPTraslados)
        End If

        Return nodoPImpuestos
    End Function
#End Region
#Region "Impuestos locales 1.0"
    Private Shared Function ObtenerNodoRetencionesLocales(ByVal retenlocal As List(Of RetencionesLocales), ByVal documento As XmlDocument) As XmlElement
        If retenlocal Is Nothing AndAlso retenlocal.Count() = 0 Then Return Nothing
        Dim nodoRetenLocales As XmlElement = documento.CreateElement("implocal", "RetencionesLocales", NAMESPACE_IMPUESTOLOCAL)

        For Each rl As RetencionesLocales In retenlocal
            nodoRetenLocales.SetAttribute("ImpLocRetenido", rl.ImpLocRetenido)
            nodoRetenLocales.SetAttribute("TasadeRetencion", rl.TasadeRetencion.ToString("F2"))
            nodoRetenLocales.SetAttribute("Importe", rl.Importe.ToString("F2"))
        Next

        Return nodoRetenLocales
    End Function

    Private Shared Function ObtenerNodoTrasladosLocales(ByVal traslocal As List(Of TrasladosLocales), ByVal documento As XmlDocument) As XmlElement
        If traslocal Is Nothing AndAlso traslocal.Count() = 0 Then Return Nothing
        Dim nodoTrasLocales As XmlElement = documento.CreateElement("implocal", "TrasladosLocales", NAMESPACE_IMPUESTOLOCAL)

        For Each tl As TrasladosLocales In traslocal
            nodoTrasLocales.SetAttribute("ImpLocTrasladado ", tl.ImpLocTraslado)
            nodoTrasLocales.SetAttribute("TasadeTraslado", tl.TasaTraslado.ToString("F2"))
            nodoTrasLocales.SetAttribute("Importe", tl.Importe.ToString("F2"))
        Next

        Return nodoTrasLocales
    End Function
#End Region
#Region "Ingresos hidrocarburos"
    Private Shared Function AgregarNodoIngresosHidrocarburos(ByVal ingresosHidro As IngresosHidrocarburos, ByVal documento As XmlDocument) As XmlElement
        If ingresosHidro Is Nothing Then Return Nothing
        Dim NodoIngresosHidro As XmlElement = documento.CreateElement("ieeh", "IngresosHidrocarburos", NAMESPACE_HINGRESOSHIDROCARBUROS)
        NodoIngresosHidro.SetAttribute("Version", ingresosHidro.Version)
        NodoIngresosHidro.SetAttribute("NumeroContrato", ingresosHidro.NumeroContrato)
        NodoIngresosHidro.SetAttribute("ContraprestacionPagadaOperador", ingresosHidro.ContraPrestacionPagadaOperador.ToString("F2"))
        NodoIngresosHidro.SetAttribute("Porcentaje", ingresosHidro.Porcentaje.ToString("F3"))
        Dim ihDocumentoRelacionado As XmlElement = ObtenerNodoIHDocumentoRelacionado(ingresosHidro.DocumentoRelacionado, documento)
        If ihDocumentoRelacionado IsNot Nothing Then NodoIngresosHidro.AppendChild(ihDocumentoRelacionado)
        Dim schemalocation As XmlAttribute = documento.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
        schemalocation.Value = SCHEMALOCATION_INGRESOSHIDROCARBUROS
        NodoIngresosHidro.SetAttributeNode(schemalocation)
        Return NodoIngresosHidro
    End Function

    Private Shared Function ObtenerNodoIHDocumentoRelacionado(ByVal ihDoctoRela As List(Of IHDocumentoRelacionado), ByVal documento As XmlDocument) As XmlElement
        If ihDoctoRela Is Nothing AndAlso ihDoctoRela.Count() = 0 Then Return Nothing
        Dim nodoihDoctoRelacionado As XmlElement = documento.CreateElement("ieeh", "DocumentoRelacionado", NAMESPACE_HINGRESOSHIDROCARBUROS)

        For Each dr As IHDocumentoRelacionado In ihDoctoRela
            nodoihDoctoRelacionado.SetAttribute("FolioFiscalVinculado", dr.FolioFiscalVinculado)
            nodoihDoctoRelacionado.SetAttribute("FechaFolioFiscalVinculado", dr.FechaFolioFiscalVinculado)
            nodoihDoctoRelacionado.SetAttribute("Mes", dr.Mes)
        Next

        Return nodoihDoctoRelacionado
    End Function
#End Region
#Region "Gastos hidrocarburos"
    Private Shared Function AgregarNodoGastosHidrocarburos(ByVal gastosHidro As GastosHidrocarburos, ByVal documento As XmlDocument) As XmlElement
        If gastosHidro Is Nothing Then Return Nothing
        Dim nodoGastosHidro As XmlElement = documento.CreateElement("gceh", "GastosHidrocarburos", NAMESPACE_GASTOSHIDROCARBUROS)
        nodoGastosHidro.SetAttribute("Version", gastosHidro.Version)
        nodoGastosHidro.SetAttribute("NumeroContrato", gastosHidro.NumeroContrato)
        nodoGastosHidro.SetAttribute("AreaContractual", gastosHidro.AreaContractual)
        Dim erogacion As XmlElement = ObtenerNodoErogacion(gastosHidro.Erogacion, documento)
        If nodoGastosHidro IsNot Nothing Then nodoGastosHidro.AppendChild(erogacion)
        Dim schemalocation As XmlAttribute = documento.CreateAttribute("xsi", "schemaLocation", "http://www.w3.org/2001/XMLSchema-instance")
        schemalocation.Value = SCHEMALOCATION_GASTOSHIDROCARBUROS
        nodoGastosHidro.SetAttributeNode(schemalocation)
        Return nodoGastosHidro
    End Function

    Private Shared Function ObtenerNodoErogacion(ByVal erogacion As List(Of Erogacion), ByVal documento As XmlDocument) As XmlElement
        If erogacion Is Nothing AndAlso erogacion.Count() = 0 Then Return Nothing
        Dim nodoErogacion As XmlElement = documento.CreateElement("gceh", "Erocion", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each e As Erogacion In erogacion
            nodoErogacion.SetAttribute("TipoErogacion", e.TipoErogacion)
            nodoErogacion.SetAttribute("MontocuErogacion", e.MontocuErogacion.ToString("F2"))
            nodoErogacion.SetAttribute("Porcentaje", e.Porcentaje.ToString("F2"))
            Dim documentoRelacionado As XmlElement = AgregarNodoEDocumentoRelacionado(e.DocumentoRelacionado, documento)
            If nodoErogacion IsNot Nothing Then nodoErogacion.AppendChild(documentoRelacionado)
            Dim actividades As XmlElement = AgegarNodoActividades(e.Actividades, documento)
            If nodoErogacion IsNot Nothing Then nodoErogacion.AppendChild(actividades)
            Dim centroCostos As XmlElement = AgregarNodoCentroCostos(e.CentroCostos, documento)
            If nodoErogacion IsNot Nothing Then nodoErogacion.AppendChild(centroCostos)
        Next

        Return nodoErogacion
    End Function

    Private Shared Function AgregarNodoEDocumentoRelacionado(ByVal documentoRelacionado As List(Of EDocumentoRelacionado), ByVal documento As XmlDocument) As XmlElement
        If documentoRelacionado Is Nothing AndAlso documentoRelacionado.Count() = 0 Then Return Nothing
        Dim nodoDocRelacionado As XmlElement = documento.CreateElement("gceh", "DocumentoRelacionado")

        For Each edr As EDocumentoRelacionado In documentoRelacionado
            nodoDocRelacionado.SetAttribute("OrigenErogacion ", edr.OrigenErogacion)
            If edr.FolioFiscalVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("FolioFiscalVinculado", edr.FolioFiscalVinculado)
            If edr.RFCProveedor <> String.Empty Then nodoDocRelacionado.SetAttribute("RFCProveedor", edr.RFCProveedor)
            If edr.MontoTotalIVA > 0 Then nodoDocRelacionado.SetAttribute("MontoTotalIVA", edr.MontoTotalIVA.ToString("F2"))
            If edr.MontoRetencionOtrosImpuestos > 0 Then nodoDocRelacionado.SetAttribute("MontoRetencionOtrosImpuestos ", edr.MontoRetencionOtrosImpuestos.ToString("F2"))
            If edr.NumeroPedimentoVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("NumeroPedimentoVinculado", edr.NumeroPedimentoVinculado)
            If edr.ClavePedimentoVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("ClavePedimentoVinculado ", edr.ClavePedimentoVinculado)
            If edr.ClavePagoPedimentoVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("ClavePagoPedimentoVinculado ", edr.ClavePagoPedimentoVinculado)
            If edr.MontoIVAPedimento > 0 Then nodoDocRelacionado.SetAttribute("MontoIVAPedimento", edr.MontoIVAPedimento.ToString("F2"))
            If edr.MontoRetencionISR > 0 Then nodoDocRelacionado.SetAttribute("MontoRetencionIVA", edr.MontoRetencionIVA.ToString("F2"))
            If edr.MontoRetencionIVA > 0 Then nodoDocRelacionado.SetAttribute("MontoRetencionIVA ", edr.MontoRetencionIVA.ToString("F2"))
            If edr.MontoRetencionOtrosImpuestos > 0 Then nodoDocRelacionado.SetAttribute("MontoRetencionOtrosImpuestos", edr.MontoRetencionOtrosImpuestos.ToString("F2"))
            If edr.NumeroPedimentoVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("NumeroPedimentoVinculado", edr.NumeroPedimentoVinculado)
            If edr.ClavePagoPedimentoVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("ClavePagoPedimentoVinculado ", edr.ClavePagoPedimentoVinculado)
            If edr.MontoIVAPedimento > 0 Then nodoDocRelacionado.SetAttribute("MontoIVAPedimento", edr.MontoIVAPedimento.ToString("F2"))
            If edr.OtrosImpuestosPagadosPedimento > 0 Then nodoDocRelacionado.SetAttribute("OtrosImpuestosPagadosPedimento", edr.OtrosImpuestosPagadosPedimento.ToString("F2"))
            If edr.FechaFolioFiscalVinculado <> String.Empty Then nodoDocRelacionado.SetAttribute("FechaFolioFiscalVinculado", edr.FechaFolioFiscalVinculado)
            If edr.Mes <> String.Empty Then nodoDocRelacionado.SetAttribute("Mes", edr.Mes)
            If edr.MontoTotalErogaciones > 0 Then nodoDocRelacionado.SetAttribute("MontoTotalErogaciones", edr.MontoTotalErogaciones.ToString("F2"))
        Next

        Return nodoDocRelacionado
    End Function

    Private Shared Function AgegarNodoActividades(ByVal actividades As List(Of Actividades), ByVal documento As XmlDocument) As XmlElement
        If actividades Is Nothing AndAlso actividades.Count() = 0 Then Return Nothing
        Dim nodoActividades As XmlElement = documento.CreateElement("gceh", "Actividades", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each a As Actividades In actividades
            nodoActividades.SetAttribute("ActividadRelacionada", a.ActividadRelacionada)
            Dim subActividades As XmlElement = ObtenerNodoSubActividades(a.SubActividades, documento)
            If nodoActividades IsNot Nothing Then nodoActividades.AppendChild(subActividades)
        Next

        Return nodoActividades
    End Function

    Private Shared Function ObtenerNodoSubActividades(ByVal subActividades As List(Of SubActividades), ByVal documento As XmlDocument) As XmlElement
        If subActividades Is Nothing AndAlso subActividades.Count() = 0 Then Return Nothing
        Dim nodoSubActividades As XmlElement = documento.CreateElement("gceh", "SubActividades", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each sa As SubActividades In subActividades
            nodoSubActividades.SetAttribute("SubActividadRelacionada", sa.SubActividadRelacionada)
            Dim tareas As XmlElement = ObtenerNodoTareas(sa.Tareas, documento)
            If nodoSubActividades IsNot Nothing Then nodoSubActividades.AppendChild(tareas)
        Next

        Return nodoSubActividades
    End Function

    Private Shared Function ObtenerNodoTareas(ByVal tareas As List(Of Tareas), ByVal documento As XmlDocument) As XmlElement
        If tareas Is Nothing AndAlso tareas.Count() = 0 Then Return Nothing
        Dim nodoTareas As XmlElement = documento.CreateElement("gceh", "Tareas", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each t As Tareas In tareas
            If t.TareaRelacionada <> String.Empty Then nodoTareas.SetAttribute("TareaRelacionada", t.TareaRelacionada)
        Next

        Return nodoTareas
    End Function

    Private Shared Function AgregarNodoCentroCostos(ByVal centroCostos As List(Of CentroCostos), ByVal documento As XmlDocument) As XmlElement
        If centroCostos Is Nothing AndAlso centroCostos.Count() = 0 Then Return Nothing
        Dim nodoCentroCos As XmlElement = documento.CreateElement("gceh", "CentroCostos", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each cc As CentroCostos In centroCostos
            If cc.Campo <> String.Empty Then nodoCentroCos.SetAttribute("Campo", cc.Campo)
            Dim yacimientos As XmlElement = ObtenerNodoYacimientos(cc.Yacimientos, documento)
            If nodoCentroCos IsNot Nothing Then nodoCentroCos.AppendChild(yacimientos)
        Next

        Return nodoCentroCos
    End Function

    Private Shared Function ObtenerNodoYacimientos(ByVal yacimientos As List(Of Yacimientos), ByVal documento As XmlDocument) As XmlElement
        If yacimientos Is Nothing AndAlso yacimientos.Count() = 0 Then Return Nothing
        Dim nodoYacimientos As XmlElement = documento.CreateElement("gceh", "Yacimientos", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each y As Yacimientos In yacimientos
            If y.Yacimiento <> String.Empty Then nodoYacimientos.SetAttribute("Yacimientos", y.Yacimiento)
            Dim pozos As XmlElement = ObtenerNodoPozos(y.Pozos, documento)
            If nodoYacimientos IsNot Nothing Then nodoYacimientos.AppendChild(pozos)
        Next

        Return nodoYacimientos
    End Function

    Private Shared Function ObtenerNodoPozos(ByVal pozos As List(Of Pozos), ByVal documento As XmlDocument) As XmlElement
        If pozos Is Nothing AndAlso pozos.Count() = 0 Then Return Nothing
        Dim nodoPozos As XmlElement = documento.CreateElement("gceh", "Pozos", NAMESPACE_GASTOSHIDROCARBUROS)

        For Each p As Pozos In pozos
            If p.Pozo <> String.Empty Then nodoPozos.SetAttribute("Pozo", p.Pozo)
        Next

        Return nodoPozos
    End Function
#End Region
#End Region
#Region "Otras Clases"

    Private Shared Sub ObtenerCertificadoYNoCertificado(ByVal rutaCertificado As String, ByRef Certificado As String, ByRef NoCertificado As String)
        Try
            Dim objCert As X509Certificate2 = New X509Certificate2()
            Dim bRawData As Byte() = ReadFile(rutaCertificado)
            objCert.Import(bRawData)
            Certificado = Convert.ToBase64String(bRawData)
            NoCertificado = FormatearSerieCert(objCert.SerialNumber)
        Catch
            Certificado = String.Empty
            NoCertificado = String.Empty
        End Try
    End Sub

    Public Shared Function ReadFile(ByVal strArchivo As String) As Byte()
        Dim f As FileStream = New FileStream(strArchivo, FileMode.Open, FileAccess.Read)
        Dim size As Integer = Convert.ToInt32(f.Length)
        Dim data As Byte() = New Byte(size - 1) {}
        size = f.Read(data, 0, size)
        f.Close()
        Return data
    End Function

    Private Shared Function FormatearSerieCert(ByVal Serie As String) As String
        Dim Resultado As String = ""
        Dim i As Integer

        For i = 1 To Serie.Length - 1 Step 2
            Resultado = Resultado & Serie.Substring(i, 1)
        Next

        Return Resultado
    End Function


    'Public Shared Function ObtenerSelloPorCertificado(ByVal xml As XmlDocument, ByVal rutaArchivoClavePrivada As String, ByVal lPassword As String) As String
    '    Dim ClavePrivada As Byte() = File.ReadAllBytes(rutaArchivoClavePrivada)
    '    Dim bytesFirmados As Byte() = Nothing
    '    Dim bCadenaOriginal As Byte() = Nothing
    '    Dim CadenaOriginal As String = GetCadenaOriginal(xml.InnerXml)
    '    Dim lSecStr As System.Security.SecureString = New System.Security.SecureString()
    '    Dim sham As SHA1Managed = New SHA1Managed()
    '    lSecStr.Clear()

    '    For Each c As Char In lPassword.ToCharArray()
    '        lSecStr.AppendChar(c)
    '    Next

    '    Dim lrsa As RSACryptoServiceProvider = opensslkey.DecodeEncryptedPrivateKeyInfo(ClavePrivada, lSecStr)
    '    bCadenaOriginal = Encoding.UTF8.GetBytes(CadenaOriginal)

    '    Try
    '        bytesFirmados = lrsa.SignData(Encoding.UTF8.GetBytes(CadenaOriginal), sham)
    '    Catch ex As NullReferenceException
    '        Throw New NullReferenceException("Clave privada incorrecta, revisa que la clave que escribes corresponde a los sellos digitales cargados")
    '    End Try

    '    Dim sellodigital As String = Convert.ToBase64String(bytesFirmados)
    '    Return sellodigital
    'End Function

    Public Shared Function GetCadenaOriginal(ByVal xmlCFD As String) As String

        Dim rutaXSLT As String = Application.StartupPath & "\XSLT\cadenaoriginal.xslt"
        Dim xslt As XslCompiledTransform = New XslCompiledTransform()
        Dim xmldoc As XmlDocument = New XmlDocument()
        Dim navigator As XPathNavigator
        Dim output As StringWriter = New StringWriter()
        xmldoc.LoadXml(xmlCFD)
        navigator = xmldoc.CreateNavigator()
        xslt.Load(rutaXSLT)
        xslt.Transform(navigator, Nothing, output)
        Return output.ToString()
    End Function
#End Region
End Class


