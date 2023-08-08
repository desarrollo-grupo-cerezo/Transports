Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FrmCartaPorteAE
    Private ISNEW As Boolean
    Private IEPS As Single
    Private SERIE_CP As String = ""
    Private VALOR_DECLA_DESDE_SAE As Integer = 0
    Private vIMPU1 As Single
    Private vIMPU2 As Single
    Private vIMPU3 As Single
    Private vIMPU4 As Single
    Private vIMP1APLA As Integer
    Private vIMP2APLA As Integer
    Private vIMP3APLA As Integer
    Private vIMP4APLA As Integer
    Private vPRECIO1 As Decimal
    Private USUARIO_REACTIVADOR As Boolean = False
    Private CVE_D_CAMPLIBCTE As Integer = 0
    Private LIB_CLIENTE As String = ""
    Private CVE_ART_TARIFA As String
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGA_DATOS_INCIALES1()
        PROCESO_BUSCAR_CARTA_PORTE()
        CARGA_PARAM_INVENT()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Sub CARGA_DATOS_INCIALES1()

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try
        Try
            AssignValidation(Me.TCVE_OPER, ValidationType.Only_Numbers)

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'F2.CustomFormat = "dd/MM/yyyy"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'F2.EditFormat.CustomFormat = "dd/MM/yyyy"

        F3.Value = Date.Today
        'F3.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'F3.CustomFormat = "dd/MM/yyyy"
        'F3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'F3.EditFormat.CustomFormat = "dd/MM/yyyy"


        FRC.Value = Date.Today
        FRC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FRC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat

        FRD.Value = Date.Today
        FRD.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FRD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat


        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True

        Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 15
        Tab1.Top = 0
        Tab1.Left = 0
        'Tab1.Dock = DockStyle.Fill

        AssignValidation(Me.TCVE_ART, ValidationType.Only_Numbers)

        TCVE_PLAZA.ReadOnly = True
        TCVE_PLAZA2.ReadOnly = True


        DERECHOS()

        IEPS = 4
        Try
            SQL = "SELECT ISNULL(IEPS,4)AS RET, VALOR_DECLA_DESDE_SAE FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        IEPS = dr("RET")
                        VALOR_DECLA_DESDE_SAE = dr.ReadNullAsEmptyInteger("VALOR_DECLA_DESDE_SAE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        TCANT.Value = 1
        TFLETE.Value = 0
        TFLETE.Tag = "0"


        TREM_CARGA1.Text = "" : TPESO_BRUTO1.Value = 0 : TTARA1.Value = 0
        TREM_CARGA2.Text = "" : TPESO_BRUTO2.Value = 0 : TTARA2.Value = 0
        TREM_CARGA3.Text = "" : TPESO_BRUTO3.Value = 0 : TTARA3.Value = 0
        TREM_CARGA4.Text = "" : TPESO_BRUTO4.Value = 0 : TTARA4.Value = 0

        LtStatus.Text = ""
        LtCartaPorte.Text = ""
        LtCartaPorte2.Text = ""

        TCVE_COBRO.Text = ""
        TCVE_VIAJE.Text = ""
        TCVE_VIAJE.Tag = ""
        F1.Value = Now
        TCVE_COBRO.Text = ""
        F2.Value = Now
        TRECOGER_EN.Text = ""
        TENTREGAR_EN.Text = ""

        TCVE_TRACTOR.Text = ""
        TCVE_TANQUE1.Text = ""
        TCVE_TANQUE2.Text = ""
        TCVE_DOLLY.Text = ""

        TCVE_TRACTOR.Tag = ""
        TCVE_TANQUE1.Tag = ""
        TCVE_TANQUE2.Tag = ""
        TCVE_DOLLY.Tag = ""

        LTractor.Tag = " "
        LTanque1.Tag = " "
        LTanque2.Tag = " "
        LDolly.Tag = " "

        TCVE_OPER.Tag = " "
        TCLAVE_O.Tag = " "
        TCLAVE_D.Tag = " "
        TRECOGER_EN.Tag = " "
        TENTREGAR_EN.Tag = " "

        RichObsPedidos.Tag = "0"
        RichObsBaja.Tag = "0"
        LtStatus.Tag = "0"

        TCVE_OPER.Text = ""

        TCVE_ART.Text = ""
        Tab1.SelectedIndex = 0
    End Sub

    Private Sub FrmCartaPorteAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        BtnProd.FlatStyle = FlatStyle.Flat
        BtnProd.FlatAppearance.BorderSize = 0
        BtnValorDecla.FlatStyle = FlatStyle.Flat
        BtnValorDecla.FlatAppearance.BorderSize = 0
        BtnEsquema.FlatStyle = FlatStyle.Flat
        BtnEsquema.FlatAppearance.BorderSize = 0

    End Sub
    Sub PROCESO_BUSCAR_CARTA_PORTE()
        Dim FLETE As Decimal

        LtTimbrada.Text = ""
        LtTimbrada.Visible = False

        If Var1 = "Nuevo" Then
            ISNEW = True
            Try
                LtCartaPorte.Text = SIGUIENTE_SERIE_CARTA_PORTE()
                LtCartaPorte2.Text = LtCartaPorte.Text

                SERIE_CP = Var24

                TCVE_VIAJE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            ISNEW = False
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_FOLIO, C.CVE_VIAJE, P2.CVE_CON, C.CVE_DOCR, C.CLIENTE, C.FECHA_DOC, C.STATUS, C.TIPO_VIAJE, C.TIPO_UNI, C.CVE_OPER, 
                    C.CLAVE_O, C.CLAVE_D, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, C.CVE_PLAZA1, 
                    C.CVE_PLAZA2, CVE_COBRO, 
                    ISNULL(REM_CARGA1,'') AS REM1, ISNULL(PESO_BRUTO1,0) AS PESO1, ISNULL(TARA1,0) AS T1, 
                    ISNULL(REM_CARGA2,'') AS REM2, ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, 
                    ISNULL(REM_CARGA3,'') AS REM3, ISNULL(PESO_BRUTO3,'0') AS PESO3, ISNULL(TARA3,'0') AS T3, 
                    ISNULL(REM_CARGA4,'') AS REM4, ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4, 
                    CVE_TIPO_PAGO, C.CVE_ART, FLETE, C.FECHA_CARGA, C.FECHA_DESCARGA, C.FECHA_REAL_CARGA, C.FECHA_REAL_DESCARGA, 
                    ISNULL(ST_CARTA_PORTE,1) AS ST_CP, 
                    ISNULL(ST.DESCR,'EDICION') AS STA_CARTAP, CVE_DOCP, C.ORDEN_DE, C.EMBARQUE, C.CARGA_ANTERIOR, C.REM_CARGA, C.CVE_VAL_DECLA,
                    VALOR_DECLARADO, C.CVE_MAT, SUBTOTAL, IVA, RETENCION, NETO, ISNULL(CANT,0) AS CANTIDAD, C.PEDIMENTO, C.OBSER_CFDI, 
                    ISNULL(CVE_ESQIMPU,0) AS CVE_ESQ, ISNULL(TIMBRADA,'') AS TIMBRA, C.CVE_TAB_VIAJE, R.CVE_TAB,
                    ISNULL(CVE_OBSP,0) AS OBSP, ISNULL(O.DESCR,'') AS DES_OBS, ISNULL(CVE_OBS_BAJA,0) AS CVEOBSBAJA, ISNULL(O2.DESCR,'') AS DES_OBS_BAJA,
                    ISNULL((SELECT LEYENDA FROM GCPEDIDOS WHERE CVE_DOC = C.CVE_DOCP),'') AS CVE_DOC_PED, ISNULL(C.CVE_TIPO_OPE,0) AS C_T_OPE 
                    FROM GCCARTA_PORTE C 
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBSP
                    LEFT JOIN GCOBS O2 ON O2.CVE_OBS = C.CVE_OBS_BAJA
                    LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = C.CVE_VIAJE 
                    LEFT JOIN GCPEDIDOS P2 ON P2.CVE_DOC = C.CVE_DOCP
                    LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = C.ST_CARTA_PORTE 
                    WHERE CVE_FOLIO = '" & Var2 & "' AND C.STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    LtCartaPorte.Text = dr("CVE_FOLIO").ToString
                    LtCartaPorte2.Text = LtCartaPorte.Text
                    LtRemision.Text = dr.ReadNullAsEmptyString("CVE_DOCR")

                    If LtRemision.Text = "0" Then LtRemision.Text = ""

                    TCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                    If TCVE_VIAJE.Text.Trim.Length > 0 Then
                        If PASS_GRUPOCE = "BUS" Then
                            TCVE_VIAJE.Enabled = True
                            btnNoViaje.Enabled = True
                        Else
                            TCVE_VIAJE.Enabled = False
                            btnNoViaje.Enabled = False
                        End If
                    End If
                    'PEDIDO
                    LtCVE_DOC.Text = dr.ReadNullAsEmptyString("CVE_DOCP")
                    Try
                        TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                        tEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                        tCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                        TCANT.Value = dr("CANTIDAD")
                        TPEDIMENTO.Text = dr.ReadNullAsEmptyString("PEDIMENTO")

                        If TPEDIMENTO.Text = "0" Then TPEDIMENTO.Text = ""

                        TCVE_OBS.Text = dr.ReadNullAsEmptyString("OBSER_CFDI")
                        If TCVE_OBS.Text = "0" Then
                            TCVE_OBS.Text = ""
                        End If

                        If dr.ReadNullAsEmptyString("CVE_TAB_VIAJE").Trim.Length > 0 Then
                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB_VIAJE")
                        Else
                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB")
                        End If

                        If TCVE_TAB_VIAJE.Text = "0" Then TCVE_TAB_VIAJE.Text = ""

                        LtCVE_CON.Text = dr.ReadNullAsEmptyString("CVE_CON")

                        TCVE_ESQIMPU.Text = dr("CVE_ESQ")
                        If TCVE_ESQIMPU.Text = "0" Then TCVE_ESQIMPU.Text = ""
                        If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                            LtEsquema.Text = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                        End If
                        LtLeyenda.Text = dr("CVE_DOC_PED")

                        RichObsPedidos.Text = dr("DES_OBS")
                        RichObsPedidos.Tag = dr("OBSP")

                        RichObsBaja.Text = dr("DES_OBS_BAJA")
                        RichObsBaja.Tag = dr("CVEOBSBAJA")

                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    TCLIENTE.Text = dr("CLIENTE").ToString
                    BUSCA_CLIENTE(TCLIENTE.Text)
                    If IsDate(dr("FECHA_DOC").ToString) Then
                        F1.Value = dr("FECHA_DOC").ToString
                    Else
                        F1.Value = Now
                    End If
                    TCVE_COBRO.Text = dr("CVE_COBRO").ToString
                    LtTipoCrobro.Text = BUSCA_CAT("Tipo de cobro", TCVE_COBRO.Text) 'BUSCA EM CATALOGOS

                    LtStatus.Text = dr("STA_CARTAP")
                    LtStatus.Tag = dr("ST_CP")

                    If LtStatus.Text = "" Then LtStatus.Text = BUSCA_CAT("GCSTATUS_CARTA_PORTE", "1")

                    Try
                        If LtStatus.Text <> "EDICION" And LtStatus.Text <> "REGRESO" Then
                            BarCerrarCartaPorte.Enabled = False
                            BarGrabar.Enabled = False
                        End If
                    Catch ex As Exception
                    End Try

                    TCVE_OPER.Text = dr("CVE_OPER").ToString
                    LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If

                    TCVE_TRACTOR.Text = dr("CVE_TRACTOR").ToString
                    LTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                    TCVE_TANQUE1.Text = dr("CVE_TANQUE1").ToString
                    LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                    TCVE_TANQUE2.Text = dr("CVE_TANQUE2").ToString
                    LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                    TCVE_DOLLY.Text = dr("CVE_DOLLY").ToString
                    LDolly.Text = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)

                    TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text
                    TCVE_TANQUE1.Tag = TCVE_TANQUE1.Text
                    TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text
                    TCVE_DOLLY.Tag = TCVE_DOLLY.Text

                    LTractor.Tag = TCVE_TRACTOR.Text
                    LTanque1.Tag = TCVE_TANQUE1.Text
                    LTanque2.Tag = TCVE_TANQUE2.Text
                    LDolly.Tag = TCVE_DOLLY.Text

                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If

                    TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                    TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                    LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)

                    LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)

                    If LtRecogerEn.Text.Trim.Length = 0 Then
                        TRECOGER_EN.Text = ""
                        TRECOGER_EN.Tag = ""
                    End If
                    If LtEntregarEn.Text.Trim.Length = 0 Then
                        TENTREGAR_EN.Text = ""
                        TENTREGAR_EN.Tag = ""
                    End If

                    TCLAVE_O.Text = dr("CLAVE_O")
                    TCLAVE_D.Text = dr("CLAVE_D")

                    '++++++++++++ - - --   TAG'S
                    TCLAVE_O.Tag = TCLAVE_O.Text
                    TCLAVE_D.Tag = TCLAVE_D.Text
                    TRECOGER_EN.Tag = TRECOGER_EN.Text
                    TENTREGAR_EN.Tag = TENTREGAR_EN.Text
                    TCVE_OPER.Tag = TCVE_OPER.Text
                    '++++++++++++ FIN TAGS'S

                    If dr("TIPO_VIAJE").ToString = "1" Then
                        RadCargado.Checked = True
                        RadVacio.Checked = False
                    Else
                        RadCargado.Checked = False
                        RadVacio.Checked = True
                    End If

                    Try
                        F2.Value = dr("FECHA_CARGA").ToString
                        F3.Value = dr("FECHA_DESCARGA").ToString
                    Catch ex As Exception
                    End Try
                    Try
                        FRC.Value = dr("FECHA_REAL_CARGA")
                        FRD.Value = dr("FECHA_REAL_DESCARGA")
                    Catch ex As Exception
                    End Try

                    DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)

                    TREM_CARGA1.Text = dr("REM1").ToString

                    TPESO_BRUTO1.Value = dr("PESO1").ToString
                    TTARA1.Value = dr("T1").ToString

                    TREM_CARGA2.Text = dr("REM2").ToString
                    TPESO_BRUTO2.Value = dr("PESO2").ToString
                    TTARA2.Value = dr("T2").ToString

                    TREM_CARGA3.Text = dr("REM3").ToString
                    TPESO_BRUTO3.Value = dr("PESO3").ToString
                    TTARA3.Value = dr("T3").ToString

                    TREM_CARGA4.Text = dr("REM4").ToString
                    TPESO_BRUTO4.Value = dr("PESO4").ToString
                    TTARA4.Value = dr("T4").ToString

                    Try
                        LtPesoNeto1.Text = Format(TPESO_BRUTO1.Text - TTARA1.Value, "###,###,##0.000")
                        LtPesoNeto5.Text = Format((TPESO_BRUTO1.Text - TTARA1.Value) + (TPESO_BRUTO3.Value - TTARA3.Value), "###,###,##0.000")

                        LtPesoNeto4.Text = Format(TPESO_BRUTO4.Value - TTARA4.Text, "###,###,##0.000")
                        LtPesoNeto6.Text = Format((TPESO_BRUTO2.Text - TTARA2.Value) + (TPESO_BRUTO4.Value - TTARA4.Value), "###,###,##0.000")

                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        Select Case dr.ReadNullAsEmptyInteger("REM_CARGA")
                            Case 1
                                RadRemCarga1.Checked = True
                            Case 2
                                RadRemCarga2.Checked = True
                            Case 3
                                RadRemCarga3.Checked = True
                            Case 4
                                RadRemCarga4.Checked = True
                            Case Else
                                RadPrecioXViaje.Checked = True
                        End Select
                        If dr("ST_CP") <> 1 And dr("ST_CP") <> 4 Then
                            TENTREGAR_EN.Enabled = False
                            TRECOGER_EN.Enabled = False
                            btnEntregarEn.Enabled = False
                            btnRecogerEn.Enabled = False

                            DESHABILITAR_CARTA_PORTE()

                            TVALOR_DECLA.Enabled = False
                            TCVE_ART.Enabled = False
                            TCANT.Enabled = False
                        End If
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If IsNumeric(dr("CVE_ART").ToString) Then
                        TCVE_ART.Text = dr("CVE_ART").ToString
                        LtDescr.Text = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text, False)
                    End If

                    FLETE = dr.ReadNullAsEmptyDecimal("FLETE")
                    Try
                        TFLETE.Value = FLETE
                        TFLETE.Tag = TFLETE.Value

                        'VALOR_DECLA_DESDE_SAE = se carga desde datos iniciales
                        If VALOR_DECLA_DESDE_SAE = 0 Then
                            TVALOR_DECLA.Text = dr.ReadNullAsEmptyInteger("CVE_VAL_DECLA") 'ARTICULO GCVALOR_DECLARADO 
                            If TVALOR_DECLA.Text = "0" Then TVALOR_DECLA.Text = ""
                            If dr.ReadNullAsEmptyInteger("CVE_VAL_DECLA") > 0 Then
                                LtDescrTipoPago.Text = BUSCA_CAT("Valor Declarado", TVALOR_DECLA.Text)
                            End If
                            LtImporteValorDeclarado.Text = Format(dr.ReadNullAsEmptyDecimal("VALOR_DECLARADO"), "###,###,##0.00")

                            LtSubTotal.Text = Format(dr("SUBTOTAL"), "###,###,##0.00")
                            LtIVA.Text = Format(dr("IVA"), "###,###,##0.00")
                            LtRet.Text = Format(dr("RETENCION"), "###,###,##0.00")
                            LtNeto.Text = Format(dr("NETO"), "###,###,##0.00")
                        Else
                            TVALOR_DECLA.Text = dr.ReadNullAsEmptyString("CVE_MAT") 'ARTICULO GCVALOR_DECLARADO 
                            If TVALOR_DECLA.Text = "0" Then TVALOR_DECLA.Text = ""
                            LtImporteValorDeclarado.Text = Format(dr.ReadNullAsEmptyDecimal("VALOR_DECLARADO"), "###,###,##0.00")
                            'X TIPO DE PAGO SEGUNDA CLAVE 
                            If TVALOR_DECLA.Text.Trim.Length > 0 Then
                                LtDescrTipoPago.Text = BUSCA_CAT("InvesSAE", TVALOR_DECLA.Text)
                                'SOLO LO OBTIENE LOS DATOS DEL ARTICULO Y LOS ASIGNA A UNA VARIABLE

                                DESPLEGAR_ARTICULO_SAE(TVALOR_DECLA.Text)

                                If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                                    CALCUAL_NUEVO_ESQUEMA(TCVE_ESQIMPU.Text)
                                End If
                                '1

                                CALCULA_PRECIO_CARTA_PORTE()

                            Else '2
                                LtDescrTipoPago.Text = ""
                                LtSubTotal.Text = Format(dr("SUBTOTAL"), "###,###,##0.00")
                                LtIVA.Text = Format(dr("IVA"), "###,###,##0.00")
                                LtRet.Text = Format(dr("RETENCION"), "###,###,##0.00")
                                LtNeto.Text = Format(dr("NETO"), "###,###,##0.00")
                            End If
                        End If

                        If dr("TIMBRA") = "S" Then
                            LtTimbrada.Visible = True
                            LtTimbrada.Text = "TIMBRADA"
                        End If

                        LtTipoOpe.Text = dr("C_T_OPE")
                        LtTipoOpeDes.Text = BUSCA_CAT("GCTIPO_OPERACION", dr("C_T_OPE"))
                        If LtTipoOpeDes.Text = "0" Then LtTipoOpeDes.Text = ""
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End If
                dr.Close()
                LtCartaPorte.Enabled = False

                If LOper.Text = "0" Then
                    LOper.Text = ""
                End If

                TCVE_COBRO.Select()
            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If LtTimbrada.Text = "TIMBRADA" Then
                TENTREGAR_EN.Enabled = False
                TRECOGER_EN.Enabled = False
                btnEntregarEn.Enabled = False
                btnRecogerEn.Enabled = False

                DESHABILITAR_CARTA_PORTE()

                TVALOR_DECLA.Enabled = False
                TCVE_ART.Enabled = False
                TCANT.Enabled = False
                TCVE_OBS.Enabled = False
                RichObsPedidos.Enabled = False
            End If

            If LtRemision.Text.Trim.Length = 0 Then
                SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem3, True)
                SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem4, True)
                SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem5, True)

                BarGrabar.Enabled = True
            End If

            If USUARIO_REACTIVADOR And LtTimbrada.Text = "TIMBRADA" Then
                DESHABILITAR_CARTA_PORTE(True)

                SET_ALL_CONTROL_READ_AND_ENABLED(Gpo2)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gpo3)

            End If
        End If
    End Sub
    Sub CARGA_PARAM_INVENT()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(CVE_ART_TARIFA,0) AS CVE_ART, ISNULL(CVE_D_CAMPLIBCTE,0) AS C_D_CAMPLIBCTE, 
                ISNULL(LIB_CLIENTE,'') AS L_CLIENTE
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                CVE_D_CAMPLIBCTE = dr("C_D_CAMPLIBCTE")
                LIB_CLIENTE = dr("L_CLIENTE")

                CVE_ART_TARIFA = dr("CVE_ART")
            Else
                CVE_ART_TARIFA = ""
                CVE_D_CAMPLIBCTE = 0
                LIB_CLIENTE = ""
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub DERECHOS()

        USUARIO_REACTIVADOR = False

        If Not pwPoder Then
            Try
                BarGrabar.Visible = False
                BarCerrarCartaPorte.Visible = False
                BarImprimir.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                ((CLAVE >= 22500 And CLAVE < 22590) Or (CLAVE >= 222550 And CLAVE < 222600) OR CLAVE = 23535)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 22540  'GRABAR 
                                    BarGrabar.Visible = True
                                Case 22580  'CERRAR CARTA PORTE
                                    BarCerrarCartaPorte.Visible = True
                                Case 22590  'IMPIRMIR CARTA PORTE
                                    BarImprimir.Visible = True
                                Case 222550 'GENERALES
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo3)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo4)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo5)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box4)
                                Case 222570 'INSTRUCCIONES DE VIAJE
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo6)
                                Case 23535
                                    USUARIO_REACTIVADOR = True
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
    Sub DESHABILITAR_CARTA_PORTE(Optional fENABLED As Boolean = False)
        Try
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo1, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo2, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo3, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo4, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo5, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gpo6, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(Box4, fENABLED)

            SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem1, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem2, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem3, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem4, fENABLED)
            SET_ALL_CONTROL_READ_AND_ENABLED(GpoRem5, fENABLED)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmCartaPorteAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmCartaPorteAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim BRUTO1 As Decimal, TARA1 As Decimal, BRUTO2 As Decimal, TARA2 As Decimal, BRUTO3 As Decimal, TARA3 As Decimal, BRUTO4 As Decimal
        Dim TARA4 As Decimal, FLETE As Decimal, TIPO_UNI As Integer, REM_CARGA As Integer, CVE_VAL_DECLA As Long, VALOR_DECLARADO As Decimal = 0
        Dim CVE_MAT As String = "", CANT As Decimal, SeGrabo As Boolean = False, CVE_OBS As Long, CVE_OBS_BAJA As Long
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                    TCLIENTE.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If String.IsNullOrEmpty(TPESO_BRUTO1.Text) Then
                BRUTO1 = TPESO_BRUTO1.Value
            Else
                BRUTO1 = TPESO_BRUTO1.Text
            End If
            If String.IsNullOrEmpty(TPESO_BRUTO2.Text) Then
                BRUTO2 = TPESO_BRUTO2.Value
            Else
                BRUTO2 = TPESO_BRUTO2.Text
            End If
            If String.IsNullOrEmpty(TPESO_BRUTO3.Text) Then
                BRUTO3 = TPESO_BRUTO3.Value
            Else
                BRUTO3 = TPESO_BRUTO3.Text
            End If
            If String.IsNullOrEmpty(TPESO_BRUTO4.Text) Then
                BRUTO4 = TPESO_BRUTO4.Value
            Else
                BRUTO4 = TPESO_BRUTO4.Text
            End If

            If String.IsNullOrEmpty(TTARA1.Text) Then
                TARA1 = TTARA1.Value
            Else
                TARA1 = TTARA1.Text
            End If
            If String.IsNullOrEmpty(TTARA2.Text) Then
                TARA2 = TTARA2.Value
            Else
                TARA2 = TTARA2.Text
            End If
            If String.IsNullOrEmpty(TTARA3.Text) Then
                TARA3 = TTARA3.Value
            Else
                TARA3 = TTARA3.Text
            End If
            If String.IsNullOrEmpty(TTARA4.Text) Then
                TARA4 = TTARA4.Value
            Else
                TARA4 = TTARA4.Text
            End If
            If String.IsNullOrEmpty(TFLETE.Text) Then
                FLETE = TFLETE.Value
            Else
                FLETE = TFLETE.Text
            End If
            If LtTipoViaje.Text = "Full" Then
                TIPO_UNI = 1
            Else
                TIPO_UNI = 0
            End If
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If ISNEW Then
            Try
                LtCartaPorte.Text = OBTENER_ULTIMO_FOLIO_CARTA_PORTE()
            Catch ex As Exception
                Bitacora("514. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("514. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If LtCartaPorte.Text.Trim.Length = 0 Then
            MsgBox("El folio no debe quedar vacio, verifique por favor")
            Return
        End If

        Try
            If RadRemCarga1.Checked Then
                REM_CARGA = 1
            ElseIf RadRemCarga2.Checked Then
                REM_CARGA = 2
            ElseIf RadRemCarga3.Checked Then
                REM_CARGA = 3
            ElseIf RadRemCarga4.Checked Then
                REM_CARGA = 4
            End If
        Catch ex As Exception
            Bitacora("514. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If IsNumeric(TVALOR_DECLA.Text) Then
                CVE_VAL_DECLA = TVALOR_DECLA.Text
            Else
                CVE_VAL_DECLA = 0
            End If

            If VALOR_DECLA_DESDE_SAE = 0 Then
                If IsNumeric(LtImporteValorDeclarado.Text.Replace(",", "")) Then
                    VALOR_DECLARADO = LtImporteValorDeclarado.Text.Replace(",", "").Trim
                End If
                CVE_MAT = TVALOR_DECLA.Text 'CLAVE ARTICULO INVE01
            Else
                CVE_MAT = TVALOR_DECLA.Text 'CLAVE ARTICULO INVE01
                If IsNumeric(LtImporteValorDeclarado.Text.Replace(",", "").Trim) Then
                    VALOR_DECLARADO = LtImporteValorDeclarado.Text.Replace(",", "").Trim
                End If
            End If
        Catch ex As Exception
            VALOR_DECLARADO = 0
        End Try
        Try
            CANT = TCANT.Text
        Catch ex As Exception
            CANT = 0
        End Try

        Try
            If RichObsPedidos.Text.Trim.Length > 0 Then
                CVE_OBS = Val(RichObsPedidos.Tag.ToString)
                CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, RichObsPedidos.Text)
            Else
                CVE_OBS = 0
            End If
        Catch ex As Exception
            Bitacora("39. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If RichObsBaja.Text.Trim.Length > 0 Then
                CVE_OBS_BAJA = Val(RichObsBaja.Tag.ToString)
                CVE_OBS_BAJA = INSERT_UPDATE_GCOBS(CVE_OBS, RichObsBaja.Text)
            Else
                CVE_OBS_BAJA = 0
            End If
            'RichObsBaja.Text = dr("DES_OBS_BAJA")
            'RichObsBaja.Tag = dr("CVEOBSBAJA")
        Catch ex As Exception
            Bitacora("39. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If ISNEW Then
            SQL = "INSERT INTO GCCARTA_PORTE (CVE_CAP, CVE_FOLIO, CVE_VIAJE, ST_CARTA_PORTE, CLIENTE, FECHA_DOC, FECHA_CARGA, FECHA_DESCARGA, 
                FECHA_REAL_CARGA, FECHA_REAL_DESCARGA, STATUS, CVE_COBRO, CVE_OBSP, CVE_OBS_BAJA, TIPO_UNI, TIPO_VIAJE, CVE_OPER, CLAVE_O, CLAVE_D, CVE_TRACTOR, 
                CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, RECOGER_EN, ENTREGAR_EN, CVE_PLAZA1, CVE_PLAZA2, REM_CARGA1, PESO_BRUTO1, TARA1, REM_CARGA2, 
                PESO_BRUTO2, TARA2, REM_CARGA3, PESO_BRUTO3, TARA3, REM_CARGA4, PESO_BRUTO4, TARA4, CVE_ART, FLETE, SUBTOTAL, IVA, RETENCION, NETO, 
                ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, REM_CARGA, CVE_VAL_DECLA, VALOR_DECLARADO, CVE_MAT, CANT, SERIE, PEDIMENTO, OBSER_CFDI, 
                CVE_TAB_VIAJE, CVE_ESQIMPU, CVE_TIPO_OPE, FECHAELAB, UUID) VALUES(
                (SELECT ISNULL(MAX(CVE_CAP),0) + 1 FROM GCCARTA_PORTE), @CVE_FOLIO, @CVE_VIAJE, @ST_CARTA_PORTE, @CLIENTE, @FECHA_DOC, @FECHA_CARGA,
                @FECHA_DESCARGA, @FECHA_REAL_CARGA, @FECHA_REAL_DESCARGA, 'A', @CVE_COBRO, @CVE_OBSP, @CVE_OBS_BAJA, @TIPO_UNI, @TIPO_VIAJE, @CVE_OPER, @CLAVE_O, @CLAVE_D, 
                @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, @RECOGER_EN, @ENTREGAR_EN, @CVE_PLAZA1, @CVE_PLAZA2, @REM_CARGA1, @PESO_BRUTO1, 
                @TARA1, @REM_CARGA2,@PESO_BRUTO2, @TARA2, @REM_CARGA3, @PESO_BRUTO3, @TARA3, @REM_CARGA4, @PESO_BRUTO4, @TARA4, @CVE_ART, @FLETE, 
                @SUBTOTAL, @IVA, @RETENCION, @NETO, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, @REM_CARGA, @CVE_VAL_DECLA, @VALOR_DECLARADO, @CVE_MAT, 
                @CANT, @SERIE, @PEDIMENTO, @OBSER_CFDI, @CVE_TAB_VIAJE, @CVE_ESQIMPU, @CVE_TIPO_OPE, GETDATE(), NEWID())"
        Else
            SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = @CVE_VIAJE, CLIENTE = @CLIENTE, CVE_COBRO = @CVE_COBRO, 
                TIPO_UNI = @TIPO_UNI, TIPO_VIAJE = @TIPO_VIAJE, CVE_OPER = @CVE_OPER, CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_TRACTOR = @CVE_TRACTOR, 
                CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, CVE_DOLLY = @CVE_DOLLY, RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, 
                CVE_PLAZA1 = @CVE_PLAZA1, CVE_PLAZA2 = @CVE_PLAZA2, REM_CARGA1 = @REM_CARGA1, PESO_BRUTO1 = @PESO_BRUTO1, TARA1 = @TARA1, 
                REM_CARGA2 = @REM_CARGA2,PESO_BRUTO2 = @PESO_BRUTO2, TARA2 = @TARA2, REM_CARGA3 = @REM_CARGA3, PESO_BRUTO3 = @PESO_BRUTO3, TARA3 = @TARA3, 
                REM_CARGA4 = @REM_CARGA4, PESO_BRUTO4 = @PESO_BRUTO4, TARA4 = @TARA4, CVE_ART = @CVE_ART, FLETE = @FLETE, SUBTOTAL = @SUBTOTAL, 
                IVA = @IVA, RETENCION = @RETENCION, NETO = @NETO, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA,
                FECHA_REAL_CARGA = @FECHA_REAL_CARGA, FECHA_REAL_DESCARGA = @FECHA_REAL_DESCARGA, CVE_OBSP = @CVE_OBSP, CVE_OBS_BAJA = @CVE_OBS_BAJA,
                ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, REM_CARGA = @REM_CARGA, CVE_VAL_DECLA = @CVE_VAL_DECLA,
                VALOR_DECLARADO = @VALOR_DECLARADO, CVE_MAT = @CVE_MAT, CANT = @CANT, PEDIMENTO = @PEDIMENTO, OBSER_CFDI = @OBSER_CFDI,
                CVE_TAB_VIAJE = @CVE_TAB_VIAJE, CVE_ESQIMPU = @CVE_ESQIMPU, CVE_TIPO_OPE = @CVE_TIPO_OPE
                WHERE CVE_FOLIO = @CVE_FOLIO"
        End If
        cmd.CommandText = SQL

        For k = 1 To 5
            Try
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = LtCartaPorte.Text
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = TCVE_VIAJE.Text
                cmd.Parameters.Add("@ST_CARTA_PORTE", SqlDbType.SmallInt).Value = 1
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F2.Value
                cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F3.Value
                cmd.Parameters.Add("@FECHA_REAL_CARGA", SqlDbType.DateTime).Value = FRC.Value
                cmd.Parameters.Add("@FECHA_REAL_DESCARGA", SqlDbType.DateTime).Value = FRD.Value
                cmd.Parameters.Add("@CVE_COBRO", SqlDbType.VarChar).Value = TCVE_COBRO.Text
                cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = TIPO_UNI
                cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(RadCargado.Checked, 1, 0)
                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = TCVE_DOLLY.Text
                cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                cmd.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = TCVE_PLAZA.Text
                cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = TCVE_PLAZA2.Text

                cmd.Parameters.Add("@REM_CARGA1", SqlDbType.VarChar).Value = TREM_CARGA1.Text
                cmd.Parameters.Add("@PESO_BRUTO1", SqlDbType.Float).Value = BRUTO1
                cmd.Parameters.Add("@TARA1", SqlDbType.Float).Value = TARA1
                cmd.Parameters.Add("@REM_CARGA2", SqlDbType.VarChar).Value = TREM_CARGA2.Text
                cmd.Parameters.Add("@PESO_BRUTO2", SqlDbType.Float).Value = BRUTO2
                cmd.Parameters.Add("@TARA2", SqlDbType.Float).Value = TARA2
                cmd.Parameters.Add("@REM_CARGA3", SqlDbType.VarChar).Value = TREM_CARGA3.Text
                cmd.Parameters.Add("@PESO_BRUTO3", SqlDbType.Float).Value = BRUTO3
                cmd.Parameters.Add("@TARA3", SqlDbType.Float).Value = TARA3
                cmd.Parameters.Add("@REM_CARGA4", SqlDbType.VarChar).Value = TREM_CARGA4.Text
                cmd.Parameters.Add("@PESO_BRUTO4", SqlDbType.Float).Value = BRUTO4
                cmd.Parameters.Add("@TARA4", SqlDbType.Float).Value = TARA4
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = FLETE
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtSubTotal.Text.Replace(",", ""))
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtIVA.Text.Replace(",", ""))
                cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtRet.Text.Replace(",", ""))
                cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtNeto.Text.Replace(",", ""))
                cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = tEMBARQUE.Text
                cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = tCARGA_ANTERIOR.Text
                cmd.Parameters.Add("@REM_CARGA", SqlDbType.SmallInt).Value = REM_CARGA
                cmd.Parameters.Add("@CVE_VAL_DECLA", SqlDbType.Int).Value = CVE_VAL_DECLA 'CLAVE DEL PRODUCTO GCVALOR_DECLARADO 
                cmd.Parameters.Add("@VALOR_DECLARADO", SqlDbType.Float).Value = VALOR_DECLARADO 'MONTO
                cmd.Parameters.Add("@CVE_MAT", SqlDbType.VarChar).Value = CVE_MAT
                cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = SERIE_CP
                cmd.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text
                cmd.Parameters.Add("@OBSER_CFDI", SqlDbType.VarChar).Value = TCVE_OBS.Text
                cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_ESQIMPU.Text)
                cmd.Parameters.Add("@CVE_OBSP", SqlDbType.Int).Value = CVE_OBS
                cmd.Parameters.Add("@CVE_OBS_BAJA", SqlDbType.Int).Value = CVE_OBS_BAJA
                cmd.Parameters.Add("@CVE_TIPO_OPE", SqlDbType.Int).Value = CONVERTIR_TO_INT(LtTipoOpe.Text)
                returnValue = cmd.ExecuteNonQuery()
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        ISNEW = False
                        MsgBox("El registro se grabo satisfactoriamente")
                    End If
                End If
                SeGrabo = True
                Exit For
            Catch ex As Exception
                Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If Not Valida_Conexion() Then
                Return
            End If

            If ISNEW Then
                LtCartaPorte.Text = SIGUIENTE_SERIE_CARTA_PORTE()
            End If
        Next

        If SeGrabo Then

            If TCVE_VIAJE.Text.Trim.Length > 0 Then

                SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_TAB_VIAJE = " & CONVERTIR_TO_LONG(TCVE_TAB_VIAJE.Text) & ", 
                    FECHA_CARGA = '" & FSQL(F2.Value) & "', FECHA_DESCARGA = '" & FSQL(F3.Value) & "' 
                    WHERE CVE_VIAJE = '" & TCVE_VIAJE.Text & "'"
                EXECUTE_QUERY_NET(SQL)
            End If

            Try
                GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se agregó o edito carta porte", TCVE_VIAJE.Text, LtCartaPorte.Text)

                If LTractor.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TRACTOR.Text <> LTractor.Tag Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio la unidad " & LTractor.Tag & " por " & TCVE_TRACTOR.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LTanque1.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TANQUE1.Text <> LTanque1.Tag Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio la unidad " & LTanque1.Tag & " por " & TCVE_TANQUE1.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LTanque2.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TANQUE2.Text <> LTanque2.Tag Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio la unidad " & LTanque2.Tag & " por " & TCVE_TANQUE2.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LDolly.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_DOLLY.Text <> LDolly.Tag Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio la unidad " & LDolly.Tag & " por " & TCVE_DOLLY.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_O.Tag <> TCLAVE_O.Text Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio el cliente operativo " & TCLAVE_O.Tag & " por " & TCLAVE_O.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio el cliente operativo " & TCLAVE_D.Tag & " por " & TCLAVE_D.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                    If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio recoger en " & TRECOGER_EN.Tag & " por " & TRECOGER_EN.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                    If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio entregar en " & TENTREGAR_EN.Tag & " por " & TENTREGAR_EN.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TCVE_OPER.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_OPER.Tag <> TCVE_OPER.Text Then
                        GRABA_BITA(TCLIENTE.Text, LtCartaPorte.Text, 0, "C", "Se cambio el operador " & TCVE_OPER.Tag & " por " & TCVE_OPER.Text,
                                           TCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If

                LTractor.Tag = TCVE_TRACTOR.Text
                LTanque1.Tag = TCVE_TANQUE1.Text
                LTanque2.Tag = TCVE_TANQUE2.Text
                LDolly.Tag = TCVE_DOLLY.Text

                TCLAVE_O.Tag = TCLAVE_O.Text
                TCLAVE_D.Tag = TCLAVE_D.Text
                TRECOGER_EN.Tag = TRECOGER_EN.Text
                TENTREGAR_EN.Tag = TENTREGAR_EN.Text
                TCVE_OPER.Tag = TCVE_OPER.Text
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnTipoCobro_Click(sender As Object, e As EventArgs) Handles btnTipoCobro.Click
        Try
            Var2 = "Tipo de Cobro"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_COBRO.Text = Var4
                LtTipoCrobro.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCLAVE_O.Focus()
            End If
        Catch ex As Exception
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnNoViaje_Click(sender As Object, e As EventArgs) Handles btnNoViaje.Click
        Try
            Var2 = "Asignacion viajes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_VIAJE.Text = Var4
                If ISNEW Then
                    TCVE_VIAJE.Tag = ""
                Else
                    TCVE_VIAJE.Tag = Var4
                End If

                DESPLEGAR_ASIGNACION_VIAJE(TCVE_VIAJE.Text)

                Var2 = "" : Var4 = "" : Var5 = ""
                TCLIENTE.Focus()
            End If
        Catch ex As Exception
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_COBRO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_COBRO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTipoCobro_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            Gpo2.Select()
            'tCLAVE_O.Select()
        End If
    End Sub

    Private Sub TCVE_COBRO_Validated(sender As Object, e As EventArgs) Handles TCVE_COBRO.Validated
        Try
            If TCVE_COBRO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo de cobro", TCVE_COBRO.Text)
                If DESCR <> "" Then
                    LtTipoCrobro.Text = DESCR
                Else
                    MsgBox("Tipo de cobro inexistente")

                    LtTipoCrobro.Text = ""
                    'tCVE_COBRO.Text = ""
                    TCVE_COBRO.SelectAll()
                    TCVE_COBRO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VIAJE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnNoViaje_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                TCLAVE_O.Select()
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub TCVE_VIAJE_Validated(sender As Object, e As EventArgs) Handles TCVE_VIAJE.Validated
        Try
            If TCVE_VIAJE.Text.Trim.Length > 0 Then
                If TCVE_VIAJE.Text <> TCVE_VIAJE.Tag Then
                    TCVE_VIAJE.Tag = TCVE_VIAJE.Text

                    DESPLEGAR_ASIGNACION_VIAJE(TCVE_VIAJE.Text)
                End If
            End If
        Catch ex As Exception
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmCartaPorteAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Movimientos Carta Porte")
            Me.Dispose()
            If FORM_IS_OPEN("frmCartaPorte") Then
                FrmCartaPorte.DESPLEGAR()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub GET_DATOS_EN_CONTRATOS(fCON As String)

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CLIENTE As String

            SQL = "SELECT T.NO_CONTRATO, T.CVE_RUTA, T.CVE_ART, T.CLIENTE, T.CLAVE_O, C2.NOMBRE AS NOM_CLAVE_O, C2.RFC AS RFC_O, C2.CALLE AS CALLE_O, " &
                 "T.CLAVE_D, C3.NOMBRE AS NOM_CLAVE_D, C3.CALLE AS CALLE_D, C3.RFC AS RFC_D, RECOGER_EN, ENTREGAR_EN, VALOR_DECLA, KM_SEN, KM_FULL " &
                 "FROM GCCONTRATO T  " &
                 "LEFT JOIN CLIE" & Empresa & " C2 On LTRIM(RTRIM(C2.CLAVE)) = LTRIM(RTRIM(T.CLAVE_O)) " &
                 "LEFT JOIN CLIE" & Empresa & " C3 On LTRIM(RTRIM(C3.CLAVE)) = LTRIM(RTRIM(T.CLAVE_D)) " &
                 "WHERE T.CVE_CON = '" & fCON & "'"

            '"LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = T.CLAVE " &      C.NOMBRE AS NOM_CLAVE, 
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                CLIENTE = dr("CLAVE_O").ToString.Trim
                If IsNumeric(CLIENTE) Then
                    CLIENTE = Space(10 - CLIENTE.Length) & CLIENTE
                End If
                CLIENTE = dr("CLAVE_D").ToString.Trim
                If IsNumeric(CLIENTE) Then
                    CLIENTE = Space(10 - CLIENTE.Length) & CLIENTE
                End If
                TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
            End If
            dr.Read()

        Catch ex As Exception
            MsgBox("69. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("69 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles btnClie.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                BUSCA_CLIENTE(TCLIENTE.Text)
                TCVE_COBRO.Select()
            Else
                TCLIENTE.Text = ""
                LtNombre.Text = ""
                LtCalle.Text = ""
                LtNoINt.Text = ""
                LtNoExt.Text = ""
                LtRFC.Text = ""
                LtCP.Text = ""
                LtCol.Text = ""
                LtCiudad.Text = ""
                LtEstado.Text = ""
            End If
        Catch ex As Exception
            Bitacora("79. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("79. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub BUSCA_CLIENTE(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If fCLAVE.Trim.Length > 0 Then

                SQL = "SELECT ISNULL(NOMBRE,'') AS NOMB, ISNULL(CALLE,'') AS DIRE, ISNULL(MUNICIPIO,'') AS MUNI, ISNULL(RFC,'') AS RF, 
                    ISNULL(CODIGO,'') AS CP, ISNULL(ESTADO, '') AS EST, ISNULL(COLONIA,'') AS COLO, ISNULL(NUMINT,'') AS NOINT, ISNULL(NUMEXT,'') AS NOEXT
                    FROM CLIE" & Empresa & " C                    
                    WHERE C.CLAVE = '" & fCLAVE & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    'tCLAVE.Text = dr("CLIENTE")
                    LtNombre.Text = dr("NOMB")
                    LtCalle.Text = dr("DIRE")
                    LtNoINt.Text = dr("NOINT")
                    LtNoExt.Text = dr("NOEXT")
                    LtRFC.Text = dr("RF")
                    LtCP.Text = dr("CP")
                    LtCol.Text = dr("COLO")
                    LtCiudad.Text = dr("MUNI")
                    LtEstado.Text = dr("EST")
                Else
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    LtCalle.Text = ""
                    LtNoINt.Text = ""
                    LtNoExt.Text = ""
                    LtRFC.Text = ""
                    LtCP.Text = ""
                    LtCol.Text = ""
                    LtCiudad.Text = ""
                    LtEstado.Text = ""
                End If
                dr.Close()
            Else

                TCLIENTE.Text = ""
                LtNombre.Text = ""
                LtCalle.Text = ""
                LtNoINt.Text = ""
                LtNoExt.Text = ""
                LtRFC.Text = ""
                LtCP.Text = ""
                LtCol.Text = ""
                LtCiudad.Text = ""
                LtEstado.Text = ""
            End If
        Catch ex As Exception
            Bitacora("84. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("84. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try

            If fCVE_OPER = "" Then
                Return
            End If
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLAVE_O.Text = dr("CLAVE").ToString
                        LtNombre1.Text = dr("NOMBRE").ToString
                        LtPlaza.Text = dr("CVE_PLAZA").ToString
                        TCVE_PLAZA.Text = dr("CVE_PLAZA").ToString

                        If TCVE_PLAZA.Text.Trim.Length > 0 Then
                            LtPlaza.Text = BUSCA_CAT("Plazas", TCVE_PLAZA.Text, False)
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
                        LtPlaza.Text = ""
                        LtDom.Text = ""
                        LtDomi.Text = ""
                        LtPlanta.Text = ""
                        LtNota.Text = ""
                        LtRFC.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_CLIENTE_OPER2(fCVE_OPER As String)
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLAVE_D.Text = dr("CLAVE").ToString
                        LtNombre2.Text = dr("NOMBRE").ToString
                        TCVE_PLAZA2.Text = dr("CVE_PLAZA").ToString

                        If TCVE_PLAZA2.Text.Trim.Length > 0 Then
                            LtPlaza2.Text = BUSCA_CAT("Plazas", TCVE_PLAZA2.Text, False)
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
            Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("92. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles btnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                TCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(Var4)
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""

            End If
        Catch ex As Exception
            Bitacora("98. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("98. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCLAVE_DEST_Click(sender As Object, e As EventArgs) Handles btnCLAVE_DEST.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLAVE_D.Text = Var4
                DESPLEGAR_CLIENTE_OPER2(Var4)
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch ex As Exception
            Bitacora("99 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("99. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'OPER = OPERADOR_ASIGNADO_VIAJE(Var4) 'OBTIEN CVE_VIAJE
                'If OPER = "" Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5  'NOMBRE
                LtLicencia.Text = Var6
                LtVigencia.Text = Var7
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_TRACTOR.Focus()

                'Else
                'MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                'tCVE_OPER.Text = ""
                'LOper.Text = ""
                'Var2 = "" : Var4 = "" : Var5 = ""
                'End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles btnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                'If UNIDAD_ASIGNADA_LOCAL(1, Var4) Then
                'MsgBox("La unidad se encuentra actualmente asignada, verifique por favor")
                'Return
                'End If
                'CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                'If CVE_VIAJE <> "" Then
                'MsgBox("La unidad no esta disponible")
                'tCVE_TANQUE1.Text = ""
                'tCVE_TANQUE1.Select()
                'Return
                'End If
                TCVE_TRACTOR.Text = Var5
                TCVE_TRACTOR.Tag = Var5
                LTractor.Text = Var6

                'LtPlaca1.Text = Var8
                'LtMarca1.Text = Var9

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try

            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                If TCVE_TRACTOR.Text <> TCVE_TRACTOR.Tag And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("La unidad no puede ser modificada cuando es enlazada desde asignacion de viaje o un pedido")
                    TCVE_TRACTOR.Text = TCVE_TRACTOR.Tag
                    Return
                End If
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text

                    LTractor.Text = DESCR
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = TCVE_TRACTOR.Tag
                End If
            Else
                If TCVE_TRACTOR.Tag.ToString.Trim.Length > 0 And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("La unidad no puede puede quedar vacia")
                    TCVE_TRACTOR.Text = TCVE_TRACTOR.Tag
                Else
                    TCVE_TRACTOR.Tag = ""
                    LTractor.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles btnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                'If UNIDAD_ASIGNADA_LOCAL(2, Var4) Then
                'MsgBox("La unidad se encuentra actualmente asignada, verifique por favor")
                'Return
                'End If
                'Dim CVE_VIAJE As String
                'CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                'If CVE_VIAJE <> "" Then
                'MsgBox("La unidad no esta disponible")
                'tCVE_TANQUE1.Text = ""
                'tCVE_TANQUE1.Select()
                'Return
                'End If

                TCVE_TANQUE1.Text = Var5
                TCVE_TANQUE1.Tag = Var5
                LTanque1.Text = Var6

                'LtPlaca2.Text = Var8
                'LtMarca2.Text = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("140. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE1.Text.Length > 0 Then
                If TCVE_TANQUE1.Text <> TCVE_TANQUE1.Tag And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("L|a unidad no puede ser modificada cuando es enlazada desde asignacion de viaje o un pedido")
                    TCVE_TANQUE1.Text = TCVE_TANQUE1.Tag
                    Return
                End If

                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_TANQUE1.Tag = TCVE_TANQUE1.Text

                    LTanque1.Text = DESCR
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE1.Text = TCVE_TANQUE1.Tag
                End If
            Else
                If TCVE_TANQUE1.Tag.ToString.Trim.Length > 0 And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("La unidad no puede puede quedar vacia")
                    TCVE_TANQUE1.Text = TCVE_TANQUE1.Tag
                Else
                    TCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("155. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("155. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque2_Click(sender As Object, e As EventArgs) Handles btnTanque2.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                'If UNIDAD_ASIGNADA_LOCAL(3, Var4) Then
                'MsgBox("La unidad se encuentra actualmente asignada, verifique por favor")
                'Return
                'End If

                'Dim CVE_VIAJE As String
                'c 'VE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                'If CVE_VIAJE <> "" Then
                'tCVE_TANQUE2.Text = ""
                'tCVE_TANQUE2.Select()
                'Return
                'End If
                TCVE_TANQUE2.Text = Var5
                TCVE_TANQUE2.Tag = Var5
                LTanque2.Text = Var6
                'LtPlaca3.Text = Var8
                'LtMarca3.Text = Var9
                Var2 = "" : Var3 = "" : Var4 = ""
                Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE2.Text.Length > 0 Then
                If TCVE_TANQUE2.Text <> TCVE_TANQUE2.Tag And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("La unidad no puede ser modificada cuando es enlazada desde asignacion de viaje o un pedido")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                    Return
                End If
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    Var3 = ""

                    TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text

                    LTanque2.Text = DESCR
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                End If
            Else
                If TCVE_TANQUE2.Tag.ToString.Trim.Length > 0 And (TCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_DOC.Text.Trim.Length > 0) Then
                    MsgBox("La unidad no puede puede quedar vacia")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                Else
                    TCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnDolly_Click(sender As Object, e As EventArgs) Handles btnDolly.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "3" : Var5 = ""

            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then

                'If UNIDAD_ASIGNADA_LOCAL(4, Var4) Then
                'MsgBox("La unidad se encuentra actualmente asignada, verifique por favor")
                'Return
                'End If

                'Dim CVE_VIAJE As String
                'CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                'If CVE_VIAJE <> "" Then
                'tCVE_DOLLY.Text = ""
                'tCVE_DOLLY.Tag = ""
                'tCVE_DOLLY.Select()
                'Return
                'End If
                TCVE_DOLLY.Text = Var5
                TCVE_DOLLY.Tag = Var5
                LDolly.Text = Var6
                'LtPlaca4.Text = Var8
                'LtMarca4.Text = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_DOLLY.Focus()
            Else
                TCVE_DOLLY.Text = ""
                TCVE_DOLLY.Tag = ""
                LDolly.Text = ""
            End If

        Catch Ex As Exception
            Bitacora("170. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("170. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_DOLLY_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOLLY.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnDolly_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_DOLLY_Validated(sender As Object, e As EventArgs) Handles TCVE_DOLLY.Validated
        Try
            If TCVE_DOLLY.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)
                If DESCR <> "" Then
                    'If UNIDAD_ASIGNADA(Var4) Then
                    'MsgBox("La unidad se encuentra actualmente asignada " & Var3)
                    'tCVE_DOLLY.Text = ""
                    'tCVE_DOLLY.Select()
                    'Return
                    'End If
                    Var3 = ""
                    LDolly.Text = DESCR
                    LDolly.Tag = DESCR
                Else
                    MsgBox("Unidad inexistente..")
                    TCVE_DOLLY.Text = ""
                    TCVE_DOLLY.Tag = ""
                    LDolly.Text = ""
                End If
            Else
                TCVE_DOLLY.Tag = ""
                LtDolly.Text = ""
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RadCargado_CheckedChanged(sender As Object, e As EventArgs) Handles RadCargado.CheckedChanged
        TENTREGAR_EN.BackColor = Color.Yellow
    End Sub
    Private Function UNIDAD_ASIGNADA_LOCAL(fUNI As Integer, fCVE_UNI As String) As Boolean
        Dim Exist As Boolean = False
        Try
            Select Case fUNI
                Case 1 'TRACTOR
                    Try
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_DOLLY.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 2 'TANQUE 1
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_DOLLY.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("181. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 3 'TANQUE2
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_DOLLY.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("182. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("182. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 4 'DOLLY
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
            Return Exist
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Sub DESPLEGAR_ASIGNACION_VIAJE(fCVE_VIAJE As String)
        If fCVE_VIAJE.Trim.Length = 0 Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, ISNULL(A.CVE_ST_UNI,0) AS STATUS_INI, A.TIPO_UNI, 
                A.TIPO_VIAJE, A.CVE_OPER, A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA,
                ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(C.RECOGER_EN,'') AS RECOGER2, 
                ISNULL(C.ENTREGAR_EN,'') AS ENTREGAR2, ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, ISNULL(A.CVE_TAB,0) AS CVETAB,
                A.RUTA_SEN_VAC, A.RUTA_SE_CAR, A.RUTA_FULL_VAC, A.RUTAL_FULL_CAR, ISNULL(A.NOTA,'') AS NTA, ISNULL(P.FECHA_CARGA,'') AS F_CARGA, 
                ISNULL(P.FECHA_DESCARGA,'') AS F_DESCARGA, ISNULL(C.CVE_ART,'') AS CVEART, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR, A.CVE_CON, 
                P.VALOR_DECLA AS DECLA
                FROM GCASIGNACION_VIAJE A
                LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = A.CVE_VIAJE
                LEFT JOIN GCCONTRATO C ON C.CVE_CON = A.CVE_CON
                WHERE A.CVE_VIAJE = '" & fCVE_VIAJE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                LtCVE_DOC.Text = dr("CVE_DOC")
                If dr("RECOGER").ToString.Trim.Length > 0 Then
                    TRECOGER_EN.Text = dr("RECOGER")
                    TRECOGER_EN.Tag = dr("RECOGER")
                Else
                    TRECOGER_EN.Text = dr("RECOGER2")
                    TRECOGER_EN.Tag = dr("RECOGER2")
                End If
                If dr("ENTREGAR").ToString.Trim.Length > 0 Then
                    TENTREGAR_EN.Text = dr("ENTREGAR")
                    TENTREGAR_EN.Tag = dr("ENTREGAR")
                Else
                    TENTREGAR_EN.Text = dr("ENTREGAR2")
                    TENTREGAR_EN.Tag = dr("ENTREGAR2")
                End If
                Try
                    TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                    tEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                    tCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                Catch ex As Exception
                End Try

                LtRecogerEn.Text = BUSCA_CAT("Plazas", TRECOGER_EN.Text)
                LtEntregarEn.Text = BUSCA_CAT("Plazas", TENTREGAR_EN.Text)

                'SE AGREGOHOY 10  MARZO
                TCVE_ART.Text = dr("CVEART")
                LtDescr.Text = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text)

                TCLAVE_O.Text = dr("ORIGEN")
                TCLAVE_D.Text = dr("DESTINO")

                If dr("TIPO_VIAJE").ToString = "1" Then
                    RadCargado.Checked = True
                    RadVacio.Checked = False

                    TCLAVE_O.Enabled = False
                    TCLAVE_D.Enabled = False
                    TRECOGER_EN.Enabled = False
                    TENTREGAR_EN.Enabled = False
                Else
                    RadCargado.Checked = False
                    RadVacio.Checked = True

                    TCLAVE_O.Enabled = True
                    TCLAVE_D.Enabled = True
                    btnCLAVE_REM.Enabled = True
                    btnCLAVE_DEST.Enabled = True
                    TRECOGER_EN.Enabled = True
                    TENTREGAR_EN.Enabled = True
                End If

                If TCVE_OPER.Text.Trim.Length = 0 Or TCVE_OPER.Text = "0" Then
                    TCVE_OPER.Text = dr("CVE_OPER").ToString
                    LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                End If
                If TCVE_OPER.Text = "0" Then
                    TCVE_OPER.Text = ""
                End If

                If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                    TCVE_TRACTOR.Text = dr("CVE_TRACTOR").ToString
                    TCVE_TRACTOR.Tag = dr("CVE_TRACTOR").ToString
                    LTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                End If
                If TCVE_TANQUE1.Text.Trim.Length = 0 Then
                    TCVE_TANQUE1.Text = dr("CVE_TANQUE1").ToString
                    TCVE_TANQUE1.Tag = dr("CVE_TANQUE1").ToString
                    LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)
                End If
                If TCVE_TANQUE2.Text.Trim.Length = 0 Then
                    TCVE_TANQUE2.Text = dr("CVE_TANQUE2").ToString
                    TCVE_TANQUE2.Tag = dr("CVE_TANQUE2").ToString
                    LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                End If
                If TCVE_DOLLY.Text.Trim.Length = 0 Then
                    TCVE_DOLLY.Text = dr("CVE_DOLLY").ToString
                    TCVE_DOLLY.Tag = dr("CVE_DOLLY").ToString
                    LDolly.Text = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)
                End If

                If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                    If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                End If
                Try
                    F2.Value = dr("F_CARGA").ToString
                    F3.Value = dr("F_DESCARGA").ToString
                Catch ex As Exception
                    Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                'CARGAR EL PRECIO DEL VIAJE DESDE EL CONTRATO
                Try
                    TVALOR_DECLA.Text = dr.ReadNullAsEmptyDecimal("DECLA").ToString
                    If TVALOR_DECLA.Text = "0" Or TVALOR_DECLA.Text.Trim.Length = 0 Then
                        TVALOR_DECLA.Text = ""
                        LtDescrTipoPago.Text = ""
                        LtImporteValorDeclarado.Text = ""

                    Else
                        Try
                            BUSCA_VALOR_DECLARADO(TVALOR_DECLA.Text)
                            LtDescrTipoPago.Text = Var5
                            If IsNumeric(Var6) Then
                                LtImporteValorDeclarado.Text = Format(dr.ReadNullAsEmptyDecimal("DECLA"), "###,###,##0.00")
                            End If
                        Catch ex As Exception
                            Bitacora("4.1 " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("4.1 " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'FIN CARGADO DE DATOS DEL PRECIO DEL VIAJE DESDE EL CONTRATO

                DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)
            Else
                TRECOGER_EN.Text = ""
                TRECOGER_EN.Tag = ""
                TENTREGAR_EN.Text = ""
                TENTREGAR_EN.Tag = ""
                TCLAVE_O.Text = ""
                TCLAVE_D.Text = ""
                LtTipoViaje.Text = ""
                RadCargado.Checked = True
                RadVacio.Checked = False
                TCVE_OPER.Text = ""
                LOper.Text = ""
                TCVE_TRACTOR.Text = ""
                TCVE_TANQUE1.Text = ""
                TCVE_TANQUE2.Text = ""
                TCVE_DOLLY.Text = ""

                TCVE_TRACTOR.Tag = ""
                TCVE_TANQUE1.Tag = ""
                TCVE_TANQUE2.Tag = ""
                TCVE_DOLLY.Tag = ""

                LTractor.Text = ""
                LTanque1.Text = ""
                LTanque2.Text = ""
                LDolly.Text = ""
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPESO_BRUTO1_TextChanged(sender As Object, e As EventArgs) Handles TPESO_BRUTO1.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA1.Text) AndAlso Not String.IsNullOrEmpty(TTARA2.Text) AndAlso
                Not String.IsNullOrEmpty(TPESO_BRUTO1.Text) AndAlso Not String.IsNullOrEmpty(TPESO_BRUTO2.Text) And
                Not IsDBNull(TPESO_BRUTO3.Value) Then

                LtPesoNeto1.Text = Format(TPESO_BRUTO1.Text - TTARA1.Value, "###,###,##0.000")
                LtPesoNeto5.Text = Format((TPESO_BRUTO1.Text - TTARA1.Value) + (TPESO_BRUTO3.Value - TTARA3.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            End If
        Catch ex As Exception
            Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTARA1_TextChanged(sender As Object, e As EventArgs) Handles TTARA1.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA1.Text) AndAlso Not String.IsNullOrEmpty(TTARA3.Text) AndAlso
                TPESO_BRUTO1.Text IsNot Nothing AndAlso TPESO_BRUTO2.Text IsNot Nothing And Not IsDBNull(TPESO_BRUTO3.Value) Then

                LtPesoNeto1.Text = Format(TPESO_BRUTO1.Value - TTARA1.Text, "###,###,##0.000")
                LtPesoNeto5.Text = Format((TPESO_BRUTO1.Text - TTARA1.Text) + (TPESO_BRUTO3.Value - TTARA3.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TPESO_BRUTO1.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If


        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPESO_BRUTO3_TextChanged(sender As Object, e As EventArgs) Handles TPESO_BRUTO3.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA1.Text) AndAlso Not String.IsNullOrEmpty(TTARA2.Text) AndAlso Not String.IsNullOrEmpty(TTARA3.Text) AndAlso
                TPESO_BRUTO1.Text IsNot Nothing AndAlso TPESO_BRUTO2.Text IsNot Nothing AndAlso TPESO_BRUTO3.Text IsNot Nothing Then

                If Not IsNumeric(TPESO_BRUTO3.Text) Then
                    TPESO_BRUTO3.Text = "0"
                End If
                LtPesoNeto3.Text = Format(TPESO_BRUTO3.Text - TTARA3.Value, "###,###,##0.000")
                LtPesoNeto5.Text = Format((TPESO_BRUTO1.Value - TTARA1.Value) + (TPESO_BRUTO3.Text - TTARA3.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TTARA3.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If

        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TTARA3_TextChanged(sender As Object, e As EventArgs) Handles TTARA3.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA1.Text) AndAlso Not String.IsNullOrEmpty(TTARA2.Text) AndAlso Not String.IsNullOrEmpty(TTARA3.Text) AndAlso
                TPESO_BRUTO1.Text IsNot Nothing AndAlso TPESO_BRUTO2.Text IsNot Nothing AndAlso TPESO_BRUTO3.Text IsNot Nothing And
                TPESO_BRUTO1.Value IsNot Nothing And Not IsDBNull(TPESO_BRUTO3.Value) And TTARA1.Value IsNot Nothing Then

                LtPesoNeto3.Text = Format(TPESO_BRUTO3.Value - TTARA3.Text, "###,###,##0.000")
                LtPesoNeto5.Text = Format((TPESO_BRUTO1.Value - TTARA1.Value) + (TPESO_BRUTO3.Value - TTARA3.Text), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TPESO_BRUTO3.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If

        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPESO_BRUTO2_TextChanged(sender As Object, e As EventArgs) Handles TPESO_BRUTO2.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA2.Text) AndAlso Not String.IsNullOrEmpty(TTARA3.Text) AndAlso Not String.IsNullOrEmpty(TTARA4.Text) AndAlso
                Not String.IsNullOrEmpty(TPESO_BRUTO2.Text) AndAlso Not String.IsNullOrEmpty(TPESO_BRUTO3.Text) AndAlso Not String.IsNullOrEmpty(TPESO_BRUTO4.Text) Then
                LtPesoNeto2.Text = Format(TPESO_BRUTO2.Text - TTARA2.Value, "###,###,##0.000")
                LtPesoNeto6.Text = Format((TPESO_BRUTO2.Text - TTARA2.Value) + (TPESO_BRUTO4.Value - TTARA4.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TTARA1.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If

        Catch ex As Exception
            Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTARA2_TextChanged(sender As Object, e As EventArgs) Handles TTARA2.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA2.Text) AndAlso Not String.IsNullOrEmpty(TTARA3.Text) AndAlso Not String.IsNullOrEmpty(TTARA4.Text) AndAlso
                TPESO_BRUTO2.Text IsNot Nothing AndAlso TPESO_BRUTO3.Text IsNot Nothing AndAlso TPESO_BRUTO4.Text IsNot Nothing Then

                LtPesoNeto2.Text = Format(TPESO_BRUTO2.Value - TTARA2.Text, "###,###,##0.000")
                LtPesoNeto6.Text = Format((TPESO_BRUTO2.Value - TTARA2.Text) + (TPESO_BRUTO4.Value - TTARA4.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TPESO_BRUTO2.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If
        Catch ex As Exception
            Bitacora("414. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("414. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPESO_BRUTO4_TextChanged(sender As Object, e As EventArgs) Handles TPESO_BRUTO4.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA3.Text) AndAlso Not String.IsNullOrEmpty(TTARA4.Text) AndAlso
                TPESO_BRUTO3.Text IsNot Nothing AndAlso TPESO_BRUTO4.Text IsNot Nothing Then

                If Not IsNumeric(TPESO_BRUTO4.Text) Then
                    TPESO_BRUTO4.Text = "0"
                End If

                LtPesoNeto4.Text = Format(TPESO_BRUTO4.Text - TTARA4.Value, "###,###,##0.000")
                LtPesoNeto6.Text = Format((TPESO_BRUTO2.Value - TTARA2.Value) + (TPESO_BRUTO4.Text - TTARA4.Value), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TTARA4.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If

        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TTARA4_TextChanged(sender As Object, e As EventArgs) Handles TTARA4.TextChanged
        Try
            If Not String.IsNullOrEmpty(TTARA3.Text) AndAlso Not String.IsNullOrEmpty(TTARA4.Text) AndAlso
                TPESO_BRUTO3.Text IsNot Nothing AndAlso Not IsDBNull(TPESO_BRUTO4.Value) And TPESO_BRUTO2.Value IsNot Nothing And
                TPESO_BRUTO4.Value IsNot Nothing And TTARA2.Value IsNot Nothing Then

                If Not IsNumeric(TTARA4.Text) Then
                    TTARA4.Text = "0"
                End If

                LtPesoNeto4.Text = Format(TPESO_BRUTO4.Value - TTARA4.Text, "###,###,##0.000")
                LtPesoNeto6.Text = Format((TPESO_BRUTO2.Value - TTARA2.Value) + (TPESO_BRUTO4.Value - TTARA4.Text), "###,###,##0.000")

                CALCULA_PRECIO_CARTA_PORTE()
            Else
                If TPESO_BRUTO4.Text IsNot Nothing Then
                    CALCULA_PRECIO_CARTA_PORTE()
                End If
            End If
        Catch ex As Exception
            Bitacora("412. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFLETE_TextChanged(sender As Object, e As EventArgs) Handles TFLETE.TextChanged
        Dim PREC As Decimal, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Try
            If Not String.IsNullOrEmpty(TFLETE.Text) Then
                If TCVE_ART.Text.Trim.Length > 0 Then
                    Dim CANT As Decimal, PRECIO As Decimal, PESO As Decimal

                    If RadPrecioXViaje.Checked Then
                        If IsNumeric(TCANT.Text) Then
                            CANT = TCANT.Text
                            If CANT = 0 Then
                                CANT = 1
                            End If
                        Else
                            CANT = 1
                        End If
                        'tFLETE.Tag = tFLETE.Text
                    Else
                        TFLETE.Tag = TFLETE.Text
                        If RadPrecioXViaje.Checked Then
                            'tFLETE.Value = tFLETE.Tag
                        ElseIf RadRemCarga1.Checked Then
                            If IsNumeric(TPESO_BRUTO1.Text.Replace(",", "")) And IsNumeric(TTARA1.Text.Replace(",", "")) Then
                                PESO = CDec(TPESO_BRUTO1.Text.Replace(",", "")) - CDec(TTARA1.Text.Replace(",", ""))
                            End If
                        ElseIf RadRemCarga2.Checked Then
                            If IsNumeric(TPESO_BRUTO2.Text.Replace(",", "")) And IsNumeric(TTARA2.Text.Replace(",", "")) Then
                                PESO = TPESO_BRUTO2.Text - TTARA2.Text
                            End If
                        ElseIf RadRemCarga3.Checked Then
                            If IsNumeric(TPESO_BRUTO3.Text.Replace(",", "")) And IsNumeric(TTARA3.Text.Replace(",", "")) Then
                                PESO = TPESO_BRUTO3.Text - TTARA3.Text
                            End If
                        ElseIf RadRemCarga4.Checked Then
                            PESO = TPESO_BRUTO4.Text - TTARA4.Text
                        End If
                        CANT = PESO
                    End If

                    If IsNumeric(TFLETE.Text) Then
                        PRECIO = TFLETE.Text
                    Else
                        PRECIO = 0
                    End If

                    If TCVE_ESQIMPU.Text.Trim.Length > 0 Then

                        CALCUAL_NUEVO_ESQUEMA(PRECIO)

                    Else '1
                        LtSubTotal.Text = Format(PRECIO * CANT, "###,###,###.00")
                        LtIVA.Text = Format((PRECIO * CANT) * 0.16, "###,###,###.00")
                        LtRet.Text = Format(((PRECIO * CANT) * 0.04), "###,###,###.00")
                        LtNeto.Text = Format((PRECIO * CANT) + ((PRECIO * CANT) * 0.16) - ((PRECIO * CANT) * 0.04), "###,###,##0.00")
                    End If
                Else
                    PREC = CDec(TFLETE.Value)

                    PREC = Math.Round(CDec(PREC), 8) * CDec(TCANT.Value)

                    cIeps = PREC * vIMPU1 / 100
                    If vIMP4APLA = 1 Then
                        cImpu2 = (PREC + cIeps) * vIMPU2 / 100
                        cImpu3 = (PREC + cIeps + cImpu2) * vIMPU3 / 100
                        cImpu = (PREC + cIeps + cImpu2 + cImpu3) * vIMPU4 / 100
                    Else
                        cImpu2 = PREC * vIMPU2 / 100
                        cImpu3 = PREC * vIMPU3 / 100
                        cImpu = PREC * vIMPU4 / 100
                    End If
                    '1
                    LtSubTotal.Text = Format(PREC, "###,###,###.00")
                    LtIVA.Text = Format(cIeps + cImpu, "###,###,###.00")
                    LtRet.Text = Format(cImpu2 + cImpu3, "###,###,###.00")
                    LtNeto.Text = Format(PREC + cIeps + cImpu2 + cImpu3 + cImpu, "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub CALCUAL_NUEVO_ESQUEMA(FFLETE As Decimal)
        Dim PREC As Decimal, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Dim Sigue As Boolean

        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4
                        FROM IMPU" & Empresa & " 
                        WHERE CVE_ESQIMPU = " & TCVE_ESQIMPU.Text
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            vIMPU1 = dr("IMPUESTO1")
                            vIMPU2 = dr("IMPUESTO2")
                            vIMPU3 = dr("IMPUESTO3")
                            vIMPU4 = dr("IMPUESTO4")
                            Sigue = True
                        End If
                    End Using
                End Using
            Else
                DESPLEGAR_ARTICULO_SAE(TVALOR_DECLA.Text)
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            PREC = FFLETE * TCANT.Value
            PREC = Math.Round(CDec(PREC), 8)

            cIeps = PREC * vIMPU1 / 100
            cImpu2 = PREC * vIMPU2 / 100
            cImpu3 = PREC * vIMPU3 / 100
            cImpu = PREC * vIMPU4 / 100
            '1 CON ESQUEMA
            LtSubTotal.Text = Format(PREC, "###,###,###.00")
            LtIVA.Text = Format(cIeps + cImpu, "###,###,###.00")
            LtRet.Text = Format(cImpu2 + cImpu3, "###,###,###.00")
            LtNeto.Text = Format(PREC + cIeps + cImpu2 + cImpu3 + cImpu, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProd_Click(sender As Object, e As EventArgs) Handles BtnProd.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtDescr.Text = Var5
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TFLETE.Focus()
            End If
        Catch Ex As Exception
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProd_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text, False)
                If DESCR <> "" Then
                    LtDescr.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BarCerrarCartaPorte_Click(sender As Object, e As EventArgs) Handles BarCerrarCartaPorte.Click
        Try
            Dim Sigue As Boolean = False
            Dim PRECIO As Decimal = 0

            If LtStatus.Text = "TRANSFERIDO" Then
                PLAY_WAV(2)
                MsgBox("La carta porte ya fue tranderida, no es posible cerrarla, verifique por favor")
                Return
            End If
            If LtStatus.Text <> "ACEPTADO" Then

                If TCLIENTE.Text.Trim.Length > 0 Then

                    If VALOR_DECLA_DESDE_SAE = 0 Then
                    Else
                        If TVALOR_DECLA.Text.Trim.Length = 0 Then
                            MsgBox("Por favor capture el tipo de pago")
                            TVALOR_DECLA.Focus()
                            Return
                        End If
                    End If

                    Try
                        PRECIO = TFLETE.Text
                    Catch ex As Exception
                        PRECIO = 0
                    End Try

                    If PRECIO = 0 Then
                        If MsgBox("El flete tiene valor a cero, Realmente desea continuar?", vbYesNo) = vbYes Then
                            Sigue = True
                        End If
                    Else
                        Sigue = True
                    End If

                    If Sigue Then
                        If MsgBox("Realmente desea cerrar la carta porte?", vbYesNo) = vbYes Then
                            LtStatus.Text = BUSCA_CAT("GCSTATUS_CARTA_PORTE", "2")

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 2 WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                        DESHABILITAR_CARTA_PORTE()

                                        MsgBox("La carta porte se cerro satisfactoriamente")

                                        BarGrabar_Click(Nothing, Nothing)

                                        Try
                                            If FORM_IS_OPEN("frmCartaPorte") Then
                                                FrmCartaPorte.Fg(FrmCartaPorte.Fg.Row, 2) = "ACEPTADO"
                                            End If
                                        Catch ex As Exception
                                            Bitacora("512. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            End Using
                        End If
                    Else
                        Tab1.SelectedIndex = 1
                        TFLETE.Select()
                    End If
                Else
                    MsgBox("Por favor capture la clave del cliente fiscal")
                    Tab1.SelectedIndex = 0

                    TCLIENTE.Select()
                End If
            Else
                PLAY_WAV(2)
                MsgBox("La carta porte ya fue cerrada verifique por favor")
                Return
            End If
        Catch ex As Exception
            Bitacora("512. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("512. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function EXISTE_CARTA_PORTE(fCVE_CP As String) As Boolean
        Dim Exist_Cp As Boolean
        Exist_Cp = False
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_VIAJE FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & fCVE_CP & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        MsgBox("El folio carta porte existe verifique por favor")
                        Exist_Cp = True
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return Exist_Cp
    End Function

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Var10 = LtCartaPorte.Text
        Var15 = "CARTA PORTE"
        Try
            ImprimirOrden(Var10)

        Catch ex As Exception
            Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirOrden(fCVE_ORD As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportCartaPorte.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportCartaPorte.mrt, verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\ReportCartaPorte.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_FOLIO_P") = fCVE_ORD
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLAVE_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_D.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_DEST_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlaza1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub BtnPlaza1_Click(sender As Object, e As EventArgs) Handles btnPlaza1.Click
        Try
            Var2 = "Plaza"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPlaza2_Click(sender As Object, e As EventArgs) Handles btnPlaza2.Click
        Try
            Var2 = "Plaza"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub BtnRecogerEn_Click(sender As Object, e As EventArgs) Handles btnRecogerEn.Click
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
    Private Sub BtnEntregarEn_Click(sender As Object, e As EventArgs) Handles btnEntregarEn.Click
        Try
            Var2 = "EntregarEn"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TENTREGAR_EN.Text = Var4
                LtEntregarEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_PLAZA2.Focus()
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
    End Sub
    Private Sub TRECOGER_EN_Validating(sender As Object, e As CancelEventArgs) Handles TRECOGER_EN.Validating
        Try
            If TRECOGER_EN.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
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
            TCVE_OPER.Select()
        End If
    End Sub
    Private Sub TENTREGAR_EN_Validating(sender As Object, e As CancelEventArgs) Handles TENTREGAR_EN.Validating
        Try
            If TENTREGAR_EN.Text.Trim.Length > 0 Then
                Dim DESCR As String

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
            Else
                LtEntregarEn.Text = ""
                TCVE_ART.Select()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub StiReport1_Printing(sender As Object, e As EventArgs) Handles StiReport1.Printing
        Try
            If StiReport1.PrinterSettings.PrintDialogResult = DialogResult.OK Then
                StiReport1.Clone()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TCVE_COBRO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_COBRO.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Gpo2.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TRECOGER_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRECOGER_EN.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Gpo3.Select()
                'tCLAVE_D.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TENTREGAR_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TENTREGAR_EN.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Gpo4.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarRemisionar_Click(sender As Object, e As EventArgs)
        If Not Valida_Conexion() Then
            MsgBox("Imposible conectarse a la base de datos")
            Return
        End If
        If Not Valida_Conexion_SAROCE() Then
            MsgBox("Imposible conectarse a la base de configuración")
            Return
        End If

        Dim ImporteConDes As Single, SUBTOTAL As Single
        Dim TIP_DOC As String, CVE_DOC As String, CVE_CLPV As String = "", STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String = ""
        Dim FECHA_DOC As String, FECHA_VEN As String, CAN_TOT As Single, IMP_TOT1 As Single, IMP_TOT2 As Single, IMP_TOT3 As Single
        Dim IMP_TOT4 As Single, DES_TOT As Single, DES_FIN As Single, COM_TOT As Single, UNI_VENTA As String
        Dim CONDICION As String, CVE_OBS As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Long, TIPCAMB As Single, NUM_PAGOS As Long, PRIMERPAGO As Single, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, FOLIO As Long, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String
        Dim CVE_BITA As Long, Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Single, DES_TOT_PORC As Single, COM_TOT_PORC As Single
        Dim METODODEPAGO As String, NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Long, IMPORTE As Single
        Dim CVE_ART As String, CANT As Single, PRECIO As Single, PXS As Single, PREC As Single, COST As Single, IMPU1 As Single, IMPU2 As Single
        Dim IMPU3 As Single, IMPU4 As Single, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer, TOTIMP1 As Single
        Dim TOTIMP2 As Single, TOTIMP3 As Single, TOTIMP4 As Single, DESC1 As Single, Desc2 As Single, Desc3 As Single, COMI As Single, APAR As Single
        Dim ACT_INV As String, NUM_ALM As Integer, POLIT_APLI As String, TIP_CAM As Single = 1, TIPO_PROD As String, REG_SERIE As Long, E_LTPD As Long
        Dim TIPO_ELEM As String, TOT_PARTIDA As Single, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer, APL_MAN_IEPS As String
        Dim MTO_PORC As Integer, MTO_CUOTA As Integer, ULT_COSTO As Single, COSTO_PROM As Single, CVE_ESQIMPU As Integer = 1, DESCR As String, UNI_MED As String
        'MOVSINV
        Dim CVE_CPTO As Integer, FACTOR_CON As Single, SIGNO As Integer, COSTEADO As String
        Dim COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String, MOV_ENLAZADO As Integer, USO_CFDI As String
        Dim FOLIO_ASIGNADO As Boolean, SIGUE As Boolean, Existe As Boolean, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Dim CADENA_NUM_MOV As String

        Dim cmdOT As New SqlCommand
        Dim drOT As SqlDataReader

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Select Case TIPO_VENTA
            Case "P"
                If MsgBox("Realmente desea grabar el Pedido?", vbYesNo) = vbNo Then
                    Exit Sub
                End If
            Case "C"
                If MsgBox("Realmente desea grabar la Cotización?", vbYesNo) = vbNo Then
                    Exit Sub
                End If
            Case "R"
                If MsgBox("Realmente desea grabar la Remisión?", vbYesNo) = vbNo Then
                    Exit Sub
                End If
        End Select

        UNI_MED = ""
        MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0

        IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0 : CONDICION = "Contado"
        CVE_OBS = 0 : ACT_CXC = "S" : ACT_COI = "N" : ENLAZADO = "O" : TIP_DOC_E = "O" : NUM_MONED = 1 : TIPCAMB = 1 : NUM_PAGOS = 1
        RFC = "" : CTLPOL = 0 : ESCFD = "N" : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
        FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
        DAT_ENVIO = 0 : USO_CFDI = "" : COM_TOT_PORC = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC_ANT = "" : DOC_ANT = ""
        STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N"

        Try
            Dim dt As DateTime = Now
            FECHA_DOC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")
        Catch ex As Exception
            FECHA_DOC = Date.Now.Year & Format(Date.Now.Month, "00") & Format(Date.Now.Day, "00")
        End Try
        FECHA_VEN = FECHA_DOC

        'CVE_CLPV = 
        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            'SQL = "SELECT RFC FROM CLIE" & Empresa & " WHERE CLAVE  = '" & tCVE_PROV.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RFC = dr("RFC")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("1700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        TIP_DOC = TIPO_VENTA
        CVE_DOC = ""

        Dim LETRA_VENTA As String, FOLIO_VENTA As Long
        Try
            SIGUE = True
            FOLIO_ASIGNADO = False
            LETRA_VENTA = SERIE_VENTA

            FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA, LETRA_VENTA)

            Do While SIGUE
                If LETRA_VENTA.Trim.Length = 0 Or LETRA_VENTA = "STAND." Then
                    CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                Else
                    CVE_DOC = LETRA_VENTA & FOLIO_VENTA
                End If

                If EXISTE_VENTA(TIPO_VENTA, CVE_DOC) Then
                    FOLIO_VENTA += 1
                    FOLIO_ASIGNADO = True
                Else
                    SIGUE = False
                End If
            Loop
        Catch ex As Exception
            Bitacora("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        If MULTIALMACEN = 1 Then
            Try
                NUM_ALM = 1
            Catch ex As Exception
                NUM_ALM = 1
            End Try
        Else
            NUM_ALM = 1
        End If

        Me.Cursor = Cursors.WaitCursor

        SERIE = SERIE_VENTA
        FOLIO = FOLIO_VENTA
        IMPORTE = 0 : CAN_TOT = 0

        If Not Valida_Conexion() Then
            Return
        End If

        cmdOT.Connection = cnSAE
        cmdOT.CommandTimeout = 180

        cmdOT.CommandText = "SELECT * FROM GCOT"
        drOT = cmdOT.ExecuteReader

        While drOT.Read

            CVE_ART = drOT("CVE_ART")
            CANT = drOT("CANT")
            PRECIO = drOT("PRECIO")
            If CVE_ART <> "TOT" Then
                Try
                    NUM_ALM = 1
                Catch ex As Exception
                    NUM_ALM = 1
                End Try
                Try
                    Try
                        SQL = "SELECT ISNULL(TIPO_ELE,'') AS TIPOELE, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM,
                            ISNULL(CVE_ESQIMPU,1) AS CVEESQIMPU, ISNULL(UNI_MED,'') AS UNIMED, ISNULL(DESCR,'') AS DES, ISNULL(PRECIO,0) AS P1
                            FROM INVE" & Empresa & " I
                            LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1
                            WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULTCOSTO")
                                COSTO_PROM = dr("COSTOPROM")
                                CVE_ESQIMPU = dr("CVEESQIMPU")
                                DESCR = dr("DES")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNIMED")
                                TIPO_PROD = dr("TIPOELE")

                                If TIPO_PROD = "P" Then
                                    PRECIO = COSTO_PROM
                                End If
                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Me.Cursor = Cursors.Default
                        Return
                    End Try
                    If Existe Then
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                IMPU1 = CSng(dr("IMPUESTO1"))
                                IMPU2 = CSng(dr("IMPUESTO2"))
                                IMPU3 = CSng(dr("IMPUESTO3"))
                                IMPU4 = CSng(dr("IMPUESTO4"))
                                IMP1APLA = CInt(dr("IMP1APLICA"))
                                IMP2APLA = CInt(dr("IMP2APLICA"))
                                IMP3APLA = CInt(dr("IMP3APLICA"))
                                IMP4APLA = CInt(dr("IMP4APLICA"))
                            End If
                            dr.Close()
                        Catch ex As Exception
                            Bitacora("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                            Me.Cursor = Cursors.Default
                            Return
                        End Try
                        If CVE_ESQIMPU = 1 Then
                            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                        Else
                            MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                        End If

                        Try
                            DESC1 = 0
                        Catch ex As Exception
                            DESC1 = 0
                        End Try

                        Try
                            PRECIO = Math.Round(CDec(PRECIO), 6)
                            PREC = PRECIO

                            Desc2 = 0 : Desc3 = 0
                            SUBTOTAL += (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT += CANT * PREC * DESC1 / 100
                            DES_TOT += DES_TOT * Desc2 / 100
                            cIeps = ImporteConDes * IMPU1 / 100
                            cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                            cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                            cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 += TOTIMP1
                            IMP_TOT2 += TOTIMP2
                            IMP_TOT3 += TOTIMP3
                            IMP_TOT4 += TOTIMP4
                            TOT_PARTIDA = CANT * PREC
                            CAN_TOT += TOT_PARTIDA

                            IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                            If CVE_ESQIMPU = 1 Then
                                MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                            Else
                                MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                            End If
                        Catch ex As Exception
                            Bitacora("1780. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1780. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("La clave del articulo no existe")
                    End If

                Catch ex As Exception
                    MsgBox("1800. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("1800. " & ex.Message & vbNewLine & ex.StackTrace)
                    Me.Cursor = Cursors.Default
                    Return
                End Try
            End If

        End While
        drOT.Close()

        If Not Valida_Conexion() Then
            Return
        End If

        PRIMERPAGO = IMPORTE
        METODODEPAGO = ""
        CVE_VEND = ""

        cmd.Connection = cnSAE
        cmd.CommandTimeout = 180

        Try
            SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM FACT" & TIPO_VENTA & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "') " &
                    "INSERT INTO FACT" & TIPO_VENTA & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, " &
                    "IMP_TOT1, IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, " &
                    "RFC, AUTORIZA, FOLIO, SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, " &
                    "DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, " &
                    "CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, " &
                    "METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, UUID) VALUES('"

            SQL = SQL & CVE_CLPV & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_DOC & "','" & FECHA_VEN & "','" &
                    Math.Round(IMP_TOT1, 6) & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                    TIPCAMB & "','" & IMP_TOT3 & "','" & Math.Round(IMP_TOT4, 6) & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                    FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALM & "','" & ACT_CXC & "','" &
                    TIP_DOC & "','" & CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" &
                    NUM_PAGOS & "','" & DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" &
                    CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" &
                    DES_FIN_PORC & "','" & DES_TOT_PORC & "','" & Math.Round(IMPORTE, 6) & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" &
                    NUMCTAPAGO & "','" & TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "',NEWID()) "

            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If
        Catch ex As Exception
            Bitacora("1870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1870. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            'Placa: Xxxxx Unidad: XXXXX
            'BUSCA_UNIDAD_CLAVEMONTE(tCVE_UNI.Text)

            'SQL = "UPDATE FACTR_CLIB" & Empresa & " SET CAMPLIB1 = '" & TIPO_SER & "', CAMPLIB4 = 'Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "' " &
            ''    "WHERE CLAVE_DOC = '" & CVE_DOC & "' " &
            '    "IF @@ROWCOUNT = 0 " &
            '    "INSERT INTO FACTR_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB1, CAMPLIB4) VALUES('" & CVE_DOC & "','" & TIPO_SER & "','Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "')"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            Bitacora("1875. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1875. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '================================================================================================================
        '================================================================================================================
        '       PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS 
        '================================================================================================================
        '================================================================================================================
        NUM_PAR = 1
        returnValue = "0"
        IMPORTE = 0


        cmdOT.CommandText = "SELECT * FROM GCOT"
        drOT = cmdOT.ExecuteReader

        While drOT.Read
            Try
                CVE_ART = drOT("CVE_ART")
                CANT = drOT("CANT")
                PRECIO = drOT("PRECIO")

                If CVE_ART <> "TOT" Then
                    Try
                        NUM_ALM = 1
                    Catch ex As Exception
                        NUM_ALM = 1
                    End Try

                    Try
                        SQL = "SELECT ISNULL(TIPO_ELE,'P') AS TIPOELE, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, " &
                            "ISNULL(CVE_ESQIMPU,1) AS CVEESQIMPU, ISNULL(UNI_MED,'') AS UNIMED, ISNULL(DESCR,'') AS DES, ISNULL(PRECIO,0) AS P1 " &
                            "FROM INVE" & Empresa & " I " &
                            "LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1 " &
                            "WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULTCOSTO")
                                COSTO_PROM = dr("COSTOPROM")
                                CVE_ESQIMPU = dr("CVEESQIMPU")
                                DESCR = dr("DES")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNIMED")
                                TIPO_PROD = dr("TIPOELE")
                                If TIPO_PROD = "P" Then
                                    PRECIO = COSTO_PROM
                                End If

                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("1890. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1890. " & ex.Message & vbNewLine & ex.StackTrace)
                        Me.Cursor = Cursors.Default
                        Return
                    End Try
                    If Existe Then
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            dr = cmd.ExecuteReader
                            If dr.Read Then
                                IMPU1 = CSng(dr("IMPUESTO1"))
                                IMPU2 = CSng(dr("IMPUESTO2"))
                                IMPU3 = CSng(dr("IMPUESTO3"))
                                IMPU4 = CSng(dr("IMPUESTO4"))
                                IMP1APLA = CInt(dr("IMP1APLICA"))
                                IMP2APLA = CInt(dr("IMP2APLICA"))
                                IMP3APLA = CInt(dr("IMP3APLICA"))
                                IMP4APLA = CInt(dr("IMP4APLICA"))
                            End If
                            dr.Close()
                        Catch ex As Exception
                            Bitacora("1900. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1900. " & ex.Message & vbNewLine & ex.StackTrace)
                            Me.Cursor = Cursors.Default
                            Return
                        End Try
                        If CVE_ESQIMPU = 1 Then
                            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                        Else
                            MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                        End If

                        Try
                            DESC1 = 0
                        Catch ex As Exception
                            DESC1 = 0
                        End Try

                        Try
                            PRECIO = Math.Round(CDec(PRECIO), 6)
                            PREC = PRECIO

                            Desc2 = 0 : Desc3 = 0
                            SUBTOTAL += (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT += (CANT * PREC * DESC1 / 100)
                            DES_TOT += (DES_TOT * Desc2 / 100)
                            cIeps = ImporteConDes * IMPU1 / 100
                            cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                            cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                            cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 += TOTIMP1
                            IMP_TOT2 += TOTIMP2
                            IMP_TOT3 += TOTIMP3
                            IMP_TOT4 += TOTIMP4
                            TOT_PARTIDA = CANT * PREC
                            IMPORTE = IMPORTE + ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                            If CVE_ESQIMPU = 1 Then
                                MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
                            Else
                                MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0
                            End If
                        Catch ex As Exception
                            Bitacora("1940. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1940. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("1. La clave del articulo no existe")
                    End If
                    PXS = CANT
                    UNI_VENTA = UNI_MED
                    COST = COSTO_PROM

                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA & Empresa & " WHERE " &
                        "CVE_DOC = '" & CVE_DOC & "' AND CVE_ART = '" & CVE_ART & "' AND NUM_PAR = " & NUM_PAR & ") " &
                        "INSERT INTO PAR_FACT" & TIPO_VENTA & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, " &
                        "IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, " &
                        "DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, " &
                        "REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, " &
                        "CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, CVE_ESQ, DESCR_ART, UUID) " &
                        "VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & CVE_ART & "','" &
                        CANT & "','" & PXS & "','" & Math.Round(PREC, 6) & "','" & Math.Round(COST, 6) & "','" & IMPU1 & "','" & IMPU2 & "','" &
                        IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" &
                        IMP4APLA & "','" & Math.Round(TOTIMP1, 6) & "','" & TOTIMP2 & "','" & TOTIMP3 & "','" & Math.Round(TOTIMP4, 6) & "','" &
                        DESC1 & "','" & Desc2 & "','" & Desc3 & "','" & COMI & "','" & APAR & "','" & ACT_INV & "','" &
                        NUM_ALM & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','" & TIPO_PROD & "','" &
                        CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "',(" &
                        "SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & Math.Round(TOT_PARTIDA, 6) &
                        "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" &
                        APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & CVE_ESQIMPU & "',' ',NEWID())"

                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Grabar REMISION partida Articulo " & CVE_ART & " Partida: " & NUM_PAR & " Cant & " & CANT)
                            Try
                                If TIPO_VENTA = "RR" Or TIPO_VENTA = "VV" Then

                                    SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & ", FCH_ULTVTA = '" & FECHA_DOC & "' " &
                                        "WHERE CVE_ART = '" & CVE_ART & "'"
                                    Try
                                        cmd.Connection = cnSAE
                                        cmd.CommandTimeout = 180

                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                        End If
                                    Catch ex As Exception
                                        Bitacora("1960. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try

                                    If MULTIALMACEN = 1 Then
                                        SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT &
                                            " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
                                        Try
                                            cmd.Connection = cnSAE
                                            cmd.CommandTimeout = 180

                                            cmd.CommandText = SQL
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                            End If
                                        Catch ex As Exception
                                            Bitacora("1980. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If

                                    If TIPO_PROD = "S" Then
                                        CADENA_NUM_MOV = "'0'"
                                    Else
                                        CADENA_NUM_MOV = "(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & ")"
                                    End If

                                    SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, " &
                                         "REFER, CLAVE_CLPV, VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, " &
                                         "EXISTENCIA, TIPO_PROD, FACTOR_CON, FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, " &
                                         "COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" & CVE_ART & "','" & NUM_ALM & "'," &
                                         CADENA_NUM_MOV & ",'" & CVE_CPTO & "','" & FECHA_DOC & "','" &
                                         TIPO_VENTA & "','" & CVE_DOC & "','" & CVE_CLPV & "','" & CVE_VEND & "','" & CANT & "','" & CANT & "','" &
                                         PREC & "','" & ULT_COSTO & "','" & REG_SERIE & "','" & UNI_VENTA & "','" & E_LTPD & "'," &
                                         "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                                    If MULTIALMACEN = 1 Then
                                        SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND " &
                                                    "CVE_ALM = " & NUM_ALM & "),0),'"   'EXISTENCIA
                                    Else
                                        SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                                    End If
                                    SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE()," &
                                         "(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                         SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" &
                                         COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & ULT_COSTO & "')"

                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                    NUM_PAR += 1
                End If

            Catch ex As Exception
                Bitacora("2200. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2200. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


        End While
        drOT.Close()

        If TIPO_VENTA = "RRR" Or TIPO_VENTA = "V" Then
            Try
                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(CVE_FOLIO AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                MsgBox("2400. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2400. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Try
            If LETRA_VENTA = "" Or LETRA_VENTA = "STAND." Then
                SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA & "' AND SERIE = 'STAND.'"
            Else
                SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA & "' AND SERIE = '" & LETRA_VENTA & "'"
            End If
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            MsgBox("2460. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "UPDATE GCORDEN_TRABAJO_EXT SET DOC_ANTR = '" & CVE_DOC & "' WHERE CVE_ORD = '" & CVE_PEDI & "'"
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

        Catch ex As Exception
            Bitacora("2480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Select Case TIPO_VENTA
            Case "P"
                GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Se grabo en pedido " & CVE_DOC)
            Case "C"
                GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Se grabo la cotizacion " & CVE_DOC)
            Case "R"
                GRABA_BITA(CVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA, " Se creo la remision " & CVE_DOC)
        End Select

        Me.Cursor = Cursors.Default

        IMPRIMIR_VENTA(CVE_DOC)

    End Sub

    Sub IMPRIMIR_VENTA(FCVE_DOC As String)
        Dim Rreporte_MRT As String
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
            Select Case Empresa
                Case "01"
                    Rreporte_MRT = "ReportRemision.mrt"
                Case "02"
                    Rreporte_MRT = "ReportRemision02.mrt"
                Case "03"
                    Rreporte_MRT = "ReportRemision03.mrt"
                Case "04"
                    Rreporte_MRT = "ReportRemision04.mrt"
                Case "05"
                    Rreporte_MRT = "ReportRemision05.mrt"
                Case "06"
                    Rreporte_MRT = "ReportRemision06.mrt"
                Case "07"
                    Rreporte_MRT = "ReportRemision07.mrt"
                Case "08"
                    Rreporte_MRT = "ReportRemision08.mrt"
                Case "09"
                    Rreporte_MRT = "ReportRemision09.mrt"
                Case "10"
                    Rreporte_MRT = "ReportRemision10.mrt"
                Case "11"
                    Rreporte_MRT = "ReportRemision11.mrt"
                Case "12"
                    Rreporte_MRT = "ReportRemision12.mrt"
                Case "13"
                    Rreporte_MRT = "ReportRemision13.mrt"
                Case "14"
                    Rreporte_MRT = "ReportRemision14.mrt"
                Case "15"
                    Rreporte_MRT = "ReportRemision15.mrt"
                Case "16"
                    Rreporte_MRT = "ReportRemision16.mrt"
                Case "17"
                    Rreporte_MRT = "ReportRemision17.mrt"
                Case "18"
                    Rreporte_MRT = "ReportRemision18.mrt"
                Case "19"
                    Rreporte_MRT = "ReportRemision19.mrt"
                Case "20"
                    Rreporte_MRT = "ReportRemision20.mrt"
                Case "21"
                    Rreporte_MRT = "ReportRemision21.mrt"
                Case "22"
                    Rreporte_MRT = "ReportRemision22.mrt"
                Case Else
                    Rreporte_MRT = "ReportRemision.mrt"
            End Select
            If Not File.Exists(RUTA_FORMATOS & "\" & Rreporte_MRT) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\" & Rreporte_MRT & ", verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS & "\" & Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = FCVE_DOC
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            TCVE_COBRO.Select()
        End If

    End Sub
    Private Sub TCLIENTE_GotFocus(sender As Object, e As EventArgs) Handles TCLIENTE.GotFocus
        TCLIENTE.Tag = TCLIENTE.Text
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                    TCLIENTE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    TCLIENTE.Select()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TFLETE_KeyDown(sender As Object, e As KeyEventArgs) Handles TFLETE.KeyDown
        Try
            If e.KeyCode = 13 Then
                TVALOR_DECLA.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TFLETE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TFLETE.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                TVALOR_DECLA.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadRemCarga1_CheckedChanged(sender As Object, e As EventArgs) Handles RadRemCarga1.CheckedChanged
        Try
            'GpoRem1.Visible = True
            'GpoRem2.Visible = False
            'GpoRem3.Visible = False
            'GpoRem4.Visible = False
            GpoRem1.BackColor = Color.LightBlue
            GpoRem2.BackColor = Color.Transparent
            GpoRem3.BackColor = Color.Transparent
            GpoRem4.BackColor = Color.Transparent
            CALCULA_PRECIO_CARTA_PORTE()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadRemCarga2_CheckedChanged(sender As Object, e As EventArgs) Handles RadRemCarga2.CheckedChanged
        Try
            'GpoRem1.Visible = False
            'GpoRem2.Visible = True
            'GpoRem3.Visible = False
            'GpoRem4.Visible = False
            GpoRem1.BackColor = Color.Transparent
            GpoRem2.BackColor = Color.LightBlue
            GpoRem3.BackColor = Color.Transparent
            GpoRem4.BackColor = Color.Transparent
            CALCULA_PRECIO_CARTA_PORTE()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadRemCarga3_CheckedChanged(sender As Object, e As EventArgs) Handles RadRemCarga3.CheckedChanged
        Try
            'GpoRem1.Visible = False
            'GpoRem2.Visible = False
            'GpoRem3.Visible = True
            'GpoRem4.Visible = False
            GpoRem1.BackColor = Color.Transparent
            GpoRem2.BackColor = Color.Transparent
            GpoRem3.BackColor = Color.LightBlue
            GpoRem4.BackColor = Color.Transparent
            CALCULA_PRECIO_CARTA_PORTE()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadRemCarga4_CheckedChanged(sender As Object, e As EventArgs) Handles RadRemCarga4.CheckedChanged
        Try
            'GpoRem1.Visible = False
            'GpoRem2.Visible = False
            'GpoRem3.Visible = False
            'GpoRem4.Visible = True
            GpoRem1.BackColor = Color.Transparent
            GpoRem2.BackColor = Color.Transparent
            GpoRem3.BackColor = Color.Transparent
            GpoRem4.BackColor = Color.LightBlue
            CALCULA_PRECIO_CARTA_PORTE()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnValorDecla_Click(sender As Object, e As EventArgs) Handles BtnValorDecla.Click

        If TCLIENTE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el cliente fiscal")
            Return
        End If

        Try
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""

            If LtCVE_CON.Text.Trim.Length = 0 Then
                Var2 = "InveSAE"
                frmSelItem.ShowDialog()
            Else
                Var2 = "Tarifas"
                Var3 = LtCVE_CON.Text
                FrmSelItem2.ShowDialog()
            End If
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 2) 'PRECIO
                'Var5 = Fg(Fg.Row, 1) 'DESCR
                'Var7 = Fg(Fg.Row, 3) 'tipo OPERACION
                'Var8 = Fg(Fg.Row, 4) 'descr tipo OPERACION
                If LtCVE_CON.Text.Trim.Length = 0 Then
                    TVALOR_DECLA.Text = Var4
                    LtDescrTipoPago.Text = Var5
                Else
                    LtTipoOpe.Text = Var7
                    LtTipoOpeDes.Text = Var8

                    'If CVE_D_CAMPLIBCTE = 1 Then
                    'CLAVE_ART_SET = OBTENER_CAMPO_LIBRE_CTE(TCLIENTE.Text, LIB_CLIENTE)
                    'If CLAVE_ART_SET.Trim.Length = 0 Then
                    'TVALOR_DECLA.Text = CVE_ART_TARIFA
                    'Else
                    'TVALOR_DECLA.Text = CLAVE_ART_SET
                    'End If
                    '   CVE_ART_TARIFA = TVALOR_DECLA.Text
                    '  LtDescrTipoPago.Text = BUSCA_CAT("Inven", CVE_ART_TARIFA)
                    'Else
                    'DESPUES
                    'TVALOR_DECLA.Text = CVE_ART_TARIFA
                    'LtDescrTipoPago.Text = BUSCA_CAT("Inven", CVE_ART_TARIFA)

                    TVALOR_DECLA.Text = Var10 'CVE_ART_TARIFA
                    LtDescrTipoPago.Text = BUSCA_CAT("Inven", Var10)

                    'End If

                End If
                Try
                    If IsNumeric(CDec(Var6.Replace(",", ""))) Then

                        TFLETE.Value = CDec(Var6.Replace(",", ""))
                        If Var9 = "0" Then
                            TFLETE.Tag = TFLETE.Value
                        Else
                            TFLETE.Value = TFLETE.Value / 2
                            TFLETE.Tag = TFLETE.Value / 2
                        End If
                        LtImporteValorDeclarado.Text = Format(TFLETE.Value, "###,###,##0.00")

                        CALCULA_PRECIO_CARTA_PORTE()
                    End If
                Catch ex As Exception
                    Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'If VALOR_DECLA_DESDE_SAE = 1 Then
                'OBTIENE LOS IMPUESTOS DEL ARTICULO TVALOR_DECLA.TXT
                'DESPLEGAR_ARTICULO_SAE(Var4)
                'End If
                'CALCULAR_TOTALES_CON_IMPUESTOS(1)
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            Else
                TFLETE.ReadOnly = False
            End If
            TCANT.Focus()
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_TOTALES_CON_IMPUESTOS(fPESO As Decimal)
        Try

            If TVALOR_DECLA.Text.Trim.Length > 0 Then
                Dim PREC As Decimal = 0, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single

                PREC = CDec(TFLETE.Text) * fPESO

                PREC = Math.Round(PREC, 6)

                cIeps = PREC * vIMPU1 / 100
                If vIMP4APLA = 1 Then
                    cImpu2 = (PREC + cIeps) * vIMPU2 / 100
                    cImpu3 = (PREC + cIeps + cImpu2) * vIMPU3 / 100
                    cImpu = (PREC + cIeps + cImpu2 + cImpu3) * vIMPU4 / 100
                Else
                    cImpu2 = PREC * vIMPU2 / 100
                    cImpu3 = PREC * vIMPU3 / 100
                    cImpu = PREC * vIMPU4 / 100
                End If
                LtSubTotal.Text = Format(PREC, "###,###,###.00")
                LtIVA.Text = Format(cIeps + cImpu, "###,###,###.00")
                LtRet.Text = Format(cImpu2 + cImpu3, "###,###,###.00")
                LtNeto.Text = Format(PREC + cIeps + cImpu2 + cImpu3 + cImpu, "###,###,##0.00")

            Else
                LtSubTotal.Text = Format(CSng(TFLETE.Text), "###,###,###.00")
                LtIVA.Text = Format(TFLETE.Text * 0.16, "###,###,###.00")
                LtRet.Text = Format((TFLETE.Text * IEPS) / 100, "###,###,###.00")
                LtNeto.Text = Format(TFLETE.Text + (TFLETE.Text * 0.16) - ((TFLETE.Text * IEPS) / 100), "###,###,##0.00")

            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_ARTICULO_SAE(fCVE_ART As String)
        Try
            If fCVE_ART.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT I.CVE_ESQIMPU, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, IMP1APLICA, IMP2APLICA, IMP3APLICA, IMP4APLICA, 
                    (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = I.CVE_ART AND CVE_PRECIO = 1) AS P1
                    FROM INVE" & Empresa & " I
                    LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                    WHERE CVE_ART = '" & fCVE_ART & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            vPRECIO1 = dr("P1")
                            vIMPU1 = dr("IMPUESTO1")
                            vIMPU2 = dr("IMPUESTO2")
                            vIMPU3 = dr("IMPUESTO3")
                            vIMPU4 = dr("IMPUESTO4")
                            vIMP1APLA = dr("IMP1APLICA")
                            vIMP2APLA = dr("IMP2APLICA")
                            vIMP3APLA = dr("IMP3APLICA")
                            vIMP4APLA = dr("IMP4APLICA")

                            TFLETE_TextChanged(Nothing, Nothing)

                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TVALOR_DECLA_KeyDown(sender As Object, e As KeyEventArgs) Handles TVALOR_DECLA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnValorDecla_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TVALOR_DECLA_Validating(sender As Object, e As CancelEventArgs) Handles TVALOR_DECLA.Validating
        Try
            '  CLAVE DEL ARTICULO PUEDE SER VALOR DELCRADA O INVE01
            If TVALOR_DECLA.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If VALOR_DECLA_DESDE_SAE = 0 Then
                    DESCR = BUSCA_CAT("Valor Declarado", TVALOR_DECLA.Text)
                Else
                    DESCR = BUSCA_CAT("InvesSAE", TVALOR_DECLA.Text)
                End If
                If DESCR <> "" Then
                    LtDescrTipoPago.Text = DESCR
                    If IsNumeric(Var7) Then

                        TFLETE.Value = CDec(Var7)
                        TFLETE.Tag = TFLETE.Value
                        LtImporteValorDeclarado.Text = Format(CDec(Var7), "###,###,##0.00")
                    End If
                    Try
                        'LValorDeclarado.Text = Format(Var6, "###,###,##0.00")

                        CALCULA_PRECIO_CARTA_PORTE()
                    Catch ex As Exception
                    End Try
                    If VALOR_DECLA_DESDE_SAE <> 0 Then
                        DESPLEGAR_ARTICULO_SAE(TVALOR_DECLA.Text)
                    End If

                    'CALCULAR_TOTALES_CON_IMPUESTOS(1)

                Else
                    MessageBox.Show("Artículo inexistente o no se encuentra en la linea " & LINEA_VALOR_DECLA)
                    TVALOR_DECLA.Focus()
                    TVALOR_DECLA.Text = ""
                    LtDescrTipoPago.Text = ""
                    LtImporteValorDeclarado.Text = ""
                    TFLETE.ReadOnly = False
                    e.Cancel = True
                End If
            Else
                LtDescrTipoPago.Text = ""
                LtImporteValorDeclarado.Text = ""
                TFLETE.ReadOnly = False
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULA_PRECIO_CARTA_PORTE()
        Dim PESO As Decimal, PRECIO As Decimal, PREC_FLETE As String
        Try
            Try 'LValorDeclarado.Text = importe del concepto
                If TCVE_ART.Text.Trim.Length = 0 Then
                    If IsNumeric(LtImporteValorDeclarado.Text.Trim.Replace(",", "")) Then
                        PRECIO = CDec(LtImporteValorDeclarado.Text.Trim.Replace(",", ""))
                        TFLETE.ReadOnly = True
                    Else
                        PRECIO = 0
                    End If
                Else
                    PRECIO = 0
                    If Not IsNothing(TFLETE.Tag) Then
                        PREC_FLETE = TFLETE.Tag
                        PREC_FLETE.Trim.Replace(",", "")
                        If IsNumeric(PREC_FLETE) Then
                            PRECIO = PREC_FLETE
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
                PRECIO = 0
            End Try

            If RadPrecioXViaje.Checked Then

                If IsNumeric(LtImporteValorDeclarado.Text.Replace(",", "")) Then
                    TFLETE.Value = LtImporteValorDeclarado.Text.Replace(",", "")
                Else
                    TFLETE.Value = TFLETE.Tag
                End If
                TFLETE_TextChanged(Nothing, Nothing)
            ElseIf RadRemCarga1.Checked Then
                If IsNumeric(TPESO_BRUTO1.Text.Replace(",", "")) And IsNumeric(TTARA1.Text.Replace(",", "")) Then
                    PESO = CDec(TPESO_BRUTO1.Text.Replace(",", "")) - CDec(TTARA1.Text.Replace(",", ""))
                    TFLETE.Value = PRECIO '* PESO
                    CALCULAR_TOTALES_CON_IMPUESTOS(PESO)
                End If
            ElseIf RadRemCarga2.Checked Then
                If IsNumeric(TPESO_BRUTO2.Text.Replace(",", "")) And IsNumeric(TTARA2.Text.Replace(",", "")) Then
                    PESO = TPESO_BRUTO2.Text - TTARA2.Text
                    TFLETE.Value = PRECIO '* PESO
                    CALCULAR_TOTALES_CON_IMPUESTOS(PESO)
                End If
            ElseIf RadRemCarga3.Checked Then
                If IsNumeric(TPESO_BRUTO3.Text.Replace(",", "")) And IsNumeric(TTARA3.Text.Replace(",", "")) Then
                    PESO = TPESO_BRUTO3.Text - TTARA3.Text
                    TFLETE.Value = PRECIO '* PESO
                    CALCULAR_TOTALES_CON_IMPUESTOS(PESO)
                End If
            ElseIf RadRemCarga4.Checked Then
                PESO = TPESO_BRUTO4.Text - TTARA4.Text
                TFLETE.Value = PRECIO '* PESO
                CALCULAR_TOTALES_CON_IMPUESTOS(PESO)
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CALCULAR_IMPORTE_PRECIO_VIAJE()
        Try
            If IsNumeric(LtImporteValorDeclarado.Text.Replace(",", "")) Then

                Dim CANT As Decimal, PRECIO As Decimal
                CANT = TCANT.Text
                PRECIO = CDec(LtImporteValorDeclarado.Text.Replace(",", ""))

                TFLETE.Value = PRECIO


                GpoRem1.BackColor = Color.Transparent
                GpoRem2.BackColor = Color.Transparent
                GpoRem3.BackColor = Color.Transparent
                GpoRem4.BackColor = Color.Transparent
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCANT_TextChanged(sender As Object, e As EventArgs) Handles TCANT.TextChanged
        TFLETE_TextChanged(Nothing, Nothing)
    End Sub
    Private Sub BtnTabRutaViajes_Click(sender As Object, e As EventArgs) Handles BtnTabRutaViajes.Click
        Try
            Var2 = "RUTAS FLORES"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TAB_VIAJE.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                TCLAVE_O.Focus()
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
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
                    WHERE CVE_TAB = '" & TCVE_TAB_VIAJE.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TCLAVE_O.Focus()
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
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles BtnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESQIMPU.Text = Var4
                TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                LtEsquema.Text = Var5

                CALCUAL_NUEVO_ESQUEMA(TFLETE.Value)
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Gpo6.Focus()
            End If
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ESQIMPU.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEsquema_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_ESQIMPU_Validated(sender As Object, e As EventArgs) Handles TCVE_ESQIMPU.Validated
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Esquema inexistente")
                    TCVE_ESQIMPU.Text = TCVE_ESQIMPU.Tag
                    TCVE_ESQIMPU.Select()
                Else
                    TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                    LtEsquema.Text = CADENA

                    CALCUAL_NUEVO_ESQUEMA(TFLETE.Value)
                End If
            Else
                LtEsquema.Text = ""

                DESPLEGAR_ARTICULO_SAE(TVALOR_DECLA.Text)

            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    tEMBARQUE.Focus()
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTARA4_KeyDown(sender As Object, e As KeyEventArgs) Handles TTARA4.KeyDown
        Try
            If e.KeyCode = 13 Then
                'FRC.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TTARA4_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TTARA4.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                'FRC.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TTARA3_KeyDown(sender As Object, e As KeyEventArgs) Handles TTARA3.KeyDown
        Try
            If e.KeyCode = 9 Then
                'tREM_CARGA4.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TTARA3_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TTARA3.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                'tREM_CARGA4.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCARGA_ANTERIOR_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCARGA_ANTERIOR.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Gpo5.Select()
        End If
    End Sub

    Private Sub TCVE_DOLLY_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_DOLLY.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Box4.Select()
        End If
    End Sub

    Private Sub TPEDIMENTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TPEDIMENTO.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TCLIENTE.Focus()
            TCLIENTE.Select()
        End If
    End Sub

    Private Sub RadCargado_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RadCargado.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TORDEN_DE.Select()
        End If
    End Sub

    Private Sub RadVacio_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RadVacio.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TORDEN_DE.Select()
        End If
    End Sub
End Class

