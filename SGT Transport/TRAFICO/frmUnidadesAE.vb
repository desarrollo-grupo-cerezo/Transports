Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient

Public Class frmUnidadesAE
    Private RUTA_DOC As String
    Private RUTA_IMAGEN As String
    Dim MODULO_UNI_COMPLETO As Integer
    Private Max_O_Min As Integer
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.SuspendLayout()
        CARGAR_DATOS()
        Me.ResumeLayout()
    End Sub
    Public Sub New(FMax_O_Min As Integer)

        Me.New()
        Max_O_Min = FMax_O_Min
    End Sub

    Private Sub frmUnidadesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            Btn1.FlatStyle = FlatStyle.Flat
            Btn1.FlatAppearance.BorderSize = 0
            Btn2.FlatStyle = FlatStyle.Flat
            Btn2.FlatAppearance.BorderSize = 0
            Btn3.FlatStyle = FlatStyle.Flat
            Btn3.FlatAppearance.BorderSize = 0
            Btn4.FlatStyle = FlatStyle.Flat
            Btn4.FlatAppearance.BorderSize = 0
            Btn5.FlatStyle = FlatStyle.Flat
            Btn5.FlatAppearance.BorderSize = 0
            Btn6.FlatStyle = FlatStyle.Flat
            Btn6.FlatAppearance.BorderSize = 0
            Btn7.FlatStyle = FlatStyle.Flat
            Btn7.FlatAppearance.BorderSize = 0
            Btn8.FlatStyle = FlatStyle.Flat
            Btn8.FlatAppearance.BorderSize = 0
            Btn9.FlatStyle = FlatStyle.Flat
            Btn9.FlatAppearance.BorderSize = 0
            Btn10.FlatStyle = FlatStyle.Flat
            Btn10.FlatAppearance.BorderSize = 0
            Btn11.FlatStyle = FlatStyle.Flat
            Btn11.FlatAppearance.BorderSize = 0
            Btn12.FlatStyle = FlatStyle.Flat
            Btn12.FlatAppearance.BorderSize = 0

        Catch ex As Exception
        End Try

        Try
            If tUni.Text.Trim = "2" Then
                If TSubTipoRem1.Text.Trim.Length > 0 Then
                    TSubTipoRem1_Validated(Nothing, Nothing)
                End If
            End If

            tSE_ASEGURADORA_Validated(Nothing, Nothing)
        Catch ex As Exception
        End Try

        tCLAVE.Enabled = False
        tDescr.Select()
        Tab1.TabPages.Item(8).TabVisible = False
        Me.Tab1.SelectedIndex = 0

        If Max_O_Min = 1 Then
            Me.FormBorderStyle = FormBorderStyle.FixedSingle
            Me.WindowState = FormWindowState.Normal
            'Me.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Me.CenterToScreen()
        End If

    End Sub
    Sub CARGAR_DATOS()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try



        cboVelProm.Items.Add("%")
        cboVelProm.Items.Add("Km")

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")

        Me.KeyPreview = True

        FUltReset.Value = Date.Today
        FUltReset.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FUltReset.CustomFormat = "dd/MM/yyyy"
        FUltReset.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FUltReset.EditFormat.CustomFormat = "dd/MM/yyyy"

        FUltServ.Value = Date.Today
        FUltServ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FUltServ.CustomFormat = "dd/MM/yyyy"
        FUltServ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FUltServ.EditFormat.CustomFormat = "dd/MM/yyyy"

        FProxServ.Value = Date.Today
        FProxServ.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FProxServ.CustomFormat = "dd/MM/yyyy"
        FProxServ.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FProxServ.EditFormat.CustomFormat = "dd/MM/yyyy"

        FFechaCompra.Value = Date.Today
        FFechaCompra.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFechaCompra.CustomFormat = "dd/MM/yyyy"
        FFechaCompra.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFechaCompra.EditFormat.CustomFormat = "dd/MM/yyyy"

        FFVencPlacasMex.Value = Date.Today
        FFVencPlacasMex.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFVencPlacasMex.CustomFormat = "dd/MM/yyyy"
        FFVencPlacasMex.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFVencPlacasMex.EditFormat.CustomFormat = "dd/MM/yyyy"

        FVencPlacasEU.Value = Date.Today
        FVencPlacasEU.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencPlacasEU.CustomFormat = "dd/MM/yyyy"
        FVencPlacasEU.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencPlacasEU.EditFormat.CustomFormat = "dd/MM/yyyy"

        FVencVeri.Value = Date.Today
        FVencVeri.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencVeri.CustomFormat = "dd/MM/yyyy"
        FVencVeri.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencVeri.EditFormat.CustomFormat = "dd/MM/yyyy"

        FVencSeg.Value = Date.Today
        FVencSeg.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencSeg.CustomFormat = "dd/MM/yyyy"
        FVencSeg.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FVencSeg.EditFormat.CustomFormat = "dd/MM/yyyy"

        tFchUltLavada.Value = Date.Today
        tFchUltLavada.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFchUltLavada.CustomFormat = "dd/MM/yyyy"
        tFchUltLavada.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFchUltLavada.EditFormat.CustomFormat = "dd/MM/yyyy"

        CboRendimiento.Items.Add("Autónomo")
        CboRendimiento.Items.Add("P4")

        Dim SEL_UNI As String
        Dim CVE_TIPO_UNI1 As Integer
        Dim CVE_TIPO_UNI2 As Integer

        tClaveMonte.CharacterCasing = CharacterCasing.Upper

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RUTA_DOC = dr("RUTA_DOC").ToString
                RUTA_IMAGEN = dr("RUTA_IMAGEN").ToString
            Else
                RUTA_DOC = ""
                RUTA_IMAGEN = ""
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(MODULO_UNIDADES_COMPLETA,0) AS MOD_UNI_COMPLETA FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        MODULO_UNI_COMPLETO = dr("MOD_UNI_COMPLETA")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Tab1.SelectedIndex = 0
        Tab2.SelectedIndex = 0
        Tab3.SelectedIndex = 0
        Tab4.SelectedIndex = 0
        Tab5.SelectedIndex = 0
        Tab6.SelectedIndex = 0
        Tab7.SelectedIndex = 0
        Tab8.SelectedIndex = 0

        INICIALIZAR_VARIABLES()
        CARGA_CAT()

        LR3.Visible = False
        TSubTipoRem1.Visible = False
        BtnSubTipoRem1.Visible = False
        LTSubTipoRem1.Visible = False
        CboRendimiento.Visible = False
        LtRend.Visible = False

        If Var3 = "B" Then
            LtBaja.Visible = True
            BtnActivo.Visible = True
            Lb1.Visible = True
            Lb2.Visible = True
            TMOTIVO_BAJA.Visible = True
            BtnActivo.Text = "Baja"
            BtnActivo.Tag = "Baja"

        Else
            LtBaja.Visible = False
            BtnActivo.Visible = False
            Lb1.Visible = False
            Lb2.Visible = False
            TMOTIVO_BAJA.Visible = False
            BtnActivo.Text = "Activo"
            BtnActivo.Tag = "Activo"
        End If

        If MODULO_UNI_COMPLETO = 0 Then
            Pag2.TabVisible = False
            Pag3.TabVisible = False
            Pag4.TabVisible = False
            Pa6.TabVisible = False
            Pa7.TabVisible = False
        End If
        If Var1 = "Nuevo" Then
            Try
                tCLAVE.Text = GET_MAX("GCUNIDADES", "CLAVE")
                tCLAVE.Enabled = False
                tDescr.Text = ""
                tDescr.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.STATUS, U.RENTADO, U.UNIDAD_PERMISI, U.DESCR, U.CVE_TIPO_UNI, ISNULL(U.CVE_SUC,0) AS C_SUC, 
                    ISNULL(U.CVE_OPER,0) AS C_OPER, ISNULL(U.CVE_MARCA,'') AS C_MARCA, ISNULL(U.CVE_MODELO,0) AS C_MODELO, 
                    ISNULL(U.NUM_SERIE_UNI,'') AS NUM_SERIE, ISNULL(U.COLOR,'') AS COLO, ISNULL(U.CVE_ART,'') AS CVEART, 
                    ISNULL(U.CVE_TANQUE1,'') AS C_TANQUE1, ISNULL(U.CVE_TANQUE2,'') AS C_TANQUE2, ISNULL(U.CVE_DOLLY,'') AS C_DOLLY, 
                    ISNULL(U.CVE_GRUPO,0) AS C_GRUPO, U.IDENT_SAT, U.IDENT_CON, U.RENDIMIENTO, U.ULTIMO_KM, U.ULTIMO_DIS, U.FEC_ULT_RES, U.FEC_ULT_SER, 
                    U.FEC_PROX_RES, U.DIAS_SERV, U.KM_SER, U.CVE_DOC, U.GARANTIA, U.ULT_DIST_RECR, U.FECHA_DOC, U.CVE_DOC_ASEG, U.CVE_OBSCOMP, 
                    U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12, U.PLACAS_MEX, 
                    U.FPLA_VENC, U.PLACAS_EU, U.FPLA_VENC_EU, U.PLACAS_DEF, U.PERMISO_SCT, U.VERIFICACION, U.FVENC_VER, U.CHTV, U.CHAC, U.CHWIFI, 
                    U.CHDISCAPA, U.VEL_PROM, U.NEUTRALIZADORES, U.FRE_BRUS, U.CAR_ACELE, U.ACC_PED_FRENO, U.VEL_MAX_MOTOR, U.PORC_ULT_CAMBIO, U.LARGO, 
                    U.ANCHO, U.ALTO, ISNULL(U.CAPACIDAD,'') AS CAPACI, U.NUM_EJES, ISNULL(U.NUM_LLANTAS,0) AS N_LLANTAS, ISNULL(U.LLANTAS_REF,'') AS LL_REF, 
                    U.CVE_MARCA_LLA, U.CVE_MODELO_LLA, U.CVE_MED, U.CVE_TIPO_LLA, U.TIPO_MOTOR, U.NUM_SERIE_MOT, U.TIPO_TRANS, U.CVE_OBSER_MOT, 
                    U.CVE_TIPO_COM, U.CAP_TANQUE_LT, U.CAP_TANQUE_MI, U.REN_CAR_KM, U.REN_CAR_MI, U.REN_VAC_KM, U.REN_VAC_MI, U.TARJ_COMB, U.TARJ_COMB2, 
                    U.TARJ_COMB3, U.OD_TARJ_IAVE, U.OD_TARJ_EPASS, U.OD_PORC, U.OD_ODOMETRO_KM, U.OD_ODOMETRO_GPS_KM, U.OD_ODOMETRO_MI, 
                    U.OD_ODOMETRO_GPS_MI, U.OD_HOROMETRO, U.OD_HOROMETRO_MIN, U.CVE_PROP, U.SE_ASEGURADORA, U.SE_TEL, U.SE_NO_SEG, U.SE_VENC, 
                    U.SE_AMPLIA, U.SE_LIMITADA, U.SE_SIN_COBERTURA, U.PARO_X_RALENTI, U.T_P_MOTOR_RELENTI, ISNULL(OB.DESCR,'') AS OBS_COMPRAS, 
                    FCHULTLAVADA, ISNULL(EJES,0) AS EJE, ISNULL(TIPO_EJE,-1) AS T_EJE, ISNULL(NIVEL,0) AS NIV1, ISNULL(NIVEL2,0) AS NIV2, 
                    ISNULL(NIVEL3,0) AS NIV3, CVE_TAQ, CVE_MOT, 
                    ISNULL((SELECT CVE_TIPO_UNI FROM GCUNIDADES WHERE CLAVE = U.CVE_TANQUE1), 0) AS CVE_TIPO_UNI1, 
                    ISNULL((SELECT CVE_TIPO_UNI FROM GCUNIDADES WHERE CLAVE = U.CVE_TANQUE2), 0) AS CVE_TIPO_UNI2, 
                    SUBTIPOREM, ANO_MODELO, ISNULL(CVE_REND,-1) AS RENDI, CUEN_CONT, CUEN_CONT2, CUEN_CONT_VTA, 
                    CTA_CON_DIESEL, CTA_CON_DIESEL_SIVA, ISNULL(MOTIVO_BAJA,'') AS MOT_BAJA, ISNULL(USUARIO_BAJA,'') AS USU_BAJA
                    FROM GCUNIDADES U
                    LEFT JOIN GCOBS OB ON OB.CVE_OBS = U.CVE_OBSCOMP 
                    WHERE CLAVE = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Try
                        tCLAVE.Text = dr("CLAVE")
                        tClaveMonte.Text = dr("CLAVEMONTE")

                        chRentada.Value = dr.ReadNullAsEmptyInteger("RENTADO")
                        chUniPer.Value = dr.ReadNullAsEmptyInteger("UNIDAD_PERMISI")
                        tDescr.Text = dr.ReadNullAsEmptyString("DESCR")
                        tUni.Text = dr.ReadNullAsEmptyInteger("CVE_TIPO_UNI")
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        CboRendimiento.SelectedIndex = dr("RENDI")
                    Catch ex As Exception
                    End Try

                    Try
                        If tUni.Text.Trim.Length > 0 And tUni.Text <> "0" Then
                            L1.Text = BUSCA_CAT("Tipo unidad", tUni.Text)
                            If tUni.Text.Trim = "2" Then
                                LR3.Visible = True
                                TSubTipoRem1.Visible = True
                                BtnSubTipoRem1.Visible = True
                                LTSubTipoRem1.Visible = True

                                TSubTipoRem1.Text = dr.ReadNullAsEmptyString("SUBTIPOREM")

                            Else
                                If tUni.Text.Trim = "1" Then
                                    CboRendimiento.Visible = True
                                    LtRend.Visible = True
                                End If
                            End If
                        Else
                            tUni.Text = ""
                            L1.Text = ""
                        End If
                        If dr("C_SUC") <> 0 Then
                            tSuc.Text = dr("C_SUC")
                            L2.Text = BUSCA_CAT("Sucursal", tSuc.Text)
                        End If
                        If dr("C_OPER") <> 0 Then
                            tCVE_OPER.Text = dr("C_OPER")
                            L3.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
                        End If

                        If dr("C_MARCA") <> "" And dr("C_MARCA") <> "0" Then
                            tCVE_MARCA.Text = dr("C_MARCA")
                            L4.Text = BUSCA_CAT("Marca unidad", tCVE_MARCA.Text)
                        End If
                        If dr("C_MODELO") <> 0 Then
                            tCVE_MODELO.Text = dr("C_MODELO")
                            L5.Text = BUSCA_CAT("Modelo", tCVE_MODELO.Text)
                        End If

                        tNUM_SERIE_UNI.Text = dr("NUM_SERIE")
                        tColor.Text = dr("COLO")

                        tCVE_ART.Text = dr("CVEART")
                        L6.Text = BUSCA_CAT("Inven", tCVE_ART.Text)

                        If dr("C_TANQUE1") <> 0 Then
                            tCVE_TANQUE1.Tag = dr("C_TANQUE1")
                            L7.Text = BUSCA_CAT("Unidades", tCVE_TANQUE1.Tag)
                            tCVE_TANQUE1.Text = Var4
                        End If
                        If dr("C_TANQUE2") <> 0 Then
                            tCVE_TANQUE2.Tag = dr("C_TANQUE2")
                            L8.Text = BUSCA_CAT("Unidades", tCVE_TANQUE2.Tag)
                            tCVE_TANQUE2.Text = Var4
                        End If
                        If dr("C_DOLLY") <> 0 Then
                            tCVE_DOLLY.Tag = dr("C_DOLLY")
                            L9.Text = BUSCA_CAT("Unidades", tCVE_DOLLY.Tag)
                            tCVE_DOLLY.Text = Var4
                        End If
                        If dr("C_GRUPO") <> 0 Then
                            tCVE_GRUPO.Text = dr("C_GRUPO")
                            L10.Text = BUSCA_CAT("Grupo unidad", tCVE_GRUPO.Text)
                        End If
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    Try
                        tIDENT_SAT.Text = dr.ReadNullAsEmptyString("IDENT_SAT")
                        tIDENT_CON.Text = dr.ReadNullAsEmptyString("IDENT_CON")
                        tRendimiento.Text = dr.ReadNullAsEmptyString("RENDIMIENTO")
                        tULTIMO_KM.Text = dr.ReadNullAsEmptyDecimal("ULTIMO_KM")
                        tULTIMO_DIS.Text = dr.ReadNullAsEmptyDecimal("ULTIMO_DIS")
                        FUltReset.Value = dr.ReadNullAsEmptyString("FEC_ULT_RES")
                        FUltServ.Value = dr.ReadNullAsEmptyString("FEC_ULT_SER")
                        FProxServ.Value = dr.ReadNullAsEmptyString("FEC_PROX_RES")
                        tFchUltLavada.Value = dr.ReadNullAsEmptyString("FCHULTLAVADA")

                        tDIAS_SERV.Text = dr.ReadNullAsEmptyInteger("DIAS_SERV")
                        tKM_SER.Text = dr.ReadNullAsEmptyInteger("KM_SER")
                        tCVE_DOC.Text = dr.ReadNullAsEmptyString("CVE_DOC")
                        tGarantia.Text = dr.ReadNullAsEmptyString("GARANTIA")
                        tULT_DIST_RECR.Text = dr.ReadNullAsEmptyDecimal("ULT_DIST_RECR")
                        FFechaCompra.Value = dr.ReadNullAsEmptyString("FECHA_DOC")
                        tCVE_DOC_ASEG.Text = dr.ReadNullAsEmptyString("CVE_DOC_ASEG")

                        tCVE_OBSCOMP.Text = dr.ReadNullAsEmptyString("OBS_COMPRAS")
                        tCVE_OBSCOMP.Tag = dr.ReadNullAsEmptyLong("CVE_OBSCOMP")

                        FFVencPlacasMex.Value = dr.ReadNullAsEmptyString("FPLA_VENC")

                        tPLACAS_EU.Text = dr.ReadNullAsEmptyString("PLACAS_EU")
                        FVencPlacasEU.Value = dr.ReadNullAsEmptyString("FPLA_VENC_EU")
                        If dr("PLACAS_DEF").ToString.Trim.Length > 0 Then
                            tPLACAS_DEF.Text = dr.ReadNullAsEmptyString("PLACAS_DEF")
                            L11.Text = BUSCA_CAT("Placas defa", tPLACAS_DEF.Text)
                        End If

                        tPERMISO_SCT.Text = dr.ReadNullAsEmptyString("PERMISO_SCT")
                        tVERIFICACION.Text = dr.ReadNullAsEmptyString("VERIFICACION")
                        FVencVeri.Value = dr.ReadNullAsEmptyString("FVENC_VER")
                        chTV.Value = dr.ReadNullAsEmptyInteger("CHTV")
                        chAC.Value = dr.ReadNullAsEmptyInteger("CHAC")
                        chWIFI.Value = dr.ReadNullAsEmptyInteger("CHWIFI")
                        chDiscapa.Value = dr.ReadNullAsEmptyInteger("CHDISCAPA")
                        tVEL_PROM.Text = dr.ReadNullAsEmptyDecimal("VEL_PROM")
                        tNEUTRALIZADORES.Text = dr.ReadNullAsEmptyDecimal("NEUTRALIZADORES")
                        tFRE_BRUS.Text = dr.ReadNullAsEmptyDecimal("FRE_BRUS")
                        tCAR_ACELE.Text = dr.ReadNullAsEmptyDecimal("CAR_ACELE")
                        tACC_PED_FRENO.Text = dr.ReadNullAsEmptyDecimal("ACC_PED_FRENO")
                        tVEL_MAX_MOTOR.Text = dr.ReadNullAsEmptyDecimal("VEL_MAX_MOTOR")
                        tPORC_ULT_CAMBIO.Text = dr.ReadNullAsEmptyDecimal("PORC_ULT_CAMBIO")
                        tLargo.Text = dr.ReadNullAsEmptyDecimal("LARGO")
                        tAncho.Text = dr.ReadNullAsEmptyDecimal("ANCHO")
                        tAlto.Text = dr.ReadNullAsEmptyDecimal("ALTO")
                        tNUM_EJES.Text = dr.ReadNullAsEmptyInteger("NUM_EJES")
                        tCVE_TAQ.Text = dr.ReadNullAsEmptyDecimal("CVE_TAQ")
                        LtTAQ.Text = BUSCA_CAT("Tanques", tCVE_TAQ.Text) & " Litros"

                        tCVE_MOT.Text = dr.ReadNullAsEmptyDecimal("CVE_MOT")
                        LtMotor.Text = BUSCA_CAT("Motor", tCVE_MOT.Text)
                        TANO_MODELO.Text = dr.ReadNullAsEmptyString("ANO_MODELO")

                        tCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                        tCUEN_CONT2.Text = dr.ReadNullAsEmptyString("CUEN_CONT2")
                        TCUEN_CONT_VTA.Text = dr.ReadNullAsEmptyString("CUEN_CONT_VTA")
                        TCTA_CON_DIESEL.Text = dr.ReadNullAsEmptyString("CTA_CON_DIESEL")
                        TCTA_CON_DIESEL_SIVA.Text = dr.ReadNullAsEmptyString("CTA_CON_DIESEL_SIVA")
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        tPLACAS_MEX.Text = dr.ReadNullAsEmptyString("PLACAS_MEX")
                        tEJES.Value = dr.ReadNullAsEmptyInteger("EJE").ToString
                        tSE_NO_SEG.Text = dr.ReadNullAsEmptyString("SE_NO_SEG")
                        tSE_ASEGURADORA.Text = dr.ReadNullAsEmptyString("SE_ASEGURADORA")
                        LtAseguradora.Text = BUSCA_CAT("Aseguradora", tSE_ASEGURADORA.Text)

                        tNUM_LLANTAS.Text = dr.ReadNullAsEmptyString("N_LLANTAS")
                        tLLANTAS_REF.Text = dr.ReadNullAsEmptyString("LL_REF")
                        tCapacidad.Text = dr("CAPACI")

                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        For Each vdp As ValueDescriptionPair In cboMarcaLlanta.Items
                            If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_MARCA_LLA") Then
                                cboMarcaLlanta.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        For Each vdp As ValueDescriptionPair In cboModeloLlanta.Items
                            If vdp.ValuePair = dr("CVE_MODELO_LLA") Then
                                cboModeloLlanta.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        For Each vdp As ValueDescriptionPair In cboMedidaLlanta.Items
                            If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_MED") Then
                                cboMedidaLlanta.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        For Each vdp As ValueDescriptionPair In cboTipoLlanta.Items
                            If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_TIPO_LLA") Then
                                cboTipoLlanta.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        tTIPO_MOTOR.Text = dr.ReadNullAsEmptyString("TIPO_MOTOR")
                        tNUM_SERIE_MOT.Text = dr.ReadNullAsEmptyString("NUM_SERIE_MOT")
                        tTIPO_TRANS.Text = dr.ReadNullAsEmptyString("TIPO_TRANS")
                        tCVE_OBSER_MOT.Text = dr.ReadNullAsEmptyString("CVE_OBSER_MOT")
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        For Each vdp As ValueDescriptionPair In cboTipoComb.Items
                            If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_TIPO_COM") Then
                                cboTipoComb.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        tCAP_TANQUE_LT.Text = dr("CAP_TANQUE_LT")
                        tCAP_TANQUE_MI.Text = dr("CAP_TANQUE_MI")
                        tREN_CAR_KM.Text = dr("REN_CAR_KM")
                        tREN_CAR_MI.Text = dr("REN_CAR_MI")
                        tREN_VAC_KM.Text = dr("REN_VAC_KM")
                        tREN_VAC_MI.Text = dr("REN_VAC_MI")
                        tTARJ_COMB.Text = dr("TARJ_COMB")
                        tTARJ_COMB2.Text = dr("TARJ_COMB2")
                        tTARJ_COMB3.Text = dr("TARJ_COMB3")
                        tOD_TARJ_IAVE.Text = dr("OD_TARJ_IAVE")
                        LtIave.Text = BUSCA_CAT("IAVE", tOD_TARJ_IAVE.Text)

                        tOD_TARJ_EPASS.Text = dr("OD_TARJ_EPASS")
                        tOD_PORC.Text = dr("OD_PORC")
                        tOD_ODOMETRO_KM.Text = dr("OD_ODOMETRO_KM")
                        tOD_ODOMETRO_GPS_KM.Text = dr("OD_ODOMETRO_GPS_KM")
                        tOD_ODOMETRO_MI.Text = dr("OD_ODOMETRO_MI")
                        tOD_ODOMETRO_GPS_MI.Text = dr("OD_ODOMETRO_GPS_MI")
                        tOD_HOROMETRO.Text = dr("OD_HOROMETRO")
                        tOD_HOROMETRO_MIN.Text = dr("OD_HOROMETRO_MIN")
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        For Each vdp As ValueDescriptionPair In cboPropietario.Items
                            If vdp.ValuePair = dr("CVE_PROP") Then
                                cboPropietario.SelectedIndex = vdp.cboIndex
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        'MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try

                        tSE_TEL.Text = dr("SE_TEL")

                        FVencSeg.Value = dr("SE_VENC")
                        chSE_AMPLIA.Checked = dr("SE_AMPLIA")
                        chSE_LIMITADA.Checked = dr("SE_LIMITADA")
                        chSE_SIN_COBERTURA.Checked = dr("SE_SIN_COBERTURA")
                        chPARO_X_RALENTI.Checked = dr("PARO_X_RALENTI")
                        tT_P_MOTOR_RELENTI.Text = dr("T_P_MOTOR_RELENTI")
                        CVE_TIPO_UNI1 = dr("CVE_TIPO_UNI1")
                        CVE_TIPO_UNI2 = dr("CVE_TIPO_UNI2")
                    Catch ex As Exception
                        Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    SEL_UNI = "0"
                    Select Case tUni.Text
                        Case "1"    'TRACTOR    1
                            SEL_UNI = "1"
                            LtTractor.Text = tClaveMonte.Text
                            If tUni.Text.Trim.Length > 0 Then
                                GTra.Visible = True
                            Else
                                GTra.Visible = False
                            End If
                            If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                LtTanque1.Text = tCVE_TANQUE1.Text
                                'GTra.Visible = True
                                GTa1.Visible = True
                            Else
                                'GTra.Visible = False
                                GTa1.Visible = False
                            End If
                            If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                LtTanque2.Text = tCVE_TANQUE2.Text
                                GTa2.Visible = True
                            Else
                                GTa2.Visible = False
                            End If
                            If tCVE_DOLLY.Text.Trim.Length > 0 Then
                                LtDolly.Text = tCVE_DOLLY.Text
                                GDol.Visible = True
                            Else
                                GDol.Visible = False
                            End If

                        Case "2"    'TANQUE1  1  2
                            If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                LtTanque1.Text = tCVE_TANQUE1.Text
                                GTra.Visible = True
                            Else
                                GTra.Visible = False
                            End If
                            If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                LtTanque2.Text = tCVE_TANQUE2.Text
                                GTa1.Visible = True
                                GTa2.Visible = False
                            Else
                                GTa1.Visible = False
                                GTa2.Visible = True
                            End If
                            If CVE_TIPO_UNI1 = 1 Then
                                SEL_UNI = "2"
                                LtTanque1.Text = tClaveMonte.Text
                            Else
                                If CVE_TIPO_UNI2 = 1 Then
                                    SEL_UNI = "3"
                                    LtTanque2.Text = tClaveMonte.Text
                                Else
                                    If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                        LtTanque1.Text = tCVE_TANQUE1.Text
                                        SEL_UNI = "2"
                                    Else
                                        If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                            LtTanque2.Text = tCVE_TANQUE2.Text
                                            SEL_UNI = "3"
                                        End If
                                    End If
                                End If
                            End If
                        Case "3"    'DOLLY      3
                            If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                GTa1.Visible = True
                            Else
                                GTa1.Visible = False
                            End If
                            If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                GTa2.Visible = True
                            Else
                                GTa2.Visible = False
                            End If
                            If CVE_TIPO_UNI1 = 1 Then
                                GTra.Visible = True
                            Else
                                If CVE_TIPO_UNI1 = 1 Then
                                    GTra.Visible = True
                                Else
                                    GTra.Visible = False
                                End If
                            End If
                            GDol.Visible = True
                            SEL_UNI = "4"
                            If tCVE_DOLLY.Text.Trim.Length > 0 Then
                                LtDolly.Text = tCVE_DOLLY.Text
                            Else
                                LtDolly.Text = tClaveMonte.Text
                            End If

                    End Select

                    Try


                        If tUni.Text = "1" Then
                            If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE1.Text, 2)
                            End If
                            If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE2.Text, 3)
                            End If
                        Else
                            'SEL_UNI  CVE_TIPO_UNI1 tipo unidad tanque 1 CVE_TIPO_UNI2 tipo unidad tanque 2
                            If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                                If CVE_TIPO_UNI1 = 1 Then
                                    ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE1.Text, 1)
                                Else
                                    ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE1.Text, 2)
                                End If
                            End If
                            If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                                If CVE_TIPO_UNI2 = 1 Then
                                    ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE2.Text, 1)
                                Else
                                    ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_TANQUE2.Text, 3)
                                End If
                            End If
                        End If

                        If tCVE_DOLLY.Text.Trim.Length > 0 Then
                            ASIGNAR_LLANTAS_TANQUES_DOLLY(tCVE_DOLLY.Text, 4)
                        End If

                        If dr.ReadNullAsEmptyString("STATUS") = "A" Then
                            BtnActivo.Text = "Activo"
                            BtnActivo.Tag = "Activo"
                        Else
                            BtnActivo.Text = "Baja"
                            BtnActivo.Tag = "Baja"
                            Lb3.Text = "USUARIO QUE LO DIO DE BAJA:" & dr("USU_BAJA")
                        End If
                        TMOTIVO_BAJA.Text = dr("MOT_BAJA")

                    Catch ex As Exception
                        'MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    DOC_FOTOS(tCLAVE.Text)
                    'CARGAR_SERVICIOS()
                End If
                dr.Close()


                SQL = "SELECT CVE_LLANTA, ISNULL(NUM_ECONOMICO,'') AS NUM_ECO, ISNULL(POSICION,0) AS POS 
                    FROM GCLLANTAS WHERE UNIDAD = '" & tClaveMonte.Text & "'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                While dr.Read
                    Select Case dr("POS")
                        Case 1
                            tLL1.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL1.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 2
                            tLL2.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL2.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 3
                            tLL3.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL3.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 4
                            tLL4.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL4.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 5
                            tLL5.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL5.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 6
                            tLL6.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL6.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 7
                            tLL7.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL7.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 8
                            tLL8.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL8.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 9
                            tLL9.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL9.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 10
                            tLL10.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL10.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 11
                            tLL11.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL11.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                        Case 12
                            tLL12.Text = dr.ReadNullAsEmptyString("CVE_LLANTA").ToString
                            LL12.Text = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                    End Select

                    ASIGNAR_LLANTAS(tClaveMonte.Text, dr("POS"), dr("NUM_ECO"))
                    IMAGEN_LLANTA(dr("NUM_ECO"), dr("POS"))

                End While
                dr.Close()

            Catch ex As Exception
                Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmUnidadesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmUnidadesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Sub ASIGNAR_LLANTAS_TANQUES_DOLLY(fUNIDAD As String, fTIPO_UNI As Integer)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If fTIPO_UNI = 2 Then
                SQL = SQL
            End If
            cmd.Connection = cnSAE
            SQL = "SELECT U.CVE_TIPO_UNI, U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, " &
                  "U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12 " &
                  "FROM GCUNIDADES U " &
                  "WHERE CLAVEMONTE = '" & fUNIDAD & "' AND ISNULL(STATUS, 'A') = 'A'"

            SQL = "SELECT CVE_LLANTA, ISNULL(NUM_ECONOMICO,'') AS NUM_ECO, ISNULL(POSICION,0) AS POS FROM GCLLANTAS WHERE UNIDAD = '" & fUNIDAD & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    If dr("NUM_ECO").ToString.Trim > 0 And dr("POS") > 0 Then
                        ASIGNAR_LLANTAS(fTIPO_UNI, dr("POS"), dr("NUM_ECO"))
                    End If
                Catch ex As Exception
                    MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ASIGNAR_LLANTAS(fUNI As String, fLLANTA As Integer, fNUM_ECONOMICO As String)
        Try

            Select Case fUNI
                Case "1" 'TRACTOR
                    'TRACTOR
                    Select Case fLLANTA
                        Case 1
                            BtnM1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnM2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnM3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnM4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnM5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnM6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnM7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnM8.Text = fNUM_ECONOMICO
                        Case 9
                            BtnM9.Text = fNUM_ECONOMICO
                        Case 10
                            BtnM10.Text = fNUM_ECONOMICO
                    End Select
                Case "2"
                    Select Case fLLANTA
                        Case 1
                            BtnT1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnT2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnT3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnT4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnT5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnT6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnT7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnT8.Text = fNUM_ECONOMICO
                        Case 9
                            BtnT9.Text = fNUM_ECONOMICO
                        Case 10
                            BtnT10.Text = fNUM_ECONOMICO
                        Case 11
                            BtnT11.Text = fNUM_ECONOMICO
                        Case 12
                            BtnT12.Text = fNUM_ECONOMICO
                    End Select
                Case "3"
                    Select Case fLLANTA
                        Case 1
                            BtnTT1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnTT2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnTT3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnTT4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnTT5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnTT6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnTT7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnTT8.Text = fNUM_ECONOMICO
                        Case 9
                            BtnTT9.Text = fNUM_ECONOMICO
                        Case 10
                            BtnTT10.Text = fNUM_ECONOMICO
                        Case 11
                            BtnTT11.Text = fNUM_ECONOMICO
                        Case 12
                            BtnTT12.Text = fNUM_ECONOMICO
                    End Select
                Case "4"
                    Select Case fLLANTA
                        Case 1
                            BtnD1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnD2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnD3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnD4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnD5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnD6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnD7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnD8.Text = fNUM_ECONOMICO
                    End Select
            End Select
        Catch ex As Exception
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub INICIALIZAR_VARIABLES()
        Try

            tCLAVE.Text = ""
            tClaveMonte.Text = ""

            chRentada.Value = 0
            chUniPer.Value = 0
            tDescr.Text = ""
            tUni.Text = ""
            tSuc.Text = ""
            tCVE_OPER.Text = ""
            tCVE_MARCA.Text = ""
            tCVE_MODELO.Text = ""
            tNUM_SERIE_UNI.Text = ""
            tColor.Text = ""
            tCVE_ART.Text = ""
            tCVE_TANQUE1.Text = ""
            tCVE_TANQUE2.Text = ""
            tCVE_DOLLY.Text = ""
            tCVE_TANQUE1.Tag = ""
            tCVE_TANQUE2.Tag = ""
            tCVE_DOLLY.Tag = ""
            tCVE_GRUPO.Text = ""
            tIDENT_SAT.Text = ""
            tIDENT_CON.Text = ""
            tRendimiento.Text = ""
            tULTIMO_KM.Text = ""
            tULTIMO_DIS.Text = ""
            FUltReset.Value = Now
            FUltServ.Value = Now
            FProxServ.Value = Now

            tFchUltLavada.Value = Now

            tDIAS_SERV.Text = ""
            tKM_SER.Text = ""
            tCVE_DOC.Text = ""
            tGarantia.Text = ""
            tULT_DIST_RECR.Text = ""
            FFechaCompra.Value = Now
            tCVE_OBSCOMP.Text = ""
            tCVE_OBSCOMP.Tag = 0

            tPLACAS_MEX.Text = ""
            FFVencPlacasMex.Value = Now
            tPLACAS_EU.Text = ""
            FVencPlacasEU.Value = Now
            tPLACAS_DEF.Text = ""
            tPERMISO_SCT.Text = ""
            tVERIFICACION.Text = ""
            FVencVeri.Value = Now
            chTV.Value = 0
            chAC.Value = 0
            chWIFI.Value = 0
            chDiscapa.Value = 0
            tVEL_PROM.Text = ""
            tNEUTRALIZADORES.Text = ""
            tFRE_BRUS.Text = ""
            tCAR_ACELE.Text = ""
            tACC_PED_FRENO.Text = ""
            tVEL_MAX_MOTOR.Text = ""
            tPORC_ULT_CAMBIO.Text = ""
            tLargo.Text = ""
            tAncho.Text = ""
            tAlto.Text = ""
            tCapacidad.Text = ""
            tNUM_EJES.Text = ""

            tEJES.Value = 0

            tNUM_LLANTAS.Text = ""
            tLLANTAS_REF.Text = ""
            If cboMarcaLlanta.Items.Count > 0 Then
                cboMarcaLlanta.SelectedIndex = 0
            End If
            If cboModeloLlanta.Items.Count > 0 Then
                cboModeloLlanta.SelectedIndex = 0
            End If
            If cboMedidaLlanta.Items.Count > 0 Then
                cboMedidaLlanta.SelectedIndex = 0
            End If
            If cboTipoLlanta.Items.Count > 0 Then
                cboTipoLlanta.SelectedIndex = 0
            End If
            If cboTipoLlanta.Items.Count > 0 Then
                cboTipoLlanta.SelectedIndex = 0
            End If

            tCAP_TANQUE_LT.Text = ""
            tCAP_TANQUE_MI.Text = ""
            tREN_CAR_KM.Text = ""
            tREN_CAR_MI.Text = ""
            tREN_VAC_KM.Text = ""
            tREN_VAC_MI.Text = ""
            tTARJ_COMB.Text = ""
            tTARJ_COMB2.Text = ""
            tTARJ_COMB3.Text = ""
            tOD_TARJ_IAVE.Text = ""
            tOD_TARJ_EPASS.Text = ""
            tOD_PORC.Text = ""
            tOD_ODOMETRO_KM.Text = ""
            tOD_ODOMETRO_GPS_KM.Text = ""
            tOD_ODOMETRO_MI.Text = ""
            tOD_ODOMETRO_GPS_MI.Text = ""
            tOD_HOROMETRO.Text = ""
            tOD_HOROMETRO_MIN.Text = ""

            If cboPropietario.Items.Count > 0 Then
                cboPropietario.SelectedIndex = 0
            End If
            tSE_ASEGURADORA.Text = ""
            tSE_TEL.Text = ""
            tSE_NO_SEG.Text = ""
            FVencSeg.Value = Now
            chSE_AMPLIA.Checked = False
            chSE_LIMITADA.Checked = False
            chSE_SIN_COBERTURA.Checked = False
            chPARO_X_RALENTI.Value = 0
            tT_P_MOTOR_RELENTI.Text = ""
            'tFD_DESCR.text = ""
            'tFD_ARCHIVO.text = ""
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub
    Sub CARGAR_SERVICIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String
            Dim CVE_ORD As String

            cmd.Connection = cnSAE

            CVE_ORD = ""
            SQL = "SELECT TOP 1 CVE_ORD FROM GCORDEN_TRABAJO GROUP BY CVE_ORD ORDER BY MAX(FECHA) DESC"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                CVE_ORD = dr("CVE_ORD")
            End If
            dr.Close()
            If CVE_ORD.Trim.Length > 0 Then

                Lt1.Text = CVE_ORD

                SQL = "SELECT O.CVE_ORD, FECHA, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(O.NO_PARTE,'') AS N_PARTE, " &
                "ISNULL(TIEMPO_SER,0) AS SERV, ISNULL(TIEMPO_REAL,0) AS REAL, ISNULL(TIPO,0) AS TIPO_I, ISNULL(S.DESCR,'') AS DES2, O.STATUS AS ST " &
                "FROM GCORDEN_TRA_SER O " &
                "LEFT JOIN GCORDEN_TRABAJO T ON T.CVE_ORD = O.CVE_ORD " &
                "LEFT JOIN GCINVER I ON I.CVE_ART = O.CVE_ART " &
                "LEFT JOIN GCSERVICIOS S ON S.CVE_SER = O.CVE_ART " &
                "WHERE O.CVE_ORD = '" & CVE_ORD & "' ORDER BY FECHA"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                Fg.Rows.Count = 1
                Do While dr.Read
                    Lt2.Text = dr("FECHA")
                    If dr("DES").ToString.Length = 0 Then
                        DESCR = dr("DES2")
                    Else
                        DESCR = dr("DES")
                    End If
                    Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & dr("CANTI") & vbTab &
                               dr("SERV") & vbTab & dr("REAL") & vbTab & dr("TIPO_I") & vbTab & dr("ST") & vbTab & dr("CANTI"))
                    Fg.Rows(Fg.Rows.Count - 1).Height = 30
                Loop
                dr.Close()

            End If
        Catch ex As Exception
            'MsgBox("36. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("36. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_CAT()

        Dim cmd As New SqlCommand
        Dim z As Integer
        cmd.Connection = cnSAE

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT * FROM GCMARCAS WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboMarcaLlanta.Items.Clear()
            Do While dr.Read
                cboMarcaLlanta.Items.Add(New ValueDescriptionPair(dr("CVE_MARCA"), dr("DESCR"), dr("CVE_MARCA"), "", z))
                z = z + 1
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_MODELO,0) AS IDE, ISNULL(DESCR,'') AS NOM FROM GCLLANTA_MODELO WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboModeloLlanta.Items.Clear()
            Do While dr.Read
                'z = dr("IDE")
                cboModeloLlanta.Items.Add(New ValueDescriptionPair(dr("IDE"), dr("NOM"), dr("IDE"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_MED,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCLLANTA_MEDIDA WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboMedidaLlanta.Items.Clear()
            Do While dr.Read
                'z = dr("TIPO")
                cboMedidaLlanta.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("37. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("37. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCLLANTA_TIPO WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboTipoLlanta.Items.Clear()
            Do While dr.Read
                ' z = dr("TIPO")
                cboTipoLlanta.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("46. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("46. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_PROP,0) AS TIPO, ISNULL(NOMBRE,'') AS NOM FROM GCPROPIETARIOS WHERE STATUS = 'A' ORDER BY NOMBRE"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboPropietario.Items.Clear()
            Do While dr.Read
                'z = dr("TIPO")
                cboPropietario.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("47. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("47. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCTIPO_COMBUSTIBLE WHERE STATUS = 'A' ORDER BY DESCR"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboTipoComb.Items.Clear()
            Do While dr.Read
                'z = dr("TIPO")
                cboTipoComb.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("48. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("48. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub DOC_FOTOS(fCLAVE As String)

        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'U'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgFotDoc.Rows.Count = 1
            'CLAVE	CVE_FOTDOC	DESCR	DOCUMENTO	CVE_OBS
            Do While dr.Read
                FgFotDoc.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT") & vbTab & "")
            Loop
            dr.Close()

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_MARCA_LLA As Integer, CVE_MODELO_LLA As Integer, CVE_MED As Integer, CVE_TIPO_LLA As Integer, CVE_TIPO_COM As Integer, CVE_PROP As Integer
        Dim CVE_OBSCOMP As Long, UltReset As String, UltServ As String, ProxServ As String, FechaCompra As String, FVencPlacasMex As String
        Dim VencPlacasEU As String, VencVeri As String, VencSeg As String, MOTIVO_BAJA As String = ""

        Dim cmd As New SqlCommand
        Try

            If BtnActivo.Text = "Baja" Then
                If TMOTIVO_BAJA.Text.Trim.Length < 30 Then
                    'MsgBox("Por favor capture el motivo de baja del operador, al menos 30 caracteres")
                    'Tab1.SelectedIndex = 8
                    'Return
                End If
            End If

            MOTIVO_BAJA = TMOTIVO_BAJA.Text.Trim
            If MOTIVO_BAJA.Length > 255 Then
                MOTIVO_BAJA = MOTIVO_BAJA.Substring(0, 255)
            End If

            If LLantaAsignada(tLL1.Text, 1) Then
                tLL1.Text = ""
                Return
            End If
            If LLantaAsignada(tLL2.Text, 2) Then
                tLL2.Text = ""
                Return
            End If
            If LLantaAsignada(tLL3.Text, 3) Then
                tLL3.Text = ""
                Return
            End If
            If LLantaAsignada(tLL4.Text, 4) Then
                tLL4.Text = ""
                Return
            End If
            If LLantaAsignada(tLL5.Text, 5) Then
                tLL5.Text = ""
                Return
            End If
            If LLantaAsignada(tLL6.Text, 6) Then
                tLL6.Text = ""
                Return
            End If
            If LLantaAsignada(tLL7.Text, 7) Then
                tLL7.Text = ""
                Return
            End If
            If LLantaAsignada(tLL8.Text, 8) Then
                tLL8.Text = ""
                Return
            End If
            If LLantaAsignada(tLL9.Text, 9) Then
                tLL9.Text = ""
                Return
            End If
            If LLantaAsignada(tLL10.Text, 10) Then
                tLL10.Text = ""
                Return
            End If
            If LLantaAsignada(tLL11.Text, 11) Then
                tLL11.Text = ""
                Return
            End If
            If LLantaAsignada(tLL12.Text, 12) Then
                tLL12.Text = ""
                Return
            End If
        Catch ex As Exception
        End Try
        Try
            UltReset = FSQL(FUltReset.Value)
            UltServ = FSQL(FUltServ.Value)
            ProxServ = FSQL(FProxServ.Value)
            FechaCompra = FSQL(FFechaCompra.Value)
            FVencPlacasMex = FSQL(FFVencPlacasMex.Value)
            VencPlacasEU = FSQL(FVencPlacasEU.Value)

            VencVeri = FSQL(FVencVeri.Value)
            VencSeg = FSQL(FVencSeg.Value)
        Catch ex As Exception

        End Try

        Try
            If cboMarcaLlanta.SelectedIndex = -1 Then
                CVE_MARCA_LLA = 0
            Else
                CVE_MARCA_LLA = CType(cboMarcaLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("49. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If cboModeloLlanta.SelectedIndex = -1 Then
                CVE_MODELO_LLA = 0
            Else
                CVE_MODELO_LLA = CType(cboModeloLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If cboMedidaLlanta.SelectedIndex = -1 Then
                CVE_MED = 0
            Else
                CVE_MED = CType(cboMedidaLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If cboTipoLlanta.SelectedIndex = -1 Then
                CVE_TIPO_LLA = 0
            Else
                CVE_TIPO_LLA = CType(cboTipoLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If cboTipoComb.SelectedIndex = -1 Then
                CVE_TIPO_COM = 0
            Else
                CVE_TIPO_COM = CType(cboTipoComb.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If cboPropietario.SelectedIndex = -1 Then
                CVE_PROP = 0
            Else
                CVE_PROP = CType(cboPropietario.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("54. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("54. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If tCVE_TANQUE1.Focused Then
            If tCVE_TANQUE1.Text.Trim.Length = 0 Then
                tCVE_TANQUE1.Tag = ""
            End If
        End If
        If tCVE_TANQUE2.Focused Then
            If tCVE_TANQUE2.Text.Trim.Length = 0 Then
                tCVE_TANQUE2.Tag = ""
            End If
        End If
        If tCVE_DOLLY.Focused Then
            If tCVE_DOLLY.Text.Trim.Length = 0 Then
                tCVE_DOLLY.Tag = ""
            End If
        End If
        Try
            If tCVE_OBSCOMP.Text.Trim.Length > 0 Then
                If IsNumeric(tCVE_OBSCOMP.Tag) Then
                    CVE_OBSCOMP = tCVE_OBSCOMP.Tag
                Else
                    CVE_OBSCOMP = 0
                End If

                If CVE_OBSCOMP = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tCVE_OBSCOMP.Text & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBSCOMP = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tCVE_OBSCOMP.Text & "' WHERE CVE_OBS = " & CVE_OBSCOMP
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If

            tCVE_OBSCOMP.Tag = CVE_OBSCOMP
        Catch ex As Exception
            MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCUNIDADES SET CLAVEMONTE = @CLAVEMONTE, RENTADO = @RENTADO, UNIDAD_PERMISI = @UNIDAD_PERMISI, DESCR = @DESCR, 
            CVE_TIPO_UNI = @CVE_TIPO_UNI, CVE_SUC = @CVE_SUC, CVE_OPER = @CVE_OPER, CVE_MARCA = @CVE_MARCA, CVE_MODELO = @CVE_MODELO, 
            NUM_SERIE_UNI = @NUM_SERIE_UNI, COLOR = @COLOR, CVE_ART = @CVE_ART, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, 
            CVE_DOLLY = @CVE_DOLLY, CVE_GRUPO = @CVE_GRUPO, IDENT_SAT = @IDENT_SAT, IDENT_CON = @IDENT_CON, RENDIMIENTO = @RENDIMIENTO, 
            ULTIMO_KM = @ULTIMO_KM, ULTIMO_DIS = @ULTIMO_DIS, FEC_ULT_RES = @FEC_ULT_RES, FEC_ULT_SER = @FEC_ULT_SER, FEC_PROX_RES = @FEC_PROX_RES, 
            DIAS_SERV = @DIAS_SERV, KM_SER = @KM_SER, CVE_DOC = @CVE_DOC, GARANTIA = @GARANTIA, ULT_DIST_RECR = @ULT_DIST_RECR, FECHA_DOC = @FECHA_DOC, 
            CVE_DOC_ASEG = @CVE_DOC_ASEG, CVE_OBSCOMP = @CVE_OBSCOMP, CHLL1 = @CHLL1, CHLL2 = @CHLL2, CHLL3 = @CHLL3, CHLL4 = @CHLL4, CHLL5 = @CHLL5, 
            CHLL6 = @CHLL6, CHLL7 = @CHLL7, CHLL8 = @CHLL8, CHLL9 = @CHLL9, CHLL10 = @CHLL10, CHLL11 = @CHLL11, CHLL12 = @CHLL12, 
            PLACAS_MEX = @PLACAS_MEX, FPLA_VENC = @FPLA_VENC, PLACAS_EU = @PLACAS_EU, FPLA_VENC_EU = @FPLA_VENC_EU, PLACAS_DEF = @PLACAS_DEF, 
            PERMISO_SCT = @PERMISO_SCT, VERIFICACION = @VERIFICACION, FVENC_VER = @FVENC_VER, CHTV = @CHTV, CHAC = @CHAC, CHWIFI = @CHWIFI, 
            CHDISCAPA = @CHDISCAPA, VEL_PROM = @VEL_PROM, NEUTRALIZADORES = @NEUTRALIZADORES, FRE_BRUS = @FRE_BRUS, CAR_ACELE = @CAR_ACELE, 
            ACC_PED_FRENO = @ACC_PED_FRENO, VEL_MAX_MOTOR = @VEL_MAX_MOTOR, PORC_ULT_CAMBIO = @PORC_ULT_CAMBIO, LARGO = @LARGO, ANCHO = @ANCHO, 
            ALTO = @ALTO, CAPACIDAD = @CAPACIDAD, NUM_EJES = @NUM_EJES, NUM_LLANTAS = @NUM_LLANTAS, LLANTAS_REF = @LLANTAS_REF, 
            CVE_MARCA_LLA = @CVE_MARCA_LLA, CVE_MODELO_LLA = @CVE_MODELO_LLA, CVE_MED = @CVE_MED, CVE_TIPO_LLA = @CVE_TIPO_LLA, TIPO_MOTOR = @TIPO_MOTOR,
            NUM_SERIE_MOT = @NUM_SERIE_MOT, TIPO_TRANS = @TIPO_TRANS, CVE_OBSER_MOT = @CVE_OBSER_MOT, CVE_TIPO_COM = @CVE_TIPO_COM, 
            CAP_TANQUE_LT = @CAP_TANQUE_LT, CAP_TANQUE_MI = @CAP_TANQUE_MI, REN_CAR_KM = @REN_CAR_KM, REN_CAR_MI = @REN_CAR_MI, REN_VAC_KM = @REN_VAC_KM,
            REN_VAC_MI = @REN_VAC_MI, TARJ_COMB = @TARJ_COMB, TARJ_COMB2 = @TARJ_COMB2, TARJ_COMB3 = @TARJ_COMB3, OD_TARJ_IAVE = @OD_TARJ_IAVE,
            OD_TARJ_EPASS = @OD_TARJ_EPASS, OD_PORC = @OD_PORC, OD_ODOMETRO_KM = @OD_ODOMETRO_KM, OD_ODOMETRO_GPS_KM = @OD_ODOMETRO_GPS_KM, 
            OD_ODOMETRO_MI = @OD_ODOMETRO_MI, OD_ODOMETRO_GPS_MI = @OD_ODOMETRO_GPS_MI, OD_HOROMETRO = @OD_HOROMETRO, OD_HOROMETRO_MIN = @OD_HOROMETRO_MIN,
            CVE_PROP = @CVE_PROP, SE_ASEGURADORA = @SE_ASEGURADORA, SE_TEL = @SE_TEL, SE_NO_SEG = @SE_NO_SEG, SE_VENC = @SE_VENC, SE_AMPLIA = @SE_AMPLIA,
            SE_LIMITADA = @SE_LIMITADA, SE_SIN_COBERTURA = @SE_SIN_COBERTURA, PARO_X_RALENTI = @PARO_X_RALENTI, T_P_MOTOR_RELENTI = @T_P_MOTOR_RELENTI, 
            FCHULTLAVADA = @FCHULTLAVADA, EJES = @EJES, NIVEL = @NIVEL, NIVEL2 = @NIVEL2, NIVEL3 = @NIVEL3, CVE_TAQ = @CVE_TAQ, CVE_MOT = @CVE_MOT, 
            CUEN_CONT = @CUEN_CONT, CUEN_CONT2 = @CUEN_CONT2, CUEN_CONT_VTA = @CUEN_CONT_VTA, SUBTIPOREM = @SUBTIPOREM, ANO_MODELO = @ANO_MODELO, 
            CVE_REND = @CVE_REND, CTA_CON_DIESEL = @CTA_CON_DIESEL, CTA_CON_DIESEL_SIVA = @CTA_CON_DIESEL_SIVA, STATUS = @STATUS, MOTIVO_BAJA = @MOTIVO_BAJA
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, RENTADO, UNIDAD_PERMISI, DESCR, CVE_TIPO_UNI, CVE_SUC, CVE_OPER, CVE_MARCA, CVE_MODELO,
            NUM_SERIE_UNI, COLOR, CVE_ART, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, CVE_GRUPO, IDENT_SAT, IDENT_CON, RENDIMIENTO, ULTIMO_KM, ULTIMO_DIS, 
            FEC_ULT_RES, FEC_ULT_SER, FEC_PROX_RES, FCHULTLAVADA, DIAS_SERV, KM_SER, CVE_DOC, GARANTIA, ULT_DIST_RECR, FECHA_DOC, CVE_DOC_ASEG, 
            CVE_OBSCOMP, CHLL1, CHLL2, CHLL3, CHLL4, CHLL5, CHLL6, CHLL7, CHLL8, CHLL9, CHLL10, CHLL11, CHLL12, PLACAS_MEX, FPLA_VENC, PLACAS_EU, 
            FPLA_VENC_EU, PLACAS_DEF, PERMISO_SCT, VERIFICACION, FVENC_VER, CHTV, CHAC, CHWIFI, CHDISCAPA, VEL_PROM, NEUTRALIZADORES, FRE_BRUS, 
            CAR_ACELE, ACC_PED_FRENO, VEL_MAX_MOTOR, PORC_ULT_CAMBIO, LARGO, ANCHO, ALTO, CAPACIDAD, NUM_EJES, NUM_LLANTAS, LLANTAS_REF, CVE_MARCA_LLA,
            CVE_MODELO_LLA, CVE_MED, CVE_TIPO_LLA, TIPO_MOTOR, NUM_SERIE_MOT, TIPO_TRANS, CVE_OBSER_MOT, CVE_TIPO_COM, CAP_TANQUE_LT, CAP_TANQUE_MI, 
            REN_CAR_KM, REN_CAR_MI, REN_VAC_KM, REN_VAC_MI, TARJ_COMB, TARJ_COMB2, TARJ_COMB3, OD_TARJ_IAVE, OD_TARJ_EPASS, OD_PORC, OD_ODOMETRO_KM,
            OD_ODOMETRO_GPS_KM, OD_ODOMETRO_MI, OD_ODOMETRO_GPS_MI, OD_HOROMETRO, OD_HOROMETRO_MIN, CVE_PROP, SE_ASEGURADORA, SE_TEL, SE_NO_SEG, SE_VENC,
            SE_AMPLIA, SE_LIMITADA, SE_SIN_COBERTURA, PARO_X_RALENTI, T_P_MOTOR_RELENTI, EJES, NIVEL, NIVEL2, NIVEL3, CVE_TAQ, CVE_MOT, CUEN_CONT, 
            CUEN_CONT2, CUEN_CONT_VTA, SUBTIPOREM, ANO_MODELO, CVE_REND, CTA_CON_DIESEL, CTA_CON_DIESEL_SIVA, MOTIVO_BAJA) 
            VALUES(
            @CLAVE, @CLAVEMONTE,'A', @RENTADO, @UNIDAD_PERMISI, @DESCR, @CVE_TIPO_UNI, @CVE_SUC, @CVE_OPER, @CVE_MARCA, @CVE_MODELO, @NUM_SERIE_UNI,
            @COLOR, @CVE_ART, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, @CVE_GRUPO, @IDENT_SAT, @IDENT_CON, @RENDIMIENTO, @ULTIMO_KM, @ULTIMO_DIS, 
            @FEC_ULT_RES, @FEC_ULT_SER, @FEC_PROX_RES, @FCHULTLAVADA, @DIAS_SERV, @KM_SER, @CVE_DOC, @GARANTIA, @ULT_DIST_RECR, @FECHA_DOC, @CVE_DOC_ASEG,
            @CVE_OBSCOMP, @CHLL1, @CHLL2, @CHLL3, @CHLL4, @CHLL5, @CHLL6, @CHLL7, @CHLL8, @CHLL9, @CHLL10, @CHLL11, @CHLL12, @PLACAS_MEX, @FPLA_VENC, 
            @PLACAS_EU, @FPLA_VENC_EU, @PLACAS_DEF, @PERMISO_SCT, @VERIFICACION, @FVENC_VER, @CHTV, @CHAC, @CHWIFI, @CHDISCAPA, @VEL_PROM, @NEUTRALIZADORES,
            @FRE_BRUS, @CAR_ACELE, @ACC_PED_FRENO, @VEL_MAX_MOTOR, @PORC_ULT_CAMBIO, @LARGO, @ANCHO, @ALTO, @CAPACIDAD, @NUM_EJES, @NUM_LLANTAS, 
            @LLANTAS_REF, @CVE_MARCA_LLA, @CVE_MODELO_LLA, @CVE_MED, @CVE_TIPO_LLA, @TIPO_MOTOR, @NUM_SERIE_MOT, @TIPO_TRANS, @CVE_OBSER_MOT, @CVE_TIPO_COM,
            @CAP_TANQUE_LT, @CAP_TANQUE_MI, @REN_CAR_KM, @REN_CAR_MI, @REN_VAC_KM, @REN_VAC_MI, @TARJ_COMB, @TARJ_COMB2, @TARJ_COMB3, @OD_TARJ_IAVE,
            @OD_TARJ_EPASS, @OD_PORC, @OD_ODOMETRO_KM, @OD_ODOMETRO_GPS_KM, @OD_ODOMETRO_MI, @OD_ODOMETRO_GPS_MI, @OD_HOROMETRO, @OD_HOROMETRO_MIN, @CVE_PROP, 
            @SE_ASEGURADORA, @SE_TEL, @SE_NO_SEG, @SE_VENC, @SE_AMPLIA, @SE_LIMITADA, @SE_SIN_COBERTURA, @PARO_X_RALENTI, @T_P_MOTOR_RELENTI, @EJES, 
            @NIVEL, @NIVEL2, @NIVEL3, @CVE_TAQ, @CVE_MOT, @CUEN_CONT, @CUEN_CONT2, @CUEN_CONT_VTA, @SUBTIPOREM, @ANO_MODELO, @CVE_REND, 
            @CTA_CON_DIESEL, @CTA_CON_DIESEL_SIVA, @MOTIVO_BAJA)"
        cmd.Connection = cnSAE
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = tCLAVE.Text
            cmd.Parameters.Add("@CLAVEMONTE", SqlDbType.VarChar).Value = tClaveMonte.Text

            cmd.Parameters.Add("@RENTADO", SqlDbType.SmallInt).Value = chRentada.Value
            cmd.Parameters.Add("@UNIDAD_PERMISI", SqlDbType.SmallInt).Value = chUniPer.Value
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDescr.Text
            cmd.Parameters.Add("@CVE_TIPO_UNI", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tUni.Text)
            cmd.Parameters.Add("@CVE_SUC", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tSuc.Text)
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_OPER.Text)
            cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = tCVE_MARCA.Text
            cmd.Parameters.Add("@CVE_MODELO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_MODELO.Text)
            cmd.Parameters.Add("@NUM_SERIE_UNI", SqlDbType.VarChar).Value = tNUM_SERIE_UNI.Text
            cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = tColor.Text
            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(tCVE_ART.Text)

            cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_TANQUE1.Tag)
            cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_TANQUE2.Tag)
            cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_DOLLY.Tag)

            cmd.Parameters.Add("@CVE_GRUPO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCVE_GRUPO.Text)
            cmd.Parameters.Add("@IDENT_SAT", SqlDbType.VarChar).Value = tIDENT_SAT.Text
            cmd.Parameters.Add("@IDENT_CON", SqlDbType.VarChar).Value = tIDENT_CON.Text
            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.VarChar).Value = tRendimiento.Text
            cmd.Parameters.Add("@ULTIMO_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tULTIMO_KM.Text)
            cmd.Parameters.Add("@ULTIMO_DIS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tULTIMO_DIS.Text)

            cmd.Parameters.Add("@FEC_ULT_RES", SqlDbType.Date).Value = FUltReset.Value
            cmd.Parameters.Add("@FEC_ULT_SER", SqlDbType.Date).Value = FUltServ.Value
            cmd.Parameters.Add("@FEC_PROX_RES", SqlDbType.Date).Value = FProxServ.Value
            cmd.Parameters.Add("@FCHULTLAVADA", SqlDbType.Date).Value = tFchUltLavada.Value
            cmd.Parameters.Add("@DIAS_SERV", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tDIAS_SERV.Text)
            cmd.Parameters.Add("@KM_SER", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKM_SER.Text)
            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = tCVE_DOC.Text
            cmd.Parameters.Add("@GARANTIA", SqlDbType.VarChar).Value = tGarantia.Text

            cmd.Parameters.Add("@ULT_DIST_RECR", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tULT_DIST_RECR.Text)
            cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = FFechaCompra.Value
            cmd.Parameters.Add("@CVE_DOC_ASEG", SqlDbType.VarChar).Value = tCVE_DOC_ASEG.Text
            cmd.Parameters.Add("@CVE_OBSCOMP", SqlDbType.Int).Value = CVE_OBSCOMP
            cmd.Parameters.Add("@CHLL1", SqlDbType.VarChar).Value = tLL1.Text
            cmd.Parameters.Add("@CHLL2", SqlDbType.VarChar).Value = tLL2.Text
            cmd.Parameters.Add("@CHLL3", SqlDbType.VarChar).Value = tLL3.Text
            cmd.Parameters.Add("@CHLL4", SqlDbType.VarChar).Value = tLL4.Text
            cmd.Parameters.Add("@CHLL5", SqlDbType.VarChar).Value = tLL5.Text
            cmd.Parameters.Add("@CHLL6", SqlDbType.VarChar).Value = tLL6.Text
            cmd.Parameters.Add("@CHLL7", SqlDbType.VarChar).Value = tLL7.Text
            cmd.Parameters.Add("@CHLL8", SqlDbType.VarChar).Value = tLL8.Text
            cmd.Parameters.Add("@CHLL9", SqlDbType.VarChar).Value = tLL9.Text
            cmd.Parameters.Add("@CHLL10", SqlDbType.VarChar).Value = tLL10.Text
            cmd.Parameters.Add("@CHLL11", SqlDbType.VarChar).Value = tLL11.Text
            cmd.Parameters.Add("@CHLL12", SqlDbType.VarChar).Value = tLL12.Text
            cmd.Parameters.Add("@PLACAS_MEX", SqlDbType.VarChar).Value = tPLACAS_MEX.Text
            cmd.Parameters.Add("@FPLA_VENC", SqlDbType.Date).Value = FFVencPlacasMex.Value
            cmd.Parameters.Add("@PLACAS_EU", SqlDbType.VarChar).Value = tPLACAS_EU.Text
            cmd.Parameters.Add("@FPLA_VENC_EU", SqlDbType.Date).Value = FVencPlacasEU.Value
            cmd.Parameters.Add("@PLACAS_DEF", SqlDbType.VarChar).Value = tPLACAS_DEF.Text
            cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = tPERMISO_SCT.Text
            cmd.Parameters.Add("@VERIFICACION", SqlDbType.VarChar).Value = tVERIFICACION.Text

            cmd.Parameters.Add("@FVENC_VER", SqlDbType.Date).Value = FVencVeri.Value
            cmd.Parameters.Add("@CHTV", SqlDbType.SmallInt).Value = chTV.Value
            cmd.Parameters.Add("@CHAC", SqlDbType.SmallInt).Value = chAC.Value
            cmd.Parameters.Add("@CHWIFI", SqlDbType.SmallInt).Value = chWIFI.Value
            cmd.Parameters.Add("@CHDISCAPA", SqlDbType.SmallInt).Value = chDiscapa.Value
            cmd.Parameters.Add("@VEL_PROM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tVEL_PROM.Text)
            cmd.Parameters.Add("@NEUTRALIZADORES", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tNEUTRALIZADORES.Text)
            cmd.Parameters.Add("@FRE_BRUS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tFRE_BRUS.Text)
            cmd.Parameters.Add("@CAR_ACELE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCAR_ACELE.Text)
            cmd.Parameters.Add("@ACC_PED_FRENO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tACC_PED_FRENO.Text)
            cmd.Parameters.Add("@VEL_MAX_MOTOR", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tVEL_MAX_MOTOR.Text)
            cmd.Parameters.Add("@PORC_ULT_CAMBIO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tPORC_ULT_CAMBIO.Text)
            cmd.Parameters.Add("@LARGO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tLargo.Text)
            cmd.Parameters.Add("@ANCHO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tAncho.Text)
            cmd.Parameters.Add("@ALTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tAlto.Text)
            cmd.Parameters.Add("@CAPACIDAD", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCapacidad.Text)
            cmd.Parameters.Add("@NUM_EJES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_EJES.Text)

            cmd.Parameters.Add("@NUM_LLANTAS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_LLANTAS.Text)
            cmd.Parameters.Add("@LLANTAS_REF", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tLLANTAS_REF.Text)
            cmd.Parameters.Add("@CVE_MARCA_LLA", SqlDbType.SmallInt).Value = CVE_MARCA_LLA
            cmd.Parameters.Add("@CVE_MODELO_LLA", SqlDbType.SmallInt).Value = CVE_MODELO_LLA
            cmd.Parameters.Add("@CVE_MED", SqlDbType.SmallInt).Value = CVE_MED
            cmd.Parameters.Add("@CVE_TIPO_LLA", SqlDbType.SmallInt).Value = CVE_TIPO_LLA

            cmd.Parameters.Add("@TIPO_MOTOR", SqlDbType.VarChar).Value = tTIPO_MOTOR.Text
            cmd.Parameters.Add("@NUM_SERIE_MOT", SqlDbType.VarChar).Value = tNUM_SERIE_MOT.Text
            cmd.Parameters.Add("@TIPO_TRANS", SqlDbType.VarChar).Value = tTIPO_TRANS.Text
            cmd.Parameters.Add("@CVE_OBSER_MOT", SqlDbType.VarChar).Value = tCVE_OBSER_MOT.Text

            cmd.Parameters.Add("@CVE_TIPO_COM", SqlDbType.SmallInt).Value = CVE_TIPO_COM
            cmd.Parameters.Add("@CAP_TANQUE_LT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCAP_TANQUE_LT.Text)
            cmd.Parameters.Add("@CAP_TANQUE_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCAP_TANQUE_MI.Text)
            cmd.Parameters.Add("@REN_CAR_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tREN_CAR_KM.Text)
            cmd.Parameters.Add("@REN_CAR_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tREN_CAR_MI.Text)
            cmd.Parameters.Add("@REN_VAC_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tREN_VAC_KM.Text)
            cmd.Parameters.Add("@REN_VAC_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tREN_VAC_MI.Text)
            cmd.Parameters.Add("@TARJ_COMB", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTARJ_COMB.Text)
            cmd.Parameters.Add("@TARJ_COMB2", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTARJ_COMB2.Text)
            cmd.Parameters.Add("@TARJ_COMB3", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTARJ_COMB3.Text)
            cmd.Parameters.Add("@OD_TARJ_IAVE", SqlDbType.VarChar).Value = tOD_TARJ_IAVE.Text
            cmd.Parameters.Add("@OD_TARJ_EPASS", SqlDbType.VarChar).Value = tOD_TARJ_EPASS.Text
            cmd.Parameters.Add("@OD_PORC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tOD_PORC.Text)
            cmd.Parameters.Add("@OD_ODOMETRO_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tOD_ODOMETRO_KM.Text)
            cmd.Parameters.Add("@OD_ODOMETRO_GPS_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tOD_ODOMETRO_GPS_KM.Text)
            cmd.Parameters.Add("@OD_ODOMETRO_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tOD_ODOMETRO_MI.Text)
            cmd.Parameters.Add("@OD_ODOMETRO_GPS_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tOD_ODOMETRO_GPS_MI.Text)
            cmd.Parameters.Add("@OD_HOROMETRO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tOD_HOROMETRO.Text)
            cmd.Parameters.Add("@OD_HOROMETRO_MIN", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tOD_HOROMETRO_MIN.Text)
            cmd.Parameters.Add("@CVE_PROP", SqlDbType.SmallInt).Value = CVE_PROP
            cmd.Parameters.Add("@SE_ASEGURADORA", SqlDbType.VarChar).Value = tSE_ASEGURADORA.Text
            cmd.Parameters.Add("@SE_TEL", SqlDbType.VarChar).Value = tSE_TEL.Text
            cmd.Parameters.Add("@SE_NO_SEG", SqlDbType.VarChar).Value = tSE_NO_SEG.Text
            cmd.Parameters.Add("@SE_VENC", SqlDbType.Date).Value = FVencSeg.Value
            cmd.Parameters.Add("@SE_AMPLIA", SqlDbType.SmallInt).Value = IIf(chSE_AMPLIA.Checked, 1, 0)
            cmd.Parameters.Add("@SE_LIMITADA", SqlDbType.SmallInt).Value = IIf(chSE_LIMITADA.Checked, 1, 0)
            cmd.Parameters.Add("@SE_SIN_COBERTURA", SqlDbType.SmallInt).Value = IIf(chSE_SIN_COBERTURA.Checked, 1, 0)
            cmd.Parameters.Add("@PARO_X_RALENTI", SqlDbType.SmallInt).Value = IIf(chPARO_X_RALENTI.Value, 1, 0)
            cmd.Parameters.Add("@T_P_MOTOR_RELENTI", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tT_P_MOTOR_RELENTI.Text)
            cmd.Parameters.Add("@EJES", SqlDbType.SmallInt).Value = tEJES.Value
            cmd.Parameters.Add("@NIVEL", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNIVEL.Tag)
            cmd.Parameters.Add("@NIVEL2", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNIVEL2.Tag)
            cmd.Parameters.Add("@NIVEL3", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNIVEL3.Tag)
            cmd.Parameters.Add("@CVE_TAQ", SqlDbType.SmallInt).Value = CONVERTIR_TO_DECIMAL(tCVE_TAQ.Text)
            cmd.Parameters.Add("@CVE_MOT", SqlDbType.SmallInt).Value = CONVERTIR_TO_DECIMAL(tCVE_MOT.Text)
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = tCUEN_CONT.Text
            cmd.Parameters.Add("@CUEN_CONT2", SqlDbType.VarChar).Value = tCUEN_CONT2.Text
            cmd.Parameters.Add("@CUEN_CONT_VTA", SqlDbType.VarChar).Value = TCUEN_CONT_VTA.Text
            cmd.Parameters.Add("@SUBTIPOREM", SqlDbType.VarChar).Value = TSubTipoRem1.Text
            cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = TANO_MODELO.Text
            cmd.Parameters.Add("@CVE_REND", SqlDbType.SmallInt).Value = CboRendimiento.SelectedIndex
            cmd.Parameters.Add("@CTA_CON_DIESEL", SqlDbType.VarChar).Value = TCTA_CON_DIESEL.Text
            cmd.Parameters.Add("@CTA_CON_DIESEL_SIVA", SqlDbType.VarChar).Value = TCTA_CON_DIESEL_SIVA.Text
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = IIf(BtnActivo.Text = "Activo", "A", "B")
            cmd.Parameters.Add("@MOTIVO_BAJA", SqlDbType.VarChar).Value = MOTIVO_BAJA
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    GRABA_POS_LLANTAS()

                    GRABA_FOTOS_DOC()

                    If BtnActivo.Text = "Baja" And BtnActivo.Text <> BtnActivo.Tag Then

                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCUNIDADES SET USUARIO_BAJA = '" & USER_GRUPOCE & "' WHERE CLAVE = '" & tCLAVE.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        GRABA_BITA(tCLAVE.Text, "", 0, "", MOTIVO_BAJA)
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
            Bitacora("56. ex.Message & vbNewLine & ex.StackTrace")
            MsgBox("56. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABA_POS_LLANTAS()
        If LL1.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 1, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL1.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL2.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 2, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL2.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL3.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 3, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL3.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL4.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 4, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL4.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL5.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 5, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL5.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL6.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 6, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL6.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL7.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 7, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL7.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL8.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 8, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL8.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL9.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 9, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL9.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL10.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 10, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL10.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL11.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 11, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL11.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
        If LL12.Text.Trim.Length > 0 Then
            SQL = "UPDATE GCLLANTAS SET POSICION = 12, UNIDAD = '" & tClaveMonte.Text & "' WHERE NUM_ECONOMICO = '" & LL12.Text & "'"
            EXECUTE_QUERY_NET(SQL)
        End If
    End Sub

    Sub GRABA_FOTOS_DOC()

        Dim DESCR As String
        Dim DOC As String
        Dim CVE_FOT As Integer
        Dim RUTA_O As String

        Dim cmd As New SqlCommand

        cmd.Connection = cnSAE
        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCLAVE.Text & "' AND TIPO_DOC = 'U'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue = "1" Then
            End If

        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try 'FgFotDoc.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))
        For k = 1 To FgFotDoc.Rows.Count - 1
            Try
                DESCR = FgFotDoc(k, 1)
                DOC = FgFotDoc(k, 2)
                CVE_FOT = FgFotDoc(k, 3)
                RUTA_O = FgFotDoc(k, 4)

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC)" &
                    " VALUES ('" & tCLAVE.Text & "','" & CVE_FOT & "','" & DESCR & "','" & DOC & "','U')"

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        SQL = ""

                        If RUTA_O.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(RUTA_O)
                            Dim newPath = Path.Combine(RUTA_O, DOC)
                            File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                        End If
                        DESCR = ""
                        DOC = ""
                        CVE_FOT = 0
                        RUTA_O = ""
                    End If
                End If
            Catch ex As Exception
                MsgBox("101. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("101. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub btnTipoUni_Click(sender As Object, e As EventArgs) Handles btnTipoUni.Click
        Try
            Var2 = "Tipo Unidad"
            Var3 = ""
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tUni.Text = Var4
                LtTractor.Text = Var5
                L1.Text = Var5

                If tUni.Text.Trim = "2" Then
                    LR3.Visible = True
                    TSubTipoRem1.Visible = True
                    BtnSubTipoRem1.Visible = True
                    LTSubTipoRem1.Visible = True
                    CboRendimiento.Visible = False
                    LtRend.Visible = False
                Else
                    LR3.Visible = False
                    TSubTipoRem1.Visible = False
                    BtnSubTipoRem1.Visible = False
                    LTSubTipoRem1.Visible = False
                    If tUni.Text.Trim = "1" Then
                        CboRendimiento.Visible = True
                        LtRend.Visible = True
                    Else
                        CboRendimiento.Visible = False
                        LtRend.Visible = False
                    End If
                End If

                Var4 = "" : Var5 = ""
                tNIVEL.Focus()
            End If
        Catch Ex As Exception
            MsgBox("102. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("102. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSuc_Click(sender As Object, e As EventArgs) Handles btnSuc.Click
        Try

            Var2 = "Sucursal"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            'Var4 = Fg(Fg.Row, 1) 'CLAVE
            'Var5 = Fg(Fg.Row, 2) 'NOMBRE
            tSuc.Text = Var4
            L2.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
            tCVE_OPER.Focus()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try

            Var2 = "Operador"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            'Var4 = Fg(Fg.Row, 1) 'CLAVE
            'Var5 = Fg(Fg.Row, 2) 'NOMBRE
            tCVE_OPER.Text = Var4
            L3.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
            tCVE_MARCA.Focus()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Try

            Var2 = "Marca Unidad"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            'Var4 = Fg(Fg.Row, 1) 'CLAVE
            'Var5 = Fg(Fg.Row, 2) 'NOMBRE
            tCVE_MARCA.Text = Var4
            L4.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
            tCVE_MODELO.Focus()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Try

            Var2 = "Modelo"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            'Var4 = Fg(Fg.Row, 1) 'CLAVE
            'Var5 = Fg(Fg.Row, 2) 'NOMBRE
            tCVE_MODELO.Text = Var4
            L5.Text = Var5
            Var2 = ""
            Var4 = ""
            Var5 = ""
            tNUM_SERIE_UNI.Focus()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCveArt_Click(sender As Object, e As EventArgs) Handles btnCveArt.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            tCVE_ART.Text = Var4
            L6.Text = Var5
            tCVE_TANQUE1.Focus()
            Var2 = "" : Var4 = "" : Var5 = ""
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTanque1_Click(sender As Object, e As EventArgs) Handles btnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()

            If tCVE_TANQUE2.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If
            If tCVE_DOLLY.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If
            If UNIDAD_ASIGNADA(Var4) Then
                MsgBox("La unidad ya fue asignada " & Var3)
                tCVE_TANQUE1.Text = ""
                tCVE_TANQUE1.Select()
                Return
            End If
            Var3 = ""

            tCVE_TANQUE1.Text = Var5
            tCVE_TANQUE1.Tag = Var4
            LtTanque1.Text = Var6
            L7.Text = Var6

            Var2 = ""
            Var4 = ""
            Var5 = ""

            tCVE_TANQUE2.Focus()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTanque2_Click(sender As Object, e As EventArgs) Handles btnTanque2.Click
        Try

            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()

            If tCVE_TANQUE1.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If
            If tCVE_DOLLY.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If

            If UNIDAD_ASIGNADA(Var4) Then
                MsgBox("La unidad ya fue asignada " & Var3)
                tCVE_TANQUE2.Text = ""
                tCVE_TANQUE2.Select()
                Return
            End If
            Var3 = ""

            tCVE_TANQUE2.Text = Var5
            tCVE_TANQUE2.Tag = Var4
            LtTanque2.Text = Var6
            L8.Text = Var6

            Var2 = ""
            Var4 = ""
            Var5 = ""
            Var6 = ""
            tCVE_DOLLY.Focus()

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDolly_Click(sender As Object, e As EventArgs) Handles btnDolly.Click

        Try

            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()

            If tCVE_TANQUE1.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If
            If tCVE_TANQUE2.Text = Var4 Then
                MsgBox("Esta unidad ya s fue asignada verifique por favor")
                Return
            End If
            If UNIDAD_ASIGNADA(Var4) Then
                MsgBox("La unidad ya fue asignada " & Var3)
                tCVE_DOLLY.Text = ""
                tCVE_DOLLY.Select()
                Return
            End If
            Var3 = ""
            tCVE_DOLLY.Text = Var5
            tCVE_DOLLY.Tag = Var4
            LtDolly.Text = Var6
            L9.Text = Var6

            Var2 = ""
            Var4 = ""
            Var5 = ""
            tCVE_GRUPO.Focus()

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnGruUni_Click(sender As Object, e As EventArgs) Handles btnGruUni.Click

        Try

            Var2 = "Grupo Unidades"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            tCVE_GRUPO.Text = Var4
            L10.Text = Var5

            Var2 = ""
            Var4 = ""
            Var5 = ""
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnPlacasDefa_Click(sender As Object, e As EventArgs) Handles btnPlacasDefa.Click


        Try
            Var2 = "Placas Defa"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            tPLACAS_DEF.Text = Var4
            L11.Text = Var5

            Var2 = ""
            Var4 = ""
            Var5 = ""

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tColor_KeyDown(sender As Object, e As KeyEventArgs) Handles tColor.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab1.SelectedIndex = 1
        End If
    End Sub

    Private Sub tKM_SER_KeyDown(sender As Object, e As KeyEventArgs) Handles tKM_SER.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab1.SelectedIndex = 3
        End If
    End Sub

    Private Sub tCVE_OBSCOMP_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OBSCOMP.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab1.SelectedIndex = 4
        End If
    End Sub

    Private Sub FVencVeri_KeyDown(sender As Object, e As KeyEventArgs) Handles FVencVeri.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab2.SelectedIndex = 1
        End If
    End Sub

    Private Sub chDiscapa_KeyDown(sender As Object, e As KeyEventArgs) Handles chDiscapa.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab2.SelectedIndex = 2
        End If
    End Sub

    Private Sub tPORC_ULT_CAMBIO_KeyDown(sender As Object, e As KeyEventArgs) Handles tPORC_ULT_CAMBIO.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab3.SelectedIndex = 0
        End If
    End Sub

    Private Sub chLL8_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab2.SelectedIndex = 0
            Tab2.Select()
            Tab2.Focus()

        End If
    End Sub

    Private Sub tNUM_EJES_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_EJES.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab3.SelectedIndex = 1
        End If
    End Sub

    Private Sub cboTipoLlanta_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoLlanta.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab3.SelectedIndex = 2
        End If
    End Sub

    Private Sub tCVE_OBSER_MOT_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OBSER_MOT.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab4.SelectedIndex = 0
        End If
    End Sub

    Private Sub tREN_VAC_MI_KeyDown(sender As Object, e As KeyEventArgs) Handles tREN_VAC_MI.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab4.SelectedIndex = 1
        End If
    End Sub

    Private Sub tTARJ_COMB3_KeyDown(sender As Object, e As KeyEventArgs) Handles tTARJ_COMB3.KeyDown
        Tab5.SelectedIndex = 0
    End Sub

    Private Sub cboPropietario_KeyDown(sender As Object, e As KeyEventArgs) Handles cboPropietario.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab6.SelectedIndex = 0
        End If
    End Sub

    Private Sub chSE_SIN_COBERTURA_KeyDown(sender As Object, e As KeyEventArgs) Handles chSE_SIN_COBERTURA.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab7.SelectedIndex = 0
        End If
    End Sub

    Private Sub tT_P_MOTOR_RELENTI_KeyDown(sender As Object, e As KeyEventArgs) Handles tT_P_MOTOR_RELENTI.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab8.SelectedIndex = 0
        End If
    End Sub

    Private Sub tIDENT_CON_KeyDown(sender As Object, e As KeyEventArgs) Handles tIDENT_CON.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab1.SelectedIndex = 2
        End If
    End Sub

    Private Sub chSE_LIMITADA_KeyDown(sender As Object, e As KeyEventArgs) Handles chSE_LIMITADA.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab7.SelectedIndex = 0
        End If
    End Sub

    Private Sub chSE_AMPLIA_KeyDown(sender As Object, e As KeyEventArgs) Handles chSE_AMPLIA.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            Tab7.SelectedIndex = 0
        End If
    End Sub
    Private Sub btnFotoDoc_Click(sender As Object, e As EventArgs)
        Try
            Dim rutaDoc As String = Application.StartupPath & "\Documentos"

            If Not Directory.Exists(rutaDoc) Then
                Directory.CreateDirectory(rutaDoc)
            End If

            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.InitialDirectory = rutaDoc
            OpenFileDialog1.Filter = "Todos los archivos|*.*"

            If LtFotoDoc.Text.Trim.Length = 0 Then
                OpenFileDialog1.FileName = ""
            Else
                OpenFileDialog1.FileName = LtFotoDoc.Text
            End If
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim copyToDir = Path.GetDirectoryName(OpenFileDialog1.FileName)
                Dim file = Path.GetFileName(OpenFileDialog1.FileName)
                If rutaDoc = copyToDir Then
                    '
                Else
                    Dim newPath = Path.Combine(copyToDir, file)
                    System.IO.File.Copy(OpenFileDialog1.FileName, rutaDoc & "\" & file)
                End If
                LtFotoDoc.Text = file
                LtFotoDoc.Tag = copyToDir
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocA_Click(sender As Object, e As EventArgs)
        Try
            If tDescrFotDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture descripción del documento")
                tDescrFotDoc.Focus()
                Return
            End If
            If LtFotoDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            FgFotDoc.AddItem("" & vbTab & tDescrFotDoc.Text & vbTab & LtFotoDoc.Text & vbTab & "0" & vbTab & LtFotoDoc.Tag.ToString)

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocE_Click(sender As Object, e As EventArgs)
        Try
            If FgFotDoc.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    FgFotDoc.RemoveItem(FgFotDoc.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub frmUnidadesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Movimientos Unidades")
            Me.Dispose()

            If OPEN_TAB("Unidades") Then
                frmUnidades.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCveArt_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tEJES.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tCVE_TANQUE1.Focus()
        End If

    End Sub

    Private Sub tCVE_ART_Validated(sender As Object, e As EventArgs) Handles tCVE_ART.Validated
        Try
            If tCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Inven", tCVE_ART.Text)
                If DESCR <> "" Then
                    L6.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                    tCVE_ART.Text = ""
                    tCVE_ART.Select()
                End If
            End If

        Catch ex As Exception
            MsgBox("103. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("103. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tUni_KeyDown(sender As Object, e As KeyEventArgs) Handles tUni.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTipoUni_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tUni_Validated(sender As Object, e As EventArgs) Handles tUni.Validated
        Try
            If tUni.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad", tUni.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                    LtTractor.Text = DESCR
                    If tUni.Text = "1" Then
                    Else
                        tNIVEL.Visible = False
                        btnNivel.Visible = False
                        Lt.Visible = False
                        tNIVEL2.Visible = False
                        Lv2.Visible = False
                        btnNivel2.Visible = False
                        tNIVEL3.Visible = False
                        Lv3.Visible = False
                        btnNivel3.Visible = False
                    End If
                    tNIVEL.Focus()
                Else
                    MsgBox("Tipo unidad inexistente")
                    tUni.Text = ""
                    tUni.Select()
                End If
            End If

        Catch ex As Exception
            MsgBox("113. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("113. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tSuc_KeyDown(sender As Object, e As KeyEventArgs) Handles tSuc.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnSuc_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tSuc_Validated(sender As Object, e As EventArgs) Handles tSuc.Validated
        Try
            If tSuc.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Sucursal", tSuc.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                Else
                    MsgBox("Sucursal inexistente")
                    tSuc.Text = ""
                    tSuc.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_OPER_Validated(sender As Object, e As EventArgs) Handles tCVE_OPER.Validated
        Try
            If tCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                    tCVE_OPER.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("126. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("126. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_MARCA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_MARCA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnMarca_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_MARCA_Validated(sender As Object, e As EventArgs) Handles tCVE_MARCA.Validated
        Try
            If tCVE_MARCA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Marca unidad", tCVE_MARCA.Text)
                If DESCR <> "" Then
                    L4.Text = DESCR
                Else
                    MsgBox("Marca inexistente")
                    tCVE_MARCA.Text = ""
                    tCVE_MARCA.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("127. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("127. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_MODELO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_MODELO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnModelo_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_MODELO_Validated(sender As Object, e As EventArgs) Handles tCVE_MODELO.Validated
        Try
            If tCVE_MODELO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Modelo", tCVE_MODELO.Text)
                If DESCR <> "" Then
                    L5.Text = DESCR
                Else
                    MsgBox("Modelo inexistente")
                    tCVE_MODELO.Text = ""
                    tCVE_MODELO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tPLACAS_DEF_KeyDown(sender As Object, e As KeyEventArgs) Handles tPLACAS_DEF.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlacasDefa_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tPLACAS_DEF_Validated(sender As Object, e As EventArgs) Handles tPLACAS_DEF.Validated
        Try
            If tPLACAS_DEF.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Placas defa", tPLACAS_DEF.Text)
                If DESCR <> "" Then
                    L11.Text = DESCR
                Else
                    MsgBox("Placa inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque1_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tCVE_ART.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tCVE_TANQUE2.Focus()
        End If

    End Sub

    Private Sub tCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles tCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If tCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA(Var4) Then
                        MsgBox("La unidad ya fue asignada " & Var3)
                        tCVE_TANQUE1.Text = ""
                        tCVE_TANQUE1.Select()
                        Return
                    End If
                    Var3 = ""
                    tCVE_TANQUE1.Tag = Var4
                    LtTanque1.Text = DESCR
                    L7.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TANQUE1.Text = ""
                    tCVE_TANQUE1.Tag = ""
                    LtTanque1.Text = ""
                    L7.Text = ""
                    tCVE_TANQUE1.Select()
                End If
            Else
                tCVE_TANQUE1.Tag = ""
                LtTanque1.Text = ""
                L7.Text = ""
            End If

        Catch ex As Exception
            Bitacora("145. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("145. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque2_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tCVE_TANQUE1.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tCVE_DOLLY.Focus()
        End If
    End Sub

    Private Sub tCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles tCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If tCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA(Var4) Then
                        MsgBox("La unidad ya fue asignada " & Var3)
                        tCVE_TANQUE2.Text = ""
                        tCVE_TANQUE2.Select()
                        Return
                    End If
                    Var3 = ""
                    tCVE_TANQUE2.Tag = Var4
                    L8.Text = DESCR
                Else
                    MsgBox("Unidad inexistente.")
                    tCVE_TANQUE2.Text = ""
                    tCVE_TANQUE2.Tag = ""
                    LtTanque2.Text = ""
                    L8.Text = ""
                    tCVE_TANQUE2.Select()
                End If
            Else
                tCVE_TANQUE2.Tag = ""
                LtTanque2.Text = ""
                L8.Text = ""
            End If

        Catch ex As Exception
            Bitacora("155. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("155. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_DOLLY_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_DOLLY.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnDolly_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tCVE_TANQUE2.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tCVE_GRUPO.Focus()
        End If

    End Sub

    Private Sub tCVE_DOLLY_Validated(sender As Object, e As EventArgs) Handles tCVE_DOLLY.Validated
        Try

            If tCVE_DOLLY.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_DOLLY.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA(Var4) Then
                        MsgBox("La unidad ya fue asignada " & Var3)
                        tCVE_DOLLY.Text = ""
                        tCVE_DOLLY.Select()
                        Return
                    End If
                    Var3 = ""

                    LtDolly.Text = DESCR
                    LtDolly.Tag = Var4
                    L9.Text = DESCR
                Else
                    MsgBox("Unidad inexistente..")
                    tCVE_DOLLY.Text = ""
                    tCVE_DOLLY.Tag = ""
                    LtDolly.Text = ""
                    L9.Text = ""
                    tCVE_DOLLY.Select()
                End If
            Else
                tCVE_DOLLY.Tag = ""
                LtDolly.Text = ""
                L9.Text = ""
            End If

        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("155. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_GRUPO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GRUPO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnGruUni_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tCVE_DOLLY.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tIDENT_SAT.Focus()
        End If

    End Sub

    Private Sub tCVE_GRUPO_Validated(sender As Object, e As EventArgs) Handles tCVE_GRUPO.Validated
        Try
            If tCVE_GRUPO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Grupo unidad", tCVE_GRUPO.Text)
                If DESCR <> "" Then
                    L10.Text = DESCR
                Else
                    MsgBox("Grupo inexistente")
                    tCVE_GRUPO.Text = ""
                    tCVE_GRUPO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("166. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("166. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        Try
            tLL1.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 1) Then
                    Return
                End If
                tLL1.Text = Var4
                LL1.Text = Var5
                BtnTT1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL2.Focus()
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tLL1_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL1.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tLL1_Validated(sender As Object, e As EventArgs) Handles tLL1.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL1.Text, 1) Then
                tLL1.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL1.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                SQL = "UPDATE GCUNIDADES SET CHLL1 = '' WHERE CLAVEMONTE = '" & Var6
                tLL1.Text = ""
                Return
            End If
            If tLL1.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL1.Text)
                If DESCR <> "" Then
                    IMAGEN_LLANTA(DESCR, 1)
                    LL1.Text = DESCR
                Else
                    MsgBox("Llanta inexistente")
                    LL1.Text = ""
                    tLL1.Text = ""
                    tLL1.Tag = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        Try
            tLL2.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 2) Then
                    Return
                End If
                tLL2.Text = Var4
                LL2.Text = Var5
                BtnTT2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL3.Focus()
            End If
        Catch ex As Exception
            Bitacora("195. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("195. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL2_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL2_Validated(sender As Object, e As EventArgs) Handles tLL2.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL2.Text, 2) Then
                tLL2.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL2.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL2.Text = ""
                Return
            End If
            If tLL2.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL2.Text)
                If DESCR <> "" Then
                    LL2.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 2)
                Else
                    MsgBox("Llanta inexistente")
                    tLL2.Text = ""
                    LL2.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("205. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("205. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        Try

            tLL3.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 3) Then
                    Return
                End If
                tLL3.Text = Var4
                LL3.Text = Var5
                BtnTT3.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL4.Focus()
            End If
        Catch ex As Exception
            Bitacora("206. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("206. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL3_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL3.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn3_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL3_Validated(sender As Object, e As EventArgs) Handles tLL3.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL3.Text, 3) Then
                tLL3.Text = ""
                Return
            End If

            Var6 = ""

            If LLANTA_ASIGNADA(tLL3.Text) Then

                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL3.Text = ""
                Return
            End If

            If tLL3.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL3.Text)
                If DESCR <> "" Then
                    LL3.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 3)
                Else
                    MsgBox("Llanta inexistente")
                    tLL3.Text = ""
                    LL3.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("225. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("225. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Try
            tLL4.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 4) Then
                    Return
                End If
                tLL4.Text = Var4
                LL4.Text = Var5
                BtnTT4.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL5.Focus()
            End If
        Catch ex As Exception
            Bitacora("235. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL4_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL4.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn4_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL4_Validated(sender As Object, e As EventArgs) Handles tLL4.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL4.Text, 4) Then
                tLL4.Text = ""
                Return
            End If
            Var6 = ""
            If LLANTA_ASIGNADA(tLL4.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL4.Text = ""
                Return
            End If
            If tLL4.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL4.Text)
                If DESCR <> "" Then
                    LL4.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 4)
                Else
                    MsgBox("Llanta inexistente")
                    tLL4.Text = ""
                    LL4.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("245. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("245. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        Try
            tLL5.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 5) Then
                    Return
                End If
                tLL5.Text = Var4
                LL5.Text = Var5
                BtnTT5.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL6.Focus()
            End If
        Catch ex As Exception
            Bitacora("255. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("255. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL5_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL5.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn5_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL5_Validated(sender As Object, e As EventArgs) Handles tLL5.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL5.Text, 5) Then
                tLL5.Text = ""
                Return
            End If
            Var6 = ""
            If LLANTA_ASIGNADA(tLL5.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL5.Text = ""
                Return
            End If

            If tLL5.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL5.Text)
                If DESCR <> "" Then
                    LL5.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 5)
                Else
                    MsgBox("Llanta inexistente")
                    tLL5.Text = ""
                    LL5.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("265. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("265. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        Try
            tLL6.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 6) Then
                    Return
                End If
                tLL6.Text = Var4
                LL6.Text = Var5
                BtnTT6.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL7.Focus()
            End If
        Catch ex As Exception
            Bitacora("275. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("275. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL6_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL6.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn6_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL6_Validated(sender As Object, e As EventArgs) Handles tLL6.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL6.Text, 6) Then
                tLL6.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL6.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL6.Text = ""
                Return
            End If

            If tLL6.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL6.Text)
                If DESCR <> "" Then
                    LL6.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 6)
                Else
                    MsgBox("Llanta inexistente")
                    tLL6.Text = ""
                    LL6.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("285. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("285. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        Try
            tLL7.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 7) Then
                    Return
                End If
                tLL7.Text = Var4
                LL7.Text = Var5
                BtnTT7.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL8.Focus()
            End If
        Catch ex As Exception
            Bitacora("295. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("295. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL7_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL7.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn7_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL7_Validated(sender As Object, e As EventArgs) Handles tLL7.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL7.Text, 7) Then
                tLL7.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL7.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL7.Text = ""
                Return
            End If

            If tLL7.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL7.Text)
                If DESCR <> "" Then
                    LL7.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 7)
                Else
                    MsgBox("Llanta inexistente")
                    tLL7.Text = ""
                    LL7.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        Try
            tLL8.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 8) Then
                    Return
                End If
                tLL8.Text = Var4
                LL8.Text = Var5
                BtnTT8.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL9.Focus()
            End If
        Catch ex As Exception
            Bitacora("326. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("326. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL8_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL8.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn8_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL8_Validated(sender As Object, e As EventArgs) Handles tLL8.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL8.Text, 8) Then
                tLL8.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL8.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL8.Text = ""
                Return
            End If

            If tLL8.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL8.Text)
                If DESCR <> "" Then
                    LL8.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 8)
                Else
                    MsgBox("Llanta inexistente")
                    tLL8.Text = ""
                    LL8.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("328. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("328. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        Try
            tLL9.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 9) Then
                    Return
                End If
                tLL9.Text = Var4
                LL9.Text = Var5
                BtnTT9.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL10.Focus()
            End If
        Catch ex As Exception
            Bitacora("335. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("335. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL9_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL9.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn9_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL9_Validated(sender As Object, e As EventArgs) Handles tLL9.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL9.Text, 9) Then
                tLL9.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL9.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL9.Text = ""
                Return
            End If

            If tLL9.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL9.Text)
                If DESCR <> "" Then
                    LL9.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 9)
                Else
                    MsgBox("Llanta inexistente")
                    tLL9.Text = ""
                    LL9.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("345. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("345. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn10_Click(sender As Object, e As EventArgs) Handles Btn10.Click
        Try
            tLL10.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 10) Then
                    Return
                End If
                tLL10.Text = Var4
                LL10.Text = Var5
                BtnTT10.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL11.Focus()
            End If
        Catch ex As Exception
            Bitacora("355. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("355. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL10_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL10.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn10_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL10_Validated(sender As Object, e As EventArgs) Handles tLL10.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(tLL10.Text, 10) Then
                tLL10.Text = ""
                Return
            End If

            Var6 = ""
            If LLANTA_ASIGNADA(tLL10.Text) Then
                MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                tLL10.Text = ""
                Return
            End If

            If tLL10.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Llantas", tLL10.Text)
                If DESCR <> "" Then
                    LL10.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 10)
                Else
                    MsgBox("Llanta inexistente")
                    tLL10.Text = ""
                    LL10.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("365. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("365. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function LLantaAsignada(fCVE_LLANTA As String, fLlanta As Integer) As Boolean
        Try
            Dim Regresa As Boolean
            Regresa = False

            If fCVE_LLANTA.Trim.Length = 0 Then
                Return False
            End If
            Select Case fLlanta
                Case 1
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or tLL6.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 2
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or tLL6.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 3
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or tLL6.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 4
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or tLL6.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 5
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL6.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 6
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 7
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 8
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL7.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 9
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 10
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 11
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Or
                        tLL12.Text = fCVE_LLANTA Then
                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
                Case 12
                    If fCVE_LLANTA.Trim.Length > 0 Then
                        If tLL1.Text = fCVE_LLANTA Or tLL2.Text = fCVE_LLANTA Or tLL3.Text = fCVE_LLANTA Or tLL4.Text = fCVE_LLANTA Or tLL5.Text = fCVE_LLANTA Or
                        tLL6.Text = fCVE_LLANTA Or tLL7.Text = fCVE_LLANTA Or tLL8.Text = fCVE_LLANTA Or tLL9.Text = fCVE_LLANTA Or tLL10.Text = fCVE_LLANTA Or
                        tLL11.Text = fCVE_LLANTA Then

                            MsgBox("La llanta " & fCVE_LLANTA & " ya se encuentra asignada")
                            Regresa = True
                        End If
                    End If
            End Select
            Return Regresa
        Catch ex As Exception
            Bitacora("375. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("375. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Sub IMAGEN_LLANTA(fDESCR As String, fNUM As Integer)
        Dim NUM As Integer
        Select Case fNUM
            Case 1  'IMAGEN 1
                If fDESCR.Trim.Length >= 4 Then
                    tLL1.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT1.ImageIndex = 1
                                Else
                                    BtnT1.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD1.ImageIndex = 1
                                BtnD1.ForeColor = Color.Yellow
                            Case "M"
                                BtnM1.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If tLL1.Tag.ToString.Length >= 4 Then
                            Select Case tLL1.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT1.ImageIndex = 0
                                    Else
                                        BtnT1.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD1.ImageIndex = 0
                                    BtnD1.ForeColor = Color.Black
                                Case "M"
                                    BtnM1.ImageIndex = 0
                                Case Else
                            End Select
                        End If

                    Catch ex As Exception
                    End Try
                    tLL1.Tag = ""
                End If
            Case 2
                If fDESCR.Trim.Length >= 4 Then
                    tLL2.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT2.ImageIndex = 1
                                Else
                                    BtnT2.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD2.ImageIndex = 1
                                BtnD2.ForeColor = Color.Yellow
                            Case "M"
                                BtnM2.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL2.Tag) Then
                            If tLL2.Tag.ToString.Length >= 4 Then
                                Select Case tLL2.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT2.ImageIndex = 0
                                        Else
                                            BtnT2.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD2.ImageIndex = 0
                                        BtnD2.ForeColor = Color.Black
                                    Case "M"
                                        BtnM2.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    tLL2.Tag = ""
                End If
            Case 3
                If fDESCR.Trim.Length >= 4 Then
                    tLL3.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT3.ImageIndex = 1
                                Else
                                    BtnT3.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD3.ImageIndex = 1
                                BtnD3.ForeColor = Color.Yellow
                            Case "M"
                                BtnM3.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL3.Tag) Then
                            If tLL3.Tag.ToString.Length >= 4 Then
                                Select Case tLL3.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT3.ImageIndex = 0
                                        Else
                                            BtnT3.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD3.ImageIndex = 0
                                        BtnD3.ForeColor = Color.Black
                                    Case "M"
                                        BtnM3.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL3.Tag = ""
                End If
            Case 4
                If fDESCR.Trim.Length >= 4 Then
                    tLL4.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT2.ImageIndex = 1
                                Else
                                    BtnT2.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD4.ImageIndex = 1
                                BtnD4.ForeColor = Color.Yellow
                            Case "M"
                                BtnM4.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL4.Tag) Then
                            If tLL4.Tag.ToString.Length >= 4 Then
                                Select Case tLL4.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT4.ImageIndex = 0
                                        Else
                                            BtnT4.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD4.ImageIndex = 0
                                        BtnD4.ForeColor = Color.Black
                                    Case "M"
                                        BtnM4.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL4.Tag = ""
                End If
            Case 5
                If fDESCR.Trim.Length >= 4 Then
                    tLL5.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT5.ImageIndex = 1
                                Else
                                    BtnT5.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD5.ImageIndex = 1
                                BtnD5.ForeColor = Color.Yellow
                            Case "M"
                                BtnM5.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL5.Tag) Then
                            If tLL5.Tag.ToString.Length >= 4 Then
                                Select Case tLL5.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT5.ImageIndex = 0
                                        Else
                                            BtnT5.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD5.ImageIndex = 0
                                        BtnD5.ForeColor = Color.Black
                                    Case "M"
                                        BtnM5.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL5.Tag = ""
                End If
            Case 6
                If fDESCR.Trim.Length >= 4 Then
                    tLL6.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT6.ImageIndex = 1
                                Else
                                    BtnT6.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD6.ImageIndex = 1
                                BtnD6.ForeColor = Color.Yellow
                            Case "M"
                                BtnM6.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL6.Tag) Then
                            If tLL6.Tag.ToString.Length >= 4 Then
                                Select Case tLL6.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT6.ImageIndex = 0
                                        Else
                                            BtnT6.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD6.ImageIndex = 0
                                        BtnD6.ForeColor = Color.Black
                                    Case "M"
                                        BtnM6.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL6.Tag = ""
                End If
            Case 7
                If fDESCR.Trim.Length >= 4 Then
                    tLL7.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT7.ImageIndex = 1
                                Else
                                    BtnT7.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD7.ImageIndex = 1
                                BtnD7.ForeColor = Color.Yellow
                            Case "M"
                                BtnM7.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL7.Tag) Then
                            If tLL7.Tag.ToString.Length >= 4 Then
                                Select Case tLL7.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT2.ImageIndex = 0
                                        Else
                                            BtnT2.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD7.ImageIndex = 0
                                        BtnD7.ForeColor = Color.Black
                                    Case "M"
                                        BtnM7.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL7.Tag = ""
                End If
            Case 8
                If fDESCR.Trim.Length >= 4 Then
                    tLL8.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT8.ImageIndex = 1
                                Else
                                    BtnT8.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD8.ImageIndex = 1
                                BtnD8.ForeColor = Color.Yellow
                            Case "M"
                                BtnM8.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL8.Tag) Then
                            If tLL8.Tag.ToString.Length >= 4 Then
                                Select Case tLL8.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT8.ImageIndex = 0
                                        Else
                                            BtnT8.ImageIndex = 0
                                        End If
                                    Case "D"
                                        BtnD8.ImageIndex = 0
                                        BtnD8.ForeColor = Color.Black
                                    Case "M"
                                        BtnM8.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL8.Tag = ""
                End If
            Case 9
                If fDESCR.Trim.Length >= 4 Then
                    tLL9.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT9.ImageIndex = 1
                                Else
                                    BtnT9.ImageIndex = 1
                                End If
                            Case "D"

                            Case "M"
                                BtnM9.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL9.Tag) Then
                            If tLL9.Tag.ToString.Length >= 4 Then
                                Select Case tLL9.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT9.ImageIndex = 0
                                        Else
                                            BtnT9.ImageIndex = 0
                                        End If
                                    Case "D"
                                    Case "M"
                                        BtnM9.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL9.Tag = ""
                End If
            Case 10
                If fDESCR.Trim.Length >= 4 Then
                    tLL10.Tag = fDESCR
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT10.ImageIndex = 1
                                Else
                                    BtnT10.ImageIndex = 1
                                End If
                            Case "D"
                                'BtnD2.ImageIndex = 1
                                'BtnD2.ForeColor = Color.Yellow
                            Case "M"
                                BtnM10.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If Not IsNothing(tLL10.Tag) Then
                            If tLL10.Tag.ToString.Length >= 4 Then
                                Select Case tLL10.Tag.Substring(0, 1)
                                    Case "T"
                                        NUM = fDESCR.Substring(2, 3)
                                        If NUM <= 120 Then
                                            BtnTT10.ImageIndex = 0
                                        Else
                                            BtnT10.ImageIndex = 0
                                        End If
                                    Case "D"
                                    'BtnD2.ImageIndex = 0
                                    'BtnD2.ForeColor = Color.Black
                                    Case "M"
                                        BtnM10.ImageIndex = 0
                                    Case Else
                                End Select
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    tLL10.Tag = ""
                End If
        End Select
    End Sub

    Private Sub Btn11_Click(sender As Object, e As EventArgs) Handles Btn11.Click
        Try
            tLL11.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 11) Then
                    Return
                End If
                tLL11.Text = Var4
                LL11.Text = Var5
                BtnTT11.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLL12.Focus()
            End If
        Catch ex As Exception
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn12_Click(sender As Object, e As EventArgs) Handles Btn12.Click
        Try
            tLL12.Select()
            Var2 = "LlantasNoAsignadas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var4, 12) Then
                    Return
                End If
                tLL12.Text = Var4
                LL12.Text = Var5
                BtnTT12.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                'tLL2.Focus()
            End If
        Catch ex As Exception
            Bitacora("435. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("435. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL11_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL11.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn11_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL12_KeyDown(sender As Object, e As KeyEventArgs) Handles tLL12.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn12_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tLL11_Validated(sender As Object, e As EventArgs) Handles tLL11.Validated
        Try
            Dim DESCR As String

            If tLL11.Text.Trim.Length > 0 Then
                If LLantaAsignada(tLL11.Text, 11) Then
                    tLL11.Text = ""
                    Return
                End If

                Var6 = ""
                If LLANTA_ASIGNADA(tLL11.Text) Then
                    MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                    tLL11.Text = ""
                    Return
                End If
                DESCR = BUSCA_CAT("Llantas", tLL11.Text)
                If DESCR <> "" Then
                    LL11.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 11)
                Else
                    MsgBox("Llanta inexistente")
                    tLL11.Text = ""
                    LL11.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("445. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("445. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tLL12_Validated(sender As Object, e As EventArgs) Handles tLL12.Validated
        Try

            If tLL12.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If LLantaAsignada(tLL12.Text, 12) Then
                    tLL12.Text = ""
                    Return
                End If

                Var6 = ""
                If LLANTA_ASIGNADA(tLL12.Text) Then
                    MsgBox("La llanta ya fue asignada en la unidad " & Var6)
                    tLL12.Text = ""
                    Return
                End If
                DESCR = BUSCA_CAT("Llantas", tLL12.Text)
                If DESCR <> "" Then
                    LL12.Text = DESCR
                    IMAGEN_LLANTA(DESCR, 12)
                Else
                    MsgBox("Llanta inexistente")
                    tLL12.Text = ""
                    LL12.Text = ""
                End If
            End If

        Catch ex As Exception
            Bitacora("455. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("455. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnIave_Click(sender As Object, e As EventArgs) Handles btnIave.Click
        Try
            Var2 = "IAVE"
            Var4 = ""
            Var5 = ""
            Var6 = ""
            frmSelItem.ShowDialog()
            tOD_TARJ_IAVE.Text = Var4
            LtIave.Text = Var5
            LtVigencia.Text = Var6
            Var2 = ""
            Var4 = ""
            Var5 = ""

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tOD_TARJ_IAVE_Validated(sender As Object, e As EventArgs) Handles tOD_TARJ_IAVE.Validated

        Try
            Dim DESCR As String

            If tOD_TARJ_IAVE.Text.Trim.Length > 0 Then
                If VERIFICA_TARJ_IAVE_NO_ASIGNADA(tCLAVE.Text, tOD_TARJ_IAVE.Text) Then
                    MsgBox("La tarjeta IAVE ya fue asignada a la unidad " & Var11)
                    tOD_TARJ_IAVE.Text = ""
                    Return
                End If
                DESCR = BUSCA_CAT("IAVE", tOD_TARJ_IAVE.Text)
                If DESCR <> "" Then
                    LtIave.Text = DESCR
                Else
                    MsgBox("Tarjeta IAVE inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("465. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("465. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tOD_TARJ_IAVE_KeyDown(sender As Object, e As KeyEventArgs) Handles tOD_TARJ_IAVE.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnIave_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Function LLANTA_ASIGNADA(fLLANTA As String) As Boolean
        Dim ExistLlanta As Boolean

        ExistLlanta = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If fLLANTA.Trim.Length = 0 Then
                Return False
            End If

            Var6 = ""

            SQL = "SELECT CLAVE, CLAVEMONTE FROM GCUNIDADES WHERE CLAVE <> '" & tCLAVE.Text & "' AND (" &
                "CHLL1 = '" & fLLANTA & "' OR CHLL2 = '" & fLLANTA & "' OR CHLL3 = '" & fLLANTA & "' OR CHLL4 = '" & fLLANTA & "' OR " &
                "CHLL5 = '" & fLLANTA & "' OR CHLL6 = '" & fLLANTA & "' OR CHLL7 = '" & fLLANTA & "' OR CHLL8 = '" & fLLANTA & "' OR " &
                "CHLL9 = '" & fLLANTA & "' OR CHLL10 = '" & fLLANTA & "' OR CHLL11 = '" & fLLANTA & "' OR CHLL12 = '" & fLLANTA & "')"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ExistLlanta = True
                Var6 = dr("CLAVEMONTE")
            End If
            dr.Close()
            Return ExistLlanta
        Catch ex As Exception
            Bitacora("475. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("475. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Private Function GET_FILTRO_UNIDAD(fCLAVE_MONTE As String, fNUM As Integer) As String

        Try
            Dim Result As String
            Result = ""
            If fCLAVE_MONTE.Length > 0 Then
                Select Case fCLAVE_MONTE.Substring(0, 2)
                    Case "T-"
                        Select Case fNUM
                            Case 1
                                Result = "M-"
                            Case 2
                                Result = "T-"
                        End Select
                    Case "M-", "D-"
                        Select Case fNUM
                            Case 1
                                Result = "T-"
                            Case 2
                                Result = "T-"
                        End Select
                End Select
            End If
            Return Result
        Catch ex As Exception
            Bitacora("485. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("485. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try

    End Function
    Private Sub btnNivel_Click(sender As Object, e As EventArgs) Handles btnNivel.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'VAR4 = Fg(0, 1) = "Clave"
                'VAR5 = Fg(0, 2) = "ID"
                'VAR6 = Fg(0, 3) = "Litros"
                'VAR7 = Fg(0, 4) = "Altura"
                tNIVEL.Text = Var5
                tNIVEL.Tag = Var4
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tNIVEL2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tNIVEL_KeyDown(sender As Object, e As KeyEventArgs) Handles tNIVEL.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNivel_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tNIVEL_Validated(sender As Object, e As EventArgs) Handles tNIVEL.Validated
        Try
            If tNIVEL.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tNIVEL.Text)
                If DESCR <> "N" Then
                    tNIVEL.Tag = Var4
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tNIVEL.Text = ""
                    tNIVEL.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNivel2_Click(sender As Object, e As EventArgs) Handles btnNivel2.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNIVEL2.Tag = Var4
                tNIVEL2.Text = Var5
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tNIVEL3.Focus()
            End If

        Catch Ex As Exception
            Bitacora("535. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("535. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNivel3_Click(sender As Object, e As EventArgs) Handles btnNivel3.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNIVEL3.Tag = Var4
                tNIVEL3.Text = Var5
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tSuc.Focus()
            End If

        Catch Ex As Exception
            Bitacora("545. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("545. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_ART_GotFocus(sender As Object, e As EventArgs) Handles tCVE_ART.GotFocus
        tCVE_ART.SelectAll()
    End Sub
    Private Sub tCVE_TANQUE1_GotFocus(sender As Object, e As EventArgs) Handles tCVE_TANQUE1.GotFocus
        tCVE_TANQUE1.SelectAll()
    End Sub
    Private Sub tCVE_TANQUE2_GotFocus(sender As Object, e As EventArgs) Handles tCVE_TANQUE2.GotFocus
        tCVE_TANQUE2.SelectAll()
    End Sub

    Private Sub tClaveMonte_Validated(sender As Object, e As EventArgs) Handles tClaveMonte.Validated
        Try
            Dim DESCR As String
            Dim CLAVE As Long
            Dim CLAVEMONTE As String
            Dim CVE_TANQUE1 As Long
            Dim CVE_TANQUE2 As Long
            Dim CVE_DOLLY As Long

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If tClaveMonte.Text.Trim.Length = 0 Then
                Return
            End If


            If EXISTE_CAMPO_UNIDADES("NO ECONOMICO", tCLAVE.Text, tClaveMonte.Text) Then
                MsgBox("El NO ECONOMICO ya fue asignado a la unidad " & Var13)
                tClaveMonte.Text = ""
                tClaveMonte.Select()
                Return
            End If

            CLAVE = 0
            CVE_DOLLY = 0
            SQL = "SELECT CLAVE FROM GCUNIDADES WHERE CLAVEMONTE = '" & tClaveMonte.Text & "' AND ISNULL(STATUS, 'A') = 'A'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                CLAVE = dr("CLAVE")
            End If
            dr.Close()

            If CLAVE > 0 Then
                SQL = "SELECT CLAVEMONTE, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY " &
                    "FROM GCUNIDADES " &
                    "WHERE ISNULL(STATUS, 'A') = 'A' AND (CVE_TANQUE1 = " & CLAVE & " OR CVE_TANQUE2 = " & CLAVE & ")"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    CVE_TANQUE1 = dr("CVE_TANQUE1")
                    CVE_TANQUE2 = dr("CVE_TANQUE2")
                    CVE_DOLLY = dr("CVE_DOLLY")
                    CLAVEMONTE = dr("CLAVEMONTE")

                    If CLAVE = CVE_TANQUE1 Then
                        DESCR = BUSCA_CAT("Unidad", CLAVEMONTE)
                        L7.Text = DESCR
                        tCVE_TANQUE1.Text = CLAVEMONTE
                        tCVE_TANQUE1.Tag = Var4

                        DESCR = BUSCA_CAT("Unidades", CVE_TANQUE2)
                        L8.Text = DESCR
                        tCVE_TANQUE2.Text = Var4
                        tCVE_TANQUE2.Tag = CVE_TANQUE2

                        DESCR = BUSCA_CAT("Unidades", dr("CVE_DOLLY"))
                        L9.Text = DESCR
                        tCVE_DOLLY.Text = Var4
                        tCVE_DOLLY.Tag = dr("CVE_DOLLY")

                    Else
                        DESCR = BUSCA_CAT("Unidad", CLAVEMONTE)
                        L7.Text = DESCR
                        tCVE_TANQUE2.Text = CLAVEMONTE
                        tCVE_TANQUE2.Tag = Var4

                        DESCR = BUSCA_CAT("Unidades", CVE_TANQUE1)
                        L8.Text = DESCR
                        tCVE_TANQUE1.Text = Var4
                        tCVE_TANQUE1.Tag = CVE_TANQUE1

                        DESCR = BUSCA_CAT("Unidades", dr("CVE_DOLLY"))
                        L9.Text = DESCR
                        tCVE_DOLLY.Text = Var4
                        tCVE_DOLLY.Tag = dr("CVE_DOLLY")

                    End If
                End If
                dr.Close()
            End If
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tNIVEL2_Validated(sender As Object, e As EventArgs) Handles tNIVEL2.Validated
        Try
            If tNIVEL2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tNIVEL2.Text)
                If DESCR <> "N" Then
                    tNIVEL2.Tag = Var4
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tNIVEL2.Text = ""
                    tNIVEL2.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tNIVEL3_Validated(sender As Object, e As EventArgs) Handles tNIVEL3.Validated
        Try
            If tNIVEL3.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tNIVEL3.Text)
                If DESCR <> "N" Then
                    tNIVEL3.Tag = Var4
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tNIVEL3.Text = ""
                    tNIVEL3.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TANQUE1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_TANQUE1.PreviewKeyDown

        Try
            If tCVE_TANQUE1.Text.Trim.Length = 0 Then
                tCVE_TANQUE1.Tag = ""
                LtTanque1.Text = ""
                L7.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tCVE_TANQUE2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_TANQUE2.PreviewKeyDown
        Try
            If tCVE_TANQUE2.Text.Trim.Length = 0 Then
                tCVE_TANQUE2.Tag = ""
                LtTanque2.Text = ""
                L8.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tCVE_DOLLY_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_DOLLY.PreviewKeyDown
        Try
            If tCVE_DOLLY.Text.Trim.Length = 0 Then

                tCVE_DOLLY.Tag = ""
                LtDolly.Text = ""
                L9.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function EXISTE_CAMPO_UNIDADES(fTIPO As String, fCLAVE As String, fVERIFI As String) As Boolean
        'PLACA 
        'NO ECONOMICO
        'SERIE
        Dim SiExist As Boolean = False
        Var13 = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                Select Case fTIPO
                    Case "PLACA"
                        SQL = "SELECT CLAVE FROM GCUNIDADES WHERE CLAVE <> '" & fCLAVE & "' AND UPPER(PLACAS_MEX) = '" & fVERIFI & "' AND ISNULL(STATUS, 'A') = 'A'"
                    Case "NO ECONOMICO"
                        SQL = "SELECT CLAVE FROM GCUNIDADES WHERE CLAVE <> '" & fCLAVE & "' AND UPPER(CLAVEMONTE) = '" & fVERIFI & "' AND ISNULL(STATUS, 'A') = 'A'"
                    Case "SERIE"
                        SQL = "SELECT CLAVE FROM GCUNIDADES WHERE CLAVE <> '" & fCLAVE & "' AND UPPER(NUM_SERIE_UNI) = '" & fVERIFI & "' AND ISNULL(STATUS, 'A') = 'A'"
                    Case Else
                        MsgBox("No existe")
                End Select
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SiExist = True
                        Var13 = dr("CLAVE")
                    End If
                End Using
            End Using
            Return SiExist
        Catch ex As Exception
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Private Sub tNUM_SERIE_UNI_Validated(sender As Object, e As EventArgs) Handles tNUM_SERIE_UNI.Validated
        Try
            If tNUM_SERIE_UNI.Text.Trim.Length > 0 Then
                If EXISTE_CAMPO_UNIDADES("SERIE", tCLAVE.Text, tNUM_SERIE_UNI.Text) Then
                    MsgBox("El numero de serie ya fue asignado a la unidad " & Var13)
                    tNUM_SERIE_UNI.Text = ""
                    tNUM_SERIE_UNI.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tPLACAS_MEX_Validated(sender As Object, e As EventArgs) Handles tPLACAS_MEX.Validated
        Try
            If tPLACAS_MEX.Text.Trim.Length > 0 Then
                If EXISTE_CAMPO_UNIDADES("PLACA", tCLAVE.Text, tPLACAS_MEX.Text) Then
                    MsgBox("La placa ya fue asignado a la unidad " & Var13)
                    tPLACAS_MEX.Text = ""
                    tPLACAS_MEX.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function EXISTE_LLANTA_TEXTBOX(fLLANTA As String, nIndex As Integer) As Boolean
        Dim ExistLlanta As Boolean = False
        Try
            If tLL1.Text = fLLANTA And nIndex <> 1 Then
                Return True
            End If
            If tLL2.Text = fLLANTA And nIndex <> 2 Then
                Return True
            End If
            If tLL3.Text = fLLANTA And nIndex <> 3 Then
                Return True
            End If
            If tLL4.Text = fLLANTA And nIndex <> 4 Then
                Return True
            End If
            If tLL5.Text = fLLANTA And nIndex <> 5 Then
                Return True
            End If
            If tLL6.Text = fLLANTA And nIndex <> 6 Then
                Return True
            End If
            If tLL7.Text = fLLANTA And nIndex <> 7 Then
                Return True
            End If
            If tLL8.Text = fLLANTA And nIndex <> 8 Then
                Return True
            End If
            If tLL9.Text = fLLANTA And nIndex <> 9 Then
                Return True
            End If
            If tLL10.Text = fLLANTA And nIndex <> 10 Then
                Return True
            End If
            If tLL11.Text = fLLANTA And nIndex <> 11 Then
                Return True
            End If
            If tLL12.Text = fLLANTA And nIndex <> 12 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub BtnTanque_Click(sender As Object, e As EventArgs) Handles BtnTanque.Click
        Try
            Var2 = "TAQ"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TAQ.Text = Var4
                LtTAQ.Text = Var7 & " Litros"
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tNUM_SERIE_UNI.Focus()
            End If
        Catch Ex As Exception
            Bitacora("535. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("535. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_TAQ_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TAQ.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_TAQ_Validated(sender As Object, e As EventArgs) Handles tCVE_TAQ.Validated
        Try
            If tCVE_TAQ.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tanques", tCVE_TAQ.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    LtTAQ.Text = DESCR & " Litros"
                    tNUM_SERIE_UNI.Focus()
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TAQ.Text = ""
                    tCVE_TAQ.Select()
                End If
            Else
                LtTAQ.Text = ""
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMotor_Click(sender As Object, e As EventArgs) Handles BtnMotor.Click
        Try
            Var2 = "Motor"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_MOT.Text = Var4
                LtMotor.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tNUM_SERIE_UNI.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_MOT_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_MOT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMotor_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_MOT_Validated(sender As Object, e As EventArgs) Handles tCVE_MOT.Validated
        Try
            If tCVE_MOT.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Motor", tCVE_MOT.Text)
                If DESCR <> "" Then
                    LtMotor.Text = DESCR
                Else
                    MsgBox("Motor inexistente")
                    tCVE_MOT.Text = ""
                    LtMotor.Text = ""
                    tNUM_SERIE_UNI.Select()
                End If
            Else
                LtMotor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAseguradoras_Click(sender As Object, e As EventArgs) Handles BtnAseguradoras.Click
        Try
            Var2 = "Aseguradoras"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tSE_ASEGURADORA.Text = Var4
                LtAseguradora.Text = Var5
                GET_ASEGURADORA(Var4)
                Var2 = "" : Var4 = "" : Var5 = ""
                tSE_NO_SEG.Focus()

            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub GET_ASEGURADORA(FCLAVE As String)
        Try
            If FCLAVE.Trim.Length > 0 Then
                SQL = "SELECT POLIZARESPCIVIL, ASEGURARESPCIVIL
                FROM GCASEGURADORAS I
                WHERE RTRIM(LTRIM(CLAVE)) = '" & FCLAVE.Trim & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTPolizaRespCivil.Text = dr.ReadNullAsEmptyString("POLIZARESPCIVIL")
                            LTAseguraRespCivil.Text = dr.ReadNullAsEmptyString("ASEGURARESPCIVIL")
                        Else
                            LTPolizaRespCivil.Text = ""
                            LTAseguraRespCivil.Text = ""
                        End If
                    End Using
                End Using

            End If
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tSE_ASEGURADORA_Validated(sender As Object, e As EventArgs) Handles tSE_ASEGURADORA.Validated
        Try
            If tSE_ASEGURADORA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Aseguradora", tSE_ASEGURADORA.Text)
                If DESCR <> "" Then
                    LtAseguradora.Text = DESCR
                    GET_ASEGURADORA(tSE_ASEGURADORA.Text)
                Else
                    MsgBox("Aseguradora inexistente")
                    tSE_ASEGURADORA.Text = ""
                    LtAseguradora.Text = ""
                    tSE_NO_SEG.Select()
                End If
            Else
                LtAseguradora.Text = ""
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnSubTipoRem1_Click(sender As Object, e As EventArgs) Handles BtnSubTipoRem1.Click
        Try
            Var2 = "SubTipoRem"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TSubTipoRem1.Text = Var4
                LTSubTipoRem1.Text = Var5
                tOD_TARJ_IAVE.Focus()
            End If
        Catch ex As Exception
            Bitacora("1360. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TSubTipoRem1_KeyDown(sender As Object, e As KeyEventArgs) Handles TSubTipoRem1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnSubTipoRem1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TSubTipoRem1_Validated(sender As Object, e As EventArgs) Handles TSubTipoRem1.Validated
        Try
            Select Case TSubTipoRem1.Text
                Case "CTR001"
                    LTSubTipoRem1.Text = "Caballete"
                Case "CTR002"
                    LTSubTipoRem1.Text = "Caja"
                Case "CTR003"
                    LTSubTipoRem1.Text = "Caja Abierta"
                Case "CTR004"
                    LTSubTipoRem1.Text = "Caja Cerrada"
                Case "CTR005"
                    LTSubTipoRem1.Text = "Caja De Recolección Con Cargador Frontal"
                Case "CTR006"
                    LTSubTipoRem1.Text = "Caja Refrigerada"
                Case "CTR007"
                    LTSubTipoRem1.Text = "Caja Seca"
                Case "CTR008"
                    LTSubTipoRem1.Text = "Caja Transferencia"
                Case "CTR009"
                    LTSubTipoRem1.Text = "Cama Baja o Cuello Ganso"
                Case "CTR010"
                    LTSubTipoRem1.Text = "Chasis Portacontenedor"
                Case "CTR011"
                    LTSubTipoRem1.Text = "Convencional De Chasis"
                Case "CTR012"
                    LTSubTipoRem1.Text = "Equipo Especial"
                Case "CTR013"
                    LTSubTipoRem1.Text = "Estacas"
                Case "CTR014"
                    LTSubTipoRem1.Text = "Góndola Madrina"
                Case "CTR015"
                    LTSubTipoRem1.Text = "Grúa Industrial"
                Case "CTR016"
                    LTSubTipoRem1.Text = "Grúa "
                Case "CTR017"
                    LTSubTipoRem1.Text = "Integral"
                Case "CTR018"
                    LTSubTipoRem1.Text = "Jaula"
                Case "CTR019"
                    LTSubTipoRem1.Text = "Media Redila"
                Case "CTR020"
                    LTSubTipoRem1.Text = "Pallet o Celdillas"
                Case "CTR021"
                    LTSubTipoRem1.Text = "Plataforma"
                Case "CTR022"
                    LTSubTipoRem1.Text = "Plataforma Con Grúa"
                Case "CTR023"
                    LTSubTipoRem1.Text = "Plataforma Encortinada"
                Case "CTR024"
                    LTSubTipoRem1.Text = "Redilas"
                Case "CTR025"
                    LTSubTipoRem1.Text = "Refrigerador"
                Case "CTR026"
                    LTSubTipoRem1.Text = "Revolvedora"
                Case "CTR027"
                    LTSubTipoRem1.Text = "Semicaja"
                Case "CTR028"
                    LTSubTipoRem1.Text = "Tanque"
                Case "CTR029"
                    LTSubTipoRem1.Text = "Tolva"
                Case "CTR030"
                    LTSubTipoRem1.Text = "Tractor"
                Case "CTR031"
                    LTSubTipoRem1.Text = "Volteo"
                Case "CTR032"
                    LTSubTipoRem1.Text = "Volteo Desmontable"
                Case Else
                    MsgBox("Sub tipo 1 inexistente")
                    LTSubTipoRem1.Text = ""
            End Select
        Catch ex As Exception
            Bitacora("1450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnActivo_Click(sender As Object, e As EventArgs) Handles BtnActivo.Click
        Try
            If BtnActivo.Text = "Activo" Then
                BtnActivo.Text = "Baja"
                Lb1.Visible = True
                Lb2.Visible = True
                TMOTIVO_BAJA.Visible = True
            Else
                BtnActivo.Text = "Activo"
                Lb1.Visible = False
                Lb2.Visible = False
                TMOTIVO_BAJA.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LL5_Click(sender As Object, e As EventArgs) Handles LL5.Click

    End Sub

    Private Sub LL11_Click(sender As Object, e As EventArgs) Handles LL11.Click

    End Sub

    Private Sub LL10_Click(sender As Object, e As EventArgs) Handles LL10.Click

    End Sub

    Private Sub LL9_Click(sender As Object, e As EventArgs) Handles LL9.Click

    End Sub

    Private Sub LL8_Click(sender As Object, e As EventArgs) Handles LL8.Click

    End Sub

    Private Sub LL7_Click(sender As Object, e As EventArgs) Handles LL7.Click

    End Sub

    Private Sub LL6_Click(sender As Object, e As EventArgs) Handles LL6.Click

    End Sub

    Private Sub LL12_Click(sender As Object, e As EventArgs) Handles LL12.Click

    End Sub

    Private Sub LL4_Click(sender As Object, e As EventArgs) Handles LL4.Click

    End Sub
End Class
