Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.ComponentModel
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class FrmOTIAE
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
    Private PAR_FALLA_UUID As String = ""
    Private CONTROL_DOC As String = ""
    Private NProc As Integer = 0
    Private U_ALMACEN As Boolean
    Private U_MANTE As Boolean
    Private DIAS_ANTICIPACION As Integer = 3
    Private LINEA_FILTRO_SERVICIO As String

    Private C93015 As Boolean, C93030 As Boolean, C93060 As Boolean, C93090 As Boolean, C93120 As Boolean, C93150 As Boolean
    Private C93180 As Boolean, C93220 As Boolean, C93250 As Boolean, C93280 As Boolean, C93310 As Boolean, C93340 As Boolean, C93370 As Boolean
    Private _myEditor As MyEditorOTI
    Private Sub FrmOTIAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim Efecto As Boolean
        Dim CVE_ALM As String = ""

        Try
            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
        Catch ex As Exception
        End Try
        Try
            CARGA_PARAM_INVENT()
            DOC_ENLAZADO = "N"
            ENTRA_KEY = True
            REMOVE_ROW = 0
            ENTRA_BTN = True
            LIMPIAR()
            tCVE_PROV.Tag = "0" : L3.Tag = "0"
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

            Tab1.Height = Me.Height - Panel1.Height - C1ToolBar1.Height - 25

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 80
            Fg.Height = Tab1.Height - 100

            FgS.Width = Screen.PrimaryScreen.Bounds.Width - 80
            FgS.Height = Tab1.Height - btnAltaServicio.Height - 100

            FgD.Width = Screen.PrimaryScreen.Bounds.Width - 80
            FgD.Height = Tab1.Height - LtFotoDoc.Top - LtFotoDoc.Height - 100

            FgD.Cols(3).Width = FgD.Width - FgD.Cols(1).Width - FgD.Cols(2).Width - FgD.Cols(0).Width - 50


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

            Fg.Cols(2).Width = 20 'CELLBUTTOM CLICK
            Fg.Cols(10).Width = 90 'STATUS 
            Fg.Cols(13).Width = 0 'TIPO_ELE
            Fg.Cols(14).Width = 0 'movs inve
            Fg.Cols(15).Width = 0 'UUID
            Fg.Cols(16).Width = 0 'CVE_PROV
            Fg.Cols(17).Width = 0 'HORA2

            Fg.Cols(18).Width = 0 'CANCELACION PARCIAL
            Fg.Cols(19).Width = 0 'PROV

            If MULTIALMACEN = 0 Then
                Fg.Cols(4).Visible = False
            End If

            Fg.Rows(0).Height = 40
            FgS.Cols(2).Width = 20
            FgS.Rows(0).Height = 40

            Me.WindowState = FormWindowState.Maximized
            'Me.KeyPreview = True

            If OT_EXT = "M" Then
                TabProductos.Visible = False
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
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        'ALMACEN                     ALMACEN                     ALMACEN                     ALMACEN
        If MULTIALMACEN = 1 Then
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim CDE As String = ""

                cmd.Connection = cnSAE
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE CVE_ALM <> 1 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    Do While dr.Read
                        cboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                        CDE = CDE & Format(dr("CVE_ALM"), "00") & " " & dr("DESCR") & "|"
                    Loop
                    cboAlmacen.SelectedIndex = 0
                Else
                    cboAlmacen.Items.Add("01 Almacen 1")
                End If
                dr.Close()
                PassData3 = CDE
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            cboAlmacen.Visible = False
            LtAlm.Visible = False
        End If

        Try 'MECANICOS      MECANICOS      MECANICOS      MECANICOS      MECANICOS      MECANICOS      
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim CDE As String = ""

            cmd.Connection = cnSAE
            SQL = "SELECT CVE_MEC, DESCR FROM GCMECANICOS WHERE STATUS = 'A' ORDER BY CVE_MEC"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read
                    CDE = CDE & dr("CVE_MEC").ToString.PadLeft(3) & " " & dr("DESCR") & "|"
                Loop
            End If
            dr.Close()
            PassData4 = CDE
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Fg.Cols(11).Visible = True
            Fg.Cols(12).Visible = True
            Fg.Cols(13).Visible = True
            Fg.Cols(14).Visible = True
            Fg.Cols(15).Visible = True
            Fg.Cols(16).Visible = True
            Fg.Cols(17).Visible = True

            Fg.Cols(12).Width = 100
            Fg.Cols(13).Width = 100
            Fg.Cols(14).Width = 100
            Fg.Cols(15).Width = 100
            Fg.Cols(16).Width = 100
            Fg.Cols(17).Width = 100
            Fg.Cols(18).Width = 100

            FgS.Cols(12).Visible = True
            FgS.Cols(13).Visible = True
            FgS.Cols(14).Visible = True
        Else
            Fg.Cols(12).Visible = False
            Fg.Cols(13).Visible = False
            Fg.Cols(14).Visible = False
            Fg.Cols(15).Visible = False
            'Fg.Cols(16).Visible = False
            'Fg.Cols(17).Visible = False

            FgS.Cols(12).Visible = False
            FgS.Cols(13).Visible = False
            FgS.Cols(14).Visible = False
        End If
        Try
            SQL = "SELECT ISNULL(PERMITIR_UNIDAD,0) AS P_UNIDAD, ISNULL(PORC_ORDEN_TRA_EXT,0) AS POR_ORD_TRA_EXT, DIAS_ANTICIPACION " &
                "FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PERMITIR_UNIDAD = dr("P_UNIDAD")
                        PORC_ORDEN_TRA_EXT = dr("POR_ORD_TRA_EXT")
                        DIAS_ANTICIPACION = dr.ReadNullAsEmptyInteger("DIAS_ANTICIPACION")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        DOC_NEW = False
        If Var1 = "Nuevo" Then
            Try
                Try
                    BarRemisionar.Enabled = False
                    BarEliminar.Enabled = False
                    BarFinOT.Enabled = False
                Catch ex As Exception
                End Try

                tCVE_ORD.Text = GET_MAX("GCORDEN_TRABAJO_EXT", "CVE_ORD")
                tCVE_ORD.Enabled = False
                tEstatus.Text = "Captura"
                DOC_NEW = True

                Try
                    If cboAlmacen.Visible Then
                        If cboAlmacen.SelectedIndex > -1 Then
                            CVE_ALM = cboAlmacen.Text
                        Else
                            CVE_ALM = cboAlmacen.Items(0).ToString
                        End If
                    Else
                        CVE_ALM = 1
                    End If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Fg.Rows.Count = 1
                '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                '                       1            2            3               4               5             6             7             8             9
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                '          10            11           12            13            14           15            16            17            18          19 
                '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov
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

                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, ISNULL(O.TIPO_SERVICIO,0) AS TIPO_SER, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA,
                    O.CVE_UNI, O.CVE_TIPO, O.CVE_OPER, O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS,
                    OB.DESCR AS OBS_STR, ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(DOC_ANTR,'') AS DOCANTR, ISNULL(PORC_UTIL,0) AS P_UTIL,
                    ISNULL(CVE_PROG,'') AS C_PROG, RESPONSABLE
                    FROM GCORDEN_TRABAJO_EXT O
                    LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS
                    WHERE CVE_ORD = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_ORD.Text = dr("CVE_ORD").ToString
                    tCVE_ORD.Tag = dr("DOCANT").ToString

                    tEstatus.Tag = dr("DOCANTR").ToString

                    If dr("P_UTIL") = 0 Then
                        'chAplicarPorcUtiidad.Checked = False
                    Else
                        'chAplicarPorcUtiidad.Checked = True
                    End If
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

                    L3.Text = BUSCA_CAT("Cliente", tCVE_PROV.Text)
                    'tCVE_PROV.Tag = Val(Var6)
                    'L3.Tag = Var7
                    tCVE_PROV.Tag = "0" : L3.Tag = "0"

                    tLUGAR_REP.Text = dr("LUGAR_REP").ToString
                    tNOTA.Text = dr("NOTA").ToString

                    tOBSER.Text = dr("OBS_STR").ToString
                    tOBSER.Tag = dr("CVE_OBS").ToString
                    tCVE_PROG.Text = dr("C_PROG")
                    If tEstatus.Text = "AUTORIZADA" Then
                        Panel1.Enabled = False
                        Panel2.Enabled = False
                    End If

                    tResponsable.Text = dr.ReadNullAsEmptyString("RESPONSABLE")

                    CARGAR_PRODUCTOS()
                    CARGAR_SERVICIOS()
                    DOC_FOTOS(tCVE_ORD.Text)
                Else

                End If
                dr.Close()

                BarRemisionar.Enabled = False
                If Var3 = "Cancelada" Then
                    Fg.Enabled = False
                    FgD.Enabled = False
                    FgS.Enabled = False
                    BarGrabar.Enabled = False
                    BarEnlazarProgSer.Enabled = False
                    BarEnlazarDoc.Enabled = False
                    BarEliminar.Enabled = False
                    BarReimpresion.Enabled = False
                    BarKardex.Visible = True
                    BarCancPartNoEntr.Enabled = False
                    tEstatus.Text = Var3
                    BarFinOT.Enabled = False
                    btnEliProd.Enabled = False

                    btnAltaProducto.Enabled = False
                    btnAltaServicio.Enabled = False
                    btnEliSer.Enabled = False
                    btnFotDocA.Enabled = False
                    btnFotDocE.Enabled = False
                    tDescrFotDoc.Enabled = False
                    btnBuscaDoc.Enabled = False
                    tOBSER.Enabled = False

                    F1.Enabled = False : radCorrectivo.Enabled = False : radExtra.Enabled = False : radPreventivo.Enabled = False
                    tCVE_UNI.Enabled = False : tCVE_TIPO.Enabled = False : tEstatus.Enabled = False : tCVE_PROV.Enabled = False
                    tLUGAR_REP.Enabled = False : tNOTA.Enabled = False : tOBSER.Enabled = False
                    radSinistro.Enabled = False : RadRescateCarr.Enabled = False
                    RadLLantas.Enabled = False : BarEnlazarDoc.Enabled = False : btnProv.Enabled = False : btnTipo.Enabled = False
                    btnUnidades.Enabled = False : tDescrFotDoc.Enabled = False : btnFotDocA.Enabled = False : btnFotDocE.Enabled = False
                    btnBuscaDoc.Enabled = False : tCVE_ORD.Enabled = False : tOBSER.Enabled = False

                Else
                    If tEstatus.Tag.ToString.Length > 0 Then
                        'dr("DOCANTR").ToString      ESTA REMISIONADA
                        BarGrabar.Enabled = False
                        BarEnlazarProgSer.Enabled = False
                        BarEnlazarDoc.Enabled = False
                        BarCancPartNoEntr.Enabled = False
                        BarFinOT.Enabled = Efecto
                        BarRemisionar.Enabled = False
                        BarEliminar.Enabled = False
                        btnEliProd.Enabled = False
                        btnAltaProducto.Enabled = False
                        btnAltaServicio.Enabled = False
                        btnEliSer.Enabled = False
                        tDescrFotDoc.Enabled = False
                        btnBuscaDoc.Enabled = False
                        tOBSER.Enabled = False
                    Else
                        If tEstatus.Text = "AUTORIZADA" Then
                            BarGrabar.Enabled = False
                            BarEnlazarProgSer.Enabled = False
                            BarEnlazarDoc.Enabled = False
                            btnAltaServicio.Enabled = False
                            btnEliSer.Enabled = False
                            BarCancPartNoEntr.Enabled = False
                            BarFinOT.Enabled = False
                            BarRemisionar.Enabled = True
                            btnEliProd.Enabled = False
                            BarEliminar.Enabled = True
                            btnAltaProducto.Enabled = False
                            btnFotDocA.Enabled = False
                            btnFotDocE.Enabled = False
                            tDescrFotDoc.Enabled = False
                            btnBuscaDoc.Enabled = False
                            tOBSER.Enabled = False
                        End If
                    End If
                End If
                tCVE_ORD.Enabled = False
            Catch ex As Exception
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Try

            If USER_GRUPOCE.Trim.Length >= 5 Then
                If U_ALMACEN Or U_MANTE Then
                    'If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Or USER_GRUPOCE.Substring(0, 5) = "MANTE" Or USER_GRUPOCE.IndexOf("TALLER") > -1 Then
                    ACCESO_USUARIO = True
                Else
                    ACCESO_USUARIO = False
                    BarCancPartNoEntr.Enabled = False
                End If
            Else
                ACCESO_USUARIO = False
                BarCancPartNoEntr.Enabled = False
            End If
        Catch ex As Exception
        End Try

        Try
            If BarGrabar.Enabled Then
                ACCESO_USUARIO = True
            Else
                ACCESO_USUARIO = False
            End If
        Catch ex As Exception
        End Try

        Tab1.SelectedIndex = 0
        Try
            ENTRA = True
            ENTRA_FALLAS = True
            _myEditor = New MyEditorOTI(Fg, MULTIALMACEN)

            If tEstatus.Text <> "AUTORIZADA" And tEstatus.Text <> "Cancelado" Then
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
                    BarGrabar.Enabled = False
                    BarEnlazarDoc.Enabled = False
                    BarFinOT.Enabled = False
                    BarRemisionar.Enabled = False
                    BarEliminar.Enabled = False
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
                    tLUGAR_REP.Enabled = False : tNOTA.Enabled = False : tOBSER.Enabled = False
                    radSinistro.Enabled = False : RadRescateCarr.Enabled = False
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
                                        BarGrabar.Enabled = True
                                        'SI TIENE  DERECHOS GRABAR
                                        F1.Enabled = True : radCorrectivo.Enabled = True : radExtra.Enabled = True : radPreventivo.Enabled = True
                                        tCVE_UNI.Enabled = True : tCVE_TIPO.Enabled = True : tEstatus.Enabled = True : tCVE_PROV.Enabled = True
                                        tLUGAR_REP.Enabled = True : tNOTA.Enabled = True : tOBSER.Enabled = True
                                        radSinistro.Enabled = True : RadRescateCarr.Enabled = True
                                        RadLLantas.Enabled = True : BarEnlazarDoc.Enabled = True : btnProv.Enabled = True : btnTipo.Enabled = True
                                        btnUnidades.Enabled = True : tDescrFotDoc.Enabled = True : btnFotDocA.Enabled = True : btnFotDocE.Enabled = True
                                        btnBuscaDoc.Enabled = True : tCVE_ORD.Enabled = True : tOBSER.Enabled = True
                                    Case 93210  'ENLAZAR COTIZACION
                                        BarEnlazarDoc.Enabled = True
                                    Case 93220  'FINALIZAR ORDEN DE TRABAJO
                                        BarFinOT.Enabled = True
                                    Case 93230  'REMISIONAR
                                        BarRemisionar.Enabled = True
                                    Case 93240  'CANCELAR ORDER DE TRABAJO
                                        BarEliminar.Enabled = True
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
                            BarGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            BarRemisionar.Enabled = True
                            BarEliminar.Enabled = True
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
                            BarGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            BarFinOT.Enabled = True
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
    Private Sub FrmOTIAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Orden de Trabajo")
            Me.Dispose()

            If SE_DESPLEGA Then
                If FORM_IS_OPEN("frmOTI") Then
                    frmOTI.DESPLEGAR()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Grabar"
                    '20 FEB 20
                    Try
                        If Not Valida_Conexion() Then
                            Return
                        End If
                        GUARDAR("S")
                    Catch ex As Exception
                    End Try
                Case "Enlazar rep. fallas"
                    ENLAZAR_REPORTE_DE_FALLAS()
                Case "Enlazar prog. servicios"
                    PROGRAMACION_DE_SERVICIOS()

                Case "Generar movs. al inventario"
                    GENERA_MINVE_OT()
                Case "Remisionar"
                    GRABAR_VENTA(tCVE_ORD.Text)
                Case "Kardex"
                    DESPLEGAR_KARDEX()
                Case "Cancelar OT"
                    CANCELAR_OT()
                Case "Reimpresión"
                    ImprimirOrden(tCVE_ORD.Text)
                Case "Cancelar part. no entregadas"
                    CancPartNoEntr()
                Case "Excel"
                    Try
                        EXPORTAR_EXCEL_TRANSPORT(Fg, "ORDEN DE TRABAJO" & tCVE_ORD.Text)
                    Catch ex As Exception
                    End Try
                Case "Salir"
                    SE_DESPLEGA = False
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub ENLAZAR_REPORTE_DE_FALLAS()
        Try
            Var4 = ""
            PAR_FALLA_UUID = ""
            CONTROL_DOC = ""
            frmEnlaceReporteFallas.ShowDialog()
            If Var4.Length > 0 Then
                PAR_FALLA_UUID = Var4
                CONTROL_DOC = "F"
                'LIMPIA EL PROGRAMCION DE SERVICIOS
                tCVE_PROG.Text = ""
                LProgServ.Text = ""

                SQL = "SELECT P.CVE_FALLA, F.FECHA, P.CVE_UNI, C.DESCR, P.DESCR_FALLA, U.CVE_TIPO_UNI, T.DESCR AS DESCR_TIPO_UNI " &
                     "FROM GCREPORTE_FALLAS_PAR P " &
                     "INNER JOIN GCREPORTE_FALLAS F ON F.CVE_FALLA = P.CVE_FALLA " &
                     "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                     "LEFT join GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                     "LEFT JOIN GCCLASIFIC_SERVICIOS C ON C.CVE_CLA = P.CVE_CLAS " &
                     "WHERE F.STATUS = 'A' AND P.UUID = '" & Var4 & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            tCVE_UNI.Text = dr("CVE_UNI")
                            L2.Text = tCVE_UNI.Text
                            tCVE_TIPO.Text = dr.ReadNullAsEmptyString("CVE_TIPO_UNI")
                            L4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI")
                            tOBSER.Text = dr.ReadNullAsEmptyString("DESCR_FALLA")
                            tLUGAR_REP.Select()
                        End If
                    End Using
                End Using
            Else
                Var4 = ""
                PAR_FALLA_UUID = ""
                CONTROL_DOC = ""
            End If
        Catch ex As Exception
            Bitacora("2560. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2560. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GUARDAR(fMENSAJES As String)
        Dim CVE_OBS As Long, TIPO_SERVICIO As Integer, SUM_IMPORTE As Decimal = 0, CVE_ORD As String
        Dim cmd As New SqlCommand

        If Not Valida_Conexion() Then
            Return
        End If

        cmd.Connection = cnSAE

        Try
            Fg.FinishEditing()
            If PERMITIR_UNIDAD = 0 Then
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
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tOBSER.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tOBSER.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            End If
            tOBSER.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
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

        SQL = "UPDATE GCORDEN_TRABAJO_EXT SET CVE_ORD = @CVE_ORD, CVE_PROG = @CVE_PROG, ESTATUS = @ESTATUS, FECHA = @FECHA, 
            TIPO_SERVICIO = @TIPO_SERVICIO, TIPO_EXTRA = @TIPO_EXTRA, CVE_UNI = @CVE_UNI, CVE_TIPO = @CVE_TIPO, CVE_PROV = @CVE_PROV, 
            LUGAR_REP = @LUGAR_REP, NOTA = @NOTA, PORC_UTIL = @PORC_UTIL, RESPONSABLE = @RESPONSABLE, CVE_OBS = @CVE_OBS
            WHERE CVE_ORD = @CVE_ORD
            IF @@ROWCOUNT = 0
            INSERT INTO GCORDEN_TRABAJO_EXT (CVE_ORD, STATUS, FECHA, FECHAELAB, TIPO_SERVICIO, TIPO_EXTRA, CVE_UNI, CVE_TIPO, ESTATUS, CVE_PROV,
            LUGAR_REP, NOTA, CVE_OBS, PORC_UTIL, CVE_PROG, DOC_SIG, RESPONSABLE, GUID) VALUES (@CVE_ORD, 'A', @FECHA, GETDATE(), @TIPO_SERVICIO,
            @TIPO_EXTRA, @CVE_UNI, @CVE_TIPO, @ESTATUS, @CVE_PROV, @LUGAR_REP, @NOTA, @CVE_OBS, @PORC_UTIL, @CVE_PROG, @DOC_SIG, @RESPONSABLE, NEWID())"
        cmd.CommandText = SQL

        If Not Valida_Conexion() Then
            Return
        End If
        Try
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
            cmd.Parameters.Add("@RESPONSABLE", SqlDbType.VarChar).Value = tResponsable.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If

                Try
                    If PAR_FALLA_UUID.Trim.Length > 0 Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCREPORTE_FALLAS_PAR SET CVE_ORD = '" & tCVE_ORD.Text & "' WHERE UUID = '" & PAR_FALLA_UUID & "'"
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue = "1" Then
                            End If
                        End Using
                    End If
                Catch ex As Exception
                    MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
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
                    MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                GRABAR_PRODUCTOS()
                GRABAR_SERVICIOS()
                GRABA_FOTOS_DOC()

                Try
                    SUM_IMPORTE = Val(Lt1.Text.Remove(",", "")) + Val(Lt5.Text.Remove(",", ""))
                Catch ex As Exception
                End Try

                If ERROR_PAR Then
                    ERROR_PAR = False
                    MsgBox("Se detecto un problema al grabar las partidas por favor intentelo nuevamente")
                Else
                    If DOC_ENLAZADO = "S" Then
                        GRABA_DOCTOSIG()
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE FACTC" & Empresa & " SET ENLAZADO = 'T', DOC_SIG = '" & tCVE_ORD.Text & "' " &
                                    "WHERE CVE_DOC = '" & LtDocAnt.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue = "1" Then
                                End If
                            End Using
                            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva orden de trabajo " &
                                       " Enlazado desde la cotizacion " & LtDocAnt.Text, "Se modifico orden de trabajo"))
                        Catch ex As Exception
                            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva", "Se modifico") & " orden de trabajo ")
                    End If
                    If fMENSAJES = "S" Then
                        MsgBox("El registro se grabo satisfactoriamente")
                        ImprimirOrden(tCVE_ORD.Text)
                        Me.Close()
                    End If
                End If
            Else
                If fMENSAJES = "S" Then
                    MsgBox("No se logro grabar el registro")
                End If
            End If
        Catch ex As Exception
            MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
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

            SQL = "INSERT INTO GCDOCTOSIG (CVE_DOC, CVE_ORD, IMPORTE, IMPORTE_OT) VALUES('" &
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
            Dim STATUS As String = "", HORA2 As String, CANT_ENT As Single, CVE_FOLIO As String, UUID As String = "", CVE_ALM As Integer
            Dim CLAVE_PROV As String, CVE_MEC As Integer = 0, CVE_ART As String, CANT As Decimal

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
                Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            ERROR_PAR = False
            For k = 1 To Fg.Rows.Count - 1

                CVE_ART = ""
                Try
                    CVE_ART = Fg(k, 1)
                Catch ex As Exception
                    CVE_ART = ""
                End Try
                CANT = 0
                Try
                    CANT = Fg(k, 5)
                Catch ex As Exception
                    CANT = 0
                End Try
                If CVE_ART.Length > 0 And CANT > 0 Then
                    If Not Valida_Conexion() Then
                    End If
                    Select Case Fg(k, 10)
                        Case "Mov. realizado"
                            STATUS = "M"
                        Case "Cancelada"
                            STATUS = "C"
                        Case Else
                            STATUS = ""
                    End Select

                    If MULTIALMACEN = 1 Then
                        Try
                            If Fg(k, 4).ToString.Length > 1 Then
                                If IsNumeric(Fg(k, 4).ToString.Substring(0, 2)) Then
                                    CVE_ALM = Fg(k, 4).ToString.Substring(0, 2)
                                Else
                                    CVE_ALM = 1
                                End If
                            Else
                                CVE_ALM = 1
                            End If
                        Catch ex As Exception
                            CVE_ALM = 1
                            Bitacora("211. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    Else
                        CVE_ALM = 1
                    End If

                    HORA2 = Fg(k, 17).ToString()
                    CANT_ENT = CONVERTIR_TO_DECIMAL(Fg(k, 18))
                    CVE_FOLIO = Fg(k, 16).ToString

                    Try
                        CVE_MEC = 0
                        If Fg(k, 8).ToString.Length >= 3 Then
                            If IsNumeric(Fg(k, 8).ToString.Substring(0, 3).Trim) Then
                                CVE_MEC = Fg(k, 8).ToString.Substring(0, 3).Trim
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("212. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    CLAVE_PROV = ""
                    Try
                        CLAVE_PROV = Fg(k, 19).ToString()
                    Catch ex As Exception
                    End Try

                    UUID = ""
                    Try
                        UUID = Fg(k, 15).ToString
                    Catch ex As Exception
                    End Try
                    If UUID.Trim.Length = 0 Then
                        UUID = Fg(k, 1) & Now.ToString
                    End If

                    If Valida_Conexion() Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCORDEN_TRA_SER_EXT SET CVE_ART = @CVE_ART, TIPO = @TIPO, DESCR = @DESCR, STATUS = @STATUS, CANT = @CANT,
                                    COSTO = @COSTO, CVE_ALM = @CVE_ALM, IMPORTE = @IMPORTE, HORA2 = @HORA2, TIEMPO_REAL = @TIEMPO_REAL, 
                                    NO_PARTE = @NO_PARTE, CANT_ENTREGADA = @CANT_ENTREGADA, CVE_PROV = @CVE_PROV, CVE_MEC = @CVE_MEC, CONTROL = @CONTROL
                                    WHERE UUID = @UUID
                                    IF @@ROWCOUNT = 0 
                                    INSERT INTO GCORDEN_TRA_SER_EXT (CVE_ORD, TIPO_PROD, CVE_ART, CANT, COSTO, IMPORTE, CVE_ALM, DESCR, TIEMPO_REAL,
                                    NO_PARTE, STATUS, TIPO, CVE_PROV, HORA2, CANT_ENTREGADA, FECHAELAB, UUID, CVE_MEC, CONTROL) VALUES (@CVE_ORD, 'P',
                                    @CVE_ART, @CANT, @COSTO, @IMPORTE, @CVE_ALM, @DESCR, @TIEMPO_REAL, @NO_PARTE, @STATUS, @TIPO, @CVE_PROV,
                                    @HORA2, @CANT_ENTREGADA, GETDATE(), NEWID(), @CVE_MEC, @CONTROL)"
                                cmd2.CommandText = SQL
                                Try
                                    cmd2.Parameters.Clear()
                                    cmd2.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                                    cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = Fg(k, 3).ToString
                                    cmd2.Parameters.Add("@CVE_ALM", SqlDbType.VarChar).Value = CVE_ALM
                                    cmd2.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                                    cmd2.Parameters.Add("@COSTO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 6).ToString), 4)
                                    cmd2.Parameters.Add("@IMPORTE", SqlDbType.VarChar).Value = Math.Round(Val(Fg(k, 7)), 4)
                                    cmd2.Parameters.Add("@TIEMPO_REAL", SqlDbType.VarChar).Value = Fg(k, 9).ToString  'REFERENCIA
                                    cmd2.Parameters.Add("@NO_PARTE", SqlDbType.VarChar).Value = CLAVE_PROV 'CLAVE DEL PROVEEDOR
                                    cmd2.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS
                                    cmd2.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = 0
                                    cmd2.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = CVE_FOLIO
                                    cmd2.Parameters.Add("@HORA2", SqlDbType.VarChar).Value = HORA2
                                    cmd2.Parameters.Add("@CANT_ENTREGADA", SqlDbType.Float).Value = CANT_ENT
                                    cmd2.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                                    cmd2.Parameters.Add("@CVE_MEC", SqlDbType.SmallInt).Value = CVE_MEC
                                    cmd2.Parameters.Add("@CONTROL", SqlDbType.VarChar).Value = CONTROL_DOC
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                    If DOC_ENLAZADO = "S" And LtDocAnt.Text.Length > 0 Then
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "UPDATE PAR_FACTC" & Empresa & " SET PXS = PXS - " & CONVERTIR_TO_DECIMAL(Fg(k, 5).ToString) &
                                                    " WHERE CVE_DOC = '" & LtDocAnt.Text & "' AND CVE_ART = '" & Fg(k, 1).ToString & "'"
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue = "1" Then
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            Bitacora("216. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
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
        Try
            Dim CVE_ALM As Integer

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "DELETE FROM GCORDEN_TRA_SER_EXT WHERE CVE_ORD = '" & tCVE_ORD.Text & "' AND TIPO_PROD = 'S'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False

            If MULTIALMACEN = 1 Then
                Try
                    If cboAlmacen.Text.Trim.Length > 1 Then
                        CVE_ALM = cboAlmacen.Text.Substring(0, 2)
                    Else
                        CVE_ALM = 1
                    End If
                Catch ex As Exception
                    CVE_ALM = 1
                    Bitacora("211. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Else
                CVE_ALM = 1
            End If


            For k = 1 To FgS.Rows.Count - 1
                If FgS(k, 1).ToString.Trim.Length > 0 And CONVERTIR_TO_DECIMAL(FgS(k, 5).ToString) > 0 Then

                    SQL = "INSERT INTO GCORDEN_TRA_SER_EXT (CVE_ORD, TIPO_PROD, CVE_ART, CANT, COSTO, IMPORTE, NO_PARTE, DESCR, TIEMPO_REAL, 
                        STATUS, TIPO, CVE_ALM, FECHAELAB, UUID) VALUES (@CVE_ORD, 'S', @CVE_ART, @CANT, @COSTO, @IMPORTE, @NO_PARTE, @DESCR, 
                        @TIEMPO_REAL, @STATUS, @TIPO, @CVE_ALM, GETDATE(), NEWID())"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = FgS(k, 1).ToString
                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = FgS(k, 3).ToString
                        cmd.Parameters.Add("@NO_PARTE", SqlDbType.VarChar).Value = FgS(k, 4).ToString
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgS(k, 5).ToString)
                        cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgS(k, 6).ToString), 4)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.VarChar).Value = Math.Round(FgS(k, 12), 4)
                        cmd.Parameters.Add("@TIEMPO_REAL", SqlDbType.VarChar).Value = FgS(k, 8).ToString
                        cmd.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = 0
                        cmd.Parameters.Add("@CVE_ALM", SqlDbType.VarChar).Value = CVE_ALM
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
        Dim DESCR As String, DOC As String, Ruta As String
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
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
    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, ISNULL(CVE_CPTO_OT,0) AS CVE_CPTOOT, " &
                "ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOT_SAL, CVE_ART_TOT " &
                "FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                AFEC_TABLA_INVE = dr("AFE_TAB_INV")
                CVE_CPTO_OT = dr("CVE_CPTOOT")
                CVE_CPTO_OT_SAL = dr("CVE_CPTOOT_SAL")
                LINEA_FILTRO_SERVICIO = dr.ReadNullAsEmptyString("CVE_ART_TOT")
            End If
            dr.Close()
            PassData = LINEA_FILTRO_SERVICIO

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
            Dim z As Integer = 1, piezas As Single = 0, CVE_ALM As String = ""
            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.BackColor = Color.Red
            NewStyle1.ForeColor = Color.White

            cmd.Connection = cnSAE
            DESC1 = Val(tCVE_PROV.Tag)
            ENTRA = False
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(IMPORTE,0) AS IMPORT,
                ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa & " WHERE REFER LIKE '%OT" & tCVE_ORD.Text & "%' AND CVE_ART = O.CVE_ART AND CVE_FOLIO = O.CVE_PROV),0) AS CANT_ENT,
                ISNULL(O.COSTO,0) AS COST, ISNULL(O.CVE_ALM,'') AS N_PARTE, TIPO_ELE, ISNULL(HORA2,'') AS MINVE, ISNULL(CVE_PROV,'') AS C_PROV,
                ISNULL(TIEMPO_REAL, '') AS REFER, ISNULL(NO_PARTE, '') AS CLAVE_PROV, ISNULL(TIPO,0) AS TIPO_I, ISNULL(O.STATUS, '') AS ST, ISNULL(O.UUID,'') AS UID,
                ISNULL(CANT_ENTREGADA,0) AS CANT_ENTR, O.CVE_ALM, ISNULL(O.CVE_MEC,0) AS CLAVE_MEC, ISNULL(M.DESCR,'') AS NOMBRE_MEC
                FROM GCORDEN_TRA_SER_EXT O
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART
                LEFT JOIN GCMECANICOS M ON M.CVE_MEC = O.CVE_MEC
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
                        DESCR = BUSCA_CAT("Prov", dr("CLAVE_PROV"))
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
                    If dr("CLAVE") = "0116004472" Then
                        CAD_OBS = CAD_OBS
                    End If
                    If Math.Abs(dr("CANT_ENT")) + Math.Abs(dr("CANT_ENTR")) = 0 Then
                        CANT = dr("CANTI")
                    Else
                        CANT = Math.Abs(dr("CANT_ENT"))
                    End If
                    piezas = piezas + CANT

                    For k As Integer = 0 To cboAlmacen.Items.Count - 1
                        Try
                            If cboAlmacen.Items(k).ToString.Substring(0, 2) = dr.ReadNullAsEmptyInteger("CVE_ALM") Then
                                CVE_ALM = cboAlmacen.Items(k).ToString
                            End If
                        Catch ex As Exception
                            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Next

                    Fg.AddItem(z & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & CVE_ALM & vbTab & CANT & vbTab & COSTO & vbTab &
                        SUBTOTAL & vbTab & IIf(dr("CLAVE_MEC") = 0, "", (dr("CLAVE_MEC").ToString.PadLeft(3) & " " & dr("NOMBRE_MEC"))) & vbTab &
                        dr("REFER") & vbTab & CAD_OBS & vbTab & dr("CANTI") & vbTab & (Math.Abs(dr("CANT_ENT")) + Math.Abs(dr("CANT_ENTR"))) & vbTab &
                        dr("IMPORT") & vbTab & CAD_OBS & vbTab & dr("UID") & vbTab & dr("C_PROV") & vbTab & dr("MINVE") & vbTab &
                        dr("CANT_ENTR") & vbTab & dr("CLAVE_PROV"))
                    If CAD_OBS = "Cancelada" Then
                        Fg.Rows(Fg.Rows.Count - 1).Style = NewStyle1
                    End If

                    z = z + 1
                    HayDatos = True
                Loop
                If tEstatus.Text <> "AUTORIZADA" And tEstatus.Text <> "Cancelado" Then
                End If
                SUM_IMPORTES("P")
            Else
                If cboAlmacen.Visible Then
                    If cboAlmacen.SelectedIndex > -1 Then
                        CVE_ALM = cboAlmacen.Text
                    Else
                        CVE_ALM = cboAlmacen.Items(0).ToString
                    End If
                Else
                    CVE_ALM = 1
                End If
                '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                '                       1            2            3               4               5             6             7             8             9
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                '          10            11           12            13            14           15            16            17            18          19 
                '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

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
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) > 0 And Fg(k, 10).ToString.Trim <> "Cancelada" Then
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
            CONTROL_DOC = ""
            PAR_FALLA_UUID = ""

            ENTRA = False
            Fg.Rows.Count = 1

            Dim CVE_ALM As String = "1"

            Try
                If cboAlmacen.Visible Then
                    If MULTIALMACEN = 1 Then
                        If cboAlmacen.SelectedIndex > -1 Then
                            CVE_ALM = cboAlmacen.Text
                        Else
                            CVE_ALM = cboAlmacen.Items(0).ToString
                        End If
                    End If
                End If

            Catch ex As Exception
                CVE_ALM = "1"
            End Try

            '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
            '                       1            2            3               4               5             6             7             8             9
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
            '          10            11           12            13            14           15            16            17            18          19 
            '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

            Fg.Rows(Fg.Rows.Count - 1).Height = 30
            ENTRA = True

        Catch ex As Exception
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If Fg.Row > 0 Then
                If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
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
            Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
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

    Private Sub TTVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
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
                                'DESPLEGAR()
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("369. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            'DESPLEGAR()
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
                tResponsable.Select()
            End If

        Catch Ex As Exception
            MsgBox("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("300. " & Ex.Message & vbNewLine & Ex.StackTrace)
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
                    tResponsable.Select()
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
                    tResponsable.Select()
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

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Clientes"
            Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem.ShowDialog()
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

    Private Sub TCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
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
    Private Sub BtnAltaProducto_Click(sender As Object, e As EventArgs) Handles btnAltaProducto.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 3).ToString.Trim.Length > 0 Then
                Dim CVE_ALM As String = "1"

                If cboAlmacen.Visible Then
                    If cboAlmacen.SelectedIndex > -1 Then
                        CVE_ALM = cboAlmacen.Text
                    Else
                        CVE_ALM = cboAlmacen.Items(0).ToString
                    End If
                End If

                '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                '                       1            2            3               4               5             6             7             8             9
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                '          10            11           12            13            14           15            16            17            18          19 
                '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

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
                If Fg(Fg.Row, 10) = "Cancelada" Then
                    MessageBox.Show("La partida se encuentra cancelada")
                    Return
                End If
                If Fg(Fg.Row, 10) = "Mov. realizado" Then
                    If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Or pwPoder Then
                        Sigue = True
                    Else
                        Sigue = False
                    End If
                Else
                    If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Or USER_GRUPOCE.Substring(0, 5) = "MANTE" Or USER_GRUPOCE.IndexOf("TALLER") > -1 Or pwPoder Then
                        Sigue = True
                    Else
                        Sigue = False
                    End If
                End If
                If Sigue Then
                    If MsgBox("Realmente desea cancelar la(s) partida(s) seleccionada(s) ?", vbYesNo) = vbYes Then
                        Try
                            CANCELAR_MOVS_PARTIDA()
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
    Sub CANCELAR_MOVS_PARTIDA()
        Try
            Dim r_ As Row, z As Integer = 0, CVE_DOC As String

            CVE_DOC = "CCOT" & tCVE_ORD.Text & "_" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
            If CVE_DOC.Length > 20 Then
                CVE_DOC = CVE_DOC.Substring(0, 20)
            End If

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    If Fg(r_.Index, 10) = "Mov. realizado" Then
                        Try        'UUID
                            If Fg(r_.Index, 15).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(r_.Index)
                            Else
                                GENERA_MINVE_OT_PARTIDA(CVE_DOC, Fg(r_.Index, 1), Fg(r_.Index, 5), Fg(r_.Index, 15), r_.Index)
                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Cancelacion partida Orden de trabajo con mov. ralizado articulo " &
                                           Fg(r_.Index, 1) & " cant. " & Fg(r_.Index, 5))
                                Try
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'C', HORA2 = '', CVE_PROV = '' WHERE UUID = '" & Fg(r_.Index, 14) & "'"
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
                End If
            Else
                MsgBox("No se encontraron partida(s) a cancelar")
            End If
            'Fg.Row = Fg.Rows.Count - 1
            'Fg.Col = 1
            '_myEditor.StartEditing(Fg.Row, 1)

        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GENERA_MINVE_OT_PARTIDA(fCVE_DOC As String, fCVE_ART As String, fCANT As Single, fUUID As String, fROW As Integer)
        Dim CVE_ART As String = ""
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = 1, COSTEADO As String = "S", COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = "", E_LTPD As String = ""
        Dim CVE_DOC As String, CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0, NO_HAY_EXIST As Integer = 0
        Dim HayPart As Boolean, Continua As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            Fg.FinishEditing()

            CVE_CPTO = CVE_CPTO_OT
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
                    SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE
                          FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
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
                            SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) + " & CANT &
                                " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN &
                                "If @@ROWCOUNT = 0 " &
                                "INSERT INTO MULT" & Empresa & "(CVE_ART, CVE_ALM, STATUS, CTRL_ALM, " &
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
                        SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
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
                            SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, 
                                VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON, 
                                FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) 
                                VALUES('" & CVE_ART & "','" & ALMACEN & "',(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                CVE_CPTO & "','" & FSQL(F1.Value) & "','" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" &
                                CVE_VEND & "','" & CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" &
                                E_LTPD & "',ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0)," 'EXIST_G
                            If MULTIALMACEN = 1 Then
                                SQL = SQL & "ISNULL((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                            Else
                                SQL = SQL & "ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),0),'"  'EXISTENCIA
                            End If
                            SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),
                                (SELECT ISNULL(ULT_CVE,0) + 1 FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" & SIGNO & "','" &
                                COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" &
                                COSTO_PROM & "')"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery.ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    NProc = NProc + 1
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
                                                Fg(fROW, 10) = "Cancelada"
                                                Fg(fROW, 14) = ""
                                                Fg(fROW, 17) = ""
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Bitacora("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    Try
                                        SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
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
                                End If
                            End If
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
    Sub ImprimirOrden(fCVE_ORD As String)
        Dim RUTA_FORMATOS As String = "", CVE_DOC_TOT As String = ""
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenTrabajoExterna.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportOrdenTrabajoExterna.mrt, verifique por favor")
                Return
            End If

            Try
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1) = "TOT" Then
                        CVE_DOC_TOT = Fg(k, 9)
                        Exit For
                    End If
                Next
            Catch ex As Exception
                Bitacora("331. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

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
            StiReport1.Item("CVE_DOC_O") = CVE_DOC_TOT
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Not ACCESO_USUARIO Then
                Return
            End If
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
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
                If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
                    Return
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If ENTRA Then
                ENTRA = False
                If Fg.Row > 0 Then
                    'Or Fg.Col = 4 
                    If Fg.Col = 3 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
                        e.Cancel = True
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
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

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
                        e.Cancel = True
                        Return
                    End If
                    If tEstatus.Text = "AUTORIZADA" Then
                        e.Cancel = True
                        Return
                    End If
                End If
            Catch ex As Exception
            End Try

            ENTRA_BTN = False
            Var4 = ""
            Var5 = ""
            Fg.FinishEditing()

            If Fg.Col = 2 Then
                Var2 = "InveP"

                frmSelItem.ShowDialog()
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
                        PRECIO = Val(Var9)
                        PRECIO = Math.Round(PRECIO, 4)
                    Catch ex As Exception
                    End Try

                    Fg(Fg.Row, 1) = Var4  'CVE_ART
                    Fg(Fg.Row, 3) = Var5  'DESCR
                    'Fg(Fg.Row, 4) = Var6  'NO_PARTE
                    Fg(Fg.Row, 6) = Var9 'precio
                    Fg(Fg.Row, 13) = Var8  'TIPO ELE
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
            End If
            If Fg.Col = 4 Then
                Var2 = "Almacenes"

                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    ENTRA = False
                    Fg.FinishEditing()
                    ENTRA = True

                    Fg(Fg.Row, 4) = Format(Val(Var4), "00") & " " & Var5

                    Var2 = "" : Var4 = "" : Var5 = ""

                    Fg.Col = 5
                    _myEditor.StartEditing(e.Row, 5)
                Else
                    Fg.Col = 1 'ARTICULO
                    _myEditor.StartEditing(e.Row, 1)
                End If
            End If
            If Fg.Col = 8 Then
                Var2 = "Mecanicos"

                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    ENTRA = False
                    Fg.FinishEditing()
                    ENTRA = True

                    Fg(Fg.Row, 8) = Var4.PadLeft(3) & " " & Var5

                    Var2 = "" : Var4 = "" : Var5 = ""

                    BtnAltaProducto_Click(Nothing, Nothing)
                Else
                    Fg.Col = 1 'ARTICULO
                    _myEditor.StartEditing(e.Row, 1)
                End If
            End If
            ENTRA_BTN = True
        Catch ex As Exception
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TNOTA_KeyDown(sender As Object, e As KeyEventArgs) Handles tNOTA.KeyDown
        Try
            If e.KeyCode = 13 Then
                tLUGAR_REP.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        If Not ACCESO_USUARIO Then
            Return
        End If
        Try
            If PASS_GRUPOCE = "FRAJA" Then
                If Fg.Row > 0 And ENTRA Then
                    Dim c_ As Integer
                    If Fg.Col = 2 Then
                        c_ = 1
                    Else
                        c_ = Fg.Col
                    End If
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
                Return
            End If
            Try
                If Fg.Row > 0 Then
                    If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
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
                    Var19 = "OTI"  'ORDEN EXTERNA PARA SER VISUALIZADA DESDE COMPRAS
                    Cp1 = tCVE_UNI.Text
                    Cp2 = tCVE_TIPO.Text

                    If Fg(Fg.Row, 9).ToString.Trim.Length > 1 Then
                        Var11 = "edit"
                        Var12 = Fg(Fg.Row, 9)
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
            If tEstatus.Text = "AUTORIZADA" Or tEstatus.Text = "REMISIONADA" Then
                e.Cancel = True
                Return
            End If
            If FgS.Row > 0 And ENTRA Then
                ENTRA = False
                If FgS.Col = 0 Or FgS.Col = 3 Or FgS.Col = 4 Or FgS.Col = 6 Or FgS.Col = 7 Or FgS.Col = 8 Then
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
        Try
            ENTRA_BTN = False
            Var2 = "InveS"
            Var4 = ""
            Var5 = LINEA_FILTRO_SERVICIO
            Var6 = "" 'ALTERNA
            Var7 = "0" 'PRECIO
            Var8 = "" 'TIPO PROD
            Var9 = "" 'COSTO PROM
            FgS.FinishEditing()

            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                FgS.FinishEditing()
                FgS(FgS.Row, 1) = Var4  'CVE_ART
                FgS(FgS.Row, 3) = Var5  'DESCR
                FgS(FgS.Row, 4) = Var6  'NO_PARTE
                FgS(FgS.Row, 6) = Var9  'COSTO PROM
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
        Try
            If FgS.Row > 0 And ENTRA Then
                ENTRA = False
                If tEstatus.Text = "AUTORIZADA" Or tEstatus.Text = "REMISIONADA" Then
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
                    If (FgS.Col = 1 Or FgS.Col = 2 Or FgS.Col = 5) And FgS(FgS.Row, 9) <> "M" Then
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
                If FgS.Col = 2 Or FgS.Col = 3 Or FgS.Col = 4 Or FgS.Col = 6 Or FgS.Col = 7 Or FgS.Col = 8 Or FgS.Col = 9 Then

                Else
                    If FgS(FgS.Row, 9) <> "M" And tEstatus.Text <> "FINALIZADA" Then
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

    Private Sub FgS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FgS.KeyPress

    End Sub

    Private Sub FgS_KeyDown(sender As Object, e As KeyEventArgs) Handles FgS.KeyDown
        Try
            If FgS.Row > 0 Then
                If tEstatus.Text = "AUTORIZADA" Or tEstatus.Text = "REMISIONADA" Then
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
            If tEstatus.Text = "AUTORIZADA" Or tEstatus.Text = "REMISIONADA" Then
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
                    Case 5
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
                                'Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                                'Var7 = dr.ReadNullAsEmptyDecimal("P1")
                                'Var8 = dr.ReadNullAsEmptyString("T_ELE")
                                'Var9 = dr.ReadNullAsEmptyDecimal("C_PROM")
                                Var5 = LINEA_FILTRO_SERVICIO
                                Var6 = ""
                                Var7 = ""
                                Var8 = ""
                                Var9 = ""
                                DESCR = BUSCA_CAT("InveS2", FgS.Editor.Text)
                                If DESCR <> "" Then
                                    FgS(FgS.Row, 1) = FgS.Editor.Text
                                    FgS(FgS.Row, 3) = DESCR
                                    FgS(FgS.Row, 4) = Var6
                                    If FgS(FgS.Row, 5).ToString.Length = 0 Or FgS(FgS.Row, 5) = 0 Then
                                        FgS(FgS.Row, 5) = 1  'CANTI
                                    End If
                                    FgS(FgS.Row, 6) = Var9  'PRECIO
                                    FgS(FgS.Row, 11) = Var8  'TIPO ELE
                                    FgS.Col = 4
                                Else
                                    e.Cancel = True
                                    MsgBox("Artículo inexistente o no pertenece a la linea " & LINEA_FILTRO_SERVICIO)
                                End If
                            End If
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
    Sub CANCELAR_OT()
        Try
            If MsgBox("Realmente desea cancelar la orden de trabajo " & tCVE_ORD.Text & "?", vbYesNo) = vbYes Then

                SQL = "UPDATE GCORDEN_TRABAJO_EXT SET STATUS = 'C' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 180

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
                CANCELAR_MOVS()
                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Se cancelo Orden de trabajo ")
                MsgBox("El registro se cancelo satisfactoriamente")
                Me.Close()

            End If
        Catch ex As Exception
            MsgBox("2680. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CANCELAR_MOVS()
        Try
            Dim z As Integer = 0, CVE_DOC As String, ALM As Integer

            CVE_DOC = "CCOT" & tCVE_ORD.Text & "_" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
            If CVE_DOC.Length > 20 Then
                CVE_DOC = CVE_DOC.Substring(0, 20)
            End If

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 10) = "Mov. realizado" Then
                    Try        '                              articulo    cant      UUID

                        Try
                            ALM = Fg(k, 4).ToString.Substring(0, 2)
                        Catch ex As Exception

                        End Try
                        GENERA_MINVE_OT_CANCELACION(CVE_DOC, Fg(k, 1), Fg(k, 5), Fg(k, 15), ALM, k)

                        GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Cancelacion partida Orden de trabajo con mov. ralizado articulo " &
                                       Fg(k, 1) & " cant. " & Fg(k, 5))
                        Try
                            SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'C', HORA2 = '', CVE_PROV = '' WHERE UUID = '" & Fg(k, 14) & "'"
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
                        z = z + 1
                    Catch ex As Exception
                        Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
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
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)

        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Sub GENERA_MINVE_OT_CANCELACION(fCVE_DOC As String, fCVE_ART As String, fCANT As Single, fUUID As String, fNUM_ALM As Integer, fROW As Integer)
        Dim CVE_ART As String = ""
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = 1, COSTEADO As String = "S", COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = "", E_LTPD As String = ""
        Dim CVE_DOC As String, CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0, NO_HAY_EXIST As Integer = 0
        Dim HayPart As Boolean, Continua As Boolean

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Try
            Fg.FinishEditing()

            CVE_CPTO = CVE_CPTO_OT
            CVE_ART = fCVE_ART
            CANT = fCANT

            ALMACEN = fNUM_ALM
            If ALMACEN = 0 Then ALMACEN = 1

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
                        COSTO_PROM_INI = COSTO_PROM
                        COSTO_PROM_FIN = COSTO_PROM
                    Catch ex As Exception
                        Bitacora("1030. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1030. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If MULTIALMACEN = 1 Then
                            SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) + " & CANT &
                                " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN &
                                "If @@ROWCOUNT = 0 " &
                                "INSERT INTO MULT" & Empresa & "(CVE_ART, CVE_ALM, STATUS, CTRL_ALM, " &
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
                        SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
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
                            SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, " &
                                "TIPO_DOC, REFER, CLAVE_CLPV, VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, " &
                                "TIPO_PROD, FACTOR_CON, FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, " &
                                "DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" & CVE_ART & "','" & ALMACEN & "'," &
                                "(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                CVE_CPTO & "',CONVERT(varchar, GETDATE(), 112),'" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                                CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                            If MULTIALMACEN = 1 Then
                                SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                            Else
                                SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                            End If
                            SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ISNULL(ULT_CVE,0) + 1 FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                    SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO_PROM & "')"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery.ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    NProc = NProc + 1
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
                                        SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
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
                                End If
                            End If
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


    Sub GENERA_MINVE_OT()

        Dim CVE_ART As String = "", CVE_ORD As String
        Dim CVE_CPTO As Integer = 60, FACTOR_CON As Single = 1, SIGNO As Integer = -1, COSTEADO As String = "S", COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single
        Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, TIPO_DOC As String = "M", TIPO_PROD As String = "P", ExistProd As Boolean = False
        Dim CANT As Single, PREC As Single = 0, COSTO As Single = 0, CVE_VEND As String = "", REG_SERIE As Integer = 0, UNI_MED As String = "", E_LTPD As String = ""
        Dim CVE_DOC As String = "", CLIENTE As String = "", COSTO_PROM As Single = 0, EXIST As Single = 0 : Dim ALMACEN As Integer = 0, NO_HAY_EXIST As Integer = 0
        Dim HayPart As Boolean, CVE_FOLIO As String = "", Continua As Boolean, UUID As String = "", NO_SE_GRABO As Boolean = True, Ano As String, ErrFolio As Boolean
        Dim EXIST_OK As Boolean, ALM_STR As String = "", Num As Integer = 0

        Dim cmd As New SqlCommand

        If MsgBox("Realmente desea generar los movimientos al inventario de la orden de trabajo?", vbYesNo) = vbNo Then
            Return
        End If
        Fg.FinishEditing()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        If CVE_CPTO_OT_SAL = 0 Then
            MsgBox("Por favor seleccione los conceptos en Parametros del sistema-Inventario")
            Return
        End If
        CVE_CPTO = CVE_CPTO_OT_SAL

        If Not Valida_Conexion() Then
            Return
        End If

        If tEstatus.Text = "AUTORIZADA" Then
            MsgBox("Orden de trabajo se encuentra AUTORIZADA, verifique por favor")
            Return
        End If
        Try
            Threading.Thread.Sleep(1000)
            GUARDAR("N")

            Threading.Thread.Sleep(1000)
        Catch ex As Exception
        End Try

        Try
            EXIST_OK = True
            For k = 1 To Fg.Rows.Count - 1

                CANT = Fg(k, 5)
                CVE_ART = Fg(k, 1)
                UUID = Fg(k, 15)

                If CVE_ART.Trim.Length > 0 And CVE_ART <> "TOT" And CANT > 0 And Fg(k, 10) <> "Mov. realizado" And Fg(k, 10) <> "Cancelada" Then
                    If UUID.Trim.Length = 0 Then
                        EXIST_OK = False
                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("961. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If Not EXIST_OK Then
            Me.Cursor = Cursors.Default
            MsgBox("Por favor primero grabe la orden de trabaja porque se agregaron nueva(s) partida(s)")
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        CVE_ORD = tCVE_ORD.Text
        Try
            EXIST_OK = True
            '██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
            '██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
            For k = 1 To Fg.Rows.Count - 1

                Try
                    CVE_FOLIO = ""
                    CANT = Fg(k, 5)
                    CVE_ART = Fg(k, 1)
                    COSTO = Fg(k, 6)
                    UUID = Fg(k, 15)
                    CVE_FOLIO = Fg(k, 16)
                Catch ex As Exception
                    Bitacora("961. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("961. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If CVE_ART.Trim.Length > 0 And CVE_ART <> "TOT" And CANT > 0 And Fg(k, 10) <> "Mov. realizado" And Fg(k, 10) <> "Cancelada" Then
                    HayPart = True

                    If Not Valida_Conexion() Then
                        Return
                    End If
                    Try
                        If MULTIALMACEN = 1 Then
                            Try
                                ALM_STR = Fg(k, 4)
                                If ALM_STR.Length >= 2 Then
                                    ALM_STR = Fg(k, 4).ToString.Substring(0, 2)
                                    If IsNumeric(ALM_STR) Then
                                        ALMACEN = ALM_STR
                                    Else
                                        ALMACEN = 1
                                    End If
                                End If

                            Catch ex As Exception
                                ALMACEN = 1
                            End Try
                        Else
                            ALMACEN = 1
                        End If

                        If ALMACEN = 0 Then ALMACEN = 1

                        COSTO_PROM_INI = COSTO_PROM
                        COSTO_PROM_FIN = COSTO_PROM
                    Catch ex As Exception
                        Bitacora("962. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("962. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    ExistProd = False
                    EXIST = 0
                    If MULTIALMACEN = 1 Then
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        UNI_MED = dr2("UNI_MED")
                                        'COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                    End If
                                End Using
                            End Using
                            SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM  = " & ALMACEN
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        ExistProd = True
                                    Else
                                        ExistProd = False
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            EXIST = 0
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        UNI_MED = dr2("UNI_MED")
                                        'COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                        ExistProd = True
                                    Else
                                        ExistProd = False
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            EXIST = 0
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    If TIPO_PROD = "P" And ExistProd And EXIST >= CANT Then
                        Num = Num + 1
                    Else
                        Try
                            EXIST_OK = False
                            Fg(k, 0) = "EI"
                            'Fg(k, 17) = "Existencia " & EXIST
                            Fg.Rows(k).Style = NewStyle1
                        Catch ex As Exception
                            EXIST_OK = False
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next

            Try
                If Not EXIST_OK Then
                    'MsgBox("En algunas partidas la existencia es insuficiente")
                    MessageBox.Show("En algunas partidas la existencia es insuficiente")
                    Me.Cursor = Cursors.Default
                    Return
                End If
                If Num = 0 Then
                    MsgBox("No se encontraron partidas a procesar o se encuentran con el movimiento al inventario realizado")
                    Me.Cursor = Cursors.Default
                    Return
                End If
            Catch ex As Exception
                Bitacora("850. " & ex.Message & vbNewLine & ex.StackTrace)
                Return
            End Try
        Catch ex As Exception
            Bitacora("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("85. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        For w = 1 To 5
            If Valida_Conexion() Then
                Exit For
            End If
        Next

        Try
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180
            Try
                CVE_DOC = "OT" & CVE_ORD & "_" & Format(Now.Hour, "00") & Format(Now.Second, "00") & Now.Day & Now.Month & Now.Year
                If CVE_DOC.Length > 20 Then
                    CVE_DOC = CVE_DOC.Substring(0, 20)
                End If
                HayPart = False
            Catch ex As Exception
                Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            For k = 1 To Fg.Rows.Count - 1

                For w = 1 To 5
                    If Valida_Conexion() Then
                        Exit For
                    End If
                Next

                Try
                    CVE_FOLIO = ""
                    CANT = Fg(k, 5)
                    CVE_ART = Fg(k, 1)
                    COSTO = Fg(k, 6)

                    UUID = Fg(k, 15)
                    CVE_FOLIO = Fg(k, 16)
                Catch ex As Exception
                    Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If CVE_ART.Trim.Length > 0 And CVE_ART <> "TOT" And CANT > 0 And Fg(k, 10) <> "Mov. realizado" And Fg(k, 10) <> "Cancelada" Then
                    HayPart = True
                    If Not Valida_Conexion() Then
                    End If
                    EXIST = 0
                    Try
                        If MULTIALMACEN = 1 Then
                            If MULTIALMACEN = 1 Then
                                Try
                                    ALM_STR = Fg(k, 4)
                                    If ALM_STR.Length >= 2 Then
                                        ALM_STR = Fg(k, 4).ToString.Substring(0, 2)
                                        If IsNumeric(ALM_STR) Then
                                            ALMACEN = ALM_STR
                                        Else
                                            ALMACEN = 1
                                        End If
                                    End If

                                Catch ex As Exception
                                    ALMACEN = 1
                                End Try
                            Else
                                ALMACEN = 1
                            End If
                        Else
                            ALMACEN = 1
                        End If

                        If ALMACEN = 0 Then ALMACEN = 1

                        COSTO_PROM_INI = COSTO_PROM
                        COSTO_PROM_FIN = COSTO_PROM
                    Catch ex As Exception
                        Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If MULTIALMACEN = 1 Then
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE " &
                                "FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        UNI_MED = dr2("UNI_MED")
                                        'COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                    End If
                                End Using
                            End Using

                            SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM  = " & ALMACEN
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        ExistProd = True
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        Try
                            SQL = "SELECT EXIST, UNI_MED, ULT_COSTO, COSTO_PROM, TIPO_ELE " &
                                "FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                        UNI_MED = dr2("UNI_MED")
                                        'COSTO = dr2("ULT_COSTO")
                                        COSTO_PROM = dr2("COSTO_PROM")
                                        TIPO_PROD = dr2("TIPO_ELE")
                                        ExistProd = True
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    If TIPO_PROD = "P" And ExistProd And EXIST >= CANT Then
                        If Not Valida_Conexion() Then
                        End If
                        Try
                            If MULTIALMACEN = 1 Then
                                SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT &
                                    " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN &
                                    " If @@ROWCOUNT = 0 " &
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
                            MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("170. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                        Continua = True
                        Try
                            SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery.ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        Catch ex As Exception
                            Continua = False
                            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If Not Valida_Conexion() Then
                            Continua = False
                            NO_SE_GRABO = False
                        End If
                        If Continua Then
                            ErrFolio = False
                            Try
                                If CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO = "-" Then
                                    CVE_FOLIO = GET_CVE_FOLIO()
                                    If CVE_FOLIO.Trim.Length = 0 Or CVE_FOLIO = "-" Then

                                        Try
                                            Ano = DateTime.Now.Year.ToString
                                            Ano = Ano.Substring(Ano.Length - 1, 1)
                                            CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") & Format(DateTime.Now.Hour, "00") & Format(DateTime.Now.Minute, "00")
                                        Catch ex As Exception
                                            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                ErrFolio = True
                            End Try

                            If ErrFolio Then
                                Try
                                    Ano = DateTime.Now.Year.ToString
                                    Ano = Ano.Substring(Ano.Length - 1, 1)
                                    CVE_FOLIO = Ano & Format(DateTime.Now.Month, "00") & Format(DateTime.Now.Day, "00") &
                                        Format(DateTime.Now.Hour, "00") & Format(DateTime.Now.Minute, "00")
                                Catch ex As Exception
                                    Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                            If CVE_FOLIO.Length > 9 Then
                                CVE_FOLIO = CVE_FOLIO.Substring(0, 9)
                            End If

                            Try
                                If COSTO <= 0 Then
                                    COSTO = COSTO_PROM
                                End If
                            Catch ex As Exception
                                Bitacora("151. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, 
                                    VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, CVE_FOLIO, TIPO_PROD, 
                                    FACTOR_CON, FECHAELAB, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) 
                                    VALUES ('" & CVE_ART & "','" & ALMACEN & "', (SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                                    CVE_CPTO & "','" & FSQL(F1.Value) & "','" & TIPO_DOC & "','" & CVE_DOC & "','" & CLIENTE & "','" &
                                    CVE_VEND & "','" & CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & UNI_MED & "','" &
                                    E_LTPD & "',(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                                If MULTIALMACEN = 1 Then
                                    SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                                Else
                                    SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                                End If 'CVE_FOLIO
                                SQL = SQL & CVE_FOLIO & "','" & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),'" & SIGNO & "','" & COSTEADO & "','" &
                                    COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO_PROM & "')"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        NO_HAY_EXIST = NO_HAY_EXIST + 1
                                    End If
                                End If
                                Try '- TERMINA INSERT INTO MINVE               - TERMINA INSERT INTO MINVE
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE', CVE_PROV = '" & CVE_FOLIO &
                                        "' WHERE UUID = '" & UUID & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                    'Fg(k, 10) = "M"
                                    'Fg(k, 17) = "MINVE"
                                    'Fg(k, 16) = CVE_FOLIO
                                Catch ex As Exception
                                    Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                GRABA_BITA(tCVE_PROV.Text, CVE_ORD, COSTO, "M", "Generacion de movimiento al inventario " &
                                           "Referencia : " & CVE_DOC & " articulo " & CVE_ART & " Cantidad " & CANT & "  FOLIO  " & CVE_FOLIO)
                            Catch ex As Exception
                                Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Else
                            Fg.Rows(k).Style = NewStyle1
                        End If
                    Else
                        Fg(k, 0) = "EI"
                        'Fg(k, 17) = "Existencia " & EXIST
                    End If
                End If
            Next
            'FINALZIAR ODEN DE TRABAJO
            Try
                Try
                    If tCVE_PROG.Text.Trim.Length > 0 Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCPROGAMACION_SERVICIOS SET CVE_ORD = '" & CVE_ORD & "', FECHA_INI_SER = GETDATE() " &
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
                tEstatus.Text = "AUTORIZADA"
            Catch ex As Exception
                Bitacora("2540. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2540. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'AUTORIZADA' WHERE CVE_ORD = '" & CVE_ORD & "'"
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                    GRABA_BITA(tCVE_PROV.Text, CVE_ORD, 0, "T", "Autorizando orden de trabajo ")
                End Using
            Catch ex As Exception
                Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Me.Cursor = Cursors.Default

            ImprimirMinve(CVE_DOC)

            Threading.Thread.Sleep(2000)

            Me.Close()

        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirMinve(fREFER As String)
        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinveOT" & Empresa & ".mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinveOT.mrt"
                If Not File.Exists(RUTA_FORMATOS) Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(RUTA_FORMATOS)

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
                    'DESPLEGAR()
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
                If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
                    e.Cancel = True
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("1341. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If ENTRA Then
                'Or Fg.Col = 4 
                If Fg.Col = 3 Or Fg.Col = 7 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then
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
                If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
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
                If Fg(Fg.Row, 10) = "Mov. realizado" Or Fg(Fg.Row, 10) = "Cancelada" Then
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
                CVE_DOC = Fg(k, 9)

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    If CVE_ART = "TOT" Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_ART, CANT, COST FROM PAR_COMPO" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read
                                        Try
                                            If tCVE_ORD.Text.Trim.Length > 0 Then
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
                                            End If
                                        Catch ex As Exception
                                            Bitacora("1390. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("1400. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        If Fg(k, 10) = "Mov. realizado" Then
                            Try
                                If tCVE_ORD.Text.Trim.Length > 0 Then
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
                                End If
                            Catch ex As Exception
                                Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            Next

            For k = 1 To FgS.Rows.Count - 1

                CVE_ART = FgS(k, 1)
                CANT = FgS(k, 5)
                PRECIO = FgS(k, 6)

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    Try
                        If tCVE_ORD.Text.Trim.Length > 0 Then
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
                        End If
                    Catch ex As Exception
                        Bitacora("1440. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            Bitacora("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Var23 = NREG
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
        Dim MTO_PORC As Integer, MTO_CUOTA As Integer
        Dim ULT_COSTO As Single, COSTO_PROM As Single, CVE_ESQIMPU As Integer = 1, DESCR As String, UNI_MED As String
        'MOVSINV
        Dim CVE_CPTO As Integer, TIPO_DOC As String, FACTOR_CON As Single, SIGNO As Integer, COSTEADO As String
        Dim COSTO_PROM_INI As Single, COSTO_PROM_FIN As Single, DESDE_INVE As String, MOV_ENLAZADO As Integer, USO_CFDI As String
        Dim FOLIO_ASIGNADO As Boolean, SIGUE As Boolean
        Dim Existe As Boolean
        Dim cIeps As Single, cImpu As Single, cImpu2 As Single, cImpu3 As Single
        Dim VentaGen As String, CADENA_NUM_MOV As String

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
                'If MsgBox("Realmente desea grabar la Remisión?", vbYesNo) = vbNo Then
                'Exit Sub
                'End If
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
                                'If TIPO_PROD <> "S" Then
                                'DESCOT = Val(tCVE_PROV.Tag)
                                'If DESCOT = 0 And Val(L3.Tag) > 0 Then
                                'PRECIO = PRECIO + Val(L3.Tag)
                                'Else
                                'If DESCOT = 0 Then
                                'DESCOT = 5
                                'End If
                                '           PRECIO = PRECIO + (PRECIO * DESCOT / 100)
                                'End If

                                'End If
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

            SQL = "UPDATE FACTR_CLIB" & Empresa & " SET CAMPLIB4 = 'Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "' " &
                "WHERE CLAVE_DOC = '" & CVE_DOC & "' " &
                "IF @@ROWCOUNT = 0 " &
                "INSERT INTO FACTR_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB4) VALUES('" & CVE_DOC & "','Placa:" & Var7 & " Unidad: " & tCVE_UNI.Text & "')"
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
                            'If TIPO_PROD <> "S" Then
                            'DESCOT = Val(tCVE_PROV.Tag)
                            'If DESCOT = 0 And Val(L3.Tag) > 0 Then
                            'PRECIO = PRECIO + Val(L3.Tag)
                            'Else
                            'If DESCOT = 0 Then
                            'DESCOT = 5
                            'End If
                            '       PRECIO = PRECIO + (PRECIO * DESCOT / 100)
                            'End If
                            'End If
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
            Fg(Fg.Row, 9) = CVE_DOC
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

    Sub FINALIZAR_OT()
        Dim Orden_Vacias As Integer = 0, Orden_proc As Integer = 0, Num_ord As Integer = 0, Num_Canc As Integer = 0
        Dim No_Proc As Integer = 0, CADENA As String = ""
        Try
            GENERA_MINVE_OT()
        Catch ex As Exception
            Bitacora("2520. " & ex.Message & vbNewLine & ex.StackTrace)
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
                    If dr("TIPOELE") = "P" Then
                        s = dr("CVE_ART") & vbTab '1
                        s = s & "" & vbTab '2
                        s = s & dr("DESCR") & " (" & dr("TIPOELE") & ")" & vbTab '3
                        s = s & "" & vbTab '4
                        s = s & dr("P_X_S") & vbTab '5
                        s = s & PREC & vbTab '6
                        s = s & dr("P_X_S") * PREC & vbTab '7
                        s = s & "" & vbTab '8
                        s = s & fCVE_DOC & vbTab '9
                        s = s & "" & vbTab '10
                        s = s & dr("P_X_S") & vbTab '11
                        s = s & "0" & vbTab '12
                        s = s & dr("P_X_S") * PREC & vbTab '13
                        s = s & "" & vbTab '14
                        s = s & dr("CVE_ART") & vbTab '15
                        s = s & "" & vbTab '16
                        s = s & ""  '17
                        s = s & 0  '18

                        Fg.AddItem("" & vbTab & s)
                    Else
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
                        s = s & ""  '16
                        s = s & 0  '17
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
    Sub DESPLEGAR_KARDEX()
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
                'tLUGAR_REP.Select()

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
                    BarKardex.Visible = False
                    btnAltaProducto.Visible = False
                    btnEliProd.Visible = False
            End Select
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CancPartNoEntr()
        Try
            Dim z As Integer = 0, IMPORTE As Decimal = 0

            If MsgBox("Realmente desea cancelar las cantida(des) de partida(s) no procesadas?", vbYesNo) = vbYes Then
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 5) > 0 Then

                        If (Fg(k, 5) + Fg(k, 18)) <> Fg(k, 11) Then

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE GCORDEN_TRA_SER_EXT SET CANT_ENTREGADA = " & (Fg(k, 11) - Fg(k, 5)) &
                                        " WHERE UUID = '" & Fg(k, 15) & "'"
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery.ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            z = z + 1
                                            Fg(k, 18) = (Fg(k, 11) - Fg(k, 5))

                                            Try
                                                IMPORTE = Lt1.Text.Remove(",", "")
                                            Catch ex As Exception
                                            End Try
                                            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, IMPORTE, "T", "Cancelacion partida parcial articulo:" &
                                                       Fg(k, 1) & " Cantidad:" & (Fg(k, 11) - Fg(k, 5)))
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

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub TLUGAR_REP_KeyDown(sender As Object, e As KeyEventArgs) Handles tLUGAR_REP.KeyDown
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

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If PASS_GRUPOCE = "FRAAAAAJA" Then
                If e.KeyCode = Keys.Delete Then
                    If Fg.Row > 0 Then
                        If MsgBox("Realemnet desea eliminar la partida " & Fg(Fg.Row, 1) & "?", vbYesNo) = vbYes Then
                            Try
                                SQL = "DELETE FROM GCORDEN_TRA_SER_EXT WHERE UUID = '" & Fg(Fg.Row, 15) & "'"
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            Fg.RemoveItem(Fg.Row)
                                            MsgBox("La partida se elimino satisfactoriamente")
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                Bitacora("2740. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("2740. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End If
            End If
            If Fg.Row > 0 Then
                If Fg.Col = 8 Then
                    If e.KeyCode = Keys.Delete Then
                        If MsgBox("Realmente desea eliminar al mecánico?", vbYesNo) = vbYes Then
                            Fg(Fg.Row, 8) = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnMagix_Click(sender As Object, e As EventArgs)
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
                            "0" & vbTab & "Mov. realizado" & vbTab & "" & vbTab & dr("CVE_FOLIO") & vbTab & "MINVE" & vbTab & "0")
                        Else
                            For k = 1 To Fg.Rows.Count - 1
                                If Fg(k, 1) = dr("CVE_ART") Then
                                    If Fg(k, 5) = dr("CANTI") And Fg(k, 10) <> "Cancelada" Then
                                        Fg(k, 10) = "Cancelada"
                                        Fg(k, 14) = "Cancelada"
                                        Exit For
                                    Else
                                        If Fg(k, 5) - dr("CANTI") >= 0 And Fg(k, 10) <> "Cancelada" Then
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
                    Fg(k, 11) = Math.Abs(Fg(k, 11))
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

    Private Sub BtnDesCancel_Click(sender As Object, e As EventArgs)
        Try
            Dim r_ As Row

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    If Fg(r_.Index, 10) = "Cancelada" Then
                        Try
                            SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = '' WHERE UUID = '" & Fg(r_.Index, 15) & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        Fg(r_.Index, 10) = ""
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

    Private Sub BtnSetMovRealizado_Click(sender As Object, e As EventArgs)
        Try
            Dim r_ As Row

            For k = Fg.Rows.Selected.Count - 1 To 0 Step -1
                r_ = Fg.Rows.Selected(k)

                If r_.Index > 0 Then
                    Try
                        SQL = "UPDATE GCORDEN_TRA_SER_EXT SET STATUS = 'M', HORA2 = 'MINVE' WHERE UUID = '" & Fg(r_.Index, 15) & "'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            returnValue = cmd2.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    Fg(r_.Index, 10) = "Mov. realizado"
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
    Private Sub Tab1_TabPageClosed(sender As Object, e As TabPageEventArgs) Handles Tab1.TabPageClosed
    End Sub

    Private Sub Tab1_TabIndexChanged(sender As Object, e As EventArgs) Handles Tab1.TabIndexChanged
        Select Case Tab1.SelectedIndex
            Case 0
                btnEliProd.Visible = True
                btnAltaProducto.Visible = True
            Case 1
                btnEliProd.Visible = False
                btnAltaProducto.Visible = False
            Case 2
            Case 3

        End Select
    End Sub
    Private Sub CboAlmacen_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles cboAlmacen.DropDownClosed
        Try
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 4) = cboAlmacen.Text
            Next
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
        End Try
    End Sub
    Sub PROGRAMACION_DE_SERVICIOS()
        Try
            Var16 = ""
            frmProgServShow.ShowDialog()
            If Var16.Trim.Length > 0 Then
                tCVE_PROG.Text = Var16
                LProgServ.Text = Var17
                CONTROL_DOC = "P"

                PAR_FALLA_UUID = ""

                BUSCAR_PROG_SERVICIOS()
            Else
                tCVE_PROG.Text = ""
                LProgServ.Text = ""
            End If
        Catch ex As Exception
            Bitacora("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_PROG_SERVICIOS()
        Dim s As String
        Dim Sigue As Boolean = True

        Try
            Dim CVE_ALM As String = ""

            If cboAlmacen.Visible Then
                If cboAlmacen.SelectedIndex > -1 Then
                    CVE_ALM = cboAlmacen.Text
                Else
                    CVE_ALM = cboAlmacen.Items(0).ToString
                End If
            End If

            ENTRA = False
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT P.CVE_ART, ISNULL(I.TIPO_ELE,'') AS TIPOELE, I.DESCR, I.COSTO_PROM, PS.CVE_UNI, " &
                    "U.DESCR AS DESCR_UNI, T.DESCR AS DESCR_TIPO, U.CVE_TIPO_UNI " &
                    "FROM GCPROGAMACION_SERVICIOS_PAR P " &
                    "INNER JOIN GCPROGAMACION_SERVICIOS PS ON PS.CVE_PROG = P.CVE_PROG " &
                    "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = PS.CVE_UNI " &
                    "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                    "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                    "WHERE P.CVE_PROG = '" & tCVE_PROG.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        If Sigue Then
                            Sigue = False
                            tCVE_UNI.Text = dr.ReadNullAsEmptyString("CVE_UNI")
                            L2.Text = dr.ReadNullAsEmptyString("DESCR_UNI")
                            tCVE_TIPO.Text = dr.ReadNullAsEmptyString("CVE_TIPO_UNI")
                            L4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO")
                        End If
                        If dr("TIPOELE") = "P" Then
                            s = dr.ReadNullAsEmptyString("CVE_ART") & vbTab '1
                            s = s & "" & vbTab '2
                            s = s & dr.ReadNullAsEmptyString("DESCR") & vbTab '3
                            s = s & CVE_ALM & vbTab '4
                            s = s & "1" & vbTab '5
                            s = s & dr.ReadNullAsEmptyDecimal("COSTO_PROM") & vbTab '6
                            s = s & (1 * dr.ReadNullAsEmptyDecimal("COSTO_PROM")) & vbTab '7
                            s = s & "" & vbTab '8
                            s = s & Var16 & vbTab '9
                            s = s & "" & vbTab '10
                            s = s & "1" & vbTab '11
                            s = s & "0" & vbTab '12
                            s = s & (1 * dr.ReadNullAsEmptyDecimal("COSTO_PROM")) & vbTab '13
                            s = s & "" & vbTab '14
                            s = s & dr("CVE_ART") & vbTab '15
                            s = s & "" & vbTab '16
                            s = s & ""  '17
                            s = s & 0  '18
                            Fg.AddItem("" & vbTab & s)
                        Else
                            s = dr.ReadNullAsEmptyString("CVE_ART") & vbTab '1
                            s = s & "" & vbTab '2
                            s = s & dr.ReadNullAsEmptyString("DESCR") & vbTab '3
                            s = s & CVE_ALM & vbTab '4
                            s = s & "1" & vbTab '5
                            s = s & dr.ReadNullAsEmptyDecimal("COSTO_PROM") & vbTab '6
                            s = s & (1 * dr.ReadNullAsEmptyDecimal("COSTO_PROM")) & vbTab '7
                            s = s & tCVE_PROG.Text & vbTab '8
                            s = s & "" & vbTab '9
                            s = s & "1" & vbTab '10
                            s = s & "0" & vbTab '11
                            s = s & (1 * dr.ReadNullAsEmptyDecimal("COSTO_PROM")) & vbTab '12
                            s = s & "" & vbTab '13
                            s = s & dr("CVE_ART") & vbTab '14
                            s = s & "" & vbTab '15
                            s = s & ""  '16
                            s = s & 0  '17

                            FgS.AddItem("" & vbTab & s)
                        End If
                    End While
                End Using
                '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                '                       1            2            3               4               5             6             7             8             9
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                '          10            11           12            13            14           15            16            17            18          19 
                '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov


                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 1
                _myEditor.StartEditing(Fg.Row, 1)
            End Using
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub

    Private Sub TLUGAR_REP_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tLUGAR_REP.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)
            Fg.Select()

        End If
    End Sub
    Private Sub TResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles tResponsable.KeyDown
        Try
            If e.KeyCode = 13 Then
                tNOTA.Select()
            End If
        Catch ex As Exception
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
Public Class MyEditorOTI
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

        '_owner.Cols(6).EditMask = "999,999,999.99"
        '_owner.Cols(7).EditMask = "999,999,999.99"

    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim CANT As Decimal, CANT_ENT As Decimal, Sigue As Boolean

        If frmOTIAE.tCVE_UNI.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture la unidad")
            Return
        End If
        'If frmOTIAE.tCVE_PROV.Text.Trim.Length = 0 Then
        'MessageBox.Show("Por favor capture el cliente")
        'Return
        'End If
        If frmOTIAE.tCVE_TIPO.Text.Trim.Length = 0 Then
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

        If PASS_GRUPOCE <> "FRAJA" Then
            Try
                CANT_ENT = _owner(row, 12)
                If CANT_ENT = 0 Then
                    Sigue = True
                Else
                    CANT = _owner(row, 5)
                    If CANT - CANT_ENT <= 0 Then
                        Sigue = False
                    End If
                End If

            Catch ex As Exception
                Sigue = True
            End Try
        End If

        If Sigue And (col = 1 Or col = 5) Then
            If col = 99 Then
                _owner.Col = 1
                frmOTIAE.tBotonMagico.Focus()
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
                'SendKeys.Send("{TAB}")
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
            frmOTIAE.tBotonMagico.Focus()
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
            If _col = 4 Then
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
                                            DESC1 = Val(frmOTIAE.tCVE_PROV.Tag)
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
                frmOTIAE.tBotonMagico.Focus()
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
                        Var2 = "InveP"
                        Var4 = ""
                        Var5 = PassData 'LINEA  
                        Var6 = "" 'ALTERNA
                        Var7 = "0" 'PRECIO
                        Var8 = "" 'TIPO PROD
                        Var9 = "" 'COSTO PROM
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) 'CLAVE
                            'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                            'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                            'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                            'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                            'Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                            _owner(_row, 1) = Var4
                            _owner(_row, 3) = Var5
                            '_owner(_row, 4) = Var6

                            Dim PRECIO As Single = 0
                            Try

                                PRECIO = Val(Var9)
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
                            CALCULAR_IMPORTES()
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
                frmOTIAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmOTIAE.tBotonMagico.Focus()
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
                    frmOTIAE.tBotonMagico.Focus()
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
                                frmOTIAE.tBotonMagico.Focus()
                            Else
                                '                      art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                                '                       1            2            3               4               5             6             7             8             9
                                'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                                '" " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                '          10            11           12            13            14           15            16            17            18          19 
                                '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

                                If FgEdit Then
                                    Dim CVE_ALM As String
                                    If frmOTIAE.cboAlmacen.SelectedIndex > -1 Then
                                        CVE_ALM = frmOTIAE.cboAlmacen.Text
                                    Else
                                        CVE_ALM = frmOTIAE.cboAlmacen.Items(0).ToString
                                    End If
                                    '                          art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                                    '                           1            2            3               4               5             6             7             8             9
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                                               " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    '          10            11           12            13            14           15            16            17            18          19 
                                    '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

                                    _owner.Select(row + 1, 1)
                                Else
                                    frmOTIAE.tBotonMagico.Focus()
                                    _owner.Select(row, 1)
                                End If
                            End If
                        Case 3
                            frmOTIAE.tBotonMagico.Focus()
                        Case 9
                            frmOTIAE.tBotonMagico.Focus()
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
                                frmOTIAE.tBotonMagico.Focus()
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
                        Case 5 '
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
                frmOTIAE.tBotonMagico.Focus()
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
                                    Var21 = Val(frmOTIAE.tCVE_PROV.Tag)
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
                                Cp1 = frmOTIAE.tCVE_UNI.Text
                                Cp2 = frmOTIAE.tCVE_TIPO.Text
                                Var19 = "OTI"  'ORDEN EXTERNA PARA SER VISUALIZADA DESDE COMPRAS

                                frmComprasTrans.ShowDialog(MainRibbonForm)

                                If Var17.Trim.Length > 0 And Var17.Trim <> "N" And Var11 <> "edit" Then
                                    DESC1 = 0
                                    Try
                                        DESC1 = Val(frmOTIAE.tCVE_PROV.Tag)
                                    Catch ex As Exception
                                    End Try
                                    'Var11 = tPROV.Text
                                    'Var12 = LtNombre.Text
                                    'Var22 = CAN_TOT - DES_TOT
                                    'Var17 = CVE_DOC
                                    'Var20 = NUM_ALM_OT
                                    'Var46 = cboAlmacen.Text

                                    _owner(_row, 1) = MyBase.Text   'CVE_ART
                                    _owner(_row, 3) = Var12 'NOMBRE CLIENTE
                                    _owner(_row, 19) = Var11 'CLAVE CLIENTE
                                    _owner(_row, 4) = Var46       'ALMACEN
                                    _owner(_row, 5) = "1"       'CANTIDAD
                                    _owner(_row, 6) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                    _owner(_row, 7) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                    _owner(_row, 9) = Var17 'REFER
                                    _owner(_row, 10) = ""
                                    '_owner(_row, 12) = Var22
                                    _owner.Col = 5

                                    frmOTIAE.ImprimirOrden(Var17)

                                Else
                                    frmOTIAE.tBotonMagico.Focus()
                                    _owner.Select(_row, 1)
                                End If
                                Return
                            Else

                                Dim Descr As String

                                If MyBase.Text.Trim.Length = 0 Then
                                    frmOTIAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                End If
                                Var9 = "" : Var22 = 0 : Var4 = ""
                                Descr = BUSCA_CAT("InveP", MyBase.Text)
                                If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                    MsgBox("Articulo inexistente")
                                    frmOTIAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                Else
                                    'Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                                    'Var7 = dr.ReadNullAsEmptyDecimal("P1")
                                    'Var8 = dr.ReadNullAsEmptyString("T_ELE")
                                    'Var9 = dr.ReadNullAsEmptyDecimal("C_PROM")
                                    Dim PRECIO As Single, DESC1 As Single
                                    _owner(_row, 1) = MyBase.Text
                                    _owner(_row, 3) = Descr
                                    '_owner(_row, 4) = Var6 'CLAVE ALTERNA
                                    '_owner(_row, 6) = Var7 'PRECIO 1
                                    Try
                                        DESC1 = Val(frmOTIAE.tCVE_PROV.Tag)
                                        If DESC1 = 0 Then
                                            PRECIO = Val(Var9) 'COSTO PROM
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
                                frmOTIAE.tBotonMagico.Focus()
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
                                                CALCULAR_IMPORTES()
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
                                    Dim CVE_ALM As String = ""

                                    If frmOTIAE.cboAlmacen.Visible Then
                                        If frmOTIAE.cboAlmacen.SelectedIndex > -1 Then
                                            CVE_ALM = frmOTIAE.cboAlmacen.Text
                                        Else
                                            CVE_ALM = frmOTIAE.cboAlmacen.Items(0).ToString
                                        End If
                                    End If
                                    '                          art          boton        descr          alm              cant         costo        subtot         mecani      referencia
                                    '                           1            2            3               4               5             6             7             8             9
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & CVE_ALM & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & " " & vbTab &
                                               " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    '          10            11           12            13            14           15            16            17            18          19 
                                    '      status         cant.Orgi      cant.Entr.   tipo_ele     Movs. inve    uuid          cve_prov     hora2         cance.par    prov

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
            frmOTIAE.Lt1.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class


