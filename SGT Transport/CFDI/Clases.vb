
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Xml.Schema


#Region "Clase Principal Comprobante"
Public Class Comprobante
    Private _version As String = "4.0"
    Private _serie As String = String.Empty
    Private _folio As String = String.Empty
    Private _fecha As DateTime
    Private _sello As String = String.Empty
    Private _formaPago As String = String.Empty
    Private _noCertificado As String = String.Empty
    Private _certificado As String = String.Empty
    Private _condicionesDePago As String = String.Empty
    Private _subtotal As Decimal = 0
    Private _descuento As Decimal = 0
    Private _moneda As String = String.Empty
    Private _tipoCambio As Decimal = 0
    Private _total As Decimal = 0
    Private _tipoDeComprobante As String = String.Empty
    Private _exportacion As String = String.Empty
    Private _metodoPago As String = String.Empty
    Private _lugarExpedicion As String = String.Empty
    Private _confirmacion As String = String.Empty
    Private _informacionGlobal As InformacionGlobal
    Private _cfdiRelacionados As CfdiRelacionados
    Private _emisor As Emisor = New Emisor
    Private _receptor As Receptor = New Receptor
    Private _conceptos As Conceptos = New Conceptos
    Private _impuestos As Impuestos = New Impuestos
    'ADDENDA
    Private _complemento As Complemento
    Private _addenda As Addenda
    Public _totalLetra As String = String.Empty
    Public AcuseCancelacion As Acuse
    Public xml As String

    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <remarks> Atributo requerido con valor prefijo a 3.3 que indica la versión del estándar bajo el que se encuentra expresado el comprobante.</remarks>
    ''' </summary>
    Public Property Version As String
        Get
            Return _version
        End Get

        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Este atributo acepta una cadena de caracteres.</remarks>
    Public Property Serie As String
        Get
            Return _serie
        End Get

        Set(ByVal value As String)
            _serie = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Este atributo acepta una cadena de caracteres.</remarks>
    ''' </summary>
    Public Property Folio As String
        Get
            Return _folio
        End Get

        Set(ByVal value As String)
            _folio = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Se expresa en la forma AAAA-MM-DD:Thh:mm:ss</remarks>
    ''' </summary>
    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get

        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Debe ser expresado como una cadeba de texto en formato Base 64.</remarks>
    ''' </summary>
    Public Property Sello As String
        Get
            Return _sello
        End Get

        Set(ByVal value As String)
            _sello = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa la clave de la forma de pago.</remarks>
    ''' </summary>
    Public Property FormaPago As String
        Get
            Return _formaPago
        End Get

        Set(ByVal value As String)
            _formaPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Expresa el numero de serie del certificado de sello digital que amremarks al comprobante de acuerdo con el acuse correspondiente a 20 posiciones otorgadas por el sistema del SAT.</remarks>
    ''' </summary>
    Public Property NoCertificado As String
        Get
            Return _noCertificado
        End Get

        Set(ByVal value As String)
            _noCertificado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>El certificado del sello digital que amremarks al comprobante, como texto en formato base 64.</remarks>
    ''' </summary>
    Public Property Certificado As String
        Get
            Return _certificado
        End Get

        Set(ByVal value As String)
            _certificado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar las condiciones comerciales aplicables para el pago del CFDI. Este atributo puede ser condicionado mediante atributos o complementos.</remarks>
    ''' </summary>
    Public Property CondicionesDePago As String
        Get
            Return _condicionesDePago
        End Get

        Set(ByVal value As String)
            _condicionesDePago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Representa la suma de los conceptos antes de descuentos e impuestos. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property SubTotal As Decimal
        Get
            Return _subtotal
        End Get

        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Representa el importe total de los descuentos aplicables antes de impuestos. No se permiten valores negativos. Se debe aplicar cuando existan conceptos con descuento.</remarks>
    ''' </summary>
    Public Property Descuento As Decimal
        Get
            Return _descuento
        End Get

        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Requerido para identificar la clave de la moneda utilizada para expresar los montos. Cuando se usa moneda nacional se registra MXN.</remarks>
    ''' </summary>
    Public Property Moneda As String
        Get
            Return _moneda
        End Get

        Set(ByVal value As String)
            _moneda = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando la clave de moneda es distinta de MXN y de XXX. </remarks>
    ''' </summary>
    Public Property TipoCambio As Decimal
        Get
            Return _tipoCambio
        End Get

        Set(ByVal value As Decimal)
            _tipoCambio = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Representa la suma del subtotal, menos los descuentos aplicables, mas las contribuciones recibidas(impuestos trasladados - federales o locales, derechos, productos, aprovechamientos, aportaciones de seguridad social, contribuciones de mejoras) menos los impuestos retenidos.No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Total As Decimal
        Get
            Return _total
        End Get

        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>La clave del efecto del comprobante fiscal para el contribuyente emisor.</remarks>
    ''' </summary>
    Public Property TipoDeComprobante As String
        Get
            Return _tipoDeComprobante
        End Get

        Set(ByVal value As String)
            _tipoDeComprobante = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar si el comprobante ampara una operación de exportación.</remarks>
    ''' </summary>
    Public Property Exportacion As String
        Get
            Return _exportacion
        End Get

        Set(ByVal value As String)
            _exportacion = value
        End Set
    End Property

    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributos condicional para precisar la clave del metodo de pago que aplica para este CFDI.</remarks>
    ''' </summary>
    Public Property MetodoPago As String
        Get
            Return _metodoPago
        End Get

        Set(ByVal value As String)
            _metodoPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Incorpora el código postal del lugar de expedición del comprobante. (Domicilio de la matriz o de la sucursal)</remarks>
    ''' </summary>
    Public Property LugarExpedicion As String
        Get
            Return _lugarExpedicion
        End Get

        Set(ByVal value As String)
            _lugarExpedicion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para registrar la clave de confirmación que entrege el PAC para expedir el comprobante con importes grandes.</remarks>
    ''' </summary>
    Public Property Confirmacion As String
        Get
            Return _confirmacion
        End Get

        Set(ByVal value As String)
            _confirmacion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para precisar la informacion de los comprobante relacionados.</remarks>
    ''' </summary>
    Public Property InformacionGlobal As InformacionGlobal
        Get
            Return _informacionGlobal
        End Get

        Set(ByVal value As InformacionGlobal)
            _informacionGlobal = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para precisar la informacion de los comprobante relacionados.</remarks>
    ''' </summary>
    Public Property CfdiRelacionados As CfdiRelacionados
        Get
            Return _cfdiRelacionados
        End Get

        Set(ByVal value As CfdiRelacionados)
            _cfdiRelacionados = value
        End Set
    End Property

    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para expresar la informacion del contribuyente emisor del comprobante.</remarks>
    ''' </summary>
    Public Property Emisor As Emisor
        Get
            Return _emisor
        End Get

        Set(ByVal value As Emisor)
            _emisor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para precisar la información del contribuyente receptor del comprobante.</remarks>
    ''' </summary>
    Public Property Receptor As Receptor
        Get
            Return _receptor
        End Get

        Set(ByVal value As Receptor)
            _receptor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para listar los conceptos cubiertos por el comprobante.</remarks>
    ''' </summary>
    Public Property Conceptos As Conceptos
        Get
            Return _conceptos
        End Get

        Set(ByVal value As Conceptos)
            _conceptos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para expresar el resumen de los impuestos aplicables.</remarks>
    ''' </summary>
    Public Property Impuestos As Impuestos
        Get
            Return _impuestos
        End Get

        Set(ByVal value As Impuestos)
            _impuestos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' <remarks>Nodo opcional donde se incluye el complemento TImbre Fiscal Digital de manera obligatoria y los nodos complementarios determinados por el SAT.</remarks>
    ''' </summary>
    Public Property Complemento As Complemento
        Get
            Return _complemento
        End Get

        Set(ByVal value As Complemento)
            _complemento = value
        End Set
    End Property
    Public Property Addenda As Addenda
        Get
            Return _addenda
        End Get
        Set(ByVal value As Addenda)
            _addenda = value
        End Set
    End Property
    '*************** Falta agregar el complemento ADDENDA ********************************/
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property TotalLetra As String
        Get
            Return _totalLetra
        End Get

        Set(ByVal value As String)
            _totalLetra = value
        End Set
    End Property

    Public Function EsInfoCorrecta() As CError
        Dim [error] As CError = New CError()
        If _version <> "4.0" Then
            [error].HayError = True
            [error].[Error] = "La version del comprobante no corresponde a la 4.0"
        ElseIf _subtotal <= 0 Then
            If _tipoDeComprobante <> "T" Then
                [error].HayError = True
                [error].[Error] = "El subtotal no debe ser igual a 0.00"
            End If
        ElseIf _total <= 0 Then
            If _tipoDeComprobante <> "T" Then
                [error].HayError = True
                [error].[Error] = "El total no debe ser igual a 0.00"
            End If
        ElseIf _moneda = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar la clave de la moneda utilizada"
        ElseIf _tipoDeComprobante = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar la clave del tipo de comprobante"
        ElseIf _lugarExpedicion = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar el atributo LugarExpedicion"
        ElseIf _lugarExpedicion = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar el atributo LugarExpedicion"
        ElseIf _emisor.Rfc = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar el atributo Rfc del emisor del comprobante"
        ElseIf _emisor.RegimenFiscal = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar la clave del RegimenFiscal del emisor del comprobante"
        ElseIf _receptor.UsoCFDI = String.Empty Then
            [error].HayError = True
            [error].[Error] = "Debe especificar la clave del Uso de CFDI del receptor del comprobante"
        End If

        Return [error]
    End Function
End Class
Public Class InformacionGlobal
    Private _periodicidad As String = String.Empty
    Private _meses As String = String.Empty
    Private _ano As Integer = 0
    '''// <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el período al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Periodicidad As String
        Get
            Return _periodicidad
        End Get
        Set(ByVal value As String)
            _periodicidad = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el mes o los meses al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Meses As String
        Get
            Return _meses
        End Get
        Set(ByVal value As String)
            _meses = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>  
    ''' <para> Atributo requerido para expresar el año al que corresponde la información del comprobante global.</para>
    ''' </summary>
    Public Property Ano As Integer
        Get
            Return _ano
        End Get
        Set(ByVal value As Integer)
            _ano = value
        End Set
    End Property
End Class
Public Class CfdiRelacionados
    Public _tipoRelacion As String = String.Empty
    Public _cfdiRelacionado As List(Of CfdiRelacionado) = New List(Of CfdiRelacionado)()
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para indicar la clave de la relación que existe entre este que se esta generando y el o los CFDI previos.</remarks>
    ''' </summary>
    Public Property TipoRelacion As String
        Get
            Return _tipoRelacion
        End Get

        Set(ByVal value As String)
            _tipoRelacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para precisar la información de los comprobantes relacionados.</remarks>
    ''' </summary>
    Public Property CfdiRelacionado As List(Of CfdiRelacionado)
        Get
            Return _cfdiRelacionado
        End Get

        Set(ByVal value As List(Of CfdiRelacionado))
            _cfdiRelacionado = value
        End Set
    End Property
End Class
Public Class CfdiRelacionado
    Private _uuid As String
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributos requerido remarks registrar el folio fiscal (UUID) de un CFDI relacionado con el presente comprobante.</remarks>
    ''' </summary>
    Public Property UUID As String
        Get
            Return _uuid
        End Get
        Set(value As String)
            _uuid = value
        End Set
    End Property

End Class
Public Class Emisor
    Private _rfc As String = String.Empty
    Private _nombre As String = String.Empty
    Private _regimenFiscal As String = String.Empty
    Private _facAtrAdquirente As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo para precisar la clave del Registro Federal de Contribuyentes.</remarks>
    ''' </summary>
    Public Property Rfc As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para registrar el nombre, denominación o razón social del contribuyente emisor del comprobante.</remarks>
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get

        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' <remarks>Atributo requerido para incorporar la clave del régimen del contribuyente emisor al que aplicara el efecto fiscal de este comprobante.</remarks>
    ''' </summary>
    Public Property RegimenFiscal As String
        Get
            Return _regimenFiscal
        End Get

        Set(ByVal value As String)
            _regimenFiscal = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido</value>
    ''' <para>Atributo condicional para expresar el número de operación proporcionado por el SAT cuando se trate de un comprobante a través de un PCECFDI o un PCGCFDISP.</para>
    ''' </summary>
    Public Property FacAtrAdquirente As String
        Get
            Return _facAtrAdquirente
        End Get

        Set(ByVal value As String)
            _facAtrAdquirente = value
        End Set
    End Property
End Class
Public Class Receptor
    Private _rfc As String = String.Empty
    Private _nombre As String = String.Empty
    Private _domicilioFiscalReceptor As String = String.Empty
    Private _residenciaFiscal As String = String.Empty
    Private _numRegIdTrib As String = String.Empty
    Private _regimenFiscalReceptor As String = String.Empty
    Private _usoCFDI As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo para precisar la clave del Registro Federal de Contribuyentes.</remarks>
    ''' </summary>
    Public Property Rfc As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para registrar el nombre, denominación o razón social del contribuyente receptor del comprobante.</remarks>
    ''' </summary>
    Public Property Nombre As String
        Get
            Return _nombre
        End Get

        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para registrar el código postal del domicilio fiscal del receptor del comprobante.</remarks>
    ''' </summary>
    Public Property DomicilioFiscalReceptor As String
        Get
            Return _domicilioFiscalReceptor
        End Get

        Set(ByVal value As String)
            _domicilioFiscalReceptor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando se incluye el complemento de comercio exterior o se registre el atributo NumRegIdTrib.</remarks>
    ''' </summary>
    Public Property ResidenciaFiscal As String
        Get
            Return _residenciaFiscal
        End Get

        Set(ByVal value As String)
            _residenciaFiscal = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para incorporar la clave del régimen fiscal del contribuyente receptor al que aplicará el efecto fiscal de este comprobante.</remarks>
    ''' </summary>
    Public Property RegimenFiscalReceptor As String
        Get
            Return _regimenFiscalReceptor
        End Get

        Set(ByVal value As String)
            _regimenFiscalReceptor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Es requerido cuando se incluye el complemento de comercio exterior.</remarks>
    ''' </summary>
    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get

        Set(ByVal value As String)
            _numRegIdTrib = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la clave del uso que dará a esta factura el receptor del CFDI.</remarks>
    ''' </summary>
    Public Property UsoCFDI As String
        Get
            Return _usoCFDI
        End Get

        Set(ByVal value As String)
            _usoCFDI = value
        End Set
    End Property
End Class
Public Class Conceptos
    Private _concepto As List(Of Concepto) = New List(Of Concepto)()
    '''<summary>
    ''' <value>Requerido.</value>
    ''' <para>Nodo requerido para expresar la informacion detallada de un bien o servicio amparado en el comprobante.</para>
    ''' </summary>
    Public Property Concepto As List(Of Concepto)
        Get
            Return _concepto
        End Get
        Set(ByVal value As List(Of Concepto))
            _concepto = value
        End Set
    End Property
End Class
Public Class Concepto
    Private _claveProdServ As String = String.Empty
    Private _noIdentificacion As String = String.Empty
    Private _cantidad As Decimal = 0
    Private _claveUnidad As String = String.Empty
    Private _unidad As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _valorUnitario As Decimal = 0
    Private _importe As Decimal = 0
    Private _descuento As Decimal = 0
    Private _objetoImp As String = String.Empty
    Private _impuestos As ImpuestosC = New ImpuestosC()
    Private _aCuentaTercerosC As ACuentaTercerosC
    Private _informacionAduanera As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
    Private _cuentaPredial As List(Of CuentaPredialC) = New List(Of CuentaPredialC)()
    Private _complemento As ComplementoConcepto
    Private _parte As List(Of ParteC) = New List(Of ParteC)()

    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Expresa la clave del producto o del servicio amparado por el presente concepto. Se deben utilizar las claves del catalogo de productos y servicios.</remarks>
    ''' </summary>
    Public Property ClaveProdServ As String
        Get
            Return _claveProdServ
        End Get

        Set(ByVal value As String)
            _claveProdServ = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa el número de parte, identificador del producto o del servicio, SKU o equivalente.</remarks>
    ''' </summary>
    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get

        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa la cantidad de bienes o servicios del tipo particular definido por el presente concepto.</remarks>
    ''' </summary>
    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get

        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Se debe utilizar la clave del catalogo de unidades. La unidad debe corresponder con la descripción del concepto.</remarks>
    ''' </summary>
    Public Property ClaveUnidad As String
        Get
            Return _claveUnidad
        End Get

        Set(ByVal value As String)
            _claveUnidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Precisa la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en el concepto.</remarks>
    ''' </summary>
    Public Property Unidad As String
        Get
            Return _unidad
        End Get

        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa la descripción del bien o servicio cubierto por el presente concepto.</remarks>
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa el valor o precio unitario del bien o servicio cubierto por el presente concepto.</remarks>
    ''' </summary>
    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get

        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Precisa el importe total de los bienes o servicios del presente concepto. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en el concepto. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Representa el importe de los descuentos aplicables al concepto. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Descuento As Decimal
        Get
            Return _descuento
        End Get

        Set(ByVal value As Decimal)
            _descuento = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido.</value>
    ''' <para>Atributo requerido para expresar si la operación comercial es objeto o no de impuesto.</para>
    ''' </summary>
    Public Property ObjetoImp As String
        Get
            Return _objetoImp
        End Get

        Set(ByVal value As String)
            _objetoImp = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Opcional.</value> 
    ''' <para>Nodo opcional para registrar información del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property ACuentaTerceros As ACuentaTercerosC
        Get
            Return _aCuentaTercerosC
        End Get

        Set(ByVal value As ACuentaTercerosC)
            _aCuentaTercerosC = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para capturar los impuestos aplicables al presente concepto. Cuando un concepto no registra un impuesto, implica que no es objeto del mismo.</remarks>
    ''' </summary>
    Public Property Impuestos As ImpuestosC
        Get
            Return _impuestos
        End Get

        Set(ByVal value As ImpuestosC)
            _impuestos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para introducir la información aduanera cuando se trate de ventas de primera mano de mercancias importadas o se trate de operaciones de comercion exterior con bienes o servicios.</remarks>
    ''' </summary>
    Public Property InformacionAduanera As List(Of InformacionAduaneraC)
        Get
            Return _informacionAduanera
        End Get

        Set(ByVal value As List(Of InformacionAduaneraC))
            _informacionAduanera = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para asentar el número de cuenta predial  con el que fue registrado el inmueble, en el sistema catastra de la entidad federativa de que trate. </remarks>
    ''' </summary>
    Public Property CuentaPredial As List(Of CuentaPredialC)
        Get
            Return _cuentaPredial
        End Get

        Set(ByVal value As List(Of CuentaPredialC))
            _cuentaPredial = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional. 
    ''' <remarks>Nodo opcional para expresar las partes o componentes que integran la totalidad del concepto expresado en el CFDI.</remarks>
    ''' </summary>
    Public Property Parte As List(Of ParteC)
        Get
            Return _parte
        End Get

        Set(ByVal value As List(Of ParteC))
            _parte = value
        End Set
    End Property

    '************************* Falta agregar la clase ComplementoConcepto *************************************/
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento concepto que permite incorporar a los fabricantes, ensambladores o distribuidores autorizados de automóviles nuevos, así como aquéllos que importen automóviles para permanecer en forma definitiva en la franja fronteriza norte del país y en los Estados de Baja California, Baja California Sur y la región parcial del Estado de Sonora, a un Comprobante Fiscal Digital a través de Internet (CFDI) la clave vehicular que corresponda a la versión enajenada y el número de identificación vehicular que corresponda al vehículo enajenado.</remarks>
    Public Property Complemento As ComplementoConcepto
        Get
            Return _complemento
        End Get
        Set(value As ComplementoConcepto)
            _complemento = value
        End Set
    End Property
