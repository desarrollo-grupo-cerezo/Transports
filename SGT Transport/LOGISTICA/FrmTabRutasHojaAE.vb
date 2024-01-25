Imports System.Data.SqlClient
Public Class FrmTabRutasHojaAE
    Public SeActualiza As Boolean
    Private NewRuta As Boolean = False
    Private TIPO_RUTAS As String
    Private SERIE_RE As String = ""
    Private FOLIO_RE As Long = 0
    Private LINEA_TAB_RUTAS As String = ""

    Private Sub FrmTabRutasHojaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Valor As String
        Me.KeyPreview = True
        Me.CenterToScreen()

        For Each tb As TextBox In Controls.OfType(Of TextBox)()

            AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
            AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
        Next

        TIPO_RUTAS = Var10 '= "RE"  = F

        If TIPO_RUTAS = "RE" Then
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(SERIE_RE,'R') AS SER_RE, ISNULL(FOLIO_RE,0) AS FOL_RE 
                        FROM GCPARAMTRANSCG"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            SERIE_RE = dr("SER_RE")
                            FOLIO_RE = dr("FOL_RE") + 1
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If

        Try
            TKM.Value = 0 : TAUTO_SENC.Value = 0 : TSUELDO_FULL.Value = 0 : TSUELDO_SENC.Value = 0
            TTAR_X_TON_FULL.Value = 0 : TTAR_X_VIA_FULL.Value = 0 : TTAR_X_TON_SENC.Value = 0 : TTAR_X_VIA_SENC.Value = 0 : TIMPORTE.Value = 0
            TCIUDAD_O.Tag = "0" : TCIUDAD_D.Tag = "0" : TIMPORTE.Value = 0 : SeActualiza = False
            TLITROS_RUTA.Value = 0 : TTAR_OPER_FULL.Value = 0
            TPORC_SUELDO_FULL.Value = 0 : TPORC_SUELDO_SENC.Value = 0 : TCLI_OP1.Tag = "" : TCLIE_OP.Tag = "" : TCLI_OP2.Tag = "" : TCLIE_OP_O.Tag = "" : tCLI_OP3.Tag = ""
            TCLIE_OP_D.Tag = "" : Lt6.Tag = "" : Lt7.Tag = "" : TDIR_O.Tag = "" : TDIR_D.Tag = "" : TCVE_CXR.Tag = "" : TKM.Tag = "0"
            TAUTO_SENC.Tag = "0" : TSUELDO_FULL.Tag = "0" : TSUELDO_SENC.Tag = "0"
            TTAR_X_VIA_SENC.Tag = "0" : tCVE_GASTO.Tag = ""
            TIMPORTE.Tag = "0" : TCVE_GASOL.Tag = "" : TLITROS_RUTA.Tag = "0"
            TPORC_MANIOBRA_FULL.Value = 0
            TPORC_MANIOBRA_SENC.Value = 0
            TSUELDO_MANIOBRA_FULL.Value = 0
            TSUELDO_MANIOBRA_SENC.Value = 0

            BtnClie_Op2.FlatStyle = FlatStyle.Flat
            BtnClie_Op2.FlatAppearance.BorderSize = 0
            BtnCasetasXRuta.FlatStyle = FlatStyle.Flat
            BtnCasetasXRuta.FlatAppearance.BorderSize = 0
            BtnClie_Op3.FlatStyle = FlatStyle.Flat
            BtnClie_Op3.FlatAppearance.BorderSize = 0
            BtnGastosViaje.FlatStyle = FlatStyle.Flat
            BtnGastosViaje.FlatAppearance.BorderSize = 0
            BtnGasolinera.FlatStyle = FlatStyle.Flat
            BtnGasolinera.FlatAppearance.BorderSize = 0

        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                NewRuta = True

                If TIPO_RUTAS = "RE" Then
                    tCVE_TAB.Text = SERIE_RE & Format(FOLIO_RE, "00000")
                Else
                    tCVE_TAB.Text = GET_MAX_TRY("GCTAB_RUTAS_F", "CVE_TAB")
                End If

                tCVE_TAB.Enabled = False
                TCLI_OP1.Text = ""
                TCLI_OP1.Select()

            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                'SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.NOTA,0) AS C_NOTA
                SQL = "SELECT T.CVE_TAB, T.CLIE_OP, ISNULL(OP1.NOMBRE,'') AS NOM_OP1, 
                    T.CLIE_OP_O, ISNULL(OP2.NOMBRE,'') AS NOM_OP_O, ISNULL(OP2.DOMICILIO,'') AS DOMI_O, ISNULL(OP2.CVE_PLAZA,0) AS CVE_PLAZA_O, 
                    T.CLIE_OP_D, ISNULL(OP3.NOMBRE,'') AS NOM_OP_D, ISNULL(OP3.DOMICILIO,'') AS DOMI_D, ISNULL(OP3.CVE_PLAZA,0) AS CVE_PLAZA_D, 
                    ISNULL(OP2.MUNICIPIO,'') AS CIUDAD_PLA_O, ISNULL(OP3.MUNICIPIO,'') AS CIUDAD_PLA_D, T.CVE_PROD, T.CVE_ART, ISNULL(P.DESCR,'') AS DESCR_PROD, 
                    T.KMS, T.AUTO_SENC, T.P4_SENC, T.FULL_AUTO, T.FULL_P4, T.AUTO_SENC_LTS, T.P4_SENC_LTS, T.FULL_AUTO_LTS, T.FULL_P4_LTS, T.SUELDO_FULL,
                    T.SUELDO_SENC, T.TAR_X_TON_FULL, T.TAR_X_VIA_FULL, T.TAR_X_TON_SENC, T.TAR_X_VIA_SENC, ISNULL(CVE_CASETA,0) AS CVE_CXR, 
                    ISNULL(T.CVE_GAS,0) AS CVEGAS, ISNULL(IMPORTE_GASTO,0) AS IMPORTE_G, ISNULL(CVE_GASOL,'') AS CVE_GASOLI, ISNULL(LITROS_RUTA,0) AS LITROS,
                    TAUTO_SENC_LTS, TP4_SENC_LTS, TFULL_AUTO_LTS, TFULL_P4_LTS, CVE_SUOP, ISNULL(T.SUELDO_X_FACTOR,0) AS SUEL_X_FAC, 
                    ISNULL(T.CVE_TIPO_OPE,0) AS CLAVE_TIPO, ISNULL(PRECIO_X_TANQUE,0) AS PRE_X_TAN, ISNULL(KM_VACIOS,0) AS KM_VAC, 
                    ISNULL(KM_CARGADO,0) AS KM_CAR, TAR_OPER_FULL, PORC_SUELDO_FULL, PORC_SUELDO_SENC, T.DESCR, T.DESCR2, PORC_MANIOBRA_FULL,
                    PORC_MANIOBRA_SENC, SUELDO_MANIOBRA_FULL, SUELDO_MANIOBRA_SENC
                    FROM GCTAB_RUTAS_F T 
                    LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = T.CLIE_OP
                    LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                    LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                    LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = T.CVE_PROD
                    LEFT JOIN GCTIPO_OPERACION TP ON TP.CVE_TIPO = T.CVE_TIPO_OPE
                    WHERE CVE_TAB = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_TAB.Text = Var2
                    Try
                        tCVE_GASTO.Text = dr("CVEGAS")
                        If tCVE_GASTO.Text = "0" Then
                            tCVE_GASTO.Text = ""
                        End If
                        If tCVE_GASTO.Text.Trim.Length > 0 Then
                            LtGastos.Text = BUSCA_CAT("GCConc", tCVE_GASTO.Text)
                        End If
                        TIMPORTE.Value = dr("IMPORTE_G")

                        TCVE_GASOL.Text = dr("CVE_GASOLI")
                        If TCVE_GASOL.Text = "0" Then TCVE_GASOL.Text = ""
                        If TCVE_GASOL.Text.Trim.Length > 0 Then
                            LtGasolinera.Text = BUSCA_CAT("Gasolinera", TCVE_GASOL.Text)
                        End If

                        TLITROS_RUTA.Value = dr("LITROS")

                        TTAR_OPER_FULL.Value = dr.ReadNullAsEmptyDecimal("TAR_OPER_FULL")
                        TPORC_SUELDO_FULL.Value = dr.ReadNullAsEmptyDecimal("PORC_SUELDO_FULL")
                        TPORC_SUELDO_SENC.Value = dr.ReadNullAsEmptyDecimal("PORC_SUELDO_SENC")

                        TDESCR.Text = dr.ReadNullAsEmptyString("DESCR")
                        TDESCR2.Text = dr.ReadNullAsEmptyString("DESCR2")

                        TPORC_MANIOBRA_FULL.Value = dr.ReadNullAsEmptyDecimal("PORC_MANIOBRA_FULL")
                        TPORC_MANIOBRA_SENC.Value = dr.ReadNullAsEmptyDecimal("PORC_MANIOBRA_SENC")
                        TSUELDO_MANIOBRA_FULL.Value = dr.ReadNullAsEmptyDecimal("SUELDO_MANIOBRA_FULL")
                        TSUELDO_MANIOBRA_SENC.Value = dr.ReadNullAsEmptyDecimal("SUELDO_MANIOBRA_SENC")

                    Catch ex As Exception
                        Bitacora("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    TCLI_OP1.Text = dr("CLIE_OP").ToString
                    TCLIE_OP.Text = BUSCA_CAT("Cliente", TCLI_OP1.Text, False)

                    'TCLIE_OP.Text = dr("NOM_OP1").ToString

                    TCLI_OP2.Text = dr("CLIE_OP_O").ToString
                    TCLIE_OP_O.Text = dr.ReadNullAsEmptyString("NOM_OP_O").ToString

                    tCLI_OP3.Text = dr("CLIE_OP_D").ToString
                    TCLIE_OP_D.Text = dr.ReadNullAsEmptyString("NOM_OP_D").ToString

                    TCIUDAD_O.Tag = dr("CVE_PLAZA_O").ToString
                    TCIUDAD_O.Text = dr.ReadNullAsEmptyString("CIUDAD_PLA_O")

                    TCIUDAD_D.Tag = dr("CVE_PLAZA_D").ToString
                    TCIUDAD_D.Text = dr.ReadNullAsEmptyString("CIUDAD_PLA_D")

                    TDIR_O.Text = dr.ReadNullAsEmptyString("DOMI_O").ToString
                    TDIR_D.Text = dr.ReadNullAsEmptyString("DOMI_D").ToString


                    TKM.Value = dr.ReadNullAsEmptyDecimal("KMS")
                    TAUTO_SENC.Value = dr.ReadNullAsEmptyDecimal("AUTO_SENC")

                    LtAUTO_SENC_LTS.Text = Format(dr.ReadNullAsEmptyDecimal("AUTO_SENC_LTS"), "###,###,##0")

                    TSUELDO_FULL.Value = dr.ReadNullAsEmptyDecimal("SUELDO_FULL")
                    TSUELDO_SENC.Value = dr.ReadNullAsEmptyDecimal("SUELDO_SENC")

                    Try
                        Valor = QUERY_GET_DATO("GCTARIFAS", "PRECIO", "CVE_RUTA", "CVE_ART", "CVE_PRECIO", tCVE_TAB.Text, "", 1, True)
                        Valor = QUERY_GET_DATO("GCTARIFAS", "PRECIO", "CVE_RUTA", "CVE_ART", "CVE_PRECIO", tCVE_TAB.Text, "", 3, True)
                        Valor = QUERY_GET_DATO("GCTARIFAS", "PRECIO", "CVE_RUTA", "CVE_ART", "CVE_PRECIO", tCVE_TAB.Text, "", 4, True)
                        Valor = QUERY_GET_DATO("GCTARIFAS", "PRECIO", "CVE_RUTA", "CVE_ART", "CVE_PRECIO", tCVE_TAB.Text, "", 5, True)

                        TTAR_X_TON_FULL.Value = dr("TAR_X_TON_FULL")
                        TTAR_X_VIA_FULL.Value = dr("TAR_X_VIA_FULL")
                        TTAR_X_TON_SENC.Value = dr("TAR_X_TON_SENC")
                        TTAR_X_VIA_SENC.Value = dr("TAR_X_VIA_SENC")

                        TCVE_CXR.Text = dr("CVE_CXR")
                        If TCVE_CXR.Text = "0" Then TCVE_CXR.Text = ""
                        If TCVE_CXR.Text.Trim.Length > 0 Then
                            LtCaseXRuta.Text = BUSCA_CAT("GCCASETAS_X_RUTA", TCVE_CXR.Text)
                        End If

                        TCLI_OP1.Tag = TCLI_OP1.Text
                        TCLIE_OP.Tag = TCLIE_OP.Text
                        TCLI_OP2.Tag = TCLI_OP2.Text
                        TCLIE_OP_O.Tag = TCLIE_OP_O.Text
                        tCLI_OP3.Tag = tCLI_OP3.Text
                        TCLIE_OP_D.Tag = TCLIE_OP_D.Text

                        Lt6.Tag = TCIUDAD_O.Text
                        Lt7.Tag = TCIUDAD_D.Text
                        TDIR_O.Tag = TDIR_O.Text
                        TDIR_D.Tag = TDIR_D.Text
                        TCVE_CXR.Tag = TCVE_CXR.Text
                        TKM.Tag = TKM.Value
                        TAUTO_SENC.Tag = TAUTO_SENC.Value
                        TSUELDO_FULL.Tag = TSUELDO_FULL.Value
                        TSUELDO_SENC.Tag = TSUELDO_SENC.Value
                        TTAR_X_VIA_SENC.Tag = TTAR_X_VIA_SENC.Value

                        tCVE_GASTO.Tag = tCVE_GASTO.Text
                        TIMPORTE.Tag = TIMPORTE.Value
                        TCVE_GASOL.Tag = TCVE_GASOL.Text
                        TLITROS_RUTA.Tag = TLITROS_RUTA.Value
                    Catch ex As Exception
                        Bitacora("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Else
                    TCLI_OP1.Text = "" : TCLI_OP2.Text = "" : tCLI_OP3.Text = "" : TCIUDAD_O.Text = 0 : TCIUDAD_O.Text = 0 : TDIR_O.Text = "" : TDIR_D.Text = ""
                    TKM.Value = 0 : TAUTO_SENC.Value = 0 : LtAUTO_SENC_LTS.Text = 0
                    TSUELDO_FULL.Value = 0 : TSUELDO_SENC.Value = 0 : TTAR_X_TON_FULL.Value = 0
                    TTAR_X_VIA_FULL.Value = 0 : TTAR_X_TON_SENC.Value = 0 : TTAR_X_VIA_SENC.Value = 0
                End If
                dr.Close()
                tCVE_TAB.Enabled = False
                TCLI_OP1.Focus()
            Catch ex As Exception
                MsgBox("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("40. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        DERECHOS()

        SeActualiza = True
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try 'AZUL Color.LemonChiffon
            sender.BackColor = Color.FromArgb(176, 240, 0)
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Dim z As Integer = 0

            Try
                TCLI_OP1.Visible = False
                BtnClie_Op1.Visible = False

                TCLIE_OP.Visible = False

                TCLI_OP2.Visible = False
                BtnClie_Op2.Visible = False

                TCLIE_OP_O.Visible = False
                TCIUDAD_O.Visible = False
                TDIR_O.Visible = False

                tCLI_OP3.Visible = False
                BtnClie_Op3.Visible = False

                TCLIE_OP_D.Visible = False
                TCIUDAD_D.Visible = False
                TDIR_D.Visible = False

                TDESCR.Visible = False

                TCVE_CXR.Visible = False
                BtnCasetasXRuta.Visible = False
                LtCaseXRuta.Visible = False

                TKM.Visible = False
                TAUTO_SENC.Visible = False
                LtAUTO_SENC_LTS.Visible = False
                TSUELDO_FULL.Visible = False
                TSUELDO_SENC.Visible = False
                TTAR_X_TON_FULL.Visible = False
                TTAR_X_VIA_FULL.Visible = False
                TTAR_X_TON_SENC.Visible = False
                TTAR_X_VIA_SENC.Visible = False

                tCVE_GASTO.Visible = False
                BtnGastosViaje.Visible = False
                LtGastos.Visible = False
                TIMPORTE.Visible = False

                TCVE_GASOL.Visible = False
                LtGasolinera.Visible = False
                TLITROS_RUTA.Visible = False
                TTAR_OPER_FULL.Visible = False
                TPORC_SUELDO_FULL.Visible = False
                TPORC_SUELDO_SENC.Visible = False
                BtnGasolinera.Visible = False


            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    (CLAVE >= 14520 AND CLAVE < 14800)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            z += 1
                            Select Case dr("CLAVE")
                                Case 14520  'CLAVE CONTRATO
                                Case 14530  'CLIENTE
                                    TCLI_OP1.Visible = True
                                    BtnClie_Op1.Visible = True

                                Case 14540  'PLANTA ORGIGEN
                                    TCLIE_OP.Visible = True
                                Case 14550  'CLIENTE
                                    TCLI_OP2.Visible = True
                                    BtnClie_Op2.Visible = True
                                Case 14560  'CIUDAD ORIGEN
                                    TCLIE_OP_O.Visible = True
                                Case 14570  'DIRECCION ORIGEN
                                    TCIUDAD_O.Visible = True
                                Case 14580  'PLANTA DESTINO
                                    TDIR_O.Visible = True
                                Case 14590  'CIUDAD DESTINO
                                    tCLI_OP3.Visible = True
                                    BtnClie_Op3.Visible = True
                                Case 14600  'CIUDAD ORIGEN
                                    TCLIE_OP_D.Visible = True
                                Case 14610  'DIRECCION DESTINO
                                    TCIUDAD_D.Visible = True
                                Case 14620  'PRODUCTO
                                    TDIR_D.Visible = True
                                Case 14635  'ARTICULO INVENTARIO
                                Case 14630  'CASETAS X RUTA
                                    TDESCR.Visible = True
                                Case 14640  'KM
                                    TCVE_CXR.Visible = True
                                    BtnCasetasXRuta.Visible = True
                                    LtCaseXRuta.Visible = True
                                Case 14650  'AUTONOMOSENCILLO
                                    TKM.Visible = True
                                Case 14660  'P4 SENCILLO
                                    TAUTO_SENC.Visible = True
                                    LtAUTO_SENC_LTS.Visible = True
                                Case 14670  'FULL AUTONOMO
                                Case 14680  'FULL P4
                                Case 14690  'SUELDO FULL
                                Case 14700  'SUELDO SENCILLO
                                    TSUELDO_FULL.Visible = True
                                Case 14710  '
                                    TSUELDO_SENC.Visible = True
                                Case 14720  'TARIFA X TONELADA FULL
                                    TTAR_X_TON_FULL.Visible = True
                                Case 14730  'TARIFA X VIAJE FULL
                                    TTAR_X_VIA_FULL.Visible = True
                                Case 14740  'TARIFA X TONELADA SENCILLO
                                    TTAR_X_TON_SENC.Visible = True
                                Case 14750  'TARIFA X VIAJE SENCILLO
                                    TTAR_X_VIA_SENC.Visible = True
                                Case 14760  'GASTOS DE VIAJE
                                    tCVE_GASTO.Visible = True
                                    BtnGastosViaje.Visible = True
                                    LtGastos.Visible = True
                                Case 14770  'IMPORTE
                                    TIMPORTE.Visible = True
                                Case 14775  '
                                    TCVE_GASOL.Visible = True
                                    BtnGasolinera.Visible = True
                                    LtGasolinera.Visible = True
                                Case 14780  '
                                    TTAR_OPER_FULL.Visible = True
                                Case 14785  '
                                    TPORC_SUELDO_FULL.Visible = True
                                Case 14790  '
                                    TPORC_SUELDO_SENC.Visible = True
                                Case 14795  '
                                    TLITROS_RUTA.Visible = True
                            End Select
                        End While
                    End Using
                End Using
                If z = 0 Then

                    TCLI_OP1.Visible = True
                    BtnClie_Op1.Visible = True

                    TCLIE_OP.Visible = True

                    TCLI_OP2.Visible = True
                    BtnClie_Op2.Visible = True

                    TCLIE_OP_O.Visible = True
                    TCIUDAD_O.Visible = True
                    TDIR_O.Visible = True

                    tCLI_OP3.Visible = True
                    BtnClie_Op3.Visible = True

                    TCLIE_OP_D.Visible = True
                    TCIUDAD_D.Visible = True
                    TDIR_D.Visible = True

                    TKM.Visible = True
                    TAUTO_SENC.Visible = True
                    LtAUTO_SENC_LTS.Visible = True


                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmTabRutasHojaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnClie_Op1_Click(sender As Object, e As EventArgs) Handles BtnClie_Op1.Click
        Try

            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'CLAVE 
                'Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                'Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                'Var7 = Fg(Fg.Row, 4).ToString 'domicilio cliente op
                TCLI_OP1.Text = Var4
                TCLIE_OP.Text = Var5

                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            TCLI_OP2.Focus()
        Catch ex As Exception
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLI_OP1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLI_OP1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Op1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLI_OP1_Validated(sender As Object, e As EventArgs) Handles TCLI_OP1.Validated
        Try
            If TCLI_OP1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                TCLI_OP1.Text = TCLI_OP1.Text.Trim.Replace(" ", "")

                If IsNumeric(TCLI_OP1.Text.Trim) Then
                    TCLI_OP1.Text = Space(10 - TCLI_OP1.Text.Trim.Length) & TCLI_OP1.Text.Trim
                End If
                DESCR = BUSCA_CAT("Cliente", TCLI_OP1.Text, False)
                If DESCR <> "" Then
                    TCLIE_OP.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIE_OP.Text = ""
                End If
            Else
                TCLIE_OP.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnClie_Op2_Click(sender As Object, e As EventArgs) Handles BtnClie_Op2.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = ""
            Var8 = "R"

            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.MUNICIPIO,0) AS C_NOTA
                'Var4 = Fg(Fg.Row, 1) 'CLAVE 
                'Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                'Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                'Var7 = Fg(Fg.Row, 4).ToString 'domicilio cliente op
                TCLI_OP2.Text = Var4
                TCLIE_OP_O.Text = Var5
                TCIUDAD_O.Text = Var4
                TDIR_O.Text = Var6
                TCIUDAD_O.Tag = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            tCLI_OP3.Focus()
        Catch ex As Exception
            MsgBox("1700. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLI_OP2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLI_OP2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Op2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLI_OP2_Validated(sender As Object, e As EventArgs) Handles TCLI_OP2.Validated
        Try
            If TCLI_OP2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente operativo", TCLI_OP2.Text, False)
                If DESCR <> "" Then

                    TCLIE_OP_O.Text = DESCR
                    TCIUDAD_O.Text = Var6
                    TDIR_O.Text = Var7
                    TCIUDAD_O.Tag = Var8
                Else
                    MsgBox("Cliente inexistente")
                    TCLI_OP2.Text = ""
                End If
            Else
                TCLI_OP2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnClie_Op3_Click(sender As Object, e As EventArgs) Handles BtnClie_Op3.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = ""
            Var8 = "D"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'SELECT C.CLAVE, C.NOMBRE, C.DOMICILIO, ISNULL(C.MUNICIPIO,0) AS C_NOTA
                'Var4 = Fg(Fg.Row, 1) 'CLAVE 
                'Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                'Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                'Var7 = Fg(Fg.Row, 4).ToString 'domicilio cliente op
                tCLI_OP3.Text = Var4
                TCLIE_OP_D.Text = Var5
                TCIUDAD_D.Text = Var7
                TDIR_D.Text = Var6
                TCIUDAD_D.Tag = Var7
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            TCIUDAD_O.Focus()
        Catch ex As Exception
            MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLI_OP3_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLI_OP3.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Op3_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLI_OP3_Validated(sender As Object, e As EventArgs) Handles tCLI_OP3.Validated
        Try
            If tCLI_OP3.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente operativo", tCLI_OP3.Text, False)
                If DESCR <> "" Then
                    'Var4 = dr("CLAVE") 'CLAVE 
                    'Var5 = dr("NOMBRE") 'nombre cliente operativo
                    'Var6 = dr("NOTA") 'plaza ciudad
                    'Var7 = dr("DOMICILIO") 'domicilio cliente op

                    TCLIE_OP_D.Text = DESCR
                    TCIUDAD_D.Text = Var6
                    TDIR_D.Text = Var7
                    TCIUDAD_D.Tag = Var8
                Else
                    MsgBox("Cliente inexistente")
                    tCLI_OP3.Text = ""
                End If
            Else
                tCLI_OP3.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim AUTO_SENC_LTS As Decimal = 0, P4_SENC_LTS As Decimal = 0, FULL_AUTO_LTS As Decimal = 0, FULL_P4_LTS As Decimal = 0
        Dim CVE_TAB_RE As String

        Try
            TKM.UpdateValueWithCurrentText()
            TAUTO_SENC.UpdateValueWithCurrentText()
            TSUELDO_FULL.UpdateValueWithCurrentText()
            TSUELDO_SENC.UpdateValueWithCurrentText()
            TTAR_X_TON_FULL.UpdateValueWithCurrentText()
            TTAR_X_VIA_FULL.UpdateValueWithCurrentText()
            TTAR_X_TON_SENC.UpdateValueWithCurrentText()
            TTAR_X_VIA_SENC.UpdateValueWithCurrentText()
            TIMPORTE.UpdateValueWithCurrentText()

            TTAR_OPER_FULL.UpdateValueWithCurrentText()
            TPORC_SUELDO_FULL.UpdateValueWithCurrentText()
            TPORC_SUELDO_SENC.UpdateValueWithCurrentText()

            TPORC_MANIOBRA_FULL.UpdateValueWithCurrentText()
            TPORC_MANIOBRA_SENC.UpdateValueWithCurrentText()
            TSUELDO_MANIOBRA_FULL.UpdateValueWithCurrentText()
            TSUELDO_MANIOBRA_SENC.UpdateValueWithCurrentText()
        Catch ex As Exception
            Bitacora("1820. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If TKM.Value = 0 Then
            MsgBox("Falta por capturar los Kilómetros, favor de verificar", MsgBoxStyle.Information)
            Return
        End If

        CALCULO1()

        Try
            If IsNumeric(LtAUTO_SENC_LTS.Text.Replace(",", "")) Then AUTO_SENC_LTS = LtAUTO_SENC_LTS.Text.Replace(",", "")

            TLITROS_RUTA.UpdateValueWithCurrentText()

        Catch ex As Exception
            Bitacora("1820. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If TIPO_RUTAS = "RE" Then
            If NewRuta Then
                CVE_TAB_RE = SERIE_RE & Format(FOLIO_RE, "00000")
                Try
                    Dim SIGUE As Boolean = True

                    Do While SIGUE
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT CVE_TAB FROM GCTAB_RUTAS_F WHERE CVE_TAB = '" & CVE_TAB_RE & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    FOLIO_RE += 1
                                    CVE_TAB_RE = SERIE_RE & Format(FOLIO_RE, "00000")
                                Else
                                    SIGUE = False
                                End If
                            End Using
                        End Using
                    Loop
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            Else
                CVE_TAB_RE = tCVE_TAB.Text
            End If
        Else
            CVE_TAB_RE = tCVE_TAB.Text
        End If

        Try
            SQL = "IF EXISTS (SELECT CVE_TAB FROM GCTAB_RUTAS_F WHERE CVE_TAB = @CVE_TAB)
                UPDATE GCTAB_RUTAS_F SET CLIE_OP = @CLIE_OP, CLIE_OP_O = @CLIE_OP_O, CLIE_OP_D = @CLIE_OP_D, 
                CVE_PROD = @CVE_PROD, CVE_ART = @CVE_ART, KMS = @KMS, AUTO_SENC = @AUTO_SENC, P4_SENC = @P4_SENC, 
                FULL_AUTO = @FULL_AUTO, FULL_P4 = @FULL_P4, SUELDO_FULL = @SUELDO_FULL, SUELDO_SENC = @SUELDO_SENC, 
                TAR_X_TON_FULL = @TAR_X_TON_FULL, TAR_X_VIA_FULL = @TAR_X_VIA_FULL, TAR_X_TON_SENC = @TAR_X_TON_SENC, 
                TAR_X_VIA_SENC = @TAR_X_VIA_SENC, CVE_CASETA = @CVE_CASETA, AUTO_SENC_LTS = @AUTO_SENC_LTS, 
                P4_SENC_LTS = @P4_SENC_LTS, FULL_AUTO_LTS = @FULL_AUTO_LTS, FULL_P4_LTS = @FULL_P4_LTS, CVE_GAS = @CVE_GAS, 
                IMPORTE_GASTO = @IMPORTE_GASTO, CVE_GASOL = @CVE_GASOL, LITROS_RUTA = @LITROS_RUTA, TAUTO_SENC_LTS = @TAUTO_SENC_LTS, 
                TP4_SENC_LTS = @TP4_SENC_LTS, TFULL_AUTO_LTS = @TFULL_AUTO_LTS, TFULL_P4_LTS = @TFULL_P4_LTS, CVE_SUOP = @CVE_SUOP, 
                SUELDO_X_FACTOR = @SUELDO_X_FACTOR, CVE_TIPO_OPE = @CVE_TIPO_OPE,PRECIO_X_TANQUE = @PRECIO_X_TANQUE,
                KM_VACIOS = @KM_VACIOS, KM_CARGADO = @KM_CARGADO, TAR_OPER_FULL = @TAR_OPER_FULL, PORC_SUELDO_FULL = @PORC_SUELDO_FULL, 
                PORC_SUELDO_SENC = @PORC_SUELDO_SENC, DESCR = @DESCR, DESCR2 = @DESCR2, PORC_MANIOBRA_FULL = @PORC_MANIOBRA_FULL,
                PORC_MANIOBRA_SENC = @PORC_MANIOBRA_SENC, SUELDO_MANIOBRA_FULL = @SUELDO_MANIOBRA_FULL, SUELDO_MANIOBRA_SENC = @SUELDO_MANIOBRA_SENC
                WHERE CVE_TAB = @CVE_TAB 
                ELSE
                INSERT INTO GCTAB_RUTAS_F (CVE_TAB, STATUS, FECHA, CLIE_OP, CLIE_OP_O, CLIE_OP_D, CVE_PROD, CVE_ART, KMS, 
                AUTO_SENC, P4_SENC, FULL_AUTO, FULL_P4, SUELDO_FULL, SUELDO_SENC, TAR_X_TON_FULL, TAR_X_VIA_FULL, TAR_X_TON_SENC, 
                TAR_X_VIA_SENC, CVE_CASETA, AUTO_SENC_LTS, P4_SENC_LTS, FULL_AUTO_LTS, FULL_P4_LTS, CVE_GAS, IMPORTE_GASTO, CVE_GASOL, 
                LITROS_RUTA, TAUTO_SENC_LTS, TP4_SENC_LTS, TFULL_AUTO_LTS, TFULL_P4_LTS, CVE_SUOP, SUELDO_X_FACTOR, CVE_TIPO_OPE, 
                PRECIO_X_TANQUE, SERIE_RE, KM_VACIOS, KM_CARGADO, UUID, FECHAELAB, DESCR, DESCR2, TAR_OPER_FULL, PORC_SUELDO_FULL, 
                PORC_SUELDO_SENC, PORC_MANIOBRA_FULL, PORC_MANIOBRA_SENC, SUELDO_MANIOBRA_FULL, SUELDO_MANIOBRA_SENC) 
                VALUES (
                @CVE_TAB, 'A', CONVERT(varchar, GETDATE(), 112), @CLIE_OP, @CLIE_OP_O, @CLIE_OP_D, @CVE_PROD, @CVE_ART, @KMS, 
                @AUTO_SENC, @P4_SENC, @FULL_AUTO, @FULL_P4, @SUELDO_FULL, @SUELDO_SENC, @TAR_X_TON_FULL, @TAR_X_VIA_FULL, @TAR_X_TON_SENC,
                @TAR_X_VIA_SENC, @CVE_CASETA, @AUTO_SENC_LTS, @P4_SENC_LTS, @FULL_AUTO_LTS, @FULL_P4_LTS, @CVE_GAS, @IMPORTE_GASTO, 
                @CVE_GASOL, @LITROS_RUTA, @TAUTO_SENC_LTS, @TP4_SENC_LTS, @TFULL_AUTO_LTS, @TFULL_P4_LTS, @CVE_SUOP, @SUELDO_X_FACTOR, 
                @CVE_TIPO_OPE, @PRECIO_X_TANQUE, @SERIE_RE, @KM_VACIOS, @KM_CARGADO, NEWID(), GETDATE(), @DESCR, @DESCR2, @TAR_OPER_FULL, 
                @PORC_SUELDO_FULL, @PORC_SUELDO_SENC, @PORC_MANIOBRA_FULL, @PORC_MANIOBRA_SENC, @SUELDO_MANIOBRA_FULL, @SUELDO_MANIOBRA_SENC)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = CVE_TAB_RE
                cmd.Parameters.Add("@CLIE_OP", SqlDbType.VarChar).Value = TCLI_OP1.Text
                cmd.Parameters.Add("@CLIE_OP_O", SqlDbType.VarChar).Value = TCLI_OP2.Text
                cmd.Parameters.Add("@CLIE_OP_D", SqlDbType.VarChar).Value = tCLI_OP3.Text


                cmd.Parameters.Add("@CVE_PROD", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = ""
                cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = TKM.Value
                cmd.Parameters.Add("@AUTO_SENC", SqlDbType.Float).Value = TAUTO_SENC.Value
                cmd.Parameters.Add("@P4_SENC", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@FULL_AUTO", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@FULL_P4", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@SUELDO_FULL", SqlDbType.Float).Value = TSUELDO_FULL.Value
                cmd.Parameters.Add("@SUELDO_SENC", SqlDbType.Float).Value = TSUELDO_SENC.Value

                cmd.Parameters.Add("@AUTO_SENC_LTS", SqlDbType.Float).Value = AUTO_SENC_LTS
                cmd.Parameters.Add("@P4_SENC_LTS", SqlDbType.Float).Value = P4_SENC_LTS
                cmd.Parameters.Add("@FULL_AUTO_LTS", SqlDbType.Float).Value = FULL_AUTO_LTS
                cmd.Parameters.Add("@FULL_P4_LTS", SqlDbType.Float).Value = FULL_P4_LTS
                cmd.Parameters.Add("@TAUTO_SENC_LTS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@TP4_SENC_LTS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@TFULL_AUTO_LTS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@TFULL_P4_LTS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@TAR_X_TON_FULL", SqlDbType.Float).Value = TTAR_X_TON_FULL.Value
                cmd.Parameters.Add("@TAR_X_VIA_FULL", SqlDbType.Float).Value = TTAR_X_VIA_FULL.Value
                cmd.Parameters.Add("@TAR_X_TON_SENC", SqlDbType.Float).Value = TTAR_X_TON_SENC.Value
                cmd.Parameters.Add("@TAR_X_VIA_SENC", SqlDbType.Float).Value = TTAR_X_VIA_SENC.Value
                cmd.Parameters.Add("@CVE_CASETA", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_CXR.Text)
                cmd.Parameters.Add("@CVE_GAS", SqlDbType.Int).Value = CONVERTIR_TO_LONG(tCVE_GASTO.Text)
                cmd.Parameters.Add("@IMPORTE_GASTO", SqlDbType.Float).Value = TIMPORTE.Value
                cmd.Parameters.Add("@CVE_GASOL", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_GASOL.Text)
                cmd.Parameters.Add("@LITROS_RUTA", SqlDbType.Float).Value = TLITROS_RUTA.Value
                cmd.Parameters.Add("@CVE_SUOP", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@SUELDO_X_FACTOR", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@CVE_TIPO_OPE", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@PRECIO_X_TANQUE", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@SERIE_RE", SqlDbType.VarChar).Value = SERIE_RE
                cmd.Parameters.Add("@KM_VACIOS", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@KM_CARGADO", SqlDbType.Float).Value = 0
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
                cmd.Parameters.Add("@DESCR2", SqlDbType.VarChar).Value = TDESCR2.Text
                cmd.Parameters.Add("@TAR_OPER_FULL", SqlDbType.Float).Value = TTAR_OPER_FULL.Value
                cmd.Parameters.Add("@PORC_SUELDO_FULL", SqlDbType.Float).Value = TPORC_SUELDO_FULL.Value
                cmd.Parameters.Add("@PORC_SUELDO_SENC", SqlDbType.Float).Value = TPORC_SUELDO_SENC.Value

                cmd.Parameters.Add("@PORC_MANIOBRA_FULL", SqlDbType.Float).Value = TPORC_MANIOBRA_FULL.Value
                cmd.Parameters.Add("@PORC_MANIOBRA_SENC", SqlDbType.Float).Value = TPORC_MANIOBRA_SENC.Value
                cmd.Parameters.Add("@SUELDO_MANIOBRA_FULL", SqlDbType.Float).Value = TSUELDO_MANIOBRA_FULL.Value
                cmd.Parameters.Add("@SUELDO_MANIOBRA_SENC", SqlDbType.Float).Value = TSUELDO_MANIOBRA_SENC.Value

                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        If NewRuta Then
                            If TIPO_RUTAS = "RE" Then
                                Try
                                    SQL = "UPDATE GCPARAMTRANSCG SET FOLIO_RE = " & FOLIO_RE
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try
                            End If
                        End If

                        EXECUTE_QUERY_NET("DELETE FROM GCTARIFAS WHERE CVE_RUTA = '" & tCVE_TAB.Text & "'")

                        ''MODIFICANDO CONTRATO Y CLIENTE OP ORIGEN
                        If TCLI_OP1.Text.Trim.Length > 0 And TCLIE_OP.Text.Trim.Length > 0 Then
                            'NOMBRE CLIENTE
                            EXECUTE_QUERY_NET("UPDATE GCCLIE_OP SET NOMBRE = '" & TCLIE_OP.Text & "' WHERE CLAVE = '" & TCLI_OP1.Text & "'")
                        End If
                        'CLIENTE OP ORIGEN
                        If TCLI_OP2.Text.Trim.Length > 0 And TCLIE_OP_O.Text.Trim.Length > 0 Then
                            EXECUTE_QUERY_NET("UPDATE GCCLIE_OP SET NOMBRE = '" & TCLIE_OP_O.Text & "', MUNICIPIO = '" & TCIUDAD_O.Text & "', 
                                            DOMICILIO = '" & TDIR_O.Text & "'  WHERE CLAVE = '" & TCLI_OP2.Text & "'")
                        End If
                        'CLIENTE OP DESTINO
                        If tCLI_OP3.Text.Trim.Length > 0 And TCLIE_OP_D.Text.Trim.Length > 0 Then
                            EXECUTE_QUERY_NET("UPDATE GCCLIE_OP SET NOMBRE = '" & TCLIE_OP_D.Text & "', DOMICILIO = '" & TDIR_D.Text & "', 
                                            MUNICIPIO = '" & TCIUDAD_D.Text & "' WHERE CLAVE = '" & tCLI_OP3.Text & "'")
                        End If

                        GRABA_SUELDOS()

                        Try
                            If Not NewRuta Then
                                'INICIO GRABADO DE BITACORAS
                                If TCLI_OP1.Tag <> TCLI_OP1.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio cliente " & TCLI_OP1.Tag & " por " & TCLI_OP1.Text, tCVE_TAB.Text)
                                If TCLIE_OP.Tag <> TCLIE_OP.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio nombre cliente " & TCLIE_OP.Tag & " por " & TCLIE_OP.Text, tCVE_TAB.Text)
                                If TCLI_OP2.Tag <> TCLI_OP2.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio planta origen " & TCLI_OP2.Tag & " por " & TCLI_OP2.Text, tCVE_TAB.Text)
                                If TCLIE_OP_O.Tag <> TCLIE_OP_O.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio nombre planta origen " & TCLIE_OP_O.Tag & " por " & TCLIE_OP_O.Text, tCVE_TAB.Text)
                                If tCLI_OP3.Tag <> tCLI_OP3.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio planta destino " & tCLI_OP3.Tag & " por " & tCLI_OP3.Text, tCVE_TAB.Text)
                                If TCLIE_OP_D.Tag <> TCLIE_OP_D.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio nombre planta destino " & TCLIE_OP_D.Tag & " por " & TCLIE_OP_D.Text, tCVE_TAB.Text)
                                If Lt6.Tag <> TCIUDAD_O.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio ciudad origen " & Lt6.Tag & " por " & TCIUDAD_O.Text, tCVE_TAB.Text)
                                If Lt7.Tag <> TCIUDAD_D.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio ciudad destino " & Lt7.Tag & " por " & TCIUDAD_D.Text, tCVE_TAB.Text)
                                If TDIR_O.Tag <> TDIR_O.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio dirección origen " & TDIR_O.Tag & " por " & TDIR_O.Text, tCVE_TAB.Text)
                                If TDIR_D.Tag <> TDIR_D.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio dirección destino " & TDIR_D.Tag & " por " & TDIR_D.Text, tCVE_TAB.Text)
                                If TCVE_CXR.Tag <> TCVE_CXR.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio caseta por ruta " & TCVE_CXR.Tag & " por " & TCVE_CXR.Text, tCVE_TAB.Text)
                                If TKM.Tag <> TKM.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio KM " & TKM.Tag & " por " & TKM.Text, tCVE_TAB.Text)
                                If TAUTO_SENC.Tag <> TAUTO_SENC.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio autónomo sencillo " & TAUTO_SENC.Tag & " por " & TAUTO_SENC.Text, tCVE_TAB.Text)

                                If TSUELDO_FULL.Tag <> TSUELDO_FULL.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio sueldo Full " & TSUELDO_FULL.Tag & " por " & TSUELDO_FULL.Text, tCVE_TAB.Text)
                                If TSUELDO_SENC.Tag <> TSUELDO_SENC.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio sueldo Sencillo " & TSUELDO_SENC.Tag & "por " & TSUELDO_SENC.Text, tCVE_TAB.Text)
                                If TTAR_X_VIA_SENC.Tag <> TTAR_X_VIA_SENC.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio tarifa viaje sencillo " & TTAR_X_VIA_SENC.Tag & " por " & TTAR_X_VIA_SENC.Text, tCVE_TAB.Text)
                                If tCVE_GASTO.Tag <> tCVE_GASTO.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio gastos de viaje " & tCVE_GASTO.Tag & " por " & tCVE_GASTO.Text, tCVE_TAB.Text)
                                If TIMPORTE.Tag <> TIMPORTE.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio importe " & TIMPORTE.Tag & " por " & TIMPORTE.Text, tCVE_TAB.Text)
                                If TCVE_GASOL.Tag <> TCVE_GASOL.Text Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio gasolinera " & TCVE_GASOL.Tag & " por " & TCVE_GASOL.Text, tCVE_TAB.Text)
                                If TLITROS_RUTA.Tag <> TLITROS_RUTA.Value Then GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A",
                                   "Se Cambio litros por ruta " & TLITROS_RUTA.Tag & " por " & TLITROS_RUTA.Text, tCVE_TAB.Text)
                            Else
                                GRABA_BITA(tCVE_TAB.Text, tCVE_TAB.Text, 0, "A", "Alta tabulador de ruta con CLAVE=" & tCVE_TAB.Text)
                            End If
                        Catch ex As Exception
                            Bitacora("2000. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If
                End If
            End Using
            MsgBox("La ruta se grabo correctamente")

            Me.Close()

        Catch ex As Exception
            MsgBox("2000. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("2000. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABA_SUELDOS()
        Dim CVE_PLAZA1 As String = "", CVE_PLAZA2 As String = ""
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            If IsNothing(TCIUDAD_O.Tag) Then
                CVE_PLAZA1 = ""
            Else
                CVE_PLAZA1 = TCIUDAD_O.Tag
            End If
            If IsNothing(TCIUDAD_D.Tag) Then
                CVE_PLAZA2 = ""
            Else
                CVE_PLAZA2 = TCIUDAD_D.Tag
            End If
        Catch ex As Exception
            MsgBox("1980. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("1980. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        SQL = "UPDATE GCSUELDO_OPER SET CLAVE_O = @CLAVE_O, CVE_TAB = @CVE_TAB, PLAZA_O = @PLAZA_O, PLAZA_D = @PLAZA_D, 
            TIPO_FULL_SENCILLO = @TIPO_FULL_SENCILLO, TIPO_CARGADO_VACIO = @TIPO_CARGADO_VACIO, SUELDO = @SUELDO, SUELDO_SENC = @SUELDO_SENC, 
            OBSER = @OBSER
            WHERE CVE_TAB = @CVE_TAB
            IF @@ROWCOUNT = 0 
            INSERT INTO GCSUELDO_OPER (CVE_SUOP, CVE_TAB, STATUS, SUELDO, SUELDO_SENC, CLAVE_O, PLAZA_O, PLAZA_D, TIPO_FULL_SENCILLO, TIPO_CARGADO_VACIO,
            OBSER, FECHAELAB, UUID) VALUES (@CVE_SUOP, @CVE_TAB, 'A', @SUELDO, @SUELDO_SENC, @CLAVE_O, @PLAZA_O, @PLAZA_D, @TIPO_FULL_SENCILLO,
            @TIPO_CARGADO_VACIO, @OBSER, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_SUOP", SqlDbType.Int).Value = GET_MAX("GCSUELDO_OPER", "CVE_SUOP")
            cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = tCVE_TAB.Text
            cmd.Parameters.Add("@SUELDO", SqlDbType.Float).Value = TSUELDO_FULL.Value
            cmd.Parameters.Add("@SUELDO_SENC", SqlDbType.Float).Value = TSUELDO_SENC.Value
            cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLI_OP1.Text
            cmd.Parameters.Add("@PLAZA_O", SqlDbType.VarChar).Value = CVE_PLAZA1
            cmd.Parameters.Add("@PLAZA_D", SqlDbType.VarChar).Value = CVE_PLAZA2
            cmd.Parameters.Add("@TIPO_FULL_SENCILLO", SqlDbType.SmallInt).Value = 0
            cmd.Parameters.Add("@TIPO_CARGADO_VACIO", SqlDbType.SmallInt).Value = 0
            cmd.Parameters.Add("@OBSER", SqlDbType.VarChar).Value = ""
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            'MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmTabRutasHojaAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Sub CALCULO1()
        Try
            If TAUTO_SENC.Value > 0 Then

                LtAUTO_SENC_LTS.Text = Format(CDec(TKM.Text) / TAUTO_SENC.Value, "###,###,##0")
            End If
        Catch ex As Exception
            Bitacora("2320. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TKM_TextChanged(sender As Object, e As EventArgs) Handles TKM.TextChanged
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TAUTO_SENC_TextChanged(sender As Object, e As EventArgs) Handles TAUTO_SENC.TextChanged
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TP4_SENC_TextChanged(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TFULL_AUTO_TextChanged(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TFULL_P4_TextChanged(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub BtnPlaza_Click(sender As Object, e As EventArgs) Handles BtnCasetasXRuta.Click
        Try
            Var2 = "GCCASETAS_X_RUTA"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CXR.Text = Var4
                LtCaseXRuta.Text = Var5 & " - " & Var6
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            TKM.Focus()
        Catch ex As Exception
            Bitacora("2480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKM_Validated(sender As Object, e As EventArgs) Handles TKM.Validated
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TAUTO_SENC_Validated(sender As Object, e As EventArgs) Handles TAUTO_SENC.Validated
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TP4_SENC_Validated(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TFULL_AUTO_Validated(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Private Sub TFULL_P4_Validated(sender As Object, e As EventArgs)
        If SeActualiza Then
            CALCULO1()
        End If
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        If fCVE_OPER.Trim.Length > 0 Then
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT OP.CLAVE, OP.NOMBRE, OP.CVE_PLAZA, OP.DOMICILIO, OP.DOMICILIO2, OP.PLANTA, OP.NOTA, OP.RFC, 
                        ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                        FROM GCCLIE_OP OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = OP.CVE_PLAZA
                        WHERE OP.CLAVE = " & fCVE_OPER
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TCLIE_OP_O.Text = dr("NOMBRE").ToString
                            TCIUDAD_O.Text = dr("CIUDAD_PLAZA").ToString
                            TCIUDAD_O.Tag = dr("CVE_PLAZA").ToString
                            TDIR_O.Text = dr("DOMICILIO").ToString
                        Else
                            TCLIE_OP_O.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("168. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("168. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER2(fCVE_OPER As String)
        If fCVE_OPER.Trim.Length > 0 Then
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT OP.CLAVE, OP.NOMBRE, OP.CVE_PLAZA, OP.DOMICILIO, OP.DOMICILIO2, OP.PLANTA, OP.NOTA, OP.RFC, 
                        ISNULL(P1.CIUDAD,'') AS CIUDAD_PLAZA, ISNULL(P1.STATUS,'A') AS ST_PLAZA
                        FROM GCCLIE_OP OP
                        LEFT JOIN GCPLAZAS P1 On P1.CLAVE = OP.CVE_PLAZA
                        WHERE OP.CLAVE = " & fCVE_OPER
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TCLIE_OP_D.Text = dr("NOMBRE").ToString
                            TCIUDAD_D.Text = dr("CIUDAD_PLAZA").ToString
                            TCIUDAD_D.Tag = dr("CVE_PLAZA").ToString
                            TDIR_D.Text = dr("DOMICILIO").ToString
                        Else
                            TCLIE_OP_O.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("168. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("168. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BtnGastosViaje_Click(sender As Object, e As EventArgs) Handles BtnGastosViaje.Click
        Try
            Var2 = "GCConc"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_GASTO.Text = Var4
                LtGastos.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            TIMPORTE.Focus()
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GASTO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnGastosViaje_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                TIMPORTE.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_GAS_Validated(sender As Object, e As EventArgs) Handles tCVE_GASTO.Validated
        Try
            If tCVE_GASTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCConc", tCVE_GASTO.Text)
                If DESCR <> "" Then
                    LtGastos.Text = DESCR
                Else
                    MsgBox("Gasto de viaje inexistente")
                    tCVE_GASTO.Text = ""
                    LtGastos.Text = ""
                End If
            Else
                LtGastos.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGasolinera_Click(sender As Object, e As EventArgs) Handles BtnGasolinera.Click
        Try
            Var2 = "Gasolinera"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_GASOL.Text = Var4
                LtGasolinera.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLITROS_RUTA.Focus()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_GASOL_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_GASOL.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnGasolinera_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                TLITROS_RUTA.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_GASOL_Validated(sender As Object, e As EventArgs) Handles TCVE_GASOL.Validated
        Try
            If TCVE_GASOL.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Gasolinera", TCVE_GASOL.Text)
                If DESCR <> "" Then
                    LtGasolinera.Text = DESCR
                Else
                    MsgBox("Gasolinera inexistente")
                    TCVE_GASOL.Text = ""
                    LtGasolinera.Text = ""
                End If
            Else
                LtGasolinera.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TSUELDO_FULL_TextChanged(sender As Object, e As EventArgs) Handles TSUELDO_FULL.TextChanged
        Try

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TTAR_OPER_FULL_TextChanged(sender As Object, e As EventArgs) Handles TTAR_OPER_FULL.TextChanged
        Try
            If Not IsNothing(TPORC_SUELDO_FULL.Text) AndAlso IsNumeric(TPORC_SUELDO_FULL.Text) Then
                TSUELDO_FULL.Value = TTAR_OPER_FULL.Text * Convert.ToDecimal(TPORC_SUELDO_FULL.Value) / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TPORC_SUELDO_FULL_TextChanged(sender As Object, e As EventArgs) Handles TPORC_SUELDO_FULL.TextChanged
        Try
            If Not IsNothing(TPORC_SUELDO_FULL.Text) AndAlso IsNumeric(TPORC_SUELDO_FULL.Text) Then
                TSUELDO_FULL.Value = TTAR_OPER_FULL.Value * Convert.ToDecimal(TPORC_SUELDO_FULL.Text) / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TSUELDO_SENC_TextChanged(sender As Object, e As EventArgs) Handles TSUELDO_SENC.TextChanged
        Try
            'TPORC_SUELDO_SENC
            'TTAR_X_TON_SENC
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TTAR_X_TON_SENC_TextChanged(sender As Object, e As EventArgs) Handles TTAR_X_TON_SENC.TextChanged
        Try
            If Not IsNothing(TTAR_X_TON_SENC.Text) AndAlso IsNumeric(TTAR_X_TON_SENC.Text) Then
                TSUELDO_SENC.Value = TTAR_X_TON_SENC.Text * Convert.ToDecimal(TPORC_SUELDO_SENC.Value) / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TPORC_SUELDO_SENC_TextChanged(sender As Object, e As EventArgs) Handles TPORC_SUELDO_SENC.TextChanged
        Try
            If Not IsNothing(TPORC_SUELDO_SENC.Text) AndAlso IsNumeric(TPORC_SUELDO_SENC.Text) Then
                TSUELDO_SENC.Value = TTAR_X_TON_SENC.Value * Convert.ToDecimal(TPORC_SUELDO_SENC.Text) / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TPORC_MANIOBRA_FULL_TextChanged(sender As Object, e As EventArgs) Handles TPORC_MANIOBRA_FULL.TextChanged
        Try
            If Not IsNothing(TPORC_MANIOBRA_FULL.Text) AndAlso IsNumeric(TPORC_MANIOBRA_FULL.Text) Then
                TSUELDO_MANIOBRA_FULL.Value = TPORC_MANIOBRA_FULL.Text * TTAR_OPER_FULL.Value / 100
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TPORC_MANIOBRA_SENC_TextChanged(sender As Object, e As EventArgs) Handles TPORC_MANIOBRA_SENC.TextChanged
        Try
            If Not IsNothing(TPORC_MANIOBRA_SENC.Text) AndAlso IsNumeric(TPORC_MANIOBRA_SENC.Text) Then
                TSUELDO_MANIOBRA_SENC.Value = TPORC_MANIOBRA_SENC.Text * TTAR_X_TON_SENC.Value / 100
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
