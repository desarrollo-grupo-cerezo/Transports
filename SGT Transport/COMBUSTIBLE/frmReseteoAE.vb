Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid

Public Class FrmReseteoAE
    Private NewRecord As Boolean = False
    Private CALCULO_POSITIVO As Boolean = False
    Private EVENTO As Integer = 0
    Private EVENTO_LTS As Integer = 0
    Private TABULADOR As Integer = 0
    Private ENTRA_EVENTO1 As Boolean = True
    Private ENTRA_EVENTO2 As Boolean = True
    Private RUTA_DOC As String = ""
    Private DESCUENTO As Integer = 0
    Private HORAS_GEN1 As Integer = 0
    Private HORAS_GEN2 As Integer = 0
    Private HORAS_USO1 As Integer = 0
    Private HORAS_GEN3 As Integer = 0
    Private HORAS_GEN4 As Integer = 0
    Private HORAS_USO2 As Integer = 0

    Private NUMGEN1 As Integer = 0
    Private NUMGEN2 As Integer = 0
    Private LTSDESCGEN As Integer = 0

    Private LTS_GEN2 As Integer = 0
    Private NUM_VIAJES_FULL As Integer = 0
    Private NUM_VIAJES_SENC As Integer = 0
    Private RPM_MAXIMA As Integer = 0

    Private CALIFICACION As Integer = 0
    Private VELOCIDADMAXIMA As Integer = 0
    Private TIEMPOMARCHAINERCIA As Integer = 0
    Private LITROSDESCONTAR As Integer = 0
    Private PRECIOXLITRO As Integer = 0
    Private DESCXLITRO As Integer = 0
    Private LTSAUTORIZ As Integer = 0
    Private LTSUREA As Integer = 0
    Private LTSUREA_REAL As Integer = 0
    Private CARGOXPUNTOMUERTO As Integer = 0
    Private NO_VIAJE As Integer = 0
    Private NO_LIQUI As Integer = 0
    Private PRECIO_X_LTS As Decimal = 0
    Private No_CALCULA_EVENTO As Boolean = False
    Private TIPO_TAB As Integer = 0
    Private BONO_ESPECIAL As Boolean = False
    Private BONO_ESPECIAL_DESCR As String = ""
    Private Tipo_movs As String

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmReseteoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        ProcessControls(Me)

    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try
            '255, 192, 0 GOLD
            '176, 240, 0
            sender.BackColor = Color.FromArgb(176, 240, 0)
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            TCAL_FAC_CAR_EVA.BackColor = Color.PowderBlue
            TCAL_RAL_EVA.BackColor = Color.PowderBlue
            TCALIF_VEL_MX.BackColor = Color.PowderBlue
            TCALIF_RPM.BackColor = Color.PowderBlue

            'AssignValidation(Me.TMUNICIPIO, ValidationType.Only_Numbers)
        Catch ex As Exception
        End Try

        Me.Width = Screen.PrimaryScreen.Bounds.Width - 25

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        CSTooltip.SetToolTip(BarGrabar, "F3 - Grabar")
        CSTooltip.SetToolTip(MnuSalir, "F5 - Salir")

        Me.CenterToScreen()
        Me.KeyPreview = True

        Try
            For Each tb As TextBox In Split1.Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next
            For Each tb As TextBox In GpoCamposAdic.Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next
            For Each tb As TextBox In GroupBox3.Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next
            For Each tb As TextBox In GroupBox2.Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next
            For Each tb As TextBox In GroupBox1.Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        BtnLitrosEntrada.FlatStyle = FlatStyle.Flat
        BtnLitrosEntrada.FlatAppearance.BorderSize = 0
        BtnLitrosSalida.FlatStyle = FlatStyle.Flat
        BtnLitrosSalida.FlatAppearance.BorderSize = 0
        BtnLimpiarLtsEnt.FlatStyle = FlatStyle.Flat
        BtnLimpiarLtsEnt.FlatAppearance.BorderSize = 0
        BtnLimpiarLtsSal.FlatStyle = FlatStyle.Flat
        BtnLimpiarLtsSal.FlatAppearance.BorderSize = 0

        BtnOper.FlatStyle = FlatStyle.Flat
        BtnOper.FlatAppearance.BorderSize = 0
        BtnUni.FlatStyle = FlatStyle.Flat
        BtnUni.FlatAppearance.BorderSize = 0
        BtnMotor.FlatStyle = FlatStyle.Flat
        BtnMotor.FlatAppearance.BorderSize = 0

        BtnAlta.FlatStyle = FlatStyle.Flat
        BtnAlta.FlatAppearance.BorderSize = 0
        BtnBaja.FlatStyle = FlatStyle.Flat
        BtnBaja.FlatAppearance.BorderSize = 0

        BtnEva.FlatStyle = FlatStyle.Flat
        BtnEva.FlatAppearance.BorderSize = 0
        BtnGen1.FlatStyle = FlatStyle.Flat
        BtnGen1.FlatAppearance.BorderSize = 0
        BtnGen2.FlatStyle = FlatStyle.Flat
        BtnGen2.FlatAppearance.BorderSize = 0

        BtnHelpnumViajes.FlatStyle = FlatStyle.Flat
        BtnHelpnumViajes.FlatAppearance.BorderSize = 0
        BtnBonosMotor.FlatStyle = FlatStyle.Flat
        BtnBonosMotor.FlatAppearance.BorderSize = 0
        BtnBonoFull.FlatStyle = FlatStyle.Flat
        BtnBonoFull.FlatAppearance.BorderSize = 0
        BtnDescXLts2.FlatStyle = FlatStyle.Flat
        BtnDescXLts2.FlatAppearance.BorderSize = 0


        TLTS_GENERADOR2.Value = 0
        TNO_VIAJES.Value = 0

        'tODOMETRO.MaxLength = 5
        TODOMETRO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TODOMETRO.EditFormat.CustomFormat = "###,###,##0.00"
        TODOMETRO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TODOMETRO.DisplayFormat.CustomFormat = "###,###,##0.00"

        THRS_TRABAJO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        THRS_TRABAJO.EditFormat.CustomFormat = "###,##0.00"
        THRS_TRABAJO.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        THRS_TRABAJO.DisplayFormat.CustomFormat = "###,##0.00"

        THRS_PTO_RALENTI.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        THRS_PTO_RALENTI.EditFormat.CustomFormat = "###,##0.00"
        THRS_PTO_RALENTI.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        THRS_PTO_RALENTI.DisplayFormat.CustomFormat = "###,##0.00"

        TLTS_PTO_RALENTI.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TLTS_PTO_RALENTI.EditFormat.CustomFormat = "###,##0.00"
        TLTS_PTO_RALENTI.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        TLTS_PTO_RALENTI.DisplayFormat.CustomFormat = "###,##0.00"

        TCVE_MOT.MaxLength = 120

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIPO_TAB,0) AS TI_TAB FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TIPO_TAB = dr("TI_TAB")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        'y obtiene PRECIO_X_LTS 
        OBTENER_RUTA_DOC()

        Try
            'CALCULA_EVENTO
            TLTS_ECM.Value = 0
            TPORC_TOLERANCIA.Value = 0
            TPORC_RALENTI.Value = 0

            TLTS_VALES.Value = 0.0

            TLTS_FORANEOS.Value = 0
            TLTS_TAB.Text = "0"
            TLTS_PTO_RALENTI.Value = 0
            LLts_desc_dif.Text = "0"
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            TCVE_RES.Text = ""
            F1.Value = Now
            TCVE_OPER.Text = ""
            LtOper.Text = ""
            TCVE_UNI.Text = ""
            LtUnidad.Text = ""
            TCVE_MOT.Text = ""
            LtPORC_TIEMPO_PTO_RALENTI.Text = ""
            LtPORC_LTS_PTO_RALENTI.Text = ""
            LtPORC_VAR_LTS_ECM_REAL.Text = ""
            LtPORC_VAR_LTS_TAB_REAL.Text = ""
            LtREND_REAL.Text = ""
            LtDIF_LTS_REAL_LTS_ECM.Text = ""
            LtDIF_LTS_REAL_LTS_TAB.Text = ""
            TCVE_UNI.Tag = ""

            TLTS_DESCONTAR.Value = 0

            TPRECIO_X_LTS.Value = 0 'PRECIO_X_LTS
            TPRECIO_X_LTS2.Value = 0 'PRECIO_X_LTS

            TPRECIO_X_LTS.Tag = PRECIO_X_LTS
            TPRECIO_X_LTS2.Tag = PRECIO_X_LTS

            TLTS_AUTORIZADOS.Value = 0

            TLTS_AUTORIZADOS2.Value = 0
            LtLTS_VALES2.Text = "0"
            TLTS_DESCONTAR2.Value = 0

            TPORC_TOL_EVENTO2.Tag = 0
            TLTS_AUTORIZADOS2.Tag = 0
            LtLTS_VALES2.Tag = 0
            TLTS_DESCONTAR2.Tag = 0

            LtDescXLitros2.Tag = 0

            TPORC_TOLERANCIA.Tag = 0
            LtLTS_ECM.Tag = 0
            TLTS_AUTORIZADOS.Tag = 0
            TLTS_DESCONTAR.Tag = 0

            TPORC_RALENTI.Tag = 0
            LtLTS_RALENTI.Tag = 0
            LtLTS_VALES.Tag = 0
            LtDescXLitros.Tag = 0

            TODOMETRO.Value = 0
            TKM_ECM.Value = 0
            TLTS_LLEGADA.Tag = "0"
            TLTS_SALIDA.Tag = "0"
            TFACTOR_CARGA.Tag = "0"
            TPORC_USO_RALENTI.Tag = "0"
            LtLTS_ECM.Text = "0"
            TBONO_RES.Tag = "0"
            TLTS_REAL.Text = 0
            TLTS_LLEGADA.Text = "0"
            TLTS_SALIDA.Text = "0"
            LtLTS_VALES.Text = "0"
            'LtLTS_FIS.Text = "0"
            'LtLTS_TAB.Text = "0"
            TFAC_CARGA.Value = 0
            THRS_TRABAJO.Value = 0
            THRS_PTO_RALENTI.Value = 0
            LtREND_ECM.Text = 0
            TPDF.Tag = RUTA_DOC
            Fg.Rows.Count = 1
            Try
                TDESCT.Value = 0
                TCALIF.Text = "0"
                TVELMAX.Value = 0
                TLITROS_UREA.Value = 0
                TCARGO_X_PUNTO_MUERTO.Value = 0
                THORAS_GEN3.Value = 0
                THORAS_GEN4.Value = 0
                THORAS_USO2.Value = 0

                LtLTS_VALES.Tag = "0"
                LtLTS_VALES2.Tag = "0"
                TLTSDESCGEN.Value = 0

                TNO_VIAJES_VACIO.Value = 0

            Catch ex As Exception
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If PASS_GRUPOCE.ToUpper = "BUS" Then
                Fg.Cols(11).Width = 90
                Fg.Cols(12).Width = 90
                Fg.Cols(16).Width = 90
                Fg.Cols(18).Width = 90
            Else
                Fg.Cols(11).Width = 0
                Fg.Cols(12).Width = 0
                Fg.Cols(16).Width = 0
            End If


            L14.Visible = False
            L15.Visible = False
            L16.Visible = False
            THORAS_GEN3.Visible = False
            THORAS_GEN4.Visible = False
            THORAS_USO2.Visible = False

            TRPM_MAX.Value = 0


        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'ASIGNACION DE LOS DEFAULT
        Select Case TIPO_TAB
            Case 0
                BarNuevoVale.Visible = False : Fg.Cols(2).Visible = False : Fg.Cols(3).Visible = False : Fg.Cols(4).Visible = False

                L1.Text = "Horas generador 1"
                L4.Text = "Horas generador 2"
                L11.Text = "Horas uso"
                L15.Visible = True
                L16.Visible = True
                THORAS_GEN4.Visible = True

                L10.Visible = True
                LtsGen2.Visible = True
                TLTS_UREA_REAL.Visible = True
                TLTS_GENERADOR2.Visible = True
                Try
                    If PASS_GRUPOCE.ToUpper = "BUS" Then
                        For k = 1 To Fg.Cols.Count - 1
                            Fg(0, k) = Fg(0, k) & " " & k
                        Next
                    End If
                    If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                        'TOOLTIP_EN_CONTROLES(Me.Controls, CSTooltip)
                        TOOLTIP_EN_CONTROLES(Split1, CSTooltip)
                        TOOLTIP_EN_CONTROLES(Split2, CSTooltip)
                        TOOLTIP_EN_CONTROLES(GpoCamposAdic, CSTooltip)
                        TOOLTIP_EN_CONTROLES(GroupBox2, CSTooltip)
                        TOOLTIP_EN_CONTROLES(GroupBox1, CSTooltip)
                        TOOLTIP_EN_CONTROLES(GroupBox3, CSTooltip)

                    End If
                    Fg.Cols(0).Width = 60
                Catch ex As Exception
                End Try
                TCARGO_X_PUNTO_MUERTO.Enabled = False
                THORAS_USO2.Visible = True
                THORAS_USO2.Enabled = False
            Case 1
                'VIKINGOS
                TLTS_VALES.Enabled = False

                BarNuevoVale.Visible = False
                L1.Text = "Horas generador 1"
                L4.Text = "Horas generador 2"
                L11.Text = "Horas uso"

                LL1.Text = ""
                L2.Text = "Litros generador"

                TCARGO_X_PUNTO_MUERTO.Enabled = False

                L14.Visible = True
                L15.Visible = True
                L16.Visible = True
                THORAS_GEN3.Visible = True
                THORAS_GEN4.Visible = True

                THORAS_USO2.Visible = True
                THORAS_USO2.Enabled = False
                TITULOS()
                For j = 1 To Fg.Cols.Count - 1
                    Fg.Cols(j).Visible = True
                    Fg.Cols(j).Width = 90
                Next
                LtsGen2.Visible = True
                TLTS_GENERADOR2.Visible = True

                Fg.Cols(1).Visible = False
                Fg.Cols(4).Visible = False
                Fg.Cols(9).Visible = False
                Fg.Cols(11).Visible = False
                Fg.Cols(13).Visible = False

                If PASS_GRUPOCE = "BUS" Then
                    Fg.Cols(16).Visible = True
                    Fg.Cols(17).Visible = True
                    Fg.Cols(18).Visible = True
                    Fg.Cols(19).Visible = True
                Else
                    Fg.Cols(16).Visible = False
                    Fg.Cols(17).Visible = False
                    Fg.Cols(18).Visible = False
                    Fg.Cols(19).Visible = False
                End If
            Case 2
                Lt11.Text = "Lts. a descontar/bono"
                Lt12.Text = "Descuento por Lt/Bono"
                L2.Text = "Calificación"
                BarNuevoVale.Visible = False
                TITULOS_FLORES()
        End Select
        If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = Fg(0, k) & " " & k
            Next
        End If

        DERECHOS()

        Tipo_movs = Var1

        If Var1 = "Nuevo" Then
            Try
                NewRecord = True
                TCVE_RES.Text = GET_MAX("GCRESETEO", "CVE_RES")
                TCVE_RES.Enabled = False

                ChEvento2.Checked = True

                OBTENER_ULTIMO_PORC_RALENTI()

                TCVE_OPER.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim S1 As Single, S2 As Single
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                If Var2.Trim.Length = 0 Then
                    Var2 = "0"
                End If

                SQL = "SELECT R.CVE_RES, R.STATUS, R.FECHA, R.CVE_OPER, R.CVE_UNI, R.CVE_MOT, R.ODOMETRO, R.KM_ECM, R.LTS_ECM, 
                    R.LTS_REAL, R.LTS_TAB, R.FAC_CARGA, R.HRS_TRABAJO, R.HRS_PTO_RALENTI, R.LTS_PTO_RALENTI, R.RPM_MAX,
                    R.PORC_TIEMPO_PTO_RALENTI, R.PORC_LTS_PTO_RALENTI, R.REND_ECM, R.PORC_VAR_LTS_ECM_REAL, R.PORC_VAR_LTS_TAB_REAL, 
                    R.REND_REAL, R.DIF_LTS_REAL_LTS_ECM, R.DIF_LTS_REAL_LTS_TAB, R.LTS_SALIDA, R.LTS_VALES, R.LTS_LLEGADA, R.PDF, R.ESTADO, 
                    R.DESCT, R.CALIF, R.VELMAX, R.TIEMPO_MARCH_INERCIA, R.KMS_TAB, R.CALIF_FACTOR_CARGA, R.CALIF_RALENTI, R.CALIF_GLOBAL,
                    R.CAL_FAC_CAR_EVA, R.CAL_RAL_EVA, R.CAL_GLO_EVA, R.LTS_DESCONTAR, R.PRECIO_X_LTS, R.LTS_AUTORIZADOS, R.LITROS_UREA, 
                    R.CARGO_X_PUNTO_MUERTO, R.FACTOR_CARGA, R.PORC_USO_RALENTI, R.LTS_UREA_REAL, R.PORC_TOLERANCIA, R.PORC_RALENTI, R.NO_VIAJE, 
                    R.NO_LIQUI, R.BONO_RES, R.LTS_FORANEOS, R.CVE_EVE, R.CALIF_VEL_MAX, R.NO_DE_VIAJES, R.NO_DE_VIAJES_VACIO, R.BONO_RES_VACIO, 
                    R.LTS_AUTORIZADOS2, R.LTS_VALES2, R.LTS_DESCONTAR2, R.PRECIO_X_LTS2, R.EVENTO, R.EVENTO_LTS, R.PORC_TOL_EVENTO2, 
                    R.DESCXLITROS2, ISNULL(R.TABULADOR,0) AS TABULA, ISNULL(R.HORAS_GEN3,0) AS H_GEN3, ISNULL(R.HORAS_GEN4,0) AS H_GEN4, 
                    ISNULL(R.HORAS_USO2,0) AS H_USO2, ISNULL(R.LTS_GENERADOR2,0) AS LTS_GEN2, R.LTSDESCGEN, ISNULL(R.CVE_EVA,0) AS C_EVA, 
                    ISNULL(C.DESCR,'') AS DES, R.NUMGEN1, R.NUMGEN2, ISNULL(G1.DESCR,'') AS DES_GEN1, ISNULL(G2.DESCR,'') AS DES_GEN2
                    FROM GCRESETEO R 
                    LEFT JOIN GCCATEVA C ON C.CVE_EVA = R.CVE_EVA
                    LEFT JOIN GCHORAS_GEN G1 ON G1.CVE_GEN = R.NUMGEN1
                    LEFT JOIN GCHORAS_GEN G2 ON G2.CVE_GEN = R.NUMGEN2
                    WHERE CVE_RES = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Try
                        'tCVE_EVE.Text = dr.ReadNullAsEmptyInteger("CVE_EVE")
                        'CVE_EVE_G = tCVE_EVE.Text
                        TNO_VIAJE.Text = dr.ReadNullAsEmptyString("NO_VIAJE")
                        TNO_LIQUI.Text = dr.ReadNullAsEmptyString("NO_LIQUI")
                        TCALIF_VEL_MAX.Text = dr.ReadNullAsEmptyDecimal("CALIF_VEL_MAX")

                        TABULADOR = dr("TABULA")
                        TLTS_GENERADOR2.Value = dr("LTS_GEN2")

                        TLTSDESCGEN.Value = dr.ReadNullAsEmptyDecimal("LTSDESCGEN")

                        TCVE_EVA.Text = dr("C_EVA")
                        LtEva.Text = BUSCA_CAT("GCCATEVA", TCVE_EVA.Text)

                        If IsNumeric(TCVE_EVA.Text) Then
                            DESPLEGAR_EVA(Convert.ToInt32(TCVE_EVA.Text))
                        End If

                        TNUMGEN1.Text = dr.ReadNullAsEmptyString("NUMGEN1")
                        TNUMGEN2.Text = dr.ReadNullAsEmptyString("NUMGEN2")
                        LtGen1.Text = dr("DES_GEN1")
                        LtGen2.Text = dr("DES_GEN2")

                        TRPM_MAX.Value = dr.ReadNullAsEmptyDecimal("RPM_MAX")

                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TLTS_UREA_REAL.Value = dr.ReadNullAsEmptyDecimal("LTS_UREA_REAL")
                    Catch ex As Exception
                    End Try
                    Try
                        TDESCT.Value = dr.ReadNullAsEmptyDecimal("DESCT")
                    Catch ex As Exception
                    End Try
                    Try
                        TCALIF.Text = dr.ReadNullAsEmptyDecimal("CALIF")
                    Catch ex As Exception
                    End Try
                    Try
                        TVELMAX.Value = dr.ReadNullAsEmptyDecimal("VELMAX")
                    Catch ex As Exception
                    End Try
                    Try
                        TTIEMPO_MARCH_INERCIA.Text = dr.ReadNullAsEmptyDecimal("TIEMPO_MARCH_INERCIA")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TLITROS_UREA.Value = dr.ReadNullAsEmptyDecimal("LITROS_UREA")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TCARGO_X_PUNTO_MUERTO.Value = dr.ReadNullAsEmptyDecimal("CARGO_X_PUNTO_MUERTO")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        THORAS_GEN3.Value = dr.ReadNullAsEmptyDecimal("H_GEN3")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        THORAS_GEN4.Value = dr.ReadNullAsEmptyDecimal("H_GEN4")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        THORAS_USO2.Value = dr.ReadNullAsEmptyDecimal("H_USO2")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TFACTOR_CARGA.Text = Format(dr.ReadNullAsEmptyDecimal("FACTOR_CARGA"), "###,##0.00")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TPORC_USO_RALENTI.Text = dr.ReadNullAsEmptyDecimal("PORC_USO_RALENTI")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        TLTS_PTO_RALENTI.Value = dr.ReadNullAsEmptyDecimal("LTS_PTO_RALENTI").ToString
                        TLTS_TAB.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_TAB"), "###,###,##0.00")

                        LtKMS_TAB.Text = Format(dr.ReadNullAsEmptyDecimal("KMS_TAB"), "###,###,##0.00")
                        S1 = dr.ReadNullAsEmptyDecimal("KMS_TAB")
                        S2 = dr.ReadNullAsEmptyDecimal("LTS_TAB")
                        If S2 > 0 Then
                            LtREND_TAB.Text = Format(S1 / S2, "###,###,##0.00")
                        End If

                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If IsNumeric(dr.ReadNullAsEmptyString("CVE_MOT").ToString) Then
                        TCVE_MOT.Text = dr.ReadNullAsEmptyString("CVE_MOT").ToString
                        If TCVE_MOT.Text.Trim <> "" And TCVE_MOT.Text <> "0" Then
                            LtMotor.Text = BUSCA_CAT("Motor", TCVE_MOT.Text)
                        Else
                            TCVE_MOT.Text = ""
                        End If
                    End If


                    TCVE_RES.Text = dr.ReadNullAsEmptyString("CVE_RES").ToString
                    F1.Value = dr.ReadNullAsEmptyString("FECHA").ToString
                    TCVE_OPER.Text = dr.ReadNullAsEmptyInteger("CVE_OPER").ToString
                    If TCVE_OPER.Text.Trim <> "" And TCVE_OPER.Text <> "0" Then
                        LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                    Else
                        TCVE_OPER.Text = ""
                    End If

                    TCVE_UNI.Text = dr.ReadNullAsEmptyString("CVE_UNI").ToString
                    LtUnidad.Text = BUSCA_CAT("Unidades", TCVE_UNI.Text)
                    TCVE_UNI.Tag = Var4
                    Try
                        TODOMETRO.Value = dr.ReadNullAsEmptyDecimal("ODOMETRO").ToString
                        'AQUI ESTA EL PROBLEMA
                        TKM_ECM.Value = dr.ReadNullAsEmptyDecimal("KM_ECM").ToString
                        TLTS_ECM.Value = dr.ReadNullAsEmptyDecimal("LTS_ECM").ToString
                        LtLTS_ECM.Text = Format(Convert.ToDecimal(TLTS_ECM.Value), "###,###,##0.00")
                        LtLTS_ECM.Tag = Format(Convert.ToDecimal(TLTS_ECM.Value), "###,###,##0.00")

                        LtPORC_LTS_PTO_RALENTI.Text = dr.ReadNullAsEmptyDecimal("PORC_LTS_PTO_RALENTI").ToString
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        '████████████████████████████████████████████████████████████████

                        LtLTS_VALES2.Text = dr.ReadNullAsEmptyDecimal("LTS_VALES2")
                        TPORC_TOL_EVENTO2.Value = dr.ReadNullAsEmptyDecimal("PORC_TOL_EVENTO2")
                        TLTS_AUTORIZADOS2.Value = dr.ReadNullAsEmptyDecimal("LTS_AUTORIZADOS2")

                        TLTS_DESCONTAR2.Value = dr.ReadNullAsEmptyDecimal("LTS_DESCONTAR2")
                        TPRECIO_X_LTS2.Value = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")

                        TPORC_TOL_EVENTO2.Tag = dr.ReadNullAsEmptyDecimal("PORC_TOL_EVENTO2")
                        TLTS_AUTORIZADOS2.Tag = dr.ReadNullAsEmptyDecimal("LTS_AUTORIZADOS2")
                        LtLTS_VALES2.Tag = dr.ReadNullAsEmptyDecimal("LTS_VALES2")
                        TLTS_DESCONTAR2.Tag = dr.ReadNullAsEmptyDecimal("LTS_DESCONTAR2")
                        TPRECIO_X_LTS2.Tag = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")


                        EVENTO = dr.ReadNullAsEmptyInteger("EVENTO")
                        EVENTO_LTS = dr.ReadNullAsEmptyInteger("EVENTO_LTS")
                        If EVENTO = 0 Then
                            'GroupBox2.Visible = True
                            ChEvento1.Checked = True
                        Else
                            'GroupBox2.Visible = False
                            ChEvento2.Checked = True

                            LtLitrosECMEvento2.Visible = True
                            TPORC_TOL_EVENTO2.Visible = True

                            If EVENTO_LTS = 0 Then
                                RadLTS_ECM.Checked = True
                            Else
                                RadLTS_TAB.Checked = True
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TCAL_FAC_CAR_EVA.Text = dr.ReadNullAsEmptyDecimal("CAL_FAC_CAR_EVA")
                        TCAL_RAL_EVA.Text = dr.ReadNullAsEmptyDecimal("CAL_RAL_EVA")
                        TCALIF_FACTOR_CARGA.Text = dr.ReadNullAsEmptyDecimal("CALIF_FACTOR_CARGA")
                        TCALIF_RALENTI.Text = dr.ReadNullAsEmptyDecimal("CALIF_RALENTI")
                        TCALIF_GLOBAL.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL")

                        Dim CAL11 As Decimal, CAL22 As Decimal, CAL33 As Decimal, CAL44 As Decimal
                        Try
                            If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                                CAL11 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                            Else
                                CAL11 = 0
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                                CAL22 = TCAL_RAL_EVA.Text.Replace(",", "")
                            Else
                                CAL22 = 0
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If IsNumeric(TCALIF_VEL_MX.Text.Replace(",", "")) Then
                                CAL33 = TCALIF_VEL_MX.Text.Replace(",", "")
                            Else
                                CAL33 = 0
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                                CAL44 = TCALIF_RPM.Text.Replace(",", "")
                            Else
                                CAL44 = 0
                            End If
                        Catch ex As Exception
                        End Try

                        Try
                            TCAL_GLO_EVA.Text = CAL11 + CAL22 + CAL33 + CAL44

                            BONO_ESPECIAL_DESCR = dr("DES")

                            If BONO_ESPECIAL_DESCR = "TABULADOR FULL" Or BONO_ESPECIAL_DESCR = "TABULADOR FULL/SENCILLO" Then
                                If IsNumeric(TCVE_EVA.Text) AndAlso Convert.ToInt16(TCVE_EVA.Text) > 0 Then
                                    If IsNumeric(TCAL_GLO_EVA.Text) AndAlso Convert.ToDecimal(TCAL_GLO_EVA.Text) > 0 Then
                                        TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                                    End If
                                Else
                                    TBONO_RES.Value = 0
                                End If
                                TBONO_RES.Tag = TBONO_RES.Value
                            End If

                            If Not BONO_ESPECIAL Then
                                If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                    TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    '████████████████████████████████████████████████████████████████

                    Try
                        TFAC_CARGA.Value = dr.ReadNullAsEmptyDecimal("FAC_CARGA").ToString
                        THRS_TRABAJO.Value = dr.ReadNullAsEmptyDecimal("HRS_TRABAJO").ToString
                        THRS_PTO_RALENTI.Value = dr.ReadNullAsEmptyDecimal("HRS_PTO_RALENTI").ToString
                    Catch ex As Exception
                        Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    Try
                        TLTS_VALES.Value = dr.ReadNullAsEmptyDecimal("LTS_VALES")
                        LtLTS_VALES.Text = Format(CDec(TLTS_VALES.Value), "###,###,##0.00")

                        TLTS_VALES.Tag = TLTS_VALES.Value
                        LtLTS_VALES.Tag = LtLTS_VALES.Text

                    Catch ex As Exception
                        Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TLTS_SALIDA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_SALIDA"), "###,###,##0.0")
                        TLTS_LLEGADA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_LLEGADA"), "###,###,##0.0")
                        TLTS_FORANEOS.Value = dr.ReadNullAsEmptyDecimal("LTS_FORANEOS")
                    Catch ex As Exception
                        Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TPDF.Text = dr.ReadNullAsEmptyString("PDF")
                        Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
                        Try
                            LRC1 = TLTS_SALIDA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try
                        Try
                            LRC2 = TLTS_VALES.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC3 = TLTS_FORANEOS.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try

                        TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
                        TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

                        'EVENTO 1
                        If ChEvento1.Checked Then
                            LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                            LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        End If

                        LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")

                    Catch ex As Exception
                    End Try

                    Select Case dr.ReadNullAsEmptyString("ESTADO")
                        Case "FINALIZADO"
                            LtEstado.Text = "ESTATUS:    FINALIZADO"
                        Case "EDICION"
                            LtEstado.Text = "ESTATUS:    EDICION"
                        Case "EN LIQUIDACION"
                            LtEstado.Text = "ESTATUS:    EN LIQUIDACION"
                    End Select

                    CAL2()
                    'CAL5()
                    CAL8()
                    CALC_CAL_GLO_EVA()

                    'LtsGen2.Visible = False
                    'TLTS_GENERADOR2.Visible = False

                    Select Case TIPO_TAB
                        Case 0
                            DESPLEGAR_PAR(TCVE_RES.Text)
                        Case 1
                            BarNuevoVale.Visible = True
                            DESPLEGAR_PAR_VIKINGOS(TCVE_RES.Text)
                        Case 2
                            If TABULADOR = 0 Then
                                DESPLEGAR_PAR(TCVE_RES.Text)
                            Else
                                DESPLEGAR_PAR_FLORES(TCVE_RES.Text)
                            End If
                    End Select

                    Try
                        Try
                            TPORC_RALENTI.Value = dr.ReadNullAsEmptyDecimal("PORC_RALENTI")
                            TPORC_RALENTI.Tag = dr.ReadNullAsEmptyDecimal("PORC_RALENTI")
                        Catch ex As Exception
                        End Try
                        TPORC_TOLERANCIA.Value = dr.ReadNullAsEmptyDecimal("PORC_TOLERANCIA")
                        TLTS_DESCONTAR.Value = dr.ReadNullAsEmptyDecimal("LTS_DESCONTAR")
                        TLTS_DESCONTAR.Tag = TLTS_DESCONTAR.Value

                        TPRECIO_X_LTS.Value = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")
                        If TPRECIO_X_LTS.Value = 0 Then
                            TPRECIO_X_LTS.Value = PRECIO_X_LTS
                        End If

                        If TPRECIO_X_LTS2.Value = 0 Then
                            TPRECIO_X_LTS2.Value = PRECIO_X_LTS
                        End If

                        TLTS_AUTORIZADOS.Value = dr.ReadNullAsEmptyDecimal("LTS_AUTORIZADOS")

                        If Convert.ToDecimal(TLTS_DESCONTAR.Text.Replace(",", "")) > 0 And Convert.ToDecimal(TPRECIO_X_LTS.Text.Replace(",", "")) > 0 Then
                            LtDescXLitros.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR.Value) * Convert.ToDecimal(TPRECIO_X_LTS.Value), "###,###,##0.00")
                        End If
                        Try
                            If TLTS_AUTORIZADOS.Value > 0 Then
                                No_CALCULA_EVENTO = True
                            End If
                        Catch ex As Exception
                            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try


                        'EMPIEZAN LOS TAGS
                        TPORC_TOLERANCIA.Tag = dr.ReadNullAsEmptyDecimal("PORC_TOLERANCIA")
                        TLTS_DESCONTAR.Tag = dr.ReadNullAsEmptyDecimal("LTS_DESCONTAR")

                        TPRECIO_X_LTS.Tag = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")
                        If TPRECIO_X_LTS.Value = 0 Then
                            TPRECIO_X_LTS.Tag = PRECIO_X_LTS
                        End If

                        TLTS_AUTORIZADOS.Tag = TLTS_AUTORIZADOS.Value
                        If Convert.ToDecimal(TLTS_DESCONTAR.Text.Replace(",", "")) > 0 And Convert.ToDecimal(TPRECIO_X_LTS.Text.Replace(",", "")) > 0 Then
                            LtDescXLitros.Tag = Format(Convert.ToDecimal(TLTS_DESCONTAR.Value) * Convert.ToDecimal(TPRECIO_X_LTS.Value), "###,###,##0.00")
                        End If

                    Catch ex As Exception
                    End Try

                    Try
                        'BONO ESPECIAL
                        If dr("DES") = "TABULADOR FULL" Or dr("DES") = "TABULADOR SENCILLO" Or dr("DES") = "TABULADOR FULL/SENCILLO" Then
                            BONO_ESPECIAL = True

                            If BONO_ESPECIAL_DESCR = "TABULADOR FULL" Or BONO_ESPECIAL_DESCR = "TABULADOR FULL/SENCILLO" Then
                                TBONO_RES.Value = dr.ReadNullAsEmptyDecimal("BONO_RES")
                                TBONO_RES_VACIO.Value = 0
                            Else
                                TBONO_RES.Value = 0
                                TBONO_RES_VACIO.Value = dr.ReadNullAsEmptyDecimal("BONO_RES_VACIO")
                            End If
                        Else
                            TBONO_RES.Value = dr.ReadNullAsEmptyDecimal("BONO_RES")
                            TBONO_RES_VACIO.Value = dr.ReadNullAsEmptyDecimal("BONO_RES_VACIO")
                        End If

                        TNO_VIAJES.Value = dr.ReadNullAsEmptyDecimal("NO_DE_VIAJES")
                        TNO_VIAJES_VACIO.Value = dr.ReadNullAsEmptyDecimal("NO_DE_VIAJES_VACIO")
                        LtDescXLitros2.Text = Format(dr.ReadNullAsEmptyDecimal("DESCXLITROS2"), "###,###,##0.00")

                        LtDescXLitros2.Tag = dr.ReadNullAsEmptyDecimal("DESCXLITROS2")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                dr.Close()
                '                  "Estatus :    FINALIZADO"
                If LtEstado.Text = "ESTATUS:    FINALIZADO" Or LtEstado.Text = "ESTATUS:    EN LIQUIDACION" Then
                    BarGrabar.Visible = False
                    Fg.AllowEditing = False
                    BtnAlta.Enabled = False
                    BtnBaja.Enabled = False
                    BarNuevoVale.Enabled = False

                    BarFinReseteo.Visible = False
                    SET_ALL_CONTROL_READ_AND_ENABLED(Split1)
                    BtnAbrirPDF.Enabled = True
                    BtnAbrirCarpeta.Enabled = True

                    SET_ALL_CONTROL_READ_AND_ENABLED(GpoCamposAdic)
                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox3)
                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox2)
                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox1)
                End If

                If PASS_GRUPOCE = "BUS" Or PASS_GRUPOCE = "CRIS" Then
                    BarGrabar.Visible = True
                End If
                Try
                    LtLTS_RALENTI.Text = Format((Convert.ToDecimal(TLTS_ECM.Text.Replace(",", "")) - Convert.ToDecimal(TLTS_PTO_RALENTI.Text.Replace(",", ""))) * Convert.ToDecimal(TPORC_RALENTI.Text.Replace(",", "")) / 100, "###,###,##0.00")

                    LtLTS_RALENTI.Tag = LtLTS_RALENTI.Text

                    If IsNumeric(LtLTS_RALENTI.Text.Replace(",", "")) Then

                        If TLTS_DESCONTAR.Value >= 0 Then
                            LLts_Desc_Ralenti.Text = "0"
                            LLts_desc_dif.Text = "0"
                        Else
                            LLts_Desc_Ralenti.Text = (CDec(TLTS_PTO_RALENTI.Text) - CDec(LtLTS_RALENTI.Text.Replace("'", ""))) * -1
                            If IsNumeric(LLts_Desc_Ralenti.Text.Replace(",", "")) Then
                                LLts_desc_dif.Text = TLTS_DESCONTAR.Text + Math.Abs(CDec(LLts_Desc_Ralenti.Text.Replace(",", "")))
                            End If
                        End If

                    End If
                Catch ex As Exception
                    Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                TCVE_RES.Enabled = False
                TCVE_OPER.Select()
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Dim NoIt As Integer = 0


        Select Case TIPO_TAB
            Case 0
                If DESCUENTO = 1 Then
                    TDESCT.Visible = True
                    NoIt += 1
                Else
                    If HORAS_GEN1 = 1 Then
                        TDESCT.Visible = True
                        NoIt += 1
                    Else
                        TDESCT.Visible = False
                        L1.Visible = False
                        LL1.Visible = False
                    End If
                End If
                If TIEMPOMARCHAINERCIA = 1 Then
                    TTIEMPO_MARCH_INERCIA.Visible = True
                    NoIt += 1
                Else
                    If HORAS_GEN2 Then
                        TTIEMPO_MARCH_INERCIA.Visible = True
                        NoIt += 1
                    Else
                        TTIEMPO_MARCH_INERCIA.Visible = False
                        L4.Visible = False
                        LL4.Visible = False
                    End If
                End If
                If CARGOXPUNTOMUERTO = 1 Then
                    TCARGO_X_PUNTO_MUERTO.Visible = True
                    NoIt += 1
                Else
                    If HORAS_USO1 Then
                        TCARGO_X_PUNTO_MUERTO.Visible = True
                        NoIt += 1
                    Else
                        TCARGO_X_PUNTO_MUERTO.Visible = False
                        L11.Visible = False
                    End If
                End If
            Case 1
                If DESCUENTO = 1 Then
                    TDESCT.Visible = True
                    NoIt += 1
                Else
                    If HORAS_GEN1 = 1 Then
                        TDESCT.Visible = True
                        NoIt += 1
                    Else
                        TDESCT.Visible = False
                        L1.Visible = False
                        LL1.Visible = False
                    End If
                End If
            Case 2
                If DESCUENTO = 1 Then
                    TDESCT.Visible = True
                    NoIt += 1
                Else
                    If HORAS_GEN1 = 1 Then
                        TDESCT.Visible = True
                        NoIt += 1
                    Else
                        TDESCT.Visible = False
                        L1.Visible = False
                        LL1.Visible = False
                    End If
                End If
                If TIEMPOMARCHAINERCIA = 1 Then
                    TTIEMPO_MARCH_INERCIA.Visible = True
                    NoIt += 1
                Else
                    If HORAS_GEN2 Then
                        TTIEMPO_MARCH_INERCIA.Visible = True
                        NoIt += 1
                    Else
                        TTIEMPO_MARCH_INERCIA.Visible = False
                        L4.Visible = False
                        LL4.Visible = False
                    End If
                End If

                If CARGOXPUNTOMUERTO = 1 Then
                    TCARGO_X_PUNTO_MUERTO.Visible = True
                    NoIt += 1
                Else
                    If HORAS_USO1 Then
                        TCARGO_X_PUNTO_MUERTO.Visible = True
                        NoIt += 1
                    Else
                        TCARGO_X_PUNTO_MUERTO.Visible = False
                        L11.Visible = False
                    End If
                End If
                'L15.TEXT	THORAS_GEN4.TEXT				LL16.TEXT
                If HORAS_GEN4 = 1 Then
                    L15.Visible = True
                    THORAS_GEN4.Visible = True
                    LL16.Visible = True
                Else
                    L15.Visible = False
                    THORAS_GEN4.Visible = False
                    LL16.Visible = False
                End If
                'L16.TEXT	THORAS_USO2.TEXT				
                If HORAS_USO2 Then
                    L16.Visible = True
                    THORAS_USO2.Visible = True
                Else
                    L16.Visible = False
                    THORAS_USO2.Visible = False
                End If
        End Select

        If LTS_GEN2 = 1 Then
            LtsGen2.Visible = True
            TLTS_GENERADOR2.Visible = True
        Else
            LtsGen2.Visible = False
            TLTS_GENERADOR2.Visible = False
        End If

        If NUM_VIAJES_FULL = 1 Then
            L17.Visible = True
            TNO_VIAJES.Visible = True
            BtnHelpnumViajes.Visible = True
        Else
            L17.Visible = False
            TNO_VIAJES.Visible = False
            BtnHelpnumViajes.Visible = False
        End If

        If NUM_VIAJES_SENC = 1 Then
            L18.Visible = True
            TNO_VIAJES_VACIO.Visible = True
        Else
            L18.Visible = False
            TNO_VIAJES_VACIO.Visible = False
        End If
        If RPM_MAXIMA = 1 Then
            L19.Visible = True
            TRPM_MAX.Visible = True
        Else
            L19.Visible = False
            TRPM_MAX.Visible = False
        End If
        '---------------------------------


        If CALIFICACION = 1 Then
            TCALIF.Visible = True
            NoIt += 1
        Else
            TCALIF.Visible = False
            L2.Visible = False
        End If
        If VELOCIDADMAXIMA = 1 Then
            TVELMAX.Visible = True
            NoIt += 1
        Else
            TVELMAX.Visible = False
            L3.Visible = False
            LL3.Visible = False
        End If

        If LITROSDESCONTAR = 1 Then
            TLTS_DESCONTAR.Visible = True
            NoIt += 1
        Else
            TLTS_DESCONTAR.Visible = False
            L5.Visible = False
            LL5.Visible = False
        End If
        If PRECIOXLITRO = 1 Then
            TPRECIO_X_LTS.Visible = True
            NoIt += 1
        Else
            TPRECIO_X_LTS.Visible = False
            L6.Visible = False
            LL6.Visible = False
        End If
        If DESCXLITRO = 1 Then
            LtDescXLitros.Visible = True
            NoIt += 1
        Else
            LtDescXLitros.Visible = False
            L7.Visible = False
            LL7.Visible = False
        End If
        If LTSAUTORIZ = 1 Then
            TLTS_AUTORIZADOS.Visible = True
            NoIt += 1
        Else
            TLTS_AUTORIZADOS.Visible = False
            L8.Visible = False
            LL8.Visible = False
        End If
        If LTSUREA = 1 Then
            TLITROS_UREA.Visible = True
            NoIt += 1
        Else
            TLITROS_UREA.Visible = False
            L9.Visible = False
            LL9.Visible = False
        End If
        If LTSUREA_REAL = 1 Then
            TLTS_UREA_REAL.Visible = True
            NoIt += 1
        Else
            TLTS_UREA_REAL.Visible = False
            L10.Visible = False
            LL10.Visible = False
        End If


        If NO_VIAJE = 1 Then
            TNO_VIAJE.Visible = True
            NoIt += 1
        Else
            TNO_VIAJE.Visible = False
            L12.Visible = False
        End If
        If NO_LIQUI = 1 Then
            TNO_LIQUI.Visible = True
            NoIt += 1
        Else
            TNO_LIQUI.Visible = False
            L13.Visible = False
        End If

        If NoIt = 0 Then
            GpoCamposAdic.Visible = False
        End If
        'L14.TEXT	THORAS_GEN3.TEXT				LL11.TEXT
        If HORAS_GEN3 = 1 Then
            L14.Visible = True
            THORAS_GEN3.Visible = True
            LL11.Visible = True
        Else
            L14.Visible = False
            THORAS_GEN3.Visible = False
            LL11.Visible = False
        End If

        If NUMGEN1 = 1 Then
            L20.Visible = True
            TNUMGEN1.Visible = True
            BtnGen1.Visible = True
            LtGen1.Visible = True
        Else
            L20.Visible = False
            TNUMGEN1.Visible = False
            BtnGen1.Visible = False
            LtGen1.Visible = False
        End If
        If NUMGEN2 = 1 Then
            L21.Visible = True
            TNUMGEN2.Visible = True
            BtnGen2.Visible = True
            LtGen2.Visible = True
        Else
            L21.Visible = False
            TNUMGEN2.Visible = False
            BtnGen2.Visible = False
            LtGen2.Visible = False
        End If

        If LTSDESCGEN = 1 Then
            L22.Visible = True
            TLTSDESCGEN.Visible = True
        Else
            L22.Visible = False
            TLTSDESCGEN.Visible = False
        End If

        Try
            CAL5()
            If ChEvento1.Checked Then
                ChEvento1_CheckedChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
        'CALCULA_EVENTO(CVE_EVE_G, No_CALCULA_EVENTO)

        '     EVENTO 1     EVENTO 1     EVENTO 1     EVENTO 1     EVENTO 1     EVENTO 1
        Try
            If ChEvento1.Checked Then
                ChEvento2.Checked = False
                LtLitrosECMEvento2.Visible = False
                TPORC_TOL_EVENTO2.Visible = False

                ENTRA_EVENTO1 = False
                ENTRA_EVENTO2 = False

                '19 JULIO

                If TPRECIO_X_LTS.Value = 0 Then
                    TPRECIO_X_LTS.Value = PRECIO_X_LTS
                    TPRECIO_X_LTS.Tag = PRECIO_X_LTS
                Else
                    TPRECIO_X_LTS.Value = TPRECIO_X_LTS.Tag
                End If

                TPORC_TOL_EVENTO2.Value = 0
                TLTS_AUTORIZADOS2.Value = 0
                LtLTS_VALES2.Text = 0
                TLTS_DESCONTAR2.Value = 0
                TPRECIO_X_LTS2.Value = 0
                LtDescXLitros2.Text = 0
                '=========================

                TPORC_TOLERANCIA.Value = TPORC_TOLERANCIA.Tag
                LtLTS_ECM.Text = LtLTS_ECM.Tag
                TLTS_AUTORIZADOS.Value = TLTS_AUTORIZADOS.Tag
                TLTS_DESCONTAR.Value = TLTS_DESCONTAR.Tag
                TPORC_RALENTI.Value = TPORC_RALENTI.Tag
                LtLTS_RALENTI.Text = LtLTS_RALENTI.Tag
                LtLTS_VALES.Text = LtLTS_VALES.Tag
                TPRECIO_X_LTS.Value = TPRECIO_X_LTS.Tag
                LtDescXLitros.Text = LtDescXLitros.Tag

                ENTRA_EVENTO1 = True
                ENTRA_EVENTO2 = True
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '         EVENTO2         EVENTO2         EVENTO2         EVENTO2         EVENTO2
        Try
            If ChEvento2.Checked Then
                ChEvento1.Checked = False
                LtLitrosECMEvento2.Visible = True
                TPORC_TOL_EVENTO2.Visible = True
                'CALCULO_EVENTO2_LTS_DESCONTAR2()
                '19 JULIO
                ENTRA_EVENTO1 = False
                ENTRA_EVENTO2 = False

                If TPRECIO_X_LTS2.Value = 0 Then
                    If TPRECIO_X_LTS.Value = 0 Then
                        TPRECIO_X_LTS2.Value = PRECIO_X_LTS
                        TPRECIO_X_LTS2.Tag = PRECIO_X_LTS
                    Else
                        TPRECIO_X_LTS2.Value = TPRECIO_X_LTS2.Tag
                    End If
                Else
                    TPRECIO_X_LTS2.Value = TPRECIO_X_LTS2.Tag
                End If


                TPORC_TOLERANCIA.Value = 0
                LtLTS_ECM.Text = 0
                TLTS_AUTORIZADOS.Value = 0
                TLTS_DESCONTAR.Value = 0
                TPORC_RALENTI.Value = 0
                LtLTS_RALENTI.Text = 0
                LtLTS_VALES.Text = 0
                TPRECIO_X_LTS.Value = 0
                LtDescXLitros.Text = 0
                'FIN CAMBIO 19 DE JULIO
                'TPORC_TOL_EVENTO2.Value = TPORC_TOL_EVENTO2.Tag
                'TLTS_AUTORIZADOS2.Value = TLTS_AUTORIZADOS2.Tag
                'LtLTS_VALES2.Text = LtLTS_VALES2.Tag
                'TLTS_DESCONTAR2.Value = TLTS_DESCONTAR2.Tag


                'if IsNumeric(LtDescXLitros2.Tag) Then
                'LtDescXLitros2.Text = Format(Convert.ToDecimal(LtDescXLitros2.Tag), "###,###,##0.00")
                'End If

                ENTRA_EVENTO1 = True
                ENTRA_EVENTO2 = True
            Else
                LtLitrosECMEvento2.Visible = True
                TPORC_TOL_EVENTO2.Visible = True
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        No_CALCULA_EVENTO = False
    End Sub
    Sub OBTENER_ULTIMO_PORC_RALENTI()

        SQL = "SELECT TOP 1 PORC_RALENTI FROM GCRESETEO
            WHERE ISNULL(STATUS,'A') = 'A' ORDER BY FECHAELAB DESC"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TPORC_RALENTI.Value = dr.ReadNullAsEmptyDecimal("PORC_RALENTI")
                        TPORC_RALENTI.Tag = dr.ReadNullAsEmptyDecimal("PORC_RALENTI")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarGrabar.Visible = False
                BarFinReseteo.Visible = False
                SET_ALL_CONTROL_READ_AND_ENABLED(Split1)
                SET_ALL_CONTROL_READ_AND_ENABLED(Pag2)
                SET_ALL_CONTROL_READ_AND_ENABLED(GpoCamposAdic)
                SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox1)
                SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox2)
                SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox3)
                TLTS_DESCONTAR.ReadOnly = False
                TLTS_DESCONTAR2.ReadOnly = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 81000 AND CLAVE < 81500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 81020 'CONSULTAR
                                    BarGrabar.Visible = False
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Split1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Pag2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox3)
                                Case 81040 'MODIFICAR
                                    BarGrabar.Visible = True
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Split1, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Pag2, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GpoCamposAdic, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox1, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox2, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(GroupBox3, True)
                                Case 81060 'FINALIZAR RESETEO
                                    BarFinReseteo.Visible = True
                                Case 81080
                                    TLTS_DESCONTAR.ReadOnly = True
                                    TLTS_DESCONTAR2.ReadOnly = True
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub OBTENER_RUTA_DOC()
        Try 'SQL SERVER
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        RUTA_DOC = dr.ReadNullAsEmptyString("RUTA_DOC")
                        DESCUENTO = dr.ReadNullAsEmptyInteger("DESCUENTO")
                        CALIFICACION = dr.ReadNullAsEmptyInteger("CALIFICACION")
                        VELOCIDADMAXIMA = dr.ReadNullAsEmptyInteger("VELOCIDADMAXIMA")
                        TIEMPOMARCHAINERCIA = dr.ReadNullAsEmptyInteger("TIEMPOMARCHAINERCIA")
                        LITROSDESCONTAR = dr.ReadNullAsEmptyInteger("LITROSDESCONTAR")
                        PRECIOXLITRO = dr.ReadNullAsEmptyInteger("PRECIOXLITRO")
                        DESCXLITRO = dr.ReadNullAsEmptyInteger("DESCXLITRO")
                        LTSAUTORIZ = dr.ReadNullAsEmptyInteger("LTSAUTORIZ")
                        LTSUREA = dr.ReadNullAsEmptyInteger("LTSUREA")
                        LTSUREA_REAL = dr.ReadNullAsEmptyInteger("LTSUREA_REAL")
                        CARGOXPUNTOMUERTO = dr.ReadNullAsEmptyInteger("CARGOXPUNTOMUERTO")
                        NO_VIAJE = dr.ReadNullAsEmptyInteger("NO_VIAJE")
                        NO_LIQUI = dr.ReadNullAsEmptyInteger("NO_LIQUI")

                        HORAS_GEN1 = dr.ReadNullAsEmptyInteger("HORAS_GEN1")
                        HORAS_GEN2 = dr.ReadNullAsEmptyInteger("HORAS_GEN2")
                        HORAS_USO1 = dr.ReadNullAsEmptyInteger("HORAS_USO1")
                        HORAS_GEN3 = dr.ReadNullAsEmptyInteger("HORAS_GEN3")
                        HORAS_GEN4 = dr.ReadNullAsEmptyInteger("HORAS_GEN4")
                        HORAS_USO2 = dr.ReadNullAsEmptyInteger("HORAS_USO2")


                        NUMGEN1 = dr.ReadNullAsEmptyInteger("NUMGEN1")
                        NUMGEN2 = dr.ReadNullAsEmptyInteger("NUMGEN2")
                        LTSDESCGEN = dr.ReadNullAsEmptyInteger("LTSDESCGEN")


                        LTS_GEN2 = dr.ReadNullAsEmptyInteger("LTS_GEN2")
                        NUM_VIAJES_FULL = dr.ReadNullAsEmptyInteger("NUM_VIAJES_FULL")
                        NUM_VIAJES_SENC = dr.ReadNullAsEmptyInteger("NUM_VIAJES_SENC")
                        RPM_MAXIMA = dr.ReadNullAsEmptyInteger("RPM_MAXIMA")

                        PRECIO_X_LTS = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")
                    End If
                End Using
            End Using

            If PRECIO_X_LTS = 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TOP 50 CVE_RES, LTS_VALES, LTS_VALES2, PRECIO_X_LTS, PRECIO_X_LTS2 FROM GCRESETEO ORDER BY FECHAELAB DESC"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            PRECIO_X_LTS = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")
                            If PRECIO_X_LTS > 0 Then
                                Exit While
                            End If
                        End While
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_PAR_FLORES(FCVE_RES As Long)
        Dim CADENA1 As String
        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.CVE_VIAJE, KMS, RENDIMIENTO, LITROS, ISNULL(FACTOR,1) AS FAC
                    FROM GCRESET_TAB_FLORES_PAR T 
                    WHERE ISNULL(T.STATUS,'A') = 'A' AND CVE_RES = " & FCVE_RES & "
                    ORDER BY T.CVE_TAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.STATUS, R.CVE_TAB, A.CVE_TRACTOR, A.FECHA, RE.DESCR AS ORIGUEN, U.CVE_REND, 
                                    (CASE ISNULL(A.TIPO_UNI,0) WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNI, 
                                    A.CLAVE_O, OP1.NOMBRE AS NOMBRE1, OP1.CVE_PLAZA AS PLAZA1, P1.CIUDAD AS CIUDAD1, A.CLAVE_D, 
                                    OP2.NOMBRE AS NOMBRE2, OP2.CVE_PLAZA AS PLAZA2, P2.CIUDAD AS CIUDAD2, R.KMS, A.FECHA_CARGA, 
                                    CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS STATUSVIAJE, 
                                    EE.DESCR AS DESTINO, R.AUTO_SENC, R.P4_SENC, R.AUTO_SENC_LTS, R.P4_SENC_LTS,
                                    R.FULL_AUTO, R.FULL_P4, R.FULL_AUTO_LTS, R.FULL_P4_LTS, CVE_CAP1, CVE_CAP2
                                    FROM GCASIGNACION_VIAJE A 
                                    LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                                    LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON
                                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                                    LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = A.CLAVE_O
                                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP1.CVE_PLAZA
                                    LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = A.CLAVE_D
                                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP2.CVE_PLAZA
                                    LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                    LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = A.RECOGER_EN
                                    LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = A.ENTREGAR_EN
                                    WHERE A.CVE_VIAJE = '" & dr("CVE_VIAJE") & "'"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        '("Autónomo")   0 '("P4")         1
                                        If dr2.ReadNullAsEmptyString("TIPOUNI") = "Full" Then
                                            If dr2("CVE_REND") = 0 Then
                                                CADENA1 = dr2("FULL_AUTO") & vbTab & dr2("FULL_AUTO_LTS")
                                            Else
                                                CADENA1 = dr2("FULL_P4") & vbTab & dr2("FULL_P4_LTS")
                                            End If
                                        Else
                                            If dr2.ReadNullAsEmptyString("CVE_REND") = 0 Then
                                                CADENA1 = dr2("AUTO_SENC") & vbTab & dr2("AUTO_SENC_LTS")
                                            Else
                                                CADENA1 = dr2("P4_SENC") & vbTab & dr2("P4_SENC_LTS")
                                            End If
                                        End If

                                        Fg.AddItem("" & vbTab & dr2("CVE_TAB") & vbTab & dr2("CVE_VIAJE") & vbTab & dr2("STATUS") & vbTab &
                                           dr2("CVE_TRACTOR") & vbTab & dr2.ReadNullAsEmptyString("FECHA") & vbTab & dr2("TIPOUNI") & vbTab &
                                           dr2("CLAVE_O") & vbTab & dr2("NOMBRE1") & vbTab & dr2("PLAZA1") & vbTab & dr2("CIUDAD1") & vbTab &
                                           dr2("CLAVE_D") & vbTab & dr2("NOMBRE2") & vbTab & dr2("PLAZA2") & vbTab & dr2("CIUDAD2") & vbTab &
                                           dr2("FECHA_CARGA") & vbTab & dr2("STATUSVIAJE") & vbTab & dr2("ORIGUEN") & vbTab & dr("FAC") & vbTab &
                                           dr("KMS") & vbTab & dr("RENDIMIENTO") & vbTab & dr("LITROS") & vbTab &
                                           dr2("KMS") & vbTab & CADENA1 & vbTab & dr2("CVE_CAP1") & vbTab & dr2("CVE_CAP2"))
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End While
                End Using
                Fg.AutoSizeCols()
                CALCULA_RENDIMIENTO_FLORES()
            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_PAR(FCVE_RES As Long)

        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_TAB, CVE_OPER, O.NOMBRE, CVE_UNI, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, 
                    ISNULL(P2.CIUDAD,'') AS DESCR_DES, ISNULL(CARGADO_VACIO,0) AS CAR_VAC, TIPO_VIAJE, CLIENTE, C.NOMBRE, 
                    ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As RENDI, ISNULL(T.UUID,'') AS UID 
                    FROM GCRESETEO_TABULADOR T 
                    LEFT JOIN GCOPERADOR O On O.CLAVE = T.CVE_OPER 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                    WHERE CVE_RES = " & FCVE_RES
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("CVE_OPER") & vbTab & dr("NOMBRE") & vbTab &
                           dr("CVE_UNI") & vbTab & dr("CVE_ORI") & vbTab & dr("DESCR_ORI") & vbTab & dr("CVE_DES") & vbTab &
                           dr("DESCR_DES") & vbTab & IIf(dr("CAR_VAC"), "CARGADO", "VACIO") & vbTab & dr("TIPO_VIAJE") & vbTab &
                           dr("CLIENTE") & vbTab & dr("NOMBRE") & vbTab & dr("KM") & vbTab & dr("RENDI") & vbTab &
                           IIf(dr("RENDI") > 0, (dr("KM") / dr("RENDI")), 0) & vbTab & dr("UID"))
                    End While
                End Using
                CALCULA_RENDIMIENTO("N")
            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_PAR_VIKINGOS(FCVE_RES As Long)
        Dim s As String

        Fg.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.NUM_VIAJE, T.STATUS, T.FOLIO_LIQ, T.CVE_OPER, T.CVE_UNI, T.NOMBRE_OPER, T.TIPO_VIAJE, 
                    T.CLIENTE, T.NOMBRE_CLIE, T.CVE_ORI, T.ORIGEN, T.CVE_DES, T.DESTINO, T.CARGADO_VACIO, T.KMS, 
                    T.RENDIMIENTO, T.LITROS, T.TONELADAS, FECHA_IDA
                    FROM GCRESET_TAB_VIKINGOS_PAR T 
                    LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                    WHERE ISNULL(T.STATUS,'A') = 'A' AND CVE_RES = " & FCVE_RES & "
                    ORDER BY T.CVE_TAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        s = dr("CVE_TAB") & vbTab '1
                        s &= dr("NUM_VIAJE") & vbTab '2
                        s &= dr("FOLIO_LIQ") & vbTab '3
                        s &= dr("CVE_OPER") & vbTab '4
                        s &= LtOper.Text & vbTab '5
                        s &= dr.ReadNullAsEmptyString("FECHA_IDA") & vbTab '6
                        s &= dr.ReadNullAsEmptyString("CVE_UNI") & vbTab '7
                        s &= dr.ReadNullAsEmptyString("TIPO_VIAJE") & vbTab '8
                        s &= dr("CLIENTE") & vbTab '9
                        s &= dr("NOMBRE_CLIE") & vbTab '10
                        s &= dr("CVE_ORI") & vbTab '11
                        s &= dr.ReadNullAsEmptyString("ORIGEN") & vbTab '12
                        s &= dr("CVE_DES") & vbTab '13
                        s &= dr.ReadNullAsEmptyString("DESTINO") & vbTab '14
                        s &= IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab '15
                        s &= dr("KMS") & vbTab '16
                        s &= dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab '17
                        s &= dr("LITROS") & vbTab '18
                        s &= dr.ReadNullAsEmptyDecimal("TONELADAS") '19

                        Fg.AddItem("" & vbTab & s)
                    End While
                End Using
                Fg.AutoSizeCols()
                CALCULA_RENDIMIENTO_VIKINGOS()
            End Using
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmReseteoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub FrmReseteoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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
        Dim CVE_EVE As Single = 0, EVE_PORC_TOLERANCIA As Single = 0, EVE_PORC_RALENTI As Single = 0
        Dim V7 As Single, V8 As Single, V9 As Single, RUTA_PDF As String = "", ARCHIVO As String = "", NO_DE_VIAJES As Decimal = 0
        Dim CVE_RES As Long, NO_DE_VIAJES_VACIO As Decimal = 0, BONO_RES_VACIO As Decimal = 0, RUTA_X As String = ""
        Dim PORC_TOL_EVENTO2 As Decimal, LT1 As Decimal, LT2 As Decimal, DESCXLITROS As Decimal, RPM_MAX As Decimal = 0, CALIF_RPM As Decimal = 0

        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        Try
            If IsNumeric(TLTS_AUTORIZADOS.Text.Trim.Replace(",", "")) And IsNumeric(LtLTS_VALES.Text.Trim.Replace(",", "")) Then
                LT1 = CDec(TLTS_AUTORIZADOS.Text.Trim.Replace(",", ""))
                LT2 = CDec(LtLTS_VALES.Text.Trim.Replace(",", ""))

                If ChEvento1.Checked Then
                    If LT1 - LT2 < 0 Or (LT1 = 0 Or LT2 = 0) Then
                        If IsNumeric(TPRECIO_X_LTS.Text) Then
                            If TPRECIO_X_LTS.Text <= 0 Then
                                MsgBox("No es posible grabar el reseteo si el precio x litro es cero")
                                Return
                            End If
                        Else
                            MsgBox("No es posible grabar el reseteo si el precio x litro es cero o menor a cero")
                            Return
                        End If
                    End If
                Else
                    If ChEvento2.Checked Then
                        If TPRECIO_X_LTS2.Value <= 0 Then
                            MsgBox("No es posible grabar el reseteo si el precio x litro es cero")
                            Return

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If TPDF.Text.Trim.Length > 0 Then
            Try
                If RUTA_DOC.Trim.Length = 0 Then
                    RUTA_PDF = Application.StartupPath
                Else
                    RUTA_PDF = RUTA_DOC
                End If
                ARCHIVO = TPDF.Text

            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            ARCHIVO = ""
        End If

        Try
            Fg.Select()
            If TLTS_UREA_REAL.Text.Trim.Length = 0 Then
                TLTS_UREA_REAL.Value = 0
            End If
            If TDESCT.Text.Trim.Length = 0 Then
                TDESCT.Value = 0
            End If
            If TCALIF.Text.Trim.Length = 0 Then
                TCALIF.Text = "0"
            End If
            If TVELMAX.Text.Trim.Length = 0 Then
                TVELMAX.Value = 0
            End If
            If TLTS_DESCONTAR.Text.Trim.Length = 0 Then
                TLTS_DESCONTAR.Value = 0
                TLTS_DESCONTAR2.Value = 0
            End If

            'If TPRECIO_X_LTS.Text.Trim.Length = 0 Then
            'TPRECIO_X_LTS.Value = 0
            'TPRECIO_X_LTS2.Value = 0
            'End If

            If TPRECIO_X_LTS2.Value <= 0 Then
                If TPRECIO_X_LTS.Value > 0 Then
                    TPRECIO_X_LTS2.Value = TPRECIO_X_LTS.Value
                Else
                    TPRECIO_X_LTS2.Value = PRECIO_X_LTS
                End If
            Else
                If TPRECIO_X_LTS.Value <= 0 Then
                    TPRECIO_X_LTS.Value = TPRECIO_X_LTS2.Value
                End If
            End If

            If TLTS_AUTORIZADOS.Text.Trim.Length = 0 Then
                TLTS_AUTORIZADOS.Value = 0
                TLTS_AUTORIZADOS2.Value = 0
            End If
            If TLITROS_UREA.Text.Trim.Length = 0 Then
                TLITROS_UREA.Value = 0
            End If
            If TCARGO_X_PUNTO_MUERTO.Text.Trim.Length = 0 Then
                TCARGO_X_PUNTO_MUERTO.Value = 0
            End If

            'If tCVE_EVE.Text.Trim.Length > 0 Then
            'If IsNumeric(tCVE_EVE.Text) Then
            'CVE_EVE = tCVE_EVE.Text
            'End If
            'End If
            If TPORC_TOLERANCIA.Text.Trim.Length > 0 Then
                If IsNumeric(TPORC_TOLERANCIA.Text) Then
                    EVE_PORC_TOLERANCIA = TPORC_TOLERANCIA.Text
                End If
            End If
            If TPORC_RALENTI.Text.Trim.Length > 0 Then
                If IsNumeric(TPORC_RALENTI.Text) Then
                    EVE_PORC_RALENTI = TPORC_RALENTI.Text
                End If
            End If
            If TLTS_UREA_REAL.Text.Trim.Length = 0 Then
                TLTS_UREA_REAL.Text = "0"
            End If
            If TPORC_TOLERANCIA.Text.Trim.Length = 0 Then
                TPORC_TOLERANCIA.Text = "0"
                TPORC_TOLERANCIA.Tag = "0"
            End If
            If TPORC_RALENTI.Text.Trim.Length = 0 Then
                TPORC_RALENTI.Text = "0"
            End If
            If IsNothing(TLTS_FORANEOS.Text) Then
                TLTS_FORANEOS.Value = 0
            Else
                If TLTS_FORANEOS.Text.Trim.Length = 0 Then
                    TLTS_FORANEOS.Value = 0
                End If
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Dim CALIF_VEL_MX As Decimal = 0, BONO_RES As Decimal = 0
        Try
            If IsNumeric(TCALIF_VEL_MX.Text.Replace(",", "")) Then
                CALIF_VEL_MX = TCALIF_VEL_MX.Text.Replace(",", "")
            Else
                CALIF_VEL_MX = 0
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(TBONO_RES.Text) Then
                BONO_RES = TBONO_RES.Text
            Else
                BONO_RES = 0
            End If
        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If Not IsNumeric(TCALIF.Text.Replace(",", "")) Then
                TCALIF.Text = "0"
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(TNO_VIAJES.Text) Then
                NO_DE_VIAJES = TNO_VIAJES.Text
            Else
                NO_DE_VIAJES = 0
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(TNO_VIAJES_VACIO.Text) Then
                NO_DE_VIAJES_VACIO = TNO_VIAJES_VACIO.Text
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(TBONO_RES_VACIO.Text) Then
                BONO_RES_VACIO = TBONO_RES_VACIO.Text
            End If
        Catch ex As Exception
        End Try
        Try
            TPORC_TOL_EVENTO2.Update()

            PORC_TOL_EVENTO2 = TPORC_TOL_EVENTO2.Value
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            THORAS_GEN3.UpdateValueWithCurrentText()
            THORAS_GEN4.UpdateValueWithCurrentText()
            THORAS_USO2.UpdateValueWithCurrentText()
            TRPM_MAX.Value.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Try
            If IsNumeric(LtDescXLitros.Text.Trim.Replace(",", "")) Then
                DESCXLITROS = Convert.ToDecimal(LtDescXLitros.Text.Trim.Replace(",", ""))
            Else
                DESCXLITROS = 0
            End If
        Catch ex As Exception
        End Try
        Try
            RPM_MAX = TRPM_MAX.Value
        Catch ex As Exception
        End Try

        Try
            Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
            Try
                LRC1 = TLTS_SALIDA.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            Try
                LRC2 = TLTS_VALES.Value
            Catch ex As Exception
            End Try
            Try
                LRC3 = TLTS_FORANEOS.Value
            Catch ex As Exception
            End Try
            Try
                LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4

            If IsNumeric(TCALIF_RPM.Text) Then
                CALIF_RPM = Convert.ToDecimal(TCALIF_RPM.Text.Trim)
            End If

        Catch ex As Exception
        End Try

        If NewRecord Then
            SQL = "INSERT INTO GCRESETEO (CVE_RES, STATUS, ESTADO, FECHA, CVE_OPER, CVE_UNI, CVE_MOT, ODOMETRO, KM_ECM, LTS_ECM, LTS_REAL, LTS_TAB, 
                FAC_CARGA, HRS_TRABAJO, HRS_PTO_RALENTI, LTS_PTO_RALENTI, LTS_SALIDA, LTS_VALES, LTS_LLEGADA, REND_ECM, PORC_VAR_LTS_ECM_REAL, 
                PORC_VAR_LTS_TAB_REAL, KMS_TAB, PORC_TIEMPO_PTO_RALENTI, PORC_LTS_PTO_RALENTI, REND_TAB, REND_REAL, DIF_LTS_REAL_LTS_TAB, DESCT, 
                CALIF, VELMAX, TIEMPO_MARCH_INERCIA, PDF, FECHAELAB, UUID, CALIF_FACTOR_CARGA, CALIF_RALENTI, CALIF_GLOBAL, CAL_FAC_CAR_EVA, 
                CAL_RAL_EVA, CAL_GLO_EVA, LTS_DESCONTAR, PRECIO_X_LTS, LTS_AUTORIZADOS, LITROS_UREA, CARGO_X_PUNTO_MUERTO, FACTOR_CARGA, 
                PORC_USO_RALENTI, LTS_UREA_REAL, CVE_EVE, EVE_PORC_TOLERANCIA, EVE_PORC_RALENTI, PORC_TOLERANCIA, PORC_RALENTI, NO_VIAJE, NO_LIQUI, 
                LTS_FORANEOS, CALIF_VEL_MAX, BONO_RES, NO_DE_VIAJES, NO_DE_VIAJES_VACIO, BONO_RES_VACIO, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, 
                PRECIO_X_LTS2, EVENTO, EVENTO_LTS, PORC_TOL_EVENTO2, DESCXLITROS2, TABULADOR, HORAS_GEN3, HORAS_GEN4, HORAS_USO2, CVE_EVA, 
                LTS_GENERADOR2, NUMGEN1, NUMGEN2, LTSDESCGEN, DESCXLITROS, RPM_MAX, CALIF_RPM, DIF_LTS_REAL_LTS_ECM) 
                OUTPUT Inserted.CVE_RES VALUES 
                (ISNULL((SELECT ISNULL(MAX(CVE_RES),0) + 1 FROM GCRESETEO),1),
                'A', 'EDICION', @FECHA, @CVE_OPER, @CVE_UNI, @CVE_MOT, @ODOMETRO, @KM_ECM, @LTS_ECM, @LTS_REAL, @LTS_TAB, @FAC_CARGA, @HRS_TRABAJO, 
                @HRS_PTO_RALENTI, @LTS_PTO_RALENTI, @LTS_SALIDA, @LTS_VALES, @LTS_LLEGADA, @REND_ECM, @PORC_VAR_LTS_ECM_REAL, @PORC_VAR_LTS_TAB_REAL, 
                @KMS_TAB, @PORC_TIEMPO_PTO_RALENTI, @PORC_LTS_PTO_RALENTI, @REND_TAB, @REND_REAL, @DIF_LTS_REAL_LTS_TAB, @DESCT, @CALIF, @VELMAX, 
                @TIEMPO_MARCH_INERCIA, @PDF, GETDATE(), NEWID(), @CALIF_FACTOR_CARGA, @CALIF_RALENTI, @CALIF_GLOBAL, @CAL_FAC_CAR_EVA, @CAL_RAL_EVA, 
                @CAL_GLO_EVA, @LTS_DESCONTAR, @PRECIO_X_LTS, @LTS_AUTORIZADOS, @LITROS_UREA, @CARGO_X_PUNTO_MUERTO, @FACTOR_CARGA, @PORC_USO_RALENTI, 
                @LTS_UREA_REAL, @CVE_EVE, @EVE_PORC_TOLERANCIA, @EVE_PORC_RALENTI, @PORC_TOLERANCIA, @PORC_RALENTI, @NO_VIAJE, @NO_LIQUI, 
                @LTS_FORANEOS, @CALIF_VEL_MAX, @BONO_RES, @NO_DE_VIAJES, @NO_DE_VIAJES_VACIO, @BONO_RES_VACIO, @LTS_AUTORIZADOS2, @LTS_VALES2, 
                @LTS_DESCONTAR2, @PRECIO_X_LTS2, @EVENTO, @EVENTO_LTS, @PORC_TOL_EVENTO2, @DESCXLITROS2, @TABULADOR, @HORAS_GEN3, @HORAS_GEN4, 
                @HORAS_USO2, @CVE_EVA, @LTS_GENERADOR2, @NUMGEN1, @NUMGEN2, @LTSDESCGEN, @DESCXLITROS, @RPM_MAX, @CALIF_RPM, @DIF_LTS_REAL_LTS_ECM)"
        Else
            SQL = "UPDATE GCRESETEO SET FECHA = @FECHA, CVE_OPER = @CVE_OPER, CVE_UNI = @CVE_UNI, CVE_MOT= @CVE_MOT, ODOMETRO = @ODOMETRO, 
                KM_ECM = @KM_ECM, LTS_ECM = @LTS_ECM, LTS_REAL = @LTS_REAL, LTS_TAB = @LTS_TAB, FAC_CARGA = @FAC_CARGA, HRS_TRABAJO = @HRS_TRABAJO, 
                HRS_PTO_RALENTI = @HRS_PTO_RALENTI, LTS_PTO_RALENTI = @LTS_PTO_RALENTI, LTS_SALIDA = @LTS_SALIDA, LTS_VALES = @LTS_VALES, 
                LTS_LLEGADA = @LTS_LLEGADA, PDF = @PDF, REND_ECM = @REND_ECM, PORC_VAR_LTS_ECM_REAL = @PORC_VAR_LTS_ECM_REAL, 
                PORC_VAR_LTS_TAB_REAL = @PORC_VAR_LTS_TAB_REAL, KMS_TAB = @KMS_TAB, PORC_TIEMPO_PTO_RALENTI = @PORC_TIEMPO_PTO_RALENTI, 
                PORC_LTS_PTO_RALENTI = @PORC_LTS_PTO_RALENTI, REND_TAB = @REND_TAB, REND_REAL = @REND_REAL, DIF_LTS_REAL_LTS_ECM = @DIF_LTS_REAL_LTS_ECM, 
                DIF_LTS_REAL_LTS_TAB = @DIF_LTS_REAL_LTS_TAB, DESCT = @DESCT, CALIF = @CALIF, VELMAX = @VELMAX, 
                TIEMPO_MARCH_INERCIA = @TIEMPO_MARCH_INERCIA, CALIF_FACTOR_CARGA = @CALIF_FACTOR_CARGA, CALIF_RALENTI = @CALIF_RALENTI, 
                CALIF_GLOBAL = @CALIF_GLOBAL, CAL_FAC_CAR_EVA = @CAL_FAC_CAR_EVA, CAL_RAL_EVA = @CAL_RAL_EVA, CAL_GLO_EVA = @CAL_GLO_EVA,
                LTS_DESCONTAR = @LTS_DESCONTAR, PRECIO_X_LTS = @PRECIO_X_LTS, LTS_AUTORIZADOS = @LTS_AUTORIZADOS, LITROS_UREA = @LITROS_UREA, 
                CARGO_X_PUNTO_MUERTO = @CARGO_X_PUNTO_MUERTO, FACTOR_CARGA = @FACTOR_CARGA, PORC_USO_RALENTI = @PORC_USO_RALENTI, 
                LTS_UREA_REAL = @LTS_UREA_REAL, CVE_EVE = @CVE_EVE, EVE_PORC_TOLERANCIA = @EVE_PORC_TOLERANCIA, EVE_PORC_RALENTI = @EVE_PORC_RALENTI, 
                PORC_TOLERANCIA = @PORC_TOLERANCIA, PORC_RALENTI = @PORC_RALENTI, NO_VIAJE = @NO_VIAJE, NO_LIQUI = @NO_LIQUI, 
                LTS_FORANEOS = @LTS_FORANEOS, CALIF_VEL_MAX = @CALIF_VEL_MAX, BONO_RES = @BONO_RES, NO_DE_VIAJES = @NO_DE_VIAJES, 
                BONO_RES_VACIO = @BONO_RES_VACIO, NO_DE_VIAJES_VACIO = @NO_DE_VIAJES_VACIO, LTS_AUTORIZADOS2 = @LTS_AUTORIZADOS2, LTS_VALES2 = @LTS_VALES2,
                LTS_DESCONTAR2= @LTS_DESCONTAR2, PRECIO_X_LTS2 = @PRECIO_X_LTS2, EVENTO = @EVENTO, EVENTO_LTS = @EVENTO_LTS, 
                PORC_TOL_EVENTO2 = @PORC_TOL_EVENTO2, DESCXLITROS2 = @DESCXLITROS2, HORAS_GEN3 = @HORAS_GEN3, HORAS_GEN4 = @HORAS_GEN4, 
                HORAS_USO2 = @HORAS_USO2, CVE_EVA = @CVE_EVA, LTS_GENERADOR2 = @LTS_GENERADOR2, NUMGEN1 = @NUMGEN1, NUMGEN2 = @NUMGEN2, 
                LTSDESCGEN = @LTSDESCGEN, DESCXLITROS = @DESCXLITROS, RPM_MAX = @RPM_MAX, CALIF_RPM = @CALIF_RPM
                WHERE CVE_RES = @CVE_RES"
        End If
        cmd.CommandText = SQL

        Try
            V7 = Math.Round(THRS_TRABAJO.Value, 6)
            V8 = Math.Round(THRS_PTO_RALENTI.Value, 6)
            V9 = Math.Round(TLTS_PTO_RALENTI.Value, 6)

            cmd.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_RES.Text)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_UNI.Text
            cmd.Parameters.Add("@CVE_MOT", SqlDbType.VarChar).Value = TCVE_MOT.Text

            cmd.Parameters.Add("@ODOMETRO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TODOMETRO.Value), 6)
            cmd.Parameters.Add("@KM_ECM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TKM_ECM.Value), 6)
            cmd.Parameters.Add("@LTS_ECM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_ECM.Value), 6)
            cmd.Parameters.Add("@LTS_REAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_REAL.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_TAB", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_TAB.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@FAC_CARGA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TFAC_CARGA.Value), 6)
            cmd.Parameters.Add("@HRS_TRABAJO", SqlDbType.Float).Value = Math.Round(THRS_TRABAJO.Value, 6)
            cmd.Parameters.Add("@HRS_PTO_RALENTI", SqlDbType.Float).Value = Math.Round(THRS_PTO_RALENTI.Value, 6)
            cmd.Parameters.Add("@LTS_PTO_RALENTI", SqlDbType.Float).Value = Math.Round(TLTS_PTO_RALENTI.Value, 6)
            cmd.Parameters.Add("@LTS_SALIDA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_SALIDA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_VALES", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_VALES.Value), 6)
            cmd.Parameters.Add("@LTS_LLEGADA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TLTS_LLEGADA.Text.Replace(",", "")), 6)

            cmd.Parameters.Add("@REND_ECM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtREND_ECM.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PORC_VAR_LTS_ECM_REAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtPORC_VAR_LTS_ECM_REAL.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PORC_VAR_LTS_TAB_REAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtPORC_VAR_LTS_TAB_REAL.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@KMS_TAB", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtKMS_TAB.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@REND_TAB", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtREND_TAB.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@REND_REAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtREND_REAL.Text.Replace(",", "")), 6)

            cmd.Parameters.Add("@PORC_TIEMPO_PTO_RALENTI", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtPORC_TIEMPO_PTO_RALENTI.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PORC_LTS_PTO_RALENTI", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtPORC_LTS_PTO_RALENTI.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@DIF_LTS_REAL_LTS_TAB", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtDIF_LTS_REAL_LTS_TAB.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@DIF_LTS_REAL_LTS_ECM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtDIF_LTS_REAL_LTS_ECM.Text.Replace(",", "")), 6)

            cmd.Parameters.Add("@DESCT", SqlDbType.Float).Value = Math.Round(CDec(TDESCT.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CALIF", SqlDbType.Float).Value = Math.Round(CDec(TCALIF.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@VELMAX", SqlDbType.Float).Value = Math.Round(CDec(TVELMAX.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@TIEMPO_MARCH_INERCIA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TTIEMPO_MARCH_INERCIA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PDF", SqlDbType.VarChar).Value = ARCHIVO
            cmd.Parameters.Add("@CALIF_FACTOR_CARGA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCALIF_FACTOR_CARGA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CALIF_RALENTI", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCALIF_RALENTI.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CALIF_GLOBAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CAL_FAC_CAR_EVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCAL_FAC_CAR_EVA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CAL_RAL_EVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCAL_RAL_EVA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CAL_GLO_EVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCAL_GLO_EVA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_AUTORIZADOS", SqlDbType.Float).Value = Math.Round(CDec(TLTS_AUTORIZADOS.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_DESCONTAR", SqlDbType.Float).Value = Math.Round(CDec(TLTS_DESCONTAR.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PRECIO_X_LTS", SqlDbType.Float).Value = Math.Round(CDec(TPRECIO_X_LTS.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LITROS_UREA", SqlDbType.Float).Value = Math.Round(CDec(TLITROS_UREA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CARGO_X_PUNTO_MUERTO", SqlDbType.Float).Value = Math.Round(CDec(TCARGO_X_PUNTO_MUERTO.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@FACTOR_CARGA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TFACTOR_CARGA.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PORC_USO_RALENTI", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPORC_USO_RALENTI.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_UREA_REAL", SqlDbType.Float).Value = Math.Round(CDec(TLTS_UREA_REAL.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@CVE_EVE", SqlDbType.Float).Value = CVE_EVE
            cmd.Parameters.Add("@EVE_PORC_TOLERANCIA", SqlDbType.Float).Value = Math.Round(EVE_PORC_TOLERANCIA, 6)
            cmd.Parameters.Add("@EVE_PORC_RALENTI", SqlDbType.Float).Value = Math.Round(EVE_PORC_RALENTI, 6)
            cmd.Parameters.Add("@PORC_TOLERANCIA", SqlDbType.Float).Value = Math.Round(CDec(TPORC_TOLERANCIA.Text), 6)
            cmd.Parameters.Add("@PORC_RALENTI", SqlDbType.Float).Value = Math.Round(CDec(TPORC_RALENTI.Text), 6)
            cmd.Parameters.Add("@NO_VIAJE", SqlDbType.VarChar).Value = TNO_VIAJE.Text
            cmd.Parameters.Add("@NO_LIQUI", SqlDbType.VarChar).Value = TNO_LIQUI.Text
            cmd.Parameters.Add("@LTS_FORANEOS", SqlDbType.Float).Value = TLTS_FORANEOS.Text
            cmd.Parameters.Add("@CALIF_VEL_MAX", SqlDbType.VarChar).Value = CALIF_VEL_MX
            cmd.Parameters.Add("@BONO_RES", SqlDbType.Float).Value = BONO_RES
            cmd.Parameters.Add("@NO_DE_VIAJES", SqlDbType.Float).Value = NO_DE_VIAJES
            cmd.Parameters.Add("@BONO_RES_VACIO", SqlDbType.Float).Value = BONO_RES_VACIO
            cmd.Parameters.Add("@NO_DE_VIAJES_VACIO", SqlDbType.Float).Value = NO_DE_VIAJES_VACIO

            cmd.Parameters.Add("@PORC_TOL_EVENTO2", SqlDbType.Float).Value = Math.Round(PORC_TOL_EVENTO2, 6)
            cmd.Parameters.Add("@LTS_AUTORIZADOS2", SqlDbType.Float).Value = Math.Round(CDec(TLTS_AUTORIZADOS2.Text.Replace(",", "")), 6)

            cmd.Parameters.Add("@LTS_VALES2", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtLTS_VALES2.Text.Trim.Replace(",", "")), 6)
            cmd.Parameters.Add("@LTS_DESCONTAR2", SqlDbType.Float).Value = Math.Round(CDec(TLTS_DESCONTAR2.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@PRECIO_X_LTS2", SqlDbType.Float).Value = Math.Round(CDec(TPRECIO_X_LTS2.Text.Replace(",", "")), 6)
            cmd.Parameters.Add("@EVENTO", SqlDbType.SmallInt).Value = IIf(ChEvento1.Checked, 0, 1)
            cmd.Parameters.Add("@EVENTO_LTS", SqlDbType.SmallInt).Value = IIf(RadLTS_ECM.Checked, 0, 1)
            cmd.Parameters.Add("@DESCXLITROS2", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtDescXLitros2.Text.Replace(",", ""))
            cmd.Parameters.Add("@TABULADOR", SqlDbType.SmallInt).Value = 1
            cmd.Parameters.Add("@HORAS_GEN3", SqlDbType.Float).Value = THORAS_GEN3.Value
            cmd.Parameters.Add("@HORAS_GEN4", SqlDbType.Float).Value = THORAS_GEN4.Value
            cmd.Parameters.Add("@HORAS_USO2", SqlDbType.Float).Value = THORAS_USO2.Value
            cmd.Parameters.Add("@CVE_EVA", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_EVA.Text)
            cmd.Parameters.Add("@LTS_GENERADOR2", SqlDbType.Float).Value = TLTS_GENERADOR2.Value

            cmd.Parameters.Add("@NUMGEN1", SqlDbType.VarChar).Value = TNUMGEN1.Text
            cmd.Parameters.Add("@NUMGEN2", SqlDbType.VarChar).Value = TNUMGEN2.Text
            cmd.Parameters.Add("@LTSDESCGEN", SqlDbType.Float).Value = TLTSDESCGEN.Value
            cmd.Parameters.Add("@DESCXLITROS", SqlDbType.Float).Value = DESCXLITROS
            cmd.Parameters.Add("@RPM_MAX", SqlDbType.Float).Value = RPM_MAX
            cmd.Parameters.Add("@CALIF_RPM", SqlDbType.Float).Value = CALIF_RPM
            If NewRecord Then
                returnValue = cmd.ExecuteScalar.ToString
                Try
                    CVE_RES = returnValue
                Catch ex As Exception
                    CVE_RES = 1
                End Try
                NewRecord = False
            Else
                returnValue = cmd.ExecuteNonQuery().ToString
                CVE_RES = TCVE_RES.Text
            End If
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If

                Select Case TIPO_TAB
                    Case 0
                        GRABAR_PARTIDAS_GASTOS()
                    Case 1
                        GRABAR_TAB_VIKINGOS_PAR()
                    Case 2
                        GRABAR_TAB_FLORES_PAR()
                End Select

                Try
                    If CONVERTIR_TO_DECIMAL(TLTS_LLEGADA.Text.Replace(",", "")) > 0 Or CONVERTIR_TO_DECIMAL(TLTS_SALIDA.Text.Replace(",", "")) > 0 Then
                        Try
                            Dim CLAVE_MED As Long

                            If IsNumeric(TLTS_LLEGADA.Tag.ToString) Then
                                CLAVE_MED = TLTS_LLEGADA.Tag.ToString
                                If CLAVE_MED > 0 Then
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_RES = " & CVE_RES & " WHERE CLAVE = " & CLAVE_MED
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            Dim CLAVE_MED As Long

                            If IsNumeric(TLTS_SALIDA.Tag.ToString) Then
                                CLAVE_MED = TLTS_SALIDA.Tag.ToString
                                If CLAVE_MED > 0 Then
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_RES = " & CVE_RES & " WHERE CLAVE = " & CLAVE_MED
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    SQL = "UPDATE GCPARAMGENERALES SET PRECIO_X_LTS = " & TPRECIO_X_LTS.Text
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                MsgBox("El registro se grabo satisfactoriamente")

                Try
                    If ARCHIVO.Trim.Length > 0 Then
                        Dim RutaArchivo = TPDF.Tag
                        Dim newPath = Path.Combine(RutaArchivo, ARCHIVO)

                        'FileCopy(newPath, RUTA_PDF & "\" & ARCHIVO)
                        RUTA_X = newPath & "  ---   " & RUTA_PDF & "\" & ARCHIVO

                        Dim Copier = New CopyFile_Ex
                        Copier.CopyEx(newPath, RUTA_PDF & "\" & ARCHIVO, True)
                        'File.Copy(newPath, RUTA_PDF & "\" & ARCHIVO)
                    End If
                Catch ex As Exception
                    Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_X)
                    'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                TCVE_RES.Text = CVE_RES

                If TIPO_TAB = 1 Then
                    BarNuevoVale.Visible = True
                End If

                BarImprimir_Click(Nothing, Nothing)

            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        NewRecord = False

    End Sub
    Sub GRABAR_TAB_FLORES_PAR()

        Dim KMS As Decimal, LITROS As Decimal, RENDIMIENTO As Decimal, CVE_TAB As String, CVE_VIAJE As String
        Dim FACTOR As Decimal

        If Not Valida_Conexion() Then
            Return
        End If
        Try
            If IsNumeric(TCVE_RES.Text) Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCRESET_TAB_FLORES_PAR SET STATUS = 'C' WHERE CVE_RES = " & CLng(TCVE_RES.Text)
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        'Try
        'Using cmd2 As SqlCommand = cnSAE.CreateCommand
        'SQL = "DELETE FROM GCRESET_TAB_FLORES_PAR WHERE CVE_RES = " & TCVE_RES.Text
        'cmd2.CommandText = SQL
        'returnValue = cmd2.ExecuteNonQuery().ToString
        'If returnValue IsNot Nothing Then
        'If returnValue = "1" Then
        'End If
        'End If
        'End Using
        'Catch ex As Exception
        'MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        'Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        'End Try
        Try
            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_TAB = 0
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_TAB = Fg(k, 1)
                        End If
                    Catch ex As Exception
                        Bitacora("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    If Not IsNothing(Fg(k, 2)) Then
                        CVE_VIAJE = Fg(k, 2)
                    Else
                        CVE_VIAJE = ""
                    End If
                    If CVE_VIAJE.Trim.Length > 0 And CVE_TAB.Trim.Length > 0 Then
                        If Not IsNothing(Fg(k, 18)) Then
                            If IsNumeric(Fg(k, 18)) Then
                                FACTOR = CDec(Fg(k, 18))
                            Else
                                FACTOR = 1
                            End If
                        Else
                            FACTOR = 1
                        End If

                        If Not IsNothing(Fg(k, 19)) Then
                            If IsNumeric(Fg(k, 19)) Then
                                KMS = Fg(k, 19)
                            Else
                                KMS = 0
                            End If
                        Else
                            KMS = 0
                        End If
                        If Not IsNothing(Fg(k, 20)) Then
                            If IsNumeric(Fg(k, 20)) Then
                                RENDIMIENTO = Fg(k, 20)
                            Else
                                RENDIMIENTO = 0
                            End If
                        Else
                            RENDIMIENTO = 0
                        End If
                        If Not IsNothing(Fg(k, 21)) Then
                            If IsNumeric(Fg(k, 21)) Then
                                LITROS = Fg(k, 21)
                            Else
                                LITROS = 0
                            End If
                        Else
                            LITROS = 0
                        End If

                        If Not Valida_Conexion() Then
                        End If

                        SQL = "INSERT INTO GCRESET_TAB_FLORES_PAR (CVE_TAB, NUM_PAR, CVE_VIAJE, STATUS, CVE_RES, KMS, 
                            FACTOR, KMS_REAL, RENDIMIENTO, LITROS, UUID) VALUES(@CVE_TAB, 
                            ISNULL((SELECT MAX(NUM_PAR) +1 FROM GCRESET_TAB_FLORES_PAR),1), 
                            @CVE_VIAJE, 'A', @CVE_RES, @KMS, @FACTOR, @KMS_REAL, @RENDIMIENTO, @LITROS, NEWID())"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = CVE_TAB
                            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = CVE_VIAJE
                            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
                            cmd.Parameters.Add("@FACTOR", SqlDbType.Float).Value = FACTOR
                            cmd.Parameters.Add("@KMS_REAL", SqlDbType.Float).Value = Math.Round((KMS * FACTOR), 4)
                            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = Math.Round(RENDIMIENTO, 2)
                            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = LITROS
                            cmd.Parameters.Add("@CVE_RES", SqlDbType.Float).Value = TCVE_RES.Text
                            returnValue = cmd.ExecuteNonQuery
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next


            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "DELETE FROM GCRESET_TAB_FLORES_PAR WHERE CVE_RES = " & CLng(TCVE_RES.Text) & " AND STATUS = 'C'"
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            MsgBox("Los tabuladores se grabaron satisfactoriamente")

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub

    Sub GRABAR_PARTIDAS_GASTOS()
        Dim CVE_ORI As Integer = 0, CVE_DES As Integer = 0, CLIENTE As String, CARGADO_VACIO As Integer = 0
        Dim KMS As Decimal = 0, LITROS As Decimal = 0, UUID As String, RENDIMIENTO As Decimal = 0, CVE_TAB As Long
        Dim CVE_OPER As Integer, CVE_UNI As String = "", TIPO_VIAJE As String

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCRESETEO_TABULADOR SET STATUS = 'C' WHERE CVE_RES = " & TCVE_RES.Text
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("170. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        SQL = "UPDATE GCRESETEO_TABULADOR SET CVE_OPER = @CVE_OPER, CVE_UNI = @CVE_UNI, TIPO_VIAJE = @TIPO_VIAJE, CVE_ORI = @CVE_ORI, 
            CVE_DES = @CVE_DES, CARGADO_VACIO = @CARGADO_VACIO, CLIENTE = @CLIENTE, KMS = @KMS, RENDIMIENTO = @RENDIMIENTO, 
            LITROS = @LITROS, STATUS = 'A' 
            WHERE UUID = @UUID 
            IF @@ROWCOUNT = 0 
            INSERT INTO GCRESETEO_TABULADOR (CVE_RES, CVE_OPER, CVE_UNI, NUM_PAR, STATUS, CVE_TAB, CVE_ORI, CVE_DES, CARGADO_VACIO, 
            TIPO_VIAJE, CLIENTE, KMS, RENDIMIENTO, LITROS, UUID) VALUES (@CVE_RES, @CVE_OPER, @CVE_UNI, 
            ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCRESETEO_TABULADOR WHERE CVE_RES = @CVE_RES),1),'A', @CVE_TAB, @CVE_ORI, @CVE_DES, 
            @CARGADO_VACIO, @TIPO_VIAJE, @CLIENTE, @KMS, @RENDIMIENTO, @LITROS, NEWID())"
        cmd.CommandText = SQL

        Try
            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_TAB = 0 : CVE_ORI = 0 : CLIENTE = "" : TIPO_VIAJE = "" : UUID = ""
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            If IsNumeric(Fg(k, 1).ToString.Trim) Then
                                CVE_TAB = Fg(k, 1).ToString.Trim
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            If IsNumeric(Fg(k, 2).ToString.Trim) Then
                                CVE_OPER = Fg(k, 2).ToString.Trim
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 4)) Then
                            CVE_UNI = Fg(k, 4)
                        End If
                    Catch ex As Exception
                        Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 5)) Then
                            CVE_ORI = Fg(k, 5)
                        End If
                    Catch ex As Exception
                        Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 11)) Then
                            CLIENTE = Fg(k, 11)
                        End If
                    Catch ex As Exception
                        Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If CVE_TAB > 0 Then
                        Try
                            CVE_DES = Fg(k, 7)
                            CARGADO_VACIO = IIf(Fg(k, 9) = "CARGADO", 1, 0)
                            TIPO_VIAJE = Fg(k, 10)
                            KMS = Fg(k, 13)
                            RENDIMIENTO = Fg(k, 14)
                            If RENDIMIENTO > 0 Then
                                LITROS = KMS / RENDIMIENTO
                            Else
                                LITROS = 0
                            End If
                            If Not IsNothing(Fg(k, 16)) Then
                                UUID = Fg(k, 16)
                            Else
                                UUID = ""
                            End If
                        Catch ex As Exception
                            Bitacora("275. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("275. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try

                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = TCVE_RES.Text
                        cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CVE_OPER
                        cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = CVE_UNI
                        cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CVE_TAB
                        cmd.Parameters.Add("@CVE_ORI", SqlDbType.Int).Value = CONVERTIR_TO_INT(CVE_ORI)
                        cmd.Parameters.Add("@CVE_DES", SqlDbType.Int).Value = CONVERTIR_TO_INT(CVE_DES)
                        cmd.Parameters.Add("@CARGADO_VACIO", SqlDbType.Int).Value = CARGADO_VACIO
                        cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.VarChar).Value = TIPO_VIAJE
                        cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLIENTE
                        cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
                        cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = RENDIMIENTO
                        cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = LITROS
                        cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("285. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("285. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "DELETE FROM GCRESETEO_TABULADOR WHERE CVE_RES = " & TCVE_RES.Text & " AND STATUS = 'C'"
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("300. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("300. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Catch ex As Exception
            MsgBox("310. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("310. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_TAB_VIKINGOS_PAR()

        Dim CVE_ORI As Integer, CVE_DES As Integer, CLIENTE As String, CARGADO_VACIO As Integer, TONELADAS As Decimal, KMS As Decimal
        Dim RENDIMIENTO As Decimal, CVE_OPER As Integer, CVE_UNI As String, TIPO_VIAJE As String, CVE_TAB As Long, LITROS As Decimal
        Dim NUM_VIAJE As Long, FOLIO_LIQ As Long, FECHA_IDA As Date, NOMBRE_OPER As String, NOMBRE_CLIE As String, ORIGEN As String
        Dim DESTINO As String

        If Fg.Rows.Count = 1 Then
            Return
        End If

        Try
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCRESET_TAB_VIKINGOS_PAR SET NUM_VIAJE = NUM_VIAJE * -1, STATUS = 'C' WHERE CVE_RES = " & TCVE_RES.Text
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
            For k = 1 To Fg.Rows.Count - 1
                Try
                    CVE_TAB = 0
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            If IsNumeric(Fg(k, 1)) Then
                                CVE_TAB = Fg(k, 1)
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    If Not IsNothing(Fg(k, 2)) Then
                        If IsNumeric(Fg(k, 2)) Then
                            NUM_VIAJE = Fg(k, 2)
                        Else
                            NUM_VIAJE = 0
                        End If
                    Else
                        NUM_VIAJE = 0
                    End If

                    If NUM_VIAJE > 0 And CVE_TAB > 0 Then

                        If Not IsNothing(Fg(k, 3)) Then
                            If IsNumeric(Fg(k, 3)) Then
                                FOLIO_LIQ = Fg(k, 3)
                            Else
                                FOLIO_LIQ = 0
                            End If
                        Else
                            FOLIO_LIQ = 0
                        End If

                        If Not IsNothing(Fg(k, 4)) Then
                            If IsNumeric(Fg(k, 4)) Then
                                CVE_OPER = Fg(k, 4)
                            Else
                                CVE_OPER = 0
                            End If
                        Else
                            CVE_OPER = 0
                        End If
                        If Not IsNothing(Fg(k, 5)) Then
                            NOMBRE_OPER = Fg(k, 5)
                        Else
                            NOMBRE_OPER = ""
                        End If

                        If Not IsNothing(Fg(k, 6)) Then
                            If IsDate(Fg(k, 6)) Then
                                FECHA_IDA = Fg(k, 6)
                            Else
                                FECHA_IDA = "01/01/1900"
                            End If
                        Else
                            FECHA_IDA = "01/01/1900"
                        End If
                        If Not IsNothing(Fg(k, 7)) Then
                            CVE_UNI = Fg(k, 7)
                        Else
                            CVE_UNI = ""
                        End If

                        If Not IsNothing(Fg(k, 8)) Then
                            TIPO_VIAJE = Fg(k, 8)
                        Else
                            TIPO_VIAJE = ""
                        End If

                        If Not IsNothing(Fg(k, 9)) Then
                            CLIENTE = Fg(k, 9)
                        Else
                            CLIENTE = ""
                        End If
                        If Not IsNothing(Fg(k, 10)) Then
                            NOMBRE_CLIE = Fg(k, 10)
                        Else
                            NOMBRE_CLIE = ""
                        End If

                        If Not IsNothing(Fg(k, 11)) Then
                            CVE_ORI = Fg(k, 11)
                        Else
                            CVE_ORI = 0
                        End If
                        If Not IsNothing(Fg(k, 12)) Then
                            ORIGEN = Fg(k, 12)
                        Else
                            ORIGEN = ""
                        End If

                        If Not IsNothing(Fg(k, 13)) Then
                            CVE_DES = Fg(k, 13)
                        Else
                            CVE_DES = 0
                        End If

                        If Not IsNothing(Fg(k, 14)) Then
                            DESTINO = Fg(k, 14)
                        Else
                            DESTINO = ""
                        End If

                        If Not IsNothing(Fg(k, 15)) Then
                            CARGADO_VACIO = IIf(Fg(k, 15) = "CARGADO", 1, 0)
                        Else
                            CARGADO_VACIO = 0
                        End If

                        If Not IsNothing(Fg(k, 16)) Then
                            If IsNumeric(Fg(k, 16)) Then
                                KMS = Fg(k, 16)
                            Else
                                KMS = 0
                            End If
                        Else
                            KMS = 0
                        End If

                        If Not IsNothing(Fg(k, 17)) Then
                            If IsNumeric(Fg(k, 17)) Then
                                RENDIMIENTO = Fg(k, 17)
                            Else
                                RENDIMIENTO = 0
                            End If
                        Else
                            RENDIMIENTO = 0
                        End If
                        If Not IsNothing(Fg(k, 18)) Then
                            If IsNumeric(Fg(k, 18)) Then
                                LITROS = Fg(k, 18)
                            Else
                                LITROS = 0
                            End If
                        Else
                            LITROS = 0
                        End If
                        Try
                            If Not IsNothing(Fg(k, 19)) Then
                                If IsNumeric(Fg(k, 19)) Then
                                    TONELADAS = Fg(k, 19)
                                Else
                                    TONELADAS = 0
                                End If
                            Else
                                TONELADAS = 0
                            End If
                        Catch ex As Exception
                            Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try

                        SQL = "IF NOT EXISTS (SELECT CVE_TAB FROM GCRESET_TAB_VIKINGOS_PAR WHERE NUM_VIAJE = @NUM_VIAJE)
                            BEGIN
                                INSERT INTO GCRESET_TAB_VIKINGOS_PAR (CVE_TAB, NUM_VIAJE, STATUS, FOLIO_LIQ, CVE_OPER, CVE_UNI, 
                                NOMBRE_OPER, TIPO_VIAJE, CLIENTE, NOMBRE_CLIE, CVE_ORI, ORIGEN, CVE_DES, DESTINO, CARGADO_VACIO, 
                                KMS, RENDIMIENTO, LITROS, TONELADAS, CVE_RES, FECHA_IDA)
                                VALUES(@CVE_TAB, @NUM_VIAJE, 'A', @FOLIO_LIQ, @CVE_OPER, @CVE_UNI, @NOMBRE_OPER, @TIPO_VIAJE, 
                                @CLIENTE, @NOMBRE_CLIE, @CVE_ORI, @ORIGEN, @CVE_DES, @DESTINO, @CARGADO_VACIO, @KMS, 
                                @RENDIMIENTO, @LITROS, @TONELADAS, @CVE_RES, @FECHA_IDA)
                            END"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CVE_TAB
                            cmd.Parameters.Add("@NUM_VIAJE", SqlDbType.Int).Value = NUM_VIAJE
                            cmd.Parameters.Add("@FOLIO_LIQ", SqlDbType.Int).Value = FOLIO_LIQ
                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CVE_OPER
                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = CVE_UNI
                            cmd.Parameters.Add("@NOMBRE_OPER", SqlDbType.VarChar).Value = NOMBRE_OPER
                            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.VarChar).Value = TIPO_VIAJE
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = CLIENTE
                            cmd.Parameters.Add("@NOMBRE_CLIE", SqlDbType.VarChar).Value = NOMBRE_CLIE
                            cmd.Parameters.Add("@CVE_ORI", SqlDbType.Int).Value = CVE_ORI
                            cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = ORIGEN
                            cmd.Parameters.Add("@CVE_DES", SqlDbType.Int).Value = CVE_DES
                            cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = DESTINO
                            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
                            cmd.Parameters.Add("@CARGADO_VACIO", SqlDbType.SmallInt).Value = CARGADO_VACIO
                            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = RENDIMIENTO
                            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = LITROS
                            cmd.Parameters.Add("@TONELADAS", SqlDbType.Float).Value = TONELADAS
                            cmd.Parameters.Add("@CVE_RES", SqlDbType.Float).Value = TCVE_RES.Text
                            cmd.Parameters.Add("@FECHA_IDA", SqlDbType.Date).Value = FECHA_IDA
                            returnValue = cmd.ExecuteNonQuery
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCTABULADOR_EXCEL SET CVE_RES = " & TCVE_RES.Text & " WHERE CVE_TAB = " & CVE_TAB
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try

                        End Using
                    End If

                Catch ex As Exception
                    Bitacora("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("95. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "DELETE FROM GCRESET_TAB_VIKINGOS_PAR WHERE STATUS = 'C' AND CVE_RES = " & TCVE_RES.Text
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                MsgBox("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("80. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try

            MsgBox("Los tabuladores se grabaron satisfactoriamente")
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles MnuSalir.Click
        Me.Close()
    End Sub

    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LtOper.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    TCVE_OPER.Text = ""
                    LtOper.Text = ""
                    TCVE_UNI.Select()
                End If
            End If

            If TIPO_TAB = 1 Then
                'VALIDA_DATOS_HORAS()
            End If

        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub VALIDA_DATOS_HORAS2()
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And TCVE_UNI.Text.Trim.Length > 0 Then
                TCVE_OPER.Text = TCVE_OPER.Text.Trim
                TCVE_UNI.Text = TCVE_UNI.Text.Trim

                If IsNumeric(TCVE_OPER.Text) Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT TOP 1 ISNULL(DESCT,0) AS DET, ISNULL(TIEMPO_MARCH_INERCIA,0) AS T_M_I 
                            FROM GCRESETEO WHERE STATUS = 'A' AND ISNULL(TIEMPO_MARCH_INERCIA,0) > 0 AND 
                            CVE_OPER = " & TCVE_OPER.Text & " AND CVE_UNI = '" & TCVE_UNI.Text & "'
                            ORDER BY FECHAELAB DESC"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                TDESCT.Value = dr("DET")
                                TTIEMPO_MARCH_INERCIA.Text = dr("T_M_I")
                                TCARGO_X_PUNTO_MUERTO.Value = dr("T_M_I") - dr("DET")
                            End If
                        End Using
                    End Using
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub

    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUni_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = "1"
                DESCR = BUSCA_CAT("Unidades3", TCVE_UNI.Text)
                If DESCR <> "" Then
                    LtUnidad.Text = Var4
                    TCVE_UNI.Tag = Var4

                    If Var5 = "0" Or Var5 = "" Then
                        TCVE_MOT.Text = ""
                        LtMotor.Text = ""
                    Else
                        TCVE_MOT.Text = Var5
                        LtMotor.Text = Var6
                    End If

                    'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                    'Var5 = dr.ReadNullAsEmptyString("CVEMOT").ToString
                    'Var6 = dr.ReadNullAsEmptyString("DESCR_MOTOR").ToString
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_UNI.Text = ""
                    LtUnidad.Text = ""
                    TCVE_UNI.Select()
                End If
            Else
                LtUnidad.Text = ""
            End If
            If TIPO_TAB = 1 Then
                'VALIDA_DATOS_HORAS()
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = ""
            Var5 = ""
            Var6 = ""
            Var7 = ""
            Var8 = ""
            Var9 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Var6 = ""
                Var7 = ""
                Var8 = ""
                Var9 = ""
                If TIPO_TAB = 1 Then
                    'VALIDA_DATOS_HORAS()
                End If
                TCVE_UNI.Focus()
            End If
        Catch Ex As Exception
            Bitacora("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUni_Click(sender As Object, e As EventArgs) Handles BtnUni.Click
        Try
            Var2 = "Unidades2"
            Var4 = "1" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "" : Var9 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString  '
                'Var3 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                'Var5 = Fg(Fg.Row, 2).ToString  'CLAVE MONTE
                'Var6 = Fg(Fg.Row, 3).ToString  'DESCR uni
                'Var7 = Fg(Fg.Row, 4).ToString  'PLACAS
                'Var8 = Fg(Fg.Row, 5).ToString  'DESCR TIPO UNIDAD
                'Var9 = Fg(Fg.Row, 6).ToString  'motor
                'Var10 = Fg(Fg.Row, 7).ToString  'NOMBRE MOTOR
                TCVE_UNI.Text = Var4
                TCVE_UNI.Tag = Var5
                LtUnidad.Text = Var5
                TCVE_MOT.Text = Var9
                If Var8 = "1" Then
                    Var10 += " FULL"
                Else
                    Var10 += " SENCILLO"
                End If
                LtMotor.Text = Var10
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "" : Var9 = ""
                If TIPO_TAB = 1 Then
                    'VALIDA_DATOS_HORAS()
                End If
                TCVE_MOT.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub THRS_TRABAJO_TextChanged(sender As Object, e As EventArgs) Handles THRS_TRABAJO.TextChanged
        CAL4()
    End Sub
    Private Sub THRS_PTO_RALENTI_TextChanged(sender As Object, e As EventArgs) Handles THRS_PTO_RALENTI.TextChanged
        CAL4()
    End Sub
    Private Sub TKM_ECM_TextChanged(sender As Object, e As EventArgs) Handles TKM_ECM.TextChanged
        CAL5()
        CAL1()
        CAL6()
        CAL9()
    End Sub
    Sub CAL1()
        Dim V1 As String, V2 As String, C1 As Single
        Try
            V1 = TKM_ECM.Text.Replace(",", "")
            V2 = TLTS_ECM.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtREND_ECM.Text = Format(C1, "##0.00")
            End If
        Catch ex As Exception
            Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub CAL2()
        Dim V1 As String, V2 As String, C1 As Single
        Try
            V1 = TLTS_REAL.Text.Replace(",", "")
            V2 = TLTS_ECM.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 = (C1 - 1) * 100
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtPORC_VAR_LTS_ECM_REAL.Text = Format(C1, "##0.00")
            End If
        Catch ex As Exception
            Bitacora("381. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("381. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL3()
        Dim V1 As String, V2 As String, C1 As Single

        Try
            V1 = TLTS_REAL.Text.Replace(",", "")
            V2 = TLTS_TAB.Text.Replace(",", "")
            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 = (C1 - 1) * 100
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtPORC_VAR_LTS_TAB_REAL.Text = Format(C1, "##0.00")
            End If
        Catch ex As Exception
            Bitacora("384. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("384. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL4()
        Try
            Dim V1 As String
            Dim V2 As String
            Dim C1 As Single
            V1 = "" : V2 = ""
            V1 = THRS_PTO_RALENTI.Text.Replace(",", "")
            V2 = THRS_TRABAJO.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 *= 100
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtPORC_TIEMPO_PTO_RALENTI.Text = Format(C1, "##0.00")
            End If
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL5()
        Try
            Dim V1 As String, V2 As String, C1 As Single
            V1 = "" : V2 = ""

            V1 = TLTS_PTO_RALENTI.Text.Replace(",", "")
            V2 = TLTS_ECM.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 *= 100
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtPORC_LTS_PTO_RALENTI.Text = Format(C1, "###,###,##0.00")
                Try
                    'LtPORC_LTS_PTO_RALENTI   ESTE SE MODIFICA
                    'tCAL_RAL_EVA
                    TCAL_RAL_EVA.Text = "0"

                    If IsNumeric(TPORC_USO_RALENTI.Text) Then
                        If C1 <= TPORC_USO_RALENTI.Text And C1 <> 0 Then
                            Try
                                TCAL_RAL_EVA.Text = TCALIF_RALENTI.Text   'tPORC_USO_RALENTI.Text
                                Dim CAL1 As Decimal, CAL2 As Decimal, CAL3 As Decimal, CAL44 As Decimal

                                Try
                                    If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                                        CAL1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                                    Else
                                        CAL1 = 0
                                    End If
                                Catch ex As Exception
                                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                                        CAL2 = TCAL_RAL_EVA.Text.Replace(",", "")
                                    Else
                                        CAL2 = 0
                                    End If
                                Catch ex As Exception
                                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    If IsNumeric(TCALIF_VEL_MX.Text.Replace(",", "")) Then
                                        CAL3 = TCALIF_VEL_MX.Text.Replace(",", "")
                                    Else
                                        CAL3 = 0
                                    End If
                                Catch ex As Exception
                                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                                        CAL44 = TCALIF_RPM.Text.Replace(",", "")
                                    Else
                                        CAL44 = 0
                                    End If
                                Catch ex As Exception
                                End Try

                                TCAL_GLO_EVA.Text = CAL1 + CAL2 + CAL3 + CAL44

                                If Not BONO_ESPECIAL Then
                                    Try
                                        If IsNumeric(TCVE_EVA.Text) AndAlso Convert.ToInt16(TCVE_EVA.Text) > 0 Then
                                            If IsNumeric(TCAL_GLO_EVA.Text) AndAlso Convert.ToDecimal(TCAL_GLO_EVA.Text) > 0 Then
                                                TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                                                TBONO_RES.Tag = TBONO_RES.Value
                                            End If
                                        End If

                                        If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                            TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                                        End If
                                    Catch ex As Exception
                                        Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Else
                                    PROC_BONO_ESPECIAL()
                                End If

                            Catch ex As Exception
                                Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Else
                            Dim CAL1 As Decimal, CAL2 As Decimal, CAL3 As Decimal, CAL44 As Decimal
                            Try
                                If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                                    CAL1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                                Else
                                    CAL1 = 0
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                                    CAL2 = TCAL_RAL_EVA.Text.Replace(",", "")
                                Else
                                    CAL2 = 0
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If IsNumeric(tCALIF_VEL_MX.Text.Replace(",", "")) Then
                                    CAL3 = tCALIF_VEL_MX.Text.Replace(",", "")
                                Else
                                    CAL3 = 0
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                                    CAL44 = TCALIF_RPM.Text.Replace(",", "")
                                Else
                                    CAL44 = 0
                                End If
                            Catch ex As Exception
                            End Try

                            If Not BONO_ESPECIAL Then
                                TCAL_GLO_EVA.Text = CAL1 + CAL2 + CAL3 + CAL44

                                If IsNumeric(TCVE_EVA.Text) AndAlso Convert.ToInt16(TCVE_EVA.Text) > 0 Then
                                    If IsNumeric(TCAL_GLO_EVA.Text) AndAlso Convert.ToDecimal(TCAL_GLO_EVA.Text) > 0 Then
                                        TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                                        TBONO_RES.Tag = TBONO_RES.Text
                                        Try
                                            If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                                TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                                            End If
                                        Catch ex As Exception
                                        End Try
                                    End If
                                End If
                            Else
                                PROC_BONO_ESPECIAL()
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL6()
        Try
            Dim V1 As String
            Dim V2 As String
            Dim C1 As Single

            V1 = "" : V2 = ""

            V1 = TKM_ECM.Text.Replace(",", "")
            V2 = TLTS_REAL.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If V1 = 0 Then

                    V1 = LtKMS_TAB.Text.Replace(",", "")
                    If IsNumeric(V1) AndAlso Convert.ToDecimal(V2) <> 0 Then
                        C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                        C1 = Math.Truncate(C1 * 1000) / 1000

                        LtREND_REAL.Text = Format(C1, "##0.00")
                    End If
                Else
                    If Convert.ToDecimal(V2) <> 0 Then
                        C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                        C1 = Math.Truncate(C1 * 1000) / 1000
                    Else
                        C1 = 0
                    End If
                    LtREND_REAL.Text = Format(C1, "##0.00")
                End If

            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL7()
        Try
            Dim V1 As String
            Dim V2 As String
            Dim C1 As Single

            V1 = "" : V2 = ""

            V1 = TLTS_ECM.Text.Replace(",", "")
            V2 = TLTS_REAL.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                C1 = Convert.ToDecimal(V1) - Convert.ToDecimal(V2)
                C1 = Math.Truncate(C1 * 1000) / 1000
                LtDIF_LTS_REAL_LTS_ECM.Text = Format(C1, "##0.00")
            End If
        Catch ex As Exception
            Bitacora("482. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("482. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL8()
        Try
            Dim V1 As String
            Dim V2 As String
            Dim C1 As Single

            V1 = "" : V2 = ""

            V1 = TLTS_TAB.Text.Replace(",", "")
            V2 = TLTS_REAL.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                C1 = Convert.ToDecimal(V1) - Convert.ToDecimal(V2)
                C1 = Math.Truncate(C1 * 1000) / 1000
                LtDIF_LTS_REAL_LTS_TAB.Text = Format(C1, "###,##0.00")
            End If
        Catch ex As Exception
            Bitacora("486. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("486. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CAL9()
        Try
            Dim V1 As String
            Dim V2 As String
            Dim C1 As Single

            V1 = "" : V2 = ""

            V1 = TKM_ECM.Text.Replace(",", "")
            V2 = TLTS_TAB.Text.Replace(",", "")

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    C1 = Convert.ToDecimal(V1) / Convert.ToDecimal(V2)
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                    'LtRENDIMIENTO_TAB.Text = Format(C1, "##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("496. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("496. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmReseteoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub
    Private Sub TLTS_PTO_RALENTI_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TLTS_PTO_RALENTI.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            TCVE_MOT.Focus()
        End If
    End Sub
    Private Sub TLTS_VALES_TextChanged(sender As Object, e As EventArgs) Handles TLTS_VALES.TextChanged
        Try
            Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
            Try
                LRC1 = TLTS_SALIDA.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            Try
                LRC2 = TLTS_VALES.Text
            Catch ex As Exception
            End Try
            Try
                LRC3 = TLTS_FORANEOS.Value
            Catch ex As Exception
            End Try
            Try
                LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
            TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

            If ChEvento1.Checked Then
                LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            Else
                LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            End If

            If RadLTS_ECM.Checked Then
                CALCULO_EVENTO2_LTS_DESCONTAR2()
            End If
            If RadLTS_TAB.Checked Then
                CALCULO_EVENTO2_LTS_TAB()
            End If

            CAL8()

            PROC_BONO_ESPECIAL()

        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub PROC_EVENTO1()
        Try
            Dim L1 As Decimal = 0, L2 As Decimal = 0, L3 As Decimal = 0, L4 As Decimal = 0
            Try
                L1 = TLTS_SALIDA.Text.Replace(",", "")

            Catch ex As Exception
            End Try
            Try
                L2 = TLTS_VALES.Value
            Catch ex As Exception
            End Try

            Try
                L3 = TLTS_FORANEOS.Value
            Catch ex As Exception
            End Try

            Try
                L4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            LtLTS_VALES.Text = Format(L1 + L2 + L3 - L4, "###,###,##0.00")
            LtLTS_VALES.Tag = Format(L1 + L2 + L3 - L4, "###,###,##0.00")

        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BtnLitrosSalida_Click(sender As Object, e As EventArgs) Handles BtnLitrosSalida.Click
        If TCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la unidad")
            Return
        End If
        Try
            Var2 = "Medicion combustible"
            Var4 = TCVE_UNI.Tag : Var5 = "" : Var6 = "" : Var20 = 1
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString   'M.CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString   'M.CLAVEMONTE
                'Var6 = Fg(Fg.Row, 4).ToString   'SUMA LITROS
                TLTS_SALIDA.Tag = Var4
                If Var6.Trim.Length > 0 Then
                    TLTS_SALIDA.Text = Format(Convert.ToDecimal(Var6), "###,###,##0.00")
                Else
                    TLTS_SALIDA.Text = 0
                End If
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = ""
                TLTS_VALES.Focus()
            Else
                If NumSelIte = 0 Then
                    TLTS_SALIDA.Text = 0
                End If
            End If
        Catch Ex As Exception
            Bitacora("540. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("540. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnLitrosEntrada_Click(sender As Object, e As EventArgs) Handles BtnLitrosEntrada.Click
        If TCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la unidad")
            Return
        End If
        Try
            Var2 = "Medicion combustible"
            Var20 = 0
            Var4 = TCVE_UNI.Tag : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 And Var6.Trim.Length > 0 Then
                TLTS_LLEGADA.Tag = Var4
                TLTS_LLEGADA.Text = Format(Convert.ToDecimal(Var6), "###,###,##0.00")
                If IsNumeric(Var6) Then
                    Try
                        Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
                        Try
                            LRC1 = TLTS_SALIDA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try
                        Try
                            LRC2 = TLTS_VALES.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC3 = TLTS_FORANEOS.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try

                        TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4

                        If ChEvento1.Checked Then
                            LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                            LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        End If

                        LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")

                        TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

                        If RadLTS_ECM.Checked Then
                            CALCULO_EVENTO2_LTS_DESCONTAR2()
                        End If
                        If RadLTS_TAB.Checked Then
                            CALCULO_EVENTO2_LTS_TAB()
                        End If


                    Catch ex As Exception
                        Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    TLTS_LLEGADA.Text = 0
                End If
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = ""
                TODOMETRO.Focus()
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub AGREGAR_PARTIDA_PAR_TAB()
        Dim ExistTab As Boolean, CVE_TAB As Long = 0, CVE_ORI As Long = 0, CLIENTE As String = ""
        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor

        Try
            Try
                For k = Fg.Rows.Count - 1 To 1 Step -1
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_TAB = Fg(k, 1)
                        Else
                            CVE_TAB = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            CVE_ORI = Fg(k, 2)
                        Else
                            CVE_ORI = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 7)) Then
                            CLIENTE = Fg(k, 7)
                        Else
                            CLIENTE = ""
                        End If
                    Catch ex As Exception
                    End Try
                    If CVE_TAB = 0 And CVE_ORI = 0 And CLIENTE.Trim.Length = 0 Then
                        Fg.RemoveItem(k)
                    End If
                Next
            Catch ex As Exception
                Bitacora("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            Dim nCopias As Integer = 0, Sigue As Boolean

            For k = 0 To aDATA.GetLength(0) - 1
                Try
                    Sigue = True
                    Try
                        If Not IsNothing(aDATA(k, 0)) Then
                            If Not IsNumeric(aDATA(k, 0)) Then
                                Sigue = False
                            End If
                        Else
                            Sigue = False
                        End If
                    Catch ex As Exception
                        Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        Sigue = False
                    End Try
                    If Sigue Then
                        'ExistTab = False
                        'For x = 1 To Fg.Rows.Count - 1
                        'If Fg(x, 1) = aDATA(k, 0) Then
                        'ExistTab = True
                        'Exit For
                        'End If
                        'Next
                        ExistTab = False
                        If Not ExistTab Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_TAB, CVE_OPER, O.NOMBRE AS NOMB_OPER, CVE_UNI, TIPO_VIAJE, CVE_ORI, ISNULL(P1.CIUDAD,'') AS DESCR_ORI, CVE_DES, 
                                ISNULL(P2.CIUDAD,'') AS DESCR_DES, 
                                ISNULL(CARGADO_VACIO,0) AS CAR_VAC, CLIENTE, C.NOMBRE AS NOMB_OP, ISNULL(KMS,0) As KM, ISNULL(RENDIMIENTO,0) As RENDI 
                                FROM GCTABULADOR_PAR T 
                                LEFT JOIN GCOPERADOR O On O.CLAVE = T.CVE_OPER 
                                LEFT JOIN GCCLIE_OP C On C.CLAVE = CLIENTE 
                                LEFT JOIN GCPLAZAS P1 On P1.CLAVE = CVE_ORI 
                                LEFT JOIN GCPLAZAS P2 On P2.CLAVE = CVE_DES 
                                WHERE CVE_TAB = " & aDATA(k, 0)
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    Do While dr.Read

                                        Try
                                            nCopias = 1
                                            If IsNumeric(aDATA(k, 1)) Then
                                                nCopias = CInt(aDATA(k, 1))
                                            End If
                                        Catch ex As Exception
                                            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try
                                        For z = 1 To nCopias
                                            Try
                                                Fg.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("CVE_OPER") & vbTab & dr("NOMB_OPER") & vbTab &
                                                    dr("CVE_UNI") & vbTab & dr("CVE_ORI") & vbTab & dr("DESCR_ORI") & vbTab & dr("CVE_DES") & vbTab &
                                                    dr("DESCR_DES") & vbTab & IIf(dr("CAR_VAC"), "CARGADO", "VACIO") & vbTab & dr("TIPO_VIAJE") & vbTab &
                                                    dr("CLIENTE") & vbTab & dr("NOMB_OP") & vbTab & dr("KM") & vbTab & dr("RENDI") & vbTab &
                                                    IIf(dr("RENDI") > 0, dr("KM") / dr("RENDI"), 0) & vbTab & "")
                                            Catch ex As Exception
                                                Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                MsgBox("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            End Try
                                        Next
                                    Loop
                                End Using
                            End Using
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
            CALCULA_RENDIMIENTO()

        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True

    End Sub
    Sub AGREGAR_PARTIDA_PAR_TAB_VIKINGOS()
        Dim s As String

        Fg.Redraw = False

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Try
            Dim ExistTab As Boolean = False, CVE_TAB As Long = 0, CVE_ORI As Long = 0, CLIENTE As String = ""
            Try
                For k = Fg.Rows.Count - 1 To 1 Step -1
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_TAB = Fg(k, 1)
                        Else
                            CVE_TAB = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            CVE_ORI = Fg(k, 2)
                        Else
                            CVE_ORI = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 7)) Then
                            CLIENTE = Fg(k, 7)
                        Else
                            CLIENTE = ""
                        End If
                    Catch ex As Exception
                    End Try

                    If CVE_TAB = 0 And CVE_ORI = 0 And CLIENTE.Trim.Length = 0 Then
                        Fg.RemoveItem(k)
                    End If
                Next
            Catch ex As Exception
                Bitacora("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            Dim nCopias As Integer = 0, Sigue As Boolean

            For k = 0 To aDATA.GetLength(0) - 1
                Try
                    Sigue = True
                    Try
                        If Not IsNothing(aDATA(k, 0)) Then
                            If Not IsNumeric(aDATA(k, 0)) Then
                                Sigue = False
                            End If
                        Else
                            Sigue = False
                        End If
                    Catch ex As Exception
                        Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        Sigue = False
                    End Try

                    If Sigue Then
                        For j = 1 To Fg.Rows.Count - 1
                            If Fg(j, 1) = aDATA(k, 0) Then
                                Sigue = False
                                Exit For
                            End If
                        Next
                    End If

                    If Sigue Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT T.CVE_TAB, T.NUM_VIAJE, T.STATUS, T.FOLIO_LIQ, T.CVE_OPER, T.CVE_UNI, T.NOMBRE_OPER, T.TIPO_VIAJE, T.CLIENTE,
                                    T.NOMBRE_CLIE, T.CVE_ORI, T.ORIGEN, T.CVE_DES, T.DESTINO, T.CARGADO_VACIO, T.KMS, T.RENDIMIENTO, T.LITROS, T.TONELADAS, 
                                    ISNULL(CVE_RES,0) AS CVE_RESET, FECHA_IDA
                                    FROM GCTABULADOR_EXCEL T 
                                    LEFT JOIN GCCLIE_OP C On C.CLAVE = T.CLIENTE 
                                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.CVE_ORI 
                                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.CVE_DES 
                                    WHERE CVE_TAB = " & aDATA(k, 0)

                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read

                                        s = dr("CVE_TAB") & vbTab & dr("NUM_VIAJE") & vbTab & dr("FOLIO_LIQ") & vbTab &
                                            dr("CVE_OPER") & vbTab & dr.ReadNullAsEmptyString("NOMBRE_OPER") & vbTab &
                                            dr.ReadNullAsEmptyString("FECHA_IDA") & vbTab & dr.ReadNullAsEmptyString("CVE_UNI") & vbTab &
                                            dr.ReadNullAsEmptyString("TIPO_VIAJE") & vbTab & dr("CLIENTE") & vbTab & dr("NOMBRE_CLIE") & vbTab &
                                            dr("CVE_ORI") & vbTab & dr.ReadNullAsEmptyString("ORIGEN") & vbTab & dr("CVE_DES") & vbTab &
                                            dr.ReadNullAsEmptyString("DESTINO") & vbTab &
                                            IIf(dr.ReadNullAsEmptyInteger("CARGADO_VACIO") = 0, "Vacio", "Cargado") & vbTab &
                                            dr("KMS") & vbTab & dr.ReadNullAsEmptyDecimal("RENDIMIENTO") & vbTab &
                                            dr("LITROS") & vbTab & dr.ReadNullAsEmptyDecimal("TONELADAS") & vbTab & IIf(dr("CVE_RESET") = 0, "", dr("CVE_RESET"))

                                        Fg.AddItem("" & vbTab & s)
                                    End While
                                End Using
                                Fg.AutoSizeCols()
                            End Using
                        Catch ex As Exception
                            Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            CALCULA_RENDIMIENTO_VIKINGOS()

        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub CALCULA_RENDIMIENTO_VIKINGOS(Optional CAL_OK As String = "")
        Dim S1 As Single = 0, S2 As Single = 0, S3 As Single = 0, z As Integer
        If CAL_OK = "N" Then
            Return
        End If
        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(k)
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("642. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length > 0 Then
                            Try
                                S1 += Fg(k, 16) 'KMS
                                S3 += Fg(k, 18) 'KMS
                            Catch ex As Exception
                            End Try
                            Try 'RENDIMIENTO
                                If Fg(k, 16) > 0 Then
                                    S2 += (Fg(k, 16) / Fg(k, 18))
                                End If
                            Catch ex As Exception
                                Bitacora("645. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                            z += 1
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("645. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            If z > 0 Then
                Fg.AddItem("" & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                           " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                           "---------------------------" & vbTab & " " & vbTab & " " & vbTab & " ")
                '16 17 18                 1             2             3             4             5             6     
                Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                           " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab &
                           "CALCULOS" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & S1 & vbTab & IIf(S3 > 0, (S1 / S3), 0) & vbTab & S3)
                '           7             8             9             10           11  
                '             12                13           14           15           16                      17                        18
            End If
            TLTS_TAB.Text = Format(S3, "###,###,##0.00")

            LtKMS_TAB.Text = Format(S1, "###,###,##0.00")
            If S3 > 0 Then
                LtREND_TAB.Text = Format(S1 / S3, "###,###,##0.00")
            End If

        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULA_RENDIMIENTO(Optional CAL_OK As String = "")

        Dim S1 As Single = 0, S2 As Single = 0, S3 As Single = 0, z As Integer

        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(k)
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("642. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length > 0 Then
                            Try
                                S1 += Fg(k, 13)
                                S3 += Fg(k, 15)
                            Catch ex As Exception
                            End Try
                            Try
                                If Fg(k, 14) > 0 Then
                                    S2 += (Fg(k, 13) / Fg(k, 14))
                                End If
                            Catch ex As Exception
                            End Try
                            z += 1
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("645. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            If z > 0 Then
                Fg.AddItem("" & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & "---------------------------" & vbTab &
                           " " & vbTab & " " & vbTab & " ")

                Fg.AddItem(" " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & "CALCULOS" & vbTab &
                               S1 & vbTab & IIf(S2 > 0, (S1 / S2), 0) & vbTab & S3)
            End If

            If CAL_OK <> "N" Then
                TLTS_TAB.Text = Format(S3, "###,###,##0.00")
                LtKMS_TAB.Text = Format(S1, "###,###,##0.00")
                If S2 > 0 Then
                    LtREND_TAB.Text = Format(S1 / S2, "###,###,##0.00")
                End If
            End If

            PROC_BONO_ESPECIAL

        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Sub PROC_BONO_ESPECIAL()
        Try
            If BONO_ESPECIAL Or BONO_ESPECIAL_DESCR = "TABULADOR FULL" Or BONO_ESPECIAL_DESCR = "TABULADOR SENCILLO" Or BONO_ESPECIAL_DESCR = "TABULADOR FULL/SENCILLO" Then
                If ChEvento2.Checked Then
                    Try
                        If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) AndAlso IsNumeric(TLTS_TAB.Text.Replace(",", "")) Then
                            If Convert.ToDecimal(TLTS_TAB.Text.Replace(",", "")) > Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", "")) Then

                                If BONO_ESPECIAL_DESCR = "TABULADOR FULL" Or BONO_ESPECIAL_DESCR = "TABULADOR FULL/SENCILLO" Then
                                    TBONO_RES.Value = TBONO.Text
                                    TBONO_RES.Tag = TBONO_RES.Value
                                    TBONO_RES_VACIO.Value = 0
                                    TBONO_RES_VACIO.Tag = 0

                                    If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                        TBONO_RES.Value = TBONO_RES.Value * TNO_VIAJES.Value
                                    End If
                                Else
                                    TBONO_RES.Value = 0
                                    TBONO_RES.Tag = 0
                                    TBONO_RES_VACIO.Value = TBONO.Text
                                    TBONO_RES_VACIO.Tag = TBONO_RES_VACIO.Value

                                    If Convert.ToDecimal(TBONO_RES_VACIO.Value) > 0 And TNO_VIAJES_VACIO.Value > 0 Then
                                        TBONO_RES_VACIO.Value = TBONO_RES_VACIO.Value * TNO_VIAJES_VACIO.Value
                                    End If
                                End If
                            Else
                                TBONO_RES.Value = 0
                                TBONO_RES.Tag = TBONO_RES.Value
                                TBONO_RES_VACIO.Value = 0
                                TBONO_RES_VACIO.Tag = TBONO_RES.Value
                            End If
                        Else
                            TBONO_RES.Value = 0
                            TBONO_RES.Tag = TBONO_RES.Value
                            TBONO_RES_VACIO.Value = 0
                            TBONO_RES_VACIO.Tag = TBONO_RES.Value
                        End If
                    Catch ex As Exception
                        Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnAlta_Click(sender As Object, e As EventArgs) Handles BtnAlta.Click
        Try
            Select Case TIPO_TAB
                Case 0 'LUTSA
                    Var2 = "ReseteoTab"
                    FrmSelItemReseteoTab.ShowDialog()
                    If Not IsNothing(aDATA) Then
                        If aDATA.Length > 0 Then
                            AGREGAR_PARTIDA_PAR_TAB()
                        End If
                    End If
                    Var2 = ""
                Case 1
                    If TCVE_OPER.Text.Trim.Length = 0 Then
                        MsgBox("Por favor seleccione el operador")
                        Return
                    End If
                    If TCVE_UNI.Text.Trim.Length = 0 Then
                        MsgBox("Por favor seleccione el operador")
                        Return
                    End If

                    Var2 = "ReseteoTab"
                    Var3 = TCVE_OPER.Text
                    Var4 = TCVE_UNI.Tag

                    FrmSelItemTabVikingos.ShowDialog()
                    If Not IsNothing(aDATA) Then
                        If aDATA.Length > 0 Then
                            AGREGAR_PARTIDA_PAR_TAB_VIKINGOS()
                        End If
                    End If
                    Var2 = ""
                Case 2
                    If TCVE_OPER.Text.Trim.Length = 0 Then
                        MsgBox("Por favor capture el operador")
                        Return
                    End If
                    If TCVE_UNI.Text.Trim.Length = 0 Then
                        MsgBox("Por favor capture la unidad")
                        Return
                    End If

                    Var2 = "ReseteoTab"
                    Var3 = TCVE_OPER.Text
                    Var4 = TCVE_UNI.Tag

                    Try
                        If Fg.Rows.Count > 1 Then
                            ReDim aDOCS(Fg.Rows.Count - 3)

                            For k = 1 To aDOCS.Length - 1
                                If Not IsNothing(Fg(k, 2)) Then
                                    aDOCS(k - 1) = Fg(k, 2)
                                End If
                            Next
                        Else
                            ReDim aDOCS(0)
                            aDOCS(0) = ""
                        End If
                    Catch ex As Exception
                        Bitacora("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    FrmSelItemTabFlores.ShowDialog()
                    If Not IsNothing(aDATA) Then
                        If aDATA.Length > 0 Then
                            AGREGAR_PARTIDA_PAR_TAB_FLORES()
                        End If
                    End If
                    Var2 = ""
            End Select
            CAL8()

        Catch Ex As Exception
            Bitacora("750. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("750. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Sub AGREGAR_PARTIDA_PAR_TAB_FLORES()
        Dim CADENA1 As String, CVE_TAB As Long = 0, CVE_ORI As Long = 0, s As String
        Dim Sigue As Boolean

        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor
        Try
            Try
                For k = Fg.Rows.Count - 1 To 1 Step -1
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_TAB = Fg(k, 1)
                        Else
                            CVE_TAB = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            CVE_ORI = Fg(k, 2)
                        Else
                            CVE_ORI = 0
                        End If
                    Catch ex As Exception
                    End Try
                    If CVE_TAB = 0 And CVE_ORI = 0 Then
                        Fg.RemoveItem(k)
                    End If
                Next
            Catch ex As Exception
                Bitacora("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("570. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                Try
                    Sigue = True
                    Try
                        If Not IsNothing(aDATA(k, 0)) Then
                            If Not IsNumeric(aDATA(k, 0)) Then
                                Sigue = False
                            End If
                        Else
                            Sigue = False
                        End If
                    Catch ex As Exception
                        Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        Sigue = False
                    End Try

                    If Sigue Then
                        For j = 1 To Fg.Rows.Count - 1
                            If Fg(j, 2) = aDATA(k, 0) Then
                                Sigue = False
                                Exit For
                            End If
                        Next
                    End If
                    'aDATA(z, 0) = Fg(k, 4) 'CVE_VIAJE
                    'aDATA(z, 1) = Fg(k, 2) 'CVE_TAB
                    'aDATA(z, 2) = Fg(k, 3) 'NCOPIAS

                    If Sigue Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT TOP 5000 A.CVE_VIAJE, A.STATUS, R.CVE_TAB, A.CVE_TRACTOR, A.FECHA, 
                                    (CASE A.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS TIPOUNI, A.CLAVE_O, OP1.NOMBRE AS NOMBRE1, 
                                    OP1.CVE_PLAZA AS PLAZA1, P1.CIUDAD AS CIUDAD1, A.CLAVE_D, OP2.NOMBRE AS NOMBRE2, OP2.CVE_PLAZA AS PLAZA2, 
                                    P2.CIUDAD AS CIUDAD2, R.KMS, A.FECHA_CARGA, 
                                    CASE WHEN A.STATUS = 'C' THEN 'CANCELADO' ELSE (CAST(A.CVE_ST_VIA AS VARCHAR(6)) + '. ' + S.DESCR) END AS STATUSVIAJE, 
                                    RE.DESCR AS ORIGUEN, EE.DESCR AS DESTINO, U.CVE_REND, R.AUTO_SENC, R.P4_SENC, R.AUTO_SENC_LTS, R.P4_SENC_LTS,
                                    R.FULL_AUTO, R.FULL_P4, R.FULL_AUTO_LTS, R.FULL_P4_LTS, CVE_CAP1, CVE_CAP2
                                    FROM GCASIGNACION_VIAJE A 
                                    LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                                    LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON
                                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                                    LEFT JOIN GCCLIE_OP OP1 ON OP1.CLAVE = A.CLAVE_O
                                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP1.CVE_PLAZA
                                    LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = A.CLAVE_D
                                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP2.CVE_PLAZA
                                    LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                                    LEFT JOIN GCRECOGER_EN_ENTREGAR_EN RE ON RE.CVE_REG = A.RECOGER_EN
                                    LEFT JOIN GCRECOGER_EN_ENTREGAR_EN EE ON EE.CVE_REG = A.ENTREGAR_EN
                                    WHERE A.CVE_VIAJE = '" & aDATA(k, 0) & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read
                                        '("Autónomo")   0 '("P4")         1
                                        ''aDATA(z, 0) = Fg(k, 4) 'CVE_VIAJE
                                        'aDATA(z, 1) = Fg(k, 2) 'CVE_TAB
                                        'aDATA(z, 2) = Fg(k, 3) 'NCOPIAS
                                        Try
                                            'nCopias = 1
                                            'If IsNumeric(aDATA(k, 2)) Then
                                            'nCopias = CDec(aDATA(k, 2))
                                            'nCopiDec = nCopias - CInt(nCopias)
                                            'If nCopiDec > 0 Then
                                            'If nCopiDec = 0.5 Then
                                            'nCopias = CInt(nCopias) + 1
                                            'Else
                                            'nCopiDec = 0
                                            'End If
                                            'End If
                                            'End If
                                        Catch ex As Exception
                                            Bitacora("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try

                                        'For z = 1 To nCopias
                                        If dr.ReadNullAsEmptyString("TIPOUNI") = "Full" Then
                                            If dr.ReadNullAsEmptyInteger("CVE_REND") = 0 Then
                                                CADENA1 = Math.Round(dr("FULL_AUTO"), 2) & vbTab & dr("FULL_AUTO_LTS")
                                            Else
                                                CADENA1 = Math.Round(dr("FULL_P4"), 2) & vbTab & dr("FULL_P4_LTS")
                                            End If
                                        Else
                                            If dr.ReadNullAsEmptyInteger("CVE_REND") = 0 Then
                                                CADENA1 = Math.Round(dr("AUTO_SENC"), 2) & vbTab & dr("AUTO_SENC_LTS")
                                            Else
                                                CADENA1 = Math.Round(dr("P4_SENC"), 2) & vbTab & dr("P4_SENC_LTS")
                                            End If
                                        End If
                                        'If nCopiDec > 0 Then
                                        'If z = nCopias Then
                                        's2 = dr("KMS") / 2 & vbTab & CADENA2 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                                        'Else
                                        's2 = dr("KMS") & vbTab & CADENA1 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                                        'End If
                                        'Else
                                        's2 = dr("KMS") & vbTab & CADENA1 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                                        'End If
                                        '           15                           16                         17                     18
                                        's &= dr("FECHA_CARGA") & vbTab & dr("STATUSVIAJE") & vbTab & dr("ORIGUEN") & vbTab & dr("DESTINO") & vbTab
                                        '                       1                        2                        3
                                        s = "" & vbTab & dr("CVE_TAB") & vbTab & dr("CVE_VIAJE") & vbTab & dr("STATUS") & vbTab
                                        '            4                                               5                      6
                                        s &= dr("CVE_TRACTOR") & vbTab & dr.ReadNullAsEmptyString("FECHA") & vbTab & dr("TIPOUNI") & vbTab
                                        '           7                       8                      9                       10  
                                        s &= dr("CLAVE_O") & vbTab & dr("NOMBRE1") & vbTab & dr("PLAZA1") & vbTab & dr("CIUDAD1") & vbTab
                                        '           11                      12                     13                      14
                                        s &= dr("CLAVE_D") & vbTab & dr("NOMBRE2") & vbTab & dr("PLAZA2") & vbTab & dr("CIUDAD2") & vbTab
                                        '           15                           16                         17                     18
                                        s &= dr("FECHA_CARGA") & vbTab & dr("STATUSVIAJE") & vbTab & dr("ORIGUEN") & vbTab & 1 & vbTab
                                        '         19             20   21               22               23 24                   25                       26    
                                        s &= dr("KMS") & vbTab & CADENA1 & vbTab & dr("KMS") & vbTab & CADENA1 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                                        Fg.AddItem(s)
                                        'Next
                                    End While
                                End Using
                                Fg.AutoSizeCols()

                            End Using
                        Catch ex As Exception
                            Bitacora("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            MsgBox("55. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            CALCULA_RENDIMIENTO_FLORES()

        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        Fg.Redraw = True
    End Sub
    Sub CALCULA_RENDIMIENTO_FLORES(Optional CAL_OK As String = "")
        Dim S1 As Single = 0, S2 As Single = 0, S3 As Single = 0, z As Integer
        If CAL_OK = "N" Then
            Return
        End If
        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(k)
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("642. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Trim.Length > 0 Then
                            Try
                                S1 += Fg(k, 19) 'KMS

                                If Not IsNothing(Fg(k, 20)) Then
                                    If IsNumeric(Fg(k, 20)) Then
                                        If CDec(Fg(k, 20)) > 0 Then
                                            S2 += CDec(Fg(k, 19)) / CDec(Fg(k, 21)) 'RENDIMIENTO 
                                        End If
                                    End If
                                End If
                                S3 += Fg(k, 21) 'litros
                            Catch ex As Exception
                            End Try
                            z += 1
                        End If
                    Else
                        Fg.RemoveItem(k)
                    End If
                Catch ex As Exception
                    Bitacora("645. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            If z > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "---------------------------" & vbTab & "" & vbTab & "" & vbTab & "")

                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "CALCULOS" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           S1 & vbTab & S2 & vbTab & S3)
                '          19          20             21   22                   23 
            End If
            TLTS_TAB.Text = Format(S3, "###,###,##0.00")
            LtKMS_TAB.Text = Format(S1, "###,###,##0.00")
            If S3 > 0 Then
                LtREND_TAB.Text = Format(S1 / S3, "###,###,##0.00")
            End If

        Catch ex As Exception
            Bitacora("665. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog With {
                .Filter = "Archivos PDF (*.pdf)|*.pdf",
                .FilterIndex = 1,
                .RestoreDirectory = True
            }
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then

                Dim RutaArchivo = Path.GetDirectoryName(openExcelFileDialog.FileName)
                Dim file = Path.GetFileName(openExcelFileDialog.FileName)

                tPDF.Text = file
                tPDF.Tag = RutaArchivo
            Else
                tPDF.Text = ""
            End If
        Catch ex As Exception
            Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAbrirPDF_Click(sender As Object, e As EventArgs) Handles BtnAbrirPDF.Click
        Dim HayError As Boolean = False
        Try
            If tPDF.Text.Trim.Length > 0 Then
                If File.Exists(RUTA_DOC & "\" & tPDF.Text) Then
                    FILE_PDF = RUTA_DOC & "\" & tPDF.Text
                    FrmOPenPDFGrapecity.Show()
                Else
                    If File.Exists(Application.StartupPath & "\" & tPDF.Text) Then
                        FILE_PDF = Application.StartupPath & "\" & tPDF.Text
                        FrmOPenPDFGrapecity.Show()
                    Else
                        If File.Exists(tPDF.Tag & "\" & tPDF.Text) Then
                            FILE_PDF = tPDF.Tag & "\" & tPDF.Text
                            FrmOPenPDFGrapecity.Show()
                        Else
                            MsgBox("No existe el archivo " & FILE_PDF)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            HayError = True
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & FILE_PDF)
        End Try
        If HayError Then
            Try
                If tPDF.Text.Trim.Length > 0 Then
                    If File.Exists(RUTA_DOC & "\" & tPDF.Text) Then
                        Process.Start(RUTA_DOC & "\" & tPDF.Text)
                    Else
                        If File.Exists(Application.StartupPath & "\" & tPDF.Text) Then
                            Process.Start(Application.StartupPath & "\" & tPDF.Text)
                        Else
                            If File.Exists(tPDF.Tag & "\" & tPDF.Text) Then
                                Process.Start(tPDF.Tag & "\" & tPDF.Text)
                            Else
                                MsgBox("No existe el archivo " & FILE_PDF)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("822. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & FILE_PDF)
            End Try
        End If
    End Sub
    Private Sub BtnAbrirCarpeta_Click(sender As Object, e As EventArgs) Handles BtnAbrirCarpeta.Click
        Try
            If Directory.Exists(RUTA_DOC) Then
                Process.Start("explorer.exe", RUTA_DOC)
            Else
                Process.Start(Application.StartupPath)
            End If
        Catch ex As Exception
            Bitacora("830. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String = ""
        Try
            Select Case TIPO_TAB
                Case 0
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportReseteo.mrt"
                Case 1
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportReseteoExcel.mrt"
                Case 2
                    RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportReseteoViajes.mrt"
            End Select

            If Not File.Exists(RUTA_FORMATOS) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_RES") = TCVE_RES.Text
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarFinReseteo_Click(sender As Object, e As EventArgs) Handles BarFinReseteo.Click
        Try
            If MsgBox("Realmente desea finalizar el reseteo?", vbYesNo) = vbYes Then

                Dim LTS_REAL As Decimal
                Try
                    If Not IsNothing(TLTS_REAL.Text) AndAlso IsNumeric(TLTS_REAL.Text.Replace(",", "")) Then
                        LTS_REAL = CDec(TLTS_REAL.Text.Replace(",", ""))
                    Else
                        LTS_REAL = 0
                    End If

                    If LTS_REAL = 0 Then
                        MsgBox("No es posible finalizar el reseteo hasta que litros reales (Litros físicos) sea mayor a cero")
                        Return
                    End If
                Catch ex As Exception
                    Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                SQL = "UPDATE GCRESETEO SET ESTADO = 'FINALIZADO' WHERE CVE_RES = '" & TCVE_RES.Text & "'"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                    MsgBox("El reseteo se finalizó correctamente")

                    Fg.AllowEditing = False
                    BtnAlta.Enabled = False
                    BtnBaja.Enabled = False
                    BarFinReseteo.Enabled = False
                    SET_ALL_CONTROL_READ_AND_ENABLED(Split1)
                    BtnAbrirPDF.Enabled = True
                    BtnAbrirCarpeta.Enabled = True
                    BarNuevoVale.Enabled = False

                End Using
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTIEMPO_MARCH_INERCIA_KeyDown(sender As Object, e As KeyEventArgs) Handles TTIEMPO_MARCH_INERCIA.KeyDown
        Try
            TTIEMPO_MARCH_INERCIA.Select()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnMotor_Click(sender As Object, e As EventArgs) Handles BtnMotor.Click
        Try
            Var2 = "Motor"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_MOT.Text = Var4
                LtMotor.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                'DESPLEGAR_EVA_MOTOR()
                TLTS_LLEGADA.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_EVA(FCVE_EVA As Integer)
        Try
            CALCULO_POSITIVO = False
            BONO_ESPECIAL = False

            Using cmd As SqlCommand = cnSAE.CreateCommand
                If FCVE_EVA > 0 Then
                    SQL = "SELECT C.CVE_EVA, C.CVE_MOT, C.FACTOR_CARGA, C.CALIF_FACTOR_CARGA, C.PORC_USO_RALENTI, C.CALIF_RALENTI, 
                        C.UUID, CAL_FAC_CAR_EVA, CAL_RAL_EVA, PONDE_FC, PONDE_RALENTI, VEL_MAX, CALIF_VEL_MAX, TIPO_VIAJE,
                        C.CALIF_GLOBAL, C.CALIF_GLOBAL2, C.CALIF_GLOBAL3, C.CALIF_GLOBAL4, C.CALIF_GLOBAL5, C.CALIF_GLOBAL6, C.CALIF_GLOBAL7, 
                        C.BONO, C.BONO2, C.BONO3, C.BONO4, C.BONO5, C.BONO6, C.BONO7, ISNULL(CALCULO_POSITIVO,0) AS CAL_POS, 
                        RPM_MAX, PON_RPM_MAX, CALIF_RPM_MAX, ISNULL(DESCR,'') AS DES
                        FROM GCCATEVA C 
                        WHERE CVE_EVA = " & FCVE_EVA & ""
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Try
                                TFACTOR_CARGA.Text = dr("FACTOR_CARGA").ToString
                                TCALIF_FACTOR_CARGA.Text = dr("CALIF_FACTOR_CARGA").ToString
                                TPORC_USO_RALENTI.Text = dr("PORC_USO_RALENTI").ToString
                                TCALIF_RALENTI.Text = dr("CALIF_RALENTI").ToString
                                TCALIF_GLOBAL.Text = dr("CALIF_GLOBAL").ToString
                                TCALIF_GLOBAL2.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL2").ToString
                                TCALIF_GLOBAL3.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL3").ToString
                                TCALIF_GLOBAL4.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL4").ToString
                                TCALIF_GLOBAL5.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL5").ToString
                                TCALIF_GLOBAL6.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL6").ToString
                                TCALIF_GLOBAL7.Text = dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL7").ToString
                                TBONO.Text = dr("BONO").ToString
                                TBONO2.Text = dr.ReadNullAsEmptyDecimal("BONO2").ToString
                                TBONO3.Text = dr.ReadNullAsEmptyDecimal("BONO3").ToString
                                TBONO4.Text = dr.ReadNullAsEmptyDecimal("BONO4").ToString
                                TBONO5.Text = dr.ReadNullAsEmptyDecimal("BONO5").ToString
                                TBONO6.Text = dr.ReadNullAsEmptyDecimal("BONO6").ToString
                                TBONO7.Text = dr.ReadNullAsEmptyDecimal("BONO7").ToString

                                LTRPM_MAX.Text = dr.ReadNullAsEmptyDecimal("RPM_MAX").ToString
                                LTCALIF_RPM_MAX.Text = dr.ReadNullAsEmptyDecimal("CALIF_RPM_MAX").ToString

                                If TRPM_MAX.Value > CDec(LTRPM_MAX.Text) Then
                                    TCALIF_RPM.Text = "0"
                                Else
                                    TCALIF_RPM.Text = LTCALIF_RPM_MAX.Text
                                End If

                                If dr("CAL_POS") = 0 Then
                                    CALCULO_POSITIVO = False
                                Else
                                    CALCULO_POSITIVO = True
                                End If
                            Catch ex As Exception
                                Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                TCALIF_VEL_MAX.Text = dr.ReadNullAsEmptyDecimal("CALIF_VEL_MAX")
                                TMOTOR.Text = BUSCA_CAT("Motor", dr("CVE_MOT"))
                                TTIPO_VIAJE.Text = IIf(dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 1, "Full", "Sencillo")

                                'LtMotor.Text = TMOTOR.Text & " " & TTIPO_VIAJE.Text

                                TVEL_MAX.Text = dr.ReadNullAsEmptyDecimal("VEL_MAX")
                                TCALIF_VEL_MAX.Text = dr.ReadNullAsEmptyDecimal("CALIF_VEL_MAX")
                            Catch ex As Exception
                                Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                TFACTOR_CARGA.Tag = dr.ReadNullAsEmptyDecimal("PONDE_FC").ToString
                                TPORC_USO_RALENTI.Tag = dr.ReadNullAsEmptyDecimal("PONDE_RALENTI").ToString

                                Dim CAL1 As Decimal, CAL2 As Decimal, CAL3 As Decimal, CAL44 As Decimal

                                Try
                                    If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                                        CAL1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                                    Else
                                        CAL1 = 0
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                                        CAL2 = TCAL_RAL_EVA.Text.Replace(",", "")
                                    Else
                                        CAL2 = 0
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsNumeric(tCALIF_VEL_MX.Text.Replace(",", "")) Then
                                        CAL3 = tCALIF_VEL_MX.Text.Replace(",", "")
                                    Else
                                        CAL3 = 0
                                    End If
                                Catch ex As Exception
                                End Try
                                Try
                                    If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                                        CAL44 = TCALIF_RPM.Text.Replace(",", "")
                                    Else
                                        CAL44 = 0
                                    End If
                                Catch ex As Exception
                                End Try

                                TCAL_GLO_EVA.Text = CAL1 + CAL2 + CAL3 + CAL44

                            Catch ex As Exception
                                Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                TFACTOR_CARGA.Tag = "0"
                                TPORC_USO_RALENTI.Tag = "0"
                            End Try

                            CAL5()
                            CALC_CAL_GLO_EVA()
                            VELMAX_CAMBIA()

                            BONO_ESPECIAL_DESCR = ""

                            If dr("DES") = "TABULADOR FULL" Or dr("DES") = "TABULADOR SENCILLO" Or dr("DES") = "TABULADOR FULL/SENCILLO" Then
                                If ChEvento2.Checked Then

                                    BONO_ESPECIAL_DESCR = dr("DES")

                                    Try
                                        If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) AndAlso IsNumeric(TLTS_TAB.Text.Replace(",", "")) Then
                                            If Convert.ToDecimal(TLTS_TAB.Text.Replace(",", "")) > Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", "")) Then

                                                If dr("DES") = "TABULADOR FULL" Or dr("DES") = "TABULADOR FULL/SENCILLO" Then
                                                    TBONO_RES.Value = TBONO.Text
                                                    TBONO_RES.Tag = TBONO_RES.Value
                                                    TBONO_RES_VACIO.Value = 0
                                                    TBONO_RES_VACIO.Tag = 0

                                                    If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                                        TBONO_RES.Value = TBONO_RES.Value * TNO_VIAJES.Value
                                                    End If
                                                Else
                                                    TBONO_RES_VACIO.Value = TBONO.Text
                                                    TBONO_RES_VACIO.Tag = TBONO_RES_VACIO.Value
                                                    TBONO_RES.Value = 0
                                                    TBONO_RES.Tag = 0

                                                    If Convert.ToDecimal(TBONO_RES_VACIO.Value) > 0 Then
                                                        TBONO_RES_VACIO.Value = TBONO_RES_VACIO.Value * TNO_VIAJES_VACIO.Value
                                                    End If
                                                End If

                                                BONO_ESPECIAL = True
                                            Else
                                                TBONO_RES.Value = 0
                                                TBONO_RES.Tag = TBONO_RES.Value
                                                TBONO_RES_VACIO.Value = 0
                                                TBONO_RES_VACIO.Tag = TBONO_RES.Value
                                            End If
                                        Else
                                            TBONO_RES.Value = 0
                                            TBONO_RES.Tag = TBONO_RES.Value
                                            TBONO_RES_VACIO.Value = 0
                                            TBONO_RES_VACIO.Tag = TBONO_RES.Value
                                        End If
                                    Catch ex As Exception
                                        Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Else
                                    TBONO_RES.Value = 0
                                    TBONO_RES.Tag = TBONO_RES.Value
                                    TBONO_RES_VACIO.Value = 0
                                    TBONO_RES_VACIO.Tag = TBONO_RES.Value
                                End If
                            Else
                                Try
                                    If IsNumeric(TCVE_EVA.Text) AndAlso Convert.ToInt16(TCVE_EVA.Text) > 0 Then
                                        If IsNumeric(TCAL_GLO_EVA.Text) AndAlso Convert.ToDecimal(TCAL_GLO_EVA.Text) > 0 Then
                                            TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                                            TBONO_RES.Tag = TBONO_RES.Text
                                        End If
                                    End If

                                    If Not IsNothing(TNO_VIAJES.Value) And Not IsNothing(TBONO_RES.Tag) Then
                                        If IsNumeric(TNO_VIAJES.Value) And IsNumeric(TBONO_RES.Tag) Then
                                            If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                                TBONO_RES.Value = Convert.ToDecimal(TBONO_RES.Tag) * Convert.ToDecimal(TNO_VIAJES.Value)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        Else
                            TFACTOR_CARGA.Text = ""
                            TCALIF_FACTOR_CARGA.Text = ""
                            TPORC_USO_RALENTI.Text = ""
                            TCALIF_RALENTI.Text = ""
                            TCALIF_GLOBAL.Text = ""
                            TBONO.Text = ""
                            TFACTOR_CARGA.Tag = "0"
                            TPORC_USO_RALENTI.Tag = "0"
                            MsgBox("Motor no encontrado en el catálogo de evaluaciones")
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_MOT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_MOT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMotor_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_MOT_Validated(sender As Object, e As EventArgs) Handles TCVE_MOT.Validated
        Try
            If TCVE_MOT.Text.Trim.Length > 0 And TCVE_MOT.Text <> "0" Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Motor", TCVE_MOT.Text)
                If DESCR <> "" Then
                    LtMotor.Text = DESCR
                    'DESPLEGAR_EVA_MOTOR()
                Else
                    MsgBox("Motor inexistente")
                    TCVE_MOT.Text = ""
                    LtMotor.Text = ""
                    TLTS_LLEGADA.Select()
                End If
            Else
                LtMotor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFAC_CARGA_TextChanged(sender As Object, e As EventArgs) Handles TFAC_CARGA.TextChanged
        CALC_CAL_GLO_EVA()
        VELMAX_CAMBIA()
    End Sub
    Sub CALC_CAL_GLO_EVA()
        Try
            Dim FAC_CARGA As Single = 0, FACTOR_CARGA As Single = 0, PORC_USO_RALENTI As Single = 0, Continua As Boolean


            If IsNumeric(TFAC_CARGA.Text.Replace(",", "")) Then
                FAC_CARGA = TFAC_CARGA.Text.Replace(",", "")
            End If
            If IsNumeric(TFACTOR_CARGA.Text.Replace(",", "")) Then
                FACTOR_CARGA = TFACTOR_CARGA.Text.Replace(",", "")
            End If

            If CALCULO_POSITIVO Then
                If FAC_CARGA >= FACTOR_CARGA And FAC_CARGA <> 0 And FACTOR_CARGA <> 0 Then
                    Continua = True
                Else
                    Continua = False
                End If
            Else
                If FAC_CARGA <= FACTOR_CARGA And FAC_CARGA <> 0 And FACTOR_CARGA <> 0 Then
                    Continua = True
                Else
                    Continua = False
                End If
            End If

            If Continua Then
                Try
                    TCAL_FAC_CAR_EVA.Text = TFACTOR_CARGA.Tag
                    If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                        PORC_USO_RALENTI = TCAL_RAL_EVA.Text.Replace(",", "")
                    Else
                        PORC_USO_RALENTI = 0
                    End If

                    Dim CAL1 As Decimal, CAL2 As Decimal, CAL3 As Decimal, CAL44 As Decimal

                    Try
                        If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                            CAL1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                        Else
                            CAL1 = 0
                        End If
                    Catch ex As Exception
                        Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                            CAL2 = TCAL_RAL_EVA.Text.Replace(",", "")
                        Else
                            CAL2 = 0
                        End If
                    Catch ex As Exception
                        Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If IsNumeric(tCALIF_VEL_MX.Text.Replace(",", "")) Then
                            CAL3 = tCALIF_VEL_MX.Text.Replace(",", "")
                        Else
                            CAL3 = 0
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                            CAL44 = TCALIF_RPM.Text.Replace(",", "")
                        Else
                            CAL44 = 0
                        End If
                    Catch ex As Exception
                    End Try

                    If Not BONO_ESPECIAL Then
                        Try
                            TCAL_GLO_EVA.Text = CAL1 + CAL2 + CAL3 + CAL44
                            TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                            TBONO_RES.Tag = TBONO_RES.Text

                            If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                            End If
                        Catch ex As Exception
                            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        PROC_BONO_ESPECIAL()
                    End If
                Catch ex As Exception
                    Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                TCAL_FAC_CAR_EVA.Text = "0"

                Dim CAL1 As Decimal, CAL2 As Decimal, CAL3 As Decimal, CAL44 As Decimal

                Try
                    If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                        CAL1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                    Else
                        CAL1 = 0
                    End If
                Catch ex As Exception
                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                        CAL2 = TCAL_RAL_EVA.Text.Replace(",", "")
                    Else
                        CAL2 = 0
                    End If
                Catch ex As Exception
                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If IsNumeric(tCALIF_VEL_MX.Text.Replace(",", "")) Then
                        CAL3 = tCALIF_VEL_MX.Text.Replace(",", "")
                    Else
                        CAL3 = 0
                    End If
                Catch ex As Exception
                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                        CAL44 = TCALIF_RPM.Text.Replace(",", "")
                    Else
                        CAL44 = 0
                    End If
                Catch ex As Exception
                End Try

                If Not BONO_ESPECIAL Then
                    TCAL_GLO_EVA.Text = CAL1 + CAL2 + CAL3 + CAL44

                    If IsNumeric(TCVE_EVA.Text) And IsNumeric(TCAL_GLO_EVA.Text) Then
                        TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(Convert.ToInt32(TCVE_EVA.Text), Convert.ToDecimal(TCAL_GLO_EVA.Text))

                        TBONO_RES.Tag = TBONO_RES.Text
                        Try
                            If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Else
                    PROC_BONO_ESPECIAL()
                End If
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLtsRealesVsLtsTab_Click(sender As Object, e As EventArgs) Handles BtnLtsRealesVsLtsTab.Click
        Try
            TLTS_TAB.BackColor = Color.Lime
            TLTS_REAL.BackColor = Color.Lime

            MsgBox("LTS REALES VS LTS TAB = LTS_TAB - LTS_REAL")
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLtsReales_Click(sender As Object, e As EventArgs) Handles BtnLtsReales.Click
        TLTS_SALIDA.BackColor = Color.Cyan
        TLTS_VALES.BackColor = Color.Cyan
        TLTS_LLEGADA.BackColor = Color.Cyan
        MsgBox("LTS. REALES = LTS_SALIDA + LTS_VALES - LTS_LLEGADA")
    End Sub

    Private Sub BtnRendECM_Click(sender As Object, e As EventArgs) Handles BtnRendECM.Click
        TKM_ECM.BackColor = Color.Magenta
        TLTS_ECM.BackColor = Color.Magenta
        MsgBox("RENDIMIENTO ECM = (KM_ECM / LTS_ECM) * 100")
    End Sub

    Private Sub BtnPorcEcmVsLtsReal_Click(sender As Object, e As EventArgs) Handles BtnPorcEcmVsLtsReal.Click
        TLTS_REAL.BackColor = Color.Green
        TLTS_ECM.BackColor = Color.Green

        MsgBox("% LTS ECM VS. LTS REAL = (LTS_REAL / LTS_ECM) * 100")

    End Sub

    Private Sub BtnLtsTabVsLtsReal_Click(sender As Object, e As EventArgs) Handles BtnLtsTabVsLtsReal.Click
        TLTS_REAL.BackColor = Color.Pink
        TLTS_TAB.BackColor = Color.Pink

        MsgBox("% LTS TAB VS. LTS REAL = ((LTS_REAL/ LTS_TAB) - 1 ) * 100")
    End Sub

    Private Sub BtnLtsRealVsLtsECM_Click(sender As Object, e As EventArgs) Handles BtnLtsRealVsLtsECM.Click
        TLTS_ECM.BackColor = Color.Purple
        TLTS_REAL.BackColor = Color.Purple

        MsgBox("LTS REALES VS LTS ECM = LTS_ECM - LTS_REAL")
    End Sub

    Private Sub BtnRendReal_Click(sender As Object, e As EventArgs) Handles BtnRendReal.Click
        TKM_ECM.BackColor = Color.Orange
        TLTS_REAL.BackColor = Color.Orange

        MsgBox("RENDIMIENTO REAL = KM_ECM / LTS_REAL")
    End Sub

    Private Sub BtnPorcTiempoPtoRalenti_Click(sender As Object, e As EventArgs) Handles BtnPorcTiempoPtoRalenti.Click
        THRS_PTO_RALENTI.BackColor = Color.DodgerBlue
        THRS_TRABAJO.BackColor = Color.DodgerBlue

        MsgBox("% TIEMPO PTO Y RALENTI = (HRS_PTO_RALENTI / HRS_TRABAJO) * 100")
    End Sub

    Private Sub BtnPorcLtsPtoRalenti_Click(sender As Object, e As EventArgs) Handles BtnPorcLtsPtoRalenti.Click
        TLTS_PTO_RALENTI.BackColor = Color.Yellow
        TLTS_ECM.BackColor = Color.Yellow

        MsgBox("% LTS PTO Y RALENTI = (LTS_PTO_RALENTI / LTS_ECM) * 100")
    End Sub
    Private Sub TPRECIO_X_LTS_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LTS.TextChanged
        Try
            If IsNumeric(TLTS_DESCONTAR.Text.Replace(",", "")) And IsNumeric(TPRECIO_X_LTS.Text.Replace(",", "")) Then
                LtDescXLitros.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR.Value) * Convert.ToDecimal(TPRECIO_X_LTS.Text.Replace(",", "")), "###,###,##0.00")
                LtDescXLitros.Tag = LtDescXLitros.Text
            Else
                LtDescXLitros.Text = "0"
                LtDescXLitros.Tag = "0"
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLTS_DESCONTAR_TextChanged(sender As Object, e As EventArgs) Handles TLTS_DESCONTAR.TextChanged
        Try
            If IsNumeric(TLTS_DESCONTAR.Text.Replace(",", "")) And IsNumeric(TPRECIO_X_LTS.Text.Replace(",", "")) Then
                LtDescXLitros.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR.Text.Replace(",", "")) * Convert.ToDecimal(TPRECIO_X_LTS.Value), "###,###,##0.00")
                LtDescXLitros.Tag = LtDescXLitros.Text
            Else
                LtDescXLitros.Text = "0"
                LtDescXLitros.Tag = "0"
            End If

            If IsNumeric(LLts_Desc_Ralenti.Text.Replace(",", "")) Then
                If CDec(TLTS_DESCONTAR.Text) >= 0 Then
                    LLts_desc_dif.Text = "0"
                    LLts_Desc_Ralenti.Text = "0"
                Else
                    LLts_desc_dif.Text = TLTS_DESCONTAR.Text + Math.Abs(CDec(LLts_Desc_Ralenti.Text.Replace(",", "")))
                    LLts_Desc_Ralenti.Text = (CDec(TLTS_PTO_RALENTI.Value) - CDec(LtLTS_RALENTI.Text.Replace("'", ""))) * -1
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TAB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged
        Try
            If TAB1.SelectedIndex = 1 Then
                TDESCT.Select()
                TDESCT.Focus()
                TDESCT.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnColorFondo_Click(sender As Object, e As EventArgs) Handles BtnColorFondo.Click
        TODOMETRO.BackColor = Color.White
        TKM_ECM.BackColor = Color.White
        TLTS_ECM.BackColor = Color.White
        TFAC_CARGA.BackColor = Color.White
        THRS_TRABAJO.BackColor = Color.White
        THRS_PTO_RALENTI.BackColor = Color.White
        TLTS_PTO_RALENTI.BackColor = Color.White

        TLTS_REAL.BackColor = Color.WhiteSmoke
        TLTS_TAB.BackColor = Color.WhiteSmoke
        LtREND_ECM.BackColor = Color.WhiteSmoke
        LtPORC_VAR_LTS_ECM_REAL.BackColor = Color.WhiteSmoke
        LtPORC_VAR_LTS_TAB_REAL.BackColor = Color.WhiteSmoke
        LtKMS_TAB.BackColor = Color.WhiteSmoke
        LtPORC_TIEMPO_PTO_RALENTI.BackColor = Color.WhiteSmoke
        LtPORC_LTS_PTO_RALENTI.BackColor = Color.WhiteSmoke
        LtREND_TAB.BackColor = Color.WhiteSmoke
        LtREND_REAL.BackColor = Color.WhiteSmoke
        LtDIF_LTS_REAL_LTS_ECM.BackColor = Color.WhiteSmoke
        LtDIF_LTS_REAL_LTS_TAB.BackColor = Color.WhiteSmoke

        If PASS_GRUPOCE = "BR3FRAJA" Or PASS_GRUPOCE = "BUS" Then

            Dim EfecRegresado As Boolean

            EfecRegresado = EXECUTE_QUERY_NET("UPDATE GCRESETEO SET TABULADOR = 1 WHERE CVE_RES = " & CLng(TCVE_RES.Text))

            MsgBox("Ok",, EfecRegresado)
        End If
    End Sub
    Private Sub TPORC_TOLERANCIA_TextChanged(sender As Object, e As EventArgs) Handles TPORC_TOLERANCIA.TextChanged
        CALCULAR_LTS_AUTORIT()
    End Sub
    Private Sub TPORC_RALENTI_TextChanged(sender As Object, e As EventArgs) Handles TPORC_RALENTI.TextChanged
        CALCULAR_LTS_AUTORIT()
    End Sub
    Private Sub TLTS_ECM_TextChanged(sender As Object, e As EventArgs) Handles TLTS_ECM.TextChanged
        Try
            Dim V1 As String, V2 As String, C1 As Single
            V1 = "" : V2 = ""

            V1 = TLTS_ECM.Text
            V1 = TLTS_ECM.Text.Replace(",", "")

            If Not IsDBNull(TLTS_PTO_RALENTI.Value) Then
                V2 = TLTS_PTO_RALENTI.Value
            End If

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V1) <> 0 Then
                    C1 = Convert.ToDecimal(V2) / Convert.ToDecimal(V1)
                    C1 *= 100
                    C1 = Math.Truncate(C1 * 1000) / 1000
                Else
                    C1 = 0
                End If
                LtPORC_LTS_PTO_RALENTI.Text = Format(C1, "###,###,##0.00")
            End If
        Catch ex As Exception
            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CAL2()
        CAL7()
        CAL1()
        CALCULAR_LTS_AUTORIT()

    End Sub
    Private Sub TLTS_PTO_RALENTI_TextChanged(sender As Object, e As EventArgs) Handles TLTS_PTO_RALENTI.TextChanged
        Try
            Dim V1 As String, V2 As String, C1 As Single

            V1 = TLTS_ECM.Value
            V2 = TLTS_PTO_RALENTI.Text

            If IsNumeric(V1) And IsNumeric(V2) Then
                If Convert.ToDecimal(V2) <> 0 Then
                    If Convert.ToDecimal(V1) > 0 Then
                        C1 = Convert.ToDecimal(V2) / Convert.ToDecimal(V1)
                        C1 *= 100
                        C1 = Math.Truncate(C1 * 1000) / 1000
                    Else
                        C1 = 0
                    End If
                Else
                    C1 = 0
                End If
                LtPORC_LTS_PTO_RALENTI.Text = Format(C1, "###,###,##0.00")
            End If

            If IsNumeric(LtLTS_RALENTI.Text.Replace(",", "")) Then
                If TLTS_DESCONTAR.Value >= 0 Then
                    LLts_Desc_Ralenti.Text = "0"
                Else
                    LLts_Desc_Ralenti.Text = (TLTS_PTO_RALENTI.Value - CDec(LtLTS_RALENTI.Text.Replace(",", ""))) * -1
                End If
            End If

        Catch ex As Exception
            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CALCULAR_LTS_AUTORIT()
    End Sub
    Private Sub TLTS_REAL_TextChanged(sender As Object, e As EventArgs) Handles TLTS_REAL.TextChanged
        Try
            If Not IsDBNull(TLTS_VALES.Value) Then
                If String.IsNullOrEmpty(TLTS_VALES.Value) Then
                    Try
                        Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
                        Try
                            LRC1 = TLTS_SALIDA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try
                        Try
                            LRC2 = TLTS_VALES.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC3 = TLTS_FORANEOS.Value
                        Catch ex As Exception
                        End Try
                        Try
                            LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
                        Catch ex As Exception
                        End Try

                        TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
                        TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

                        If ChEvento1.Checked Then
                            LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                            LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        End If

                        LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                        LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")

                        If RadLTS_ECM.Checked Then
                            CALCULO_EVENTO2_LTS_DESCONTAR2()
                        End If
                        If RadLTS_TAB.Checked Then
                            CALCULO_EVENTO2_LTS_TAB()
                        End If

                    Catch ex As Exception
                        Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            CAL2()
            CAL3()
            CAL7()
            CAL8()
            CAL6()
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        CALCULAR_LTS_AUTORIT()
    End Sub

    Private Sub TLTS_FORANEOS_TextChanged(sender As Object, e As EventArgs) Handles TLTS_FORANEOS.TextChanged
        Try
            Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
            Try
                LRC1 = TLTS_SALIDA.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            Try
                LRC2 = TLTS_VALES.Value
            Catch ex As Exception
            End Try
            Try
                LRC3 = TLTS_FORANEOS.Text
            Catch ex As Exception
            End Try
            Try
                LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
            TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

            If ChEvento1.Checked Then
                LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            End If

            LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")

            CAL8()

            PROC_BONO_ESPECIAL()

            If RadLTS_ECM.Checked Then
                CALCULO_EVENTO2_LTS_DESCONTAR2()
            End If
            If RadLTS_TAB.Checked Then
                CALCULO_EVENTO2_LTS_TAB()
            End If

        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLimpiarLtsEnt_Click(sender As Object, e As EventArgs) Handles BtnLimpiarLtsEnt.Click

        If MsgBox("Realmente desea eliminar los litros de entrada?", vbYesNo) = vbNo Then
            Return
        End If

        TLTS_LLEGADA.Text = "0"
        Try
            Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
            Try
                LRC1 = TLTS_SALIDA.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            Try
                LRC2 = TLTS_VALES.Value
            Catch ex As Exception
            End Try
            Try
                LRC3 = TLTS_FORANEOS.Value
            Catch ex As Exception
            End Try
            Try
                LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
            TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

            If ChEvento1.Checked Then
                LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            End If

            LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            If IsNumeric(TCVE_RES.Text) Then
                SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_RES = 0, TIPO_LITROS = 0 WHERE CVE_RES = " & CLng(TCVE_RES.Text)
                EXECUTE_QUERY_NET(SQL)
            End If


            If RadLTS_ECM.Checked Then
                CALCULO_EVENTO2_LTS_DESCONTAR2()
            End If
            If RadLTS_TAB.Checked Then
                CALCULO_EVENTO2_LTS_TAB()
            End If

        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLimpiarLtsSal_Click(sender As Object, e As EventArgs) Handles BtnLimpiarLtsSal.Click

        If MsgBox("Realmente desea eliminar los litros de salidas?", vbYesNo) = vbNo Then
            Return
        End If

        TLTS_SALIDA.Text = "0"
        Try
            Dim LRC1 As Decimal = 0, LRC2 As Decimal = 0, LRC3 As Decimal = 0, LRC4 As Decimal = 0
            Try
                LRC1 = TLTS_SALIDA.Text.Replace(",", "")
            Catch ex As Exception
            End Try
            Try
                LRC2 = TLTS_VALES.Value
            Catch ex As Exception
            End Try
            Try
                LRC3 = TLTS_FORANEOS.Value
            Catch ex As Exception
            End Try
            Try
                LRC4 = TLTS_LLEGADA.Text.Replace(",", "")
            Catch ex As Exception
            End Try

            TLTS_REAL.Text = LRC1 + LRC2 + LRC3 - LRC4
            TLTS_REAL.Tag = LRC1 + LRC2 + LRC3 - LRC4

            If ChEvento1.Checked Then
                LtLTS_VALES.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
                LtLTS_VALES.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            End If

            LtLTS_VALES2.Text = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")
            LtLTS_VALES2.Tag = Format(LRC1 + LRC2 + LRC3 - LRC4, "###,###,##0.00")

            If IsNumeric(TCVE_RES.Text) Then
                SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_RES = 0, TIPO_LITROS = 0 WHERE CVE_RES = " & CLng(TCVE_RES.Text)
                EXECUTE_QUERY_NET(SQL)
            End If


            If RadLTS_ECM.Checked Then
                CALCULO_EVENTO2_LTS_DESCONTAR2()
            End If
            If RadLTS_TAB.Checked Then
                CALCULO_EVENTO2_LTS_TAB()
            End If

        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TVELMAX_TextChanged(sender As Object, e As EventArgs) Handles TVELMAX.TextChanged
        VELMAX_CAMBIA()
    End Sub
    Sub VELMAX_CAMBIA()
        Try
            If IsNumeric(TVELMAX.Text.Replace(",", "")) And IsNumeric(TVEL_MAX.Text.Replace(",", "")) Then
                If Convert.ToDecimal(TVELMAX.Text.Replace(",", "")) <= Convert.ToDecimal(TVEL_MAX.Text.Replace(",", "")) Then
                    TCALIF_VEL_MX.Text = TCALIF_VEL_MAX.Text
                Else
                    TCALIF_VEL_MX.Text = "0"
                End If
                Try
                    Dim C1 As Single = 0, C2 As Single = 0, C3 As Single = 0, C44 As Single = 0
                    Try
                        C1 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                    Catch ex As Exception
                    End Try
                    Try
                        C2 = TCAL_RAL_EVA.Text.Replace(",", "")
                    Catch ex As Exception
                    End Try
                    Try
                        C3 = tCALIF_VEL_MX.Text.Replace(",", "")
                    Catch ex As Exception
                    End Try
                    Try
                        If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                            C44 = TCALIF_RPM.Text.Replace(",", "")
                        Else
                            C44 = 0
                        End If
                    Catch ex As Exception
                    End Try

                    If Not BONO_ESPECIAL Then
                        TCAL_GLO_EVA.Text = Format(C1 + C2 + C3 + C44, "###,###,##0")
                        TBONO_RES.Value = OBTENER_BONO_DESDE_CATEVA(TCVE_EVA.Text, TCAL_GLO_EVA.Text)
                        TBONO_RES.Tag = TBONO_RES.Text
                        Try
                            If Convert.ToDecimal(TNO_VIAJES.Value) > 0 Then
                                TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Value
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        PROC_BONO_ESPECIAL()
                    End If
                Catch ex As Exception
                    Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function OBTENER_BONO_DESDE_CATEVA(FCVE_EVA As Integer, fCANT_GLO_EVA As Decimal) As Decimal
        Dim BONO As Decimal = 0, CALIF_GLOBAL As Decimal
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCATEVA WHERE CVE_EVA = " & FCVE_EVA & ""
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Try
                            CALIF_GLOBAL = dr("CALIF_GLOBAL")
                            If CALIF_GLOBAL = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL2") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO2")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL3") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO3")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL4") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO4")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL5") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO5")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL6") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO6")
                            ElseIf dr.ReadNullAsEmptyDecimal("CALIF_GLOBAL7") = fCANT_GLO_EVA Then
                                BONO = dr.ReadNullAsEmptyDecimal("BONO7")
                            End If
                        Catch ex As Exception
                            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End Using
            End Using
            Return BONO
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1340. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & SQL)
            Return BONO
        End Try
    End Function

    Private Sub TNO_VIAJES_TextChanged(sender As Object, e As EventArgs) Handles tNO_VIAJES.TextChanged
        Try
            If Not BONO_ESPECIAL Then
                If IsNumeric(TNO_VIAJES.Text) Then
                    If Convert.ToDecimal(TNO_VIAJES.Text) > 0 Then
                        TBONO_RES.Value = CDec(TBONO_RES.Tag) * TNO_VIAJES.Text
                    End If
                End If
            Else
                PROC_BONO_ESPECIAL()
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBONO_RES_TextChanged(sender As Object, e As EventArgs) Handles TBONO_RES.TextChanged
        Try
            LtBONO_RES_TOTAL.Text = CDec(TBONO_RES.Text) + CDec(TBONO_RES_VACIO.Value)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TNO_VIAJES_VACIO_TextChanged(sender As Object, e As EventArgs) Handles TNO_VIAJES_VACIO.TextChanged
        Try
            If Not BONO_ESPECIAL Then
                If IsNumeric(TNO_VIAJES_VACIO.Text) Then
                    If Convert.ToDecimal(TNO_VIAJES_VACIO.Text) > 0 Then
                        TBONO_RES_VACIO.Value = CDec(TBONO_RES_VACIO.Tag) * TNO_VIAJES_VACIO.Text
                    End If
                End If
            Else
                PROC_BONO_ESPECIAL()
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBONO_RES_VACIO_TextChanged(sender As Object, e As EventArgs) Handles TBONO_RES_VACIO.TextChanged
        Try
            LtBONO_RES_TOTAL.Text = CDec(TBONO_RES.Value) + CDec(TBONO_RES_VACIO.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TPRECIO_X_LTS_Validating(sender As Object, e As CancelEventArgs) Handles TPRECIO_X_LTS.Validating
        Try
            If TPRECIO_X_LTS.Value < 0 Then
                TPRECIO_X_LTS.Value = 0
                TPRECIO_X_LTS2.Value = 0

                TPRECIO_X_LTS.Tag = 0
                TPRECIO_X_LTS2.Tag = 0
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChEvento1_CheckedChanged(sender As Object, e As EventArgs) Handles ChEvento1.CheckedChanged
        Try
            If ChEvento1.Checked Then
                ChEvento2.Checked = False
                LtLitrosECMEvento2.Visible = False
                TPORC_TOL_EVENTO2.Visible = False

                ENTRA_EVENTO1 = False
                ENTRA_EVENTO2 = False

                '19 JULIO

                If TPRECIO_X_LTS.Value = 0 Then
                    TPRECIO_X_LTS.Value = PRECIO_X_LTS
                    TPRECIO_X_LTS.Tag = PRECIO_X_LTS
                Else
                    TPRECIO_X_LTS.Value = TPRECIO_X_LTS.Tag
                End If

                TPORC_TOL_EVENTO2.Value = 0
                TLTS_AUTORIZADOS2.Value = 0
                LtLTS_VALES2.Text = 0
                TLTS_DESCONTAR2.Value = 0
                'TPRECIO_X_LTS2.Value = 0
                LtDescXLitros2.Text = 0

                Try
                    If Not BONO_ESPECIAL Then
                        'TBONO_RES.Value = 0
                    End If
                Catch ex As Exception
                    Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                '=========================

                TPORC_TOLERANCIA.Value = TPORC_TOLERANCIA.Tag
                LtLTS_ECM.Text = LtLTS_ECM.Tag

                If IsNumeric(TLTS_ECM.Text.Replace(",", "")) And IsNumeric(TPORC_TOLERANCIA.Text.Replace(",", "")) Then
                    Dim CC1 As Decimal, C2 As Decimal

                    CC1 = Convert.ToDecimal(TLTS_ECM.Text.Replace(",", "")) - Convert.ToDecimal(TLTS_PTO_RALENTI.Text.Replace(",", ""))
                    C2 = (Convert.ToDecimal(TPORC_RALENTI.Text.Replace(",", "")) + Convert.ToDecimal(TPORC_TOLERANCIA.Text.Replace(",", "")))
                    If C2 > 0 Then
                        C2 = 1 + (C2 / 100)
                    Else
                        C2 = 0
                    End If
                    TLTS_AUTORIZADOS.Value = CC1 * C2
                    TLTS_AUTORIZADOS.Tag = CC1 * C2
                End If

                PROC_EVENTO1() 'LtLTS_VALES.Text = LtLTS_VALES.Tag
                CALCULAR_LTS_AUTORIT()

                LtDescXLitros.Text = LtDescXLitros.Tag
                TLTS_DESCONTAR.Value = TLTS_DESCONTAR.Tag
                TPORC_RALENTI.Value = TPORC_RALENTI.Tag
                LtLTS_RALENTI.Text = LtLTS_RALENTI.Tag

                ENTRA_EVENTO1 = True
                ENTRA_EVENTO2 = True
            Else
                TPORC_TOLERANCIA.Value = 0
                LtLTS_ECM.Text = ""
                TLTS_AUTORIZADOS.Value = 0
                TLTS_DESCONTAR.Value = 0
                LLts_desc_dif.Text = ""
                LLts_Desc_Ralenti.Text = ""

                TPORC_RALENTI.Value = 0
                LtLTS_RALENTI.Text = ""
                LtLTS_VALES.Text = ""
                'TPRECIO_X_LTS
                LtDescXLitros.Text = ""

                LtLitrosECMEvento2.Visible = True
                TPORC_TOL_EVENTO2.Visible = True
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChEvento2_CheckedChanged(sender As Object, e As EventArgs) Handles ChEvento2.CheckedChanged
        Try
            If ChEvento2.Checked Then
                ChEvento1.Checked = False
                LtLitrosECMEvento2.Visible = True
                TPORC_TOL_EVENTO2.Visible = True
                'CALCULO_EVENTO2_LTS_DESCONTAR2()
                '19 JULIO
                ENTRA_EVENTO1 = False
                ENTRA_EVENTO2 = False

                If TPRECIO_X_LTS2.Value = 0 Then
                    If TPRECIO_X_LTS.Value = 0 Then
                        TPRECIO_X_LTS2.Value = PRECIO_X_LTS
                        TPRECIO_X_LTS2.Tag = PRECIO_X_LTS
                    Else
                        TPRECIO_X_LTS2.Value = TPRECIO_X_LTS.Value
                        TPRECIO_X_LTS2.Tag = TPRECIO_X_LTS.Value
                    End If
                Else
                    TPRECIO_X_LTS2.Value = TPRECIO_X_LTS2.Tag
                End If

                TPORC_TOLERANCIA.Value = 0
                LtLTS_ECM.Text = 0
                TLTS_AUTORIZADOS.Value = 0
                TLTS_DESCONTAR.Value = 0
                TPORC_RALENTI.Value = 0
                LtLTS_RALENTI.Text = 0
                LtLTS_VALES.Text = 0
                LtDescXLitros.Text = 0


                TPORC_TOL_EVENTO2.Value = TPORC_TOL_EVENTO2.Tag
                TLTS_AUTORIZADOS2.Value = TLTS_AUTORIZADOS2.Tag
                LtLTS_VALES2.Text = LtLTS_VALES2.Tag
                ''TLTS_DESCONTAR2.Value = TLTS_DESCONTAR2.Tag

                If IsNumeric(TPRECIO_X_LTS2.Text.Replace(",", "")) Then
                    LtDescXLitros2.Text = Format(CDec(TLTS_DESCONTAR2.Value) * CDec(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                    ''LtDescXLitros2.Tag = Format(CDec(TLTS_DESCONTAR2.Value) * CDec(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                Else
                    LtDescXLitros2.Text = 0
                    ''LtDescXLitros2.Tag = 0
                End If

                'If IsNumeric(LtDescXLitros2.Tag) Then
                'LtDescXLitros2.Text = Format(Convert.ToDecimal(LtDescXLitros2.Tag), "###,###,##0.00")
                'End If

                ENTRA_EVENTO1 = True
                ENTRA_EVENTO2 = True

                CALCULO_EVENTO2_LTS_DESCONTAR2()
                PROC_BONO_ESPECIAL()

            Else

                TPORC_TOLERANCIA.Value = 0
                LtLTS_ECM.Text = ""
                TLTS_AUTORIZADOS.Value = 0
                TLTS_DESCONTAR.Value = 0
                LLts_desc_dif.Text = ""
                LLts_Desc_Ralenti.Text = ""

                TPORC_RALENTI.Value = 0
                LtLTS_RALENTI.Text = ""
                LtLTS_VALES.Text = ""
                'TPRECIO_X_LTS
                LtDescXLitros.Text = ""

                LtLitrosECMEvento2.Visible = True
                TPORC_TOL_EVENTO2.Visible = True
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CALCULAR_LTS_AUTORIT()
        Dim C1 As Decimal, C2 As Decimal

        If ChEvento1.Checked Then
            Try
                If IsNumeric(TLTS_PTO_RALENTI.Text.Replace(",", "")) And IsNumeric(TLTS_ECM.Text.Replace(",", "")) And
                    IsNumeric(TPORC_RALENTI.Text.Replace(",", "")) And IsNumeric(TPORC_RALENTI.Text.Replace(",", "")) Then

                    If IsNumeric(TLTS_ECM.Text.Replace(",", "")) And IsNumeric(TPORC_TOLERANCIA.Text.Replace(",", "")) Then
                        C1 = Convert.ToDecimal(TLTS_ECM.Text.Replace(",", "")) - Convert.ToDecimal(TLTS_PTO_RALENTI.Text.Replace(",", ""))
                        C2 = (Convert.ToDecimal(TPORC_RALENTI.Text.Replace(",", "")) + Convert.ToDecimal(TPORC_TOLERANCIA.Text.Replace(",", "")))
                        If C2 > 0 Then
                            C2 = 1 + (C2 / 100)
                        Else
                            C2 = 0
                        End If
                        Try
                            TLTS_AUTORIZADOS.Value = C1 * C2
                            TLTS_AUTORIZADOS.Tag = C1 * C2

                            If IsNumeric(TLTS_AUTORIZADOS.Text) Then
                                If IsNumeric(LtLTS_VALES.Text.Trim.Replace(",", "")) Then
                                    If CDec(TLTS_AUTORIZADOS.Value) - CDec(LtLTS_VALES.Text.Trim.Replace(",", "")) > 0 Then
                                        TLTS_DESCONTAR.Value = 0
                                        TLTS_DESCONTAR.Tag = 0
                                    Else
                                        TLTS_DESCONTAR.Value = CDec(TLTS_AUTORIZADOS.Value) - CDec(LtLTS_VALES.Text.Trim.Replace(",", ""))
                                        TLTS_DESCONTAR.Tag = CDec(TLTS_AUTORIZADOS.Value) - CDec(LtLTS_VALES.Text.Trim.Replace(",", ""))

                                        If TLTS_DESCONTAR.Value >= 0 Then
                                            LLts_Desc_Ralenti.Text = "0"
                                            LLts_desc_dif.Text = "0"
                                        Else
                                            If IsNumeric(LLts_Desc_Ralenti.Text.Replace(",", "")) Then
                                                LLts_desc_dif.Text = TLTS_DESCONTAR.Text + Math.Abs(CDec(LLts_Desc_Ralenti.Text.Replace(",", "")))
                                            End If
                                        End If
                                    End If
                                Else
                                    TLTS_DESCONTAR.Value = 0
                                    TLTS_DESCONTAR.Tag = 0
                                    LLts_Desc_Ralenti.Text = "0"
                                    LLts_desc_dif.Text = "0"
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        LtLTS_ECM.Text = Format((Convert.ToDecimal(TLTS_ECM.Text.Replace(",", "")) - Convert.ToDecimal(TLTS_PTO_RALENTI.Text.Replace(",", ""))) * Convert.ToDecimal(TPORC_TOLERANCIA.Text.Replace(",", "")) / 100, "###,###,##0.00")

                        LtLTS_RALENTI.Text = Format((Convert.ToDecimal(TLTS_ECM.Text.Replace(",", "")) - Convert.ToDecimal(TLTS_PTO_RALENTI.Text.Replace(",", ""))) * Convert.ToDecimal(TPORC_RALENTI.Text.Replace(",", "")) / 100, "###,###,##0.00")

                        LtLTS_ECM.Tag = LtLTS_ECM.Text
                        LtLTS_RALENTI.Tag = LtLTS_RALENTI.Text


                        If TLTS_DESCONTAR.Value >= 0 Then
                            LLts_Desc_Ralenti.Text = "0"
                        Else

                            LLts_Desc_Ralenti.Text = (CDec(TLTS_PTO_RALENTI.Value) - CDec(LtLTS_RALENTI.Text.Replace("'", ""))) * -1
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CALCULO_EVENTO2_LTS_DESCONTAR2()

        If ChEvento2.Checked Then
            Try
                If TPORC_TOL_EVENTO2.Value > 0 Then
                    TLTS_AUTORIZADOS2.Value = TLTS_ECM.Value + ((TLTS_ECM.Value * TPORC_TOL_EVENTO2.Value) / 100)
                    TLTS_AUTORIZADOS2.Tag = TLTS_ECM.Value + ((TLTS_ECM.Value * TPORC_TOL_EVENTO2.Value) / 100)
                Else
                    TLTS_AUTORIZADOS2.Value = TLTS_ECM.Value
                    TLTS_AUTORIZADOS2.Tag = TLTS_ECM.Value
                End If

                Select Case TIPO_TAB
                    Case 0 'MONTELLANO  TABULADOR EDE RUTAS
                        If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                            If TLTS_AUTORIZADOS2.Value < CDec(LtLTS_VALES2.Text.Replace(",", "")) Then
                                TLTS_DESCONTAR2.Value = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                                ''TLTS_DESCONTAR2.Tag = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                            Else
                                TLTS_DESCONTAR2.Value = 0
                                ''TLTS_DESCONTAR2.Tag = 0
                            End If
                        Else
                            TLTS_DESCONTAR2.Value = 0
                            ''TLTS_DESCONTAR2.Tag = 0
                        End If
                        If TLTS_DESCONTAR2.Value > 0 Then
                            TLTS_DESCONTAR2.Value = 0
                            LtDescXLitros2.Text = 0
                        End If
                    Case 1
                        'VIKINGOS TABULADOR ED RUTAS
                        If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                            If TLTS_AUTORIZADOS2.Value < CDec(LtLTS_VALES2.Text.Replace(",", "")) Then
                                TLTS_DESCONTAR2.Value = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                                TLTS_DESCONTAR2.Tag = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                            Else
                                TLTS_DESCONTAR2.Value = 0
                                TLTS_DESCONTAR2.Tag = 0
                            End If
                        Else
                            TLTS_DESCONTAR2.Value = 0
                            TLTS_DESCONTAR2.Tag = 0
                        End If
                    Case 2
                        'MONTELLANO VIAJES POR LIQUIDAR
                        If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                            TLTS_DESCONTAR2.Value = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                            TLTS_DESCONTAR2.Tag = TLTS_AUTORIZADOS2.Value - CDec(LtLTS_VALES2.Text.Replace(",", ""))
                        Else
                            TLTS_DESCONTAR2.Value = TLTS_AUTORIZADOS2.Value
                            TLTS_DESCONTAR2.Tag = TLTS_AUTORIZADOS2.Value
                        End If
                End Select


                If IsNumeric(TPRECIO_X_LTS2.Text.Replace(",", "")) Then
                    LtDescXLitros2.Text = Format(CDec(TLTS_DESCONTAR2.Value) * CDec(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                    LtDescXLitros2.Tag = Format(CDec(TLTS_DESCONTAR2.Value) * CDec(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                Else
                    LtDescXLitros2.Text = 0
                    LtDescXLitros2.Tag = 0
                End If

            Catch ex As Exception
                Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub RadLTS_ECM_CheckedChanged(sender As Object, e As EventArgs) Handles RadLTS_ECM.CheckedChanged
        Try
            TPORC_TOL_EVENTO2.Update()
        Catch ex As Exception
        End Try

        If RadLTS_ECM.Checked Then
            LtLitrosECMEvento2.Visible = True
            TPORC_TOL_EVENTO2.Visible = True

            CALCULO_EVENTO2_LTS_DESCONTAR2()

        Else
            LtLitrosECMEvento2.Visible = False
            TPORC_TOL_EVENTO2.Visible = False
        End If

    End Sub
    Private Sub TPORC_TOL_EVENTO2_TextChanged(sender As Object, e As EventArgs) Handles TPORC_TOL_EVENTO2.TextChanged
        Try
            CALCULO_EVENTO2_LTS_DESCONTAR2()

        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_TOL_EVENTO2_Validated(sender As Object, e As EventArgs) Handles TPORC_TOL_EVENTO2.Validated
        Try
            CALCULO_EVENTO2_LTS_DESCONTAR2()

        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULO_EVENTO2_LTS_TAB()
        Try
            'EVENTO 2 OPCION 2
            'EVENTO 2 LITROS TABULADOR
            Dim LTS_VALES_2 As Decimal

            Select Case TIPO_TAB
                Case 0 'MONTELLANO  TABULADOR EDE RUTAS
                    If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                        LTS_VALES_2 = CDec(LtLTS_VALES2.Text.Replace(",", ""))
                        If TLTS_AUTORIZADOS2.Value > LTS_VALES_2 Then
                            TLTS_DESCONTAR2.Value = 0
                            LtDescXLitros2.Text = 0
                        Else
                            TLTS_DESCONTAR2.Value = CDec(TLTS_TAB.Text.Replace(",", "")) - Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", ""))
                            LtDescXLitros2.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR2.Value) * Convert.ToDecimal(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                        End If

                        If TLTS_DESCONTAR2.Value > 0 Then
                            TLTS_DESCONTAR2.Value = 0
                            LtDescXLitros2.Text = 0
                        End If
                    End If
                    'LtDescXLitros2
                Case 1
                    'VIKINGOS TABULADOR ED RUTAS
                    If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                        LTS_VALES_2 = CDec(LtLTS_VALES2.Text.Replace(",", ""))
                        If TLTS_AUTORIZADOS2.Value > LTS_VALES_2 Then
                            TLTS_DESCONTAR2.Value = 0
                            LtDescXLitros2.Text = 0
                        Else
                            TLTS_DESCONTAR2.Value = CDec(TLTS_TAB.Text.Replace(",", "")) - Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", ""))
                            LtDescXLitros2.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR2.Value) * Convert.ToDecimal(TPRECIO_X_LTS.Text.Replace(",", "")), "###,###,##0.00")
                        End If
                    End If
                Case 2
                    'MONTELLANO VIAJES POR LIQUIDAR
                    If IsNumeric(LtLTS_VALES2.Text.Replace(",", "")) Then
                        LTS_VALES_2 = CDec(LtLTS_VALES2.Text.Replace(",", ""))
                        TLTS_DESCONTAR2.Value = CDec(TLTS_TAB.Text.Replace(",", "")) - Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", ""))
                        LtDescXLitros2.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR2.Value) * Convert.ToDecimal(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                    Else
                        If IsNumeric(TLTS_TAB.Text.Replace(",", "")) Then
                            TLTS_DESCONTAR2.Value = CDec(TLTS_TAB.Text.Replace(",", ""))
                            LtDescXLitros2.Text = Format(Convert.ToDecimal(TLTS_DESCONTAR2.Value) * Convert.ToDecimal(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
                        End If
                    End If
            End Select

            TLTS_AUTORIZADOS2.Value = CDec(TLTS_TAB.Text.Replace(",", ""))
            TLTS_AUTORIZADOS2.Tag = CDec(TLTS_TAB.Text.Replace(",", ""))

            TLTS_DESCONTAR2.Tag = CDec(TLTS_TAB.Text.Replace(",", "")) - Convert.ToDecimal(LtLTS_VALES2.Text.Replace(",", ""))
            LtDescXLitros2.Tag = Format(Convert.ToDecimal(TLTS_DESCONTAR2.Value) * Convert.ToDecimal(TPRECIO_X_LTS2.Text.Replace(",", "")), "###,###,##0.00")
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RadLTS_TAB_CheckedChanged(sender As Object, e As EventArgs) Handles RadLTS_TAB.CheckedChanged
        Try
            'EVENTO 2 
            'OPCION 2
            If RadLTS_TAB.Checked Then
                CALCULO_EVENTO2_LTS_TAB()
            End If
        Catch ex As Exception
            Bitacora("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub
    Private Sub TPRECIO_X_LTS2_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LTS2.TextChanged
        Try
            If ENTRA_EVENTO1 And ENTRA_EVENTO2 Then
                LtDescXLitros2.Text = Format(TLTS_DESCONTAR2.Value * CDec(TPRECIO_X_LTS2.Text), "###,###,##0.00")

                LtDescXLitros2.Tag = TLTS_DESCONTAR2.Value * CDec(TPRECIO_X_LTS2.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg.Cols.Count = 1
            Fg.Cols.Count = 20

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Clave"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(Int32)

            Fg(0, 2) = "Num. viaje"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(Int32)

            Fg(0, 3) = "Folio"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(Int32)

            Fg(0, 4) = "Clave oper"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(Int32)

            Fg(0, 5) = "Nombre operador"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(String)

            Fg(0, 6) = "Fecha ida"
            Dim c66 As Column = Fg.Cols(6)
            c66.DataType = GetType(String)

            Fg(0, 7) = "Unidad"
            Dim c6 As Column = Fg.Cols(7)
            c6.DataType = GetType(String)

            Fg(0, 8) = "Tipo viaje"
            Dim c7 As Column = Fg.Cols(8)
            c7.DataType = GetType(String)

            Fg(0, 9) = "Cliente"
            Dim c8 As Column = Fg.Cols(9)
            c8.DataType = GetType(String)

            Fg(0, 10) = "Nombre del cliente"
            Dim c9 As Column = Fg.Cols(10)
            c9.DataType = GetType(String)

            Fg(0, 11) = "Cve. origen"
            Dim c10 As Column = Fg.Cols(11)
            c10.DataType = GetType(Int32)

            Fg(0, 12) = "Descripción origen"
            Dim c11 As Column = Fg.Cols(12)
            c11.DataType = GetType(String)

            Fg(0, 13) = "Cve. destino"
            Dim c12 As Column = Fg.Cols(13)
            c12.DataType = GetType(Int32)

            Fg(0, 14) = "Descripción destino"
            Dim c13 As Column = Fg.Cols(14)
            c13.DataType = GetType(String)

            Fg(0, 15) = "Cargado vacio"
            Dim c14 As Column = Fg.Cols(15)
            c14.DataType = GetType(String)

            Fg(0, 16) = "Kms"
            Dim c15 As Column = Fg.Cols(16)
            c15.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 17) = "Rendimiento"
            Dim c16 As Column = Fg.Cols(17)
            c16.DataType = GetType(Decimal)
            Fg.Cols(17).Format = "###,###,##0.00"

            Fg(0, 18) = "Litros"
            Dim c17 As Column = Fg.Cols(18)
            c17.DataType = GetType(Decimal)
            Fg.Cols(16).Format = "###,###,##0.00"

            Fg(0, 19) = "Toneladas"
            Dim c18 As Column = Fg.Cols(19)
            c18.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg.Cols(8).ComboList = "|Full|Sencillo"
            Fg.Cols(15).ComboList = "|Cargado|Vacio"

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub TITULOS_FLORES()
        Try
            Fg.Cols.Count = 1
            Fg.Cols.Count = 27

            Fg.Cols(18).AllowEditing = True

            Fg.Rows(0).Height = 40
            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - 150

            Fg(0, 1) = "Tab. Ruta"
            Dim cc1 As Column = Fg.Cols(1)
            cc1.DataType = GetType(String)

            Fg(0, 2) = "Num. viaje"
            Dim c2 As Column = Fg.Cols(2)
            c2.DataType = GetType(String)

            Fg(0, 3) = "Estatus"
            Dim c3 As Column = Fg.Cols(3)
            c3.DataType = GetType(String)

            Fg(0, 4) = "Unidad"
            Dim c4 As Column = Fg.Cols(4)
            c4.DataType = GetType(String)

            Fg(0, 5) = "Fecha"
            Dim c5 As Column = Fg.Cols(5)
            c5.DataType = GetType(DateTime)

            Fg(0, 6) = "Tipo unidad"
            Dim c66 As Column = Fg.Cols(6)
            c66.DataType = GetType(String)

            Fg(0, 7) = "Cve. origen"
            Dim c7 As Column = Fg.Cols(7)
            c7.DataType = GetType(String)

            Fg(0, 8) = "Cliente operativo origen"
            Dim c8 As Column = Fg.Cols(8)
            c8.DataType = GetType(String)

            Fg(0, 9) = "Plaza"
            Dim c9 As Column = Fg.Cols(9)
            c9.DataType = GetType(String)

            Fg(0, 10) = "Plaza"
            Dim c10 As Column = Fg.Cols(10)
            c10.DataType = GetType(String)

            Fg(0, 11) = "Cve. destino"
            Dim c11 As Column = Fg.Cols(11)
            c11.DataType = GetType(String)

            Fg(0, 12) = "Cliente operativo destino"
            Dim c12 As Column = Fg.Cols(12)
            c12.DataType = GetType(String)

            Fg(0, 13) = "Plaza"
            Dim c13 As Column = Fg.Cols(13)
            c13.DataType = GetType(String)

            Fg(0, 14) = "Plaza"
            Dim c14 As Column = Fg.Cols(14)
            c14.DataType = GetType(String)

            Fg(0, 15) = "Fecha carga"
            Dim c15 As Column = Fg.Cols(15)
            c15.DataType = GetType(DateTime)

            Fg(0, 16) = "Estatus viaje"
            Dim c16 As Column = Fg.Cols(16)
            c16.DataType = GetType(String)

            Fg(0, 17) = "Origen"
            Dim c17 As Column = Fg.Cols(17)
            c17.DataType = GetType(String)

            Fg(0, 18) = "Factor"
            Dim c18 As Column = Fg.Cols(18)
            c18.DataType = GetType(Decimal)

            Fg(0, 19) = "Kms"
            Dim c19 As Column = Fg.Cols(19)
            c19.DataType = GetType(Decimal)
            Fg.Cols(19).Format = "###,###,##0.00"

            Fg(0, 20) = "Rendimiento"
            Dim c20 As Column = Fg.Cols(20)
            c20.DataType = GetType(Decimal)
            Fg.Cols(20).Format = "###,###,##0.00"

            Fg(0, 21) = "Litros"
            Dim c21 As Column = Fg.Cols(21)
            c21.DataType = GetType(Decimal)
            Fg.Cols(21).Format = "###,###,##0.00"

            '************************************
            Fg(0, 22) = "Kms"
            Dim c22 As Column = Fg.Cols(22)
            c22.DataType = GetType(Decimal)
            Fg.Cols(22).Format = "###,###,##0.00"

            Fg(0, 23) = "Rendimiento"
            Dim c23 As Column = Fg.Cols(23)
            c23.DataType = GetType(Decimal)
            Fg.Cols(23).Format = "###,###,##0.00"

            Fg(0, 24) = "Litros"
            Dim c24 As Column = Fg.Cols(24)
            c24.DataType = GetType(Decimal)
            Fg.Cols(24).Format = "###,###,##0.00"
            '*********************

            Fg(0, 25) = "Carta porte 1"
            Dim c25 As Column = Fg.Cols(25)
            c25.DataType = GetType(String)

            Fg(0, 26) = "Carta porte 2"
            Dim c26 As Column = Fg.Cols(26)
            c26.DataType = GetType(String)

            Fg.Cols(3).Visible = False
            Fg.Cols(9).Visible = False
            Fg.Cols(13).Visible = False

            Fg.Cols(7).Visible = False
            Fg.Cols(11).Visible = False

            Fg.Cols(17).Visible = False
            Fg.Cols(18).Visible = True

            If PASS_GRUPOCE <> "BUS" Then
                Fg.Cols(22).Visible = False
                Fg.Cols(23).Visible = False
                Fg.Cols(24).Visible = False
            End If

        Catch ex As Exception
            Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnBaja_Click(sender As Object, e As EventArgs) Handles BtnBaja.Click
        Dim CVE_TAB As String = "", CVE_ORI As Long, CLIENTE As String

        If Fg.Row > 0 Then
            Try
                Try
                    If Not IsNothing(Fg(Fg.Row, 1)) Then
                        CVE_TAB = Fg(Fg.Row, 1)
                    Else
                        CVE_TAB = ""
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not IsNothing(Fg(Fg.Row, 5)) Then
                        CVE_ORI = Fg(Fg.Row, 5)
                    Else
                        CVE_ORI = 0
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Not IsNothing(Fg(Fg.Row, 11)) Then
                        CLIENTE = Fg(Fg.Row, 11)
                    Else
                        CLIENTE = ""
                    End If
                Catch ex As Exception
                End Try

                If CVE_TAB <> "" Then
                    If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                        Fg.RemoveItem(Fg.Row)

                        Select Case TIPO_TAB
                            Case 0
                                CALCULA_RENDIMIENTO()
                            Case 1
                                CALCULA_RENDIMIENTO_VIKINGOS()
                            Case 2
                                CALCULA_RENDIMIENTO_FLORES()
                        End Select
                    End If
                End If

            Catch ex As Exception
                Bitacora("755. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("755. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub BarEditVale_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarNuevoVale_Click_1(sender As Object, e As EventArgs) Handles BarNuevoVale.Click
        Try
            Var1 = "Nuevo"
            Var7 = TCVE_RES.Text
            Var6 = LtOper.Text

            Var48 = 0 'AQUI SE REGRESA LOS TLUS_REALES

            Var49 = TLTS_VALES.Value

            PassData10 = F1.Value

            frmConciValesComEditViking.TFOLIO.Text = GET_MAX_TRY("GCASIGNACION_VIAJE_VALES", "FOLIO")
            frmConciValesComEditViking.TFOLIO.Enabled = False
            frmConciValesComEditViking.TFOLIO.Tag = TCVE_OPER.Text

            frmConciValesComEditViking.TCVE_OPER.Text = TCVE_OPER.Text

            frmConciValesComEditViking.ShowDialog()
            'If Var48 > 0 Then
            'TLTS_VALES.Value = Var48
            'End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                Select Case TIPO_TAB
                    Case 0
                    'CALCULA_RENDIMIENTO()
                    Case 1
                    'CALCULA_RENDIMIENTO_VIKINGOS()
                    Case 2
                        'CALCULA_RENDIMIENTO_FLORES()
                        If Fg.Col <> 18 Then
                            e.Cancel = True
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_LeaveEdit(sender As Object, e As RowColEventArgs) Handles Fg.LeaveEdit
        Try
            Select Case TIPO_TAB
                Case 0
                    'CALCULA_RENDIMIENTO()
                Case 1
                    'CALCULA_RENDIMIENTO_VIKINGOS()
                Case 2
                    'CALCULA_RENDIMIENTO_FLORES()
                    '         19             20   21                 22                        23    
                    's &+= dr("KMS") & vbTab & CADENA1 & vbTab & dr("CVE_CAP1") & vbTab & dr("CVE_CAP2")
                    If Fg.Row > 0 Then
                        If Fg.Col = 18 Then
                            If Not IsNothing(Fg.Editor) Then
                                If IsNumeric(Fg.Editor.Text) Then
                                    If CDec(Fg.Editor.Text) > 0 Then
                                        Fg(Fg.Row, 19) = Fg(Fg.Row, 22) * CDec(Fg.Editor.Text)
                                        Fg(Fg.Row, 20) = Fg(Fg.Row, 23) * CDec(Fg.Editor.Text)
                                        Fg(Fg.Row, 21) = Fg(Fg.Row, 24) * CDec(Fg.Editor.Text)

                                        CALCULA_RENDIMIENTO_FLORES()
                                    Else
                                        Fg.Editor.Text = 1
                                    End If
                                End If
                            End If
                        End If
                    End If
            End Select

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TRPM_MAX_TextChanged(sender As Object, e As EventArgs) Handles TRPM_MAX.TextChanged
        Try
            If IsNumeric(TRPM_MAX.Text) And IsNumeric(LTRPM_MAX.Text) Then
                If CDec(TRPM_MAX.Text) > CDec(LTRPM_MAX.Text) Then
                    TCALIF_RPM.Text = "0"
                Else
                    TCALIF_RPM.Text = LTCALIF_RPM_MAX.Text
                End If
            End If

            Dim CAL11 As Decimal, CAL22 As Decimal, CAL33 As Decimal, CAL44 As Decimal
            Try
                If IsNumeric(TCAL_FAC_CAR_EVA.Text.Replace(",", "")) Then
                    CAL11 = TCAL_FAC_CAR_EVA.Text.Replace(",", "")
                Else
                    CAL11 = 0
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(TCAL_RAL_EVA.Text.Replace(",", "")) Then
                    CAL22 = TCAL_RAL_EVA.Text.Replace(",", "")
                Else
                    CAL22 = 0
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(tCALIF_VEL_MX.Text.Replace(",", "")) Then
                    CAL33 = tCALIF_VEL_MX.Text.Replace(",", "")
                Else
                    CAL33 = 0
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(TCALIF_RPM.Text.Replace(",", "")) Then
                    CAL44 = TCALIF_RPM.Text.Replace(",", "")
                Else
                    CAL44 = 0
                End If
            Catch ex As Exception
            End Try

            TCAL_GLO_EVA.Text = CAL11 + CAL22 + CAL33 + CAL44

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDESCT_TextChanged(sender As Object, e As EventArgs) Handles TDESCT.TextChanged
        Try
            If Not IsNothing(TDESCT.Text) And Not IsNothing(TTIEMPO_MARCH_INERCIA.Text) Then
                If IsNumeric(TTIEMPO_MARCH_INERCIA.Text.Replace(",", "")) And IsNumeric(TDESCT.Text) Then
                    TCARGO_X_PUNTO_MUERTO.Value = CDec(TTIEMPO_MARCH_INERCIA.Text.Replace(",", "")) - CDec(TDESCT.Text)
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTIEMPO_MARCH_INERCIA_TextChanged(sender As Object, e As EventArgs) Handles TTIEMPO_MARCH_INERCIA.TextChanged
        Try
            If Not IsNothing(TDESCT.Value) And Not IsNothing(TTIEMPO_MARCH_INERCIA.Text) Then
                If IsNumeric(TTIEMPO_MARCH_INERCIA.Text.Replace(",", "")) And IsNumeric(TDESCT.Value) Then
                    TCARGO_X_PUNTO_MUERTO.Value = CDec(TTIEMPO_MARCH_INERCIA.Text.Replace(",", "")) - CDec(TDESCT.Text)
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEva_Click(sender As Object, e As EventArgs) Handles BtnEva.Click
        Try
            Var2 = "GCCATEVA"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString   'NOMBRE MOTOR
                'Var6 = Fg(Fg.Row, 3).ToString   'FULL SENCILLO
                TCVE_EVA.Text = Var4
                LtEva.Text = Var5 & " " & Var6

                If IsNumeric(TCVE_EVA.Text) Then
                    DESPLEGAR_EVA(Convert.ToInt32(TCVE_EVA.Text))
                End If

                Var2 = "" : Var4 = "" : Var5 = ""
                TLTS_VALES.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_EVA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_EVA.KeyDown
        If e.KeyValue = Keys.F2 Then
            BtnEva_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_EVA_Validated(sender As Object, e As EventArgs) Handles TCVE_EVA.Validated
        Try
            If TCVE_EVA.Text.Trim.Length > 0 Then

                Var3 = TCVE_MOT.Text
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCCATEVA", TCVE_EVA.Text)
                If DESCR <> "" Then
                    LtEva.Text = DESCR
                    If IsNumeric(TCVE_EVA.Text) Then
                        DESPLEGAR_EVA(Convert.ToInt32(TCVE_EVA.Text))
                    End If
                Else
                    MsgBox("Evaluación inexistente")
                    TCVE_EVA.Text = ""
                    LtEva.Text = ""
                    TLTS_VALES.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub THORAS_GEN3_TextChanged(sender As Object, e As EventArgs) Handles THORAS_GEN3.TextChanged
        Try
            If Not IsNothing(THORAS_GEN3.Text) And Not IsNothing(THORAS_GEN4.Text) Then
                If IsNumeric(THORAS_GEN4.Text.Replace(",", "")) And IsNumeric(THORAS_GEN3.Text) Then
                    THORAS_USO2.Value = THORAS_GEN4.Value - CDec(THORAS_GEN3.Text.Replace(",", ""))
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub THORAS_GEN4_TextChanged(sender As Object, e As EventArgs) Handles THORAS_GEN4.TextChanged
        Try
            If Not IsNothing(THORAS_GEN3.Value) And Not IsNothing(THORAS_GEN4.Text) Then
                If IsNumeric(THORAS_GEN4.Text.Replace(",", "")) And IsNumeric(THORAS_GEN3.Value) Then
                    THORAS_USO2.Value = CDec(THORAS_GEN4.Text.Replace(",", "")) - THORAS_GEN3.Text
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnHelpnumViajes_Click(sender As Object, e As EventArgs) Handles BtnHelpnumViajes.Click

        MsgBox("El bono de toma desde GCCATEVA filtrando el motor " & TCVE_MOT.Text & " y buscando que la suma de 
               (CAL_FAC_CAR_EVA + CAL_RAL_EVA + CALIF_VEL_MX + CALIF_RPM) = CALIF_GLOBAL, si es igual toma 
                el contenido del campo BONO")

    End Sub

    Private Sub BtnBonosMotor_Click(sender As Object, e As EventArgs) Handles BtnBonosMotor.Click
        Var2 = TCVE_MOT.Text
        Var3 = LtMotor.Text
        FrmBonosMotor.ShowDialog()
    End Sub
    Private Sub BtnGen1_Click(sender As Object, e As EventArgs) Handles BtnGen1.Click
        Try
            Var2 = "NumGen"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUMGEN1.Text = Var4
                LtGen1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TNUMGEN2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUMGEN1_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUMGEN1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGen1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TNUMGEN1_Validated(sender As Object, e As EventArgs) Handles TNUMGEN1.Validated
        Try
            If TNUMGEN1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("NumGen", TNUMGEN1.Text)
                If DESCR <> "" Then
                    LtGen1.Text = DESCR
                Else
                    MsgBox("Num. generador 1 inexistente")
                    TNUMGEN1.Text = ""
                    LtGen1.Text = ""
                End If
            Else
                LtGen1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGen2_Click(sender As Object, e As EventArgs) Handles BtnGen2.Click
        Try
            Var2 = "NumGen"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUMGEN2.Text = Var4
                LtGen2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLTSDESCGEN.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUMGEN2_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUMGEN2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGen2_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TNUMGEN2_Validated(sender As Object, e As EventArgs) Handles TNUMGEN2.Validated
        Try
            If TNUMGEN2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("NumGen", TNUMGEN2.Text)
                If DESCR <> "" Then
                    LtGen2.Text = DESCR
                Else
                    MsgBox("Num. generador 2 inexistente")
                    TNUMGEN2.Text = ""
                    LtGen2.Text = ""
                End If
            Else
                LtGen2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDescXLts2_Click(sender As Object, e As EventArgs) Handles BtnDescXLts2.Click
        TLTS_DESCONTAR2.BackColor = Color.Cyan
        TPRECIO_X_LTS2.BackColor = Color.Cyan
        MsgBox("Desc. x litros = Lts. a descontar *  Precio x litro")
    End Sub

    Private Sub BtnBonoFull_Click(sender As Object, e As EventArgs) Handles BtnBonoFull.Click

    End Sub

    Private Sub BtnBono1_Click(sender As Object, e As EventArgs) Handles BtnBono1.Click

    End Sub
End Class
