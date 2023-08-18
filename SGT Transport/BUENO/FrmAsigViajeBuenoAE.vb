Imports Spire.Xls
Imports System.IO
Imports System.ComponentModel
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports System.Xml
Imports C1.Win.C1Input
Imports C1.Win.C1Command
Public Class FrmAsigViajeBuenoAE

    Private PasaXLS As Boolean = True
    Private ViajeNew As Boolean
    Private SSUBT As Decimal = 0
    Private vIMPU1 As Decimal
    Private vIMPU2 As Decimal
    Private vIMPU3 As Decimal
    Private vIMPU4 As Decimal
    Private SERIE_A As String
    Private FOLIO_A As Long
    Private SERIE_AG As String
    Private FOLIO_AG As Long
    Private IsMatPeligroso As Boolean = False
    Private SeCopio As String = "N"
    Private SOLOCONSULTAR As Boolean = False

    Public Mofifica_Remitente_destinatario As Boolean

    Private SeDesplega As Boolean = False

    Private SERIE_AV As String
    Private FOLIO_AV As Long
    Private TIPO_FACTURACION As Integer = 1
    Private MONTO_X_VIAJE As Decimal = 0
    Private MONTO_X_TON As Decimal = 0
    Private FACTOR_IEPS As Decimal
    Private ENTRA As Boolean
    Private ENTRAM As Boolean
    Private ENTRAT As Boolean = True
    Private ENTRAA As Boolean = True
    Private ENTRAG As Boolean = True

    Private VIAJES_A_COPIAR As Integer

    Private DOC_NEW As Boolean
    Private VALOR_DECLA_DESDE_SAE As Integer = 0
    Private TAR_X_VIA_FULL As Decimal = 0
    Private TAR_X_VIA_SENC As Decimal = 0
    Private TAR_X_TON_FULL As Decimal = 0
    Private ACEPTA_CALCULO As Boolean = False
    Private STATUS_VIA As Integer, STATUS_CANCELADO As Boolean = False
    Private NO_MODIF_FG As Boolean = False
    Private NO_MODIF_FG_CARGA As Boolean = False
    Private ENTRA_CALCULOS As Boolean = False
    Private CVE_PRODSERV As String
    Private CVE_UNIDAD As String
    Private FOLIO_INICIAL As Long
    Private FACTURA_UNO_O_MULT As String
    Private CADENAC As String = ""
    Private WithEvents MenuCV As New ContextMenuStrip
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmAsigViajeBuenoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try

            BtnTabRutaViajes.FlatStyle = FlatStyle.Flat
            BtnTabRutaViajes.FlatAppearance.BorderSize = 0
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

            BtnAgregar.FlatStyle = FlatStyle.Flat
            BtnAgregar.FlatAppearance.BorderSize = 0
            BtnEliminar.FlatStyle = FlatStyle.Flat
            BtnEliminar.FlatAppearance.BorderSize = 0

            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0
            BtnMoneda.FlatStyle = FlatStyle.Flat
            BtnMoneda.FlatAppearance.BorderSize = 0
            BtnEsquema.FlatStyle = FlatStyle.Flat
            BtnEsquema.FlatAppearance.BorderSize = 0
            BtnPlazaFG.FlatStyle = FlatStyle.Flat
            BtnPlazaFG.FlatAppearance.BorderSize = 0
            BtnProdServ1.FlatStyle = FlatStyle.Flat
            BtnProdServ1.FlatAppearance.BorderSize = 0
            BtnProdServ2.FlatStyle = FlatStyle.Flat
            BtnProdServ2.FlatAppearance.BorderSize = 0
            BtnProdServ3.FlatStyle = FlatStyle.Flat
            BtnProdServ3.FlatAppearance.BorderSize = 0
            BtnProdServ4.FlatStyle = FlatStyle.Flat
            BtnProdServ4.FlatAppearance.BorderSize = 0
            BtnProdServ5.FlatStyle = FlatStyle.Flat
            BtnProdServ5.FlatAppearance.BorderSize = 0
            BtnProdServ6.FlatStyle = FlatStyle.Flat
            BtnProdServ6.FlatAppearance.BorderSize = 0
            BtnCveUni1.FlatStyle = FlatStyle.Flat
            BtnCveUni1.FlatAppearance.BorderSize = 0
            BtnCveUni2.FlatStyle = FlatStyle.Flat
            BtnCveUni2.FlatAppearance.BorderSize = 0
            BtnCveUni3.FlatStyle = FlatStyle.Flat
            BtnCveUni3.FlatAppearance.BorderSize = 0
            BtnCveUni4.FlatStyle = FlatStyle.Flat
            BtnCveUni4.FlatAppearance.BorderSize = 0
            BtnCveUni5.FlatStyle = FlatStyle.Flat
            BtnCveUni5.FlatAppearance.BorderSize = 0
            BtnCveUni6.FlatStyle = FlatStyle.Flat
            BtnCveUni6.FlatAppearance.BorderSize = 0
            BtnCveProd.FlatStyle = FlatStyle.Flat
            BtnCveProd.FlatAppearance.BorderSize = 0
            BtnCveUnidad.FlatStyle = FlatStyle.Flat
            BtnCveUnidad.FlatAppearance.BorderSize = 0
            BtnPagoSAT.FlatStyle = FlatStyle.Flat
            BtnPagoSAT.FlatAppearance.BorderSize = 0
            BarMetodoPago.FlatStyle = FlatStyle.Flat
            BarMetodoPago.FlatAppearance.BorderSize = 0
            BtnUsoCFDI.FlatStyle = FlatStyle.Flat
            BtnUsoCFDI.FlatAppearance.BorderSize = 0

            BtnSelViaje.FlatStyle = FlatStyle.Flat
            BtnSelViaje.FlatAppearance.BorderSize = 0

            TIPO_FACTURACION = ESCENARIO

            Dim SPOR1 As Decimal
            Select Case ESCENARIO
                Case 0
                    Pag7.TabVisible = True 'IMPORTE    
                    Pag0.TabVisible = False 'PRINCIPAL FACTURAR VARIOS VIAJES
                    Pag6.TabVisible = True 'MARCANCIAS
                    Pag4.TabVisible = True 'CARGAS
                    'Pag2.TabVisible = True 'OBSERVACIONES VIAJE
                    'Pag5.TabVisible = True 'VIAJES
                    Pag8.TabVisible = True 'CAMPOS ADICIONALES

                    GpoRem5.Visible = False
                    TFLETEA.Visible = False
                    TABONO_NETO.Visible = False
                    Label89.Visible = False
                    Label90.Visible = False


                Case 1
                    Pag0.TabVisible = False

                    Label89.Visible = False
                    TABONO_NETO.Visible = False
                    Label90.Visible = False
                    TFLETEA.Visible = False
                    GpoRem5.Visible = False

                Case 2
                    Pag0.TabVisible = True
                    SplitM1P2.Visible = False
                    SPOR1 = (FgViajes.Width / Me.Width) * 100
                    SplitM1P1.SizeRatio = SPOR1 + 1
                    SplitM1P2.SizeRatio = 0

                    SplitM1P3.SizeRatio = 100 - SplitM1P1.SizeRatio - SplitM1P2.SizeRatio
                    Pag7.TabVisible = False

                    Label89.Visible = False
                    TABONO_NETO.Visible = False
                    Label90.Visible = False
                    TFLETEA.Visible = False
                    GpoRem5.Visible = False
                Case 3
                    Pag0.TabVisible = False
                    SplitM1P1.Visible = False
                    SplitM1P1.SizeRatio = 0
                    SplitM1P2.SizeRatio = SPOR1 + 1
                    SplitM1P3.SizeRatio = 100 - SplitM1P1.SizeRatio - SplitM1P2.SizeRatio

                    'If PASS_GRUPOCE = "BUS" Then
                    GroupBox1.Visible = True
                    'Else
                    'GroupBox1.Visible = False
                    'End If

                    Label89.Visible = True
                    TABONO_NETO.Visible = True
                    Label90.Visible = True
                    TFLETEA.Visible = True
                    GpoRem5.Visible = True
            End Select

            SPOR1 = ((BtnBorrarMercancias.Top + BtnBorrarMercancias.Height) / Me.Height) * 100
            SplitM3P1.SizeRatio = SPOR1 + 10
            SplitM3P2.SizeRatio = 100 - SplitM3P1.SizeRatio

            SPOR1 = ((BtnCopiarCamposAdic.Top + BtnCopiarCamposAdic.Height) / Me.Height) * 100
            SplitM2P1.SizeRatio = SPOR1 + 3
            SplitM2P2.SizeRatio = 100 - SplitM2P1.SizeRatio
            SplitM2P2.SizeRatio = 100 - SplitM2P1.SizeRatio

            SplitMG.Dock = DockStyle.Fill
            TAB1.Dock = DockStyle.Fill

            Fg.DrawMode = DrawModeEnum.OwnerDraw
        Catch ex As Exception
        End Try

        ENTRA_CALCULOS = True
        ENTRAA = True
        SplitM1P2.Visible = False
        If Var49 = 55 Then
            SOLOCONSULTAR = True
        End If

        Try
            SQL = "SELECT CLAVE, DESCR FROM GCCARGAS WHERE STATUS = 'A' ORDER BY TRY_PARSE(CLAVE AS INT)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        'CADENAC += dr.ReadNullAsEmptyString("CLAVE") & " " & dr.ReadNullAsEmptyString("DESCR") & "|"
                        CboCarga.Items.Add(dr.ReadNullAsEmptyString("DESCR"))
                    End While
                End Using
            End Using
            If CADENAC.Length > 1 Then
                CADENAC = CADENAC.Substring(0, CADENAC.Length)
            End If

        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try



    End Sub
    Sub CARGAR_DATOS1()
        'TFOLIOFG.Value = 0

        TDIAS_CRED.Value = 0 : TVOLUMEN_PESO.Value = 0 : TFLETE.Value = 0 : TSUB_TOTAL.Value = 0 : TRET.Value = 0 : TIVA.Value = 0
        TNETO.Value = 0 : TMONTO1.Value = 0 : TMONTO2.Value = 0 : TMONTO3.Value = 0 : TMONTO4.Value = 0 : TMONTO5.Value = 0 : TMONTO6.Value = 0
        TRET1.Value = 0 : TRET2.Value = 0 : TRET3.Value = 0 : TRET4.Value = 0 : TRET5.Value = 0 : TRET6.Value = 0 : TCVE_PRODSERV.Value = "" : TCVE_PRODSERV1.Value = ""
        TCVE_PRODSERV2.Value = "" : TCVE_PRODSERV3.Value = "" : TCVE_PRODSERV4.Value = "" : TCVE_PRODSERV5.Value = "" : TCVE_PRODSERV6.Value = ""
        TCVE_UNIDAD.Value = "" : TCVE_UNIDAD1.Value = "" : TCVE_UNIDAD2.Value = "" : TCVE_UNIDAD3.Value = "" : TCVE_UNIDAD4.Value = "" : TCVE_UNIDAD5.Value = ""
        TCVE_UNIDAD6.Value = "" : TABONO_NETO.Value = 0 : TFLETEA.Value = 0 : TSUBT_ABO3.Value = 0 : TIVA_ABO3.Value = 0 : TRET_ABO3.Value = 0 : TNETO_ABO3.Value = 0
        TKMS_VACIO.Value = 0 : TIVAC1.Value = 0 : TSUBT_O.Value = 0 : TIVA_O.Value = 0 : TRET_O.Value = 0 : TNETO_O.Value = 0 : TSUBT_O2.Value = 0 : TIVA_O2.Value = 0
        TRET_O2.Value = 0 : TNETO_O2.Value = 0 : TSALDO_SUBTOTAL.Value = 0 : TSALDO_IVA.Value = 0 : TSALDO_RET.Value = 0 : TSALDO_NETO.Value = 0
        TFOLIOFG.Value = 0

        TDIAS_CRED.ErrorInfo.ShowErrorMessage = False : TVOLUMEN_PESO.ErrorInfo.ShowErrorMessage = False : TFLETE.ErrorInfo.ShowErrorMessage = False : TSUB_TOTAL.ErrorInfo.ShowErrorMessage = False : TRET.ErrorInfo.ShowErrorMessage = False : TIVA.ErrorInfo.ShowErrorMessage = False
        TNETO.ErrorInfo.ShowErrorMessage = False : TMONTO1.ErrorInfo.ShowErrorMessage = False : TMONTO2.ErrorInfo.ShowErrorMessage = False : TMONTO3.ErrorInfo.ShowErrorMessage = False : TMONTO4.ErrorInfo.ShowErrorMessage = False : TMONTO5.ErrorInfo.ShowErrorMessage = False : TMONTO6.ErrorInfo.ShowErrorMessage = False
        TRET1.ErrorInfo.ShowErrorMessage = False : TRET2.ErrorInfo.ShowErrorMessage = False : TRET3.ErrorInfo.ShowErrorMessage = False : TRET4.ErrorInfo.ShowErrorMessage = False : TRET5.ErrorInfo.ShowErrorMessage = False : TRET6.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV1.ErrorInfo.ShowErrorMessage = False
        TCVE_PRODSERV2.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV3.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV4.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV5.ErrorInfo.ShowErrorMessage = False : TCVE_PRODSERV6.ErrorInfo.ShowErrorMessage = False
        TCVE_UNIDAD.ErrorInfo.ShowErrorMessage = False : TCVE_UNIDAD1.ErrorInfo.ShowErrorMessage = False : TCVE_UNIDAD2.ErrorInfo.ShowErrorMessage = False : TCVE_UNIDAD3.ErrorInfo.ShowErrorMessage = False : TCVE_UNIDAD4.ErrorInfo.ShowErrorMessage = False : TCVE_UNIDAD5.ErrorInfo.ShowErrorMessage = False
        TCVE_UNIDAD6.ErrorInfo.ShowErrorMessage = False : TABONO_NETO.ErrorInfo.ShowErrorMessage = False : TFLETEA.ErrorInfo.ShowErrorMessage = False : TSUBT_ABO3.ErrorInfo.ShowErrorMessage = False : TIVA_ABO3.ErrorInfo.ShowErrorMessage = False : TRET_ABO3.ErrorInfo.ShowErrorMessage = False : TNETO_ABO3.ErrorInfo.ShowErrorMessage = False
        TKMS_VACIO.ErrorInfo.ShowErrorMessage = False : TIVAC1.ErrorInfo.ShowErrorMessage = False : TSUBT_O.ErrorInfo.ShowErrorMessage = False : TIVA_O.ErrorInfo.ShowErrorMessage = False : TRET_O.ErrorInfo.ShowErrorMessage = False : TNETO_O.ErrorInfo.ShowErrorMessage = False : TSUBT_O2.ErrorInfo.ShowErrorMessage = False : TIVA_O2.ErrorInfo.ShowErrorMessage = False
        TRET_O2.ErrorInfo.ShowErrorMessage = False : TNETO_O2.ErrorInfo.ShowErrorMessage = False : TSALDO_SUBTOTAL.ErrorInfo.ShowErrorMessage = False : TSALDO_IVA.ErrorInfo.ShowErrorMessage = False : TSALDO_RET.ErrorInfo.ShowErrorMessage = False : TSALDO_NETO.ErrorInfo.ShowErrorMessage = False
        TFOLIOFG.ErrorInfo.ShowErrorMessage = False

        TFLETE.Tag = "0"
        TRET1.Tag = 0 : TRET2.Tag = 0 : TRET3.Tag = 0 : TRET4.Tag = 0 : TRET5.Tag = 0 : TRET6.Tag = 0
        TIVAC1.Tag = "0" : TIVAC2.Tag = "0" : TIVAC3.Tag = "0" : TIVAC4.Tag = "0" : TIVAC5.Tag = "0" : TIVAC6.Tag = "0"

        TKMS_VACIO.ErrorInfo.ShowErrorMessage = False

        TXT.BorderColor = Color.SteelBlue
        TXT.BackColor = Color.LightBlue
        TXTN.BorderColor = Color.SteelBlue
        TFOLIO_VIAJE.Value = ""

        SplitM1.FixedLineWidth = 0
        SplitM1.HeaderLineWidth = 0
        SplitM1.SplitterWidth = 0
        SplitM1.BorderWidth = 0

        SplitM2.FixedLineWidth = 0
        SplitM2.HeaderLineWidth = 0
        SplitM2.SplitterWidth = 0
        SplitM2.BorderWidth = 0

        FgA.Dock = DockStyle.Fill
        Fg.Dock = DockStyle.Fill
        FgViajes.Cols(0).Width = 2

        SplitM1.Dock = DockStyle.Fill

        SplitM4.FixedLineWidth = 0
        SplitM4.HeaderLineWidth = 0
        SplitM4.SplitterWidth = 0
        SplitM4.BorderWidth = 0
        SplitM3P1.BorderWidth = 0
        SplitM3.FixedLineWidth = 0
        SplitM3.HeaderLineWidth = 0
        SplitM3.SplitterWidth = 0

        SplitM2P1.BorderWidth = 0
        SplitM2.FixedLineWidth = 0
        SplitM2.HeaderLineWidth = 0
        SplitM2.SplitterWidth = 0

        SplitM3.Dock = DockStyle.Fill
        SplitM2.Dock = DockStyle.Fill

        LtCalle1.Tag = ""
        LtCalle2.Tag = ""
        LtNombre1.Tag = ""
        LtRFC.Tag = ""
        TCVE_TAB_VIAJE.Tag = ""
        TCVE_OPER.Tag = ""

        FgG.BeginUpdate()
        FgV.BeginUpdate()
        Fg.BeginUpdate()
        FgA.BeginUpdate()

        FgG.Redraw = False
        FgV.Redraw = False
        Fg.Redraw = False
        FgA.Redraw = False

        TTIPO_CAMBIO.Value = 0

        Try
            ENTRAA = False
            Select Case ESCENARIO
                Case 1, 0
                    Pag0.TabVisible = False
                Case 2
                    SplitM1P2.Visible = False
                Case 3
                    SplitM1P1.Visible = False
            End Select


            FACTURA_UNO_O_MULT = Var10

            If FACTURA_UNO_O_MULT = "VVM" Then
                CboSerieFactura.Enabled = False
                TFOLIO.Enabled = False
                LtDisponible.Text = ""
                Pag4.TabVisible = False
                Pag8.TabVisible = False
            Else
                If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                    BarGrabar.Text = "Grabar y facturar"
                    CboSerieFactura.Enabled = True
                    TFOLIO.Enabled = True
                Else
                    'Var10 = "VIAJE BUENO"
                    If FACTURA_UNO_O_MULT = "VIAJE BUENO" Then

                    End If
                End If
            End If
            If Var17 = "" Then
                BoxGastos.Width = Screen.PrimaryScreen.Bounds.Width - 130

                FgG.Width = Screen.PrimaryScreen.Bounds.Width - 100
                FgV.Width = Screen.PrimaryScreen.Bounds.Width - 100
                Fg.Width = Screen.PrimaryScreen.Bounds.Width - 100
                FgA.Width = Screen.PrimaryScreen.Bounds.Width - 100

                Pag6.TabVisible = False
                Pag7.TabVisible = False

            Else
                Me.FormBorderStyle = FormBorderStyle.Sizable
                Me.WindowState = FormWindowState.Normal
                Me.ShowInTaskbar = False
                Me.MaximizeBox = False
                Me.MinimizeBox = False

                Me.Width = Screen.PrimaryScreen.Bounds.Width

                FgA.Width = Me.Width - 50 'ADICIONALES
                FgA.Height = TAB1.Height - 100 'ADICIONALES

                FgG.Width = BoxGastos.Width - 50
                FgV.Width = BoxGastos.Width - 50

                SplitM3.Width = Screen.PrimaryScreen.Bounds.Width - 150
                Fg.Dock = DockStyle.Fill

                Pag3.TabVisible = False 'GASTOS DE VIAJE
                Pag6.TabVisible = True 'MERCANCIAS
                Pag7.TabVisible = True 'IMPORTES
                Me.CenterToScreen()
            End If

            FgA.Cols(1).Visible = False

            TNETO.Value = 0

            AssignValidation(Me.TCVE_TAB_VIAJE, ValidationType.Only_Numbers)

            FACTOR_IEPS = 0
            SERIE_A = "" : FOLIO_A = 1
            SERIE_AG = "" : FOLIO_AG = 1
            SERIE_AV = "" : FOLIO_AV = 1
            OBTENER_FOLIOS()
            ENTRA = True

            Me.KeyPreview = True

            F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy HH:mm:ss"

            F2.Value = Date.Today
            F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F2.EditFormat.CustomFormat = "dd/MM/yyyy HH:mm:ss"


            FRC.Value = Date.Today
            FRC.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FRC.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            FRC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FRC.EditFormat.CustomFormat = "dd/MM/yyyy HH:mm:ss"

            FRD.Value = Date.Today
            FRD.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FRD.CustomFormat = "dd/MM/yyyy HH:mm:ss"
            FRD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FRD.EditFormat.CustomFormat = "dd/MM/yyyy HH:mm:ss"

            FFG.Value = Date.Today
            FFG.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FFG.CustomFormat = "dd/MM/yyyy"
            FFG.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FFG.EditFormat.CustomFormat = "dd/MM/yyyy"

            FIFG.Value = Date.Today
            FIFG.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FIFG.CustomFormat = "dd/MM/yyyy"
            FIFG.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FIFG.EditFormat.CustomFormat = "dd/MM/yyyy"

            FPDFG.Value = Date.Today
            FPDFG.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FPDFG.CustomFormat = "dd/MM/yyyy"
            FPDFG.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FPDFG.EditFormat.CustomFormat = "dd/MM/yyyy"

            FgViajes.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

            MenuCV.Items.Add("Eliminar partida")
            Fg.ContextMenuStrip = MenuCV

            FgViajes.SetCellCheck(0, 1, C1.Win.C1FlexGrid.CheckEnum.Unchecked)

            FECHA.Value = Date.Today
            FECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.CustomFormat = "dd/MM/yyyy"
            FECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

            FECHA.Value = Date.Today

            TRECOGER_EN.MaxLength = 255
            TENTREGAR_EN.MaxLength = 255

            FgG.Cols(7).ComboList = "EDICION|ACEPTADO|"
            FgG.Cols(10).ComboList = "TRANSFERENCIA|EFECTIVO|"

            FgV.Cols(15).ComboList = "EDICION|CAPTURADO|"

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


            FgCarga.Cols(1).StarWidth = "*" 'CANTIDAD
            FgCarga.Cols(2).StarWidth = "3*" 'EMBALAJE
            FgCarga.Cols(3).StarWidth = "3*" 'CARGA
            FgCarga.Cols(4).StarWidth = "2*" 'QUE EL REMITENTE DICE CONTIENEN
            FgCarga.Cols(5).StarWidth = "*" 'PESO
            FgCarga.Cols(6).StarWidth = "*" 'VOLUMEN
            FgCarga.Cols(7).StarWidth = "*" 'Peso estimado
            FgCarga.Cols(8).StarWidth = "*" 'PEDIMENTO

            FgCarga.Cols(1).MinWidth = 50
            FgCarga.Cols(9).Visible = False

            FgG.ShowButtons = ShowButtonsEnum.Always
            FgV.ShowButtons = ShowButtonsEnum.Always

            Fg.Rows(0).Height = 50
            Fg.Styles.Fixed.WordWrap = True

            FgCarga.Rows.Count = 1
            SplitM4.Dock = DockStyle.Fill
            FgCarga.Dock = DockStyle.Fill

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
                For k = 1 To FgCarga.Cols.Count - 1
                    FgCarga(0, k) = FgCarga(0, k) & " (" & k & ")"
                Next
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = k & "." & Fg(0, k)
                Next
                For k = 1 To FgA.Cols.Count - 1
                    FgA(0, k) = k & "." & FgA(0, k)
                Next
            Else
                FgG.Cols(11).Width = 0
                FgV.Cols(19).Width = 0
            End If

            TCVE_TRACTOR.Text = ""
            TCVE_TANQUE1.Text = ""
            TCVE_TANQUE2.Text = ""
            TCVE_DOLLY.Text = ""

            TCVE_TRACTOR.Tag = ""
            TCVE_TANQUE1.Tag = ""
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

            DOC_NEW = False
            TIMPORTE_CONCEP.Value = 0
            TAB1.SelectedIndex = 0

            Me.Text = Var11
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

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
            SQL = "SELECT CVE_PRODSERV, CVE_UNIDAD FROM GCPARAMVENTAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_PRODSERV = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                        CVE_UNIDAD = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        Try
            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Clave", GetType(System.String))
            dt.Columns.Add("Descripcion", GetType(System.String))

            dt.Rows.Add("", "")
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_COBRO, DESCR FROM GCASIGCONCEP_COBRO ORDER BY CVE_COBRO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_COBRO"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboConc1.TextDetached = True
            CboConc1.ItemsDataSource = dt.DefaultView
            CboConc1.ItemsDisplayMember = "Descripcion"
            CboConc1.ItemsValueMember = "Clave"
            CboConc1.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc1.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboConc2.TextDetached = True
            CboConc2.ItemsDataSource = dt.DefaultView
            CboConc2.ItemsDisplayMember = "Descripcion"
            CboConc2.ItemsValueMember = "Clave"
            CboConc2.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc2.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboConc3.TextDetached = True
            CboConc3.ItemsDataSource = dt.DefaultView
            CboConc3.ItemsDisplayMember = "Descripcion"
            CboConc3.ItemsValueMember = "Clave"
            CboConc3.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc3.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboConc4.TextDetached = True
            CboConc4.ItemsDataSource = dt.DefaultView
            CboConc4.ItemsDisplayMember = "Descripcion"
            CboConc4.ItemsValueMember = "Clave"
            CboConc4.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc4.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboConc5.TextDetached = True
            CboConc5.ItemsDataSource = dt.DefaultView
            CboConc5.ItemsDisplayMember = "Descripcion"
            CboConc5.ItemsValueMember = "Clave"
            CboConc5.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc5.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboConc6.TextDetached = True
            CboConc6.ItemsDataSource = dt.DefaultView
            CboConc6.ItemsDisplayMember = "Descripcion"
            CboConc6.ItemsValueMember = "Clave"
            CboConc6.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboConc6.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"


            CboConc1.SelectedIndex = 0
            CboConc2.SelectedIndex = 0
            CboConc3.SelectedIndex = 0
            CboConc4.SelectedIndex = 0
            CboConc5.SelectedIndex = 0
            CboConc6.SelectedIndex = 0
            DERECHOS()

        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        TFOLIO.Value = 0

        SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA
              FROM FOLIOSF" & Empresa & "
              WHERE TIP_DOC = 'F'"
        CboSerieFactura.Items.Clear()
        Using cmd As SqlCommand = cnSAE.CreateCommand
            cmd.CommandText = SQL
            Using dr As SqlDataReader = cmd.ExecuteReader
                While dr.Read
                    CboSerieFactura.Items.Add(dr("LETRA"))
                    CboSerieFG.Items.Add(dr("LETRA"))
                End While
            End Using
        End Using

        CboSerieFG.SelectedIndex = 0

        LtDisponible.Text = ""

        If Var1 = "Nuevo" Then
            Try
                ViajeNew = True

                BarImprimir.Enabled = False
                'BarImprimirCartasPorte.Enabled = False
                'BarImprimirBitacoraViaje.Enabled = False

                FOLIO_A = GET_MAX_TRY("GCASIGNACION_VIAJE", "CVE_VIAJE")

                'TCVE_DOC.Text = ""
                LtCVE_VIAJE.Text = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)

                Ltviaje2.Text = LtCVE_VIAJE.Text
                LtNoViaje.Text = LtCVE_VIAJE.Text

                LtStatus.Text = "DISPONIBLE"
                LtCVE_VIAJE.Tag = ""
                DOC_NEW = True

                TCVE_PRODSERV.Value = CVE_PRODSERV
                TCVE_UNIDAD.Value = CVE_UNIDAD

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            ViajeNew = False
            BarCopiarViaje.Enabled = False

            'Var11 = "Viajes a facturar"
            If FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Then
                DESPLEGAR_VIAJES_NO_FACTURADOS(Var4)
            Else
                Try
                    LtCVE_VIAJE.Text = Var2
                    DESPLEGAR_VIAJE(Var2)

                    If TCVE_MON.Text.Trim.Length = 0 Then
                        TCVE_MON.Focus()
                    ElseIf TCLAVE_O.Text.Trim.Length = 0 Then
                        TCLAVE_O.Focus()
                    ElseIf TCLAVE_D.Text.Trim.Length = 0 Then
                        TCLAVE_D.Focus()
                    ElseIf TRECOGER_EN.Text.Trim.Length = 0 Then
                        TRECOGER_EN.Focus()
                    ElseIf TENTREGAR_EN.Text.Trim.Length = 0 Then
                        TENTREGAR_EN.Focus()
                    ElseIf TCVE_OPER.Text.Trim.Length = 0 Then
                        TCVE_OPER.Focus()
                    Else
                        TORDEN_DE.Focus()
                    End If

                Catch ex As Exception
                    Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
        CARGAR_TARIFAS(TCVE_TAB_VIAJE.Text)

        DESPLEGAR_TIPO_VIAJE()

        ACEPTA_CALCULO = True
        ENTRAM = True

        Select Case LtStatus.Text
            Case "Cancelado"
                BarGrabar.Enabled = False
                BarEditarRemitente.Enabled = False
                BarEditDestinatario.Enabled = False
                BoxGastos.Enabled = False
                SplitM3.Enabled = False
                SplitM4.Enabled = False
                TFOLIO_VIAJE.Enabled = False
                BtnSelViaje.Enabled = False
                ChCalleFiscal.Enabled = False
                BarEditarRemitente.Enabled = False
                BarEditDestinatario.Enabled = False

                DESHABILITAR()
            Case "TIMBRADO"

                If TFLETEA.Value <= 0 And ESCENARIO <> 3 Then
                    BarGrabar.Enabled = False
                    BarEditarRemitente.Enabled = False
                    BarEditDestinatario.Enabled = False
                    BoxGastos.Enabled = False
                    SplitM3.Enabled = False
                    SplitM4.Enabled = False
                    TFOLIO_VIAJE.Enabled = False
                    BtnSelViaje.Enabled = False
                    ChCalleFiscal.Enabled = False

                    BarEditarRemitente.Enabled = False
                    BarEditDestinatario.Enabled = False

                    DESHABILITAR()
                Else
                    TFOLIO.Value = 0
                    CboSerieFactura.SelectedIndex = -1
                End If
            Case "LIQUIDADO"
                BarGrabar.Enabled = False
                BarEditarRemitente.Enabled = False
                BarEditDestinatario.Enabled = False
                BoxGastos.Enabled = False
                SplitM3.Enabled = False
                SplitM4.Enabled = False
                TFOLIO_VIAJE.Enabled = False
                BtnSelViaje.Enabled = False
                ChCalleFiscal.Enabled = False
                BarEditarRemitente.Enabled = False
                BarEditDestinatario.Enabled = False

                DESHABILITAR()

                BoxGastos.Enabled = False
        End Select


        Mofifica_Remitente_destinatario = True

        If LtTimbrado.Text = "FACTURADO" Or LtTimbrado.Text = "TIMBRADO" Then
            Mofifica_Remitente_destinatario = False
            ChCalleFiscal.Enabled = False
            BarEditarRemitente.Enabled = False
            BarEditDestinatario.Enabled = False
        End If
        If LtStatus.Text = "Cancelado" Or LtStatus.Text = "LIQUIDADO" Then
            Mofifica_Remitente_destinatario = False
            ChCalleFiscal.Enabled = False
            BarEditarRemitente.Enabled = False
            BarEditDestinatario.Enabled = False

        End If

        FgG.EndUpdate()
        FgV.EndUpdate()
        Fg.EndUpdate()
        FgA.EndUpdate()

        FgG.Redraw = True
        FgV.Redraw = True
        Fg.Redraw = True
        FgA.Redraw = True

    End Sub
    Sub DESPLEGAR_TIPO_VIAJE()

        If FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then

            If IsNumeric(LtFolio.Text) AndAlso Convert.ToInt32(LtFolio.Text) > 0 Then

                If ESCENARIO = 3 And SSUBT > 0 Then
                    Dim Efecto As Boolean = True
                    Try
                        For Each c As Control In Pag1.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = Efecto
                            End If
                            If TypeOf c Is Button Then
                                c.Enabled = Efecto
                            End If
                        Next
                        For Each c As Control In Pag6.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = Efecto
                            End If
                            If TypeOf c Is Button Then
                                c.Enabled = Efecto
                            End If
                        Next
                        NO_MODIF_FG = True
                        For Each c As Control In Pag7.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = Efecto
                            ElseIf TypeOf c Is Button Then
                                c.Enabled = Efecto
                            Else
                                c.Enabled = Efecto
                            End If
                        Next
                        For Each c As Control In Pag8.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = Efecto
                            ElseIf TypeOf c Is Button Then
                                c.Enabled = Efecto
                            Else
                                c.Enabled = Efecto
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
                            c.Enabled = Efecto
                        End If
                        If TypeOf c Is Button Then
                            c.Enabled = Efecto
                        End If
                    Next

                    For Each c As Control In Gpo6.Controls
                        If TypeOf c Is TextBox Then
                            c.BackColor = Color.LightYellow
                            c.ForeColor = Color.Black
                            c.Enabled = Efecto
                        ElseIf TypeOf c Is Button Then
                            c.Enabled = Efecto
                        Else
                            c.Enabled = Efecto
                        End If
                    Next
                    Debug.Print("")
                    For Each c As Control In Box2.Controls
                        If TypeOf c Is TextBox Then
                            c.BackColor = Color.LightYellow
                            c.ForeColor = Color.Black
                            c.Enabled = Efecto
                        End If
                        If TypeOf c Is Button Then
                            c.Enabled = Efecto
                        End If
                    Next
                    For Each c As Control In Box4.Controls
                        If TypeOf c Is TextBox Then
                            c.BackColor = Color.LightYellow
                            c.ForeColor = Color.Black
                            c.Enabled = Efecto
                        End If
                        If TypeOf c Is Button Then
                            c.Enabled = Efecto
                        End If
                    Next
                    For Each c As Control In Box5.Controls
                        If TypeOf c Is TextBox Then
                            c.BackColor = Color.LightYellow
                            c.ForeColor = Color.Black
                            c.Enabled = Efecto
                        End If
                        If TypeOf c Is Button Then
                            c.Enabled = Efecto
                        End If
                    Next
                    Try
                        BarGrabar.Enabled = Efecto
                        BtnCLAVE_REM.Enabled = Efecto
                        BtnCLAVE_DEST.Enabled = Efecto
                        BtnOper.Enabled = Efecto
                        BtnTractor.Enabled = Efecto
                        BtnTanque1.Enabled = Efecto
                        BtnTanque2.Enabled = Efecto
                        BtnDolly.Enabled = Efecto

                        SplitM3P1.Enabled = Efecto
                        SplitM3P2.Enabled = Efecto

                        SplitM4P1.Enabled = Efecto
                        SplitM4P2.Enabled = Efecto

                        'TOBS.Enabled = False
                    Catch ex As Exception
                    End Try

                Else
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
                        For Each c As Control In Pag6.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = False
                            End If
                            If TypeOf c Is Button Then
                                c.Enabled = False
                            End If
                        Next
                        NO_MODIF_FG = True

                        For Each c As Control In Pag7.Controls

                            BACKUPTXT("TYPECONTROLS", c.Name)
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = False
                            ElseIf TypeOf c Is Button Then
                                c.Enabled = False
                            Else
                                c.Enabled = False
                            End If
                        Next


                        For Each c As Control In Pag8.Controls
                            If TypeOf c Is TextBox Then
                                c.BackColor = Color.LightYellow
                                c.ForeColor = Color.Black
                                c.Enabled = False
                            ElseIf TypeOf c Is Button Then
                                c.Enabled = False
                            Else
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

                    For Each c As Control In Gpo6.Controls
                        If TypeOf c Is TextBox Then
                            c.BackColor = Color.LightYellow
                            c.ForeColor = Color.Black
                            c.Enabled = False
                        ElseIf TypeOf c Is Button Then
                            c.Enabled = False
                        Else
                            c.Enabled = False
                        End If
                    Next
                    Debug.Print("")
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

                    Try
                        BarGrabar.Enabled = False
                        BtnCLAVE_REM.Enabled = False
                        BtnCLAVE_DEST.Enabled = False
                        BtnOper.Enabled = False
                        BtnTractor.Enabled = False
                        BtnTanque1.Enabled = False
                        BtnTanque2.Enabled = False
                        BtnDolly.Enabled = False

                        SplitM3P1.Enabled = False
                        SplitM3P2.Enabled = False

                        SplitM4P1.Enabled = False
                        SplitM4P2.Enabled = False
                    Catch ex As Exception
                    End Try
                End If

                If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                    SQL = "SELECT A.FACTURADO, A.TIMBRADO, A.TIPO_FACTURACION, A.CVE_VIAJE, A.NETO,
                        ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) As ABONOS,
                        (A.NETO -ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO
                        FROM GCASIGNACION_VIAJE A 
                        WHERE CVE_VIAJE = '" & LtCVE_VIAJE.Text & "' AND A.STATUS <> 'C' AND ISNULL(FACTURADO,'') = 'S'"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then

                                    If dr("TIPO_FACTURACION") = 3 Then
                                        If dr("SALDO") > 1 Then
                                            BarGrabar.Enabled = True
                                            CboSerieFactura.Enabled = True
                                            TFOLIO.Enabled = True
                                            TABONO_NETO.Enabled = True

                                            For Each c As Control In Pag7.Controls
                                                If TypeOf c Is TextBox Then
                                                    c.BackColor = Color.LightYellow
                                                    c.ForeColor = Color.Black
                                                    c.Enabled = True
                                                ElseIf TypeOf c Is Button Then
                                                    c.Enabled = True
                                                Else
                                                    c.Enabled = True
                                                End If
                                            Next
                                        Else
                                            TABONO_NETO.Enabled = False

                                            For Each c As Control In Pag7.Controls
                                                If TypeOf c Is TextBox Then
                                                    c.BackColor = Color.LightYellow
                                                    c.ForeColor = Color.Black
                                                    c.Enabled = False
                                                ElseIf TypeOf c Is Button Then
                                                    c.Enabled = False
                                                Else
                                                    c.Enabled = False
                                                End If
                                            Next
                                        End If
                                    End If
                                    BarGrabar.Enabled = True
                                End If

                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
                Try
                    SQL = "SELECT LP.CVE_VIAJE, L.STATUS, LP.STATUS, LP.CVE_ST_VIA  FROM GCLIQ_PARTIDAS LP
                        LEFT JOIN GCLIQUIDACIONES L ON L.CVE_LIQ = LP.CVE_LIQ
                        WHERE L.STATUS = 'L' AND LP.STATUS <> 'C' AND LP.CVE_VIAJE = '" & LtCVE_VIAJE.Text & "'"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    BoxGastos.Enabled = False
                                    LtStatus.Text = "LIQUIDADO"
                                    BarGrabar.Enabled = False
                                Else
                                    BoxGastos.Enabled = True
                                    BarGrabar.Enabled = True
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Else
                'Pag7.TabVisible = False
            End If
            FOLIO_INICIAL = TFOLIO.Value
        End If
    End Sub
    Sub DESHABILITAR()

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
            For Each c As Control In Pag6.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                End If
                If TypeOf c Is Button Then
                    c.Enabled = False
                End If
            Next
            NO_MODIF_FG = True
            For Each c As Control In Pag7.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                ElseIf TypeOf c Is Button Then
                    c.Enabled = False
                Else
                    c.Enabled = False
                End If
            Next


            For Each c As Control In Pag8.Controls
                If TypeOf c Is TextBox Then
                    c.BackColor = Color.LightYellow
                    c.ForeColor = Color.Black
                    c.Enabled = False
                ElseIf TypeOf c Is Button Then
                    c.Enabled = False
                Else
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
        For Each c As Control In Gpo6.Controls
            If TypeOf c Is TextBox Then
                c.BackColor = Color.LightYellow
                c.ForeColor = Color.Black
                c.Enabled = False
            ElseIf TypeOf c Is Button Then
                c.Enabled = False
            Else
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

        Try
            BarGrabar.Enabled = False
            BtnCLAVE_REM.Enabled = False
            BtnCLAVE_DEST.Enabled = False
            BtnOper.Enabled = False
            BtnTractor.Enabled = False
            BtnTanque1.Enabled = False
            BtnTanque2.Enabled = False
            BtnDolly.Enabled = False

            SplitM3P1.Enabled = False
            SplitM3P2.Enabled = False

            SplitM4P1.Enabled = False
            SplitM4P2.Enabled = False

            Box4.Enabled = False

            TFOLIO_VIAJE.Enabled = False
            BtnSelViaje.Enabled = False

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_VIAJES_NO_FACTURADOS(FCLIENTE As String)

        FgViajes.Rows.Count = 1
        FgViajes.Redraw = False

        SQL = "SELECT TOP 5000 A.CVE_VIAJE, FECHA_CARGA
            FROM GCASIGNACION_VIAJE A 
            LEFT JOIN GCCAT_STATUS_VIAJE S ON S.CLAVE = A.CVE_ST_VIA
            WHERE A.STATUS <> 'C' AND A.CLIENTE = '" & FCLIENTE & "' AND ISNULL(A.FACTURADO,'') <> 'S' AND ISNULL(A.TIMBRADO,'') <> 'S'
            ORDER BY A.FECHAELAB DESC"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgViajes.AddItem("" & vbTab & "" & vbTab & dr("CVE_VIAJE") & vbTab & dr("FECHA_CARGA"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        FgViajes.Redraw = True
    End Sub
    Private Sub MenuCV_Opening(sender As Object, e As CancelEventArgs) Handles MenuCV.Opening

        Try
            MenuCV.Items.Clear()

            If Not IsNothing(Fg(Fg.Row, 2)) Then
                MenuCV.Items.AddRange({New ToolStripMenuItem("Eliminar partida " & Fg(Fg.Row, 2).ToString)})
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MenuCV_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuCV.ItemClicked
        Try
            If Fg.Row > 0 Then
                Fg.RemoveItem(Fg.Row)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR_VIAJE(FCVE_VIAJE As String)
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        cmd.Connection = cnSAE
        Dim CAMBIO_MON As Decimal

        If FCVE_VIAJE.Trim.Length = 0 Then
            Return
        End If


        SQL = "SELECT A.CVE_VIAJE, A.CVE_DOC, A.FECHA, A.FECHA_CARGA, A.FECHA_DESCARGA, A.STATUS, ISNULL(A.CVE_ST_VIA,0) AS STATUS_VIA, 
            ISNULL(CVE_ST_VALE,1) AS STATUS_VALE, ISNULL(A.CVE_ST_UNI,0) AS STATUS_UNI, A.TIPO_UNI, A.TIPO_VIAJE, A.CVE_OPER, 
            A.CVE_CON, A.CVE_TRACTOR, A.CVE_TANQUE1, A.CVE_TANQUE2, A.CVE_DOLLY, ISNULL(A.CVE_RUTA,0) AS C_RUTA, 
            ISNULL(A.RECOGER_EN,'') AS RECOGER, ISNULL(A.ENTREGAR_EN,'') AS ENTREGAR, ISNULL(A.CLAVE_O,'') AS ORIGEN, ISNULL(A.CLAVE_D,'') AS DESTINO, 
            ISNULL(A.CVE_TAB, '') AS CVETAB, A.NOTA, A.ORDEN_DE, A.EMBARQUE, A.CARGA_ANTERIOR, ISNULL(A.CVE_TAB_VIAJE,0) AS TAB_VIAJE, 
            ISNULL(R.CVE_TAB,'') AS CVE_TAB_RUTA, A.CLIENTE, A.CVE_MONED, A.VOLUMEN_PESO, PRECIO_VIAJE_TONE, IMPORTE_CONCEP, CVE_COBRO, 
            ISNULL(SUBTOTAL,0) AS SUBT, ISNULL(IVA,0) AS IV, ISNULL(RETENCION,0) AS RET, ISNULL(NETO,0) AS NET, ISNULL(CANT,0) AS CANTIDAD, 
            ISNULL(REM_CARGA,0) AS REM_CAR, ISNULL(A.FLETE,0) AS FLET, ISNULL(A.CVE_ESQIMPU,0) AS CVE_ESQ, C.FORMADEPAGOSAT, C.USO_CFDI, 
            C.METODODEPAGO, SERIE, FOLIO, A.CVE_COBRO, CVE_PRODSERV, CVE_UNIDAD, C.NOMBRE, ISNULL(R.DESCR,'') AS DES1, ISNULL(R.DESCR2,'') AS DES2, 
            CALLE_FISCAL, CALLE1, CALLE2, A.TIPO_CAMBIO_LEYENDA, A.TIPO_CAMBIO, ISNULL(C.CVE_ESQIMPU,0) AS CVE_ESQ_CLIE,
            FECHA_REAL_CARGA, FECHA_REAL_DESCARGA, KMS_VACIO, ISNULL(FACTURADO,'') AS FACT_OK, ISNULL(TIMBRADO,'') AS TIMBRA,
            ISNULL(COMPLEMENTO,0) AS COMPLE, ISNULL(VIAJE_COMPLE,'') AS VIA_COMPLE, ISNULL(OBS_COMPLE,'') AS OB_COMPLE
            FROM GCASIGNACION_VIAJE A 
            LEFT JOIN GCTAB_RUTAS_F R ON R.CVE_TAB = A.CVE_TAB
            LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = A.CLIENTE
            WHERE A.CVE_VIAJE = '" & FCVE_VIAJE & "'"
        Try
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    Try
                        If dr("COMPLE") = 1 Then
                            ChComplemento.Checked = True
                            TVIAJE_COMPLE.Text = dr("VIA_COMPLE")
                            TOBS_COMPLE.Text = dr("OB_COMPLE")
                            TVIAJE_COMPLE.Visible = True
                            TOBS_COMPLE.Visible = True
                            Lt1.Visible = True
                            Lt2.Visible = True
                        Else
                            ChComplemento.Checked = False
                            TVIAJE_COMPLE.Text = ""
                            TOBS_COMPLE.Text = ""
                            TVIAJE_COMPLE.Visible = False
                            TOBS_COMPLE.Visible = False
                            Lt1.Visible = False
                            Lt2.Visible = False
                        End If
                    Catch ex As Exception
                    End Try

                    If SeCopio <> "S" Then
                        LtCVE_VIAJE.Text = FCVE_VIAJE
                        LtCVE_VIAJE.Tag = LtCVE_VIAJE.Text
                        Ltviaje2.Text = LtCVE_VIAJE.Text
                    End If

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

                    '---------------------------------------------------------------------------

                    If IsDate(dr("FECHA_REAL_CARGA").ToString) Then
                        FRC.Value = dr("FECHA_REAL_CARGA").ToString
                    Else
                        FRC.Value = Now
                    End If

                    If IsDate(dr("FECHA_REAL_DESCARGA").ToString) Then
                        FRD.Value = dr("FECHA_REAL_DESCARGA").ToString
                    Else
                        FRD.Value = Now
                    End If

                    TCVE_TAB_VIAJE.Text = dr("TAB_VIAJE")
                    If TCVE_TAB_VIAJE.Text = "0" Then TCVE_TAB_VIAJE.Text = ""

                    TCLIENTE.Text = dr.ReadNullAsEmptyString("CLIENTE")

                    LNombreCTe.Text = BUSCA_CAT("Cliente", TCLIENTE.Text)

                    LtDescr.Text = dr("DES1")
                    LtDescr2.Text = dr("DES2")


                    TCVE_MON.Text = dr.ReadNullAsEmptyInteger("CVE_MONED")
                    If TCVE_MON.Text = "0" Then
                        TCVE_MON.Text = ""
                    End If

                    Try
                        CAMBIO_MON = 0
                        If TCVE_MON.Text.Trim.Length = 0 AndAlso Not IsNumeric(TCVE_MON.Text) Then
                            TCVE_MON.Text = "1"
                        End If

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED  
                                    FROM MONED" & Empresa & " WHERE NUM_MONED = " & TCVE_MON.Text
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    LtMoneda.Text = dr2("DESCR")
                                    CAMBIO_MON = dr2.ReadNullAsEmptyDecimal("TCAMBIO")
                                    LtCve_moned.Text = dr2("CVE_MONED")
                                    TTIPO_CAMBIO.Value = dr2("TCAMBIO")
                                Else
                                    LtMoneda.Text = ""
                                    CAMBIO_MON = 0
                                    LtCve_moned.Text = ""
                                    TTIPO_CAMBIO.Value = 0
                                End If
                            End Using
                        End Using


                        TTIPO_CAMBIO_LEYENDA.Text = dr.ReadNullAsEmptyString("TIPO_CAMBIO_LEYENDA")
                        If dr.ReadNullAsEmptyDecimal("TIPO_CAMBIO") > 0 Then
                            TTIPO_CAMBIO.Value = dr.ReadNullAsEmptyDecimal("TIPO_CAMBIO")
                            TTIPO_CAMBIO.Tag = TTIPO_CAMBIO.Value
                        Else
                            TTIPO_CAMBIO.Value = CAMBIO_MON
                            TTIPO_CAMBIO.Tag = TTIPO_CAMBIO.Value
                        End If
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    TFORMADEPAGOSAT.Text = dr("FORMADEPAGOSAT")
                    TUSO_CFDI.Text = dr("USO_CFDI")
                    TMETODODEPAGO.Text = dr("METODODEPAGO")


                    For k = 0 To CboSerieFactura.Items.Count - 1
                        If CboSerieFactura.Items(k) = dr.ReadNullAsEmptyString("SERIE") Then
                            CboSerieFactura.SelectedIndex = k
                            Exit For
                        End If
                    Next

                    If SeCopio <> "S" Then
                        LtSerie.Text = dr.ReadNullAsEmptyString("SERIE")
                        LtFolio.Text = dr.ReadNullAsEmptyLong("FOLIO")
                        TFOLIO.Value = dr.ReadNullAsEmptyLong("FOLIO")
                    End If

                    TKMS_VACIO.Value = dr("KMS_VACIO")
                    STATUS_VIA = dr("STATUS_VIA")
                    LtStatus.Text = BUSCA_CAT("Estatus Viaje", STATUS_VIA)

                    If dr("FACT_OK") = "S" Then
                        LtTimbrado.Visible = True
                        LtTimbrado.Text = "FACTURADO"
                        LtTimbrado.BorderStyle = BorderStyle.FixedSingle
                        LtStatus.Text = "Facturado"
                        ChCalleFiscal.Enabled = False
                        BarEditarRemitente.Enabled = False
                        BarEditDestinatario.Enabled = False
                    End If

                    If dr("TIMBRA") = "S" Or dr("TIMBRA") = "S" Then
                        LtTimbrado.Visible = True
                        LtTimbrado.Text = "TIMBRADO"
                        LtTimbrado.BorderStyle = BorderStyle.FixedSingle
                        LtStatus.Text = "Timbrado"
                        ChCalleFiscal.Enabled = False
                        BarEditarRemitente.Enabled = False
                        BarEditDestinatario.Enabled = False
                    End If

                    If dr("STATUS") = "C" Then
                        STATUS_CANCELADO = True
                        LtStatus.Text = "Cancelado"
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

                If dr.ReadNullAsEmptyInteger("CALLE_FISCAL") = 1 Then

                    ChCalleFiscal.Checked = True
                    Try
                        ChCalleFiscal.CheckState = Windows.Forms.CheckState.Checked
                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT NOMBRE, RFC, CALLE, CRUZAMIENTOS, CRUZAMIENTOS2 
                                FROM CLIE" & Empresa & "
                                WHERE CLAVE  = '" & TCLIENTE.Text & "'"
                            cmd3.CommandText = SQL
                            Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                If dr3.Read Then
                                    LtNombre1.Text = dr3("NOMBRE")
                                    LtRFC.Text = dr3("RFC")
                                    LtCalle1.Text = dr3("CALLE")
                                    LtCalle2.Text = dr3("CRUZAMIENTOS") & " " & dr3("CRUZAMIENTOS2")
                                    LtAliasO.Text = ""
                                    LtPlanta.Text = ""
                                    LtNota.Text = ""
                                Else
                                    LtNombre1.Text = ""
                                    LtAliasO.Text = ""
                                    LtCalle1.Text = ""
                                    LtCalle2.Text = ""
                                    LtPlanta.Text = ""
                                    LtNota.Text = ""
                                    LtRFC.Text = ""
                                End If
                            End Using
                        End Using
                        TCLAVE_O.Text = ""
                        TCLAVE_O.Enabled = False
                        BtnCLAVE_REM.Enabled = False
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    ChCalleFiscal.Checked = False
                    TCLAVE_O.Enabled = True
                    BtnCLAVE_REM.Enabled = True
                    If TCLAVE_O.Text.Trim.Length > 0 Then
                        DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                    End If
                End If

                DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 

                FECHA.Value = dr("FECHA").ToString

                TCVE_OPER.Text = dr("CVE_OPER").ToString
                TCVE_OPER.Tag = TCVE_OPER.Text

                If TCVE_OPER.Text = "0" Then
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Tag = ""
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

                TCVE_TRACTOR.Text = dr("CVE_TRACTOR").ToString
                TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text
                LTractor.Tag = TCVE_TRACTOR.Text

                LTractor.Text = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)

                TCVE_TANQUE1.Text = dr("CVE_TANQUE1").ToString
                TCVE_TANQUE1.Tag = TCVE_TANQUE1.Text
                LTanque1.Tag = TCVE_TANQUE1.Text

                LTanque1.Text = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)

                TCVE_TANQUE2.Text = dr("CVE_TANQUE2").ToString
                TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text
                LTanque2.Tag = TCVE_TANQUE2.Text

                LTanque2.Text = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)

                TCVE_DOLLY.Text = dr("CVE_DOLLY").ToString
                TCVE_DOLLY.Tag = dr("CVE_DOLLY").ToString

                LDolly.Text = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)

                If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                    If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                    Else
                        LtTipoViaje.Text = "Sencillo"
                    End If
                End If

                If dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 1 Then
                    RadCargado.Checked = True
                    RadVacio.Checked = False
                Else
                    RadCargado.Checked = False
                    RadVacio.Checked = True
                End If
<<<<<<< HEAD

                Try

                    TCVE_PRODSERV.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                    TCVE_UNIDAD.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")

=======

                Try

                    TCVE_PRODSERV.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                    TCVE_UNIDAD.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")

>>>>>>> Ultimos Cambios
                    If TCVE_PRODSERV.Value.ToString.Trim.Length = 0 Then TCVE_PRODSERV.Value = CVE_PRODSERV
                    If TCVE_UNIDAD.Value.ToString.Trim.Length = 0 Then TCVE_UNIDAD.Value = CVE_UNIDAD

                    'TAR_X_VIA_FULL
                    'TAR_X_VIA_SENC
                    'TTAR_X_TON_FULL
                    TVOLUMEN_PESO.Value = dr.ReadNullAsEmptyDecimal("VOLUMEN_PESO")

                    TIMPORTE_CONCEP.Value = dr.ReadNullAsEmptyDecimal("IMPORTE_CONCEP")
                    TFLETE.Value = dr("FLET")
                    TFLETE.Tag = dr("FLET")

                    If dr.ReadNullAsEmptyInteger("PRECIO_VIAJE_TONE") = 0 Then
                        RadPrecioXViaje.Checked = True
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        RadPrecioXTonelada.Checked = True
                        MONTO_X_TON = TFLETE.Value
                    End If

                    TSUB_TOTAL.Value = dr("SUBT")
                    TRET.Value = dr("RET")
                    TIVA.Value = dr("IV")
                    TNETO.Value = dr("NET")

                    If ESCENARIO = 0 Then
                        If FACTURA_UNO_O_MULT = "VVM" Then
                            Pag0.TabVisible = False
                        End If
                    End If


                    TCVE_ESQIMPU.Text = dr("CVE_ESQ")

                    If TCVE_ESQIMPU.Text = "0" Then TCVE_ESQIMPU.Text = ""

                    If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                        LtEsquema.Text = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                    Else
                        TCVE_ESQIMPU.Text = dr("CVE_ESQ_CLIE")

                        If TCVE_ESQIMPU.Text = "0" Then TCVE_ESQIMPU.Text = ""

                        If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text.Trim) Then

                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT ISNULL(CVE_ESQIMPU, 0) AS CVE_ESQ, ISNULL(DESCRIPESQ,'') AS DES
                                         FROM IMPU" & Empresa & " 
                                         WHERE ISNULL(CVE_ESQIMPU, 0) = " & CONVERTIR_TO_INT(TCVE_ESQIMPU.Text.Trim)
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            If dr2("CVE_ESQ") > 0 Then
                                                TCVE_ESQIMPU.Text = dr2("CVE_ESQ")
                                                LtEsquema.Text = dr2("DES")
                                            Else
                                                TCVE_ESQIMPU.Text = "0"
                                                LtEsquema.Text = ""
                                            End If
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    End If

                Catch ex As Exception
                    Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try


                DESPLEGAR_GASTOS_VIAJE(FCVE_VIAJE, dr("STATUS_VIA"))

                DESPLEGAR_GASTOS_VALES(FCVE_VIAJE, dr("STATUS_VALE"))

                'AQUI  ESTABA EL ERROR
                DESPLEGAR_MERCANCIAS(FCVE_VIAJE)

                DESPLEGAR_ADIC(FCVE_VIAJE)
                DESPLEGAR_CONCEP_PAR(FCVE_VIAJE)

                DESPLEGAR_CARGAS(FCVE_VIAJE)

                CARGAR_ABONOS_ESCENARIO3(FCVE_VIAJE)

            Else
                'BUSCA SI NO EXISTE EN LA TABLA GCASIGNACION_VIAJE 
                'LtCVE_VIAJE.Text = SIGUIENTE_FOLIO_VIAJE(SERIE_A, FOLIO_A)
                'LtCVE_VIAJE.Tag = ""
                'Ltviaje2.Text = LtCVE_VIAJE.Text
                MsgBox("1. Viaje inexistente, verifique por favor")
                TFOLIO_VIAJE.Value = ""
            End If
            dr.Close()

            If ESCENARIO = 2 And ESCENARIO <> 0 Then
                'CALCULAR_ESCENARIO2_MULT(FCVE_VIAJE)
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Sub CALCULAR_ESCENARIO2_MULT(FCVE_VIAJE As String)

        Dim PREC As Decimal, cIeps As Decimal, cImpu As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, Sigue As Boolean
        Dim M1 As Decimal, M2 As Decimal, M3 As Decimal, M4 As Decimal, M5 As Decimal, M6 As Decimal, FLETE As Decimal
        Dim IVA1 As Decimal = 0, IVA2 As Decimal = 0, IVA3 As Decimal = 0, IVA4 As Decimal = 0, IVA5 As Decimal = 0, IVA6 As Decimal = 0
        Dim RET1 As Decimal = 0, RET2 As Decimal = 0, RET3 As Decimal = 0, RET4 As Decimal = 0, RET5 As Decimal = 0, RET6 As Decimal = 0

        Try
            If TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                LtTipoViaje.Text = "Full"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    'TAR_X_VIA_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_FULL")
                    'TAR_X_VIA_SENC = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_SENC")
                    'TAR_X_TON_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_TON_FULL")
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_VIAJE = TFLETE.Value
                End If
            ElseIf TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length = 0 Then
                LtTipoViaje.Text = "Sencillo"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_TON = TFLETE.Value
                End If
            ElseIf TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length = 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                LtTipoViaje.Text = "Sencillo"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_TON = TFLETE.Value
                End If
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'CALCULOS_TEXTCHANGED(1, "MX")

        Try
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
            TMONTO1.UpdateValueWithCurrentText()
            TMONTO2.UpdateValueWithCurrentText()
            TMONTO3.UpdateValueWithCurrentText()
            TMONTO4.UpdateValueWithCurrentText()
            TMONTO5.UpdateValueWithCurrentText()
            TMONTO6.UpdateValueWithCurrentText()
            TRET1.UpdateValueWithCurrentText()
            TRET2.UpdateValueWithCurrentText()
            TRET3.UpdateValueWithCurrentText()
            TRET4.UpdateValueWithCurrentText()
            TRET5.UpdateValueWithCurrentText()
            TRET6.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text) Then
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
            End If

            If Not IsNothing(TFLETE.Value) AndAlso IsNumeric(TFLETE.Value) AndAlso TFLETE.Text <> "" Then
                FLETE = TFLETE.Value
            Else
                FLETE = 0
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If Not String.IsNullOrEmpty(FLETE) AndAlso IsNumeric(FLETE) Then

                PREC = FLETE

                If RadPrecioXViaje.Checked Then
                    MONTO_X_VIAJE = FLETE
                Else
                    MONTO_X_TON = FLETE
                End If

                PREC = Math.Round(CDec(PREC), 8)

                M1 = IIf(IsNumeric(TMONTO1.Value), Convert.ToDecimal(TMONTO1.Value), 0)
                If ChCAUSA_IVA1.Checked Then
                    IVA1 = M1 * IIf(Not IsNothing(TIVAC1.Value) AndAlso IsNumeric(TIVAC1.Value), TIVAC1.Value, 0) / 100
                End If
                If ChCAUSA_RET1.Checked Then
                    RET1 = M1 * IIf(IsNumeric(TRET1.Value), Convert.ToDecimal(TRET1.Value), 0) / 100
                End If

                M2 = IIf(IsNumeric(TMONTO2.Value), Convert.ToDecimal(TMONTO2.Value), 0)
                If ChCAUSA_IVA2.Checked Then
                    IVA2 = M2 * IIf(Not IsNothing(TIVAC2.Value) AndAlso IsNumeric(TIVAC2.Value), TIVAC2.Value, 0) / 100
                End If
                If ChCAUSA_RET2.Checked Then
                    RET2 = M2 * IIf(IsNumeric(TRET2.Value), Convert.ToDecimal(TRET2.Value), 0) / 100
                End If

                M3 = IIf(IsNumeric(TMONTO3.Value), Convert.ToDecimal(TMONTO3.Value), 0)
                If ChCAUSA_IVA3.Checked Then
                    IVA3 = M3 * IIf(Not IsNothing(TIVAC3.Value) AndAlso IsNumeric(TIVAC3.Value), TIVAC3.Value, 0) / 100
                End If
                If ChCAUSA_RET3.Checked Then
                    RET3 = M3 * IIf(IsNumeric(TRET3.Value), Convert.ToDecimal(TRET3.Value), 0) / 100
                End If

                M4 = IIf(IsNumeric(TMONTO4.Value), Convert.ToDecimal(TMONTO4.Value), 0)
                If ChCAUSA_IVA4.Checked Then
                    IVA4 = M4 * IIf(Not IsNothing(TIVAC4.Value) AndAlso IsNumeric(TIVAC4.Value), TIVAC4.Value, 0) / 100
                End If
                If ChCAUSA_RET4.Checked Then
                    RET4 = M4 * IIf(IsNumeric(TRET4.Value), Convert.ToDecimal(TRET4.Value), 0) / 100
                End If

                M5 = IIf(IsNumeric(TMONTO5.Value), Convert.ToDecimal(TMONTO5.Value), 0)
                If ChCAUSA_IVA5.Checked Then
                    IVA5 = M5 * IIf(Not IsNothing(TIVAC5.Value) AndAlso IsNumeric(TIVAC5.Value), TIVAC5.Value, 0) / 100
                End If
                If ChCAUSA_RET5.Checked Then
                    RET5 = M5 * IIf(IsNumeric(TRET5.Value), Convert.ToDecimal(TRET5.Value), 0) / 100
                End If

                M6 = IIf(IsNumeric(TMONTO6.Value), Convert.ToDecimal(TMONTO6.Value), 0)
                If ChCAUSA_IVA6.Checked Then
                    IVA6 = M6 * IIf(Not IsNothing(TIVAC6.Value) AndAlso IsNumeric(TIVAC6.Value), TIVAC6.Value, 0) / 100
                End If
                If ChCAUSA_RET6.Checked Then
                    RET6 = M6 * IIf(IsNumeric(TRET6.Value), Convert.ToDecimal(TRET6.Value), 0) / 100
                End If

                TIMPORTE_CONCEP.Value = M1 + M2 + M3 + M4 + M5 + M6

                PREC += TIMPORTE_CONCEP.Value

                cIeps = PREC * vIMPU1 / 100
                cImpu2 = PREC * vIMPU2 / 100
                cImpu3 = PREC * vIMPU3 / 100
                cImpu = PREC * vIMPU4 / 100

                TSUB_TOTAL.Value = PREC + M1 + M2 + M3 + M4 + M5 + M6
                TIVA.Value = cIeps + cImpu + IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                TRET.Value = cImpu2 + cImpu3 + RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                TNETO.Value = TSUB_TOTAL.Value + TIVA.Value + TRET.Value

            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub CARGAR_ABONOS_ESCENARIO3(ByVal BVIAJE As String)
        Dim SALDO As Decimal
        Dim SIVA As Decimal, SRET As Decimal, SNETO As Decimal

        If ESCENARIO > 0 Then
            Select Case ESCENARIO
                Case 1

                Case 2

                Case 3
                    Pag0.TabVisible = False

                    Try
                        SQL = "SELECT A.FACTURADO, A.TIMBRADO, A.TIPO_FACTURACION, A.CVE_VIAJE, A.NETO,
                            ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0) As ABONOS,
                            (A.NETO - ISNULL((SELECT SUM(NETO) FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = A.CVE_VIAJE),0)) AS SALDO,
                            B.SUBTOTAL AS SUBTOTAL2, B.IVA as IVA2, B.RET AS RET2, B.NETO AS NETO2 
                            FROM GCASIGNACION_VIAJE A 
                            LEFT JOIN GCASIGNACION_VIAJE_ABONOS B ON B.CVE_VIAJE = A.CVE_VIAJE
                            WHERE A.CVE_VIAJE = '" & LtCVE_VIAJE.Text & "' AND A.STATUS <> 'C' AND ISNULL(FACTURADO,'') = 'S'"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            'SQL = "SELECT SUBTOTAL, IVA, RET,  NETO FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = '" & BVIAJE & "'"
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                While dr2.Read
                                    SSUBT += dr2.ReadNullAsEmptyDecimal("SUBTOTAL2")
                                    SIVA += dr2.ReadNullAsEmptyDecimal("IVA2")
                                    SRET += dr2.ReadNullAsEmptyDecimal("RET2")
                                    SNETO += dr2.ReadNullAsEmptyDecimal("NETO2")
                                    SALDO = dr2("SALDO")
                                End While
                            End Using
                        End Using

                        If SALDO > 0.1 Then
                            TSUBT_ABO3.Value = SSUBT
                            TIVA_ABO3.Value = SIVA
                            TRET_ABO3.Value = SRET
                            TNETO_ABO3.Value = SNETO
                            TABONO_NETO.Value = 0
                            LtSaldo.Visible = True
                            TSALDO_SUBTOTAL.Value = 0 'TSUBT_O2.Value - SSUBT
                            TSALDO_IVA.Value = 0 'TIVA_O2.Value - SIVA
                            TSALDO_RET.Value = 0 'TRET_O2.Value - SRET
                            TSALDO_NETO.Value = 0 'TNETO_O2.Value - SNETO
                            TSUBT_O.Value = 0 'dr("SUBT") - SSUBT
                            TRET_O.Value = 0 'dr("RET") - SIVA
                            TIVA_O.Value = 0 'dr("IV") - SRET
                            TNETO_O.Value = 0 'dr("NET") - SNETO

                            TFLETEA.Value = TNETO.Value - SNETO
                            TFLETE.Enabled = False
                            CboSerieFactura.Enabled = True

                            TABONO_NETO.Enabled = True
                            If TFLETEA.Value < 1 Then
                                TFLETEA.Enabled = False
                                TFOLIO.Enabled = False
                            Else
                                TFLETEA.Enabled = True
                                TFOLIO.Enabled = True
                            End If

                        Else
                            TSUBT_ABO3.Value = SSUBT
                            TIVA_ABO3.Value = SIVA
                            TRET_ABO3.Value = SRET
                            TNETO_ABO3.Value = SNETO
                            'If ESCENARIO = 3 Then
                            TABONO_NETO.Visible = True
                            TFLETEA.Visible = True
                            GpoRem5.Visible = True
                            TFLETEA.Value = TNETO.Value
                            'Else
                            'TABONO_NETO.Visible = False
                            'GpoRem5.Visible = False
                            'End If

                            'LtSaldo.Visible = False
                            'TSALDO_SUBTOTAL.Visible = False
                            'TSALDO_IVA.Visible = False
                            'TSALDO_RET.Visible = False
                            'TSALDO_NETO.Visible = False
                        End If
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

            End Select
        End If
    End Sub
    Sub DESPLEGAR_CONCEP_PAR(FVIAJE As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_COBRO, NUM_PAR, CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA_PORC, RET_PORC, MONTO
                    FROM GCASIG_CONCEP_PAR 
                    WHERE CVE_VIAJE = '" & FVIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr.ReadNullAsEmptyInteger("CVE_COBRO")
                            Case 1
                                For k = 1 To CboConc1.Items.Count - 1
                                    If CboConc1.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc1.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO1.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA1.Checked = True
                                Else
                                    ChCAUSA_IVA1.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET1.Checked = True
                                Else
                                    ChCAUSA_RET1.Checked = False
                                End If
                                TIVAC1.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET1.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV1.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD1.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            Case 2
                                For k = 1 To CboConc2.Items.Count - 1
                                    If CboConc2.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc2.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO2.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA2.Checked = True
                                Else
                                    ChCAUSA_IVA2.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET2.Checked = True
                                Else
                                    ChCAUSA_RET2.Checked = False
                                End If
                                TIVAC2.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET2.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV2.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD2.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            Case 3
                                For k = 1 To CboConc3.Items.Count - 1
                                    If CboConc3.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc3.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO3.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA3.Checked = True
                                Else
                                    ChCAUSA_IVA3.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET3.Checked = True
                                Else
                                    ChCAUSA_RET3.Checked = False
                                End If
                                TIVAC3.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET3.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV3.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD3.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            Case 4
                                For k = 1 To CboConc4.Items.Count - 1
                                    If CboConc4.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc4.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO4.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA4.Checked = True
                                Else
                                    ChCAUSA_IVA4.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET4.Checked = True
                                Else
                                    ChCAUSA_RET4.Checked = False
                                End If
                                TIVAC4.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET4.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV4.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD4.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            Case 5
                                For k = 1 To CboConc5.Items.Count - 1
                                    If CboConc5.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc5.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO5.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA5.Checked = True
                                Else
                                    ChCAUSA_IVA5.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET5.Checked = True
                                Else
                                    ChCAUSA_RET5.Checked = False
                                End If
                                TIVAC5.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET5.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV5.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD5.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                            Case 6
                                For k = 1 To CboConc6.Items.Count - 1
                                    If CboConc6.Items(k) = dr.ReadNullAsEmptyInteger("CVE_COBRO") Then
                                        CboConc6.SelectedIndex = k
                                        Exit For
                                    End If
                                Next
                                TMONTO6.Value = dr.ReadNullAsEmptyDecimal("MONTO")
                                If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                    ChCAUSA_IVA6.Checked = True
                                Else
                                    ChCAUSA_IVA6.Checked = False
                                End If
                                If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                    ChCAUSA_RET6.Checked = True
                                Else
                                    ChCAUSA_RET6.Checked = False
                                End If
                                TIVAC6.Value = dr.ReadNullAsEmptyDecimal("IVA_PORC")
                                TRET6.Value = dr.ReadNullAsEmptyDecimal("RET_PORC")
                                TCVE_PRODSERV6.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                                TCVE_UNIDAD6.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_ADIC(FVIAJE As String)
        Try 'GCASIG_CAMPOS_ADIC (ID INT IDENTITY(1,1) PRIMARY KEY, CAMPO_ADIC VARCHAR(MAX)

            ENTRAA = False
            FgA.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ID, CAMPO_ADIC FROM GCASIG_CAMPOS_ADIC WHERE CVE_VIAJE = '" & FVIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgA.AddItem("" & vbTab & dr("ID") & vbTab & dr("CAMPO_ADIC"))
                    End While
                End Using
                FgA.AddItem("" & vbTab & 0 & vbTab & "")
                FgA.Row = FgA.Rows.Count - 1
                FgA.Col = 2
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        ENTRAA = True
    End Sub

    Sub CARGAR_TARIFAS(FCVE_TAB_VIAJE As String)
        Try
            If FCVE_TAB_VIAJE.Trim.Length > 0 Then
                SQL = "SELECT T.TAR_X_TON_FULL, T.TAR_X_VIA_FULL, T.TAR_X_VIA_SENC 
                FROM GCTAB_RUTAS_F T 
                WHERE CVE_TAB = '" & FCVE_TAB_VIAJE & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            TAR_X_VIA_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_FULL")
                            TAR_X_VIA_SENC = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_SENC")
                            TAR_X_TON_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_TON_FULL")

                            If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                    LtTipoViaje.Text = "Full"

                                    If RadPrecioXViaje.Checked Then
                                        TFLETE.Value = TAR_X_VIA_FULL
                                        TFLETE.Tag = TAR_X_VIA_FULL
                                        MONTO_X_VIAJE = TFLETE.Value
                                    Else
                                        TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                                        TFLETE.Tag = TAR_X_TON_FULL
                                        MONTO_X_TON = TFLETE.Value
                                    End If
                                Else
                                    LtTipoViaje.Text = "Sencillo"
                                    If RadPrecioXViaje.Checked Then
                                        TFLETE.Value = TAR_X_VIA_SENC
                                        TFLETE.Tag = TAR_X_VIA_SENC
                                        MONTO_X_VIAJE = TFLETE.Value
                                    Else
                                        TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                                        TFLETE.Tag = TAR_X_TON_FULL
                                        MONTO_X_TON = TFLETE.Value
                                    End If
                                End If
                            End If
                        End If
                    End Using
                End Using

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_MERCANCIAS(FCVE_VIAJE2 As String)
        Dim s As String

        Try
            'Fg.Cols.Count = 14
            'Fg(0, 1) = "Cantidad"
            'Fg(0, 2) = "ID_UNIDAD"
            'Fg(0, 3) = "Descripcion unidad"
            'Fg(0, 4) = "ID_MERCANCIA"
            'Fg(0, 5) = "Descripcio mercancia"
            'Fg(0, 6) = "Mat. peligroso"
            'Fg(0, 7) = "ID_EMBALAJE"
            'Fg(0, 8) = "Descriupcion embalaje"
            'Fg(0, 9) = "Peso"
            'Fg(0, 10) = "Valor mercancia"
            'Fg(0, 11) = "Moneda"
            'Fg(0, 12) = "ID_FRACC_ARANCELARIA"
            'Fg(0, 13) = "UUID_COM_EXT"

            NO_MODIF_FG = True

            SQL = "SELECT M.CVE_VIAJE, M.NUM_PAR, M.CANT, M.ID_UNIDAD, M.DESC_UNIDAD, M.ID_MERCANCIA, M.DESCR_MERCANCIA, 
                    M.MAT_PELIGROSO, M.CVE_MAT_PELIGROSO, M.ID_EMBALAJE, M.DESC_EMBALAJE, M.PESO, M.VALOR_MERCANCIA, M.MONEDA, 
                    M.ID_FRACC_ARANCELARIA, M.UUID_COM_EXT 
                    FROM GCMERCANCIAS M WHERE CVE_VIAJE = '" & FCVE_VIAJE2 & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    Do While dr.Read

                        s = "" & vbTab '0
                        s &= dr("CANT") & vbTab '1
                        s &= dr("ID_UNIDAD") & vbTab '2
                        s &= "" & vbTab '3
                        s &= dr("DESC_UNIDAD") & vbTab '4
                        s &= dr("ID_MERCANCIA") & vbTab '5
                        s &= "" & vbTab '6
                        s &= dr("DESCR_MERCANCIA") & vbTab '7
                        s &= IIf(dr("MAT_PELIGROSO") = "Si", True, False) & vbTab '8
                        s &= dr("CVE_MAT_PELIGROSO") & vbTab '9
                        s &= "" & vbTab '10
                        s &= dr("ID_EMBALAJE") & vbTab '11
                        s &= "" & vbTab                 ' 12
                        s &= dr("DESC_EMBALAJE") & vbTab '13
                        s &= dr("PESO") & vbTab '14
                        s &= dr("VALOR_MERCANCIA") & vbTab '15
                        s &= dr("MONEDA") & vbTab '16
                        s &= "" & vbTab '17
                        s &= dr("ID_FRACC_ARANCELARIA") & vbTab '18
                        s &= dr("UUID_COM_EXT") & vbTab '19
                        s &= "" & vbTab  '20 AQUI IVA EL VIAJE
                        s &= dr("NUM_PAR")  '21 NUM_PAR
                        Fg.AddItem(s)

                    Loop
                End Using
            End Using

            Fg.Cols(20).Visible = False

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & False & vbTab &
                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & "MXN" & vbTab & "" & vbTab &
                       "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1

            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                'PORQUI NO DEBE DE PASAR
            Else
                'SendKeys.Send(" ")
            End If
            'Fg.AutoSizeRow(0)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        NO_MODIF_FG = False

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
                'BarImprimirBitacoraViaje.Visible = False
                'BarImprimirCartasPorte.Visible = False
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
                                    'SET_ALL_CONTROL_READ_AND_ENABLED(Box9)
                                Case 222060 'MODIFICA DATOS GENERALES

                                Case 22070  'OBSERVACIONES VIAJE
                                Case 222070 'CONSULTAR OBSERVACIONES VIAJE
                                    'SET_ALL_CONTROL_READ_AND_ENABLED(Box7)


                                Case 222080 'MODIFICA OBSERVACIONES VIAJE
                                Case 222090 'CONSULTAR GASTOS DE VIAJE

                                Case 222100 'MODIFICA OBSERVACIONES VIAJE


                                Case 22080  'GASTOS DE CIAJE

                                Case 22090  'DATOS DE LA BITACORA
                                Case 222110 'CONSULTAR DATOS DE LA BITACORA
                                    'SET_ALL_CONTROL_READ_AND_ENABLED(Box10)
                                Case 222120 'MODIFICA DATOS DE LA BITACORA


                                Case 22100  'IMPRIMIR BITACORA DE VIAJE
                                    'BarImprimirBitacoraViaje.Visible = True
                                Case 22110  'IMPIRMIR CARTA PORTE
                                    'BarImprimirCartasPorte.Visible = True
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
    Sub DESPLEGAR_CARGAS(FCVE_VIAJE As String)

        FgCarga.Rows.Count = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CANT, C.EMBALAJE, C.CARGA, C.CONTIENE, C.PESO, C.VOLUMEN, C.PESO_ESTIMADO, C.PEDIMENTO
                    FROM GCCARGA C
                    LEFT JOIN GCCARGAS G1 ON G1.CLAVE = C.CARGA
                    WHERE CVE_VIAJE = '" & FCVE_VIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        FgCarga.AddItem("" & vbTab & dr("CANT") & vbTab & dr("EMBALAJE") & vbTab & dr("CARGA") & vbTab &
                                dr("CONTIENE") & vbTab & dr("PESO") & vbTab & dr("VOLUMEN") & vbTab &
                                dr("PESO_ESTIMADO") & vbTab & dr("PEDIMENTO"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_GASTOS_VIAJE(fCVE_VIAJE As String, fST_GASTOS_VIAJE As Integer)
        Dim STATUS_VIAJES As String
        Dim CVE_FOLIO As Long

        Try
            STATUS_VIAJES = OBTENER_STATUS_GASTOS_VIAJE()

            FgG.Redraw = False

            FgG.Rows.Count = 1

            If SeCopio = "S" Then
                CVE_FOLIO = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")
            End If

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT GV.CVE_OPER, GV.CVE_GAV, GV.FOLIO, convert(varchar, GV.FECHAELAB, 103) AS FECHA_G, GV.CVE_NUM, 
                    GV.IMPORTE, ISNULL(C.DESCR,'No se encontró la deducción en la tabla GCCONC_GASTOS') AS DES, 
                    ISNULL(GV.ST_GASTOS,'EDICION') AS ST_GAS, GV.UUID, GV.CVE_LIQ,
                    CASE WHEN ISNULL(GV.TIPO_PAGO, -1) = -1 THEN '' WHEN ISNULL(GV.TIPO_PAGO, 0) = 0 THEN 'TRANSFERENCIA' ELSE 'EFECTIVO' END AS TPAGO
                    FROM GCASIGNACION_VIAJE_GASTOS GV
                    LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = GV.CVE_NUM
                    WHERE GV.CVE_VIAJE = '" & fCVE_VIAJE & "' AND ISNULL(GV.STATUS,'A') <> 'C' ORDER BY GV.FECHAELAB"

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        FgG.AddItem("" & vbTab & IIf(SeCopio = "S", CVE_FOLIO, dr("FOLIO")) & vbTab & dr("FECHA_G") & vbTab & dr("CVE_NUM") & vbTab &
                                    dr("DES") & vbTab & dr("IMPORTE") & vbTab & dr("FOLIO") & vbTab & IIf(SeCopio = "S", "EDICION", dr("ST_GAS")) & vbTab &
                                    "S" & vbTab & IIf(SeCopio = "S", "", dr("UUID")) & vbTab & dr("TPAGO") & vbTab & "" & vbTab & dr("CVE_LIQ"))
                        CVE_FOLIO += 1
                    End While
                End Using
                FgG.AutoSizeRows()
            End Using
        Catch ex As Exception
            Bitacora("27. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        FgG.Redraw = True
    End Sub
    Sub DESPLEGAR_GASTOS_VALES(fCVE_VIAJE As String, fCVE_ST_VALE As Integer)
        Dim STATUS_VALES As String, FOLIO_TRASPASO As String, s As String
        Dim CVE_FOLIO As Long

        Try
            STATUS_VALES = OBTENER_STATUS_VALES_VIAJE()

            FgG.Redraw = False

            FgV.Rows.Count = 1

            If SeCopio = "S" Then
                CVE_FOLIO = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")
            End If

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

                        'FOLIO_TRASPASO = ES_FOLIO_TRASPASO(dr("FOLIO"))

                        s = IIf(SeCopio = "S", CVE_FOLIO, dr("FOLIO")) & vbTab '1
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
                        s &= IIf(SeCopio = "S", "EDICION", dr("ST_VAL")) & vbTab '1 & vbTab '15
                        s &= dr.ReadNullAsEmptyString("OBS") & vbTab '16
                        s &= "N" & vbTab '17
                        s &= IIf(SeCopio = "S", "", dr("UUID")) & vbTab '18
                        s &= "" & vbTab '19
                        s &= "" & vbTab '20
                        s &= dr("CVE_LIQ") '21

                        FgV.AddItem("" & vbTab & s)
                        'FOLIO_TRASPASO = FOLIO_TRASPASO
                        CVE_FOLIO += 1
                    End While
                    FgV.AutoSizeRows()
                End Using
            End Using

            FgV.ShowButtons = ShowButtonsEnum.Always
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        FgG.Redraw = True
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
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Return ESTA_EL_FOLIO
    End Function
    Private Sub FrmAsigViajeBuenoAE_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    End Sub
    Private Sub FrmAsigViajeBuenoAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA Then
            'SendKeys.Send("{TAB}")
            'e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        Try
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try
        If TVOLUMEN_PESO.Value = 0 Then
            MsgBox("Por favor capture el Volumen/Peso")
            Return
        End If

        If FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Then
            If GUARDAR_FACTURA() Then
                GUARDAR_VIAJE()
            End If
        Else
            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                If GUARDAR_FACTURA() Then
                    GUARDAR_VIAJE()
                End If
            Else
                GUARDAR_VIAJE()
            End If
        End If
    End Sub
    Sub GUARDAR_VIAJE()
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim FLETE As Decimal, REM_CARGA As Integer, CANT As Decimal, DETEC_ERROR_VIOLATION_KEY As Boolean = False
        Dim CVE_VIAJE As String, CVE_OBS As Long, TIPO_UNI As Integer, z As Integer = 0, SeGrabo As Boolean = False
        Dim SERIE_FV As String = "", FOLIO_FV As Long, CVE_COBRO As Integer, CVE_DOC As String = "", CVE_ESQIMPU As Integer
        Dim SQLJ As String

        CVE_DOC = SERIE_FV & FOLIO_FV

        If ESCENARIO = 2 Then

            If LtCVE_VIAJE.Text.Trim.Length = 0 Then
                For k = 1 To Fg.Rows.Count - 1
                    If FgViajes(k, 1) Then
                        LtCVE_VIAJE.Text = FgViajes(FgViajes.Row, 2)
                    End If
                Next
            End If
        Else
            If LtCVE_VIAJE.Text.Trim.Length = 0 Then
                BORRA_FACTURA(CVE_DOC)
                MsgBox("El folio de viaje no fue asignado favor e salga y volver a entrar")
                Return
            End If
        End If

        Try
            TFLETE.UpdateValueWithCurrentText()
            TIMPORTE_CONCEP.UpdateValueWithCurrentText()
            TFOLIO.UpdateValueWithCurrentText()
            TSUBT_O.UpdateValueWithCurrentText()
            TIVA_O.UpdateValueWithCurrentText()
            TRET_O.UpdateValueWithCurrentText()
            TNETO_O.UpdateValueWithCurrentText()
            TDIAS_CRED.UpdateValueWithCurrentText()
            TTIPO_CAMBIO.UpdateValueWithCurrentText()
            TKMS_VACIO.UpdateValueWithCurrentText()
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            For k = 1 To FgG.Rows.Count - 1
                If String.IsNullOrEmpty(FgG(k, 3)) Then
                    z += 1
                End If
            Next

            If z > 0 Then
                MsgBox("Por favor capture el concepto del gasto en gastos e viaje")
                BORRA_FACTURA(CVE_DOC)
                TAB1.SelectedIndex = 2
                Return
            End If


            If FACTURA_UNO_O_MULT = "SEFACTURA" Then

            ElseIf FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Then

            ElseIf FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                If TNETO_O2.Value = 0 Then

                    BORRA_FACTURA(CVE_DOC)
                    MsgBox("Por favor capture el abono del viaje")
                    Return
                End If
            End If

            Dim EXIST_FOLIO As Boolean = False, VIAJE_LOC As String = ""

            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then

                If FACTURA_UNO_O_MULT = "SEFACTURA" Then

                    If ESCENARIO = 2 Then
                        If CboSerieFG.SelectedIndex = -1 Or CboSerieFG.Text = "STAND." Then
                            SERIE_FV = ""
                        Else
                            SERIE_FV = CboSerieFG.Text
                        End If
                        FOLIO_FV = TFOLIOFG.Value
                    Else
                        If CboSerieFactura.SelectedIndex = -1 Or CboSerieFactura.Text = "STAND." Then
                            SERIE_FV = ""
                        Else
                            SERIE_FV = CboSerieFactura.Text
                        End If
                        FOLIO_FV = TFOLIO.Value
                    End If

                    If FOLIO_FV > 0 AndAlso SERIE_FV <> "" Then

                        If DOC_NEW Then
                            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE 
                                WHERE SERIE = '" & SERIE_FV & "' AND FOLIO = " & FOLIO_FV
                        Else
                            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE 
                                WHERE SERIE = '" & SERIE_FV & "' AND FOLIO = " & FOLIO_FV & " AND CVE_VIAJE <> '" & LtCVE_VIAJE.Text & "'"
                        End If

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    VIAJE_LOC = dr("CVE_VIAJE")
                                    EXIST_FOLIO = True
                                End If
                            End Using
                        End Using


                        If EXIST_FOLIO Then
                            MsgBox("La serie-folio se encuentra asignado en el viaje " & VIAJE_LOC)
                            LtDisponible.Text = "NO DISPONIBLE"

                            BORRA_FACTURA(CVE_DOC)

                            Return
                        End If

                    Else
                        BORRA_FACTURA(CVE_DOC)

                        MsgBox("1. Por favor capture el folio de la factura")
                        Return
                    End If
                Else

                    If ESCENARIO = 2 Then
                        If CboSerieFG.SelectedIndex = -1 Or CboSerieFG.Text = "STAND." Then
                            SERIE_FV = ""
                        Else
                            SERIE_FV = CboSerieFG.Text
                        End If
                        FOLIO_FV = TFOLIOFG.Value
                    Else
                        If CboSerieFactura.SelectedIndex = -1 Or CboSerieFactura.Text = "STAND." Then
                            SERIE_FV = ""
                        Else
                            SERIE_FV = CboSerieFactura.Text
                        End If
                        FOLIO_FV = TFOLIO.Value
                    End If

                    If FOLIO_FV > 0 AndAlso SERIE_FV <> "" Then

                        If DOC_NEW Then
                            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE 
                                WHERE SERIE = '" & SERIE_FV & "' AND FOLIO = " & FOLIO_FV
                        Else
                            SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE 
                                SERIE = '" & SERIE_FV & "' AND FOLIO = " & FOLIO_FV & " AND 
                                CVE_VIAJE <> '" & LtCVE_VIAJE.Text & "'"
                        End If

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    VIAJE_LOC = dr("CVE_VIAJE")
                                    EXIST_FOLIO = True
                                End If
                            End Using
                        End Using

                        CVE_DOC = SERIE_FV & FOLIO_FV

                        If EXIST_FOLIO Then
                            MsgBox("La serie-folio se encuentra asignado en el viaje " & VIAJE_LOC)
                            LtDisponible.Text = "NO DISPONIBLE"

                            BORRA_FACTURA(CVE_DOC)
                            Return
                        End If


                    Else
                        BORRA_FACTURA(CVE_DOC)
                        MsgBox("2. Por favor capture el folio de la factura")
                        Return
                    End If
                End If
            Else
                SERIE_FV = CboSerieFactura.Text
                FOLIO_FV = TFOLIO.Value
            End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TORDEN_DE.Focus()

            FLETE = TFLETE.Value

            If LtTipoViaje.Text = "Full" Then
                TIPO_UNI = 1
            Else
                TIPO_UNI = 0
            End If

            If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                MsgBox("El tractor no debe quedar vacío")
                Return
            End If

            If Not Valida_Conexion() Then
                Return
            End If

            CVE_OBS = 0

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If CboConc1.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc1.Items(CboConc1.SelectedIndex))
            Else
                CVE_COBRO = 0
            End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If LtTipoViaje.Text = "Full" Then
            TIPO_UNI = 1
        Else
            TIPO_UNI = 0
        End If

        If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text.Trim) Then
            CVE_ESQIMPU = Convert.ToInt16(TCVE_ESQIMPU.Text.Trim)
        Else
            CVE_ESQIMPU = 0
        End If

        If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
            If CVE_ESQIMPU <= 0 Then
                MsgBox("Existe un problema con el esquema de impuestos, verifique en la pestaña ""Importes"" que tenga asignado su esquema")
                Return
            End If
        End If

        CVE_VIAJE = LtCVE_VIAJE.Text


        If DOC_NEW Then
            SQLJ = "INSERT INTO GCASIGNACION_VIAJE (CVE_VIAJE, FECHA, FECHA_CARGA, FECHA_DESCARGA, STATUS, TIPO_UNI, TIPO_VIAJE, 
                CVE_OPER, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, CVE_ST_VIA, CVE_ST_UNI, RECOGER_EN, ENTREGAR_EN, 
                CLAVE_O, CLAVE_D, CVE_TAB, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_TAB_VIAJE, TIPO_CAMBIO, TIPO_CAMBIO_LEYENDA, 
                FECHAELAB, UUID, CLIENTE, CVE_MONED, VOLUMEN_PESO, FLETE, SUBTOTAL, IVA, RETENCION, NETO, REM_CARGA, CANT, 
                CVE_ESQIMPU, CVE_COBRO, IMPORTE_CONCEP, PRECIO_VIAJE_TONE, CVE_PRODSERV, CVE_UNIDAD, SERIE, FOLIO, 
                TIPO_FACTURACION, CALLE_FISCAL, CALLE1, CALLE2, FECHA_REAL_CARGA, FECHA_REAL_DESCARGA, KMS_VACIO, COMPLEMENTO,
                VIAJE_COMPLE, OBS_COMPLE) 
                VALUES (
                @CVE_VIAJE, @FECHA, @FECHA_CARGA, @FECHA_DESCARGA, 'A', @TIPO_UNI, @TIPO_VIAJE, @CVE_OPER, @CVE_TRACTOR, @CVE_TANQUE1,  
                @CVE_TANQUE2, @CVE_DOLLY, '1', '1', @RECOGER_EN, @ENTREGAR_EN, @CLAVE_O, @CLAVE_D, @CVE_TAB, @ORDEN_DE, @EMBARQUE, 
                @CARGA_ANTERIOR, @CVE_TAB_VIAJE, @TIPO_CAMBIO, @TIPO_CAMBIO_LEYENDA, GETDATE(), NEWID(), @CLIENTE, @CVE_MONED, 
                @VOLUMEN_PESO, @FLETE, @SUBTOTAL, @IVA, @RETENCION, @NETO, @REM_CARGA, @CANT, @CVE_ESQIMPU, @CVE_COBRO, 
                @IMPORTE_CONCEP, @PRECIO_VIAJE_TONE, @CVE_PRODSERV, @CVE_UNIDAD, @SERIE, @FOLIO, @TIPO_FACTURACION,
                @CALLE_FISCAL, @CALLE1, @CALLE2, @FECHA_REAL_CARGA, @FECHA_REAL_DESCARGA, @KMS_VACIO, @COMPLEMENTO,
                @VIAJE_COMPLE, @OBS_COMPLE) "
        Else
            SQLJ = "UPDATE GCASIGNACION_VIAJE SET TIPO_UNI = @TIPO_UNI, TIPO_VIAJE = @TIPO_VIAJE, CVE_OPER = @CVE_OPER, 
                CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, CVE_DOLLY = @CVE_DOLLY, 
                RECOGER_EN = @RECOGER_EN, ENTREGAR_EN = @ENTREGAR_EN, CLAVE_O = @CLAVE_O, CLAVE_D  = @CLAVE_D, CVE_TAB = @CVE_TAB, 
                ORDEN_DE = @ORDEN_DE, EMBARQUE = @EMBARQUE, CARGA_ANTERIOR = @CARGA_ANTERIOR, CVE_TAB_VIAJE = @CVE_TAB_VIAJE, 
                FECHA_CARGA = @FECHA_CARGA, FECHA_DESCARGA = @FECHA_DESCARGA, CLIENTE = @CLIENTE, CVE_MONED = @CVE_MONED, 
                VOLUMEN_PESO = @VOLUMEN_PESO, FLETE = @FLETE, SUBTOTAL = @SUBTOTAL, IVA = @IVA, RETENCION = @RETENCION, NETO = @NETO, 
                REM_CARGA = @REM_CARGA, CVE_ESQIMPU = @CVE_ESQIMPU, CVE_COBRO = @CVE_COBRO, IMPORTE_CONCEP = @IMPORTE_CONCEP, 
                PRECIO_VIAJE_TONE = @PRECIO_VIAJE_TONE, CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD, SERIE = @SERIE, 
                TIPO_FACTURACION = @TIPO_FACTURACION, FOLIO = @FOLIO, TIPO_CAMBIO_LEYENDA = @TIPO_CAMBIO_LEYENDA, 
                TIPO_CAMBIO = @TIPO_CAMBIO, CALLE_FISCAL = @CALLE_FISCAL, CALLE1 = @CALLE1, CALLE2 = @CALLE2,
                FECHA_REAL_CARGA = @FECHA_REAL_CARGA, FECHA_REAL_DESCARGA = @FECHA_REAL_DESCARGA, KMS_VACIO = @KMS_VACIO,
                COMPLEMENTO = @COMPLEMENTO, VIAJE_COMPLE = @VIAJE_COMPLE, OBS_COMPLE = @OBS_COMPLE
                WHERE CVE_VIAJE = @CVE_VIAJE "
        End If

        For k = 1 To 5
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQLJ
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = CVE_VIAJE
                    cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now

                    cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                    cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value

                    cmd.Parameters.Add("@FECHA_REAL_CARGA", SqlDbType.DateTime).Value = FRC.Value
                    cmd.Parameters.Add("@FECHA_REAL_DESCARGA", SqlDbType.DateTime).Value = FRD.Value

                    cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = TIPO_UNI
                    cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(RadCargado.Checked, 1, 0)
                    cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                    cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                    cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                    cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                    cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = TCVE_DOLLY.Text
                    cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                    cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                    cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                    cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                    cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                    cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                    cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                    cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                    cmd.Parameters.Add("@CVE_MONED", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_MON.Text)
                    cmd.Parameters.Add("@VOLUMEN_PESO", SqlDbType.Float).Value = TVOLUMEN_PESO.Value
                    cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = FLETE
                    cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = TSUB_TOTAL.Value
                    cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = TIVA.Value
                    cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = TRET.Value
                    cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = TNETO.Value
                    cmd.Parameters.Add("@REM_CARGA", SqlDbType.SmallInt).Value = REM_CARGA
                    cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.SmallInt).Value = CVE_ESQIMPU
                    cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                    cmd.Parameters.Add("@IMPORTE_CONCEP", SqlDbType.Float).Value = TIMPORTE_CONCEP.Value
                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                    cmd.Parameters.Add("@PRECIO_VIAJE_TONE", SqlDbType.SmallInt).Value = IIf(RadPrecioXViaje.Checked, 0, 1)
                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV.Text
                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD.Text
                    If ESCENARIO = 2 Then
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = CboSerieFG.Text
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = TFOLIOFG.Value
                    Else
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = CboSerieFactura.Text
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = TFOLIO.Value
                    End If
                    cmd.Parameters.Add("@TIPO_FACTURACION", SqlDbType.SmallInt).Value = TIPO_FACTURACION
                    cmd.Parameters.Add("@TIPO_CAMBIO_LEYENDA", SqlDbType.VarChar).Value = TTIPO_CAMBIO_LEYENDA.Text
                    cmd.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Float).Value = TTIPO_CAMBIO.Value
                    cmd.Parameters.Add("@CALLE_FISCAL", SqlDbType.SmallInt).Value = IIf(ChCalleFiscal.Checked, 1, 0)
                    cmd.Parameters.Add("@CALLE1", SqlDbType.VarChar).Value = LtCalle1.Text
                    cmd.Parameters.Add("@CALLE2", SqlDbType.VarChar).Value = LtCalle2.Text
                    cmd.Parameters.Add("@KMS_VACIO", SqlDbType.Float).Value = TKMS_VACIO.Value

                    cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.SmallInt).Value = IIf(ChComplemento.Checked, 1, 0)
                    cmd.Parameters.Add("@VIAJE_COMPLE", SqlDbType.VarChar).Value = TVIAJE_COMPLE.Text
                    cmd.Parameters.Add("@OBS_COMPLE", SqlDbType.VarChar).Value = TOBS_COMPLE.Text

                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If

                    'GRABAR
                    If ESCENARIO = 2 Then

                        For j = 1 To FgViajes.Rows.Count - 1

                            If FgViajes(j, 1) Then
                                SQL = "UPDATE GCASIGNACION_VIAJE SET CVE_DOC = '" & CVE_DOC & "', FACTURADO = 'S', TIPO_FACTURACION = " & TIPO_FACTURACION & ",
                                     SERIE = '" & CboSerieFG.Text & "', FOLIO = " & TFOLIOFG.Value & " WHERE CVE_VIAJE = '" & FgViajes(j, 2) & "'"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                SQL = "UPDATE GCMERCANCIAS SET CVE_DOC = '" & CVE_DOC & "' WHERE CVE_VIAJE = '" & FgViajes(j, 2) & "'"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Next
                    End If

                    If ESCENARIO = 3 Then
                        If FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                            Try
                                If TSUBT_O2.Value > 0 Then
                                    SQL = "INSERT INTO GCASIGNACION_VIAJE_ABONOS (CVE_VIAJE, STATUS, CVE_DOC, NUM_PAR, SUBTOTAL, IVA, RET, NETO, FECHA, FECHAELAB) 
                                        VALUES ('" & CVE_VIAJE & "','F','" & CVE_DOC & "',
                                        ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCASIGNACION_VIAJE_ABONOS WHERE CVE_VIAJE = '" & CVE_VIAJE & "'),1)," &
                                        Math.Round(TSUBT_O2.Value, 6) & "," & Math.Round(TIVA_O2.Value, 6) & "," & Math.Round(TRET_O2.Value, 6) & "," &
                                        Math.Round(TNETO_O2.Value, 6) & ",CONVERT(varchar, GETDATE(), 112),
                                        GETDATE())"

                                    returnValue2 = EXECUTE_QUERY_NET(SQL)
                                    If returnValue2 = "Else" Then
                                        BACKUPTXT("ERROR ASIGNACION_VIAJE", SQL)
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If

                    If TCLIENTE.Text.Trim.Length > 0 Then
                        SQL = "UPDATE CLIE" & Empresa & " SET METODODEPAGO = '" & TMETODODEPAGO.Text & "', 
                            FORMADEPAGOSAT = '" & TFORMADEPAGOSAT.Text & "', 
                            USO_CFDI = '" & TUSO_CFDI.Text & "',
                            DIASCRED = " & TDIAS_CRED.Value & "
                            WHERE CLAVE = '" & TCLIENTE.Text & "'"
                        EXECUTE_QUERY_NET(SQL)
                    End If

                    If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then

                        SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_FV & "
                              WHERE SERIE = '" & IIf(SERIE_FV = "", "STAND.", SERIE_FV) & "' AND TIP_DOC = 'F'"
                        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                        If ESCENARIO = 2 Then

                            For w = 1 To FgViajes.Rows.Count - 1
                                If FgViajes(w, 1) Then
                                    SQL = "UPDATE GCASIGNACION_VIAJE SET 
                                    SERIE = '" & SERIE_FV & "', 
                                    FOLIO = " & FOLIO_FV & ", 
                                    CVE_DOC = '" & CVE_DOC & "',
                                    FACTURADO = 'S' 
                                    WHERE CVE_VIAJE = '" & FgViajes(w, 2) & "'"
                                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                End If
                            Next
                        Else
                            SQL = "UPDATE GCASIGNACION_VIAJE SET 
                                SERIE = '" & SERIE_FV & "', 
                                FOLIO = " & FOLIO_FV & ", 
                                CVE_DOC = '" & CVE_DOC & "',
                                FACTURADO = 'S' 
                                WHERE CVE_VIAJE = '" & CVE_VIAJE & "'"
                            ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                        End If

                        If FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                            'CUEN_M(CVE_VIAJE, TCLIENTE.Text, TNETO_O2.Value, "", 0)
                            'CUEN_DET(CVE_VIAJE, CVE_VIAJE, TCLIENTE.Text, TNETO_O.Value, 10, "")
                        End If
                    End If

                End Using
                SeGrabo = True

                LtCVE_VIAJE.Text = CVE_VIAJE

                Exit For
            Catch ex As SqlException
                ' Log the original exception here
                For Each sqlError As SqlError In ex.Errors

                    BITACORASQL("sqlError.Number :" & sqlError.Number & ", sqlError:" & sqlError.ToString)

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
                        MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                Threading.Thread.Sleep(3000)
                MsgBox("Problemas de comunicación vuelva a intentarlo por favor")
                Return
            End If
        Next
        'FIN FOR DE GRABADO POR SI HAY ERROR
        If SeGrabo Then
            FgA.FinishEditing()

            GRABAR_GASTOS(CVE_VIAJE)
            GRABAR_VALES(CVE_VIAJE)

            GRABAR_GCMERCANCIAS(CVE_VIAJE, CVE_DOC)
            GRABAR_CARGA(CVE_VIAJE, CVE_DOC)

            GRABAR_GASTOS_CAMPOS_ADIC(CVE_VIAJE)
            GRABAR_CONCEPTOS_PARTIDAS(CVE_VIAJE)

            SeDesplega = True
            Try
                If LTractor.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TRACTOR.Text <> LTractor.Tag Then
                        GRABA_BITA(CVE_VIAJE, "", 0, "V", "Se cambio la unidad " & TCVE_TRACTOR.Text & " por " & LTractor.Tag, LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If LTanque1.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TANQUE1.Text <> LTanque1.Tag Then
                        GRABA_BITA(CVE_VIAJE, "", 0, "V", "Se cambio la unidad " & TCVE_TANQUE1.Text & " por " & LTanque1.Tag, LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If LTanque2.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_TANQUE2.Text <> LTanque2.Tag Then
                        GRABA_BITA(CVE_VIAJE, "", 0, "V", "Se cambio la unidad " & TCVE_TANQUE2.Text & " por " & LTanque2.Tag, LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If LDolly.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_DOLLY.Text <> LDolly.Tag Then
                        GRABA_BITA(CVE_VIAJE, "", 0, "V", "Se cambio la unidad " & TCVE_DOLLY.Text & " por " & LDolly.Tag,
                                  LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If TCLAVE_O.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_O.Tag <> TCLAVE_O.Text Then
                        GRABA_BITA("", "", 0, "V", "Se cambio el cliente operativo " & TCLAVE_O.Tag & " por " & TCLAVE_O.Text, LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If TCLAVE_D.Tag.ToString.Trim.Length > 0 Then
                    If TCLAVE_D.Tag <> TCLAVE_D.Text Then
                        GRABA_BITA("", "", 0, "V", "Se cambio el cliente operativo " & TCLAVE_D.Tag & " por " & TCLAVE_D.Text, LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If TRECOGER_EN.Tag.ToString.Trim.Length > 0 Then
                    If TRECOGER_EN.Tag <> TRECOGER_EN.Text Then
                        GRABA_BITA("", "", 0, "V", "Se cambio recoger en " & TRECOGER_EN.Tag & " por " & TRECOGER_EN.Text,
                                           LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If TENTREGAR_EN.Tag.ToString.Trim.Length > 0 Then
                    If TENTREGAR_EN.Tag <> TENTREGAR_EN.Text Then
                        GRABA_BITA("", "", 0, "V", "Se cambio entregar en " & TENTREGAR_EN.Tag & " por " & TENTREGAR_EN.Text,
                                           LtCVE_VIAJE.Text, "", "FtoF")
                    End If
                End If
                If TCVE_OPER.Tag.ToString.Trim.Length > 0 Then
                    If TCVE_OPER.Tag <> TCVE_OPER.Text Then
                        GRABA_BITA("", "", 0, "V", "Se cambio el operador " & TCVE_OPER.Tag & " por " & TCVE_OPER.Text,
                                           LtCVE_VIAJE.Text, "", "FtoF")
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
            LtCVE_VIAJE.Text = CVE_VIAJE


            If ESCENARIO = 2 Then
                MsgBox("Los viajes se grabaron correctamente")
            Else
                MsgBox("El viaje " & CVE_VIAJE & " se grabo correctamente")
            End If

            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                If ExisteTab("Asignación de Viajes") Then
                    FrmAsignacionViaje.DESPLEGAR()
                End If

                TAB1.SelectedIndex = 0
            End If
        Else


            MsgBox("No se logro grabar la asignación de viaje")
        End If
    End Sub
    Sub BORRA_FACTURA(CVE_DOC)
        SQL = "DELETE FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
        Debug.Print("")
        SQL = "DELETE FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
        ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

    End Sub

    Sub GUARDAR_VIAJE_AUTOMATICO()
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim FLETE As Decimal, REM_CARGA As Integer, CANT As Decimal, DETEC_ERROR_VIOLATION_KEY As Boolean = False
        Dim CVE_VIAJE As String, CVE_OBS As Long, TIPO_UNI As Integer, z As Integer = 0, SeGrabo As Boolean = False
        Dim SERIE_FV As String = "", FOLIO_FV As Long, CVE_COBRO As Integer, CVE_DOC As String = "", CVE_ESQIMPU As Integer

        Try
            TFLETE.UpdateValueWithCurrentText()
            TIMPORTE_CONCEP.UpdateValueWithCurrentText()
            TFOLIO.UpdateValueWithCurrentText()
            TSUBT_O.UpdateValueWithCurrentText()
            TIVA_O.UpdateValueWithCurrentText()
            TRET_O.UpdateValueWithCurrentText()
            TNETO_O.UpdateValueWithCurrentText()
            TDIAS_CRED.UpdateValueWithCurrentText()
            TTIPO_CAMBIO.UpdateValueWithCurrentText()
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            FLETE = TFLETE.Value

            If LtTipoViaje.Text = "Full" Then
                TIPO_UNI = 1
            Else
                TIPO_UNI = 0
            End If

            'If TOBS.Text.Trim.Length > 0 Then
            'CVE_OBS = Val(TOBS.Tag.ToString)
            'CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TOBS.Text)
            'Else
            CVE_OBS = 0
            'End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If CboConc1.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc1.Items(CboConc1.SelectedIndex))
            Else
                CVE_COBRO = 0
            End If
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If LtTipoViaje.Text = "Full" Then
            TIPO_UNI = 1
        Else
            TIPO_UNI = 0
        End If

        GUARDAR_VIAJE()

        FrmFGCopiandoViajes.Fg.Rows.Count = 1

        For j = 1 To VIAJES_A_COPIAR

            If Valida_Conexion() Then

                FOLIO_FV = GET_MAX_TRY("GCASIGNACION_VIAJE", "CVE_VIAJE")

                CVE_VIAJE = FOLIO_FV

                SQL = "INSERT INTO GCASIGNACION_VIAJE (CVE_VIAJE, FECHA, FECHA_CARGA, FECHA_DESCARGA, STATUS, TIPO_UNI, TIPO_VIAJE, 
                    CVE_OPER, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, CVE_ST_VIA, CVE_ST_UNI, RECOGER_EN, ENTREGAR_EN, 
                    CLAVE_O, CLAVE_D, CVE_TAB, ORDEN_DE, EMBARQUE, CARGA_ANTERIOR, CVE_TAB_VIAJE, TIPO_CAMBIO, TIPO_CAMBIO_LEYENDA, 
                    FECHAELAB, UUID, CLIENTE, CVE_MONED, VOLUMEN_PESO, FLETE, SUBTOTAL, IVA, RETENCION, NETO, REM_CARGA, CANT, 
                    CVE_ESQIMPU, CVE_COBRO, IMPORTE_CONCEP, PRECIO_VIAJE_TONE, CVE_PRODSERV, CVE_UNIDAD, SERIE, FOLIO, 
                    TIPO_FACTURACION, CALLE_FISCAL, CALLE1, CALLE2) 
                    VALUES (
                    @CVE_VIAJE, @FECHA, @FECHA_CARGA, @FECHA_DESCARGA, 'A', @TIPO_UNI, @TIPO_VIAJE, @CVE_OPER, @CVE_TRACTOR, @CVE_TANQUE1,  
                    @CVE_TANQUE2, @CVE_DOLLY, '1', '1', @RECOGER_EN, @ENTREGAR_EN, @CLAVE_O, @CLAVE_D, @CVE_TAB, @ORDEN_DE, @EMBARQUE, 
                    @CARGA_ANTERIOR, @CVE_TAB_VIAJE, @TIPO_CAMBIO, @TIPO_CAMBIO_LEYENDA, GETDATE(), NEWID(), @CLIENTE, @CVE_MONED, 
                    @VOLUMEN_PESO, @FLETE, @SUBTOTAL, @IVA, @RETENCION, @NETO, @REM_CARGA, @CANT, @CVE_ESQIMPU, @CVE_COBRO, 
                    @IMPORTE_CONCEP, @PRECIO_VIAJE_TONE, @CVE_PRODSERV, @CVE_UNIDAD, @SERIE, @FOLIO, @TIPO_FACTURACION,
                    @CALLE_FISCAL, @CALLE1, @CALLE2)"

                For k = 1 To 5
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = CVE_VIAJE
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                            cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                            cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                            cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = TIPO_UNI
                            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(RadCargado.Checked, 1, 0)
                            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                            cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                            cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                            cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                            cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = TCVE_DOLLY.Text
                            cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                            cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                            cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                            cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                            cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                            cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                            cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                            cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                            cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                            cmd.Parameters.Add("@CVE_MONED", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_MON.Text)
                            cmd.Parameters.Add("@VOLUMEN_PESO", SqlDbType.SmallInt).Value = TVOLUMEN_PESO.Value
                            cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = FLETE
                            cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = TSUB_TOTAL.Value
                            cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = TIVA.Value
                            cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = TRET.Value
                            cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = TNETO.Value
                            cmd.Parameters.Add("@REM_CARGA", SqlDbType.SmallInt).Value = REM_CARGA
                            cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.SmallInt).Value = CVE_ESQIMPU
                            cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                            cmd.Parameters.Add("@IMPORTE_CONCEP", SqlDbType.Float).Value = TIMPORTE_CONCEP.Value
                            cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                            cmd.Parameters.Add("@PRECIO_VIAJE_TONE", SqlDbType.SmallInt).Value = IIf(RadPrecioXViaje.Checked, 0, 1)
                            cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV.Text
                            cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD.Text
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = ""
                            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = 0
                            cmd.Parameters.Add("@TIPO_FACTURACION", SqlDbType.SmallInt).Value = TIPO_FACTURACION
                            cmd.Parameters.Add("@TIPO_CAMBIO_LEYENDA", SqlDbType.VarChar).Value = TTIPO_CAMBIO_LEYENDA.Text
                            cmd.Parameters.Add("@TIPO_CAMBIO", SqlDbType.Float).Value = TTIPO_CAMBIO.Value

                            cmd.Parameters.Add("@CALLE_FISCAL", SqlDbType.SmallInt).Value = IIf(ChCalleFiscal.Checked, 1, 0)
                            cmd.Parameters.Add("@CALLE1", SqlDbType.VarChar).Value = LtCalle1.Text
                            cmd.Parameters.Add("@CALLE2", SqlDbType.VarChar).Value = LtCalle2.Text

                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
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
                    End If
                Next
                'FIN FOR DE GRABADO POR SI HAY ERROR
                If SeGrabo Then

                    FgA.FinishEditing()

                    GRABAR_GASTOS(CVE_VIAJE)
                    GRABAR_VALES(CVE_VIAJE)

                    GRABAR_GCMERCANCIAS(CVE_VIAJE, CVE_DOC)
                    GRABAR_CARGA(CVE_VIAJE, CVE_DOC)

                    GRABAR_GASTOS_CAMPOS_ADIC(CVE_VIAJE)
                    GRABAR_CONCEPTOS_PARTIDAS(CVE_VIAJE)

                    GRABA_BITA(CVE_VIAJE, "", 0, "V", "Viaje copiado desde el viaje " & LtCVE_VIAJE.Text, LtCVE_VIAJE.Text, "", "Copy")
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCFOLIOS SET ULT_DOC = " & FOLIO_A & " WHERE TIP_DOC = 'A' AND 
                             SERIE = '" & IIf(SERIE_A = "" Or SERIE_A = "STAND.", "STAND.", SERIE_A) & "'"
                        cmd2.CommandText = SQL
                        cmd2.ExecuteNonQuery()
                    End Using

                    FrmFGCopiandoViajes.Fg.AddItem("" & vbTab & CVE_VIAJE & vbTab & "Copiado")
                End If
            End If
        Next

        FrmFGCopiandoViajes.ShowDialog()

    End Sub
    Sub GRABAR_GCMERCANCIAS(FCVE_VIAJE As String, Optional FCVE_DOC As String = "")
        Dim NUM_PAR As Integer = 0
        Dim CANT As Decimal, PESO As Decimal, VALOR_MERCANCIA As Decimal, DETEC_ERROR_VIOLATION_KEY As Boolean = False
        Dim CVE_UNID As String, CVE_PRODSER As String, MAT_PELIGROSO As String, CVE_MAT_PELIGROSO As String

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            SQL = "DELETE FROM GCMERCANCIAS WHERE CVE_VIAJE = '" & FCVE_VIAJE & "'"
            If EXECUTE_QUERY_NET(SQL) Then

            End If

            For k = 1 To Fg.Rows.Count - 1

                CANT = 0
                If Not IsNothing(Fg(k, 1)) Then
                    If IsNumeric(Fg(k, 1)) Then
                        CANT = Convert.ToDecimal(Fg(k, 1))
                    End If
                End If
                If IsNothing(Fg(k, 2)) Then
                    CVE_UNID = ""
                Else
                    CVE_UNID = Fg(k, 2)
                End If
                If IsNothing(Fg(k, 5)) Then
                    CVE_PRODSER = ""
                Else
                    CVE_PRODSER = Fg(k, 5)
                End If

                NUM_PAR += 1

                If CANT > 0 Then
                    For j = 1 To 3
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SET ansi_warnings OFF
                                    IF EXISTS (SELECT CVE_VIAJE FROM GCMERCANCIAS WHERE CVE_VIAJE = @CVE_VIAJE AND NUM_PAR = @NUM_PAR)
                                    UPDATE GCMERCANCIAS SET CANT = @CANT, ID_UNIDAD = @ID_UNIDAD, DESC_UNIDAD = @DESC_UNIDAD, 
                                    ID_MERCANCIA = @ID_MERCANCIA, DESCR_MERCANCIA = @DESCR_MERCANCIA, MAT_PELIGROSO = @MAT_PELIGROSO, 
                                    CVE_MAT_PELIGROSO = @CVE_MAT_PELIGROSO, ID_EMBALAJE = @ID_EMBALAJE, DESC_EMBALAJE = @DESC_EMBALAJE, 
                                    PESO = @PESO, VALOR_MERCANCIA = @VALOR_MERCANCIA, MONEDA = @MONEDA, ID_FRACC_ARANCELARIA = @ID_FRACC_ARANCELARIA, 
                                    UUID_COM_EXT = @UUID_COM_EXT, CVE_DOC = @CVE_DOC
                                    OUTPUT INSERTED.NUM_PAR
                                    WHERE CVE_VIAJE = @CVE_VIAJE AND NUM_PAR = @NUM_PAR
                                    ELSE
                                    INSERT INTO GCMERCANCIAS (CVE_VIAJE, NUM_PAR, CVE_DOC, CANT, ID_UNIDAD, DESC_UNIDAD, ID_MERCANCIA, DESCR_MERCANCIA, 
                                    MAT_PELIGROSO, CVE_MAT_PELIGROSO, ID_EMBALAJE, DESC_EMBALAJE, PESO, VALOR_MERCANCIA, MONEDA, ID_FRACC_ARANCELARIA, 
                                    UUID_COM_EXT) 
                                    OUTPUT Inserted.NUM_PAR VALUES (@CVE_VIAJE, ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCMERCANCIAS),1), @CVE_DOC, @CANT, @ID_UNIDAD, 
                                    @DESC_UNIDAD, @ID_MERCANCIA, @DESCR_MERCANCIA, @MAT_PELIGROSO, @CVE_MAT_PELIGROSO, @ID_EMBALAJE, @DESC_EMBALAJE, 
                                    @PESO, @VALOR_MERCANCIA, @MONEDA, @ID_FRACC_ARANCELARIA, @UUID_COM_EXT)"

                                If Not IsNothing(Fg(k, 0)) Then
                                    If IsNumeric(Fg(k, 0)) Then
                                        NUM_PAR = Fg(k, 0)
                                    End If
                                End If

                                PESO = 0
                                If Not IsNothing(Fg(k, 14)) Then
                                    If IsNumeric(Fg(k, 14)) Then
                                        PESO = Convert.ToDecimal(Fg(k, 14))
                                    End If
                                End If
                                VALOR_MERCANCIA = 0
                                If Not IsNothing(Fg(k, 15)) Then
                                    If IsNumeric(Fg(k, 15)) Then
                                        VALOR_MERCANCIA = Convert.ToDecimal(Fg(k, 15))
                                    End If
                                End If

                                MAT_PELIGROSO = "No"
                                If Not IsNothing(Fg(k, 8)) Then
                                    If Fg(k, 8) Then
                                        MAT_PELIGROSO = "Si"
                                    End If
                                End If
                                CVE_MAT_PELIGROSO = ""
                                If Not IsNothing(Fg(k, 9)) Then
                                    CVE_MAT_PELIGROSO = Fg(k, 9)
                                Else
                                    Debug.Print("")
                                End If


                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = FCVE_DOC
                                cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                                cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 2)), "", Fg(k, 2))
                                cmd.Parameters.Add("@DESC_UNIDAD", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 4)), "", Fg(k, 4))
                                cmd.Parameters.Add("@ID_MERCANCIA", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 5)), "", Fg(k, 5))
                                cmd.Parameters.Add("@DESCR_MERCANCIA", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 7)), "", Fg(k, 7))
                                cmd.Parameters.Add("@MAT_PELIGROSO", SqlDbType.VarChar).Value = MAT_PELIGROSO
                                cmd.Parameters.Add("@CVE_MAT_PELIGROSO", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 9)), "", Fg(k, 9))
                                cmd.Parameters.Add("@ID_EMBALAJE", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 11)), "", Fg(k, 11))
                                cmd.Parameters.Add("@DESC_EMBALAJE", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 13)), "", Fg(k, 13))
                                cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = PESO
                                cmd.Parameters.Add("@VALOR_MERCANCIA", SqlDbType.Float).Value = VALOR_MERCANCIA
                                cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 16)), "", Fg(k, 16))
                                cmd.Parameters.Add("@ID_FRACC_ARANCELARIA", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 18)), "", Fg(k, 18))
                                cmd.Parameters.Add("@UUID_COM_EXT", SqlDbType.VarChar).Value = IIf(IsNothing(Fg(k, 19)), "", Fg(k, 19))

                                ReturnValueLong = cmd.ExecuteScalar()
                                If Not IsNothing(ReturnValueLong) Then
                                    If ReturnValueLong > 0 Then
                                        Fg(k, 21) = ReturnValueLong
                                        Exit For
                                    End If
                                End If
                            End Using
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
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                        If DETEC_ERROR_VIOLATION_KEY Then
                            NUM_PAR += 1
                        End If
                    Next
                End If

            Next

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CARGA(FCVE_VIAJE As String, FCVE_DOC As String)

        Try
            Dim CANT As Decimal, EMBALAJE As String, CARGA As String, CONTIENE As String
            Dim PESO As Decimal, VOLUMEN As Decimal, PESO_ESTIMADO As Decimal, PEDIMENTO As String, NUM_PAR As Integer = 1

            SQL = "DELETE FROM GCCARGA WHERE CVE_VIAJE = '" & FCVE_VIAJE & "'"

            If EXECUTE_QUERY_NET(SQL) Then
                Debug.Print(ReturnValueLong)
            End If

            For k = 1 To FgCarga.Rows.Count - 1

                Try
                    If Not IsDBNull(FgCarga(k, 1)) AndAlso Not IsNothing(FgCarga(k, 1)) Then
                        CANT = FgCarga(k, 1)
                    Else
                        CANT = 0
                    End If
                    If Not IsDBNull(FgCarga(k, 2)) AndAlso Not IsNothing(FgCarga(k, 2)) Then
                        EMBALAJE = FgCarga(k, 2)
                    Else
                        EMBALAJE = ""
                    End If
                    If Not IsDBNull(FgCarga(k, 3)) AndAlso Not IsNothing(FgCarga(k, 3)) Then
                        CARGA = FgCarga(k, 3)
                    Else
                        CARGA = ""
                    End If
                    If Not IsDBNull(FgCarga(k, 4)) AndAlso Not IsNothing(FgCarga(k, 4)) Then
                        CONTIENE = FgCarga(k, 4)
                    Else
                        CONTIENE = ""
                    End If
                    If Not IsDBNull(FgCarga(k, 5)) AndAlso Not IsNothing(FgCarga(k, 5)) Then
                        PESO = FgCarga(k, 5)
                    Else
                        PESO = 0
                    End If
                    If Not IsDBNull(FgCarga(k, 6)) AndAlso Not IsNothing(FgCarga(k, 6)) Then
                        VOLUMEN = FgCarga(k, 6)
                    Else
                        VOLUMEN = 0
                    End If
                    If Not IsDBNull(FgCarga(k, 7)) AndAlso Not IsNothing(FgCarga(k, 7)) Then
                        PESO_ESTIMADO = FgCarga(k, 7)
                    Else
                        PESO_ESTIMADO = 0
                    End If
<<<<<<< HEAD
                    If Not IsDBNull(FgCarga(k, 8)) AndAlso Not IsNothing(FgCarga(k, 8)) Then
=======
                    If FgCarga(k, 8) IsNot Nothing Then
>>>>>>> Ultimos Cambios
                        PEDIMENTO = FgCarga(k, 8)
                    Else
                        PEDIMENTO = ""
                    End If


                    SQL = "SET ansi_warnings OFF
                        INSERT INTO GCCARGA (CVE_VIAJE, NUM_PAR, CVE_DOC, CANT, EMBALAJE, CARGA, CONTIENE, 
                        PESO, VOLUMEN, PESO_ESTIMADO, PEDIMENTO) VALUES ('" & FCVE_VIAJE & "','" & NUM_PAR & "','" &
                        FCVE_DOC & "','" & CANT & "','" & EMBALAJE & "','" & CARGA & "','" & CONTIENE & "','" & PESO & "','" &
                        VOLUMEN & "','" & PESO_ESTIMADO & "','" & PEDIMENTO & "')"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                NUM_PAR += 1
                            End If
                        End If
                    End Using

                Catch ex As Exception
                    Bitacora("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
                    MsgBox("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
        End Try
    End Sub

    Private Function GUARDAR_FACTURA() As Boolean

        Dim NUM_MOV As Long, CANT As Decimal, CANT_ORIGINAL As Decimal, CANT_SURTIDA As Decimal
        Dim FOLIO As Integer, CLIENTE As String, CVE_ART As String, EXIST As Decimal
        Dim PRECIO As Decimal, PREC As Decimal, DESC1 As Decimal, DESC2 As Decimal, DESC3 As Decimal, ALMACEN As Integer
        Dim TIP_DOC As String, E_LTPD As Integer, DES_FIN As Decimal, FECHA_ENT As String
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim SUBTOTAL As Decimal, ImporteConDes As Decimal, DES_TOT As Decimal, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, IMPORTE As Decimal, COM_TOT As Decimal
        Dim CVE_DOC As String, STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim FECHA_DOC As String, FECHA_VEN As String, CAN_TOT As Decimal, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal
        Dim CONDICION As String, CVE_OBS As Long = 0, NUM_ALMA As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Integer, TIPCAMB As Decimal, NUM_PAGOS As Long, PRIMERPAGO As Decimal, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String, CVE_BITA As Long
        Dim Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, COM_TOT_PORC As Decimal
        'variables partidas
        Dim NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Integer, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer
        Dim CVE_ESQ As Integer, COST As Decimal, COMI As Decimal, APAR As Decimal, ACT_INV As String, POLIT_APLI As String, TIP_CAM As Decimal
        Dim TIPO_PROD As String, REG_SERIE As Long, TIPO_ELEM As String, TOT_PARTIDA As Decimal, APL_MAN_IEPS As String, MTO_PORC As Integer, MTO_CUOTA As Integer
        Dim CVE_TRACTOR As String, CVE_TANQUE1 As String, CVE_TANQUE2 As String, CVE_DOLLY As String, CLAVE_O As String
        Dim RECOGER_EN As String, CLAVE_D As String, ENTREGAR_EN As String, CVE_OPER As Integer
        'MOVSINV
        Dim FORMADEPAGOSAT As String, UNI_MED As String
        Dim SIGUE As Boolean, FOLIO_ASIGNADO As Boolean
        Dim USO_CFDI As String, METODODEPAGO As String, DETEC_ERROR_VIOLATION_KEY As Boolean, CVE_VIAJE As String
        Dim TIPO_VENTA_LOCAL As String = "F", SERIE_FMV As String, DESCR As String = "", Kfin As Integer, ExisteViaje As Boolean, PESO_CARGA As Decimal
        Dim doc As New XmlDocument()

        If TAB1.SelectedIndex = 5 Then
            TAB1.SelectedIndex = 1
        End If

        If FgCarga.Rows.Count > 1 Then
            If Not IsNothing(FgCarga(1, 5)) Then
                If IsNumeric(FgCarga(1, 5)) Then
                    PESO_CARGA = FgCarga(1, 5)
                Else
                    PESO_CARGA = 0
                End If
            Else
                PESO_CARGA = 0
            End If

        End If
        If PESO_CARGA > 0 Then
            If TVOLUMEN_PESO.Value <> PESO_CARGA Then
                MsgBox("El volumen/peso debe ser igual al peso de la primera carga, verifique por favor")
                Return False
            End If
        End If

        If ESCENARIO = 3 Then
            If TABONO_NETO.Value = 0 And CboSerieFactura.SelectedIndex = -1 And TFOLIO.Value = 0 Then
                MsgBox("Por favor capture el abono")
                Return False
            End If
        End If

        If Not Valida_Conexion() Then
            Return False
        End If

        Try
            TCVE_PRODSERV.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        CLIENTE = TCLIENTE.Text
        CVE_ART = TCVE_PRODSERV.Value
        RFC = LtRFC.Text
        If IsNumeric(TCVE_ESQIMPU.Text.Trim) Then
            CVE_ESQ = Convert.ToInt16(TCVE_ESQIMPU.Text.Trim)
        Else
            CVE_ESQ = 0
        End If
        METODODEPAGO = TMETODODEPAGO.Text : USO_CFDI = TUSO_CFDI.Text : FORMADEPAGOSAT = TFORMADEPAGOSAT.Text
        CVE_VIAJE = LtCVE_VIAJE.Text
        CVE_TRACTOR = TCVE_TRACTOR.Text
        CVE_TANQUE1 = TCVE_TANQUE1.Text
        CVE_TANQUE2 = TCVE_TANQUE2.Text
        CVE_DOLLY = TCVE_DOLLY.Text
        CLAVE_O = TCLAVE_O.Text
        RECOGER_EN = TRECOGER_EN.Text
        CLAVE_D = TCLAVE_D.Text
        ENTREGAR_EN = TENTREGAR_EN.Text
        CVE_OPER = IIf(IsNumeric(TCVE_OPER.Text.Trim), TCVE_OPER.Text.Trim, 0)

        If CVE_ART.Trim.Length = 0 Then
            MsgBox("Por favor capture la clave SAT")
            Return False
        End If

        Try
            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml") Then
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml")

                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_ClaveProdServ='" & CVE_ART & "']")
                If nodeList.Count > 0 Then
                    For Each znode In nodeList
                        DESCR = VarXml(znode, "Descripcion")
                    Next
                End If
            Else
                MsgBox("Catálogo " & Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml inexistente, verifique por favor")
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        FECHA_DOC = FSQL(F1.Value)
        FECHA_ENT = FECHA_DOC

        If ESCENARIO = 2 Or ESCENARIO = 3 Then
            FECHA_VEN = FSQL(DateTime.Parse(F1.Value).AddDays(TDIAS_CRED.Value).ToString())
        Else
            FECHA_VEN = FECHA_DOC
        End If

        If Not Valida_Conexion() Then
            Return False
        End If

        UNI_MED = "" : TIP_CAM = 1 : REG_SERIE = 0 : E_LTPD = 0 : DAT_MOSTR = 0

        CVE_VEND = ""

        If ESCENARIO = 1 Or ESCENARIO = 3 Then
            SERIE_FMV = CboSerieFactura.Text
            FOLIO = TFOLIO.Value

            If FOLIO = 0 AndAlso CboSerieFactura.Text <> "" Then
                MsgBox("Por favor seleccione el folio y la serie de la factura")
                TAB1.SelectedIndex = 5
                CboSerieFactura.Focus()
                Return False
            End If
        Else
            SERIE_FMV = CboSerieFG.Text
            FOLIO = TFOLIOFG.Value

            If FOLIO = 0 AndAlso CboSerieFG.Text <> "" Then
                MsgBox("Por favor seleccione el folio y la serie de la factura")
                TAB1.SelectedIndex = 0
                TFOLIOFG.Focus()
                Return False
            End If
        End If

        CVE_DOC = SERIE_FMV & FOLIO
        SERIE = SERIE_FMV

        If FOLIO = 0 Then
            MsgBox("Por favor seleccione la serie del viaje")
            Return False
        End If

        If EXISTE_VENTA("F", CVE_DOC) Then
            MsgBox("La factura ya existe verifique por favor, seleccione un nuevo folio")
            Return False
        End If

        '███████████████████████████████████████████████████████████████████████████████████████

        '                                 INICIA LA GRABACION DE LAS CABEZAS
        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
        Try

            IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0
            CONDICION = "Contado" : NUM_ALMA = 1 : ACT_CXC = "S" : ACT_COI = "A" : ENLAZADO = "O"
            NUM_PAGOS = 1
            CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
            FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
            DAT_ENVIO = 0 : COM_TOT_PORC = 0 : IMPORTE = 0
            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC = "V" : TIP_DOC_ANT = "" : DOC_ANT = ""
            STATUS = "E" : TIP_CAM = 1 : E_LTPD = 0 : SUBTOTAL = 0


            NUM_MONED = TCVE_MON.Text
            TIPCAMB = TTIPO_CAMBIO.Value

            TIP_DOC_E = "O"
            CONTADO = "S"
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            DESC2 = 0
            DESC3 = 0
            TIP_DOC = "F"
            CANT = 1
            ALMACEN = 1
            EXIST = 0

            'If CVE_ESQ <= 0 Then
            'MsgBox("Existe un problema con el esquema de impuestos, verifique en la pestaña ""Importes"" que tenga asignado su esquema")
            'Return False
            'End If

            Try
                SQL = "SELECT ISNULL(P.IMPUESTO1,0) AS IMPU1, ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3, 
                    ISNULL(P.IMPUESTO4,0) AS IMPU4 
                    FROM IMPU" & Empresa & " P
                    WHERE CVE_ESQIMPU = " & CVE_ESQ
                Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                    cmdF2.CommandText = SQL
                    Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                        If drF2.Read Then
                            IMPU1 = drF2("IMPU1")
                            IMPU2 = drF2("IMPU2")
                            IMPU3 = drF2("IMPU3")
                            IMPU4 = drF2("IMPU4")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("640. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            DESC1 = 0
            Select Case ESCENARIO
                Case 1
                    PRECIO = TSUB_TOTAL.Value
                    PREC = TSUB_TOTAL.Value
                Case 2
                    PRECIO = TSUBT2.Value
                    PREC = TSUBT2.Value
                Case 3
                    PRECIO = TSUBT_O.Value
                    PREC = TSUBT_O.Value
            End Select

            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
            DES_TOT += (CANT * PREC * DESC1 / 100)
            DES_TOT += (DES_TOT * DESC2 / 100)

            TOTIMP1 = 0
            TOTIMP2 = 0

            Select Case ESCENARIO
                Case 1
                    TOTIMP3 = TRET.Value
                    TOTIMP4 = TIVA.Value
                    CAN_TOT = TSUB_TOTAL.Value
                    IMPORTE = TNETO.Value
                Case 2
                    TOTIMP3 = TRETE2.Value
                    TOTIMP4 = TIVA2.Value
                    CAN_TOT = TSUBT2.Value
                    IMPORTE = TNETO2.Value
                Case 3
                    TOTIMP3 = TRET_O2.Value
                    TOTIMP4 = TIVA_O2.Value
                    CAN_TOT = TSUBT_O2.Value
                    IMPORTE = TNETO_O2.Value
            End Select

            'If TOTIMP3 = 0 Or TOTIMP4 = 0 Then
            'MsgBox("Se encontró un problema en los impuestos, verifique por favor")
            'Return False
            'End If

            If IMPORTE = 0 Then
                MsgBox("El importe no puede ser cero, verifique por favor")
                Return False
            End If

            IMP_TOT1 = 0
            IMP_TOT2 = 0
            IMP_TOT3 = TOTIMP3
            IMP_TOT4 = TOTIMP4


            DES_TOT_PORC = DESC1
            COM_TOT = 0
            DES_TOT = DES_TOT
            CVE_PEDI = CVE_VIAJE
            PRIMERPAGO = IMPORTE

            Try '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                Dim RegDuplicado As Boolean = False
                Dim SQLF As String

                SQLF = SQL

                For k = 1 To 5

                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "')
                        INSERT INTO FACTF" & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, IMP_TOT2, DES_FIN, COM_TOT, 
                        ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, 
                        TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, 
                        CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, 
                        TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, CVE_VIAJE,  CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, 
                        CLAVE_O, RECOGER_EN, CLAVE_D, ENTREGAR_EN, CVE_OPER, UUID, VERSION_SINC)  VALUES ('" &
                        CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" & Math.Round(IMP_TOT1, 6) & "','" &
                        Math.Round(IMP_TOT2, 6) & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" & TIPCAMB & "','" &
                        Math.Round(IMP_TOT3, 6) & "','" & Math.Round(IMP_TOT4, 6) & "','" & Math.Round(PRIMERPAGO, 6) & "','" & RFC & "','" & AUTORIZA & "','" &
                        FOLIO & "','" & SERIE_FMV & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                        CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" &
                        DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" & CTLPOL & "','" & CVE_OBS & "','" &
                        STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" & DES_TOT_PORC & "','" & Math.Round(IMPORTE, 6) & "','" &
                        COM_TOT_PORC & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" & TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" &
                        USO_CFDI & "','" & FORMADEPAGOSAT & "','" & CVE_VIAJE & "','" & CVE_TRACTOR & "','" & CVE_TANQUE1 & "','" & CVE_TANQUE2 & "','" &
                        CVE_DOLLY & "','" & CLAVE_O & "','" & RECOGER_EN & "','" & CLAVE_D & "','" &
                        ENTREGAR_EN & "','" & CVE_OPER & "', NEWID(), GETDATE())"
                    Try
                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                            cmd3.CommandText = SQL
                            returnValue = cmd3.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
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
                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                    Catch ex As Exception
                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        If DETEC_ERROR_VIOLATION_KEY Then
                            SIGUE = True
                            FOLIO_ASIGNADO = False
                            ' Toma el siguiente folio tabla FOLIOSF
                            FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, SERIE_FMV)

                            Do While SIGUE
                                'If SERIE_FMV.Trim.Length = 0 Or SERIE_FMV = "STAND." Then
                                'CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                                'Else
                                CVE_DOC = SERIE_FMV & FOLIO_VENTA
                                'End If

                                If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                                    FOLIO_VENTA += 1
                                    FOLIO_ASIGNADO = True
                                Else
                                    SIGUE = False
                                End If
                            Loop
                        End If
                    Catch ex As Exception
                        BITACORATPV("693. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("693. " & ex.Message & vbNewLine & ex.StackTrace)
                        Return False
                    End Try
                Next
                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                'CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   
                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                Try
                    If SERIE_FMV = "" Or SERIE_FMV = "STAND." Then
                        SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = 'STAND.'"
                    Else
                        SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & SERIE_FMV & "'"
                    End If
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = SQL
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    MsgBox("715. " & ex.Message & vbNewLine & ex.StackTrace)
                    BITACORATPV("715. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            Catch ex As Exception
                BITACORATPV("720. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("730. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        '████████████████████████████████████████████████████████████████████████████████████

        'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
        SUBTOTAL = 0 : DES_TOT = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : MAN_IEPS = "" : APL_MAN_IEPS = ""
        'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
        Try
            CANT_ORIGINAL = 1
            CANT = 1
            CANT_SURTIDA = CANT
            ALMACEN = 1

            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
            DESC1 = 0
            Select Case ESCENARIO
                Case 1
                    PRECIO = TSUB_TOTAL.Value
                    PREC = TSUB_TOTAL.Value
                Case 2
                    PRECIO = TSUBT2.Value
                    PREC = TSUBT2.Value
                Case 3
                    PRECIO = TSUBT_O.Value
                    PREC = TSUBT_O.Value
            End Select

            DESC2 = 0 : DESC3 = 0
            SUBTOTAL += (CANT * PREC)
            ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)

            DES_TOT += (CANT * PREC * DESC1 / 100)
            DES_TOT += (DES_TOT * DESC2 / 100)

            Select Case ESCENARIO
                Case 1
                    TOTIMP3 = TRET.Value
                    TOTIMP4 = TIVA.Value
                    CAN_TOT = TSUB_TOTAL.Value
                    IMPORTE += TNETO.Value
                Case 2
                    TOTIMP3 = TRETE2.Value
                    TOTIMP4 = TIVA2.Value
                    CAN_TOT = TSUBT2.Value
                    IMPORTE += TNETO2.Value
                Case 3
                    TOTIMP3 = TRET_O.Value
                    TOTIMP4 = TIVA_O.Value
                    TOT_PARTIDA = TSUBT_O.Value
                    IMPORTE += TNETO_O.Value
            End Select

            If CVE_ESQ = 1 Then
                MAN_IEPS = "N"
                APL_MAN_IMP = 1
                CUOTA_IEPS = 0
                APL_MAN_IEPS = "C"
                MTO_PORC = 0
                MTO_CUOTA = 0
            Else
                MAN_IEPS = ""
                APL_MAN_IMP = 0
                CUOTA_IEPS = 0
                APL_MAN_IEPS = ""
                MTO_PORC = 0
                MTO_CUOTA = 0
            End If
        Catch ex As Exception
            BITACORATPV("760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If ESCENARIO = 2 Then
            Kfin = FgViajes.Rows.Count - 1
        Else
            Kfin = 1
        End If

        '==========================================================================================================
        'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
        '==========================================================================================================
        NUM_PAR = 1
        For k = 1 To Kfin

            For w = 1 To 5
                If Valida_Conexion() Then
                    Exit For
                End If
            Next

            Select Case ESCENARIO
                Case 1
                    'TOTIMP3 = TRET.Value
                    'TOTIMP4 = TIVA.Value
                    'CAN_TOT = TSUB_TOTAL.Value
                    'IMPORTE = TNETO.Value

                    PREC = TSUB_TOTAL.Value
                    TOT_PARTIDA = TSUB_TOTAL.Value
                    TOTIMP3 = TRET.Value
                    TOTIMP4 = TIVA.Value
                    CANT = 1
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand

                            SQL = "SELECT * FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & LtCVE_VIAJE.Text & "'"

                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then

                                    CVE_ESQ = dr.ReadNullAsEmptyInteger("CVE_ESQIMPU")

                                    SQL = "SELECT ISNULL(P.IMPUESTO1,0) AS IMPU1, ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3,
                                            ISNULL(P.IMPUESTO4,0) AS IMPU4 
                                            FROM IMPU" & Empresa & " P
                                            WHERE CVE_ESQIMPU = " & CVE_ESQ
                                    Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                                        cmdF2.CommandText = SQL
                                        Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                                            If drF2.Read Then
                                                IMPU1 = drF2("IMPU1")
                                                IMPU2 = drF2("IMPU2")
                                                IMPU3 = drF2("IMPU3")
                                                IMPU4 = drF2("IMPU4")
                                            End If
                                        End Using
                                    End Using
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                        INSERT INTO PAR_FACTF" & Empresa & " (CVE_DOC, NUM_PAR, CVE_VIAJE, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, 
                        IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, 
                        POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, 
                        MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, DESCR_ART, CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" &
                        NUM_PAR & "','" & LtCVE_VIAJE.Text & "','" & CVE_ART & "','" & CANT & "','" & CANT & "','" & Math.Round(PREC, 6) & "','" &
                        COST & "','" & IMPU1 & "','" & IMPU2 & "','" & IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" &
                        IMP4APLA & "','" & Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" & Math.Round(TOTIMP3, 6) & "','" &
                        Math.Round(TOTIMP4, 6) & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" & ACT_INV & "','" &
                        ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" & CVE_OBS & "','" & REG_SERIE & "','" &
                        E_LTPD & "','" & TIPO_ELEM & "','0','" & Math.Round(TOT_PARTIDA, 6) & "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" &
                        CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & DESCR & "','" &
                        CVE_ESQ & "',NEWID())"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    NUM_MOV = returnValue
                                    NUM_PAR += 1
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Case 2
                    'TOTIMP3 = TRETE2.Value
                    'TOTIMP4 = TIVA2.Value
                    'CAN_TOT = TSUBT2.Value
                    'IMPORTE = TNETO2.Value
                    If FgViajes(k, 1) Then

                        ExisteViaje = False
                        SQL = "SELECT * FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & FgViajes(k, 2) & "'"
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then

                                        CVE_ESQ = dr.ReadNullAsEmptyInteger("CVE_ESQIMPU")

                                        SQL = "SELECT ISNULL(P.IMPUESTO1,0) AS IMPU1, ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3,
                                            ISNULL(P.IMPUESTO4,0) AS IMPU4, IMP1APLICA, IMP2APLICA, IMP3APLICA, IMP4APLICA
                                            FROM IMPU" & Empresa & " P
                                            WHERE CVE_ESQIMPU = " & CVE_ESQ
                                        Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                                            cmdF2.CommandText = SQL
                                            Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                                                If drF2.Read Then
                                                    IMPU1 = drF2("IMPU1")
                                                    IMPU2 = drF2("IMPU2")
                                                    IMPU3 = drF2("IMPU3")
                                                    IMPU4 = drF2("IMPU4")
                                                    IMP1APLA = drF2("IMP1APLICA")
                                                    IMP2APLA = drF2("IMP2APLICA")
                                                    IMP3APLA = drF2("IMP3APLICA")
                                                    IMP4APLA = drF2("IMP4APLICA")
                                                End If
                                            End Using
                                        End Using

                                        CANT = 1

                                        PREC = dr("SUBTOTAL")
                                        TOTIMP3 = dr("RETENCION")
                                        TOTIMP4 = dr("IVA")
                                        TOT_PARTIDA = dr("SUBTOTAL")

                                        ExisteViaje = True
                                        IMPORTE = dr("NETO")
                                    End If
                                End Using
                            End Using
                            If ExisteViaje Then
                                SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                                    INSERT INTO PAR_FACTF" & Empresa & " (CVE_DOC, NUM_PAR, CVE_VIAJE, CVE_ART, CANT, PXS, PREC, COST, IMPU1,
                                    IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2,
                                    DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD,
                                    TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC,
                                    MTO_CUOTA, DESCR_ART, CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & FgViajes(k, 2) & "','" &
                                    CVE_ART & "','" & CANT & "','" & CANT & "','" & Math.Round(PREC, 6) & "','" & COST & "','" & IMPU1 & "','" & IMPU2 & "','" &
                                    IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" &
                                    Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" & Math.Round(TOTIMP3, 6) & "','" & Math.Round(TOTIMP4, 6) & "','" &
                                    DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" & ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" &
                                    TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" & CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" &
                                    TIPO_ELEM & "','0','" & Math.Round(TOT_PARTIDA, 6) & "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" &
                                    CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & DESCR & "','" &
                                    CVE_ESQ & "',NEWID())"
                                Try
                                    Using cmd As SqlCommand = cnSAE.CreateCommand
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                                NUM_MOV = returnValue
                                                NUM_PAR += 1
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End If
                Case 3

                    PREC = TSUBT_O2.Value
                    TOT_PARTIDA = TSUBT_O2.Value
                    TOTIMP3 = TRET_O2.Value
                    TOTIMP4 = TIVA_O2.Value
                    CANT = 1

                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand

                            SQL = "SELECT * FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & LtCVE_VIAJE.Text & "'"

                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then

                                    CVE_ESQ = dr.ReadNullAsEmptyInteger("CVE_ESQIMPU")

                                    SQL = "SELECT ISNULL(P.IMPUESTO1,0) AS IMPU1, ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3,
                                            ISNULL(P.IMPUESTO4,0) AS IMPU4 
                                            FROM IMPU" & Empresa & " P
                                            WHERE CVE_ESQIMPU = " & CVE_ESQ
                                    Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                                        cmdF2.CommandText = SQL
                                        Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                                            If drF2.Read Then
                                                IMPU1 = drF2("IMPU1")
                                                IMPU2 = drF2("IMPU2")
                                                IMPU3 = drF2("IMPU3")
                                                IMPU4 = drF2("IMPU4")
                                            End If
                                        End Using
                                    End Using
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACTF" & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                        INSERT INTO PAR_FACTF" & Empresa & " (CVE_DOC, NUM_PAR, CVE_VIAJE, CVE_ART, CANT, PXS, PREC, COST, IMPU1,
                        IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2,
                        DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD,
                        TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC,
                        MTO_CUOTA, DESCR_ART, CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & LtCVE_VIAJE.Text & "','" &
                        CVE_ART & "','" & CANT & "','" & CANT & "','" & Math.Round(PREC, 6) & "','" & COST & "','" & IMPU1 & "','" & IMPU2 & "','" &
                        IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" &
                        Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" & Math.Round(TOTIMP3, 6) & "','" & Math.Round(TOTIMP4, 6) & "','" &
                        DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" & ACT_INV & "','" & ALMACEN & "','" &
                        POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" & CVE_OBS & "','" & REG_SERIE & "','" &
                        E_LTPD & "','" & TIPO_ELEM & "','0','" & TOT_PARTIDA & "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" &
                        CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" & DESCR & "','" &
                        CVE_ESQ & "',NEWID())"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    NUM_MOV = returnValue
                                    NUM_PAR += 1
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
            End Select
        Next
        Return True

    End Function

    Sub GUARDAR_VIAJE_MULT()
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim FLETE As Decimal, REM_CARGA As Integer, CVE_VIAJE As String, z As Integer, CVE_OBS As Long, TIPO_UNI As Integer, SeGrabo As Boolean = False
        Dim CVE_COBRO As Integer, CVE_DOC As String, CVE_ESQIMPU As Integer, NOTA As String = ""

        Try
            TFLETE.UpdateValueWithCurrentText()
            TIMPORTE_CONCEP.UpdateValueWithCurrentText()
            TFOLIO.UpdateValueWithCurrentText()
            TFOLIO.UpdateValueWithCurrentText()
            TSUBT2.UpdateValueWithCurrentText()
            TIVA2.UpdateValueWithCurrentText()
            TRETE2.UpdateValueWithCurrentText()
            TNETO2.UpdateValueWithCurrentText()

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If TFOLIOFG.Value = 0 AndAlso CboSerieFG.Text = "" Then
                MsgBox("3. Por favor capture el folio de la factura")
                Return
            End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TORDEN_DE.Focus()

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

            If TCVE_TRACTOR.Text.Trim.Length = 0 Then
                MsgBox("El tractor no debe quedar vacio")
                Return
            End If

            'If TOBS.Text.Trim.Length > 0 Then
            'CVE_OBS = Val(TOBS.Tag.ToString)
            'CVE_OBS = INSERT_UPDATE_GCOBS(CVE_OBS, TOBS.Text)
            'Else
            CVE_OBS = 0
            'End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            z = 0
            For k = 1 To FgViajes.Rows.Count - 1
                If FgViajes(k, 1) Then
                    CVE_VIAJE = FgViajes(k, 2)
                    z += 1
                End If
            Next
            If z = 0 Then
                MsgBox("Por favor selecione al menos un viaje")
                Return
            End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If CboConc1.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc1.Items(CboConc1.SelectedIndex))
            Else
                CVE_COBRO = 0
            End If

        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If LtTipoViaje.Text = "Full" Then
            TIPO_UNI = 1
        Else
            TIPO_UNI = 0
        End If

        If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text.Trim) Then
            CVE_ESQIMPU = Convert.ToInt16(TCVE_ESQIMPU.Text.Trim)
        Else
            CVE_ESQIMPU = 0
        End If

        CVE_DOC = CboSerieFG.Text & TFOLIOFG.Value
        CVE_VIAJE = CboSerieFG.Text & TFOLIOFG.Value

        For j = 1 To FgViajes.Rows.Count - 1
            If FgViajes(j, 1) Then
                NOTA += FgViajes(j, 2) & ", "
            End If
        Next

        If NOTA.Trim.Length > 0 Then
            NOTA = NOTA.Substring(0, NOTA.Length - 2)
        End If

        For k = 1 To 3
            Try
                SQL = "INSERT INTO GCASIGNACION_BUENO (CVE_VIAJE, CVE_DOC, FECHA, 
                    FECHA_CARGA, FECHA_DESCARGA, STATUS, TIPO_UNI, TIPO_VIAJE, CVE_OPER, CVE_TRACTOR, CVE_TANQUE1, CVE_TANQUE2, 
                    CVE_DOLLY, CVE_ST_VIA, CVE_ST_UNI, RECOGER_EN, ENTREGAR_EN, CLAVE_O, CLAVE_D, CVE_TAB, NOTA, ORDEN_DE, EMBARQUE, 
                    CARGA_ANTERIOR, CVE_TAB_VIAJE, CVE_TRANSBORDO, CVE_VIAJE_TRANSBORDO, FECHAELAB, UUID, CLIENTE, CVE_MONED, 
                    VOLUMEN_PESO, FLETE, SUBTOTAL, IVA, RETENCION, NETO, REM_CARGA, CVE_ESQIMPU, CVE_COBRO, IMPORTE_CONCEP, 
                    PRECIO_VIAJE_TONE, CVE_PRODSERV, CVE_UNIDAD, SERIE, FOLIO) 
                    VALUES (
                    @CVE_VIAJE, @CVE_DOC, @FECHA, @FECHA_CARGA, @FECHA_DESCARGA, 
                    'A', @TIPO_UNI, @TIPO_VIAJE, @CVE_OPER, @CVE_TRACTOR, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, '1', '1', @RECOGER_EN, 
                    @ENTREGAR_EN, @CLAVE_O, @CLAVE_D, @CVE_TAB, @NOTA, @ORDEN_DE, @EMBARQUE, @CARGA_ANTERIOR, @CVE_TAB_VIAJE, 
                    @CVE_TRANSBORDO, @CVE_VIAJE_TRANSBORDO, GETDATE(), NEWID(), @CLIENTE, @CVE_MONED, @VOLUMEN_PESO, @FLETE, @SUBTOTAL, 
                    @IVA, @RETENCION, @NETO, @REM_CARGA, @CVE_ESQIMPU, @CVE_COBRO, @IMPORTE_CONCEP, @PRECIO_VIAJE_TONE, 
                    @CVE_PRODSERV, @CVE_UNIDAD, @SERIE, @FOLIO)"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = CVE_DOC
                    cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                    cmd.Parameters.Add("@CVE_TRANSBORDO", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
                    cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.DateTime).Value = F1.Value
                    cmd.Parameters.Add("@FECHA_DESCARGA", SqlDbType.DateTime).Value = F2.Value
                    cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = TIPO_UNI
                    cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(RadCargado.Checked, 1, 0)
                    cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                    cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = TCVE_TRACTOR.Text
                    cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = TCVE_TANQUE1.Text
                    cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = TCVE_TANQUE2.Text
                    cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = TCVE_DOLLY.Text
                    cmd.Parameters.Add("@RECOGER_EN", SqlDbType.VarChar).Value = TRECOGER_EN.Text
                    cmd.Parameters.Add("@ENTREGAR_EN", SqlDbType.VarChar).Value = TENTREGAR_EN.Text
                    cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = TCLAVE_O.Text
                    cmd.Parameters.Add("@CLAVE_D", SqlDbType.VarChar).Value = TCLAVE_D.Text
                    cmd.Parameters.Add("@CVE_TAB", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                    cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = NOTA
                    cmd.Parameters.Add("@ORDEN_DE", SqlDbType.VarChar).Value = TORDEN_DE.Text
                    cmd.Parameters.Add("@EMBARQUE", SqlDbType.VarChar).Value = TEMBARQUE.Text
                    cmd.Parameters.Add("@CARGA_ANTERIOR", SqlDbType.VarChar).Value = TCARGA_ANTERIOR.Text
                    cmd.Parameters.Add("@CVE_TAB_VIAJE", SqlDbType.VarChar).Value = TCVE_TAB_VIAJE.Text
                    cmd.Parameters.Add("@CVE_VIAJE_TRANSBORDO", SqlDbType.VarChar).Value = ""
                    cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                    cmd.Parameters.Add("@CVE_MONED", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_MON.Text)
                    cmd.Parameters.Add("@VOLUMEN_PESO", SqlDbType.SmallInt).Value = TVOLUMEN_PESO.Value
                    cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = FLETE
                    cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = TSUBT2.Value
                    cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = TIVA2.Value
                    cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = TRETE2.Value
                    cmd.Parameters.Add("@NETO", SqlDbType.Float).Value = TNETO2.Value
                    cmd.Parameters.Add("@REM_CARGA", SqlDbType.SmallInt).Value = REM_CARGA
                    cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.SmallInt).Value = CVE_ESQIMPU
                    cmd.Parameters.Add("@IMPORTE_CONCEP", SqlDbType.Float).Value = 0
                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                    cmd.Parameters.Add("@PRECIO_VIAJE_TONE", SqlDbType.SmallInt).Value = IIf(RadPrecioXViaje.Checked, 0, 1)
                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV.Text
                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD.Text
                    cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = CboSerieFG.Text
                    cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = TFOLIOFG.Value
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                            For j = 1 To FgViajes.Rows.Count - 1

                                If FgViajes(j, 1) Then
                                    SQL = "UPDATE GCASIGNACION_BUENO SET CVE_DOC = '" & CVE_DOC & "', FACTURADO = 'S', TIPO_FACTURACION = " & TIPO_FACTURACION & ",
                                        SERIE = '" & CboSerieFactura.Text & "', FOLIO = " & TFOLIO.Value & " WHERE CVE_VIAJE = '" & FgViajes(j, 2) & "'"
                                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)

                                    SQL = "UPDATE GCMERCANCIAS2 SET CVE_DOC = '" & CVE_DOC & "' WHERE CVE_VIAJE = '" & FgViajes(j, 2) & "'"
                                    ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                                End If
                            Next

                        End If
                    End If
                End Using
                SeGrabo = True
                Exit For
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If Not Valida_Conexion() Then
            End If
        Next


        'FIN FOR DE GRABADO POR SI HAY ERROR
        If SeGrabo Then
            'GRABAR_GASTOS(CVE_VIAJE)
            'GRABAR_VALES(CVE_VIAJE)
            'GRABAR_MOVIMIENTOS_CFG()

            GRABAR_GCMERCANCIAS2(CVE_DOC)

            'GRABAR_TAB_RUTA()
            'GRABAR_GASTOS_CAMPOS_ADIC()
            'GRABAR_CONCEPTOS_PARTIDAS(CVE_VIAJE)
            SeDesplega = True
            DOC_NEW = False
            LtCVE_VIAJE.Tag = CVE_VIAJE

            Try
                If LtCVE_VIAJE.Tag.ToString.Trim.Length = 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "UPDATE GCFOLIOS SET ULT_DOC = " & TFOLIO.Value & " WHERE TIP_DOC = 'F' AND 
                             SERIE = '" & IIf(SERIE_A = "" Or SERIE_A = "STAND.", "STAND.", CboSerieFactura.Text) & "'"
                        cmd2.CommandText = SQL
                        cmd2.ExecuteNonQuery()
                    End Using
                End If
            Catch ex As Exception
                Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MsgBox("El registro se grabo satisfactoriamente")

            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                TAB1.SelectedIndex = 0
            End If
        Else
            MsgBox("No se logro grabar la asignacion de viaje")
        End If
    End Sub

    Sub GRABAR_CONCEPTOS_PARTIDAS(FCVE_VIAJE As String)
        Dim CVE_COBRO As Integer

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            TMONTO1.UpdateValueWithCurrentText()
            TCVE_PRODSERV1.UpdateValueWithCurrentText()
            TCVE_UNIDAD1.UpdateValueWithCurrentText()
            TIVAC1.UpdateValueWithCurrentText()
            TRET1.UpdateValueWithCurrentText()

            TMONTO2.UpdateValueWithCurrentText()
            TCVE_PRODSERV2.UpdateValueWithCurrentText()
            TCVE_UNIDAD2.UpdateValueWithCurrentText()
            TIVAC2.UpdateValueWithCurrentText()
            TRET2.UpdateValueWithCurrentText()

            TMONTO3.UpdateValueWithCurrentText()
            TCVE_PRODSERV3.UpdateValueWithCurrentText()
            TCVE_UNIDAD3.UpdateValueWithCurrentText()
            TIVAC3.UpdateValueWithCurrentText()
            TRET3.UpdateValueWithCurrentText()

            TMONTO4.UpdateValueWithCurrentText()
            TCVE_PRODSERV4.UpdateValueWithCurrentText()
            TCVE_UNIDAD4.UpdateValueWithCurrentText()
            TIVAC4.UpdateValueWithCurrentText()
            TRET4.UpdateValueWithCurrentText()

            TMONTO5.UpdateValueWithCurrentText()
            TCVE_PRODSERV5.UpdateValueWithCurrentText()
            TCVE_UNIDAD5.UpdateValueWithCurrentText()
            TIVAC5.UpdateValueWithCurrentText()
            TRET5.UpdateValueWithCurrentText()

            TMONTO6.UpdateValueWithCurrentText()
            TCVE_PRODSERV6.UpdateValueWithCurrentText()
            TCVE_UNIDAD6.UpdateValueWithCurrentText()
            TIVAC6.UpdateValueWithCurrentText()
            TRET6.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        SQL = "IF EXISTS (SELECT CVE_COBRO FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = @CVE_VIAJE AND CVE_COBRO = @CVE_COBRO AND NUM_PAR = @NUM_PAR)
                UPDATE GCASIG_CONCEP_PAR SET CAUSA_IVA = @CAUSA_IVA, IVA_PORC = @IVA_PORC, CAUSA_RET = @CAUSA_RET, RET_PORC = @RET_PORC, 
                CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD, MONTO = @MONTO
                WHERE CVE_VIAJE = @CVE_VIAJE AND CVE_COBRO = @CVE_COBRO AND NUM_PAR = @NUM_PAR
            ELSE
                INSERT INTO GCASIG_CONCEP_PAR (CVE_VIAJE, CVE_COBRO, NUM_PAR, STATUS, CAUSA_IVA,  IVA_PORC, CAUSA_RET,  RET_PORC, MONTO, CVE_PRODSERV, 
                CVE_UNIDAD, UUID) VALUES (@CVE_VIAJE, @CVE_COBRO, @NUM_PAR, 'A', @CAUSA_IVA, @IVA_PORC, @CAUSA_RET,  @RET_PORC, @MONTO, @CVE_PRODSERV, 
                @CVE_UNIDAD, NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL

                For k = 1 To 6

                    Select Case k
                        Case 1
                            If CboConc1.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc1.Items(CboConc1.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 1"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Case 2
                            If CboConc2.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc2.Items(CboConc2.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 2"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Case 3
                            If CboConc3.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc3.Items(CboConc3.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 3"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Case 4
                            If CboConc4.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc4.Items(CboConc4.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 4"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Case 5
                            If CboConc5.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc5.Items(CboConc5.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 5"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                        Case 6
                            If CboConc6.SelectedIndex > 0 Then
                                CVE_COBRO = CInt(CboConc6.Items(CboConc6.SelectedIndex))
                            Else
                                CVE_COBRO = 0
                                SQL = "DELETE FROM GCASIG_CONCEP_PAR WHERE CVE_VIAJE = '" & FCVE_VIAJE & "' AND CVE_COBRO = 6"
                                ReturnExeQuery = EXECUTE_QUERY_NET(SQL)
                            End If
                    End Select
                    If CVE_COBRO > 0 Then
                        cmd.Parameters.Clear()
                        Select Case CVE_COBRO
                            Case 1
                                If TMONTO1.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA1.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET1.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO1.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV1.Value
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD1.Value
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC1.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET1.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Case 2
                                If TMONTO2.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA2.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET2.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO2.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV2.Text
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD2.Text
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC2.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET2.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Case 3
                                If TMONTO3.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA3.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET3.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO3.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV3.Text
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD3.Text
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC3.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET3.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Case 4
                                If TMONTO4.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA4.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET4.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO4.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV4.Text
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD4.Text
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC4.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET4.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Case 5
                                If TMONTO5.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA5.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET5.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO5.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV5.Text
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD5.Text
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC5.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET5.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Case 6
                                If TMONTO6.Value > 0 Then
                                    cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_VIAJE
                                    cmd.Parameters.Add("@CVE_COBRO", SqlDbType.SmallInt).Value = CVE_COBRO
                                    cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = k
                                    cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = IIf(ChCAUSA_IVA6.Checked, 1, 0)
                                    cmd.Parameters.Add("@CAUSA_RET", SqlDbType.SmallInt).Value = IIf(ChCAUSA_RET6.Checked, 1, 0)
                                    cmd.Parameters.Add("@MONTO", SqlDbType.SmallInt).Value = TMONTO6.Value
                                    cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV6.Text
                                    cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD6.Text
                                    cmd.Parameters.Add("@IVA_PORC", SqlDbType.VarChar).Value = TIVAC6.Value
                                    cmd.Parameters.Add("@RET_PORC", SqlDbType.VarChar).Value = TRET6.Value
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If

                        End Select
                    End If
                Next
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try


    End Sub
    Sub GRABAR_GASTOS_CAMPOS_ADIC(FCVE_VIAJE As String)
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim ID As Long, DESCR As String

            SQL = "DELETE FROM GCASIG_CAMPOS_ADIC WHERE CVE_VIAJE = '" & FCVE_VIAJE & "'"
            EXECUTE_QUERY_NET(SQL)

            For k = 1 To FgA.Rows.Count - 1

                If Not IsDBNull(FgA(k, 1)) AndAlso Not IsNothing(FgA(k, 1)) Then
                    ID = FgA(k, 1)
                Else
                    ID = 0
                End If
                If Not IsDBNull(FgA(k, 2)) AndAlso Not IsNothing(FgA(k, 2)) Then
                    DESCR = FgA(k, 2)
                Else
                    DESCR = ""
                End If

                If DESCR.Trim.Length > 0 Then    'GCASIG_CAMPOS_ADIC (ID INT IDENTITY(1,1) PRIMARY KEY, CAMPO_ADIC VARCHAR(MAX)
                    SQL = "INSERT INTO GCASIG_CAMPOS_ADIC (CVE_VIAJE, CAMPO_ADIC) VALUES ('" & FCVE_VIAJE & "','" & DESCR & "')"

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                End If
            Next
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
        End Try
    End Sub

    Sub GRABAR_GCMERCANCIAS2(FCVE_DOC As String)
        Dim NUM_PAR As Integer = 1, DETEC_ERROR_VIOLATION_KEY As Boolean = False, CVE_VIAJE As String

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            SQL = "DELETE FROM GCMERCANCIAS2 WHERE CVE_DOC = '" & FCVE_DOC & "'"
            EXECUTE_QUERY_NET(SQL)

            For k = 1 To FgViajes.Rows.Count - 1

                If FgViajes(k, 1) Then

                    CVE_VIAJE = FgViajes(k, 2)

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM GCMERCANCIAS WHERE CVE_VIAJE = '" & CVE_VIAJE & "'"
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            While dr2.Read

                                For j = 1 To 3
                                    Try
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            SQL = "SET ansi_warnings OFF
                                                IF EXISTS (SELECT CVE_VIAJE FROM GCMERCANCIAS WHERE CVE_VIAJE = @CVE_VIAJE AND NUM_PAR = @NUM_PAR)
                                                UPDATE GCMERCANCIAS2 SET CANT = @CANT, ID_UNIDAD = @ID_UNIDAD, DESC_UNIDAD = @DESC_UNIDAD, 
                                                ID_MERCANCIA = @ID_MERCANCIA, DESCR_MERCANCIA = @DESCR_MERCANCIA, MAT_PELIGROSO = @MAT_PELIGROSO, 
                                                CVE_MAT_PELIGROSO = @CVE_MAT_PELIGROSO, ID_EMBALAJE = @ID_EMBALAJE, DESC_EMBALAJE = @DESC_EMBALAJE, 
                                                PESO = @PESO, VALOR_MERCANCIA = @VALOR_MERCANCIA, MONEDA = @MONEDA, ID_FRACC_ARANCELARIA = @ID_FRACC_ARANCELARIA, 
                                                UUID_COM_EXT = @UUID_COM_EXT, CVE_DOC = @CVE_DOC
                                                WHERE CVE_VIAJE = @CVE_VIAJE AND NUM_PAR = @NUM_PAR
                                                ELSE
                                                INSERT INTO GCMERCANCIAS2 (CVE_VIAJE, NUM_PAR, CVE_DOC, CANT, ID_UNIDAD, DESC_UNIDAD, ID_MERCANCIA, DESCR_MERCANCIA, 
                                                MAT_PELIGROSO, CVE_MAT_PELIGROSO, ID_EMBALAJE, DESC_EMBALAJE, PESO, VALOR_MERCANCIA, MONEDA, ID_FRACC_ARANCELARIA, 
                                                UUID_COM_EXT) VALUES (@CVE_VIAJE, ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCMERCANCIAS2),1), @CVE_DOC, @CANT, @ID_UNIDAD, 
                                                @DESC_UNIDAD, @ID_MERCANCIA, @DESCR_MERCANCIA, @MAT_PELIGROSO, @CVE_MAT_PELIGROSO, @ID_EMBALAJE, @DESC_EMBALAJE, 
                                                @PESO, @VALOR_MERCANCIA, @MONEDA, @ID_FRACC_ARANCELARIA, @UUID_COM_EXT)"

                                            cmd.CommandText = SQL
                                            cmd.Parameters.Clear()
                                            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = FCVE_DOC
                                            cmd.Parameters.Add("@NUM_PAR", SqlDbType.SmallInt).Value = NUM_PAR
                                            cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = FCVE_DOC
                                            cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = dr2("CANT")
                                            cmd.Parameters.Add("@ID_UNIDAD", SqlDbType.VarChar).Value = dr2("ID_UNIDAD")
                                            cmd.Parameters.Add("@DESC_UNIDAD", SqlDbType.VarChar).Value = dr2("DESC_UNIDAD")
                                            cmd.Parameters.Add("@ID_MERCANCIA", SqlDbType.VarChar).Value = dr2("ID_MERCANCIA")
                                            cmd.Parameters.Add("@DESCR_MERCANCIA", SqlDbType.VarChar).Value = dr2("DESCR_MERCANCIA")
                                            cmd.Parameters.Add("@MAT_PELIGROSO", SqlDbType.VarChar).Value = dr2("MAT_PELIGROSO")
                                            cmd.Parameters.Add("@CVE_MAT_PELIGROSO", SqlDbType.VarChar).Value = dr2("CVE_MAT_PELIGROSO")
                                            cmd.Parameters.Add("@ID_EMBALAJE", SqlDbType.VarChar).Value = dr2("ID_EMBALAJE")
                                            cmd.Parameters.Add("@DESC_EMBALAJE", SqlDbType.VarChar).Value = dr2("DESC_EMBALAJE")
                                            cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = dr2("PESO")
                                            cmd.Parameters.Add("@VALOR_MERCANCIA", SqlDbType.Float).Value = dr2("VALOR_MERCANCIA")
                                            cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = dr2("MONEDA")
                                            cmd.Parameters.Add("@ID_FRACC_ARANCELARIA", SqlDbType.VarChar).Value = dr2("ID_FRACC_ARANCELARIA")
                                            cmd.Parameters.Add("@UUID_COM_EXT", SqlDbType.VarChar).Value = dr2("UUID_COM_EXT")
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                    NUM_PAR += 1
                                                    Exit For
                                                End If
                                            End If
                                        End Using
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
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try
                                    If DETEC_ERROR_VIOLATION_KEY Then
                                        NUM_PAR += 1
                                    End If
                                Next
                            End While
                        End Using
                    End Using
                End If
            Next
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_GASTOS_AUTO()
        Dim CVE_FOLIO As String, CVE_GAS As Integer, IMPORTE As Decimal = 0, GAS_DESCR As String = ""

        Try
            If TCVE_TAB_VIAJE.Text.Trim.Length > 0 Then
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(F.CVE_GAS,0) AS CVEGAS, ISNULL(IMPORTE_GASTO,0) AS IMPORTE, C.DESCR
                            FROM GCTAB_RUTAS_F F
                            LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = F.CVE_GAS
                            WHERE CVE_TAB = '" & TCVE_TAB_VIAJE.Text & "'"
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

                    FgG.AddItem("" & vbTab & CVE_FOLIO & vbTab & FECHA.Value & vbTab & CVE_GAS & vbTab & GAS_DESCR & vbTab & IMPORTE & vbTab &
                                CVE_FOLIO & vbTab & "EDICION" & vbTab & "S" & vbTab & " " & vbTab & "" & vbTab & "")
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

        If TCVE_TAB_VIAJE.Text.Trim.Length > 0 Then
            Try
                SQL = "SELECT R.CVE_GASOL, R.LITROS_RUTA, R.IMPORTE_GAS, R.AUTO_SENC_LTS, R.P4_SENC_LTS, R.FULL_AUTO_LTS, R.FULL_P4_LTS, G.DESCR
                    FROM GCTAB_RUTAS_F R
                    LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = R.CVE_GASOL
                    WHERE R.CVE_TAB = '" & TCVE_TAB_VIAJE.Text & "'"
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
                                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                    LITROS_OK = FULL_AUTO_LTS 'LtTipoViaje.Text = "Full"
                                Else
                                    LITROS_OK = AUTO_SENC_LTS 'LtTipoViaje.Text = "Sencillo"
                                End If
                            Else 'P4
                                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
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
                    s &= "" & vbTab '19
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

        If FgCarga.Row > 0 Then
            Dim cmd As New SqlCommand With {.Connection = cnSAE}

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
                cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CONVERTIR_TO_INT(FgCarga(FgCarga.Row, 1))
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgCarga(FgCarga.Row, 2)
                cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = IIf(FgCarga(FgCarga.Row, 3) = "Full", 1, 0)
                cmd.Parameters.Add("@CVE_RUTA", SqlDbType.VarChar).Value = FgCarga(FgCarga.Row, 4)
                cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = FgCarga(FgCarga.Row, 5)
                cmd.Parameters.Add("@DESTINO", SqlDbType.VarChar).Value = FgCarga(FgCarga.Row, 6)
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = FgCarga(FgCarga.Row, 7)
                cmd.Parameters.Add("@KM_RECO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 9))
                cmd.Parameters.Add("@COSTO_CASETAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 10))
                cmd.Parameters.Add("@EJES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(FgCarga(FgCarga.Row, 11))
                cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 12))  'N
                cmd.Parameters.Add("@SUELDO_OPER", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 13)) 'N
                cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 14)) 'N
                cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 15)) 'N
                cmd.Parameters.Add("@LITROS_RUTA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 16)) 'N
                cmd.Parameters.Add("@COSTO_DISEL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgCarga(FgCarga.Row, 17)) 'N
                cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(FgCarga(FgCarga.Row, 18) = "Cargado", 1, 0)
                cmd.Parameters.Add("@ST_TAB_RUTAS", SqlDbType.VarChar).Value = FgCarga(FgCarga.Row, 17).ToString 'N
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

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET STATUS = 'C' WHERE CVE_VIAJE = '" & fCVE_VIAJE & "'"
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

                        For j = 1 To 5

                            SQL = "UPDATE GCASIGNACION_VIAJE_GASTOS SET CVE_OPER = @CVE_OPER, CVE_NUM = @CVE_NUM, IMPORTE = @IMPORTE,
                                ST_GASTOS = @ST_GASTOS, STATUS = 'A', TIPO_PAGO = @TIPO_PAGO 
                                WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO
                                IF @@ROWCOUNT = 0
                                INSERT INTO GCASIGNACION_VIAJE_GASTOS (CVE_VIAJE, STATUS, CVE_OPER, FOLIO, FECHA, CVE_NUM, IMPORTE, FECHAELAB, 
                                ST_GASTOS, TIPO_PAGO, UUID) OUTPUT Inserted.UUID VALUES (@CVE_VIAJE,'A', @CVE_OPER, @FOLIO, @FECHA, @CVE_NUM, @IMPORTE, GETDATE(), 
                                @ST_GASTOS, @TIPO_PAGO, NEWID())"
                            cmd.CommandText = SQL
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
        Dim CVE_GAS As String = "", LITROS As Decimal = 0, P_X_LITRO As Decimal = 0, LITROS_REALES As Decimal, SUBTOTAL As Decimal = 0, IVA As Decimal = 0, IEPS As Decimal = 0
        Dim IMPORTE As Decimal = 0, FACTURA As String = "", OBS As String = "", CVE_FOLIO As String, UUID As String
        Dim z As Integer, SQL1 As String, FECHA_TRASPASO
        Dim FOL_VIA As Long = 0
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        FgV.FinishEditing()

        If Not Valida_Conexion() Then
            Return
        End If

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
                                SQL = "IF NOT EXISTS (SELECT CVE_DOCP FROM GCSEG_VALPED WHERE FOLIO = " & CVE_FOLIO & ")
                                    INSERT INTO GCSEG_VALPED (CVE_DOCP, STATUS, FOLIO, FECHA_PED, UUID)
                                    VALUES (@CVE_DOCP, 'A', @FOLIO, @FECHA_PED, NEWID())"
                                Try
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        cmd2.Parameters.Add("@CVE_DOCP", SqlDbType.VarChar).Value = ""
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

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmAsigViajeBuenoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        CloseTab("Asignación viaje")
        Me.Dispose()
        If SeDesplega Then

            If ViajeNew Then
                If ExisteTab("Asignación de Viajes") Then
                    FrmAsigViajeBueno.DESPLEGAR()
                End If
            End If
        End If
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TORDEN_DE.Focus()
        End If

        If TIENE_GASTOS_Y_VALES() Then
            MsgBox("El viaje tiene capturado gastos y vales no es posible cambiar de operador")
            TORDEN_DE.Focus()
            e.Handled = True

            TCVE_OPER.Text = TCVE_OPER.Tag

        End If
    End Sub

    Private Function TIENE_GASTOS_Y_VALES() As Boolean
        Dim TieneGastos As Boolean = False
        Try
            For k = 1 To FgG.Rows.Count - 1
                If FgG(k, 7) = "AUTORIZADO" Or FgG(k, 7) = "DEPOSITADO" Then
                    TieneGastos = True
                    Exit For
                End If
            Next

            For k = 1 To FgV.Rows.Count - 1
                If FgV(k, 15) = "CAPTURADO" Then
                    TieneGastos = True
                    Exit For
                End If
            Next

        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return TieneGastos

    End Function
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
                        TCVE_OPER.Tag = ""
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
                    TCVE_OPER.Tag = ""
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
            If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                If TCVE_OPER.Text.Trim <> "" And TCVE_OPER.Text <> "0" Then
                    If Not DOC_NEW Then
                        If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                            'MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                            'Return
                        End If
                    End If
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
                TCVE_OPER.Tag = Var4
                LOper.Text = Var5  'NOMBRE
                LtOp1.Text = Var4
                LtOp2.Text = Var5
                LtLicencia.Text = Var6
                LtVigencia.Text = Var7
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                TCVE_OPER.Tag = ""
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
        Select Case e.KeyCode
            Case Keys.F2
                BtnTractor_Click(Nothing, Nothing)
            Case Keys.Up
                TCVE_OPER.Focus()
            Case Keys.Down
                TCVE_TANQUE1.Focus()
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub TCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles TCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If TCVE_TRACTOR.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_TRACTOR.Tag = TCVE_TRACTOR.Text
                    LTractor.Text = DESCR
                    If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                        If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                            LtTipoViaje.Text = "Full"

                            TFLETE.Value = TAR_X_VIA_FULL
                            TFLETE.Tag = TAR_X_VIA_FULL
                            If RadPrecioXViaje.Checked Then
                                MONTO_X_VIAJE = TFLETE.Value
                            Else
                                MONTO_X_TON = TFLETE.Value
                            End If
                        Else
                            LtTipoViaje.Text = "Sencillo"
                            TFLETE.Value = TAR_X_VIA_SENC
                            TFLETE.Tag = TAR_X_VIA_SENC
                            If RadPrecioXViaje.Checked Then
                                MONTO_X_VIAJE = TFLETE.Value
                            Else
                                MONTO_X_TON = TFLETE.Value
                            End If
                        End If
                        ASIGNA_TANQUES(TCVE_TRACTOR.Text)
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TRACTOR.Text = TCVE_TRACTOR.Tag
                End If
            Else
                TFLETE.Value = 0
                TFLETE.Tag = 0

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
    Private Sub TCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE1.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnTanque1_Click(Nothing, Nothing)
            Case Keys.Up
                TCVE_TRACTOR.Focus()
            Case Keys.Down
                TCVE_TANQUE2.Focus()
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub TCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_TANQUE1.Tag = TCVE_TANQUE1.Text
                    LTanque1.Text = DESCR
                    If TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                        TFLETE.Value = TAR_X_VIA_FULL
                        TFLETE.Tag = TAR_X_VIA_FULL

                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If
                    Else
                        LtTipoViaje.Text = "Sencillo"
                        TFLETE.Value = TAR_X_VIA_SENC
                        TFLETE.Tag = TAR_X_VIA_SENC
                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE1.Text = TCVE_TANQUE1.Tag
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"

                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If
                Else
                    LtTipoViaje.Text = "Sencillo"
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If
                End If
                'If TCVE_TANQUE1.Tag.ToString.Trim.Length > 0 And Not DOC_NEW Then
                'MsgBox("La unidad no puede puede quedar vacia")
                'TCVE_TANQUE1.Text = TCVE_TANQUE1.Tag
                'End If
            End If
        Catch ex As Exception
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TANQUE2.KeyDown
        Select Case e.KeyCode
            Case Keys.F2
                BtnTanque2_Click(Nothing, Nothing)
            Case Keys.Up
                TCVE_TANQUE1.Focus()
            Case Keys.Down
                TCVE_DOLLY.Focus()
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
    Private Sub TCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles TCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If TCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_TANQUE2.Tag = TCVE_TANQUE2.Text
                    LTanque2.Text = DESCR
                    If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                        TFLETE.Value = TAR_X_VIA_FULL
                        TFLETE.Tag = TAR_X_VIA_FULL
                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If
                    Else
                        LtTipoViaje.Text = "Sencillo"
                        TFLETE.Value = TAR_X_VIA_SENC
                        TFLETE.Tag = TAR_X_VIA_SENC
                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If
                    End If
                Else
                    MsgBox("Tanque inexistente")
                    TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                End If
            Else
                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL

                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If

                Else
                    LtTipoViaje.Text = "Sencillo"
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If

                End If
                'If TCVE_TANQUE2.Tag.Trim.Length > 0 And Not DOC_NEW Then
                'LtTipoViaje.Text = "Full"
                'MsgBox("El tipo de unidad es full no puede quedar vacio")
                'TCVE_TANQUE2.Text = TCVE_TANQUE2.Tag
                'End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTractor_Click(sender As Object, e As EventArgs) Handles BtnTractor.Click
        Try
            If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                If TCVE_TRACTOR.Text.Trim <> "" And TCVE_TRACTOR.Text <> "0" Then
                    If Not DOC_NEW Then
                        If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                            'MsgBox("El Tractor no puede ser modificado porque tiene gastos o vales de combustible asignados")
                            'Return
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then

                If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                    If UNIDAD_ASIGNADA_LOCAL(1, Var4) Then
                        MsgBox("Esta unidad ya fue asignada verifique por favor")
                    End If
                End If
                If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                    If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                        LtTipoViaje.Text = "Full"
                        TFLETE.Value = TAR_X_VIA_FULL
                        TFLETE.Tag = TAR_X_VIA_FULL

                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If

                    Else
                        LtTipoViaje.Text = "Sencillo"
                        TFLETE.Value = TAR_X_VIA_SENC
                        TFLETE.Tag = TAR_X_VIA_SENC
                        If RadPrecioXViaje.Checked Then
                            MONTO_X_VIAJE = TFLETE.Value
                        Else
                            MONTO_X_TON = TFLETE.Value
                        End If
                    End If
                End If

                TCVE_TRACTOR.Text = Var5
                TCVE_TRACTOR.Tag = Var5
                LTractor.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_TANQUE1.Focus()
                ASIGNA_TANQUES(TCVE_TRACTOR.Text)
            End If

        Catch Ex As Exception
            Bitacora("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Sub ASIGNA_TANQUES(FTRACTOR As String)
        Try
            'TCVE_TANQUE1.Text = ""
            'LTanque1.Text = ""
            'TCVE_TANQUE2.Text = ""
            'LTanque2.Text = ""
            'TCVE_DOLLY.Text = ""
            'LDolly.Text = ""

            Dim d As Integer = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(KIT,0) AS KT, ISNULL(CVE_OPER,0) AS OPER FROM GCSTATUS_UNIDADES WHERE CVE_UNI = '" & FTRACTOR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        If dr("KT") > 0 Then

                            If dr("OPER") > 0 Then
                                TCVE_OPER.Text = dr("OPER")
                                TCVE_OPER.Tag = dr("OPER")

                                LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                            End If

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT CVE_UNI 
                                    FROM GCSTATUS_UNIDADES S
                                    INNER JOIN GCUNIDADES U ON U.CLAVEMONTE = S.CVE_UNI 
                                    WHERE U.CVE_TIPO_UNI <> 1 AND KIT  = " & dr("KT") & " ORDER BY U.CVE_TIPO_UNI"
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    While dr2.Read
                                        Select Case d
                                            Case 1
                                                If dr2("CVE_UNI").ToString.Length > 0 Then
                                                    TCVE_TANQUE1.Text = dr2("CVE_UNI")
                                                    SendKeys.Send("{TAB}")
                                                End If
                                            Case 2
                                                If dr2("CVE_UNI").ToString.Trim.Length > 0 Then
                                                    TCVE_TANQUE2.Text = dr2("CVE_UNI")
                                                    SendKeys.Send("{TAB}")
                                                End If
                                            Case 3
                                                If dr2("CVE_UNI").ToString.Trim.Length > 0 Then
                                                    TCVE_DOLLY.Text = dr2("CVE_UNI")
                                                    SendKeys.Send("{TAB}")
                                                End If
                                        End Select
                                        d += 1
                                    End While
                                End Using
                            End Using
                        End If
                    End If
                End Using
            End Using

            DESPLEGA_IMPORTE_RUTA

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGA_IMPORTE_RUTA()
        Try
            If TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                LtTipoViaje.Text = "Full"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    'TAR_X_VIA_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_FULL")
                    'TAR_X_VIA_SENC = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_SENC")
                    'TAR_X_TON_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_TON_FULL")
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_VIAJE = TFLETE.Value
                End If
            ElseIf TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length = 0 Then
                LtTipoViaje.Text = "Sencillo"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_TON = TFLETE.Value
                End If
            ElseIf TCVE_TRACTOR.Text.Trim.Length > 0 And TCVE_TANQUE1.Text.Trim.Length = 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                LtTipoViaje.Text = "Sencillo"
                If RadPrecioXViaje.Checked Then
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    MONTO_X_VIAJE = TFLETE.Value
                Else
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL
                    MONTO_X_TON = TFLETE.Value
                End If
            End If

            CALCULOS_TEXTCHANGED(1, "MX")

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTanque1_Click(sender As Object, e As EventArgs) Handles BtnTanque1.Click
        Try
            If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                If TCVE_TANQUE1.Text.Trim <> "" Then
                    If Not DOC_NEW Then
                        If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                            'MsgBox("El Tanque 1 no puede ser modificado porque tiene gastos o vales de combustible asignados")
                            'Return
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                    If UNIDAD_ASIGNADA_LOCAL(2, Var4) Then
                        MsgBox("Esta unidad ya fue asignada verifique por favor")
                    End If
                End If

                If TCVE_TANQUE2.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If

                Else
                    LtTipoViaje.Text = "Sencillo"
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If
                End If

                TCVE_TANQUE1.Text = Var5
                TCVE_TANQUE1.Tag = Var5
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
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        ' MsgBox("El Tanque 2 no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        ' Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then

                If TCVE_TANQUE1.Text.Trim.Length > 0 Then
                    LtTipoViaje.Text = "Full"
                    TFLETE.Value = TAR_X_VIA_FULL
                    TFLETE.Tag = TAR_X_VIA_FULL
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If

                Else
                    LtTipoViaje.Text = "Sencillo"
                    TFLETE.Value = TAR_X_VIA_SENC
                    TFLETE.Tag = TAR_X_VIA_SENC
                    If RadPrecioXViaje.Checked Then
                        MONTO_X_VIAJE = TFLETE.Value
                    Else
                        MONTO_X_TON = TFLETE.Value
                    End If
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
            If FACTURA_UNO_O_MULT <> "SEFACTURA" AndAlso FACTURA_UNO_O_MULT <> "SEFACTURA_MULT" Then
                If TCVE_DOLLY.Text.Trim <> "" Then
                    If Not DOC_NEW Then
                        If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                            'MsgBox("El Dolly no puede ser modificado porque tiene gastos o vales de combustible asignados")
                            'Return
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "3" : Var5 = ""

            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
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
    Private Sub FgG_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgG.CellButtonClick
        Try
            If FgG.Row > 0 AndAlso e.Col = 3 Then

                ENTRAG = False
                If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                    FgG(FgG.Row, 7) = "ACEPTADO" Then
                    FgG.Col = 1
                    'MsgBox("2. La partida ya fue cerrada no se puede modificar")
                    Return
                End If

                Var2 = "GCConc"
                Var4 = "" : Var5 = ""
                FrmSelItem2.ShowDialog()
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

        ENTRAG = True
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
                If String.IsNullOrEmpty(FgG(k, 3)) Then
                    Sigue = False
                Else
                    If FgG(k, 8) <> "S" Then
                        Fol += 1
                    End If
                End If
            Next


            If Sigue Or FgG.Rows.Count = 1 Then
                STATUS_VIAJE = OBTENER_STATUS_GASTOS_VIAJE()

                FOLIO_AG = GET_MAX_TRY("GCASIGNACION_VIAJE_GASTOS", "FOLIO")

                FgG.AddItem("" & vbTab & (FOLIO_AG + Fol) & vbTab & DateTime.Now.ToString("dd/MM/yyyy") & vbTab & "" & vbTab & "" & vbTab &
                            "0" & vbTab & "" & vbTab & IIf(STATUS_VIAJE.Trim.Length > 0, STATUS_VIAJE, "EDICION") & vbTab & "N" & vbTab &
                            " " & vbTab & " " & vbTab & " ")
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

            If FgV(FgV.Row, 15) <> "" Then
                If FgV(FgV.Row, 15) <> "EDICION" Then
                    MsgBox("No es posible eliminar el vale por que esta capturado o depositado , verifique por favor")
                    Return
                End If
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
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
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
                        If TCVE_TANQUE1.Text = fCVE_UNI Then
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
                        LtNombre1.Tag = dr("NOMBRE").ToString

                        LtAliasO.Text = dr("NOTA")
                        LtAliasO.Tag = ""

                        LtCalle1.Text = dr("DOMICILIO").ToString
                        LtCalle1.Tag = dr("DOMICILIO").ToString

                        LtCalle2.Text = dr("DOMICILIO2").ToString
                        LtCalle2.Tag = dr("DOMICILIO2").ToString

                        LtPlanta.Text = dr("PLANTA").ToString
                        LtPlanta.Tag = dr("PLANTA").ToString

                        'LtNota.Text = dr("NOTA").ToString
                        'LtNota.Tag = dr("NOTA").ToString

                        LtRFC.Text = dr("RFC").ToString
                        LtRFC.Tag = dr("RFC").ToString

                    Else
                        TCLAVE_O.Text = ""
                        LtNombre1.Text = ""
                        LtAliasO.Text = ""
                        LtCalle1.Text = ""
                        LtCalle2.Text = ""
                        LtPlanta.Text = ""
                        LtNota.Text = ""
                        LtRFC.Text = ""

                        LtNombre1.Tag = ""
                        LtAliasO.Tag = ""
                        LtCalle1.Tag = ""
                        LtCalle2.Tag = ""
                        LtPlanta.Tag = ""
                        LtNota.Tag = ""
                        LtRFC.Tag = ""
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
                        LtAliasD.Text = dr("NOTA")

                        LtDom2.Text = dr("DOMICILIO").ToString
                        LtDomi2.Text = dr("DOMICILIO2").ToString
                        LtPlanta2.Text = dr("PLANTA").ToString
                        'LtNota2.Text = dr("NOTA").ToString
                        LtRFC2.Text = dr("RFC").ToString
                    Else
                        TCLAVE_D.Text = ""
                        LtNombre2.Text = ""
                        LtAliasD.Text = ""
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

    Private Sub BtnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "T"
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
        If e.KeyCode = Keys.Enter Then
            F1.Focus()
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
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "T"
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
        If e.KeyCode = Keys.Enter Then
            F2.Focus()
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
            Dim LITROS As Decimal

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
    Private Function OBTENER_STATUS_VALES_VIAJE()
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
    Private Function OBTENER_STATUS_GASTOS_VIAJE() As String
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
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs)

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

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click

        Try
            If FgCarga.Rows.Count <= 1 Then
                '                            CANT          EMBALAJE        CARGA       QUE EL REMITENTE DICE QUE CONTIENE
                FgCarga.AddItem("" & vbTab & "1" & vbTab & "Viaje" & vbTab & "" & vbTab & "" & vbTab &
                           "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                '              PESO        VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
            Else
                '                            CANT          EMBALAJE        CARGA       QUE EL REMITENTE DICE QUE CONTIENE
                FgCarga.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                '              PESO        VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
            End If
            FgCarga.Focus()
            FgCarga.Row = FgCarga.Rows.Count - 1
            FgCarga.Col = 1
            'SendKeys.Send("{ENTER}")
        Catch ex As Exception
            Bitacora("717. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("717. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                FgCarga.Rows.Remove(FgCarga.Row)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FgG_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgG.BeforeEdit
        Try
            If FgG.Row > 0 And ENTRAG Then
                ENTRAG = False
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

        ENTRAG = True
    End Sub
    Private Sub FgG_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgG.ValidateEdit
        Try
            If e.Row > 0 And ENTRAG Then
                ENTRAG = False
                Select Case e.Col
                    Case 2, 5, 7
                        If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                       FgG(FgG.Row, 7) = "ACEPTADO" Then
                            MsgBox("3. La partida ya fue cerrada no se puede modificar")
                            ENTRAG = True
                            Return
                        End If
                    Case 3

                        If FgG(FgG.Row, 7) = "DEPOSITADO" Or FgG(FgG.Row, 7) = "AUTORIZADO" Or FgG(FgG.Row, 7) = "CANCELADO" Or
                            FgG(FgG.Row, 7) = "ACEPTADO" Then
                            FgG.Col = 1
                            ENTRAG = True
                            Return
                        End If

                        'SQL = "SELECT CVE_GAS, DESCR FROM GCCONC_GASTOS WHERE STATUS = 'A' ORDER BY CVE_GAS"
                        FgG(FgG.Row, 4) = BUSCA_CAT("GCConc", FgG.Editor.Text)
                End Select
            End If
        Catch ex As Exception
            Bitacora("762. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRAG = True
    End Sub
    Private Sub FgG_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgG.KeyDownEdit
        If e.Row > 0 Then
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Select Case e.Col
                    Case 3
                        FgG.Col = 5
                End Select
            End If

        End If
    End Sub
    Private Sub FgG_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles FgG.PreviewKeyDown
        Select Case FgG.Col
            Case 3
                FgG.Col = 5
                FgG.StartEditing()
        End Select
    End Sub
    Private Sub TCVE_DOLLY_Validated(sender As Object, e As EventArgs) Handles TCVE_DOLLY.Validated
        Try
            Dim DESCR As String
            If TCVE_DOLLY.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", TCVE_DOLLY.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    TCVE_DOLLY.Tag = TCVE_DOLLY.Text
                    LDolly.Text = DESCR
                Else
                    MsgBox("Dolly inexistente")
                    TCVE_DOLLY.Text = ""
                    TCVE_DOLLY.Tag = ""
                    LDolly.Text = ""
                    TCVE_TANQUE1.Select()
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



    Private Sub TCVE_DOLLY_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_DOLLY.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnDolly_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            TCLAVE_O.Focus()
        End If
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
        If e.KeyCode = Keys.Enter Then
            TCLAVE_D.Focus()
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
    Private Sub BarImprimirBitacoraViaje_Click(sender As Object, e As EventArgs)
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
            If FgG.Row > 0 And ENTRAG Then
                ENTRAG = False
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
        ENTRAG = True
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
    Private Sub TCVE_OPER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_OPER.KeyPress
        Try
            If TCVE_OPER.Text.Trim <> "" Then
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        'MsgBox("El operador no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        'e.Handled = True
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TRACTOR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_TRACTOR.KeyPress
        Try
            If TCVE_TRACTOR.Text.Trim <> "" Then
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        'MsgBox("El tractor no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        'e.Handled = True
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TANQUE1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_TANQUE1.KeyPress
        Try
            If TCVE_TANQUE1.Text.Trim <> "" Then
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        'MsgBox("El tanque no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        'e.Handled = True
                        'Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TANQUE2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_TANQUE2.KeyPress
        Try
            If TCVE_TANQUE2.Text.Trim <> "" Then
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        'MsgBox("El tanque no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        'e.Handled = True
                        'Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_DOLLY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_DOLLY.KeyPress
        Try
            If TCVE_DOLLY.Text.Trim <> "" Then
                If Not DOC_NEW Then
                    If FgG.Rows.Count > 1 Or FgV.Rows.Count > 1 Then
                        'MsgBox("El Dolly no puede ser modificado porque tiene gastos o vales de combustible asignados")
                        'e.Handled = True
                        'Return
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnTabRutaViajes_Click(sender As Object, e As EventArgs) Handles BtnTabRutaViajes.Click

        Try
            Var2 = "RUTAS FLORES"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TAB_VIAJE.Text = Var4
                TCVE_TAB_VIAJE.Tag = Var4
                LtDescr.Text = Var7
                LtDescr2.Text = Var8
                Var2 = "" : Var4 = "" : Var5 = ""
                DESPLEGAR_RUTAS_FLORES(TCVE_TAB_VIAJE.Text)

            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_RUTAS_FLORES(FCVE_TAB_VIAJE As String)
        Dim Existe As Boolean = False

        TCLIENTE.Text = ""

        LNombreCTe.Text = ""
        TAR_X_VIA_FULL = 0
        TAR_X_VIA_SENC = 0
        TAR_X_TON_FULL = 0
        LtTipoViaje.Text = ""
        TFLETE.Value = 0
        TFLETE.Tag = 0
        MONTO_X_VIAJE = 0
        MONTO_X_TON = 0

        TUSO_CFDI.Text = ""
        TFORMADEPAGOSAT.Text = ""
        TMETODODEPAGO.Text = ""

        'FgG.Rows.Count = 1
        'FgV.Rows.Count = 1

        Try

            SQL = "SELECT T.CVE_TAB, T.CLIE_OP, ISNULL(OP1.NOMBRE,'') AS f, T.CLIE_OP_O, ISNULL(OP2.NOMBRE,'') AS NOM_OP_O, 
                T.CLIE_OP_D, ISNULL(OP3.NOMBRE,'') AS NOM_OP_D, ISNULL(OP2.CVE_PLAZA,0) AS CVE_PLAZA_O, 
                ISNULL(P1.CIUDAD,'') AS CIUDAD_PLA_O, ISNULL(OP3.CVE_PLAZA,0) AS CVE_PLAZA_D, ISNULL(P2.CIUDAD,'') AS CIUDAD_PLA_D, 
                ISNULL(OP2.DOMICILIO,'') AS DOMI_O, ISNULL(OP3.DOMICILIO,'') AS DOMI_D, T.CVE_PROD, T.CVE_ART, 
                T.KMS, T.AUTO_SENC, T.P4_SENC, T.FULL_AUTO, T.FULL_P4, T.AUTO_SENC_LTS, 
                T.P4_SENC_LTS, T.FULL_AUTO_LTS, T.FULL_P4_LTS, T.SUELDO_FULL, T.SUELDO_SENC, T.TAR_X_TON_FULL, T.TAR_X_TON_SENC, 
                T.TAR_X_VIA_FULL, T.TAR_X_VIA_SENC, USO_CFDI, FORMADEPAGOSAT, METODODEPAGO, ISNULL(T.DESCR,'') AS DESCR_RUTA
                FROM GCTAB_RUTAS_F T 
                LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = OP2.CVE_PLAZA
                LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = OP3.CVE_PLAZA
                WHERE CVE_TAB = '" & FCVE_TAB_VIAJE & "'"

            SQL = "SELECT T.CVE_TAB, T.CLIE_OP, ISNULL(T.DESCR,'') AS DES, ISNULL(T.DESCR2,'') AS DES2, ISNULL(OP1.NOMBRE,'') AS f, T.CLIE_OP_O, 
                ISNULL(OP2.NOMBRE,'') AS NOM_OP_O, T.CLIE_OP_D, ISNULL(OP3.NOMBRE,'') AS NOM_OP_D, ISNULL(OP2.CVE_PLAZA,0) AS CVE_PLAZA_O, 
                ISNULL(OP3.CVE_PLAZA,0) AS CVE_PLAZA_D, ISNULL(OP2.DOMICILIO,'') AS DOMI_O, ISNULL(OP3.DOMICILIO,'') AS DOMI_D, T.CVE_PROD, T.CVE_ART, 
                T.KMS, T.AUTO_SENC, T.P4_SENC, T.FULL_AUTO, T.FULL_P4, T.AUTO_SENC_LTS, 
                T.P4_SENC_LTS, T.FULL_AUTO_LTS, T.FULL_P4_LTS, T.SUELDO_FULL, T.SUELDO_SENC, T.TAR_X_TON_FULL, T.TAR_X_TON_SENC, 
                T.TAR_X_VIA_FULL, T.TAR_X_VIA_SENC, USO_CFDI, FORMADEPAGOSAT, METODODEPAGO, ISNULL(T.DESCR,'') AS DESCR_RUTA
                FROM GCTAB_RUTAS_F T 
                LEFT JOIN CLIE" & Empresa & " OP1 ON OP1.CLAVE = T.CLIE_OP
                LEFT JOIN GCCLIE_OP OP2 ON OP2.CLAVE = T.CLIE_OP_O
                LEFT JOIN GCCLIE_OP OP3 ON OP3.CLAVE = T.CLIE_OP_D
                WHERE CVE_TAB = '" & FCVE_TAB_VIAJE & "'"

            'CLIE_OP_O  CLIE_OP_D

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLIENTE.Text = dr("CLIE_OP")

                        LtNombreRuta.Text = dr("DESCR_RUTA")
                        LNombreCTe.Text = BUSCA_CAT("Cliente", TCLIENTE.Text, False)
                        LtDescr.Text = dr("DES")
                        LtDescr2.Text = dr("DES2")

                        TAR_X_VIA_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_FULL")
                        TAR_X_VIA_SENC = dr.ReadNullAsEmptyDecimal("TAR_X_VIA_SENC")
                        TAR_X_TON_FULL = dr.ReadNullAsEmptyDecimal("TAR_X_TON_FULL")
                        If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                            If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                LtTipoViaje.Text = "Full"
                                If RadPrecioXViaje.Checked Then
                                    TFLETE.Value = TAR_X_VIA_FULL
                                    TFLETE.Tag = TAR_X_VIA_FULL
                                    MONTO_X_VIAJE = TFLETE.Value
                                Else
                                    MONTO_X_TON = TFLETE.Value
                                End If

                            Else
                                LtTipoViaje.Text = "Sencillo"
                                TFLETE.Value = TAR_X_VIA_SENC
                                TFLETE.Tag = TAR_X_VIA_SENC
                                If RadPrecioXViaje.Checked Then
                                    MONTO_X_VIAJE = TFLETE.Value
                                Else
                                    MONTO_X_TON = TFLETE.Value
                                End If
                            End If
                        End If

                        If TCLIENTE.Text.Trim.Length > 0 Then
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT ISNULL(C.CVE_ESQIMPU, 0) AS CVE_ESQ, ISNULL(DESCRIPESQ,'') AS DES, NUM_MON
                                         FROM CLIE" & Empresa & " C
                                         LEFT JOIN IMPU" & Empresa & " I ON I.CVE_ESQIMPU = C.CVE_ESQIMPU
                                         WHERE CLAVE = '" & TCLIENTE.Text & "'"
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            If dr2("CVE_ESQ") > 0 Then
                                                TCVE_ESQIMPU.Text = dr2("CVE_ESQ")
                                                LtEsquema.Text = dr2("DES")
                                            Else
                                                TCVE_ESQIMPU.Text = ""
                                                LtEsquema.Text = ""
                                            End If
                                            TCVE_MON.Text = dr2.ReadNullAsEmptyInteger("NUM_MON")
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If

                        Existe = True
                        TUSO_CFDI.Text = dr.ReadNullAsEmptyString("USO_CFDI")
                        TFORMADEPAGOSAT.Text = dr.ReadNullAsEmptyString("FORMADEPAGOSAT")
                        TMETODODEPAGO.Text = dr.ReadNullAsEmptyString("METODODEPAGO")

                        TCLAVE_O.Text = dr.ReadNullAsEmptyString("CLIE_OP_O")
                        TCLAVE_D.Text = dr.ReadNullAsEmptyString("CLIE_OP_D")
                    End If
                End Using
            End Using
            If Existe Then
                If TCVE_MON.Text = "0" Then
                    TCVE_MON.Text = ""
                End If

                Try
                    If TCVE_MON.Text.Trim.Length = 0 AndAlso Not IsNumeric(TCVE_MON.Text) Then
                        TCVE_MON.Text = "1"
                    End If

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand

                        SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED  
                             FROM MONED" & Empresa & " WHERE NUM_MONED = " & TCVE_MON.Text
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                LtMoneda.Text = dr2("DESCR")
                                LtCve_moned.Text = dr2("CVE_MONED")
                                TTIPO_CAMBIO.Value = dr2("TCAMBIO")
                            Else
                                LtMoneda.Text = ""
                                LtCve_moned.Text = ""
                                TTIPO_CAMBIO.Value = 0
                            End If
                        End Using
                    End Using

                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try


                CARGAR_GASTOS_AUTO()
                CARGAR_VALES_AUTO()

                If TCLAVE_O.Text.Trim.Length > 0 Then
                    DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text)
                Else
                    LtNombre1.Text = ""
                    LtAliasO.Text = ""
                    LtCalle1.Text = ""
                    LtCalle2.Text = ""
                    LtPlanta.Text = ""
                    LtNota.Text = ""
                    LtRFC.Text = ""
                End If

                If TCLAVE_D.Text.Trim.Length > 0 Then
                    DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text)
                Else
                    LtNombre2.Text = ""
                    LtAliasD.Text = ""
                    LtDom2.Text = ""
                    LtDomi2.Text = ""
                    LtPlanta2.Text = ""
                    LtNota2.Text = ""
                    LtRFC2.Text = ""
                End If

                TCVE_MON.Focus()

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

                DESPLEGAR_RUTAS_FLORES(TCVE_TAB_VIAJE.Text)

                TCVE_TAB_VIAJE.Tag = TCVE_TAB_VIAJE.Text

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

    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog With {
                .Filter = "Excel files (*.xls or .xlsx)|*.xls;*.xlsx",
                .FilterIndex = 1,
                .RestoreDirectory = True
            }
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                TExcel.Text = openExcelFileDialog.FileName
                CARGAR_HOJAS()
            Else
                TExcel.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles BtnExportarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Mercancias")
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_HOJAS()
        Try
            'C1XLBook1.Clear()
            'C1XLBook1.Load(TExcel.Text, True)

            'BtnImportarExcel_Click(Nothing, Nothing)
            'Dim workbook As New Workbook()
            'Workbook.LoadFromFile(TExcel.Text)
            'Dim sheet As Worksheet = workbook.Worksheets(0)
            'CboHojas.Items.Clear()
            'For k = 0 To sheet.Workbook.Worksheets.Count - 1
            'CboHojas.Items.Add(sheet.Workbook.Worksheets.Item(k).Name)
            'Next
            'If CboHojas.Items.Count > 0 Then
            'CboHojas.SelectedIndex = 0
            'End If

            BtnImportarExcel_Click(Nothing, Nothing)

        Catch ex As Exception
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnImportarExcel_Click(sender As Object, e As EventArgs) Handles BtnImportarExcel.Click
        Dim COLA As String = "", COLB As String = "", COLC As String = "", COLD As String = "", COLE As String = "", COLF As String = "", COLG As String = ""
        Dim COLH As String = "", COLI As String = "", COLJ As String = "", COLK As String = "", COLL As String = "", COLM As String = "", COLN As String = ""
        Dim rw As Integer, pos As Integer, UNI_SAT As String, DESCR As String

        If TExcel.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un archivo de excel")
            Return
        End If

        PasaXLS = False
        BtnImportarExcel.Enabled = False

        Try
            SQL = "SELECT M.COLA, M.COLB, M.COLC, M.COLD, M.COLE, M.COLF, M.COLG, M.COLH, M.COLI, M.COLJ, M.COLK, M.COLL, M.COLM, M.COLN
                FROM GCMERCANCIAS_CFG M 
                WHERE CLIENTE = '" & TCLIENTE.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        COLA = dr("COLA").ToString
                        COLB = dr("COLB").ToString
                        COLC = dr("COLC").ToString
                        COLD = dr("COLD").ToString
                        COLE = dr("COLE").ToString
                        COLF = dr("COLF").ToString
                        COLG = dr("COLG").ToString
                        COLH = dr("COLH").ToString
                        COLI = dr("COLI").ToString
                        COLJ = dr("COLJ").ToString
                        COLK = dr("COLK").ToString
                        COLL = dr("COLL").ToString
                        COLM = dr("COLM").ToString
                        COLN = dr("COLN").ToString
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Fg.Rows.Count = 1
        'C1XLBook1.Clear()
        'C1XLBook1.Load(TExcel.Text)

        'Dim source As XLSheet = C1XLBook1.Sheets(CboHojas.SelectedIndex)

        Fg.Redraw = False
        Fg.BeginUpdate()

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor

        ENTRAM = False
        '1
        Dim workbook As New Workbook()
        workbook.LoadFromFile(TExcel.Text)
        Dim sheet As Worksheet = workbook.Worksheets(0)

        'Dim firstRow As CellRange = sheet.Rows(0)
        'Dim lastrow As Integer = sheet.LastRow ' Returns 65536
        'Dim lastColumn As Integer = sheet.LastColumn ' Returns 256

        If ChHeader.Checked Then
            rw = 2
        Else
            rw = 1
        End If

        Try
            For row = rw To sheet.Rows.Count

                Fg.AddItem("" & vbTab & "")
                r_ = Fg.Rows.Count - 1
                '1
                If COLA.Trim.Length > 0 Then
                    pos = POS_COL(COLA)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 1) = sheet(row, pos).Value
                    End If
                End If
                '2
                If COLB.Trim.Length > 0 Then
                    pos = POS_COL(COLB)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 2) = sheet(row, pos).Value
                    End If
                End If
                '3
                If COLC.Trim.Length > 0 Then
                    pos = POS_COL(COLC)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 4) = sheet(row, pos).Value
                    End If
                End If
                '4
                If COLD.Trim.Length > 0 Then
                    pos = POS_COL(COLD)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 5) = sheet(row, pos).Value
                    End If
                End If
                '5
                If COLE.Trim.Length > 0 Then
                    pos = POS_COL(COLE)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 7) = sheet(row, pos).Value
                    End If
                End If
                '6     MATERIAL PELIGROSO
                If COLF.Trim.Length > 0 Then
                    pos = POS_COL(COLF)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        If sheet(row, pos).Value.ToString.ToUpper = "SI" Or sheet(row, pos).Value.ToString.ToUpper = "Si" Or
                            sheet(row, pos).Value.ToString.ToUpper = "SÍ" Or sheet(row, pos).Value.ToString.ToUpper = "Sí" Then
                            Fg(r_, 8) = True
                        End If
                    End If
                End If
                '7
                If COLN.Trim.Length > 0 Then
                    pos = POS_COL(COLN)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 9) = sheet(row, pos).Value 'CVE. MAT. PELIGROSO
                    End If
                End If
                '8
                If COLG.Trim.Length > 0 Then
                    pos = POS_COL(COLG)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 11) = sheet(row, pos).Value 'EMBALAJE
                    End If
                End If
                '9
                If COLH.Trim.Length > 0 Then
                    pos = POS_COL(COLH)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 13) = sheet(row, pos).Value 'DESCRIPCION EMBALAJE
                    End If
                End If
                '10
                If COLI.Trim.Length > 0 Then
                    pos = POS_COL(COLI)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 14) = sheet(row, pos).Value 'PESO
                    End If
                End If
                '11
                If COLJ.Trim.Length > 0 Then
                    pos = POS_COL(COLJ)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 15) = sheet(row, pos).Value 'VALOR MERCANCIAS
                    End If
                End If
                '12
                If COLK.Trim.Length > 0 Then
                    pos = POS_COL(COLK)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        If sheet(row, pos).Value.ToString.Length = 0 Then
                            Fg(r_, 16) = "MXN"
                        Else
                            Fg(r_, 16) = sheet(row, pos).Value 'MONEDA
                        End If
                    Else
                        Fg(r_, 16) = "MXN"
                    End If
                Else
                    Fg(r_, 16) = "MXN"
                End If
                '13
                If COLL.Trim.Length > 0 Then
                    pos = POS_COL(COLL)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 18) = sheet(row, pos).Value 'ID
                    End If
                End If
                '14
                If COLM.Trim.Length > 0 Then
                    pos = POS_COL(COLM)
                    If Not IsNothing(sheet(row, pos).Value) Then
                        Fg(r_, 19) = sheet(row, pos).Value 'UUID
                    End If
                End If
                If row = 50 Then
                    Lt6.Refresh()
                End If
                Lt6.Text = "Partidas " & row & "/" & Fg.Rows.Count - 1
            Next row


            Dim doc As New XmlDocument()

            Try
                For k = 1 To Fg.Rows.Count - 1

                    If IsNothing(Fg(k, 4)) Then

                        DESCR = If([String].IsNullOrEmpty(Fg(k, 4)), "", Fg(k, 4))
                        UNI_SAT = If([String].IsNullOrEmpty(Fg(k, 2)), "", Fg(k, 2))

                        If UNI_SAT.Trim.Length > 0 And DESCR.Trim.Length = 0 Then

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT claveUnidad, nombre FROM tblcclaveunidad WHERE claveUnidad = '" & UNI_SAT & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read Then
                                            Fg(k, 4) = dr("nombre")
                                        End If
                                    End Using
                                End Using

                                SQL = "SELECT clave, nombre FROM tblcclaveunidadpeso WHERE clave = '" & UNI_SAT & "'"
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        If dr.Read Then
                                            Fg(k, 4) = dr("nombre")
                                        End If
                                    End Using
                                End Using

                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If

                    End If

                    If IsNothing(Fg(k, 7)) Then

                        DESCR = If([String].IsNullOrEmpty(Fg(k, 7)), "", Fg(k, 7))
                        UNI_SAT = If([String].IsNullOrEmpty(Fg(k, 5)), "", Fg(k, 5))

                        If UNI_SAT.Trim.Length > 0 And DESCR.Trim.Length = 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_PROD_SERV.xml")

                                Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_ClaveProdServ='" & UNI_SAT & "']")
                                If nodeList.Count > 0 Then
                                    For Each znode In nodeList
                                        Fg(k, 7) = VarXml(znode, "Descripcion")
                                    Next
                                End If
                            End If
                        End If

                    End If

                Next
            Catch ex As Exception
                Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Lt6.Text = "Partidas " & Fg.Rows.Count - 1

            IsMatPeligroso = False
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & False & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & "MXN" & vbTab & "" & vbTab & "" & vbTab & "")
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            'SendKeys.Send(" ")
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        'CADENA = sheet.Range("A2").Value & vbTab & sheet.Range("B2").Value & vbTab & sheet.Range("D2").Value & vbTab & sheet.Range("E2").Value & vbTab
        'CADENA += sheet.Range("G2").Value & vbTab & sheet.Range("H2").Value & vbTab & sheet.Range("K2").Value & vbTab & sheet.Range("M2").Value & vbTab
        'CADENA += sheet.Range("N2").Value & vbTab & sheet.Range("O2").Value & vbTab & sheet.Range("P2").Value & vbTab
        'Fg.AddItem("" & vbTab & CADENA)
        'CADENA = sheet.Range("A3").Value & vbTab & sheet.Range("B3").Value & vbTab & sheet.Range("D3").Value & vbTab & sheet.Range("E3").Value & vbTab
        'CADENA += sheet.Range("G3").Value & vbTab & sheet.Range("H3").Value & vbTab & sheet.Range("K3").Value & vbTab & sheet.Range("M3").Value & vbTab
        'CADENA += sheet.Range("N3").Value & vbTab & sheet.Range("O3").Value & vbTab & sheet.Range("P3").Value & vbTab
        'Fg.AddItem("" & vbTab & CADENA)
        'CADENA = sheet.Range("A4").Value & vbTab & sheet.Range("B4").Value & vbTab & sheet.Range("D4").Value & vbTab & sheet.Range("E4").Value & vbTab
        'CADENA += sheet.Range("G4").Value & vbTab & sheet.Range("H4").Value & vbTab & sheet.Range("K4").Value & vbTab & sheet.Range("M4").Value & vbTab
        'CADENA += sheet.Range("N4").Value & vbTab & sheet.Range("O4").Value & vbTab & sheet.Range("P4").Value & vbTab
        'Fg.AddItem("" & vbTab & CADENA)

        '2

        ENTRAM = True
        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        BtnImportarExcel.Enabled = True

        Fg.Redraw = True
        Fg.EndUpdate()

        PasaXLS = True

        MsgBox("Proceso terminado")
    End Sub

    Private Function POS_COL(FCOLUMNA As String) As Integer
        Dim NCOL As Integer
        Select Case FCOLUMNA
            Case "A"
                NCOL = 1
            Case "B"
                NCOL = 2
            Case "C"
                NCOL = 3
            Case "D"
                NCOL = 4
            Case "E"
                NCOL = 5
            Case "F"
                NCOL = 6
            Case "G"
                NCOL = 7
            Case "H"
                NCOL = 8
            Case "I"
                NCOL = 9
            Case "J"
                NCOL = 10
            Case "K"
                NCOL = 11
            Case "L"
                NCOL = 12
            Case "M"
                NCOL = 13
            Case "N"
                NCOL = 14
            Case "O"
                NCOL = 15
            Case "P"
                NCOL = 16
            Case "Q"
                NCOL = 17
            Case "R"
                NCOL = 18
            Case "S"
                NCOL = 19
            Case "T"
                NCOL = 20
            Case "U"
                NCOL = 21
            Case "V"
                NCOL = 22
            Case "W"
                NCOL = 23
            Case "X"
                NCOL = 24
            Case "Y"
                NCOL = 25
            Case "Z"
                NCOL = 26
            Case "AA"
                NCOL = 27
            Case "AB"
                NCOL = 28
            Case "AC"
                NCOL = 29
            Case "AD"
                NCOL = 30
            Case "AE"
                NCOL = 31
            Case "AF"
                NCOL = 32
            Case "AG"
                NCOL = 33
            Case "AH"
                NCOL = 34
            Case "AI"
                NCOL = 35
            Case "AJ"
                NCOL = 36
            Case "AK"
                NCOL = 37
            Case "AL"
                NCOL = 38
            Case "AM"
                NCOL = 39
            Case "AN"
                NCOL = 40


            Case "AO"
                NCOL = 41
            Case "AP"
                NCOL = 42
            Case "AQ"
                NCOL = 43
            Case "AR"
                NCOL = 44
            Case "AS"
                NCOL = 45
            Case "AT"
                NCOL = 46
            Case "AU"
                NCOL = 47
            Case "AV"
                NCOL = 48
            Case "AW"
                NCOL = 49
            Case "AX"
                NCOL = 50
            Case "AY"
                NCOL = 51
            Case "AZ"
                NCOL = 52
            Case "BA"
                NCOL = 53
            Case "BB"
                NCOL = 54

            Case "BC"
                NCOL = 55
            Case "BD"
                NCOL = 56
            Case "BE"
                NCOL = 57
            Case "BF"
                NCOL = 58
            Case "BG"
                NCOL = 59
            Case "BH"
                NCOL = 60
            Case "BI"
                NCOL = 61
            Case "BJ"
                NCOL = 62
            Case "BK"
                NCOL = 63
            Case "BL"
                NCOL = 64
            Case "BM"
                NCOL = 65
            Case "BN"
                NCOL = 66
            Case "BO"
                NCOL = 67
            Case "BP"
                NCOL = 68
        End Select

        Return NCOL
    End Function
    Sub DESPLEGAR_DATOS_CTE(FCLIENTE As String)

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT FORMADEPAGOSAT, USO_CFDI, METODODEPAGO FROM CLIE" & Empresa & " WHERE CLAVE = '" & FCLIENTE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TFORMADEPAGOSAT.Text = dr("FORMADEPAGOSAT")
                        TUSO_CFDI.Text = dr("USO_CFDI")
                        TMETODODEPAGO.Text = dr("METODODEPAGO")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try

            Var2 = "CTE_POS"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'CLAVE 
                'Var5 = Fg(Fg.Row, 2).ToString 'nombre cliente operativo
                'Var6 = Fg(Fg.Row, 3).ToString 'plaza ciudad
                'Var7 = Fg(Fg.Row, 4).ToString 'domicilio cliente op
                TCLIENTE.Text = Var4
                LNombreCTe.Text = Var5

                DESPLEGAR_DATOS_CTE(Var4)

                If TCLIENTE.Text.Trim.Length > 0 Then
                    'DESPLEGAR_MERCANCIAS_CFG()
                End If

                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
            TExcel.Focus()
        Catch ex As Exception
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            TCVE_MON.Focus()
        End If
    End Sub

    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text, False)
                If DESCR <> "" Then

                    LNombreCTe.Text = DESCR

                    DESPLEGAR_DATOS_CTE(TCLIENTE.Text)
                Else
                    MsgBox("Cliente inexistente")
                    LNombreCTe.Text = ""
                    TCLIENTE.Text = ""
                End If
            Else
                LNombreCTe.Text = ""
                TCLIENTE.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1680. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1680. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMoneda_Click(sender As Object, e As EventArgs) Handles BtnMoneda.Click
        Try
            Var2 = "Moneda"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'NUM_MONED
                'Var5 = Fg(Fg.Row, 2) 'DESCR
                'Var6 = Fg(Fg.Row, 3) 'CVE_MONDE
                'Var7 = Fg(Fg.Row, 4) 'TIPO CAMBBIO
                TCVE_MON.Text = Var4
                LtMoneda.Text = Var5
                LtCve_moned.Text = Var6
                TTIPO_CAMBIO.Value = Var7
                CALCULAR_MONTOS()
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
            TExcel.Focus()
        Catch ex As Exception
            MsgBox("1660. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1660. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_MON_Validated(sender As Object, e As EventArgs) Handles TCVE_MON.Validated
        Try
            If TCVE_MON.Text.Trim.Length > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED  
                     FROM MONED" & Empresa & " WHERE NUM_MONED = " & TCVE_MON.Text
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        If dr2.Read Then
                            LtMoneda.Text = dr2("DESCR")
                            LtCve_moned.Text = dr2("CVE_MONED")
                            TTIPO_CAMBIO.Value = dr2("TCAMBIO")
                        Else
                            LtMoneda.Text = ""
                            LtCve_moned.Text = ""
                            TTIPO_CAMBIO.Value = 0
                        End If
                    End Using
                End Using
            End If

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_MON_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_MON.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnMoneda_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub CALCULA_PRECIO_CARTA_PORTE()
        Dim PRECIO As Decimal, PREC_FLETE As String
        Try
            Try 'LValorDeclarado.Text = importe del concepto
                PRECIO = 0
                If Not IsNothing(TFLETE.Tag) Then
                    PREC_FLETE = TFLETE.Tag
                    PREC_FLETE.Trim.Replace(",", "")
                    If IsNumeric(PREC_FLETE) Then
                        PRECIO = PREC_FLETE
                    End If
                End If

            Catch ex As Exception
                Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
                PRECIO = 0
            End Try
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_NUEVO_ESQUEMA()
        Dim PREC As Decimal, cIeps As Decimal, cImpu As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, Sigue As Boolean
        Dim M1 As Decimal, M2 As Decimal, M3 As Decimal, M4 As Decimal, M5 As Decimal, M6 As Decimal, FLETE As Decimal
        Dim IVA1 As Decimal = 0, IVA2 As Decimal = 0, IVA3 As Decimal = 0, IVA4 As Decimal = 0, IVA5 As Decimal = 0, IVA6 As Decimal = 0
        Dim RET1 As Decimal = 0, RET2 As Decimal = 0, RET3 As Decimal = 0, RET4 As Decimal = 0, RET5 As Decimal = 0, RET6 As Decimal = 0

        If Not ACEPTA_CALCULO Then
            Return
        End If

        Try
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
            TMONTO1.UpdateValueWithCurrentText()
            TMONTO2.UpdateValueWithCurrentText()
            TMONTO3.UpdateValueWithCurrentText()
            TMONTO4.UpdateValueWithCurrentText()
            TMONTO5.UpdateValueWithCurrentText()
            TMONTO6.UpdateValueWithCurrentText()
            TRET1.UpdateValueWithCurrentText()
            TRET2.UpdateValueWithCurrentText()
            TRET3.UpdateValueWithCurrentText()
            TRET4.UpdateValueWithCurrentText()
            TRET5.UpdateValueWithCurrentText()
            TRET6.UpdateValueWithCurrentText()

            TIVAC1.UpdateValueWithCurrentText()
            TIVAC2.UpdateValueWithCurrentText()
            TIVAC3.UpdateValueWithCurrentText()
            TIVAC4.UpdateValueWithCurrentText()
            TIVAC5.UpdateValueWithCurrentText()
            TIVAC6.UpdateValueWithCurrentText()

            TFLETE.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text) Then
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
            End If

            FLETE = TFLETE.Value

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If Not String.IsNullOrEmpty(FLETE) AndAlso IsNumeric(FLETE) Then

                If ESCENARIO = 0 Then
                    If RadPrecioXTonelada.Checked Then
                        If MONTO_X_TON = 0 Then
                            If TVOLUMEN_PESO.Value > 0 Then
                                TFLETEA.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                                TFLETEA.Tag = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                                MONTO_X_TON = TFLETE.Value
                            Else
                                TFLETEA.Value = TAR_X_TON_FULL
                                TFLETEA.Tag = TAR_X_TON_FULL
                                MONTO_X_TON = TFLETE.Value
                            End If
                        Else
                            TFLETEA.Value = MONTO_X_TON
                            TFLETEA.Tag = MONTO_X_TON
                        End If
                    Else
                        If MONTO_X_VIAJE > 0 Then

                            TFLETEA.Value = MONTO_X_VIAJE
                            TFLETEA.Tag = MONTO_X_VIAJE
                        Else
                            If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                                If TCVE_TANQUE1.Text.Trim.Length > 0 And TCVE_TANQUE2.Text.Trim.Length > 0 Then
                                    TFLETEA.Value = TAR_X_VIA_FULL
                                    TFLETEA.Tag = TAR_X_VIA_FULL
                                    MONTO_X_VIAJE = TFLETE.Value
                                Else
                                    TFLETEA.Value = TAR_X_VIA_SENC
                                    TFLETEA.Tag = TAR_X_VIA_SENC
                                    MONTO_X_VIAJE = TFLETE.Value
                                End If
                            Else
                                TFLETEA.Value = 0
                                TFLETEA.Tag = 0
                                MONTO_X_VIAJE = 0
                                MONTO_X_TON = 0
                            End If
                        End If
                    End If
                End If


                PREC = TFLETE.Value
                PREC = Math.Round(CDec(PREC), 8)

                M1 = IIf(IsNumeric(TMONTO1.Value), Convert.ToDecimal(TMONTO1.Value), 0)
                If ChCAUSA_IVA1.Checked Then
                    IVA1 = M1 * IIf(IsNumeric(TIVAC1.Value), Convert.ToDecimal(TIVAC1.Value), 0) / 100
                End If
                If ChCAUSA_RET1.Checked Then
                    RET1 = M1 * IIf(IsNumeric(TRET1.Value), Convert.ToDecimal(TRET1.Value), 0) / 100
                End If

                M2 = IIf(IsNumeric(TMONTO2.Value), Convert.ToDecimal(TMONTO2.Value), 0)
                If ChCAUSA_IVA2.Checked Then
                    IVA2 = M2 * IIf(IsNumeric(TIVAC2.Value), Convert.ToDecimal(TIVAC2.Value), 0) / 100
                End If
                If ChCAUSA_RET2.Checked Then
                    RET2 = M2 * IIf(IsNumeric(TRET2.Value), Convert.ToDecimal(TRET2.Value), 0) / 100
                End If

                M3 = IIf(IsNumeric(TMONTO3.Value), Convert.ToDecimal(TMONTO3.Value), 0)
                If ChCAUSA_IVA3.Checked Then
                    IVA3 = M3 * IIf(IsNumeric(TIVAC3.Value), Convert.ToDecimal(TIVAC3.Value), 0) / 100
                End If
                If ChCAUSA_RET3.Checked Then
                    RET3 = M3 * IIf(IsNumeric(TRET3.Value), Convert.ToDecimal(TRET3.Value), 0) / 100
                End If

                M4 = IIf(IsNumeric(TMONTO4.Value), Convert.ToDecimal(TMONTO4.Value), 0)
                If ChCAUSA_IVA4.Checked Then
                    IVA4 = M4 * IIf(IsNumeric(TIVAC4.Value), Convert.ToDecimal(TIVAC4.Value), 0) / 100
                End If
                If ChCAUSA_RET4.Checked Then
                    RET4 = M4 * IIf(IsNumeric(TRET4.Value), Convert.ToDecimal(TRET4.Value), 0) / 100
                End If

                M5 = IIf(IsNumeric(TMONTO5.Value), Convert.ToDecimal(TMONTO5.Value), 0)
                If ChCAUSA_IVA5.Checked Then
                    IVA5 = M5 * IIf(IsNumeric(TIVAC5.Value), Convert.ToDecimal(TIVAC5.Value), 0) / 100
                End If
                If ChCAUSA_RET5.Checked Then
                    RET5 = M5 * IIf(IsNumeric(TRET5.Value), Convert.ToDecimal(TRET5.Value), 0) / 100
                End If

                M6 = IIf(IsNumeric(TMONTO6.Value), Convert.ToDecimal(TMONTO6.Value), 0)
                If ChCAUSA_IVA6.Checked Then
                    IVA6 = M6 * IIf(IsNumeric(TIVAC6.Value), Convert.ToDecimal(TIVAC6.Value), 0) / 100
                End If
                If ChCAUSA_RET6.Checked Then
                    RET6 = M6 * IIf(IsNumeric(TRET6.Value), Convert.ToDecimal(TRET6.Value), 0) / 100
                End If

                cIeps = PREC * vIMPU1 / 100
                cImpu2 = PREC * vIMPU2 / 100
                cImpu3 = PREC * vIMPU3 / 100
                cImpu = PREC * vIMPU4 / 100

                If ESCENARIO = 3 Then
                    TSUBT_O.Value = PREC + M1 + M2 + M3 + M4 + M5 + M6
                    TIVA_O.Value = cImpu + IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                    TRET_O.Value = cImpu2 + cImpu3 + RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                    TNETO_O.Value = TSUBT_O.Value + TIVA_O.Value + TRET_O.Value

                    TSALDO_SUBTOTAL.Value = TSUBT_O2.Value - TSUBT_O.Value
                    TSALDO_IVA.Value = TIVA_O2.Value - TIVA_O.Value
                    TSALDO_RET.Value = TRET_O2.Value - TRET_O.Value
                    TSALDO_NETO.Value = TNETO_O2.Value - (TABONO_NETO.Value + TNETO_O.Value)
                Else
                    'TIMPORTE_CONCEP.Value = M1 + M2 + M3 + M4 + M5 + M6
                    TSUB_TOTAL.Value = PREC + M1 + M2 + M3 + M4 + M5 + M6
                    TIVA.Value = cImpu + IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                    TRET.Value = cImpu2 + cImpu3 + RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                    TNETO.Value = TSUB_TOTAL.Value + TIVA.Value + TRET.Value

                End If
            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULO_ESCENARIO3(FNUM As Integer)
        Dim PREC As Decimal, cIeps As Decimal, cImpu As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, Sigue As Boolean
        Dim M1 As Decimal, M2 As Decimal, M3 As Decimal, M4 As Decimal, M5 As Decimal, M6 As Decimal, FLETE As Decimal
        Dim IVA1 As Decimal = 0, IVA2 As Decimal = 0, IVA3 As Decimal = 0, IVA4 As Decimal = 0, IVA5 As Decimal = 0, IVA6 As Decimal = 0
        Dim RET1 As Decimal = 0, RET2 As Decimal = 0, RET3 As Decimal = 0, RET4 As Decimal = 0, RET5 As Decimal = 0, RET6 As Decimal = 0
        Dim IMPORTE_CONCEP As Decimal, MONTOA1 = 0, MONTOA2 = 0, MONTOA3 = 0, MONTOA4 = 0, MONTOA5 = 0, MONTOA6 = 0, ABONO_NETO As Decimal = 0
        Dim ABONO_NETO_SIN_IVA As Decimal = 0

        If Not ACEPTA_CALCULO Then
            Return
        End If

        Try
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
            TMONTO1.UpdateValueWithCurrentText()
            TMONTO2.UpdateValueWithCurrentText()
            TMONTO3.UpdateValueWithCurrentText()
            TMONTO4.UpdateValueWithCurrentText()
            TMONTO5.UpdateValueWithCurrentText()
            TMONTO6.UpdateValueWithCurrentText()
            TRET1.UpdateValueWithCurrentText()
            TRET2.UpdateValueWithCurrentText()
            TRET3.UpdateValueWithCurrentText()
            TRET4.UpdateValueWithCurrentText()
            TRET5.UpdateValueWithCurrentText()
            TRET6.UpdateValueWithCurrentText()
            TFLETE.UpdateValueWithCurrentText()
            TFLETEA.UpdateValueWithCurrentText()
            If FNUM = 20 Then
                If Not IsNothing(TABONO_NETO.Text) AndAlso IsNumeric(TABONO_NETO.Text) Then
                    ABONO_NETO = TABONO_NETO.Text
                Else
                    If Not IsNothing(TABONO_NETO.Value) AndAlso IsNumeric(TABONO_NETO.Value) Then
                        ABONO_NETO = TABONO_NETO.Value
                    Else
                        ABONO_NETO = 0
                    End If
                End If
            Else
                TABONO_NETO.UpdateValueWithCurrentText()
            End If

            'TABONO_NETO.Value = QUITAR_IMPUESTO_BUENO(Convert.ToInt16(TCVE_ESQIMPU.Text), ABONO_NETO)

            MONTOA1 = TMONTO1.Value
            MONTOA2 = TMONTO2.Value
            MONTOA3 = TMONTO3.Value
            MONTOA4 = TMONTO4.Value
            MONTOA5 = TMONTO5.Value
            MONTOA6 = TMONTO6.Value

            If Not IsNothing(TFLETEA.Text) AndAlso IsNumeric(TFLETEA.Text) Then
                FLETE = Convert.ToDecimal(TFLETEA.Text)
            Else
                FLETE = 0
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text) Then
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
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If Not String.IsNullOrEmpty(FLETE) AndAlso IsNumeric(FLETE) Then

                If IsNothing(TIVAC1.Value) OrElse IsDBNull(TIVAC1.Value) OrElse Not IsNumeric(TIVAC1.Value) Then TIVAC1.Value = 0
                If IsNothing(TIVAC2.Value) OrElse IsDBNull(TIVAC2.Value) OrElse Not IsNumeric(TIVAC2.Value) Then TIVAC2.Value = 0
                If IsNothing(TIVAC3.Value) OrElse IsDBNull(TIVAC3.Value) OrElse Not IsNumeric(TIVAC3.Value) Then TIVAC3.Value = 0
                If IsNothing(TIVAC4.Value) OrElse IsDBNull(TIVAC4.Value) OrElse Not IsNumeric(TIVAC4.Value) Then TIVAC4.Value = 0
                If IsNothing(TIVAC5.Value) OrElse IsDBNull(TIVAC5.Value) OrElse Not IsNumeric(TIVAC5.Value) Then TIVAC5.Value = 0
                If IsNothing(TIVAC6.Value) OrElse IsDBNull(TIVAC6.Value) OrElse Not IsNumeric(TIVAC6.Value) Then TIVAC6.Value = 0

                If IsNothing(TRET1.Value) OrElse IsDBNull(TRET1.Value) OrElse Not IsNumeric(TRET1.Value) Then TRET1.Value = 0
                If IsNothing(TRET2.Value) OrElse IsDBNull(TRET2.Value) OrElse Not IsNumeric(TRET2.Value) Then TRET2.Value = 0
                If IsNothing(TRET3.Value) OrElse IsDBNull(TRET3.Value) OrElse Not IsNumeric(TRET3.Value) Then TRET3.Value = 0
                If IsNothing(TRET4.Value) OrElse IsDBNull(TRET4.Value) OrElse Not IsNumeric(TRET4.Value) Then TRET4.Value = 0
                If IsNothing(TRET5.Value) OrElse IsDBNull(TRET5.Value) OrElse Not IsNumeric(TRET5.Value) Then TRET5.Value = 0
                If IsNothing(TRET6.Value) OrElse IsDBNull(TRET6.Value) OrElse Not IsNumeric(TRET6.Value) Then TRET6.Value = 0



                PREC = FLETE
                PREC = Math.Round(CDec(PREC), 8)

                ABONO_NETO_SIN_IVA = QUITAR_IMPUESTO_BUENO(Convert.ToInt16(TCVE_ESQIMPU.Text), PREC)
                PREC = ABONO_NETO_SIN_IVA

                M1 = IIf(IsNumeric(MONTOA1), Convert.ToDecimal(MONTOA1), 0)
                If ChCAUSA_IVA1.Checked Then
                    IVA1 = M1 * IIf(IsNumeric(TIVAC1.Value), Convert.ToDecimal(TIVAC1.Value), 0) / 100
                End If
                If ChCAUSA_RET1.Checked Then
                    RET1 = M1 * IIf(IsNumeric(TRET1.Value), Convert.ToDecimal(TRET1.Value), 0) / 100
                End If

                M2 = IIf(IsNumeric(MONTOA2), Convert.ToDecimal(MONTOA2), 0)
                If ChCAUSA_IVA2.Checked Then
                    IVA2 = M2 * IIf(IsNumeric(TIVAC2.Value), Convert.ToDecimal(TIVAC2.Value), 0) / 100
                End If
                If ChCAUSA_RET2.Checked Then
                    RET2 = M2 * IIf(IsNumeric(TRET2.Value), Convert.ToDecimal(TRET2.Value), 0) / 100
                End If

                M3 = IIf(IsNumeric(MONTOA3), Convert.ToDecimal(MONTOA3), 0)
                If ChCAUSA_IVA3.Checked Then
                    IVA3 = M3 * IIf(IsNumeric(TIVAC3.Value), Convert.ToDecimal(TIVAC3.Value), 0) / 100
                End If
                If ChCAUSA_RET3.Checked Then
                    RET3 = M3 * IIf(IsNumeric(TRET3.Value), Convert.ToDecimal(TRET3.Value), 0) / 100
                End If

                M4 = IIf(IsNumeric(MONTOA4), Convert.ToDecimal(MONTOA4), 0)
                If ChCAUSA_IVA4.Checked Then
                    IVA4 = M4 * IIf(IsNumeric(TIVAC4.Value), Convert.ToDecimal(TIVAC4.Value), 0) / 100
                End If
                If ChCAUSA_RET4.Checked Then
                    RET4 = M4 * IIf(IsNumeric(TRET4.Value), Convert.ToDecimal(TRET4.Value), 0) / 100
                End If

                M5 = IIf(IsNumeric(MONTOA5), Convert.ToDecimal(MONTOA5), 0)
                If ChCAUSA_IVA5.Checked Then
                    IVA5 = M5 * IIf(IsNumeric(TIVAC5.Value), Convert.ToDecimal(TIVAC5.Value), 0) / 100
                End If
                If ChCAUSA_RET5.Checked Then
                    RET5 = M5 * IIf(IsNumeric(TRET5.Value), Convert.ToDecimal(TRET5.Value), 0) / 100
                End If

                M6 = IIf(IsNumeric(MONTOA6), Convert.ToDecimal(MONTOA6), 0)
                If ChCAUSA_IVA6.Checked Then
                    IVA6 = M6 * IIf(IsNumeric(TIVAC6.Value), Convert.ToDecimal(TIVAC6.Value), 0) / 100
                End If
                If ChCAUSA_RET6.Checked Then
                    RET6 = M6 * IIf(IsNumeric(TRET6.Value), Convert.ToDecimal(TRET6.Value), 0) / 100
                End If

                IMPORTE_CONCEP = M1 + M2 + M3 + M4 + M5 + M6

                cIeps = (PREC + IMPORTE_CONCEP) * vIMPU1 / 100
                cImpu2 = (PREC + IMPORTE_CONCEP) * vIMPU2 / 100
                cImpu3 = (PREC + IMPORTE_CONCEP) * vIMPU3 / 100
                cImpu = (PREC + IMPORTE_CONCEP) * vIMPU4 / 100

                TSUBT_O.Value = PREC + M1 + M2 + M3 + M4 + M5 + M6
                TIVA_O.Value = cImpu + IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                TRET_O.Value = cImpu2 + cImpu3 + RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                TNETO_O.Value = PREC + IMPORTE_CONCEP + TIVA_O.Value + TRET_O.Value


                ABONO_NETO_SIN_IVA = QUITAR_IMPUESTO_BUENO(Convert.ToInt16(TCVE_ESQIMPU.Text), ABONO_NETO)

                ABONO_NETO = ABONO_NETO_SIN_IVA

                cIeps = ABONO_NETO * vIMPU1 / 100
                cImpu2 = ABONO_NETO * vIMPU2 / 100
                cImpu3 = ABONO_NETO * vIMPU3 / 100
                cImpu = ABONO_NETO * vIMPU4 / 100

                TSUBT_O2.Value = ABONO_NETO
                TIVA_O2.Value = cImpu '+ IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                TRET_O2.Value = cImpu2 + cImpu3 '+ RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                TNETO_O2.Value = ABONO_NETO + TIVA_O2.Value + TRET_O2.Value

                TSALDO_SUBTOTAL.Value = TSUBT_O.Value - TSUBT_O2.Value
                TSALDO_IVA.Value = TIVA_O.Value - TIVA_O2.Value
                TSALDO_RET.Value = TRET_O.Value - TRET_O2.Value
                TSALDO_NETO.Value = TNETO_O.Value - TNETO_O2.Value

            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CALCULO_ESCENARIO3_PAGOS_PARCIALES()
        Dim PREC As Decimal

        If Not ACEPTA_CALCULO Then
            Return
        End If
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text) Then
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
                        End If
                    End Using
                End Using
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            PREC = 0
            TSUBT_O.Value = PREC
            TIVA_O.Value = PREC * 0.16
            TRET_O.Value = PREC * -0.04
            TNETO_O.Value = TSUBT_O.Value + TIVA_O.Value + TRET_O.Value
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TIMPORTE_CONCEP_TextChanged(sender As Object, e As EventArgs) Handles TIMPORTE_CONCEP.TextChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Try
            If Not IsNothing(TIMPORTE_CONCEP.Text) Then
                If IsNumeric(TIMPORTE_CONCEP.Text) Then
                    TFLETE_TextChanged(Nothing, Nothing)
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TVOLUMEN_PESO_TextChanged(sender As Object, e As EventArgs) Handles TVOLUMEN_PESO.TextChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Try
            If RadPrecioXTonelada.Checked Then
                If TVOLUMEN_PESO.Value > 0 Then
                    TFLETE.Value = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                    TFLETE.Tag = TAR_X_TON_FULL * TVOLUMEN_PESO.Value
                End If
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFLETE_Leave(sender As Object, e As EventArgs) Handles TFLETE.Leave
        If Not ENTRA_CALCULOS Then
            Return
        End If

        CALCULOS_TEXTCHANGED(1, "")
    End Sub
    Private Sub TFLETE_TextChanged(sender As Object, e As EventArgs) Handles TFLETE.TextChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        CALCULOS_TEXTCHANGED(1, "MX")

    End Sub

    Sub CALCULOS_TEXTCHANGED(FOP As Integer, MONEDA As String)
        Dim PREC As Decimal, cIeps As Decimal, cImpu As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, Sigue As Boolean
        Dim M1 As Decimal, M2 As Decimal, M3 As Decimal, M4 As Decimal, M5 As Decimal, M6 As Decimal, FLETE As Decimal
        Dim IVA1 As Decimal = 0, IVA2 As Decimal = 0, IVA3 As Decimal = 0, IVA4 As Decimal = 0, IVA5 As Decimal = 0, IVA6 As Decimal = 0
        Dim RET1 As Decimal = 0, RET2 As Decimal = 0, RET3 As Decimal = 0, RET4 As Decimal = 0, RET5 As Decimal = 0, RET6 As Decimal = 0

        If Not ACEPTA_CALCULO Then
            Return
        End If

        Try
            TVOLUMEN_PESO.UpdateValueWithCurrentText()
            TMONTO1.UpdateValueWithCurrentText()
            TMONTO2.UpdateValueWithCurrentText()
            TMONTO3.UpdateValueWithCurrentText()
            TMONTO4.UpdateValueWithCurrentText()
            TMONTO5.UpdateValueWithCurrentText()
            TMONTO6.UpdateValueWithCurrentText()
            TRET1.UpdateValueWithCurrentText()
            TRET2.UpdateValueWithCurrentText()
            TRET3.UpdateValueWithCurrentText()
            TRET4.UpdateValueWithCurrentText()
            TRET5.UpdateValueWithCurrentText()
            TRET6.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 AndAlso IsNumeric(TCVE_ESQIMPU.Text) Then
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
            End If

            If FOP = 1 Then
                If Not IsNothing(TFLETE.Text) AndAlso IsNumeric(TFLETE.Text) AndAlso TFLETE.Text <> "" Then
                    FLETE = TFLETE.Text
                Else
                    FLETE = 0
                End If
            Else
                If Not IsNothing(TFLETE.Value) AndAlso IsNumeric(TFLETE.Value) AndAlso TFLETE.Text <> "" Then
                    FLETE = TFLETE.Value
                Else
                    FLETE = 0
                End If
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If Not String.IsNullOrEmpty(FLETE) AndAlso IsNumeric(FLETE) Then

                PREC = FLETE

                If RadPrecioXViaje.Checked Then
                    MONTO_X_VIAJE = FLETE
                Else
                    MONTO_X_TON = FLETE
                End If

                PREC = Math.Round(CDec(PREC), 8)

                M1 = IIf(IsNumeric(TMONTO1.Value), Convert.ToDecimal(TMONTO1.Value), 0)
                If ChCAUSA_IVA1.Checked Then
                    IVA1 = M1 * IIf(Not IsNothing(TIVAC1.Value) AndAlso IsNumeric(TIVAC1.Value), TIVAC1.Value, 0) / 100
                End If
                If ChCAUSA_RET1.Checked Then
                    RET1 = M1 * IIf(IsNumeric(TRET1.Value), Convert.ToDecimal(TRET1.Value), 0) / 100
                End If

                M2 = IIf(IsNumeric(TMONTO2.Value), Convert.ToDecimal(TMONTO2.Value), 0)
                If ChCAUSA_IVA2.Checked Then
                    IVA2 = M2 * IIf(Not IsNothing(TIVAC2.Value) AndAlso IsNumeric(TIVAC2.Value), TIVAC2.Value, 0) / 100
                End If
                If ChCAUSA_RET2.Checked Then
                    RET2 = M2 * IIf(IsNumeric(TRET2.Value), Convert.ToDecimal(TRET2.Value), 0) / 100
                End If

                M3 = IIf(IsNumeric(TMONTO3.Value), Convert.ToDecimal(TMONTO3.Value), 0)
                If ChCAUSA_IVA3.Checked Then
                    IVA3 = M3 * IIf(Not IsNothing(TIVAC3.Value) AndAlso IsNumeric(TIVAC3.Value), TIVAC3.Value, 0) / 100
                End If
                If ChCAUSA_RET3.Checked Then
                    RET3 = M3 * IIf(IsNumeric(TRET3.Value), Convert.ToDecimal(TRET3.Value), 0) / 100
                End If

                M4 = IIf(IsNumeric(TMONTO4.Value), Convert.ToDecimal(TMONTO4.Value), 0)
                If ChCAUSA_IVA4.Checked Then
                    IVA4 = M4 * IIf(Not IsNothing(TIVAC4.Value) AndAlso IsNumeric(TIVAC4.Value), TIVAC4.Value, 0) / 100
                End If
                If ChCAUSA_RET4.Checked Then
                    RET4 = M4 * IIf(IsNumeric(TRET4.Value), Convert.ToDecimal(TRET4.Value), 0) / 100
                End If

                M5 = IIf(IsNumeric(TMONTO5.Value), Convert.ToDecimal(TMONTO5.Value), 0)
                If ChCAUSA_IVA5.Checked Then
                    IVA5 = M5 * IIf(Not IsNothing(TIVAC5.Value) AndAlso IsNumeric(TIVAC5.Value), TIVAC5.Value, 0) / 100
                End If
                If ChCAUSA_RET5.Checked Then
                    RET5 = M5 * IIf(IsNumeric(TRET5.Value), Convert.ToDecimal(TRET5.Value), 0) / 100
                End If

                M6 = IIf(IsNumeric(TMONTO6.Value), Convert.ToDecimal(TMONTO6.Value), 0)
                If ChCAUSA_IVA6.Checked Then
                    IVA6 = M6 * IIf(Not IsNothing(TIVAC6.Value) AndAlso IsNumeric(TIVAC6.Value), TIVAC6.Value, 0) / 100
                End If
                If ChCAUSA_RET6.Checked Then
                    RET6 = M6 * IIf(IsNumeric(TRET6.Value), Convert.ToDecimal(TRET6.Value), 0) / 100
                End If

                TIMPORTE_CONCEP.Value = M1 + M2 + M3 + M4 + M5 + M6

                PREC += TIMPORTE_CONCEP.Value

                cIeps = PREC * vIMPU1 / 100
                cImpu2 = PREC * vIMPU2 / 100
                cImpu3 = PREC * vIMPU3 / 100
                cImpu = PREC * vIMPU4 / 100

                TSUB_TOTAL.Value = PREC + M1 + M2 + M3 + M4 + M5 + M6
                TIVA.Value = cIeps + cImpu + IVA1 + IVA2 + IVA3 + IVA4 + IVA5 + IVA6
                TRET.Value = cImpu2 + cImpu3 + RET1 + RET2 + RET3 + RET4 + RET5 + RET6
                TNETO.Value = TSUB_TOTAL.Value + TIVA.Value + TRET.Value

                If ESCENARIO = 3 Then
                    'TFLETEA.Value = TNETO.Value
                End If
            End If
        Catch ex As Exception
            Bitacora("416. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("416. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RadPrecioXViaje_CheckedChanged(sender As Object, e As EventArgs) Handles RadPrecioXViaje.CheckedChanged

        If Not ENTRA_CALCULOS Then
            Return
        End If
        Try
            CALCULAR_NUEVO_ESQUEMA()
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub RadPrecioXTonelada_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadPrecioXTonelada.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Try
            CARGAR_TARIFAS(TCVE_TAB_VIAJE.Text)

            CALCULAR_NUEVO_ESQUEMA()

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BtnBorrarMercancias_Click(sender As Object, e As EventArgs) Handles BtnBorrarMercancias.Click

        BtnBorrarMercancias.Enabled = False

        If Not DOC_NEW Then
            If MsgBox("Realmente desea borrar las marcancias del viaje " & LtCVE_VIAJE.Text & "?", vbYesNo) = vbYes Then
                Try
                    Fg.Rows.Count = 1

                    SQL = "DELETE FROM GCMERCANCIAS WHERE CVE_VIAJE = '" & LtCVE_VIAJE.Text & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If Convert.ToInt32(returnValue) > 0 Then
                                'MsgBox("Las mercancias se eliminaron correctamente")
                            End If
                        End If
                    End Using
                    MsgBox("Las mercancias se eliminaron correctamente")
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                End Try
            End If
        Else
            MsgBox("Por favor primero grabe el viaje")
        End If

        BtnBorrarMercancias.Enabled = True
    End Sub
    Private Sub BtnUsoCFDI_Click(sender As Object, e As EventArgs) Handles BtnUsoCFDI.Click
        Try
            Var2 = "USOCFDI"
            Var4 = ""
            FrmSelItem22.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUSO_CFDI.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarCopiarViaje_Click(sender As Object, e As ClickEventArgs) Handles BarCopiarViaje.Click
        Try
            Var2 = "Copiar viaje"
            Var24 = ""
            Var44 = 0
            Var19 = "MOSTRAR TODOS"
            FrmSelViaje.ShowDialog()
            If Var24.Trim.Length > 0 Then

                If MsgBox("Realmente desea copiar el o los viajes desde el viaje " & Var44, vbYesNo) = vbYes Then
                    VIAJES_A_COPIAR = Var44

                    SeCopio = "S"

                    If VIAJES_A_COPIAR = 1 Then
                        DESPLEGAR_VIAJE(Var24)

                        BarCopiarViaje.Enabled = False
                    Else
                        If VIAJES_A_COPIAR > 1 Then

                            DESPLEGAR_VIAJE(Var24)

                            Threading.Thread.Sleep(3000)

                            GUARDAR_VIAJE_AUTOMATICO()

                            BarCopiarViaje.Enabled = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TUSO_CFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles TUSO_CFDI.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUsoCFDI_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnPagoSAT_Click(sender As Object, e As EventArgs) Handles BtnPagoSAT.Click
        Try
            Var2 = "PagoSAT"

            frmUsoCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TFORMADEPAGOSAT.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TUSO_CFDI_Validated(sender As Object, e As EventArgs) Handles TUSO_CFDI.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("USO CFDI", TUSO_CFDI.Text)
            If DESCR = "N" Or DESCR = "" Then
                MsgBox("Uso CFDI inexistente")
                TUSO_CFDI.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TFORMADEPAGOSAT_KeyDown(sender As Object, e As KeyEventArgs) Handles TFORMADEPAGOSAT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPagoSAT_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BarMetodoPago_Click(sender As Object, e As EventArgs) Handles BarMetodoPago.Click
        Try
            Var2 = "Metodo de pago"
            Var4 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMETODODEPAGO.Text = Var4
                Var2 = ""
                Var4 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TFORMADEPAGOSAT_Validated(sender As Object, e As EventArgs) Handles TFORMADEPAGOSAT.Validated
        Try
            Dim Clave As String, Descr As String = ""

            If TFORMADEPAGOSAT.Text.Trim.Length > 0 Then
                Dim doc As New XmlDocument()
                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_FORMA_PAGO.xml")
                Dim child_nodes As XmlNodeList = doc.GetElementsByTagName("row")
                Dim Existe As Boolean = False

                Dim txt As String = ""
                For Each child As XmlNode In child_nodes
                    Clave = child.Attributes("c_FormaPago").InnerXml '& " = " & child.InnerText & vbCrLf
                    Descr = child.Attributes("Descripcion").InnerXml

                    If child.Attributes("c_FormaPago").InnerXml = TFORMADEPAGOSAT.Text Then
                        Existe = True
                        Exit For
                    End If
                Next child
                If Not Existe Then
                    MsgBox("Forma de pago inexistemte, verifique por favor")
                    TFORMADEPAGOSAT.Text = TFORMADEPAGOSAT.Tag
                Else
                    Label70.Text = Descr
                End If
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TMETODODEPAGO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMETODODEPAGO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BarMetodoPago_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMETODODEPAGO_Validated(sender As Object, e As EventArgs) Handles TMETODODEPAGO.Validated
        Try
            If TMETODODEPAGO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Metodo de pago", TMETODODEPAGO.Text)
                If DESCR <> "N" And DESCR <> "" Then

                Else
                    MsgBox("Metodo de pago inexistente")
                    TMETODODEPAGO.Text = ""
                    TUSO_CFDI.Focus()
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCopiarCamposAdic_Click(sender As Object, e As EventArgs) Handles BtnCopiarCamposAdic.Click
        Try
            Var2 = "Copiar adicionales"
            Var24 = ""
            Var19 = "MOSTRAR TODOS"
            FrmSelViaje.ShowDialog()
            If Var24.Trim.Length > 0 Then
                COPIAR_CAMPOS_ADIC_DESDE_OTRO_VIAJER(Var24)
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub COPIAR_CAMPOS_ADIC_DESDE_OTRO_VIAJER(FVIAJE As String)
        Try 'GCASIG_CAMPOS_ADIC (ID INT IDENTITY(1,1) PRIMARY KEY, CAMPO_ADIC VARCHAR(MAX)

            ENTRAA = False

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CAMPO_ADIC FROM GCASIG_CAMPOS_ADIC WHERE CVE_VIAJE = '" & FVIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgA.AddItem("" & vbTab & 0 & vbTab & dr("CAMPO_ADIC"))
                    End While
                End Using

            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        ENTRAA = True
    End Sub

    Private Sub FgA_KeyDown(sender As Object, e As KeyEventArgs) Handles FgA.KeyDown
        Try
            If Not ENTRAA Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Insert
                    FgA.AddItem("" & vbTab & 0 & vbTab & "")
                    FgA.Row = FgA.Rows.Count - 1
                Case Keys.Delete
                    FgA.RemoveItem(FgA.Row)
                Case Keys.Enter
                    e.SuppressKeyPress = True
            End Select
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgA_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgA.KeyDownEdit
        Try
            If Not ENTRAA Then
                Return
            End If

            Select Case e.KeyCode
                Case Keys.Enter
                    e.Handled = True
            End Select
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgA_EnterCell(sender As Object, e As EventArgs) Handles FgA.EnterCell
        Try
            If Not ENTRAA Then
                Return
            End If

            If FgA.Row > 0 Then
                FgA.StartEditing()
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TFOLIO_TextChanged(sender As Object, e As EventArgs) Handles TFOLIO.TextChanged
        If Not ACEPTA_CALCULO Then
            Return
        End If

        Try
            Dim FOLIO As Long, FOLIOVALUE As Long

            If FACTURA_UNO_O_MULT = "VVM" Then
                Return
            End If

            If Not IsNothing(TFOLIO.Text) AndAlso IsNumeric(TFOLIO.Text) Then

                FOLIO = Convert.ToInt64(TFOLIO.Text)
                FOLIOVALUE = TFOLIO.Value

                SQL = "SELECT ISNULL(STATUS,'') AS ST FROM GCASIGNACION_VIAJE 
                    WHERE SERIE = '" & CboSerieFactura.Text & "' AND FOLIO = " & FOLIO

                LtDisponible.Text = "DISPONIBLE"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            If dr("ST") = "C" Then
                                LtDisponible.Text = "DISPONIBLE"
                                TFOLIO.Value = FOLIO
                            Else
                                LtDisponible.Text = "NO DISPONIBLE"
                            End If
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProdServ1_Click(sender As Object, e As EventArgs) Handles BtnProdServ1.Click
        Prosec = "CATINV"
        FrmNewXCategoria.ShowDialog()
        Var10 = ""
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV1.Text = Var10
        End If
    End Sub
    Private Sub BtnProdServ2_Click(sender As Object, e As EventArgs) Handles BtnProdServ2.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV2.Text = Var10
        End If
    End Sub

    Private Sub BtnProdServ3_Click(sender As Object, e As EventArgs) Handles BtnProdServ3.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV3.Text = Var10
        End If
    End Sub

    Private Sub BtnProdServ4_Click(sender As Object, e As EventArgs) Handles BtnProdServ4.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV4.Text = Var10
        End If
    End Sub

    Private Sub BtnProdServ5_Click(sender As Object, e As EventArgs) Handles BtnProdServ5.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV5.Text = Var10
        End If
    End Sub

    Private Sub BtnProdServ6_Click(sender As Object, e As EventArgs) Handles BtnProdServ6.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV6.Text = Var10
        End If
    End Sub

    Private Sub BtnCveUni1_Click(sender As Object, e As EventArgs) Handles BtnCveUni1.Click
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD1.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCveUni2_Click(sender As Object, e As EventArgs) Handles BtnCveUni2.Click
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD2.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCveUni3_Click(sender As Object, e As EventArgs) Handles BtnCveUni3.Click
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD3.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCveUni4_Click(sender As Object, e As EventArgs) Handles BtnCveUni4.Click
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD4.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCveUni5_Click(sender As Object, e As EventArgs) Handles BtnCveUni5.Click
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD5.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCveUni6_Click(sender As Object, e As EventArgs) Handles BtnCveUni6.Click

        GroupBox1.Visible = True
        Try
            Prosec = "UNIMED"
            Var10 = ""
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD6.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TTIPO_CAMBIO_Validated(sender As Object, e As EventArgs) Handles TTIPO_CAMBIO.Validated
        Try
            CALCULAR_MONTOS()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TAB1.SelectedIndexChanged

        If Not ENTRA_CALCULOS Then
            Return
        End If
        Try
            Select Case TAB1.SelectedIndex
                Case 0
                    TFOLIO_VIAJE.Enabled = False
                    BtnSelViaje.Enabled = False
                Case 1
                    If LtTimbrado.Text = "FACTURADO" Or LtTimbrado.Text = "TIMBRADO" Or LtStatus.Text = "Cancelado" Or LtStatus.Text = "LIQUIDADO" Then
                        TFOLIO_VIAJE.Enabled = False
                        BtnSelViaje.Enabled = False
                    Else
                        TFOLIO_VIAJE.Enabled = True
                        BtnSelViaje.Enabled = True
                    End If
                Case 5 'IMPORTES
                    DESPLEGA_IMPORTE_RUTA()

                    If TFLETEA.Value < 1 And ESCENARIO = 3 Then


                        TABONO_NETO.Enabled = False
                        TFOLIO.Enabled = False
                        CboSerieFactura.Enabled = False

                        CboConc1.Enabled = False
                        CboConc2.Enabled = False
                        CboConc3.Enabled = False
                        CboConc4.Enabled = False
                        CboConc5.Enabled = False
                        CboConc6.Enabled = False
                        TMONTO1.Enabled = False
                        TMONTO2.Enabled = False
                        TMONTO3.Enabled = False
                        TMONTO4.Enabled = False
                        TMONTO5.Enabled = False
                        TMONTO6.Enabled = False

                        ChCAUSA_IVA1.Enabled = False : ChCAUSA_RET1.Enabled = False : TIVAC1.Enabled = False : TRET1.Enabled = False : TCVE_PRODSERV1.Enabled = False : BtnProdServ1.Enabled = False : TCVE_UNIDAD1.Enabled = False : BtnCveUni1.Enabled = False
                        ChCAUSA_IVA2.Enabled = False : ChCAUSA_RET2.Enabled = False : TIVAC2.Enabled = False : TRET2.Enabled = False : TCVE_PRODSERV2.Enabled = False : BtnProdServ2.Enabled = False : TCVE_UNIDAD2.Enabled = False : BtnCveUni2.Enabled = False
                        ChCAUSA_IVA3.Enabled = False : ChCAUSA_RET3.Enabled = False : TIVAC3.Enabled = False : TRET3.Enabled = False : TCVE_PRODSERV3.Enabled = False : BtnProdServ3.Enabled = False : TCVE_UNIDAD3.Enabled = False : BtnCveUni3.Enabled = False
                        ChCAUSA_IVA4.Enabled = False : ChCAUSA_RET4.Enabled = False : TIVAC4.Enabled = False : TRET4.Enabled = False : TCVE_PRODSERV4.Enabled = False : BtnProdServ4.Enabled = False : TCVE_UNIDAD4.Enabled = False : BtnCveUni4.Enabled = False
                        ChCAUSA_IVA5.Enabled = False : ChCAUSA_RET5.Enabled = False : TIVAC5.Enabled = False : TRET5.Enabled = False : TCVE_PRODSERV5.Enabled = False : BtnProdServ5.Enabled = False : TCVE_UNIDAD5.Enabled = False : BtnCveUni5.Enabled = False
                        ChCAUSA_IVA6.Enabled = False : ChCAUSA_RET6.Enabled = False : TIVAC6.Enabled = False : TRET6.Enabled = False : TCVE_PRODSERV6.Enabled = False : BtnProdServ6.Enabled = False : TCVE_UNIDAD6.Enabled = False : BtnCveUni6.Enabled = False

                        BtnEsquema.Enabled = False
                        TCVE_ESQIMPU.Enabled = False
                    Else
                        Dim Efecto As Boolean

                        If LtTimbrado.Text = "TIMBRADO" Or LtTimbrado.Text = "FACTURADO" Or LtStatus.Text = "Cancelado" Or LtStatus.Text = "LIQUIDADO" Then
                            Efecto = False
                        Else
                            Efecto = True
                        End If

                        ' TABONO_NETO.Enabled = Efecto
                        'TFOLIO.Enabled = Efecto
                        'CboSerieFactura.Enabled = Efecto

                        CboConc1.Enabled = Efecto
                        CboConc2.Enabled = Efecto
                        CboConc3.Enabled = Efecto
                        CboConc4.Enabled = Efecto
                        CboConc5.Enabled = Efecto
                        CboConc6.Enabled = Efecto
                        TMONTO1.Enabled = Efecto
                        TMONTO2.Enabled = Efecto
                        TMONTO3.Enabled = Efecto
                        TMONTO4.Enabled = Efecto
                        TMONTO5.Enabled = Efecto
                        TMONTO6.Enabled = Efecto
                        ChCAUSA_IVA1.Enabled = Efecto : ChCAUSA_RET1.Enabled = Efecto : TIVAC1.Enabled = Efecto : TRET1.Enabled = Efecto : TCVE_PRODSERV1.Enabled = Efecto : BtnProdServ1.Enabled = Efecto : TCVE_UNIDAD1.Enabled = Efecto : BtnCveUni1.Enabled = Efecto
                        ChCAUSA_IVA2.Enabled = Efecto : ChCAUSA_RET2.Enabled = Efecto : TIVAC2.Enabled = Efecto : TRET2.Enabled = Efecto : TCVE_PRODSERV2.Enabled = Efecto : BtnProdServ2.Enabled = Efecto : TCVE_UNIDAD2.Enabled = Efecto : BtnCveUni2.Enabled = Efecto
                        ChCAUSA_IVA3.Enabled = Efecto : ChCAUSA_RET3.Enabled = Efecto : TIVAC3.Enabled = Efecto : TRET3.Enabled = Efecto : TCVE_PRODSERV3.Enabled = Efecto : BtnProdServ3.Enabled = Efecto : TCVE_UNIDAD3.Enabled = Efecto : BtnCveUni3.Enabled = Efecto
                        ChCAUSA_IVA4.Enabled = Efecto : ChCAUSA_RET4.Enabled = Efecto : TIVAC4.Enabled = Efecto : TRET4.Enabled = Efecto : TCVE_PRODSERV4.Enabled = Efecto : BtnProdServ4.Enabled = Efecto : TCVE_UNIDAD4.Enabled = Efecto : BtnCveUni4.Enabled = Efecto
                        ChCAUSA_IVA5.Enabled = Efecto : ChCAUSA_RET5.Enabled = Efecto : TIVAC5.Enabled = Efecto : TRET5.Enabled = Efecto : TCVE_PRODSERV5.Enabled = Efecto : BtnProdServ5.Enabled = Efecto : TCVE_UNIDAD5.Enabled = Efecto : BtnCveUni5.Enabled = Efecto
                        ChCAUSA_IVA6.Enabled = Efecto : ChCAUSA_RET6.Enabled = Efecto : TIVAC6.Enabled = Efecto : TRET6.Enabled = Efecto : TCVE_PRODSERV6.Enabled = Efecto : BtnProdServ6.Enabled = Efecto : TCVE_UNIDAD6.Enabled = Efecto : BtnCveUni6.Enabled = Efecto
                        BtnEsquema.Enabled = Efecto
                        TCVE_ESQIMPU.Enabled = Efecto
                    End If

                Case 6

                    TFOLIO_VIAJE.Enabled = False
                    BtnSelViaje.Enabled = False
                    SendKeys.Send("{TAB}")
                    FgA.Focus()
                    FgA.Select()
                    FgA.Row = 1
                    FgA.Col = 2
                    FgA.Focus()
                Case Else
                    TFOLIO_VIAJE.Enabled = False
                    BtnSelViaje.Enabled = False
            End Select
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboConc1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc1.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        Try
            Dim CVE_COBRO As Integer

            If CboConc1.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc1.Items(CboConc1.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, IVA, CAUSA_RET, RET, CVE_PRODSERV, CVE_UNIDAD  
                        FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA1.Checked = True
                                TIVAC1.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA1.Checked = False
                                TIVAC1.Value = 0 'IMPUESTO
                            End If
                            TIVAC1.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET1.Checked = True
                                TRET1.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET1.Checked = False
                                TRET1.Value = 0
                            End If
                            TRET1.Tag = TRET1.Value

                            TCVE_PRODSERV1.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD1.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO1.Value = 0
                            TIVAC1.Value = 0
                            TRET1.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO1.Focus()
            Else
                ChCAUSA_IVA1.Checked = False
                ChCAUSA_RET1.Checked = False
                TCVE_PRODSERV1.Value = ""
                TCVE_UNIDAD1.Value = ""

                TMONTO1.Value = 0
                TIVAC1.Value = 0
                TRET1.Value = 0

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboConc2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc2.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Dim CVE_COBRO As Integer
        Try
            If CboConc2.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc2.Items(CboConc2.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA, RET 
                    FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA2.Checked = True
                                TIVAC1.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA2.Checked = False
                                TIVAC2.Value = 0 'IMPUESTO
                            End If
                            TIVAC2.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET2.Checked = True
                                TRET2.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET2.Checked = False
                                TRET2.Value = 0
                            End If
                            TRET2.Tag = TRET2.Value

                            TCVE_PRODSERV2.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD2.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO2.Value = 0
                            TIVAC2.Value = 0
                            TRET2.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO2.Focus()
            Else
                ChCAUSA_IVA2.Checked = False
                ChCAUSA_RET2.Checked = False
                TMONTO2.Value = 0
                TIVAC2.Value = 0
                TRET2.Value = 0
                TCVE_PRODSERV2.Value = ""
                TCVE_UNIDAD2.Value = ""
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub CboConc3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc3.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Dim CVE_COBRO As Integer
        Try
            If CboConc3.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc3.Items(CboConc3.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA, RET 
                    FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA3.Checked = True
                                TIVAC3.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA3.Checked = False
                                TIVAC3.Value = 0 'IMPUESTO
                            End If
                            TIVAC3.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET3.Checked = True
                                TRET3.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET3.Checked = False
                                TRET3.Value = 0
                            End If
                            TRET3.Tag = TRET3.Value

                            TCVE_PRODSERV3.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD3.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO3.Value = 0
                            TIVAC3.Value = 0
                            TRET3.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO3.Focus()
            Else
                ChCAUSA_IVA3.Checked = False
                ChCAUSA_RET3.Checked = False
                TMONTO3.Value = 0
                TIVAC3.Value = 0
                TRET3.Value = 0
                TCVE_PRODSERV3.Value = ""
                TCVE_UNIDAD3.Value = ""
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboConc4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc4.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Dim CVE_COBRO As Integer
        Try
            If CboConc4.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc4.Items(CboConc4.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA, RET 
                    FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA4.Checked = True
                                TIVAC4.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA4.Checked = False
                                TIVAC4.Value = 0 'IMPUESTO
                            End If
                            TIVAC4.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET4.Checked = True
                                TRET4.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET4.Checked = False
                                TRET4.Value = 0
                            End If
                            TRET4.Tag = TRET4.Value

                            TCVE_PRODSERV4.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD4.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO4.Value = 0
                            TIVAC4.Value = 0
                            TRET4.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO4.Focus()
            Else
                ChCAUSA_IVA3.Checked = False
                ChCAUSA_RET3.Checked = False
                TMONTO3.Value = 0
                TIVAC3.Value = 0
                TRET3.Value = 0
                TCVE_PRODSERV3.Value = ""
                TCVE_UNIDAD3.Value = ""
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub CboConc5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc5.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Dim CVE_COBRO As Integer
        Try

            If CboConc5.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc5.Items(CboConc5.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA, RET 
                    FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA5.Checked = True
                                TIVAC5.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA5.Checked = False
                                TIVAC5.Value = 0 'IMPUESTO
                            End If
                            TIVAC5.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET5.Checked = True
                                TRET5.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET5.Checked = False
                                TRET5.Value = 0
                            End If
                            TRET5.Tag = TRET5.Value

                            TCVE_PRODSERV5.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD5.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO5.Value = 0
                            TIVAC5.Value = 0
                            TRET5.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO5.Focus()
            Else
                ChCAUSA_IVA5.Checked = False
                ChCAUSA_RET5.Checked = False
                TMONTO5.Value = 0
                TIVAC5.Value = 0
                TRET5.Value = 0
                TCVE_PRODSERV5.Value = ""
                TCVE_UNIDAD5.Value = ""
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboConc6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboConc6.SelectedIndexChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If
        Dim CVE_COBRO As Integer
        Try
            If CboConc6.SelectedIndex > 0 Then
                CVE_COBRO = CInt(CboConc6.Items(CboConc6.SelectedIndex))
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CAUSA_IVA, CAUSA_RET, CVE_PRODSERV, CVE_UNIDAD, IVA, RET 
                    FROM GCASIGCONCEP_COBRO WHERE CVE_COBRO = " & CVE_COBRO
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then

                            If dr.ReadNullAsEmptyInteger("CAUSA_IVA") = 1 Then
                                ChCAUSA_IVA6.Checked = True
                                TIVAC6.Value = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO
                            Else
                                ChCAUSA_IVA6.Checked = False
                                TIVAC6.Value = 0 'IMPUESTO
                            End If
                            TIVAC6.Tag = dr.ReadNullAsEmptyDecimal("IVA") 'IMPUESTO

                            If dr.ReadNullAsEmptyInteger("CAUSA_RET") = 1 Then
                                ChCAUSA_RET6.Checked = True
                                TRET6.Value = dr.ReadNullAsEmptyDecimal("RET") 'IMPUESTO
                            Else
                                ChCAUSA_RET6.Checked = False
                                TRET6.Value = 0
                            End If
                            TRET6.Tag = TRET6.Value

                            TCVE_PRODSERV6.Value = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            TCVE_UNIDAD6.Value = dr.ReadNullAsEmptyString("CVE_UNIDAD")
                        Else
                            TMONTO6.Value = 0
                            TIVAC6.Value = 0
                            TRET6.Value = 0
                        End If
                    End Using
                End Using

                If ESCENARIO = 3 Then
                    CALCULOS_TEXTCHANGED(1, "MX")
                End If

                TMONTO6.Focus()
            Else
                ChCAUSA_IVA6.Checked = False
                ChCAUSA_RET6.Checked = False
                TMONTO6.Value = 0
                TIVAC6.Value = 0
                TRET6.Value = 0
                TCVE_PRODSERV6.Value = ""
                TCVE_UNIDAD6.Value = ""
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub CALCULOS_CONCEPTOS(FOP As Integer)
        Try
            Dim SUMA As Decimal = 0
            Select Case FOP
                Case 1
                    SUMA = TMONTO1.Text + TMONTO2.Value + TMONTO3.Value + TMONTO4.Value + TMONTO5.Value + TMONTO6.Value
                Case 2
                    SUMA = TMONTO1.Value + TMONTO2.Text + TMONTO3.Value + TMONTO4.Value + TMONTO5.Value + TMONTO6.Value
                Case 3
                    SUMA = TMONTO1.Value + TMONTO2.Value + TMONTO3.Text + TMONTO4.Value + TMONTO5.Value + TMONTO6.Value
                Case 4
                    SUMA = TMONTO1.Value + TMONTO2.Value + TMONTO3.Value + TMONTO4.Text + TMONTO5.Value + TMONTO6.Value
                Case 5
                    SUMA = TMONTO1.Value + TMONTO2.Value + TMONTO3.Value + TMONTO4.Value + TMONTO5.Text + TMONTO6.Value
                Case 6
                    SUMA = TMONTO1.Value + TMONTO2.Value + TMONTO3.Value + TMONTO4.Value + TMONTO5.Value + TMONTO6.Text
            End Select

            TIMPORTE_CONCEP.Value = SUMA
            TSUB_TOTAL.Value = TFLETE.Value + SUMA


        Catch ex As Exception
        End Try
    End Sub
    Private Sub TMONTO1_TextChanged(sender As Object, e As EventArgs) Handles TMONTO1.TextChanged
        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then

            CALCULOS_TEXTCHANGED(1, "MEX")

        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TMONTO2_TextChanged(sender As Object, e As EventArgs) Handles TMONTO2.TextChanged
        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MEX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TMONTO3_TextChanged(sender As Object, e As EventArgs) Handles TMONTO3.TextChanged

        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MEX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TMONTO4_TextChanged(sender As Object, e As EventArgs) Handles TMONTO4.TextChanged

        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MEX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TMONTO5_TextChanged(sender As Object, e As EventArgs) Handles TMONTO5.TextChanged

        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MEX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TMONTO6_TextChanged(sender As Object, e As EventArgs) Handles TMONTO6.TextChanged

        If Not ACEPTA_CALCULO Then
            Return
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MEX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub TRET1_TextChanged(sender As Object, e As EventArgs) Handles TRET1.TextChanged
    End Sub
    Private Sub TRET2_TextChanged(sender As Object, e As EventArgs) Handles TRET2.TextChanged
        'CALCULAR_NUEVO_ESQUEMA()
    End Sub
    Private Sub TRET3_TextChanged(sender As Object, e As EventArgs) Handles TRET3.TextChanged
        'CALCULAR_NUEVO_ESQUEMA()
    End Sub
    Private Sub TRET4_TextChanged(sender As Object, e As EventArgs) Handles TRET4.TextChanged
        'CALCULAR_NUEVO_ESQUEMA()
    End Sub
    Private Sub TRET5_TextChanged(sender As Object, e As EventArgs) Handles TRET5.TextChanged
        'CALCULAR_NUEVO_ESQUEMA()
    End Sub
    Private Sub TRET6_TextChanged(sender As Object, e As EventArgs) Handles TRET6.TextChanged
        'CALCULAR_NUEVO_ESQUEMA()
    End Sub
    Private Sub BtnCveProd_Click(sender As Object, e As EventArgs) Handles BtnCveProd.Click
        Prosec = "CATINV"
        Var10 = ""
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV.Text = Var10
        End If
    End Sub

    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles BtnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESQIMPU.Text = Var4
                TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                LtEsquema.Text = Var5

                If ESCENARIO = 3 Then
                    CALCULO_ESCENARIO3(1)

                    TSUBT_O.Value = 0
                    TIVA_O.Value = 0
                    TRET_O.Value = 0
                    TNETO_O.Value = 0

                    TSUBT_O2.Value = 0
                    TIVA_O2.Value = 0
                    TRET_O2.Value = 0
                    TNETO_O2.Value = 0

                    TSALDO_SUBTOTAL.Value = 0
                    TSALDO_IVA.Value = 0
                    TSALDO_RET.Value = 0
                    TSALDO_NETO.Value = 0
                    TABONO_NETO.Value = 0
                    TFLETEA.Value = 0

                    CALCULOS_TEXTCHANGED(1, "MX")

                    CARGAR_ABONOS_ESCENARIO3(LtCVE_VIAJE.Text)

                Else
                    CALCULAR_NUEVO_ESQUEMA()
                End If
                Var2 = ""
                Var4 = ""
                Var5 = ""
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

                    If ESCENARIO = 3 Then
                        CALCULO_ESCENARIO3(1)

                        TSUBT_O.Value = 0
                        TIVA_O.Value = 0
                        TRET_O.Value = 0
                        TNETO_O.Value = 0

                        TSUBT_O2.Value = 0
                        TIVA_O2.Value = 0
                        TRET_O2.Value = 0
                        TNETO_O2.Value = 0

                        TSALDO_SUBTOTAL.Value = 0
                        TSALDO_IVA.Value = 0
                        TSALDO_RET.Value = 0
                        TSALDO_NETO.Value = 0
                        TABONO_NETO.Value = 0
                        TFLETEA.Value = 0

                        CALCULOS_TEXTCHANGED(1, "MX")

                        CARGAR_ABONOS_ESCENARIO3(LtCVE_VIAJE.Text)

                    Else
                        CALCULAR_NUEVO_ESQUEMA()
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '*****************************CAUSA IVA
    Private Sub ChCAUSA_IVA1_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA1.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA1.Checked Then
            If Not IsNothing(TIVAC1.Tag) AndAlso IsNumeric(TIVAC1.Tag) Then
                TIVAC1.Value = TIVAC1.Tag
            Else
                TIVAC1.Value = 0
            End If
        Else
            TIVAC1.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_IVA2_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA2.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA2.Checked Then
            If Not IsNothing(TIVAC2.Tag) AndAlso IsNumeric(TIVAC2.Tag) Then
                TIVAC2.Value = TIVAC2.Tag
            Else
                TIVAC2.Value = 0
            End If

        Else
            TIVAC2.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_IVA3_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA3.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA3.Checked Then
            If Not IsNothing(TIVAC3.Tag) AndAlso IsNumeric(TIVAC3.Tag) Then
                TIVAC3.Value = TIVAC3.Tag
            Else
                TIVAC3.Value = 0
            End If
        Else
            TIVAC3.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_IVA4_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA4.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA4.Checked Then
            If Not IsNothing(TIVAC4.Tag) AndAlso IsNumeric(TIVAC4.Tag) Then
                TIVAC4.Value = TIVAC4.Tag
            Else
                TIVAC4.Value = 0
            End If
        Else
            TIVAC4.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_IVA5_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA5.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA5.Checked Then
            If Not IsNothing(TIVAC5.Tag) AndAlso IsNumeric(TIVAC5.Tag) Then
                TIVAC5.Value = TIVAC5.Tag
            Else
                TIVAC5.Value = 0
            End If
        Else
            TIVAC5.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_IVA6_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_IVA6.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_IVA6.Checked Then
            If Not IsNothing(TIVAC6.Tag) AndAlso IsNumeric(TIVAC6.Tag) Then
                TIVAC6.Value = TIVAC6.Tag
            Else
                TIVAC6.Value = 0
            End If
        Else
            TIVAC6.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    '*****************************CAUSA RET
    Private Sub ChCAUSA_RET1_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET1.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET1.Checked Then
            TRET1.Value = TRET1.Tag
        Else
            TRET1.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If

    End Sub
    Private Sub ChCAUSA_RET2_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET2.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET2.Checked Then
            TRET2.Value = TRET2.Tag
        Else
            TRET2.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_RET3_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET3.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET3.Checked Then
            TRET3.Value = TRET3.Tag
        Else
            TRET3.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_RET4_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET4.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET4.Checked Then
            TRET4.Value = TRET4.Tag
        Else
            TRET4.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_RET5_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET5.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET5.Checked Then
            TRET5.Value = TRET5.Tag
        Else
            TRET5.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub
    Private Sub ChCAUSA_RET6_CheckedChanged(sender As Object, e As EventArgs) Handles ChCAUSA_RET6.CheckedChanged
        If Not ENTRA_CALCULOS Then
            Return
        End If

        If ChCAUSA_RET6.Checked Then
            TRET6.Value = TRET6.Tag
        Else
            TRET6.Value = 0
        End If

        If ESCENARIO = 3 Then
            CALCULOS_TEXTCHANGED(1, "MX")
        Else
            CALCULAR_NUEVO_ESQUEMA()
        End If
    End Sub

    Private Sub FgViajes_CellChecked(sender As Object, e As RowColEventArgs) Handles FgViajes.CellChecked
        Dim z As Integer = 0
        SeCopio = ""
        Try
            If e.Row = 0 AndAlso e.Col = 1 Then
                ChangeState(FgViajes.GetCellCheck(e.Row, e.Col))
            Else
                If FgViajes.GetCellCheck(e.Row, e.Col) = C1.Win.C1FlexGrid.CheckEnum.Unchecked Then
                    For k = 1 To FgViajes.Rows.Count - 1
                        If FgViajes.GetCellCheck(k, 1) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
                            z += 1
                        End If
                        For j = Fg.Rows.Count - 1 To 1 Step -1
                            If FgViajes(k, 2) = Fg(j, 20) Then
                                Fg.RemoveItem(j)
                            End If
                        Next

                    Next
                Else
                    If FgViajes.GetCellCheck(FgViajes.Row, 1) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
                        DESPLEGAR_VIAJE(FgViajes(FgViajes.Row, 2))
                    End If
                End If
            End If
            CALCULAR_MONTOS()
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_MONTOS()
        Try
            Dim SUBT As Decimal = 0, IVA As Decimal = 0, RET As Decimal = 0, NET As Decimal = 0
            For k = 1 To FgViajes.Rows.Count - 1

                If FgViajes.GetCellCheck(k, 1) = C1.Win.C1FlexGrid.CheckEnum.Checked Then
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand

                            SQL = "SELECT ISNULL(V.SUBTOTAL,0) AS SUBT, ISNULL(V.IVA,0) AS IV, ISNULL(V.RETENCION,0) AS RET, 
                                ISNULL(V.NETO,0) AS NET, I.IMPUESTO1, I.IMPUESTO2, I.IMPUESTO3, I.IMPUESTO4
                                FROM GCASIGNACION_VIAJE V
                                LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = V.CLIENTE
                                LEFT JOIN IMPU" & Empresa & " I ON I.CVE_ESQIMPU = C.CVE_ESQIMPU
                                WHERE V.CVE_VIAJE = '" & FgViajes(k, 2) & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    vIMPU1 = dr("IMPUESTO1")
                                    vIMPU2 = dr("IMPUESTO2")
                                    vIMPU3 = dr("IMPUESTO3")
                                    vIMPU4 = dr("IMPUESTO4")

                                    SUBT += dr("SUBT")
                                    IVA += dr("SUBT") * vIMPU4 / 100
                                    RET += dr("SUBT") * vIMPU3 / 100
                                    NET += dr("SUBT") + (dr("SUBT") * vIMPU4 / 100) + (dr("SUBT") * vIMPU3 / 100)

                                    FgViajes(k, 5) = dr("SUBT")
                                    FgViajes(k, 6) = dr("SUBT") * vIMPU3 / 100
                                    FgViajes(k, 7) = dr("SUBT") * vIMPU4 / 100
                                    FgViajes(k, 8) = dr("SUBT") + (dr("SUBT") * vIMPU4 / 100) + (dr("SUBT") * vIMPU3 / 100)

                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
            Next

            If TCVE_MON.Text.Trim = "1" Or TCVE_MON.Text.Trim = "" Then
                TSUBT2.Value = SUBT
                TIVA2.Value = IVA
                TRETE2.Value = RET
                TNETO2.Value = NET
            Else
                TSUBT2.Value = SUBT
                TIVA2.Value = IVA
                TRETE2.Value = RET
                TNETO2.Value = NET
            End If
        Catch ex As Exception
            Bitacora("605. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub ChangeState(ByVal state As C1.Win.C1FlexGrid.CheckEnum)
        For row As Integer = FgViajes.Rows.Fixed To FgViajes.Rows.Count - 1
            FgViajes.SetCellCheck(row, 1, state)
        Next
    End Sub

    Private Sub FgViajes_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgViajes.BeforeEdit
        If FgViajes.Row > 0 Then
            If FgViajes.Col = 2 Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub TMONTOA1_TextChanged(sender As Object, e As EventArgs)
        CALCULO_ESCENARIO3(1)
    End Sub

    Private Sub TMONTOA2_TextChanged(sender As Object, e As EventArgs)
        CALCULO_ESCENARIO3(2)
    End Sub
    Private Sub TMONTOA3_TextChanged(sender As Object, e As EventArgs)

        CALCULO_ESCENARIO3(3)
    End Sub
    Private Sub TMONTOA4_TextChanged(sender As Object, e As EventArgs)
        CALCULO_ESCENARIO3(4)
    End Sub

    Private Sub TMONTOA5_TextChanged(sender As Object, e As EventArgs)
        CALCULO_ESCENARIO3(5)
    End Sub
    Private Sub TMONTOA6_TextChanged(sender As Object, e As EventArgs)
        CALCULO_ESCENARIO3(6)
    End Sub
    Private Sub CboSerieFactura_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboSerieFactura.DropDownClosed
        Dim SIGUE As Boolean = True
        If FACTURA_UNO_O_MULT = "VVM" Then
            Return
        End If
        Try
            TFOLIO.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try
        Try            'Dim CVE_DOC As String
            If CboSerieFactura.SelectedIndex > -1 Then

                SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA
                    FROM FOLIOSF" & Empresa & "
                    WHERE TIP_DOC = 'F' AND SERIE = '" & CboSerieFactura.Text & "'"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TFOLIO.Value = dr("ULTDOC") + 1
                        End If
                    End Using
                End Using
                LtDisponible.Text = "DISPONIBLE"

                While SIGUE
                    SQL = "SELECT ISNULL(STATUS,'') AS ST FROM GCASIGNACION_VIAJE 
                        WHERE SERIE = '" & CboSerieFactura.Text & "' AND FOLIO = " & TFOLIO.Value
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                If dr("ST") = "A" Then
                                    LtDisponible.Text = "NO DISPONIBLE"
                                    TFOLIO.Value += 1
                                Else
                                    LtDisponible.Text = "DISPONIBLE"
                                End If
                            End If
                        End Using
                    End Using
                    If LtDisponible.Text = "DISPONIBLE" Then
                        SIGUE = False
                    End If
                End While
                If FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                    For k = 0 To CboSerieFG.Items.Count - 1
                        If CboSerieFG.Items(k) = CboSerieFactura.Text Then
                            CboSerieFG.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    TFOLIOFG.Value = TFOLIO.Value
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTractorEdit_Click(sender As Object, e As EventArgs) Handles BtnTractorEdit.Click
        Try
            If TCVE_TRACTOR.Text.Trim.Length > 0 Then
                Var1 = "Edit"
                Var2 = TCVE_TRACTOR.Text
                Var3 = "A"

                Using options = New frmUnidadesAE(1)
                    If DialogResult.OK = options.ShowDialog() Then
                    End If
                End Using

            Else
                MsgBox("Por favor seleccione un registro")
            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTanqueEdit1_Click(sender As Object, e As EventArgs) Handles BtnTanqueEdit1.Click
        If TCVE_TANQUE1.Text.Trim.Length > 0 Then
            Var1 = "Edit"
            Var2 = TCVE_TANQUE1.Text
            Var3 = "A"

            CREA_TAB(frmUnidadesAE, "Movimientos Unidades")

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BtnTanqueEdit2_Click(sender As Object, e As EventArgs) Handles BtnTanqueEdit2.Click
        If TCVE_TANQUE2.Text.Trim.Length > 0 Then
            Var1 = "Edit"
            Var2 = TCVE_TANQUE2.Text
            Var3 = "A"

            CREA_TAB(frmUnidadesAE, "Movimientos Unidades")

        Else
            MsgBox("Por favor seleccione un registro")
        End If
    End Sub

    Private Sub BtnDollyEdit_Click(sender As Object, e As EventArgs) Handles BtnDollyEdit.Click

        If BtnDollyEdit.Text.Trim.Length > 0 Then
            Var1 = "Edit"
            Var2 = BtnDollyEdit.Text
            Var3 = "A"

            CREA_TAB(frmUnidadesAE, "Movimientos Unidades")

        Else
            MsgBox("Por favor seleccione un registro")
        End If

    End Sub


    Private Sub FgA_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgA.BeforeEdit
        Try
            If e.Col = 1 Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TXT_Validated(sender As Object, e As EventArgs) Handles TXT.Validated
        Try
            Dim DATO_REGRESADO As String

            If Fg.Row > 0 And TXT.Text.Trim.Length > 0 Then
                Select Case Fg.Col
                    Case 2 'XML


                        DATO_REGRESADO = BUSCA_CAT2("tblcclaveunidad", TXT.Text)
                        'DATO_REGRESADO = BUSCA_CAT_XML("CAT_UNIDAD_PESO", TXT.Text)
                        If DATO_REGRESADO = "" Then
                            MsgBox("Unidad SAT inexistente")
                        Else
                            If Fg(Fg.Row, 4).ToString.Trim.Length = 0 Then
                                Fg(Fg.Row, 4) = DATO_REGRESADO
                            Else
                                If PasaXLS Then
                                    Fg(Fg.Row, 4) = DATO_REGRESADO
                                End If
                            End If
                        End If

                    Case 5 'XML
                        DATO_REGRESADO = BUSCA_CAT_XML("CATINV", TXT.Text)
                        If DATO_REGRESADO = "" Then
                            MsgBox("Bienes transportados inexistente")
                        Else
                            Fg(Fg.Row, 7) = DATO_REGRESADO
                        End If
                    Case 9 'XML   Material peligroso    XML
                        DATO_REGRESADO = BUSCA_CAT_XML("CAT_MATERIAL_PELIGROSO", TXT.Text)
                        If DATO_REGRESADO = "" Then
                            MsgBox("Material peligroso inexistente")
                        End If
                    Case 11
                        DATO_REGRESADO = BUSCA_CAT_XML("CAT_TIPO_EMBALAJE", TXT.Text)
                        If DATO_REGRESADO = "" Then
                            MsgBox("Embalaje inexistente")
                        Else
                            Fg(Fg.Row, 13) = DATO_REGRESADO
                        End If
                End Select
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try
    End Sub
    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 2
                            'Fg.Col = 5

                        Case 5
                            'Fg.Col = 8
                        Case 8
                            If IsMatPeligroso Then
                                'Fg.Col = 9
                            Else
                                'Fg.Col = 14
                            End If
                        Case 9
                            'Fg.Col = 11

                        Case 11
                            'Fg.Col = 14
                            'SendKeys.Send(" ")

                        Case 16
                            'Fg.Col = 18

                        Case 18
                            'Fg.Col = 19

                        Case 19
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                ADD_ROW_FG()
                            Else
                                'Fg.Row = Fg.Rows.Count - 1
                                'Fg.Col = 1

                            End If
                    End Select
                    ENTRAM = True
                    Return
                End If
                If e.KeyCode = Keys.Left Then

                    If TXT.SelectionStart = 0 Then
                        TXT.Select(0, 0)
                        e.Handled = True
                    End If
                End If
                If e.KeyCode = Keys.Right Then

                    If TXT.SelectionStart = 0 Then
                        TXT.Select(TXT.Text.Length, TXT.Text.Length)
                        'TXT.Select(TXT.SelectionStart - 1, TXT.SelectionStart - 1)
                        e.Handled = True
                    End If
                    If TXT.SelectionStart = TXT.Text.Length Then
                        e.Handled = True
                    End If
                End If
                If e.KeyCode = Keys.Up Then
                    If Fg.Row = 1 Then
                        e.SuppressKeyPress = True
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    e.SuppressKeyPress = True
                End If

                If e.KeyCode = Keys.F2 Then
                    If Fg.Col = 2 Then
                        Try
                            Var2 = "tblcclaveunidad"
                            Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                TXT.Text = Var4
                                Fg(Fg.Row, 2) = Var4
                                Fg(Fg.Row, 4) = Var5
                                'Fg.Col = 4
                            End If
                        Catch ex As Exception
                            Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    If Fg.Col = 5 Then 'BIENES TRANSPORTADOS Y CVE_PRODSERV SAT
                        Try
                            Prosec = "CATINV"
                            Var2 = ""
                            Var4 = ""
                            Var5 = ""
                            FrmNewXCategoria.ShowDialog()
                            If Var10.Trim.Length > 0 Then
                                TXT.Text = Var10
                                Fg(Fg.Row, 7) = Var11
                                'Fg.Col = 8
                            End If
                        Catch ex As Exception
                            Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    If Fg.Col = 9 Then 'MATERIAL PELIGROSO
                        Try
                            Prosec = "CAT_MATERIAL_PELIGROSO"
                            Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                            Var10 = ""

                            FrmNewXCategoria.ShowDialog()
                            If Var10.Trim.Length > 0 Then
                                TXT.Text = Var10
                                'Fg.Col = 11
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    If Fg.Col = 11 Then 'EMBALAJE
                        Try
                            Var2 = "tblctipoembalaje"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItemCFDI.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                TXT.Text = Var4
                                Fg(Fg.Row, 13) = Var5
                                'Fg.Col = 14
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    If Fg.Col = 16 Then
                        Try
                            Var2 = "MONEDA"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItem22.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                TXT.Text = Var4
                                'Fg(Fg.Row, 9) = Var5
                                'Fg.Col = 18
                            End If
                        Catch ex As Exception
                            Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try

            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Tab Then
                    Select Case Fg.Col
                        Case 1
                            Fg.Col = 2

                        Case 2
                            Fg.Col = 4

                        Case 4
                            Fg.Col = 5
                        Case 5
                            Fg.Col = 8

                        Case 8
                            If IsMatPeligroso Then
                                Fg.Col = 9
                            Else
                                Fg.Col = 14
                            End If

                        Case 9
                            Fg.Col = 11

                        Case 11
                            Fg.Col = 14

                        Case 16
                            Fg.Col = 18

                        Case 18
                            Fg.Col = 19

                        Case 19
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                ADD_ROW_FG()
                            Else
                                Fg.Row = Fg.Rows.Count - 1
                                Fg.Col = 1

                            End If
                    End Select
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub ADD_ROW_FG()
        Try
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & False & vbTab &
                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & "MXN" & vbTab & "" & vbTab & "" & vbTab & "")
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TXTN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTN.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Delete Then
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If Fg.Row > 0 Then
                    Fg.RemoveItem(Fg.Row)
                    Fg.Col = 0
                End If
                Return
            End If
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Left Then

                    If TXTN.SelectionStart = 0 Then
                        TXTN.Select(0, 0)
                        e.Handled = True
                    End If
                End If
                If e.KeyCode = Keys.Right Then

                    If TXTN.SelectionStart = 0 Then
                        TXTN.Select(TXTN.Text.Length, TXTN.Text.Length)
                        e.Handled = True
                    End If
                    If TXTN.SelectionStart = TXTN.Text.Length Then
                        e.Handled = True
                    End If
                End If
                If e.KeyCode = Keys.Up Then
                    If Fg.Row = 1 Then
                        e.SuppressKeyPress = True
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    If Fg.Col = 1 Then
                        If Fg(Fg.Row, 1) > 0 Then
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                IsMatPeligroso = False
                                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & False & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & "MXN" & vbTab & "" & vbTab & "" & vbTab & "")
                                Fg.Row = Fg.Rows.Count - 1
                                Fg.Col = 1
                                'SendKeys.Send(" ")
                            End If
                        End If
                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Tab Then
                    Select Case Fg.Col
                        Case 1
                            Fg.Col = 2

                        Case 14
                            Fg.Col = 15

                        Case 15
                            Fg.Col = 16

                    End Select
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Tab Then
                    Select Case Fg.Col
                        Case 1
                            'Fg.Col = 2
                        Case 2
                            'Fg.Col = 4
                        Case 4
                            'Fg.Col = 7
                        Case 7
                            'Fg.Col = 8
                        Case 9
                            'Fg.Col = 9
                        Case 9
                            'Fg.Col = 11
                        Case 11
                            'Fg.Col = 13
                        Case 13
                            'Fg.Col = 14
                        Case 14
                            'Fg.Col = 15
                        Case 15
                            'Fg.Col = 16
                        Case 16
                            'Fg.Col = 18
                        Case 18
                            'Fg.Col = 19
                    End Select
                End If

                If e.KeyCode = Keys.Right Then
                    Select Case Fg.Col
                        Case 1
                            'Fg.Col = 2
                        Case 2
                            'Fg.Col = 4
                        Case 4
                            'Fg.Col = 7
                        Case 7
                            'Fg.Col = 8
                        Case 9
                            'Fg.Col = 9
                        Case 9
                            'Fg.Col = 11
                        Case 11
                            'Fg.Col = 13
                        Case 13
                            'Fg.Col = 14
                        Case 14
                            'Fg.Col = 15
                        Case 15
                            'Fg.Col = 16
                        Case 16
                            'Fg.Col = 18
                        Case 18
                            'Fg.Col = 19
                    End Select
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If NO_MODIF_FG Then
            Return
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If NO_MODIF_FG Then
                e.Cancel = True
                Return
            End If

            If ENTRAM Then
                ENTRAM = False
                If e.Col = 4 Or e.Col = 13 Then
                    e.Cancel = True
                Else
                    If IsMatPeligroso Then
                        If e.Col = 9 Or e.Col = 11 Or e.Col = 13 Then
                            e.Cancel = True
                        End If
                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
        End Try

    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If ENTRAM Then
                ENTRAM = False
                If Fg.Row > 0 Then
                    If Fg.Col = 4 Or Fg.Col = 13 Then

                    Else
                        If IsMatPeligroso Then
                            If Fg.Col = 8 Or Fg.Col = 9 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Then

                            Else
                                'Fg.StartEditing()
                            End If
                        Else
                            'Fg.StartEditing()
                        End If
                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If NO_MODIF_FG Then
            Return
        End If

        Try
            If e.Row > 0 Then
                If e.Col = 10 Or e.Col = 12 Then
                    If Not Fg(e.Row, 8) Then
                        Return
                    End If
                End If
            End If


            If ENTRAM Then
                ENTRAM = False
                If Fg.Col = 3 Then
                    Try
                        Var2 = "tblcclaveunidad"
                        Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                        FrmSelItem2.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            Fg(Fg.Row, 2) = Var4
                            Fg(Fg.Row, 4) = Var5
                            'Fg.Col = 4
                        End If
                    Catch ex As Exception
                        Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRAM = True
                    Return
                End If
                If Fg.Col = 6 Then 'BIENES TRANSPORTADOS Y CVE_PRODSERV SAT
                    Try
                        Prosec = "CATINV"
                        Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                        FrmNewXCategoria.ShowDialog()
                        If Var10.Trim.Length > 0 Then
                            'Var10 = Linea
                            'Var11 = Descr
                            'Var12 = Descr2
                            Fg(Fg.Row, 5) = Var10
                            Fg(Fg.Row, 7) = Var11
                            'Fg.Col = 8
                        End If
                    Catch ex As Exception
                        Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRAM = True
                    Return
                End If
                If Fg.Col = 10 Then 'MATERIAL PELIGROSO
                    Try
                        Prosec = "CAT_MATERIAL_PELIGROSO"
                        Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                        FrmNewXCategoria.ShowDialog()
                        If Var10.Trim.Length > 0 Then
                            Fg(Fg.Row, 9) = Var10
                            Fg.Col = 11

                        End If
                    Catch ex As Exception
                        Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRAM = True
                    Return
                End If
                If Fg.Col = 12 Then 'EMBALAJE
                    Try
                        Var2 = "tblctipoembalaje"
                        Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                        FrmSelItemCFDI.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            Fg(Fg.Row, 11) = Var4
                            Fg(Fg.Row, 13) = Var5
                            Fg.Col = 14
                        End If
                    Catch ex As Exception
                        Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRAM = True
                    Return
                End If
                If Fg.Col = 17 Then
                    Try
                        Var2 = "MONEDA"
                        Var4 = ""
                        Var5 = ""
                        FrmSelItem22.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            Fg(Fg.Row, 16) = Var4
                            'Fg.Col = 18
                        End If
                    Catch ex As Exception
                        Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ENTRAM = True
                    Return
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If ENTRAM Then
                ENTRAM = False
                If Fg.Row > 0 Then
                    If Fg.Col = 8 Then
                        If Fg(e.Row, e.Col).Equals(True) Then
                            IsMatPeligroso = False
                            Fg(Fg.Row, 9) = ""
                            Fg(Fg.Row, 11) = ""
                            Fg(Fg.Row, 13) = ""
                        Else
                            IsMatPeligroso = True
                            Fg(Fg.Row, 9) = ""
                            Fg(Fg.Row, 11) = ""
                            Fg(Fg.Row, 13) = ""
                        End If
                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If NO_MODIF_FG Then
            Return
        End If
        Try

            If ENTRAM Then
                ENTRAM = False
                Select Case e.KeyCode'                                  Boton                                  Boton                                                 Boton                     Boton                                                            Boton
                    Case Keys.Insert '          1            2            3            4            5            6            7             8              9           10           11           12           13          14          15           16           17           18           19
                        IsMatPeligroso = False
                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & DBNull.Value & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "MXN" & vbTab & "" & vbTab & "" & vbTab & "")
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 1

                    Case Keys.Delete
                        If Fg.Row > 0 Then
                            If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                                Fg.RemoveItem(Fg.Row)
                                Fg.Col = 0
                            End If
                        End If
                    Case Keys.Enter
                    'e.SuppressKeyPress = True
                    Case Keys.F2
                        If Fg.Col = 5 Then
                            Try
                                Prosec = "CATINV"
                                Var4 = "" : Var5 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                                FrmNewXCategoria.ShowDialog()
                                If Var10.Trim.Length > 0 Then
                                    'Var10 = Linea
                                    'Var11 = Descr
                                    'Var12 = Descr2
                                    Fg(Fg.Row, 5) = Var10
                                    Fg(Fg.Row, 7) = Var11
                                    'Fg.Col = 8
                                End If
                            Catch ex As Exception
                                Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            ENTRAM = True
                            Return
                        End If
                        If Fg.Col = 17 Then
                            Try
                                Var2 = "MONEDA"
                                Var4 = ""
                                Var5 = ""
                                FrmSelItem22.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 16) = Var4
                                    'Fg.Col = 18
                                End If
                            Catch ex As Exception
                                Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)

                                MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If

                    Case Keys.Left

                        Select Case Fg.Col
                            Case 13
                                Fg.Col = 12
                            Case 7
                                Fg.Col = 6
                        End Select

                        'r_ = Fg.Row
                        'c_ = Fg.Col
                        'TMAGICO_GotFocus(Nothing, Nothing)
                        'SendKeys.Send("{ENTER}")
                End Select

                Select Case Fg.Col
                    Case 1
                        'Fg.Col = 2
                    Case 2

                    Case 3

                End Select
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub


    Private Sub BtnExcelCargas_Click(sender As Object, e As EventArgs)
        EXPORTAR_EXCEL_TRANSPORT(FgCarga, "Cargas")
    End Sub
    Private Sub TORDEN_DE_KeyDown(sender As Object, e As KeyEventArgs) Handles TORDEN_DE.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEMBARQUE.Focus()
        End If
    End Sub

    Private Sub TEMBARQUE_KeyDown(sender As Object, e As KeyEventArgs) Handles TEMBARQUE.KeyDown
        If e.KeyCode = Keys.Enter Then
            TCARGA_ANTERIOR.Focus()
        End If
    End Sub

    Private Sub ChCalleFiscal_CheckedChanged(sender As Object, e As EventArgs) Handles ChCalleFiscal.CheckedChanged
        Try
            If ChCalleFiscal.Checked Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT NOMBRE, RFC, CALLE, CRUZAMIENTOS, CRUZAMIENTOS2 
                    FROM CLIE" & Empresa & "
                    WHERE CLAVE  = '" & TCLIENTE.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LtNombre1.Text = dr("NOMBRE")
                            LtRFC.Text = dr("RFC")
                            LtCalle1.Text = dr("CALLE")
                            LtCalle2.Text = dr("CRUZAMIENTOS") & " " & ("CRUZAMIENTOS2")
                            LtAliasO.Text = ""
                            LtPlanta.Text = ""
                            LtNota.Text = ""
                        Else
                            LtNombre1.Text = ""
                            LtAliasO.Text = ""
                            LtCalle1.Text = ""
                            LtCalle2.Text = ""
                            LtPlanta.Text = ""
                            LtNota.Text = ""
                            LtRFC.Text = ""
                        End If
                    End Using
                End Using
                TCLAVE_O.Text = ""
                TCLAVE_O.Enabled = False
                BtnCLAVE_REM.Enabled = False
            Else
                LtNombre1.Text = ""
                LtAliasO.Text = ""
                LtCalle1.Text = ""
                LtCalle2.Text = ""
                LtPlanta.Text = ""
                LtNota.Text = ""
                LtRFC.Text = ""

                LtNombre1.Text = LtNombre1.Tag
                LtRFC.Text = LtRFC.Tag
                LtCalle1.Text = LtCalle1.Tag
                LtCalle2.Text = LtCalle2.Tag
                LtAliasO.Text = LtAliasO.Tag
                LtPlanta.Text = LtPlanta.Tag
                LtNota.Text = LtNota.Tag
                TCLAVE_O.Enabled = True
                BtnCLAVE_REM.Enabled = True

            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub TVOLUMEN_PESO_KeyDown(sender As Object, e As KeyEventArgs) Handles TVOLUMEN_PESO.KeyDown
        If e.KeyCode = Keys.Enter Then
            TCVE_TRACTOR.Focus()
        End If
    End Sub

    Private Sub BarEditDestinatario_Click(sender As Object, e As ClickEventArgs) Handles BarEditDestinatario.Click

        Var8 = "D"
        Var1 = "Edit"
        Var2 = "" 'TCLAVE_D.Text
        Var4 = ""
        Var17 = "M"  'MUESTRA LA VENTA EN SHOWDIALOG

        FrmClientesOperativos.ShowDialog()
        If Var4.Trim.Length > 0 Then

            If Mofifica_Remitente_destinatario Then
                TCLAVE_D.Text = Var4
                DESPLEGAR_CLIENTE_OPER2(TCLAVE_D.Text) 'GCCLIE_OP 
            End If
        End If
    End Sub
    Private Sub BarEditarRemitente_Click(sender As Object, e As ClickEventArgs) Handles BarEditarRemitente.Click

        Var8 = "R"
        Var1 = "Edit"
        Var2 = "" 'TCLAVE_O.Text

        Var17 = "M"  'MUESTRA LA VENTA EN SHOWDIALOG
        FrmClientesOperativos.ShowDialog()
        If Var4.Trim.Length > 0 Then

            If Mofifica_Remitente_destinatario Then
                TCLAVE_O.Text = Var4
                DESPLEGAR_CLIENTE_OPER(TCLAVE_O.Text) 'GCCLIE_OP 
            End If
        End If


    End Sub
    Private Sub BtnCopiarCargas_Click(sender As Object, e As EventArgs) Handles BtnCopiarCargas.Click
        BtnCopiarCargas.Enabled = False

        Try
            Var2 = "Copiar cargas"
            Var24 = ""
            Var44 = 0
            Var19 = "MOSTRAR TODOS"
            FrmSelViaje.ShowDialog()
            If Var24.Trim.Length > 0 Then

                If Var24 = LtCVE_VIAJE.Text Then
                    MsgBox("Por favor seleccione otro viaje no es posible copiar cargas del mismo viaje")
                    Return
                End If
                Dim ExistViaje As Boolean = False

                If Var24.Trim.Length > 0 Then
                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader

                    SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & Var24 & "'
                            AND CVE_ST_VIA <> 7"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then
                        ExistViaje = True
                    Else
                        MsgBox("Viaje inexistente")
                    End If
                    dr.Close()
                End If
                If ExistViaje Then
                    COPIAR_CARGAS_DE_OTRO_VIAJE(Var24)
                End If
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BtnCopiarCargas.Enabled = True
    End Sub

    Private Sub BtnCopiarMercancias_Click(sender As Object, e As EventArgs) Handles BtnCopiarMercancias.Click
        BtnCopiarMercancias.Enabled = False
        Try
            Var2 = "Copiar mercancias"
            Var24 = ""
            Var44 = 0
            Var19 = "MOSTRAR TODOS"

            FrmSelViaje.ShowDialog()
            If Var24.Trim.Length > 0 Then

                If Var24 = LtCVE_VIAJE.Text Then
                    MsgBox("Por favor seleccione otro viaje no es posible copiar mercancías del mismo viaje")
                    Return
                End If

                Dim ExistViaje As Boolean = False

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader

                SQL = "SELECT CVE_VIAJE FROM GCASIGNACION_VIAJE WHERE CVE_VIAJE = '" & Var24 & "'
                            AND CVE_ST_VIA <> 7"
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    ExistViaje = True
                Else
                    MsgBox("Viaje inexistente")
                End If
                dr.Close()

                If ExistViaje Then
                    COPIAR_MERCANCIAS_DE_OTRO_VIAJE(Var24)
                End If
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BtnCopiarMercancias.Enabled = True
    End Sub
    Sub COPIAR_MERCANCIAS_DE_OTRO_VIAJE(FVIAJE As String)
        Try

            Dim result = RJMessageBox.Show("Realmente desea copiar las mercancías del viaje " & FVIAJE & "?" & vbNewLine &
                                           "Si - Copiar y borrar las actuales" & vbNewLine &
                                           "No - Agregar a las ya existentes" & vbNewLine &
                                           "Cancel - Cancelar el copiado" & vbNewLine, "", MessageBoxButtons.YesNoCancel)

            If result = DialogResult.Cancel Then
                Return
            End If

            NO_MODIF_FG = True

            If result = DialogResult.No Then
                Fg.Rows.Count = 1
            End If

            Dim s As String

            If ESCENARIO = 2 Then
                Fg.Rows.Count = 1
                Fg.Cols(20).Visible = True

                If FACTURA_UNO_O_MULT = "VIAJE BUENO" Then

                    SQL = "SELECT M.CVE_VIAJE, M.NUM_PAR, M.CANT, M.ID_UNIDAD, M.DESC_UNIDAD, M.ID_MERCANCIA, M.DESCR_MERCANCIA, 
                        M.MAT_PELIGROSO, M.CVE_MAT_PELIGROSO, M.ID_EMBALAJE, M.DESC_EMBALAJE, M.PESO, M.VALOR_MERCANCIA, M.MONEDA, 
                        M.ID_FRACC_ARANCELARIA, M.UUID_COM_EXT
                        FROM GCMERCANCIAS M WHERE CVE_DOC = '" & FVIAJE & "'"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            Do While dr.Read

                                s = "" & vbTab '0
                                s &= dr("CANT") & vbTab '1
                                s &= dr("ID_UNIDAD") & vbTab '2
                                s &= "" & vbTab '3
                                s &= dr("DESC_UNIDAD") & vbTab '4
                                s &= dr("ID_MERCANCIA") & vbTab '5
                                s &= "" & vbTab '6
                                s &= dr("DESCR_MERCANCIA") & vbTab '7
                                s &= IIf(dr("MAT_PELIGROSO") = "Si", True, False) & vbTab '8
                                s &= dr("CVE_MAT_PELIGROSO") & vbTab '9
                                s &= "" & vbTab '10
                                s &= dr("ID_EMBALAJE") & vbTab '11
                                s &= "" & vbTab
                                s &= dr("DESC_EMBALAJE") & vbTab '13
                                s &= dr("PESO") & vbTab '14
                                s &= dr("VALOR_MERCANCIA") & vbTab '15
                                s &= dr("MONEDA") & vbTab '16
                                s &= "" & vbTab '17
                                s &= dr("ID_FRACC_ARANCELARIA") & vbTab '18
                                s &= dr("UUID_COM_EXT") & vbTab  '19
                                s &= "" & vbTab    '20 AQUI IVA EL VIAJE
                                s &= dr("NUM_PAR")
                                Fg.AddItem(s)
                                'Fg.Col = 20
                            Loop
                        End Using
                    End Using
                Else
                    For k = 1 To FgViajes.Rows.Count - 1

                        If FgViajes(k, 1) Then
                            SQL = "SELECT M.CVE_VIAJE, M.NUM_PAR, M.CANT, M.ID_UNIDAD, M.DESC_UNIDAD, M.ID_MERCANCIA, M.DESCR_MERCANCIA, 
                                M.MAT_PELIGROSO, M.CVE_MAT_PELIGROSO, M.ID_EMBALAJE, M.DESC_EMBALAJE, M.PESO, M.VALOR_MERCANCIA, M.MONEDA, 
                                M.ID_FRACC_ARANCELARIA, M.UUID_COM_EXT 
                                FROM GCMERCANCIAS M WHERE CVE_VIAJE = '" & FgViajes(k, 2) & "'"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    Do While dr.Read

                                        s = "" & vbTab '0
                                        s &= dr("CANT") & vbTab '1
                                        s &= dr("ID_UNIDAD") & vbTab '2
                                        s &= "" & vbTab '3
                                        s &= dr("DESC_UNIDAD") & vbTab '4
                                        s &= dr("ID_MERCANCIA") & vbTab '5
                                        s &= "" & vbTab '6
                                        s &= dr("DESCR_MERCANCIA") & vbTab '7
                                        s &= IIf(dr("MAT_PELIGROSO") = "Si", True, False) & vbTab '8
                                        s &= dr("CVE_MAT_PELIGROSO") & vbTab '9
                                        s &= "" & vbTab '10
                                        s &= dr("ID_EMBALAJE") & vbTab '11
                                        s &= "" & vbTab
                                        s &= dr("DESC_EMBALAJE") & vbTab '13
                                        s &= dr("PESO") & vbTab '14
                                        s &= dr("VALOR_MERCANCIA") & vbTab '15
                                        s &= dr("MONEDA") & vbTab '16
                                        s &= "" & vbTab '17
                                        s &= dr("ID_FRACC_ARANCELARIA") & vbTab '18
                                        s &= dr("UUID_COM_EXT") & vbTab  '19
                                        s &= FgViajes(k, 2) & vbTab   '20
                                        s &= dr("NUM_PAR")   '21
                                        Fg.AddItem(s)
                                        Fg.Col = 20

                                    Loop
                                End Using
                            End Using
                        End If
                    Next
                End If

            Else

                If FACTURA_UNO_O_MULT = "VIAJE BUENO" Then
                    SQL = "SELECT M.CVE_VIAJE, M.NUM_PAR, M.CANT, M.ID_UNIDAD, M.DESC_UNIDAD, M.ID_MERCANCIA, M.DESCR_MERCANCIA, 
                        M.MAT_PELIGROSO, M.CVE_MAT_PELIGROSO, M.ID_EMBALAJE, M.DESC_EMBALAJE, M.PESO, M.VALOR_MERCANCIA, M.MONEDA, 
                        M.ID_FRACC_ARANCELARIA, M.UUID_COM_EXT 
                        FROM GCMERCANCIAS2 M WHERE CVE_DOC = '" & FVIAJE & "'"
                Else
                    SQL = "SELECT M.CVE_VIAJE, M.NUM_PAR, M.CANT, M.ID_UNIDAD, M.DESC_UNIDAD, M.ID_MERCANCIA, M.DESCR_MERCANCIA, 
                        M.MAT_PELIGROSO, M.CVE_MAT_PELIGROSO, M.ID_EMBALAJE, M.DESC_EMBALAJE, M.PESO, M.VALOR_MERCANCIA, M.MONEDA, 
                        M.ID_FRACC_ARANCELARIA, M.UUID_COM_EXT 
                        FROM GCMERCANCIAS M WHERE CVE_VIAJE = '" & FVIAJE & "'"
                End If
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read

                            s = "" & vbTab '0
                            s &= dr("CANT") & vbTab '1
                            s &= dr("ID_UNIDAD") & vbTab '2
                            s &= "" & vbTab '3
                            s &= dr("DESC_UNIDAD") & vbTab '4
                            s &= dr("ID_MERCANCIA") & vbTab '5
                            s &= "" & vbTab '6
                            s &= dr("DESCR_MERCANCIA") & vbTab '7
                            s &= IIf(dr("MAT_PELIGROSO") = "Si", True, False) & vbTab '8
                            s &= dr("CVE_MAT_PELIGROSO") & vbTab '9
                            s &= "" & vbTab '10
                            s &= dr("ID_EMBALAJE") & vbTab '11
                            s &= "" & vbTab
                            s &= dr("DESC_EMBALAJE") & vbTab '13
                            s &= dr("PESO") & vbTab '14
                            s &= dr("VALOR_MERCANCIA") & vbTab '15
                            s &= dr("MONEDA") & vbTab '16
                            s &= "" & vbTab '17
                            s &= dr("ID_FRACC_ARANCELARIA") & vbTab '18
                            s &= dr("UUID_COM_EXT") '19
                            s &= "" & vbTab   '20
                            s &= dr("NUM_PAR")   '21

                            Fg.AddItem(s)

                        Loop
                    End Using
                End Using
                Fg.Cols(20).Visible = False
            End If

            If IsNothing(Fg(1, 1)) Then
                Fg.RemoveItem(1)
            Else
                If Not IsNumeric(Fg(1, 1)) Or Fg(1, 1) = 0 Then
                    Fg.RemoveItem(1)
                End If
            End If

            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & False & vbTab &
                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & 0 & vbTab & "MXN" & vbTab & "" & vbTab &
                       "" & vbTab & "" & vbTab & "" & vbTab & "0")
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1

            If FACTURA_UNO_O_MULT = "SEFACTURA" Or FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Or FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                'PORQUI NO DEBE DE PASAR
            Else
                'SendKeys.Send(" ")
            End If
            FgCarga.Focus()
            Fg.AutoSizeRow(0)
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        NO_MODIF_FG = False
    End Sub
    Sub COPIAR_CARGAS_DE_OTRO_VIAJE(FVIAJE As String)
        Try
            Dim result = RJMessageBox.Show("Realmente desea copiar las cargas del viaje " & FVIAJE & vbNewLine &
                                           "Si - Copiar y borrar las actuales" & vbNewLine &
                                           "No - Agregar a las ya existentes" & vbNewLine &
                                           "Cancel - Cancelar el copiado" & vbNewLine, "", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Return
            End If

            NO_MODIF_FG = True

            If result = DialogResult.OK Then
                FgCarga.Rows.Count = 1
            End If

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT C.CANT, C.EMBALAJE, C.CARGA, CONTIENE, C.PESO, C.VOLUMEN, C.PESO_ESTIMADO, C.PEDIMENTO
                    FROM GCCARGA C
                    WHERE CVE_VIAJE = '" & FVIAJE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgCarga.AddItem("" & vbTab & dr("CANT") & vbTab & dr("EMBALAJE") & vbTab & dr("CARGA") & vbTab &
                                        dr("CONTIENE") & vbTab & dr("PESO") & vbTab & dr("VOLUMEN") & vbTab &
                                        dr("PESO_ESTIMADO") & vbTab & dr("PEDIMENTO"))
                    End While
                End Using
            End Using
            FgCarga.Focus()
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        NO_MODIF_FG = False
    End Sub
    Private Sub TFOLIOFG_TextChanged(sender As Object, e As EventArgs) Handles TFOLIOFG.TextChanged
        If Not ACEPTA_CALCULO Then
            Return
        End If

        Try
            Dim FOLIO As Long, FOLIOVALUE As Long

            If FACTURA_UNO_O_MULT = "VVM" Then
                Return
            End If

            If Not IsNothing(TFOLIOFG.Text) AndAlso IsNumeric(TFOLIOFG.Text) Then

                FOLIO = Convert.ToInt64(TFOLIOFG.Text)
                FOLIOVALUE = TFOLIOFG.Value

                SQL = "SELECT ISNULL(STATUS,'') AS ST FROM GCASIGNACION_VIAJE 
                    WHERE SERIE = '" & CboSerieFG.Text & "' AND FOLIO = " & FOLIO

                LtDisponible.Text = "DISPONIBLE"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            If dr("ST") = "C" Then
                                LtDisponible.Text = "DISPONIBLE"
                                TFOLIO.Value = FOLIO
                            Else
                                LtDisponible.Text = "NO DISPONIBLE"
                            End If
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboSerieFG_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboSerieFG.DropDownClosed
        Dim SIGUE As Boolean = True
        If FACTURA_UNO_O_MULT = "VVM" Then
            Return
        End If
        Try
            TFOLIOFG.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try
        Try            'Dim CVE_DOC As String
            If CboSerieFG.SelectedIndex > -1 Then

                SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA
                    FROM FOLIOSF" & Empresa & "
                    WHERE TIP_DOC = 'F' AND SERIE = '" & CboSerieFG.Text & "'"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            TFOLIOFG.Value = dr("ULTDOC") + 1
                        End If
                    End Using
                End Using
                LtDispMV.Text = "DISPONIBLE"

                While SIGUE
                    SQL = "SELECT ISNULL(STATUS,'') AS ST FROM GCASIGNACION_VIAJE 
                        WHERE SERIE = '" & CboSerieFG.Text & "' AND FOLIO = " & TFOLIOFG.Value
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                If dr("ST") = "A" Then
                                    LtDispMV.Text = "NO DISPONIBLE"
                                    TFOLIOFG.Value += 1
                                Else
                                    LtDispMV.Text = "DISPONIBLE"
                                End If
                            End If
                        End Using
                    End Using
                    If LtDispMV.Text = "DISPONIBLE" Then
                        SIGUE = False
                    End If
                End While
                If FACTURA_UNO_O_MULT = "SEFACTURA 3" Then
                    For k = 0 To CboSerieFG.Items.Count - 1
                        If CboSerieFG.Items(k) = CboSerieFactura.Text Then
                            CboSerieFG.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    TFOLIO.Value = TFOLIOFG.Value
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TABONO_NETO_TextChanged(sender As Object, e As EventArgs) Handles TABONO_NETO.TextChanged
        Dim ABONO As Decimal = 0
        If Not ACEPTA_CALCULO Then
            Return
        End If
        Try
            If IsDBNull(TABONO_NETO.Text) And IsDBNull(TFLETEA.Value) Then
                Return
            End If

            If IsNothing(TABONO_NETO.Value) And IsNothing(TFLETEA.Value) Then
                Return
            End If

            Try
                ABONO = TABONO_NETO.Text
            Catch ex As Exception
                Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


            If ABONO = 0 Then
                TSUBT_O.Value = 0
                TIVA_O.Value = 0
                TRET_O.Value = 0
                TNETO_O.Value = 0

                TSUBT_O2.Value = 0
                TIVA_O2.Value = 0
                TRET_O2.Value = 0
                TNETO_O2.Value = 0

                TSALDO_SUBTOTAL.Value = 0
                TSALDO_IVA.Value = 0
                TSALDO_RET.Value = 0
                TSALDO_NETO.Value = 0

                Return
            End If
            If Convert.ToDecimal(TABONO_NETO.Text) > TFLETEA.Value Then
                MsgBox("El monto no puede ser mayor al original")
                Return
            End If
            CALCULO_ESCENARIO3(20)
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TABONO_NETO_Validated(sender As Object, e As EventArgs) Handles TABONO_NETO.Validated
        Try
            If TABONO_NETO.Text > TFLETEA.Value Then
                TABONO_NETO.Value = 0
                Return
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFOLIO_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles TFOLIO_VIAJE.KeyDown
        Try
            If e.KeyCode = 13 Then
                If IsNumeric(TFOLIO_VIAJE.Text) Then

                    Var49 = 55
                    Var2 = TFOLIO_VIAJE.Text

                    Dim f As New FrnAsigViajeBConsul With {.MdiParent = MainRibbonForm.Owner, .TopLevel = True}
                    f.ShowDialog()

                    Var49 = 0
                    Var2 = ""
                    TFOLIO_VIAJE.Text = ""

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnSelViaje_Click(sender As Object, e As EventArgs) Handles BtnSelViaje.Click
        Try
            Var2 = "Asignacion Viajes bueno2"
            Var4 = "" : Var5 = "" : Var6 = "" : Var10 = ""

            FrmSelItem.ShowDialog()
            MainRibbonForm.Activate()

            If Var4.Trim.Length > 0 Then
                TFOLIO_VIAJE.Text = Var4
                LtCVE_VIAJE.Text = Var4
                Try
                    BarCopiarViaje.Enabled = False

                    If FACTURA_UNO_O_MULT = "SEFACTURA_MULT" Then
                        DESPLEGAR_VIAJES_NO_FACTURADOS(TFOLIO_VIAJE.Text)
                    Else
                        Try
                            TFOLIO_VIAJE.UpdateValueWithCurrentText()

                            LtCVE_VIAJE.Text = TFOLIO_VIAJE.Value
                            DESPLEGAR_VIAJE(TFOLIO_VIAJE.Value)

                            If TCVE_MON.Text.Trim.Length = 0 Then
                                TCVE_MON.Focus()
                            ElseIf TCLAVE_O.Text.Trim.Length = 0 Then
                                TCLAVE_O.Focus()
                            ElseIf TCLAVE_D.Text.Trim.Length = 0 Then
                                TCLAVE_D.Focus()
                            ElseIf TRECOGER_EN.Text.Trim.Length = 0 Then
                                TRECOGER_EN.Focus()
                            ElseIf TENTREGAR_EN.Text.Trim.Length = 0 Then
                                TENTREGAR_EN.Focus()
                            ElseIf TCVE_OPER.Text.Trim.Length = 0 Then
                                TCVE_OPER.Focus()
                            Else
                                TORDEN_DE.Focus()
                            End If
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                    CARGAR_TARIFAS(TCVE_TAB_VIAJE.Text)

                    DESPLEGAR_TIPO_VIAJE()

                    If LtTimbrado.Text = "TIMBRADO" Or LtStatus.Text = "Cancelado" Then
                        BarGrabar.Enabled = False
                        BarEditarRemitente.Enabled = False
                        BarEditDestinatario.Enabled = False
                        BoxGastos.Enabled = False
                        SplitM3.Enabled = False
                        SplitM4.Enabled = False
                        DESHABILITAR()
                        TFOLIO_VIAJE.Enabled = False
                        BtnSelViaje.Enabled = False
                        ChCalleFiscal.Enabled = False
                        BarEditarRemitente.Enabled = False
                        BarEditDestinatario.Enabled = False
                    End If

                    If LtStatus.Text = "LIQUIDADO" Then
                        BoxGastos.Enabled = False
                    Else
                        BoxGastos.Enabled = True
                    End If

                Catch ex As Exception
                End Try

                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnMotTras_Click(sender As Object, e As EventArgs) Handles BtnMotTras.Click
        Try
            Prosec = "CAT_MOT_TRASLADO"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnINCOTERM_Click(sender As Object, e As EventArgs) Handles BtnINCOTERM.Click
        Try
            Prosec = "CAT_INCOTERM"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTipoOper_Click(sender As Object, e As EventArgs) Handles BtnTipoOper.Click
        Try
            Prosec = "CAT_TIPO_OP"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnNumExpCon_Click(sender As Object, e As EventArgs) Handles BtnNumExpCon.Click
        Try
            Prosec = "CAT_EXPORTACION40"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUniAduana_Click(sender As Object, e As EventArgs) Handles BtnUniAduana.Click
        Try
            Prosec = "CAT_UNI_ADUANA"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPaisAdenda_Click(sender As Object, e As EventArgs) Handles BtnPaisAdenda.Click
        Try
            Prosec = "CAT_PAIS"
            Var10 = ""
            FrmListaXML.ShowDialog()
            If Var10.Trim.Length > 0 Then
                'TMUNICIPIO.Text = Var12
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFOLIO_VIAJE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TFOLIO_VIAJE.PreviewKeyDown
        Try
            If e.KeyCode = 13 Then
                TCVE_MON.Focus()
            End If
        Catch ex As Exception
        End Try
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


    Private Sub TXTC_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTC.KeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = 13 Then
                    Select Case FgCarga.Col
                        Case 3

                        Case 4

                        Case 6
                        Case 7

                        Case 100
                            If FgCarga.Row = FgCarga.Rows.Count - 1 Then
                                '                            CANT         CLAVE        EMBALAJE     CLAVE        CARGA     QUE EL REMITENTE DICE QUE CONTIENE
                                FgCarga.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                    "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                                '              PESO        VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
                                FgCarga.Row = FgCarga.Rows.Count - 1
                                FgCarga.Col = 1
                            Else
                                FgCarga.Row = FgCarga.Rows.Count - 1
                                FgCarga.Col = 1
                            End If
                    End Select
                    ENTRAM = True
                    Return
                End If
                If e.KeyCode = Keys.Left Then
                    Select Case FgCarga.Col
                        Case 9
                            FgCarga.Col = 8
                        Case 8
                            FgCarga.Col = 7
                        Case 7
                            FgCarga.Col = 6
                    End Select
                End If
                If e.KeyCode = Keys.Right Then
                    Select Case FgCarga.Col
                        Case 2
                            'FgCarga.Col = 4
                        Case 4
                           ' FgCarga.Col = 6
                        Case 6
                            'FgCarga.Col = 7
                        Case 7

                        Case 10
                            'e.SuppressKeyPress = True
                    End Select
                End If
                If e.KeyCode = Keys.Up Then
                    If FgCarga.Row = 1 Then
                        e.SuppressKeyPress = True
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    e.SuppressKeyPress = True
                End If
                If e.KeyCode = Keys.Insert Then
                    BtnAgregar_Click(Nothing, Nothing)
                End If

                If e.KeyCode = Keys.Delete Then
                    If FgCarga.Row > 0 Then

                    End If
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXTC_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTC.PreviewKeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Tab Then
                    Select Case FgCarga.Col
                        Case 2
                            'FgCarga.Col = 4
                        Case 4
                            FgCarga.Col = 6
                        Case 6
                            FgCarga.Col = 7
                        Case 10
                            If FgCarga.Row = FgCarga.Rows.Count - 1 Then

                                '                            CANT         CLAVE        EMBALAJE     CLAVE        CARGA     QUE EL REMITENTE DICE QUE CONTIENE
                                FgCarga.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                                '              PESO          VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
                                FgCarga.Row = FgCarga.Rows.Count - 1
                                FgCarga.Col = 1
                            Else
                                FgCarga.Row = FgCarga.Rows.Count - 1
                                FgCarga.Col = 1
                            End If
                    End Select
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_KeyUp(sender As Object, e As KeyEventArgs) Handles TXTN.KeyUp

    End Sub
    Private Sub TXTNC_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTNC.KeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = 13 Then
                    Select Case FgCarga.Col
                    End Select
                    ENTRAM = True
                    Return
                End If
                If e.KeyCode = Keys.Left Then '<---------

                    If TXTNC.SelectionStart = 0 Then
                        TXTNC.Select(0, 0)
                        e.Handled = True
                    End If


                    Select Case FgCarga.Col
                    End Select
                End If
                If e.KeyCode = Keys.Right Then '--------->
                    Select Case FgCarga.Col
                        Case 1, 7, 8, 9

                            If TXTNC.SelectionStart = 0 Then
                                TXTNC.Select(TXTNC.Text.Length, TXTNC.Text.Length)
                                'TXTNC.Select(TXTNC.SelectionStart - 1, TXTNC.SelectionStart - 1)
                                e.Handled = True
                            End If
                            If TXTNC.SelectionStart = TXTNC.Text.Length Then
                                e.Handled = True
                            End If
                    End Select
                End If
                If e.KeyCode = Keys.Up Then
                    If FgCarga.Row = 1 Then
                        e.SuppressKeyPress = True
                    End If
                End If
                If e.KeyCode = Keys.Down Then
                    If FgCarga.Col = 1 Then
                        If FgCarga(FgCarga.Row, 1) > 0 Then
                            If FgCarga.Row = FgCarga.Rows.Count - 1 Then
                                '                            CANT         CLAVE        EMBALAJE     CLAVE        CARGA     QUE EL REMITENTE DICE QUE CONTIENE
                                FgCarga.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                                '              PESO          VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
                                FgCarga.Row = Fg.Rows.Count - 1
                                FgCarga.Col = 1
                                'SendKeys.Send(" ")
                            End If
                        End If
                    End If
                End If
                If e.KeyCode = Keys.Insert Then
                    BtnAgregar_Click(Nothing, Nothing)
                End If

                If IsNothing(FgCarga.Editor) Then
                    If e.KeyCode = Keys.Delete Then
                        If FgCarga.Row > 0 Then
                            FgCarga.RemoveItem(FgCarga.Row)
                        End If
                    End If
                End If


                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXTNC_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTNC.PreviewKeyDown
        Try
            If ENTRAM Then
                ENTRAM = False
                If e.KeyCode = Keys.Tab Then
                    Select Case FgCarga.Col
                        Case 1
                            FgCarga.Col = 2
                        Case 7
                            FgCarga.Col = 8
                        Case 8
                            FgCarga.Col = 9
                        Case 9
                            FgCarga.Col = 10
                    End Select
                End If
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles CboCarga.KeyDown

        If NO_MODIF_FG Then
            Return
        End If

        If e.KeyCode = 13 Then
            If CboCarga.AutoOpen = True Then
                'CboCarga.AutoOpen = False
            Else
                'FgCarga.StartEditing()
                'CboCarga.AutoOpen = True
            End If
        End If
        If e.KeyCode = Keys.Right Then
            CboCarga.AutoOpen = False
            FgCarga.FinishEditing()
            FgCarga.Col = 4
            FgCarga.FinishEditing()
        End If
        If e.KeyCode = Keys.Left Then
            CboCarga.AutoOpen = False
            FgCarga.FinishEditing()
        End If
    End Sub
    Private Sub CboCarga_GotFocus(sender As Object, e As EventArgs) Handles CboCarga.GotFocus
        CboCarga.AutoOpen = True
    End Sub
    Private Sub FgCarga_KeyUp(sender As Object, e As KeyEventArgs) Handles FgCarga.KeyUp
        If NO_MODIF_FG Then
            Return
        End If

        Try
            If FgCarga.Row > 0 Then
                If FgCarga.Col = 3 Then
                    'FgCarga.StartEditing()
                End If
            End If
            If e.KeyCode = Keys.Right Then
                CboCarga.AutoOpen = False
                FgCarga.FinishEditing()
            End If
            If e.KeyCode = Keys.Left Then
                CboCarga.AutoOpen = False
                FgCarga.FinishEditing()
            End If
        Catch ex As Exception
            Bitacora(ex.Message & ex.StackTrace)
        End Try

    End Sub
    Private Sub FgCarga_EnterCell(sender As Object, e As EventArgs) Handles FgCarga.EnterCell

    End Sub

    Private Sub FgCarga_KeyDown(sender As Object, e As KeyEventArgs) Handles FgCarga.KeyDown
        If NO_MODIF_FG Then
            Return
        End If
        NO_MODIF_FG = True
        Try

            If ENTRAM Then
                ENTRAM = False
                Select Case e.KeyCode'                           Boton                                  
                    Case Keys.Insert '                1            2            3            4             5             6             7             8
                        IsMatPeligroso = False
                        ''                            CANT         CLAVE        EMBALAJE     CLAVE        CARGA     QUE EL REMITENTE DICE QUE CONTIENE
                        'FgCarga.AddItem("" & vbTab & "0" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                        '                "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "0")
                        ''              PESO          VOLUMEN   PESO ESTIMADO  PEDIMENTO       NUM_PAR
                        'FgCarga.Row = FgCarga.Rows.Count - 1
                        'FgCarga.Col = 1

                        BtnAgregar_Click(Nothing, Nothing)


                    Case Keys.Delete
                        If FgCarga.Row > 0 Then
                            FgCarga.RemoveItem(FgCarga.Row)
                        End If
                    Case Keys.Enter
                        If FgCarga.Row > 0 Then
                            Select Case FgCarga.Col
                                Case 1
                                    SendKeys.Send("{LEFT}")
                                Case 2
                                    SendKeys.Send("{RIGHT}")
                                Case 4
                                    SendKeys.Send("{RIGHT}")
                                Case 5
                                    SendKeys.Send("{LEFT}")
                                Case 6
                                    SendKeys.Send("{LEFT}")
                                Case 7
                                    SendKeys.Send("{LEFT}")
                                Case 8
                                    SendKeys.Send("{RIGHT}")

                            End Select
                        End If
                    Case Keys.F2
                        If FgCarga.Row > 0 Then
                            If FgCarga.Col = 4 Then
                                Try
                                    Var2 = "MONEDA"
                                    Var4 = ""
                                    Var5 = ""
                                    FrmSelItem22.ShowDialog()
                                    If Var4.Trim.Length > 0 Then
                                        FgCarga(FgCarga.Row, 2) = Var4
                                        'FgCarga.Col = 3
                                    End If
                                Catch ex As Exception
                                    Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If

                    Case Keys.Left

                        'r_ = FgCarga.Row
                        'c_ = FgCarga.Col
                        'TMAGICO_GotFocus(Nothing, Nothing)
                        'SendKeys.Send("{ENTER}")
                    Case Keys.Right
                        'Fg.Col = 4
                    Case FgCarga.Col = 3

                End Select
                ENTRAM = True
            End If
        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
        NO_MODIF_FG = False
    End Sub

    Private Sub FgCarga_Click(sender As Object, e As EventArgs) Handles FgCarga.Click
        If NO_MODIF_FG Then
            Return
        End If
    End Sub
    Private Sub FgCarga_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgCarga.BeforeEdit
        Try
            If NO_MODIF_FG Then
                e.Cancel = True
                Return
            End If

        Catch ex As Exception
            ENTRAM = True
        End Try
    End Sub
    Private Sub FgCarga_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgCarga.CellButtonClick
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If FgCarga.Row > 0 Then
                If ENTRAM Then
                    ENTRAM = False
                    If FgCarga.Col = 2 Then
                        Try
                            Var2 = "Embalaje"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                FgCarga(FgCarga.Row, 2) = Var4
                                FgCarga(FgCarga.Row, 3) = Var5
                                FgCarga.Col = 4
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    If FgCarga.Col = 4 Then 'CARGAS
                        Try
                            Var2 = "Cargas"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                FgCarga(FgCarga.Row, 4) = Var4
                                FgCarga(FgCarga.Row, 5) = Var5
                                FgCarga.Col = 6
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If
                    ENTRAM = True
                End If
            End If

        Catch ex As Exception
            ENTRAM = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgCarga_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgCarga.ValidateEdit
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If FgCarga.Col = 2 Then
                If Not IsNothing(FgCarga.Editor) Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT DESCR FROM GCEMBALAJE WHERE CLAVE = '" & FgCarga.Editor.Text & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                FgCarga(FgCarga.Row, 3) = dr("DESCR")
                            End If
                        End Using
                    End Using
                End If
            End If
            If FgCarga.Col = 4 Then
                If Not IsNothing(FgCarga.Editor) Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT DESCR FROM GCCARGAS WHERE CLAVE = '" & FgCarga.Editor.Text & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                FgCarga(FgCarga.Row, 5) = dr("DESCR")
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
    Private Sub FgCarga_KeyPressEdit(sender As Object, e As KeyPressEditEventArgs) Handles FgCarga.KeyPressEdit
        Select Case FgCarga.Col
            Case 2
            Case 4
            Case 7
                'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Right) Then
                'e.Handled = True
                'End If
        End Select
    End Sub

    Private Sub FgCarga_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgCarga.KeyDownEdit
        If NO_MODIF_FG Then
            Return
        End If
        Try
            ENTRAM = False
            If e.Row > 0 Then

                If e.KeyCode = 13 Then
                    If Fg.Col = 3 Then

                        'AQUI CIRO
                        'NO_MODIF_FG_CARGA = True
                        'FgCarga.StartEditing()
                        'CboCarga.AutoOpen = True
                        'NO_MODIF_FG_CARGA = False
                    End If
                End If
                If e.KeyCode = Keys.Left Then '<----------
                    Select Case e.Col
                        Case 2
                            e.Handled = True
                        Case 4
                            'FgCarga.Col = 2

                        Case 7
                            'e.Handled = True
                    End Select
                End If
                If e.KeyCode = Keys.Right Then '----->
                    Select Case e.Col
                        Case 2

                            'e.Handled = True
                        Case 4
                        Case 7
                    End Select
                End If
                If e.KeyCode = Keys.F2 Then
                    If FgCarga.Col = 2 Then
                        Try
                            Var2 = "Embalaje"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                FgCarga(FgCarga.Row, 2) = Var4
                                FgCarga.Editor.Text = Var4

                                FgCarga(FgCarga.Row, 3) = Var5
                                'FgCarga.Col = 4
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return
                    End If

                    If FgCarga.Col = 4 Then 'CARGAS
                        Try
                            Var2 = "Cargas"
                            Var4 = ""
                            Var5 = ""
                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                FgCarga(FgCarga.Row, 4) = Var4
                                FgCarga.Editor.Text = Var4
                                FgCarga(FgCarga.Row, 5) = Var5
                                'FgCarga.Col = 6
                                'SendKeys.Send(" ")
                            End If
                        Catch ex As Exception
                            Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRAM = True
                        Return

                        ENTRAM = True
                    End If
                End If

            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        ENTRAM = True

    End Sub

    Private Sub FgCarga_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles FgCarga.PreviewKeyDown
        If NO_MODIF_FG Then
            Return
        End If
        Try
            If FgCarga.Row > 0 Then
                If ENTRAM Then
                    If e.KeyCode = Keys.Tab Then
                        ENTRAM = False
                        Select Case FgCarga.Col
                            Case 1
                                FgCarga.Col = 2
                            Case 2
                            'FgCarga.Col = 4
                            Case 4

                            Case 6
                                Fg.Col = 8
                            Case 7
                                FgCarga.Col = 8
                            Case 8
                                FgCarga.Col = 9
                            Case 9
                                FgCarga.Col = 1
                            Case 8
                                If IsMatPeligroso Then
                                    FgCarga.Col = 9
                                Else
                                    FgCarga.Col = 14
                                End If
                            Case 9
                                FgCarga.Col = 11
                            Case 11
                                FgCarga.Col = 14
                            Case 16
                                FgCarga.Col = 18
                            Case 18
                                FgCarga.Col = 19
                            Case 19
                                If FgCarga.Row = FgCarga.Rows.Count - 1 Then
                                    ADD_ROW_FG()
                                Else
                                    FgCarga.Row = FgCarga.Rows.Count - 1
                                    FgCarga.Col = 1
                                End If
                        End Select
                    End If
                    ENTRAM = True
                End If
            End If

        Catch ex As Exception
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRAM = True
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub

    Private Sub FgCarga_StartEdit(sender As Object, e As RowColEventArgs) Handles FgCarga.StartEdit

    End Sub

    Private Sub FgCarga_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgCarga.AfterEdit

    End Sub

    Private Sub TXTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTC.KeyPress

    End Sub

    Private Sub TXTC_KeyUp(sender As Object, e As KeyEventArgs) Handles TXTC.KeyUp
        'SendKeys.Send("{RIGHT}")
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress

    End Sub

    Private Sub ChComplemento_CheckedChanged(sender As Object, e As EventArgs) Handles ChComplemento.CheckedChanged
        Try
            If ChComplemento.Checked Then
                TVIAJE_COMPLE.Visible = True
                TOBS_COMPLE.Visible = True
                Lt1.Visible = True
                Lt2.Visible = True
            Else
                TVIAJE_COMPLE.Visible = False
                TOBS_COMPLE.Visible = False
                Lt1.Visible = False
                Lt2.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TXTC_GotFocus(sender As Object, e As EventArgs) Handles TXTC.GotFocus

    End Sub

    Private Sub TXTC_Enter(sender As Object, e As EventArgs) Handles TXTC.Enter
        Debug.Print(TXTC.Text)
    End Sub
End Class

