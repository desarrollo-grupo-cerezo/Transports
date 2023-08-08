Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class frmAseguradorasAE
    Private CLIENTE As String
    Private Sub FrmAseguradorasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()

        Me.KeyPreview = True
        Me.WindowState = FormWindowState.Maximized

        CONTROLES_MAXLENGHT()
        TAB1.SelectedIndex = 0

        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                INICIALIZAR_CONTROLES()
                TCLAVE.Text = GET_MAX_TRY("GCASEGURADORAS", "CLAVE")
                TCLAVE.Enabled = False
                TNOMBRE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            CLIENTE = Var2
            DESPLEGAR_CLIENTE()
        End If
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

            cmd.Connection = cnSAE

            SQL = "SELECT I.CLAVE, I.STATUS, I.NOMBRE, I.RFC, I.CALLE, I.NUMINT, I.NUMEXT, I.CRUZAMIENTOS, I.CRUZAMIENTOS2, I.COLONIA, I.CODIGO, 
                I.LOCALIDAD, I.MUNICIPIO, I.ESTADO, I.PAIS, I.NACIONALIDAD, I.REFERDIR, I.TELEFONO, I.CLASIFIC, I.FAX, I.PAG_WEB, I.CURP,
                I.CVE_ZONA, I.CVE_BITA, I.CVE_OBS, I.TIPO_EMPRESA, I.MATRIZ, I.CUENTA_CONTABLE, I.USO_CFDI, I.CVE_PAIS_SAT, I.NUMIDREGFISCAL, 
                I.FORMADEPAGOSAT, ISNULL(OB.STR_OBS,'') AS OBSTR, CUEN_CONT, POLIZARESPCIVIL, ASEGURARESPCIVIL
                FROM GCASEGURADORAS I
                LEFT JOIN OCLI" & Empresa & " OB ON OB.CVE_OBS = I.CVE_OBS
                WHERE CLAVE = '" & CLIENTE & "' AND I.STATUS = 'A'"
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
                    TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")

                    TPolizaRespCivil.Text = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                    TAseguraRespCivil.Text = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")

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
                    TNacionalidad.Text = IIf(IsDBNull(dr("NACIONALIDAD")), "", dr("NACIONALIDAD"))
                    TREFERDIR.Text = IIf(IsDBNull(dr("REFERDIR")), "", dr("REFERDIR"))
                Catch ex As Exception
                    MsgBox("11. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("11. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    TTELEFONO.Text = IIf(IsDBNull(dr("TELEFONO")), "", dr("TELEFONO"))
                    TClasific.Text = IIf(IsDBNull(dr("CLASIFIC")), "", dr("CLASIFIC"))
                    TFax.Text = IIf(IsDBNull(dr("FAX")), "", dr("FAX"))
                    TPAG_WEB.Text = IIf(IsDBNull(dr("PAG_WEB")), "", dr("PAG_WEB"))
                    TCURP.Text = IIf(IsDBNull(dr("CURP")), "", dr("CURP"))
                    TCVE_ZONA.Text = IIf(IsDBNull(dr("CVE_ZONA")), "", dr("CVE_ZONA"))
                Catch ex As Exception
                    MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    TCVE_OBS.Text = dr("OBSTR")
                    TCVE_OBS.Tag = dr("CVE_OBS")

                Catch ex As Exception
                    MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            Else
                INICIALIZAR_CONTROLES()
            End If
            dr.Close()

            TCLAVE.Enabled = False
            TNOMBRE.Select()

        Catch ex As Exception
            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub CONTROLES_MAXLENGHT()

        TCLAVE.MaxLength = 10
        TNOMBRE.MaxLength = 120
        TRFC.MaxLength = 15
        TCALLE.MaxLength = 80
        TNumInt.MaxLength = 15
        TNumExt.MaxLength = 15
        TCRUZAMIENTOS.MaxLength = 40
        TCRUZAMIENTOS2.MaxLength = 40
        TCOLONIA.MaxLength = 50
        TCODIGO.MaxLength = 5
        TLOCALIDAD.MaxLength = 50
        TMunicipio.MaxLength = 50
        TEstado.MaxLength = 50
        TPais.MaxLength = 50
        TNacionalidad.MaxLength = 40
        TREFERDIR.MaxLength = 255
        TTELEFONO.MaxLength = 25
        TClasific.MaxLength = 5
        TFax.MaxLength = 25
        TPAG_WEB.MaxLength = 60
        TCURP.MaxLength = 18
        TCVE_ZONA.MaxLength = 6
        TUSO_CFDI.MaxLength = 5
        TCVE_PAIS_SAT.MaxLength = 5
        TNUMIDREGFISCAL.MaxLength = 128
        TFORMADEPAGOSAT.MaxLength = 5

    End Sub
    Sub INICIALIZAR_CONTROLES()

        Try

            TCLAVE.Text = ""

            TNOMBRE.Text = ""
            TRFC.Text = ""
            TCALLE.Text = ""
            TNumInt.Text = ""
            TNumExt.Text = ""
            TCOLONIA.Text = ""
            TCODIGO.Text = ""
            TLOCALIDAD.Text = ""
            TMunicipio.Text = ""
            TEstado.Text = ""
            TPais.Text = ""
            TNacionalidad.Text = ""
            TTELEFONO.Text = ""
            TClasific.Text = ""
            TFax.Text = ""
            TPAG_WEB.Text = ""
            TCURP.Text = ""
            TCVE_ZONA.Text = ""
            TCVE_OBS.Text = ""
            TCVE_OBS.Tag = "0"
            TUSO_CFDI.Text = ""
            TCVE_PAIS_SAT.Text = ""
            TNUMIDREGFISCAL.Text = ""
            TFORMADEPAGOSAT.Text = ""

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmAseguradorasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Movimiento Aseguradoras")
            Me.Dispose()

            If Form_Open(frmAseguradoras) Then
                frmAseguradoras.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmAseguradorasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmAseguradorasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim cmd As New SqlCommand
        Dim CVE_BITA As Long
        Dim CVE_OBS As Long

        Try
            If IsNumeric(TCVE_OBS.Tag) Then
                CVE_OBS = TCVE_OBS.Tag
            Else
                CVE_OBS = 0
            End If

            CVE_OBS = INSERT_UPDATE_OCLI(TCVE_OBS.Tag, TCVE_OBS.Text)

        Catch ex As Exception
            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCASEGURADORAS SET CLAVE = @CLAVE, NOMBRE = @NOMBRE, RFC = @RFC, CALLE = @CALLE, NUMINT = @NUMINT, NUMEXT = @NUMEXT, 
            CRUZAMIENTOS = @CRUZAMIENTOS, CRUZAMIENTOS2 = @CRUZAMIENTOS2, COLONIA = @COLONIA, CODIGO = @CODIGO, LOCALIDAD = @LOCALIDAD, MUNICIPIO = @MUNICIPIO,
            ESTADO = @ESTADO, PAIS = @PAIS, NACIONALIDAD = @NACIONALIDAD, REFERDIR = @REFERDIR, TELEFONO = @TELEFONO, CLASIFIC = @CLASIFIC, FAX = @FAX, 
            PAG_WEB = @PAG_WEB, CURP = @CURP, CVE_ZONA = @CVE_ZONA, CVE_BITA = @CVE_BITA, CVE_OBS = @CVE_OBS, USO_CFDI = @USO_CFDI, CVE_PAIS_SAT = @CVE_PAIS_SAT,
            NUMIDREGFISCAL = @NUMIDREGFISCAL, FORMADEPAGOSAT = @FORMADEPAGOSAT, CUEN_CONT = @CUEN_CONT, POLIZARESPCIVIL = @POLIZARESPCIVIL,
            ASEGURARESPCIVIL = @ASEGURARESPCIVIL
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO GCASEGURADORAS (CLAVE, STATUS, NOMBRE, RFC, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, COLONIA, CODIGO, LOCALIDAD, MUNICIPIO,
            ESTADO, PAIS, NACIONALIDAD, REFERDIR, TELEFONO, CLASIFIC, FAX, PAG_WEB, CURP, CVE_ZONA, CVE_BITA, CVE_OBS, USO_CFDI, CVE_PAIS_SAT, NUMIDREGFISCAL,
            FORMADEPAGOSAT, CUEN_CONT, POLIZARESPCIVIL, ASEGURARESPCIVIL) VALUES(@CLAVE, 'A', @NOMBRE, @RFC, @CALLE, @NUMINT, @NUMEXT, @CRUZAMIENTOS,
            @CRUZAMIENTOS2, @COLONIA, @CODIGO, @LOCALIDAD, @MUNICIPIO, @ESTADO, @PAIS, @NACIONALIDAD, @REFERDIR, @TELEFONO, @CLASIFIC, @FAX, @PAG_WEB, 
            @CURP, @CVE_ZONA, @CVE_BITA, @CVE_OBS, @USO_CFDI, @CVE_PAIS_SAT, @NUMIDREGFISCAL, @FORMADEPAGOSAT, @CUEN_CONT, @POLIZARESPCIVIL, @ASEGURARESPCIVIL)"
        cmd.Connection = cnSAE
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLAVE.Text
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Text
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Text
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text
            cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = TNumInt.Text
            cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = TNumExt.Text
            cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = TCRUZAMIENTOS.Text
            cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = TCRUZAMIENTOS2.Text
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = TCODIGO.Text
            cmd.Parameters.Add("@LOCALIDAD", SqlDbType.VarChar).Value = TLOCALIDAD.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMunicipio.Text
            cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = TEstado.Text
            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPais.Text
            cmd.Parameters.Add("@NACIONALIDAD", SqlDbType.VarChar).Value = TNacionalidad.Text
            cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = TREFERDIR.Text
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text
            cmd.Parameters.Add("@CLASIFIC", SqlDbType.VarChar).Value = TClasific.Text
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar).Value = TFax.Text
            cmd.Parameters.Add("@PAG_WEB", SqlDbType.VarChar).Value = TPAG_WEB.Text
            cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = TCURP.Text
            cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = TCVE_ZONA.Text
            cmd.Parameters.Add("@CVE_BITA", SqlDbType.Int).Value = CVE_BITA
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = TUSO_CFDI.Text
            cmd.Parameters.Add("@CVE_PAIS_SAT", SqlDbType.VarChar).Value = TCVE_PAIS_SAT.Text
            cmd.Parameters.Add("@NUMIDREGFISCAL", SqlDbType.VarChar).Value = TNUMIDREGFISCAL.Text
            cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = TFORMADEPAGOSAT.Text
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
            cmd.Parameters.Add("@POLIZARESPCIVIL", SqlDbType.VarChar).Value = TPolizaRespCivil.Text
            cmd.Parameters.Add("@ASEGURARESPCIVIL", SqlDbType.VarChar).Value = TAseguraRespCivil.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
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

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        Try

            If frmClientes.Fg.Row > 1 Then
                CLIENTE = frmClientes.Fg(frmClientes.Fg.Row - 1, 1)
                frmClientes.Fg.Row = frmClientes.Fg.Row - 1
                DESPLEGAR_CLIENTE()
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnInicial_Click(sender As Object, e As EventArgs) Handles BtnInicial.Click
        Try

            If frmClientes.Fg.Row > 0 Then
                CLIENTE = frmClientes.Fg(1, 1)
                frmClientes.Fg.Row = 1
                DESPLEGAR_CLIENTE()
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        Try
            If frmClientes.Fg.Row > 0 Then
                If frmClientes.Fg.Row < frmClientes.Fg.Rows.Count - 1 Then
                    CLIENTE = frmClientes.Fg(frmClientes.Fg.Row + 1, 1)
                    frmClientes.Fg.Row = frmClientes.Fg.Row + 1
                    DESPLEGAR_CLIENTE()
                End If
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles BtnFinal.Click
        Try
            If frmClientes.Fg.Row > 0 Then
                CLIENTE = frmClientes.Fg(frmClientes.Fg.Rows.Count - 1, 1)
                frmClientes.Fg.Row = frmClientes.Fg.Rows.Count - 1
                DESPLEGAR_CLIENTE()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
