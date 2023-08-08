Imports FirebirdSql.Data.FirebirdClient

Public Enum EnmTipoDocumento
    SinAsignar = 0
    FacturaVentas = 1
    Viaje = 2
    Liquidacion = 3
End Enum

Public Enum EnmTipoDocumentoPoliza
    SinAsignar = 0
    VentasFletes = 1
    VentaOtros = 2
    Liquidacion = 3
End Enum
Public Class Poliza
    Public TipoPoliza As String
    Public NumPoliza As String
    Public Periodo As Integer
    Public Ejercicio As Integer
    Public FechaPoliza As DateTime
    Public ConceptoPoliza As String
    Public NumPartida As Integer
    Public LogAudita As String
    Public Contabiliza As String
    Public NumParCua As Integer
    Public TieneDocumentos As Integer
    Public PROCCONTAB As Long
    Public Origen As String
    Public UUID As String
    Public EsPolizaPrivada As Long
    Public UUIDOP As String

    Public TipoDocumentoPoliza As EnmTipoDocumentoPoliza
    Public RegistroPoliza As RegPol
    Public Auxiliares As List(Of Auxiliar)
    Public Documentos As List(Of Documento)

    Public Sub New()
        RegistroPoliza = New RegPol()
        Auxiliares = New List(Of Auxiliar)
        Documentos = New List(Of Documento)
    End Sub

End Class

Public Class Auxiliar
    Public TipoPoliza As String
    Public NumPoliza As String
    Public NumPartida As Double
    Public Periodo As Integer
    Public Ejercicio As Integer
    Public NumCuenta As String
    Public NumCuentaCOI As String
    Public FechaPoliza As DateTime
    Public ConceptoPoliza As String
    Public DebeHaber As String
    Public MontoMovimiento As Double
    Public NumDepartamento As Integer
    Public TipoCambio As Double
    Public ContraPartida As Integer
    Public Orden As Long
    Public CCostos As Long
    Public CGupos As Long
    Public IDINFADIPAR As Long
    Public UUID As New UuidTimbres
End Class

Public Class RegPol
    Public Transaccion As Long
    Public TipoPoliza As String
    Public NumPoliza As String
    Public FechaPoliza As DateTime
    Public FechaOPR As DateTime
    Public Sistema As String
    Public NumUsr As Long
    Public Operacion As Long
    Public Status As Integer
    Public TipoPolizaNTR As String
    Public PolizaModelo As String
    Public REGCONCLI As Long
    Public StatusCli As String
End Class

Public Class UuidTimbres
    Public NumReg As Long = -1
    Public UUID As String
    Public Monto As Double
    Public Serie As String
    Public Folio As String
    Public RfcEmisor As String
    Public RfcReceptor As String
    Public Orden As Integer
    Public Fecha As DateTime
    Public TipoComprobante As Integer
    Public TipoCambio As Double
    Public VersionCFDI As String
    Public Moneda As String
End Class

Public Class CuentaContable
    Public Ejercicio As Integer
    Public NumCuenta As String
    Public NumCuentaAsignada As String
    Public Coincidencias As Integer

    Public Sub New()
    End Sub

    Public Sub New(Anio As Integer, Cuenta As String)
        Ejercicio = Anio
        NumCuenta = Cuenta
    End Sub
End Class

Public Class Documento
    Public TipoDocumento As EnmTipoDocumento
    Public ClaveDocumento As String

    Public Sub New()
    End Sub

    Public Sub New(Tipo As EnmTipoDocumento, Clave As String)
        TipoDocumento = Tipo
        ClaveDocumento = Clave
    End Sub
End Class

