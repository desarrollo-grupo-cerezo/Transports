Imports System.Xml
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmAlmacenesAE
    Private Sub FrmAlmacenesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        AssignValidation(Me.TMUNICIPIO, ValidationType.Only_Numbers)
        AssignValidation(Me.TLOCALIDAD, ValidationType.Only_Numbers)
        AssignValidation(Me.TCOLONIA, ValidationType.Only_Numbers)
        AssignValidation(Me.TCP, ValidationType.Only_Numbers)

        BtnListaPrec.FlatStyle = FlatStyle.Flat
        BtnListaPrec.FlatAppearance.BorderSize = 0
        BtnMovEnt.FlatStyle = FlatStyle.Flat
        BtnMovEnt.FlatAppearance.BorderSize = 0
        BtnMovSal.FlatStyle = FlatStyle.Flat
        BtnMovSal.FlatAppearance.BorderSize = 0
        BtnMunicipio.FlatStyle = FlatStyle.Flat
        BtnMunicipio.FlatAppearance.BorderSize = 0
        BtnLocalidad.FlatStyle = FlatStyle.Flat
        BtnLocalidad.FlatAppearance.BorderSize = 0
        BtnEstado.FlatStyle = FlatStyle.Flat
        BtnEstado.FlatAppearance.BorderSize = 0
        BtnPais.FlatStyle = FlatStyle.Flat
        BtnPais.FlatAppearance.BorderSize = 0

        BtRFC.FlatStyle = FlatStyle.Flat
        BtRFC.FlatAppearance.BorderSize = 0

        BtCP.FlatStyle = FlatStyle.Flat
        BtCP.FlatAppearance.BorderSize = 0
        BtEstado.FlatStyle = FlatStyle.Flat
        BtEstado.FlatAppearance.BorderSize = 0
        BtPais.FlatStyle = FlatStyle.Flat
        BtPais.FlatAppearance.BorderSize = 0
        BtnOblig.FlatStyle = FlatStyle.Flat
        BtnOblig.FlatAppearance.BorderSize = 0

        BtnColonia.FlatStyle = FlatStyle.Flat
        BtnColonia.FlatAppearance.BorderSize = 0
        BtnCP.FlatStyle = FlatStyle.Flat
        BtnCP.FlatAppearance.BorderSize = 0

        TLISTA_PREC.Value = 1
        TCVE_MENT.Value = 7
        TCVE_MSAL.Value = 58
        TKMS_RECORRIDOS.Value = 0

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        TDescr.MaxLength = 40
        CboAlmacen.Items.Clear()
        For k = 1 To 99
            CboAlmacen.Items.Add(k)
        Next

        For Each tb As TextBox In Controls.OfType(Of TextBox)()
            Debug.Print(tb.Name)
            AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
            AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
        Next


        If Var1 = "Nuevo" Then
            Try
                TDescr.Text = ""
                TDescr.Focus()
                TDescr.Select()

                Dim CVE_ALM As Integer = GET_MAX("ALMACENES" & Empresa, "CVE_ALM")

                CboAlmacen.Enabled = True
                For k = 1 To CboAlmacen.Items.Count - 1
                    If CboAlmacen.Items(k) = CVE_ALM Then
                        CboAlmacen.SelectedIndex = k
                        Exit For
                    End If
                Next


                TDescr.Focus()
                TDescr.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT M.CVE_ALM, M.DESCR, M.DIRECCION, M.ENCARGADO, M.TELEFONO, M.LISTA_PREC, M.CUEN_CONT, 
                    M.CVE_MENT, M.CVE_MSAL 
                    FROM ALMACENES" & Empresa & " M 
                    WHERE CVE_ALM = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    For k = 0 To CboAlmacen.Items.Count - 1
                        If CboAlmacen.Items(k) = dr("CVE_ALM") Then
                            CboAlmacen.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    TDescr.Text = dr.ReadNullAsEmptyString("DESCR")
                    TDIRECCION.Text = dr.ReadNullAsEmptyString("DIRECCION")
                    TENCARGADO.Text = dr.ReadNullAsEmptyString("ENCARGADO")
                    TTELEFONO.Text = dr.ReadNullAsEmptyString("TELEFONO")
                    TLISTA_PREC.Value = dr.ReadNullAsEmptyInteger("LISTA_PREC")
                    If TLISTA_PREC.Value < 1 Then
                        TLISTA_PREC.Value = 1
                    End If
                    TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                    TCVE_MENT.Value = dr.ReadNullAsEmptyInteger("CVE_MENT")
                    TCVE_MSAL.Value = dr.ReadNullAsEmptyInteger("CVE_MSAL")

                    DESPLEGAR_UBICACIONES()

                Else
                    CboAlmacen.SelectedIndex = -1
                    TDescr.Text = ""
                    TCUEN_CONT.Text = ""
                End If
                dr.Close()

                CboAlmacen.Enabled = False
                TDescr.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try
            sender.BackColor = Color.LightCyan
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try

    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub

    Sub DESPLEGAR_UBICACIONES()

        SQL = "SELECT D.CVE_UBI, D.CVE_ALM, D.RFC, D.NOMBRE, D.NUM_IDENTIFIER, D.RESIDENCIA, D.PAIS, 
            D.CP, D.ESTADO, D.MUNICIPIO, D.LOCALIDAD, D.COLONIA, D.CALLE, D.NUMINT, D.NUMEXT, 
            D.REFERENCIA, KMS_RECORRIDOS
            FROM CFDI_UBICACIONES D 
            WHERE CVE_ALM = " & Var2
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        For k = 0 To CboAlmacen.Items.Count - 1
                            If dr("CVE_ALM") = CboAlmacen.Items(k) Then
                                CboAlmacen.SelectedIndex = k
                                Exit For
                            End If
                        Next
                        TRFC.Text = dr.ReadNullAsEmptyString("RFC")
                        TNOMBRE.Text = dr.ReadNullAsEmptyString("NOMBRE")
                        TNUM_IDENTIFIER.Text = dr.ReadNullAsEmptyString("NUM_IDENTIFIER")
                        TRESIDENCIA.Text = dr.ReadNullAsEmptyString("RESIDENCIA")

                        If dr.ReadNullAsEmptyString("PAIS").Trim.Length > 0 Then
                            TPAIS.Text = dr.ReadNullAsEmptyString("PAIS")
                        Else
                            TPAIS.Text = "MEX"
                        End If

                        TCP.Text = dr.ReadNullAsEmptyString("CP")
                        TESTADO.Text = dr.ReadNullAsEmptyString("ESTADO")
                        TMUNICIPIO.Text = dr.ReadNullAsEmptyString("MUNICIPIO")
                        TLOCALIDAD.Text = dr.ReadNullAsEmptyString("LOCALIDAD")
                        TCOLONIA.Text = dr.ReadNullAsEmptyString("COLONIA")
                        TCALLE.Text = dr.ReadNullAsEmptyString("CALLE")
                        TNUMINT.Text = dr.ReadNullAsEmptyString("NUMINT")
                        TNUMEXT.Text = dr.ReadNullAsEmptyString("NUMEXT")
                        TREFERENCIA.Text = dr.ReadNullAsEmptyString("REFERENCIA")
                        TKMS_RECORRIDOS.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")
                    Else
                        TPAIS.Text = "MEX"
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmAlmacenesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmAlmacenesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            TKMS_RECORRIDOS.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If TDescr.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        If CboAlmacen.SelectedIndex = -1 Then
            MsgBox("POr favor seleccione un almacen")
            Return
        End If

        SQL = "IF EXISTS (SELECT CVE_ALM FROM ALMACENES" & Empresa & " WHERE CVE_ALM  = @CVE_ALM)
                UPDATE ALMACENES" & Empresa & " SET DESCR = @DESCR, DIRECCION = @DIRECCION, ENCARGADO = @ENCARGADO, 
                TELEFONO = @TELEFONO, LISTA_PREC = @LISTA_PREC, CUEN_CONT = @CUEN_CONT, CVE_MENT = @CVE_MENT, 
                CVE_MSAL = @CVE_MSAL
                WHERE CVE_ALM = @CVE_ALM
            ELSE
                INSERT INTO ALMACENES" & Empresa & " (CVE_ALM, STATUS, DESCR, DIRECCION, ENCARGADO, TELEFONO, LISTA_PREC, 
                CUEN_CONT, CVE_MENT, CVE_MSAL)
                VALUES(
                @CVE_ALM, 'A', @DESCR, @DIRECCION, @ENCARGADO, @TELEFONO, @LISTA_PREC, @CUEN_CONT, @CVE_MENT, @CVE_MSAL)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ALM", SqlDbType.Int).Value = CboAlmacen.Items(CboAlmacen.SelectedIndex)
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDescr.Text
                cmd.Parameters.Add("@DIRECCION", SqlDbType.VarChar).Value = TDIRECCION.Text
                cmd.Parameters.Add("@ENCARGADO", SqlDbType.VarChar).Value = TENCARGADO.Text
                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text
                cmd.Parameters.Add("@LISTA_PREC", SqlDbType.Int).Value = TLISTA_PREC.Value
                cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
                cmd.Parameters.Add("@CVE_MENT", SqlDbType.Int).Value = TCVE_MENT.Value
                cmd.Parameters.Add("@CVE_MSAL", SqlDbType.Int).Value = TCVE_MSAL.Value
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        GRABAR_UBICACIONES()
                        MsgBox("El almacén se grabo correctamente")
                        Me.Close()
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_UBICACIONES()

        SQL = "IF EXISTS (SELECT CVE_ALM FROM CFDI_UBICACIONES WHERE CVE_ALM = @CVE_ALM)
                    UPDATE CFDI_UBICACIONES SET RFC = @RFC, NOMBRE = @NOMBRE, NUM_IDENTIFIER = @NUM_IDENTIFIER, 
                    RESIDENCIA = @RESIDENCIA, PAIS = @PAIS, CP = @CP, ESTADO = @ESTADO, MUNICIPIO = @MUNICIPIO, 
                    LOCALIDAD = @LOCALIDAD, COLONIA = @COLONIA, CALLE = @CALLE, NUMINT = @NUMINT, NUMEXT = @NUMEXT, 
                    REFERENCIA = @REFERENCIA, KMS_RECORRIDOS = @KMS_RECORRIDOS
                    WHERE CVE_ALM = @CVE_ALM
                ELSE
                    INSERT INTO CFDI_UBICACIONES (CVE_UBI, CVE_ALM, RFC, NOMBRE, NUM_IDENTIFIER, RESIDENCIA, PAIS, 
                    CP, ESTADO, MUNICIPIO, LOCALIDAD, COLONIA, CALLE, NUMINT, NUMEXT, REFERENCIA, KMS_RECORRIDOS)
                    VALUES(
                    ISNULL((SELECT MAX(CVE_UBI) + 1 FROM CFDI_UBICACIONES),1), @CVE_ALM, @RFC, @NOMBRE, @NUM_IDENTIFIER, 
                    @RESIDENCIA, @PAIS, @CP, @ESTADO, @MUNICIPIO, @LOCALIDAD, @COLONIA, @CALLE, @NUMINT, @NUMEXT, 
                    @REFERENCIA, @KMS_RECORRIDOS)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ALM", SqlDbType.Int).Value = CboAlmacen.Items(CboAlmacen.SelectedIndex)
                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Text
                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Text
                cmd.Parameters.Add("@NUM_IDENTIFIER", SqlDbType.VarChar).Value = TNUM_IDENTIFIER.Text
                cmd.Parameters.Add("@RESIDENCIA", SqlDbType.VarChar).Value = TRESIDENCIA.Text
                cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text
                cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = TCP.Text
                cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TESTADO.Text
                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO.Text
                cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text
                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text
                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text
                cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNUMINT.Text
                cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNUMEXT.Text
                cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = TREFERENCIA.Text
                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Int).Value = TKMS_RECORRIDOS.Value
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub frmAlmacenesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Almacén")

            If ExisteTab("Almacenes") Then
                FrmAlmacenes.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try

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

    Private Sub TMUNICIPIO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMUNICIPIO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMunicipio_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMUNICIPIO_Validated(sender As Object, e As EventArgs) Handles TMUNICIPIO.Validated
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
    Private Sub TLOCALIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles TLOCALIDAD.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLocalidad_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLOCALIDAD_Validated(sender As Object, e As EventArgs) Handles TLOCALIDAD.Validated
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
    Private Sub BtnPais_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles BtnPais.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            TDescr.Focus()
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
    Private Sub TCOLONIA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCOLONIA.KeyDown
        If e.KeyCode = Keys.Enter Then
            TDescr.Focus()
        End If
        If e.KeyCode = Keys.F2 Then
            BtnColonia_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub TCOLONIA_Validated(sender As Object, e As EventArgs) Handles TCOLONIA.Validated

    End Sub
    Private Sub BtnListaPrec_Click(sender As Object, e As EventArgs) Handles BtnListaPrec.Click
        Try
            Var2 = "ListaPrec"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLISTA_PREC.Value = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_MENT.Focus()
            End If
        Catch Ex As Exception
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TLISTA_PREC_KeyDown(sender As Object, e As KeyEventArgs) Handles TLISTA_PREC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnListaPrec_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLISTA_PREC_Validated(sender As Object, e As EventArgs) Handles TLISTA_PREC.Validated
        Try
            If TLISTA_PREC.Text.Trim.Length > 0 And TLISTA_PREC.Value > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("ListaPrec", TLISTA_PREC.Text)
                If DESCR = "" Then
                    MsgBox("Lista de precios inexistente verifique por favor")
                    TLISTA_PREC.Text = ""
                End If
            Else
                TLISTA_PREC.Value = 1
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMovEnt_Click(sender As Object, e As EventArgs) Handles BtnMovEnt.Click
        Try
            Var2 = "MinveEnt"
            Var4 = "" : Var5 = ""
            Var7 = " AND SIGNO = 1"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_MENT.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_MSAL.Focus()
            End If
        Catch Ex As Exception
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_MENT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_MENT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMovEnt_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_MENT_Validated(sender As Object, e As EventArgs) Handles TCVE_MENT.Validated
        Try
            If TCVE_MENT.Text.Trim.Length > 0 And TCVE_MENT.Value > 0 Then
                Dim DESCR As String
                Var7 = " AND SIGNO = 1"
                DESCR = BUSCA_CAT("MinveEnt", TCVE_MENT.Text)
                If DESCR = "" Then
                    MsgBox("Concepto entrada inexistente verifique por favor")
                    TCVE_MENT.Value = ""
                    'TCVE_MENT.Select()
                End If
            Else
                TCVE_MENT.Value = 7
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMovSal_Click(sender As Object, e As EventArgs) Handles BtnMovSal.Click
        Try
            Var2 = "MinveSal"
            Var4 = "" : Var5 = ""
            Var7 = " AND SIGNO = -1"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_MSAL.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                Panel1.Focus()
            End If
        Catch Ex As Exception
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_MSAL_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_MSAL.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMovSal_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_MSAL_Validated(sender As Object, e As EventArgs) Handles TCVE_MSAL.Validated
        Try
            If TCVE_MSAL.Text.Trim.Length > 0 And TCVE_MSAL.Value > 0 Then
                Dim DESCR As String
                Var7 = " AND SIGNO = -1"
                DESCR = BUSCA_CAT("MinveSal", TCVE_MSAL.Text)
                If DESCR = "" Then
                    MsgBox("Concepto salida inexistente verifique por favor")
                    TCVE_MSAL.Value = ""
                    'TCVE_MSAL.Select()
                End If
            Else
                TCVE_MSAL.Value = 58
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
