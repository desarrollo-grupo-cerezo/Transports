Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Themes

Public Class FrmInspeccionLlantasAE
    Private NewInspec As Boolean
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmInspeccionLlantasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        SplitM.Dock = DockStyle.Fill
        SplitM.SplitterWidth = 1
        SplitM.BorderWidth = 1
        SplitM.HeaderLineWidth = 1
        SplitM.FixedLineWidth = 1

        Dim SPOR1 As Decimal

        SPOR1 = ((TFECHA.Top + TFECHA.Height + 40) / Me.Height) * 100
        Split1.SizeRatio = SPOR1

        Split2.SizeRatio = 100 - Split1.SizeRatio - SPOR1
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            'BtnMod.FlatStyle = FlatStyle.Flat
            'BtnMod.FlatAppearance.BorderSize = 0

            Me.CenterToScreen()
            Me.KeyPreview = True
            TCVE_UNI.Text = "" : TPOSICION1.Value = 0 : TMARCA1.Text = "" : TMODELO1.Text = "" : TTIPO_LLANTA1.Text = "" : TObs1.Text = ""

            TCOSTO_LLANTA1.Value = 0 : TKMS_MONTAR1.Value = 0 : TPROFUNDIDA_ORIGINAL1.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS1.Value = 0 : TPROFUNDIDAD_ACTUAL11.Value = 0 : TPOSICION1.Value = 0 : TDESGASTE1.Value = 0
            TCOSTO_LLANTA2.Value = 0 : TKMS_MONTAR2.Value = 0 : TPROFUNDIDA_ORIGINAL2.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS2.Value = 0 : TPROFUNDIDAD_ACTUAL12.Value = 0 : TPOSICION2.Value = 0 : TDESGASTE2.Value = 0
            TCOSTO_LLANTA3.Value = 0 : TKMS_MONTAR3.Value = 0 : TPROFUNDIDA_ORIGINAL3.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS3.Value = 0 : TPROFUNDIDAD_ACTUAL13.Value = 0 : TPOSICION3.Value = 0 : TDESGASTE3.Value = 0
            TCOSTO_LLANTA4.Value = 0 : TKMS_MONTAR4.Value = 0 : TPROFUNDIDA_ORIGINAL4.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS4.Value = 0 : TPROFUNDIDAD_ACTUAL14.Value = 0 : TPOSICION4.Value = 0 : TDESGASTE4.Value = 0
            TCOSTO_LLANTA5.Value = 0 : TKMS_MONTAR5.Value = 0 : TPROFUNDIDA_ORIGINAL5.Value = 0 : TKMS_DESMONTAR5.Value = 0 : TKM_RECORRIDOS5.Value = 0 : TPROFUNDIDAD_ACTUAL15.Value = 0 : TPOSICION5.Value = 0 : TDESGASTE5.Value = 0
            TCOSTO_LLANTA6.Value = 0 : TKMS_MONTAR6.Value = 0 : TPROFUNDIDA_ORIGINAL6.Value = 0 : TKMS_DESMONTAR6.Value = 0 : TKM_RECORRIDOS6.Value = 0 : TPROFUNDIDAD_ACTUAL16.Value = 0 : TPOSICION6.Value = 0 : TDESGASTE6.Value = 0
            TCOSTO_LLANTA7.Value = 0 : TKMS_MONTAR7.Value = 0 : TPROFUNDIDA_ORIGINAL7.Value = 0 : TKMS_DESMONTAR7.Value = 0 : TKM_RECORRIDOS7.Value = 0 : TPROFUNDIDAD_ACTUAL17.Value = 0 : TPOSICION7.Value = 0 : TDESGASTE7.Value = 0
            TCOSTO_LLANTA8.Value = 0 : TKMS_MONTAR8.Value = 0 : TPROFUNDIDA_ORIGINAL8.Value = 0 : TKMS_DESMONTAR8.Value = 0 : TKM_RECORRIDOS8.Value = 0 : TPROFUNDIDAD_ACTUAL18.Value = 0 : TPOSICION8.Value = 0 : TDESGASTE8.Value = 0
            TCOSTO_LLANTA9.Value = 0 : TKMS_MONTAR9.Value = 0 : TPROFUNDIDA_ORIGINAL9.Value = 0 : TKMS_DESMONTAR9.Value = 0 : TKM_RECORRIDOS9.Value = 0 : TPROFUNDIDAD_ACTUAL19.Value = 0 : TPOSICION9.Value = 0 : TDESGASTE9.Value = 0
            TCOSTO_LLANTA10.Value = 0 : TKMS_MONTAR10.Value = 0 : TPROFUNDIDA_ORIGINAL10.Value = 0 : TKMS_DESMONTAR10.Value = 0 : TKM_RECORRIDOS10.Value = 0 : TPROFUNDIDAD_ACTUAL110.Value = 0 : TPOSICION10.Value = 0 : TDESGASTE10.Value = 0
            TCOSTO_LLANTA11.Value = 0 : TKMS_MONTAR11.Value = 0 : TPROFUNDIDA_ORIGINAL11.Value = 0 : TKMS_DESMONTAR11.Value = 0 : TKM_RECORRIDOS11.Value = 0 : TPROFUNDIDAD_ACTUAL111.Value = 0 : TPOSICION11.Value = 0 : TDESGASTE11.Value = 0
            TCOSTO_LLANTA12.Value = 0 : TKMS_MONTAR12.Value = 0 : TPROFUNDIDA_ORIGINAL12.Value = 0 : TKMS_DESMONTAR12.Value = 0 : TKM_RECORRIDOS12.Value = 0 : TPROFUNDIDAD_ACTUAL112.Value = 0 : TPOSICION12.Value = 0 : TDESGASTE12.Value = 0

            TMARCA1.Enabled = False : TMARCA2.Enabled = False : TMARCA3.Enabled = False : TMARCA4.Enabled = False : TMARCA5.Enabled = False : TMARCA6.Enabled = False
            TMARCA7.Enabled = False : TMARCA8.Enabled = False : TMARCA9.Enabled = False : TMARCA10.Enabled = False : TMARCA11.Enabled = False : TMARCA12.Enabled = False

            TMODELO1.Enabled = False : TMODELO2.Enabled = False : TMODELO3.Enabled = False : TMODELO4.Enabled = False : TMODELO5.Enabled = False : TMODELO6.Enabled = False
            TMODELO7.Enabled = False : TMODELO8.Enabled = False : TMODELO9.Enabled = False : TMODELO10.Enabled = False : TMODELO11.Enabled = False : TMODELO12.Enabled = False

            TTIPO_LLANTA1.Enabled = False : TTIPO_LLANTA2.Enabled = False : TTIPO_LLANTA3.Enabled = False : TTIPO_LLANTA4.Enabled = False : TTIPO_LLANTA5.Enabled = False
            TTIPO_LLANTA6.Enabled = False : TTIPO_LLANTA7.Enabled = False : TTIPO_LLANTA8.Enabled = False : TTIPO_LLANTA9.Enabled = False
            TTIPO_LLANTA10.Enabled = False : TTIPO_LLANTA11.Enabled = False : TTIPO_LLANTA12.Enabled = False

            TNUEVA_RENOVADA1.Enabled = False : TNUEVA_RENOVADA2.Enabled = False : TNUEVA_RENOVADA3.Enabled = False : TNUEVA_RENOVADA4.Enabled = False : TNUEVA_RENOVADA5.Enabled = False
            TNUEVA_RENOVADA6.Enabled = False : TNUEVA_RENOVADA7.Enabled = False : TNUEVA_RENOVADA8.Enabled = False : TNUEVA_RENOVADA9.Enabled = False : TNUEVA_RENOVADA10.Enabled = False
            TNUEVA_RENOVADA11.Enabled = False : TNUEVA_RENOVADA12.Enabled = False

            TFECHA_MONTAJE1.Enabled = False : TFECHA_MONTAJE2.Enabled = False : TFECHA_MONTAJE3.Enabled = False : TFECHA_MONTAJE4.Enabled = False : TFECHA_MONTAJE5.Enabled = False
            TFECHA_MONTAJE6.Enabled = False : TFECHA_MONTAJE7.Enabled = False : TFECHA_MONTAJE8.Enabled = False : TFECHA_MONTAJE9.Enabled = False : TFECHA_MONTAJE10.Enabled = False
            TFECHA_MONTAJE11.Enabled = False : TFECHA_MONTAJE12.Enabled = False

            TCOSTO_LLANTA1.Enabled = False : TCOSTO_LLANTA2.Enabled = False : TCOSTO_LLANTA3.Enabled = False : TCOSTO_LLANTA4.Enabled = False : TCOSTO_LLANTA5.Enabled = False
            TCOSTO_LLANTA6.Enabled = False : TCOSTO_LLANTA7.Enabled = False : TCOSTO_LLANTA8.Enabled = False : TCOSTO_LLANTA9.Enabled = False : TCOSTO_LLANTA10.Enabled = False
            TCOSTO_LLANTA11.Enabled = False : TCOSTO_LLANTA12.Enabled = False

            TKMS_MONTAR1.Enabled = False : TKMS_MONTAR2.Enabled = False : TKMS_MONTAR3.Enabled = False : TKMS_MONTAR4.Enabled = False : TKMS_MONTAR5.Enabled = False
            TKMS_MONTAR6.Enabled = False : TKMS_MONTAR7.Enabled = False : TKMS_MONTAR8.Enabled = False : TKMS_MONTAR9.Enabled = False : TKMS_MONTAR10.Enabled = False
            TKMS_MONTAR11.Enabled = False : TKMS_MONTAR12.Enabled = False

            TPROFUNDIDA_ORIGINAL1.Enabled = False : TPROFUNDIDA_ORIGINAL2.Enabled = False : TPROFUNDIDA_ORIGINAL3.Enabled = False : TPROFUNDIDA_ORIGINAL4.Enabled = False
            TPROFUNDIDA_ORIGINAL5.Enabled = False : TPROFUNDIDA_ORIGINAL6.Enabled = False : TPROFUNDIDA_ORIGINAL7.Enabled = False : TPROFUNDIDA_ORIGINAL8.Enabled = False
            TPROFUNDIDA_ORIGINAL9.Enabled = False : TPROFUNDIDA_ORIGINAL10.Enabled = False : TPROFUNDIDA_ORIGINAL11.Enabled = False : TPROFUNDIDA_ORIGINAL12.Enabled = False

            TDESGASTE1.Enabled = False : TDESGASTE2.Enabled = False : TDESGASTE3.Enabled = False : TDESGASTE4.Enabled = False : TDESGASTE5.Enabled = False : TDESGASTE6.Enabled = False
            TDESGASTE7.Enabled = False : TDESGASTE8.Enabled = False : TDESGASTE9.Enabled = False : TDESGASTE10.Enabled = False : TDESGASTE11.Enabled = False : TDESGASTE12.Enabled = False

            TKM_RECORRIDOS1.Enabled = False : TKM_RECORRIDOS2.Enabled = False : TKM_RECORRIDOS3.Enabled = False : TKM_RECORRIDOS4.Enabled = False : TKM_RECORRIDOS5.Enabled = False
            TKM_RECORRIDOS6.Enabled = False : TKM_RECORRIDOS7.Enabled = False : TKM_RECORRIDOS8.Enabled = False : TKM_RECORRIDOS9.Enabled = False : TKM_RECORRIDOS10.Enabled = False
            TKM_RECORRIDOS11.Enabled = False : TKM_RECORRIDOS12.Enabled = False

            TPOSICION1.Enabled = False : TPOSICION2.Enabled = False : TPOSICION3.Enabled = False : TPOSICION4.Enabled = False : TPOSICION5.Enabled = False : TPOSICION6.Enabled = False
            TPOSICION7.Enabled = False : TPOSICION8.Enabled = False : TPOSICION9.Enabled = False : TPOSICION10.Enabled = False : TPOSICION11.Enabled = False : TPOSICION12.Enabled = False


            TKM_ACTUAL1.Value = 0 : TKM_ACTUAL2.Value = 0 : TKM_ACTUAL3.Value = 0 : TKM_ACTUAL4.Value = 0 : TKM_ACTUAL5.Value = 0 : TKM_ACTUAL6.Value = 0
            TKM_ACTUAL7.Value = 0 : TKM_ACTUAL8.Value = 0 : TKM_ACTUAL9.Value = 0 : TKM_ACTUAL10.Value = 0 : TKM_ACTUAL11.Value = 0 : TKM_ACTUAL12.Value = 0
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            NewInspec = True
            LtSt.Text = "EDICION"

            LtCve_Ins.Text = GET_MAX("GCINSPEC_LLANTAS", "CVE_INS")
            Try
                TCVE_UNI.Text = ""
                TCVE_UNI.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

        Else
            LtCve_Ins.Text = Var2
            NewInspec = False
            Try
                Dim NUM As Integer = 1, TIP_UNI As String = "1"

                SQL = "SELECT I.UNIDAD, ISNULL(I.STATUS,'') AS ST, I.FECHA, I.NUM_ECONOMICO, ISNULL(I.POSICION,0) AS POSI, ISNULL(L.TIPO_NUEVA_RENO,0) AS TIPO_NEW_REN, 
                    L.FECHA_MON, L.MARCA, L.MODELO, L.TIPO_LLANTA, M.DESCR AS DESCR_MARCA, MO.DESCR AS DESCR_MODELO, T.DESCR AS DESCR_TIPO, L.COSTO_LLANTA_MN, 
                    L.PROFUNDIDA_ORIGINAL, I.PROFUNDIDAD_ACTUAL, I.PROFUNDIDAD_ACTUAL2, I.PROFUNDIDAD_ACTUAL3, I.PROFUNDIDAD_ACTUAL4, I.PRESION_ACTUAL, 
                    L.KMS_MONTAR, I.KMS_DESMONTAR, I.KMS_RECORRIDOS, I.DESGASTE, I.OBS, ISNULL(U.CVE_TIPO_UNI,'1') AS TIP_UNI, ISNULL(I.KMS_ACTUAL,0) AS KM_ACT,
                    I.TIPO_RIN
                    FROM GCINSPEC_LLANTAS I 
                    LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = I.UNIDAD
                    LEFT JOIN GCLLANTAS L ON L.NUM_ECONOMICO = I.NUM_ECONOMICO 
                    LEFT JOIN GCMARCAS M ON M.CVE_MARCA = L.MARCA
                    LEFT JOIN GCLLANTA_MODELO MO ON MO.CVE_MODELO = L.MODELO
                    LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = L.STATUS_LLANTA 
                    LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = L.TIPO_LLANTA
                    WHERE I.CVE_INS = " & CONVERTIR_TO_LONG(Var2) & " ORDER BY L.POSICION"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read
                            TCVE_UNI.Text = dr("UNIDAD")
                            TIP_UNI = dr("TIP_UNI")
                            If IsDate(dr("FECHA")) Then
                                TFECHA.Value = dr("FECHA")
                            End If

                            Select Case dr("ST")
                                Case "E"
                                    LtSt.Text = "EDICION"
                                Case "F"
                                    LtSt.Text = "FINALIZADO"
                                Case "C"
                                    LtSt.Text = "CANCELADO"
                            End Select
                            Select Case dr("POSI")
                                Case 1
                                    TLL1.Text = dr("NUM_ECONOMICO")
                                    TMARCA1.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO1.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA1.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA1.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE1.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA1.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL1.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS1.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL21.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL31.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL41.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION1.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE1.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TKM_ACTUAL1.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN1.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                    TObs1.Text = dr.ReadNullAsEmptyString("OBS")
                                Case 2
                                    TLL2.Text = dr("NUM_ECONOMICO")
                                    TMARCA2.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO2.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA2.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA2.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE2.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA2.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR2.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL2.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR2.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS2.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL12.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL22.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL32.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL42.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL12.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION2.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE2.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs2.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL2.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN2.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 3
                                    TLL3.Text = dr("NUM_ECONOMICO")
                                    TMARCA3.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO3.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA3.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA3.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA3.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE3.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA3.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR3.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL3.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR3.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS3.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL13.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL23.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL33.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL43.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL13.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION3.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE3.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs3.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL3.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN3.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 4
                                    TLL4.Text = dr("NUM_ECONOMICO")
                                    TMARCA4.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO4.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA4.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA4.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE4.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA4.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR4.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL4.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR4.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS4.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL14.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL24.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL34.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL44.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL14.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION4.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE4.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs4.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL4.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN4.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 5
                                    TLL5.Text = dr("NUM_ECONOMICO")
                                    TMARCA5.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO5.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA5.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA5.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA5.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE5.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA5.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR5.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL5.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR5.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS5.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL15.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL25.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL35.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL45.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL15.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION5.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE5.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs5.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL5.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN5.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 6
                                    TLL6.Text = dr("NUM_ECONOMICO")
                                    TMARCA6.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO6.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA6.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA6.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA6.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE6.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA6.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR6.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL6.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR6.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS6.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL16.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL26.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL36.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL46.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL16.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION6.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE6.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs6.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL6.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN6.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 7
                                    TLL7.Text = dr("NUM_ECONOMICO")
                                    TMARCA7.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO7.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA7.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA7.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA7.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE7.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA7.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR7.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL7.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR7.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS7.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL17.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL27.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL37.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL47.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL17.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION7.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE7.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs7.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL7.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN7.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 8
                                    TLL8.Text = dr("NUM_ECONOMICO")
                                    TMARCA8.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO8.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA8.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA8.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA8.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE8.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA8.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR8.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL8.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR8.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS8.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL18.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL28.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL38.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL48.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL18.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION8.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE8.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs8.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL8.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN8.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 9
                                    TLL9.Text = dr("NUM_ECONOMICO")
                                    TMARCA9.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO9.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA9.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA9.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA9.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE9.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA9.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR9.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL9.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR9.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS9.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL19.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL29.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL39.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL49.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL19.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION9.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE9.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs9.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL9.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN9.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 10
                                    TLL10.Text = dr("NUM_ECONOMICO")
                                    TMARCA10.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO10.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA10.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA10.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA10.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE10.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA10.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR10.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL10.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR10.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS10.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL110.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL210.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL310.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL410.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL110.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION10.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE10.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs10.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL10.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN10.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 11
                                    TLL11.Text = dr("NUM_ECONOMICO")
                                    TMARCA11.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO11.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA11.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA11.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA11.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE11.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA11.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR11.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR11.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS11.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL111.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL211.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL311.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL411.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL111.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION11.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE11.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs11.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN11.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                                Case 12
                                    TLL12.Text = dr("NUM_ECONOMICO")
                                    TMARCA12.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                    TMODELO12.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                    TTIPO_LLANTA12.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                    If dr("TIPO_NEW_REN") = 0 Then
                                        TNUEVA_RENOVADA12.Text = "Nueva"
                                    Else
                                        TNUEVA_RENOVADA12.Text = "Renovada"
                                    End If
                                    TFECHA_MONTAJE12.Text = dr("FECHA_MON")
                                    TCOSTO_LLANTA12.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                    TKMS_MONTAR12.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                    TPROFUNDIDA_ORIGINAL12.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                                    TKMS_DESMONTAR12.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                    TKM_RECORRIDOS12.Value = dr.ReadNullAsEmptyDecimal("KMS_RECORRIDOS")

                                    TPROFUNDIDAD_ACTUAL112.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL212.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL312.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL412.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL112.Value = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                    TPOSICION12.Value = dr.ReadNullAsEmptyInteger("POSI")
                                    TDESGASTE12.Value = dr.ReadNullAsEmptyInteger("DESGASTE")
                                    TObs12.Text = dr.ReadNullAsEmptyString("OBS")
                                    TKM_ACTUAL12.Value = dr.ReadNullAsEmptyDecimal("KM_ACT")
                                    TTIPO_RIN12.Text = dr.ReadNullAsEmptyString("TIPO_RIN")
                            End Select
                            NUM += 1
                        Loop
                    End Using
                End Using

                Select Case TIP_UNI
                    Case "1"    'TRACTOR    1
                        Et9.Visible = True : TLL9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True
                        Et11.Visible = False : TLL11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False
                        TMARCA9.Visible = True : TMODELO9.Visible = True : TTIPO_LLANTA9.Visible = True : TNUEVA_RENOVADA9.Visible = True : TFECHA_MONTAJE9.Visible = True : TCOSTO_LLANTA9.Visible = True
                        TKMS_MONTAR9.Visible = True : TPROFUNDIDA_ORIGINAL9.Visible = True : TKMS_DESMONTAR9.Visible = True : TKM_RECORRIDOS9.Visible = True
                        TPOSICION9.Visible = True : TDESGASTE9.Visible = True : TObs9.Visible = True

                        TMARCA10.Visible = True : TMODELO10.Visible = True : TTIPO_LLANTA10.Visible = True : TNUEVA_RENOVADA10.Visible = True : TFECHA_MONTAJE10.Visible = True : TCOSTO_LLANTA10.Visible = True
                        TKMS_MONTAR10.Visible = True : TPROFUNDIDA_ORIGINAL10.Visible = True : TKMS_DESMONTAR10.Visible = True : TKM_RECORRIDOS10.Visible = True
                        TPOSICION10.Visible = True : TDESGASTE10.Visible = True : TObs10.Visible = True

                        TMARCA11.Visible = False : TMODELO11.Visible = False : TTIPO_LLANTA11.Visible = False : TNUEVA_RENOVADA11.Visible = False : TFECHA_MONTAJE11.Visible = False : TCOSTO_LLANTA11.Visible = False
                        TKMS_MONTAR11.Visible = False : TPROFUNDIDA_ORIGINAL11.Visible = False : TKMS_DESMONTAR11.Visible = False : TKM_RECORRIDOS11.Visible = False
                        TPOSICION11.Visible = False : TDESGASTE11.Visible = False : TObs11.Visible = False

                        TMARCA12.Visible = False : TMODELO12.Visible = False : TTIPO_LLANTA12.Visible = False : TNUEVA_RENOVADA12.Visible = False : TFECHA_MONTAJE12.Visible = False : TCOSTO_LLANTA12.Visible = False
                        TKMS_MONTAR12.Visible = False : TPROFUNDIDA_ORIGINAL12.Visible = False : TKMS_DESMONTAR12.Visible = False : TKM_RECORRIDOS12.Visible = False
                        TPOSICION12.Visible = False : TDESGASTE12.Visible = False : TObs12.Visible = False

                        TPROFUNDIDAD_ACTUAL19.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True : TPROFUNDIDAD_ACTUAL111.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPROFUNDIDAD_ACTUAL29.Visible = True : TPROFUNDIDAD_ACTUAL210.Visible = True : TPROFUNDIDAD_ACTUAL211.Visible = False : TPROFUNDIDAD_ACTUAL212.Visible = False
                        TPROFUNDIDAD_ACTUAL39.Visible = True : TPROFUNDIDAD_ACTUAL310.Visible = True : TPROFUNDIDAD_ACTUAL311.Visible = False : TPROFUNDIDAD_ACTUAL312.Visible = False
                        TPROFUNDIDAD_ACTUAL49.Visible = True : TPROFUNDIDAD_ACTUAL410.Visible = True : TPROFUNDIDAD_ACTUAL411.Visible = False : TPROFUNDIDAD_ACTUAL412.Visible = False
                        TPRESION_ACTUAL111.Visible = False : TPRESION_ACTUAL112.Visible = False

                    Case "2"    'TANQUE1  1  2
                        Et9.Visible = True : TLL9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True
                        Et11.Visible = True : TLL11.Visible = True
                        Et12.Visible = True : TLL12.Visible = True
                        TMARCA9.Visible = True : TMODELO9.Visible = True : TTIPO_LLANTA9.Visible = True : TNUEVA_RENOVADA9.Visible = True : TFECHA_MONTAJE9.Visible = True : TCOSTO_LLANTA9.Visible = True
                        TKMS_MONTAR9.Visible = True : TPROFUNDIDA_ORIGINAL9.Visible = True : TKMS_DESMONTAR9.Visible = True : TKM_RECORRIDOS9.Visible = True
                        TPOSICION9.Visible = True : TDESGASTE9.Visible = True : TObs9.Visible = True

                        TMARCA10.Visible = True : TMODELO10.Visible = True : TTIPO_LLANTA10.Visible = True : TNUEVA_RENOVADA10.Visible = True : TFECHA_MONTAJE10.Visible = True : TCOSTO_LLANTA10.Visible = True
                        TKMS_MONTAR10.Visible = True : TPROFUNDIDA_ORIGINAL10.Visible = True : TKMS_DESMONTAR10.Visible = True : TKM_RECORRIDOS10.Visible = True
                        TPOSICION10.Visible = True : TDESGASTE10.Visible = True : TObs10.Visible = True

                        TMARCA11.Visible = True : TMODELO11.Visible = True : TTIPO_LLANTA11.Visible = True : TNUEVA_RENOVADA11.Visible = True : TFECHA_MONTAJE11.Visible = True : TCOSTO_LLANTA11.Visible = True
                        TKMS_MONTAR11.Visible = True : TPROFUNDIDA_ORIGINAL11.Visible = True : TKMS_DESMONTAR11.Visible = True : TKM_RECORRIDOS11.Visible = True
                        TPOSICION11.Visible = True : TDESGASTE11.Visible = True : TObs11.Visible = True

                        TMARCA12.Visible = True : TMODELO12.Visible = True : TTIPO_LLANTA12.Visible = True : TNUEVA_RENOVADA12.Visible = True : TFECHA_MONTAJE12.Visible = True : TCOSTO_LLANTA12.Visible = True
                        TKMS_MONTAR12.Visible = True : TPROFUNDIDA_ORIGINAL12.Visible = True : TKMS_DESMONTAR12.Visible = True : TKM_RECORRIDOS12.Visible = True
                        TPOSICION12.Visible = True : TDESGASTE12.Visible = True : TObs12.Visible = True

                        TPROFUNDIDAD_ACTUAL19.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True : TPROFUNDIDAD_ACTUAL111.Visible = True : TPROFUNDIDAD_ACTUAL112.Visible = True
                        TPROFUNDIDAD_ACTUAL29.Visible = True : TPROFUNDIDAD_ACTUAL210.Visible = True : TPROFUNDIDAD_ACTUAL211.Visible = True : TPROFUNDIDAD_ACTUAL212.Visible = True
                        TPROFUNDIDAD_ACTUAL39.Visible = True : TPROFUNDIDAD_ACTUAL310.Visible = True : TPROFUNDIDAD_ACTUAL311.Visible = True : TPROFUNDIDAD_ACTUAL312.Visible = True
                        TPROFUNDIDAD_ACTUAL49.Visible = True : TPROFUNDIDAD_ACTUAL410.Visible = True : TPROFUNDIDAD_ACTUAL411.Visible = True : TPROFUNDIDAD_ACTUAL412.Visible = True
                        TPRESION_ACTUAL111.Visible = True : TPRESION_ACTUAL112.Visible = True

                    Case "3"    'DOLLY      3
                        Et9.Visible = False : TLL9.Visible = False
                        Et10.Visible = False : TLL10.Visible = False
                        Et11.Visible = False : TLL11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False

                        TMARCA9.Visible = False : TMODELO9.Visible = False : TTIPO_LLANTA9.Visible = False : TNUEVA_RENOVADA9.Visible = False : TFECHA_MONTAJE9.Visible = False : TCOSTO_LLANTA9.Visible = False
                        TKMS_MONTAR9.Visible = False : TPROFUNDIDA_ORIGINAL9.Visible = False : TKMS_DESMONTAR9.Visible = False : TKM_RECORRIDOS9.Visible = False : TPROFUNDIDAD_ACTUAL19.Visible = False
                        TPOSICION9.Visible = False : TDESGASTE9.Visible = False : TObs9.Visible = False

                        TMARCA10.Visible = False : TMODELO10.Visible = False : TTIPO_LLANTA10.Visible = False : TNUEVA_RENOVADA10.Visible = False : TFECHA_MONTAJE10.Visible = False : TCOSTO_LLANTA10.Visible = False
                        TKMS_MONTAR10.Visible = False : TPROFUNDIDA_ORIGINAL10.Visible = False : TKMS_DESMONTAR10.Visible = False : TKM_RECORRIDOS10.Visible = False : TPROFUNDIDAD_ACTUAL110.Visible = False
                        TPOSICION10.Visible = False : TDESGASTE10.Visible = False : TObs10.Visible = False

                        TMARCA11.Visible = False : TMODELO11.Visible = False : TTIPO_LLANTA11.Visible = False : TNUEVA_RENOVADA11.Visible = False : TFECHA_MONTAJE11.Visible = False : TCOSTO_LLANTA11.Visible = False
                        TKMS_MONTAR11.Visible = False : TPROFUNDIDA_ORIGINAL11.Visible = False : TKMS_DESMONTAR11.Visible = False : TKM_RECORRIDOS11.Visible = False : TPROFUNDIDAD_ACTUAL111.Visible = False
                        TPOSICION11.Visible = False : TDESGASTE11.Visible = False : TObs11.Visible = False

                        TMARCA12.Visible = False : TMODELO12.Visible = False : TTIPO_LLANTA12.Visible = False : TNUEVA_RENOVADA12.Visible = False : TFECHA_MONTAJE12.Visible = False : TCOSTO_LLANTA12.Visible = False
                        TKMS_MONTAR12.Visible = False : TPROFUNDIDA_ORIGINAL12.Visible = False : TKMS_DESMONTAR12.Visible = False : TKM_RECORRIDOS12.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPOSICION12.Visible = False : TDESGASTE12.Visible = False : TObs12.Visible = False

                        TPROFUNDIDAD_ACTUAL19.Visible = False : TPROFUNDIDAD_ACTUAL110.Visible = False : TPROFUNDIDAD_ACTUAL111.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPROFUNDIDAD_ACTUAL29.Visible = False : TPROFUNDIDAD_ACTUAL210.Visible = False : TPROFUNDIDAD_ACTUAL211.Visible = False : TPROFUNDIDAD_ACTUAL212.Visible = False
                        TPROFUNDIDAD_ACTUAL39.Visible = False : TPROFUNDIDAD_ACTUAL310.Visible = False : TPROFUNDIDAD_ACTUAL311.Visible = False : TPROFUNDIDAD_ACTUAL312.Visible = False
                        TPROFUNDIDAD_ACTUAL49.Visible = False : TPROFUNDIDAD_ACTUAL410.Visible = False : TPROFUNDIDAD_ACTUAL411.Visible = False : TPROFUNDIDAD_ACTUAL412.Visible = False
                        TPRESION_ACTUAL111.Visible = False : TPRESION_ACTUAL112.Visible = False
                End Select

                If LtSt.Text = "FINALIZADO" Or LtSt.Text = "CANCELADO" Then
                    SET_ALL_CONTROL_READ_AND_ENABLED(Split1)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Split2)
                End If

                TCVE_UNI.Enabled = False
                BtnUnidades.Enabled = False
                TLL1.Select()
            Catch ex As Exception
                Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
                If PASS_GRUPOCE = "BUS" Then
                    MsgBox("49. " & ex.Message & vbNewLine & ex.StackTrace)
                End If
            End Try
        End If
    End Sub
    Sub DESPLEGAR_INSPECCION(FNUM As Integer, FNUM_ECONOMICO As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT I.NUM_ECONOMICO, I.STATUS, I.FECHA, I.UNIDAD, L.POSICION, ISNULL(L.TIPO_NUEVA_RENO,0) AS TIPO_NEW_REN, L.FECHA_MON, 
                L.MARCA, L.MODELO, L.TIPO_LLANTA, M.DESCR AS DESCR_MARCA, MO.DESCR AS DESCR_MODELO, T.DESCR AS DESCR_TIPO,
                L.COSTO_LLANTA_MN, L.PROFUNDIDA_ORIGINAL, L.PROFUNDIDAD_ACTUAL, L.KMS_MONTAR, L.KMS_DESMONTAR, I.DESGASTE, I.OBS 
                FROM GCINSPEC_LLANTAS I 
                LEFT JOIN GCLLANTAS L ON L.NUM_ECONOMICO = I.NUM_ECONOMICO
                LEFT JOIN GCMARCAS M ON M.CVE_MARCA = L.MARCA
                LEFT JOIN GCLLANTA_MODELO MO ON MO.CVE_MODELO = L.MODELO
                LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = L.STATUS_LLANTA 
                LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = L.TIPO_LLANTA
                WHERE I.NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then

                Select Case FNUM
                    Case 1
                        If Not IsDBNull(dr("FECHA")) Then TFECHA.Value = dr("FECHA")
                        TPOSICION1.Value = dr("POSICION")
                        TMARCA1.Text = dr.ReadNullAsEmptyString("MARCA")
                        TMODELO1.Text = dr.ReadNullAsEmptyString("MODELO")
                        TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("TIPO_LLANTA")
                        TCOSTO_LLANTA1.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                        TPROFUNDIDA_ORIGINAL1.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                        TPROFUNDIDAD_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                        TKMS_MONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                        TKMS_DESMONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                        TDESGASTE1.Value = dr.ReadNullAsEmptyDecimal("DESGASTE")
                        TObs1.Text = dr.ReadNullAsEmptyString("OBS")

                End Select
            End If

            dr.Close()
            TCVE_UNI.Select()
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim CVE_INS As Long

        CVE_INS = GET_MAX("GCINSPEC_LLANTAS", "CVE_INS")

        Try
            TPOSICION1.UpdateValueWithCurrentText()
            TCOSTO_LLANTA1.UpdateValueWithCurrentText()
            TPROFUNDIDA_ORIGINAL1.UpdateValueWithCurrentText()
            TPROFUNDIDAD_ACTUAL11.UpdateValueWithCurrentText()
            TKMS_MONTAR1.UpdateValueWithCurrentText()
            TKMS_DESMONTAR1.UpdateValueWithCurrentText()
            TDESGASTE1.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If NewInspec Then
            SQL = "INSERT INTO GCINSPEC_LLANTAS (CVE_INS, UNIDAD, NUM_ECONOMICO, FECHA, STATUS, MARCA, MODELO, TIPO_LLANTA, TIPO_NUEVA_RENO, FECHA_MON, 
                COSTO_LLANTA_MN, KMS_MONTAR, KMS_DESMONTAR, KMS_RECORRIDOS, PROFUNDIDAD_ACTUAL, PROFUNDIDAD_ACTUAL2, PROFUNDIDAD_ACTUAL3, PROFUNDIDAD_ACTUAL4, 
                PRESION_ACTUAL, PROFUNDIDA_ORIGINAL, POSICION, DESGASTE, OBS, FECHAELAB, UUID, KMS_ACTUAL, TIPO_RIN) 
                VALUES(
                @CVE_INS, @UNIDAD, @NUM_ECONOMICO, @FECHA, 'E', @MARCA, @MODELO, @TIPO_LLANTA, @TIPO_NUEVA_RENO, @FECHA_MON, @COSTO_LLANTA_MN, @KMS_MONTAR, 
                @KMS_DESMONTAR, @KMS_RECORRIDOS, @PROFUNDIDAD_ACTUAL, @PROFUNDIDAD_ACTUAL2, @PROFUNDIDAD_ACTUAL3, @PROFUNDIDAD_ACTUAL4, @PRESION_ACTUAL, 
                @PROFUNDIDA_ORIGINAL, @POSICION, @DESGASTE, @OBS, GETDATE(), NEWID(), @KMS_ACTUAL, @TIPO_RIN)"
        Else
            SQL = "UPDATE GCINSPEC_LLANTAS SET FECHA = @FECHA, MARCA = @MARCA, MODELO = @MODELO, TIPO_LLANTA = @TIPO_LLANTA, 
                TIPO_NUEVA_RENO = @TIPO_NUEVA_RENO, FECHA_MON = @FECHA_MON, COSTO_LLANTA_MN = @COSTO_LLANTA_MN, KMS_MONTAR = @KMS_MONTAR,
	            PROFUNDIDAD_ACTUAL = @PROFUNDIDAD_ACTUAL, KMS_DESMONTAR = @KMS_DESMONTAR, KMS_RECORRIDOS = @KMS_RECORRIDOS, 
                PROFUNDIDA_ORIGINAL = @PROFUNDIDA_ORIGINAL, POSICION = @POSICION, DESGASTE = @DESGASTE, OBS = @OBS, 
                PROFUNDIDAD_ACTUAL2 = @PROFUNDIDAD_ACTUAL2, PROFUNDIDAD_ACTUAL3 = @PROFUNDIDAD_ACTUAL3, PROFUNDIDAD_ACTUAL4 = @PROFUNDIDAD_ACTUAL4, 
                PRESION_ACTUAL = @PRESION_ACTUAL, KMS_ACTUAL = @KMS_ACTUAL, TIPO_RIN = @TIPO_RIN
                WHERE UNIDAD = @UNIDAD AND NUM_ECONOMICO = @NUM_ECONOMICO"
        End If


        Try
            For k = 1 To 12
                Select Case k
                    Case 1
                        If TLL1.Text.Trim.Length > 0 Then

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL1.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA1.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO1.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA1.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA1.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE1.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA1.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR1.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL1.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR1.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR1.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL11.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL21.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL31.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL41.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL11.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 1
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE1.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs1.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL1.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN1.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 2
                        If TLL2.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL2.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA2.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO2.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA2.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA2.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE2.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA2.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR2.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL2.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR2.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR2.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL12.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL22.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL32.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL42.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL12.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 2
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE2.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs2.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL2.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN2.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 3
                        If TLL3.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL3.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA3.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO3.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA3.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA3.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE3.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA3.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR3.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL3.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR3.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR3.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL13.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL23.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL33.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL43.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL13.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 3
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE3.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs3.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL3.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN3.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 4
                        If TLL4.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL4.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA4.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO4.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA4.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA4.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE4.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA4.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR4.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL4.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR4.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR4.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL14.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL24.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL34.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL44.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL14.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 4
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE4.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs4.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL4.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN4.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 5
                        If TLL5.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL5.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA5.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO5.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA5.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA5.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE5.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA5.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR5.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL5.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR5.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR5.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL15.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL25.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL35.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL45.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL15.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 5
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE5.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs5.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL5.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN5.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 6
                        If TLL6.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL6.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA6.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO6.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA6.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA6.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE6.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA6.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR6.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL6.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR6.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR6.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL16.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL26.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL36.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL46.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL16.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 6
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE6.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs6.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL6.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN6.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 7
                        If TLL7.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL7.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA7.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO7.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA7.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA7.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE7.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA7.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR7.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL7.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR7.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR7.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL17.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL27.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL37.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL47.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL17.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 7
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE7.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs7.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL7.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN7.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 8
                        If TLL8.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL8.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA8.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO8.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA8.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA8.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE8.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA8.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR8.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL8.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR8.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR8.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL18.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL28.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL38.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL48.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL18.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 8
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE8.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs8.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL8.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN8.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 9
                        If TLL9.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL9.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA9.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO9.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA9.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA9.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE9.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA9.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR9.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL9.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR9.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR9.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL19.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL29.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL39.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL49.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL19.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 9
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE9.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs9.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL9.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN9.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 10
                        If TLL10.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL10.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA10.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO10.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA10.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA10.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE10.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA10.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR10.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL10.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR10.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR10.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL110.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL210.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL310.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL410.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL110.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 10
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE10.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs10.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL10.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN10.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 11
                        If TLL11.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL11.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA11.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO11.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA11.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA11.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE11.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA11.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR11.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL11.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR11.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR11.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL111.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL211.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL311.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL411.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL111.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 11
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE11.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs11.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL11.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN11.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 12
                        If TLL12.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL12.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = TFECHA.Value
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA12.Text
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO12.Text
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA12.Text
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = TNUEVA_RENOVADA12.Text
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = TFECHA_MONTAJE12.Text
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = TCOSTO_LLANTA12.Value
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR12.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = TPROFUNDIDA_ORIGINAL12.Value
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR12.Value
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = TKMS_DESMONTAR12.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL112.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL212.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL312.Value
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL412.Value
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = TPRESION_ACTUAL112.Value
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 12
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = TDESGASTE12.Value
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = TObs12.Text
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKM_ACTUAL12.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = TTIPO_RIN12.Text
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                End Select
            Next

            Dim result = RJMessageBox.Show("Los registros se grabaron correctamente", "", MessageBoxButtons.OK)
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub


    Private Sub FrmInspeccionLlantasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub FrmInspeccionLlantasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Sub DESPLEGA_DATOS_LLANTA(FNUM As Integer, FNUM_ECONOMICO As String)

        Try
            SQL = "Select L.POSICION, ISNULL(L.TIPO_NUEVA_RENO,0) As TIPO_NEW_REN, L.FECHA_MON, PROFUNDIDAD_ACTUAL2, PROFUNDIDAD_ACTUAL3, PROFUNDIDAD_ACTUAL4,
                L.MARCA, L.MODELO, L.TIPO_LLANTA, M.DESCR AS DESCR_MARCA, MO.DESCR AS DESCR_MODELO, T.DESCR AS DESCR_TIPO, L.COSTO_LLANTA_MN, L.PROFUNDIDA_ORIGINAL, 
                L.PROFUNDIDAD_ACTUAL, L.KMS_MONTAR, L.KMS_DESMONTAR, L.PRESION_ACTUAL
                FROM GCLLANTAS L 
                LEFT JOIN GCMARCAS M ON M.CVE_MARCA = L.MARCA
                LEFT JOIN GCLLANTA_MODELO MO ON MO.CVE_MODELO = L.MODELO
                LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = L.STATUS_LLANTA 
                LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = L.TIPO_LLANTA
                WHERE NUM_ECONOMICO = '" & FNUM_ECONOMICO & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        Select Case FNUM
                            Case 1
                                TPOSICION1.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA1.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA1.Text = "Renovada"
                                End If
                                TMARCA1.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO1.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")

                                TCOSTO_LLANTA1.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL1.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL21.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL31.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL41.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL11.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE1.Text = dr("FECHA_MON")

                                TKM_RECORRIDOS1.Value = TKMS_MONTAR1.Value - TKMS_DESMONTAR1.Value
                                TDESGASTE1.Value = TPROFUNDIDA_ORIGINAL1.Value - TPROFUNDIDAD_ACTUAL11.Value
                            Case 2
                                TPOSICION2.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA2.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA2.Text = "Renovada"
                                End If
                                TMARCA2.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO2.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA2.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA2.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL2.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL12.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL22.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL32.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL42.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL12.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR2.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR2.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE2.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS2.Value = TKMS_MONTAR2.Value - TKMS_DESMONTAR2.Value
                                TDESGASTE2.Value = TPROFUNDIDA_ORIGINAL2.Value - TPROFUNDIDAD_ACTUAL12.Value
                            Case 3
                                TPOSICION3.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA3.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA3.Text = "Renovada"
                                End If
                                TMARCA3.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO3.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA3.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA3.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL3.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL13.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL23.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL33.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL43.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL13.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR3.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR3.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE3.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS3.Value = TKMS_MONTAR3.Value - TKMS_DESMONTAR3.Value
                                TDESGASTE3.Value = TPROFUNDIDA_ORIGINAL3.Value - TPROFUNDIDAD_ACTUAL13.Value
                            Case 4
                                TPOSICION4.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA4.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA4.Text = "Renovada"
                                End If
                                TMARCA4.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO4.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA4.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL4.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL14.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL24.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL34.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL44.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL14.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR4.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR4.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE4.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS4.Value = TKMS_MONTAR4.Value - TKMS_DESMONTAR4.Value
                                TDESGASTE4.Value = TPROFUNDIDA_ORIGINAL4.Value - TPROFUNDIDAD_ACTUAL14.Value
                            Case 5
                                TPOSICION5.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA5.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA5.Text = "Renovada"
                                End If
                                TMARCA5.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO5.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA5.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA5.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL5.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL15.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL25.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL35.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL45.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL15.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR5.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR5.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE5.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS5.Value = TKMS_MONTAR5.Value - TKMS_DESMONTAR5.Value
                                TDESGASTE5.Value = TPROFUNDIDA_ORIGINAL5.Value - TPROFUNDIDAD_ACTUAL15.Value
                            Case 6
                                TPOSICION6.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA6.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA6.Text = "Renovada"
                                End If
                                TMARCA6.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO6.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA6.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA6.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL6.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL16.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL26.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL36.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL46.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL16.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR6.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR6.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE6.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS6.Value = TKMS_MONTAR6.Value - TKMS_DESMONTAR6.Value
                                TDESGASTE6.Value = TPROFUNDIDA_ORIGINAL6.Value - TPROFUNDIDAD_ACTUAL16.Value
                            Case 7
                                TPOSICION7.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA7.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA7.Text = "Renovada"
                                End If
                                TMARCA7.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO7.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA7.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA7.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL7.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPRESION_ACTUAL17.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TPROFUNDIDAD_ACTUAL17.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL27.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL37.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL47.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TKMS_MONTAR7.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR7.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE7.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS7.Value = TKMS_MONTAR7.Value - TKMS_DESMONTAR7.Value
                                TDESGASTE7.Value = TPROFUNDIDA_ORIGINAL7.Value - TPROFUNDIDAD_ACTUAL17.Value
                            Case 8
                                TPOSICION8.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA8.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA8.Text = "Renovada"
                                End If
                                TMARCA8.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO8.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA8.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA8.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL8.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL18.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL28.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL38.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL48.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL18.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR8.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR8.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE8.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS8.Value = TKMS_MONTAR8.Value - TKMS_DESMONTAR8.Value
                                TDESGASTE8.Value = TPROFUNDIDA_ORIGINAL8.Value - TPROFUNDIDAD_ACTUAL18.Value
                            Case 9
                                TPOSICION9.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA9.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA9.Text = "Renovada"
                                End If
                                TMARCA9.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO9.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA9.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA9.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL9.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                TPROFUNDIDAD_ACTUAL19.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                TPROFUNDIDAD_ACTUAL29.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                TPROFUNDIDAD_ACTUAL39.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                TPROFUNDIDAD_ACTUAL49.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                TPRESION_ACTUAL19.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")

                                TKMS_MONTAR9.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR9.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE9.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS9.Value = TKMS_MONTAR9.Value - TKMS_DESMONTAR9.Value
                                TDESGASTE9.Value = TPROFUNDIDA_ORIGINAL9.Value - TPROFUNDIDAD_ACTUAL19.Value
                            Case 10
                                TPOSICION10.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA10.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA10.Text = "Renovada"
                                End If
                                TMARCA10.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO10.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA10.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA10.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL10.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                Try
                                    TPROFUNDIDAD_ACTUAL110.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL210.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL310.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL410.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL110.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")
                                Catch ex As Exception

                                End Try


                                TKMS_MONTAR10.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR10.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE10.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS10.Value = TKMS_MONTAR10.Value - TKMS_DESMONTAR10.Value
                                TDESGASTE10.Value = TPROFUNDIDA_ORIGINAL10.Value - TPROFUNDIDAD_ACTUAL110.Value
                            Case 11
                                TPOSICION11.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA11.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA11.Text = "Renovada"
                                End If
                                TMARCA11.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO11.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA11.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA11.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                Try
                                    TPROFUNDIDAD_ACTUAL111.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL211.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL311.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL411.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL111.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")
                                Catch ex As Exception

                                End Try

                                TKMS_MONTAR11.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR11.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE11.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS11.Value = TKMS_MONTAR11.Value - TKMS_DESMONTAR11.Value
                                TDESGASTE11.Value = TPROFUNDIDA_ORIGINAL11.Value - TPROFUNDIDAD_ACTUAL111.Value
                            Case 12
                                TPOSICION12.Value = dr.ReadNullAsEmptyInteger("POSICION")
                                If dr("TIPO_NEW_REN") = 0 Then
                                    TNUEVA_RENOVADA12.Text = "Nueva"
                                Else
                                    TNUEVA_RENOVADA12.Text = "Renovada"
                                End If
                                TMARCA12.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                                TMODELO12.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                                TTIPO_LLANTA12.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                                TCOSTO_LLANTA12.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                                TPROFUNDIDA_ORIGINAL12.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                                Try
                                    TPROFUNDIDAD_ACTUAL112.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")
                                    TPROFUNDIDAD_ACTUAL212.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL2")
                                    TPROFUNDIDAD_ACTUAL312.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL3")
                                    TPROFUNDIDAD_ACTUAL412.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL4")

                                    TPRESION_ACTUAL112.Text = dr.ReadNullAsEmptyDecimal("PRESION_ACTUAL")
                                Catch ex As Exception

                                End Try

                                TKMS_MONTAR12.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                                TKMS_DESMONTAR12.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")
                                TFECHA_MONTAJE12.Text = dr("FECHA_MON")
                                TKM_RECORRIDOS12.Value = TKMS_MONTAR12.Value - TKMS_DESMONTAR12.Value
                                TDESGASTE12.Value = TPROFUNDIDA_ORIGINAL12.Value - TPROFUNDIDAD_ACTUAL112.Value

                        End Select
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
            If PASS_GRUPOCE = "BUS" Then
                MsgBox("49. " & ex.Message & vbNewLine & ex.StackTrace)
            End If
        End Try
    End Sub
    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "UnidadesInspec"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var5
                L2.Text = Var6
                Var2 = ""
                Var4 = ""
                Var5 = ""

                LLANTAS_ASIGNADAS()

                'TNUM_LLANTAS.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidades_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                    LLANTAS_ASIGNADAS()
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_UNI.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub LLANTAS_ASIGNADAS()
        Dim SEL_UNI As String
        Dim Tipo_Uni As String = ""


        TCOSTO_LLANTA1.Value = 0 : TKMS_MONTAR1.Value = 0 : TPROFUNDIDA_ORIGINAL1.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS1.Value = 0 : TPROFUNDIDAD_ACTUAL11.Value = 0 : TPOSICION1.Value = 0 : TDESGASTE1.Value = 0
        TCOSTO_LLANTA2.Value = 0 : TKMS_MONTAR2.Value = 0 : TPROFUNDIDA_ORIGINAL2.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS2.Value = 0 : TPROFUNDIDAD_ACTUAL12.Value = 0 : TPOSICION2.Value = 0 : TDESGASTE2.Value = 0
        TCOSTO_LLANTA3.Value = 0 : TKMS_MONTAR3.Value = 0 : TPROFUNDIDA_ORIGINAL3.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS3.Value = 0 : TPROFUNDIDAD_ACTUAL13.Value = 0 : TPOSICION3.Value = 0 : TDESGASTE3.Value = 0
        TCOSTO_LLANTA4.Value = 0 : TKMS_MONTAR4.Value = 0 : TPROFUNDIDA_ORIGINAL4.Value = 0 : TKMS_DESMONTAR1.Value = 0 : TKM_RECORRIDOS4.Value = 0 : TPROFUNDIDAD_ACTUAL14.Value = 0 : TPOSICION4.Value = 0 : TDESGASTE4.Value = 0
        TCOSTO_LLANTA5.Value = 0 : TKMS_MONTAR5.Value = 0 : TPROFUNDIDA_ORIGINAL5.Value = 0 : TKMS_DESMONTAR5.Value = 0 : TKM_RECORRIDOS5.Value = 0 : TPROFUNDIDAD_ACTUAL15.Value = 0 : TPOSICION5.Value = 0 : TDESGASTE5.Value = 0
        TCOSTO_LLANTA6.Value = 0 : TKMS_MONTAR6.Value = 0 : TPROFUNDIDA_ORIGINAL6.Value = 0 : TKMS_DESMONTAR6.Value = 0 : TKM_RECORRIDOS6.Value = 0 : TPROFUNDIDAD_ACTUAL16.Value = 0 : TPOSICION6.Value = 0 : TDESGASTE6.Value = 0
        TCOSTO_LLANTA7.Value = 0 : TKMS_MONTAR7.Value = 0 : TPROFUNDIDA_ORIGINAL7.Value = 0 : TKMS_DESMONTAR7.Value = 0 : TKM_RECORRIDOS7.Value = 0 : TPROFUNDIDAD_ACTUAL17.Value = 0 : TPOSICION7.Value = 0 : TDESGASTE7.Value = 0
        TCOSTO_LLANTA8.Value = 0 : TKMS_MONTAR8.Value = 0 : TPROFUNDIDA_ORIGINAL8.Value = 0 : TKMS_DESMONTAR8.Value = 0 : TKM_RECORRIDOS8.Value = 0 : TPROFUNDIDAD_ACTUAL18.Value = 0 : TPOSICION8.Value = 0 : TDESGASTE8.Value = 0
        TCOSTO_LLANTA9.Value = 0 : TKMS_MONTAR9.Value = 0 : TPROFUNDIDA_ORIGINAL9.Value = 0 : TKMS_DESMONTAR9.Value = 0 : TKM_RECORRIDOS9.Value = 0 : TPROFUNDIDAD_ACTUAL19.Value = 0 : TPOSICION9.Value = 0 : TDESGASTE9.Value = 0
        TCOSTO_LLANTA10.Value = 0 : TKMS_MONTAR10.Value = 0 : TPROFUNDIDA_ORIGINAL10.Value = 0 : TKMS_DESMONTAR10.Value = 0 : TKM_RECORRIDOS10.Value = 0 : TPROFUNDIDAD_ACTUAL110.Value = 0 : TPOSICION10.Value = 0 : TDESGASTE10.Value = 0
        TCOSTO_LLANTA11.Value = 0 : TKMS_MONTAR11.Value = 0 : TPROFUNDIDA_ORIGINAL11.Value = 0 : TKMS_DESMONTAR11.Value = 0 : TKM_RECORRIDOS11.Value = 0 : TPROFUNDIDAD_ACTUAL111.Value = 0 : TPOSICION11.Value = 0 : TDESGASTE11.Value = 0
        TCOSTO_LLANTA12.Value = 0 : TKMS_MONTAR12.Value = 0 : TPROFUNDIDA_ORIGINAL12.Value = 0 : TKMS_DESMONTAR12.Value = 0 : TKM_RECORRIDOS12.Value = 0 : TPROFUNDIDAD_ACTUAL112.Value = 0 : TPOSICION12.Value = 0 : TDESGASTE12.Value = 0


        TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
        TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""
        TLL1.Tag = "" : TLL2.Tag = "" : TLL3.Tag = "" : TLL4.Tag = "" : TLL5.Tag = "" : TLL6.Tag = ""
        TLL7.Tag = "" : TLL8.Tag = "" : TLL9.Tag = "" : TLL10.Tag = "" : TLL11.Tag = "" : TLL12.Tag = ""
        TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
        TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.CVE_TIPO_UNI, ISNULL(U.CVE_TANQUE1,'') AS C_TANQUE1, ISNULL(U.CVE_TANQUE2,'') AS C_TANQUE2,
                ISNULL(U.CVE_DOLLY,'') AS C_DOLLY, U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12,
                ISNULL(U.NUM_LLANTAS,0) AS N_LLANTAS, ISNULL(U.LLANTAS_REF,'') AS LL_REF, U.CVE_MARCA_LLA, U.CVE_MODELO_LLA, U.CVE_MED, U.CVE_TIPO_LLA
                FROM GCUNIDADES U
                LEFT JOIN GCOBS OB ON OB.CVE_OBS = U.CVE_OBSCOMP
                WHERE CLAVEMONTE = '" & TCVE_UNI.Text & "' AND ISNULL(STATUS, 'A') = 'A'
                ORDER BY U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    TCVE_UNI.Tag = dr("CLAVE")
                    Tipo_Uni = dr("CVE_TIPO_UNI")
                    L2.Tag = Tipo_Uni
                Catch ex As Exception
                    Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                SEL_UNI = "0"

                Select Case Tipo_Uni
                    Case "1"    'TRACTOR    1
                        SEL_UNI = "1"
                        Et9.Visible = True : TLL9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True
                        Et11.Visible = False : TLL11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False

                        TMARCA9.Visible = True : TMODELO9.Visible = True : TTIPO_LLANTA9.Visible = True : TNUEVA_RENOVADA9.Visible = True : TFECHA_MONTAJE9.Visible = True : TCOSTO_LLANTA9.Visible = True
                        TKMS_MONTAR9.Visible = True : TPROFUNDIDA_ORIGINAL9.Visible = True : TKMS_DESMONTAR9.Visible = True : TKM_RECORRIDOS9.Visible = True : TPROFUNDIDAD_ACTUAL19.Visible = True
                        TPOSICION9.Visible = True : TDESGASTE9.Visible = True : TObs9.Visible = True

                        TMARCA10.Visible = True : TMODELO10.Visible = True : TTIPO_LLANTA10.Visible = True : TNUEVA_RENOVADA10.Visible = True : TFECHA_MONTAJE10.Visible = True : TCOSTO_LLANTA10.Visible = True
                        TKMS_MONTAR10.Visible = True : TPROFUNDIDA_ORIGINAL10.Visible = True : TKMS_DESMONTAR10.Visible = True : TKM_RECORRIDOS10.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True
                        TPOSICION10.Visible = True : TDESGASTE10.Visible = True : TObs10.Visible = True

                        TMARCA11.Visible = False : TMODELO11.Visible = False : TTIPO_LLANTA11.Visible = False : TNUEVA_RENOVADA11.Visible = False : TFECHA_MONTAJE11.Visible = False : TCOSTO_LLANTA11.Visible = False
                        TKMS_MONTAR11.Visible = False : TPROFUNDIDA_ORIGINAL11.Visible = False : TKMS_DESMONTAR11.Visible = False : TKM_RECORRIDOS11.Visible = False : TPROFUNDIDAD_ACTUAL111.Visible = False
                        TPOSICION11.Visible = False : TDESGASTE11.Visible = False : TObs11.Visible = False

                        TMARCA12.Visible = False : TMODELO12.Visible = False : TTIPO_LLANTA12.Visible = False : TNUEVA_RENOVADA12.Visible = False : TFECHA_MONTAJE12.Visible = False : TCOSTO_LLANTA12.Visible = False
                        TKMS_MONTAR12.Visible = False : TPROFUNDIDA_ORIGINAL12.Visible = False : TKMS_DESMONTAR12.Visible = False : TKM_RECORRIDOS12.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPOSICION12.Visible = False : TDESGASTE12.Visible = False : TObs12.Visible = False

                        TPROFUNDIDAD_ACTUAL19.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True : TPROFUNDIDAD_ACTUAL111.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPROFUNDIDAD_ACTUAL29.Visible = True : TPROFUNDIDAD_ACTUAL210.Visible = True : TPROFUNDIDAD_ACTUAL211.Visible = False : TPROFUNDIDAD_ACTUAL212.Visible = False
                        TPROFUNDIDAD_ACTUAL39.Visible = True : TPROFUNDIDAD_ACTUAL310.Visible = True : TPROFUNDIDAD_ACTUAL311.Visible = False : TPROFUNDIDAD_ACTUAL312.Visible = False
                        TPROFUNDIDAD_ACTUAL49.Visible = True : TPROFUNDIDAD_ACTUAL410.Visible = True : TPROFUNDIDAD_ACTUAL411.Visible = False : TPROFUNDIDAD_ACTUAL412.Visible = False
                        TPRESION_ACTUAL111.Visible = False : TPRESION_ACTUAL112.Visible = False



                    Case "2"    'TANQUE1  1  2
                        Et9.Visible = True : TLL9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True
                        Et11.Visible = True : TLL11.Visible = True
                        Et12.Visible = True : TLL12.Visible = True

                        TMARCA9.Visible = True : TMODELO9.Visible = True : TTIPO_LLANTA9.Visible = True : TNUEVA_RENOVADA9.Visible = True : TFECHA_MONTAJE9.Visible = True : TCOSTO_LLANTA9.Visible = True
                        TKMS_MONTAR9.Visible = True : TPROFUNDIDA_ORIGINAL9.Visible = True : TKMS_DESMONTAR9.Visible = True : TKM_RECORRIDOS9.Visible = True : TPROFUNDIDAD_ACTUAL19.Visible = True
                        TPOSICION9.Visible = True : TDESGASTE9.Visible = True : TObs9.Visible = True

                        TMARCA10.Visible = True : TMODELO10.Visible = True : TTIPO_LLANTA10.Visible = True : TNUEVA_RENOVADA10.Visible = True : TFECHA_MONTAJE10.Visible = True : TCOSTO_LLANTA10.Visible = True
                        TKMS_MONTAR10.Visible = True : TPROFUNDIDA_ORIGINAL10.Visible = True : TKMS_DESMONTAR10.Visible = True : TKM_RECORRIDOS10.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True
                        TPOSICION10.Visible = True : TDESGASTE10.Visible = True : TObs10.Visible = True

                        TMARCA11.Visible = True : TMODELO11.Visible = True : TTIPO_LLANTA11.Visible = True : TNUEVA_RENOVADA11.Visible = True : TFECHA_MONTAJE11.Visible = True : TCOSTO_LLANTA11.Visible = True
                        TKMS_MONTAR11.Visible = True : TPROFUNDIDA_ORIGINAL11.Visible = True : TKMS_DESMONTAR11.Visible = True : TKM_RECORRIDOS11.Visible = True : TPROFUNDIDAD_ACTUAL111.Visible = True
                        TPOSICION11.Visible = True : TDESGASTE11.Visible = True : TObs11.Visible = True

                        TMARCA12.Visible = True : TMODELO12.Visible = True : TTIPO_LLANTA12.Visible = True : TNUEVA_RENOVADA12.Visible = True : TFECHA_MONTAJE12.Visible = True : TCOSTO_LLANTA12.Visible = True
                        TKMS_MONTAR12.Visible = True : TPROFUNDIDA_ORIGINAL12.Visible = True : TKMS_DESMONTAR12.Visible = True : TKM_RECORRIDOS12.Visible = True : TPROFUNDIDAD_ACTUAL112.Visible = True
                        TPOSICION12.Visible = True : TDESGASTE12.Visible = True : TObs12.Visible = True

                        TPROFUNDIDAD_ACTUAL19.Visible = True : TPROFUNDIDAD_ACTUAL110.Visible = True : TPROFUNDIDAD_ACTUAL111.Visible = True : TPROFUNDIDAD_ACTUAL112.Visible = True
                        TPROFUNDIDAD_ACTUAL29.Visible = True : TPROFUNDIDAD_ACTUAL210.Visible = True : TPROFUNDIDAD_ACTUAL211.Visible = True : TPROFUNDIDAD_ACTUAL212.Visible = True
                        TPROFUNDIDAD_ACTUAL39.Visible = True : TPROFUNDIDAD_ACTUAL310.Visible = True : TPROFUNDIDAD_ACTUAL311.Visible = True : TPROFUNDIDAD_ACTUAL312.Visible = True
                        TPROFUNDIDAD_ACTUAL49.Visible = True : TPROFUNDIDAD_ACTUAL410.Visible = True : TPROFUNDIDAD_ACTUAL411.Visible = True : TPROFUNDIDAD_ACTUAL412.Visible = True
                        TPRESION_ACTUAL111.Visible = True : TPRESION_ACTUAL112.Visible = True

                    Case "3"    'DOLLY      3
                        SEL_UNI = "4"
                        Et9.Visible = False : TLL9.Visible = False
                        Et10.Visible = False : TLL10.Visible = False
                        Et11.Visible = False : TLL11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False

                        TMARCA9.Visible = False : TMODELO9.Visible = False : TTIPO_LLANTA9.Visible = False : TNUEVA_RENOVADA9.Visible = False : TFECHA_MONTAJE9.Visible = False : TCOSTO_LLANTA9.Visible = False
                        TKMS_MONTAR9.Visible = False : TPROFUNDIDA_ORIGINAL9.Visible = False : TKMS_DESMONTAR9.Visible = False : TKM_RECORRIDOS9.Visible = False : TPROFUNDIDAD_ACTUAL19.Visible = False
                        TPOSICION9.Visible = False : TDESGASTE9.Visible = False : TObs9.Visible = False

                        TMARCA10.Visible = False : TMODELO10.Visible = False : TTIPO_LLANTA10.Visible = False : TNUEVA_RENOVADA10.Visible = False : TFECHA_MONTAJE10.Visible = False : TCOSTO_LLANTA10.Visible = False
                        TKMS_MONTAR10.Visible = False : TPROFUNDIDA_ORIGINAL10.Visible = False : TKMS_DESMONTAR10.Visible = False : TKM_RECORRIDOS10.Visible = False : TPROFUNDIDAD_ACTUAL110.Visible = False
                        TPOSICION10.Visible = False : TDESGASTE10.Visible = False : TObs10.Visible = False

                        TMARCA11.Visible = False : TMODELO11.Visible = False : TTIPO_LLANTA11.Visible = False : TNUEVA_RENOVADA11.Visible = False : TFECHA_MONTAJE11.Visible = False : TCOSTO_LLANTA11.Visible = False
                        TKMS_MONTAR11.Visible = False : TPROFUNDIDA_ORIGINAL11.Visible = False : TKMS_DESMONTAR11.Visible = False : TKM_RECORRIDOS11.Visible = False : TPROFUNDIDAD_ACTUAL111.Visible = False
                        TPOSICION11.Visible = False : TDESGASTE11.Visible = False : TObs11.Visible = False

                        TMARCA12.Visible = False : TMODELO12.Visible = False : TTIPO_LLANTA12.Visible = False : TNUEVA_RENOVADA12.Visible = False : TFECHA_MONTAJE12.Visible = False : TCOSTO_LLANTA12.Visible = False
                        TKMS_MONTAR12.Visible = False : TPROFUNDIDA_ORIGINAL12.Visible = False : TKMS_DESMONTAR12.Visible = False : TKM_RECORRIDOS12.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPOSICION12.Visible = False : TDESGASTE12.Visible = False : TObs12.Visible = False

                        TPROFUNDIDAD_ACTUAL19.Visible = False : TPROFUNDIDAD_ACTUAL110.Visible = False : TPROFUNDIDAD_ACTUAL111.Visible = False : TPROFUNDIDAD_ACTUAL112.Visible = False
                        TPROFUNDIDAD_ACTUAL29.Visible = False : TPROFUNDIDAD_ACTUAL210.Visible = False : TPROFUNDIDAD_ACTUAL211.Visible = False : TPROFUNDIDAD_ACTUAL212.Visible = False
                        TPROFUNDIDAD_ACTUAL39.Visible = False : TPROFUNDIDAD_ACTUAL310.Visible = False : TPROFUNDIDAD_ACTUAL311.Visible = False : TPROFUNDIDAD_ACTUAL312.Visible = False
                        TPROFUNDIDAD_ACTUAL49.Visible = False : TPROFUNDIDAD_ACTUAL410.Visible = False : TPROFUNDIDAD_ACTUAL411.Visible = False : TPROFUNDIDAD_ACTUAL412.Visible = False
                        TPRESION_ACTUAL19.Visible = False
                        TPRESION_ACTUAL110.Visible = False
                        TPRESION_ACTUAL111.Visible = False
                        TPRESION_ACTUAL112.Visible = False
                End Select

                Try
                    'NUM_ECONOMICO
                    'TLL1.Text = BUSCA_NUM_ECONOMICO(dr("CHLL1").ToString)
                    If TLL1.Text = "0" Then TLL1.Text = ""
                    If TLL1.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL1.Tag = TLL1.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(1, TLL1.Text)
                    Else
                        'LIMPIAR_PARTIDA(1)
                    End If
                    'TLL2.Text = BUSCA_NUM_ECONOMICO(dr("CHLL2").ToString)
                    If TLL2.Text = "0" Then TLL2.Text = ""
                    If TLL2.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL2.Tag = TLL2.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(2, TLL2.Text)
                    End If
                    'TLL3.Text = BUSCA_NUM_ECONOMICO(dr("CHLL3").ToString)
                    If TLL3.Text = "0" Then TLL3.Text = ""
                    If TLL3.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL3.Tag = TLL3.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(3, TLL3.Text)
                    End If
                    'TLL4.Text = BUSCA_NUM_ECONOMICO(dr("CHLL4").ToString)
                    If TLL4.Text = "0" Then TLL4.Text = ""
                    If TLL4.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL4.Tag = TLL4.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(4, TLL4.Text)
                    End If
                    'TLL5.Text = BUSCA_NUM_ECONOMICO(dr("CHLL5").ToString)
                    If TLL5.Text = "0" Then TLL5.Text = ""
                    If TLL5.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL5.Tag = TLL5.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(5, TLL5.Text)
                    End If
                    'TLL6.Text = BUSCA_NUM_ECONOMICO(dr("CHLL6").ToString)
                    If TLL6.Text = "0" Then TLL6.Text = ""
                    If TLL6.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL6.Tag = TLL6.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(6, TLL6.Text)
                    End If
                    'TLL7.Text = BUSCA_NUM_ECONOMICO(dr("CHLL7").ToString)
                    If TLL7.Text = "0" Then TLL7.Text = ""
                    If TLL7.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL7.Tag = TLL7.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(7, TLL7.Text)
                    End If
                    'TLL8.Text = BUSCA_NUM_ECONOMICO(dr("CHLL8").ToString)
                    If TLL8.Text = "0" Then TLL8.Text = ""
                    If TLL8.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL8.Tag = TLL8.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(8, TLL8.Text)
                    End If
                    'TLL9.Text = BUSCA_NUM_ECONOMICO(dr("CHLL9").ToString)
                    If TLL9.Text = "0" Then TLL9.Text = ""
                    If TLL9.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL9.Tag = TLL9.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(9, TLL9.Text)
                    End If
                    'TLL10.Text = BUSCA_NUM_ECONOMICO(dr("CHLL10").ToString)
                    If TLL10.Text = "0" Then TLL10.Text = ""
                    If TLL10.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL10.Tag = TLL10.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(10, TLL10.Text)
                    End If
                    'TLL11'.Text = BUSCA_NUM_ECONOMICO(dr("CHLL11").ToString)
                    If TLL11.Text = "0" Then TLL11.Text = ""
                    If TLL11.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL11.Tag = TLL11.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(11, TLL11.Text)
                    End If
                    'TLL12.Text = BUSCA_NUM_ECONOMICO(dr("CHLL12").ToString)
                    If TLL12.Text = "0" Then TLL12.Text = ""
                    If TLL12.Text.Trim.Length > 0 Then
                        'NUM_ECONOMICO
                        'TLL12.Tag = TLL12.Text
                        'CVE_LLANTA
                        'DESPLEGA_DATOS_LLANTA(12, TLL12.Text)
                    End If

                    Try
                        Dim DESCR As String
                        If TLL1.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL1.Text)
                        End If
                        If TLL2.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL2.Text)
                        End If
                        If TLL3.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL3.Text)
                        End If
                        If TLL4.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL4.Text)
                        End If
                        If TLL5.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL5.Text)
                        End If
                        If TLL6.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL6.Text)
                        End If
                        If TLL7.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL7.Text)
                        End If
                        If TLL10.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL10.Text)
                        End If
                        If TLL11.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL11.Text)
                        End If
                        If TLL12.Text.Trim.Length > 0 Then
                            DESCR = BUSCA_CAT("LlantasNE", TLL12.Text)
                        End If
                    Catch ex As Exception
                    End Try
                Catch ex As Exception
                    'MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dr.Close()


            TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
            TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""

            SQL = "SELECT L.CVE_LLANTA, ISNULL(L.NUM_ECONOMICO,'') AS NUM_ECO, ISNULL(L.POSICION,0) AS POS, M.DESCR AS DESCR_MARCA, 
                MO.DESCR AS DESCR_MODELO, ISNULL(L.TIPO_NUEVA_RENO,0) AS TIPO_NEW_REN, L.FECHA_MON, L.MARCA, L.MODELO, L.TIPO_LLANTA, 
                L.COSTO_LLANTA_MN, L.PROFUNDIDA_ORIGINAL, L.KMS_MONTAR, T.DESCR AS DESCR_TIPO
                FROM GCLLANTAS L
                LEFT JOIN GCMARCAS M ON M.CVE_MARCA = L.MARCA
                LEFT JOIN GCLLANTA_MODELO MO ON MO.CVE_MODELO = L.MODELO
                LEFT JOIN GCLLANTA_STATUS SL ON SL.CVE_STATUS = L.STATUS_LLANTA 
                LEFT JOIN GCLLANTA_TIPO T ON T.CVE_TIPO = L.TIPO_LLANTA
                WHERE UNIDAD = '" & TCVE_UNI.Text & "'
                ORDER BY L.FECHA_MON DESC"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            While dr.Read

                Select Case dr("POS")
                    Case 1
                        If TPOSICION1.Value = 0 Then
                            TLL1.Text = dr("NUM_ECO")
                            TLL1.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString

                            TMARCA1.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO1.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA1.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA1.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE1.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA1.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR1.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION1.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL1.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                        End If
                    Case 2
                        If TPOSICION2.Value = 0 Then
                            TLL2.Text = dr("NUM_ECO")
                            TLL2.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA2.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO2.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA1.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA2.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA2.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE2.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA2.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR2.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION2.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL2.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")
                        End If
                    Case 3
                        If TPOSICION3.Value = 0 Then
                            TLL3.Text = dr("NUM_ECO")
                            TLL3.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA3.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO3.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA3.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA3.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA3.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE3.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA3.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR3.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION3.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL3.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 4
                        If TPOSICION4.Value = 0 Then
                            TLL4.Text = dr("NUM_ECO")
                            TLL4.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA4.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO4.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA4.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA4.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE4.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA4.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR4.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION4.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL4.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 5
                        If TPOSICION5.Value = 0 Then
                            TLL5.Text = dr("NUM_ECO")
                            TLL5.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA5.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO5.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA5.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA5.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA5.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE5.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA5.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR5.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION5.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL5.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 6
                        If TPOSICION6.Value = 0 Then
                            TLL6.Text = dr("NUM_ECO")
                            TLL6.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA6.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO6.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA6.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA6.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA6.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE6.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA6.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR6.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION6.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL6.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 7
                        If TPOSICION7.Value = 0 Then
                            TLL7.Text = dr("NUM_ECO")
                            TLL7.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA7.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO7.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA7.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA7.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA7.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE7.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA7.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR7.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION7.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL7.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 8
                        If TPOSICION8.Value = 0 Then
                            TLL8.Text = dr("NUM_ECO")
                            TLL8.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA8.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO8.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA8.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA8.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA8.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE8.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA8.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR8.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION8.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL8.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 9
                        If TPOSICION9.Value = 0 Then
                            TLL9.Text = dr("NUM_ECO")
                            TLL9.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA9.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO9.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA9.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA9.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA9.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE9.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA9.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR9.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION9.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL9.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 10
                        If TPOSICION10.Value = 0 Then
                            TLL10.Text = dr("NUM_ECO")
                            TLL10.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA10.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO10.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA10.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA10.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA10.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE10.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA10.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR10.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION10.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL10.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 11
                        If TPOSICION11.Value = 0 Then
                            TLL11.Text = dr("NUM_ECO")
                            TLL11.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA11.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO11.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA11.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA11.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA11.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE11.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA11.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR11.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION11.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL11.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                    Case 12
                        If TPOSICION12.Value = 0 Then
                            TLL12.Text = dr("NUM_ECO")
                            TLL12.Tag = dr.ReadNullAsEmptyString("NUM_ECO").ToString
                            TMARCA12.Text = dr.ReadNullAsEmptyString("DESCR_MARCA")
                            TMODELO12.Text = dr.ReadNullAsEmptyString("DESCR_MODELO")
                            TTIPO_LLANTA12.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                            If dr("TIPO_NEW_REN") = 0 Then
                                TNUEVA_RENOVADA12.Text = "Nueva"
                            Else
                                TNUEVA_RENOVADA12.Text = "Renovada"
                            End If
                            TFECHA_MONTAJE12.Text = dr("FECHA_MON")
                            TCOSTO_LLANTA12.Value = dr.ReadNullAsEmptyDecimal("COSTO_LLANTA_MN")
                            TKMS_MONTAR12.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                            TPOSICION12.Value = dr.ReadNullAsEmptyInteger("POS")
                            TPROFUNDIDA_ORIGINAL12.Value = dr.ReadNullAsEmptyDecimal("PROFUNDIDA_ORIGINAL")

                        End If
                End Select
            End While
            dr.Close()

        Catch ex As Exception
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR_PARTIDA(FNUM As Integer)
        Try
            Select Case FNUM
                Case 1
                Case 2

                Case 3

                Case 4

                Case 5

                Case 6

                Case 7

                Case 8

                Case 9

                Case 10

                Case 11

                Case 12

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Function BUSCA_NUM_ECONOMICO(fCVE_LLANTA As String) As String
        Dim NUM_ECO As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND CVE_LLANTA = '" & fCVE_LLANTA & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NUM_ECO = dr.ReadNullAsEmptyString("NUM_ECONOMICO")

                    End If
                End Using
            End Using
            Return NUM_ECO
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
            Return NUM_ECO
        End Try
    End Function
    Private Sub TPROFUNDIDAD_ACTUAL1_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL11.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL11.Text) Then
                TDESGASTE1.Value = TPROFUNDIDA_ORIGINAL1.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL11.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL2_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL12.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL12.Text) Then
                TDESGASTE2.Value = TPROFUNDIDA_ORIGINAL2.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL12.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL3_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL13.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL13.Text) Then
                TDESGASTE3.Value = TPROFUNDIDA_ORIGINAL3.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL13.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL4_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL14.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL14.Text) Then
                TDESGASTE4.Value = TPROFUNDIDA_ORIGINAL4.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL14.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL5_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL15.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL15.Text) Then
                TDESGASTE5.Value = TPROFUNDIDA_ORIGINAL5.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL15.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL6_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL16.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL16.Text) Then
                TDESGASTE6.Value = TPROFUNDIDA_ORIGINAL6.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL16.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL7_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL17.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL17.Text) Then
                TDESGASTE7.Value = TPROFUNDIDA_ORIGINAL7.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL17.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL8_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL18.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL18.Text) Then
                TDESGASTE8.Value = TPROFUNDIDA_ORIGINAL8.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL18.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL9_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL19.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL19.Text) Then
                TDESGASTE9.Value = TPROFUNDIDA_ORIGINAL9.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL19.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL10_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL110.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL110.Text) Then
                TDESGASTE10.Value = TPROFUNDIDA_ORIGINAL10.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL110.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL11_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL111.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL111.Text) Then
                TDESGASTE11.Value = TPROFUNDIDA_ORIGINAL11.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL111.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL12_TextChanged(sender As Object, e As EventArgs) Handles TPROFUNDIDAD_ACTUAL112.TextChanged
        Try
            If IsNumeric(TPROFUNDIDAD_ACTUAL112.Text) Then
                TDESGASTE12.Value = TPROFUNDIDA_ORIGINAL12.Value - Convert.ToDecimal(TPROFUNDIDAD_ACTUAL112.Text)
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '**********************************************************************************
    '**********************************************************************************
    '**********************************************************************************
    Private Sub TKMS_DESMONTAR1_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR1.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR1.Text) Then
                TKM_RECORRIDOS1.Value = Convert.ToDecimal(TKMS_DESMONTAR1.Text) - TKMS_MONTAR1.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR2_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR2.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR2.Text) Then
                TKM_RECORRIDOS2.Value = Convert.ToDecimal(TKMS_DESMONTAR2.Text) - TKMS_MONTAR2.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR3_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR3.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR3.Text) Then
                TKM_RECORRIDOS3.Value = Convert.ToDecimal(TKMS_DESMONTAR3.Text) - TKMS_MONTAR3.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR4_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR4.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR4.Text) Then
                TKM_RECORRIDOS4.Value = Convert.ToDecimal(TKMS_DESMONTAR4.Text) - TKMS_MONTAR4.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR5_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR5.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR5.Text) Then
                TKM_RECORRIDOS5.Value = Convert.ToDecimal(TKMS_DESMONTAR5.Text) - TKMS_MONTAR5.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR6_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR6.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR6.Text) Then
                TKM_RECORRIDOS6.Value = Convert.ToDecimal(TKMS_DESMONTAR6.Text) - TKMS_MONTAR6.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR7_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR7.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR7.Text) Then
                TKM_RECORRIDOS7.Value = Convert.ToDecimal(TKMS_DESMONTAR7.Text) - TKMS_MONTAR7.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR8_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR8.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR8.Text) Then
                TKM_RECORRIDOS8.Value = Convert.ToDecimal(TKMS_DESMONTAR8.Text) - TKMS_MONTAR8.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR9_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR9.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR9.Text) Then
                TKM_RECORRIDOS9.Value = Convert.ToDecimal(TKMS_DESMONTAR9.Text) - TKMS_MONTAR9.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR10_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR10.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR10.Text) Then
                TKM_RECORRIDOS10.Value = Convert.ToDecimal(TKMS_DESMONTAR10.Text) - TKMS_MONTAR10.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR11_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR11.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR11.Text) Then
                TKM_RECORRIDOS11.Value = Convert.ToDecimal(TKMS_DESMONTAR11.Text) - TKMS_MONTAR11.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TKMS_DESMONTAR12_TextChanged(sender As Object, e As EventArgs) Handles TKMS_DESMONTAR12.TextChanged
        Try
            If IsNumeric(TKMS_DESMONTAR12.Text) Then
                TKM_RECORRIDOS12.Value = Convert.ToDecimal(TKMS_DESMONTAR12.Text) - TKMS_MONTAR12.Value
            End If
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL1_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL11.KeyDown
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL12.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL2_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL12.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL11.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL13.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL3_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL13.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL12.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL14.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL4_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL14.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL13.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL15.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL5_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL15.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL14.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL16.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL6_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL16.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL15.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL17.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL7_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL17.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL16.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL18.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL8_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL18.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL17.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL19.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL9_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL19.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL18.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL110.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL10_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL110.KeyDown
        If e.KeyCode = Keys.Up Then
            TPROFUNDIDAD_ACTUAL19.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TPROFUNDIDAD_ACTUAL111.Focus()
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL11_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL111.KeyDown
        If TPROFUNDIDAD_ACTUAL110.Visible Then
            If e.KeyCode = Keys.Up Then
                TPROFUNDIDAD_ACTUAL110.Focus()
            End If
        End If
        If TPROFUNDIDAD_ACTUAL112.Visible Then
            If e.KeyCode = Keys.Down Then
                TPROFUNDIDAD_ACTUAL112.Focus()
            End If
        End If
    End Sub
    Private Sub TPROFUNDIDAD_ACTUAL12_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROFUNDIDAD_ACTUAL112.KeyDown
        If TPROFUNDIDAD_ACTUAL111.Visible Then
            If e.KeyCode = Keys.Up Then
                TPROFUNDIDAD_ACTUAL111.Focus()
            End If
        End If
    End Sub

    Private Sub TKMS_DESMONTAR1_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR1.KeyDown
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR2.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR2_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR2.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR1.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR3.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR3_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR3.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR2.Focus()
        End If

        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR4.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR4_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR4.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR3.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR5.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR5_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR5.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR4.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR6.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR6_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR6.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR5.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR7.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR7_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR7.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR6.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR8.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR8_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR8.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR7.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR9.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR9_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR9.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR8.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR10.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR10_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR10.KeyDown
        If e.KeyCode = Keys.Up Then
            TKMS_DESMONTAR9.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TKMS_DESMONTAR11.Focus()
        End If
    End Sub
    Private Sub TKMS_DESMONTAR11_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR11.KeyDown
        If TKMS_DESMONTAR10.Visible Then
            If e.KeyCode = Keys.Up Then
                TKMS_DESMONTAR10.Focus()
            End If
        End If
        If TKMS_DESMONTAR12.Visible Then
            If e.KeyCode = Keys.Down Then
                TKMS_DESMONTAR12.Focus()
            End If
        End If
    End Sub
    Private Sub TKMS_DESMONTAR12_KeyDown(sender As Object, e As KeyEventArgs) Handles TKMS_DESMONTAR12.KeyDown
        If TKMS_DESMONTAR11.Visible Then
            If e.KeyCode = Keys.Up Then
                TKMS_DESMONTAR11.Focus()
            End If
        End If
    End Sub

    Private Sub TKM_ACTUAL1_Validated(sender As Object, e As EventArgs) Handles TKM_ACTUAL1.Validated
        Try
            TKM_ACTUAL2.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL3.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL4.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL5.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL6.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL7.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL8.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL9.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL10.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL11.Value = TKM_ACTUAL1.Value
            TKM_ACTUAL12.Value = TKM_ACTUAL1.Value
        Catch ex As Exception

        End Try
    End Sub
End Class