End Class
Public Class ACuentaTercerosC
    Private _rfcACuentaTerceros As String = String.Empty
    Private _nombreACuentaTerceros As String = String.Empty
    Private _regimenFiscalACuentaTerceros As String = String.Empty
    Private _domicilioFiscalACuentaTerceros As String = String.Empty
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para registrar la Clave del Registro Federal de Contribuyentes del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property RfcACuentaTerceros As String
        Get
            Return _rfcACuentaTerceros
        End Get
        Set(ByVal value As String)
            _rfcACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Opcional. </value>
    ''' <para>Atributo requerido para registrar el nombre, denominación o razón social del contribuyente Tercero correspondiente con el Rfc, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property NombreACuentaTerceros As String
        Get
            Return _nombreACuentaTerceros
        End Get
        Set(ByVal value As String)
            _nombreACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para incorporar la clave del régimen del contribuyente Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property RegimenFiscalACuentaTerceros As String
        Get
            Return _regimenFiscalACuentaTerceros
        End Get
        Set(ByVal value As String)
            _regimenFiscalACuentaTerceros = value
        End Set
    End Property
    ''' <summary>
    ''' <value>Requerido. </value>
    ''' <para>Atributo requerido para incorporar el código postal del domicilio fiscal del Tercero, a cuenta del que se realiza la operación.</para>
    ''' </summary>
    Public Property DomicilioFiscalACuentaTerceros As String
        Get
            Return _domicilioFiscalACuentaTerceros
        End Get
        Set(ByVal value As String)
            _domicilioFiscalACuentaTerceros = value
        End Set
    End Property
End Class
Public Class ComplementoConcepto
    Private _ventaVehiculos As VentaVehiculos
    Public Property VentaVehiculos As VentaVehiculos
        Get
            Return _ventaVehiculos
        End Get
        Set(value As VentaVehiculos)
            _ventaVehiculos = value
        End Set
    End Property
End Class
Public Class ImpuestosC
    Private _traslados As List(Of TrasladoC) = New List(Of TrasladoC)()
    Private _retenciones As List(Of RetencionC) = New List(Of RetencionC)()
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para asentar los impuestos trasladados aplicables al presente concepto.</remarks>
    ''' </summary>
    Public Property Traslados As List(Of TrasladoC)
        Get
            Return _traslados
        End Get

        Set(ByVal value As List(Of TrasladoC))
            _traslados = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    '''  <remarks>Nodo opcional para asentar los impuestos retenidos aplicables al presente concepto.</remarks>
    ''' </summary>
    Public Property Retenciones As List(Of RetencionC)
        Get
            Return _retenciones
        End Get

        Set(ByVal value As List(Of RetencionC))
            _retenciones = value
        End Set
    End Property
End Class
Public Class TrasladoC
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la base para el calculo del impuesto, la determinación de la base se realiza de acuerdo con las disposiciones vigentes. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto traslado aplicable al concepto.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' <remarks>Atributo condicional para señalar el valor de la tasa o cuota del impuesto que se traslada para el presente concepto. Es requerido cuando el atributo TipoFactor tenga una clava que corresponte a TasaOCuota.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para señalar el importe del impuesto trasladado que aplica al concepto. No se permiten valore negativos. Es requerido cuado TipoFactor sea TasaOCuota.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class RetencionC
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la base para el calculo de la retención, la determinación de la base se realiza de acuerdo con las disposiciones fiscales vigentes. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto retenido aplicable al concepto.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' <remarks>Atributo requerido para señalar la tasa o cuota del impuesto que se retiene para el presente concepto.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el importe del impuesto retenido que aplica al concepto. No se permiten valore negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class InformacionAduaneraC
    Private _numeroPedimento As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el número del pedimento que ampara la importación del bien que se expresa en el siguiente formato: últimos 2 dígitos del año de validación seguidos por dos espacios, 2 dígitos de la aduana de despacho seguidos por dos espacios, 4 dígitos del número de la patente seguidos por dos espacios, 1 dígito que corresponde al último dígito del año en curso, salvo que se trate de un pedimento consolidado iniciado en el año inmediato anterior o del pedimento original de una rectificación, seguido de 6 dígitos de la numeración progresiva por aduana.</remarks>
    ''' </summary>
    Public Property NumeroPedimento As String
        Get
            Return _numeroPedimento
        End Get

        Set(ByVal value As String)
            _numeroPedimento = value
        End Set
    End Property
End Class
Public Class CuentaPredialC
    Private _numero As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar el número de la cuenta predial del inmueble cubierto por el presente concepto, o bien para incorporar los datos de identificación del certificado de participación inmobiliaria no amortizable, tratándose de arrendamiento.</remarks>
    ''' </summary>
    Public Property Numero As String
        Get
            Return _numero
        End Get
        Set(ByVal value As String)
            _numero = value
        End Set
    End Property
End Class
Public Class ParteC
    Private _claveProdServ As String = String.Empty
    Private _noIdentificacion As String = String.Empty
    Private _cantidad As Decimal = 0
    Private _unidad As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _valorUnitario As Decimal = 0
    Private _importe As Decimal = 0
    Private _informacionAduanera As List(Of InformacionAduaneraC) = New List(Of InformacionAduaneraC)()
    ''' <summary>
    ''' Requerido. 
    ''' <remarks>Expresa la clave del producto o del servicio amparado por la presente parte. Es requerido y deben utilizar las claves del cátalogo de productos y servicios, cuando los conceptos que registren por sus actividades corresponden con dichos conceptos.</remarks>
    ''' </summary>
    Public Property ClaveProdServ As String
        Get
            Return _claveProdServ
        End Get

        Set(ByVal value As String)
            _claveProdServ = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Expresa el número de serie, número de parte del bien o identificador del producto o del servicio amparado por la presente parte.</remarks>
    ''' </summary>
    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get

        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por la presente parte.</remarks>
    ''' </summary>
    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get

        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar la unidad de medida propia de la operación del emisor, aplicable para la cantidad expresada en la parte. La unidad debe corresponder con la descripción de la parte.</remarks>
    ''' </summary>
    Public Property Unidad As String
        Get
            Return _unidad
        End Get

        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte.</remarks>
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get

        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para introducir la información aduanera aplicable cuando se trate de ventas de primera mano de mercancías importadas o se trate de operaciones de comercio exterior con bienes o servicios.</remarks>
    ''' </summary>
    Public Property InformacionAduanera As List(Of InformacionAduaneraC)
        Get
            Return _informacionAduanera
        End Get

        Set(ByVal value As List(Of InformacionAduaneraC))
            _informacionAduanera = value
        End Set
    End Property
End Class
Public Class Impuestos
    Private _totalImpuestosRetenidos As Decimal = 0
    Private _totalImpuestosTrasladados As Decimal = 0
    Private _retenciones As List(Of Retencion) = New List(Of Retencion)()
    Private _traslados As List(Of Traslado) = New List(Of Traslado)()
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar el total de los impuestos retenidos que se desprenden de los conceptos expresados en el comprobante fiscal digital por Internet. No se permiten valores negativos. Es requerido cuando en los conceptos se registren impuestos retenidos.</remarks>
    ''' </summary>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return _totalImpuestosRetenidos
        End Get

        Set(ByVal value As Decimal)
            _totalImpuestosRetenidos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo condicional para expresar el total de los impuestos trasladados que se desprenden de los conceptos expresados en el comprobante fiscal digital por Internet. No se permiten valores negativos. Es requerido cuando en los conceptos se registren impuestos trasladados.</remarks>
    ''' </summary>
    Public Property TotalImpuestosTrasladados As Decimal
        Get
            Return _totalImpuestosTrasladados
        End Get

        Set(ByVal value As Decimal)
            _totalImpuestosTrasladados = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para capturar los impuestos retenidos aplicables. Es requerido cuando en los conceptos se registre algún impuesto retenido.</remarks>
    ''' </summary>
    Public Property Retenciones As List(Of Retencion)
        Get
            Return _retenciones
        End Get

        Set(ByVal value As List(Of Retencion))
            _retenciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo condicional para capturar los impuestos trasladados aplicables. Es requerido cuando en los conceptos se registre un impuesto trasladado.</remarks>
    ''' </summary>
    Public Property Traslados As List(Of Traslado)
        Get
            Return _traslados
        End Get

        Set(ByVal value As List(Of Traslado))
            _traslados = value
        End Set
    End Property
End Class
Public Class Retencion
    Private _impuesto As String = String.Empty
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto retenido.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el monto del impuesto retenido. No se permiten valores negativos.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class Traslado
    Private _base As Decimal = 0
    Private _impuesto As String = String.Empty
    Private _tipoFactor As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' <value>Requerido.</value> 
    ''' <para>Atributo requerido para señalar la suma de los atributos Base de los conceptos del impuesto trasladado. No se permiten valores negativos.</para>
    ''' </summary>
    Public Property Base As Decimal
        Get
            Return _base
        End Get

        Set(ByVal value As Decimal)
            _base = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de impuesto traslado.</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la clave del tipo de factor que se aplica a la base del impuesto.</remarks>
    ''' </summary>
    Public Property TipoFactor As String
        Get
            Return _tipoFactor
        End Get

        Set(ByVal value As String)
            _tipoFactor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar el valor de la tasa o cuota del impuesto que se traslada por los conceptos amparados en el comprobante.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la suma del importe del impuesto trasladado, agrupado por impuesto, TipoFactor y TasaOCuota. No se permiten valores negativos.</remarks>  
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class Complemento
    Private _timbreFiscalDigital As TimbreFiscalDigital = New TimbreFiscalDigital()
    Private _pagos As Pagos
    Private _nomina As Nomina
    Private _vehiculoUsado As VehiculoUsado
    Private _ventaVehiculos As VentaVehiculos
    Private _ingresosHidrocarburos As IngresosHidrocarburos
    Private _gastosHidrocarburos As GastosHidrocarburos
    Private _cartarPorte20 As CartaPorte
    Private _consumoDeCombustibles As ConsumoDeCombustibles
    Private _comercioExterior11 As ComercioExterior

    Public Property TimbreFiscalDigital As TimbreFiscalDigital
        Get
            Return _timbreFiscalDigital
        End Get
        Set(value As TimbreFiscalDigital)
            _timbreFiscalDigital = value
        End Set
    End Property
    Public Property Pagos As Pagos
        Get
            Return _pagos
        End Get
        Set(value As Pagos)
            _pagos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI) la información que ampara conceptos de ingresos por salarios, la prestación de un servicio personal subordinado o conceptos asimilados a salarios (Nómina).</remarks>
    Public Property Nomina As Nomina
        Get
            Return _nomina
        End Get
        Set(value As Nomina)
            _nomina = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Complemento opcional que permite incorporar información a los contribuyentes que enajenen vehículos nuevos a personas físicas que no tributen en los términos de las Secciones I y II del Capítulo II del Título IV de la ley del ISR, y que reciban en contraprestación como resultados de esa enajenación un vehículo usado y dinero</remarks>
    Public Property VehiculoUsado As VehiculoUsado
        Get
            Return _vehiculoUsado
        End Get
        Set(value As VehiculoUsado)
            _vehiculoUsado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Complemento concepto que permite incorporar a los fabricantes, ensambladores o distribuidores autorizados de automóviles nuevos, así como aquéllos que importen automóviles para permanecer en forma definitiva en la franja fronteriza norte del país y en los Estados de Baja California, Baja California Sur y la región parcial del Estado de Sonora, a un Comprobante Fiscal Digital a través de Internet (CFDI) la clave vehicular que corresponda a la versión enajenada y el número de identificación vehicular que corresponda al vehículo enajenado.</remarks>
    Public Property VentaVehiculos As VentaVehiculos
        Get
            Return _ventaVehiculos
        End Get
        Set(value As VentaVehiculos)
            _ventaVehiculos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Estándar del Complemento Ingresos atribuibles a los Integrantes de un Consorcio derivados de la Contraprestación de un Contrato de Exploración o Extracción de Hidrocarburos.</remarks>
    Public Property IngresosHidrocarburos As IngresosHidrocarburos
        Get
            Return _ingresosHidrocarburos
        End Get
        Set(value As IngresosHidrocarburos)
            _ingresosHidrocarburos = value
        End Set
    End Property
    Public Property GastosHidrocarburos As GastosHidrocarburos
        Get
            Return _gastosHidrocarburos
        End Get
        Set(value As GastosHidrocarburos)
            _gastosHidrocarburos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento al Comprobante Fiscal Digital por Internet (CFDI) para integrar la información de consumo de combustibles por monedero electrónico.</remarks>
    Public Property ConsumoDeCombustibles As ConsumoDeCombustibles
        Get
            Return _consumoDeCombustibles
        End Get
        Set(value As ConsumoDeCombustibles)
            _consumoDeCombustibles = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI), la información relacionada a los bienes y/o mercancías, ubicaciones de origen, puntos intermedios y destinos, así como lo referente al medio por el que se transportan; ya sea por vía terrestre (autotransporte y férrea), marítima y/o aérea; además de incluir el traslado de hidrocarburos y petrolíferos.</remarks>
    Public Property CartaPorte20 As CartaPorte
        Get
            Return _cartarPorte20
        End Get
        Set(value As CartaPorte)
            _cartarPorte20 = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Complemento para incorporar la información en el caso de Exportación de Mercancías en definitiva.</remarks>
    Public Property ComercioExterior As ComercioExterior
        Get
            Return _comercioExterior11
        End Get
        Set(value As ComercioExterior)
            _comercioExterior11 = value
        End Set
    End Property
End Class
#End Region
#Region "Complementos"
#Region "Carta Porte 2.0"
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
#End Region
#Region "Complemento ComercioExterior"
Public Class ComercioExterior
    Private _emisor As CCE11Emisor
    Private _propietario As List(Of CCE11Propietario) = New List(Of CCE11Propietario)
    Private _receptor As CCE11Receptor
    Private _destinario As List(Of CCE11Destinario) = New List(Of CCE11Destinario)
    Private _mercancias As CCE11Mercancias
    Private _version As String
    Private _motivoTraslado As String
    Private _tipoOperacion As String
    Private _claveDePedimento As String
    Private _certificadoOrigen As Integer
    Private _numCertificadoOrigen As String
    Private _numeroExportadorConfiable As String
    Private _incoterm As String
    Private _subdivision As Integer
    Private _observaciones As String
    Private _tipoCambioUSD As String
    Private _totalUSD As Decimal

    Public Property TotalUSD As Decimal
        Get
            Return _totalUSD
        End Get
        Set(ByVal value As Decimal)
            _totalUSD = value
        End Set
    End Property

    Public Property TipoCambioUSD As String
        Get
            Return _tipoCambioUSD
        End Get
        Set(ByVal value As String)
            _tipoCambioUSD = value
        End Set
    End Property

    Public Property Observaciones As String
        Get
            Return _observaciones
        End Get
        Set(ByVal value As String)
            _observaciones = value
        End Set
    End Property

    Public Property Subdivision As Integer
        Get
            Return _subdivision
        End Get
        Set(ByVal value As Integer)
            _subdivision = value
        End Set
    End Property

    Public Property Incoterm As String
        Get
            Return _incoterm
        End Get
        Set(ByVal value As String)
            _incoterm = value
        End Set
    End Property

    Public Property NumeroExportadorConfiable As String
        Get
            Return _numeroExportadorConfiable
        End Get
        Set(ByVal value As String)
            _numeroExportadorConfiable = value
        End Set
    End Property

    Public Property NumCertificadoOrigen As String
        Get
            Return _numCertificadoOrigen
        End Get
        Set(ByVal value As String)
            _numCertificadoOrigen = value
        End Set
    End Property

    Public Property CertificadoOrigen As Integer
        Get
            Return _certificadoOrigen
        End Get
        Set(ByVal value As Integer)
            _certificadoOrigen = value
        End Set
    End Property

    Public Property ClaveDePedimento As String
        Get
            Return _claveDePedimento
        End Get
        Set(ByVal value As String)
            _claveDePedimento = value
        End Set
    End Property

    Public Property TipoOperacion As String
        Get
            Return _tipoOperacion
        End Get
        Set(ByVal value As String)
            _tipoOperacion = value
        End Set
    End Property

    Public Property MotivoTraslado As String
        Get
            Return _motivoTraslado
        End Get
        Set(ByVal value As String)
            _motivoTraslado = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property Mercancias As CCE11Mercancias
        Get
            Return _mercancias
        End Get
        Set(ByVal value As CCE11Mercancias)
            _mercancias = value
        End Set
    End Property

    Public Property Destinario As List(Of CCE11Destinario)
        Get
            Return _destinario
        End Get
        Set(ByVal value As List(Of CCE11Destinario))
            _destinario = value
        End Set
    End Property

    Public Property Receptor As CCE11Receptor
        Get
            Return _receptor
        End Get
        Set(ByVal value As CCE11Receptor)
            _receptor = value
        End Set
    End Property

    Public Property Propietario As List(Of CCE11Propietario)
        Get
            Return _propietario
        End Get
        Set(ByVal value As List(Of CCE11Propietario))
            _propietario = value
        End Set
    End Property

    Public Property Emisor As CCE11Emisor
        Get
            Return _emisor
        End Get
        Set(ByVal value As CCE11Emisor)
            _emisor = value
        End Set
    End Property
End Class

Public Class CCE11Domicilio
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
            Return _calle
        End Get
        Set(ByVal value As String)
            _calle = value
        End Set
    End Property

    Public Property NumeroExterior As String
        Get
            Return _numeroExterior
        End Get
        Set(ByVal value As String)
            _numeroExterior = value
        End Set
    End Property

    Public Property NumeroInterior As String
        Get
            Return _numeroInterior
        End Get
        Set(ByVal value As String)
            _numeroInterior = value
        End Set
    End Property

    Public Property Colonia As String
        Get
            Return _colonia
        End Get
        Set(ByVal value As String)
            _colonia = value
        End Set
    End Property

    Public Property Localidad As String
        Get
            Return _localidad
        End Get
        Set(ByVal value As String)
            _localidad = value
        End Set
    End Property

    Public Property Referencia As String
        Get
            Return _referencia
        End Get
        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property

    Public Property Municipio As String
        Get
            Return _municipio
        End Get
        Set(ByVal value As String)
            _municipio = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(ByVal value As String)
            _estado = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _pais
        End Get
        Set(ByVal value As String)
            _pais = value
        End Set
    End Property

    Public Property CodigoPostal As String
        Get
            Return _codigoPostal
        End Get
        Set(ByVal value As String)
            _codigoPostal = value
        End Set
    End Property
End Class

Public Class CCE11Emisor
    Private _curp As String
    Private _domicilio As CCE11Domicilio

    Public Property Curp As String
        Get
            Return _curp
        End Get
        Set(ByVal value As String)
            _curp = value
        End Set
    End Property

    Public Property Domicilio As CCE11Domicilio
        Get
            Return _domicilio
        End Get
        Set(ByVal value As CCE11Domicilio)
            _domicilio = value
        End Set
    End Property
End Class

Public Class CCE11Propietario
    Private _numRegIdTrib As String
    Private _residenciaFiscal As String

    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get
        Set(ByVal value As String)
            _numRegIdTrib = value
        End Set
    End Property

    Public Property ResidenciaFiscal As String
        Get
            Return _residenciaFiscal
        End Get
        Set(ByVal value As String)
            _residenciaFiscal = value
        End Set
    End Property
End Class

Public Class CCE11Receptor
    Private _numRegIdTrib As String
    Private _domicilio As CCE11Domicilio

    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get
        Set(ByVal value As String)
            _numRegIdTrib = value
        End Set
    End Property

    Public Property Domicilio As CCE11Domicilio
        Get
            Return _domicilio
        End Get
        Set(ByVal value As CCE11Domicilio)
            _domicilio = value
        End Set
    End Property
End Class

Public Class CCE11Destinario
    Private _numRegIdTrib As String
    Private _domicilio As CCE11Domicilio
    Private _nombre As String

    Public Property NumRegIdTrib As String
        Get
            Return _numRegIdTrib
        End Get
        Set(ByVal value As String)
            _numRegIdTrib = value
        End Set
    End Property

    Public Property Domicilio As CCE11Domicilio
        Get
            Return _domicilio
        End Get
        Set(ByVal value As CCE11Domicilio)
            _domicilio = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property
End Class

Public Class CCE11Mercancia
    Private _descripcionesEspecificas As List(Of CCE11DescripcionesEspecificas) = New List(Of CCE11DescripcionesEspecificas)()
    Private _noIdentificacion As String
    Private _fraccionArancelaria As String
    Private _cantidadAduana As Decimal
    Private _unidadAduana As String
    Private _valorUnitarioAduana As Decimal
    Private _valorDolares As Decimal

    Public Property DescripcionesEspecificas As List(Of CCE11DescripcionesEspecificas)
        Get
            Return _descripcionesEspecificas
        End Get
        Set(ByVal value As List(Of CCE11DescripcionesEspecificas))
            _descripcionesEspecificas = value
        End Set
    End Property

    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get
        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property

    Public Property FraccionArancelaria As String
        Get
            Return _fraccionArancelaria
        End Get
        Set(ByVal value As String)
            _fraccionArancelaria = value
        End Set
    End Property

    Public Property CantidadAduana As Decimal
        Get
            Return _cantidadAduana
        End Get
        Set(ByVal value As Decimal)
            _cantidadAduana = value
        End Set
    End Property

    Public Property UnidadAduana As String
        Get
            Return _unidadAduana
        End Get
        Set(ByVal value As String)
            _unidadAduana = value
        End Set
    End Property

    Public Property ValorUnitarioAduana As Decimal
        Get
            Return _valorUnitarioAduana
        End Get
        Set(ByVal value As Decimal)
            _valorUnitarioAduana = value
        End Set
    End Property

    Public Property ValorDolares As Decimal
        Get
            Return _valorDolares
        End Get
        Set(ByVal value As Decimal)
            _valorDolares = value
        End Set
    End Property
End Class

Public Class CCE11Mercancias
    Private _mercancia As List(Of CCE11Mercancia) = New List(Of CCE11Mercancia)()
    Public _version As String
    Public _motivoTraslado As String
    Public _tipoOperacion As String
    Public _clavePedimento As String
    Public _certificadoOrigen As String
    Public _numCertificadoOrigen As String
    Public Mercancia As List(Of CCE11Mercancia) = New List(Of CCE11Mercancia)()

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property MotivoTraslado As String
        Get
            Return _motivoTraslado
        End Get
        Set(ByVal value As String)
            _motivoTraslado = value
        End Set
    End Property

    Public Property TipoOperacion As String
        Get
            Return _tipoOperacion
        End Get
        Set(ByVal value As String)
            _tipoOperacion = value
        End Set
    End Property

    Public Property ClavePedimento As String
        Get
            Return _clavePedimento
        End Get
        Set(ByVal value As String)
            _clavePedimento = value
        End Set
    End Property

    Public Property CertificadoOrigen As String
        Get
            Return _certificadoOrigen
        End Get
        Set(ByVal value As String)
            _certificadoOrigen = value
        End Set
    End Property

    Public Property NumCertificadoOrigen As String
        Get
            Return _numCertificadoOrigen
        End Get
        Set(ByVal value As String)
            _numCertificadoOrigen = value
        End Set
    End Property
End Class

Public Class CCE11DescripcionesEspecificas
    Private _marca As String
    Private _modelo As String
    Private _subModelo As String
    Private _numeroSerie As String

    Public Property NumeroSerie As String
        Get
            Return _numeroSerie
        End Get
        Set(ByVal value As String)
            _numeroSerie = value
        End Set
    End Property

    Public Property SubModelo As String
        Get
            Return _subModelo
        End Get
        Set(ByVal value As String)
            _subModelo = value
        End Set
    End Property

    Public Property Modelo As String
        Get
            Return _modelo
        End Get
        Set(ByVal value As String)
            _modelo = value
        End Set
    End Property

    Public Property Marca As String
        Get
            Return _marca
        End Get
        Set(ByVal value As String)
            _marca = value
        End Set
    End Property
End Class

#End Region


#Region "TimbresFiscalDigital"
Public Class TimbreFiscalDigital
    Private _version As String = "1.1"
    Private _UUID As String = String.Empty
    Private _fechaTimbrado As DateTime = DateTime.Now
    Private _rfcProvCertif As String = String.Empty
    Private _leyenda As String = String.Empty
    Private _selloCFD As String = String.Empty
    Private _noCertificadoSAT As String = String.Empty
    Private _selloSAT As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' Valor inicial 1.1
    ''' <remarks>Atributo requerido para la expresión de la versión del estándar del Timbre Fiscal Digital.</remarks>
    ''' </summary>
    Public Property Version As String
        Get
            Return _version
        End Get

        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar los 36 caracteres del folio fiscal (UUID) de la transacción de timbrado conforme al estándar RFC 4122.</remarks>
    ''' </summary>
    Public Property UUID As String
        Get
            Return _UUID
        End Get

        Set(ByVal value As String)
            _UUID = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la fecha y hora, de la generación del timbre por la certificación digital del SAT. Se expresa en la forma AAAA-MM-DDThh:mm:ss y debe corresponder con la hora de la Zona Centro del Sistema de Horario en México.</remarks>
    ''' </summary>
    Public Property FechaTimbrado As DateTime
        Get
            Return _fechaTimbrado
        End Get

        Set(ByVal value As DateTime)
            _fechaTimbrado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el RFC del proveedor de certificación de comprobantes fiscales digitales que genera el timbre fiscal digital.</remarks>
    ''' </summary>
    Public Property RfcProvCertif As String
        Get
            Return _rfcProvCertif
        End Get

        Set(ByVal value As String)
            _rfcProvCertif = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para registrar información que el SAT comunique a los usuarios del CFDI.</remarks>
    ''' </summary>
    Public Property Leyenda As String
        Get
            Return _leyenda
        End Get

        Set(ByVal value As String)
            _leyenda = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para contener el sello digital del comprobante fiscal o del comprobante de retenciones, que se ha timbrado. El sello debe ser expresado como una cadena de texto en formato Base 64.</remarks>
    ''' </summary>
    Public Property SelloCFD As String
        Get
            Return _selloCFD
        End Get

        Set(ByVal value As String)
            _selloCFD = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el número de serie del certificado del SAT usado para generar el sello digital del Timbre Fiscal Digital.</remarks>
    ''' </summary>
    Public Property NoCertificadoSAT As String
        Get
            Return _noCertificadoSAT
        End Get

        Set(ByVal value As String)
            _noCertificadoSAT = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para contener el sello digital del Timbre Fiscal Digital, al que hacen referencia las reglas de la Resolución Miscelánea vigente. El sello debe ser expresado como una cadena de texto en formato Base 64.</remarks>
    ''' </summary>
    Public Property SelloSAT As String
        Get
            Return _selloSAT
        End Get

        Set(ByVal value As String)
            _selloSAT = value
        End Set
    End Property
