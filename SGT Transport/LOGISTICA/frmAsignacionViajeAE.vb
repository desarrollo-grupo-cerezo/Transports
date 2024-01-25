Imports C1.Win.C1Themes
Imports System.IO
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Public Class FrmAsignacionViajeAE
    Private SERIE_A As String
    Private FOLIO_A As Long
    Private BORRAR_REG_ANTERIORES As Boolean
    Private SERIE_AG As String
    Private FOLIO_AG As Long
    Private SeDesplega As Boolean = False

    Private SERIE_AV As String
    Private FOLIO_AV As Long
    Private FACTOR_IEPS As Single
    Private SERIE_VALE_COMBUS As String = ""
    Private ENTRA As Boolean
    Private DOC_NEW As Boolean
    Private VALOR_DECLA_DESDE_SAE As Integer = 0
    Private Sub FrmAsignacionViajeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim STATUS_VIA As Integer, STATUS_CANCELADO As Boolean = False


        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BtnPedido.FlatStyle = FlatStyle.Flat
            BtnPedido.FlatAppearance.BorderSize = 0
            BtnTabRutaViajes.FlatStyle = FlatStyle.Flat
            BtnTabRutaViajes.FlatAppearance.BorderSize = 0
            BtnContrato.FlatStyle = FlatStyle.Flat
            BtnContrato.FlatAppearance.BorderSize = 0
            BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
            BtnCLAVE_REM.FlatAppearance.BorderSize = 0
            BtnRecogerEn.FlatStyle = FlatStyle.Flat
            BtnRecogerEn.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            BtnTractor.FlatStyle = FlatStyle.Flat
            BtnTractor.FlatAppearance.BorderSize = 0
            BtnTanque1.FlatStyle = FlatStyle.Flat
            BtnTanque1.FlatAppearance.BorderSize = 0
            BtnTanque2.FlatStyle = FlatStyle.Flat
            BtnTanque2.FlatAppearance.BorderSize = 0
            BtnDolly.FlatStyle = FlatStyle.Flat
            BtnDolly.FlatAppearance.BorderSize = 0
            BtnCLAVE_DEST.FlatStyle = FlatStyle.Flat
            BtnCLAVE_DEST.FlatAppearance.BorderSize = 0
            BtnEntregarEn.FlatStyle = FlatStyle.Flat
            BtnEntregarEn.FlatAppearance.BorderSize = 0
            BtnTabRutas.FlatStyle = FlatStyle.Flat
            BtnTabRutas.FlatAppearance.BorderSize = 0
            BtnAgregar.FlatStyle = FlatStyle.Flat
            BtnAgregar.FlatAppearance.BorderSize = 0
            BtnEliminar.FlatStyle = FlatStyle.Flat
            BtnEliminar.FlatAppearance.BorderSize = 0

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        AssignValidation(Me.TCVE_TAB_VIAJE, ValidationType.Only_Numbers)

        FACTOR_IEPS = 0
        Try
            SQL = "SELECT * FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        FACTOR_IEPS = dr("FACTOR_IEPS")
                        VALOR_DECLA_DESDE_SAE = dr.ReadNullAsEmptyInteger("VALOR_DECLA_DESDE_SAE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SERIE_A = "" : FOLIO_A = 1
            SERIE_AG = "" : FOLIO_AG = 1
            SERIE_AV = "" : FOLIO_AV = 1
            OBTENER_FOLIOS()
            TCVE_DOC.Tag = " "
            ENTRA = True

            Me.KeyPreview = True
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F1.EditFormat.CustomFormat = "dd/MM/yyyy"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F2.CustomFormat = "dd/MM/yyyy"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            'F2.EditFormat.CustomFormat = "dd/MM/yyyy"

            FECHA.Value = Date.Today
            FECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.CustomFormat = "dd/MM/yyyy"
            FECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

            FECHA.Value = Date.Today

            TRECOGER_EN.MaxLength = 255
            TENTREGAR_EN.MaxLength = 255
            TRUTA_SEN_VAC.MaxLength = 255
            TRUTA_SE_CAR.MaxLength = 255
            TRUTA_FULL_VAC.MaxLength = 255
            TRUTAL_FULL_CAR.MaxLength = 255
            TNOTA.MaxLength = 255

            Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Box8.Width = Screen.PrimaryScreen.Bounds.Width - 50
            FgG.Width = Screen.PrimaryScreen.Bounds.Width - 100
            FgV.Width = Screen.PrimaryScreen.Bounds.Width - 100

            Box6.Width = Screen.PrimaryScreen.Bounds.Width - 50
            FgR.Width = Screen.PrimaryScreen.Bounds.Width - 100

            FgG.Cols(7).ComboList = "EDICION|ACEPTADO|"
            FgG.Cols(10).ComboList = "TRANSFERENCIA|EFECTIVO|"

            FgV.Cols(15).ComboList = "EDICION|CAPTURADO|"

            FgR.Cols(3).ComboList = "Full|Sencillo|"
            FgR.Cols(18).ComboList = "Cargado|Vacio|"

            FgG.Cols(3).Width = 45
            FgG.Cols(8).Width = 0
            FgG.Cols(9).Width = 0
            FgG.Cols(11).Width = 0

            FgV.Cols(3).Width = 55
            FgV.Cols(3).Width = 100
            FgV.Cols(5).Width = 250
            FgV.Cols(14).Width = 0
            FgV.Cols(17).Width = 0
            FgV.Cols(18).Width = 0
            FgV.Cols(19).Width = 0
            FgV.Cols(20).Width = 0

            FgG.ShowButtons = ShowButtonsEnum.Always
            FgV.ShowButtons = ShowButtonsEnum.Always


            If PASS_GRUPOCE = "BUS" Then
                FgG.Cols(9).Width = 110
                FgV.Cols(17).Width = 110
                FgV.Cols(18).Width = 110
                FgV.Cols(19).Width = 10
                FgV.Cols(20).Width = 110
                FgV.Cols(14).Width = 80
                For k = 1 To FgV.Cols.Count - 1
                    FgV(0, k) = FgV(0, k) & " (" & k & ")"
                Next
                For k = 1 To FgG.Cols.Count - 1
                    FgG(0, k) = FgG(0, k) & " (" & k & ")"
                Next
                For k = 1 To FgR.Cols.Count - 1
                    FgR(0, k) = FgR(0, k) & " (" & k & ")"
                Next
            Else
                FgG.Cols(11).Width = 0
                FgV.Cols(19).Width = 0
            End If

            TCVE_TRACTOR.Text = ""
            tCVE_TANQUE1.Text = ""
            TCVE_TANQUE2.Text = ""
            TCVE_DOLLY.Text = ""

            TCVE_TRACTOR.Tag = ""
            tCVE_TANQUE1.Tag = ""
            TCVE_TANQUE2.Tag = ""
            TCVE_DOLLY.Tag = ""

            TRECOGER_EN.Tag = " "
            TENTREGAR_EN.Tag = " "
            LTractor.Tag = " "
            LTanque1.Tag = " "
            LTanque2.Tag = " "
            LDolly.Tag = " "

            TCVE_OPER.Tag = " "
            TCLAVE_O.Tag = " "
            TCLAVE_D.Tag = " "
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try



        DOC_NEW = False
        If Var1 = "Nuevo" Then
            Try
                BarImprimir.Enabled = False
                BarImprimirCartasPorte.Enabled = False
                BarImprimirBitacoraViaje.Enabled = False

                TCVE_DOC.Text = ""
                LtCVE_VIAJE.Text = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                LtNoViaje.Text = LtCVE_VIAJE.Text
                LtStatus.Text = "DISPONIBLE"
                TCVE_DOC.Select()
                LtCVE_VIAJE.Tag = ""
                DOC_NEW = True

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.FECHA_CARGA, A.FECHA_DESCARGA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, 
                    ISNULL(CVE_ST_VALE,1) AS STATUS_VALE, ISNULL(A.CVE_ST_UNI,0) AS STATUS_UNI, A.TIPO_UNI, A.TIPO_VIAJE, A.CVE_OPER, 
                    A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA, 
                    ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, 
                    ISNULL(A.CVE_TAB, '') AS CVETAB, A.RUTA_SEN_VAC, A.RUTA_SE_CAR, A.RUTA_FULL_VAC, A.RUTAL_FULL_CAR, A.NOTA, 
                    A.CVE_CAP1, A.CVE_CAP2, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR, ISNULL(A.CVE_TAB_VIAJE,0) AS TAB_VIAJE, ISNULL(R.CVE_TAB,'') AS CVE_TAB_RUTA
                    FROM GCASIGNACION_VIAJE A 
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = A.CVE_CON
                    WHERE A.CVE_VIAJE = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then

                    If Var3 = "TRANSBORDO" Then

                        LtCVE_VIAJE.Text = "TRANSBORDO"
                        LtCVE_VIAJE.ForeColor = Color.Red
                        LtCVE_VIAJE.Tag = dr("CVE_VIAJE").ToString
                    Else
                        LtCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                        LtCVE_VIAJE.Tag = LtCVE_VIAJE.Text
                    End If
                    Try
                        If IsDate(dr("FECHA_CARGA").ToString) Then
                            F1.Value = dr("FECHA_CARGA").ToString
                        Else
                            F1.Value = BUSCAR_FECHA_EN_PEDIDOS("CARGA", dr("CVE_DOC").ToString)
                        End If

                        If IsDate(dr("FECHA_DESCARGA").ToString) Then
                            F2.Value = dr("FECHA_DESCARGA").ToString
                        Else
                            F2.Value = BUSCAR_FECHA_EN_PEDIDOS("DESCARGA", dr("CVE_DOC").ToString)
                        End If
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    LtNoViaje.Text = LtCVE_VIAJE.Text

                    Try
                        TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                        TEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                        TCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    TCVE_DOC.Text = dr("CVE_DOC").ToString
                    TCVE_CON.Text = dr("CVE_CON").ToString
                    LtCartaPorte.Text = dr.ReadNullAsEmptyString("CVE_CAP1")
                    LtCartaPorte2.Text = dr.ReadNullAsEmptyString("CVE_CAP2")

                    TRECOGER_EN.Text = dr("RECOGER")
                    TRECOGER_EN.Tag = dr("RECOGER")

                    TENTREGAR_EN.Text = dr("ENTREGAR")
                    TENTREGAR_EN.Tag = dr("ENTREGAR")

                    LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                    LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)

                    TCLAVE_O.Text = dr("ORIGEN")
                    TCLAVE_D.Text = dr("DESTINO")

                    TCLAVE_O.Tag = dr("ORIGEN")
                    TCLAVE_D.Tag = dr("DESTINO")


                    DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text) 'GCCLIE_OP 
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 

                    TRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                    TRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                    TRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                    TRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                    TNOTA.Text = dr("NOTA").ToString

                    FECHA.Value = dr("FECHA").ToString

                    TCVE_OPER.Text = dr("CVE_OPER").ToString

                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If

                    If TCVE_OPER.Text.Trim.Length > 0 Then
                        LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                        LtOp1.Text = TCVE_OPER.Text
                        LtOp2.Text = LOper.Text
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT ISNULL(NOMBRE,'') AS DES, LICENCIA, LIC_VENC FROM GCOPERADOR WHERE CLAVE = '" & TCVE_OPER.Text & "' AND STATUS  = 'A'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    LtLicencia.Text = dr2("LICENCIA")
                                    LtVigencia.Text = dr2("LIC_VENC")
                                End If
                                dr2.Close()
                            End Using
                        End Using
                    End If

                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If

                    TCVE_TRACTOR.Text = dr("CVE_TRACTOR").ToString
                    TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text
                    LTractor.Tag = TCVE_TRACTOR.Text

                    LTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                    tCVE_TANQUE1.Text = dr("CVE_TANQUE1").ToString
                    tCVE_TANQUE1.Tag = tCVE_TANQUE1.Text
                    LTanque1.Tag = tCVE_TANQUE1.Text

                    LTanque1.Text = BUSCA_CAT("Unidad", tCVE_TANQUE1.Text)

                    TCVE_TANQUE2.Text = dr("CVE_TANQUE2").ToString
                    TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text
                    LTanque2.Tag = TCVE_TANQUE2.Text

                    LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                    TCVE_DOLLY.Text = dr("CVE_DOLLY").ToString
                    TCVE_DOLLY.Tag = dr("CVE_DOLLY").ToString

                    LDolly.Text = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)

                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"
                        Else
                            LtTipoViaje.Text = "Sencillo"
                        End If
                    End If

                    If dr("CVETAB") = "" Then
                        TCVE_TAB.Text = ""
                    Else
                        TCVE_TAB.Text = dr("CVETAB")
                    End If

                    TCVE_TAB_VIAJE.Text = dr("CVE_TAB_RUTA")

                    If dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 1 Then
                        RadCargado.Checked = True
                        RadVacio.Checked = False
                    Else
                        RadCargado.Checked = False
                        RadVacio.Checked = True
                    End If
                    STATUS_VIA = dr("STATUS_VIA")

                    Try 'GCCAT_STATUS_UNIDADES 
                        LtStatus.Text = BUSCA_CAT("Estatus Viaje", STATUS_VIA)
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If dr("STATUS") = "C" Then
                        STATUS_CANCELADO = True
                        LtStatus.Text = "Cancelado"
                    End If

                    DESPLEGAR_TAB_RUTAS(LtCVE_VIAJE.Text)
                    DESPLEGAR_GASTOS_VIAJE(LtCVE_VIAJE.Text, dr("STATUS_VIA"))
                    DESPLEGAR_GASTOS_VALES(LtCVE_VIAJE.Text, dr("STATUS_VALE"))
                Else
                    'BUSCA SI NO EXISTE EN LA TABLA GCASIGNACION_VIAJE 
                    LtCVE_VIAJE.Text = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                    LtCVE_VIAJE.Tag = ""
                End If
                dr.Close()

                TCVE_DOC.Enabled = False
                TCVE_TRACTOR.Focus()


            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        DERECHOS()

        If STATUS_CANCELADO Or STATUS_VIA = 3 Or STATUS_VIA = 5 Then

            Try
                For Each c As Control In Pag1.Controls
                    If TypeOf c Is TextBox Then
                        c.BackColor = Color.LightYellow
                        c.ForeColor = Color.Black
                        c.Enabled = False
                    End If
                    If TypeOf c Is Button Then
                        c.Enabled = False
                    End If
                Next
            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            For Each c As Control In Box1.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box2.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box4.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box5.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box6.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box7.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box8.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box9.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            For Each c As Control In Box10.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next

            Try
                BarGrabar.Enabled = False

                BtnPedido.Enabled = False
                BtnContrato.Enabled = False
                BtnCLAVE_REM.Enabled = False
                BtnCLAVE_DEST.Enabled = False
                BtnOper.Enabled = False
                BtnTractor.Enabled = False
                BtnTanque1.Enabled = False
                BtnTanque2.Enabled = False
                BtnDolly.Enabled = False
                TOBS.Enabled = False
            Catch ex As Exception
            End Try
        Else
            If TCVE_DOC.Text.Trim.Length > 0 Then
                BtnPedido.Enabled = False
            Else
                BtnPedido.Enabled = True
            End If
        End If

        If VALOR_DECLA_DESDE_SAE = 0 Then
            If FACTOR_IEPS = 0 Then
                MsgBox("El factor no a sido capturado, verifique por favor")
            End If
        End If

    End Sub
    Private Function BUSCAR_FECHA_EN_PEDIDOS(fFECHA As String, fCVE_DOC As String) As Date
        Dim FECH As Date = Now
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT " & IIf(fFECHA = "CARGA", "FECHA_CARGA", "FECHA_DESCARGA") & " FROM GCPEDIDOS WHERE CVE_DOC = '" & fCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        FECH = dr(0)
                    End If
                End Using
            End Using
            Return FECH
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Return FECH
        End Try
    End Function
    Sub OBTENER_FOLIOS()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIP_DOC,'') AS TIPO_DOC, ISNULL(SERIE,'') AS SERIE1, ISNULL(ULT_DOC,0) AS ULTDOC FROM GCFOLIOS
                WHERE TIP_DOC = 'A' OR TIP_DOC = 'AG' OR TIP_DOC = 'AV'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read
                        Select Case dr("TIPO_DOC")
                            Case "A"
                                SERIE_A = dr("SERIE1")
                                FOLIO_A = dr("ULTDOC") + 1
                            Case "AG"
                                SERIE_AG = dr("SERIE1")
                                FOLIO_AG = dr("ULTDOC") + 1
                            Case "AV"
                                SERIE_AV = dr("SERIE1")
                                FOLIO_AV = dr("ULTDOC") + 1
                                If SERIE_AV = "STAND." Then
                                    SERIE_AV = ""
                                End If
                        End Select
                    Loop
                End Using
            End Using
        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DERECHOS()
        If Not pwPoder Then
            Try
                BarGrabar.Visible = False
                BarImprimirBitacoraViaje.Visible = False
                BarImprimirCartasPorte.Visible = False
            Catch ex As Exception
            End Try
            Try
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    (CLAVE >= 22000 AND CLAVE < 22990 OR CLAVE >= 222000 AND CLAVE < 222400)"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 22040  'GRABAR VIAJE
                                    BarGrabar.Visible = True
                                Case 22050  'DATOS GENERALES
                                Case 222050 'CONSULTAR DATOS GENERALES
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Pag1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box1)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box2)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box4)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box5)
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box9)
                                Case 222060 'MODIFICA DATOS GENERALES

                                Case 22070  'OBSERVACIONES VIAJE
                                Case 222070 'CONSULTAR OBSERVACIONES VIAJE
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box7)


                                Case 222080 'MODIFICA OBSERVACIONES VIAJE
                                Case 222090 'CONSULTAR GASTOS DE VIAJE
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box8)
                                Case 222100 'MODIFICA OBSERVACIONES VIAJE


                                Case 22080  'GASTOS DE CIAJE

                                Case 22090  'DATOS DE LA BITACORA
                                Case 222110 'CONSULTAR DATOS DE LA BITACORA
                                    SET_ALL_CONTROL_READ_AND_ENABLED(Box10)
                                Case 222120 'MODIFICA DATOS DE LA BITACORA


                                Case 22100  'IMPRIMIR BITACORA DE VIAJE
                                    BarImprimirBitacoraViaje.Visible = True
                                Case 22110  'IMPIRMIR CARTA PORTE
                                    BarImprimirCartasPorte.Visible = True
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
    Sub DESPLEGAR_TAB_RUTAS(fCVE_CON As String)

        Dim NewStyle1 As CellStyle
        NewStyle1 = FgR.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True

        FgR.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, T.CVE_RUTA, P1.CIUDAD AS ORIG, 
                    P2.CIUDAD AS DEST, ISNULL(C.CLAVE,'') AS CLIE, NOMBRE, T.KM_RECO, T.COSTO_CASETAS, T.FLETE, T.SUELDO_OPER, T.RENDIMIENTO, T.P_X_LITRO,
                    T.LITROS_RUTA, T.COSTO_DISEL, (CASE T.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, T.EJES
                    FROM GCASIGNACION_VIAJE_TAB_RUTAS T
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = T.CLIENTE
                    LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = D.CVE_PLA1
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = D.CVE_PLA2
                    WHERE CVE_VIAJE = '" & fCVE_CON & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgR.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("FECHA") & vbTab & dr("T_UNI") & vbTab & dr("CVE_RUTA") & vbTab &
                                   dr("ORIG") & vbTab & dr("DEST") & vbTab & dr("CLIE") & vbTab & dr("NOMBRE") & vbTab & dr("KM_RECO") & vbTab &
                                   dr("COSTO_CASETAS") & vbTab & dr("EJES") & vbTab & dr("FLETE") & vbTab & dr("SUELDO_OPER") & vbTab &
                                   dr("RENDIMIENTO") & vbTab & dr("P_X_LITRO") & vbTab & dr("LITROS_RUTA") & vbTab & dr("COSTO_DISEL") & vbTab &
                                   dr("T_VIAJE"))
                        LtRuta1.Text = dr("ORIG") & "-" & dr("DEST")
                        FgR.Rows(0).Style = NewStyle1
                        FgR.Rows(FgR.Rows.Count - 1).Style = NewStyle1
                    End While
                    FgR.AutoSizeRows()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_GASTOS_VIAJE(fCVE_VIAJE As String, fST_GASTOS_VIAJE As Integer)
        Dim STATUS_VIAJES As String

        STATUS_VIAJES = OBTENER_STATUS_GASTOS_VIAJE(fST_GASTOS_VIAJE)

        FgG.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_OPER, CVE_GAV, FOLIO, convert(varchar, GV.FECHAELAB, 103) AS FECHA_G, CVE_NUM, IMPORTE, DESCR, 
                    ISNULL(ST_GASTOS,'EDICION') AS ST_GAS, UUID, CVE_LIQ,
                    CASE WHEN ISNULL(TIPO_PAGO, -1) = -1 THEN '' WHEN ISNULL(TIPO_PAGO, 0) = 0 THEN 'TRANSFERENCIA' ELSE 'EFECTIVO' END AS TPAGO
                    FROM GCASIGNACION_VIAJE_GASTOS GV
                    LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                    WHERE CVE_VIAJE = '" & fCVE_VIAJE & "' AND ISNULL(GV.STATUS,'A') <> 'C' ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgG.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("FECHA_G") & vbTab & dr("CVE_NUM") & vbTab & dr("DESCR") & vbTab &
                                    dr("IMPORTE") & vbTab & dr("FOLIO") & vbTab & dr("ST_GAS") & vbTab & "S" & vbTab & dr("UUID") & vbTab &
                                    dr("TPAGO") & vbTab & "" & vbTab & dr("CVE_LIQ"))
                    End While
                End Using
                FgG.AutoSizeRows()
            End Using
        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_GASTOS_VALES(fCVE_VIAJE As String, fCVE_ST_VALE As Integer)
        Dim STATUS_VALES As String, FOLIO_TRASPASO As String, s As String

        STATUS_VALES = OBTENER_STATUS_VALES_VIAJE(fCVE_ST_VALE)

        Try
            FgV.Rows.Count = 1

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, GV.FECHA, GV.FECHA_TRASPASO, GV.CVE_GAS, GV.LITROS, GV.LITROS_REALES, 
                    GV.P_X_LITRO, GV.SUBTOTAL, GV.IVA, GV.IEPS, GV.IMPORTE, G.DESCR, GV.FACTURA, ISNULL(GV.ST_VALES,'EDICION') AS ST_VAL, 
                    OBS, UUID, CVE_LIQ
                    FROM GCASIGNACION_VIAJE_VALES GV 
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                    WHERE GV.CVE_VIAJE = '" & fCVE_VIAJE & "' AND ISNULL(GV.STATUS,'A') <> 'C' ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        FOLIO_TRASPASO = ES_FOLIO_TRASPASO(dr("FOLIO"))

                        s = dr("FOLIO") & vbTab '1
                        s &= dr("FECHA") & vbTab '2
                        s &= dr("FECHA_TRASPASO") & vbTab '3
                        s &= dr("CVE_GAS") & vbTab '4
                        s &= dr("DESCR") & vbTab '5
                        s &= dr("LITROS") & vbTab '6
                        s &= dr("LITROS_REALES") & vbTab '7
                        s &= dr("P_X_LITRO") & vbTab '8
                        s &= dr("SUBTOTAL") & vbTab '9
                        s &= dr("IVA") & vbTab '10
                        s &= dr("IEPS") & vbTab '11
                        s &= dr("IMPORTE") & vbTab '12
                        s &= dr("FACTURA") & vbTab '13
                        s &= "" & vbTab '14
                        s &= dr("ST_VAL") & vbTab '15
                        s &= dr.ReadNullAsEmptyString("OBS") & vbTab '16
                        s &= "N" & vbTab '17
                        s &= dr("UUID") & vbTab '18
                        s &= "" & vbTab '19
                        s &= FOLIO_TRASPASO & vbTab '20
                        s &= dr("CVE_LIQ") '21

                        FgV.AddItem("" & vbTab & s)
                        FOLIO_TRASPASO = FOLIO_TRASPASO
                    End While
                    FgV.AutoSizeRows()
                End Using
            End Using

            FgV.ShowButtons = ShowButtonsEnum.Always
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function ES_FOLIO_TRASPASO(FFOLIO As String) As String
        Dim ESTA_EL_FOLIO As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT FOLIO FROM GCSEG_VALPED WHERE FOLIO = '" & FFOLIO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        ESTA_EL_FOLIO = "Si"
                    End If
                End Using
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
        Return ESTA_EL_FOLIO
    End Function
    Private Sub FrmAsignacionViajeAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                MnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub FrmAsignacionViajeAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_VIAJE As String, CVE_OBS As Long, TIPO_UNI As Integer, CVE_TRANSBORDO As Long = 0, z As Integer = 0, SeGrabo As Boolean = False
        Dim DETEC_ERROR_VIOLATION_KEY As Boolean
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        TORDEN_DE.Focus()

        Try
            For k = 1 To FgG.Rows.Count - 1
                If String.IsNullOrEmpty(FgG(k, 3)) Then
                    z += 1
                End If
            Next
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If z > 0 Then
            MsgBox("Por favor capture el concepto del gasto en gastos e viaje")
            Tab1.SelectedIndex = 3
            Return
        End If
        Try
            If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                MsgBox("El tractor no debe quedar vacio")
                Return
            End If
            If Not RadVacio.Checked Then

                If TCVE_DOC.Text.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione el pedido")
                    Return
                End If
                If Not EXISTE_PEDIDO(TCVE_DOC.Text) Then
                    MsgBox("Pedido inexistente verifique por favor")
                    TCVE_DOC.Select()
                    Return
                End If
            End If

            If TOBS.Text.Trim.Length > 0 Then
                CVE_OBS = Val(TOBS.Tag.ToString)
                CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TOBS.Text)
            Else
                CVE_OBS = 0
            End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If LtCVE_VIAJE.Text = "TRANSBORDO" Then

                CVE_TRANSBORDO = GET_MAX("GCASIGNACION_VIAJE", "CVE_TRANSBORDO")

                CVE_VIAJE = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                DOC_NEW = True

            Else
                If Not IsNothing(LtCVE_VIAJE.Tag) Then
                    If LtCVE_VIAJE.Tag.Trim.Length > 0 Then
                        CVE_VIAJE = LtCVE_VIAJE.Tag
                    Else
                        CVE_VIAJE = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                    End If
                Else
                    CVE_VIAJE = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                End If
            End If
        Catch ex As Exception
            CVE_VIAJE = "00"
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If CVE_VIAJE = "00" Then
                CVE_VIAJE = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
            End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If LtTipoViaje.Text = "Full" Then
            TIPO_UNI = 1
        Else
            TIPO_UNI = 0
        End If

        If DOC_NEW Then
            SQL = "INSERT INTO GCASIGNACION_VIAJE (CVE_VIAJE, CVE_DOC, FECHA, FECHA_CARGA, FECHA_DESCARGA, STATUS, TIPO_UNI, TIPO_VIAJE, CVE_OPER, CVE_CON, 
                CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, CVE_ST_VIA, CVE_ST_UNI, RECOGER_EN, ENTREGAR_EN, CLAVE_O, CLAVE_D, CVE_TAB, RUTA_SEN_VAC, 
                RUTA_SE_CAR, RUTA_FULL_VAC, RUTAL_FULL_CAR, NOTA, CVE_CAP1, CVE_CAP2, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_TAB_VIAJE, CVE_TRANSBORDO, 
                CVE_VIAJE_TRANSBORDO, FECHAELAB, UUID) VALUES (@CVE_VIAJE, @CVE_DOC, @FECHA, @FECHA_CARGA, @FECHA_DESCARGA, 'A', @TIPO_UNI, @TIPO_VIAJE, 
                @CVE_OPER, @CVE_CON, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, '1', '1', @RECOGER_EN, @ENTREGAR_EN, @CLAVE_O, @CLAVE_D, @CVE_TAB, 
                @RUTA_SEN_VAC, @RUTA_SE_CAR, @RUTA_FULL_VAC, @RUTAL_FULL_CAR, @NOTA, @CVE_CAP1, @CVE_CAP2, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, 
                @CVE_TAB_VIAJE, @CVE_TRANSBORDO, @CVE_VIAJE_TRANSBORDO, GETDATE(), NEWID())"
        Else
            SQL = "UPDATE GCASIGNACION_VIAJE Set CVE_DOC = @CVE_DOC, TIPO_UNI = @TIPO_UNI, TIPO_VIAJE = @TIPO_VIAJE, CVE_OPER = @CVE_OPER, 
                CVE_CON = @CVE_CON, CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, CVE_DOLLY = @CVE_DOLLY, 
                RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, CLAVE_O = @CLAVE_O, CLAVE_D  = @CLAVE_D, CVE_TAB = @CVE_TAB, 
                RUTA_SEN_VAC = @RUTA_SEN_VAC, RUTA_SE_CAR = @RUTA_SE_CAR, RUTA_FULL_VAC = @RUTA_FULL_VAC, RUTAL_FULL_CAR = @RUTAL_FULL_CAR, 
                NOTA = @NOTA, CVE_CAP1 = @CVE_CAP1, CVE_CAP2 = @CVE_CAP2, ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, 
                CVE_TAB_VIAJE = @CVE_TAB_VIAJE, CVE_TRANSBORDO = @CVE_TRANSBORDO, FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA 
                WHERE CVE_VIAJE = @CVE_VIAJE "
        End If
        cmd.CommandText = SQL

        For k = 1 To 5
            Try
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = CVE_VIAJE
                cmd.Parameters.Add("@CVE_TRANSBORDO", SqlDbType.Int).Value = CVE_TRANSBORDO
                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = TCVE_DOC.Text
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = TIPO_UNI
                cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(RadCargado.Checked, 1, 0)
                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = tCVE_TANQUE1.Text
                cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = TCVE_DOLLY.Text
                cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = TCVE_TAB.Text
                cmd.Parameters.Add("@RUTA_SEN_VAC", SqlDbType.VarChar).Value = TRUTA_SEN_VAC.Text
                cmd.Parameters.Add("@RUTA_SE_CAR", SqlDbType.VarChar).Value = TRUTA_SE_CAR.Text
                cmd.Parameters.Add("@RUTA_FULL_VAC", SqlDbType.VarChar).Value = TRUTA_FULL_VAC.Text
                cmd.Parameters.Add("@RUTAL_FULL_CAR", SqlDbType.VarChar).Value = TRUTAL_FULL_CAR.Text
                cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = TNOTA.Text
                cmd.Parameters.Add("@CVE_CAP1", SqlDbType.VarChar).Value = LtCartaPorte.Text
                cmd.Parameters.Add("@CVE_CAP2", SqlDbType.VarChar).Value = IIf(LtCartaPorte2.Text.Trim.Length = 0, "", LtCartaPorte2.Text)
                cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                If LtCVE_VIAJE.Text = "TRANSBORDO" Then
                    cmd.Parameters.Add("@CVE_VIAJE_TRANSBORDO", SqlDbType.VarChar).Value = LtCVE_VIAJE.Tag
                Else
                    cmd.Parameters.Add("@CVE_VIAJE_TRANSBORDO", SqlDbType.VarChar).Value = ""
                End If
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
                SeGrabo = True
                Exit For
            Catch ex As SqlException
                ' Log the original exception here

                For Each sqlError As SqlError In ex.Errors

                    BITACORASQL(sqlError.Number & ", " & sqlError.ToString)

                    Select Case sqlError.Number
                        Case 207 ' 207 = InvalidColumn
                            'do your Stuff here
                            Exit Select
                        Case 547 ' 547 = (Foreign) Key violation
                            'do your Stuff here
                            DETEC_ERROR_VIOLATION_KEY = True
                            Exit Select
                        Case 2601, 2627 ' 2601 = (Primary) key violation
                            'do your Stuff here
                            DETEC_ERROR_VIOLATION_KEY = True
                            Exit Select
                        Case 3621
                            'The statement has been terminated.
                        Case Else                        'do your Stuff here
                            Exit Select
                    End Select
                Next

            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If Valida_Conexion() Then
                If DETEC_ERROR_VIOLATION_KEY Then
                    Try
                        CVE_VIAJE = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                    Catch ex As Exception
                        Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                Threading.Thread.Sleep(3000)
                MsgBox("Problemas de comunicación vuelva a intentarlo por favor")
                Return
            End If
        Next

        MsgBox(CVE_VIAJE)

        'If DOC_NEW Then
        'GRABAR_GASTOS_AUTO(CVE_VIAJE)
        'GRABAR_VALES_AUTO(CVE_VIAJE)
        'Else
        GRABAR_GASTOS(CVE_VIAJE)
        GRABAR_VALES(CVE_VIAJE)
        'End If

        GRABAR_TAB_RUTA()

        'FIN FOR DE GRABADO POR SI HAY ERROR
        If SeGrabo Then
            SeDesplega = True
            Try
                If LtCVE_VIAJE.Text = "TRANSBORDO" Then
                    If TCVE_DOC.Text.Trim.Length > 0 Then
                        SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_CAP1 = '', CVE_CAP2 = '', 
                            CVE_VIAJE_TRANSBORDO = '" & CVE_VIAJE & "', CVE_DOC = ''
                            WHERE CVE_VIAJE = '" & LtCVE_VIAJE.Tag & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                LtCVE_VIAJE.Text = CVE_VIAJE
                                LtCVE_VIAJE.Tag = CVE_VIAJE
                            End If
                        End Using
                    End If

                    If LtCVE_VIAJE.Text.Trim.Length > 0 Or LtCVE_VIAJE.Tag.ToString.Trim.Length > 0 Then
                    End If
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TCVE_DOC.Text.Trim.Length > 0 Then
                    SQL = "UPDATE GCPEDIDOS SET CVE_VIAJE = '" & CVE_VIAJE & "' WHERE CVE_DOC = '" & TCVE_DOC.Text & "'"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                    End Using
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If LtCartaPorte.Text.Trim.Length > 0 Then
                    SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = '" & CVE_VIAJE & "' WHERE CVE_FOLIO = '" & LtCartaPorte.Text & "'"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                    End Using
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If LtCartaPorte2.Text.Trim.Length > 0 Then
                    SQL = "UPDATE GCCARTA_PORTE SET CVE_VIAJE = '" & CVE_VIAJE & "' WHERE CVE_FOLIO = '" & LtCartaPorte2.Text & "'"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                    End Using
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            GRABA_BITA(CVE_VIAJE, TCVE_DOC.Text, 0, "V", "Se agregó o edito asginación de viaje", LtCartaPorte.Text)

            Try
                If LTractor.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TRACTOR.Text <> LTractor.Tag Then
                        GRABA_BITA(CVE_VIAJE, TCVE_DOC.Text, 0, "V", "Se cambio la unidad " & TCVE_TRACTOR.Text & " por " & LTractor.Tag, LtCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LTanque1.Tag.ToString.Trim.Length > 0 Then
                    If tCVE_TANQUE1.Text <> LTanque1.Tag Then
                        GRABA_BITA(CVE_VIAJE, TCVE_DOC.Text, 0, "V", "Se cambio la unidad " & tCVE_TANQUE1.Text & " por " & LTanque1.Tag, LtCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LTanque2.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TANQUE2.Text <> LTanque2.Tag Then
                        GRABA_BITA(CVE_VIAJE, TCVE_DOC.Text, 0, "V", "Se cambio la unidad " & TCVE_TANQUE2.Text & " por " & LTanque2.Tag, LtCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If LDolly.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_DOLLY.Text <> LDolly.Tag Then
                        GRABA_BITA(CVE_VIAJE, TCVE_DOC.Text, 0, "V", "Se cambio la unidad " & TCVE_DOLLY.Text & " por " & LDolly.Tag,
                                  LtCVE_VIAJE.Text, LtCartaPorte.Text, "FtoF")
                    End If
                End If
                If TCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_O.Tag <> TCLAVE_O.Text Then
                        GRABA_BITA("", LtCartaPorte.Text, 0, "V", "Se cambio el cliente operativo " & TCLAVE_O.Tag & " por " & TCLAVE_O.Text, LtCVE_VIAJE.Text, TCVE_DOC.Text, "FtoF")
                    End If
                End If
                If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                        GRABA_BITA("", LtCartaPorte.Text, 0, "V", "Se cambio el cliente operativo " & TCLAVE_D.Tag & " por " & TCLAVE_D.Text, LtCVE_VIAJE.Text, TCVE_DOC.Text, "FtoF")
                    End If
                End If
                If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                    If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                        GRABA_BITA("", LtCartaPorte.Text, 0, "V", "Se cambio recoger en " & TRECOGER_EN.Tag & " por " & TRECOGER_EN.Text,
                                           LtCVE_VIAJE.Text, TCVE_DOC.Text, "FtoF")
                    End If
                End If
                If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                    If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                        GRABA_BITA("", LtCartaPorte.Text, 0, "V", "Se cambio entregar en " & TENTREGAR_EN.Tag & " por " & TENTREGAR_EN.Text,
                                           LtCVE_VIAJE.Text, TCVE_DOC.Text, "FtoF")
                    End If
                End If
                If TCVE_OPER.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_OPER.Tag <> TCVE_OPER.Text Then
                        GRABA_BITA("", LtCartaPorte.Text, 0, "V", "Se cambio el operador " & TCVE_OPER.Tag & " por " & TCVE_OPER.Text,
                                           LtCVE_VIAJE.Text, TCVE_DOC.Text, "FtoF")
                    End If
                End If
                LTractor.Tag = TCVE_TRACTOR.Text
                LTanque1.Tag = tCVE_TANQUE1.Text
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

            Try
                If LtCVE_VIAJE.Tag.ToString.Trim.Length = 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCFOLIOS SET ULT_DOC = " & FOLIO_A & " WHERE TIP_DOC = 'A' AND 
                             SERIE = '" & IIf(SERIE_A = "" Or SERIE_A = "STAND.", "STAND.", SERIE_A) & "'"
                        cmd2.CommandText = SQL
                        cmd2.ExecuteNonQuery()
                    End Using
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            DOC_NEW = False
            LtCVE_VIAJE.Tag = CVE_VIAJE

            BarImprimirBitacoraViaje.Enabled = True
            If LtCartaPorte.Text.Trim.Length > 0 Or LtCartaPorte2.Text.Trim.Length > 0 Then
                BarImprimirCartasPorte.Enabled = True
            End If

            MsgBox("El viaje " & CVE_VIAJE & " se grabo correctamente")
            Tab1.SelectedIndex = 0
        Else
            MsgBox("No se logro grabar la asignación de viaje")
        End If

    End Sub
    Sub CARGAR_GASTOS_AUTO()
        Dim CVE_FOLIO As String, CVE_GAS As Integer, IMPORTE As Decimal = 0, GAS_DESCR As String = ""

        Try
            If TCVE_CON.Text.Trim.Length > 0 Then

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(F.CVE_GAS,0) AS CVEGAS, ISNULL(IMPORTE_GASTO,0) AS IMPORTE, C.DESCR
                            FROM GCTAB_RUTAS_F F
                            LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = F.CVE_GAS
                            WHERE CVE_CON = '" & TCVE_CON.Text & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CVE_GAS = dr("CVEGAS")
                                IMPORTE = dr("IMPORTE")
                                GAS_DESCR = dr.ReadNullAsEmptyString("DESCR")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try

                If CVE_GAS > 0 Then

                    CVE_FOLIO = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")
                    'FgG.Rows.Count = 1

                    For k = FgG.Rows.Count - 1 To 1 Step -1
                        If FgG(k, 11) = TCVE_DOC.Text Then
                            FgG.RemoveItem(k)
                        End If
                    Next

                    FgG.AddItem("" & vbTab & CVE_FOLIO & vbTab & FECHA.Value & vbTab & CVE_GAS & vbTab & GAS_DESCR & vbTab & IMPORTE & vbTab &
                                CVE_FOLIO & vbTab & "EDICION" & vbTab & "S" & vbTab & " " & vbTab & "TRANSFERENCIA" & vbTab & TCVE_DOC.Text)
                End If
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_VALES_AUTO()
        Dim CVE_FOLIO As Long, CVE_GAV As String = "", LITROS As Decimal = 0, IMPORTE_GAS As Decimal
        Dim AUTO_SENC_LTS As Decimal = 0, P4_SENC_LTS As Decimal = 0, FULL_AUTO_LTS As Decimal = 0, FULL_P4_LTS As Decimal = 0
        Dim CVE_REND As Integer = -1, SIGUE As Boolean = True, LITROS_OK As Decimal = 0, DESCR As String = ""

        If TCVE_CON.Text.Trim.Length > 0 Then
            Try
                SQL = "SELECT C.CVE_CON, R.CVE_GASOL, R.LITROS_RUTA, C.IMPORTE_GAS, R.AUTO_SENC_LTS, R.P4_SENC_LTS, R.FULL_AUTO_LTS, R.FULL_P4_LTS, G.DESCR
                    FROM GCCONTRATO C
                    LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = C.CVE_CON
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = R.CVE_GASOL
                    WHERE C.CVE_CON = '" & TCVE_CON.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_GAV = dr.ReadNullAsEmptyString("CVE_GASOL")
                            LITROS = dr.ReadNullAsEmptyDecimal("LITROS_RUTA")
                            IMPORTE_GAS = dr.ReadNullAsEmptyDecimal("IMPORTE_GAS")
                            AUTO_SENC_LTS = dr.ReadNullAsEmptyDecimal("AUTO_SENC_LTS")
                            P4_SENC_LTS = dr.ReadNullAsEmptyDecimal("P4_SENC_LTS")
                            FULL_AUTO_LTS = dr.ReadNullAsEmptyDecimal("FULL_AUTO_LTS")
                            FULL_P4_LTS = dr.ReadNullAsEmptyDecimal("FULL_P4_LTS")
                            DESCR = dr.ReadNullAsEmptyString("DESCR")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SQL = "SELECT ISNULL(CVE_REND,-1) AS CVEREND
                    FROM GCUNIDADES WHERE CLAVEMONTE = '" & TCVE_TRACTOR.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_REND = dr.ReadNullAsEmptyString("CVEREND")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                'LtAUTO_SENC_LTS     AUTO_SENC_LTS
                'LtP4_SENC_LTS       P4_SENC_LTS

                'LtFULL_AUTO_LTS     FULL_AUTO_LTS
                'LtFULL_P4_LTS       FULL_P4_LTS

                'CboRendimiento.Items.Add("Autónomo")
                'CboRendimiento.Items.Add("P4")
                If LITROS = 0 And AUTO_SENC_LTS = 0 And P4_SENC_LTS = 0 And FULL_AUTO_LTS = 0 And FULL_P4_LTS = 0 Then
                    'Cuando no hay litros ni en rutas ni en contrato no generar vale de diesel.
                    SIGUE = False
                Else
                    If AUTO_SENC_LTS = 0 And P4_SENC_LTS = 0 And FULL_AUTO_LTS = 0 And FULL_P4_LTS = 0 Then
                        'si en rutas todas tienen cero, utilizar los litros de Contrato. 
                        If LITROS > 0 Then
                            LITROS_OK = LITROS
                        Else
                            SIGUE = False
                        End If
                    Else
                        'Si en rutas con un valor en litros mayor a 0 pero no hay tipo de rendimiento utilizar el primer valor.
                        If CVE_REND = -1 Then
                            If AUTO_SENC_LTS > 0 Then
                                LITROS_OK = LITROS
                            Else
                                If P4_SENC_LTS > 0 Then
                                    LITROS_OK = LITROS
                                Else
                                    If FULL_AUTO_LTS > 0 Then
                                        LITROS_OK = LITROS
                                    Else
                                        LITROS_OK = FULL_P4_LTS
                                    End If
                                End If
                            End If
                        Else
                            If CVE_REND = 0 Then 'AUTONOMO
                                If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                    LITROS_OK = FULL_AUTO_LTS 'LtTipoViaje.Text = "Full"
                                Else
                                    LITROS_OK = AUTO_SENC_LTS 'LtTipoViaje.Text = "Sencillo"
                                End If
                            Else 'P4
                                If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                    LITROS_OK = FULL_P4_LTS 'LtTipoViaje.Text = "Full"
                                Else
                                    LITROS_OK = P4_SENC_LTS 'LtTipoViaje.Text = "Sencillo"
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If SIGUE Then
                Try
                    Dim s As String

                    CVE_FOLIO = GET_MAX_TRY("GCASIGNACION_VIAJE_VALES", "FOLIO")

                    For k = FgV.Rows.Count - 1 To 1 Step -1
                        If FgV(k, 19) = TCVE_DOC.Text Then
                            FgV.RemoveItem(k)
                        End If
                    Next

                    s = Format(CVE_FOLIO, "0000000000") & vbTab '1
                    s &= FECHA.Value & vbTab '2
                    s &= "" & vbTab '3   FECHA TRANS
                    s &= CVE_GAV & vbTab '4
                    s &= DESCR & vbTab '5
                    s &= Math.Round(LITROS_OK, 4) & vbTab '6
                    s &= 0 & vbTab '7
                    s &= 0 & vbTab '8
                    s &= 0 & vbTab '9
                    s &= 0 & vbTab '10
                    s &= 0 & vbTab '11
                    s &= 0 & vbTab '12
                    s &= "" & vbTab '13
                    s &= "" & vbTab '14
                    s &= "" & vbTab '15
                    s &= "VALE GENERADO AUTOMATICAMENTE" & vbTab '16
                    s &= "S" & vbTab '17
                    s &= "" & vbTab '18
                    s &= TCVE_DOC.Text & vbTab '19
                    s &= " " '20  BANDERA SI SE CONVIRTIO EN TRANS

                    FgV.AddItem("" & vbTab & s)

                Catch ex As Exception
                    Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
    End Sub

    Sub GRABAR_TAB_RUTA()
        If Not Valida_Conexion() Then
            Return
        End If

        If FgR.Row > 0 Then
            Dim cmd As New SqlCommand With {
                .Connection = cnSAE
            }

            SQL = "UPDATE GCASIGNACION_VIAJE_TAB_RUTAS SET CVE_VIAJE = @CVE_VIAJE, CVE_TAB = @CVE_TAB, FECHA = @FECHA, TIPO_UNI = @TIPO_UNI, 
                CVE_RUTA = @CVE_RUTA, ORIGEN = @ORIGEN, DESTINO = @DESTINO, CLIENTE = @CLIENTE, KM_RECO = @KM_RECO, COSTO_CASETAS = @COSTO_CASETAS, 
                FLETE = @FLETE, SUELDO_OPER = @SUELDO_OPER, RENDIMIENTO = @RENDIMIENTO, P_X_LITRO = @P_X_LITRO, LITROS_RUTA = @LITROS_RUTA, 
                COSTO_DISEL = @COSTO_DISEL, TIPO_VIAJE = @TIPO_VIAJE, EJES = @EJES, ST_TAB_RUTAS = @ST_TAB_RUTAS
                WHERE CVE_CON = @CVE_CON
                IF @@ROWCOUNT = 0
                INSERT INTO GCASIGNACION_VIAJE_TAB_RUTAS (CVE_VIAJE, CVE_CON, CVE_TAB, FECHA, TIPO_UNI, CVE_RUTA, ORIGEN, DESTINO, CLIENTE, KM_RECO, 
                COSTO_CASETAS, FLETE, SUELDO_OPER, RENDIMIENTO, P_X_LITRO, LITROS_RUTA, COSTO_DISEL, TIPO_VIAJE, EJES, ST_TAB_RUTAS, UUID) VALUES(
                @CVE_VIAJE, @CVE_CON, @CVE_TAB, @FECHA, @TIPO_UNI, @CVE_RUTA, @ORIGEN, @DESTINO, @CLIENTE, @KM_RECO, @COSTO_CASETAS, @FLETE, @SUELDO_OPER, 
                @RENDIMIENTO, @P_X_LITRO, @LITROS_RUTA, @COSTO_DISEL, @TIPO_VIAJE, @EJES, @ST_TAB_RUTAS, NEWID())"
            cmd.CommandText = SQL
            Try
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtCVE_VIAJE.Text
                cmd.Parameters.Add("@CVE_CON", SqlDbType.VarChar).Value = TCVE_CON.Text
                cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CONVERTIR_TO_INT(FgR(FgR.Row, 1))
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgR(FgR.Row, 2)
                cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = IIf(FgR(FgR.Row, 3) = "Full", 1, 0)
                cmd.Parameters.Add("@CVE_RUTA", SqlDbType.VarChar).Value = FgR(FgR.Row, 4)
                cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = FgR(FgR.Row, 5)
                cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = FgR(FgR.Row, 6)
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = FgR(FgR.Row, 7)
                cmd.Parameters.Add("@KM_RECO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 9))
                cmd.Parameters.Add("@COSTO_CASETAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 10))
                cmd.Parameters.Add("@EJES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(FgR(FgR.Row, 11))
                cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 12))  'N
                cmd.Parameters.Add("@SUELDO_OPER", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 13)) 'N
                cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 14)) 'N
                cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 15)) 'N
                cmd.Parameters.Add("@LITROS_RUTA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 16)) 'N
                cmd.Parameters.Add("@COSTO_DISEL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgR(FgR.Row, 17)) 'N
                cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(FgR(FgR.Row, 18) = "Cargado", 1, 0)
                cmd.Parameters.Add("@ST_TAB_RUTAS", SqlDbType.VarChar).Value = FgR(FgR.Row, 17).ToString 'N
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub GRABAR_GASTOS(fCVE_VIAJE As String)
        Dim CVE_FOLIO As String = "", UUID As String, FECH As Date, QUERY As String
        Dim FOL_VIA As Long = 0, TIPO_VIAJE As Integer = -1
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        FgG.FinishEditing()

        Try
            'SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET STATUS = 'C' WHERE CVE_VIAJE = '" & fCVE_VIAJE & "'"
            'Using cmd2 As SqlCommand = cnSAE.CreateCommand
            'cmd2.CommandText = SQL
            'returnValue = cmd2.ExecuteNonQuery().ToString
            'If returnValue IsNot Nothing Then
            'If returnValue = "1" Then
            'End If
            'End If
            'End Using
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL2 = "IF EXISTS (SELECT FOLIO FROM GCASIGNACION_VIAJE_GASTOS WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO)
            UPDATE GCASIGNACION_VIAJE_GASTOS SET CVE_OPER = @CVE_OPER, CVE_NUM = @CVE_NUM, IMPORTE = @IMPORTE,
            ST_GASTOS = @ST_GASTOS, TIPO_PAGO = @TIPO_PAGO 
            WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO
        ELSE
            INSERT INTO GCASIGNACION_VIAJE_GASTOS (CVE_VIAJE, STATUS, CVE_OPER, FOLIO, FECHA, CVE_NUM, IMPORTE, FECHAELAB, 
            ST_GASTOS, TIPO_PAGO, UUID) OUTPUT Inserted.UUID 
            VALUES (@CVE_VIAJE,'A', @CVE_OPER, @FOLIO, @FECHA, @CVE_NUM, @IMPORTE, GETDATE(), 
            @ST_GASTOS, @TIPO_PAGO, NEWID())"
        Try
            For k = 1 To FgG.Rows.Count - 1
                If Not String.IsNullOrEmpty(FgG(k, 3)) Then
                    Try                        'FOLIO = VERIFICAR_FOLIO_ASIG_VIA_GASTOS(FgG(k, 1))
                        Try
                            If Not IsNothing(FgG(k, 10)) Then
                                If FgG(k, 10) = "TRANSFERENCIA" Then
                                    TIPO_VIAJE = 0
                                Else
                                    TIPO_VIAJE = 1
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            UUID = FgG(k, 9)
                        Catch ex As Exception
                            UUID = ""
                        End Try
                        Try
                            If UUID.Trim.Length > 0 Then
                                CVE_FOLIO = FgG(k, 1)
                            Else
                                FOL_VIA = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")
                                CVE_FOLIO = FOL_VIA
                            End If
                        Catch ex As Exception
                            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        QUERY = fCVE_VIAJE & ", " & TCVE_OPER.Text & ", " & CVE_FOLIO & FECH & ", " & FgG(k, 3) & ", " &
                            FgG(k, 5) & ", " & FgG(k, 7) & TIPO_VIAJE & " row k " & k

                        Try
                            If IsNothing(FgG(k, 2)) Then
                                FECH = F1.Value
                            Else
                                FECH = FgG(k, 2)
                            End If
                        Catch ex As Exception
                            FECH = F1.Value
                            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & QUERY)
                        End Try

                        cmd.CommandText = SQL2
                        For j = 1 To 5
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = fCVE_VIAJE
                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                            cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FECH
                            cmd.Parameters.Add("@CVE_NUM", SqlDbType.VarChar).Value = FgG(k, 3)
                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgG(k, 5))
                            cmd.Parameters.Add("@ST_GASTOS", SqlDbType.VarChar).Value = FgG(k, 7)
                            cmd.Parameters.Add("@TIPO_PAGO", SqlDbType.SmallInt).Value = TIPO_VIAJE
                            Try
                                returnValue = cmd.ExecuteScalar
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                    FgG(k, 6) = CVE_FOLIO
                                    FgG(k, 9) = returnValue
                                    FgG(k, 8) = "S"
                                End If
                                Exit For
                            Catch ex As Exception
                                Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            FOL_VIA = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")
                            CVE_FOLIO = FOL_VIA
                        Next
                    Catch ex As Exception
                        Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            If FOL_VIA > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCFOLIOS SET ULT_DOC = " & FOL_VIA & " WHERE TIP_DOC = 'AG' AND SERIE = '" & IIf(SERIE_AG = "" Or
                         SERIE_AG = "STAND.", "STAND.", SERIE_AG) & "'"
                    cmd2.CommandText = SQL
                    cmd2.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("45. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_VALES(fCVE_VIAJE As String)
        Dim CVE_GAS As String = "", LITROS As Single = 0, P_X_LITRO As Single = 0, LITROS_REALES As Decimal, SUBTOTAL As Single = 0, IVA As Single = 0, IEPS As Single = 0
        Dim IMPORTE As Single = 0, FACTURA As String = "", OBS As String = "", CVE_FOLIO As String, UUID As String
        Dim z As Integer, SQL1 As String, FECHA_TRASPASO
        Dim FOL_VIA As Long = 0
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        FgV.FinishEditing()

        Try
            SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET STATUS = 'C' WHERE CVE_VIAJE = '" & fCVE_VIAJE & "'"
            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        Try
            z = 0
            For k = 1 To FgV.Rows.Count - 1

                Try
                    UUID = FgV(k, 18)
                Catch ex As Exception
                    UUID = ""
                End Try

                If UUID.Trim.Length > 0 Then
                    SQL1 = "UPDATE GCASIGNACION_VIAJE_VALES SET CVE_OPER = @CVE_OPER, FECHA = @FECHA, CVE_GAS = @CVE_GAS, LITROS = @LITROS, 
                        LITROS_REALES = @LITROS_REALES, P_X_LITRO = @P_X_LITRO, SUBTOTAL = @SUBTOTAL, IVA = @IVA, IEPS = @IEPS, IMPORTE = @IMPORTE, 
                        FACTURA = @FACTURA, ST_VALES = @ST_VALES, STATUS = 'A', OBS = @OBS, FECHA_TRASPASO = @FECHA_TRASPASO
                        OUTPUT INSERTED.UUID
                        WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO"
                Else
                    SQL1 = "INSERT INTO GCASIGNACION_VIAJE_VALES (CVE_VIAJE, STATUS, CVE_OPER, FOLIO, FECHA, FECHA_TRASPASO, CVE_GAS, 
                        LITROS, LITROS_REALES, P_X_LITRO, SUBTOTAL, IVA, IEPS, IMPORTE, FACTURA, FECHAELAB, ST_VALES, OBS, UUID) 
                        OUTPUT Inserted.UUID VALUES(
                        @CVE_VIAJE, 'A', @CVE_OPER, @FOLIO, @FECHA, @FECHA_TRASPASO, @CVE_GAS, @LITROS, @P_X_LITRO, @LITROS_REALES, 
                        @SUBTOTAL, @IVA, @IEPS, @IMPORTE, @FACTURA, GETDATE(), @ST_VALES, @OBS, NEWID())"
                End If
                Try
                    CVE_GAS = IIf(String.IsNullOrEmpty(FgV(k, 4)), "", FgV(k, 4))
                    LITROS = IIf(String.IsNullOrEmpty(FgV(k, 6)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 6)))
                    LITROS_REALES = IIf(String.IsNullOrEmpty(FgV(k, 7)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 7)))
                    P_X_LITRO = IIf(String.IsNullOrEmpty(FgV(k, 8)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 8)))
                    SUBTOTAL = IIf(String.IsNullOrEmpty(FgV(k, 9)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 9)))
                    IVA = IIf(String.IsNullOrEmpty(FgV(k, 10)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 10)))
                    IEPS = IIf(String.IsNullOrEmpty(FgV(k, 11)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 11)))
                    IMPORTE = IIf(String.IsNullOrEmpty(FgV(k, 12)), 0, CONVERTIR_TO_DECIMAL(FgV(k, 12)))
                    FACTURA = IIf(String.IsNullOrEmpty(FgV(k, 13)), "", FgV(k, 13))
                    OBS = IIf(String.IsNullOrEmpty(FgV(k, 16)), "", FgV(k, 16))
                Catch ex As Exception
                    Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    If IsNothing(FgV(k, 3)) Then
                        FECHA_TRASPASO = DBNull.Value
                    ElseIf String.IsNullOrEmpty(FgV(k, 3)) Then
                        FECHA_TRASPASO = DBNull.Value
                    ElseIf IsDate(FgV(k, 3)) Then
                        FECHA_TRASPASO = FgV(k, 3)
                    Else
                        FECHA_TRASPASO = DBNull.Value
                    End If
                Catch ex As Exception
                    Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                For j = 1 To 3
                    Try
                        If UUID.Trim.Length > 0 Then
                            CVE_FOLIO = FgV(k, 1)
                        Else
                            FOL_VIA = GET_MAX_TRY("GCASIGNACION_VIAJE_VALES", "FOLIO")
                            CVE_FOLIO = Format(FOL_VIA, "0000000000")
                        End If

                        cmd.CommandText = SQL1
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = fCVE_VIAJE
                        cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                        cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgV(k, 2)
                        cmd.Parameters.Add("@FECHA_TRASPASO", SqlDbType.Date).Value = FECHA_TRASPASO
                        cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = CVE_GAS
                        cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = Math.Round(LITROS, 4)
                        cmd.Parameters.Add("@LITROS_REALES", SqlDbType.Float).Value = Math.Round(LITROS_REALES, 4)
                        cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = Math.Round(P_X_LITRO, 4)
                        cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL, 4)
                        cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA, 4)
                        cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(IEPS, 4)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 4)
                        cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FACTURA
                        cmd.Parameters.Add("@ST_VALES", SqlDbType.VarChar).Value = FgV(k, 15)
                        cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = OBS
                        Try
                            returnValue = cmd.ExecuteScalar
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                            If UUID.Trim.Length = 0 Then
                                FgV(k, 18) = returnValue
                                FgV(k, 17) = "N"
                                FgV(k, 1) = CVE_FOLIO
                            End If

                            If UUID.Trim.Length = 0 Then
                                'nueva rutina para llevar el seguieiento de pedidos
                                SQL = "INSERT INTO GCSEG_VALPED (CVE_DOCP, STATUS, FOLIO, FECHA_PED, UUID)
                                    VALUES (@CVE_DOCP, 'A', @FOLIO, @FECHA_PED, NEWID())"
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = TCVE_DOC.Text
                                        cmd2.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = CVE_FOLIO
                                        cmd2.Parameters.Add("@FECHA_PED", SqlDbType.Date).Value = FgV(k, 2)
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
                                'FIN SEGUIMIENTO DE PEDIDOS
                            End If

                            Exit For

                        Catch sqlEx As SqlException
                            If sqlEx.Number = 2627 Then
                            End If
                            Bitacora("53. " & sqlEx.Message & vbNewLine & sqlEx.StackTrace)
                        Catch ex As Exception
                            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    Catch ex As Exception
                        Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
                        'MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Next
            If FOL_VIA > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCFOLIOS SET ULT_DOC = " & FOL_VIA & " WHERE TIP_DOC = 'AV' AND
                        SERIE = '" & IIf(SERIE_AV = "" Or SERIE_AV = "STAND.", "STAND.", SERIE_AV) & "'"
                    cmd2.CommandText = SQL
                    cmd2.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function VERIFICAR_EXIST_FOLIO(fCVE_FOLIO As String) As String
        Try
            Dim FOLIO As Long, SIGUE As Boolean = True
            Dim CVE_FOL As String

            FOLIO = StrToNum(fCVE_FOLIO)
            CVE_FOL = SERIE_AV & Format(FOLIO, "0000000000")
            Do While SIGUE
                If EXIST_FOLIO_GASTO_VIAJE(CVE_FOL) Then
                    FOLIO += 1
                    CVE_FOL = SERIE_AV & Format(FOLIO, "0000000000")
                Else
                    SIGUE = False
                End If
            Loop
            Return CVE_FOL
        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Return fCVE_FOLIO
        End Try
    End Function

    Private Function EXIST_FOLIO_GASTO_VIAJE(fCVE_FOL As String) As Boolean
        Dim Exist_folio As Boolean = False
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL2 = "SELECT FOLIO FROM GCASIGNACION_VIAJE_VALES WHERE FOLIO = '" & fCVE_FOL & "'"
                cmd.CommandText = SQL2
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Exist_folio = True
                    End If
                End Using
            End Using
            Return Exist_folio
        Catch ex As Exception
            Return Exist_folio
        End Try
    End Function

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmAsignacionViajeAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Asignación viaje")
        Me.Dispose()
        If SeDesplega Then
            If FORM_IS_OPEN("FrmAsignacionViaje") Then
                FrmAsignacionViaje.DESPLEGAR()
            End If
        End If
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
                        LOper.Text = DESCR
                        LtOp1.Text = TCVE_OPER.Text
                        LtOp2.Text = DESCR
                        LtLicencia.Text = Var6
                        LtVigencia.Text = Var7
                        Var2 = "" : Var4 = "" : Var5 = ""
                    Else
                        MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                        TCVE_OPER.Text = ""
                        LOper.Text = ""
                        LtOp1.Text = ""
                        LtOp2.Text = ""
                        LtLicencia.Text = ""
                        LtVigencia.Text = ""
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_OPER.Select()
                    End If
                Else
                    MsgBox("Operador inexistente")
                    LtOp1.Text = ""
                    LtOp2.Text = ""
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                LtOp1.Text = ""
                LtOp2.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click

        Try
            If TCVE_OPER.Text.Trim <> "" And TCVE_OPER.Text <> "0" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5  'NOMBRE
                LtOp1.Text = Var4
                LtOp2.Text = Var5
                LtLicencia.Text = Var6
                LtVigencia.Text = Var7
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                LtOp1.Text = ""
                LtOp2.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_OPER.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.F2 Then
                BtnOper_Click(Nothing, Nothing)
                Return
            End If
        End If
    End Sub
    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTractor_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            TCVE_OPER.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            tCVE_TANQUE1.Focus()
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Dim CVE_VIAJE As String
                    If UNIDAD_ASIGNADA_LOCAL(1, TCVE_TRACTOR.Text) Then
                        'MsgBox("Esta unidad ya fue asignada verifique por favor")
                        'tCVE_TRACTOR.Text = tCVE_TRACTOR.Tag
                        'Return
                    End If
                    CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(TCVE_TRACTOR.Text)
                    If CVE_VIAJE <> "" Then
                        'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                        'tCVE_TRACTOR.Text = tCVE_TRACTOR.Tag
                        'Return
                    End If
                    Var3 = ""
                    TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text
                    LTractor.Text = DESCR
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
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
                If TCVE_TRACTOR.Tag.ToString.Trim.Length > 0 And Not DOC_NEW Then
                    MsgBox("La unidad no puede puede quedar vacia")
                    TCVE_TRACTOR.Text = TCVE_TRACTOR.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque1_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            TCVE_TRACTOR.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TCVE_TANQUE2.Focus()
        End If
    End Sub
    Private Sub TCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles tCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If tCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    Dim CVE_VIAJE As String
                    If UNIDAD_ASIGNADA_LOCAL(2, tCVE_TANQUE1.Text) Then
                        'MsgBox("Esta unidad ya fue asignada verifique por favor")
                        'tCVE_TANQUE1.Text = tCVE_TANQUE1.Tag
                        'Return
                    End If
                    CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(tCVE_TANQUE1.Text)
                    If CVE_VIAJE <> "" Then
                        'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                        'tCVE_TANQUE1.Text = tCVE_TANQUE1.Tag
                        'Return
                    End If
                    Var3 = ""
                    tCVE_TANQUE1.Tag = tCVE_TANQUE1.Text
                    LTanque1.Text = DESCR
                    If TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TANQUE1.Text = tCVE_TANQUE1.Tag
                End If
            Else
                If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                If tCVE_TANQUE1.Tag.ToString.Trim.Length > 0 And Not DOC_NEW Then
                    MsgBox("La unidad no puede puede quedar vacia")
                    tCVE_TANQUE1.Text = tCVE_TANQUE1.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTanque2_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tCVE_TANQUE1.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TCVE_DOLLY.Focus()
        End If
    End Sub
    Private Sub TCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    Dim CVE_VIAJE As String
                    If UNIDAD_ASIGNADA_LOCAL(3, TCVE_TANQUE2.Text) Then
                        'MsgBox("Esta unidad ya fue asignada verifique por favor")
                        'tCVE_TANQUE2.Text = tCVE_TANQUE2.Tag
                        'Return
                    End If
                    CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(TCVE_TANQUE2.Text)
                    If CVE_VIAJE <> "" Then
                        'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                        'tCVE_TANQUE2.Text = tCVE_TANQUE2.Tag
                        'Return
                    End If
                    Var3 = ""
                    TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text
                    LTanque2.Text = DESCR
                    If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                End If
            Else
                If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                If TCVE_TANQUE2.Tag.Trim.Length > 0 And Not DOC_NEW Then
                    MsgBox("El tipo de unidad es full no puede quedar vacio")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            If TCVE_TRACTOR.Text.Trim <> "" And TCVE_TRACTOR.Text <> "0" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(1, Var4) Then
                    MsgBox("Esta unidad ya fue asignada verifique por favor")
                    'Return
                End If
                Dim CVE_VIAJE As String

                CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                If CVE_VIAJE <> "" Then
                    'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                    TCVE_TRACTOR.Select()
                End If
                If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                    If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                End If

                TCVE_TRACTOR.Text = Var5
                TCVE_TRACTOR.Tag = Var5
                LTractor.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                tCVE_TANQUE1.Focus()
            End If

        Catch Ex As Exception
            Bitacora("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            If tCVE_TANQUE1.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(2, Var4) Then
                    MsgBox("Esta unidad ya fue asignada verifique por favor")
                    'Return
                End If
                Dim CVE_VIAJE As String

                CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                If CVE_VIAJE <> "" Then
                    'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                    tCVE_TANQUE1.Select()
                End If
                LtTipoViaje.Text = "Sencillo"

                tCVE_TANQUE1.Text = Var5
                tCVE_TANQUE1.Tag = Var5
                LTanque1.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("170. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("170. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTanque2_Click(sender As Object, e As EventArgs) Handles BtnTanque2.Click
        Try
            If TCVE_TANQUE2.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(3, Var4) Then
                    'MsgBox("Esta unidad ya fue asignada verifique por favor")
                    'Return
                End If
                Dim CVE_VIAJE As String

                If Var5.Trim.Length > 0 Then
                    CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                    If CVE_VIAJE <> "" Then
                        'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                        TCVE_TANQUE2.Select()
                    End If
                End If
                If tCVE_TANQUE1.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                Else
                    LtTipoViaje.Text = "Sencillo"
                End If
                TCVE_TANQUE2.Text = Var5
                TCVE_TANQUE2.Tag = Var5
                LTanque2.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = ""
                Var5 = ""
                TCVE_TANQUE2.Focus()
            End If

        Catch Ex As Exception
            Bitacora("180. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("180. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnDolly_Click(sender As Object, e As EventArgs) Handles BtnDolly.Click
        Try
            If TCVE_DOLLY.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "3" : Var5 = ""

            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_LOCAL(4, Var4) Then
                    'MsgBox("Esta unidad ya fue asignada verifique por favor")
                    'Return
                End If
                Dim CVE_VIAJE As String

                CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(Var5)
                If CVE_VIAJE <> "" Then
                    'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                    TCVE_DOLLY.Select()
                End If
                TCVE_DOLLY.Text = Var5
                TCVE_DOLLY.Tag = Var5
                LDolly.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_DOLLY.Focus()
            Else
                TCVE_DOLLY.Text = ""
                TCVE_DOLLY.Tag = ""
                LDolly.Text = ""
            End If

        Catch Ex As Exception
            Bitacora("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_DOC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPedido_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_DOC_Validated(sender As Object, e As EventArgs) Handles TCVE_DOC.Validated
        Try
            If TCVE_DOC.Text.Length > 0 Then
                BUSCAR_PEDIDO(TCVE_DOC.Text)

            Else
                LIMPIAR()
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnPedido_Click(sender As Object, e As EventArgs) Handles BtnPedido.Click
        Try
            Dim CVE_VIAJE As String

            Var2 = "Pedidos"
            Var3 = "" : Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_DOC.Text = Var4

                TCVE_DOC.Tag = Var4
                'BUSCAR_PEDIDO
                CVE_VIAJE = PEDIDO_ASIGNADO(Var4)
                If CVE_VIAJE = "" Then

                    BUSCAR_PEDIDO(TCVE_DOC.Text)
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_CON.Focus()
                Else
                    MsgBox("El pedido ya fue asignado en el viaje " & CVE_VIAJE)
                    Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                    TCVE_DOC.Text = ""
                    TCVE_DOC.Select()
                End If
            End If
        Catch Ex As Exception
            Bitacora("380. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("380. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_PEDIDO(fCVE_DOC As String)
        If fCVE_DOC.Trim.Length = 0 Then
            Return
        End If
        Try
            SQL = "SELECT P.CVE_DOC, P.CVE_CLIE, ISNULL(P.CVE_CON,'') AS CVECON, P.STATUS, P.CVE_ART, ISNULL(I.DESCR,'') AS DESCR_PRODUCTO, 
                ISNULL(P1.CIUDAD,'') AS DESCR_ORIGEN, ISNULL(P2.CIUDAD,'') AS DESCR_DESTINO, P.FECHA, P.CVE_ORIGEN, P.CVE_DESTINO, P.FECHA_CARGA, 
                P.FECHA_DESCARGA, ISNULL(NOMBRE,'') AS NOMB, ISNULL(CALLE,'') AS DIRE, ISNULL(NUMINT,'') AS NOINT, ISNULL(NUMEXT,'') AS NOEXT, 
                ISNULL(RFC,'') AS RF, ISNULL(CODIGO,'') AS CP, ISNULL(COLONIA,'') AS COLO, ISNULL(C.MUNICIPIO,'') AS MUNI, ISNULL(ESTADO,'') AS EST, 
                CLAVE_O, CLAVE_D, RECOGER_EN, ENTREGAR_EN, CVE_OPER, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, NUM_TALON, NUM_TALON2, ORDEN_DE, EMBARQUE, 
                CARGA_ANTERIOR, CVE_TAB_VIAJE, R.CVE_TAB
                FROM GCPEDIDOS P
                LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_CON = P.CVE_CON
                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = P.CVE_CLIE
                LEFT JOIN GCPRODUCTOS I ON I.CVE_PROD = P.CVE_ART
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = P.CVE_ORIGEN
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = P.CVE_DESTINO
                WHERE P.CVE_DOC = '" & fCVE_DOC & "'"  'CVE_DOC DE GCASIGNACION_VIAJE

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCVE_CON.Text = dr("CVECON")

                        F1.Value = dr("FECHA_CARGA").ToString
                        F2.Value = dr("FECHA_DESCARGA").ToString

                        Try
                            TORDEN_DE.Text = dr.ReadNullAsEmptyString("ORDEN_DE")
                            TEMBARQUE.Text = dr.ReadNullAsEmptyString("EMBARQUE")
                            TCARGA_ANTERIOR.Text = dr.ReadNullAsEmptyString("CARGA_ANTERIOR")

                            TCVE_TAB_VIAJE.Text = dr.ReadNullAsEmptyString("CVE_TAB")
                        Catch ex As Exception
                        End Try

                        LtCartaPorte.Text = dr.ReadNullAsEmptyString("NUM_TALON")
                        LtCartaPorte2.Text = dr.ReadNullAsEmptyString("NUM_TALON2")

                        TCLAVE_O.Text = dr("CLAVE_O").ToString.Trim
                        TCLAVE_D.Text = dr("CLAVE_D").ToString.Trim

                        DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                        DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)

                        TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                        TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                        TRECOGER_EN.Tag = dr("RECOGER_EN").ToString
                        TENTREGAR_EN.Tag = dr("ENTREGAR_EN").ToString

                        LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)

                        TCVE_OPER.Text = dr.ReadNullAsEmptyInteger("CVE_OPER")
                        If TCVE_OPER.Text = "0" Then
                            TCVE_OPER.Text = ""
                        End If

                        LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                        LtLicencia.Text = Var6
                        LtVigencia.Text = Var7

                        TCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                        tCVE_TANQUE1.Text = dr.ReadNullAsEmptyString("CVE_TANQUE1")
                        TCVE_TANQUE2.Text = dr.ReadNullAsEmptyString("CVE_TANQUE2")

                        If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                            If tCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                LtTipoViaje.Text = "Full"
                            Else
                                LtTipoViaje.Text = "Sencillo"
                            End If
                        End If

                        DESPLEGAR_CONTRATO(TCVE_CON.Text)
                    Else
                        LIMPIAR()

                        MsgBox("Pedido inexistente verifique por favor")

                        TCVE_DOC.Text = ""

                        TCVE_DOC.Select()

                    End If
                    dr.Close()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgG.CellButtonClick
        Try
            If FgG.Row > 0 And e.Col = 3 Then

                If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                    FgG(FgG.Row, 7) = "ACEPTADO" Then
                    FgG.Col = 1
                    'MsgBox("2. La partida ya fue cerrada no se puede modificar")
                    Return
                End If

                Var2 = "GCConc"
                Var4 = "" : Var5 = ""
                FrmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    FgG(FgG.Row, 3) = Var4
                    FgG(FgG.Row, 4) = Var5
                    Var2 = "" : Var4 = "" : Var5 = ""
                    FgG.Col = 5
                    FgG.StartEditing()
                End If
            End If
        Catch Ex As Exception
            Bitacora("775. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("775 " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGastosAlta_Click(sender As Object, e As EventArgs) Handles BtnGastosAlta.Click
        Try
            Dim Sigue As Boolean = True, Fol As Long = 0
            Dim STATUS_VIAJE As String

            If DOC_NEW Then
                MsgBox("No es posible agregar un gasto hasta que el viaje se grabe")
                Return
            End If

            OBTENER_FOLIOS()

            For k = 1 To FgG.Rows.Count - 1
                If String.IsNullOrEmpty(FgG(k, 4)) Then
                    Sigue = False
                Else
                    If FgG(k, 8) <> "S" Then
                        Fol += 1
                    End If
                End If
            Next


            If Sigue Or FgG.Rows.Count = 1 Then

                STATUS_VIAJE = OBTENER_STATUS_GASTOS_VIAJE(1)

                FOLIO_AG = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")

                FgG.AddItem("" & vbTab & (FOLIO_AG + Fol) & vbTab & DateTime.Now.ToString("dd/MM/yyyy") & vbTab & "" & vbTab & "" & vbTab &
                            "0" & vbTab & "" & vbTab & STATUS_VIAJE & vbTab & "N" & vbTab & " " & vbTab & "TRANSFERENCIA" & vbTab & " ")
            Else
                MsgBox("Por favor capture el gasto")
            End If
        Catch ex As Exception
            Bitacora("790. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("790. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGastosBaja_Click(sender As Object, e As EventArgs) Handles BtnGastosBaja.Click
        If FgG.Row > 0 Then
            If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Then
                MsgBox("3. La partida ya fue cerrada no se puede modificar")
                Return
            End If
            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                FgG.Rows.Remove(FgG.Row)
            End If
        End If
    End Sub
    Private Sub BtnValesAlta_Click(sender As Object, e As EventArgs) Handles BtnValesAlta.Click
        Try
            Dim Sigue As Boolean = True, Fol As Long = 0, s As String
            Dim STATUS_VALE As String, CVE_DOC As String

            If DOC_NEW Then
                MsgBox("No es posible agregar un vale hasta que el viaje se grabe")
                Return
            End If

            'SERIE_VALE_COMBUS
            OBTENER_FOLIOS()

            For k = 1 To FgV.Rows.Count - 1
                If String.IsNullOrEmpty(FgV(k, 5)) Then
                    Sigue = False
                Else
                    If FgV(k, 5).ToString.Trim.Length = 0 Then
                        Sigue = False
                    Else
                        If FgV(k, 17) = "S" Then
                            Fol += 1
                        End If
                    End If
                End If
            Next
            If Sigue Or FgV.Rows.Count = 1 Then
                STATUS_VALE = ""
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT DESCR FROM GCSTATUS_VALE_COMBUSTIBLE WHERE CVE_VAC = 1"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                STATUS_VALE = dr("DESCR")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                'CVE_DOC = SERIE_AV & Format(FOLIO_AV + Fol, "0000000000")

                FOLIO_AV = GET_MAX_TRY("GCASIGNACION_VIAJE_VALES", "FOLIO")

                CVE_DOC = SERIE_AV & Format(FOLIO_AV + Fol, "0000000000")

                s = CVE_DOC & vbTab '1
                s &= DateTime.Now.ToString("dd/MM/yyyy") & vbTab '2
                s &= "" & vbTab '3
                s &= "" & vbTab '4
                s &= "" & vbTab '5
                s &= "0" & vbTab '6
                s &= "0" & vbTab '7
                s &= "0" & vbTab '8
                s &= "0" & vbTab '9
                s &= "0" & vbTab '10
                s &= "0" & vbTab '11
                s &= "0" & vbTab '12
                s &= "" & vbTab '13
                s &= "" & vbTab '14
                s &= STATUS_VALE & vbTab '15
                s &= "" & vbTab '16
                s &= "S" & vbTab '17
                s &= " " & vbTab '18  UUID
                s &= " " & vbTab '19  CVE_DOC_PED
                s &= " " '20  BANDERA SI ES TRANS

                FgV.AddItem("" & vbTab & s)
                '                                              16 folio     
            Else
                MsgBox("Por favor capture la gasolinera")
            End If
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnValesBaja_Click(sender As Object, e As EventArgs) Handles BtnValesBaja.Click
        Try
            If FgV.Row < 1 Then
                MsgBox("Por favor seleccione un vale de combustible")
                Return
            End If
            If FgV(FgV.Row, 15) <> "EDICION" Then
                MsgBox("No es posible eliminar el vale por que esta capturado o depositado , verifique por favor")
                Return
            End If

            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                FgV.Rows.Remove(FgV.Row)
            End If
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_GotFocus(sender As Object, e As EventArgs) Handles FgG.GotFocus
        ENTRA = False
    End Sub
    Private Sub FgV_GotFocus(sender As Object, e As EventArgs) Handles FgV.GotFocus
        ENTRA = False
    End Sub
    Private Sub FgG_LostFocus(sender As Object, e As EventArgs) Handles FgG.LostFocus
        ENTRA = True
    End Sub
    Private Sub FgV_LostFocus(sender As Object, e As EventArgs) Handles FgV.LostFocus
        ENTRA = True
    End Sub
    Private Function UNIDAD_ASIGNADA_LOCAL(fUNI As Integer, fCVE_UNI As String) As Boolean

        Dim Exist As Boolean = False

        Try
            Select Case fUNI
                Case 1 'TRACTOR
                    Try
                        If tCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_DOLLY.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 3 'TANQUE2
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If tCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_DOLLY.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 4 'DOLLY
                    Try
                        If TCVE_TRACTOR.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If tCVE_TANQUE1.Text = fCVE_UNI Then
                            Exist = True
                        End If
                        If TCVE_TANQUE2.Text = fCVE_UNI Then
                            Exist = True
                        End If
                    Catch ex As Exception
                        Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
            Return Exist
        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub RadVacio_CheckedChanged(sender As Object, e As EventArgs) Handles RadVacio.CheckedChanged
        Try
            If RadVacio.Checked Then
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs)
        DESPLEGAR_TAB_RUTAS(LtCVE_VIAJE.Text)
    End Sub

    Sub DESPLEGAR_CONTRATO(fCVE_CON As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CVE_CON, CONTRATO_CLIENTE, CVE_RUTA, C.STATUS, C.RUTA_SEN_VAC, C.RUTA_SE_CAR, C.RUTA_FULL_VAC, C.RUTAL_FULL_CAR,
                    C.NOTA, C.GAS_VIAJE_SEN, C.GAS_VIAJE_FUL, C.LTR_DIESEL_SEN, C.LTR_DIESEL_FULL, C.KM_SEN, C.KM_FULL, C.REDIMIENTO, C.OBSER,
                    C.CVE_GAS, C.NO_VALES, C.TIPO_VIAJE, C.LITROS, C.NO_CONTRATO, CLAVE_O, CLAVE_D, CVE_ORIGEN, CVE_DESTINO, RECOGER_EN, ENTREGAR_EN,
                    CVE_PROV, CVE_MAT, ISNULL(VALOR_DECLA,0) AS DECLA, CVE_ART, LEYENDA, ISNULL(IMPR_TALON,0) AS IMPR, 
                    ISNULL(C.CVE_OBS,0) AS CVEOBS, ISNULL(O.DESCR,'') AS OBS_DESCR
                    FROM GCCONTRATO C
                    LEFT JOIN GCOBS O ON O.CVE_OBS = C.CVE_OBS
                    WHERE CVE_CON = '" & fCVE_CON & "' AND STATUS = 'A' "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        If TCLAVE_O.Text.Trim.Length = 0 Then
                            TCLAVE_O.Text = dr("CLAVE_O").ToString.Trim
                            DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                        End If
                        If TCLAVE_D.Text.Trim.Length = 0 Then
                            TCLAVE_D.Text = dr("CLAVE_D").ToString.Trim
                            DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)
                        End If

                        TCONTRATO_CLIENTE.Text = dr("NO_CONTRATO").ToString

                        If TRECOGER_EN.Text.Trim.Length = 0 Then
                            TRECOGER_EN.Text = dr("RECOGER_EN").ToString
                            TRECOGER_EN.Tag = dr("RECOGER_EN").ToString
                            LtRecogerEn.Text = BUSCA_CAT("RecogerEn", TRECOGER_EN.Text)
                        End If

                        If TENTREGAR_EN.Text.Trim.Length = 0 Then
                            TENTREGAR_EN.Text = dr("ENTREGAR_EN").ToString
                            TENTREGAR_EN.Tag = dr("ENTREGAR_EN").ToString
                            LtEntregarEn.Text = BUSCA_CAT("EntregarEn", TENTREGAR_EN.Text)
                        End If

                        TRUTA_SEN_VAC.Text = dr("RUTA_SEN_VAC").ToString
                        TRUTA_SE_CAR.Text = dr("RUTA_SE_CAR").ToString
                        TRUTA_FULL_VAC.Text = dr("RUTA_FULL_VAC").ToString
                        TRUTAL_FULL_CAR.Text = dr("RUTAL_FULL_CAR").ToString
                        TNOTA.Text = dr("NOTA").ToString

                        TOBS.Text = dr("OBS_DESCR")
                        TOBS.Tag = dr("CVEOBS")

                        DESPLEGAR_TAB_RUTAS_DESDE_CONTRATO(dr("CVE_CON").ToString)

                        CARGAR_GASTOS_AUTO()
                        CARGAR_VALES_AUTO()

                        TCVE_DOC.Tag = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("138. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("138. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_TAB_RUTAS_DESDE_CONTRATO(fCVE_CON As String)
        Dim NewStyle1 As CellStyle
        NewStyle1 = FgR.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True

        FgR.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, T.CVE_RUTA, T.ORIGEN, T.DESTINO, " &
                    "ISNULL(CLAVE,'') AS CLIE, NOMBRE, T.KM_RECO, T.COSTO_CASETAS, T.FLETE, T.SUELDO_OPER, T.RENDIMIENTO, T.P_X_LITRO, T.LITROS_RUTA, " &
                    "T.COSTO_DISEL, (CASE T.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, T.EJES " &
                    "FROM GCCONTRATOS_TAB_RUTAS T " &
                    "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = T.CLIENTE " &
                    "WHERE CVE_CON = '" & fCVE_CON & "' ORDER BY FECHA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgR.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("FECHA") & vbTab & dr("T_UNI") & vbTab & dr("CVE_RUTA") & vbTab &
                                   dr("ORIGEN") & vbTab & dr("DESTINO") & vbTab & dr("CLIE") & vbTab & dr("NOMBRE") & vbTab & dr("KM_RECO") & vbTab &
                                   dr("COSTO_CASETAS") & vbTab & dr("EJES") & vbTab & dr("FLETE") & vbTab & dr("SUELDO_OPER") & vbTab &
                                   dr("RENDIMIENTO") & vbTab & dr("P_X_LITRO") & vbTab & dr("LITROS_RUTA") & vbTab & dr("COSTO_DISEL") & vbTab &
                                   dr("T_VIAJE"))
                        LtRuta1.Text = dr("ORIGEN") & "-" & dr("DESTINO")
                        FgR.Rows(0).Style = NewStyle1
                        FgR.Rows(FgR.Rows.Count - 1).Style = NewStyle1
                    End While
                    FgR.AutoSizeRows()
                End Using
            End Using
        Catch ex As Exception
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try
            If fCVE_OPER.Trim.Length = 0 Then
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
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub DESPLEGAR_CLIENTE_OPER2(fCVE_OPER As String)
        Try
            If fCVE_OPER.Trim.Length = 0 Then
                Return
            End If

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
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnContrato_Click(sender As Object, e As EventArgs) Handles BtnContrato.Click
        Try
            Var2 = "Contrato"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CON.Text = Var4

                DESPLEGAR_CONTRATO(Var4)

                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_REM_Click(Nothing, Nothing)
            Return
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

    Private Sub BtnCLAVE_DEST_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_DEST.Click
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
            Bitacora("39 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("39. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLAVE_D_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLAVE_D.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCLAVE_DEST_Click(Nothing, Nothing)
            Return
        End If
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

    Private Sub FgV_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgV.ValidateEdit
        Try
            Dim PRECIO_SIN_IEPS As Decimal
            Dim SUBTOTAL1 As Decimal
            Dim SUBTOTAL2 As Decimal
            Dim IEPS As Decimal
            Dim PRECIO As Decimal
            Dim LITROS As Single

            If FgV.Row > 0 Then

                If FgV(FgV.Row, 15) = "DEPOSITADO" Or FgV(FgV.Row, 15) = "CONCILIADO" Then
                    MsgBox("La partida ya fue cerrada no se puede modificar")
                    e.Cancel = True
                    Return
                End If

                If e.Col = 6 Or e.Col = 7 Then
                    If e.Col = 6 Then
                        LITROS = FgV.Editor.Text
                        PRECIO = FgV(FgV.Row, 8)
                    Else
                        LITROS = FgV(FgV.Row, 7)
                        PRECIO = FgV.Editor.Text
                    End If


                    IEPS = LITROS * FACTOR_IEPS
                    If PRECIO > 0 Then
                        PRECIO_SIN_IEPS = PRECIO - (IEPS / LITROS)
                    Else
                        PRECIO_SIN_IEPS = 0
                    End If

                    SUBTOTAL1 = LITROS * PRECIO_SIN_IEPS
                    SUBTOTAL2 = SUBTOTAL1 / 1.16

                    If FgV.Col = 7 Then
                        FgV(FgV.Row, 9) = SUBTOTAL2 + IEPS     'SUBTOTAL
                        FgV(FgV.Row, 10) = SUBTOTAL2 * 0.16                'IVA
                        FgV(FgV.Row, 11) = IEPS         'IEPS
                        FgV(FgV.Row, 12) = SUBTOTAL2 + IEPS + (SUBTOTAL2 * 0.16)  'TOTAL
                    End If
                    If FgV.Col = 8 Then
                        FgV(FgV.Row, 9) = SUBTOTAL2 + IEPS     'SUBTOTAL
                        FgV(FgV.Row, 10) = SUBTOTAL2 * 0.16                'IVA
                        FgV(FgV.Row, 11) = IEPS         'IEPS
                        FgV(FgV.Row, 12) = SUBTOTAL2 + IEPS + (SUBTOTAL2 * 0.16)  'TOTAL
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgV_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgV.CellButtonClick
        Try
            If FgV.Row > 0 And e.Col = 4 Then
                If FgV(FgV.Row, 15) = "DEPOSITADO" Or FgV(FgV.Row, 15) = "CONCILIADO" Then
                    MsgBox("La partida ya fue cerrada no se puede modificar")
                    e.Cancel = True
                    Return
                End If
                If FgV(FgV.Row, 15) = "CAPTURADO" Then
                    MsgBox("La partida ya fue aceptada no se puede modificar")
                    e.Cancel = True
                    Return
                End If
                Var2 = "Gasolinera"
                Var4 = "" : Var5 = ""
                FrmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    FgV(FgV.Row, 4) = Var4
                    FgV(FgV.Row, 5) = Var5
                    Var2 = "" : Var4 = "" : Var5 = ""
                    FgV.Col = 6
                    FgV.StartEditing()
                End If
            End If
        Catch Ex As Exception
            Bitacora("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub FgV_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgV.BeforeEdit
        Try
            If FgV.Row > 0 Then
                If FgV.Col = 2 Or FgV.Col = 3 Or FgV.Col = 4 Or FgV.Col = 6 Or FgV.Col = 15 Or FgV.Col = 16 Then
                    If FgV(FgV.Row, 15) = "DEPOSITADO" Or FgV(FgV.Row, 15) = "CONCILIADO" Then
                        e.Cancel = True

                        FgV.Col = 1
                        MsgBox("La partida ya fue cerrada no se puede modificar")
                        Return
                    Else
                        If FgV(FgV.Row, 15) = "CAPTURADO" Then

                            If FgV(FgV.Row, 20).ToString.Trim <> "Si" Then
                                e.Cancel = True
                                Return
                            End If
                        Else
                            If FgV.Col = 15 Then
                                If FgV(FgV.Row, 15) = "CAPTURADO" Then
                                    e.Cancel = True
                                End If
                            Else
                                If FgV(FgV.Row, 15) = "CAPTURADO" Then
                                    If FgV.Col <> 6 Then
                                        e.Cancel = True
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If FgV.Col = 2 Then
                        'If FgV(FgV.Row, 20).ToString.Trim = "Si" Then
                        e.Cancel = True
                        'End If
                    End If
                    If FgV.Col = 3 Then
                        If FgV(FgV.Row, 20).ToString.Trim <> "Si" Then
                            e.Cancel = True
                        End If
                    End If
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("782. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("782. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgV_EnterCell(sender As Object, e As EventArgs) Handles FgV.EnterCell
        Try
            If FgV.Row > 0 Then
                If Not IsNothing(FgV(FgV.Row, 15)) And Not IsNothing(FgV(FgV.Row, 15)) Then
                    If FgV(FgV.Row, 15) <> "ACEPTADO" And FgV(FgV.Row, 15) <> "CAPTURADO" Then
                        If FgV.Col = 2 Or FgV.Col = 4 Or FgV.Col = 6 Or FgV.Col = 15 Or FgV.Col = 16 Then
                            If FgV.Col = 2 Then
                                'If FgV(FgV.Row, 20).ToString.Trim = "Si" Then
                                Return
                                'End If
                            End If
                            If FgV.Col = 3 Then
                                If FgV(FgV.Row, 20).ToString.Trim <> "Si" Then
                                    Return
                                End If
                            End If

                            If FgV(FgV.Row, 15) <> "DEPOSITADO" And FgV(FgV.Row, 15) <> "CONCILIADO" Then
                                FgV.StartEditing()
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgV_KeyDown(sender As Object, e As KeyEventArgs) Handles FgV.KeyDown
        Try
            If FgV.Row > 0 Then
                If FgV(FgV.Row, 15) = "DEPOSITADO" Or FgV(FgV.Row, 15) = "CONCILIADO" Then
                    MsgBox("La partida ya fue cerrada no se puede modificar")
                    Return
                End If
                If e.KeyCode = Keys.F2 Then
                    BtnValesAlta_Click(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function OBTENER_STATUS_VALES_VIAJE(fCVE_ST_VA As Integer)
        Dim STATUS_VIAJE As String

        STATUS_VIAJE = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT DESCR FROM GCSTATUS_VALE_COMBUSTIBLE WHERE CVE_VAC = 1"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        STATUS_VIAJE = dr("DESCR")
                    End If
                End Using
            End Using
            Return STATUS_VIAJE
        Catch ex As Exception
            Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
            Return STATUS_VIAJE
        End Try
    End Function
    Private Function OBTENER_STATUS_GASTOS_VIAJE(fCVE_GAV As Integer) As String
        Dim STATUS_VIAJE As String

        STATUS_VIAJE = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT DESCR FROM GCSTATUS_GASTOS_VIAJE WHERE CVE_GAV = 1"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        STATUS_VIAJE = dr("DESCR")
                    End If
                End Using
            End Using
            Return STATUS_VIAJE
        Catch ex As Exception
            Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
            Return STATUS_VIAJE
        End Try
    End Function
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click

        Var10 = LtCVE_VIAJE.Text
        Var15 = "BITACORA DE VIAJE"
        Try
            'frmCrystalReport.ShowDialog()
            Dim Rreporte_MRT As String = ""
            Dim RUTA_FORMATOS As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            Try
                Rreporte_MRT = RUTA_FORMATOS & "\ReportBitacoraDeViaje.mrt"
                If Not File.Exists(Rreporte_MRT) Then
                    MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                    Return
                End If
                StiReport1.Load(Rreporte_MRT)
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                        Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text

                StiReport1.Item("CVE_VIAJE_PARAM") = LtCVE_VIAJE.Text
                StiReport1.Render()
                StiReport1.Show()

            Catch ex As Exception
                Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            Bitacora("781. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("781. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAgregar_Click_1(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Dim NewStyle1 As CellStyle
        NewStyle1 = FgR.Styles.Add("NewStyle1")
        NewStyle1.WordWrap = True

        Try
            Dim NOMBRE As String
            NOMBRE = ""
            If TCVE_TAB.Text.Trim.Length > 0 Then
                Dim Exist As Boolean
                Exist = False
                For k = 1 To FgR.Rows.Count - 1
                    If FgR(k, 1) = TCVE_TAB.Text Then
                        Exist = True
                        Exit For
                    End If
                Next
                If Exist Then
                    MsgBox("El tabulador de ruta ya fue agregado, verifique por favor")
                    Return
                End If
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT T.CVE_TAB, T.FECHA, (CASE T.TIPO_UNI WHEN 1 THEN 'Full' ELSE 'Sencillo' END) AS T_UNI, D.CVE_RUTA, P1.CIUDAD AS ORIG, P2.CIUDAD AS DEST, " &
                        "ISNULL(CLIENTE,'') AS CLIE, ISNULL(NOMBRE,'') AS NOMB, ISNULL(T.KM_RECO, 0) AS KM, ISNULL(T.COSTO_CASETAS, 0) AS COST_CAS, ISNULL(T.FLETE, 0) AS FLET, " &
                        "ISNULL(T.SUELDO_OPER, 0) AS SUELD, ISNULL(T.RENDIMIENTO, 0) AS RENDI, ISNULL(T.P_X_LITRO, 0) AS P_LITRO, ISNULL(T.LITROS_RUTA, 0) AS LT_RUT, " &
                        "ISNULL(T.COSTO_DISEL, 0) AS COST_DIS, (CASE T.TIPO_VIAJE WHEN 1 THEN 'Cargado' ELSE 'Vacio' END) AS T_VIAJE, ISNULL(T.EJES, 0) AS EJE " &
                        "FROM GCTAB_RUTAS T " &
                        "LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.ORIGEN " &
                        "LEFT JOIN GCPLAZAS P1 On P1.CLAVE = D.CVE_PLA1 " &
                        "LEFT JOIN GCPLAZAS P2 On P2.CLAVE = D.CVE_PLA2 " &
                        "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = T.CLIENTE " &
                        "WHERE T.STATUS = 'A' AND T.CVE_TAB = " & TCVE_TAB.Text
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            'tLITROS_RUTA.Text = Format(tKM_RECO.Text / tRENDIMIENTO.Value, "###,###,##0.00")
                            'tCOSTO_DISEL.Text = Format(tLITROS_RUTA.Text * tP_X_LITRO.Value, "###,###,##0.00")
                            FgR.AddItem("" & vbTab & dr("CVE_TAB") & vbTab & dr("FECHA") & vbTab & dr("T_UNI") & vbTab & dr("CVE_RUTA") & vbTab &
                                       dr("ORIG") & vbTab & dr("DEST") & vbTab & dr("CLIE") & vbTab & dr("NOMB") & vbTab & dr("KM") & vbTab &
                                       (dr("COST_CAS") / 1.16) & vbTab & dr("EJE") & vbTab & dr("FLET") & vbTab & dr("SUELD") & vbTab &
                                       dr("RENDI") & vbTab & dr("P_LITRO") & vbTab & dr("KM") / dr("RENDI") & vbTab & (dr("KM") / dr("RENDI")) * dr("P_LITRO") & vbTab &
                                       dr("T_VIAJE") & vbTab & "")
                            TCVE_TAB.Text = ""
                            LtRuta1.Text = dr("ORIG") & "-" & dr("DEST")
                            FgR.Rows(0).Style = NewStyle1
                            FgR.Rows(FgR.Rows.Count - 1).Style = NewStyle1
                            FgR.AutoSizeRows()
                        Else
                            TCVE_TAB.Text = ""
                            LtTabRuta.Text = ""
                        End If
                    End Using
                End Using
            Else
                LtTabRuta.Text = ""
            End If
        Catch ex As Exception
            Bitacora("717. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("717. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                FgR.Rows.Remove(FgR.Row)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCVE_TAB_Validated(sender As Object, e As EventArgs) Handles TCVE_TAB.Validated
        Try
            If TCVE_TAB.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tab Rutas", TCVE_TAB.Text)
                If DESCR <> "" Then
                    LtTabRuta.Text = DESCR
                Else
                    MsgBox("Tabulador ruta inexistente")
                    TCVE_TAB.Text = ""
                    LtTabRuta.Text = ""
                    TCVE_TAB.Select()
                End If
            Else
                LtTabRuta.Text = ""
            End If
        Catch ex As Exception
            Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("762. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TAB_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TAB.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTabRutas_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub FgR_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgR.BeforeEdit
        Try
            If e.Col = 2 Or e.Col = 3 Or e.Col = 4 Or e.Col = 7 Or e.Col = 9 Or e.Col = 10 Or e.Col = 11 Or e.Col = 12 Or e.Col = 13 Or
                e.Col = 14 Or e.Col = 15 Or e.Col = 18 Then
            Else
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FgR_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgR.ValidateEdit

        Select Case e.Col
            Case 7 'KM RECORRIDOS
                Try
                    If FgR.Editor.Text > 0 Then
                        FgR(e.Row, 14) = Val(FgR.Editor.Text) / FgR(e.Row, 12)
                    Else
                        FgR(e.Row, 14) = 0
                    End If
                Catch ex As Exception
                    Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("762. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 9 'KM RECORRIDOS
                Try
                    If FgR.Editor.Text > 0 Then
                        FgR(e.Row, 16) = Val(FgR.Editor.Text) / FgR(e.Row, 14)
                        FgR(e.Row, 17) = FgR(e.Row, 16) * FgR(e.Row, 15)
                    Else
                        FgR(e.Row, 16) = 0
                    End If
                Catch ex As Exception
                    Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("762. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 14 'RENDIMIENTO
                Try
                    If Val(FgR.Editor.Text) > 0 Then
                        FgR(e.Row, 16) = FgR(e.Row, 9) / Val(FgR.Editor.Text)
                    Else
                        FgR(e.Row, 16) = 0
                    End If
                Catch ex As Exception
                    Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("762. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 15
                Try
                    If Val(FgR.Editor.Text) > 0 Then
                        FgR(e.Row, 17) = FgR(e.Row, 16) * Val(FgR.Editor.Text)
                    Else
                        FgR(e.Row, 17) = 0
                    End If
                Catch ex As Exception
                    Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("762. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
        End Select

    End Sub
    Private Sub FgG_KeyDown(sender As Object, e As KeyEventArgs) Handles FgG.KeyDown
        Try
            If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                FgG(FgG.Row, 7) = "ACEPTADO" Then
                MsgBox("La partida ya fue cerrada no se puede modificar")
                Return
            End If

            If e.KeyCode = Keys.F2 Then
                BtnGastosAlta_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgG.BeforeEdit
        Try
            If FgG.Row > 0 Then
                If FgG.Col = 1 Or FgG.Col = 2 Or FgG.Col = 4 Then
                    e.Cancel = True
                Else
                    If FgG.Col <> 3 Then
                        If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or
                            FgG(FgG.Row, 7) = "CANCELADO" Or FgG(FgG.Row, 7) = "ACEPTADO" Then
                            e.Cancel = True
                            FgG.Col = 1
                            'MsgBox("2. La partida ya fue cerrada no se puede modificar")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgG.ValidateEdit
        Try
            If e.Row > 0 Then
                If e.Col = 2 Or e.Col = 5 Or e.Col = 7 Then
                    If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                       FgG(FgG.Row, 7) = "ACEPTADO" Then
                        MsgBox("3. La partida ya fue cerrada no se puede modificar")
                        Return
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCVE_DOLLY_Validated(sender As Object, e As EventArgs) Handles TCVE_DOLLY.Validated
        Try
            Dim DESCR As String
            If TCVE_DOLLY.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)
                If DESCR <> "" Then
                    Dim CVE_VIAJE As String
                    If UNIDAD_ASIGNADA_LOCAL(4, TCVE_DOLLY.Text) Then
                        'MsgBox("Esta unidad ya fue asignada verifique por favor")
                    End If

                    CVE_VIAJE = UNIDAD_ASIGNADA_VIAJE(TCVE_DOLLY.Text)
                    If CVE_VIAJE <> "" Then
                        'MsgBox("La unidad ya fue asignada " & CVE_VIAJE)
                    End If
                    Var3 = ""
                    TCVE_DOLLY.Tag = TCVE_DOLLY.Text
                    LDolly.Text = DESCR
                Else
                    MsgBox("Dolly inexistente")
                    TCVE_DOLLY.Text = ""
                    TCVE_DOLLY.Tag = ""
                    LDolly.Text = ""
                    tCVE_TANQUE1.Select()
                End If
            Else
                TCVE_DOLLY.Tag = ""
                LDolly.Text = ""
            End If
        Catch ex As Exception
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgR_GotFocus(sender As Object, e As EventArgs) Handles FgR.GotFocus
        ENTRA = False
    End Sub
    Private Sub FgR_LostFocus(sender As Object, e As EventArgs) Handles FgR.LostFocus
        ENTRA = True
    End Sub

    Private Sub FgR_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgR.CellButtonClick
        Dim RENDIMIENTO As Single
        Try
            If FgR.Row > 0 Then
                If FgR(FgR.Row, 7) = "DEPOSITADO" Then
                    MsgBox("1. La partida ya fue cerrada no se puede modificar")
                    Return
                End If
                If e.Col = 4 Then 'RUTA
                    Try
                        Var2 = "Detalle Rutas"
                        Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                        FrmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1)          'CVE_RUTA
                            'Var5 = Fg(Fg.Row, 2).ToString 'origen
                            'Var6 = Fg(Fg.Row, 3).ToString 'destino
                            'Var7 = Fg(Fg.Row, 4).ToString 'KM RECORRIDOS
                            'Var8 = Fg(Fg.Row, 5).ToString 'COSTO_CASETAS
                            'Var9 = Fg(Fg.Row, 6).ToString 'EJES
                            FgR(FgR.Row, 4) = Var4 'CVE_RUTA
                            FgR(FgR.Row, 5) = Var5 'ORIGEN
                            FgR(FgR.Row, 6) = Var6 'destino
                            FgR(FgR.Row, 9) = Val(Var7) 'KM_RECORRIDOS
                            If Not IsDBNull(Var8) Then
                                'COSTO_CASETAS
                                FgR(FgR.Row, 10) = Math.Round(Val(Var8) / 1.16, 2)
                            End If
                            FgR(FgR.Row, 11) = Var9  'EJES
                            Try         'RENDIMIENTO
                                If IsNumeric(FgR(FgR.Row, 14)) Then
                                    RENDIMIENTO = FgR(FgR.Row, 14)
                                Else
                                    RENDIMIENTO = 0
                                End If
                                If RENDIMIENTO > 0 Then
                                    'LITROS RUTA
                                    FgR(FgR.Row, 16) = Math.Round(Val(Var6) / RENDIMIENTO, 2)
                                End If
                            Catch ex As Exception
                                Bitacora("710 " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("710 " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                If IsNumeric(FgR(FgR.Row, 16)) And IsNumeric(FgR(FgR.Row, 15)) Then
                                    'COSTO DIESEL
                                    FgR(FgR.Row, 17) = Math.Round(FgR(FgR.Row, 16) * FgR(FgR.Row, 15), 2)
                                End If
                            Catch ex As Exception
                                Bitacora("712. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("712. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                        End If
                    Catch ex As Exception
                        Bitacora("715. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                If e.Col = 7 Then 'CLIENTE
                    Var2 = "Clientes"
                    Var4 = "" : Var5 = ""
                    FrmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        FgR(FgR.Row, 7) = Var4
                        FgR(FgR.Row, 8) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                    End If
                End If
            End If
        Catch Ex As Exception
            Bitacora("775. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("775 " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_CON_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_CON.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnContrato_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_DOLLY_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOLLY.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnDolly_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub BtnTabRutas_Click(sender As Object, e As EventArgs) Handles BtnTabRutas.Click
        Try
            'Var4 = Fg(Fg.Row, 1)          'CVE_RUTA
            'Var5 = Fg(Fg.Row, 2).ToString 'origen
            'Var6 = Fg(Fg.Row, 3).ToString 'destino
            'Var7 = Fg(Fg.Row, 4).ToString 'KM RECORRIDOS
            'Var8 = Fg(Fg.Row, 5).ToString 'COSTO_CASETAS
            'Var9 = Fg(Fg.Row, 6).ToString 'EJES
            If FgR.Row > 0 Then
                MsgBox("Primero debe de borrar el tabulador de rutas actual antes de agregar uno nuevo")
                Return
            End If
            'Var1 = IIf(radFull.Checked, 1, 0)
            Var2 = "Detalle Rutas"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TAB.Text = Var4
                LtTabRuta.Text = Var5 & "  " & Var6
                Var4 = "" : Var5 = "" : Var6 = ""
            End If
        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
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
                TCVE_OPER.Focus()
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TENTREGAR_EN_KeyDown(sender As Object, e As KeyEventArgs) Handles TENTREGAR_EN.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEntregarEn_Click(Nothing, Nothing)
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
                TCVE_OPER.Select()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Private Sub TRECOGER_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRECOGER_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Box2.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TENTREGAR_EN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TENTREGAR_EN.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Box5.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarImprimirCartasPorte_Click(sender As Object, e As EventArgs) Handles BarImprimirCartasPorte.Click
        Try

            If LtCartaPorte.Text.Trim.Length > 0 Then
                Var10 = LtCartaPorte.Text
                Var15 = "CARTA PORTE"
                ImprimirOrden(Var10)
            End If
            If LtCartaPorte2.Text.Trim.Length > 0 Then
                Var10 = LtCartaPorte2.Text
                Var15 = "CARTA PORTE"
                ImprimirOrden(Var10)
            End If

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
    Private Sub BarImprimirBitacoraViaje_Click(sender As Object, e As EventArgs) Handles BarImprimirBitacoraViaje.Click
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportBitacoraDeViaje.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportBitacoraDeViaje.mrt, verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\ReportBitacoraDeViaje.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("CVE_VIAJE_PARAM") = LtCVE_VIAJE.Text
            StiReport1.Item("CVE_VIAJE2") = LtCVE_VIAJE.Text
            StiReport1.Item("CVE_VIAJE3") = LtCVE_VIAJE.Text
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles FgG.ComboCloseUp
        Try
            If FgG.Row > 0 And e.Col = 7 Then
                If FgG(e.Row, 3).ToString.Length = 0 Then
                    MsgBox("Por favor antes seleccione un gasto")
                    FgG.ComboBoxEditor.SelectedIndex = 0
                    e.Cancel = True
                    Return
                End If
                If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Then
                    MsgBox("1. La partida ya fue cerrada no se puede modificar")
                    Return
                End If
            End If
        Catch Ex As Exception
            Bitacora("775. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("775 " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_MouseEnterCell(sender As Object, e As RowColEventArgs) Handles FgG.MouseEnterCell
        Try
            If FgG.Row > 0 Then
                If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or
                            FgG(FgG.Row, 7) = "CANCELADO" Or FgG(FgG.Row, 7) = "ACEPTADO" Then
                    Return
                End If
                If e.Col = 3 And e.Row >= 1 Then
                    FgG.Col = 3
                End If
            End If
        Catch ex As Exception
            Bitacora("775. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimirGasto_Click(sender As Object, e As EventArgs) Handles BarImprimirGasto.Click
        Try
            Dim RUTA_FORMATOS As String, FOLIO As Long = 0

            If Not IsNothing(FgG(FgG.Row, 1)) Then
                If IsNumeric(FgG(FgG.Row, 1)) Then
                    FOLIO = FgG(FgG.Row, 1)
                End If
            End If

            If FOLIO = 0 Then
                MsgBox("Por favor seleccione un folio de gastos")
                Return
            End If

            BarImprimirGasto.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportGastosDeViaje.mrt"
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

            StiReport1.Item("CVE_VIAJE") = LtCVE_VIAJE.Text
            StiReport1.Item("FOLIO") = FOLIO

            StiReport1.Render()
            StiReport1.Show()

            BarImprimirGasto.Enabled = True
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarVales_Click(sender As Object, e As EventArgs) Handles BarVales.Click
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportValesDeViaje.mrt"
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
            StiReport1.Item("CVE_VIAJE") = LtCVE_VIAJE.Text
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgV_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles FgV.ComboCloseUp
        Try
            If FgV.Col = 2 Then
                e.Cancel = True
            End If

            If FgV(FgV.Row, 15) = "CAPTURADO" Then

            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgV_ComboDropDown(sender As Object, e As RowColEventArgs) Handles FgV.ComboDropDown
        Try
            If FgV.Col = 2 Then
                e.Cancel = True
            End If
            If FgV.Col = 15 Then
                If FgV(FgV.Row, 15) = "CAPTURADO" Then
                    MsgBox("El vale de viaje esta como CAPTURADO no es posible cambiar el estatus, verifique por favor")
                    SendKeys.Send("{TAB}")
                End If
            End If
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCVE_OPER.KeyPress
        Try
            If tCVE_OPER.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    e.Handled = True
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCVE_TRACTOR.KeyPress
        Try
            If tCVE_TRACTOR.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    e.Handled = True
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TANQUE1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCVE_TANQUE1.KeyPress
        Try
            If tCVE_TANQUE1.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    e.Handled = True
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCVE_TANQUE2.KeyPress
        Try
            If tCVE_TANQUE2.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    e.Handled = True
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_DOLLY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tCVE_DOLLY.KeyPress
        Try
            If tCVE_DOLLY.Text.Trim <> "" Then
                If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                    MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                    e.Handled = True
                    Return
                End If
            End If
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
                tCVE_CON.Focus()
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
                            tCVE_CON.Focus()
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

    Private Sub TCVE_DOLLY_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_DOLLY.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Box1.Focus()
        End If
    End Sub

    Private Sub TCARGA_ANTERIOR_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCARGA_ANTERIOR.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            TCVE_TRACTOR.Focus()
        End If
    End Sub
End Class

