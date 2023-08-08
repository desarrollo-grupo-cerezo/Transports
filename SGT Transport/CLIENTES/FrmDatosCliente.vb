Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.Xml

Public Class FrmDatosCliente
    Private CLIE_NEW As Boolean
    Private Sub FrmDatosCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        BtnRegFisc.FlatStyle = FlatStyle.Flat
        BtnRegFisc.FlatAppearance.BorderSize = 0
        BtnUSoCFDI.FlatStyle = FlatStyle.Flat
        BtnUSoCFDI.FlatAppearance.BorderSize = 0
        BtnFormaPagoSAT.FlatStyle = FlatStyle.Flat
        BtnFormaPagoSAT.FlatAppearance.BorderSize = 0
        BtnZona.FlatStyle = FlatStyle.Flat
        BtnZona.FlatAppearance.BorderSize = 0

        CLIE_NEW = False

        Select Case Var1
            Case "Nuevo"
                CLIE_NEW = True
                Dim CLAVE As String

                CLAVE = GET_MAX_TRY("CLIE" & Empresa, "CLAVE")
                CLAVE = Space(10 - CLAVE.Length) & CLAVE.Trim
                TCLAVE.Text = CLAVE
                TCLAVE.Enabled = False
                TNOMBRE.Focus()
            Case "Edit"
                DESPLEGAR_CLIENTE()
                TCLAVE.Enabled = False
                TNOMBRE.Focus()
            Case "Consulta"
                BarGrabar.Visible = False
                DESPLEGAR_CLIENTE()
                SET_ALL_CONTROL_READ_AND_ENABLED(Me)
        End Select
    End Sub

    Private Sub FrmDatosCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Sub DESPLEGAR_CLIENTE()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim cmd2 As New SqlCommand
            Dim Exist As Boolean
            Exist = False
            TCVE_OBS.Tag = ""

            cmd.Connection = cnSAE
            SQL = "SELECT I.CLAVE, I.STATUS, I.NOMBRE, I.RFC, I.CALLE, I.NUMINT, I.NUMEXT, I.CRUZAMIENTOS, I.CRUZAMIENTOS2, I.COLONIA, I.CODIGO,
                I.LOCALIDAD, I.MUNICIPIO, I.ESTADO, I.PAIS, I.NACIONALIDAD, I.REFERDIR, I.TELEFONO, I.CLASIFIC, I.FAX, I.PAG_WEB, I.CURP,
                I.CVE_ZONA, I.IMPRIR, I.MAIL, I.NIVELSEC, I.ENVIOSILEN, I.EMAILPRED, I.DIAREV, I.DIAPAGO, I.CON_CREDITO, I.DIASCRED, I.LIMCRED,
                I.SALDO, I.LISTA_PREC, I.CVE_BITA, I.ULT_PAGOD, I.ULT_PAGOM, I.ULT_PAGOF, I.DESCUENTO, I.ULT_VENTAD, I.ULT_COMPM, I.FCH_ULTCOM,
                I.VENTAS, I.CVE_VEND, ISNULL(I.CVE_OBS,'') AS CVEOBS, I.TIPO_EMPRESA, I.MATRIZ, I.CALLE_ENVIO, I.NUMINT_ENVIO, I.NUMEXT_ENVIO,
                I.CRUZAMIENTOS_ENVIO, I.CRUZAMIENTOS_ENVIO2, I.COLONIA_ENVIO, I.LOCALIDAD_ENVIO, I.MUNICIPIO_ENVIO, I.ESTADO_ENVIO,
                I.PAIS_ENVIO, I.CODIGO_ENVIO, I.CVE_ZONA_ENVIO, I.REFERENCIA_ENVIO, I.CUENTA_CONTABLE, REG_FISC,
                I.METODODEPAGO, I.NUMCTAPAGO, I.MODELO, I.USO_CFDI, I.CVE_PAIS_SAT, I.NUMIDREGFISCAL, I.FORMADEPAGOSAT,
                ISNULL(OB.STR_OBS,'') AS OBSTR
                FROM CLIE" & Empresa & " I
                LEFT Join OCLI" & Empresa & " OB ON OB.CVE_OBS = I.CVE_OBS
                WHERE CLAVE = '" & Var2 & "' AND I.STATUS = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Exist = True

                TCLAVE.Text = dr("CLAVE")
                Try
                    TNOMBRE.Text = IIf(IsDBNull(dr("NOMBRE")), "", dr("NOMBRE"))
                    TRFC.Text = IIf(IsDBNull(dr("RFC")), "", dr("RFC"))
                    TCALLE.Text = IIf(IsDBNull(dr("CALLE")), "", dr("CALLE"))
                    TNumInt.Text = IIf(IsDBNull(dr("NUMINT")), "", dr("NUMINT"))
                    TNumExt.Text = IIf(IsDBNull(dr("NUMEXT")), "", dr("NUMEXT"))
                    TCRUZAMIENTOS.Text = IIf(IsDBNull(dr("CRUZAMIENTOS")), "", dr("CRUZAMIENTOS"))
                    TCRUZAMIENTOS2.Text = IIf(IsDBNull(dr("CRUZAMIENTOS2")), "", dr("CRUZAMIENTOS2"))
                    TCOLONIA.Text = IIf(IsDBNull(dr("COLONIA")), "", dr("COLONIA"))
                    TREGIMEN_FISCAL.Text = dr.ReadNullAsEmptyString("REG_FISC")
                    TUSO_CFDI.Text = dr.ReadNullAsEmptyString("USO_CFDI")
                    TFORMADEPAGOSAT.Text = dr.ReadNullAsEmptyString("FORMADEPAGOSAT")
                    TCORREO.Text = dr.ReadNullAsEmptyString("EMAILPRED")

                Catch ex As Exception
                    MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TCODIGO.Text = IIf(IsDBNull(dr("CODIGO")), "", dr("CODIGO"))
                    TLOCALIDAD.Text = IIf(IsDBNull(dr("LOCALIDAD")), "", dr("LOCALIDAD"))
                    TMunicipio.Text = IIf(IsDBNull(dr("MUNICIPIO")), "", dr("MUNICIPIO"))
                    TEstado.Text = IIf(IsDBNull(dr("ESTADO")), "", dr("ESTADO"))
                    TPais.Text = IIf(IsDBNull(dr("PAIS")), "", dr("PAIS"))
                    'LtPais.Text = BUSCA_CAT("Pais", TPais.Text)

                    TREFERDIR.Text = dr.ReadNullAsEmptyString("REFERDIR")
                    TCVE_OBS.Text = dr("OBSTR")
                    TCVE_OBS.Tag = dr("CVEOBS")
                Catch ex As Exception
                    MsgBox("11. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("11. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                TCURP.Text = IIf(IsDBNull(dr("CURP")), "", dr("CURP"))
                TCVE_ZONA.Text = IIf(IsDBNull(dr("CVE_ZONA")), "", dr("CVE_ZONA"))
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAceptar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim cmd As New SqlCommand
        Dim CVE_OBS As Long

        If CLIE_NEW And TRFC.Text <> "XAXX010101000" And TRFC.Text.Trim.Length > 0 Then
            If RFC_CLIENTE_EXISTE(TRFC.Text) Then
                If MsgBox("El RFC actualmente se encuentra asignado al cliente " & vbNewLine & Var10 & vbNewLine & "Desea continuar?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
        End If
        If TNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del cliente")
            Return
        End If
        Try
            If IsNumeric(TCVE_OBS.Tag) Then
                CVE_OBS = TCVE_OBS.Tag
            Else
                CVE_OBS = 0
            End If

            CVE_OBS = INSERT_UPDATE_OCLI(CVE_OBS, TCVE_OBS.Text)

            If CLIE_NEW Then
                Var10 = TCLAVE.Text
            Else
                Var10 = ""
            End If
        Catch ex As Exception
            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        SQL = "IF EXISTS (SELECT CLAVE FROM CLIE" & Empresa & " WHERE CLAVE = @CLAVE)
                UPDATE CLIE" & Empresa & " SET NOMBRE = @NOMBRE, RFC = @RFC, CALLE = @CALLE, NUMINT = @NUMINT, NUMEXT = @NUMEXT, 
                CRUZAMIENTOS = @CRUZAMIENTOS, CRUZAMIENTOS2 = @CRUZAMIENTOS2, COLONIA = @COLONIA, CODIGO = @CODIGO,
                LOCALIDAD = @LOCALIDAD, MUNICIPIO = @MUNICIPIO, ESTADO = @ESTADO, PAIS = @PAIS, TELEFONO = @TELEFONO, FAX = @FAX, 
                CURP = @CURP, CVE_ZONA = @CVE_ZONA, EMAILPRED = @EMAILPRED, CVE_OBS = @CVE_OBS, USO_CFDI = @USO_CFDI, 
                FORMADEPAGOSAT = @FORMADEPAGOSAT, REG_FISC = @REG_FISC, REFERDIR = @REFERDIR
                WHERE CLAVE = @CLAVE
            ELSE
                INSERT INTO CLIE" & Empresa & " (CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO,
                LOCALIDAD, MUNICIPIO, ESTADO, PAIS, TELEFONO, FAX, CURP, CVE_ZONA, IMPRIR, EMAILPRED, USO_CFDI, FORMADEPAGOSAT, REG_FISC, REFERDIR) 
                VALUES(
                @CLAVE, 'A', @NOMBRE, @RFC, @CALLE, @NUMINT, @NUMEXT, @CRUZAMIENTOS, @CRUZAMIENTOS2, @COLONIA, @CODIGO, @LOCALIDAD,
                @MUNICIPIO, @ESTADO, @PAIS, @TELEFONO, @FAX, @CURP, @CVE_ZONA, 'S', @EMAILPRED, @USO_CFDI, @FORMADEPAGOSAT, @REG_FISC, @REFERDIR)"

        cmd.Connection = cnSAE
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = RemoveCharacter(TCLAVE.Text)
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = RemoveCharacter(TNOMBRE.Text.Trim)
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = RemoveCharacter(TRFC.Text.Trim)
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text.Trim
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar).Value = TCELULAR.Text.Trim
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNumInt.Text.Trim
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNumExt.Text.Trim
            cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = TCRUZAMIENTOS.Text.Trim
            cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = TCRUZAMIENTOS2.Text.Trim
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text.Trim
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TCODIGO.Text.Trim
            cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text.Trim
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMunicipio.Text.Trim
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TEstado.Text.Trim
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPais.Text.Trim
            cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = TCURP.Text.Trim
            cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = TCVE_ZONA.Text.Trim
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@EMAILPRED", SqlDbType.VarChar).Value = TCORREO.Text
            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = TUSO_CFDI.Text.Trim
            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = TFORMADEPAGOSAT.Text.Trim
            cmd.Parameters.Add("@REG_FISC", SqlDbType.VarChar).Value = TREGIMEN_FISCAL.Text.Trim
            cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = TREFERDIR.Text.Trim
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El cliente se grabo correctamente")

                    Me.DialogResult = Windows.Forms.DialogResult.OK

                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnRegFisc_Click(sender As Object, e As EventArgs) Handles BtnRegFisc.Click
        Try
            Var2 = "RegimenFiscal"
            frmUsoCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TREGIMEN_FISCAL.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TREGIMEN_FISCAL_KeyDown(sender As Object, e As KeyEventArgs) Handles TREGIMEN_FISCAL.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnRegFisc_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TREGIMEN_FISCAL_Validated(sender As Object, e As EventArgs) Handles TREGIMEN_FISCAL.Validated
        Try
            If TREGIMEN_FISCAL.Text.Trim.Length > 0 Then
                Dim doc As New XmlDocument()
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_REGIMENFISCAL40.xml")
                Dim child_nodes As XmlNodeList = doc.GetElementsByTagName("row")
                Dim Moral As String, Fisica As String, Descr As String, Regimen As String
                Dim Existe As Boolean = False

                Dim txt As String = ""
                For Each child As XmlNode In child_nodes
                    Moral = child.Attributes("Moral").InnerXml '& " = " & child.InnerText & vbCrLf
                    Fisica = child.Attributes("Fisica").InnerXml
                    Descr = child.Attributes("Descripcion").InnerXml
                    Regimen = child.Attributes("c_RegimenFiscal").InnerXml

                    If child.Attributes("c_RegimenFiscal").InnerXml = TREGIMEN_FISCAL.Text Then
                        Existe = True
                    End If
                Next child
                If Not Existe Then
                    MsgBox("Regimen fiscal inexistemte, verifique por favor")
                    TREGIMEN_FISCAL.Text = TREGIMEN_FISCAL.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnUSoCFDI_Click(sender As Object, e As EventArgs) Handles BtnUSoCFDI.Click
        Try
            Var2 = "USOCFDI"
            FrmSelItem22.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUSO_CFDI.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TUSO_CFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles TUSO_CFDI.KeyDown

    End Sub

    Private Sub TUSO_CFDI_Validated(sender As Object, e As EventArgs) Handles TUSO_CFDI.Validated

    End Sub
    Private Sub BtnFormaPagoSAT_Click(sender As Object, e As EventArgs) Handles BtnFormaPagoSAT.Click

    End Sub

    Private Sub BtnZona_Click(sender As Object, e As EventArgs) Handles BtnZona.Click

    End Sub
    Private Sub TFORMADEPAGOSAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TFORMADEPAGOSAT.KeyDown

    End Sub

    Private Sub TFORMADEPAGOSAT_Validated(sender As Object, e As EventArgs) Handles TFORMADEPAGOSAT.Validated

    End Sub
End Class
