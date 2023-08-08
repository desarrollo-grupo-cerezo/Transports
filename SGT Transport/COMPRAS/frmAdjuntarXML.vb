Imports System.IO
Imports System.Xml

Public Class frmAdjuntarXML
    Private Sub frmAdjuntarXML_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            If Var25.Trim.Length > 0 Then
                Dim RUTA_XML_COMP As String
                'RUTA_XML_COMP
                RUTA_XML_COMP = OBTENER_RUTA_XML()
                If RUTA_XML_COMP.Trim.Length = 0 Then
                    RUTA_XML_COMP = Application.StartupPath
                End If

                'RUTA_XML_COMP & "\" & 

                tXML.Text = Var25
                Try
                    Dim UUID As String
                    If tXML.Text.Trim.Length > 0 Then
                        UUID = OBTENER_UUID_XML(tXML.Text)
                    End If
                Catch ex As Exception
                    Bitacora("365. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("365. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmAdjuntarXML_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        Try
            Dim UUID As String

            Dim openExcelFileDialog As New OpenFileDialog()
            openExcelFileDialog.Filter = "Archivo XML (*.XML or .xml)|.XML;*.XML"
            openExcelFileDialog.FilterIndex = 1
            openExcelFileDialog.RestoreDirectory = True
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                tXML.Text = openExcelFileDialog.FileName
                UUID = OBTENER_UUID_XML(tXML.Text)
            Else
                tXML.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click

        If tXML.Text.Trim.Length > 0 Then
            Var25 = tXML.Text
            Var2 = LtSerie.Text
            Var3 = LtFolio.Text
            Var4 = LtFecha.Text

            Me.Close()
        Else
            MsgBox("Por favor seleccione el archivo XML")
        End If

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click

        Me.Close()
    End Sub

    Private Sub tXML_Validated(sender As Object, e As EventArgs) Handles tXML.Validated
        Try
            Dim UUID As String
            If tXML.Text.Trim.Length > 0 Then

                If File.Exists(tXML.Text) Then
                    UUID = OBTENER_UUID_XML(tXML.Text)
                Else
                    If IO.Path.GetFileName(tXML.Text).ToString.Trim.Length > 0 Then
                        MsgBox("Ruta inexistente " & tXML.Text)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tXML_TextChanged(sender As Object, e As EventArgs) Handles tXML.TextChanged
        If tXML.Text.Length = 0 Then
            LtFecha.Text = ""
            LtFormaPago.Text = ""
            LtMoneda.Text = ""
            LtTipoComprobante.Text = ""
            LtTotal.Text = ""
            LtUsoCFDI.Text = ""
            LtVersion.Text = ""
            LtSerie.Text = ""
            LtFolio.Text = ""
        End If
    End Sub

    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String
        Dim strMetodoPago As String, strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String
        Dim strEmisorCalle As String, strEmisorNoExterior As String, strEmisorNoInterior As String, strEmisorColonia As String
        Dim strEmisorMunicipio As String, strEmisorEstado As String, strUsoCFDI As String, strRegimen As String
        Dim strDescuento As String, strNumCtaPago As String, strVersion As String, NoCertificadoSAT As String
        Dim UUID As String, UUIDR As String

        Dim FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String, Monto As String, FormaDePagoP As String
        Dim FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String, ImpPagado As String, ImpSaldoAnt As String
        Dim NumParcialidad As String, MetodoDePagoDR As String
        Dim concepto As XmlNodeList, Elemento As XmlNode, subnodo As XmlElement, IdDocumento As String

        Dim XML As String, xDoc As XmlDocument, xNodo As XmlNodeList, xAtt As XmlElement, Comprobante As XmlNode

        If fFILE_XML.Trim.Length = 0 Then
            MsgBox("Por favor seleccione el archivo XML")
            Return ""
        End If

        If IO.Path.GetFileName(fFILE_XML).ToString.Trim.Length = 0 Then
            tXML.Text = ""
            Return ""
        End If
        If Not File.Exists(fFILE_XML) Then
            MsgBox("XML Inexistente verifique por favor")
            tXML.Text = ""
            Return ""
        End If

        strEmisorNombre = "" : strFechaEmision = "" : strEmisorCalle = "" : strEmisorMunicipio = "" : strEmisorEstado = ""
        strEmisorNoExterior = "" : strEmisorNoInterior = "" : strEmisorColonia = "" : strFormaPago = "" : strMetodoPago = ""
        strSubtotal = "" : strTotal = "" : strEmisorRfc = "" : strFolio = "" : strDescuento = "0" : strNumCtaPago = ""
        strSerie = "" : strVersionTimbre = "" : UUID = "" : FechaTimbrado = "" : NoCertificadoSAT = "" : strTipoComprobante = "" : strUsoCFDI = ""
        strReceptorRfc = "" : UUIDR = ""

        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""

        xDoc = New XmlDocument

        XML = fFILE_XML

        Try
            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try
                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")
                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")

                            LtFecha.Text = strFechaEmision
                            LtTotal.Text = strTotal
                            LtVersion.Text = strVersion
                            LtMoneda.Text = strMoneda
                            LtFormaPago.Text = BUSCAR_FORMA_PAGO(strFormaPago)
                            LtVersion.Text = strVersion
                            LtUsoCFDI.Text = strUsoCFDI
                            LtTipoComprobante.Text = IIf(strTipoComprobante = "I", "Ingreso", "Egreso")
                            LtSerie.Text = strSerie
                            LtFolio.Text = strFolio

                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR
                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                                LtUsoCFDI.Text = strUsoCFDI
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                Application.DoEvents()
                                Me.Refresh()
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then

                Try
                    ').Value = strSerie & strFolio
                    ').Value = BUSCA_CLIENTE(strEmisorRfc, strEmisorNombre)
                    ').Value = strEmisorNombre
                    ').Value = strEmisorRfc
                    ').Value = strUsoCFDI
                    ').Value = strTipoComprobante
                    ').Value = strVersionTimbre
                    ').Value = UUID
                    ').Value = NoCertificadoSAT
                    ').Value = FechaTimbrado
                    ').Value = strFormaPago
                    ').Value = strMetodoPago
                    ').Value = strTotal
                    ').Value = strSubtotal
                    ').Value = strSerie
                    ').Value = strFolio
                    ').Value = UUIDR
                    ').Value = FormaDePagoP
                    ').Value = Serie & Folio
                    ').Value = IdDocumento
                Catch ex As Exception
                    Bitacora("99. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & XML)
            MsgBox("Problema al abrir el xml " & XML)
        End Try

        Return UUID

    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub BtnDEsAsociarXml_Click(sender As Object, e As EventArgs) Handles BtnDEsAsociarXml.Click

        If MsgBox("Realmente desea desasociar xml?", vbYesNo) = vbYes Then
            tXML.Text = ""
            LtSerie.Text = ""
            LtFolio.Text = ""
            LtFecha.Text = ""

            Var25 = "Des"
            Var2 = ""
            Var3 = ""
            Var4 = ""

            Var6 = "DESASOCIAR"

            SQL = "DELETE FROM GCCOMPRAS WHERE CVE_DOC = '" & Var24 & "'"
            EXECUTE_QUERY_NET(SQL)

            Me.Close()
        End If

    End Sub
End Class
