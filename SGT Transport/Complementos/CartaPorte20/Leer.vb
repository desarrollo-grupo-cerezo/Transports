Imports System.Xml

Namespace CartaPorte20


    Public Class Leer
        Public Shared Function ObtenerNodoComplementoCartaPorte(ByVal documento As XmlElement) As CartaPorte
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
    End Class

End Namespace