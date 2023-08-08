Imports SGT_Transport.CartaPorte20

Public Class frmCartaPorte20

    Public _cartaPorte As CartaPorte
    Private Sub frmCartaPorte20_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Me.WindowState = FormWindowState.Minimized
            Me.CenterToScreen()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (_cartaPorte Is Nothing) Then
            _cartaPorte = New CartaPorte
        End If
        _cartaPorte.Version = "2.0"
        _cartaPorte.TotalDistRec = 1319.2D
        _cartaPorte.TranspInternac = "No"
        Dim ubicaciones As Ubicaciones = New Ubicaciones()
        Dim ubicacionOrigen As Ubicacion = New Ubicacion()
        ubicacionOrigen.TipoUbicacion = "Origen"
        ubicacionOrigen.IDUbicacion = "OR458563"
        ubicacionOrigen.RFCRemitenteDestinatario = Principal.LTFACTURA.Text
        ubicacionOrigen.NombreRemitenteDestinatario = Principal.LtRazonSocialEmisor.Text

        ubicacionOrigen.FechaHoraSalidaLlegada = DateTime.Now
        Dim domicilioOrigen As Domicilio = New Domicilio()
        domicilioOrigen.Calle = "Oriente 21"
        domicilioOrigen.NumeroExterior = "368"
        domicilioOrigen.NumeroInterior = ""
        domicilioOrigen.Colonia = "2621"
        domicilioOrigen.Localidad = "03"
        domicilioOrigen.CodigoPostal = "03103"
        domicilioOrigen.Estado = "DIF"
        domicilioOrigen.Municipio = "014"
        domicilioOrigen.Pais = "MEX"
        ubicacionOrigen.Domicilio = domicilioOrigen

        Dim ubicacionDestino As Ubicacion = New Ubicacion()

        ubicacionDestino.TipoUbicacion = "Destino"
        ubicacionDestino.IDUbicacion = "DE458563"
        ubicacionDestino.RFCRemitenteDestinatario = Principal.LtRFCReceptor.Text
        ubicacionDestino.NombreRemitenteDestinatario = "CRISTIAN CEREZO GUZMAN"
        ubicacionDestino.FechaHoraSalidaLlegada = DateTime.Now
        ubicacionDestino.DistanciaRecorrida = 1319.2D
        Dim domicilioDestino As Domicilio = New Domicilio()
        domicilioDestino.Calle = "Allende"
        domicilioDestino.NumeroExterior = "128"
        domicilioDestino.NumeroInterior = "33"
        domicilioDestino.Colonia = "0001"
        domicilioDestino.Localidad = "01"
        domicilioDestino.CodigoPostal = "24000"
        domicilioDestino.Estado = "CAM"
        domicilioDestino.Municipio = "002"
        domicilioDestino.Pais = "MEX"
        ubicacionDestino.Domicilio = domicilioDestino
        ubicaciones.Ubicacion.Add(ubicacionOrigen)
        ubicaciones.Ubicacion.Add(ubicacionDestino)
        _cartaPorte.Ubicaciones = ubicaciones
        Dim mercancias As Mercancias = New Mercancias()
        mercancias.NumTotalMercancias = 2
        mercancias.PesoBrutoTotal = 715
        mercancias.UnidadPeso = "X1A"

        Dim mercancia1 As Mercancia = New Mercancia()


        mercancia1.BienesTransp = "10101501"

        mercancia1.Descripcion = "Servicio de flete"

        mercancia1.Cantidad = 10
        mercancia1.ClaveUnidad = "H87"
        mercancia1.Unidad = "Pieza"
        mercancia1.Dimensiones = "59/40/36plg"
        mercancia1.PesoEnKg = 15D
        mercancia1.Moneda = "MXN"
        mercancia1.ValorMercancia = 150000

        'Dim mercancia2 As Mercancia = New Mercancia()
        'mercancia2.BienesTransp = "10101501"
        'mercancia2.Descripcion = "Maquinas lavadoras de lavandería"
        'mercancia2.Cantidad = 10
        'mercancia2.ClaveUnidad = "H87"
        'mercancia2.Unidad = "Pieza"
        'mercancia2.Dimensiones = "59/40/36plg"
        'mercancia2.PesoEnKg = 700D
        'mercancia2.Moneda = "MXN"
        'mercancia2.ValorMercancia = 150000

        Dim cantidadTransporta As CantidadTransporta = New CantidadTransporta()
        cantidadTransporta.Cantidad = 8
        cantidadTransporta.IDOrigen = "OR458563"
        cantidadTransporta.IDDestino = "DE458563"

        'mercancia2.CantidadTransporta.Add(cantidadTransporta)
        mercancias.Mercancia.Add(mercancia1)
        'mercancias.Mercancia.Add(mercancia2)
        Dim autotransporte As Autotransporte = New Autotransporte()
        autotransporte.PermSCT = "TPAF01"
        autotransporte.NumPermisoSCT = "ABCDEFG4525648ABCDEFG4525648"
        Dim identificacionVehicular As IdentificacionVehicular = New IdentificacionVehicular()
        identificacionVehicular.ConfigVehicular = "OTROEVGP"
        identificacionVehicular.PlacaVM = "IRKFOAZ"
        identificacionVehicular.AnioModeloVM = 2020
        Dim seguros As Seguros = New Seguros()
        seguros.AseguraRespCivil = "Seguros Afirme"
        seguros.PolizaRespCivil = "NUMPOLIZASEGURO"
        seguros.AseguraCarga = "Seguros Afirme"
        seguros.PolizaCarga = "NUMPOLIZASEGURO"
        seguros.PrimaSeguro = 1200
        Dim remolques As Remolques = New Remolques()
        Dim remolque1 As Remolque = New Remolque()
        remolque1.SubTipoRem = "CTR006"
        remolque1.Placa = "TIG4568"
        Dim remolque2 As Remolque = New Remolque()
        remolque2.SubTipoRem = "CTR004"
        remolque2.Placa = "ABC1234"
        remolques.Remolque.Add(remolque1)
        remolques.Remolque.Add(remolque2)
        autotransporte.IdentificacionVehicular = identificacionVehicular
        autotransporte.Seguros = seguros
        autotransporte.Remolques = remolques
        mercancias.Autotransporte = autotransporte
        _cartaPorte.Mercancias = mercancias
        Dim figuraTransporte As FiguraTransporte = New FiguraTransporte()
        Dim tiposFigura As TiposFigura = New TiposFigura()

        tiposFigura.TipoFigura = "01"
        tiposFigura.RFCFigura = "SAMC610616GHA"
        tiposFigura.NumLicencia = "6565165161"
        tiposFigura.NombreFigura = "Daniel Lopez Lopez"


        Dim DomicilioTipoFigura As Domicilio = New Domicilio()
        DomicilioTipoFigura.CodigoPostal = "94327"
        DomicilioTipoFigura.Pais = "MEX"
        DomicilioTipoFigura.Estado = "VER"

        tiposFigura.Domicilio = DomicilioTipoFigura

        figuraTransporte.TiposFigura.Add(tiposFigura)

        _cartaPorte.FiguraTransporte = figuraTransporte
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub richTextBox1_TextChanged(sender As Object, e As EventArgs) Handles richTextBox1.TextChanged

    End Sub
End Class