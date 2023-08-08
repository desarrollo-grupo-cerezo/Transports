Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input

Public Class FrmPolizaComprasNC
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
    Private Sub FrmPolizaComprasNC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Tab1.Height = Me.Height - C1ToolBar1.Height - Panel1.Height - Panel1.Height
            Fg.Rows(0).Height = 50
            GET_RUTA_MODELO()

            tPOLIZA.Text = "COMPRAS ALMACEN " & DateTime.Now.ToString("MMMM")
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
    Private Sub FrmPolizaComprasNC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Póliza compras NC")
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Dim IMPORTE As Decimal = 0, IMP1 As Decimal = 0, IMP2 As Decimal = 0, IMP3 As Decimal = 0, IMP4 As Decimal = 0, SUBTOTAL As Decimal = 0

        Fg.Rows.Count = 1
        Fg.Cols.Count = 25

        Fg.Redraw = False
        Fg(0, 1) = "Documento"
        Dim c1 As Column = Fg.Cols(1)
        c1.DataType = GetType(String)

        Fg(0, 2) = "Proveedor"
        Dim c2 As Column = Fg.Cols(2)
        c2.DataType = GetType(String)

        Fg(0, 3) = "Nombre"
        Dim c3 As Column = Fg.Cols(3)
        c3.DataType = GetType(String)

        Fg(0, 4) = "Estatus"
        Dim c4 As Column = Fg.Cols(4)
        c4.DataType = GetType(String)

        Fg(0, 5) = "Su refer."
        Dim c5 As Column = Fg.Cols(5)
        c5.DataType = GetType(String)

        Fg(0, 6) = "Fecha"
        Dim c6 As Column = Fg.Cols(6)
        c6.DataType = GetType(DateTime)

        Fg(0, 7) = "Fecha pag."
        Dim c7 As Column = Fg.Cols(7)
        c7.DataType = GetType(DateTime)

        Fg(0, 8) = "Almacen"
        Dim c8 As Column = Fg.Cols(8)
        c8.DataType = GetType(Int32)

        Fg(0, 9) = "Sub. total"
        Dim c9 As Column = Fg.Cols(9)
        c9.DataType = GetType(Decimal)
        Fg.Cols(9).Format = "###,###,##0.00"

        Fg(0, 10) = "IEPS"
        Dim c10 As Column = Fg.Cols(10)
        c10.DataType = GetType(Decimal)
        Fg.Cols(10).Format = "###,###,##0.00"

        Fg(0, 11) = "Retencion ISR"
        Dim c110 As Column = Fg.Cols(11)
        c110.DataType = GetType(Decimal)
        Fg.Cols(11).Format = "###,###,##0.00"

        Fg(0, 12) = "Retencio IVA"
        Dim c111 As Column = Fg.Cols(12)
        c111.DataType = GetType(Decimal)
        Fg.Cols(12).Format = "###,###,##0.00"

        Fg(0, 13) = "IVA"
        Dim c121 As Column = Fg.Cols(13)
        c121.DataType = GetType(Decimal)
        Fg.Cols(13).Format = "###,###,##0.00"

        Fg(0, 14) = "Descuento"
        Dim c11 As Column = Fg.Cols(14)
        c11.DataType = GetType(Decimal)
        Fg.Cols(14).Format = "###,###,##0.00"

        Fg(0, 15) = "Importe"
        Dim c12 As Column = Fg.Cols(15)
        c12.DataType = GetType(Decimal)
        Fg.Cols(15).Format = "###,###,##0.00"

        Fg(0, 16) = "Fecha elab."
        Dim c13 As Column = Fg.Cols(16)
        c13.DataType = GetType(DateTime)

        Fg(0, 17) = "Tipo documento anterior"
        Dim c14 As Column = Fg.Cols(17)
        c14.DataType = GetType(String)

        Fg(0, 18) = "Documento anterior"
        Dim c15 As Column = Fg.Cols(18)
        c15.DataType = GetType(String)

        Fg(0, 19) = "UUID XML"
        Dim c16 As Column = Fg.Cols(19)
        c16.DataType = GetType(String)

        Fg(0, 20) = "RFC"
        Fg(0, 21) = "Cuenta contable"
        Fg(0, 22) = "Serie"
        Fg(0, 23) = "Folio"
        Fg(0, 24) = "xml"
        Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter
        Fg.Cols(17).TextAlign = TextAlignEnum.CenterCenter
        Try
            SQL = "SELECT  C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.STATUS, C.SU_REFER, C.FECHA_DOC, C.FECHA_PAG, 
                CAST(C.NUM_ALMA AS VARCHAR(2)) + '. ' + A.DESCR AS ALMACEN, C.CAN_TOT, C.DES_TOT, C.IMPORTE, C.FECHAELAB, 
                ISNULL(C.IMP_TOT1,0) AS IMPTOT1, ISNULL(C.IMP_TOT2,0) AS IMPTOT2, ISNULL(C.IMP_TOT3,0) AS IMPTOT3, ISNULL(C.IMP_TOT4,0) AS IMPTOT4, 
                CASE ISNULL(C.TIP_DOC_ANT,'') WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' WHEN 'r' THEN 'Recepción' WHEN 'q' THEN 'Requsición' ELSE '' END AS TIPO_D_ANT, 
                ISNULL(C.DOC_ANT,'') AS DOCANT, ISNULL(UUID_XML,'') AS UUID, 
                ISNULL(P.RFC,'') AS RFC_, ISNULL(P.CUENTA_CONTABLE,'') AS Cta, C.SERIE AS 'Serie', C.FOLIO AS Folio, ISNULL(ARCHIVO_XML,'') AS FILE_XML
                FROM COMPD" & Empresa & " C 
                LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = C.NUM_ALMA
                LEFT JOIN GCCOMPRAS X ON X.CVE_DOC = C.CVE_DOC " &
                CADENA & " ORDER BY C.FECHAELAB DESC"
            '  17              18                                      19                  20
            'p.RFC, p.CUENTA_CONTABLE AS 'Cta. contable proveedor', C.SERIE AS 'Serie', C.FOLIO AS 'Folio'
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMBRE") & vbTab & dr("STATUS") & vbTab &
                                   dr("SU_REFER") & vbTab & dr("FECHA_DOC") & vbTab & dr("FECHA_PAG") & vbTab & dr("ALMACEN") & vbTab &
                                   dr("CAN_TOT") & vbTab & dr("IMPTOT1") & vbTab & dr("IMPTOT2") & vbTab & dr("IMPTOT3") & vbTab & dr("IMPTOT4") & vbTab &
                                   dr("DES_TOT") & vbTab & dr("IMPORTE") & vbTab & dr("FECHAELAB") & vbTab & dr("TIPO_D_ANT") & vbTab &
                                   dr("DOCANT") & vbTab & dr("UUID") & vbTab & dr("RFC_") & vbTab & dr("Cta") & vbTab &
                                   dr("Serie") & vbTab & dr("Folio") & vbTab & dr("FILE_XML"))
                        'IMPUESTO 10
                        'UUID  16
                        'FILE XML 21
                        SUBTOTAL = SUBTOTAL + dr("CAN_TOT")
                        IMP1 += dr("IMPTOT1")
                        IMP2 += dr("IMPTOT2")
                        IMP3 += dr("IMPTOT3")
                        IMP4 += dr("IMPTOT4")
                        IMPORTE = IMPORTE + dr("IMPORTE")
                    End While
                End Using
            End Using
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                       SUBTOTAL & vbTab & IMP1 & vbTab & IMP2 & vbTab & IMP3 & vbTab & IMP4 & vbTab & "" & vbTab & IMPORTE)

            Fg.TopRow = Fg.Rows.Count - 1
            Fg.Select(Fg.Rows.Count - 1, 1)
            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            Fg.AutoSizeCols()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True

        MsgBox("Proceso terminado")
    End Sub
    Sub DESPLEGAR_ALMACEN()
        If Not Valida_Conexion() Then
            Return
        End If
        Fg2.Redraw = False
        Try
            SQL = "SELECT  P.NUM_ALM, MAX(A.DESCR), ROUND(SUM(P.TOT_PARTIDA),6) AS IMPORT, MAX(A.CUEN_CONT) AS 'Cuenta contable'
                FROM PAR_COMPD" & Empresa & " P
                LEFT JOIN COMPD" & Empresa & " C ON C.CVE_DOC = P.CVE_DOC
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = P.NUM_ALM " &
                CADENA &
                " GROUP BY P.NUM_ALM ORDER BY P.NUM_ALM"
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg2.DataSource = BindingSource1.DataSource

            Fg2(0, 1) = "Almacén"
            Dim c1 As Column = Fg2.Cols(1)
            c1.DataType = GetType(Int32)

            Fg2(0, 2) = "Descripcion"
            Dim c2 As Column = Fg2.Cols(2)
            c2.DataType = GetType(Int32)

            Fg2(0, 3) = "Importe"
            Dim c3 As Column = Fg2.Cols(3)
            c3.DataType = GetType(Decimal)
            Fg2.Cols(3).Format = "###,###,##0.00"

            Fg2.AutoSizeCols()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg2.Redraw = True
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PolizaCompras")
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub TPOLIZA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tPOLIZA.KeyPress

        Select Case e.KeyChar
            Case "\", "/", ":", ",", "*", "?", """", "<", ">", "|", "[", "]", ";", ":", "'", "+", "}", "{", "´", "="
                e.Handled = True
        End Select
    End Sub
    Private Sub BarGenPoliza_Click(sender As Object, e As ClickEventArgs) Handles BarGenPoliza.Click
        Dim s As String = ""
        Dim CVE_DOC As String = "", CVE_CLPV As String = "", RFC As String = "", IMPORTE As Decimal, IMPUESTO As Decimal, CTA_PROV As String = ""
        Dim ALMACEN As String = "", CTA_ALMACEN As String = "", NOMBRE As String = "", FECHA As String = "", UUID_XML As String = "", SERIE As String = "", FOLIO As Long
        Dim POLIZA_MODELO As String = "", TOTAL As Decimal = 0, CONCEPTO As String, FILE_XML As String = "", NUM_PAR As Long = 12903, NUM_PARX As Long = 0
        Dim CADENA1 As String, IMP1 As Decimal = 0, IMP2 As Decimal = 0, IMP3 As Decimal = 0, IMP4 As Decimal = 0
        Dim CTA_RETENCION As String, CTA_RETENCION_IVA As String, CTA_IVA As String

        If MsgBox("Realmente desea generar la compra modelo?", vbYesNo) = vbNo Then
            Return
        End If

        Fg.Redraw = False
        Fg.Cursor = Cursors.WaitCursor
        Me.Cursor = Cursors.WaitCursor

        POLIZA_MODELO = RUTA_MODELO & "\" & tPOLIZA.Text.Replace("/", "_") & ".POL"
        If POLIZA_MODELO.Length > 255 Then
            POLIZA_MODELO = POLIZA_MODELO.Substring(0, 255)
        End If
        IMPUESTO = 0
        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA>"
            s = s & "<FIELDS>"
            s = s & "<FIELD attrname=""VersionCOI"" fieldtype=""i2""/>"
            s = s & "<FIELD attrname=""TipoPoliz"" fieldtype=""string"" WIDTH=""5""/>"
            s = s & "<FIELD attrname=""DiaPoliz"" fieldtype=""string"" WIDTH=""2""/>"
            s = s & "<FIELD attrname=""ConcepPoliz"" fieldtype=""string"" WIDTH=""120""/>"
            s = s & "<FIELD attrname=""UUID"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS>"
            s = s & "<FIELD attrname=""Cuenta"" fieldtype=""string"" WIDTH=""21""/>"
            s = s & "<FIELD attrname=""Depto"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""ConceptoPol"" fieldtype=""string"" WIDTH=""120""/>"
            s = s & "<FIELD attrname=""Monto"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""TipoCambio"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""DebeHaber"" fieldtype=""string"" WIDTH=""1""/>"
            s = s & "<FIELD attrname=""ccostos"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""proyectos"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""Porcentaje"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""FRMPAGO"" fieldtype=""string"" WIDTH=""5""/>"
            s = s & "<FIELD attrname=""NUMCHEQUE"" fieldtype=""string"" WIDTH=""20""/>"
            s = s & "<FIELD attrname=""MONTOBN"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""BANCO"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""CTAORIG"" fieldtype=""string"" WIDTH=""50""/>"
            s = s & "<FIELD attrname=""BENEF"" fieldtype=""string"" WIDTH=""300""/>"
            s = s & "<FIELD attrname=""RFC"" fieldtype=""string"" WIDTH=""13""/>"
            s = s & "<FIELD attrname=""BANCODEST"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""CTADEST"" fieldtype=""string"" WIDTH=""50""/>"
            s = s & "<FIELD attrname=""FECHACHEQUE"" fieldtype=""string"" WIDTH=""10""/>"
            s = s & "<FIELD attrname=""BANCOORIGEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s = s & "<FIELD attrname=""BANCODESTEXT"" fieldtype=""string"" WIDTH=""225""/>"
            s = s & "<FIELD attrname=""IDUUID"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""IDFISCAL"" fieldtype=""string"" WIDTH=""40""/>"
            s = s & "<FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested"">"
            s = s & "<FIELDS>"
            s = s & "<FIELD attrname=""NUMREG"" fieldtype=""i4""/>"
            s = s & "<FIELD attrname=""UUIDTIMBRE"" fieldtype=""string"" WIDTH=""36""/>"
            s = s & "<FIELD attrname=""MONTO"" fieldtype=""r8""/>"
            s = s & "<FIELD attrname=""SERIE"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""FOLIO"" fieldtype=""string"" WIDTH=""100""/>"
            s = s & "<FIELD attrname=""RFCEMISOR"" fieldtype=""string"" WIDTH=""16""/>"
            s = s & "<FIELD attrname=""RFCRECEPTOR"" fieldtype=""string"" WIDTH=""16""/>"
            s = s & "<FIELD attrname=""FECHAUUID"" fieldtype=""string"" WIDTH=""10""/>"
            s = s & "<FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/>"
            s = s & "</FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA><ROWDATA>"
            s = s & "<ROW VersionCOI=""810"" TipoPoliz=""Co"" DiaPoliz=""31"" ConcepPoliz=""" & tPOLIZA.Text & """><Partidas>"

            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1) IsNot Nothing Then
                        CVE_DOC = Fg(k, 1)
                    Else
                        CVE_DOC = ""
                    End If
                    CVE_CLPV = Fg(k, 2)
                    NOMBRE = Fg(k, 3)

                    If Fg(k, 6) IsNot Nothing Then
                        FECHA = Fg(k, 6)
                    End If

                    IMPORTE = Fg(k, 15)

                    If Fg(k, 19) IsNot Nothing Then
                        UUID_XML = Fg(k, 19)
                    Else
                        UUID_XML = ""
                    End If
                    If Fg(k, 20) IsNot Nothing Then
                        RFC = Fg(k, 20)
                    Else
                        RFC = ""
                    End If
                    If Fg(k, 21) IsNot Nothing Then
                        CTA_PROV = Fg(k, 21).ToString.Replace("-", "")
                    Else
                        CTA_PROV = ""
                    End If
                    '20
                    If CTA_PROV.Trim.Length > 0 Then
                        If CTA_PROV.Trim.Length < 20 Then
                            CTA_PROV = CTA_PROV.PadRight(20, "0") & "3"
                        End If
                    End If
                    'NUM_CTA = fCUENTA_CLIENTE.Replace("-", "") & "00000003"

                    If Fg(k, 22) IsNot Nothing Then
                        SERIE = Fg(k, 22)
                    Else
                        SERIE = ""
                    End If
                    If Fg(k, 23) IsNot Nothing Then
                        FOLIO = Fg(k, 23)
                    Else
                        FOLIO = 0
                    End If
                    If Fg(k, 24) IsNot Nothing Then
                        'UUID  16
                        'FILE XML 21
                        FILE_XML = Fg(k, 24)
                    Else
                        FILE_XML = ""
                    End If
                    TOTAL = TOTAL + IMPORTE
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    IMPORTE = 0
                End Try
                '  17              18                                      19                  20
                'p.RFC, p.CUENTA_CONTABLE AS 'Cta. contable proveedor', C.SERIE AS 'Serie', C.FOLIO AS 'Folio'
                If CVE_DOC.Trim.Length > 0 And IMPORTE > 0 Then

                    If Not IsNothing(Fg(k, 10)) Then
                        If IsNumeric(Fg(k, 10)) Then
                            IMP1 += Fg(k, 10)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 11)) Then
                        If IsNumeric(Fg(k, 11)) Then
                            IMP2 += Fg(k, 11)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 12)) Then
                        If IsNumeric(Fg(k, 12)) Then
                            IMP3 += Fg(k, 12)
                        End If
                    End If
                    If Not IsNothing(Fg(k, 13)) Then
                        If IsNumeric(Fg(k, 13)) Then
                            IMP4 += Fg(k, 13)
                        End If
                    End If

                    EmisorRfcCFD = "" : FolioCFD = "" : SerieCFD = "" : FechaEmision = "" : TotalCFD = 0 : SubtotalCFD = 0 : IVAcfd = 0
                    VersionCFD = "" : MonedaCFD = "" : FormaPagoCFD = "" : UsoCFDICFD = "" : TipoComprobanteCFD = "" : UsoCFD = ""

                    If FILE_XML.Trim.Length > 0 Then

                        UUID_XML = OBTENER_UUID_XML(FILE_XML)
                        Try
                            '"2021-08-10T11:45:51"
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

                    CONCEPTO = "Proveedores Proveedor " & CVE_CLPV & " , Doc-" & CVE_DOC & " - " & FECHA

                    s = s & "<ROWPartidas Cuenta=""" & CTA_PROV & """ Depto=""0"" ConceptoPol=""" & CONCEPTO & """"
                    s = s & " Monto=""" & Math.Round(IMPORTE, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""""
                    s = s & " RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" &
                        NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID>" & CADENA1 & "</CDSPartidasUUID></ROWPartidas>"
                    If NUM_PARX <> 0 Then
                        NUM_PAR = NUM_PAR + 1
                    End If
                    Try
                        'SQL = "UPDATE COMPC" & Empresa & " Set ACT_COI = 'S' WHERE CVE_DOC = '" & CVE_DOC & "'"
                        'Using cmd As SqlCommand = cnSAE.CreateCommand
                        'cmd.CommandText = SQL
                        'returnValue = cmd.ExecuteNonQuery().ToString
                        'If returnValue IsNot Nothing Then
                        'If returnValue = "1" Then
                        'End If
                        'End If
                        'End Using
                    Catch ex As Exception
                        Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("220. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
            Next
            NUM_PARX = 0

            CTA_RETENCION = "233-001-0008"
            CTA_RETENCION_IVA = "121-001-0000"
            CTA_IVA = "121-001-0000"

            If IMP2 > 0 Then
                s = s & "<ROWPartidas Cuenta=""" & CTA_RETENCION & """ Depto=""0"" ConceptoPol="""
                s = s & "Impuesto " & """ Monto=""" & Math.Round(IMP2, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""" RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" & NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID></ROWPartidas>"
            End If

            If IMP3 > 0 Then
                s = s & "<ROWPartidas Cuenta=""" & CTA_RETENCION_IVA & """ Depto=""0"" ConceptoPol="""
                s = s & "Impuesto " & """ Monto=""" & Math.Round(IMP3, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""" RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" & NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID></ROWPartidas>"
            End If

            If IMP4 > 0 Then
                s = s & "<ROWPartidas Cuenta=""" & CTA_IVA & """ Depto=""0"" ConceptoPol="""
                s = s & "Impuesto " & """ Monto=""" & Math.Round(IMP4, 2) & """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""" RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" & NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID></ROWPartidas>"
            End If


            NUM_PAR = NUM_PAR + 1
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            NUM_PARX = 0
            For k = 1 To Fg2.Rows.Count - 1
                Try
                    Try
                        ALMACEN = Fg2(k, 2)
                        IMPORTE = Fg2(k, 3)
                        CTA_ALMACEN = Fg2(k, 4).ToString.Replace("-", "")
                    Catch ex As Exception
                        Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    s = s & "<ROWPartidas Cuenta=""" & CTA_ALMACEN & """ Depto=""0"" ConceptoPol=""" & ALMACEN & """ Monto=""" & Math.Round(IMPORTE, 2) & """ TipoCambio=""1"" DebeHaber=""D"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""" RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""" & NUM_PARX & """ IDFISCAL=""""><CDSPartidasUUID></CDSPartidasUUID></ROWPartidas>"
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        s = s & "</Partidas></ROW></ROWDATA></DATAPACKET>"
        BACKUPXML(POLIZA_MODELO, s)

        Fg.Redraw = True
        Fg.Cursor = Cursors.Default
        Me.Cursor = Cursors.Default

        MsgBox("La poliza modelo se grabo satisfactoriamente en " & POLIZA_MODELO & ".POL")


    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND ISNULL(C.STATUS,'') <> 'C'" ' AND 
            'ISNULL(C.ACT_COI,'N') = 'N' "
            DESPLEGAR()

            DESPLEGAR_ALMACEN()

            Fg.Select()
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Tab1_SelectedIndexChanging(sender As Object, e As SelectedIndexChangingEventArgs) Handles Tab1.SelectedIndexChanging
        Try
            If Tab1.SelectedIndex = 0 Then
                LtNUm.Text = "Registros encontrados: " & Fg2.Rows.Count - 1
            Else
                LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg2_DoubleClick(sender As Object, e As EventArgs) Handles Fg2.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg2(Fg2.Row, Fg2.Col))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub F1_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F1.DropDownClosed
        Try
            Dim d1 As DateTime = F1.Value

            tPOLIZA.Text = "Compras almacen " & MonthName(d1.Month)
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String
        Dim strSerie As String
        Dim strFolio As String
        Dim strFechaEmision As String
        Dim strSello As String
        Dim strNoCertificado As String
        Dim strSubtotal As String
        Dim strTotal As String
        Dim strMoneda As String
        Dim strCondiciones As String
        Dim strFormaPago As String
        Dim strMetodoPago As String
        Dim strLugarExpedicion As String

        Dim strReceptorRfc As String

        Dim strEmisorRfc As String
        Dim strEmisorNombre As String
        Dim strEmisorCalle As String
        Dim strEmisorNoExterior As String
        Dim strEmisorNoInterior As String
        Dim strEmisorColonia As String
        Dim strEmisorMunicipio As String
        Dim strEmisorEstado As String
        Dim strUsoCFDI As String

        Dim strRegimen As String
        Dim strDescuento As String
        Dim strNumCtaPago As String
        Dim strVersion As String
        Dim NoCertificadoSAT As String
        Dim UUID As String
        Dim UUIDR As String

        Dim FechaTimbrado As String
        Dim strVersionTimbre As String
        Dim NumOperacion As String
        Dim Monto As String
        Dim FormaDePagoP As String
        Dim FechaPago As String
        Dim Folio As String
        Dim Serie As String
        Dim ImpSaldoInsoluto As String
        Dim ImpPagado As String
        Dim ImpSaldoAnt As String
        Dim NumParcialidad As String
        Dim MetodoDePagoDR As String
        Dim concepto As XmlNodeList
        Dim Elemento As XmlNode
        Dim subnodo As XmlElement
        Dim IdDocumento As String

        Dim XML As String
        Dim xDoc As XmlDocument
        Dim xNodo As XmlNodeList
        Dim xAtt As XmlElement
        Dim Comprobante As XmlNode
        Dim RUTA_XML As String
        Dim Impuestos As XmlNode = Nothing
        Dim totalImpuestosTrasladados As Decimal
        Dim vsTIT As Decimal
        Dim k As Integer

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

        strEmisorNombre = "" : strFechaEmision = "" : strEmisorCalle = "" : strEmisorMunicipio = "" : strEmisorEstado = ""
        strEmisorNoExterior = "" : strEmisorNoInterior = "" : strEmisorColonia = "" : strFormaPago = "" : strMetodoPago = ""
        strSubtotal = "" : strTotal = "" : strEmisorRfc = "" : strFolio = "" : strDescuento = "0" : strNumCtaPago = ""
        strSerie = "" : strVersionTimbre = "" : UUID = "" : FechaTimbrado = "" : NoCertificadoSAT = "" : strTipoComprobante = "" : strUsoCFDI = ""
        strReceptorRfc = "" : UUIDR = ""

        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""

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
End Class
