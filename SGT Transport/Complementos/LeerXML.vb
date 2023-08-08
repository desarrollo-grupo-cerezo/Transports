Imports System.Xml

Public Class LeerXML
#Region "Comprobante"
    Public Function ObtenerComprobante(ByVal rutaXML As String) As Comprobante
        Dim documento As XmlDocument = New XmlDocument()
        Dim comprobante As Comprobante = New Comprobante()
        documento.Load(rutaXML)
        documento.PreserveWhitespace = True
        ObtenerNodoComprobante(documento, comprobante)
        comprobante.InformacionGlobal = ObtenerNodoInformacionGlobal(documento)
        comprobante.CfdiRelacionados = ObtenerNodoCfdisRelacionados(documento)
        comprobante.Emisor = ObtenerNodoEmisor(documento)
        comprobante.Receptor = ObtenerNodoReceptor(documento)
        comprobante.Conceptos = ObtenerNodoConceptos(documento)
        comprobante.Impuestos = ObtenerNodoImpuestos(documento)

        comprobante.Complemento = ObtenerComplemento(documento)
        comprobante.Addenda = ObtenerNodoAdenda(documento)
        comprobante.AcuseCancelacion = ObtenerAcuseCancelacion(documento)
        comprobante.xml = documento.InnerXml
        Return comprobante
    End Function

    Private Sub ObtenerNodoComprobante(ByVal documento As XmlDocument, ByRef comprobante As Comprobante)
        Dim fecha As DateTime
        Dim valueFloat As Decimal
        comprobante = New Comprobante()
        Dim lComprobante As XmlNodeList = documento.GetElementsByTagName("cfdi:Comprobante")
        If lComprobante.Count = 0 Then Return
        Dim nComprobante As XmlElement = TryCast(lComprobante(0), XmlElement)
        If nComprobante.HasAttribute("Version") Then comprobante.Version = nComprobante.GetAttribute("Version")
        If nComprobante.HasAttribute("Serie") Then comprobante.Serie = nComprobante.GetAttribute("Serie")
        If nComprobante.HasAttribute("Folio") Then comprobante.Folio = nComprobante.GetAttribute("Folio")
        If nComprobante.HasAttribute("Fecha") Then comprobante.Fecha = If(DateTime.TryParse(nComprobante.GetAttribute("Fecha"), fecha), fecha, DateTime.Now)
        If nComprobante.HasAttribute("Sello") Then comprobante.Sello = nComprobante.GetAttribute("Sello")
        If nComprobante.HasAttribute("FormaPago") Then comprobante.FormaPago = nComprobante.GetAttribute("FormaPago")
        If nComprobante.HasAttribute("NoCertificado") Then comprobante.NoCertificado = nComprobante.GetAttribute("NoCertificado")
        If nComprobante.HasAttribute("Certificado") Then comprobante.Certificado = nComprobante.GetAttribute("Certificado")
        If nComprobante.HasAttribute("CondicionesDePago") Then comprobante.CondicionesDePago = nComprobante.GetAttribute("CondicionesDePago")
        If nComprobante.HasAttribute("SubTotal") Then comprobante.SubTotal = If(Decimal.TryParse(nComprobante.GetAttribute("SubTotal"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Descuento") Then comprobante.Descuento = If(Decimal.TryParse(nComprobante.GetAttribute("Descuento"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Moneda") Then comprobante.Moneda = nComprobante.GetAttribute("Moneda")
        If nComprobante.HasAttribute("TipoCambio") Then comprobante.TipoCambio = If(Decimal.TryParse(nComprobante.GetAttribute("TipoCambio"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("Total") Then comprobante.Total = If(Decimal.TryParse(nComprobante.GetAttribute("Total"), valueFloat), valueFloat, 0)
        If nComprobante.HasAttribute("TipoDeComprobante") Then comprobante.TipoDeComprobante = nComprobante.GetAttribute("TipoDeComprobante")
        If nComprobante.HasAttribute("Exportacion") Then comprobante.Exportacion = nComprobante.GetAttribute("Exportacion")
        If nComprobante.HasAttribute("MetodoPago") Then comprobante.MetodoPago = nComprobante.GetAttribute("MetodoPago")
        If nComprobante.HasAttribute("LugarExpedicion") Then comprobante.LugarExpedicion = nComprobante.GetAttribute("LugarExpedicion")
        If nComprobante.HasAttribute("Confirmacion") Then comprobante.Confirmacion = nComprobante.GetAttribute("Confirmacion")
    End Sub

    Private Function ObtenerNodoInformacionGlobal(ByVal documento As XmlDocument) As InformacionGlobal
        If documento.GetElementsByTagName("cfdi:InformacionGlobal") Is Nothing OrElse documento.GetElementsByTagName("cfdi:InformacionGlobal").Count = 0 Then Return Nothing
        Dim informacionGlobal As InformacionGlobal = New InformacionGlobal()
        Dim lInformacionGlobal As XmlNodeList = documento.GetElementsByTagName("cfdi:InformacionGlobal")
        Dim nInformacionGlobal As XmlElement = lInformacionGlobal(0)
        If (nInformacionGlobal.HasAttribute("Año")) Then informacionGlobal.Ano = nInformacionGlobal.GetAttribute("Año")
        If (nInformacionGlobal.HasAttribute("Meses")) Then informacionGlobal.Meses = nInformacionGlobal.GetAttribute("Meses")
        If (nInformacionGlobal.HasAttribute("Periodicidad")) Then informacionGlobal.Periodicidad = nInformacionGlobal.GetAttribute("Periodicidad")
        Return informacionGlobal
    End Function

    Private Function ObtenerNodoCfdisRelacionados(ByVal documento As XmlDocument) As CfdiRelacionados
        If documento.GetElementsByTagName("cfdi:CfdiRelacionados") Is Nothing OrElse documento.GetElementsByTagName("cfdi:CfdiRelacionados").Count = 0 Then Return Nothing
        Dim cfdiRelacionados As CfdiRelacionados = New CfdiRelacionados()
        Dim lCfdiRelacionados As XmlNodeList = documento.GetElementsByTagName("cfdi:CfdiRelacionados")
        If (CType(lCfdiRelacionados(0), XmlElement)).GetAttribute("TipoRelacion") IsNot Nothing Then cfdiRelacionados.TipoRelacion = (CType(lCfdiRelacionados(0), XmlElement)).GetAttribute("TipoRelacion")
        If (CType(lCfdiRelacionados(0), XmlElement)).GetElementsByTagName("cfdi:Relacionado") Is Nothing Then Return cfdiRelacionados
        Dim ListaCfdiRelacionados As XmlNodeList = (CType(lCfdiRelacionados(0), XmlElement)).GetElementsByTagName("cfdi:CfdiRelacionado")

        For Each nodo As XmlElement In ListaCfdiRelacionados
            Dim c As CfdiRelacionado = New CfdiRelacionado()
            If nodo.GetAttribute("UUID") IsNot Nothing Then c.UUID = nodo.GetAttribute("UUID")
            cfdiRelacionados.CfdiRelacionado.Add(c)
        Next

        Return cfdiRelacionados
    End Function

    Private Function ObtenerNodoEmisor(ByVal documento As XmlDocument) As Emisor
        Dim lEmisores As XmlNodeList = documento.GetElementsByTagName("cfdi:Emisor")
        If lEmisores.Count = 0 Then Return Nothing
        Dim nEmisor As XmlElement = TryCast(lEmisores(0), XmlElement)
        Dim emisor As Emisor = New Emisor()
        If nEmisor.HasAttribute("Rfc") Then emisor.Rfc = nEmisor.GetAttribute("Rfc")
        If nEmisor.HasAttribute("Nombre") Then emisor.Nombre = nEmisor.GetAttribute("Nombre")
        If nEmisor.HasAttribute("RegimenFiscal") Then emisor.RegimenFiscal = nEmisor.GetAttribute("RegimenFiscal")
        If nEmisor.HasAttribute("FacAtrAdquirente") Then emisor.FacAtrAdquirente = nEmisor.GetAttribute("FacAtrAdquirente")
        Return emisor
    End Function

    Private Function ObtenerAcuseCancelacion(ByVal documento As XmlDocument) As Acuse
        Dim fecha As DateTime
        Dim lCancelacion As XmlNodeList = documento.GetElementsByTagName("Acuse")
        If lCancelacion.Count = 0 Then Return Nothing
        Dim nCancelacion As XmlElement = TryCast(lCancelacion(0), XmlElement)
        Dim cancelacion As Acuse = New Acuse()
        cancelacion.RfcEmisor = nCancelacion.GetAttribute("RfcEmisor")
        cancelacion.Fecha = If(DateTime.TryParse(nCancelacion.GetAttribute("Fecha"), fecha), fecha, DateTime.Now)
        Dim lFolios As XmlNodeList = nCancelacion.GetElementsByTagName("Folios")

        If lFolios.Count > 0 Then
            cancelacion.Folios = New Folios()
            Dim nFolios As XmlElement = TryCast(lFolios(0), XmlElement)
            Dim nUUID As XmlElement = TryCast((nFolios.GetElementsByTagName("UUID"))(0), XmlElement)
            Dim nEstatusUUID As XmlElement = TryCast((nFolios.GetElementsByTagName("EstatusUUID"))(0), XmlElement)
            cancelacion.Folios.EstatusUUID = nEstatusUUID.InnerText
            cancelacion.Folios.UUID = nUUID.InnerText
        End If

        Return cancelacion
    End Function

    Private Function ObtenerNodoReceptor(ByVal documento As XmlDocument) As Receptor
        Dim lReceptor As XmlNodeList = documento.GetElementsByTagName("cfdi:Receptor")
        If lReceptor.Count = 0 Then Return Nothing
        Dim nReceptor As XmlElement = TryCast(lReceptor(0), XmlElement)
        Dim receptor As Receptor = New Receptor()
        If nReceptor.HasAttribute("Rfc") Then receptor.Rfc = nReceptor.GetAttribute("Rfc")
        If nReceptor.HasAttribute("Nombre") Then receptor.Nombre = nReceptor.GetAttribute("Nombre")
        If nReceptor.HasAttribute("DomicilioFiscalReceptor") Then receptor.DomicilioFiscalReceptor = nReceptor.GetAttribute("DomicilioFiscalReceptor")
        If nReceptor.HasAttribute("ResidenciaFiscal") Then receptor.ResidenciaFiscal = nReceptor.GetAttribute("ResidenciaFiscal")
        If nReceptor.HasAttribute("NumRegIdTrib") Then receptor.NumRegIdTrib = nReceptor.GetAttribute("NumRegIdTrib")
        If nReceptor.HasAttribute("RegimenFiscalReceptor") Then receptor.RegimenFiscalReceptor = nReceptor.GetAttribute("RegimenFiscalReceptor")
        If nReceptor.HasAttribute("UsoCFDI") Then receptor.UsoCFDI = nReceptor.GetAttribute("UsoCFDI")
        Return receptor
    End Function

    Private Function ObtenerNodoConceptos(ByVal documento As XmlDocument) As Conceptos
        Dim valDecimal As Decimal
        Dim lConceptos As XmlNodeList = documento.GetElementsByTagName("cfdi:Conceptos")
        If lConceptos.Count = 0 Then Return Nothing
        Dim conceptos As Conceptos = New Conceptos()
        conceptos.Concepto = New List(Of Concepto)()
        Dim nConceptos As XmlElement = TryCast(lConceptos(0), XmlElement)
        Dim lConcepto As XmlNodeList = nConceptos.GetElementsByTagName("cfdi:Concepto")

        For Each nConcepto As XmlElement In lConcepto
            Dim concepto As Concepto = New Concepto()
            If nConcepto.HasAttribute("ClaveProdServ") Then concepto.ClaveProdServ = nConcepto.GetAttribute("ClaveProdServ")
            If nConcepto.HasAttribute("NoIdentificacion") Then concepto.NoIdentificacion = nConcepto.GetAttribute("NoIdentificacion")
            If nConcepto.HasAttribute("Cantidad") Then concepto.Cantidad = If(Decimal.TryParse(nConcepto.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("ClaveUnidad") Then concepto.ClaveUnidad = nConcepto.GetAttribute("ClaveUnidad")
            If nConcepto.HasAttribute("Unidad") Then concepto.Unidad = nConcepto.GetAttribute("Unidad")
            If nConcepto.HasAttribute("Descripcion") Then concepto.Descripcion = nConcepto.GetAttribute("Descripcion")
            If nConcepto.HasAttribute("ValorUnitario") Then concepto.ValorUnitario = If(Decimal.TryParse(nConcepto.GetAttribute("ValorUnitario"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("Importe") Then concepto.Importe = If(Decimal.TryParse(nConcepto.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("Descuento") Then concepto.Descuento = If(Decimal.TryParse(nConcepto.GetAttribute("Descuento"), valDecimal), valDecimal, 0)
            If nConcepto.HasAttribute("ObjetoImp") Then concepto.ObjetoImp = nConcepto.GetAttribute("ObjetoImp")
            concepto.ACuentaTerceros = ObtenerAcuentaTercerosConcepto(nConcepto)
            concepto.Impuestos = ObtenerImpuestosConcepto(nConcepto)
            concepto.InformacionAduanera = ObtenerInformacionAduaneraConcepto(nConcepto)
            concepto.CuentaPredial = ObtenerCuentaPredialConcepto(nConcepto)
            concepto.Parte = ObtenerParteC(nConcepto)
            conceptos.Concepto.Add(concepto)
        Next

        Return conceptos
    End Function

    Private Function ObtenerImpuestosConcepto(ByVal nodoConcepto As XmlElement) As ImpuestosC
        Dim valDecimal As Decimal
        Dim lImpuestos As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:Impuestos")
        If lImpuestos.Count = 0 Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lImpuestos(0), XmlElement)
        Dim lTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Traslados")
        Dim impuestos As ImpuestosC = New ImpuestosC()

        If lTraslados.Count > 0 Then
            Dim traslados As List(Of TrasladoC) = New List(Of TrasladoC)()
            Dim nTraslados As XmlElement = TryCast(lTraslados(0), XmlElement)

            For Each nTraslado As XmlElement In nTraslados.GetElementsByTagName("cfdi:Traslado")
                Dim traslado As TrasladoC = New TrasladoC()
                If nTraslado.HasAttribute("Base") Then traslado.Base = If(Decimal.TryParse(nTraslado.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nTraslado.GetAttribute("Impuesto")
                If nTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nTraslado.GetAttribute("TipoFactor")
                If nTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                traslados.Add(traslado)
            Next

            impuestos.Traslados = traslados
        End If

        Dim lRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Retenciones")

        If lRetenciones.Count > 0 Then
            Dim retenciones As List(Of RetencionC) = New List(Of RetencionC)()
            Dim nRetenciones As XmlElement = TryCast(lRetenciones(0), XmlElement)

            For Each nRetencion As XmlElement In nRetenciones.GetElementsByTagName("cfdi:Retencion")
                Dim retencion As RetencionC = New RetencionC()
                If nRetencion.HasAttribute("Base") Then retencion.Base = If(Decimal.TryParse(nRetencion.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nRetencion.GetAttribute("Impuesto")
                If nRetencion.HasAttribute("TipoFactor") Then retencion.TipoFactor = nRetencion.GetAttribute("TipoFactor")
                If nRetencion.HasAttribute("TasaOCuota") Then retencion.TasaOCuota = If(Decimal.TryParse(nRetencion.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                retenciones.Add(retencion)
            Next

            impuestos.Retenciones = retenciones
        End If

        Return impuestos
    End Function

    Private Function ObtenerAcuentaTercerosConcepto(ByVal nodoConcepto As XmlElement) As ACuentaTercerosC
        Dim lACuentaTerceros As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:ACuentaTerceros")
        If lACuentaTerceros.Count = 0 Then Return Nothing
        Dim aCuentaTerceros As ACuentaTercerosC = New ACuentaTercerosC()
        Dim nInformacionAduanera As XmlElement = TryCast(lACuentaTerceros(0), XmlElement)
        If nInformacionAduanera.HasAttribute("RfcACuentaTerceros") Then aCuentaTerceros.RfcACuentaTerceros = nInformacionAduanera.GetAttribute("RfcACuentaTerceros")
        If nInformacionAduanera.HasAttribute("NombreACuentaTerceros") Then aCuentaTerceros.NombreACuentaTerceros = nInformacionAduanera.GetAttribute("NombreACuentaTerceros")
        If nInformacionAduanera.HasAttribute("RegimenFiscalACuentaTerceros") Then aCuentaTerceros.RegimenFiscalACuentaTerceros = nInformacionAduanera.GetAttribute("RegimenFiscalACuentaTerceros")
        If nInformacionAduanera.HasAttribute("DomicilioFiscalACuentaTerceros") Then aCuentaTerceros.DomicilioFiscalACuentaTerceros = nInformacionAduanera.GetAttribute("DomicilioFiscalACuentaTerceros")
        Return aCuentaTerceros
    End Function

    Private Function ObtenerInformacionAduaneraConcepto(ByVal nodoConcepto As XmlElement) As List(Of InformacionAduaneraC)
        Dim lInformacionAduanera As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:InformacionAduanera")
        If lInformacionAduanera.Count = 0 Then Return Nothing
        Dim lista As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
        Dim nInformacionAduanera As XmlElement = TryCast(lInformacionAduanera(0), XmlElement)

        For Each nInformacionA As XmlElement In lInformacionAduanera
            Dim informacionAduanera As InformacionAduaneraC = New InformacionAduaneraC()
            If nInformacionA.HasAttribute("NumeroPedimento") Then informacionAduanera.NumeroPedimento = nInformacionA.GetAttribute("NumeroPedimento")
            lista.Add(informacionAduanera)
        Next

        Return lista
    End Function

    Private Shared Function ObtenerCuentaPredialConcepto(ByVal nodoConcepto As XmlElement) As List(Of CuentaPredialC)
        Dim listaCuentaPredial As List(Of CuentaPredialC) = New List(Of CuentaPredialC)
        Dim lnCuentaPredial As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:CuentaPredial")
        If lnCuentaPredial.Count = 0 Then Return Nothing
        For Each nCuentaPredial As XmlElement In lnCuentaPredial
            Dim cuentaPredial As CuentaPredialC = New CuentaPredialC()
            If nCuentaPredial.HasAttribute("Numero") Then cuentaPredial.Numero = nCuentaPredial.GetAttribute("Numero")
            listaCuentaPredial.Add(cuentaPredial)
        Next
        'Dim nCuentaPredial As XmlElement = TryCast(lCuentaPredial(0), XmlElement)
        Return listaCuentaPredial
    End Function

    Private Function ObtenerParteC(ByVal nodoConcepto As XmlElement) As List(Of ParteC)
        Dim valDecimal As Decimal
        Dim lParte As XmlNodeList = nodoConcepto.GetElementsByTagName("cfdi:Parte")
        Dim lista As List(Of ParteC) = New List(Of ParteC)()
        For Each nParte As XmlElement In lParte
            Dim parte As ParteC = New ParteC()
            If nParte.HasAttribute("ClaveProdServ") Then parte.ClaveProdServ = nParte.GetAttribute("ClaveProdServ")
            If nParte.HasAttribute("NoIdentificacion") Then parte.NoIdentificacion = nParte.GetAttribute("NoIdentificacion")
            If nParte.HasAttribute("Cantidad") Then parte.Cantidad = If(Decimal.TryParse(nParte.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
            If nParte.HasAttribute("Unidad") Then parte.Unidad = nParte.GetAttribute("Unidad")
            If nParte.HasAttribute("Descripcion") Then parte.Descripcion = nParte.GetAttribute("Descripcion")
            If nParte.HasAttribute("ValorUnitario") Then parte.ValorUnitario = If(Decimal.TryParse(nParte.GetAttribute("ValorUnitario"), valDecimal), valDecimal, 0)
            If nParte.HasAttribute("Importe") Then parte.Importe = If(Decimal.TryParse(nParte.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            lista.Add(parte)
        Next

        Return lista
    End Function

    Private Function ObtenerNodoImpuestos(ByVal documento As XmlDocument) As Impuestos
        Dim valDecimal As Decimal
        Dim lImpuestos As XmlNodeList = documento.GetElementsByTagName("cfdi:Impuestos")
        If lImpuestos.Count = 0 Then Return Nothing
        Dim encontrado As Boolean = False
        Dim indice As Integer = 0

        For Each item As XmlElement In lImpuestos

            If item.ParentNode.Name = "cfdi:Comprobante" Then
                encontrado = True
                Exit For
            End If

            indice += 1
        Next

        If Not encontrado Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lImpuestos(indice), XmlElement)
        Dim impuestos As Impuestos = New Impuestos()
        If nImpuestos.HasAttribute("TotalImpuestosRetenidos") Then impuestos.TotalImpuestosRetenidos = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
        If nImpuestos.HasAttribute("TotalImpuestosTrasladados") Then impuestos.TotalImpuestosTrasladados = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosTrasladados"), valDecimal), valDecimal, 0)
        Dim lRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Retenciones")

        If lRetenciones.Count > 0 Then
            Dim retenciones As List(Of Retencion) = New List(Of Retencion)()
            Dim nRetenciones As XmlElement = TryCast(lRetenciones(0), XmlElement)

            For Each nRetencion As XmlElement In nRetenciones.GetElementsByTagName("cfdi:Retencion")
                Dim retencion As Retencion = New Retencion()
                If nRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nRetencion.GetAttribute("Impuesto")
                If nRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                retenciones.Add(retencion)
            Next

            impuestos.Retenciones = retenciones
        End If

        Dim lTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("cfdi:Traslados")

        If lTraslados.Count > 0 Then
            Dim traslados As List(Of Traslado) = New List(Of Traslado)()
            Dim nTraslados As XmlElement = TryCast(lTraslados(0), XmlElement)

            For Each nTraslado As XmlElement In nTraslados.GetElementsByTagName("cfdi:Traslado")
                Dim traslado As Traslado = New Traslado()
                If nTraslado.HasAttribute("Base") Then traslado.Base = If(Decimal.TryParse(nTraslado.GetAttribute("Base"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nTraslado.GetAttribute("Impuesto")
                If nTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nTraslado.GetAttribute("TipoFactor")
                If nTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
                If nTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
                traslados.Add(traslado)
            Next

            impuestos.Traslados = traslados
        End If

        Return impuestos
    End Function

    Private Function ObtenerComplemento(ByVal documento As XmlDocument) As Complemento
        Dim complemento As Complemento = New Complemento()
        Dim listaComplemento As XmlNodeList = documento.GetElementsByTagName("cfdi:Complemento")
        If listaComplemento.Count = 0 Then Return Nothing
        Dim nodoComplemento As XmlElement = TryCast(listaComplemento(0), XmlElement)
        'complemento.CartaPorte10 = Clasesfacturacion.CartaPorte10.Leer.ObtenerNodoComplementoCartaPorte(nodoComplemento)
        complemento.CartaPorte20 = ObtenerNodoComplementoCartaPorte20(nodoComplemento)
        complemento.TimbreFiscalDigital = ObtenerNodoComplementoTimbreFiscalDigital(nodoComplemento)
        complemento.Nomina = ObtenerNodoComplementoNomina(nodoComplemento)
        complemento.Pagos = ObtenerNodoPagos(documento)
        complemento.ComercioExterior = ObtenerNodoComplementoComercioExterior(documento)
        Return complemento
    End Function

    Private Function ObtenerNodoComplementoTimbreFiscalDigital(ByVal nodoComplemento As XmlElement) As TimbreFiscalDigital
        Dim fecha As DateTime
        Dim lTimbreFiscalDigital As XmlNodeList = nodoComplemento.GetElementsByTagName("tfd:TimbreFiscalDigital")
        If lTimbreFiscalDigital.Count = 0 Then Return Nothing
        Dim nTimbreFiscalDigital As XmlElement = TryCast(lTimbreFiscalDigital(0), XmlElement)
        Dim timbreFiscalDigital As TimbreFiscalDigital = New TimbreFiscalDigital()
        If nTimbreFiscalDigital.HasAttribute("Version") Then timbreFiscalDigital.Version = nTimbreFiscalDigital.GetAttribute("Version")
        If nTimbreFiscalDigital.HasAttribute("UUID") Then timbreFiscalDigital.UUID = nTimbreFiscalDigital.GetAttribute("UUID")
        If nTimbreFiscalDigital.HasAttribute("FechaTimbrado") Then timbreFiscalDigital.FechaTimbrado = If(DateTime.TryParse(nTimbreFiscalDigital.GetAttribute("FechaTimbrado"), fecha), fecha, DateTime.Now)
        If nTimbreFiscalDigital.HasAttribute("RfcProvCertif") Then timbreFiscalDigital.RfcProvCertif = nTimbreFiscalDigital.GetAttribute("RfcProvCertif")
        If nTimbreFiscalDigital.HasAttribute("Leyenda") Then timbreFiscalDigital.Leyenda = nTimbreFiscalDigital.GetAttribute("Leyenda")
        If nTimbreFiscalDigital.HasAttribute("SelloCFD") Then timbreFiscalDigital.SelloCFD = nTimbreFiscalDigital.GetAttribute("SelloCFD")
        If nTimbreFiscalDigital.HasAttribute("NoCertificadoSAT") Then timbreFiscalDigital.NoCertificadoSAT = nTimbreFiscalDigital.GetAttribute("NoCertificadoSAT")
        If nTimbreFiscalDigital.HasAttribute("SelloSAT") Then timbreFiscalDigital.SelloSAT = nTimbreFiscalDigital.GetAttribute("SelloSAT")
        Return timbreFiscalDigital
    End Function
#End Region
#Region "Complementos"
#Region "Comercio Exterior 11"

    Public Shared Function ObtenerNodoComplementoComercioExterior(ByVal documento As XmlDocument) As ComercioExterior
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim comercioExterior As ComercioExterior = New ComercioExterior()
        Dim listaCartaPorte As XmlNodeList = documento.GetElementsByTagName("cce11:ComercioExterior")
        If listaCartaPorte.Count = 0 Then Return Nothing
        Dim nodoComercioExterior As XmlElement = TryCast(listaCartaPorte(0), XmlElement)
        If nodoComercioExterior.HasAttribute("Version") Then comercioExterior.Version = nodoComercioExterior.GetAttribute("Version")
        If nodoComercioExterior.HasAttribute("MotivoTraslado") Then comercioExterior.MotivoTraslado = nodoComercioExterior.GetAttribute("MotivoTraslado")
        comercioExterior.TipoOperacion = nodoComercioExterior.GetAttribute("TipoOperacion")
        If nodoComercioExterior.HasAttribute("ClaveDePedimento") Then comercioExterior.ClaveDePedimento = nodoComercioExterior.GetAttribute("ClaveDePedimento")
        If nodoComercioExterior.HasAttribute("CertificadoOrigen") Then comercioExterior.CertificadoOrigen = If(Integer.TryParse(nodoComercioExterior.GetAttribute("CertificadoOrigen"), valInt), valInt, 0)
        If nodoComercioExterior.HasAttribute("NumCertificadoOrigen") Then comercioExterior.NumCertificadoOrigen = nodoComercioExterior.GetAttribute("NumCertificadoOrigen")
        If nodoComercioExterior.HasAttribute("NumeroExportadorConfiable") Then comercioExterior.NumeroExportadorConfiable = nodoComercioExterior.GetAttribute("NumeroExportadorConfiable")
        If nodoComercioExterior.HasAttribute("Incoterm") Then comercioExterior.Incoterm = nodoComercioExterior.GetAttribute("Incoterm")
        If nodoComercioExterior.HasAttribute("Subdivision") Then comercioExterior.Subdivision = If(Integer.TryParse(nodoComercioExterior.GetAttribute("Subdivision"), valInt), valInt, 0)
        If nodoComercioExterior.HasAttribute("Observaciones") Then comercioExterior.Observaciones = nodoComercioExterior.GetAttribute("Observaciones")
        If nodoComercioExterior.HasAttribute("TipoCambioUSD") Then comercioExterior.TipoCambioUSD = nodoComercioExterior.GetAttribute("TipoCambioUSD")
        If nodoComercioExterior.HasAttribute("TotalUSD") Then comercioExterior.TotalUSD = If(Decimal.TryParse(nodoComercioExterior.GetAttribute("TotalUSD"), valDecimal), valDecimal, 0)
        Return comercioExterior
    End Function

    Private Shared Function ObtenerNodoEmisor(ByVal nodoCartaPorte As XmlElement) As CCE11Emisor
        Dim emisor As CCE11Emisor = New CCE11Emisor()
        Dim listaEmisores As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cce11:Emisor")
        If listaEmisores.Count = 0 Then Return Nothing
        Dim nodoEmisor As XmlElement = TryCast(listaEmisores(0), XmlElement)
        If nodoEmisor.HasAttribute("Curp") Then emisor.Curp = nodoEmisor.GetAttribute("Curp")
        emisor.Domicilio = ObtenerNodoDomicilio(nodoEmisor)
        Return emisor
    End Function

    Private Shared Function ObtenerNodoDomicilio(ByVal nodoEmisor As XmlElement) As CCE11Domicilio
        Dim domicilio As CCE11Domicilio = New CCE11Domicilio()
        Dim listaDomicilios As XmlNodeList = nodoEmisor.GetElementsByTagName("cce11:Domicilio")
        If listaDomicilios.Count = 0 Then Return Nothing
        Dim nodoDomicilio As XmlElement = TryCast(listaDomicilios(0), XmlElement)
        If nodoDomicilio.HasAttribute("Calle") Then domicilio.Calle = nodoDomicilio.GetAttribute("Calle")
        If nodoDomicilio.HasAttribute("NumeroExterior") Then domicilio.NumeroExterior = nodoDomicilio.GetAttribute("NumeroExterior")
        If nodoDomicilio.HasAttribute("NumeroInterior") Then domicilio.NumeroInterior = nodoDomicilio.GetAttribute("NumeroInterior")
        If nodoDomicilio.HasAttribute("Colonia") Then domicilio.Colonia = nodoDomicilio.GetAttribute("Colonia")
        If nodoDomicilio.HasAttribute("Localidad") Then domicilio.Localidad = nodoDomicilio.GetAttribute("Localidad")
        If nodoDomicilio.HasAttribute("Referencia") Then domicilio.Referencia = nodoDomicilio.GetAttribute("Referencia")
        If nodoDomicilio.HasAttribute("Municipio") Then domicilio.Municipio = nodoDomicilio.GetAttribute("Municipio")
        If nodoDomicilio.HasAttribute("Estado") Then domicilio.Estado = nodoDomicilio.GetAttribute("Estado")
        If nodoDomicilio.HasAttribute("Pais") Then domicilio.Pais = nodoDomicilio.GetAttribute("Pais")
        If nodoDomicilio.HasAttribute("CodigoPostal") Then domicilio.CodigoPostal = nodoDomicilio.GetAttribute("CodigoPostal")
        Return domicilio
    End Function

    Private Shared Function ObtenerPropietario(ByVal nodoComercioExterior As XmlElement) As List(Of CCE11Propietario)
        Dim listaPropietario As List(Of CCE11Propietario) = New List(Of CCE11Propietario)()

        For Each item As XmlElement In nodoComercioExterior.GetElementsByTagName("cce11:Propietario")
            Dim propietario As CCE11Propietario = New CCE11Propietario()
            propietario.NumRegIdTrib = item.GetAttribute("NumRegIdTrib")
            propietario.ResidenciaFiscal = item.GetAttribute("ResidenciaFiscal")
            listaPropietario.Add(propietario)
        Next

        Return listaPropietario
    End Function

    Private Shared Function ObtenerNodoReceptor(ByVal nodoComercioExterior As XmlElement) As CCE11Receptor
        Dim receptor As CCE11Receptor = New CCE11Receptor()
        Dim listaReceptor As XmlNodeList = nodoComercioExterior.GetElementsByTagName("cce11:Receptor")
        If listaReceptor.Count = 0 Then Return Nothing
        Dim nodoReceptor As XmlElement = TryCast(listaReceptor(0), XmlElement)
        receptor.Domicilio = ObtenerNodoDomicilio(nodoReceptor)
        If nodoReceptor.HasAttribute("NumRegIdTrib") Then receptor.NumRegIdTrib = nodoReceptor.GetAttribute("NumRegIdTrib")
        Return receptor
    End Function

    Private Shared Function ObtenerDestinario(ByVal nodoComercioExterior As XmlElement) As List(Of CCE11Destinario)
        Dim listaDestinario As List(Of CCE11Destinario) = New List(Of CCE11Destinario)()

        For Each item As XmlElement In nodoComercioExterior.GetElementsByTagName("cce11:Destinario")
            Dim destinario As CCE11Destinario = New CCE11Destinario()
            If item.HasAttribute("NumRegIdTrib") Then destinario.NumRegIdTrib = item.GetAttribute("NumRegIdTrib")
            If item.HasAttribute("Nombre") Then destinario.Nombre = item.GetAttribute("Nombre")
            listaDestinario.Add(destinario)
        Next

        Return listaDestinario
    End Function

    Private Shared Function ObtenerNodoMercancias(ByVal nodoComercioExterior As XmlElement) As CCE11Mercancias
        Dim mercancias As CCE11Mercancias = New CCE11Mercancias()
        Dim listaMercancias As XmlNodeList = nodoComercioExterior.GetElementsByTagName("cce11:Mercancias")
        If listaMercancias.Count = 0 Then Return Nothing
        Dim nodoMercancias As XmlElement = TryCast(listaMercancias(0), XmlElement)
        mercancias.Mercancia = ObtenerMercancia(nodoMercancias)
        Return mercancias
    End Function

    Private Shared Function ObtenerMercancia(ByVal nodoMercancias As XmlElement) As List(Of CCE11Mercancia)
        Dim valDecimal As Decimal = 0D
        Dim listaMercancia As List(Of CCE11Mercancia) = New List(Of CCE11Mercancia)()

        For Each item As XmlElement In nodoMercancias.GetElementsByTagName("cce11:Mercancia")
            Dim mercancia As CCE11Mercancia = New CCE11Mercancia()
            mercancia.DescripcionesEspecificas = ObtenerNodoDescripcionesEspecificas(item)
            mercancia.NoIdentificacion = item.GetAttribute("NoIdentificacion")
            If item.HasAttribute("FraccionArancelaria") Then mercancia.FraccionArancelaria = item.GetAttribute("FraccionArancelaria")
            If item.HasAttribute("CantidadAduana") Then mercancia.CantidadAduana = If(Decimal.TryParse(item.GetAttribute("CantidadAduana"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("UnidadAduana") Then mercancia.UnidadAduana = item.GetAttribute("UnidadAduana")
            If item.HasAttribute("ValorUnitarioAduana") Then mercancia.ValorUnitarioAduana = If(Decimal.TryParse(item.GetAttribute("ValorUnitarioAduana"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("ValorDolares") Then mercancia.ValorDolares = If(Decimal.TryParse(item.GetAttribute("ValorDolares"), valDecimal), valDecimal, 0D)
            listaMercancia.Add(mercancia)
        Next

        Return listaMercancia
    End Function

    Private Shared Function ObtenerNodoDescripcionesEspecificas(ByVal nodoMercancia As XmlElement) As List(Of CCE11DescripcionesEspecificas)
        Dim listadescripcionesEspecificas As List(Of CCE11DescripcionesEspecificas) = New List(Of CCE11DescripcionesEspecificas)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cce11:DescripcionesEspecificas")
            Dim descripcionesEspecificas As CCE11DescripcionesEspecificas = New CCE11DescripcionesEspecificas()
            If item.HasAttribute("Marca") Then descripcionesEspecificas.Marca = item.GetAttribute("Marca")
            If item.HasAttribute("Modelo") Then descripcionesEspecificas.Modelo = item.GetAttribute("Modelo")
            If item.HasAttribute("SubModelo") Then descripcionesEspecificas.SubModelo = item.GetAttribute("SubModelo")
            If item.HasAttribute("NumeroSerie") Then descripcionesEspecificas.NumeroSerie = item.GetAttribute("NumeroSerie")
            listadescripcionesEspecificas.Add(descripcionesEspecificas)
        Next

        Return listadescripcionesEspecificas
    End Function

#End Region
#Region "Carta Porte 20"
    Public Shared Function ObtenerNodoComplementoCartaPorte20(ByVal documento As XmlElement) As CartaPorte
        Dim valDecimal As Decimal
        Dim cartaPorte As CartaPorte = New CartaPorte()
        Dim listaCartaPorte As XmlNodeList = documento.GetElementsByTagName("cartaporte20:CartaPorte")
        If listaCartaPorte.Count = 0 Then Return Nothing
        Dim nodoCartaPorte As XmlElement = TryCast(listaCartaPorte(0), XmlElement)
        If nodoCartaPorte.HasAttribute("Version") Then cartaPorte.Version = nodoCartaPorte.GetAttribute("Version")
        If cartaPorte.Version <> "2.0" Then Return Nothing
        cartaPorte.Ubicaciones = CP20ObtenerUbicaciones(nodoCartaPorte)
        cartaPorte.Mercancias = CP20ObtenerMercancias(nodoCartaPorte)
        cartaPorte.FiguraTransporte = CP20ObtenerFiguraTransporte(nodoCartaPorte)
        If nodoCartaPorte.HasAttribute("TranspInternac") Then cartaPorte.TranspInternac = nodoCartaPorte.GetAttribute("TranspInternac")
        If nodoCartaPorte.HasAttribute("EntradaSalidaMerc") Then cartaPorte.EntradaSalidaMerc = nodoCartaPorte.GetAttribute("EntradaSalidaMerc")
        If nodoCartaPorte.HasAttribute("PaisOrigenDestino") Then cartaPorte.PaisOrigenDestino = nodoCartaPorte.GetAttribute("PaisOrigenDestino")
        If nodoCartaPorte.HasAttribute("ViaEntradaSalida") Then cartaPorte.ViaEntradaSalida = nodoCartaPorte.GetAttribute("ViaEntradaSalida")
        If nodoCartaPorte.HasAttribute("TotalDistRec") Then cartaPorte.TotalDistRec = If(Decimal.TryParse(nodoCartaPorte.GetAttribute("TotalDistRec"), valDecimal), valDecimal, 0D)
        Return cartaPorte
    End Function

    Private Shared Function CP20ObtenerUbicaciones(ByVal nodoCartaPorte As XmlElement) As Ubicaciones
        Dim ubicaciones As Ubicaciones = New Ubicaciones()
        Dim listaUbicaciones As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:Ubicaciones")
        If listaUbicaciones.Count = 0 Then Return Nothing
        Dim nodoUbicaciones As XmlElement = TryCast(listaUbicaciones(0), XmlElement)
        ubicaciones.Ubicacion = CP20ObtenerUbicacion(nodoUbicaciones)
        Return ubicaciones
    End Function

    Private Shared Function CP20ObtenerUbicacion(ByVal nodoUbicaciones As XmlElement) As List(Of Ubicacion)
        Dim valDecimal As Decimal
        Dim valDateTime As DateTime
        Dim listaUbicacion As List(Of Ubicacion) = New List(Of Ubicacion)()

        For Each item As XmlElement In nodoUbicaciones.GetElementsByTagName("cartaporte20:Ubicacion")
            Dim ubicacion As Ubicacion = New Ubicacion()
            ubicacion.Domicilio = CP20ObtenerDomicilio(item)
            If item.HasAttribute("TipoUbicacion") Then ubicacion.TipoUbicacion = item.GetAttribute("TipoUbicacion")
            If item.HasAttribute("IDUbicacion") Then ubicacion.IDUbicacion = item.GetAttribute("IDUbicacion")
            If item.HasAttribute("RFCRemitenteDestinatario") Then ubicacion.RFCRemitenteDestinatario = item.GetAttribute("RFCRemitenteDestinatario")
            If item.HasAttribute("NombreRemitenteDestinatario") Then ubicacion.NombreRemitenteDestinatario = item.GetAttribute("NombreRemitenteDestinatario")
            If item.HasAttribute("NumRegIdTrib") Then ubicacion.NumRegIdTrib = item.GetAttribute("NumRegIdTrib")
            If item.HasAttribute("ResidenciaFiscal") Then ubicacion.ResidenciaFiscal = item.GetAttribute("ResidenciaFiscal")
            If item.HasAttribute("NumEstacion") Then ubicacion.NumEstacion = item.GetAttribute("NumEstacion")
            If item.HasAttribute("NombreEstacion") Then ubicacion.NombreEstacion = item.GetAttribute("NombreEstacion")
            If item.HasAttribute("NavegacionTrafico") Then ubicacion.NavegacionTrafico = item.GetAttribute("NavegacionTrafico")
            If item.HasAttribute("FechaHoraSalidaLlegada") Then ubicacion.FechaHoraSalidaLlegada = If(DateTime.TryParse(item.GetAttribute("FechaHoraSalidaLlegada"), valDateTime), valDateTime, DateTime.Now)
            If item.HasAttribute("TipoEstacion") Then ubicacion.TipoEstacion = item.GetAttribute("TipoEstacion")
            If item.HasAttribute("DistanciaRecorrida") Then ubicacion.DistanciaRecorrida = If(Decimal.TryParse(item.GetAttribute("DistanciaRecorrida"), valDecimal), valDecimal, 0D)
            listaUbicacion.Add(ubicacion)
        Next

        Return listaUbicacion
    End Function

    Private Shared Function CP20ObtenerDomicilio(ByVal nodoUbicacion As XmlElement) As Domicilio
        Dim domicilio As Domicilio = New Domicilio()
        Dim listaDomicilios As XmlNodeList = nodoUbicacion.GetElementsByTagName("cartaporte20:Domicilio")
        If listaDomicilios.Count = 0 Then Return Nothing
        Dim nodoDomicilio As XmlElement = TryCast(listaDomicilios(0), XmlElement)
        If nodoDomicilio.HasAttribute("Calle") Then domicilio.Calle = nodoDomicilio.GetAttribute("Calle")
        If nodoDomicilio.HasAttribute("NumeroExterior") Then domicilio.NumeroExterior = nodoDomicilio.GetAttribute("NumeroExterior")
        If nodoDomicilio.HasAttribute("NumeroInterior") Then domicilio.NumeroInterior = nodoDomicilio.GetAttribute("NumeroInterior")
        If nodoDomicilio.HasAttribute("Colonia") Then domicilio.Colonia = nodoDomicilio.GetAttribute("Colonia")
        If nodoDomicilio.HasAttribute("Localidad") Then domicilio.Localidad = nodoDomicilio.GetAttribute("Localidad")
        If nodoDomicilio.HasAttribute("Referencia") Then domicilio.Referencia = nodoDomicilio.GetAttribute("Referencia")
        If nodoDomicilio.HasAttribute("Municipio") Then domicilio.Municipio = nodoDomicilio.GetAttribute("Municipio")
        If nodoDomicilio.HasAttribute("Estado") Then domicilio.Estado = nodoDomicilio.GetAttribute("Estado")
        If nodoDomicilio.HasAttribute("Pais") Then domicilio.Pais = nodoDomicilio.GetAttribute("Pais")
        If nodoDomicilio.HasAttribute("CodigoPostal") Then domicilio.CodigoPostal = nodoDomicilio.GetAttribute("CodigoPostal")
        Return domicilio
    End Function

    Private Shared Function CP20ObtenerMercancias(ByVal nodoCartaPorte As XmlElement) As Mercancias
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim mercancias As Mercancias = New Mercancias()
        Dim listaMercancias As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:Mercancias")
        If listaMercancias.Count = 0 Then Return Nothing
        Dim nodoMercancias As XmlElement = TryCast(listaMercancias(0), XmlElement)
        mercancias.Mercancia = CP20ObtenerMercancia(nodoMercancias)
        mercancias.Autotransporte = CP20ObtenerAutoTransporte(nodoMercancias)
        mercancias.TransporteMaritimo = CP20ObtenerTransporteMaritimo(nodoMercancias)
        mercancias.TransporteAereo = CP20ObtenerTransporteAereo(nodoMercancias)
        mercancias.TransporteFerroviario = CP20ObtenerTransporteFerroviario(nodoMercancias)
        If nodoMercancias.HasAttribute("PesoBrutoTotal") Then mercancias.PesoBrutoTotal = If(Decimal.TryParse(nodoMercancias.GetAttribute("PesoBrutoTotal"), valDecimal), valDecimal, 0D)
        If nodoMercancias.HasAttribute("UnidadPeso") Then mercancias.UnidadPeso = nodoMercancias.GetAttribute("UnidadPeso")
        If nodoMercancias.HasAttribute("PesoNetoTotal") Then mercancias.PesoNetoTotal = If(Decimal.TryParse(nodoMercancias.GetAttribute("PesoNetoTotal"), valDecimal), valDecimal, 0D)
        If nodoMercancias.HasAttribute("NumTotalMercancias") Then mercancias.NumTotalMercancias = If(Integer.TryParse(nodoMercancias.GetAttribute("NumTotalMercancias"), valInt), valInt, 0)
        If nodoMercancias.HasAttribute("CargoPorTasacion") Then mercancias.CargoPorTasacion = If(Decimal.TryParse(nodoMercancias.GetAttribute("CargoPorTasacion"), valDecimal), valDecimal, 0D)
        Return mercancias
    End Function

    Private Shared Function CP20ObtenerMercancia(ByVal nodoMercancias As XmlElement) As List(Of Mercancia)
        Dim valDecimal As Decimal
        Dim listaMercancia As List(Of Mercancia) = New List(Of Mercancia)()

        For Each item As XmlElement In nodoMercancias.GetElementsByTagName("cartaporte20:Mercancia")
            Dim mercancia As Mercancia = New Mercancia()
            mercancia.Pedimentos = CP20ObtenerPedimentos(item)
            mercancia.GuiasIdentificacion = CP20ObtenerGuiasIdentificacion(item)
            mercancia.CantidadTransporta = CP20ObtenerCantidadTransporta(item)
            mercancia.DetalleMercancia = CP20ObtenerDetalleMercancia(item)
            If item.HasAttribute("BienesTransp") Then mercancia.BienesTransp = item.GetAttribute("BienesTransp")
            If item.HasAttribute("ClaveSTCC") Then mercancia.ClaveSTCC = item.GetAttribute("ClaveSTCC")
            If item.HasAttribute("Descripcion") Then mercancia.Descripcion = item.GetAttribute("Descripcion")
            If item.HasAttribute("Cantidad") Then mercancia.Cantidad = If(Decimal.TryParse(item.GetAttribute("Cantidad"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("ClaveUnidad") Then mercancia.ClaveUnidad = item.GetAttribute("ClaveUnidad")
            If item.HasAttribute("Unidad") Then mercancia.Unidad = item.GetAttribute("Unidad")
            If item.HasAttribute("Dimensiones") Then mercancia.Dimensiones = item.GetAttribute("Dimensiones")
            If item.HasAttribute("MaterialPeligroso") Then mercancia.MaterialPeligroso = item.GetAttribute("MaterialPeligroso")
            If item.HasAttribute("CveMaterialPeligroso") Then mercancia.CveMaterialPeligroso = item.GetAttribute("CveMaterialPeligroso")
            If item.HasAttribute("Embalaje") Then mercancia.Embalaje = item.GetAttribute("Embalaje")
            If item.HasAttribute("DescripEmbalaje") Then mercancia.DescripEmbalaje = item.GetAttribute("DescripEmbalaje")
            If item.HasAttribute("PesoEnKg") Then mercancia.PesoEnKg = If(Decimal.TryParse(item.GetAttribute("PesoEnKg"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("ValorMercancia") Then mercancia.ValorMercancia = If(Decimal.TryParse(item.GetAttribute("ValorMercancia"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("Moneda") Then mercancia.Moneda = item.GetAttribute("Moneda")
            If item.HasAttribute("FraccionArancelaria") Then mercancia.FraccionArancelaria = item.GetAttribute("FraccionArancelaria")
            If item.HasAttribute("UUIDComercioExt") Then mercancia.UUIDComercioExt = item.GetAttribute("UUIDComercioExt")
            listaMercancia.Add(mercancia)
        Next

        Return listaMercancia
    End Function

    Private Shared Function CP20ObtenerPedimentos(ByVal nodoMercancia As XmlElement) As List(Of Pedimentos)
        Dim listaPedimentos As List(Of Pedimentos) = New List(Of Pedimentos)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:Pedimentos")
            Dim pedimentos As Pedimentos = New Pedimentos()
            If item.HasAttribute("Pedimentos") Then pedimentos.Pedimento = item.GetAttribute("Pedimentos")
            listaPedimentos.Add(pedimentos)
        Next

        Return listaPedimentos
    End Function

    Private Shared Function CP20ObtenerGuiasIdentificacion(ByVal nodoMercancia As XmlElement) As List(Of GuiasIdentificacion)
        Dim valDecimal As Decimal
        Dim listaGuiasIdentificacion As List(Of GuiasIdentificacion) = New List(Of GuiasIdentificacion)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:GuiasIdentificacion")
            Dim guiasIdentificacion As GuiasIdentificacion = New GuiasIdentificacion()
            If item.HasAttribute("DescripGuiaIdentificacion") Then guiasIdentificacion.DescripGuiaIdentificacion = item.GetAttribute("DescripGuiaIdentificacion")
            If item.HasAttribute("NumeroGuiaIdentificacion") Then guiasIdentificacion.NumeroGuiaIdentificacion = item.GetAttribute("NumeroGuiaIdentificacion")
            If item.HasAttribute("PesoGuiaIdentificacion") Then guiasIdentificacion.PesoGuiaIdentificacion = If(Decimal.TryParse(item.GetAttribute("PesoGuiaIdentificacion"), valDecimal), valDecimal, 0D)
            listaGuiasIdentificacion.Add(guiasIdentificacion)
        Next

        Return listaGuiasIdentificacion
    End Function

    Private Shared Function CP20ObtenerCantidadTransporta(ByVal nodoMercancia As XmlElement) As List(Of CantidadTransporta)
        Dim valDecimal As Decimal
        Dim listaCantidadTransporta As List(Of CantidadTransporta) = New List(Of CantidadTransporta)()

        For Each item As XmlElement In nodoMercancia.GetElementsByTagName("cartaporte20:CantidadTransporta")
            Dim cantidadTransporta As CantidadTransporta = New CantidadTransporta()
            If item.HasAttribute("Cantidad") Then cantidadTransporta.Cantidad = If(Decimal.TryParse(item.GetAttribute("Cantidad"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("IDOrigen") Then cantidadTransporta.IDOrigen = item.GetAttribute("IDOrigen")
            If item.HasAttribute("IDDestino") Then cantidadTransporta.IDDestino = item.GetAttribute("IDDestino")
            If item.HasAttribute("CvesTransporte") Then cantidadTransporta.CvesTransporte = item.GetAttribute("CvesTransporte")
            listaCantidadTransporta.Add(cantidadTransporta)
        Next

        Return listaCantidadTransporta
    End Function

    Private Shared Function CP20ObtenerDetalleMercancia(ByVal nodoMercancia As XmlElement) As DetalleMercancia
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim detalleMercancias As DetalleMercancia = New DetalleMercancia()
        Dim listaDetalleMercancias As XmlNodeList = nodoMercancia.GetElementsByTagName("cartaporte20:DetalleMercancia")
        If listaDetalleMercancias.Count = 0 Then Return Nothing
        Dim nodoDetalleMercancia As XmlElement = TryCast(listaDetalleMercancias(0), XmlElement)
        If nodoDetalleMercancia.HasAttribute("UnidadPesoMerc") Then detalleMercancias.UnidadPesoMerc = nodoDetalleMercancia.HasAttribute("UnidadPesoMerc").ToString()
        If nodoDetalleMercancia.HasAttribute("PesoBruto") Then detalleMercancias.PesoBruto = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoBruto"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("PesoNeto") Then detalleMercancias.PesoNeto = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoNeto"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("PesoTara") Then detalleMercancias.PesoTara = If(Decimal.TryParse(nodoDetalleMercancia.GetAttribute("PesoTara"), valDecimal), valDecimal, 0D)
        If nodoDetalleMercancia.HasAttribute("NumPiezas") Then detalleMercancias.NumPiezas = If(Integer.TryParse(nodoDetalleMercancia.GetAttribute("NumPiezas"), valInt), valInt, 0)
        Return detalleMercancias
    End Function

    Private Shared Function CP20ObtenerAutoTransporte(ByVal nodoMercancias As XmlElement) As Autotransporte
        Dim autoTransporte As Autotransporte = New Autotransporte()
        Dim listaAutotransporte As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:AutotransporteFederal")
        If listaAutotransporte.Count = 0 Then Return Nothing
        Dim nodoAutotransporte As XmlElement = TryCast(listaAutotransporte(0), XmlElement)
        autoTransporte.IdentificacionVehicular = CP20ObtenerIdentificacionVehicular(nodoAutotransporte)
        autoTransporte.Seguros = CP20ObtenerSeguros(nodoAutotransporte)
        autoTransporte.Remolques = CP20ObtenerRemolques(nodoAutotransporte)
        If nodoAutotransporte.HasAttribute("PermSCT") Then autoTransporte.PermSCT = nodoAutotransporte.HasAttribute("PermSCT").ToString()
        If nodoAutotransporte.HasAttribute("NumPermisoSCT") Then autoTransporte.NumPermisoSCT = nodoAutotransporte.HasAttribute("NumPermisoSCT").ToString()
        Return autoTransporte
    End Function

    Private Shared Function CP20ObtenerIdentificacionVehicular(ByVal nodoAutotransporteFederal As XmlElement) As IdentificacionVehicular
        Dim valInt As Integer
        Dim identificacionVehicular As IdentificacionVehicular = New IdentificacionVehicular()
        Dim listaIdentificacionVehicular As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte20:IdentificacionVehicular")
        If listaIdentificacionVehicular.Count = 0 Then Return Nothing
        Dim nodoIdentificacionVehicular As XmlElement = TryCast(listaIdentificacionVehicular(0), XmlElement)
        If nodoIdentificacionVehicular.HasAttribute("ConfigVehicular") Then identificacionVehicular.ConfigVehicular = nodoIdentificacionVehicular.GetAttribute("ConfigVehicular").ToString()
        If nodoIdentificacionVehicular.HasAttribute("PlacaVM") Then identificacionVehicular.PlacaVM = nodoIdentificacionVehicular.GetAttribute("PlacaVM").ToString()
        If nodoIdentificacionVehicular.HasAttribute("AnioModeloVM") Then identificacionVehicular.AnioModeloVM = If(Integer.TryParse(nodoIdentificacionVehicular.GetAttribute("AnioModeloVM").ToString(), valInt), valInt, 0)
        Return identificacionVehicular
    End Function

    Private Shared Function CP20ObtenerSeguros(ByVal nodoAutoTransporte As XmlElement) As Seguros
        Dim valDecimal As Decimal
        Dim seguros As Seguros = New Seguros()
        Dim listaSeguros As XmlNodeList = nodoAutoTransporte.GetElementsByTagName("cartaporte20:Seguros")
        If listaSeguros.Count > 0 Then Return Nothing
        Dim nodoSeguros As XmlElement = TryCast(listaSeguros(0), XmlElement)
        If nodoSeguros.HasAttribute("AseguraRespCivil") Then seguros.AseguraRespCivil = nodoSeguros.GetAttribute("AseguraRespCivil")
        If nodoSeguros.HasAttribute("PolizaRespCivil") Then seguros.PolizaRespCivil = nodoSeguros.GetAttribute("PolizaRespCivil")
        If nodoSeguros.HasAttribute("AseguraMedAmbiente") Then seguros.AseguraMedAmbiente = nodoSeguros.GetAttribute("AseguraMedAmbiente")
        If nodoSeguros.HasAttribute("PolizaMedAmbiente") Then seguros.PolizaMedAmbiente = nodoSeguros.GetAttribute("PolizaMedAmbiente")
        If nodoSeguros.HasAttribute("AseguraCarga") Then seguros.AseguraCarga = nodoSeguros.GetAttribute("AseguraCarga")
        If nodoSeguros.HasAttribute("PolizaCarga") Then seguros.PolizaCarga = nodoSeguros.GetAttribute("PolizaCarga")
        If nodoSeguros.HasAttribute("PrimaSeguro") Then seguros.PrimaSeguro = If(Decimal.TryParse(nodoSeguros.GetAttribute("PrimaSeguro"), valDecimal), valDecimal, 0D)
        Return seguros
    End Function

    Private Shared Function CP20ObtenerRemolques(ByVal nodoAutotransporteFederal As XmlElement) As Remolques
        Dim remolques As Remolques = New Remolques()
        Dim listaRemolques As XmlNodeList = nodoAutotransporteFederal.GetElementsByTagName("cartaporte20:Remolques")
        If listaRemolques.Count = 0 Then Return Nothing
        Dim nodoRemolques As XmlElement = TryCast(listaRemolques(0), XmlElement)
        remolques.Remolque = CP20ObtenerRemolque(nodoRemolques)
        Return remolques
    End Function

    Private Shared Function CP20ObtenerRemolque(ByVal nodoRemolques As XmlElement) As List(Of Remolque)
        Dim listaRemolque As List(Of Remolque) = New List(Of Remolque)()

        For Each item As XmlElement In nodoRemolques.GetElementsByTagName("cartaporte20:Remolque")
            Dim remolque As Remolque = New Remolque()
            If item.HasAttribute("Placa") Then remolque.Placa = item.GetAttribute("Placa")
            If item.HasAttribute("SubTipoRem") Then remolque.SubTipoRem = item.GetAttribute("SubTipoRem")
            listaRemolque.Add(remolque)
        Next

        Return listaRemolque
    End Function

    Private Shared Function CP20ObtenerTransporteMaritimo(ByVal nodoMercancias As XmlElement) As TransporteMaritimo
        Dim valInt As Integer
        Dim valDecimal As Decimal
        Dim transporteMaritimo As TransporteMaritimo = New TransporteMaritimo()
        Dim listaTransporteMaritimo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteMaritimo")
        If listaTransporteMaritimo.Count = 0 Then Return Nothing
        Dim nodoTransporteMaritimo As XmlElement = TryCast(listaTransporteMaritimo(0), XmlElement)
        transporteMaritimo.Contenedor = CP20ObtenerContenedor(nodoTransporteMaritimo)
        If nodoTransporteMaritimo.HasAttribute("PermSCT") Then transporteMaritimo.PermSCT = nodoTransporteMaritimo.GetAttribute("PermSCT")
        If nodoTransporteMaritimo.HasAttribute("NumPermisoSCT") Then transporteMaritimo.NumPermisoSCT = nodoTransporteMaritimo.GetAttribute("NumPermisoSCT")
        If nodoTransporteMaritimo.HasAttribute("NombreAseg") Then transporteMaritimo.NombreAseg = nodoTransporteMaritimo.GetAttribute("NombreAseg")
        If nodoTransporteMaritimo.HasAttribute("NumPolizaSeguro") Then transporteMaritimo.NumPolizaSeguro = nodoTransporteMaritimo.GetAttribute("NumPolizaSeguro")
        If nodoTransporteMaritimo.HasAttribute("TipoEmbarcacion") Then transporteMaritimo.TipoEmbarcacion = nodoTransporteMaritimo.GetAttribute("TipoEmbarcacion")
        If nodoTransporteMaritimo.HasAttribute("Matricula") Then transporteMaritimo.Matricula = nodoTransporteMaritimo.GetAttribute("Matricula")
        If nodoTransporteMaritimo.HasAttribute("NumeroOMI") Then transporteMaritimo.NumeroOMI = nodoTransporteMaritimo.GetAttribute("NumeroOMI")
        If nodoTransporteMaritimo.HasAttribute("AnioEmbarcacion") Then transporteMaritimo.AnioEmbarcacion = If(Integer.TryParse(nodoTransporteMaritimo.GetAttribute("AnioEmbarcacion"), valInt), valInt, 0)
        If nodoTransporteMaritimo.HasAttribute("NombreEmbarc") Then transporteMaritimo.NombreEmbarc = nodoTransporteMaritimo.GetAttribute("NombreEmbarc")
        If nodoTransporteMaritimo.HasAttribute("NacionalidadEmbarc") Then transporteMaritimo.NacionalidadEmbarc = nodoTransporteMaritimo.GetAttribute("NacionalidadEmbarc")
        If nodoTransporteMaritimo.HasAttribute("UnidadesDeArqBruto") Then transporteMaritimo.UnidadesDeArqBruto = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("UnidadesDeArqBruto"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("TipoCarga") Then transporteMaritimo.TipoCarga = nodoTransporteMaritimo.GetAttribute("TipoCarga")
        If nodoTransporteMaritimo.HasAttribute("NumCertITC") Then transporteMaritimo.NumCertITC = nodoTransporteMaritimo.GetAttribute("NumCertITC")
        If nodoTransporteMaritimo.HasAttribute("Eslora") Then transporteMaritimo.Eslora = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Eslora"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("Manga") Then transporteMaritimo.Manga = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Manga"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("Calado") Then transporteMaritimo.Calado = If(Decimal.TryParse(nodoTransporteMaritimo.GetAttribute("Calado"), valDecimal), valDecimal, 0D)
        If nodoTransporteMaritimo.HasAttribute("LineaNaviera") Then transporteMaritimo.LineaNaviera = nodoTransporteMaritimo.GetAttribute("LineaNaviera")
        If nodoTransporteMaritimo.HasAttribute("NombreAgenteNaviero") Then transporteMaritimo.NombreAgenteNaviero = nodoTransporteMaritimo.GetAttribute("NombreAgenteNaviero")
        If nodoTransporteMaritimo.HasAttribute("NumAutorizacionNaviero") Then transporteMaritimo.NumAutorizacionNaviero = nodoTransporteMaritimo.GetAttribute("NumAutorizacionNaviero")
        If nodoTransporteMaritimo.HasAttribute("NumViaje") Then transporteMaritimo.NumViaje = nodoTransporteMaritimo.GetAttribute("NumViaje")
        If nodoTransporteMaritimo.HasAttribute("NumConocEmbarc") Then transporteMaritimo.NumConocEmbarc = nodoTransporteMaritimo.GetAttribute("NumConocEmbarc")
        Return transporteMaritimo
    End Function

    Private Shared Function CP20ObtenerContenedor(ByVal nodoTransporteMaritimo As XmlElement) As List(Of Contenedor)
        Dim listaContenedor As List(Of Contenedor) = New List(Of Contenedor)()

        For Each item As XmlElement In nodoTransporteMaritimo.GetElementsByTagName("cartaporte20:Contenedor")
            Dim contenedor As Contenedor = New Contenedor()
            If nodoTransporteMaritimo.HasAttribute("MatriculaContenedor") Then contenedor.MatriculaContenedor = nodoTransporteMaritimo.GetAttribute("MatriculaContenedor")
            If nodoTransporteMaritimo.HasAttribute("TipoContenedor") Then contenedor.TipoContenedor = nodoTransporteMaritimo.GetAttribute("TipoContenedor")
            If nodoTransporteMaritimo.HasAttribute("NumPrecinto") Then contenedor.NumPrecinto = nodoTransporteMaritimo.GetAttribute("NumPrecinto")
            listaContenedor.Add(contenedor)
        Next

        Return listaContenedor
    End Function

    Private Shared Function CP20ObtenerTransporteAereo(ByVal nodoMercancias As XmlElement) As TransporteAereo
        Dim transporteAereo As TransporteAereo = New TransporteAereo()
        Dim listaTransporteAereo As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteAereo")
        If listaTransporteAereo.Count = 0 Then Return Nothing
        Dim nodoTransporteAereo As XmlElement = TryCast(listaTransporteAereo(0), XmlElement)
        If nodoTransporteAereo.HasAttribute("PermSCT") Then transporteAereo.PermSCT = nodoTransporteAereo.GetAttribute("PermSCT")
        If nodoTransporteAereo.HasAttribute("NumPermisoSCT") Then transporteAereo.NumPermisoSCT = nodoTransporteAereo.GetAttribute("NumPermisoSCT")
        If nodoTransporteAereo.HasAttribute("MatriculaAeronave") Then transporteAereo.MatriculaAeronave = nodoTransporteAereo.GetAttribute("MatriculaAeronave")
        If nodoTransporteAereo.HasAttribute("NombreAseg") Then transporteAereo.NombreAseg = nodoTransporteAereo.GetAttribute("NombreAseg")
        If nodoTransporteAereo.HasAttribute("NumPolizaSeguro") Then transporteAereo.NumPolizaSeguro = nodoTransporteAereo.GetAttribute("NumPolizaSeguro")
        If nodoTransporteAereo.HasAttribute("NumeroGuia") Then transporteAereo.NumeroGuia = nodoTransporteAereo.GetAttribute("NumeroGuia")
        If nodoTransporteAereo.HasAttribute("LugarContrato") Then transporteAereo.LugarContrato = nodoTransporteAereo.GetAttribute("LugarContrato")
        If nodoTransporteAereo.HasAttribute("CodigoTransportista") Then transporteAereo.CodigoTransportista = nodoTransporteAereo.GetAttribute("CodigoTransportista")
        If nodoTransporteAereo.HasAttribute("RFCEmbarcador") Then transporteAereo.RFCEmbarcador = nodoTransporteAereo.GetAttribute("RFCEmbarcador")
        If nodoTransporteAereo.HasAttribute("NumRegIdTribEmbarc") Then transporteAereo.NumRegIdTribEmbarc = nodoTransporteAereo.GetAttribute("NumRegIdTribEmbarc")
        If nodoTransporteAereo.HasAttribute("ResidenciaFiscalEmbarc") Then transporteAereo.ResidenciaFiscalEmbarc = nodoTransporteAereo.GetAttribute("ResidenciaFiscalEmbarc")
        If nodoTransporteAereo.HasAttribute("NombreEmbarcador") Then transporteAereo.NombreEmbarcador = nodoTransporteAereo.GetAttribute("NombreEmbarcador")
        Return transporteAereo
    End Function

    Private Shared Function CP20ObtenerTransporteFerroviario(ByVal nodoMercancias As XmlElement) As TransporteFerroviario
        Dim transporteFerroviario As TransporteFerroviario = New TransporteFerroviario()
        Dim listaTransporteFerroviario As XmlNodeList = nodoMercancias.GetElementsByTagName("cartaporte20:TransporteFerroviario")
        If listaTransporteFerroviario.Count = 0 Then Return Nothing
        Dim nodoTransporteFerroviario As XmlElement = TryCast(listaTransporteFerroviario(0), XmlElement)
        transporteFerroviario.DerechosDePaso = CP20ObtenerDerechosDePaso(nodoTransporteFerroviario)
        transporteFerroviario.Carro = CP20ObtenerCarro(nodoTransporteFerroviario)
        If nodoTransporteFerroviario.HasAttribute("TipoDeServicio") Then transporteFerroviario.TipoDeServicio = nodoTransporteFerroviario.GetAttribute("TipoDeServicio")
        If nodoTransporteFerroviario.HasAttribute("TipoDeTrafico") Then transporteFerroviario.TipoDeTrafico = nodoTransporteFerroviario.GetAttribute("TipoDeTrafico")
        If nodoTransporteFerroviario.HasAttribute("NombreAseg") Then transporteFerroviario.NombreAseg = nodoTransporteFerroviario.GetAttribute("NombreAseg")
        If nodoTransporteFerroviario.HasAttribute("NumPolizaSeguro") Then transporteFerroviario.NumPolizaSeguro = nodoTransporteFerroviario.GetAttribute("NumPolizaSeguro")
        Return transporteFerroviario
    End Function

    Private Shared Function CP20ObtenerDerechosDePaso(ByVal nodoTransporteFerroviario As XmlElement) As List(Of DerechosDePaso)
        Dim valDecimal As Decimal
        Dim listaDerechosDePaso As List(Of DerechosDePaso) = New List(Of DerechosDePaso)()

        For Each item As XmlElement In nodoTransporteFerroviario.GetElementsByTagName("cartaporte20:DerechosDePaso")
            Dim derechosDePaso As DerechosDePaso = New DerechosDePaso()
            If item.HasAttribute("TipoDerechoDePaso") Then derechosDePaso.TipoDerechoDePaso = item.GetAttribute("TipoDerechoDePaso")
            If item.HasAttribute("KilometrajePagado") Then derechosDePaso.KilometrajePagado = If(Decimal.TryParse(item.GetAttribute("KilometrajePagado"), valDecimal), valDecimal, 0D)
            listaDerechosDePaso.Add(derechosDePaso)
        Next

        Return listaDerechosDePaso
    End Function

    Private Shared Function CP20ObtenerCarro(ByVal nodoTransporteFerroviario As XmlElement) As List(Of Carro)
        Dim valDecimal As Decimal
        Dim listaCarro As List(Of Carro) = New List(Of Carro)()

        For Each item As XmlElement In nodoTransporteFerroviario.GetElementsByTagName("cartaporte20:Carro")
            Dim carro As Carro = New Carro()
            carro.Contenedor = CP20ObtenerContenedorCarro(item)
            If item.HasAttribute("TipoCarro") Then carro.TipoCarro = item.GetAttribute("TipoCarro")
            If item.HasAttribute("MatriculaCarro") Then carro.MatriculaCarro = item.GetAttribute("MatriculaCarro")
            If item.HasAttribute("GuiaCarro") Then carro.GuiaCarro = item.GetAttribute("GuiaCarro")
            If item.HasAttribute("ToneladasNetasCarro") Then carro.ToneladasNetasCarro = If(Decimal.TryParse(item.GetAttribute("ToneladasNetasCarro"), valDecimal), valDecimal, 0D)
        Next

        Return listaCarro
    End Function

    Private Shared Function CP20ObtenerContenedorCarro(ByVal nodoCarro As XmlElement) As List(Of CarroContenedor)
        Dim valDecimal As Decimal
        Dim listaContenedor As List(Of CarroContenedor) = New List(Of CarroContenedor)()

        For Each item As XmlElement In nodoCarro.GetElementsByTagName("cartaporte20:Contenedor")
            Dim contenedor As CarroContenedor = New CarroContenedor()
            If item.HasAttribute("TipoContenedor") Then contenedor.TipoContenedor = item.GetAttribute("TipoContenedor")
            If item.HasAttribute("PesoContenedorVacio") Then contenedor.PesoContenedorVacio = If(Decimal.TryParse(item.GetAttribute("PesoContenedorVacio"), valDecimal), valDecimal, 0D)
            If item.HasAttribute("PesoNetoMercancia") Then contenedor.PesoNetoMercancia = If(Decimal.TryParse(item.GetAttribute("PesoNetoMercancia"), valDecimal), valDecimal, 0D)
            listaContenedor.Add(contenedor)
        Next

        Return listaContenedor
    End Function

    Private Shared Function CP20ObtenerFiguraTransporte(ByVal nodoCartaPorte As XmlElement) As FiguraTransporte
        Dim figuraTransporte As FiguraTransporte = New FiguraTransporte()
        Dim listaFiguraTransporte As XmlNodeList = nodoCartaPorte.GetElementsByTagName("cartaporte20:FiguraTransporte")
        If listaFiguraTransporte.Count = 0 Then Return Nothing
        Dim nodoFiguraTransporte As XmlElement = TryCast(listaFiguraTransporte(0), XmlElement)
        figuraTransporte.TiposFigura = CP20ObtenerTiposFigura(nodoFiguraTransporte)
        Return figuraTransporte
    End Function

    Private Shared Function CP20ObtenerTiposFigura(ByVal nodoFiguraTransporte As XmlElement) As List(Of TiposFigura)
        Dim listaTiposFigura As List(Of TiposFigura) = New List(Of TiposFigura)()

        For Each item As XmlElement In nodoFiguraTransporte.GetElementsByTagName("cartaporte20:TiposFigura")
            Dim tiposFigura As TiposFigura = New TiposFigura()
            tiposFigura.PartesTransporte = CP20ObtenerPartesTransporte(item)
            tiposFigura.Domicilio = CP20ObtenerDomicilio(item)
            If item.HasAttribute("TipoFigura") Then tiposFigura.TipoFigura = item.GetAttribute("TipoFigura")
            If item.HasAttribute("RFCFigura") Then tiposFigura.RFCFigura = item.GetAttribute("RFCFigura")
            If item.HasAttribute("NumLicencia") Then tiposFigura.NumLicencia = item.GetAttribute("NumLicencia")
            If item.HasAttribute("NombreFigura") Then tiposFigura.NombreFigura = item.GetAttribute("NombreFigura")
            If item.HasAttribute("NumRegIdTribFigura") Then tiposFigura.NumRegIdTribFigura = item.GetAttribute("NumRegIdTribFigura")
            If item.HasAttribute("ResidenciaFiscalFigura") Then tiposFigura.ResidenciaFiscalFigura = item.GetAttribute("ResidenciaFiscalFigura")
            listaTiposFigura.Add(tiposFigura)
        Next

        Return listaTiposFigura
    End Function

    Private Shared Function CP20ObtenerPartesTransporte(ByVal nodoTiposFigura As XmlElement) As List(Of PartesTransporte)
        Dim listaPartesTransporte As List(Of PartesTransporte) = New List(Of PartesTransporte)()

        For Each item As XmlElement In nodoTiposFigura.GetElementsByTagName("cartaporte20:PartesTransporte")
            Dim partesTransporte As PartesTransporte = New PartesTransporte()
            If item.HasAttribute("ParteTransporte") Then partesTransporte.ParteTransporte = item.GetAttribute("ParteTransporte")
            listaPartesTransporte.Add(partesTransporte)
        Next

        Return listaPartesTransporte
    End Function
#End Region
#Region "Complemento Nomina"
    Private Function ObtenerNodoComplementoNomina(ByVal nodoComplemento As XmlElement) As Nomina
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lNomina As XmlNodeList = nodoComplemento.GetElementsByTagName("nomina12:Nomina")
        If lNomina.Count = 0 Then Return Nothing
        Dim nNomina As XmlElement = TryCast(lNomina(0), XmlElement)
        Dim nomina As Nomina = New Nomina()
        If nNomina.HasAttribute("Version") Then nomina.Version = nNomina.GetAttribute("Version")
        If nNomina.HasAttribute("TipoNomina") Then nomina.TipoNomina = nNomina.GetAttribute("TipoNomina")
        If nNomina.HasAttribute("FechaPago") Then nomina.FechaPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("FechaInicialPago") Then nomina.FechaInicialPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaInicialPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("FechaFinalPago") Then nomina.FechaFinalPago = If(DateTime.TryParse(nNomina.GetAttribute("FechaFinalPago"), fecha), fecha, DateTime.Now)
        If nNomina.HasAttribute("NumDiasPagados") Then nomina.NumDiasPagados = If(Decimal.TryParse(nNomina.GetAttribute("NumDiasPagados"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalPercepciones") Then nomina.TotalPercepciones = If(Decimal.TryParse(nNomina.GetAttribute("TotalPercepciones"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalDeducciones") Then nomina.TotalDeducciones = If(Decimal.TryParse(nNomina.GetAttribute("TotalDeducciones"), valDecimal), valDecimal, 0)
        If nNomina.HasAttribute("TotalOtrosPagos") Then nomina.TotalOtrosPagos = If(Decimal.TryParse(nNomina.GetAttribute("TotalOtrosPagos"), valDecimal), valDecimal, 0)
        nomina.Emisor = ObtenerNodoEmisorNomina(nNomina)
        nomina.Receptor = ObtenerNodoReceptorNomina(nNomina)
        nomina.Percepciones = ObtenerNodoPercepcionesNomina(nNomina)
        nomina.Deducciones = ObtenerNodoDeduccionesNomina(nNomina)
        nomina.OtrosPagos = ObtenerNodoOtrosPagosNomina(nNomina)
        nomina.Incapacidades = ObtenerNodoIncapacidadesNomina(nNomina)
        nomina.HorasExtra = ObtenerNodoHorasExtraNomina(nNomina)
        Return nomina
    End Function

    Private Function ObtenerNodoEmisorNomina(ByVal nodoNomina As XmlElement) As NEmisor
        Dim lNEmisores As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Emisor")
        If lNEmisores.Count = 0 Then Return Nothing
        Dim nNEmisor As XmlElement = TryCast(lNEmisores(0), XmlElement)
        Dim nEmisor As NEmisor = New NEmisor()
        If nNEmisor.HasAttribute("Curp") Then nEmisor.Curp = nNEmisor.GetAttribute("Curp")
        If nNEmisor.HasAttribute("RegistroPatronal") Then nEmisor.RegistroPatronal = nNEmisor.GetAttribute("RegistroPatronal")
        If nNEmisor.HasAttribute("RfcPatronOrigen") Then nEmisor.RfcPatronOrigen = nNEmisor.GetAttribute("RfcPatronOrigen")
        nEmisor.EntidadSNCF = ObtenerNodoEntidadSNCFEmisorNomina(nNEmisor)
        Return nEmisor
    End Function

    Private Function ObtenerNodoEntidadSNCFEmisorNomina(ByVal nodoEmisorNomina As XmlElement) As NEntidadSNCF
        Dim valDecimal As Decimal
        Dim lNEntidadSNCF As XmlNodeList = nodoEmisorNomina.GetElementsByTagName("nomina12:EntidadSNCF")
        If lNEntidadSNCF.Count = 0 Then Return Nothing
        Dim nNEntidadSNCF As XmlElement = TryCast(lNEntidadSNCF(0), XmlElement)
        Dim entidadSNCF As NEntidadSNCF = New NEntidadSNCF()
        If nNEntidadSNCF.HasAttribute("OrigenRecurso") Then entidadSNCF.OrigenRecurso = nNEntidadSNCF.GetAttribute("OrigenRecurso")
        If nNEntidadSNCF.HasAttribute("MontoRecursoPropio") Then entidadSNCF.MontoRecursoPropio = If(Decimal.TryParse(nNEntidadSNCF.GetAttribute("Cantidad"), valDecimal), valDecimal, 0)
        Return entidadSNCF
    End Function

    Private Function ObtenerNodoReceptorNomina(ByVal nodoNomina As XmlElement) As NReceptor
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lNReceptor As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Receptor")
        If lNReceptor.Count = 0 Then Return Nothing
        Dim nNReceptor As XmlElement = TryCast(lNReceptor(0), XmlElement)
        Dim nReceptor As NReceptor = New NReceptor()
        If nNReceptor.HasAttribute("Curp") Then nReceptor.Curp = nNReceptor.GetAttribute("Curp")
        If nNReceptor.HasAttribute("NumSeguridadSocial") Then nReceptor.NumSeguridadSocial = nNReceptor.GetAttribute("NumSeguridadSocial")
        If nNReceptor.HasAttribute("FechaInicioRelLaboral") Then nReceptor.FechaInicioRelLaboral = If(DateTime.TryParse(nNReceptor.GetAttribute("FechaInicioRelLaboral"), fecha), fecha, DateTime.Now)
        If nNReceptor.HasAttribute("Antigüedad") Then nReceptor.Antiguedad = nNReceptor.GetAttribute("Antigüedad")
        If nNReceptor.HasAttribute("TipoContrato") Then nReceptor.TipoContrato = nNReceptor.GetAttribute("TipoContrato")
        If nNReceptor.HasAttribute("Sindicalizado") Then nReceptor.Sindicalizado = nNReceptor.GetAttribute("Sindicalizado")
        If nNReceptor.HasAttribute("TipoJornada") Then nReceptor.TipoJornada = nNReceptor.GetAttribute("TipoJornada")
        If nNReceptor.HasAttribute("TipoRegimen") Then nReceptor.TipoRegimen = nNReceptor.GetAttribute("TipoRegimen")
        If nNReceptor.HasAttribute("NumEmpleado") Then nReceptor.NumEmpleado = nNReceptor.GetAttribute("NumEmpleado")
        If nNReceptor.HasAttribute("Departamento") Then nReceptor.Departamento = nNReceptor.GetAttribute("Departamento")
        If nNReceptor.HasAttribute("Puesto") Then nReceptor.Puesto = nNReceptor.GetAttribute("Puesto")
        If nNReceptor.HasAttribute("RiesgoPuesto") Then nReceptor.RiesgoPuesto = nNReceptor.GetAttribute("RiesgoPuesto")
        If nNReceptor.HasAttribute("PeriodicidadPago") Then nReceptor.PeriodicidadPago = nNReceptor.GetAttribute("PeriodicidadPago")
        If nNReceptor.HasAttribute("Banco") Then nReceptor.Banco = nNReceptor.GetAttribute("Banco")
        If nNReceptor.HasAttribute("CuentaBancaria") Then nReceptor.CuentaBancaria = nNReceptor.GetAttribute("CuentaBancaria")
        If nNReceptor.HasAttribute("SalarioBaseCotApor") Then nReceptor.SalarioBaseCotApor = If(Decimal.TryParse(nNReceptor.GetAttribute("SalarioBaseCotApor"), valDecimal), valDecimal, 0)
        If nNReceptor.HasAttribute("SalarioDiarioIntegrado") Then nReceptor.SalarioDiarioIntegrado = If(Decimal.TryParse(nNReceptor.GetAttribute("SalarioDiarioIntegrado"), valDecimal), valDecimal, 0)
        If nNReceptor.HasAttribute("ClaveEntFed") Then nReceptor.ClaveEntFed = nNReceptor.GetAttribute("ClaveEntFed")
        nReceptor.SubContratacion = ObtenerNodoSubContratacionReceptorNomina(nNReceptor)
        Return nReceptor
    End Function

    Private Function ObtenerNodoSubContratacionReceptorNomina(ByVal nodoReceptorNomina As XmlElement) As List(Of NSubContratacion)
        Dim valDecimal As Decimal
        Dim lNSubContratacion As XmlNodeList = nodoReceptorNomina.GetElementsByTagName("nomina12:SubContratacion")
        Dim lista As List(Of NSubContratacion) = New List(Of NSubContratacion)()
        For Each nSubContratacion As XmlElement In lNSubContratacion
            Dim subcontratacion As NSubContratacion = New NSubContratacion()
            If nSubContratacion.HasAttribute("RfcLabora") Then subcontratacion.RfcLabora = nSubContratacion.GetAttribute("RfcLabora")
            If nSubContratacion.HasAttribute("PorcentajeTiempo") Then subcontratacion.PorcentajeTiempo = If(Decimal.TryParse(nSubContratacion.GetAttribute("PorcentajeTiempo"), valDecimal), valDecimal, 0)
            lista.Add(subcontratacion)
        Next
        Return lista
    End Function

    Private Function ObtenerNodoPercepcionesNomina(ByVal nodoNomina As XmlElement) As NPercepciones
        Dim valDecimal As Decimal
        Dim nPercepciones As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Percepciones")
        If nPercepciones.Count = 0 Then Return Nothing
        Dim nPercepcion As XmlElement = TryCast(nPercepciones(0), XmlElement)
        Dim percepciones As NPercepciones = New NPercepciones()
        If nPercepcion.HasAttribute("TotalSueldos") Then percepciones.TotalSueldos = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalSueldos"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalSeparacionIndemnizacion") Then percepciones.TotalSeparacionIndemnizacion = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalSeparacionIndemnizacion"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalJubilacionPensionRetiro") Then percepciones.TotalJubilacionPensionRetiro = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalJubilacionPensionRetiro"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalGravado") Then percepciones.TotalGravado = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalGravado"), valDecimal), valDecimal, 0)
        If nPercepcion.HasAttribute("TotalExento") Then percepciones.TotalExento = If(Decimal.TryParse(nPercepcion.GetAttribute("TotalExento"), valDecimal), valDecimal, 0)

        percepciones.Percepcion = New List(Of NPercepcion)()

        For Each p As XmlElement In nPercepcion.GetElementsByTagName("nomina12:Percepcion")
            Dim percepcion As NPercepcion = New NPercepcion()
            If p.HasAttribute("TipoPercepcion") Then percepcion.TipoPercepcion = p.GetAttribute("TipoPercepcion")
            If p.HasAttribute("Clave") Then percepcion.Clave = p.GetAttribute("Clave")
            If p.HasAttribute("Concepto") Then percepcion.Concepto = p.GetAttribute("Concepto")
            If p.HasAttribute("ImporteGravado") Then percepcion.ImporteGravado = If(Decimal.TryParse(p.GetAttribute("ImporteGravado"), valDecimal), valDecimal, 0)
            If p.HasAttribute("ImporteExento") Then percepcion.ImporteExento = If(Decimal.TryParse(p.GetAttribute("ImporteExento"), valDecimal), valDecimal, 0)
            percepcion.AccionesOTitulos = ObtenerNodoAccionesOTitulosPercepcionNomina(p)
            percepcion.HorasExtras = ObtenerNodoHorasExtraNomina(p)
            percepciones.Percepcion.Add(percepcion)
        Next

        percepciones.JubilacionPensionRetiro = ObtenerNodoJubilacionPensionRetiroNomina(nPercepcion)
        percepciones.SeparacionIndeminzacion = ObtenerNodoSeparacionIndemnizacion(nPercepcion)
        Return percepciones
    End Function

    Private Function ObtenerNodoAccionesOTitulosPercepcionNomina(ByVal nodoPercepcionNomina As XmlElement) As NAccionesOTitulos
        Dim valDecimal As Decimal
        Dim lNAccionesOTitulos As XmlNodeList = nodoPercepcionNomina.GetElementsByTagName("nomina12:AccionesOTitulos")
        If lNAccionesOTitulos.Count = 0 Then Return Nothing
        Dim nNAccionesOTitulos As XmlElement = TryCast(lNAccionesOTitulos(0), XmlElement)
        Dim accionesOTitulos As NAccionesOTitulos = New NAccionesOTitulos()
        accionesOTitulos.ValorMercado = nNAccionesOTitulos.GetAttribute("ValorMercado")
        accionesOTitulos.PrecioAlOtorgarse = If(Decimal.TryParse(nNAccionesOTitulos.GetAttribute("PrecioAlOtorgarse"), valDecimal), valDecimal, 0)
        Return accionesOTitulos
    End Function

    Private Function ObtenerNodoHorasExtraNomina(ByVal nodoNomina As XmlElement) As List(Of NHorasExtra)
        Dim valInt As Integer
        Dim lNHorasExtra As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:HorasExtra")
        If lNHorasExtra.Count = 0 Then Return Nothing
        Dim lista As List(Of NHorasExtra) = New List(Of NHorasExtra)()
        Dim nNHoraExtra As XmlElement = TryCast(lNHorasExtra(0), XmlElement)

        For Each h As XmlElement In lNHorasExtra
            Dim nhorasextra As XmlElement = TryCast(nNHoraExtra, XmlElement)
            Dim horasExtra As NHorasExtra = New NHorasExtra()
            horasExtra.Dias = If(Integer.TryParse(h.GetAttribute("Dias"), valInt), valInt, 0)
            horasExtra.TipoHoras = If(Integer.TryParse(h.GetAttribute("TipoHoras"), valInt), valInt, 0)
            horasExtra.HorasExtra = If(Integer.TryParse(h.GetAttribute("HorasExtra"), valInt), valInt, 0)
            horasExtra.ImportePagado = Decimal.Parse(h.GetAttribute("ImportePagado"))
            lista.Add(horasExtra)
        Next

        Return lista
    End Function

    Private Function ObtenerNodoJubilacionPensionRetiroNomina(ByVal nodoPercepcionesNomina As XmlElement) As NJubilacionPensionRetiro
        Dim valDecimal As Decimal
        Dim lNJubilacionPensionRetiro As XmlNodeList = nodoPercepcionesNomina.GetElementsByTagName("nomina12:JubilacionPensionRetiro")
        If lNJubilacionPensionRetiro.Count = 0 Then Return Nothing
        Dim nNJubilacionPensionRetiro As XmlElement = TryCast(lNJubilacionPensionRetiro(0), XmlElement)
        Dim jubilacionPensionRetiro As NJubilacionPensionRetiro = New NJubilacionPensionRetiro()
        If nNJubilacionPensionRetiro.HasAttribute("TotalUnaExhibicion") Then jubilacionPensionRetiro.TotalUnaExhibicion = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("TotalUnaExhibicion"), valDecimal), valDecimal, 0)
        If nNJubilacionPensionRetiro.HasAttribute("TotalParcialidad") Then jubilacionPensionRetiro.TotalParcialidad = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("TotalParcialidad"), valDecimal), valDecimal, 0)
        If nNJubilacionPensionRetiro.HasAttribute("MontoDiario") Then jubilacionPensionRetiro.MontoDiario = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("MontoDiario"), valDecimal), valDecimal, 0)
        jubilacionPensionRetiro.IngresoAcumulable = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("IngresoAcumulable"), valDecimal), valDecimal, 0)
        jubilacionPensionRetiro.IngresoNoAcumulable = If(Decimal.TryParse(nNJubilacionPensionRetiro.GetAttribute("IngresoNoAcumulable"), valDecimal), valDecimal, 0)
        Return jubilacionPensionRetiro
    End Function

    Private Function ObtenerNodoSeparacionIndemnizacion(ByVal nodoPercepcionesNomina As XmlElement) As NSeparacionIndemnizacion
        Dim valDecimal As Decimal
        Dim valInt As Integer
        Dim lNSeparacionIndeminzacion As XmlNodeList = nodoPercepcionesNomina.GetElementsByTagName("nomina12:SeparacionIndemnizacion")
        If lNSeparacionIndeminzacion.Count = 0 Then Return Nothing
        Dim nNSeparacionIndeminzacion As XmlElement = TryCast(lNSeparacionIndeminzacion(0), XmlElement)
        Dim separacionIndeminzacion As NSeparacionIndemnizacion = New NSeparacionIndemnizacion()
        separacionIndeminzacion.TotalPagado = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("TotalPagado"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.NumAnosServicio = If(Integer.TryParse(nNSeparacionIndeminzacion.GetAttribute("NumAnosServicio"), valInt), valInt, 0)
        separacionIndeminzacion.UltimoSueldoMensOrd = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("UltimoSueldoMensOrd"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.IngresoAcumulable = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("IngresoAcumulable"), valDecimal), valDecimal, 0)
        separacionIndeminzacion.IngresoNoAcumulable = If(Decimal.TryParse(nNSeparacionIndeminzacion.GetAttribute("IngresoNoAcumulable"), valDecimal), valDecimal, 0)
        Return separacionIndeminzacion
    End Function

    Private Function ObtenerNodoDeduccionesNomina(ByVal nodoNomina As XmlElement) As NDeducciones
        Dim valDecimal As Decimal
        Dim nNDeducciones As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Deducciones")
        If nNDeducciones.Count = 0 Then Return Nothing
        Dim nNDeduccion As XmlElement = TryCast(nNDeducciones(0), XmlElement)
        Dim deducciones As NDeducciones = New NDeducciones()
        If nNDeduccion.HasAttribute("TotalOtrasDeducciones") Then deducciones.TotalOtrasDeducciones = If(Decimal.TryParse(nNDeduccion.GetAttribute("TotalOtrasDeducciones"), valDecimal), valDecimal, 0)
        If nNDeduccion.HasAttribute("TotalImpuestosRetenidos") Then deducciones.TotalImpuestosRetenidos = If(Decimal.TryParse(nNDeduccion.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
        deducciones.Deduccion = New List(Of NDeduccion)()

        For Each d As XmlElement In nNDeduccion.GetElementsByTagName("nomina12:Deduccion")
            Dim deduccion As NDeduccion = New NDeduccion()
            If d.HasAttribute("TipoDeduccion") Then deduccion.TipoDeduccion = d.GetAttribute("TipoDeduccion")
            If d.HasAttribute("Clave") Then deduccion.Clave = d.GetAttribute("Clave")
            If d.HasAttribute("Concepto") Then deduccion.Concepto = d.GetAttribute("Concepto")
            If d.HasAttribute("Importe") Then deduccion.Importe = If(Decimal.TryParse(d.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            deducciones.Deduccion.Add(deduccion)
        Next

        Return deducciones
    End Function

    Private Function ObtenerNodoOtrosPagosNomina(ByVal nodoNomina As XmlElement) As NOtrosPagos
        Dim valDecimal As Decimal
        Dim lOtrosPagos As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:OtrosPagos")
        If lOtrosPagos.Count = 0 Then Return Nothing
        Dim otrosPagos As NOtrosPagos = New NOtrosPagos()
        otrosPagos.OtroPago = New List(Of NOtroPago)()
        Dim nOtrosPagos As XmlElement = TryCast(lOtrosPagos(0), XmlElement)
        Dim lOtroPago As XmlNodeList = nOtrosPagos.GetElementsByTagName("nomina12:OtroPago")

        For Each op As XmlElement In lOtroPago
            Dim otroPago As NOtroPago = New NOtroPago()
            If op.HasAttribute("TipoOtroPago") Then otroPago.TipoOtroPago = op.GetAttribute("TipoOtroPago")
            If op.HasAttribute("Clave") Then otroPago.Clave = op.GetAttribute("Clave")
            If op.HasAttribute("Concepto") Then otroPago.Concepto = op.GetAttribute("Concepto")
            If op.HasAttribute("Importe") Then otroPago.Importe = If(Decimal.TryParse(op.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            otroPago.SubsidioAlEmpleo = ObtenerNodoSubsidioAlEmpleo(op)
            otroPago.CompensacionSaldosAFavor = ObtenerNodoCompensacionSaldosAFavor(op)
            otrosPagos.OtroPago.Add(otroPago)
        Next

        Return otrosPagos
    End Function

    Private Function ObtenerNodoSubsidioAlEmpleo(ByVal nodoOtroPago As XmlElement) As NSubsidioAlEmpleo
        Dim valDecimal As Decimal
        Dim lNSubsidioAlEmpleo As XmlNodeList = nodoOtroPago.GetElementsByTagName("nomina12:SubsidioAlEmpleo")
        If lNSubsidioAlEmpleo.Count = 0 Then Return Nothing
        Dim nSubsidioAlEmpleado As XmlElement = TryCast(lNSubsidioAlEmpleo(0), XmlElement)
        Dim subsidioAlEmpleo As NSubsidioAlEmpleo = New NSubsidioAlEmpleo()
        If nSubsidioAlEmpleado.HasAttribute("SubsidioCausado") Then subsidioAlEmpleo.SubsidioCausado = If(Decimal.TryParse(nSubsidioAlEmpleado.GetAttribute("SubsidioCausado"), valDecimal), valDecimal, 0)
        Return subsidioAlEmpleo
    End Function

    Private Function ObtenerNodoCompensacionSaldosAFavor(ByVal nodoOtroPagoNomina As XmlElement) As NCompensacionSaldosAFavor
        Dim valDecimal As Decimal
        Dim lNCompensacionSaldosAFavor As XmlNodeList = nodoOtroPagoNomina.GetElementsByTagName("nomina12:CompensacionSaldosAFavor")
        If lNCompensacionSaldosAFavor.Count = 0 Then Return Nothing
        Dim nNCompensacionSaldosAFavor As XmlElement = TryCast(lNCompensacionSaldosAFavor(0), XmlElement)
        Dim compensacionSaldosAFavor As NCompensacionSaldosAFavor = New NCompensacionSaldosAFavor()
        compensacionSaldosAFavor.SaldoAFavor = If(Decimal.TryParse(nNCompensacionSaldosAFavor.GetAttribute("SaldoAFavor"), valDecimal), valDecimal, 0)
        compensacionSaldosAFavor.Ano = nNCompensacionSaldosAFavor.GetAttribute("Año")
        compensacionSaldosAFavor.RemanenteSalFav = If(Decimal.TryParse(nNCompensacionSaldosAFavor.GetAttribute("RemanenteSalFav"), valDecimal), valDecimal, 0)
        Return compensacionSaldosAFavor
    End Function

    Private Function ObtenerNodoIncapacidadesNomina(ByVal nodoNomina As XmlElement) As NIncapacidades
        Dim nIncapacidades As XmlNodeList = nodoNomina.GetElementsByTagName("nomina12:Incapacidades")
        If nIncapacidades.Count = 0 Then Return Nothing
        Dim nIncapacidad As XmlElement = TryCast(nIncapacidades(0), XmlElement)
        Dim incapacidades As NIncapacidades = New NIncapacidades()
        incapacidades.Incapacidad = New List(Of NIncapacidad)()

        For Each i As XmlElement In nIncapacidad.GetElementsByTagName("nomina12:Incapacidad")
            Dim incapacidad As NIncapacidad = New NIncapacidad()
            If i.HasAttribute("DiasIncapacidad") Then incapacidad.DiasIncapacidad = Integer.Parse(i.GetAttribute("DiasIncapacidad"))
            If i.HasAttribute("TipoIncapacidad") Then incapacidad.TipoIncapacidad = i.GetAttribute("Concepto")
            incapacidades.Incapacidad.Add(incapacidad)
        Next

        Return incapacidades
    End Function
#End Region
#Region "Complemento Pagos 2.0"
    Private Shared Function ObtenerNodoPagos(ByVal documento As XmlDocument) As Pagos
        Dim valDecimal As Decimal
        Dim fecha As DateTime
        Dim lPagos As XmlNodeList = documento.GetElementsByTagName("pago20:Pagos")
        If lPagos.Count = 0 Then Return Nothing
        Dim pagos As Pagos = New Pagos()
        pagos.Pago = New List(Of Pago)()
        Dim nPagos As XmlElement = TryCast(lPagos(0), XmlElement)
        If nPagos.HasAttribute("Version") Then pagos.Version = nPagos.GetAttribute("Version")
        pagos.Totales = ObtenerTotalesP(nPagos)
        Dim lPago As XmlNodeList = nPagos.GetElementsByTagName("pago20:Pago")

        For Each nPago As XmlElement In lPago
            Dim pago As Pago = New Pago()
            If nPago.HasAttribute("FechaPago") Then pago.FechaPago = If(DateTime.TryParse(nPago.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
            If nPago.HasAttribute("FormaDePagoP") Then pago.FormaDePagoP = nPago.GetAttribute("FormaDePagoP")
            If nPago.HasAttribute("MonedaP") Then pago.MonedaP = nPago.GetAttribute("MonedaP")
            If nPago.HasAttribute("TipoCambioP") Then pago.TipoCambioP = If(Decimal.TryParse(nPago.GetAttribute("TipoCambioP"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("Monto") Then pago.Monto = If(Decimal.TryParse(nPago.GetAttribute("Monto"), valDecimal), valDecimal, 0)
            If nPago.HasAttribute("NumOperacion") Then pago.NumOperacion = nPago.GetAttribute("NumOperacion")
            If nPago.HasAttribute("RfcEmisorCtaOrd") Then pago.RfcEmisorCtaOrd = nPago.GetAttribute("RfcEmisorCtaOrd")
            If nPago.HasAttribute("NomBancoOrdExt") Then pago.NomBancoOrdExt = nPago.GetAttribute("NomBancoOrdExt")
            If nPago.HasAttribute("CtaOrdenante") Then pago.CtaOrdenante = nPago.GetAttribute("CtaOrdenante")
            If nPago.HasAttribute("RfcEmisorCtaBen") Then pago.RfcEmisorCtaBen = nPago.GetAttribute("RfcEmisorCtaBen")
            If nPago.HasAttribute("CtaBeneficiario") Then pago.CtaBeneficiario = nPago.GetAttribute("CtaBeneficiario")
            If nPago.HasAttribute("TipoCadPago") Then pago.TipoCadPago = nPago.GetAttribute("TipoCadPago")
            If nPago.HasAttribute("CertPago") Then pago.CertPago = nPago.GetAttribute("CertPago")
            If nPago.HasAttribute("CadPago") Then pago.CadPago = nPago.GetAttribute("CadPago")
            If nPago.HasAttribute("SelloPago") Then pago.SelloPago = nPago.GetAttribute("SelloPago")
            pago.DoctoRelacionado = ObtenerDoctoRelacionadoPago(nPago)
            pago.Impuestos = obtenerImpuestosPago(nPago)
            pagos.Pago.Add(pago)
        Next

        Return pagos
    End Function

    Private Shared Function ObtenerTotalesP(ByVal nodoPagos As XmlElement) As PTotales
        Dim lnTotales As XmlNodeList = nodoPagos.GetElementsByTagName("pago20:Totales")
        Dim totales As PTotales = New PTotales()
        If lnTotales.Count = 0 Then Return totales
        Dim nTotales As XmlElement = TryCast(lnTotales(0), XmlElement)
        If nTotales.HasAttribute("MontoTotalPagos") Then totales.MontoTotalPagos = Decimal.Parse(nTotales.GetAttribute("MontoTotalPagos"))
        If nTotales.HasAttribute("TotalRetencionesIEPS") Then totales.TotalRetencionesIEPS = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesIEPS"))
        If nTotales.HasAttribute("TotalRetencionesISR") Then totales.TotalRetencionesISR = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesISR"))
        If nTotales.HasAttribute("TotalRetencionesIVA") Then totales.TotalRetencionesIVA = Decimal.Parse(nTotales.GetAttribute("TotalRetencionesIVA"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA0") Then totales.TotalTrasladosBaseIVA0 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA0"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA16") Then totales.TotalTrasladosBaseIVA16 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA16"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVA8") Then totales.TotalTrasladosBaseIVA8 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVA8"))
        If nTotales.HasAttribute("TotalTrasladosBaseIVAExento") Then totales.TotalTrasladosBaseIVAExento = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosBaseIVAExento"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA0") Then totales.TotalTrasladosImpuestoIVA0 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA0"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA16") Then totales.TotalTrasladosImpuestoIVA16 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA16"))
        If nTotales.HasAttribute("TotalTrasladosImpuestoIVA8") Then totales.TotalTrasladosImpuestoIVA8 = Decimal.Parse(nTotales.GetAttribute("TotalTrasladosImpuestoIVA8"))
        Return totales
    End Function

    Private Shared Function ObtenerDoctoRelacionadoPago(ByVal nodoPago As XmlElement) As List(Of PDoctoRelacionado)
        Dim lnDoctoRelacionado As XmlNodeList = nodoPago.GetElementsByTagName("pago20:DoctoRelacionado")
        Dim listaDoctosRelacionados As List(Of PDoctoRelacionado) = New List(Of PDoctoRelacionado)()
        If lnDoctoRelacionado.Count = 0 Then Return listaDoctosRelacionados

        For Each nDoctoRelacionado As XmlElement In lnDoctoRelacionado
            Dim pDoctoRelacionado As PDoctoRelacionado = New PDoctoRelacionado()
            If nDoctoRelacionado.HasAttribute("IdDocumento") Then pDoctoRelacionado.IdDocumento = nDoctoRelacionado.GetAttribute("IdDocumento")
            If nDoctoRelacionado.HasAttribute("Serie") Then pDoctoRelacionado.Serie = nDoctoRelacionado.GetAttribute("Serie")
            If nDoctoRelacionado.HasAttribute("Folio") Then pDoctoRelacionado.Folio = nDoctoRelacionado.GetAttribute("Folio")
            If nDoctoRelacionado.HasAttribute("MonedaDR") Then pDoctoRelacionado.MonedaDR = nDoctoRelacionado.GetAttribute("MonedaDR")
            If nDoctoRelacionado.HasAttribute("EquivalenciaDR") Then pDoctoRelacionado.EquivalenciaDR = Decimal.Parse(nDoctoRelacionado.GetAttribute("EquivalenciaDR"))
            If nDoctoRelacionado.HasAttribute("NumParcialidad") Then pDoctoRelacionado.NumParcialidad = nDoctoRelacionado.GetAttribute("NumParcialidad")
            If nDoctoRelacionado.HasAttribute("ImpSaldoAnt") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoAnt"))
            If nDoctoRelacionado.HasAttribute("ImpPagado") Then pDoctoRelacionado.ImpPagado = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpPagado"))
            If nDoctoRelacionado.HasAttribute("ImpSaldoInsoluto") Then pDoctoRelacionado.ImpSaldoInsoluto = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoInsoluto"))
            If nDoctoRelacionado.HasAttribute("ObjetoImpDR") Then pDoctoRelacionado.ObjetoImpDR = nDoctoRelacionado.GetAttribute("ObjetoImpDR")
            pDoctoRelacionado.ImpuestosDR = ObtenerImpuestosDR(nDoctoRelacionado)
            listaDoctosRelacionados.Add(pDoctoRelacionado)
        Next

        Return listaDoctosRelacionados
    End Function

    Private Shared Function ObtenerImpuestosDR(ByVal nodoDoctoRelacionado As XmlElement) As ImpuestosDR
        'Dim impuestos As ImpuestosDR = Nothing
        Dim valDecimal As Decimal
        Dim lnImpuestosDR As XmlNodeList = nodoDoctoRelacionado.GetElementsByTagName("pago20:ImpuestosDR")
        If lnImpuestosDR.Count = 0 Then Return Nothing
        Dim nImpuestosDR As XmlElement = TryCast(lnImpuestosDR(0), XmlElement)
        Dim lPRetenciones As XmlNodeList = nImpuestosDR.GetElementsByTagName("pago20:RetencionesDR")

        Dim impuestos As ImpuestosDR = New ImpuestosDR


        Try
            If lPRetenciones.Count > 0 Then
                Dim retenciones As RetencionesDR = New RetencionesDR()
                retenciones.RetencionDR = New List(Of RetencionDR)()
                Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

                For Each nRetencionDR As XmlElement In nPRetenciones.GetElementsByTagName("pago20:RetencionDR")
                    Dim retencion As RetencionDR = New RetencionDR()
                    If nRetencionDR.HasAttribute("BaseDR") Then retencion.BaseDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("BaseDR"), valDecimal), valDecimal, 0)
                    If nRetencionDR.HasAttribute("ImpuestoDR") Then retencion.ImpuestoDR = nRetencionDR.GetAttribute("ImpuestoDR")
                    If nRetencionDR.HasAttribute("TipoFactorDR") Then retencion.TipoFactorDR = nRetencionDR.GetAttribute("TipoFactorDR")
                    If nRetencionDR.HasAttribute("TasaOCuotaDR") Then retencion.TasaOCuotaDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("TasaOCuotaDR"), valDecimal), valDecimal, 0)
                    If nRetencionDR.HasAttribute("ImporteDR") Then retencion.ImporteDR = If(Decimal.TryParse(nRetencionDR.GetAttribute("ImporteDR"), valDecimal), valDecimal, 0)
                    retenciones.RetencionDR.Add(retencion)
                Next
                impuestos.RetencionesDR = retenciones
            End If
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim lPTraslados As XmlNodeList = nImpuestosDR.GetElementsByTagName("pago20:TrasladosDR")

            If lPTraslados.Count > 0 Then
                Dim traslados As TrasladosDR = New TrasladosDR()
                traslados.TrasladoDR = New List(Of TrasladoDR)()
                Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

                For Each nTrasladoDR As XmlElement In nPTraslados.GetElementsByTagName("pago20:TrasladoDR")
                    Dim traslado As TrasladoDR = New TrasladoDR()
                    If nTrasladoDR.HasAttribute("BaseDR") Then traslado.BaseDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("BaseDR"), valDecimal), valDecimal, 0)
                    If nTrasladoDR.HasAttribute("ImpuestoDR") Then traslado.ImpuestoDR = nTrasladoDR.GetAttribute("ImpuestoDR")
                    If nTrasladoDR.HasAttribute("TipoFactorDR") Then traslado.TipoFactorDR = nTrasladoDR.GetAttribute("TipoFactorDR")
                    If nTrasladoDR.HasAttribute("TasaOCuotaDR") Then traslado.TasaOCuotaDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("TasaOCuotaDR"), valDecimal), valDecimal, 0)
                    If nTrasladoDR.HasAttribute("ImporteDR") Then traslado.ImporteDR = If(Decimal.TryParse(nTrasladoDR.GetAttribute("ImporteDR"), valDecimal), valDecimal, 0)
                    traslados.TrasladoDR.Add(traslado)
                Next

                impuestos.TrasladosDR = traslados
            End If
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        Return Impuestos
    End Function

    Private Shared Function obtenerImpuestosPago(ByVal nodoPago As XmlElement) As ImpuestosP
        Dim valDecimal As Decimal
        Dim impuestos As ImpuestosP = Nothing
        'pago.Impuestos = obtenerImpuestosPago(nPago)

        Dim lnImpuestos As XmlNodeList = nodoPago.GetElementsByTagName("pago20:ImpuestosP")
        If lnImpuestos.Count = 0 Then Return Nothing
        Dim nImpuestos As XmlElement = TryCast(lnImpuestos(0), XmlElement)
        Dim lPRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:RetencionesP")

        If lPRetenciones.Count > 0 Then
            Dim retenciones As RetencionesP = New RetencionesP()
            retenciones.RetencionP = New List(Of RetencionP)()
            Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

            For Each nPRetencion As XmlElement In nPRetenciones.GetElementsByTagName("pago10:RetencionP")
                Dim retencion As RetencionP = New RetencionP()
                If nPRetencion.HasAttribute("ImpuestoP") Then retencion.ImpuestoP = nPRetencion.GetAttribute("ImpuestoP")
                If nPRetencion.HasAttribute("ImporteP") Then retencion.ImporteP = If(Decimal.TryParse(nPRetencion.GetAttribute("ImporteP"), valDecimal), valDecimal, 0)
                retenciones.RetencionP.Add(retencion)
            Next

            impuestos.RetencionesP = retenciones
        End If

        Dim lPTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:TrasladosP")

        If lPTraslados.Count > 0 Then
            Dim traslados As TrasladosP = New TrasladosP()
            traslados.TrasladoP = New List(Of TrasladoP)()
            Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

            For Each nPTraslado As XmlElement In nPTraslados.GetElementsByTagName("pago10:TrasladoP")
                Dim traslado As TrasladoP = New TrasladoP()
                If nPTraslado.HasAttribute("BaseP") Then traslado.BaseP = If(Decimal.TryParse(nPTraslado.GetAttribute("BaseP"), valDecimal), valDecimal, 0)
                If nPTraslado.HasAttribute("ImpuestoP") Then traslado.ImpuestoP = nPTraslado.GetAttribute("ImpuestoP")
                If nPTraslado.HasAttribute("TipoFactorP") Then traslado.TipoFactorP = nPTraslado.GetAttribute("TipoFactorP")
                If nPTraslado.HasAttribute("TasaOCuotaP") Then traslado.TasaOCuotaP = If(Decimal.TryParse(nPTraslado.GetAttribute("TasaOCuotaP"), valDecimal), valDecimal, 0)
                If nPTraslado.HasAttribute("ImporteP") Then traslado.ImporteP = If(Decimal.TryParse(nPTraslado.GetAttribute("ImporteP"), valDecimal), valDecimal, 0)
                traslados.TrasladoP.Add(traslado)
            Next

            impuestos.TrasladosP = traslados
        End If

        Return impuestos
    End Function
#End Region
#Region "Complemento Pagos 1.0"
    'Private Function ObtenerNodoPagos(ByVal nodoComplemento As XmlElement) As Pagos
    '    Dim valDecimal As Decimal
    '    Dim fecha As DateTime
    '    Dim lPagos As XmlNodeList = nodoComplemento.GetElementsByTagName("pago10:Pagos")
    '    If lPagos.Count = 0 Then Return Nothing
    '    Dim pagos As Pagos = New Pagos()
    '    pagos.Pago = New List(Of Pago)()
    '    Dim nPagos As XmlElement = TryCast(lPagos(0), XmlElement)
    '    If nPagos.HasAttribute("Version") Then pagos.Version = nPagos.GetAttribute("Version")
    '    Dim lPago As XmlNodeList = nPagos.GetElementsByTagName("pago10:Pago")

    '    For Each nPago As XmlElement In lPago
    '        Dim pago As Pago = New Pago()
    '        If nPago.HasAttribute("FechaPago") Then pago.FechaPago = If(DateTime.TryParse(nPago.GetAttribute("FechaPago"), fecha), fecha, DateTime.Now)
    '        If nPago.HasAttribute("FormaDePagoP") Then pago.FormaDePagoP = nPago.GetAttribute("FormaDePagoP")
    '        If nPago.HasAttribute("MonedaP") Then pago.MonedaP = nPago.GetAttribute("MonedaP")
    '        If nPago.HasAttribute("TipoCambioP") Then pago.TipoCambioP = If(Decimal.TryParse(nPago.GetAttribute("TipoCambioP"), valDecimal), valDecimal, 0)
    '        If nPago.HasAttribute("Monto") Then pago.Monto = If(Decimal.TryParse(nPago.GetAttribute("Monto"), valDecimal), valDecimal, 0)
    '        If nPago.HasAttribute("NumOperacion") Then pago.NumOperacion = nPago.GetAttribute("NumOperacion")
    '        If nPago.HasAttribute("RfcEmisorCtaOrd") Then pago.RfcEmisorCtaOrd = nPago.GetAttribute("RfcEmisorCtaOrd")
    '        If nPago.HasAttribute("NomBancoOrdExt") Then pago.NomBancoOrdExt = nPago.GetAttribute("NomBancoOrdExt")
    '        If nPago.HasAttribute("CtaOrdenante") Then pago.CtaOrdenante = nPago.GetAttribute("CtaOrdenante")
    '        If nPago.HasAttribute("RfcEmisorCtaBen") Then pago.RfcEmisorCtaBen = nPago.GetAttribute("RfcEmisorCtaBen")
    '        If nPago.HasAttribute("CtaBeneficiario") Then pago.CtaBeneficiario = nPago.GetAttribute("CtaBeneficiario")
    '        If nPago.HasAttribute("TipoCadPago") Then pago.TipoCadPago = nPago.GetAttribute("TipoCadPago")
    '        If nPago.HasAttribute("CertPago") Then pago.CertPago = nPago.GetAttribute("CertPago")
    '        If nPago.HasAttribute("CadPago") Then pago.CadPago = nPago.GetAttribute("CadPago")
    '        If nPago.HasAttribute("SelloPago") Then pago.SelloPago = nPago.GetAttribute("SelloPago")
    '        pago.DoctoRelacionado = ObtenerDoctoRelacionadoPago(nPago)
    '        pago.Impuestos = obtenerImpuestosPago(nPago)
    '        pagos.Pago.Add(pago)
    '    Next

    '    Return pagos
    'End Function

    'Private Function ObtenerDoctoRelacionadoPago(ByVal nodoPago As XmlElement) As List(Of PDoctoRelacionado)
    '    Dim lnDoctoRelacionado As XmlNodeList = nodoPago.GetElementsByTagName("pago10:DoctoRelacionado")
    '    If lnDoctoRelacionado.Count = 0 Then Return Nothing
    '    Dim listaDoctosRelacionados As List(Of PDoctoRelacionado) = New List(Of PDoctoRelacionado)()

    '    For Each nDoctoRelacionado As XmlElement In lnDoctoRelacionado
    '        Dim pDoctoRelacionado As PDoctoRelacionado = New PDoctoRelacionado()
    '        If nDoctoRelacionado.HasAttribute("IdDocumento") Then pDoctoRelacionado.IdDocumento = nDoctoRelacionado.GetAttribute("IdDocumento")
    '        If nDoctoRelacionado.HasAttribute("Serie") Then pDoctoRelacionado.Serie = nDoctoRelacionado.GetAttribute("Serie")
    '        If nDoctoRelacionado.HasAttribute("Folio") Then pDoctoRelacionado.Folio = nDoctoRelacionado.GetAttribute("Folio")
    '        If nDoctoRelacionado.HasAttribute("MonedaDR") Then pDoctoRelacionado.MonedaDR = nDoctoRelacionado.GetAttribute("MonedaDR")
    '        If nDoctoRelacionado.HasAttribute("TipoCambioDR") Then pDoctoRelacionado.TipoCambioDR = Decimal.Parse(nDoctoRelacionado.GetAttribute("TipoCambioDR"))
    '        If nDoctoRelacionado.HasAttribute("MetodoDePagoDR") Then pDoctoRelacionado.MetodoDePagoDR = nDoctoRelacionado.GetAttribute("MetodoDePagoDR")
    '        If nDoctoRelacionado.HasAttribute("NumParcialidad") Then pDoctoRelacionado.NumParcialidad = nDoctoRelacionado.GetAttribute("NumParcialidad")
    '        If nDoctoRelacionado.HasAttribute("ImpSaldoAnt") Then pDoctoRelacionado.ImpSaldoAnt = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoAnt"))
    '        If nDoctoRelacionado.HasAttribute("ImpPagado") Then pDoctoRelacionado.ImpPagado = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpPagado"))
    '        If nDoctoRelacionado.HasAttribute("ImpSaldoInsoluto") Then pDoctoRelacionado.ImpSaldoInsoluto = Decimal.Parse(nDoctoRelacionado.GetAttribute("ImpSaldoInsoluto"))
    '        listaDoctosRelacionados.Add(pDoctoRelacionado)
    '    Next

    '    Return listaDoctosRelacionados
    'End Function

    'Private Function obtenerImpuestosPago(ByVal nodoPago As XmlElement) As List(Of PImpuestos)
    '    Dim valDecimal As Decimal
    '    Dim impuestos As PImpuestos = Nothing
    '    Dim lnImpuestos As XmlNodeList = nodoPago.GetElementsByTagName("pago10:Impuestos")
    '    If lnImpuestos.Count = 0 Then Return Nothing
    '    Dim listaImpuestos As List(Of PImpuestos) = New List(Of PImpuestos)()

    '    For Each nImpuestos As XmlElement In lnImpuestos
    '        If nImpuestos.HasAttribute("TotalImpuestosRetenidos") Then impuestos.TotalImpuestosRetenidos = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosRetenidos"), valDecimal), valDecimal, 0)
    '        If nImpuestos.HasAttribute("TotalImpuestosTrasladados") Then impuestos.TotalImpuestosTrasladados = If(Decimal.TryParse(nImpuestos.GetAttribute("TotalImpuestosTrasladados"), valDecimal), valDecimal, 0)
    '        Dim lPRetenciones As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:Retenciones")

    '        If lPRetenciones.Count > 0 Then
    '            Dim retenciones As PRetenciones = New PRetenciones()
    '            retenciones.Retencion = New List(Of PRetencion)()
    '            Dim nPRetenciones As XmlElement = TryCast(lPRetenciones(0), XmlElement)

    '            For Each nPRetencion As XmlElement In nPRetenciones.GetElementsByTagName("pago10:Retencion")
    '                Dim retencion As PRetencion = New PRetencion()
    '                If nPRetencion.HasAttribute("Impuesto") Then retencion.Impuesto = nPRetencion.GetAttribute("Impuesto")
    '                If nPRetencion.HasAttribute("Importe") Then retencion.Importe = If(Decimal.TryParse(nPRetencion.GetAttribute("Importe"), valDecimal), valDecimal, 0)
    '                retenciones.Retencion.Add(retencion)
    '            Next

    '            impuestos.Retenciones = retenciones
    '        End If

    '        Dim lPTraslados As XmlNodeList = nImpuestos.GetElementsByTagName("pago10:Traslados")

    '        If lPTraslados.Count > 0 Then
    '            Dim traslados As PTraslados = New PTraslados()
    '            traslados.Traslado = New List(Of PTraslado)()
    '            Dim nPTraslados As XmlElement = TryCast(lPTraslados(0), XmlElement)

    '            For Each nPTraslado As XmlElement In nPTraslados.GetElementsByTagName("pago10:Traslado")
    '                Dim traslado As PTraslado = New PTraslado()
    '                If nPTraslado.HasAttribute("Impuesto") Then traslado.Impuesto = nPTraslado.GetAttribute("Impuesto")
    '                If nPTraslado.HasAttribute("TipoFactor") Then traslado.TipoFactor = nPTraslado.GetAttribute("TipoFactor")
    '                If nPTraslado.HasAttribute("TasaOCuota") Then traslado.TasaOCuota = If(Decimal.TryParse(nPTraslado.GetAttribute("TasaOCuota"), valDecimal), valDecimal, 0)
    '                If nPTraslado.HasAttribute("Importe") Then traslado.Importe = If(Decimal.TryParse(nPTraslado.GetAttribute("Importe"), valDecimal), valDecimal, 0)
    '                traslados.Traslado.Add(traslado)
    '            Next

    '            impuestos.Traslados = traslados
    '        End If

    '        listaImpuestos.Add(impuestos)
    '    Next

    '    Return listaImpuestos
    'End Function
#End Region
#Region "Complemento Impuestos Locales"

    Private Function ObtenerNodoImpuestosLocales(ByVal documento As XmlDocument) As ImpuestosLocales
        Dim valDecimal As Decimal
        Dim lImpuestosLocales As XmlNodeList = documento.GetElementsByTagName("implocal:ImpuestosLocales")
        If lImpuestosLocales.Count <= 0 Then Return Nothing
        Dim nImpLocales As XmlElement = TryCast(lImpuestosLocales(0), XmlElement)
        Dim imlocal As ImpuestosLocales = New ImpuestosLocales()
        imlocal.Version = nImpLocales.GetAttribute("Version")
        imlocal.TotaldeRetenciones = If(Decimal.TryParse(nImpLocales.GetAttribute("TotaldeRetenciones"), valDecimal), valDecimal, 0)
        imlocal.TotalTraslasdos = If(Decimal.TryParse(nImpLocales.GetAttribute("TotaldeTraslados"), valDecimal), valDecimal, 0)
        imlocal.RetencionesLocales = ObtenerNodoRetencionesLocales(nImpLocales)
        imlocal.TrasladosLocales = ObtenerNodoTrasladosLocales(nImpLocales)
        Return imlocal
    End Function

    Private Function ObtenerNodoRetencionesLocales(ByVal nodoImpuestosLocales As XmlElement) As List(Of RetencionesLocales)
        Dim valDecimal As Decimal
        Dim lRetencionesLocales As XmlNodeList = nodoImpuestosLocales.GetElementsByTagName("implocal:RetencionesLocales")
        If lRetencionesLocales.Count = 0 Then Return Nothing
        Dim lista As List(Of RetencionesLocales) = New List(Of RetencionesLocales)()
        Dim nRetencionesLocales As XmlElement = TryCast(lRetencionesLocales(0), XmlElement)

        For Each nRetenLocal As XmlElement In lRetencionesLocales
            ' Dim RetenLocal As XmlElement = TryCast(nRetencionesLocales, XmlElement)
            Dim retenlocal As RetencionesLocales = New RetencionesLocales()
            retenlocal.ImpLocRetenido = nRetenLocal.GetAttribute("ImpLocRetenido ")
            retenlocal.TasadeRetencion = If(Decimal.TryParse(nRetenLocal.GetAttribute("TasadeRetencion"), valDecimal), valDecimal, 0)
            retenlocal.Importe = If(Decimal.TryParse(nRetenLocal.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            lista.Add(retenlocal)
        Next

        Return lista
    End Function

    Private Function ObtenerNodoTrasladosLocales(ByVal nodoImpuestosLocales As XmlElement) As List(Of TrasladosLocales)
        Dim valDecimal As Decimal
        Dim lTrasladosLocales As XmlNodeList = nodoImpuestosLocales.GetElementsByTagName("implocal:TrasladosLocales")
        If lTrasladosLocales.Count = 0 Then Return Nothing
        Dim lista As List(Of TrasladosLocales) = New List(Of TrasladosLocales)()
        Dim nTrasladosLocales As XmlElement = TryCast(lTrasladosLocales(0), XmlElement)

        For Each nTraslocal As XmlElement In lTrasladosLocales
            Dim TrasladosLocales As XmlElement = TryCast(nTrasladosLocales, XmlElement)
            Dim traslocal As TrasladosLocales = New TrasladosLocales()
            traslocal.ImpLocTraslado = nTrasladosLocales.GetAttribute("ImpLocTrasladado ")
            traslocal.TasaTraslado = If(Decimal.TryParse(nTrasladosLocales.GetAttribute("TasadeTraslado"), valDecimal), valDecimal, 0)
            traslocal.Importe = If(Decimal.TryParse(nTrasladosLocales.GetAttribute("Importe"), valDecimal), valDecimal, 0)
            lista.Add(traslocal)
        Next

        Return lista
    End Function
#End Region
#Region "Complemento Gastos Hidrocarburos"


    Private Function ObtenerNodoComplementoGastosHidroCarburos(ByVal nodoComprobante As XmlDocument) As GastosHidrocarburos
        Dim nlGastosHidrocarburos As XmlNodeList = nodoComprobante.GetElementsByTagName("gceh:GastosHidrocarburos")
        If nlGastosHidrocarburos.Count = 0 Then Return Nothing
        Dim gastosHidrocarburos As GastosHidrocarburos = New GastosHidrocarburos()
        Dim nGastosHidrocarburos As XmlElement = TryCast(nlGastosHidrocarburos(0), XmlElement)
        If nGastosHidrocarburos.HasAttribute("Version") Then gastosHidrocarburos.Version = nGastosHidrocarburos.GetAttribute("Version")
        If nGastosHidrocarburos.HasAttribute("NumeroContrato") Then gastosHidrocarburos.NumeroContrato = nGastosHidrocarburos.GetAttribute("NumeroContrato")
        If nGastosHidrocarburos.HasAttribute("AreaContractual") Then gastosHidrocarburos.AreaContractual = nGastosHidrocarburos.GetAttribute("AreaContractual")
        gastosHidrocarburos.Erogacion = ObtenerErogacionesGastosHidrocarburos(nGastosHidrocarburos)
        Return gastosHidrocarburos
    End Function

    Private Function ObtenerErogacionesGastosHidrocarburos(ByVal nGastosHidrocarburos As XmlElement) As List(Of Erogacion)
        Dim valDecimal As Decimal
        Dim nlErogaciones As XmlNodeList = nGastosHidrocarburos.GetElementsByTagName("gceh:Erogacion")
        If nlErogaciones.Count = 0 Then Return Nothing
        Dim listaErogaciones As List(Of Erogacion) = New List(Of Erogacion)()

        For Each nErogacion As XmlElement In nlErogaciones
            Dim erogacion As Erogacion = New Erogacion()
            If nErogacion.HasAttribute("TipoErogacion") Then erogacion.TipoErogacion = nErogacion.GetAttribute("TipoErogacion")
            If nErogacion.HasAttribute("MontocuErogacion") Then erogacion.MontocuErogacion = If(Decimal.TryParse(nErogacion.GetAttribute("MontocuErogacion"), valDecimal), valDecimal, 0)
            If nErogacion.HasAttribute("Porcentaje") Then erogacion.MontocuErogacion = If(Decimal.TryParse(nErogacion.GetAttribute("Porcentaje"), valDecimal), valDecimal, 0)
            erogacion.DocumentoRelacionado = ObtenerDocumentoRelacionadoErogacion(nErogacion)
            erogacion.Actividades = ObtenerActividadesErogacion(nErogacion)
            erogacion.CentroCostos = ObtenerCentroCostosErogacion(nErogacion)
            listaErogaciones.Add(erogacion)
        Next

        Return listaErogaciones
    End Function

    Private Function ObtenerDocumentoRelacionadoErogacion(ByVal nErogacion As XmlElement) As List(Of EDocumentoRelacionado)
        Dim valDecimal As Decimal
        Dim nDocumentosRelacionados As XmlNodeList = nErogacion.GetElementsByTagName("gceh:DocumentoRelacionado")
        If nDocumentosRelacionados.Count = 0 Then Return Nothing
        Dim listaDocumentoRelacionado As List(Of EDocumentoRelacionado) = New List(Of EDocumentoRelacionado)()

        For Each nDocumentoRelacionado As XmlElement In nDocumentosRelacionados
            Dim documentoRelacionado As EDocumentoRelacionado = New EDocumentoRelacionado()
            If nDocumentoRelacionado.HasAttribute("OrigenErogacion") Then documentoRelacionado.OrigenErogacion = nDocumentoRelacionado.GetAttribute("OrigenErogacion")
            If nDocumentoRelacionado.HasAttribute("FolioFiscalVinculado") Then documentoRelacionado.FolioFiscalVinculado = nDocumentoRelacionado.GetAttribute("FolioFiscalVinculado")
            If nDocumentoRelacionado.HasAttribute("RFCProveedor") Then documentoRelacionado.RFCProveedor = nDocumentoRelacionado.GetAttribute("RFCProveedor")
            If nDocumentoRelacionado.HasAttribute("MontoTotalIVA") Then documentoRelacionado.MontoTotalIVA = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoTotalIVA"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("MontoRetencionISR") Then documentoRelacionado.MontoRetencionISR = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoRetencionISR"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("MontoRetencionIVA") Then documentoRelacionado.MontoRetencionIVA = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoRetencionIVA"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("MontoRetencionOtrosImpuestos") Then documentoRelacionado.MontoRetencionOtrosImpuestos = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoRetencionOtrosImpuestos"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("NumeroPedimentoVinculado") Then documentoRelacionado.NumeroPedimentoVinculado = nDocumentoRelacionado.GetAttribute("NumeroPedimentoVinculado")
            If nDocumentoRelacionado.HasAttribute("ClavePedimentoVinculado") Then documentoRelacionado.ClavePedimentoVinculado = nDocumentoRelacionado.GetAttribute("ClavePedimentoVinculado")
            If nDocumentoRelacionado.HasAttribute("ClavePagoPedimentoVinculado") Then documentoRelacionado.ClavePagoPedimentoVinculado = nDocumentoRelacionado.GetAttribute("ClavePagoPedimentoVinculado")
            If nDocumentoRelacionado.HasAttribute("MontoIVAPedimento") Then documentoRelacionado.MontoIVAPedimento = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoIVAPedimento"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("OtrosImpuestosPagadosPedimento") Then documentoRelacionado.OtrosImpuestosPagadosPedimento = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("OtrosImpuestosPagadosPedimento"), valDecimal), valDecimal, 0)
            If nDocumentoRelacionado.HasAttribute("FechaFolioFiscalVinculado") Then documentoRelacionado.FechaFolioFiscalVinculado = nDocumentoRelacionado.GetAttribute("FechaFolioFiscalVinculado")
            If nDocumentoRelacionado.HasAttribute("Mes") Then documentoRelacionado.Mes = nDocumentoRelacionado.GetAttribute("Mes")
            If nDocumentoRelacionado.HasAttribute("MontoTotalErogaciones") Then documentoRelacionado.MontoTotalErogaciones = If(Decimal.TryParse(nDocumentoRelacionado.GetAttribute("MontoTotalErogaciones"), valDecimal), valDecimal, 0)
            listaDocumentoRelacionado.Add(documentoRelacionado)
        Next

        Return listaDocumentoRelacionado
    End Function

    Private Function ObtenerActividadesErogacion(ByVal nErogacion As XmlElement) As List(Of Actividades)
        Dim nActividades As XmlNodeList = nErogacion.GetElementsByTagName("gceh:SubActividades")
        If nActividades.Count = 0 Then Return Nothing
        Dim listaActividades As List(Of Actividades) = New List(Of Actividades)()

        For Each nActividad As XmlElement In nActividades
            Dim actividad As Actividades = New Actividades()
            If nActividad.HasAttribute("ActividadRelacionada") Then actividad.ActividadRelacionada = nActividad.GetAttribute("ActividadRelacionada")
            actividad.SubActividades = ObtenerSubActividadesErogacion(nErogacion)
            listaActividades.Add(actividad)
        Next

        Return listaActividades
    End Function

    Private Function ObtenerSubActividadesErogacion(ByVal nActividades As XmlElement) As List(Of SubActividades)
        Dim nSubActividades As XmlNodeList = nActividades.GetElementsByTagName("gceh:SubActividades")
        If nSubActividades.Count = 0 Then Return Nothing
        Dim listaSubActividades As List(Of SubActividades) = New List(Of SubActividades)()

        For Each nSubActividad As XmlElement In nSubActividades
            Dim subactividad As SubActividades = New SubActividades()
            If nSubActividad.HasAttribute("SubActividadRelacionada") Then subactividad.SubActividadRelacionada = nSubActividad.GetAttribute("SubActividadRelacionada")
            subactividad.Tareas = ObtenerTareasErogacion(nActividades)
            listaSubActividades.Add(subactividad)
        Next

        Return listaSubActividades
    End Function

    Private Function ObtenerTareasErogacion(ByVal nSubactividades As XmlElement) As List(Of Tareas)
        Dim nTareas As XmlNodeList = nSubactividades.GetElementsByTagName("gceh:Tareas")
        If nTareas.Count = 0 Then Return Nothing
        Dim listaTareas As List(Of Tareas) = New List(Of Tareas)()

        For Each nTarea As XmlElement In nTareas
            Dim tarea As Tareas = New Tareas()
            If nTarea.HasAttribute("TareaRelacionada") Then tarea.TareaRelacionada = nTarea.GetAttribute("TareaRelacionada")
            listaTareas.Add(tarea)
        Next

        Return listaTareas
    End Function

    Private Function ObtenerCentroCostosErogacion(ByVal nErogacion As XmlElement) As List(Of CentroCostos)
        Dim nCentrosCostos As XmlNodeList = nErogacion.GetElementsByTagName("gceh:Actividades")
        If nCentrosCostos.Count = 0 Then Return Nothing
        Dim ListaCentro As List(Of CentroCostos) = New List(Of CentroCostos)()

        For Each nCentroCosto As XmlElement In nCentrosCostos
            Dim centroCosto As CentroCostos = New CentroCostos()
            If nCentroCosto.HasAttribute("Campo") Then centroCosto.Campo = nCentroCosto.GetAttribute("Campo")
            centroCosto.Yacimientos = ObtenerYacimientosErogacion(nErogacion)
            ListaCentro.Add(centroCosto)
        Next

        Return ListaCentro
    End Function

    Private Function ObtenerYacimientosErogacion(ByVal nCentroCosto As XmlElement) As List(Of Yacimientos)
        Dim nYacimientos As XmlNodeList = nCentroCosto.GetElementsByTagName("gceh:Yacimientos")
        If nYacimientos.Count = 0 Then Return Nothing
        Dim ListaYacimientos As List(Of Yacimientos) = New List(Of Yacimientos)()

        For Each nYacimiento As XmlElement In nYacimientos
            Dim yacimiento As Yacimientos = New Yacimientos()
            If nYacimiento.HasAttribute("Yacimiento") Then yacimiento.Yacimiento = nYacimiento.GetAttribute("Yacimiento")
            yacimiento.Pozos = ObtenerPozosErogacion(nCentroCosto)
            ListaYacimientos.Add(yacimiento)
        Next

        Return ListaYacimientos
    End Function

    Private Function ObtenerPozosErogacion(ByVal nYacimientos As XmlElement) As List(Of Pozos)
        Dim nPozos As XmlNodeList = nYacimientos.GetElementsByTagName("gceh:Pozos")
        If nPozos.Count = 0 Then Return Nothing
        Dim listaPozos As List(Of Pozos) = New List(Of Pozos)()

        For Each nPozo As XmlElement In nPozos
            Dim pozo As Pozos = New Pozos()
            If nPozo.HasAttribute("Pozo") Then pozo.Pozo = nPozo.GetAttribute("Pozo")
            listaPozos.Add(pozo)
        Next

        Return listaPozos
    End Function
#End Region
#Region "Complemento Addenda"
    Private Function ObtenerNodoAdenda(ByVal documento As XmlDocument) As Addenda
        Dim lAdenda As XmlNodeList = documento.GetElementsByTagName("cfdi:Addendas")
        If lAdenda.Count = 0 Then Return Nothing
        Dim nAdenda As XmlElement = TryCast(lAdenda(0), XmlElement)
        Dim adenda As Addenda = New Addenda()
        If nAdenda.HasAttribute("Direccion1") Then adenda.Direccion = nAdenda.GetAttribute("Direccion1")
        Return adenda
    End Function
#End Region
#End Region
End Class
