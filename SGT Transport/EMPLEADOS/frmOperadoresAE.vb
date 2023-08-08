Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Public Class frmOperadoresAE
    Private RUTA_IMAGEN As String
    Private NewRecord As Boolean = False

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_CONTROLES1()
        CARGA_CAT()
        CARGAR_DATOS()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ResumeLayout()

    End Sub
    Private Sub FrmOperadoresAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        FgFotDoc.AllowEditing = False

    End Sub
    Sub CARGAR_DATOS()
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.Connection = cnSAE

        Try

            BtnDocVencA.FlatStyle = FlatStyle.Flat
            BtnDocVencA.FlatAppearance.BorderSize = 0
            BtnDocVencE.FlatStyle = FlatStyle.Flat
            BtnDocVencE.FlatAppearance.BorderSize = 0
            BtnPuesto.FlatStyle = FlatStyle.Flat
            BtnPuesto.FlatAppearance.BorderSize = 0
            BtnUniAsig.FlatStyle = FlatStyle.Flat
            BtnUniAsig.FlatAppearance.BorderSize = 0
            BtnFotDocE.FlatStyle = FlatStyle.Flat
            BtnFotDocE.FlatAppearance.BorderSize = 0
            BtnFotDocA.FlatStyle = FlatStyle.Flat
            BtnFotDocA.FlatAppearance.BorderSize = 0
            BtnAgregarIncidencia.FlatStyle = FlatStyle.Flat
            BtnAgregarIncidencia.FlatAppearance.BorderSize = 0
            BtnEliminarIncidencia.FlatStyle = FlatStyle.Flat
            BtnEliminarIncidencia.FlatAppearance.BorderSize = 0
            BtnIncidencias.FlatStyle = FlatStyle.Flat
            BtnIncidencias.FlatAppearance.BorderSize = 0
            BtnAltaAnt.FlatStyle = FlatStyle.Flat
            BtnAltaAnt.FlatAppearance.BorderSize = 0
            BtnBajaAnt.FlatStyle = FlatStyle.Flat
            BtnBajaAnt.FlatAppearance.BorderSize = 0
            BtnImprimir.FlatStyle = FlatStyle.Flat
            BtnImprimir.FlatAppearance.BorderSize = 0

        Catch ex As Exception
        End Try
        Select Case Var3
            Case "B"
                LtBaja.Visible = True
                BtnActivo.Visible = True
                Lb1.Visible = True
                Lb2.Visible = True
                TMOTIVO_BAJA.Visible = True
                BtnActivo.Text = "Baja"
                BtnActivo.Tag = "Baja"
            Case "R"
                LtBaja.Visible = False
                BtnActivo.Visible = False
                Lb1.Visible = False
                Lb2.Visible = False
                TMOTIVO_BAJA.Visible = False
                BtnActivo.Text = "Reactivado"
                BtnActivo.Tag = "Reactivado"
            Case Else
                '"A"
                LtBaja.Visible = False
                BtnActivo.Visible = False
                Lb1.Visible = False
                Lb2.Visible = False
                TMOTIVO_BAJA.Visible = False
                BtnActivo.Text = "Activo"
                BtnActivo.Tag = "Activo"
        End Select

        If Var1 = "Nuevo" Then
            Try
                NewRecord = True
                INICIALIZAR_CONTROLES()
                TCLAVE.Text = GET_MAX("GCOPERADOR", "CLAVE")
                TCLAVE.Enabled = False
                TNOMBRE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Try
                    SQL = "SELECT O.CLAVE, O.CLAVE_MONTE, O.STATUS, O.ESPERMISIONARIO, O.NOMBRE, O.RFC, O.CURP, O.FCONTRA, O.CALLE, O.TELEFONO,
                        O.COLONIA, O.CP, O.CIUDAD, O.CVE_ESTADO, O.LICENCIA, O.LIC_VENC, O.LICB, O.LICC, O.LICE, O.PASAPARTE, O.PAS_VENC,
                        O.IMSS, O.CVE_GRUSAN, O.DIABETICO, O.HIPERTENSO, O.ALERGIAS, O.CVE_BANCO, O.APP_MOVIL, O.NUM_CUENTA, O.CLABE,
                        O.CVE_TIPO_OPER, O.CVE_EDOCIVIL, O.FECHANAC, O.BENEFICIARIO, O.AVISAR_A, O.CVE_PUESTO, O.FACTO_SM_INFONAVIT,
                        O.FACTO_PORC_INFONAVIT, O.RET_DIARIA_INFONAVIT, O.RET_DIARIA_FONACOT, O.TRANSPORTADORA, O.CVE_TRACTOR,
                        ISNULL(O.CVE_OBS,0) AS CVEOBS, CVE_TIPO_REG, O.CVE_DEPTO, O.CVE_TIPO_CON, O.CVE_TIPO_JOR, O.CVE_PER_PAGO,
                        O.CVE_RIES_PUE, O.CORREO, O.VL_SEN_CAR, O.VL_SEN_VAC, O.VL_FULL_CAR_CAR, O.VL_FULL_VAC_VAC, O.VL_FULL_CAR_VAC,
                        O.VL_SUE_SEM, O.VL_SUE_DIA, O.VL_SUE_DIA_INT, O.VL_SEN_CAR_KM, O.VL_SEN_CAR_MI, O.VL_SEN_VAC_KM, O.VL_SEN_VAC_MI,
                        O.VL_FULL_VAC_VAC_KM, O.VL_FULL_VAC_VAC_MI, O.VL_FULL_CAR_CAR_KM, O.VL_FULL_CAR_CAR_MI, O.VL_FULL_CAR_VAC_KM,
                        O.VL_FULL_CAR_VAC_MI, O.CVE_CLASIFIC, ISNULL(OB.DESCR,'') AS OBS_STR, ISNULL(P.DESCR,'') AS NOMPUESTO, ISNULL(T.DESCR,'') AS MODE,
                        ISNULL(MPRUEBA,'') AS M_PRUEBA, ISNULL(FECHA_ANTI,'') AS F_ANTI, ISNULL(RESPONSABLE,'') AS RESPON, ISNULL(COCAINA,'') AS C_OCAINA,
                        ISNULL(TETRA, '') AS T_ETRA, ISNULL(ANFETAMINA,'') AS A_NFETAMINA, ISNULL(MENTA,'') AS M_ENTA, ISNULL(OPIACEOS,'') AS O_PIACEOS,
                        CVE_IMAGEN, O.CUEN_CONT, NOMBRE_OPER, AP_PATERNO, AP_MATERNO, CP_SAT, COLONIA_SAT,  MUNICIPIO, MUNICIPIO_SAT, POBLACION_SAT, 
                        ESTADO_SAT, REFRENDO_MEDICO, PAIS, PAIS_SAT, NUM_EXT, CORREO_PER, ISNULL(O.MOTIVO_BAJA,'') AS MOT_BAJA, 
                        ISNULL(O.USUARIO_BAJA,'') AS USU_BAJA
                        FROM GCOPERADOR O
                        LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS
                        LEFT JOIN GCPUESTOS P ON P.CVE_PUESTO = O.CVE_PUESTO
                        LEFT JOIN GCUNIDADES T ON T.CLAVE = O.CVE_TRACTOR
                        WHERE O.CLAVE = '" & Var2 & "'"

                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        TCLAVE.Text = dr.ReadNullAsEmptyString("CLAVE")
                        TCLAVE_MONTE.Text = dr.ReadNullAsEmptyString("CLAVE_MONTE")
                        Try
                            ChEsPermisionario.Value = dr.ReadNullAsEmptyInteger("ESPERMISIONARIO")

                            TNOMBRE_OPER.Text = dr.ReadNullAsEmptyString("NOMBRE_OPER")
                            TAP_PATERNO.Text = dr.ReadNullAsEmptyString("AP_PATERNO")
                            TAP_MATERNO.Text = dr.ReadNullAsEmptyString("AP_MATERNO")
                            TCorreoPersonal.Text = dr.ReadNullAsEmptyString("CORREO_PER")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            TCOLONIA.Text = dr.ReadNullAsEmptyString("COLONIA")
                            TCP.Text = dr.ReadNullAsEmptyString("CP")
                            TPOBLACION.Text = dr.ReadNullAsEmptyString("CIUDAD")
                            TMUNICIPIO.Text = dr.ReadNullAsEmptyString("MUNICIPIO")

                            TCOLONIA_SAT.Text = dr.ReadNullAsEmptyString("COLONIA_SAT")
                            TCP_SAT.Text = dr.ReadNullAsEmptyString("CP_SAT")
                            TPOBLACION_SAT.Text = dr.ReadNullAsEmptyString("POBLACION_SAT")
                            TMUNICIPIO_SAT.Text = dr.ReadNullAsEmptyString("MUNICIPIO_SAT")
                            TESTADO_SAT.Text = dr.ReadNullAsEmptyString("ESTADO_SAT")
                            TPAIS.Text = dr.ReadNullAsEmptyString("PAIS")
                            TPAIS_SAT.Text = dr.ReadNullAsEmptyString("PAIS_SAT")
                            TNUM_EXT.Text = dr.ReadNullAsEmptyString("NUM_EXT")

                            FRM.Value = dr("REFRENDO_MEDICO")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboEstado.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_ESTADO") Then
                                    CboEstado.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next

                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            TNOMBRE.Text = dr.ReadNullAsEmptyString("NOMBRE")
                            TRFC.Text = dr.ReadNullAsEmptyString("RFC")
                            TCURP.Text = dr.ReadNullAsEmptyString("CURP")
                            If IsDate(dr("FCONTRA")) Then
                                FContra.Value = dr("FCONTRA")
                            End If

                            TCALLE.Text = dr.ReadNullAsEmptyString("CALLE")
                            TTELEFONO.Text = dr.ReadNullAsEmptyString("TELEFONO")

                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            TLICENCIA.Text = dr("LICENCIA")
                            If IsDate(dr("LIC_VENC")) Then
                                FLIC_VENC.Value = dr("LIC_VENC")
                            End If

                            If dr.ReadNullAsEmptyInteger("LICB") = 1 Then
                                ChLicenciaB.Checked = True
                            Else
                                ChLicenciaB.Checked = False
                            End If
                            If dr.ReadNullAsEmptyInteger("LICC") = 1 Then
                                ChLicenciaC.Checked = True
                            Else
                                ChLicenciaC.Checked = False
                            End If
                            If dr.ReadNullAsEmptyInteger("LICE") = 1 Then
                                ChLicenciaE.Checked = True
                            Else
                                ChLicenciaE.Checked = False
                            End If

                            TPasaparte.Text = dr.ReadNullAsEmptyString("PASAPARTE")

                            If IsDate(dr.ReadNullAsEmptyString("PAS_VENC")) Then
                                FPAS_VENC.Value = dr.ReadNullAsEmptyString("PAS_VENC")
                            End If

                            TIMSS.Text = dr.ReadNullAsEmptyString("IMSS")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In cboGrupoSanguineo.Items
                                If vdp.ValuePair = dr("CVE_GRUSAN") Then
                                    cboGrupoSanguineo.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            If dr.ReadNullAsEmptyInteger("DIABETICO") = 1 Then
                                ChDiabetico.Checked = True
                            Else
                                ChDiabetico.Checked = False
                            End If
                            If dr.ReadNullAsEmptyInteger("HIPERTENSO") = 1 Then
                                ChHipertenso.Checked = True
                            Else
                                ChHipertenso.Checked = False
                            End If
                            TAlergias.Text = dr.ReadNullAsEmptyString("ALERGIAS")
                        Catch ex As Exception
                            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboBanco.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_BANCO") Then
                                    CboBanco.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            If dr.ReadNullAsEmptyInteger("APP_MOVIL") = 1 Then
                                chAplicacionMovil.Checked = True
                            Else
                                chAplicacionMovil.Checked = False
                            End If
                            TNUM_CUENTA.Text = dr.ReadNullAsEmptyString("NUM_CUENTA")
                            TCLABE.Text = dr.ReadNullAsEmptyString("CLABE")
                            TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")
                        Catch ex As Exception
                            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboTipoOper.Items
                                If vdp.ValuePair = dr("CVE_TIPO_OPER") Then
                                    CboTipoOper.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            TCVE_EDOCIVIL.Text = dr.ReadNullAsEmptyString("CVE_EDOCIVIL")

                            If IsDate(dr.ReadNullAsEmptyString("FECHANAC")) Then
                                FFECHA_NAC.Value = dr.ReadNullAsEmptyString("FECHANAC")
                            End If

                            TBeneficiario.Text = dr.ReadNullAsEmptyString("BENEFICIARIO")
                            TAVISAR_A.Text = dr.ReadNullAsEmptyString("AVISAR_A")
                            TCVE_PUESTO.Text = dr.ReadNullAsEmptyString("CVE_PUESTO")
                            LtPuesto.Text = dr.ReadNullAsEmptyString("NOMPUESTO")

                            TFACTO_SM_INFONAVIT.Text = dr.ReadNullAsEmptyString("FACTO_SM_INFONAVIT")
                            TFACTO_PORC_INFONAVIT.Text = dr.ReadNullAsEmptyString("FACTO_PORC_INFONAVIT")
                            TRET_DIARIA_INFONAVIT.Text = dr.ReadNullAsEmptyString("RET_DIARIA_INFONAVIT")
                            TRET_DIARIA_FONACOT.Text = dr.ReadNullAsEmptyString("RET_DIARIA_FONACOT")
                            TTRANSPORTADORA.Text = dr.ReadNullAsEmptyString("TRANSPORTADORA")

                            TCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                            LtTractor.Text = dr.ReadNullAsEmptyString("MODE")

                            TCVE_OBS.Text = dr.ReadNullAsEmptyString("OBS_STR")
                            TCVE_OBS.Tag = dr.ReadNullAsEmptyLong("CVEOBS")
                        Catch ex As Exception
                            Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboTipoRegimen.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_TIPO_REG") Then
                                    CboTipoRegimen.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboDepto.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyString("CVE_DEPTO") Then
                                    CboDepto.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboTipoContrato.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_TIPO_CON") Then
                                    CboTipoContrato.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboTipoJornada.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_TIPO_JOR") Then
                                    CboTipoJornada.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            For Each vdp As ValueDescriptionPair In CboPeriodicidadPago.Items
                                If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_PER_PAGO") Then
                                    CboPeriodicidadPago.SelectedIndex = vdp.cboIndex
                                    Exit For
                                End If
                            Next
                        Catch ex As Exception
                            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            If CboRiesgoPuesto.Items.Count - 1 > 0 Then
                                For Each vdp As ValueDescriptionPair In CboRiesgoPuesto.Items
                                    If vdp.ValuePair = dr.ReadNullAsEmptyInteger("CVE_RIES_PUE") Then
                                        CboRiesgoPuesto.SelectedIndex = vdp.cboIndex
                                        Exit For
                                    End If
                                Next
                            End If

                        Catch ex As Exception
                            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            TCORREO1.Text = dr.ReadNullAsEmptyString("CORREO")

                            TVL_SEN_CAR.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_CAR")
                            TVL_SEN_VAC.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_VAC")
                            TVL_FULL_CAR_CAR.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_CAR")
                            TVL_FULL_VAC_VAC.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_VAC_VAC")
                            TVL_FULL_CAR_VAC.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_VAC")
                            TVL_SUE_SEM.Text = dr.ReadNullAsEmptyDecimal("VL_SUE_SEM")
                            TVL_SUE_DIA.Text = dr.ReadNullAsEmptyDecimal("VL_SUE_DIA")
                            TVL_SUE_DIA_INT.Text = dr.ReadNullAsEmptyDecimal("VL_SUE_DIA_INT")
                            TVL_SEN_CAR_KM.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_CAR_KM")
                            TVL_SEN_CAR_MI.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_CAR_MI")
                            TVL_SEN_VAC_KM.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_VAC_KM")
                            TVL_SEN_VAC_MI.Text = dr.ReadNullAsEmptyDecimal("VL_SEN_VAC_MI")
                            TVL_FULL_VAC_VAC_KM.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_VAC_VAC_KM")
                            TVL_FULL_VAC_VAC_MI.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_VAC_VAC_MI")
                            TVL_FULL_CAR_CAR_KM.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_CAR_KM")
                            TVL_FULL_CAR_CAR_MI.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_CAR_MI")
                            TVL_FULL_CAR_VAC_KM.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_VAC_KM")
                            TVL_FULL_CAR_VAC_MI.Text = dr.ReadNullAsEmptyDecimal("VL_FULL_CAR_VAC_MI")
                            'tCVE_INC.text = dr("CVE_INC")
                            'tCVE_FOTDOC.text = dr("CVE_FOTDOC")
                            'tFOLIO_ULT_LIQ.text = dr("FOLIO_ULT_LIQ")
                            'tFECHA_ULT_LIQ.text = dr("FECHA_ULT_LIQ")
                            '"ISNULL(TETRA, '') AS T_ETRA, ISNULL(ANFETAMINA,'') AS ANFETAMINA, ISNULL(MENTA,'') AS MENTA, ISNULL(OPIACEOS,'') AS O_PIACEOS " &
                            TCVE_CLASIFIC.Text = dr.ReadNullAsEmptyInteger("CVE_CLASIFIC")
                            TCVE_ANT.Text = dr.ReadNullAsEmptyString("M_PRUEBA").ToString
                            FechaAnti.Value = dr.ReadNullAsEmptyString("F_ANTI").ToString
                            TREGISTRO.Text = dr.ReadNullAsEmptyString("RESPON").ToString
                            TCOCAINA.Text = dr.ReadNullAsEmptyString("C_OCAINA").ToString
                            TTETRA.Text = dr.ReadNullAsEmptyString("T_ETRA").ToString
                            TANFETAMINA.Text = dr.ReadNullAsEmptyString("A_NFETAMINA").ToString
                            TMETA.Text = dr.ReadNullAsEmptyString("M_ENTA").ToString
                            TOPIACEOS.Text = dr.ReadNullAsEmptyString("O_PIACEOS").ToString
                            'VENCIMIENTO DOCUMENTOS
                            VENCIMIENTO_DOCUMENTOS(TCLAVE.Text)
                            INCIDENCIAS(TCLAVE.Text)
                            DOC_FOTOS(TCLAVE.Text)

                            pic.Tag = dr.ReadNullAsEmptyString("CVE_IMAGEN").ToString

                            Select Case dr.ReadNullAsEmptyString("STATUS")
                                Case "B"
                                    BtnActivo.Text = "Baja"
                                    Lb3.Text = "USUARIO QUE LO DIO DE BAJA:" & dr("USU_BAJA")
                                Case "R"
                                    BtnActivo.Text = "Reactivado"
                                Case Else
                                    BtnActivo.Text = "Activo"
                            End Select

                            TMOTIVO_BAJA.Text = dr("MOT_BAJA")
                        Catch ex As Exception
                            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If pic.Tag.ToString.Trim.Length > 0 Then
                            If File.Exists(RUTA_IMAGEN & "\" & pic.Tag) Then

                                pic.Tag = RUTA_IMAGEN & "\" & pic.Tag

                                pic.Image = Image.FromFile(pic.Tag)
                                AutosizeImage(pic.Tag, pic)
                            Else
                                pic.Image = PicFoto.Image
                            End If
                        Else
                            pic.Image = PicFoto.Image
                        End If


                        CARGAR_ANTIDOPING()

                    Else
                        INICIALIZAR_CONTROLES()
                    End If
                    dr.Close()
                    TCLAVE.Enabled = False
                    TNOMBRE.Select()
                Catch Ex As Exception
                    Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                End Try

            Catch ex As Exception
                Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Tab1.TabPages.Item(7).TabVisible = False

        Me.Tab1.SelectedIndex = 0
    End Sub
    Sub CARGAR_CONTROLES1()

        If Var1 = "Edit" Then
        End If
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.CenterToScreen()


        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        FContra.Value = Date.Today
        FContra.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FContra.CustomFormat = "dd/MM/yyyy"
        FContra.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FContra.EditFormat.CustomFormat = "dd/MM/yyyy"

        FLIC_VENC.Value = Date.Today
        FLIC_VENC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FLIC_VENC.CustomFormat = "dd/MM/yyyy"
        FLIC_VENC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FLIC_VENC.EditFormat.CustomFormat = "dd/MM/yyyy"


        FPAS_VENC.Value = Date.Today
        FPAS_VENC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FPAS_VENC.CustomFormat = "dd/MM/yyyy"
        FPAS_VENC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FPAS_VENC.EditFormat.CustomFormat = "dd/MM/yyyy"


        FFECHA_NAC.Value = Date.Today
        FFECHA_NAC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFECHA_NAC.CustomFormat = "dd/MM/yyyy"
        FFECHA_NAC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FFECHA_NAC.EditFormat.CustomFormat = "dd/MM/yyyy"

        FInci.Value = Date.Today
        FInci.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FInci.CustomFormat = "dd/MM/yyyy"
        FInci.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FInci.EditFormat.CustomFormat = "dd/MM/yyyy"

        FDocVenc.Value = Date.Today
        FDocVenc.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FDocVenc.CustomFormat = "dd/MM/yyyy"
        FDocVenc.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FDocVenc.EditFormat.CustomFormat = "dd/MM/yyyy"

        FechaAnti.Value = Date.Today
        FechaAnti.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FechaAnti.CustomFormat = "dd/MM/yyyy"
        FechaAnti.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FechaAnti.EditFormat.CustomFormat = "dd/MM/yyyy"

        FRM.Value = Date.Today
        FRM.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FRM.CustomFormat = "dd/MM/yyyy"
        FRM.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        FRM.EditFormat.CustomFormat = "dd/MM/yyyy"

        FgDocVenc.Rows.Count = 1
        FgFotDoc.Rows.Count = 1
        FgInc.Rows.Count = 1
        FgA.Rows.Count = 1
        FgA.Rows(0).Height = 40

        CboMetodoPrueba.Items.Clear()
        CboMetodoPrueba.Items.Add("INMUNOENZIMATICO")
        CboMetodoPrueba.Items.Add("ORINA")
        CboMetodoPrueba.Items.Add("SANGRE")
        CboMetodoPrueba.Items.Add("SALIVA")

        CboMetodoPrueba.SelectedIndex = 0
    End Sub
    Private Sub FrmOperadoresAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmOperadoresAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Sub CARGAR_ANTIDOPING()

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            TCVE_ANT.Text = GET_MAX("GCANTIDOPING", "FOLIO")

            TREGISTRO.Text = ""

            FechaAnti.Value = Now
            TCOCAINA.Text = ""
            TTETRA.Text = ""
            TANFETAMINA.Text = ""
            TMETA.Text = ""
            TOPIACEOS.Text = ""

            cmd.Connection = cnSAE

            SQL = "SELECT A.FOLIO, A.REGISTRO, A.FECHA, A.COCAINA, A.TETRAHIDROCANABINOL, A.ANFETAMINAS, A.METANFETAMINAS, A.OPIACEOS, A.METODPRUEBA " &
                "FROM GCANTIDOPING A WHERE CLAVE = " & Var2

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgA.Rows.Count = 1

            Do While dr.Read
                FgA.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("REGISTRO") & vbTab & dr("FECHA") & vbTab & dr("COCAINA") & vbTab & dr("TETRAHIDROCANABINOL") & vbTab &
                           dr("ANFETAMINAS") & vbTab & dr("METANFETAMINAS") & vbTab & dr("OPIACEOS") & vbTab & dr("METODPRUEBA"))
            Loop
            dr.Close()
        Catch ex As Exception
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub INICIALIZAR_CONTROLES()
        Try

            TCLAVE.Text = ""
            TCLAVE_MONTE.Text = ""
            ChEsPermisionario.Checked = False

            TNOMBRE.Text = ""
            TRFC.Text = ""
            TCURP.Text = ""
            TCALLE.Text = ""
            TTELEFONO.Text = ""
            TCOLONIA.Text = ""
            TCP.Text = ""
            TPOBLACION.Text = ""
            CboEstado.SelectedIndex = -1
            TLICENCIA.Text = ""
            FLIC_VENC.Value = Now
            ChLicenciaB.Checked = False
            ChLicenciaC.Checked = False
            ChLicenciaE.Checked = False
            TPasaparte.Text = ""
            FPAS_VENC.Value = Now
            TIMSS.Text = ""
            cboGrupoSanguineo.SelectedIndex = -1
            ChDiabetico.Checked = False
            ChHipertenso.Checked = False
            TAlergias.Text = ""
            CboBanco.SelectedIndex = -1
            chAplicacionMovil.Checked = False
            TNUM_CUENTA.Text = ""
            TCLABE.Text = ""
            CboTipoOper.SelectedIndex = -1
            TCVE_EDOCIVIL.Text = ""
            FFECHA_NAC.Value = Now
            TBeneficiario.Text = ""
            TAVISAR_A.Text = ""
            TCVE_PUESTO.Text = ""
            TFACTO_SM_INFONAVIT.Text = ""
            TFACTO_PORC_INFONAVIT.Text = ""
            TRET_DIARIA_INFONAVIT.Text = ""
            TRET_DIARIA_FONACOT.Text = ""
            TTRANSPORTADORA.Text = ""
            TCVE_TRACTOR.Text = ""
            TCVE_OBS.Text = ""
            TCVE_OBS.Tag = "0"

            CboTipoRegimen.SelectedIndex = -1
            CboDepto.SelectedIndex = -1
            CboTipoContrato.SelectedIndex = -1
            CboTipoJornada.SelectedIndex = -1
            CboPeriodicidadPago.SelectedIndex = -1
            CboRiesgoPuesto.SelectedIndex = -1
            TCORREO1.Text = ""
            TVL_SEN_CAR.Text = ""
            TVL_SEN_VAC.Text = ""
            TVL_FULL_CAR_CAR.Text = ""
            TVL_FULL_VAC_VAC.Text = ""
            TVL_FULL_CAR_VAC.Text = ""
            TVL_SUE_SEM.Text = ""
            TVL_SUE_DIA.Text = ""
            TVL_SUE_DIA_INT.Text = ""
            TVL_SEN_CAR_KM.Text = ""
            TVL_SEN_CAR_MI.Text = ""
            TVL_SEN_VAC_KM.Text = ""
            TVL_SEN_VAC_MI.Text = ""
            TVL_FULL_VAC_VAC_KM.Text = ""
            TVL_FULL_VAC_VAC_MI.Text = ""
            TVL_FULL_CAR_CAR_KM.Text = ""
            TVL_FULL_CAR_CAR_MI.Text = ""
            TVL_FULL_CAR_VAC_KM.Text = ""
            TVL_FULL_CAR_VAC_MI.Text = ""


            LtFOLIO_ULT_LIQ.Text = ""
            LtFECHA_ULT_LIQ.Text = ""
            TCVE_CLASIFIC.Text = ""

            TCVE_ANT.Text = ""
            FechaAnti.Value = Now
            TREGISTRO.Text = ""
            TCOCAINA.Text = ""
            TTETRA.Text = ""
            TANFETAMINA.Text = ""
            TMETA.Text = ""
            TOPIACEOS.Text = ""
            TCUEN_CONT.Text = ""
            pic.Image = PicFoto.Image
            pic.Tag = ""

            FgA.Rows.Count = 1

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Sub DOC_FOTOS(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'O'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgFotDoc.Rows.Count = 1
            'CLAVE	CVE_FOTDOC	DESCR	DOCUMENTO	CVE_OBS
            Do While dr.Read
                FgFotDoc.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))
            Loop
            dr.Close()

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try


    End Sub

    Sub INCIDENCIAS(fCLAVE As String)

        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT V.CLAVE, ISNULL(V.CVE_INCI,0) AS CVE_IN, V.FECHA, V.CREADO_POR, V.CVE_INCI, V.CVE_OBS, ISNULL(C.DESCR,'') AS DESCR_INC, " &
                 "ISNULL(O.DESCR,'') AS OBSER " &
                 "FROM GCINCIDENCIAS V " &
                 "LEFT JOIN GCCATINCIDENCIAS C ON C.CVE_INC = V.CVE_INCI " &
                 "LEFT JOIN GCOBS O ON O.CVE_OBS = V.CVE_OBS " &
                 "WHERE CLAVE = '" & fCLAVE & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgInc.Rows.Count = 1
            'CLAVE	CVE_INC	FECHA	CREADO_POR	CVE_INCI	CVE_OBS
            'CVE_INC	STATUS	DESCR

            Do While dr.Read
                FgInc.AddItem("" & vbTab & dr("FECHA") & vbTab & dr("CREADO_POR") & vbTab & dr("DESCR_INC") & vbTab &
                                  dr("OBSER") & vbTab & dr("CVE_IN"))
            Loop
            dr.Close()

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try


    End Sub

    Sub VENCIMIENTO_DOCUMENTOS(fCLAVE As String)

        Try

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CVE_DOC, NOMBRE, FECHA_VENC, ISNULL(CVE_VENDOC,0) AS CVE_VEN FROM GCVENC_DOC WHERE CLAVE = '" & fCLAVE & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            FgDocVenc.Rows.Count = 1
            'CREATE TABLE GCVENC_DOC (CLAVE INT NULL, CVE_VENDOC SMALLINT NULL, CVE_DOC VARCHAR(255) NULL, NOMBRE VARCHAR(255) NULL)
            Do While dr.Read
                FgDocVenc.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("NOMBRE") & vbTab & dr("FECHA_VENC") & vbTab & dr("CVE_VEN"))
            Loop
            dr.Close()
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_CAT()
        Dim cmd As New SqlCommand
        Dim z As Integer
        cmd.Connection = cnSAE
        Dim dr As SqlDataReader
        Try
            SQL = "SELECT * FROM GCBANCOS WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboBanco.Items.Clear()
            Do While dr.Read
                CboBanco.Items.Add(New ValueDescriptionPair(dr("CVE_BANCO"), dr("DESCR"), dr("CVE_BANCO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_ESTADO,0) AS IDE, ISNULL(NOMBRE,'') AS NOM FROM GCESTADOS WHERE STATUS = 'A' ORDER BY NOMBRE"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboEstado.Items.Clear()
            Do While dr.Read
                CboEstado.Items.Add(New ValueDescriptionPair(dr("IDE"), dr("NOM"), dr("IDE"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCTIPO_OPERACION WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboTipoOper.Items.Clear()
            Do While dr.Read
                CboTipoOper.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCTIPO_REGIMEN WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboTipoRegimen.Items.Clear()
            Do While dr.Read
                CboTipoRegimen.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT ISNULL(CVE_DEPTO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCDEPTOS WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboDepto.Items.Clear()
            Do While dr.Read
                CboDepto.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCTIPO_CONTRATO WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboTipoContrato.Items.Clear()
            Do While dr.Read
                CboTipoContrato.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("32. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_TIPO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCTIPO_JORNADA WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboTipoJornada.Items.Clear()
            Do While dr.Read
                CboTipoJornada.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("33. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("33. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_PAGO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCPER_PAGO WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboPeriodicidadPago.Items.Clear()
            Do While dr.Read
                CboPeriodicidadPago.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(CVE_RIESGO,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCRIESGO_TRABAJO WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            CboRiesgoPuesto.Items.Clear()
            If dr.HasRows Then
                Do While dr.Read
                    CboRiesgoPuesto.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                    z = z + 1
                Loop
            Else
                CboRiesgoPuesto.Items.Add(" ")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("36. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("36. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT ISNULL(CVE_GRUSAN,0) AS TIPO, ISNULL(DESCR,'') AS NOM FROM GCGRUPO_SANGUINEO WHERE STATUS = 'A' ORDER BY DESCR"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            cboGrupoSanguineo.Items.Clear()
            Do While dr.Read
                cboGrupoSanguineo.Items.Add(New ValueDescriptionPair(dr("TIPO"), dr("NOM"), dr("TIPO"), "", z))
                z = z + 1
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("37. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("37. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            SQL = "SELECT ISNULL(RUTA_IMAGEN,'') AS RUTA_IMAG FROM GCPARAMGENERALES"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            z = 0
            If dr.Read Then
                RUTA_IMAGEN = dr("RUTA_IMAG")
            End If
            dr.Close()
            If RUTA_IMAGEN.Trim.Length = 0 Then
                RUTA_IMAGEN = Application.StartupPath
            End If
        Catch ex As Exception
            MsgBox("37. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("37. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CLAVE As Long = 0, file_ext As String, file_name As String, file_name_sin_ext As String, CVE_IMAGEN As String, CVE_RIES_PUE As Integer
        Dim CVE_ESTADO As Integer, CVE_GRUSAN As Integer, CVE_BANCO As Integer, CVE_TIPO_OPER As Integer, CVE_OBS As Long, MOTIVO_BAJA As String = ""
        Dim CVE_TIPO_REG As Integer, CVE_DEPTO As String, CVE_TIPO_CON As Integer, CVE_TIPO_JOR As Integer, CVE_PER_PAGO As Integer
        Dim STATUS_OPER As String = ""

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If TNOMBRE.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el nombre del operador")
            Return
        End If

        Try
            If BtnActivo.Text = "Baja" Then
                If TMOTIVO_BAJA.Text.Trim.Length < 30 Then
                    MsgBox("Por favor capture el motivo de baja del operador, al menos 30 caracteres")
                    Tab1.SelectedIndex = 8
                    Return
                Else
                    MOTIVO_BAJA = TMOTIVO_BAJA.Text

                    If MOTIVO_BAJA.Length > 255 Then
                        MOTIVO_BAJA = MOTIVO_BAJA.Substring(0, 255)
                    End If
                End If
            End If

            Select Case BtnActivo.Text
                Case "Baja"
                    STATUS_OPER = "B"
                Case "Reactivado"
                    STATUS_OPER = "R"
                Case Else
                    STATUS_OPER = "A"
            End Select

            If TCVE_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(TCVE_OBS.Tag) Then
                    CVE_OBS = TCVE_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & TCVE_OBS.Text & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & TCVE_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If

            TCVE_OBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CVE_ESTADO = 0
        CVE_DEPTO = ""

        Try
            Try
                If CboRiesgoPuesto.SelectedIndex = -1 Then
                    CVE_RIES_PUE = 0
                Else
                    CVE_RIES_PUE = CType(CboRiesgoPuesto.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("41. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("41. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboPeriodicidadPago.SelectedIndex = -1 Then
                    CVE_PER_PAGO = 0
                Else
                    CVE_PER_PAGO = CType(CboPeriodicidadPago.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("42. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("42. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboTipoJornada.SelectedIndex = -1 Then
                    CVE_TIPO_JOR = 0
                Else
                    CVE_TIPO_JOR = CType(CboTipoJornada.SelectedItem, ValueDescriptionPair).ClavePair
                End If

            Catch ex As Exception
                MsgBox("43. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("43. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboTipoContrato.SelectedIndex = -1 Then
                    CVE_TIPO_CON = 0
                Else
                    CVE_TIPO_CON = CType(CboTipoContrato.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("44. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("44. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboDepto.SelectedIndex = -1 Then
                    CVE_DEPTO = 0
                Else
                    CVE_DEPTO = CType(CboDepto.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("45. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboTipoRegimen.SelectedIndex = -1 Then
                    CVE_TIPO_REG = 0
                Else
                    CVE_TIPO_REG = CType(CboTipoRegimen.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("46. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("46. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboTipoOper.SelectedIndex = -1 Then
                    CVE_TIPO_OPER = 0
                Else
                    CVE_TIPO_OPER = CType(CboTipoOper.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("47. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("47. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboEstado.SelectedIndex = -1 Then
                    CVE_ESTADO = 0
                Else
                    CVE_ESTADO = CType(CboEstado.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("48. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("48. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If cboGrupoSanguineo.SelectedIndex = -1 Then
                    CVE_GRUSAN = 0
                Else
                    CVE_GRUSAN = CType(cboGrupoSanguineo.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("49. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboBanco.SelectedIndex = -1 Then
                    CVE_BANCO = 0
                Else
                    CVE_BANCO = CType(CboBanco.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Catch ex As Exception
                MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        CVE_IMAGEN = ""
        Try
            If pic.Tag.ToString.Trim.Length > 0 Then
                If File.Exists(pic.Tag) Then
                    file_ext = IO.Path.GetExtension(pic.Tag)
                    file_name = IO.Path.GetFileName(pic.Tag)
                    file_name_sin_ext = IO.Path.GetFileNameWithoutExtension(pic.Tag)

                    If file_name_sin_ext.Trim.Length > 16 Then file_name_sin_ext = file_name_sin_ext.Substring(0, 16)

                    CVE_IMAGEN = file_name_sin_ext & file_ext
                    FileCopy(pic.Tag, RUTA_IMAGEN & "\" & CVE_IMAGEN)
                End If
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If NewRecord Then
                SQL = "INSERT INTO GCOPERADOR (CLAVE, CLAVE_MONTE, STATUS, ESPERMISIONARIO, NOMBRE, RFC, CURP, FCONTRA, CALLE, TELEFONO, COLONIA, CP, 
                    CIUDAD, CVE_ESTADO, LICENCIA, LIC_VENC, LICB, LICC, LICE, PASAPARTE, PAS_VENC, IMSS, CVE_GRUSAN, DIABETICO, HIPERTENSO, ALERGIAS, 
                    CVE_BANCO, APP_MOVIL, NUM_CUENTA, CLABE, CVE_TIPO_OPER, CVE_EDOCIVIL, FECHANAC, BENEFICIARIO, AVISAR_A, CVE_PUESTO, FACTO_SM_INFONAVIT, 
                    FACTO_PORC_INFONAVIT, RET_DIARIA_INFONAVIT, RET_DIARIA_FONACOT, TRANSPORTADORA, CVE_TRACTOR, CVE_OBS, CVE_TIPO_REG, CVE_DEPTO, 
                    CVE_TIPO_CON, CVE_TIPO_JOR, CVE_PER_PAGO, CVE_RIES_PUE, CORREO, VL_SEN_CAR, VL_SEN_VAC, VL_FULL_CAR_CAR, VL_FULL_VAC_VAC, 
                    VL_FULL_CAR_VAC, VL_SUE_SEM, VL_SUE_DIA, VL_SUE_DIA_INT, VL_SEN_CAR_KM, VL_SEN_CAR_MI, VL_SEN_VAC_KM, VL_SEN_VAC_MI, VL_FULL_VAC_VAC_KM,
                    VL_FULL_VAC_VAC_MI, VL_FULL_CAR_CAR_KM,  VL_FULL_CAR_CAR_MI, VL_FULL_CAR_VAC_KM, VL_FULL_CAR_VAC_MI, CVE_CLASIFIC, MPRUEBA, FECHA_ANTI,
                    RESPONSABLE, COCAINA, TETRA, ANFETAMINA, MENTA, OPIACEOS, CVE_IMAGEN, CUEN_CONT, NOMBRE_OPER, AP_PATERNO, AP_MATERNO, MUNICIPIO, 
                    COLONIA_SAT, CP_SAT, POBLACION_SAT, MUNICIPIO_SAT, ESTADO_SAT, REFRENDO_MEDICO, PAIS, PAIS_SAT, NUM_EXT, CORREO_PER)
                    OUTPUT Inserted.CLAVE VALUES (
                    ISNULL((SELECT ISNULL(MAX(CLAVE),0) + 1 FROM GCOPERADOR),1), 
                    @CLAVE_MONTE, 'A', @ESPERMISIONARIO, @NOMBRE, @RFC, @CURP, @FCONTRA, @CALLE, @TELEFONO, @COLONIA, @CP, @CIUDAD, @CVE_ESTADO, @LICENCIA,
                    @LIC_VENC, @LICB, @LICC, @LICE, @PASAPARTE, @PAS_VENC, @IMSS, @CVE_GRUSAN, @DIABETICO, @HIPERTENSO, @ALERGIAS, @CVE_BANCO, @APP_MOVIL,
                    @NUM_CUENTA, @CLABE, @CVE_TIPO_OPER, @CVE_EDOCIVIL, @FECHANAC, @BENEFICIARIO, @AVISAR_A, @CVE_PUESTO, @FACTO_SM_INFONAVIT,
                    @FACTO_PORC_INFONAVIT, @RET_DIARIA_INFONAVIT, @RET_DIARIA_FONACOT, @TRANSPORTADORA, @CVE_TRACTOR, @CVE_OBS, @CVE_TIPO_REG, @CVE_DEPTO,
                    @CVE_TIPO_CON, @CVE_TIPO_JOR, @CVE_PER_PAGO, @CVE_RIES_PUE, @CORREO, @VL_SEN_CAR, @VL_SEN_VAC, @VL_FULL_CAR_CAR, @VL_FULL_VAC_VAC,
                    @VL_FULL_CAR_VAC, @VL_SUE_SEM, @VL_SUE_DIA, @VL_SUE_DIA_INT, @VL_SEN_CAR_KM, @VL_SEN_CAR_MI, @VL_SEN_VAC_KM, @VL_SEN_VAC_MI,
                    @VL_FULL_VAC_VAC_KM, @VL_FULL_VAC_VAC_MI, @VL_FULL_CAR_CAR_KM, @VL_FULL_CAR_CAR_MI, @VL_FULL_CAR_VAC_KM, @VL_FULL_CAR_VAC_MI, @CVE_CLASIFIC,
                    @MPRUEBA, @FECHA_ANTI, @RESPONSABLE, @COCAINA, @TETRA, @ANFETAMINA, @MENTA, @OPIACEOS, @CVE_IMAGEN, @CUEN_CONT, @NOMBRE_OPER, @AP_PATERNO,
                    @AP_MATERNO, @MUNICIPIO, @COLONIA_SAT, @CP_SAT, @POBLACION_SAT, @MUNICIPIO_SAT, @ESTADO_SAT, @REFRENDO_MEDICO, @PAIS, @PAIS_SAT, @NUM_EXT,
                    @CORREO_PER)"
            Else
                SQL = "UPDATE GCOPERADOR SET CLAVE = @CLAVE, CLAVE_MONTE = @CLAVE_MONTE, ESPERMISIONARIO = @ESPERMISIONARIO, NOMBRE = @NOMBRE, RFC = @RFC, 
                    CURP = @CURP, FCONTRA = @FCONTRA, CALLE = @CALLE, TELEFONO = @TELEFONO,  COLONIA = @COLONIA, CP = @CP, CIUDAD = @CIUDAD, 
                    CVE_ESTADO = @CVE_ESTADO, LICENCIA = @LICENCIA, LIC_VENC = @LIC_VENC, LICB = @LICB, LICC = @LICC, LICE = @LICE, PASAPARTE = @PASAPARTE, 
                    PAS_VENC = @PAS_VENC, IMSS = @IMSS, CVE_GRUSAN = @CVE_GRUSAN, DIABETICO = @DIABETICO, HIPERTENSO = @HIPERTENSO, ALERGIAS = @ALERGIAS, 
                    CVE_BANCO = @CVE_BANCO, APP_MOVIL = @APP_MOVIL, NUM_CUENTA = @NUM_CUENTA, CLABE = @CLABE, CVE_TIPO_OPER = @CVE_TIPO_OPER, 
                    CVE_EDOCIVIL = @CVE_EDOCIVIL, FECHANAC = @FECHANAC, BENEFICIARIO = @BENEFICIARIO, AVISAR_A = @AVISAR_A, CVE_PUESTO = @CVE_PUESTO, 
                    FACTO_SM_INFONAVIT = @FACTO_SM_INFONAVIT, FACTO_PORC_INFONAVIT = @FACTO_PORC_INFONAVIT, RET_DIARIA_INFONAVIT = @RET_DIARIA_INFONAVIT, 
                    RET_DIARIA_FONACOT = @RET_DIARIA_FONACOT, TRANSPORTADORA = @TRANSPORTADORA, CVE_TRACTOR = @CVE_TRACTOR, CVE_OBS = @CVE_OBS, 
                    CVE_TIPO_REG = @CVE_TIPO_REG, CVE_DEPTO = @CVE_DEPTO, CVE_TIPO_CON = @CVE_TIPO_CON, CVE_TIPO_JOR = @CVE_TIPO_JOR, 
                    CVE_PER_PAGO = @CVE_PER_PAGO, CVE_RIES_PUE = @CVE_RIES_PUE, CORREO = @CORREO, VL_SEN_CAR = @VL_SEN_CAR, VL_SEN_VAC = @VL_SEN_VAC, 
                    VL_FULL_CAR_CAR = @VL_FULL_CAR_CAR, VL_FULL_VAC_VAC = @VL_FULL_VAC_VAC, VL_FULL_CAR_VAC = @VL_FULL_CAR_VAC, VL_SUE_SEM = @VL_SUE_SEM, 
                    VL_SUE_DIA = @VL_SUE_DIA, VL_SUE_DIA_INT = @VL_SUE_DIA_INT, VL_SEN_CAR_KM = @VL_SEN_CAR_KM, VL_SEN_CAR_MI = @VL_SEN_CAR_MI, 
                    VL_SEN_VAC_KM = @VL_SEN_VAC_KM, VL_SEN_VAC_MI = @VL_SEN_VAC_MI, VL_FULL_VAC_VAC_KM = @VL_FULL_VAC_VAC_KM, 
                    VL_FULL_VAC_VAC_MI = @VL_FULL_VAC_VAC_MI, VL_FULL_CAR_CAR_KM = @VL_FULL_CAR_CAR_KM, VL_FULL_CAR_CAR_MI = @VL_FULL_CAR_CAR_MI, 
                    VL_FULL_CAR_VAC_KM = @VL_FULL_CAR_VAC_KM, VL_FULL_CAR_VAC_MI = @VL_FULL_CAR_VAC_MI, CVE_CLASIFIC = @CVE_CLASIFIC, MPRUEBA = @MPRUEBA, 
                    FECHA_ANTI = @FECHA_ANTI, RESPONSABLE = @RESPONSABLE, COCAINA = @COCAINA, TETRA = @TETRA, ANFETAMINA = @ANFETAMINA, MENTA = @MENTA, 
                    OPIACEOS = @OPIACEOS, CVE_IMAGEN = @CVE_IMAGEN, CUEN_CONT = @CUEN_CONT, NOMBRE_OPER = @NOMBRE_OPER, AP_PATERNO = @AP_PATERNO, 
                    AP_MATERNO = @AP_MATERNO, MUNICIPIO = @MUNICIPIO, COLONIA_SAT = @COLONIA_SAT, CP_SAT = @CP_SAT, POBLACION_SAT = @POBLACION_SAT, 
                    MUNICIPIO_SAT = @MUNICIPIO_SAT, ESTADO_SAT = @ESTADO_SAT, REFRENDO_MEDICO = @REFRENDO_MEDICO, PAIS = @PAIS, PAIS_SAT = @PAIS_SAT, 
                    NUM_EXT = @NUM_EXT, CORREO_PER = @CORREO_PER, STATUS = @STATUS, MOTIVO_BAJA = @MOTIVO_BAJA
                    WHERE CLAVE = @CLAVE "
            End If
            cmd.CommandText = SQL
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CInt(TCLAVE.Text)
            cmd.Parameters.Add("@CLAVE_MONTE", SqlDbType.VarChar).Value = TCLAVE_MONTE.Text
            cmd.Parameters.Add("@ESPERMISIONARIO", SqlDbType.SmallInt).Value = ChEsPermisionario.Checked
            cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Text
            cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Text
            cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = TCURP.Text
            cmd.Parameters.Add("@FCONTRA", SqlDbType.Date).Value = FContra.Value
            cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = TCALLE.Text
            cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TTELEFONO.Text
            cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = TCOLONIA.Text
            cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = TCP.Text
            cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = TPOBLACION.Text
            cmd.Parameters.Add("@CVE_ESTADO", SqlDbType.VarChar).Value = CVE_ESTADO
            cmd.Parameters.Add("@LICENCIA", SqlDbType.VarChar).Value = TLICENCIA.Text
            cmd.Parameters.Add("@LIC_VENC", SqlDbType.Date).Value = FLIC_VENC.Value
            cmd.Parameters.Add("@LICB", SqlDbType.SmallInt).Value = IIf(ChLicenciaB.Checked, 1, 0)
            cmd.Parameters.Add("@LICC", SqlDbType.SmallInt).Value = IIf(ChLicenciaC.Checked, 1, 0)
            cmd.Parameters.Add("@LICE", SqlDbType.SmallInt).Value = IIf(ChLicenciaE.Checked, 1, 0)
            cmd.Parameters.Add("@PASAPARTE", SqlDbType.VarChar).Value = TPasaparte.Text
            cmd.Parameters.Add("@PAS_VENC", SqlDbType.Date).Value = FPAS_VENC.Value
            cmd.Parameters.Add("@IMSS", SqlDbType.VarChar).Value = TIMSS.Text
            cmd.Parameters.Add("@CVE_GRUSAN", SqlDbType.VarChar).Value = CVE_GRUSAN
            cmd.Parameters.Add("@DIABETICO", SqlDbType.SmallInt).Value = IIf(ChDiabetico.Checked, 1, 0)
            cmd.Parameters.Add("@HIPERTENSO", SqlDbType.SmallInt).Value = IIf(ChHipertenso.Checked, 1, 0)
            cmd.Parameters.Add("@ALERGIAS", SqlDbType.VarChar).Value = TAlergias.Text
            cmd.Parameters.Add("@CVE_BANCO", SqlDbType.Int).Value = CVE_BANCO
            cmd.Parameters.Add("@APP_MOVIL", SqlDbType.VarChar).Value = IIf(chAplicacionMovil.Checked, 1, 0)
            cmd.Parameters.Add("@NUM_CUENTA", SqlDbType.VarChar).Value = TNUM_CUENTA.Text
            cmd.Parameters.Add("@CLABE", SqlDbType.VarChar).Value = TCLABE.Text
            cmd.Parameters.Add("@CVE_TIPO_OPER", SqlDbType.SmallInt).Value = CVE_TIPO_OPER
            cmd.Parameters.Add("@CVE_EDOCIVIL", SqlDbType.VarChar).Value = TCVE_EDOCIVIL.Text
            cmd.Parameters.Add("@FECHANAC", SqlDbType.Date).Value = FFECHA_NAC.Value
            cmd.Parameters.Add("@BENEFICIARIO", SqlDbType.VarChar).Value = TBeneficiario.Text
            cmd.Parameters.Add("@AVISAR_A", SqlDbType.VarChar).Value = TAVISAR_A.Text
            cmd.Parameters.Add("@CVE_PUESTO", SqlDbType.VarChar).Value = TCVE_PUESTO.Text
            cmd.Parameters.Add("@FACTO_SM_INFONAVIT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TFACTO_SM_INFONAVIT.Text)
            cmd.Parameters.Add("@FACTO_PORC_INFONAVIT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TFACTO_PORC_INFONAVIT.Text)
            cmd.Parameters.Add("@RET_DIARIA_INFONAVIT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TRET_DIARIA_INFONAVIT.Text)
            cmd.Parameters.Add("@RET_DIARIA_FONACOT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TRET_DIARIA_FONACOT.Text)
            cmd.Parameters.Add("@TRANSPORTADORA", SqlDbType.VarChar).Value = TTRANSPORTADORA.Text
            cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@CVE_TIPO_REG", SqlDbType.SmallInt).Value = CVE_TIPO_REG
            cmd.Parameters.Add("@CVE_DEPTO", SqlDbType.VarChar).Value = CVE_DEPTO
            cmd.Parameters.Add("@CVE_TIPO_CON", SqlDbType.SmallInt).Value = CVE_TIPO_CON
            cmd.Parameters.Add("@CVE_TIPO_JOR", SqlDbType.SmallInt).Value = CVE_TIPO_JOR
            cmd.Parameters.Add("@CVE_PER_PAGO", SqlDbType.SmallInt).Value = CVE_PER_PAGO
            cmd.Parameters.Add("@CVE_RIES_PUE", SqlDbType.SmallInt).Value = CVE_RIES_PUE
            cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = TCORREO1.Text
            cmd.Parameters.Add("@VL_SEN_CAR", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_CAR.Text)
            cmd.Parameters.Add("@VL_SEN_VAC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_VAC.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_CAR", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_CAR.Text)
            cmd.Parameters.Add("@VL_FULL_VAC_VAC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_VAC_VAC.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_VAC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_VAC.Text)
            cmd.Parameters.Add("@VL_SUE_SEM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SUE_SEM.Text)
            cmd.Parameters.Add("@VL_SUE_DIA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SUE_DIA.Text)
            cmd.Parameters.Add("@VL_SUE_DIA_INT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SUE_DIA_INT.Text)
            cmd.Parameters.Add("@VL_SEN_CAR_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_CAR_KM.Text)
            cmd.Parameters.Add("@VL_SEN_CAR_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_CAR_MI.Text)
            cmd.Parameters.Add("@VL_SEN_VAC_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_VAC_KM.Text)
            cmd.Parameters.Add("@VL_SEN_VAC_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_SEN_VAC_MI.Text)
            cmd.Parameters.Add("@VL_FULL_VAC_VAC_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_VAC_VAC_KM.Text)
            cmd.Parameters.Add("@VL_FULL_VAC_VAC_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_VAC_VAC_MI.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_CAR_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_CAR_KM.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_CAR_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_CAR_MI.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_VAC_KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_VAC_KM.Text)
            cmd.Parameters.Add("@VL_FULL_CAR_VAC_MI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVL_FULL_CAR_VAC_MI.Text)
            cmd.Parameters.Add("@CVE_CLASIFIC", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_CLASIFIC.Text)
            cmd.Parameters.Add("@MPRUEBA", SqlDbType.VarChar).Value = TCVE_ANT.Text
            cmd.Parameters.Add("@FECHA_ANTI", SqlDbType.Date).Value = FechaAnti.Value
            cmd.Parameters.Add("@RESPONSABLE", SqlDbType.VarChar).Value = TREGISTRO.Text
            cmd.Parameters.Add("@COCAINA", SqlDbType.VarChar).Value = TCOCAINA.Text
            cmd.Parameters.Add("@TETRA", SqlDbType.VarChar).Value = TTETRA.Text
            cmd.Parameters.Add("@ANFETAMINA", SqlDbType.VarChar).Value = TANFETAMINA.Text
            cmd.Parameters.Add("@MENTA", SqlDbType.VarChar).Value = TMETA.Text
            cmd.Parameters.Add("@OPIACEOS", SqlDbType.VarChar).Value = TOPIACEOS.Text
            cmd.Parameters.Add("@CVE_IMAGEN", SqlDbType.VarChar).Value = CVE_IMAGEN
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
            cmd.Parameters.Add("@NOMBRE_OPER", SqlDbType.VarChar).Value = TNOMBRE_OPER.Text
            cmd.Parameters.Add("@AP_PATERNO", SqlDbType.VarChar).Value = TAP_PATERNO.Text
            cmd.Parameters.Add("@AP_MATERNO", SqlDbType.VarChar).Value = TAP_MATERNO.Text
            cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = TMUNICIPIO.Text
            cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = TMUNICIPIO_SAT.Text
            cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = TCOLONIA_SAT.Text
            cmd.Parameters.Add("@CP_SAT", SqlDbType.VarChar).Value = TCP_SAT.Text
            cmd.Parameters.Add("@POBLACION_SAT", SqlDbType.VarChar).Value = TPOBLACION_SAT.Text
            cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = TESTADO_SAT.Text
            cmd.Parameters.Add("@REFRENDO_MEDICO", SqlDbType.Date).Value = FRM.Value

            cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = TPAIS.Text
            cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = TPAIS_SAT.Text
            cmd.Parameters.Add("@NUM_EXT", SqlDbType.VarChar).Value = TNUM_EXT.Text
            cmd.Parameters.Add("@CORREO_PER", SqlDbType.VarChar).Value = TCorreoPersonal.Text
            cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS_OPER
            cmd.Parameters.Add("@MOTIVO_BAJA", SqlDbType.VarChar).Value = MOTIVO_BAJA
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                Else
                    MsgBox("No se logro grabar el registro")
                End If

                If NewRecord Then
                    CLAVE = returnValue
                    TCLAVE.Text = CLAVE
                Else
                    CLAVE = TCLAVE.Text
                End If

                GRABA_VENC_DOC(CLAVE)
                GRABA_INICIDENCIAS(CLAVE)
                GRABA_FOTOS_DOC(CLAVE)
                GRABA_ANTIDOPING(CLAVE)

                If BtnActivo.Text = "Baja" And BtnActivo.Text <> BtnActivo.Tag Then
                    Try
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCOPERADOR SET USUARIO_BAJA = '" & USER_GRUPOCE & "' WHERE CLAVE = " & CInt(TCLAVE.Text)
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

                    GRABA_BITA(TCLAVE.Text, "", 0, "", TMOTIVO_BAJA.Text)
                End If

                MsgBox("El registro se grabo satisfactoriamente")
                Me.Close()
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GRABA_ANTIDOPING(fCLAVE As Long)

        Dim FOLIO As Long
        Dim FECHA As String
        Dim COCAINA As String
        Dim TETRAHIDROCANABINOL As String
        Dim ANFETAMINAS As String
        Dim METANFETAMINAS As String
        Dim OPIACEOS As String
        Dim METODPRUEBA As String
        Dim REGISTRO As String

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            SQL = "DELETE FROM GCANTIDOPING WHERE CLAVE = " & fCLAVE
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora("61. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        For k = 1 To FgA.Rows.Count - 1
            Try
                FOLIO = FgA(k, 1)
                REGISTRO = FgA(k, 2)
                FECHA = FgA(k, 3)
                COCAINA = FgA(k, 4)
                TETRAHIDROCANABINOL = FgA(k, 5)
                ANFETAMINAS = FgA(k, 6)
                METANFETAMINAS = FgA(k, 7)
                OPIACEOS = FgA(k, 8)
                METODPRUEBA = FgA(k, 9)

                SQL = "INSERT INTO GCANTIDOPING (CLAVE, FOLIO, REGISTRO, FECHA, COCAINA, TETRAHIDROCANABINOL, ANFETAMINAS, METANFETAMINAS, OPIACEOS, METODPRUEBA) VALUES('" &
                      fCLAVE & "','" & FOLIO & "','" & REGISTRO & "','" & FSQL(FECHA) & "','" & COCAINA & "','" & TETRAHIDROCANABINOL & "','" & ANFETAMINAS & "','" &
                      METANFETAMINAS & "','" & OPIACEOS & "','" & METODPRUEBA & "')"

                cmd.CommandText = SQL

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

    End Sub

    Sub GRABA_VENC_DOC(fCLAVE As Long)
        Dim DOC As String
        Dim NOMBRE As String
        Dim FECHA As String
        Dim CVE_VENDOC As Integer
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            SQL = "DELETE FROM GCVENC_DOC WHERE CLAVE = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        For k = 1 To FgDocVenc.Rows.Count - 1
            Try
                DOC = FgDocVenc(k, 1)
                NOMBRE = FgDocVenc(k, 2)
                FECHA = FgDocVenc(k, 3)
                CVE_VENDOC = FgDocVenc(k, 4)

                SQL = "INSERT INTO GCVENC_DOC (CLAVE, CVE_VENDOC, CVE_DOC, NOMBRE, FECHA_VENC)" &
                    " VALUES ('" & fCLAVE & "','" & CVE_VENDOC & "','" & DOC & "','" & NOMBRE & "','" & FSQL(FECHA) & "')"

                cmd.CommandText = SQL

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub

    Sub GRABA_INICIDENCIAS(fCLAVE As Long)

        Dim CREADO_POR As String
        Dim OBSER As String
        Dim FECHA As String
        Dim CVE_INCI As Integer
        Dim CVE_OBS As Long
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            SQL = "DELETE FROM GCINCIDENCIAS WHERE CLAVE = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora("61. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        For k = 1 To FgInc.Rows.Count - 1
            Try
                FECHA = FgInc(k, 1)
                CREADO_POR = FgInc(k, 2)
                OBSER = FgInc(k, 4)
                CVE_OBS = GRABA_OBSER(OBSER)
                CVE_INCI = FgInc(k, 5)

                SQL = "INSERT INTO GCINCIDENCIAS (CLAVE, CVE_INC, CVE_INCI, FECHA, CREADO_POR, CVE_OBS)" &
                    " VALUES ('" & fCLAVE & "','0','" & CVE_INCI & "','" & FSQL(FECHA) & "','" & CREADO_POR & "','" & CVE_OBS & "')"

                cmd.CommandText = SQL

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Sub GRABA_FOTOS_DOC(fCLAVE As Long)
        Dim DESCR As String
        Dim DOC As String
        Dim CVE_FOT As Integer

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'O'"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Bitacora("71. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("71. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        For k = 1 To FgFotDoc.Rows.Count - 1
            Try
                DESCR = FgFotDoc(k, 1)
                DOC = FgFotDoc(k, 2)
                CVE_FOT = FgFotDoc(k, 3)

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC)" &
                    " VALUES ('" & fCLAVE & "','" & CVE_FOT & "','" & DESCR & "','" & DOC & "','O')"

                cmd.CommandText = SQL

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub

    Private Sub BtnDepto_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Deptos"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()

            If Var4.Trim.Length > 0 Then
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("81. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("81. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BtnPago_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Formas de pago"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If

        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUnidad_Click(sender As Object, e As EventArgs)

        Try
            Var2 = "Unidades"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("83. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("83. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub BtnDocVencA_Click(sender As Object, e As EventArgs) Handles BtnDocVencA.Click
        Try
            If tDocVenc.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el documento")
                tDocVenc.Focus()
                Return
            End If
            If tNombreVenc.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el nombre del documento")
                Return
            End If

            FgDocVenc.AddItem("" & vbTab & tDocVenc.Text & vbTab & tNombreVenc.Text & vbTab & FDocVenc.Value & vbTab & "0")
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAgregarIncidencia_Click(sender As Object, e As EventArgs)

        Try


            If tObs_Inci.Text.Trim.Length = 0 Then
                MsgBox("por favor capture las observaciones de la incidencia")
                tObs_Inci.Focus()
                Return
            End If

            FgInc.AddItem("" & vbTab & FInci.Value & vbTab & Usuario_SAROCE & vbTab & LtInci.Text & vbTab & tObs_Inci.Text & tCVE_INC.Text)

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDocVencE_Click(sender As Object, e As EventArgs) Handles BtnDocVencE.Click

        Try

            If FgDocVenc.Row > 0 Then
                If MsgBox("Realmente desea eliminar el documento seleccionado?", vbYesNo) = vbYes Then
                    FgDocVenc.RemoveItem(FgDocVenc.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAgregarIncidencia_Click_1(sender As Object, e As EventArgs) Handles BtnAgregarIncidencia.Click
        Try
            If tObs_Inci.Text.Trim.Length = 0 Then
                MsgBox("Por favor captura las observaciones")
                Return
            End If

            FgInc.AddItem("" & vbTab & FInci.Value & vbTab & Usuario_SAROCE & vbTab & LtInci.Text & vbTab & tObs_Inci.Text & vbTab & tCVE_INC.Text & vbTab & "0")

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnFotoDoc_Click(sender As Object, e As EventArgs) Handles btnFotoDoc.Click

        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        'OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Todos los archivos|*.*"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Do things here, the path is stored in openFileDialog1.Filename
            'If no files were selected, openFileDialog1.Filename is ""  
            LtFotoDoc.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub BtnFotDocA_Click(sender As Object, e As EventArgs) Handles BtnFotDocA.Click
        Try
            If tDescrFotDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el documento")
                tDocVenc.Focus()
                Return
            End If
            If LtFotoDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            FgFotDoc.AddItem("" & vbTab & tDescrFotDoc.Text & vbTab & LtFotoDoc.Text & vbTab & "0")

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFotDocE_Click(sender As Object, e As EventArgs) Handles BtnFotDocE.Click
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
    Private Sub BtnEliminarIncidencia_Click(sender As Object, e As EventArgs) Handles BtnEliminarIncidencia.Click
        Try
            If FgInc.Row > 0 Then
                If MsgBox("Realmente desea eliminar la incidencia seleccionado?", vbYesNo) = vbYes Then
                    FgInc.RemoveItem(FgInc.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub


    Private Sub BtnPuesto_Click(sender As Object, e As EventArgs) Handles BtnPuesto.Click

        Try

            Var2 = "Puestos"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PUESTO.Text = Var4
                LtPuesto.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tFACTO_SM_INFONAVIT.Focus()
            End If


        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUniAsig_Click(sender As Object, e As EventArgs) Handles BtnUniAsig.Click
        Try
            Var2 = "Unidades"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TRACTOR.Text = Var4
                LtTractor.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_OBS.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_PUESTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PUESTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPuesto_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TRACTOR.KeyDown

        If e.KeyCode = Keys.F2 Then
            BtnUniAsig_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_PUESTO_Validated(sender As Object, e As EventArgs) Handles tCVE_PUESTO.Validated
        Try
            If tCVE_PUESTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Puesto", tCVE_PUESTO.Text)
                If DESCR <> "" Then
                    LtPuesto.Text = DESCR
                Else
                    MsgBox("Puesto inexistente")
                    tCVE_PUESTO.Text = ""
                    tCVE_PUESTO.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("84. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("84. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles tCVE_TRACTOR.Validated
        If tCVE_TRACTOR.Text.Trim.Length > 0 Then
            LtTractor.Text = BUSCA_CAT("Unidades", tCVE_TRACTOR.Text)
        End If
    End Sub

    Private Sub FrmOperadoresAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Movimientos a Operadores")
    End Sub

    Private Sub BtnIncidencias_Click(sender As Object, e As EventArgs) Handles BtnIncidencias.Click
        Try
            Var2 = "Incidencias"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_INC.Text = Var4
                LtInci.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                FInci.Focus()
            End If
        Catch ex As Exception
            Bitacora("115. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("115. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_INC_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_INC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnIncidencias_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_INC_Validated(sender As Object, e As EventArgs) Handles tCVE_INC.Validated
        Try
            If tCVE_INC.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Incidencias", tCVE_INC.Text)
                If DESCR <> "" Then
                    LtInci.Text = DESCR
                Else
                    MsgBox("Incidencia inexistente")
                    tCVE_INC.Text = ""
                    tCVE_INC.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCOCAINA_Validated(sender As Object, e As EventArgs) Handles tCOCAINA.Validated
        Try
            If tCOCAINA.Text.Trim.Length > 0 Then
                If tCOCAINA.Text <> "P" And tCOCAINA.Text <> "N" Then
                    MsgBox("Por favor seleccione P o N")
                    tCOCAINA.Text = ""
                    tCOCAINA.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBajaAnt_Click(sender As Object, e As EventArgs) Handles BtnBajaAnt.Click
        Try
            If fgA.Row > 0 Then
                If MsgBox("Realmente desea dar de baja el antidoping?", vbYesNo) = vbYes Then
                    If fgA.Row > 0 Then
                        fgA.RemoveItem(fgA.Row)
                        MsgBox("El antidoping de elimino satisfactoriamente")
                    End If
                End If
            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            Bitacora("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaAnt_Click(sender As Object, e As EventArgs) Handles BtnAltaAnt.Click
        Try

            If tCOCAINA.Text.Trim.Length = 0 And tTETRA.Text.Trim.Length = 0 And tANFETAMINA.Text.Trim.Length = 0 And
               tMETA.Text.Trim.Length = 0 And tOPIACEOS.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione al menos un tipo de droga")
                Return
            End If
            Dim FECHA As String

            Try
                Dim dt As DateTime = FechaAnti.Value
                FECHA = Format(dt.Day, "00") & "/" & Format(dt.Month, "00") & "/" & dt.Year
            Catch ex As Exception
                FECHA = Date.Now.Year & Format(Date.Now.Month, "00") & Format(Date.Now.Day, "00")
            End Try

            fgA.AddItem("" & vbTab & tCVE_ANT.Text & vbTab & tREGISTRO.Text & vbTab & FECHA & vbTab & tCOCAINA.Text & vbTab & tTETRA.Text & vbTab &
                           tANFETAMINA.Text & vbTab & tMETA.Text & vbTab & tOPIACEOS.Text & vbTab & cboMetodoPrueba.Text)

            tCOCAINA.Text = ""
            tTETRA.Text = ""
            tANFETAMINA.Text = ""
            tMETA.Text = ""
            tOPIACEOS.Text = ""

            tCVE_ANT.Text = GET_MAX("GCANTIDOPING", "FOLIO")

        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnImprimir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click
        Try

            If fgA.Row > 0 Then
                Dim FOLIO As Integer
                Dim RUTA_FORMATOS As String

                RUTA_FORMATOS = GET_RUTA_FORMATOS()
                If Not File.Exists(RUTA_FORMATOS & "\ReportAntidoping.mrt") Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportAntidoping.mrt, verifique por favor")
                    Return
                End If

                StiReport1.Load(RUTA_FORMATOS & "\ReportAntidoping.mrt")

                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()

                FOLIO = fgA(fgA.Row, 1)

                StiReport1.Item("CVE_OPER") = tCLAVE.Text
                StiReport1.Item("CVE_FOLIO") = FOLIO
                StiReport1.Render()
                StiReport1.Show()
                'StiReport1.Print(True)
            Else
                MsgBox("Por favor seleccione un folio")
            End If

        Catch ex As Exception
            Bitacora("301. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("301. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub FgA_Click(sender As Object, e As EventArgs) Handles fgA.Click

    End Sub
    Private Sub PicFoto_DoubleClick(sender As Object, e As EventArgs) Handles pic.DoubleClick
        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog With {
                .DefaultExt = "jpg",
                .FileName = "",
                .Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp|PNG|*.png",
                .Title = "Select file"
            }
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                pic.Tag = ofd.FileName

                AutosizeImage(ofd.FileName, pic)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        Try
            picFoto_DoubleClick(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnActivo_Click(sender As Object, e As EventArgs) Handles BtnActivo.Click
        Try
            Select Case BtnActivo.Text
                Case "Activo"
                    Lb1.Visible = False
                    Lb2.Visible = False
                    TMOTIVO_BAJA.Visible = False
                Case "Reactivado"
                    BtnActivo.Text = "Baja"
                    Lb1.Visible = True
                    Lb2.Visible = True
                    TMOTIVO_BAJA.Visible = True
                Case "Baja"
                    BtnActivo.Text = "Reactivado"
                    Lb1.Visible = True
                    Lb2.Visible = True
                    TMOTIVO_BAJA.Visible = True
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnLocalidad_Click(sender As Object, e As EventArgs) Handles BtnLocalidad.Click
        Try
            Prosec = "Localidad"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TPOBLACION_SAT.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TPOBLACION_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TPOBLACION_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLocalidad_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TPOBLACION_SAT_Validated(sender As Object, e As EventArgs) Handles TPOBLACION_SAT.Validated
        Dim doc As New XmlDocument()
        Try
            If TPOBLACION_SAT.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TPOBLACION_SAT.Text & "']")
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
                TESTADO_SAT.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TESTADO_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TESTADO_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEstado_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TESTADO_SAT_Validated(sender As Object, e As EventArgs) Handles TESTADO_SAT.Validated
        Dim doc As New XmlDocument()

        Try
            If TESTADO_SAT.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TESTADO_SAT.Text & "']")
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
                TPAIS_SAT.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPAIS_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TPAIS_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPais_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TPAIS_SAT_Validated(sender As Object, e As EventArgs) Handles TPAIS_SAT.Validated
        Dim doc As New XmlDocument()

        Try
            If TPAIS_SAT.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_PAIS.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Pais='" & TPAIS_SAT.Text & "']")
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

    Private Sub BtnMunicipio_Click(sender As Object, e As EventArgs) Handles BtnMunicipio.Click
        Try
            Prosec = "Municipio"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TMUNICIPIO_SAT.Text = Var10
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub TMUNICIPIO_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TMUNICIPIO_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMunicipio_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TMUNICIPIO_SAT_Validated(sender As Object, e As EventArgs) Handles TMUNICIPIO_SAT.Validated
        Dim doc As New XmlDocument()
        Try
            If TMUNICIPIO_SAT.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & TMUNICIPIO_SAT.Text & "']")
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
    Private Sub BtnCP_Click(sender As Object, e As EventArgs) Handles BtnCP.Click
        Try
            Prosec = "CP"
            Var4 = ""
            Var6 = TCP_SAT.Text
            Var7 = TPOBLACION_SAT.Text
            Var8 = TMUNICIPIO_SAT.Text
            Var9 = TESTADO_SAT.Text

            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCP_SAT.Text = Var4
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCP_SAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCP_SAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCP_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCP_SAT_Validated(sender As Object, e As EventArgs) Handles TCP_SAT.Validated
        Dim doc As New XmlDocument()
        Dim CP As String, x As Integer = 0

        Try
            If TCP_SAT.Text.Trim.Length > 0 Then
                If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml") Then
                    doc.Load(Application.StartupPath & "\CatalogosSat\CAT_CODIGO_POSTAL.xml")

                    Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TPOBLACION_SAT.Text & "' or @c_Municipio='" & TMUNICIPIO_SAT.Text & "' or @c_Estado='" & TESTADO_SAT.Text & "']")
                    If nodeList.Count = 0 Then
                        MsgBox("Codigo postal inexistente, verifique por favor")
                    Else
                        For Each node As XmlNode In nodeList
                            CP = node.Attributes("c_CodigoPostal").Value
                            If CP = TCP_SAT.Text Then
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
            Var6 = TCOLONIA_SAT.Text
            Var7 = TCP_SAT.Text
            FrmSelItemBinding.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCOLONIA_SAT.Text = Var4
            End If
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

    End Sub
    Private Sub FgFotDoc_DoubleClick(sender As Object, e As EventArgs) Handles FgFotDoc.DoubleClick

        Try
            If IO.File.Exists(FgFotDoc(FgFotDoc.Row, 2)) Then
                Process.Start(FgFotDoc(FgFotDoc.Row, 2))
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
End Class
