
Imports Stimulsoft.Report
Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Themes
Imports C1.Win.C1Input

Public Class FrmCFDICancPago
    Private TIMBRADO_DEMO As String = "No"
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private EMISOR_RFC As String
    Private aUUID(0) As String

    Private Sub FrmCFDICancPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        'Var2 = Fg(Fg.Row, 2) 'FACTURA
        'Var3 = Fg(Fg.Row, 3) 'CATA PORTE 1
        'Var4 = Fg(Fg.Row, 4) 'CATA PORTE 2


        Try
            LtFactura.Text = Var2
            LtUUI.Text = BUSCAR_UUID_CFDI_PAGO(LtFactura.Text)

            LtFacturaSust.Text = " "
            LTUUID_SUSTITUYE.Text = " "

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
                        gContraPFX = dr("PASS_PFX").ToString  'contrasena del certificado
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
        Dim TimbreOK As Boolean = False, XML_TABLA As String = "", FILE_XML As String = "", CVE_DOC As String = ""
        Dim CER64 As String, KEY64 As String, USUAARIO_TIMB As String, PASS_TIMB As String, FECHA_CAN As String = ""
        Dim ListaUUID As New List(Of String), SIGUE As Boolean
        Dim d As DateTime = DateTime.Now
        Dim resultado As String = "", CVE_MCANC As String = "01", UUID As String = ""
        Dim xdoc As New XmlDocument()

        If CboMotivoCanc.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione un motivo de cancelación")
            Return
        End If

        If LtUUI.Text.Trim.Length = 0 Then
            MsgBox("No existe el UUID del complemento de pago")
            Return
        End If

        If MsgBox("Realmente desea cancelar el complemento de pago?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            CVE_MCANC = CboMotivoCanc.Items(CboMotivoCanc.SelectedIndex)
            If CVE_MCANC = "01" Then
                If LTUUID_SUSTITUYE.Text.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione el complemento de pago que sustituye")
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

        Try

            CVE_DOC = LtFactura.Text

            If Var3 = "Timbrada" Then
                CVE_MCANC = CboMotivoCanc.Items(CboMotivoCanc.SelectedIndex)

                If TIMBRADO_DEMO = "Si" Then
                    USUAARIO_TIMB = "demo2"
                    PASS_TIMB = "123456789"
                Else
                    USUAARIO_TIMB = gUSUARIO_PAC
                    PASS_TIMB = gPASS_PAC
                End If

                aUUID(0) = LtUUI.Text
                ListaUUID.Add(aUUID(0))

                CER64 = ConvertFileToBase64(gRutaCertificado)
                KEY64 = ConvertFileToBase64(gRutaPFX)

                FECHA_CAN = DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss")

                If TIMBRADO_DEMO = "Si" Then
                    Try
                        Dim autentication As New WSDIGIBOX_AUTENTICATION.wsAutenticacionSoapClient()
                        Dim token = autentication.AutenticarBasico(USUAARIO_TIMB, PASS_TIMB)

                        Dim timbrarSOAP As New WSDIGIBOX_CANCEL_DEMO.wsCancelacionSoapClient

                        resultado = timbrarSOAP.CancelarCSDV2(CER64, KEY64, gContraPFX, EMISOR_RFC, aUUID, UUID, CVE_MCANC, token)

                        If resultado.Trim.Length > 0 Then
                            Sigue = True
                        Else
                            Sigue = False
                        End If
                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("12. " & ex.Message)
                    End Try
                Else
                    Try
                        Dim autentication As DIGIBOX_AUTENTICACION.wsAutenticacionSoapClient = New DIGIBOX_AUTENTICACION.wsAutenticacionSoapClient()
                        Dim token = autentication.AutenticarBasico(USUAARIO_TIMB, PASS_TIMB)
                        Dim timbrarSOAP As WSDIGIBOX_CANCEL_2022.wsCancelacionSoapClient = New WSDIGIBOX_CANCEL_2022.wsCancelacionSoapClient

                        resultado = timbrarSOAP.CancelarCSDV2(CER64, KEY64, gContraPFX, EMISOR_RFC, aUUID, UUID, CVE_MCANC, token)

                        If resultado.Trim.Length > 0 Then
                            Sigue = True
                        Else
                            Sigue = False
                        End If
                    Catch ex As Exception
                        BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("12. " & ex.Message)
                    End Try
                End If
            Else
                SIGUE = True
            End If


            If SIGUE Then

                BACKUPTXT("CFDI CANCEL", CVE_DOC & "," & resultado & "," & FECHA_CAN & "," & TOBSER.Text & "," & USER_GRUPOCE)

                SQL = "UPDATE CFDI_COMPAGO SET ESTATUS = 'C', FECHA_CANCEL = @FECHA_CANCEL, XML_CANC = @XML_CANC,
                    OBS_CANC = @OBS_CANC, CVE_DOC_REL = @CVE_DOC_REL, UUID_REL = @UUID_REL
                    WHERE CVE_DOC = @CVE_DOC"
                Try
                    'Var2 = Fg(Fg.Row, 2) 'FACTURA
                    'Var3 = Fg(Fg.Row, 3) 'CATA PORTE 1   CVE_FOLIO
                    'Var4 = Fg(Fg.Row, 4) 'CATA PORTE 2
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@XML_CANC", SqlDbType.VarChar).Value = resultado
                        cmd.Parameters.Add("@FECHA_CANCEL", SqlDbType.VarChar).Value = FECHA_CAN
                        cmd.Parameters.Add("@OBS_CANC", SqlDbType.VarChar).Value = TOBSER.Text
                        cmd.Parameters.Add("@USUARIO_CANCELA", SqlDbType.VarChar).Value = USER_GRUPOCE
                        cmd.Parameters.Add("@CVE_DOC_REL", SqlDbType.VarChar).Value = LtFacturaSust.Text
                        cmd.Parameters.Add("@UUID_REL", SqlDbType.VarChar).Value = LTUUID_SUSTITUYE.Text
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    End Using

                    Try
                        'GCCFDI_COMPAGO_PAR_DR 
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT REFER FROM CFDI_COMPAGO_PAR_DR WHERE CVE_DOC = '" & CVE_DOC & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    For z = 1 To 5
                                        SQL = "UPDATE CUEN_DET" & Empresa & " SET CVE_DOC_COMPPAGO = '' WHERE REFER = @REFER"
                                        Try
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                cmd2.CommandText = SQL
                                                cmd2.Parameters.Clear()
                                                cmd2.Parameters.Add("@REFER", SqlDbType.VarChar).Value = dr("REFER")
                                                returnValue = cmd2.ExecuteNonQuery().ToString
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
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    Var17 = "Desplega"
                    Try
                        Dim FILE_PDF As String, Reporte_MRT As String, RUTA_FORMATOS As String

                        FILE_XML = gRutaXML_TIMBRADO & "\TEMPCP" & CVE_DOC & ".xml"
                        File.WriteAllText(FILE_XML, resultado)

                        FILE_PDF = gRutaXML_NO_TIMBRADO & "\" & CVE_DOC & "CANC" & ".pdf"

                        RUTA_FORMATOS = GET_RUTA_FORMATOS()
                        Reporte_MRT = RUTA_FORMATOS & "\ReportCancelPagoCompo.mrt"
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
            Else
                Dim msg As Object

                msg = New VtlMessageBox(C1.Win.C1Ribbon.VisualStyle.Office2010Blue)
                Dim Result As String
                With msg
                    '.AddImageToMoreText("gridImage", img)
                    .MessageText = "No se logro realizar la cancelación"
                    '.MoreText = "-----"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Proceso terminado"
                    .Icon = MessageBoxIcon.Error

                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()
                End With
            End If
            'TIMBRADO DEMO                  'TIMBRADO DEMO                  'TIMBRADO DEMO
        Catch ex As Exception
            BITACORACFDI("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmCFDICancPago_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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
            Var2 = "PAGO CFDI"
            Var4 = "" : Var5 = ""
            'Var25 = CLIENTE YA VIENE DESDE LA VENTA ANTERIOR
            PassData = "TOP"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                If LtFactura.Text = Var4 Then
                    MsgBox("Por favor selecciono otro documento no puede ser igual al documento a cancelar")
                Else
                    Var47 = "PAGO CFDI"
                    LTUUID_SUSTITUYE.Text = BUSCAR_UUID_CARTA_PORTE(Var4)
                    LtFacturaSust.Text = Var4
                End If
            End If
        Catch Ex As Exception
            BITACORACFDI("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("402. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BarLimpiarRel_Click(sender As Object, e As EventArgs) Handles BarLimpiarRel.Click
        LtFacturaSust.Text = ""
        LTUUID_SUSTITUYE.Text = ""
    End Sub
End Class