End Class
#End Region
#Region "Nomina"
Public Class NEmisor
    Private _curp As String = String.Empty
    Private _registroPatronal As String = String.Empty
    Private _rfcPatronOrigen As String = String.Empty
    Private _entidadSNCF As NEntidadSNCF = New NEntidadSNCF()
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar la CURP del emisor del comprobante de nomina cuando es una persona fisica.</remarks>
    Public Property Curp As String
        Get
            Return _curp
        End Get
        Set(value As String)
            _curp = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Atributor condicional para expresar el registro patronal clave de ramo - pagaduria o la que se le asigne la institucion.</remarks>
    Public Property RegistroPatronal As String
        Get
            Return _registroPatronal
        End Get
        Set(value As String)
            _registroPatronal = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar el RFC de la persona que fungió como patrón cuando el pago al trabajador se realice a través de un tercero como vehículo o herramienta de pago.</remarks>
    Public Property RfcPatronOrigen As String
        Get
            Return _rfcPatronOrigen
        End Get
        Set(value As String)
            _rfcPatronOrigen = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para que las entidades adheridas al Sistema Nacional de Coordinación Fiscal realicen la identificación del origen de los recursos utilizados en el pago de nómina del personal que presta o desempeña un servicio personal subordinado en las dependencias de la entidad federativa, del municipio o demarcación territorial de la Ciudad de México, así como en sus respectivos organismos autónomos y entidades paraestatales y paramunicipales.</remarks>
    Public Property EntidadSNCF As NEntidadSNCF
        Get
            Return _entidadSNCF
        End Get
        Set(value As NEntidadSNCF)
            _entidadSNCF = value
        End Set
    End Property

End Class
Public Class NEntidadSNCF
    Private _origenRecurso As String = String.Empty
    Private _montoRecursoPropio As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para identificar el origen del recurso utilizado para el pago de nómina del presona que presta o desempaña un servicio personal subordinado.</remarks>
    Public Property OrigenRecurso As String
        Get
            Return _origenRecurso
        End Get
        Set(value As String)
            _origenRecurso = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar  el monto del recurso pagado con cargo a sus participaciones u otros ingresos locales.</remarks>
    Public Property MontoRecursoPropio As String
        Get
            Return _montoRecursoPropio
        End Get
        Set(value As String)
            _montoRecursoPropio = value
        End Set
    End Property
End Class
Public Class NReceptor
    Private _curp As String = String.Empty
    Private _numSeguridadSocial As String = String.Empty 'Condicional
    Private _fechaInicioRelLaboral As DateTime = DateTime.Now 'Condicional
    Private _antiguedad As String = String.Empty 'Condicional
    Private _tipoContrato As String = String.Empty
    Private _sindicalizado As String = String.Empty 'Opcional
    Private _tipoJornada As String = String.Empty 'Condicional
    Private _tipoRegimen As String = String.Empty
    Private _numEmpleado As String = String.Empty
    Private _departamento As String = String.Empty 'Opcional
    Private _puesto As String = String.Empty 'Opcional
    Private _riesgoPuesto As String = String.Empty 'Opcional
    Private _periodicidadPago As String = String.Empty
    Private _banco As String = String.Empty
    Private _cuentaBancaria As String = String.Empty
    Private _salarioBaseCotApor As Decimal = 0
    Private _salarioDiarioIntegrado As Decimal = 0
    Private _claveEntFed As String = String.Empty
    Private _subContratacion As List(Of NSubContratacion) = New List(Of NSubContratacion)()
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la CURP del receptor del comprobante de nómina</remarks>
    Public Property Curp As String
        Get
            Return _curp
        End Get
        Set(value As String)
            _curp = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de seguridad social del trabajador. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales</remarks>
    Public Property NumSeguridadSocial As String
        Get
            Return _numSeguridadSocial
        End Get
        Set(value As String)
            _numSeguridadSocial = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar la fecha de inicio de la relación laboral entre el empleador y el empleado. Se expresa en la forma aaaa-mm-dd, de acuerdo con la espeficicación ISO 8601. Se debe ingresar cuando se cuente con él o se este obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property FechaInicioRelLaboral As DateTime
        Get
            Return _fechaInicioRelLaboral
        End Get
        Set(value As DateTime)
            _fechaInicioRelLaboral = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el número de semanas o el periodo de años, meses y días que el empleado ha mantenido relación laboral con el empleador. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property Antiguedad As String
        Get
            Return _antiguedad
        End Get
        Set(value As String)
            _antiguedad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el tipo de contrato que tiene el trabajador.</remarks>
    Public Property TipoContrato As String
        Get
            Return _tipoContrato
        End Get
        Set(value As String)
            _tipoContrato = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para indicar si el trabajador está asociado a un sindicato. Si se omite se asume que no está asociado a algún sindicato.</remarks>
    Public Property Sindicalizado As String
        Get
            Return _sindicalizado
        End Get
        Set(value As String)
            _sindicalizado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el tipo de jornada que cubre el trabajador. Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property TipoJornada As String
        Get
            Return _tipoJornada
        End Get
        Set(value As String)
            _tipoJornada = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión de la clave del régimen por el cual se tiene contratado al trabajador.</remarks>
    Public Property TipoRegimen As String
        Get
            Return _tipoRegimen
        End Get
        Set(value As String)
            _tipoRegimen = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de empleado de 1 a 15 posiciones.</remarks>
    Public Property NumEmpleado As String
        Get
            Return _numEmpleado
        End Get
        Set(value As String)
            _numEmpleado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo opcional para la expresión del departamento o área a la que pertenece el trabajador.</remarks>
    Public Property Departamento As String
        Get
            Return _departamento
        End Get
        Set(value As String)
            _departamento = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para la expresión del puesto asignado al empleado o actividad que realiza.</remarks>
    Public Property Puesto As String
        Get
            Return _puesto
        End Get
        Set(value As String)
            _puesto = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar la clave conforme a la Clase en que deben inscribirse los patrones, de acuerdo con las actividades que desempeñan sus trabajadores, según lo previsto en el artículo 196 del Reglamento en Materia de Afiliación Clasificación de Empresas, Recaudación y Fiscalización, o conforme con la normatividad del Instituto de Seguridad Social del trabajador. Se debe ingresar cuando se cuente con él, o se esté obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property RiesgoPuesto As String
        Get
            Return _riesgoPuesto
        End Get
        Set(value As String)
            _riesgoPuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la forma en que se establece el pago del salario.</remarks>
    Public Property PeriodicidadPago As String
        Get
            Return _periodicidadPago
        End Get
        Set(value As String)
            _periodicidadPago = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para la expresión de la clave del Banco conforme al catálogo, donde se realiza el depósito de nómina.</remarks>
    Public Property Banco As String
        Get
            Return _banco
        End Get
        Set(value As String)
            _banco = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para la expresión de la cuenta bancaria a 11 posiciones o número de teléfono celular a 10 posiciones o número de tarjeta de crédito, débito o servicios a 15 ó 16 posiciones o la CLABE a 18 posiciones o número de monedero electrónico, donde se realiza el depósito de nómina.</remarks>
    Public Property CuentaBancaria As String
        Get
            Return _cuentaBancaria
        End Get
        Set(value As String)
            _cuentaBancaria = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar la retribución otorgada al trabajador, que se integra por los pagos hechos en efectivo por cuota diaria, gratificaciones, percepciones, alimentación, habitación, primas, comisiones, prestaciones en especie y cualquiera otra cantidad o prestación que se entregue al trabajador por su trabajo, sin considerar los conceptos que se excluyen de conformidad con el Artículo 27 de la Ley del Seguro Social, o la integración de los pagos conforme la normatividad del Instituto de Seguridad Social del trabajador. (Se emplea para pagar las cuotas y aportaciones de Seguridad Social). Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property SalarioBaseCotApor As Decimal
        Get
            Return _salarioBaseCotApor
        End Get
        Set(value As Decimal)
            _salarioBaseCotApor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar el salario que se integra con los pagos hechos en efectivo por cuota diaria, gratificaciones, percepciones, habitación, primas, comisiones, prestaciones en especie y cualquier otra cantidad o prestación que se entregue al trabajador por su trabajo, de conformidad con el Art. 84 de la Ley Federal del Trabajo. (Se utiliza para el cálculo de las indemnizaciones). Se debe ingresar cuando se esté obligado conforme a otras disposiciones distintas a las fiscales.</remarks>
    Public Property SalarioDiarioIntegrado As Decimal
        Get
            Return _salarioDiarioIntegrado
        End Get
        Set(value As Decimal)
            _salarioDiarioIntegrado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la clave de la entidad federativa en donde el receptor del recibo prestó el servicio.</remarks>
    Public Property ClaveEntFed As String
        Get
            Return _claveEntFed
        End Get
        Set(value As String)
            _claveEntFed = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar la lista de las personas que los subcontrataron.</remarks>
    Public Property SubContratacion As List(Of NSubContratacion)
        Get
            Return _subContratacion
        End Get
        Set(value As List(Of NSubContratacion))
            _subContratacion = value
        End Set
    End Property

End Class
Public Class NSubContratacion
    Private _rfcLabora As String = String.Empty
    Private _porcentajeTiempo As String = String.Empty
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el RFC de la persona que subcontrata.</remarks>
    Public Property RfcLabora As String
        Get
            Return _rfcLabora
        End Get
        Set(value As String)
            _rfcLabora = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el porcentaje del tiempo que prestó sus servicios con el RFC que lo subcontrata.</remarks>
    Public Property PorcentajeTiempo As String
        Get
            Return _porcentajeTiempo
        End Get
        Set(value As String)
            _porcentajeTiempo = value
        End Set
    End Property

