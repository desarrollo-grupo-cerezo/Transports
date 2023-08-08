Imports C1.Win.C1Themes
Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmContratosAE
    Private Entra As Boolean
    Private ENTR As Boolean = True
    Private IEPS As Single
    Private DOCNEW As Boolean
    Private IMPU1 As Single
    Private IMPU2 As Single
    Private IMPU3 As Single
    Private IMPU4 As Single
    Private IMP1APLA As Integer
    Private IMP2APLA As Integer
    Private IMP3APLA As Integer
    Private IMP4APLA As Integer
    Private PRECIO1 As Decimal
    Private LINEA_FILTRO_SERVICIO As String
    Private VALOR_DECLA_DESDE_SAE As Integer

    Private Sub FrmContratosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim cmd2 As New SqlCommand
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        cmd.Connection = cnSAE

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

        AssignValidation(Me.tCVE_ART, ValidationType.Only_Numbers)
        AssignValidation(Me.tValorDeclarado, ValidationType.Only_Numbers)

        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        BtnClienContrato.FlatStyle = FlatStyle.Flat
        BtnClienContrato.FlatAppearance.BorderSize = 0
        BtnTabRutaViajes.FlatStyle = FlatStyle.Flat
        BtnTabRutaViajes.FlatAppearance.BorderSize = 0
        BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
        BtnCLAVE_REM.FlatAppearance.BorderSize = 0
        BtnPlaza.FlatStyle = FlatStyle.Flat
        BtnPlaza.FlatAppearance.BorderSize = 0
        BtnRecogerEn.FlatStyle = FlatStyle.Flat
        BtnRecogerEn.FlatAppearance.BorderSize = 0
        BtnGastosViaje.FlatStyle = FlatStyle.Flat
        BtnGastosViaje.FlatAppearance.BorderSize = 0
        BtnValesCombus.FlatStyle = FlatStyle.Flat
        BtnValesCombus.FlatAppearance.BorderSize = 0
        BtnCLAVE_DEST.FlatStyle = FlatStyle.Flat
        BtnCLAVE_DEST.FlatAppearance.BorderSize = 0
        BtnPlaza2.FlatStyle = FlatStyle.Flat
        BtnPlaza2.FlatAppearance.BorderSize = 0
        BtnEntregarEn.FlatStyle = FlatStyle.Flat
        BtnEntregarEn.FlatAppearance.BorderSize = 0
        BtnProducto.FlatStyle = FlatStyle.Flat
        BtnProducto.FlatAppearance.BorderSize = 0
        BtnValorDecla.FlatStyle = FlatStyle.Flat
        BtnValorDecla.FlatAppearance.BorderSize = 0
        BtnArtFac.FlatStyle = FlatStyle.Flat
        BtnArtFac.FlatAppearance.BorderSize = 0

        TCVE_CON.MaxLength = 10
        TCLAVE_O.MaxLength = 10
        TCLAVE_D.MaxLength = 10
        tCVE_ART.MaxLength = 16
        TLeyenda.MaxLength = 120
        TRECOGER_EN.MaxLength = 120
        TENTREGAR_EN.MaxLength = 120

        tRUTA_SEN_VAC.MaxLength = 255
        tRUTA_SE_CAR.MaxLength = 255
        tRUTA_FULL_VAC.MaxLength = 255
        tRUTAL_FULL_CAR.MaxLength = 255
        tNOTA.MaxLength = 255
        TCONTRATO_CLIENTE.MaxLength = 20
        TCVE_CON.Tag = ""
        TCLAVE_O.Text = ""
        LtNombre1.Text = ""
        LtPlaza.Text = ""
        LtPlaza2.Text = ""
        LtDom.Text = ""
        LtDomi.Text = ""
        LtPlanta.Text = ""
        LtNota.Text = ""
        LtRFC.Text = ""
        TOBS.Tag = "0"
        TOBS.Text = ""
        tFLETE.Value = 0
        tCVE_PLAZA.Tag = ""
        TCVE_PLAZA2.Tag = ""
        LtPlanta.Tag = ""
        LtPlanta2.Tag = ""
        TIMPORTE.Value = 0

        TCLAVE_O.Tag = " "
        TCLAVE_D.Tag = " "
        TRECOGER_EN.Tag = " "
        TENTREGAR_EN.Tag = " "

        Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 20

        CARGA_PARAM_INVENT()

        IEPS = 4
        Try
            SQL = "SELECT ISNULL(IEPS,4)AS RET, VALOR_DECLA_DESDE_SAE FROM GCPARAMTRANSCG"
            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                cmd3.CommandText = SQL
                Using dr3 As SqlDataReader = cmd3.ExecuteReader
                    If dr3.Read Then
                        IEPS = dr3("RET")
                        VALOR_DECLA_DESDE_SAE = dr3.ReadNullAsEmptyInteger("VALOR_DECLA_DESDE_SAE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        cmd2.Connection = cnSAE
        Entra = True
        Try
            Tab1.SelectedIndex = 0
        Catch ex As Exception
        End Try

        CARGAR_CAT()

        DOCNEW = False
        If Var1 = "Nuevo" Then
            Try
                TCVE_CON.Text = GET_MAX("GCCONTRATO", "CVE_CON")
                TCVE_CON.Enabled = False
                TCLAVE_O.Text = ""
                TCLAVE_O.Select()

                DOCNEW = True

            Catch ex As Exception
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                SQL = "SELECT C.CVE_CON, CONTRATO_CLIENTE, CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR,
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER,
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, CLAVE_O, CLAVE_D, CVE_ORIGEN, CVE_DESTINO, RECOGER_EN, ENTREGAR_EN,
                    C.CVE_PROV, C.CVE_MAT, ISNULL(C.VALOR_DECLA,0) AS DECLA, C.CVE_ART, C.LEYENDA, ISNULL(C.IMPR_TALON,0) AS IMPR, ISNULL(C.CVE_OBS,0) AS CVEOBS,
                    ISNULL(O.DESCR,'') AS OBS_DESCR, CUEN_CONT, FLETE, R.CVE_TAB, 
                    ISNULL(REM_CARGA1,'') AS REM1, ISNULL(PESO_BRUTO1,0) AS PESO1, ISNULL(TARA1,0) AS T1, 
                    ISNULL(REM_CARGA2,'') AS REM2, ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, 
                    ISNULL(REM_CARGA3,'') AS REM3, ISNULL(PESO_BRUTO3,'0') AS PESO3, ISNULL(TARA3,'0') AS T3, 
                    ISNULL(REM_CARGA4,'') AS REM4, ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4, C.REM_CARGA, C.CVE_VAL_DECLA, C.VALOR_DECLARADO,
                    C.CVE_GTO, C.IMPORTE_GAS, C.CVE_GAV, C.LITROS, C.CVE_TAB_VIAJE, C.KMS, C.P4_SENC_LTS, C.FULL_P4_LTS
                    FROM GCCONTRATO C
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS
                    WHERE C.CVE_CON = '" & Var2 & "' AND C.STATUS = 'A' "
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_CON.Text = dr("CVE_CON").ToString
                    TCLAVE_O.Text = ""
                    TCLAVE_D.Text = ""
                    TCLAVE_O.Tag = ""
                    TCLAVE_D.Tag = ""
                    Try
                        'GASTOS DE VIAJE
                        TCVE_GAS.Text = dr.ReadNullAsEmptyLong("CVE_GTO")
                        LtGastos.Text = BUSCA_CAT("GCConc", TCVE_GAS.Text)
                        TIMPORTE.Value = dr.ReadNullAsEmptyDecimal("IMPORTE_GAS")
                        'GASOLINERA
                        TCVE_VALE.Text = dr.ReadNullAsEmptyString("CVE_GAV")
                        LtVales.Text = BUSCA_CAT("Gasolinera", TCVE_VALE.Text)
                        TLITROS.Value = dr.ReadNullAsEmptyDecimal("LITROS")
                        If dr.ReadNullAsEmptyString("CVE_TAB_VIAJE").ToString.Trim.Length > 0 Then
                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB_VIAJE")
                        Else
                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB")
                        End If
                    Catch ex As Exception
                        Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    'FIN NUEVO
                    '********************************************
                    tRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                    tRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                    tRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                    tRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                    tNOTA.Text = dr("NOTA").ToString

                    TCONTRATO_CLIENTE.Text = dr("NO_CONTRATO").ToString
                    LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)
                    TCLAVE_O.Text = dr("CLAVE_O").ToString.Trim
                    DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)

                    TCLAVE_D.Text = dr("CLAVE_D").ToString.Trim
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)
                    'AQUI SONSO
                    TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                    LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)

                    TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                    LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)

                    'TAG'S
                    TCLAVE_O.Tag = TCLAVE_O.Text
                    TCLAVE_D.Tag = TCLAVE_D.Text
                    TRECOGER_EN.Tag = TRECOGER_EN.Text
                    TENTREGAR_EN.Tag = TENTREGAR_EN.Text

                    tCVE_ART.Text = dr("CVE_ART").ToString
                    LtProducto.Text = BUSCA_CAT("GCPRODUCTOS", tCVE_ART.Text)

                    tValorDeclarado.Text = dr("DECLA").ToString
                    If tValorDeclarado.Text = "0" Or tValorDeclarado.Text = "" Then
                        tValorDeclarado.Text = ""
                        Lt1.Text = ""
                        Lt3.Text = ""
                    Else
                        Dim DESCR As String
                        ENTR = False
                        DESCR = BUSCA_CAT("Valor Declarado", tValorDeclarado.Text)
                        If DESCR <> "" Then
                            'Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                            'Var7 = dr.ReadNullAsEmptyDecimal("P1")
                            Lt1.Text = DESCR
                            If IsNumeric(Var4.Replace(",", "")) Then
                                Lt3.Text = Format(CDec(Var4.Replace(",", "")), "###,###,##0.00")
                            Else
                                Lt3.Text = ""
                            End If
                        End If
                    End If

                    tFLETE.Value = dr.ReadNullAsEmptyDecimal("FLETE")

                    TLeyenda.Text = dr("LEYENDA").ToString
                    TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                    TOBS.Tag = dr("CVEOBS")
                    TOBS.Text = dr("OBS_DESCR")
                    CARGAR_CONC()
                End If
                dr.Close()

                TCVE_CON.Enabled = False
                TCLAVE_O.Select()

            Catch ex As Exception
                Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        DERECHOS()

    End Sub
    Sub CARGA_PARAM_INVENT()
        If Not Valida_Conexion() Then
            Me.Close()
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT CVE_ART_TOT FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            LINEA_FILTRO_SERVICIO = ""
            If dr.Read Then
                LINEA_FILTRO_SERVICIO = dr.ReadNullAsEmptyString("CVE_ART_TOT")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                Pag5.Visible = False
                BarGrabar.Visible = False
                Pag5.Width = 0
                Tab1.TabPages.Item(3).Enabled = False
                GpoFactura.Visible = False
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    (CLAVE >= 11500 AND CLAVE < 11990)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 11530  'GRABAR
                                    BarGrabar.Visible = True
                                Case 11540  'ACCESO PESTAÑA BAJA DE VIAJE
                                    Tab1.TabPages.Item(3).Enabled = True
                                Case 11580  'ACCESO VALOR FACTURA
                                    GpoFactura.Visible = True
                                    'VALOR DECLARADO
                            End Select
                        End While
                    End Using
                End Using

                If Not BarGrabar.Visible Then
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp5)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp6)
                    TOBS.ReadOnly = True

                End If
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Function BUSCAR_CVE_VIAJE(fCVE_CON As String) As String
        Dim CVE_CON As String = ""

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(CVE_VIAJE,'') AS CVEVIAJE FROM GCASIGNACION_VIAJE WHERE CVE_CON = '" & fCVE_CON & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_CON = dr("CVEVIAJE")
                    End If
                End Using
            End Using
            Return CVE_CON
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Sub CARGAR_CONC()
        Try
            Dim cmd2 As New SqlCommand
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CVE_CPTO As Integer
            Dim CVE_ART As String
            Dim TRASLADO As Integer
            Dim RETIENE As Integer
            Dim IMPORTE As Single
            Dim Sicon As Boolean

            cmd.Connection = cnSAE
            cmd2.Connection = cnSAE

            SQL = "SELECT ISNULL(C.CVE_ART,'') AS ART, ISNULL(C.CVE_CPTO,'') AS CPTO, ISNULL(TRASLADO,0) AS TRAS, ISNULL(RETIENE,0) AS RET, " &
                "ISNULL(IMPORTE,0) AS IMPORT, ISNULL(DESCR, '') AS DES, ISNULL(CLIENTE,'') AS CLIE " &
                "FROM GCCONTRATO_CONC C " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = C.CVE_ART " &
                "WHERE CVE_CON = '" & TCVE_CON.Text & "' "
            cmd.CommandText = SQL
            Sicon = False
            dr = cmd.ExecuteReader
            Do While dr.Read
                CVE_ART = dr("ART")
                CVE_CPTO = dr("CPTO")
                TRASLADO = dr("TRAS")
                RETIENE = dr("RET")
                IMPORTE = dr("IMPORT")
                Sicon = True
            Loop
            dr.Close()

        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAT()
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        TCVE_CON.Text = ""
        TCLAVE_O.Text = ""
        TCLAVE_D.Text = ""
        TRECOGER_EN.Text = ""
        TENTREGAR_EN.Text = ""
        tValorDeclarado.Text = ""
        Lt1.Text = ""
        Lt3.Text = ""

        tCVE_ART.Text = ""
        TLeyenda.Text = ""

        tRUTA_SEN_VAC.Text = ""
        tRUTA_SE_CAR.Text = ""
        tRUTA_FULL_VAC.Text = ""
        tRUTAL_FULL_CAR.Text = ""
        tNOTA.Text = ""
        TCONTRATO_CLIENTE.Text = ""


    End Sub

    Private Sub FrmContratosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub FrmContratosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And Entra Then
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
        Dim CVE_OBS As Long, FLETE As Decimal, VALOR_DECLARADO As Decimal, IMPORTE_FAC As Decimal, IMPORTE_GAS As Decimal = 0
        Dim LITROS As Decimal = 0, SeGrabo As Boolean = False

        Try
            If IsNumeric(TLITROS.Text) Then
                LITROS = TLITROS.Text
            Else
                LITROS = 0
            End If
            TIMPORTE.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Try
            IMPORTE_GAS = TIMPORTE.Value

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If String.IsNullOrEmpty(tFLETE.Text) Then
                FLETE = tFLETE.Value
            Else
                FLETE = tFLETE.Text
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(Lt3.Text.Replace(",", "")) Then
                VALOR_DECLARADO = Lt3.Text.Replace(",", "").Trim
            Else
                VALOR_DECLARADO = 0
            End If
            If TOBS.Text.Trim.Length > 0 Then
                CVE_OBS = Val(TOBS.Tag.ToString)
                CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TOBS.Text)
            Else
                CVE_OBS = 0
            End If
            If IsNumeric(LtImporteFac.Text.Replace(",", "")) Then
                IMPORTE_FAC = CDec(LtImporteFac.Text.Replace(",", ""))
            Else
                IMPORTE_FAC = 0
            End If
        Catch ex As Exception
            VALOR_DECLARADO = 0
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        cmd.Connection = cnSAE
        ',         KMS, P4_SENC_LTS, FULL_P4_LTS, LTR_DIESEL_SEN, LTR_DIESEL_FULL
        ',                 @KMS, @P4_SENC_LTS, @FULL_P4_LTS, @LTR_DIESEL_SEN, @LTR_DIESEL_FULL
        If DOCNEW Then
            SQL = " INSERT INTO GCCONTRATO (CVE_CON, STATUS, RUTA_SEN_VAC, RUTA_SE_CAR, RUTA_FULL_VAC, RUTAL_FULL_CAR, NOTA, CVE_OBS, CONTRATO_CLIENTE, 
                NO_CONTRATO, CLAVE_O, CLAVE_D, RECOGER_EN, ENTREGAR_EN, VALOR_DECLA, CVE_ART, LEYENDA, FECHAELAB, UUID, CUEN_CONT, FLETE, 
                SUBTOTAL, IVA, RETENCION, NETO, VALOR_DECLARADO, CVE_MAT, CVE_ART_FAC, IMPORTE_FAC, CVE_GTO, IMPORTE_GAS, CVE_GAV, LITROS, CVE_TAB_VIAJE)  
                VALUES (
                @CVE_CON, 'A', @RUTA_SEN_VAC, @RUTA_SE_CAR, @RUTA_FULL_VAC, @RUTAL_FULL_CAR, @NOTA, @CVE_OBS, @CONTRATO_CLIENTE, @NO_CONTRATO, @CLAVE_O,
                @CLAVE_D, @RECOGER_EN, @ENTREGAR_EN, @VALOR_DECLA, @CVE_ART, @LEYENDA, GETDATE(), NEWID(), @CUEN_CONT, @FLETE, @SUBTOTAL, 
                @IVA, @RETENCION, @NETO, @VALOR_DECLARADO, @CVE_MAT, @CVE_ART_FAC, @IMPORTE_FAC, @CVE_GTO, @IMPORTE_GAS, @CVE_GAV, @LITROS, @CVE_TAB_VIAJE)"
        Else
            SQL = "UPDATE GCCONTRATO SET RUTA_SEN_VAC = @RUTA_SEN_VAC, RUTA_SE_CAR = @RUTA_SE_CAR, RUTA_FULL_VAC = @RUTA_FULL_VAC, 
                RUTAL_FULL_CAR = @RUTAL_FULL_CAR, NOTA = @NOTA, CVE_OBS = @CVE_OBS, CONTRATO_CLIENTE = @CONTRATO_CLIENTE, NO_CONTRATO = @NO_CONTRATO, 
                CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, VALOR_DECLA = @VALOR_DECLA, CVE_ART = @CVE_ART, 
                LEYENDA = @LEYENDA, CUEN_CONT = @CUEN_CONT, FLETE = @FLETE, SUBTOTAL = @SUBTOTAL, IVA = @IVA, RETENCION = @RETENCION, 
                NETO = @NETO, VALOR_DECLARADO = @VALOR_DECLARADO, CVE_MAT = @CVE_MAT, CVE_ART_FAC = @CVE_ART_FAC, IMPORTE_FAC = @IMPORTE_FAC,
                CVE_GTO = @CVE_GTO, IMPORTE_GAS = @IMPORTE_GAS, CVE_GAV = @CVE_GAV, LITROS = @LITROS, CVE_TAB_VIAJE = @CVE_TAB_VIAJE
                WHERE CVE_CON = @CVE_CON"
        End If
        ',         KMS = @KMS, P4_SENC_LTS = @P4_SENC_LTS, FULL_P4_LTS = @FULL_P4_LTS, LTR_DIESEL_SEN = @LTR_DIESEL_SEN, LTR_DIESEL_FULL = @LTR_DIESEL_FULL
        cmd.CommandText = SQL

        For k = 1 To 5
            Try
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                cmd.Parameters.Add("@RUTA_SEN_VAC", SqlDbType.VarChar).Value = tRUTA_SEN_VAC.Text
                cmd.Parameters.Add("@RUTA_SE_CAR", SqlDbType.VarChar).Value = tRUTA_SE_CAR.Text
                cmd.Parameters.Add("@RUTA_FULL_VAC", SqlDbType.VarChar).Value = tRUTA_FULL_VAC.Text
                cmd.Parameters.Add("@RUTAL_FULL_CAR", SqlDbType.VarChar).Value = tRUTAL_FULL_CAR.Text
                cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = tNOTA.Text
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.BigInt).Value = CVE_OBS
                cmd.Parameters.Add("@NO_CONTRATO", SqlDbType.VarChar).Value = TCONTRATO_CLIENTE.Text
                cmd.Parameters.Add("@CONTRATO_CLIENTE", SqlDbType.VarChar).Value = TCONTRATO_CLIENTE.Text
                cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = IIf(IsNumeric(TCLAVE_O.Text), TCLAVE_O.Text, 0)
                cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = IIf(IsNumeric(TCLAVE_D.Text), TCLAVE_D.Text, 0)
                cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                cmd.Parameters.Add("@VALOR_DECLA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tValorDeclarado.Text)
                cmd.Parameters.Add("@CVE_MAT", SqlDbType.VarChar).Value = tValorDeclarado.Text
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = tCVE_ART.Text
                cmd.Parameters.Add("@LEYENDA", SqlDbType.VarChar).Value = TLeyenda.Text
                cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
                cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = FLETE
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtSubTotal.Text.Replace(",", ""))
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtIVA.Text.Replace(",", ""))
                cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtRet.Text.Replace(",", ""))
                cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtNeto.Text.Replace(",", ""))
                cmd.Parameters.Add("@VALOR_DECLARADO", SqlDbType.Float).Value = VALOR_DECLARADO
                cmd.Parameters.Add("@CVE_ART_FAC", SqlDbType.VarChar).Value = tCVE_ART.Text
                cmd.Parameters.Add("@IMPORTE_FAC", SqlDbType.Float).Value = IMPORTE_FAC
                cmd.Parameters.Add("@CVE_GTO", SqlDbType.VarChar).Value = TCVE_GAS.Text
                cmd.Parameters.Add("@IMPORTE_GAS", SqlDbType.Float).Value = IMPORTE_GAS
                cmd.Parameters.Add("@CVE_GAV", SqlDbType.VarChar).Value = TCVE_VALE.Text
                cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = LITROS
                cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                End If
                SeGrabo = True
                Exit For
            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            TCVE_CON.Text = GET_MAX("GCCONTRATO", "CVE_CON")
        Next

        If SeGrabo Then
            Try
                Dim returnRegresado As String = "", SQLX As String

                If VALOR_DECLA_DESDE_SAE = 1 Then
                    If tFLETE.Value > 0 Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQLX = "UPDATE PRECIO_X_PROD" & Empresa & " SET PRECIO = " & tFLETE.Value & " 
                                  WHERE CVE_ART = '" & tValorDeclarado.Text & "' AND CVE_PRECIO = 1"
                            cmd.CommandText = SQLX
                            returnRegresado = cmd.ExecuteNonQuery().ToString()
                        End Using
                    End If
                End If
            Catch ex As Exception
                Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                GRABA_BITA("", TCVE_CON.Text, 0, "T", "Se agregó o edito contrato " & TCVE_CON.Text, TCONTRATO_CLIENTE.Text, TCVE_CON.Text)

                If TCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_O.Tag <> TCLAVE_O.Text Then
                        GRABA_BITA("", TCVE_CON.Text, 0, "T", "Se cambio el cliente operativo [" & TCLAVE_O.Tag & "] por [" & TCLAVE_O.Text & "]", "Contrato", TCVE_CON.Text, "FtoF")
                    End If
                End If
                If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                        GRABA_BITA("", TCVE_CON.Text, 0, "T", "Se cambio el cliente operativo [" & TCLAVE_D.Tag & "] por [" & TCLAVE_D.Text & "]", "Contrato", TCVE_CON.Text, "FtoF")
                    End If
                End If
                If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                    If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                        GRABA_BITA("", TCVE_CON.Text, 0, "T", "Se cambio recoger en [" & TRECOGER_EN.Tag & "] por [" & TRECOGER_EN.Text & "]", "Contrato", TCVE_CON.Text, "FtoF")
                    End If
                End If
                If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                    If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                        GRABA_BITA("", TCVE_CON.Text, 0, "T", "Se cambio entregar en [" & TENTREGAR_EN.Tag & "] por [" & TENTREGAR_EN.Text & "]", "Contrato", TCVE_CON.Text, "FtoF")
                    End If
                End If

                TCLAVE_O.Tag = TCLAVE_O.Text
                TCLAVE_D.Tag = TCLAVE_D.Text
                TRECOGER_EN.Tag = TRECOGER_EN.Text
                TENTREGAR_EN.Tag = TENTREGAR_EN.Text
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MsgBox("El registro se grabo satisfactoriamente")
            Me.Close()
        Else
            MsgBox("No se logro grabar el registro")
        End If

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                TCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCLAVE_DEST_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_DEST.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLAVE_D.Text = Var4
                DESPLEGAR_CLIENTE_OPER2(Var4)
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TENTREGAR_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("59 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("59. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ART.Text = Var4
                LtProducto.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLeyenda.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProducto_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            LtDom2.Select()
        End If
        If e.KeyCode = 9 Then
            TCLAVE_D.Select()
        End If
    End Sub
    Private Sub TCVE_PROV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Select Case e.KeyCode
            Case Keys.Up
            Case Keys.Left
            Case Keys.Right
            Case Keys.Down
            Case Keys.Tab, Keys.Enter
                e.IsInputKey = True
                TCLAVE_D.Select()
        End Select
    End Sub

    Private Sub TCVE_REM_MouseUp(sender As Object, e As MouseEventArgs) Handles TCLAVE_O.MouseUp
        TCLAVE_O.SelectAll()
    End Sub
    Private Sub TCVE_DEST_MouseUp(sender As Object, e As MouseEventArgs) Handles TCLAVE_D.MouseUp
        TCLAVE_D.SelectAll()
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles tCVE_ART.Validated
        Try
            If tCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCPRODUCTOS", tCVE_ART.Text)
                If DESCR <> "" Then
                    LtProducto.Text = DESCR
                Else
                    MsgBox("Producto inexistente")
                    tCVE_ART.Text = ""
                    tCVE_ART.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmContratosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Contratos AE")
            Me.Dispose()

            If FORM_IS_OPEN("frmContratos") Then
                frmContratos.DESPLEGAR()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TOBS_GotFocus(sender As Object, e As EventArgs) Handles TOBS.GotFocus
        Entra = False
    End Sub
    Private Sub TOBS_LostFocus(sender As Object, e As EventArgs) Handles TOBS.LostFocus
        Entra = True
    End Sub
    Private Sub TCLAVE_O_Validated(sender As Object, e As EventArgs) Handles TCLAVE_O.Validated
        Try
            If TCLAVE_O.Text.Trim.Length > 0 Then
                DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_D_Validated(sender As Object, e As EventArgs) Handles TCLAVE_D.Validated
        Try
            If TCLAVE_D.Text.Trim.Length > 0 Then
                DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)
            Else
                LtNombre2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TCLAVE_O_Validated(Nothing, Nothing)
            If e.KeyCode = Keys.Enter Then
                Label22.Focus()
            Else
            End If
        End If
    End Sub
    Private Sub TCLAVE_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_D.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_DEST_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TCLAVE_D_Validated(Nothing, Nothing)
            If e.KeyCode = Keys.Enter Then
                'Label30.Focus()
            Else
            End If
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
                            TCLAVE_O.Text = dr("CLAVE").ToString
                            LtNombre1.Text = dr("NOMBRE").ToString
                            tCVE_PLAZA.Text = dr("CVE_PLAZA").ToString
                            tCVE_PLAZA.Tag = dr("ST_PLAZA").ToString

                            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                                LtPlaza.Text = BUSCA_CAT("Plazas", tCVE_PLAZA.Text, False)
                                LtPlaza.Tag = tCVE_PLAZA.Text
                            End If
                            LtDom.Text = dr("DOMICILIO").ToString
                            LtDomi.Text = dr("DOMICILIO2").ToString
                            LtPlanta.Text = dr("PLANTA").ToString
                            LtNota.Text = dr("NOTA").ToString
                            LtRFC.Text = dr("RFC").ToString
                        Else
                            TCLAVE_O.Text = ""
                            LtNombre1.Text = ""
                            LtPlaza.Text = ""
                            LtPlaza2.Text = ""
                            LtDom.Text = ""
                            LtDomi.Text = ""
                            LtPlanta.Text = ""
                            LtNota.Text = ""
                            LtRFC.Text = ""
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
                            TCLAVE_D.Text = dr("CLAVE").ToString
                            LtNombre2.Text = dr("NOMBRE").ToString
                            TCVE_PLAZA2.Text = dr("CVE_PLAZA").ToString
                            TCVE_PLAZA2.Tag = dr("ST_PLAZA").ToString

                            If TCVE_PLAZA2.Text.Trim.Length > 0 Then
                                LtPlaza2.Text = BUSCA_CAT("Plazas", TCVE_PLAZA2.Text, False)
                                LtPlaza2.Tag = TCVE_PLAZA2.Text
                            End If
                            LtDom2.Text = dr("DOMICILIO").ToString
                            LtDomi2.Text = dr("DOMICILIO2").ToString
                            LtPlanta2.Text = dr("PLANTA").ToString
                            LtNota2.Text = dr("NOTA").ToString
                            LtRFC2.Text = dr("RFC").ToString
                        Else
                            TCLAVE_D.Text = ""
                            LtNombre2.Text = ""
                            LtPlaza2.Text = ""
                            LtDom2.Text = ""
                            LtDomi2.Text = ""
                            LtPlanta2.Text = ""
                            LtNota2.Text = ""
                            LtRFC2.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("172. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("172. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BtnClienContrato_Click(sender As Object, e As EventArgs) Handles BtnClienContrato.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCONTRATO_CLIENTE.Text = Var4
                LtClienteContrato.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch ex As Exception
            Bitacora("178. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("178. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnValorDecla_Click(sender As Object, e As EventArgs) Handles BtnValorDecla.Click
        Try
            'If VALOR_DECLA_DESDE_SAE = 0 Then
            Var2 = "Valor Declarado"
            FrmSelItem2.ShowDialog()
            'Else
            'Var2 = "InveSAE"
            'frmSelItem.ShowDialog()
            'End If
            If Var4.Trim.Length > 0 Then
                tValorDeclarado.Text = Var4
                Lt1.Text = Var5
                If IsNumeric(Var6) Then
                    Lt3.Text = Format(CDec(Var6), "###,###,##0.00")
                End If
                If VALOR_DECLA_DESDE_SAE = 0 Then
                Else
                    'Var4 = Fg(Fg.Row, 1) 'CVE_ART
                    'Var5 = Fg(Fg.Row, 2) 'DESCRIPCION
                    'Var6 = Fg(Fg.Row, 3) 'PRECIO
                    PRECIO1 = 0 : IMPU1 = 0 : IMPU2 = 0 : IMPU3 = 0 : IMPU4 = 0 : IMP1APLA = 0 : IMP2APLA = 0 : IMP3APLA = 0 : IMP4APLA = 0
                    DESPLEGAR_ARTICULO_SAE(Var4)
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_ARTICULO_SAE(fCVE_ART As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT I.CVE_ESQIMPU, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, IMP1APLICA, IMP2APLICA, IMP3APLICA, IMP4APLICA, 
                    (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1
                    FROM INVE" & Empresa & " I
                    LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                    WHERE CVE_ART = '" & fCVE_ART & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PRECIO1 = dr("P1")
                        IMPU1 = dr("IMPUESTO1")
                        IMPU2 = dr("IMPUESTO2")
                        IMPU3 = dr("IMPUESTO3")
                        IMPU4 = dr("IMPUESTO4")
                        IMP1APLA = dr("IMP1APLICA")
                        IMP2APLA = dr("IMP2APLICA")
                        IMP3APLA = dr("IMP3APLICA")
                        IMP4APLA = dr("IMP4APLICA")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPlaza_Click(sender As Object, e As EventArgs) Handles BtnPlaza.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlaza_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub BtnPlaza2_Click(sender As Object, e As EventArgs) Handles BtnPlaza2.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TValorDeclarado_KeyDown(sender As Object, e As KeyEventArgs) Handles tValorDeclarado.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnValorDecla_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCONTRATO_CLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCONTRATO_CLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClienContrato_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TRECOGER_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRECOGER_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                'tCLAVE_D.Select()
                Gp3.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TENTREGAR_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TENTREGAR_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Gp4.Select()
                Gp4.Select()
                'tCVE_GAS.Select()
                'tCVE_GAS.Focus()

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnRecogerEn_Click(sender As Object, e As EventArgs) Handles BtnRecogerEn.Click
        Try
            Var2 = "RecogerEn"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TRECOGER_EN.Text = Var4
                LtRecogerEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCLAVE_D.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEntregarEn_Click(sender As Object, e As EventArgs) Handles BtnEntregarEn.Click
        Try
            Var2 = "EntregarEn"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TENTREGAR_EN.Text = Var4
                LtEntregarEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_GAS.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TRECOGER_EN_KeyDown(sender As Object, e As KeyEventArgs) Handles TRECOGER_EN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnRecogerEn_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            TCLAVE_D.Focus()
        End If
    End Sub
    Private Sub TRECOGER_EN_Validated(sender As Object, e As EventArgs) Handles TRECOGER_EN.Validated
        Try
            If TRECOGER_EN.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", TRECOGER_EN.Text)
                If DESCR <> "" Then
                    LtRecogerEn.Text = DESCR
                Else
                    MsgBox("Registro inexistente")
                    TRECOGER_EN.Text = ""
                    LtRecogerEn.Text = ""
                    TRECOGER_EN.Select()
                End If
            Else
                LtRecogerEn.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TENTREGAR_EN_KeyDown(sender As Object, e As KeyEventArgs) Handles TENTREGAR_EN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEntregarEn_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            TCVE_GAS.Focus()
        End If
    End Sub
    Private Sub TENTREGAR_EN_Validating(sender As Object, e As CancelEventArgs) Handles TENTREGAR_EN.Validating
        Try
            If TENTREGAR_EN.Text.Trim.Length > 0 And ENTR Then
                Dim DESCR As String
                ENTR = False
                DESCR = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                If DESCR <> "" Then
                    LtEntregarEn.Text = DESCR
                Else
                    MessageBox.Show("Registro inexistente-")
                    TENTREGAR_EN.Focus()
                    TENTREGAR_EN.Text = ""
                    LtEntregarEn.Text = ""
                    e.Cancel = True
                End If
                ENTR = True
            Else
                LtEntregarEn.Text = ""
                tCVE_ART.Select()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TValorDeclarado_Validating(sender As Object, e As CancelEventArgs) Handles tValorDeclarado.Validating
        Try
            If tValorDeclarado.Text.Trim.Length > 0 And ENTR Then
                Dim DESCR As String
                ENTR = False
                'If VALOR_DECLA_DESDE_SAE = 0 Then
                DESCR = BUSCA_CAT("Valor Declarado", tValorDeclarado.Text)
                'Else
                'DESCR = BUSCA_CAT("InvesSAE", tValorDeclarado.Text)
                'End If
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                    'Var7 = dr.ReadNullAsEmptyDecimal("P1")
                    'Var8 = dr.ReadNullAsEmptyString("T_ELE")
                    'Var9 = dr.ReadNullAsEmptyDecimal("C_PROM")
                    Lt1.Text = DESCR
                    If VALOR_DECLA_DESDE_SAE = 0 Then
                        If IsNumeric(Var4) Then
                            Lt3.Text = Format(CDec(Var4), "###,###,##0.00")
                        Else
                            Lt3.Text = ""
                        End If
                    Else
                        If IsNumeric(Var7) Then
                            Lt3.Text = Format(CDec(Var7), "###,###,##0.00")
                        Else
                            Lt3.Text = ""
                        End If

                        DESPLEGAR_ARTICULO_SAE(tValorDeclarado.Text)
                        CALCULA_PRECIO_CARTA_PORTE()
                    End If
                Else
                    MessageBox.Show("Registro inexistente-")
                    tValorDeclarado.Focus()
                    tValorDeclarado.Text = ""
                    Lt1.Text = ""
                    Lt3.Text = ""
                    e.Cancel = True
                End If
                ENTR = True
            Else
                Lt1.Text = ""
                Lt3.Text = ""
                tFLETE.Value = 0
                LtEntregarEn.Text = ""
                TLeyenda.Select()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        Try
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                Else
                    If tCVE_PLAZA.Tag <> "B" And tCVE_PLAZA.Text <> LtPlaza.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA.Focus()
                        tCVE_PLAZA.Text = ""
                        LtPlaza.Text = ""
                    End If
                End If
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PLAZA2_Validated(sender As Object, e As EventArgs) Handles TCVE_PLAZA2.Validated
        Try
            If TCVE_PLAZA2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", TCVE_PLAZA2.Text)
                If DESCR <> "" Then
                    LtPlaza2.Text = DESCR
                Else
                    If TCVE_PLAZA2.Tag <> "B" And TCVE_PLAZA2.Text <> LtPlaza2.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        TCVE_PLAZA2.Focus()
                        TCVE_PLAZA2.Text = ""
                        LtPlaza2.Text = ""
                    End If
                End If
            Else
                LtPlaza2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TFLETE_TextChanged(sender As Object, e As EventArgs) Handles tFLETE.TextChanged
        Try
            If Not String.IsNullOrEmpty(tFLETE.Text) Then
                If VALOR_DECLA_DESDE_SAE = 0 Then
                    LtSubTotal.Text = Format(CSng(tFLETE.Text), "###,###,###.00")
                    LtIVA.Text = Format(tFLETE.Text * 0.16, "###,###,###.00")
                    LtRet.Text = Format((tFLETE.Text * IEPS) / 100, "###,###,###.00")
                    LtNeto.Text = Format(tFLETE.Text + (tFLETE.Text * 0.16) - ((tFLETE.Text * IEPS) / 100), "###,###,##0.00")
                Else
                    Dim PREC As Decimal = 0, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single

                    If IsNumeric(tFLETE.Text) Then
                        PREC = tFLETE.Text
                        PREC = Math.Round(CDec(PREC), 8)

                        cIeps = PREC * IMPU1 / 100
                        If IMP4APLA = 1 Then
                            cImpu2 = (PREC + cIeps) * IMPU2 / 100
                            cImpu3 = (PREC + cIeps + cImpu2) * IMPU3 / 100
                            cImpu = (PREC + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                        Else
                            cImpu2 = PREC * IMPU2 / 100
                            cImpu3 = PREC * IMPU3 / 100
                            cImpu = PREC * IMPU4 / 100
                        End If
                        LtSubTotal.Text = Format(CDec(tFLETE.Text), "###,###,###.00")
                        LtIVA.Text = Format(cIeps + cImpu, "###,###,###.00")
                        LtRet.Text = Format(cImpu2 + cImpu3, "###,###,###.00")
                        LtNeto.Text = Format(tFLETE.Text + cIeps + cImpu2 + cImpu3 + cImpu, "###,###,##0.00")
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULA_PRECIO_CARTA_PORTE()
        Try
            Dim PRECIO As Decimal = 0
            Try
                If IsNumeric(Lt3.Text.Trim.Replace(",", "")) Then
                    PRECIO = CDec(Lt3.Text.Trim.Replace(",", ""))
                    tFLETE.Value = PRECIO

                    Dim PREC As Decimal = 0, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single

                    PREC = tFLETE.Text
                    PREC = Math.Round(CDec(PREC), 8)

                    cIeps = PREC * IMPU1 / 100
                    If IMP4APLA = 1 Then
                        cImpu2 = (PREC + cIeps) * IMPU2 / 100
                        cImpu3 = (PREC + cIeps + cImpu2) * IMPU3 / 100
                        cImpu = (PREC + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                    Else
                        cImpu2 = PREC * IMPU2 / 100
                        cImpu3 = PREC * IMPU3 / 100
                        cImpu = PREC * IMPU4 / 100
                    End If
                    LtSubTotal.Text = Format(CSng(tFLETE.Text), "###,###,###.00")
                    LtIVA.Text = Format(cIeps + cImpu2 + cImpu3 + cImpu, "###,###,###.00")
                    LtRet.Text = Format(cIeps + cImpu3, "###,###,###.00")
                    LtNeto.Text = Format(tFLETE.Text + cIeps + cImpu2 + cImpu3 + cImpu, "###,###,##0.00")
                Else
                    PRECIO = 0
                End If
            Catch ex As Exception
                PRECIO = 0
            End Try
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnArtFac_Click(sender As Object, e As EventArgs) Handles BtnArtFac.Click
        Try
            Var2 = "InveS"
            Var4 = ""
            Var5 = LINEA_FILTRO_SERVICIO
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_FAC.Text = Var4
                LtDescrFac.Text = Var5
                If IsNumeric(Var7) Then
                    LtImporteFac.Text = Format(CDec(Var7), "###,###,##0.00")
                Else
                    LtImporteFac.Text = ""
                End If

                Var2 = "" : Var4 = "" : Var5 = ""
                TLeyenda.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_FAC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_FAC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArtFac_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_ART_FAC_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_FAC.Validated
        Try
            If TCVE_ART_FAC.Text.Trim.Length > 0 Then
                Var5 = LINEA_FILTRO_SERVICIO
                Dim DESCR As String
                DESCR = BUSCA_CAT("InveS2", TCVE_ART_FAC.Text)
                If DESCR <> "" Then
                    LtDescrFac.Text = DESCR
                    If IsNumeric(Var7) Then
                        LtImporteFac.Text = Format(CDec(Var7), "###,###,##0.00")
                    Else
                        LtImporteFac.Text = ""
                    End If
                Else
                    MsgBox("Articulo inexistente")
                    TCVE_ART_FAC.Text = ""
                    TCVE_ART_FAC.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGastosViaje_Click(sender As Object, e As EventArgs) Handles BtnGastosViaje.Click
        Try
            Var2 = "GCConc"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_GAS.Text = Var4
                LtGastos.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_VALE.Focus()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_GAS.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnGastosViaje_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                TCVE_VALE.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_GAS_Validated(sender As Object, e As EventArgs) Handles TCVE_GAS.Validated
        Try
            If TCVE_GAS.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCConc", TCVE_GAS.Text)
                If DESCR <> "" Then
                    LtVales.Text = DESCR
                Else
                    MsgBox("Gasto de viaje inexistente")
                    TCVE_GAS.Text = ""
                    LtVales.Text = ""
                End If
            Else
                LtVales.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnValesCombus_Click(sender As Object, e As EventArgs) Handles BtnValesCombus.Click
        Try
            Var2 = "Gasolinera"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_VALE.Text = Var4
                LtVales.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLeyenda.Focus()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_VALE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VALE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnGastosViaje_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                TLeyenda.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_VALE_Validated(sender As Object, e As EventArgs) Handles TCVE_VALE.Validated
        Try
            If TCVE_VALE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Gasolinera", TCVE_VALE.Text)
                If DESCR <> "" Then
                    LtVales.Text = DESCR
                Else
                    MsgBox("Gasolinera inexistente")
                    TCVE_VALE.Text = ""
                    LtVales.Text = ""
                End If
            Else
                LtVales.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTabRutaViajes_Click(sender As Object, e As EventArgs) Handles BtnTabRutaViajes.Click
        Try
            Var2 = "RUTAS FLORES"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TAB_VIAJE.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                DESPLEGAR_RUTAS_FLORES(TCVE_TAB_VIAJE.Text)
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_RUTAS_FLORES(FCVE_TAB_VIAJE As String)
        Dim Existe As Boolean = False
        Try
            SQL = "SELECT T.CVE_TAB, T.CLIE_OP, ISNULL(OP1.NOMBRE,'') AS NOM_OP1, T.CLIE_OP_O, ISNULL(OP2.NOMBRE,'') AS NOM_OP_O, 
                T.CLIE_OP_D, ISNULL(OP3.NOMBRE,'') AS NOM_OP_D, ISNULL(OP2.CVE_PLAZA,0) AS CVE_PLAZA_O, 
                ISNULL(P1.CIUDAD,'') AS CIUDAD_PLA_O, ISNULL(OP3.CVE_PLAZA,0) AS CVE_PLAZA_D, ISNULL(P2.CIUDAD,'') AS CIUDAD_PLA_D, 
                ISNULL(OP2.DOMICILIO,'') AS DOMI_O, ISNULL(OP3.DOMICILIO,'') AS DOMI_D, T.CVE_PROD, T.CVE_ART, 
                ISNULL(P.DESCR,'') AS DESCR_PROD, T.KMS, T.AUTO_SENC, T.P4_SENC, T.FULL_AUTO, T.FULL_P4, T.AUTO_SENC_LTS, 
                T.P4_SENC_LTS, T.FULL_AUTO_LTS, T.FULL_P4_LTS, T.SUELDO_FULL, T.SUELDO_SENC, T.TAR_X_TON_FULL, T.TAR_X_VIA_FULL,
                T.TAR_X_TON_SENC, T.TAR_X_VIA_SENC 
                FROM GCTAB_RUTAS_F T 
                LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = T.CLIE_OP
                LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP2.CVE_PLAZA
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP3.CVE_PLAZA
                LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = T.CVE_PROD
                WHERE CVE_TAB = '" & FCVE_TAB_VIAJE & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCONTRATO_CLIENTE.Text = dr("CLIE_OP")
                        TCLAVE_O.Text = dr("CLIE_OP_O").ToString
                        TCLAVE_D.Text = dr("CLIE_OP_D").ToString
                        Existe = True
                    End If
                End Using
            End Using
            If Existe Then
                tCLAVE_O_Validated(Nothing, Nothing)
                tCLAVE_D_Validated(Nothing, Nothing)
                tCONTRATO_CLIENTE_Validated(Nothing, Nothing)
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCONTRATO_CLIENTE_Validated(sender As Object, e As EventArgs) Handles TCONTRATO_CLIENTE.Validated
        Try
            If TCONTRATO_CLIENTE.Text.Trim.Length > 0 Then
                LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TAB_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TAB_VIAJE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTabRutaViajes_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TAB_VIAJE_Validated(sender As Object, e As EventArgs) Handles TCVE_TAB_VIAJE.Validated
        If TCVE_TAB_VIAJE.Text.Length > 0 Then
            Try
                SQL = "SELECT T.CVE_TAB
                    FROM GCTAB_RUTAS_F T
                    WHERE CVE_TAB = " & TCVE_TAB_VIAJE.Text
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            DESPLEGAR_RUTAS_FLORES(TCVE_TAB_VIAJE.Text)
                        Else
                            MsgBox("tabulador de viaje inexistente, verifique por favor")
                            TCVE_TAB_VIAJE.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
End Class
