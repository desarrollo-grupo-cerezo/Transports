
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


Module Timbrar
    Function TimbrarDIGIBOX(ByVal rutaXml As String, ByVal rutaXmlt As String, ByVal usuario As String, ByVal password As String) As Boolean
        Dim resultado As String
        Dim Xml As XmlDocument = New XmlDocument()
        Xml.Load(rutaXml)

        If TIMBRADO_SAT = "Si" Then
            '"TIMBRADO DEMO"
            Try
                Dim autentication As WSDIGIBOX_AUTENTICATION.wsAutenticacionSoapClient = New WSDIGIBOX_AUTENTICATION.wsAutenticacionSoapClient()
                Dim token = autentication.AutenticarBasico(usuario, password)
                Dim timbrarSOAP As WSDIGIBOX.wsTimbradoSoapClient = New WSDIGIBOX.wsTimbradoSoapClient()
                Dim xmlResutlado = New XmlDocument

                resultado = timbrarSOAP.TimbrarXMLV2(xml.OuterXml, token)
                Var8 = resultado
                CFDI_XML_DIGIBOX = resultado

                Dim xmlREsultado As XmlDocument = New XmlDocument
                xmlResutlado.LoadXml(resultado)
                xmlResutlado.Save(rutaXmlt)

                Try
                    xmlResutlado.Save(XML_BK)
                Catch ex As Exception
                    BITACORACFDI("Error en DIGIBOX DEMO xmlResutlado.Save. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Catch ex As Exception
                BITACORACFDI("Error en DIGIBOX DEMO. " & ex.Message & vbNewLine & ex.StackTrace)

                MsgBox("Error en DIGIBOX DEMO. " & ex.Message)
                Return False
            End Try
        Else
            Try
                Dim Autentication As DIGIBOX_AUTENTICACION.wsAutenticacionSoapClient = New DIGIBOX_AUTENTICACION.wsAutenticacionSoapClient()
                Dim Token = Autentication.AutenticarBasico(usuario, password)
                Dim TimbrarSOAP As DIGIBOX_TIMBRADO.wsTimbradoSoapClient = New DIGIBOX_TIMBRADO.wsTimbradoSoapClient()
                Dim xmlResutlado = New XmlDocument

                'SomeComsumedWebService wsc = New SomeComsumedWebService()
                'SomeComsumedWebService.Timeout = 600000; // 10 minutes
                'var obj = SomeComsumedWebService.MethodToGetData()

                resultado = TimbrarSOAP.TimbrarXMLV2(Xml.OuterXml, Token)
                Var8 = resultado
                CFDI_XML_DIGIBOX = resultado

                Dim xmlREsultado As XmlDocument = New XmlDocument
                xmlResutlado.LoadXml(resultado)
                xmlResutlado.Save(rutaXmlt)

                Try
                    xmlResutlado.Save(XML_BK)
                Catch ex As Exception
                    BITACORACFDI("Error en DIGIBOX xmlResutlado.Save. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Catch ex As Exception
                BITACORACFDI("Error en DIGIBOX. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("Error en DIGIBOX. " & ex.Message)
                Return False
            End Try
        End If
        Return True


    End Function
    Function TimbrarFolioDigitales(ByVal rutaXMLTimbrar As String, ByVal rutaXML As String, ByVal usuario As String, ByVal password As String) As Boolean
        Dim ServicioTimbrado_FOLIOS_DIGITALES As WSFD.WSCFDI33Client = New WSFD.WSCFDI33Client
        Dim RespuestaTimbrado_FOLIOS_DIGITALES As WSFD.RespuestaTFD33 = New WSFD.RespuestaTFD33
        Dim DocumentoXML As XmlDocument = New XmlDocument()
        DocumentoXML.Load(rutaXMLTimbrar)
        Dim stringXML As String = Nothing
        stringXML = DocumentoXML.OuterXml
        RespuestaTimbrado_FOLIOS_DIGITALES = ServicioTimbrado_FOLIOS_DIGITALES.TimbrarCFDI(usuario, password, stringXML, "1222")
        If RespuestaTimbrado_FOLIOS_DIGITALES.OperacionExitosa = True Then
            DocumentoXML.LoadXml(RespuestaTimbrado_FOLIOS_DIGITALES.XMLResultado)
            DocumentoXML.Save(rutaXML)
            Return True
        Else
            Dim [error] As String
            [error] = RespuestaTimbrado_FOLIOS_DIGITALES.CodigoRespuesta
            [error] += RespuestaTimbrado_FOLIOS_DIGITALES.MensajeError
            [error] += RespuestaTimbrado_FOLIOS_DIGITALES.MensajeErrorDetallado
            MessageBox.Show([error])
            Return False
        End If
    End Function
    Function timbrarRV(ByVal rutaXMLTimbrar As String, ByVal rutaXML As String, ByVal usuario As String, ByVal password As String) As Boolean
        Dim servicioTimbrado As WSRV.ServiceSoapClient = New WSRV.ServiceSoapClient()
        Dim respuestatimbrado As WSRV.StructCfd = New WSRV.StructCfd()
        Dim DocumentoXML As XmlDocument = New XmlDocument()
        DocumentoXML.Load(rutaXMLTimbrar)
        Dim stringXML As String = Nothing
        stringXML = DocumentoXML.OuterXml
        stringXML = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(stringXML))
        Dim autorizacion As WSRV.AuthSoapHd = New WSRV.AuthSoapHd()
        autorizacion.strUserName = usuario
        autorizacion.strPassword = password
        RespuestaTimbrado = ServicioTimbrado.TestCfd33(autorizacion, stringXML)

        If RespuestaTimbrado.state = 0 Then
            Dim xmlResultado As String = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(RespuestaTimbrado.Cfdi))
            DocumentoXML.LoadXml(xmlResultado)
            DocumentoXML.Save(rutaXML)
            Return True
        Else
            MessageBox.Show(RespuestaTimbrado.state & " " + RespuestaTimbrado.Descripcion, "Error de timbrado", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
            Return False
        End If
    End Function

End Module

