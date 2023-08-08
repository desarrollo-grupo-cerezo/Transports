
Imports Stimulsoft.Report
Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Themes
Imports C1.Win.C1Input

Public Class FrmCFDICancFAC
    Private TIMBRADO_DEMO As String = "No"
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private EMISOR_RFC As String
    Private CVE_FOLIO As String

    Private Sub FrmCFDICancFAC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        Lt1.Visible = False
        Lt2.Visible = False
        Lt5.Visible = False
        BtnCartaPorte.Visible = False
        LTUUID_SUSTITUYE.Visible = False
        LtFacturaSust.Visible = False

        'Var2 = Fg(Fg.Row, 2) 'FACTURA
        'Var3 = Fg(Fg.Row, 3) 'CATA PORTE 1
        'Var4 = Fg(Fg.Row, 4) 'CATA PORTE 2

        Try

            CVE_FOLIO = Var3

            LtFactura.Text = Var2 ' BUSCARA EN TABLA CFDI

            LtUUI.Text = BUSCAR_UUID_CARTA_PORTE(LtFactura.Text)

        Catch ex As Exception
            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
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

                        Else
                            TIMBRADO_DEMO = "Si"

                            LtTimbrado.Text = "Timbrado DEMO"

                        End If
                        EMISOR_RFC = dr("EMISOR_RFC")
                        gRutaXML_NO_TIMBRADO = dr("RUTA_XML_NOTIMBRADO")
                        gRutaXML_TIMBRADO = dr("RUTA_XML_TIMBRADO")
                        gRutaCertificado = dr("FILE_CER") 'CERTIFICADO
                        gRutaPFX = dr("FILE_PFX").ToString '.KEY
                        gContraPFX = Desencriptar(dr("PASS_PFX").ToString)  'contrasena del certificado
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            CboMotivoCanc.Items.Clear()
            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Almacén", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))

            CboMotivoCanc.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_MOCANC ORDER BY CVE_MCANC"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_MCANC"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboMotivoCanc.TextDetached = True
            CboMotivoCanc.ItemsDataSource = dt.DefaultView
            CboMotivoCanc.ItemsDisplayMember = "Descripción"
            CboMotivoCanc.ItemsValueMember = "Almacén"
            CboMotivoCanc.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboMotivoCanc.HtmlPattern = "<table><tr><td width=30>{Almacén}</td><td width=1550>{Descripción}</td><td width=1600></tr></table>"
        Catch ex As Exception
            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As ClickEventArgs) Handles BarCancelar.Click
        Dim TimbreOK As Boolean = False, XML_TABLA As String = "", FILE_XML As String = "", CVE_DOC As String = "", FACTURA As String
        Dim CER64 As String, KEY64 As String, USUAARIO_TIMB As String, PASS_TIMB As String
        Dim aUUID(0) As String, ListaUUID As New List(Of String)
        Dim d As DateTime = DateTime.Now
        Dim resultado As String, CVE_MCANC As String = "01", UUID As String = ""
        Dim xdoc As XmlDocument = New XmlDocument()

        If Not Valida_Conexion() Then
            Return
        End If

        If CboMotivoCanc.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione un motivo de cancelación")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            CVE_MCANC = CboMotivoCanc.Items(CboMotivoCanc.SelectedIndex)
            If CVE_MCANC = "01" Then
                If LTUUID_SUSTITUYE.Text.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione carta porte que sustituye")
                    Return
                End If
                UUID = LTUUID_SUSTITUYE.Text
            Else
                UUID = ""
            End If
        Catch ex As Exception
            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        FACTURA = LtFactura.Text

        'Var6 = "FBUENO"  'FACTURA BUENO
        'Var6 = "FCPT"  'FACTURA CARTA PORTE TRASLADO
        'Var6 = "FTPV"  'FACTURA TPV
        'Var6 = "FTPVN"  'FACTURA DESDE FrmTPVNotas
        Select Case Var6
            Case "FBUENO"
                If MsgBox("Realmente desea cancelar la factura " & FACTURA & "?", vbYesNo) = vbNo Then
                    Return
                End If
            Case "FCPT"
                If MsgBox("Realmente desea cancelar la carta porte traslado " & FACTURA & "?", vbYesNo) = vbNo Then
                    Return
                End If
            Case "FTPV"
                If MsgBox("Realmente desea cancelar la factura " & FACTURA & "?", vbYesNo) = vbNo Then
                    Return
                End If
            Case "FTPVN"
                If MsgBox("Realmente desea cancelar la factura " & FACTURA & "?", vbYesNo) = vbNo Then
                    Return
                End If
        End Select

        Try
            If PassData9 = "TIMBRADA" Then
                ' CANCELADA PENDIENTE
                If TIMBRADO_DEMO = "Si" Then
                    USUAARIO_TIMB = "demo2"
                    PASS_TIMB = "123456789"
                Else
                    USUAARIO_TIMB = gUSUARIO_PAC
                    PASS_TIMB = gPASS_PAC
                End If

                Var47 = ""
                aUUID(0) = BUSCAR_UUID_CARTA_PORTE(FACTURA)
                ListaUUID.Add(aUUID(0))
                CER64 = ConvertFileToBase64(gRutaCertificado)
                KEY64 = ConvertFileToBase64(gRutaPFX)

                resultado = ""
                Dim FECHA_CAN As String = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss")
                If TIMBRADO_DEMO = "Si" Then
                    Try
                        Dim Autentication As New WSDIGIBOX_AUTENTICATION.wsAutenticacionSoapClient()
                        Dim Token = Autentication.AutenticarBasico(USUAARIO_TIMB, PASS_TIMB)
                        Dim TimbrarSOAP As New WSDIGIBOX_CANCEL_DEMO.wsCancelacionSoapClient
                        resultado = TimbrarSOAP.CancelarCSDV2(CER64, KEY64, gContraPFX, EMISOR_RFC, aUUID, UUID, CVE_MCANC, Token)
                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    Try
                        Dim Autentication As New DIGIBOX_AUTENTICACION.wsAutenticacionSoapClient()
                        Dim Token = Autentication.AutenticarBasico(USUAARIO_TIMB, PASS_TIMB)
                        Dim TimbrarSOAP As New WSDIGIBOX_CANCEL_2022.wsCancelacionSoapClient
                        resultado = timbrarSOAP.CancelarCSDV2(CER64, KEY64, gContraPFX, EMISOR_RFC, aUUID, UUID, CVE_MCANC, token)
                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("12. " & ex.Message)
                    End Try
                End If

                BACKUPTXT("CFDI CANCEL XML", resultado & vbNewLine)

                If resultado.Trim.Length > 0 Then

                    SQL = "UPDATE CFDI SET ESTATUS = 'C', FECHA_CANCELADA = GETDATE(), FECHA_CANCEL = @FECHA_CANCEL, XML_CANC = @XML_CANC,
                        OBS_CANC = @OBS_CANC 
                        WHERE FACTURA = @FACTURA"
                    Try
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FACTURA
                                cmd.Parameters.Add("@XML_CANC", SqlDbType.VarChar).Value = resultado
                                'cmd.Parameters.Add("@FECHA_CANCEL", SqlDbType.VarChar).Value = FECHA_CAN
                                cmd.Parameters.Add("@OBS_CANC", SqlDbType.VarChar).Value = TOBSER.Text
                                cmd.Parameters.Add("@USUARIO_CANCELA", SqlDbType.VarChar).Value = USER_GRUPOCE
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        BACKUPTXT("CFDI CANCEL", FACTURA & "," & resultado & "," & FECHA_CAN & "," & TOBSER.Text & "," & USER_GRUPOCE)

                        Try
                            Dim FILE_PDF As String, Reporte_MRT As String, RUTA_FORMATOS As String

                            FILE_XML = gRutaXML_TIMBRADO & "\TEMPCP" & FACTURA & ".xml"
                            File.WriteAllText(FILE_XML, resultado)

                            FILE_PDF = gRutaXML_NO_TIMBRADO & "\" & EMISOR_RFC & "-" & FACTURA & "CANC" & ".pdf"

                            RUTA_FORMATOS = GET_RUTA_FORMATOS()
                            Reporte_MRT = RUTA_FORMATOS & "\ReportFacturaCanc.mrt"
                            If File.Exists(Reporte_MRT) Then
                                StiReport1.Load(Reporte_MRT)

                                Dim xmlDataBase = New Stimulsoft.Report.Dictionary.StiXmlDatabase("Data", FILE_XML)
                                StiReport1.Dictionary.Databases.Clear()
                                StiReport1.Dictionary.Databases.Add(xmlDataBase)
                                StiReport1.Compile()
                                StiReport1.Render()
                                'StiReport1.Design()
                                StiReport1.ExportDocument(StiExportFormat.Pdf, FILE_PDF)
                                StiReport1.Show()
                            Else
                                MsgBox("No existe el reporte " & Reporte_MRT & ", verifique por favor")
                                MsgBox("Cancelación exitosa")
                                Return
                            End If
                        Catch ex As Exception
                            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    Catch ex As Exception
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                    Var5 = "ok"
                Else
                    MsgBox("No se logro realizar la cancelación")
                End If
            Else
                Try
                    SQL = "UPDATE FACTF" & Empresa & " SET STATUS = 'C' WHERE CVE_DOC = '" & FACTURA & "'"
                    EXECUTE_QUERY_NET(SQL)

                    SQL = "DELETE FROM CUEN_M" & Empresa & " WHERE REFER = '" & FACTURA & "'"
                    EXECUTE_QUERY_NET(SQL)

                    SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & FACTURA & "'"
                    EXECUTE_QUERY_NET(SQL)

                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT * FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & FACTURA & "'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then

                                    SQL = "INSERT INTO CFDI (FACTURA, ESTATUS, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                                        CLIENTE, SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID) 
                                        VALUES (
                                        @FACTURA, 'C', @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                                        @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID())"
                                    For k = 1 To 5
                                        Application.DoEvents()
                                        Try
                                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                                cmd.CommandText = SQL
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FACTURA
                                                cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "F"
                                                cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                                                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = dr2("SERIE")
                                                cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = dr2("FOLIO")
                                                cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Now
                                                cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "N"
                                                cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                                                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = dr2("CVE_CLPV")
                                                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(dr2("CAN_TOT"), 6)

                                                cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(dr2("IMP_TOT1"), 6)
                                                cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(dr2("IMP_TOT2"), 6)
                                                cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(dr2("IMP_TOT3"), 6)
                                                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(dr2("IMP_TOT4"), 6)
                                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(dr2("IMPORTE"), 6)
                                                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = ""
                                                returnValue = cmd.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                        Exit For
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try
                                    Next
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    MsgBox("La cancelación se realizó correctamente")
                    Var5 = "ok"
                    Me.Close()
                Catch ex As Exception
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            End If

            'TIMBRADO DEMO                  'TIMBRADO DEMO                  'TIMBRADO DEMO
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmCFDICancFAC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CboMotivoCanc_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboMotivoCanc.DropDownClosed
        Try
            Dim CVE_MOC As String = ""

            If CboMotivoCanc.SelectedIndex > -1 Then
                CVE_MOC = CboMotivoCanc.Items(CboMotivoCanc.SelectedIndex)
                LtMotivo.Text = CVE_MOC & " " & CboMotivoCanc.Text
                If CVE_MOC = "01" Then
                    Lt1.Visible = True
                    Lt2.Visible = True
                    Lt5.Visible = True
                    BtnCartaPorte.Visible = True
                    LTUUID_SUSTITUYE.Visible = True
                    LtFacturaSust.Visible = True

                    LtFacturaSust.Text = ""
                Else
                    Lt1.Visible = False
                    Lt2.Visible = False
                    Lt5.Visible = False
                    BtnCartaPorte.Visible = False
                    LTUUID_SUSTITUYE.Visible = False
                    LtFacturaSust.Visible = False
                End If
            End If
        Catch ex As Exception
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCartaPorte_Click(sender As Object, e As EventArgs) Handles BtnCartaPorte.Click
        Try
            Var2 = "FACTURA CFDI"
            Var4 = "" : Var5 = ""
            PassData = "TOP"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'FACTURA
                'Var5 = Fg(Fg.Row, 2) 'CLIENTE
                'Var6 = Fg(Fg.Row, 3) 'NOMBRE
                'Var7 = Fg(Fg.Row, 4) 'FECHA
                LTUUID_SUSTITUYE.Text = BUSCAR_UUID_CARTA_PORTE(Var4)
                LtFacturaSust.Text = Var4
            End If
        Catch Ex As Exception
            BITACORACFDI("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
End Class