End Class
Public Class NPercepciones
    Private _totalSueldos As Decimal = 0
    Private _totalSeparacionIndemnizacion As Decimal = 0
    Private _totalJubilacionPensionRetiro As Decimal = 0
    Private _totalGravado As Decimal
    Private _totalExento As Decimal
    Private _percepcion As List(Of NPercepcion) = New List(Of NPercepcion)()
    Private _jubilacionPensionRetiro As NJubilacionPensionRetiro = New NJubilacionPensionRetiro()
    Private _separacionIndeminzacion As NSeparacionIndemnizacion = New NSeparacionIndemnizacion()
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el total de percepciones brutas (gravadas y exentas) por sueldos y salarios y conceptos asimilados a salarios.</remarks>
    Public Property TotalSueldos As Decimal
        Get
            Return _totalSueldos
        End Get
        Set(value As Decimal)
            _totalSueldos = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el importe exento y gravado de las claves tipo percepción 022 Prima por Antigüedad, 023 Pagos por separación y 025 Indemnizaciones.</remarks>
    Public Property TotalSeparacionIndemnizacion As Decimal
        Get
            Return _totalSeparacionIndemnizacion
        End Get
        Set(value As Decimal)
            _totalSeparacionIndemnizacion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el importe exento y gravado de las claves tipo percepción 039 Jubilaciones, pensiones o haberes de retiro en una exhibición y 044 Jubilaciones, pensiones o haberes de retiro en parcialidades.</remarks>
    Public Property TotalJubilacionPensionRetiro As Decimal
        Get
            Return _totalJubilacionPensionRetiro
        End Get
        Set(value As Decimal)
            _totalJubilacionPensionRetiro = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el total de percepciones gravadas que se relacionan en el comprobante.</remarks>
    Public Property TotalGravado As Decimal
        Get
            Return _totalGravado
        End Get
        Set(value As Decimal)
            _totalGravado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el total de percepciones exentas que se relacionan en el comprobante.</remarks>
    Public Property TotalExento As Decimal
        Get
            Return _totalExento
        End Get
        Set(value As Decimal)
            _totalExento = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Nodo requerido para expresar la información detallada de una percepción.</remarks>
    Public Property Percepcion As List(Of NPercepcion)
        Get
            Return _percepcion
        End Get
        Set(value As List(Of NPercepcion))
            _percepcion = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar la información detallada de pagos por jubilación, pensiones o haberes de retiro.</remarks>
    Public Property JubilacionPensionRetiro As NJubilacionPensionRetiro
        Get
            Return _jubilacionPensionRetiro
        End Get
        Set(value As NJubilacionPensionRetiro)
            _jubilacionPensionRetiro = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar la información detallada de otros pagos por separación.</remarks>
    Public Property SeparacionIndeminzacion As NSeparacionIndemnizacion
        Get
            Return _separacionIndeminzacion
        End Get
        Set(value As NSeparacionIndemnizacion)
            _separacionIndeminzacion = value
        End Set
    End Property
End Class
Public Class NPercepcion
    Private _tipoPercepcion As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importeGravado As Decimal = 0
    Private _importeExento As Decimal = 0
    Private _accionesOTitulos As NAccionesOTitulos = New NAccionesOTitulos()
    Private _horasExtras As List(Of NHorasExtra) = New List(Of NHorasExtra)()
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la Clave agrupadora bajo la cual se clasifica la percepción.</remarks>
    Public Property TipoPercepcion As String
        Get
            Return _tipoPercepcion
        End Get
        Set(value As String)
            _tipoPercepcion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la clave de percepción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres.</remarks>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la descripción del concepto de percepción.</remarks>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(value As String)
            _concepto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Atributo requerido, representa el importe gravado de un concepto de percepción.</remarks>
    Public Property ImporteGravado As Decimal
        Get
            Return _importeGravado
        End Get
        Set(value As Decimal)
            _importeGravado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido, representa el importe exento de un concepto de percepción.</remarks>
    Public Property ImporteExento As Decimal
        Get
            Return _importeExento
        End Get
        Set(value As Decimal)
            _importeExento = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar ingresos por acciones o títulos valor que representan bienes. Se vuelve requerido cuando existan ingresos por sueldos derivados de adquisición de acciones o títulos (Art. 94, fracción VII LISR).</remarks>
    Public Property AccionesOTitulos As NAccionesOTitulos
        Get
            Return _accionesOTitulos
        End Get
        Set(value As NAccionesOTitulos)
            _accionesOTitulos = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar las horas extra aplicables.</remarks>
    Public Property HorasExtras As List(Of NHorasExtra)
        Get
            Return _horasExtras
        End Get
        Set(value As List(Of NHorasExtra))
            _horasExtras = value
        End Set
    End Property

End Class
Public Class NAccionesOTitulos
    Private _valorMercado As String = String.Empty
    Private _precioAlOtorgarse As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el valor de mercado de las Acciones o Títulos valor al ejercer la opción.</remarks>
    Public Property ValorMercado As String
        Get
            Return _valorMercado
        End Get
        Set(value As String)
            _valorMercado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el precio establecido al otorgarse la opción de ingresos en acciones o títulos valor.</remarks>
    Public Property PrecioAlOtorgarse As Decimal
        Get
            Return _precioAlOtorgarse
        End Get
        Set(value As Decimal)
            _precioAlOtorgarse = value
        End Set
    End Property
End Class
Public Class NHorasExtra
    Private _dias As String = String.Empty
    Private _tipoHoras As Integer = -1
    Private _horasExtra As Integer = -1
    Private _importePagado As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de días en que el trabajador realizó horas extra en el periodo.</remarks>
    Public Property Dias As String
        Get
            Return _dias
        End Get
        Set(value As String)
            _dias = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el tipo de pago de las horas extra.</remarks>
    Public Property TipoHoras As Integer
        Get
            Return _tipoHoras
        End Get
        Set(value As Integer)
            _tipoHoras = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de horas extra trabajadas en el periodo.</remarks>
    Public Property HorasExtra As Integer
        Get
            Return _horasExtra
        End Get
        Set(value As Integer)
            _horasExtra = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el importe pagado por las horas extra.</remarks>
    Public Property ImportePagado As Decimal
        Get
            Return _importePagado
        End Get
        Set(value As Decimal)
            _importePagado = value
        End Set
    End Property

End Class
Public Class NJubilacionPensionRetiro
    Private _totalUnaExhibicion As Decimal = 0
    Private _totalParcialidad As Decimal = 0
    Private _montoDiario As Decimal = 0
    Private _ingresoAcumulable As Decimal = 0
    Private _ingresoNoAcumulable As Decimal = 0
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional que indica el monto total del pago cuando se realiza en una sola exhibición.</remarks>
    Public Property TotalUnaExhibicion As Decimal
        Get
            Return _totalUnaExhibicion
        End Get
        Set(value As Decimal)
            _totalUnaExhibicion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar los ingresos totales por pago cuando se hace en parcialidades.</remarks>
    Public Property TotalParcialidad As Decimal
        Get
            Return _totalParcialidad
        End Get
        Set(value As Decimal)
            _totalParcialidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el monto diario percibido por jubilación, pensiones o haberes de retiro cuando se realiza en parcialidades.</remarks>
    Public Property MontoDiario As Decimal
        Get
            Return _montoDiario
        End Get
        Set(value As Decimal)
            _montoDiario = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar los ingresos acumulables.</remarks>
    Public Property IngresoAcumulable As Decimal
        Get
            Return _ingresoAcumulable
        End Get
        Set(value As Decimal)
            _ingresoAcumulable = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar los ingresos no acumulables.</remarks>
    Public Property IngresoNoAcumulable As Decimal
        Get
            Return _ingresoNoAcumulable
        End Get
        Set(value As Decimal)
            _ingresoNoAcumulable = value
        End Set
    End Property
End Class
Public Class NSeparacionIndemnizacion
    Private _totalPagado As Decimal = 0
    Private _numAnosServicio As Integer = -1
    Private _ultimoSueldoMensOrd As Decimal = 0
    Private _ingresoAcumulable As Decimal = 0
    Private _ingresoNoAcumulable As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido que indica el monto total del pago.</remarks>
    Public Property TotalPagado As Decimal
        Get
            Return _totalPagado
        End Get
        Set(value As Decimal)
            _totalPagado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de años de servicio del trabajador. Se redondea al entero superior si la cifra contiene años y meses y hay más de 6 meses.</remarks>
    Public Property NumAnosServicio As Decimal
        Get
            Return _numAnosServicio
        End Get
        Set(value As Decimal)
            _numAnosServicio = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido que indica el último sueldo mensual ordinario.</remarks>
    Public Property UltimoSueldoMensOrd As Decimal
        Get
            Return _ultimoSueldoMensOrd
        End Get
        Set(value As Decimal)
            _ultimoSueldoMensOrd = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar los ingresos acumulables.</remarks>
    Public Property IngresoAcumulable As Decimal
        Get
            Return _ingresoAcumulable
        End Get
        Set(value As Decimal)
            _ingresoAcumulable = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido que indica los ingresos no acumulables.</remarks>
    Public Property IngresoNoAcumulable As Decimal
        Get
            Return _ingresoNoAcumulable
        End Get
        Set(value As Decimal)
            _ingresoNoAcumulable = value
        End Set
    End Property
End Class
Public Class NDeducciones
    Private _totalOtrasDeducciones As Decimal
    Private _totalImpuestosRetenidos As Decimal
    Private _deduccion As List(Of NDeduccion) = New List(Of NDeduccion)()
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el total de deducciones que se relacionan en el comprobante, donde la clave de tipo de deducción sea distinta a la 002 correspondiente a ISR.</remarks>
    Public Property TotalOtrasDeducciones As Decimal
        Get
            Return _totalOtrasDeducciones
        End Get
        Set(value As Decimal)
            _totalOtrasDeducciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el total de los impuestos federales retenidos, es decir, donde la clave de tipo de deducción sea 002 correspondiente a ISR.</remarks>
    Public Property TotalImpuestosRetenidos As Decimal
        Get
            Return _totalImpuestosRetenidos
        End Get
        Set(value As Decimal)
            _totalImpuestosRetenidos = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Nodo requerido para expresar la información detallada de una deducción.</remarks>
    Public Property Deduccion As List(Of NDeduccion)
        Get
            Return _deduccion
        End Get
        Set(value As List(Of NDeduccion))
            _deduccion = value
        End Set
    End Property
End Class
Public Class NDeduccion
    Private _tipoDeduccion As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para registrar la clave agrupadora que clasifica la deducción.</remarks>
    Public Property TipoDeduccion As String
        Get
            Return _tipoDeduccion
        End Get
        Set(value As String)
            _tipoDeduccion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la clave de deducción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres.</remarks>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la descripción del concepto de deducción.</remarks>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(value As String)
            _concepto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para registrar el importe del concepto de deducción.</remarks>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class NOtrosPagos
    Private _otroPago As List(Of NOtroPago) = New List(Of NOtroPago)()
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar otros pagos aplicables.</remarks>
    Public Property OtroPago As List(Of NOtroPago)
        Get
            Return _otroPago
        End Get
        Set(value As List(Of NOtroPago))
            _otroPago = value
        End Set
    End Property
End Class
Public Class NOtroPago
    Private _tipoOtroPago As String = String.Empty
    Private _clave As String = String.Empty
    Private _concepto As String = String.Empty
    Private _importe As Decimal = 0
    Private _subsidioAlEmpleo As NSubsidioAlEmpleo = New NSubsidioAlEmpleo()
    Private _compensacionSaldosAFavor As NCompensacionSaldosAFavor = New NCompensacionSaldosAFavor()
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la clave agrupadora bajo la cual se clasifica el otro pago.</remarks>
    Public Property TipoOtroPago As String
        Get
            Return _tipoOtroPago
        End Get
        Set(value As String)
            _tipoOtroPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido, representa la clave de otro pago de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres.</remarks>
    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la descripción del concepto de otro pago.</remarks>
    Public Property Concepto As String
        Get
            Return _concepto
        End Get
        Set(value As String)
            _concepto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el importe del concepto de otro pago.</remarks>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Nodo requerido para expresar la información referente al subsidio al empleo del trabajador.</remarks>
    Public Property SubsidioAlEmpleo As NSubsidioAlEmpleo
        Get
            Return _subsidioAlEmpleo
        End Get
        Set(value As NSubsidioAlEmpleo)
            _subsidioAlEmpleo = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar la información referente a la compensación de saldos a favor de un trabajador.</remarks>
    Public Property CompensacionSaldosAFavor As NCompensacionSaldosAFavor
        Get
            Return _compensacionSaldosAFavor
        End Get
        Set(value As NCompensacionSaldosAFavor)
            _compensacionSaldosAFavor = value
        End Set
    End Property
End Class
Public Class NSubsidioAlEmpleo
    Private _subsidioCausado As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el subsidio causado conforme a la tabla del subsidio para el empleo publicada en el Anexo 8 de la RMF vigente.</remarks>
    Public Property SubsidioCausado As Decimal
        Get
            Return _subsidioCausado
        End Get
        Set(value As Decimal)
            _subsidioCausado = value
        End Set
    End Property
End Class
Public Class NCompensacionSaldosAFavor
    Private _saldoAFavor As Decimal = 0
    Private _ano As String = String.Empty
    Private _remanenteSalFav As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el saldo a favor determinado por el patrón al trabajador en periodos o ejercicios anteriores.</remarks>
    Public Property SaldoAFavor As Decimal
        Get
            Return _saldoAFavor
        End Get
        Set(value As Decimal)
            _saldoAFavor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el año en que se determinó el saldo a favor del trabajador por el patrón que se incluye en el campo “RemanenteSalFav”.</remarks>
    Public Property Ano As String
        Get
            Return _ano
        End Get
        Set(value As String)
            _ano = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el remanente del saldo a favor del trabajador.</remarks>
    Public Property RemanenteSalFav As Decimal
        Get
            Return _remanenteSalFav
        End Get
        Set(value As Decimal)
            _remanenteSalFav = value
        End Set
    End Property
End Class
Public Class NIncapacidades
    Private _incapacidad As List(Of NIncapacidad) = New List(Of NIncapacidad)()
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar información de las incapacidades.</remarks>
    Public Property Incapacidad As List(Of NIncapacidad)
        Get
            Return _incapacidad
        End Get
        Set(value As List(Of NIncapacidad))
            _incapacidad = value
        End Set
    End Property
End Class
Public Class NIncapacidad
    Private _diasIncapacidad As Integer = -1
    Private _tipoIncapacidad As String = String.Empty
    Private _importeMonetario As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de días enteros que el trabajador se incapacitó en el periodo.</remarks>
    Public Property DiasIncapacidad As Decimal
        Get
            Return _diasIncapacidad
        End Get
        Set(value As Decimal)
            _diasIncapacidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la razón de la incapacidad.</remarks>
    Public Property TipoIncapacidad As String
        Get
            Return _tipoIncapacidad
        End Get
        Set(value As String)
            _tipoIncapacidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para expresar el monto del importe monetario de la incapacidad.</remarks>
    Public Property ImporteMonetario As Decimal
        Get
            Return _importeMonetario
        End Get
        Set(value As Decimal)
            _importeMonetario = value
        End Set
    End Property

End Class

''' <summary>
''' Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI) la información que ampara conceptos de ingresos por salarios, la prestación de un servicio personal subordinado o conceptos asimilados a salarios (Nómina).
''' </summary>
''' <remarks>Complemento para incorporar al Comprobante Fiscal Digital por Internet (CFDI) la información que ampara conceptos de ingresos por salarios, la prestación de un servicio personal subordinado o conceptos asimilados a salarios (Nómina).</remarks>
Public Class Nomina
    Public _version As String = String.Empty
    Public _tipoNomina As String = String.Empty
    Public _fechaPago As DateTime = DateTime.Now
    Public _fechaInicialPago As DateTime = DateTime.Now
    Public _fechaFinalPago As DateTime = DateTime.Now
    Public _numDiasPagados As Decimal = 0
    Public _totalPercepciones As Decimal = 0
    Public _totalDeducciones As Decimal = 0
    Public _totalOtrosPagos As Decimal = 0
    Public _emisor As NEmisor
    Public _receptor As NReceptor
    Public _percepciones As NPercepciones
    Public _deducciones As NDeducciones
    Public _otrosPagos As NOtrosPagos
    Public _incapacidades As NIncapacidades
    Public _horasExtra As List(Of NHorasExtra) = New List(Of NHorasExtra)

    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión de la versión del complemento. Valor prefijado 1.2</remarks>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Atributo requerido para indicar el tipo de nómina, puede ser O= Nómina ordinaria o E= Nómina extraordinaria.</remarks>
    Public Property TipoNomina As String
        Get
            Return _tipoNomina
        End Get
        Set(value As String)
            _tipoNomina = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión de la fecha efectiva de erogación del gasto. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.</remarks>
    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(value As DateTime)
            _fechaPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión de la fecha inicial del período de pago. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.</remarks>
    Public Property FechaInicialPago As DateTime
        Get
            Return _fechaInicialPago
        End Get
        Set(value As DateTime)
            _fechaInicialPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión de la fecha final del período de pago. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.</remarks>
    Public Property FechaFinalPago As DateTime
        Get
            Return _fechaFinalPago
        End Get
        Set(value As DateTime)
            _fechaFinalPago = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para la expresión del número o la fracción de días pagados. Posiciones decimales 3.</remarks>
    Public Property NumDiasPagados As Decimal
        Get
            Return _numDiasPagados
        End Get
        Set(value As Decimal)
            _numDiasPagados = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para representar la suma de las percepciones.</remarks>
    Public Property TotalPercepciones As Decimal
        Get
            Return _totalPercepciones
        End Get
        Set(value As Decimal)
            _totalPercepciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional
    ''' </summary>
    ''' <remarks>Atributo condicional para representar la suma de las deducciones aplicables.</remarks>
    Public Property TotalDeducciones As Decimal
        Get
            Return _totalDeducciones
        End Get
        Set(value As Decimal)
            _totalDeducciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo condicional para representar la suma de otros pagos.</remarks>
    Public Property TotalOtrosPagos As Decimal
        Get
            Return _totalOtrosPagos
        End Get
        Set(value As Decimal)
            _totalOtrosPagos = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar la información del contribuyente emisor del comprobante de nómina.</remarks>
    Public Property Emisor As NEmisor
        Get
            Return _emisor
        End Get
        Set(value As NEmisor)
            _emisor = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Nodo requerido para precisar la información del contribuyente receptor del comprobante de nómina.</remarks>
    Public Property Receptor As NReceptor
        Get
            Return _receptor
        End Get
        Set(value As NReceptor)
            _receptor = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar las percepciones aplicables.</remarks>
    Public Property Percepciones As NPercepciones
        Get
            Return _percepciones
        End Get
        Set(value As NPercepciones)
            _percepciones = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Nodo opcional para expresar las deducciones aplicables.</remarks>
    Public Property Deducciones As NDeducciones
        Get
            Return _deducciones
        End Get
        Set(value As NDeducciones)
            _deducciones = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar otros pagos aplicables.</remarks>
    Public Property OtrosPagos As NOtrosPagos
        Get
            Return _otrosPagos
        End Get
        Set(value As NOtrosPagos)
            _otrosPagos = value
        End Set
    End Property
    ''' <summary>
    ''' Condicional.
    ''' </summary>
    ''' <remarks>Nodo condicional para expresar información de las incapacidades.</remarks>
    Public Property Incapacidades As NIncapacidades
        Get
            Return _incapacidades
        End Get
        Set(value As NIncapacidades)
            _incapacidades = value
        End Set
    End Property
    Public Property HorasExtra As List(Of NHorasExtra)
        Get
            Return _horasExtra
        End Get
        Set(value As List(Of NHorasExtra))
            _horasExtra = value
        End Set
    End Property
