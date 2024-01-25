Imports System.Security.Cryptography.X509Certificates

Imports System.IO
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.Xml

Public Class FrmConfiguracionCFDI
    Private Sub FrmConfiguracionCFDI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SERIE_CP As String = ""
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            Me.KeyPreview = True

            cboVerCCP.Items.Clear()
            cboVerCCP.Items.Add("2.0")
            cboVerCCP.Items.Add("3.0")

            TFTOFACTURA.Value = ""
            TFTODEV.Value = ""
            TFTOCOMPPAGO.Value = ""
            TREFERENCIA.Value = ""
            TFTOFACTURA.Tag = ""
            TFTODEV.Tag = ""
            TFTOCOMPPAGO.Tag = ""

            BtnPermSCT.FlatStyle = FlatStyle.Flat
            BtnPermSCT.FlatAppearance.BorderSize = 0

            BtnCP.FlatStyle = FlatStyle.Flat
            BtnCP.FlatAppearance.BorderSize = 0
            BtnEstado.FlatStyle = FlatStyle.Flat
            BtnEstado.FlatAppearance.BorderSize = 0
            BtnPais.FlatStyle = FlatStyle.Flat
            BtnPais.FlatAppearance.BorderSize = 0
            BtnMunicipio.FlatStyle = FlatStyle.Flat
            BtnMunicipio.FlatStyle = FlatStyle.Flat
            BtnLocalidad.FlatStyle = FlatStyle.Flat
            BtnLocalidad.FlatStyle = FlatStyle.Flat

            BtnColonia.FlatStyle = FlatStyle.Flat
            BtnColonia.FlatAppearance.BorderSize = 0
            BtnCP.FlatStyle = FlatStyle.Flat
            BtnCP.FlatAppearance.BorderSize = 0

            Tab1.Dock = DockStyle.Fill


            SQL = "SELECT D.USUARIO, D.PASS, D.FOLIO, D.FILE_CER, D.FILE_PFX, D.PASS_PFX, D.EMISOR_RFC, D.EMISOR_RAZON_SOCIAL, D.EMISOR_REGIMEN_FISCAL,
                D.EMISOR_LUGAR_EXPEDICION, D.RUTA_XML_TIMBRADO, D.RUTA_XML_NOTIMBRADO, CALLE, NUMEXT, NUMINT, COLONIA, LOCALIDAD, MUNICIPIO, CP, ESTADO, 
                PAIS, CORREO1, CORREO2, TIMBRADO_DEMO, PERMSCT, NUMPERMISOSCT, POLIZAMEDAMBIENTE, ASEGURAMEDAMBIENTE, SERIE_CP, RUTA_XML_TIMBRADO_CONPRECIOS, 
                RUTA_XML_NOTIMBRADO_CONPRECIOS, FTOFACTURA, FTODEV, FTOCOMPPAGO, COLONIA_NOSAT, LOCALIDAD_NOSAT, MUNICIPIO_NOSAT, ISNULL(REFERENCIA,'') AS REFER,
                ISNULL(ADDENDA_CE,0) AS ADD_CE, VerCCP
                FROM CFDI_CFG D"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    'USUARIO PAC DIGIBOX
                    TUsuario.Text = dr.ReadNullAsEmptyString("USUARIO").ToString
                    'CONTRASENA PAC DIGIBOX
                    TPass.Text = Desencriptar(dr.ReadNullAsEmptyString("PASS").ToString)
                    'CONTRASENA SELLO SAT SAT ENDEJO   PASS_PFX
                    TPASS_PFX.Text = Desencriptar(dr.ReadNullAsEmptyString("PASS_PFX").ToString)  'contrasena del certificado

                Catch ex As Exception
                    Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                'TFolio.Text = dr("FOLIO").ToString
                TFILE_CER.Text = dr("FILE_CER").ToString '.CER
                TFILE_PFX.Text = dr("FILE_PFX").ToString '.KYE

                TEMISOR_RFC.Value = dr("EMISOR_RFC").ToString
                TEMISOR_RAZON_SOCIAL.Value = dr("EMISOR_RAZON_SOCIAL").ToString
                TCALLE.Value = dr.ReadNullAsEmptyString("CALLE")
                TNUMEXT.Value = dr.ReadNullAsEmptyString("NUMEXT")
                TNUMINT.Value = dr.ReadNullAsEmptyString("NUMINT")

                TCOLONIA_SAT.Value = dr.ReadNullAsEmptyString("COLONIA")
                TLOCALIDAD_SAT.Value = dr.ReadNullAsEmptyString("LOCALIDAD")
                TMUNICIPIO_SAT.Value = dr.ReadNullAsEmptyString("MUNICIPIO")

                TCOLONIA.Text = dr.ReadNullAsEmptyString("COLONIA_NOSAT")
                TLOCALIDAD.Text = dr.ReadNullAsEmptyString("LOCALIDAD_NOSAT")
                TMUNICIPIO.Text = dr.ReadNullAsEmptyString("MUNICIPIO_NOSAT")

                TCP.Value = dr.ReadNullAsEmptyString("CP")
                TESTADO.Value = dr.ReadNullAsEmptyString("ESTADO")

                TPAIS.Value = dr.ReadNullAsEmptyString("PAIS")
                TCorreo1.Text = dr.ReadNullAsEmptyString("CORREO1")
                TCorreo2.Text = dr.ReadNullAsEmptyString("CORREO2")

                cboVerCCP.SelectedText = dr.ReadNullAsEmptyString("VerCCP")

                If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 1 Then
                    ChTimbradoDemo.Checked = True
                Else
                    ChTimbradoDemo.Checked = False
                End If

                TEMISOR_REGIMEN_FISCAL.Value = dr("EMISOR_REGIMEN_FISCAL").ToString
                TEMISOR_LUGAR_EXPEDICION.Value = dr("EMISOR_LUGAR_EXPEDICION").ToString

                TRUTA_XML_TIMBRADO.Text = dr("RUTA_XML_TIMBRADO").ToString
                TRUTA_XML_NOTIMBRADO.Text = dr("RUTA_XML_NOTIMBRADO").ToString

                TRUTA_XML_TIMBRADO_CONPRECIOS.Text = dr("RUTA_XML_TIMBRADO_CONPRECIOS").ToString
                TRUTA_XML_NOTIMBRADO_CONPRECIOS.Text = dr("RUTA_XML_NOTIMBRADO_CONPRECIOS").ToString

                TPermSCT.Text = dr.ReadNullAsEmptyString("PERMSCT")
                TNumPermisoSCT.Text = dr.ReadNullAsEmptyString("NUMPERMISOSCT")

                TPolizaMedAmbiente.Text = dr.ReadNullAsEmptyString("POLIZAMEDAMBIENTE")
                TAseguraMedAmbiente.Text = dr.ReadNullAsEmptyString("ASEGURAMEDAMBIENTE")
                SERIE_CP = dr.ReadNullAsEmptyString("SERIE_CP")
                Try
                    TFTOFACTURA.Value = dr.ReadNullAsEmptyString("FTOFACTURA")
                    TFTODEV.Value = dr.ReadNullAsEmptyString("FTODEV")
                    TFTOCOMPPAGO.Value = dr.ReadNullAsEmptyString("FTOCOMPPAGO")

                    TREFERENCIA.Value = dr("REFER")

                    If dr("ADD_CE") = 1 Then
                        ChAddendaCE.CheckAlign = True
                    Else
                        ChAddendaCE.CheckAlign = False
                    End If

                Catch ex As Exception
                End Try
            Else
                TUsuario.Text = ""
                TPass.Text = ""
                'TFolio.Value = 0
                TFILE_CER.Text = ""
                TFILE_PFX.Text = ""
                TPASS_PFX.Text = ""
                TEMISOR_RFC.Text = ""
                TEMISOR_RAZON_SOCIAL.Text = ""
                TEMISOR_REGIMEN_FISCAL.Text = ""
                TEMISOR_LUGAR_EXPEDICION.Text = ""
                TRUTA_XML_TIMBRADO.Text = ""
                TRUTA_XML_NOTIMBRADO.Text = ""
                TPolizaMedAmbiente.Text = ""
                TAseguraMedAmbiente.Text = ""
            End If
            dr.Close()
            TUsuario.Select()
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA, TIP_DOC FROM FOLIOSF" & Empresa
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        If dr("TIP_DOC") = "F" Then CboSerieCP.Items.Add(dr("LETRA"))
                    Loop
                End Using
            End Using

            For k = 0 To CboSerieCP.Items.Count - 1
                If CboSerieCP.Items(k) = SERIE_CP Then
                    CboSerieCP.SelectedIndex = k
                End If
            Next

            If TFILE_CER.Text.Trim.Length > 0 Then

                ValidarCertificadoSAT(TFILE_CER.Text, TPASS_PFX.Text)
            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmConfiguracionCFDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Parámetros factura electrónica")
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        SQL = "IF EXISTS (SELECT USUARIO FROM CFDI_CFG)
            UPDATE CFDI_CFG SET USUARIO = @USUARIO, PASS = @PASS, FOLIO = @FOLIO, FILE_CER = @FILE_CER, FILE_PFX = @FILE_PFX, PASS_PFX = @PASS_PFX,
            EMISOR_RFC = @EMISOR_RFC, EMISOR_RAZON_SOCIAL = @EMISOR_RAZON_SOCIAL, EMISOR_REGIMEN_FISCAL = @EMISOR_REGIMEN_FISCAL, SERIE_CP = @SERIE_CP,
            EMISOR_LUGAR_EXPEDICION = @EMISOR_LUGAR_EXPEDICION, CALLE = @CALLE, CP = @CP, NUMEXT = @NUMEXT, NUMINT = @NUMINT, LOCALIDAD = @LOCALIDAD, 
            MUNICIPIO = @MUNICIPIO, ESTADO = @ESTADO, COLONIA = @COLONIA, PAIS = @PAIS, CORREO1 = @CORREO1, CORREO2 = @CORREO2, 
            TIMBRADO_DEMO = @TIMBRADO_DEMO, PERMSCT = @PERMSCT, NUMPERMISOSCT = @NUMPERMISOSCT, POLIZAMEDAMBIENTE = @POLIZAMEDAMBIENTE, 
            ASEGURAMEDAMBIENTE = @ASEGURAMEDAMBIENTE, RUTA_XML_TIMBRADO = @RUTA_XML_TIMBRADO, RUTA_XML_NOTIMBRADO = @RUTA_XML_NOTIMBRADO, 
            RUTA_XML_TIMBRADO_CONPRECIOS = @RUTA_XML_TIMBRADO_CONPRECIOS, RUTA_XML_NOTIMBRADO_CONPRECIOS = @RUTA_XML_NOTIMBRADO_CONPRECIOS,
            FTOFACTURA = @FTOFACTURA, FTODEV = @FTODEV, FTOCOMPPAGO = @FTOCOMPPAGO, COLONIA_NOSAT = @COLONIA_NOSAT, LOCALIDAD_NOSAT = @LOCALIDAD_NOSAT, 
            MUNICIPIO_NOSAT = @MUNICIPIO_NOSAT, REFERENCIA = @REFERENCIA, ADDENDA_CE = @ADDENDA_CE, VerCCP = @VerCCP
            ELSE
            INSERT INTO CFDI_CFG (USUARIO, PASS, FOLIO, FILE_CER, FILE_PFX, PASS_PFX, EMISOR_RFC, EMISOR_RAZON_SOCIAL, EMISOR_REGIMEN_FISCAL,
            EMISOR_LUGAR_EXPEDICION, CALLE, CP, NUMEXT, NUMINT, LOCALIDAD, MUNICIPIO, ESTADO, COLONIA, PAIS, CORREO1, CORREO2, TIMBRADO_DEMO, PERMSCT, 
            NUMPERMISOSCT, POLIZAMEDAMBIENTE, ASEGURAMEDAMBIENTE, SERIE_CP, RUTA_XML_TIMBRADO, RUTA_XML_NOTIMBRADO, RUTA_XML_TIMBRADO_CONPRECIOS,
            RUTA_XML_NOTIMBRADO_CONPRECIOS, FTOFACTURA, FTODEV, FTOCOMPPAGO, COLONIA_NOSAT, LOCALIDAD_NOSAT, MUNICIPIO_NOSAT, REFERENCIA, ADDENDA_CE, VerCCP)
            VALUES 
            (@USUARIO, @PASS, @FOLIO, @FILE_CER, @FILE_PFX, @PASS_PFX, @EMISOR_RFC, @EMISOR_RAZON_SOCIAL, @EMISOR_REGIMEN_FISCAL, @EMISOR_LUGAR_EXPEDICION, 
            @CALLE, @CP, @NUMEXT, @NUMINT, @LOCALIDAD, @MUNICIPIO, @ESTADO, @COLONIA, @PAIS, @CORREO1, @CORREO2, @TIMBRADO_DEMO, @PERMSCT, @NUMPERMISOSCT, 
            @SERIE_CP, @POLIZAMEDAMBIENTE, @ASEGURAMEDAMBIENTE, @RUTA_XML_TIMBRADO, @RUTA_XML_NOTIMBRADO, @RUTA_XML_TIMBRADO_CONPRECIOS, 
            @RUTA_XML_NOTIMBRADO_CONPRECIOS, @FTOFACTURA, @FTODEV, @FTOCOMPPAGO, @COLONIA_NOSAT, @LOCALIDAD_NOSAT, @MUNICIPIO_NOSAT, @REFERENCIA, @ADDENDA_CE, @VerCCP)"

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE,
            .CommandText = SQL
        }
        Try
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = TUsuario.Text
            cmd.Parameters.Add("@PASS", SqlDbType.VarChar).Value = Encriptar(TPass.Text)
            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = 0
            cmd.Parameters.Add("@FILE_CER", SqlDbType.VarChar).Value = TFILE_CER.Text
            cmd.Parameters.Add("@FILE_PFX", SqlDbType.VarChar).Value = TFILE_PFX.Text
            cmd.Parameters.Add("@PASS_PFX", SqlDbType.VarChar).Value = Encriptar(TPASS_PFX.Text)
            cmd.Parameters.Add("@EMISOR_RFC", SqlDbType.VarChar).Value = TEMISOR_RFC.Text
            cmd.Parameters.Add("@EMISOR_RAZON_SOCIAL", SqlDbType.VarChar).Value = TEMISOR_RAZON_SOCIAL.Text
            cmd.Parameters.Add("@EMISOR_REGIMEN_FISCAL", SqlDbType.VarChar).Value = TEMISOR_REGIMEN_FISCAL.Text
            cmd.Parameters.Add("@EMISOR_LUGAR_EXPEDICION", SqlDbType.VarChar).Value = TEMISOR_LUGAR_EXPEDICION.Text
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = TCP.Text
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNUMEXT.Text
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNUMINT.Text

            cmd.Parameters.Add("@COLONIA_NOSAT", SqlDbType.VarChar).Value = TCOLONIA.Text
            cmd.Parameters.Add("@LOCALIDAD_NOSAT", SqlDbType.VarChar).Value = TLOCALIDAD.Text
            cmd.Parameters.Add("@MUNICIPIO_NOSAT", SqlDbType.VarChar).Value = TMUNICIPIO.Text

            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA_SAT.Text
            cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD_SAT.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO_SAT.Text
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TESTADO.Text
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text
            cmd.Parameters.Add("@RUTA_XML_TIMBRADO", SqlDbType.VarChar).Value = TRUTA_XML_TIMBRADO.Text
            cmd.Parameters.Add("@RUTA_XML_NOTIMBRADO", SqlDbType.VarChar).Value = TRUTA_XML_NOTIMBRADO.Text
            cmd.Parameters.Add("@CORREO1", SqlDbType.VarChar).Value = TCorreo1.Text
            cmd.Parameters.Add("@CORREO2", SqlDbType.VarChar).Value = TCorreo2.Text
            cmd.Parameters.Add("@TIMBRADO_DEMO", SqlDbType.VarChar).Value = IIf(ChTimbradoDemo.Checked, 1, 0)
            cmd.Parameters.Add("@PERMSCT", SqlDbType.VarChar).Value = TPermSCT.Text
            cmd.Parameters.Add("@NUMPERMISOSCT", SqlDbType.VarChar).Value = TNumPermisoSCT.Text
            cmd.Parameters.Add("@POLIZAMEDAMBIENTE", SqlDbType.VarChar).Value = TPolizaMedAmbiente.Text
            cmd.Parameters.Add("@ASEGURAMEDAMBIENTE", SqlDbType.VarChar).Value = TAseguraMedAmbiente.Text
            cmd.Parameters.Add("@SERIE_CP", SqlDbType.VarChar).Value = CboSerieCP.Text
            cmd.Parameters.Add("@RUTA_XML_TIMBRADO_CONPRECIOS", SqlDbType.VarChar).Value = TRUTA_XML_TIMBRADO_CONPRECIOS.Text
            cmd.Parameters.Add("@RUTA_XML_NOTIMBRADO_CONPRECIOS", SqlDbType.VarChar).Value = TRUTA_XML_NOTIMBRADO_CONPRECIOS.Text
            cmd.Parameters.Add("@FTOFACTURA", SqlDbType.VarChar).Value = TFTOFACTURA.Text
            cmd.Parameters.Add("@FTODEV", SqlDbType.VarChar).Value = TFTODEV.Text
            cmd.Parameters.Add("@FTOCOMPPAGO", SqlDbType.VarChar).Value = TFTOCOMPPAGO.Text
            cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = TREFERENCIA.Text
            cmd.Parameters.Add("@ADDENDA_CE", SqlDbType.SmallInt).Value = IIf(ChAddendaCE.Checked, 1, 0)
            cmd.Parameters.Add("@VerCCP", SqlDbType.VarChar).Value = cboVerCCP.Text

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    If TFTOFACTURA.Text.Trim.Length > 0 And TFTOFACTURA.Tag.ToString.Trim.Length > 0 Then
                        Dim rutaCg As String = GET_RUTA_FORMATOS()
                        Dim copyToDir = Path.GetDirectoryName(TFTOFACTURA.Tag)

                        If rutaCg <> copyToDir Then
                            Try
                                If File.Exists(TFTOFACTURA.Tag) Then
                                    File.Copy(TFTOFACTURA.Tag, rutaCg & "\" & TFTOFACTURA.Text, True)
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End If
                        Try
                            SQL = "IF NOT EXISTS (SELECT NOMBRE FROM GCFORMATOS WHERE ARCHIVO = '" & TFTOFACTURA.Text & "') 
                                INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID) VALUES (" & GET_MAX("GCFORMATOS", "CVE_REP") &
                                ",'A','Formato CFDI FACTURA electronica','Formato CFDI FACTURA','" & TFTOFACTURA.Text & "', GETDATE(), NEWID())"
                            If EXECUTE_QUERY_NET(SQL) Then
                            End If
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If

                    If TFTODEV.Text.Trim.Length > 0 Then
                        Dim rutaCg As String = GET_RUTA_FORMATOS()
                        Dim copyToDir = Path.GetDirectoryName(TFTODEV.Tag)

                        If rutaCg <> copyToDir Then
                            Try
                                If File.Exists(TFTODEV.Tag) Then
                                    File.Copy(TFTODEV.Tag, rutaCg & "\" & TFTODEV.Text, True)
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End If
                        Try
                            SQL = "IF NOT EXISTS (SELECT NOMBRE FROM GCFORMATOS WHERE ARCHIVO = '" & TFTODEV.Text & "') 
                                INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID) VALUES (" & GET_MAX("GCFORMATOS", "CVE_REP") &
                                ",'A','Formato CFDI nota de credito','Formato CFDI nota de credito','" & TFTODEV.Text & "', GETDATE(), NEWID())"
                            If EXECUTE_QUERY_NET(SQL) Then
                            End If
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If

                    If TFTOCOMPPAGO.Text.Trim.Length > 0 Then
                        Dim rutaCg As String = GET_RUTA_FORMATOS()
                        Dim copyToDir = Path.GetDirectoryName(TFTOCOMPPAGO.Tag)

                        If rutaCg <> copyToDir Then
                            Try
                                If File.Exists(TFTOCOMPPAGO.Tag) Then
                                    File.Copy(TFTOCOMPPAGO.Tag, rutaCg & "\" & TFTOCOMPPAGO.Text, True)
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End If
                        Try
                            SQL = "IF NOT EXISTS (SELECT NOMBRE FROM GCFORMATOS WHERE ARCHIVO = '" & TFTOCOMPPAGO.Text & "') 
                                INSERT INTO GCFORMATOS (CVE_REP, STATUS, NOMBRE, DESCR, ARCHIVO, FECHAELAB, UUID) VALUES (" & GET_MAX("GCFORMATOS", "CVE_REP") &
                                ",'A','Formato CFDI complemento de pago','Formato CFDI complemento de pago','" & TFTOCOMPPAGO.Text & "', GETDATE(), NEWID())"
                            If EXECUTE_QUERY_NET(SQL) Then
                            End If
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If

                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnFileCer_Click(sender As Object, e As EventArgs) Handles BtnFileCer.Click
        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        OpenFileDialog1.Filter = "Certificado|*.cer"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TFILE_CER.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub BtnFilePFX_Click(sender As Object, e As EventArgs) Handles BtnFilePFX.Click
        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        OpenFileDialog1.Filter = "Certificado|*.key"
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TFILE_PFX.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Private Sub BtnRutaTimbrados_Click(sender As Object, e As EventArgs) Handles BtnRutaTimbrados.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_XML_TIMBRADO.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub BtnRutaNoTimbrados_Click(sender As Object, e As EventArgs) Handles BtnRutaNoTimbrados.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_XML_NOTIMBRADO.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub FrmConfiguracionCFDI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BtnPermSCT_Click(sender As Object, e As EventArgs) Handles BtnPermSCT.Click
        Try
            Var2 = "PermSCT"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPermSCT.Text = Var4
                LTPermSCT.Text = Var5
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPermSCT_Validated(sender As Object, e As EventArgs) Handles TPermSCT.Validated
        Try
            If TPermSCT.Text.Trim.Length > 0 Then
                Select Case TPermSCT.Text
                    Case "TPAF01"
                        LTPermSCT.Text = "Autotransporte Federal de carga general."
                    Case "TPAF02"
                        LTPermSCT.Text = "Transporte privado de carga."
                    Case "TPAF03"
                        LTPermSCT.Text = "Autotransporte Federal de Carga Especializada de materiales y residuos peligrosos."
                    Case "TPXX00"
                        LTPermSCT.Text = "Permiso no comtenplado en el catálogo."
                    Case Else
                        MsgBox("Permiso inexistente")
                        LTPermSCT.Text = ""
                End Select
            End If
        Catch ex As Exception
            Bitacora("1430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRutaTimbradosConPrec_Click(sender As Object, e As EventArgs) Handles BtnRutaTimbradosConPrec.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_XML_TIMBRADO_CONPRECIOS.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub BtnRutaNoTimbradosConPrec_Click(sender As Object, e As EventArgs) Handles BtnRutaNoTimbradosConPrec.Click
        If (FolderBrowserDialog1.ShowDialog() = DialogResult.OK) Then
            TRUTA_XML_NOTIMBRADO_CONPRECIOS.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub BtnFTOFactura_Click(sender As Object, e As EventArgs) Handles BtnFTOFactura.Click
        Try
            Dim rutaCg As String = GET_RUTA_FORMATOS()
            If rutaCg.Trim.Length = 0 Then
                rutaCg = Application.StartupPath & "\REPORTES"
            End If

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaCg
            OpenFileDialog1.Filter = "Reporte mrt|*.mrt"
            If TFTOFACTURA.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = TFTOFACTURA.Text
            End If

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)

                TFTOFACTURA.Text = file
                TFTOFACTURA.Tag = OpenFileDialog1.FileName
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFTODev_Click(sender As Object, e As EventArgs) Handles BtnFTODev.Click
        Try
            Dim rutaCg As String = GET_RUTA_FORMATOS()
            If rutaCg.Trim.Length = 0 Then
                rutaCg = Application.StartupPath & "\REPORTES"
            End If

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaCg
            OpenFileDialog1.Filter = "Reporte mrt|*.mrt"
            If TFTODEV.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = TFTODEV.Text
            End If

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)

                TFTODEV.Text = file
                TFTODEV.Tag = OpenFileDialog1.FileName
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFTOCompPago_Click(sender As Object, e As EventArgs) Handles BtnFTOCompPago.Click
        Try
            Dim rutaCg As String = GET_RUTA_FORMATOS()
            If rutaCg.Trim.Length = 0 Then
                rutaCg = Application.StartupPath & "\REPORTES"
            End If

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaCg
            OpenFileDialog1.Filter = "Reporte mrt|*.mrt"
            If TFTOCOMPPAGO.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = TFTOCOMPPAGO.Text
            End If

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)

                TFTOCOMPPAGO.Text = file
                TFTOCOMPPAGO.Tag = OpenFileDialog1.FileName
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TEMISOR_REGIMEN_FISCAL_TextChanged(sender As Object, e As EventArgs) Handles TEMISOR_REGIMEN_FISCAL.TextChanged

    End Sub
    Private Sub BtnMunicipio_Click(sender As Object, e As EventArgs) Handles BtnMunicipio.Click
        Try
            Prosec = "Municipio"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TMUNICIPIO.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TMUNICIPIO_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TMUNICIPIO_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMunicipio_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMUNICIPIO_SAT_Validated(sender As Object, e As EventArgs) Handles TMUNICIPIO_SAT.Validated
        Dim doc As New XmlDocument()
        Try
            If TMUNICIPIO.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TMUNICIPIO.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLocalidad_Click(sender As Object, e As EventArgs) Handles BtnLocalidad.Click
        Try
            Prosec = "Localidad"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TLOCALIDAD.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLOCALIDAD_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TLOCALIDAD_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLocalidad_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TLOCALIDAD_SAT_Validated(sender As Object, e As EventArgs) Handles TLOCALIDAD_SAT.Validated
        Dim doc As New XmlDocument()
        Try
            If TLOCALIDAD.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TLOCALIDAD.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEstado_Click(sender As Object, e As EventArgs) Handles BtnEstado.Click
        Try
            Prosec = "Estado"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TESTADO.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TESTADO_KeyDown(sender As Object, e As KeyEventArgs) Handles TESTADO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEstado_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TESTADO_Validated(sender As Object, e As EventArgs) Handles TESTADO.Validated
        Dim doc As New XmlDocument()

        Try
            If TLOCALIDAD.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TESTADO.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPais_Click(sender As Object, e As EventArgs) Handles BtnPais.Click
        Try
            Prosec = "Pais"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TPAIS.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPAIS_KeyDown(sender As Object, e As KeyEventArgs) Handles TPAIS.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPais_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TPAIS_Validated(sender As Object, e As EventArgs) Handles TPAIS.Validated
        Dim doc As New XmlDocument()

        Try
            If TLOCALIDAD.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Pais='" & TPAIS.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Localidad inexistente, verifique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCP_Click(sender As Object, e As EventArgs) Handles BtnCP.Click
        Try
            Prosec = "CP"
            Var4 = ""
            Var7 = TLOCALIDAD.Text
            Var8 = TMUNICIPIO.Text
            Var9 = TESTADO.Text

            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCP.Text = Var4
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCP_KeyDown(sender As Object, e As KeyEventArgs) Handles TCP.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCP_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCP_Validated(sender As Object, e As EventArgs) Handles TCP.Validated
        Dim doc As New XmlDocument()
        Dim CP As String, x As Integer = 0

        Try
            If TCP.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Codigo postal inexistente, verifique por favor")
                    Else
                        For Each node As XmlNode In nodeList
                            CP = node.Attributes("c_CodigoPostal").Value
                            If CP = TCP.Text Then
                                x += 1
                            End If
                        Next
                    End If
                    If x = 0 Then
                        MsgBox("Código postal no corresponde a la localidad y municipio capturados, verfique por favor")
                    End If
                Else
                    MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml inexistente, verifique por favor")
                End If
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnColonia_Click(sender As Object, e As EventArgs) Handles BtnColonia.Click
        Try
            Prosec = "COLONIAS"
            Var4 = ""
            Var7 = TCP.Text
            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCOLONIA.Text = Var4
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCOLONIA_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCOLONIA_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnColonia_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub ValidarCertificadoSAT(FCER As String, FKEY As String)
        Try
            Dim Cert As New X509Certificate2(FCER, FKEY)

            If Cert.NotAfter > Date.Now Then
                'Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - VÁLIDO");
                LtVencCer.Text = Cert.NotAfter.ToString("dd-MM-yyyy HH:mm:sszzz") & " - VÁLIDO"
            Else
                'Console.WriteLine(cert.NotAfter.ToString("dd - MM - yyyy HH: mm:sszzz") + " - INVÁLIDO");
                LtVencCer.Text = Cert.NotAfter.ToString("dd-MM-yyyy HH:mm:sszzz") & " - INVÁLIDO"
                'Console.Read();
            End If

        Catch ex As Exception
            If PASS_GRUPOCE = "BUS" Then
                MessageBox.Show(ex.Message)
            End If
        End Try
    End Sub

End Class
