Namespace CartaPorte20


    Public Class CartaPorte
        Private _ubicaciones As Ubicaciones
        Private _mercancias As Mercancias
        Private _figuraTransporte As FiguraTransporte
        Private _version As String
        Private _transpInternac As String
        Private _entradaSalidaMerc As String
        Private _paisOrigenDestino As String
        Private _viaEntradaSalida As String
        Private _totalDistRec As Decimal

        Public Sub New()
            Me._version = "2.0"
        End Sub

        Public Property Ubicaciones As Ubicaciones
            Get
                Return Me._ubicaciones
            End Get
            Set(ByVal value As Ubicaciones)
                Me._ubicaciones = value
            End Set
        End Property

        Public Property Mercancias As Mercancias
            Get
                Return Me._mercancias
            End Get
            Set(ByVal value As Mercancias)
                Me._mercancias = value
            End Set
        End Property

        Public Property FiguraTransporte As FiguraTransporte
            Get
                Return Me._figuraTransporte
            End Get
            Set(ByVal value As FiguraTransporte)
                Me._figuraTransporte = value
            End Set
        End Property

        Public Property Version As String
            Get
                Return Me._version
            End Get
            Set(ByVal value As String)
                Me._version = value
            End Set
        End Property

        Public Property TranspInternac As String
            Get
                Return Me._transpInternac
            End Get
            Set(ByVal value As String)
                Me._transpInternac = value
            End Set
        End Property

        Public Property EntradaSalidaMerc As String
            Get
                Return Me._entradaSalidaMerc
            End Get
            Set(ByVal value As String)
                Me._entradaSalidaMerc = value
            End Set
        End Property

        Public Property PaisOrigenDestino As String
            Get
                Return Me._paisOrigenDestino
            End Get
            Set(ByVal value As String)
                Me._paisOrigenDestino = value
            End Set
        End Property

        Public Property ViaEntradaSalida As String
            Get
                Return Me._viaEntradaSalida
            End Get
            Set(ByVal value As String)
                Me._viaEntradaSalida = value
            End Set
        End Property

        Public Property TotalDistRec As Decimal
            Get
                Return Me._totalDistRec
            End Get
            Set(ByVal value As Decimal)
                Me._totalDistRec = value
            End Set
        End Property
    End Class

    Partial Public Class Ubicaciones
        Private _ubicacion As List(Of Ubicacion) = New List(Of Ubicacion)()

        Public Property Ubicacion As List(Of Ubicacion)
            Get
                Return Me._ubicacion
            End Get
            Set(ByVal value As List(Of Ubicacion))
                Me._ubicacion = value
            End Set
        End Property
    End Class

    Partial Public Class Ubicacion
        Private _domicilio As Domicilio
        Private _tipoUbicacion As String
        Private _iDUbicacion As String
        Private _rFCRemitenteDestinatario As String
        Private _nombreRemitenteDestinatario As String
        Private _numRegIdTrib As String
        Private _residenciaFiscal As String
        Private _numEstacion As String
        Private _nombreEstacion As String
        Private _navegacionTrafico As String
        Private _fechaHoraSalidaLlegada As DateTime
        Private _tipoEstacion As String
        Private _distanciaRecorrida As Decimal

        Public Property Domicilio As Domicilio
            Get
                Return Me._domicilio
            End Get
            Set(ByVal value As Domicilio)
                Me._domicilio = value
            End Set
        End Property

        Public Property TipoUbicacion As String
            Get
                Return Me._tipoUbicacion
            End Get
            Set(ByVal value As String)
                Me._tipoUbicacion = value
            End Set
        End Property

        Public Property IDUbicacion As String
            Get
                Return Me._iDUbicacion
            End Get
            Set(ByVal value As String)
                Me._iDUbicacion = value
            End Set
        End Property

        Public Property RFCRemitenteDestinatario As String
            Get
                Return Me._rFCRemitenteDestinatario
            End Get
            Set(ByVal value As String)
                Me._rFCRemitenteDestinatario = value
            End Set
        End Property

        Public Property NombreRemitenteDestinatario As String
            Get
                Return Me._nombreRemitenteDestinatario
            End Get
            Set(ByVal value As String)
                Me._nombreRemitenteDestinatario = value
            End Set
        End Property

        Public Property NumRegIdTrib As String
            Get
                Return Me._numRegIdTrib
            End Get
            Set(ByVal value As String)
                Me._numRegIdTrib = value
            End Set
        End Property

        Public Property ResidenciaFiscal As String
            Get
                Return Me._residenciaFiscal
            End Get
            Set(ByVal value As String)
                Me._residenciaFiscal = value
            End Set
        End Property

        Public Property NumEstacion As String
            Get
                Return Me._numEstacion
            End Get
            Set(ByVal value As String)
                Me._numEstacion = value
            End Set
        End Property

        Public Property NombreEstacion As String
            Get
                Return Me._nombreEstacion
            End Get
            Set(ByVal value As String)
                Me._nombreEstacion = value
            End Set
        End Property

        Public Property NavegacionTrafico As String
            Get
                Return Me._navegacionTrafico
            End Get
            Set(ByVal value As String)
                Me._navegacionTrafico = value
            End Set
        End Property

        Public Property FechaHoraSalidaLlegada As DateTime
            Get
                Return Me._fechaHoraSalidaLlegada
            End Get
            Set(ByVal value As DateTime)
                Me._fechaHoraSalidaLlegada = value
            End Set
        End Property

        Public Property TipoEstacion As String
            Get
                Return Me._tipoEstacion
            End Get
            Set(ByVal value As String)
                Me._tipoEstacion = value
            End Set
        End Property

        Public Property DistanciaRecorrida As Decimal
            Get
                Return Me._distanciaRecorrida
            End Get
            Set(ByVal value As Decimal)
                Me._distanciaRecorrida = value
            End Set
        End Property
    End Class

    Partial Public Class Domicilio
        Private _calle As String
        Private _numeroExterior As String
        Private _numeroInterior As String
        Private _colonia As String
        Private _localidad As String
        Private _referencia As String
        Private _municipio As String
        Private _estado As String
        Private _pais As String
        Private _codigoPostal As String

        Public Property Calle As String
            Get
                Return Me._calle
            End Get
            Set(ByVal value As String)
                Me._calle = value
            End Set
        End Property

        Public Property NumeroExterior As String
            Get
                Return Me._numeroExterior
            End Get
            Set(ByVal value As String)
                Me._numeroExterior = value
            End Set
        End Property

        Public Property NumeroInterior As String
            Get
                Return Me._numeroInterior
            End Get
            Set(ByVal value As String)
                Me._numeroInterior = value
            End Set
        End Property

        Public Property Colonia As String
            Get
                Return Me._colonia
            End Get
            Set(ByVal value As String)
                Me._colonia = value
            End Set
        End Property

        Public Property Localidad As String
            Get
                Return Me._localidad
            End Get
            Set(ByVal value As String)
                Me._localidad = value
            End Set
        End Property

        Public Property Referencia As String
            Get
                Return Me._referencia
            End Get
            Set(ByVal value As String)
                Me._referencia = value
            End Set
        End Property

        Public Property Municipio As String
            Get
                Return Me._municipio
            End Get
            Set(ByVal value As String)
                Me._municipio = value
            End Set
        End Property

        Public Property Estado As String
            Get
                Return Me._estado
            End Get
            Set(ByVal value As String)
                Me._estado = value
            End Set
        End Property

        Public Property Pais As String
            Get
                Return Me._pais
            End Get
            Set(ByVal value As String)
                Me._pais = value
            End Set
        End Property

        Public Property CodigoPostal As String
            Get
                Return Me._codigoPostal
            End Get
            Set(ByVal value As String)
                Me._codigoPostal = value
            End Set
        End Property
    End Class

    Partial Public Class Mercancias
        Private _mercancia As List(Of Mercancia) = New List(Of Mercancia)()
        Private _autotransporte As Autotransporte
        Private _transporteMaritimo As TransporteMaritimo
        Private _transporteAereo As TransporteAereo
        Private _transporteFerroviario As TransporteFerroviario
        Private _pesoBrutoTotal As Decimal
        Private _unidadPeso As String
        Private _pesoNetoTotal As Decimal
        Private _numTotalMercancias As Integer
        Private _cargoPorTasacion As Decimal

        Public Property Mercancia As List(Of Mercancia)
            Get
                Return Me._mercancia
            End Get
            Set(ByVal value As List(Of Mercancia))
                Me._mercancia = value
            End Set
        End Property

        Public Property Autotransporte As Autotransporte
            Get
                Return Me._autotransporte
            End Get
            Set(ByVal value As Autotransporte)
                Me._autotransporte = value
            End Set
        End Property

        Public Property TransporteMaritimo As TransporteMaritimo
            Get
                Return Me._transporteMaritimo
            End Get
            Set(ByVal value As TransporteMaritimo)
                Me._transporteMaritimo = value
            End Set
        End Property

        Public Property TransporteAereo As TransporteAereo
            Get
                Return Me._transporteAereo
            End Get
            Set(ByVal value As TransporteAereo)
                Me._transporteAereo = value
            End Set
        End Property

        Public Property TransporteFerroviario As TransporteFerroviario
            Get
                Return Me._transporteFerroviario
            End Get
            Set(ByVal value As TransporteFerroviario)
                Me._transporteFerroviario = value
            End Set
        End Property

        Public Property PesoBrutoTotal As Decimal
            Get
                Return Me._pesoBrutoTotal
            End Get
            Set(ByVal value As Decimal)
                Me._pesoBrutoTotal = value
            End Set
        End Property

        Public Property UnidadPeso As String
            Get
                Return Me._unidadPeso
            End Get
            Set(ByVal value As String)
                Me._unidadPeso = value
            End Set
        End Property

        Public Property PesoNetoTotal As Decimal
            Get
                Return Me._pesoNetoTotal
            End Get
            Set(ByVal value As Decimal)
                Me._pesoNetoTotal = value
            End Set
        End Property

        Public Property NumTotalMercancias As Integer
            Get
                Return Me._numTotalMercancias
            End Get
            Set(ByVal value As Integer)
                Me._numTotalMercancias = value
            End Set
        End Property

        Public Property CargoPorTasacion As Decimal
            Get
                Return Me._cargoPorTasacion
            End Get
            Set(ByVal value As Decimal)
                Me._cargoPorTasacion = value
            End Set
        End Property
    End Class

    Partial Public Class Mercancia
        Private _pedimentos As List(Of Pedimentos) = New List(Of Pedimentos)()
        Private _guiasIdentificacion As List(Of GuiasIdentificacion) = New List(Of GuiasIdentificacion)()
        Private _cantidadTransporta As List(Of CantidadTransporta) = New List(Of CantidadTransporta)()
        Private _detalleMercancia As DetalleMercancia
        Private _bienesTransp As String
        Private _claveSTCC As String
        Private _descripcion As String
        Private _cantidad As Decimal
        Private _claveUnidad As String
        Private _unidad As String
        Private _dimensiones As String
        Private _materialPeligroso As String
        Private _cveMaterialPeligroso As String
        Private _embalaje As String
        Private _descripEmbalaje As String
        Private _pesoEnKg As Decimal
        Private _valorMercancia As Decimal
        Private _moneda As String
        Private _fraccionArancelaria As String
        Private _uUIDComercioExt As String

        Public Property Pedimentos As List(Of Pedimentos)
            Get
                Return Me._pedimentos
            End Get
            Set(ByVal value As List(Of Pedimentos))
                Me._pedimentos = value
            End Set
        End Property

        Public Property GuiasIdentificacion As List(Of GuiasIdentificacion)
            Get
                Return Me._guiasIdentificacion
            End Get
            Set(ByVal value As List(Of GuiasIdentificacion))
                Me._guiasIdentificacion = value
            End Set
        End Property

        Public Property CantidadTransporta As List(Of CantidadTransporta)
            Get
                Return Me._cantidadTransporta
            End Get
            Set(ByVal value As List(Of CantidadTransporta))
                Me._cantidadTransporta = value
            End Set
        End Property

        Public Property DetalleMercancia As DetalleMercancia
            Get
                Return Me._detalleMercancia
            End Get
            Set(ByVal value As DetalleMercancia)
                Me._detalleMercancia = value
            End Set
        End Property

        Public Property BienesTransp As String
            Get
                Return Me._bienesTransp
            End Get
            Set(ByVal value As String)
                Me._bienesTransp = value
            End Set
        End Property

        Public Property ClaveSTCC As String
            Get
                Return Me._claveSTCC
            End Get
            Set(ByVal value As String)
                Me._claveSTCC = value
            End Set
        End Property

        Public Property Descripcion As String
            Get
                Return Me._descripcion
            End Get
            Set(ByVal value As String)
                Me._descripcion = value
            End Set
        End Property

        Public Property Cantidad As Decimal
            Get
                Return Me._cantidad
            End Get
            Set(ByVal value As Decimal)
                Me._cantidad = value
            End Set
        End Property

        Public Property ClaveUnidad As String
            Get
                Return Me._claveUnidad
            End Get
            Set(ByVal value As String)
                Me._claveUnidad = value
            End Set
        End Property

        Public Property Unidad As String
            Get
                Return Me._unidad
            End Get
            Set(ByVal value As String)
                Me._unidad = value
            End Set
        End Property

        Public Property Dimensiones As String
            Get
                Return Me._dimensiones
            End Get
            Set(ByVal value As String)
                Me._dimensiones = value
            End Set
        End Property

        Public Property MaterialPeligroso As String
            Get
                Return Me._materialPeligroso
            End Get
            Set(ByVal value As String)
                Me._materialPeligroso = value
            End Set
        End Property

        Public Property CveMaterialPeligroso As String
            Get
                Return Me._cveMaterialPeligroso
            End Get
            Set(ByVal value As String)
                Me._cveMaterialPeligroso = value
            End Set
        End Property

        Public Property Embalaje As String
            Get
                Return Me._embalaje
            End Get
            Set(ByVal value As String)
                Me._embalaje = value
            End Set
        End Property

        Public Property DescripEmbalaje As String
            Get
                Return Me._descripEmbalaje
            End Get
            Set(ByVal value As String)
                Me._descripEmbalaje = value
            End Set
        End Property

        Public Property PesoEnKg As Decimal
            Get
                Return Me._pesoEnKg
            End Get
            Set(ByVal value As Decimal)
                Me._pesoEnKg = value
            End Set
        End Property

        Public Property ValorMercancia As Decimal
            Get
                Return Me._valorMercancia
            End Get
            Set(ByVal value As Decimal)
                Me._valorMercancia = value
            End Set
        End Property

        Public Property Moneda As String
            Get
                Return Me._moneda
            End Get
            Set(ByVal value As String)
                Me._moneda = value
            End Set
        End Property

        Public Property FraccionArancelaria As String
            Get
                Return Me._fraccionArancelaria
            End Get
            Set(ByVal value As String)
                Me._fraccionArancelaria = value
            End Set
        End Property

        Public Property UUIDComercioExt As String
            Get
                Return Me._uUIDComercioExt
            End Get
            Set(ByVal value As String)
                Me._uUIDComercioExt = value
            End Set
        End Property
    End Class

    Partial Public Class Pedimentos
        Private _pedimento As String

        Public Property Pedimento As String
            Get
                Return Me._pedimento
            End Get
            Set(ByVal value As String)
                Me._pedimento = value
            End Set
        End Property
    End Class

    Partial Public Class GuiasIdentificacion
        Private _numeroGuiaIdentificacion As String
        Private _descripGuiaIdentificacion As String
        Private _pesoGuiaIdentificacion As Decimal

        Public Property NumeroGuiaIdentificacion As String
            Get
                Return Me._numeroGuiaIdentificacion
            End Get
            Set(ByVal value As String)
                Me._numeroGuiaIdentificacion = value
            End Set
        End Property

        Public Property DescripGuiaIdentificacion As String
            Get
                Return Me._descripGuiaIdentificacion
            End Get
            Set(ByVal value As String)
                Me._descripGuiaIdentificacion = value
            End Set
        End Property

        Public Property PesoGuiaIdentificacion As Decimal
            Get
                Return Me._pesoGuiaIdentificacion
            End Get
            Set(ByVal value As Decimal)
                Me._pesoGuiaIdentificacion = value
            End Set
        End Property
    End Class

    Partial Public Class CantidadTransporta
        Private _cantidad As Decimal
        Private _iDOrigen As String
        Private _iDDestino As String
        Private _cvesTransporte As String

        Public Property Cantidad As Decimal
            Get
                Return Me._cantidad
            End Get
            Set(ByVal value As Decimal)
                Me._cantidad = value
            End Set
        End Property

        Public Property IDOrigen As String
            Get
                Return Me._iDOrigen
            End Get
            Set(ByVal value As String)
                Me._iDOrigen = value
            End Set
        End Property

        Public Property IDDestino As String
            Get
                Return Me._iDDestino
            End Get
            Set(ByVal value As String)
                Me._iDDestino = value
            End Set
        End Property

        Public Property CvesTransporte As String
            Get
                Return Me._cvesTransporte
            End Get
            Set(ByVal value As String)
                Me._cvesTransporte = value
            End Set
        End Property
    End Class

    Partial Public Class DetalleMercancia
        Private _unidadPesoMerc As String
        Private _pesoBruto As Decimal
        Private _pesoNeto As Decimal
        Private _pesoTara As Decimal
        Private _numPiezas As Integer

        Public Property UnidadPesoMerc As String
            Get
                Return Me._unidadPesoMerc
            End Get
            Set(ByVal value As String)
                Me._unidadPesoMerc = value
            End Set
        End Property

        Public Property PesoBruto As Decimal
            Get
                Return Me._pesoBruto
            End Get
            Set(ByVal value As Decimal)
                Me._pesoBruto = value
            End Set
        End Property

        Public Property PesoNeto As Decimal
            Get
                Return Me._pesoNeto
            End Get
            Set(ByVal value As Decimal)
                Me._pesoNeto = value
            End Set
        End Property

        Public Property PesoTara As Decimal
            Get
                Return Me._pesoTara
            End Get
            Set(ByVal value As Decimal)
                Me._pesoTara = value
            End Set
        End Property

        Public Property NumPiezas As Integer
            Get
                Return Me._numPiezas
            End Get
            Set(ByVal value As Integer)
                Me._numPiezas = value
            End Set
        End Property
    End Class

    Partial Public Class Autotransporte
        Private _identificacionVehicular As IdentificacionVehicular
        Private _seguros As Seguros
        Private _remolques As Remolques
        Private _permSCT As String
        Private _numPermisoSCT As String

        Public Property IdentificacionVehicular As IdentificacionVehicular
            Get
                Return Me._identificacionVehicular
            End Get
            Set(ByVal value As IdentificacionVehicular)
                Me._identificacionVehicular = value
            End Set
        End Property

        Public Property Seguros As Seguros
            Get
                Return Me._seguros
            End Get
            Set(ByVal value As Seguros)
                Me._seguros = value
            End Set
        End Property

        Public Property Remolques As Remolques
            Get
                Return Me._remolques
            End Get
            Set(ByVal value As Remolques)
                Me._remolques = value
            End Set
        End Property

        Public Property PermSCT As String
            Get
                Return Me._permSCT
            End Get
            Set(ByVal value As String)
                Me._permSCT = value
            End Set
        End Property

        Public Property NumPermisoSCT As String
            Get
                Return Me._numPermisoSCT
            End Get
            Set(ByVal value As String)
                Me._numPermisoSCT = value
            End Set
        End Property
    End Class

    Partial Public Class IdentificacionVehicular
        Private _configVehicular As String
        Private _placaVM As String
        Private _anioModeloVM As Integer

        Public Property ConfigVehicular As String
            Get
                Return Me._configVehicular
            End Get
            Set(ByVal value As String)
                Me._configVehicular = value
            End Set
        End Property

        Public Property PlacaVM As String
            Get
                Return Me._placaVM
            End Get
            Set(ByVal value As String)
                Me._placaVM = value
            End Set
        End Property

        Public Property AnioModeloVM As Integer
            Get
                Return Me._anioModeloVM
            End Get
            Set(ByVal value As Integer)
                Me._anioModeloVM = value
            End Set
        End Property
    End Class

    Partial Public Class Seguros
        Private _aseguraRespCivil As String
        Private _polizaRespCivil As String
        Private _aseguraMedAmbiente As String
        Private _polizaMedAmbiente As String
        Private _aseguraCarga As String
        Private _polizaCarga As String
        Private _primaSeguro As Decimal = -1

        Public Property AseguraRespCivil As String
            Get
                Return Me._aseguraRespCivil
            End Get
            Set(ByVal value As String)
                Me._aseguraRespCivil = value
            End Set
        End Property

        Public Property PolizaRespCivil As String
            Get
                Return Me._polizaRespCivil
            End Get
            Set(ByVal value As String)
                Me._polizaRespCivil = value
            End Set
        End Property

        Public Property AseguraMedAmbiente As String
            Get
                Return Me._aseguraMedAmbiente
            End Get
            Set(ByVal value As String)
                Me._aseguraMedAmbiente = value
            End Set
        End Property

        Public Property PolizaMedAmbiente As String
            Get
                Return Me._polizaMedAmbiente
            End Get
            Set(ByVal value As String)
                Me._polizaMedAmbiente = value
            End Set
        End Property

        Public Property AseguraCarga As String
            Get
                Return Me._aseguraCarga
            End Get
            Set(ByVal value As String)
                Me._aseguraCarga = value
            End Set
        End Property

        Public Property PolizaCarga As String
            Get
                Return Me._polizaCarga
            End Get
            Set(ByVal value As String)
                Me._polizaCarga = value
            End Set
        End Property

        Public Property PrimaSeguro As Decimal
            Get
                Return Me._primaSeguro
            End Get
            Set(ByVal value As Decimal)
                Me._primaSeguro = value
            End Set
        End Property
    End Class

    Partial Public Class Remolques
        Private _remolque As List(Of Remolque) = New List(Of Remolque)()

        Public Property Remolque As List(Of Remolque)
            Get
                Return Me._remolque
            End Get
            Set(ByVal value As List(Of Remolque))
                Me._remolque = value
            End Set
        End Property
    End Class

    Partial Public Class Remolque
        Private _subTipoRem As String
        Private _placa As String

        Public Property SubTipoRem As String
            Get
                Return Me._subTipoRem
            End Get
            Set(ByVal value As String)
                Me._subTipoRem = value
            End Set
        End Property

        Public Property Placa As String
            Get
                Return Me._placa
            End Get
            Set(ByVal value As String)
                Me._placa = value
            End Set
        End Property
    End Class

    Partial Public Class TransporteMaritimo
        Private _contenedor As List(Of Contenedor) = New List(Of Contenedor)()
        Private _permSCT As String
        Private _numPermisoSCT As String
        Private _nombreAseg As String
        Private _numPolizaSeguro As String
        Private _tipoEmbarcacion As String
        Private _matricula As String
        Private _numeroOMI As String
        Private _anioEmbarcacion As Integer
        Private _nombreEmbarc As String
        Private _nacionalidadEmbarc As String
        Private _unidadesDeArqBruto As Decimal
        Private _tipoCarga As String
        Private _numCertITC As String
        Private _eslora As Decimal = -1
        Private _manga As Decimal = -1
        Private _calado As Decimal = -1
        Private _lineaNaviera As String
        Private _nombreAgenteNaviero As String
        Private _numAutorizacionNaviero As String
        Private _numViaje As String
        Private _numConocEmbarc As String

        Public Property Contenedor As List(Of Contenedor)
            Get
                Return Me._contenedor
            End Get
            Set(ByVal value As List(Of Contenedor))
                Me._contenedor = value
            End Set
        End Property

        Public Property PermSCT As String
            Get
                Return Me._permSCT
            End Get
            Set(ByVal value As String)
                Me._permSCT = value
            End Set
        End Property

        Public Property NumPermisoSCT As String
            Get
                Return Me._numPermisoSCT
            End Get
            Set(ByVal value As String)
                Me._numPermisoSCT = value
            End Set
        End Property

        Public Property NombreAseg As String
            Get
                Return Me._nombreAseg
            End Get
            Set(ByVal value As String)
                Me._nombreAseg = value
            End Set
        End Property

        Public Property NumPolizaSeguro As String
            Get
                Return Me._numPolizaSeguro
            End Get
            Set(ByVal value As String)
                Me._numPolizaSeguro = value
            End Set
        End Property

        Public Property TipoEmbarcacion As String
            Get
                Return Me._tipoEmbarcacion
            End Get
            Set(ByVal value As String)
                Me._tipoEmbarcacion = value
            End Set
        End Property

        Public Property Matricula As String
            Get
                Return Me._matricula
            End Get
            Set(ByVal value As String)
                Me._matricula = value
            End Set
        End Property

        Public Property NumeroOMI As String
            Get
                Return Me._numeroOMI
            End Get
            Set(ByVal value As String)
                Me._numeroOMI = value
            End Set
        End Property

        Public Property AnioEmbarcacion As Integer
            Get
                Return Me._anioEmbarcacion
            End Get
            Set(ByVal value As Integer)
                Me._anioEmbarcacion = value
            End Set
        End Property

        Public Property NombreEmbarc As String
            Get
                Return Me._nombreEmbarc
            End Get
            Set(ByVal value As String)
                Me._nombreEmbarc = value
            End Set
        End Property

        Public Property NacionalidadEmbarc As String
            Get
                Return Me._nacionalidadEmbarc
            End Get
            Set(ByVal value As String)
                Me._nacionalidadEmbarc = value
            End Set
        End Property

        Public Property UnidadesDeArqBruto As Decimal
            Get
                Return Me._unidadesDeArqBruto
            End Get
            Set(ByVal value As Decimal)
                Me._unidadesDeArqBruto = value
            End Set
        End Property

        Public Property TipoCarga As String
            Get
                Return Me._tipoCarga
            End Get
            Set(ByVal value As String)
                Me._tipoCarga = value
            End Set
        End Property

        Public Property NumCertITC As String
            Get
                Return Me._numCertITC
            End Get
            Set(ByVal value As String)
                Me._numCertITC = value
            End Set
        End Property

        Public Property Eslora As Decimal
            Get
                Return Me._eslora
            End Get
            Set(ByVal value As Decimal)
                Me._eslora = value
            End Set
        End Property

        Public Property Manga As Decimal
            Get
                Return Me._manga
            End Get
            Set(ByVal value As Decimal)
                Me._manga = value
            End Set
        End Property

        Public Property Calado As Decimal
            Get
                Return Me._calado
            End Get
            Set(ByVal value As Decimal)
                Me._calado = value
            End Set
        End Property

        Public Property LineaNaviera As String
            Get
                Return Me._lineaNaviera
            End Get
            Set(ByVal value As String)
                Me._lineaNaviera = value
            End Set
        End Property

        Public Property NombreAgenteNaviero As String
            Get
                Return Me._nombreAgenteNaviero
            End Get
            Set(ByVal value As String)
                Me._nombreAgenteNaviero = value
            End Set
        End Property

        Public Property NumAutorizacionNaviero As String
            Get
                Return Me._numAutorizacionNaviero
            End Get
            Set(ByVal value As String)
                Me._numAutorizacionNaviero = value
            End Set
        End Property

        Public Property NumViaje As String
            Get
                Return Me._numViaje
            End Get
            Set(ByVal value As String)
                Me._numViaje = value
            End Set
        End Property

        Public Property NumConocEmbarc As String
            Get
                Return Me._numConocEmbarc
            End Get
            Set(ByVal value As String)
                Me._numConocEmbarc = value
            End Set
        End Property
    End Class

    Partial Public Class Contenedor
        Private _matriculaContenedor As String
        Private _tipoContenedor As String
        Private _numPrecinto As String

        Public Property MatriculaContenedor As String
            Get
                Return Me._matriculaContenedor
            End Get
            Set(ByVal value As String)
                Me._matriculaContenedor = value
            End Set
        End Property

        Public Property TipoContenedor As String
            Get
                Return Me._tipoContenedor
            End Get
            Set(ByVal value As String)
                Me._tipoContenedor = value
            End Set
        End Property

        Public Property NumPrecinto As String
            Get
                Return Me._numPrecinto
            End Get
            Set(ByVal value As String)
                Me._numPrecinto = value
            End Set
        End Property
    End Class

    Partial Public Class TransporteAereo
        Private _permSCT As String
        Private _numPermisoSCT As String
        Private _matriculaAeronave As String
        Private _nombreAseg As String
        Private _numPolizaSeguro As String
        Private _numeroGuia As String
        Private _lugarContrato As String
        Private _codigoTransportista As String
        Private _rFCEmbarcador As String
        Private _numRegIdTribEmbarc As String
        Private _residenciaFiscalEmbarc As String
        Private _nombreEmbarcador As String

        Public Property PermSCT As String
            Get
                Return Me._permSCT
            End Get
            Set(ByVal value As String)
                Me._permSCT = value
            End Set
        End Property

        Public Property NumPermisoSCT As String
            Get
                Return Me._numPermisoSCT
            End Get
            Set(ByVal value As String)
                Me._numPermisoSCT = value
            End Set
        End Property

        Public Property MatriculaAeronave As String
            Get
                Return Me._matriculaAeronave
            End Get
            Set(ByVal value As String)
                Me._matriculaAeronave = value
            End Set
        End Property

        Public Property NombreAseg As String
            Get
                Return Me._nombreAseg
            End Get
            Set(ByVal value As String)
                Me._nombreAseg = value
            End Set
        End Property

        Public Property NumPolizaSeguro As String
            Get
                Return Me._numPolizaSeguro
            End Get
            Set(ByVal value As String)
                Me._numPolizaSeguro = value
            End Set
        End Property

        Public Property NumeroGuia As String
            Get
                Return Me._numeroGuia
            End Get
            Set(ByVal value As String)
                Me._numeroGuia = value
            End Set
        End Property

        Public Property LugarContrato As String
            Get
                Return Me._lugarContrato
            End Get
            Set(ByVal value As String)
                Me._lugarContrato = value
            End Set
        End Property

        Public Property CodigoTransportista As String
            Get
                Return Me._codigoTransportista
            End Get
            Set(ByVal value As String)
                Me._codigoTransportista = value
            End Set
        End Property

        Public Property RFCEmbarcador As String
            Get
                Return Me._rFCEmbarcador
            End Get
            Set(ByVal value As String)
                Me._rFCEmbarcador = value
            End Set
        End Property

        Public Property NumRegIdTribEmbarc As String
            Get
                Return Me._numRegIdTribEmbarc
            End Get
            Set(ByVal value As String)
                Me._numRegIdTribEmbarc = value
            End Set
        End Property

        Public Property ResidenciaFiscalEmbarc As String
            Get
                Return Me._residenciaFiscalEmbarc
            End Get
            Set(ByVal value As String)
                Me._residenciaFiscalEmbarc = value
            End Set
        End Property

        Public Property NombreEmbarcador As String
            Get
                Return Me._nombreEmbarcador
            End Get
            Set(ByVal value As String)
                Me._nombreEmbarcador = value
            End Set
        End Property
    End Class

    Partial Public Class TransporteFerroviario
        Private _derechosDePaso As List(Of DerechosDePaso) = New List(Of DerechosDePaso)()
        Private _carro As List(Of Carro)
        Private _tipoDeServicio As String
        Private _tipoDeTrafico As String
        Private _nombreAseg As String
        Private _numPolizaSeguro As String

        Public Property DerechosDePaso As List(Of DerechosDePaso)
            Get
                Return Me._derechosDePaso
            End Get
            Set(ByVal value As List(Of DerechosDePaso))
                Me._derechosDePaso = value
            End Set
        End Property

        Public Property Carro As List(Of Carro)
            Get
                Return Me._carro
            End Get
            Set(ByVal value As List(Of Carro))
                Me._carro = value
            End Set
        End Property

        Public Property TipoDeServicio As String
            Get
                Return Me._tipoDeServicio
            End Get
            Set(ByVal value As String)
                Me._tipoDeServicio = value
            End Set
        End Property

        Public Property TipoDeTrafico As String
            Get
                Return Me._tipoDeTrafico
            End Get
            Set(ByVal value As String)
                Me._tipoDeTrafico = value
            End Set
        End Property

        Public Property NombreAseg As String
            Get
                Return Me._nombreAseg
            End Get
            Set(ByVal value As String)
                Me._nombreAseg = value
            End Set
        End Property

        Public Property NumPolizaSeguro As String
            Get
                Return Me._numPolizaSeguro
            End Get
            Set(ByVal value As String)
                Me._numPolizaSeguro = value
            End Set
        End Property
    End Class

    Partial Public Class DerechosDePaso
        Private _tipoDerechoDePaso As String
        Private _kilometrajePagado As Decimal

        Public Property TipoDerechoDePaso As String
            Get
                Return Me._tipoDerechoDePaso
            End Get
            Set(ByVal value As String)
                Me._tipoDerechoDePaso = value
            End Set
        End Property

        Public Property KilometrajePagado As Decimal
            Get
                Return Me._kilometrajePagado
            End Get
            Set(ByVal value As Decimal)
                Me._kilometrajePagado = value
            End Set
        End Property
    End Class

    Partial Public Class Carro
        Private _contenedor As List(Of CarroContenedor) = New List(Of CarroContenedor)()
        Private _tipoCarro As String
        Private _matriculaCarro As String
        Private _guiaCarro As String
        Private _toneladasNetasCarro As Decimal

        Public Property Contenedor As List(Of CarroContenedor)
            Get
                Return Me._contenedor
            End Get
            Set(ByVal value As List(Of CarroContenedor))
                Me._contenedor = value
            End Set
        End Property

        Public Property TipoCarro As String
            Get
                Return Me._tipoCarro
            End Get
            Set(ByVal value As String)
                Me._tipoCarro = value
            End Set
        End Property

        Public Property MatriculaCarro As String
            Get
                Return Me._matriculaCarro
            End Get
            Set(ByVal value As String)
                Me._matriculaCarro = value
            End Set
        End Property

        Public Property GuiaCarro As String
            Get
                Return Me._guiaCarro
            End Get
            Set(ByVal value As String)
                Me._guiaCarro = value
            End Set
        End Property

        Public Property ToneladasNetasCarro As Decimal
            Get
                Return Me._toneladasNetasCarro
            End Get
            Set(ByVal value As Decimal)
                Me._toneladasNetasCarro = value
            End Set
        End Property
    End Class

    Partial Public Class CarroContenedor
        Private _tipoContenedor As String
        Private _pesoContenedorVacio As Decimal
        Private _pesoNetoMercancia As Decimal

        Public Property TipoContenedor As String
            Get
                Return Me._tipoContenedor
            End Get
            Set(ByVal value As String)
                Me._tipoContenedor = value
            End Set
        End Property

        Public Property PesoContenedorVacio As Decimal
            Get
                Return Me._pesoContenedorVacio
            End Get
            Set(ByVal value As Decimal)
                Me._pesoContenedorVacio = value
            End Set
        End Property

        Public Property PesoNetoMercancia As Decimal
            Get
                Return Me._pesoNetoMercancia
            End Get
            Set(ByVal value As Decimal)
                Me._pesoNetoMercancia = value
            End Set
        End Property
    End Class

    Partial Public Class FiguraTransporte
        Private _tiposFigura As List(Of TiposFigura) = New List(Of TiposFigura)()

        Public Property TiposFigura As List(Of TiposFigura)
            Get
                Return Me._tiposFigura
            End Get
            Set(ByVal value As List(Of TiposFigura))
                Me._tiposFigura = value
            End Set
        End Property
    End Class

    Partial Public Class TiposFigura
        Private _partesTransporte As List(Of PartesTransporte) = New List(Of PartesTransporte)()
        Private _domicilio As Domicilio
        Private _tipoFigura As String
        Private _rFCFigura As String
        Private _numLicencia As String
        Private _nombreFigura As String
        Private _numRegIdTribFigura As String
        Private _residenciaFiscalFigura As String

        Public Property PartesTransporte As List(Of PartesTransporte)
            Get
                Return Me._partesTransporte
            End Get
            Set(ByVal value As List(Of PartesTransporte))
                Me._partesTransporte = value
            End Set
        End Property
        Public Property Domicilio As Domicilio
            Get
                Return Me._domicilio
            End Get
            Set(ByVal value As Domicilio)
                Me._domicilio = value
            End Set
        End Property

        Public Property TipoFigura As String
            Get
                Return Me._tipoFigura
            End Get
            Set(ByVal value As String)
                Me._tipoFigura = value
            End Set
        End Property

        Public Property RFCFigura As String
            Get
                Return Me._rFCFigura
            End Get
            Set(ByVal value As String)
                Me._rFCFigura = value
            End Set
        End Property

        Public Property NumLicencia As String
            Get
                Return Me._numLicencia
            End Get
            Set(ByVal value As String)
                Me._numLicencia = value
            End Set
        End Property

        Public Property NombreFigura As String
            Get
                Return Me._nombreFigura
            End Get
            Set(ByVal value As String)
                Me._nombreFigura = value
            End Set
        End Property

        Public Property NumRegIdTribFigura As String
            Get
                Return Me._numRegIdTribFigura
            End Get
            Set(ByVal value As String)
                Me._numRegIdTribFigura = value
            End Set
        End Property

        Public Property ResidenciaFiscalFigura As String
            Get
                Return Me._residenciaFiscalFigura
            End Get
            Set(ByVal value As String)
                Me._residenciaFiscalFigura = value
            End Set
        End Property
    End Class

    Partial Public Class PartesTransporte

        Private _parteTransporte As String

        Public Property ParteTransporte As String
            Get
                Return Me._parteTransporte
            End Get
            Set(ByVal value As String)
                Me._parteTransporte = value
            End Set
        End Property
    End Class

End Namespace