End Class
#End Region
#Region "Complemento Pagos 1.0 - Se reemplazo por la version 2.0"
'Public Class PTraslado
'    Private _impuesto As String = String.Empty
'    Private _tipoFactor As String = String.Empty
'    Private _tasaOCuota As Decimal = 0
'    Private _importe As Decimal = 0
'    '' <summary>
'    ''' <value>Requerido</value> 
'    ''' <para>Señalar la clave del tipo de impuesto trasladado.</para>
'    ''' </summary>
'    Public Property Impuesto As String
'        Get
'            Return _impuesto
'        End Get
'        Set(ByVal value As String)
'            _impuesto = value
'        End Set
'    End Property
'    '''<summary>
'    '''<value>Requerido</value> 
'    ''' <para> señalar la clave del tipo de factor que se aplica a la base del impuesto.</para>
'    ''' </summary>
'    Public Property TipoFactor As String
'        Get
'            Return _tipoFactor
'        End Get
'        Set(ByVal value As String)
'            _tipoFactor = value
'        End Set
'    End Property
'    ''' <summary>
'    '''<value>Requerido</value> 
'    ''' <para>Señalar el valor de la tasa o cuota del impuesto que se traslada.</para>
'    ''' </summary>
'    Public Property TasaOCuota As Decimal
'        Get
'            Return _tasaOCuota
'        End Get
'        Set(ByVal value As Decimal)
'            _tasaOCuota = value
'        End Set
'    End Property
'    ''' <summary>
'    '''<value>Requerido</value> 
'    ''' <para>Señalar el importe del impuesto trasladado. No se permiten valores negativos.</para>
'    ''' </summary>
'    Public Property Importe As Decimal
'        Get
'            Return _importe
'        End Get
'        Set(ByVal value As Decimal)
'            _importe = value
'        End Set
'    End Property
'End Class

'Public Class PTraslados

'    Private _traslado As List(Of PTraslado)
'    ''' <summary>
'    ''' <para>Nodo condicional para capturar los impuestos trasladados aplicables.</para>
'    '''Traslado (1, Ilimitado) 
'    ''' </summary>
'    Public Property Traslado As List(Of PTraslado)
'        Get
'            Return _traslado
'        End Get
'        Set(ByVal value As List(Of PTraslado))
'            _traslado = value
'        End Set
'    End Property
'End Class

'Public Class PRetencion
'    Private _impuesto As String = String.Empty
'    Private _importe As Decimal = 0
'    ''' <summary>
'    '''<value>Requerido</value> 
'    ''' <para>señalar la clave del tipo de impuesto retenido.</para>
'    ''' </summary>
'    Public Property Impuesto As String
'        Get
'            Return _impuesto
'        End Get
'        Set(ByVal value As String)
'            _impuesto = value
'        End Set
'    End Property
'    '''<summary>
'    '''<value>Requerido</value> 
'    ''' <para>señalar el importe o monto del impuesto retenido. No se permiten valores negativos.</para>
'    ''' </summary>
'    Public Property Importe As Decimal
'        Get
'            Return _importe
'        End Get
'        Set(ByVal value As Decimal)
'            _importe = value
'        End Set
'    End Property
'End Class

'Public Class PRetenciones
'    Private _pretencion As List(Of PRetencion)
'    '''<summary>
'    '''<value>Requerido</value> 
'    '''<para>Nodo requerido para registrar la información detallada de una retención de impuesto específico.</para>
'    ''' </summary>
'    Public Property Retencion As List(Of PRetencion)
'        Get
'            Return _pretencion
'        End Get
'        Set(ByVal value As List(Of PRetencion))
'            _pretencion = value
'        End Set
'    End Property
'End Class

'Public Class PImpuestos
'    Private _TotalImpuestosRetenidos As Decimal = 0
'    Private _TotalImpuestosTrasladados As Decimal = 0
'    Private _retenciones As PRetenciones
'    Private _traslados As PTraslados
'    ''' <summary>
'    ''' <value>Opcional</value>
'    ''' <para>Expresar el total de los impuestos retenidos que se desprenden del pago. No se permiten valores negativos.</para>
'    ''' </summary>
'    Public Property TotalImpuestosRetenidos As Decimal
'        Get
'            Return _TotalImpuestosRetenidos
'        End Get
'        Set(ByVal value As Decimal)
'            _TotalImpuestosRetenidos = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' <value>Opcional</value>
'    ''' <para>Expresar el total de los impuestos trasladados que se desprenden del pago. No se permiten valores negativos.</para>
'    ''' </summary>
'    Public Property TotalImpuestosTrasladados As Decimal
'        Get
'            Return _TotalImpuestosTrasladados
'        End Get
'        Set(ByVal value As Decimal)
'            _TotalImpuestosTrasladados = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' <value>Opcional</value>
'    ''' <para>Nodo condicional para capturar los impuestos retenidos aplicables.</para>
'    ''' </summary>
'    Public Property Retenciones As PRetenciones
'        Get
'            Return _retenciones
'        End Get
'        Set(ByVal value As PRetenciones)
'            _retenciones = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' <value>Opcional</value>
'    ''' <para>Nodo condicional para capturar los impuestos trasladados aplicables.</para>
'    ''' </summary>
'    Public Property Traslados As PTraslados
'        Get
'            Return _traslados
'        End Get
'        Set(ByVal value As PTraslados)
'            _traslados = value
'        End Set
'    End Property
'End Class

'Public Class PDoctoRelacionado
'    Private _idDocumento As String = String.Empty
'    Private _serie As String = String.Empty
'    Private _folio As String = String.Empty
'    Private _monedaDR As String = String.Empty
'    Private _tipoCambioDR As Decimal = 0
'    Private _metodoDePagoDR As String = String.Empty
'    Private _numParcialidad As String = String.Empty
'    Private _impSaldoAnt As Decimal = 0
'    Private _impPagado As Decimal = 0
'    Private _impSaldoInsoluto As Decimal = 0

'    Public Property IdDocumento As String
'        Get
'            Return _idDocumento
'        End Get
'        Set(value As String)
'            _idDocumento = value
'        End Set
'    End Property

'    Public Property Serie As String
'        Get
'            Return _serie
'        End Get
'        Set(value As String)
'            _serie = value
'        End Set
'    End Property
'    Public Property Folio As String
'        Get
'            Return _folio
'        End Get
'        Set(value As String)
'            _folio = value
'        End Set
'    End Property
'    Public Property MonedaDR As String
'        Get
'            Return _monedaDR
'        End Get
'        Set(value As String)
'            _monedaDR = value
'        End Set
'    End Property
'    Public Property TipoCambioDR As Decimal
'        Get
'            Return _tipoCambioDR
'        End Get
'        Set(value As Decimal)
'            _tipoCambioDR = value
'        End Set
'    End Property
'    Public Property MetodoDePagoDR As String
'        Get
'            Return _metodoDePagoDR
'        End Get
'        Set(value As String)
'            _metodoDePagoDR = value
'        End Set
'    End Property
'    Public Property NumParcialidad As String
'        Get
'            Return _numParcialidad
'        End Get
'        Set(value As String)
'            _numParcialidad = value
'        End Set
'    End Property
'    Public Property ImpSaldoAnt As Decimal
'        Get
'            Return _impSaldoAnt
'        End Get
'        Set(value As Decimal)
'            _impSaldoAnt = value
'        End Set
'    End Property
'    Public Property ImpPagado As Decimal
'        Get
'            Return _impPagado
'        End Get
'        Set(value As Decimal)
'            _impPagado = value
'        End Set
'    End Property
'    Public Property ImpSaldoInsoluto As Decimal
'        Get
'            Return _impSaldoInsoluto
'        End Get
'        Set(value As Decimal)
'            _impSaldoInsoluto = value
'        End Set
'    End Property
'End Class
'Public Class Pago
'    Private _fechaPago As DateTime = DateTime.Now
'    Private _formaDePagoP As String = String.Empty
'    Private _monedaP As String = String.Empty
'    Private _tipoCambioP As String = String.Empty
'    Private _monto As Decimal = 0
'    Private _numOperacion As String = String.Empty
'    Private _rfcEmisorCtaOrd As String = String.Empty
'    Private _nomBancoOrdExt As String = String.Empty
'    Private _ctaOrdenante As String = String.Empty
'    Private _rfcEmisorCtaBen As String = String.Empty
'    Private _ctaBeneficiario As String = String.Empty
'    Private _tipoCadPago As String = String.Empty
'    Private _certPago As String = String.Empty
'    Private _cadPago As String = String.Empty
'    Private _selloPago As String = String.Empty
'    Private _doctoRelacionado As List(Of PDoctoRelacionado) = New List(Of PDoctoRelacionado)()
'    Private _impuestos As List(Of PImpuestos) = New List(Of PImpuestos)

'    Public Property FechaPago As DateTime
'        Get
'            Return _fechaPago
'        End Get
'        Set(value As DateTime)
'            _fechaPago = value
'        End Set
'    End Property
'    Public Property FormaDePagoP As String
'        Get
'            Return _formaDePagoP
'        End Get
'        Set(value As String)
'            _formaDePagoP = value
'        End Set
'    End Property
'    Public Property MonedaP As String
'        Get
'            Return _monedaP
'        End Get
'        Set(value As String)
'            _monedaP = value
'        End Set
'    End Property
'    Public Property TipoCambioP As Decimal
'        Get
'            Return _tipoCambioP
'        End Get
'        Set(value As Decimal)
'            _tipoCambioP = value
'        End Set
'    End Property
'    Public Property Monto As Decimal
'        Get
'            Return _monto
'        End Get
'        Set(value As Decimal)
'            _monto = value
'        End Set
'    End Property
'    Public Property NumOperacion As String
'        Get
'            Return _numOperacion
'        End Get
'        Set(value As String)
'            _numOperacion = value
'        End Set
'    End Property
'    Public Property RfcEmisorCtaOrd As String
'        Get
'            Return _rfcEmisorCtaOrd
'        End Get
'        Set(value As String)
'            _rfcEmisorCtaOrd = value
'        End Set
'    End Property
'    Public Property NomBancoOrdExt As String
'        Get
'            Return _nomBancoOrdExt
'        End Get
'        Set(value As String)
'            _nomBancoOrdExt = value
'        End Set
'    End Property
'    Public Property CtaOrdenante As String
'        Get
'            Return _ctaOrdenante
'        End Get
'        Set(value As String)
'            _ctaOrdenante = value
'        End Set
'    End Property
'    Public Property RfcEmisorCtaBen As String
'        Get
'            Return _rfcEmisorCtaBen
'        End Get
'        Set(value As String)
'            _rfcEmisorCtaBen = value
'        End Set
'    End Property
'    Public Property CtaBeneficiario As String
'        Get
'            Return _ctaBeneficiario
'        End Get
'        Set(value As String)
'            _ctaBeneficiario = value
'        End Set
'    End Property
'    Public Property TipoCadPago As String
'        Get
'            Return _tipoCadPago
'        End Get
'        Set(value As String)
'            _tipoCadPago = value
'        End Set
'    End Property
'    Public Property CertPago As String
'        Get
'            Return _certPago
'        End Get
'        Set(value As String)
'            _certPago = value
'        End Set
'    End Property
'    Public Property CadPago As String
'        Get
'            Return _cadPago
'        End Get
'        Set(value As String)
'            _cadPago = value
'        End Set
'    End Property
'    Public Property SelloPago As String
'        Get
'            Return _selloPago
'        End Get
'        Set(value As String)
'            _selloPago = value
'        End Set
'    End Property
'    Public Property DoctoRelacionado As List(Of PDoctoRelacionado)
'        Get
'            Return _doctoRelacionado
'        End Get
'        Set(value As List(Of PDoctoRelacionado))
'            _doctoRelacionado = value
'        End Set
'    End Property
'    Public Property Impuestos As List(Of PImpuestos)
'        Get
'            Return _impuestos
'        End Get
'        Set(value As List(Of PImpuestos))
'            _impuestos = value
'        End Set
'    End Property
'End Class
'Public Class Pagos
'    Private _version As String = String.Empty
'    Private _pago As List(Of Pago) = New List(Of Pago)()
'    Public Property Version As String
'        Get
'            Return _version
'        End Get
'        Set(value As String)
'            _version = value
'        End Set
'    End Property
'    Public Property Pago As List(Of Pago)
'        Get
'            Return _pago
'        End Get
'        Set(value As List(Of Pago))
'            _pago = value
'        End Set
'    End Property
'End Class

#End Region
#Region "Complemento Pagos 2.0"
Public Class Pagos
    Private _totales As PTotales = New PTotales()
    Private _pago As List(Of Pago) = New List(Of Pago)()
    Private _version As String = "2.0"

    Public Property Totales As PTotales
        Get
            Return _totales
        End Get
        Set(ByVal value As PTotales)
            _totales = value
        End Set
    End Property

    Public Property Pago As List(Of Pago)
        Get
            Return _pago
        End Get
        Set(ByVal value As List(Of Pago))
            _pago = value
        End Set
    End Property

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property
End Class
Public Class PTotales
    Private _totalRetencionesIVA As Decimal = 0D
    Private _totalRetencionesISR As Decimal = 0D
    Private _totalRetencionesIEPS As Decimal = 0D
    Private _totalTrasladosBaseIVA16 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA16 As Decimal = 0D
    Private _totalTrasladosBaseIVA8 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA8 As Decimal = 0D
    Private _totalTrasladosBaseIVA0 As Decimal = 0D
    Private _totalTrasladosImpuestoIVA0 As Decimal = 0D
    Private _totalTrasladosBaseIVAExento As Decimal = 0D
    Private _montoTotalPagos As Decimal = 0D

    Public Property TotalRetencionesIVA As Decimal
        Get
            Return _totalRetencionesIVA
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesIVA = value
        End Set
    End Property

    Public Property TotalRetencionesISR As Decimal
        Get
            Return _totalRetencionesISR
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesISR = value
        End Set
    End Property

    Public Property TotalRetencionesIEPS As Decimal
        Get
            Return _totalRetencionesIEPS
        End Get
        Set(ByVal value As Decimal)
            _totalRetencionesIEPS = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA16 As Decimal
        Get
            Return _totalTrasladosBaseIVA16
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA16 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA16 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA16
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA16 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA8 As Decimal
        Get
            Return _totalTrasladosBaseIVA8
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA8 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA8 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA8
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA8 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVA0 As Decimal
        Get
            Return _totalTrasladosBaseIVA0
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVA0 = value
        End Set
    End Property

    Public Property TotalTrasladosImpuestoIVA0 As Decimal
        Get
            Return _totalTrasladosImpuestoIVA0
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosImpuestoIVA0 = value
        End Set
    End Property

    Public Property TotalTrasladosBaseIVAExento As Decimal
        Get
            Return _totalTrasladosBaseIVAExento
        End Get
        Set(ByVal value As Decimal)
            _totalTrasladosBaseIVAExento = value
        End Set
    End Property

    Public Property MontoTotalPagos As Decimal
        Get
            Return _montoTotalPagos
        End Get
        Set(ByVal value As Decimal)
            _montoTotalPagos = value
        End Set
    End Property
End Class
Public Class Pago
    Private _fechaPago As DateTime
    Private _formaDePagoP As String = String.Empty
    Private _monedaP As String = String.Empty
    Private _tipoCambioP As Decimal = 0
    Private _monto As Decimal = 0
    Private _numOperacion As String = String.Empty
    Private _rfcEmisorCtaOrd As String = String.Empty
    Private _nomBancoOrdExt As String = String.Empty
    Private _ctaOrdenante As String = String.Empty
    Private _rfcEmisorCtaBen As String = String.Empty
    Private _ctaBeneficiario As String = String.Empty
    Private _tipoCadPago As String = String.Empty
    Private _certPago As String = String.Empty
    Private _cadPago As String = String.Empty
    Private _selloPago As String = String.Empty
    Private _doctoRelacionado As List(Of PDoctoRelacionado) = New List(Of PDoctoRelacionado)()
    Private _impuestos As ImpuestosP

    Public Property FechaPago As DateTime
        Get
            Return _fechaPago
        End Get
        Set(ByVal value As DateTime)
            _fechaPago = value
        End Set
    End Property

    Public Property FormaDePagoP As String
        Get
            Return _formaDePagoP
        End Get
        Set(ByVal value As String)
            _formaDePagoP = value
        End Set
    End Property

    Public Property MonedaP As String
        Get
            Return _monedaP
        End Get
        Set(ByVal value As String)
            _monedaP = value
        End Set
    End Property

    Public Property TipoCambioP As Decimal
        Get
            Return _tipoCambioP
        End Get
        Set(ByVal value As Decimal)
            _tipoCambioP = value
        End Set
    End Property

    Public Property Monto As Decimal
        Get
            Return _monto
        End Get
        Set(ByVal value As Decimal)
            _monto = value
        End Set
    End Property

    Public Property NumOperacion As String
        Get
            Return _numOperacion
        End Get
        Set(ByVal value As String)
            _numOperacion = value
        End Set
    End Property

    Public Property RfcEmisorCtaOrd As String
        Get
            Return _rfcEmisorCtaOrd
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaOrd = value
        End Set
    End Property

    Public Property NomBancoOrdExt As String
        Get
            Return _nomBancoOrdExt
        End Get
        Set(ByVal value As String)
            _nomBancoOrdExt = value
        End Set
    End Property

    Public Property CtaOrdenante As String
        Get
            Return _ctaOrdenante
        End Get
        Set(ByVal value As String)
            _ctaOrdenante = value
        End Set
    End Property

    Public Property RfcEmisorCtaBen As String
        Get
            Return _rfcEmisorCtaBen
        End Get
        Set(ByVal value As String)
            _rfcEmisorCtaBen = value
        End Set
    End Property

    Public Property CtaBeneficiario As String
        Get
            Return _ctaBeneficiario
        End Get
        Set(ByVal value As String)
            _ctaBeneficiario = value
        End Set
    End Property

    Public Property TipoCadPago As String
        Get
            Return _tipoCadPago
        End Get
        Set(ByVal value As String)
            _tipoCadPago = value
        End Set
    End Property

    Public Property CertPago As String
        Get
            Return _certPago
        End Get
        Set(ByVal value As String)
            _certPago = value
        End Set
    End Property

    Public Property CadPago As String
        Get
            Return _cadPago
        End Get
        Set(ByVal value As String)
            _cadPago = value
        End Set
    End Property

    Public Property SelloPago As String
        Get
            Return _selloPago
        End Get
        Set(ByVal value As String)
            _selloPago = value
        End Set
    End Property

    Public Property DoctoRelacionado As List(Of PDoctoRelacionado)
        Get
            Return _doctoRelacionado
        End Get
        Set(ByVal value As List(Of PDoctoRelacionado))
            _doctoRelacionado = value
        End Set
    End Property

    Public Property Impuestos As ImpuestosP
        Get
            Return _impuestos
        End Get
        Set(ByVal value As ImpuestosP)
            _impuestos = value
        End Set
    End Property
