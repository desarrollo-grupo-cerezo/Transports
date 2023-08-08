Imports System.Xml

Namespace CartaPorte20

    NotInheritable Class GenerarElement
        Private Shared NAMESPACE_CARTA_PORTE As String = "http://www.sat.gob.mx/CartaPorte20"

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

    End Class
End Namespace



