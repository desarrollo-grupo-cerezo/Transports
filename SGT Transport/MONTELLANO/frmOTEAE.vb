Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.ComponentModel
Imports C1.Win.C1Command

Public Class frmOTEAE
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
    Private LINEA_FILTRO_SERVICIO As String
    Private PAR_FALLA_UUID As String = ""
    Private C93501 As Boolean, C93530 As Boolean, C93560 As Boolean, C93590 As Boolean, C93620 As Boolean, C93650 As Boolean
    Private C93710 As Boolean, C93740 As Boolean, C93770 As Boolean, C93800 As Boolean, C93830 As Boolean, C93860 As Boolean
    Private U_ALMACEN As Boolean
    Private U_MANTE As Boolean
    Private NUM_ALM_OT As Integer = 1
    Private _myEditor As MyEditorOTE
    Private Sub frmOTEAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


        LkEnlazarDoc.Text = "Enlazar reporte" & vbNewLine & "de fallas"
        Try
            tCVE_ORD.MaxLength = 10
            tCVE_UNI.MaxLength = 10
            tCVE_TIPO.MaxLength = 10
            tCVE_PROV.MaxLength = 10
            tLUGAR_REP.MaxLength = 50
            tNOTA.MaxLength = 100
            SEGONE = True
            Tab1.Width = Screen.PrimaryScreen.Bounds.Width - 50
            Tab1.Height = Me.Height - Panel1.Height - C1ToolBar1.Height - 50

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 80
            Fg.Height = Tab1.Height - btnAltaProducto.Height - 100

            FgD.Width = Screen.PrimaryScreen.Bounds.Width - 80
            FgD.Height = Tab1.Height - LtFotoDoc.Top - LtFotoDoc.Height - 100

            FgD.Cols(3).Width = FgD.Width - FgD.Cols(1).Width - FgD.Cols(2).Width - FgD.Cols(0).Width - 50

            BarEliminar.Text = "Cancelar orden" & vbNewLine & "de trabajo"
            BarFinOT.Text = "Finalizar orden" & vbNewLine & "de trabajo"

            L1.Top = Fg.Top + Fg.Height + 5
            Lt1.Top = Fg.Top + Fg.Height + 5
            LtDocAnt.Top = Lt1.Top
            Label7.Top = Lt1.Top
            FgD.Rows.Count = 1

            Me.Refresh()
            ENTRA_FALLAS = False
            ENTRA = False
            LtDocAnt.Text = ""
            tEstatus.Tag = ""
            tLUGAR_REP.Tag = "1"
            VarFORM2 = ""
            Dim NewStyle1 As CellStyle
            NewStyle1 = Fg.Styles.Add("NewStyle1")
            NewStyle1.WordWrap = True

            Fg.Cols(2).Width = 20
            Fg.Cols(9).Width = 90
            Fg.Rows(0).Height = 40

            Me.WindowState = FormWindowState.Maximized
            'Me.KeyPreview = True
            If PASS_GRUPOCE = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & " " & Fg(0, k)
                Next
            End If
        Catch ex As Exception
        End Try

        If Not Valida_Conexion() Then
            Return
        End If

        DERECHOS()

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT ISNULL(RUTA_DOC,'') AS RUTA FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

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
            'Fg.Cols(12).Visible = False
            'Fg.Cols(13).Visible = False
            'Fg.Cols(14).Visible = False
            'Fg.Cols(15).Visible = False
            'Fg.Cols(16).Visible = False
            'Fg.Cols(17).Visible = False
        Else
            'Fg.Cols(6).Visible = True
            'Fg.Cols(7).Visible = True
            Fg.Cols(12).Visible = False
            Fg.Cols(13).Visible = False
            Fg.Cols(14).Visible = False
            Fg.Cols(15).Visible = False
            Fg.Cols(16).Visible = False
            Fg.Cols(17).Visible = False
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
        Catch ex As Exception
        End Try

        DOC_NEW = False
        FgEdit = False
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
                FgEdit = True

                Fg.Rows.Count = 1 '      1             2           3           4             5             6             7             8             9 
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & " " & vbTab &
                   "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "N")
                '  10            11           12           13            14            15            16           17            18            19            20  
            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

                SQL = "SELECT O.CVE_ORD, O.ESTATUS, O.FECHA, O.CVE_SER, ISNULL(O.TIPO_SERVICIO,0) AS TIPO_SER, ISNULL(O.TIPO_EXTRA, 0) AS T_EXTRA, O.CVE_UNI, " &
                    "O.CVE_TIPO, O.CVE_OPER, O.CVE_PROV, O.FACTURA, O.VIDA_REP_ANO, O.VIDA_REP_KM, O.LUGAR_REP, O.NOTA, O.CVE_OBS, OB.DESCR AS OBS_STR, " &
                    "ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(DOC_ANTR,'') AS DOCANTR, ISNULL(CVE_PROG,'') AS C_PROG, RESPONSABLE " &
                    "FROM GCORDEN_TRABAJO_EXT O " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = O.CVE_OBS " &
                    "WHERE CVE_ORD = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    Try
                        tCVE_ORD.Text = dr("CVE_ORD").ToString
                        tCVE_ORD.Tag = dr("DOCANT").ToString

                        tEstatus.Tag = dr("DOCANTR").ToString

                        F1.Value = dr("FECHA").ToString
                        Select Case dr("TIPO_SER")
                            Case 0
                                RadPreventivo.Checked = True
                            Case 1
                                RadCorrectivo.Checked = True
                            Case 2
                                radExtra.Checked = True
                            Case 3
                                radSinistro.Checked = True
                            Case 4
                                RadRescateCarr.Checked = True
                            Case 5
                                RadLLantas.Checked = True
                            Case Else
                                RadPreventivo.Checked = True
                        End Select
                        tCVE_UNI.Text = dr("CVE_UNI").ToString

                        L2.Text = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                        'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                        'Var5 = dr.ReadNullAsEmptyString("TIPO_UNI").ToString
                        'Var6 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString
                        'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                        'Var8 = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI").ToString

                        tCVE_TIPO.Text = Var5                   'dr("CVE_TIPO").ToString
                        L4.Text = Var8                          'L4.Text = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)

                        tEstatus.Text = dr("ESTATUS").ToString

                        Var6 = "0"
                        tCVE_PROV.Text = dr("CVE_PROV").ToString
                        'L3.Text = BUSCA_CAT("ClieOT", tCVE_PROV.Text)
                        L3.Text = BUSCA_CAT("Cliente", tCVE_PROV.Text)
                        'Var6 = dr("LIB5")
                        'Var7 = dr("LIB6")
                        tCVE_PROV.Tag = "0"
                        L3.Tag = "0"

                        tFACTURA.Text = dr.ReadNullAsEmptyString("FACTURA").ToString
                        tLUGAR_REP.Text = dr("LUGAR_REP").ToString
                        tNOTA.Text = dr("NOTA").ToString

                        tOBSER.Text = dr("OBS_STR").ToString
                        tOBSER.Tag = dr("CVE_OBS").ToString
                        tCVE_PROG.Text = dr("C_PROG")
                        If tEstatus.Text = "FINALIZADO" Or tEstatus.Text = "AUTORIZADA" Then
                            Panel1.Enabled = False
                            Panel2.Enabled = False
                            If tEstatus.Tag.ToString.Length > 0 Then
                                tEstatus.Text = "REMISIONADA"
                                LtRem.Visible = True
                                LtRem.Text = tEstatus.Tag
                            End If
                        End If

                        tResponsable.Text = dr.ReadNullAsEmptyString("RESPONSABLE")

                        CARGAR_PRODUCTOS()
                        DOC_FOTOS(tCVE_ORD.Text)
                    Catch ex As Exception
                        Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                End If
                dr.Close()

                BarRemisionar.Enabled = False
                If Var3 = "Cancelada" Then
                    BarGrabar.Enabled = False
                    BarEnlazarDoc.Enabled = False
                    Fg.Enabled = False
                    FgD.Enabled = False
                    BarEliminar.Enabled = False
                    BarReimpresion.Enabled = False
                    tEstatus.Text = Var3
                    BarFinOT.Enabled = False
                    btnEliProd.Enabled = False
                    btnAltaProducto.Enabled = False
                    btnFotDocA.Enabled = False
                    btnFotDocE.Enabled = False
                Else
                    If tEstatus.Tag.ToString.Length > 0 Then
                        'dr("DOCANTR").ToString      ESTA REMISIONADA
                        BarGrabar.Enabled = False
                        BarEnlazarDoc.Enabled = False
                        BarFinOT.Enabled = False
                        BarRemisionar.Enabled = False
                        BarEliminar.Enabled = False
                        btnEliProd.Enabled = False
                        btnAltaProducto.Enabled = False
                        btnFotDocA.Enabled = False
                        btnFotDocE.Enabled = False
                    Else
                        If tEstatus.Text = "FINALIZADO" Or tEstatus.Text = "AUTORIZADA" Then
                            BarGrabar.Enabled = False
                            BarEnlazarDoc.Enabled = False
                            btnAltaProducto.Enabled = False
                            BarFinOT.Enabled = False
                            BarRemisionar.Enabled = True
                            btnEliProd.Enabled = False
                            btnFotDocA.Enabled = False
                            btnFotDocE.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Try
            If tEstatus.Text = "FINALIZADO" Or tEstatus.Text = "Cancelado" Or tEstatus.Text = "REMISIONADA" Or tEstatus.Text = "AUTORIZADA" Then
                ACCESO_USUARIO = False
            Else
                Try
                    If BarGrabar.Enabled Then
                        ACCESO_USUARIO = True
                    Else
                        ACCESO_USUARIO = False
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            Bitacora("42. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            ENTRA = True
            ENTRA_FALLAS = True

            If ACCESO_USUARIO Then
                _myEditor = New MyEditorOTE(Fg, MULTIALMACEN)
                If DOC_NEW = True Then
                    tCVE_UNI.Select()
                Else
                    tLUGAR_REP.Focus()
                End If
            Else
                btnAltaProducto.Enabled = False
                btnEliProd.Enabled = False
                Panel1.Enabled = False
                Panel2.Enabled = False
                Fg.AllowEditing = False
            End If
        Catch ex As Exception
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
                    TabProductos.Enabled = False
                    TabDocDigitales.Enabled = False
                    TabObser.Enabled = False
                    btnAltaProducto.Enabled = False
                    btnEliProd.Enabled = False

                    'SI TIENE  DERECHOS GRABAR
                    SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 93500 AND CLAVE < 94000"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                Select Case dr("CLAVE")
                                    Case 93700  'GRABAR
                                        BarGrabar.Enabled = True
                                    Case 93710  'ENLAZAR COTIZACION
                                        BarEnlazarDoc.Enabled = True
                                    Case 93720  'FINALIZAR ORDEN DE TRABAJO
                                        BarFinOT.Enabled = True
                                    Case 93730  'REMISIONAR
                                        BarRemisionar.Enabled = True
                                    Case 93740  'CANCELAR ORDER DE TRABAJO
                                        BarEliminar.Enabled = True
                                    Case 93750  'REIMPRESION
                                        BarReimpresion.Enabled = True
                                    Case 93780  'PESTAÑA PRODUCTOS AQUI SERVICIOS
                                        TabProductos.Enabled = True
                                    Case 93790  'PESTAÑA DOCUMENTOS DIGITALES
                                        TabDocDigitales.Enabled = True
                                    Case 93800  'PESTAÑA OBSERVACIONES
                                        TabObser.Enabled = True
                                    Case 93830  'ALTA PARTIDAS PRODUCTOS
                                        btnAltaProducto.Enabled = True
                                    Case 93840  'ELIMINRA PARTIDA PRODUCTOS
                                        btnEliProd.Enabled = True
                                End Select
                                z = z + 1
                            End While
                        End Using
                    End Using
                    If z = 0 Then
                        If USER_GRUPOCE.IndexOf("ALMACEN") > -1 Then
                            BarGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            'barFinOT.Enabled = True
                            BarRemisionar.Enabled = True
                            BarEliminar.Enabled = True
                            BarReimpresion.Enabled = True
                            TabProductos.Enabled = True
                            TabDocDigitales.Enabled = True
                            TabObser.Enabled = True
                            btnAltaProducto.Enabled = True
                            btnEliProd.Enabled = True
                        End If
                        If USER_GRUPOCE.IndexOf("MANTE") > -1 Then
                            BarGrabar.Enabled = True
                            BarEnlazarDoc.Enabled = True
                            BarFinOT.Enabled = True
                            BarEliminar.Enabled = True
                            'BarRemisionar.Enabled = True
                            'barCancelarOT.Enabled = True
                            BarReimpresion.Enabled = True
                            'BarCancPartNoEntr.Enabled = True
                            TabProductos.Enabled = True
                            TabDocDigitales.Enabled = True
                            TabObser.Enabled = True
                            btnAltaProducto.Enabled = True
                            'btnEliProd.Enabled = True
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("43. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("43. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("44. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("44. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Grabar"
                    Try
                        If Not Valida_Conexion() Then
                            Return
                        End If
                        VarFORM2 = ""
                        GUARDAR("S")
                    Catch ex As Exception
                    End Try
                Case "Enlazar reporte"
                    ENLAZAR_REPORTE_DE_FALLAS()
                Case "Finalizar orden de trabajo"
                    'FINALIZAR_OT()
                Case "Remisionar"
                    GRABAR_VENTA(tCVE_ORD.Text)
                Case "Kardex"
                    Show_Kardex()
                Case "Cancelar orden de trabajo", "Cancelar orden" & vbCrLf & "de trabajo"
                    CANCELAR_OT()
                Case "Reimpresión"
                    ImprimirOrden(tCVE_ORD.Text)
                Case "Excel"
                    Try
                        EXPORTAR_EXCEL_TRANSPORT(Fg, "ORDEN DE TRABAJO" & tCVE_ORD.Text)
                    Catch ex As Exception
                    End Try
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmOTEAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            If VarFORM2 = "NoSalirDelForm" Then
            Else
                CloseTab("Orden de Trabajo Externa")
                Me.Dispose()
                If FORM_IS_OPEN("frmOTE") Then
                    frmOTE.DESPLEGAR()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmOTEAE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If VarFORM2.Trim.Length > 0 Then
            Try
                Dim nPar As Integer = 0, nTOT As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Trim.Length > 0 And CONVERTIR_TO_DECIMAL(Fg(k, 5).ToString) > 0 Then
                        '                        (k,8)  CVE_DOC - ORDEN DE COMPRA
                        If Fg(k, 1) = "TOT" And Fg(k, 8).ToString.Trim.Length > 0 And Fg(k, 20).ToString.Trim = "S" Then
                            nTOT = nTOT + 1
                        Else
                            If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 1) <> "TOT" Then
                                nPar = nPar + 1
                            End If
                        End If
                    End If
                Next
                If nTOT > 0 Or nPar > 0 Then
                    If MsgBox("Existen partidas " & IIf(nTOT > 0, "y TOT", "") & " en la orden de trabajo externa, Realmente desea abandonar la captura?", vbYesNo) = vbYes Then
                        If nTOT > 0 Then
                            If MsgBox("La ORDEN DE TRABAJO sera cancelada, Realmente desea salir?", vbYesNo) = vbYes Then
                                CANCELAR_TOT()
                                VarFORM2 = ""
                            Else
                                e.Cancel = True
                                VarFORM2 = "NoSalirDelForm"
                            End If
                        End If
                    Else
                        e.Cancel = True
                        VarFORM2 = ""
                    End If
                Else
                    VarFORM2 = ""
                End If
            Catch ex As Exception
                Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CANCELAR_TOT()
        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length > 0 Then
                    '                          REFER de la OEDEN DE COMPRA 
                    If Fg(k, 1) = "TOT" And Fg(k, 8).ToString.Trim.Length > 0 Then
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE COMPO" & Empresa & " SET STATUS = 'C' WHERE CVE_DOC = '" & Fg(k, 8) & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
        Catch ex As Exception
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(CVE_CPTO_OT,0) AS CVE_CPTOOT, " &
                "ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOT_SAL, CVE_ART_TOT " &
                "FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            LINEA_FILTRO_SERVICIO = ""
            CVE_CPTO_OT = 0
            CVE_CPTO_OT_SAL = 0
            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                CVE_CPTO_OT = dr("CVE_CPTOOT")
                CVE_CPTO_OT_SAL = dr("CVE_CPTOOT_SAL")
                LINEA_FILTRO_SERVICIO = dr.ReadNullAsEmptyString("CVE_ART_TOT")
            End If
            dr.Close()
            PassData = LINEA_FILTRO_SERVICIO

            cmd.Connection = cnSAE
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(SERIE_REMISION_EXT, '') AS SERIE_REM " &
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
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub DOC_FOTOS(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'M' AND CVE_FOTDOC = 0"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgD.Rows.Count = 1
            Do While dr.Read
                FgD.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & RUTA_DOC)
            Loop
            dr.Close()
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CARGAR_PRODUCTOS()
        If Not Valida_Conexion() Then
        End If
        If Not Valida_Conexion() Then
        End If
        If Not Valida_Conexion() Then
            Me.Close()
        End If

        Dim HayError As Boolean = False, HayDatos As Boolean = False
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim DESCR As String, COSTO As Decimal = 0, DESC1 As Single = 0, SUBTOTAL As Decimal = 0, CAD_OBS As String = 0, CANT As Single = 0

            cmd.Connection = cnSAE

            DESC1 = Val(tCVE_PROV.Tag)
            ENTRA = False
            Fg.Rows.Count = 1

            SQL = "SELECT CVE_ORD, ISNULL(O.CVE_ART,'') AS CLAVE, ISNULL(I.DESCR,'') AS DES, ISNULL(O.CANT,0) AS CANTI, ISNULL(IMPORTE,0) AS IMPORT, " &
                "ISNULL((SELECT SUM(CANT * SIGNO) FROM MINVE" & Empresa &
                " WHERE REFER LIKE 'OT" & tCVE_ORD.Text & "%' AND CVE_ART = O.CVE_ART AND CVE_FOLIO = O.CVE_PROV),0) AS CANT_ENT, " &
                "ISNULL(O.COSTO,0) AS COST, ISNULL(O.NO_PARTE,'') AS N_PARTE, TIPO_ELE, ISNULL(HORA2,'') AS MINVE, ISNULL(CVE_PROV,'') AS C_PROV, " &
                "ISNULL(TIEMPO_REAL, '') AS REFER, ISNULL(TIPO,0) AS TIPO_I, ISNULL(O.STATUS, '-') AS ST, ISNULL(O.UUID,'') AS UID, " &
                "ISNULL(CANT_ENTREGADA,0) AS CANT_ENTR, CVE_ALM " &
                "FROM GCORDEN_TRA_SER_EXT O " &
                "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = O.CVE_ART " &
                "WHERE CVE_ORD = '" & tCVE_ORD.Text & "' ORDER BY FECHAELAB"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                Do While dr.Read

                    If Not Valida_Conexion() Then
                    End If
                    If Not Valida_Conexion() Then
                    End If

                    DESCR = dr("DES")
                    If DESCR.Trim.Length = 0 Then
                        DESCR = BUSCA_CAT("InveS", dr("CLAVE"))
                    End If
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
                    If Math.Abs(dr("CANT_ENT")) + Math.Abs(dr("CANT_ENTR")) = 0 Then
                        CANT = dr("CANTI")
                    Else
                        CANT = Math.Abs(dr("CANT_ENT"))
                    End If

                    Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & CANT & vbTab & COSTO & vbTab &
                        SUBTOTAL & vbTab & dr("REFER") & vbTab & CAD_OBS & vbTab & dr("CANTI") & vbTab & (Math.Abs(dr("CANT_ENT")) + Math.Abs(dr("CANT_ENTR"))) & vbTab &
                        dr("IMPORT") & vbTab & CAD_OBS & vbTab & dr("UID") & vbTab & dr("C_PROV") & vbTab & dr("MINVE") & vbTab & dr("CANT_ENTR") & vbTab &
                        "" & vbTab & "" & vbTab & "N")
                    HayDatos = True
                Loop
                If tEstatus.Text <> "FINALIZADO" And tEstatus.Text <> "Cancelado" Or tEstatus.Text = "AUTORIZADA" Then
                    '                        1             2           3           4             5             6             7             8   
                    'Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                    '       " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0)
                    '           9            10            11           12            13            14           15            16            17
                End If

                SUM_IMPORTES("P")
            Else
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "-" & vbTab & "-" & vbTab & "0" & vbTab &
                        "" & vbTab & "" & vbTab & "N")
            End If
            dr.Close()
            Me.Refresh()
            ENTRA = True

        Catch ex As Exception
            HayError = True
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If HayError And HayDatos Then
            Me.Close()
        End If
    End Sub
    Sub SUM_IMPORTES(fTIPO As String)
        Try
            ENTRA = False
            Dim SUMA As Decimal = 0, SUBTOTAL As Decimal = 0, COSTO As Decimal = 0, DESC1 As Decimal
            DESC1 = Val(tCVE_PROV.Tag)
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

            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
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
                       " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab &
                       "" & vbTab & "" & vbTab & "N")
            Fg.Rows(Fg.Rows.Count - 1).Height = 30
            ENTRA = True

        Catch ex As Exception
            MsgBox("290. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ENLAZAR_REPORTE_DE_FALLAS()
        Try
            Var4 = ""
            PAR_FALLA_UUID = ""
            frmEnlaceReporteFallas.ShowDialog()
            If Var4.Length > 0 Then
                PAR_FALLA_UUID = Var4
                SQL = "SELECT P.CVE_FALLA, F.FECHA, P.CVE_UNI, C.DESCR, P.DESCR_FALLA, U.CVE_TIPO_UNI, T.DESCR AS DESCR_TIPO_UNI " &
                     "FROM GCREPORTE_FALLAS_PAR P " &
                     "INNER JOIN GCREPORTE_FALLAS F ON F.CVE_FALLA = P.CVE_FALLA " &
                     "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                     "LEFT join GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                     "LEFT JOIN GCCLASIFIC_SERVICIOS C ON C.CVE_CLA = P.CVE_CLAS " &
                     "WHERE P.UUID = '" & Var4 & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            tCVE_UNI.Text = dr("CVE_UNI")
                            L2.Text = tCVE_UNI.Text
                            tCVE_TIPO.Text = dr.ReadNullAsEmptyString("CVE_TIPO_UNI")
                            L4.Text = dr.ReadNullAsEmptyString("DESCR_TIPO_UNI")
                            tOBSER.Text = dr.ReadNullAsEmptyString("DESCR_FALLA")
                            'tCVE_PROV.Select()
                            tFACTURA.Select()
                        End If
                    End Using
                End Using

            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GUARDAR(fMENSAJES As String)
        Dim CVE_OBS As Long, TIPO_SERVICIO As Integer, SUM_IMPORTE As Decimal = 0
        Dim CVE_ORD As String = ""
        Dim z As Integer = 0

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE


        Try
            If Fg.Rows.Count = 1 Then
                z = 0
            Else
                For k = 1 To Fg.Rows.Count - 1
                    If Fg.Rows(k).IsVisible Then
                        If Not IsNothing(Fg(k, 1)) And Not IsNothing(Fg(k, 3)) Then
                            If Fg(k, 1).ToString.Trim.Length > 0 And Fg(k, 3).ToString.Trim.Length > 0 Then
                                z += 1
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("310. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'If z = 0 Then
        'MsgBox("No existen partidas por favor agregue al menos una partida")
        'Return
        'End If
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
            'MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            TIPO_SERVICIO = -1
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
            If TIPO_SERVICIO = -1 Then
                MsgBox("POr favor seleccione el tipo de servicio")
                Return
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
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
        Catch ex As Exception
            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCORDEN_TRABAJO_EXT SET CVE_ORD = @CVE_ORD, CVE_PROG = @CVE_PROG, ESTATUS = @ESTATUS, FECHA = @FECHA, TIPO_SERVICIO = @TIPO_SERVICIO,
            TIPO_EXTRA = @TIPO_EXTRA, CVE_UNI = @CVE_UNI, CVE_TIPO = @CVE_TIPO, CVE_PROV = @CVE_PROV, LUGAR_REP = @LUGAR_REP, NOTA = @NOTA,
            FACTURA = @FACTURA, RESPONSABLE = @RESPONSABLE
            WHERE CVE_ORD = @CVE_ORD
            IF @@ROWCOUNT = 0
            INSERT INTO GCORDEN_TRABAJO_EXT (CVE_ORD, STATUS, FECHA, FECHAELAB, TIPO_SERVICIO, TIPO_EXTRA, CVE_UNI, CVE_TIPO, ESTATUS, CVE_PROV, FACTURA,
            LUGAR_REP, NOTA, CVE_OBS, CVE_PROG, DOC_SIG, A_M, RESPONSABLE) VALUES (@CVE_ORD, 'A', @FECHA, GETDATE(), @TIPO_SERVICIO, @TIPO_EXTRA, @CVE_UNI,
            @CVE_TIPO, @ESTATUS, @CVE_PROV, @FACTURA, @LUGAR_REP, @NOTA, @CVE_OBS, @CVE_PROG, @DOC_SIG, 'M', @RESPONSABLE)"
        cmd.CommandText = SQL
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
            cmd.Parameters.Add("@CVE_PROG", SqlDbType.VarChar).Value = tCVE_PROG.Text
            cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = LtDocAnt.Text
            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = tFACTURA.Text
            cmd.Parameters.Add("@RESPONSABLE", SqlDbType.VarChar).Value = tResponsable.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
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
                        MsgBox("350. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("350. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If tCVE_PROG.Text.Trim.Length > 0 Then
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCPROGAMACION_SERVICIOS SET CVE_ORD = '" & tCVE_ORD.Text & "', FECHA_INI_SER = GETDATE() WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue = "1" Then
                                End If
                            End Using
                        End If
                    Catch ex As Exception
                        MsgBox("360. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    GRABAR_PRODUCTOS()

                    If ERROR_PAR Then
                        ERROR_PAR = False
                        MsgBox("Se detecto un problema al grabar las partidas por favor intentelo nuevamente")
                    Else
                        GRABA_FOTOS_DOC()

                        Try
                            SUM_IMPORTE = CDec(Lt1.Text.Replace(",", ""))
                        Catch ex As Exception
                            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
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
                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva orden de trabajo externa " &
                                       " Enlazado desde la cotizacion " & LtDocAnt.Text, "Se modifico orden de trabajo externa "))
                            Catch ex As Exception
                                MsgBox("390. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("390. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Else
                            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, SUM_IMPORTE, "T", IIf(DOC_NEW, "Nueva", "Se modifico") & " orden de trabajo externa ")
                        End If
                        If fMENSAJES = "S" Then
                            MsgBox("El registro se grabo satisfactoriamente")
                        End If

                        Try
                            ImprimirOrden(tCVE_ORD.Text)
                            Threading.Thread.Sleep(3000)
                            Me.Close()
                        Catch ex As Exception
                        End Try
                    End If
                Else
                    If fMENSAJES = "S" Then
                        MsgBox("No se logro grabar la orden de trabajo por favor intentelo nuevamente")
                    End If
                End If
            Else
                If fMENSAJES = "S" Then
                    MsgBox("No se logro grabar el registro")
                End If
            End If
        Catch ex As Exception
            MsgBox("395. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("395. " & ex.Message & vbNewLine & ex.StackTrace)
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
                If IsNumeric(Lt1.Text.Replace(",", "")) Then
                    SUMA_IMPORTE = SUMA_IMPORTE + Lt1.Text.Replace(",", "")
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
            MsgBox("400. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("400. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PRODUCTOS()
        Try
            Dim STATUS As String = "", UUID As String
            Dim CVE_ART As String, CANT As Single, CVE_ALM As Integer = 1
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE
            If Not Valida_Conexion() Then
                Return
            End If

            Try
                If Fg.Col > 1 Then
                    Fg.Select()
                    SendKeys.Send("{ENTER}")
                End If

                If IsNumeric(tLUGAR_REP.Tag) Then
                    CVE_ALM = tLUGAR_REP.Tag
                Else
                    CVE_ALM = 1
                End If
            Catch ex As Exception
                Bitacora("420. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            ERROR_PAR = False

            For k = 1 To Fg.Rows.Count - 1
                CVE_ART = "" : CANT = 0
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        CVE_ART = Fg(k, 1).ToString
                    Else
                        CVE_ART = 0
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                    Bitacora("422. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                Try
                    If Not IsNothing(Fg(k, 5)) Then
                        CANT = CONVERTIR_TO_DECIMAL(Fg(k, 5).ToString)
                    Else
                        CANT = 0
                    End If
                Catch ex As Exception
                    CANT = 0
                    Bitacora("424. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                If CVE_ART.Trim.Length > 0 And CANT > 0 Then

                    Select Case Fg(k, 9)
                        Case "Mov. realizado"
                            STATUS = "M"
                        Case "Cancelada"
                            STATUS = "C"
                        Case Else
                            STATUS = ""
                    End Select
                    If Not Valida_Conexion() Then
                    End If
                    If Valida_Conexion() Then
                        UUID = ""
                        Try
                            UUID = Fg(k, 14).ToString
                        Catch ex As Exception
                        End Try
                        If UUID.Trim.Length = 0 Then
                            UUID = Fg(k, 1) & Now.ToString
                        End If
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE GCORDEN_TRA_SER_EXT SET CVE_ART = @CVE_ART, TIPO = @TIPO, DESCR = @DESCR, STATUS = @STATUS, CANT = @CANT, COSTO = @COSTO, " &
                                    "NO_PARTE = @NO_PARTE, IMPORTE = @IMPORTE, HORA2 = @HORA2, TIEMPO_REAL = @TIEMPO_REAL, CANT_ENTREGADA = @CANT_ENTREGADA, CVE_PROV = @CVE_PROV " &
                                    "WHERE UUID = @UUID " &
                                    "IF @@ROWCOUNT = 0 " &
                                    "INSERT INTO GCORDEN_TRA_SER_EXT (CVE_ORD, TIPO_PROD, CVE_ART, CANT, COSTO, IMPORTE, NO_PARTE, DESCR, TIEMPO_REAL, STATUS, TIPO, " &
                                     "CVE_PROV, HORA2, CANT_ENTREGADA, CVE_ALM, FECHAELAB, UUID) VALUES (@CVE_ORD, 'S', @CVE_ART, @CANT, @COSTO, @IMPORTE, @NO_PARTE, @DESCR, " &
                                     "@TIEMPO_REAL, @STATUS, @TIPO, @CVE_PROV, @HORA2, @CANT_ENTREGADA, @CVE_ALM, GETDATE(), NEWID())"
                                cmd2.CommandText = SQL
                                Try
                                    cmd2.Parameters.Clear()
                                    cmd2.Parameters.Add("@CVE_ORD", SqlDbType.VarChar).Value = tCVE_ORD.Text
                                    cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = Fg(k, 1).ToString
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = Fg(k, 3).ToString
                                    cmd2.Parameters.Add("@NO_PARTE", SqlDbType.VarChar).Value = Fg(k, 4).ToString
                                    cmd2.Parameters.Add("@CANT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 5).ToString)
                                    cmd2.Parameters.Add("@COSTO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(Fg(k, 6).ToString), 4)
                                    cmd2.Parameters.Add("@IMPORTE", SqlDbType.VarChar).Value = Math.Round(Val(Fg(k, 12)), 4)
                                    cmd2.Parameters.Add("@TIEMPO_REAL", SqlDbType.VarChar).Value = Fg(k, 8).ToString
                                    cmd2.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS
                                    cmd2.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = 0
                                    cmd2.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = Fg(k, 15).ToString
                                    cmd2.Parameters.Add("@HORA2", SqlDbType.VarChar).Value = Fg(k, 16).ToString
                                    cmd2.Parameters.Add("@CANT_ENTREGADA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 17))
                                    cmd2.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                                    cmd2.Parameters.Add("@CVE_ALM", SqlDbType.SmallInt).Value = CVE_ALM
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            Try
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "UPDATE PAR_FACTC" & Empresa & " SET PXS = PXS - " & CONVERTIR_TO_DECIMAL(Fg(k, 5).ToString) &
                                                        " WHERE CVE_DOC = '" & LtDocAnt.Text & "' AND CVE_ART = '" & Fg(k, 1).ToString & "'"
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue = "1" Then
                                                    End If
                                                End Using

                                                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, Math.Round(CDec(Fg(k, 12)), 4), "P", "Partida orden de trabajo externa ", Fg(k, 8).ToString)

                                            Catch ex As Exception
                                                Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End If
                                Catch ex As Exception
                                    MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
                                    Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
                                    ERROR_PAR = True
                                End Try
                            End Using
                        Catch ex As Exception
                            MsgBox("432. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("432. " & ex.Message & vbNewLine & ex.StackTrace)
                            ERROR_PAR = True
                        End Try
                    End If
                Else
                    If Fg(k, 1) = "TOT" And Fg(k, 8).ToString.Trim.Length > 0 And Fg(k, 20) = "C" Then
                        Try
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE COMPO" & Empresa & " SET STATUS = 'C' WHERE CVE_DOC = '" & Fg(k, 8) & "'"
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("435. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("435. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
            ENTRA = True
        Catch ex As Exception
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABA_FOTOS_DOC()
        Dim DESCR As String, DOC As String, Ruta As String
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE
        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_ORD.Text & "' AND TIPO_DOC = 'M' AND ISNULL(CVE_FOTDOC,0) = 0"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
        Catch ex As Exception
        End Try
        For k = 1 To FgD.Rows.Count - 1
            Try
                DESCR = FgD(k, 1)
                DOC = FgD(k, 2).ToString
                Ruta = FgD(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_ORD.Text & "','0','" & DESCR & "','" & DOC & "','M')"

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
                MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Private Sub barFinOT_Click(sender As Object, e As EventArgs) Handles BarFinOT.Click

        'FINALZIAR ODEN DE TRABAJO

        If MsgBox("¿Realmente desea Autorizar la orden de trabajo externa?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'AUTORIZADA' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
                GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Finalizacion orden de trabajo externa ")
            End Using
            tEstatus.Text = "AUTORIZADA"

            MsgBox("La Orden de Trabajo externa se finalizo satisfactoriamente")

            Try
                BarRemisionar.Enabled = True
                Fg.Enabled = False : FgD.Enabled = False
                BarFinOT.Enabled = False : BarEliminar.Enabled = False : btnEliProd.Enabled = False : btnAltaProducto.Enabled = False : F1.Enabled = False
                radCorrectivo.Enabled = False : radExtra.Enabled = False : radPreventivo.Enabled = False : tCVE_UNI.Enabled = False : tCVE_TIPO.Enabled = False
                tEstatus.Enabled = False : tCVE_PROV.Enabled = False : tLUGAR_REP.Enabled = False : tNOTA.Enabled = False : tOBSER.Enabled = False : BtnServProg.Enabled = False
                radSinistro.Enabled = False : RadRescateCarr.Enabled = False : RadLLantas.Enabled = False : BarEnlazarDoc.Enabled = False
                btnProv.Enabled = False : btnUnidades.Enabled = False : BarGrabar.Enabled = False : tDescrFotDoc.Enabled = False
                btnFotDocA.Enabled = False : btnFotDocE.Enabled = False : btnBuscaDoc.Enabled = False : tCVE_ORD.Enabled = False : tOBSER.Enabled = False
            Catch ex As Exception
            End Try
            Try
                frmOTE.Fg(Fg.Row, 2) = "AUTORIZADA"
            Catch ex As Exception
            End Try

            'FINALZIAR ODEN DE TRABAJO
        Catch ex As Exception
            Bitacora("490. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub MARCAR_OT_COMO_REMISIONADA()
        Try
            SQL = "UPDATE GCORDEN_TRABAJO_EXT SET DOC_ANTR = 'NR' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Try
                            'SQL = "UPDATE GCORDEN_TRA_SER_EXT SET COSTO = 10  WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                            'Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            'cmd2.CommandText = SQL
                            'returnValue = cmd2.ExecuteNonQuery().ToString
                            'If returnValue IsNot Nothing Then
                            'If returnValue = "1" Then
                            'MsgBox("La orden no se remisiono porque solo cuenta con servicios pero sera marcada como REMISIONADA, proceso terminado")
                            'End If
                            'End If
                            'End Using
                        Catch ex As Exception
                            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        MsgBox("La orden no se remisiono porque solo cuenta con servicios pero sera marcada como REMISIONADA, proceso terminado")
                    End If
                End If
            End Using
            GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, CONVERTIR_TO_DECIMAL(Lt1.Text), "O", " Se remisiono la orden de trabajo pero no se genero la remision porque solo cuenta con servicios")
            Me.Close()
        Catch ex As Exception
            Bitacora("535. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("535. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRemisionar_Click(sender As Object, e As EventArgs) Handles BarRemisionar.Click
        GRABAR_VENTA(tCVE_ORD.Text)
    End Sub
    Private Sub GRABAR_VENTA(fCVE_OT As String)
        If Not Valida_Conexion() Then
            Return
        End If
        If Not Valida_Conexion_SAROCE() Then
            MsgBox("Imposible conectarse a la base de configuración")
            Return
        End If
        Dim z As Integer = 0

        For k = 1 To Fg.Rows.Count - 1
            If Fg(k, 1) = "TOT" Then
                z = z + 1
            End If
        Next
        If z = 0 Then
            'MARCAR QUE YA FUE REMISIONADO Y NO SE AGREGAR LA REMISION EN
            MARCAR_OT_COMO_REMISIONADA()
        Else
            GRABAR_REM(fCVE_OT)
        End If
    End Sub
    Sub GRABAR_REM(fCVE_OT As String)
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


        If tEstatus.Text = "Cancelada" Then
            MsgBox("La orden de trabajo externa actualmente se enuentra cancelada, no es posible remisionarla")
            Return
        End If

        If MsgBox("Realmente desea generar la remision de la orden de trabajo externa?", vbYesNo) = vbNo Then
            Return
        End If
        VentaGen = ""
        Select Case TIPO_VENTA
            Case "P"
                VentaGen = " el Pedido"
            Case "C"
                VentaGen = "la Cotización"
            Case "R"
                VentaGen = "la Remisión"
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
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "S" : POLIT_APLI = "" : TIP_DOC_ANT = "" : DOC_ANT = ""
        METODODEPAGO = "" : STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N" : TIPO_DOC = TIPO_VENTA
        FECHA_DOC = ""

        Try
            PROCESAR_TABLA_OT()
            If Var23 = 0 Then
                MessageBox.Show("No se encontraron partidas a remisionar en la orden de tabajo")
                Return
            End If
        Catch ex As Exception
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
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
            cmd.CommandTimeout = 120

            SQL = "SELECT ISNULL(RFC,'') AS RFC_ FROM CLIE" & Empresa & " WHERE CLAVE  = '" & tCVE_PROV.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RFC = dr("RFC_")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        If PASS_GRUPOCE = "WINAS" Or PASS_GRUPOCE = "MAYAYI" Then
            If MsgBox(CVE_DOC, vbYesNo) = vbNo Then
                Return
            End If
        End If

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

        cmdOT.Connection = cnSAE
        cmdOT.CommandTimeout = 120

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
                        SQL = "SELECT TIPO_ELE, ULT_COSTO, COSTO_PROM, CVE_ESQIMPU, UNI_MED, DESCR, ISNULL(PRECIO,0) AS P1 " &
                        "FROM INVE" & Empresa & " I " &
                        "LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1 " &
                        "WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULT_COSTO")
                                COSTO_PROM = dr("COSTO_PROM")
                                CVE_ESQIMPU = dr("CVE_ESQIMPU")
                                DESCR = dr("DESCR")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNI_MED")
                                TIPO_PROD = dr("TIPO_ELE")
                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("640. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("640. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("660. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("660. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("680. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("680. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("La clave del articulo no existe")
                    End If

                Catch ex As Exception
                    MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
                    Me.Cursor = Cursors.Default
                    Return
                End Try
            End If

        End While
        drOT.Close()

        PRIMERPAGO = IMPORTE
        METODODEPAGO = ""
        CVE_VEND = ""

        cmd.Connection = cnSAE
        cmd.CommandTimeout = 120
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
            Bitacora("870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("870. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("875. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("875. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        '================================================================================================================
        '       PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS        PARTIDAS 
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
                        SQL = "SELECT TIPO_ELE, ULT_COSTO, COSTO_PROM, CVE_ESQIMPU, UNI_MED, DESCR, ISNULL(PRECIO,0) AS P1 " &
                            "FROM INVE" & Empresa & " I " &
                            "LEFT JOIN PRECIO_X_PROD" & Empresa & " P ON P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1 " &
                            "WHERE I.CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        dr = cmd.ExecuteReader
                        If dr.HasRows Then
                            If dr.Read Then
                                ULT_COSTO = dr("ULT_COSTO")
                                COSTO_PROM = dr("COSTO_PROM")
                                CVE_ESQIMPU = dr("CVE_ESQIMPU")
                                DESCR = dr("DESCR")
                                DESCR = DESCR.Replace("'", "")
                                UNI_MED = dr("UNI_MED")
                                TIPO_PROD = dr("TIPO_ELE")
                                Existe = True
                            Else
                                Existe = False
                            End If
                        Else
                            Existe = False
                        End If
                        dr.Close()
                    Catch ex As Exception
                        MsgBox("890. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("890. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("920. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("920. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("940. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        MsgBox("1. La clave del articulo no existe")
                    End If
                    PXS = CANT
                    UNI_VENTA = "No aplica"
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
                        NUM_ALM & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','S','" &
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
                                If TIPO_VENTA = "RR" Or TIPO_VENTA = "V" Then

                                    SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & ", FCH_ULTVTA = '" & FECHA_DOC & "' " &
                                        "WHERE CVE_ART = '" & CVE_ART & "'"
                                    Try
                                        cmd.Connection = cnSAE
                                        cmd.CommandTimeout = 120

                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                        End If
                                    Catch ex As Exception
                                        Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try

                                    If MULTIALMACEN = 1 Then
                                        SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT &
                                            " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
                                        Try
                                            cmd.Connection = cnSAE
                                            cmd.CommandTimeout = 120

                                            cmd.CommandText = SQL
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                            End If
                                        Catch ex As Exception
                                            Bitacora("980. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                    CADENA_NUM_MOV = "'0'"
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

        Me.Close()
    End Sub
    Sub IMPRIMIR_VENTA(fTIPO_DOC As String, fCVE_DOC As String)
        Dim Rreporte_MRT As String = ""
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
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
        Catch ex As Exception
            Bitacora("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CANCELAR_OT()
        Try
            If MsgBox("Realmente desea cancelar la orden de trabajo externa " & tCVE_ORD.Text & "?", vbYesNo) = vbYes Then
                'If LA_REMISION_ESTA_CANCELADA(LtRem.Text) Then
                SQL = "UPDATE GCORDEN_TRABAJO_EXT SET STATUS = 'C' WHERE CVE_ORD = '" & tCVE_ORD.Text & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandTimeout = 120

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                        CANCELAR_TOT()

                        Try
                            If LtRem.Text.Trim.Length > 0 Then
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE FACTR" & Empresa & " SET CVE_PEDI = '' WHERE CVE_DOC = '" & LtRem.Text & "'"
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            End If
                        Catch ex As Exception
                            Bitacora("2650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2650. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        GRABA_BITA(tCVE_PROV.Text, tCVE_ORD.Text, 0, "T", "Se cancelo Orden de trabajo externa ")

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
            Bitacora("2680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function LA_REMISION_ESTA_CANCELADA(fCVE_DOC As String) As Boolean
        Dim EstaCance As Boolean = False
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(STATUS,'') AS ST FROM FACTR" & Empresa & " WHERE CVE_DOC = '" & fCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("ST") = "C" Then
                            EstaCance = True
                        End If
                    End If
                End Using
            End Using
            Return EstaCance
        Catch ex As Exception
            MsgBox("2690. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2690. " & ex.Message & vbNewLine & ex.StackTrace)
            Return EstaCance
        End Try
    End Function

    Private Sub Show_Kardex()
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
            Bitacora("2700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirOrden(fCVE_ORD As String)
        Dim RUTA_FORMATOS As String = "", CVE_DOC1 As String = "", CVE_DOC2 As String = "", CVE_DOC3 As String = "", z As Integer = 0
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportMantenimientoExterna.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportMantenimientoExterna.mrt, verifique por favor")
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

            Try
                z = 0
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM GCORDEN_TRA_SER_EXT WHERE CVE_ORD = '" & fCVE_ORD & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            If dr("CVE_ART") = "TOT" Then
                                z = z + 1
                                Select Case z
                                    Case 1
                                        CVE_DOC1 = dr("TIEMPO_REAL")
                                    Case 2
                                        CVE_DOC2 = dr("TIEMPO_REAL")
                                    Case 3
                                        CVE_DOC3 = dr("TIEMPO_REAL")
                                End Select
                            End If
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("2710. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("2710. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            StiReport1.Load(RUTA_FORMATOS & "\ReportMantenimientoExterna.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.Item("CVE_ORDEN") = fCVE_ORD
            StiReport1.Item("CVE_OTE01") = CVE_DOC1
            StiReport1.Item("CVE_OTE02") = CVE_DOC2
            StiReport1.Item("CVE_OTE03") = CVE_DOC3
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("2720. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("2720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                tCVE_TIPO.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    If PERMITIR_UNIDAD = 0 Then
                        L2.Text = DESCR
                        L2.Tag = Var5

                        tCVE_TIPO.Text = Var5 'TIPO UNIDAD
                        L4.Text = Var8 'DESCRIPCION TIP0 UNIDAD
                    Else
                        'Var4 = dr.ReadNullAsEmptyString("CLAVE").ToString
                        'Var5 = dr.ReadNullAsEmptyInteger("TIPO_UNI")
                        'Var6 = dr.ReadNullAsEmptyString("DES").ToString
                        'Var7 = dr.ReadNullAsEmptyString("TAQ").ToString
                        'var8 = descr tipo unidad
                        L2.Text = DESCR

                        tCVE_TIPO.Text = Var5 'TIPO UNIDAD
                        L4.Text = Var8 'DESCRIPCION TIP0 UNIDAD
                    End If
                    Try
                        If SEGONE Then
                            Var5 = tCVE_UNI.Text
                            If Var5.Trim.Length > 0 Then
                                SEGONE = False
                                Var16 = "S"
                            End If
                        End If
                        tNOTA.Select()
                    Catch ex As Exception
                    End Try
                    Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_TIPO.Text = ""
                    L2.Text = ""
                    L4.Text = ""
                    tCVE_UNI.Text = ""
                    Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                    tCVE_UNI.Select()
                End If
            Else
                tCVE_TIPO.Text = ""
                L2.Text = ""
                L4.Text = ""
            End If
        Catch ex As Exception
            Bitacora("2770. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2770. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnUnidades_Click(sender As Object, e As EventArgs) Handles btnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "" : Var5 = ""
            Var6 = "" : Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = ""

            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE CVE_VIAJE
                'Var3 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                'Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                'Var6 = Fg(Fg.Row, 3).ToString   'DESCR TIPO UNIDAD
                'Var7 = Fg(Fg.Row, 4).ToString   'PLACAS
                'Var8 = Fg(Fg.Row, 5).ToString   'MARCA UNIDAD
                'Var9 = Fg(Fg.Row, 6).ToString   'CVE_TIPO UNI
                'Var11 = Fg(Fg.Row, 8).ToString   'CVE_TIPO UNI
                'If Not IsNothing(Fg(Fg.Row, 7)) Then
                'Var10 = Fg(Fg.Row, 7).ToString   'CVE_TAQ
                'End If

                tCVE_UNI.Text = Var3
                L2.Text = Var6
                L2.Tag = Var9

                tCVE_TIPO.Text = Var9
                L4.Text = Var11       'DESCRIPCION TIPO UNIDAD

                Var3 = "" : Var4 = "" : Var5 = ""
                Var6 = "" : Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = ""
                tNOTA.Focus()
            End If
        Catch Ex As Exception
            MsgBox("2790. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("2790. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TIPO_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TIPO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnTipo_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                'tCVE_PROV.Focus()
                tNOTA.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_TIPO_Validated(sender As Object, e As EventArgs) Handles tCVE_TIPO.Validated
        Try
            If tCVE_TIPO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)
                If DESCR <> "" Then
                    L4.Text = DESCR
                    tNOTA.Select()
                Else
                    MsgBox("Tipo Unidad inexistente")
                    tCVE_TIPO.Text = ""
                    tCVE_TIPO.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("2800. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTipo_Click(sender As Object, e As EventArgs)
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
                'tCVE_PROV.Focus()
                tNOTA.Select()
            End If

        Catch Ex As Exception
            MsgBox("2820. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("2820. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnProv_Click(Nothing, Nothing)
            End If
            If e.KeyCode = 13 Then
                If IsNumeric(tCVE_PROV.Text.Trim) Then
                    tCVE_PROV.Text = Space(10 - tCVE_PROV.Text.Trim.Length) & tCVE_PROV.Text.Trim
                End If
                tFACTURA.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
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
            Bitacora("2840. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
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
            MsgBox("2860. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("2860. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAltaProducto_Click(sender As Object, e As EventArgs) Handles btnAltaProducto.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 3).ToString.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab &
                           " " & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab &
                           " " & vbTab & " " & vbTab & "N")
            End If
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)
        Catch ex As Exception
            MsgBox("2880. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("2880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEliProd_Click(sender As Object, e As EventArgs) Handles btnEliProd.Click
        Try
            If Fg.Row > 0 Then
                Dim Sigue As Boolean = False
                If Fg(Fg.Row, 9) = "Cancelada" Then
                    MessageBox.Show("La partida se encuentra cancelada")
                    Return
                End If
                If tEstatus.Text = "Remisionada" Then
                    Sigue = False
                Else
                    Sigue = True
                End If
                If Sigue Then
                    If MsgBox("Realmente desea cancelar la partida seleccionada?", vbYesNo) = vbYes Then
                        Try
                            If Fg(Fg.Row, 1) = "TOT" And Fg(Fg.Row, 8).ToString.Trim.Length > 0 Then

                                If MsgBox("La orden de compra " & Fg(Fg.Row, 8).ToString &
                                          " sera cancelada, por favor confirme?", vbYesNo) = vbYes Then
                                    Fg(Fg.Row, 20) = "C"
                                    Fg.Rows(Fg.Row).Visible = False
                                End If
                            Else
                                Fg(Fg.Row, 9) = "Cancelada"
                                Fg.Rows(Fg.Row).Visible = False
                            End If
                        Catch ex As Exception
                            Bitacora("2890. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2890. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("2900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2900. " & ex.Message & vbNewLine & ex.StackTrace)
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
                Bitacora("3000. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("3020. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("3030. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3030. " & ex.Message & vbNewLine & ex.StackTrace)
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
                If Fg.Col = 1 Or Fg.Col = 5 Or IIf(DOC_NEW, 6, 5) Then
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
            Var2 = "InveS"
            Var4 = ""
            Var5 = LINEA_FILTRO_SERVICIO
            Var6 = "" 'ALTERNA
            Var7 = "0" 'PRECIO
            Var8 = "" 'TIPO PROD
            Var9 = "" 'COSTO PROM
            Fg.FinishEditing()

            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                Fg.FinishEditing()

                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                'Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                Dim PRECIO As Single = 0
                Try
                    PRECIO = Val(Var9)
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
            MsgBox("3040. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("3040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tNOTA_KeyDown(sender As Object, e As KeyEventArgs) Handles tNOTA.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
                tResponsable.Select()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tNOTA_Validated(sender As Object, e As EventArgs) Handles tNOTA.Validated

    End Sub

    Private Sub tNOTA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tNOTA.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                'tLUGAR_REP.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub EntraFlex(fENTRA As Boolean)
        Try
            ENTRA = fENTRA
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles tBotonMagico.GotFocus
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
            Bitacora("3050. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnBuscaDoc_Click(sender As Object, e As EventArgs) Handles btnBuscaDoc.Click
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

    Private Sub btnFotDocA_Click(sender As Object, e As EventArgs) Handles btnFotDocA.Click
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
            LtFotoDoc.Text = ""

        Catch Ex As Exception
            Bitacora("3060. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("3060. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocE_Click(sender As Object, e As EventArgs) Handles btnFotDocE.Click
        Try
            If FgD.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    FgD.RemoveItem(FgD.Row)
                End If
            End If
        Catch Ex As Exception
            Bitacora("3070. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("3070. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub FgD_DoubleClick(sender As Object, e As EventArgs) Handles FgD.DoubleClick
        Try
            If FgD.Row > 0 Then
                If File.Exists(FgD(FgD.Row, 3) & "\" & FgD(FgD.Row, 2)) Then
                    Process.Start(FgD(FgD.Row, 3) & "\" & FgD(FgD.Row, 2))
                Else
                    MessageBox.Show("El documento " & RUTA_DOC & "\" & FgD(FgD.Row, 2) & "no existe")
                End If
            Else
                MessageBox.Show("Por favor seleccione un documento")
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
            Bitacora("3080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3080. " & ex.Message & vbNewLine & ex.StackTrace)
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
            Bitacora("3090. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3090. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            'SQL = "CREATE TABLE GCOT (CVE_ORD VARCHAR(10) NULL, CVE_CLIE varchar(10) NULL, CVE_ART VARCHAR(16) NULL, CANT FLOAT NULL) ON [PRIMARY]"
            For k = 1 To Fg.Rows.Count - 1

                CVE_ART = Fg(k, 1)
                CANT = Fg(k, 5)
                PRECIO = Fg(k, 6)
                CVE_DOC = Fg(k, 8)

                If CVE_ART.Trim.Length > 0 And CANT > 0 Then
                    If CVE_ART <> "TOT" Then
                        If Fg(k, 9) <> "Cancelada" Then
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
                                    Bitacora("3100. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Bitacora("3200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Var23 = NREG

    End Sub

    Private Sub tLUGAR_REP_KeyDown(sender As Object, e As KeyEventArgs) Handles tLUGAR_REP.KeyDown
        Try
            If e.KeyCode = 13 Then
                btnAltaProducto_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_PROG_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROG.KeyDown
        Try
            If e.KeyCode = 13 Then
                tFACTURA.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub ImprimirOrden_Compra(fTIPO_DOC As String, fCVE_DOC As String)
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
                Case "12"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra12.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra12.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "13"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra13.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra13.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "14"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra14.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra14.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "15"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra15.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra15.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "16"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra16.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra16.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "17"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra17.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra17.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "18"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra18.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra18.mrt") Then
                        MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                        Return
                    End If
                    StiReport1.Load(ARCHIVO_MRT)
                Case "19"
                    ARCHIVO_MRT = RUTA_FORMATOS & "\ReportOrdenDeCompra19.mrt"
                    If Not File.Exists(RUTA_FORMATOS & "\ReportOrdenDeCompra19.mrt") Then
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
            Bitacora("3300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tFACTURA_KeyDown(sender As Object, e As KeyEventArgs) Handles tFACTURA.KeyDown
        Try
            If e.KeyCode = 13 Then
                tLUGAR_REP.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tNOTA_GotFocus(sender As Object, e As EventArgs) Handles tNOTA.GotFocus
        Try
            tNOTA.SelectAll()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tLUGAR_REP_GotFocus(sender As Object, e As EventArgs) Handles tLUGAR_REP.GotFocus
        Try
            tNOTA.SelectAll()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tLUGAR_REP_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tLUGAR_REP.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)
            Fg.Select()
        End If
    End Sub
    Private Sub tResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles tResponsable.KeyDown
        Try
            If e.KeyCode = 13 Then
                tLUGAR_REP.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tResponsable_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tResponsable.PreviewKeyDown

    End Sub
End Class

'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorOTE
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
        Dim CANT As Decimal, CANT_ENT As Decimal, Sigue As Boolean

        If frmOTEAE.tCVE_UNI.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture la unidad")
            Return
        End If
        'If frmOTEAE.tCVE_PROV.Text.Trim.Length = 0 Then
        ' MessageBox.Show("Por favor capture el cliente")
        ' Return
        ' End If
        If frmOTEAE.tCVE_TIPO.Text.Trim.Length = 0 Then
            MessageBox.Show("Por favor capture el tipo de unidad")
            Return
        End If

        If Not FgEdit And col = 6 Then
            Return
        End If
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        If col = 1 And keyRec = 9 Then
            'If IsNothing(_owner(_row, 1)) Then
            MyBase.Visible = True
            _owner.Select()
            _owner.StartEditing()
            Return

            'End If
        End If
        If col = 1 And keyRec = 99 Then
            _owner.Select(1, 2)
            _owner.Row = 1
            _owner.Col = 1
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 1
            Return
        End If
        Sigue = True
        Try
            CANT_ENT = _owner(row, 11)
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

        If Sigue And (col = 1 Or col = 5 Or col = 6) Then
            If col = 99 Then
                _owner.Col = 1
                frmOTEAE.tBotonMagico.Focus()
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
            frmOTEAE.tBotonMagico.Focus()
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
                                            DESC1 = Val(frmOTEAE.tCVE_PROV.Tag)
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
                frmOTEAE.tBotonMagico.Focus()
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
                        Var2 = "InveS" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        Var5 = PassData
                        frmSelItem.ShowDialog()
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
                                DESC1 = Val(frmOTEAE.tCVE_PROV.Tag)
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
                            'CALCULAR_IMPORTES()

                            _owner.Col = 5
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 5 Then
                    _owner.Col = 6
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
                frmOTEAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmOTEAE.tBotonMagico.Focus()
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
                    frmOTEAE.tBotonMagico.Focus()
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
                                frmOTEAE.tBotonMagico.Focus()
                            Else
                                '                              1                2             3                    4                       5 
                                'Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & "" & vbTab & DESCR & vbTab & dr("N_PARTE") & vbTab & dr("CANTI") & vbTab &
                                '    6                 7                     8                    9                   10
                                'SUBTOTAL & vbTab & SUBTOTAL & vbTab & dr("REFER") & vbTab & dr("ST") & vbTab & dr("CANTI") & vbTab &
                                '        11                    12                                 13                                      14
                                'dr("CANT_ENT") & vbTab & dr("IMPORT") & vbTab & IIf(dr("ST") = "M", "Mov. realizado", " ") & vbTab & dr("UID"))
                                If FgEdit Then
                                    '_owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                    '               "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                    '               "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & " " & vbTab & " " & vbTab & "N")
                                    '_owner.Select(row + 1, 1)
                                Else
                                    frmOTEAE.tBotonMagico.Focus()
                                    _owner.Select(row, 1)
                                End If
                            End If
                        Case 3
                            frmOTEAE.tBotonMagico.Focus()
                        Case 9
                            frmOTEAE.tBotonMagico.Focus()
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
                        Case 6
                            col = 5
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
                                frmOTEAE.tBotonMagico.Focus()
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
                            col = 6
                        Case 6
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
                frmOTEAE.tBotonMagico.Focus()
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
                                Var18 = "MANTE_EXT"
                                Var21 = 0
                                Try
                                    Var21 = Val(frmOTEAE.tCVE_PROV.Tag)
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
                                Cp1 = frmOTEAE.tCVE_UNI.Text
                                Cp2 = frmOTEAE.tCVE_TIPO.Text

                                Try
                                    Try
                                        If IsNumeric(frmOTEAE.tLUGAR_REP.Tag) Then
                                            Var20 = frmOTEAE.tLUGAR_REP.Tag
                                        Else
                                            Var20 = 1
                                        End If
                                    Catch ex As Exception
                                        Var20 = 1
                                    End Try

                                    frmComprasTrans.ShowDialog()
                                    If Var17.Trim.Length > 0 And Var17.Trim <> "N" And Var11 <> "edit" Then
                                        'Var11 = tPROV.Text
                                        'Var12 = LtNombre.Text
                                        'Var22 = CAN_TOT - DES_TOT
                                        'Var17 = CVE_DOC
                                        'Var20 = NUM_ALM_OT
                                        frmOTEAE.tLUGAR_REP.Tag = Var20

                                        VarFORM2 = "NoSalirDelForm"
                                        DESC1 = 0
                                        Try
                                            DESC1 = Val(frmOTEAE.tCVE_PROV.Tag)
                                        Catch ex As Exception
                                        End Try
                                        _owner(_row, 1) = MyBase.Text
                                        _owner(_row, 3) = Var12  'NOMBRE CLIENTE
                                        _owner(_row, 4) = Var11 'CLAVE PROVEEDOR
                                        _owner(_row, 5) = "1"
                                        _owner(_row, 6) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                        _owner(_row, 7) = Var22 + (Var22 * Var21 / 100) 'SUBTOTAL
                                        _owner(_row, 8) = Var17 'REFER
                                        _owner(_row, 9) = ""
                                        _owner(_row, 12) = Var22 'IMPORTE CON DESCUENTO

                                        _owner(_row, 20) = "S" 'ES
                                        _owner.Col = 5

                                        'frmOTEAE.ImprimirOrdenOdenDeCompra(Var17)

                                    Else
                                        frmOTEAE.tBotonMagico.Focus()

                                        _owner.Select(_row, 1)
                                    End If
                                    Var17 = ""
                                    Var18 = ""
                                Catch ex As Exception
                                End Try
                                Return
                            Else

                                Dim Descr As String

                                If MyBase.Text.Trim.Length = 0 Then
                                    frmOTEAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                End If
                                Var9 = "" : Var22 = 0 : Var4 = ""
                                Descr = BUSCA_CAT("InveS", MyBase.Text)
                                If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                    MsgBox("Servicio inexistente")
                                    frmOTEAE.tBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                Else
                                    Dim PRECIO As Single, DESC1 As Single, Continua As Boolean = True

                                    _owner(_row, 1) = MyBase.Text
                                    _owner(_row, 3) = Descr
                                    _owner(_row, 4) = Var6

                                    If FgEdit Then
                                        Try
                                            If _owner(_row, 6) > 0.00 Then
                                                Continua = False
                                            Else

                                            End If
                                        Catch ex As Exception
                                            Continua = True
                                        End Try
                                    Else
                                        Continua = False
                                    End If

                                    If Continua Then
                                        _owner(_row, 6) = Var7
                                        Try
                                            DESC1 = Val(frmOTEAE.tCVE_PROV.Tag)
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
                                    Else
                                        Try
                                            Dim C1 As Decimal
                                            If _owner(_row, 5) = 0 Then
                                                _owner(_row, 5) = 1
                                            End If
                                            C1 = _owner(_row, 5) * _owner(_row, 6)
                                            _owner(_row, 7) = C1
                                        Catch ex As Exception
                                        End Try
                                    End If
                                    _owner.Col = 5
                                    Return
                                End If
                            End If
                        Case 5 'cantidad
                            If MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0" Then
                                MsgBox("Cantidad incorrecta")
                                MyBase.Visible = True
                                frmOTEAE.tBotonMagico.Focus()
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
                                If FgEdit Then
                                    _owner.Col = 6
                                Else
                                    HayErr = False
                                    Try
                                        _owner.Select(row + 1, 1)
                                    Catch ex As Exception
                                        HayErr = True
                                    End Try
                                    If HayErr Then
                                        _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                           "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                           "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "" & vbTab & " " & vbTab & "N")
                                        _owner.Select(row + 1, 1)
                                    End If
                                    _owner.StartEditing()
                                    Return
                                End If
                                _owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 6
                            Try
                                Dim C1 As Decimal
                                If _owner(_row, 5) = 0 Then
                                    _owner(_row, 5) = 1
                                End If
                                C1 = _owner(_row, 5) * _owner(_row, 6)
                                _owner(_row, 7) = C1
                            Catch ex As Exception
                            End Try
                            HayErr = False
                            Try
                                _owner.Select(row + 1, 1)
                            Catch ex As Exception
                                HayErr = True
                            End Try
                            If HayErr Then
                                _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                           "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                           "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "" & vbTab & " " & vbTab & "N")
                                _owner.Select(row + 1, 1)
                            End If
                            _owner.StartEditing()
                            Return
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
            cmd.CommandTimeout = 120

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
            frmOTEAE.Lt1.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

End Class