End Class
Public Class PDoctoRelacionado
    Private _idDocumento As String = String.Empty
    Private _serie As String = String.Empty
    Private _folio As String = String.Empty
    Private _monedaDR As String = String.Empty
    Private _equivalenciaDR As Decimal = 0
    Private _numParcialidad As String = String.Empty
    Private _impSaldoAnt As Decimal = 0
    Private _impPagado As Decimal = 0
    Private _impSaldoInsoluto As Decimal = 0
    Private _objetoImpDR As String = String.Empty
    Private _impuestosDR As ImpuestosDR

    Public Property IdDocumento As String
        Get
            Return _idDocumento
        End Get
        Set(ByVal value As String)
            _idDocumento = value
        End Set
    End Property

    Public Property Serie As String
        Get
            Return _serie
        End Get
        Set(ByVal value As String)
            _serie = value
        End Set
    End Property

    Public Property Folio As String
        Get
            Return _folio
        End Get
        Set(ByVal value As String)
            _folio = value
        End Set
    End Property

    Public Property MonedaDR As String
        Get
            Return _monedaDR
        End Get
        Set(ByVal value As String)
            _monedaDR = value
        End Set
    End Property

    Public Property EquivalenciaDR As Decimal
        Get
            Return _equivalenciaDR
        End Get
        Set(ByVal value As Decimal)
            _equivalenciaDR = value
        End Set
    End Property

    Public Property NumParcialidad As String
        Get
            Return _numParcialidad
        End Get
        Set(ByVal value As String)
            _numParcialidad = value
        End Set
    End Property

    Public Property ImpSaldoAnt As Decimal
        Get
            Return _impSaldoAnt
        End Get
        Set(ByVal value As Decimal)
            _impSaldoAnt = value
        End Set
    End Property

    Public Property ImpPagado As Decimal
        Get
            Return _impPagado
        End Get
        Set(ByVal value As Decimal)
            _impPagado = value
        End Set
    End Property

    Public Property ImpSaldoInsoluto As Decimal
        Get
            Return _impSaldoInsoluto
        End Get
        Set(ByVal value As Decimal)
            _impSaldoInsoluto = value
        End Set
    End Property

    Public Property ObjetoImpDR As String
        Get
            Return _objetoImpDR
        End Get
        Set(ByVal value As String)
            _objetoImpDR = value
        End Set
    End Property

    Public Property ImpuestosDR As ImpuestosDR
        Get
            Return _impuestosDR
        End Get
        Set(ByVal value As ImpuestosDR)
            _impuestosDR = value
        End Set
    End Property
End Class
Public Class ImpuestosDR
    Private _retencionesDR As RetencionesDR
    Private _trasladosDR As TrasladosDR

    Public Property RetencionesDR As RetencionesDR
        Get
            Return _retencionesDR
        End Get
        Set(ByVal value As RetencionesDR)
            _retencionesDR = value
        End Set
    End Property

    Public Property TrasladosDR As TrasladosDR
        Get
            Return _trasladosDR
        End Get
        Set(ByVal value As TrasladosDR)
            _trasladosDR = value
        End Set
    End Property
End Class
Public Class RetencionesDR
    Private _retencionDR As List(Of RetencionDR)

    Public Property RetencionDR As List(Of RetencionDR)
        Get
            Return _retencionDR
        End Get
        Set(ByVal value As List(Of RetencionDR))
            _retencionDR = value
        End Set
    End Property
End Class
Public Class RetencionDR
    Private _baseDR As Decimal = 0
    Private _impuestoDR As String = String.Empty
    Private _tipoFactorDR As String = String.Empty
    Private _tasaOCuotaDR As Decimal = 0
    Private _importeDR As Decimal = 0

    Public Property BaseDR As Decimal
        Get
            Return _baseDR
        End Get
        Set(ByVal value As Decimal)
            _baseDR = value
        End Set
    End Property

    Public Property ImpuestoDR As String
        Get
            Return _impuestoDR
        End Get
        Set(ByVal value As String)
            _impuestoDR = value
        End Set
    End Property

    Public Property TipoFactorDR As String
        Get
            Return _tipoFactorDR
        End Get
        Set(ByVal value As String)
            _tipoFactorDR = value
        End Set
    End Property

    Public Property TasaOCuotaDR As Decimal
        Get
            Return _tasaOCuotaDR
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaDR = value
        End Set
    End Property

    Public Property ImporteDR As Decimal
        Get
            Return _importeDR
        End Get
        Set(ByVal value As Decimal)
            _importeDR = value
        End Set
    End Property
End Class
Public Class TrasladosDR
    Private _trasladoDR As List(Of TrasladoDR)

    Public Property TrasladoDR As List(Of TrasladoDR)
        Get
            Return _trasladoDR
        End Get
        Set(ByVal value As List(Of TrasladoDR))
            _trasladoDR = value
        End Set
    End Property
End Class
Public Class TrasladoDR
    Private _baseDR As Decimal = 0
    Private _impuestoDR As String = String.Empty
    Private _tipoFactorDR As String = String.Empty
    Private _tasaOCuotaDR As Decimal = 0
    Private _importeDR As Decimal = 0

    Public Property BaseDR As Decimal
        Get
            Return _baseDR
        End Get
        Set(ByVal value As Decimal)
            _baseDR = value
        End Set
    End Property

    Public Property ImpuestoDR As String
        Get
            Return _impuestoDR
        End Get
        Set(ByVal value As String)
            _impuestoDR = value
        End Set
    End Property

    Public Property TipoFactorDR As String
        Get
            Return _tipoFactorDR
        End Get
        Set(ByVal value As String)
            _tipoFactorDR = value
        End Set
    End Property

    Public Property TasaOCuotaDR As Decimal
        Get
            Return _tasaOCuotaDR
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaDR = value
        End Set
    End Property

    Public Property ImporteDR As Decimal
        Get
            Return _importeDR
        End Get
        Set(ByVal value As Decimal)
            _importeDR = value
        End Set
    End Property
End Class
Public Class ImpuestosP
    Private _retencionesP As RetencionesP
    Private _trasladosP As TrasladosP

    Public Property RetencionesP As RetencionesP
        Get
            Return _retencionesP
        End Get
        Set(ByVal value As RetencionesP)
            _retencionesP = value
        End Set
    End Property

    Public Property TrasladosP As TrasladosP
        Get
            Return _trasladosP
        End Get
        Set(ByVal value As TrasladosP)
            _trasladosP = value
        End Set
    End Property
End Class
Public Class RetencionesP
    Private _retencionP As List(Of RetencionP) = New List(Of RetencionP)()

    Public Property RetencionP As List(Of RetencionP)
        Get
            Return _retencionP
        End Get
        Set(ByVal value As List(Of RetencionP))
            _retencionP = value
        End Set
    End Property
End Class
Public Class TrasladosP
    Private _trasladoP As List(Of TrasladoP)

    Public Property TrasladoP As List(Of TrasladoP)
        Get
            Return _trasladoP
        End Get
        Set(ByVal value As List(Of TrasladoP))
            _trasladoP = value
        End Set
    End Property
End Class
Public Class RetencionP
    Private _impuestoP As String = String.Empty
    Private _importeP As Decimal = 0

    Public Property ImpuestoP As String
        Get
            Return _impuestoP
        End Get
        Set(ByVal value As String)
            _impuestoP = value
        End Set
    End Property

    Public Property ImporteP As Decimal
        Get
            Return _importeP
        End Get
        Set(ByVal value As Decimal)
            _importeP = value
        End Set
    End Property
End Class
Public Class TrasladoP
    Private _baseP As Decimal = 0
    Private _impuestoP As String = String.Empty
    Private _tipoFactorP As String = String.Empty
    Private _tasaOCuotaP As Decimal = 0
    Private _importeP As Decimal = 0

    Public Property BaseP As Decimal
        Get
            Return _baseP
        End Get
        Set(ByVal value As Decimal)
            _baseP = value
        End Set
    End Property

    Public Property ImpuestoP As String
        Get
            Return _impuestoP
        End Get
        Set(ByVal value As String)
            _impuestoP = value
        End Set
    End Property

    Public Property TipoFactorP As String
        Get
            Return _tipoFactorP
        End Get
        Set(ByVal value As String)
            _tipoFactorP = value
        End Set
    End Property

    Public Property TasaOCuotaP As Decimal
        Get
            Return _tasaOCuotaP
        End Get
        Set(ByVal value As Decimal)
            _tasaOCuotaP = value
        End Set
    End Property

    Public Property ImporteP As Decimal
        Get
            Return _importeP
        End Get
        Set(ByVal value As Decimal)
            _importeP = value
        End Set
    End Property
End Class

#End Region
#Region "Complemento VehiculoUsado"
''' <summary>
''' Complemento opcional que permite incorporar información a los contribuyentes que enajenen vehículos nuevos a personas físicas que no tributen en los términos de las Secciones I y II del Capítulo II del Título IV de la ley del ISR, y que reciban en contraprestación como resultados de esa enajenación un vehículo usado y dinero
''' </summary>
Public Class VehiculoUsado
    Private _version As String = "1.0"
    Private _montoAdquisicion As Decimal = 0
    Private _montoEnajenacion As Decimal = 0
    Private _claveVehicular As String = String.Empty
    Private _marca As String = String.Empty
    Private _tipo As String = String.Empty
    Private _modelo As String = String.Empty
    Private _numeroMotor As String = String.Empty
    Private _numeroSerie As String = String.Empty
    Private _NIV As String = String.Empty
    Private _valor As Decimal = 0
    Private _informacionAduanera As List(Of VUInformacionAduanera) = New List(Of VUInformacionAduanera)()
    ''' <summary>
    ''' Requerido
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la versión del complemento. Valor prefijado a 1.0</remarks>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el monto de adquisición del vehículo usado según factura original, primera venta.</remarks>
    Public Property MontoAdquisicion As Decimal
        Get
            Return _montoAdquisicion
        End Get
        Set(value As Decimal)
            _montoAdquisicion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el monto de enajenación del vehículo usado.</remarks>
    Public Property MontoEnajenacion As Decimal
        Get
            Return _montoEnajenacion
        End Get
        Set(value As Decimal)
            _montoEnajenacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la clave vehicular del vehículo usado. Longitud mínima 1, longitud máxima 7</remarks>
    Public Property ClaveVehicular As String
        Get
            Return _claveVehicular
        End Get
        Set(value As String)
            _claveVehicular = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la marca del vehículo usado. Longitud mínima 1, longitud máxima 50</remarks>
    Public Property Marca As String
        Get
            Return _marca
        End Get
        Set(value As String)
            _marca = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el tipo del vehículo usado. Longitud mínima 1, longitud máxima 50</remarks>
    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el año modelo del vehículo usado.</remarks>
    Public Property Modelo As String
        Get
            Return _modelo
        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar el número de motor del vehículo usado (en caso de contar con dicho número se deberá ingresar). Longitud mínima 1, longitud máxima 17.</remarks>
    Public Property NumeroMotor As String
        Get
            Return _numeroMotor
        End Get
        Set(value As String)
            _numeroMotor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar el número de serie de la carrocería del vehículo usado (en caso de contar con dicho número se deberá ingresar). Longitud mínima 1, longitud máxima 17.</remarks>
    Public Property NumeroSerie As String
        Get
            Return _numeroSerie
        End Get
        Set(value As String)
            _numeroSerie = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para expresar el número de identificación vehicular del vehículo usado (Cuando exista el NIV deberá incluirse este invariablemente). Longitud mínima 1, longitud máxima 17.</remarks>
    Public Property NIV As String
        Get
            Return _NIV
        End Get
        Set(value As String)
            _NIV = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el valor del vehículo, establecido en la Guía EBC o Libro Azul (Guía de Información a Comerciantes de Automóviles y Camiones y Aseguradores de la República Mexicana) vigente, emitida por la Asociación Nacional de Comerciantes en Automóviles y Camiones nuevos y usados A.C.</remarks>
    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(value As String)
            _valor = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Nodo opcional para introducir la información aduanera aplicable cuando se trate de ventas de primera mano de mercancías importadas.</remarks>
    Public Property InformacionAduanera As List(Of VUInformacionAduanera)
        Get
            Return _informacionAduanera
        End Get
        Set(value As List(Of VUInformacionAduanera))
            _informacionAduanera = value
        End Set
    End Property
End Class
Public Class VUInformacionAduanera
    Private _numero As String
    Private _fecha As String
    Private _aduana As String
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número del documento aduanero que ampara la importación del bien. Longitud mínima 1.</remarks>
    Public Property Numero As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la fecha de expedición del documento aduanero que ampara la importación del bien.</remarks>
    Public Property Fecha As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para precisar la aduana por la que se efectuó la importación del bien.</remarks>
    Public Property Aduana As String
        Get
            Return _aduana
        End Get
        Set(value As String)
            _aduana = value
        End Set
    End Property


End Class
#End Region
#Region "Complemento Concepto VentaVehiculos"
''' <summary>
''' Complemento concepto que permite incorporar a los fabricantes, ensambladores o distribuidores autorizados de automóviles nuevos, así como aquéllos que importen automóviles para permanecer en forma definitiva en la franja fronteriza norte del país y en los Estados de Baja California, Baja California Sur y la región parcial del Estado de Sonora, a un Comprobante Fiscal Digital a través de Internet (CFDI) la clave vehicular que corresponda a la versión enajenada y el número de identificación vehicular que corresponda al vehículo enajenado.
''' </summary>
''' <remarks></remarks>
Public Class VentaVehiculos
    Private _version As String = "1.1"
    Private _claveVehicular As String = String.Empty
    Private _NIV As String = String.Empty
    Private _informacionAduanera As List(Of VVInformacionAduanera) = New List(Of VVInformacionAduanera)
    Private _parte As List(Of VVParte) = New List(Of VVParte)()
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido con valor prefijado a 1.1 que indica la versión del estándar bajo el que se encuentra expresado el complemento.</remarks>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para precisar Clave vehicular que corresponda a la versión del vehículo enajenado.</remarks>
    Public Property ClaveVehicular As String
        Get
            Return _claveVehicular
        End Get
        Set(value As String)
            _claveVehicular = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para precisar el número de identificación vehicular que corresponda al vehículo enajenado.</remarks>
    Public Property NIV As String
        Get
            Return _NIV
        End Get
        Set(value As String)
            _NIV = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Nodo opcional para introducir la información aduanera aplicable cuando se trate de ventas de primera mano de mercancías importadas.</remarks>
    Public Property InformacionAduanera As List(Of VVInformacionAduanera)
        Get
            Return _informacionAduanera
        End Get
        Set(value As List(Of VVInformacionAduanera))
            _informacionAduanera = value
        End Set
    End Property
    Public Property Parte As List(Of VVParte)
        Get
            Return _parte
        End Get
        Set(value As List(Of VVParte))
            _parte = value
        End Set
    End Property
End Class
Public Class VVInformacionAduanera
    Private _numero As String
    Private _fecha As String
    Private _aduana As String
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número del documento aduanero que ampara la importación del bien. Longitud mínima 1.</remarks>
    Public Property Numero As String
        Get
            Return _numero
        End Get
        Set(value As String)
            _numero = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar la fecha de expedición del documento aduanero que ampara la importación del bien.</remarks>
    Public Property Fecha As String
        Get
            Return _fecha
        End Get
        Set(value As String)
            _fecha = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para precisar la aduana por la que se efectuó la importación del bien.</remarks>
    Public Property Aduana As String
        Get
            Return _aduana
        End Get
        Set(value As String)
            _aduana = value
        End Set
    End Property


End Class
Public Class VVParte
    Private _cantidad As Decimal = 0
    Private _unidad As String = String.Empty
    Private _noIdentificacion As String = String.Empty
    Private _descripcion As String = String.Empty
    Private _valorUnitario As Decimal = 0
    Private _importe As Decimal = 0
    Private _informacionAduanera As List(Of VVInformacionAduanera) = New List(Of VVInformacionAduanera)()
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la cantidad de bienes o servicios del tipo particular definido por la presente parte.</remarks>
    ''' </summary>
    Public Property Cantidad As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar la unidad de medida aplicable para la cantidad expresada en la parte.</remarks>
    ''' </summary>
    Public Property Unidad As String
        Get
            Return _unidad
        End Get
        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para expresar el número de serie del bien o identificador del servicio amparado por la presente parte.</remarks>
    ''' </summary>
    Public Property NoIdentificacion As String
        Get
            Return _noIdentificacion
        End Get
        Set(ByVal value As String)
            _noIdentificacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar la descripción del bien o servicio cubierto por la presente parte.</remarks>
    ''' </summary>
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar el valor o precio unitario del bien o servicio cubierto por la presente parte.</remarks>
    ''' </summary>
    Public Property ValorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get
        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para precisar el importe total de los bienes o servicios de la presente parte. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario expresado en la parte.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Nodo opcional para introducir la información aduanera aplicable cuando se trate de ventas de primera mano de mercancías importadas o se trate de operaciones de comercio exterior con bienes o servicios.</remarks>
    ''' </summary>
    Public Property InformacionAduanera As List(Of VVInformacionAduanera)
        Get
            Return _informacionAduanera
        End Get

        Set(ByVal value As List(Of VVInformacionAduanera))
            _informacionAduanera = value
        End Set
    End Property
End Class
#End Region
#Region "Complemento Consumo de Combustible"
Public Class CCConcepto
    Private _identificador As String
    Private _fecha As DateTime
    Private _rfc As String
    Private _claveEstacion As String
    Private _tipoCombustible As String
    Private _cantidad As Decimal
    Private _nombreCombustible As String
    Private _folioOperacion As String
    Private _valorUnitario As Decimal
    Private _importe As Decimal
    Private _determinados As CCDeterminados
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para la expresión del identificador o número de monedero electrónico.</remarks>
    ''' </summary>
    Public Property Identificador As String
        Get
            Return _identificador
        End Get

        Set(ByVal value As String)
            _identificador = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para la expresión de la Fecha y hora de expedición de la operación reportada. Se expresa en la forma aaaa-mm-ddThh:mm:ss, de acuerdo con la especificación ISO 8601.</remarks>
    ''' </summary>
    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get

        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido del RFC del enajenante del combustible.</remarks>
    ''' </summary>
    Public Property Rfc As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la clave de cliente de la estacion de servicio, a 10 caracteres, cuando sea requerido.</remarks>
    ''' </summary>
    Public Property claveEstacion As String
        Get
            Return _claveEstacion
        End Get

        Set(ByVal value As String)
            _claveEstacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la clave del tipo de combustible</remarks>
    ''' </summary>
    Public Property TipoCombustible As String
        Get
            Return _tipoCombustible
        End Get

        Set(ByVal value As String)
            _tipoCombustible = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido nara definir el volumen de combustible adquirido.</remarks>
    ''' </summary>
    Public Property cantidad As Decimal
        Get
            Return _cantidad
        End Get

        Set(ByVal value As Decimal)
            _cantidad = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el nombre del combustible adquirido.</remarks>
    ''' </summary>
    Public Property NombreCombustible As String
        Get
            Return _nombreCombustible
        End Get

        Set(ByVal value As String)
            _nombreCombustible = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido pare referir el númerode folio de cada operación realizada por cada monedero elctrónico</remarks>
    ''' </summary>
    Public Property FolioOperacion As String
        Get
            Return _folioOperacion
        End Get

        Set(ByVal value As String)
            _folioOperacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para definir el precio unitario del combustible adquirido.</remarks>
    ''' </summary>
    Public Property valorUnitario As Decimal
        Get
            Return _valorUnitario
        End Get

        Set(ByVal value As Decimal)
            _valorUnitario = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para definir el monto total de consumo de combustible. Debe ser equivalente al resultado de multiplicar la cantidad por el valor unitario.</remarks>
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para enlistar los impuestos determinados aplicables de combustibles.</remarks>
    ''' </summary>
    Public Property Determinados As CCDeterminados
        Get
            Return _determinados
        End Get

        Set(ByVal value As CCDeterminados)
            _determinados = value
        End Set
    End Property
End Class
Public Class CCDeterminado
    Private _impuesto As String = String.Empty
    Private _tasaOCuota As Decimal = 0
    Private _importe As Decimal = 0
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para definir el timpo de impuesto. Valores permitidos IVA, IEPS</remarks>
    ''' </summary>
    Public Property Impuesto As String
        Get
            Return _impuesto
        End Get

        Set(ByVal value As String)
            _impuesto = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para señalar la tasa del impuesto por cada concepto amparado en el comprobante.</remarks>
    ''' </summary>
    Public Property TasaOCuota As Decimal
        Get
            Return _tasaOCuota
        End Get

        Set(ByVal value As Decimal)
            _tasaOCuota = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para definirl el importe o monto del impuesto.</remarks>  
    ''' </summary>
    Public Property Importe As Decimal
        Get
            Return _importe
        End Get

        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
