Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.ComponentModel
Public Class FrmOrdenDeTrabajoExtAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private ENTRA_FALLAS As Boolean
    Private PERMITIR_UNIDAD As Integer = 0
    Private PORC_ORDEN_TRA_EXT As Decimal = 0
    Private TIPO_VENTA As String = "R"
    Private CVE_CPTO_OT As Integer = 0
    Private CVE_CPTO_OT_SAL As Integer = 0
    Private RUTA_DOC As String
    Private DOC_ENLAZADO As String = "N"
    Private SEGONE As Boolean
    Private DOC_NEW As Boolean
    Private ACCESO_USUARIO As Boolean
    Private ERROR_PAR As Boolean
    Private SE_DESPLEGA As Boolean = True
    Private NProc As Integer = 0
    Private U_ALMACEN As Boolean
    Private U_MANTE As Boolean

    Private C93015 As Boolean, C93030 As Boolean, C93060 As Boolean, C93090 As Boolean, C93120 As Boolean, C93150 As Boolean
    Private C93180 As Boolean, C93220 As Boolean, C93250 As Boolean, C93280 As Boolean, C93310 As Boolean, C93340 As Boolean, C93370 As Boolean

    Private _myEditor As MyEditorOTEXT
    Private Sub FrmOrdenDeTrabajoExtAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Efecto As Boolean
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
        End Try

        Try
            tCVE_ORD.MaxLength = 10
            tEstatus.MaxLength = 80
            tCVE_UNI.MaxLength = 10
            tCVE_TIPO.MaxLength = 10
            tCVE_PROV.MaxLength = 10
            tLUGAR_REP.MaxLength = 50
            tNOTA.MaxLength = 100
            SEGONE = True

            Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 50

            Tab1.Height = Me.Height - Panel1.Height - barMenu.Height - 25

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 80
            Fg.Height = Tab1.Height - 100

            FgS.Width = Screen.PrimaryScreen.Bounds.Width - 80
            FgS.Height = Tab1.Height - btnAltaServicio.Height - 100

            FgD.Width = Screen.PrimaryScreen.Bounds.Width - 80
            FgD.Height = Tab1.Height - LtFotoDoc.Top - LtFotoDoc.Height - 100

            FgD.Cols(3).Width = FgD.Width - FgD.Cols(1).Width - FgD.Cols(2).Width - FgD.Cols(0).Width - 50

            BarCancPartNoEntr.Text = "Cancelar part." & vbNewLine & "no entregadas"
            barCancelarOT.Text = "Cancelar orden" & vbNewLine & "de trabajo"
            barFinOT.Text = "Finalizar orden" & vbNewLine & "de trabajo"

            L1.Top = Fg.Top + Fg.Height + 5
            Lt1.Top = Fg.Top + Fg.Height + 5

            Lt3.Top = Fg.Top + Fg.Height + 8
            LtPiezas.Top = Fg.Top + Fg.Height + 5
            Lt4.Top = Fg.Top + Fg.Height + 8
            LtPar.Top = Fg.Top + Fg.Height + 5

            LtDocAnt.Top = Lt1.Top
            Label7.Top = Lt1.Top + 3
            L5.Top = FgS.Top + FgS.Height + 5
            Lt5.Top = FgS.Top + FgS.Height + 5

            FgD.Rows.Count = 1

            Me.Refresh()
            ENTRA_FALLAS = False
            ENTRA = False
            LtDocAnt.Text = ""
            tEstatus.Tag = ""
            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Fg.Cols(2).Width = 20
            Fg.Cols(9).Width = 90
            Fg.Rows(0).Height = 40

            FgS.Cols(2).Width = 20
            FgS.Rows(0).Height = 40

            C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
            C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
            Me.WindowState = FormWindowState.Maximized
            Me.KeyPreview = True

            If OT_EXT = "M" Then
                TabProductos.Enabled = False
            End If
        Catch ex As Exception
        End Try

        DERECHOS()

        Try
            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & k
                Next
                For k = 1 To FgS.Cols.Count - 1
                    FgS(0, k) = FgS(0, k) & " " & k
                Next
            End If
        Catch ex As Exception
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(RUTA_DOC,'') AS RUTA FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RUTA_DOC = dr("RUTA").ToString
            Else
                RUTA_DOC = ""
            End If
            dr.Close()
            If RUTA_DOC.Trim.Length = 0 Then RUTA_DOC = Application.StartupPath
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If PASS_GRUPOCE = "BUS" Then
            Fg.Cols(12).Visible = True
            Fg.Cols(13).Visible = True
            Fg.Cols(14).Visible = True
            Fg.Cols(15).Visible = True
            Fg.Cols(16).Visible = True
            Fg.Cols(17).Visible = True

            FgS.Cols(12).Visible = True
            FgS.Cols(13).Visible = True
            FgS.Cols(14).Visible = True
        Else
            Fg.Cols(12).Visible = False
            Fg.Cols(13).Visible = False
            Fg.Cols(14).Visible = False
            Fg.Cols(15).Visible = False
            Fg.Cols(16).Visible = False
            Fg.Cols(17).Visible = False

            FgS.Cols(12).Visible = False
            FgS.Cols(13).Visible = False
            FgS.Cols(14).Visible = False
        End If
        Try
            SQL = "SELECT ISNULL(PERMITIR_UNIDAD,0) AS P_UNIDAD, ISNULL(PORC_ORDEN_TRA_EXT,0) AS POR_ORD_TRA_EXT FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PERMITIR_UNIDAD = dr("P_UNIDAD")
                        PORC_ORDEN_TRA_EXT = dr("POR_ORD_TRA_EXT")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            CARGA_PARAM_INVENT()
            DOC_ENLAZADO = "N"
            ENTRA_KEY = True
            REMOVE_ROW = 0
            ENTRA_BTN = True
            LIMPIAR()
            tCVE_PROV.Tag = "0" : L3.Tag = "0"
            tCVE_ORD.Enabled = False
        Catch ex As Exception
        End Try
        DOC_NEW = False
        If Var1 = "Nuevo" Then
            LtNueva.Visible = True

            Try
                Try
                    BarRemisionar.Enabled = False
                    barCancelarOT.Enabled = False
                    barFinOT.Enabled = False
                    BarCancPartNoEntr.Enabled = False
                    BarReimpresion.Enabled = False

                Catch ex As Exception
                End Try
                tCVE_ORD.Text = GET_MAX("GCORDEN_TRABAJO_EXT", "CVE_ORD")
                tCVE_ORD.Enabled = False
                tEstatus.Text = "Captura"
                DOC_NEW = True

                Fg.Rows.Count = 1 '      1             2           3           4             5             6             7             8   
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0)
                '           9            10            11           12            13            14           15            16            17
                FgS.Rows.Count = 1
                FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab)
            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 180

                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, ISNULL(O.TIPO_SERVICIO,0) AS TIPO_SER, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA, O.CVE_UNI, " &
                    "O.CVE_TIPO, O.CVE_OPER, O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS, OB.DESCR AS OBS_STR, " &
                    "ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(DOC_ANTR,'') AS DOCANTR, ISNULL(PORC_UTIL,0) AS P_UTIL, ISNULL(CVE_PROG,'') AS C_PROG " &
                    "FROM GCORDEN_TRABAJO_EXT O " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS " &
                    "WHERE CVE_ORD = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_ORD.Text = dr("CVE_ORD").ToString
                    tCVE_ORD.Tag = dr("DOCANT").ToString
                    tEstatus.Tag = dr("DOCANTR").ToString
                    F1.Value = dr("FECHA").ToString
                    Select Case dr("TIPO_SER")
                        Case 0
                            radPreventivo.Checked = True
                        Case 1
                            radCorrectivo.Checked = True
                        Case 2
                            radExtra.Checked = True
                        Case 3
                            radSinistro.Checked = True
                        Case 4
                            RadRescateCarr.Checked = True
                        Case 5
                            RadLLantas.Checked = True
                        Case Else
                            radPreventivo.Checked = True
                    End Select
                    tCVE_UNI.Text = dr("CVE_UNI").ToString
                    L2.Text = BUSCA_CAT("Unidad", tCVE_UNI.Text)

                    tCVE_TIPO.Text = dr("CVE_TIPO").ToString
                    L4.Text = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)

                    tEstatus.Text = dr("ESTATUS").ToString

                    Var6 = "0"
                    tCVE_PROV.Text = dr("CVE_PROV").ToString
                    L3.Text = BUSCA_CAT("ClieOT", tCVE_PROV.Text)
                    tCVE_PROV.Tag = Val(Var6)
                    L3.Tag = Var7

                    tLUGAR_REP.Text = dr("LUGAR_REP").ToString
                    tNOTA.Text = dr("NOTA").ToString

                    tOBSER.Text = dr("OBS_STR").ToString
                    tOBSER.Tag = dr("CVE_OBS").ToString
                    tCVE_PROG.Text = dr("C_PROG")
                    If tEstatus.Text = "FINALIZADO" Then
                        Panel1.Enabled = False
                        Panel2.Enabled = False
                        If tEstatus.Tag.ToString.Length > 0 Then
                            tEstatus.Text = "REMISIONADA"
                        End If
                    End If
                    CARGAR_PRODUCTOS()
                    CARGAR_SERVICIOS()
                    DOC_FOTOS(tCVE_ORD.Text)
                End If
                dr.Close()

                If Var3 = "Cancelada" Then
                    tEstatus.Text = Var3
                    Efecto = False
                    Fg.Enabled = False
                    FgD.Enabled = False
                    FgS.Enabled = False
                    barGrabar.Enabled = False
                    BarEnlazarDoc.Enabled = False
                    BarRemisionar.Enabled = False
                    Panel1.Enabled = False
                    Panel2.Enabled = False

                    barCancelarOT.Enabled = False
                    BarReimpresion.Enabled = False
                    BarKardex.Visible = False
                    BarCancPartNoEntr.Enabled = False
                    barFinOT.Enabled = Efecto
                    btnEliProd.Enabled = Efecto

                    btnAltaProducto.Enabled = Efecto
                    btnAltaServicio.Enabled = Efecto
                    btnEliSer.Enabled = Efecto
                    GBox1.Enabled = False
                Else
                    If tEstatus.Tag.ToString.Length > 0 Then
                        BarCancPartNoEntr.Enabled = False
                        Efecto = False
                        barFinOT.Enabled = Efecto
                        BarRemisionar.Enabled = False
                        barCancelarOT.Enabled = False
                        btnEliProd.Enabled = Efecto
                        btnAltaProducto.Enabled = Efecto
                        btnAltaServicio.Enabled = Efecto
                        btnEliSer.Enabled = Efecto
                        GBox1.Enabled = False
                    Else
                        If tEstatus.Text = "FINALIZADO" Then
                            barGrabar.Enabled = False
                            BarEnlazarDoc.Enabled = False
                            btnAltaServicio.Enabled = False
                            BarKardex.Enabled = False
                            BarReimpresion.Enabled = False
                            btnEliSer.Enabled = False
                            BarCancPartNoEntr.Enabled = False
                            barCancelarOT.Enabled = False
                            barFinOT.Enabled = False
                            'INCIO DERECHOS
                            'BarRemisionar.Enabled = True
                            btnAltaProducto.Enabled = False
                            btnEliProd.Enabled = False
                            GBox1.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                'MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Try
            If barGrabar.Enabled Then
                ACCESO_USUARIO = True
            Else
                ACCESO_USUARIO = False
            End If
        Catch ex As Exception
        End Try
        Try
            BtnMagix.Visible = False
            BtnDesCancel.Visible = False
            BtnSetMovRealizado.Visible = False
            Tab1.SelectedIndex = 0
        Catch ex As Exception
            Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            ENTRA = True
            ENTRA_FALLAS = True
            _myEditor = New MyEditorOTEXT(Fg, MULTIALMACEN)

            If tEstatus.Text <> "FINALIZADO" And tEstatus.Text <> "Cancelado" Then
                If DOC_NEW Then
                    tCVE_UNI.Select()
                Else
                    tLUGAR_REP.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DERECHOS()
        Dim z As Integer = 0
        Try
            If Not pwPoder Then
                Try
                    barGrabar.Enabled = False
                    BarEnlazarDoc.Enabled = False
                    barFinOT.Enabled = False
                    BarRemisionar.Enabled = False
                    barCancelarOT.Enabled = False
                    BarReimpresion.Enabled = False
                    BarCancPartNoEntr.Enabled = False

                    TabProductos.Enabled = False
                    TabServicios.Enabled = False
                    TabDocDigitales.Enabled = False
                    TabObser.Enabled = False

                    btnAltaProducto.Enabled = False
                    btnEliProd.Enabled = False
                    btnAltaServicio.Enabled = False
                    btnEliSer.Enabled = False

                    'SI TIENE  DERECHOS GRABAR
                    F1.Enabled = False : radCorrectivo.Enabled = False : radExtra.Enabled = False : radPreventivo.Enabled = False
                    tCVE_UNI.Enabled = False : tCVE_TIPO.Enabled = False : tEstatus.Enabled = False : tCVE_PROV.Enabled = False
                    tLUGAR_REP.Enabled = False : tNOTA.Enabled = False : tOBSER.Enabled = False : BtnServProg.Enabled = False
                    btnProgServ.Enabled = False : radSinistro.Enabled = False : RadRescateCarr.Enabled = False
                    RadLLantas.Enabled = False : BarEnlazarDoc.Enabled = False : btnProv.Enabled = False : btnTipo.Enabled = False
                    btnUnidades.Enabled = False : tDescrFotDoc.Enabled = False : btnFotDocA.Enabled = False : btnFotDocE.Enabled = False
                    btnBuscaDoc.Enabled = False : tCVE_ORD.Enabled = False : tOBSER.Enabled = False


                    SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 93000 AND CLAVE < 93500"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                Select Case dr("CLAVE")
                                    Case 93200  'GRABAR
                                        barGrabar.Enabled = True
                                        'SI TIENE  DERECHOS GRABAR
                                        F1.Enabled = True : radCorrectivo.Enabled = True : radExtra.Enabled = True : radPreventivo.Enabled = True
                                        tCVE_UNI.Enabled = True : tCVE_TIPO.Enabled = True : tEstatus.Enabled = True : tCVE_PROV.Enabled = True
                                        tLUGAR_REP.Enabled = True : tNOTA.Enabled = True : tOBSER.Enabled = True : BtnServProg.Enabled = True
                                        btnProgServ.Enabled = True : radSinistro.Enabled = True : RadRescateCarr.Enabled = True
                                        RadLLantas.Enabled = True : BarEnlazarDoc.Enabled = True : btnProv.Enabled = True : btnTipo.Enabled = True
                                        btnUnidades.Enabled = True : tDescrFotDoc.Enabled = True : btnFotDocA.Enabled = True : btnFotDocE.Enabled = True
                                        btnBuscaDoc.Enabled = True : tCVE_ORD.Enabled = True : tOBSER.Enabled = True
                                    Case 93210  'ENLAZAR COTIZACION
                                        BarEnlazarDoc.Enabled = True
                                    Case 93220  'FINALIZAR ORDEN DE TRABAJO
                                        barFinOT.Enabled = True
                                    Case 93230  'REMISIONAR
                                        BarRemisionar.Enabled = True
                                    Case 93240  'CANCELAR ORDER DE TRABAJO
                                        barCancelarOT.Enabled = True
                                    Case 93250  'REIMPRESION
                                        BarReimpresion.Enabled = True
                                    Case 93260  'CANCELAR PART. NO ENTREGADAS
                                        BarCancPartNoEntr.Enabled = True
                                    Case 93270  'PESTAÑA PRODUCTOS
                                        TabProductos.Enabled = True
                                    Case 93280  'PESTAÑA SERVICIOS
                                        TabServicios.Enabled = True
                                    Case 93290  'PESTAÑA DOCUMENTOS DIGITALES
                                        TabDocDigitales.Enabled = True
                                    Case 93300  'PESTAÑA OBSERVACIONES
                                        TabObser.Enabled = True
                                    Case 93310  'ALTA PARTIDAS PRODUCTOS
                                        btnAltaProducto.Enabled = True
                                    Case 93320  'ELIMINRA PARTIDA PRODUCTOS
                                        btnEliProd.Enabled = True
                                    Case 93330  'ALTA PARTIDA SERVICIOS
                                        btnAltaServicio.Enabled = True
                                    Case 93340  'ELIMINAR PARTIDA SERVICIOS
                                        btnEliSer.Enabled = True
                                End Select
                                z = z + 1
                            End While
                        End Using
                    End Using
                    If z = 0 Then
                        If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Then
                            barGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            BarRemisionar.Enabled = True
                            barCancelarOT.Enabled = True
                            BarReimpresion.Enabled = True
                            BarCancPartNoEntr.Enabled = True
                            TabProductos.Enabled = True
                            TabServicios.Enabled = True
                            TabDocDigitales.Enabled = True
                            TabObser.Enabled = True
                            btnAltaProducto.Enabled = True
                            btnEliProd.Enabled = True
                            btnAltaServicio.Enabled = True
                            btnEliSer.Enabled = True
                        End If
                        If USER_GRUPOCE.IndexOf("MANTE") > -1 Then
                            barGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            barFinOT.Enabled = True
                            BarReimpresion.Enabled = True
                            TabProductos.Enabled = True
                            TabServicios.Enabled = True
                            TabDocDigitales.Enabled = True
                            TabObser.Enabled = True
                            btnAltaProducto.Enabled = True
                            btnAltaServicio.Enabled = True
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, ISNULL(CVE_CPTO_OT,0) AS CVE_CPTOOT, " &
                "ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOT_SAL " &
                "FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
                CVE_CPTO_OT = dr("CVE_CPTOOT")
                CVE_CPTO_OT_SAL = dr("CVE_CPTOOT_SAL")
            End If
            dr.Close()

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT ISNULL(SERIE_REMISION, '') AS SERIE_REM " &
                "FROM GCPARAMVENTAS"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                SERIE_VENTA = dr("SERIE_REM")
            Else
                SERIE_VENTA = ""
            End If
            dr.Close()

        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DOC_FOTOS(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'O' AND CVE_FOTDOC = 0"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgD.Rows.Count = 1
            Do While dr.Read
                FgD.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & RUTA_DOC)
            Loop
            dr.Close()
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CARGAR_PRODUCTOS()
        If Not Valida_Conexion() Then
        End If
        If Not Valida_Conexion() Then
        End If
        Dim HayError As Boolean = False, HayDatos As Boolean = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String, COSTO As Decimal = 0, DESC1 As Single = 0, SUBTOTAL As Decimal = 0, CAD_OBS As String = 0, CANT As Single = 0
            Dim z As Integer = 1, piezas As Single = 0

            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.BackColor = Color.Red
            NewStyle1.ForeColor = Color.White


            cmd.Connection = cnSAE
            DESC1 = Val(tCVE_PROV.Tag)
            ENTRA = False
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(IMPORTE,0) AS IMPORT,
                ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa & " WHERE (REFER LIKE '%OT" & tCVE_ORD.Text & "%' OR REFER LIKE '%CCOT" & tCVE_ORD.Text &
                "%') AND CVE_ART = O.CVE_ART AND CVE_FOLIO = O.CVE_PROV),0) AS CANT_ENT,
                ISNULL(O.COSTO,0) AS COST, ISNULL(O.NO_PARTE,'') AS N_PARTE, TIPO_ELE, ISNULL(HORA2,'') AS MINVE, ISNULL(CVE_PROV,'') AS C_PROV,
                ISNULL(TIEMPO_REAL, '') AS REFER, ISNULL(TIPO,0) AS TIPO_I, ISNULL(O.STATUS, '-') AS ST, ISNULL(O.UUID,'') AS UID,
                ISNULL(CANT_ENTREGADA,0) AS CANT_ENTR, TIEMPO_SER
                FROM GCORDEN_TRA_SER_EXT O
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART
                WHERE CVE_ORD = '" & tCVE_ORD.Text & "' AND TIPO_PROD = 'P' ORDER BY FECHAELAB"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read

                    If Not Valida_Conexion() Then
                    End If
                    If Not Valida_Conexion() Then
                    End If

                    DESCR = dr("DES")
                    COSTO = dr("COST")
                    If dr("CLAVE") = "TOT" Then
                        DESCR = BUSCA_CAT("Prov", dr("N_PARTE"))
                        SUBTOTAL = dr("IMPORT") + (dr("IMPORT") * DESC1 / 100)
                    Else
                        SUBTOTAL = COSTO
                    End If
                    SUBTOTAL = SUBTOTAL * dr("CANTI")
                    Select Case dr("ST")
                        Case "M"
                            CAD_OBS = "Mov. realizado"
                        Case "C"
                            CAD_OBS = "Cancelada"
                        Case Else
                            CAD_OBS = ""
                    End Select
                    If dr("CLAVE") = "0109001052" Then
                        CAD_OBS = CAD_OBS
                    End If

                    CANT = Math.Round(dr("CANTI"), 4)

                    'CANT1 = Math.Truncate((Fg(k, 5) + Fg(k, 17)) * 10) / 10
                    'CANT2 = Math.Truncate(Fg(k, 10) * 10) / 10
                    'If CANT1 <> CANT2 Then
                    'End If

                    'CANT + CANT_ENTR <>  CANT

                    piezas = piezas + CANT '     1                2              3                   4                  5               6
                    Fg.AddItem(z & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & CANT & vbTab & COSTO & vbTab &
                        SUBTOTAL & vbTab & dr("REFER") & vbTab & CAD_OBS & vbTab & CANT & vbTab & Math.Abs(dr("CANT_ENT")) & vbTab &
                        dr("IMPORT") & vbTab & CAD_OBS & vbTab & dr("UID") & vbTab & dr("C_PROV") & vbTab & dr("MINVE") & vbTab & dr("CANT_ENTR") & vbTab &
                        dr.ReadNullAsEmptyString("TIEMPO_SER"))
                    '         12                  13                 14                   15                      16                      17                 18  
                    If CAD_OBS = "Cancelada" Then
                        Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                        Fg.SetCellStyle(Fg.Rows.Count - 1, 0, NewStyle1)
                    End If
                    If dr("CLAVE") = "0109001052" Then
                        CAD_OBS = CAD_OBS
                    End If
                    z = z + 1
                    HayDatos = True
                Loop
                If tEstatus.Text <> "FINALIZADO" And tEstatus.Text <> "Cancelado" Then
                    '                        1             2           3           4             5             6             7             8   
                    'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                    '       " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & VBTAB  & USUARIO)
                    '           9            10            11           12            13            14           15            16            17         18
                End If
                SUM_IMPORTES("P")
            Else
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
                '           9            10            11           12            13            14           15            16            17         18
            End If
            dr.Close()
            Me.Refresh()

            LtPiezas.Text = piezas
            LtPar.Text = z - 1

            ENTRA = True
        Catch ex As Exception
            HayError = True
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If HayError Then
            Me.Close()
        End If
    End Sub
    Sub CARGAR_SERVICIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String, COSTO As Decimal = 0, DESC1 As Single = 0, SUBTOTAL As Decimal = 0

            cmd.Connection = cnSAE

            DESC1 = Val(tCVE_PROV.Tag)
            ENTRA = False
            FgS.Rows.Count = 1

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,' ') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(IMPORTE,0) AS IMPORT, " &
                "ISNULL((SELECT SUM(CANT) FROM MINVE" & Empresa & " WHERE REFER = 'OT" & tCVE_ORD.Text & "' AND CVE_ART = O.CVE_ART),0) AS CANT_ENT, " &
                "ISNULL(O.COSTO,0) AS COST, ISNULL(O.NO_PARTE,'') AS N_PARTE, TIPO_ELE, " &
                "ISNULL(TIEMPO_REAL, '') AS REFER, ISNULL(TIPO,0) AS TIPO_I, ISNULL(O.STATUS, '-') AS ST, ISNULL(O.UUID,'') AS UID  " &
                "FROM GCORDEN_TRA_SER_EXT O " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART " &
                "WHERE CVE_ORD = '" & tCVE_ORD.Text & "' AND TIPO_PROD = 'S' ORDER BY FECHAELAB"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read
                    DESCR = dr("DES")
                    COSTO = dr("COST")
                    SUBTOTAL = COSTO
                    SUBTOTAL = SUBTOTAL * dr("CANTI")

                    FgS.AddItem("" & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & dr("CANTI") & vbTab & COSTO & vbTab &
                        SUBTOTAL & vbTab & dr("REFER") & vbTab & dr("ST") & vbTab & dr("CANTI") & vbTab & dr("CANT_ENT") & vbTab & dr("IMPORT") & vbTab &
                        IIf(dr("ST") = "M", "Mov. realizado", IIf(dr("ST") = "C", "Cancelada", "")) & vbTab & dr("UID"))
                Loop
                SUM_IMPORTES("S")
            Else
                FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab)
            End If
            dr.Close()
            Me.Refresh()
            ENTRA = True
        Catch ex As Exception
            Bitacora("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub SUM_IMPORTES(fTIPO As String)
        Try
            ENTRA = False
            Dim SUMA As Decimal = 0, SUBTOTAL As Decimal = 0, COSTO As Decimal = 0, DESC1 As Decimal
            DESC1 = Val(tCVE_PROV.Tag)
            If fTIPO = "P" Then
                Fg.FinishEditing()
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) > 0 And Fg(k, 9).ToString.Trim <> "Cancelada" Then
                        COSTO = Fg(k, 6)
                        If Fg(k, 1).ToString.Trim = "TOT" Then
                            SUBTOTAL = COSTO '+ (COSTO * DESC1 / 100)
                        Else
                            SUBTOTAL = COSTO
                        End If
                        SUMA = SUMA + (SUBTOTAL * Fg(k, 5))
                        Fg(k, 7) = (SUBTOTAL * Fg(k, 5))
                    End If
                Next
                Lt1.Text = Format(SUMA, "###,###,##0.00")
            Else
                FgS.FinishEditing()
                For k = 1 To FgS.Rows.Count - 1
                    If FgS(k, 1).ToString.Trim.Length > 0 And FgS(k, 5) > 0 Then
                        COSTO = FgS(k, 6)
                        If FgS(k, 1).ToString.Trim = "TOT" Then
                            SUBTOTAL = COSTO '+ (COSTO * DESC1 / 100)
                        Else
                            SUBTOTAL = COSTO
                        End If
                        SUMA = SUMA + (SUBTOTAL * FgS(k, 5))
                        FgS(k, 7) = (SUBTOTAL * FgS(k, 5))
                    End If
                Next
                Lt5.Text = Format(SUMA, "###,###,##0.00")
            End If
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            'tCVE_ORD.Text = ""
            F1.Value = Now
            radPreventivo.Checked = True
            radCorrectivo.Checked = False
            tCVE_UNI.Text = ""
            tCVE_TIPO.Text = ""
            tCVE_PROV.Text = ""
            tLUGAR_REP.Text = ""
            tNOTA.Text = ""

            ENTRA = False
            Fg.Rows.Count = 1

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
            Fg.Rows(Fg.Rows.Count - 1).Height = 30
            ENTRA = True

        Catch ex As Exception
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmOrdenDeTrabajoExtAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Orden de Trabajo")
            Me.Dispose()

            If SE_DESPLEGA Then
                If FORM_IS_OPEN("frmOrdenDeTrabajoExt") Then
                    'frmOrdenDeTrabajoExt.DESPLEGAR()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmOrdenDeTrabajoExtAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    BarGrabar_Click(Nothing, Nothing)
                Case Keys.F5
                    mnuSalir_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        Try
            If Not Valida_Conexion() Then
                Return
            End If
            GUARDAR("S")
        Catch ex As Exception
        End Try
    End Sub
    Sub GUARDAR(fMENSAJES As String)
        Dim CVE_OBS As Long, TIPO_SERVICIO As Integer, SUM_IMPORTE As Decimal = 0, CVE_ORD As String

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Fg.FinishEditing()
            If PERMITIR_UNIDAD = 0 Then
                Try
                    If Not UNIDAD_ESTA_EN_MANTO_EXTERNO_BASE(tCVE_UNI.Text) Then
                        MsgBox("La unidad " & tCVE_UNI.Text & " no se encuentra en mantenimientio Externo ó base")
                        Return
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
        Try
            If tCVE_UNI.Text.Trim.Length = 0 Then
                MsgBox("La unidad de debe quedar vacia")
                Return
            End If
        Catch ex As Exception
        End Try
        Try
            If tCVE_TIPO.Text.Trim = "1" Then
                If tNOTA.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture el Odometro")
                    tNOTA.Focus()
                    Return
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            If tOBSER.Text.Trim.Length > 0 Then
                If IsNumeric(tOBSER.Tag) Then
                    CVE_OBS = tOBSER.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tOBSER.Text & "')"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteScalar.ToString
                        If returnValue IsNot Nothing Then
                            If CLng(returnValue) > 0 Then
                                CVE_OBS = returnValue
                            End If
                        End If
                    End Using
                Else
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCOBS SET DESCR = '" & tOBSER.Text & "' WHERE CVE_OBS = " & CVE_OBS
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                End If
            End If
            tOBSER.Tag = CVE_OBS
        Catch ex As Exception
            'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            TIPO_SERVICIO = 0
            If radPreventivo.Checked = True Then
                TIPO_SERVICIO = 0
            End If
            If radCorrectivo.Checked = True Then
                TIPO_SERVICIO = 1
            End If
            If radExtra.Checked = True Then
                TIPO_SERVICIO = 2
            End If
            If radSinistro.Checked = True Then
                TIPO_SERVICIO = 3
            End If
            If RadRescateCarr.Checked = True Then
                TIPO_SERVICIO = 4
            End If
            If RadLLantas.Checked = True Then
                TIPO_SERVICIO = 5
            End If
        Catch ex As Exception
        End Try

        If Not Valida_Conexion() Then
            Return
        End If
        If DOC_NEW Then
            CVE_ORD = tCVE_ORD.Text
            Try
                CVE_ORD = OBTENER_CONSECUTIVO_OT(CVE_ORD)
                tCVE_ORD.Text = CVE_ORD

            Catch ex As Exception
                CVE_ORD = tCVE_ORD.Text
            End Try
        Else
            CVE_ORD = tCVE_ORD.Text
        End If

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            SQL = "UPDATE GCORDEN_TRABAJO_EXT SET CVE_ORD = @CVE_ORD, CVE_PROG = @CVE_PROG, ESTATUS = @ESTATUS, FECHA = @FECHA, TIPO_SERVICIO = @TIPO_SERVICIO,
                TIPO_EXTRA = @TIPO_EXTRA, CVE_UNI = @CVE_UNI, CVE_TIPO = @CVE_TIPO, CVE_PROV = @CVE_PROV, LUGAR_REP = @LUGAR_REP, NOTA = @NOTA,
                PORC_UTIL = @PORC_UTIL, GUID = @GUID
                WHERE CVE_ORD = @CVE_ORD
                IF @@ROWCOUNT = 0
                INSERT INTO GCORDEN_TRABAJO_EXT (CVE_ORD, STATUS, FECHA, FECHAELAB, TIPO_SERVICIO, TIPO_EXTRA, CVE_UNI, CVE_TIPO, ESTATUS, CVE_PROV, LUGAR_REP, 
                NOTA, CVE_OBS, PORC_UTIL, CVE_PROG, DOC_SIG, GUID) VALUES (@CVE_ORD, 'A', @FECHA, GETDATE(), @TIPO_SERVICIO, @TIPO_EXTRA, @CVE_UNI, @CVE_TIPO,
                @ESTATUS, @CVE_PROV, @LUGAR_REP, @NOTA, @CVE_OBS, @PORC_UTIL, @CVE_PROG, @DOC_SIG, @GUID)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = CVE_ORD
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Text
                cmd.Parameters.Add("@TIPO_SERVICIO", SqlDbType.SmallInt).Value = TIPO_SERVICIO
                cmd.Parameters.Add("@TIPO_EXTRA", SqlDbType.SmallInt).Value = IIf(radExtra.Checked, 1, 0)
                cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
                cmd.Parameters.Add("@CVE_TIPO", SqlDbType.VarChar).Value = tCVE_TIPO.Text
                cmd.Parameters.Add("@ESTATUS", SqlDbType.VarChar).Value = tEstatus.Text
                cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = tCVE_PROV.Text
                cmd.Parameters.Add("@LUGAR_REP", SqlDbType.VarChar).Value = tLUGAR_REP.Text
                cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = tNOTA.Text
                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                cmd.Parameters.Add("@PORC_UTIL", SqlDbType.Int).Value = 0
                cmd.Parameters.Add("@CVE_PROG", SqlDbType.VarChar).Value = tCVE_PROG.Text
                cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = LtDocAnt.Text
                cmd.Parameters.Add("@GUID", SqlDbType.VarChar).Value = USER_GRUPOCE
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        GRABAR_PRODUCTOS()
                        GRABAR_SERVICIOS()
                        GRABA_FOTOS_DOC()
                        Try
                            Dim IMP1 As Decimal = 0, IMP2 As Decimal = 0

                            Try
                                If IsNumeric(Lt5.Text.Replace(",", "")) Then
                                    IMP1 = CDec(Lt5.Text.Remove(",", ""))
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If IsNumeric(Lt1.Text.Replace(",", "")) Then
                                    IMP2 = CDec(Lt1.Text.Replace(",", ""))
                                End If
                            Catch ex As Exception
                            End Try
                            SUM_IMPORTE = IMP1 + IMP2
                        Catch ex As Exception
                            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        If ERROR_PAR Then
                            ERROR_PAR = False
                            MsgBox("Se detecto un problema al grabar las partidas por favor intentelo nuevamente")
                        Else
                            If DOC_ENLAZADO = "S" Then
                                GRABA_DOCTOSIG()
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        SQL = "UPDATE FACTC" & Empresa & " SET ENLAZADO = 'T', DOC_SIG = '" & tCVE_ORD.Text & "' WHERE CVE_DOC = '" & LtDocAnt.Text & "'"
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue = "1" Then
                                        End If
                                    End Using
                                Catch ex As Exception
                                    MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
                                    Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva orden de trabajo " &
                                           " Enlazado desde la cotizacion " & LtDocAnt.Text, "Se modifico orden de trabajo"), tCVE_ORD.Text)

                            Else
                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva", "Se modifico") & " orden de trabajo ", tCVE_ORD.Text)
                            End If
                            If fMENSAJES = "S" Then
                                MsgBox("El registro se grabo satisfactoriamente")
                            End If
                            ImprimirOrden(tCVE_ORD.Text)
                            Me.Close()
                        End If
                    Else
                        If fMENSAJES = "S" Then
                            MsgBox("No se logro grabar el registro")
                        End If
                    End If
                Else
                    If fMENSAJES = "S" Then
                        MsgBox("No se logro grabar el registro")
                    End If
                End If
            End Using

        Catch ex As SqlException
            ' Log the original exception here
            For Each sqlError As SqlError In ex.Errors
                Select Case sqlError.Number
                    Case 207                        ' 207 = InvalidColumn
                        'do your Stuff here
                        Exit Select
                    Case 547                        ' 547 = (Foreign) Key violation
                        'do your Stuff here
                        Exit Select
                    Case 2601                        ' 2601 = (Primary) key violation
                        'do your Stuff here
                        Exit Select
                    Case Else                        'do your Stuff here
                        Exit Select
                End Select
            Next
        End Try
    End Sub
    Sub GRABA_DOCTOSIG()
        Try
            Dim SUMA_IMPORTE As Decimal = 0
            Try
                If IsNumeric(Lt1.Text.Replace(",", "")) Then
                    SUMA_IMPORTE = Lt1.Text.Replace(",", "")
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(Lt5.Text.Replace(",", "")) Then
                    SUMA_IMPORTE = SUMA_IMPORTE + Lt5.Text.Replace(",", "")
                End If
            Catch ex As Exception
            End Try

            If Not Valida_Conexion() Then
            End If

            SQL = "INSERT INTO GCDOCTOSIG (TIPO_DOC, CVE_DOC, CVE_ORD, IMPORTE, IMPORTE_OT) VALUES('C','" &
                LtDocAnt.Text & "','" & tCVE_ORD.Text & "','" & LtDocAnt.Tag & "','" & SUMA_IMPORTE & "')"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PRODUCTOS()
        Try
            Dim STATUS As String = "", HORA2 As String, CANT_ENT As Single, CVE_FOLIO As String, UUID As String = "", TIEMPO_REAL As String = ""
            Dim CANT_CAPTURA As Single, CANT_ORIGINAL As Single, USUARIO_EDIT As String, COSTO As Decimal, IMPORTE As Decimal
            Dim DESCR As String = "", NO_PARTE As String = ""
            Dim cmd As New SqlCommand

            If Not Valida_Conexion() Then
                Return
            End If

            cmd.Connection = cnSAE
            Try
                If Fg.Col > 1 Then
                    Fg.Select()
                    SendKeys.Send("{ENTER}")
                End If
            Catch ex As Exception
                Bitacora("210. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            ERROR_PAR = False
            Dim CVE_ART As String, CANT As Decimal

            For k = 1 To Fg.Rows.Count - 1
                CVE_ART = "" : CANT = 0
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        CVE_ART = Fg(k, 1).ToString.Trim
                    Else
                        CVE_ART = 0
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                    Bitacora("212. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                Try
                    If Not IsNothing(Fg(k, 5)) Then
                        If IsNumeric(Fg(k, 5).ToString.Trim) Then
                            CANT = Fg(k, 5).ToString.Trim
                        Else
                            CANT = 0
                        End If
                    Else
                        CANT = 0
                    End If
                Catch ex As Exception
                    CANT = 0
                    Bitacora("214. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    If Not Valida_Conexion() Then
                    End If
                    Try
                        CANT_CAPTURA = Fg(k, 5)
                        CANT_ORIGINAL = Fg(k, 10)
                    Catch ex As Exception
                    End Try

                    Select Case Fg(k, 9)
                        Case "Mov. realizado"
                            STATUS = "M"
                        Case "Cancelada"
                            STATUS = "C"
                        Case Else
                            STATUS = ""
                    End Select
                    If PASS_GRUPOCE = "FRAJAXXX" Then
                        STATUS = "M"
                        HORA2 = "MINVE"
                        CANT_ENT = 0
                        CVE_FOLIO = BUSCAR_MINVE_CVE_FOLIO(tCVE_ORD.Text, Fg(k, 1).ToString)
                    Else
                        HORA2 = Fg(k, 16).ToString()
                        CANT_ENT = CONVERTIR_TO_DECIMAL(Fg(k, 17))
                        CVE_FOLIO = Fg(k, 15).ToString
                    End If
                    UUID = ""
                    Try
                        UUID = Fg(k, 14).ToString
                    Catch ex As Exception
                    End Try
                    If UUID.Trim.Length = 0 Then
                        UUID = Fg(k, 1) & Now.ToString
                    End If

                    If Valida_Conexion() Then
                        Try
                            If DOC_NEW Then
                                USUARIO_EDIT = ""
                            Else
                                If CANT_CAPTURA <> CANT_ORIGINAL Then
                                    USUARIO_EDIT = USER_GRUPOCE
                                Else
                                    USUARIO_EDIT = ""
                                End If
                            End If
                            Try
                                COSTO = 0
                                If Not IsNothing(Fg(k, 6)) Then
                                    If IsNumeric(Fg(k, 6).ToString.Trim) Then
                                        COSTO = Fg(k, 6).ToString.Trim
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                IMPORTE = 0
                                If Not IsNothing(Fg(k, 12)) Then
                                    If IsNumeric(Fg(k, 12).ToString.Trim) Then
                                        IMPORTE = Fg(k, 12).ToString.Trim
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                TIEMPO_REAL = ""
                                If Not IsNothing(Fg(k, 8)) Then
                                    TIEMPO_REAL = Fg(k, 8).ToString.Trim
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                DESCR = ""
                                If Not IsNothing(Fg(k, 3)) Then
                                    DESCR = Fg(k, 3).ToString.Trim
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                NO_PARTE = ""
                                If Not IsNothing(Fg(k, 4)) Then
                                    NO_PARTE = Fg(k, 4).ToString.Trim
                                End If
                            Catch ex As Exception
                            End Try

                            If Not Valida_Conexion() Then
                            End If

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCORDEN_TRA_SER_EXT SET CVE_ART = @CVE_ART, TIPO = @TIPO, DESCR = @DESCR, STATUS = @STATUS, CANT = @CANT, 
                                    COSTO = @COSTO, NO_PARTE = @NO_PARTE, IMPORTE = @IMPORTE, HORA2 = @HORA2, TIEMPO_REAL = @TIEMPO_REAL, 
                                    CANT_ENTREGADA = @CANT_ENTREGADA, CVE_PROV = @CVE_PROV, USUARIO_EDIT = @USUARIO_EDIT 
                                    WHERE UUID = @UUID
                                    IF @@ROWCOUNT = 0
                                    INSERT INTO GCORDEN_TRA_SER_EXT (CVE_ORD, TIPO_PROD, CVE_ART, CANT, COSTO, IMPORTE, NO_PARTE, DESCR, TIEMPO_REAL, STATUS, TIPO, 
                                    CVE_PROV, HORA2, CANT_ENTREGADA, USUARIO_ALTA, FECHAELAB, UUID) VALUES (@CVE_ORD, 'P', @CVE_ART, @CANT, @COSTO, @IMPORTE,
                                    @NO_PARTE, @DESCR, @TIEMPO_REAL, @STATUS, @TIPO, @CVE_PROV, @HORA2, @CANT_ENTREGADA, @USUARIO_ALTA, GETDATE(), NEWID())"

                                cmd2.CommandText = SQL
                                Try
                                    cmd2.Parameters.Clear()
                                    cmd2.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                                    cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = DESCR
                                    cmd2.Parameters.Add("@NO_PARTE", SqlDbType.VarChar).Value = NO_PARTE
                                    cmd2.Parameters.Add("@CANT", SqlDbType.Float).Value = Math.Round(CANT, 5)
                                    cmd2.Parameters.Add("@COSTO", SqlDbType.Float).Value = Math.Round(COSTO, 4)
                                    cmd2.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                                    cmd2.Parameters.Add("@TIEMPO_REAL", SqlDbType.VarChar).Value = TIEMPO_REAL
                                    cmd2.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS
                                    cmd2.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = 0
                                    cmd2.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = CVE_FOLIO
                                    cmd2.Parameters.Add("@HORA2", SqlDbType.VarChar).Value = HORA2
                                    cmd2.Parameters.Add("@CANT_ENTREGADA", SqlDbType.Float).Value = CANT_ENT
                                    cmd2.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                                    cmd2.Parameters.Add("@USUARIO_ALTA", SqlDbType.VarChar).Value = USER_GRUPOCE
                                    cmd2.Parameters.Add("@USUARIO_EDIT", SqlDbType.VarChar).Value = USUARIO_EDIT
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            If DOC_ENLAZADO = "S" And LtDocAnt.Text.Length > 0 Then
                                                Try
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        SQL = "UPDATE PAR_FACTC" & Empresa & " SET PXS = PXS - " & Math.Round(CANT) &
                                                                " WHERE CVE_DOC = '" & LtDocAnt.Text & "' AND CVE_ART = '" & CVE_ART & "'"
                                                        cmd3.CommandText = SQL
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue = "1" Then
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    Bitacora("216. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End If

                                            Try
                                                GRABA_BITA("", tCVE_ORD.Text, Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 6).ToString), 4), "T",
                                                           IIf(DOC_NEW, "Nueva partida", IIf(CANT_CAPTURA <> CANT_ORIGINAL, "Se modifico cantidad", "")),
                                                            tCVE_ORD.Text, Fg(k, 1).ToString)
                                            Catch ex As Exception
                                                Bitacora("216. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
                                    ERROR_PAR = True
                                End Try
                            End Using
                        Catch ex As Exception
                            Bitacora("216. " & ex.Message & vbNewLine & ex.StackTrace)
                            ERROR_PAR = True
                        End Try
                    Else
                        ERROR_PAR = True
                    End If 'VALIDA CONEXION
                End If
            Next
            ENTRA = True

        Catch ex As Exception
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCAR_MINVE_CVE_FOLIO(fCVE_ORD As String, fCVE_ART As String) As String
        Dim REFER As String, CVE_FOL As String = ""
        Try
            REFER = "OT" & fCVE_ORD

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_FOLIO FROM MINVE" & Empresa & " WHERE SUBSTRING(REFER, 1," & REFER.Length & ") = '" & REFER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_FOL = dr("CVE_FOLIO")
                    End If
                End Using
            End Using
            Return CVE_FOL
        Catch ex As Exception
            MsgBox("241. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("241. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_FOL
        End Try
    End Function
    Sub GRABAR_SERVICIOS()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand With {
                .Connection = cnSAE
            }, CANT As Decimal = 0

            SQL = "DELETE FROM GCORDEN_TRA_SER_EXT WHERE CVE_ORD = '" & tCVE_ORD.Text & "' AND TIPO_PROD = 'S'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            For k = 1 To FgS.Rows.Count - 1
                If FgS(k, 1).ToString.Trim.Length > 0 And CONVERTIR_TO_DECIMAL(FgS(k, 5).ToString) > 0 Then

                    If Not IsNothing(FgS(k, 5)) Then
                        If IsNumeric(FgS(k, 5).ToString.Trim) Then
                            CANT = FgS(k, 5).ToString.Trim
                        Else
                            CANT = 0
                        End If
                    Else
                        CANT = 0
                    End If

                    SQL = "INSERT INTO GCORDEN_TRA_SER_EXT (CVE_ORD, TIPO_PROD, CVE_ART, CANT, COSTO, IMPORTE, NO_PARTE, DESCR, TIEMPO_REAL, STATUS, 
                        TIPO, FECHAELAB, UUID) VALUES (@CVE_ORD, 'S', @CVE_ART, @CANT, @COSTO, @IMPORTE, @NO_PARTE, @DESCR, @TIEMPO_REAL, @STATUS, 
                        @TIPO, GETDATE(), NEWID())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(FgS(k, 1).ToString)
                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = FgS(k, 3).ToString
                        cmd.Parameters.Add("@NO_PARTE", SqlDbType.VarChar).Value = FgS(k, 4).ToString
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = Math.Round(CANT, 4)
                        cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgS(k, 6).ToString), 4)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar).Value = Math.Round(FgS(k, 12), 4)
                        cmd.Parameters.Add("@TIEMPO_REAL", SqlDbType.VarChar).Value = FgS(k, 8).ToString
                        cmd.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = 0
                        cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "M"
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABA_FOTOS_DOC()

        If Not Valida_Conexion() Then
            Return
        End If

        Dim DESCR As String, DOC As String, Ruta As String
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_ORD.Text & "' AND TIPO_DOC = 'O' AND ISNULL(CVE_FOTDOC,0) = 0"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
        Catch ex As Exception
        End Try
        For k = 1 To FgD.Rows.Count - 1
            Try
                DESCR = FgD(k, 1)
                DOC = FgD(k, 2).ToString
                Ruta = FgD(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_ORD.Text & "','0','" & DESCR & "','" & DOC & "','O')"

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If Ruta.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(DOC)
                            Dim newPath = Path.Combine(Ruta, DOC)
                            If Not File.Exists(RUTA_DOC & "\" & DOC) Then
                                File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Private Sub BarReimpresion_Click(sender As Object, e As EventArgs) Handles BarReimpresion.Click
        If DOC_NEW Then
            MsgBox("Para poder re-imprimir la orden de trabajo, por favor primero grabe la OT")
        Else
            ImprimirOrden(tCVE_ORD.Text)
        End If
    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        SE_DESPLEGA = False
        Me.Close()
    End Sub
    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var3
                L2.Text = Var6
                L2.Tag = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                tCVE_TIPO.Focus()
                Try
                    SEGONE = True
                    If SEGONE Then
                        Var5 = tCVE_UNI.Text
                        If Var5.Trim.Length > 0 Then
                            SEGONE = False
                            Var16 = FSQL(Date.Now)
                            DESPLEGAR()
                        End If

                    End If
                Catch ex As Exception
                End Try
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTipo_Click(sender As Object, e As EventArgs) Handles btnTipo.Click
        Try
            Var2 = "Tipo Unidad"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_TIPO.Text = Var4
                L4.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_PROV.Focus()
            End If

        Catch Ex As Exception
            MsgBox("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEliSer_Click(sender As Object, e As EventArgs) Handles btnEliSer.Click
        Try
            If FgS.Row > 0 Then
                Try
                    If FgS(FgS.Row, 1).ToString.Length = 0 Then
                        FgS.Col = 1
                        FgS.StartEditing()
                        Return
                    End If
                Catch ex As Exception
                End Try

                If MsgBox("Realmente desea eliminar la partida (artículo " & FgS(FgS.Row, 1) & ") ?", vbYesNo) = vbYes Then
                    Try
                        FgS.RemoveItem(FgS.Row)
                    Catch ex As Exception
                        Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                MsgBox("Por favor seleccione un servicio")
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_SERVICIOS(fCLAVE As String)
        Try
            Dim NO_PARTTE As String
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            If MsgBox("Realmente desea cargar las actividades de mantenimiento", vbYesNo) = vbNo Then
                Return
            End If

            ENTRA = False
            Fg.Rows.Count = 1
            SQL = "SELECT P.CVE_ART, ISNULL(P.DESCR,'') AS DES, ISNULL(TIEMPO,'') AS TIEMPO1, ISNULL(TIPO,0) AS TIPO_I, ISNULL(TIPO_ELE,'P') AS T_ELE, " &
                "ISNULL((SELECT TOP 1 CVE_ALTER FROM GCCVES_ALTER A WHERE CVE_ART = P.CVE_ART),'') AS N_PARTE " &
                "FROM GCSERVICIOS_MANTE_PAR P " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART " &
                "WHERE CVE_SER = '" & fCLAVE & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read

                NO_PARTTE = dr("N_PARTE")
                Fg.AddItem("" & vbTab & dr("CVE_ART").ToString & vbTab & "" & vbTab & dr("DES") & vbTab & NO_PARTTE & vbTab & "1" & vbTab &
                           "0" & dr("TIEMPO1") & vbTab & "0" & vbTab & " " & vbTab & "1" & vbTab & "" & vbTab & dr("T_ELE") & vbTab & "" & vbTab &
                           "" & vbTab & " " & vbTab & " " & vbTab & 0)
                Fg.Rows(Fg.Rows.Count - 1).Height = 30
            Loop
            dr.Close()
            ENTRA = True
        Catch ex As Exception
            MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    If PERMITIR_UNIDAD = 0 Then
                        L2.Text = DESCR
                        L2.Tag = Var5
                    Else
                        L2.Text = DESCR
                    End If
                    Try
                        If SEGONE Then
                            Var5 = tCVE_UNI.Text
                            If Var5.Trim.Length > 0 Then
                                SEGONE = False
                                Var16 = "S"
                                DESPLEGAR()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR()
        Try
            Dim w As Integer = 0
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT CVE_PROG, P.STATUS, P.CVE_UNI, T.DESCR AS TDESCR, ISNULL(SM.DESCR,'') AS DESCR_SM, FECHA_PROG, KM_ACTUAL, KM_PROX_SERVICIO, " &
                "ISNULL(P.CVE_OBS,'') AS OBS_STR, CVE_ORD, " &
                "ISNULL(STUFF((SELECT ' , ' + DESCR FROM GCPROGAMACION_SERVICIOS_PAR S INNER JOIN INVE" & Empresa & " I ON I.CVE_ART = S.CVE_ART WHERE S.CVE_PROG = P.CVE_PROG FOR XML PATH ('')),1,2, ''),'') AS PAR_SER " &
                "FROM GCPROGAMACION_SERVICIOS P " &
                "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                "LEFT JOIN GCSERVICIOS_MANTE SM ON SM.CVE_SER = P.CVE_SER " &
                "WHERE P.STATUS <> 'C' AND P.STATUS <> 'F' AND P.CVE_UNI = '" & tCVE_UNI.Text & "' "
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                w = w + 1
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("390. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("390. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    tCVE_TIPO.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_TIPO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TIPO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnTipo_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    tCVE_PROV.Focus()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_TIPO_Validated(sender As Object, e As EventArgs) Handles tCVE_TIPO.Validated
        Try
            If tCVE_TIPO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)
                If DESCR <> "" Then
                    L4.Text = DESCR
                    tCVE_PROV.Focus()
                Else
                    MsgBox("Tipo Unidad inexistente")
                    tCVE_TIPO.Text = ""
                    tCVE_TIPO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirOdenDeCompra(fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()


            Select Case Empresa
                Case "01"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "02"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra02.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "03"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra03.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra03.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "04"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra04.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra04.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "05"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra05.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra05.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "06"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra06.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra06.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "07"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra07.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra07.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "08"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra08.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra08.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "09"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra09.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportCompra09.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "10"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra10.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra10.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "11"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra11.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra11.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                Case "12"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra12.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "13"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra13.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "14"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra14.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "15"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra15.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "16"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra16.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "17"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra17.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "18"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra18.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "19"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra19.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "20"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra20.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "21"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra21.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case "22"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra22.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                Case Else
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
            End Select

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("REFER") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirOrden(fCVE_ORD As String)
        Dim RUTA_FORMATOS As String = ""
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenTrabajoExterna.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportOrdenTrabajoExterna.mrt, verifique por favor")
                Return
            End If

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET IMPORTE = CANT * COSTO WHERE CVE_ORD = '" & fCVE_ORD & "'"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
            End Try

            StiReport1.Load(RUTA_FORMATOS & "\ReportOrdenTrabajoExterna.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("CVE_ORDEN") = fCVE_ORD
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirMinve(fREFER As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            Select Case Empresa
                Case "01"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "02"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE02.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "03"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE03.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "04"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE04.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "05"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE05.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "06"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE06.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "07"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE07.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "08"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE08.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "09"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE09.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "10"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE10.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "11"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE11.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "12"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE12.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "13"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE13.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "14"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE14.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "15"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE15.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "16"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE16.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "17"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE17.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "18"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE18.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "19"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE19.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "20"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE20.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "21"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE21.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case "22"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE22.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
                Case Else
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & " verifique por favor")
                        Return
                    End If
            End Select

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.Item("REFER") = fREFER

            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaServicio_Click(sender As Object, e As EventArgs) Handles btnAltaServicio.Click
        Try
            If FgS(FgS.Rows.Count - 1, 1).ToString.Trim.Length > 0 And FgS(FgS.Rows.Count - 1, 3).ToString.Trim.Length > 0 Then
                FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab)
            End If
            FgS.Row = FgS.Rows.Count - 1
            FgS.Col = 1
            FgS.StartEditing()
        Catch ex As Exception
            MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Not ACCESO_USUARIO Then
                Return
            End If
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                        Return
                    End If
                End If
            Catch ex As Exception
                Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If Fg.Row > 0 And ENTRA Then
                Dim c_ As Integer
                If Fg.Col = 2 Then
                    c_ = 1
                Else
                    c_ = Fg.Col
                End If
                _myEditor.StartEditing(Fg.Row, c_)
            End If
        Catch ex As Exception
            Bitacora("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                    Return
                End If
            End If
            If ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 5 Then
                    Dim c_ As Integer
                    If Fg.Col = 2 Then
                        c_ = 1
                    Else
                        c_ = Fg.Col
                    End If
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub IMPRIMIR_COMPRA(fTIPO_DOC As String, fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            Select Case fTIPO_DOC
                Case "c"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportCompra.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportCompra.mrt, verifique por favor")
                        Return
                    End If
                    StiReport1.Load(RUTA_FORMATOS & "\ReportCompra.mrt")
                Case "r"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportRecepcion.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportRecepcion.mrt, verifique por favor")
                        Return
                    End If
                    StiReport1.Load(RUTA_FORMATOS & "\ReportRecepcion.mrt")
                Case "o"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt, verifique por favor")
                        Return
                    End If
                    StiReport1.Load(RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt")
            End Select


            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("REFER") = fCVE_DOC
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV_Validating(sender As Object, e As CancelEventArgs) Handles tCVE_PROV.Validating
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String

                If IsNumeric(tCVE_PROV.Text.Trim) Then
                    DESCR = tCVE_PROV.Text.Trim
                    DESCR = Space(10 - Len(DESCR)) & DESCR
                    tCVE_PROV.Text = DESCR
                End If
                DESCR = BUSCA_CAT("ClieOT", tCVE_PROV.Text)
                If DESCR <> "" Then
                    L3.Text = DESCR
                    tCVE_PROV.Tag = Var6
                    L3.Tag = Var7
                Else
                    MsgBox("Cliente inexistente")
                    tCVE_PROV.Text = ""
                    tCVE_UNI.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                L3.Text = Var5
                tCVE_PROV.Tag = Var8
                L3.Tag = Var9

                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                tLUGAR_REP.Focus()
            End If

        Catch Ex As Exception
            MsgBox("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("560. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                        e.Cancel = True
                        Return
                    End If
                End If
            Catch ex As Exception
            End Try

            ENTRA_BTN = False
            'Var2 = "InvenRS"
            Var2 = "InveP"
            Var4 = ""
            Var5 = ""
            Fg.FinishEditing()

            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                Fg.FinishEditing()

                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                'Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                Dim DESC1 As Single = 0, PRECIO As Single = 0
                Try
                    DESC1 = Val(tCVE_PROV.Tag)
                    If DESC1 = 0 Then
                        PRECIO = Val(Var9) / 0.95
                    Else
                        PRECIO = Val(Var9) + (Val(Var9) * DESC1 / 100)
                    End If
                    PRECIO = Math.Round(PRECIO, 4)
                Catch ex As Exception
                End Try

                Fg(Fg.Row, 1) = Var4  'CVE_ART
                Fg(Fg.Row, 3) = Var5  'DESCR
                Fg(Fg.Row, 4) = Var6  'NO_PARTE
                Fg(Fg.Row, 6) = PRECIO 'precio
                Fg(Fg.Row, 11) = Var8  'TIPO ELE
                Try
                    If Fg(Fg.Row, 5) = 0 Then
                        Fg(Fg.Row, 7) = PRECIO
                    Else
                        Fg(Fg.Row, 7) = Fg(Fg.Row, 5) * PRECIO
                    End If
                Catch ex As Exception

                End Try
                Var2 = "" : Var4 = "" : Var5 = ""
                ENTRA = True
                Fg.Col = 5
                _myEditor.StartEditing(e.Row, 5)
            Else
                Fg.Col = 1 'ARTICULO
                _myEditor.StartEditing(e.Row, 1)
            End If
            ENTRA_BTN = True
        Catch ex As Exception
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnProv_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                If IsNumeric(tCVE_PROV.Text.Trim) Then
                    tCVE_PROV.Text = Space(10 - tCVE_PROV.Text.Trim.Length) & tCVE_PROV.Text.Trim
                End If
                tLUGAR_REP.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TNOTA_KeyDown(sender As Object, e As KeyEventArgs) Handles tNOTA.KeyDown
        Try
            If e.KeyCode = 13 Then

                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                _myEditor.StartEditing(Fg.Row, 1, 99)
                'Fg.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                        Return
                    End If
                End If
            Catch ex As Exception
            End Try
            If Fg.Row > 0 Then

                If Fg(Fg.Row, 1) = "TOT" Then
                    TIPO_COMPRA = "o"
                    Var17 = "N"
                    Var22 = 0
                    Cp1 = tCVE_UNI.Text
                    Cp2 = tCVE_TIPO.Text

                    If Fg(Fg.Row, 8).ToString.Trim.Length > 1 Then
                        Var11 = "edit"
                        Var12 = Fg(Fg.Row, 8)
                        frmComprasTrans.ShowDialog()
                    Else
                        Var11 = ""
                        Var12 = ""
                    End If
                End If

            End If
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub EntraFlex(fENTRA As Boolean)
        Try
            ENTRA = fENTRA
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles tBotonMagico.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 1 Then
                c_ = 1
            Else
                c_ = Fg.Col
            End If
            _myEditor.StartEditing(Fg.Row, c_)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgS.AfterEdit
        Try
            If Not ACCESO_USUARIO Then
                Return
            End If

            If e.Row > 0 Then
                If e.Col = 1 Then
                    Return
                End If
            End If
        Catch ex As Exception
            MsgBox("670. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgS_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgS.BeforeEdit
        Try
            If tEstatus.Text = "FINALIZADA" Or tEstatus.Text = "REMISIONADA" Then
                e.Cancel = True
                Return
            End If
            If FgS.Row > 0 And ENTRA Then
                ENTRA = False
                If FgS.Col = 0 Or FgS.Col = 3 Or FgS.Col = 4 Or FgS.Col = 7 Or FgS.Col = 8 Then
                    e.Cancel = True
                End If

                If FgS(FgS.Row, 10) > 0 Then
                    If (FgS(FgS.Row, 10) - Val(FgS(FgS.Row, 11))) <= 0 Then
                        e.Cancel = True
                    End If
                End If
                If FgS(FgS.Row, 9) = "M" Then
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("680. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgS.CellButtonClick
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            ENTRA_BTN = False
            'Var2 = "InvenRS"
            Var2 = "InvenRS"
            Var4 = ""
            Var5 = ""
            FgS.FinishEditing()

            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                FgS.FinishEditing()
                FgS(FgS.Row, 1) = Var4  'CVE_ART
                FgS(FgS.Row, 3) = Var5  'DESCR
                FgS(FgS.Row, 4) = Var6  'NO_PARTE
                FgS(FgS.Row, 11) = Var8  'TIPO ELE
                Var2 = ""
                Var4 = ""
                Var5 = ""
                ENTRA = True
                FgS.Col = 5
            Else
                FgS.Col = 1
            End If
            ENTRA_BTN = True
        Catch ex As Exception
            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_Click(sender As Object, e As EventArgs) Handles FgS.Click
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If FgS.Row > 0 And ENTRA Then
                ENTRA = False
                If tEstatus.Text = "FINALIZADA" Or tEstatus.Text = "REMISIONADA" Then
                Else
                    If FgS(FgS.Row, 10) > 0 Then
                        If (FgS(FgS.Row, 10) - Val(FgS(FgS.Row, 11))) <= 0 Then
                            FgS.FinishEditing()
                            ENTRA = True
                            Return
                        End If
                    End If
                    If FgS(FgS.Row, 9) = "M" Then
                        FgS.FinishEditing()
                        ENTRA = True
                        Return
                    End If
                    If (FgS.Col = 1 Or FgS.Col = 2 Or FgS.Col = 5 Or FgS.Col = 6) And FgS(FgS.Row, 9) <> "M" Then
                        FgS.StartEditing()
                    End If
                    ENTRA = True
                End If
            End If
        Catch ex As Exception
            MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_EnterCell(sender As Object, e As EventArgs) Handles FgS.EnterCell
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If FgS.Row > 0 And ENTRA Then
                ENTRA = False
                If FgS(FgS.Row, 10) > 0 Then
                    If FgS(FgS.Row, 10) - FgS(FgS.Row, 11) <= 0 Then
                        FgS.FinishEditing()
                        ENTRA = True
                        Return
                    End If
                End If

                If FgS(FgS.Row, 9) = "M" Then
                    FgS.FinishEditing()
                    ENTRA = True
                    Return
                End If
                If FgS.Col = 2 Or FgS.Col = 3 Or FgS.Col = 4 Or FgS.Col = 7 Or FgS.Col = 8 Or FgS.Col = 9 Then

                Else
                    If FgS(FgS.Row, 9) <> "M" And tEstatus.Text <> "FINALIZADA" Then

                        If FgS.Col = 5 Then
                            FgS(FgS.Row, 5) = "1"
                        End If

                        FgS.StartEditing()
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_GotFocus(sender As Object, e As EventArgs) Handles FgS.GotFocus
        ENTRA_KEY = False
    End Sub

    Private Sub FgS_KeyDown(sender As Object, e As KeyEventArgs) Handles FgS.KeyDown
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If FgS.Row > 0 Then
                If tEstatus.Text = "FINALIZADA" Or tEstatus.Text = "REMISIONADA" Then
                    Return
                End If
                If FgS.Col = 1 And e.KeyCode = 27 Then
                    If FgS(FgS.Row, 1).ToString.Trim.Length = 0 Or FgS(FgS.Row, 3).ToString.Trim.Length = 0 Then
                        FgS.RemoveItem(FgS.Row)
                        REMOVE_ROW = FgS.Row
                        Return
                    End If
                    Return
                End If
                If FgS.Col = 1 And e.KeyCode = Keys.Down Then
                    If FgS(FgS.Row, 1).ToString.Trim.Length > 0 And FgS(FgS.Row, 3).ToString.Trim.Length > 0 Then
                        FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab)
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgS.KeyDownEdit
        Try
            If tEstatus.Text = "FINALIZADA" Or tEstatus.Text = "REMISIONADA" Then
                Return
            End If
            If e.KeyCode = 27 Then
                If FgS.Col = 3 Then
                    If FgS(FgS.Row, 3).ToString.Trim.Length = 0 Or FgS(FgS.Row, 4).ToString.Trim.Length = 0 Then
                        FgS.RemoveItem(FgS.Row)
                        REMOVE_ROW = FgS.Row
                        Return
                    End If
                End If
                Return
            End If
            If FgS.Col = 1 And e.KeyCode = Keys.F2 Then
                FgS_CellButtonClick(Nothing, Nothing)
                Return
            End If
            If (e.KeyCode = 13 Or e.KeyCode = 9) And ENTRA Then
                ENTRA = False
                Select Case e.Col
                    Case 1
                        'FgS.Col = 4
                        'FgS.StartEditing()
                    Case 6
                        SUM_IMPORTES("S")
                        If FgS(e.Row, 1).ToString.Trim.Length > 0 And FgS(e.Row, 3).ToString.Trim.Length > 0 Then
                            If FgS.Row = FgS.Rows.Count - 1 Then
                                FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                                    " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab)
                                FgS.Row = FgS.Rows.Count - 1
                            Else
                                FgS.Row = FgS.Row + 1
                            End If
                            FgS.Col = 0
                            Var9 = "S"
                            tBotonMagico.Focus()
                            FgS.StartEditing()
                            ENTRA = True
                            Return
                        End If
                End Select
                ENTRA = True
                Return
            End If
            If e.Col = 8 Then

            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_LostFocus(sender As Object, e As EventArgs) Handles FgS.LostFocus
        ENTRA_KEY = True
    End Sub
    Private Sub FgS_SetupEditor(sender As Object, e As RowColEventArgs) Handles FgS.SetupEditor
        Try
            If e.Row > 0 Then
                If e.Col = 1 Then
                    Dim tb As TextBox = FgS.Editor
                    tb.CharacterCasing = CharacterCasing.Upper
                End If
            End If
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgS_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgS.ValidateEdit
        Try
            If FgS.Row > 0 And ENTRA Then
                If FgS(e.Row, 9) = "M" Then
                    'e.Cancel = True
                Else
                    ENTRA = False
                    If FgS.Col = 1 Then
                        If FgS.Editor.Text.Trim.Length > 0 Then
                            If FgS.Editor.Text <> "TOT" Then
                                Dim DESCR As String
                                DESCR = BUSCA_CAT("InveS", FgS.Editor.Text)
                                If DESCR <> "" Then
                                    FgS(FgS.Row, 1) = FgS.Editor.Text
                                    FgS(FgS.Row, 3) = DESCR
                                    FgS(FgS.Row, 4) = Var6
                                    If FgS(FgS.Row, 5).ToString.Length = 0 Or FgS(FgS.Row, 5) = 0 Then
                                        FgS(FgS.Row, 5) = 1  'CANTI
                                    End If
                                    FgS(FgS.Row, 6) = Var7  'PRECIO
                                    FgS(FgS.Row, 11) = Var8  'TIPO ELE
                                    FgS.Col = 4
                                Else
                                    e.Cancel = True
                                    MsgBox("Articulo inexistente")
                                End If
                            End If
                        End If
                    End If
                    If FgS.Col = 5 Then
                        If IsNumeric(FgS.Editor.Text) Then
                            If CInt(FgS.Editor.Text) = 0 Then
                                FgS.Editor.Text = "1"
                                'e.Cancel = True
                            End If
                        Else
                            FgS.Editor.Text = "1"
                        End If
                    End If
                    ENTRA = True
                End If
            End If
        Catch ex As Exception
            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaProducto_Click(sender As Object, e As EventArgs) Handles btnAltaProducto.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 3).ToString.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
            End If
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)

        Catch ex As Exception
            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliProd_Click(sender As Object, e As EventArgs) Handles btnEliProd.Click
        Try
            If Fg.Row > 0 Then
                Dim Sigue As Boolean = False

                If Fg(Fg.Row, 1).ToString.Trim = "" Then
                    MessageBox.Show("La partida no tienre clave del articulo")
                    Return
                End If

                If Fg(Fg.Row, 9) = "Cancelada" Then
                    MessageBox.Show("La partida se encuentra cancelada")
                    Return
                End If
                If Fg(Fg.Row, 9) = "Mov. realizado" Then
                    Sigue = True
                Else
                    Sigue = True
                End If
                If Sigue Then
                    If MsgBox("Realmente desea cancelar la(s) partida(s) seleccionada(s) ?", vbYesNo) = vbYes Then
                        Try
                            CANCELAR_MOVS()
                        Catch ex As Exception
                            Bitacora("860. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("860. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Else
                    MessageBox.Show("Usuario sin derechos, solo almacén puede cancelar partidas procesadas")
                    Return
                End If

            Else
                MsgBox("Por favor seleccione un articulo")
            End If
        Catch ex As Exception
            Bitacora("880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CANCELAR_MOVS()

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim r_ As Row, z As Integer = 0, CVE_DOC As String

            CVE_DOC = "CCOT" & tCVE_ORD.Text & "_" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
            If CVE_DOC.Length > 20 Then
                CVE_DOC = CVE_DOC.Substring(0, 20)
            End If

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    If Fg(r_.Index, 9) = "Mov. realizado" Then
                        Try        'UUID
                            If Fg(r_.Index, 14).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(r_.Index)
                            Else
                                GENERA_MINVE_OT(CVE_DOC, Fg(r_.Index, 1), Fg(r_.Index, 11), Fg(r_.Index, 14), r_.Index, 1)

                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T",
                                           "Cancelacion partida Orden de trabajo con mov. ralizado, articulo " &
                                           Fg(r_.Index, 1) & " cant. " & Fg(r_.Index, 11))
                                Try
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'C', HORA2 = '', CVE_PROV = '', 
                                        TIEMPO_SER = '" & USER_GRUPOCE & "' WHERE UUID = '" & Fg(r_.Index, 14) & "'"
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                            z = z + 1
                        Catch ex As Exception
                            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        If Fg(r_.Index, 1) <> "OT" And Fg(r_.Index, 9) <> "Cancelada" Then
                            Try 'UUID
                                If Fg(r_.Index, 14).ToString.Trim.Length = 0 Then
                                    Fg.RemoveItem(r_.Index)
                                    z = z + 1
                                Else
                                    Try
                                        SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'C' WHERE UUID = '" & Fg(r_.Index, 14) & "'"
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                    Fg(r_.Index, 9) = "Cancelada"
                                                    GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Cancelacion partida Orden de trabajo SIN mov. ralizado articulo " &
                                                            Fg(r_.Index, 1) & " cant. " & Fg(r_.Index, 5))
                                                End If
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("920. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    z = z + 1
                                End If
                            Catch ex As Exception
                                Bitacora("940. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            Next

            If z > 0 Then
                If NProc > 0 Then
                    ImprimirMinve(CVE_DOC)
                Else
                    MsgBox("No se logro cancelar partida(s)")
                End If
            Else
                MsgBox("No se encontraron partida(s) a cancelar")
            End If

            Try

                If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 Then
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
                End If
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                _myEditor.StartEditing(Fg.Row, 1)

            Catch ex As Exception
                Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GENERA_MINVE_OT(fCVE_DOC As String, fCVE_ART As String, fCANT As Single, fUUID As String, fROW As Integer, fSIGNO As Integer)
        Dim CVE_ART As String = ""
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer, COSTEADO As String = "S", COSTO_PROM_INI As Single
        Dim COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P"
        Dim ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = ""
        Dim E_LTPD As String = ""
        Dim CVE_DOC As String, CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0
        Dim NO_HAY_EXIST As Integer = 0, Cadena_signo As String = ""
        Dim HayPart As Boolean, Continua As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Fg.FinishEditing()

            'CVE_CPTO_OT = dr("CVE_CPTOOT")
            'CVE_CPTO_OT_SAL = dr("CVE_CPTOOT_SAL")
            SIGNO = fSIGNO

            If SIGNO = 1 Then
                CVE_CPTO = CVE_CPTO_OT
                Cadena_signo = " + "
            Else
                CVE_CPTO = CVE_CPTO_OT_SAL
                Cadena_signo = " - "
            End If

            CVE_ART = fCVE_ART
            CANT = fCANT
        Catch ex As Exception
        End Try

        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            CVE_DOC = fCVE_DOC
            If CVE_DOC.Length > 20 Then
                CVE_DOC = CVE_DOC.Substring(0, 20)
            End If
            HayPart = False

            If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                HayPart = True
                Try
                    SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE " &
                            "FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader
                    If dr.Read Then
                        EXIST = dr("EXIST")
                        UNI_MED = dr("UNI_MED")
                        COSTO = dr("ULT_COSTO")
                        COSTO_PROM = dr("COSTO_PROM")
                        TIPO_PROD = dr("TIPO_ELE")
                        ExistProd = True
                    End If
                    dr.Close()
                Catch ex As Exception
                    Bitacora("1000. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1000. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If TIPO_PROD = "P" Then
                    NO_HAY_EXIST = NO_HAY_EXIST + 1
                    Try
                        ALMACEN = 1

                        If ALMACEN = 0 Then ALMACEN = 1

                        COSTO_PROM_INI = COSTO_PROM
                        COSTO_PROM_FIN = COSTO_PROM
                    Catch ex As Exception
                        Bitacora("1030. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1030. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If MULTIALMACEN = 1 Then
                            SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) " & Cadena_signo & CANT &
                                " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN &
                                "If @@ROWCOUNT = 0 " &
                                "INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, " &
                                "EXIST, STOCK_MIN, STOCK_MAX, COMP_X_REC, UUID, VERSION_SINC) VALUES('" & CVE_ART & "','" & ALMACEN & "','A','','" &
                                CANT & "', 0, 0, 0, NEWID(), GETDATE())"

                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("1070. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1070. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try
                    Continua = True
                    Try
                        SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) " & Cadena_signo & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("1180. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1180. " & ex.Message & vbNewLine & ex.StackTrace)
                        Continua = False
                    End Try
                    If Continua Then
                        Continua = False
                        Try
                            'SQL = "IF NOT EXISTS(SELECT REFER FROM MINVE" & Empresa & " WHERE REFER = '" & CVE_DOC & "' AND CVE_ART = '" &
                            'CVE_PROD & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & ALMACEN & ")
                            If Not Valida_Conexion() Then
                            End If

                            SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, 
                                FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, 
                                EXISTENCIA, TIPO_PROD, FACTOR_CON, FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, 
                                DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" & CVE_ART & "','" & ALMACEN & "'," &
                                "(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                                CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                            If MULTIALMACEN = 1 Then
                                SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                            Else
                                SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                            End If
                            SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ISNULL(ULT_CVE,0) + 1 FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                  SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" &
                                  MOV_ENLAZADO & "','" & COSTO_PROM & "')"

                            For k = 1 To 5
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        NProc = NProc + 1
                                        Exit For
                                    End If
                                End If
                            Next

                            Try
                                SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'Captura' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'C', HORA2 = '', CVE_PROV = '' WHERE UUID = '" & fUUID & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Fg(fROW, 9) = "Cancelada"
                                        Fg(fROW, 13) = ""
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) 
                                            FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        Catch ex As Exception
                            Bitacora("1200. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1200. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If 'continua
                End If 'producto
            End If 'CVE_ART.Trim.Length > 0 And CANT > 0

        Catch ex As Exception
            Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnBuscaDoc_Click(sender As Object, e As EventArgs) Handles btnBuscaDoc.Click
        Try
            OpenFileDialog1.Title = "Por favor seleccione un archivo"
            OpenFileDialog1.Filter = "Todos los archivos|*.*"
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim ruta As String
                ruta = Path.GetDirectoryName(OpenFileDialog1.FileName)
                LtFotoDoc.Text = Path.GetFileName(OpenFileDialog1.FileName)
                LtFotoDoc.Tag = ruta
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnFotDocA_Click(sender As Object, e As EventArgs) Handles btnFotDocA.Click
        Try
            If tDescrFotDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor la descripcion del documento")
                FgD.Focus()
                Return
            End If
            If LtFotoDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            FgD.AddItem("" & vbTab & tDescrFotDoc.Text & vbTab & LtFotoDoc.Text & vbTab & LtFotoDoc.Tag & vbTab & "1")

            tDescrFotDoc.Text = ""
            LtFotoDoc.Tag = ""

        Catch Ex As Exception
            Bitacora("1320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("1320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFotDocE_Click(sender As Object, e As EventArgs) Handles btnFotDocE.Click
        Try
            If FgD.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    FgD.RemoveItem(FgD.Row)
                End If
            End If
        Catch Ex As Exception
            Bitacora("1340. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("1340. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_DoubleClick(sender As Object, e As EventArgs) Handles FgD.DoubleClick
        Try
            If FgD.Row > 0 Then
                If File.Exists(FgD(FgD.Row, 3) & "\" & FgD(FgD.Row, 2)) Then
                    Process.Start(FgD(FgD.Row, 3) & "\" & FgD(FgD.Row, 2))
                Else
                    MessageBox.Show("El documento " & FgD(FgD.Row, 3) & "\" & FgD(FgD.Row, 2) & " no existe")
                End If
            Else
                MessageBox.Show("Por favor seleccione un documento")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_UNI_GotFocus(sender As Object, e As EventArgs) Handles tCVE_UNI.GotFocus
        Try
            If SEGONE Then
                Var5 = tCVE_UNI.Text
                If Var5.Trim.Length > 0 Then
                    SEGONE = False
                    Var16 = FSQL(Date.Now)
                    DESPLEGAR()
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnProgServ_Click(sender As Object, e As EventArgs) Handles btnProgServ.Click
        Try
            Var5 = tCVE_UNI.Text
            If Var5.Trim.Length > 0 Then
                SEGONE = False
                Var16 = FSQL(Date.Now)
                DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnServProg_Click(sender As Object, e As EventArgs) Handles BtnServProg.Click
        Try
            Var5 = tCVE_UNI.Text
            If Var5.Trim.Length > 0 Then
                Var16 = ""
                'BOTON LUPA
                frmProgServShow.ShowDialog()
                If Var16.Trim.Length > 0 Then
                    tCVE_PROG.Text = Var16
                    LProgServ.Text = Var17
                Else
                    MsgBox("No se encontraron servicios programados")
                    tCVE_PROG.Text = ""
                    LProgServ.Text = ""
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                    e.Cancel = True
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If ENTRA Then
                If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Bitacora("1360. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        If ENTRA Then
            If _myEditor.Visible Then
                _myEditor.UpdatePosition()
            End If
        End If
    End Sub
    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 9) = "Mov. realizado" Or Fg(Fg.Row, 9) = "Cancelada" Then
                    Return
                End If
            End If
            If ENTRA Then
                _myEditor.SetPendingKey(e.KeyChar)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub PROCESAR_TABLA_OT()
        Dim CVE_ART As String, CANT As Decimal, PRECIO As Decimal, CVE_DOC As String
        Dim NREG As Integer = 0

        Var23 = 0

        Try
            SQL = "DELETE FROM GCOT"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            'SQL = "CREATE TABLE GCOT (CVE_ORD VARCHAR(10) NULL, CVE_CLIE varchar(10) NULL, CVE_ART VARCHAR(16) NULL, CANT FLOAT NULL) ON [PRIMARY]"
            For k = 1 To Fg.Rows.Count - 1

                CVE_ART = Fg(k, 1)
                CANT = Fg(k, 5)
                PRECIO = Fg(k, 6)
                CVE_DOC = Fg(k, 8)

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    If CVE_ART = "TOT" Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_ART, CANT, COST FROM PAR_COMPO" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read
                                        If tCVE_ORD.Text.Trim.Length > 0 Then
                                            Try
                                                SQL = "INSERT INTO GCOT (CVE_ORD, CVE_ART, CANT, PRECIO) VALUES('" &
                                                    tCVE_ORD.Text & "','" & dr("CVE_ART") & "','" & dr("CANT") & "','" & dr("COST") & "')"

                                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                    cmd2.CommandText = SQL
                                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                            NREG = NREG + 1
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                Bitacora("1390. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("1400. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        If Fg(k, 9) = "Mov. realizado" Then
                            If tCVE_ORD.Text.Trim.Length > 0 Then
                                Try
                                    SQL = "INSERT INTO GCOT (CVE_ORD, CVE_ART, CANT, PRECIO) VALUES('" &
                                        tCVE_ORD.Text & "','" & CVE_ART & "','" & CANT & "','" & PRECIO & "')"
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                NREG = NREG + 1
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End If
                End If
            Next

            For k = 1 To FgS.Rows.Count - 1

                CVE_ART = FgS(k, 1)
                CANT = FgS(k, 5)
                PRECIO = FgS(k, 6)

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    If tCVE_ORD.Text.Trim.Length > 0 Then
                        Try
                            SQL = "INSERT INTO GCOT (CVE_ORD, CVE_ART, CANT, PRECIO) VALUES('" &
                                tCVE_ORD.Text & "','" & CVE_ART & "','" & CANT & "','" & PRECIO & "')"

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        NREG = NREG + 1
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("1440. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Var23 = NREG

    End Sub
    Sub MARCAR_OT_COMO_REMISIONADA()
        Try
            SQL = "UPDATE GCORDEN_TRABAJO_EXT SET DOC_ANTR = 'NR' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("La orden no se remisiono porque solo cuenta con servicios pero sera marcada como REMISIONADA, proceso terminado")
                    End If
                End If
            End Using
            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, CONVERTIR_TO_DECIMAL(Lt1.Text), "O", " Se remisiono la orden de trabajo pero no se genero la remision porque solo cuenta con servicios")
            Me.Close()
        Catch ex As Exception
            Bitacora("2535. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2535. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRemisionar_Click(sender As Object, e As EventArgs) Handles BarRemisionar.Click
        Dim Sigue As Boolean = False
        Dim z As Integer = 0

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Length > 0 Then
                    z = z + 1
                End If
            Next
            If z > 0 Then
                Sigue = True
            End If
        Catch ex As Exception
            Bitacora("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If z = 0 Then
            Try
                For k = 1 To FgS.Rows.Count - 1
                    If FgS(k, 6) > 1 Then
                        Sigue = True
                    End If
                Next
            Catch ex As Exception
                Bitacora("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        If Sigue Then
            GRABAR_VENTA(tCVE_ORD.Text)
        Else
            MARCAR_OT_COMO_REMISIONADA()
        End If

    End Sub
    Private Sub GRABAR_VENTA(fCVE_OT As String)

        If Not Valida_Conexion() Then
            MsgBox("Imposible conectarse a la base de datos")
            Return
        End If
        If Not Valida_Conexion_SAROCE() Then
            MsgBox("Imposible conectarse a la base de configuración")
            Return
        End If

        Dim ImporteConDes As Single, SUBTOTAL As Single

        Dim TIP_DOC As String, CVE_DOC As String, CVE_CLPV As String, STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim FECHA_DOC As String, FECHA_ENT As String, FECHA_VEN As String, CAN_TOT As Single, IMP_TOT1 As Single, IMP_TOT2 As Single, IMP_TOT3 As Single
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
        Dim CVE_CPTO As Integer, TIPO_DOC As String, FACTOR_CON As Single, SIGNO As Integer, COSTEADO As String
        Dim COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String, MOV_ENLAZADO As Integer, USO_CFDI As String
        Dim FOLIO_ASIGNADO As Boolean, SIGUE As Boolean, Existe As Boolean, cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Dim VentaGen As String, DESCOT As Single, CADENA_NUM_MOV As String, TIPO_SER As String = ""

        Dim cmdOT As New SqlCommand
        Dim drOT As SqlDataReader

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        VentaGen = ""
        Select Case TIPO_VENTA
            Case "P"
                VentaGen = " el Pedido"
                'If MsgBox("Realmente desea grabar el Pedido?", vbYesNo) = vbNo Then
                'Exit Sub
                'End If
            Case "C"
                VentaGen = "la Cotización"
                'If MsgBox("Realmente desea grabar la Cotización?", vbYesNo) = vbNo Then
                'Exit Sub
                'End If
            Case "R"
                VentaGen = "la Remisión"
                If MsgBox("Realmente desea grabar la Remisión?", vbYesNo) = vbNo Then
                    Exit Sub
                End If
        End Select
        CVE_DOC = ""
        CVE_PEDI = fCVE_OT

        UNI_MED = "" : TIPO_PROD = "P"
        MAN_IEPS = "" : APL_MAN_IMP = 0 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "" : MTO_PORC = 0 : MTO_CUOTA = 0

        CVE_VEND = "" : IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0 : CONDICION = "Contado"
        CVE_OBS = 0 : NUM_ALM = 1 : ACT_CXC = "S" : ACT_COI = "N" : ENLAZADO = "O" : TIP_DOC_E = "O" : NUM_MONED = 1 : TIPCAMB = 1 : NUM_PAGOS = 1
        RFC = "" : CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
        FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
        DAT_ENVIO = 0 : USO_CFDI = "" : COM_TOT_PORC = 0 : NUM_PAR = 1
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC_ANT = "" : DOC_ANT = ""
        METODODEPAGO = "" : STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N" : TIPO_DOC = TIPO_VENTA

        FECHA_DOC = ""

        Try
            PROCESAR_TABLA_OT()
            If Var23 = 0 Then
                MessageBox.Show("No se encontraron partidas a remisionar en la orden de tabajo")
                Return
            End If
        Catch ex As Exception
            Bitacora("1480. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1480. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TIPO_SER = ""
            If radPreventivo.Checked = True Then
                TIPO_SER = "PREVENTIVO"
            End If
            If radCorrectivo.Checked = True Then
                TIPO_SER = "CORRECTIVO"
            End If
            If radExtra.Checked = True Then
                TIPO_SER = "EXTRAORDINARIO"
            End If
            If radSinistro.Checked = True Then
                TIPO_SER = "SINIESTRO"
            End If
            If RadRescateCarr.Checked = True Then
                TIPO_SER = "RESCATE CARRETERO"
            End If
            If RadLLantas.Checked = True Then
                TIPO_SER = "LLANTAS"
            End If
        Catch ex As Exception
        End Try

        Try
            Dim dt As DateTime = Now
            FECHA_DOC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")
        Catch ex As Exception
            FECHA_DOC = Date.Now.Year & Format(Date.Now.Month, "00") & Format(Date.Now.Day, "00")
        End Try
        FECHA_ENT = FECHA_DOC
        FECHA_VEN = FECHA_DOC

        CVE_CLPV = tCVE_PROV.Text
        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT RFC FROM CLIE" & Empresa & " WHERE CLAVE  = '" & tCVE_PROV.Text & "'"
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
                    FOLIO_VENTA = FOLIO_VENTA + 1
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

                Existe = False
                Try
                    Try
                        SQL = "SELECT ISNULL(TIPO_ELE,'') AS TIPOELE, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, " &
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
                        MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        Me.Cursor = Cursors.Default
                        Return
                    End Try
                    If Existe Then
                        Try
                            Try
                                If TIPO_PROD <> "S" Then
                                    DESCOT = Val(tCVE_PROV.Tag)
                                    If DESCOT = 0 And Val(L3.Tag) > 0 Then
                                        PRECIO = PRECIO + Val(L3.Tag)
                                    Else
                                        If DESCOT = 0 Then
                                            DESCOT = 5
                                        End If
                                        PRECIO = PRECIO + (PRECIO * DESCOT / 100)
                                    End If
                                End If
                            Catch ex As Exception
                            End Try

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
                            SUBTOTAL = SUBTOTAL + (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT = DES_TOT + (CANT * PREC * DESC1 / 100)
                            DES_TOT = DES_TOT + (DES_TOT * Desc2 / 100)
                            cIeps = ImporteConDes * IMPU1 / 100
                            cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                            cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                            cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 = IMP_TOT1 + TOTIMP1
                            IMP_TOT2 = IMP_TOT2 + TOTIMP2
                            IMP_TOT3 = IMP_TOT3 + TOTIMP3
                            IMP_TOT4 = IMP_TOT4 + TOTIMP4
                            TOT_PARTIDA = CANT * PREC
                            CAN_TOT = CAN_TOT + TOT_PARTIDA

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
            BUSCA_UNIDAD_CLAVEMONTE(tCVE_UNI.Text)

            SQL = "UPDATE FACTR_CLIB" & Empresa & " SET CAMPLIB1 = '" & TIPO_SER & "', CAMPLIB4 = 'Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "' " &
                "WHERE CLAVE_DOC = '" & CVE_DOC & "' " &
                "IF @@ROWCOUNT = 0 " &
                "INSERT INTO FACTR_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB1, CAMPLIB4) VALUES('" & CVE_DOC & "','" & TIPO_SER & "','Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "')"
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

            If Not Valida_Conexion() Then
            End If

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
                            If TIPO_PROD <> "S" Then
                                DESCOT = Val(tCVE_PROV.Tag)
                                If DESCOT = 0 And Val(L3.Tag) > 0 Then
                                    PRECIO = PRECIO + Val(L3.Tag)
                                Else
                                    If DESCOT = 0 Then
                                        DESCOT = 5
                                    End If
                                    PRECIO = PRECIO + (PRECIO * DESCOT / 100)
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("1920. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1920. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            PRECIO = Math.Round(CDec(PRECIO), 6)
                            PREC = PRECIO

                            Desc2 = 0 : Desc3 = 0
                            SUBTOTAL = SUBTOTAL + (CANT * PREC)
                            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                            DES_TOT = DES_TOT + (CANT * PREC * DESC1 / 100)
                            DES_TOT = DES_TOT + (DES_TOT * Desc2 / 100)
                            cIeps = ImporteConDes * IMPU1 / 100
                            cImpu2 = (ImporteConDes + cIeps) * IMPU2 / 100
                            cImpu3 = (ImporteConDes + cIeps + cImpu2) * IMPU3 / 100
                            cImpu = (ImporteConDes + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            TOTIMP1 = cIeps
                            TOTIMP2 = cImpu2
                            TOTIMP3 = cImpu3
                            TOTIMP4 = cImpu

                            IMP_TOT1 = IMP_TOT1 + TOTIMP1
                            IMP_TOT2 = IMP_TOT2 + TOTIMP2
                            IMP_TOT3 = IMP_TOT3 + TOTIMP3
                            IMP_TOT4 = IMP_TOT4 + TOTIMP4
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
                    NUM_PAR = NUM_PAR + 1
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

        IMPRIMIR_VENTA(TIPO_VENTA, CVE_DOC)

        Try
            Fg(Fg.Row, 11) = CVE_DOC
        Catch ex As Exception
        End Try

        Me.Close()

    End Sub
    Sub IMPRIMIR_VENTA(fTIPO_DOC As String, fCVE_DOC As String)
        Dim Rreporte_MRT As String = ""
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
            If Fg.Row > 0 Then
                Select Case fTIPO_DOC
                    Case "R"
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
                    Case "V"
                        Select Case Empresa

                            Case "01"
                                Rreporte_MRT = "Nota de Venta Ticket.mrt"
                            Case "02"
                                Rreporte_MRT = "Nota de Venta Ticket02.mrt"
                            Case "03"
                                Rreporte_MRT = "Nota de Venta Ticket03.mrt"
                            Case "04"
                                Rreporte_MRT = "Nota de Venta Ticket04.mrt"
                            Case "05"
                                Rreporte_MRT = "Nota de Venta Ticket05.mrt"
                            Case "06"
                                Rreporte_MRT = "Nota de Venta Ticket06.mrt"
                        End Select
                        If Not File.Exists(Application.StartupPath & "\" & Rreporte_MRT) Then
                            MsgBox("No existe el reporte " & Application.StartupPath & "\" & Rreporte_MRT & ", verifique por favor")
                            Return
                        End If
                        StiReport1.Load(Application.StartupPath & "\" & Rreporte_MRT)
                    Case "P"
                        Select Case Empresa
                            Case "01"
                                Rreporte_MRT = "ReportPedido.mrt"
                            Case "02"
                                Rreporte_MRT = "ReportPedido02.mrt"
                            Case "03"
                                Rreporte_MRT = "ReportPedido03.mrt"
                            Case "04"
                                Rreporte_MRT = "ReportPedido04.mrt"
                            Case "05"
                                Rreporte_MRT = "ReportPedido05.mrt"
                            Case "06"
                                Rreporte_MRT = "ReportPedido06.mrt"
                        End Select
                        If Not File.Exists(Application.StartupPath & "\" & Rreporte_MRT) Then
                            MsgBox("No existe el reporte " & Application.StartupPath & "\" & Rreporte_MRT & ", verifique por favor")
                            Return
                        End If
                        StiReport1.Load(Application.StartupPath & "\" & Rreporte_MRT)
                    Case "C"
                        Select Case Empresa
                            Case "01"
                                Rreporte_MRT = "ReportCotizacion.mrt"
                            Case "02"
                                Rreporte_MRT = "ReportCotizacion02.mrt"
                            Case "03"
                                Rreporte_MRT = "ReportCotizacion03.mrt"
                            Case "04"
                                Rreporte_MRT = "ReportCotizacion04.mrt"
                            Case "05"
                                Rreporte_MRT = "ReportCotizacion05.mrt"
                            Case "06"
                                Rreporte_MRT = "ReportCotizacion06.mrt"
                            Case "07"
                                Rreporte_MRT = "ReportCotizacion07.mrt"
                            Case "08"
                                Rreporte_MRT = "ReportCotizacion08.mrt"
                            Case "09"
                                Rreporte_MRT = "ReportCotizacion09.mrt"
                            Case "10"
                                Rreporte_MRT = "ReportCotizacion10.mrt"
                            Case "11"
                                Rreporte_MRT = "ReportCotizacion11.mrt"
                            Case "12"
                                Rreporte_MRT = "ReportCotizacion12.mrt"
                        End Select
                        If Not File.Exists(Application.StartupPath & "\" & Rreporte_MRT) Then
                            MsgBox("No existe el reporte " & Application.StartupPath & "\" & Rreporte_MRT & ", verifique por favor")
                            Return
                        End If
                        StiReport1.Load(Application.StartupPath & "\" & Rreporte_MRT)
                End Select
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()

                StiReport1.Item("REFER") = fCVE_DOC
                StiReport1.Render()
                StiReport1.Show()
            Else
                MsgBox("Por favor seleccione el documento a imprimir")
            End If
        Catch ex As Exception
            Bitacora("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarFinOT_Click(sender As Object, e As EventArgs) Handles barFinOT.Click
        Dim Orden_Vacias As Integer = 0, Orden_proc As Integer = 0, Num_ord As Integer = 0, Num_Canc As Integer = 0
        Dim No_Proc As Integer = 0, CADENA As String = "", CANT1 As Decimal, CANT2 As Decimal, num_ot = 0
        Dim Orden_Vacias_ser As Integer = 0

        If MsgBox("Realmente desea finalizar la orden de trabajo?", vbYesNo) = vbNo Then
            Return
        End If

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            'FINALZIAR ODEN DE TRABAJO
            Try
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) > 0 Then
                        If Fg(k, 9) = "Cancelada" Then
                            Num_Canc = Num_Canc + 1
                        Else
                            If Fg(k, 9).ToString.Length = 0 And Fg(k, 1) <> "TOT" Then
                                Orden_Vacias = Orden_Vacias + 1
                            End If
                            If Fg(k, 9) = "Mov. realizado" Or Fg(k, 1) = "OT" Then
                                Orden_proc = Orden_proc + 1
                            End If
                            If Fg(k, 1) = "TOT" Then
                                num_ot = num_ot + 1
                            End If
                            Num_ord = Num_ord + 1

                            CANT1 = Math.Round(Fg(k, 5), 4)
                            CANT2 = Math.Round(Fg(k, 11), 4)
                            If CANT1 <> CANT2 Then
                                No_Proc = No_Proc + 1
                                CADENA = CADENA & Fg(k, 1) & " " & Fg(k, 3) & vbNewLine & " Cant. original " & CANT2 & vbNewLine & " Cant. procesadas " & Fg(k, 5) &
                                vbNewLine & " Pendien. X procesar " & Math.Round(Fg(k, 5) - Fg(k, 11), 4) & vbNewLine
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                Bitacora("2520. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                For k = 1 To FgS.Rows.Count - 1
                    If FgS(k, 1).ToString.Trim.Length > 0 And FgS(k, 5) > 0 Then
                        Orden_Vacias_ser = Orden_Vacias_ser + 1
                    End If
                Next
            Catch ex As Exception
                Bitacora("2520. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If Orden_Vacias > 0 Then
                'No tienen Mov. realizado
                MsgBox("Para poder finalizar la orden de trabaja es necesario procesar todas las partidas")
                Fg.Focus()
                Return
            End If
            If No_Proc > 0 Then
                MsgBox("Las siguientes partidas no han sido procesadas en su totalidad " & CADENA & vbNewLine &
                       "Si desea continuar debe cancelar las partida(s) no procesadas")
                Fg.Focus()
                Return
            End If
        Catch ex As Exception
            Bitacora("2520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try        'FINALZIAR ODEN DE TRABAJO
            Using cmd As SqlCommand = cnSAE.CreateCommand
                'SQL = "UPDATE GCORDEN_TRABAJO_EXT SET STATUS = 'C' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                If Orden_proc > 0 Or Orden_Vacias_ser > 0 Then
                    SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'FINALIZADO' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                Else
                    If Num_ord = Num_Canc And num_ot = 0 And Orden_Vacias_ser = 0 Then
                        SQL = "UPDATE GCORDEN_TRABAJO_EXT SET STATUS = 'C', ESTATUS = 'FINALIZADO' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                    Else
                        SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'FINALIZADO' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                    End If

                End If

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Finalizacion orden de trabajo ")
                    End If
                End If
            End Using
            Try
                If tCVE_PROG.Text.Trim.Length > 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCPROGAMACION_SERVICIOS SET CVE_ORD = '" & tCVE_ORD.Text & "', FECHA_INI_SER = GETDATE() " &
                              "WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue = "1" Then
                        End If
                    End Using
                End If
            Catch ex As Exception
                MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            tEstatus.Text = "FINALIZADO"

            MsgBox("La Orden de Trabajo se finalizo satisfactoriamente")

            Me.Close()
            'FINALZIAR ODEN DE TRABAJO
        Catch ex As Exception
            Bitacora("2540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEnlazarDoc_Click(sender As Object, e As EventArgs) Handles BarEnlazarDoc.Click
        Try
            Var15 = "C"
            frmEnlaceVentas.ShowDialog()
            If aDOCS.Length > 0 Then
                Dim CVE_DOC As String
                ENTRA = False
                LIMPIAR()
                Fg.Rows.Count = 1
                FgS.Rows.Count = 1
                For k = 0 To aDOCS.Length - 1
                    CVE_DOC = aDOCS(k)
                    If CVE_DOC.Trim.Length > 0 Then
                        BUSCAR_VENTA("C", CVE_DOC)
                    End If
                Next
                Try
                    LtDocAnt.Text = aDOCS(0)
                Catch ex As Exception
                End Try

                ENTRA = False
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1

                For k = 1 To FgS.Rows.Count - 1
                    Try
                        FgS(k, 1) = FgS(k, 14)
                    Catch ex As Exception

                    End Try
                Next
                FgS.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0")
                FgS.Row = FgS.Rows.Count - 1
                FgS.Col = 1


                ENTRA = True
                DOC_ENLAZADO = "S"
            End If

        Catch ex As Exception
            Bitacora("2560. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2560. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_VENTA(fTIPOC As String, fCVE_DOC As String)
        Dim PREC As Single, NUM_ALM As Integer, IEPS As Single, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single, Sigue As Boolean, s As String, j As Integer

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            With Fg
                Dim NewStyle1 As CellStyle
                NewStyle1 = .Styles.Add("NewStyle1")
                NewStyle1.BackColor = System.Drawing.Color.Blue
                .SetCellStyle(0, 0, NewStyle1)

            End With

            Dim CustomStyle As CellStyle = Fg.Styles.Add("CustomStyle")
            CustomStyle.BackColor = Color.Orange

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180
        Catch ex As Exception

        End Try

        Try
            SQL = "SELECT P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA, EXIST, P.CVE_OBS, " &
                "ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, NUM_PAR, ISNULL(PXS,0) AS P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM,1) AS NUMALM, " &
                "ISNULL(P.DESC1,0) AS D1, ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, " &
                "F.CVE_CLPV, C.NOMBRE, C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,  " &
                "ISNULL(CAMPLIB1, '') AS LIB1, ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, F.IMPORTE " &
                "FROM PAR_FACT" & fTIPOC.ToUpper & Empresa & " P " &
                "LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC " &
                "LEFT JOIN FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = P.CVE_DOC " &
                "LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR " &
                "LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV " &
                "LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Sigue = True : ENTRA = False : j = 0
            Do While dr.Read
                If Sigue Then
                    tCVE_PROV.Text = dr("CVE_CLPV")
                    'tCVE_PEDI.Text = dr("PEDI")
                    L3.Text = dr("NOMBRE").ToString
                    LtDocAnt.Tag = dr("IMPORTE")

                    tCVE_UNI.Text = dr("PEDI")
                    L2.Text = BUSCA_CAT("Unidad", tCVE_UNI.Text)

                    tCVE_TIPO.Text = dr("CONDI")
                    L4.Text = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)

                    'LtCalle.Text = dr("CALLE").ToString
                    'LtColonia.Text = dr("COLONIA").ToString
                    'LtNumInt.Text = dr("NUMINT").ToString
                    'LtNumExt.Text = dr("NUMEXT").ToString
                    'LtCP.Text = dr("CODIGO").ToString
                    'LtRFC.Text = dr("RFC").ToString
                    'LtPoblacion.Text = dr("MUNICIPIO").ToString
                    'LtEstado.Text = dr("ESTADO").ToString
                    NUM_ALM = dr("NUMALM")
                    Try
                        If MULTIALMACEN = 1 Then
                            'cboAlmacen.SelectedIndex = 0
                            'For k = 0 To cboAlmacen.Items.Count - 1
                            ' If Val(cboAlmacen.Items(k).ToString.Substring(0, 2)) = NUM_ALM Then
                            'cboAlmacen.SelectedIndex = k
                            'Exit For
                            'End If
                            '   Next
                        Else
                            'cboAlmacen.SelectedIndex = 0
                        End If
                    Catch ex As Exception
                        Bitacora("2580. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    'tEntregarEn.Text = dr("INF_NOMBRE")
                    'tCONDICION.Text = dr("CONDI")
                    'tDesc.Text = dr("D1")
                    'tCVE_VEND.Text = dr("VEND")
                    Sigue = False
                End If

                If dr("P_X_S") > 0 Then
                    PREC = dr("PREC")
                    PREC = Math.Round(PREC, 4)
                    DESCP = PREC * dr("DESC1") / 100
                    IEPS = dr("IMPU1")
                    cIEPS = (PREC - DESCP - DESCP2) * IEPS / 100
                    IMPU = dr("IMPU4")
                    cIMPU = (PREC - DESCP - DESCP2 + cIEPS) * IMPU / 100
                    PrecioVenta = PREC - DESCP - DESCP2
                    '18 NUM_PAR
                    '19 CVE_DOC_ENLAZADO
                    '20 ENLACE_TIP_DOC
                    s = dr("CVE_ART") & vbTab '1
                    s = s & "" & vbTab '2
                    s = s & dr("DESCR") & " (" & dr("TIPOELE") & ")" & vbTab '3
                    s = s & "" & vbTab '4
                    s = s & dr("P_X_S") & vbTab '5
                    s = s & PREC & vbTab '6
                    s = s & dr("P_X_S") * PREC & vbTab '7
                    s = s & fCVE_DOC & vbTab '8
                    s = s & "" & vbTab '9
                    s = s & dr("P_X_S") & vbTab '10
                    s = s & "0" & vbTab '11
                    s = s & dr("P_X_S") * PREC & vbTab '12
                    s = s & "" & vbTab '13
                    s = s & dr("CVE_ART") & vbTab '14
                    s = s & "" & vbTab '15
                    s = s & "" & vbTab '16
                    s = s & 0 & vbTab '17
                    s = s & ""  '18
                    If dr("TIPOELE") = "P" Then
                        Fg.AddItem("" & vbTab & s)
                    Else
                        FgS.AddItem("" & vbTab & s)
                    End If
                    j = j + 1
                End If
            Loop
            Try
                SUM_IMPORTES("P")
                SUM_IMPORTES("S")
            Catch ex As Exception
            End Try
        Catch ex As Exception
            Bitacora("2600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub BarKardex_Click(sender As Object, e As EventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 1) 'CVE_ART
                Var5 = "" 'DESCRIPCION
                Try
                    Var5 = Fg(Fg.Row, 4) 'DESCRIPCION
                Catch ex As Exception
                End Try
                If Var4.Trim.Length > 0 Then
                    frmKardex.ShowDialog()
                Else
                    MessageBox.Show("Por favor seleccione un artículo")
                End If
            End If
        Catch ex As Exception
            Bitacora("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNOTA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tNOTA.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                _myEditor.StartEditing(Fg.Row, 1)

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        Try
            If tEstatus.Text = "Cancelada" Then
                Return
            End If
            Select Case Tab1.SelectedIndex
                Case 0
                    BarKardex.Visible = True
                    btnAltaProducto.Visible = True
                    btnEliProd.Visible = True
                Case Else
                    btnAltaProducto.Visible = False
                    btnEliProd.Visible = False
                    BarKardex.Visible = False
            End Select
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarCancelarOT_Click(sender As Object, e As EventArgs) Handles barCancelarOT.Click
        Try
            Dim z As Integer = 0
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) > 0 Then
                        If Fg(k, 9) = "Mov. realizado" Then
                            z = z + 1
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("2640. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            If z > 0 Then
                MsgBox("La orden de trabajo no puede ser cancelada porque tiene partida(s) con movimiento(s) procesados")
                Return
            End If
        Catch ex As Exception
            Bitacora("2660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If MsgBox("Realmente desea cancelar la orden de trabajo " & tCVE_ORD.Text & "?", vbYesNo) = vbYes Then
                'Dim CVE_DOC As String = ""
                'CVE_DOC = ORDEN_DE_TRABAJO_COMPRA_GENERADA(Fg(Fg.Row, 15))
                'If CVE_DOC <> "" Then
                'MsgBox("A la orden de trabajo " & Fg(Fg.Row, 1) & " se le generó la compra " & CVE_DOC & ", no es posible cancelar, verifique por favor")
                'Return
                'End If

                If Not Valida_Conexion() Then
                    Return
                End If

                SQL = "UPDATE GCORDEN_TRABAJO_EXT SET STATUS = 'C', GUID = '" & USER_GRUPOCE & "' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                Dim cmd As New SqlCommand With {
                    .Connection = cnSAE,
                    .CommandTimeout = 180,
                    .CommandText = SQL
                }
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Se cancelo Orden de trabajo ")
                        MsgBox("El registro se cancelo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("NO se logro cancelo el registro")
                    End If
                Else
                    MsgBox("!!NO se logro cancelo el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("2680. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCancPartNoEntr_Click(sender As Object, e As EventArgs) Handles BarCancPartNoEntr.Click
        Try
            Dim z As Integer = 0, IMPORTE As Decimal = 0, CANT As Decimal, CANT_ENT As Decimal, CANT_ENTR As Decimal

            If MsgBox("Realmente desea cancelar las cantida(des) de partida(s) no procesadas?", vbYesNo) = vbYes Then
                For k = 1 To Fg.Rows.Count - 1
                    CANT = Fg(k, 5)
                    CANT_ENT = Fg(k, 11)
                    CANT_ENTR = Fg(k, 17)
                    If Fg(k, 1) = "0109001052" Then
                    End If

                    '   CVE_ART                              CANTIDAD  
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) <> 0 And Fg(k, 9) <> "Cancelada" Then
                        '    CANT     CANC. PARCIAL
                        '     216    +     0            126

                        '   CANT    CANT_ENT (MINVE)
                        If Fg(k, 5) <> Fg(k, 11) And Fg(k, 11) > 0 Then

                            If Not Valida_Conexion() Then
                                Return
                            End If

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET CANT = " & Fg(k, 11) & ", CANT_ORIGINAL = " & CANT & " WHERE UUID = '" & Fg(k, 14) & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            z = z + 1
                                            Fg(k, 5) = Fg(k, 11)
                                            Try
                                                IMPORTE = Lt1.Text.Remove(",", "")
                                            Catch ex As Exception
                                            End Try
                                            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, IMPORTE, "T", "Cancelacion partida parcial articulo:" &
                                                       Fg(k, 1) & " Cantidad:" & (Fg(k, 10) - Fg(k, 5)))
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("2700. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("2700. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                Next
                If z = 0 Then
                    MsgBox("No se encontraron partidas parciales a cancelar")
                Else
                    MsgBox("Las partidas parciales se cancelaron satisfactoriamente")
                End If
            End If
        Catch ex As Exception
            MsgBox("2750. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLUGAR_REP_KeyDown(sender As Object, e As KeyEventArgs) Handles tLUGAR_REP.KeyDown
        Try
            If e.KeyCode = 13 Then
                tNOTA.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "ORDEN DE TRABAJO" & tCVE_ORD.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnMagix_Click(sender As Object, e As EventArgs) Handles BtnMagix.Click
        Dim Exist As Boolean = False, z As Integer = 0, x As Integer = 0, piezas As Single = 0

        Try
            SQL = "DELETE FROM GCORDEN_TRA_SER_EXT WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("OK " & returnValue)
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("2740. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2740. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT REFER, M.CVE_ART, CANT AS CANTI, SIGNO, COSTO, PRECIO, DESCR, CVE_FOLIO FROM MINVE" & Empresa & " M " &
                    "INNER JOIN INVE" & Empresa & " I ON I.CVE_ART = M.CVE_ART " &
                    "WHERE REFER LIKE 'OT" & tCVE_ORD.Text & "%' OR REFER LIKE 'CCOT" & tCVE_ORD.Text & "%' ORDER BY NUM_MOV"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("SIGNO") = -1 Then
                            Fg.AddItem(x & vbTab & dr("CVE_ART") & vbTab & "" & vbTab & dr("DESCR") & vbTab & "" & vbTab & dr("CANTI") & vbTab & dr("COSTO") & vbTab &
                                Math.Abs(dr("CANTI") * dr("COSTO")) & vbTab & "" & vbTab & "Mov. realizado" & vbTab & dr("CANTI") & vbTab & "0" & vbTab &
                                "0" & vbTab & "Mov. realizado" & vbTab & "" & vbTab & dr("CVE_FOLIO") & vbTab & "MINVE" & vbTab & "0" & vbTab & "")
                        Else
                            For k = 1 To Fg.Rows.Count - 1
                                If Fg(k, 1) = dr("CVE_ART") Then
                                    If Fg(k, 5) = dr("CANTI") And Fg(k, 9) <> "Cancelada" Then
                                        Fg(k, 9) = "Cancelada"
                                        Fg(k, 13) = "Cancelada"
                                        Exit For
                                    Else
                                        If Fg(k, 5) - dr("CANTI") >= 0 And Fg(k, 9) <> "Cancelada" Then
                                            Fg(k, 5) = Fg(k, 5) - dr("CANTI")
                                            Exit For
                                        End If
                                    End If
                                End If
                            Next
                        End If

                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("2750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            For k = Fg.Rows.Count - 1 To 1 Step -1
                If Fg(k, 5) = 0 Then
                    Fg.RemoveItem(k)
                Else
                    Fg(k, 5) = Math.Abs(Fg(k, 5))
                    Fg(k, 10) = Math.Abs(Fg(k, 10))
                End If
            Next
            Try
                For k = 1 To Fg.Rows.Count - 1
                    Fg(k, 0) = k
                    piezas = piezas + Fg(k, 5)
                Next
                LtPiezas.Text = piezas
                LtPar.Text = Fg.Rows.Count - 1
            Catch ex As Exception
            End Try

            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)

        Catch ex As Exception
            Bitacora("2760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnDesCancel_Click(sender As Object, e As EventArgs) Handles BtnDesCancel.Click
        Try
            Dim r_ As Row

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    If Fg(r_.Index, 9) = "Cancelada" Then
                        Try
                            SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = '' WHERE UUID = '" & Fg(r_.Index, 14) & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Fg(r_.Index, 9) = ""
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("2760. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2760. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
            MsgBox("OK")

            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)
        Catch ex As Exception
            Bitacora("2770. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2770. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSetMovRealizado_Click(sender As Object, e As EventArgs) Handles BtnSetMovRealizado.Click
        Try
            Dim r_ As Row

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    Try
                        SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE' WHERE UUID = '" & Fg(r_.Index, 14) & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Fg(r_.Index, 9) = "Mov. realizado"
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("2760. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2760. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            MsgBox("OK")

            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)
        Catch ex As Exception
            Bitacora("2770. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2770. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_PROG_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROG.KeyDown

    End Sub
    Sub ImprimirOrden(fTIPO_DOC As String, fCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            Select Case Empresa
                Case "01"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "02"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra02.mrt"
                    If Not File.Exists(ARCHIVO_MRT) Then
                        MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "03"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra03.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra03.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "04"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra04.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra04.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "05"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra05.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra05.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "06"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra06.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra06.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "07"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra07.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra07.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "08"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra08.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra08.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "09"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra09.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportCompra09.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "10"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra10.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra10.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "11"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra11.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra11.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
            End Select

            BACKUPTXT("RUTA FORMATOS", ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("REFER") = fCVE_DOC
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class


'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorOTEXT
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyAlmacen As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        _owner.Cols(6).EditMask = "999,999,999.99"
        _owner.Cols(7).EditMask = "999,999,999.99"
    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim Sigue As Boolean

        If frmOrdenDeTrabajoExtAE.tCVE_UNI.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture la unidad")
            Return
        End If
        If frmOrdenDeTrabajoExtAE.tCVE_PROV.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture el cliente")
            Return
        End If
        If frmOrdenDeTrabajoExtAE.tCVE_TIPO.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture el tipo de unidad")
            Return
        End If
        'save coordinates of cell being edited        'guardar las coordenadas de la celda que se está editando
        If col = 1 And keyRec = 9 Then
            MyBase.Visible = True
            _owner.Select()
            _owner.StartEditing()
            Return
        End If
        If col = 1 And keyRec = 999 Then
            _owner.Col = 1
            MyBase.Visible = True
            _owner.Select(_row, 1)
            _owner.StartEditing()
            SendKeys.Send("{TAB}")
            Return
        End If
        Sigue = True

        If Sigue And (col = 1 Or col = 5) Then
            If col = 99 Then
                _owner.Col = 1
                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If

            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)
            rc.Width = rc.Width - 1
            rc.Height = rc.Height - 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control
            If col = 131 Then
                'PRECIO
            End If
            MyBase.Text = ""
            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf Not _owner(row, col) Is Nothing Then
                MyBase.Text = _owner(row, col).ToString()
            End If
            MyBase.Select(Text.Length, 0)
            'make editor visible
            MyBase.Visible = True
            'and get the focus
            '_owner.Select(_row, 2)
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength

            If col = 1 And keyRec = 99 Then
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("4000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 1 Or col = 5 Then
            MyBase.Visible = True
        End If
    End Sub
    'guardar clave que inició el modo de edición
    Public Sub SetPendingKey(ByVal chr As Char)
        _pendingKey = chr
    End Sub

    'move editor after the grid has scrolled
    'mover editor después de que la cuadrícula se haya desplazado
    Public Sub UpdatePosition()
        'get cell rect now
        'obtener celular ahora
        Dim rcCell As Rectangle = _owner.GetCellRect(_row, _col, False)

        'intersect with scrollable part of the grid
        'intersectarse con parte desplazable de la cuadrícula
        Dim rcScroll As Rectangle = _owner.ClientRectangle
        rcScroll.X = _owner.Cols(_owner.Cols.Fixed).Left
        rcScroll.Y = _owner.Rows(_owner.Rows.Fixed).Top
        rcScroll.Width = rcScroll.Width - rcScroll.X
        rcScroll.Height = rcScroll.Height - rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width = rcCell.Width - 1
        If (rcCell.Height > 0) Then rcCell.Height = rcCell.Height - 1
        MyBase.Bounds = rcCell
    End Sub
    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        If _col = 99 Then
            _owner.Col = 1
            frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            'aqui esta el error
            If _col = 1 Then
                If IsNothing(_owner(_row, 1)) Then
                    MyBase.Visible = True
                    _owner.Select()
                    _owner.Select(_row, 1)
                    _owner.StartEditing()
                    Return
                End If
                If _owner(_row, _col) = "" Then
                    MyBase.Visible = True
                    Return
                End If
            End If
            If _col = 5 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 6)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try

                                        Dim DESC1 As Single = 0, PRECIO As Single = 0
                                        Try
                                            DESC1 = Val(frmOrdenDeTrabajoExtAE.tCVE_PROV.Tag)
                                            PRECIO = Val(_owner(_row, 6))
                                            'PRECIO = PRECIO + (PRECIO * DESC1 / 100)
                                        Catch ex As Exception
                                        End Try

                                        Dim C1 As Decimal
                                        C1 = MyBase.Text * PRECIO
                                        _owner(_row, 7) = C1
                                    Catch ex As Exception
                                        _owner(_row, 7) = MyBase.Text * _owner(_row, 6)
                                    End Try
                                    _owner.FinishEditing()
                                    CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4050. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 99 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 9)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = _owner(_row, 10) * MyBase.Text
                                        _owner(_row, 11) = C1

                                    Catch ex As Exception
                                        _owner(_row, 11) = _owner(_row, 10) * MyBase.Text
                                    End Try
                                    CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'procesamiento base
            MyBase.OnLeave(e)

            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
            End If

            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("4150. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    'manejaremos la tecla de tabulación nosotros mismos
    Protected Overrides Function IsInputkey(ByVal keydata As Keys) As Boolean
        If keydata = Keys.Tab Or keydata = Keys.Enter Then
            Return True
        End If
        Return MyBase.IsInputKey(keydata)
    End Function

    'algunas teclas finalizan la edición
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        If _col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                _cancel = True
                _owner.Select()
                e.Handled = True
            Case Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Left, Keys.Right
                _owner.Select()
                e.Handled = True
                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 1 Then
                    Try                    'ARTICULOS
                        Var2 = "InveP" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem2.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) 'CLAVE
                            'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                            'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                            'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                            'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                            _owner(_row, 1) = Var4
                            _owner(_row, 3) = Var5
                            _owner(_row, 4) = Var6

                            Dim DESC1 As Single = 0, PRECIO As Single = 0
                            Try
                                DESC1 = Val(frmOrdenDeTrabajoExtAE.tCVE_PROV.Tag)
                                If DESC1 = 0 Then
                                    PRECIO = Val(Var9) / 0.95
                                Else
                                    PRECIO = Val(Var9) + (Val(Var9) * DESC1 / 100)
                                End If
                                PRECIO = Math.Round(PRECIO, 4)
                            Catch ex As Exception
                            End Try
                            Try
                                Dim C1 As Decimal

                                _owner(_row, 6) = PRECIO

                                C1 = _owner(_row, 5) * PRECIO
                                _owner(_row, 7) = C1
                            Catch ex As Exception
                            End Try
                            frmOrdenDeTrabajoAE.CALCULAR_IMPORTES()

                            _owner.Col = 5
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 5 Then
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
            Return
        End If

        If col = 22 Or col = 24 Or col = 25 Or col = 213 Then
            If Not IsNothing(_owner(_row, _col)) Then
                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                    _owner.Row = _row
                    _owner.Col = col
                    _owner.Row = _row
                    Return
                End If
            Else
                _owner.Select()
                '_owner.Row = _row
                '_owner.Col = col
                '_owner.Select(_row, _col)
                Return
            End If
        End If
        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    If IsNothing(_owner(_row, 3)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 3).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If IsNothing(_owner(_row, 3)) Then
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row = row - 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                If _owner.Rows.Count - 1 = row Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                            Else
                                '                              1                2             3                    4                       5 
                                'Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & dr("CANTI") & vbTab &
                                '    6                 7                     8                    9                   10
                                'SUBTOTAL & vbTab & SUBTOTAL & vbTab & dr("REFER") & vbTab & dr("ST") & vbTab & dr("CANTI") & vbTab &
                                '        11                    12                                 13                                      14
                                'dr("CANT_ENT") & vbTab & dr("IMPORT") & vbTab & IIf(dr("ST") = "M", "Mov. realizado", " ") & vbTab & dr("UID"))
                                If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                                   "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                                   "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                Else
                                    frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                    _owner.Select(row, 1)
                                End If
                            End If
                        Case 3
                            frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                        Case 9
                            frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                    End Select
                    Return
                Else
                    row = row + 1
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner.Rows.Count - 1 <> 1 Then
                                        _owner.RemoveItem(_owner.Row)
                                        row = _owner.Rows.Count - 1
                                    End If
                                    Return
                                Else
                                    If _owner(_row, 3).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            Else
                                If IsNothing(_owner(_row, 3)) Then
                                    If _owner(_row, 1).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            End If
                            If row = 1 Then
                                row = _owner.Rows.Count - 1
                            Else
                                row = row - 1
                            End If
                            col = 1
                        Case 5
                            col = 1
                    End Select
                    'col = col - 1
                    'If col = 2 Or col = 4 Then
                    'col = col - 1
                    'End If
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 9 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                '_owner.Select()
                                '_owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                Return
                            End If
                            col = 5
                        Case 5 'PROVEEDOR
                            col = 1
                    End Select
                Else
                    col = 1
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
        End Select

        'validar nueva selección
        If (row < _owner.Rows.Fixed) Then row = _owner.Rows.Fixed
        If (col < _owner.Cols.Fixed) Then col = _owner.Cols.Fixed
        If (row > _owner.Rows.Count - 1) Then row = _owner.Rows.Count - 1
        If (col > _owner.Cols.Count - 1) Then col = _owner.Cols.Count - 1

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 1 'CVE_ART
                            If MyBase.Text = "TOT" Then
                                Dim DESC1 As Decimal = 0
                                TIPO_COMPRA = "o"
                                Var17 = "N"
                                Var21 = 0
                                Try
                                    Var21 = Val(frmOrdenDeTrabajoExtAE.tCVE_PROV.Tag)
                                Catch ex As Exception
                                    Var21 = 0
                                End Try
                                Var22 = 0

                                If Not IsNothing(_owner(_row, 7)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, 7)) Then
                                        If _owner(_row, 7).ToString.Trim.Length > 1 Then
                                            Var11 = "edit"
                                            Var12 = _owner(_row, 8)
                                        Else
                                            Var11 = ""
                                            Var12 = ""
                                        End If
                                    Else
                                        Var11 = ""
                                        Var12 = ""
                                    End If
                                Else
                                    Var11 = ""
                                    Var12 = ""
                                End If
                                Cp1 = frmOrdenDeTrabajoExtAE.tCVE_UNI.Text
                                Cp2 = frmOrdenDeTrabajoExtAE.tCVE_TIPO.Text

                                frmComprasTrans.ShowDialog(MainRibbonForm)

                                If Var17.Trim.Length > 0 And Var17.Trim <> "N" And Var11 <> "edit" Then
                                    DESC1 = 0
                                    Try
                                        DESC1 = Val(frmOrdenDeTrabajoExtAE.tCVE_PROV.Tag)
                                    Catch ex As Exception
                                    End Try

                                    _owner(_row, 1) = MyBase.Text
                                    _owner(_row, 3) = Var12 'NOMBRE CLIENTE
                                    _owner(_row, 4) = Var11 'CLAVE CLIENTE
                                    _owner(_row, 5) = "1"
                                    _owner(_row, 6) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                    _owner(_row, 7) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                    _owner(_row, 8) = Var17 'REFER
                                    _owner(_row, 9) = ""
                                    _owner(_row, 12) = Var22
                                    _owner.Col = 5

                                    frmOrdenDeTrabajoExtAE.ImprimirOdenDeCompra(Var17)

                                Else
                                    frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                    _owner.Select(_row, 1)
                                End If
                                Return
                            Else

                                Dim Descr As String

                                If MyBase.Text.Trim.Length = 0 Then
                                    frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                End If
                                Var9 = "" : Var22 = 0 : Var4 = ""
                                Descr = BUSCA_CAT("InveP", MyBase.Text)
                                If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                    If PASS_GRUPOCE.ToUpper = "BUS" Then
                                        MsgBox("Articulo inexistente " & SQL)
                                    Else
                                        MsgBox("Articulo inexistente")
                                    End If
                                    frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                Else
                                    Dim PRECIO As Single, DESC1 As Single
                                    _owner(_row, 1) = MyBase.Text
                                    _owner(_row, 3) = Descr
                                    _owner(_row, 4) = Var6
                                    _owner(_row, 6) = Var7
                                    Try
                                        DESC1 = Val(frmOrdenDeTrabajoExtAE.tCVE_PROV.Tag)
                                        If DESC1 = 0 Then
                                            PRECIO = Val(Var9) / 0.95
                                        Else
                                            PRECIO = Val(Var9) + (Val(Var9) * DESC1 / 100)
                                        End If
                                        PRECIO = Math.Round(PRECIO, 4)
                                        _owner(_row, 6) = PRECIO
                                        Dim C1 As Decimal
                                        If _owner(_row, 5) = 0 Then
                                            _owner(_row, 5) = 1
                                        End If
                                        C1 = _owner(_row, 5) * PRECIO
                                        _owner(_row, 7) = C1
                                    Catch ex As Exception
                                        _owner(_row, 7) = PRECIO
                                    End Try
                                    _owner.Col = 5
                                    Return
                                End If
                            End If
                        Case 5 'cantidad
                            If MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0" Then
                                MsgBox("Cantidad incorrecta")
                                MyBase.Visible = True
                                frmOrdenDeTrabajoExtAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = "1"
                                _owner.StartEditing()
                                Return
                            End If
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 1)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = _owner(_row, 6) * MyBase.Text
                                                    _owner(_row, 7) = C1
                                                Catch ex As Exception
                                                    _owner(_row, 7) = _owner(_row, 6) * MyBase.Text
                                                End Try
                                                frmOrdenDeTrabajoAE.CALCULAR_IMPORTES()
                                            End If
                                        End If
                                    End If
                                End If
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try
                                If HayErr Then
                                    'If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                                   "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                                   "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                    'End If
                                Else
                                    'If _owner(row, 1) > 0 And _owner(row, 3).ToString.Trim.Length > 0 Then
                                    'End If
                                End If
                                _owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 111
                            _owner.Select(row, col + 4)
                        Case 55
                            _owner.Select(row, col + 4)
                        Case 10
                    End Select

                    _owner.StartEditing()
                    'Return

                Case Else
                    If _col = 5 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 1 Then
                        e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("4300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT TOP 1 PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                _owner(_row, 1) = dr("CVE_ART")
                _owner(_row, 3) = dr("DESCR")
                Try
                    Dim C1 As Decimal
                    C1 = _owner(_row, 5) * _owner(_row, 6)
                    _owner(_row, 7) = C1
                Catch ex As Exception
                    _owner(_row, 7) = _owner(_row, 5) * _owner(_row, 6)
                End Try
                'frmTPV.CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("4350. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4350. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_IMPORTES()
        Try
            Dim SUMA As Decimal = 0
            _owner.FinishEditing()

            For k = 1 To _owner.Rows.Count - 1
                If _owner(k, 1).ToString.Trim.Length > 0 And _owner(k, 1).ToString.Trim = "TOT" And _owner(k, 9).ToString.Trim = "Cancelada" Then
                    SUMA = SUMA + _owner(k, 7)
                End If
            Next
            frmOrdenDeTrabajoAE.LtTotal.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class

