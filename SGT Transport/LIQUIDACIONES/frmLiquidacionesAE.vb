Imports C1.Win.C1Themes
Imports System.IO
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmLiquidacionesAE
    Private JustGotFocus As Boolean = False
    Private SHOW_MENSAJE As String = ""
    Private IsNew As Boolean = False
    Private ENTRA_VA As Boolean = False

    Private PRECIO_X_LTS As Decimal = 0
    Private ENTRA As Boolean
    Private ENTRA_D As Boolean
    Private ENTRA_LIQ As Boolean = True
    Private SUMA As Decimal = 0
    Private SUMA2 As Decimal = 0
    Private SUMA_LTS As Decimal = 0
    Private SelFg As String = ""
    Private nGastos As Integer = 0, nVales As Integer = 0
    Private FlexiSoloLectura As Boolean = False
    Private FlexiLiquidada As Boolean = False
    Private _myEditor As MyEditorLiq
    Private _myEditorPa As MyEditorPA

    Private _FgColDefault = 0
    Private _FgColSeleccione = 1
    Private _FgColNumViaje = 2
    Private _FgColFactura1 = 3
    Private _FgColFactura2 = 4
    Private _FgColCliente = 5
    Private _FgColRutaOrigen = 6
    Private _FgColRutaDestino = 7
    Private _FgColTipoViaje = 8
    Private _FgColFacturado = 9
    Private _FgColSueldo = 10
    Private _FgColPorcSueldo = 11
    Private _FgColSueldoManiobra = 12
    Private _FgColPorcSdoManiobra = 13
    Private _FgColSelCalculo = 14
    Private _FgColSdoPorTonedada = 15
    Private _FgColSdoManiobraPorTonedada = 16
    Private _FgColSueldoViaje = 17
    Private _FgColTipoUnidad = 18
    Private _FgColUnidad = 19
    Private _FgColNumCPorte = 20
    Private _FgColEstatus = 21
    Private _FgColNumCPorte2 = 22
    Private _FgColEstatus2 = 23
    Private _FgColVacio = 24
    Private _FgColClaveOrigen = 25
    Private _FgColOrigen = 26
    Private _FgColClaveDestino = 27
    Private _FgColDestino = 28
    Private _FgColCveStViaje = 29
    Private _FgColStatusViaje = 30
    Private _FgColPuntos = 31
    Private _FgColCheck19 = 32
    Private _FgColNumPar = 33
    Private _FgColUUID = 34
    Private _FgColNuevo = 35
    Private _FgColVacio23 = 36
    Private _FgColxFactor = 37
    Private _FgColFCargaPRog = 38
    Private _FgColFCargaReal = 39
    Private _FgColFDescProg = 40
    Private _FgColFDescReal = 41
    Private _FgColDemorasCarga = 42
    Private _FgColDemorasDescarga = 43
    Private _FgColSueldoxFactor = 44



    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmLiquidacionesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        ProcessControls(Me)

    End Sub

    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        SplitMult.Dock = DockStyle.Fill

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

        AssignValidation(TCVE_OPER, ValidationType.Only_Numbers)

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        BtnOper.FlatStyle = FlatStyle.Flat
        BtnOper.FlatAppearance.BorderSize = 0
        BtnUnidad.FlatStyle = FlatStyle.Flat
        BtnUnidad.FlatAppearance.BorderSize = 0
        BtnReset.FlatStyle = FlatStyle.Flat
        BtnReset.FlatAppearance.BorderSize = 0


        FgCasetas.Cols(1).StarWidth = "2*"
        FgCasetas.Cols(2).StarWidth = "*"
        FgCasetas.Cols(3).StarWidth = "*"
        FgCasetas.Cols(4).StarWidth = "4*"
        FgCasetas.Cols(5).StarWidth = "*"
        FgCasetas.Cols(6).StarWidth = "4*"
        FgCasetas.Cols(7).StarWidth = "2*"

        SQL = "SELECT C.CVE_CXR, C.CVE_PLAZA, P1.CIUDAD AS CIUDAD1, C.CVE_PLAZA2, P2.CIUDAD AS CIUDAD2, IMPORTE_CASETAS
            FROM GCCASETAS_X_RUTA C 
            LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
            LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
            WHERE C.STATUS = 'A' ORDER BY CVE_CXR"
        FgCasetas.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgCasetas.AddItem("" & vbTab & "" & vbTab & dr("CVE_CXR") & vbTab & dr("CVE_PLAZA") & vbTab &
                                          dr("CIUDAD1") & vbTab & dr("CVE_PLAZA2") & vbTab & dr("CIUDAD2") & vbTab &
                                          dr("IMPORTE_CASETAS"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try



        FgG.Rows.Count = 1
        FgV.Rows.Count = 1
        FgGC.Rows.Count = 1
        FgD.Rows.Count = 2
        FgPA.Rows.Count = 1

        TABONAR.Value = 0

        'FgGC.Cols(14).Visible = False
        If PASS_GRUPOCE = "BUS" Then
            FgGC.Cols(15).Visible = False
            FgGC.Cols(16).Visible = False
            FgGC.Cols(17).Visible = True
            FgGC.Cols(18).Visible = False
        Else
            FgGC.Cols(15).Visible = False
            FgGC.Cols(16).Visible = False
            FgGC.Cols(17).Visible = False
            FgGC.Cols(18).Visible = False
        End If

        Fg.Cols(_FgColUnidad).Visible = False
        Fg.Cols(_FgColNumCPorte).Visible = False
        Fg.Cols(_FgColEstatus).Visible = False
        Fg.Cols(_FgColNumCPorte2).Visible = False
        Fg.Cols(_FgColEstatus2).Visible = False
        Fg.Cols(_FgColVacio).Visible = False
        Fg.Cols(_FgColClaveOrigen).Visible = False
        Fg.Cols(_FgColOrigen).Visible = False
        Fg.Cols(_FgColClaveDestino).Visible = False
        Fg.Cols(_FgColDestino).Visible = False
        Fg.Cols(_FgColCveStViaje).Visible = False
        Fg.Cols(_FgColStatusViaje).Visible = False
        Fg.Cols(_FgColPuntos).Visible = False
        Fg.Cols(_FgColCheck19).Visible = False
        Fg.Cols(_FgColNumPar).Visible = False
        Fg.Cols(_FgColUUID).Visible = False
        Fg.Cols(_FgColNuevo).Visible = False
        Fg.Cols(_FgColVacio23).Visible = False
        Fg.Cols(_FgColxFactor).Visible = False
        Fg.Cols(_FgColFCargaPRog).Visible = False
        Fg.Cols(_FgColFCargaReal).Visible = False
        Fg.Cols(_FgColFDescProg).Visible = False
        Fg.Cols(_FgColFDescReal).Visible = False
        Fg.Cols(_FgColDemorasCarga).Visible = False
        Fg.Cols(_FgColDemorasDescarga).Visible = False
        Fg.Cols(_FgColSueldoxFactor).Visible = False


        Fg.DrawMode = DrawModeEnum.OwnerDraw
        FgG.DrawMode = DrawModeEnum.OwnerDraw

        'y obtiene PRECIO_X_LTS 
        OBTENER_RUTA_DOC()

        Fg.Cols(_FgColCveStViaje).Width = 0
        TCVE_LIQ.Text = ""
        F1.Value = Now
        TCVE_LIQ.Text = ""
        TCVE_OPER.Text = ""
        LtTipoCrobro.Text = ""
        TOBS.Text = ""
        TOBS.Tag = "0"
        ENTRA_D = True
        Var46 = ""
        TCVE_RES.Tag = "0"
        TDESCT.Tag = "0"
        TCARGO_X_PUNTO_MUERTO.Tag = "0"

        Try
            SQL = "SELECT ISNULL(LIN_PROD,'') AS LIN_PRO FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Var46 = dr("LIN_PRO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If PASS_GRUPOCE.ToUpper = "BUS" Then
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = k & "." & Fg(0, k)
            Next
            For k = 1 To FgV.Cols.Count - 1
                FgV(0, k) = k & "." & FgV(0, k)
            Next
            For k = 1 To FgGC.Cols.Count - 1
                FgGC(0, k) = k & "." & FgGC(0, k)
            Next
            For k = 1 To FgD.Cols.Count - 1
                FgD(0, k) = k & "." & FgD(0, k)
            Next
            For k = 1 To FgPA.Cols.Count - 1
                FgPA(0, k) = k & "." & FgPA(0, k)
            Next

            'Fg.Cols(_FgColSueldoViaje).Visible = True
            'Fg.Cols(_FgColPuntos).Visible = True
            'Fg.Cols(_FgColCheck19).Visible = False
        End If
        Try
            If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                'TOOLTIP_EN_CONTROLES(Me.Controls, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(SplitMult1, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(SplitMult3, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(GpoCamposAdic, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(Pag7, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(GpoCamposAdic, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(GpoEvento1, C1SuperTooltip1)
                TOOLTIP_EN_CONTROLES(GpoEvento2, C1SuperTooltip1)
            End If
        Catch ex As Exception
            BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Tab1.SelectedIndex = 0
        LtTipoCrobro.Text = "Edición"

        If Var1 = "Nuevo" Then
            IsNew = True
            Try
                TCVE_LIQ.Text = GET_MAX("GCLIQUIDACIONES", "CVE_LIQ")
                TCVE_LIQ.Enabled = False
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                BITACORA_LIQ("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            BarCancelacion.Enabled = False
            BarImprimirLiq.Enabled = False
            BarFinalizarLiq.Enabled = False

            Fg.SetCellCheck(0, _FgColSeleccione, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
            Fg.SetCellCheck(0, _FgColSelCalculo, C1.Win.C1FlexGrid.CheckEnum.Unchecked)
            FgG.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

            FlexiSoloLectura = False
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                If Var2 = "" Then
                    Var2 = "0"
                End If

                SQL = "SELECT L.CVE_LIQ, L.CVE_ST_LIQ, L.STATUS, L.FECHA, L.CVE_OPER, L.CVE_UNI,  L.CVE_RES, L.CVE_OBS, 
                    O.DESCR AS STR_OBS, GASTOS_VIAJE, VALES_COMBUSTIBLE, PERCEP_X_VIAJE, OTRAS_PERCEP, DEDUCCIONES, 
                    DIF_COMPROBACION, SUBTOTAL, IMPORTE, CVE_DED_RES, ISNULL(CVE_DED_DESCUENTO,0) AS CVE_DED_DES, 
                    ISNULL(CVE_DED_CARGO_P_MUERTO,0) AS CVE_DED_MUE
                    FROM GCLIQUIDACIONES L
                    LEFT JOIN GCOBS O ON O.CVE_OBS = L.CVE_OBS    
                    WHERE CVE_LIQ = " & Var2

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_LIQ.Text = dr("CVE_LIQ").ToString
                    F1.Value = dr("FECHA").ToString
                    TCVE_LIQ.Text = dr("CVE_LIQ").ToString
                    TCVE_OPER.Text = dr("CVE_OPER").ToString
                    LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

                    TCVE_TRACTOR.Text = dr("CVE_UNI").ToString

                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        LtUnidad.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                    End If

                    TCVE_RES.Text = dr("CVE_RES").ToString
                    If TCVE_RES.Text = "0" Then TCVE_RES.Text = ""
                    TCVE_RES.Tag = dr.ReadNullAsEmptyInteger("CVE_DED_RES")

                    Try
                        'CVE_DED_DESCUENTO, CVE_DED_CARGO_P_MUERTO
                        TDESCT.Tag = dr("CVE_DED_DES")
                        TCARGO_X_PUNTO_MUERTO.Tag = dr("CVE_DED_MUE")
                    Catch ex As Exception
                        BITACORA_LIQ("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    TOBS.Text = dr.ReadNullAsEmptyString("STR_OBS")
                    TOBS.Tag = dr.ReadNullAsEmptyDecimal("CVE_OBS")

                    LtTotDeduc.Text = Format(dr.ReadNullAsEmptyDecimal("DEDUCCIONES"), "###,###,##0.00")

                    'Fg   GCLIQ_PARTIDAS    Liquidaciones de viaje
                    DESPLEGAR_LIQ_PARTIDAS(CLng(TCVE_LIQ.Text))
                    'FgG    GCASIGNACION_VIAJE_GASTOS 
                    DESPLEGAR_LIQ_GASTOS_VIAJE(CLng(TCVE_LIQ.Text))
                    'FgV     GCASIGNACION_VIAJE_VALES 
                    DESPLEGAR_LIQ_VALES_VIAJE(CLng(TCVE_LIQ.Text))
                    'FgGC   GCLIQ_GASTOS_COMPROBADOS 
                    DESPLEGAR_LIQ_GASTOS_COMPROBADOS(CLng(TCVE_LIQ.Text))
                    'FgD    GCLIQ_DEDUCCIONES 
                    DESPLEGAR_LIQ_DEDUCCIONES(CLng(TCVE_LIQ.Text))
                    'FgPA   GCLIQ_PENSION_ALI 
                    DESPLEGAR_LIQ_PENSION_ALIMENTICIA(CLng(TCVE_LIQ.Text))
                    'FgCasetas   GCLIQ_CASETAS
                    DESPLEGAR_LIQ_CASETAS(CLng(TCVE_LIQ.Text))

                    LtValesCombustible.Text = Format(dr.ReadNullAsEmptyDecimal("VALES_COMBUSTIBLE"), "###,###,##0.00")
                    LtPerXViaje.Text = Format(dr.ReadNullAsEmptyDecimal("PERCEP_X_VIAJE"), "###,###,##0.00")
                    LtOtrasPercep.Text = Format(dr.ReadNullAsEmptyDecimal("OTRAS_PERCEP"), "###,###,##0.00")
                    LtDifCompro.Text = Format(dr.ReadNullAsEmptyDecimal("DIF_COMPROBACION"), "###,###,##0.00")
                    LtSubtotal.Text = Format(dr.ReadNullAsEmptyDecimal("SUBTOTAL"), "###,###,##0.00")

                    LtImporteLiquidar.Text = Format(dr.ReadNullAsEmptyDecimal("IMPORTE"), "###,###,##0.00")
                    LtTotalPercep.Text = Format(dr.ReadNullAsEmptyDecimal("PERCEP_X_VIAJE") + dr.ReadNullAsEmptyDecimal("OTRAS_PERCEP"), "###,###,##0.00")

                    Select Case dr("CVE_ST_LIQ")
                        Case 1
                            LtTipoCrobro.Text = "Edición"
                        Case 2
                            LtTipoCrobro.Text = "Aceptada"
                            TCVE_OPER.ReadOnly = True
                            TCVE_RES.ReadOnly = True
                            TCVE_TRACTOR.ReadOnly = True
                            TABONAR.ReadOnly = True
                            TOBSER.ReadOnly = True
                        Case 3
                            LtTipoCrobro.Text = "Contabilizada"
                            LtTipoCrobro.Text = "Aceptada"
                            TCVE_OPER.ReadOnly = True
                            TCVE_RES.ReadOnly = True
                            TCVE_TRACTOR.ReadOnly = True
                            TABONAR.ReadOnly = True
                            TOBSER.ReadOnly = True
                        Case 4
                            LtTipoCrobro.Text = "Depositada"
                            LtTipoCrobro.Text = "Aceptada"
                            TCVE_OPER.ReadOnly = True
                            TCVE_RES.ReadOnly = True
                            TCVE_TRACTOR.ReadOnly = True
                            TABONAR.ReadOnly = True
                            TOBSER.ReadOnly = True
                    End Select

                    If dr("STATUS") = "C" Then
                        LtTipoCrobro.Text = "Cancelada"
                        TABONAR.ReadOnly = True
                        TOBSER.ReadOnly = True

                        BtnAddGC.Enabled = False
                        BtnEliminarGasto.Enabled = False

                        BtnAddDec.Enabled = False
                        BtnEliminar.Enabled = False


                        BtnGastosViaje.Enabled = False
                        BtnGastosViajeEliminar.Enabled = False
                        FlexiSoloLectura = True
                    Else
                        If dr("STATUS") = "L" Then
                            FlexiLiquidada = True

                            BtnAddGC.Enabled = False
                            BtnEliminarGasto.Enabled = False

                            BtnAddDec.Enabled = False
                            BtnEliminar.Enabled = False

                            BtnGastosViaje.Enabled = False
                            BtnGastosViajeEliminar.Enabled = False

                            BtnAltaPA.Enabled = False
                            BtnEliPartPA.Enabled = False
                            FlexiSoloLectura = True
                        Else
                            TOBSER.ReadOnly = False
                        End If
                    End If
                    BarDesplegar.Enabled = False
                    'FlexiSoloLectura = True
                End If
                dr.Close()

                DESPLEGAR_RESETEO()

                TCVE_OPER.ReadOnly = True
                BtnOper.Enabled = False
                TCVE_TRACTOR.ReadOnly = True
                BtnUnidad.Enabled = False
                F1.ReadOnly = True
                TCVE_LIQ.Enabled = False

                'DESPLEGA TODAS LAS LIQUIDACIONES DEL OPERQDOR MENOS LAS LIQUIDADASS
                DESPLEGAR_BarDesplegar(True)

                Tab1.Select()

                CALCULAR_IMPORTES()

                Fg.Focus()
                Fg.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                BITACORA_LIQ("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        ENTRA = True
        Me.Refresh()
        If LtTipoCrobro.Text = "Aceptada" Or LtTipoCrobro.Text = "Contabilizada" Or LtTipoCrobro.Text = "Depositada" Or
            LtTipoCrobro.Text = "Cancelada" Or LtTipoCrobro.Text = "Liquidado" Then
            Try
                FlexiSoloLectura = True
                For Each c As Control In Page1.Controls
                    If TypeOf c Is TextBox Then

                        c.BackColor = Color.LightYellow
                        c.ForeColor = Color.Black
                        c.Enabled = False
                    End If
                    If TypeOf c Is Button Then

                        c.Enabled = False
                    End If
                Next
                For Each c As Control In SplitMult1.Controls
                    If TypeOf c Is TextBox Then
                        c.BackColor = Color.LightYellow
                        c.ForeColor = Color.Black
                        c.Enabled = False
                    End If
                    If TypeOf c Is Button Then
                        c.Enabled = False
                    End If
                Next
                BtnEliminar.Enabled = False
                BtnEliminarGasto.Enabled = False
                BtnAddDec.Enabled = False
                BtnGastosViaje.Enabled = False
                BtnGastosViajeEliminar.Enabled = False

                BtnAddGC.Enabled = False
                TOBS.ReadOnly = True
                BarDesplegar.Enabled = False
                BarGrabar.Enabled = False
                BarFinalizarLiq.Enabled = False

                If LtTipoCrobro.Text <> "Aceptada" Then
                    BarImprimirResteo.Enabled = False
                    BarImprimirLiq.Enabled = False
                    BarReseteo.Enabled = False
                End If

                TLTS_DESCONTAR2.Enabled = False
                TPRECIO_X_LTS2.Enabled = False
                TLTS_AUTORIZADOS2.Enabled = False

                BtnAltaPA.Enabled = False
                BtnEliPartPA.Enabled = False

            Catch ex As Exception
                BITACORA_LIQ("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If LtTipoCrobro.Text = "Aceptada" Or LtTipoCrobro.Text = "Edición" Then
                BarCancelacion.Enabled = True
            Else
                BarCancelacion.Enabled = False
            End If
        Else

            TCVE_OPER.Select()
            Try
                _myEditor = New MyEditorLiq(FgGC)
            Catch ex As Exception
            End Try

            Try
                _myEditorPa = New MyEditorPA(FgPA)
            Catch ex As Exception
            End Try

        End If

        ENTRA_VA = True

        'Fg.Cols(_FgColClaveDestino).Visible = False
        'Fg.Cols(_FgColCheck19).Visible = False
        'Fg.Cols(_FgColNumPar).Visible = False
        'Fg.Cols(_FgColUUID).Visible = False
        'Fg.Cols(_FgColNuevo).Visible = False
        'Fg.Cols(_FgColVacio23).Visible = False
        'Fg.Cols(_FgColxFactor).Visible = True
    End Sub
    Sub DESPLEGAR_LIQ_CASETAS(FCVE_LIQ As Long)
        Try
            SQL = "SELECT CVE_LIQ, CVE_CXR, CVE_PLAZA, CVE_PLAZA2, IMPORTE
                FROM GCLIQ_CASETAS
                WHERE CVE_LIQ = " & FCVE_LIQ & " ORDER BY CVE_LIQ, CVE_CXR"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        For k = 1 To FgCasetas.Rows.Count - 1
                            If dr.ReadNullAsEmptyInteger("CVE_CXR") = FgCasetas(k, 2) Then
                                FgCasetas(k, 1) = True
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_LIQ_PARTIDAS(fCVE_LIQ As Long)
        Try
            Dim s As String = "", ExistViaje As Boolean = False, CVE_CAP1 As String, CVE_CAP2 As String, TIP_VIAJE As String
            Dim CPS As String
            Fg.Rows.Count = 1

            SUMA = 0
            SQL = "SELECT GV.CVE_VIAJE, GV.CVE_CAP1, GV.CVE_CAP2, GV.TIPO_UNIDAD, A.TIPO_VIAJE, A.FECHA_CARGA, GV.CVE_UNI, 
                GV.CLAVE_O, E.DESCR AS DESCR_ORIGEN, GV.CLAVE_D, R.DESCR AS DESCR_DESTINO, GV.CVE_ST_VIA, 
                S.DESCR AS STATUS_VIAJE, GV.SUELDO, GV.NUM_PAR, GV.UUID, ISNULL(A.CVE_CAP1,'') AS CAP1, 
                ISNULL(A.CVE_CAP2,'') AS CAP2, ISNULL(A.CVE_TAB_VIAJE,'') AS CVE_TAB, 
                ISNULL(ST.DESCR,'') AS ST_CP, CP.FECHA_REAL_CARGA, CP.FECHA_DESCARGA, CP.FECHA_REAL_DESCARGA, 
                ISNULL((SELECT ISNULL(STC.DESCR,'') AS ST_CP FROM GCCARTA_PORTE CT LEFT JOIN GCSTATUS_CARTA_PORTE STC ON STC.CVE_CAP = CT.ST_CARTA_PORTE WHERE CVE_FOLIO = A.CVE_CAP2),'') AS ST_CP2,
                DATEDIFF(day, CP.FECHA_CARGA, CP.FECHA_REAL_CARGA) AS DIF1, 
                DATEDIFF(day, CP.FECHA_DESCARGA, CP.FECHA_REAL_DESCARGA) AS DIF2,
                ISNULL(R1.SUELDO_X_FACTOR,0) AS SUELDO_C_FAC, CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.SUELDO_FULL,0) ELSE ISNULL(R1.SUELDO_SENC,0) END AS SUEL_CONV,
				A.CVE_DOC AS FACT1, '' AS FACT2, CLI.NOMBRE AS CLIENTE_NOMBRE, R1.DESCR AS ORIGEN, R1.DESCR2 AS DESTINO, ISNULL(FAC.CAN_TOT, 0) AS FACTURADO,
				isnull(SEL_CALCULO, 0) AS SEL_CALCULO, isnull(PORC_SUELDO, 0) AS PORC_SUELDO, isnull(SUELDO_MANIOBRA, 0) AS SUELDO_MANIOBRA, isnull(PORC_SUELDO_MANIOBRA, 0) AS PORC_SUELDO_MANIOBRA, 
                isnull(SDO_X_TONELADA, 0) AS SDO_X_TONELADA, isnull(SDO_MANIOBRA_X_TONELADA, 0) AS SDO_MANIOBRA_X_TONELADA
                FROM GCLIQ_PARTIDAS GV
                LEFT JOIN GCCARTA_PORTE CP ON CP.CVE_FOLIO = GV.CVE_CAP1
                LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = CP.ST_CARTA_PORTE
                LEFT JOIN GCASIGNACION_VIAJE A ON A.CVE_VIAJE = GV.CVE_VIAJE
                --LEFT JOIN GCTAB_RUTAS_F R1 ON R1.CVE_CON = A.CVE_CON
                LEFT JOIN GCTAB_RUTAS_F R1 ON R1.CVE_TAB = A.CVE_TAB_VIAJE
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN E ON E.CVE_REG = GV.CLAVE_O
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R ON R.CVE_REG = GV.CLAVE_D
                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = GV.CVE_ST_VIA
				LEFT JOIN CLIE05 CLI WITH (nolock) ON CLI.CLAVE = A.CLIENTE	
				LEFT JOIN FACTF05 FAC WITH (nolock) ON FAC.CVE_DOC = A.CVE_DOC AND FAC.STATUS != 'C' AND FAC.TIMBRADO = 'S'
                WHERE CVE_LIQ = " & fCVE_LIQ & " ORDER BY GV.FECHAELAB"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            ExistViaje = False
                            For k = 1 To Fg.Rows.Count - 1
                                If Fg(k, _FgColUUID) = dr("UUID") Then
                                    ExistViaje = True
                                    Fg(k, _FgColSeleccione) = True
                                    Fg(k, _FgColSueldoViaje) = dr("SUELDO")
                                    Fg(k, _FgColCheck19) = "Check"
                                    Fg(k, _FgColNumPar) = dr("NUM_PAR")
                                    SUMA += dr("SUELDO")
                                    Exit For
                                End If
                            Next
                            If Not ExistViaje Then
                                CVE_CAP1 = dr("CAP1")
                                CVE_CAP2 = dr("CAP2")
                                CPS = CVE_CAP1
                                If CVE_CAP2.Trim.Length > 0 Then
                                    TIP_VIAJE = "Full"
                                    CPS = CPS & " - " & CVE_CAP2
                                Else
                                    TIP_VIAJE = "Sencillo"
                                End If

                                ''                                               1                     2                   3                     4                     5    
                                's = IIf(dr("CVE_TAB").ToString.Trim.Length = 0, "", ">") & vbTab & True & vbTab & dr("CVE_VIAJE") & vbTab & CVE_CAP1 & vbTab & dr("ST_CP") & vbTab & CVE_CAP2 & vbTab
                                ''             6                    7                             8
                                's &= dr("ST_CP2") & vbTab & TIP_VIAJE & vbTab & IIf(dr("TIPO_UNIDAD") = 1, "Cargado", "Vacio") & vbTab
                                ''                 9                       10                      11                        12
                                's &= dr("FECHA_CARGA") & vbTab & dr("CVE_UNI") & vbTab & dr("CLAVE_O") & vbTab & dr("DESCR_ORIGEN") & vbTab
                                ''              13                         14                           15                         16
                                's &= dr("CLAVE_D") & vbTab & dr("DESCR_DESTINO") & vbTab & dr("CVE_ST_VIA") & vbTab & dr("STATUS_VIAJE") & vbTab
                                ''              17              18            19                  20                     21           22 NUEVO S/N   23 CVE_TAB_VIAJE SUELDO
                                's &= dr("SUELDO") & vbTab & "" & vbTab & "NO" & vbTab & dr("NUM_PAR") & vbTab & dr("UUID") & vbTab & "N" & vbTab & dr("CVE_TAB") & vbTab
                                ''     24 x factor             25                             26                             27                              28
                                's &= "" & vbTab & dr("FECHA_CARGA") & vbTab & dr("FECHA_REAL_CARGA") & vbTab & dr("FECHA_DESCARGA") & vbTab & dr("FECHA_REAL_DESCARGA") & vbTab
                                ''           29                    30                     31                     32
                                's &= dr("DIF1") & vbTab & dr("DIF2") & vbTab & dr("SUELDO") & vbTab & dr("SUEL_CONV")


                                s = IIf(dr("CVE_TAB").ToString.Trim.Length = 0, "", ">")
                                s &= vbTab & True
                                s &= vbTab & dr("CVE_VIAJE")
                                s &= vbTab & dr("FACT1")
                                s &= vbTab & dr("FACT2")
                                s &= vbTab & dr("CLIENTE_NOMBRE")
                                s &= vbTab & dr("ORIGEN")
                                s &= vbTab & dr("DESTINO")
                                's &= vbTab & TIP_VIAJE
                                s &= vbTab & IIf(dr.ReadNullAsEmptyInteger("TIPO_UNIDAD") = 1, "Full", "Sencillo")
                                s &= vbTab & dr("FACTURADO")
                                s &= vbTab & dr("SUEL_CONV")
                                s &= vbTab & dr("PORC_SUELDO")
                                s &= vbTab & dr("SUELDO_MANIOBRA")
                                s &= vbTab & dr("PORC_SUELDO_MANIOBRA")
                                s &= vbTab & dr("SEL_CALCULO")
                                s &= vbTab & dr("SDO_X_TONELADA")
                                s &= vbTab & dr("SDO_MANIOBRA_X_TONELADA")
                                s &= vbTab & dr("SUELDO")
                                s &= vbTab & IIf(dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 1, "Cargado", "Vacio")
                                s &= vbTab & dr.ReadNullAsEmptyString("CVE_UNI")
                                s &= vbTab & dr("CAP1")
                                s &= vbTab & dr("ST_CP")
                                s &= vbTab & dr("CAP2")
                                s &= vbTab & dr("ST_CP2")
                                s &= vbTab & dr("FECHA_CARGA")
                                s &= vbTab & dr("CLAVE_O")
                                s &= vbTab & dr("DESCR_ORIGEN")
                                s &= vbTab & dr("CLAVE_D")
                                s &= vbTab & dr("DESCR_DESTINO")
                                s &= vbTab & dr("CVE_ST_VIA")
                                s &= vbTab & dr("STATUS_VIAJE")
                                s &= vbTab & ""
                                s &= vbTab & "NO"
                                s &= vbTab & 0
                                s &= vbTab & dr("UUID")
                                s &= vbTab & "N"
                                s &= vbTab & dr("CVE_TAB")
                                s &= vbTab & ""
                                s &= vbTab & dr("FECHA_CARGA")
                                s &= vbTab & dr("FECHA_REAL_CARGA")
                                s &= vbTab & dr("FECHA_DESCARGA")
                                s &= vbTab & dr("FECHA_REAL_DESCARGA")
                                s &= vbTab & dr("DIF1")
                                s &= vbTab & dr("DIF2")
                                s &= vbTab & dr("SUEL_CONV")


                                Fg.AddItem(s)
                                DESPLEGAR_LIQ_GASTOS_VIAJE(dr("CVE_VIAJE"))
                                DESPLEGAR_LIQ_VALES_VIAJE(dr("CVE_VIAJE"))

                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("27. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
                LtPerXViaje.Text = Format(SUMA, "###,###,##0.00")
            End Using

            Fg.AutoSizeCols()
        Catch ex As Exception
            BITACORA_LIQ("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub OBTENER_RUTA_DOC()
        Try 'SQL SERVER
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCPARAMGENERALES"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        PRECIO_X_LTS = dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORA_LIQ("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_LIQ_GASTOS_VIAJE(fCVE_IAJE As String)
        Dim STATUS As Boolean
        Try
            SUMA2 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_VIAJE, ISNULL(GV.STATUS,'A') AS STA, CVE_OPER, CVE_GAV, FOLIO, FECHA, CVE_NUM, 
                    ISNULL(IMPORTE,0) AS IMPORT, DESCR, ISNULL(ST_GASTOS,'EDICION') AS ST_GAS, GV.UUID
                    FROM GCASIGNACION_VIAJE_GASTOS GV
                    LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                    WHERE CVE_LIQ = '" & fCVE_IAJE & "' AND ISNULL(ST_GASTOS,'') = 'DEPOSITADO' ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            STATUS = True
                            SUMA2 += dr("IMPORT")
                            If STATUS Then
                                FgG.AddItem("1" & vbTab & STATUS & vbTab & dr("CVE_VIAJE") & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab &
                                    dr("CVE_NUM") & vbTab & dr("DESCR") & vbTab & dr("IMPORT") & vbTab & dr("ST_GAS") & vbTab & 0 & vbTab & dr("UUID"))
                                nGastos += 1
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("850. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
                FgG.AutoSizeCols()
                LtGastosDeViaje.Text = Format(SUMA2, "###,###,##0.00")
            End Using
        Catch ex As Exception
            BITACORA_LIQ("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_LIQ_VALES_VIAJE(fCVE_VIAJE As String)
        Try
            Dim LTS_REALES As Decimal = 0

            SUMA_LTS = 0 : SUMA2 = 0
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_VIAJE, GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, GV.FECHA, GV.CVE_GAS, GV.LITROS, GV.LITROS_REALES, GV.P_X_LITRO, GV.SUBTOTAL, 
                    GV.IVA, GV.IEPS, GV.IMPORTE, G.DESCR, GV.FACTURA, ISNULL(GV.ST_VALES,'EDICION') AS ST_VAL, GV.UUID
                    FROM GCASIGNACION_VIAJE_VALES GV
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                    WHERE GV.STATUS = 'A' AND GV.CVE_LIQ = '" & fCVE_VIAJE & "' AND ST_VALES <> 'EDICION'  AND ST_VALES <> 'CAPTURADO'  ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgV.AddItem("" & vbTab & dr("CVE_VIAJE") & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("CVE_GAS") & vbTab & dr("DESCR") & vbTab &
                                     dr("LITROS") & vbTab & dr("LITROS_REALES") & vbTab & dr("P_X_LITRO") & vbTab & dr("SUBTOTAL") & vbTab &
                                     dr("IVA") & vbTab & dr("IEPS") & vbTab & dr("IMPORTE") & vbTab & dr("FACTURA") & vbTab & 0 & vbTab & dr("UUID"))
                        nVales += 1
                    End While
                End Using
                Try
                    For k = FgV.Rows.Count - 1 To 1 Step -1
                        Try
                            If FgV.Rows(k).IsVisible Then
                                SUMA2 += FgV(k, 12)
                                SUMA_LTS += FgV(k, 7)
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Next
                Catch ex As Exception
                    BITACORA_LIQ("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                FgV.AutoSizeCols()
                LtValesCombustible.Text = Format(SUMA2, "###,###,##0.00")
            End Using
        Catch ex As Exception
            BITACORA_LIQ("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_LIQ_GASTOS_COMPROBADOS(fCVE_LIQ As Long)

        ENTRA = False
        Try
            Dim j As Integer = 1
            SUMA2 = 0
            FgGC.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_DOC, GV.REFER, GV.CVE_ART, I.DESCR, GV.CVE_PROV, P.NOMBRE, GV.FECHA, GV.SUBTOTAL, GV.IVA, GV.IEPS, GV.TOTAL, 
                    GV.CVE_OBS, O.DESCR AS STR_OBS, GV.NUM_PAR, GV.UUID
                    FROM GCLIQ_GASTOS_COMPROBADOS GV
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = GV.CVE_ART
                    LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = GV.CVE_PROV
                    LEFT JOIN GCOBS O ON O.CVE_OBS = GV.CVE_OBS
                    WHERE GV.CVE_LIQ = " & fCVE_LIQ & " ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgGC.AddItem("" & vbTab & dr("CVE_DOC") & vbTab & dr("REFER") & vbTab & dr("CVE_ART") & vbTab & "" & vbTab & dr("DESCR") & vbTab &
                                     dr("CVE_PROV") & vbTab & "" & vbTab & dr("NOMBRE") & vbTab & dr("FECHA") & vbTab & dr("SUBTOTAL") & vbTab &
                                     dr("IVA") & vbTab & dr("IEPS") & vbTab & dr("TOTAL") & vbTab & dr("STR_OBS") & vbTab & 0 & vbTab & 0 & vbTab &
                                     dr.ReadNullAsEmptyInteger("NUM_PAR") & vbTab & dr.ReadNullAsEmptyLong("CVE_OBS") & vbTab & dr("UUID"))
                        FgGC.Col = 0
                        j += 1
                        SUMA2 += dr("TOTAL")
                    End While
                End Using
                CALCULAR_IMPORTES()
                '                           1            2              3           4          5             6           7          8                     9
                '                       Documento	Referencia	    Articulo      button	descripcion	     prov       button     nombre     	       	fecha
                FgGC.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & Date.Now.ToShortDateString & vbTab &
                             "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & 0 & vbTab & "")
                '            10           11           12           13           14 	      15		    16	          17           18          19
                '           subtotal	 iva	       ieps	        total	    STR_OBS      IEPS	        IVA	          NUM_PAR     CVE_OBS      UIUID 
                Try
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(FgGC.Rows.Count - 1, 2)
                    End If
                Catch ex As Exception
                End Try
            End Using
        Catch ex As Exception
            BITACORA_LIQ("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Sub DESPLEGAR_LIQ_PENSION_ALIMENTICIA(fCVE_LIQ As Long)
        ENTRA = False
        Try
            FgPA.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_FOLIO, GV.CVE_ART, I.DESCR, GV.FECHA, GV.FACTOR, GV.IMPORTE, GV.CVE_OBS, O.DESCR AS STR_OBS, GV.NUM_PAR, GV.UUID
                    FROM GCLIQ_PENSION_ALI GV
                    LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = GV.CVE_ART
                    LEFT JOIN GCOBS O ON O.CVE_OBS = GV.CVE_OBS
                    WHERE GV.CVE_LIQ = " & fCVE_LIQ & " ORDER BY FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgPA.AddItem("" & vbTab & dr("CVE_FOLIO") & vbTab & dr("CVE_ART") & vbTab & "" & vbTab & dr("DESCR") & vbTab &
                                     dr("FECHA") & vbTab & dr("FACTOR") & vbTab & dr("IMPORTE") & vbTab & dr("STR_OBS") & vbTab &
                                     dr("NUM_PAR") & vbTab & dr("CVE_OBS") & vbTab & dr("UUID"))
                    End While
                End Using
                CALCULAR_IMPORTES()
                '                                                     1                          2           3            4          
                '                                                 Documento	               Articulo      button	   descripcion	 
                'FgPA.AddItem(FgPA.Rows.Count & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                'ate.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                '                             5                    6            7            8            9           10            11
                '	       	                fecha	            factor	     total	      OBSER	       NUM_PAR     CVE_OBS       UUID
                Try
                    If Not IsNothing(_myEditorPa) Then
                        _myEditorPa.StartEditing(FgPA.Rows.Count - 1, 2)
                    End If
                Catch ex As Exception
                End Try
            End Using
        Catch ex As Exception
            BITACORA_LIQ("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
        FgPA.Refresh()

    End Sub
    Sub DESPLEGAR_LIQ_DEDUCCIONES(fCVE_LIQ As Long)
        Try 'SQL = "SELECT CVE_DED, DESCR FROM GCDEDUCCIONES WHERE STATUS = 'A' ORDER BY CVE_DED"
            Dim PAGADO As Decimal, s As String, SALDO_ANT As Decimal = 0, ABONOS_ANT As Decimal = 0, SALDO_ACTUAL As Decimal = 0
            Dim SUM_DED As Decimal = 0, NUM_PAR As Integer = 1
            SUMA2 = 0
            FgD.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_FOLIO, ISNULL(GV.CVE_DED,0) CV_DED, ISNULL(GV.DESCR,'') AS DES, ISNULL(DD.DESCR,'') AS DESCRIP, GV.FECHA, 
                    ISNULL(DD.IMPORTE_PRESTAMO,0) AS IMPORT_PRES, ISNULL(DD.IMPORTE_PAGADO,0) AS IMPORT_PAG, ISNULL(DD.SALDO,0) AS SALD, 
                    ISNULL(GV.IMPORTE,0) AS IMPORT, ISNULL(DD.SALDO_ACTUAL,0) AS SALDO_ACT, ISNULL(GV.CVE_OBS,0) AS CVEOBS, ISNULL(O.DESCR,'') AS STR_OBS, 
                    ISNULL(GV.NUM_PAR,0) AS NUMPAR, ISNULL(GV.UUID,'') AS UUI, 
                    ISNULL((SELECT SUM(IMPORTE) FROM GCLIQ_DEDUCCIONES WHERE STATUS = 'A' AND CVE_DED = GV.CVE_DED AND FECHAELAB < GV.FECHAELAB),0) AS ABONOS
                    FROM GCLIQ_DEDUCCIONES GV
                    LEFT JOIN GCDEDUC_OPER DD ON DD.FOLIO = GV.CVE_DED
                    LEFT JOIN GCDEDUCCIONES D ON D.CVE_DED = DD.CVE_DED
                    LEFT JOIN GCOBS O ON O.CVE_OBS = GV.CVE_OBS
                    WHERE GV.CVE_LIQ = " & fCVE_LIQ & " ORDER BY GV.FECHAELAB"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        PAGADO = dr("ABONOS")
                        SALDO_ANT = dr("IMPORT_PRES") - PAGADO
                        SALDO_ACTUAL = dr("IMPORT_PRES") - PAGADO - dr("IMPORT")

                        s = dr("CVE_FOLIO") & vbTab '1
                        s &= dr("CV_DED") & vbTab '2
                        s &= IIf(dr("DES").ToString.Trim.Length > 0, dr("DES"), dr("DESCRIP")) & vbTab '3
                        s &= dr("FECHA") & vbTab '4
                        s &= dr("IMPORT_PRES") & vbTab '5  IMPORTE REPSTAMO
                        s &= PAGADO & vbTab '6   IMPORTE PAGADO
                        s &= SALDO_ANT & vbTab '7  SALDO ANT
                        s &= dr("IMPORT") & vbTab '8  ABONO
                        s &= SALDO_ACTUAL & vbTab '9  SALDO ACTUAL
                        s &= dr("STR_OBS") & vbTab '10
                        s &= dr("NUMPAR") & vbTab '11
                        s &= dr("UUI") & vbTab '12
                        s &= dr("CVEOBS") '13

                        NUM_PAR += 1

                        FgD.AddItem("" & vbTab & s)

                        SUMA2 += dr("IMPORT")
                    End While
                End Using
                LtTotDeduc.Text = Format(SUMA2, "###,###,##0.00")
                Me.Refresh()
            End Using
        Catch ex As Exception
            BITACORA_LIQ("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmLiquidacionesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Liquidación")
        Try
            If FORM_IS_OPEN("frmLiquidaciones") Then
                FrmLiquidaciones.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmLiquidacionesAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim SE_GRABO As Boolean = False, CVE_OBS As Long = 0, PERCEP_VIAJE As Decimal = 0, OTRAS_PER As Decimal = 0, DEDUCCIONES As Decimal = 0
        Dim DIF_COMPROBACION As Decimal = 0, IMPORTE As Decimal = 0, GASTOS_VIAJE As Decimal = 0
        Dim VALES_COMBUSTIBLE As Decimal = 0, SUBTOTAL As Decimal = 0, z As Integer = 0, x As Integer = 0, IMPORTE_A_LIQUIDAR As Decimal
        Dim DESCUENTO As Decimal = 0, CARGO_X_PUNTO_MUERTO As Decimal = 0, DETEC_ERROR_VIOLATION_KEY As Boolean, CVE_LIQ As Long, SIGUE As Boolean

        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If Not Valida_Conexion() Then
            Return
        End If



        If Not IsNothing(_myEditor) Then
            If _myEditor.Visible Then
                '_myEditor.FinishEditing()
                TBotonMagico_GotFocus(Nothing, Nothing)
            End If
        End If

        If SHOW_MENSAJE = "" Then
            If MsgBox("Realmente desea grabar la liquidación?", vbYesNo) = vbNo Then
                Return
            End If
        End If


        If TCVE_OPER.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el operador")
            Return
        End If
        If TCVE_TRACTOR.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la unidad")
            Return
        End If

        Try
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, _FgColSeleccione) Then
                    z += 1
                    Try
                        If IsNothing(Fg(k, _FgColSueldoViaje)) Then
                            x += 1
                        Else
                            If IsNumeric(Fg(k, _FgColSueldoViaje)) Then
                                If Fg(k, _FgColSueldoViaje) = 0 Then
                                    x += 1
                                Else
                                    PERCEP_VIAJE += Fg(k, _FgColSueldoViaje)
                                End If
                            Else
                                x += 1
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            BITACORA_LIQ("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If z = 0 Then
            MsgBox("No hay viajes a liquidar, verifique por favor")
            Return
        End If
        'If x > 0 Then
        'MsgBox("Por favor capture el sueldo del viaje")
        'Return
        'End If
        Try
            If TOBS.Text.Trim.Length > 0 Then
                If IsNumeric(TOBS.Tag) Then
                    CVE_OBS = TOBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & TOBS.Text & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & TOBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            End If
            TOBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORA_LIQ("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtGastosDeViaje.Text.Replace(",", "")) Then
                GASTOS_VIAJE = LtGastosDeViaje.Text.Replace(",", "")
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(LtValesCombustible.Text.Replace(",", "")) Then
                VALES_COMBUSTIBLE = LtValesCombustible.Text.Replace(",", "")
            End If
        Catch ex As Exception
        End Try
        Try
            'If IsNumeric(LtPerXViaje.Text.Replace(",", "")) Then
            'PERCEP_VIAJE = LtPerXViaje.Text
            'End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtOtrasPercep.Text.Replace(",", "")) Then
                OTRAS_PER = LtOtrasPercep.Text.Replace(",", "")
            End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtTotDeduc.Text.Replace(",", "")) Then
                DEDUCCIONES = LtTotDeduc.Text.Replace(",", "")
            End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtDifCompro.Text.Replace(",", "")) Then
                DIF_COMPROBACION = LtDifCompro.Text.Replace(",", "")
            End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtSubtotal.Text.Replace(",", "")) Then
                SUBTOTAL = LtSubtotal.Text.Replace(",", "")
            End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If IsNumeric(LtImporteLiquidar.Text.Replace(",", "")) Then
                IMPORTE = LtImporteLiquidar.Text.Replace(",", "")
            End If
        Catch ex As Exception
            BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Dim FOLIO As Long, FOLIO2 As Long, FOLIO3 As Long, CVE_DED_OPER As Long, LTS_DESCONTAR As Decimal = 0, LITROS As Decimal = 0

        If GpoEvento1.Visible Then
            Try
                If IsNumeric(LtDescXLitros.Text.Replace(",", "")) Then
                    LTS_DESCONTAR = LtDescXLitros.Text.Replace(",", "")
                End If
                If IsNumeric(LtLTS_VALES.Text.Replace(",", "")) Then
                    LITROS = LtLTS_VALES.Text.Replace(",", "")
                End If
            Catch ex As Exception
                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                If IsNumeric(LtDescXLitros2.Text.Replace(",", "")) Then
                    LTS_DESCONTAR = LtDescXLitros2.Text.Replace(",", "")
                End If
                If IsNumeric(TLTS_DESCONTAR2.Text.Replace(",", "")) Then
                    LITROS = TLTS_DESCONTAR2.Text.Replace(",", "")
                End If
            Catch ex As Exception
                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        If IsNew Then
            'AQUI SE VALIDARA QUE NO EXISTA LA LIQUIDACION CUANDO ES NUEVO

            CVE_LIQ = CONVERTIR_TO_INT(TCVE_LIQ.Text)

            Try
                SIGUE = True
                Do While SIGUE
                    If EXISTE_LIQUIDACION(CVE_LIQ) Then
                        CVE_LIQ += 1
                    Else
                        SIGUE = False
                    End If
                Loop
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


            SQL = "INSERT INTO GCLIQUIDACIONES (CVE_LIQ, STATUS, FECHA, CVE_OPER, CVE_UNI, CVE_RES, CVE_ST_LIQ, CVE_OBS, GASTOS_VIAJE, 
                VALES_COMBUSTIBLE, PERCEP_X_VIAJE, OTRAS_PERCEP, DEDUCCIONES, DIF_COMPROBACION, SUBTOTAL, IMPORTE, CVE_DED_RES, 
                CVE_DED_DESCUENTO, CVE_DED_CARGO_P_MUERTO, FECHAELAB, UUID) 
                VALUES (
                @CVE_LIQ, 'A', @FECHA, @CVE_OPER, @CVE_UNI, @CVE_RES, @CVE_ST_LIQ, @CVE_OBS, @GASTOS_VIAJE, @VALES_COMBUSTIBLE, 
                @PERCEP_X_VIAJE, @OTRAS_PERCEP, @DEDUCCIONES, @DIF_COMPROBACION, @SUBTOTAL, @IMPORTE, @CVE_DED_RES, 
                @CVE_DED_DESCUENTO, @CVE_DED_CARGO_P_MUERTO, GETDATE(), NEWID())"
        Else

            CVE_LIQ = TCVE_LIQ.Text

            SQL = "UPDATE GCLIQUIDACIONES SET CVE_OPER = @CVE_OPER, CVE_UNI = @CVE_UNI, CVE_RES = @CVE_RES, CVE_ST_LIQ = @CVE_ST_LIQ, 
                GASTOS_VIAJE = @GASTOS_VIAJE, VALES_COMBUSTIBLE = @VALES_COMBUSTIBLE, PERCEP_X_VIAJE = @PERCEP_X_VIAJE, 
                OTRAS_PERCEP = @OTRAS_PERCEP, DEDUCCIONES = @DEDUCCIONES, DIF_COMPROBACION = @DIF_COMPROBACION, SUBTOTAL = @SUBTOTAL, 
                IMPORTE = @IMPORTE, CVE_OBS = @CVE_OBS, CVE_DED_RES = @CVE_DED_RES, CVE_DED_DESCUENTO = @CVE_DED_DESCUENTO,
                CVE_DED_CARGO_P_MUERTO = @CVE_DED_CARGO_P_MUERTO
                WHERE CVE_LIQ = @CVE_LIQ"
        End If
        cmd.CommandText = SQL

        DETEC_ERROR_VIOLATION_KEY = False
        Try
            For k = 1 To 5
                Try
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CVE_LIQ
                    cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                    cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                    cmd.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_RES.Text)
                    cmd.Parameters.Add("@GASTOS_VIAJE", SqlDbType.Float).Value = GASTOS_VIAJE
                    cmd.Parameters.Add("@VALES_COMBUSTIBLE", SqlDbType.Float).Value = VALES_COMBUSTIBLE
                    cmd.Parameters.Add("@PERCEP_X_VIAJE", SqlDbType.Float).Value = PERCEP_VIAJE
                    cmd.Parameters.Add("@OTRAS_PERCEP", SqlDbType.Float).Value = OTRAS_PER
                    cmd.Parameters.Add("@DEDUCCIONES", SqlDbType.Float).Value = DEDUCCIONES
                    cmd.Parameters.Add("@DIF_COMPROBACION", SqlDbType.Float).Value = DIF_COMPROBACION
                    cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = SUBTOTAL
                    cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPORTE
                    cmd.Parameters.Add("@CVE_ST_LIQ", SqlDbType.Int).Value = 1
                    cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                    cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value ' FECHA LIQUIDACION
                    cmd.Parameters.Add("@CVE_DED_RES", SqlDbType.Int).Value = FOLIO
                    cmd.Parameters.Add("@CVE_DED_DESCUENTO", SqlDbType.Int).Value = FOLIO2
                    cmd.Parameters.Add("@CVE_DED_CARGO_P_MUERTO", SqlDbType.Int).Value = FOLIO3
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If

                    SE_GRABO = True
                    GRABAR_LIQ_PARTIDAS(CVE_LIQ) 'Fg   GCLIQ_PARTIDAS 
                    GRABAR_LIQ_GASTOS_VIAJE(CVE_LIQ) 'FgG  GCASIGNACION_VIAJE_GASTOS 
                    GRABAR_LIQ_VALES_VIAJE(CVE_LIQ) 'FgV   UPDATE GCASIGNACION_VIAJE_VALES 
                    GRABAR_LIQ_GASTOS_COMPROBADOS(CVE_LIQ) 'FgGC   GCLIQ_GASTOS_COMPROBADOS 
                    GRABAR_LIQ_DEDUCCIONES(CVE_LIQ) 'FgD   GCLIQ_DEDUCCIONES 
                    GRABAR_LIQ_PENSION_ALIMENTICIA(CVE_LIQ)
                    GRABAR_LIQ_CASETAS(CVE_LIQ)

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
                    BITACORA_LIQ("100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If Not Valida_Conexion() Then
                End If

                If DETEC_ERROR_VIOLATION_KEY Then
                    CVE_LIQ = GET_MAX("GCLIQUIDACIONES", "CVE_LIQ")
                End If
            Next
            If SE_GRABO Then

                'RUTINA PARA GRABAR LAS DEDUCCIONES

                If LTS_DESCONTAR < 0 Then
                    If Not Valida_Conexion() Then
                    End If

                    If IsNumeric(TCVE_RES.Tag) Then
                        FOLIO = CInt(TCVE_RES.Tag)
                    Else
                        FOLIO = 0
                    End If
                    If FOLIO = 0 Then
                        CVE_DED_OPER = GET_MAX("GCDEDUC_OPER", "CVE_DED_OPER")
                        FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
                    End If
                    'DEDUCCION LITROS A DESCONTAR 7
                    SQL = "UPDATE GCDEDUC_OPER SET IMPORTE_PRESTAMO = @IMPORTE_PRESTAMO, CVE_RES = @CVE_RES WHERE FOLIO = @FOLIO
                        IF @@ROWCOUNT = 0
                        INSERT INTO GCDEDUC_OPER (CVE_DED_OPER, FOLIO, CVE_OPER, CVE_LIQ, CVE_DED, STATUS, DESCR, IMPORTE_PRESTAMO, IMPORTE_PAGADO, SALDO, 
                        PAGO_EN_LIQ, SALDO_ACTUAL, FECHA, CVE_RES, FECHAELAB, UUID) VALUES (@CVE_DED_OPER, @FOLIO, @CVE_OPER, @CVE_LIQ, @CVE_DED, 'A', @DESCR, 
                        @IMPORTE_PRESTAMO, @IMPORTE_PAGADO, @SALDO, @PAGO_EN_LIQ, @SALDO_ACTUAL, @FECHA, @CVE_RES, GETDATE(), NEWID())"
                    Try
                        DETEC_ERROR_VIOLATION_KEY = False
                        For j = 1 To 5
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    cmd2.Parameters.Add("@CVE_DED_OPER", SqlDbType.Int).Value = CVE_DED_OPER
                                    cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                                    cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                    cmd2.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CVE_LIQ
                                    cmd2.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = 7
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = "RESETEO " & TCVE_RES.Text & " Litros a descontar " & Math.Abs(LITROS)
                                    cmd2.Parameters.Add("@IMPORTE_PRESTAMO", SqlDbType.Float).Value = Math.Abs(LTS_DESCONTAR)
                                    cmd2.Parameters.Add("@IMPORTE_PAGADO", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO", SqlDbType.Float).Value = Math.Abs(LTS_DESCONTAR)
                                    cmd2.Parameters.Add("@PAGO_EN_LIQ", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                                    cmd2.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_RES.Text)
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                                TCVE_RES.Tag = FOLIO
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
                                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try

                            If Not Valida_Conexion() Then
                            End If

                            If DETEC_ERROR_VIOLATION_KEY Then
                                FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
                            End If
                        Next

                        SQL = "UPDATE GCLIQUIDACIONES SET CVE_DED_RES = " & FOLIO & " WHERE CVE_LIQ = " & CVE_LIQ
                        EXECUTE_QUERY_NET(SQL)

                    Catch ex As Exception
                        BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                End If
                Try
                    If IsNumeric(TDESCT.Text.Replace(",", "")) Then
                        DESCUENTO = CDec(TDESCT.Text.Replace(",", ""))
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                If DESCUENTO > 0 Then
                    'DEDUCCION descuento 3
                    If Not Valida_Conexion() Then
                    End If

                    If IsNumeric(TDESCT.Tag) Then
                        FOLIO2 = CInt(TDESCT.Tag)
                    Else
                        FOLIO2 = 0
                    End If
                    If FOLIO2 = 0 Then
                        CVE_DED_OPER = GET_MAX("GCDEDUC_OPER", "CVE_DED_OPER")
                        FOLIO2 = GET_MAX("GCDEDUC_OPER", "FOLIO")
                    End If

                    SQL = "UPDATE GCDEDUC_OPER SET IMPORTE_PRESTAMO = @IMPORTE_PRESTAMO, CVE_RES = @CVE_RES WHERE FOLIO = @FOLIO
                        IF @@ROWCOUNT = 0
                        INSERT INTO GCDEDUC_OPER (CVE_DED_OPER, FOLIO, CVE_OPER, CVE_LIQ, CVE_DED, STATUS, DESCR, IMPORTE_PRESTAMO, IMPORTE_PAGADO, SALDO, 
                        PAGO_EN_LIQ, SALDO_ACTUAL, FECHA, CVE_RES, FECHAELAB, UUID) VALUES (@CVE_DED_OPER, @FOLIO, @CVE_OPER, @CVE_LIQ, @CVE_DED, 'A', @DESCR, 
                        @IMPORTE_PRESTAMO, @IMPORTE_PAGADO, @SALDO, @PAGO_EN_LIQ, @SALDO_ACTUAL, @FECHA, @CVE_RES, GETDATE(), NEWID())"
                    Try
                        DETEC_ERROR_VIOLATION_KEY = False
                        For j = 1 To 5
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    cmd2.Parameters.Add("@CVE_DED_OPER", SqlDbType.Int).Value = CVE_DED_OPER
                                    cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO2
                                    cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                    cmd2.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CVE_LIQ
                                    cmd2.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = 3
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = "RESETEO " & TCVE_RES.Text & " DESCUENTO"
                                    cmd2.Parameters.Add("@IMPORTE_PRESTAMO", SqlDbType.Float).Value = Math.Abs(DESCUENTO)
                                    cmd2.Parameters.Add("@IMPORTE_PAGADO", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO", SqlDbType.Float).Value = Math.Abs(DESCUENTO)
                                    cmd2.Parameters.Add("@PAGO_EN_LIQ", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                                    cmd2.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_RES.Text)
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                                TDESCT.Tag = FOLIO2
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
                                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                            If Not Valida_Conexion() Then
                            End If
                            If DETEC_ERROR_VIOLATION_KEY Then
                                FOLIO2 = GET_MAX("GCDEDUC_OPER", "FOLIO")
                            End If
                        Next

                        SQL = "UPDATE GCLIQUIDACIONES SET CVE_DED_DESCUENTO = " & FOLIO2 & " WHERE CVE_LIQ = " & CVE_LIQ

                        EXECUTE_QUERY_NET(SQL)
                    Catch ex As Exception
                        BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                End If

                Try
                    If IsNumeric(TCARGO_X_PUNTO_MUERTO.Text.Replace(",", "")) Then
                        CARGO_X_PUNTO_MUERTO = CDec(TCARGO_X_PUNTO_MUERTO.Text.Replace(",", ""))
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

                If CARGO_X_PUNTO_MUERTO > 0 Then
                    'DECUCCION cargo x punto muerto  5
                    If Not Valida_Conexion() Then
                    End If

                    If IsNumeric(TCARGO_X_PUNTO_MUERTO.Tag) Then
                        FOLIO3 = CInt(TCARGO_X_PUNTO_MUERTO.Tag)
                    Else
                        FOLIO3 = 0
                    End If

                    If FOLIO3 = 0 Then
                        CVE_DED_OPER = GET_MAX("GCDEDUC_OPER", "CVE_DED_OPER")
                        FOLIO3 = GET_MAX("GCDEDUC_OPER", "FOLIO")
                    End If

                    SQL = "UPDATE GCDEDUC_OPER SET IMPORTE_PRESTAMO = @IMPORTE_PRESTAMO, CVE_RES = @CVE_RES WHERE FOLIO = @FOLIO
                        IF @@ROWCOUNT = 0
                        INSERT INTO GCDEDUC_OPER (CVE_DED_OPER, FOLIO, CVE_OPER, CVE_LIQ, CVE_DED, STATUS, DESCR, IMPORTE_PRESTAMO, IMPORTE_PAGADO, SALDO, 
                        PAGO_EN_LIQ, SALDO_ACTUAL, FECHA, CVE_RES, FECHAELAB, UUID) VALUES (@CVE_DED_OPER, @FOLIO, @CVE_OPER, @CVE_LIQ, @CVE_DED, 'A', @DESCR, 
                        @IMPORTE_PRESTAMO, @IMPORTE_PAGADO, @SALDO, @PAGO_EN_LIQ, @SALDO_ACTUAL, @FECHA, @CVE_RES, GETDATE(), NEWID())"
                    Try
                        DETEC_ERROR_VIOLATION_KEY = False
                        For j = 1 To 5
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    cmd2.Parameters.Add("@CVE_DED_OPER", SqlDbType.Int).Value = CVE_DED_OPER
                                    cmd2.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO3
                                    cmd2.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                    cmd2.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CVE_LIQ
                                    cmd2.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = 5
                                    cmd2.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = "RESETEO " & TCVE_RES.Text & " CARGO POR PUNTO MUERTO"
                                    cmd2.Parameters.Add("@IMPORTE_PRESTAMO", SqlDbType.Float).Value = Math.Abs(CARGO_X_PUNTO_MUERTO)
                                    cmd2.Parameters.Add("@IMPORTE_PAGADO", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO", SqlDbType.Float).Value = Math.Abs(CARGO_X_PUNTO_MUERTO)
                                    cmd2.Parameters.Add("@PAGO_EN_LIQ", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Float).Value = 0
                                    cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                                    cmd2.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_RES.Text)
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                                TCARGO_X_PUNTO_MUERTO.Tag = FOLIO3
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
                                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                            If Not Valida_Conexion() Then
                            End If
                            If DETEC_ERROR_VIOLATION_KEY Then
                                FOLIO3 = GET_MAX("GCDEDUC_OPER", "FOLIO")
                            End If
                        Next

                        SQL = "UPDATE GCLIQUIDACIONES SET CVE_DED_CARGO_P_MUERTO = " & FOLIO3 & " WHERE CVE_LIQ = " & CVE_LIQ

                        EXECUTE_QUERY_NET(SQL)

                    Catch ex As Exception
                        BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                End If


                If Not Valida_Conexion() Then
                End If

                IMPORTE_A_LIQUIDAR = CALCULAR_IMPORTES_FINAL_AL_GRABAR()

                If IMPORTE = 0 Then
                    BACKUPTXT("IMPORTE_LIQ", "LIQUIDACION:" & CVE_LIQ & ", IMPORTE_A_LIQUIDAR = " & IMPORTE_A_LIQUIDAR & ", IMPORTE ORIGINAL = " & IMPORTE)
                Else
                    BACKUPTXT("IMPORTE_LIQ", "LIQUIDACION:" & CVE_LIQ & ", IMPORTE_A_LIQUIDAR = " & IMPORTE_A_LIQUIDAR & ", IMPORTE ORIGINAL = " & IMPORTE)
                End If


                Try
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = "UPDATE GCRESETEO SET ESTADO = 'EN LIQUIDACION' WHERE CVE_RES = " & CONVERTIR_TO_INT(TCVE_RES.Text)
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If SHOW_MENSAJE = "" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                End If

            Else
                If SHOW_MENSAJE = "" Then
                    MsgBox("No se logro grabar el registro")
                End If

            End If
        Catch ex As Exception
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORA_LIQ("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Focus()
            BarGrabar.Enabled = True
            BarFinalizarLiq.Enabled = True
            BarImprimirLiq.Enabled = True
            BarDesplegar.Enabled = False

            TCVE_LIQ.Text = CVE_LIQ

        Catch ex As Exception
        End Try

        IsNew = False

    End Sub
    Private Sub GRABAR_LIQ_CASETAS(FCVE_LIQ)


        SQL = "DELETE FROM GCLIQ_CASETAS WHERE CVE_LIQ = " & FCVE_LIQ
        EXECUTE_QUERY_NET(SQL)

        For k = 1 To FgCasetas.Rows.Count - 1
            Try
                If FgCasetas(k, 1) Then
                    SQL = "INSERT INTO GCLIQ_CASETAS (CVE_LIQ, CVE_CXR, FECHA, CVE_PLAZA, CVE_PLAZA2, IMPORTE, FECHAELAB, UUID)
                    VALUES(@CVE_LIQ, @CVE_CXR, CONVERT(varchar, GETDATE(), 112), @CVE_PLAZA, @CVE_PLAZA2, @IMPORTE, GETDATE(), NEWID())"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = FCVE_LIQ
                        cmd.Parameters.Add("@CVE_CXR", SqlDbType.Int).Value = CONVERTIR_TO_INT(FgCasetas(k, 2))
                        cmd.Parameters.Add("@CVE_PLAZA", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(FgCasetas(k, 3))
                        cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(FgCasetas(k, 5))
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCasetas(k, 7))
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    End Using
                End If
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        Next

    End Sub
    Private Function VERIFICAR_SIGUIENTE_FOLIO_GCDEDUC_OPER(fCVE_DED_OPER As Long) As Long
        Dim SIGUE As Boolean = True
        Try
            Do While SIGUE

                If Not Valida_Conexion() Then
                End If

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_DED_OPER FROM GCDEDUC_OPER WHERE CVE_DED_OPER = " & fCVE_DED_OPER
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            fCVE_DED_OPER += 1
                        Else
                            SIGUE = False
                        End If
                    End Using
                End Using
            Loop
            Return fCVE_DED_OPER
        Catch ex As Exception
            BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Return fCVE_DED_OPER
        End Try
    End Function

    Sub GRABAR_LIQ_PARTIDAS(FCVE_LIQ As Long)
        Dim cmd As New SqlCommand With {.Connection = cnSAE}
        Dim SUELDO As Decimal = 0, d1 As Date = Now, FECHA As Date, NUM_PAR As Integer = 0
        Dim SQLx As String, CVE_SUOP As Long = 0

        'TAB 1     TAB 1     TAB 1     TAB 1     TAB 1     TAB 1     TAB 1     TAB 1     TAB 1     
        SQL = "UPDATE GCLIQ_PARTIDAS SET CVE_CAP1 = @CVE_CAP1, CVE_CAP2 = @CVE_CAP2, TIPO_VIAJE = @TIPO_VIAJE, TIPO_UNIDAD = @TIPO_UNIDAD, 
            FECHA_VIAJE = @FECHA_VIAJE, CVE_UNI = @CVE_UNI, CLAVE_O = @CLAVE_O, CLAVE_D = @CLAVE_D, CVE_ST_VIA = @CVE_ST_VIA, SUELDO = @SUELDO, 
            @CVE_SUOP = CVE_SUOP, SEL_CALCULO = @SEL_CALCULO, PORC_SUELDO = @PORC_SUELDO, SUELDO_MANIOBRA = @SUELDO_MANIOBRA, 
            PORC_SUELDO_MANIOBRA = @PORC_SUELDO_MANIOBRA, SDO_X_TONELADA = @SDO_X_TONELADA, SDO_MANIOBRA_X_TONELADA = @SDO_MANIOBRA_X_TONELADA
            WHERE UUID = @UUID AND STATUS = 'A'
            IF @@ROWCOUNT = 0
            INSERT INTO GCLIQ_PARTIDAS (CVE_LIQ, CVE_VIAJE, NUM_PAR, STATUS, CVE_CAP1, CVE_CAP2, TIPO_VIAJE, TIPO_UNIDAD, FECHA_VIAJE, CVE_UNI, 
            CLAVE_O, CLAVE_D, CVE_ST_VIA, SUELDO, CVE_SUOP, FECHAELAB, UUID, SEL_CALCULO, PORC_SUELDO, SUELDO_MANIOBRA, PORC_SUELDO_MANIOBRA, SDO_X_TONELADA, SDO_MANIOBRA_X_TONELADA) 
            VALUES (
            @CVE_LIQ, @CVE_VIAJE, ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCLIQ_PARTIDAS WHERE CVE_LIQ = @CVE_LIQ),1), 'A', @CVE_CAP1, @CVE_CAP2, 
            @TIPO_VIAJE, @TIPO_UNIDAD, @FECHA_VIAJE, @CVE_UNI, @CLAVE_O, @CLAVE_D, @CVE_ST_VIA, @SUELDO, @CVE_SUOP, GETDATE(), @UUID, @SEL_CALCULO, @PORC_SUELDO, @SUELDO_MANIOBRA, @PORC_SUELDO_MANIOBRA, @SDO_X_TONELADA, @SDO_MANIOBRA_X_TONELADA)"

        For k = 1 To Fg.Rows.Count - 1
            Try
                If Fg(k, _FgColSeleccione) Then
                    If Not IsNothing(Fg(k, _FgColNumViaje)) Then
                        If Not String.IsNullOrEmpty(Fg(k, _FgColNumViaje)) Then
                            If Fg(k, _FgColNumViaje).ToString.Trim.Length > 0 Then
                                Try
                                    SUELDO = 0
                                    If Not IsNothing(Fg(k, _FgColSueldoViaje)) Then
                                        If Not String.IsNullOrEmpty(Fg(k, _FgColSueldoViaje)) Then
                                            SUELDO = Fg(k, _FgColSueldoViaje)
                                            Try
                                                CVE_SUOP = Fg(k, _FgColPuntos)
                                            Catch ex As Exception
                                            End Try
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("130. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    NUM_PAR = 0
                                    If Not IsNothing(Fg(k, _FgColNumPar)) Then
                                        If Not String.IsNullOrEmpty(Fg(k, _FgColNumPar)) Then
                                            If IsNumeric(Fg(k, _FgColNumPar).ToString.Trim) Then
                                                NUM_PAR = CONVERTIR_TO_INT(CInt(Fg(k, _FgColNumPar).ToString.Trim))
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    FECHA = d1.ToShortDateString
                                    If Not IsNothing(Fg(k, _FgColFCargaPRog)) Then
                                        If Not String.IsNullOrEmpty(Fg(k, _FgColFCargaPRog)) Then
                                            If IsDate(Fg(k, _FgColFCargaPRog)) Then
                                                FECHA = Fg(k, _FgColFCargaPRog)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                If Valida_Conexion() Then
                                    Try 'TAB1                      TAB1                      TAB1
                                        cmd.CommandText = SQL
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = FCVE_LIQ
                                        cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = Fg(k, _FgColNumViaje)
                                        cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                        cmd.Parameters.Add("@CVE_CAP1", SqlDbType.VarChar).Value = Fg(k, _FgColNumCPorte)
                                        cmd.Parameters.Add("@CVE_CAP2", SqlDbType.VarChar).Value = Fg(k, _FgColNumCPorte2)
                                        cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.SmallInt).Value = IIf(Fg(k, _FgColTipoViaje) = "Full", 1, 0)
                                        cmd.Parameters.Add("@TIPO_UNIDAD", SqlDbType.SmallInt).Value = IIf(Fg(k, _FgColTipoUnidad) = "Cargado", 1, 0)
                                        cmd.Parameters.Add("@FECHA_VIAJE", SqlDbType.Date).Value = FECHA
                                        cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = Fg(k, _FgColUnidad)
                                        cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = Fg(k, _FgColClaveOrigen)
                                        cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = Fg(k, _FgColClaveDestino)
                                        cmd.Parameters.Add("@CVE_ST_VIA", SqlDbType.SmallInt).Value = 0
                                        cmd.Parameters.Add("@SUELDO", SqlDbType.Float).Value = SUELDO
                                        cmd.Parameters.Add("@CVE_SUOP", SqlDbType.Float).Value = CVE_SUOP
                                        cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = Fg(k, _FgColUUID)
                                        cmd.Parameters.Add("@SEL_CALCULO", SqlDbType.Bit).Value = IIf(Fg(k, _FgColSelCalculo), 1, 0)
                                        cmd.Parameters.Add("@PORC_SUELDO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, _FgColPorcSueldo))
                                        cmd.Parameters.Add("@SUELDO_MANIOBRA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, _FgColSueldoManiobra))
                                        cmd.Parameters.Add("@PORC_SUELDO_MANIOBRA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, _FgColPorcSdoManiobra))
                                        cmd.Parameters.Add("@SDO_X_TONELADA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, _FgColSdoPorTonedada))
                                        cmd.Parameters.Add("@SDO_MANIOBRA_X_TONELADA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, _FgColSdoManiobraPorTonedada))


                                        returnValue = cmd.ExecuteNonQuery
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                Try
                                                    SQLx = "UPDATE GCASIGNACION_VIAJE SET CVE_ST_VIA = 5 WHERE CVE_VIAJE = '" & Fg(k, _FgColNumViaje) & "'"
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQLx
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                                    MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End If
                                        End If
                                        Fg(k, _FgColPuntos) = returnValue
                                    Catch ex As Exception
                                        BITACORA_LIQ("170. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End If
                        End If
                    End If
                Else
                    If Valida_Conexion() Then
                        Try
                            SQLx = "UPDATE GCASIGNACION_VIAJE SET CVE_ST_VIA = 4 WHERE CVE_VIAJE = '" & Fg(k, _FgColNumViaje) & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQLx
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORA_LIQ("180. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQLx = "DELETE FROM GCLIQ_GASTOS_VIAJE WHERE CVE_LIQ = '" & FCVE_LIQ & "' AND CVE_VIAJE = '" & Fg(k, _FgColNumViaje) & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQLx
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORA_LIQ("190. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQLx = "DELETE FROM GCLIQ_VALES_VIAJE WHERE CVE_LIQ = '" & FCVE_LIQ & "' AND CVE_VIAJE = '" & Fg(k, _FgColNumViaje) & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQLx
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORA_LIQ("210. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("220. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        Try
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Not Fg(k, _FgColSeleccione) Then
                        If Not IsNothing(Fg(k, _FgColNumPar)) Then
                            If Not String.IsNullOrEmpty(Fg(k, _FgColNumPar)) Then
                                If IsNumeric(Fg(k, _FgColNumPar).ToString.Trim) Then

                                    If Valida_Conexion() Then
                                        SQL = "DELETE FROM GCLIQ_PARTIDAS WHERE UUID = '" & Fg(k, _FgColUUID) & "'"
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("230. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("230. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            BITACORA_LIQ("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_LIQ_GASTOS_VIAJE(FCVE_LIQ As Long)
        Dim STATUS As String = "", CVE_VIAJE As String
        'GASTOS DE VIAJE
        'TAB2                      TAB2                      TAB2

        If Not Valida_Conexion() Then
            Return
        End If

        SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET CVE_LIQ = @CVE_LIQ, STATUS = @STATUS WHERE UUID = @UUID"

        For k = 1 To FgG.Rows.Count - 1
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    Try 'TAB2                      TAB2                      TAB2

                        If IsNothing(FgG(k, 2)) Then
                            CVE_VIAJE = ""
                        Else
                            CVE_VIAJE = FgG(k, 2)
                        End If

                        If CVE_VIAJE.Trim.Length > 0 Then
                            If FgG(k, 1) Then
                                For j = 1 To Fg.Rows.Count - 1
                                    Try
                                        If Fg(j, _FgColNumViaje) = CVE_VIAJE Then
                                            If FgG(k, 1) Then
                                                STATUS = "L"
                                            Else
                                                STATUS = "A"
                                            End If
                                            Exit For
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("270. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                Next
                                If Valida_Conexion() Then

                                    cmd.CommandText = SQL
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = IIf(FgG(k, 1), FCVE_LIQ, 0)
                                    cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS
                                    cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = FgG(k, 10)
                                    returnValue = cmd.ExecuteNonQuery
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("270. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        MsgBox("270. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                End Using
            Catch ex As Exception
                BITACORA_LIQ("280. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("280. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Next
    End Sub
    Sub GRABAR_LIQ_VALES_VIAJE(FCVE_LIQ As Long)
        Dim CVE_VIAJE As String, STATUS As String = "A"
        'TAB3                      TAB3                      TAB3
        'GCASIGNACION_VIAJE_VALES

        SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET CVE_LIQ = @CVE_LIQ WHERE UUID = @UUID"

        For k = 1 To FgV.Rows.Count - 1
            Try
                If Not IsNothing(FgV(k, 15)) Then
                    If FgV(k, 15).ToString.Trim.Length > 0 Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            Try 'TAB3                      TAB3                      TAB3

                                CVE_VIAJE = FgV(k, 1)

                                For j = 1 To Fg.Rows.Count - 1
                                    If Fg(j, _FgColNumViaje) = CVE_VIAJE Then
                                        If Fg(j, _FgColSeleccione) Then
                                            STATUS = "L"
                                        Else
                                            STATUS = "A"
                                        End If
                                        Exit For
                                    End If
                                Next
                                If Valida_Conexion() Then
                                    cmd.CommandText = SQL
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = IIf(STATUS = "L", FCVE_LIQ, 0)
                                    cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = STATUS
                                    cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = FgV(k, 15)
                                    Try
                                        returnValue = cmd.ExecuteNonQuery
                                    Catch ex As Exception
                                        BITACORA_LIQ("370. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If

                                    FgV(k, 14) = "OK"

                                End If
                            Catch ex As Exception
                                BITACORA_LIQ("370. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                MsgBox("370. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End Using
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("380. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("380. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Next
    End Sub
    Sub GRABAR_LIQ_GASTOS_COMPROBADOS(FCVE_LIQ As Long)
        Dim NUM_PAR As Integer = 0, CVE_OBS As Long = 0, SQL2 As String
        'TAB4                      TAB4                      TAB4

        'Documento	Referencia	Articulo	button	descripcion	prov button	nombre	fecha	subtotal	iva	ieps	total	obser	IEPS	IVA	NUM_PAR

        For k = 1 To FgGC.Rows.Count - 1
            Try
                If FgGC.Rows(k).IsVisible Then
                    If Not IsNothing(FgGC(k, 1)) Then
                        If Not String.IsNullOrEmpty(FgGC(k, 1)) Then
                            If FgGC(k, 2).ToString.Trim.Length > 0 Then
                                Try
                                    NUM_PAR = 0
                                    If Not IsNothing(FgGC(k, 17)) Then
                                        If Not String.IsNullOrEmpty(FgGC(k, 17)) Then
                                            If IsNumeric(FgGC(k, 17).ToString.Trim) Then
                                                NUM_PAR = CONVERTIR_TO_INT(FgGC(k, 17).ToString.Trim)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("440. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                'OBSERVACIONES
                                Try
                                    CVE_OBS = 0
                                    If Not IsNothing(FgGC(k, 14)) Then
                                        If FgGC(k, 14).ToString.Trim.Length > 0 Then
                                            If IsNothing(FgGC(k, 18)) Then
                                                CVE_OBS = 0
                                            Else
                                                If IsNumeric(FgGC(k, 18)) Then
                                                    CVE_OBS = FgGC(k, 18)
                                                Else
                                                    CVE_OBS = 0
                                                End If
                                            End If
                                            If Valida_Conexion() Then
                                                If CVE_OBS = 0 Then
                                                    SQL2 = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS 
                                                    VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & FgGC(k, 14) & "')"
                                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                                        cmd.CommandText = SQL2
                                                        returnValue = cmd.ExecuteScalar.ToString
                                                        If returnValue IsNot Nothing Then
                                                            If CLng(returnValue) > 0 Then
                                                                CVE_OBS = returnValue
                                                            End If
                                                        End If
                                                    End Using
                                                Else
                                                    SQL2 = "UPDATE GCOBS SET DESCR = '" & FgGC(k, 14) & "' WHERE CVE_OBS = " & CVE_OBS
                                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                                        cmd.CommandText = SQL2
                                                        returnValue = cmd.ExecuteNonQuery.ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                End If
                                            End If
                                        End If
                                        FgGC(k, 18) = CVE_OBS
                                    End If
                                Catch ex As Exception
                                    MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                    BITACORA_LIQ("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                If Valida_Conexion() Then
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        Try 'TAB4                      TAB4                      TAB4
                                            SQL = "UPDATE GCLIQ_GASTOS_COMPROBADOS SET CVE_DOC = @CVE_DOC, REFER = @REFER, CVE_ART = @CVE_ART, CVE_PROV = @CVE_PROV, FECHA = @FECHA, 
                                                SUBTOTAL = @SUBTOTAL, IVA = @IVA, TOTAL = @TOTAL, CVE_OBS = @CVE_OBS
                                                WHERE CVE_LIQ = @CVE_LIQ AND NUM_PAR = @NUM_PAR
                                                IF @@ROWCOUNT = 0
                                                INSERT INTO GCLIQ_GASTOS_COMPROBADOS (CVE_LIQ, CVE_VIAJE, NUM_PAR, STATUS, CVE_DOC, REFER, CVE_ART, CVE_PROV, FECHA, SUBTOTAL, 
                                                IVA, IEPS, TOTAL, CVE_OBS, FECHAELAB, UUID) 
                                                OUTPUT Inserted.NUM_PAR VALUES (
                                                @CVE_LIQ, '', ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCLIQ_GASTOS_COMPROBADOS WHERE CVE_LIQ = @CVE_LIQ),1),'A', 
                                                @CVE_DOC, @REFER, @CVE_ART, @CVE_PROV, @FECHA, @SUBTOTAL, @IVA, @IEPS, @TOTAL, @CVE_OBS, GETDATE(), NEWID())"

                                            cmd.CommandText = SQL
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = FCVE_LIQ
                                            cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC")
                                            cmd.Parameters.Add("@REFER", SqlDbType.VarChar).Value = FgGC(k, 2)
                                            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = FgGC(k, 3)
                                            cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = FgGC(k, 6)
                                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgGC(k, 9)
                                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgGC(k, 10)), 4)
                                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgGC(k, 11)), 4)
                                            cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgGC(k, 12)), 4)
                                            cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgGC(k, 13)), 4)
                                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                                            'SE CORRIGIO PROBLEMA DE DUPLICIDAD DE FOLIO 10-NOV-2022
                                            Try
                                                returnValue = cmd.ExecuteScalar()
                                            Catch ex As Exception
                                                returnValue = NUM_PAR
                                            End Try
                                            If returnValue IsNot Nothing Then
                                                FgGC(k, 17) = returnValue
                                            Else
                                                FgGC(k, 17) = NUM_PAR
                                            End If

                                        Catch ex As Exception
                                            BITACORA_LIQ("500. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            MsgBox("500. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try
                                    End Using
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("510. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("510. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Next

        Try
            For k = 1 To FgGC.Rows.Count - 1
                If Not FgGC.Rows(k).IsVisible Then
                    Try
                        If IsNumeric(FgGC(k, 17)) Then

                            If Valida_Conexion() Then
                                SQL = "DELETE FROM GCLIQ_GASTOS_COMPROBADOS WHERE CVE_LIQ = '" & FCVE_LIQ & "' AND NUM_PAR = " & FgGC(k, 17)
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
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
                        BITACORA_LIQ("530. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("530. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            BITACORA_LIQ("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    'GRABA PENSION ALIMENTICIA
    Sub GRABAR_LIQ_PENSION_ALIMENTICIA(FCVE_LIQ As Long)

        Dim NUM_PAR As Integer = 0, CVE_OBS As Long = 0, SQL2 As String

        'TAB4                      TAB5                      TAB5
        If Not Valida_Conexion() Then
        End If

        SQL = "UPDATE GCLIQ_PENSION_ALI SET CVE_ART = @CVE_ART, FECHA = @FECHA, IMPORTE = @IMPORTE, FACTOR = @FACTOR, CVE_OBS = @CVE_OBS
            WHERE CVE_LIQ = @CVE_LIQ AND NUM_PAR = @NUM_PAR
            IF @@ROWCOUNT = 0
            INSERT INTO GCLIQ_PENSION_ALI  (CVE_LIQ, CVE_VIAJE, NUM_PAR, STATUS, CVE_FOLIO, CVE_ART, FECHA, IMPORTE, 
            FACTOR, CVE_OBS, FECHAELAB, UUID) 
            OUTPUT Inserted.NUM_PAR VALUES (
            @CVE_LIQ, '', ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCLIQ_PENSION_ALI  WHERE CVE_LIQ = @CVE_LIQ),1),'A', 
            @CVE_FOLIO, @CVE_ART, @FECHA, @IMPORTE, @FACTOR, @CVE_OBS, GETDATE(), NEWID())"

        For k = 1 To FgPA.Rows.Count - 1
            Try
                If FgPA.Rows(k).IsVisible Then
                    If Not IsNothing(FgPA(k, 1)) Then
                        If Not String.IsNullOrEmpty(FgPA(k, 1)) Then
                            If FgPA(k, 2).ToString.Trim.Length > 0 Then
                                Try
                                    NUM_PAR = 0
                                    If Not IsNothing(FgPA(k, 9)) Then
                                        If Not String.IsNullOrEmpty(FgPA(k, 9)) Then
                                            If IsNumeric(FgPA(k, 9).ToString.Trim) Then
                                                NUM_PAR = CONVERTIR_TO_INT(FgPA(k, 9).ToString.Trim)
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("440. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                'OBSERVACIONES
                                Try
                                    CVE_OBS = 0
                                    If Not IsNothing(FgPA(k, 8)) Then
                                        If FgPA(k, 8).ToString.Trim.Length > 0 Then
                                            If IsNothing(FgPA(k, 10)) Then
                                                CVE_OBS = 0
                                            Else
                                                If IsNumeric(FgPA(k, 10)) Then
                                                    CVE_OBS = FgPA(k, 10)
                                                Else
                                                    CVE_OBS = 0
                                                End If
                                            End If

                                            If Valida_Conexion() Then
                                                If CVE_OBS = 0 Then
                                                    SQL2 = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS 
                                                    VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & FgPA(k, 8) & "')"
                                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                                        cmd.CommandText = SQL2
                                                        returnValue = cmd.ExecuteScalar.ToString
                                                        If returnValue IsNot Nothing Then
                                                            If CLng(returnValue) > 0 Then
                                                                CVE_OBS = returnValue
                                                            End If
                                                        End If
                                                    End Using
                                                Else
                                                    SQL2 = "UPDATE GCOBS SET DESCR = '" & FgPA(k, 8) & "' WHERE CVE_OBS = " & CVE_OBS
                                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                                        cmd.CommandText = SQL2
                                                        returnValue = cmd.ExecuteNonQuery.ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then
                                                            End If
                                                        End If
                                                    End Using
                                                End If
                                            End If
                                        End If
                                        FgPA(k, 10) = CVE_OBS
                                    End If
                                Catch ex As Exception
                                    MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                    BITACORA_LIQ("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                If Valida_Conexion() Then
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        Try 'TAB4                      TAB4                      TAB4
                                            cmd.CommandText = SQL
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = FCVE_LIQ
                                            cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                            cmd.Parameters.Add("@CVE_FOLIO", SqlDbType.VarChar).Value = GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC")
                                            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = FgPA(k, 2)
                                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgPA(k, 5)
                                            cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgPA(k, 7)), 6)
                                            cmd.Parameters.Add("@FACTOR", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(FgPA(k, 6)), 6)
                                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                                            Try
                                                returnValue = cmd.ExecuteScalar()
                                            Catch ex As Exception
                                                returnValue = NUM_PAR
                                            End Try
                                            If returnValue IsNot Nothing Then
                                                FgPA(k, 9) = returnValue
                                            Else
                                                FgPA(k, 9) = NUM_PAR
                                            End If
                                        Catch ex As Exception
                                            BITACORA_LIQ("500. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            MsgBox("500. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        End Try
                                    End Using
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("510. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("510. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Next

        Try
            For k = 1 To FgPA.Rows.Count - 1
                If Not FgPA.Rows(k).IsVisible Then
                    Try
                        If IsNumeric(FgPA(k, 9)) Then

                            If Valida_Conexion() Then
                                SQL = "DELETE FROM GCLIQ_PENSION_ALI WHERE CVE_LIQ = '" & FCVE_LIQ & "' AND NUM_PAR = " & FgPA(k, 9)
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
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
                        BITACORA_LIQ("530. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("530. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            BITACORA_LIQ("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_LIQ_DEDUCCIONES(FCVE_LIQ As Long)
        Dim d1 As Date = Now
        Dim FECHA As Date, DESCR As String = "", CVE_DED As Long = 0, CVE_LIQ As Long = 0
        Dim CVE_FOLIO As String, NUM_PAR As Integer = 0, IMPORTE As Decimal = 0, CVE_OBS As Long = 0

        If Not Valida_Conexion() Then
        End If

        TCVE_RES.Select()

        'TAB5                      TAB5                      TAB5
        SQL = "UPDATE GCLIQ_DEDUCCIONES SET FECHA = @FECHA, IMPORTE = @IMPORTE, CVE_OBS = @CVE_OBS, DESCR = @DESCR 
            WHERE CVE_LIQ = @CVE_LIQ AND NUM_PAR = @NUM_PAR AND CVE_DED = @CVE_DED
            IF @@ROWCOUNT = 0
            INSERT INTO GCLIQ_DEDUCCIONES (CVE_LIQ, CVE_FOLIO, NUM_PAR, STATUS, DESCR, CVE_DED, FECHA, IMPORTE, FECHAELAB, UUID, CVE_OBS)
            OUTPUT Inserted.NUM_PAR VALUES(
            @CVE_LIQ, 
            ISNULL((SELECT MAX(CVE_FOLIO) + 1 FROM GCLIQ_DEDUCCIONES WHERE CVE_LIQ = @CVE_LIQ),1), 
            ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCLIQ_DEDUCCIONES WHERE CVE_LIQ = @CVE_LIQ),1),'A', @DESCR,
            @CVE_DED, @FECHA, @IMPORTE, GETDATE(), NEWID(), @CVE_OBS)"
        Try
            For k = 1 To FgD.Rows.Count - 1
                Try
                    If FgD.Rows(k).IsVisible Then
                        If Not IsNothing(FgD(k, 2)) Then
                            If Not IsNothing(FgD(k, 8)) Then
                                If IsNumeric(FgD(k, 8)) Then
                                    'OBSERVACIONES
                                    Try
                                        CVE_OBS = 0
                                        If Not IsNothing(FgD(k, 10)) Then
                                            If FgD(k, 10).ToString.Trim.Length > 0 Then
                                                If IsNothing(FgD(k, 13)) Then
                                                    CVE_OBS = 0
                                                Else
                                                    If IsNumeric(FgD(k, 13)) Then
                                                        CVE_OBS = FgD(k, 13)
                                                    Else
                                                        CVE_OBS = 0
                                                    End If
                                                End If

                                                If Valida_Conexion() Then
                                                    If CVE_OBS = 0 Then
                                                        SQL2 = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES
                                                         ((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & FgD(k, 10) & "')"
                                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                                            cmd.CommandText = SQL2
                                                            returnValue = cmd.ExecuteScalar.ToString
                                                            If returnValue IsNot Nothing Then
                                                                If CLng(returnValue) > 0 Then
                                                                    CVE_OBS = returnValue
                                                                End If
                                                            End If
                                                        End Using
                                                    Else
                                                        SQL2 = "UPDATE GCOBS SET DESCR = '" & FgD(k, 10) & "' WHERE CVE_OBS = " & CVE_OBS
                                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                                            cmd.CommandText = SQL2
                                                            returnValue = cmd.ExecuteNonQuery.ToString
                                                            If returnValue IsNot Nothing Then
                                                                If returnValue = "1" Then
                                                                End If
                                                            End If
                                                        End Using
                                                    End If
                                                End If
                                            End If
                                            FgD(k, 13) = CVE_OBS
                                        End If
                                    Catch ex As Exception
                                        MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                        BITACORA_LIQ("460. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    Try
                                        FECHA = d1.ToShortDateString
                                        If Not IsNothing(FgD(k, 4)) Then
                                            If Not String.IsNullOrEmpty(FgD(k, 4)) Then
                                                If IsDate(FgD(k, 4)) Then
                                                    FECHA = FgD(k, 4)
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("560. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    Try
                                        CVE_FOLIO = ""
                                        If Not IsNothing(FgD(k, 1)) Then
                                            If Not String.IsNullOrEmpty(FgD(k, 1)) Then
                                                If FgD(k, 1).ToString.Trim.Length > 0 Then
                                                    CVE_FOLIO = FgD(k, 1)
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("580. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    Try
                                        NUM_PAR = 0
                                        If Not IsNothing(FgD(k, 11)) Then
                                            If Not String.IsNullOrEmpty(FgD(k, 11)) Then
                                                If IsNumeric(FgD(k, 11).ToString.Trim) Then
                                                    NUM_PAR = FgD(k, 11).ToString.Trim
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("610. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    Try
                                        IMPORTE = 0
                                        If Not IsNothing(FgD(k, 8)) Then
                                            If Not String.IsNullOrEmpty(FgD(k, 8)) Then
                                                If FgD(k, 8).ToString.Trim.Length > 0 Then
                                                    IMPORTE = FgD(k, 8)
                                                End If
                                            End If
                                        End If
                                        DESCR = FgD(k, 3)

                                    Catch ex As Exception
                                        BITACORA_LIQ("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        'MsgBox("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    Try
                                        CVE_DED = 0
                                        If Not IsNothing(FgD(k, 2)) Then
                                            CVE_DED = CONVERTIR_TO_INT(FgD(k, 2))
                                        End If
                                        CVE_LIQ = FCVE_LIQ
                                    Catch ex As Exception
                                        BITACORA_LIQ("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    'GCLIQ_DEDUCCIONES 
                                    If Valida_Conexion() Then
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            Try 'TAB5                      TAB5                      TAB5
                                                cmd.CommandText = SQL
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CVE_LIQ
                                                cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                                cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "A"
                                                cmd.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = CVE_DED
                                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FECHA
                                                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = IMPORTE
                                                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                                                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = DESCR
                                                Try
                                                    returnValue = cmd.ExecuteScalar()
                                                Catch ex As Exception
                                                    'BITACORA_LIQ("640. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                    returnValue = NUM_PAR
                                                End Try
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                                If IsNothing(returnValue) Then
                                                    returnValue = NUM_PAR
                                                End If

                                                FgD(k, 11) = returnValue
                                            Catch ex As Exception
                                                BITACORA_LIQ("660. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                MsgBox("660. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            End Try
                                        End Using
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("680. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    MsgBox("680. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

        Catch ex As Exception
            BITACORA_LIQ("710. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            MsgBox("710. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Try
            For k = 1 To FgD.Rows.Count - 1
                Try
                    If Not FgD.Rows(k).IsVisible Then
                        If IsNumeric(FgD(k, 11)) Then

                            If Valida_Conexion() Then
                                SQL = "DELETE FROM GCLIQ_DEDUCCIONES WHERE CVE_LIQ = '" & FCVE_LIQ & "' AND NUM_PAR = " & FgD(k, 11)
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("720. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            BITACORA_LIQ("730. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LtOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_TRACTOR.Text = ""
                LtUnidad.Text = ""
                Fg.Rows.Count = 1 : FgG.Rows.Count = 1 : FgD.Rows.Count = 1 : FgV.Rows.Count = 1 : FgGC.Rows.Count = 1
                TCVE_RES.Text = ""

                TCVE_TRACTOR.Focus()
            Else
                TCVE_OPER.Text = ""
                LtOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            BITACORA_LIQ("740. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("740. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            TCVE_TRACTOR.Focus()
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.ReadOnly Then
                Return
            End If

            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LtOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                Else
                    MsgBox("Operador inexistente")
                    LtOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
                TCVE_TRACTOR.Text = ""
                LtUnidad.Text = ""
            Else
                LtOper.Text = ""
                TCVE_OPER.Text = ""
            End If
        Catch ex As Exception
            BITACORA_LIQ("760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_ASIGNACION_VIAJE(fCVE_VIAJE As String)
        If fCVE_VIAJE.Trim.Length = 0 Then
            Return
        End If
    End Sub
    Private Sub BarDesplegar_Click(sender As Object, e As EventArgs) Handles BarDesplegar.Click
        Dim Exist As Boolean

        ENTRA_VA = False

        Exist = False
        Using cmd2 As SqlCommand = cnSAE.CreateCommand
            SQL = "SELECT ISNULL(NOMBRE,'') AS DES FROM GCOPERADOR WHERE CLAVE = '" & TCVE_OPER.Text & "' AND STATUS  = 'A'"
            cmd2.CommandText = SQL
            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                If dr2.Read Then
                    Exist = True
                End If
                dr2.Close()
            End Using
        End Using
        If Not Exist Then
            MsgBox("Operador inexistente o se encuentra de baja")
            TCVE_OPER.Select()
            TCVE_OPER.SelectAll()
            Return
        End If
        Dim DESCR As String

        If TCVE_TRACTOR.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione una unidad")
            TCVE_TRACTOR.Select()
            Return
        End If

        If TCVE_TRACTOR.Text.Trim.Length > 0 Then
            DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
            If DESCR = "" Or DESCR = "N" Then
                MsgBox("Unidad inexistente")
                LtUnidad.Text = ""
                Return
            End If
        End If
        'DESPLEGA TODAS LAS LIQUIDACIONES DEL OPERQDOR MENOS LAS LIQUIDADASS
        DESPLEGAR_BarDesplegar()

        LtSubtotal.Text = 0
        LtImporteLiquidar.Text = 0

        'DESPLEGAR_LIQ_PARTIDAS(CLng(tCVE_LIQ.Text))
        'INICIA DESPLEGUE DE GASTOS DE VIAJE Y VALES DE VIAJE
        FgG.Rows.Count = 1
        DESPLEGAR_LIQ_GASTOS_VIAJE(CLng(TCVE_LIQ.Text))
        DESPLEGAR_LIQ_VALES_VIAJE(CLng(TCVE_LIQ.Text))


        DESPLEGAR_LIQ_GASTOS_COMPROBADOS(CLng(TCVE_LIQ.Text))
        DESPLEGAR_LIQ_DEDUCCIONES(CLng(TCVE_LIQ.Text))

        ENTRA_VA = True

    End Sub
    Sub DESPLEGAR_BarDesplegar(Optional FFiltrar_Liq As Boolean = False)
        Dim s As String, AgregarPartida As Boolean, SUELDO_OPER As Decimal = 0

        Try
            If Not FFiltrar_Liq Then
                Fg.Rows.Count = 1 : FgG.Rows.Count = 1 : FgD.Rows.Count = 1 : FgV.Rows.Count = 1 : FgGC.Rows.Count = 1
            End If

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT U.CLAVE, A.STATUS, U.CLAVEMONTE, A.CVE_TRACTOR, A.FECHA, A.CVE_VIAJE, A.TIPO_UNI , A.TIPO_VIAJE,
                O.NOMBRE + '  (' + CAST(A.CVE_OPER AS VARCHAR(5)) + ')' AS NOM_OPER, A.ENTREGAR_EN, E.DESCR AS ENTREGAR, A.RECOGER_EN, 
                R.DESCR AS RECOGER, ISNULL(A.CVE_CAP1,'') AS CAP1, ISNULL(A.CVE_CAP2,'') AS CAP2, A.CVE_ST_VIA, 
                S.DESCR AS STATUS_VIAJE,TAB.SUELDO_OPER,ISNULL(ST.DESCR,'') AS ST_CP, ISNULL(R1.CVE_TAB,'') AS CVETAB, A.UUID, 
                CP1.FECHA_CARGA, CP1.FECHA_REAL_CARGA, CP1.FECHA_DESCARGA, CP1.FECHA_REAL_DESCARGA, 
                ISNULL((SELECT ISNULL(STC.DESCR,'') FROM GCCARTA_PORTE CT LEFT JOIN GCSTATUS_CARTA_PORTE STC ON STC.CVE_CAP = CT.ST_CARTA_PORTE WHERE CVE_FOLIO = A.CVE_CAP2),'') AS ST_CP2,
                DATEDIFF(day, CP1.FECHA_CARGA, CP1.FECHA_REAL_CARGA) AS DIF1, DATEDIFF(day, CP1.FECHA_DESCARGA, 
                CP1.FECHA_REAL_DESCARGA) AS DIF2, ISNULL(R1.SUELDO_X_FACTOR,0) AS SUELDO_C_FAC, 
                CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.SUELDO_FULL,0) ELSE ISNULL(SUELDO_SENC,0) END AS SUEL_CONV,
				A.CVE_DOC AS FACT1, '' AS FACT2, CLI.NOMBRE AS CLIENTE_NOMBRE, R1.DESCR AS ORIGEN, R1.DESCR2 AS DESTINO, ISNULL(FAC.CAN_TOT, 0) AS FACTURADO,
				CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.PORC_SUELDO_FULL, 0) ELSE ISNULL(R1.PORC_SUELDO_SENC, 0) END AS PORC_SUELDO,
				CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.SUELDO_MANIOBRA_FULL, 0) ELSE ISNULL(R1.SUELDO_MANIOBRA_SENC, 0) END AS SUELDO_MANIOBRA,
				CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.PORC_MANIOBRA_FULL, 0) ELSE ISNULL(R1.PORC_MANIOBRA_SENC, 0) END AS PORC_SUELDO_MANIOBRA,
                round(((CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.PORC_SUELDO_FULL, 0) ELSE ISNULL(R1.PORC_SUELDO_SENC, 0) END * ISNULL(FAC.CAN_TOT, 0))/100), 2) AS SDO_X_TONELADA, 
				round(((CASE WHEN A.TIPO_UNI = 1 THEN ISNULL(R1.PORC_MANIOBRA_FULL, 0) ELSE ISNULL(R1.PORC_MANIOBRA_SENC, 0) END * ISNULL(FAC.CAN_TOT, 0))/100), 2) AS SDO_MANIOBRA_X_TONELADA
                FROM GCASIGNACION_VIAJE A
                LEFT JOIN GCTAB_RUTAS_F R1 ON R1.CVE_TAB = A.CVE_TAB_VIAJE
                LEFT JOIN GCCARTA_PORTE CP1 ON CP1.CVE_FOLIO = A.CVE_CAP1
                LEFT JOIN GCSTATUS_CARTA_PORTE ST ON ST.CVE_CAP = CP1.ST_CARTA_PORTE
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN E ON E.CVE_REG = A.ENTREGAR_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R ON R.CVE_REG = A.RECOGER_EN
                LEFT JOIN GCUNIDADES U ON A.CVE_TRACTOR = U.CLAVEMONTE
                LEFT JOIN GCASIGNACION_VIAJE_TAB_RUTAS TAB ON TAB.CVE_CON = A.CVE_CON
                LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
                LEFT JOIN GCOPERADOR O ON O.CLAVE = A.CVE_OPER
                LEFT JOIN CLIE05 CLI WITH (nolock) ON CLI.CLAVE = A.CLIENTE	
				LEFT JOIN FACTF05 FAC WITH (nolock) ON FAC.CVE_DOC = A.CVE_DOC AND FAC.STATUS != 'C' AND FAC.TIMBRADO = 'S' 
                WHERE A.STATUS = 'A' AND A.CVE_OPER = '" & TCVE_OPER.Text & "' 
                " & IIf(TCVE_TRACTOR.Text.Trim.Length > 0, " AND A.CVE_TRACTOR = '" & TCVE_TRACTOR.Text & "'", "") & " AND 
                A.CVE_ST_VIA <> 5 
                ORDER BY A.CVE_VIAJE"
            'TERMINADO      A.CVE_ST_VIA = '3' AND 
            '1   PENDIENTE                      LEFT JOIN GCPEDIDOS P ON P.CVE_VIAJE = C.CVE_VIAJE 
            '2   TRANSITO
            '3   TERMINADO
            '4   REGRESO
            '5   LIQUIDADO
            '6   POR LIQUIDAR
            '7   CANCELADO
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                AgregarPartida = True

                SUELDO_OPER = dr("SUEL_CONV")

                s = IIf(dr("CVETAB").ToString.Trim.Length = 0, "", ">")
                s &= vbTab & False
                s &= vbTab & dr("CVE_VIAJE")
                s &= vbTab & dr("FACT1")
                s &= vbTab & dr("FACT2")
                s &= vbTab & dr("CLIENTE_NOMBRE")
                s &= vbTab & dr("ORIGEN")
                s &= vbTab & dr("DESTINO")
                s &= vbTab & IIf(dr.ReadNullAsEmptyInteger("TIPO_UNI") = 1, "Full", "Sencillo")
                s &= vbTab & dr("FACTURADO")
                s &= vbTab & SUELDO_OPER
                s &= vbTab & dr("PORC_SUELDO")
                s &= vbTab & dr("SUELDO_MANIOBRA")
                s &= vbTab & dr("PORC_SUELDO_MANIOBRA")
                s &= vbTab & False
                s &= vbTab & dr("SDO_X_TONELADA")
                s &= vbTab & dr("SDO_MANIOBRA_X_TONELADA")
                s &= vbTab & dr("SUEL_CONV")
                s &= vbTab & IIf(dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 1, "Cargado", "Vacio")
                s &= vbTab & dr.ReadNullAsEmptyString("CVE_TRACTOR")
                s &= vbTab & dr("CAP1")
                s &= vbTab & dr("ST_CP")
                s &= vbTab & dr("CAP2")
                s &= vbTab & dr("ST_CP2")
                s &= vbTab & dr.ReadNullAsEmptyString("FECHA")
                s &= vbTab & dr("RECOGER_EN")
                s &= vbTab & dr("RECOGER")
                s &= vbTab & dr("ENTREGAR_EN")
                s &= vbTab & dr("ENTREGAR")
                s &= vbTab & dr("CVE_ST_VIA")
                s &= vbTab & dr("STATUS_VIAJE")
                s &= vbTab & ""
                s &= vbTab & "NO"
                s &= vbTab & 0
                s &= vbTab & dr("UUID")
                s &= vbTab & "S"
                s &= vbTab & dr("CVETAB")
                s &= vbTab & ""
                s &= vbTab & dr("FECHA_CARGA")
                s &= vbTab & dr("FECHA_REAL_CARGA")
                s &= vbTab & dr("FECHA_DESCARGA")
                s &= vbTab & dr("FECHA_REAL_DESCARGA")
                s &= vbTab & dr("DIF1")
                s &= vbTab & dr("DIF2")
                s &= vbTab & dr("SUEL_CONV")

                If Not FFiltrar_Liq Then
                    Fg.AddItem(s)
                Else
                    For k = 1 To Fg.Rows.Count - 1
                        If Fg(k, _FgColNumViaje) = dr.ReadNullAsEmptyString("CVE_VIAJE") Then
                            AgregarPartida = False
                            Exit For
                        End If
                    Next
                    If AgregarPartida Then Fg.AddItem(s)
                End If
            Loop
            dr.Close()

            If Not FFiltrar_Liq Then
                Fg.AutoSizeCols()
                If Fg.Row > 0 Then
                    Fg.Cols(_FgColNumViaje).Width = 100
                    Fg.Row = 1
                    Fg.Col = _FgColSeleccione
                    Fg.Select()
                End If
                FgG.Rows.Count = 1
                FgV.Rows.Count = 1
                FgGC.Rows.Count = 1
                FgD.Rows.Count = 1
            End If
        Catch ex As Exception
            BITACORA_LIQ("800. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub FGCHECK_DESPLEGAR_GASTOS_VIAJE(fCVE_VIAJE As String, Optional fPROC As String = "")
        Dim Exist As Boolean
        FgG.Redraw = False

        Try
            For k = FgG.Rows.Count - 1 To 1 Step -1
                Try '1 = CVE_VIAJE
                    If IsNothing(FgG(k, 2)) Then
                        FgG.RemoveItem(k)
                    Else
                        If String.IsNullOrEmpty(FgG(k, 2).ToString.Trim) Then
                            FgG.RemoveItem(k)
                        Else
                            If FgG(k, 2).ToString.Length = 0 Then
                                FgG.RemoveItem(k)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("820. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            BITACORA_LIQ("840. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If fPROC = "A" Then
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "Select CVE_OPER, CVE_GAV, FOLIO, FECHA, CVE_NUM, ISNULL(IMPORTE, 0) As IMPORT, DESCR,
                        ISNULL(ST_GASTOS,'EDICION') AS ST_GAS, GV.UUID
                        From GCASIGNACION_VIAJE_GASTOS GV
                        LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                        WHERE 
                        GV.STATUS <> 'L' AND CVE_VIAJE = '" & fCVE_VIAJE & "' AND ISNULL(ST_GASTOS,'') = 'DEPOSITADO' ORDER BY FECHAELAB"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                Exist = False
                                'For k = 1 To FgG.Rows.Count - 1
                                'If FgG(k, 10) = dr("UUID") Then
                                'Exist = True
                                'Exit For
                                'End If
                                'Next
                                FgG.AddItem("2" & vbTab & "" & vbTab & fCVE_VIAJE & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("CVE_NUM") & vbTab &
                                    dr("DESCR") & vbTab & dr("IMPORT") & vbTab & dr("ST_GAS") & vbTab & 0 & vbTab & dr("UUID"))
                                nGastos += 1
                            Catch ex As Exception
                                BITACORA_LIQ("850. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORA_LIQ("900. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            'Fg(e.Row, 19) = "Check"
            Try
                For k = FgG.Rows.Count - 1 To 1 Step -1
                    If FgG(k, 2) = fCVE_VIAJE Then
                        FgG(k, 2) = "KILL"
                        FgG.Rows(k).Visible = False
                        'FgG.RemoveItem(k)
                    End If
                Next
            Catch ex As Exception
                BITACORA_LIQ("920. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("920. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SUMA = 0
                For k = 1 To FgG.Rows.Count - 1
                    Try
                        If FgG.Rows(k).IsVisible Then
                            If FgG(k, 1) Then
                                SUMA += FgG(k, 7)
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("940. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Catch ex As Exception
                BITACORA_LIQ("960. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        FgG.Redraw = True
    End Sub
    Sub FGCHECK_DESPLEGAR_GASTOS_VIAJE_VALES(fCVE_VIAJE As String, fPROC As String)

        FgG.Redraw = False
        Try
            For k = FgV.Rows.Count - 1 To 1 Step -1
                Try
                    If IsNothing(FgV(k, 1)) Then
                        FgV.RemoveItem(k)
                    Else
                        If String.IsNullOrEmpty(FgV(k, 1).ToString.Trim) Then
                            FgV.RemoveItem(k)
                        Else
                            If FgV(k, 1).ToString.Length = 0 Then
                                FgV.RemoveItem(k)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("980. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("980. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            BITACORA_LIQ("1000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If fPROC = "A" Then
            Try
                SUMA2 = 0
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, GV.FECHA, GV.CVE_GAS, GV.LITROS, GV.LITROS_REALES, GV.P_X_LITRO, GV.SUBTOTAL, 
                    GV.IVA, GV.IEPS, GV.IMPORTE, G.DESCR, GV.FACTURA, ISNULL(GV.ST_VALES,'EDICION') AS ST_VAL, GV.UUID
                    FROM GCASIGNACION_VIAJE_VALES GV
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                    WHERE 
                    GV.STATUS <> 'L' AND GV.STATUS <> 'C' AND GV.CVE_VIAJE = '" & fCVE_VIAJE & "' AND ST_VALES <> 'EDICION' AND ST_VALES <> 'CAPTURADO' AND 
                    ISNULL(GV.CVE_LIQ,0) = 0
                    ORDER BY FECHAELAB"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            FgV.AddItem("" & vbTab & fCVE_VIAJE & vbTab & dr("FOLIO") & vbTab & dr("FECHA") & vbTab & dr("CVE_GAS") & vbTab & dr("DESCR") & vbTab &
                                     dr("LITROS") & vbTab & dr("LITROS_REALES") & vbTab & dr("P_X_LITRO") & vbTab & dr("SUBTOTAL") & vbTab &
                                     dr("IVA") & vbTab & dr("IEPS") & vbTab & dr("IMPORTE") & vbTab & dr("FACTURA") & vbTab & 0 & vbTab & dr("UUID"))
                            nVales += 1
                        End While
                    End Using
                    Try
                        For k = FgV.Rows.Count - 1 To 1 Step -1
                            Try
                                If FgV.Rows(k).IsVisible Then
                                    SUMA2 += FgV(k, 12)
                                End If
                            Catch ex As Exception
                                BITACORA_LIQ("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Next
                    Catch ex As Exception
                        BITACORA_LIQ("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End Using
            Catch ex As Exception
                BITACORA_LIQ("1060. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1060. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                For k = FgV.Rows.Count - 1 To 1 Step -1
                    Try
                        If FgV(k, 1) = fCVE_VIAJE Then
                            FgV(k, 13) = "KILL"
                            FgV.Rows(k).Visible = False
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("1070. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1070. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Catch ex As Exception
                BITACORA_LIQ("1080. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1080. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                SUMA2 = 0
                For k = FgV.Rows.Count - 1 To 1 Step -1
                    Try
                        If FgV.Rows(k).IsVisible Then
                            SUMA2 += FgV(k, 12)
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("1100. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1100. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next

            Catch ex As Exception
                BITACORA_LIQ("1120. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1120. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        FgG.Redraw = True
    End Sub
    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_OPER.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            'barDesplegar.Select()
            'Fg.Focus()
        End If
    End Sub
    Private Sub FrmLiquidacionesAE_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            'If MsgBox("Realmende desea abandonar la liquidacion?", vbYesNo) = vbYes Then
            'e.Cancel = False
            'Else
            'e.Cancel = True
            'End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs)
        Try
            If SelFg = "N" Then
                If FgD.Row > 0 Then
                    FgD.RemoveItem(FgD.Row)
                    CALCULAR_IMPORTES()
                End If
            Else
                If FgGC.Row > 0 Then
                    FgGC.RemoveItem(FgGC.Row)
                    CALCULAR_IMPORTES()
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 Then
                '                                           20 NUEVO S/N   
                If LtTipoCrobro.Text = "Edición" Then
                    If Fg(Fg.Row, _FgColSeleccione) Then
                        If Fg.Col <> _FgColSeleccione And Fg.Col <> _FgColStatusViaje And Fg.Col <> _FgColxFactor And Fg.Col <> _FgColSelCalculo Then
                            e.Cancel = True
                        End If
                    Else
                        If Fg.Col <> _FgColSeleccione Then
                            e.Cancel = True
                        End If
                    End If
                Else
                    e.Cancel = True
                    Return
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1340. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If FlexiSoloLectura Then
                Return
            End If

            If Fg.Col = _FgColSeleccione And Fg.Col = _FgColSelCalculo And ENTRA Then
                Fg.StartEditing()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick

        'If Fg.Col = 18 Then _FgColPuntos
        If Fg.Col = 188 Then
            Try
                'Var4 = Fg(Fg.Row, 1).ToString   'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString   'CIENTE
                'Var6 = Fg(Fg.Row, 3).ToString   'ORIGEN
                'Var7 = Fg(Fg.Row, 4).ToString   'DESTINO
                'Var8 = Fg(Fg.Row, 7).ToString   'SUELDO
                Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                Var9 = Fg(Fg.Row, _FgColTipoViaje)
                Var2 = "Sueldo operadores"
                frmSelItemSueldoOper.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    Fg(Fg.Row, _FgColSueldoViaje) = Var8
                    Fg(Fg.Row, _FgColPuntos) = Var4

                    CALCULAR_IMPORTES()
                End If
            Catch ex As Exception
                BITACORA_LIQ("1360. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                MsgBox("1360. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit
        If FlexiSoloLectura Then
            e.Cancel = True
            Return
        End If
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If LtTipoCrobro.Text <> "Edición" And Fg(Fg.Row, _FgColNuevo) = "N" Then
                e.Cancel = True
            Else
                Try
                    If Fg.Row > 0 Then
                        If Fg.Col = _FgColxFactor Then
                            If Not IsNothing(Fg(Fg.Row, _FgColSueldo)) Then
                                If IsNumeric(Fg(Fg.Row, _FgColSueldo)) Then
                                    If IsNumeric(Fg.Editor.Text) Then
                                        If CDec(Fg.Editor.Text) < 0 Then
                                            e.Cancel = True
                                            Fg(Fg.Row, _FgColSueldoViaje) = Fg(Fg.Row, _FgColSueldo)
                                        Else
                                            If CDec(Fg.Editor.Text) = 0 Then
                                                Fg(Fg.Row, _FgColSueldoViaje) = Fg(Fg.Row, _FgColSueldo)
                                            Else
                                                Fg(Fg.Row, _FgColSueldoViaje) = Fg(Fg.Row, _FgColSueldo) * CDec(Fg.Editor.Text)
                                            End If
                                        End If
                                        CALCULAR_IMPORTES()
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("2200. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                '
                If Fg.Col = _FgColxFactor Then
                    '                23 CVE_TAB_VIAJE SUELDO
                    If Not IsNothing(Fg(Fg.Row, _FgColVacio23)) And Fg(Fg.Row, _FgColVacio23) <> "0" Then
                        If Fg(Fg.Row, _FgColVacio23).ToString.Trim.Length = 0 Then
                            Fg.FinishEditing()
                        Else
                            If Fg(Fg.Row, _FgColSueldoxFactor) = 0 Then
                                Fg.FinishEditing()
                            End If
                        End If
                    Else
                        Fg.FinishEditing()
                    End If
                End If

            End If
        Catch ex As Exception
            BITACORA_LIQ("2200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            If TCVE_OPER.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave del operador")
                e.Cancel = True
                Fg(e.Row, _FgColSeleccione) = False
                Return
            End If
            If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave de la unidad")
                e.Cancel = True
                Fg(e.Row, _FgColSeleccione) = False
                Return
            End If
        Catch ex As Exception
            BITACORA_LIQ("1290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If e.Row = 0 And e.Col = _FgColSeleccione And ENTRA Then
            Try
                Dim PROC As String = ""
                ENTRA = False
                SUMA = 0 : SUMA2 = 0

                FgG.Rows.Count = 1
                FgV.Rows.Count = 1
                nGastos = 0 : nVales = 0

                'SOLO CAMBIA A CHECK box true false
                ChangeState(Fg.GetCellCheck(e.Row, e.Col))

                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, _FgColSeleccione) Then
                        PROC = "A"
                        FGCHECK_DESPLEGAR_GASTOS_VIAJE(Fg(k, _FgColNumViaje), PROC)
                        FGCHECK_DESPLEGAR_GASTOS_VIAJE_VALES(Fg(k, _FgColNumViaje), PROC)
                        Fg(k, _FgColCheck19) = "Check"
                    Else
                        Fg(k, _FgColCheck19) = ""
                    End If
                Next
                Try
                    If FgG.Rows.Count > 0 Then
                        FgG.AutoSizeCols()
                    End If
                    If FgV.Rows.Count > 0 Then
                        FgV.AutoSizeCols()
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                CALCULAR_IMPORTES()

                Try
                    SUMA2 = 0 : SUMA_LTS = 0
                    For k = FgV.Rows.Count - 1 To 1 Step -1
                        Try
                            If FgV.Rows(k).IsVisible Then
                                SUMA2 += FgV(k, 12)
                                SUMA_LTS += FgV(k, 7)
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Next
                Catch ex As Exception
                    BITACORA_LIQ("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                LtValesCombustible.Text = Format(SUMA2, "###,###,##0.00")
                'LtLitros.Text = Format(SUMA_LTS, "###,###,##0.00")

                FgG.AddItem("3" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "TOTAL" & vbTab & SUMA)

                FgV.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                            "" & vbTab & SUMA_LTS & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & SUMA2)
                ENTRA = True
            Catch ex As Exception
                ENTRA = True
                BITACORA_LIQ("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        If e.Row > 0 Then
            Try
                If e.Col = _FgColSeleccione And ENTRA Then
                    Dim PROC As String = ""
                    ENTRA = False
                    SUMA = 0 : SUMA2 = 0

                    'ChangeState(Fg.GetCellCheck(e.Row, e.Col))

                    If Fg(e.Row, _FgColSeleccione) Then
                        PROC = "A"
                        If Fg(e.Row, _FgColCheck19) <> "Check" Then
                            nGastos = 0 : nVales = 0
                            FGCHECK_DESPLEGAR_GASTOS_VIAJE(Fg(e.Row, _FgColNumViaje), PROC)
                            FGCHECK_DESPLEGAR_GASTOS_VIAJE_VALES(Fg(e.Row, _FgColNumViaje), PROC)
                            FgG.AutoSizeCols()
                            FgV.AutoSizeCols()
                        End If
                        Fg(e.Row, _FgColCheck19) = "Check"
                        'SUELDO
                        'If Fg(e.Row, _FgColSueldoViaje) = 0 Then
                        '    '     CARTA PORTE                           CARTA PORTE 2
                        '    If Fg(e.Row, _FgColNumCPorte).ToString.Trim.Length = 0 And Fg(e.Row, _FgColNumCPorte2).ToString.Trim.Length = 0 Then
                        '        Fg(e.Row, _FgColSueldoViaje) = 0
                        '    Else '     ACRTA PORTE                            CARTA PORTE 2
                        '        If Fg(e.Row, _FgColNumCPorte).ToString.Trim.Length > 0 And Fg(e.Row, _FgColNumCPorte2).ToString.Trim.Length > 0 Then
                        '            If Fg(e.Row, _FgColEstatus).ToString = "CANCELADO" And Fg(e.Row, 6).ToString = "CANCELADO" Then
                        '                Fg(e.Row, _FgColSueldoViaje) = 0 'SUELDO
                        '            Else
                        '                Fg(e.Row, _FgColSueldoViaje) = BUSCA_SUELDO(Fg(e.Row, _FgColTipoViaje), Fg(e.Row, _FgColVacio23)) 'SUELDO
                        '            End If
                        '        Else
                        '            If Fg(e.Row, _FgColEstatus).ToString = "CANCELADO" Then
                        '                Fg(e.Row, _FgColSueldoViaje) = 0 'SUELDO
                        '            Else
                        '                Fg(e.Row, _FgColSueldoViaje) = BUSCA_SUELDO(Fg(e.Row, _FgColTipoViaje), Fg(e.Row, _FgColVacio23)) 'SUELDO
                        '            End If
                        '        End If
                        '    End If
                        'End If
                    Else
                        'Fg(e.Row, _FgColSueldoViaje) = "0"
                        Fg(e.Row, _FgColPuntos) = ""
                        PROC = "E"
                        FGCHECK_DESPLEGAR_GASTOS_VIAJE(Fg(e.Row, _FgColNumViaje), PROC)
                        FGCHECK_DESPLEGAR_GASTOS_VIAJE_VALES(Fg(e.Row, _FgColNumViaje), PROC)
                        Fg(e.Row, _FgColCheck19) = "NO"
                    End If
                    BarImprimirLiq.Enabled = False

                    CALCULAR_IMPORTES()

                    Try
                        SUMA2 = 0 : SUMA_LTS = 0
                        For k = FgV.Rows.Count - 1 To 1 Step -1
                            Try
                                If FgV.Rows(k).IsVisible Then
                                    SUMA2 += FgV(k, 12)
                                    SUMA_LTS += FgV(k, 7)
                                End If
                            Catch ex As Exception
                                BITACORA_LIQ("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1020. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Next
                    Catch ex As Exception
                        BITACORA_LIQ("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1040. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    LtValesCombustible.Text = Format(SUMA2, "###,###,##0.00")
                    'LtLitros.Text = Format(SUMA_LTS, "###,###,##0.00")
                    'FgG.AddItem("4" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "TOTAL" & vbTab & SUMA)
                    FgV.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                "" & vbTab & SUMA_LTS & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & SUMA2)
                    ENTRA = True
                End If
                '************

                If e.Col = _FgColSelCalculo And ENTRA Then
                    ENTRA = False
                    Fg(e.Row, _FgColSueldoViaje) = IIf(Fg(e.Row, _FgColSelCalculo), Fg(e.Row, _FgColSdoPorTonedada), Fg(e.Row, _FgColSueldo))
                    CALCULAR_IMPORTES()
                    ENTRA = True
                End If

            Catch ex As Exception
                ENTRA = True
                BITACORA_LIQ("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Function BUSCA_SUELDO(FTIPO_UNI As String, FCVE_TAB As String) As Decimal
        Dim SUELDO_OPER As Decimal = 0

        Try 'PASA POR AQUI CUANDO NO TIENE SUELDO
            If FCVE_TAB.Trim.Length > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT SUELDO, SUELDO_SENC FROM GCSUELDO_OPER WHERE CVE_TAB = '" & FCVE_TAB & "'"
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        If dr2.Read Then
                            If FTIPO_UNI = "Full" Then
                                SUELDO_OPER = dr2.ReadNullAsEmptyDecimal("SUELDO")
                            Else
                                SUELDO_OPER = dr2.ReadNullAsEmptyDecimal("SUELDO_SENC")
                            End If
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            BITACORA_LIQ("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return SUELDO_OPER

    End Function
    Sub CALCULO_RESETEO()
        Try
            CALCULAR_IMPORTES()
        Catch ex As Exception
            BITACORA_LIQ("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUnidad_Click(sender As Object, e As EventArgs) Handles BtnUnidad.Click
        Try
            Var2 = "Uni_Viaje" '"Unidades"
            Var3 = "" : Var4 = "" : Var5 = TCVE_OPER.Text
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                TCVE_TRACTOR.Text = Var5
                LtUnidad.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_RES.Focus()
            End If
        Catch Ex As Exception
            BITACORA_LIQ("1420. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("1420. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidad_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TRACTOR_Validating(sender As Object, e As CancelEventArgs) Handles TCVE_TRACTOR.Validating
        Try
            If TCVE_TRACTOR.ReadOnly Then
                Return
            End If
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    LtUnidad.Text = DESCR
                Else
                    e.Cancel = True
                    MsgBox("Unidad inexistente")
                    TCVE_TRACTOR.Text = ""
                    LtUnidad.Text = ""
                End If
            Else
                TCVE_TRACTOR.Text = ""
                LtUnidad.Text = ""
                'e.Cancel = True
            End If
        Catch ex As Exception
            BITACORA_LIQ("1440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Try
            If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione la unidad")
                TCVE_TRACTOR.Focus()
                Return
            End If
            If TCVE_OPER.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione el operador")
                TCVE_TRACTOR.Focus()
                Return
            End If

            Var2 = "Reseteo"
            Var4 = ""
            Var5 = " AND ESTADO <> 'EN LIQUIDACION' AND R.CVE_OPER = " & TCVE_OPER.Text & " AND U.CLAVEMONTE = '" & TCVE_TRACTOR.Text & "'"
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_RES.Text = Var4
                DESPLEGAR_RESETEO()
            End If
        Catch ex As Exception
            BITACORA_LIQ("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_RES_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_RES.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnReset_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_RES_Validated(sender As Object, e As EventArgs) Handles TCVE_RES.Validated
        Try
            If TCVE_RES.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESPLEGAR_RESETEO()
            Else
                TCVE_RES.Text = ""
            End If
        Catch ex As Exception
            BITACORA_LIQ("1440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_RESETEO()
        Dim MONTO As Decimal

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If TCVE_RES.Text.Trim.Length > 0 And IsNumeric(TCVE_RES.Text) Then
                SQL = "SELECT R.CVE_RES, R.STATUS, R.FECHA, R.CVE_OPER, R.CVE_UNI, R.CVE_MOT, R.ODOMETRO, R.KM_ECM, R.LTS_ECM, R.LTS_REAL, R.LTS_TAB, 
                    R.FAC_CARGA, R.HRS_TRABAJO, R.HRS_PTO_RALENTI, R.LTS_PTO_RALENTI, R.PORC_TIEMPO_PTO_RALENTI, R.PORC_LTS_PTO_RALENTI, R.REND_ECM, 
                    R.PORC_VAR_LTS_ECM_REAL, R.PORC_VAR_LTS_TAB_REAL, R.REND_REAL, R.DIF_LTS_REAL_LTS_ECM, R.DIF_LTS_REAL_LTS_TAB, LTS_SALIDA, 
                    LTS_VALES, LTS_LLEGADA, PDF, ESTADO, DESCT, CALIF, VELMAX, TIEMPO_MARCH_INERCIA, KMS_TAB, CALIF_FACTOR_CARGA, CALIF_RALENTI, 
                    CALIF_GLOBAL, CAL_FAC_CAR_EVA, CAL_RAL_EVA, CAL_GLO_EVA, LTS_DESCONTAR, PRECIO_X_LTS, LTS_AUTORIZADOS, LITROS_UREA, 
                    CARGO_X_PUNTO_MUERTO, FACTOR_CARGA, PORC_USO_RALENTI, LTS_UREA_REAL, PORC_TOLERANCIA, PORC_RALENTI, NO_VIAJE, NO_LIQUI, 
                    BONO_RES, LTS_FORANEOS, CVE_EVE, CALIF_VEL_MAX, NO_DE_VIAJES, NO_DE_VIAJES_VACIO, BONO_RES_VACIO, 
                    ISNULL(EVENTO,0) AS EVEN, ISNULL(EVENTO_LTS,0) AS EVEN_LTS, LTS_AUTORIZADOS2, LTS_VALES2, LTS_DESCONTAR2, LTS_DESCONTAR2
                    FROM GCRESETEO R WHERE CVE_RES = " & TCVE_RES.Text
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Try
                                Try
                                    TLTS_UREA_REAL.Text = dr.ReadNullAsEmptyDecimal("LTS_UREA_REAL")

                                    LtLtsEfectivo.Text = Format(dr("LTS_FORANEOS"), "###,###,##0.00")
                                    LtLitros.Text = Format(dr("LTS_VALES"), "###,###,##0.00")

                                    LtLotaLts.Text = Format(dr("LTS_FORANEOS") + dr("LTS_VALES"), "###,###,##0.00")

                                Catch ex As Exception
                                End Try
                                Try
                                    TDESCT.Text = dr.ReadNullAsEmptyDecimal("DESCT")
                                Catch ex As Exception
                                End Try
                                Try
                                    TCALIF.Text = dr.ReadNullAsEmptyDecimal("CALIF")
                                Catch ex As Exception
                                End Try
                                Try
                                    TVELMAX.Text = dr.ReadNullAsEmptyDecimal("VELMAX")
                                Catch ex As Exception
                                End Try
                                Try
                                    TTIEMPO_MARCH_INERCIA.Text = dr.ReadNullAsEmptyDecimal("TIEMPO_MARCH_INERCIA")
                                Catch ex As Exception
                                    BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                Try
                                    TLITROS_UREA.Text = dr.ReadNullAsEmptyDecimal("LITROS_UREA")
                                Catch ex As Exception
                                    BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Catch ex As Exception
                                BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                TLTS_TAB.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_TAB"), "###,###,##0.00")
                            Catch ex As Exception
                                BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            TCVE_MOT.Text = dr.ReadNullAsEmptyString("CVE_MOT").ToString

                            TCVE_RES2.Text = dr.ReadNullAsEmptyString("CVE_RES").ToString
                            TFECHA.Text = dr.ReadNullAsEmptyString("FECHA").ToString
                            TCVE_OPER2.Text = dr.ReadNullAsEmptyInteger("CVE_OPER").ToString
                            If TCVE_OPER.Text.Trim <> "" And TCVE_OPER.Text <> "0" Then
                                LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                            Else
                                TCVE_OPER.Text = ""
                            End If

                            TCVE_TRACTOR2.Text = dr.ReadNullAsEmptyString("CVE_UNI").ToString
                            Try
                                TODOMETRO.Text = Format(dr.ReadNullAsEmptyDecimal("ODOMETRO"), "###,###,##0.00")
                                'AQUI ESTA EL PROBLEMA
                                TKM_ECM.Text = Format(dr.ReadNullAsEmptyDecimal("KM_ECM"), "###,###,##0.00")
                                TLTS_ECM.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_ECM"), "###,###,##0.00")
                                LtLTS_ECM.Text = Format(CSng(TLTS_ECM.Text), "###,###,##0.00")
                            Catch ex As Exception
                                BITACORA_LIQ("20. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                TLTS_VALES.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_VALES"), "###,###,##0.00")
                                LtLTS_VALES.Text = Format(CSng(TLTS_VALES.Text), "###,###,##0.00")
                            Catch ex As Exception
                                BITACORA_LIQ("35. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                TLTS_SALIDA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_SALIDA"), "###,###,##0.00")
                                TLTS_LLEGADA.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_LLEGADA"), "###,###,##0.00")
                                TLTS_FORANEOS.Text = dr.ReadNullAsEmptyDecimal("LTS_FORANEOS")
                            Catch ex As Exception
                                BITACORA_LIQ("35. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                Dim L1 As Decimal = 0, L2 As Decimal = 0, L3 As Decimal = 0, L4 As Decimal = 0
                                Try
                                    L1 = TLTS_SALIDA.Text.Replace(",", "")
                                Catch ex As Exception
                                End Try
                                Try
                                    L2 = TLTS_VALES.Text
                                Catch ex As Exception
                                End Try
                                Try
                                    L3 = TLTS_FORANEOS.Text
                                Catch ex As Exception
                                End Try
                                Try
                                    L4 = TLTS_LLEGADA.Text.Replace(",", "")
                                Catch ex As Exception
                                End Try
                                TLTS_REAL.Text = Format(L1 + L2 + L3 - L4, "###,###,##0.00")
                                LtLTS_VALES.Text = Format(L1 + L2 + L3 - L4, "###,###,##0.00")
                            Catch ex As Exception
                            End Try
                            Try
                                Try
                                    TPORC_RALENTI.Text = Format(dr.ReadNullAsEmptyDecimal("PORC_RALENTI"), "###,###,##0.00")
                                Catch ex As Exception
                                End Try
                                TPORC_TOLERANCIA.Text = Format(dr.ReadNullAsEmptyDecimal("PORC_TOLERANCIA"), "###,###,##0.00")
                                TLTS_DESCONTAR.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_DESCONTAR"), "###,###,##0.00")

                                TPRECIO_X_LTS.Text = Format(dr.ReadNullAsEmptyDecimal("PRECIO_X_LTS"), "###,###,##0.00")
                                If TPRECIO_X_LTS.Text = 0 Then
                                    TPRECIO_X_LTS.Text = Format(PRECIO_X_LTS, "###,###,##0.00")
                                End If

                                TLTS_AUTORIZADOS.Text = Format(dr.ReadNullAsEmptyDecimal("LTS_AUTORIZADOS"), "###,###,##0.00")
                                MONTO = CSng(TLTS_DESCONTAR.Text) * CSng(TPRECIO_X_LTS.Text)
                                LtDescXLitros.Text = Format(MONTO, "###,###,##0.00")

                                TCARGO_X_PUNTO_MUERTO.Text = Format(dr.ReadNullAsEmptyDecimal("CARGO_X_PUNTO_MUERTO"), "###,###,##0.00")

                            Catch ex As Exception
                                BITACORA_LIQ("35. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            LtLTS_ECM.Text = Format((CSng(TLTS_ECM.Text.Replace(",", "")) - dr.ReadNullAsEmptyDecimal("LTS_PTO_RALENTI")) *
                                            CSng(TPORC_TOLERANCIA.Text.Replace(",", "")) / 100, "###,###,##0.00")

                            If dr("EVEN") = 0 Then
                                GpoEvento2.Visible = False
                            Else
                                GpoEvento1.Visible = False
                                GpoEvento2.Left = GpoEvento1.Left

                                'tLTS_AUTORIZADOS2
                                'LtLTS_VALES2
                                'tLTS_DESCONTAR2
                                'tPRECIO_X_LTS2
                                'LtDescXLitros2

                                TPRECIO_X_LTS2.Value = TPRECIO_X_LTS.Text.Replace(",", "")
                                LtLTS_VALES2.Text = Format(dr("LTS_VALES2"), "###,###,#0.00")

                                If dr("EVEN_LTS") = 0 Then
                                    RadLTS_ECM.Checked = True
                                    TLTS_AUTORIZADOS2.Value = CSng(TLTS_ECM.Text.Replace(",", ""))
                                    TLTS_DESCONTAR2.Value = CSng(TLTS_ECM.Text.Replace(",", "")) - dr("LTS_VALES2")
                                    LtDescXLitros2.Text = Format(TLTS_DESCONTAR2.Value * CSng(TPRECIO_X_LTS.Text.Replace(",", "")), "###,###,##0.00")
                                Else
                                    RadLTS_TAB.Checked = True
                                    TLTS_AUTORIZADOS2.Value = CDec(TLTS_TAB.Text.Replace(",", ""))
                                    TLTS_DESCONTAR2.Value = CDec(TLTS_TAB.Text.Replace(",", "")) - dr("LTS_VALES2")
                                    LtDescXLitros2.Text = Format(TLTS_DESCONTAR2.Value * CSng(TPRECIO_X_LTS.Text.Replace(",", "")), "###,###,##0.00")
                                End If
                            End If
                        Else
                            MsgBox("Reseteo inexistente, verifique por favor")
                        End If
                    End Using
                End Using

            End If
        Catch ex As Exception
            BITACORA_LIQ("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimirResteo_Click(sender As Object, e As EventArgs) Handles BarImprimirResteo.Click
        Dim RUTA_FORMATOS As String = ""

        If TCVE_RES.Text.Trim.Length > 0 Then
            Try
                RUTA_FORMATOS = GET_RUTA_FORMATOS()
                If Not File.Exists(RUTA_FORMATOS & "\ReportReseteo.mrt") Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportReseteo.mrt, verifique por favor")
                    Return
                End If

                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        'SQL = "UPDATE GCORDEN_TRA_SER_EXT SET IMPORTE = CANT * COSTO WHERE CVE_ORD = '" & fCVE_ORD & "'"
                        'cmd.CommandText = SQL
                        'returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                End Try

                StiReport1.Load(RUTA_FORMATOS & "\ReportReseteo.mrt")

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
                BITACORA_LIQ("1480. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("1480. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione un reseteo")
        End If
    End Sub
    Private Sub BtnAddDec_Click(sender As Object, e As EventArgs) Handles BtnAddDec.Click
        Try
            If FgD.Rows.Count = 1 Then
                '                         1             2            3             4            5 
                '                      FOLIO LIQ.  folio dedudc     descr        fecha      imp. prestamo
                FgD.AddItem("" & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab &
                            "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab & "0")
                '         pagado         saldo         abonar     saldo actual     obser         num_par        uuid       cve_obs   
                '            6             7             8             9             10           11              12          13
            Else
                If Not IsNothing(FgD(FgD.Rows.Count - 1, 2)) Then
                    If Not String.IsNullOrEmpty(FgD(FgD.Rows.Count - 1, 2)) Then
                        '                         1             2            3             4            5 
                        '                      FOLIO LIQ.  folio dedudc     descr        fecha      imp. prestamo
                        FgD.AddItem("" & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab &
                                    "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab & "0")
                        '         pagado         saldo         abonar     saldo actual     obser         num_par        uuid       cve_obs   
                        '            6             7             8             9             10           11              12          13
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_GotFocus(sender As Object, e As EventArgs) Handles FgD.GotFocus
        SelFg = "N"
    End Sub
    Private Sub FgD_BeforeAddRow(sender As Object, e As RowColEventArgs) Handles FgD.BeforeAddRow
        Try
            If FlexiLiquidada Then
                e.Cancel = True
                Return
            End If
            If FlexiSoloLectura Then
                Dim i As Integer
                If FgD.Row > 99 And ENTRA_D Then
                    For i = 1 To 9
                        If e.Col = 1 And e.Row = i Then
                            e.Cancel = True
                        End If
                    Next
                End If
            Else
                If FgD.Row > 99 And ENTRA_D Then
                    If FgD.Row > 1 Then
                        If Not String.IsNullOrEmpty(FgD(FgD.Row - 1, 1)) Then
                            If FgD(FgD.Row - 1, 1).ToString.Trim.Length = 0 Then
                                e.Cancel = True
                            End If
                        End If
                        If Not String.IsNullOrEmpty(FgD(FgD.Row - 1, 2)) Then
                            If FgD(FgD.Row - 1, 2).ToString.Trim.Length = 0 Then
                                e.Cancel = True
                            End If
                        End If
                        If Not String.IsNullOrEmpty(FgD(FgD.Row - 1, 4)) Then
                            If FgD(FgD.Row - 1, 4).ToString.Trim.Length = 0 Then
                                e.Cancel = True
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1140. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgD.BeforeEdit
        Try
            If FgD.Row > 0 And ENTRA_D Then
                If FlexiLiquidada Then
                    e.Cancel = True
                    Return
                End If
                'If Not IsNothing(FgD(FgD.Row, 12)) Then
                'If FgD(FgD.Row, 12).ToString.Trim.Length > 0 Then
                'FgD.FinishEditing()
                'Return
                'End If
                'End If
                If FgD.Col = 1 Or FgD.Col = 3 Or FgD.Col = 5 Or FgD.Col = 6 Or FgD.Col = 7 Or FgD.Col = 9 Or FgD.Col = 11 Or FgD.Col = 12 Or FgD.Col = 13 Then

                    If FgD(FgD.Row, 2) = "0" Then

                    Else
                        e.Cancel = True
                    End If

                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles FgD.ComboCloseUp
        Try
            If FlexiLiquidada Then
                e.Cancel = True
                Return
            End If
            'If FgD(e.Row, 12).ToString.Trim.Length > 0 Then
            'FgD.FinishEditing()
            'Return
            'End If

            If FgD.Row > 99 And ENTRA_D Then
                If FgD.Col = 4 Then
                    FgD.Col = 5
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgD_EnterCell(sender As Object, e As EventArgs) Handles FgD.EnterCell
        Try
            If FgD.Row > 0 And ENTRA_D Then
                If FlexiLiquidada Then
                    Return
                End If
                ENTRA_D = False
                'If Not IsNothing(FgD(FgD.Row, 12)) Then
                'If FgD(FgD.Row, 12).ToString.Trim.Length > 0 Then
                'FgD.FinishEditing()
                'ENTRA_D = True
                'Return
                'End If
                'End If
                If FgD.Col <> 1 And FgD.Col <> 3 And FgD.Col <> 5 And FgD.Col <> 6 And FgD.Col <> 7 And FgD.Col <> 9 And
                    FgD.Col <> 11 And FgD.Col <> 12 And FgD.Col <> 13 Then

                    FgD.StartEditing()
                Else
                    If FgD.Col = 3 Then
                        If Not IsNothing(FgD(FgD.Row, 2)) Then
                            If FgD(FgD.Row, 2).ToString.Trim.Length = 0 Or FgD(FgD.Row, 2) = "0" Then
                                FgD.StartEditing()
                            End If
                        End If
                    End If
                End If
                ENTRA_D = True
            End If
        Catch ex As Exception
            BITACORA_LIQ("1800. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("1800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgD_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgD.KeyDownEdit
        Try
            If FlexiLiquidada Then
                Return
            End If
            If e.KeyCode = Keys.F2 Then
                If FgD.Row > 0 Then
                    If Not IsNothing(FgD(FgD.Row, 8)) Then
                        If FgD(FgD.Row, 8).ToString.Trim.Length > 0 Then
                            'FgD.FinishEditing()
                            'Return
                        End If

                        If FgD.Col = 2 Then
                            FgD_CellButtonClick(Nothing, Nothing)
                        End If

                    End If
                End If
            End If
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                If e.Col = 2 Then
                    ENTRA_D = False
                    FgD.Col = 8
                    TBotonMagicoD_GotFocus(Nothing, Nothing)
                    'tABONAR.Focus()
                    'tABONAR.Select()
                    'FgD.StartEditing()
                    ENTRA_D = True
                End If
                If e.Col = 3 Then
                    FgD.Col = 8
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1820. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TBotonMagicoD_GotFocus(sender As Object, e As EventArgs) Handles TBotonMagicoD.GotFocus
        Try
            c_ = FgD.Col
            'FgD.Select()
            FgD.Focus()
            FgD.Col = c_
            FgD.StartEditing()

        Catch ex As Exception
            BITACORA_LIQ("2200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_DoubleClick(sender As Object, e As EventArgs) Handles FgD.DoubleClick
        Try
            ENTRA_D = True
            If FgD.Row > 99 And ENTRA_D Then
                ENTRA_D = False
                If FgD(FgD.Row, 12).ToString.Trim.Length > 0 Then
                    FgD.FinishEditing()
                    ENTRA_D = True
                    Return
                End If
                ENTRA_D = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgD_StartEdit(sender As Object, e As RowColEventArgs) Handles FgD.StartEdit
        Try
            If FgD.Row > 99 And ENTRA_D Then
                ENTRA_D = False
                If FgD(FgD.Row, 12).ToString.Trim.Length > 0 Then
                    FgD.FinishEditing()
                    ENTRA_D = True
                    Return
                End If
                ENTRA_D = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgD_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgD.ValidateEdit
        Dim Precio As Decimal
        Try
            If FlexiLiquidada Then
                e.Cancel = True
                Return
            End If
            If e.Row > 0 Then
                Try
                    If e.Col = 2 Then
                        If FgD.Editor.Text.Trim.Length = 0 Or FgD.Editor.Text.Trim = "0" Then
                            FgD(e.Row, 5) = ""
                            FgD(e.Row, 6) = ""
                            FgD(e.Row, 7) = ""
                            FgD(e.Row, 8) = ""
                            FgD(e.Row, 9) = ""
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If e.Row > 99 And ENTRA Then
                ENTRA = False
                If e.Col = 88 Then
                    If Not String.IsNullOrEmpty(FgD.Editor.Text) Then
                        If IsNumeric(FgD.Editor.Text) Then
                            Precio = CSng(FgD.Editor.Text)
                            If Precio > 0 Then
                                FgD.FinishEditing()
                                'FgF.Row = FgF.Row + 1
                                'FgF.Col = 0
                                Dim TOT As Decimal = 0
                                Try
                                    If IsNumeric(FgD(FgD.Row, 5)) Then
                                        TOT = CDec(FgD(FgD.Row, 5))
                                    End If
                                Catch ex As Exception
                                End Try
                                If FgD.Row = 1 Then
                                    Try
                                        If Not IsNothing(FgD(1, 2)) Then
                                            If Not String.IsNullOrEmpty(FgD(1, 2).ToString.Trim) Then
                                                If FgD(1, 2).ToString.Trim.Length > 0 Then
                                                    If FgD.Row = FgD.Rows.Count - 1 Then
                                                        '                         1             2            3             4            5 
                                                        '                      FOLIO LIQ.  folio dedudc     descr        fecha      imp. prestamo
                                                        FgD.AddItem("" & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab &
                                                                    "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab & "0")
                                                        '         pagado         saldo         abonar     saldo actual     obser         num_par        uuid       cve_obs   
                                                        '            6             7             8             9             10           11              12          13
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("1220. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Else
                                    Try
                                        If Not IsNothing(FgD(FgD.Rows.Count - 1, 2)) Then
                                            If Not String.IsNullOrEmpty(FgD(FgD.Rows.Count - 1, 2).ToString.Trim) Then
                                                If FgD(FgD.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                                                    If FgD.Row = FgD.Rows.Count - 1 Then
                                                        '                         1             2            3             4            5 
                                                        '                      FOLIO LIQ.  folio dedudc     descr        fecha      imp. prestamo
                                                        FgD.AddItem("" & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab &
                                                                    "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab & "0")
                                                        '         pagado         saldo         abonar     saldo actual     obser         num_par        uuid       cve_obs   
                                                        '            6             7             8             9             10           11              12          13
                                                    End If
                                                End If
                                            End If
                                        End If

                                    Catch ex As Exception
                                        BITACORA_LIQ("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("1240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                                'FgD.Row = FgD.Rows.Count - 1
                                'FgD.Col = 1
                            Else
                                e.Cancel = True
                                'FgN.Row = FgF.Row + 1
                                'FgN.Col = 1
                            End If
                        End If
                    End If
                    'FgD.FinishEditing()
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORA_LIQ("1260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgD.CellButtonClick
        Try

            If LtTipoCrobro.Text = "Edición" Then
                If FgD.Row > 0 And ENTRA_D Then
                    Try
                        If FgD.Row > 1 Then
                            If FgD(FgD.Row - 1, 2).ToString.Trim.Length = 0 Then
                                'Return
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("1520. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Var2 = "GCDEDUC_OPER"
                    Var3 = TCVE_OPER.Text
                    Var4 = ""
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Dim ExisDed As Boolean = False

                        Try
                            For k = 1 To FgD.Rows.Count - 1
                                If Not IsNothing(FgD(k, 2)) Then
                                    If FgD(k, 2) = Var4 And k <> FgD.Row Then
                                        ExisDed = True
                                    End If
                                End If
                            Next
                            If ExisDed Then
                                MsgBox("La deduccion ya fue agregada verique por favor")
                                Return
                            End If
                        Catch ex As Exception
                        End Try

                        FgD.FinishEditing(Var4)
                        'Var4 = Fg(Fg.Row, 1) 'FOLIO
                        'Var5 = Fg(Fg.Row, 2) 'DESCR DEDUCCION
                        'Var6 = Fg(Fg.Row, 3) 'DESCRIPCION DEDUDC OPER
                        'Var7 = Fg(Fg.Row, 4) 'IMPORTE PRESTAMO
                        'Var8 = Fg(Fg.Row, 5) 'SALDO
                        'Var9 = Fg(Fg.Row, 6) 'PAGO EN LIQ.
                        'Var10 = Fg(Fg.Row, 7) 'SALDO ACTUAL

                        'SALDO = CALCULAR_SALDO_DEDUC()

                        FgD(FgD.Row, 4) = Now
                        FgD(FgD.Row, 2) = Var4
                        FgD(FgD.Row, 3) = Var6
                        FgD(FgD.Row, 5) = Var7 'IMPORTE PRESTAMO
                        FgD(FgD.Row, 6) = Var9 'IMPORTE PAGADO
                        FgD(FgD.Row, 7) = Var8 'SALDO
                        FgD(FgD.Row, 9) = Var10
                        CALCULAR_IMPORTES()
                        FgD.Col = 8
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TOBSER_Validated(sender As Object, e As EventArgs) Handles TOBSER.Validated
        Try
            If FgD.Row > 0 Then
                If Not IsNothing(FgD(FgD.Row, 2)) Then
                    If FgD(FgD.Row, 2).ToString.Length > 0 Then
                        'FgD.AddItem("" & vbTab & " " & vbTab & " " & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab &
                        '            "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & " " & vbTab & "0" & vbTab & " " & vbTab & "0")
                        'FgD.Row = FgD.Rows.Count - 1
                        'FgD.Col = 2
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TABONAR_KeyDown(sender As Object, e As KeyEventArgs) Handles TABONAR.KeyDown
        Try
            If e.KeyCode = 13 Then
                ENTRA_D = False
                FgD.Col = 10

                ENTRA_D = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TABONAR_TextChanged(sender As Object, e As EventArgs) Handles TABONAR.TextChanged
        Try
            If FgD.Row > 0 And ENTRA_D Then
                ENTRA_D = False

                Dim SALDO As Decimal, ABONO As Decimal = 0
                Try
                    If FgD(FgD.Row, 2).ToString.Trim.Length > 0 And FgD(FgD.Row, 2).ToString <> "0" Then

                        If IsNumeric(TABONAR.Text) And IsNumeric(FgD(FgD.Row, 7)) Then
                            SALDO = FgD(FgD.Row, 7) - CDec(TABONAR.Value)

                            If SALDO < 0 Then
                                MsgBox("El abono no puede ser mayor al saldo " & SALDO & ", verifique por favor")
                                TABONAR.Value = 0
                                FgD(FgD.Row, 8) = 0
                                FgD(FgD.Row, 9) = 0
                            Else
                                If IsNumeric(TABONAR.Text) Then
                                    ABONO = CDec(TABONAR.Text)
                                    FgD(FgD.Row, 9) = FgD(FgD.Row, 7) - ABONO
                                    'FgD(FgD.Row, 7) = FgD(FgD.Row, 5) - ABONO
                                End If
                            End If
                            'FgD(FgD.Row, 6) = CDec(tABONAR.Text)
                            'CALCULAR_IMPORTES()
                        End If
                    Else
                        If IsNumeric(TABONAR.Text) Then
                            'CALCULAR_IMPORTES()
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                ENTRA_D = True
            End If
        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TABONAR_Validated(sender As Object, e As EventArgs) Handles TABONAR.Validated
        Try
            Dim SALDO As Decimal

            ENTRA_D = False
            If Not IsNothing(FgD(FgD.Row, 7)) Then
                If IsNumeric(TABONAR.Text) And IsNumeric(FgD(FgD.Row, 7)) Then

                    SALDO = FgD(FgD.Row, 7)

                    If SALDO < CDec(TABONAR.Text) And ENTRA_D Then
                        ENTRA_D = False
                        MsgBox("El abono no puede ser mayor al saldo, verifique por favor")
                        TABONAR.Text = "0.00"
                        TABONAR.SelectionStart = 3
                        TABONAR.SelectionLength = TABONAR.SelectionLength
                        TABONAR.Select()
                    Else
                        FgD.FinishEditing()
                        CALCULAR_IMPORTES()
                    End If
                End If
            End If
            ENTRA_D = True

        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA_D = True
    End Sub
    Private Function SUMA_DEDUCCIONES(Optional FABONO As Decimal = 0) As Decimal
        Dim SUMA As Decimal = 0

        Try
            For k = 1 To FgD.Rows.Count - 1
                If Not String.IsNullOrEmpty(FgD(k, 8)) Then
                    If FgD.Rows(k).IsVisible Then
                        If IsNumeric(FgD(k, 8)) Then
                            SUMA += FgD(k, 8)
                        End If
                    End If
                End If
            Next
            Return SUMA + FABONO
        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
            Return SUMA '+ ABONO
        End Try
    End Function

    Private Sub BtnEliminar_Click_1(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            Dim S1 As Decimal = 0, CADENA As String
            Try
                FgD.FinishEditing()

                If FgD.Row > 0 Then
                    If MsgBox("Realmente desea eliminar el renglon seleccionado?", vbYesNo) = vbYes Then
                        'FgD.RemoveItem(FgD.Row)
                        FgD(FgD.Row, 1) = "KILL"
                        CADENA = FgD(FgD.Row, 3)
                        If FgD(FgD.Row, 11).ToString.Length = 0 Or FgD(FgD.Row, 11) = 0 Then
                            FgD.RemoveItem(FgD.Row)
                        Else
                            FgD.Rows(FgD.Row).Visible = False
                        End If
                        CALCULAR_IMPORTES()
                    Else
                        Return
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("1620. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            BITACORA_LIQ("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgD_KeyDown(sender As Object, e As KeyEventArgs) Handles FgD.KeyDown
        Try
            If FlexiLiquidada Then
                Return
            End If
            If e.KeyCode = Keys.F2 Then
                If FgD.Row > 0 Then
                    If FgD.Col = 2 Then
                        FgD_CellButtonClick(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("1700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAddGC_Click(sender As Object, e As EventArgs) Handles BtnAddGC.Click
        Try
            If FgRowVis() = 0 Then
                FgGC.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                        "" & vbTab & "" & vbTab & Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab &
                        "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "")
                Try
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(FgGC.Rows.Count - 1, 2)
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1700. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                Try
                    Dim rw_ As Integer
                    rw_ = FgRowVis()

                    If Not IsNothing(FgGC(rw_, 2)) Then
                        If Not String.IsNullOrEmpty(FgGC(rw_, 2)) Then
                            If FgGC(rw_, 2).ToString.Trim.Length > 0 Then
                                FgGC.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                               "" & vbTab & "" & vbTab & Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab &
                                                               "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "")
                                Try
                                    If Not IsNothing(_myEditor) Then
                                        _myEditor.StartEditing(FgGC.Rows.Count - 1, 2)
                                    End If
                                Catch ex As Exception
                                End Try
                            Else
                                Debug.Print("1")
                                MsgBox("Por favor capture factura")
                                Try
                                    If Not IsNothing(_myEditor) Then
                                        _myEditor.StartEditing(FgGC.Rows.Count - 1, 2)
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("1700. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        Else
                            Debug.Print("2")
                            Try
                                If Not IsNothing(_myEditor) Then
                                    FgGC.Col = 2
                                    _myEditor.StartEditing(FgGC.Rows.Count - 1, 2)
                                End If
                            Catch ex As Exception
                                BITACORA_LIQ("1700. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            MsgBox("Por favor capture factura")
                        End If
                    Else
                        Debug.Print("3")
                        MsgBox("Por favor capture factura")
                        Fg.Col = _FgColSeleccione
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1701. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            BITACORA_LIQ("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function FgRowVis() As Integer
        Dim v As Integer = 0
        Try
            For k = 1 To FgGC.Rows.Count - 1
                If FgGC.Rows(k).IsVisible Then
                    v += 1
                End If
            Next
            Return v
        Catch ex As Exception
            Return 1
        End Try
    End Function

    Private Sub BtnEliminarGasto_Click(sender As Object, e As EventArgs) Handles BtnEliminarGasto.Click
        Try
            Dim S1 As Decimal = 0
            Try
                If FgGC.Row > 0 Then
                    If MsgBox("Realmente desea eliminar el renglon seleccionado?", vbYesNo) = vbYes Then

                        FgGC.Col = 1
                        FgGC(FgGC.Row, 1) = "KILL"
                        FgGC.Rows(FgGC.Row).Visible = False
                    Else
                        Return
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            For k = 1 To FgGC.Rows.Count - 1
                Try
                    If FgGC.Rows(FgGC.Row).IsVisible Then
                        S1 += FgGC(k, 13)
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            LtGastosComprobados.Text = Format(S1, "###,###,##0.00")

            Dim v As Integer = 0
            Try
                For k = 1 To FgGC.Rows.Count - 1
                    If FgGC.Rows(k).IsVisible Then
                        v += 1
                    End If
                Next
            Catch ex As Exception
            End Try

            If v > 0 Then
                FgGC.Col = 2
                Try
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(v, 2)
                    End If
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            BITACORA_LIQ("1780. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimirLiq_Click(sender As Object, e As EventArgs) Handles BarImprimirLiq.Click
        Dim RUTA_FORMATOS As String = ""

        If TCVE_LIQ.Text.Trim.Length > 0 Then
            Try
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportLiquidacion.mrt"
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
                StiReport1.Item("CVE_LIQ1") = CLng(TCVE_LIQ.Text)
                StiReport1.Item("CVE_LIQ2") = CLng(TCVE_LIQ.Text)
                StiReport1.Item("CVE_LIQ3") = CLng(TCVE_LIQ.Text)
                StiReport1.Item("CVE_LIQ4") = CLng(TCVE_LIQ.Text)
                StiReport1.Item("CVE_LIQ5") = CLng(TCVE_LIQ.Text)
                StiReport1.Item("CVE_OPER") = CLng(TCVE_OPER.Text)
                StiReport1.Item("CVE_TRACTOR") = TCVE_TRACTOR.Text
                StiReport1.Item("CVE_OPER_DED") = CLng(TCVE_OPER.Text)
                StiReport1.Render()
                'StiReport1.Print(True)
                StiReport1.Show()
            Catch ex As Exception
                BITACORA_LIQ("1840. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
                MsgBox("1840. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("Por favor seleccione un reseteo")
        End If
    End Sub
    Private Sub BarFinalizarLiq_Click(sender As Object, e As EventArgs) Handles BarFinalizarLiq.Click
        Dim DETEC_ERROR_VIOLATION_KEY As Boolean = False
        Try
            If Not Valida_Conexion() Then
                Return
            End If

            If IsNew Then
                MsgBox("Primero debe de grabar la liquidación")
                Return
            End If


            If TCVE_LIQ.Text.Trim.Length = 0 And Not IsNumeric(TCVE_LIQ.Text) Then
                Return
            End If

            SHOW_MENSAJE = "NO"
            BarGrabar_Click(Nothing, Nothing)
            SHOW_MENSAJE = ""

            Dim IMPORTE_LIQUIDAR As Decimal = 0, MONTO_ANTERIOR As Decimal = 0

            If IsNumeric(LtImporteLiquidar.Text.Replace(",", "")) Then
                IMPORTE_LIQUIDAR = CDec(LtImporteLiquidar.Text.Replace(",", ""))
                'If IMPORTE_LIQUIDAR < 0 Then
                'MsgBox("El importe a liquidar es menor a cero, No es posible finalizar la liquidación, verifique por favor ")
                'Return
                'End If
            End If

            SQL = "UPDATE GCLIQUIDACIONES SET STATUS = 'L', CVE_ST_LIQ = 2 WHERE CVE_LIQ = " & TCVE_LIQ.Text

            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                cmd2.CommandText = SQL
                returnValue = cmd2.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        Try
                            For k = 1 To FgD.Rows.Count - 1
                                If FgD.Rows(k).IsVisible Then
                                    If Not IsNothing(FgD(k, 2)) Then
                                        If Not String.IsNullOrEmpty(FgD(k, 2)) Then
                                            If FgD(k, 2).ToString.Trim.Length > 0 And IsNumeric(FgD(k, 2)) Then
                                                Dim IMPORTE As Decimal = 0
                                                Try
                                                    If Not IsNothing(FgD(k, 8)) Then
                                                        If Not String.IsNullOrEmpty(FgD(k, 8)) Then
                                                            If FgD(k, 8).ToString.Trim.Length > 0 Then
                                                                IMPORTE = FgD(k, 8)
                                                            End If
                                                        End If
                                                    End If
                                                Catch ex As Exception
                                                    BITACORA_LIQ("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                    MsgBox("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                End Try

                                                MONTO_ANTERIOR = FgD(k, 6)

                                                For j = 1 To 5
                                                    Try
                                                        If Valida_Conexion() Then
                                                            SQL = "UPDATE GCDEDUC_OPER SET SALDO = SALDO - " & IMPORTE & ", 
                                                                IMPORTE_PAGADO = IMPORTE_PAGADO + " & IMPORTE & " 
                                                                WHERE FOLIO = " & CLng(FgD(k, 2))
                                                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                                                cmd.CommandText = SQL
                                                                returnValue = cmd.ExecuteNonQuery().ToString
                                                                If returnValue IsNot Nothing Then
                                                                    If returnValue = "1" Then
                                                                    End If
                                                                End If
                                                            End Using
                                                            AJUSTA_DEDUCCIONES(CLng(FgD(k, 2)))
                                                            Exit For
                                                        End If
                                                    Catch ex As Exception
                                                        BITACORA_LIQ("620. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                    End Try
                                                Next
                                            End If
                                        End If
                                    End If
                                End If
                            Next

                            Using cmdSDO As SqlCommand = cnSAE.CreateCommand
                                cmdSDO.CommandText = "EXEC [dbo].[sp_LiqCalculaSueldo] @CveLiq"
                                cmdSDO.Parameters.Add("@CveLiq", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_LIQ.Text)
                                returnValue = cmdSDO.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using

                        Catch ex As Exception
                            BITACORA_LIQ("1840. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1840. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        ' ---------------------->>>>>>>>>>>>>>> generando deduciion si es negativo
                        If IMPORTE_LIQUIDAR < 0 Then

                            Dim FOLIO As Long, CVE_DED_OPER As Long

                            CVE_DED_OPER = GET_MAX("GCDEDUC_OPER", "CVE_DED_OPER")
                            FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")

                            SQL = "INSERT INTO GCDEDUC_OPER (CVE_DED_OPER, FOLIO, CVE_OPER, CVE_LIQ, CVE_DED, STATUS, DESCR, IMPORTE_PRESTAMO, 
                                IMPORTE_PAGADO, SALDO, PAGO_EN_LIQ, SALDO_ACTUAL, FECHA, CVE_RES, FECHAELAB, UUID) VALUES (@CVE_DED_OPER, @FOLIO, 
                                @CVE_OPER, @CVE_LIQ, @CVE_DED, 'A', @DESCR, @IMPORTE_PRESTAMO, @IMPORTE_PAGADO, @SALDO, @PAGO_EN_LIQ, @SALDO_ACTUAL, 
                                @FECHA, @CVE_RES, GETDATE(), NEWID())"
                            Try
                                For j = 1 To 5
                                    Try
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            cmd.Parameters.Add("@CVE_DED_OPER", SqlDbType.Int).Value = CVE_DED_OPER
                                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                                            cmd.Parameters.Add("@CVE_LIQ", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_LIQ.Text)
                                            cmd.Parameters.Add("@CVE_DED", SqlDbType.Int).Value = 10
                                            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = "Saldo liquidación " & TCVE_LIQ.Text & " reseteo " & TCVE_RES.Text
                                            cmd.Parameters.Add("@IMPORTE_PRESTAMO", SqlDbType.Float).Value = Math.Abs(IMPORTE_LIQUIDAR)
                                            cmd.Parameters.Add("@IMPORTE_PAGADO", SqlDbType.Float).Value = 0
                                            cmd.Parameters.Add("@SALDO", SqlDbType.Float).Value = Math.Abs(IMPORTE_LIQUIDAR)
                                            cmd.Parameters.Add("@PAGO_EN_LIQ", SqlDbType.Float).Value = 0
                                            cmd.Parameters.Add("@SALDO_ACTUAL", SqlDbType.Float).Value = 0
                                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date.ToString("dd/MM/yyyy")
                                            cmd.Parameters.Add("@CVE_RES", SqlDbType.Int).Value = CONVERTIR_TO_LONG(TCVE_RES.Text)
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                        Exit For
                                    Catch ex As SqlException
                                        For Each sqlError As SqlError In ex.Errors

                                            BITACORASQL(sqlError.Number & ", " & sqlError.ToString)

                                            Select Case sqlError.Number
                                                Case 207 ' 207 = InvalidColumn
                                                    Exit Select
                                                Case 547 ' 547 = (Foreign) Key violation
                                                    DETEC_ERROR_VIOLATION_KEY = True
                                                    Exit Select
                                                Case 2601, 2627 ' 2601 = (Primary) key violation
                                                    DETEC_ERROR_VIOLATION_KEY = True
                                                    Exit Select
                                                Case 3621 'The statement has been terminated.
                                                Case Else  'do your Stuff here
                                                    Exit Select
                                            End Select
                                        Next
                                    Catch ex As Exception
                                        BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                    If Valida_Conexion() Then
                                        If DETEC_ERROR_VIOLATION_KEY Then
                                            FOLIO = GET_MAX("GCDEDUC_OPER", "FOLIO")
                                        End If
                                    End If
                                Next
                            Catch ex As Exception
                                BITACORA_LIQ("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End If

                        MsgBox("La liquidación se finalizo satisfactoriamente")

                    End If
                End If
            End Using

        Catch ex As Exception
            BITACORA_LIQ("1860. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1860. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarGrabar.Enabled = False
        BarFinalizarLiq.Enabled = False

        Me.Close()

    End Sub

    Sub AJUSTA_DEDUCCIONES(FCVE_DED As Long)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(SUM(IMPORTE),0) AS SUMA_D FROM GCLIQ_DEDUCCIONES 
                        WHERE STATUS = 'A' AND CVE_DED = " & FCVE_DED
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand

                            If dr("SUMA_D") > 0 Then

                                SQL = "UPDATE GCDEDUC_OPER SET SALDO = IMPORTE_PRESTAMO - " & Math.Round(dr("SUMA_D"), 4) & ",
                                           IMPORTE_PAGADO = " & Math.Round(dr("SUMA_D"), 4) & " WHERE FOLIO = " & FCVE_DED
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End If
                        End Using
                    End If
                End Using
            End Using


        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles F1.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                TCVE_OPER.Select()
            End If
        Catch ex As Exception
            BITACORA_LIQ("1880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_RES_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_RES.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Tab1.SelectedIndex = 0
                Fg.Select()
            End If
        Catch ex As Exception
            BITACORA_LIQ("1890. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1890. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '######################################################################################################################################
    '######################################################################################################################################
    '######################################################################################################################################
    '######################################################################################################################################
    '######################################################################################################################################
    '######################################################################################################################################

    Private Sub FgGC_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgGC.CellButtonClick
        If FgGC.Row > 0 Then
            If LtTipoCrobro.Text = "Edición" Then
                '                 19 UIUID 
                'If FgGC(FgGC.Row, 19).ToString.Trim.Length > 0 Then
                'Return
                'End If

                If FgGC.Col = 4 Then
                    Try
                        Var2 = "InveLiq"
                        Var4 = "" : Var5 = ""
                        FgGC.FinishEditing()
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            ENTRA_LIQ = False
                            FgGC.FinishEditing()
                            FgGC(FgGC.Row, 3) = Var4
                            FgGC(FgGC.Row, 5) = Var5

                            LLENAR_GRID_ARTICULO(Var4)
                            Var2 = "" : Var4 = "" : Var5 = ""

                            ENTRA_LIQ = True
                            FgGC.Col = 6
                            Try
                                If Not IsNothing(_myEditor) Then
                                    _myEditor.StartEditing(e.Row, 6)
                                End If
                            Catch ex As Exception
                            End Try
                        Else
                            FgGC.Col = 2
                            Try
                                If Not IsNothing(_myEditor) Then
                                    _myEditor.StartEditing(e.Row, 2)
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORA_LIQ("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Return
                End If
                If FgGC.Col = 7 Then
                    Try
                        Var2 = "Prov"
                        Var4 = "" : Var5 = ""
                        FgGC.FinishEditing()
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) CLAVE
                            'Var5 = Fg(Fg.Row, 2) CIUDAD
                            'Var6 = Fg(Fg.Row, 3) MUNICIPIO
                            ENTRA_LIQ = False
                            FgGC.FinishEditing()
                            FgGC(FgGC.Row, 6) = Var4
                            FgGC(FgGC.Row, 8) = Var5
                            Var2 = "" : Var4 = "" : Var5 = ""
                            ENTRA_LIQ = True
                            FgGC.Col = 10

                            Try
                                If Not IsNothing(_myEditor) Then
                                    _myEditor.StartEditing(e.Row, 10)
                                End If
                            Catch ex As Exception
                            End Try
                        Else
                            FgGC.Col = 2
                            Try
                                If Not IsNothing(_myEditor) Then
                                    _myEditor.StartEditing(e.Row, 2)
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORA_LIQ("2020. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If

        End If
    End Sub
    Private Sub FgGC_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgGC.BeforeEdit
        Try
            If FlexiLiquidada Then
                e.Cancel = True
                Return
            End If
            If FlexiSoloLectura Then
                Dim i As Integer
                For i = 1 To 9
                    If e.Col = 1 And e.Row = i Then
                        e.Cancel = True
                    End If
                Next
            Else
                If e.Row > 0 And ENTRA_LIQ Then
                    If FgGC(e.Row, 19).ToString.Trim.Length > 0 Then
                        e.Cancel = True
                    Else
                        If FgGC.Col = 2 Or FgGC.Col = 3 Or FgGC.Col = 4 Or FgGC.Col = 6 Or FgGC.Col = 7 Or FgGC.Col = 9 Or FgGC.Col = 10 Or FgGC.Col = 14 Then
                            e.Cancel = False
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single, PRECIO As Decimal = 0

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 3),0) AS P3, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 4),0) AS P4, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 5),0) AS P5, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 6),0) AS P6, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 7),0) AS P7, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 8),0) AS P8, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 9),0) AS P9, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 10),0) AS P10, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 11),0) AS P11, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 12),0) AS P12, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 13),0) AS P13, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 14),0) AS P14 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                FgGC(FgGC.Row, 3) = dr("CVE_ART")
                FgGC(FgGC.Row, 5) = dr("DESCR")
                FgGC(FgGC.Row, 15) = dr("IMPUESTO1") 'IEPS
                FgGC(FgGC.Row, 16) = dr("IMPUESTO4") 'IVA
                LtUnidad.Text = FgGC(FgGC.Row, 16)
                CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            BITACORA_LIQ("5000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgGC_LostFocus(sender As Object, e As EventArgs) Handles FgGC.LostFocus
        Try
            If Not FlexiLiquidada Then
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(FgGC.Row, FgGC.Col)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgGC_EnterCell(sender As Object, e As EventArgs) Handles FgGC.EnterCell
        Try
            If FgGC.Row > 0 And ENTRA_LIQ Then
                If FlexiLiquidada Then
                    Return
                End If
                If Not IsNothing(FgGC(FgGC.Row, 19)) Then
                    If FgGC(FgGC.Row, 19).ToString.Trim.Length > 0 Then
                        Return
                    End If

                    If FgGC.Col = 2 Or FgGC.Col = 3 Or FgGC.Col = 4 Or FgGC.Col = 6 Or FgGC.Col = 7 Or FgGC.Col = 10 Or FgGC.Col = 14 Then
                        Dim c_ As Integer
                        c_ = FgGC.Col
                        Try
                            If Not IsNothing(_myEditor) Then
                                _myEditor.StartEditing(FgGC.Row, c_)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2060. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgGC_Click(sender As Object, e As EventArgs) Handles FgGC.Click
        Try
            If FgGC.Row > 0 Then
                If FlexiLiquidada Then
                    Return
                End If
                If FgGC(FgGC.Row, 19).ToString.Trim.Length > 0 Then
                    Return
                End If
                If ENTRA_LIQ Then
                    If FgGC.Col = 2 Or FgGC.Col = 3 Or FgGC.Col = 4 Or FgGC.Col = 6 Or FgGC.Col = 7 Or FgGC.Col = 10 Or FgGC.Col = 14 Then
                        Dim c_ As Integer
                        'If FgGC.Col = 4 Or FgGC.Col = 7 Then
                        'c_ = 1
                        'Else
                        c_ = FgGC.Col
                        'End If
                        Try
                            If Not IsNothing(_myEditor) Then
                                _myEditor.StartEditing(FgGC.Row, c_)
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        If FgGC.Col = 9 Then
                            FgGC.StartEditing()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgGC_StartEdit(sender As Object, e As RowColEventArgs) Handles FgGC.StartEdit
        Try
            If FgGC.Row > 0 Then
                If FlexiLiquidada Then
                    Return
                End If
                If FgGC(FgGC.Row, 19).ToString.Trim.Length > 0 Or FlexiSoloLectura Then
                    FgGC.FinishEditing()
                    Return
                End If

                If ENTRA_LIQ Then
                    If FgGC.Col = 9 Then

                    Else
                        If FgGC.Col = 2 Or FgGC.Col = 3 Or FgGC.Col = 4 Or FgGC.Col = 6 Or FgGC.Col = 7 Or FgGC.Col = 10 Or FgGC.Col = 14 Then
                            e.Cancel = True
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgGC_AfterScroll(sender As Object, e As RangeEventArgs) Handles FgGC.AfterScroll
        Try
            If ENTRA_LIQ Then
                If Not IsNothing(_myEditor) Then
                    If _myEditor.Visible Then
                        _myEditor.UpdatePosition()
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgGC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FgGC.KeyPress
        Try
            If ENTRA_LIQ Then
                If Not IsNothing(_myEditor) Then
                    _myEditor.SetPendingKey(e.KeyChar)
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CALCULAR_IMPORTES(Optional FABONO As Decimal = 0)
        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader
        Dim CVE_ART As String, IMPORTE As Single, CVE_ESQIMPU As Integer = 1, CAN_TOT As Single, PRECIO As Single, PRECIO_NETO As Single
        Dim cIeps As Single, cImpu As Single, IMP1APLA As Integer, IMP4APLA As Integer, TOTIMP1 As Single, TOTIMP2 As Single, TOTIMP3 As Single
        Dim TOTIMP4 As Single, IMPU1 As Single, IMPU4 As Single, cImpu2 As Single, cImpu3 As Single, ImporteIeps As Single, ImporteIVA As Single
        Dim PERCEP_X_VIAJE As Decimal = 0, OTRAS_PERCEP As Decimal, DEDUCCIONES As Decimal, DIF_COMPROBACION As Decimal
        Dim MONTO_RESETEO As Decimal


        If Not Valida_Conexion() Then
            Return
        End If

        cmd.Connection = cnSAE

        Try
            TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To FgGC.Rows.Count - 1

                If FgGC.Rows(i).IsVisible Then
                    Try
                        CVE_ART = FgGC(i, 3)
                        CVE_ART = CVE_ART.Replace("'", "")
                    Catch ex As Exception
                        CVE_ART = ""
                    End Try
                    Try
                        If CVE_ART.Length > 0 Then
                            Try
                                cmd.CommandText = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                                Reader = cmd.ExecuteReader
                                If Reader.HasRows Then
                                    If Reader.Read Then
                                        CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                    End If
                                End If
                                Reader.Close()
                            Catch ex As Exception
                                MsgBox("2090. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                                BITACORA_LIQ("2090. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                                Reader = cmd.ExecuteReader
                                If Reader.Read Then
                                    IMPU1 = CDec(Reader("IMPUESTO1"))
                                    IMPU4 = CDec(Reader("IMPUESTO4"))
                                    IMP1APLA = CInt(Reader("IMP1APLICA"))
                                    IMP4APLA = CInt(Reader("IMP4APLICA"))
                                End If
                                Reader.Close()
                            Catch ex As Exception
                                BITACORA_LIQ("2100. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("2100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                            End Try

                            Try
                                PRECIO = CDec(FgGC(i, 10))
                                PRECIO = Math.Round(CDec(PRECIO), 6)
                                PRECIO_NETO = PRECIO

                                cIeps = PRECIO_NETO * IMPU1 / 100
                                If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                    cImpu = (PRECIO_NETO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                                Else
                                    cImpu = PRECIO_NETO * IMPU4 / 100
                                End If

                                ImporteIeps += (PRECIO_NETO * IMPU1 / 100)
                                ImporteIVA += (PRECIO_NETO * IMPU4 / 100)

                                TOTIMP1 += cIeps
                                TOTIMP2 += cImpu2
                                TOTIMP3 += cImpu3
                                TOTIMP4 += cImpu

                                IMPORTE += (PRECIO_NETO + cIeps + cImpu)
                                CAN_TOT += PRECIO

                                FgGC(i, 11) = cImpu
                                FgGC(i, 12) = cIeps
                                FgGC(i, 13) = (PRECIO_NETO + cIeps + cImpu)

                            Catch ex As Exception
                                MsgBox("2120. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                                BITACORA_LIQ("2120. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox("2140. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        BITACORA_LIQ("2140. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End If
            Next
            LtGastosComprobados.Text = Format(CAN_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")

            Dim GASTOS_VIAJE As Decimal = 0, GASTOS_COMPROBADOS As Decimal = 0
            Dim PERC_X_VIAJE As Decimal = 0, OTRAS_PERC As Decimal = 0
            Try
                For k = 1 To FgG.Rows.Count - 1
                    If FgG.Rows(k).IsVisible Then
                        If FgG(k, 2).ToString.Length > 0 Then
                            If FgG(k, 1) Then
                                GASTOS_VIAJE += FgG(k, 7)
                            End If
                        End If
                    End If
                Next

                LtGastosDeViaje.Text = Format(GASTOS_VIAJE, "###,###,##0.00")   'NUEVO

                If FgG(FgG.Rows.Count - 1, 6).ToString.ToUpper = "TOTAL" Then
                    FgG(FgG.Rows.Count - 1, 7) = GASTOS_VIAJE
                Else
                    FgG.AddItem("5" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "TOTAL" & vbTab & GASTOS_VIAJE)
                End If
            Catch ex As Exception
                BITACORA_LIQ("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                Try
                    For k = 1 To Fg.Rows.Count - 1
                        If Fg.Rows(k).IsVisible Then
                            If Not IsNothing(Fg(k, _FgColNumViaje)) Then
                                If Fg(k, _FgColSeleccione) Then
                                    If Fg(k, _FgColNumViaje).ToString.Length > 0 Then
                                        PERC_X_VIAJE += Fg(k, _FgColSueldoViaje)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Catch ex As Exception
                    BITACORA_LIQ("1180. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If IsNumeric(LtOtrasPercep.Text.Replace(",", "")) Then
                    OTRAS_PERC = LtOtrasPercep.Text.Replace(",", "")
                End If

                LtPerXViaje.Text = Format(PERC_X_VIAJE, "###,###,##0.00") 'NUEVO

            Catch ex As Exception
                BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            GASTOS_COMPROBADOS = (CAN_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4)
            '                    SI               SI    
            DIF_COMPROBACION = GASTOS_VIAJE - GASTOS_COMPROBADOS

            LtDifCompro.Text = Format(DIF_COMPROBACION, "###,###,##0.00")

            DEDUCCIONES = SUMA_DEDUCCIONES() + FABONO

            LtTotDeduc.Text = Format(DEDUCCIONES, "###,###,##0.00")
            Me.Refresh()

            LtOtrasPercep.Text = Format(Math.Abs(GASTOS_VIAJE - GASTOS_COMPROBADOS), "###,###,##0.00")
            LtTotalPercep.Text = Format(PERC_X_VIAJE + GASTOS_COMPROBADOS, "###,###,##0.00")
            Try
                If IsNumeric(LtPerXViaje.Text.Replace(",", "")) Then 'NO
                    PERCEP_X_VIAJE = CDec(LtPerXViaje.Text.Replace(",", ""))
                End If
                If IsNumeric(LtOtrasPercep.Text.Replace(",", "")) Then 'SI
                    OTRAS_PERCEP = CDec(LtOtrasPercep.Text.Replace(",", ""))
                End If
            Catch ex As Exception
                BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If IsNumeric(LtDescXLitros.Text.Replace(",", "")) Then
                MONTO_RESETEO = LtDescXLitros.Text.Replace(",", "")
            End If

            Dim IMPORTE_LIQUIDAR As Decimal = 0, FACTOR As Decimal = 0, IMPORTE_PA As Decimal = 0, PENSION_ALIMENTICIA As Decimal = 0
            If DIF_COMPROBACION > 0 Then
                '                     total percepciones
                IMPORTE_LIQUIDAR = Format(PERCEP_X_VIAJE - DEDUCCIONES - Math.Abs(DIF_COMPROBACION), "###,###,##0.00")
            Else
                IMPORTE_LIQUIDAR = Format(PERCEP_X_VIAJE - DEDUCCIONES + Math.Abs(DIF_COMPROBACION), "###,###,##0.00")
            End If
            Try
                LtImporteLiquidar.Text = "0"
                Try 'PENSION ALIMENTICIA
                    For k = 1 To FgPA.Rows.Count - 1
                        If FgPA.Rows(k).IsVisible Then
                            If Not IsNothing(FgPA(k, 2)) Then
                                If FgPA(k, 2).ToString.Length > 0 Then
                                    If IsNumeric(FgPA(k, 6)) Then
                                        FACTOR = FgPA(k, 6)
                                        IMPORTE_PA = IMPORTE_LIQUIDAR * FACTOR / 100
                                        FgPA(k, 7) = IMPORTE_PA
                                        PENSION_ALIMENTICIA += IMPORTE_PA
                                    End If
                                End If
                            End If
                        End If
                    Next
                    If IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA > 0 Then
                        LtPA.Text = Format(PENSION_ALIMENTICIA, "###,###,##0.00")
                        LtImporteLiquidar.Text = Format(IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA, "###,###,##0.00")
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("2160. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                LtSubtotal.Text = LtImporteLiquidar.Text

            Catch ex As Exception
                BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            LtImporteLiquidar.Text = Format(IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA, "###,###,##0.00")
            Me.Refresh()

        Catch ex As Exception
            BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function CALCULAR_IMPORTES_FINAL_AL_GRABAR() As Decimal

        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader
        Dim CVE_ART As String, IMPORTE As Decimal, CVE_ESQIMPU As Integer = 1, CAN_TOT As Decimal, PRECIO As Decimal, PRECIO_NETO As Decimal
        Dim cIeps As Decimal, cImpu As Decimal, IMP1APLA As Integer, IMP4APLA As Integer, TOTIMP1 As Decimal = 0, TOTIMP2 As Decimal = 0, TOTIMP3 As Decimal = 0
        Dim TOTIMP4 As Decimal = 0, IMPU1 As Decimal, IMPU4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, ImporteIeps As Decimal, ImporteIVA As Decimal
        Dim PERCEP_X_VIAJE As Decimal = 0, DEDUCCIONES As Decimal, DIF_COMPROBACION As Decimal
        Dim IMPORTE_LIQUIDAR As Decimal, FACTOR As Decimal, IMPORTE_PA As Decimal, PENSION_ALIMENTICIA As Decimal = 0
        Dim GASTOS_VIAJE As Decimal = 0, GASTOS_COMPROBADOS As Decimal
        Dim PERC_X_VIAJE As Decimal = 0, IMPORTE_A_LIQUIDAR As Decimal = 0

        If Not Valida_Conexion() Then
            Return 0
        End If

        cmd.Connection = cnSAE

        Try
            For i As Integer = 1 To FgGC.Rows.Count - 1

                If FgGC.Rows(i).IsVisible Then
                    Try
                        CVE_ART = FgGC(i, 3)
                        CVE_ART = CVE_ART.Replace("'", "")
                    Catch ex As Exception
                        CVE_ART = ""
                    End Try
                    Try
                        If CVE_ART.Length > 0 Then
                            cmd.CommandText = "SELECT * FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                End If
                            End If
                            Reader.Close()
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CDec(Reader("IMPUESTO1"))
                                IMPU4 = CDec(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            End If
                            Reader.Close()

                            PRECIO = CDec(FgGC(i, 10))
                            PRECIO = Math.Round(CDec(PRECIO), 6)
                            PRECIO_NETO = PRECIO

                            cIeps = PRECIO_NETO * IMPU1 / 100
                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (PRECIO_NETO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = PRECIO_NETO * IMPU4 / 100
                            End If

                            ImporteIeps += (PRECIO_NETO * IMPU1 / 100)
                            ImporteIVA += (PRECIO_NETO * IMPU4 / 100)

                            TOTIMP1 += cIeps
                            TOTIMP2 += cImpu2
                            TOTIMP3 += cImpu3
                            TOTIMP4 += cImpu

                            IMPORTE += (PRECIO_NETO + cIeps + cImpu)
                            CAN_TOT += PRECIO
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("2140. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            Try
                For k = 1 To FgG.Rows.Count - 1
                    If FgG.Rows(k).IsVisible Then
                        If FgG(k, 2).ToString.Length > 0 Then
                            If FgG(k, 1) Then
                                GASTOS_VIAJE += FgG(k, 7)
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                BITACORA_LIQ("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                For k = 1 To Fg.Rows.Count - 1
                    If Fg.Rows(k).IsVisible Then
                        If Not IsNothing(Fg(k, _FgColNumViaje)) Then
                            If Fg(k, _FgColSeleccione) Then
                                If Fg(k, _FgColNumViaje).ToString.Length > 0 Then
                                    PERC_X_VIAJE += Fg(k, _FgColSueldoViaje)
                                End If
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            GASTOS_COMPROBADOS = (CAN_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4)
            DIF_COMPROBACION = GASTOS_VIAJE - GASTOS_COMPROBADOS 'ok
            DEDUCCIONES = SUMA_DEDUCCIONES()

            Try
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, _FgColSueldoViaje)) Then
                        If Not IsDBNull(Fg(k, _FgColSueldoViaje)) Then
                            If IsNumeric(Fg(k, _FgColSueldoViaje)) Then
                                PERCEP_X_VIAJE += Fg(k, _FgColSueldoViaje)
                            End If
                        End If
                    End If
                Next
            Catch ex As Exception
                BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If DIF_COMPROBACION > 0 Then
                IMPORTE_LIQUIDAR = PERCEP_X_VIAJE - DEDUCCIONES - Math.Abs(DIF_COMPROBACION)
            Else
                IMPORTE_LIQUIDAR = PERCEP_X_VIAJE - DEDUCCIONES + Math.Abs(DIF_COMPROBACION)
            End If
            Try 'PENSION ALIMENTICIA
                For k = 1 To FgPA.Rows.Count - 1
                    If FgPA.Rows(k).IsVisible Then
                        If Not IsNothing(FgPA(k, 2)) Then
                            If FgPA(k, 2).ToString.Length > 0 Then
                                If IsNumeric(FgPA(k, 6)) Then
                                    FACTOR = FgPA(k, 6)
                                    IMPORTE_PA = IMPORTE_LIQUIDAR * FACTOR
                                    PENSION_ALIMENTICIA += IMPORTE_PA
                                End If
                            End If
                        End If
                    End If
                Next
                If IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA > 0 Then
                    IMPORTE_A_LIQUIDAR = Format(IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA, "###,###,##0.00")
                End If
            Catch ex As Exception
                BITACORA_LIQ("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            IMPORTE_A_LIQUIDAR = Format(IMPORTE_LIQUIDAR - PENSION_ALIMENTICIA, "###,###,##0.00")
        Catch ex As Exception
            BITACORA_LIQ("2180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Return IMPORTE_A_LIQUIDAR

    End Function

    Private Sub TBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles TBotonMagico.GotFocus
        Try
            FgGC.Select()
            Dim c_ As Integer
            If FgGC.Col = 4 Then
                c_ = 3
            Else
                c_ = FgGC.Col
            End If
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(FgGC.Row, c_)
            End If
        Catch ex As Exception
            BITACORA_LIQ("2200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged
        Try
            Select Case Tab1.SelectedIndex
                Case 0
                Case 1
                Case 2
                Case 3
                    FgGC.Select()
                    Try
                        FgGC.Row = FgGC.Rows.Count - 1
                        FgGC.Col = 2
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(FgGC.Rows.Count - 1, 0)
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        Catch ex As Exception
            BITACORA_LIQ("2220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnObs_Click(sender As Object, e As EventArgs)
        Try
            If FgGC.Row > 0 Then
                Var4 = FgGC(FgGC.Row, 14)
                Var5 = "NUEVO"
                frmObserDocumento.ShowDialog()
                FgGC(FgGC.Row, 14) = Var4

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarCancelacion_Click(sender As Object, e As EventArgs) Handles BarCancelacion.Click
        Try
            If Not Valida_Conexion() Then
                Return
            End If

            If LtTipoCrobro.Text = "Cancelado" Then
                MsgBox("La liquidación se encuengra cancelada")
                Return
            End If

            If LtTipoCrobro.Text = "Contabilizada" Then
                MsgBox("La liquidación se encuengra contabilizada no es posible realizar la cancelación")
                Return
            End If
            If LtTipoCrobro.Text = "Depositada" Then
                MsgBox("La liquidación se encuengra depositada no es posible realizar la cancelación")
                Return
            End If

            If MsgBox("Realmente desea cancelar la liquidación?", vbYesNo) = vbYes Then

                Var4 = ""
                FrmMotivoBaja.ShowDialog()

                If Var4.Trim.Length > 0 Then
                    Dim CVE_MTC As Long = 0
                    Try
                        CVE_MTC = GRABA_MOTIVO_CANC("LIQUIDACIONES", Var4)
                    Catch ex As Exception
                        BITACORA_LIQ("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    SQL = "UPDATE GCLIQUIDACIONES SET STATUS = 'C', CVE_MTC = " & CVE_MTC & " WHERE CVE_LIQ = " & CLng(TCVE_LIQ.Text)

                    Dim cmd As New SqlCommand With {
                        .Connection = cnSAE,
                        .CommandText = SQL
                    }
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            For k = 1 To Fg.Rows.Count - 1
                                If Not IsNothing(Fg(k, _FgColNumViaje)) Then
                                    If Not String.IsNullOrEmpty(Fg(k, _FgColNumViaje)) Then
                                        If Fg(k, _FgColNumViaje).ToString.Trim.Length > 0 Then

                                            If Not Valida_Conexion() Then
                                            End If

                                            Try
                                                SQL = "UPDATE GCLIQ_PARTIDAS SET STATUS = 'C' WHERE UUID = '" & Fg(k, _FgColUUID) & "'"
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        Else

                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                                MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                            Try
                                                SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_ST_VIA = 6 WHERE CVE_VIAJE = '" & Fg(k, _FgColNumViaje) & "'"
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        Else
                                                            If PASS_GRUPOCE.ToUpper = "GOHAN" Then
                                                                'MsgBox("Cristian tomale una foto a esta ventana y enviamela por fa" & vbNewLine & SQL)
                                                            End If
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                                MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End If
                                End If
                            Next
                            'GASTOS DE VIAJE FgG
                            For k = 1 To FgG.Rows.Count - 1
                                Try
                                    If Not IsNothing(FgG(k, 2)) Then
                                        If Not String.IsNullOrEmpty(FgG(k, 2)) Then
                                            If FgG(k, 3).ToString.Trim.Length > 0 Then

                                                If Not Valida_Conexion() Then
                                                End If

                                                SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET STATUS = 'A', CVE_LIQ = 0 WHERE 
                                                    CVE_VIAJE = '" & FgG(k, 2) & "' AND FOLIO = '" & FgG(k, 3) & "'"
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            '************* FIN GASTOS DE VIAJE

                            'VALES DE VIAJE FgV
                            For k = 1 To FgV.Rows.Count - 1
                                Try
                                    If Not IsNothing(FgV(k, 1)) Then
                                        If Not String.IsNullOrEmpty(FgV(k, 1)) Then
                                            If FgV(k, 2).ToString.Trim.Length > 0 Then

                                                If Not Valida_Conexion() Then
                                                End If

                                                SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET STATUS = 'A', CVE_LIQ = 0 WHERE 
                                                    CVE_VIAJE = '" & FgV(k, 1) & "' AND FOLIO = '" & FgV(k, 2) & "'"
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Next
                            '************* FIN VALES DE VIAJE
                            Try
                                'LIQ. GASTOS COMPROBADOS
                                If Not Valida_Conexion() Then
                                End If

                                SQL = "UPDATE GCLIQ_GASTOS_COMPROBADOS SET STATUS = 'C' WHERE CVE_LIQ = " & CLng(TCVE_LIQ.Text)
                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    cmd3.CommandText = SQL
                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            'LIQ. DEDUCCIONES
                            Try
                                If Not Valida_Conexion() Then
                                End If
                                SQL = "UPDATE GCLIQ_DEDUCCIONES SET STATUS = 'C' WHERE CVE_LIQ = " & CLng(TCVE_LIQ.Text)
                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    cmd3.CommandText = SQL
                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            'SALDO DEDUCCIONES
                            Try
                                Dim ABONO As Decimal = 0, FOLIO_DED As Long = 0, IMPORTE_PAGADO As Decimal = 0

                                For k = 1 To FgD.Rows.Count - 1
                                    Try
                                        If Not IsNothing(FgD(k, 11)) Then
                                            If IsNumeric(FgD(k, 11)) Then
                                                If Not IsNothing(FgD(k, 2)) Then
                                                    If IsNumeric(FgD(k, 2)) Then
                                                        If IsNumeric(FgD(k, 6)) Then

                                                            FOLIO_DED = CLng(FgD(k, 2))

                                                            If Not Valida_Conexion() Then
                                                            End If

                                                            IMPORTE_PAGADO = OBTEN_IMPORTE_PAGADO_GCDEDUC_OPER(FOLIO_DED)

                                                            SQL = "UPDATE GCDEDUC_OPER SET STATUS = 'A', 
                                                                IMPORTE_PAGADO = IMPORTE_PAGADO - " & IMPORTE_PAGADO & ", 
                                                                SALDO = SALDO + " & IMPORTE_PAGADO & "
                                                                WHERE FOLIO = " & FOLIO_DED
                                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                                cmd2.CommandText = SQL
                                                                returnValue = cmd2.ExecuteNonQuery().ToString
                                                                If returnValue IsNot Nothing Then
                                                                    If returnValue = "1" Then
                                                                    End If
                                                                End If
                                                            End Using
                                                            AJUSTA_DEDUCCIONES(FOLIO_DED)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    Catch ex As Exception
                                        BITACORA_LIQ("720. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                    End Try
                                Next
                            Catch ex As Exception
                                BITACORA_LIQ("730. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            'BORRANDO DEDUCCION 10
                            Try
                                SQL = "DELETE FROM GCDEDUC_OPER WHERE CVE_LIQ = " & CLng(TCVE_LIQ.Text) & " AND CVE_DED = 10"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                If CONVERTIR_TO_INT(TCVE_RES.Text) > 0 Then
                                    If Not Valida_Conexion() Then
                                    End If

                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        ' ANTES "EN LIQUIDACION"
                                        SQL = "UPDATE GCRESETEO SET ESTADO = 'FINALIZADO' 
                                            WHERE CVE_RES = " & CONVERTIR_TO_LONG(TCVE_RES.Text)
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                        Try
                                            SQL = "UPDATE GCDEDUC_OPER SET STATUS = 'C' WHERE CVE_LIQ = " & CLng(TCVE_LIQ.Text) & " AND 
                                                CVE_RES = " & CONVERTIR_TO_LONG(TCVE_RES.Text)
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                cmd2.CommandText = SQL
                                                returnValue = cmd2.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End Using
                                End If
                            Catch ex As Exception
                                BITACORA_LIQ("160. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Dim ResultMensaje As String
                            ResultMensaje = MensajeBox("!! La liquidación se cancelo correctamente !!", "Proceso finalizado", "Information")

                            Me.Close()
                        Else
                            MsgBox("!!NO se logro cancelar la liquidación!!")
                        End If
                    Else
                        MsgBox("!!NO se logro cancelar la liquidación!!")
                    End If
                Else
                    Dim ResultMensaje As String
                    ResultMensaje = MensajeBox("!! Cancelación abortada ¡¡", "Proceso finalizado", "Error")
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function OBTEN_IMPORTE_PAGADO_GCDEDUC_OPER(FFOLIO As Long) As Decimal
        Dim IMPORTE_PAGADO As Decimal = 0
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT IMPORTE_PAGADO FROM GCDEDUC_OPER WHERE FOLIO = " & FFOLIO
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        IMPORTE_PAGADO = dr("IMPORTE_PAGADO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORA_LIQ("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return IMPORTE_PAGADO

    End Function
    Private Sub TMagic_GotFocus(sender As Object, e As EventArgs) Handles tMagic.GotFocus
        'FgD.Select()
        FgD.Col = 10
    End Sub
    Private Sub FgG_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgG.BeforeEdit
        Try
            If FlexiSoloLectura Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TABONAR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TABONAR.KeyPress
        If FlexiSoloLectura Then
        End If
    End Sub
    Private Sub TOBSER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOBSER.KeyPress
        If FlexiSoloLectura Then
        End If
    End Sub
    Private Sub BtnGastosViaje_Click(sender As Object, e As EventArgs) Handles BtnGastosViaje.Click
        Try
            Var18 = TCVE_OPER.Text
            Var19 = TCVE_TRACTOR.Text
            FrmSelGastosViaje.ShowDialog()

            CALCULA_SUMA_GC_GV()
            CALCULAR_IMPORTES()

        Catch ex As Exception
            BITACORA_LIQ("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULA_SUMA_GC_GV()
        Dim GASTOS_VIAJE As Decimal = 0, GASTOS_COMPROBADOS As Decimal = 0
        Try
            For k = 1 To FgGC.Rows.Count - 1
                If FgGC.Rows(k).IsVisible Then
                    GASTOS_COMPROBADOS += FgGC(k, 13)
                End If
            Next
        Catch ex As Exception
            BITACORA_LIQ("1160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            For k = 1 To FgG.Rows.Count - 1
                If FgG.Rows(k).IsVisible Then
                    If FgG(k, 1) Then
                        GASTOS_VIAJE += FgG(k, 7)
                    End If
                End If
            Next
            LtGastosDeViaje.Text = Format(GASTOS_VIAJE, "###,###,##0.00")

            If FgG(FgG.Rows.Count - 1, 6) = "TOTAL" Then
                FgG(FgG.Rows.Count - 1, 7) = GASTOS_VIAJE
            End If

        Catch ex As Exception
            BITACORA_LIQ("1180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        LtDifCompro.Text = Format(GASTOS_VIAJE - GASTOS_COMPROBADOS, "###,###,##0.00")

    End Sub
    Private Sub BtnGastosViajeEliminar_Click(sender As Object, e As EventArgs) Handles BtnGastosViajeEliminar.Click
        Try
            Dim Sigue As Boolean = False
            If FgG.Row > 0 Then

                If LtTipoCrobro.Text = "Edición" Then
                    Sigue = True
                End If
                If Sigue Then
                    If MsgBox("Realmente desea eliminar el gastos seleccionado?", vbYesNo) = vbYes Then
                        SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET STATUS = 'A', CVE_LIQ = 0
                             WHERE CVE_VIAJE = '" & FgG(FgG.Row, 2) & "' AND FOLIO = '" & FgG(FgG.Row, 3) & "'"

                        If EXECUTE_QUERY_NET(SQL) Then
                        End If

                        FgG.RemoveItem(FgG.Row)

                        CALCULA_SUMA_GC_GV()
                        MsgBox("El gastos se elimino satisfactoriamente")
                    End If
                Else
                    MsgBox("El gastos no puede ser eliminado porque se encuentra DEPOSITADO")
                End If
            Else
                MsgBox("Por favor seleccione el gasto a eliminar")
            End If
        Catch ex As Exception
            BITACORA_LIQ("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgG_CellChecked(sender As Object, e As RowColEventArgs) Handles FgG.CellChecked
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeStateG(FgG.GetCellCheck(e.Row, e.Col))
            End If
            CALCULAR_IMPORTES()
        Catch ex As Exception
            BITACORA_LIQ("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TDESCR_KeyDown(sender As Object, e As KeyEventArgs) Handles TDESCR.KeyDown
        Try
            If e.KeyCode = 13 Then
                TABONAR.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TDESCR_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TDESCR.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                FgD.Col = 8
                FgD.StartEditing()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TABONAR_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TABONAR.PreviewKeyDown
        If e.KeyCode = 9 Then
            FgD.Col = 10

            FgD.StartEditing()
        End If
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell

    End Sub

    Private Sub FgG_OwnerDrawCell(sender As Object, e As C1.Win.C1FlexGrid.OwnerDrawCellEventArgs) Handles FgG.OwnerDrawCell

    End Sub
    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = Fg.Rows.Fixed To Fg.Rows.Count - 1
            Fg.SetCellCheck(row, _FgColSeleccione, state)
        Next
    End Sub

    Private Sub TBotonMagicoD_TextChanged(sender As Object, e As EventArgs) Handles TBotonMagicoD.TextChanged

    End Sub

    Private Sub ChangeStateG(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = FgG.Rows.Fixed To FgG.Rows.Count - 1
            FgG.SetCellCheck(row, 1, state)
        Next
    End Sub


    Private Sub TABONAR_Click(sender As Object, e As EventArgs) Handles TABONAR.Click
        JustGotFocus = True

        If JustGotFocus Then
            TABONAR.SelectAll()
        End If
    End Sub

    Private Sub TABONAR_Enter(sender As Object, e As EventArgs) Handles TABONAR.Enter
        JustGotFocus = False

    End Sub

    Private Sub FgPA_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgPA.CellButtonClick
        Try
            If FgPA.Row > 0 Then
                If FgPA(FgPA.Row, 11).ToString.Trim.Length > 0 Then
                    Return
                End If

                If FgPA.Col = 3 Then
                    Try
                        Var2 = "InveLiq"
                        Var4 = "" : Var5 = ""
                        FgPA.FinishEditing()
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            ENTRA_LIQ = False
                            FgPA.FinishEditing()
                            FgPA(FgPA.Row, 2) = Var4
                            FgPA(FgPA.Row, 4) = Var5
                            Var2 = "" : Var4 = "" : Var5 = ""
                            ENTRA_LIQ = True
                            FgPA.Col = 6
                            Try
                                If Not IsNothing(_myEditorPa) Then
                                    _myEditorPa.StartEditing(e.Row, 6)
                                End If
                            Catch ex As Exception
                            End Try
                        Else
                            FgPA.Col = 6
                            Try
                                If Not IsNothing(_myEditorPa) Then
                                    _myEditorPa.StartEditing(e.Row, 6)
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                        BITACORA_LIQ("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Return
                End If
            End If

        Catch ex As Exception
            BITACORA_LIQ("2060. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgPA_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgPA.BeforeEdit
        Try
            If FlexiLiquidada Then
                e.Cancel = True
                Return
            End If
            If e.Row > 0 And ENTRA_LIQ Then
                If FgPA(e.Row, 11).ToString.Trim.Length > 0 Then
                    e.Cancel = True
                Else
                    If FgPA.Col = 2 Or FgPA.Col = 3 Or FgPA.Col = 6 Or FgPA.Col = 8 Then
                        e.Cancel = False
                    Else
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            BITACORA_LIQ("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgPA_LostFocus(sender As Object, e As EventArgs) Handles FgPA.LostFocus
        Try
            If Not FlexiLiquidada Then
                If Not IsNothing(_myEditorPa) Then
                    _myEditorPa.StartEditing(FgPA.Row, FgPA.Col)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FgPA_EnterCell(sender As Object, e As EventArgs) Handles FgPA.EnterCell
        Try
            If FgPA.Row > 0 And ENTRA_LIQ Then
                If FlexiLiquidada Then
                    Return
                End If
                If Not IsNothing(FgPA(FgPA.Row, 11)) Then
                    If FgPA(FgPA.Row, 11).ToString.Trim.Length > 0 Then
                        Return
                    End If

                    If FgPA.Col = 2 Or FgPA.Col = 6 Or FgPA.Col = 8 Then
                        Dim c_ As Integer
                        c_ = FgPA.Col
                        Try
                            If Not IsNothing(_myEditorPa) Then
                                _myEditorPa.StartEditing(FgPA.Row, c_)
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2060. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgPA_Click(sender As Object, e As EventArgs) Handles FgPA.Click
        Try
            If FgPA.Row > 0 Then
                If FlexiLiquidada Then
                    Return
                End If
                If FgPA(FgPA.Row, 11).ToString.Trim.Length > 0 Then
                    Return
                End If
                If ENTRA_LIQ Then
                    If FgPA.Col = 2 Or FgPA.Col = 6 Or FgPA.Col = 8 Then
                        Dim c_ As Integer
                        c_ = FgPA.Col
                        Try
                            If Not IsNothing(_myEditorPa) Then
                                _myEditorPa.StartEditing(FgPA.Row, c_)
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        If FgPA.Col = 9 Then
                            FgPA.StartEditing()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2060. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgPA_StartEdit(sender As Object, e As RowColEventArgs) Handles FgPA.StartEdit
        Try
            If FgPA.Row > 0 Then
                If FlexiLiquidada Then
                    Return
                End If
                If FgPA(FgPA.Row, 11).ToString.Trim.Length > 0 Then
                    FgPA.FinishEditing()
                    Return
                End If

                If ENTRA_LIQ Then
                    If FgPA.Col = 9 Then

                    Else
                        If FgPA.Col = 2 Or FgPA.Col = 6 Or FgPA.Col = 8 Then
                            e.Cancel = True
                        Else
                            e.Cancel = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgPA_AfterScroll(sender As Object, e As RangeEventArgs) Handles FgPA.AfterScroll
        If ENTRA_LIQ Then
            If Not IsNothing(_myEditorPa) Then
                If _myEditorPa.Visible Then
                    _myEditorPa.UpdatePosition()
                End If
            End If
        End If
    End Sub
    Private Function FgRowVisPA() As Integer
        Dim v As Integer = 0
        Try
            For k = 1 To FgPA.Rows.Count - 1
                If FgPA.Rows(k).IsVisible Then
                    v += 1
                End If
            Next
            Return v
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Private Sub BtnAltaPA_Click(sender As Object, e As EventArgs) Handles BtnAltaPA.Click
        Try
            If FgRowVisPA() = 0 Then
                '                                                     1                                    2           3            4          
                '                                                 Documento	                           Articulo      button	   descripcion	 
                FgPA.AddItem(FgPA.Rows.Count & vbTab & GET_MAX("GCLIQ_PENSION_ALI", "CVE_FOLIO") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                             Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                '                             5                    6            7            8            9           10            11
                '	       	                fecha	            factor	     total	      OBSER	       NUM_PAR     CVE_OBS       UUID
                Try
                    FgPA.Col = 2
                    If Not IsNothing(_myEditorPa) Then
                        _myEditorPa.StartEditing(FgPA.Rows.Count - 1, 2)
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1700. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                Try
                    Dim rw_ As Integer
                    rw_ = FgRowVisPA()

                    If Not IsNothing(FgPA(rw_, 2)) Then
                        If Not String.IsNullOrEmpty(FgPA(rw_, 2)) Then
                            If FgPA(rw_, 2).ToString.Trim.Length > 0 Then
                                '                                                     1                          2           3            4          
                                '                                                 Documento	               Articulo      button	   descripcion	 
                                FgPA.AddItem(FgPA.Rows.Count & vbTab & GET_MAX("GCLIQ_PENSION_ALI", "CVE_FOLIO") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                             Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                                '                             5                    6            7            8            9           10            11
                                '	       	                fecha	            factor	     total	      OBSER	       NUM_PAR     CVE_OBS       UUID
                                Try
                                    If Not IsNothing(_myEditorPa) Then
                                        _myEditorPa.StartEditing(FgPA.Rows.Count - 1, 2)
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1701. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            BITACORA_LIQ("1720. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1720. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliPartPA_Click(sender As Object, e As EventArgs) Handles BtnEliPartPA.Click
        Try
            Dim S1 As Decimal = 0
            Try
                If FgPA.Row > 0 Then
                    If MsgBox("Realmente desea eliminar el renglon seleccionado?", vbYesNo) = vbYes Then

                        FgPA.Col = 1
                        FgPA(FgPA.Row, 1) = "KILL"
                        FgPA.Rows(FgPA.Row).Visible = False
                    Else
                        Return
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            For k = 1 To FgPA.Rows.Count - 1
                Try
                    If FgPA.Rows(FgPA.Row).IsVisible Then
                        S1 += FgPA(k, 13)
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("1760. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            LtPA.Text = Format(S1, "###,###,##0.00")
            CALCULAR_IMPORTES()
            Dim v As Integer = 0
            Try
                For k = 1 To FgPA.Rows.Count - 1
                    If FgPA.Rows(k).IsVisible Then
                        v += 1
                    End If
                Next
            Catch ex As Exception
            End Try

            If v > 0 Then
                FgPA.Col = 2
                Try
                    If Not IsNothing(_myEditorPa) Then
                        _myEditorPa.StartEditing(v, 2)
                    End If
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception
            BITACORA_LIQ("1780. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgPA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles FgPA.KeyPress
        Try
            If ENTRA_LIQ Then
                If Not IsNothing(_myEditorPa) Then
                    _myEditorPa.SetPendingKey(e.KeyChar)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnOTrasPercep_Click(sender As Object, e As EventArgs) Handles BtnOTrasPercep.Click
        MsgBox("Si GASTOS_VIAJE-GASTOS_COMPROBADOS >= 0 
               then" & vbNewLine &
               "OtrasPercep = 0" & vbNewLine & "
               else" & vbNewLine & "
               TotalPercep = PERCEP_X_VIAJE+(GASTOS_VIAJE-GASTOS_COMPROBADOS)")
    End Sub

    Private Sub BtnToTPercep_Click(sender As Object, e As EventArgs) Handles BtnToTPercep.Click
        MsgBox("Si GASTOS_VIAJE-GASTOS_COMPROBADOS >= 0 " & vbNewLine & "
                then" & vbNewLine & "
                TotalPercep = PERCEP_X_VIAJE" & vbNewLine & "
                else" & vbNewLine & "
		        TotalPercep = PERCEP_X_VIAJE+(GASTOS_VIAJE-GASTOS_COMPROBADOS)")
    End Sub

    Private Sub BtnDifCompro_Click(sender As Object, e As EventArgs) Handles BtnDifCompro.Click
        MsgBox("DifCompro = GASTOS_VIAJE - GASTOS_COMPROBADOS")
    End Sub
    Private Sub BtnSubTotal_Click(sender As Object, e As EventArgs) Handles BtnSubTotal.Click
        MsgBox("Si DIF_COMPROBACION > 0 " & vbNewLine & "
Then " & vbNewLine & "
                Subtotal  = PERCEP_X_VIAJE+OTRAS_PERCEP-DEDUCCIONES- DIF_COMPROBACION " & vbNewLine & "
Else " & vbNewLine & "
                Subtotal = PERCEP_X_VIAJE+OTRAS_PERCEP-DEDUCCIONES-MONTO_RESETEO")
    End Sub
    Private Sub BarReseteo_Click(sender As Object, e As EventArgs) Handles BarReseteo.Click
        If TCVE_OPER.Text.Trim.Length > 0 Then

            Var2 = TCVE_OPER.Text
            FrmReseteoConsulta.ShowDialog()
        Else
            If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
                Var2 = ""
                FrmReseteoConsulta.ShowDialog()
            Else
                MsgBox("Por favor seleccione un operador")
            End If

        End If
    End Sub
    Private Sub TBOTONMAGICO_PA_GotFocus(sender As Object, e As EventArgs) Handles TBOTONMAGICO_PA.GotFocus
        Try
            FgPA.Select()
            Dim c_ As Integer
            c_ = FgPA.Col
            If Not IsNothing(_myEditorPa) Then
                _myEditorPa.StartEditing(FgPA.Row, c_)
            End If
        Catch ex As Exception
            BITACORA_LIQ("2200. " & ex.Message & vbNewLine & ex.StackTrace)
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
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorLiq
    'FgGC
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim ENTRA_FGG As Boolean = True
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    Dim c1Editor As Boolean = False
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid)
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
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim Sigue As Boolean

        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        If col = 2 And keyRec = 9 Then
            MyBase.Visible = True
            _owner.Select()
            _owner.StartEditing()
            Return
        End If
        If col = 2 And keyRec = 99 Then
            _owner.Select(1, 2)
            _owner.Row = 1
            _owner.Col = 2
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 1
            Return
        End If
        Sigue = True
        If _owner(row, 19).ToString.Trim.Length > 0 Then
            Return
        End If

        If _owner.Col = 2 Or _owner.Col = 3 Or _owner.Col = 6 Or _owner.Col = 10 Or _owner.Col = 14 Then
            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)

            rc.Width -= 1
            rc.Height -= 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control

            MyBase.Text = ""
            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf _owner(row, col) IsNot Nothing Then
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
            If col = 10 Then
                FrmLiquidacionesAE.CALCULAR_IMPORTES()
            End If
        Catch ex As Exception
            BITACORA_LIQ("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Public Sub FinishEditing()
        Try
            _owner.FinishEditing()
            FrmLiquidacionesAE.CALCULAR_IMPORTES()
        Catch ex As Exception
            BITACORA_LIQ("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 2 Or col = 3 Or col = 6 Then
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
        Dim MyTextBox As String

        'GASTO COMPROBADOS FGG
        'AQUI ESTA EL ERROR DONDE SE BRINCA  LA CLAVE DEL CLIENTE
        Try
            If _col = 99 Then
                _owner.Col = 2
                FrmLiquidacionesAE.TBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        Catch ex As Exception
            BITACORA_LIQ("2520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            'aqui esta el error
            Try
                If _col = 2 Then
                    If c1Editor Then
                        Return
                    End If

                End If
            Catch ex As Exception
                BITACORA_LIQ("2540. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If _col = 3 Then
                    Try
                        If Not IsNothing(_owner(_row, _col)) Then
                            If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                If MyBase.Text.Trim.Length = 0 Then
                                    c_ = 3
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                Else
                                End If
                            End If
                        End If
                        LLENAR_GRID_ARTICULO(MyBase.Text)
                    Catch ex As Exception
                        BITACORA_LIQ("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                BITACORA_LIQ("2580. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If _col = 6 And ENTRA_FGG Then 'PROVEEDOR
                    ENTRA_FGG = False
                    Try
                        If Not IsNothing(_owner(_row, 6)) Then
                            If MyBase.Text.Trim.Length = 0 Then
                                '            IEPS                    IVA
                                If _owner(_row, 15) > 0 Or _owner(_row, 16) > 0 Then

                                    c_ = 6
                                    FrmLiquidacionesAE.LtOper.Text = DateTime.Now
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    '_owner.Select()
                                    _owner.Select(_owner.Row, 3)
                                    '_owner.StartEditing()
                                    MsgBox("Es articulo lleva IVA por favor capture el proveedor")
                                    'FrmLiquidacionesAE.tBotonMagico.Focus()
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRA_FGG = True
                End If
            Catch ex As Exception
                BITACORA_LIQ("2580. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'procesamiento base
            MyBase.OnLeave(e)
            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
                Try
                    If _col = 10 Then
                        Try
                            MyTextBox = MyBase.Text
                            If MyBase.Text.Trim.Length > 0 And IsNumeric(MyBase.Text) Then
                                FrmLiquidacionesAE.CALCULAR_IMPORTES()
                            Else
                                Return
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("2600. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2600. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Return
            End If
            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False


        Catch ex As Exception
            BITACORA_LIQ("4150. " & ex.Message & vbNewLine & ex.StackTrace)
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
                _owner.Col = 2
                FrmLiquidacionesAE.TBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
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
                'Dim keypress As System.Windows.Forms.KeyPressEventArgs
                'OnKeyDown(e)
            Case Keys.F2
                If _col = 3 Then 'articulo
                    Try
                        Var2 = "InveLiq" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 3) = Var4
                            _owner(_row, 5) = Var5

                            LLENAR_GRID_ARTICULO(Var4)

                            _owner.Col = 6
                        End If
                        Return
                    Catch Ex As Exception
                        BITACORA_LIQ("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 6 Then 'proveedor
                    Try
                        Var2 = "Prov" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 6) = Var4
                            _owner(_row, 8) = Var5
                            _owner.Col = 10
                        End If
                        Return
                    Catch Ex As Exception
                        BITACORA_LIQ("4240. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4240. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub
    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        Try
            If col = 99 Then
                If Not FgEdit Then
                    _owner.Col = 2
                    FrmLiquidacionesAE.TBotonMagico.Focus()
                    _owner.Select()
                    _owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
            End If

            If col = 2 And key = Keys.Left Then
                c_ = 2
                FrmLiquidacionesAE.TBotonMagico.Focus()
                'Return
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
                    Return
                End If
            End If
            Select Case key
                Case Keys.Tab, Keys.Enter

                Case Keys.Up
                    If _owner.Row = 1 Then
                        c_ = _owner.Col
                        FrmLiquidacionesAE.TBotonMagico.Focus()
                        Return
                    End If
                    If IsNothing(_owner(_row, 2)) Then
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
                    End If

                    If _owner(_row, 2).ToString.Length = 0 Then
                        _owner.RemoveItem(_owner.Row)
                        row = FgRowVis()
                    End If

                    If row > 1 Then
                        row -= 1
                        MyBase.Visible = False
                        _owner.Select()
                        _owner.Select(row, col)
                        _owner.StartEditing()
                        Return
                    Else
                        _owner.Select()
                        _owner.Select(row, col)
                        _owner.StartEditing()
                        c_ = _owner.Col
                        FrmLiquidacionesAE.TBotonMagico.Focus()
                    End If
                Case Keys.Down
                    If FgRowVis() = row Then
                        Select Case col
                            Case 2
                                If IsNothing(_owner(_row, 2)) Then
                                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                                        c_ = 2
                                        FrmLiquidacionesAE.TBotonMagico.Focus()
                                    End If
                                Else
                                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                                        c_ = 2
                                        FrmLiquidacionesAE.TBotonMagico.Focus()
                                    Else

                                        '                           1            2              3           4          5             6           7     
                                        '                       Documento	Referencia	    Articulo      button	descripcion	     prov        button
                                        _owner.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       "" & vbTab & Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0")
                                        '              8            9            10           11           12           13           14 	      15		    16	          17        18            19
                                        '	       	  nombre        fecha	     subtotal	  iva	       ieps	        total	     obser	      IEPS	        IVA	          NUM_PAR   CVE_OBS     UUID
                                        _owner.Select(_owner.Rows.Count - 1, 2)
                                        c_ = 2
                                        FrmLiquidacionesAE.TBotonMagico.Focus()
                                    End If
                                End If
                            Case Else
                                c_ = _owner.Col
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                        End Select
                        Return
                    Else
                        Try
                            If col = 2 Then
                                If row + 1 <= _owner.Rows.Count - 1 Then
                                    For x = row + 1 To _owner.Rows.Count - 1
                                        'row = row + 1
                                        If _owner.Rows(x).IsVisible Then
                                            row = x
                                            Exit For
                                        End If
                                    Next
                                End If
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                c_ = _owner.Col
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                            Else
                                c_ = _owner.Col
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Case Keys.PageUp
                    row -= 10
                Case Keys.PageUp
                    row += 10
                Case Keys.Left
                    '<<<<<<------   izquierda
                    If col > 1 Then
                        Select Case col
                            Case 2
                                c_ = 2
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                c_ = 2
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                Return
                                If row = 1 Then
                                    'row = _owner.Rows.Count - 1
                                Else
                                    'row = row - 1
                                End If
                                col = 2
                            Case 3
                                col = 2
                            Case 6
                                col = 3
                            Case 9
                                col = 6
                            Case 10
                                col = 9
                            Case <= 14
                                col = 10
                        End Select
                        '<<<<<<------   izquierda
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
                    'FLECHA PARA ------->
                    If col <= 14 Then
                        Select Case col
                            Case 2
                                'CORREGIR AQUI
                                If IsNothing(_owner(_row, 2)) Then
                                    c_ = 2
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    '_owner.Select()
                                    '_owner.Select(row, col)
                                    '_owner.StartEditing()
                                    Return
                                End If
                                If MyBase.Text.ToString.Length = 0 Then
                                    c_ = 2
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                    c_ = 2
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    Return
                                End If
                                col = 3
                            'Return
                            'Case 2
                            'col = 3
                            Case 3
                                'CORREGIR AQUI
                                If IsNothing(_owner(_row, 2)) Then
                                    c_ = 3
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    '_owner.Select()
                                    '_owner.Select(row, col)
                                    '_owner.StartEditing()
                                    Return
                                End If
                                If MyBase.Text.ToString.Length = 0 Then
                                    c_ = 3
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                    c_ = 3
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    Return
                                End If
                                col = 6
                            Case 6
                                col = 9
                            Case 9
                                col = 10
                            Case 10
                                col = 14
                            Case 14

                                If MyBase.Text.ToString.Length = 0 Then
                                    c_ = 14
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                    c_ = 14
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    Return
                                End If
                                Try
                                    If Not IsNothing(_owner(_owner.Rows.Count - 1, 2)) Then
                                        If _owner(_owner.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                                            '                           1            2              3           4          5             6           7              8                   
                                            '                       Documento	Referencia	    Articulo      button	descripcion	     prov        button       nombre
                                            _owner.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                    Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "")
                                            '               9                            10           11           12           13           14 	      15		    16	          17            18           19
                                            '	            fecha	                   subtotal	      iva	       ieps	        total	     obser	      IEPS	        IVA	          NUM_PAR       CVE_OBS      UUID
                                        End If
                                    End If
                                    c1Editor = False
                                    row = _owner.Rows.Count - 1
                                    col = 1
                                Catch ex As Exception
                                    BITACORA_LIQ("4280. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("4280. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                        End Select
                    Else
                        col = 2
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

            'aplicar nueva selección        7SS
            Try
                _owner.Select(_row, col)
            Catch ex As Exception
                BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function FgRowVis() As Integer
        Dim v As Integer = 0
        Try
            For k = 1 To _owner.Rows.Count - 1
                If _owner.Rows(k).IsVisible Then
                    v += 1
                End If
            Next
            Return v
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        If col = 99 Then
            _owner.Col = 2
            FrmLiquidacionesAE.TBotonMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 2
                            If MyBase.Text.Trim.Length = 0 Then
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                Return
                            End If
                        Case 3 'ARTICULO
                            Dim Descr As String

                            If MyBase.Text.Trim.Length = 0 Then
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Var5 = Var46

                            Descr = BUSCA_CAT("InveLiq", MyBase.Text)

                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                MyBase.Text = ""
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner(_row, 5) = ""
                                _owner.StartEditing()
                                MsgBox("Articulo inexistente")
                                Return
                            Else
                                '_owner(_row, 1) = MyBase.Text
                                _owner(_row, 5) = Descr

                                LLENAR_GRID_ARTICULO(MyBase.Text)

                                _owner.Col = 6
                                Return
                            End If
                        Case 6 'PROVEEDOR
                            Dim Descr As String

                            If MyBase.Text.Trim.Length > 0 Then
                                MyBase.Text = Space(10 - MyBase.Text.Trim.Length) & MyBase.Text.Trim

                                Descr = BUSCA_CAT("Prov", MyBase.Text)
                                If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                    MsgBox("Proveedor inexistente")
                                    FrmLiquidacionesAE.TBotonMagico.Focus()
                                    _owner.Select(_row, _col)
                                    _owner(_row, _col) = ""
                                    _owner.StartEditing()
                                    Return
                                Else
                                    _owner(_row, 6) = MyBase.Text
                                    _owner(_row, 8) = Descr
                                    _owner.Col = 9
                                    Return
                                End If
                            Else
                                _owner.Col = 9
                            End If
                        Case 10
                            '_owner.Col = 14
                        Case 14
                            If MyBase.Text.Trim.Length = 0 Then
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                _owner.Select()
                                _owner.Select(_row, _col)
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBotonMagico.Focus()
                                Return
                            Else
                                Try
                                    If Not IsNothing(_owner(_owner.Rows.Count - 1, 2)) Then
                                        If _owner(_owner.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                                            '                           1            2              3           4          5             6           7              8                   
                                            '                       Documento	Referencia	    Articulo      button	descripcion	     prov        button       nombre
                                            _owner.AddItem("" & vbTab & GET_MAX_TRY("GCLIQ_GASTOS_COMPROBADOS", "CVE_DOC") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                           "" & vbTab & "" & vbTab & Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab &
                                                           "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "")
                                            '               9                            10           11           12           13           14 	      15		    16	          17            18           19
                                            '	            fecha	                   subtotal	      iva	       ieps	        total	     obser	      IEPS	        IVA	          NUM_PAR       CVE_OBS      UUID
                                        End If
                                    End If
                                    c1Editor = False
                                    row = _owner.Rows.Count - 1
                                    col = 1
                                Catch ex As Exception
                                    BITACORA_LIQ("4300. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("4300. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                            'Case 14
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 1
                            _owner.Select(row, col + 1)
                            'col = 1
                        Case 3, 6
                            _owner.Select(row, col + 2)
                        Case 2, 8, 9
                            _owner.Select(row, col + 1)
                        Case 10
                            _owner.Col = 14
                            _owner.Select(row, col + 4)
                    End Select
                    _owner.StartEditing()
                    'Return
                Case Else
                    If _col = 4 Or _col = 7 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 10 Then
                        'e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            BITACORA_LIQ("4320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single, PRECIO As Decimal = 0

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 3),0) AS P3, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 4),0) AS P4, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 5),0) AS P5, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 6),0) AS P6, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 7),0) AS P7, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 8),0) AS P8, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 9),0) AS P9, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 10),0) AS P10, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 11),0) AS P11, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 12),0) AS P12, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 13),0) AS P13, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 14),0) AS P14 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                _owner(_row, 3) = dr("CVE_ART")
                _owner(_row, 5) = dr("DESCR")
                _owner(_row, 15) = dr("IMPUESTO1") 'IEPS
                _owner(_row, 16) = dr("IMPUESTO4") 'IVA

                FrmLiquidacionesAE.LtUnidad.Text = _owner(_row, 16)

                FrmLiquidacionesAE.CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            BITACORA_LIQ("5000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub _owner_MouseLeave(sender As Object, e As EventArgs) Handles _owner.MouseLeave
        FrmLiquidacionesAE.Lm4.Text = "True"
        c1Editor = True
    End Sub

    Private Sub _owner_MouseEnter(sender As Object, e As EventArgs) Handles _owner.MouseEnter
        FrmLiquidacionesAE.Lm4.Text = "False"
        c1Editor = False
    End Sub

    Private Sub MyEditorLiq_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        FrmLiquidacionesAE.Lm4.Text = "False"
        c1Editor = False
    End Sub


End Class



'███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
'███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
'███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
'███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
'███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
Public Class MyEditorPA
    'FgPA
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    Dim c1Editor As Boolean = False
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
    End Sub
    'comenzar a editar: mover a la celda y activar
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim Sigue As Boolean
        Try
            'save coordinates of cell being edited
            'guardar las coordenadas de la celda que se está editando
            If col = 2 And keyRec = 9 Then
                MyBase.Visible = True
                _owner.Select()
                _owner.StartEditing()
                Return
            End If
            If col = 2 And keyRec = 99 Then
                _owner.Select(1, 2)
                _owner.Row = 1
                _owner.Col = 2
                MoveCursor(Keys.Enter)
                _owner.Rows.Count = 1
                Return
            End If
            Sigue = True
            If col = 99 Then
                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
            If Not IsNothing(_owner(row, 11)) Then
                If _owner(row, 11).ToString.Trim.Length > 0 Then
                    Return
                End If
            End If
        Catch ex As Exception
            BITACORA_LIQ("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If _owner.Col = 2 Or _owner.Col = 6 Or _owner.Col = 8 Then
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

                MyBase.Text = ""
                If _pendingKey > " " Then
                    MyBase.Text = _pendingKey.ToString()
                ElseIf _owner(row, col) IsNot Nothing Then
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
        Catch ex As Exception
            BITACORA_LIQ("5000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
            If col = 6 Then
                FrmLiquidacionesAE.CALCULAR_IMPORTES()
            End If
        Catch ex As Exception
            BITACORA_LIQ("2500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 2 Or col = 3 Or col = 6 Or col = 8 Then
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
        Dim MyTextBox As String

        'AQUI ESTA EL ERROR DONDE SE BRINCA  LA CLAVE DEL CLIENTE
        Try
            If _col = 99 Then
                _owner.Col = 2
                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        Catch ex As Exception
            BITACORA_LIQ("2520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            'aqui esta el error
            Try
                If _col = 2 Then
                    If c1Editor Then
                        Return
                    End If
                End If
            Catch ex As Exception
                BITACORA_LIQ("2540. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If _col = 3 Then 'CLAVE ARTICULO
                    Try
                        If Not IsNothing(_owner(_row, _col)) Then
                            If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                If MyBase.Text.Trim.Length = 0 Then
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                Else
                                End If
                            End If
                        End If
                        LLENAR_GRID_ARTICULO(MyBase.Text)
                    Catch ex As Exception
                        BITACORA_LIQ("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2560. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                BITACORA_LIQ("2580. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If _col = 99 Then
                    Try
                        If Not IsNothing(_owner(_row, _col)) Then
                            If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                If IsNumeric(_owner(_row, 9)) Then
                                    If IsNumeric(MyBase.Text) Then

                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        BITACORA_LIQ("2640. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2640. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                BITACORA_LIQ("2660. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            'If _col = 7 Then
            'Return
            'End If

            'procesamiento base
            MyBase.OnLeave(e)
            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
                Try
                    If _col = 6 Then 'FACTOR
                        Try
                            MyTextBox = MyBase.Text
                            If MyBase.Text.Trim.Length > 0 And IsNumeric(MyBase.Text) Then
                                FrmLiquidacionesAE.CALCULAR_IMPORTES()
                            Else
                                Return
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("2600. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2600. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    BITACORA_LIQ("2620. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Return
            End If
            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False


        Catch ex As Exception
            BITACORA_LIQ("4150. " & ex.Message & vbNewLine & ex.StackTrace)
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
                _owner.Col = 2
                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
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
                'Dim keypress As System.Windows.Forms.KeyPressEventArgs
                'OnKeyDown(e)
            Case Keys.F2
                If _col = 2 Then 'articulo
                    Try
                        Var2 = "InveLiq" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 2) = Var4
                            _owner(_row, 4) = Var5
                            _owner.Col = 6
                        End If
                        Return
                    Catch Ex As Exception
                        BITACORA_LIQ("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4200. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub
    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        Try
            If col = 99 Then
                If Not FgEdit Then
                    _owner.Col = 2
                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                    _owner.Select()
                    _owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
            End If

            If col = 2 And key = Keys.Left Then
                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                'Return
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
                    Return
                End If
            End If
            Select Case key
                Case Keys.Tab, Keys.Enter

                Case Keys.Up
                    If _owner.Row = 1 Then
                        FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                        Return
                    End If
                    If IsNothing(_owner(_row, 2)) Then
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
                    End If

                    If _owner(_row, 2).ToString.Length = 0 Then
                        _owner.RemoveItem(_owner.Row)
                        row = FgRowVis()
                    End If

                    If row > 1 Then
                        row -= 1
                        MyBase.Visible = False
                        _owner.Select()
                        _owner.Select(row, col)
                        _owner.StartEditing()
                        Return
                    Else
                        _owner.Select()
                        _owner.Select(row, col)
                        _owner.StartEditing()
                        FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                    End If
                Case Keys.Down
                    If FgRowVis() = row Then
                        Select Case col
                            Case 2
                                If IsNothing(_owner(_row, 2)) Then
                                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                                        FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    End If
                                Else
                                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                                        FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    Else

                                        _owner.Select(_owner.Rows.Count - 1, 2)
                                        FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    End If
                                End If
                            Case Else
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                        End Select
                        Return
                    Else
                        Try
                            If col = 2 Then
                                If row + 1 <= _owner.Rows.Count - 1 Then
                                    For x = row + 1 To _owner.Rows.Count - 1
                                        'row = row + 1
                                        If _owner.Rows(x).IsVisible Then
                                            row = x
                                            Exit For
                                        End If
                                    Next
                                End If
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                            Else
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                            End If
                        Catch ex As Exception
                            BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Case Keys.PageUp
                    row -= 10
                Case Keys.PageUp
                    row += 10
                Case Keys.Left
                    '<<<<<<------   izquierda
                    If col > 1 Then
                        Select Case col
                            Case 2
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                Return
                                If row = 1 Then
                                    'row = _owner.Rows.Count - 1
                                Else
                                    'row = row - 1
                                End If
                                col = 6
                            Case 6
                                col = 8
                            Case <= 8
                                col = 8
                        End Select
                        '<<<<<<------   izquierda
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
                    'FLECHA PARA ------->
                    If col <= 14 Then
                        Select Case col
                            Case 2
                                'CORREGIR AQUI
                                If IsNothing(_owner(_row, 2)) Then
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    '_owner.Select()
                                    '_owner.Select(row, col)
                                    '_owner.StartEditing()
                                    Return
                                End If
                                If MyBase.Text.ToString.Length = 0 Then
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    Return
                                End If
                                col = 6
                            Case 8

                                If MyBase.Text.ToString.Length = 0 Then
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    _owner.Select()
                                    _owner.Select(row, col)
                                    _owner.StartEditing()
                                    FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    Return
                                End If
                                Try
                                    If Not IsNothing(_owner(_owner.Rows.Count - 1, 2)) Then
                                        If _owner(_owner.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                                            '                                                     1                          2           3            4          
                                            '                                                 Documento	                 Articulo      button	 descripcion	 
                                            _owner.AddItem("" & vbTab & GET_MAX("GCLIQ_PENSION_ALI", "CVE_FOLIO") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                                            '                             5                      6            7            8            9           10            11
                                            '	       	                fecha	              factor	    total	     OBSER	      NUM_PAR     CVE_OBS       UUID
                                        End If
                                    End If
                                    c1Editor = False
                                    row = _owner.Rows.Count - 1
                                    col = 1
                                Catch ex As Exception
                                    BITACORA_LIQ("4280. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("4280. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                        End Select
                    Else
                        col = 2
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

            'aplicar nueva selección        7SS
            Try
                _owner.Select(_row, col)
            Catch ex As Exception
                BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORA_LIQ("4260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function FgRowVis() As Integer
        Dim v As Integer = 0
        Try
            For k = 1 To _owner.Rows.Count - 1
                If _owner.Rows(k).IsVisible Then
                    v += 1
                End If
            Next
            Return v
        Catch ex As Exception
            Return 1
        End Try
    End Function
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        If col = 99 Then
            _owner.Col = 2
            FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 2
                            Dim Descr As String

                            If MyBase.Text.Trim.Length = 0 Then
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Var5 = Var46

                            Descr = BUSCA_CAT("InveLiq", MyBase.Text)

                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                MyBase.Text = ""
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner(_row, 4) = ""
                                _owner.StartEditing()
                                MsgBox("Articulo inexistente")
                                Return
                            Else
                                '_owner(_row, 1) = MyBase.Text
                                _owner(_row, 4) = Descr
                                _owner.Col = 6
                                Return
                            End If
                        Case 8
                            If MyBase.Text.Trim.Length = 0 Then
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                _owner.Select()
                                _owner.Select(_row, _col)
                                _owner.StartEditing()
                                FrmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                Return
                            Else
                                Try
                                    If Not IsNothing(_owner(_owner.Rows.Count - 1, 2)) Then
                                        If _owner(_owner.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                                            '                                                     1                          2           3            4          
                                            '                                                 Documento	                 Articulo      button	 descripcion	 
                                            _owner.AddItem(_owner.Rows.Count & vbTab & GET_MAX("GCLIQ_PENSION_ALI", "CVE_FOLIO") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                                            '                             5                      6            7            8            9           10            11
                                            '	       	                fecha	              factor	    total	     OBSER	      NUM_PAR     CVE_OBS       UUID
                                        End If
                                    End If
                                    c1Editor = False

                                    row = _owner.Rows.Count - 1
                                    '_owner.Row = row
                                    '_owner.Col = 2
                                    'frmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    '_owner.Select()
                                    _owner.Select(row, 2)
                                    _owner.StartEditing()
                                    'frmLiquidacionesAE.TBOTONMAGICO_PA.Focus()
                                    Return

                                Catch ex As Exception
                                    BITACORA_LIQ("4300. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("4300. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                            'Case 14
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 1
                            '_owner.Select(row, col + 1)
                        Case 2
                            _owner.Select(row, col + 4)
                        Case 6
                            _owner.Select(row, col + 2)
                    End Select
                    _owner.StartEditing()
                    'Return
                Case Else
                    If _col = 3 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 1 Then
                        'e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            BITACORA_LIQ("4320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single, PRECIO As Decimal = 0

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 3),0) AS P3, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 4),0) AS P4, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 5),0) AS P5, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 6),0) AS P6, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 7),0) AS P7, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 8),0) AS P8, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 9),0) AS P9, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 10),0) AS P10, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 11),0) AS P11, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 12),0) AS P12, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 13),0) AS P13, " &
                "ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 14),0) AS P14 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                '                                                 Documento	               Articulo      button	   descripcion	 
                'FgPA.AddItem("" & vbTab & GET_MAX("GCLIQ_PENSION_ALI", "CVE_FOLIO") & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                'Date.Now.ToShortDateString & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                '                             5                    6            7            8            9           10            11
                '	       	                fecha	            factor	     total	      OBSER	       NUM_PAR     CVE_OBS       UUID
                _owner(_row, 2) = dr("CVE_ART")
                _owner(_row, 4) = dr("DESCR")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORA_LIQ("5000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub _owner_MouseLeave(sender As Object, e As EventArgs) Handles _owner.MouseLeave
        FrmLiquidacionesAE.Lm4.Text = "True"
        c1Editor = True
    End Sub
    Private Sub _owner_MouseEnter(sender As Object, e As EventArgs) Handles _owner.MouseEnter
        FrmLiquidacionesAE.Lm4.Text = "False"
        c1Editor = False
    End Sub
    Private Sub MyEditorLiq_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        FrmLiquidacionesAE.Lm4.Text = "False"
        c1Editor = False
    End Sub
End Class