Public Class CCConceptos
    Private _conceptos As List(Of CCConcepto)
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para enlistar los conceptos cubiertos por Consumo de Combustibles.</remarks>  
    ''' </summary>
    Public Property Conceptos As List(Of CCConcepto)
        Get
            Return _conceptos
        End Get
        Set(value As List(Of CCConcepto))
            _conceptos = value
        End Set
    End Property
End Class
Public Class CCDeterminados
    Private _determinados As List(Of CCDeterminado)
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para enlistar los impuestos determinados aplicables de combustibles.</remarks>  
    ''' </summary>
    Public Property Determinados As List(Of CCDeterminado)
        Get
            Return _determinados
        End Get
        Set(value As List(Of CCDeterminado))
            _determinados = value
        End Set
    End Property
End Class
Public Class ConsumoDeCombustibles
    Private _version As String = "1.1"
    Private _tipoOperacion As String
    Private _numeroDeCuenta As String
    Private _subTotal As Decimal
    Private _total As Decimal
    Private _conceptos As CCConceptos
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para la expresión de la versión del complemento.</remarks>
    ''' </summary>
    Public Property version As String
        Get
            Return _version
        End Get

        Set(ByVal value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el tipo de operación de acuerdo con el medio de pago.</remarks>
    ''' </summary>
    Public Property TipoOperacion As String
        Get
            Return _tipoOperacion
        End Get

        Set(ByVal value As String)
            _tipoOperacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para expresar el número de cuenta  del adquiriente del monedero electrónico.</remarks>
    ''' </summary>
    Public Property NumeroDeCuenta As String
        Get
            Return _numeroDeCuenta
        End Get

        Set(ByVal value As String)
            _numeroDeCuenta = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' <remarks>Atributo opcional para representar la suma de todos los importes tipo ConceptoConsumoDeCombustibles.</remarks>
    ''' </summary>
    Public Property Subtotal As Decimal
        Get
            Return _subTotal
        End Get

        Set(ByVal value As Decimal)
            _subTotal = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el monto total de consumo de combustibles.</remarks>
    ''' </summary>
    Public Property Total As Decimal
        Get
            Return _total
        End Get

        Set(ByVal value As Decimal)
            _total = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para enlistar los conceptos cubiertos por Consumo de Combustibles.</remarks>
    ''' </summary>
    Public Property Conceptos As CCConceptos
        Get
            Return _conceptos
        End Get

        Set(ByVal value As CCConceptos)
            _conceptos = value
        End Set
    End Property

End Class
#End Region
#Region "Complemento Ingresos Hidrocarburos"
''' <summary>
''' Estándar del Complemento Ingresos atribuibles a los Integrantes de un Consorcio derivados de la Contraprestación de un Contrato de Exploración o Extracción de Hidrocarburos.
''' </summary>
''' <remarks></remarks>
Public Class IngresosHidrocarburos
    Private _version As String = String.Empty
    Private _numeroContrato As String = String.Empty
    Private _contraPrestacionPagadaOperador As Decimal = 0
    Private _porcentaje As Decimal = 0
    Private _documentoRelacionado As List(Of IHDocumentoRelacionado) = New List(Of IHDocumentoRelacionado)
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido que indica la versión del complemento.</remarks>
    ''' </summary>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el número de contrato asignado por la Comisión Nacional de Hidrocarburos con el cual se encuentra vinculado el ingreso.</remarks>
    ''' </summary>
    Public Property NumeroContrato As String
        Get
            Return _numeroContrato
        End Get
        Set(value As String)
            _numeroContrato = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para precisar el importe total de las contraprestaciones pagadas al operador del consorcio.</remarks>
    ''' </summary>
    Public Property ContraPrestacionPagadaOperador As Decimal
        Get
            Return _contraPrestacionPagadaOperador
        End Get
        Set(value As Decimal)
            _contraPrestacionPagadaOperador = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el porcentaje que ampara el CFDI que emite cada integrante del consorcio al operador, respecto del total de las contraprestaciones entregadas al operador del consorcio por el FMP.</remarks>
    ''' </summary>
    Public Property Porcentaje As Decimal
        Get
            Return _porcentaje
        End Get
        Set(value As Decimal)
            _porcentaje = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Nodo requerido para expresar la información del documento relacionado al ingreso.</remarks>
    ''' </summary>
    Public Property DocumentoRelacionado As List(Of IHDocumentoRelacionado)
        Get
            Return _documentoRelacionado
        End Get
        Set(value As List(Of IHDocumentoRelacionado))
            _documentoRelacionado = value
        End Set
    End Property
End Class
Public Class IHDocumentoRelacionado
    Private _folioFiscalVinculado As String
    Private _fechaFolioFiscalVinculado As String
    Private _mes As String
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el folio fiscal del CFDI expedido por el operador del consorcio al FMP.</remarks>
    ''' </summary>
    Public Property FolioFiscalVinculado As String
        Get
            Return _folioFiscalVinculado
        End Get
        Set(value As String)
            _folioFiscalVinculado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar la fecha del CFDI expedido por el operador del consorcio al FMP. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.</remarks>
    ''' </summary>
    Public Property FechaFolioFiscalVinculado As String
        Get
            Return _fechaFolioFiscalVinculado
        End Get
        Set(value As String)
            _fechaFolioFiscalVinculado = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' <remarks>Atributo requerido para expresar el mes que corresponda al CFDI expedido por el operador del consorcio al FMP.</remarks>
    ''' </summary>
    Public Property Mes As String
        Get
            Return _mes
        End Get
        Set(value As String)
            _mes = value
        End Set
    End Property
End Class
#End Region
#Region "Complemento Gastos Hidrocarburos"
''' <summary>
''' Complemento para Gastos del Consorcio derivados de la Ejecución de un Contrato de Exploración o Extracción de Hidrocarburos.
''' </summary>
''' <remarks></remarks>
Public Class GastosHidrocarburos
    Private _version As String = "1.0"
    Private _numeroContrato As String = String.Empty
    Private _areaContractual As String = String.Empty
    Private _erogacion As List(Of Erogacion) = New List(Of Erogacion)
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido que indica la versión del complemento.</remarks>
    Public Property Version As String
        Get
            Return _version
        End Get
        Set(value As String)
            _version = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el número de contrato asignado por la Comisión Nacional de Hidrocarburos con el cual se encuentra vinculado el gasto.</remarks>
    Public Property NumeroContrato As String
        Get
            Return _numeroContrato
        End Get
        Set(value As String)
            _numeroContrato = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Atributo opcional para especificar el centro de costos del área contractual al cual se encuentra relacionado el costo, gasto o inversión, conforme a los “Lineamientos para la elaboración y presentación de los costos, gastos e inversiones; la procura de bienes y servicios en los contratos y asignaciones; la verificación contable y financiera de los contratos, y la actualización de regalías en contratos y del derecho de extracción de hidrocarburos”, emitidos por la Secretaria de Hacienda y Crédito Público.</remarks>
    Public Property AreaContractual As String
        Get
            Return _areaContractual
        End Get
        Set(value As String)
            _areaContractual = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Nodo requerido para capturar los datos de la erogación.</remarks>
    Public Property Erogacion As List(Of Erogacion)
        Get
            Return _erogacion
        End Get
        Set(value As List(Of Erogacion))
            _erogacion = value
        End Set
    End Property
End Class
Public Class Erogacion
    Private _tipoErogacion As String = String.Empty
    Private _montocuErogacion As Decimal = 0
    Private _porcentaje As Decimal = 0
    Private _documentoRelacionado As List(Of EDocumentoRelacionado) = New List(Of EDocumentoRelacionado)
    Private _actividades As List(Of Actividades) = New List(Of Actividades)()
    Private _centroCostos As List(Of CentroCostos) = New List(Of CentroCostos)()
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para señalar el tipo de erogación realizada por el operador.</remarks>
    Public Property TipoErogacion As String
        Get
            Return _tipoErogacion
        End Get
        Set(value As String)
            _tipoErogacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el importe de cada uno de los costos, gastos o inversiones efectuados en el mes de que se trate y que integran el total del monto del CFDI emitido al integrante del consorcio y que se encuentran amparados en el CFDI o en el comprobante fiscal que cumpla con lo dispuesto en la regla 2.7.1.16. (o la regla que corresponda en la RMF del ejercicio de que se trate), expedido a favor del operador del consorcio.</remarks>
    Public Property MontocuErogacion As Decimal
        Get
            Return _montocuErogacion
        End Get
        Set(value As Decimal)
            _montocuErogacion = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Atributo requerido para expresar el porcentaje que representa el importe total del CFDI que se expide al integrante del consorcio por los costos, gastos o inversiones efectuados en el mes de que se trate, en relación al importe total de los comprobantes expedidos al operador del consorcio.</remarks>
    Public Property Porcentaje As Decimal
        Get
            Return _porcentaje
        End Get
        Set(value As Decimal)
            _porcentaje = value
        End Set
    End Property
    ''' <summary>
    ''' Requerido.
    ''' </summary>
    ''' <remarks>Nodo requerido para expresar la información del documento relacionado a la erogación.</remarks>
    Public Property DocumentoRelacionado As List(Of EDocumentoRelacionado)
        Get
            Return _documentoRelacionado
        End Get
        Set(value As List(Of EDocumentoRelacionado))
            _documentoRelacionado = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Nodo opcional para registrar las actividades petroleras.</remarks>
    Public Property Actividades As List(Of Actividades)
        Get
            Return _actividades
        End Get
        Set(value As List(Of Actividades))
            _actividades = value
        End Set
    End Property
    ''' <summary>
    ''' Opcional.
    ''' </summary>
    ''' <remarks>Nodo opcional para capturar los datos complementarios del centro de costos al cual se encuentra relacionado el costo, gasto o inversión, especificando el pozo, yacimiento, campo y área contractual correspondiente.</remarks>
    Public Property CentroCostos As List(Of CentroCostos)
        Get
            Return _centroCostos
        End Get
        Set(value As List(Of CentroCostos))
            _centroCostos = value
        End Set
    End Property

End Class
Public Class EDocumentoRelacionado
    Private _origenErogacion As String = String.Empty
    Private _folioFiscalVinculado As String = String.Empty
    Private _rfcProveedor As String = String.Empty
    Private _montoTotalIVA As Decimal = 0
    Private _montoRetencionISR As Decimal = 0
    Private _montoRetencionIVA As Decimal = 0
    Private _montoRetencionOtrosImpuestos As Decimal = 0
    Private _numeroPedimentoVinculado As String = String.Empty
    Private _clavePedimentoVinculado As String = String.Empty
    Private _clavePagoPedimentoVinculado As String = String.Empty
    Private _montoIVAPedimento As Decimal = 0
    Private _otrosImpuestosPagadosPedimento As Decimal = 0
    Private _fechaFolioFiscalVinculado As String = String.Empty
    Private _mes As String = String.Empty
    Private _montoTotalErogaciones As Decimal = 0

    Public Property OrigenErogacion As String
        Get
            Return _origenErogacion
        End Get
        Set(value As String)
            _origenErogacion = value
        End Set
    End Property
    Public Property FolioFiscalVinculado As String
        Get
            Return _folioFiscalVinculado
        End Get
        Set(value As String)
            _folioFiscalVinculado = value
        End Set
    End Property
    Public Property RFCProveedor As String
        Get
            Return _rfcProveedor
        End Get
        Set(value As String)
            _rfcProveedor = value
        End Set
    End Property
    Public Property MontoTotalIVA As Decimal
        Get
            Return _montoTotalIVA
        End Get
        Set(value As Decimal)
            _montoTotalIVA = value
        End Set
    End Property
    Public Property MontoRetencionISR As Decimal
        Get
            Return _montoRetencionISR
        End Get
        Set(value As Decimal)
            _montoRetencionISR = value
        End Set
    End Property
    Public Property MontoRetencionIVA As Decimal
        Get
            Return _montoTotalIVA
        End Get
        Set(value As Decimal)
            _montoTotalIVA = value
        End Set
    End Property
    Public Property MontoRetencionOtrosImpuestos As Decimal
        Get
            Return _montoRetencionOtrosImpuestos
        End Get
        Set(value As Decimal)
            _montoRetencionOtrosImpuestos = value
        End Set
    End Property
    Public Property NumeroPedimentoVinculado As String
        Get
            Return _numeroPedimentoVinculado
        End Get
        Set(value As String)
            _numeroPedimentoVinculado = value
        End Set
    End Property
    Public Property ClavePedimentoVinculado As String
        Get
            Return _clavePedimentoVinculado
        End Get
        Set(value As String)
            _clavePedimentoVinculado = value
        End Set
    End Property
    Public Property ClavePagoPedimentoVinculado As String
        Get
            Return _clavePagoPedimentoVinculado
        End Get
        Set(value As String)
            _clavePagoPedimentoVinculado = value
        End Set
    End Property

    Public Property MontoIVAPedimento As Decimal
        Get
            Return _montoIVAPedimento
        End Get
        Set(value As Decimal)
            _montoIVAPedimento = value
        End Set
    End Property
    Public Property OtrosImpuestosPagadosPedimento As Decimal
        Get
            Return _otrosImpuestosPagadosPedimento
        End Get
        Set(value As Decimal)
            _otrosImpuestosPagadosPedimento = value
        End Set
    End Property
    Public Property FechaFolioFiscalVinculado As String
        Get
            Return _fechaFolioFiscalVinculado
        End Get
        Set(value As String)
            _fechaFolioFiscalVinculado = value
        End Set
    End Property
    Public Property Mes As String
        Get
            Return _mes
        End Get
        Set(value As String)
            _mes = value
        End Set
    End Property
    Public Property MontoTotalErogaciones As Decimal
        Get
            Return _montoTotalErogaciones
        End Get
        Set(value As Decimal)
            _montoTotalErogaciones = value
        End Set
    End Property
End Class
Public Class Actividades
    Private _actividadRelacionada As String = String.Empty
    Private _subActividades As List(Of SubActividades) = New List(Of SubActividades)()

    Public Property ActividadRelacionada As String
        Get
            Return _actividadRelacionada
        End Get
        Set(value As String)
            _actividadRelacionada = value
        End Set
    End Property
    Public Property SubActividades As List(Of SubActividades)
        Get
            Return _subActividades
        End Get
        Set(value As List(Of SubActividades))
            _subActividades = value
        End Set
    End Property
End Class
Public Class SubActividades
    Private _subActividadRelacionada As String = String.Empty
    Private _tareas As List(Of Tareas) = New List(Of Tareas)
    Public Property SubActividadRelacionada As String
        Get
            Return _subActividadRelacionada
        End Get
        Set(value As String)
            _subActividadRelacionada = value
        End Set
    End Property
    Public Property Tareas As List(Of Tareas)
        Get
            Return _tareas
        End Get
        Set(value As List(Of Tareas))
            _tareas = value
        End Set
    End Property
End Class
Public Class Tareas
    Private _tareaRelacionada As String
    Public Property TareaRelacionada As String
        Get
            Return _tareaRelacionada
        End Get
        Set(value As String)
            _tareaRelacionada = value
        End Set
    End Property
End Class
Public Class CentroCostos
    Private _campo As String = String.Empty
    Private _yacimientos As List(Of Yacimientos) = New List(Of Yacimientos)

    Public Property Campo As String
        Get
            Return _campo
        End Get
        Set(value As String)
            _campo = value
        End Set
    End Property
    Public Property Yacimientos As List(Of Yacimientos)
        Get
            Return _yacimientos
        End Get
        Set(value As List(Of Yacimientos))
            _yacimientos = value
        End Set
    End Property
End Class
Public Class Yacimientos
    Private _yacimiento As String = String.Empty
    Private _pozos As List(Of Pozos) = New List(Of Pozos)()
    Public Property Yacimiento As String
        Get
            Return _yacimiento
        End Get
        Set(value As String)
            _yacimiento = value
        End Set
    End Property
    Public Property Pozos As List(Of Pozos)
        Get
            Return _pozos
        End Get
        Set(value As List(Of Pozos))
            _pozos = value
        End Set
    End Property
End Class
Public Class Pozos
    Private _pozo As String
    Public Property Pozo As String
        Get
            Return _pozo
        End Get
        Set(value As String)
            _pozo = value
        End Set
    End Property
