Imports System.IO
Imports System.Xml
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports System.Text.RegularExpressions

Public Class FrmPagoComplementoAE

    Private _comprobante As Comprobante
    Private _documentosRelacionados As List(Of PDoctoRelacionado)
    Private _impuestosDR As List(Of ImpuestosDR)

    Private _retencionesDR As RetencionesDR
    Private _TrasladosDR As List(Of TrasladosDR)

    Private EMISOR_RAZON_SOCIAL As String = "", EMISOR_LUGAR_EXPEDICION As String = ""
    Private EMISOR_REGIMEN_FISCAL As String = ""
    Private TIENE_DOC_RELACIONADOS As Boolean

    Private OBSER As String = ""
    Private TIMBRADO_DEMO As String = "No"
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private EMISOR_RFC As String
    Private CVE_FOLIO As String
    Private TIPO_VENTA_G As String = "G"
    Private LETRA_G As String = "STAND."
    Private Exito As Boolean = False
    Private c_ As Integer
    Private UUID_G As String
    Private ISNEW As Boolean

    Private ENTRA As Boolean = True
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        INICIO()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Sub INICIO()
        Dim CADENA As String = ""

        

        Try
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            '3 FORMAT DE PAGO
            TXT.BorderColor = Color.Black
            TXTN.BorderColor = Color.Black
            If PASS_GRUPOCE = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
            End If

            PassData5 = ""
            ReDim aDATA(0, 1)

            Fg.Rows.Count = 2
            Fg.DrawMode = DrawModeEnum.OwnerDraw
            '                    documento       ...      pago sat        ...        fecha       importe       moneda         ...     tipo cambio       ...
            '                        1            2           3            4            5             6            7            8            9            10
            'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
            '        "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & " " & vbTab &
            '        " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "")
            '   11           12           13           14           15           16           17           18           19            20
            '                                  num. cuenta      ...           rfc         banco         ...       cta benefi      ...      rfc benefi    num. peracion
            '   21             22           23            24            25
            '  status         obser      CVE_DOC REL.   UUID REL      NO. PARTIDA   REFER_DR
            Fg(1, 1) = "" 'REFER
            Fg(1, 2) = ""
            Fg(1, 3) = "" 'PAGO SAT
            Fg(1, 4) = ""
            Fg(1, 5) = Now 'FECHA
            Fg(1, 6) = 0 'IMPORTE
            Fg(1, 7) = "" 'MOEDA
            Fg(1, 8) = "" '...
            Fg(1, 9) = "" 'TIPO CAMBIO
            Fg(1, 10) = "" '...
            Fg(1, 11) = ""
            Fg(1, 12) = ""
            Fg(1, 13) = ""
            Fg(1, 14) = ""
            Fg(1, 15) = ""
            Fg(1, 16) = ""
            Fg(1, 17) = ""
            Fg(1, 19) = ""
            Fg(1, 18) = ""
            Fg(1, 20) = ""
            Fg(1, 21) = ""
            Fg(1, 22) = ""
            Fg(1, 23) = ""
            Fg(1, 24) = ""
            Fg(1, 25) = "" 'NO: PARTIDA
            Fg(1, 26) = "" 'REFER_DR
            Fg(1, 27) = 0 'REFER_DR



            Fg.Cols(2).Width = 20
            Fg.Cols(4).Width = 20
            Fg.Cols(8).Width = 20
            Fg.Cols(10).Width = 20
            Fg.Cols(11).Width = 120
            Fg.Cols(12).Width = 120
            Fg.Cols(13).Width = 20
            Fg.Cols(16).Width = 20
            Fg.Cols(18).Width = 20


            If PASS_GRUPOCE = "BUS" Then
                Fg.Cols(11).Visible = False
                Fg.Cols(11).AllowEditing = False
                Fg.Cols(23).Visible = False
                Fg.Cols(24).Visible = False
                Fg.Cols(25).Visible = False
                Fg.Cols(26).Visible = False
            Else
                Fg.Cols(11).Visible = False
                Fg.Cols(11).AllowEditing = False
                Fg.Cols(23).Visible = False
                Fg.Cols(24).Visible = False
                Fg.Cols(25).Visible = False
                Fg.Cols(26).Visible = False

            End If

            Fg.SetCellImage(0, 1, My.Resources.cuadro2)
            Fg.SetCellImage(0, 3, My.Resources.cuadro2)
            Fg.SetCellImage(0, 6, My.Resources.cuadro2)
            Fg.SetCellImage(0, 7, My.Resources.cuadro2)
            Fg.SetCellImage(0, 9, My.Resources.cuadro2)

            FgDR.Rows.Count = 1

            'Hyperlink column
            'Dim hyperlinkCol As Column = Fg.Cols(11)
            'hyperlinkCol.AllowEditing = True
            'hyperlinkCol.Width = 190
            'hyperlinkCol.Caption = ""
            'hyperlinkCol.ComboList = "..."

            'Dim cs As CellStyle = Fg.Styles.Add("NewLink")
            'cs.Font = New Font(Fg.Font, FontStyle.Underline)
            'cs.ForeColor = Color.Blue

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE FROM GCUSUARIOS_PARAM WHERE 
                    UPPER(USUARIO) = '" & USER_GRUPOCE.ToUpper & "' AND TIPO_DOC = 'G'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LETRA_G = dr("SERIE")
                    End If
                End Using
            End Using


            LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_PAGOS("G", LETRA_G)

            CADENA = ""
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_CPTO, DESCR FROM CONC" & Empresa & " WHERE STATUS = 'A' AND ISNULL(FORMADEPAGOSAT,'') <> ''"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CADENA = CADENA & "|" & dr("NUM_CPTO").ToString.PadLeft(4) & " " & dr("DESCR")
                    End While
                End Using
            End Using

            CADENA = ""
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_MONED, DESCR FROM MONED" & Empresa & " WHERE STATUS = 'A' ORDER BY NUM_MONED"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CADENA = CADENA & "|" & Format(dr("NUM_MONED"), "00") & " " & dr("DESCR")
                    End While
                End Using
            End Using


            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        gUSUARIO_PAC = dr("USUARIO")
                        gPASS_PAC = Desencriptar(dr("PASS"))
                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                            TIMBRADO_SAT = "No"
                        Else
                            TIMBRADO_DEMO = "Si"
                            TIMBRADO_SAT = "Si"
                            LtTimbrado.Text = "TIMBRADO DEMO"
                        End If

                        EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr("EMISOR_RFC")
                        EMISOR_LUGAR_EXPEDICION = dr("EMISOR_LUGAR_EXPEDICION")
                        EMISOR_REGIMEN_FISCAL = dr("EMISOR_REGIMEN_FISCAL")
                        gRutaXML_NO_TIMBRADO = dr("RUTA_XML_NOTIMBRADO")
                        gRutaXML_TIMBRADO = dr("RUTA_XML_TIMBRADO")
                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado

                        LtRegimenEmisor.Text = EMISOR_REGIMEN_FISCAL
                    End If
                End Using
            End Using

        Catch ex As Exception
            BITACORACFDI("1080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "DELETE FROM GCCFDI_COMPAGO_PAR_DR"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        If Var11 = "edit" Then
            ISNEW = False
            'Var12 = Fg(Fg.Row, 1) 'REFER
            BarGrabar.Enabled = False
            BarEliminarPart.Enabled = False
            BarFolioDigital.Enabled = False
            btnClie.Enabled = False
            TCLIENTE.Enabled = False
            F1.Enabled = False
            BtnRefreshCliente.Enabled = False

            BarCFDIRel.Visible = True

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT P.CVE_DOC, P.CLIENTE, P.ESTATUS, P.IMPORTE, P.FECHA, P.RFC
                        FROM CFDI_COMPAGO P 
                        WHERE CVE_DOC = '" & Var12 & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LtCVE_DOC.Text = Var12
                            TCLIENTE.Text = dr("CLIENTE")
                            LLENA_CAMPOS(TCLIENTE.Text)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            Try
                Fg.Rows.Count = 1
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT P.CVE_DOC, P.NUM_PAR, P.REFER, P.ESTATUS, P.FORMAPAGOSAT, P.FACTURA, P.FECHA, P.IMPORTE, 
                        P.CVE_OBS, P.CVE_MONED, P.TCAMBIO, P.CTA_ORD, P.RFC_ORD, P.BANCO_ORD, P.CTA_BEN, P.RFC_BEN, 
                        NUM_OPERACION, P.NUM_CPTO
                        FROM CFDI_COMPAGO_PAR P WHERE CVE_DOC = '" & Var12 & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Fg.AddItem("" & vbTab & dr("REFER") & vbTab & "" & vbTab & dr("FORMAPAGOSAT") & vbTab & "" & vbTab &
                                       dr("FECHA") & vbTab & dr("IMPORTE") & vbTab & dr("CVE_MONED") & vbTab & "" & vbTab &
                                       dr("TCAMBIO") & vbTab & "" & vbTab & "" & vbTab & dr("CTA_ORD") & vbTab & "" & vbTab &
                                       dr("RFC_ORD") & vbTab & dr("BANCO_ORD") & vbTab & "" & vbTab & dr("CTA_BEN") & vbTab &
                                       "" & vbTab & dr("RFC_BEN") & vbTab & dr("NUM_OPERACION") & vbTab & "" & vbTab &
                                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & dr("NUM_CPTO"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            Try
                FgDR.Rows.Count = 1


                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM CFDI_COMPAGO_PAR_DR WHERE CVE_DOC = '" & Var12 & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            FgDR.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & "" & vbTab & dr("NUMPARCIALIDAD") & vbTab & dr("FECHA") & vbTab & dr("IMPSALDOANT") & vbTab &
                                         dr("IMPPAGADO") & vbTab & dr("IMPSALDOINSOLUTO") & vbTab & dr("IDDOCUMENTO") & vbTab & dr("SERIE") & vbTab & dr("FOLIO") & vbTab &
                                         dr("MONEDADR") & vbTab & dr("FORMADEPAGOSAT") & vbTab & dr("TCAMBIO") & vbTab & 0 & vbTab & 0 & vbTab & 0 & vbTab & 0 & dr("IMPMON_EXT"))
                        End While
                        Fg.AutoSizeCols()
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        Else
            ISNEW = True
        End If

    End Sub
    Private Sub FrmPagoComplementoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Dim myuuid As Guid = Guid.NewGuid()
        UUID_G = myuuid.ToString()

        PassData2 = UUID_G
        FFormOpen = "CLOSE"

        Fg.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter

        TCLIENTE.Focus()
        Try
            Fg.SetCellImage(Fg.Rows.Count - 1, 11, My.Resources.lapiz22)
            Dim cs As CellStyle = Fg.Styles.Add("BooleanFilterCell")
            cs.ImageAlign = ImageAlignEnum.CenterCenter
            Fg.SetCellStyle(Fg.Rows.Count - 1, 11, cs)
        Catch ex As Exception
        End Try

    End Sub
    Private Function GetConcepto() As Concepto
        Dim c As New Concepto With {
            .ClaveProdServ = "84111506",
            .ClaveUnidad = "ACT",
            .ValorUnitario = 0,
            .Importe = 0,
            .Cantidad = 1,
            .Descripcion = "Pago",
            .ObjetoImp = "01"}
        Return c
    End Function
    Private Sub CalculaTotales()
        Dim montoTotalPagos As Single = 0
        For Each p As Pago In _comprobante.Complemento.Pagos.Pago
            montoTotalPagos += p.Monto
        Next

        _comprobante.Complemento.Pagos.Totales.MontoTotalPagos = montoTotalPagos
    End Sub
    Private Function ValidaCamposConcepto() As Boolean
        Dim band As Boolean = True
        'If (nudPagoMonto.Value <= 0) Then
        'lError.Text = "El campo Monto debe ser mayor a 0"
        'band = False
        'End If
        'If (cbPagoFormaPago.SelectedValue = Nothing) Then
        'lError.Text = "El campo Forma de pago es obligatorio"
        'band = False
        'End If
        'If (cbPagoMoneda.SelectedValue = Nothing) Then
        'lError.Text = "El campo Moneda es obligatorio"
        'band = False
        'End If
        'If (band = False) Then
        'tlpError.Visible = True
        'timer1.Enabled = True        '
        'End If
        Return band
    End Function
    Private Sub BtnConceptoAgregar_Click(sender As Object, e As EventArgs)
        If (ValidaCamposConcepto() = False) Then
            Return
        End If

    End Sub
    Private Sub GetCamposCombox()
    End Sub
    Private Sub BarFolioDigital_Click(sender As Object, e As ClickEventArgs) Handles BarFolioDigital.Click
        Try
            'Var14 = Fg(Fg.Row, 1)
            'Var18 = Fg(Fg.Row, 2)
            Var14 = "G"
            Var15 = "D"
            frmSelSerie.ShowDialog()
            If Var14.Trim.Length > 0 Then
                LETRA_G = Var14
                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_PAGOS("G", LETRA_G)
                'cargarUsosCfdi()
            End If
        Catch ex As Exception
            BITACORACFDI("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCFDIRel_Click(sender As Object, e As ClickEventArgs) Handles BarCFDIRel.Click
        Dim z As Integer = 0

        Lt2.Visible = False
        Var47 = "PAGO CFDI"
        Var25 = TCLIENTE.Text
        FrmCFDIRelacionados.ShowDialog()
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                Lt2.Visible = True
                Lt2.Text = "Documentos relacionados"
            Else
                Lt2.Text = ""
                Lt2.Visible = False
            End If

        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub AGREGA_CFDIRELACIONADOS()
        Dim z As Integer
        Dim _cfdiRelacionados As New CfdiRelacionados

        Try
            z = 0
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                _cfdiRelacionados.TipoRelacion = PassData5
                '
                For k = 0 To aDATA.GetLength(0) - 1
                    If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                        If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then

                            Dim c As New CfdiRelacionado With {
                                .UUID = aDATA(k, 1)
                            }
                            '_c.CfdiRelacionados.CfdiRelacionado.Add(c)
                            _cfdiRelacionados.CfdiRelacionado.Add(c)
                            TIENE_DOC_RELACIONADOS = True
                        End If
                    End If
                Next
                _comprobante.CfdiRelacionados = _cfdiRelacionados
            End If
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
            Var44 = -9
        End Try

    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim DOCTO As String = ""
        Dim CER64 As String, KEY64 As String, USUAARIO_TIMB As String, PASS_TIMB As String, CVE_OBS As Long
        Dim CVE_DOC As String = "", REFER As String = "", FORMA_PAGO_SAT As String = "", IMPORTE As Decimal
        Dim CVE_MONED As String = "", TIPO_CAMBIO As Integer, CTA_BAN_ORD As String = "", RFC_ORD As String = "", BANCO_ORD As String = ""
        Dim CTA_BAN_BEN As String = "", RFC_BEN As String = "", NUM_OPER As String = "", Continua As Boolean = False, Continua_Par As Boolean
        Dim FECHA_PAGO As Date, NUM_CPTO As Integer = 0, resultado As String, z As Integer = 0, NO_PARTIDA_CUEN_DET As Integer

        Dim IMPPAGADO As Decimal = 0, ErroFormPagoSat As Boolean = False
        Dim aUUID(0) As String, ListaUUID As New List(Of String)
        Dim d As DateTime = DateTime.Now

        Dim xdoc As New XmlDocument()

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim HayErr As Boolean = False

            For k = 1 To FgDR.Rows.Count - 1
                If IsNothing(FgDR(k, 11)) Or IsNothing(FgDR(k, 12)) Then
                    HayErr = True
                Else
                    If FgDR(k, 11).ToString.Trim.Length = 0 Or FgDR(k, 12).ToString.Trim.Length = 0 Then
                        HayErr = True
                    End If
                End If
            Next
            If HayErr Then
                MsgBox("Existe un problema en la moneda y forma de pago en los documentos relacionados, verifique por favor")
                Return
            End If
        Catch ex As Exception
            BITACORACFDI("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try


        If MsgBox("Realmente desea realizar el complemento de pago?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            IMPPAGADO = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(SUM(IMPPAGADO),0) AS PAGADO FROM GCCFDI_COMPAGO_PAR_DR"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        IMPPAGADO = dr.ReadNullAsEmptyDecimal("PAGADO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        If IMPPAGADO <= 0 Then
            MsgBox("No se encontraron documentos aa realizar complemento de pago")
            Return
        End If


        Try
            _comprobante = New Comprobante With {.Fecha = Date.Now}

            _comprobante.Conceptos.Concepto.Add(GetConcepto())
            _comprobante.Emisor.Nombre = EMISOR_RAZON_SOCIAL
            _comprobante.Emisor.Rfc = EMISOR_RFC
            _comprobante.LugarExpedicion = EMISOR_LUGAR_EXPEDICION
            '_comprobante.Complemento.Pagos.Version = "1.0"
            _comprobante.SubTotal = 0
            _comprobante.Total = 0
            _comprobante.Emisor.RegimenFiscal = LtRegimenEmisor.Text
            _comprobante.TipoDeComprobante = "P"
            _comprobante.Exportacion = "01"
            _comprobante.Moneda = "XXX"

            _comprobante.Complemento = New Complemento With {
                .Pagos = New Pagos
            }

            _comprobante.Receptor.Nombre = LtNombre.Text
            _comprobante.Receptor.Rfc = LtRFC.Text
            _comprobante.Receptor.UsoCFDI = LtUSO_CFDI.Text
            _comprobante.Receptor.RegimenFiscalReceptor = LtRegimenReceptor.Text
            _comprobante.Receptor.DomicilioFiscalReceptor = LtCP.Text

            For k = 1 To Fg.Rows.Count - 1

                Try
                    REFER = "" : FORMA_PAGO_SAT = "" : IMPORTE = 0 : CVE_MONED = "" : TIPO_CAMBIO = 0 : CTA_BAN_ORD = ""
                    RFC_ORD = "" : BANCO_ORD = "" : CTA_BAN_BEN = "" : RFC_BEN = "" : NUM_OPER = ""
                    If Not IsNothing(Fg(k, 1)) Then
                        DOCTO = Fg(k, 1)
                    End If
                    If Not IsNothing(Fg(k, 3)) Then
                        FORMA_PAGO_SAT = Fg(k, 3)
                        If FORMA_PAGO_SAT = "99" And DOCTO.Trim.Length > 0 Then
                            ErroFormPagoSat = True
                        End If
                    End If
                    If Not IsNothing(Fg(k, 6)) Then
                        IMPORTE = Fg(k, 6)
                    End If
                    If Not IsNothing(Fg(k, 7)) Then
                        CVE_MONED = Fg(k, 7)
                    End If
                    If Not IsNothing(Fg(k, 9)) Then
                        TIPO_CAMBIO = Fg(k, 9)
                    End If
                    If Not IsNothing(Fg(k, 12)) Then
                        If Not IsDBNull(Fg(k, 12)) Then
                            CTA_BAN_ORD = Fg(k, 12)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 14)) Then
                        If Not IsDBNull(Fg(k, 14)) Then
                            RFC_ORD = Fg(k, 14)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 15)) Then
                        If Not IsDBNull(Fg(k, 15)) Then
                            BANCO_ORD = Fg(k, 15)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 17)) Then
                        If Not IsDBNull(Fg(k, 17)) Then
                            CTA_BAN_BEN = Fg(k, 17)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 19)) Then
                        If Not IsDBNull(Fg(k, 19)) Then
                            RFC_BEN = Fg(k, 19)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 20)) Then
                        NUM_OPER = Fg(k, 20)
                    Else
                        NUM_OPER = ""
                    End If
                    'If Not IsNothing(Fg(k, 25)) Then 'NO_PARTIDA
                    'If IsNumeric(Fg(k, 25)) Then
                    'NO_PARTIDA_CUEN_DET = Fg(k, 25)
                    'Else
                    'NO_PARTIDA_CUEN_DET = 1
                    'End If
                    'Else
                    'NO_PARTIDA_CUEN_DET = 1
                    'End If
                    If Not IsNothing(Fg(k, 27)) Then
                        If IsNumeric(Fg(k, 27)) Then
                            NUM_CPTO = Fg(k, 27)
                        Else
                            NUM_CPTO = 0
                        End If
                    Else
                        NUM_CPTO = 0
                    End If
                    If REFER.Trim.Length > 0 Or FORMA_PAGO_SAT.Length > 0 Or IMPORTE > 0 Or CVE_MONED.Trim.Length > 0 Or TIPO_CAMBIO > 0 Or NUM_CPTO > 0 Then
                        z += 1
                    End If

                Catch ex As Exception
                    BITACORACFDI("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next

            If z = 0 Then
                MsgBox("Algunas datos no se capturaron verifique por favor")
                Return
            End If

            If ErroFormPagoSat Then
                MsgBox("Error en la forma de pago verifique por favor")
                Return
            End If

            Try
                Try
                    If TIMBRADO_DEMO = "Si" Then
                        USUAARIO_TIMB = "demo2"
                        PASS_TIMB = "123456789"
                    Else
                        USUAARIO_TIMB = gUSUARIO_PAC
                        PASS_TIMB = gPASS_PAC
                    End If

                    CER64 = ConvertFileToBase64(gRutaCertificado)
                    KEY64 = ConvertFileToBase64(gRutaPFX)

                    resultado = ""
                    'Dim FECHA_CAN As String = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss")
                    CVE_DOC = SIGUIENTE_CVE_DOC_PAGOS("G", LETRA_G)
                Catch ex As Exception
                    BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                End Try

                For k = 1 To 5


                    '░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                    'CABEZAS

                    Try
                        Try
                            Dim Sigue As Boolean
                            Sigue = True
                            Do While Sigue

                                If LETRA_G.Trim.Length = 0 Or LETRA_G = "STAND." Then
                                    CVE_DOC = Space(10) & Format(FOLIO_G, "0000")
                                Else
                                    CVE_DOC = LETRA_G & Format(FOLIO_G, "0000")
                                End If

                                If EXISTE_PAGO_COMP("G", CVE_DOC) Then
                                    FOLIO_G += 1
                                Else
                                    Sigue = False
                                End If
                            Loop
                        Catch ex As Exception
                            BITACORACFDI("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        SQL = "INSERT INTO CFDI_COMPAGO (CVE_DOC, TIPO_COMPROBANTE, CLIENTE, ESTATUS, IMPORTE, REFERENCIA, FECHA, CVE_OBS, 
                            RFC, SERIE, FOLIO, USUARIO, CVE_BITA, VERSION, UUID, FECHAELAB) VALUES(
                            @CVE_DOC, @TIPO_COMPROBANTE, @CLIENTE, 'P', @IMPORTE, @REFERENCIA, @FECHA, @CVE_OBS, @RFC, 
                            @SERIE, @FOLIO, @USUARIO, @CVE_BITA, '4.0', NEWID(), GETDATE())"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                            cmd.Parameters.Add("@TIPO_COMPROBANTE", SqlDbType.VarChar).Value = "P"
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPPAGADO
                            cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = LtRFC.Text
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = "G"
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO_G
                            cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = 0
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Continua = True
                                    Exit For
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                    End Try
                    If Not Valida_Conexion() Then
                    End If
                    CVE_DOC = SIGUIENTE_CVE_DOC_PAGOS("G", LETRA_G)
                Next

                If Continua Then
                    For k = 1 To Fg.Rows.Count - 1

                        Try
                            FECHA_PAGO = Now
                            If Not IsNothing(Fg(k, 1)) Then
                                DOCTO = Fg(k, 1)
                            End If
                            If Not IsNothing(Fg(k, 3)) Then
                                FORMA_PAGO_SAT = Fg(k, 3)
                                If FORMA_PAGO_SAT = "99" And DOCTO.Trim.Length > 0 Then
                                    ErroFormPagoSat = True
                                End If
                            End If
                            If Not IsNothing(Fg(k, 5)) Then
                                If IsDate(Fg(k, 5)) Then
                                    FECHA_PAGO = Fg(k, 5)
                                End If
                            End If
                            If Not IsNothing(Fg(k, 6)) Then
                                IMPORTE = Fg(k, 6)
                            End If

                            If Not IsNothing(Fg(k, 7)) Then
                                CVE_MONED = Fg(k, 7)
                            End If
                            If Not IsNothing(Fg(k, 9)) Then
                                TIPO_CAMBIO = Fg(k, 9)
                            End If
                            If Not IsNothing(Fg(k, 12)) Then
                                CTA_BAN_ORD = Fg(k, 12)
                            End If
                            If Not IsNothing(Fg(k, 14)) Then
                                RFC_ORD = Fg(k, 14)
                            End If
                            If Not IsNothing(Fg(k, 15)) Then
                                BANCO_ORD = Fg(k, 15)
                            End If
                            If Not IsNothing(Fg(k, 17)) Then
                                CTA_BAN_BEN = Fg(k, 17)
                            End If
                            If Not IsNothing(Fg(k, 19)) Then
                                RFC_BEN = Fg(k, 19)
                            End If
                            If Not IsNothing(Fg(k, 20)) Then
                                NUM_OPER = Fg(k, 20)
                            Else
                                NUM_OPER = ""
                            End If
                            'If Not IsNothing(Fg(k, 25)) Then 'NO_PARTIDA
                            'If IsNumeric(Fg(k, 25)) Then
                            'NO_PARTIDA_CUEN_DET = Fg(k, 25)
                            'Else
                            'NO_PARTIDA_CUEN_DET = 1
                            'End If
                            'Else
                            'NO_PARTIDA_CUEN_DET = 1
                            'End If
                            If Not IsNothing(Fg(k, 27)) Then
                                If IsNumeric(Fg(k, 27)) Then
                                    NUM_CPTO = Fg(k, 27)
                                Else
                                    NUM_CPTO = 0
                                End If
                            Else
                                NUM_CPTO = 0
                            End If
                        Catch ex As Exception
                            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                        End Try

                        CVE_OBS = 0

                        If DOCTO.Trim.Length > 0 And FORMA_PAGO_SAT.Trim.Length > 0 And IMPORTE > 0 And CVE_MONED.Trim.Length > 0 And TIPO_CAMBIO > 0 Then


                            '▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒

                            'PARTIDAS 
                            Try
                                IMPPAGADO = 0
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT IMPPAGADO AS PAGADO FROM GCCFDI_COMPAGO_PAR_DR 
                                        WHERE GUID_G = '" & UUID_G & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        While dr.Read
                                            IMPPAGADO += Math.Round(dr.ReadNullAsEmptyDecimal("PAGADO"), 2)
                                        End While
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try

                            Continua_Par = False

                            'Dim montoTotalPagos As Single = 0, TrasBaseIVAExento As Decimal = 0
                            'For Each p As Pago In _comprobante.Complemento.Pagos.Pago
                            '   montoTotalPagos = montoTotalPagos + p.Monto
                            'Next
                            '_comprobante.Complemento.Pagos.Totales.MontoTotalPagos = montoTotalPagos

                            If IMPPAGADO > 0 Then

                                For j = 1 To 9

                                    Try 'INDEX    CVE_DOC, REFER, TIPO_COMPROBANTE, NUM_PAR
                                        SQL = "SET ansi_warnings OFF
                                            INSERT INTO CFDI_COMPAGO_PAR (CVE_DOC, TIPO_COMPROBANTE, NUM_PAR, REFER, ESTATUS, FORMAPAGOSAT, NUM_CPTO,
                                            FACTURA, FECHA, FECHA_PAGO, IMPORTE, CVE_OBS, CVE_MONED, TCAMBIO, CTA_ORD, RFC_ORD, BANCO_ORD, CTA_BEN,
                                            RFC_BEN, NUM_OPERACION, NO_PARTIDA, UUID_G, FECHAELAB) VALUES(@CVE_DOC, @TIPO_COMPROBANTE, 
                                            ISNULL((SELECT MAX(NUM_PAR) + 1 FROM CFDI_COMPAGO_PAR WHERE CVE_DOC = @CVE_DOC AND REFER = @REFER AND
                                            TIPO_COMPROBANTE = @TIPO_COMPROBANTE),1), @REFER, 'E', @FORMAPAGOSAT, @NUM_CPTO, @FACTURA, @FECHA,
                                            @FECHA_PAGO, @IMPORTE, @CVE_OBS, @CVE_MONED, @TCAMBIO, @CTA_ORD, @RFC_ORD, @BANCO_ORD, @CTA_BEN, 
                                            @RFC_BEN, @NUM_OPERACION, @NO_PARTIDA, @UUID_G, GETDATE())"

                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                            cmd.Parameters.Add("@TIPO_COMPROBANTE", SqlDbType.VarChar).Value = "P"
                                            cmd.Parameters.Add("@REFER", SqlDbType.VarChar).Value = DOCTO
                                            cmd.Parameters.Add("@FORMAPAGOSAT", SqlDbType.VarChar).Value = FORMA_PAGO_SAT
                                            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.SmallInt).Value = NUM_CPTO
                                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = ""
                                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                                            cmd.Parameters.Add("@FECHA_PAGO", SqlDbType.DateTime).Value = FECHA_PAGO
                                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPPAGADO
                                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                                            cmd.Parameters.Add("@CVE_MONED", SqlDbType.VarChar).Value = CVE_MONED
                                            cmd.Parameters.Add("@TCAMBIO", SqlDbType.Float).Value = TIPO_CAMBIO
                                            cmd.Parameters.Add("@CTA_ORD", SqlDbType.VarChar).Value = CTA_BAN_ORD
                                            cmd.Parameters.Add("@RFC_ORD", SqlDbType.VarChar).Value = RFC_ORD
                                            cmd.Parameters.Add("@BANCO_ORD", SqlDbType.VarChar).Value = BANCO_ORD
                                            cmd.Parameters.Add("@CTA_BEN", SqlDbType.VarChar).Value = CTA_BAN_BEN
                                            cmd.Parameters.Add("@RFC_BEN", SqlDbType.VarChar).Value = RFC_BEN
                                            cmd.Parameters.Add("@NUM_OPERACION", SqlDbType.VarChar).Value = NUM_OPER
                                            cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.SmallInt).Value = NO_PARTIDA_CUEN_DET
                                            cmd.Parameters.Add("@UUID_G", SqlDbType.VarChar).Value = UUID_G
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                    Continua_Par = True
                                                    Exit For
                                                End If
                                            End If
                                        End Using
                                    Catch SQLex As SqlException
                                        Dim SSS As SqlError, Sqlcadena As String = ""
                                        'MsgBox("Count = " & SQLex.Errors.Count)
                                        For Each SSS In SQLex.Errors
                                            Sqlcadena += SSS.Message & vbNewLine
                                        Next
                                        MsgBox(Sqlcadena)
                                        BITACORACFDI("101. " & vbNewLine & SQLex.Data.ToString & SQLex.ErrorCode.ToString &
                                                     SQLex.GetBaseException.ToString & SQLex.LineNumber.ToString & SQLex.TargetSite.ToString)

                                    Catch ex As Exception
                                        MsgBox("10. " & vbNewLine & ex.StackTrace)
                                        BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                                    End Try
                                    If Not Valida_Conexion() Then
                                    End If
                                Next
                            End If

                            If Continua_Par Then
                                Dim LETRA_DR As String

                                LETRA_DR = Regex.Replace(REFER, "[^a-zA-Z]", "")

                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT DR.CVE_DOC, DR.FECHA, DR.IMPSALDOANT, DR.IMPPAGADO, DR.IMPSALDOINSOLUTO, DR.NUMPARCIALIDAD, DR.MONEDADR, DR.EQUIVALENCIADR, 
                                        DR.FOLIO, DR.SERIE, DR.OBJETOIMP_DR, DR.IDDOCUMENTO, DR.FORMADEPAGOSAT, DR.TCAMBIO, ISNULL(F.SUBTOTAL,0) AS SUBT, ISNULL(F.IVA,0) AS IV, 
                                        ISNULL(F.RETENCION,0) AS RET, DR.IMPU1, DR.IMPU2, DR.IMPU3, DR.IMPU4, IMPNUM_EXT
                                        FROM GCCFDI_COMPAGO_PAR_DR DR
                                        LEFT JOIN CFDI F ON F.FACTURA = DR.CVE_DOC
                                        WHERE GUID_G = '" & UUID_G & "' ORDER BY NUMPARCIALIDAD"
                                    cmd3.CommandText = SQL
                                    Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                        While dr3.Read
                                            Try
                                                SQL = "INSERT INTO CFDI_COMPAGO_PAR_DR (CVE_DOC, NUM_PAR, REFER, DOCTO, FECHA, FOLIO, OBJETOIMP_DR, IMPSALDOINSOLUTO, 
                                                    IMPPAGADO, IMPSALDOANT, NUMPARCIALIDAD, EQUIVALENCIADR, MONEDADR, SERIE, IDDOCUMENTO, FORMADEPAGOSAT, TCAMBIO, GUID_G,
                                                    IMPU1, IMPU2, IMPU3, IMPU4) 
                                                    VALUES(
                                                    @CVE_DOC, ISNULL((SELECT MAX(ISNULL(NUM_PAR,0)) + 1 FROM CFDI_COMPAGO_PAR_DR WHERE CVE_DOC = @CVE_DOC),1), @REFER, @DOCTO, 
                                                    @FECHA, @FOLIO, @OBJETOIMP_DR, @IMPSALDOINSOLUTO, @IMPPAGADO, @IMPSALDOANT, @NUMPARCIALIDAD, @EQUIVALENCIADR, @MONEDADR, 
                                                    @SERIE, @IDDOCUMENTO, @FORMADEPAGOSAT, @TCAMBIO, @GUID_G, @IMPU1, @IMPU2, @IMPU3, @IMPU4)"
                                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                    cmd2.CommandText = SQL
                                                    cmd2.Parameters.Clear()
                                                    cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                                    cmd2.Parameters.Add("@REFER", SqlDbType.VarChar).Value = dr3("CVE_DOC")
                                                    cmd2.Parameters.Add("@IMPU1", SqlDbType.Float).Value = dr3.ReadNullAsEmptyDecimal("IMPU1")
                                                    cmd2.Parameters.Add("@IMPU2", SqlDbType.Float).Value = dr3.ReadNullAsEmptyDecimal("IMPU2")
                                                    cmd2.Parameters.Add("@IMPU3", SqlDbType.Float).Value = dr3.ReadNullAsEmptyDecimal("IMPU3")
                                                    cmd2.Parameters.Add("@IMPU4", SqlDbType.Float).Value = dr3.ReadNullAsEmptyDecimal("IMPU4")
                                                    cmd2.Parameters.Add("@DOCTO", SqlDbType.VarChar).Value = DOCTO
                                                    cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = dr3("FECHA")
                                                    cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = GetNumeric(dr3("CVE_DOC"))
                                                    cmd2.Parameters.Add("@OBJETOIMP_DR", SqlDbType.VarChar).Value = "02"
                                                    cmd2.Parameters.Add("@IMPSALDOINSOLUTO", SqlDbType.Float).Value = dr3("IMPSALDOINSOLUTO")
                                                    cmd2.Parameters.Add("@IMPPAGADO", SqlDbType.Float).Value = Math.Round(dr3("IMPPAGADO"), 2)
                                                    cmd2.Parameters.Add("@IMPSALDOANT", SqlDbType.Float).Value = dr3("IMPSALDOANT")
                                                    cmd2.Parameters.Add("@NUMPARCIALIDAD", SqlDbType.SmallInt).Value = dr3("NUMPARCIALIDAD")
                                                    cmd2.Parameters.Add("@EQUIVALENCIADR", SqlDbType.SmallInt).Value = dr3("EQUIVALENCIADR")
                                                    cmd2.Parameters.Add("@MONEDADR", SqlDbType.VarChar).Value = dr3("MONEDADR")
                                                    cmd2.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_DR
                                                    cmd2.Parameters.Add("@IDDOCUMENTO", SqlDbType.VarChar).Value = dr3("IDDOCUMENTO")
                                                    cmd2.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = dr3("FORMADEPAGOSAT")
                                                    cmd2.Parameters.Add("@TCAMBIO", SqlDbType.VarChar).Value = dr3("TCAMBIO")
                                                    cmd2.Parameters.Add("@GUID_G", SqlDbType.VarChar).Value = UUID_G
                                                    cmd2.Parameters.Add("@IMPNUM_EXT", SqlDbType.Float).Value = dr3("IMPNUM_EXT")
                                                    returnValue = cmd2.ExecuteNonQuery()
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                            End Try
                                        End While
                                    End Using
                                End Using

                                For z = 1 To 5
                                    SQL = "UPDATE CUEN_DET" & Empresa & " SET CVE_DOC_COMPPAGO = @CVE_DOC_COMPPAGO WHERE DOCTO = @REFER"
                                    Try
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.Add("@REFER", SqlDbType.VarChar).Value = DOCTO
                                            cmd.Parameters.Add("@CVE_DOC_COMPPAGO", SqlDbType.VarChar).Value = CVE_DOC
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If CInt(returnValue) > 0 Then
                                                Exit For
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                                    End Try
                                    If Not Valida_Conexion() Then
                                    End If
                                Next
                            End If
                        Else
                            Fg(k, 0) = "E"
                        End If
                    Next

                    Try
                        Dim CVE_DOC_F As String, UUID_F As String, FECHA_CERT As String = Now.ToString("yyyy-MM-ddTHH:mm:ss")

                        For k = 0 To aDATA.GetLength(0) - 1
                            If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                                If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then

                                    CVE_DOC_F = aDATA(k, 0)
                                    UUID_F = aDATA(k, 1)
                                    Try
                                        SQL = "INSERT INTO CFDI_REL" & Empresa & " (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC, FECHA_CERT) 
                                            VALUES ('" & UUID_F & "','" & PassData5 & "','" & CVE_DOC & "','" & CVE_DOC_F & "','P','" & FECHA_CERT & "')"

                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then

                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End If
                        Next
                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        If LETRA_G = "" Or LETRA_G = "STAND." Then
                            SQL2 = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & GetNumeric(CVE_DOC) & " WHERE TIP_DOC = 'G' AND SERIE = 'STAND.'"
                        Else
                            SQL2 = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & GetNumeric(CVE_DOC) & " WHERE TIP_DOC = 'G' AND SERIE = '" & LETRA_G & "'"
                        End If

                        EXECUTE_QUERY_NET(SQL2)
                    Catch ex As Exception
                        BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
                    End Try

                    LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_PAGOS("G", LETRA_G)

                    EXECUTE_QUERY_NET("DELETE FROM GCCFDI_COMPAGO_PAR_DR")


                    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓

                    ' INICA PROCESO DE TIMBRAR 

                    FrmTimbrarCdeP.LtNombre.Text = LtNombre.Text
                    FrmTimbrarCdeP.LtRFC.Text = LtRFC.Text
                    FrmTimbrarCdeP.LtUSO_CFDI.Text = LtUSO_CFDI.Text
                    FrmTimbrarCdeP.LtRegimenReceptor.Text = LtRegimenReceptor.Text
                    FrmTimbrarCdeP.LtCP.Text = LtCP.Text

                    Var4 = CVE_DOC
                    Var5 = LtCorreo.Text

                    PassData1 = "PAGO COMPLEMENTO"
                    Var18 = ""

                    FrmTimbrarCdeP.ShowDialog()

                    Limpiar()

                    If Var18 = "SI" Then
                        FILE_PDF = Var16
                        FrmOPenPDFGrapecity.Show()
                    End If

                End If
            Catch ex As Exception
                BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("12. " & ex.Message)
            End Try
            PassData5 = ""
            ReDim aDATA(0, 1)

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub Limpiar()
        Try
            Fg.Rows.Count = 1

            AGREGA_ROW()

            TCLIENTE.Text = ""
            LtNombre.Text = ""
            LtCP.Text = ""
            LtRFC.Text = ""
            LtUSO_CFDI.Text = ""
            LtRegimenReceptor.Text = ""
            F1.Value = Now

            FgDR.Rows.Count = 1

            TCLIENTE.Focus()
            TCLIENTE.Select()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim UUID As String, QR As String
        Try
            Dim XML As String, RUTA_DISCOC As String

            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("No existe comprobante a imprimir")
                Return
            End If

            If Not IsNothing(Fg(1, 1)) Then
                If Fg(1, 1).ToString.Trim.Length = 0 Then
                    MsgBox("No existe comprobante a imprimir")
                    Return
                End If
            End If
            If Not IsNothing(FgDR(1, 1)) Then
                If FgDR(1, 1).ToString.Trim.Length = 0 Then
                    MsgBox("No existe comprobante a imprimir")
                    Return
                End If
            End If

            SQL = "SELECT ISNULL(XML,'') AS XML_P FROM CFDI_COMPAGO WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        XML = dr("XML_P")
                    Else
                        XML = ""
                    End If
                End Using
            End Using

            Try
                Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String

                RUTA_FORMATOS = GET_RUTA_FORMATOS()

                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIPAGO.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
                Try
                    RUTA_DISCOC = "C:\TRANS PDF\SIN PRECIOS"
                    If Not Directory.Exists(RUTA_DISCOC) Then
                        Directory.CreateDirectory("C:\TRANS PDF")
                        Directory.CreateDirectory(RUTA_DISCOC)
                    End If
                Catch ex As Exception
                    RUTA_DISCOC = gRutaXML_TIMBRADO
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                UUID = BUSCAR_UUID_CFDI_PAGO(LtCVE_DOC.Text)

                'QR = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=91346FA9-B904-4CFB-95C8-8981989CBA6C&re=SCA920130LV3&rr=MOGM730513N54&tt=0.000000&fe=o7pPKA=="
                QR = "https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?&id=" & uuid & "&re=SCA920130LV3&rr=MOGM730513N54&tt=0.000000&fe=o7pPKA=="
                If File.Exists(ARCHIVO_MRT) Then

                    StiReport1.Load(ARCHIVO_MRT)
                    Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                            Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                    StiReport1.Dictionary.Databases.Clear()
                    StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                    StiReport1.Compile()
                    StiReport1("CVE_DOC") = LtCVE_DOC.Text

                    StiReport1.Render()
                    StiReport1.Show()
                Else
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    MsgBox("Cancelación exitosa")
                    Return
                End If
            Catch ex As Exception
                MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarRecepPagoMult_Click(sender As Object, e As ClickEventArgs) Handles BarRecepPagoMult.Click
        'frmRecepcionPagosCxC.ShowDialog()

        FrmPagoMultidocCxC.ShowDialog()

        Me.Show()
        Me.BringToFront()

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles btnClie.Click
        Try
            Var2 = "Clientes"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LLENA_CAMPOS(Var4)

                POS_FG()

                Var2 = ""
                Var4 = ""
                Var5 = ""
            Else
                If TCLIENTE.Text.Trim.Length > 0 Then
                    POS_FG()
                Else
                    TCLIENTE.Focus()
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("1080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub POS_FG()
        Try
            If Fg.Rows.Count = 1 Then
                AGREGA_ROW()
            End If

            Fg.Focus()
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            SendKeys.Send("{ENTER}")

        Catch ex As Exception
            BITACORACFDI("1080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            SendKeys.Send("{TAB}")
            Return
        End If
        Select Case e.KeyCode
            Case Keys.F7
                BarEliminarPart_Click(Nothing, Nothing)
                e.Handled = True
            Case Keys.F8
                BarDatosCliente_Click(Nothing, Nothing)
                e.Handled = True
            Case Keys.F9
                BarAltaCliente_Click(Nothing, Nothing)
                e.Handled = True
            Case Keys.F10
                BarAltaCtaOrdenante_Click(Nothing, Nothing)
                e.Handled = True
            Case Keys.F11
                BatAltaCtaBeneficiario_Click(Nothing, Nothing)
                e.Handled = True
        End Select
    End Sub

    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length = 0 Then
                Return
            End If
            LLENA_CAMPOS(TCLIENTE.Text)

            POS_FG()

        Catch ex As Exception
            BITACORACFDI("1620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnRefreshCliente_Click(sender As Object, e As EventArgs) Handles BtnRefreshCliente.Click
        Try
            BtnRefreshCliente.Visible = False
            Me.Refresh()

            LLENA_CAMPOS(TCLIENTE.Text)

            BtnRefreshCliente.Visible = True
        Catch ex As Exception
            BITACORACFDI("1620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENA_CAMPOS(ByVal fCLAVE As String)

        Me.Cursor = Cursors.WaitCursor

        Threading.Thread.Sleep(500)

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim USO_CFDI As String = ""

            If IsNumeric(fCLAVE.Trim) Then
                fCLAVE = Space(10 - fCLAVE.Trim.Length) & fCLAVE.Trim
                TCLIENTE.Text = fCLAVE
            End If

            cmd.Connection = cnSAE
            SQL = "SELECT NOMBRE, CALLE, COLONIA, NUMINT, NUMEXT, CODIGO, RFC, MUNICIPIO, ESTADO, USO_CFDI, 
                ISNULL(REG_FISC,'') AS REGFISC, ISNULL(EMAILPRED,'') AS CORREO
                FROM CLIE" & Empresa & " WHERE CLAVE  = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                LtNombre.Text = dr("NOMBRE").ToString
                LtRFC.Text = dr("RFC").ToString
                LtUSO_CFDI.Text = "CP01"
                LtRegimenReceptor.Text = dr("REGFISC")
                LtCP.Text = dr("CODIGO")
                LtCorreo.Text = dr("CORREO")
            Else
                MsgBox("Cliente inexistente")
                TCLIENTE.Text = ""

                LtNombre.Text = ""
                LtRFC.Text = ""
                LtUSO_CFDI.Text = ""
                LtRegimenReceptor.Text = ""
                LtCP.Text = ""
                LtCorreo.Text = ""

                TCLIENTE.Select()
            End If
            dr.Close()

        Catch ex As Exception
            BITACORACFDI("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub BarAltaCliente_Click(sender As Object, e As ClickEventArgs) Handles BarAltaCliente.Click

        Var1 = "Nuevo"
        Var11 = ""
        Var4 = "XXX"
        frmClientesAE.ShowDialog()
        If Var11.Trim.Length > 0 Then
            TCLIENTE.Text = Var11
        End If
    End Sub

    Private Sub BarDatosCliente_Click(sender As Object, e As ClickEventArgs) Handles BarDatosCliente.Click
        If TCLIENTE.Text.Trim.Length > 0 Then

            Var1 = "Consulta"
            Var2 = TCLIENTE.Text

            FrmDatosCliente.ShowDialog()
        End If
    End Sub
    Private Sub BarEliminarPart_Click(sender As Object, e As ClickEventArgs) Handles BarEliminarPart.Click
        Try
            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                Fg.RemoveItem(Fg.Row)
                Try
                    SQL = "DELETE FROM GCCFDI_COMPAGO_PAR_DR WHERE GUID_G = '" & UUID_G & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                    End Using

                    AGREGA_ROW()

                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObsDoc_Click(sender As Object, e As ClickEventArgs) Handles BarObsDoc.Click
        Try
            TIPO_OTI = 1
            TIPO_COMPRA = "o"
            Var4 = OBSER
            frmObserDocumento.ShowDialog()
            OBSER = Var4
        Catch ex As Exception
            BITACORACFDI("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObsPart_Click(sender As Object, e As ClickEventArgs) Handles BarObsPart.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                    TIPO_OTI = 1
                    TIPO_COMPRA = "o"
                    Var4 = Fg(Fg.Row, 21)
                    frmObserDocumento.ShowDialog()
                    Fg(Fg.Row, 21) = Var4
                Else
                    MsgBox("Por favor seleccione ua partida válida")
                End If

            Else
                MsgBox("Por favor seleccione una partida")
            End If
        Catch ex As Exception
            BITACORACFDI("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTotales_Click(sender As Object, e As ClickEventArgs) Handles BarTotales.Click

    End Sub
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "ClieDocSaldos"
            Var4 = ""
            Var5 = ""
            Var10 = " AND CVE_CLIE = '" & TCLIENTE.Text & "' "
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Fg(Fg.Row, 1) = Var4
                'Var4 = Fg(Fg.Row, 1).ToString  'REFER
                'Var5 = Fg(Fg.Row, 2).ToString  'CLIENTE
                'Var7 = Fg(Fg.Row, 7) 'ABONOS
                'Var8 = Fg(Fg.Row, 8) 'IMPORTE
                'Var9 = Fg(Fg.Row, 8) + Fg(Fg.Row, 7)  'SALDO
                'Var6 = Fg(Fg.Row, 11).ToString  'NUM_CPTO

                Fg.Focus()

                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Col = 3

            End If

        Catch Ex As Exception
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            BITACORACFDI("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Not ISNEW Then
                Return
            End If

            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 20 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENA_VECTOR(FROW As Integer)
        Dim Texto As String, z As Integer = 0, Texto2 As String, Texto3 As String
        Dim delimitadores() As String = {"@"}
        Dim vectoraux() As String, vectoraux2() As String, vectoraux3() As String

        Try
            If Not IsNothing(Fg(FROW, 23)) Then
                Texto = Fg(FROW, 23)
            Else
                Texto = ""
            End If
            If Not IsNothing(Fg(FROW, 24)) Then
                Texto2 = Fg(FROW, 24)
            Else
                Texto2 = ""
            End If
            If Not IsNothing(Fg(FROW, 25)) Then
                Texto3 = Fg(FROW, 25)
            Else
                Texto3 = ""
            End If

            vectoraux = Texto.Split(delimitadores, StringSplitOptions.None)
            vectoraux2 = Texto2.Split(delimitadores, StringSplitOptions.None)
            vectoraux3 = Texto3.Split(delimitadores, StringSplitOptions.None)

            If Texto.Trim.Length > 0 Then
                For Each item As String In vectoraux
                    If item.ToString.Length > 0 Then
                        z += 1
                    End If
                Next

                ReDim aDATA(z, 2)
                z = 0
                For Each item As String In vectoraux
                    If item.ToString.Length > 0 Then
                        aDATA(z, 0) = item
                        z += 1
                    End If
                Next
                z = 0
                For Each item As String In vectoraux2
                    If item.ToString.Length > 0 Then
                        aDATA(z, 1) = item
                        z += 1
                    End If
                Next
                z = 0
                For Each item As String In vectoraux3
                    If item.ToString.Length > 0 Then
                        aDATA(z, 2) = item
                        z += 1
                    End If
                Next
            Else
                ReDim aDATA(0, 2)
                aDATA(0, 0) = ""
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub UPDATE_VECTOR(FROW As Integer)
        Dim TEXTO As String = "", TEXTO2 As String = "", TEXTO3 As String = ""
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                Try
                    If Not IsNothing(aDATA(k, 0)) Then
                        TEXTO = TEXTO & aDATA(k, 0) & "@"
                        TEXTO2 = TEXTO2 & aDATA(k, 1) & "@"
                        TEXTO3 = TEXTO3 & aDATA(k, 2) & "@"
                    End If
                Catch ex As Exception
                    BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Fg(FROW, 23) = TEXTO
            Fg(FROW, 24) = TEXTO2
            Fg(FROW, 25) = TEXTO3
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Not ISNEW Then
                Return
            End If
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 10 Then
                    If Not IsNothing(Fg(Fg.Row, 10)) Then
                        If Fg(Fg.Row, 10).ToString.Trim.Length = 0 Then
                            'Fg(Fg.Row, 10) = "No"
                        End If
                    Else
                        'Fg(Fg.Row, 10) = "No"
                    End If
                End If 'Or Fg.Col = 11 
                If Fg.Col = 1 Or Fg.Col = 2 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 6 Or Fg.Col = 7 Or
                    Fg.Col = 9 Or Fg.Col = 10 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or
                    Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 17 Or Fg.Col = 18 Or Fg.Col = 19 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORACFDI("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            If Not ISNEW Then
                Return
            End If

            If Fg.Row > 0 Then
                If TCLIENTE.Text.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione el cliente")
                    TCLIENTE.Focus()
                    Return
                End If
                If Fg.Col <> 2 Then
                    Try
                        If EstaFormOpen(FrmPDocDR) And Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                            Return
                        End If

                        If Not IsNothing(Fg(Fg.Row, 1)) Then
                            If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                                MsgBox("Por favor capture el documento")
                                Return
                            End If
                        End If
                    Catch ex As Exception
                        BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If Fg(Fg.Row, 3) = "01" Then
                        If Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 17 Or Fg.Col = 18 Or Fg.Col = 19 Then
                            Return
                        End If
                    End If

                End If

                Var4 = ""
                Var5 = ""
                'Fg.FinishEditing()
                '2	10	13	15
                If Fg.Col = 2 Then

                    If EstaFormOpen(FrmPDocDR) And Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                        Return
                    End If

                    ENTRA = False

                    Var2 = "PagoComplemento"
                    Var5 = TCLIENTE.Text
                    'SOLO FACTURAS QUE TENGAN 99 Y PPD
                    FrmSelItem2.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1).ToString   'DOCUMENTO
                        'Var5 = Fg(Fg.Row, 2).ToString   'CLIENTE
                        'Var6 = Fg(Fg.Row, 4).ToString   'FECHA
                        'Var7 = Fg(Fg.Row, 6).ToString   'DOCTO
                        'Var8 = Fg(Fg.Row, 7).ToString   'IMPORTE
                        'Var9 = Fg(Fg.Row, 8).ToString   'CVE_MONED  MXN
                        'Var21 = Fg(Fg.Row, 9).ToString   'TCAMBIO US 19.87, MXN = 1
                        'Var11 = Fg(Fg.Row, 11).ToString   'METODO DE PAGO
                        'Var12 = Fg(Fg.Row, 12).ToString   'FORMA DE PAGO SAT

                        Fg(Fg.Row, 1) = Var4
                        Fg(Fg.Row, 26) = Var4

                        If Var4.Trim.Length > 0 Then
                            DESPLEGAR_DR(Var4)
                            'If Not EstaFormOpen(FrmPDocDR) Then
                            'Dim Floating As New FrmPDocDR()
                            'Floating.Show(Me)
                            'End If
                        End If

                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 1
                        SendKeys.Send("{TAB}")
                    Else
                        Fg.Col = 1
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 4 Then
                    'FORMA DE PAGO SAT
                    Var2 = "tblcformapago"
                    Var2 = "ConcSAT"
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'FORMAPAGOSAT
                        'Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        'Var6 = Fg(Fg.Row, 3) 'NUM_CPTO

                        Fg(Fg.Row, 3) = Var4
                        Fg(Fg.Row, 27) = CInt(Var6)

                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 5
                    Else
                        Fg.Col = 3
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 8 Then
                    'MONEDA
                    Var2 = "Moneda"
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                        'Var5 = Fg(Fg.Row, 2) 'DESCR
                        'Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                        'Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                        Fg(Fg.Row, 7) = Var6
                        Fg(Fg.Row, 9) = Var7
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 9
                    Else
                        Fg.Col = 7
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 10 Then
                    'TIPO DE CAMBIO
                    Var2 = "Moneda"
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                        'Var5 = Fg(Fg.Row, 2) 'DESCR
                        'Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                        'Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                        Fg(Fg.Row, 7) = Var6
                        Fg(Fg.Row, 9) = Var4

                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 12
                    Else
                        Fg.Col = 9
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 13 Then
                    'NUM. CUENTA
                    Var2 = "CuentaOrdenante"
                    Var46 = TCLIENTE.Text

                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
                        'Var5 = Fg(Fg.Row, 2) 'RFC 
                        'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
                        Fg(Fg.Row, 12) = Var4
                        Fg(Fg.Row, 14) = Var5
                        Fg(Fg.Row, 15) = Var6
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 15
                    Else
                        Fg.Col = 12
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 16 Then
                    'BANCO
                    Var2 = "Bancos"
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'CLAVE
                        'Var5 = Fg(Fg.Row, 2) 'NOMBRE
                        Fg(Fg.Row, 15) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 15
                    Else
                        Fg.Col = 14
                    End If
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 18 Then
                    'CUENTA BANCARIA
                    Var2 = "CuentaBeneficiaria"
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
                        'Var5 = Fg(Fg.Row, 2) 'RFC 
                        'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
                        Fg(Fg.Row, 17) = Var4
                        Fg(Fg.Row, 19) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 17
                    Else
                        Fg.Col = 15
                    End If
                    ENTRA = True
                End If
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Not ISNEW Then
                Return
            End If

            If Fg.Row > 0 And ENTRA Then
                If Fg.Col <> 11 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If Not ISNEW Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                Select Case e.KeyCode
                    Case 5
                        'SendKeys.Send("{TAB}")
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If Not ISNEW Then
                Return
            End If

            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 10 Then
                    If Fg(Fg.Row, 10) = "No" Then
                        Fg.Row = Fg.Row + 1
                        Fg.Col = 0
                    End If
                End If
                Select Case e.KeyCode
                    Case 13
                        If e.Col = 5 Then
                            'Fg.Col = 7
                            'SendKeys.Send("{ENTER}")
                        End If
                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If Not ISNEW Then
            Return
        End If

        If Fg.Row > 0 And ENTRA Then
            If (e.KeyCode = 9) And Fg.Col = 5 Then
                Fg.Col = 6
                SendKeys.Send("{ENTER}")
            End If
        End If
    End Sub
    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F7
                    BarEliminarPart_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F8
                    BarDatosCliente_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F9
                    BarAltaCliente_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F10
                    BarAltaCtaOrdenante_Click(Nothing, Nothing)
                    e.Handled = True
                Case Keys.F11
                    BatAltaCtaBeneficiario_Click(Nothing, Nothing)
                    e.Handled = True
            End Select

            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 99 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                Fg.Col = 3
                            End If
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.Handled = False
                            Else
                                Fg.Col = 3
                            End If
                            SendKeys.Send("{ENTER}")
                        Case 3
                            Fg.Col = 5
                            'SendKeys.Send("{ENTER}")
                        Case 5
                            'Fg.Col = 6
                            'SendKeys.Send("{ENTER}")
                        Case 6
                            Fg.Col = 7
                            SendKeys.Send("{ENTER}")
                        Case 7
                            'MONEDA
                            ENTRA = False
                            If TXT.Text.Trim.Length > 0 Then
                                Dim DESCR As String
                                DESCR = BUSCA_CAT("Moneda2", TXT.Text)
                                If DESCR <> "" Then
                                    Fg(Fg.Row, 7) = DESCR
                                    Fg.Col = 9
                                    SendKeys.Send("{ENTER}")
                                Else
                                    ENTRA = False
                                    Fg.Col = 7
                                    ENTRA = False
                                    MsgBox("Moneda inexistente")
                                    ENTRA = False
                                    Fg.Col = 7
                                    c_ = 7
                                    TMagico.Focus()
                                    SendKeys.Send("{ENTER}")
                                End If
                            Else
                                Fg.Col = 9
                                SendKeys.Send("{ENTER}")
                            End If
                            ENTRA = True
                        Case 9
                            Fg.Col = 12
                            SendKeys.Send("{ENTER}")
                            ENTRA = True
                            Return
                        Case 12
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 15
                                SendKeys.Send("{ENTER}")
                            End If
                        Case 15
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 17
                                SendKeys.Send("{ENTER}")
                            End If
                        Case 17
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 19
                                SendKeys.Send("{ENTER}")
                            End If
                        Case 19
                            Fg.Col = 20
                            SendKeys.Send("{ENTER}")
                        Case 20
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                AGREGA_ROW()
                            Else
                                Fg.Row = Fg.Row + 1
                            End If

                            Fg.Col = 1
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = Keys.F2 Then
                    Select Case Fg.Col
                        Case 1
                            Try
                                If EstaFormOpen(FrmPDocDR) And Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                                    Return
                                End If

                                Var2 = "PagoComplemento"
                                Var5 = TCLIENTE.Text
                                'SOLO FACTURAS QUE TENGAN 99 Y PPD
                                FrmSelItem2.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    ENTRA = False
                                    'Var4 = Fg(Fg.Row, 1).ToString   'DOCUMENTO
                                    'Var5 = Fg(Fg.Row, 2).ToString   'CLIENTE
                                    'Var6 = Fg(Fg.Row, 4).ToString   'FECHA
                                    'Var7 = Fg(Fg.Row, 6).ToString   'DOCTO
                                    'Var8 = Fg(Fg.Row, 7).ToString   'IMPORTE
                                    'Var9 = Fg(Fg.Row, 8).ToString   'NO_PARTIDA
                                    'Var10 = Fg(Fg.Row, 9).ToString   'CVE_MONED  MXN
                                    'Var21 = Fg(Fg.Row, 10).ToString   'TCAMBIO US 19.87, MXN = 1

                                    If DOCUMENTO_AGREGADO_EN_FG(Var4) Then

                                        MsgBox("la partida ya fue agregada verifiaque por favor")
                                    Else
                                        TXT.Text = Var4
                                        Fg(Fg.Row, 1) = Var4
                                        Fg(Fg.Row, 6) = Var8
                                        Fg(Fg.Row, 7) = Var10
                                        Fg(Fg.Row, 9) = Var21
                                        Fg(Fg.Row, 20) = Var4
                                        Fg(Fg.Row, 25) = Var9
                                        '       REFER
                                        Fg(Fg.Row, 26) = Var4
                                        Var2 = "" : Var4 = "" : Var5 = ""
                                    End If
                                    ENTRA = True
                                    Fg.Col = 3
                                Else
                                    Fg.Col = 1
                                End If
                            Catch ex As Exception
                                BITACORACFDI("190. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 3
                            'FORMA DE PAGO SAT
                            Var2 = "tblcformapago"
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                ENTRA = False
                                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                                'Var5 = Fg(Fg.Row, 2) 'NOMBRE
                                TXT.Text = Var4
                                Fg(Fg.Row, 3) = Var4
                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True
                                Fg.Col = 5
                            Else
                                Fg.Col = 3
                            End If
                            ENTRA = True
                            Return

                        Case 7
                            'MONEDA
                            Var2 = "Moneda"
                            frmSelItem.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                ENTRA = False
                                'Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                                'Var5 = Fg(Fg.Row, 2) 'DESCR
                                'Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                                'Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                                TXT.Text = Var6
                                Fg(Fg.Row, 7) = Var6
                                Fg(Fg.Row, 9) = Var7
                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True
                                Fg.Col = 9
                            Else
                                Fg.Col = 7
                            End If
                        Case 12
                            'CUENTA BANCARIA ORDENANTE
                            'NUM. CUENTA
                            Var2 = "CuentaOrdenante"
                            Var46 = TCLIENTE.Text

                            frmSelItem.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                ENTRA = False
                                'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
                                'Var5 = Fg(Fg.Row, 2) 'RFC 
                                'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
                                TXT.Text = Var4
                                Fg(Fg.Row, 12) = Var4
                                Fg(Fg.Row, 14) = Var5
                                Fg(Fg.Row, 15) = Var6
                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True
                                Fg.Col = 17
                            Else
                                Fg.Col = 12
                            End If
                            Return
                        Case 15   'BANCO
                            Var2 = "Bancos"
                            frmSelItem.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                ENTRA = False
                                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                                'Var5 = Fg(Fg.Row, 2) 'NOMBRE
                                TXT.Text = Var4
                                Fg(Fg.Row, 15) = Var4
                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True
                                Fg.Col = 17
                            Else
                                Fg.Col = 15
                            End If
                        Case 17 'CUENTA BANCARIA BENEFICIARIO
                            'CUENTA BANCARIA
                            Var2 = "CuentaBeneficiaria"
                            frmSelItem.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                ENTRA = False
                                'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
                                'Var5 = Fg(Fg.Row, 2) 'RFC 
                                'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
                                TXT.Text = Var4
                                Fg(Fg.Row, 17) = Var4
                                Fg(Fg.Row, 19) = Var5
                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True
                                Fg.Col = 19
                            Else
                                Fg.Col = 17
                            End If
                    End Select

                End If
                If e.KeyCode = Keys.Left Then
                    Select Case Fg.Col
                        Case 1
                            e.SuppressKeyPress = True
                        Case 3
                            Fg.Col = 1
                        Case 5
                            'Fg.Col = 6
                        Case 6
                            Fg.Col = 5
                        Case 7
                            Fg.Col = 6
                        Case 9
                            Fg.Col = 7
                        Case 12
                            Fg.Col = 9
                        Case 14
                            Fg.Col = 12
                        Case 16
                            Fg.Col = 14
                        Case 18
                            Fg.Col = 16
                    End Select
                End If
                If e.KeyCode = Keys.Right Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.SuppressKeyPress = True
                            Else
                                Fg.Col = 3
                                'SendKeys.Send("{ENTER}")
                            End If
                        Case 3
                            Fg.Col = 5

                        Case 5
                            'Fg.Col = 6
                        Case 6
                            Fg.Col = 7
                        Case 7
                            Fg.Col = 9
                        Case 9
                            Fg.Col = 12
                        Case 12
                            Fg.Col = 14
                        Case 14
                            Fg.Col = 15
                        Case 15
                            Fg.Col = 17
                        Case 18
                            Fg.Col = 19
                        Case 19
                            Fg.Col = 20
                        Case 20
                            e.SuppressKeyPress = True
                    End Select
                End If
                If e.KeyCode = Keys.Up Then
                    If Fg.Row = 1 Then
                        e.SuppressKeyPress = True
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                e.SuppressKeyPress = True
                            Else
                                AGREGA_ROW()
                            End If
                        Case Else
                            Try
                                If Fg(Fg.Row + 1, 1).ToString.Trim.Length = 0 Then
                                    Fg.Row = Fg.Row + 1
                                    Fg.Col = 1
                                    SendKeys.Send("{ENTER}")
                                End If
                            Catch ex As Exception
                                BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                End If
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function DOCUMENTO_AGREGADO_EN_FG(FREFER As String) As Boolean
        Dim Existe As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If IsNumeric(Fg(k, 25)) Then
                    If Fg(k, 1) = FREFER Then
                        Existe = True
                    End If
                End If
            Next
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Existe
    End Function

    Private Function EstaFormOpen(frm As Form) As Boolean
        Dim blnRet As Boolean = False

        Try
            For Each f As Form In MainRibbonForm.OwnedForms
                If f.Name = frm.Name Then
                    blnRet = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return blnRet
    End Function

    Private Function IsFormOpen(frm As Form) As Boolean
        Dim blnRet As Boolean

        For Each f As Form In MainRibbonForm.OwnedForms
            If f.Name = frm.Name Then
                f.Close()
                f.Dispose()
                Exit For
            End If
        Next

        Return blnRet
    End Function

    Sub AGREGA_ROW()
        Try
            If Fg.Row = Fg.Rows.Count - 1 Or Fg.Rows.Count = 1 Then

                If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 Or Fg.Rows.Count = 1 Then
                    '                    documento       ...      pago sat        ...        fecha       importe       moneda         ...      tipo cambio       ...
                    '                        1            2           3            4            5             6            7            8            9            10
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Now & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                    "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & " " & vbTab &
                    " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "")
                    '   11           12           13           14           15           16           17           18           19            20
                    'docs. reldos num. cuenta     ...          rfc         banco         ...       cta benefi      ...       rfc benefi    num. peracion
                    '   21             22           23            24            25
                    '  status         obser      CVE_DOC REL.   UUID REL      NO. PARTIDA   REFER_DR
                    Fg.SetCellImage(Fg.Rows.Count - 1, 11, My.Resources.lapiz22)
                    Dim cs As CellStyle = Fg.Styles.Add("BooleanFilterCell")
                    cs.ImageAlign = ImageAlignEnum.CenterCenter
                    Fg.SetCellStyle(Fg.Rows.Count - 1, 11, cs)
                End If
                Fg.Row = Fg.Rows.Count - 1
            Else
                Fg.Row = Fg.Row + 1
            End If

            Fg.Col = 1
            SendKeys.Send("{ENTER}")
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXT_GotFocus(sender As Object, e As EventArgs) Handles TXT.GotFocus
        TXT.BackColor = Color.LightSkyBlue
    End Sub
    Private Sub TXTN_Click(sender As Object, e As EventArgs) Handles TXTN.Click
        'Fg.StartEditing()
    End Sub
    Private Sub TXTN_GotFocus(sender As Object, e As EventArgs) Handles TXTN.GotFocus
        TXTN.BackColor = Color.LightSeaGreen
    End Sub

    Private Sub BarAltaCtaOrdenante_Click(sender As Object, e As ClickEventArgs) Handles BarAltaCtaOrdenante.Click
        Var1 = "XXX"
        FrmCtaBanOrdAE.ShowDialog()
    End Sub

    Private Sub BatAltaCtaBeneficiario_Click(sender As Object, e As ClickEventArgs) Handles BatAltaCtaBeneficiario.Click
        Var1 = "XXX"
        FrmCtaBanEmpresaAE.ShowDialog()
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        If Not ISNEW Then
            Return
        End If

        If Fg.Row > 0 Then
            If Exito Then
                Select Case Fg.Col
                    Case 5
                        'Fg.Editor.Text = ""
                        Fg(Fg.Row, 3) = ""
                    Case 7
                End Select
                Exito = False
            End If
        End If
    End Sub
    Private Sub FrmPagoComplementoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.F8) Then
                e.Handled = True
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CargarRegimenesFiscales()
        Dim lista As New List(Of cRegimenFiscal) From {
            New cRegimenFiscal(1, "601", "General de Ley Personas Morales"),
            New cRegimenFiscal(2, "603", "Personas Morales con Fines no Lucrativos"),
            New cRegimenFiscal(3, "605", "Sueldos y Salarios e Ingresos Asimilados a Salarios"),
            New cRegimenFiscal(4, "606", "Arrendamiento"),
            New cRegimenFiscal(5, "607", "Régimen de Enajenación o Adquisición de Bienes"),
            New cRegimenFiscal(6, "608", "Demás ingresos"),
            New cRegimenFiscal(7, "609", "Consolidación"),
            New cRegimenFiscal(8, "610", "Residentes en el Extranjero sin Establecimiento Permanente en México"),
            New cRegimenFiscal(9, "611", "Ingresos por Dividendos lista.Add(new cRegimenFiscal(socios y accionistas));"),
            New cRegimenFiscal(10, "612", "Personas Físicas con Actividades Empresariales y Profesionales"),
            New cRegimenFiscal(11, "614", "Ingresos por intereses"),
            New cRegimenFiscal(12, "615", "Régimen de los ingresos por obtención de premios"),
            New cRegimenFiscal(13, "616", "Sin obligaciones fiscales"),
            New cRegimenFiscal(14, "620", "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"),
            New cRegimenFiscal(15, "621", "Incorporación Fiscal"),
            New cRegimenFiscal(16, "622", "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"),
            New cRegimenFiscal(17, "623", "Opcional para Grupos de Sociedades"),
            New cRegimenFiscal(18, "624", "Coordinados"),
            New cRegimenFiscal(19, "625", "Régimen de las Actividades Empresariales con ingresos a través de Plataformas Tecnológicas"),
            New cRegimenFiscal(20, "626", "Régimen Simplificado de Confianza")
        }

    End Sub
    Private Sub CargarUsosCfdi()
        Dim lista As New List(Of cUsoCFDI) From {
            New cUsoCFDI(1, "G01", "Adquisición de mercancias"),
            New cUsoCFDI(2, "G02", "Devoluciones, descuentos o bonificaciones"),
            New cUsoCFDI(3, "G03", "Gastos en general"),
            New cUsoCFDI(4, "I01", "Construcciones"),
            New cUsoCFDI(5, "I02", "Mobilario y equipo de oficina por inversiones"),
            New cUsoCFDI(6, "I03", "Equipo de transporte"),
            New cUsoCFDI(7, "I04", "Equipo de computo y accesorios"),
            New cUsoCFDI(8, "I05", "Dados, troqueles, moldes, matrices y herramental"),
            New cUsoCFDI(9, "I06", "Comunicaciones telefónicas"),
            New cUsoCFDI(10, "I07", "Comunicaciones satelitales"),
            New cUsoCFDI(11, "I08", "Otra maquinaria y equipo"),
            New cUsoCFDI(12, "D01", "Honorarios médicos, dentales y gastos hospitalarios."),
            New cUsoCFDI(13, "D02", "Gastos médicos por incapacidad o discapacidad"),
            New cUsoCFDI(14, "D03", "Gastos funerales."),
            New cUsoCFDI(15, "D04", "Donativos."),
            New cUsoCFDI(16, "D05", "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."),
            New cUsoCFDI(17, "D06", "Aportaciones voluntarias al SAR."),
            New cUsoCFDI(18, "D07", "Primas por seguros de gastos médicos."),
            New cUsoCFDI(19, "D08", "Gastos de transportación escolar obligatoria."),
            New cUsoCFDI(20, "D09", "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."),
            New cUsoCFDI(21, "D10", "Pagos por servicios educativos (colegiaturas)"),
            New cUsoCFDI(22, "S01", "Sin efectos fiscales.)"),
            New cUsoCFDI(23, "CP01", "Pagos"),
            New cUsoCFDI(24, "CN01", "Nómina")
        }
    End Sub
    Private Sub TMagico_GotFocus(sender As Object, e As EventArgs) Handles TMagico.GotFocus
        Try
            TXT.Value = ""
            TXT.Focus()
            Fg(Fg.Row, c_) = ""

            Fg.Col = c_
            Fg.Select()
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 1
                            If TXT.Text.Length = 0 Then
                                'e.IsInputKey = True
                                'TXT.Focus()
                            Else
                                'Fg.Col = 3
                            End If
                        Case 3
                            Fg.Col = 5
                        Case 5
                            Fg.Col = 6
                        Case 6
                            Fg.Col = 7
                        Case 7
                            'MONEDA
                            ENTRA = False
                            If TXT.Text.Trim.Length > 0 Then
                                Dim DESCR As String
                                DESCR = BUSCA_CAT("Moneda2", TXT.Text)
                                If DESCR <> "" Then
                                    Fg(Fg.Row, 7) = DESCR
                                    Fg.Col = 9
                                    SendKeys.Send("{ENTER}")
                                Else
                                    MsgBox("Moneda inexistente")
                                    c_ = Fg.Col
                                    TMagico.Focus()
                                    SendKeys.Send("{ENTER}")
                                End If
                            Else
                                Fg.Col = 9
                                SendKeys.Send("{ENTER}")
                            End If
                            ENTRA = True
                        Case 9
                            Fg.Col = 12
                        Case 12
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 17
                                'SendKeys.Send("{ENTER}")
                            End If
                        Case 14
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 17
                                SendKeys.Send("{ENTER}")
                            End If
                        Case 15
                            If Fg(Fg.Row, 3) = "01" Then
                                Fg.Col = 20
                                SendKeys.Send("{ENTER}")
                            Else
                                Fg.Col = 17
                                SendKeys.Send("{ENTER}")
                            End If
                        Case 17
                            Fg.Col = 20
                            SendKeys.Send("{ENTER}")
                        Case 19
                            Fg.Col = 20
                        Case 20
                            AGREGA_ROW()

                    End Select
                End If
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXT_Validated(sender As Object, e As EventArgs) Handles TXT.Validated
        Try
            If Fg.Row > 0 Then
                Select Case Fg.Col
                    Case 1

                End Select
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 9 Then
                    Select Case Fg.Col
                        Case 6
                            Fg.Col = 7
                    End Select
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 6
                            Fg.Col = 7
                            SendKeys.Send("{ENTER}")
                    End Select
                End If
                If e.KeyCode = Keys.Down Then
                    Select Case Fg.Col
                        Case 1
                        Case Else
                            Try
                                If Fg(Fg.Row + 1, 1).ToString.Trim.Length = 0 Then
                                    Fg.Row = Fg.Row + 1
                                    Fg.Col = 1
                                    SendKeys.Send("{ENTER}")
                                End If
                            Catch ex As Exception
                                BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXT_Leave(sender As Object, e As EventArgs) Handles TXT.Leave
        Dim Existe As Boolean = False, IMPORTE_M As Decimal = 0
        Dim CVE_MONED As String = "", TCAMBIO As Decimal = 0, ABONOS As Decimal = 0
        Dim FORMADEPAGOSAT As String = "", FECHA_APLI As DateTime

        Try
            Dim SALDO_ANT As Decimal = 0
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 1
                        If TXT.Text.Trim.Length > 0 Then

                            If ExisteReferEnFG(TXT.Text, Fg.Row) Then
                                MsgBox("El documento ya fue agregado verifique por favor")
                                ENTRA = True
                                Return
                            End If

                            Dim pnt As Point
                            pnt = Fg.PointToScreen(New Point(0, 0))

                            Var44 = pnt.Y 'FG
                            Var45 = Fg.Row * 23 'PUNOS AGREGAGOS X FILA

                            'LtRegimenEmisor.Text = Var44
                            'LtRegimenReceptor.Text = Var45
                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT D.REFER, D.CVE_CLIE, P.NOMBRE, D.FECHA_APLI, D.NO_FACTURA, D.DOCTO, D.IMPORTE, 
                                        N.CVE_MONED, D.TCAMBIO, D.NO_PARTIDA, M.IMPORTE AS IMPORTE_M, LV.METODODEPAGO, LV.FORMADEPAGOSAT
                                        FROM CUEN_DET" & Empresa & " D
                                        LEFT JOIN CUEN_M" & Empresa & " M ON M.REFER = D.REFER AND D.CVE_CLIE = M.CVE_CLIE
                                        LEFT JOIN CFDI LV ON LV.FACTURA = D.REFER
                                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE 
                                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                                        WHERE ISNULL(LV.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(LV.FORMADEPAGOSAT,'99') = 99 AND 
                                        ISNULL(D.CVE_DOC_COMPPAGO,'') > '' AND UPPER(D.DOCTO) = '" & TXT.Text.Trim.ToUpper & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        Do While dr.Read
                                            ABONOS += dr("IMPORTE")
                                            Existe = True
                                        Loop
                                    End Using
                                End Using

                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT D.REFER, D.CVE_CLIE, P.NOMBRE, D.FECHA_APLI, D.NO_FACTURA, D.DOCTO, D.IMPORTE, D.FECHAELAB,
                                        N.CVE_MONED, D.TCAMBIO, D.NO_PARTIDA, M.IMPORTE AS IMPORTE_M, LV.METODODEPAGO, CT.FORMADEPAGOSAT
                                        FROM CUEN_DET" & Empresa & " D
                                        LEFT JOIN CUEN_M" & Empresa & " M ON M.REFER = D.REFER AND D.CVE_CLIE = M.CVE_CLIE
                                        LEFT JOIN CONC" & Empresa & " CT ON CT.NUM_CPTO = D.NUM_CPTO
                                        LEFT JOIN CFDI LV ON LV.FACTURA = D.REFER
                                        LEFT JOIN CLIE" & Empresa & " P ON P.CLAVE = D.CVE_CLIE 
                                        LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                                        WHERE ISNULL(LV.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(LV.FORMADEPAGOSAT,'99') = 99 AND 
                                        ISNULL(D.CVE_DOC_COMPPAGO,'') = '' AND UPPER(D.DOCTO) = '" & TXT.Text.Trim.ToUpper & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        Do While dr.Read
                                            SALDO_ANT += dr.ReadNullAsEmptyDecimal("IMPORTE")
                                            IMPORTE_M += dr.ReadNullAsEmptyDecimal("IMPORTE")
                                            CVE_MONED = dr.ReadNullAsEmptyString("CVE_MONED")
                                            TCAMBIO = dr("TCAMBIO")
                                            FORMADEPAGOSAT = dr("FORMADEPAGOSAT")
                                            FECHA_APLI = dr("FECHAELAB")
                                            Existe = True
                                        Loop
                                    End Using
                                    If Existe Then
                                        'Var11 = Fg(Fg.Row, 11).ToString   'METODO DE PAGO
                                        'Var12 = Fg(Fg.Row, 12).ToString   'FORMA DE PAGO SAT

                                        Fg(Fg.Row, 3) = FORMADEPAGOSAT
                                        Fg(Fg.Row, 5) = FECHA_APLI
                                        Fg(Fg.Row, 6) = IMPORTE_M
                                        Fg(Fg.Row, 7) = CVE_MONED
                                        Fg(Fg.Row, 9) = TCAMBIO
                                        Fg(Fg.Row, 20) = TXT.Text 'NUM_OPERACION 
                                        'DOCUMENTO ORIGINAL

                                        Fg(Fg.Row, 26) = TXT.Text 'DOCUMENTO ORIGINAL


                                        ENTRA = True
                                        If Fg.Rows.Count > 1 Then
                                            Var48 = IMPORTE_M
                                            Var49 = ABONOS
                                            Var47 = TXT.Text
                                            Var46 = TCLIENTE.Text

                                            DESPLEGAR_DR(Var47)

                                            'If Not EstaFormOpen(FrmPDocDR) Then
                                            'If Var47.Trim.Length > 0 Then
                                            'Dim Floating As New FrmPDocDR()
                                            'Floating.Show(Me)
                                            'End If
                                            'End If
                                        End If
                                        Fg.Focus()
                                        If FORMADEPAGOSAT = "01" Then
                                            Fg(Fg.Row, 12) = ""
                                            Fg(Fg.Row, 14) = ""
                                            Fg(Fg.Row, 15) = ""
                                            Fg(Fg.Row, 17) = ""
                                            Fg(Fg.Row, 19) = ""
                                            Fg.Col = 20
                                            'SendKeys.Send("{ENTER}")

                                        Else
                                            Fg.Col = 12
                                        End If

                                    Else
                                        MsgBox("1. Documento inexistente")
                                        ENTRA = False
                                        'c_ = 1
                                        'TMagico.Focus()
                                        'TXT.Text = ""
                                        TXT.Focus()
                                        ENTRA = False
                                        TXT.Select()
                                        TXT.Text = ""
                                        Fg(Fg.Row, 1) = ""
                                        'SendKeys.Send("{ENTER}")
                                        ENTRA = True
                                    End If

                                End Using

                            Catch ex As Exception
                                BITACORACFDI("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    Case 3
                        ENTRA = False
                        If TXT.Text.Trim.Length > 0 Then
                            Dim DESCR As String
                            DESCR = BUSCA_CAT("ConcSAT", TXT.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 3) = DESCR
                                Fg(Fg.Row, 27) = Var6
                            Else
                                Exito = True
                                MsgBox("Forma de pago SAT inexistente.")
                                Fg.Select()
                                Fg.Focus()

                                ENTRA = False
                                TXT.Focus()
                                ENTRA = False
                                TXT.Select()
                                TXT.Text = ""
                                Fg(Fg.Row, 3) = ""
                                ENTRA = True
                                SendKeys.Send("{ENTER}")
                            End If
                        End If
                        ENTRA = True
                    Case 7
                        'MONEDA
                        ENTRA = False
                        If TXT.Text.Trim.Length > 0 Then
                            Dim DESCR As String
                            DESCR = BUSCA_CAT("Moneda2", TXT.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 7) = DESCR
                            Else
                                MsgBox("Moneda inexistente")

                                ENTRA = False
                                c_ = Fg.Col
                                ENTRA = False
                                TMagico.Focus()
                                ENTRA = False
                            End If
                        End If
                        ENTRA = True
                    Case 9
                        'TIPO DE CAMBIO
                        ENTRA = False
                        If TXT.Text.Trim.Length > 0 Then
                            Dim DESCR As String
                            DESCR = BUSCA_CAT("Moneda3", TXT.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 7) = DESCR
                            Else
                                MsgBox("Tipo de cambio inexistente")

                                ENTRA = False
                                c_ = Fg.Col
                                ENTRA = False
                                TMagico.Focus()
                                ENTRA = False
                            End If
                        End If
                        ENTRA = True
                    Case 11
                        ENTRA = False
                        If TXT.Text.Trim.Length > 0 Then
                            Dim DESCR As String
                            DESCR = BUSCA_CAT("CuentaOrdenante", TXT.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 13) = DESCR
                                Fg(Fg.Row, 14) = Var6
                            Else
                                MsgBox("Cuenta ordenante inexistente")
                            End If
                        End If
                        ENTRA = True
                    Case 16
                        ENTRA = False
                        If TXT.Text.Trim.Length > 0 Then
                            Dim DESCR As String
                            DESCR = BUSCA_CAT("CuentaBeneficiario", TXT.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 6) = DESCR
                            Else
                                MsgBox("Cuenta beneficiario sinexistente")
                            End If
                        End If
                        ENTRA = True
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
            ENTRA = True
        End Try
    End Sub
    Private Function ExisteReferEnFG(FREFER As String, FROW As Integer) As Boolean
        Dim ExisteRefer As Boolean = False
        Try
            For k = 1 To Fg.Rows.Count - 1
                If k <> FROW Then
                    If Fg(k, 1) = FREFER Then
                        ExisteRefer = True
                        Exit For
                    End If
                End If
            Next
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return ExisteRefer
    End Function

    Private Function Offset(ByRef controlObj As Control, ByVal x As Integer, ByVal y As Integer) As Point

        Dim pt As Point
        Dim parentObj As Control = controlObj.Parent

        Do While parentObj IsNot controlObj.FindForm
            x += parentObj.Location.X
            y += parentObj.Location.Y
            parentObj = parentObj.Parent
        Loop

        pt = PointToScreen(controlObj.Location)
        pt.Offset(x, y)
        Return pt

    End Function
    Private Sub TXTN_TextChanged(sender As Object, e As EventArgs) Handles TXTN.TextChanged
        Try
            Dim SUMA As Decimal = 0
            If Fg.Col = 6 Then
                For k = 1 To Fg.Rows.Count - 1
                    If k = Fg.Row Then
                        SUMA += TXTN.Value
                    Else
                        If Not IsNothing(Fg(k, 6)) Then
                            If IsNumeric(Fg(k, 6)) Then
                                SUMA += Fg(k, 6)
                            End If
                        End If

                    End If
                Next
                'LtTotal.Text = Format(SUMA, "###,###,##0.00")
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If Fg.Row > 0 Then
            If Fg.Col = 11 Then
            End If
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Not ISNEW Then
                e.Cancel = True
                Return
            End If

            If Fg.Row > 0 Then
                If Fg(Fg.Row, 3) = "01" Then
                    If Fg.Col = 6 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 17 Or Fg.Col = 18 Or Fg.Col = 19 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmPagoComplementoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Pago complemento")
            Me.Dispose()

            If OPEN_TAB("Complemento de pago") Then
                FrmPagoComplemento.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Fg_KeyPressEdit(sender As Object, e As KeyPressEditEventArgs) Handles Fg.KeyPressEdit
        Try
            Select Case e.KeyChar
                Case Microsoft.VisualBasic.ChrW(Keys.Return)
                    Fg.Col = 6
            End Select
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXT.KeyPress
        Try
            If EstaFormOpen(FrmPDocDR) And Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                e.Handled = True
            End If

            If Fg.Row > 0 Then
                If Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Or Fg.Col = 16 Or Fg.Col = 17 Or Fg.Col = 18 Or Fg.Col = 19 Then
                    e.Handled = True
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgDR_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgDR.BeforeEdit
        Try
            If Not ISNEW Then
                e.Cancel = True
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FgDR_DoubleClick(sender As Object, e As EventArgs) Handles FgDR.DoubleClick
        Try
            If Not ISNEW Then
                FgDR.FinishEditing()
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FgDR_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgDR.KeyDownEdit
        Try
            If Not ISNEW Then
                FgDR.FinishEditing()
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FgDR_KeyDown(sender As Object, e As KeyEventArgs) Handles FgDR.KeyDown
        Try
            If Not ISNEW Then
                FgDR.FinishEditing()
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FgDR_LeaveEdit(sender As Object, e As RowColEventArgs) Handles FgDR.LeaveEdit
        Try
            If Fg.Row > 0 Then
                Select Case Fg.Col
                    Case 1
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET CVE_DOC = '" & Fg(Fg.Row, 1) & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 3
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET NUMPARCIALIDAD = " & CInt(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg.Editor.Text))
                    Case 4
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FECHA = '" & FSQL(Fg.Editor.Text) & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 5
                        Fg(Fg.Row, 7) = CDec(Fg.Editor.Text) - Fg(Fg.Row, 6)
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOANT = " & CDec(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))

                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOINSOLUTO = " & CDec(Fg(Fg.Row, 7)) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 7
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IMPSALDOINSOLUTO = " & CDec(Fg.Editor.Text) & " WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))

                    Case 8 'UUID
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET IDDOCUMENTO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 9 'SERIE
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET SERIE= '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 10 'FOLIO
                        EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FOLIO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                    Case 11 'MONEDA
                        If Not IsNothing(Fg.Editor) Then
                            EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET MONEDADR = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                        End If
                    Case 12 'METODO DE PAGO
                        If Not IsNothing(Fg.Editor) Then
                            EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET FORMADEPAGOSAT = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                        End If
                    Case 13 'TCAMBIO
                        If Not IsNothing(Fg.Editor) Then
                            EXECUTE_QUERY_NET("UPDATE GCCFDI_COMPAGO_PAR_DR SET TCAMBIO = '" & Fg.Editor.Text & "' WHERE 
                                        CVE_DOC = '" & Fg(Fg.Row, 1) & "' AND NUMPARCIALIDAD = " & CInt(Fg(Fg.Row, 3)))
                        End If
                End Select

            End If
        Catch ex As Exception
            Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgDR_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgDR.CellButtonClick
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    ENTRA = False

                    Var2 = "PagoComplementoDocCte"
                    Var5 = FgDR(FgDR.Row, 1) 'REFER
                    Var46 = TCLIENTE.Text

                    'SOLO FACTURAS QUE TENGAN 99 Y PPD
                    FrmSelItem2.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        ENTRA = False
                        'Var4 = Fg(Fg.Row, 1).ToString   'DOCUMENTO
                        'Var5 = Fg(Fg.Row, 2).ToString   'CLIENTE
                        'Var6 = Fg(Fg.Row, 4).ToString   'FECHA
                        'Var7 = Fg(Fg.Row, 6).ToString   'DOCTO
                        'Var8 = Fg(Fg.Row, 7).ToString   'IMPORTE
                        'Var9 = Fg(Fg.Row, 8).ToString   'NO_PARTIDA
                        'Var10 = Fg(Fg.Row, 9).ToString   'CVE_MONED  MXN
                        'Var21 = Fg(Fg.Row, 10).ToString   'TCAMBIO US 19.87, MXN = 1
                        'Fg(Fg.Row, 1) = Var4
                        'Fg(Fg.Row, 3) = Var9 'num partida
                        'Fg(Fg.Row, 4) = Var6 'fecha
                        'Fg(Fg.Row, 5) = Var6 'saldo ant
                        'Fg(Fg.Row, 6) = Var8 'importe
                        'Fg(Fg.Row, 7) = Var2 'saldo
                        'Fg(Fg.Row, 8) = Var4 'uuid
                        'Fg(Fg.Row, 9) = Var4 'seria
                        'Fg(Fg.Row, 10) = Var4 'folio
                        'Fg(Fg.Row, 11) = Var4 'moneda
                        'Fg(Fg.Row, 12) = Var4 'metodo de pago
                        'Fg(Fg.Row, 13) = Var4 'tipocambio

                        Fg(Fg.Row, 1) = Var4

                        Var2 = "" : Var4 = "" : Var5 = ""
                        ENTRA = True
                        Fg.Col = 3
                    Else
                        Fg.Col = 1
                    End If
                    ENTRA = True
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_DR(FREFER As String)
        Dim OBJETOIMP_DR As String = ""
        Dim IMPORTEDR As Decimal, CVE_DOC As String

        FgDR.Rows.Count = 1

        CVE_DOC = FREFER

        Try
            SQL = "DELETE FROM GCCFDI_COMPAGO_PAR_DR"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            Dim LETRA_DR As String
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT D.REFER, D.CVE_CLIE, C.NOMBRE, D.FECHA_APLI, D.NO_FACTURA, D.DOCTO, D.IMPORTE, N.CVE_MONED, D.TCAMBIO, D.NO_PARTIDA, 
                    M.IMPORTE AS IMPORTE_M, LV.METODODEPAGO, LV.FORMADEPAGOSAT, P.IMPU1, P.IMPU2, P.IMPU3, P.IMPU4, D.IMPMON_EXT
                    FROM CUEN_DET" & Empresa & " D
                    LEFT JOIN CUEN_M" & Empresa & " M ON M.REFER = D.REFER AND D.CVE_CLIE = M.CVE_CLIE
                    LEFT JOIN PAR_FACTF" & Empresa & " P ON P.CVE_DOC = D.REFER AND NUM_PAR = 1
                    LEFT JOIN CFDI LV ON LV.FACTURA = D.REFER
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = D.CVE_CLIE 
                    LEFT JOIN MONED" & Empresa & " N ON N.NUM_MONED = M.NUM_MONED 
                    WHERE ISNULL(LV.METODODEPAGO,'PPD') = 'PPD' AND ISNULL(LV.FORMADEPAGOSAT,'99') = 99 AND 
                    ISNULL(D.CVE_DOC_COMPPAGO,'') = '' AND UPPER(D.DOCTO) = '" & CVE_DOC.ToUpper & "'"
                cmd.CommandText = SQL

                Dim UUIDDR As String, IMPORTE As Decimal = 0, SALDO_ANT As Decimal

                SALDO_ANT = Var48 - Var49 'IMPORTE_M - ABONOS
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read

                        UUIDDR = BUSCAR_UUID_CARTA_PORTE(dr("REFER"))

                        If UUIDDR.Trim.Length > 0 Then
                            LETRA_DR = Regex.Replace(dr("REFER"), "[^a-zA-Z]", "")

                            IMPORTEDR = Math.Round(dr("IMPORTE"), 6)
                            SALDO_ANT = Math.Abs(CALCULAR_SALDO_CLIENTE(dr("REFER"), CVE_DOC, dr("CVE_CLIE")))

                            FgDR.AddItem("" & vbTab & dr("REFER") & vbTab & "" & vbTab & dr("NO_PARTIDA") & vbTab & dr("FECHA_APLI") & vbTab & SALDO_ANT & vbTab & dr("IMPORTE") & vbTab &
                                  (SALDO_ANT - IMPORTEDR) & vbTab & UUIDDR & vbTab & LETRA_DR & vbTab & GetNumeric(dr("REFER")) & vbTab & dr("CVE_MONED") & vbTab &
                                  dr("FORMADEPAGOSAT") & vbTab & dr("TCAMBIO") & vbTab & dr.ReadNullAsEmptyDecimal("IMPU1") & vbTab & dr.ReadNullAsEmptyDecimal("IMPU2") & vbTab &
                                  dr.ReadNullAsEmptyDecimal("IMPU3") & vbTab & dr("IMPU4") & vbTab & dr("IMPMON_EXT"))

                            IMPORTE = IMPORTEDR

                            Try
                                SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM GCCFDI_COMPAGO_PAR_DR WHERE CVE_DOC = @CVE_DOC AND NUMPARCIALIDAD = @NUMPARCIALIDAD)
                                    BEGIN
                                        INSERT INTO GCCFDI_COMPAGO_PAR_DR (CVE_DOC, FECHA, FOLIO, OBJETOIMP_DR, IMPSALDOINSOLUTO, IMPPAGADO, IMPSALDOANT, NUMPARCIALIDAD, 
                                        EQUIVALENCIADR, MONEDADR, SERIE, IDDOCUMENTO, FORMADEPAGOSAT, TCAMBIO, GUID_G, IMPU1, IMPU2, IMPU3, IMPU4) 
                                        VALUES(
                                        @CVE_DOC, @FECHA, @FOLIO, @OBJETOIMP_DR, @IMPSALDOINSOLUTO, @IMPPAGADO, @IMPSALDOANT, @NUMPARCIALIDAD, @EQUIVALENCIADR, @MONEDADR, 
                                        @SERIE, @IDDOCUMENTO, @FORMADEPAGOSAT, @TCAMBIO, @GUID_G, @IMPU1, @IMPU2, @IMPU3, @IMPU4)
                                    END"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    cmd2.Parameters.Clear()
                                    cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = dr("REFER")
                                    cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = dr("FECHA_APLI")

                                    cmd2.Parameters.Add("@IMPU1", SqlDbType.Float).Value = dr.ReadNullAsEmptyDecimal("IMPU1")
                                    cmd2.Parameters.Add("@IMPU2", SqlDbType.Float).Value = dr.ReadNullAsEmptyDecimal("IMPU2")
                                    cmd2.Parameters.Add("@IMPU3", SqlDbType.Float).Value = dr.ReadNullAsEmptyDecimal("IMPU3")
                                    cmd2.Parameters.Add("@IMPU4", SqlDbType.Float).Value = dr.ReadNullAsEmptyDecimal("IMPU4")

                                    cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = GetNumeric(dr("REFER"))
                                    cmd2.Parameters.Add("@OBJETOIMP_DR", SqlDbType.VarChar).Value = OBJETOIMP_DR
                                    cmd2.Parameters.Add("@IMPSALDOINSOLUTO", SqlDbType.Float).Value = Math.Round(SALDO_ANT - IMPORTEDR, 6)
                                    cmd2.Parameters.Add("@IMPPAGADO", SqlDbType.Float).Value = IMPORTEDR
                                    cmd2.Parameters.Add("@IMPSALDOANT", SqlDbType.Float).Value = Math.Round(SALDO_ANT, 6)
                                    cmd2.Parameters.Add("@NUMPARCIALIDAD", SqlDbType.SmallInt).Value = dr("NO_PARTIDA")
                                    cmd2.Parameters.Add("@EQUIVALENCIADR", SqlDbType.SmallInt).Value = dr("TCAMBIO")
                                    cmd2.Parameters.Add("@MONEDADR", SqlDbType.VarChar).Value = dr("CVE_MONED")
                                    cmd2.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_DR
                                    cmd2.Parameters.Add("@IDDOCUMENTO", SqlDbType.VarChar).Value = UUIDDR
                                    cmd2.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = dr("FORMADEPAGOSAT")
                                    cmd2.Parameters.Add("@TCAMBIO", SqlDbType.VarChar).Value = dr("TCAMBIO")
                                    cmd2.Parameters.Add("@IMPMON_EXT", SqlDbType.VarChar).Value = dr("IMPMON_EXT")
                                    cmd2.Parameters.Add("@GUID_G", SqlDbType.VarChar).Value = UUID_G
                                    returnValue = cmd2.ExecuteNonQuery()
                                    If returnValue IsNot Nothing Then

                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    Loop
                    FgDR.AutoSizeCols()
                End Using
            End Using

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Function CALCULAR_SALDO_CLIENTE(FREFER As String, FDOCTO As String, FCVE_CLIE As String) As Decimal
        Dim SALDO As Decimal = 0

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT (IMPORTE * SIGNO) AS IMPORT FROM CUEN_DET" & Empresa & " WHERE REFER = '" & FREFER & "' AND 
                    DOCTO = '" & FDOCTO & "' AND CVE_CLIE = '" & FCVE_CLIE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        SALDO += dr("IMPORT")
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return SALDO
    End Function
    Private Function AGREGAR_DOC(FCVE_DOC As String, FNO_PARTIDA As Integer) As Boolean
        Dim EXISTE As Boolean = False
        Try
            For k = 1 To FgDR.Rows.Count - 1
                If FgDR(k, 1) = FCVE_DOC And FgDR(k, 3) = FNO_PARTIDA Then
                    EXISTE = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return EXISTE
    End Function

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            If Fg.Row > 0 Then
                EXPORTAR_EXCEL_TRANSPORT(FgDR, "PAGOS CFDI " & Fg(1, 1).ToString)
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class