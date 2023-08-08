Imports System.Data.SqlClient
Imports System.Xml
Public Class FrmClientesOperativosAE
    Private CLIEN_OP_NEW As Boolean
    Private ENTRA As Boolean = True
    Private RD As String
    Private Sub FrmClientesOperativosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        BarMenu.BackColor = Color.FromArgb(164, 177, 202)

        TNOMBRE.MaxLength = 120
        TDOMICILIO.MaxLength = 255
        TNUMEXT.MaxLength = 255
        TPLANTA.MaxLength = 50
        TNOTA.MaxLength = 255
        TRFC.MaxLength = 20


        TNUMREGIDTRIB.Value = ""
        TNUMREGIDTRIB.Text = ""
        TCLAVE.Text = 0
        TNOMBRE.Text = ""
        TDOMICILIO.Text = ""
        TNUMEXT.Text = ""
        TPLANTA.Text = ""
        TNOTA.Text = ""
        TRFC.Text = ""
        RD = Var8
        If Var1 = "Nuevo" Then
            CLIEN_OP_NEW = True
            Try
                TCLAVE.Text = RD & Format(GET_MAX_OP(RD), "0000")
                TCLAVE.Enabled = False
                TNOMBRE.Text = ""
                TNOMBRE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            CLIEN_OP_NEW = False
            DESPLEGAR_CLIENTE_OP(Var2)
        End If
    End Sub
    Sub DESPLEGAR_CLIENTE_OP(FCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT C.CLAVE, C.NOMBRE, C.CVE_PLAZA, C.DOMICILIO, C.DOMICILIO2, C.PLANTA, C.NOTA, C.RFC, C.CUEN_CONT, CP, CP_SAT, COLONIA, 
                    C.COLONIA_SAT, C.POBLACION, C.POBLACION_SAT, C.MUNICIPIO, C.MUNICIPIO_SAT, ESTADO, ESTADO_SAT, PAIS, PAIS_SAT, NUMEXT, NUMINT,
                    REFERENCIA, NUMREGIDTRIB
                    FROM GCCLIE_OP C 
                    WHERE C.CLAVE = '" & FCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                TCLAVE.Text = dr("CLAVE").ToString
                TNOMBRE.Text = dr("NOMBRE").ToString
                TDOMICILIO.Text = dr("DOMICILIO").ToString
                TDOMICILIO2.Text = dr("DOMICILIO2").ToString

                TNUMEXT.Text = dr("NUMEXT").ToString
                TNUMINT.Text = dr("NUMINT").ToString

                TPLANTA.Text = dr("PLANTA").ToString
                TNOTA.Text = dr("NOTA").ToString
                TRFC.Text = dr("RFC").ToString
                TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")

                TCP.Text = dr.ReadNullAsEmptyString("CP")
                TCP_SAT.Text = dr.ReadNullAsEmptyString("CP_SAT")
                TCOLONIA.Text = dr.ReadNullAsEmptyString("COLONIA")
                TCOLONIA_SAT.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")

                TLOCALIDAD.Text = dr.ReadNullAsEmptyString("POBLACION")
                TLOCALIDAD_SAT.Text = dr.ReadNullAsEmptyString("POBLACION_SAT")

                TMUNICIPIO.Text = dr.ReadNullAsEmptyString("MUNICIPIO")
                TMUNICIPIO_SAT.Text = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")

                TESTADO.Text = dr.ReadNullAsEmptyString("ESTADO")
                TESTADO_SAT.Text = dr.ReadNullAsEmptyString("ESTADO_SAT")

                TPAIS.Text = dr.ReadNullAsEmptyString("PAIS")
                TPAIS_SAT.Text = dr.ReadNullAsEmptyString("PAIS_SAT")

                TNUMREGIDTRIB.Text = dr.ReadNullAsEmptyString("NUMREGIDTRIB")

            Else
                TCLAVE.Text = 0
                TNOMBRE.Text = ""
                TDOMICILIO.Text = ""
                TNUMEXT.Text = ""
                TPLANTA.Text = ""
                TNOTA.Text = ""
                TRFC.Text = ""
                TCUEN_CONT.Text = ""
                TNUMREGIDTRIB.Text = ""
            End If
            dr.Close()

            TCLAVE.Enabled = False
            TNOMBRE.Select()

        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmClientesOperativosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmClientesOperativosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If TNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("La nombre no debe quedar vacia, verifique por favor")
            Return
        End If

        SQL = "IF EXISTS (SELECT CLAVE FROM GCCLIE_OP WHERE CLAVE = @CLAVE)
                UPDATE GCCLIE_OP SET NOMBRE = @NOMBRE, DOMICILIO = @DOMICILIO, DOMICILIO2 = @DOMICILIO2, NUMEXT = @NUMEXT, NUMINT = @NUMINT, 
                PLANTA = @PLANTA, NOTA = @NOTA, RFC = @RFC, CUEN_CONT = @CUEN_CONT, CP = @CP, CP_SAT = @CP_SAT, COLONIA = @COLONIA, 
                COLONIA_SAT = @COLONIA_SAT, POBLACION = @POBLACION, POBLACION_SAT = @POBLACION_SAT, MUNICIPIO = @MUNICIPIO, 
                MUNICIPIO_SAT = @MUNICIPIO_SAT, ESTADO = @ESTADO, ESTADO_SAT = @ESTADO_SAT, PAIS = @PAIS, PAIS_SAT = @PAIS_SAT,
                NUMREGIDTRIB = @NUMREGIDTRIB
                WHERE CLAVE = @CLAVE 
            ELSE
                INSERT INTO GCCLIE_OP (CLAVE, STATUS, NOMBRE, DOMICILIO, DOMICILIO2, NUMEXT, NUMINT, PLANTA, NOTA, RFC, 
                CUEN_CONT, CP, CP_SAT, COLONIA, COLONIA_SAT, POBLACION, POBLACION_SAT, MUNICIPIO, MUNICIPIO_SAT, ESTADO, ESTADO_SAT, 
                PAIS, PAIS_SAT, UUID, RD, NUMREGIDTRIB) 
                VALUES(
                @CLAVE, 'A', @NOMBRE, @DOMICILIO, @DOMICILIO2, @NUMEXT, @NUMINT, @PLANTA, @NOTA, @RFC, @CUEN_CONT, @CP, 
                @CP_SAT, @COLONIA, @COLONIA_SAT, @POBLACION, @POBLACION_SAT, @MUNICIPIO, @MUNICIPIO_SAT, @ESTADO, @ESTADO_SAT, @PAIS, 
                @PAIS_SAT, NEWID(), @RD, @NUMREGIDTRIB)"
        Var4 = ""
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Text
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Text
            cmd.Parameters.Add("@DOMICILIO", SqlDbType.VarChar).Value = TDOMICILIO.Text
            cmd.Parameters.Add("@DOMICILIO2", SqlDbType.VarChar).Value = TDOMICILIO2.Text
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNUMEXT.Text
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNUMINT.Text
            cmd.Parameters.Add("@PLANTA", SqlDbType.VarChar).Value = TPLANTA.Text
            cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = TNOTA.Text
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = TCP.Text
            cmd.Parameters.Add("@CP_SAT", SqlDbType.VarChar).Value = TCP_SAT.Text
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text
            cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = TCOLONIA_SAT.Text
            cmd.Parameters.Add("@POBLACION", SqlDbType.VarChar).Value = TLOCALIDAD.Text
            cmd.Parameters.Add("@POBLACION_SAT", SqlDbType.VarChar).Value = TLOCALIDAD_SAT.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO.Text
            cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = TMUNICIPIO_SAT.Text
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TESTADO.Text
            cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = TESTADO_SAT.Text
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text
            cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = TPAIS_SAT.Text
            cmd.Parameters.Add("@RD", SqlDbType.VarChar).Value = RD
            cmd.Parameters.Add("@NUMREGIDTRIB", SqlDbType.VarChar).Value = TNUMREGIDTRIB.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")

                    Var4 = "" 'TCLAVE.Text

                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '==========================================================================
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmClientesOperativosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub TCUEN_CONT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCUEN_CONT.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                TNOMBRE.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCP_Click(sender As Object, e As EventArgs) Handles BtnCP.Click
        Try
            Prosec = "CP"
            Var4 = ""
            Var6 = TCP.Text
            Var7 = TLOCALIDAD.Text
            Var8 = TMUNICIPIO.Text
            Var9 = TESTADO.Text
            FrmListaXML.ShowDialog()
            'FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCP.Text = Var4
                TESTADO_SAT.Text = Var7
                TMUNICIPIO_SAT.Text = Var8
                TLOCALIDAD_SAT.Text = Var9
                TPAIS.Text = "MEXICO"
                TPAIS_SAT.Text = "MEX"

            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
            'Prosec = "CP"
            'Var4 = ""
            'Var7 = ""
            'Var8 = ""
            'Var9 = ""
            'FrmSelItemBinding.ShowDialog()
            'If Var4.Trim.Length > 0 Then
            'Var4 = Fg(Fg.Row, 1) 'CP
            'Var7 = Fg(Fg.Row, 2) 'ESTADO
            'Var8 = Fg(Fg.Row, 3) 'MUNICIPIO
            'Var9 = Fg(Fg.Row, 4) 'LOCALIDAD
            'TCP.Text = Var4
            'TESTADO_SAT.Text = Var7
            'TMUNICIPIO_SAT.Text = Var8
            'TLOCALIDAD_SAT.Text = Var9
            'TPAIS.Text = "MEXICO"
            'TPAIS_SAT.Text = "MEX"
            'End If
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

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_CodigoPostal='" & TCP.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Codigo postal inexistente, verifique por favor")
                    Else
                        For Each node As XmlNode In nodeList
                            CP = node.Attributes("c_CodigoPostal").Value
                            TESTADO_SAT.Text = node.Attributes("c_Estado").Value
                            TMUNICIPIO_SAT.Text = node.Attributes("c_Municipio").Value
                            TLOCALIDAD_SAT.Text = node.Attributes("c_Localidad").Value
                            TPAIS.Text = "MEXICO"
                            TPAIS_SAT.Text = "MEX"

                            If CP = TCP.Text Then
                                x += 1
                            End If
                        Next
                    End If
                    If x = 0 Then
                        MsgBox("Código postal no corresponde a la localidad y municipio capturados, verfique por favor")
                    Else
                        If TESTADO_SAT.Text.Trim.Length > 0 AndAlso TLOCALIDAD_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & TESTADO_SAT.Text & "' and @Clave='" & TLOCALIDAD_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TLOCALIDAD.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        If TESTADO_SAT.Text.Trim.Length > 0 AndAlso TMUNICIPIO_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & TESTADO_SAT.Text & "' and @Clave='" & TMUNICIPIO_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TMUNICIPIO.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If

                        If TESTADO_SAT.Text.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TESTADO_SAT.Text & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            TESTADO.Text = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If
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
            Var6 = TCOLONIA_SAT.Text
            Var7 = TCP.Text
            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCOLONIA.Text = Var8
                TCOLONIA_SAT.Text = Var4
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
            'Prosec = "COLONIAS"
            'Var4 = ""
            'Var7 = TCP.Text
            'FrmSelItemBinding.ShowDialog()
            'If Var4.Trim.Length > 0 Then
            'Var4 = Fg(Fg.Row, 1) '"Colonia"
            'Var7 = Fg(Fg.Row, 2) '"Código postal"
            'Var8 = Fg(Fg.Row, 3) '"Nombre asentamiento"

            'TCOLONIA.Text = Var8
            'TCOLONIA_SAT.Text = Var4
            'End If
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

    Private Sub TCOLONIA_SAT_Validated(sender As Object, e As EventArgs) Handles TCOLONIA_SAT.Validated

        SQL = "SELECT colonia, codigopostal, nombreasentamiento 
            FROM tblcolonias WHERE colonia = '" & TCOLONIA_SAT.Text & "' AND codigopostal = '" & TCP.Text & "'"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCOLONIA.Text = dr("nombreasentamiento")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnMunicipio_Click(sender As Object, e As EventArgs) Handles BtnMunicipio.Click
        Try
            Prosec = "Municipio"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TMUNICIPIO.Text = Var12
                TMUNICIPIO_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLocalidad_Click(sender As Object, e As EventArgs) Handles BtnLocalidad.Click
        Try
            Prosec = "Localidad"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TLOCALIDAD.Text = Var12
                TLOCALIDAD_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEstado_Click(sender As Object, e As EventArgs) Handles BtnEstado.Click
        Try
            Prosec = "Estado"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TESTADO.Text = Var12
                TESTADO_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPais_Click(sender As Object, e As EventArgs) Handles BtnPais.Click
        Try
            Prosec = "Pais"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TPAIS.Text = Var12
                TPAIS_SAT.Text = Var11
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCP2_Click(sender As Object, e As EventArgs) Handles BtnCP2.Click
        Try
            Prosec = "CP"
            Var4 = ""
            Var7 = ""
            Var8 = ""
            Var9 = ""
            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCP.Text = Var4
                TCP_SAT.Text = Var4
                TESTADO_SAT.Text = Var7
                TMUNICIPIO_SAT.Text = Var8
                TLOCALIDAD_SAT.Text = Var9
                TPAIS.Text = "MEXICO"
                TPAIS_SAT.Text = "MEX"
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLOCALIDAD_SAT_TextChanged(sender As Object, e As EventArgs) Handles TLOCALIDAD_SAT.TextChanged
        Try
            If TLOCALIDAD_SAT.Text.Trim.Length = 0 Then
                TLOCALIDAD.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnGrabarCteFiscal_Click(sender As Object, e As EventArgs) Handles BtnGrabarCteFiscal.Click

        If MsgBox("Realmente desea agregar el cliente operativo como cliente fiscal", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Dim ExistCte As Boolean = False, CLIENTE As String = ""

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CLAVE, REFERENCIA_ENVIO FROM CLIE" & Empresa & " WHERE REFERENCIA_ENVIO = '" & TCLAVE.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ExistCte = True
                        CLIENTE = dr("CLAVE")
                    End If
                End Using
            End Using
            If ExistCte Then
                MsgBox("El cliente operativo ya fue agregado en los clientes fiscales con clave " & CLIENTE)
                Return
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try



        SQL = "INSERT INTO CLIE" & Empresa & " (CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO,
            LOCALIDAD, MUNICIPIO, ESTADO, PAIS, NACIONALIDAD, REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, IMPRIR, MAIL,
            NIVELSEC, ENVIOSILEN, EMAILPRED, DIAREV, DIAPAGO, CON_CREDITO, DIASCRED, LIMCRED, LISTA_PREC, CVE_BITA, ULT_PAGOD,
            ULT_PAGOM, ULT_PAGOF, DESCUENTO, ULT_VENTAD, ULT_COMPM, FCH_ULTCOM, VENTAS, CVE_VEND, CVE_OBS, TIPO_EMPRESA, MATRIZ,
            CALLE_ENVIO, NUMINT_ENVIO, NUMEXT_ENVIO, CRUZAMIENTOS_ENVIO, CRUZAMIENTOS_ENVIO2, COLONIA_ENVIO, LOCALIDAD_ENVIO, 
            MUNICIPIO_ENVIO, ESTADO_ENVIO, PAIS_ENVIO, CODIGO_ENVIO, CVE_ZONA_ENVIO, REFERENCIA_ENVIO, CUENTA_CONTABLE,
            METODODEPAGO, NUMCTAPAGO, MODELO, USO_CFDI, CVE_PAIS_SAT, NUMIDREGFISCAL, FORMADEPAGOSAT, REG_FISC, NOMBRECOMERCIAL) VALUES(
            @CLAVE, 'A', @NOMBRE, @RFC, @CALLE, @NUMINT, @NUMEXT, @CRUZAMIENTOS, @CRUZAMIENTOS2, @COLONIA, @CODIGO, @LOCALIDAD,
            @MUNICIPIO, @ESTADO, @PAIS, @NACIONALIDAD, @REFERDIR, @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, @CURP, @CVE_ZONA, @IMPRIR, @MAIL,
            @NIVELSEC, @ENVIOSILEN, @EMAILPRED, @DIAREV, @DIAPAGO, @CON_CREDITO, @DIASCRED, @LIMCRED, @LISTA_PREC, @CVE_BITA,
            @ULT_PAGOD, @ULT_PAGOM, @ULT_PAGOF, @DESCUENTO, @ULT_VENTAD, @ULT_COMPM, @FCH_ULTCOM, @VENTAS, @CVE_VEND, @CVE_OBS, @TIPO_EMPRESA,
            @MATRIZ, @CALLE_ENVIO, @NUMINT_ENVIO, @NUMEXT_ENVIO, @CRUZAMIENTOS_ENVIO, @CRUZAMIENTOS_ENVIO2, @COLONIA_ENVIO, @LOCALIDAD_ENVIO,
            @MUNICIPIO_ENVIO, @ESTADO_ENVIO, @PAIS_ENVIO, @CODIGO_ENVIO, @CVE_ZONA_ENVIO, @REFERENCIA_ENVIO, @CUENTA_CONTABLE, @METODODEPAGO,
            @NUMCTAPAGO, @MODELO, @USO_CFDI, @CVE_PAIS_SAT, @NUMIDREGFISCAL, @FORMADEPAGOSAT, @REG_FISC, @NOMBRECOMERCIAL)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = GET_MAX("CLIE" & Empresa, "CLAVE", 10)
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Text
                cmd.Parameters.Add("@NOMBRECOMERCIAL", SqlDbType.VarChar).Value = TNOMBRE.Text
                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Text
                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TDOMICILIO.Text.Trim
                cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNUMINT.Text.Trim
                cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNUMEXT.Text.Trim

                cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = TDOMICILIO2.Text.Trim
                cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text.Trim
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TCP.Text.Trim
                cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text.Trim
                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO.Text.Trim
                cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TESTADO.Text.Trim
                cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text.Trim
                cmd.Parameters.Add("@NACIONALIDAD", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@FAX", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@PAG_WEB", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@IMPRIR", SqlDbType.VarChar).Value = "S"
                cmd.Parameters.Add("@MAIL", SqlDbType.VarChar).Value = "S"
                cmd.Parameters.Add("@NIVELSEC", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@ENVIOSILEN", SqlDbType.VarChar).Value = "N"
                cmd.Parameters.Add("@EMAILPRED", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@DIAREV", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@DIAPAGO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CON_CREDITO", SqlDbType.VarChar).Value = "N"
                cmd.Parameters.Add("@DIASCRED", SqlDbType.Int).Value = 9
                cmd.Parameters.Add("@LIMCRED", SqlDbType.Float).Value = 9
                cmd.Parameters.Add("@LISTA_PREC", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@ULT_PAGOD", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@ULT_PAGOM", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@ULT_PAGOF", SqlDbType.DateTime).Value = Now
                cmd.Parameters.Add("@DESCUENTO", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@ULT_VENTAD", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@ULT_COMPM", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@FCH_ULTCOM", SqlDbType.DateTime).Value = Now
                cmd.Parameters.Add("@VENTAS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@TIPO_EMPRESA", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@MATRIZ", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CALLE_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@NUMINT_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@NUMEXT_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CRUZAMIENTOS_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CRUZAMIENTOS_ENVIO2", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@COLONIA_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@LOCALIDAD_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@MUNICIPIO_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@ESTADO_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@PAIS_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CODIGO_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@CVE_ZONA_ENVIO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@REFERENCIA_ENVIO", SqlDbType.VarChar).Value = TCLAVE.Text
                cmd.Parameters.Add("@CUENTA_CONTABLE", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = "PPD"
                cmd.Parameters.Add("@NUMCTAPAGO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = "G03"
                cmd.Parameters.Add("@CVE_PAIS_SAT", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@NUMIDREGFISCAL", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = "99"
                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "A"
                cmd.Parameters.Add("@REG_FISC", SqlDbType.VarChar).Value = ""

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            MsgBox("El cliente se agrego a cliente fiscal")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub TMUNICIPIO_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TMUNICIPIO_SAT.KeyDown

    End Sub
End Class
