Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid

Public Class FrmPolizaDeCompras
    Dim CADENA As String = ""
    Dim RUTA_MODELO As String = ""
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Private Sub FrmPolizaDeCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub FrmPolizaDeCompras_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Póliza de compras")
    End Sub
    Sub DESPLEGAR()
        If Not Valida_Conexion() Then
            Return
        End If
        Fg.Redraw = False
        Try
            SQL = "SELECT  C.CVE_DOC, C.CVE_CLPV, NOMBRE, C.STATUS, C.SU_REFER, C.FECHA_DOC, C.FECHA_PAG, 
                CAST(C.NUM_ALMA AS VARCHAR(2)) + '. ' + A.DESCR, C.CAN_TOT, (C.IMP_TOT1 + C.IMP_TOT2 + C.IMP_TOT3 + C.IMP_TOT4) AS 'Impuesto', 
                C.DES_TOT, C.IMPORTE, C.FECHAELAB, 
                CASE ISNULL(C.TIP_DOC_ANT,'') WHEN 'c' THEN 'Compra' WHEN 'o' THEN 'Orden de compra' WHEN 'r' THEN 'Recepción' WHEN 'q' THEN 'Requsición' ELSE '' END AS TIPO_D_ANT, 
                ISNULL(C.DOC_ANT,'') AS DOCANT, ISNULL(UUID_XML,'') AS 'UUID Fiscal', 
                ISNULL(P.RFC,'') AS RFC_, ISNULL(P.CUENTA_CONTABLE,'') AS 'Cta. contable proveedor', C.SERIE AS 'Serie', C.FOLIO AS 'Folio'
                FROM COMPC" & Empresa & " C " &
                "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE  = C.CVE_CLPV
                LEFT JOIN ALMACENES" & Empresa & " A ON A.CVE_ALM = C.NUM_ALMA
                LEFT JOIN GCCOMPRAS X ON X.CVE_DOC = C.CVE_DOC " &
                CADENA & " ORDER BY C.FECHAELAB DESC"
            '  17              18                                      19                  20
            'p.RFC, p.CUENTA_CONTABLE AS 'Cta. contable proveedor', C.SERIE AS 'Serie', C.FOLIO AS 'Folio'

            Dim da As New SqlDataAdapter
            Dim dt As New DataTable

            da = New SqlDataAdapter(SQL, cnSAE)
            dt = New DataTable ' crear un DataTable
            da.SelectCommand.CommandTimeout = 120
            da.Fill(dt)

            BindingSource1.DataSource = dt
            Fg.DataSource = BindingSource1.DataSource

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
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(DateTime)

            Fg(0, 8) = "Almacen"
            Dim c8 As Column = Fg.Cols(12)
            c8.DataType = GetType(Int32)

            Fg(0, 9) = "Sub. total"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(Decimal)
            Fg.Cols(9).Format = "###,###,##0.00"

            Fg(0, 10) = "Impuesto"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(Decimal)
            Fg.Cols(10).Format = "###,###,##0.00"

            Fg(0, 11) = "Descuento"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(Decimal)
            Fg.Cols(11).Format = "###,###,##0.00"

            Fg(0, 12) = "Importe"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(Decimal)
            Fg.Cols(12).Format = "###,###,##0.00"

            Fg(0, 13) = "Fecha elab."
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(DateTime)

            Fg(0, 14) = "Tipo documento anterior"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Fg(0, 15) = "Documento anterior"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(String)

            Fg.AutoSizeCols()

            Fg.Cols(4).TextAlign = TextAlignEnum.CenterCenter
            Fg.Cols(14).TextAlign = TextAlignEnum.CenterCenter

            LtNUm.Text = "Registros encontrados: " & Fg.Rows.Count - 1

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Fg.Redraw = True
    End Sub
    Private Sub BarCarpeta_Click(sender As Object, e As ClickEventArgs) Handles BarCarpeta.Click
        If RUTA_MODELO.Trim.Length > 0 Then
            Process.Start("explorer.exe", RUTA_MODELO)
        End If
    End Sub

    Private Sub BarDesplegar_Click(sender As Object, e As ClickEventArgs) Handles BarDesplegar.Click
        Try
            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND C.STATUS <> 'C' AND 
                    ISNULL(C.ACT_COI,'N') = 'N' "
            DESPLEGAR()

            CADENA = " WHERE FECHA_DOC >= '" & FSQL(F1.Value) & "' AND FECHA_DOC <= '" & FSQL(F2.Value) & "' AND C.STATUS <> 'C' AND 
                    ISNULL(C.ACT_COI,'N') = 'N' "

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarExcel_Click(sender As Object, e As ClickEventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PolizaCompras")
        Catch ex As Exception
        End Try
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
        Dim CTA_ALMACEN As String = "", NOMBRE As String = "", FECHA As String = "", UUID_XML As String = "", SERIE As String = "", FOLIO As Long
        Dim POLIZA_MODELO As String = ""

        If MsgBox("Realmente desea generar la compra modelo?", vbYesNo) = vbNo Then
            Return
        End If

        POLIZA_MODELO = RUTA_MODELO & "\" & tPOLIZA.Text.Replace("/", "_") & ".POL"
        If POLIZA_MODELO.Length > 255 Then
            POLIZA_MODELO = POLIZA_MODELO.Substring(0, 255)
        End If

        Try
            s = "<?xml version=""1.0"" standalone=""yes""?>  <DATAPACKET Version=""2.0""><METADATA><FIELDS><FIELD attrname=""VersionCOI"" fieldtype=""i2""/><FIELD attrname=""TipoPoliz"" fieldtype=""String"" WIDTH=""5""/><FIELD attrname=""DiaPoliz"" fieldtype=""String"" WIDTH=""2""/><FIELD attrname=""ConcepPoliz"" fieldtype=""String"" WIDTH=""120""/><FIELD attrname=""UUID"" fieldtype=""String"" WIDTH=""100""/><FIELD attrname=""Partidas"" fieldtype=""nested""><FIELDS><FIELD attrname=""Cuenta"" fieldtype=""String"" WIDTH=""21""/><FIELD attrname=""Depto"" fieldtype=""i4""/><FIELD attrname=""ConceptoPol"" fieldtype=""String"" WIDTH=""120""/><FIELD attrname=""Monto"" fieldtype=""r8""/><FIELD attrname=""TipoCambio"" fieldtype=""r8""/><FIELD attrname=""DebeHaber"" fieldtype=""String"" WIDTH=""1""/><FIELD attrname=""ccostos"" fieldtype=""i4""/><FIELD attrname=""proyectos"" fieldtype=""i4""/><FIELD attrname=""Porcentaje"" fieldtype=""r8""/><FIELD attrname=""FRMPAGO"" fieldtype=""String"" WIDTH=""5""/><FIELD attrname=""NUMCHEQUE"" fieldtype=""String"" WIDTH=""20""/><FIELD attrname=""MONTOBN"" fieldtype=""r8""/><FIELD attrname=""BANCO"" fieldtype=""i4""/><FIELD attrname=""CTAORIG"" fieldtype=""String"" WIDTH=""50""/><FIELD attrname=""BENEF"" fieldtype=""String"" WIDTH=""300""/><FIELD attrname=""RFC"" fieldtype=""String"" WIDTH=""13""/><FIELD attrname=""BANCODEST"" fieldtype=""i4""/><FIELD attrname=""CTADEST"" fieldtype=""String"" WIDTH=""50""/><FIELD attrname=""FECHACHEQUE"" fieldtype=""String"" WIDTH=""10""/><FIELD attrname=""BANCOORIGEXT"" fieldtype=""String"" WIDTH=""225""/><FIELD attrname=""BANCODESTEXT"" fieldtype=""String"" WIDTH=""225""/><FIELD attrname=""IDUUID"" fieldtype=""i4""/><FIELD attrname=""IDFISCAL"" fieldtype=""String"" WIDTH=""40""/><FIELD attrname=""CDSPartidasUUID"" fieldtype=""nested""><FIELDS><FIELD attrname=""NUMREG"" fieldtype=""i4""/><FIELD attrname=""UUIDTIMBRE"" fieldtype=""String"" WIDTH=""36""/><FIELD attrname=""MONTO"" fieldtype=""r8""/><FIELD attrname=""SERIE"" fieldtype=""String"" WIDTH=""100""/><FIELD attrname=""FOLIO"" fieldtype=""String"" WIDTH=""100""/><FIELD attrname=""RFCEMISOR"" fieldtype=""String"" WIDTH=""16""/><FIELD attrname=""RFCRECEPTOR"" fieldtype=""String"" WIDTH=""16""/><FIELD attrname=""FECHAUUID"" fieldtype=""String"" WIDTH=""10""/><FIELD attrname=""TIPOCOMPROBANTE"" fieldtype=""i2""/></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></FIELD></FIELDS><PARAMS/></METADATA>"
            s = s & "<ROWDATA><ROW VersionCOI=""810"" TipoPoliz=""Co"" DiaPoliz=""30"" ConcepPoliz=""" & tPOLIZA.Text & """>"

            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_DOC = Fg(k, 1)
                    CVE_CLPV = Fg(k, 2)
                    NOMBRE = Fg(k, 3)
                    FECHA = Fg(k, 6)
                    IMPUESTO = Fg(k, 10)
                    IMPORTE = Fg(k, 12)
                    UUID_XML = Fg(k, 16)
                    RFC = Fg(k, 17)
                    CTA_PROV = Fg(k, 18).ToString.Replace("-", "")
                    SERIE = Fg(k, 19)
                    FOLIO = Fg(k, 20)
                Catch ex As Exception
                    Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                '  17              18                                      19                  20
                'p.RFC, p.CUENTA_CONTABLE AS 'Cta. contable proveedor', C.SERIE AS 'Serie', C.FOLIO AS 'Folio'
                s = s & "<Partidas><ROWPartidas Cuenta=""" & CTA_PROV & """ Depto=""0"" ConceptoPol="""
                s = s & "Proveedores Proveedor " & CVE_CLPV & " , Doc-""" & CVE_DOC & """ - """ & FECHA & """ Monto=""" & Math.Round(IMPORTE, 2) &
                    """ TipoCambio=""1"" DebeHaber=""H"" ccostos=""0"" proyectos=""0"" FRMPAGO="""" NUMCHEQUE="""" MONTOBN=""0"" BANCO=""0"" CTAORIG="""" BENEF="""" RFC="""" BANCODEST=""0"" CTADEST="""" FECHACHEQUE="""" BANCOORIGEXT="""" BANCODESTEXT="""" IDUUID=""7477"" IDFISCAL=""""><CDSPartidasUUID><ROWCDSPartidasUUID NUMREG=""7477"" UUIDTIMBRE=""" &
                    UUID_XML & """ MONTO=""" & Math.Round(IMPORTE, 2) & """ SERIE=""" & SERIE & """ FOLIO=""" & FOLIO & """ RFCEMISOR=""" & RFC & """ RFCRECEPTOR=""TEM820612AF7"" FECHAUUID=""01/04/2021"" TIPOCOMPROBANTE=""1""/></CDSPartidasUUID></ROWPartidas>"
                Try
                    SQL = "UPDATE COMPC" & Empresa & " SET ACT_COI = 'S' WHERE CVE_DOC = '" & CVE_DOC & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("220. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        s = s & "</Partidas></ROW></ROWDATA></DATAPACKET>"

        BACKUPXML(POLIZA_MODELO, s)

        MsgBox("La poliza modelo se grabo satisfactoriamente en " & POLIZA_MODELO & ".POL")

    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
