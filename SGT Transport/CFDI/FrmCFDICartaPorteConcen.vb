Imports System.IO
Imports Stimulsoft.Report
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class FrmCFDICartaPorteConcen
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private TIMBRADO_DEMO As String = "No"
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private IMPRIMIR_CON As String
    Private NRow As Long = 0
    Private CADENA As String = ""
    Private Sub FrmCFDICartaPorteConcen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - C1ToolBar1.Height - 50
        Fg.DrawMode = DrawModeEnum.OwnerDraw


        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If PASS_GRUPOCE <> "BUS" And PASS_GRUPOCE <> "GOKU" Then
            'BarImprimirSti.Visible = False
        End If

        BarReCPCanc.Enabled = False

        DERECHOS()

        DESPLEGAR()
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarReCPSinPrec.Visible = False
                BarReCPConPrec.Visible = False

                BarExtraerXML.Visible = False
                BarCancelar.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    (CLAVE >= 235100 AND CLAVE < 235200)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 235100
                                    BarReCPSinPrec.Visible = True
                                    BarReCPConPrec.Visible = True
                                Case 235110
                                    BarExtraerXML.Visible = True
                                Case 235120
                                    BarCancelar.Visible = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORACFDI("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR()
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim ds As New DataSet

            Fg.Redraw = False

            SQL = "SELECT TDOC as 'Tipo documento', 
                FACTURA AS 'Factura', CASE 
                WHEN ESTATUS = 'C' THEN 'Cancelada' 
                WHEN ESTATUS = 'P' THEN 'Timbrado. En proceso de cancelación' 
                ELSE 'Emitida' END AS 'Estatus', 
                CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE DOCUMENT END AS 'Carta porte', 
                CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE ISNULL(DOCUMENT2,'') END AS 'carta porte 2', 
                '(' + CLIENTE + ')  ' + NOMBRE,
                SUBTOTAL AS 'Subtotal', RETENCION AS 'Retención', IVA AS 'IVA', IMPORTE AS 'Importe',
                CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE VERSION END AS 'Versión', 
                (SELECT FECHA_REAL_CARGA FROM GCCARTA_PORTE WHERE CVE_FOLIO = DOCUMENT) AS 'Fecha real carga', 
                CASE WHEN ISNULL(ESTATUS,'') = 'C' THEN '' ELSE FECHA_CERT END AS 'Fecha certificado', 
                FECHA_CANCEL AS 'Fecha cancelación', OBS_CANC AS 'Observaciones', 
                CASE WHEN TIMBRADO = 'S' THEN 'Timbrado' ELSE 'No timbrada' END AS 'Timbrado', USUARIO AS 'Usuario', 
                FECHAELAB AS 'Fecha elaboración', POLIZA AS 'Poliza'
                FROM CFDI F
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CLIENTE
                ORDER BY FECHAELAB DESC"
            '            ,S
            '(SELECT CVE_MAT + ' ' + CAMPLIB3 FROM GCCARTA_PORTE P LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = P.CVE_MAT WHERE CVE_FOLIO = CFDI.DOCUMENT) AS CP1_LIB3,
            '(SELECT CVE_MAT + ' ' + CAMPLIB3 FROM GCCARTA_PORTE P LEFT JOIN INVE_CLIB" & Empresa & " L ON L.CVE_PROD = P.CVE_MAT WHERE CVE_FOLIO = CFDI.DOCUMENT2) AS CP2_LIB3

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable
            da.SelectCommand.CommandTimeout = 120

            da.Fill(dt)
            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

            Fg.Cols(0).Width = 40
            If NRow > 0 Then
                Fg.Row = NRow
                NRow = 0
            End If

            Dim c11 As Column = Fg.Cols(18)
            c11.DataType = GetType(DateTime)
            c11.Format = "g"

            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(Decimal)
            Fg.Cols(7).Format = "###,###,##0.00"

            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(Decimal)
            Fg.Cols(8).Format = "###,###,##0.00"

            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"


            '  Clear existing subtotals.
            Fg.Subtotal(AggregateEnum.Clear)
            Fg.SubtotalPosition = SubtotalPositionEnum.BelowData

            '  Get a Grand total (use -1 instead of column index).
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 7, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 8, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 9, "Grand Total")
            Fg.Subtotal(AggregateEnum.Sum, -1, -1, 10, "Grand Total")

            Dim cs As CellStyle
            cs = Fg.Styles(CellStyleEnum.GrandTotal)
            cs.BackColor = Color.Black
            cs.ForeColor = Color.White
            cs.Font = New Font(Font, FontStyle.Bold)

            Fg.AutoSizeCols()

            Fg.Cols(6).Width = 150
            Fg.Redraw = True

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1

        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCFDICartaPorteConcen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Concentrado CFDI carta porte")
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click

        Try
            If Fg.Row > 0 Then

                If Fg(Fg.Row, 3) = "Cancelada" Then
                    MsgBox("la carta porte ya se encuentra cancelada, verifique por favor")
                    Return
                End If

                Var2 = Fg(Fg.Row, 2) 'FACTURA
                Var3 = Fg(Fg.Row, 4) 'CATA PORTE 1
                Var4 = Fg(Fg.Row, 5) 'CATA PORTE 2
                Var10 = Fg(Fg.Row, 11) 'VERSION

                FrmCFDICanc.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "concentrado CFDI carta porte")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BsarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarActualizar_Click(sender As Object, e As ClickEventArgs) Handles BarActualizar.Click
        DESPLEGAR()
    End Sub

    Private Sub BarExtraerXML_Click(sender As Object, e As ClickEventArgs) Handles BarExtraerXML.Click
        FrmExtraerXML.ShowDialog()
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 3) = "Cancelada" Then
                    BarReCPCanc.Enabled = True
                    BarReCPSinPrec.Enabled = False
                    BarReCPConPrec.Enabled = False
                Else
                    BarReCPCanc.Enabled = False
                    BarReCPSinPrec.Enabled = True
                    BarReCPConPrec.Enabled = True
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarReCPSinPrec_Click(sender As Object, e As ClickEventArgs) Handles BarReCPSinPrec.Click
        CP_IMPRIME_IMPORTES = False
        If Fg.Row > 0 Then
            IMPRIMIR_CFDI(Fg(Fg.Row, 2), "CARTA PORTE")
        Else
            MsgBox("Por favor seleccione un documento")
        End If
    End Sub
    Private Sub BarReCPConPrec_Click(sender As Object, e As ClickEventArgs) Handles BarReCPConPrec.Click
        CP_IMPRIME_IMPORTES = True

        If Fg.Row > 0 Then

            IMPRIMIR_CFDI(Fg(Fg.Row, 2), "CARTA PORTE")
        Else
            MsgBox("Por favor seleccione un documento")
        End If
    End Sub
    Private Sub BarReCPCanc_Click(sender As Object, e As ClickEventArgs) Handles BarReCPCanc.Click
        Dim Reporte_MRT As String, RUTA_FORMATOS As String, FILE_PDF As String
        Dim XML As String = "", FILE_XML As String, FACTURA As String, CARTA_PORTE1 As String

        If Fg.Row = 0 Then
            MsgBox("Por favor seleccione una carta perte")
            Return
        End If
        If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
            MsgBox("Por favor seleccione una carta perte")
            Return
        End If

        RUTA_FORMATOS = GET_RUTA_FORMATOS()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                        gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")

                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            'SQL = "SELECT TDOC as 'Tipo documento', FACTURA AS 'Factura', CASE WHEN ESTATUS = 'C' THEN 'Cancelada' ELSE 'Emitida' END AS 'Estatus', 
            'DOCUMENT AS 'Carta porte', DOCUMENT2 AS 'carta porte 2', VERSION AS 'Versión', 
            'SERIE AS 'Serie', FECHA_CERT AS 'Fecha certificado', FECHA_CANCEL AS 'Fecha cancelación', OBS_CANC AS 'Observaciones', 
            'C'ase WHEN TIMBRADO = 'S' THEN 'Timbrado' ELSE 'No timbrada' END AS 'Timbrado', USUARIO AS 'Usuario', FECHAELAB AS 'Fecha elaboración'
            FACTURA = Fg(Fg.Row, 2)
            CARTA_PORTE1 = Fg(Fg.Row, 4)
            Try
                SQL = "SELECT TDOC, DOCUMENT, DOCUMENT2, XML_CANC, FILE_XML FROM CFDI WHERE FACTURA = '" & FACTURA & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            XML = dr("XML_CANC")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORACFDI("400. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            FILE_XML = gRutaXML_TIMBRADO & "\TEMPCP.xml"
            File.WriteAllText(FILE_XML, XML)

            FILE_PDF = gRutaXML_NO_TIMBRADO & "\" & CARTA_PORTE1 & "-" & FACTURA & "CANC" & ".pdf"

            Reporte_MRT = RUTA_FORMATOS & "\" & OBTENER_MRT("CARTA PORTE CANC")
            If Not File.Exists(Reporte_MRT) Then
                MsgBox("No existe el reporte " & Reporte_MRT & ", verifique por favor")
                Return
            End If
            StiReport1.Load(Reporte_MRT)

            Dim xmlDataBase = New Stimulsoft.Report.Dictionary.StiXmlDatabase("Data", FILE_XML)
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(xmlDataBase)
            StiReport1.Compile()
            StiReport1.Render()
            'StiReport1.Design()
            StiReport1.ExportDocument(StiExportFormat.Pdf, FILE_PDF)
            StiReport1.Show()

        Catch ex As Exception
            BITACORACFDI("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEstatusCFDI_Click(sender As Object, e As ClickEventArgs) Handles BarEstatusCFDI.Click
        If Fg.Row = 0 Then
            MsgBox("Por favor seleccione un documento")
            Return
        End If
        Dim EMISOR_RAZON_SOCIAL As String = "", EMISOR_RFC As String = ""
        Dim NOMBRE_CLI As String = "", RFC As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        EMISOR_RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")
                        EMISOR_RFC = dr("EMISOR_RFC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NOMBRE, RFC FROM CFDI 
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = CFDI.CLIENTE
                    WHERE FACTURA = '" & Fg(Fg.Row, 2) & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NOMBRE_CLI = dr("NOMBRE")
                        RFC = dr("RFC")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("10. " & vbNewLine & ex.StackTrace)
        End Try

        PassData1 = "FACTURA"

        Var2 = Fg(Fg.Row, 2) 'DOCUMENTO
        Var3 = EMISOR_RAZON_SOCIAL
        Var4 = EMISOR_RFC
        Var5 = RFC 'RFC RECEPTOR
        Var6 = NOMBRE_CLI 'NOMBRE RECEPTOR
        FrmEstatusCFDI.ShowDialog()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub BarEnviarcorreo_Click(sender As Object, e As ClickEventArgs) Handles BarEnviarcorreo.Click
        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String, PDF As String = ""
        Dim CALLE_DESTINO As String, NUMEROEXTERIOR_DESTINO As String, COLONIA_DESTINO As String, Err As Boolean = False
        Dim LOCALIDAD_DESTINO As String, CODIGOPOSTAL_DESTINO As String, ESTADO_DESTINO As String, MUNICIPIO_DESTINO As String
        Dim ENVIAR_MAIL As String, CORREO_CLIENTE As String = "", RAZON_SOCIAL As String = "", NOMBRE_CLIENTE As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        PassData6 = dr("CALLE") & ", Num. ext. " & dr("NUMEXT") & ", CP " & dr("CP")

                        RAZON_SOCIAL = dr("EMISOR_RAZON_SOCIAL")

                        gUSUARIO_PAC = dr("USUARIO")
                        gPASS_PAC = Desencriptar(dr("PASS"))
                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                        Else
                            TIMBRADO_DEMO = "Si"
                        End If

                        If CP_IMPRIME_IMPORTES Then
                            'CON PRECIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado
                    End If
                End Using
            End Using
        Catch ex As Exception
            Err = True
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        Try
            CVE_DOC = Fg(Fg.Row, 2)
            Try
                SQL = "SELECT TDOC, DOCUMENT, DOCUMENT2, XML, FILE_XML FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            XML = dr("XML")
                            CTA_PORT1 = dr("DOCUMENT")
                            CTA_PORT2 = dr("DOCUMENT2")
                        End If
                    End Using
                End Using

                Try
                    SQL = "SELECT C.CVE_DOCR, C.CLIENTE, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, 
                        CVE_DOCP, C.ORDEN_DE, C.EMBARQUE, ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1,
                        ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2,
                        ISNULL(U.ANO_MODELO,'') AS ANO_MOD, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL, C.CVE_ART, ISNULL(P.DESCR,'') AS DESCR_MAT, 
                        ISNULL(CAMPLIB1,'') AS LIB1, ISNULL(PEDIMENTO,'') AS CP_PEDIMENTO, ISNULL(C.OBSER_CFDI,'') AS OBS_CFDI, 
                        R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN, SC.NOMBRE, SC.CALLE, SC.NUMEXT, SC.COLONIA, SC.LOCALIDAD, SC.MUNICIPIO, SC.CODIGO,
                        SC.ESTADO, ISNULL(SC.MAIL,'') AS ENVIAR_CORREO, ISNULL(SC.EMAILPRED,'') AS CORREO
                        FROM GCCARTA_PORTE C 
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = C.RECOGER_EN
                        LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = C.ENTREGAR_EN
                        LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = C.CVE_TRACTOR
                        LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = C.CVE_TANQUE1
                        LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = C.CVE_TANQUE2
                        LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                        LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = CAST(C.CVE_ART AS INT)
                        LEFT JOIN CLIE" & Empresa & " SC ON SC.CLAVE =  C.CLIENTE
                        LEFT JOIN CLIE_CLIB" & Empresa & " L ON L.CVE_CLIE =  SC.CLAVE
                        WHERE CVE_FOLIO = '" & CTA_PORT1 & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CP_ORDEN_DE = dr.ReadNullAsEmptyString("ORDEN_DE")
                                CP_EMBARQUE = dr.ReadNullAsEmptyString("EMBARQUE")

                                CP_RECOGER_EN = dr.ReadNullAsEmptyString("DESCR_RECOGER_EN")
                                CP_ENTREGAR_EN = dr.ReadNullAsEmptyString("DESCR_ENTREGAR_EN")

                                CP_TRACTOR = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                                CP_TANQUE1 = dr.ReadNullAsEmptyString("CVE_TANQUE1")
                                CP_TANQUE2 = dr.ReadNullAsEmptyString("CVE_TANQUE2")
                                CP_PLACAS_TRACTOR = dr.ReadNullAsEmptyString("PLACAS_MEX_TRACTOR")
                                CP_PLACAS_TANQUE1 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE1")
                                CP_PLACAS_TANQUE2 = dr.ReadNullAsEmptyString("PLACAS_MEX_TANQUE2")

                                CP_POLIZARESPCIVIL = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                                CP_ASEGURARESPCIVIL = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                                CP_NUM_PROV = dr.ReadNullAsEmptyString("LIB1")
                                CP_PEDIMENTO = dr.ReadNullAsEmptyString("CP_PEDIMENTO")
                                If CP_PEDIMENTO = "0" Then CP_PEDIMENTO = ""
                                CP_OBSER_CFDI = dr.ReadNullAsEmptyString("OBS_CFDI")

                                CALLE_DESTINO = dr.ReadNullAsEmptyString("CALLE")
                                NUMEROEXTERIOR_DESTINO = dr.ReadNullAsEmptyString("NUMEXT")
                                COLONIA_DESTINO = dr.ReadNullAsEmptyString("COLONIA")
                                LOCALIDAD_DESTINO = dr.ReadNullAsEmptyString("LOCALIDAD")
                                CODIGOPOSTAL_DESTINO = dr.ReadNullAsEmptyString("CODIGO")
                                ESTADO_DESTINO = dr.ReadNullAsEmptyString("ESTADO")
                                MUNICIPIO_DESTINO = dr.ReadNullAsEmptyString("MUNICIPIO")


                                PassData7 = CALLE_DESTINO
                                If NUMEROEXTERIOR_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Num. ext. " & NUMEROEXTERIOR_DESTINO
                                End If
                                If CODIGOPOSTAL_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", CP " & CODIGOPOSTAL_DESTINO
                                End If
                                If COLONIA_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Colonia " & COLONIA_DESTINO
                                End If
                                If LOCALIDAD_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Localidad " & LOCALIDAD_DESTINO
                                End If
                                If MUNICIPIO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Municipio " & MUNICIPIO_DESTINO
                                End If
                                If ESTADO_DESTINO.Trim.Length > 0 Then
                                    PassData7 = PassData7 & ", Estado " & ESTADO_DESTINO
                                End If

                                ENVIAR_MAIL = dr("ENVIAR_CORREO")
                                CORREO_CLIENTE = dr("CORREO")
                                NOMBRE_CLIENTE = "(" & dr("CLIENTE") & ") " & dr.ReadNullAsEmptyString("NOMBRE")
                            Else
                                CP_ORDEN_DE = "" : CP_EMBARQUE = "" : CP_RECOGER_EN = "" : CP_ENTREGAR_EN = "" : CP_TRACTOR = "" : CP_TANQUE1 = ""
                                CP_TANQUE2 = "" : CP_PLACAS_TRACTOR = "" : CP_PLACAS_TANQUE1 = "" : CP_PLACAS_TANQUE2 = ""
                                CP_POLIZARESPCIVIL = "" : CP_ASEGURARESPCIVIL = "" : CP_NUM_PROV = "" : CP_PEDIMENTO = "" : CP_OBSER_CFDI = ""
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Err = True
                    BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("12. " & ex.Message)
                End Try
                If Err Then
                    MsgBox("Problema detectado verifique las rutas por favor")
                    Return
                End If

                Var4 = ""
                Var5 = CORREO_CLIENTE
                Var6 = NOMBRE_CLIENTE
                Var7 = ""
                Var8 = ""
                Var9 = ""
                Var10 = ""

                FrmCorreo.ShowDialog()

                If Var4 = "NO" Then
                    Return
                End If

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM CFDI_CFG"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then

                                CP_PERMSCT = dr.ReadNullAsEmptyString("PERMSCT")
                                CP_NUMPERMISOSCT = dr.ReadNullAsEmptyString("NUMPERMISOSCT")

                                CP_POLIZAMEDAMBIENTE = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                                CP_ASEGURAMEDAMBIENTE = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                    Err = True

                End Try
                If Err Then
                    MsgBox("Problema detectado verifique las rutas por favor")
                    Return
                End If

                FILE_XML = gRutaXML_TIMBRADO & "\" & CTA_PORT1 & "-" & CVE_DOC & ".xml"
                Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & CTA_PORT1 & "-" & CVE_DOC & ".pdf"

                PDF = rutaPDF

                File.WriteAllText(FILE_XML, XML)
                '                                   String.Empty
                CreaPDF.Generar(FILE_XML, rutaPDF, Application.StartupPath & "\logo.jpg", False)
                'Process.Start(rutaPDF)

            Catch ex As Exception
                Err = True
                BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & FILE_XML & vbNewLine & "PDF:" & PDF)
            End Try
            If Err Then
                MsgBox("Problema detectado verifique las rutas por favor")
                Return
            End If
        Catch ex As Exception
            Err = True
            BITACORACFDI("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        Try
            Dim aCorreo As New ArrayList From {PDF, FILE_XML}
            Dim horaActual As String, SALUDO As String, MensaDia As String = ""

            Try
                horaActual = DateTime.Now.ToString("HH:mm")

                If horaActual >= "24:00" And horaActual <= "12:00" Then
                    SALUDO = "Buenos Días"
                ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                    SALUDO = "Buenas Tardes"
                ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                    SALUDO = "Buenas Noches"
                End If
                MensaDia = horaActual
            Catch ex As Exception
                BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CORREO_CLIENTE.Trim.Length > 0 Or Var7.Trim.Length > 0 Or Var8.Trim.Length > 0 Or Var9.Trim.Length > 0 Or Var10.Trim.Length > 0 Then
                SendEmail(CORREO_CLIENTE, "CFDI Carta porte",
                        MensaDia & vbCrLf & vbCrLf &
                        "CFDI Carta porte " & CTA_PORT1 & vbCrLf &
                        "Adjunto se envia representación CFDI Carta porte en formato PDF" & vbCrLf & vbCrLf &
                         RAZON_SOCIAL,
                        aCorreo, Var7, Var8, Var9, Var10)

                MsgBox("Correo enviado")
            Else
                MsgBox("El cliente " & NOMBRE_CLIENTE & " no tiene correo capturado")
            End If
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarMReimpMasiva_Click(sender As Object, e As ClickEventArgs) Handles BarMReimpMasiva.Click
        Try
            FrmFiltroReimpMasiva.ShowDialog()

        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExtraSel_Click(sender As Object, e As ClickEventArgs) Handles BarExtraSel.Click
        Dim XML_TABLA As String, FILE_XML As String, z As Integer = 0
        Dim RUTA_DOC As String = ""

        If MsgBox("Realmente desea extraer los XML seleccionados?", vbYesNo) = vbNo Then
            Return
        End If

        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            RUTA_DOC = FolderBrowserDialog1.SelectedPath
        End If

        If RUTA_DOC.Trim.Length = 0 Then
            MsgBox("Por favor seleccione la ruta donde se extraeran los XML")
            Return
        End If

        Try
            For Each r As Row In Fg.Rows.Selected

                If Fg(r.Index, 3) <> "Cancelada" And Fg(r.Index, 16) = "Timbrado" Then

                    SQL = "SELECT FACTURA, DOCUMENT, XML FROM CFDI WHERE FACTURA = '" & Fg(r.Index, 2) & "'"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                XML_TABLA = dr("XML")
                                If XML_TABLA.Trim.Length > 0 Then
                                    FILE_XML = RUTA_DOC & "\" & dr("FACTURA") & " " & dr("DOCUMENT") & ".xml"
                                    If Not File.Exists(FILE_XML) Then
                                        File.WriteAllText(FILE_XML, XML_TABLA)
                                        z += 1
                                    End If
                                End If
                            End While
                        End Using
                    End Using
                End If
            Next

            MsgBox("Proceso terminado, archivos creados " & z)

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExtraTodos_Click(sender As Object, e As ClickEventArgs) Handles BarExtraTodos.Click
        FrmExtraerXML.ShowDialog()
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If e.KeyCode = Keys.E AndAlso e.Modifiers = Keys.Control Then

                For i = 1 To Fg.Rows.Count - 1
                    Fg.Rows(i).Selected = True
                Next

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