End Class
#End Region
#Region "Impuestos Locales"
Public Class ImpuestosLocales
    Private _version As String = "1.0"
    Private _totaldeRetenciones As Decimal
    Private _totalTraslados As Decimal
    Private _retencionesLocales As List(Of RetencionesLocales)
    Private _trasladosLocales As List(Of TrasladosLocales)

    Public Property Version As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property TotaldeRetenciones As Decimal
        Get
            Return _totaldeRetenciones
        End Get
        Set(ByVal value As Decimal)
            _totaldeRetenciones = value
        End Set
    End Property

    Public Property TotalTraslasdos As Decimal
        Get
            Return _totalTraslados
        End Get
        Set(ByVal value As Decimal)
            _totalTraslados = value
        End Set
    End Property

    Public Property RetencionesLocales As List(Of RetencionesLocales)
        Get
            Return _retencionesLocales
        End Get
        Set(ByVal value As List(Of RetencionesLocales))
            _retencionesLocales = value
        End Set
    End Property

    Public Property TrasladosLocales As List(Of TrasladosLocales)
        Get
            Return _trasladosLocales
        End Get
        Set(ByVal value As List(Of TrasladosLocales))
            _trasladosLocales = value
        End Set
    End Property
End Class

Public Class RetencionesLocales
    Private _impLocRetenido As String = String.Empty
    Private _tasadeRetencion As Decimal = 0
    Private _importe As Decimal = 0

    Public Property ImpLocRetenido As String
        Get
            Return _impLocRetenido
        End Get
        Set(ByVal value As String)
            _impLocRetenido = value
        End Set
    End Property

    Public Property TasadeRetencion As Decimal
        Get
            Return _tasadeRetencion
        End Get
        Set(ByVal value As Decimal)
            _tasadeRetencion = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class

Public Class TrasladosLocales
    Private _impLocTraslados As String = String.Empty
    Private _tasadeTraslados As Decimal = 0
    Private _importe As Decimal = 0

    Public Property ImpLocTraslado As String
        Get
            Return _impLocTraslados
        End Get
        Set(ByVal value As String)
            _impLocTraslados = value
        End Set
    End Property

    Public Property TasaTraslado As Decimal
        Get
            Return _tasadeTraslados
        End Get
        Set(ByVal value As Decimal)
            _tasadeTraslados = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property
End Class
#End Region
#Region "Adenda"
Public Class Addenda
    Private _direccion As String
    Private _codigoPostal As String

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property
    Public Property CodigoPostal As String
        Get
            Return _codigoPostal
        End Get
        Set(ByVal value As String)
            _codigoPostal = value
        End Set
    End Property
End Class
#End Region
#End Region
#Region "Clase AcuseCancelacion"
Public Class Folios
    Private _UUID As String = String.Empty
    Private _estatusUUID As String = String.Empty

    Public Property UUID As String
        Get
            Return _UUID
        End Get
        Set(ByVal value As String)
            _UUID = value
        End Set
    End Property

    Public Property EstatusUUID As String
        Get
            Return _estatusUUID
        End Get
        Set(ByVal value As String)
            _estatusUUID = value
        End Set
    End Property
End Class
Public Class Acuse
    Private _fecha As DateTime
    Private _rfcEmisor As String = String.Empty
    Private _selloDigitalSAT As String = String.Empty
    Private _folios As Folios = New Folios()

    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property

    Public Property RfcEmisor As String
        Get
            Return _rfcEmisor
        End Get
        Set(ByVal value As String)
            _rfcEmisor = value
        End Set
    End Property

    Public Property SelloDigitalSAT As String
        Get
            Return _selloDigitalSAT
        End Get
        Set(ByVal value As String)
            _selloDigitalSAT = value
        End Set
    End Property

    Public Property Folios As Folios
        Get
            Return _folios
        End Get
        Set(ByVal value As Folios)
            _folios = value
        End Set
    End Property
End Class
#End Region
#Region "Otras clases"
Public Structure CError
    Private _error As String
    Private _hayError As Boolean

    Public Property [Error] As String
        Get
            Return _error
        End Get

        Set(ByVal value As String)
            _error = value
        End Set
    End Property

    Public Property HayError As Boolean
        Get
            Return _hayError
        End Get

        Set(ByVal value As Boolean)
            _hayError = value
        End Set
    End Property
End Structure
Public Class XmlValidationErrorBuilder
    Private _errors As New List(Of ValidationEventArgs)()

    Public Sub ValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
        If args.Severity = XmlSeverityType.Error Then
            _errors.Add(args)
        End If
    End Sub

    Public Function GetErrors() As String
        If _errors.Count <> 0 Then
            Dim builder As New StringBuilder()
            builder.Append("The following ")
            builder.Append(_errors.Count.ToString())
            builder.AppendLine(" error(s) were found while validating the XML document against the XSD:")
            For Each i As ValidationEventArgs In _errors
                builder.Append("* ")
                builder.AppendLine(i.Message)
            Next
            Return builder.ToString()
        Else
            Return Nothing
        End If
    End Function
End Class
Public Class validarXML
    Public Shared Function LoadValidatedXDocument(xmlFilePath As String, xsdFilePath As String) As XDocument
        Dim doc As XDocument = XDocument.Load(xmlFilePath)
        Dim schemas As New XmlSchemaSet()
        schemas.Add(Nothing, xsdFilePath)
        Dim errorBuilder As New XmlValidationErrorBuilder()
        doc.Validate(schemas, New ValidationEventHandler(AddressOf errorBuilder.ValidationEventHandler))
        Dim errorsText As String = errorBuilder.GetErrors()
        If errorsText IsNot Nothing Then
            MessageBox.Show(errorsText)
        End If
        Return doc
    End Function
End Class
Public Enum Modo
    Nuevo
    Edicion
End Enum
Public Class Cliente
    Private _idCliente As Object
    Private _rfc As String
    Private _razonSocial As String
    Private _calle As String
    Private _numeroInterior As String
    Private _numeroExterior As String
    Private _colonia As String
    Private _localidad As String
    Private _referencia As String
    Private _cp As String
    Private _municipio As String
    Private _estado As String
    Private _pais As String
    Private _idUsoCFDI As String
    Public Property IdCliente As Object
        Get
            Return _idCliente
        End Get

        Set(ByVal value As Object)
            _idCliente = value
        End Set
    End Property
    Public Property RFC As String
        Get
            Return _rfc
        End Get

        Set(ByVal value As String)
            _rfc = value
        End Set
    End Property
    Public Property RazonSocial As String
        Get
            Return _razonSocial
        End Get

        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property
    Public Property Calle As String
        Get
            Return _calle
        End Get

        Set(ByVal value As String)
            _calle = value
        End Set
    End Property
    Public Property NumeroInterior As String
        Get
            Return _numeroInterior
        End Get

        Set(ByVal value As String)
            _numeroInterior = value
        End Set
    End Property
    Public Property NumeroExterior As String
        Get
            Return _numeroExterior
        End Get

        Set(ByVal value As String)
            _numeroExterior = value
        End Set
    End Property
    Public Property Colonia As String
        Get
            Return _colonia
        End Get

        Set(ByVal value As String)
            _colonia = value
        End Set
    End Property
    Public Property Localidad As String
        Get
            Return _localidad
        End Get

        Set(ByVal value As String)
            _localidad = value
        End Set
    End Property
    Public Property Referencia As String
        Get
            Return _referencia
        End Get

        Set(ByVal value As String)
            _referencia = value
        End Set
    End Property
    Public Property CP As String
        Get
            Return _cp
        End Get

        Set(ByVal value As String)
            _cp = value
        End Set
    End Property
    Public Property Municipio As String
        Get
            Return _municipio
        End Get

        Set(ByVal value As String)
            _municipio = value
        End Set
    End Property
    Public Property Estado As String
        Get
            Return _estado
        End Get

        Set(ByVal value As String)
            _estado = value
        End Set
    End Property
    Public Property Pais As String
        Get
            Return _pais
        End Get

        Set(ByVal value As String)
            _pais = value
        End Set
    End Property
    Public Property IdUsoCFDI As String
        Get
            Return _idUsoCFDI
        End Get

        Set(ByVal value As String)
            _idUsoCFDI = value
        End Set
    End Property
    Public ReadOnly Property DireccionCompleta As String
        Get
            Dim datos As StringBuilder = New StringBuilder()
            If Calle <> String.Empty Then datos.Append(Calle & " ")
            If Colonia <> String.Empty Then datos.Append(Colonia)
            If Calle <> String.Empty OrElse Colonia <> String.Empty Then datos.Append(vbLf)
            If CP <> String.Empty Then datos.Append("CP " & CP)
            If Localidad <> String.Empty Then datos.Append(" " & Localidad)
            If Municipio <> String.Empty Then datos.Append(", " & Municipio)
            If Estado <> String.Empty Then datos.Append(", " & Estado)
            If Pais <> String.Empty Then datos.Append(", " & Pais)
            datos.Append(vbLf)
            Return datos.ToString()
        End Get
    End Property
End Class
Public Class Producto

    Private _idProducto As Object
    Private _codigo As String
    Private _descripcion As String
    Private _unidad As String
    Private _precio As Single
    Private _idUnidad As String
    Private _idClaveProdServ As String

    Public Property IdProducto As Object
        Get
            Return _idProducto
        End Get

        Set(ByVal value As Object)
            _idProducto = value
        End Set
    End Property

    Public Property Codigo As String
        Get
            Return _codigo
        End Get

        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Unidad As String
        Get
            Return _unidad
        End Get

        Set(ByVal value As String)
            _unidad = value
        End Set
    End Property

    Public Property Precio As Single
        Get
            Return Precio
        End Get

        Set(ByVal value As Single)
            _precio = value
        End Set
    End Property

    Public Property IdUnidad As String
        Get
            Return _idUnidad
        End Get

        Set(ByVal value As String)
            _idUnidad = value
        End Set
    End Property

    Public Property IdClaveProdServ As String
        Get
            Return _idClaveProdServ
        End Get

        Set(ByVal value As String)
            _idClaveProdServ = value
        End Set
    End Property
End Class
#End Region
#Region "Catalogos SAT"
Public Structure cExportacion
    Private _id As Integer
    Private _exportacion As String
    Private _descripcion As String

    Public Sub New(ByVal id As Integer, ByVal exportacion As String, ByVal descripcion As String)
        Me._id = id
        Me._exportacion = exportacion
        Me._descripcion = descripcion
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Exportacion As String
        Get
            Return _exportacion
        End Get
        Set(ByVal value As String)
            _exportacion = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _exportacion & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cTipoComprobante
    Private _tipoComprobante As String
    Private _descripcion As String
    Private _id As Integer
    Public Sub New(ByVal id As Integer, ByVal tipoComprobante As String, ByVal descripcion As String)
        Me._id = id
        Me._tipoComprobante = tipoComprobante
        Me._descripcion = descripcion
    End Sub
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property TipoComprobante As String
        Get
            Return _tipoComprobante
        End Get

        Set(ByVal value As String)
            _tipoComprobante = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return TipoComprobante & "-" & Descripcion
        End Get
    End Property
End Structure
Public Structure cObjetoImp
    Private _objetoImp As String
    Private _descripcion As String
    Private _id As Object

    Public Sub New(ByVal id As Object, ByVal regimenFiscal As String, ByVal descripcion As String)
        Me._id = id
        Me._objetoImp = regimenFiscal
        Me._descripcion = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get
        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property ObjetoImp As String
        Get
            Return _objetoImp
        End Get
        Set(ByVal value As String)
            _objetoImp = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _objetoImp & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cPais

    Public Sub New(ByVal clave As String, ByVal descripcion As String)
        Me.Clave = clave
        Me.Descripcion = descripcion
    End Sub

    Private _clave As String

    Private _descripcion As String

    Public Property Clave As String
        Get
            Return _clave
        End Get

        Set(ByVal value As String)
            _clave = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
End Structure
Public Structure cRegimenFiscal

    Private _regimenFiscal As String

    Private _descripcion As String

    Private _id As Object

    Public Sub New(ByVal id As Object, ByVal regimenFiscal As String, ByVal descripcion As String)
        Me.Id = id
        Me.RegimenFiscal = regimenFiscal
        Me.Descripcion = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get

        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property RegimenFiscal As String
        Get
            Return _regimenFiscal
        End Get

        Set(ByVal value As String)
            _regimenFiscal = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _regimenFiscal & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cUsoCFDI
    Private _id As Object
    Private _usoCfdi As String
    Private _descripcion As String


    Public Sub New(ByVal id As Object, ByVal usoCfdi As String, ByVal descripcion As String)
        _id = id
        _usoCfdi = usoCfdi
        _descripcion = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get

        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property UsoCFDI As String
        Get
            Return _usoCfdi
        End Get

        Set(ByVal value As String)
            _usoCfdi = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _usoCfdi & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cClaveUnidad

    Private _id As Object

    Private _claveUnidad As String

    Private _nombre As String

    Public Sub New(ByVal id As Object, ByVal claveUnidad As String, ByVal descripcion As String)
        Me.Id = id
        Me.ClaveUnidad = claveUnidad
        Me.Nombre = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get

        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property ClaveUnidad As String
        Get
            Return _claveUnidad
        End Get

        Set(ByVal value As String)
            _claveUnidad = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get

        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public Property ClaveYDescripcion As String
        Get
            Return _claveUnidad & "- " & _nombre
        End Get

        Set(ByVal value As String)
        End Set
    End Property
End Structure
Public Structure cClaveProdServ

    Private _id As Object

    Private _claveProdServ As String

    Private _descripcion As String

    Public Sub New(ByVal id As Object, ByVal claveProdServ As String, ByVal descripcion As String)
        Me.Id = id
        Me.ClaveProdServ = claveProdServ
        Me.Descripcion = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get

        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property ClaveProdServ As String
        Get
            Return _claveProdServ
        End Get

        Set(ByVal value As String)
            _claveProdServ = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Property ClaveYDescripcion As String
        Get
            Return _claveProdServ & "- " & _descripcion
        End Get

        Set(ByVal value As String)
        End Set
    End Property
End Structure
Public Structure cFormaPago

    Private _id As Object

    Private _formaPago As String

    Private _descripcion As String

    Public Sub New(ByVal id As Integer, ByVal formaPago As String, ByVal descripcion As String)
        Me.Id = id
        Me.FormaPago = formaPago
        Me.Descripcion = descripcion
    End Sub

    Public Property Id As Object
        Get
            Return _id
        End Get

        Set(ByVal value As Object)
            _id = value
        End Set
    End Property

    Public Property FormaPago As String
        Get
            Return _formaPago
        End Get

        Set(ByVal value As String)
            _formaPago = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _formaPago & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cMoneda

    Private _id As Integer

    Private _moneda As String

    Private _descripcion As String

    Public Sub New(ByVal id As Integer, ByVal moneda As String, ByVal descripcion As String)
        Me.Id = id
        Me.Moneda = moneda
        Me.Descripcion = descripcion
    End Sub

    Public Property Id As Integer
        Get
            Return _id
        End Get

        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Moneda As String
        Get
            Return _moneda
        End Get

        Set(ByVal value As String)
            _moneda = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _moneda & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cMetodoPago
    Private _id As Integer
    Private _metodoPago As String
    Private _descripcion As String

    Public Sub New(ByVal id As Integer, ByVal metodoPago As String, ByVal descripcion As String)
        Me.Id = id
        Me.MetodoPago = metodoPago
        Me.Descripcion = descripcion
    End Sub
    Public Property Id As Integer
        Get
            Return _id
        End Get

        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property MetodoPago As String
        Get
            Return _metodoPago
        End Get

        Set(ByVal value As String)
            _metodoPago = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get

        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _metodoPago & "- " & _descripcion
        End Get
    End Property
End Structure

Public Structure cActividad
    Private _actividad As String
    Private _descripcion As String

    Public Sub New(ByVal actividad As String, ByVal descripcion As String)
        Me._actividad = actividad
        Me._descripcion = descripcion
    End Sub
    Public Property Actividad As String
        Get
            Return _actividad
        End Get
        Set(ByVal value As String)
            _actividad = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _actividad & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cSubactividad
    Private _actividad As String
    Private _subactividad As String
    Private _descripcion As String

    Public Sub New(ByVal actividad As String, ByVal subactividad As String, ByVal descripcion As String)
        Me._actividad = actividad
        Me._subactividad = subactividad
        Me._descripcion = descripcion
    End Sub
    Public Property Actividad As String
        Get
            Return _actividad
        End Get
        Set(ByVal value As String)
            _actividad = value
        End Set
    End Property
    Public Property Subactividad As String
        Get
            Return _subactividad
        End Get
        Set(ByVal value As String)
            _subactividad = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _subactividad & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cTarea
    Private _actividad As String
    Private _subactividad As String
    Private _tarea As String
    Private _descripcion As String

    Public Sub New(ByVal actividad As String, ByVal subactividad As String, ByVal tarea As String, ByVal descripcion As String)
        Me._actividad = actividad
        Me._subactividad = subactividad
        Me._tarea = tarea
        Me._descripcion = descripcion
    End Sub
    Public Property Actividad As String
        Get
            Return _actividad
        End Get
        Set(ByVal value As String)
            _actividad = value
        End Set
    End Property
    Public Property Subactividad As String
        Get
            Return _subactividad
        End Get
        Set(ByVal value As String)
            _subactividad = value
        End Set
    End Property
    Public Property Tarea As String
        Get
            Return _tarea
        End Get
        Set(ByVal value As String)
            _tarea = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _tarea & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cClavePedimento
    Private _clavePedimento As String
    Private _descripcion As String

    Public Sub New(ByVal clavePedimento As String, ByVal descripcion As String)
        Me._clavePedimento = clavePedimento
        Me._descripcion = descripcion
    End Sub
    Public Property ClavePedimento As String
        Get
            Return _clavePedimento
        End Get
        Set(ByVal value As String)
            _clavePedimento = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _clavePedimento & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cClavePagoPedimento
    Private _clavePagoPedimento As String
    Private _descripcion As String

    Public Sub New(ByVal clavePedimento As String, ByVal descripcion As String)
        Me._clavePagoPedimento = clavePedimento
        Me._descripcion = descripcion
    End Sub
    Public Property ClavePagoPedimento As String
        Get
            Return _clavePagoPedimento
        End Get
        Set(ByVal value As String)
            _clavePagoPedimento = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Public ReadOnly Property ClaveYDescripcion As String
        Get
            Return _clavePagoPedimento & "- " & _descripcion
        End Get
    End Property
End Structure
Public Structure cClaveTipoCombustible
    Private _claveTipoCombustible As String
    Private _tipoCombustible As String
    Public Property ClaveTipoCombustible As String
        Get
            Return _claveTipoCombustible
        End Get
        Set(value As String)
            _claveTipoCombustible = value
        End Set
    End Property
    Public Property TipoCombustible As String
        Get
            Return _tipoCombustible
        End Get
        Set(value As String)
            _tipoCombustible = value
        End Set
    End Property
End Structure

#End Region



