Imports System.Text
Imports System.Threading.Tasks

Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Imports System.Xml
Imports System.Globalization

Public NotInheritable Class CreaPDF

    Private Shared FUENTE_TITULO As Font = New Font(FontFactory.GetFont("ArialMT", 10, Font.BOLD, BaseColor.BLACK))
    Private Shared FUENTE_TITULO1 As Font = New Font(FontFactory.GetFont("ArialMT", 7, Font.BOLD, BaseColor.BLACK))
    Private Shared FUENTE_NORMAL As Font = New Font(FontFactory.GetFont("ArialMT", 7, Font.NORMAL, BaseColor.BLACK))
    Private Shared FUENTE_SUBTITULO As Font = New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)
    Private Shared FUENTE_SUBTITULO_BLANCO As Font = New Font(FontFactory.GetFont("ArialMT", 7, Font.BOLD, BaseColor.WHITE))
    Private Shared FUENTE_NORMAL_BOLD As Font = New Font(Font.FontFamily.HELVETICA, 6, Font.BOLD)
    Private Shared FUENTE_MEDIANA As Font = New Font(Font.FontFamily.HELVETICA, 8)


    'Private _documento As Document
    ''Objeto para escribir el pdf
    'Private _fuenteTitulos As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
    'Private _fuenteContenido As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.NOT_EMBEDDED)
    'Private _writer As PdfWriter
    'Private _cb As PdfContentByte
    'Private _comprobante As Comprobante
    ''Objeto que contendra la información del documento pdf
    'Private xDoc As XmlDocument
    '' Objeto para abrir el archivo xml
    'Private _fTitulo As Font
    'Private _fSubtitulo As Font
    'Private _FNormal As Font
    'Private _FNormalBold As Font
    'Private _fMediana As Font

    Private Shared Sub AgregaPropiedadesDocumento(ByRef documento As Document)
        documento.AddAuthor("Grupo Cerezo S.A de C.V")
        documento.AddCreator("Grupo Cerezo ")
        documento.AddKeywords("Reporte de Grupo Cerezo ")
        documento.AddSubject("Document Carta porte")
        documento.AddTitle("CFDI sistema TransportCG")
        documento.SetMargins(cmAFloat(0.5F), cmAFloat(0.5F), cmAFloat(0.2F), cmAFloat(0.3F))
    End Sub

    Public Shared Function Generar(ByVal comprobante As Comprobante, ByVal rutaPDF As String, ByVal rutaLogo As String, ByVal abrir As Boolean) As Boolean

        Dim documento As Document = New Document(PageSize.LETTER)
        Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(rutaPDF, FileMode.Create))
        writer.PageEvent = New ITextEvents()
        documento.Open()
        AgregaPropiedadesDocumento(documento)
        SeleccionarFormato(comprobante, documento, rutaLogo)
        documento.Close()
        If abrir Then System.Diagnostics.Process.Start(rutaPDF)
        Return True
    End Function

    Public Shared Function Generar(ByVal rutaXML As String, ByVal rutaPDF As String, ByVal rutaLogo As String, ByVal abrir As Boolean) As Boolean

        Dim leer As New LeerXML
        Dim comprobante As Comprobante = leer.ObtenerComprobante(rutaXML)
        'Dim documento As Document = New Document(PageSize.LETTER)
        Dim documento As Document = New Document(PageSize.LETTER, CmAFloat(0.5F), CmAFloat(0.5F), CmAFloat(0.2F), CmAFloat(1.5F))
        Dim writer As PdfWriter = PdfWriter.GetInstance(documento, New FileStream(rutaPDF, FileMode.Create))
        writer.PageEvent = New ITextEvents()
        documento.Open()
        AgregaPropiedadesDocumento(documento)
        SeleccionarFormato(comprobante, documento, rutaLogo)
        documento.Close()
        If abrir Then System.Diagnostics.Process.Start(rutaPDF)
        Return True
    End Function

    'Public Sub New(rutaXML As String, rutaPDF As String, logo As System.Drawing.Image)
    '    'CreateRootAndChildren();

    '    _fTitulo = New Font(Font.FontFamily.HELVETICA, 10, Font.BOLD)
    '    _fSubtitulo = New Font(Font.FontFamily.HELVETICA, 9, Font.BOLD)
    '    _FNormal = New Font(Font.FontFamily.HELVETICA, 8)
    '    _FNormalBold = New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)
    '    _fMediana = New Font(Font.FontFamily.HELVETICA, 7)

    '    LeerArtributosXML(rutaXML)

    '    'Trabajos con el documento XML
    '    _documento = New Document(PageSize.LETTER)
    '    'string nombreDocumento = Path.GetTempFileName() + ".pdf";
    '    Dim nombreDocumento As String = rutaPDF

    '    'Creamos el documetno
    '    _writer = PdfWriter.GetInstance(_documento, New FileStream(nombreDocumento, FileMode.Create))
    '    _writer.PageEvent = New ITextEvents()

    '    'Agregamos propiedades al documento
    '    AgregaPropiedadesDocumento()

    '    'Abrimos el documento
    '    _documento.Open()

    '    If ObtenerTipoComprobante() = "N" Then
    '        NAgregarTitulo()
    '        NAgregarTabla(logo)
    '        NAgregarPercepcionesDeducciones()
    '        NAgregarMensaje()
    '        NAgregarDatosFiscales()
    '    Else


    '        AgregarLogo(logo)
    '        AgregarCuadro()
    '        AgregarDatosEmisorReceptor()
    '        AgregarDatosFactura()
    '        AgregarCfdiRelacionados()
    '        'AgregarDatosReceptorEmisor();
    '        AgregarPagos10()
    '        AgregarDatosProductos1()
    '        AgregarTotales()
    '        AgregarSellos()
    '    End If
    '    'Cerramoe el documento
    '    _documento.Close()

    '    'Abrimos el archivo .pdf
    '    System.Diagnostics.Process.Start(nombreDocumento)
    'End Sub

    Private Shared Sub SeleccionarFormato(ByVal comprobante As Comprobante, ByVal documento As Document, ByVal rutaLogo As String)
        If comprobante.TipoDeComprobante = "N" Then
            FormatoNomina2(documento, comprobante, rutaLogo)
        ElseIf comprobante.TipoDeComprobante = "P" Then
            FormatoPagos(documento, comprobante, rutaLogo)
        ElseIf comprobante.AcuseCancelacion IsNot Nothing Then
            FormatoAcuseCancelacion(documento, comprobante)
        ElseIf comprobante.Complemento IsNot Nothing AndAlso comprobante.Complemento.CartaPorte20 IsNot Nothing Then
            FormatoCartaPorte20(documento, comprobante, rutaLogo)
        ElseIf comprobante.Complemento IsNot Nothing AndAlso comprobante.Complemento.ComercioExterior IsNot Nothing Then
            FormatoComercioExterior(documento, comprobante, rutaLogo)
        Else
            FormatoNormal(documento, comprobante, rutaLogo)
        End If
    End Sub

    Private Shared Sub FormatoNormal(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        If comprobante.CfdiRelacionados IsNot Nothing Then documento.Add(AgregarCfdisRelacionados(comprobante.CfdiRelacionados))
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub
    Private Shared Sub FormatoComercioExterior(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        If comprobante.CfdiRelacionados IsNot Nothing Then documento.Add(AgregarCfdisRelacionados(comprobante.CfdiRelacionados))
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub

    Private Shared Sub FormatoCartaPorte20(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))

        If comprobante.CfdiRelacionados IsNot Nothing Then
            documento.Add(AgregarCfdisRelacionados(comprobante.CfdiRelacionados))
        End If

        documento.Add(AgregarConceptosCartaPorte(comprobante))

        If CP_IMPRIME_IMPORTES Then
            documento.Add(AgregarTotales(comprobante))
        End If
        If CP_OBSER_CFDI.Trim.Length > 0 Then
            'OBSERVACIONES
            AgregarObservaciones(documento, "Observaciones", CP_OBSER_CFDI)

            'FIN OBSERVACIONES
        End If
        AgregarDatosCartaPorte(documento, comprobante)
        AgregarUbicaciones(documento, comprobante)
        AgregarMercancias(documento, comprobante)
        If comprobante.Complemento.CartaPorte20.FiguraTransporte IsNot Nothing Then AgregarFiguraTransporte(documento, comprobante)
        CP_AgregarTransporte(documento, comprobante)

        documento.Add(AgregarSellos(comprobante))
        'documento.Add(AgregarSellos(comprobante))
        CARTA_PORTE_ANEXO = "CONDICIONES DE PRESTACIÓN DE SERVICIOS QUE AMPARA EL COMPLEMENTO CARTA PORTE.
PRIMERA.- Para los efectos del presente contrato de transporte se denomina ""Transportista"" al que realiza el servicio de transportación y ""Expedidor"", ""Remitente"" o ""Usuario"" al usuario que contrate el servicio o remite la mercancía.
SEGUNDA.- El ""Expedidor"", ""Remitente"" o ""Usuario"" es responsable de que la información proporcionada al ""Transportista"" sea veraz y que la documentación que entregue para efectos del transporte sea la correcta.
TERCERA.- El ""Expedidor"", ""Remitente"" o ""Usuario"" debe declarar al ""Transportista"" el tipo de mercancía o efectos de que se trate, peso, medidas y/o número de la carga que entrega para su transporte y, en su caso, el valor de la misma. La carga que se entregue a granel podrá ser aforada en metros cúbicos con la conformidad del ""Expedidor"", ""Remitente"" o ""Usuario"".
CUARTA.- Para efectos del transporte, el ""Expedidor"", ""Remitente"" o ""Usuario"" deberá entregar al ""Transportista"" los documentos que las leyes y reglamentos exijan para llevar a cabo el servicio, en caso de no cumplirse con estos requisitos el ""Transportista"" está obligado a rehusar el transporte de las mercancías.
QUINTA.- Si por sospecha de falsedad en la declaración del contenido de un bulto el ""Transportista"" deseare proceder a su reconocimiento, podrá hacerlo ante testigos y con asistencia del ""Expedidor"", ""Remitente"" o ""Usuario"" o del consignatario. Si este último no concurriere, se solicitará la presencia de un inspector de la Secretaría de Comunicaciones y Transportes, y se levantará el acta correspondiente. El ""Transportista"" tendrá en todo caso, la obligación de dejar los bultos en el estado en que se encontraban antes del reconocimiento.
SEXTA.- El ""Transportista"" deberá recoger y entregar la carga precisamente en los domicilios que señale el ""Expedidor"", ""Remitente"" o ""Usuario"", ajustándose a los términos y condiciones convenidos. El ""Transportista"" sólo está obligado a llevar la carga al domicilio del consignatario para su entrega una sola vez. Si ésta no fuera recibida, se dejará aviso de que la mercancía queda a disposición del interesado en las bodegas que indique el ""Transportista"".
SÉPTIMA.- Si la carga no fuere retirada dentro de los 30 días hábiles siguientes a aquél en que hubiere sido puesta a disposición del consignatario, el ""Transportista"" podrá solicitar la venta en subasta pública con arreglo a lo que dispone el Código de Comercio.
OCTAVA.- El ""Transportista"" y el ""Expedidor"", ""Remitente"" o ""Usuario"" negociarán libremente el precio del servicio, tomando en cuenta su tipo, característica de los embarques, volumen, regularidad, clase de carga y sistema de pago.
NOVENA.- Si el ""Expedidor"", ""Remitente"" o ""Usuario"" desea que el ""Transportista"" asuma la responsabilidad por el valor de las mercancías o efectos que él declare y que cubra toda clase de riesgos, inclusive los derivados de caso fortuito o de fuerza mayor, las partes deberán convenir un cargo adicional, equivalente al valor de la prima del seguro que se contrate, el cual se deberá expresar en un CFDI con Complemento Carta Porte.
DÉCIMA.- Cuando el importe del flete no incluya el cargo adicional, la responsabilidad del ""Transportista"" queda expresamente limitada a la cantidad equivalente a 15 Unidades de Medida y Actualización (UMAS) por tonelada o cuando se trate de embarques cuyo peso sea mayor de 200 kg., pero menor de 1000 kg; y 4 UMAS por remesa cuando se trate de embarques con peso hasta de 200 kg.
DÉCIMA PRIMERA.- El precio del transporte deberá pagarse en origen, salvo convenio entre las partes de pago en destino. Cuando el transporte se hubiere concertado ""Flete por Cobrar"", la entrega de las mercancías o efectos se hará contra el pago del flete y el ""Transportista"" tendrá derecho a retenerlos mientras no se le cubra el precio convenido.
DÉCIMA SEGUNDA.- Si al momento de la entrega resultare algún faltante o avería, el consignatario podrá formular su reclamación por escrito al ""Transportista"", dentro de las 24 horas siguientes.
 
DÉCIMA TERCERA.- El ""Transportista"" queda eximido de la obligación de recibir mercancías o efectos para su transporte, en los siguientes casos:
a) Cuando se trate de carga que por su naturaleza, peso, volumen, embalaje defectuoso o cualquier otra circunstancia no pueda transportarse sin destruirse o sin causar daño a los demás artículos o al material rodante, salvo que la empresa de que se trate tenga el equipo adecuado.
b) Las mercancías cuyo transporte haya sido prohibido por disposiciones legales o reglamentarias. Cuando tales disposiciones no prohíban precisamente el transporte de determinadas mercancías, pero sí ordenen la presentación de ciertos documentos para que puedan ser transportadas, el ""Expedidor"", ""Remitente"" o ""Usuario"" estará obligado a entregar al ""Transportista"" los documentos correspondientes.
DÉCIMA CUARTA.- Los casos no previstos en las presentes condiciones y las quejas derivadas de su aplicación se someterán por la vía administrativa a la Secretaría de Comunicaciones y Transportes.
DÉCIMA QUINTA.- Para el caso de que el ""Expedidor"", ""Remitente"" o ""Usuario"" contrate carro por entero, éste aceptará la responsabilidad solidaria para con el ""Transportista"" mediante la figura de la corresponsabilidad que contempla el artículo 10 del Reglamento Sobre el Peso, Dimensiones y Capacidad de los Vehículos de Autotransporte que Transitan en los Caminos y Puentes de Jurisdicción Federal, por lo que el ""Expedidor"", ""Remitente"" o ""Usuario"" queda obligado a verificar que la carga y el vehículo que la transporta, cumplan con el peso y dimensiones máximas establecidos en la NOM-012-SCT-2-2017, o la que la sustituya.
Para el caso de incumplimiento e inobservancia a las disposiciones que regulan el peso y dimensiones, por parte del ""Expedidor"", ""Remitente"" o ""Usuario"", éste será corresponsable de las infracciones y multas que la Secretaría de Infraestructura, Comunicaciones y Transportes o la Guardia Nacional impongan al ""Transportista"", por cargar las unidades con exceso de peso.
"
        AgregarObservaciones(documento, "ANEXO ÚNICO", CARTA_PORTE_ANEXO)

    End Sub
    Public Shared Sub AgregarObservaciones(ByVal document As Document, ByVal FLEYENDA As String, FOBSERVACIONES As String)

        Dim anchoColumnas As Single() = cmAFloat(New Single() {20.0F})
        'Dim tamanoColumnas As Single() = cmAFloat(New Single() {20.0F})
        Dim TObser As PdfPTable = New PdfPTable(anchoColumnas)

        TObser.SetTotalWidth(anchoColumnas)
        TObser.SpacingBefore = 5
        TObser.HorizontalAlignment = Element.ALIGN_CENTER
        TObser.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        TObser.DefaultCell.BorderWidth = 1
        TObser.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph(FLEYENDA, FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        TObser.AddCell(cEncabezado)

        'TObser.AddCell(New Phrase("Observaciones", FUENTE_SUBTITULO))
        TObser.AddCell(New Phrase(FOBSERVACIONES, FUENTE_MEDIANA))

        TObser.CompleteRow()
        document.Add(TObser)
    End Sub
    Private Shared Sub FormatoPagos(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        AgregarTablaPagos(documento, comprobante)
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub

    Private Shared Sub FormatoNomina2(ByVal documento As Document, ByVal comprobante As Comprobante, ByVal rutaLogo As String)
        documento.Add(AgregarEncabezado(comprobante, rutaLogo))
        N2AgregarEmisor(documento, comprobante)
        N2AgregarEmpleadoPagos(documento, comprobante)
        N2AgregarPercepciones(documento, comprobante.Complemento.Nomina.Percepciones)
        N2AgregarDeducciones(documento, comprobante.Complemento.Nomina.Deducciones)
        N2AgregarOtroPagos(documento, comprobante.Complemento.Nomina.OtrosPagos)
        documento.Add(AgregarDatosProductos(comprobante))
        documento.Add(AgregarTotales(comprobante))
        documento.Add(AgregarSellos(comprobante))
    End Sub

    Private Shared Sub FormatoAcuseCancelacion(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim FuenteTitulo As Font = New Font(FontFactory.GetFont("ArialMT", 12, Font.BOLD, BaseColor.BLACK))
        Dim FuenteNormal As Font = New Font(FontFactory.GetFont("ArialMT", 9, Font.NORMAL, BaseColor.BLACK))
        Dim FuenteNormalBold As Font = New Font(FontFactory.GetFont("ArialMT", 9, Font.BOLD, BaseColor.BLACK))
        documento.Add(New Paragraph("Acuse de Solicitud Cancelación de CFDI", FuenteTitulo) With {
            .Alignment = Rectangle.ALIGN_CENTER
        })
        Dim anchoColumnas As Single() = cmAFloat(New Single() {6.0F, 10.0F})
        Dim tablaDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tablaDatos.SpacingBefore = 30
        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaDatos.DefaultCell.PaddingBottom = 15
        tablaDatos.SetTotalWidth(anchoColumnas)
        tablaDatos.LockedWidth = True
        tablaDatos.HorizontalAlignment = Element.ALIGN_CENTER
        tablaDatos.AddCell(New Phrase("Fecha y hora de cancelación:", FuenteNormalBold))
        tablaDatos.AddCell(New Phrase(comprobante.AcuseCancelacion.Fecha.ToString("s"), FuenteNormal))
        tablaDatos.AddCell(New Phrase("Rfc Emisor:", FuenteNormalBold))
        tablaDatos.AddCell(New Phrase(comprobante.AcuseCancelacion.RfcEmisor, FuenteNormal))
        tablaDatos.AddCell(New Phrase("Sello digital SAT:", FuenteNormalBold))
        tablaDatos.AddCell(New Phrase(comprobante.AcuseCancelacion.SelloDigitalSAT, FuenteNormal))
        documento.Add(tablaDatos)
        anchoColumnas = cmAFloat(New Single() {8.0F, 8.0F})
        Dim tablaFolios As PdfPTable = New PdfPTable(anchoColumnas)
        tablaFolios.SpacingBefore = 5
        tablaFolios.SetTotalWidth(anchoColumnas)
        tablaFolios.LockedWidth = True
        tablaFolios.HorizontalAlignment = Element.ALIGN_CENTER
        tablaFolios.AddCell(New Phrase("Folio fiscal UUID:", FuenteNormal))
        tablaFolios.AddCell(New Phrase("Estado CFDI:", FuenteNormal))
        tablaFolios.AddCell(New PdfPCell(New Phrase(comprobante.AcuseCancelacion.Folios.UUID, FuenteNormalBold)) With {
            .PaddingTop = 10,
            .PaddingBottom = 10
        })
        tablaFolios.AddCell(New PdfPCell(New Phrase(comprobante.AcuseCancelacion.Folios.EstatusUUID & " - " + ObtenerEstatusUUID(comprobante.AcuseCancelacion.Folios.EstatusUUID), FuenteNormalBold)) With {
            .PaddingTop = 10,
            .PaddingBottom = 10
        })
        documento.Add(tablaFolios)
        documento.Add(New Phrase(comprobante.xml, FUENTE_NORMAL))
    End Sub
    Private Shared Function AgregarCfdisRelacionados(ByVal cfdisRelacionados As CfdiRelacionados) As IElement
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        FUENTE_NORMAL_BOLD.Size = 8
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {20.0F})
        Dim tablaCFDISRelacionados As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaCFDISRelacionados.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaCFDISRelacionados.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaCFDISRelacionados.DefaultCell.BorderColor = cBorde
        tablaCFDISRelacionados.SpacingBefore = 10
        tablaCFDISRelacionados.DefaultCell.BackgroundColor = BaseColor.BLACK
        tablaCFDISRelacionados.LockedWidth = True
        tablaCFDISRelacionados.SetTotalWidth(tamanoColumnas)
        Dim relacion As StringBuilder = New StringBuilder()
        relacion.Append("CFDI'S RELACIONADOS (")
        relacion.Append(cfdisRelacionados.TipoRelacion & "- ")
        relacion.Append(ObtenerTipoRelacion(cfdisRelacionados.TipoRelacion) & ")")
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase(relacion.ToString(), FUENTE_SUBTITULO_BLANCO)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.UseAscender = True
        ctitulo.BorderColor = cBorde
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        ctitulo.BorderWidth = 1.0F
        ctitulo.Colspan = 6
        tablaCFDISRelacionados.AddCell(ctitulo)

        For Each cfdiRelacionado As CfdiRelacionado In cfdisRelacionados.CfdiRelacionado
            tablaCFDISRelacionados.AddCell(New PdfPCell(New Phrase(cfdiRelacionado.UUID, FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })
        Next

        Return tablaCFDISRelacionados
    End Function

#Region "Formato normal"
    Private Shared Function AgregarLogo(ByVal rutaLogo As String) As PdfPCell
        Dim celda As PdfPCell

        If rutaLogo <> String.Empty Then
            Dim imagen As Image = Image.GetInstance(rutaLogo)
            imagen.ScaleToFit(110, 110)
            celda = New PdfPCell(imagen)
            celda.HorizontalAlignment = Rectangle.ALIGN_CENTER
            celda.Border = Rectangle.NO_BORDER
        Else
            celda = New PdfPCell(New Phrase())
            celda.Border = Rectangle.NO_BORDER
        End If

        Return celda
    End Function

    Private Shared Function AgregarEncabezado(ByVal comprobante As Comprobante, ByVal rutaLogo As String) As IElement
        Dim anchoColumnas As Single() = cmAFloat(New Single() {5, 8.5F, 6.5F})
        Dim tablaDatos As PdfPTable = New PdfPTable(anchoColumnas)

        Try
            tablaDatos.DefaultCell.UseBorderPadding = False
            tablaDatos.SetTotalWidth(anchoColumnas)
            tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
            tablaDatos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
            tablaDatos.LockedWidth = True

            If File.Exists(rutaLogo) Then
                tablaDatos.AddCell(AgregarLogo(rutaLogo))
            Else
                tablaDatos.AddCell(AgregarLogo(""))
            End If


            Dim prc As Paragraph = New Paragraph()
            prc.Alignment = Element.ALIGN_CENTER
            prc.Add(New Chunk(comprobante.Emisor.Nombre & vbLf, FUENTE_TITULO))
            prc.Add(New Chunk(comprobante.Emisor.Rfc & vbLf, FUENTE_MEDIANA))
            prc.Add(New Chunk("RÉGIMEN FISCAL: " & comprobante.Emisor.RegimenFiscal & " - " + ObtenerRegimenFiscal(comprobante.Emisor.RegimenFiscal) & vbLf & vbLf, FUENTE_NORMAL))

            prc.Add(New Chunk("Domicilio fiscal" & vbLf, FUENTE_TITULO))
            prc.Add(New Chunk(PassData6 & vbLf & vbLf, FUENTE_NORMAL))

            prc.Add(New Chunk("CLIENTE" & vbLf, FUENTE_TITULO))
            prc.Add(New Chunk(CP_CLIENTE & " " & comprobante.Receptor.Nombre & vbLf, FUENTE_NORMAL))

            prc.Add(New Chunk(comprobante.Receptor.Rfc & vbLf, FUENTE_NORMAL))
            prc.Add(New Chunk("RÉGIMEN FISCAL: " & comprobante.Receptor.RegimenFiscalReceptor & " - " + ObtenerRegimenFiscal(comprobante.Receptor.RegimenFiscalReceptor) & vbLf, FUENTE_NORMAL))
            prc.Add(New Chunk("USO CFDI: " & comprobante.Receptor.UsoCFDI & " - " + ObtenerUsoCFDI(comprobante.Receptor.UsoCFDI) & vbLf & vbLf, FUENTE_NORMAL))

            prc.Add(New Chunk("Domicilio fiscal" & vbLf, FUENTE_TITULO))
            prc.Add(New Chunk(PassData7 & vbLf, FUENTE_NORMAL))

            tablaDatos.AddCell(New PdfPCell(prc) With {
                .HorizontalAlignment = Element.ALIGN_CENTER,
                .Border = Rectangle.NO_BORDER,
                .PaddingLeft = 12,
                .PaddingRight = 12
            })
            anchoColumnas = New Single() {cmAFloat(6.3F)}
            Dim tablaDatosFactura As PdfPTable = New PdfPTable(anchoColumnas)
            tablaDatosFactura.DefaultCell.Border = Rectangle.NO_BORDER
            tablaDatosFactura.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT
            tablaDatosFactura.DefaultCell.SetLeading(5, 0)

            'FACTURA SOLO NUMERO
            tablaDatosFactura.AddCell(New Phrase("FACTURA: " & comprobante.Serie & " " + comprobante.Folio, FUENTE_TITULO))
            Try
                tablaDatosFactura.AddCell(New Phrase("FOLIO FISCAL (UUID):", FUENTE_TITULO1))
                tablaDatosFactura.AddCell(New Phrase(comprobante.Complemento.TimbreFiscalDigital.UUID, FUENTE_NORMAL))
                tablaDatosFactura.AddCell(New Phrase("NO. DE SERIE DEL CERTIFICADO DEL SAT:", FUENTE_TITULO1))
                tablaDatosFactura.AddCell(New Phrase(comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT, FUENTE_NORMAL))
            Catch ex As Exception
            End Try
            tablaDatosFactura.AddCell(New Phrase("NO. DE SERIE DEL CERTIFICADO DEL EMISOR:", FUENTE_TITULO1))
            tablaDatosFactura.AddCell(New Phrase(comprobante.NoCertificado, FUENTE_NORMAL))
            tablaDatosFactura.AddCell(New Phrase("FECHA Y HORA DE CERTIFICACIÓN:", FUENTE_TITULO1))
            Try
                tablaDatosFactura.AddCell(New Phrase(comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado.ToString("s"), FUENTE_NORMAL))
            Catch ex As Exception
            End Try
            tablaDatosFactura.AddCell(New Phrase("FECHA Y HORA DE EMISIÓN DE CFDI:", FUENTE_TITULO1))
            tablaDatosFactura.AddCell(New Phrase(comprobante.Fecha.ToString("s"), FUENTE_NORMAL))
            tablaDatosFactura.AddCell(New Phrase("LUGAR DE EXPEDICIÓN:", FUENTE_TITULO1))
            tablaDatosFactura.AddCell(New Phrase(comprobante.LugarExpedicion, FUENTE_NORMAL))

            If Not IsNothing(CTA_PORT1) Then
                tablaDatosFactura.AddCell(New Phrase("CARTA PORTE: " & GetNumeric(CTA_PORT1), FUENTE_TITULO1))
                If CTA_PORT2.Trim.Length > 0 Then
                    tablaDatosFactura.AddCell(New Phrase("CARTA PORTE 2:" & GetNumeric(CTA_PORT2), FUENTE_TITULO1))
                End If
                If CP_NUM_PROV.Trim.Length > 0 Then
                    tablaDatosFactura.AddCell(New Phrase("NUMERO PROVEEDOR: " & CP_NUM_PROV, FUENTE_TITULO1))
                End If
            End If

            tablaDatosFactura.AddCell(New Phrase("Version ""4.0""", FUENTE_TITULO1))

            tablaDatos.AddCell(tablaDatosFactura)
            tablaDatos.CompleteRow()
        Catch ex As Exception
            MsgBox("755. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORACFDI("755. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Return tablaDatos
    End Function

    Private Shared Function AgregarDatosProductos(ByVal comprobante As Comprobante) As IElement
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        FUENTE_NORMAL_BOLD.Size = 8
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {1.4F, 2.4F, 2.4F, 9.0F, 2.4F, 2.4F})
        Dim tablaProductos As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaProductos.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaProductos.DefaultCell.BorderColor = cBorde
        tablaProductos.SpacingBefore = 10
        tablaProductos.DefaultCell.BackgroundColor = BaseColor.BLACK
        tablaProductos.LockedWidth = True
        tablaProductos.SetTotalWidth(tamanoColumnas)
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("CONCEPTOS", FUENTE_SUBTITULO_BLANCO)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.UseAscender = True
        ctitulo.BorderColor = cBorde
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        ctitulo.BorderWidth = 1.0F
        ctitulo.Colspan = 6
        tablaProductos.AddCell(ctitulo)
        tablaProductos.AddCell(New Phrase("Cantidad", FUENTE_SUBTITULO_BLANCO))
        tablaProductos.AddCell(New PdfPCell(New Phrase("Unidad", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BorderColor = cBorde,
            .BackgroundColor = BaseColor.BLACK,
            .HorizontalAlignment = Element.ALIGN_CENTER
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("No. Identificación", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BorderColor = cBorde,
            .BackgroundColor = BaseColor.BLACK,
            .HorizontalAlignment = Element.ALIGN_CENTER
        })
        tablaProductos.AddCell(New Phrase("Descripcion", FUENTE_SUBTITULO_BLANCO))
        tablaProductos.AddCell(New PdfPCell(New Phrase("Precio Unitario", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BackgroundColor = BaseColor.BLACK,
            .BorderColor = cBorde,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BackgroundColor = BaseColor.BLACK,
            .BorderColor = cBorde,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })

        For Each concepto As Concepto In comprobante.Conceptos.Concepto
            Dim descripcion As StringBuilder = New StringBuilder()
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Cantidad.ToString("F2"), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveUnidad & " - " + ObtenerUnidad(concepto.ClaveUnidad), FUENTE_NORMAL)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.NoIdentificacion, FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            descripcion.Append(concepto.Descripcion & vbLf & vbLf & "Clave Prod. Serv. " + concepto.ClaveProdServ & vbLf)

            If concepto.Impuestos IsNot Nothing Then
                descripcion.Append("Impuestos:" & vbLf)

                If concepto.Impuestos.Traslados.Count > 0 Then
                    descripcion.Append("  Traslados:" & vbLf)

                    For Each t As TrasladoC In concepto.Impuestos.Traslados
                        descripcion.Append("    " & t.Impuesto & " " + ObtenerImpuesto(t.Impuesto) & " Base - " + t.Base.ToString("C2") & " Tasa - " + t.TasaOCuota.ToString("F6") & " Importe - " + t.Importe.ToString("C2") & vbLf)
                    Next
                End If
            End If

            tablaProductos.AddCell(New PdfPCell(New Phrase(descripcion.ToString(), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ValorUnitario.ToString("C"), FUENTE_NORMAL)) With {
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .BorderColor = cBorde,
                .BorderWidth = 1
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Importe.ToString("C"), FUENTE_NORMAL)) With {
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .BorderColor = cBorde,
                .BorderWidth = 1
            })
        Next

        'AQUI ESTA EL PROBLEMA
        If comprobante.TipoDeComprobante <> "P" AndAlso comprobante.TipoDeComprobante <> "N" Then
            Dim AnchoDoc As Integer

            AnchoDoc = tablaProductos.CalculateHeights()

            If tablaProductos.CalculateHeights() < 400 Then
                Dim total As Single = 400 - tablaProductos.CalculateHeights()
                tablaProductos.AddCell(New PdfPCell(New Phrase(" ")) With {
                    .BorderWidth = 1,
                    .BorderWidthTop = 0,
                    .BorderColor = BaseColor.WHITE,
                    .Colspan = 6,
                    .FixedHeight = total
                })
            End If
        End If

        Return tablaProductos
    End Function

    Private Shared Function ObtenerTotalEnLetra(ByVal total As Decimal) As String
        Dim numaLet As Numalet = New Numalet()
        numaLet.MascaraSalidaDecimal = "00/100 M.N."
        numaLet.SeparadorDecimalSalida = "pesos"
        numaLet.ApocoparUnoParteEntera = True
        numaLet.LetraCapital = True
        Return numaLet.ToCustomString(total).ToUpper()
    End Function

    Private Shared Function AgregarTotales(ByVal comprobante As Comprobante) As IElement
        Dim anchoColumasTablaTotales As Single() = cmAFloat(New Single() {13.5F, 6.5F})
        Dim tablaTotales As PdfPTable = New PdfPTable(anchoColumasTablaTotales)
        tablaTotales.HorizontalAlignment = Element.ALIGN_CENTER
        tablaTotales.SetTotalWidth(anchoColumasTablaTotales)
        tablaTotales.DefaultCell.Border = Rectangle.NO_BORDER
        tablaTotales.SpacingBefore = 4
        tablaTotales.LockedWidth = True
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 2.5F})
        Dim tablaImportes As PdfPTable = New PdfPTable(anchoColumnas)
        tablaImportes.SetTotalWidth(anchoColumnas)
        tablaImportes.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT
        tablaImportes.LockedWidth = True
        tablaImportes.DefaultCell.Border = Rectangle.NO_BORDER
        Dim columnasLetra As Single() = cmAFloat(New Single() {3.6F, 9.9F})
        Dim tablaImporteLetra As PdfPTable = New PdfPTable(columnasLetra)
        tablaImporteLetra.DefaultCell.Border = Rectangle.NO_BORDER
        tablaImporteLetra.SetTotalWidth(columnasLetra)
        tablaImporteLetra.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
        tablaImporteLetra.LockedWidth = True

        If comprobante.Descuento > 0 Then
            Dim subtotal As Decimal = comprobante.SubTotal + comprobante.Descuento
            tablaImportes.AddCell(New Phrase("SUBTOTAL:", FUENTE_TITULO1))
            tablaImportes.AddCell(New Phrase(comprobante.SubTotal.ToString("C2"), FUENTE_NORMAL))
            tablaImportes.AddCell(New Phrase("DESCUENTO:", FUENTE_TITULO1))
            tablaImportes.AddCell(New Phrase(comprobante.Descuento.ToString("C2"), FUENTE_NORMAL))
        End If

        tablaImportes.AddCell(New Phrase("SUBTOTAL:", FUENTE_TITULO1))
        tablaImportes.AddCell(New Phrase(comprobante.SubTotal.ToString("C2"), FUENTE_NORMAL))

        If comprobante.Impuestos IsNot Nothing Then

            If comprobante.Impuestos.Traslados IsNot Nothing Then

                For Each t As Traslado In comprobante.Impuestos.Traslados
                    tablaImportes.AddCell(New Phrase("TRASLADO " & ObtenerImpuesto(t.Impuesto) & " TASA " + t.TasaOCuota.ToString("F6"), FUENTE_TITULO1))
                    tablaImportes.AddCell(New Phrase(t.Importe.ToString("C2"), FUENTE_NORMAL))
                Next
            End If

            If comprobante.Impuestos.Retenciones IsNot Nothing Then

                For Each r As Retencion In comprobante.Impuestos.Retenciones
                    tablaImportes.AddCell(New Phrase("RETENCIÓN " & ObtenerImpuesto(r.Impuesto), FUENTE_TITULO1))
                    tablaImportes.AddCell(New Phrase(r.Importe.ToString("C2"), FUENTE_NORMAL))
                Next
            End If
        End If

        tablaImportes.AddCell(New Phrase("TOTAL:", FUENTE_TITULO1))
        tablaImportes.AddCell(New Phrase(comprobante.Total.ToString("C2"), FUENTE_NORMAL))
        tablaImporteLetra.AddCell(New Phrase("IMPORTE CON LETRA: ", FUENTE_TITULO1))
        tablaImporteLetra.AddCell(New PdfPCell(New Phrase(ObtenerTotalEnLetra(comprobante.Total), FUENTE_NORMAL)) With {
            .Rowspan = 2,
            .Border = Rectangle.NO_BORDER
        })
        tablaImporteLetra.AddCell(New Phrase(" ", FUENTE_TITULO1))
        tablaImporteLetra.AddCell(New Phrase("TIPO DE COMPROBANTE:", FUENTE_TITULO1))
        tablaImporteLetra.AddCell(New Phrase(comprobante.TipoDeComprobante & " - " + ObtenerTipoComprobante(comprobante.TipoDeComprobante), FUENTE_NORMAL))

        If comprobante.FormaPago <> String.Empty Then
            tablaImporteLetra.AddCell(New Phrase("FORMA DE PAGO:", FUENTE_TITULO1))
            tablaImporteLetra.AddCell(New Phrase(comprobante.FormaPago & " - " + ObtenerFormaPago(comprobante.FormaPago), FUENTE_NORMAL))
        End If

        If comprobante.MetodoPago <> String.Empty Then
            tablaImporteLetra.AddCell(New Phrase("MÉTODO DE PAGO:", FUENTE_TITULO1))
            tablaImporteLetra.AddCell(New Phrase(comprobante.MetodoPago & " - " + ObtenerMetodoPago(comprobante.MetodoPago), FUENTE_NORMAL))
        End If

        tablaImporteLetra.AddCell(New Phrase("MONEDA:", FUENTE_TITULO1))
        tablaImporteLetra.AddCell(New Phrase(comprobante.Moneda & " - " + ObtenerMoneda(comprobante.Moneda), FUENTE_NORMAL))
        tablaTotales.AddCell(tablaImporteLetra)
        tablaTotales.AddCell(tablaImportes)
        Return tablaTotales
    End Function

    Private Shared Function AgregarSellos(ByVal comprobante As Comprobante) As IElement
        Dim codigoQR As StringBuilder = New StringBuilder()
        codigoQR.Append("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?")
        codigoQR.Append("&id=" & comprobante.Complemento.TimbreFiscalDigital.UUID)
        codigoQR.Append("&re=" & comprobante.Emisor.Rfc)
        codigoQR.Append("&rr=" & comprobante.Receptor.Rfc)
        codigoQR.Append("&tt=" & comprobante.Total.ToString())
        codigoQR.Append("&fe=" & comprobante.Sello.Substring(comprobante.Sello.Length - 8, 8))
        Dim pdfCodigoQR As BarcodeQRCode = New BarcodeQRCode(codigoQR.ToString(), 1, 1, Nothing)
        Dim img As Image = pdfCodigoQR.GetImage()
        img.ScaleAbsolute(cmAFloat(3.4F), cmAFloat(3.4F))
        img.Alignment = Element.ALIGN_LEFT
        Dim cadenaOriginal As StringBuilder = New StringBuilder()
        cadenaOriginal.Append("||")
        cadenaOriginal.Append("1.0|")
        cadenaOriginal.Append(comprobante.Folio & "|")
        cadenaOriginal.Append(comprobante.Folio.ToString() & "|")
        cadenaOriginal.Append(comprobante.Sello & "|")
        cadenaOriginal.Append(comprobante.Serie & "||")
        Dim anchoColumnas As Single() = cmAFloat(New Single() {3.5F, 16.5F})
        Dim tablaSellosQR As PdfPTable = New PdfPTable(anchoColumnas)
        tablaSellosQR.DefaultCell.Border = Rectangle.NO_BORDER
        tablaSellosQR.SetTotalWidth(anchoColumnas)
        tablaSellosQR.LockedWidth = True
        tablaSellosQR.SpacingBefore = 7
        tablaSellosQR.KeepTogether = True
        Dim celdaimagen As PdfPCell = New PdfPCell()
        celdaimagen.Border = Rectangle.NO_BORDER
        celdaimagen.VerticalAlignment = Element.ALIGN_TOP
        celdaimagen.Padding = 0
        celdaimagen.AddElement(img)

        celdaimagen.FixedHeight = cmAFloat(3.5F)
        tablaSellosQR.AddCell(celdaimagen)
        Dim anchoColumnas1 As Single() = cmAFloat(New Single() {16.5F})
        Dim tablaSellos As PdfPTable = New PdfPTable(anchoColumnas1)
        tablaSellos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
        tablaSellos.DefaultCell.VerticalAlignment = Element.ALIGN_TOP
        tablaSellos.DefaultCell.Border = Rectangle.NO_BORDER
        tablaSellos.SetTotalWidth(anchoColumnas1)
        tablaSellos.HorizontalAlignment = Element.ALIGN_CENTER
        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL CFDI:", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
        tablaSellos.AddCell(New Phrase(comprobante.Sello, New Font(Font.FontFamily.HELVETICA, 6)))
        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL SAT", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
        tablaSellos.AddCell(New Phrase(comprobante.Sello, New Font(Font.FontFamily.HELVETICA, 6)))
        tablaSellos.AddCell(New Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT:", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
        tablaSellos.AddCell(New Phrase(cadenaOriginal.ToString(), New Font(Font.FontFamily.HELVETICA, 6)))
        tablaSellosQR.AddCell(tablaSellos)
        Return tablaSellosQR
    End Function
#End Region
    '#Region "Pagos"
    '    Private Shared Function PAgregarDocumentosRelacionados(ByVal documentosRelacionados As List(Of PDoctoRelacionado)) As PdfPTable
    '        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
    '        Dim tDocumentos As PdfPTable = New PdfPTable(anchoColumnas)
    '        tDocumentos.SetTotalWidth(anchoColumnas)
    '        tDocumentos.SpacingBefore = 5
    '        tDocumentos.HorizontalAlignment = Element.ALIGN_CENTER
    '        tDocumentos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
    '        tDocumentos.DefaultCell.BorderWidth = 1
    '        tDocumentos.LockedWidth = True

    '        If documentosRelacionados.Count > 0 Then
    '            Dim count As Integer = 1

    '            For Each dr As PDoctoRelacionado In documentosRelacionados
    '                Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DOCUMENTO RELACIONADO  " & count.ToString(), FUENTE_SUBTITULO_BLANCO))
    '                cEncabezado.Border = Rectangle.NO_BORDER
    '                cEncabezado.BackgroundColor = BaseColor.BLACK
    '                cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
    '                cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
    '                cEncabezado.UseAscender = True
    '                cEncabezado.Colspan = 4
    '                tDocumentos.AddCell(cEncabezado)
    '                tDocumentos.CompleteRow()
    '                tDocumentos.AddCell(New Phrase("Id Documento:", FUENTE_NORMAL_BOLD))
    '                tDocumentos.AddCell(New Phrase(dr.IdDocumento, FUENTE_NORMAL))
    '                tDocumentos.AddCell(New Phrase("Folio:", FUENTE_NORMAL_BOLD))
    '                tDocumentos.AddCell(New Phrase(dr.Serie & " " + dr.Folio, FUENTE_NORMAL))
    '                tDocumentos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
    '                tDocumentos.AddCell(New Phrase(dr.MonedaDR, FUENTE_NORMAL))

    '                If dr.TipoCambioDR > 0 Then
    '                    tDocumentos.AddCell(New Phrase("Tipo de cambio:", FUENTE_NORMAL_BOLD))
    '                    tDocumentos.AddCell(New Phrase(dr.TipoCambioDR.ToString("F2"), FUENTE_NORMAL))
    '                End If

    '                tDocumentos.AddCell(New Phrase("Metodo de Pago:", FUENTE_NORMAL_BOLD))
    '                tDocumentos.AddCell(New Phrase(dr.MetodoDePagoDR & " - " + ObtenerMetodoPago(dr.MetodoDePagoDR), FUENTE_NORMAL))

    '                If dr.NumParcialidad <> String.Empty Then
    '                    tDocumentos.AddCell(New Phrase("Núm. de parcialidad:", FUENTE_NORMAL_BOLD))
    '                    tDocumentos.AddCell(New Phrase(dr.NumParcialidad, FUENTE_NORMAL))
    '                End If

    '                If dr.ImpSaldoAnt <> 0 Then
    '                    tDocumentos.AddCell(New Phrase("Saldo anterior:", FUENTE_NORMAL_BOLD))
    '                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoAnt.ToString("C2"), FUENTE_NORMAL))
    '                End If

    '                If dr.ImpPagado <> 0 Then
    '                    tDocumentos.AddCell(New Phrase("Importe pagado:", FUENTE_NORMAL_BOLD))
    '                    tDocumentos.AddCell(New Phrase(dr.ImpPagado.ToString("C2"), FUENTE_NORMAL))
    '                End If

    '                If dr.ImpSaldoInsoluto <> 0 Then
    '                    tDocumentos.AddCell(New Phrase("Saldo insoluto:", FUENTE_NORMAL_BOLD))
    '                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoInsoluto.ToString("C2"), FUENTE_NORMAL))
    '                End If

    '                tDocumentos.CompleteRow()
    '                count += 1
    '            Next
    '        End If

    '        Return tDocumentos
    '    End Function

    '    Private Shared Function PAgregarPago(ByVal pago As Pago, ByVal contador As Integer) As PdfPTable
    '        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
    '        Dim tPagos As PdfPTable = New PdfPTable(anchoColumnas)
    '        tPagos.SetTotalWidth(anchoColumnas)
    '        tPagos.SpacingBefore = 5
    '        tPagos.HorizontalAlignment = Element.ALIGN_CENTER
    '        tPagos.DefaultCell.BorderWidth = 1
    '        tPagos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
    '        tPagos.LockedWidth = True
    '        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("PAGO " & contador.ToString(), FUENTE_SUBTITULO_BLANCO)) With {
    '            .BackgroundColor = BaseColor.BLACK
    '        }
    '        ctitulo.Border = Rectangle.NO_BORDER
    '        ctitulo.Colspan = 4
    '        ctitulo.UseAscender = True
    '        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
    '        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
    '        tPagos.AddCell(ctitulo)
    '        tPagos.AddCell(New Phrase("Fecha de pago:", FUENTE_NORMAL_BOLD))
    '        tPagos.AddCell((New Phrase(pago.FechaPago.ToShortDateString(), FUENTE_NORMAL)))
    '        tPagos.AddCell(New Phrase("Forma de pago:", FUENTE_NORMAL_BOLD))
    '        tPagos.AddCell(New Phrase(pago.FormaDePagoP & " - " + ObtenerFormaPago(pago.FormaDePagoP), FUENTE_NORMAL))
    '        tPagos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
    '        tPagos.AddCell(New Phrase(pago.MonedaP, FUENTE_NORMAL))

    '        If pago.TipoCambioP <> 0 Then
    '            tPagos.AddCell(New Phrase("Tipo de cambio:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.TipoCambioP.ToString("C2"), FUENTE_NORMAL))
    '        End If

    '        tPagos.AddCell(New Phrase("Monto:", FUENTE_NORMAL_BOLD))
    '        tPagos.AddCell(New Phrase(pago.Monto.ToString("C2"), FUENTE_NORMAL))

    '        If pago.NumOperacion <> String.Empty Then
    '            tPagos.AddCell(New Phrase("Núm. de operación:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.NumOperacion, FUENTE_NORMAL))
    '        End If

    '        If pago.RfcEmisorCtaOrd <> String.Empty Then
    '            tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
    '        End If

    '        If pago.NomBancoOrdExt <> String.Empty Then
    '            tPagos.AddCell(New Phrase("NomBancoOrdExt:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.NomBancoOrdExt, FUENTE_NORMAL))
    '        End If

    '        If pago.CtaOrdenante <> String.Empty Then
    '            tPagos.AddCell(New Phrase("CtaOrdenante:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.CtaOrdenante, FUENTE_NORMAL))
    '        End If

    '        If pago.RfcEmisorCtaOrd <> String.Empty Then
    '            tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
    '        End If

    '        If pago.RfcEmisorCtaBen <> String.Empty Then
    '            tPagos.AddCell(New Phrase("RfcEmisorCtaBen:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaBen, FUENTE_NORMAL))
    '        End If

    '        If pago.CtaBeneficiario <> String.Empty Then
    '            tPagos.AddCell(New Phrase("CtaBeneficiario:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.CtaBeneficiario, FUENTE_NORMAL))
    '        End If

    '        If pago.TipoCadPago <> String.Empty Then
    '            tPagos.AddCell(New Phrase("TipoCadPago:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.TipoCadPago, FUENTE_NORMAL))
    '        End If

    '        If pago.CertPago <> String.Empty Then
    '            tPagos.AddCell(New Phrase("CertPago:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.CertPago, FUENTE_NORMAL))
    '        End If

    '        If pago.CadPago <> String.Empty Then
    '            tPagos.AddCell(New Phrase("CadPago:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.CadPago, FUENTE_NORMAL))
    '        End If

    '        If pago.SelloPago <> String.Empty Then
    '            tPagos.AddCell(New Phrase("SelloPago:", FUENTE_NORMAL_BOLD))
    '            tPagos.AddCell(New Phrase(pago.SelloPago, FUENTE_NORMAL))
    '        End If

    '        tPagos.CompleteRow()

    '        If pago.Impuestos IsNot Nothing AndAlso pago.Impuestos.Count > 0 Then
    '            Dim cdr As PdfPCell = New PdfPCell(New Paragraph("- Impuestos:", FUENTE_NORMAL_BOLD))
    '            cdr.Colspan = 3
    '            tPagos.AddCell(cdr)
    '            tPagos.CompleteRow()

    '            For Each impuestos As PImpuestos In pago.Impuestos

    '                For Each r As PRetencion In impuestos.Retenciones.Retencion

    '                    If r.Impuesto <> String.Empty Then
    '                        tPagos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
    '                        tPagos.AddCell(New Phrase(r.Impuesto, FUENTE_NORMAL))
    '                    End If

    '                    If r.Importe <> 0 Then
    '                        tPagos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
    '                        tPagos.AddCell(New Phrase(r.Importe.ToString("C2"), FUENTE_NORMAL))
    '                    End If

    '                    tPagos.CompleteRow()
    '                Next

    '                For Each t As PTraslado In impuestos.Traslados.Traslado
    '                    tPagos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(t.Impuesto, FUENTE_NORMAL))
    '                    tPagos.AddCell(New Phrase("Tipo factor:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(t.TipoFactor, FUENTE_NORMAL))
    '                    tPagos.AddCell(New Phrase("Tasa:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(t.TasaOCuota.ToString("C2"), FUENTE_NORMAL))
    '                    tPagos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(t.Importe.ToString("C2"), FUENTE_NORMAL))
    '                    tPagos.CompleteRow()
    '                Next

    '                If impuestos.TotalImpuestosRetenidos > 0 Then
    '                    tPagos.AddCell(New Phrase("Total impuestos retenidos:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(impuestos.TotalImpuestosRetenidos.ToString("C2"), FUENTE_NORMAL))
    '                    tPagos.CompleteRow()
    '                End If

    '                If impuestos.TotalImpuestosTrasladados > 0 Then
    '                    tPagos.AddCell(New Phrase("Total impuestos trasladados:", FUENTE_NORMAL_BOLD))
    '                    tPagos.AddCell(New Phrase(impuestos.TotalImpuestosTrasladados.ToString("C2"), FUENTE_NORMAL))
    '                    tPagos.CompleteRow()
    '                End If
    '            Next
    '        End If

    '        Return tPagos
    '    End Function

    '    Private Shared Sub AgregarTablaPagos(ByVal documento As Document, ByVal comprobante As Comprobante)
    '        If comprobante.Complemento.Pagos Is Nothing OrElse comprobante.Complemento.Pagos.Pago.Count <= 0 Then Return
    '        Dim contador As Integer = 1

    '        For Each pago As Pago In comprobante.Complemento.Pagos.Pago
    '            documento.Add(PAgregarPago(pago, contador))
    '            If pago.DoctoRelacionado.Count > 0 Then documento.Add(PAgregarDocumentosRelacionados(pago.DoctoRelacionado))
    '            contador += 1
    '        Next
    '    End Sub
    '#End Region
#Region "Pagos 2.0"
    Private Shared Function PAgregarDocumentosRelacionados(ByVal documentosRelacionados As List(Of PDoctoRelacionado)) As PdfPTable
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tDocumentos As PdfPTable = New PdfPTable(anchoColumnas)
        tDocumentos.SetTotalWidth(anchoColumnas)
        tDocumentos.SpacingBefore = 5
        tDocumentos.HorizontalAlignment = Element.ALIGN_CENTER
        tDocumentos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tDocumentos.DefaultCell.BorderWidth = 1
        tDocumentos.LockedWidth = True

        If documentosRelacionados.Count > 0 Then
            Dim count As Integer = 1

            For Each dr As PDoctoRelacionado In documentosRelacionados
                Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DOCUMENTO RELACIONADO  " & count.ToString(), FUENTE_SUBTITULO_BLANCO))
                cEncabezado.Border = Rectangle.NO_BORDER
                cEncabezado.BackgroundColor = BaseColor.BLACK
                cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
                cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
                cEncabezado.UseAscender = True
                cEncabezado.Colspan = 4
                tDocumentos.AddCell(cEncabezado)
                tDocumentos.CompleteRow()
                tDocumentos.AddCell(New Phrase("Id Documento:", FUENTE_NORMAL_BOLD))
                tDocumentos.AddCell(New Phrase(dr.IdDocumento, FUENTE_NORMAL))
                tDocumentos.AddCell(New Phrase("Serie:", FUENTE_NORMAL_BOLD))
                tDocumentos.AddCell(New Phrase(dr.Serie, FUENTE_NORMAL))
                tDocumentos.AddCell(New Phrase("Folio:", FUENTE_NORMAL_BOLD))
                tDocumentos.AddCell(New Phrase(dr.Folio, FUENTE_NORMAL))
                tDocumentos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
                tDocumentos.AddCell(New Phrase(dr.MonedaDR, FUENTE_NORMAL))

                If dr.EquivalenciaDR > 0 Then
                    tDocumentos.AddCell(New Phrase("Equivalencia:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.EquivalenciaDR.ToString("F2"), FUENTE_NORMAL))
                End If

                If dr.NumParcialidad <> String.Empty Then
                    tDocumentos.AddCell(New Phrase("Núm. de parcialidad:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.NumParcialidad, FUENTE_NORMAL))
                End If

                If dr.ImpSaldoAnt <> 0 Then
                    tDocumentos.AddCell(New Phrase("Saldo anterior:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoAnt.ToString("C2"), FUENTE_NORMAL))
                End If

                If dr.ImpPagado <> 0 Then
                    tDocumentos.AddCell(New Phrase("Importe pagado:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpPagado.ToString("C2"), FUENTE_NORMAL))
                End If

                If dr.ImpSaldoInsoluto <> 0 Then
                    tDocumentos.AddCell(New Phrase("Saldo insoluto:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ImpSaldoInsoluto.ToString("C2"), FUENTE_NORMAL))
                End If

                If dr.ImpSaldoInsoluto <> 0 Then
                    tDocumentos.AddCell(New Phrase("Objeto de impuesto:", FUENTE_NORMAL_BOLD))
                    tDocumentos.AddCell(New Phrase(dr.ObjetoImpDR, FUENTE_NORMAL))
                End If

                tDocumentos.CompleteRow()
                count += 1
            Next
        End If

        Return tDocumentos
    End Function

    Private Shared Function PAgregarPago(ByVal pago As Pago, ByVal contador As Integer) As PdfPTable
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tPagos As PdfPTable = New PdfPTable(anchoColumnas)
        tPagos.SetTotalWidth(anchoColumnas)
        tPagos.SpacingBefore = 5
        tPagos.HorizontalAlignment = Element.ALIGN_CENTER
        tPagos.DefaultCell.BorderWidth = 1
        tPagos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tPagos.LockedWidth = True
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("PAGO " & contador.ToString(), FUENTE_SUBTITULO_BLANCO)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.Colspan = 4
        ctitulo.UseAscender = True
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        tPagos.AddCell(ctitulo)
        tPagos.AddCell(New Phrase("Fecha de pago:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell((New Phrase(pago.FechaPago.ToShortDateString(), FUENTE_NORMAL)))
        tPagos.AddCell(New Phrase("Forma de pago:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.FormaDePagoP & " - " + ObtenerFormaPago(pago.FormaDePagoP), FUENTE_NORMAL))
        tPagos.AddCell(New Phrase("Moneda:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.MonedaP, FUENTE_NORMAL))

        If pago.TipoCambioP <> 0 Then
            tPagos.AddCell(New Phrase("Tipo de cambio:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.TipoCambioP.ToString("C2"), FUENTE_NORMAL))
        End If

        tPagos.AddCell(New Phrase("Monto:", FUENTE_NORMAL_BOLD))
        tPagos.AddCell(New Phrase(pago.Monto.ToString("C2"), FUENTE_NORMAL))

        If pago.NumOperacion <> String.Empty Then
            tPagos.AddCell(New Phrase("Núm. de operación:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.NumOperacion, FUENTE_NORMAL))
        End If

        If pago.RfcEmisorCtaOrd <> String.Empty Then
            tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
        End If

        If pago.NomBancoOrdExt <> String.Empty Then
            tPagos.AddCell(New Phrase("NomBancoOrdExt:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.NomBancoOrdExt, FUENTE_NORMAL))
        End If

        If pago.CtaOrdenante <> String.Empty Then
            tPagos.AddCell(New Phrase("CtaOrdenante:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.CtaOrdenante, FUENTE_NORMAL))
        End If

        If pago.RfcEmisorCtaOrd <> String.Empty Then
            tPagos.AddCell(New Phrase("RFC Emisor Cta:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaOrd, FUENTE_NORMAL))
        End If

        If pago.RfcEmisorCtaBen <> String.Empty Then
            tPagos.AddCell(New Phrase("RfcEmisorCtaBen:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.RfcEmisorCtaBen, FUENTE_NORMAL))
        End If

        If pago.CtaBeneficiario <> String.Empty Then
            tPagos.AddCell(New Phrase("CtaBeneficiario:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.CtaBeneficiario, FUENTE_NORMAL))
        End If

        If pago.TipoCadPago <> String.Empty Then
            tPagos.AddCell(New Phrase("TipoCadPago:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.TipoCadPago, FUENTE_NORMAL))
        End If

        If pago.CertPago <> String.Empty Then
            tPagos.AddCell(New Phrase("CertPago:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.CertPago, FUENTE_NORMAL))
        End If

        If pago.CadPago <> String.Empty Then
            tPagos.AddCell(New Phrase("CadPago:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.CadPago, FUENTE_NORMAL))
        End If

        If pago.SelloPago <> String.Empty Then
            tPagos.AddCell(New Phrase("SelloPago:", FUENTE_NORMAL_BOLD))
            tPagos.AddCell(New Phrase(pago.SelloPago, FUENTE_NORMAL))
        End If

        tPagos.CompleteRow()

        If pago.Impuestos IsNot Nothing Then
            Dim cdr As PdfPCell = New PdfPCell(New Paragraph("- Impuestos:", FUENTE_NORMAL_BOLD))
            cdr.Colspan = 3
            tPagos.AddCell(cdr)
            tPagos.CompleteRow()

            For Each r As RetencionP In pago.Impuestos.RetencionesP.RetencionP

                If r.ImpuestoP <> String.Empty Then
                    tPagos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
                    tPagos.AddCell(New Phrase(r.ImpuestoP, FUENTE_NORMAL))
                End If

                If r.ImporteP <> 0 Then
                    tPagos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
                    tPagos.AddCell(New Phrase(r.ImporteP.ToString("C2"), FUENTE_NORMAL))
                End If

                tPagos.CompleteRow()
            Next

            For Each t As TrasladoP In pago.Impuestos.TrasladosP.TrasladoP
                tPagos.AddCell(New Phrase("Base:", FUENTE_NORMAL_BOLD))
                tPagos.AddCell(New Phrase(t.BaseP.ToString("C2"), FUENTE_NORMAL))
                tPagos.AddCell(New Phrase("Impuesto:", FUENTE_NORMAL_BOLD))
                tPagos.AddCell(New Phrase(t.ImpuestoP, FUENTE_NORMAL))
                tPagos.AddCell(New Phrase("Tipo factor:", FUENTE_NORMAL_BOLD))
                tPagos.AddCell(New Phrase(t.TipoFactorP, FUENTE_NORMAL))
                tPagos.AddCell(New Phrase("Tasa:", FUENTE_NORMAL_BOLD))
                tPagos.AddCell(New Phrase(t.TasaOCuotaP.ToString("C2"), FUENTE_NORMAL))
                tPagos.AddCell(New Phrase("Importe:", FUENTE_NORMAL_BOLD))
                tPagos.AddCell(New Phrase(t.ImporteP.ToString("C2"), FUENTE_NORMAL))
                tPagos.CompleteRow()
            Next
        End If

        Return tPagos
    End Function

    Private Shared Sub AgregarTablaPagos(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.Pagos Is Nothing OrElse comprobante.Complemento.Pagos.Pago.Count <= 0 Then Return
        Dim pagos As Pagos = comprobante.Complemento.Pagos
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tPagos As PdfPTable = New PdfPTable(anchoColumnas)
        tPagos.SetTotalWidth(anchoColumnas)
        tPagos.SpacingBefore = 5
        tPagos.HorizontalAlignment = Element.ALIGN_CENTER
        tPagos.DefaultCell.BorderWidth = 1
        tPagos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tPagos.LockedWidth = True
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("PAGOS", FUENTE_SUBTITULO_BLANCO)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.Border = Rectangle.NO_BORDER
        ctitulo.Colspan = 4
        ctitulo.UseAscender = True
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        tPagos.AddCell(ctitulo)

        If pagos.Totales.TotalRetencionesIEPS > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IEPS", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalRetencionesIEPS.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalRetencionesISR > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones ISR", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalRetencionesISR.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalRetencionesIVA > 0 Then
            tPagos.AddCell(New Phrase("Total retenciones IVA", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalRetencionesIVA.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosBaseIVA0 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados base IVA 0", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosBaseIVA0.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosBaseIVA16 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados base IVA 16", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosBaseIVA16.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosBaseIVA8 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados base IVA 8", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosBaseIVA8.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosBaseIVAExento > 0 Then
            tPagos.AddCell(New Phrase("Total traslados base IVA exento", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosBaseIVAExento.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosImpuestoIVA0 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuesto IVA 0", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosImpuestoIVA0.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosImpuestoIVA16 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuesto IVA 16", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosImpuestoIVA16.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.TotalTrasladosImpuestoIVA8 > 0 Then
            tPagos.AddCell(New Phrase("Total traslados impuesto IVA 8", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.TotalTrasladosImpuestoIVA8.ToString("C2"), FUENTE_NORMAL)))
        End If

        If pagos.Totales.MontoTotalPagos > 0 Then
            tPagos.AddCell(New Phrase("Monto total pagos", FUENTE_NORMAL_BOLD))
            tPagos.AddCell((New Phrase(pagos.Totales.MontoTotalPagos.ToString("C2"), FUENTE_NORMAL)))
        End If

        tPagos.CompleteRow()
        documento.Add(tPagos)
        Dim contador As Integer = 1

        For Each pago As Pago In comprobante.Complemento.Pagos.Pago
            documento.Add(PAgregarPago(pago, contador))
            If pago.DoctoRelacionado.Count > 0 Then documento.Add(PAgregarDocumentosRelacionados(pago.DoctoRelacionado))
            contador += 1
        Next
    End Sub
#End Region
#Region "Comercio exteior"
    Public Shared Sub CCEAgregarComercioExterior(ByVal documento As Document, ByVal comercioExterior As ComercioExterior)
        Dim contador As Integer = 0
        If comercioExterior Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tComercioExterior As PdfPTable = New PdfPTable(anchoColumnas)
        tComercioExterior.SetTotalWidth(anchoColumnas)
        tComercioExterior.SpacingBefore = 5
        tComercioExterior.HorizontalAlignment = Element.ALIGN_CENTER
        tComercioExterior.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tComercioExterior.DefaultCell.BorderWidth = 1
        tComercioExterior.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("Comercio exterior", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tComercioExterior.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(comercioExterior.MotivoTraslado) Then
            tComercioExterior.AddCell(New Phrase("Motivo traslado", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.MotivoTraslado, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.MotivoTraslado) Then
            tComercioExterior.AddCell(New Phrase("Tipo de operación", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.TipoOperacion, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.ClaveDePedimento) Then
            tComercioExterior.AddCell(New Phrase("Clave de pedimento", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.ClaveDePedimento, FUENTE_MEDIANA))
        End If

        If comercioExterior.CertificadoOrigen = 0 Then
            tComercioExterior.AddCell(New Phrase("CertificadoOrgien", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.MotivoTraslado, FUENTE_MEDIANA))
        End If

        If comercioExterior.CertificadoOrigen = 1 Then
            tComercioExterior.AddCell(New Phrase("CertificadoOrgien", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.MotivoTraslado, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.NumCertificadoOrigen) Then
            tComercioExterior.AddCell(New Phrase("Núm. certificado origen", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.NumCertificadoOrigen, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.NumCertificadoOrigen) Then
            tComercioExterior.AddCell(New Phrase("Número exportador cliente", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.NumCertificadoOrigen, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.Incoterm) Then
            tComercioExterior.AddCell(New Phrase("Incoterm", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.Incoterm, FUENTE_MEDIANA))
        End If

        If comercioExterior.Subdivision = 0 Then
            tComercioExterior.AddCell(New Phrase("Subdivision", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase("No tiene subdivision", FUENTE_MEDIANA))
        End If

        If comercioExterior.Subdivision = 1 Then
            tComercioExterior.AddCell(New Phrase("Subdivision", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase("Si tiene subdivision", FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.Observaciones) Then
            tComercioExterior.AddCell(New Phrase("Observaciones", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.Observaciones, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(comercioExterior.TipoCambioUSD) Then
            tComercioExterior.AddCell(New Phrase("Tipo de cambio USD", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.TipoCambioUSD, FUENTE_MEDIANA))
        End If

        If comercioExterior.TotalUSD > 0 Then
            tComercioExterior.AddCell(New Phrase("Total USD", FUENTE_SUBTITULO))
            tComercioExterior.AddCell(New Phrase(comercioExterior.TotalUSD.ToString("F2"), FUENTE_MEDIANA))
        End If

        tComercioExterior.CompleteRow()
        documento.Add(tComercioExterior)
        CCEEmisor(documento, comercioExterior.Emisor)

        For Each item In comercioExterior.Propietario
            CCEPropietario(documento, item, Math.Min(System.Threading.Interlocked.Increment(contador), contador - 1))
        Next

        CCEReceptor(documento, comercioExterior.Receptor)
        contador = 1

        For Each item In comercioExterior.Destinario
            CCEDestinario(documento, item, Math.Min(System.Threading.Interlocked.Increment(contador), contador - 1))
        Next

        If comercioExterior.Mercancias IsNot Nothing Then
            contador = 1

            For Each item In comercioExterior.Mercancias.Mercancia
                CCEMercancia(documento, item, Math.Min(System.Threading.Interlocked.Increment(contador), contador - 1))
            Next
        End If
    End Sub

    Public Shared Sub CCEEmisor(ByVal document As Document, ByVal emisor As CCE11Emisor)
        If emisor Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tEmisor As PdfPTable = New PdfPTable(anchoColumnas)
        tEmisor.SetTotalWidth(anchoColumnas)
        tEmisor.SpacingBefore = 5
        tEmisor.HorizontalAlignment = Element.ALIGN_CENTER
        tEmisor.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tEmisor.DefaultCell.BorderWidth = 1
        tEmisor.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("EMISOR", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tEmisor.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(emisor.Curp) Then
            tEmisor.AddCell(New Phrase("CURP", FUENTE_SUBTITULO))
            tEmisor.AddCell(New Phrase(emisor.Curp, FUENTE_MEDIANA))
        End If

        If emisor.Domicilio IsNot Nothing Then
            Dim domicilio As CCE11Domicilio = emisor.Domicilio

            If Not String.IsNullOrEmpty(domicilio.Calle) Then
                tEmisor.AddCell(New Phrase("Calle", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Calle, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then
                tEmisor.AddCell(New Phrase("Numero exterior", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.NumeroExterior, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then
                tEmisor.AddCell(New Phrase("Numero interior", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.NumeroInterior, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Colonia) Then
                tEmisor.AddCell(New Phrase("Colonia", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Colonia, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Localidad) Then
                tEmisor.AddCell(New Phrase("Localidad", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Localidad, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Referencia) Then
                tEmisor.AddCell(New Phrase("Referencia", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Referencia, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Municipio) Then
                tEmisor.AddCell(New Phrase("Municipio", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Municipio, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Estado) Then
                tEmisor.AddCell(New Phrase("Estado", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Estado, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Pais) Then
                tEmisor.AddCell(New Phrase("Pais", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Pais, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then
                tEmisor.AddCell(New Phrase("CodigoPostal", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.CodigoPostal, FUENTE_MEDIANA))
            End If
        End If

        tEmisor.CompleteRow()
        document.Add(tEmisor)
    End Sub

    Public Shared Sub CCEPropietario(ByVal document As Document, ByVal propietario As CCE11Propietario, ByVal contador As Integer)
        If propietario Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tPropietario As PdfPTable = New PdfPTable(anchoColumnas)
        tPropietario.SetTotalWidth(anchoColumnas)
        tPropietario.SpacingBefore = 5
        tPropietario.HorizontalAlignment = Element.ALIGN_CENTER
        tPropietario.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tPropietario.DefaultCell.BorderWidth = 1
        tPropietario.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PROPIETARIO" & (If(contador = 1, "", contador.ToString())), FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tPropietario.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(propietario.NumRegIdTrib) Then
            tPropietario.AddCell(New Phrase("NumRegIdTrib", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(propietario.NumRegIdTrib, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(propietario.ResidenciaFiscal) Then
            tPropietario.AddCell(New Phrase("Residencia Fiscal", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(propietario.ResidenciaFiscal, FUENTE_MEDIANA))
        End If

        tPropietario.CompleteRow()
        document.Add(tPropietario)
    End Sub

    Public Shared Sub CCEReceptor(ByVal document As Document, ByVal receptor As CCE11Receptor)
        If receptor Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tEmisor As PdfPTable = New PdfPTable(anchoColumnas)
        tEmisor.SetTotalWidth(anchoColumnas)
        tEmisor.SpacingBefore = 5
        tEmisor.HorizontalAlignment = Element.ALIGN_CENTER
        tEmisor.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tEmisor.DefaultCell.BorderWidth = 1
        tEmisor.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("RECEPTOR", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tEmisor.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(receptor.NumRegIdTrib) Then
            tEmisor.AddCell(New Phrase("NumRegIdTrib", FUENTE_SUBTITULO))
            tEmisor.AddCell(New Phrase(receptor.NumRegIdTrib, FUENTE_MEDIANA))
        End If

        If receptor.Domicilio IsNot Nothing Then
            Dim domicilio As CCE11Domicilio = receptor.Domicilio

            If Not String.IsNullOrEmpty(domicilio.Calle) Then
                tEmisor.AddCell(New Phrase("Calle", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Calle, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then
                tEmisor.AddCell(New Phrase("Numero exterior", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.NumeroExterior, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then
                tEmisor.AddCell(New Phrase("Numero interior", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.NumeroInterior, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Colonia) Then
                tEmisor.AddCell(New Phrase("Colonia", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Colonia, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Localidad) Then
                tEmisor.AddCell(New Phrase("Localidad", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Localidad, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Referencia) Then
                tEmisor.AddCell(New Phrase("Referencia", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Referencia, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Municipio) Then
                tEmisor.AddCell(New Phrase("Municipio", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Municipio, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Estado) Then
                tEmisor.AddCell(New Phrase("Estado", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Estado, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.Pais) Then
                tEmisor.AddCell(New Phrase("Pais", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.Pais, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then
                tEmisor.AddCell(New Phrase("CodigoPostal", FUENTE_SUBTITULO))
                tEmisor.AddCell(New Phrase(domicilio.CodigoPostal, FUENTE_MEDIANA))
            End If
        End If

        tEmisor.CompleteRow()
        document.Add(tEmisor)
    End Sub

    Public Shared Sub CCEDestinario(ByVal document As Document, ByVal destinario As CCE11Destinario, ByVal contador As Integer)
        If destinario Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tPropietario As PdfPTable = New PdfPTable(anchoColumnas)
        tPropietario.SetTotalWidth(anchoColumnas)
        tPropietario.SpacingBefore = 5
        tPropietario.HorizontalAlignment = Element.ALIGN_CENTER
        tPropietario.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tPropietario.DefaultCell.BorderWidth = 1
        tPropietario.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DESTINARIO" & (If(contador = 1, "", contador.ToString())), FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tPropietario.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(destinario.NumRegIdTrib) Then
            tPropietario.AddCell(New Phrase("NumRegIdTrib", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(destinario.NumRegIdTrib, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(destinario.Nombre) Then
            tPropietario.AddCell(New Phrase("Nombre", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(destinario.Nombre, FUENTE_MEDIANA))
        End If

        tPropietario.CompleteRow()
        document.Add(tPropietario)
    End Sub

    Public Shared Sub CCEMercancia(ByVal document As Document, ByVal mercancia As CCE11Mercancia, ByVal contador As Integer)
        If mercancia Is Nothing Then Return
        Dim anchoColumnas As Single() = CmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tPropietario As PdfPTable = New PdfPTable(anchoColumnas)
        tPropietario.SetTotalWidth(anchoColumnas)
        tPropietario.SpacingBefore = 5
        tPropietario.HorizontalAlignment = Element.ALIGN_CENTER
        tPropietario.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tPropietario.DefaultCell.BorderWidth = 1
        tPropietario.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("MERCANCIA" & (If(contador = 1, "", contador.ToString())), FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tPropietario.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(mercancia.NoIdentificacion) Then
            tPropietario.AddCell(New Phrase("NoIdentificacion", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.NoIdentificacion, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(mercancia.FraccionArancelaria) Then
            tPropietario.AddCell(New Phrase("Fraccion Arancelaria", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.FraccionArancelaria, FUENTE_MEDIANA))
        End If

        If mercancia.CantidadAduana > 0 Then
            tPropietario.AddCell(New Phrase("Cantidad aduana", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.CantidadAduana.ToString("F2"), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(mercancia.UnidadAduana) Then
            tPropietario.AddCell(New Phrase("Unidad aduana", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.FraccionArancelaria, FUENTE_MEDIANA))
        End If

        If mercancia.ValorUnitarioAduana > 0 Then
            tPropietario.AddCell(New Phrase("Valor unitario aduana", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.ValorUnitarioAduana.ToString("F2"), FUENTE_MEDIANA))
        End If

        If mercancia.ValorDolares > 0 Then
            tPropietario.AddCell(New Phrase("Valor dolares", FUENTE_SUBTITULO))
            tPropietario.AddCell(New Phrase(mercancia.ValorDolares.ToString("F2"), FUENTE_MEDIANA))
        End If

        tPropietario.CompleteRow()
        document.Add(tPropietario)
    End Sub
#End Region
#Region "Nomina"
    Public Shared Sub N2AgregarEmisor(ByVal document As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.Nomina.Emisor Is Nothing Then comprobante.Complemento.Nomina.Emisor = New NEmisor()
        If comprobante.Complemento.Nomina.Emisor.Curp = String.Empty And comprobante.Complemento.Nomina.Emisor.RegistroPatronal = String.Empty AndAlso comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen = String.Empty Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tEmisor As PdfPTable = New PdfPTable(anchoColumnas)
        tEmisor.SetTotalWidth(anchoColumnas)
        tEmisor.SpacingBefore = 5
        tEmisor.HorizontalAlignment = Element.ALIGN_CENTER
        tEmisor.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tEmisor.DefaultCell.BorderWidth = 1
        tEmisor.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("EMISOR", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tEmisor.AddCell(cEncabezado)

        If comprobante.Complemento.Nomina.Emisor.RegistroPatronal <> String.Empty Then
            tEmisor.AddCell(New Phrase("Registro patronal", FUENTE_SUBTITULO))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.RegistroPatronal, FUENTE_MEDIANA))
        End If

        If comprobante.Complemento.Nomina.Emisor.Curp <> String.Empty Then
            tEmisor.AddCell(New Phrase("CURP", FUENTE_SUBTITULO))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.Curp, FUENTE_MEDIANA))
        End If

        If comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen <> String.Empty Then
            tEmisor.AddCell(New Phrase("RFC patrón origen", FUENTE_SUBTITULO))
            tEmisor.AddCell(New Phrase(comprobante.Complemento.Nomina.Emisor.RfcPatronOrigen, FUENTE_MEDIANA))
        End If

        tEmisor.CompleteRow()
        document.Add(tEmisor)
    End Sub

    Public Shared Function N2AgregarEmpleado(ByVal receptor As NReceptor) As PdfPTable
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F})
        Dim tDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tDatos.SetTotalWidth(anchoColumnas)
        tDatos.LockedWidth = True
        tDatos.DefaultCell.BorderColor = cBorde
        tDatos.DefaultCell.BorderWidth = 1
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("EMPLEADO", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.BorderWidth = 1
        cEncabezado.BorderColor = cBorde
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 2
        tDatos.AddCell(cEncabezado)
        tDatos.AddCell(New Phrase("Núm. de empleado", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(receptor.NumEmpleado, FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("CURP", FUENTE_SUBTITULO))
        tDatos.AddCell((New Phrase(receptor.Curp, FUENTE_MEDIANA)))

        If receptor.NumSeguridadSocial <> String.Empty Then
            tDatos.AddCell(New Phrase("Núm. Seguridad Social", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.NumSeguridadSocial, FUENTE_MEDIANA))
        End If

        tDatos.AddCell(New Phrase("Fecha de inicio de la relación laboral", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(receptor.FechaInicioRelLaboral.ToShortDateString(), FUENTE_MEDIANA))

        If receptor.Antiguedad <> String.Empty Then
            tDatos.AddCell(New Phrase("Antigüedad", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.Antiguedad, FUENTE_MEDIANA))
        End If

        tDatos.AddCell(New Phrase("Tipo de contrato", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(receptor.TipoContrato, FUENTE_MEDIANA))

        If receptor.Sindicalizado <> String.Empty Then
            tDatos.AddCell(New Phrase("Sindicalizado", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.Sindicalizado, FUENTE_MEDIANA))
        End If

        If receptor.TipoJornada <> String.Empty Then
            tDatos.AddCell(New Phrase("Tipo jornada", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.TipoJornada, FUENTE_MEDIANA))
        End If

        If receptor.TipoRegimen <> String.Empty Then
            tDatos.AddCell(New Phrase("Tipo de régimen", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.TipoRegimen, FUENTE_MEDIANA))
        End If

        If receptor.Departamento <> String.Empty Then
            tDatos.AddCell(New Phrase("Departamento", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.Departamento, FUENTE_MEDIANA))
        End If

        If receptor.Puesto <> String.Empty Then
            tDatos.AddCell(New Phrase("Puesto", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.Puesto, FUENTE_MEDIANA))
        End If

        If receptor.RiesgoPuesto <> String.Empty Then
            tDatos.AddCell(New Phrase("Riesgo de puesto", FUENTE_SUBTITULO))
            tDatos.AddCell(New Phrase(receptor.RiesgoPuesto & " - " + ObtenerRiesgoPuesto(receptor.RiesgoPuesto), FUENTE_MEDIANA))
        End If

        Return tDatos
    End Function

    Public Shared Function N2AgregarPago(ByVal nomina As Nomina) As PdfPTable
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F})
        Dim tDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tDatos.DefaultCell.BorderColor = cBorde
        tDatos.SetTotalWidth(anchoColumnas)
        tDatos.LockedWidth = True
        tDatos.DefaultCell.BorderWidth = 1
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PAGOS", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.BorderWidth = 1
        cEncabezado.BorderColor = cBorde
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 2
        tDatos.AddCell(cEncabezado)
        tDatos.AddCell(New Phrase("Tipo de nómina", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.TipoNomina & " - " + ObtenerTipoNomina(nomina.TipoNomina), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Fecha de pago", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.FechaPago.ToShortDateString(), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Fecha inicial de pago", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.FechaInicialPago.ToShortDateString(), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Fecha final pago", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.FechaFinalPago.ToShortDateString(), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Núm. de dias pagados", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.NumDiasPagados.ToString("F3"), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Salario diario integrado", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.Receptor.SalarioDiarioIntegrado.ToString("F2"), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Salario base Cot. Aport.", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.Receptor.SalarioBaseCotApor.ToString("F2"), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Periodicidad de pago", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.Receptor.PeriodicidadPago & " - " + ObtenerPeriodicidadPago(nomina.Receptor.PeriodicidadPago), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Total de percepciones", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.TotalPercepciones.ToString("C3"), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Total de deducciones", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.TotalDeducciones.ToString("C3"), FUENTE_MEDIANA))
        tDatos.AddCell(New Phrase("Total de otros pagos", FUENTE_SUBTITULO))
        tDatos.AddCell(New Phrase(nomina.TotalOtrosPagos.ToString("C3"), FUENTE_MEDIANA))
        tDatos.CompleteRow()
        Return tDatos
    End Function

    Public Shared Sub N2AgregarEmpleadoPagos(ByVal document As Document, ByVal comprobante As Comprobante)
        Dim anchoColumnas As Single() = cmAFloat(New Single() {10.0F, 10.0F})
        Dim tDatos As PdfPTable = New PdfPTable(anchoColumnas)
        tDatos.DefaultCell.Border = Rectangle.NO_BORDER
        tDatos.SetTotalWidth(anchoColumnas)
        tDatos.SpacingBefore = 5
        tDatos.HorizontalAlignment = Element.ALIGN_CENTER
        tDatos.LockedWidth = True
        tDatos.AddCell(N2AgregarEmpleado(comprobante.Complemento.Nomina.Receptor))
        tDatos.AddCell(N2AgregarPago(comprobante.Complemento.Nomina))
        document.Add(tDatos)
    End Sub

    Public Shared Sub N2AgregarPercepciones(ByVal document As Document, ByVal percepciones As NPercepciones)
        If percepciones IsNot Nothing AndAlso percepciones.Percepcion IsNot Nothing AndAlso percepciones.Percepcion.Count > 0 Then
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.5F, 4.0F, 5.5F, 3, 3})
            Dim tPercepciones As PdfPTable = New PdfPTable(anchoColumnas)
            tPercepciones.DefaultCell.BorderWidth = 1
            tPercepciones.DefaultCell.BorderColor = cBorde
            tPercepciones.SetTotalWidth(anchoColumnas)
            tPercepciones.SpacingBefore = 5
            tPercepciones.HorizontalAlignment = Element.ALIGN_CENTER
            tPercepciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PERCEPCIONES", FUENTE_SUBTITULO_BLANCO))
            cEncabezado.BorderColor = cBorde
            cEncabezado.BorderWidth = 1
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tPercepciones.AddCell(cEncabezado)
            tPercepciones.AddCell(New Phrase("Concepto", FUENTE_SUBTITULO))
            tPercepciones.AddCell(New Phrase("Clave", FUENTE_SUBTITULO))
            tPercepciones.AddCell(New Phrase("Tipo de percecepíon", FUENTE_SUBTITULO))
            tPercepciones.AddCell(New PdfPCell(New Phrase("Importe exento", FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tPercepciones.AddCell(New PdfPCell(New Phrase("Importe gravado", FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each p As NPercepcion In percepciones.Percepcion
                tPercepciones.AddCell(New Phrase(p.Concepto, FUENTE_MEDIANA))
                tPercepciones.AddCell(New Phrase(p.Clave, FUENTE_MEDIANA))
                tPercepciones.AddCell(New Phrase(p.TipoPercepcion & " - " + ObtenerTipoPercepcion(p.TipoPercepcion), FUENTE_MEDIANA))
                tPercepciones.AddCell(New PdfPCell(New Phrase(p.ImporteGravado.ToString("C2"), FUENTE_MEDIANA)) With {
                    .BorderWidth = 1,
                    .BorderColor = cBorde,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
                tPercepciones.AddCell(New PdfPCell(New Phrase(p.ImporteExento.ToString("C2"), FUENTE_MEDIANA)) With {
                    .BorderWidth = 1,
                    .BorderColor = cBorde,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            tPercepciones.AddCell("")
            tPercepciones.AddCell("")
            tPercepciones.AddCell(New Phrase("Total", FUENTE_SUBTITULO))
            tPercepciones.AddCell(New PdfPCell(New Phrase(percepciones.TotalGravado.ToString("C2"), FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tPercepciones.AddCell(New PdfPCell(New Phrase(percepciones.TotalExento.ToString("C2"), FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            document.Add(tPercepciones)
        End If
    End Sub

    Public Shared Sub N2AgregarDeducciones(ByVal document As Document, ByVal deducciones As NDeducciones)
        If deducciones IsNot Nothing AndAlso deducciones.Deduccion IsNot Nothing AndAlso deducciones.Deduccion.Count > 0 Then
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.5F, 4.0F, 8.5F, 3})
            Dim tDeducciones As PdfPTable = New PdfPTable(anchoColumnas)
            tDeducciones.DefaultCell.BorderWidth = 1
            tDeducciones.DefaultCell.BorderColor = cBorde
            tDeducciones.SetTotalWidth(anchoColumnas)
            tDeducciones.SpacingBefore = 5
            tDeducciones.HorizontalAlignment = Element.ALIGN_CENTER
            tDeducciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DEDUCCIONES", FUENTE_SUBTITULO_BLANCO))
            cEncabezado.BorderColor = cBorde
            cEncabezado.BorderWidth = 1
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tDeducciones.AddCell(cEncabezado)
            tDeducciones.AddCell(New Phrase("Concepto", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New Phrase("Clave", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New Phrase("Tipo de deducción", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each d As NDeduccion In deducciones.Deduccion
                tDeducciones.AddCell(New Phrase(d.Concepto, FUENTE_MEDIANA))
                tDeducciones.AddCell(New Phrase(d.Clave, FUENTE_MEDIANA))
                tDeducciones.AddCell(New Phrase(d.TipoDeduccion & " - " + ObtenerTipoDeduccion(d.TipoDeduccion), FUENTE_MEDIANA))
                tDeducciones.AddCell(New PdfPCell(New Phrase(d.Importe.ToString("C2"), FUENTE_MEDIANA)) With {
                    .BorderWidth = 1,
                    .BorderColor = cBorde,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            tDeducciones.AddCell("")
            tDeducciones.AddCell("")
            tDeducciones.AddCell(New Phrase("Total", FUENTE_SUBTITULO))
            Dim total As Decimal = 0
            total = deducciones.TotalImpuestosRetenidos + deducciones.TotalOtrasDeducciones
            tDeducciones.AddCell(New PdfPCell(New Phrase(total.ToString("C2"), FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            document.Add(tDeducciones)
        End If
    End Sub

    Public Shared Sub N2AgregarOtroPagos(ByVal document As Document, ByVal otrosPagos As NOtrosPagos)
        If otrosPagos IsNot Nothing AndAlso otrosPagos.OtroPago IsNot Nothing AndAlso otrosPagos.OtroPago.Count > 0 Then
            If ExisteSubsidioParaElEmpleo(otrosPagos) AndAlso otrosPagos.OtroPago.Count = 1 Then Return
            Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.5F, 4.0F, 8.5F, 3})
            Dim tDeducciones As PdfPTable = New PdfPTable(anchoColumnas)
            tDeducciones.DefaultCell.BorderWidth = 1
            tDeducciones.DefaultCell.BorderColor = cBorde
            tDeducciones.SetTotalWidth(anchoColumnas)
            tDeducciones.SpacingBefore = 5
            tDeducciones.HorizontalAlignment = Element.ALIGN_CENTER
            tDeducciones.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("OTROS PAGOS", FUENTE_SUBTITULO_BLANCO))
            cEncabezado.BorderColor = cBorde
            cEncabezado.BorderWidth = 1
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 5
            tDeducciones.AddCell(cEncabezado)
            tDeducciones.AddCell(New Phrase("Concepto", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New Phrase("Clave", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New Phrase("Tipo de deducción", FUENTE_SUBTITULO))
            tDeducciones.AddCell(New PdfPCell(New Phrase("Importe", FUENTE_SUBTITULO)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })

            For Each d As NOtroPago In otrosPagos.OtroPago
                tDeducciones.AddCell(New Phrase(d.Concepto, FUENTE_MEDIANA))
                tDeducciones.AddCell(New Phrase(d.Clave, FUENTE_MEDIANA))
                tDeducciones.AddCell(New Phrase(d.TipoOtroPago & " - " + ObtenerTipoOtroPago(d.TipoOtroPago), FUENTE_MEDIANA))
                tDeducciones.AddCell(New PdfPCell(New Phrase(d.Importe.ToString("C2"), FUENTE_MEDIANA)) With {
                    .BorderWidth = 1,
                    .BorderColor = cBorde,
                    .HorizontalAlignment = Element.ALIGN_RIGHT
                })
            Next

            document.Add(tDeducciones)
        End If
    End Sub

    Private Shared Function ExisteSubsidioParaElEmpleo(ByVal otrosPagos As NOtrosPagos) As Boolean
        Dim band As Boolean = False

        If otrosPagos IsNot Nothing Then

            For Each op As NOtroPago In otrosPagos.OtroPago
                If op.Importe = 0.01D Then Return True
            Next
        End If

        Return band
    End Function
#End Region
#Region "Carta Porte"
    Private Shared Sub AgregarDatosCartaPorte(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.CartaPorte20 Is Nothing Then Return
        Dim cartaPorte As CartaPorte = comprobante.Complemento.CartaPorte20

        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tCartaPorte As PdfPTable = New PdfPTable(anchoColumnas)
        tCartaPorte.SetTotalWidth(anchoColumnas)
        tCartaPorte.SpacingBefore = 5
        tCartaPorte.HorizontalAlignment = Element.ALIGN_CENTER
        tCartaPorte.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tCartaPorte.DefaultCell.BorderWidth = 1
        tCartaPorte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CARTA PORTE " & cartaPorte.Version.ToUpper(), FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tCartaPorte.AddCell(cEncabezado)
        tCartaPorte.AddCell(New Phrase("Transporte internacional", FUENTE_SUBTITULO))
        tCartaPorte.AddCell(New Phrase(cartaPorte.TranspInternac, FUENTE_MEDIANA))

        If Not String.IsNullOrEmpty(cartaPorte.EntradaSalidaMerc) Then
            tCartaPorte.AddCell(New Phrase("Entrada-Salida mercancías", FUENTE_SUBTITULO))
            tCartaPorte.AddCell(New Phrase(cartaPorte.PaisOrigenDestino, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.PaisOrigenDestino) Then
            tCartaPorte.AddCell(New Phrase("Pais origen o destino", FUENTE_SUBTITULO))
            tCartaPorte.AddCell(New Phrase(cartaPorte.PaisOrigenDestino, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(cartaPorte.ViaEntradaSalida) Then
            tCartaPorte.AddCell(New Phrase("Vía entrada o salida", FUENTE_SUBTITULO))
            tCartaPorte.AddCell(New Phrase(cartaPorte.ViaEntradaSalida, FUENTE_MEDIANA))
        End If

        If cartaPorte.TotalDistRec > 0 Then
            tCartaPorte.AddCell(New Phrase("Total distancia recorrida", FUENTE_SUBTITULO))
            tCartaPorte.AddCell(New Phrase(cartaPorte.TotalDistRec.ToString() & " k.m.", FUENTE_MEDIANA))
        End If

        tCartaPorte.CompleteRow()
        documento.Add(tCartaPorte)
    End Sub

    Private Shared Function AgregarConceptosCartaPorte(ByVal comprobante As Comprobante) As IElement
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        FUENTE_NORMAL_BOLD.Size = 8
        Dim tamanoColumnas As Single() = cmAFloat(New Single() {1.4F, 2.4F, 2.4F, 9.0F, 2.4F, 2.4F})
        Dim tablaProductos As PdfPTable = New PdfPTable(tamanoColumnas)
        tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
        tablaProductos.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE
        tablaProductos.DefaultCell.BorderColor = cBorde
        tablaProductos.SpacingBefore = 10
        tablaProductos.DefaultCell.BackgroundColor = BaseColor.BLACK
        tablaProductos.LockedWidth = True
        tablaProductos.SetTotalWidth(tamanoColumnas)
        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("CONCEPTOS", FUENTE_SUBTITULO_BLANCO)) With {
            .BackgroundColor = BaseColor.BLACK
        }
        ctitulo.UseAscender = True
        ctitulo.BorderColor = cBorde
        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
        ctitulo.VerticalAlignment = Element.ALIGN_MIDDLE
        ctitulo.BorderWidth = 1.0F
        ctitulo.Colspan = 6
        tablaProductos.AddCell(ctitulo)
        tablaProductos.AddCell(New Phrase("Cantidad", FUENTE_SUBTITULO_BLANCO))
        tablaProductos.AddCell(New PdfPCell(New Phrase("Unidad", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BorderColor = cBorde,
            .BackgroundColor = BaseColor.BLACK,
            .HorizontalAlignment = Element.ALIGN_CENTER
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase("No. Identificación", FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BorderColor = cBorde,
            .BackgroundColor = BaseColor.BLACK,
            .HorizontalAlignment = Element.ALIGN_CENTER
        })
        tablaProductos.AddCell(New Phrase("Descripcion", FUENTE_SUBTITULO_BLANCO))

        Dim Impr1 As String, Impr2 As String

        If CP_IMPRIME_IMPORTES Then
            Impr1 = "Precio Unitario"
            Impr2 = "Importe"
        Else
            Impr1 = ""
            Impr2 = ""
        End If
        tablaProductos.AddCell(New PdfPCell(New Phrase(Impr1, FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BackgroundColor = BaseColor.BLACK,
            .BorderColor = cBorde,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })
        tablaProductos.AddCell(New PdfPCell(New Phrase(Impr2, FUENTE_SUBTITULO_BLANCO)) With {
            .BorderWidth = 1,
            .BackgroundColor = BaseColor.BLACK,
            .BorderColor = cBorde,
            .HorizontalAlignment = Element.ALIGN_RIGHT
        })

        For Each concepto As Concepto In comprobante.Conceptos.Concepto
            Dim descripcion As StringBuilder = New StringBuilder()
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.Cantidad.ToString("F2"), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_RIGHT
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.ClaveUnidad & " - " + ObtenerUnidad(concepto.ClaveUnidad), FUENTE_NORMAL)) With {
                .BorderWidth = 1,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(concepto.NoIdentificacion, FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_CENTER
            })
            descripcion.Append(concepto.Descripcion & vbLf & vbLf & "Clave Prod. Serv. " + concepto.ClaveProdServ & vbLf)

            If CP_IMPRIME_IMPORTES Then
                If concepto.Impuestos IsNot Nothing Then
                    descripcion.Append("Impuestos:" & vbLf)

                    If concepto.Impuestos.Traslados.Count > 0 Then
                        descripcion.Append("  Traslados:" & vbLf)

                        For Each t As TrasladoC In concepto.Impuestos.Traslados
                            descripcion.Append("    " & t.Impuesto & " " + ObtenerImpuesto(t.Impuesto) & " Base - " + t.Base.ToString("C2") & " Tasa - " + t.TasaOCuota.ToString("F6") & " Importe - " + t.Importe.ToString("C2") & vbLf)
                        Next
                    End If
                End If
            End If

            tablaProductos.AddCell(New PdfPCell(New Phrase(descripcion.ToString(), FUENTE_NORMAL)) With {
                .BorderWidth = 1.0F,
                .BorderColor = cBorde,
                .HorizontalAlignment = Element.ALIGN_LEFT
            })

            If CP_IMPRIME_IMPORTES Then
                Impr1 = concepto.ValorUnitario.ToString("C")
                Impr2 = concepto.Importe.ToString("C")
            Else
                Impr1 = ""
                Impr2 = ""
            End If

            tablaProductos.AddCell(New PdfPCell(New Phrase(Impr1, FUENTE_NORMAL)) With {
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .BorderColor = cBorde,
                .BorderWidth = 1
            })
            tablaProductos.AddCell(New PdfPCell(New Phrase(Impr2, FUENTE_NORMAL)) With {
                .HorizontalAlignment = Element.ALIGN_RIGHT,
                .BorderColor = cBorde,
                .BorderWidth = 1
            })
        Next

        Return tablaProductos
    End Function

    Private Shared Sub AgregarUbicaciones(ByVal documento As Document, ByVal comprobante As Comprobante)
        If comprobante.Complemento.CartaPorte20.Ubicaciones Is Nothing Then Return
        Dim contador As Integer = 0

        For Each ubicacion1 In comprobante.Complemento.CartaPorte20.Ubicaciones.Ubicacion
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tTipoFigura As PdfPTable = New PdfPTable(anchoColumnas)
            tTipoFigura.SetTotalWidth(anchoColumnas)
            tTipoFigura.SpacingBefore = 5
            tTipoFigura.HorizontalAlignment = Element.ALIGN_CENTER
            tTipoFigura.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tTipoFigura.DefaultCell.BorderWidth = 1
            tTipoFigura.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("UBICACIÓN " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTipoFigura.AddCell(cEncabezado)
            tTipoFigura.AddCell(New Phrase("Tipo de ubicación", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(ubicacion1.TipoUbicacion, FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(ubicacion1.IDUbicacion) Then
                tTipoFigura.AddCell(New Phrase("ID ubicación", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.IDUbicacion, FUENTE_MEDIANA))
            End If

            tTipoFigura.AddCell(New Phrase("R.F.C del " & (If(ubicacion1.TipoUbicacion = "Origen", "remitente", "destinario")), FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(ubicacion1.RFCRemitenteDestinatario, FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(ubicacion1.NombreRemitenteDestinatario) Then
                tTipoFigura.AddCell(New Phrase("Número del " & (If(ubicacion1.TipoUbicacion = "Origen", "remitente", "destinario")), FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.NombreRemitenteDestinatario, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(ubicacion1.NumRegIdTrib) Then
                tTipoFigura.AddCell(New Phrase("Núm. Reg. Id. Trib.", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.NumRegIdTrib, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(ubicacion1.ResidenciaFiscal) Then
                tTipoFigura.AddCell(New Phrase("Residencia fiscal", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.ResidenciaFiscal, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(ubicacion1.NumEstacion) Then
                tTipoFigura.AddCell(New Phrase("Número de estación", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.NumEstacion, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(ubicacion1.NombreEstacion) Then
                tTipoFigura.AddCell(New Phrase("Nombre de estación", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.NombreEstacion, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(ubicacion1.NavegacionTrafico) Then
                tTipoFigura.AddCell(New Phrase("Tipo de puerto de " & ubicacion1.TipoUbicacion.ToLower(), FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.NavegacionTrafico, FUENTE_MEDIANA))
            End If

            tTipoFigura.AddCell(New Phrase("Fecha", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(ubicacion1.FechaHoraSalidaLlegada.ToString("s"), FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(ubicacion1.TipoEstacion) Then
                tTipoFigura.AddCell(New Phrase("Tipo de estación", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.TipoEstacion & " " + ObtenerTipoEstacion(ubicacion1.TipoEstacion), FUENTE_MEDIANA))
            End If

            If ubicacion1.DistanciaRecorrida > 0 Then
                tTipoFigura.AddCell(New Phrase("Distancia recorrida", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(ubicacion1.DistanciaRecorrida.ToString("f2"), FUENTE_MEDIANA))
            End If

            If contador.ToString() = "1" Then
                tTipoFigura.AddCell(New Phrase("Recoger En", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(CP_RECOGER_EN, FUENTE_MEDIANA))
            Else
                tTipoFigura.AddCell(New Phrase("Entregar En", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(CP_ENTREGAR_EN, FUENTE_MEDIANA))
            End If

            tTipoFigura.CompleteRow()
            documento.Add(tTipoFigura)
            AgregarDomicilio(documento, ubicacion1.Domicilio)
        Next
    End Sub

    Private Shared Sub AgregarFiguraTransporte(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim contador As Integer = 0

        For Each tipoFigura In comprobante.Complemento.CartaPorte20.FiguraTransporte.TiposFigura
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tTipoFigura As PdfPTable = New PdfPTable(anchoColumnas)
            tTipoFigura.SetTotalWidth(anchoColumnas)
            tTipoFigura.SpacingBefore = 5
            tTipoFigura.HorizontalAlignment = Element.ALIGN_CENTER
            tTipoFigura.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tTipoFigura.DefaultCell.BorderWidth = 1
            tTipoFigura.LockedWidth = True

            If contador = 1 Then
                Dim cTiposFigura As PdfPCell = New PdfPCell(New Phrase("FIGURAS DE TRANSPORTE", FUENTE_SUBTITULO_BLANCO)) With {
                    .BackgroundColor = BaseColor.BLACK
                }
                cTiposFigura.UseAscender = True
                cTiposFigura.BorderColor = cBorde
                cTiposFigura.HorizontalAlignment = Element.ALIGN_CENTER
                cTiposFigura.VerticalAlignment = Element.ALIGN_MIDDLE
                cTiposFigura.BorderWidth = 1.0F
                cTiposFigura.Colspan = 4
                tTipoFigura.AddCell(cTiposFigura)
            End If

            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TIPO DE FIGURA " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.BorderColor = cBorde
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTipoFigura.AddCell(cEncabezado)
            tTipoFigura.AddCell(New Phrase("Tipo de figura", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(tipoFigura.TipoFigura, FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(tipoFigura.RFCFigura) Then
                tTipoFigura.AddCell(New Phrase("R.F.C", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(tipoFigura.RFCFigura, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NumLicencia) Then
                tTipoFigura.AddCell(New Phrase("Número de licencia", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NumLicencia, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NombreFigura) Then
                tTipoFigura.AddCell(New Phrase("Nombre de figura", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NombreFigura, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.NumRegIdTribFigura) Then
                tTipoFigura.AddCell(New Phrase("Núm. Reg. Id. Trib.", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(tipoFigura.NumRegIdTribFigura, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(tipoFigura.ResidenciaFiscalFigura) Then
                tTipoFigura.AddCell(New Phrase("Residencia fiscal", FUENTE_SUBTITULO))
                tTipoFigura.AddCell(New Phrase(tipoFigura.ResidenciaFiscalFigura, FUENTE_MEDIANA))
            End If
            tTipoFigura.CompleteRow()
            documento.Add(tTipoFigura)
            AgregarPartesTransporte(documento, tipoFigura)
            AgregarDomicilio(documento, tipoFigura.Domicilio)

        Next
    End Sub
    Private Shared Sub CP_AgregarTransporte(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim cBorde As BaseColor = New BaseColor(241, 241, 241)
        Dim contador As Integer = 0

        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tTipoFigura As PdfPTable = New PdfPTable(anchoColumnas)

        tTipoFigura.SetTotalWidth(anchoColumnas)
        tTipoFigura.SpacingBefore = 5
        tTipoFigura.HorizontalAlignment = Element.ALIGN_CENTER
        tTipoFigura.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tTipoFigura.DefaultCell.BorderWidth = 1
        tTipoFigura.LockedWidth = True

        If contador = 1 Then
            Dim cTiposFigura As PdfPCell = New PdfPCell(New Phrase("UNIDADES", FUENTE_SUBTITULO_BLANCO)) With {
                    .BackgroundColor = BaseColor.BLACK
                }
            cTiposFigura.UseAscender = True
            cTiposFigura.BorderColor = cBorde
            cTiposFigura.HorizontalAlignment = Element.ALIGN_CENTER
            cTiposFigura.VerticalAlignment = Element.ALIGN_MIDDLE
            cTiposFigura.BorderWidth = 1.0F
            cTiposFigura.Colspan = 4
            tTipoFigura.AddCell(cTiposFigura)
        End If

        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("UNIDADES", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.BorderColor = cBorde
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTipoFigura.AddCell(cEncabezado)

        tTipoFigura.AddCell(New Phrase("Unidad", FUENTE_SUBTITULO))
        tTipoFigura.AddCell(New Phrase(CP_TRACTOR, FUENTE_MEDIANA))

        If Not String.IsNullOrEmpty(CP_PLACAS_TRACTOR) Then
            tTipoFigura.AddCell(New Phrase("Placas tractocamión", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_PLACAS_TRACTOR, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(CP_TANQUE1) Then
            tTipoFigura.AddCell(New Phrase("Tanque 1", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_TANQUE1, FUENTE_MEDIANA))
        End If
        If Not String.IsNullOrEmpty(CP_PLACAS_TANQUE1) Then
            tTipoFigura.AddCell(New Phrase("Placas tanque 1", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_PLACAS_TANQUE1, FUENTE_MEDIANA))
        End If


        If Not String.IsNullOrEmpty(CP_TANQUE2) Then
            tTipoFigura.AddCell(New Phrase("Tanque 2", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_TANQUE2, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(CP_PLACAS_TANQUE2) Then
            tTipoFigura.AddCell(New Phrase("Placas tanque 2", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_PLACAS_TANQUE2, FUENTE_MEDIANA))
        End If


        If Not String.IsNullOrEmpty(CP_POLIZAMEDAMBIENTE) Then
            tTipoFigura.AddCell(New Phrase("Poliza med. ambiente", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_POLIZAMEDAMBIENTE, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(CP_ASEGURAMEDAMBIENTE) Then
            tTipoFigura.AddCell(New Phrase("Asegura med. ambiente", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_ASEGURAMEDAMBIENTE, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(CP_POLIZARESPCIVIL) Then
            tTipoFigura.AddCell(New Phrase("Poliza resp. civil", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_POLIZARESPCIVIL, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(CP_ASEGURARESPCIVIL) Then
            tTipoFigura.AddCell(New Phrase("Asegura resp civil", FUENTE_SUBTITULO))
            tTipoFigura.AddCell(New Phrase(CP_ASEGURARESPCIVIL, FUENTE_MEDIANA))
        End If

        tTipoFigura.AddCell(New Phrase(" ", FUENTE_SUBTITULO))
        tTipoFigura.AddCell(New Phrase(" ", FUENTE_MEDIANA))


        documento.Add(tTipoFigura)
    End Sub
    Private Shared Sub AgregarPartesTransporte(ByVal documento As Document, ByVal tipoFigura As TiposFigura)
        Dim contador As Integer = 0

        For Each parteTransporte In tipoFigura.PartesTransporte
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 10.0F})
            Dim tParteTransporte As PdfPTable = New PdfPTable(anchoColumnas)
            tParteTransporte.SetTotalWidth(anchoColumnas)
            tParteTransporte.SpacingBefore = 5
            tParteTransporte.HorizontalAlignment = Element.ALIGN_CENTER
            tParteTransporte.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tParteTransporte.DefaultCell.BorderWidth = 1
            tParteTransporte.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PARTE DE TRANSPORTE " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 3
            tParteTransporte.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(parteTransporte.ParteTransporte) Then
                tParteTransporte.AddCell(New Phrase("Parte transporte", FUENTE_SUBTITULO))
                tParteTransporte.AddCell(New Phrase(parteTransporte.ParteTransporte, FUENTE_MEDIANA))
            End If
            tParteTransporte.CompleteRow()
            documento.Add(tParteTransporte)


        Next
    End Sub

    Private Shared Sub AgregarMercancias(ByVal documento As Document, ByVal comprobante As Comprobante)
        Dim mercancias As Mercancias = comprobante.Complemento.CartaPorte20.Mercancias

        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tMercancias As PdfPTable = New PdfPTable(anchoColumnas)
        tMercancias.SetTotalWidth(anchoColumnas)
        tMercancias.SpacingBefore = 5
        tMercancias.HorizontalAlignment = Element.ALIGN_CENTER
        tMercancias.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tMercancias.DefaultCell.BorderWidth = 1
        tMercancias.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("MERCANCIAS", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tMercancias.AddCell(cEncabezado)
        tMercancias.AddCell(New Phrase("Peso bruto total", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(mercancias.PesoBrutoTotal.ToString("f3"), FUENTE_MEDIANA))
        tMercancias.AddCell(New Phrase("Unidad de peso", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(mercancias.UnidadPeso, FUENTE_MEDIANA))

        If mercancias.PesoNetoTotal > 0 Then
            tMercancias.AddCell(New Phrase("Peso neto total", FUENTE_SUBTITULO))
            tMercancias.AddCell(New Phrase(mercancias.PesoNetoTotal.ToString("F3"), FUENTE_MEDIANA))
        End If

        tMercancias.AddCell(New Phrase("Número total de mercancias", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(mercancias.NumTotalMercancias.ToString(), FUENTE_MEDIANA))

        If mercancias.CargoPorTasacion > 0 Then
            tMercancias.AddCell(New Phrase("Cargo por tasacion", FUENTE_SUBTITULO))
            tMercancias.AddCell(New Phrase(mercancias.CargoPorTasacion.ToString(), FUENTE_MEDIANA))
        End If

        tMercancias.AddCell(New Phrase("Orden de ", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(CP_ORDEN_DE, FUENTE_SUBTITULO))

        tMercancias.AddCell(New Phrase("Embarque ", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(CP_EMBARQUE, FUENTE_SUBTITULO))

        tMercancias.AddCell(New Phrase("Pedimento", FUENTE_SUBTITULO))
        tMercancias.AddCell(New Phrase(CP_PEDIMENTO, FUENTE_SUBTITULO))

        tMercancias.CompleteRow()
        documento.Add(tMercancias)
        AgregarMercancia(documento, mercancias)
        AgregarAutoTransporte(documento, mercancias)
        AgregarTransporteMaritimo(documento, mercancias.TransporteMaritimo)
        AgregarTransporteAereo(documento, mercancias.TransporteAereo)
        'AgregarTransporteFerroviario(documento, mercancias.TransporteFerroviario)
    End Sub

    Private Shared Sub AgregarMercancia(ByVal documento As Document, ByVal mercancias As Mercancias)
        Dim contador As Integer = 0

        For Each mercancia In mercancias.Mercancia
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tMercancia As PdfPTable = New PdfPTable(anchoColumnas)
            tMercancia.SetTotalWidth(anchoColumnas)
            tMercancia.SpacingBefore = 5
            tMercancia.HorizontalAlignment = Element.ALIGN_CENTER
            tMercancia.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tMercancia.DefaultCell.BorderWidth = 1
            tMercancia.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("MERCANCIA " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tMercancia.AddCell(cEncabezado)
            tMercancia.AddCell(New Phrase("Bienes transportados", FUENTE_SUBTITULO))
            tMercancia.AddCell(New Phrase(mercancia.BienesTransp, FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(mercancia.ClaveSTCC) Then
                tMercancia.AddCell(New Phrase("Clave STTC", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.ClaveSTCC, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.Descripcion) Then
                tMercancia.AddCell(New Phrase("Descripción", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Descripcion, FUENTE_MEDIANA))
            End If

            If mercancia.Cantidad > 0 Then
                tMercancia.AddCell(New Phrase("Cantidad", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Cantidad.ToString("F6"), FUENTE_MEDIANA))
            End If

            tMercancia.AddCell(New Phrase("Clave de unidad", FUENTE_SUBTITULO))
            tMercancia.AddCell(New Phrase(mercancia.ClaveUnidad & " - " + ObtenerUnidad(mercancia.ClaveUnidad), FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(mercancia.Unidad) Then
                tMercancia.AddCell(New Phrase("Unidad", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Unidad, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.Dimensiones) Then
                tMercancia.AddCell(New Phrase("Dimensiones", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Dimensiones, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.MaterialPeligroso) Then
                tMercancia.AddCell(New Phrase("Material peligroso", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.MaterialPeligroso, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.CveMaterialPeligroso) Then
                tMercancia.AddCell(New Phrase("Clave material peligroso", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.CveMaterialPeligroso, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.Embalaje) Then
                tMercancia.AddCell(New Phrase("Embalaje", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Embalaje, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.DescripEmbalaje) Then
                tMercancia.AddCell(New Phrase("Descripción embalaje", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.DescripEmbalaje, FUENTE_MEDIANA))
            End If

            tMercancia.AddCell(New Phrase("Peso en kg", FUENTE_SUBTITULO))
            tMercancia.AddCell(New Phrase(mercancia.PesoEnKg.ToString("F3"), FUENTE_MEDIANA))

            If mercancia.ValorMercancia > 0 Then
                tMercancia.AddCell(New Phrase("Valor mercancia", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.ValorMercancia.ToString("F2"), FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.Moneda) Then
                tMercancia.AddCell(New Phrase("Moneda", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.Moneda, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.FraccionArancelaria) Then
                tMercancia.AddCell(New Phrase("Fraccion arancelaria", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.FraccionArancelaria, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(mercancia.UUIDComercioExt) Then
                tMercancia.AddCell(New Phrase("UUID comercio exterior", FUENTE_SUBTITULO))
                tMercancia.AddCell(New Phrase(mercancia.UUIDComercioExt, FUENTE_MEDIANA))
            End If

            tMercancia.CompleteRow()
            documento.Add(tMercancia)
            AgregarPedimentos(documento, mercancia)
            AgregarGuiasIdentificacion(documento, mercancia)
            AgregarCantidadTransporta(documento, mercancia)
            AgregarDetalleMercancia(documento, mercancia)
        Next
    End Sub

    Private Shared Sub AgregarPedimentos(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each pedimento In mercancia.Pedimentos
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tPedimentos As PdfPTable = New PdfPTable(anchoColumnas)
            tPedimentos.SetTotalWidth(anchoColumnas)
            tPedimentos.SpacingBefore = 5
            tPedimentos.HorizontalAlignment = Element.ALIGN_CENTER
            tPedimentos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tPedimentos.DefaultCell.BorderWidth = 1
            tPedimentos.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("PEDIMENTOS " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tPedimentos.AddCell(cEncabezado)
            tPedimentos.AddCell(New Phrase("Pedimento", FUENTE_SUBTITULO))
            tPedimentos.AddCell(New Phrase(pedimento.Pedimento, FUENTE_MEDIANA))
            documento.Add(tPedimentos)
        Next
    End Sub

    Private Shared Sub AgregarGuiasIdentificacion(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each guiaIdentificacion In mercancia.GuiasIdentificacion
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tPedimentos As PdfPTable = New PdfPTable(anchoColumnas)
            tPedimentos.SetTotalWidth(anchoColumnas)
            tPedimentos.SpacingBefore = 5
            tPedimentos.HorizontalAlignment = Element.ALIGN_CENTER
            tPedimentos.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tPedimentos.DefaultCell.BorderWidth = 1
            tPedimentos.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("GUÍA IDENTIFICACIÓN" & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tPedimentos.AddCell(cEncabezado)
            tPedimentos.AddCell(New Phrase("Número de guía", FUENTE_SUBTITULO))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.NumeroGuiaIdentificacion, FUENTE_MEDIANA))
            tPedimentos.AddCell(New Phrase("Descripción", FUENTE_SUBTITULO))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.DescripGuiaIdentificacion, FUENTE_MEDIANA))
            tPedimentos.AddCell(New Phrase("Peso del paquete", FUENTE_SUBTITULO))
            tPedimentos.AddCell(New Phrase(guiaIdentificacion.PesoGuiaIdentificacion.ToString("F3"), FUENTE_MEDIANA))
            documento.Add(tPedimentos)
        Next
    End Sub

    Private Shared Sub AgregarCantidadTransporta(ByVal documento As Document, ByVal mercancia As Mercancia)
        Dim contador As Integer = 0

        For Each cantidadTransporta In mercancia.CantidadTransporta
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tCantidadTransporta As PdfPTable = New PdfPTable(anchoColumnas)
            tCantidadTransporta.SetTotalWidth(anchoColumnas)
            tCantidadTransporta.SpacingBefore = 5
            tCantidadTransporta.HorizontalAlignment = Element.ALIGN_CENTER
            tCantidadTransporta.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tCantidadTransporta.DefaultCell.BorderWidth = 1
            tCantidadTransporta.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CANTIDAD TRANSPORTA " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tCantidadTransporta.AddCell(cEncabezado)
            tCantidadTransporta.AddCell(New Phrase("Cantidad", FUENTE_SUBTITULO))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.Cantidad.ToString("F6"), FUENTE_MEDIANA))
            tCantidadTransporta.AddCell(New Phrase("ID origen", FUENTE_SUBTITULO))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.IDOrigen, FUENTE_MEDIANA))
            tCantidadTransporta.AddCell(New Phrase("Id destino", FUENTE_SUBTITULO))
            tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.IDDestino, FUENTE_MEDIANA))

            If Not String.IsNullOrEmpty(cantidadTransporta.CvesTransporte) Then
                tCantidadTransporta.AddCell(New Phrase("Clave transporte", FUENTE_SUBTITULO))
                tCantidadTransporta.AddCell(New Phrase(cantidadTransporta.CvesTransporte & " - " + ObtenerCveTransporte(cantidadTransporta.CvesTransporte), FUENTE_MEDIANA))
            End If

            tCantidadTransporta.CompleteRow()
            documento.Add(tCantidadTransporta)
        Next
    End Sub

    Private Shared Sub AgregarDetalleMercancia(ByVal documento As Document, ByVal mercancia As Mercancia)
        If mercancia.DetalleMercancia Is Nothing Then Return
        Dim detalle As DetalleMercancia = mercancia.DetalleMercancia
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tDetalleMercancia As PdfPTable = New PdfPTable(anchoColumnas)
        tDetalleMercancia.SetTotalWidth(anchoColumnas)
        tDetalleMercancia.SpacingBefore = 5
        tDetalleMercancia.HorizontalAlignment = Element.ALIGN_CENTER
        tDetalleMercancia.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tDetalleMercancia.DefaultCell.BorderWidth = 1
        tDetalleMercancia.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DETALLE MERCANCIA", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tDetalleMercancia.AddCell(cEncabezado)
        tDetalleMercancia.AddCell(New Phrase("Unidad peso", FUENTE_SUBTITULO))
        tDetalleMercancia.AddCell(New Phrase(detalle.UnidadPesoMerc, FUENTE_MEDIANA))
        tDetalleMercancia.AddCell(New Phrase("Peso bruto", FUENTE_SUBTITULO))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoBruto.ToString("F3"), FUENTE_MEDIANA))
        tDetalleMercancia.AddCell(New Phrase("Peso neto", FUENTE_SUBTITULO))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoNeto.ToString("F3"), FUENTE_MEDIANA))
        tDetalleMercancia.AddCell(New Phrase("Peso tara", FUENTE_SUBTITULO))
        tDetalleMercancia.AddCell(New Phrase(detalle.PesoTara.ToString("F3"), FUENTE_MEDIANA))

        If detalle.NumPiezas > 0 Then
            tDetalleMercancia.AddCell(New Phrase("Número de piezas", FUENTE_SUBTITULO))
            tDetalleMercancia.AddCell(New Phrase(detalle.NumPiezas.ToString(), FUENTE_MEDIANA))
        End If

        tDetalleMercancia.CompleteRow()
        documento.Add(tDetalleMercancia)
    End Sub

    Private Shared Sub AgregarDomicilio(ByVal documento As Document, ByVal domicilio As Domicilio)
        If domicilio Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tDomicilio As PdfPTable = New PdfPTable(anchoColumnas)
        tDomicilio.SetTotalWidth(anchoColumnas)
        tDomicilio.SpacingBefore = 5
        tDomicilio.HorizontalAlignment = Element.ALIGN_CENTER
        tDomicilio.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tDomicilio.DefaultCell.BorderWidth = 1
        tDomicilio.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DOMICILIO", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tDomicilio.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(domicilio.Calle) Then
            tDomicilio.AddCell(New Phrase("Calle", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Calle, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.NumeroExterior) Then
            tDomicilio.AddCell(New Phrase("Número exterior", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.NumeroExterior, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.NumeroInterior) Then
            tDomicilio.AddCell(New Phrase("Número interior", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.NumeroInterior, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Colonia) Then
            tDomicilio.AddCell(New Phrase("Colonia", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Colonia, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Localidad) Then
            tDomicilio.AddCell(New Phrase("Localidad", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Localidad, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Referencia) Then
            tDomicilio.AddCell(New Phrase("Referencia", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Referencia, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Municipio) Then
            tDomicilio.AddCell(New Phrase("Municipio", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Municipio, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Estado) Then
            tDomicilio.AddCell(New Phrase("Estado", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Estado, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.Pais) Then
            tDomicilio.AddCell(New Phrase("Pais", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.Pais, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(domicilio.CodigoPostal) Then
            tDomicilio.AddCell(New Phrase("Código postal", FUENTE_SUBTITULO))
            tDomicilio.AddCell(New Phrase(domicilio.CodigoPostal, FUENTE_MEDIANA))
        End If

        tDomicilio.CompleteRow()
        documento.Add(tDomicilio)
    End Sub

    Private Shared Sub AgregarAutoTransporte(ByVal documento As Document, ByVal mercancias As Mercancias)
        If mercancias.Autotransporte Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tAutoTransporte As PdfPTable = New PdfPTable(anchoColumnas)
        tAutoTransporte.SetTotalWidth(anchoColumnas)
        tAutoTransporte.SpacingBefore = 5
        tAutoTransporte.HorizontalAlignment = Element.ALIGN_CENTER
        tAutoTransporte.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tAutoTransporte.DefaultCell.BorderWidth = 1
        tAutoTransporte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("AUTOTRANSPORTE", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tAutoTransporte.AddCell(cEncabezado)
        tAutoTransporte.AddCell(New Phrase("Permiso SCT", FUENTE_SUBTITULO))
        tAutoTransporte.AddCell(New Phrase(mercancias.Autotransporte.PermSCT & " - " + ObtenerTipoPermiso(mercancias.Autotransporte.PermSCT), FUENTE_MEDIANA))
        tAutoTransporte.AddCell(New Phrase("Núm permiso SCT", FUENTE_SUBTITULO))
        tAutoTransporte.AddCell(New Phrase(mercancias.Autotransporte.NumPermisoSCT, FUENTE_MEDIANA))
        documento.Add(tAutoTransporte)
        AgregarIdentificacionVehicular(documento, mercancias.Autotransporte)
        AgregarSeguros(documento, mercancias.Autotransporte)
        AgregarRemolques(documento, mercancias.Autotransporte.Remolques)
    End Sub

    Private Shared Sub AgregarIdentificacionVehicular(ByVal documento As Document, ByVal autotransporte As Autotransporte)
        If autotransporte.IdentificacionVehicular Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tAutoTransporte As PdfPTable = New PdfPTable(anchoColumnas)
        tAutoTransporte.SetTotalWidth(anchoColumnas)
        tAutoTransporte.SpacingBefore = 5
        tAutoTransporte.HorizontalAlignment = Element.ALIGN_CENTER
        tAutoTransporte.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tAutoTransporte.DefaultCell.BorderWidth = 1
        tAutoTransporte.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("IDENTIFICACIÓN VEHICULAR", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tAutoTransporte.AddCell(cEncabezado)
        tAutoTransporte.AddCell(New Phrase("Clave autotransporte", FUENTE_SUBTITULO))
        tAutoTransporte.AddCell(New Phrase(autotransporte.IdentificacionVehicular.ConfigVehicular & " - " + ObtenerConfigAutotransporte(autotransporte.IdentificacionVehicular.ConfigVehicular), FUENTE_MEDIANA))
        tAutoTransporte.AddCell(New Phrase("Placa", FUENTE_SUBTITULO))
        tAutoTransporte.AddCell(New Phrase(autotransporte.IdentificacionVehicular.PlacaVM, FUENTE_MEDIANA))
        tAutoTransporte.AddCell(New Phrase("Año", FUENTE_SUBTITULO))
        tAutoTransporte.AddCell(New Phrase(autotransporte.IdentificacionVehicular.AnioModeloVM.ToString(), FUENTE_MEDIANA))
        documento.Add(tAutoTransporte)
    End Sub

    Private Shared Sub AgregarSeguros(ByVal documento As Document, ByVal autotransporte As Autotransporte)
        If autotransporte.Seguros Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tSeguros As PdfPTable = New PdfPTable(anchoColumnas)
        tSeguros.SetTotalWidth(anchoColumnas)
        tSeguros.SpacingBefore = 5
        tSeguros.HorizontalAlignment = Element.ALIGN_CENTER
        tSeguros.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tSeguros.DefaultCell.BorderWidth = 1
        tSeguros.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("SEGUROS", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tSeguros.AddCell(cEncabezado)
        tSeguros.AddCell(New Phrase("Nombre aseguradora civil", FUENTE_SUBTITULO))
        tSeguros.AddCell(New Phrase(autotransporte.Seguros.AseguraRespCivil, FUENTE_MEDIANA))
        tSeguros.AddCell(New Phrase("Número poliza aseguradora civil", FUENTE_SUBTITULO))
        tSeguros.AddCell(New Phrase(autotransporte.Seguros.PolizaRespCivil, FUENTE_MEDIANA))

        If Not String.IsNullOrEmpty(autotransporte.Seguros.AseguraMedAmbiente) Then
            tSeguros.AddCell(New Phrase("Nombre aseguradora medio ambiente", FUENTE_SUBTITULO))
            tSeguros.AddCell(New Phrase(autotransporte.Seguros.AseguraMedAmbiente, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(autotransporte.Seguros.PolizaMedAmbiente) Then
            tSeguros.AddCell(New Phrase("Número poloza aseguradora medio ambiente", FUENTE_SUBTITULO))
            tSeguros.AddCell(New Phrase(autotransporte.Seguros.PolizaMedAmbiente, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(autotransporte.Seguros.AseguraCarga) Then
            tSeguros.AddCell(New Phrase("Nombre aseguradora carga", FUENTE_SUBTITULO))
            tSeguros.AddCell(New Phrase(autotransporte.Seguros.AseguraCarga, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(autotransporte.Seguros.PolizaCarga) Then
            tSeguros.AddCell(New Phrase("Número poliza aseguradora carga", FUENTE_SUBTITULO))
            tSeguros.AddCell(New Phrase(autotransporte.Seguros.PolizaCarga, FUENTE_MEDIANA))
        End If

        If autotransporte.Seguros.PrimaSeguro > 0 Then
            tSeguros.AddCell(New Phrase("Valor importe asegurado", FUENTE_SUBTITULO))
            tSeguros.AddCell(New Phrase(autotransporte.Seguros.PrimaSeguro.ToString("C2"), FUENTE_MEDIANA))
        End If

        documento.Add(tSeguros)
    End Sub

    Private Shared Sub AgregarRemolques(ByVal documento As Document, ByVal remolques As Remolques)
        If remolques Is Nothing Then Return
        Dim contador As Integer = 0

        For Each remolque In remolques.Remolque
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tRemolques As PdfPTable = New PdfPTable(anchoColumnas)
            tRemolques.SetTotalWidth(anchoColumnas)
            tRemolques.SpacingBefore = 5
            tRemolques.HorizontalAlignment = Element.ALIGN_CENTER
            tRemolques.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tRemolques.DefaultCell.BorderWidth = 1
            tRemolques.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("REMOLQUE " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tRemolques.AddCell(cEncabezado)
            tRemolques.AddCell(New Phrase("Subtipo de remolque o semiremolque", FUENTE_SUBTITULO))
            tRemolques.AddCell(New Phrase(remolque.SubTipoRem, FUENTE_MEDIANA))
            tRemolques.AddCell(New Phrase("Placa", FUENTE_SUBTITULO))
            tRemolques.AddCell(New Phrase(remolque.Placa, FUENTE_MEDIANA))
            tRemolques.CompleteRow()
            documento.Add(tRemolques)
        Next
    End Sub

    Private Shared Sub AgregarTransporteMaritimo(ByVal documento As Document, ByVal transporteMaritimo As TransporteMaritimo)
        If transporteMaritimo Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tTransporteMaritimo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteMaritimo.SetTotalWidth(anchoColumnas)
        tTransporteMaritimo.SpacingBefore = 5
        tTransporteMaritimo.HorizontalAlignment = Element.ALIGN_CENTER
        tTransporteMaritimo.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tTransporteMaritimo.DefaultCell.BorderWidth = 1
        tTransporteMaritimo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE MARITIMO", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteMaritimo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteMaritimo.PermSCT) Then
            tTransporteMaritimo.AddCell(New Phrase("Permiso SCT", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.PermSCT & " - " + ObtenerTipoPermiso(transporteMaritimo.PermSCT), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumPermisoSCT) Then
            tTransporteMaritimo.AddCell(New Phrase("Permiso SCT", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumPermisoSCT, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreAseg) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre aseguradora", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreAseg, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumPolizaSeguro) Then
            tTransporteMaritimo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumPolizaSeguro, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.TipoEmbarcacion) Then
            tTransporteMaritimo.AddCell(New Phrase("Tipo de embarcación", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.TipoEmbarcacion & " - " + ObtenerConfigMaritima(transporteMaritimo.TipoEmbarcacion), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.Matricula) Then
            tTransporteMaritimo.AddCell(New Phrase("Matricula", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Matricula, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumeroOMI) Then
            tTransporteMaritimo.AddCell(New Phrase("Número OMI", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumeroOMI, FUENTE_MEDIANA))
        End If

        If transporteMaritimo.AnioEmbarcacion > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Año de embarcación", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.AnioEmbarcacion.ToString(), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreEmbarc) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre de embarcación", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreEmbarc, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NacionalidadEmbarc) Then
            tTransporteMaritimo.AddCell(New Phrase("Nacionalidad embarcación", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NacionalidadEmbarc, FUENTE_MEDIANA))
        End If

        If transporteMaritimo.UnidadesDeArqBruto > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Unidades de arqueo bruto", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.UnidadesDeArqBruto.ToString("f3"), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.TipoCarga) Then
            tTransporteMaritimo.AddCell(New Phrase("Tipo de carga", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.TipoCarga & " " + ObtenerTipoCarga(transporteMaritimo.TipoCarga), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumCertITC) Then
            tTransporteMaritimo.AddCell(New Phrase("Número de certificado ITC", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumCertITC, FUENTE_MEDIANA))
        End If

        If transporteMaritimo.Eslora > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud de eslora", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Eslora.ToString("f3"), FUENTE_MEDIANA))
        End If

        If transporteMaritimo.Manga > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud de manga", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Manga.ToString("f3"), FUENTE_MEDIANA))
        End If

        If transporteMaritimo.Calado > 0 Then
            tTransporteMaritimo.AddCell(New Phrase("Longitud del calado", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.Calado.ToString("f3"), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.LineaNaviera) Then
            tTransporteMaritimo.AddCell(New Phrase("Linea naviera", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.LineaNaviera, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NombreAgenteNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Nombre del agente naviero", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NombreAgenteNaviero, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumAutorizacionNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Número de la autorización", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumAutorizacionNaviero, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumViaje) Then
            tTransporteMaritimo.AddCell(New Phrase("Número del viaje", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumViaje, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteMaritimo.NumAutorizacionNaviero) Then
            tTransporteMaritimo.AddCell(New Phrase("Número de conocimiento de embarque", FUENTE_SUBTITULO))
            tTransporteMaritimo.AddCell(New Phrase(transporteMaritimo.NumConocEmbarc, FUENTE_MEDIANA))
        End If

        tTransporteMaritimo.CompleteRow()
        documento.Add(tTransporteMaritimo)
        AgregarContenedor(documento, transporteMaritimo)
    End Sub

    Private Shared Sub AgregarContenedor(ByVal documento As Document, ByVal transporteMaritimo As TransporteMaritimo)
        Dim contador As Integer = 0

        For Each item In transporteMaritimo.Contenedor
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tContenedor As PdfPTable = New PdfPTable(anchoColumnas)
            tContenedor.SetTotalWidth(anchoColumnas)
            tContenedor.SpacingBefore = 5
            tContenedor.HorizontalAlignment = Element.ALIGN_CENTER
            tContenedor.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tContenedor.DefaultCell.BorderWidth = 1
            tContenedor.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CONTENEDOR " & contador, FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tContenedor.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.MatriculaContenedor) Then
                tContenedor.AddCell(New Phrase("Matricula del contenedor", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.MatriculaContenedor & " - " + ObtenerTipoPermiso(transporteMaritimo.PermSCT), FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(item.TipoContenedor) Then
                tContenedor.AddCell(New Phrase("Tipo de contenedor", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.TipoContenedor, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(item.NumPrecinto) Then
                tContenedor.AddCell(New Phrase("Núm del sello o precinto ", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.NumPrecinto, FUENTE_MEDIANA))
            End If

            tContenedor.CompleteRow()
            documento.Add(tContenedor)
        Next
    End Sub

    Private Shared Sub AgregarTransporteAereo(ByVal documento As Document, ByVal transporteAereo As TransporteAereo)
        If transporteAereo Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteAereo.SetTotalWidth(anchoColumnas)
        tTransporteAereo.SpacingBefore = 5
        tTransporteAereo.HorizontalAlignment = Element.ALIGN_CENTER
        tTransporteAereo.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tTransporteAereo.DefaultCell.BorderWidth = 1
        tTransporteAereo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE AEREO", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteAereo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteAereo.PermSCT) Then
            tTransporteAereo.AddCell(New Phrase("Permiso SCT", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.PermSCT & " - " + ObtenerTipoPermiso(transporteAereo.PermSCT), FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumPermisoSCT) Then
            tTransporteAereo.AddCell(New Phrase("Núm. Permiso SCT", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumPermisoSCT, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.MatriculaAeronave) Then
            tTransporteAereo.AddCell(New Phrase("Matricula aeronave", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.MatriculaAeronave, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NombreAseg) Then
            tTransporteAereo.AddCell(New Phrase("Nombre de la aseguradora", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NombreAseg, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumPolizaSeguro) Then
            tTransporteAereo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumPolizaSeguro, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumeroGuia) Then
            tTransporteAereo.AddCell(New Phrase("Núm de guía", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumeroGuia, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.LugarContrato) Then
            tTransporteAereo.AddCell(New Phrase("Lugar de contrato", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.LugarContrato, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.CodigoTransportista) Then
            tTransporteAereo.AddCell(New Phrase("Código transportista", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.CodigoTransportista, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.RFCEmbarcador) Then
            tTransporteAereo.AddCell(New Phrase("RFC Embarcador", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.RFCEmbarcador, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NumRegIdTribEmbarc) Then
            tTransporteAereo.AddCell(New Phrase("Num. Reg. Id. Trib. Embarcador", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.NumRegIdTribEmbarc, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.ResidenciaFiscalEmbarc) Then
            tTransporteAereo.AddCell(New Phrase("Residencia fiscal embarcador", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.ResidenciaFiscalEmbarc, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteAereo.NombreEmbarcador) Then
            tTransporteAereo.AddCell(New Phrase("Nombre embarcador", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteAereo.ResidenciaFiscalEmbarc, FUENTE_MEDIANA))
        End If
    End Sub

    Private Shared Sub AgregarTransporteFerroviario(ByVal documento As Document, ByVal transporteFerroviario As TransporteFerroviario)
        If transporteFerroviario Is Nothing Then Return
        Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
        Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
        tTransporteAereo.SetTotalWidth(anchoColumnas)
        tTransporteAereo.SpacingBefore = 5
        tTransporteAereo.HorizontalAlignment = Element.ALIGN_CENTER
        tTransporteAereo.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
        tTransporteAereo.DefaultCell.BorderWidth = 1
        tTransporteAereo.LockedWidth = True
        Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("TRANSPORTE FERROVIARIO", FUENTE_SUBTITULO_BLANCO))
        cEncabezado.Border = Rectangle.NO_BORDER
        cEncabezado.BackgroundColor = BaseColor.BLACK
        cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
        cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
        cEncabezado.UseAscender = True
        cEncabezado.Colspan = 4
        tTransporteAereo.AddCell(cEncabezado)

        If Not String.IsNullOrEmpty(transporteFerroviario.TipoDeServicio) Then
            tTransporteAereo.AddCell(New Phrase("Tipo de servicio", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.TipoDeServicio & " - ", FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.TipoDeTrafico) Then
            tTransporteAereo.AddCell(New Phrase("Tipo de trafico", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.TipoDeTrafico, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.NombreAseg) Then
            tTransporteAereo.AddCell(New Phrase("Nombre de la aseguradora", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.NombreAseg, FUENTE_MEDIANA))
        End If

        If Not String.IsNullOrEmpty(transporteFerroviario.NumPolizaSeguro) Then
            tTransporteAereo.AddCell(New Phrase("Núm. poliza seguro", FUENTE_SUBTITULO))
            tTransporteAereo.AddCell(New Phrase(transporteFerroviario.NumPolizaSeguro, FUENTE_MEDIANA))
        End If

        tTransporteAereo.CompleteRow()
        documento.Add(tTransporteAereo)
        AgregarDerechosDePaso(documento, transporteFerroviario)
        AgregarCarro(documento, transporteFerroviario)
    End Sub

    Private Shared Sub AgregarDerechosDePaso(ByVal documento As Document, ByVal transporteFerroviario As TransporteFerroviario)
        Dim contador As Integer = 0

        For Each item In transporteFerroviario.DerechosDePaso
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tTransporteAereo As PdfPTable = New PdfPTable(anchoColumnas)
            tTransporteAereo.SetTotalWidth(anchoColumnas)
            tTransporteAereo.SpacingBefore = 5
            tTransporteAereo.HorizontalAlignment = Element.ALIGN_CENTER
            tTransporteAereo.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tTransporteAereo.DefaultCell.BorderWidth = 1
            tTransporteAereo.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("DERECHO DE PASO " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tTransporteAereo.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoDerechoDePaso) Then
                tTransporteAereo.AddCell(New Phrase("Tipo derecho de paso", FUENTE_SUBTITULO))
                tTransporteAereo.AddCell(New Phrase(item.TipoDerechoDePaso & " - ", FUENTE_MEDIANA))
            End If

            If item.KilometrajePagado > 0 Then
                tTransporteAereo.AddCell(New Phrase("Kilometraje pagado", FUENTE_SUBTITULO))
                tTransporteAereo.AddCell(New Phrase(item.KilometrajePagado.ToString("f2"), FUENTE_MEDIANA))
            End If
        Next
    End Sub

    Private Shared Sub AgregarCarro(ByVal documento As Document, ByVal transporteFerroviario As TransporteFerroviario)
        Dim contador As Integer = 0

        For Each item In transporteFerroviario.Carro
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tCarro As PdfPTable = New PdfPTable(anchoColumnas)
            tCarro.SetTotalWidth(anchoColumnas)
            tCarro.SpacingBefore = 5
            tCarro.HorizontalAlignment = Element.ALIGN_CENTER
            tCarro.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tCarro.DefaultCell.BorderWidth = 1
            tCarro.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CARRO " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tCarro.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoCarro) Then
                tCarro.AddCell(New Phrase("Tipo de carro", FUENTE_SUBTITULO))
                tCarro.AddCell(New Phrase(item.TipoCarro & " - ", FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(item.MatriculaCarro) Then
                tCarro.AddCell(New Phrase("Matricula carro", FUENTE_SUBTITULO))
                tCarro.AddCell(New Phrase(item.MatriculaCarro, FUENTE_MEDIANA))
            End If

            If Not String.IsNullOrEmpty(item.GuiaCarro) Then
                tCarro.AddCell(New Phrase("Guia carro", FUENTE_SUBTITULO))
                tCarro.AddCell(New Phrase(item.MatriculaCarro, FUENTE_MEDIANA))
            End If

            If item.ToneladasNetasCarro > 0 Then
                tCarro.AddCell(New Phrase("Toneladas netas carro", FUENTE_SUBTITULO))
                tCarro.AddCell(New Phrase(item.ToneladasNetasCarro.ToString("F3"), FUENTE_MEDIANA))
            End If

            tCarro.CompleteRow()
            documento.Add(tCarro)
            'AgregarContenedor(documento, item)
        Next
    End Sub

    Private Shared Sub AgregarContenedor(ByVal documento As Document, ByVal carro As CartaPorte20.Carro)
        Dim contador As Integer = 0

        For Each item In carro.Contenedor
            contador += 1
            Dim anchoColumnas As Single() = cmAFloat(New Single() {4.0F, 6.0F, 4.0F, 6.0F})
            Dim tContenedor As PdfPTable = New PdfPTable(anchoColumnas)
            tContenedor.SetTotalWidth(anchoColumnas)
            tContenedor.SpacingBefore = 5
            tContenedor.HorizontalAlignment = Element.ALIGN_CENTER
            tContenedor.DefaultCell.BorderColor = New BaseColor(241, 241, 241)
            tContenedor.DefaultCell.BorderWidth = 1
            tContenedor.LockedWidth = True
            Dim cEncabezado As PdfPCell = New PdfPCell(New Paragraph("CONTENEDOR " & contador.ToString(), FUENTE_SUBTITULO_BLANCO))
            cEncabezado.Border = Rectangle.NO_BORDER
            cEncabezado.BackgroundColor = BaseColor.BLACK
            cEncabezado.HorizontalAlignment = Element.ALIGN_CENTER
            cEncabezado.VerticalAlignment = Element.ALIGN_MIDDLE
            cEncabezado.UseAscender = True
            cEncabezado.Colspan = 4
            tContenedor.AddCell(cEncabezado)

            If Not String.IsNullOrEmpty(item.TipoContenedor) Then
                tContenedor.AddCell(New Phrase("Tipo contenedor", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.TipoContenedor & " - ", FUENTE_MEDIANA))
            End If

            If item.PesoContenedorVacio > 0 Then
                tContenedor.AddCell(New Phrase("PesoContenedorVacio", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.PesoContenedorVacio.ToString("F3"), FUENTE_MEDIANA))
            End If

            If item.PesoNetoMercancia > 0 Then
                tContenedor.AddCell(New Phrase("Peso neto mercancia", FUENTE_SUBTITULO))
                tContenedor.AddCell(New Phrase(item.PesoNetoMercancia.ToString("F3"), FUENTE_MEDIANA))
            End If

            tContenedor.CompleteRow()
            documento.Add(tContenedor)
        Next
    End Sub
#End Region
#Region "Catalogos SAT"
    Private Shared Function ObtenerRegimenFiscal(ByVal clave As String) As String
        If clave = "601" Then
            Return "General de Ley Personas Morales"
        ElseIf clave = "603" Then
            Return "Personas Morales con Fines no Lucrativos"
        ElseIf clave = "605" Then
            Return "Sueldos y Salarios e Ingresos Asimilados a Salarios"
        ElseIf clave = "606" Then
            Return "Arrendamiento"
        ElseIf clave = "608" Then
            Return "Demás ingresos"
        ElseIf clave = "609" Then
            Return "Consolidación"
        ElseIf clave = "610" Then
            Return "Residentes en el Extranjero sin Establecimiento Permanente en México"
        ElseIf clave = "611" Then
            Return "Ingresos por Dividendos (socios y accionistas)"
        ElseIf clave = "612" Then
            Return "Personas Físicas con Actividades Empresariales y Profesionales"
        ElseIf clave = "614" Then
            Return "Ingresos por intereses"
        ElseIf clave = "616" Then
            Return "Sin obligaciones fiscales"
        ElseIf clave = "620" Then
            Return "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"
        ElseIf clave = "621" Then
            Return "Incorporación Fiscal"
        ElseIf clave = "622" Then
            Return "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"
        ElseIf clave = "623" Then
            Return "Opcional para Grupos de Sociedades"
        ElseIf clave = "624" Then
            Return "Coordinados"
        ElseIf clave = "628" Then
            Return "Hidrocarburos"
        ElseIf clave = "607" Then
            Return "Régimen de Enajenación o Adquisición de Bienes"
        ElseIf clave = "629" Then
            Return "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"
        ElseIf clave = "630" Then
            Return "Enajenación de acciones en bolsa de valores"
        ElseIf clave = "615" Then
            Return "Régimen de los ingresos por obtención de premios"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoNomina(ByVal tipoNomina As String) As String
        tipoNomina = tipoNomina.ToUpper()

        If tipoNomina = "O" Then
            Return "Nómina ordinaria"
        ElseIf tipoNomina = "E" Then
            Return "Nómina extraordinaria"
        Else
            Return "-"
        End If
    End Function

    Private Shared Function ObtenerFormaPago(ByVal clave As String) As String
        If clave = "01" Then
            Return "Efectivo"
        ElseIf clave = "02" Then
            Return "Cheque nominativo"
        ElseIf clave = "03" Then
            Return "Transferencia electrónica de fondos"
        ElseIf clave = "04" Then
            Return "Tarjeta de crédito"
        ElseIf clave = "05" Then
            Return "Monedero electrónico"
        ElseIf clave = "06" Then
            Return "Dinero electrónico"
        ElseIf clave = "08" Then
            Return "Vales de despensa"
        ElseIf clave = "12" Then
            Return "Dación en pago"
        ElseIf clave = "13" Then
            Return "Pago por subrogación"
        ElseIf clave = "14" Then
            Return "Pago por consignación"
        ElseIf clave = "15" Then
            Return "Condonación"
        ElseIf clave = "17" Then
            Return "Compensación"
        ElseIf clave = "23" Then
            Return "Novación"
        ElseIf clave = "24" Then
            Return "Confusión"
        ElseIf clave = "25" Then
            Return "Remisión de deuda"
        ElseIf clave = "26" Then
            Return "Prescripción o caducidad"
        ElseIf clave = "27" Then
            Return "A satisfacción del acreedor"
        ElseIf clave = "28" Then
            Return "Tarjeta de débito"
        ElseIf clave = "29" Then
            Return "Tarjeta de servicios"
        ElseIf clave = "30" Then
            Return "Aplicación de anticipos"
        ElseIf clave = "99" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerImpuesto(ByVal clave As String) As String
        If clave = "001" Then
            Return "ISR"
        ElseIf clave = "002" Then
            Return "IVA"
        ElseIf clave = "003" Then
            Return "IEPS"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerMetodoPago(ByVal clave As String) As String
        If clave = "PUE" Then
            Return "Pago en una sola exhibición"
        ElseIf clave = "PPD" Then
            Return "Pago en parcialidades o diferido"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerPais(ByVal clave As String) As String
        If clave = "MEX" Then
            Return "México"
        ElseIf clave = "USA" Then
            Return "Estados Unidos"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoComprobante(ByVal clave As String) As String
        If clave = "I" Then
            Return "Ingreso"
        ElseIf clave = "E" Then
            Return "Egreso"
        ElseIf clave = "T" Then
            Return "Traslado"
        ElseIf clave = "N" Then
            Return "Nómina"
        ElseIf clave = "P" Then
            Return "Pago"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerUsoCFDI(ByVal clave As String) As String
        If clave = "G01" Then
            Return "Adquisición de mercancias"
        ElseIf clave = "G02" Then
            Return "Devoluciones, descuentos o bonificaciones"
        ElseIf clave = "G03" Then
            Return "Gastos en general"
        ElseIf clave = "I01" Then
            Return "Construcciones"
        ElseIf clave = "I02" Then
            Return "Mobilario y equipo de oficina por inversiones"
        ElseIf clave = "I03" Then
            Return "Equipo de transporte"
        ElseIf clave = "I04" Then
            Return "Equipo de computo y accesorios"
        ElseIf clave = "I05" Then
            Return "Dados, troqueles, moldes, matrices y herramental"
        ElseIf clave = "I06" Then
            Return "Comunicaciones telefónicas"
        ElseIf clave = "I07" Then
            Return "Comunicaciones satelitales"
        ElseIf clave = "I08" Then
            Return "Otra maquinaria y equipo"
        ElseIf clave = "D01" Then
            Return "Honorarios médicos, dentales y gastos hospitalarios."
        ElseIf clave = "D02" Then
            Return "Gastos médicos por incapacidad o discapacidad"
        ElseIf clave = "D03" Then
            Return "Gastos funerales."
        ElseIf clave = "D04" Then
            Return "Donativos."
        ElseIf clave = "D05" Then
            Return "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."
        ElseIf clave = "D06" Then
            Return "Aportaciones voluntarias al SAR."
        ElseIf clave = "D07" Then
            Return "Primas por seguros de gastos médicos."
        ElseIf clave = "D08" Then
            Return "Gastos de transportación escolar obligatoria."
        ElseIf clave = "D09" Then
            Return "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."
        ElseIf clave = "D10" Then
            Return "Pagos por servicios educativos (colegiaturas)"
        ElseIf clave = "P01" Then
            Return "Por definir"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerUnidad(ByVal clave As String) As String
        clave = clave.ToUpper()

        If clave = "H87" Then
            Return "Pieza"
        ElseIf clave = "LTR" Then
            Return "Litro"
        ElseIf clave = "KGM" Then
            Return "Kilogramo"
        ElseIf clave = "E48" Then
            Return "Unidad de servicio"
        ElseIf clave = "EA" Then
            Return "Elemento"
        ElseIf clave = "PR" Then
            Return "Par"
        ElseIf clave = "ACT" Then
            Return "Actividad"
        ElseIf clave = "LUB" Then
            Return "Tonelada métrica, aceite lubricante"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerMoneda(ByVal clave As String) As String
        If clave = "MXN" Then
            Return "Peso Mexicano"
        ElseIf clave = "EUR" Then
            Return "Euro"
        ElseIf clave = "USD" Then
            Return "Dolar americano"
        ElseIf clave = "XXX" Then
            Return "Los códigos asignados para las transacciones en que intervenga ninguna moneda"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoRelacion(ByVal clave As String) As String
        If clave = "01" Then
            Return "Nota de crédito de los documentos relacionados"
        ElseIf clave = "02" Then
            Return "Nota de débito de los documentos relacionados"
        ElseIf clave = "03" Then
            Return "Devolución de mercancía sobre facturas o traslados previos"
        ElseIf clave = "04" Then
            Return "Sustitución de los CFDI previos"
        ElseIf clave = "05" Then
            Return "Traslados de mercancias facturados previamente"
        ElseIf clave = "06" Then
            Return "Factura generada por los traslados previos"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoJornada(ByVal clave As String) As String
        If clave = "01" Then
            Return "Diurna"
        ElseIf clave = "02" Then
            Return "Nocturna"
        ElseIf clave = "03" Then
            Return "Mixta"
        ElseIf clave = "04" Then
            Return "Por hora"
        ElseIf clave = "05" Then
            Return "Reducida"
        ElseIf clave = "06" Then
            Return "Continuada"
        ElseIf clave = "07" Then
            Return "Partida"
        ElseIf clave = "08" Then
            Return "Por turnos"
        ElseIf clave = "99" Then
            Return "OtraJornada"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerTipoRegimen(ByVal clave As String) As String
        If clave = "02" Then
            Return "Sueldos"
        ElseIf clave = "07" Then
            Return "Asimilados Miembros consejos"
        ElseIf clave = "08" Then
            Return "Asimilados comisionistas"
        ElseIf clave = "09" Then
            Return "Asimilados Honorarios"
        ElseIf clave = "10" Then
            Return "Asimilados acciones"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoJornada1(ByVal clave As String) As String
        If clave = "01" Then
            Return "8"
        ElseIf clave = "02" Then
            Return "7"
        ElseIf clave = "03" Then
            Return "7.3"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerPeriodicidadPago(ByVal clave As String) As String
        If clave = "02" Then
            Return "Semanal "
        ElseIf clave = "03" Then
            Return "Catorcenal "
        ElseIf clave = "04" Then
            Return "Quincenal "
        ElseIf clave = "05" Then
            Return "Mensual "
        ElseIf clave = "10" Then
            Return "Decenal "
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerRiesgoPuesto(ByVal riesgoPuesto As String) As String
        If riesgoPuesto = "1" Then
            Return "Clase I"
        ElseIf riesgoPuesto = "2" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "3" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "4" Then
            Return "Clase II"
        ElseIf riesgoPuesto = "5" Then
            Return "Clase II"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoContrato(ByVal clave As String) As String
        If clave = "01" Then
            Return "Contrato de trabajo por tiempo indeterminado"
        ElseIf clave = "02" Then
            Return "Contrato de trabajo para obra determinada"
        ElseIf clave = "03" Then
            Return "Contrato de trabajo por tiempo determinado"
        ElseIf clave = "04" Then
            Return "Contrato de trabajo por temporada"
        ElseIf clave = "05" Then
            Return "Contrato de trabajo sujeto a prueba"
        ElseIf clave = "06" Then
            Return "Contrato de trabajo con capacitación inicial"
        ElseIf clave = "07" Then
            Return "Modalidad de contratación por pago de hora laborada"
        ElseIf clave = "08" Then
            Return "Modalidad de trabajo por comisión laboral"
        ElseIf clave = "09" Then
            Return "Modalidades de contratación donde no existe relación de trabajo"
        ElseIf clave = "10" Then
            Return "Jubilación, pensión, retiro."
        ElseIf clave = "99" Then
            Return "Otro contrato"
        Else
            Return " "
        End If
    End Function

    Private Shared Function ObtenerTipoPercepcion(ByVal clave As String) As String
        If clave = "001" Then
            Return "Sueldos, Salarios  Rayas y Jornales"
        ElseIf clave = "002" Then
            Return "Gratificación Anual (Aguinaldo)"
        ElseIf clave = "003" Then
            Return "Participación de los Trabajadores en las Utilidades PTU"
        ElseIf clave = "004" Then
            Return "Reembolso de Gastos Médicos Dentales y Hospitalarios"
        ElseIf clave = "005" Then
            Return "Fondo de Ahorro"
        ElseIf clave = "006" Then
            Return "Caja de ahorro"
        ElseIf clave = "009" Then
            Return "Contribuciones a Cargo del Trabajador Pagadas por el Patrón"
        ElseIf clave = "010" Then
            Return "Premios por puntualidad"
        ElseIf clave = "011" Then
            Return "Prima de Seguro de vida"
        ElseIf clave = "012" Then
            Return "Seguro de Gastos Médicos Mayores"
        ElseIf clave = "013" Then
            Return "Cuotas Sindicales Pagadas por el Patrón"
        ElseIf clave = "014" Then
            Return "Subsidios por incapacidad"
        ElseIf clave = "015" Then
            Return "Becas para trabajadores y/o hijos"
        ElseIf clave = "019" Then
            Return "Horas extra"
        ElseIf clave = "020" Then
            Return "Prima dominical"
        ElseIf clave = "021" Then
            Return "Prima vacacional"
        ElseIf clave = "022" Then
            Return "Prima por antigüedad"
        ElseIf clave = "023" Then
            Return "Pagos por separación"
        ElseIf clave = "024" Then
            Return "Seguro de retiro"
        ElseIf clave = "025" Then
            Return "Indemnizaciones"
        ElseIf clave = "026" Then
            Return "Reembolso por funeral"
        ElseIf clave = "027" Then
            Return "Cuotas de seguridad social pagadas por el patrón"
        ElseIf clave = "028" Then
            Return "Comisiones"
        ElseIf clave = "029" Then
            Return "Vales de despensa"
        ElseIf clave = "030" Then
            Return "Vales de restaurante"
        ElseIf clave = "031" Then
            Return "Vales de gasolina"
        ElseIf clave = "032" Then
            Return "Vales de ropa"
        ElseIf clave = "033" Then
            Return "Ayuda para renta"
        ElseIf clave = "034" Then
            Return "Ayuda para artículos escolares"
        ElseIf clave = "035" Then
            Return "Ayuda para anteojos"
        ElseIf clave = "036" Then
            Return "Ayuda para transporte"
        ElseIf clave = "037" Then
            Return "Ayuda para gastos de funeral"
        ElseIf clave = "038" Then
            Return "Otros ingresos por salarios"
        ElseIf clave = "039" Then
            Return "Jubilaciones, pensiones o haberes de retiro"
        ElseIf clave = "044" Then
            Return "Jubilaciones, pensiones o haberes de retiro en parcialidades"
        ElseIf clave = "045" Then
            Return "Ingresos en acciones o títulos valor que representan bienes"
        ElseIf clave = "046" Then
            Return "Ingresos asimilados a salarios"
        ElseIf clave = "047" Then
            Return "Alimentación"
        ElseIf clave = "048" Then
            Return "Habitación"
        ElseIf clave = "049" Then
            Return "Premios por asistencia"
        ElseIf clave = "050" Then
            Return "Viáticos"
        ElseIf clave = "051" Then
            Return "Pagos por gratificaciones, primas, compensaciones, recompensas u otros a extrabajadores derivados de jubilación en parcialidades"
        ElseIf clave = "052" Then
            Return "Pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de resoluciones judicial o de un laudo"
        ElseIf clave = "053" Then
            Return "Pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de resoluciones judicial o de un laudo"
        Else
            Return String.Empty
        End If
    End Function

    Private Shared Function ObtenerTipoDeduccion(ByVal clave As String) As String
        If clave = "001" Then
            Return "Seguridad social"
        ElseIf clave = "002" Then
            Return "ISR"
        ElseIf clave = "003" Then
            Return "Aportaciones a retiro, cesantía en edad avanzada y vejez."
        ElseIf clave = "004" Then
            Return "Otros"
        ElseIf clave = "005" Then
            Return "Aportaciones a Fondo de vivienda"
        ElseIf clave = "006" Then
            Return "Descuento por incapacidad"
        ElseIf clave = "007" Then
            Return "Pensión alimenticia"
        ElseIf clave = "008" Then
            Return "Renta"
        ElseIf clave = "009" Then
            Return "Préstamos provenientes del Fondo Nacional de la Vivienda para los Trabajadores"
        ElseIf clave = "010" Then
            Return "Pago por crédito de vivienda"
        ElseIf clave = "011" Then
            Return "Pago de abonos INFONACOT"
        ElseIf clave = "012" Then
            Return "Anticipo de salarios"
        ElseIf clave = "013" Then
            Return "Pagos hechos con exceso al trabajador"
        ElseIf clave = "014" Then
            Return "Errores"
        ElseIf clave = "015" Then
            Return "Pérdidas"
        ElseIf clave = "016" Then
            Return "Averías"
        ElseIf clave = "017" Then
            Return "Adquisición de artículos producidos por la empresa o establecimiento"
        ElseIf clave = "018" Then
            Return "Cuotas para la constitución y fomento de sociedades cooperativas y de cajas de ahorro"
        ElseIf clave = "019" Then
            Return "Cuotas sindicales"
        ElseIf clave = "020" Then
            Return "Ausencia (Ausentismo)"
        ElseIf clave = "021" Then
            Return "Cuotas obrero patronales"
        ElseIf clave = "022" Then
            Return "Impuestos Locales"
        ElseIf clave = "023" Then
            Return "Aportaciones voluntarias"
        ElseIf clave = "024" Then
            Return "Ajuste en Gratificación Anual (Aguinaldo) Exento"
        ElseIf clave = "025" Then
            Return "Ajuste en Gratificación Anual (Aguinaldo) Gravado"
        ElseIf clave = "026" Then
            Return "Ajuste en Participación de los Trabajadores en las Utilidades PTU Exento"
        ElseIf clave = "027" Then
            Return "Ajuste en Participación de los Trabajadores en las Utilidades PTU Gravado"
        ElseIf clave = "028" Then
            Return "Ajuste en Reembolso de Gastos Médicos Dentales y Hospitalarios Exento"
        ElseIf clave = "029" Then
            Return "Ajuste en Fondo de ahorro Exento"
        ElseIf clave = "030" Then
            Return "Ajuste en Caja de ahorro Exento"
        ElseIf clave = "031" Then
            Return "Ajuste en Contribuciones a Cargo del Trabajador Pagadas por el Patrón Exento"
        ElseIf clave = "032" Then
            Return "Ajuste en Premios por puntualidad Gravado"
        ElseIf clave = "033" Then
            Return "Ajuste en Prima de Seguro de vida Exento"
        ElseIf clave = "034" Then
            Return "Ajuste en Seguro de Gastos Médicos Mayores Exento"
        ElseIf clave = "035" Then
            Return "Ajuste en Cuotas Sindicales Pagadas por el Patrón Exento"
        ElseIf clave = "036" Then
            Return "Ajuste en Subsidios por incapacidad Exento"
        ElseIf clave = "037" Then
            Return "Ajuste en Becas para trabajadores y/o hijos Exento"
        ElseIf clave = "038" Then
            Return "Ajuste en Horas extra Exento"
        ElseIf clave = "039" Then
            Return "Ajuste en Horas extra Gravado"
        ElseIf clave = "040" Then
            Return "Ajuste en Prima dominical Exento"
        ElseIf clave = "041" Then
            Return "Ajuste en Prima dominical Gravado"
        ElseIf clave = "042" Then
            Return "Ajuste en Prima vacacional Exento"
        ElseIf clave = "043" Then
            Return "Ajuste en Prima vacacional Gravado"
        ElseIf clave = "044" Then
            Return "Ajuste en Prima por antigüedad Exento"
        ElseIf clave = "045" Then
            Return "Ajuste en Prima por antigüedad Gravado"
        ElseIf clave = "046" Then
            Return "Ajuste en Pagos por separación Exento"
        ElseIf clave = "047" Then
            Return "Ajuste en Pagos por separación Gravado"
        ElseIf clave = "048" Then
            Return "Ajuste en Seguro de retiro Exento"
        ElseIf clave = "049" Then
            Return "Ajuste en Indemnizaciones Exento"
        ElseIf clave = "050" Then
            Return "Ajuste en Indemnizaciones Gravado"
        ElseIf clave = "051" Then
            Return "Ajuste en Reembolso por funeral Exento"
        ElseIf clave = "052" Then
            Return "Ajuste en Cuotas de seguridad social pagadas por el patrón Exento"
        ElseIf clave = "053" Then
            Return "Ajuste en Comisiones Gravado"
        ElseIf clave = "054" Then
            Return "Ajuste en Vales de despensa Exento"
        ElseIf clave = "055" Then
            Return "Ajuste en Vales de restaurante Exento"
        ElseIf clave = "056" Then
            Return "Ajuste en Vales de gasolina Exento"
        ElseIf clave = "057" Then
            Return "Ajuste en Vales de ropa Exento"
        ElseIf clave = "058" Then
            Return "Ajuste en Ayuda para renta Exento"
        ElseIf clave = "059" Then
            Return "Ajuste en Ayuda para artículos escolares Exento"
        ElseIf clave = "060" Then
            Return "Ajuste en Ayuda para anteojos Exento"
        ElseIf clave = "061" Then
            Return "Ajuste en Ayuda para transporte Exento"
        ElseIf clave = "062" Then
            Return "Ajuste en Ayuda para gastos de funeral Exento"
        ElseIf clave = "063" Then
            Return "Ajuste en Otros ingresos por salarios Exento"
        ElseIf clave = "064" Then
            Return "Ajuste en Otros ingresos por salarios Gravado"
        ElseIf clave = "065" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en una sola exhibición Exento "
        ElseIf clave = "066" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en una sola exhibición Gravado"
        ElseIf clave = "067" Then
            Return "Ajuste en Pagos por separación Acumulable"
        ElseIf clave = "068" Then
            Return "Ajuste en Pagos por separación No acumulable"
        ElseIf clave = "069" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en parcialidades Exento"
        ElseIf clave = "070" Then
            Return "Ajuste en Jubilaciones, pensiones o haberes de retiro en parcialidades Gravado"
        ElseIf clave = "071" Then
            Return "Ajuste en Subsidio para el empleo (efectivamente entregado al trabajador)"
        ElseIf clave = "072" Then
            Return "Ajuste en Ingresos en acciones o títulos valor que representan bienes Exento"
        ElseIf clave = "073" Then
            Return "Ajuste en Ingresos en acciones o títulos valor que representan bienes Gravado"
        ElseIf clave = "074" Then
            Return "Ajuste en Alimentación Exento"
        ElseIf clave = "075" Then
            Return "Ajuste en Alimentación Gravado"
        ElseIf clave = "076" Then
            Return "Ajuste en Habitación Exento"
        ElseIf clave = "077" Then
            Return "Ajuste en Habitación Gravado"
        ElseIf clave = "078" Then
            Return "Ajuste en Premios por asistencia"
        ElseIf clave = "079" Then
            Return "Ajuste en Pagos distintos a los listados y que no deben considerarse como ingreso por sueldos, salarios o ingresos asimilados."
        ElseIf clave = "080" Then
            Return "Ajuste en Viáticos gravados"
        ElseIf clave = "081" Then
            Return "Ajuste en Viáticos (entregados al trabajador)"
        ElseIf clave = "082" Then
            Return "Ajuste en Fondo de ahorro Gravado"
        ElseIf clave = "083" Then
            Return "Ajuste en Caja de ahorro Gravado"
        ElseIf clave = "084" Then
            Return "Ajuste en Prima de Seguro de vida Gravado"
        ElseIf clave = "085" Then
            Return "Ajuste en Seguro de Gastos Médicos Mayores Gravado"
        ElseIf clave = "086" Then
            Return "Ajuste en Subsidios por incapacidad Gravado"
        ElseIf clave = "087" Then
            Return "Ajuste en Becas para trabajadores y/o hijos Gravado"
        ElseIf clave = "088" Then
            Return "Ajuste en Seguro de retiro Gravado"
        ElseIf clave = "089" Then
            Return "Ajuste en Vales de despensa Gravado"
        ElseIf clave = "090" Then
            Return "Ajuste en Vales de restaurante Gravado"
        ElseIf clave = "091" Then
            Return "Ajuste en Vales de gasolina Gravado"
        ElseIf clave = "092" Then
            Return "Ajuste en Vales de ropa Gravado"
        ElseIf clave = "093" Then
            Return "Ajuste en Ayuda para renta Gravado"
        ElseIf clave = "094" Then
            Return "Ajuste en Ayuda para artículos escolares Gravado"
        ElseIf clave = "095" Then
            Return "Ajuste en Ayuda para anteojos Gravado"
        ElseIf clave = "096" Then
            Return "Ajuste en Ayuda para transporte Gravado"
        ElseIf clave = "097" Then
            Return "Ajuste en Ayuda para gastos de funeral Gravado"
        ElseIf clave = "098" Then
            Return "Ajuste a ingresos asimilados a salarios gravados"
        ElseIf clave = "099" Then
            Return "Ajuste a ingresos por sueldos y salarios gravados"
        ElseIf clave = "100" Then
            Return "Ajuste en Viáticos exentos"
        ElseIf clave = "101" Then
            Return "ISR Retenido de ejercicio anterior"
        ElseIf clave = "102" Then
            Return "Ajuste a pagos por gratificaciones, primas, compensaciones, recompensas u otros a extrabajadores derivados de jubilación en parcialidades, gravados"
        ElseIf clave = "103" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de una resolución judicial o de un laudo gravados"
        ElseIf clave = "104" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en parcialidades derivados de la ejecución de una resolución judicial o de un laudo exentos"
        ElseIf clave = "105" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de una resolución judicial o de un laudo gravados"
        ElseIf clave = "106" Then
            Return "Ajuste a pagos que se realicen a extrabajadores que obtengan una jubilación en una sola exhibición derivados de la ejecución de una resolución judicial o de un laudo exentos"
        Else
            Return String.Empty
        End If
    End Function

    Private Shared Function ObtenerTipoOtroPago(ByVal clave As String) As String
        If clave = "0001" Then
            Return "Reintegro de ISR pagado en exceso (siempre que no haya sido enterado al SAT)."
        ElseIf clave = "002" Then
            Return "Subsidio para el empleo (efectivamente entregado al trabajador)."
        ElseIf clave = "003" Then
            Return "Viáticos (entregados al trabajador)."
        ElseIf clave = "004" Then
            Return "Aplicación de saldo a favor por compensación anual."
        ElseIf clave = "005" Then
            Return "Reintegro de ISR retenido en exceso de ejercicio anterior (siempre que no haya sido enterado al SAT)."
        ElseIf clave = "999" Then
            Return "Pagos distintos a los listados y que no deben considerarse como ingreso por sueldos, salarios o ingresos asimilados."
        Else
            Return String.Empty
        End If
    End Function

    Private Shared Function ObtenerEstatusUUID(ByVal clave As String) As String
        If clave = "201" Then
            Return "Cancelación aceptada"
        ElseIf clave = "202" Then
            Return "Cancelacion no aceptada"
        Else
            Return ""
        End If
    End Function
    Private Shared Function ObtenerTipoEstacion(ByVal tipoEstacion As String) As String
        If tipoEstacion = "01" Then
            Return "Origen Nacional"
        ElseIf tipoEstacion = "02" Then
            Return "Intermedia"
        ElseIf tipoEstacion = "03" Then
            Return "Destino Final Nacional"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerCveTransporte(ByVal claveTransporte As String) As String
        If claveTransporte = "01" Then
            Return "Autotransporte"
        ElseIf claveTransporte = "02" Then
            Return "Transporte Marítimo"
        ElseIf claveTransporte = "03" Then
            Return "Transporte Aéreo"
        ElseIf claveTransporte = "03" Then
            Return "Transporte Ferroviario"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerConfigVehicular(ByVal configVehicular As String) As String
        If configVehicular = "VL" Then
            Return "Vehículo ligero de carga (2 llantas en el eje delantero y 2 llantas en el eje trasero)"
        ElseIf configVehicular = "C2" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)"
        ElseIf configVehicular = "C3" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)"
        ElseIf configVehicular = "C2R2" Then
            Return "Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C3R2" Then
            Return "Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C2R3" Then
            Return "Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "C3R3" Then
            Return "Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "T2S1" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S2" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S3" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S1" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S2" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S3" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R4" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)"
        ElseIf configVehicular = "T2S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S3S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "OTROEVGP" Then
            Return "Especializado de carga Voluminosa y/o Gran Peso"
        ElseIf configVehicular = "OTROSG" Then
            Return "Servicio de Grúas"
        ElseIf configVehicular = "GPLUTA" Then
            Return "Grúa de Pluma Tipo A"
        ElseIf configVehicular = "GPLUTB" Then
            Return "Grúa de Pluma Tipo B"
        ElseIf configVehicular = "GPLUTC" Then
            Return "Grúa de Pluma Tipo C"
        ElseIf configVehicular = "GPLUTD" Then
            Return "Grúa de Pluma Tipo D"
        ElseIf configVehicular = "GPLATA" Then
            Return "Grúa de Plataforma Tipo A"
        ElseIf configVehicular = "GPLATB" Then
            Return "Grúa de Plataforma Tipo B"
        ElseIf configVehicular = "GPLATC" Then
            Return "Grúa de Plataforma Tipo C"
        ElseIf configVehicular = "GPLATD" Then
            Return "Grúa de Plataforma Tipo D"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerTipoPermiso(ByVal tipoPermiso As String) As String
        If tipoPermiso = "TPAF01" Then
            Return "Autotransporte Federal de carga general."
        ElseIf tipoPermiso = "TPAF02" Then
            Return "Transporte privado de carga."
        ElseIf tipoPermiso = "TPAF03" Then
            Return "Autotransporte Federal de Carga Especializada de materiales y residuos peligrosos."
        ElseIf tipoPermiso = "TPAF04" Then
            Return "Transporte de automóviles sin rodar en vehículo tipo góndola."
        ElseIf tipoPermiso = "TPAF05" Then
            Return "Transporte de carga de gran peso y/o volumen de hasta 90 toneladas."
        ElseIf tipoPermiso = "TPAF06" Then
            Return "Transporte de carga especializada de gran peso y/o volumen de más 90 toneladas."
        ElseIf tipoPermiso = "TPAF07" Then
            Return "Transporte Privado de materiales y residuos peligrosos."
        ElseIf tipoPermiso = "TPAF08" Then
            Return "Autotransporte internacional de carga de largo recorrido."
        ElseIf tipoPermiso = "TPAF09" Then
            Return "Autotransporte internacional de carga especializada de materiales y residuos peligrosos de largo recorrido."
        ElseIf tipoPermiso = "TPAF10" Then
            Return "Autotransporte Federal de Carga General cuyo ámbito de aplicación comprende la franja fronteriza con Estados Unidos."
        ElseIf tipoPermiso = "TPAF11" Then
            Return "Autotransporte Federal de Carga Especializada cuyo ámbito de aplicación comprende la franja fronteriza con Estados Unidos."
        ElseIf tipoPermiso = "TPAF12" Then
            Return "Servicio auxiliar de arrastre en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF13" Then
            Return "Servicio auxiliar de servicios de arrastre, arrastre y salvamento, y depósito de vehículos en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF14" Then
            Return "Servicio de paquetería y mensajería en las vías generales de comunicación."
        ElseIf tipoPermiso = "TPAF15" Then
            Return "Transporte especial para el tránsito de grúas industriales con peso máximo de 90 toneladas."
        ElseIf tipoPermiso = "TPAF16" Then
            Return "Servicio federal para empresas arrendadoras servicio público federal."
        ElseIf tipoPermiso = "TPAF17" Then
            Return "Empresas trasladistas de vehículos nuevos."
        ElseIf tipoPermiso = "TPAF18" Then
            Return "Empresas fabricantes o distribuidoras de vehículos nuevos."
        ElseIf tipoPermiso = "TPAF19" Then
            Return "Autorización expresa para circular en los caminos y puentes de jurisdicción federal con configuraciones de tractocamión doblemente articulado."
        ElseIf tipoPermiso = "TPAF20" Then
            Return "Autotransporte Federal de Carga Especializada de fondos y valores."
        ElseIf tipoPermiso = "TPTM01" Then
            Return "Permiso temporal para navegación de cabotaje"
        ElseIf tipoPermiso = "TPTA01" Then
            Return "Concesión y/o autorización para el servicio regular nacional y/o internacional para empresas mexicanas"
        ElseIf tipoPermiso = "TPTA02" Then
            Return "Permiso para el servicio aéreo regular de empresas extranjeras"
        ElseIf tipoPermiso = "TPTA03" Then
            Return "Permiso para el servicio nacional e internacional no regular de fletamento"
        ElseIf tipoPermiso = "TPTA04" Then
            Return "Permiso para el servicio nacional e internacional no regular de taxi aéreo"
        ElseIf tipoPermiso = "TPXX00" Then
            Return "Permiso no contemplado en el catálogo."
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerConfigAutotransporte(ByVal configVehicular As String) As String
        If configVehicular = "VL" Then
            Return "Vehículo ligero de carga (2 llantas en el eje delantero y 2 llantas en el eje trasero)"
        ElseIf configVehicular = "C2" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 4 llantas en el eje trasero)"
        ElseIf configVehicular = "C3" Then
            Return "Camión Unitario (2 llantas en el eje delantero y 6 o 8 llantas en los dos ejes traseros)"
        ElseIf configVehicular = "C2R2" Then
            Return "Camión-Remolque (6 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C3R2" Then
            Return "Camión-Remolque (10 llantas en el camión y 8 llantas en remolque)"
        ElseIf configVehicular = "C2R3" Then
            Return "Camión-Remolque (6 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "C3R3" Then
            Return "Camión-Remolque (10 llantas en el camión y 12 llantas en remolque)"
        ElseIf configVehicular = "T2S1" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S2" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S3" Then
            Return "Tractocamión Articulado (6 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S1" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 4 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S2" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 8 llantas en el semirremolque)"
        ElseIf configVehicular = "T3S3" Then
            Return "Tractocamión Articulado (10 llantas en el tractocamión, 12 llantas en el semirremolque)"
        ElseIf configVehicular = "T2S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T2S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (6 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S1R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 4 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R2" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 8 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R3" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 12 llantas en el remolque)"
        ElseIf configVehicular = "T3S2R4" Then
            Return "Tractocamión Semirremolque-Remolque (10 llantas en el tractocamión, 8 llantas en el semirremolque y 16 llantas en el remolque)"
        ElseIf configVehicular = "T2S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (6 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S2S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 8 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "T3S3S2" Then
            Return "Tractocamión Semirremolque-Semirremolque (10 llantas en el tractocamión, 12 llantas en el semirremolque delantero y 8 llantas en el semirremolque trasero)"
        ElseIf configVehicular = "OTROEVGP" Then
            Return "Especializado de carga Voluminosa y/o Gran Peso"
        ElseIf configVehicular = "OTROSG" Then
            Return "Servicio de Grúas"
        ElseIf configVehicular = "GPLUTA" Then
            Return "Grúa de Pluma Tipo A"
        ElseIf configVehicular = "GPLUTB" Then
            Return "Grúa de Pluma Tipo B"
        ElseIf configVehicular = "GPLUTC" Then
            Return "Grúa de Pluma Tipo C"
        ElseIf configVehicular = "GPLUTD" Then
            Return "Grúa de Pluma Tipo D"
        ElseIf configVehicular = "GPLATA" Then
            Return "Grúa de Plataforma Tipo A"
        ElseIf configVehicular = "GPLATB" Then
            Return "Grúa de Plataforma Tipo B"
        ElseIf configVehicular = "GPLATC" Then
            Return "Grúa de Plataforma Tipo C"
        ElseIf configVehicular = "GPLATD" Then
            Return "Grúa de Plataforma Tipo D"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerConfigMaritima(ByVal configMaritima As String) As String
        If configMaritima = "B01" Then
            Return "Abastecedor"
        ElseIf configMaritima = "B02" Then
            Return "Barcaza"
        ElseIf configMaritima = "B03" Then
            Return "Granelero"
        ElseIf configMaritima = "B04" Then
            Return "Porta Contenedor"
        ElseIf configMaritima = "B05" Then
            Return "Draga"
        ElseIf configMaritima = "B06" Then
            Return "Pesquero"
        ElseIf configMaritima = "B07" Then
            Return "Carga General"
        ElseIf configMaritima = "B08" Then
            Return "Quimiqueros"
        ElseIf configMaritima = "B09" Then
            Return "Transbordadores"
        ElseIf configMaritima = "B10" Then
            Return "Carga RoRo"
        ElseIf configMaritima = "B11" Then
            Return "Investigación"
        ElseIf configMaritima = "B12" Then
            Return "Tanquero"
        ElseIf configMaritima = "B13" Then
            Return "Gasero"
        ElseIf configMaritima = "B14" Then
            Return "Remolcador"
        ElseIf configMaritima = "B15" Then
            Return "Extraordinaria especialización"
        Else
            Return ""
        End If
    End Function

    Private Shared Function ObtenerTipoCarga(ByVal tipoCarga As String) As String
        If tipoCarga = "CGS" Then
            Return "Carga General Suelta"
        ElseIf tipoCarga = "CGC" Then
            Return "Carga General Contenerizada"
        ElseIf tipoCarga = "GMN" Then
            Return "Gran Mineral"
        ElseIf tipoCarga = "GAG" Then
            Return "Granel Agrícola"
        ElseIf tipoCarga = "OFL" Then
            Return "Otros Fluidos"
        ElseIf tipoCarga = "PYD" Then
            Return "Petróleo y Derivados"
        Else
            Return ""
        End If
    End Function
#End Region


    Private Shared Function CmAFloat(ByVal centimetro As Single) As Single
        Return centimetro * 28.3464565F
    End Function

    Private Shared Function CmAFloat(ByVal centimetro As Single()) As Single()
        For i As Integer = 0 To centimetro.Length - 1
            centimetro(i) = centimetro(i) * 28.3464565F
        Next

        Return centimetro
    End Function

    '#Region "Escribir datos en el .pdf"


    '    Private Sub NAgregarTitulo()
    '        Dim titulo As New StringBuilder()
    '        titulo.Append("Recibo pago de nómina ")
    '        If _comprobante.Complemento.Nomina.Receptor.PeriodicidadPago = "02" Then
    '            titulo.Append("Semanal      del ")
    '        End If
    '        If _comprobante.Complemento.Nomina.Receptor.PeriodicidadPago = "03" Then
    '            titulo.Append("Catorcenal      del ")
    '        End If
    '        If _comprobante.Complemento.Nomina.Receptor.PeriodicidadPago = "04" Then
    '            titulo.Append("Quincenal      del ")
    '        End If
    '        If _comprobante.Complemento.Nomina.Receptor.PeriodicidadPago = "05" Then
    '            titulo.Append("Mensual      del ")
    '        End If
    '        If _comprobante.Complemento.Nomina.Receptor.PeriodicidadPago = "10" Then
    '            titulo.Append("Decenal      del ")
    '        End If
    '        Dim fecha As New DateTime()
    '        DateTime.TryParse(_comprobante.Complemento.Nomina.FechaInicialPago, fecha)
    '        titulo.Append(fecha.ToShortDateString() + " ")
    '        titulo.Append("  al ")
    '        DateTime.TryParse(_comprobante.Complemento.Nomina.FechaFinalPago, fecha)
    '        titulo.Append(fecha.ToShortDateString() + " ")
    '        Dim p1 As New Paragraph()

    '        p1.Alignment = Element.ALIGN_CENTER
    '        p1.Add(New Phrase(titulo.ToString(), New Font(Font.FontFamily.HELVETICA, 16, Font.BOLD)))

    '        _documento.Add(p1)
    '    End Sub

    '    Private Sub NAgregarTabla(logo As System.Drawing.Image)
    '        Dim columnas As Single() = {565.0F}
    '        Dim tablaDatos As New PdfPTable(columnas)
    '        tablaDatos.SetTotalWidth(columnas)
    '        tablaDatos.SpacingBefore = 10
    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaDatos.LockedWidth = True

    '        tablaDatos.AddCell(AgregarDatosLaborales(logo))
    '        tablaDatos.AddCell(NAgregarEmisor())
    '        tablaDatos.AddCell(NAgregarPercepcionesDeducciones())


    '        _documento.Add(tablaDatos)

    '        Dim colTotalNeto As Single() = {405.0F, 90, 70}
    '        Dim tablaTotalNeto As New PdfPTable(colTotalNeto)
    '        'tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER;
    '        tablaTotalNeto.SetTotalWidth(colTotalNeto)
    '        tablaTotalNeto.SpacingBefore = 0
    '        'tablaTotalNeto.HorizontalAlignment = Rectangle.ALIGN_RIGHT;
    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaTotalNeto.LockedWidth = True

    '        Dim celdab As New PdfPCell(New Phrase("", New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdab.HorizontalAlignment = Rectangle.ALIGN_RIGHT
    '        celdab.Border = Rectangle.NO_BORDER
    '        tablaTotalNeto.AddCell(celdab)

    '        tablaTotalNeto.AddCell(New Phrase("Neto a recibir:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaTotal As New PdfPCell(New Phrase(_comprobante.Total.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaTotal.HorizontalAlignment = Rectangle.ALIGN_RIGHT
    '        tablaTotalNeto.AddCell(celdaTotal)

    '        _documento.Add(tablaTotalNeto)
    '    End Sub

    '    Private Function AgregarDatosLaborales(logoEmpresa As System.Drawing.Image) As PdfPTable
    '        Dim columnas As Single() = {120.0F, 60.0F, 100.0F, 60.0F, 80.0F, 70.0F, _
    '            75.0F}
    '        Dim tablaDatos As New PdfPTable(columnas)
    '        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaDatos.SetTotalWidth(columnas)

    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaDatos.LockedWidth = True

    '        'Agregar logo
    '        If logoEmpresa IsNot Nothing Then
    '            Dim imagen As Image = Image.GetInstance(logoEmpresa, BaseColor.BLACK)
    '            imagen.ScaleToFit(120, 120)
    '            Dim cell As New PdfPCell(imagen)
    '            cell.Rowspan = 6
    '            cell.HorizontalAlignment = Rectangle.ALIGN_CENTER
    '            cell.Border = Rectangle.NO_BORDER
    '            tablaDatos.AddCell(cell)
    '        Else

    '            Dim celdaVacia As New PdfPCell(New Phrase())
    '            celdaVacia.Rowspan = 6
    '            celdaVacia.Border = Rectangle.NO_BORDER
    '            tablaDatos.AddCell(celdaVacia)
    '        End If

    '        tablaDatos.AddCell(New Phrase("Núm.", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.NumEmpleado, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Trabajador", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaNombre As New PdfPCell(New Phrase(_comprobante.Receptor.Nombre, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaNombre.Border = Rectangle.NO_BORDER
    '        celdaNombre.Colspan = 4
    '        tablaDatos.AddCell(celdaNombre)
    '        tablaDatos.AddCell(New Phrase("CURP", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.Curp, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Dias Periodo", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.NumDiasPagados, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Cuota diaria", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.SalarioBaseCotApor.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("R.F.C", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Receptor.Rfc, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Tipo jornada", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        If _comprobante.Complemento.Nomina.Receptor.TipoJornada = "01" Then
    '            tablaDatos.AddCell(New Phrase("Diurna", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "02" Then
    '            tablaDatos.AddCell(New Phrase("Nocturna", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "03" Then
    '            tablaDatos.AddCell(New Phrase("Mixta", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "04" Then
    '            tablaDatos.AddCell(New Phrase("Por hora", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "05" Then
    '            tablaDatos.AddCell(New Phrase("Reducida", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "06" Then
    '            tablaDatos.AddCell(New Phrase("Continuada", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "07" Then
    '            tablaDatos.AddCell(New Phrase("Partida", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "08" Then
    '            tablaDatos.AddCell(New Phrase("Por turnos", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "99" Then
    '            tablaDatos.AddCell(New Phrase("OtraJornada", New Font(Font.FontFamily.HELVETICA, 8)))
    '        Else
    '            tablaDatos.AddCell(New Phrase("", New Font(Font.FontFamily.HELVETICA, 8)))
    '        End If


    '        tablaDatos.AddCell(New Phrase("Integrado", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.SalarioDiarioIntegrado.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("IMSS", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.NumSeguridadSocial, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Horas jornada", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        If _comprobante.Complemento.Nomina.Receptor.TipoJornada = "01" Then
    '            'DIURNA
    '            tablaDatos.AddCell(New Phrase("8", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "02" Then
    '            'NOCTURTO
    '            tablaDatos.AddCell(New Phrase("7", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoJornada = "03" Then
    '            'MIXTO
    '            tablaDatos.AddCell(New Phrase("7.3", New Font(Font.FontFamily.HELVETICA, 8)))
    '        Else
    '            tablaDatos.AddCell(New Phrase("", New Font(Font.FontFamily.HELVETICA, 8)))
    '        End If

    '        tablaDatos.AddCell(New Phrase("Sub. Causado", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(NObtenerSubsidioCausado().ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))

    '        'tablaDatos.AddCell(new Phrase("Sub. Empleo", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
    '        'tablaDatos.AddCell(new Phrase(_templatePDF.nomina.totalPercepciones.ToString("C2"), new Font(Font.FontFamily.HELVETICA, 8)));
    '        tablaDatos.AddCell(New Phrase("Regimen", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        If _comprobante.Complemento.Nomina.Receptor.TipoRegimen = "02" Then
    '            tablaDatos.AddCell(New Phrase("Sueldos", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoRegimen = "07" Then
    '            tablaDatos.AddCell(New Phrase("Asimilados Miembros consejos", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoRegimen = "08" Then
    '            tablaDatos.AddCell(New Phrase("Asimilados comisionistas", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoRegimen = "09" Then
    '            tablaDatos.AddCell(New Phrase("Asimilados Honorarios", New Font(Font.FontFamily.HELVETICA, 8)))
    '        ElseIf _comprobante.Complemento.Nomina.Receptor.TipoRegimen = "10" Then
    '            tablaDatos.AddCell(New Phrase("Asimilados acciones", New Font(Font.FontFamily.HELVETICA, 8)))
    '        Else
    '            tablaDatos.AddCell(New Phrase(" ", New Font(Font.FontFamily.HELVETICA, 8)))
    '        End If
    '        tablaDatos.AddCell(New Phrase("Ing. Gravado", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Percepciones.TotalGravado.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))


    '        tablaDatos.AddCell(New Phrase("Ingreso exento", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Percepciones.TotalExento.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Puesto", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))

    '        Dim celdaPuesto As New PdfPCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.Puesto, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaPuesto.Border = Rectangle.NO_BORDER
    '        celdaPuesto.Colspan = 2
    '        tablaDatos.AddCell(celdaPuesto)

    '        tablaDatos.AddCell(New Phrase("Departamento", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaDepartamento As New PdfPCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.Departamento, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaDepartamento.Border = Rectangle.NO_BORDER
    '        celdaDepartamento.Colspan = 2
    '        tablaDatos.AddCell(celdaDepartamento)


    '        Return tablaDatos
    '    End Function

    '    Private Function NAgregarEmisor() As PdfPTable
    '        Dim columnas As Single() = {80.0F, 164.0F, 50.0F, 90.0F, 80.0F, 100.0F}
    '        Dim tablaDatos As New PdfPTable(columnas)
    '        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaDatos.SetTotalWidth(columnas)
    '        tablaDatos.SpacingBefore = 5
    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaDatos.LockedWidth = True

    '        tablaDatos.AddCell(New Phrase("Patrón/Emisor:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaRFC As New PdfPCell(New Phrase(_comprobante.Emisor.Nombre, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaRFC.Border = Rectangle.NO_BORDER
    '        celdaRFC.Colspan = 5
    '        tablaDatos.AddCell(celdaRFC)
    '        tablaDatos.AddCell(New Phrase("Dirección:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaDireccion As New PdfPCell(New Phrase("Direccion", New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaDireccion.Border = Rectangle.NO_BORDER
    '        celdaDireccion.Colspan = 5
    '        tablaDatos.AddCell(celdaDireccion)
    '        tablaDatos.AddCell(New Phrase("R.F.C.:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Emisor.Rfc, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("IMSS:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Emisor.RegistroPatronal, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Riesgo Puesto:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.Receptor.RiesgoPuesto, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Regimen fiscal:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaRegimen As New PdfPCell(New Phrase(_comprobante.Emisor.RegimenFiscal, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaRegimen.Border = Rectangle.NO_BORDER
    '        celdaRegimen.Colspan = 3
    '        tablaDatos.AddCell(celdaRegimen)
    '        tablaDatos.AddCell(New Phrase("Fecha de pago:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.Nomina.FechaPago, New Font(Font.FontFamily.HELVETICA, 8)))

    '        Return tablaDatos

    '    End Function

    '    Private Function NAgregarPercepcionesDeducciones() As PdfPTable
    '        Dim anchoColumnasTablaProductos As Single() = {280.0F, 280.0F}
    '        Dim tablaProductosPrincipal As New PdfPTable(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaProductosPrincipal.SetTotalWidth(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.SpacingBefore = 0
    '        tablaProductosPrincipal.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductosPrincipal.LockedWidth = True


    '        'Datos de los productos
    '        Dim tamanoColumnas As Single() = {190.0F, 90.0F}
    '        Dim tablaPercepciones As New PdfPTable(tamanoColumnas)
    '        tablaPercepciones.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaPercepciones.SetTotalWidth(tamanoColumnas)
    '        tablaPercepciones.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaPercepciones.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaPercepciones.LockedWidth = True

    '        Dim celdaTituloPercepciones As New PdfPCell(New Phrase("PERCEPCIONES", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        celdaTituloPercepciones.Colspan = 2
    '        celdaTituloPercepciones.HorizontalAlignment = Element.ALIGN_CENTER
    '        celdaTituloPercepciones.Border = Rectangle.NO_BORDER
    '        tablaPercepciones.AddCell(celdaTituloPercepciones)

    '        Dim celdaConcepto As New PdfPCell(New Phrase("Concepto", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        celdaConcepto.HorizontalAlignment = Element.ALIGN_LEFT
    '        celdaConcepto.Right = -1
    '        tablaPercepciones.AddCell(celdaConcepto)

    '        Dim celdaImporte As New PdfPCell(New Phrase("Importe", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        celdaImporte.HorizontalAlignment = Element.ALIGN_RIGHT
    '        tablaPercepciones.AddCell(celdaImporte)

    '        For Each p As NPercepcion In _comprobante.Complemento.Nomina.Percepciones.Percepcion
    '            tablaPercepciones.AddCell(New Phrase(p.Concepto, New Font(Font.FontFamily.HELVETICA, 8)))
    '            Dim importe As New PdfPCell(New Phrase((p.ImporteExento + p.ImporteGravado).ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.Border = Rectangle.RIGHT_BORDER
    '            'tablaProductos.AddCell(new Phrase(p.importe, new Font(Font.FontFamily.HELVETICA, 8)));
    '            tablaPercepciones.AddCell(importe)
    '        Next

    '        If _comprobante.Complemento.Nomina.OtrosPagos.OtroPago.Count > 0 Then
    '            tablaPercepciones.AddCell(New Phrase("Otros Pagos", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '            Dim otrosPagos As New PdfPCell()
    '            otrosPagos.Border = Rectangle.RIGHT_BORDER
    '            tablaPercepciones.AddCell(otrosPagos)
    '            For Each p As NOtroPago In _comprobante.Complemento.Nomina.OtrosPagos.OtroPago
    '                tablaPercepciones.AddCell(New Phrase(p.Concepto, New Font(Font.FontFamily.HELVETICA, 8)))
    '                Dim importe As New PdfPCell(New Phrase((p.Importe).ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '                importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '                importe.Border = Rectangle.RIGHT_BORDER
    '                'tablaProductos.AddCell(new Phrase(p.importe, new Font(Font.FontFamily.HELVETICA, 8)));
    '                tablaPercepciones.AddCell(importe)
    '            Next
    '        End If
    '        tablaPercepciones.AddCell(New Phrase("Suma de percepciones", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))

    '        Dim totalPercepciones As Single = _comprobante.Complemento.Nomina.TotalPercepciones
    '        Dim celdaTotalPercepciones As New PdfPCell(New Phrase(totalPercepciones.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaTotalPercepciones.HorizontalAlignment = Element.ALIGN_RIGHT
    '        celdaTotalPercepciones.Border = Rectangle.RIGHT_BORDER
    '        tablaPercepciones.AddCell(celdaTotalPercepciones)

    '        'Datos de los productos
    '        Dim tamanoColumnasPercepciones As Single() = {190.0F, 90.0F}
    '        Dim tablaDeducciones As New PdfPTable(tamanoColumnas)
    '        tablaDeducciones.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaDeducciones.SetTotalWidth(tamanoColumnas)
    '        tablaDeducciones.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaDeducciones.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaDeducciones.LockedWidth = True


    '        Dim celdaTituloDeducciones As New PdfPCell(New Phrase("DEDUCCIONES", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        celdaTituloDeducciones.Border = Rectangle.NO_BORDER
    '        celdaTituloDeducciones.HorizontalAlignment = Element.ALIGN_CENTER
    '        celdaTituloDeducciones.Colspan = 2
    '        tablaDeducciones.AddCell(celdaTituloDeducciones)

    '        tablaDeducciones.AddCell(celdaConcepto)
    '        tablaDeducciones.AddCell(celdaImporte)
    '        For Each p As NDeduccion In _comprobante.Complemento.Nomina.Deducciones.Deduccion
    '            tablaDeducciones.AddCell(New Phrase(p.Concepto, New Font(Font.FontFamily.HELVETICA, 8)))
    '            Dim importe As New PdfPCell(New Phrase(New Phrase((p.Importe).ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8))))
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.Border = Rectangle.NO_BORDER
    '            'tablaProductos.AddCell(new Phrase(p.importe, new Font(Font.FontFamily.HELVETICA, 8)));
    '            tablaDeducciones.AddCell(importe)
    '        Next

    '        tablaDeducciones.AddCell(New Phrase("Suma de deducciones", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))

    '        Dim celdaTotalDeducciones As New PdfPCell(New Phrase(_comprobante.Descuento.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaTotalDeducciones.Border = Rectangle.NO_BORDER
    '        celdaTotalDeducciones.HorizontalAlignment = Element.ALIGN_RIGHT
    '        tablaDeducciones.AddCell(celdaTotalDeducciones)

    '        'tablaDeducciones.FooterRows = 1;

    '        Dim celdaTitulos As New PdfPCell(tablaPercepciones)
    '        celdaTitulos.Right = -5
    '        celdaTitulos.Border = Rectangle.NO_BORDER
    '        tablaProductosPrincipal.AddCell(celdaTitulos)
    '        Dim celdaProductos As New PdfPCell(tablaDeducciones)
    '        celdaProductos.Border = Rectangle.NO_BORDER
    '        tablaProductosPrincipal.AddCell(celdaProductos)


    '        Return tablaProductosPrincipal
    '    End Function

    '    Private Function NObtenerSubsidioCausado() As Single
    '        Dim totalSubsidiosCausado As Single = 0.0F
    '        For Each item As NOtroPago In _comprobante.Complemento.Nomina.OtrosPagos.OtroPago
    '            If item.Concepto = "Subsidio efectivo" Then
    '                totalSubsidiosCausado = item.SubsidioAlEmpleo.SubsidioCausado

    '            End If
    '        Next
    '        Return totalSubsidiosCausado
    '    End Function

    '    Private Sub NAgregarMensaje()
    '        Dim columnas As Single() = {565}
    '        Dim tablaDatos As New PdfPTable(columnas)
    '        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaDatos.SetTotalWidth(columnas)
    '        tablaDatos.SpacingBefore = 25
    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaDatos.LockedWidth = True

    '        Dim celdaLinea As New PdfPCell(New Phrase("___________________________________", New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaLinea.Border = Rectangle.NO_BORDER
    '        celdaLinea.HorizontalAlignment = Rectangle.ALIGN_CENTER
    '        tablaDatos.AddCell(celdaLinea)
    '        Dim celdaNombre As New PdfPCell(New Phrase(_comprobante.Receptor.Nombre, New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        celdaNombre.Border = Rectangle.NO_BORDER
    '        celdaNombre.HorizontalAlignment = Rectangle.ALIGN_CENTER
    '        tablaDatos.AddCell(celdaNombre)
    '        tablaDatos.AddCell(New Phrase("El importe de este recibo cubre toda percepción, deducción, subsidio fiscal, descansos y prestaciones legales por mi trabajo a éste patrón (o derivadas de la prestación de servicios independientes a éste Emisor) por el periodo marcado, no quedando cantidad alguna por pagar o prestación por reclamar.", New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Acepto y me doy por pagado en forma y tiempo, segun lo marcado en las Leyes Fiscales y Laborales vigentes, quedando pendiente la recepción del archivo CFDI a mi dirección de correo electrónico, la que me ha sido solicitada y que haré saber en su oportunidad a éste Patrón o Emisor.", New Font(Font.FontFamily.HELVETICA, 8)))

    '        _documento.Add(tablaDatos)
    '    End Sub

    '    Private Sub NAgregarDatosFiscales()
    '        Dim columnas As Single() = {125.0F, 80.0F, 160.0F, 100.0F, 100.0F}
    '        Dim tablaDatos As New PdfPTable(columnas)
    '        tablaDatos.SetTotalWidth(columnas)
    '        tablaDatos.SpacingBefore = 10
    '        'tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT;
    '        tablaDatos.LockedWidth = True

    '        Dim celdaUI As New PdfPCell(New Phrase("Representación parcial del CFDI correspondiente al UUID/ Folio fiscal:     " + _comprobante.Complemento.TimbreFiscalDigital.UUID, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaUI.Colspan = 5
    '        celdaUI.HorizontalAlignment = Rectangle.ALIGN_CENTER
    '        tablaDatos.AddCell(celdaUI)

    '        'Agregamos el codigo QR al documento
    '        Dim codigoQR As New StringBuilder()
    '        codigoQR.Append("?re" + _comprobante.Emisor.Rfc)
    '        'RFC del Emisor
    '        codigoQR.Append("&rr" + _comprobante.Receptor.Rfc)
    '        'RFC del receptor
    '        codigoQR.Append("&tt" + _comprobante.Total)
    '        'Total del comprobante 10 enteros y 6 decimales
    '        codigoQR.Append("&id" + _comprobante.Complemento.TimbreFiscalDigital.UUID)
    '        'UUID del comprobante
    '        Dim pdfCodigoQR As New BarcodeQRCode(codigoQR.ToString(), 1, 1, Nothing)
    '        Dim img As Image = pdfCodigoQR.GetImage()
    '        img.SpacingAfter = 0.0F
    '        img.SpacingBefore = 0.0F
    '        img.BorderWidth = 1.0F
    '        img.ScaleAbsolute(100.0F, 100.0F)
    '        'img.ScalePercent(100, 100);
    '        'img.border
    '        Dim celdaQR As New PdfPCell(img)
    '        celdaQR.Rowspan = 5
    '        celdaQR.FixedHeight = 105
    '        celdaQR.HorizontalAlignment = Rectangle.ALIGN_CENTER
    '        celdaQR.VerticalAlignment = Rectangle.ALIGN_MIDDLE

    '        tablaDatos.AddCell(celdaQR)


    '        tablaDatos.AddCell(New Phrase("Total:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Total.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))
    '        Dim ffolio As New Phrase()
    '        ffolio.Add(New Chunk("Folio: ", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        ffolio.Add(New Chunk(_comprobante.Folio, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(ffolio)

    '        Dim fMetodoPao As New Phrase()
    '        fMetodoPao.Add(New Chunk("Metodo de pago: ", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        fMetodoPao.Add(New Chunk(_comprobante.MetodoPago, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(fMetodoPao)


    '        'tablaDatos.AddCell(new Phrase(_templatePDF.folio, new Font(Font.FontFamily.HELVETICA, 8)));
    '        'Agregar Totales
    '        tablaDatos.AddCell(New Phrase("Importe con letra:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        Dim celdaImporteLetra As New PdfPCell(New Phrase(_comprobante.TotalLetra, New Font(Font.FontFamily.HELVETICA, 8)))
    '        celdaImporteLetra.Colspan = 3
    '        tablaDatos.AddCell(celdaImporteLetra)
    '        tablaDatos.AddCell(New Phrase("Fecha y hora de certificación:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Lugar" & vbLf & "Fecha de expedición:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.LugarExpedicion + vbLf + _comprobante.Fecha, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Certificado SAT:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT, New Font(Font.FontFamily.HELVETICA, 8)))
    '        tablaDatos.AddCell(New Phrase("Forma de pago:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaDatos.AddCell(New Phrase(_comprobante.FormaPago, New Font(Font.FontFamily.HELVETICA, 8)))

    '        Dim parrafoSelloSAT As New Phrase()
    '        parrafoSelloSAT.Add((New Chunk("Sello SAT" & vbLf, New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))))
    '        parrafoSelloSAT.Add(New Chunk(_comprobante.Complemento.TimbreFiscalDigital.SelloSAT, New Font(Font.FontFamily.HELVETICA, 8)))
    '        Dim celdaSelloSAT As New PdfPCell(parrafoSelloSAT)
    '        celdaSelloSAT.Colspan = 4
    '        tablaDatos.AddCell(celdaSelloSAT)

    '        Dim parrafoSelloDE As New Phrase()
    '        parrafoSelloDE.Add((New Chunk("Sello digital Emisor" & vbLf, New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))))
    '        parrafoSelloDE.Add(New Chunk(_comprobante.Complemento.TimbreFiscalDigital.SelloCFD, New Font(Font.FontFamily.HELVETICA, 8)))
    '        Dim celdaSDE As New PdfPCell(parrafoSelloDE)
    '        celdaSDE.Colspan = 5
    '        tablaDatos.AddCell(celdaSDE)

    '        Dim parrafoCadenaOriginal As New Phrase()
    '        parrafoCadenaOriginal.Add((New Chunk("Cadena original Complemento de certificado digital del SAT" & vbLf, New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD))))
    '        Dim cadenaOriginal As New StringBuilder()
    '        cadenaOriginal.Append("||")
    '        cadenaOriginal.Append("1.0|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.UUID + "|")
    '        cadenaOriginal.Append(_comprobante.Fecha.ToString() + "|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.SelloSAT + "|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT + "||")
    '        parrafoCadenaOriginal.Add(New Chunk(cadenaOriginal.ToString(), New Font(Font.FontFamily.HELVETICA, 8)))

    '        Dim celdaCadenaOriginal As New PdfPCell(parrafoCadenaOriginal)
    '        celdaCadenaOriginal.Colspan = 5
    '        tablaDatos.AddCell(celdaCadenaOriginal)

    '        _documento.Add(tablaDatos)

    '    End Sub

    '    Private Sub AgregarLogo(logoEmpresa As System.Drawing.Image)
    '        If logoEmpresa Is Nothing Then
    '            Return
    '        End If
    '        'Agrego la imagen al documento
    '        Dim imagen As Image = Image.GetInstance(logoEmpresa, BaseColor.BLACK)
    '        imagen.ScaleToFit(140, 140)
    '        imagen.Alignment = Element.ALIGN_RIGHT
    '        Dim logo As New Chunk(imagen, 1, -115)
    '        _documento.Add(logo)
    '    End Sub

    '    Private Sub AgregarCuadro()
    '        _cb = _writer.DirectContentUnder
    '        '_cb.SaveState();
    '        '_cb.BeginText();
    '        '_cb.MoveText(1, 1);
    '        '_cb.SetFontAndSize(_fuenteTitulos, 8);
    '        '_cb.ShowText("Faustino Rojas Arelano");
    '        '_cb.EndText();
    '        '_cb.RestoreState();

    '        'Agrego cuadro al documento
    '        _cb.SetColorStroke(BaseColor.BLACK)
    '        'Color de la linea
    '        _cb.SetColorFill(BaseColor.WHITE)
    '        ' Color del relleno
    '        _cb.SetLineWidth(1.5F)
    '        'Tamano de la linea
    '        _cb.Rectangle(408, 625, 195, 160)
    '        _cb.FillStroke()
    '    End Sub

    '    Private Sub AgregarDatosEmisorReceptor()

    '        'Datos del emisor
    '        Dim p1 As New Paragraph()
    '        p1.IndentationLeft = 150.0F
    '        p1.IndentationRight = 250.0F

    '        p1.Leading = 9
    '        p1.Alignment = Element.ALIGN_CENTER
    '        p1.Add(New Phrase(_comprobante.Emisor.Nombre, _fTitulo))
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase(_comprobante.Emisor.Rfc, _FNormal))
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase(Convert.ToString("Régimen fiscal: " + _comprobante.Emisor.RegimenFiscal + " - ") & ObtenerRegimenFiscal(_comprobante.Emisor.RegimenFiscal), _FNormal))
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase("CLIENTE", _fTitulo))
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase(_comprobante.Receptor.Nombre, _FNormal))
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase(_comprobante.Receptor.Rfc, _FNormal))
    '        p1.Add(vbLf)
    '        p1.Add(New Phrase(Convert.ToString("Uso de CFDI: " + _comprobante.Receptor.UsoCFDI + " - ") & ObtenerUsoCFDI(_comprobante.Receptor.UsoCFDI), _FNormal))
    '        If _comprobante.Receptor.ResidenciaFiscal <> String.Empty Then
    '            p1.Add(vbLf)
    '            p1.Add(New Phrase(_comprobante.Receptor.ResidenciaFiscal, New Font(Font.FontFamily.HELVETICA, 8)))
    '        End If
    '        If _comprobante.Receptor.NumRegIdTrib <> String.Empty Then
    '            p1.Add(vbLf)
    '            p1.Add(New Phrase(_comprobante.Receptor.NumRegIdTrib, New Font(Font.FontFamily.HELVETICA, 8)))
    '        End If
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        p1.Add(vbLf)
    '        _documento.Add(p1)
    '    End Sub

    '    Private Sub AgregaPropiedadesDocumento()
    '        _documento.AddAuthor("Advansys S.A de C.V")
    '        _documento.AddCreator("Sample application using iTextSharp")
    '        _documento.AddKeywords("Reporte de Hunter")
    '        _documento.AddSubject("Document subject - Describing the steps creating a PDF document")
    '        _documento.AddTitle("Reporte del sistema Hunter")
    '        _documento.SetMargins(5, 5, 20, 30)
    '    End Sub

    '    Private Function toFloat(valor As String) As Single
    '        Dim val As Single = 0.0F
    '        Single.TryParse(valor, val)
    '        Return val
    '    End Function

    '    Private Function toDecimal(valor As String) As Decimal
    '        Dim val As Decimal = 0
    '        Decimal.TryParse(valor, val)
    '        Return val
    '    End Function

    '    Private Sub AgregarDatosFactura()
    '        Dim anchoColumnas As Single() = {250.0F}
    '        Dim tablaDatos As New PdfPTable(anchoColumnas)
    '        'tablaProductosPrincipal.DefaultCell.Border = Rectangle.NO_BORDER;
    '        tablaDatos.DefaultCell.UseBorderPadding = False
    '        tablaDatos.SetTotalWidth(anchoColumnas)
    '        tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaDatos.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
    '        tablaDatos.DefaultCell.Padding = 1
    '        'tablaDatos.DefaultCell.FixedHeight = 13;
    '        'tablaProductosPrincipal.SpacingBefore = 15;
    '        tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaDatos.LockedWidth = True
    '        tablaDatos.AddCell(New Phrase("FACTURA NÚM: " + _comprobante.Serie + " " + _comprobante.Folio, _FNormalBold))
    '        tablaDatos.AddCell(New Phrase("FOLIO FISCAL (UUID): ", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.UUID, _FNormal))
    '        tablaDatos.AddCell(New Phrase("NO. DE SERIE DEL CERTIFICADO DEL SAT:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT, _FNormal))
    '        tablaDatos.AddCell(New Phrase("NO. DE SERIE DEL CERTIFICADO DEL EMISOR:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.NoCertificado, _FNormal))
    '        tablaDatos.AddCell(New Phrase("FECHA Y HORA DE CERTIFICACIÓN:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado, _FNormal))
    '        tablaDatos.AddCell(New Phrase("RFC PROVEEDOR DE CERTIFICACIÓN:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.RfcProvCertif, _FNormal))
    '        tablaDatos.AddCell(New Phrase("FECHA Y HORA DE EMISIÓN DE CFDI:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.Fecha, _FNormal))
    '        tablaDatos.AddCell(New Phrase("LUGAR DE EXPEDICIÓN:", _FNormalBold))
    '        tablaDatos.AddCell(New Phrase(_comprobante.LugarExpedicion, _FNormal))
    '        tablaDatos.WriteSelectedRows(0, -1, 382, 778, _writer.DirectContent)

    '        'Datos de la factura
    '        'Paragraph p2 = new Paragraph();
    '        'p2.IndentationLeft = 403f;

    '        'p2.SpacingAfter = 18;
    '        'p2.Leading = 10;
    '        'p2.Alignment = Element.ALIGN_CENTER;

    '        ' _documento.Add(p2);

    '        '/_cb.SaveState();
    '        '/_cb.BeginText();
    '        '/_cb.MoveText(1, 1);
    '        '/_cb.SetFontAndSize(_fuenteTitulos, 8);
    '        '/_cb.ShowText("Faustino Rojas Arelano");
    '        '/_cb.EndText();
    '        '/_cb.RestoreState();

    '        'PdfContentByte cb = _writer.DirectContent;

    '        'cb.BeginText();
    '        'cb.SetFontAndSize(_fuenteTitulos, 8);
    '        'ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, p2, 300, 500,0);
    '        'cb.EndText();
    '    End Sub

    '    Private Sub AgregarCfdiRelacionados()
    '        If _comprobante.CfdiRelacionados.CfdiRelacionado.Count <= 0 Then
    '            Return
    '        End If
    '        Dim anchoColumnas As Single() = {350.0F, 250.0F}
    '        Dim tablaCfdisRelacionados As New PdfPTable(anchoColumnas)
    '        tablaCfdisRelacionados.SetTotalWidth(anchoColumnas)
    '        tablaCfdisRelacionados.SpacingBefore = 7.0F
    '        tablaCfdisRelacionados.LockedWidth = True

    '        Dim ctitulo As New PdfPCell(New Phrase("CFDI´S RELACIONADOS", New Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.WHITE)))
    '        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
    '        ctitulo.VerticalAlignment = Element.ALIGN_CENTER
    '        ctitulo.Colspan = 2
    '        ctitulo.BackgroundColor = BaseColor.BLACK
    '        tablaCfdisRelacionados.AddCell(ctitulo)

    '        Dim anchoColRelacion As Single() = {250.0F}
    '        Dim tablaTipoRelacion As New PdfPTable(anchoColRelacion)
    '        tablaTipoRelacion.SpacingBefore = 0.0F
    '        tablaTipoRelacion.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaTipoRelacion.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
    '        tablaTipoRelacion.AddCell(New Phrase("Tipo de relación", _FNormalBold))
    '        tablaTipoRelacion.AddCell(New Phrase(Convert.ToString(_comprobante.CfdiRelacionados.TipoRelacion + " - ") & ObtenerTipoRelacion(_comprobante.CfdiRelacionados.TipoRelacion), _FNormal))
    '        tablaCfdisRelacionados.AddCell(tablaTipoRelacion)

    '        Dim anchocol As Single() = {250.0F}
    '        Dim tablacfdis As New PdfPTable(anchocol)
    '        tablacfdis.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablacfdis.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
    '        tablacfdis.SpacingBefore = 0.0F
    '        tablacfdis.AddCell(New Phrase("Folio fiscal", _FNormalBold))

    '        For Each item As CfdiRelacionado In _comprobante.CfdiRelacionados.CfdiRelacionado
    '            tablacfdis.AddCell(New Phrase(item.UUID, _FNormal))
    '        Next

    '        tablaCfdisRelacionados.AddCell(tablacfdis)
    '        _documento.Add(tablaCfdisRelacionados)

    '    End Sub

    '    Private Sub AgregarPagos10()
    '        If _comprobante.Complemento.Pagos.Pago.Count <= 0 Then Return
    '        Dim anchoColumnas As Single() = {600.0F}
    '        Dim tComplemento As PdfPTable = New PdfPTable(anchoColumnas)
    '        tComplemento.SetTotalWidth(anchoColumnas)
    '        tComplemento.SpacingBefore = 7.0F
    '        tComplemento.LockedWidth = True
    '        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("Complemento pagos V-" & _comprobante.Complemento.Pagos.Version, New Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.WHITE)))
    '        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
    '        ctitulo.VerticalAlignment = Element.ALIGN_CENTER
    '        ctitulo.BackgroundColor = BaseColor.BLACK
    '        tComplemento.AddCell(ctitulo)
    '        Dim acPagos As Single() = {100.0F, 100.0F, 100.0F, 100.0F, 100.0F, 100.0F}
    '        Dim tPagos As PdfPTable = New PdfPTable(acPagos)
    '        tPagos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tPagos.SetTotalWidth(acPagos)
    '        tPagos.SpacingBefore = 7.0F
    '        For Each pago As Pago In _comprobante.Complemento.Pagos.Pago
    '            If pago.FechaPago <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("Fecha de pago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.FechaPago, _FNormal))
    '            End If

    '            If pago.FormaDePagoP <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("Forma de pago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.FormaDePagoP, _FNormal))
    '            End If

    '            If pago.MonedaP <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("Moneda:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.MonedaP, _FNormal))
    '            End If

    '            If pago.TipoCambioP <> 0 Then
    '                tPagos.AddCell(New Paragraph("Tipo de cambio:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.TipoCambioP.ToString("C2"), _FNormal))
    '            End If

    '            If pago.Monto <> 0 Then
    '                tPagos.AddCell(New Paragraph("Monto:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.Monto.ToString("C2"), _FNormal))
    '            End If

    '            If pago.NumOperacion <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("Núm. de operación:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.NumOperacion, _FNormal))
    '            End If

    '            If pago.RfcEmisorCtaOrd <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("RFC Emisor Cta:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.RfcEmisorCtaOrd, _FNormal))
    '            End If

    '            If pago.NomBancoOrdExt <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("NomBancoOrdExt:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.NomBancoOrdExt, _FNormal))
    '            End If

    '            If pago.CtaOrdenante <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("CtaOrdenante:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.CtaOrdenante, _FNormal))
    '            End If

    '            If pago.RfcEmisorCtaOrd <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("RFC Emisor Cta:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.RfcEmisorCtaOrd, _FNormal))
    '            End If

    '            If pago.RfcEmisorCtaBen <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("RfcEmisorCtaBen:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.RfcEmisorCtaBen, _FNormal))
    '            End If

    '            If pago.CtaBeneficiario <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("CtaBeneficiario:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.CtaBeneficiario, _FNormal))
    '            End If

    '            If pago.TipoCadPago <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("TipoCadPago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.TipoCadPago, _FNormal))
    '            End If

    '            If pago.CertPago <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("CertPago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.CertPago, _FNormal))
    '            End If

    '            If pago.CadPago <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("CadPago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.CadPago, _FNormal))
    '            End If

    '            If pago.SelloPago <> String.Empty Then
    '                tPagos.AddCell(New Paragraph("SelloPago:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.SelloPago, _FNormal))
    '            End If

    '            tPagos.CompleteRow()
    '            If pago.DoctoRelacionado.Count > 0 Then
    '                Dim cdr As PdfPCell = New PdfPCell(New Paragraph("- Documentos relacionados", _FNormalBold))
    '                cdr.Border = Rectangle.NO_BORDER
    '                cdr.Colspan = 3
    '                tPagos.AddCell(cdr)
    '                tPagos.CompleteRow()
    '            End If

    '            For Each dr As PDoctoRelacionado In pago.DoctoRelacionado
    '                If dr.IdDocumento <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("IdDocumento:", _FNormalBold))
    '                    Dim cid As PdfPCell = New PdfPCell(New Paragraph(dr.IdDocumento, _FNormalBold))
    '                    cid.Colspan = 3
    '                    cid.Border = Rectangle.NO_BORDER
    '                    tPagos.AddCell(cid)
    '                End If

    '                If dr.Serie <> String.Empty OrElse dr.Folio <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Folio:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.Serie & " " + dr.Folio, _FNormal))
    '                End If

    '                If dr.MonedaDR <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Moneda:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.MonedaDR, _FNormal))
    '                End If

    '                If dr.TipoCambioDR <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Tipo de cambio:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.TipoCambioDR, _FNormal))
    '                End If

    '                If dr.NumParcialidad <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Núm. de parcialidad:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.NumParcialidad, _FNormal))
    '                End If

    '                If dr.ImpSaldoAnt <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Saldo anterior:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.ImpSaldoAnt.ToString("C2"), _FNormal))
    '                End If

    '                If dr.ImpPagado <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Importe pagado:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.ImpPagado.ToString("C2"), _FNormal))
    '                End If

    '                If dr.ImpSaldoInsoluto <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Saldo insoluto:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(dr.ImpSaldoInsoluto.ToString("C2"), _FNormal))
    '                End If

    '                tPagos.CompleteRow()
    '            Next

    '            tComplemento.AddCell(tPagos)
    '            If pago.Impuestos.Traslados.Count > 0 OrElse pago.Impuestos.Retenciones.Count > 0 Then
    '                Dim cdr As PdfPCell = New PdfPCell(New Paragraph("- Impuestos:", _FNormalBold))
    '                cdr.Colspan = 3
    '                tPagos.AddCell(cdr)
    '                tPagos.CompleteRow()
    '            End If

    '            For Each r As Retencion In pago.Impuestos.Retenciones
    '                If r.Impuesto <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Impuesto:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(r.Impuesto, _FNormal))
    '                End If

    '                If r.Importe <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Importe:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(r.Importe.ToString("C2"), _FNormal))
    '                End If

    '                tPagos.CompleteRow()
    '            Next

    '            For Each t As Traslado In pago.Impuestos.Traslados
    '                If t.Impuesto <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Impuesto:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(t.Impuesto, _FNormal))
    '                End If

    '                If t.TipoFactor <> String.Empty Then
    '                    tPagos.AddCell(New Paragraph("Tipo factor:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(t.TipoFactor, _FNormal))
    '                End If

    '                If t.TasaOCuota <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Tasa:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(t.TasaOCuota.ToString("C2"), _FNormal))
    '                End If

    '                If t.Importe <> 0 Then
    '                    tPagos.AddCell(New Paragraph("Importe:", _FNormalBold))
    '                    tPagos.AddCell(New Paragraph(t.Importe.ToString("C2"), _FNormal))
    '                End If

    '                tPagos.CompleteRow()
    '            Next

    '            If pago.Impuestos.TotalImpuestosRetenidos > 0 Then
    '                tPagos.AddCell(New Paragraph("Total impuestos retenidos:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.Impuestos.TotalImpuestosRetenidos.ToString("C2"), _FNormal))
    '                tPagos.CompleteRow()
    '            End If

    '            If pago.Impuestos.TotalImpuestosTrasladados > 0 Then
    '                tPagos.AddCell(New Paragraph("Total impuestos trasladados:", _FNormalBold))
    '                tPagos.AddCell(New Paragraph(pago.Impuestos.TotalImpuestosTrasladados.ToString("C2"), _FNormal))
    '                tPagos.CompleteRow()
    '            End If
    '        Next

    '        _documento.Add(tComplemento)
    '    End Sub

    '    Private Function AgregarCeldaString(ByVal valor As String) As PdfPCell
    '        Dim celdaValorUnitario As PdfPCell = New PdfPCell(New Phrase(valor, _fMediana))
    '        celdaValorUnitario.HorizontalAlignment = Element.ALIGN_LEFT
    '        celdaValorUnitario.BorderWidthLeft = 0.1F
    '        celdaValorUnitario.BorderWidthRight = 0.0F
    '        celdaValorUnitario.BorderWidthBottom = 0.0F
    '        celdaValorUnitario.BorderWidthTop = 0.0F
    '        Return celdaValorUnitario
    '    End Function

    '    Private Function AgregarCeldaStringFinal(ByVal valor As String) As PdfPCell
    '        Dim celdaValorUnitario As PdfPCell = New PdfPCell(New Phrase(valor, _fMediana))
    '        celdaValorUnitario.HorizontalAlignment = Element.ALIGN_LEFT
    '        celdaValorUnitario.BorderWidthLeft = 0.1F
    '        celdaValorUnitario.BorderWidthRight = 0.0F
    '        celdaValorUnitario.BorderWidthBottom = 0.1F
    '        celdaValorUnitario.BorderWidthTop = 0.0F
    '        Return celdaValorUnitario
    '    End Function

    '    Private Function AgregarCeldaCantidad(ByVal valor As String) As PdfPCell
    '        Dim celdaValorUnitario As PdfPCell = New PdfPCell(New Phrase(valor, _fMediana))
    '        celdaValorUnitario.HorizontalAlignment = Element.ALIGN_RIGHT
    '        celdaValorUnitario.BorderWidthLeft = 0.1F
    '        celdaValorUnitario.BorderWidthRight = 0.0F
    '        celdaValorUnitario.BorderWidthBottom = 0.0F
    '        celdaValorUnitario.BorderWidthTop = 0.0F
    '        Return celdaValorUnitario
    '    End Function
    '    Private Function AgregarColumna(ByVal Nombre As String) As PdfPCell
    '        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase(Nombre, _FNormalBold))
    '        ctitulo.HorizontalAlignment = Element.ALIGN_LEFT
    '        ctitulo.VerticalAlignment = Element.ALIGN_CENTER
    '        ctitulo.BackgroundColor = BaseColor.WHITE
    '        Return ctitulo
    '    End Function

    '    Private Sub AgregarDatosProductos()
    '        Dim anchoColumnasTablaProductos As Single() = {600.0F}
    '        Dim tablaProductosPrincipal As PdfPTable = New PdfPTable(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.SetTotalWidth(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.SpacingBefore = 7.0F
    '        tablaProductosPrincipal.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductosPrincipal.LockedWidth = True
    '        Dim tamanoColumnas As Single() = {50.0F, 60.0F, 310.0F, 90.0F, 90.0F}
    '        Dim tablaProductosTitulos As PdfPTable = New PdfPTable(tamanoColumnas)
    '        tablaProductosTitulos.SetTotalWidth(tamanoColumnas)
    '        tablaProductosTitulos.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductosTitulos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductosTitulos.LockedWidth = True
    '        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("CONCEPTOS", New Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.WHITE)))
    '        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
    '        ctitulo.VerticalAlignment = Element.ALIGN_CENTER
    '        ctitulo.Colspan = 5
    '        ctitulo.BackgroundColor = BaseColor.BLACK
    '        tablaProductosTitulos.AddCell(ctitulo)
    '        tablaProductosTitulos.AddCell(New Phrase("Cantidad", _FNormalBold))
    '        tablaProductosTitulos.AddCell(New Phrase("Unidad", _FNormalBold))
    '        tablaProductosTitulos.AddCell(New Phrase("Descripción", _FNormalBold))
    '        tablaProductosTitulos.AddCell(New Phrase("Precion unitario", _FNormalBold))
    '        tablaProductosTitulos.AddCell(New Phrase("Importe", _FNormalBold))
    '        Dim tamanoColumnasProductos As Single() = {50.0F, 60.0F, 310.0F, 90.0F, 90.0F}
    '        Dim tablaProductos As PdfPTable = New PdfPTable(tamanoColumnas)
    '        tablaProductos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductos.DefaultCell.BorderWidthLeft = 0.1F
    '        tablaProductos.DefaultCell.BorderWidthRight = 0.0F
    '        tablaProductos.DefaultCell.BorderWidthBottom = 0.0F
    '        tablaProductos.DefaultCell.BorderWidthTop = 0.0F
    '        tablaProductos.SetTotalWidth(tamanoColumnas)
    '        tablaProductos.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductos.LockedWidth = True
    '        For Each c As Concepto In _comprobante.Conceptos
    '            Dim descripcion As StringBuilder = New StringBuilder()
    '            tablaProductos.AddCell(New Phrase(c.Cantidad.ToString(), _fMediana))
    '            tablaProductos.AddCell(New Phrase(c.ClaveUnidad & " - " + getUnidad(c.ClaveUnidad), _fMediana))
    '            descripcion.Append(c.Descripcion & vbLf & "Clave Prod. Serv. " + c.ClaveProdServ)
    '            descripcion.Append(vbLf)
    '            If c.NoIdentificacion <> String.Empty Then descripcion.Append("No. Identificación - " & c.NoIdentificacion & vbLf)
    '            If c.Impuestos.Traslados.Count > 0 OrElse c.Impuestos.Retenciones.Count > 0 Then
    '                descripcion.Append("Impuestos:" & vbLf)
    '                If c.Impuestos.Traslados.Count > 0 Then
    '                    descripcion.Append("  Traslados:" & vbLf)
    '                    For Each t As TrasladoC In c.Impuestos.Traslados
    '                        descripcion.Append("    " & t.Impuesto & " " + getImpuesto(t.Impuesto) & " Base -" + t.Base.ToString("C2") & " Tasa -" + t.TasaOCuota.ToString("F6") & " Importe -" + t.Importe.ToString("C2") & vbLf)
    '                    Next
    '                End If

    '                If c.Impuestos.Retenciones.Count > 0 Then
    '                    For Each r As RetencionC In c.Impuestos.Retenciones
    '                        descripcion.Append("  Retenciones:" & vbLf)
    '                        descripcion.Append("    " & r.Impuesto & " " + getImpuesto(r.Impuesto) & " Base " + r.Base.ToString("C2") & " Tasa " + r.TasaOCuota.ToString("F6") & " Importe " + r.Importe.ToString("C2") & vbLf)
    '                    Next
    '                End If
    '            End If

    '            tablaProductos.AddCell(New Phrase(descripcion.ToString(), _fMediana))
    '            Dim celdaValorUnitario As PdfPCell = New PdfPCell(New Phrase(c.ValorUnitario.ToString("C2"), _fMediana))
    '            celdaValorUnitario.HorizontalAlignment = Element.ALIGN_RIGHT
    '            celdaValorUnitario.BorderWidthLeft = 0.1F
    '            celdaValorUnitario.BorderWidthRight = 0.0F
    '            celdaValorUnitario.BorderWidthBottom = 0.0F
    '            celdaValorUnitario.BorderWidthTop = 0.0F
    '            tablaProductos.AddCell(celdaValorUnitario)
    '            Dim importe As PdfPCell = New PdfPCell(New Phrase(c.Importe.ToString("C2"), _fMediana))
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.BorderWidthLeft = 0.1F
    '            importe.BorderWidthRight = 0.0F
    '            importe.BorderWidthBottom = 0.0F
    '            importe.BorderWidthTop = 0.0F
    '            tablaProductos.AddCell(importe)
    '        Next

    '        Dim celdaTitulos As PdfPCell = New PdfPCell(tablaProductosTitulos)
    '        tablaProductosPrincipal.AddCell(celdaTitulos)
    '        Dim celdaProductos As PdfPCell = New PdfPCell(tablaProductos)
    '        If _comprobante.TipoDeComprobante = "I" OrElse _comprobante.TipoDeComprobante = "E" Then celdaProductos.MinimumHeight = 300
    '        tablaProductosPrincipal.AddCell(celdaProductos)
    '        _documento.Add(tablaProductosPrincipal)
    '    End Sub

    '    Private Sub AgregarDatosProductos1()
    '        Dim anchoColumnasTablaProductos As Single() = {50.0F, 60.0F, 310.0F, 90.0F, 90.0F}
    '        Dim tablaProductosPrincipal As PdfPTable = New PdfPTable(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.SetTotalWidth(anchoColumnasTablaProductos)
    '        tablaProductosPrincipal.SpacingBefore = 7.0F
    '        tablaProductosPrincipal.SpacingAfter = 2.0F
    '        tablaProductosPrincipal.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaProductosPrincipal.LockedWidth = True
    '        Dim ctitulo As PdfPCell = New PdfPCell(New Phrase("CONCEPTOS", New Font(Font.FontFamily.HELVETICA, 7, Font.NORMAL, BaseColor.WHITE)))
    '        ctitulo.HorizontalAlignment = Element.ALIGN_CENTER
    '        ctitulo.VerticalAlignment = Element.ALIGN_CENTER
    '        ctitulo.Colspan = 5
    '        ctitulo.BackgroundColor = BaseColor.BLACK
    '        tablaProductosPrincipal.AddCell(ctitulo)
    '        tablaProductosPrincipal.AddCell(AgregarColumna("Cantidad"))
    '        tablaProductosPrincipal.AddCell(AgregarColumna("Unidad"))
    '        tablaProductosPrincipal.AddCell(AgregarColumna("Descripcion"))
    '        tablaProductosPrincipal.AddCell(AgregarColumna("Precio Unitario"))
    '        tablaProductosPrincipal.AddCell(AgregarColumna("Importe"))
    '        For Each c As Concepto In _comprobante.Conceptos.Concepto
    '            Dim descripcion As StringBuilder = New StringBuilder()
    '            tablaProductosPrincipal.AddCell(AgregarCeldaString(c.Cantidad.ToString()))
    '            tablaProductosPrincipal.AddCell(AgregarCeldaString(c.ClaveUnidad & " - " + ObtenerUnidad(c.ClaveUnidad)))
    '            descripcion.Append(c.Descripcion & vbLf & "Clave Prod. Serv. " + c.ClaveProdServ)
    '            descripcion.Append(vbLf)
    '            If c.NoIdentificacion <> String.Empty Then descripcion.Append("No. Identificación - " & c.NoIdentificacion & vbLf)
    '            If c.Impuestos.Retenciones.Count > 0 OrElse c.Impuestos.Traslados.Count > 0 Then
    '                descripcion.Append("Impuestos:" & vbLf)
    '                If c.Impuestos.Traslados.Count > 0 Then
    '                    descripcion.Append("  Traslados:" & vbLf)
    '                    For Each t As TrasladoC In c.Impuestos.Traslados
    '                        descripcion.Append("    " & t.Impuesto & " " + ObtenerImpuesto(t.Impuesto) & " Base -" + t.Base.ToString("C2") & " Tasa -" + t.TasaOCuota.ToString("F6") & " Importe -" + t.Importe.ToString("C2") & vbLf)
    '                    Next
    '                End If

    '                If c.Impuestos.Retenciones.Count > 0 Then
    '                    For Each r As RetencionC In c.Impuestos.Retenciones
    '                        descripcion.Append("  Retenciones:" & vbLf)
    '                        descripcion.Append("    " & r.Impuesto & " " + ObtenerImpuesto(r.Impuesto) & " Base " + r.Base.ToString("C2") & " Tasa " + r.TasaOCuota.ToString("F6") & " Importe " + r.Importe.ToString("C2") & vbLf)
    '                    Next
    '                End If
    '            End If

    '            tablaProductosPrincipal.AddCell(AgregarCeldaString(descripcion.ToString()))
    '            Dim celdaValorUnitario As PdfPCell = New PdfPCell(New Phrase(c.ValorUnitario.ToString("C2"), _fMediana))
    '            celdaValorUnitario.HorizontalAlignment = Element.ALIGN_RIGHT
    '            celdaValorUnitario.BorderWidthLeft = 0.1F
    '            celdaValorUnitario.BorderWidthRight = 0.0F
    '            celdaValorUnitario.BorderWidthBottom = 0.0F
    '            celdaValorUnitario.BorderWidthTop = 0.0F
    '            tablaProductosPrincipal.AddCell(celdaValorUnitario)
    '            Dim importe As PdfPCell = New PdfPCell(New Phrase(c.Importe.ToString("C2"), _fMediana))
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.HorizontalAlignment = Element.ALIGN_RIGHT
    '            importe.BorderWidthLeft = 0.1F
    '            importe.BorderWidthRight = 0.1F
    '            importe.BorderWidthBottom = 0.0F
    '            importe.BorderWidthTop = 0.0F
    '            tablaProductosPrincipal.AddCell(importe)
    '        Next

    '        If _comprobante.TipoDeComprobante = "I" OrElse _comprobante.TipoDeComprobante = "E" Then
    '            Dim completar As String = String.Empty
    '            If _comprobante.Conceptos.Concepto.Count < 8 Then
    '                Dim cuenta As Integer = 7 - _comprobante.Conceptos.Concepto.Count
    '                For i As Integer = 0 To cuenta - 1
    '                    completar += vbLf & vbLf & vbLf & vbLf & vbLf & vbLf
    '                Next
    '            End If

    '            tablaProductosPrincipal.AddCell(AgregarCeldaStringFinal(completar))
    '            tablaProductosPrincipal.AddCell(AgregarCeldaStringFinal(""))
    '            tablaProductosPrincipal.AddCell(AgregarCeldaStringFinal(""))
    '            tablaProductosPrincipal.AddCell(AgregarCeldaStringFinal(""))
    '            Dim final As PdfPCell = New PdfPCell(New Phrase("", _fMediana))
    '            final.HorizontalAlignment = Element.ALIGN_RIGHT
    '            final.HorizontalAlignment = Element.ALIGN_RIGHT
    '            final.BorderWidthLeft = 0.1F
    '            final.BorderWidthRight = 0.1F
    '            final.BorderWidthBottom = 0.1F
    '            final.BorderWidthTop = 0.0F
    '            tablaProductosPrincipal.AddCell(final)
    '        Else
    '            tablaProductosPrincipal.AddCell(AgregarCeldaStringFinal(""))
    '            tablaProductosPrincipal.CompleteRow()
    '        End If

    '        _documento.Add(tablaProductosPrincipal)
    '    End Sub

    '    Private Sub AgregarTotales()

    '        Dim anchoColumasTablaTotales As Single() = {400.0F, 200.0F}
    '        Dim tablaTotales As New PdfPTable(anchoColumasTablaTotales)
    '        tablaTotales.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaTotales.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaTotales.SetTotalWidth(anchoColumasTablaTotales)
    '        tablaTotales.HorizontalAlignment = Element.ALIGN_CENTER
    '        tablaTotales.LockedWidth = True

    '        Dim anchoColumnas As Single() = {130, 70.0F}
    '        Dim tablaImportes As New PdfPTable(anchoColumnas)
    '        tablaImportes.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaImportes.SetTotalWidth(anchoColumnas)
    '        tablaImportes.DefaultCell.HorizontalAlignment = Element.ALIGN_RIGHT
    '        'tablaImportes.HorizontalAlignment = Element.ALIGN_RIGHT;
    '        tablaImportes.LockedWidth = True

    '        tablaImportes.AddCell(New Phrase("SUBTOTAL:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaImportes.AddCell(New Phrase(_comprobante.SubTotal.ToString("C"), New Font(Font.FontFamily.HELVETICA, 8)))

    '        If _comprobante.Descuento > 0 Then
    '            tablaImportes.AddCell(New Phrase("DESCUENTO:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        End If

    '        If _comprobante.Impuestos.Traslados.Count > 0 Then
    '            For Each t As Traslado In _comprobante.Impuestos.Traslados
    '                tablaImportes.AddCell(New Phrase((Convert.ToString("TRASLADO ") & ObtenerImpuesto(t.Impuesto)) + " TASA " + t.TasaOCuota.ToString("F6"), _FNormalBold))
    '                tablaImportes.AddCell(New Phrase(t.Importe.ToString("C2"), _FNormal))
    '            Next
    '        End If
    '        If _comprobante.Impuestos.Retenciones.Count > 0 Then
    '            For Each r As Retencion In _comprobante.Impuestos.Retenciones
    '                tablaImportes.AddCell(New Phrase(Convert.ToString("RETENCIÓN ") & ObtenerImpuesto(r.Impuesto), _FNormalBold))
    '                tablaImportes.AddCell(New Phrase(r.Importe.ToString("C2"), _FNormal))
    '            Next
    '        End If

    '        tablaImportes.AddCell(New Phrase("Total:", New Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)))
    '        tablaImportes.AddCell(New Phrase(_comprobante.Total.ToString("C2"), New Font(Font.FontFamily.HELVETICA, 8)))

    '        Dim columnasLetra As Single() = {120, 280}
    '        Dim tablaImporteLetra As New PdfPTable(columnasLetra)
    '        tablaImporteLetra.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaImporteLetra.SetTotalWidth(columnasLetra)
    '        tablaImporteLetra.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        'tablaImportes.HorizontalAlignment = Element.ALIGN_RIGHT;
    '        tablaImporteLetra.LockedWidth = True


    '        tablaImporteLetra.AddCell(New Phrase("IMPORTE CON LETRA", _FNormalBold))
    '        tablaImporteLetra.AddCell(New Phrase(_comprobante.TotalLetra, _FNormal))

    '        tablaImporteLetra.AddCell(New Phrase("TIPO DE COMPROBANTE", _FNormalBold))
    '        tablaImporteLetra.AddCell(New Phrase(Convert.ToString(_comprobante.TipoDeComprobante + " ") & ObtenerTipoComprobante(_comprobante.TipoDeComprobante), _FNormal))

    '        If _comprobante.FormaPago <> String.Empty Then
    '            tablaImporteLetra.AddCell(New Phrase("FORMA DE PAGO", _FNormalBold))
    '            tablaImporteLetra.AddCell(New Phrase(Convert.ToString(_comprobante.FormaPago + " ") & ObtenerFormaPago(_comprobante.FormaPago), _FNormal))
    '        End If

    '        If _comprobante.MetodoPago <> String.Empty Then
    '            tablaImporteLetra.AddCell(New Phrase("MÉTODO DE PAGO", _FNormalBold))
    '            tablaImporteLetra.AddCell(New Phrase(Convert.ToString(_comprobante.MetodoPago + " ") & ObtenerMetodoPago(_comprobante.MetodoPago), _FNormal))
    '        End If

    '        tablaImporteLetra.AddCell(New Phrase("MONEDA", _FNormalBold))
    '        tablaImporteLetra.AddCell(New Phrase(Convert.ToString(_comprobante.Moneda + " ") & ObtenerMoneda(_comprobante.Moneda), _FNormal))


    '        'valorUnitario.Border = Rectangle.NO_BORDER;

    '        'foreach (ImpuestoCFD i in _comprobante.Impuestos)
    '        '{
    '        '    tablaImportes.AddCell(new Phrase(i.impuesto + " " + i.tasa.ToString("F2") + "%:", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
    '        '    tablaImportes.AddCell(new Phrase(i.importe.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));
    '        '}

    '        'foreach (RetencionCFD i in _comprobante.retenciones)
    '        '{
    '        '    tablaImportes.AddCell(new Phrase("Retencion " + i.impuesto + ": ", new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD)));
    '        '    tablaImportes.AddCell(new Phrase(i.importe.ToString("C"), new Font(Font.FontFamily.HELVETICA, 8)));
    '        '}



    '        tablaTotales.AddCell(tablaImporteLetra)
    '        tablaTotales.AddCell(tablaImportes)
    '        _documento.Add(tablaTotales)
    '    End Sub

    '    Private Sub AgregarSellos()
    '        Dim cadenaOriginal As New StringBuilder()
    '        cadenaOriginal.Append("||")
    '        cadenaOriginal.Append("1.1|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.UUID + "|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.FechaTimbrado + "|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.SelloCFD + "|")
    '        cadenaOriginal.Append(_comprobante.Complemento.TimbreFiscalDigital.NoCertificadoSAT + "||")

    '        Dim anchoColumnas As Single() = {100.0F, 480.0F}
    '        Dim tablaSellosQR As New PdfPTable(anchoColumnas)
    '        tablaSellosQR.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaSellosQR.SpacingBefore = 10.0F
    '        tablaSellosQR.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaSellosQR.SetTotalWidth(anchoColumnas)
    '        'tablaSellosQR.HorizontalAlignment = Element.ALIGN_CENTER;
    '        tablaSellosQR.LockedWidth = True

    '        Dim anchoColumnas1 As Single() = {480}
    '        Dim tablaSellos As New PdfPTable(anchoColumnas1)
    '        tablaSellos.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT
    '        tablaSellos.DefaultCell.VerticalAlignment = Element.ALIGN_TOP
    '        tablaSellos.DefaultCell.Border = Rectangle.NO_BORDER
    '        tablaSellos.SetTotalWidth(anchoColumnas1)
    '        tablaSellos.HorizontalAlignment = Element.ALIGN_CENTER
    '        'tablaSellos.LockedWidth = true;
    '        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL CFDI:", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
    '        tablaSellos.AddCell(New Phrase(_comprobante.Complemento.TimbreFiscalDigital.SelloCFD, New Font(Font.FontFamily.HELVETICA, 7)))
    '        tablaSellos.AddCell(New Phrase("SELLO DIGITAL DEL SAT", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
    '        tablaSellos.AddCell(New Phrase(_comprobante.Sello, New Font(Font.FontFamily.HELVETICA, 7)))
    '        tablaSellos.AddCell(New Phrase("CADENA ORIGINAL DEL COMPLEMENTO DE CERTIFICACIÓN DIGITAL DEL SAT:", New Font(Font.FontFamily.HELVETICA, 7, Font.BOLD)))
    '        tablaSellos.AddCell(New Phrase(cadenaOriginal.ToString(), New Font(Font.FontFamily.HELVETICA, 7)))

    '        'Agregamos el codigo QR al documento
    '        Dim codigoQR As New StringBuilder()
    '        codigoQR.Append("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx")
    '        'La URL del acceso al servicio que pueda mostrar los datos de la versión pública del comprobante.
    '        codigoQR.Append("&id=" + _comprobante.Complemento.TimbreFiscalDigital.UUID)
    '        'Número de folio fiscal del comprobante (UUID).
    '        codigoQR.Append("&re=" + _comprobante.Emisor.Rfc)
    '        'RFC del emisor.
    '        codigoQR.Append("&rr=" + _comprobante.Receptor.Rfc)
    '        'RFC del receptor.
    '        codigoQR.Append("&tt=" + _comprobante.Total.ToString())
    '        'Total del comprobante.
    '        Dim cuenta As Integer = _comprobante.Sello.Count()
    '        cuenta = cuenta - 8
    '        codigoQR.Append("&fe=" + _comprobante.Sello.Substring(cuenta))
    '        'Ocho últimos caracteres del sello digital del emisor del comprobante..
    '        Dim pdfCodigoQR As New BarcodeQRCode(codigoQR.ToString(), 1, 1, Nothing)
    '        Dim img As Image = pdfCodigoQR.GetImage()
    '        img.SpacingAfter = 0.0F
    '        img.SpacingBefore = 0.0F
    '        img.BorderWidth = 1.0F
    '        'img.ScalePercent(100, 78);
    '        'img.border

    '        tablaSellosQR.AddCell(img)
    '        tablaSellosQR.AddCell(tablaSellos)


    '        _documento.Add(tablaSellosQR)
    '    End Sub

    '#End Region

End Class

#Region "Extensión de la clase pdfPageEvenHelper"
Public Class ITextEvents
    Inherits PdfPageEventHelper

    ' This is the contentbyte object of the writer
    Private cb As PdfContentByte

    ' we will put the final number of pages in a template
    Private headerTemplate As PdfTemplate, footerTemplate As PdfTemplate

    ' this is the BaseFont we are going to use for the header / footer
    Private bf As BaseFont = Nothing

    ' This keeps track of the creation time
    Private PrintTime As DateTime = DateTime.Now


#Region "Fields"
    Private _header As String
#End Region

#Region "Properties"
    Public Property Header() As String
        Get
            Return _header
        End Get
        Set(value As String)
            _header = value
        End Set
    End Property
#End Region


    Public Overrides Sub OnOpenDocument(writer As PdfWriter, document As Document)
        Try
            PrintTime = DateTime.Now
            bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)
            cb = writer.DirectContent
            headerTemplate = cb.CreateTemplate(100, 100)
            footerTemplate = cb.CreateTemplate(50, 50)

        Catch de As DocumentException

        Catch ioe As System.IO.IOException
        End Try
    End Sub

    Public Overrides Sub OnEndPage(writer As iTextSharp.text.pdf.PdfWriter, document As iTextSharp.text.Document)
        MyBase.OnEndPage(writer, document)

        'iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

        'iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

        'Phrase p1Header = new Phrase("Sample Header Here", baseFontNormal);

        '/Create PdfTable object
        'PdfPTable pdfTab = new PdfPTable(3);

        '/We will have to create separate cells to include image logo and 2 separate strings
        '/Row 1
        'PdfPCell pdfCell1 = new PdfPCell();
        'PdfPCell pdfCell2 = new PdfPCell(p1Header);
        'PdfPCell pdfCell3 = new PdfPCell();
        Dim text As [String] = "Página " + writer.PageNumber.ToString() + " de "


        '/Add paging to header
        '{
        '    cb.BeginText();
        '    cb.SetFontAndSize(bf, 12);
        '    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
        '    cb.ShowText(text);
        '    cb.EndText();
        '    float len = bf.GetWidthPoint(text, 12);
        '    //Adds "12" in Page 1 of 12
        '    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
        '}

        'Add paging to footer
        If True Then
            cb.BeginText()
            cb.SetFontAndSize(bf, 9)
            cb.SetTextMatrix(document.PageSize.GetRight(70), document.PageSize.GetBottom(30))
            'cb.MoveText(500,30);
            'cb.ShowText("Este comprobante es una representación impresa de un CFDI");
            cb.ShowText(text)
            cb.EndText()
            Dim len As Single = bf.GetWidthPoint(text, 9)
            cb.AddTemplate(footerTemplate, document.PageSize.GetRight(70) + len, document.PageSize.GetBottom(30))

            Dim anchoColumasTablaTotales As Single() = {600.0F}
            Dim tabla As New PdfPTable(anchoColumasTablaTotales)
            tabla.DefaultCell.Border = Rectangle.NO_BORDER
            tabla.SetTotalWidth(anchoColumasTablaTotales)
            tabla.HorizontalAlignment = Element.ALIGN_CENTER
            tabla.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
            tabla.LockedWidth = True
            tabla.AddCell(New Phrase("Este documento es una representación impresa de un CFDI", New Font(Font.FontFamily.HELVETICA, 8)))
            tabla.WriteSelectedRows(0, -1, 5, document.PageSize.GetBottom(40), writer.DirectContent)



        End If



        '/Row 2
        'PdfPCell pdfCell4 = new PdfPCell(new Phrase("Sub Header Description", baseFontNormal));
        '/Row 3


        'PdfPCell pdfCell5 = new PdfPCell(new Phrase("Date:" + PrintTime.ToShortDateString(), baseFontBig));
        'PdfPCell pdfCell6 = new PdfPCell();
        'PdfPCell pdfCell7 = new PdfPCell(new Phrase("TIME:" + string.Format("{0:t}", DateTime.Now), baseFontBig));


        '/set the alignment of all three cells and set border to 0
        'pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell5.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell6.HorizontalAlignment = Element.ALIGN_CENTER;
        'pdfCell7.HorizontalAlignment = Element.ALIGN_CENTER;


        'pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
        'pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
        'pdfCell4.VerticalAlignment = Element.ALIGN_TOP;
        'pdfCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
        'pdfCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
        'pdfCell7.VerticalAlignment = Element.ALIGN_MIDDLE;


        'pdfCell4.Colspan = 3;



        'pdfCell1.Border = 0;
        'pdfCell2.Border = 0;
        'pdfCell3.Border = 0;
        'pdfCell4.Border = 0;
        'pdfCell5.Border = 0;
        'pdfCell6.Border = 0;
        'pdfCell7.Border = 0;


        '/add all three cells into PdfTable
        'pdfTab.AddCell(pdfCell1);
        'pdfTab.AddCell(pdfCell2);
        'pdfTab.AddCell(pdfCell3);
        'pdfTab.AddCell(pdfCell4);
        'pdfTab.AddCell(pdfCell5);
        'pdfTab.AddCell(pdfCell6);
        'pdfTab.AddCell(pdfCell7);

        'pdfTab.TotalWidth = document.PageSize.Width - 80f;
        'pdfTab.WidthPercentage = 70;
        '/pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;


        '/call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
        '/first param is start row. -1 indicates there is no end row and all the rows to be included to write
        '/Third and fourth param is x and y position to start writing
        'pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
        '/set pdfContent value

        '/Move the pointer and draw line to separate header section from rest of page
        'cb.MoveTo(40, document.PageSize.Height - 100);
        'cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
        'cb.Stroke();

        'Move the pointer and draw line to separate footer section from rest of page
        'cb.MoveTo(40, document.PageSize.GetBottom(50));
        'cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
        'cb.Stroke();
    End Sub

    Public Overrides Sub OnCloseDocument(writer As PdfWriter, document As Document)
        MyBase.OnCloseDocument(writer, document)

        'headerTemplate.BeginText();
        'headerTemplate.SetFontAndSize(bf, 12);
        'headerTemplate.SetTextMatrix(0, 0);
        'headerTemplate.ShowText((writer.PageNumber - 1).ToString());
        'headerTemplate.EndText();

        footerTemplate.BeginText()
        footerTemplate.SetFontAndSize(bf, 9)
        'footerTemplate.MoveText(550,30);
        footerTemplate.SetTextMatrix(0, 0)
        footerTemplate.ShowText((writer.PageNumber - 1).ToString())
        footerTemplate.EndText()


    End Sub
End Class
#End Region

''' <summary>
''' Convierte números en su expresión numérica a su numeral cardinal
''' </summary>
Public NotInheritable Class Numalet

#Region "Miembros estáticos"

    Private Const UNI As Integer = 0, DIECI As Integer = 1, DECENA As Integer = 2, CENTENA As Integer = 3
    Private Shared _matriz As String(,) = New String(CENTENA, 9) { _
        {Nothing, " uno", " dos", " tres", " cuatro", " cinco", " seis", " siete", " ocho", " nueve"}, _
        {" diez", " once", " doce", " trece", " catorce", " quince", " dieciséis", " diecisiete", " dieciocho", " diecinueve"}, _
        {Nothing, Nothing, Nothing, " treinta", " cuarenta", " cincuenta", " sesenta", " setenta", " ochenta", " noventa"}, _
        {Nothing, Nothing, Nothing, Nothing, Nothing, " quinientos", Nothing, " setecientos", Nothing, " novecientos"}}
    Private Const [sub] As Char = CChar(ChrW(26))
    'Cambiar acá si se quiere otro comportamiento en los métodos de clase
    Public Const SeparadorDecimalSalidaDefault As String = "pesos"
    Public Const MascaraSalidaDecimalDefault As String = "00'/100 MXN'"
    Public Const DecimalesDefault As Int32 = 2
    Public Const LetraCapitalDefault As Boolean = True
    Public Const ConvertirDecimalesDefault As Boolean = False
    Public Const ApocoparUnoParteEnteraDefault As Boolean = False
    Public Const ApocoparUnoParteDecimalDefault As Boolean = False

#End Region

#Region "Propiedades"

    Private _decimales As Int32 = DecimalesDefault
    Private _cultureInfo As CultureInfo = Globalization.CultureInfo.CurrentCulture
    Private _separadorDecimalSalida As String = SeparadorDecimalSalidaDefault
    Private _posiciones As Int32 = DecimalesDefault
    Private _mascaraSalidaDecimal As String, _mascaraSalidaDecimalInterna As String = MascaraSalidaDecimalDefault
    Private _esMascaraNumerica As Boolean = True
    Private _letraCapital As Boolean = LetraCapitalDefault
    Private _convertirDecimales As Boolean = ConvertirDecimalesDefault
    Private _apocoparUnoParteEntera As Boolean = False
    Private _apocoparUnoParteDecimal As Boolean

    ''' <summary>
    ''' Indica la cantidad de decimales que se pasarán a entero para la conversión
    ''' </summary>
    ''' <remarks>Esta propiedad cambia al cambiar MascaraDecimal por un valor que empieze con '0'</remarks>
    Public Property Decimales() As Int32
        Get
            Return _decimales
        End Get
        Set(ByVal value As Int32)
            If value > 10 Then
                Throw New ArgumentException(value.ToString() + " excede el número máximo de decimales admitidos, solo se admiten hasta 10.")
            End If
            _decimales = value
        End Set
    End Property

    ''' <summary>
    ''' Objeto CultureInfo utilizado para convertir las cadenas de entrada en números
    ''' </summary>
    Public Property CultureInfo() As CultureInfo
        Get
            Return _cultureInfo
        End Get
        Set(ByVal value As CultureInfo)
            _cultureInfo = value
        End Set
    End Property

    ''' <summary>
    ''' Indica la cadena a intercalar entre la parte entera y la decimal del número
    ''' </summary>
    Public Property SeparadorDecimalSalida() As String
        Get
            Return _separadorDecimalSalida
        End Get
        Set(ByVal value As String)
            _separadorDecimalSalida = value
            'Si el separador decimal es compuesto, infiero que estoy cuantificando algo,
            'por lo que apocopo el "uno" convirtiéndolo en "un"
            If value.Trim().IndexOf(" ") > 0 Then
                _apocoparUnoParteEntera = True
            Else
                _apocoparUnoParteEntera = False
            End If
        End Set
    End Property

    ''' <summary>
    ''' Indica el formato que se le dara a la parte decimal del número
    ''' </summary>
    Public Property MascaraSalidaDecimal() As String
        Get
            If Not [String].IsNullOrEmpty(_mascaraSalidaDecimal) Then
                Return _mascaraSalidaDecimal
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            'determino la cantidad de cifras a redondear a partir de la cantidad de '0' o ''
            'que haya al principio de la cadena, y también si es una máscara numérica
            Dim i As Integer = 0
            While i < value.Length AndAlso (value(i) = "0"c OrElse value(i) = "#")
                i += 1
            End While
            _posiciones = i
            If i > 0 Then
                _decimales = i
                _esMascaraNumerica = True
            Else
                _esMascaraNumerica = False
            End If
            _mascaraSalidaDecimal = value
            If _esMascaraNumerica Then
                _mascaraSalidaDecimalInterna = value.Substring(0, _posiciones) + "'" + value.Substring(_posiciones).Replace("''", [sub].ToString()).Replace("'", [String].Empty).Replace([sub].ToString(), "'") + "'"
            Else
                _mascaraSalidaDecimalInterna = value.Replace("''", [sub].ToString()).Replace("'", [String].Empty).Replace([sub].ToString(), "'")
            End If
        End Set
    End Property

    ''' <summary>
    ''' Indica si la primera letra del resultado debe estár en mayúscula
    ''' </summary>
    Public Property LetraCapital() As Boolean
        Get
            Return _letraCapital
        End Get
        Set(ByVal value As Boolean)
            _letraCapital = value
        End Set
    End Property

    ''' <summary>
    ''' Indica si se deben convertir los decimales a su expresión nominal
    ''' </summary>
    Public Property ConvertirDecimales() As Boolean
        Get
            Return _convertirDecimales
        End Get
        Set(ByVal value As Boolean)
            _convertirDecimales = value
            _apocoparUnoParteDecimal = value
            If value Then
                ' Si la máscara es la default, la borro
                If _mascaraSalidaDecimal = MascaraSalidaDecimalDefault Then
                    MascaraSalidaDecimal = ""
                End If
            ElseIf [String].IsNullOrEmpty(_mascaraSalidaDecimal) Then
                MascaraSalidaDecimal = MascaraSalidaDecimalDefault
                'Si no hay máscara dejo la default
            End If
        End Set
    End Property

    ''' <summary>
    ''' Indica si de debe cambiar "uno" por "un" en las unidades.
    ''' </summary>
    Public Property ApocoparUnoParteEntera() As Boolean
        Get
            Return _apocoparUnoParteEntera
        End Get
        Set(ByVal value As Boolean)
            _apocoparUnoParteEntera = value
        End Set
    End Property

    ''' <summary>
    ''' Determina si se debe apococopar el "uno" en la parte decimal
    ''' </summary>
    ''' <remarks>El valor de esta propiedad cambia al setear ConvertirDecimales</remarks>
    Public Property ApocoparUnoParteDecimal() As Boolean
        Get
            Return _apocoparUnoParteDecimal
        End Get
        Set(ByVal value As Boolean)
            _apocoparUnoParteDecimal = value
        End Set
    End Property

#End Region

#Region "Constructores"

    Public Sub New()
        MascaraSalidaDecimal = MascaraSalidaDecimalDefault
        SeparadorDecimalSalida = SeparadorDecimalSalidaDefault
        LetraCapital = LetraCapitalDefault
        ConvertirDecimales = _convertirDecimales
    End Sub

    Public Sub New(ByVal ConvertirDecimales As Boolean, ByVal MascaraSalidaDecimal As String, ByVal SeparadorDecimalSalida As String, ByVal LetraCapital As Boolean)
        If Not [String].IsNullOrEmpty(MascaraSalidaDecimal) Then
            Me.MascaraSalidaDecimal = MascaraSalidaDecimal
        End If
        If Not [String].IsNullOrEmpty(SeparadorDecimalSalida) Then
            _separadorDecimalSalida = SeparadorDecimalSalida
        End If
        _letraCapital = LetraCapital
        _convertirDecimales = ConvertirDecimales
    End Sub

#End Region

#Region "Conversores de instancia"

    Public Function ToCustomCardinal(ByVal Numero As Double) As String
        Return Convertir(Convert.ToDecimal(Numero), _decimales, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _
        _convertirDecimales, _apocoparUnoParteEntera, _apocoparUnoParteDecimal)
    End Function

    Public Function ToCustomCardinal(ByVal Numero As String) As String
        Dim dNumero As Double
        If [Double].TryParse(Numero, NumberStyles.Float, _cultureInfo, dNumero) Then
            Return ToCustomCardinal(dNumero)
        Else
            Throw New ArgumentException("'" + Numero + "' no es un número válido.")
        End If
    End Function

    Public Function ToCustomCardinal(ByVal Numero As Decimal) As String
        Return ToCardinal(Numero)
    End Function

    Public Function ToCustomCardinal(ByVal Numero As Int32) As String
        Return Convertir(Convert.ToDecimal(Numero), 0, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _
        _convertirDecimales, _apocoparUnoParteEntera, False)
    End Function

    Public Function ToCustomString(ByVal Numero As Single) As String
        Return Convertir(Convert.ToDecimal(Numero), _decimales, _separadorDecimalSalida, _mascaraSalidaDecimalInterna, _esMascaraNumerica, _letraCapital, _convertirDecimales, _apocoparUnoParteEntera, _apocoparUnoParteDecimal)
    End Function

#End Region

#Region "Conversores estáticos"

    Public Shared Function ToCardinal(ByVal Numero As Int32) As String
        Return Convertir(Convert.ToDecimal(Numero), 0, Nothing, Nothing, True, LetraCapitalDefault, _
        ConvertirDecimalesDefault, ApocoparUnoParteEnteraDefault, ApocoparUnoParteDecimalDefault)
    End Function

    Public Shared Function ToCardinal(ByVal Numero As Double) As String
        Return Convertir(Convert.ToDecimal(Numero), DecimalesDefault, SeparadorDecimalSalidaDefault, MascaraSalidaDecimalDefault, True, LetraCapitalDefault, _
        ConvertirDecimalesDefault, ApocoparUnoParteEnteraDefault, ApocoparUnoParteDecimalDefault)
    End Function

    Public Shared Function ToCardinal(ByVal Numero As String, ByVal ReferenciaCultural As CultureInfo) As String
        Dim dNumero As Double
        If [Double].TryParse(Numero, NumberStyles.Float, ReferenciaCultural, dNumero) Then
            Return ToCardinal(dNumero)
        Else
            Throw New ArgumentException("'" + Numero + "' no es un número válido.")
        End If
    End Function


    Public Shared Function ToCardinal(ByVal Numero As String) As String
        Return Numalet.ToCardinal(Numero, CultureInfo.CurrentCulture)
    End Function

    Public Shared Function ToCardinal(ByVal Numero As Decimal) As String
        Return ToCardinal(Convert.ToDouble(Numero))
    End Function

#End Region

    Private Shared Function Convertir(ByVal Numero As Decimal, ByVal Decimales As Int32, ByVal SeparadorDecimalSalida As String, ByVal MascaraSalidaDecimal As String, ByVal EsMascaraNumerica As Boolean, ByVal LetraCapital As Boolean, _
    ByVal ConvertirDecimales As Boolean, ByVal ApocoparUnoParteEntera As Boolean, ByVal ApocoparUnoParteDecimal As Boolean) As String
        Dim Num As Int64
        Dim terna As Int32, centenaTerna As Int32, decenaTerna As Int32, unidadTerna As Int32, iTerna As Int32
        Dim cadTerna As String
        Dim Resultado As New StringBuilder()

        Num = Math.Floor(Math.Abs(Numero))

        If Num >= 1000000000001 OrElse Num < 0 Then
            Throw New ArgumentException("El número '" + Numero.ToString() + "' excedió los límites del conversor: [0;1.000.000.000.001]")
        End If
        If Num = 0 Then
            Resultado.Append(" cero")
        Else
            iTerna = 0

            Do Until Num = 0

                iTerna += 1
                cadTerna = String.Empty
                terna = Num Mod 1000

                centenaTerna = Int(terna / 100)
                decenaTerna = terna - centenaTerna * 100 'Decena junto con la unidad
                unidadTerna = (decenaTerna - Math.Floor(decenaTerna / 10) * 10)

                Select Case decenaTerna
                    Case 1 To 9
                        cadTerna = _matriz(UNI, unidadTerna) + cadTerna
                    Case 10 To 19
                        cadTerna = cadTerna + _matriz(DIECI, unidadTerna)
                    Case 20
                        cadTerna = cadTerna + " veinte"
                    Case 21 To 29
                        cadTerna = " veinti" + _matriz(UNI, unidadTerna).Substring(1)
                    Case 30 To 99
                        If unidadTerna <> 0 Then
                            cadTerna = _matriz(DECENA, Int(decenaTerna / 10)) + " y" + _matriz(UNI, unidadTerna) + cadTerna
                        Else
                            cadTerna += _matriz(DECENA, Int(decenaTerna / 10))
                        End If
                End Select

                Select Case centenaTerna
                    Case 1
                        If decenaTerna > 0 Then
                            cadTerna = " ciento" + cadTerna
                        Else
                            cadTerna = " cien" + cadTerna
                        End If
                        Exit Select
                    Case 5, 7, 9
                        cadTerna = _matriz(CENTENA, Int(terna / 100)) + cadTerna
                        Exit Select
                    Case Else
                        If Int(terna / 100) > 1 Then
                            cadTerna = _matriz(UNI, Int(terna / 100)) + "cientos" + cadTerna
                        End If
                        Exit Select
                End Select
                'Reemplazo el 'uno' por 'un' si no es en las únidades o si se solicító apocopar
                If (iTerna > 1 OrElse ApocoparUnoParteEntera) AndAlso decenaTerna = 21 Then
                    cadTerna = cadTerna.Replace("veintiuno", "veintiún")
                ElseIf (iTerna > 1 OrElse ApocoparUnoParteEntera) AndAlso unidadTerna = 1 AndAlso decenaTerna <> 11 Then
                    cadTerna = cadTerna.Substring(0, cadTerna.Length - 1)
                    'Acentúo 'veintidós', 'veintitrés' y 'veintiséis'
                ElseIf decenaTerna = 22 Then
                    cadTerna = cadTerna.Replace("veintidos", "veintidós")
                ElseIf decenaTerna = 23 Then
                    cadTerna = cadTerna.Replace("veintitres", "veintitrés")
                ElseIf decenaTerna = 26 Then
                    cadTerna = cadTerna.Replace("veintiseis", "veintiséis")
                End If

                'Completo miles y millones
                Select Case iTerna
                    Case 3
                        If Numero < 2000000 Then
                            cadTerna += " millón"
                        Else
                            cadTerna += " millones"
                        End If
                    Case 2, 4
                        If terna > 0 Then cadTerna += " mil"
                End Select
                Resultado.Insert(0, cadTerna)
                Num = Int(Num / 1000)
            Loop
        End If

        'Se agregan los decimales si corresponde
        If Decimales > 0 Then
            Resultado.Append(" " + SeparadorDecimalSalida + " ")
            Dim EnteroDecimal As Int32 = Int(Math.Round((Numero - Int(Numero)) * Math.Pow(10, Decimales)))
            If ConvertirDecimales Then
                Dim esMascaraDecimalDefault As Boolean = MascaraSalidaDecimal = MascaraSalidaDecimalDefault
                Resultado.Append(Convertir(Convert.ToDecimal(EnteroDecimal), 0, Nothing, Nothing, EsMascaraNumerica, False, _
                False, (ApocoparUnoParteDecimal AndAlso Not EsMascaraNumerica), False) + " " + (IIf(EsMascaraNumerica, "", MascaraSalidaDecimal)))
            ElseIf EsMascaraNumerica Then
                Resultado.Append(EnteroDecimal.ToString(MascaraSalidaDecimal))
            Else
                Resultado.Append(EnteroDecimal.ToString() + " " + MascaraSalidaDecimal)
            End If
        End If
        'Se pone la primer letra en mayúscula si corresponde y se retorna el resultado
        If LetraCapital Then
            Return Resultado(1).ToString().ToUpper() + Resultado.ToString(2, Resultado.Length - 2)
        Else
            Return Resultado.ToString().Substring(1)
        End If
    End Function

End Class