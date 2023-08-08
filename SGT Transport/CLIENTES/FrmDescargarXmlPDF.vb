Imports Stimulsoft.Report
Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmDescargarXmlPDF
    Private Sub FrmDescargarXmlPDF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()
        Catch ex As Exception
        End Try

        C1List1.Splits(0).DisplayColumns(0).Width = 100
        C1List1.Splits(0).DisplayColumns(1).Width = 100
        C1List1.Splits(0).DisplayColumns(2).Width = 150

    End Sub
    Private Sub FrmDescargarXmlPDF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnDoc_Click(sender As Object, e As EventArgs) Handles BtnDoc.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_DOC.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarDescargar_Click(sender As Object, e As ClickEventArgs) Handles BarDescargar.Click
        Dim XML As String = "", FILE_XML As String = "", CVE_DOC As String = "", PDF As String = "", Err As Boolean = False
        Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String, j As Integer = 0, RFC As String, rutaPDF As String
        Dim CTA_PORT1 As String = "", CTA_PORT2 As String = ""
        Dim CALLE_DESTINO As String, NUMEROEXTERIOR_DESTINO As String, COLONIA_DESTINO As String
        Dim LOCALIDAD_DESTINO As String, CODIGOPOSTAL_DESTINO As String, ESTADO_DESTINO As String
        Dim MUNICIPIO_DESTINO As String, ENVIAR_MAIL As String, CORREO_CLIENTE As String, NOMBRE_CLIENTE As String
        Dim RUTA_PDF As String, CVE_VIAJE As String


        If TRUTA_DOC.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione la ruta donde se descargaran el XML y PDF")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Select Case Var4
            Case "CARTA PORTE"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM CFDI_CFG"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                PassData6 = dr("CALLE") & ", Num. ext. " & dr("NUMEXT") & ", CP " & dr("CP")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Err = True
                    BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
        End Select
        If Err Then
            MsgBox("Problema detectado verifique las rutas por favor")
            Return
        End If

        For row As Integer = 0 To C1List1.ListCount - 1
            Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
            Dim cellValue2 As Object = C1List1.GetDisplayText(row, 1)
            RFC = C1List1.GetDisplayText(row, 2).ToString
            Try
                CVE_DOC = cellValue.ToString
                CVE_VIAJE = cellValue2.ToString
                Select Case Var4
                    Case "CARTA PORTE BUENO"

                        SQL = "SELECT ISNULL(XML,'') AS XML1 FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    XML = dr("XML1")
                                End If
                            End Using
                        End Using

                        If XML.Trim.Length > 0 Then
                            FILE_XML = TRUTA_DOC.Text & "\" & RFC & "-" & CVE_DOC & ".xml"
                            File.WriteAllText(FILE_XML, XML)

                            RUTA_FORMATOS = GET_RUTA_FORMATOS()

                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40" & Empresa & ".mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDI40.mrt"
                                If Not File.Exists(ARCHIVO_MRT) Then
                                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                    Exit For
                                End If
                            End If

                            RUTA_PDF = TRUTA_DOC.Text & "\" & CVE_DOC & ".pdf"

                            StiReport1.Load(ARCHIVO_MRT)
                            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                            StiReport1.Dictionary.Databases.Clear()
                            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
                            StiReport1.Compile()

                            Dim IMPORTE As Decimal = 0
                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT IMPORTE FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read Then
                                            IMPORTE = dr("IMPORTE")
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception

                            End Try

                            Dim entero As Integer = Int(IMPORTE)
                            Dim decimales As Double = IMPORTE - entero

                            Dim NUMTOLET As String
                            NUMTOLET = "** ( " + Num2Text(entero) + " PESOS " + Microsoft.VisualBasic.Right(CStr(Format(decimales, "0.00")), 2) + "/100 M.N.)**"

                            StiReport1("CVE_VIAJE") = CVE_VIAJE
                            StiReport1("CVE_DOC") = CVE_DOC
                            StiReport1("NUMTOLETRA") = NUMTOLET
                            StiReport1.ReportName = "Carta porte 4.0"
                            StiReport1.Render()
                            StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                            j += 1
                        End If
                    Case "PAGO"
                        SQL = "SELECT ISNULL(XML,'') AS XML1 FROM CFDI_COMPAGO WHERE CVE_DOC = '" & CVE_DOC & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    XML = dr("XML1")
                                End If
                            End Using
                        End Using

                        If XML.Trim.Length > 0 Then
                            FILE_XML = TRUTA_DOC.Text & "\" & RFC & "-" & CVE_DOC & ".xml"
                            File.WriteAllText(FILE_XML, XML)

                            RUTA_FORMATOS = GET_RUTA_FORMATOS()

                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDIPAGO.mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                Return
                            End If
                            RUTA_PDF = TRUTA_DOC.Text & "\" & CVE_DOC & ".pdf"

                            StiReport1.Load(ARCHIVO_MRT)
                            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                            StiReport1.Dictionary.Databases.Clear()
                            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
                            StiReport1.Compile()
                            StiReport1.Render()
                            StiReport1.Item("CVE_DOC") = CVE_DOC

                            StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                            j += 1
                        End If
                    Case "FACTURAS", "CARTA PORTE"

                        '░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░

                        SQL = "SELECT ISNULL(DOCUMENT,'') AS CP1, ISNULL(DOCUMENT2,'') AS CP2, 
                            ISNULL(XML,'') AS XML1 FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    XML = dr("XML1")
                                    CTA_PORT1 = dr("CP1")
                                    CTA_PORT2 = dr("CP2")
                                End If
                            End Using
                        End Using

                        CP_ORDEN_DE = "" : CP_EMBARQUE = "" : CP_RECOGER_EN = "" : CP_ENTREGAR_EN = "" : CP_TRACTOR = "" : CP_TANQUE1 = ""
                        CP_TANQUE2 = "" : CP_PLACAS_TRACTOR = "" : CP_PLACAS_TANQUE1 = "" : CP_PLACAS_TANQUE2 = ""
                        CP_POLIZARESPCIVIL = "" : CP_ASEGURARESPCIVIL = "" : CP_NUM_PROV = "" : CP_PEDIMENTO = "" : CP_OBSER_CFDI = ""


                        If Var4 = "CARTA PORTE" Then

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
                                    End If
                                End Using
                            End Using
                        End If

                        If Var4 = "CARTA PORTE" Then
                            FILE_XML = TRUTA_DOC.Text & "\" & CTA_PORT1 & "-" & CVE_DOC & ".xml"
                            rutaPDF = TRUTA_DOC.Text & "\" & CTA_PORT1 & "-" & CVE_DOC & ".pdf"
                        Else
                            FILE_XML = TRUTA_DOC.Text & "\" & CVE_DOC & ".xml"
                            rutaPDF = TRUTA_DOC.Text & "\" & CVE_DOC & ".pdf"
                        End If

                        File.WriteAllText(FILE_XML, XML)
                        CreaPDF.Generar(FILE_XML, rutaPDF, Application.StartupPath & "\logo.jpg", False)
                        j += 1

                        '░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
                    Case "CARTA PORTE TRASLADO"
                        SQL = "SELECT ISNULL(XML,'') AS XML1 FROM CFDI WHERE FACTURA = '" & CVE_DOC & "'"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    XML = dr("XML1")
                                End If
                            End Using
                        End Using

                        If XML.Trim.Length > 0 Then
                            FILE_XML = TRUTA_DOC.Text & "\" & RFC & "-" & CVE_DOC & ".xml"
                            File.WriteAllText(FILE_XML, XML)

                            RUTA_FORMATOS = GET_RUTA_FORMATOS()

                            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT" & Empresa & ".mrt"
                            If Not File.Exists(ARCHIVO_MRT) Then
                                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportCFDICPT.mrt"
                                If Not File.Exists(ARCHIVO_MRT) Then
                                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                                    Return
                                End If
                            End If

                            RUTA_PDF = TRUTA_DOC.Text & "\" & RFC & "-" & CVE_DOC & ".pdf"

                            StiReport1.Load(ARCHIVO_MRT)
                            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                                           Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
                            StiReport1.Dictionary.Databases.Clear()
                            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))
                            StiReport1.Compile()
                            StiReport1.Item("CVE_DOC") = CVE_DOC

                            StiReport1.Render()
                            StiReport1.ExportDocument(StiExportFormat.Pdf, RUTA_PDF)
                            j += 1
                        End If
                End Select
            Catch ex As Exception
                BITACORACFDI("470. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        Me.Cursor = Cursors.Default

        MsgBox("Descarga completa ",, "Archivos descargados " & j * 2)

        Process.Start(TRUTA_DOC.Text)

        Me.Close()

    End Sub
End Class
