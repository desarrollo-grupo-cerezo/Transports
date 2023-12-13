Imports System.Xml
Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Public Class FrmTPV

    Private _c As Comprobante
    Private FTP_CFDI_DEV As String = ""
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String

    Private USO_CFDI As String
    Private REG_FISC As String
    Private MONEDA As String
    Private METODODEPAGO As String
    Private FORMAPAGO As String

    Private TIMBRADO_DEMO As String = "No"
    Private EMISORRFC As String = ""
    Private CVE_ART_NC As String = ""
    Private _myEditor As MyEditorTPV

    Private Obser As String = ""
    Private ENTRA As Boolean = True
    Private MODO_EDIT As String = ""
    Private SE_MODIFICA As Boolean = True
    Private ALTA_CLIENTES As Integer
    Private ALTA_PRODUCTOS As Integer
    Private CAPTURA_PAGO_VENTA As Integer
    Private MULTIALMACEN As Integer
    Private DOC_ENLAZADO As String = ""
    Private CREDITO As String = ""
    Private INDIRECTOS_X_PARTIDA As Integer = 0
    Private C_IMPUESTOS As Integer = 0
    Private C_ALMACEN As Integer = 0
    Private C_I_PART_KIT As Integer = 0
    Private BLOQUEAR_PRECIO_PV As Integer = 0
    Private TIPO_VENTA_LOCAL As String
    Private LINEA_EN_VENTAS As String = ""

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Sub CARGAR_DATOS1()
        Dim Efecto As Boolean
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

        Catch ex As Exception
        End Try
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Try
                F1.Value = Date.Today
                F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F1.CustomFormat = "dd/MM/yyyy"
                F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F1.EditFormat.CustomFormat = "dd/MM/yyyy"

                Me.WindowState = FormWindowState.Maximized

                For k = 0 To aLIB1.GetLength(0) - 1
                    aLIB1(k, 0) = "--"
                    aLIB1(k, 1) = ""

                    aLIB2(k + 1, k, 0) = "--"
                    aLIB2(k + 1, k, 1) = ""
                Next

                PassData5 = ""
                ReDim aDATA(0, 1)

            Catch ex As Exception
                BITACORATPV("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MODO_EDIT = Var11
            BarEnlaceDocumento.Visible = True
            LEntregarEn.Visible = True
            tEntregarEn.Visible = True
            LtNombre.Tag = ""
            F1.Tag = ""
            tEntregarEn.Tag = ""
            LtRFC.Tag = ""
            DOC_ENLAZADO = ""
            TCVE_PEDI.Tag = ""
            LtNombre.Tag = ""

            BtnFactura.FlatStyle = FlatStyle.Flat
            BtnFactura.FlatAppearance.BorderSize = 0

            BtnUnidades.FlatStyle = FlatStyle.Flat
            BtnUnidades.FlatAppearance.BorderSize = 0

            BtnTipo.FlatStyle = FlatStyle.Flat
            BtnTipo.FlatAppearance.BorderSize = 0

            BtnVend.FlatStyle = FlatStyle.Flat
            BtnVend.FlatAppearance.BorderSize = 0

            TIPO_VENTA_LOCAL = TIPO_VENTA

            If MULTIALMACEN = 1 Then
                CboAlmacen.Visible = True
                LtAlm.Visible = True
            Else
                CboAlmacen.Visible = False
                LtAlm.Visible = False
            End If

            OBSER_X_PARTIDA = 0
            OBSER_X_DOC = 0
            Obser = ""
            LtCVE_DOC.Tag = 0
            Ldocu.Tag = ""

            CARGA_PARAM_VENTAS()
            CARGA_PARAM_INVENT()  'LEER MULTIALMACEN O o 1  
            tEsquema.Value = 0
            TDESC.Value = 0
            tDesFin.Value = 0

            If OBSER_X_DOC = 1 Then
                BarObserDoc.Visible = True
            End If
            If OBSER_X_PARTIDA = 1 Then
                BarObserPar.Visible = True
            End If
            If BLOQUEAR_PRECIO_PV = 0 Then
                CboPrecio.Enabled = True
            Else
                CboPrecio.Enabled = False
            End If

        Catch ex As Exception
            BITACORATPV("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'OBTIENE SERIE DESDE LA TABLA GCUSUARIOS_SERIE 
        LETRA_VENTA = OBTENER_SERIE_USUARIO_TIPO_VENTA(TIPO_VENTA_LOCAL)

        LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)

        If TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "F" Then

            'Var12
            If MODO_EDIT = "edit" Then
                LETRA_VENTA = String.Concat(Var12.Where(AddressOf Char.IsLetter))
            End If

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TIPO FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & LETRA_VENTA & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            Ldocu.Tag = IIf(dr("TIPO") = "I", "Impresión", "Digital")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        Page2.TabVisible = False
        Page3.TabVisible = False

        Select Case TIPO_VENTA_LOCAL
            Case "F"
                LtVenta.Text = "Facturación"
                If Ldocu.Tag = "Digital" Then
                    CargarUsosCfdi()
                    CargarRegimenesFiscales()
                    CargarMonedas()
                    CargarMetodosPago()
                    CargarFormasPago()

                    Page2.TabVisible = True
                    Page3.TabVisible = False
                End If
            Case "V"
                LtVenta.Text = "Nota de venta"
            Case "P"
                LtVenta.Text = "Pedido"
            Case "C"
                LtVenta.Text = "Cotización"
            Case "R"
                LtVenta.Text = "Remisión"
            Case "D"
                LtVenta.Text = "Devolución (Nota de crédito)"
                'LA SERIE ES DIGITAL
                If Ldocu.Tag = "Digital" Then
                    CargarUsosCfdi()
                    CargarRegimenesFiscales()
                    Page2.TabVisible = True
                    Page3.TabVisible = False
                    CargarMonedas()
                    CargarMetodosPago()
                    CargarFormasPago()

                    If CVE_ART_NC.Trim.Length = 0 Then
                        MsgBox("Por favor capture la clave del articulo para notas de credito en parametros-inventario")
                    End If
                End If
        End Select

        Try
            If Encriptar(PASS_GRUPOCE.ToUpper) = "LEWxrrg5GxY=" Then
                Fg.Cols(9).Visible = True
                Fg.Cols(10).Visible = True
                Fg.Cols(11).Visible = True
                Fg.Cols(12).Visible = True

                Fg.Cols(15).Visible = True
                Fg.Cols(16).Visible = True
                Fg.Cols(17).Visible = True
                Fg.Cols(18).Visible = True

                Fg.Cols(18).Visible = True
                Fg.Cols(19).Visible = True
                Fg.Cols(20).Visible = True
            Else
                Fg.Cols(9).Visible = True
                Fg.Cols(10).Visible = True
                Fg.Cols(11).Visible = True
                Fg.Cols(12).Visible = True
                Fg.Cols(15).Visible = False
                Fg.Cols(16).Visible = False
                Fg.Cols(17).Visible = False
                Fg.Cols(18).Visible = False
                Fg.Cols(18).Visible = False
                Fg.Cols(19).Visible = False
                Fg.Cols(20).Visible = False
                Fg.Cols(21).Visible = False
                Fg.Cols(27).Visible = False
            End If
        Catch ex As Exception
            BITACORATPV("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Rows.Count = 1
        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                  "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
        ENTRA = True
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Do While dr.Read
                CboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
            Loop
            dr.Close()
            CboAlmacen.SelectedIndex = 0
        Catch ex As Exception
            BITACORATPV("45. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM PRECIOS" & Empresa & " WHERE STATUS = 'A' ORDER BY CVE_PRECIO"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                CboPrecio.Items.Add(Format(dr("CVE_PRECIO"), "00") & " " & dr("DESCRIPCION"))
            Loop
            dr.Close()
            CboPrecio.SelectedIndex = 0
        Catch ex As Exception
            BITACORATPV("47. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("47. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        DERECHOS()

        Try
            FgEdit = True
            Select Case MODO_EDIT
                Case "edit"
                    DOC_NEW = False
                    LtCVE_DOC.Text = Var12
                    Fg.Rows.Count = 1
                    BUSCAR_VENTA(TIPO_VENTA_LOCAL, Var12)
                    Fg.Cols(8).Visible = True : Fg.Cols(13).Visible = True : Fg.Cols(14).Visible = True
                    F1.Enabled = False

                    'DOCUMENTO ANTERIOR
                    If Var16.Trim.Length = 0 Then
                        Efecto = True
                        SE_MODIFICA = True
                    Else
                        SE_MODIFICA = False
                        Efecto = False
                    End If

                    If TCVE_PEDI.Text = "CARTA PORTE" Then
                        SE_MODIFICA = False
                        Efecto = False
                    Else
                        Fg.Cols(23).Visible = False
                    End If

                    If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "V" Then
                        SE_MODIFICA = False
                        Efecto = False
                    End If


                    TCLIENTE.Enabled = Efecto
                    BarGrabar.Enabled = Efecto
                    TCVE_PEDI.Enabled = Efecto : TCVE_VEND.Enabled = Efecto : BtnVend.Enabled = Efecto : btnEsquema.Enabled = Efecto : TDESC.Enabled = Efecto
                    tDesFin.Enabled = Efecto : tEntregarEn.Enabled = True : CboAlmacen.Enabled = Efecto : tEsquema.Enabled = Efecto
                    BarEliminar.Enabled = Efecto : BarSerie.Enabled = Efecto
                    BarAltaProv.Enabled = Efecto : BarAltaArticulo.Enabled = Efecto : BarEnlaceDocumento.Enabled = Efecto : BtnClie.Enabled = Efecto
                    BarLimpiar.Enabled = Efecto : FgEdit = Efecto
                    Fg.Enabled = True

                    BarObserDoc.Enabled = True : BarObserPar.Enabled = True

                    Label30.Visible = Efecto
                    LtDocAnt.Visible = Efecto
                    tCONDICION.Enabled = Efecto

                    TCVE_UNI.Enabled = Efecto
                    TCVE_TIPO.Enabled = Efecto
                    BtnUnidades.Enabled = Efecto
                    BtnTipo.Enabled = Efecto

                    TCVE_OPER.Enabled = Efecto
                    BtnOper.Enabled = Efecto
                    txCMT.Enabled = Efecto

                    Fg.Cols(1).Visible = False
                    Fg(0, 2) = "Cantidad"
                Case Else
                    DOC_NEW = True : TCLIENTE.Enabled = True : TCVE_PEDI.Enabled = True : TCVE_VEND.Enabled = True : BtnVend.Enabled = True
                    btnEsquema.Enabled = True : TDESC.Enabled = True : tDesFin.Enabled = True : tEntregarEn.Enabled = True : CboAlmacen.Enabled = True
                    tEsquema.Enabled = True : Fg.Enabled = True : CboTipoVenta.Enabled = True : F1.Enabled = False : BarGrabar.Enabled = True
                    BarEliminar.Enabled = True : BarObserDoc.Enabled = True : BarSerie.Enabled = True : BarAltaProv.Enabled = True : BarAltaArticulo.Enabled = True
                    Fg.Cols(1).Visible = False
                    Fg(0, 2) = "Cantidad"
            End Select
            tEntregarEn.Visible = False
            btnEntregarEn.Visible = False
            LEntregarEn.Visible = False

            Label29.Visible = False
            TCVE_OPER.Visible = False
            BtnOper.Visible = False
            LOper.Visible = False
            Label31.Visible = False
            txCMT.Visible = False

            If TCVE_PEDI.Text <> "CARTA PORTE" Then
                Fg.Cols(23).Width = 0
                Fg.Cols(24).Width = 0
                Fg.Cols(25).Width = 0
                Fg.Cols(26).Width = 0
            End If
            If TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "F" Then
                TCVE_UNI.Visible = False
                TCVE_TIPO.Visible = False
                BtnUnidades.Visible = False
                BtnTipo.Visible = False
                Label11.Visible = False
                Label17.Visible = False
                L4.Visible = False
                LUnidad.Visible = False
            End If
            If TIPO_VENTA_LOCAL = "F" Then
                Label11.Visible = True
                TCVE_UNI.Visible = True
                BtnUnidades.Visible = True
                LUnidad.Visible = True
                Label29.Visible = True
                TCVE_OPER.Visible = True
                BtnOper.Visible = True
                LOper.Visible = True
                Label31.Visible = True
                txCMT.Visible = True
            End If
        Catch ex As Exception
            BITACORATPV("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Try
                If Encriptar(PASS_GRUPOCE.ToUpper) = "LEWxrrg5GxY=" Then
                    For k = 1 To Fg.Cols.Count - 1
                        Fg(0, k) = Fg(0, k) & "(" & k & ")"
                    Next
                End If
            Catch ex As Exception
                BITACORATPV("55. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If MODO_EDIT = "edit" Then
                If (TIPO_VENTA_LOCAL = "C" Or TIPO_VENTA_LOCAL = "R") And SE_MODIFICA Then
                    _myEditor = New MyEditorTPV(Fg, LINEA_EN_VENTAS)
                    If Fg.Row > 0 Then
                        _myEditor.StartEditing(1, 2)
                    End If
                Else
                    Fg.AllowEditing = False
                End If
            Else
                _myEditor = New MyEditorTPV(Fg, LINEA_EN_VENTAS)
                TCLIENTE.Select()
            End If
        Catch ex As Exception
            BITACORATPV("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmTPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If
        Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
        Fg.Height = Me.Height - Tab1.Top - Tab1.Height - 30 - LtTOTAL.Height - BarraMENU.Height

        LtTOTAL.Left = Fg.Width - LtTOTAL.Width - 30
        LtTOTAL.Top = Fg.Top + Fg.Height + 10
        Label30.Top = LtTOTAL.Top
        LtDocAnt.Top = LtTOTAL.Top
        LtDocSig.Top = LtTOTAL.Top
        LtFactura.Top = LtTOTAL.Top


    End Sub
    Sub DERECHOS()
        If pwPoder Then
            Try
                BarEnlaceDocumento.Visible = True
                BarCancelar.Visible = True
                BarImprimir.Visible = True
                BarExcel.Visible = True
            Catch ex As Exception
            End Try
        Else
            Try
                BarEnlaceDocumento.Visible = False
                BarCancelar.Visible = False
                BarImprimir.Visible = False
                BarExcel.Visible = False
            Catch ex As Exception
            End Try
            Try
                Select Case TIPO_VENTA_LOCAL
                    Case "F"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                            CLAVE > 61000 AND CLAVE < 61700"
                    Case "R"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                            CLAVE > 50500 AND CLAVE < 60700"
                    Case "C"
                        SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                            CLAVE > 60100 AND CLAVE < 60300"
                End Select
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case TIPO_VENTA_LOCAL
                                Case "F"
                                    Select Case dr("CLAVE")
                                        Case 61400
                                            BarExcel.Visible = True
                                        Case 61450
                                            BarCancelar.Visible = True
                                        Case 61300
                                            BarImprimir.Visible = True
                                        Case 61500
                                            BarEnlaceDocumento.Visible = True
                                    End Select
                                Case "R"
                                    Select Case dr("CLAVE")
                                        Case 60560
                                            BarExcel.Visible = True
                                        Case 50590
                                            BarCancelar.Visible = True
                                        Case 60620
                                            BarImprimir.Visible = True
                                        Case 60650
                                            BarEnlaceDocumento.Visible = True
                                    End Select
                                Case "C"
                                    Select Case dr("CLAVE")
                                        Case 60160
                                            BarExcel.Visible = True
                                        Case 60190
                                            BarCancelar.Visible = True
                                        Case 60220
                                            BarImprimir.Visible = True
                                        Case 60250
                                            BarEnlaceDocumento.Visible = True
                                    End Select
                            End Select
                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("65. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Sub CARGA_PARAM_VENTAS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(CAPTURA_PAGO_VENTAS, 0) AS C_PAGO_VENTAS, ISNULL(C_ALTA_CLIENTES, 0) AS ALTA_CLIENTES,
                  ISNULL(C_ALTA_PRODUCTOS, 0) AS ALTA_PRODUCTOS, ISNULL(OBSER_X_DOC, 0) AS OBS_X_DOC,
                  ISNULL(OBSER_X_PARTIDA, 0) AS OBSER_X_PARTIDA, ISNULL(INDIRECTOS_X_PARTIDA, 0) AS INDIRECTOS_X_PARTIDA,
                  ISNULL(IMPUESTOS, 0) AS C_IMPUESTOS, ISNULL(ALMACEN, 0) AS C_ALMACEN, ISNULL(IMP_PART_KIT,0) AS I_PART_KIT,
                  ISNULL(BLOQUEAR_PRECIO_PV,0) AS BLOQ_PREC, ISNULL(LINEA_EN_VENTAS,'') AS LIN_VTA
                  FROM GCPARAMVENTAS"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                CAPTURA_PAGO_VENTA = dr("C_PAGO_VENTAS")
                ALTA_CLIENTES = dr("ALTA_CLIENTES")
                ALTA_PRODUCTOS = dr("ALTA_PRODUCTOS")
                OBSER_X_PARTIDA = dr("OBSER_X_PARTIDA")
                OBSER_X_DOC = dr("OBS_X_DOC")

                INDIRECTOS_X_PARTIDA = dr("INDIRECTOS_X_PARTIDA")
                C_IMPUESTOS = dr("C_IMPUESTOS")
                C_ALMACEN = dr("C_ALMACEN")
                C_I_PART_KIT = dr("I_PART_KIT")
                BLOQUEAR_PRECIO_PV = dr("BLOQ_PREC")
                LINEA_EN_VENTAS = dr("LIN_VTA")
            End If
            dr.Close()

            If pwPoder Then
                BarSerie.Visible = True
            Else
                If TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "F" Then
                    BarSerie.Visible = True
                Else
                    BarSerie.Visible = False
                End If
            End If

            If ALTA_CLIENTES = 0 Then
                BarAltaProv.Visible = False
            Else
                BarAltaProv.Visible = True
            End If
            If ALTA_PRODUCTOS = 0 Then
                BarAltaArticulo.Visible = False
            Else
                BarAltaArticulo.Visible = True
            End If
            Fg.Cols(1).Visible = False
            If C_IMPUESTOS = 0 Then
                Fg.Cols(9).Visible = False
                Fg.Cols(10).Visible = False
                Fg.Cols(11).Visible = False
                Fg.Cols(12).Visible = False
            Else
                Fg.Cols(9).Visible = True
                Fg.Cols(10).Visible = True
                Fg.Cols(11).Visible = True
                Fg.Cols(12).Visible = True
            End If
            If C_ALMACEN = 0 Then
                Fg.Cols(3).Visible = False
            Else
                Fg.Cols(3).Visible = True
            End If
            If ALTA_CLIENTES = 0 Then
                BarAltaProv.Visible = False
            Else
                BarAltaProv.Visible = True
            End If
        Catch ex As Exception
            BITACORATPV("70. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("70. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            CVE_ART_NC = ""

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(CVE_ART_NC,'') AS ART_NC FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                CVE_ART_NC = dr("ART_NC")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("75. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarEnlaceDocumento_Click(sender As Object, e As EventArgs) Handles BarEnlaceDocumento.Click
        Try
            Dim CVE_DOC As String

            If TIPO_VENTA_LOCAL = "F" Then
                Var15 = "R"

                DOC_ENLAZADO = "N"
                FrmEnlaceVentasGen.ShowDialog()
            Else
                If TIPO_VENTA_LOCAL = "D" Then
                    Var15 = "F"
                Else
                    Var15 = "P"
                End If

                DOC_ENLAZADO = "N"
                FrmEnlaceVentas.ShowDialog()
            End If
            If aDOCS.Length > 0 Then
                ENTRA = False
                LIMPIAR()
                Fg.Rows.Count = 1
                For k = 0 To aDOCS.Length - 1
                    CVE_DOC = aDOCS(k)

                    If CVE_DOC.Trim.Length > 0 Then
                        If TIPO_VENTA_LOCAL = "D" Then
                            '          FACTURA   DOCUMENT DOCUMENT2      
                            BUSCAR_CFDI(CVE_DOC, Var5, Var6)
                        Else
                            BUSCAR_VENTA(Var15, CVE_DOC)
                        End If

                    End If
                Next
                Try
                    LtDocAnt.Text = aDOCS(0)
                Catch ex As Exception
                End Try
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & " ")
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 2
                ENTRA = True
                DOC_ENLAZADO = "S"
            End If
        Catch ex As Exception
            BITACORATPV("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_VENTA(fTIPOC As String, fCVE_DOC As String)
        Dim PREC As Single, NUM_ALM As Integer, IEPS As Single, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single, Sigue As Boolean, s As String, j As Integer
        Dim LIB1 As Decimal = 0, LIB2 As String = "", LIB3 As String = "", LIB4 As String = "", LIB5 As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        With Fg
            Dim NewStyle1 As C1.Win.C1FlexGrid.CellStyle
            NewStyle1 = .Styles.Add("NewStyle1")
            NewStyle1.BackColor = System.Drawing.Color.Blue
            .SetCellStyle(0, 0, NewStyle1)
        End With

        Dim CustomStyle As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add("CustomStyle")
        CustomStyle.BackColor = Color.Orange
        LtCVE_DOC.Tag = 0
        Obser = ""

        If Not Valida_Conexion() Then
            Return
        End If


        cmd.Connection = cnSAE
        Try

            If TIPO_OTI = 0 Then
                If EXIST_FIELD_SQL_SAE("PAR_FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa, "CAMPLIB1") And
                    EXIST_FIELD_SQL_SAE("FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa, "CAMPLIB1") And
                    EXIST_FIELD_SQL_SAE("FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa, "CAMPLIB5") Then
                    SQL = "SELECT P.CVE_ART, CANT, I.DESCR AS DESCR_ART, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA,
                        EXIST, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, NUM_PAR, ISNULL(PXS,0) AS P_X_S, P.CVE_DOC,
                        ISNULL(P.NUM_ALM,1) AS NUMALM, ISNULL(P.DESC1,0) AS D1, ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI,
                        F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO,
                        C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE, ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, 
                        ISNULL(L.CAMPLIB1, '') AS LIB1, ISNULL(L.CAMPLIB5,'') AS S_OBS_DOC, ISNULL(LP.CAMPLIB1,'') AS S_OBS_PAR, 
                        ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG, DOC_SIG, F.STATUS, 
                        ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, P.CVE_ESQ " & IIf(fTIPOC.ToUpper.Equals("F"), ", F.CVE_TRACTOR, F.CVE_OPER, F.CMT", "") & "
                        FROM PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                        LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa & " L ON L.CLAVE_DOC = P.CVE_DOC
                        LEFT JOIN PAR_FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa & " LP ON LP.CLAVE_DOC = P.CVE_DOC AND LP.NUM_PART = P.NUM_PAR
                        LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                        LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                        LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
                Else
                    SQL = "SELECT P.CVE_ART, CANT, I.DESCR AS DESCR_ART, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA,
                        EXIST, ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(COSTO_PROM,0) AS COSTOPROM, NUM_PAR, ISNULL(PXS,0) AS P_X_S, P.CVE_DOC,
                        ISNULL(P.NUM_ALM,1) AS NUMALM, ISNULL(P.DESC1,0) AS D1, ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI,
                        F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO,
                        C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE, ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, 
                        ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG, DOC_SIG, F.STATUS,
                        ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, P.CVE_ESQ " & IIf(fTIPOC.ToUpper.Equals("F"), ", F.CVE_TRACTOR, F.CVE_OPER, F.CMT", "") & "
                        FROM PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                        LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                        LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                        LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
                End If
            Else
                SQL = "Select P.CVE_ART, CANT, I.DESCR AS DESCR_ART, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, 
                        UNI_VENTA, EXIST, ISNULL(ULT_COSTO, 0) As ULTCOSTO, ISNULL(COSTO_PROM, 0) As COSTOPROM, NUM_PAR, 
                        ISNULL(PXS, 0) As P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM, 1) As NUMALM, ISNULL(P.DESC1, 0) As D1, 
                        ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, 
                        C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,
                        ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, ISNULL(F.CVE_OBS, 0) As CVE_OBS_DOC, 
                        ISNULL(P.CVE_OBS, 0) As CVE_OBS_PAR, ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG,
                        DOC_SIG, ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, F.STATUS, P.CVE_ESQ " & IIf(fTIPOC.ToUpper.Equals("F"), ", F.CVE_TRACTOR, F.CVE_OPER, F.CMT", "") & "
                        FROM PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                        LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                        LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                        LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "'"
            End If

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Sigue = True : ENTRA = False : j = 0
            Do While dr.Read
                If Sigue Then
                    Try
                        If dr("STATUS") = "C" Then
                            LtCanc.Visible = True
                        Else
                            LtCanc.Visible = False
                        End If
                        TCLIENTE.Text = dr("CVE_CLPV")
                        TCVE_PEDI.Text = dr("PEDI")
                        TCVE_PEDI.Tag = dr("ENLAZADO_DOC")

                        If TCVE_PEDI.Text.Trim.Length > 0 Then
                            If fTIPOC.ToUpper = "R" Then
                                Label30.Visible = True
                                LtDocAnt.Visible = True

                                Label30.Text = "Remision enlazada a OT"
                                LtDocAnt.Text = TCVE_PEDI.Text
                            End If
                        Else
                            Label30.Text = "Doc. enlazado"
                            LtDocAnt.Text = ""
                        End If
                        LtNombre.Text = dr("NOMBRE").ToString
                        LtCalle.Text = dr("CALLE").ToString
                        LtColonia.Text = dr("COLONIA").ToString
                        LtNumInt.Text = dr("NUMINT").ToString
                        LtNumExt.Text = dr("NUMEXT").ToString
                        LtCP.Text = dr("CODIGO").ToString
                        LtRFC.Text = dr("RFC").ToString
                        LtPoblacion.Text = dr("MUNICIPIO").ToString
                        LtEstado.Text = dr("ESTADO").ToString
                        NUM_ALM = dr("NUMALM")
                        LtCVE_DOC.Tag = "0"
                        LtRFC.Tag = "0"

                        Try
                            If TIPO_OTI = 0 Then
                                Obser = dr("S_OBS_DOC")
                            Else
                                Obser = dr("DOC_OBS")
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            Select Case dr.ReadNullAsEmptyString("TIP_DOC_SIG")
                                Case "F"
                                    LtDocSig.Text = "Factura"
                                Case "V"
                                    LtDocSig.Text = "Nota de venta"
                                Case "R"
                                    LtDocSig.Text = "Remisión"
                                Case "C"
                                    LtDocSig.Text = "Cotización"
                                Case "P"
                                    LtDocSig.Text = "Pedido"
                                Case Else
                                    LtDocSig.Visible = False
                                    LtFactura.Visible = False
                            End Select
                            LtFactura.Text = dr.ReadNullAsEmptyString("DOC_SIG")
                        Catch ex As Exception
                            BITACORATPV("90. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Catch ex As Exception
                        BITACORATPV("95. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If Obser.Trim.Length = 0 Then
                        Try
                            If Obser.Trim.Length > 0 Then
                                If TIPO_OTI = 0 Then
                                    If EXIST_FIELD_SQL_SAE("FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa, "CAMPLIB5") Then
                                        SQL = "IF NOT EXISTS (SELECT CLAVE_DOC FROM FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa &
                                        " WHERE CLAVE_DOC = '" & fCVE_DOC & "') " &
                                        "INSERT INTO FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa & " (CLAVE_DOC, CAMPLIB5) VALUES('" &
                                        fCVE_DOC & "','" & Obser & "')"
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    End If
                                Else
                                    LtRFC.Tag = dr("CVE_OBS_DOC")
                                    Obser = dr.ReadNullAsEmptyString("DOC_OBS")
                                End If
                            End If
                        Catch ex As Exception
                            BITACORATPV("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    If fTIPOC.ToUpper.Equals("F") Then
                        TCVE_OPER.Text = dr.ReadNullAsEmptyString("CVE_OPER")
                        LOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)
                        txCMT.Text = dr.ReadNullAsEmptyString("CMT")
                        TCVE_UNI.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR")
                    Else
                        TCVE_UNI.Text = dr("PEDI")
                    End If



                    LUnidad.Text = BUSCA_CAT("Unidad", TCVE_UNI.Text)

                    TCVE_TIPO.Text = dr("CONDI")
                    L4.Text = BUSCA_CAT("Tipo unidad", TCVE_TIPO.Text)
                    Try
                        F1.Value = dr("FECHA_DOC")
                        F1.Tag = dr("FECHAELAB")
                    Catch ex As Exception
                    End Try
                    'tCONDICION.Text = tCVE_TIPO.Text
                    Try
                        If MULTIALMACEN = 1 Then
                            CboAlmacen.SelectedIndex = 0
                            For k = 0 To CboAlmacen.Items.Count - 1
                                If Val(CboAlmacen.Items(k).ToString.Substring(0, 2)) = NUM_ALM Then
                                    CboAlmacen.SelectedIndex = k
                                    Exit For
                                End If
                            Next
                        Else
                            CboAlmacen.SelectedIndex = 0
                        End If
                    Catch ex As Exception
                        BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    tEntregarEn.Text = dr("INF_NOMBRE")
                    TDESC.Value = dr("D1")
                    TCVE_VEND.Text = dr("VEND")
                    Sigue = False
                End If

                Try
                    If TIPO_OTI = 0 Then
                        If EXIST_FIELD_SQL_SAE("FACT" & fTIPOC.ToUpper & "_CLIB" & Empresa, "CAMPLIB1") Then
                            LIB1 = dr("LIB1")
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("115. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

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
                s = "" & vbTab '1
                s = s & dr("CANT") & vbTab '2
                s = s & dr("NUMALM") & vbTab '3
                s = s & dr("CVE_ART") & vbTab '4
                s = s & "" & vbTab '5
                s = s & dr("DESCR_ART") & vbTab '6
                s = s & dr("UNI_VENTA") & vbTab '7
                s = s & dr("DESC1") & vbTab '8
                s = s & dr("IMPU1") & vbTab '9
                s = s & dr("IMPU2") & vbTab '10
                s = s & dr("IMPU3") & vbTab '11
                s = s & dr("IMPU4") & vbTab '12
                s = s & PREC & vbTab '13
                s = s & dr("CANT") * PREC & vbTab '14
                s = s & dr("CVE_ART") & vbTab '15
                s = s & "" & vbTab '16
                s = s & "" & vbTab '17
                s = s & dr("NUM_PAR") & vbTab '18
                s = s & fCVE_DOC & vbTab '19
                s = s & fTIPOC.ToUpper & vbTab '20
                s = s & "0" & vbTab '21
                Try
                    If TIPO_OTI = 0 Then
                        s = s & dr("S_OBS_PAR") & vbTab '22
                    Else
                        s = s & dr("PAR_OBS") & vbTab '22
                    End If
                Catch ex As Exception
                    s = s & dr("PAR_OBS") & vbTab '22
                End Try

                'TONELADAS & "','" & REMISION & "','" & CVE_FOLIO & "','" & UNIDAD & "','" & FECHA & "')"
                s = s & LIB3 & vbTab '23    CARTA PORTE 
                s = s & LIB2 & vbTab '24    REMISION CARGA
                s = s & LIB4 & vbTab '25    UNIDAD
                s = s & LIB1 & vbTab '26    TONELADAS
                s = s & dr("CVE_ESQ") '27    P.CVE_ESQ

                Fg.AddItem("" & vbTab & s)
                j += 1
                If dr("TIPOELE") = "K" Then
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.SetCellStyle(Fg.Row, 6, CustomStyle)
                End If
            Loop
            Try
                Var13 = "SOLOTOTAL"
                CALCULAR_IMPORTES()
            Catch ex As Exception
            End Try

            If (TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D") And Ldocu.Tag = "Digital" Then
                LtFAC_CVE_DOC.Text = fCVE_DOC
                LtUUID.Text = BUSCAR_UUID_FACTURA_TRANSPORT(fCVE_DOC)
            End If

            If Fg.Rows.Count = 1 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
            End If
        Catch ex As Exception
            BITACORATPV("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Sub BUSCAR_CFDI(FFACTURA As String, FDOCUMENT As String, FDOCUMENT2 As String)
        Dim PREC As Single, IEPS As Single, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single, Sigue As Boolean, s As String, j As Integer
        Dim LIB1 As Decimal = 0, LIB2 As String = "", LIB3 As String = "", LIB4 As String = "", LIB5 As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        With Fg
            Dim NewStyle1 As C1.Win.C1FlexGrid.CellStyle
            NewStyle1 = .Styles.Add("NewStyle1")
            NewStyle1.BackColor = System.Drawing.Color.Blue
            .SetCellStyle(0, 0, NewStyle1)
        End With

        Dim CustomStyle As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add("CustomStyle")
        CustomStyle.BackColor = Color.Orange
        LtCVE_DOC.Tag = 0
        Obser = ""

        If Not Valida_Conexion() Then
            Return
        End If
        cmd.Connection = cnSAE
        Try

            SQL = "SELECT C.CVE_FOLIO, C.CVE_VIAJE, C.CVE_DOCR, C.CLIENTE, C.FECHA_DOC, C.TIPO_VIAJE, C.CVE_OPER, C.CLAVE_O, C.CLAVE_D, C.CVE_TRACTOR, 
                C.CVE_TANQUE1, C.CVE_TANQUE2, C.CVE_DOLLY, C.RECOGER_EN, C.ENTREGAR_EN, C.CVE_PLAZA1, C.CVE_PLAZA2, ISNULL(PESO_BRUTO1,0) AS PESO1, 
                ISNULL(TARA1,0) AS T1, ISNULL(PESO_BRUTO2,'0') AS PESO2, ISNULL(TARA2,'0') AS T2, ISNULL(PESO_BRUTO3,'0') AS PESO3, ISNULL(TARA3,'0') AS T3,
                ISNULL(PESO_BRUTO4,'0') AS PESO4, ISNULL(TARA4,'0') AS T4, C.CVE_MAT, FLETE, C.FECHA_CARGA, C.FECHA_DESCARGA, CVE_DOCP, C.ORDEN_DE, 
                C.EMBARQUE, C.CARGA_ANTERIOR, C.REM_CARGA, VALOR_DECLARADO, SUBTOTAL, IVA, RETENCION, NETO, ISNULL(CANT,0) AS CANTIDAD, 
                ISNULL(U.PLACAS_MEX,'') AS PLACAS_MEX_TRACTOR, ISNULL(U2.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE1, ISNULL(U2.SUBTIPOREM,'') AS SUTIREM1, 
                ISNULL(U3.PLACAS_MEX,'') AS PLACAS_MEX_TANQUE2, ISNULL(U3.SUBTIPOREM,'') AS SUTIREM2, ISNULL(U.ANO_MODELO,'') AS ANO_MOD,
                STUFF(CONVERT(VARCHAR(50), C.FECHAELAB, 127), 20, 4, '') AS FELAB, A.POLIZARESPCIVIL, A.ASEGURARESPCIVIL, C.CVE_ART, 
                ISNULL(P.DESCR,'') AS DESCR_MAT, ISNULL(PEDIMENTO,'') AS CP_PEDIMENTO, R1.DESCR AS DESCR_RECOGER_EN, R2.DESCR AS DESCR_ENTREGAR_EN,
                ISNULL(I.CVE_ESQIMPU,0) AS CVE_ESQ, T.NOMBRE, T.RFC, T.CALLE, T.COLONIA, T.NUMINT, T.NUMEXT, T.CODIGO, T.MUNICIPIO, T.ESTADO,
                IMPUESTO1 AS IMPU1, IMPUESTO2 AS IMPU2, IMPUESTO3 AS IMPU3, IMPUESTO4 AS IMPU4, IMP4APLICA, IMP1APLICA, CVE_MAT, TIPO_ELE, 
                UNI_MED AS UNI_VENTA, I.DESCR AS DES
                FROM GCCARTA_PORTE C 
                LEFT JOIN CLIE" & Empresa & " T ON T.CLAVE = C.CLIENTE
                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = C.CVE_MAT
                LEFT JOIN IMPU" & Empresa & " IP ON IP.CVE_ESQIMPU = I.CVE_ESQIMPU
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R1 ON R1.CVE_REG = C.RECOGER_EN
                LEFT JOIN GCRECOGER_EN_ENTREGAR_EN R2 ON R2.CVE_REG = C.ENTREGAR_EN
                LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = C.CVE_TRACTOR
                LEFT JOIN GCUNIDADES U2 ON U2.CLAVEMONTE = C.CVE_TANQUE1
                LEFT JOIN GCUNIDADES U3 ON U3.CLAVEMONTE = C.CVE_TANQUE2
                LEFT JOIN GCASEGURADORAS A ON A.CLAVE = U.SE_ASEGURADORA
                LEFT JOIN GCPRODUCTOS P ON P.CVE_PROD = CAST(C.CVE_ART AS INT)
                WHERE (CVE_FOLIO = '" & FDOCUMENT & "' OR CVE_FOLIO = '" & FDOCUMENT2 & "') AND C.STATUS = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Sigue = True : ENTRA = False : j = 0
            Do While dr.Read
                If Sigue Then
                    Try
                        TCLIENTE.Text = dr("CLIENTE")
                        'tCVE_PEDI.Text = dr("PEDI")
                        TCVE_PEDI.Tag = dr("ENLAZADO_DOC")

                        Label30.Text = "Doc. enlazado"
                        LtDocAnt.Text = ""

                        LtNombre.Text = dr("NOMBRE").ToString
                        LtCalle.Text = dr("CALLE").ToString
                        LtColonia.Text = dr("COLONIA").ToString
                        LtNumInt.Text = dr("NUMINT").ToString
                        LtNumExt.Text = dr("NUMEXT").ToString
                        LtCP.Text = dr("CODIGO").ToString
                        LtRFC.Text = dr("RFC").ToString
                        LtPoblacion.Text = dr("MUNICIPIO").ToString
                        LtEstado.Text = dr("ESTADO").ToString
                        'NUM_ALM = dr("NUMALM")
                        LtCVE_DOC.Tag = "0"
                        LtRFC.Tag = "0"

                    Catch ex As Exception
                        BITACORATPV("130. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    'tCVE_UNI.Text = dr("PEDI")
                    LUnidad.Text = BUSCA_CAT("Unidad", dr("CVE_TRACTOR"))

                    'tCVE_TIPO.Text = dr("CONDI")
                    'L4.Text = BUSCA_CAT("Tipo unidad", tCVE_TIPO.Text)
                    Try
                        F1.Value = dr("FECHA_DOC")
                        F1.Tag = dr("FECHAELAB")
                    Catch ex As Exception
                    End Try
                    'tCONDICION.Text = tCVE_TIPO.Text
                    'tEntregarEn.Text = dr("INF_NOMBRE")
                    'tDesc.Value = dr("D1")
                    'tCVE_VEND.Text = dr("VEND")
                    Sigue = False
                End If


                PREC = dr("SUBTOTAL")
                PREC = Math.Round(PREC, 4)
                DESCP = 0 'PREC * dr("DESC1") / 100
                IEPS = dr("IMPU1")
                cIEPS = (PREC - DESCP - DESCP2) * IEPS / 100
                IMPU = dr("IMPU4")
                cIMPU = (PREC - DESCP - DESCP2 + cIEPS) * IMPU / 100
                PrecioVenta = PREC - DESCP - DESCP2
                '18 NUM_PAR
                '19 CVE_DOC_ENLAZADO
                '20 ENLACE_TIP_DOC
                s = "" & vbTab '1
                s = s & 1 & vbTab '2
                s = s & 1 & vbTab '3
                s = s & dr("CVE_MAT") & vbTab '4
                s = s & "" & vbTab '5
                s = s & dr("DES") & " (" & dr("TIPO_ELE") & ")" & vbTab '6
                s = s & dr("UNI_VENTA") & vbTab '7
                s = s & 0 & vbTab '8
                s = s & dr("IMPU1") & vbTab '9
                s = s & dr("IMPU2") & vbTab '10
                s = s & dr("IMPU3") & vbTab '11
                s = s & dr("IMPU4") & vbTab '12
                s = s & PREC & vbTab '13
                s = s & 1 * PREC & vbTab '14
                s = s & dr("CVE_MAT") & vbTab '15
                s = s & "" & vbTab '16
                s = s & "" & vbTab '17
                s = s & 1 & vbTab '18
                s = s & "" & vbTab '19
                s = s & "" & vbTab '20
                s = s & "0" & vbTab '21
                s = s & IIf(j = 0, FDOCUMENT, FDOCUMENT2) & vbTab '23    CARTA PORTE 
                s = s & dr("REM_CARGA") & vbTab '24    REMISION CARGA
                s = s & dr("CVE_TRACTOR") & vbTab '25    UNIDAD
                s = s & dr("PESO1") - dr("T1") & vbTab '25    TONELADAS
                Fg.AddItem("" & vbTab & s)
                j += 1
            Loop
            Try
                Var13 = "SOLOTOTAL"
                CALCULAR_IMPORTES()
            Catch ex As Exception
            End Try

            If (TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D") And Ldocu.Tag = "Digital" Then
                LtFAC_CVE_DOC.Text = FFACTURA
                LtUUID.Text = BUSCAR_UUID_FACTURA_TRANSPORT(FFACTURA)
            End If

            If Fg.Rows.Count = 1 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
            End If
        Catch ex As Exception
            BITACORATPV("135. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub FrmTPV_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
            CloseTab("Punto de venta")

            If PassData8 = "FACTURAS" Then
                If Form_Open(frmFACTURAS) Then
                    frmFACTURAS.REFRESCAR()
                End If
            Else
                If Form_Open(FrmDocumentos) Then
                    FrmDocumentos.REFRESCAR()
                End If
            End If

        Catch ex As Exception
            BITACORATPV("137. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("137. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSerie_Click(sender As Object, e As EventArgs) Handles BarSerie.Click
        Try
            Var14 = TIPO_VENTA_LOCAL

            If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D" Then
                Var15 = ""
            Else
                Var15 = "I"
            End If
            frmSelSerie.ShowDialog()
            If Var14.Trim.Length > 0 Then

                LETRA_VENTA = Var14
                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)

                If (TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D") And Var18 = "Digital" Then
                    CargarUsosCfdi()
                    CargarRegimenesFiscales()
                    CargarMonedas()
                    CargarMetodosPago()
                    CargarFormasPago()

                    Page2.TabVisible = True
                    Page3.TabVisible = False

                    Ldocu.Tag = Var18 ' = "Digital"

                    If TIPO_VENTA_LOCAL = "D" Then
                        If CVE_ART_NC.Trim.Length = 0 Then
                            MsgBox("Por favor capture la clave del articulo para notas de credito en parametros-inventario")
                        End If
                    End If
                Else
                    Page2.TabVisible = False
                    Page3.TabVisible = False
                End If

            End If
        Catch ex As Exception
            BITACORATPV("139. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("139. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_PEDI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_PEDI.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Try
                    If e.KeyCode = Keys.Enter Then
                        If TCLIENTE.Text.Trim.Length = 0 Then
                            MsgBox("Por favor capture la clave del cliente")
                            TCLIENTE.Focus()
                            Return
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("140. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                TCVE_VEND.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles TDESC.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D" Then
                    CboPrecio.Focus()
                Else
                    TCVE_UNI.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TDesFin_KeyDown(sender As Object, e As KeyEventArgs) Handles tDesFin.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                If tCONDICION.Visible Then
                    tCONDICION.Focus()
                Else
                    Dim c_ As Integer
                    If Fg.Col = 1 Then
                        c_ = 2
                    Else
                        c_ = Fg.Col
                    End If
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, c_, 0)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TEntregarEn_KeyDown(sender As Object, e As KeyEventArgs) Handles tEntregarEn.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnEntregarEn_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = Keys.Enter Then
                If TCLIENTE.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del cliente")
                    TCLIENTE.Focus()
                    Return
                End If
                Try
                    If e.KeyCode = 13 Or e.KeyCode = 9 Then
                        Dim c_ As Integer
                        If Fg.Col = 1 Then
                            c_ = 2
                        Else
                            c_ = Fg.Col
                        End If
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(Fg.Row, c_, 0)
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            BITACORATPV("142. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("142. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_VENTA(fTIPO_DOC As String, fCVE_DOC As String)
        Dim Rreporte_MRT As String
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
            If Fg.Row > 0 Then
                Select Case TIPO_VENTA_LOCAL
                    Case "F"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportFactura" & Empresa & ".mrt"
                        If File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportFactura" & Empresa & ".mrt"
                        Else
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportFactura.mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "V"
                        Rreporte_MRT = RUTA_FORMATOS & "\Nota de Venta Ticket.mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\Nota de Venta Ticket" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                            End If
                            Return
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "P"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportPedido.mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportPedido" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                            End If
                            Return
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "C"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportCotizacion.mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportCotizacion" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                            End If
                            Return
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "D"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportDevoluciones.mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportDevoluciones" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                            End If
                            Return
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "R"
                        If REM_CARTA_PORTE Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportRemisionCAP" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                Rreporte_MRT = RUTA_FORMATOS & "\ReportRemisionCAP.mrt"
                                If Not File.Exists(Rreporte_MRT) Then
                                    MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                    Return
                                End If
                            End If
                        Else
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportRemision" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                Rreporte_MRT = RUTA_FORMATOS & "\ReportRemision.mrt"
                                If Not File.Exists(Rreporte_MRT) Then
                                    MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                    Return
                                End If
                            End If
                        End If

                        StiReport1.Load(Rreporte_MRT)
                End Select
                Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

                StiReport1.Dictionary.Databases.Clear()
                StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

                StiReport1.Compile()
                StiReport1.Dictionary.Synchronize()
                StiReport1.ReportName = Me.Text
                StiReport1.Item("REFER") = fCVE_DOC
                StiReport1.Render()
                StiReport1.Show()
            Else
                MsgBox("Por favor seleccione el documento a imprimir")
            End If
        Catch ex As Exception
            BITACORATPV("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click_1(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Try
            If DOC_NEW Then
                MsgBox("Para re-imprimir el documento se debe de grabar, cuando es un documento nuevo se imprime al grabar")
                Return
            End If

            If Ldocu.Tag = "Digital" Then
                IMPRIMIR_CFDI_40(LtCVE_DOC.Text, "FACTURAS")
            Else
                IMPRIMIR_VENTA(TIPO_VENTA_LOCAL, LtCVE_DOC.Text)
            End If

        Catch ex As Exception
            BITACORATPV("210. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTotales_Click(sender As Object, e As EventArgs) Handles BarTotales.Click

        If Not ExistenPartidas() Then
            MsgBox("No existen partidas por favor agreguelas")
            Return
        End If

        If TCLIENTE.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un cliente")
            Return
        End If

        Var9 = "Parcial"
        Var7 = "TOTALES"
        Var13 = "VENTANA COBRO"
        CALCULAR_IMPORTES()

        FrmVentanaCobro.ShowDialog()
    End Sub
    Sub CALCULAR_IMPORTES(Optional FROW As Integer = 0, Optional FCANT As Decimal = 1)

        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader

        Dim IMPORTE As Single, DESCUENTO1 As Single, ImporteConDes As Single, DESC1 As Single
        Dim CVE_ESQIMPU As Integer = 1, CAN_TOT As Single, DES_TOT As Single, PRECIO As Single, PRECIO_NETO As Single

        Dim cIeps As Single, cImpu As Single, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer
        Dim TOTIMP1 As Single, TOTIMP2 As Single, TOTIMP3 As Single, TOTIMP4 As Single
        Dim IMPU1 As Single, IMPU2 As Single, IMPU3 As Single, IMPU4 As Single, cImpu2 As Single, cImpu3 As Single
        Dim ImporteIeps As Single, ImporteImpu2 As Single, ImporteImpu3 As Single, ImporteIVA As Single
        Dim CANT As Single, CVE_ART As String

        cmd.Connection = cnSAE

        Try
            DES_TOT = 0
            TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To Fg.Rows.Count - 1

                Try
                    CVE_ART = Fg(i, 4)
                    CVE_ART = CVE_ART.Replace("'", "")
                Catch ex As Exception
                    CVE_ART = ""
                End Try
                Try
                    If FROW = 0 Then
                        CANT = Fg(i, 2)
                    Else
                        If i = FROW Then
                            CANT = FCANT
                        Else
                            CANT = Fg(i, 2)
                        End If
                    End If
                    If CVE_ART.Length > 0 And CANT > 0 Then
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
                            MsgBox("230. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                            BITACORATPV("230. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & Fg(i, 27)
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CSng(Reader("IMPUESTO1"))
                                IMPU2 = CSng(Reader("IMPUESTO2"))
                                IMPU3 = CSng(Reader("IMPUESTO3"))
                                IMPU4 = CSng(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            BITACORATPV("241. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("241. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try

                        Try
                            DESC1 = CSng(Fg(i, 8))
                            PRECIO = CSng(Fg(i, 13))
                            PRECIO = Math.Round(CDec(PRECIO), 6)
                            PRECIO_NETO = PRECIO - (PRECIO * DESC1 / 100)

                            DESCUENTO1 = (CANT * PRECIO * DESC1 / 100)
                            ImporteConDes = (CANT * PRECIO) - DESCUENTO1
                            ImporteConDes = Math.Round(CDec(ImporteConDes), 6)

                            DES_TOT += DESCUENTO1

                            cIeps = PRECIO_NETO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CSng((PRECIO_NETO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CSng(PRECIO_NETO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CSng((PRECIO_NETO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CSng(PRECIO_NETO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (PRECIO_NETO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = PRECIO_NETO * IMPU4 / 100
                            End If

                            ImporteIeps += (PRECIO_NETO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (PRECIO_NETO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (PRECIO_NETO * CANT * IMPU3 / 100)
                            ImporteIVA += (PRECIO_NETO * CANT * IMPU4 / 100)


                            TOTIMP1 += (CANT * cIeps)
                            TOTIMP2 += (CANT * cImpu2)
                            TOTIMP3 += (CANT * cImpu3)
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (PRECIO_NETO + cIeps + cImpu2 + cImpu3 + cImpu))
                            CAN_TOT += (CANT * PRECIO)

                            Fg(i, 14) = (CANT * PRECIO_NETO)
                        Catch ex As Exception
                            MsgBox("242. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                            BITACORATPV("242. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    MsgBox("243. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                    BITACORATPV("243. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            If Var13 = "SOLOTOTAL" Then
                LtTOTAL.Text = Format(CAN_TOT - DES_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")
            Else
                FrmVentanaCobro.LtSubtotal.Text = Format(CAN_TOT, "###,##0.00")
                FrmVentanaCobro.LtDesc.Text = Format(DES_TOT, "###,##0.00")
                FrmVentanaCobro.LtIeps.Text = Format(TOTIMP1, "###,##0.00")
                FrmVentanaCobro.LtImpu2.Text = Format(TOTIMP2, "###,##0.00")
                FrmVentanaCobro.LtImpu3.Text = Format(TOTIMP3, "###,##0.00")
                FrmVentanaCobro.LtIVA.Text = Format(TOTIMP4, "###,##0.00")
                FrmVentanaCobro.LtTotal.Text = Format(CAN_TOT - DES_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")
                FrmVentanaCobro.LtImporteTotal.Text = Format(CAN_TOT - DES_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")
            End If

            Var13 = ""
        Catch ex As Exception
            BITACORATPV("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENA_CAMPOS(ByVal fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If IsNumeric(fCLAVE.Trim) Then
                fCLAVE = Space(10 - fCLAVE.Trim.Length) & fCLAVE.Trim
                TCLIENTE.Text = fCLAVE
            End If

            cmd.Connection = cnSAE
            SQL = "SELECT NOMBRE, CALLE, COLONIA, NUMINT, NUMEXT, CODIGO, RFC, MUNICIPIO, ESTADO, 
                ISNULL(LISTA_PREC,1) AS PRECIO, ISNULL(USO_CFDI,'') AS USOCFDI, REG_FISC, 
                ISNULL(FORMADEPAGOSAT,'') AS FPAGOSAT, ISNULL(METODODEPAGO,'') AS METPAGO, ISNULL(EMAILPRED,'') AS CORREO
                FROM CLIE" & Empresa & " WHERE CLAVE  = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                LtNombre.Text = dr("NOMBRE").ToString
                LtNombre.Tag = dr("CORREO").ToString
                LtCorreo.Text = dr("CORREO").ToString
                LtCalle.Text = dr("CALLE").ToString
                LtColonia.Text = dr("COLONIA").ToString
                LtNumInt.Text = dr("NUMINT").ToString
                LtNumExt.Text = dr("NUMEXT").ToString
                LtCP.Text = dr("CODIGO").ToString
                LtRFC.Text = dr("RFC").ToString
                LtPoblacion.Text = dr("MUNICIPIO").ToString
                LtEstado.Text = dr("ESTADO").ToString
                USO_CFDI = dr("USOCFDI")
                REG_FISC = dr.ReadNullAsEmptyString("REG_FISC")

                For k = 1 To CboPrecio.Items.Count - 1
                    If Val(CboPrecio.Items(k).ToString.Substring(0, 2)) = dr("PRECIO") Then
                        CboPrecio.SelectedIndex = k
                        Exit For
                    End If
                Next

                If dr("METPAGO").Trim.Length > 0 Then
                    For k = 0 To cbMetodoPago.Items.Count - 1
                        cbMetodoPago.SelectedIndex = k
                        If (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago = dr("METPAGO") Then
                            cbMetodoPago.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If
                If dr("FPAGOSAT").Trim.Length > 0 Then
                    For k = 0 To cbFormaPago.Items.Count - 1
                        cbFormaPago.SelectedIndex = k
                        If (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago = dr("FPAGOSAT") Then
                            cbFormaPago.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If

                If USO_CFDI.Trim.Length > 0 Then
                    For k = 0 To cbUsoCfdi.Items.Count - 1
                        cbUsoCfdi.SelectedIndex = k
                        If (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI = USO_CFDI Then
                            cbUsoCfdi.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If
                cbRegimenesFiscales.SelectedIndex = -1
                If REG_FISC.Trim.Length > 0 Then
                    Try
                        For k = 0 To cbRegimenesFiscales.Items.Count - 1
                            cbRegimenesFiscales.SelectedIndex = k
                            If (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal = REG_FISC Then
                                cbRegimenesFiscales.SelectedIndex = k
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        BITACORATPV("480. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                MsgBox("Cliente inexistente")
                TCLIENTE.Text = ""
                TCLIENTE.Select()

            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function ExistenPartidas() As Boolean
        Try
            Dim Siok As Boolean = False
            For k = 1 To Fg.Rows.Count - 1
                Try
                    If Fg(k, 2) > 0 And Fg(k, 4).ToString.Trim.Length > 0 Then
                        Siok = True
                        Exit For
                    End If
                Catch ex As Exception
                    BITACORATPV("340. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Return Siok
        Catch ex As Exception
            BITACORATPV("350. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Private Function ValidaExistencias() As Boolean
        Dim bContinua As Boolean = False
        Try
            Dim cmd As New SqlCommand

            Dim CveArt As String
            Dim Cant As Double
            Dim k As Integer

            cmd.Connection = cnSAE

            For k = 1 To Fg.Rows.Count - 1

                Cant = Fg(k, 2)
                CveArt = Fg(k, 4)

                SQL = "SELECT CVE_ART, TIPO_ELE, EXIST FROM INVE" & Empresa & " I WHERE I.CVE_ART = '" & CveArt & "'"
                cmd.CommandText = SQL
                Using dr = cmd.ExecuteReader
                    If dr.Read Then

                        If dr("TIPO_ELE") = "P" Then
                            If Convert.ToDecimal(dr("EXIST") >= Cant) Then
                                bContinua = True
                            Else
                                MsgBox("La Cantidad solicitada: " & Cant & " del Artículo: " & CveArt & " excede las existencias: " & dr("EXIST"), MsgBoxStyle.Exclamation, "Inventario")
                                bContinua = False
                                Return bContinua
                            End If
                        Else
                            bContinua = True
                        End If

                    End If
                End Using
            Next
        Catch ex As Exception
            BITACORATPV("3880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return bContinua
    End Function
    Sub GRABAR()
        Try
            BarGrabar_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Try
            Dim Sigue As Boolean = False

            If Not ExistenPartidas() Then
                MsgBox("No existen partidas por favor agreguelas")
                Return
            End If
            If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                If Not ValidaExistencias() Then
                    Return
                End If
            End If

            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un cliente")
                Return
            End If
            If OBSER_X_DOC = 1 Then
                Var4 = Obser
                Var5 = "NUEVO"
                Var6 = "FACTF_CLIB"
                Var7 = "FACT" & TIPO_VENTA & "_CLIB" & Empresa

                If DOC_NEW Then
                    Var8 = ""
                Else
                    Var8 = LtCVE_DOC.Text
                End If

                FrmObserYCampLib.ShowDialog()
                Obser = Var4
                Sigue = True
            Else
                Sigue = True
            End If
            If Sigue = True Then
                Var7 = ""
                Var8 = ""
                Var13 = "SOLOTOTAL"
                CALCULAR_IMPORTES()
                VarFORM = ""
                If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                    ReDim aTPV(1, 1)
                    FrmVentanaTipoVenta.ShowDialog()
                    'VarFORM = "CONTADO"
                    'VarFORM = "CREDITO"
                    If VarFORM = "CONTADO" Or VarFORM = "CREDITO" Then
                        CREDITO = VarFORM
                        'VarFORM = NO_AFECTAR_MINVE_NOTA_VENTA
                        If VarFORM = "CONTADO" Then

                            Var9 = "Parcial"
                            Var7 = ""
                            Var13 = "VENTANA COBRO"
                            CALCULAR_IMPORTES()

                            FrmVentanaCobro.ShowDialog()
                            If VarFORM = "GRABAR" Then
                                GUARDAR()
                            End If
                        Else
                            GUARDAR()
                        End If
                    End If
                Else
                    GUARDAR()
                End If
            End If
        Catch ex As Exception
            BITACORATPV("360. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub GUARDAR()

        Dim COSTO_PROM_GRAL As Decimal
        Dim NUM_MOV As Long, NUM_MOV_KIT As Long, CANT As Decimal, CANT_ORIGINAL As Decimal, CANT_SURTIDA As Decimal
        Dim FOLIO As Integer, CLIENTE As String, CVE_ART As String, EXIST As Decimal, NUM_PAR_ENLAZADO As Integer, CVE_DOC_ENLAZADO As String
        Dim ENLACE_TIP_DOC As String = "", NUM_PAR_KIT As Integer, CANT_KIT As Decimal, PRECIO_KIT As Decimal, CVE_PROD As String, ANT_SIG As String
        Dim PRECIO As Decimal, PREC As Decimal, DESC1 As Decimal, DESC2 As Decimal, DESC3 As Decimal, ALMACEN As Integer, MULTIALMACEN As Integer
        Dim TIP_DOC As String, E_LTPD As Integer, DES_FIN As Decimal, FECHA_ENT As String
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim cImpu1 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu4 As Decimal
        Dim SUBTOTAL As Decimal, ImporteConDes As Decimal, DES_TOT As Decimal, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, IMPORTE As Decimal, COM_TOT As Decimal
        Dim CVE_DOC As String, STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim FECHA_DOC As String, FECHA_VEN As String, CAN_TOT As Decimal, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal
        Dim CONDICION As String, CVE_OBS As Long, NUM_ALMA As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Long, TIPCAMB As Decimal, NUM_PAGOS As Long, PRIMERPAGO As Decimal, DOC_ANT As String, RFC As String
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String, CVE_BITA As Long
        Dim Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, COM_TOT_PORC As Decimal
        'variables partidas
        Dim NUMCTAPAGO As String, TIP_DOC_ANT As String, NUM_PAR As Integer, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer
        Dim CVE_ESQ As Integer, COST As Decimal, COMI As Decimal, APAR As Decimal, ACT_INV As String, POLIT_APLI As String, TIP_CAM As Decimal
        Dim TIPO_PROD As String, TIPO_PROD2 As String = "", REG_SERIE As Long, TIPO_ELEM As String, TOT_PARTIDA As Decimal
        Dim APL_MAN_IEPS As String, MTO_PORC As Integer, MTO_CUOTA As Integer
        'MOVSINV
        Dim CVE_CPTO As Integer, FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, FORMADEPAGOSAT As String, UNI_MED As String
        Dim COSTO_PROM As Decimal, UUID As String, SIGUE As Boolean, FOLIO_ASIGNADO As Boolean
        Dim cIEPS As Decimal, cIMPU As Decimal, UNI_VENTA As String, FECHAELAB As String, CADENA_FECHELAB As String
        Dim cmdT As New SqlCommand
        Dim cmdF As New SqlCommand
        Dim cmdP As New SqlCommand
        Dim cmd As New SqlCommand

        Try
            USO_CFDI = "" : FORMADEPAGOSAT = "" : NUM_MONED = 1 : METODODEPAGO = ""

            Select Case TIPO_VENTA_LOCAL
                Case "F"

                    If Ldocu.Tag = "Digital" Then

                        If cbUsoCfdi.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If

                        If Not IsNothing(cbUsoCfdi.SelectedItem) Then
                            USO_CFDI = (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI

                            If IsNothing(USO_CFDI) Then
                                MsgBox("Por favor seleccione el uso CFDI")
                                Tab1.SelectedIndex = 1
                                Return
                            End If

                            If USO_CFDI.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione el uso CFDI")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                        End If
                        'MONEDA
                        If cbMoneda.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If
                        If Not IsNothing(cbMoneda.SelectedItem) Then
                            MONEDA = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda

                            If IsNothing(MONEDA) Then
                                MsgBox("Por favor seleccione la moneda")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                            If MONEDA.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione la moneda")
                                Tab1.SelectedIndex = 1
                                Return
                            End If

                            NUM_MONED = (CType(cbMoneda.SelectedItem, cMoneda)).Id

                        End If
                        'METODODEPAGO 
                        If cbMetodoPago.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If
                        If Not IsNothing(cbMetodoPago.SelectedItem) Then
                            METODODEPAGO = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago

                            If IsNothing(METODODEPAGO) Then
                                MsgBox("Por favor seleccione metodo de pago")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                            If METODODEPAGO.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione metodo de pago")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                        End If
                        'FORMADEPAGOSAT 
                        If cbFormaPago.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If
                        If Not IsNothing(cbFormaPago.SelectedItem) Then
                            FORMADEPAGOSAT = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago

                            If IsNothing(FORMADEPAGOSAT) Then
                                MsgBox("Por favor seleccione la forma de pago SAT")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                            If FORMADEPAGOSAT.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione la forma de pago SAT")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                        End If
                        'REG_FISC
                        If cbRegimenesFiscales.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If
                        If Not IsNothing(cbRegimenesFiscales.SelectedItem) Then
                            REG_FISC = (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal

                            If IsNothing(REG_FISC) Then
                                MsgBox("Por favor seleccione la forma de pago SAT")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                            If REG_FISC.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione la forma de pago SAT")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                        End If
                    End If
                    If MsgBox("Realmente desea grabar la factura?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "V"
                    If MsgBox("Realmente desea grabar la nota de venta?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "P"
                    If MsgBox("Realmente desea grabar el pedido?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "C"
                    If MsgBox("Realmente desea grabar la cotizacion?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "R"
                    If MsgBox("Realmente desea grabar la remision?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "D"
                    If Ldocu.Tag = "Digital" Then
                        If CVE_ART_NC.Trim.Length = 0 Then
                            MsgBox("Por favor capture la clave del artículo para notas de crédito en parametros-inventario")
                            Return
                        End If
                        If LtFAC_CVE_DOC.Text.Trim.Length = 0 Then
                            If MsgBox("No ha enlazado ninguna factura desea continuar?", vbYesNo) = vbNo Then
                                Return
                            End If
                        End If
                        Try
                            Dim z As Integer = 0

                            For k = 0 To aDATA.GetLength(0) - 1
                                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                                        z += 1
                                    End If
                                End If
                            Next
                            If z = 0 Then
                                If MsgBox("No ha seleccionado el documento relacionado, desea continuar?", vbYesNo) = vbNo Then
                                    Return
                                End If
                            End If
                        Catch ex As Exception
                            BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                    If MsgBox("Realmente desea grabar la devolución?", vbYesNo) = vbNo Then
                        Return
                    End If
            End Select
        Catch ex As Exception
            BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try

        CADENA_FECHELAB = "GETDATE"

        If Not DOC_NEW And TIPO_VENTA_LOCAL = "C" Then
            FECHA_DOC = FSQL(F1.Value)
            FECHA_ENT = FECHA_DOC
            FECHA_VEN = FECHA_DOC
            Try
                Dim D1 As Date
                FECHAELAB = F1.Tag.ToString
                D1 = FECHAELAB

                FECHAELAB = D1.ToString("yyyyMMdd HH:mm:ss")
                CADENA_FECHELAB = "'" & FECHAELAB & "'"
            Catch ex As Exception
                FECHAELAB = ""
                BITACORATPV("395. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            FECHA_DOC = FSQL(F1.Value)
            FECHA_ENT = FECHA_DOC
            FECHA_VEN = FECHA_DOC
            Try
                Dim D1 As Date
                FECHAELAB = F1.Tag.ToString
                If IsDate(FECHAELAB) Then
                    D1 = FECHAELAB
                Else
                    D1 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                End If
                FECHAELAB = ""
                FECHAELAB = D1.ToString("yyyyMMdd HH:mm:ss")
                CADENA_FECHELAB = "'" & FECHAELAB & "'"
            Catch ex As Exception
                FECHAELAB = ""
                BITACORATPV("398. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        If FECHAELAB.Trim.Length = 0 Then
            CADENA_FECHELAB = "GETDATE()"
        End If

        If Not Valida_Conexion() Then
            Return
        End If

        cmdF.Connection = cnSAE
        cmd.Connection = cnSAE
        cmdP.Connection = cnSAE

        Try
            If MULTIALMACEN = 0 Then
                NUM_ALMA = 1
            Else
                If CboAlmacen.SelectedIndex = -1 Then
                    NUM_ALMA = 1
                Else
                    NUM_ALMA = CboAlmacen.Items(CboAlmacen.SelectedIndex).ToString.Substring(0, 2)
                End If
            End If
        Catch ex As Exception
            BITACORATPV("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        TIP_DOC = TIPO_VENTA

        CVE_DOC = "" : CVE_CPTO = 51
        UNI_MED = "" : TIP_CAM = 1 : FACTOR_CON = 1 : REG_SERIE = 0 : E_LTPD = 0 : MOV_ENLAZADO = 0
        DAT_MOSTR = 0

        CLIENTE = TCLIENTE.Text
        CVE_VEND = TCVE_VEND.Text

        If Not DOC_NEW And (TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "C" Or TIPO_VENTA_LOCAL = "R") Then

            CVE_DOC = LtCVE_DOC.Text
            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "DELETE FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORATPV("410. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "DELETE FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORATPV("420. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                SIGUE = True
                FOLIO_ASIGNADO = False
                ' Toma el siguiente folio tabla FOLIOSF
                FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, LETRA_VENTA)

                Do While SIGUE
                    If LETRA_VENTA.Trim.Length = 0 Or LETRA_VENTA = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                    Else
                        If TIPO_VENTA_LOCAL = "F" Then
                            CVE_DOC = LETRA_VENTA & Format(FOLIO_VENTA, "0000000000")
                        Else
                            CVE_DOC = LETRA_VENTA & FOLIO_VENTA
                        End If
                    End If

                    If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                        FOLIO_VENTA += 1
                        FOLIO_ASIGNADO = True
                    Else
                        SIGUE = False
                    End If
                Loop
            Catch ex As Exception
                BITACORATPV("425. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
                Return
            End Try
        End If

        Try
            If tEntregarEn.Tag.ToString.Trim.Length > 0 And DOC_NEW Then

                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM CLIE" & Empresa & " WHERE CLAVE = '" & tEntregarEn.Tag & "'"
                    cmd2.CommandText = SQL
                    Using dr As SqlDataReader = cmd2.ExecuteReader
                        If dr.Read Then
                            SQL = "INSERT INTO INFENVIO" & Empresa & " (CVE_INFO, CVE_CONS, NOMBRE, CALLE, NUMINT, NUMEXT, CRUZAMIENTOS, CRUZAMIENTOS2, POB,
                                CURP, REFERDIR, CVE_ZONA, STRNOGUIA, STRMODOENV, FECHA_ENV, NOMBRE_RECEP, NO_RECEP, COLONIA, CODIGO, ESTADO, PAIS, MUNICIPIO)
                                OUTPUT Inserted.CVE_INFO VALUES((Select ISNULL(MAX(CVE_INFO),0) + 1 FROM INFENVIO" & Empresa & "), @CVE_CONS, @NOMBRE, @CALLE,
                                @NUMINT, @NUMEXT, @CRUZAMIENTOS, @CRUZAMIENTOS2, @POB, @CURP, @REFERDIR, @CVE_ZONA, @STRNOGUIA, @STRMODOENV, GETDATE(),
                                @NOMBRE_RECEP, @NO_RECEP, @COLONIA, @CODIGO, @ESTADO, @PAIS, @MUNICIPIO)"
                            cmd.CommandText = SQL
                            Try 'NUMINT_ENVIO, NUMEXT_ENVIO, REFERENCIA_ENVIO, LAT_ENVIO
                                cmd.Parameters.Add("@CVE_CONS", SqlDbType.VarChar).Value = tEntregarEn.Tag
                                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = dr("NOMBRE")
                                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = dr("CALLE")
                                cmd.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = dr("NUMINT")
                                cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = dr("NUMEXT")
                                cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = dr("CRUZAMIENTOS")
                                cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = dr("CRUZAMIENTOS2")
                                cmd.Parameters.Add("@POB", SqlDbType.VarChar).Value = dr("LOCALIDAD")
                                cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = dr("CALLE_ENVIO")
                                cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = dr("REFERDIR")
                                cmd.Parameters.Add("@CVE_ZONA", SqlDbType.VarChar).Value = dr("CVE_ZONA")
                                cmd.Parameters.Add("@STRNOGUIA", SqlDbType.VarChar).Value = dr("NUMINT_ENVIO")
                                cmd.Parameters.Add("@STRMODOENV", SqlDbType.VarChar).Value = dr("NUMEXT_ENVIO")
                                cmd.Parameters.Add("@NOMBRE_RECEP", SqlDbType.VarChar).Value = dr("REFERENCIA_ENVIO")
                                cmd.Parameters.Add("@NO_RECEP", SqlDbType.VarChar).Value = dr("LAT_ENVIO")
                                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = dr("COLONIA")
                                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = dr("CODIGO")
                                cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = dr("ESTADO")
                                cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = dr("PAIS")
                                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = dr("MUNICIPIO")
                                returnValue = cmd.ExecuteScalar().ToString
                                If returnValue IsNot Nothing Then
                                    DAT_MOSTR = Val(returnValue)
                                    If DAT_MOSTR > 0 Then

                                        SQL = "UPDATE TBLCONTROL" & Empresa & " Set ULT_CVE = (Select ISNULL(MAX(CVE_INFO),0) FROM INFENVIO" & Empresa & ") WHERE ID_TABLA = 70"
                                        cmd.CommandText = SQL
                                        returnValue = cmd.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                BITACORATPV("428. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("428. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            BITACORATPV("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try



        '███████████████████████████████████████████████████████████████████████████████████████

        '                                 INICIA LA GRABACION DE LAS CABEZAS

        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS


        Try

            IMP_TOT1 = 0 : IMP_TOT2 = 0 : IMP_TOT3 = 0 : IMP_TOT4 = 0 : DES_TOT = 0 : DES_FIN = 0 : COM_TOT = 0
            CONDICION = tCONDICION.Text : CVE_OBS = 0 : NUM_ALMA = 1 : ACT_CXC = "S" : ACT_COI = "A" : ENLAZADO = "O"
            TIPCAMB = 1 : NUM_PAGOS = 1
            RFC = "" : CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
            FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
            DAT_ENVIO = 0 : COM_TOT_PORC = 0 : IMPORTE = 0
            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC = "V" : TIP_DOC_ANT = "" : DOC_ANT = ""
            STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N" : SIGNO = -1 : TIP_CAM = 1 : E_LTPD = 0 : UUID = "" : SUBTOTAL = 0

            If TIPO_VENTA_LOCAL = "" Then
                NUM_MONED = 1
                If TIPO_VENTA_LOCAL = "V" Then
                    METODODEPAGO = "PPD" : USO_CFDI = "G01" : FORMADEPAGOSAT = "01"
                Else
                    METODODEPAGO = "" : USO_CFDI = "" : FORMADEPAGOSAT = ""
                End If
            End If

            TIP_DOC_E = "O"
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            DESC2 = 0
            DESC3 = 0
            FOLIO = FOLIO_VENTA
            SERIE = LETRA_VENTA

            For k = 1 To Fg.Rows.Count - 1

                For w = 1 To 5
                    If Valida_Conexion() Then
                        Exit For
                    End If
                Next

                Try
                    CANT = Fg(k, 2)
                    ALMACEN = Fg(k, 3)
                    CVE_ART = Fg(k, 4)
                Catch ex As Exception
                    CANT = 0 : ALMACEN = 1 : CVE_ART = ""
                End Try

                If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                    EXIST = 0
                    Try
                        If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                            If CREDITO = "CREDITO" Then
                                CONTADO = "N"
                                METODODEPAGO = "PPD"
                            Else
                                CONTADO = "S"
                                METODODEPAGO = "PPD"
                            End If
                        Else
                            CONTADO = "N"
                        End If
                        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        TIP_DOC = TIPO_VENTA
                    Catch ex As Exception
                        BITACORATPV("620. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS UCOSTO, ISNULL(I.COSTO_PROM,0) AS CPROM, ISNULL(P.IMPUESTO1,0) AS IMPU1,
                            ISNULL(P.IMPUESTO2,0) AS IMPU2, ISNULL(P.IMPUESTO3,0) AS IMPU3, ISNULL(P.IMPUESTO4,0) AS IMPU4, ISNULL(P.IMP1APLICA,0) AS IMP1APLA,
                            ISNULL(P.IMP2APLICA,0) AS IMP2APLA, ISNULL(P.IMP3APLICA,0) AS IMP3APLA, ISNULL(P.IMP4APLICA,0) AS IMP4APLA,
                            ISNULL(TIPO_ELE,'') AS TIP_ELE
                            FROM INVE" & Empresa & " I
                            LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                            WHERE CVE_ART = '" & CVE_ART & "'"

                        Using cmdF2 As SqlCommand = cnSAE.CreateCommand
                            cmdF2.CommandText = SQL
                            Using drF2 As SqlDataReader = cmdF2.ExecuteReader
                                If drF2.Read Then
                                    COST = drF2("UCOSTO").ToString
                                    COST = Math.Round(COST, 2)
                                    COSTO_PROM = drF2("CPROM").ToString
                                    IMPU1 = drF2("IMPU1")
                                    IMPU2 = drF2("IMPU2")
                                    IMPU3 = drF2("IMPU3")
                                    IMPU4 = drF2("IMPU4")
                                    IMP1APLA = drF2("IMP1APLA")
                                    IMP2APLA = drF2("IMP2APLA")
                                    IMP3APLA = drF2("IMP3APLA")
                                    IMP4APLA = drF2("IMP4APLA")
                                    CVE_ESQ = drF2("CVE_ESQIMPU")
                                    UNI_MED = drF2("UNI_MED")
                                    TIPO_PROD = drF2("TIP_ELE") '= "K"
                                End If
                            End Using
                        End Using
                    Catch ex As Exception
                        BITACORATPV("640. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("640. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    DESC1 = Fg(k, 8)
                    PRECIO = Fg(k, 13)
                    PREC = PRECIO
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    SUBTOTAL += (CANT * PREC)
                    ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                    'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      
                    DES_TOT += (CANT * PREC * DESC1 / 100)
                    DES_TOT += (DES_TOT * DESC2 / 100)

                    cImpu1 = ImporteConDes * IMPU1 / 100
                    cImpu2 = (ImporteConDes + cImpu1) * IMPU2 / 100
                    cImpu3 = (ImporteConDes + cImpu1 + cImpu2) * IMPU3 / 100
                    cImpu4 = (ImporteConDes + cImpu1 + cImpu2 + cImpu3) * IMPU4 / 100
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    TOTIMP1 = cImpu1
                    TOTIMP2 = cImpu2
                    TOTIMP3 = cImpu3
                    TOTIMP4 = cImpu4
                    IMP_TOT1 += TOTIMP1
                    IMP_TOT2 += TOTIMP2
                    IMP_TOT3 += TOTIMP3
                    IMP_TOT4 += TOTIMP4
                    IMPORTE += ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4
                End If
            Next
            CAN_TOT = SUBTOTAL
            DES_TOT_PORC = DESC1
            COM_TOT = 0

            PRIMERPAGO = 0
            DES_TOT = DES_TOT
            Try
                If DOC_ENLAZADO = "S" Then
                    If TIPO_VENTA_LOCAL = "D" Then
                        TIP_DOC_ANT = "F"
                        DOC_ANT = aDOCS(0)
                    Else
                        TIP_DOC_ANT = "P"
                        DOC_ANT = aDOCS(0)
                    End If
                End If
            Catch ex As Exception
                BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            Try 'OBSERVACIONES
                If LtNombre.Tag.ToString.Trim.Length > 0 Then
                    CVE_OBS = GRABA_OBSER(LtNombre.Tag)
                Else
                    CVE_OBS = 0
                End If
            Catch ex As Exception
                BITACORATPV("660. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("666. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
            CVE_PEDI = TCVE_UNI.Text
            CONDICION = TCVE_TIPO.Text
            PRIMERPAGO = IMPORTE
            RFC = LtRFC.Text
            CVE_OBS = 0
            Try
                If Obser.Trim.Length > 0 Then
                    If TIPO_OTI = 0 Then
                        Try
                            INSERT_UPDATE_OBS_FAC_CLIB(CVE_DOC, TIPO_VENTA_LOCAL, Obser)
                        Catch ex As Exception
                            BITACORATPV("670. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        CVE_OBS = Val(LtRFC.Tag)
                        CVE_OBS = INSERT_UPDATE_OBS_FAC(CVE_OBS, Obser)
                    End If
                End If
            Catch ex As Exception
                BITACORATPV("680. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS


                Dim RegDuplicado As Boolean = False
                Dim SQLF As String

                SQLF = SQL

                For k = 1 To 5

                    If DOC_NEW Then
                        If TIPO_VENTA_LOCAL = "F" Then
                            SQL = "INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC, CVE_TRACTOR, CVE_OPER, CMT) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            IMP_TOT1 & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                            TIPCAMB & "','" & IMP_TOT3 & "','" & IMP_TOT4 & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                            FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                            CVE_DOC & "','" & CAN_TOT & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" &
                            DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "'," & CADENA_FECHELAB & ",'" &
                            CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" &
                            DES_TOT_PORC & "','" & IMPORTE & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" &
                            TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',
                            NEWID(), GETDATE(), '" & TCVE_UNI.Text & "', '" & TCVE_OPER.Text & "', '" & txCMT.Text & "')"
                        Else
                            SQL = "INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            IMP_TOT1 & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                            TIPCAMB & "','" & IMP_TOT3 & "','" & IMP_TOT4 & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                            FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                            CVE_DOC & "','" & CAN_TOT & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" &
                            DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "'," & CADENA_FECHELAB & ",'" &
                            CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" &
                            DES_TOT_PORC & "','" & IMPORTE & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" &
                            TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',
                            NEWID(), GETDATE())"
                        End If
                    Else
                        If TIPO_VENTA_LOCAL = "F" Then
                            SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "')
                            INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC, CVE_TRACTOR, CVE_OPER, CMT) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            IMP_TOT1 & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                            TIPCAMB & "','" & IMP_TOT3 & "','" & IMP_TOT4 & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                            FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                            CVE_DOC & "','" & CAN_TOT & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" &
                            DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "'," & CADENA_FECHELAB & ",'" &
                            CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" &
                            DES_TOT_PORC & "','" & IMPORTE & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" &
                            TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',
                            NEWID(), GETDATE(), '" & TCVE_UNI.Text & "', '" & TCVE_OPER.Text & "', '" & txCMT.Text & "'))"
                        Else
                            SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "')
                            INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            IMP_TOT1 & "','" & IMP_TOT2 & "','" & DES_FIN & "','" & COM_TOT & "','" & ACT_COI & "','" & NUM_MONED & "','" &
                            TIPCAMB & "','" & IMP_TOT3 & "','" & IMP_TOT4 & "','" & PRIMERPAGO & "','" & RFC & "','" & AUTORIZA & "','" &
                            FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" & ESCFD & "','" & NUM_ALMA & "','" & ACT_CXC & "','" & TIP_DOC & "','" &
                            CVE_DOC & "','" & CAN_TOT & "','" & CVE_VEND & "','" & DES_TOT & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" &
                            DAT_ENVIO & "','" & CONTADO & "','" & DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "'," & CADENA_FECHELAB & ",'" &
                            CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" & TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" &
                            DES_TOT_PORC & "','" & IMPORTE & "','" & COM_TOT_PORC & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" &
                            TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',
                            NEWID(), GETDATE())"
                        End If

                    End If

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
                    Catch SQLex As SqlException
                        Dim SSS As SqlError, Sqlcadena As String = ""
                        For Each SSS In SQLex.Errors
                            Sqlcadena += SSS.Message & vbNewLine
                        Next
                        BITACORATPV("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                    Catch ex As Exception
                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        SIGUE = True
                        FOLIO_ASIGNADO = False
                        ' Toma el siguiente folio tabla FOLIOSF
                        FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, LETRA_VENTA)

                        Do While SIGUE
                            If LETRA_VENTA.Trim.Length = 0 Or LETRA_VENTA = "STAND." Then
                                CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                            Else
                                CVE_DOC = LETRA_VENTA & FOLIO_VENTA
                            End If

                            If EXISTE_VENTA(TIPO_VENTA_LOCAL, CVE_DOC) Then
                                FOLIO_VENTA += 1
                                FOLIO_ASIGNADO = True
                            Else
                                SIGUE = False
                            End If
                        Loop
                    Catch ex As Exception
                        BITACORATPV("693. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("693. " & ex.Message & vbNewLine & ex.StackTrace)
                        Return
                    End Try
                Next

                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                'CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   
                If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                    'CUEN M
                    CUEN_M(CVE_DOC, CLIENTE, IMPORTE, 1, CVE_VEND, CVE_BITA)

                    If CREDITO <> "CREDITO" Then
                        'RUTIANA CONTADO  
                        Dim MONTO As Decimal, NO_CPTO As Integer
                        Try
                            For k = 0 To aTPV.GetUpperBound(0)
                                If IsNumeric(aTPV(k, 0)) Then
                                    NO_CPTO = aTPV(k, 0)
                                Else
                                    NO_CPTO = 0
                                End If
                                If IsNumeric(aTPV(k, 1)) Then
                                    MONTO = aTPV(k, 1)
                                Else
                                    MONTO = 0
                                End If
                                If MONTO > 0 And NO_CPTO > 0 Then
                                    CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, MONTO, 1, NO_CPTO, CVE_VEND)
                                End If
                            Next
                        Catch ex As Exception
                            BITACORATPV("695. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("695. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", 
                                FCH_ULTCOM = '" & FECHA_DOC & "'
                                WHERE CLAVE = '" & CLIENTE & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("700. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & IMPORTE & ", " &
                              "ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", FCH_ULTCOM = '" & FECHA_DOC & "' WHERE CLAVE = '" & CLIENTE & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("705. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("705. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    If TIPO_VENTA_LOCAL = "R" And DOC_NEW Then
                        Try
                            SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", 
                                FCH_ULTCOM = '" & FECHA_DOC & "'
                               WHERE CLAVE = '" & CLIENTE & "'"
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("710. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("710. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                If MODO_EDIT <> "edit" Then
                    Try
                        If LETRA_VENTA = "" Or LETRA_VENTA = "STAND." Then
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = 'STAND.'"
                        Else
                            SQL = "UPDATE FOLIOSF" & Empresa & " SET ULT_DOC = " & FOLIO_VENTA & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & LETRA_VENTA & "'"
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
                End If
            Catch ex As Exception
                BITACORATPV("720. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("730. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        'FIN CABEZAS FACT           CABEZAS FACT          CABEZAS FACT          CABEZAS FACT 

        '████████████████████████████████████████████████████████████████████████████████████



        'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
        NUM_PAR = 1 : CVE_ART = "" : CVE_VEND = "" : COSTEADO = "S" : DESDE_INVE = "N"
        SUBTOTAL = 0 : DES_TOT = 0
        TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : MAN_IEPS = "" : APL_MAN_IEPS = ""

        CVE_DOC_ENLAZADO = ""


        For k = 1 To Fg.Rows.Count - 1

            For w = 1 To 5
                If Valida_Conexion() Then
                    Exit For
                End If
            Next

            Try
                CANT_ORIGINAL = Fg(k, 1)
                CANT = Fg(k, 2)
                CANT_SURTIDA = CANT
                ALMACEN = Fg(k, 3)
                If ALMACEN = 0 Then ALMACEN = 1
                CVE_ART = Fg(k, 4)

                Try 'NUM_PAR
                    If IsNothing(Fg(k, 18)) Then
                        NUM_PAR_ENLAZADO = 1
                    Else
                        If IsNumeric(Fg(k, 18)) Then
                            NUM_PAR_ENLAZADO = Fg(k, 18)
                        End If
                    End If
                    'CVE_DOC ENLAZADO
                    If IsNothing(Fg(k, 19)) Then
                        CVE_DOC_ENLAZADO = ""
                    Else
                        If IsNumeric(Fg(k, 19)) Then
                            CVE_DOC_ENLAZADO = Fg(k, 19)
                        End If
                    End If
                    'tip_doc_enlazado	
                    If IsNothing(Fg(k, 20)) Then
                        ENLACE_TIP_DOC = ""
                    Else
                        If IsNumeric(Fg(k, 20)) Then
                            ENLACE_TIP_DOC = Fg(k, 20)
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("735. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Catch ex As Exception
                BITACORATPV("740. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
            If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                Try
                    SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS ULTCOSTO, ISNULL(I.COSTO_PROM,0) AS COSTOPROM, " &
                        "COALESCE(P.IMPUESTO1,0) AS IMPU1, COALESCE(P.IMPUESTO2,0) AS IMPU2, COALESCE(P.IMPUESTO3,0) AS IMPU3, " &
                        "COALESCE(P.IMPUESTO4,0) AS IMPU4, COALESCE(P.IMP1APLICA,0) AS IMP1APLA, COALESCE(P.IMP2APLICA,0) AS IMP2APLA, " &
                        "COALESCE(P.IMP3APLICA,0) AS IMP3APLA, COALESCE(P.IMP4APLICA,0) AS IMP4APLA, ISNULL(TIPO_ELE,'') AS TIP_ELE " &
                        "FROM INVE" & Empresa & " I " &
                        "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                        "WHERE CVE_ART = '" & CVE_ART & "'"

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                COST = dr2("ULTCOSTO")
                                COST = Math.Round(COST, 2)
                                COSTO_PROM = dr2("COSTOPROM").ToString
                                IMPU1 = dr2("IMPU1")
                                IMPU2 = dr2("IMPU2")
                                IMPU3 = dr2("IMPU3")
                                IMPU4 = dr2("IMPU4")
                                IMP1APLA = dr2("IMP1APLA")
                                IMP2APLA = dr2("IMP2APLA")
                                IMP3APLA = dr2("IMP3APLA")
                                IMP4APLA = dr2("IMP4APLA")
                                CVE_ESQ = dr2("CVE_ESQIMPU")
                                UNI_MED = dr2("UNI_MED")
                                TIPO_PROD2 = dr2("TIP_ELE")
                                Select Case dr2("TIP_ELE")
                                    Case "K"
                                        TIPO_PROD = "K"
                                        TIPO_ELEM = "N"
                                    Case "S"
                                        TIPO_PROD = "S"
                                        TIPO_ELEM = "S"
                                    Case Else
                                        TIPO_PROD = "P"
                                        TIPO_ELEM = "N"
                                End Select
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    DESC1 = Fg(k, 8)
                    PRECIO = Fg(k, 13)
                    PREC = PRECIO

                    DESC2 = 0 : DESC3 = 0
                    SUBTOTAL += (CANT * PREC)
                    ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)
                    'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                    DES_TOT += (CANT * PREC * DESC1 / 100)
                    DES_TOT += (DES_TOT * DESC2 / 100)
                    cImpu1 = ImporteConDes * IMPU1 / 100
                    cImpu2 = (ImporteConDes + cImpu1) * IMPU2 / 100
                    cImpu3 = (ImporteConDes + cImpu1 + cImpu2) * IMPU3 / 100
                    cImpu4 = (ImporteConDes + cImpu1 + cImpu2 + cImpu3) * IMPU4 / 100
                    TOTIMP1 = cImpu1
                    TOTIMP2 = cImpu2
                    TOTIMP3 = cImpu3
                    TOTIMP4 = cImpu4

                    TOT_PARTIDA = CANT * PREC
                    IMPORTE += ImporteConDes + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4

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
                '==========================================================================================================
                'PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      PARTIDAS      
                '==========================================================================================================
                'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER     
                CVE_OBS = 0
                Try
                    If Fg(k, 22).ToString.Trim.Length > 0 Then
                        'CVE_OBS = Val(Fg(k, 21))
                        'CVE_OBS = INSERT_UPDATE_OBS_FAC(CVE_OBS, Fg(k, 22))
                        If TIPO_OTI = 0 Then
                            INSERT_UPDATE_OBS_FAC_CLIB_PAR(CVE_DOC, TIPO_VENTA_LOCAL, NUM_PAR, Fg(k, 22))
                        Else
                            CVE_OBS = INSERT_UPDATE_OBS_FAC(Val(Fg(k, 21)), Fg(k, 22))
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("765. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    SQL = "IF NOT EXISTS(SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE
                        CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR & ")
                        INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1,
                        IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2,
                        DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD,
                        TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC,
                        MTO_CUOTA, DESCR_ART, CVE_ESQ, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" & CVE_ART & "','" & CANT & "','" &
                        CANT & "','" & PREC & "','" & COST & "','" & IMPU1 & "','" & IMPU2 & "','" & IMPU3 & "','" & IMPU4 & "','" &
                        IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" & TOTIMP1 & "','" & TOTIMP2 & "','" &
                        TOTIMP3 & "','" & TOTIMP4 & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" & APAR & "','" &
                        ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" & TIPO_PROD & "','" &
                        CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','0','" & TOT_PARTIDA & "','S',GETDATE(),'" &
                        MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" &
                        CVE_DOC_ENLAZADO & "','" & CVE_ESQ & "',NEWID())"
                    Try
                        cmdF.Connection = cnSAE
                        cmdF.CommandText = SQL
                        returnValue = cmdF.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                            NUM_MOV = returnValue
                        End If
                    Catch ex As Exception
                        BITACORATPV("770. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("770. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        GRABAR_CAMPLIB_PAR(CVE_DOC, NUM_PAR)
                    Catch ex As Exception
                        BITACORATPV("780. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    If TIPO_PROD = "K" And DOC_NEW Then
                        NUM_PAR += 1
                        NUM_PAR_KIT = NUM_PAR
                        TIPO_PROD = "P"
                        TIPO_ELEM = "K"
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT ISNULL(CVE_PROD,'') AS CVEPROD, ISNULL(PORCEN,0) AS PORCEN1, ISNULL(CANTIDAD,0) AS CANT, 
                                ISNULL(ULT_COSTO,0) AS ULTCOSTO, ISNULL(IMPUESTO1,0) AS IMPU1, ISNULL(IMPUESTO4,0) AS IMPU4, ISNULL(IMP1APLICA,0) AS IMP1APLA,
                                UNI_MED, ISNULL(IMP2APLICA,0) AS IMP2APLA, ISNULL(IMP3APLICA,0) AS IMP3APLA, ISNULL(IMP4APLICA,0) AS IMP4APLA
                                FROM KITS" & Empresa & " K
                                INNER JOIN INVE" & Empresa & " I  ON I.CVE_ART = K.CVE_PROD
                                INNER JOIN IMPU" & Empresa & " P  ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                                WHERE K.CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    CANT_KIT = dr("CANT") * CANT
                                    PRECIO_KIT = PREC * dr("PORCEN1") / dr("CANT")
                                    IMPU1 = dr("IMPU1")
                                    IMPU2 = 0
                                    IMPU3 = 0
                                    IMPU4 = dr("IMPU4")
                                    IMP1APLA = dr("IMP1APLA")
                                    IMP2APLA = dr("IMP2APLA")
                                    IMP3APLA = dr("IMP3APLA")
                                    IMP4APLA = dr("IMP4APLA")
                                    CVE_PROD = dr("CVEPROD")

                                    ImporteConDes = (CANT_KIT * PRECIO_KIT) - (CANT_KIT * PRECIO_KIT * DESC1 / 100)

                                    cIEPS = ImporteConDes * IMPU1 / 100
                                    If dr("IMP4APLA") = 1 Then
                                        cIMPU = (ImporteConDes + cIEPS) * IMPU4 / 100
                                    Else
                                        cIMPU = (ImporteConDes * IMPU4) / 100
                                    End If
                                    UNI_VENTA = "" & dr("UNI_MED")

                                    TOTIMP1 = cIEPS
                                    TOTIMP2 = 0
                                    TOTIMP3 = 0
                                    TOTIMP4 = cIMPU
                                    '**************************************************************
                                    'INICIA GRABADO DE PARTIDAS         KITS         KITS      
                                    '**************************************************************
                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa &
                                         " WHERE CVE_DOC = '" & CVE_DOC & "' AND NUM_PAR = " & NUM_PAR_KIT & ") " &
                                         "INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, " &
                                         "IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, " &
                                         "DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, " &
                                         "E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, VERSION_SINC, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, " &
                                         "MTO_PORC, MTO_CUOTA, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR_KIT & "','" & CVE_PROD & "','" &
                                         CANT_KIT & "','" & CANT_KIT & "','" & PRECIO_KIT & "','" & dr("ULTCOSTO") & "','" & IMPU1 & "','" & IMPU2 & "','" &
                                         IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" & TOTIMP1 & "','" &
                                         TOTIMP2 & "','" & TOTIMP3 & "','" & TOTIMP4 & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" &
                                         APAR & "','" & ACT_INV & "','" & ALMACEN & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','P','" &
                                         CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','0','" & ImporteConDes & "','S',GETDATE(),'" &
                                         MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "',NEWID())"
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                        NUM_MOV_KIT = returnValue
                                    End Using
                                    NUM_PAR_KIT += 1

                                    If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Then
                                        'AFECTANDO INVENTARIO MINVE Y INVE

                                        '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT_KIT &
                                                    ", FCH_ULTVTA = '" & FECHA_DOC & "' WHERE CVE_ART = '" & CVE_PROD & "'"
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("790. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("790. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try

                                        Try
                                            If MULTIALMACEN = 1 Then
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT_KIT &
                                                    " WHERE CVE_ART = '" & CVE_PROD & "' AND CVE_ALM = " & ALMACEN
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            End If
                                        Catch ex As Exception
                                            BITACORATPV("800. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("800. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        'MINVE KITES
                                        SIGNO = -1
                                        COSTO_PROM_INI = COST
                                        COSTO_PROM_FIN = COST
                                        COSTO_PROM_GRAL = COST

                                        SQL = "IF NOT EXISTS(SELECT REFER FROM MINVE" & Empresa & " WHERE REFER = '" & CVE_DOC & "' AND CVE_ART = '" &
                                            CVE_PROD & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & ALMACEN & ")
                                            INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL)
                                            VALUES ('" & CVE_PROD & "','" & ALMACEN & "','" & NUM_MOV_KIT & "','" & CVE_CPTO & "','" & FECHA_DOC & "','" &
                                            TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" & CANT_KIT & "','" &
                                            CANT_KIT & "','" & PRECIO_KIT & "','" & COST & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                            "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "')," 'EXIST_G
                                        If MULTIALMACEN = 1 Then
                                            SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "' AND 
                                                CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                                        Else
                                            SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "'),'"  'EXISTENCIA
                                        End If
                                        SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " 
                                            WHERE ID_TABLA = 32),'" &
                                             SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" &
                                             MOV_ENLAZADO & "','" & COSTO_PROM_GRAL & "')"
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                cmd3.CommandText = SQL
                                                returnValue = cmd3.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                    End If
                                                End If
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("810. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        'FIN MINVE KITS
                                    End If
                                End While
                            End Using
                        End Using
                        NUM_PAR = NUM_PAR_KIT
                    End If

                    If DOC_ENLAZADO = "S" And TIPO_VENTA_LOCAL = "R" Then
                        SIGUE = False
                    Else
                        SIGUE = True
                    End If

                    If (TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "R") And TIPO_PROD2 <> "K" And DOC_NEW And SIGUE Then
                        Try
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                SQL = "UPDATE INVE" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & ", FCH_ULTVTA = '" & FECHA_DOC & "'" &
                                    " WHERE CVE_ART = '" & CVE_ART & "'"
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("820. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("820. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If MULTIALMACEN = 1 Then
                            Try
                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                    SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN
                                    cmd3.CommandText = SQL
                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                BITACORATPV("830. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("830. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If

                        SIGNO = -1
                        COSTO_PROM_INI = COST
                        COSTO_PROM_FIN = COST
                        COSTO_PROM_GRAL = COST

                        'PARTIDAS REALES   NO NO KIT
                        SQL = "IF NOT EXISTS(SELECT REFER FROM MINVE" & Empresa & " WHERE
                            REFER = '" & CVE_DOC & "' AND CVE_ART = '" & CVE_ART & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & ALMACEN & ")
                            INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL)
                            VALUES('" & CVE_ART & "','" & ALMACEN & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                            CVE_CPTO & "','" & FECHA_DOC & "','" & TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                            CANT & "','" & CANT & "','" & PREC & "','" & COST & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                        If MULTIALMACEN = 1 Then
                            SQL = SQL & "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & ALMACEN & "),0),'"   'EXISTENCIA
                        Else
                            SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                        End If
                        SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" &
                                MOV_ENLAZADO & "','" & COSTO_PROM_GRAL & "')"
                        Try
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                returnValue = cmd3.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("840. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("840. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    Try
                        '===============================================================================================
                        'DOC ENLAZADO
                        If DOC_ENLAZADO = "S" And DOC_NEW Then
                            Try
                                CVE_DOC_ENLAZADO = Fg(k, 19)
                                NUM_PAR_ENLAZADO = Fg(k, 18)
                                ENLACE_TIP_DOC = Fg(k, 20)
                            Catch ex As Exception
                            End Try

                            If TIPO_PROD = "K" Then
                                NUM_PAR_KIT = NUM_PAR + 1
                                Try
                                    SQL = "SELECT ISNULL(CVE_PROD,'') AS CVEPROD, ISNULL(PORCEN,0) AS PORCEN1, " &
                                        "ISNULL(CANTIDAD,0) AS CANT, ISNULL(ULT_COSTO,0) AS ULTCOSTO " &
                                        "FROM KITS" & Empresa & " K " &
                                        "INNER JOIN INVE" & Empresa & " I  ON I.CVE_ART = K.CVE_PROD " &
                                        "WHERE K.CVE_ART = '" & CVE_ART & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        Using dr As SqlDataReader = cmd2.ExecuteReader
                                            While dr.Read
                                                Try
                                                    CANT_KIT = dr("CANT")
                                                    PRECIO_KIT = PREC * dr("PORCEN1")
                                                    CVE_PROD = dr("CVEPROD")
                                                    ANT_SIG = "S"
                                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM DOCTOSIGF" & Empresa & " 
                                                        WHERE TIP_DOC = '" & ENLACE_TIP_DOC & "' AND CVE_DOC = '" & CVE_DOC_ENLAZADO &
                                                        "' AND  ANT_SIG = '" & ANT_SIG & "' AND TIP_DOC_E = '" & TIP_DOC & "' AND CVE_DOC_E = '" & CVE_DOC &
                                                        "' AND PARTIDA = " & NUM_PAR_KIT & ") 
                                                        INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E,
                                                        CANT_E) VALUES('" & ENLACE_TIP_DOC & "','" & CVE_DOC_ENLAZADO & "','" & ANT_SIG & "','" &
                                                        TIP_DOC & "','" & CVE_DOC & "','" & NUM_PAR_KIT & "','" & NUM_PAR_KIT & "','" & CANT_KIT & "')"

                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQL
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then

                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    BITACORATPV("850. " & ex.Message & vbNewLine & ex.StackTrace)
                                                    MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try

                                                Try
                                                    ANT_SIG = "A"
                                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM DOCTOSIGF" & Empresa & " WHERE
                                                        TIP_DOC = '" & TIP_DOC & "' AND CVE_DOC = '" & CVE_DOC & "' AND  ANT_SIG = '" & ANT_SIG & "' AND
                                                        TIP_DOC_E = '" & ENLACE_TIP_DOC & "' AND CVE_DOC_E = '" & CVE_DOC_ENLAZADO & "' AND 
                                                        PARTIDA = " & NUM_PAR_KIT & ")
                                                        INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E,
                                                        CANT_E) VALUES('" & TIP_DOC & "','" & CVE_DOC & "','" & ANT_SIG & "','" & ENLACE_TIP_DOC & "','" &
                                                        CVE_DOC_ENLAZADO & "','" & NUM_PAR_KIT & "','" & NUM_PAR_KIT & "','" & CANT_KIT & "')"

                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQL
                                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                                        If returnValue IsNot Nothing Then
                                                            If returnValue = "1" Then

                                                            End If
                                                        End If
                                                    End Using
                                                Catch ex As Exception
                                                    BITACORATPV("855. " & ex.Message & vbNewLine & ex.StackTrace)
                                                    MsgBox("855. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try

                                                Try
                                                    If Len(Trim(CVE_DOC_ENLAZADO)) > 0 Then
                                                        SQL = "UPDATE PAR_FACT" & ENLACE_TIP_DOC & Empresa & " SET PXS = PXS - " & NUM_PAR_KIT & " WHERE
                                                            CVE_DOC = '" & CVE_DOC_ENLAZADO & "' AND CVE_ART = '" & CVE_ART & "' AND 
                                                            NUM_PAR = " & NUM_PAR_ENLAZADO
                                                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                            cmd3.CommandText = SQL
                                                            returnValue = cmd3.ExecuteNonQuery().ToString
                                                            If returnValue IsNot Nothing Then
                                                                If returnValue = "1" Then
                                                                End If
                                                            End If
                                                        End Using
                                                    End If
                                                Catch ex As Exception
                                                    BITACORATPV("858. " & ex.Message & vbNewLine & ex.StackTrace)
                                                    MsgBox("858. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End While
                                        End Using
                                    End Using
                                Catch ex As Exception
                                    BITACORATPV("860. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("860. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            Else
                                'ACTUALIZAR DOC SIG ENLAZADO NO KIT     NO KIT     NO KIT
                                ' NO KIT     NO KIT     NO KIT     NO KIT     NO KIT
                                Try
                                    ANT_SIG = "S"
                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM DOCTOSIGF" & Empresa & " WHERE
                                        TIP_DOC = '" & ENLACE_TIP_DOC & "' AND CVE_DOC = '" & CVE_DOC_ENLAZADO & "' AND  ANT_SIG = '" & ANT_SIG & "' AND
                                        TIP_DOC_E = '" & TIP_DOC & "' AND CVE_DOC_E = '" & CVE_DOC & "' AND PARTIDA = " & NUM_PAR & ")
                                        INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E, CANT_E) 
                                        VALUES('" & ENLACE_TIP_DOC & " ','" & CVE_DOC_ENLAZADO & "','" & ANT_SIG & "','" & TIP_DOC & "','" & CVE_DOC & "','" &
                                        NUM_PAR & "','" & NUM_PAR & "','" & CANT & "')"
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    BITACORATPV("865. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("865. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                Try
                                    ANT_SIG = "A"
                                    SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM DOCTOSIGF" & Empresa & " WHERE
                                        TIP_DOC = '" & TIP_DOC & "' AND CVE_DOC = '" & CVE_DOC & "' AND  ANT_SIG = '" & ANT_SIG & "' AND
                                        TIP_DOC_E = '" & ENLACE_TIP_DOC & "' AND CVE_DOC_E = '" & CVE_DOC_ENLAZADO & "' AND PARTIDA = " & NUM_PAR & ")
                                        INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E, CANT_E) 
                                        VALUES('" & TIP_DOC & "','" & CVE_DOC & "','" & ANT_SIG & "','" & ENLACE_TIP_DOC & "','" & CVE_DOC_ENLAZADO & "','" &
                                        NUM_PAR & "','" & NUM_PAR & "','" & CANT & "')"

                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    BITACORATPV("870. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("870. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                Try
                                    If Len(Trim(CVE_DOC_ENLAZADO)) > 0 Then
                                        SQL = "UPDATE PAR_FACT" & ENLACE_TIP_DOC & Empresa & " SET PXS = PXS - " & CANT & " WHERE " &
                                              "CVE_DOC = '" & CVE_DOC_ENLAZADO & "' AND CVE_ART = '" & CVE_ART & "' AND NUM_PAR = " & NUM_PAR_ENLAZADO
                                        Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                            cmd3.CommandText = SQL
                                            returnValue = cmd3.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then

                                                End If
                                            End If
                                        End Using
                                    End If
                                Catch ex As Exception
                                    BITACORATPV("875. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("875. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                        ' FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S    
                        ' FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S    
                    Catch ex As Exception
                        BITACORATPV("878. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("878. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                Catch ex As Exception
                    BITACORATPV("880. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("880. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      SQL SERVER      
                NUM_PAR += 1
            End If 'CANT >0
        Next

        Try
            If DOC_ENLAZADO = "S" And TIPO_VENTA_LOCAL = "R" Then
                SIGUE = False
            Else
                SIGUE = True
            End If

            If (TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "R") And DOC_NEW And SIGUE Then
                Try
                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT COALESCE(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) " &
                        "FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = SQL
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    BITACORATPV("890. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("890. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Try
                    SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT COALESCE(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = SQL
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    BITACORATPV("900. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            BITACORATPV("910. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("910. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        'FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  PARTIDAS     FIN  FIN  FIN  FIN  FIN  FIN  

        If MODO_EDIT <> "edit" Then
            If DOC_ENLAZADO = "S" Then
                'UPDATE FACT CON LOS DOCS SIGUIENTES
                ENLAZAR_CVE_DOC_UPDATE_DOC_SIG(CVE_DOC)
            End If
        End If

        Try
            'INICIO GRABADO DE CAMPOS LIBRES CABEZAS
            'aLIB1(k, 0) = Fg(k, 1) 'CAMPO
            'aLIB1(k, 1) = Fg(k, 3) 'DATO CAPTURADO
            GRABAR_CAMPLIB_DOC(CVE_DOC)

        Catch ex As Exception
            BITACORATPV("910. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Select Case TIPO_VENTA_LOCAL
            Case "F"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " Factura " & IIf(LtDocAnt.Text.Trim.Length > 0,
                                                                                                          "  Documento enlazado " & LtDocAnt.Text, ""))
            Case "R"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " Remisión" & IIf(LtDocAnt.Text.Trim.Length > 0,
                                                                                                          "  Documento enlazado " & LtDocAnt.Text, ""))
            Case "V"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " venta " & IIf(LtDocAnt.Text.Trim.Length > 0,
                                                                                                          "  Documento enlazado " & LtDocAnt.Text, ""))
            Case "C"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " cotizacion " & IIf(LtDocAnt.Text.Trim.Length > 0,
                                                                                                               "  Documento enlazado " & LtDocAnt.Text, ""))
            Case "P"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " pedido " & IIf(LtDocAnt.Text.Trim.Length > 0,
                                                                                                           "  Documento enlazado " & LtDocAnt.Text, ""))
            Case "D"
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " devolución " & IIf(LtDocAnt.Text.Trim.Length > 0,
                           "  Documento enlazado " & LtDocAnt.Text, ""))
        End Select

        If TIPO_VENTA_LOCAL = "D" And Ldocu.Tag = "Digital" Then

            If Var18 <> "Timbrada" Then
                GRABAR_CFDI_REL("D", CVE_DOC)
                TimbrarDigiBoxNC(CVE_DOC, DOC_ENLAZADO, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, IMPORTE)
            End If

            PassData1 = "DEVOLUCION CFDI"
            Var4 = CVE_DOC
            Var5 = LtCorreo.Text  'CORREO
            Var18 = ""
            Var16 = ""

            ' INICA PROCESO DE TIMBRAR 
            FrmTimbrarCdeP.LtNombre.Text = LtNombre.Text
            FrmTimbrarCdeP.LtRFC.Text = LtRFC.Text
            FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
            FrmTimbrarCdeP.LtRegimenReceptor.Text = REG_FISC
            FrmTimbrarCdeP.LtCP.Text = LtCP.Text

            FrmTimbrarCdeP.ShowDialog()

            LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)

            LtFAC_CVE_DOC.Text = ""
            LtUUID.Text = ""

            LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)
            LIMPIAR()

        Else
            If TIPO_VENTA_LOCAL = "F" And Ldocu.Tag = "Digital" Then
                PassData1 = "FACTURA"
                Var4 = CVE_DOC
                Var5 = LtCorreo.Text  'CORREO
                Var18 = ""
                Var16 = ""

                GRABAR_CFDI_REL("F", CVE_DOC)

                '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                ' INICA PROCESO DE TIMBRAR 
                FrmTimbrarCdeP.LtNombre.Text = LtNombre.Text
                FrmTimbrarCdeP.LtRFC.Text = LtRFC.Text
                FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
                FrmTimbrarCdeP.LtRegimenReceptor.Text = REG_FISC
                FrmTimbrarCdeP.LtCP.Text = LtCP.Text

                FrmTimbrarCdeP.ShowDialog()

                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)
                LIMPIAR()
                If Var18 = "SI" Then
                    FILE_PDF = Var16
                    If File.Exists(Var16) Then
                        FrmOPenPDFGrapecity.Show()
                    End If
                End If
            Else
                IMPRIMIR_VENTA(TIPO_VENTA_LOCAL, CVE_DOC)

                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)
                LIMPIAR()

            End If
        End If
    End Sub
    Sub GRABAR_CFDI_REL(FTIPO_DOC As String, FCVE_DOC As String)
        Dim z As Integer = 0
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                For k = 0 To aDATA.GetLength(0) - 1
                    If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                        If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                            Try
                                SQL = "INSERT INTO CFDI_REL" & Empresa & " (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC) 
                                    VALUES('" & aDATA(k, 1) & "','" & PassData5 & "','" & FCVE_DOC & "','" &
                                    aDATA(k, 0) & "','" & FTIPO_DOC & "')"
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using
                            Catch ex As Exception
                                BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CAMPLIB_DOC(FCVE_DOC As String)
        Dim cmd As New SqlCommand
        Dim CAMPO As String, DATO_CAPTURADO As String, CADENA_DATOS As String, CADENA_CAMPO As String
        Dim TIPO_CAMPO As String
        Try
            'aLIB1(k, 0) = Fg(k, 1) 'CAMPO
            'aLIB1(k, 1) = Fg(k, 3) 'DATO CAPTURADO
            cmd.Connection = cnSAE

            CADENA_CAMPO = "CLAVE_DOC"
            CADENA_DATOS = FCVE_DOC
            For k = 0 To aLIB1.GetLength(0) - 1

                If Not IsNothing(aLIB1(k, 0)) Then
                    CAMPO = aLIB1(k, 0)
                    If CAMPO <> "--" Then
                        If CAMPO.Trim.Length > 0 Then
                            DATO_CAPTURADO = aLIB1(k, 1)

                            TIPO_CAMPO = GET_DATATYPE("PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa, CAMPO)
                            Select Case TIPO_CAMPO.ToLower
                                Case "varchar", "char"

                                Case "int"
                                    If Not IsNumeric(DATO_CAPTURADO) Then
                                        DATO_CAPTURADO = "0"
                                    End If
                                Case "smallint"
                                    If Not IsNumeric(DATO_CAPTURADO) Then
                                        DATO_CAPTURADO = "0"
                                    End If
                                Case "float"
                                    If Not IsNumeric(DATO_CAPTURADO) Then
                                        DATO_CAPTURADO = "0"
                                    End If
                                Case "date", "datetime"

                            End Select
                            CADENA_CAMPO = CADENA_CAMPO & ", " & CAMPO
                            CADENA_DATOS = CADENA_DATOS & "','" & DATO_CAPTURADO
                        End If
                    End If

                End If
            Next

            If CADENA_CAMPO <> "CVE_DOC" Then
                Try
                    SQL = "SET ansi_warnings OFF
                     INSERT INTO FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " (" & CADENA_CAMPO & ") VALUES('" & CADENA_DATOS & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CAMPLIB_PAR(FCVE_DOC As String, FNUM_PAR As Integer)
        Dim cmd As New SqlCommand
        Dim CAMPO As String, DATO_CAPTURADO As String, CADENA_DATOS As String, CADENA_CAMPO As String
        Dim TIPO_CAMPO As String

        Try
            'aLIB1(k, 0) = Fg(k, 1) 'CAMPO
            'aLIB1(k, 1) = Fg(k, 3) 'DATO CAPTURADO
            cmd.Connection = cnSAE

            CADENA_CAMPO = "CLAVE_DOC, NUM_PART"
            CADENA_DATOS = FCVE_DOC & "','" & FNUM_PAR
            For k = 0 To aLIB2.GetLength(0) - 2
                Try
                    If Not IsNothing(aLIB2(FNUM_PAR, k, 0)) Then
                        CAMPO = aLIB2(FNUM_PAR, k, 0)
                        If CAMPO.Trim.Length > 0 Then
                            If CAMPO <> "--" Then
                                DATO_CAPTURADO = aLIB2(FNUM_PAR, k, 1)

                                TIPO_CAMPO = GET_DATATYPE("PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa, CAMPO)
                                Select Case TIPO_CAMPO.ToLower
                                    Case "varchar", "char"

                                    Case "int"
                                        If Not IsNumeric(DATO_CAPTURADO) Then
                                            DATO_CAPTURADO = "0"
                                        End If
                                    Case "smallint"
                                        If Not IsNumeric(DATO_CAPTURADO) Then
                                            DATO_CAPTURADO = "0"
                                        End If
                                    Case "float"
                                        If Not IsNumeric(DATO_CAPTURADO) Then
                                            DATO_CAPTURADO = "0"
                                        End If
                                    Case "date", "datetime"

                                End Select

                                CADENA_CAMPO = CADENA_CAMPO & ", " & CAMPO
                                CADENA_DATOS = CADENA_DATOS & "','" & DATO_CAPTURADO
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next

            If CADENA_CAMPO <> "CVE_DOC, NUM_PAR" Then
                'CADENA_CAMPO = CADENA_CAMPO.Substring(0, CADENA_CAMPO.Length - 1)
                'CADENA_DATOS = CADENA_DATOS.Substring(0, CADENA_DATOS.Length - 3)
                Try
                    SQL = "SET ansi_warnings OFF
                     INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " (" & CADENA_CAMPO & ") VALUES('" & CADENA_DATOS & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


    End Sub
    Private Sub TimbrarDigiBoxFactura(FCVE_DOC As String, FSERIE As String, FFOLIO As Long, FCLIENTE As String,
                                      FCAN_TOT As Decimal, FIMP_TOT1 As Decimal, FIMP_TOT2 As Decimal,
                                      FIMP_TOT3 As Decimal, FIMP_TOT4 As Decimal, FIMPORTE As Decimal)

        Dim d1 As DateTime = F1.Value
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")
        Dim aCORREOS(0) As String
        Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & EMISORRFC & "_" & FCVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_" & FCVE_DOC & ".xml"
        Dim rutaPFX As String = gRutaPFX
        Dim rutaCertificado As String = gRutaCertificado, USUARIO_TIMB As String, PASS_TIMB As String
        Dim TimbreOK As Boolean
        Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_" & FCVE_DOC & ".pdf"
        Dim errorC As CError = _c.EsInfoCorrecta()

        If TIMBRADO_DEMO = "Si" Then
            USUARIO_TIMB = "demo2"
            PASS_TIMB = "123456789"
        Else
            USUARIO_TIMB = gUSUARIO_PAC
            PASS_TIMB = gPASS_PAC
        End If
        Var8 = ""
        Try
            If File.Exists(RutaXML_NO_TIMBRADO) = True Then
                File.Delete(RutaXML_NO_TIMBRADO)
            End If
            If File.Exists(RutaXML_TIMBRADO) = True Then
                File.Delete(RutaXML_TIMBRADO)
            End If
            If File.Exists(rutaPDF) = True Then
                File.Delete(rutaPDF)
            End If
        Catch ex As Exception
        End Try

        If Not File.Exists(rutaPFX) Then
            MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
            Return
        End If

        If Not File.Exists(rutaCertificado) Then
            MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
            Return
        End If

        If LtUUID.Text.Trim.Length > 0 Then
            Dim c As CfdiRelacionado = New CfdiRelacionado()

            _c.CfdiRelacionados.TipoRelacion = "07"
            c.UUID = LtUUID.Text
            _c.CfdiRelacionados.CfdiRelacionado.Add(c)

        End If

        CFDI_XML_DIGIBOX = ""

        Dim xml As XmlDocument = GenerarXML.ObtenerXML(_c, rutaPFX, gContraPFX, rutaCertificado)
        xml.Save(RutaXML_NO_TIMBRADO)


        If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUARIO_TIMB, PASS_TIMB) Then

            CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF, Application.StartupPath & "\logo.jpg", False)
            TimbreOK = True

            SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                CLIENTE, SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID) 
                VALUES (
                @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID())"

            For k = 1 To 5
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FCVE_DOC
                        cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "F"
                        cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = ""
                        cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = ""
                        cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = FSERIE
                        cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = FECHA_CERT
                        cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                        cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = "S"
                        cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                        cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = FCLIENTE
                        cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(FCAN_TOT, 6)
                        cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = Math.Round(FIMP_TOT3, 6)
                        cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(FIMP_TOT4, 6)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(FIMPORTE, 6)
                        cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = USO_CFDI
                        cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = METODODEPAGO
                        cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = FORMAPAGO
                        cmd.Parameters.Add("@MONEDA", SqlDbType.VarChar).Value = MONEDA
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Exit For
                            End If
                        End If
                    End Using
                Catch SQLex As SqlException
                    Dim SSS As SqlError, Sqlcadena As String = ""
                    'MsgBox("Count = " & SQLex.Errors.Count)
                    For Each SSS In SQLex.Errors
                        Sqlcadena += SSS.Message & vbNewLine
                    Next
                    BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                Catch ex As Exception
                    BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next
        End If

    End Sub

    Sub CARGAR_CONCEPTOS_FACTURA(ByVal FCVE_DOC As String, FTIPO_DOC As String)
        Dim DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, CVE_PRODSERV As String = ""
        Dim CVE_UNIDAD As String = "", DESCR As String = "", UNI_MED As String = ""

        Try
            Try
                SQL = "SELECT P.CVE_ART, P.CANT, P.PREC, ISNULL(DESCR,'') AS DES, UNI_MED, P.IMPU1, P.IMPU2, P.IMPU3, P.IMPU4, P.TOT_PARTIDA,
                        CVE_PRODSERV, CVE_UNIDAD
                        FROM PAR_FACT" & FTIPO_DOC & Empresa & " P
                        LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " T ON T.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE CVE_DOC = '" & FCVE_DOC & "'"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            DESCR = dr("DES")
                            UNI_MED = dr.ReadNullAsEmptyString("UNI_MED")
                            IMPU1 = dr("IMPU1")
                            IMPU2 = dr("IMPU2")
                            IMPU3 = dr("IMPU3")
                            IMPU4 = dr("IMPU4")
                            CVE_PRODSERV = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                            CVE_UNIDAD = dr.ReadNullAsEmptyString("CVE_UNIDAD")

                            DESC1 = 0
                            PRECIO = dr("PREC")
                            Dim c As Concepto = New Concepto With {
                                .Cantidad = dr("CANT"),
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = DESCR,
                                .Descuento = DESC1,
                                .Importe = dr("TOT_PARTIDA"),
                                .NoIdentificacion = dr("CVE_ART"),
                                .Unidad = UNI_MED,
                                .ValorUnitario = PRECIO,
                                .Impuestos = GetImpuestosConcepto(PRECIO, 1, DESC1, IMPU1, IMPU2, IMPU3, IMPU4)
                            }
                            _c.Conceptos.Concepto.Add(c)

                        End While
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            CalculaTotales()

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub TimbrarDigiBoxNC(FCVE_DOC As String, FDOC_ENLAZADO As String, FCAN_TOT As Decimal,
                               FIMP_TOT1 As Decimal, FIMP_TOT2 As Decimal, FIMP_TOT3 As Decimal, FIMP_TOT4 As Decimal, FIMPORTE As Decimal)
        Dim USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim IMP1 As Decimal, IMP2 As Decimal, IMP3 As Decimal, IMP4 As Decimal
        Dim USOCFDI As String, PENDIENTE As String

        Dim d1 As DateTime = F1.Value
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")

        Me.Cursor = Cursors.WaitCursor
        _c = New Comprobante()

        GET_PARAM_CFDI("E")

        CARGAR_CONCEPTOS(FCAN_TOT, IMP1, IMP2, IMP3, IMP4)
        USOCFDI = (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI
        _c.Receptor.UsoCFDI = USOCFDI


        AGREGA_CFDIRELACIONADOS(LtCVE_DOC.Text)

        'If LtUUID.Text.Trim.Length > 0 Then
        'Dim c As CfdiRelacionado = New CfdiRelacionado()
        '_c.CfdiRelacionados.TipoRelacion = "07"
        'c.UUID = LtUUID.Text
        '_c.CfdiRelacionados.CfdiRelacionado.Add(c)
        'End If

        Try
            Dim aCORREOS(0) As String
            Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & EMISORRFC & "_NC_" & FCVE_DOC & ".xml"
            Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_NC_" & FCVE_DOC & ".xml"
            Dim rutaPFX As String = gRutaPFX
            Dim rutaCertificado As String = gRutaCertificado

            Dim rutaPDF As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_NC_" & FCVE_DOC & ".pdf"
            Dim errorC As CError = _c.EsInfoCorrecta()

            If TIMBRADO_DEMO = "Si" Then
                USUAARIO_TIMB = "demo2"
                PASS_TIMB = "123456789"
            Else
                USUAARIO_TIMB = gUSUARIO_PAC
                PASS_TIMB = gPASS_PAC
            End If
            Var8 = ""
            Try
                If File.Exists(RutaXML_NO_TIMBRADO) = True Then
                    File.Delete(RutaXML_NO_TIMBRADO)
                End If
                If File.Exists(RutaXML_TIMBRADO) = True Then
                    File.Delete(RutaXML_TIMBRADO)
                End If
                If File.Exists(rutaPDF) = True Then
                    File.Delete(rutaPDF)
                End If
            Catch ex As Exception
            End Try

            If Not File.Exists(rutaPFX) Then
                MsgBox("No se logro cargar el archivo key " & rutaPFX & ", verifque por favor")
                Return
            End If

            If Not File.Exists(rutaCertificado) Then
                MsgBox("No se logro cargar el certificado " & rutaCertificado & ", verifque por favor")
                Return
            End If

            Var46 = "NOCERTIFICADO"

            Dim xml As XmlDocument = GenerarXML.ObtenerXML(_c, rutaPFX, gContraPFX, rutaCertificado)
            xml.Save(RutaXML_NO_TIMBRADO)

            If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUAARIO_TIMB, PASS_TIMB) Then
                'CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF, Application.StartupPath & "\logo.jpg", False)
                TimbreOK = True
            End If

            Try
                If TimbreOK Then
                    PENDIENTE = "N"
                Else
                    PENDIENTE = "S"
                End If

                BACKUPTXT("CFDI", FCVE_DOC & "," & LETRA_VENTA & "," & F1.Value & "," & Var8 & ",S," & USER_GRUPOCE)

                SQL = "SET ansi_warnings OFF
                    UPDATE CFDI_COM_PAGO SET TIMBRADO = @TIMBRADO WHERE DOCUMENTO = @DOCUMENTO 
                    IF @@ROWCOUNT = 0 
                    INSERT INTO CFDI_COM_PAGO (DOCUMENTO, TDOC, DOCUMENTO_ANT, DOCUMENTO_TIPO, VERSION, SERIE, FOLIO, FECHA_CERT, FECHA_CANCEL, XML, 
                    OBS_CANC, FILE_XML, TIMBRADO, USUARIO, USUARIO_CANCELA, FECHAELAB, UUID, CLAVE_MOCANC, CLIENTE, SUBTOTAL,  
                    RETENCION, IVA, IMPORTE) VALUES (@DOCUMENTO, @TDOC, @DOCUMENTO_ANT, @DOCUMENTO_TIPO, @VERSION, @SERIE, @FOLIO, @FECHA_CERT, 
                    @FECHA_CANCEL, @XML, @OBS_CANC, @FILE_XML, @TIMBRADO, @USUARIO, @USUARIO_CANCELA, GETDATE(), NEWID(),
                    @CLAVE_MOCANC, @CLIENTE, @SUBTOTAL, @RETENCION, @IVA, @IMPORTE)"
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Add("@DOCUMENTO", SqlDbType.VarChar).Value = FCVE_DOC
                        cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "NC"
                        cmd.Parameters.Add("@DOCUMENTO_ANT", SqlDbType.VarChar).Value = FDOC_ENLAZADO
                        cmd.Parameters.Add("@DOCUMENTO_TIPO", SqlDbType.VarChar).Value = "F"
                        cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "2.0"
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_VENTA
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO_VENTA
                        cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = FECHA_CERT
                        cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = CFDI_XML_DIGIBOX
                        cmd.Parameters.Add("@FECHA_CANCEL", SqlDbType.VarChar).Value = ""
                        'cmd.Parameters.Add("@FECHA_CANCELADA", SqlDbType.Date).Value = ""
                        cmd.Parameters.Add("@OBS_CANC", SqlDbType.VarChar).Value = ""
                        cmd.Parameters.Add("@FILE_XML", SqlDbType.VarChar).Value = Path.GetFileName(RutaXML_TIMBRADO)
                        cmd.Parameters.Add("@TIMBRADO", SqlDbType.VarChar).Value = PENDIENTE
                        cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Usuario_SAROCE
                        cmd.Parameters.Add("@USUARIO_CANCELA", SqlDbType.VarChar).Value = ""
                        cmd.Parameters.Add("@CLAVE_MOCANC", SqlDbType.VarChar).Value = ""
                        cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIENTE.Text
                        cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = FCAN_TOT
                        cmd.Parameters.Add("@RETENCION", SqlDbType.Float).Value = FIMP_TOT2 + FIMP_TOT3
                        cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = FIMP_TOT4
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = FIMPORTE
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If

                    End Using
                Catch ex As Exception
                    MsgBox("955. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    BITACORATPV("955. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
                Var8 = ""
            Catch ex As Exception
                BITACORATPV("960. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("970. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Me.Cursor = Cursors.Default
        'btnTimbrarDigiBox.Enabled = True
        If TimbreOK Then
            Me.Close()
        End If

    End Sub
    Sub AGREGA_CFDIRELACIONADOS(FCVE_DOC As String)
        Dim TIPO_REL As String = ""
        Dim _cfdiRelacionados As New CfdiRelacionados
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT UUID, TIP_REL FROM CFDI_REL" & Empresa & " WHERE CVE_DOC = '" & FCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        TIPO_REL = dr("TIP_REL")
                        Dim c As New CfdiRelacionado With {.UUID = dr("UUID")}
                        _cfdiRelacionados.CfdiRelacionado.Add(c)
                    End While
                End Using
                _cfdiRelacionados.TipoRelacion = TIPO_REL
                _c.CfdiRelacionados = _cfdiRelacionados
            End Using
        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GET_PARAM_CFDI(FTIPO_COMPROBANTE As String)
        Dim CALLE As String, NUMEXT As String, NUMINT As String, COLONIA As String, LOCALIDAD As String, CP As String, ESTADO As String
        Dim PAIS As String, MUNICIPIO As String, RAZONSOCIALEMISOR As String = "", LUGAREXPEDICION As String = ""
        Dim EMISOR_REGIMEN_FISCAL As String = "", CORREO1 As String, CORREO2 As String

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM CFDI_CFG"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        gUSUARIO_PAC = dr("USUARIO")
                        gPASS_PAC = Desencriptar(dr("PASS"))
                        '0 - NO 1 - SI
                        If dr.ReadNullAsEmptyInteger("TIMBRADO_DEMO") = 0 Then
                            TIMBRADO_DEMO = "No"
                            TIMBRADO_SAT = "No"
                        Else
                            TIMBRADO_DEMO = "Si"
                            TIMBRADO_SAT = "Si"
                        End If

                        If CP_IMPRIME_IMPORTES Then
                            'CON PORCIOS CARAJO
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO_CONPRECIOS")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO_CONPRECIOS")
                        Else
                            gRutaXML_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_TIMBRADO")
                            gRutaXML_NO_TIMBRADO = dr.ReadNullAsEmptyString("RUTA_XML_NOTIMBRADO")
                        End If

                        gRutaPFX = dr("FILE_PFX")
                        gContraPFX = dr("PASS_PFX")
                        gRutaCertificado = dr("FILE_CER")

                        CALLE = dr.ReadNullAsEmptyString("CALLE")
                        NUMEXT = dr.ReadNullAsEmptyString("NUMEXT")
                        NUMINT = dr.ReadNullAsEmptyString("NUMINT")
                        COLONIA = dr.ReadNullAsEmptyString("COLONIA")
                        LOCALIDAD = dr.ReadNullAsEmptyString("LOCALIDAD")
                        CP = dr.ReadNullAsEmptyString("CP")
                        ESTADO = dr.ReadNullAsEmptyString("ESTADO")
                        MUNICIPIO = dr.ReadNullAsEmptyString("MUNICIPIO")
                        PAIS = dr.ReadNullAsEmptyString("PAIS")
                        EMISORRFC = dr("EMISOR_RFC")
                        RAZONSOCIALEMISOR = dr("EMISOR_RAZON_SOCIAL")

                        LUGAREXPEDICION = dr("EMISOR_LUGAR_EXPEDICION")
                        EMISOR_REGIMEN_FISCAL = dr("EMISOR_REGIMEN_FISCAL")
                        CORREO1 = dr.ReadNullAsEmptyString("CORREO1")
                        CORREO2 = dr.ReadNullAsEmptyString("CORREO2")
                        FTP_CFDI_DEV = dr.ReadNullAsEmptyString("FTODEV")
                    End If
                End Using
            End Using

            _c.Emisor.Nombre = RAZONSOCIALEMISOR
            _c.Emisor.Rfc = EMISORRFC
            _c.LugarExpedicion = LUGAREXPEDICION
            _c.Fecha = F1.Value
            _c.Serie = LETRA_VENTA
            _c.Folio = FOLIO_VENTA
            _c.Emisor.RegimenFiscal = EMISOR_REGIMEN_FISCAL

            If cbRegimenesFiscales.SelectedItem IsNot Nothing Then _c.Emisor.RegimenFiscal = (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal

            USO_CFDI = (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI
            MONEDA = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda
            METODODEPAGO = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
            FORMAPAGO = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago

            _c.TipoDeComprobante = FTIPO_COMPROBANTE
            _c.Moneda = (CType(cbMoneda.SelectedItem, cMoneda)).Moneda
            _c.MetodoPago = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
            _c.FormaPago = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago

            _c.Exportacion = "01"

            _c.Receptor.Nombre = LtNombre.Text
            _c.Receptor.Rfc = LtRFC.Text

            _c.Receptor.DomicilioFiscalReceptor = LtCP.Text
            _c.Receptor.RegimenFiscalReceptor = (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal
            _c.Receptor.UsoCFDI = (CType(cbUsoCfdi.SelectedItem, cUsoCFDI)).UsoCFDI


        Catch ex As Exception
            BITACORATPV("1000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CONCEPTOS(ByVal FSUBTOTAL As Decimal, ByRef FIMP1 As Decimal, ByRef FIMP2 As Decimal, ByRef FIMP3 As Decimal, ByRef FIMP4 As Decimal)
        Dim CANT As Decimal, CVE_ART As String, DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal
        Dim IMPU4 As Decimal, CVE_PRODSERV As String = "", CVE_UNIDAD As String = "", DESCR As String = "", UNI_MED As String = "", IMPORTE As Decimal = 0
        Try
            CANT = 1
            CVE_ART = CVE_ART_NC
            If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                Try
                    SQL = "SELECT ISNULL(DESCR,'') AS DES, UNI_MED, ISNULL(P.IMPUESTO1,0) AS IMPU1, ISNULL(P.IMPUESTO2,0) AS IMPU2, 
                        ISNULL(P.IMPUESTO3,0) AS IMPU3, ISNULL(P.IMPUESTO4,0) AS IMPU4, CVE_PRODSERV, CVE_UNIDAD
                        FROM INVE" & Empresa & " I
                        LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE CVE_ART = '" & CVE_ART & "'"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                            If dr2.Read Then
                                DESCR = dr2("DES")
                                UNI_MED = dr2.ReadNullAsEmptyString("UNI_MED")
                                IMPU1 = dr2("IMPU1")
                                IMPU2 = dr2("IMPU2")
                                IMPU3 = dr2("IMPU3")
                                IMPU4 = dr2("IMPU4")
                                CVE_PRODSERV = dr2.ReadNullAsEmptyString("CVE_PRODSERV")
                                CVE_UNIDAD = dr2.ReadNullAsEmptyString("CVE_UNIDAD")
                                FIMP1 = IMPU1
                                FIMP2 = IMPU2
                                FIMP3 = IMPU3
                                FIMP4 = IMPU4
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                'DESCR = Fg(k, 6)
                DESC1 = 0 'Fg(k, 8)
                PRECIO = FSUBTOTAL  'Fg(k, 13)
                'IMPORTE = Fg(k, 14)
                Dim c As Concepto = New Concepto With {
                    .Cantidad = 1,
                    .ClaveProdServ = CVE_PRODSERV,
                    .ClaveUnidad = CVE_UNIDAD,
                    .Descripcion = DESCR,
                    .Descuento = DESC1,
                    .Importe = FSUBTOTAL,
                    .NoIdentificacion = CVE_ART,
                    .Unidad = UNI_MED,
                    .ValorUnitario = FSUBTOTAL,
                    .Impuestos = GetImpuestosConcepto(FSUBTOTAL, 1, DESC1, IMPU1, IMPU2, IMPU3, IMPU4),
                    .ObjetoImp = "02"
                }
                _c.Conceptos.Concepto.Add(c)
            End If

            CalculaTotales()

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Function GetImpuestosConcepto(FPRECIO As Decimal, FCANT As Decimal, FDESC As Decimal,
                                          FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal) As ImpuestosC
        Dim impuesto As ImpuestosC = New ImpuestosC()
        Try
            If FIMPU1 > 0 Then
                FIMPU1 = FIMPU1 / 100
                impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 = FIMPU2 / 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 = FIMPU3 / 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 = FIMPU4 / 100
                impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU4, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU4, 2), .TipoFactor = "Tasa"})
            End If
        Catch ex As Exception
            BITACORATPV("1750. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1750. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return impuesto

    End Function
    Private Sub CalculaTotales()
        _c.Impuestos = GetImpuestos(_c.Conceptos.Concepto)
        Dim subtotal As Decimal = 0D
        Dim descuento As Decimal = 0D

        For Each c As Concepto In _c.Conceptos.Concepto
            subtotal = subtotal + c.Importe
            descuento = c.Descuento
        Next

        _c.SubTotal = subtotal
        _c.Descuento = descuento
        _c.Total = subtotal - _c.Impuestos.TotalImpuestosRetenidos + _c.Impuestos.TotalImpuestosTrasladados
        _c.TotalLetra = New Numalet().ToCustomString(_c.Total)

    End Sub
    Private Function GetImpuestos(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As Traslado = New Traslado()
        Dim retencion As Retencion = New Retencion()
        Dim traslados As List(Of Traslado) = New List(Of Traslado)()
        Dim retenciones As List(Of Retencion) = New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As Impuestos = New Impuestos()

        For Each c As Concepto In conceptos
            For Each t As TrasladoC In c.Impuestos.Traslados
                If (traslados.Exists(Function(x) (x.Impuesto = t.Impuesto) AndAlso (x.TasaOCuota = t.TasaOCuota))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = t.Impuesto)
                    traslados(index).Importe = traslados(index).Importe + t.Importe
                Else
                    traslado = New Traslado With {
                        .Importe = t.Importe,
                        .Impuesto = t.Impuesto,
                        .TasaOCuota = t.TasaOCuota,
                        .TipoFactor = t.TipoFactor,
                        .Base = t.Base
                    }
                    traslados.Add(traslado)
                End If
            Next

            For Each r As RetencionC In c.Impuestos.Retenciones
                If (retenciones.Exists(Function(x) (x.Impuesto = r.Impuesto))) Then
                    index = traslados.FindIndex(Function(x) x.Impuesto = r.Impuesto)
                    retenciones(index).Importe = retenciones(index).Importe + r.Importe
                Else
                    retencion = New Retencion()
                    retencion.Importe = r.Importe
                    retencion.Impuesto = r.Impuesto

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos = totalImpuestosRetenidos + r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados = totalImpuestosTrasladados + t.Importe
        Next

        impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function

    Private Sub CargarUsosCfdi()
        Dim lista As List(Of cUsoCFDI) = New List(Of cUsoCFDI) From {
            New cUsoCFDI(1, "G01", "Adquisición de mercancias"),
            New cUsoCFDI(2, "G02", "Devoluciones, descuentos o bonificaciones"),
            New cUsoCFDI(3, "G03", "Gastos en general"),
            New cUsoCFDI(4, "I01", "Construcciones"),
            New cUsoCFDI(5, "I02", "Mobilario y equipo de oficina por inversiones"),
            New cUsoCFDI(6, "I03", "Equipo de transporte"),
            New cUsoCFDI(7, "I04", "Equipo de computo y accesorios"),
            New cUsoCFDI(8, "I05", "Dados, troqueles, moldes, matrices y herramental"),
            New cUsoCFDI(9, "G01", "Adquisición de mercancias"),
            New cUsoCFDI(10, "G02", "Devoluciones, descuentos o bonificaciones"),
            New cUsoCFDI(11, "G03", "Gastos en general"),
            New cUsoCFDI(12, "I01", "Construcciones"),
            New cUsoCFDI(13, "I02", "Mobilario y equipo de oficina por inversiones"),
            New cUsoCFDI(14, "I03", "Equipo de transporte"),
            New cUsoCFDI(15, "I04", "Equipo de computo y accesorios"),
            New cUsoCFDI(16, "I05", "Dados, troqueles, moldes, matrices y herramental"),
            New cUsoCFDI(17, "I06", "Comunicaciones telefónicas"),
            New cUsoCFDI(18, "I07", "Comunicaciones satelitales"),
            New cUsoCFDI(19, "I08", "Otra maquinaria y equipo"),
            New cUsoCFDI(20, "D01", "Honorarios médicos, dentales y gastos hospitalarios."),
            New cUsoCFDI(21, "D02", "Gastos médicos por incapacidad o discapacidad"),
            New cUsoCFDI(22, "D03", "Gastos funerales."),
            New cUsoCFDI(23, "D04", "Donativos."),
            New cUsoCFDI(24, "D05", "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."),
            New cUsoCFDI(25, "D06", "Aportaciones voluntarias al SAR."),
            New cUsoCFDI(26, "D07", "Primas por seguros de gastos médicos."),
            New cUsoCFDI(27, "D08", "Gastos de transportación escolar obligatoria."),
            New cUsoCFDI(28, "D09", "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."),
            New cUsoCFDI(29, "D10", "Pagos por servicios educativos (colegiaturas)"),
            New cUsoCFDI(30, "P01", "Por definir"),
            New cUsoCFDI(31, "I06", "Comunicaciones telefónicas"),
            New cUsoCFDI(32, "I07", "Comunicaciones satelitales"),
            New cUsoCFDI(33, "I08", "Otra maquinaria y equipo"),
            New cUsoCFDI(34, "D01", "Honorarios médicos, dentales y gastos hospitalarios."),
            New cUsoCFDI(35, "D02", "Gastos médicos por incapacidad o discapacidad"),
            New cUsoCFDI(36, "D03", "Gastos funerales."),
            New cUsoCFDI(37, "D04", "Donativos."),
            New cUsoCFDI(38, "D05", "Intereses reales efectivamente pagados por créditos hipotecarios (casa habitación)."),
            New cUsoCFDI(39, "D06", "Aportaciones voluntarias al SAR."),
            New cUsoCFDI(40, "D07", "Primas por seguros de gastos médicos."),
            New cUsoCFDI(41, "D08", "Gastos de transportación escolar obligatoria."),
            New cUsoCFDI(42, "D09", "Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones."),
            New cUsoCFDI(43, "D10", "Pagos por servicios educativos (colegiaturas)"),
            New cUsoCFDI(44, "P01", "Por definir")
        }
        cbUsoCfdi.DataSource = lista
    End Sub
    Sub ENLAZAR_CVE_DOC_UPDATE_DOC_SIG(fCVE_DOC As String)
        Dim TIPO_DOC_LOV As String
        Try
            TIPO_DOC_LOV = "P"
            For k = 0 To UBound(aDOCS)
                If aDOCS(k).ToString.Length > 0 Then

                    SQL = "UPDATE FACT" & TIPO_DOC_LOV & Empresa & " SET " &
                          "DOC_SIG = '" & fCVE_DOC & "', TIP_DOC_SIG = 'V', ENLAZADO = 'T', " &
                          "TIP_DOC_E = 'V' WHERE " & "CVE_DOC = '" & aDOCS(k) & "'"
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        BITACORATPV("1980. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("1980. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            BITACORATPV("1990. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1990. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_M(fCVE_DOC As String, fCLAVE As String, fIMPORTE As Decimal, fNUM_CARGO As Long, fCVE_VEND As String, fCVE_BITA As Long)

        Dim CVE_CLIE As String, REFER As String, NUM_CPTO As Integer, CVE_OBS As Long, NO_FACTURA As String, DOCTO As String, IMPORTE As Decimal
        Dim AFEC_COI As String, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, ENTREGADA As String
        Dim cmd As New SqlCommand
        Dim cmdT As New SqlCommand

        Try
            CVE_CLIE = fCLAVE
            REFER = fCVE_DOC
            NO_FACTURA = REFER
            DOCTO = REFER
            IMPORTE = fIMPORTE
            IMPMON_EXT = fIMPORTE

            SIGNO = 1

            If TIPO_VENTA_LOCAL = "F" Then
                NUM_CPTO = 1
            Else
                NUM_CPTO = 2
            End If


            CVE_OBS = 0 : AFEC_COI = "S" : STRCVEVEND = fCVE_VEND : NUM_MONED = 1 : TCAMBIO = 1
            CVE_FOLIO = "" : TIPO_MOV = "C" : ENTREGADA = "S"

            SQL = "IF NOT EXISTS(SELECT REFER FROM CUEN_M" & Empresa & " WHERE " &
                "REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND NUM_CPTO = " & NUM_CPTO & " AND NUM_CARGO = 1) " &
                "INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, " &
                "IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, " &
                "CVE_BITA, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & NUM_CPTO &
                "','1','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(fIMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112)," &
                "CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" & TCAMBIO & "','" &
                Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" & TIPO_MOV & "','" & fCVE_BITA & "','" & SIGNO & "','" &
                CLAVE_SAE & "','" & ENTREGADA & "',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"
            Try
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            Catch ex As Exception
                BITACORATPV("2000. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2000. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            BITACORATPV("2020. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2020. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CUEN_DET(fCVE_DOC As String, fDOCTO As String, fCLAVE As String, fIMPORTE As Decimal, fNUM_CARGO As Integer, fNUM_CPTO_PAGO As Integer, fCVE_VEND As String)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim DOCTO As String, IMPORTE As Decimal, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, NO_PARTIDA As Integer, AFEC_COI As String
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim cmdT As New SqlCommand

        CVE_CLIE = fCLAVE
        REFER = fCVE_DOC
        NO_FACTURA = REFER

        If fNUM_CPTO_PAGO = 0 Then
            NUM_CPTO = 10
        Else
            NUM_CPTO = fNUM_CPTO_PAGO
        End If

        If TIPO_VENTA_LOCAL = "F" Then
            ID_MOV = 1
        Else
            ID_MOV = 2
        End If

        CVE_OBS = 0 : DOCTO = fDOCTO : NUM_MONED = 1 : TCAMBIO = 1 : AFEC_COI = "S"
        IMPORTE = fIMPORTE
        STRCVEVEND = fCVE_VEND
        IMPMON_EXT = IMPORTE

        CVE_FOLIO = "" : TIPO_MOV = "A" : NO_PARTIDA = 1 : NUM_CARGO = 1
        SIGNO = -1

        cmd.Connection = cnSAE
        SQL = "SELECT COALESCE(MAX(NO_PARTIDA),0) + 1 AS NO_PAR FROM CUEN_DET" & Empresa & " 
            WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "'"
        Try
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                NO_PARTIDA = dr("NO_PAR")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("2030. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2030. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "IF NOT EXISTS (SELECT REFER FROM CUEN_DET" & Empresa & " WHERE REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND " &
            "ID_MOV = " & ID_MOV & " AND NUM_CPTO = " & NUM_CPTO & " AND NO_PARTIDA = " & NO_PARTIDA & ") " &
            "INSERT INTO CUEN_DET" & Empresa & " (CVE_CLIE, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, " &
            "FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, SIGNO, " &
            "CVE_AUT, USUARIO, NO_PARTIDA, UUID, VERSION_SINC) VALUES('" & CVE_CLIE & "','" & REFER & "','" & ID_MOV & "','" & NUM_CPTO & "','" &
            NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(fIMPORTE, 6) &
            "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & NUM_MONED & "','" &
            TCAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'0','" & CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','0','" & CLAVE_SAE & "','" &
            NO_PARTIDA & "',NEWID(), GETDATE())"
        Try
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2040. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2040. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ACTUALIZA_SALDO_CLIENTE(fTIP As String, fEMPRESA3 As String, fCVE_DOC As String, fIMPORTE As Decimal,
                                fFECHA_DOC As String, fCLIENTE As String, fSIGNO As Integer)
        '                      ACTUALIZACION DE SALDO DE CLIENTE
        Dim IMPORTE As Decimal

        IMPORTE = Math.Round(fIMPORTE, 4) * fSIGNO

        SQL = "UPDATE CLIE" & fEMPRESA3 & " SET SALDO = ROUND((COALESCE(SALDO,0) + (" & IMPORTE & ")),4), " &
            "ULT_VENTAD = '" & fCVE_DOC & "', ULT_COMPM = " & IMPORTE & ", FCH_ULTCOM = '" & fFECHA_DOC & "' " &
            "WHERE CLAVE = '" & fCLIENTE & "'"
        Try
            Dim cmdF As New SqlCommand With {
                .Connection = cnSAE,
                .CommandText = SQL
            }
            returnValue = cmdF.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
            End If
        Catch ex As Exception
            BITACORATPV("2050. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2050. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObserDoc_Click(sender As Object, e As EventArgs) Handles BarObserDoc.Click
        Try
            Var4 = Obser
            Var5 = "NUEVO"
            Var6 = "FACTF_CLIB"
            Var7 = "FACT" & TIPO_VENTA & "_CLIB" & Empresa

            If DOC_NEW Then
                Var8 = ""
            Else
                Var8 = LtCVE_DOC.Text
            End If

            FrmObserYCampLib.ShowDialog()
            Obser = Var4
        Catch ex As Exception
            BITACORATPV("2060. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2060. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            Fg.RemoveItem(Fg.Row)
            If Fg.Rows.Count - 1 = 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 2
            End If
        Catch ex As Exception
            BITACORATPV("2070. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2070. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarAltaProv_Click(sender As Object, e As EventArgs) Handles BarAltaProv.Click
        Var1 = "Nuevo"
        frmClientesAE.ShowDialog()
    End Sub
    Private Sub BarAltaArticulo_Click(sender As Object, e As EventArgs) Handles BarAltaArticulo.Click

        Try
            DialogOK = "Show"
            FrmInvenAE.ShowDialog()
            DialogOK = ""
        Catch ex As Exception
            BITACORATPV("2070. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnClie_Click(sender As Object, e As EventArgs) Handles BtnClie.Click
        Try
            Var2 = "Clientes"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4

                LLENA_CAMPOS(Var4)

                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCVE_VEND.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        'SE_MODIFICA = false
        Try
            If Not SE_MODIFICA Then
                Return
            End If
            If ENTRA Then

                If Fg.Col = 2 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 8 Or Fg.Col = 13 Then
                    'start editing the cell with the custom editor
                    Dim c_ As Integer
                    If Fg.Col = 1 Then
                        c_ = 2
                    Else
                        c_ = Fg.Col
                    End If
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, c_)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Not SE_MODIFICA Then
            Return
        End If

        Try
            If Fg.Row > 0 Then
                Select Case e.Col
                    Case 5
                        Try
                            If IsNothing(Fg(Fg.Row, 2)) Then
                                MsgBox("La cantidad no debe quedar vacia")
                                Fg.Col = 2
                                Return
                            End If
                            If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                                MsgBox("La cantidad no debe quedar vacia")
                                Fg.Col = 2
                                Return
                            End If
                            Var15 = "Busqueda"

                            Var4 = ""
                            If TIPO_VENTA_LOCAL = "F" Then
                                Var2 = "FACTURA"
                                Var5 = ""
                            Else
                                Var2 = "Articulo"
                                Var5 = LINEA_EN_VENTAS
                            End If

                            Fg.FinishEditing()

                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                Fg(Fg.Row, 4) = Var4
                                Fg(Fg.Row, 6) = Var5
                                LLENAR_GRID_ARTICULO(Var4)
                                Var2 = ""
                                Var4 = ""
                                Var5 = ""
                                Fg.Col = 13
                            Else
                                Fg.Col = 2
                            End If
                        Catch ex As Exception
                            BITACORATPV("2090. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2090. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                End Select
            End If
        Catch ex As Exception
            BITACORATPV("2100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single
            Dim PRECIO As Single

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            SQL = "SELECT DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU,  " &
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
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE CVE_ART = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ULT_COSTO = dr("ULT_COSTO")
                Fg(Fg.Row, 6) = dr("DESCR")
                Fg(Fg.Row, 7) = dr("UNI_MED")
                Fg(Fg.Row, 8) = TDESC.Text
                Fg(Fg.Row, 9) = dr("IMPUESTO1") 'IEPS
                Fg(Fg.Row, 10) = dr("IMPUESTO2") 'IMPU2
                Fg(Fg.Row, 11) = dr("IMPUESTO3") 'IMPU4
                Fg(Fg.Row, 12) = dr("IMPUESTO4") 'IVA
                Fg(Fg.Row, 27) = dr("CVE_ESQIMPU")
                If Fg(Fg.Row, 15) <> fCVE_ART Then
                    Select Case CboPrecio.Items(CboPrecio.SelectedIndex).ToString.Substring(0, 2)
                        Case "01"
                            PRECIO = dr("P1")
                        Case "02"
                            PRECIO = dr("P2")
                        Case "03"
                            PRECIO = dr("P3")
                        Case "04"
                            PRECIO = dr("P4")
                        Case "05"
                            PRECIO = dr("P5")
                        Case "06"
                            PRECIO = dr("P6")
                        Case "07"
                            PRECIO = dr("P7")
                        Case "08"
                            PRECIO = dr("P8")
                        Case "09"
                            PRECIO = dr("P9")
                        Case "10"
                            PRECIO = dr("P10")
                        Case "11"
                            PRECIO = dr("P11")
                        Case "12"
                            PRECIO = dr("P12")
                        Case "13"
                            PRECIO = dr("P13")
                        Case "14"
                            PRECIO = dr("P14")
                    End Select
                    Fg(Fg.Row, 13) = Math.Round(PRECIO, 4)
                End If
                Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                Fg(Fg.Row, 15) = fCVE_ART
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles btnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tEsquema.Value = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TDESC.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2170. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2170. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEntregarEn_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tEntregarEn.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                If TCLIENTE.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del cliente")
                    TCLIENTE.Focus()
                    Return
                End If
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_, 9)
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If Fg.Row > 0 And ENTRA Then
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If ENTRA Then
                If Fg.Col = 2 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 8 Or Fg.Col = 13 Then
                    e.Cancel = True
                Else
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If ENTRA Then
                If _myEditor.Visible Then
                    _myEditor.UpdatePosition()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If ENTRA Then
                _myEditor.SetPendingKey(e.KeyChar)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TEsquema_KeyDown(sender As Object, e As KeyEventArgs) Handles tEsquema.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                TDESC.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 2 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 8 Or Fg.Col = 13 Then

                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2210. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarLimpiar_Click(sender As Object, e As EventArgs) Handles BarLimpiar.Click
        Try
            LIMPIAR()
        Catch ex As Exception
        End Try
    End Sub
    Sub LIMPIAR()

        Try
            'cboTipoVenta.SelectedIndex = 0
            TCLIENTE.Text = ""
            LtNombre.Text = ""
            LtNombre.Tag = ""
            LtCalle.Text = ""
            LtColonia.Text = ""
            LtNumInt.Text = ""
            LtNumExt.Text = ""
            LtCP.Text = ""
            LtRFC.Text = ""
            LtPoblacion.Text = ""
            LtEstado.Text = ""
            TCLIENTE.Text = ""
            TCVE_PEDI.Text = ""
            DOC_ENLAZADO = "N"
            DOC_NEW = True
            Obser = ""
            TCVE_UNI.Text = ""
            LUnidad.Text = ""
            TCVE_TIPO.Text = ""
            L4.Text = ""
            TCVE_VEND.Text = ""
            Try
                tEsquema.Value = 1
                TDESC.Value = "0"
                tDesFin.Value = "0"
                LtTOTAL.Text = ""
                LtDocAnt.Text = ""
            Catch ex As Exception
            End Try
            tEntregarEn.Text = ""
            tEntregarEn.Tag = ""
            LtCVE_DOC.Tag = ""

            LtFAC_CVE_DOC.Text = ""
            LtUUID.Text = ""

            ENTRA = False
            Try
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(1, 2, 99)
                End If
            Catch ex As Exception
                BITACORATPV("2278. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                Fg.Rows.Count = 1
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                           "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                Fg.Row = 1
                Fg.Col = 2
                ENTRA = True
                Fg_Click(Nothing, Nothing)
            Catch ex As Exception
                ENTRA = True
            End Try

            Try
                For k = 0 To aLIB1.GetLength(0) - 2
                    aLIB1(k, 0) = "--"
                    aLIB1(k, 1) = ""
                Next
                For k = 0 To aLIB2.GetLength(0) - 2
                    For j = 0 To aLIB2.GetLength(0) - 2
                        aLIB2(k, j, 0) = "--"
                        aLIB2(k, j, 1) = ""
                    Next
                Next
                Tab1.SelectedIndex = 0
                Lt2.Text = ""
            Catch ex As Exception
                BITACORATPV("2278. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            TCLIENTE.Focus()
        Catch ex As Exception
            BITACORATPV("2280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnVend_Click(sender As Object, e As EventArgs) Handles BtnVend.Click
        Try
            Var2 = "Vend"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_VEND.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TDESC.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_VEND_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VEND.KeyDown
        Try
            If e.KeyCode = 13 Then
                Try
                    If TCLIENTE.Text.Trim.Length = 0 Then
                        MsgBox("Por favor capture la clave del cliente")
                        TCLIENTE.Focus()
                        Return
                    End If
                    TDESC.Focus()
                    Return
                Catch ex As Exception
                    BITACORATPV("2380. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2380. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If e.KeyCode = Keys.F2 Then
                BtnVend_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            BITACORATPV("2390. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2390. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_VEND_Validated(sender As Object, e As EventArgs) Handles TCVE_VEND.Validated
        Try
            If TCVE_VEND.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = TCVE_VEND.Text
                If IsNumeric(DESCR.Trim) Then
                    DESCR = Space(5 - DESCR.Trim.Length) & DESCR.Trim
                    TCVE_VEND.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Vend", TCVE_VEND.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Vendedor inexistente o esta de baja")
                    TCVE_VEND.Text = ""
                    TCVE_VEND.Focus()
                    TCVE_VEND.Select()
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarExcel_Click(sender As Object, e As EventArgs) Handles BarExcel.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "PEDIDO" & LtCVE_DOC.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TMagico2_GotFocus(sender As Object, e As EventArgs) Handles tMagico2.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 1 Then
                c_ = 2
            Else
                c_ = Fg.Col
            End If
            If Not IsNothing(_myEditor) Then
                _myEditor.StartEditing(Fg.Row, c_)
            End If
        Catch ex As Exception
            BITACORATPV("2450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEntregarEn_Validated(sender As Object, e As EventArgs) Handles tEntregarEn.Validated
        Try
            If tEntregarEn.Text.Trim.Length > 0 Then
                Var5 = ""
                Dim DESCR As String
                DESCR = BUSCA_CAT("Sucursal", tEntregarEn.Text)
                If DESCR <> "" Then
                    LtSuc.Text = DESCR
                Else
                    MsgBox("Sucursal   " & tEntregarEn.Text & " inexistente")
                    tEntregarEn.Text = ""
                    tEntregarEn.Focus()
                    tEntregarEn.SelectAll()
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_DATOS_ENVIO()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(I.CLAVE, '') AS CLAVE1, ISNULL(I.NOMBRE, '') AS NOMBRE1, ISNULL(I.CALLE, '') AS CALLE1, ISNULL(I.NUMINT, '') AS NUMINT1, " &
                    "ISNULL(I.NUMEXT, '') AS NUMEXT1, ISNULL(I.CRUZAMIENTOS2, '') AS CRUZAMIENTOS21, ISNULL(I.COLONIA, '') AS COLONIA1, ISNULL(I.CALLE_ENVIO, '') AS CALLE_ENVIO1, " &
                    "ISNULL(I.NUMINT_ENVIO, '') AS NUMINT_ENVIO1, ISNULL(I.NUMEXT_ENVIO, '') AS NUMEXT_ENVIO1, ISNULL(I.REFERENCIA_ENVIO, '') AS REFERENCIA_ENVIO1, " &
                    "ISNULL(I.LAT_ENVIO, '') AS  LAT_ENVIO1 " &
                    "FROM CLIE" & Empresa & " I WHERE CLAVE = '" & tEntregarEn.Tag & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                    Else
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("2610. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2610. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TDesFin_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tDesFin.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                tCONDICION.Focus()
                tCONDICION.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_VEND_GotFocus(sender As Object, e As EventArgs) Handles TCVE_VEND.GotFocus
        tEsquema.SelectAll()
    End Sub
    Private Sub TEntregarEn_GotFocus(sender As Object, e As EventArgs) Handles tEntregarEn.GotFocus
        tEntregarEn.SelectAll()
    End Sub
    Private Sub TCVE_PEDI_GotFocus(sender As Object, e As EventArgs) Handles TCVE_PEDI.GotFocus
        TCVE_PEDI.SelectAll()
    End Sub
    Private Sub TCLIENTE_GotFocus(sender As Object, e As EventArgs) Handles TCLIENTE.GotFocus
        TCLIENTE.SelectAll()
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnClie_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If IsNumeric(TCLIENTE.Text.Trim) Then
                TCLIENTE.Text = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
            End If
            TCVE_VEND.Focus()
        End If
    End Sub
    Private Sub TCLIENTE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLIENTE.PreviewKeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave del cliente")
                TCLIENTE.Select()
                TCLIENTE.Select()
            End If
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length = 0 Then
                Return
            End If
            LLENA_CAMPOS(TCLIENTE.Text)
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEntregarEn_Click(sender As Object, e As EventArgs) Handles btnEntregarEn.Click
        Try
            Var2 = "Sucursal"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tEntregarEn.Text = Var4
                LtSuc.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Try
                    Dim c_ As Integer
                    If Fg.Col = 1 Then
                        c_ = 2
                    Else
                        c_ = Fg.Col
                    End If
                    If Not IsNothing(_myEditor) Then
                        _myEditor.StartEditing(Fg.Row, c_, 0)
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            BITACORATPV("2670. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2670. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCONDICION_KeyDown(sender As Object, e As KeyEventArgs) Handles tCONDICION.KeyDown
        Try
            If e.KeyCode = 13 Then
                TCVE_UNI.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCONDICION_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCONDICION.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                'tCVE_UNI.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCONDICION_GotFocus(sender As Object, e As EventArgs) Handles tCONDICION.GotFocus
        tCONDICION.SelectAll()
        tCONDICION.BackColor = Color.Yellow
    End Sub

    Private Sub TCONDICION_LostFocus(sender As Object, e As EventArgs) Handles tCONDICION.LostFocus
        tCONDICION.BackColor = Color.White
    End Sub
    Sub CANCELAR_CFDI()

        Try

            Var2 = LtCVE_DOC.Text ' Fg(Fg.Row, 2) 'FACTURA
            Var3 = "N"  'CATA PORTE 1
            Var4 = "N"  'CATA PORTE 2
            Var6 = "FTPV"  'FACTURA TPV
            Var10 = "4.0" 'VERSION

            Var5 = ""

            FrmCFDICancFAC.ShowDialog()
            If Var5 = "ok" Then
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            BITACORACFDI("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarCancelar_Click(sender As Object, e As EventArgs) Handles BarCancelar.Click

        If LtCanc.Visible Then
            MsgBox("El documento ya se encuentra cancelada, verifique por favor")
            Return
        End If

        If Ldocu.Tag = "Digital" Then
            CANCELAR_CFDI()
        Else
            CANCELAR_DOCUMENTO()
        End If

    End Sub
    Sub CANCELAR_DOCUMENTO()
        Dim DOC_ANT As String = "", TIP_DOC_ANT As String = "", CVE_DOC As String, CADENA_CANC As String = ""
        Dim nCanc As Integer = 0, nNoCanc As Integer = 0
        'MOVSINV
        Dim CLAVE_CLPV As String = "", CVE_PEDI As String = ""
        Dim DOC_SIG As String = "", TIP_DOC_SIG As String
        Dim DoctoCancelado As String, SiOk As Boolean, CVE_BITA As Long, Sigue As Boolean, ENLAZADO As String = ""
        Dim DATO_REGRESADO As String, IMPORTE As Single, Status As String, FECHA_VENTA As String, CADENA As String = ""


        If Not Valida_Conexion() Then
            Return
        End If

        CVE_DOC = LtCVE_DOC.Text

        If CVE_DOC.Trim.Length = 0 Then
            MsgBox("No se encontro el documento a cancelar")
            Return
        End If

        If TCVE_PEDI.Tag = "T" Then
            Select Case TIPO_VENTA_LOCAL
                Case "C"
                    MsgBox("La cotizacion tiene un documento siguiente, no es posible realziar la cancelación")
                Case "R"
                    MsgBox("La remision tiene un documento siguiente, no es posible realziar la cancelación")
                Case "V"
                    MsgBox("La nota de venta tiene un documento siguiente, no es posible realziar la cancelación")
                Case "P"
                    MsgBox("El pedido tiene un documento siguiente, no es posible realziar la cancelación")
                Case "D"
                    MsgBox("La devolución tiene un documento siguiente, no es posible realziar la cancelación")
            End Select
            Return
        End If
        Try
            Try
                Select Case TIPO_VENTA_LOCAL
                    Case "C"
                        CADENA = "UNA COTIZACION"
                    Case "R"
                        CADENA = "UNA REMISION"
                    Case "V"
                        CADENA = "UNA NOTA DE VENTA"
                    Case "P"
                        CADENA = "UN PEDIDO"
                    Case "D"
                        CADENA = "UNA DEVOLUCION"
                End Select
            Catch ex As Exception
                BITACORATPV("2700. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2700. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If MsgBox("ESTA INTENTANDO CANCELAR " & CADENA & ", ES CORRECTO?", vbYesNo, "TIPO DE DOCUMENTO") = vbNo Then
                Exit Sub
            End If

            If MsgBox("El documento a cancelar es el " & CVE_DOC & ", Es correcto?", vbYesNo, "Verificar documento a cancelar") = vbNo Then
                Exit Sub
            End If
            If CVE_DOC.Trim.Length = 0 Then
                MsgBox("Por favor capturer el documento en cuadro de texto 'Documento'")
                Exit Sub
            End If
            If Not Valida_Conexion() Then
                MsgBox("Problema al conectarse al servidor")
                Exit Sub
            End If
            'NOMBRE & IIf(rst!TIPO = "C", "    (Crédito)", "") & vbTab & rst!FECHA_DOC & vbTab & rst!Importe & vbTab &
            'rst!STATUS & vbTab & rst!DOCSIG & vbTab & rst!TIPDOCSIG & vbTab & rst!DOCANT & vbTab & rst!TIPDOCANT & vbTab & rst!FPAGO3
            Try
                FECHA_VENTA = "" : Status = ""
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_CLPV, ISNULL(DOC_SIG,'') AS DOCSIG, FECHA_DOC, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG, ISNULL(R.ENLAZADO,'') AS ENLAZA, " &
                        "ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(TIP_DOC_ANT,'') AS TIPDOCANT, ISNULL(STATUS,'') AS ST, ISNULL(CVE_PEDI,'') AS PEDI " &
                        "FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " R " &
                        "WHERE CVE_DOC = '" & CVE_DOC & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CLAVE_CLPV = dr("CVE_CLPV")
                            DoctoCancelado = dr("DOCSIG")
                            FECHA_VENTA = FSQL(dr("FECHA_DOC"))
                            DOC_SIG = dr("DOCSIG")     'PUEDE VENIR DE UNA FACTURA
                            TIP_DOC_SIG = dr("TIPDOCSIG")  'PUEDE VENIR DE UNA FACTURA
                            DOC_ANT = dr("DOCANT")
                            TIP_DOC_ANT = dr("TIPDOCANT")
                            CVE_PEDI = dr("PEDI")
                            ENLAZADO = dr("ENLAZA")
                            Status = dr("ST")
                        Else
                            Status = "XXX"
                        End If
                    End Using
                End Using
                If Status = "XXX" Then
                    MsgBox("Documento inexistente")
                    Exit Sub
                End If

                If Status = "C" Then
                    MsgBox("El documento actualmente se encuentra cancelado, cancelación abortada")
                    Exit Sub
                End If
            Catch ex As Exception
                BITACORATPV("2710. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2710. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT STATUS FROM FACTF" & Empresa & " WHERE DOC_ANT = '" & CVE_DOC & "' AND TIP_DOC_ANT = '" & TIPO_VENTA_LOCAL & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        Do While dr.Read
                            If dr("STATUS") = "C" Then
                                nCanc += 1
                            Else
                                nNoCanc += 1
                            End If
                        Loop
                    End Using
                    If nNoCanc >= 1 Then
                        Sigue = False
                    Else
                        If (nNoCanc + nCanc) = 0 Then
                            Sigue = False
                        Else
                            Sigue = True
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORATPV("2715. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2715. " & ex.Message & vbNewLine & ex.StackTrace)
                Return
            End Try

            If ENLAZADO <> "O" And Sigue Then
                Try
                    SiOk = True
                    If SiOk Then
                        CADENA_CANC = ""
                        TIP_DOC_SIG = "C"
                        If TIP_DOC_SIG = "F" Then CADENA_CANC = "La Factura"
                        If TIP_DOC_SIG = "V" Then CADENA_CANC = "La Nota"
                        If TIP_DOC_SIG = "R" Then CADENA_CANC = "La Remision"
                        If TIP_DOC_SIG = "P" Then CADENA_CANC = "El Pedido"
                        If TIP_DOC_SIG = "C" Then CADENA_CANC = "La Cotización"
                        MsgBox("El folio " & CVE_DOC & " se le genero " & CADENA_CANC & " " & DOC_SIG & " no se puede cancelar")
                        Exit Sub
                    End If

                Catch ex As Exception
                    BITACORATPV("2740. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2740. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "R" Or TIPO_VENTA_LOCAL = "F" Then
                Try
                    DATO_REGRESADO = ESTA_EL_TICKET_FACTURADO(CVE_DOC)

                    If DATO_REGRESADO.Trim.Length > 0 Then
                        CADENA_CANC = ""
                        If Var10 = "F" Then CADENA_CANC = "la Factura "
                        If Var10 = "V" Then CADENA_CANC = "la Nota "
                        If Var10 = "R" Then CADENA_CANC = "la Remision "
                        If Var10 = "P" Then CADENA_CANC = "el Pedido "
                        If Var10 = "C" Then CADENA_CANC = "la Cotización "
                        If Var10 = "D" Then CADENA_CANC = "la Devolución "
                        MsgBox("El documento " & CVE_DOC & " se le generó " & CADENA_CANC & DATO_REGRESADO & ", no es posible realizar la cancelación")
                        Return
                    End If
                Catch ex As Exception
                    BITACORATPV("2750. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2750. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If MsgBox("Realmente desea cancelar documento " & CVE_DOC & "?", vbYesNo) = vbNo Then
                Exit Sub
            End If
            Try
                If Not Valida_Conexion() Then
                    Return
                End If

                CVE_BITA = GRABA_BITA(CLAVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, "Se cancelo " & CADENA_CANC)

                SQL = "UPDATE FACT" & TIPO_VENTA_LOCAL & Empresa & " SET " &
                  "STATUS = 'C', FECHA_CANCELA = CONVERT(varchar, GETDATE(), 112), ENLAZADO = 'O', TIP_DOC_ANT = '', DOC_ANT = '', " &
                  "CVE_BITA = " & CVE_BITA & " WHERE CVE_DOC = '" & CVE_DOC & "'"
                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                    cmd3.CommandText = SQL
                    returnValue = cmd3.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORATPV("2800. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2800. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            If TIPO_VENTA_LOCAL = "R" And CVE_PEDI = "CARTA PORTE" Then
                '(CLAVE_DOC, NUM_PART, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB4, CAMPLIB5) VALUES ('" &
                'CVE_DOC & " ','" & NUM_PAR & "','" & TONELADAS & "','" & REMISION & "','" & CVE_FOLIO & "','" & UNIDAD & "','" & FECHA & "')"
                Try
                    Dim CVE_FOLIO_CP As String

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT * FROM PAR_FACTR_CLIB" & Empresa & " WHERE CLAVE_DOC = '" & CVE_DOC & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read

                                CVE_FOLIO_CP = dr("CAMPLIB3")

                                Try
                                    SQL = "UPDATE GCCARTA_PORTE SET ST_CARTA_PORTE = 2,  CVE_DOCR = '' WHERE CVE_FOLIO = '" & CVE_FOLIO_CP & "'"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL

                                        returnValue = cmd2.ExecuteNonQuery().ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                Catch ex As Exception
                                    BITACORATPV("2810. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End While
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("2815. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2815. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    SQL = "UPDATE GCORDEN_TRABAJO_EXT SET ESTATUS = 'FINALIZADO', DOC_ANTR = '' WHERE CVE_ORD = '" & CVE_PEDI & "'"
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = SQL
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    BITACORATPV("2820. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2820. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "V" Then
                Try
                    SQL = "DELETE FROM CUEN_M" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                    EXECUTE_QUERY_NET(SQL)

                    SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                    EXECUTE_QUERY_NET(SQL)
                Catch ex As Exception
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            End If

            If TIP_DOC_ANT.Trim.Length > 0 Then
                If Not Valida_Conexion() Then
                    Return
                End If
                Try
                    SQL = "UPDATE FACT" & TIP_DOC_ANT & Empresa & " SET ENLAZADO = 'O', DOC_SIG = '', TIP_DOC_SIG = '' WHERE CVE_DOC = '" & DOC_ANT & "'"
                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                        cmd3.CommandText = SQL
                        returnValue = cmd3.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    BITACORATPV("2825. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("2825. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'PROCESO LIBERAR LOS DOCUMENTOS COTIZACIONES O PEDIDOS
            End If
            Try
                'BITACORA
                SQL = "UPDATE GCTBLCONTROL SET ULT_CVE = (SELECT COALESCE(MAX(CVE_BITA),0) FROM GCBITA) WHERE ID_TABLA = 62"
                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                    cmd3.CommandText = SQL
                    returnValue = cmd3.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                BITACORATPV("2830. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2830. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MsgBox("El documento se cancelo satisfactoriamente")

            Me.Close()

        Catch ex As Exception
            BITACORATPV("2840. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function ESTA_EL_TICKET_FACTURADO(fCVE_DOC As String) As String
        Dim isFac As String = ""
        Var10 = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT STATUS, D.TIP_DOC_E, D.CVE_DOC_E FROM DOCTOSIGF" & Empresa & " D " &
                    "LEFT JOIN FACTF" & Empresa & " F ON F.CVE_DOC = D.CVE_DOC_E " &
                    "WHERE D.CVE_DOC = '" & fCVE_DOC & "' AND D.TIP_DOC_E = 'F'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("STATUS") <> "C" Then
                            isFac = dr("CVE_DOC_E")
                            Var10 = dr("TIP_DOC_E")
                        End If
                    End If
                End Using
            End Using
            Return isFac
        Catch ex As Exception
            BITACORATPV("2870. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2870. " & ex.Message & vbNewLine & ex.StackTrace)
            Return ""
        End Try
    End Function

    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnUnidades_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                TCVE_TIPO.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                    If DESCR.Trim.Length > 0 Then
                        LUnidad.Text = DESCR
                    Else
                        LUnidad.Text = TCVE_UNI.Text
                    End If
                Else
                    MsgBox("Unidad inexistente")
                    LUnidad.Text = ""
                    TCVE_UNI.Text = ""
                    'tCVE_UNI.Select()
                End If
            Else
                LUnidad.Text = ""
            End If
        Catch ex As Exception
            BITACORATPV("2880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var3

                LUnidad.Text = IIf(Var6.Trim.Length = 0, Var3, Var6)
                LUnidad.Tag = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                If TIPO_VENTA_LOCAL <> "F" Then
                    TCVE_TIPO.Focus()
                End If
            End If
        Catch Ex As Exception
            MsgBox("2900. " & Ex.Message & vbNewLine & Ex.StackTrace)
            BITACORATPV("2900. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTipo_Click(sender As Object, e As EventArgs) Handles BtnTipo.Click
        Try
            Var2 = "Tipo Unidad"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TIPO.Text = Var4
                L4.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_TIPO.Focus()
            End If
        Catch Ex As Exception
            MsgBox("2910. " & Ex.Message & vbNewLine & Ex.StackTrace)
            BITACORATPV("2910. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TIPO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TIPO.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnTipo_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Then
                Fg.Row = 1
                Fg.Col = 2
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_, 13)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_TIPO_Validated(sender As Object, e As EventArgs) Handles TCVE_TIPO.Validated
        Try
            If TCVE_TIPO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad", TCVE_TIPO.Text)
                If DESCR <> "" Then
                    If DESCR.Trim.Length > 0 Then
                        L4.Text = DESCR
                    Else
                        L4.Text = TCVE_TIPO.Text
                    End If
                Else
                    MsgBox("Tipo Unidad inexistente")
                    TCVE_TIPO.Text = ""
                    TCVE_TIPO.Select()
                End If
            End If

        Catch ex As Exception
            BITACORATPV("2920. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2920. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_TIPO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_TIPO.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                Fg.Row = 1
                Fg.Col = 2
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_, 9)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub L4_DoubleClick(sender As Object, e As EventArgs) Handles L4.DoubleClick
        Dim FECHAELAB As String, FECHA2 As String, D1 As Date

        Try
            FECHAELAB = F1.Tag.ToString
            D1 = FECHAELAB
            FECHA2 = D1.ToString("yyyyMMdd HH:mm:ss")

        Catch ex As Exception
            BITACORATPV("2930. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarObserPar_Click(sender As Object, e As EventArgs) Handles BarObserPar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 22)
                Var5 = "NUEVO"
                Var6 = "PAR_FACT_CLIB"
                Var7 = "PAR_FACT" & TIPO_VENTA & "_CLIB" & Empresa
                Var20 = Fg.Row

                If DOC_NEW Then
                    Var8 = ""
                Else
                    Var8 = LtCVE_DOC.Text
                End If

                FrmObserYCampLib.ShowDialog()
                Fg(Fg.Row, 22) = Var4
            End If

        Catch ex As Exception
            BITACORATPV("2940. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPrecio.SelectedIndexChanged
        Try
            If TCVE_UNI.Visible Then
                TCVE_UNI.Focus()
            Else
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
                Fg.Focus()
                If Not IsNothing(_myEditor) Then
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2945. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles CboPrecio.KeyDown
        If e.KeyCode = 13 Then
            If CboAlmacen.Visible Then
                CboAlmacen.Focus()
            Else
                If TCVE_UNI.Visible Then
                    TCVE_UNI.Focus()
                Else
                    Try
                        Fg.Row = 1
                        Fg.Col = 2
                        Dim c_ As Integer
                        If Fg.Col = 1 Then
                            c_ = 2
                        Else
                            c_ = Fg.Col
                        End If
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(Fg.Row, c_, 9)
                        End If
                    Catch ex As Exception
                        BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
        End If
    End Sub
    Private Sub CboAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles CboAlmacen.KeyDown
        If e.KeyCode = 13 Then

        End If
    End Sub
    Private Sub CboAlmacen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboAlmacen.PreviewKeyDown


    End Sub
    Private Sub CboPrecio_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboPrecio.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                If CboAlmacen.Visible Then
                    CboAlmacen.Focus()
                Else
                    If TCVE_UNI.Visible Then
                        'TCVE_UNI.Focus()
                    Else
                        Fg.Row = 1
                        Fg.Col = 2
                        Dim c_ As Integer
                        If Fg.Col = 1 Then
                            c_ = 2
                        Else
                            c_ = Fg.Col
                        End If
                        If Not IsNothing(_myEditor) Then
                            _myEditor.StartEditing(Fg.Row, c_, 99)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CboAlmacen_GotFocus(sender As Object, e As EventArgs) Handles CboAlmacen.GotFocus
        CboAlmacen.BackColor = Color.Yellow
    End Sub
    Private Sub CboAlmacen_LostFocus(sender As Object, e As EventArgs) Handles CboAlmacen.LostFocus
        CboAlmacen.BackColor = Control.DefaultBackColor
    End Sub
    Private Sub CboPrecio_GotFocus(sender As Object, e As EventArgs) Handles CboPrecio.GotFocus
        CboPrecio.BackColor = Color.Yellow
    End Sub
    Private Sub CboPrecio_LostFocus(sender As Object, e As EventArgs) Handles CboPrecio.LostFocus
        CboPrecio.BackColor = Control.DefaultBackColor
    End Sub

    Private Sub BtnFactura_Click(sender As Object, e As EventArgs) Handles BtnFactura.Click
        Try
            Var2 = "FACTURAS"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                LtFAC_CVE_DOC.Text = Var4
                LtUUID.Text = BUSCAR_UUID_CARTA_PORTE(Var4)

                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCVE_VEND.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2960. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTimbrarNC_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarKardex_Click(sender As Object, e As EventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 4)

                If Var4.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione una partida que contenga la clave del articulo a consultar el kardex")
                    Return
                End If
                Var5 = ""
                Try
                    Var5 = Fg(Fg.Row, 6)
                Catch ex As Exception
                End Try
                FrmKardex.ShowDialog()
            End If
        Catch ex As Exception
            BITACORATPV("2980. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2980. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnRefreshRegFisc_Click(sender As Object, e As EventArgs) Handles BtnRefreshRegFisc.Click
        Try
            LLENA_CAMPOS(TCLIENTE.Text)
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub CargarRegimenesFiscales()
        Dim lista As New List(Of cRegimenFiscal) From {
            New cRegimenFiscal(1, "601", "General de Ley Personas Morales"),
            New cRegimenFiscal(2, "603", "Personas Morales con Fines no Lucrativos"),
            New cRegimenFiscal(3, "605", "Sueldos y Salarios e Ingresos Asimilados a Salarios"),
            New cRegimenFiscal(4, "606", "Arrendamiento"),
            New cRegimenFiscal(5, "608", "Demás ingresos"),
            New cRegimenFiscal(6, "609", "Consolidación"),
            New cRegimenFiscal(7, "610", "Residentes en el Extranjero sin Establecimiento Permanente en México"),
            New cRegimenFiscal(8, "611", "Ingresos por Dividendos lista.Add(new cRegimenFiscal(socios y accionistas));"),
            New cRegimenFiscal(9, "612", "Personas Físicas con Actividades Empresariales y Profesionales"),
            New cRegimenFiscal(10, "614", "Ingresos por intereses"),
            New cRegimenFiscal(11, "616", "Sin obligaciones fiscales"),
            New cRegimenFiscal(12, "620", "Sociedades Cooperativas de Producción que optan por diferir sus ingresos"),
            New cRegimenFiscal(13, "621", "Incorporación Fiscal"),
            New cRegimenFiscal(14, "622", "Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras"),
            New cRegimenFiscal(15, "623", "Opcional para Grupos de Sociedades"),
            New cRegimenFiscal(16, "624", "Coordinados"),
            New cRegimenFiscal(17, "628", "Hidrocarburos"),
            New cRegimenFiscal(18, "607", "Régimen de Enajenación o Adquisición de Bienes"),
            New cRegimenFiscal(19, "629", "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"),
            New cRegimenFiscal(20, "630", "Enajenación de acciones en bolsa de valores"),
            New cRegimenFiscal(21, "615", "Régimen de los ingresos por obtención de premios")
        }
        cbRegimenesFiscales.DataSource = lista
    End Sub
    Private Sub CargarMonedas()
        Try
            'Me.Id = id
            'Me.MONEDA = MONEDA
            'Me.Descripcion = descripcion
            Dim lista As List(Of cMoneda) = New List(Of cMoneda)()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED 
                    FROM MONED" & Empresa & " WHERE ISNULL(STATUS,'') = 'A' ORDER BY NUM_MONED"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        lista.Add(New cMoneda(dr.ReadNullAsEmptyString("NUM_MONED"), dr.ReadNullAsEmptyString("CVE_MONED"), dr.ReadNullAsEmptyString("DESCR")))
                    End While
                End Using
                cbMoneda.DataSource = lista
            End Using
        Catch SQLex As SqlException
            Dim SSS As SqlError, Sqlcadena As String = ""
            For Each SSS In SQLex.Errors
                Sqlcadena += SSS.Message & vbNewLine
            Next
            BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub CargarMetodosPago()
        Dim Lista As New List(Of cMetodoPago) From {
            New cMetodoPago(1, "PUE", "Pago en una sola exhibición"),
            New cMetodoPago(2, "PIP", "Pago inicial y parcialidades"),
            New cMetodoPago(3, "PPD", "Pago en parcialidades o diferido")
}
        cbMetodoPago.DataSource = Lista
    End Sub
    Private Sub CargarFormasPago()
        Dim lista As New List(Of cFormaPago) From {
            New cFormaPago(1, "01", "Efectivo"),
            New cFormaPago(2, "02", "Cheque nominativo"),
            New cFormaPago(3, "03", "Transferencia electrónica de fondos"),
            New cFormaPago(4, "04", "Tarjeta de crédito"),
            New cFormaPago(5, "05", "Monedero electrónico"),
            New cFormaPago(6, "06", "Dinero electrónico"),
            New cFormaPago(7, "08", "Vales de despensa"),
            New cFormaPago(8, "12", "Dación en pago"),
            New cFormaPago(9, "13", "Pago por subrogación"),
            New cFormaPago(10, "14", "Pago por consignación"),
            New cFormaPago(11, "15", "Condonación"),
            New cFormaPago(12, "17", "Compensación"),
            New cFormaPago(13, "23", "Novación"),
            New cFormaPago(14, "24", "Confusión"),
            New cFormaPago(15, "25", "Remisión de deuda"),
            New cFormaPago(16, "26", "Prescripción o caducidad"),
            New cFormaPago(17, "27", "A satisfacción del acreedor"),
            New cFormaPago(18, "28", "Tarjeta de débito"),
            New cFormaPago(19, "29", "Tarjeta de servicios"),
            New cFormaPago(20, "99", "Por definir")
        }
        cbFormaPago.DataSource = lista
    End Sub
    Private Sub BtnDocRel_Click(sender As Object, e As EventArgs) Handles BtnDocRel.Click
        Dim z As Integer = 0

        Var47 = "FACTURA CFDI"
        Lt2.Visible = False

        FrmCFDIRelacionados.ShowDialog()
        Try
            For k = 0 To aDATA.GetLength(0) - 1
                If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                    If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                        z += 1
                    End If
                End If
            Next
            If z > 0 Then
                Lt2.Visible = True
                Lt2.Text = "Documentos relacionados"
            Else
                Lt2.Text = ""
                Lt2.Visible = False
            End If

        Catch ex As Exception
            BITACORACFDI("850. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                TCVE_OPER.Tag = Var4
                LOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
            Else
                TCVE_OPER.Text = ""
                TCVE_OPER.Tag = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("90. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_OPER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_OPER.PreviewKeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            If e.KeyCode = Keys.F2 Then
                BtnOper_Click(Nothing, Nothing)
                Return
            End If
        End If
    End Sub

    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 And IsNumeric(TCVE_OPER.Text) Then
                Dim DESCR As String, OPER As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then

                    OPER = ""
                    If OPER = "" Then
                        LOper.Text = DESCR
                        Var2 = "" : Var4 = "" : Var5 = ""
                    Else
                        MsgBox("El operador se encuentra asignado en el viaje " & OPER)
                        TCVE_OPER.Text = ""
                        TCVE_OPER.Tag = ""
                        LOper.Text = ""
                        Var2 = "" : Var4 = "" : Var5 = ""
                        TCVE_OPER.Select()
                    End If
                Else
                    MsgBox("Operador inexistente")
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Tag = ""
                    TCVE_OPER.Select()
                End If
            Else
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
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
Public Class MyEditorTPV
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    Private LIN_EN_VTA As String

    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, FLINEA_EN_VENTAS As String)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        LIN_EN_VTA = FLINEA_EN_VENTAS
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        '_owner.Cols(13).EditMask = "999,999,999.99"
        _owner.Cols(13).Format = "###,###,###.##"
    End Sub

    'comenzar a editar: mover a la celda y activar
    'R1
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        'save coordinates of cell being edited
        'guardar las coordenadas de la celda que se está editando
        Dim PRECIO As Single

        If col = 2 And keyRec = 99 Then
            MyBase.Visible = True
            _owner.Select()
            'MoveCursor(Keys.KeyCode)
            _owner.Row = 1
            _owner.Col = 2
            _owner.StartEditing()
            Return
            'End If
        End If
        If col = 2 And keyRec = 133 Then
            MyBase.Visible = True
            _owner.Select()
            MoveCursor(Keys.KeyCode)
            '_owner.Row = 1
            '_owner.Col = 2
            _owner.StartEditing()
            Return
        End If

        If col = 2 And keyRec = 99 Then
            _owner.Select(1, 2)
            _owner.Row = 1
            _owner.Col = 2
            MoveCursor(Keys.Enter)
            _owner.Rows.Count = 2
            Return
        End If
        If col = 2 Or col = 4 Or col = 8 Or col = 13 Then
            If col <> 2 Then
                If Not FgEdit Then
                    _owner.Col = 2

                    FrmTPV.tMagico2.Focus()
                    MyBase.Visible = True
                    '_owner.Select()
                    _owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
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
                If col = 13 Then
                    PRECIO = _owner(row, col).ToString()
                    PRECIO = Math.Round(PRECIO, 4)
                    MyBase.Text = PRECIO
                Else
                    MyBase.Text = _owner(row, col).ToString()
                End If
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
            BITACORATPV("3000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)

        If col = 2 Or col = 4 Or col = 5 Or col = 13 Then
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

        If _col <> 2 Then
            If Not FgEdit Then

                _owner.Col = 2
                FrmTPV.tMagico2.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        Try
            If _col = 2 Then 'cantidad
                Try
                    If Not IsNothing(MyBase.Text) Then
                        If IsNumeric(MyBase.Text) Then
                            Var13 = "SOLOTOTAL"
                            FrmTPV.CALCULAR_IMPORTES(_row, CDec(MyBase.Text))
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("3020. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("3020. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'aqui esta el error
            If _col = 22 Then
                If IsNothing(_owner(_row, 2)) Then
                    MyBase.Visible = True
                    _owner.Select()
                    _owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
                If _owner(_row, _col) = "" Then
                    MyBase.Visible = True
                    Return
                End If
            End If
            If _col = 8 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 2)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = (_owner(_row, 2) * _owner(_row, 13)) - (_owner(_row, 2) * _owner(_row, 13) * MyBase.Text / 100)
                                        _owner(_row, 14) = C1

                                    Catch ex As Exception
                                        _owner(_row, 14) = _owner(_row, 2) * _owner(_row, 13)
                                    End Try
                                    Var13 = "SOLOTOTAL"
                                    FrmTPV.CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("3030. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("3030. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

            End If
            If _col = 13 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 2)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = (_owner(_row, 2) * MyBase.Text) - (_owner(_row, 2) * MyBase.Text * _owner(_row, 8) / 100)
                                        _owner(_row, 14) = C1

                                    Catch ex As Exception
                                        _owner(_row, 14) = _owner(_row, 2) * MyBase.Text
                                    End Try
                                    Var13 = "SOLOTOTAL"
                                    FrmTPV.CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    BITACORATPV("3040. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("3040. " & ex.Message & vbNewLine & ex.StackTrace)
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
            BITACORATPV("3050. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)

        If _col <> 2 Then
            If Not FgEdit Then
                _owner.Col = 2

                FrmTPV.tMagico2.Focus()
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
            Case Keys.F3

                FrmTPV.GRABAR()
            Case Keys.F2
                If _col = 4 Then
                    Try                    'ARTICULOS
                        If TIPO_VENTA = "F" Then
                            Var2 = "FACTURA"
                            Var5 = ""
                        Else
                            Var2 = "Articulo"
                            Var5 = LIN_EN_VTA
                        End If
                        Var4 = "" : Var6 = "" : Var9 = ""

                        FrmSelItem2.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            _owner(_row, 4) = Var4
                            LLENAR_GRID_ARTICULO(Var4)
                            _owner.Col = 13
                        End If
                        Return
                    Catch Ex As Exception
                        BITACORATPV("3060. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("3060. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 13 Then
                    Var22 = 0
                    Var17 = _owner(_row, 4)
                    frmSelPrecio.ShowDialog()
                    If Var22 > 0 Then
                        _owner(_row, 13) = Var22
                    End If
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col


        If col <> 2 Then
            If Not FgEdit Then
                _owner.Col = 2

                FrmTPV.tMagico2.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 2 And key = Keys.Left Then
            FrmTPV.tMagico2.Focus()
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
                    FrmTPV.tMagico2.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 2)) Then
                    If IsNothing(_owner(_row, 4)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 4).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If IsNothing(_owner(_row, 4)) Then
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
                        Case 2
                            If IsNothing(_owner(_row, 2)) Then
                                FrmTPV.tMagico2.Focus()
                            Else
                                If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                   "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                                    _owner.Select(row + 1, 2)
                                Else
                                    FrmTPV.tMagico2.Focus()
                                    _owner.Select(row, 2)
                                End If
                            End If
                        Case 4
                            FrmTPV.tMagico2.Focus()
                        Case 13
                            FrmTPV.tMagico2.Focus()
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
                        Case 2
                            If IsNothing(_owner(_row, 2)) Then
                                If IsNothing(_owner(_row, 4)) Then
                                    If _owner.Rows.Count - 1 <> 1 Then
                                        _owner.RemoveItem(_owner.Row)
                                        row = _owner.Rows.Count - 1
                                    End If
                                    Return
                                Else
                                    If _owner(_row, 4).ToString.Length = 0 Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    End If
                                End If
                            Else
                                If IsNothing(_owner(_row, 4)) Then
                                    If _owner(_row, 2).ToString.Length = 0 Then
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
                            col = 2
                        Case 4
                            col = 2
                        Case 13
                            col = 4
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
                If col <= 13 Then
                    Select Case col
                        Case 2
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 2)) Then
                                FrmTPV.tMagico2.Focus()
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
                            col = 4
                        Case 4
                            If IsNothing(_owner(_row, 2)) Then
                                FrmTPV.tMagico2.Focus()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                FrmTPV.tMagico2.Focus()
                                Return
                            End If
                            col = 13
                        Case 13
                            col = 2
                    End Select
                    'col = col + 1
                    'If col = 2 Or col = 4 Then
                    'col = col + 1
                    'End If
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

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean, Desc1 As Single



        If col <> 2 Then
            If Not FgEdit Then
                _owner.Col = 2

                FrmTPV.tMagico2.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 4 'CVE_ART
                            Dim Descr As String
                            If MyBase.Text.Trim.Length = 0 Then
                                FrmTPV.tMagico2.Focus()
                                Return
                            End If
                            Var9 = "" : Var22 = 0 : Var4 = ""

                            If TIPO_VENTA = "F" Then
                                Descr = BUSCA_CAT("FACTURA", MyBase.Text)
                            Else
                                Descr = BUSCA_CAT("Inven", MyBase.Text)
                            End If
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Articulo inexistente")
                                FrmTPV.tMagico2.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                LLENAR_GRID_ARTICULO(MyBase.Text)
                                Desc1 = 0
                                Try
                                    Desc1 = _owner(_row, 8)
                                Catch ex As Exception
                                End Try
                                Try
                                    If Desc1 = 0 Then
                                        _owner(_row, 8) = Desc1
                                    End If
                                Catch ex As Exception

                                End Try
                                _owner.Col = 13
                                Return
                            End If
                        Case 2
                            If Not IsNothing(_owner(_row, _col)) Then
                                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                    _owner.Row = _row
                                    _owner.Col = col
                                    _owner.Row = _row
                                    _owner.StartEditing()
                                    Return
                                End If
                            End If
                            If MyBase.Text.Trim.Length = 0 Then
                                FrmTPV.tMagico2.Focus()
                                Return
                            End If
                        Case 13

                            If Not IsNothing(_owner(_row, _col)) Then
                                If _owner(_row, _col).ToString.Trim.Length = 0 Then
                                    _owner.Row = _row
                                    _owner.Col = col
                                    _owner.Row = _row
                                    _owner.StartEditing()
                                    Return
                                End If
                            Else
                                '_owner.Select()
                                '_owner.Row = _row
                                '_owner.Col = col
                                '_owner.StartEditing()
                                'Return
                            End If
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 2
                            _owner.Select(row, col + 2)
                        Case 4
                            _owner.Select(row, col + 4)
                        Case 8
                            _owner.Select(row, col + 5)
                        Case 13
                            Try
                                If OBSER_X_PARTIDA = 1 Then
                                    Var4 = _owner(_owner.Row, 22)
                                    Var5 = "NUEVO"
                                    Var6 = "PAR_FACT_CLIB"
                                    Var7 = "PAR_FACT" & TIPO_VENTA & "_CLIB" & Empresa
                                    Var20 = FrmTPV.Fg.Row

                                    If DOC_NEW Then
                                        Var8 = ""
                                    Else
                                        Var8 = FrmTPV.LtCVE_DOC.Text
                                    End If

                                    FrmObserYCampLib.ShowDialog()
                                    If Var4.Trim.Length > 0 Then
                                        _owner(_owner.Row, 22) = Var4
                                    End If
                                End If
                            Catch ex As Exception

                            End Try
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 2)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = (_owner(_row, 2) * MyBase.Text) - (_owner(_row, 2) * MyBase.Text * _owner(_row, 8) / 100)
                                                    _owner(_row, 14) = C1
                                                Catch ex As Exception
                                                    _owner(_row, 14) = _owner(_row, 2) * MyBase.Text
                                                End Try
                                                ' frmTPV.CALCULAR_IMPORTES()
                                            End If
                                        End If
                                    End If
                                End If
                                HayErr = False
                                Try
                                    Var13 = "SOLOTOTAL"
                                    FrmTPV.CALCULAR_IMPORTES()
                                Catch ex As Exception
                                End Try
                                Try
                                    _owner.Select(row + 1, 2)
                                Catch ex As Exception
                                    HayErr = True
                                End Try
                                If HayErr Then
                                    '                                      CANT          ALM        ARTICULO      BOTON        DESCR      UNI_MED        DESC1        IMP1         IMP2         IMP3         IMP4        PRECIO      SUBTOT       CVE_ART
                                    '                           1            2            3            4            5            6           7             8            9           10           11           12           13           14           15 
                                    If FgEdit Then
                                        _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab &
                                                       "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "")
                                        _owner.Select(row + 1, 2)
                                    End If
                                Else
                                    If _owner(row, 2) > 0 And _owner(row, 4).ToString.Trim.Length > 0 Then

                                    End If
                                End If
                            Catch ex As Exception
                                BITACORATPV("3070. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("3070. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    _owner.StartEditing()
                    Return

                Case Else
                    If _col = 2 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If

                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            BITACORATPV("3080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3080. " & ex.Message & vbNewLine & ex.StackTrace)
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
                ULT_COSTO = dr("ULT_COSTO")
                _owner(_row, 4) = dr("CVE_ART")
                _owner(_row, 6) = dr("DESCR")
                _owner(_row, 7) = dr("UNI_MED")
                _owner(_row, 8) = FrmTPV.TDESC.Text
                _owner(_row, 9) = dr("IMPUESTO1") 'IEPS
                _owner(_row, 10) = dr("IMPUESTO2") 'IMPU2
                _owner(_row, 11) = dr("IMPUESTO3") 'IMPU4
                _owner(_row, 12) = dr("IMPUESTO4") 'IVA
                _owner(_row, 27) = dr("CVE_ESQIMPU")
                If _owner(_row, 15) <> fCVE_ART Then
                    'PRECIO = frmTPV.cboPrecio.Items(frmTPV.cboPrecio.SelectedIndex).ToString.Substring(0, 2)
                    Select Case FrmTPV.CboPrecio.Items(FrmTPV.CboPrecio.SelectedIndex).ToString.Substring(0, 2)
                        Case "01"
                            PRECIO = dr("P1")
                        Case "02"
                            PRECIO = dr("P2")
                        Case "03"
                            PRECIO = dr("P3")
                        Case "04"
                            PRECIO = dr("P4")
                        Case "05"
                            PRECIO = dr("P5")
                        Case "06"
                            PRECIO = dr("P6")
                        Case "07"
                            PRECIO = dr("P7")
                        Case "08"
                            PRECIO = dr("P8")
                        Case "09"
                            PRECIO = dr("P9")
                        Case "10"
                            PRECIO = dr("P10")
                        Case "11"
                            PRECIO = dr("P11")
                        Case "12"
                            PRECIO = dr("P12")
                        Case "13"
                            PRECIO = dr("P13")
                        Case "14"
                            PRECIO = dr("P14")
                    End Select
                    _owner(_row, 13) = PRECIO
                Else

                End If
                Try
                    Dim C1 As Decimal
                    '       CANTIDAD                         CANT                     DESC       
                    C1 = (_owner(_row, 2) * PRECIO) - (_owner(_row, 2) * PRECIO * _owner(_row, 8) / 100)
                    _owner(_row, 14) = C1
                Catch ex As Exception
                    _owner(_row, 14) = _owner(_row, 2) * PRECIO
                End Try
                _owner(_row, 15) = fCVE_ART
                Var13 = "SOLOTOTAL"
                FrmTPV.CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("3880. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("3880. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class