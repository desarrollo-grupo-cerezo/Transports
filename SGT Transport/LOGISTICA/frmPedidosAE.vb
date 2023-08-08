Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Input
Imports System.ComponentModel
Public Class FrmPedidosAE
    Private SERIE_PEDIDO As String
    Private DOCNEW As Boolean
    Private CP_VIRTUAL As String = ""
    Private EditPed As Boolean
    Private Entra As Boolean
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()
        CARGAR_DAOS2()

        Me.ResumeLayout()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmPedidosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub
    Private Sub FrmPedidosAE_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If Var1 = "Nuevo" Then
            TCVE_CON.Focus()
            TCVE_CON.Select()
        Else
            TCVE_OPER.Focus()
            TCVE_OPER.Select()
        End If


    End Sub

    Sub CARGAR_DATOS1()
        AssignValidation(Me.tCopias, ValidationType.Only_Numbers)
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BtnContrato.FlatStyle = FlatStyle.Flat
            BtnContrato.FlatAppearance.BorderSize = 0
            BtnTabRutaViajes.FlatStyle = FlatStyle.Flat
            BtnTabRutaViajes.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
            BtnCLAVE_REM.FlatAppearance.BorderSize = 0
            BtnPlaza.FlatStyle = FlatStyle.Flat
            BtnPlaza.FlatAppearance.BorderSize = 0
            BtnRecogerEn.FlatStyle = FlatStyle.Flat
            BtnRecogerEn.FlatAppearance.BorderSize = 0
            BtnProducto.FlatStyle = FlatStyle.Flat
            BtnProducto.FlatAppearance.BorderSize = 0
            BtnTractor.FlatStyle = FlatStyle.Flat
            BtnTractor.FlatAppearance.BorderSize = 0
            BtnTanque1.FlatStyle = FlatStyle.Flat
            BtnTanque1.FlatAppearance.BorderSize = 0
            BtnTanque2.FlatStyle = FlatStyle.Flat
            BtnTanque2.FlatAppearance.BorderSize = 0
            BtnCLAVE_DEST.FlatStyle = FlatStyle.Flat
            BtnCLAVE_DEST.FlatAppearance.BorderSize = 0
            BtnPlaza2.FlatStyle = FlatStyle.Flat
            BtnPlaza2.FlatAppearance.BorderSize = 0
            BtnEntregarEn.FlatStyle = FlatStyle.Flat
            BtnEntregarEn.FlatAppearance.BorderSize = 0
            BtnDesasignarCP1.FlatStyle = FlatStyle.Flat
            BtnDesasignarCP1.FlatAppearance.BorderSize = 0
            BtnDesasignarCP2.FlatStyle = FlatStyle.Flat
            BtnDesasignarCP2.FlatAppearance.BorderSize = 0
            BtnMas1.FlatStyle = FlatStyle.Flat
            BtnMas1.FlatAppearance.BorderSize = 0
            BtnMas2.FlatStyle = FlatStyle.Flat
            BtnMas2.FlatAppearance.BorderSize = 0

        Catch ex As Exception
        End Try
        Try
            F1.Value = Date.Today
            F1.Tag = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.Tag = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F2.EditFormat.CustomFormat = "dd/MM/yyyy"
            C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
            C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

            Me.CenterToScreen()
            Me.KeyPreview = True
            LtFecha.Text = Now

            BtnMas1.Left = BtnDesasignarCP1.Left
            BtnMas2.Left = BtnDesasignarCP2.Left


        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TCVE_OBS.Tag = "0"
            TCLAVE_O.Text = "" : TCLAVE_D.Text = "" : TCLAVE_O.Tag = "" : TCLAVE_D.Tag = "" : TCVE_RUTA.Text = "" : LtRuta1.Text = ""
            TRUTA_SEN_VAC.Text = "" : TRUTA_SE_CAR.Text = "" : TRUTA_FULL_VAC.Text = "" : TRUTAL_FULL_CAR.Text = "" : TNOTA.Text = ""
            TRECOGER_EN.Text = "" : TENTREGAR_EN.Text = "" : TValorDeclarado.Text = "" : TCVE_OBS.Text = ""
            Lt1.Text = "" : LtValorDeclarado.Text = "" : LtNombre1.Text = "" : LtNombre2.Text = "" : TCVE_ART.Text = ""

            AssignValidation(Me.TValorDeclarado, ValidationType.Only_Numbers)
            AssignValidation(Me.TCVE_ART, ValidationType.Only_Numbers)

            TCVE_TRACTOR.Text = ""
            TCVE_TANQUE1.Text = ""
            TCVE_TANQUE2.Text = ""

            TCVE_TRACTOR.Tag = ""
            TCVE_TANQUE1.Tag = ""
            TCVE_TANQUE2.Tag = ""

            LtTractor.Tag = " "
            LTanque1.Tag = " "
            LTanque2.Tag = " "

            TCVE_OPER.Tag = " "
            TCLAVE_O.Tag = " "
            TCLAVE_D.Tag = " "
            TRECOGER_EN.Tag = " "
            TENTREGAR_EN.Tag = " "

            SERIE_PEDIDO = ""
            EditPed = False
            Entra = True
            LtCartaPorte.Tag = ""
            LtCartaPorte2.Tag = ""

            LCartaPorte1.Tag = ""
            LCartaPorte2.Tag = ""

            LtCVE_DOC.Tag = ""
            LtStatus.Visible = False
        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        DERECHOS()

        BarEnlazarPedido.Visible = False

        DOCNEW = False
        If Var1 = "Nuevo" Then
            BarEnlazarPedido.Visible = True
            DOCNEW = True
            LtNewEdit.Text = "Nuevo"
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT ISNULL(SERIE_PEDIDOS,0) AS SER_PED FROM GCPARAMVENTAS"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    SERIE_PEDIDO = dr("SER_PED")
                End If
                dr.Close()
            Catch ex As Exception
                Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                BtnDesasignarCP1.Visible = False
                BtnDesasignarCP2.Visible = False

                LCartaPorte2.Visible = False
                LtCartaPorte2.Visible = False

                BtnMas1.Visible = True
                BtnMas2.Visible = False

                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_VENTA("P", SERIE_PEDIDO)

                If SERIE_PEDIDO = "" Or SERIE_PEDIDO = "STAND." Then
                    LtCVE_DOC.Text = Format(FOLIO_G, "0000000000")
                Else
                    LtCVE_DOC.Text = SERIE_PEDIDO & Format(FOLIO_G, "0000000000")
                End If

                LtCartaPorte.Text = SIGUIENTE_SERIE_CARTA_PORTE()

                LCartaPorte1.Tag = LtCartaPorte.Text
                LCartaPorte2.Tag = Var24 & Format(Var20 + 1, "0000000000")

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            LtNewEdit.Text = "Edit"
            BtnMas1.Visible = False
            BtnMas2.Visible = False
            BtnDesasignarCP1.Visible = True

            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_DOC, P.CVE_CLIE, ISNULL(P.CVE_CON,'') AS CVECON, ISNULL(P.STATUS,'C') AS ST, P.CVE_ART, ISNULL(I.DESCR,'') AS DESCR_PRODUCTO, 
                    ISNULL(P1.CIUDAD,'') AS DESCR_ORIGEN, ISNULL(P2.CIUDAD,'') AS DESCR_DESTINO, P.FECHA, P.CVE_ORIGEN, P.CVE_DESTINO, 
                    P.FECHA_CARGA, P.FECHA_DESCARGA, ISNULL(NOMBRE,'') AS NOMB, ISNULL(DOMICILIO,'') AS DIRE, ISNULL(RFC,'') AS RF, 
                    ISNULL(C.DOMICILIO2,'') AS MUNI, NUM_TALON, NUM_TALON2, P.CVE_CAP, P.CVE_OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, P.CVE_TANQUE2, 
                    ISNULL(P.CVE_OBS,0) AS CVEOBS, ISNULL(O.DESCR,'') AS OBS_DESCR, P.RECOGER_EN, P.ENTREGAR_EN, ISNULL(P.CLAVE_O,'') AS ORIGEN, 
                    ISNULL(P.CLAVE_D,'') AS DESTINO, P.LEYENDA, P.VALOR_DECLA, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_VIAJE, PEDIMENTO, P.CVE_TAB_VIAJE,
                    ISNULL((SELECT TOP 1 TIMBRADA FROM GCCARTA_PORTE WHERE CVE_DOCP = P.CVE_DOC AND ISNULL(TIMBRADA,'') = 'S'),'') AS TIMBRA,
                    ISNULL((SELECT TOP 1 CVE_DOCR FROM GCCARTA_PORTE WHERE CVE_FOLIO = P.NUM_TALON),'') AS REMA1,
                    ISNULL((SELECT TOP 1 CVE_DOCR FROM GCCARTA_PORTE WHERE CVE_FOLIO = P.NUM_TALON2),'') AS REMA2
                    FROM GCPEDIDOS P 
                    LEFT JOIN GCCLIE_OP C ON C.CLAVE = P.CVE_CLIE 
                    LEFT JOIN GCCONTRATO CT On CT.CVE_CON = P.CVE_CON 
                    LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = CT.CVE_ART 
                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN 
                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO 
                    LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS 
                    WHERE P.CVE_DOC = '" & Var2 & "'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    EditPed = True
                    LtCVE_DOC.Text = Var2

                    If dr("ST") = "C" Then
                        LtStatus.Visible = True
                        LtStatus.Text = "CANCELADO"
                    Else
                        If dr("TIMBRA") = "S" Then
                            LtStatus.Visible = True
                            LtStatus.Text = "TIMBRADA"

                        End If
                    End If

                    TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART").ToString
                    LtProducto.Text = BUSCA_CAT("Productos", TCVE_ART.Text)
                    Try
                        TLeyenda.Text = dr.ReadNullAsEmptyString("LEYENDA").ToString
                        TValorDeclarado.Text = dr.ReadNullAsEmptyString("VALOR_DECLA").ToString
                        'SQL = "SELECT E.CLAVE, E.IMPORTE, E.DESCR FROM GCVALOR_DECLARADO E WHERE E.STATUS = 'A' AND E.CLAVE = '" & fCLAVE & "'"
                        BUSCA_VALOR_DECLARADO(TValorDeclarado.Text)
                        Lt1.Text = Var5
                        If IsNumeric(Var6) Then
                            LtValorDeclarado.Text = Var6
                        End If

                        LtViaje.Text = dr.ReadNullAsEmptyString("CVE_VIAJE")

                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                        TEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                        TCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                        TPEDIMENTO.Text = dr.ReadNullAsEmptyString("PEDIMENTO")

                        TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB_VIAJE")
                    Catch ex As Exception
                        Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    LtFecha.Text = dr("FECHA").ToString

                    If IsDate(dr("FECHA_CARGA").ToString) Then
                        F1.Value = dr("FECHA_CARGA").ToString
                        F1.Tag = dr("FECHA_CARGA").ToString
                    Else
                        F1.Value = Date.Today
                        F1.Tag = Date.Today
                    End If

                    If IsDate(dr("FECHA_DESCARGA").ToString) Then
                        F2.Value = dr("FECHA_DESCARGA").ToString
                        F2.Tag = dr("FECHA_DESCARGA").ToString
                    Else
                        F2.Value = Date.Today
                        F2.Tag = Date.Today
                    End If

                    TCVE_CON.Text = dr.ReadNullAsEmptyString("CVECON")

                    TENTREGAR_EN.Text = dr.ReadNullAsEmptyString("ENTREGAR_EN")
                    TRECOGER_EN.Text = dr.ReadNullAsEmptyString("RECOGER_EN")
                    If TENTREGAR_EN.Text.Trim.Length > 0 Then
                        LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                    End If
                    If TENTREGAR_EN.Text.Trim.Length > 0 Then
                        LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                    End If

                    TCLAVE_O.Text = dr("ORIGEN")
                    TCLAVE_D.Text = dr("DESTINO")

                    DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text) 'GCCLIE_OP 
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 

                    If TCVE_CON.Text.Trim.Length > 0 Then
                        DESPLEGAR_CONTRATO2(TCVE_CON.Text)
                    End If
                    'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                    'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                    'Var6 = dr.ReadNullAsEmptyString("DES").ToString
                    'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                    'Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString
                    TCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                    LtTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                    TCVE_TANQUE1.Text = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                    LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                    TCVE_TANQUE2.Text = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString
                    LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If
                    TCVE_OPER.Text = dr.ReadNullAsEmptyString("CVE_OPER")
                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If
                    If TCVE_OPER.Text.Trim.Length > 0 Then
                        LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                    End If

                    LtTractor.Tag = TCVE_TRACTOR.Text
                    LTanque1.Tag = TCVE_TANQUE1.Text
                    LTanque2.Tag = TCVE_TANQUE2.Text

                    TCLAVE_O.Tag = TCLAVE_O.Text
                    TCLAVE_D.Tag = TCLAVE_D.Text
                    TRECOGER_EN.Tag = TRECOGER_EN.Text
                    TENTREGAR_EN.Tag = TENTREGAR_EN.Text
                    TCVE_OPER.Tag = TCVE_OPER.Text

                    Try
                        LtCartaPorte.Text = dr.ReadNullAsEmptyString("NUM_TALON")
                        LtCartaPorte2.Text = dr.ReadNullAsEmptyString("NUM_TALON2")
                        LCartaPorte1.Tag = LtCartaPorte.Text
                        LCartaPorte2.Tag = LtCartaPorte2.Text
                        LtREMA1.Text = IIf(dr.ReadNullAsEmptyString("REMA1") = "0", "", dr.ReadNullAsEmptyString("REMA1"))
                        LtREMA2.Text = IIf(dr.ReadNullAsEmptyString("REMA2") = "0", "", dr.ReadNullAsEmptyString("REMA2"))

                        If LtREMA1.Text.Trim.Length = 0 Then
                            LtREMA1.Visible = False
                        End If
                        If LtREMA2.Text.Trim.Length = 0 Then
                            LtREMA2.Visible = False
                        End If
                    Catch ex As Exception
                    End Try


                    If LtViaje.Text.Trim.Length > 0 Then
                        BtnDesasignarCP1.Visible = False
                        BtnDesasignarCP2.Visible = False
                    Else
                        If LtCartaPorte.Text.Trim.Length = 0 Then
                            BtnDesasignarCP1.Visible = False
                        End If
                        If LtCartaPorte2.Text.Trim.Length = 0 Then
                            BtnDesasignarCP2.Visible = False
                        End If
                    End If

                    TCVE_OBS.Tag = dr("CVEOBS")
                    TCVE_OBS.Text = dr("OBS_DESCR")
                    If TCVE_OBS.Text = "0" Then
                        TCVE_OBS.Text = ""
                    End If
                End If
                dr.Close()

            Catch ex As Exception
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub DESPLEGAR_CONTRATO2(fCVE_CON As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_CON, C.CONTRATO_CLIENTE, C.CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR, 
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER, 
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, C.CLAVE_O, C.CLAVE_D, C.CVE_ORIGEN, C.CVE_DESTINO, C.RECOGER_EN, C.ENTREGAR_EN, 
                    C.CVE_PROV, C.CVE_MAT, ISNULL(C.VALOR_DECLA,0) AS DECLA, C.CVE_ART, C.LEYENDA, ISNULL(C.IMPR_TALON,0) AS IMPR, ISNULL(C.CVE_OBS,0) AS CVEOBS, 
                    ISNULL(O.DESCR,'') AS OBS_DESCR, C.CVE_TAB_VIAJE, R.CVE_TAB
                    FROM GCCONTRATO C 
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                    WHERE C.CVE_CON = '" & fCVE_CON & "' AND C.STATUS = 'A' "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCONTRATO_CLIENTE.Text = dr("NO_CONTRATO").ToString
                        LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)

                        TCVE_OBS_CON.Text = dr("OBS_DESCR")

                        TRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                        TRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                        TRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                        TRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                        TNOTA.Text = dr("NOTA").ToString
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_DAOS2()
        TCVE_CON.Enabled = True
        BtnContrato.Enabled = True
        TCVE_OBS.Enabled = True
        TCVE_OBS_CON.Enabled = False

        'var3 VIAJE ASIGNADO
        If Var3.Trim.Length > 0 Then
            'var3 VIAJE ASIGNADO
            Try
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                'SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                'SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                TCLAVE_O.Enabled = False
                BtnCLAVE_REM.Enabled = False
                TCVE_PLAZA.Enabled = False
                BtnPlaza.Enabled = False
                TRECOGER_EN.Enabled = False
                BtnRecogerEn.Enabled = False

                TCLAVE_D.Enabled = False
                BtnCLAVE_DEST.Enabled = False
                tCVE_PLAZA2.Enabled = False
                tCVE_PLAZA2.Enabled = False
                TENTREGAR_EN.Enabled = False


                SET_ALL_CONTROL_READ_AND_ENABLED(Box3)

                TENTREGAR_EN.Enabled = False
                TRECOGER_EN.Enabled = False
                TCVE_OPER.Enabled = False
                TCVE_TRACTOR.Enabled = False
                TCVE_TANQUE1.Enabled = False
                TCVE_TANQUE2.Enabled = False

                TCVE_ART.Enabled = False
                TLeyenda.Enabled = False
                TEMBARQUE.Enabled = False
                TValorDeclarado.Enabled = False
                TCARGA_ANTERIOR.Enabled = False
                TPEDIMENTO.Enabled = False

            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If LtStatus.Text = "CANCELADO" Or LtStatus.Text = "TIMBRADA" Then
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
            SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
            SET_ALL_CONTROL_READ_AND_ENABLED(Box3)
            TPEDIMENTO.Enabled = False

            TENTREGAR_EN.Enabled = False
            TRECOGER_EN.Enabled = False
            TCVE_OPER.Enabled = False
            TCVE_TRACTOR.Enabled = False
            TCVE_TANQUE1.Enabled = False
            TCVE_TANQUE2.Enabled = False
            TCVE_OBS.Enabled = False

            BarCancelar.Visible = False
            BarCartaPorteVirtual.Enabled = False

            If LtStatus.Text = "TIMBRADA" Then
                BarGrabar.Visible = True

            Else
                BarGrabar.Visible = False
            End If

            'If LtREMA1.Text.Trim.Length > 0 Or LtREMA2.Text.Trim.Length > 0 Then
            'tORDEN_DE.Enabled = False
            'Else
            TORDEN_DE.Enabled = True
            'End If
        Else
            'If LtREMA1.Text.Trim.Length > 0 Or LtREMA2.Text.Trim.Length > 0 Then
            'tORDEN_DE.Enabled = False
            'Else
            TORDEN_DE.Enabled = True
            'End If
        End If


    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarGrabar.Visible = False
                BarImprimir.Visible = False
                BarCancelar.Visible = False
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
                TPEDIMENTO.Enabled = False

            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                      (CLAVE >= 24000 AND CLAVE < 24600 OR CLAVE >= 244000 AND CLAVE < 244200)"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 24050 'GRABAR 
                                    BarGrabar.Visible = True
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp1, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp2, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp3, True)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp4, True)
                                    TPEDIMENTO.Enabled = True
                                Case 24052 'GRABAR 
                                    BarCancelar.Visible = True
                                Case 24075 'IMPIRMIR CARTA PORTE
                                    BarImprimir.Visible = True
                                Case 244060 'GENERALES
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp3)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Gp4)
                                    TPEDIMENTO.Enabled = False
                                Case 244080 'DATOS DE LA BITACORA
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box2)
                                Case 244100 'OBSERVACIONES PEDIDO
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box3)
                                Case 244120 'INSTRUCCIONES DE VIAJE
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box4)
                                    TPEDIMENTO.Enabled = False
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
    Private Sub FrmPedidosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmPedidosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) And Entra Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        If LtStatus.Text = "TIMBRADA" Or LtViaje.Text.Trim.Length > 0 Then
            GRABAR_DATOS_ESPECIFICOS()
        Else
            GRABAR_PEDIDO()
        End If
    End Sub
    Sub GRABAR_DATOS_ESPECIFICOS()
        Try
            If LtStatus.Text = "TIMBRADA" Then
                SQL = "UPDATE GCPEDIDOS SET ORDEN_DE = @ORDEN_DE WHERE CVE_DOC = @CVE_DOC "

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Else
                SQL = "UPDATE GCPEDIDOS SET ORDEN_DE = @ORDEN_DE, FECHA_CARGA = @FECHA_CARGA, 
                    FECHA_DESCARGA = @FECHA_DESCARGA WHERE CVE_DOC = @CVE_DOC"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
                    cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                    cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If LtStatus.Text = "TIMBRADA" Then
                If LtCartaPorte.Text.Trim.Length > 0 And LtCartaPorte2.Text.Trim.Length > 0 Then
                    SQL = "UPDATE GCCARTA_PORTE SET ORDEN_DE = @ORDEN_DE
                        WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "' OR CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                Else
                    SQL = "UPDATE GCCARTA_PORTE SET ORDEN_DE = @ORDEN_DE
                        WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                End If
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Else
                If LtCartaPorte.Text.Trim.Length > 0 And LtCartaPorte2.Text.Trim.Length > 0 Then
                    SQL = "UPDATE GCCARTA_PORTE SET ORDEN_DE = @ORDEN_DE, FECHA_CARGA = @FECHA_CARGA, 
                        FECHA_DESCARGA = @FECHA_DESCARGA
                        WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "' OR CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                Else
                    SQL = "UPDATE GCCARTA_PORTE SET ORDEN_DE = @ORDEN_DE, FECHA_CARGA = @FECHA_CARGA, 
                        FECHA_DESCARGA = @FECHA_DESCARGA
                        WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                End If
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = LtCVE_DOC.Text
                    cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                    cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_PEDIDO()
        Dim CVE_DOC As String, CVE_OBS As Long, FOLIO_ASIGNADO As Boolean, FOLIO_PEDIDO As Long, Sigue As Boolean, nCopias As Integer
        Dim FOLIO_CARTA_PORTE_GRABA As String, FOLIO_CARTA_PORTE As String = "", FOLIO_CARTA_PORTE2 As String = "", TIPO_UNI As Integer
        Dim nCopiasCp As Integer = 0, z As Integer = 0, CVE_DOC2 As String = ""
        Dim SQL1 As String, ReAsignarCp As Boolean = False
        Dim cmd As New SqlCommand

        'If tCVE_CON.Text.Trim.Length = 0 Then
        'MsgBox("La clave del contrato no debe quedar vacia")
        'tCVE_CON.Select()
        'Return
        'End If
        TLeyenda.Select()

        If LtCartaPorte.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Or LtCartaPorte2.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Then
            ReAsignarCp = True
        End If

        If LtCartaPorte.Tag = "DESASIGNAR CARTA PORTE" Or LtCartaPorte2.Tag = "DESASIGNAR CARTA PORTE" Then
            ReAsignarCp = True
        End If

        If LtCVE_DOC.Text.Trim.Length = 0 Then
            EditPed = False
        End If
        If IsNumeric(tCopias.Text) Then
            nCopias = tCopias.Text
        Else
            nCopias = 0
        End If
        If nCopias < 0 And nCopias > 20 Then
            MsgBox("el número de copias no debe meno a cero o exceder a 10, verifique por favor")
            Return
        End If
        Try
            If TCVE_OBS.Text.Trim.Length > 0 Then
                CVE_OBS = Val(TCVE_OBS.Tag.ToString)
                CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TCVE_OBS.Text)
            Else
                CVE_OBS = 0
            End If
        Catch ex As Exception
            Bitacora("39. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If Not EditPed Then
            'ALTA ES UN PEDIDO NUEVO          ALTA ES UN PEDIDO NUEVO
            CVE_DOC = ""
            Try
                Sigue = True
                FOLIO_ASIGNADO = False
                FOLIO_PEDIDO = SIGUIENTE_FOLIO_VENTA("P", SERIE_PEDIDO.ToString)
                Do While Sigue
                    If SERIE_PEDIDO.ToString.Trim.Length = 0 Or SERIE_PEDIDO.ToString = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_PEDIDO, "0000000000")
                    Else
                        CVE_DOC = SERIE_PEDIDO & Format(FOLIO_PEDIDO, "0000000000")
                    End If
                    If EXISTE_PEDIDO(CVE_DOC) Then
                        FOLIO_PEDIDO += 1
                        FOLIO_ASIGNADO = True
                    Else
                        Sigue = False
                    End If
                Loop
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If LtTipoViaje.Text = "Full" Then
                nCopiasCp = 2
                TIPO_UNI = 1
            Else
                nCopiasCp = 1
                TIPO_UNI = 0
            End If
        Else
            'NO  NO  NO  NO ES ALTA ES EDIT    EDIT ENDEJO
            CVE_DOC = LtCVE_DOC.Text
            nCopias = 0
        End If

        If DOCNEW Then
            SQL1 = "INSERT INTO GCPEDIDOS (CVE_DOC, CVE_CON, STATUS, FECHA, FECHA_CARGA, FECHA_DESCARGA, FECHAELAB, UUID, NUM_TALON, NUM_TALON2, CVE_OPER, 
                CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2,CVE_OBS, ENTREGAR_EN, RECOGER_EN, CLAVE_O, CLAVE_D, CVE_PLAZA1, CVE_PLAZA2, CVE_ART, VALOR_DECLA, 
                LEYENDA, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, PEDIMENTO, PED_ENLAZADO, CVE_TAB_VIAJE) VALUES (@CVE_DOC, @CVE_CON, 'A', @FECHA, @FECHA_CARGA, 
                @FECHA_DESCARGA, GETDATE(), NEWID(), @NUM_TALON, @NUM_TALON2, @CVE_OPER, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_OBS, @ENTREGAR_EN, 
                @RECOGER_EN, @CLAVE_O, @CLAVE_D, @CVE_PLAZA1, @CVE_PLAZA2, @CVE_ART, @VALOR_DECLA, @LEYENDA, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR,
                @PEDIMENTO, @PED_ENLAZADO, @CVE_TAB_VIAJE)"
        Else
            SQL1 = "UPDATE GCPEDIDOS SET NUM_TALON = @NUM_TALON, NUM_TALON2 = @NUM_TALON2, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, 
                CVE_CON = @CVE_CON, CVE_OBS = @CVE_OBS, CVE_OPER = @CVE_OPER, CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, 
                CVE_TANQUE2 = @CVE_TANQUE2, ENTREGAR_EN = @ENTREGAR_EN, RECOGER_EN = @RECOGER_EN, CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, 
                CVE_PLAZA1 = @CVE_PLAZA1, CVE_PLAZA2 = @CVE_PLAZA2, CVE_ART = @CVE_ART, VALOR_DECLA = @VALOR_DECLA, LEYENDA = @LEYENDA, 
                ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, PEDIMENTO = @PEDIMENTO, CVE_TAB_VIAJE = @CVE_TAB_VIAJE
                WHERE CVE_DOC = @CVE_DOC "
        End If
        cmd.CommandText = SQL1

        'CREACION DE COPIAS DE PEDIDOS SI TAMBIEN SON COPIAS DE LOS PEDIDOS
        'COPIAS DE PEDIDOS          Y CARTAS PORTE
        For k = 0 To nCopias
            Try
                If Not EditPed Then
                    'ALTA ES UN PEDIDO NUEVO          ALTA ES UN PEDIDO NUEVO
                    If ReAsignarCp Then
                        If LtCartaPorte.Text.ToString.Trim.Length > 0 Then
                            FOLIO_CARTA_PORTE = LCartaPorte1.Tag
                        Else
                            FOLIO_CARTA_PORTE = ""
                        End If
                        If LtTipoViaje.Text = "Full" Then
                            If LtCartaPorte2.Text.ToString.Trim.Length > 0 Then
                                FOLIO_CARTA_PORTE2 = LCartaPorte2.Tag
                            End If
                        Else
                            FOLIO_CARTA_PORTE2 = ""
                        End If
                        nCopias = 0
                    Else
                        If CP_VIRTUAL = "VIRTUAL" Then
                            FOLIO_CARTA_PORTE = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
                        Else
                            FOLIO_CARTA_PORTE = SIGUIENTE_SERIE_CARTA_PORTE()
                        End If

                        If LtTipoViaje.Text = "Full" Then
                            'Var24 = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE")
                            'Var20 = dr.ReadNullAsEmptyDecimal("ULT_DOC_CARTA_PORTE") + 1
                            FOLIO_CARTA_PORTE2 = Var24 & Format(Var20 + 1, "0000000000")
                        Else
                            FOLIO_CARTA_PORTE2 = ""
                        End If
                    End If
                Else
                    If LtTipoViaje.Text = "Full" Then
                        If ReAsignarCp Then
                            nCopiasCp = 0
                        Else
                            If LtCartaPorte.Text.Trim.Length > 0 And LtCartaPorte2.Text.Trim.Length = 0 Then

                                If CP_VIRTUAL = "VIRTUAL" Then
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
                                Else
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE()
                                End If

                                FOLIO_CARTA_PORTE2 = Var24 & Format(Var20, "0000000000")

                                LtCartaPorte2.Text = FOLIO_CARTA_PORTE2
                                LCartaPorte2.Tag = FOLIO_CARTA_PORTE2
                                nCopiasCp = 1
                            Else
                                nCopiasCp = 0
                                FOLIO_CARTA_PORTE2 = LtCartaPorte2.Text
                            End If
                        End If
                    Else
                        nCopiasCp = 0
                    End If

                    If ReAsignarCp Then
                        FOLIO_CARTA_PORTE = LtCartaPorte.Text
                        FOLIO_CARTA_PORTE2 = LtCartaPorte2.Text
                    Else
                        FOLIO_CARTA_PORTE = LtCartaPorte.Text
                    End If
                    Try
                        'CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO
                        If LtCartaPorte.Tag = "DESASIGNAR CARTA PORTE" Then
                            If LCartaPorte1.Tag.ToString.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '' WHERE CVE_FOLIO = '" & LCartaPorte1.Tag.ToString & "'"
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
                        Bitacora("40.1. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("40.1. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If LtCartaPorte2.Tag = "DESASIGNAR CARTA PORTE" Then
                            If LCartaPorte2.Tag.ToString.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '' WHERE CVE_FOLIO = '" & LCartaPorte2.Tag.ToString & "'"
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
                        Bitacora("40.1. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("40.1. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End If
            Catch ex As Exception
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If Not EditPed Then
                'ALTA ES UN PEDIDO NUEVO          ALTA ES UN PEDIDO NUEVO
                '
                'CREACION DE NUEVA CARTA PORTE
                FOLIO_CARTA_PORTE_GRABA = FOLIO_CARTA_PORTE



                If Not ReAsignarCp Then
                    For i = 1 To nCopiasCp 'CUANDO ES FULL CREA 2 CARTAS PORTE
                        Try
                            SQL1 = "INSERT INTO GCCARTA_PORTE (CVE_CAP, CVE_FOLIO, CVE_VIAJE, CVE_DOCP, CLIENTE, FECHA_DOC, FECHA_CARGA, 
                                FECHA_DESCARGA, STATUS, CVE_COBRO, TIPO_UNI, TIPO_VIAJE, CVE_OPER, CLAVE_O, CLAVE_D, CVE_TRACTOR, CVE_TANQUE1, 
                                CVE_TANQUE2, CVE_DOLLY, RECOGER_EN, ENTREGAR_EN, CVE_PLAZA1, CVE_PLAZA2, REM_CARGA1, PESO_BRUTO1, TARA1, REM_CARGA2, 
                                PESO_BRUTO2, TARA2, REM_CARGA3, PESO_BRUTO3, TARA3, REM_CARGA4, PESO_BRUTO4, TARA4, CVE_ART, FLETE, SUBTOTAL, IVA, 
                                RETENCION, NETO, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_TAB_VIAJE, CVE_CON, CVE_OBSP, CP_VIRTUAL, FECHAELAB, UUID) 
                                VALUES (
                                ISNULL((SELECT ISNULL(MAX(CVE_CAP),0) + 1 FROM  GCCARTA_PORTE),1), 
                                @CVE_FOLIO, @CVE_VIAJE, @CVE_DOCP, @CLIENTE, @FECHA_DOC, @FECHA_CARGA, @FECHA_DESCARGA, 'A', @CVE_COBRO, @TIPO_UNI, 
                                @TIPO_VIAJE, @CVE_OPER, @CLAVE_O, @CLAVE_D, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, @RECOGER_EN, 
                                @ENTREGAR_EN, @CVE_PLAZA1, @CVE_PLAZA2, @REM_CARGA1, @PESO_BRUTO1, @TARA1, @REM_CARGA2, @PESO_BRUTO2, @TARA2, 
                                @REM_CARGA3, @PESO_BRUTO3, @TARA3, @REM_CARGA4, @PESO_BRUTO4, @TARA4, @CVE_ART, @FLETE, @SUBTOTAL, @IVA, @RETENCION, 
                                @NETO, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, @CVE_TAB_VIAJE, @CVE_CON, @CVE_OBSP, @CP_VIRTUAL, GETDATE(), NEWID())"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL1
                                For z = 1 To 3
                                    Try
                                        cmd2.Parameters.Clear()
                                        cmd2.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE_GRABA
                                        cmd2.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = CVE_DOC
                                        cmd2.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = Now
                                        cmd2.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                                        cmd2.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                                        cmd2.Parameters.Add("@CVE_COBRO", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = 0           'FULL SENCILLO
                                        cmd2.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = TIPO_UNI  'CARGADO VACIO
                                        cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                        cmd2.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                                        cmd2.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                                        cmd2.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                                        cmd2.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                                        cmd2.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                                        cmd2.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                                        cmd2.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                                        cmd2.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = TCVE_PLAZA.Text
                                        cmd2.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = tCVE_PLAZA2.Text
                                        cmd2.Parameters.Add("@REM_CARGA1", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@PESO_BRUTO1", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@TARA1", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@REM_CARGA2", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@PESO_BRUTO2", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@TARA2", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@REM_CARGA3", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@PESO_BRUTO3", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@TARA3", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@REM_CARGA4", SqlDbType.VarChar).Value = ""
                                        cmd2.Parameters.Add("@PESO_BRUTO4", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@TARA4", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                                        cmd2.Parameters.Add("@FLETE", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@IVA", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@RETENCION", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@NETO", SqlDbType.Float).Value = 0
                                        cmd2.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                                        cmd2.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                                        cmd2.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                                        cmd2.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                                        cmd2.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                                        cmd2.Parameters.Add("@CVE_OBSP", SqlDbType.Int).Value = CVE_OBS
                                        cmd2.Parameters.Add("@CP_VIRTUAL", SqlDbType.Int).Value = IIf(CP_VIRTUAL = "VIRTUAL", 1, 0)
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                Try
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        If CP_VIRTUAL = "VIRTUAL" Then
                                                            SQL = "UPDATE GCPARAMTRANSCG SET ULT_DOC_CARTA_PORTE_VIRTUAL = " & Var20
                                                        Else
                                                            SQL = "UPDATE GCPARAMTRANSCG SET ULT_DOC_CARTA_PORTE = " & Var20
                                                        End If
                                                        cmd3.CommandText = SQL
                                                        returnValue2 = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue2 = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try

                                                Exit For

                                            End If
                                        End If
                                    Catch ex As Exception
                                        Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    'NUEVO FOLIO CARTA PORTE X QUE YA EXISTE UNA
                                    Var20 += 1
                                    FOLIO_CARTA_PORTE = Var24 & Format(Var20, "0000000000")
                                    LtCartaPorte.Text = FOLIO_CARTA_PORTE
                                    FOLIO_CARTA_PORTE_GRABA = FOLIO_CARTA_PORTE
                                Next 'FOR PARA VERIFICAR QUE SE GRABO CORRECTAMENTE LA CARTA PORTE
                                '██████████████████████████████████████████████████████████████████████
                            End Using
                            '              ALTA CARTA PORTE              ALTA CARTA PORTE              ALTA CARTA PORTE
                            '              ALTA CARTA PORTE              ALTA CARTA PORTE              ALTA CARTA PORTE

                            'SIGUIENTE CARTA PORTE
                            If LtCartaPorte2.Text.Trim.Length > 0 And i <> nCopiasCp Then
                                If CP_VIRTUAL = "VIRTUAL" Then
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
                                Else
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE()
                                End If
                                FOLIO_CARTA_PORTE2 = Var24 & Format(Var20, "0000000000")
                                LtCartaPorte2.Text = FOLIO_CARTA_PORTE2
                                FOLIO_CARTA_PORTE_GRABA = FOLIO_CARTA_PORTE2
                            End If

                        Catch ex As Exception
                            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Next
                Else
                    Try
                        '
                        If LtCartaPorte.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Then

                            If LtCartaPorte.Text.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '" & CVE_DOC & "' WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            LtCartaPorte.Tag = ""
                                        End If
                                    End If
                                End Using
                            End If
                        End If
                        If LtCartaPorte2.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Then
                            If LtCartaPorte2.Text.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '" & CVE_DOC & "' WHERE CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            LtCartaPorte2.Tag = ""
                                        End If
                                    End If
                                End Using
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else

                'SI ES EDICION PERO SE GRABARA LA SEGUNDA CARTA PORTE PORQUE AHORA ES FULL
                For i = 1 To nCopiasCp
                    Try
                        SQL1 = "INSERT INTO GCCARTA_PORTE (CVE_CAP, CVE_FOLIO, CVE_VIAJE, CVE_DOCP, CLIENTE, FECHA_DOC, FECHA_CARGA, 
                            FECHA_DESCARGA, STATUS, CVE_COBRO, TIPO_UNI, TIPO_VIAJE, CVE_OPER, CLAVE_O, CLAVE_D, CVE_TRACTOR, CVE_TANQUE1, 
                            CVE_TANQUE2, CVE_DOLLY, RECOGER_EN, ENTREGAR_EN, CVE_PLAZA1, CVE_PLAZA2, REM_CARGA1, PESO_BRUTO1, TARA1, REM_CARGA2, 
                            PESO_BRUTO2, TARA2, REM_CARGA3, PESO_BRUTO3, TARA3, REM_CARGA4, PESO_BRUTO4, TARA4, CVE_ART, FLETE, SUBTOTAL, IVA, 
                            RETENCION, NETO, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_TAB_VIAJE, CVE_CON, CVE_OBSP, FECHAELAB, UUID) VALUES 
                            (ISNULL((SELECT ISNULL(MAX(CVE_CAP),0) + 1 FROM  GCCARTA_PORTE),1), 
                            @CVE_FOLIO, @CVE_VIAJE, @CVE_DOCP, @CLIENTE, @FECHA_DOC, @FECHA_CARGA, @FECHA_DESCARGA, 'A', @CVE_COBRO, 
                            @TIPO_UNI, @TIPO_VIAJE, @CVE_OPER, @CLAVE_O, @CLAVE_D, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, 
                            @RECOGER_EN, @ENTREGAR_EN, @CVE_PLAZA1, @CVE_PLAZA2, @REM_CARGA1, @PESO_BRUTO1, @TARA1, @REM_CARGA2, @PESO_BRUTO2, 
                            @TARA2, @REM_CARGA3, @PESO_BRUTO3, @TARA3, @REM_CARGA4, @PESO_BRUTO4, @TARA4, @CVE_ART, @FLETE, @SUBTOTAL, @IVA, 
                            @RETENCION, @NETO, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, @CVE_TAB_VIAJE, @CVE_CON, @CVE_OBSP, GETDATE(), NEWID())"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL1
                            For z = 1 To 3
                                Try
                                    cmd2.Parameters.Clear()
                                    cmd2.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE2
                                    cmd2.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = CVE_DOC
                                    cmd2.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = Now
                                    cmd2.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                                    cmd2.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                                    cmd2.Parameters.Add("@CVE_COBRO", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = 0           'FULL SENCILLO
                                    cmd2.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = TIPO_UNI  'CARGADO VACIO
                                    cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                    cmd2.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                                    cmd2.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                                    cmd2.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                                    cmd2.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                                    cmd2.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                                    cmd2.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                                    cmd2.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                                    cmd2.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = TCVE_PLAZA.Text
                                    cmd2.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = tCVE_PLAZA2.Text
                                    cmd2.Parameters.Add("@REM_CARGA1", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@PESO_BRUTO1", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@TARA1", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@REM_CARGA2", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@PESO_BRUTO2", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@TARA2", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@REM_CARGA3", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@PESO_BRUTO3", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@TARA3", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@REM_CARGA4", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@PESO_BRUTO4", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@TARA4", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                                    cmd2.Parameters.Add("@FLETE", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@IVA", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@RETENCION", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@NETO", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                                    cmd2.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                                    cmd2.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                                    cmd2.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                                    cmd2.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                                    cmd2.Parameters.Add("@CVE_OBSP", SqlDbType.Int).Value = CVE_OBS
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            Try
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    If CP_VIRTUAL = "VIRTUAL" Then
                                                        SQL = "UPDATE GCPARAMTRANSCG SET ULT_DOC_CARTA_PORTE_VIRTUAL = " & (Var20 + 1)
                                                    Else
                                                        SQL = "UPDATE GCPARAMTRANSCG SET ULT_DOC_CARTA_PORTE = " & (Var20 + 1)
                                                    End If

                                                    cmd3.CommandText = SQL
                                                    returnValue2 = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue2 = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try

                                            Exit For

                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                If CP_VIRTUAL = "VIRTUAL" Then
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
                                Else
                                    FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE()
                                End If

                                Var20 += 1
                                FOLIO_CARTA_PORTE2 = Var24 & Format(Var20, "0000000000")
                                LtCartaPorte2.Text = FOLIO_CARTA_PORTE2
                            Next 'FOR PARA VERIFICAR QUE SE GRABO CORRECTAMENTE LA CARTA PORTE
                            '██████████████████████████████████████████████████████████████████████
                        End Using
                        'SIGUIENTE CARTA PORTE



                        If LtCartaPorte2.Text.Trim.Length > 0 And i <> nCopiasCp Then

                            If CP_VIRTUAL = "VIRTUAL" Then
                                FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
                            Else
                                FOLIO_CARTA_PORTE2 = SIGUIENTE_SERIE_CARTA_PORTE()
                            End If

                            FOLIO_CARTA_PORTE2 = Var24 & Format(Var20 + 1, "0000000000")
                            LtCartaPorte2.Text = FOLIO_CARTA_PORTE2
                            FOLIO_CARTA_PORTE_GRABA = FOLIO_CARTA_PORTE2
                        End If
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next '================ FIN CARTA PORTE 2 

                Try
                    '
                    If LtCartaPorte.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Then

                        If LtCartaPorte.Text.Trim.Length > 0 Then
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '" & CVE_DOC & "' WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        LtCartaPorte.Tag = ""
                                    End If
                                End If
                            End Using
                        End If
                    End If
                    If LtCartaPorte2.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO" Then
                        If LtCartaPorte2.Text.Trim.Length > 0 Then
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '" & CVE_DOC & "' WHERE CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        LtCartaPorte2.Tag = ""
                                    End If
                                End If
                            End Using
                        End If
                    End If

                Catch ex As Exception
                    Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If

            CVE_DOC2 = CVE_DOC

            'TERMINA ALTA DE CARTAS PORTE                    TERMINA ALTA DE CARTAS PORTE
            'TERMINA ALTA DE CARTAS PORTE                    TERMINA ALTA DE CARTAS PORTE

            Try
                'EMPIEZA ALTA DEL PEDIDO              EMPIEZA ALTA DEL PEDIDO
                'EMPIEZA ALTA DEL PEDIDO              EMPIEZA ALTA DEL PEDIDO
                cmd.Connection = cnSAE
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                cmd.Parameters.Add("@PED_ENLAZADO", SqlDbType.VarChar).Value = LtCVE_DOC.Tag
                cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                cmd.Parameters.Add("@NUM_TALON", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE
                cmd.Parameters.Add("@NUM_TALON2", SqlDbType.VarChar).Value = FOLIO_CARTA_PORTE2
                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                cmd.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(TCVE_PLAZA.Text)
                cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(tCVE_PLAZA2.Text)
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                cmd.Parameters.Add("@VALOR_DECLA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TValorDeclarado.Text)
                cmd.Parameters.Add("@LEYENDA", SqlDbType.VarChar).Value = TLeyenda.Text
                cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                cmd.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text
                cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        ImprimirOrden(CVE_DOC)

                        If DOCNEW Then

                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_PEDIDO &
                                      " WHERE TIP_DOC = 'P' AND SERIE = '" & IIf(SERIE_PEDIDO = "", "STAND.", SERIE_PEDIDO) & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("70. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                If LtCVE_DOC.Tag.ToString.Trim.Length > 0 Then
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "UPDATE GCPEDIDOSPROG SET ENLAZADO = 'S' WHERE CVE_DOC = '" & LtCVE_DOC.Tag.ToString & "'"
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                End If
                            Catch ex As Exception
                                Bitacora("70. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            End Try

                            CVE_DOC = ""
                            Try
                                Sigue = True
                                FOLIO_ASIGNADO = False
                                FOLIO_PEDIDO = SIGUIENTE_FOLIO_VENTA("P", SERIE_PEDIDO.ToString)
                                Do While Sigue

                                    If SERIE_PEDIDO.ToString.Trim.Length = 0 Or SERIE_PEDIDO.ToString = "STAND." Then
                                        CVE_DOC = Space(10) & Format(FOLIO_PEDIDO, "0000000000")
                                    Else
                                        CVE_DOC = SERIE_PEDIDO & Format(FOLIO_PEDIDO, "0000000000")
                                    End If

                                    If EXISTE_PEDIDO(CVE_DOC) Then
                                        FOLIO_PEDIDO += 1
                                        FOLIO_ASIGNADO = True
                                    Else
                                        Sigue = False
                                    End If
                                Loop
                            Catch ex As Exception
                                Bitacora("70. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'FIN ALTA DEL PEDIDO                  FIN ALTA DEL PEDIDO
            'FIN ALTA DEL PEDIDO                  FIN ALTA DEL PEDIDO
        Next 'FIN ALTA DEL PEDIDO                 FIN ALTA DEL PEDIDO


        'PRODUCTO
        If LtCartaPorte.Text.Trim.Length > 0 Or LtCartaPorte2.Text.Trim.Length > 0 Then
            Dim ST_CARTA_PORTE As Integer = 0

            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(ST_CARTA_PORTE,1) AS ST FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        If dr2.Read Then
                            ST_CARTA_PORTE = dr2("ST")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try


            If LtCartaPorte.Text.Trim.Length > 0 And ST_CARTA_PORTE = 1 Then
                Try
                    SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = @CVE_VIAJE, CVE_DOCP = @CVE_DOCP, TIPO_VIAJE = @TIPO_VIAJE, CVE_OPER = @CVE_OPER, 
                        CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, 
                        RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, 
                        ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, PEDIMENTO = @PEDIMENTO, CVE_ART = @CVE_ART,
                        CVE_PLAZA1 = @CVE_PLAZA1, CVE_PLAZA2 = @CVE_PLAZA2, CVE_TAB_VIAJE = @CVE_TAB_VIAJE, CVE_CON = @CVE_CON, CVE_OBSP = @CVE_OBSP
                        WHERE CVE_FOLIO = @CVE_FOLIO"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        cmd2.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtViaje.Text
                        cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = CVE_DOC2
                        cmd2.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = TIPO_UNI  'CARGADO VACIO
                        cmd2.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = LtCartaPorte.Text
                        cmd2.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                        cmd2.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                        cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                        cmd2.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                        cmd2.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                        cmd2.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                        cmd2.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                        cmd2.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                        cmd2.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                        cmd2.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                        cmd2.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                        cmd2.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                        cmd2.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                        cmd2.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text
                        cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                        cmd2.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = TCVE_PLAZA.Text
                        cmd2.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = tCVE_PLAZA2.Text
                        cmd2.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                        cmd2.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                        cmd2.Parameters.Add("@CVE_OBSP", SqlDbType.Int).Value = CVE_OBS
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    'MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            ST_CARTA_PORTE = 0

            If LtCartaPorte2.Text.Trim.Length > 0 Then

                Try
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(ST_CARTA_PORTE,1) AS ST FROM GCCARTA_PORTE WHERE CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                ST_CARTA_PORTE = dr2("ST")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                If ST_CARTA_PORTE = 1 Then
                    Try
                        SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = @CVE_VIAJE, CVE_DOCP = @CVE_DOCP, TIPO_VIAJE = @TIPO_VIAJE, CVE_OPER = @CVE_OPER, 
                            CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, 
                            RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, 
                            ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, PEDIMENTO = @PEDIMENTO, CVE_ART = @CVE_ART,
                            CVE_PLAZA1 = @CVE_PLAZA1, CVE_PLAZA2 = @CVE_PLAZA2, CVE_TAB_VIAJE = @CVE_TAB_VIAJE, CVE_CON = @CVE_CON, CVE_OBSP = @CVE_OBSP
                            WHERE CVE_FOLIO = @CVE_FOLIO"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            cmd2.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtViaje.Text
                            cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = CVE_DOC2
                            cmd2.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = TIPO_UNI  'CARGADO VACIO
                            cmd2.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = LtCartaPorte2.Text
                            cmd2.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                            cmd2.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                            cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                            cmd2.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                            cmd2.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                            cmd2.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                            cmd2.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                            cmd2.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                            cmd2.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                            cmd2.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                            cmd2.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                            cmd2.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                            cmd2.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                            cmd2.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text
                            cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                            cmd2.Parameters.Add("@CVE_PLAZA1", SqlDbType.VarChar).Value = TCVE_PLAZA.Text
                            cmd2.Parameters.Add("@CVE_PLAZA2", SqlDbType.VarChar).Value = tCVE_PLAZA2.Text
                            cmd2.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                            cmd2.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                            cmd2.Parameters.Add("@CVE_OBSP", SqlDbType.Int).Value = CVE_OBS
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                        'MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        End If

        If EditPed Then            'ACTULIZANDO INFORMACION EN CARTA PORTE

            If LtViaje.Text.Trim.Length > 0 Then
                Try
                    Try
                        SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_OPER = @CVE_OPER, CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_TRACTOR = @CVE_TRACTOR, 
                            CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, 
                            FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, 
                            CARGA_ANTERIOR = @CARGA_ANTERIOR
                            WHERE CVE_VIAJE = @CVE_VIAJE"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            cmd2.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtViaje.Text
                            cmd2.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                            cmd2.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                            cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                            cmd2.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                            cmd2.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                            cmd2.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                            cmd2.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                            cmd2.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                            cmd2.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                            cmd2.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                            cmd2.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                            cmd2.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                            cmd2.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                            'cmd2.Parameters.Add("@PEDIMENTO", SqlDbType.VarChar).Value = TPEDIMENTO.Text
                            'cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = tCVE_ART.Text
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If

        Try
            GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se agregó o edito carta porte", LtCVE_DOC.Text, LtCartaPorte.Text)

            If LtTractor.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TRACTOR.Text <> LtTractor.Tag Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio la unidad " & LtTractor.Tag & " por " & TCVE_TRACTOR.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If LTanque1.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TANQUE1.Text <> LTanque1.Tag Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio la unidad " & LTanque1.Tag & " por " & TCVE_TANQUE1.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If LTanque2.Tag.ToString.Trim.Length > 0 Then
                If TCVE_TANQUE2.Text <> LTanque2.Tag Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio la unidad " & LTanque2.Tag & " por " & TCVE_TANQUE2.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If TCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                If TCLAVE_O.Tag <> TCLAVE_O.Text Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio el cliente operativo " & TCLAVE_O.Tag & " por " & TCLAVE_O.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio el cliente operativo " & TCLAVE_D.Tag & " por " & TCLAVE_D.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio recoger en " & TRECOGER_EN.Tag & " por " & TRECOGER_EN.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio entregar en " & TENTREGAR_EN.Tag & " por " & TENTREGAR_EN.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If
            If TCVE_OPER.Tag.ToString.Trim.Length > 0 Then
                If TCVE_OPER.Tag <> TCVE_OPER.Text Then
                    GRABA_BITA("", LtCartaPorte.Text, 0, "P", "Se cambio el operador " & TCVE_OPER.Tag & " por " & TCVE_OPER.Text,
                                       LtCVE_DOC.Text, LtCartaPorte.Text, "FtoF")
                End If
            End If

            LtTractor.Tag = TCVE_TRACTOR.Text
            LTanque1.Tag = TCVE_TANQUE1.Text
            LTanque2.Tag = TCVE_TANQUE2.Text

            TCLAVE_O.Tag = TCLAVE_O.Text
            TCLAVE_D.Tag = TCLAVE_D.Text
            TRECOGER_EN.Tag = TRECOGER_EN.Text
            TENTREGAR_EN.Tag = TENTREGAR_EN.Text
            TCVE_OPER.Tag = TCVE_OPER.Text

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        EditPed = True
        DOCNEW = False

        LtCartaPorte.Tag = ""
        LtCartaPorte2.Tag = ""
        BtnMas1.Visible = False
        BtnMas2.Visible = False

        'MsgBox("El registro se grabo satisfactoriamente")
        'LIMPIAR()
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmPedidosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnContrato_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Contrato"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CON.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""

                DESPLEGAR_CONTRATO(TCVE_CON.Text)

                TCVE_CON.Select()
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OBS_GotFocus(sender As Object, e As EventArgs) Handles TCVE_OBS.GotFocus
        Entra = False
    End Sub
    Private Sub TCVE_OBS_LostFocus(sender As Object, e As EventArgs) Handles TCVE_OBS.LostFocus
        Entra = True
    End Sub
    Private Sub BtnContrato_Click_1(sender As Object, e As EventArgs) Handles BtnContrato.Click
        Try
            Var2 = "Contrato"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CON.Text = Var4
                DESPLEGAR_CONTRATO(Var4)
                'LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CON_Validated(sender As Object, e As EventArgs) Handles TCVE_CON.Validated
        Try
            If TCVE_CON.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Contrato", TCVE_CON.Text)
                If DESCR <> "" Then

                Else
                    TCVE_CON.Select()
                    MsgBox("El contrato no existe")
                    TCVE_CON.Text = ""
                End If
            Else
                TCLAVE_O.Text = "" : TCLAVE_D.Text = "" : TCLAVE_O.Tag = "" : TCLAVE_D.Tag = "" : TCVE_RUTA.Text = "" : LtRuta1.Text = ""
                TRUTA_SEN_VAC.Text = "" : TRUTA_SE_CAR.Text = "" : TRUTA_FULL_VAC.Text = "" : TRUTAL_FULL_CAR.Text = "" : TNOTA.Text = ""
                TRECOGER_EN.Text = "" : TENTREGAR_EN.Text = "" : TValorDeclarado.Text = "" : TCVE_OBS.Text = "" : TValorDeclarado.Text = ""
                Lt1.Text = "" : LtValorDeclarado.Text = "" : TCVE_ART.Text = ""
            End If
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CON_GotFocus(sender As Object, e As EventArgs) Handles TCVE_CON.GotFocus
        Entra = False
    End Sub
    Private Sub TCVE_CON_LostFocus(sender As Object, e As EventArgs) Handles TCVE_CON.LostFocus
        Entra = True
        'MODIFICACIUON 15 DICIEM RE 2022

    End Sub
    Private Sub TCVE_CON_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_CON.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            If TCLAVE_O.Text.Trim.Length = 0 Then
                DESPLEGAR_CONTRATO(TCVE_CON.Text)
            End If
        End If

    End Sub

    Sub DESPLEGAR_CONTRATO(fCVE_CON As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_CON, C.CONTRATO_CLIENTE, C.CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR, 
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER, 
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, C.CLAVE_O, C.CLAVE_D, C.CVE_ORIGEN, C.CVE_DESTINO, C.RECOGER_EN, C.ENTREGAR_EN, 
                    C.CVE_PROV, C.CVE_MAT, ISNULL(C.VALOR_DECLA,0) AS DECLA, C.CVE_ART, C.LEYENDA, ISNULL(C.IMPR_TALON,0) AS IMPR, ISNULL(C.CVE_OBS,0) AS CVEOBS, 
                    ISNULL(O.DESCR,'') AS OBS_DESCR, C.CVE_TAB_VIAJE, R.CVE_TAB
                    FROM GCCONTRATO C 
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                    WHERE C.CVE_CON = '" & fCVE_CON & "' AND C.STATUS = 'A' "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLAVE_O.Text = dr("CLAVE_O").ToString.Trim
                        TCLAVE_D.Text = dr("CLAVE_D").ToString.Trim
                        'MARCA1

                        TCONTRATO_CLIENTE.Text = dr("NO_CONTRATO").ToString
                        '"SELECT ISNULL(NOMBRE,'') AS DES FROM GCCLIE_OP WHERE CLAVE = " & fCLAVE
                        LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)

                        '"SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                        DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                        DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)

                        Try
                            TCVE_TAB_VIAJE.Text = dr("CVE_TAB_VIAJE")
                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB")
                        Catch ex As Exception

                        End Try
                        If TRECOGER_EN.Text.Trim.Length = 0 Then
                            TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                            '"SELECT ISNULL(DESCR,'') AS DES FROM GCRECOGER_EN_ENTREGAR_EN WHERE CVE_REG = '" & fCLAVE & "'"
                            LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        End If
                        If TENTREGAR_EN.Text.Trim.Length = 0 Then
                            TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                            '"SELECT ISNULL(DESCR,'') AS DES FROM GCRECOGER_EN_ENTREGAR_EN WHERE CVE_REG = '" & fCLAVE & "'"
                            LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                        End If

                        TValorDeclarado.Text = dr("DECLA").ToString
                        TLeyenda.Text = dr("LEYENDA").ToString
                        TRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                        TRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                        TRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                        TRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                        TNOTA.Text = dr("NOTA").ToString

                        TCVE_OBS_CON.Text = dr("OBS_DESCR")

                        TValorDeclarado.Text = dr("DECLA").ToString
                        If TValorDeclarado.Text = "0" Then
                            TValorDeclarado.Text = ""
                            Lt1.Text = ""
                            LtValorDeclarado.Text = ""
                        Else
                            Try
                                '"SELECT E.CLAVE, E.IMPORTE, E.DESCR From GCVALOR_DECLARADO E Where e.STATUS = 'A' AND E.CLAVE = '" & fCLAVE & "'"
                                BUSCA_VALOR_DECLARADO(TValorDeclarado.Text)
                                Lt1.Text = Var5
                                If IsNumeric(Var6) Then
                                    LtValorDeclarado.Text = Format(CSng(Var6), "###,##0.00")
                                End If
                            Catch ex As Exception
                                Bitacora("120 " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("120 " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                        TCVE_ART.Text = dr("CVE_ART").ToString
                        LtProducto.Text = BUSCA_CAT("Productos", TCVE_ART.Text)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try

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
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        tCVE_PLAZA2.Text = dr("CVE_PLAZA").ToString

                        If tCVE_PLAZA2.Text.Trim.Length > 0 Then
                            LtPlaza2.Text = BUSCA_CAT("Plazas", tCVE_PLAZA2.Text, False)
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
            Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnRuta_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Detalle rutas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_RUTA.Text = Var4
                LtRuta1.Text = "Origen:" & Var7 & "   Destino:" & Var10
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = ""
                TRUTA_SEN_VAC.Focus()
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_RUTA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_RUTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnRuta_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_RUTA_Validated(sender As Object, e As EventArgs) Handles TCVE_RUTA.Validated
        Try
            If TCVE_RUTA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Detalle rutas", TCVE_RUTA.Text)
                LtRuta1.Text = DESCR
                If DESCR <> "" Then
                    LtRuta1.Text = DESCR
                Else
                    MsgBox("Ruta inexistente")
                End If
            End If

        Catch ex As Exception
            Bitacora("195. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("195. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_CON_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CON.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnContrato_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = Keys.Tab Or e.KeyCode = 13 Then
                If TCLAVE_O.Text.Trim.Length = 0 Then
                    DESPLEGAR_CONTRATO(TCVE_CON.Text)
                End If
                'tCVE_OPER.Select()
                Label15.Select()
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("GCPRODUCTOS", TCVE_ART.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    LtProducto.Text = DESCR
                Else
                    MsgBox("Articulo inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Dim OPER As String

            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                'OPER = OPERADOR_ASIGNADO_VIAJE(Var4) 'OBTIEN CVE_VIAJE
                OPER = ""
                If OPER = "" Then
                    TCVE_OPER.Text = Var4
                    LtOper.Text = Var5  'NOMBRE
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_TRACTOR.Focus()
                Else
                    MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                    TCVE_OPER.Text = ""
                    LtOper.Text = ""
                    Var2 = "" : Var4 = "" : Var5 = ""
                End If
            Else
                TCVE_OPER.Text = ""
                LtOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String, OPER As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    'OPER = OPERADOR_ASIGNADO_VIAJE(tCVE_OPER.Text) 'OBTIEN CVE_VIAJE
                    OPER = ""
                    If OPER = "" Then
                        LtOper.Text = DESCR
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_TRACTOR.Focus()
                    Else
                        MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                        TCVE_OPER.Text = ""
                        LtOper.Text = ""
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_OPER.Select()
                    End If


                Else
                    MsgBox("Operador inexistente")
                    LtOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                LtOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
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
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA(Var4) Then
                        MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                        TCVE_TRACTOR.Text = ""
                        TCVE_TRACTOR.Tag = ""
                        LtTractor.Text = ""
                        TCVE_TRACTOR.Select()
                        Return
                    End If
                    'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                    'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                    'Var6 = dr.ReadNullAsEmptyString("DES").ToString'
                    'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                    'Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString

                    Var3 = ""
                    TCVE_TRACTOR.Tag = DESCR
                    LtTractor.Text = DESCR

                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = ""
                    TCVE_TRACTOR.Tag = ""
                    LtTractor.Text = ""
                    TCVE_TRACTOR.Select()
                End If
            Else
                TCVE_TANQUE1.Tag = ""
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
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
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA_LOCAL(2, TCVE_TANQUE1.Text) Then
                        MsgBox("Unidad asignada, verifique por favor")
                        TCVE_TANQUE1.Text = ""
                        TCVE_TANQUE1.Tag = ""
                        LTanque1.Text = ""
                        TCVE_TANQUE1.Select()
                        Return
                    End If
                    Var3 = ""
                    TCVE_TANQUE1.Tag = DESCR
                    LTanque1.Text = DESCR
                    If TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                        LtCartaPorte2.Text = LCartaPorte2.Tag
                    Else
                        LtCartaPorte2.Text = ""
                        LtTipoViaje.Text = "Sencillo"
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE1.Text = ""
                    TCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                    TCVE_TANQUE1.Select()
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                    LtCartaPorte2.Text = LCartaPorte2.Tag
                Else
                    LtCartaPorte2.Text = ""
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE1.Tag = ""
                LTanque1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque2_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            Gp2.Select()
        End If
    End Sub
    Private Sub TCVE_TANQUE2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_TANQUE2.PreviewKeyDown
        If e.KeyCode = 9 Then
            Gp2.Select()
        End If
    End Sub
    Private Sub TCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA_LOCAL(3, TCVE_TANQUE2.Text) Then
                        MsgBox("Unidad asignada, verifique por favor")
                        TCVE_TANQUE2.Text = ""
                        TCVE_TANQUE2.Tag = ""
                        LTanque2.Text = ""
                        LtCartaPorte2.Text = ""
                        TCVE_TANQUE2.Select()
                        Return
                    End If
                    Var3 = ""
                    TCVE_TANQUE2.Tag = DESCR
                    LTanque2.Text = DESCR
                    If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                        LtCartaPorte2.Text = LCartaPorte2.Tag

                        LCartaPorte2.Visible = True
                        LtCartaPorte2.Visible = True

                    Else
                        LtCartaPorte2.Text = ""
                        LtTipoViaje.Text = "Sencillo"

                        LCartaPorte2.Visible = False
                        LtCartaPorte2.Visible = False
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE2.Text = ""
                    TCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                    LCartaPorte2.Visible = False
                    LtCartaPorte2.Visible = False
                    'TRECOGER_EN.Focus()
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                    LtCartaPorte2.Text = LCartaPorte2.Tag
                Else
                    LtCartaPorte2.Text = ""
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE2.Tag = ""
                LTanque2.Text = ""
                'TRECOGER_EN.Focus()
            End If
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CARTA_PORTE(fCVE_CAP As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_FOLIO, C.CVE_VIAJE, C.CLIENTE, C.FECHA_DOC, C.STATUS, C.TIPO_VIAJE, C.TIPO_UNI, C.CVE_OPER, C.CLAVE_O,
                    C.CLAVE_D, C.CVE_TRACTOR, C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, CVE_COBRO,
                    ISNULL(REM_CARGA1,'') AS REM1, ISNULL(PESO_BRUTO1,0) AS PESO1, ISNULL(TARA1,0) AS T1, ISNULL(REM_CARGA2,'') AS REM2,
                    ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, ISNULL(REM_CARGA3,'') AS REM3, ISNULL(PESO_BRUTO3,'0') AS PESO3,
                    ISNULL(TARA3,'0') AS T3, ISNULL(REM_CARGA4,'') AS REM4, ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4,
                    CVE_TIPO_PAGO
                    FROM GCCARTA_PORTE C
                    WHERE CVE_FOLIO = '" & fCVE_CAP & "' AND C.STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCVE_OPER.Text = dr("CVE_OPER").ToString
                        LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

                        TCVE_TRACTOR.Text = dr("CVE_TRACTOR").ToString
                        LtTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                        TCVE_TANQUE1.Text = dr("CVE_TANQUE1").ToString
                        LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                        TCVE_TANQUE2.Text = dr("CVE_TANQUE2").ToString
                        LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                        'tCVE_DOLLY.Text = dr("CVE_DOLLY").ToString
                        'LDolly.Text = BUSCA_CAT("Unidad", tCVE_DOLLY.Text)
                        TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                        TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                        LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)

                        If dr("TIPO_UNI").ToString = "1" Then
                            'radFull.Checked = True
                            'radSencillo.Checked = False
                            If dr("TIPO_VIAJE").ToString = "1" Then
                                'radCargado.Checked = True
                                'radVacio.Checked = False
                                'CARGADO
                                LaTractor.Visible = True
                                LtTanque1.Visible = True
                                LtTanque2.Visible = True

                                TCVE_TRACTOR.Visible = True
                                TCVE_TANQUE1.Visible = True
                                TCVE_TANQUE2.Visible = True

                                BtnTractor.Visible = True
                                BtnTanque1.Visible = True
                                BtnTanque2.Visible = True

                                LtTractor.Visible = True
                                LTanque1.Visible = True
                                LTanque2.Visible = True
                            Else
                                LaTractor.Visible = True
                                LtTanque1.Visible = True
                                LtTanque2.Visible = True

                                TCVE_TRACTOR.Visible = True
                                TCVE_TANQUE1.Visible = True
                                TCVE_TANQUE2.Visible = True

                                BtnTractor.Visible = True
                                BtnTanque1.Visible = True
                                BtnTanque2.Visible = True

                                LtTractor.Visible = True
                                LTanque1.Visible = True
                                LTanque2.Visible = True
                            End If
                        Else
                            'radFull.Checked = False
                            'radSencillo.Checked = True
                            If dr("TIPO_VIAJE").ToString = "1" Then
                                LaTractor.Visible = True
                                LtTanque1.Visible = True
                                LtTanque2.Visible = False

                                TCVE_TRACTOR.Visible = True
                                TCVE_TANQUE1.Visible = True
                                TCVE_TANQUE2.Visible = False

                                BtnTractor.Visible = True
                                BtnTanque1.Visible = True
                                BtnTanque2.Visible = False

                                LtTractor.Visible = True
                                LTanque1.Visible = True
                                LTanque2.Visible = False
                            Else
                                LaTractor.Visible = True
                                LtTanque1.Visible = True
                                LtTanque2.Visible = False


                                TCVE_TRACTOR.Visible = True
                                TCVE_TANQUE1.Visible = True
                                TCVE_TANQUE2.Visible = False

                                BtnTractor.Visible = True
                                BtnTanque1.Visible = True
                                BtnTanque2.Visible = False

                                LtTractor.Visible = True
                                LTanque1.Visible = True
                                LTanque2.Visible = False
                            End If
                        End If

                        If dr("TIPO_VIAJE").ToString = "1" Then
                        Else
                        End If
                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                TCVE_TRACTOR.Tag = Var4
                LtTractor.Text = Var6
                'LtPlaca1.Text = Var8
                'LtMarca1.Text = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(2, Var5) Then
                    MsgBox("Unidad asignada, verifique por favor")
                    TCVE_TANQUE1.Text = ""
                    TCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_TANQUE1.Select()
                    Return
                End If
                LtTipoViaje.Text = "Sencillo"
                TCVE_TANQUE1.Text = Var5
                TCVE_TANQUE1.Tag = Var4
                LTanque1.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque2_Click(sender As Object, e As EventArgs) Handles BtnTanque2.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(3, Var5) Then
                    MsgBox("La unidad asignada, verifique por favor")
                    TCVE_TANQUE2.Text = ""
                    TCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                    LtCartaPorte2.Text = ""
                    LCartaPorte2.Visible = False
                    LtCartaPorte2.Visible = False
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_TANQUE2.Select()
                    Return
                End If
                If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"

                    LtCartaPorte2.Text = LCartaPorte2.Tag
                    LCartaPorte2.Visible = True
                    LtCartaPorte2.Visible = True
                Else
                    LtTipoViaje.Text = "Sencillo"
                    LtCartaPorte2.Text = ""
                    LCartaPorte2.Visible = False
                    LtCartaPorte2.Visible = False
                End If
                TCVE_TANQUE2.Text = Var5
                TCVE_TANQUE2.Tag = Var4
                LTanque2.Text = Var6

                Var2 = "" : Var3 = "" : Var4 = ""
                Var5 = ""
                TRECOGER_EN.Focus()
            End If

        Catch Ex As Exception
            Bitacora("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
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
                    Catch ex As Exception
                        Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 2 'TANQUE 1
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 3 'TANQUE2
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
            Return Exist
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click

        ImprimirOrden(LtCVE_DOC.Text)

    End Sub
    Sub ImprimirOrden(fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportPedido.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportPedido.mrt, verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\ReportPedido.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_DOC") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TRECOGER_EN_KeyDown(sender As Object, e As KeyEventArgs) Handles TRECOGER_EN.KeyDown

    End Sub
    Private Sub TRECOGER_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRECOGER_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Gp3.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TENTREGAR_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TENTREGAR_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Gp4.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub F1_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F1.DropDownClosed
        Try
            If IsDate(LtFecha.Text) Then
                Dim dt As DateTime = Convert.ToDateTime(LtFecha.Text)

                If dt > F1.Value Then
                    MsgBox("La fecha de carga no puede ser menor a la fecha del pedido")
                    F1.Value = F1.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_Validating(sender As Object, e As CancelEventArgs) Handles F1.Validating
        Try
            If IsDate(LtFecha.Text) Then
                Dim dt As DateTime = Convert.ToDateTime(LtFecha.Text)

                If dt > F1.Value Then
                    MsgBox("La fecha de carga no puede ser menor a la fecha del pedido")
                    F1.Value = F1.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F2_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F2.DropDownClosed
        Try
            If IsDate(LtFecha.Text) Then
                Dim dt As DateTime = Convert.ToDateTime(LtFecha.Text.Substring(0, 10) & " 00:0:00")
                If F1.Value > F2.Value Then
                    MsgBox("1. La fecha de descarga no puede ser menor a la fecha de carga")
                    F2.Value = F2.Tag
                    TCVE_ART.Select()
                End If
                If dt > F2.Value Then
                    MsgBox("2. La fecha de descarga no puede ser menor a la fecha del pedido")
                    F2.Value = F2.Tag
                    TCVE_ART.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TENTREGAR_EN.Text = Var4
                LtEntregarEn.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_PLAZA2.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
    Private Sub BtnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
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
            Var2 = "Cliente operativo" '       GCCLIE_OP
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
    Private Sub BtnPlaza_Click(sender As Object, e As EventArgs) Handles BtnPlaza.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPlaza2_Click(sender As Object, e As EventArgs) Handles BtnPlaza2.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
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
        End If
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
    Private Sub TCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlaza_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Sub LIMPIAR()
        Try
            LIMPIAR_ALL_CONTROL(Gp1)
            LIMPIAR_ALL_CONTROL(Gp2)
            LIMPIAR_ALL_CONTROL(Gp3)
            LIMPIAR_ALL_CONTROL(Gp4)
            LIMPIAR_ALL_CONTROL(Box2)
            LIMPIAR_ALL_CONTROL(Box3)
            LIMPIAR_ALL_CONTROL(Box4)

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click

        Try
            If MsgBox("Realmente desea cancelar el pedido?", vbYesNo) = vbYes Then
                Try
                    SQL = "UPDATE GCPEDIDOS SET STATUS = 'C', CVE_VIAJE = '', NUM_TALON = '', NUM_TALON2 = '' WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                'DESASIGNANDO PEDIDO EN CARTA PORTE
                                If LtCartaPorte.Text.Trim.Length > 0 Then
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '', CVE_VIAJE = '' WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                                If LtCartaPorte2.Text.Trim.Length > 0 Then
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCCARTA_PORTE SET CVE_DOCP = '', CVE_VIAJE = '' WHERE CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                                If LtViaje.Text.Trim.Length > 0 Then
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_DOC = '', CVE_CAP1 = '', CVE_CAP2 = ''  WHERE CVE_VIAJE = '" & LtViaje.Text & "'"
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If

                                'CANCELACION EN SEGUIEMIENTO DE PEDIDOS

                                SQL = "UPDATE GCSEG_VALPED SET STATUS = 'C' WHERE CVE_DOCP = '" & LtCVE_DOC.Text & "'"
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then

                                            End If
                                        End If
                                    End Using
                                Catch ex As SqlException
                                    Dim errSQL As String = ""
                                    For i As Integer = 0 To ex.Errors.Count - 1
                                        errSQL = ("Index #" & i & vbLf & "Message: " & ex.Errors(i).Message & vbLf & "
							        LineNumber: " & ex.Errors(i).LineNumber.ToString & vbLf & "Source: " + ex.Errors(i).Source & vbLf & "
							        Procedure: " & ex.Errors(i).Procedure & vbLf)
                                    Next
                                    Bitacora("251. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & errSQL)
                                Catch ex As Exception
                                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try

                            End If
                        End If


                        GRABA_BITA(TCVE_OPER.Text, LtCVE_DOC.Text, 0, "C", "Se cancelo pedido con cartas porte " & LtCartaPorte.Text & ", carta porte 2:" &
                                   LtCartaPorte2.Text, LtViaje.Text)

                        MsgBox("El pedido se cancelo satisfactoriamente")
                        Me.Close()
                    End Using
                Catch ex As Exception
                    Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try


            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDesasignarCP1_Click(sender As Object, e As EventArgs) Handles BtnDesasignarCP1.Click
        Try
            If LtCartaPorte.Text.Trim.Length > 0 Then
                If MsgBox("Realmente desea desasignar la carta porte", vbYesNo) = vbYes Then

                    GRABA_BITA(TCVE_OPER.Text, LtCVE_DOC.Text, 0, "C", "Se desasigno carta porte del pedido", TCVE_CON.Text)

                    LtCartaPorte.Text = ""
                    LtCartaPorte.Tag = "DESASIGNAR CARTA PORTE"

                    MsgBox("Movimiento grabado en la bitacora")

                    BtnDesasignarCP1.Visible = False
                    BtnMas1.Visible = True

                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDesasignarCP2_Click(sender As Object, e As EventArgs) Handles BtnDesasignarCP2.Click
        Try
            If LtCartaPorte2.Text.Trim.Length > 0 Then
                If MsgBox("Realmente desea desasignar la carta porte", vbYesNo) = vbYes Then

                    GRABA_BITA(TCVE_OPER.Text, LtCVE_DOC.Text, 0, "C", "Se desasigno carta porte del pedido", TCVE_CON.Text)
                    LtCartaPorte2.Text = ""
                    LtCartaPorte2.Tag = "DESASIGNAR CARTA PORTE"
                    MsgBox("Movimiento grabado en la bitacora")

                    BtnDesasignarCP2.Visible = False
                    BtnMas2.Visible = True

                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMas1_Click(sender As Object, e As EventArgs) Handles BtnMas1.Click
        Try
            If LtTipoViaje.Text = "Full" Then
                Var45 = 2
            Else
                Var45 = 1
            End If
            Var4 = ""
            Var5 = ""
            FrmSelItemCP.ShowDialog()
            If Var4.Trim.Length = 0 Then
                Return
            Else
                LtCartaPorte.Text = Var4
                LCartaPorte1.Tag = Var4
                If Var4.Trim.Length > 0 Then
                    LtCartaPorte.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO"
                    If Var5.Trim.Length > 0 Then

                        LtCartaPorte2.Text = Var5
                        LCartaPorte2.Tag = Var5

                        LtCartaPorte2.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO"
                    End If

                    GRABA_BITA(TCVE_OPER.Text, LtCVE_DOC.Text, 0, "C", "Se asigno carta porte existente " & Var4, LtCartaPorte.Text)

                    MsgBox("Movimiento grabado en la bitacora")
                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnMas2_Click(sender As Object, e As EventArgs) Handles BtnMas2.Click
        Try
            If LtCartaPorte.Text.Trim.Length = 0 Then
                MsgBox("Por favor agregue en la carta porte e1")
                Return
            End If

            Var4 = ""
            Var5 = ""
            FrmSelItemCP.ShowDialog()
            If Var4.Trim.Length = 0 Then
                Return
            Else
                LtCartaPorte2.Text = Var4
                If Var4.Trim.Length > 0 Then
                    LtCartaPorte2.Tag = "CARTA PORTE EXISTENTE EN UN PEDIDO NUEVO"
                    GRABA_BITA(TCVE_OPER.Text, LtCVE_DOC.Text, 0, "C", "Se asigno carta porte existente " & Var4, LtCartaPorte.Text)

                    MsgBox("Se grabo el la bitacora el cambio")
                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Try
            Var2 = "GCPRODUCTOS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                LtProducto.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TLeyenda.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProducto_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BarEnlazarPedido_Click(sender As Object, e As EventArgs) Handles BarEnlazarPedido.Click
        Try
            Var2 = "PedidosProg"
            PassData = "TOP"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                'Var5 = Fg(Fg.Row, 2) 'CVE_CON
                'Var6 = Fg(Fg.Row, 3) 'CVE_CLIE

                LtDocEnlazado.Text = "Pedido prog. enlazado " & Var4
                LtCVE_DOC.Tag = Var4

                DESPLEGAR_PED_ENLAZADO()
            End If

        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_PED_ENLAZADO()
        Try
            SQL = "SELECT C.CVE_CON, C.CONTRATO_CLIENTE, C.CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR, 
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER, 
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, C.CLAVE_O, C.CLAVE_D, C.CVE_ORIGEN, C.CVE_DESTINO, C.RECOGER_EN, C.ENTREGAR_EN, 
                    C.CVE_PROV, C.CVE_MAT, ISNULL(C.VALOR_DECLA,0) AS DECLA, C.CVE_ART, C.LEYENDA, ISNULL(C.IMPR_TALON,0) AS IMPR, ISNULL(C.CVE_OBS,0) AS CVEOBS, 
                    ISNULL(O.DESCR,'') AS OBS_DESCR, C.CVE_TAB_VIAJE, R.CVE_TAB
                    FROM GCCONTRATO C 
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS 
                    WHERE C.CVE_CON = '' AND C.STATUS = 'A' "


            SQL = "SELECT P.CVE_DOC, P.CVE_CLIE, ISNULL(P.CVE_CON,'') AS CVECON, ISNULL(P.STATUS,'C') AS ST, P.CVE_ART, ISNULL(I.DESCR,'') AS DESCR_PRODUCTO, 
                ISNULL(P1.CIUDAD,'') AS DESCR_ORIGEN, ISNULL(P2.CIUDAD,'') AS DESCR_DESTINO, P.FECHA, P.CVE_ORIGEN, P.CVE_DESTINO, 
                P.FECHA_CARGA, P.FECHA_DESCARGA, ISNULL(NOMBRE,'') AS NOMB, ISNULL(DOMICILIO,'') AS DIRE, ISNULL(RFC,'') AS RF, 
                ISNULL(C.DOMICILIO2,'') AS MUNI, NUM_TALON, NUM_TALON2, P.CVE_CAP, P.CVE_OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, P.CVE_TANQUE2, 
                ISNULL(P.CVE_OBS,0) AS CVEOBS, ISNULL(O.DESCR,'') AS OBS_DESCR, P.RECOGER_EN, P.ENTREGAR_EN, ISNULL(P.CLAVE_O,'') AS ORIGEN, 
                ISNULL(P.CLAVE_D,'') AS DESTINO, P.LEYENDA, P.VALOR_DECLA, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_VIAJE, PEDIMENTO, R.CVE_TAB,
                ISNULL(CT.NO_CONTRATO,'') AS NOCONTRATO 
                FROM GCPEDIDOSPROG P 
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = P.CVE_CON
                LEFT JOIN GCCLIE_OP C ON C.CLAVE = P.CVE_CLIE 
                LEFT JOIN GCCONTRATO CT On CT.CVE_CON = P.CVE_CON 
                LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = CT.CVE_ART 
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN 
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO 
                LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS 
                WHERE P.CVE_DOC = '" & Var4 & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART").ToString
                        LtProducto.Text = BUSCA_CAT("Productos", TCVE_ART.Text)
                        Try
                            TLeyenda.Text = dr.ReadNullAsEmptyString("LEYENDA").ToString
                            TValorDeclarado.Text = dr.ReadNullAsEmptyString("VALOR_DECLA").ToString
                            BUSCA_VALOR_DECLARADO(TValorDeclarado.Text)
                            Lt1.Text = Var5

                            If IsNumeric(Var6) Then
                                LtValorDeclarado.Text = Var6
                            End If

                            TCVE_TAB_VIAJE.Text = dr("CVE_TAB")
                        Catch ex As Exception
                            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                            TEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                            TCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                            TPEDIMENTO.Text = dr.ReadNullAsEmptyString("PEDIMENTO")
                        Catch ex As Exception
                            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        LtFecha.Text = dr("FECHA").ToString

                        If IsDate(dr("FECHA_CARGA").ToString) Then
                            F1.Value = dr("FECHA_CARGA").ToString
                            F1.Tag = dr("FECHA_CARGA").ToString
                        Else
                            F1.Value = Date.Today
                            F1.Tag = Date.Today
                        End If

                        If IsDate(dr("FECHA_DESCARGA").ToString) Then
                            F2.Value = dr("FECHA_DESCARGA").ToString
                            F2.Tag = dr("FECHA_DESCARGA").ToString
                        Else
                            F2.Value = Date.Today
                            F2.Tag = Date.Today
                        End If

                        TCVE_CON.Text = dr.ReadNullAsEmptyString("CVECON")
                        TCONTRATO_CLIENTE.Text = dr("NOCONTRATO").ToString
                        LtClienteContrato.Text = BUSCA_CAT("Cliente operativo", TCONTRATO_CLIENTE.Text)

                        TENTREGAR_EN.Text = dr.ReadNullAsEmptyString("ENTREGAR_EN")
                        TRECOGER_EN.Text = dr.ReadNullAsEmptyString("RECOGER_EN")
                        If TRECOGER_EN.Text.Trim.Length > 0 Then
                            LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        End If
                        If TENTREGAR_EN.Text.Trim.Length > 0 Then
                            LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                        End If

                        TCLAVE_O.Text = dr("ORIGEN")
                        TCLAVE_D.Text = dr("DESTINO")

                        DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text) 'GCCLIE_OP 
                        DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 

                        TCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                        LtTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                        TCVE_TANQUE1.Text = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                        LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                        TCVE_TANQUE2.Text = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString
                        LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                        If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                            If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                LtTipoViaje.Text = "Full"

                                LtCartaPorte2.Text = LCartaPorte2.Tag
                                LCartaPorte2.Visible = True
                                LtCartaPorte2.Visible = True
                            Else
                                LtTipoViaje.Text = "Sencillo"
                            End If
                        End If
                        TCVE_OPER.Text = dr.ReadNullAsEmptyString("CVE_OPER")
                        If TCVE_OPER.Text = "0" Then
                            TCVE_OPER.Text = ""
                        End If
                        If TCVE_OPER.Text.Trim.Length > 0 Then
                            LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                        End If

                        LtTractor.Tag = TCVE_TRACTOR.Text
                        LTanque1.Tag = TCVE_TANQUE1.Text
                        LTanque2.Tag = TCVE_TANQUE2.Text

                        TCLAVE_O.Tag = TCLAVE_O.Text
                        TCLAVE_D.Tag = TCLAVE_D.Text
                        TRECOGER_EN.Tag = TRECOGER_EN.Text
                        TENTREGAR_EN.Tag = TENTREGAR_EN.Text
                        TCVE_OPER.Tag = TCVE_OPER.Text

                        TCVE_OBS.Tag = dr("CVEOBS")
                        TCVE_OBS.Text = dr("OBS_DESCR")

                        TCVE_OPER.Focus()

                    End If
                End Using
            End Using
        Catch ex As Exception
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
                TCVE_CON.Focus()
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
                            TCVE_CON.Focus()
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
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BarCancelEspecial.Click
        BarCancelar_Click(Nothing, Nothing)
    End Sub
    Private Sub BarCartaPorteVirtual_Click(sender As Object, e As EventArgs) Handles BarCartaPorteVirtual.Click
        Try
            CP_VIRTUAL = "VIRTUAL"

            LtCartaPorte.Text = SIGUIENTE_SERIE_CARTA_PORTE_VIRTUAL()
            LCartaPorte1.Tag = LtCartaPorte.Text
            LCartaPorte2.Tag = Var24 & Format(Var20 + 1, "0000000000")

            If LtTipoViaje.Text = "Full" Then
                LtCartaPorte2.Text = Var24 & Format(Var20 + 1, "0000000000")
            Else
                LtCartaPorte2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCARGA_ANTERIOR_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCARGA_ANTERIOR.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TORDEN_DE.Select()
        End If
    End Sub
    Private Sub TPEDIMENTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TPEDIMENTO.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TCVE_OPER.Select()
        End If
    End Sub

End Class

