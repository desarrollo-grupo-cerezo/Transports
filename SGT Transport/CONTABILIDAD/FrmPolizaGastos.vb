Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmPolizaGastos
    Private EmisorRfcCFD As String

    Private SerieCFD As String
    Private FolioCFD As String
    Private FechaEmision As String

    Private TotalCFD As Decimal
    Private SubtotalCFD As Decimal
    Private IVAcfd As Decimal

    Private VersionCFD As String
    Private MonedaCFD As String
    Private FormaPagoCFD As String
    Private UsoCFDICFD As String
    Private TipoComprobanteCFD As String

    Private UsoCFD As String

    Dim CADENA As String = ""
    Dim RUTA_MODELO As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmPolizaGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Fg.Rows.Count = 1
            Fg.Rows(0).Height = 50

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - 50

            GET_RUTA_MODELO()

            tPOLIZA.Text = "Gastos administrativos " & DateTime.Now.ToShortDateString

            Fg.Cols.Count = 7
            Fg(0, 1) = "Cuenta contable"
            Dim c11 As Column = Fg.Cols(1)
            c11.DataType = GetType(String)

            Fg(0, 2) = ""
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Descripcion"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Cargo"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Decimal)
            Fg.Cols(4).Format = "###,###,##0.00"

            Fg(0, 5) = "Abono"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(Decimal)
            Fg.Cols(5).Format = "###,###,##0.00"

            Fg(0, 6) = "XML"
            Dim c6 As Column = Fg.Cols(6)
            c6.DataType = GetType(String)
            'Fg.Cols(6).Visible = False

            Dim N = DateTime.Now.AddMonths(-1)
            Dim D1 As String, D2 As String

            D1 = "01/" & Format(N.Month, "00") & "/" & Now.Year
            D2 = Format(DateTime.DaysInMonth(N.Year, N.Month), "00") & "/" & Format(N.Month, "00") & "/" & Now.Year

            F1.Value = D1
            F2.Value = D2

        Catch ex As Exception
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_RUTA_MODELO()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                RUTA_MODELO = dr("RUTA_MODELO").ToString
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPolizaGastos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Póliza gastos administrativos")
    End Sub
    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim SUBT As Decimal = 0, IVA As Decimal, IMPORTE As Decimal
        Dim SUMA As Decimal = 0
        Dim NewStyle1 As CellStyle, NewStyle2 As CellStyle


        Fg.Rows.Count = 1
        Fg.Redraw = False

        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.CadetBlue
        NewStyle1.ForeColor = Color.Black

        NewStyle2 = Fg.Styles.Add("NewStyle2")
        NewStyle2.BackColor = Color.Yellow
        NewStyle2.ForeColor = Color.Black

        Try

            SQL = "SELECT P.CVE_DOC, P.TOT_PARTIDA, (P.TOTIMP1 + P.TOTIMP2 + P.TOTIMP3 + P.TOTIMP4) AS TOT_IMP, 
                ISNULL(PROV.CUENTA_CONTABLE,'') AS CTA_PROV, PROV.NOMBRE, ISNULL(G.CUENTA_CONT,'') AS CTA_CONCEP_GASTO, 
                ISNULL(ARCHIVO_XML,'') AS FILE_XML
                FROM GCGASTOS_PART P 
                LEFT JOIN GCGASTOS F ON F.CVE_DOC = P.CVE_DOC
                LEFT JOIN GCCOMPRAS X ON X.CVE_DOC = P.CVE_DOC
                LEFT JOIN GCCATGASTOS G ON G.CVE_ART = P.CVE_ART
                LEFT JOIN PROV" & Empresa & " PROV ON PROV.CLAVE = F.CVE_CLPV
                WHERE F.STATUS <> 'C' AND 
                F.FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CADENA = dr("NOMBRE") & "  F/" & dr("CVE_DOC")
                            IMPORTE = dr("TOT_PARTIDA")
                            IVA = dr("TOT_IMP")
                            Fg.AddItem(IIf(dr("FILE_XML").ToString.Trim.Length > 0, "x", "") & vbTab & dr("CTA_CONCEP_GASTO") & vbTab & "0" & vbTab & CADENA & vbTab & IMPORTE & vbTab & "" & vbTab &
                                       dr("FILE_XML"))
                            If dr("CTA_CONCEP_GASTO").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                            End If
                            Fg.AddItem("" & vbTab & "121-001-0000" & vbTab & "0" & vbTab & CADENA & vbTab & IVA & vbTab & "" & vbTab & "")
                            Fg.AddItem("" & vbTab & dr("CTA_PROV") & vbTab & "0" & vbTab & CADENA & vbTab & "" & vbTab & IMPORTE + IVA & vbTab & "")
                            If dr("CTA_PROV").Trim.Length = 0 Then
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 1, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 2, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 3, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 4, NewStyle1)
                                Fg.SetCellStyle(Fg.Rows.Count - 1, 5, NewStyle1)
                            End If
                            SUBT += IMPORTE
                            SUMA += IMPORTE + IVA
                        Catch ex As Exception
                            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
            Fg.AddItem("" & vbTab & " " & vbTab & "" & vbTab & " " & vbTab & SUMA & vbTab & SUMA & vbTab & "")
            Fg.AutoSizeCols()
            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Fg.Select()

        MsgBox("Proceso terminado")
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PolizaCompras")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click
        Dim s As String = "", nDoc As Integer = 0
        Dim CUENTA As String, CONCEPTO As String, IMPORTE1 As Decimal, IMPORTE2 As Decimal
        Dim CADENA1 As String, XML As String
        Dim UUID_XML As String
        Dim FILE_XML As String = "", NUM_PAR As Long = 12903, NUM_PARX As Long

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length = 0 Then
                    nDoc += 1
                End If
            Next
        Catch ex As Exception
        End Try

        If nDoc > 0 Then
            If MsgBox("Existen documentos sin CUENTA CONTABLE, Desea continuar?", vbYesNo) = vbNo Then
                Return
            End If
        End If

        If tPOLIZA.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre de la poliza")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor

        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA>"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""VersionCOI"" fieldtype=""i2""/>"
            s &= "<FIELD attrname=""TipoPoliz"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""DiaPoliz"" fieldtype=""string"" WIDTH=""2""/>"
            s &= "<FIELD attrname=""ConcepPoliz"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""UUID"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS>"
            s &= "<FIELD attrname=""Cuenta"" fieldtype=""string"" WIDTH=""21""/>"
            s &= "<FIELD attrname=""Depto"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""ConceptoPol"" fieldtype=""string"" WIDTH=""120""/>"
            s &= "<FIELD attrname=""Monto"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""TipoCambio"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""DebeHaber"" fieldtype=""string"" WIDTH=""1""/>"
            s &= "<FIELD attrname=""ccostos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""proyectos"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""Porcentaje"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""FRMPAGO"" fieldtype=""string"" WIDTH=""5""/>"
            s &= "<FIELD attrname=""NUMCHEQUE"" fieldtype=""string"" WIDTH=""20""/>"
            s &= "<FIELD attrname=""MONTOBN"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""BANCO"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTAORIG"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""BENEF"" fieldtype=""string"" WIDTH=""300""/>"
            s &= "<FIELD attrname=""RFC"" fieldtype=""string"" WIDTH=""13""/>"
            s &= "<FIELD attrname=""BANCODEST"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""CTADEST"" fieldtype=""string"" WIDTH=""50""/>"
            s &= "<FIELD attrname=""FECHACHEQUE"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""BANCOORIGEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""BANCODESTEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s &= "<FIELD attrname=""IDUUID"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""IDFISCAL"" fieldtype=""string"" WIDTH=""40""/>"
            s &= "<FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested"">"
            s &= "<FIELDS>"
            s &= "<FIELD attrname=""NUMREG"" fieldtype=""i4""/>"
            s &= "<FIELD attrname=""UUIDTIMBRE"" fieldtype=""string"" WIDTH=""36""/>"
            s &= "<FIELD attrname=""MONTO"" fieldtype=""r8""/>"
            s &= "<FIELD attrname=""SERIE"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""FOLIO"" fieldtype=""string"" WIDTH=""100""/>"
            s &= "<FIELD attrname=""RFCEMISOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""RFCRECEPTOR"" fieldtype=""string"" WIDTH=""16""/>"
            s &= "<FIELD attrname=""FECHAUUID"" fieldtype=""string"" WIDTH=""10""/>"
            s &= "<FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/>"
            s &= "</FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA><ROWDATA>"
            s &= "<ROW VersionCOI=""810"" TipoPoliz=""Co"" DiaPoliz=""30"" ConcepPoliz=""" & tPOLIZA.Text & """><Partidas>"
            'BACKUPTXT("XML", s)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Try
            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                CUENTA = Fg(k, 1)
                CONCEPTO = Fg(k, 3)
                IMPORTE1 = 0
                Try
                    IMPORTE1 = Fg(k, 4)
                Catch ex As Exception
                End Try
                IMPORTE2 = 0
                Try
                    IMPORTE2 = Fg(k, 5)
                Catch ex As Exception
                End Try

                If CUENTA.Trim.Length > 0 Then

                    If CONCEPTO.IndexOf("096") > -1 Then
                        XML = ""
                    End If

                    If Fg(k, 6) IsNot Nothing Then
                        XML = Fg(k, 6)
                    Else
                        XML = ""
                    End If

                    If XML.Trim.Length > 0 Then
                        EmisorRfcCFD = "" : FolioCFD = "" : SerieCFD = "" : FechaEmision = "" : TotalCFD = 0 : SubtotalCFD = 0 : IVAcfd = 0 : VersionCFD = ""
                        MonedaCFD = "" : FormaPagoCFD = "" : UsoCFDICFD = "" : TipoComprobanteCFD = "" : UsoCFD = ""

                        UUID_XML = OBTENER_UUID_XML(FILE_XML)
                        Try '"2021-08-10T11:45:51"
                            FechaEmision = FechaEmision.Substring(8, 2) & "/" & FechaEmision.Substring(5, 2) & "/" & FechaEmision.Substring(0, 4)
                        Catch ex As Exception
                            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If Not IsDate(FechaEmision) Then
                            FechaEmision = ""
                            NUM_PARX = 0
                        Else
                            NUM_PARX = NUM_PAR
                        End If
                        If UUID_XML.Trim.Length > 0 Then
                            CADENA1 = "<ROWCDSPartidasUUID NUMREG=""" & NUM_PARX & """ UUIDTIMBRE=""" & UUID_XML & """ MONTO=""" & TotalCFD & """ SERIE=""" & SerieCFD & """ FOLIO=""" & FolioCFD & """ RFCEMISOR=""" & EmisorRfcCFD & """ RFCRECEPTOR=""TEM820612AF7"" FECHAUUID=""" & FechaEmision & """ TIPOCOMPROBANTE=""1""/>"
                            Fg(k, 16) = UUID_XML
                        Else
                            CADENA1 = ""
                        End If
                    Else
                        CADENA1 = ""
                        NUM_PARX = 0
                    End If

                    s &= "<ROWPartidas Cuenta=""" & CUENTA & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    If IMPORTE1 > 0 Then
                        s &= " Monto=""" & Math.Round(IMPORTE1, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    Else
                        s &= " Monto=""" & Math.Round(IMPORTE2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    End If

                    s &= " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" &
                        NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID>"
                    s &= "</ROWPartidas>"

                    If NUM_PARX <> 0 Then
                        NUM_PAR += 1
                    End If
                    'IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID></ROWPartidas>"
                End If
            Next
            s &= "</Partidas></ROW></ROWDATA></DATAPACKET>"

            Var4 = "NO"

            tPOLIZA.Text = tPOLIZA.Text.Replace("/", "-")
            BACKUPXML(RUTA_MODELO & "\" & tPOLIZA.Text & ".POL", s)

            If Var4 = "OK" Then
                MsgBox("La póliza modelo se grabo satisfactoriamente en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            Else
                MsgBox("No se logro crear la póliza modelo en " & RUTA_MODELO & "\" & tPOLIZA.Text & ".XML")
            End If
        Catch ex As Exception
            Bitacora("655. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("655. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String, strSerie As String, strFolio As String, strFechaEmision As String, strSello As String, strNoCertificado As String
        Dim strSubtotal As String, strTotal As String, strMoneda As String, strCondiciones As String, strFormaPago As String, strMetodoPago As String
        Dim strLugarExpedicion As String, strReceptorRfc As String, strEmisorRfc As String, strEmisorNombre As String
        Dim strUsoCFDI As String, strRegimen As String, strDescuento As String, strNumCtaPago As String, strVersion As String, NoCertificadoSAT As String
        Dim UUID As String, UUIDR As String, FechaTimbrado As String, strVersionTimbre As String, NumOperacion As String, Monto As String
        Dim FormaDePagoP As String, FechaPago As String, Folio As String, Serie As String, ImpSaldoInsoluto As String, ImpPagado As String
        Dim ImpSaldoAnt As String, NumParcialidad As String, MetodoDePagoDR As String, totalImpuestosTrasladados As Decimal
        Dim vsTIT As Decimal, k As Integer, IdDocumento As String
        Dim concepto As XmlNodeList
        Dim Elemento As XmlNode
        Dim subnodo As XmlElement

        Dim XML As String
        Dim xDoc As XmlDocument
        Dim xNodo As XmlNodeList
        Dim xAtt As XmlElement
        Dim Comprobante As XmlNode
        Dim RUTA_XML As String
        Dim Impuestos As XmlNode = Nothing
        'aqui
        If fFILE_XML.Trim.Length = 0 Then
            Return ""
        End If

        RUTA_XML = OBTENER_RUTA_XML()
        fFILE_XML = Path.GetFileName(fFILE_XML)
        BACKUPTXT("FILES XML", RUTA_XML & "\" & fFILE_XML)

        If Not File.Exists(RUTA_XML & "\" & fFILE_XML) Then
            'BACKUPTXT("FILES XML", RUTA_XML & "\" & fFILE_XML)
            Return ""
        End If

        strEmisorRfc = "" : UUID = "" : strTipoComprobante = "" : strUsoCFDI = ""

        xDoc = New XmlDocument

        Try
            XML = RUTA_XML & "\" & fFILE_XML

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

                            SerieCFD = VarXml(xAtt, "Serie")
                            FolioCFD = VarXml(xAtt, "Folio")

                            FechaEmision = strFechaEmision
                            TotalCFD = strTotal
                            SubtotalCFD = strSubtotal

                            VersionCFD = strVersion
                            MonedaCFD = strMoneda
                            FormaPagoCFD = BUSCAR_FORMA_PAGO(strFormaPago)
                            VersionCFD = strVersion
                            UsoCFDICFD = strUsoCFDI
                            TipoComprobanteCFD = IIf(strTipoComprobante = "I", "Ingreso", "Egreso")
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo

                                strEmisorRfc = VarXml(xAtt, "rfc")
                                Try
                                    If strEmisorRfc.Trim.Length = 0 Then
                                        strEmisorRfc = VarXml(xAtt, "Rfc")
                                    End If
                                Catch ex As Exception
                                    Bitacora("8. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                strEmisorNombre = VarXml(xAtt, "nombre")
                                Try
                                    If strEmisorNombre.Trim.Length = 0 Then
                                        strEmisorNombre = VarXml(xAtt, "Nombre")
                                    End If
                                Catch ex As Exception
                                    Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            EmisorRfcCFD = strEmisorRfc
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        Impuestos = Comprobante("cfdi:Impuestos")
                        totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("totalImpuestosTrasladados").Value)
                    Catch ex As Exception
                        totalImpuestosTrasladados = 0
                    End Try
                    If totalImpuestosTrasladados = 0 Then
                        Try
                            Impuestos = Comprobante("cfdi:Impuestos")
                            totalImpuestosTrasladados = CDec(Impuestos.Attributes.GetNamedItem("TotalImpuestosTrasladados").Value)
                        Catch ex As Exception
                            totalImpuestosTrasladados = 0
                        End Try
                    End If
                    Try
                        If totalImpuestosTrasladados = 0 Then
                            vsTIT = 0
                            k = 1
                            For Each vRegIT As XmlElement In Impuestos.ChildNodes
                                If vRegIT.Name = "cfdi:Traslados" Then
                                    vsTIT = vsTIT + CDec(vRegIT.FirstChild.Attributes("importe").Value)
                                End If
                            Next
                        Else
                            vsTIT = totalImpuestosTrasladados
                        End If
                    Catch ex As Exception
                        'Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    IVAcfd = totalImpuestosTrasladados

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
                                UsoCFD = strUsoCFDI
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
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
            End If
            Return UUID
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub tPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPOLIZA.KeyPress
        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub
End Class