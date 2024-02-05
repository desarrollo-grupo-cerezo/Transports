Imports System.Xml
Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class FrmTPV

    Private _c As Comprobante
    Private SERIE_POS As String
    Private LONGITUD As Integer
    Private PRINTDIRECTPV As Integer

    Private FTP_CFDI_DEV As String = ""
    Private gUSUARIO_PAC As String
    Private gPASS_PAC As String
    Private MOSTRAR_LP_PV As Integer
    Private LISTA_PREC_CLIE As String
    Private SEBLOQUEA As String = "N"
    Private MONEDA As String
    Private VALIDAR_EXIST_PED As String
    Private USO_CFDI As String
    Private REG_FISC As String
    Private METODODEPAGO As String
    Private FORMAPAGO As String

    Private DOCUMENT_ENLAZADO As String = ""
    Private TIMBRADO_DEMO As String = "No"
    Private EMISORRFC As String = ""
    Private CVE_ART_NC As String = ""
    Private NUM_CPTO_NC As Integer

    Private OBSER As String = ""
    Private CUADRILLA As String = ""
    Private ENTRA As Boolean = True
    Private MODO_EDIT As String = ""
    Private SE_MODIFICA As Boolean = True
    Private ALTA_CLIENTES As Integer
    Private ALTA_PRODUCTOS As Integer
    Private CAPTURA_PAGO_VENTA As Integer
    Private DOC_ENLAZADO As String = ""
    Private CREDITO As String = ""
    Private INDIRECTOS_X_PARTIDA As Integer = 0

    Private ALMACEN_X_PARTIDA As Integer
    Private IMPUESTOS_X_PARTIDA As Integer
    Private DESC_X_PARTIDA As Integer

    Private BLOQ8 As Boolean = False
    Private BLOQ9 As Boolean = False
    Private BLOQ10 As Boolean = False
    Private BLOQ11 As Boolean = False
    Private BLOQ12 As Boolean = False

    Private C_I_PART_KIT As Integer = 0
    Private BLOQUEAR_PRECIO_PV As Integer = 0
    Private CLIENTE_MOSTRADOR As String = ""
    Private TIPO_VENTA_LOCAL As String
    Private LINEA_EN_VENTAS As String = ""
    Private CANC_ESPECIAL As Integer = 0
    Private FACTURA_DIGITAL As String = ""
    Private TIPO_DOC_ENLAZADO As String = ""
    Private CAMPLIB_OBRA As String = ""
    Private CAMPLIB_OBRA_CUADRILLA As String = ""
    Private CHCAMPOLIB_CUADRILLA As Integer = 0
    Private CUADRILLA_SE_CANCELA As Boolean = False
    Private EXIST_NOT As Boolean = False
    Private COPIAS_TK_NV As Integer
    Private COPIAS_TK_PED As Integer
    Private CVE_ART_P As String
    Private LUUID As String = Guid.NewGuid().ToString("N")

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()

        CARGAR_DATOS1()

        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub FrmTPV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Return
        End If


        Dim ThemeLocal As String
        Try
            Select Case TIPO_VENTA_LOCAL
                Case "V"
                    ThemeLocal = "ShinyBlue"

                Case "C"
                    ThemeLocal = "Violette"
                Case "P"
                    ThemeLocal = "Office2016Black"
                Case "R"
                    ThemeLocal = "GreenHouse"
                Case "D"
                    ThemeLocal = "ExpressionLight"
                Case Else
                    ThemeLocal = "ShinyBlue"
                    'BarraMENU.ForeColor = Color.White
                    BarraMENU.Items(0).ForeColor = Color.White
                    BarraMENU.Items(1).ForeColor = Color.White
                    BarraMENU.Items(2).ForeColor = Color.White
                    BarraMENU.Items(3).ForeColor = Color.White
                    BarraMENU.Items(4).ForeColor = Color.White
                    BarraMENU.Items(5).ForeColor = Color.White
                    BarraMENU.Items(6).ForeColor = Color.White
                    BarraMENU.Items(7).ForeColor = Color.White
            End Select

            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            BarraMENU.BackColor = Color.FromArgb(2, 101, 189)
            Select Case TIPO_VENTA_LOCAL
                Case "V"
                    BarraMENU.Items(0).ForeColor = Color.White
                    BarraMENU.Items(1).ForeColor = Color.White
                    BarraMENU.Items(2).ForeColor = Color.White
                    BarraMENU.Items(3).ForeColor = Color.White
                    BarraMENU.Items(4).ForeColor = Color.White
                    BarraMENU.Items(5).ForeColor = Color.White
                    BarraMENU.Items(6).ForeColor = Color.White
                    BarraMENU.Items(7).ForeColor = Color.White
                Case "C"
                    BarraMENU.BackColor = Color.FromArgb(51, 184, 255)
                Case "P"
                    BarraMENU.BackColor = Color.FromArgb(187, 204, 216)
                Case "R"
                    BarraMENU.BackColor = Color.FromArgb(46, 137, 91)
                Case "D"

                Case Else

            End Select

            Fg.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Fg.Height = Me.Height - Tab1.Top - Tab1.Height - 30 - LtTOTAL.Height - BarraMENU.Height

            Fg.DrawMode = DrawModeEnum.OwnerDraw

            LtTOTAL.Left = Fg.Width - LtTOTAL.Width - 30
            LtTOTAL.Top = Fg.Top + Fg.Height + 10
            Label30.Top = LtTOTAL.Top
            LtDocAnt.Top = LtTOTAL.Top
            LtDocSig.Top = LtTOTAL.Top
            LtFactura.Top = LtTOTAL.Top
            Var46 = ""
            GEN_OC_OT = ""
            TOBRA.Tag = LUUID

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED 
                    FROM MONED" & Empresa & " WHERE STATUS = 'A' AND NOT CVE_MONED IS NULL ORDER BY NUM_MONED"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            CboMoneda.Items.Add(String.Format("{0} | {1} | {2}", dr("NUM_MONED"), dr("CVE_MONED"), dr("DESCR")))
                        End While
                    End Using
                    CboMoneda.SelectedIndex = 0
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            txTC.Value = 1

        Catch ex As Exception
            BITACORATPV("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA = True
    End Sub
    Private Sub FrmTPV_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If pwPoder Then
            BarCancelar.Visible = True

            If CANC_ESPECIAL = 1 Then
                BarCancelar2.Visible = True
                BarCancelar.Visible = False
            Else
                BarCancelar2.Visible = False
                BarCancelar.Visible = True
            End If
        Else
            If pwSupervisor Then
                If CANC_ESPECIAL = 1 Then
                    BarCancelar.Visible = False
                    BarCancelar2.Visible = True
                Else
                    BarCancelar2.Visible = False
                    BarCancelar.Visible = True
                End If
            End If
        End If

        TXTN.BorderColor = System.Drawing.Color.Blue

        If MODO_EDIT = "edit" Then
            Fg.Focus()
        Else
            TCLIENTE.Text = CLIENTE_MOSTRADOR

            If CLIENTE_MOSTRADOR.Trim.Length > 0 Then
                Fg.Focus()
                Fg.Col = 2
                'SendKeys.Send("{ENTER}")
            Else
                TCLIENTE.Focus()
            End If
        End If

        ENTRA = True

        Var2 = ""
        FrmSelFactura.ShowDialog()
        If Var2.Trim.Length > 0 Then

        Else
            Me.Close()
        End If
    End Sub
    Private Sub FrmTPV_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If MODO_EDIT <> "edit" Then
                Dim NumPart As Integer = 0
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 2)) And Not IsNothing(Fg(k, 4)) Then
                        If Fg(k, 2) > 0 And Fg(k, 4).ToString.Trim.Length > 0 Then
                            NumPart += 1
                        End If
                    End If
                Next
                If NumPart > 0 Then
                    If MsgBox("Existen partidas en la venta, Realmente desea salir?", vbYesNo) = vbNo Then
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            BITACORATPV("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_DATOS1()
        Dim Efecto As Boolean

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
                PassData5 = ""
                ReDim aDATA(0, 1)

                For k = 0 To aLIB1.GetLength(0) - 1
                    aLIB1(k, 0) = "--"
                    aLIB1(k, 1) = ""
                Next

                For k = 0 To aLIB2.GetLength(0) - 2
                    For j = 0 To aLIB2.GetLength(0) - 2
                        aLIB2(k, j, 0) = "--"
                        aLIB2(k, j, 1) = ""
                    Next
                Next

            Catch ex As Exception
                BITACORATPV("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

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

            BtnVend.FlatStyle = FlatStyle.Flat
            BtnVend.FlatAppearance.BorderSize = 0

            TIPO_VENTA_LOCAL = TIPO_VENTA

            OBSER_X_PARTIDA = 0
            OBSER_X_DOC = 0
            OBSER = ""
            LtCVE_DOC.Tag = 0
            Ldocu.Tag = ""
            TXTN.ErrorInfo.ShowErrorMessage = False

            CARGA_PARAM_VENTAS()

            CARGA_PARAM_INVENT()  'LEER MULTIALMACEN O o 1  

            CARGA_PARAM_CFDI()

            CARGAR_PARAM_USUARIO()

            'AQUI SONSO
            Fg.Cols(16).Visible = False
            Fg.Cols(17).Visible = False
            Fg.Cols(18).Visible = False
            Fg.Cols(19).Visible = False
            Fg.Cols(20).Visible = False
            Fg.Cols(21).Visible = False
            Fg.Cols(22).Visible = False
            Fg.Cols(23).Visible = False
            Fg.Cols(24).Visible = False
            Fg.Cols(25).Visible = False
            Fg.Cols(26).Visible = False
            Fg.Cols(27).Visible = False
            Fg.Cols(28).Visible = False
            Fg.Cols(29).Visible = False
            Fg.Cols(30).Visible = False
            Fg.Cols(31).Visible = False
            Fg.Cols(32).Visible = False
            Fg.Cols(33).Visible = False
            Fg.Cols(34).Visible = False
            Fg.Cols(35).Visible = False

            If IMPUESTOS_X_PARTIDA = 0 Then
                Fg.Cols(9).Visible = False
                Fg.Cols(10).Visible = False
                Fg.Cols(11).Visible = False
                Fg.Cols(12).Visible = False

                BLOQ9 = True
                BLOQ10 = True
                BLOQ11 = True
                BLOQ12 = True
            Else
                Fg.Cols(9).Visible = True
                Fg.Cols(10).Visible = True
                Fg.Cols(11).Visible = True
                Fg.Cols(12).Visible = True

                BLOQ9 = False
                BLOQ10 = False
                BLOQ11 = False
                BLOQ12 = False
            End If

            If DESC_X_PARTIDA = 1 Then
                Fg.Cols(8).Visible = True
            Else
                Fg.Cols(8).Visible = False
            End If
            'aqui sonso
            Fg.Cols(2).StarWidth = "*" 'CANTIDAD
            Fg.Cols(3).StarWidth = "*" 'ALMACEN
            Fg.Cols(4).StarWidth = "*" 'PRODUCTO
            Fg.Cols(6).StarWidth = "4" 'DESCRIPCION
            Fg.Cols(7).StarWidth = "*" 'UNIDAD
            Fg.Cols(8).StarWidth = "*" 'DESCUENTO
            Fg.Cols(9).StarWidth = "*" 'IEPS
            Fg.Cols(10).StarWidth = "*" 'ISR
            Fg.Cols(11).StarWidth = "*" 'IVA RET
            Fg.Cols(12).StarWidth = "*" 'IVA
            Fg.Cols(13).StarWidth = "*" 'PRECIO
            Fg.Cols(15).StarWidth = "*" 'SUBTOTAL

            Fg.Cols(14).ComboList = "|..."

            If MULTIALMACEN = 0 Then
                CboAlmacen.Enabled = False
                Fg.Cols(3).Visible = False
            Else
                CboAlmacen.Enabled = True
                If ALMACEN_X_PARTIDA = 1 Then
                    Fg.Cols(3).Visible = True
                Else
                    Fg.Cols(3).Visible = False
                End If
            End If

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

            If MOSTRAR_LP_PV = 1 Then
                Fg.Cols(14).Visible = True
            Else
                Fg.Cols(14).Visible = False
            End If

            If CHCAMPOLIB_CUADRILLA = 1 Then
                BarCerrarPedido.Visible = True
                BarReactivarPedido.Visible = True
            Else
                BarCerrarPedido.Visible = False
                BarReactivarPedido.Visible = False
                TOBRA.Visible = False
                LtOb1.Visible = False
                BtnObra.Visible = False
            End If
        Catch ex As Exception
            BITACORATPV("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            'Using cmd As SqlCommand = cnSAE.CreateCommand
            '    SQL = "SELECT SERIE FROM GCUSUARIOS_PARAM WHERE 
            '        UPPER(USUARIO) = '" & USER_GRUPOCE.ToUpper & "' AND TIPO_DOC = '" & TIPO_VENTA_LOCAL & "'"
            '    cmd.CommandText = SQL
            '    Using dr As SqlDataReader = cmd.ExecuteReader
            '        If dr.Read Then
            '            LETRA_VENTA = dr("SERIE")
            '        End If
            '    End Using
            'End Using

            'OBTIENE SERIE DESDE LA TABLA GCUSUARIOS_SERIE TOMANDO EN CUENTA EL USUARIO Y TIPO DE VENTA = CAMPO SERIE_VENTA
            LETRA_VENTA = OBTENER_SERIE_USUARIO_TIPO_VENTA(TIPO_VENTA_LOCAL)

            LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)

            MODO_EDIT = Var11
        Catch ex As Exception
            BITACORATPV("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        If TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "F" Then
            '  Var11
            If MODO_EDIT = "edit" Then
                'LETRA_VENTA = String.Concat(Var12.Where(AddressOf Char.IsLetter))
            End If

            FACTURA_DIGITAL = "Impresión"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT TIPO FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & LETRA_VENTA & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            If dr("TIPO") = "I" Then
                                Ldocu.Tag = "Impresión"
                                FACTURA_DIGITAL = "Impresión"
                            Else
                                Ldocu.Tag = "Digital"
                                FACTURA_DIGITAL = "Digital"
                            End If
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
        BarTimbrarNC.Enabled = False

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

                    If Var18 = "Timbrada" Then
                        BarTimbrarNC.Enabled = False
                        BarObserDoc.Enabled = False
                        BarObserPar.Enabled = False

                    End If

                    If CVE_ART_NC.Trim.Length = 0 Then
                        MsgBox("Por favor capture la clave del articulo para notas de crédito en parámetros-configuración CFDI")
                    End If
                End If
        End Select

        Try
            If Encriptar(PASS_GRUPOCE.ToUpper) = "LEWxrrg5GxY=" Then
                'Fg.Cols(9).Visible = True
                'Fg.Cols(10).Visible = True
                'Fg.Cols(11).Visible = True
                'Fg.Cols(12).Visible = True

                'Fg.Cols(15).Visible = True
                'Fg.Cols(16).Visible = True
                'Fg.Cols(17).Visible = True
                'Fg.Cols(18).Visible = True

                'Fg.Cols(18).Visible = True
                'Fg.Cols(19).Visible = True
                'Fg.Cols(20).Visible = True
            Else
                'Fg.Cols(9).Visible = True
                'Fg.Cols(10).Visible = True
                'Fg.Cols(11).Visible = True
                'Fg.Cols(12).Visible = True
                'Fg.Cols(15).Visible = False
                'Fg.Cols(16).Visible = False
                'Fg.Cols(17).Visible = False
                'Fg.Cols(18).Visible = False
                'Fg.Cols(19).Visible = False
                'Fg.Cols(20).Visible = False
                'Fg.Cols(21).Visible = False
                'Fg.Cols(22).Visible = False
                'Fg.Cols(23).Visible = False
                'Fg.Cols(24).Visible = False
                'Fg.Cols(25).Visible = False
                'Fg.Cols(26).Visible = False
                'Fg.Cols(27).Visible = False
                'Fg.Cols(28).Visible = False
                'Fg.Cols(29).Visible = False
            End If
        Catch ex As Exception
            BITACORATPV("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            Do While dr.Read
                CboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                CboALmacenFG.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
            Loop
            dr.Close()
            CboAlmacen.SelectedIndex = 0
            CboALmacenFG.SelectedIndex = 0
        Catch ex As Exception
            BITACORATPV("45. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Dim s As String, CADENA_ALM As String = ""

        Fg.Rows.Count = 1
        If ALMACEN_X_PARTIDA = 1 Then
            If CboAlmacen.SelectedIndex > -1 Then
                CADENA_ALM = CboAlmacen.Text
            End If
        End If

        ENTRA = True
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

        SQL = "DELETE FROM GCLIB_PAR_P"
        ReturnBool = EXECUTE_QUERY_NET(SQL)

        SQL = "DELETE FROM GCLIB_FACTP"
        ReturnBool = EXECUTE_QUERY_NET(SQL)

        Try
            FgEdit = True
            Select Case MODO_EDIT
                Case "edit"

                    DOC_NEW = False
                    LtCVE_DOC.Text = Var12
                    Fg.Rows.Count = 1


                    SEBLOQUEA = "N"

                    BUSCAR_VENTA(TIPO_VENTA_LOCAL, Var12)

                    Fg.Cols(8).Visible = True : Fg.Cols(13).Visible = True : Fg.Cols(15).Visible = True
                    F1.Enabled = False
                    'DOCUMENTO ANTERIOR
                    If IsNothing(Var16) Then Var16 = ""
                    'Fg.Cols(23).Visible = False

                    If CHCAMPOLIB_CUADRILLA = 0 Then
                        SEBLOQUEA = "N"
                    End If

                    If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "R" Then
                        SE_MODIFICA = False
                        Efecto = False
                    Else
                        If LtDocAnt.Text.Trim.Length > 0 Then
                            If CHCAMPOLIB_CUADRILLA = 0 Then
                                SE_MODIFICA = False
                                Efecto = False
                            Else
                                If SEBLOQUEA = "S" Then
                                    SE_MODIFICA = False
                                Else
                                    SE_MODIFICA = True
                                    Efecto = True
                                End If
                            End If
                        Else
                            If TIPO_VENTA_LOCAL = "C" Or TIPO_VENTA_LOCAL = "P" Then
                                If CHCAMPOLIB_CUADRILLA = 0 Then
                                    SE_MODIFICA = True
                                    Efecto = True
                                Else
                                    If SEBLOQUEA = "S" Then
                                        SE_MODIFICA = False
                                        Efecto = False
                                    Else
                                        SE_MODIFICA = True
                                        Efecto = True
                                    End If
                                End If
                            End If
                        End If
                    End If

                    TCLIENTE.Enabled = Efecto
                    BarGrabar.Enabled = Efecto
                    TCVE_PEDI.Enabled = Efecto : TCVE_VEND.Enabled = Efecto : BtnVend.Enabled = Efecto : btnEsquema.Enabled = Efecto : TDESC.Enabled = Efecto
                    tDesFin.Enabled = Efecto : tEntregarEn.Enabled = True : tEsquema.Enabled = Efecto
                    BarEliminar.Enabled = Efecto : BarSerie.Enabled = Efecto
                    BarAltaProv.Enabled = Efecto : BarAltaArticulo.Enabled = Efecto : BarEnlaceDocumento.Enabled = Efecto : BtnClie.Enabled = Efecto
                    BarLimpiar.Enabled = Efecto : FgEdit = Efecto : BarSerie.Enabled = False
                    Fg.Enabled = True

                    If Var18 = "Timbrada" Then
                        BarTimbrarNC.Enabled = False
                        BarObserDoc.Enabled = False
                        BarObserPar.Enabled = False
                    Else
                        BarObserDoc.Enabled = True : BarObserPar.Enabled = True
                    End If

                    Label30.Visible = Efecto
                    LtDocAnt.Visible = Efecto
                    tCONDICION.Enabled = Efecto


                    Fg.Cols(1).Visible = False
                    Fg(0, 2) = "Cantidad"
                Case Else

                    SE_MODIFICA = True
                    DOC_NEW = True : TCLIENTE.Enabled = True : TCVE_PEDI.Enabled = True : TCVE_VEND.Enabled = True : BtnVend.Enabled = True
                    btnEsquema.Enabled = True : TDESC.Enabled = True : tDesFin.Enabled = True : tEntregarEn.Enabled = True
                    tEsquema.Enabled = True : Fg.Enabled = True : CboTipoVenta.Enabled = True : F1.Enabled = False : BarGrabar.Enabled = True
                    BarEliminar.Enabled = True : BarObserDoc.Enabled = True : BarSerie.Enabled = True : BarAltaProv.Enabled = True : BarAltaArticulo.Enabled = True
                    BarTimbrarNC.Enabled = False

                    Fg.Cols(1).Visible = False
                    Fg(0, 2) = "Cantidad"

                    LLENAR_CAMPOS_LIBRES(TIPO_VENTA_LOCAL, LUUID)
            End Select
            tEntregarEn.Visible = False
            btnEntregarEn.Visible = False
            LEntregarEn.Visible = False


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

                If CHCAMPOLIB_CUADRILLA = 0 Then
                    TOBRA.Visible = False
                    LtObra.Visible = False
                    LtOb1.Visible = False
                Else
                    F1.Enabled = True
                End If

            Catch ex As Exception
                BITACORATPV("55. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If MODO_EDIT = "edit" Then
                If (TIPO_VENTA_LOCAL = "C" Or TIPO_VENTA_LOCAL = "R" Or TIPO_VENTA_LOCAL = "P") And SE_MODIFICA Then

                Else
                    Fg.AllowEditing = False
                End If
                TCLIENTE.Select()
            Else
                Fg.Focus()
            End If
            LtVenta.Left = Me.Width - LtVenta.Width - 20

            ENTRA = True


            If SE_MODIFICA Then
                '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                '   1            2            3            4            5            6            7            8            9           10
                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART         1            2        NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                '    11           12           13           14           15           16           17           18           19           20           21
                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       REG_LTPD      CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                '    22          23           24           25           26           27           28           29           30          31
                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab
                '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                '   32           33          34           35

                Fg.AddItem("" & vbTab & s)

                Fg.Row = Fg.Rows.Count - 1
                Fg(Fg.Row, 3) = CADENA_ALM

                Fg.Col = 2
                'SendKeys.Send("{ENTER}")
            Else
                Fg.Col = 2
            End If

        Catch ex As Exception
            BITACORATPV("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CargarUsosCfdi()
        Try
            cbUsoCfdi.Items.Clear()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT id, usoCfdi, descripcion FROM tblcusocfdi "
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        cbUsoCfdi.Items.Add(dr("usoCfdi") & " " & dr("descripcion"))
                    End While
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

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
                SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND 
                    CLAVE > 50500 AND CLAVE <= 61500"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Select Case dr("CLAVE")
                                Case 61400, 60560, 60160
                                    BarExcel.Visible = True
                                Case 61450, 50590, 60190
                                    BarCancelar.Visible = True
                                Case 61300, 60620, 60220
                                    BarImprimir.Visible = True
                                Case 61500, 60650, 60250
                                    BarEnlaceDocumento.Visible = True
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

        VALIDAR_EXIST_PED = 0

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(CAPTURA_PAGO_VENTAS, 0) AS C_PAGO_VENTAS, ISNULL(C_ALTA_CLIENTES, 0) AS ALTA_CLIENTES,
                ISNULL(C_ALTA_PRODUCTOS, 0) AS ALTA_PRODUCTOS, ISNULL(OBSER_X_DOC, 0) AS OBS_X_DOC,
                ISNULL(OBSER_X_PARTIDA, 0) AS OBSER_X_PARTIDA, ISNULL(INDIRECTOS_X_PARTIDA, 0) AS INDIRECTOS_X_PARTIDA,
                ISNULL(IMPUESTOS, 0) AS C_IMPUESTOS, ISNULL(ALMACEN, 0) AS C_ALMACEN, ISNULL(IMP_PART_KIT,0) AS I_PART_KIT,
                ISNULL(BLOQUEAR_PRECIO_PV,0) AS BLOQ_PREC, ISNULL(LINEA_EN_VENTAS,'') AS LIN_VTA, CAMPLIB_OBRA,
                CAMPLIB_OBRA_CUADRILLA, CHCAMPOLIB_CUADRILLA, VALIDAR_EXIST_PED, DESC_X_PARTIDA, ISNULL(CLIE_MOSTR,'') AS CLI_MOST,
                COPIAS_TK_NV, COPIAS_TK_PED, ISNULL(MOSTRAR_LP_PV,0) AS MOS_LP_PV
                FROM GCPARAMVENTAS"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                CAPTURA_PAGO_VENTA = dr("C_PAGO_VENTAS")
                ALTA_CLIENTES = dr("ALTA_CLIENTES")
                ALTA_PRODUCTOS = dr("ALTA_PRODUCTOS")
                OBSER_X_PARTIDA = dr("OBSER_X_PARTIDA")
                OBSER_X_DOC = dr("OBS_X_DOC")

                'ChINDIRECTOS_X_PARTIDA.Value = dr("IND_X_PAR")
                'ChIMPUESTOS.Value = dr("C_IMP") 'IMPUESTOS X PARTIDA
                'ChALMACEN.Value = dr("C_ALM") 'ALMACEN POR PARTIDA

                INDIRECTOS_X_PARTIDA = dr("INDIRECTOS_X_PARTIDA")

                IMPUESTOS_X_PARTIDA = dr("C_IMPUESTOS") 'IMPUESTOS X PARTIDA
                ALMACEN_X_PARTIDA = dr("C_ALMACEN") 'ALMACEN POR PARTIDA
                DESC_X_PARTIDA = dr.ReadNullAsEmptyInteger("DESC_X_PARTIDA")

                C_I_PART_KIT = dr("I_PART_KIT")
                BLOQUEAR_PRECIO_PV = dr("BLOQ_PREC")
                LINEA_EN_VENTAS = dr("LIN_VTA")
                CAMPLIB_OBRA = dr.ReadNullAsEmptyString("CAMPLIB_OBRA")
                CAMPLIB_OBRA_CUADRILLA = dr.ReadNullAsEmptyString("CAMPLIB_OBRA_CUADRILLA")
                CHCAMPOLIB_CUADRILLA = dr.ReadNullAsEmptyInteger("CHCAMPOLIB_CUADRILLA")
                Var45 = CHCAMPOLIB_CUADRILLA
                OT_EXT = CHCAMPOLIB_CUADRILLA
                CLIENTE_MOSTRADOR = dr("CLI_MOST")
                'VALIDAR_EXIST_PED = dr.ReadNullAsEmptyInteger("VALIDAR_EXIST_PED")
                COPIAS_TK_NV = dr.ReadNullAsEmptyInteger("COPIAS_TK_NV") + 1
                COPIAS_TK_PED = dr.ReadNullAsEmptyInteger("COPIAS_TK_PED") + 1
                MOSTRAR_LP_PV = dr("MOS_LP_PV")

                'IMPU_FISICA_A_SA = dr.ReadNullAsEmptyInteger("IMPU_FISICA_A_SA")
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
            If IMPUESTOS_X_PARTIDA = 0 Then
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
            If ALMACEN_X_PARTIDA = 0 Then
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
    Sub CARGAR_PARAM_USUARIO()
        Try
            CANC_ESPECIAL = 0

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(CANC_ESPECIAL,0) AS CANC_ESP, PRINTDIRECTPV FROM GCUSUARIOS_GEN WHERE USUARIO = '" & USER_GRUPOCE & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CANC_ESPECIAL = dr("CANC_ESP")
                        PRINTDIRECTPV = dr.ReadNullAsEmptyInteger("PRINTDIRECTPV")
                    End If
                End Using
            End Using

            '=============================================================================================================
            'SE AGREGO PARA OBSTENER EL FORMATO Y LA SERIE DEL USUARIO
            '15 SEPTIEMBRE 2023

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT SERIE FROM GCUSUARIOS_PARAM WHERE 
                    UPPER(USUARIO) = '" & USER_GRUPOCE & "' AND TIPO_DOC = '" & TIPO_VENTA_LOCAL & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        SERIE_POS = dr("SERIE")
                    End If
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT LONGITUD, FTOEMISION
                    FROM PARAM_FOLIOSF" & Empresa & " 
                    WHERE TIPODOCTO = '" & TIPO_VENTA_LOCAL & "' AND SERIE = '" & SERIE_POS & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LONGITUD = dr("LONGITUD")
                        REPORTE_POS = dr("FTOEMISION")
                    End If
                End Using
            End Using

            Me.DialogResult = DialogResult.OK
            Connect = "Si"

            If REPORTE_POS.Trim.Length = 0 Then
                REPORTE_POS = "TicketEstandard.mrt"
            End If

        Catch ex As Exception
            BITACORATPV("75. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub CARGA_PARAM_CFDI()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            CVE_ART_NC = ""

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(CVE_ART_NC,'') AS ART_NC, NUM_CPTO_NC FROM CFDI_CFG"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                NUM_CPTO_NC = dr.ReadNullAsEmptyInteger("NUM_CPTO_NC")
                CVE_ART_NC = dr.ReadNullAsEmptyString("ART_NC")
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("75. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Sub CARGA_PARAM_INVENT()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            CVE_ART_NC = ""

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
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

            DOCUMENT_ENLAZADO = ""
            TIPO_DOC_ENLAZADO = ""
            DOC_ENLAZADO = "N"

            Select Case TIPO_VENTA_LOCAL
                Case "F"
                    Var15 = "V"
                Case "D"
                    Var15 = "F"
                Case "V"
                    Var15 = "C"
                Case "R"
                    Var15 = "P"
            End Select

            If CHCAMPOLIB_CUADRILLA = 1 Then
                Var28 = "COILSA"
                Var15 = "P"
                If TIPO_VENTA_LOCAL = "P" Then
                    MsgBox("Esta usted intentando enlazar un pedido sobre un pedido, verifique por favor")
                    Return
                End If

            End If

            FrmEnlaceVentasGen.ShowDialog()
            If aDOCS.Length > 0 Then

                ENTRA = False
                LIMPIAR()

                DOCUMENT_ENLAZADO = Var15

                Fg.Rows.Count = 1
                For k = 0 To aDOCS.Length - 1
                    CVE_DOC = aDOCS(k)

                    If CVE_DOC.Trim.Length > 0 Then
                        If TIPO_VENTA_LOCAL = "D" Then
                            '          FACTURA   DOCUMENT DOCUMENT2      
                            'BUSCAR_CFDI(CVE_DOC, Var5, Var6)
                            BUSCAR_VENTA(Var15, CVE_DOC)
                        Else
                            BUSCAR_VENTA(Var15, CVE_DOC)
                        End If
                        DOC_ENLAZADO = "S"
                    End If
                Next
                Try
                    LtDocAnt.Text = aDOCS(0)
                Catch ex As Exception
                End Try
                Dim s As String

                '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                '   1            2            3            4            5            6            7            8            9           10
                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART         1            2        NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                '    11           12           13           14           15           16           17           18           19           20           21
                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       REG_LTPD      CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                '    22          23           24           25           26           27           28           29           30          31
                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab
                '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                '   32           33          34           35


                Fg.AddItem("" & vbTab & s)

                Fg.Focus()
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 2
                ENTRA = True
            End If
        Catch ex As Exception
            BITACORATPV("80. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub BUSCAR_VENTA(fTIPOC As String, fCVE_DOC As String)
        Dim PREC As Single, NUM_ALM As Integer, IMPU As Single, cIEPS As Single, cIMPU As Single
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, CLIENTE As String
        Dim IVA2 As Decimal, IVA3 As Decimal, Efecto As Boolean, MONTO_REMISIONADO As Decimal = 0
        Dim DESCP As Single, DESCP2 As Single, PrecioVenta As Single, Sigue As Boolean = True, s As String, j As Integer
        Dim CADENA As String, MONTO_OBTENIDO As Decimal = 0, CADENA_ALM As String = ""

        If Not Valida_Conexion() Then
            Return
        End If

        With Fg
            Dim NewStyle1 As C1.Win.C1FlexGrid.CellStyle
            NewStyle1 = .Styles.Add("NewStyle1")
            NewStyle1.BackColor = System.Drawing.Color.Blue
            .SetCellStyle(0, 0, NewStyle1)
        End With

        Dim CustomStyle As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add("CustomStyle")
        CustomStyle.BackColor = Color.Orange
        'LtCVE_DOC.Tag = 0
        'LtCVE_DOC.Text = fCVE_DOC
        OBSER = ""

        SQL = "DELETE FROM GCLIB_PAR_P"
        ReturnBool = EXECUTE_QUERY_NET(SQL)

        SQL = "DELETE FROM GCLIB_FACTP"
        ReturnBool = EXECUTE_QUERY_NET(SQL)

        Try

            If CHCAMPOLIB_CUADRILLA = 0 Then
                SQL = "Select F.TIP_DOC, P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, 
                    UNI_VENTA, EXIST, ISNULL(ULT_COSTO, 0) As ULTCOSTO, ISNULL(COSTO_PROM, 0) As COSTOPROM, NUM_PAR, COST, 
                    PXS As P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM, 1) As NUMALM, ISNULL(P.DESC1, 0) As D1, ISNULL(I.LIN_PROD,'') AS LINEA, 
                    ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, 
                    C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,
                    ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, ISNULL(F.CVE_OBS, 0) As CVE_OBS_DOC, 
                    ISNULL(P.CVE_OBS, 0) As CVE_OBS_PAR, ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG,
                    DOC_SIG, ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, F.STATUS, P.CVE_ESQ, ISNULL(P.FACTURA_CIERRE,'') AS FAC_CIERRE,
                    ISNULL(I.CON_LOTE,'') AS CONLOTE, P.CVE_ESQ, F.FORMADEPAGOSAT, F.METODODEPAGO, F.SERIE, TIP_DOC_ANT, DOC_ANT,
                    P.DESC3 AS MONTO_REMISIONADO, CAN_TOT, IMPORTE
                    From PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                    LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                    LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                    LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                    LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                    LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                    LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                    LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = P.CVE_ESQ
                    WHERE P.CVE_DOC = '" & fCVE_DOC & "'"

                SQL2 = SQL
            Else
                If fTIPOC = "P" Then
                    If TIPO_VENTA_LOCAL = "R" Then
                        CADENA = " AND PREC > 0 "
                    Else
                        CADENA = ""
                    End If


                    SQL = "Select F.TIP_DOC, P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, 
                        UNI_VENTA, EXIST, ISNULL(ULT_COSTO, 0) As ULTCOSTO, ISNULL(COSTO_PROM, 0) As COSTOPROM, NUM_PAR, COST, 
                        PXS As P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM, 1) As NUMALM, ISNULL(P.DESC1, 0) As D1, ISNULL(I.LIN_PROD,'') AS LINEA, 
                        ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, 
                        C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,
                        ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, ISNULL(F.CVE_OBS, 0) As CVE_OBS_DOC, 
                        ISNULL(P.CVE_OBS, 0) As CVE_OBS_PAR, ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG,
                        DOC_SIG, ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, F.STATUS, P.CVE_ESQ, ISNULL(P.FACTURA_CIERRE,'') AS FAC_CIERRE,
                        ISNULL(I.CON_LOTE,'') AS CONLOTE, P.CVE_ESQ, F.FORMADEPAGOSAT, F.METODODEPAGO, F.SERIE, TIP_DOC_ANT, DOC_ANT,
                        BLOQUEAR, TOT_PARTIDA, CAN_TOT, IMPORTE
                        From PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                        LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                        LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                        LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = P.CVE_ESQ
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "' " & CADENA & " ORDER BY NUM_PAR"

                    SQL2 = SQL
                Else
                    SQL = "Select F.TIP_DOC, P.CVE_ART, CANT, I.DESCR, P.DESC1, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, 
                        COST, UNI_VENTA, EXIST, ISNULL(ULT_COSTO, 0) As ULTCOSTO, ISNULL(COSTO_PROM, 0) As COSTOPROM, NUM_PAR, 
                        PXS As P_X_S, P.CVE_DOC, ISNULL(P.NUM_ALM, 1) As NUMALM, ISNULL(P.DESC1, 0) As D1, ISNULL(I.LIN_PROD,'') AS LINEA, 
                        ISNULL(F.CVE_VEND,'') AS VEND, ISNULL(CONDICION,'') AS CONDI, F.FECHA_DOC, F.FECHAELAB, F.CVE_CLPV, C.NOMBRE, 
                        C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, C.MUNICIPIO, C.ESTADO, ISNULL(I.TIPO_ELE,'') AS TIPOELE,
                        ISNULL(CVE_PEDI,'') AS PEDI, ISNULL(INF.NOMBRE,'') AS INF_NOMBRE, ISNULL(F.CVE_OBS, 0) As CVE_OBS_DOC, 
                        ISNULL(P.CVE_OBS, 0) As CVE_OBS_PAR, ISNULL(OD.STR_OBS,'') AS DOC_OBS, ISNULL(OP.STR_OBS,'') AS PAR_OBS, TIP_DOC_SIG,
                        DOC_SIG, ISNULL(ENLAZADO,'') AS ENLAZADO_DOC, F.STATUS, P.CVE_ESQ, ISNULL(P.FACTURA_CIERRE,'') AS FAC_CIERRE,
                        ISNULL(I.CON_LOTE,'') AS CONLOTE, P.CVE_ESQ, F.FORMADEPAGOSAT, F.METODODEPAGO, F.SERIE, TIP_DOC_ANT, DOC_ANT,
                        ISNULL((SELECT SUM(CAN_TOT) FROM FACTR" & Empresa & " WHERE DOC_ANT = P.CVE_DOC),0) AS MONTO_REMISIONADO,
                        ISNULL((SELECT SUM(CAN_TOT) FROM FACTP" & Empresa & " WHERE CVE_DOC = F.DOC_SIG),0) AS IMPORTE_PEDIDO,
                        TOT_PARTIDA, CAN_TOT, IMPORTE
                        From PAR_FACT" & fTIPOC.ToUpper & Empresa & " P
                        LEFT JOIN FACT" & fTIPOC.ToUpper & Empresa & " F ON F.CVE_DOC = P.CVE_DOC
                        LEFT JOIN OBS_DOCF" & Empresa & " OD ON OD.CVE_OBS = F.CVE_OBS
                        LEFT JOIN OBS_DOCF" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS
                        LEFT JOIN INFENVIO" & Empresa & " INF ON INF.CVE_INFO = F.DAT_MOSTR
                        LEFT JOIN CLIE" & Empresa & " C On C.CLAVE = F.CVE_CLPV
                        LEFT JOIN INVE" & Empresa & " I On I.CVE_ART = P.CVE_ART
                        LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = P.CVE_ESQ
                        WHERE P.CVE_DOC = '" & fCVE_DOC & "' ORDER BY NUM_PAR"
                End If
            End If
            SQL2 = SQL

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            If Sigue Then
                                Try
                                    TIPO_DOC_ENLAZADO = dr("TIP_DOC")
                                    If dr("STATUS") = "C" Then
                                        LtCanc.Visible = True
                                    Else
                                        LtCanc.Visible = False
                                    End If
                                    CLIENTE = dr("CVE_CLPV")
                                    TCLIENTE.Text = CLIENTE

                                    TCVE_PEDI.Text = dr("PEDI")
                                    TCVE_PEDI.Tag = dr("ENLAZADO_DOC")

                                    If TCVE_PEDI.Text.Trim.Length > 0 Then
                                        If fTIPOC.ToUpper = "R" Then
                                            Label30.Visible = True
                                            LtDocAnt.Visible = True

                                            Label30.Text = "Remisión enlazada"
                                            LtDocAnt.Text = TCVE_PEDI.Text
                                        End If
                                    End If

                                    If dr.ReadNullAsEmptyString("TIP_DOC_ANT").ToString.Trim.Length > 0 Then
                                        Label30.Text = "Doc. enlazado"
                                        LtDocAnt.Text = dr("DOC_ANT")
                                    Else
                                        If dr.ReadNullAsEmptyString("DOC_SIG").ToString.Length > 0 Then
                                            Label30.Text = "Doc. enlazado"
                                            LtDocAnt.Text = dr("DOC_SIG")
                                        Else
                                            Label30.Text = ""
                                            LtDocAnt.Text = ""
                                        End If
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

                                    If CHCAMPOLIB_CUADRILLA = 1 And fTIPOC = "P" Then
                                        SEBLOQUEA = dr.ReadNullAsEmptyString("BLOQUEAR")
                                    Else
                                        SEBLOQUEA = "N"
                                    End If

                                    Try
                                        OBSER = dr("DOC_OBS")
                                        Dim TIPO_SERIE As String = ""
                                        Try
                                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "SELECT TIPO FROM FOLIOSF" & Empresa & " WHERE SERIE = '" & dr("SERIE") & "' AND TIP_DOC = '" & fTIPOC.ToUpper & "'"
                                                cmd2.CommandText = SQL
                                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                    If dr2.Read Then
                                                        TIPO_SERIE = dr2.ReadNullAsEmptyString("TIPO")
                                                    End If
                                                End Using
                                            End Using
                                        Catch ex As Exception
                                            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                        End Try


                                        If TIPO_SERIE = "D" Then

                                            Ldocu.Tag = "Digital"
                                            FACTURA_DIGITAL = "Digital"

                                            CargarUsosCfdi()
                                            CargarRegimenesFiscales()
                                            CargarMonedas()
                                            CargarMetodosPago()
                                            CargarFormasPago()
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

                                Try
                                    F1.Value = dr("FECHA_DOC")
                                    F1.Tag = dr("FECHAELAB")
                                Catch ex As Exception
                                End Try
                                Try
                                    If MULTIALMACEN = 1 Then
                                        CboAlmacen.SelectedIndex = 0
                                        For k = 0 To CboAlmacen.Items.Count - 1
                                            If Val(CboAlmacen.Items(k).ToString.Substring(0, 2)) = NUM_ALM Then
                                                CboAlmacen.SelectedIndex = k
                                                CADENA_ALM = CboAlmacen.Items(k).ToString
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        CboAlmacen.SelectedIndex = 0
                                    End If

                                    tEntregarEn.Text = dr("INF_NOMBRE")
                                    TDESC.Value = dr("D1")
                                    TCVE_VEND.Text = dr("VEND")
                                    FORMAPAGO = dr("FORMADEPAGOSAT")
                                Catch ex As Exception
                                    BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                Try
                                    If dr("FORMADEPAGOSAT").ToString.Trim.Length > 0 Then
                                        cbFormaPago.SelectedIndex = 0
                                        For k = 0 To cbFormaPago.Items.Count - 1
                                            cbFormaPago.SelectedIndex = k
                                            If (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago = dr("FORMADEPAGOSAT") Then
                                                cbFormaPago.SelectedIndex = k
                                                LtFormaPagoSat.Text = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If cbFormaPago.SelectedIndex > -1 Then
                                            cbFormaPago.SelectedIndex = 0
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                'Private USO_CFDI As String
                                'Private REG_FISC As String
                                'Private METODODEPAGO As String
                                'Private FORMAPAGO As String

                                Try
                                    METODODEPAGO = dr("METODODEPAGO")
                                    If dr("METODODEPAGO").ToString.Trim.Length > 0 Then
                                        If cbMetodoPago.SelectedIndex > -1 Then
                                            cbMetodoPago.SelectedIndex = 0
                                        End If
                                        For k = 0 To cbMetodoPago.Items.Count - 1
                                            If (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago = dr("METODODEPAGO") Then
                                                cbMetodoPago.SelectedIndex = k
                                                LtMetodoPago.Text = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
                                                Exit For
                                            End If
                                        Next
                                    Else
                                        If cbMetodoPago.SelectedIndex > -1 Then
                                            cbMetodoPago.SelectedIndex = 0
                                        End If
                                    End If
                                Catch ex As Exception
                                    BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                Sigue = False
                            End If

                            If CHCAMPOLIB_CUADRILLA = 1 Then
                                If TIPO_VENTA_LOCAL = "R" Then
                                    Try
                                        Dim PART_E As Integer = 0, REMA As String
                                        MONTO_OBTENIDO = 0

                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            SQL = "SELECT CVE_DOC_E, PART_E FROM DOCTOSIGF" & Empresa & " 
                                                WHERE CVE_DOC = '" & fCVE_DOC & "' AND ANT_SIG = 'S' AND PARTIDA = " & dr("NUM_PAR")
                                            cmd2.CommandText = SQL
                                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                                While dr2.Read

                                                    REMA = dr2("CVE_DOC_E")
                                                    PART_E = dr2("PART_E")

                                                    SQL = "SELECT TOT_PARTIDA FROM PAR_FACTR" & Empresa & " P2 
                                                        LEFT JOIN FACTR" & Empresa & " F2 ON F2.CVE_DOC = P2.CVE_DOC 
                                                        WHERE F2.CVE_DOC = '" & REMA & "' AND P2.CVE_ART = '" & dr("CVE_ART") & "' AND P2.NUM_PAR = " & PART_E
                                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                        cmd3.CommandText = SQL
                                                        Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                                            If dr3.Read Then
                                                                MONTO_OBTENIDO += dr3("TOT_PARTIDA")
                                                            End If
                                                        End Using
                                                    End Using

                                                End While
                                            End Using
                                        End Using

                                        If CHCAMPOLIB_CUADRILLA = 0 Then
                                            PREC = dr("PREC")
                                            PREC = Math.Round(PREC, 6)
                                        Else
                                            If TIPO_VENTA_LOCAL = "R" Then
                                                If MONTO_OBTENIDO > 0 Then
                                                    If dr("TOT_PARTIDA") - MONTO_OBTENIDO >= 0 Then
                                                        MONTO_REMISIONADO = dr("TOT_PARTIDA") - MONTO_OBTENIDO
                                                        PREC = MONTO_REMISIONADO
                                                    Else
                                                        MONTO_REMISIONADO = MONTO_OBTENIDO
                                                        PREC = Math.Round(MONTO_REMISIONADO, 6)
                                                    End If
                                                Else
                                                    PREC = dr("PREC")
                                                    PREC = Math.Round(PREC, 6)
                                                End If
                                            Else
                                                PREC = dr("PREC")
                                                PREC = Math.Round(PREC, 6)
                                            End If
                                            'LtDocAnt.Text = dr.ReadNullAsEmptyString("REM_PED")
                                        End If
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try
                                Else
                                    '==================================================================
                                    Try
                                        If CHCAMPOLIB_CUADRILLA = 0 Then
                                            PREC = dr("PREC")
                                            PREC = Math.Round(PREC, 6)
                                        Else
                                            If TIPO_VENTA_LOCAL = "R" Then
                                                If dr("PREC") > 0 Then
                                                    If dr("TOT_PARTIDA") - dr("MO") >= 0 Then
                                                        MONTO_REMISIONADO = dr("TOT_PARTIDA") - dr("MONTO_REMISIONADO")
                                                        PREC = MONTO_REMISIONADO
                                                    Else
                                                        MONTO_REMISIONADO = dr("MONTO_REMISIONADO")
                                                        PREC = Math.Round(MONTO_REMISIONADO, 6)
                                                    End If
                                                Else
                                                    PREC = dr("PREC")
                                                    PREC = Math.Round(PREC, 6)
                                                End If
                                            Else
                                                PREC = dr("PREC")
                                                PREC = Math.Round(PREC, 6)
                                            End If
                                            'LtDocAnt.Text = dr.ReadNullAsEmptyString("REM_PED")
                                        End If
                                    Catch ex As Exception
                                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                    End Try
                                End If
                            Else
                                PREC = dr("PREC")
                                PREC = Math.Round(PREC, 6)
                            End If


                            If PREC <> 0 Then
                                Try
                                    DESCP = PREC * dr("DESC1") / 100
                                    IMPU1 = dr("IMPU1")
                                    IMPU2 = dr("IMPU2")
                                    IMPU3 = dr("IMPU3")
                                    IMPU4 = dr("IMPU4")

                                    cIEPS = (PREC - DESCP - DESCP2) * IMPU1 / 100
                                    IVA2 = (PREC - DESCP - DESCP2) * IMPU2 / 100
                                    IVA3 = (PREC - DESCP - DESCP2) * IMPU3 / 100
                                    cIMPU = (PREC - DESCP - DESCP2) * IMPU / 100
                                    PrecioVenta = PREC - DESCP - DESCP2

                                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                                    s = "" & vbTab '1
                                    s &= dr("CANT") & vbTab '2
                                    s &= CADENA_ALM & vbTab '3
                                    s &= dr("CVE_ART") & vbTab '4
                                    s &= "" & vbTab '5
                                    s &= dr("DESCR") & " (" & dr("TIPOELE") & ")" & vbTab '6
                                    s &= dr("UNI_VENTA") & vbTab '7
                                    s &= dr("DESC1") & vbTab '8
                                    s &= dr("IMPU1") & vbTab '9
                                    s &= dr("IMPU2") & vbTab '10
                                    s &= dr("IMPU3") & vbTab '11
                                    s &= dr("IMPU4") & vbTab '12
                                    s &= PREC & vbTab '13
                                    s &= "" & vbTab '14
                                    s &= dr("CANT") * PREC & vbTab '15
                                    s &= dr("CVE_ART") & vbTab '16
                                    s &= dr("FAC_CIERRE") & vbTab '17
                                    s &= "" & vbTab '18
                                    s &= dr("NUM_PAR") & vbTab '19
                                    s &= fCVE_DOC & vbTab '20
                                    s &= fTIPOC.ToUpper & vbTab '21
                                    s &= "0" & vbTab 'CVE_OBS 22
                                    s &= dr("PAR_OBS") & vbTab '23
                                    s &= dr("CONLOTE") & vbTab '24    CON LOTE  S/N
                                    s &= "" & vbTab '25    REG_LTPD
                                    s &= "" & vbTab '26    UNIDAD
                                    s &= "" & vbTab '27    NO SE USA
                                    s &= dr("CVE_ESQ") & vbTab '28
                                    s &= MONTO_REMISIONADO & vbTab '29
                                    s &= dr("TIPOELE") & vbTab '30 TIPO_ELE
                                    s &= dr("LINEA") '31    LINEA
                                    s &= "" '32    politica
                                    s &= 0 '33    PREC_PUBLICO PRECIO
                                    s &= 0 '34    LISTA_PREC_VTA 'LISTA DE PRECIOS
                                    s &= 0 '35    CANT_POLIT 'PIEZAS

                                    'Fg(z, 32) = "" 'POLITICA
                                    'Fg(z, 33) = 0 'PREC_PUBLICO PRECIO
                                    'Fg(z, 34) = 0 'LISTA_PREC_VTA 'LISTA DE PRECIOS
                                    'Fg(z, 35) = 0 'CANT_POLIT 'PIEZAS

                                    Fg.AddItem("" & vbTab & s)
                                    j += 1
                                    If dr("TIPOELE") = "K" Then
                                        Fg.Row = Fg.Rows.Count - 1
                                        Fg.SetCellStyle(Fg.Row, 6, CustomStyle)
                                    End If
                                Catch ex As Exception
                                    BITACORATPV("120. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                                End Try
                            End If
                        End While
                    End Using
                End Using

            Catch ex As Exception
                BITACORATPV("120. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            '================================================

            LLENAR_CAMPOS_LIBRES(fTIPOC, fCVE_DOC)

            Var13 = "SOLOTOTAL"
            CALCULAR_IMPORTES()

            If (TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "D") And Ldocu.Tag = "Digital" Then
                LtFAC_CVE_DOC.Text = fCVE_DOC
                LtUUID.Text = BUSCAR_UUID_FACTURA_TRANSPORT(fCVE_DOC)
                LLENA_CAMPOS(TCLIENTE.Text)
            Else
                If DOC_ENLAZADO = "S" Then
                    LtDocAnt.Text = fCVE_DOC & vbCrLf & "Tipo doc " & fTIPOC
                Else
                    LtDocAnt.Text = ""
                End If
            End If

            Fg.Focus()
        Catch ex As Exception
            BITACORATPV("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True

    End Sub

    Sub LLENAR_CAMPOS_LIBRES(FTIPOC As String, FCVE_DOC As String)
        Dim CAEDENA As String, CADENA2 As String, TIENE_LIB As Boolean = False, CVE_DOC_P As String
        Try
            If DOC_NEW Then
                CVE_DOC_P = LUUID
            Else
                CVE_DOC_P = LtCVE_DOC.Text
            End If

            Dim TIPO_CAMPO As String, EXIST_LIB As Boolean = False, TIP_FIELD As String
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM PAR_FACT" & FTIPOC & "_CLIB" & Empresa & " L WHERE CLAVE_DOC = '" & FCVE_DOC & "' ORDER BY NUM_PART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            TIENE_LIB = True

                            CAEDENA = "INSERT INTO GCLIB_PAR_P (CLAVE_DOC, NUM_PART"

                            For k = 2 To dr.FieldCount - 1
                                CAEDENA &= ", " & dr.GetName(k) & ", ETIQUETA" & GetNumeric(dr.GetName(k)) & ",TIPO" & GetNumeric(dr.GetName(k))
                            Next

                            CAEDENA += ") VALUES ('" & CVE_DOC_P & "','" & dr("NUM_PART")

                            For k = 2 To dr.FieldCount - 1

                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper

                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Or TIPO_CAMPO = "DECIMAL" Then
                                    TIP_FIELD = "N"
                                Else
                                    TIP_FIELD = " "
                                End If

                                CAEDENA += "','" & dr(dr.GetName(k)) & "','" & GET_ETIQUETA("PAR_FACT_CLIB", dr.GetName(k)) & "','" & TIP_FIELD
                            Next
                            CAEDENA += "')"

                            SQL = CAEDENA
                            ReturnBool = EXECUTE_QUERY_NET(SQL)
                        Catch ex As Exception
                            BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using

            If Not TIENE_LIB Then

                CAEDENA = "INSERT INTO GCLIB_PAR_P (CLAVE_DOC, NUM_PART"
                CADENA2 = " VALUES ('" & CVE_DOC_P & "','1"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM PARAM_CAMPOSLIBRES" & Empresa & " 
                        WHERE IDTABLA = 'PAR_FACT_CLIB' ORDER BY CAMPO"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try

                                CAEDENA &= ", " & dr("CAMPO") & ", ETIQUETA" & GetNumeric(dr("CAMPO")) & ",TIPO" & GetNumeric(dr("CAMPO"))

                                TIPO_CAMPO = dr.GetDataTypeName(2).ToString.ToUpper

                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                        TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Or TIPO_CAMPO = "DECIMAL" Then
                                    TIP_FIELD = "N"
                                Else
                                    TIP_FIELD = " "
                                End If

                                CADENA2 += "',' ','" & dr("ETIQUETA") & "','" & TIP_FIELD
                            Catch ex As Exception
                                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While

                        CAEDENA += ")"
                        CADENA2 += "')"
                        SQL = CAEDENA & CADENA2
                        ReturnBool = EXECUTE_QUERY_NET(SQL)

                    End Using
                End Using

            End If


            'AQUI EMPIEZA LA BUSQUEDQA DE LOS CAMPOS LIBRES DEL DOCUMENTO ENLAZADO
            'FACTP_CLIB

            TIENE_LIB = False
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM FACT" & FTIPOC & "_CLIB" & Empresa & " L WHERE CLAVE_DOC = '" & FCVE_DOC & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            TIENE_LIB = True

                            CAEDENA = "INSERT INTO GCLIB_FACTP (CLAVE_DOC"

                            Try
                                For k = 1 To dr.FieldCount - 1
                                    CAEDENA &= ", " & dr.GetName(k) & ", ETIQUETA" & GetNumeric(dr.GetName(k)) & ",TIPO" & GetNumeric(dr.GetName(k))
                                Next
                            Catch ex As Exception
                                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            CAEDENA += ", UUID) VALUES ('" & CVE_DOC_P

                            For k = 1 To dr.FieldCount - 1

                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper

                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Or TIPO_CAMPO = "DECIMAL" Then
                                    TIP_FIELD = "N"
                                Else
                                    TIP_FIELD = " "
                                End If

                                CAEDENA += "','" & dr(dr.GetName(k)) & "','" & GET_ETIQUETA("FACTP_CLIB", dr.GetName(k)) & "','" & TIP_FIELD

                                If CHCAMPOLIB_CUADRILLA = 1 Then
                                    If dr.GetName(k) = "CAMPLIB2" Then
                                        TOBRA.Text = dr(dr.GetName(k))
                                        If TOBRA.Text.Length >= 1 Then
                                            Try
                                                If TOBRA.Text.IndexOf(" ") > -1 Then
                                                    TOBRA.Text = TOBRA.Text.Substring(0, TOBRA.Text.IndexOf(" ")).Trim '& dr(dr.GetName(k)).ToString
                                                Else
                                                    TOBRA.Text = TOBRA.Text
                                                End If

                                                '.Substring(0, 20) & dr(dr.GetName(k)).ToString

                                                LtObra.Text = " " & BUSCA_CAT("Obra", TOBRA.Text)
                                            Catch ex As Exception
                                                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                        End If
                                    End If
                                End If
                            Next
                            CAEDENA += "',NEWID())"

                            SQL = CAEDENA
                            ReturnBool = EXECUTE_QUERY_NET(SQL)
                        Catch ex As Exception
                            BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                    End While
                End Using
            End Using
            If Not TIENE_LIB Then

                '============================================= NO SE ENCONTRARON PARTIDAS DE CAMPOS LIBRES ES UNO NUEVO
                CAEDENA = "INSERT INTO GCLIB_FACTP (CLAVE_DOC"
                CADENA2 = " VALUES ('" & CVE_DOC_P
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM PARAM_CAMPOSLIBRES" & Empresa & " 
                        WHERE IDTABLA = 'FACT" & TIPO_VENTA_LOCAL & "_CLIB' ORDER BY CAMPO"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Try
                                CAEDENA &= ", " & dr("CAMPO") & ", ETIQUETA" & GetNumeric(dr("CAMPO")) & ",TIPO" & GetNumeric(dr("CAMPO"))

                                TIPO_CAMPO = dr.GetDataTypeName(2).ToString.ToUpper
                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Or TIPO_CAMPO = "DECIMAL" Then
                                    TIP_FIELD = "N"
                                Else
                                    TIP_FIELD = " "
                                End If

                                CADENA2 &= "',' ','" & dr("ETIQUETA") & "','" & TIP_FIELD

                            Catch ex As Exception
                                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                        CAEDENA += ", UUID) "
                        CADENA2 += "',NEWID())"

                        SQL = CAEDENA & CADENA2
                        ReturnBool = EXECUTE_QUERY_NET(SQL)
                    End Using
                End Using

            End If
        Catch ex As Exception
            BITACORATPV("135. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
        OBSER = ""

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
                    LtFormaPagoSat.Text = BUSCA_CAT("Unidad", dr("CVE_TRACTOR"))

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
                s &= 1 & vbTab '2
                s &= 1 & vbTab '3
                s &= dr("CVE_MAT") & vbTab '4
                s &= "" & vbTab '5
                s &= dr("DES") & " (" & dr("TIPO_ELE") & ")" & vbTab '6
                s &= dr("UNI_VENTA") & vbTab '7
                s &= 0 & vbTab '8
                s &= dr("IMPU1") & vbTab '9
                s &= dr("IMPU2") & vbTab '10
                s &= dr("IMPU3") & vbTab '11
                s &= dr("IMPU4") & vbTab '12
                s &= PREC & vbTab '13
                s &= 1 * PREC & vbTab '14
                s &= dr("CVE_MAT") & vbTab '15
                s &= "" & vbTab '16
                s &= "" & vbTab '17
                s &= 1 & vbTab '18
                s &= "" & vbTab '19
                s &= "" & vbTab '20
                s &= "0" & vbTab '21
                s &= IIf(j = 0, FDOCUMENT, FDOCUMENT2) & vbTab '22
                s &= "" & vbTab '23
                s &= dr("REM_CARGA") & vbTab '24    REMISION CARGA
                s &= dr("CVE_TRACTOR") & vbTab '25    UNIDAD
                s &= dr("PESO1") - dr("T1") & vbTab '26    TONELADAS
                s &= 0 '23
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
                '  CANT         PXS          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                '   1            2            3            4            5            6            7            8            9           10
                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                '   IMP3         IMP4        PRECIO      SUBTOT       CVE_ART         1            2          NUM_PAR   CVE_DOC_ENLA  ENLA_TIP_DOC    
                '    11           12           13           14           15           16           17           18           19           20 
                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                ' CVE_OBS       CVE_OBS_PAR   CON LOTE      LOTE                                                           EXIST       TIPO_ELE     LINEA
                '    21          22           23           24           25           26           27           28           29          30           31  
                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab & ""
                '(P)POLITICA PREC PUBLIC LISTA_PREC_VTA CANT_POLIT                                  
                '    32            33          34          35


                Fg.AddItem("" & vbTab & s)
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

            Dim TabName As String

            TabName = MainRibbonForm.Tab1.TabPages(MainRibbonForm.Tab1.SelectedIndex).Text

            CloseTab(TabName)

            If PassData8 = "FACTURAS" Then
                If Form_Open(frmFACTURAS) Then
                    frmFACTURAS.REFRESCAR()
                End If
            Else
                If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "P" Then
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

                    Ldocu.Tag = "Digital"
                    FACTURA_DIGITAL = "Digital"

                    CargarUsosCfdi()
                    CargarRegimenesFiscales()
                    CargarMonedas()
                    CargarMetodosPago()
                    CargarFormasPago()

                    If TCLIENTE.Text.Trim.Length > 0 Then
                        LLENA_CAMPOS(TCLIENTE.Text)
                    End If


                    Try
                        If LtFormaPagoSat.Text.Trim.Length > 0 Then
                            For k = 0 To cbFormaPago.Items.Count - 1
                                cbFormaPago.SelectedIndex = k
                                If (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago = LtFormaPagoSat.Text.Trim Then
                                    cbFormaPago.SelectedIndex = k
                                    Exit For
                                End If
                            Next
                        Else
                            cbFormaPago.SelectedIndex = 0
                        End If
                    Catch ex As Exception
                        BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If LtMetodoPago.Text.Trim.Length > 0 Then
                            For k = 0 To cbMetodoPago.Items.Count - 1
                                cbMetodoPago.SelectedIndex = k
                                If (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago = LtMetodoPago.Text.Trim Then
                                    cbMetodoPago.SelectedIndex = k
                                    Exit For
                                End If
                            Next
                        Else
                            cbMetodoPago.SelectedIndex = 0
                        End If
                    Catch ex As Exception
                        BITACORATPV("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try


                    Page2.TabVisible = True
                    Page3.TabVisible = False

                    Ldocu.Tag = Var18 ' = "Digital"

                    If TIPO_VENTA_LOCAL = "D" And Ldocu.Tag = "Digital" Then
                        If CVE_ART_NC.Trim.Length = 0 Then
                            MsgBox("Por favor capture la clave del articulo para notas de crédito en parámetros-inventario")
                        Else
                            '1,4,6,13
                            Fg.Row = 1
                            Fg(1, 1) = 1
                            Fg(1, 2) = 1
                            Fg(1, 4) = CVE_ART_NC
                            Fg.Col = 4

                        End If
                    End If
                Else
                    Ldocu.Tag = "Impresión"
                    FACTURA_DIGITAL = "Impresión"

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
            If e.KeyCode = 13 Then
                If CboPrecio.Visible Then
                    CboPrecio.Focus()
                Else
                    If CboAlmacen.Visible Then
                        CboAlmacen.Focus()
                    Else
                        Fg.Focus()
                        Fg.Col = 2
                        SendKeys.Send("{ENTER}")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TDESC_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TDESC.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                If CboPrecio.Visible Then
                    CboPrecio.Focus()
                Else
                    If CboAlmacen.Visible Then
                        CboAlmacen.Focus()
                    Else
                        Fg.Focus()
                        Fg.Col = 2
                        SendKeys.Send("{ENTER}")
                    End If
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
                    End If
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
            BITACORATPV("142. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("142. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub IMPRIMIR_VENTA(fCVE_DOC As String)
        Dim Rreporte_MRT As String
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()

        Try
            If Fg.Row > 0 Then
                Select Case TIPO_VENTA_LOCAL
                    Case "F"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportFactura" & Empresa & ".mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportFactura.mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "V"
                        Rreporte_MRT = RUTA_FORMATOS & "\TicketEstandard.mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\Nota de Venta Ticket" & Empresa & ".mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "P"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportPedido" & Empresa & ".mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportPedido.mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "C"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportCotizacion" & Empresa & ".mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportCotizacion.mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
                        End If
                        StiReport1.Load(Rreporte_MRT)
                    Case "D"
                        Rreporte_MRT = RUTA_FORMATOS & "\ReportDevoluciones" & Empresa & ".mrt"
                        If Not File.Exists(Rreporte_MRT) Then
                            Rreporte_MRT = RUTA_FORMATOS & "\ReportDevoluciones.mrt"
                            If Not File.Exists(Rreporte_MRT) Then
                                MsgBox("No existe el reporte " & Rreporte_MRT & ", verifique por favor")
                                Return
                            End If
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
                If TIPO_VENTA_LOCAL = "F" Then
                    PassData1 = "FACTURA"
                    IMPRIMIR_CFDI_40(LtCVE_DOC.Text, "FACTURA")
                Else
                    PassData1 = "CFDI Nota de crédito"
                    IMPRIMIR_CFDI_40(LtCVE_DOC.Text, "NOTA DE CREDITO")
                End If
            Else
                GEN_IMPRIMIR_TICKET(TIPO_VENTA_LOCAL, LETRA_VENTA, LtCVE_DOC.Text, "FrmTPV", CDec(LtTOTAL.Text.Replace(",", "")))

                'GEN_IMPRIMIR_TICKET_TPV(TIPO_VENTA_LOCAL, LtCVE_DOC.Text, "FrmTPV")
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

        Dim IMPORTE As Decimal, DESCUENTO1 As Decimal, ImporteConDes As Decimal, DESC1 As Decimal
        Dim CVE_ESQIMPU As Integer = 1, CAN_TOT As Decimal, DES_TOT As Decimal, PRECIO As Decimal, PRECIO_NETO As Decimal

        Dim cIeps As Decimal, cImpu As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer
        Dim TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal
        Dim ImporteIeps As Decimal, ImporteImpu2 As Decimal, ImporteImpu3 As Decimal, ImporteIVA As Decimal
        Dim CANT As Decimal, CVE_ART As String = "", FAC_CIERRE As String = "", DESC_VTA As Decimal


        ENTRA = False

        Fg.Redraw = False
        Fg.BeginUpdate()

        Try
            DES_TOT = 0
            TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To Fg.Rows.Count - 1

                Try
                    CVE_ART = Fg(i, 4)
                    CVE_ART = CVE_ART.Replace("'", "")

                    CVE_ESQIMPU = Fg(i, 28)
                    FAC_CIERRE = Fg(i, 17)
                Catch ex As Exception

                End Try
                Try
                    CANT = Fg(i, 2)

                    If CVE_ART.Length > 0 And CANT > 0 Then

                        If FAC_CIERRE = "S" Then
                            IMPU1 = 0 : IMPU2 = 0 : IMPU3 = 0 : IMPU4 = 0
                            IMP1APLA = 6 : IMP2APLA = 6 : IMP3APLA = 6 : IMP4APLA = 14
                        Else
                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
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
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                            End Try
                        End If
                        Try
                            If DESC_VTA = 0 Then
                                Try
                                    If Not IsNothing(Fg(i, 8)) Then
                                        If IsNumeric(Fg(i, 8)) Then
                                            DESC1 = Fg(i, 8)
                                        End If
                                    End If
                                Catch ex As Exception
                                End Try
                            Else
                                DESC1 = DESC_VTA
                                Fg(i, 8) = DESC_VTA
                            End If

                            PRECIO = Fg(i, 13)
                            PRECIO_NETO = PRECIO - (PRECIO * DESC1 / 100)

                            DESCUENTO1 = (CANT * PRECIO * DESC1 / 100)
                            ImporteConDes = (CANT * PRECIO) - DESCUENTO1
                            DES_TOT += DESCUENTO1

                            cIeps = PRECIO_NETO * IMPU1 / 100
                            cImpu2 = PRECIO_NETO * IMPU2 / 100
                            cImpu3 = PRECIO_NETO * IMPU3 / 100
                            cImpu = PRECIO_NETO * IMPU4 / 100

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

                            Fg(i, 15) = (CANT * PRECIO_NETO)
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

        Fg.Redraw = True
        Fg.EndUpdate()

        ENTRA = True
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
                LISTA_PREC_CLIE = dr("PRECIO")

                For k = 1 To CboPrecio.Items.Count - 1
                    If Val(CboPrecio.Items(k).ToString.Substring(0, 2)) = dr("PRECIO") Then
                        CboPrecio.SelectedIndex = k
                        Exit For
                    End If
                Next

                'Private METODODEPAGO As String
                'Private FORMAPAGO As String

                If USO_CFDI.Trim.Length > 0 Then
                    For k = 0 To cbUsoCfdi.Items.Count - 1
                        If cbUsoCfdi.Items(k).ToString.Substring(0, 3) = USO_CFDI Then
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
                LtNombre.Text = ""
                LtNombre.Tag = ""
                LtCorreo.Text = ""
                LtCalle.Text = ""
                LtColonia.Text = ""
                LtNumInt.Text = ""
                LtNumExt.Text = ""
                LtCP.Text = ""
                LtRFC.Text = ""
                LtPoblacion.Text = ""
                LtEstado.Text = ""
                USO_CFDI = ""
                REG_FISC = ""
                LISTA_PREC_CLIE = ""

                CboPrecio.SelectedIndex = -1
                cbMetodoPago.SelectedIndex = -1

                cbFormaPago.SelectedIndex = -1

                cbUsoCfdi.SelectedIndex = -1
                cbRegimenesFiscales.SelectedIndex = -1


                MsgBox("Cliente inexistente")
                TCLIENTE.Text = ""
                TCLIENTE.Select()
            End If
            dr.Close()
        Catch ex As Exception
            BITACORATPV("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub cbMetodoPago_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMetodoPago.SelectedIndexChanged
        Dim FORMA_PAGO As String

        Try
            If (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago = "PPD" Then
                FORMA_PAGO = "99"
                If FORMA_PAGO.Trim.Length > 0 Then
                    For k = 0 To cbFormaPago.Items.Count - 1
                        cbFormaPago.SelectedIndex = k
                        If (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago = FORMAPAGO Then
                            cbFormaPago.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If
            End If

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
    Sub GRABAR()
        Try
            BarGrabar_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Try
            Dim Sigue As Boolean = False, CLAVE_OBRA As String = ""

            If Not ExistenPartidas() Then
                MsgBox("No existen partidas por favor agréguelas")
                Return
            End If

            If TCLIENTE.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un cliente")
                Return
            End If


            If CHCAMPOLIB_CUADRILLA = 1 And (TIPO_VENTA_LOCAL = "P" Or TIPO_VENTA_LOCAL = "R") Then
                If TOBRA.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la obra")
                    Return
                End If
            End If

            ENTRA = False
            Fg.FinishEditing()
            ENTRA = True

            CALCULAR_IMPORTES()
            If OBSER_X_DOC = 1 Then
                Var4 = OBSER
                Var5 = "NUEVO"
                Var6 = "FACTF_CLIB"
                Var7 = "FACT" & TIPO_VENTA & "_CLIB" & Empresa
                Var9 = "D"

                If DOC_NEW Then
                    Var8 = LUUID
                Else
                    Var8 = LtCVE_DOC.Text
                End If


                If CHCAMPOLIB_CUADRILLA = 1 Then

                    If TOBRA.Text <> "" AndAlso TOBRA.Text.Trim.Length > 0 Then

                        CLAVE_OBRA = TOBRA.Text.PadRight(20)
                        Var10 = CLAVE_OBRA & " " & LtObra.Text
                        Var14 = CAMPLIB_OBRA
                    Else
                        Var10 = ""
                        Var14 = ""
                    End If
                Else
                    Var10 = ""
                    Var14 = ""
                End If


                FrmObserYCampLib.ShowDialog()
                OBSER = Var4
                Sigue = True

            Else
                Sigue = True
            End If
            If Sigue = True Then
                Var7 = ""
                Var8 = ""
                Var13 = "SOLOTOTAL"
                VarFORM = ""
                If (TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F") And (FACTURA_DIGITAL = "Impresión" Or FACTURA_DIGITAL = "") Then
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
        Dim DESC1 As Decimal, DESC2 As Decimal, DESC3 As Decimal, ALMACEN As Integer, ALMACEN_FG As String, NUM_ALM As Integer
        Dim PRECIO As Decimal, PREC As Decimal, TIP_DOC As String, E_LTPD As Integer, DES_FIN As Decimal, FECHA_ENT As String
        Dim IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, TOTIMP1 As Decimal, TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal
        Dim cImpu1 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, cImpu4 As Decimal
        Dim SUBTOTAL As Decimal, ImporteConDes As Decimal, DES_TOT As Decimal, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, IMPORTE As Decimal, COM_TOT As Decimal
        Dim CVE_DOC As String, STATUS As String, DAT_MOSTR As Long, CVE_VEND As String, CVE_PEDI As String
        Dim FECHA_DOC As String, FECHA_VEN As String, CAN_TOT As Decimal, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal
        Dim CONDICION As String, CVE_OBS As Long, ACT_CXC As String, ACT_COI As String, ENLAZADO As String, TIP_DOC_E As String
        Dim NUM_MONED As Integer = 1, TIPCAMB As Decimal, NUM_PAGOS As Long, PRIMERPAGO As Decimal, DOC_ANT As String = "", RFC As String = ""
        Dim CTLPOL As Long, ESCFD As String, AUTORIZA As Long, SERIE As String, AUTOANIO As String, DAT_ENVIO As Long, CONTADO As String, CVE_BITA As Long
        Dim Bloq As String, FORMAENVIO As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, COM_TOT_PORC As Decimal
        'variables partidas
        Dim NUMCTAPAGO As String, TIP_DOC_ANT As String = "", NUM_PAR As Integer, MAN_IEPS As String, APL_MAN_IMP As Integer, CUOTA_IEPS As Integer
        Dim CVE_ESQ As Integer, CVE_ESQIMPU As Integer, COST As Decimal, COMI As Decimal, APAR As Decimal, ACT_INV As String, POLIT_APLI As String, TIP_CAM As Decimal
        Dim TIPO_PROD As String, TIPO_PROD2 As String = "", REG_SERIE As Long, TIPO_ELEM As String, TOT_PARTIDA As Decimal
        Dim APL_MAN_IEPS As String, MTO_PORC As Integer, MTO_CUOTA As Integer
        'MOVSINV
        Dim CVE_CPTO As Integer, FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, FORMADEPAGOSAT As String = "", UNI_MED As String, COSTO_PROM As Decimal, UUID As String
        Dim SIGUE As Boolean, FOLIO_ASIGNADO As Boolean, cIEPS As Decimal, cIMPU As Decimal, UNI_VENTA As String, DETEC_ERROR_VIOLATION_KEY As Boolean
        Dim CVE_PRODSERV As String = "", CVE_UNIDAD As String = "", SUBTOTAL2 As Decimal
        Dim Continua2 As Boolean

        Dim cmdT As New SqlCommand
        Dim cmdF As New SqlCommand
        Dim cmdP As New SqlCommand
        Dim cmd As New SqlCommand

        Try
            Continua2 = False
            ENTRA = False
            For k = 1 To Fg.Rows.Count - 1
                If Not IsNothing(Fg(k, 4)) Then
                    If Fg(k, 4).ToString.Trim.Length > 0 And Fg(k, 4).ToString = "P" Then
                        Try
                            ALMACEN = 1
                            Try
                                If ALMACEN_X_PARTIDA = 1 Then
                                    If Fg(k, 3).ToString.Length > 2 Then
                                        ALMACEN = CInt(Fg(k, 3).ToString.Substring(0, 2))
                                    End If
                                Else
                                    If CboAlmacen.SelectedIndex > -1 Then
                                        ALMACEN = CboAlmacen.Items(CboAlmacen.SelectedIndex).ToString.Substring(0, 2)
                                    End If
                                End If
                            Catch ex As Exception
                                BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            If Not IsNothing(Fg(k, 2)) Then
                                If IsNumeric(Fg(k, 2)) Then
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        If MULTIALMACEN = 0 Then
                                            SQL = "SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & Fg(k, 4).ToString & "'"
                                        Else
                                            SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & Fg(k, 4).ToString & "' AND CVE_ALM = " & ALMACEN
                                        End If
                                        cmd2.CommandText = SQL
                                        Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                            If dr2.Read Then
                                                If Fg(k, 2) > dr2("EXIST") Then
                                                    Continua2 = True
                                                End If
                                            End If
                                        End Using
                                    End Using
                                End If
                            End If
                        Catch ex As Exception
                            BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If
            Next
            ENTRA = True
            If Continua2 Then
                MsgBox("En algunas partidas la existencia es insuficiente")
                Return
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            USO_CFDI = "" : METODODEPAGO = ""



            Select Case TIPO_VENTA_LOCAL
                Case "F", "D"

                    If Ldocu.Tag = "Digital" Then

                        If cbUsoCfdi.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If

                        If cbUsoCfdi.Items(cbUsoCfdi.SelectedIndex).ToString.Length > 2 Then
                            USO_CFDI = cbUsoCfdi.Items(cbUsoCfdi.SelectedIndex).ToString.Substring(0, 3)
                        Else
                            USO_CFDI = ""
                        End If

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


                        'MONEDA
                        If CboMoneda.SelectedIndex = -1 Then
                            MsgBox("Por favor seleccione el uso CFDI")
                            Tab1.SelectedIndex = 1
                            Return
                        End If

                        NUM_MONED = CboMoneda.SelectedItem.ToString.Substring(0, 1)
                        MONEDA = NUM_MONED

                        If Not IsNothing(CboMoneda.SelectedItem) Then

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

                            NUM_MONED = CboMoneda.SelectedItem.ToString.Substring(0, 1)

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
                                MsgBox("Por favor seleccione método de pago")
                                Tab1.SelectedIndex = 1
                                Return
                            End If
                            If METODODEPAGO.Trim.Length = 0 Then
                                MsgBox("Por favor seleccione método de pago")
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
                        Else
                            MsgBox("Por favor seleccione la forma de pago SAT")
                            Tab1.SelectedIndex = 1
                            Return
                        End If

                        If TCLIENTE.Text = "MOSTR" Or TCLIENTE.Text = CLIENTE_MOSTRADOR Then
                            MsgBox("No se puede facturar a cliente mostrador verifique por favor")
                            Return
                        End If

                    End If

                    If TIPO_VENTA_LOCAL = "D" Then
                        'DEVOLUCION
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
                    Else
                        If MsgBox("Realmente desea grabar la factura?", vbYesNo) = vbNo Then
                            Return
                        End If
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
                    If MsgBox("Realmente desea grabar la cotización?", vbYesNo) = vbNo Then
                        Return
                    End If
                Case "R"
                    If MsgBox("Realmente desea grabar la remisión?", vbYesNo) = vbNo Then
                        Return
                    End If
            End Select
        Catch ex As Exception
            BITACORATPV("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Return
        End Try


        If Not DOC_NEW And TIPO_VENTA_LOCAL = "C" Then
            FECHA_DOC = FSQL(F1.Value)
            FECHA_ENT = FECHA_DOC
            FECHA_VEN = FECHA_DOC
        Else
            FECHA_DOC = FSQL(F1.Value)
            FECHA_ENT = FECHA_DOC
            FECHA_VEN = FECHA_DOC
        End If

        If Not Valida_Conexion() Then
            Return
        End If

        cmdF.Connection = cnSAE
        cmd.Connection = cnSAE
        cmdP.Connection = cnSAE

        Try
            If MULTIALMACEN = 0 Then
                ALMACEN = 1
            Else
                If CboAlmacen.SelectedIndex = -1 Then
                    ALMACEN = 1
                Else
                    ALMACEN = CboAlmacen.Items(CboAlmacen.SelectedIndex).ToString.Substring(0, 2)
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

        If Not DOC_NEW And (TIPO_VENTA_LOCAL = "D" Or TIPO_VENTA_LOCAL = "C" Or TIPO_VENTA_LOCAL = "R" Or TIPO_VENTA_LOCAL = "P") Then

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
                FOLIO_VENTA = SIGUIENTE_FOLIO_VENTA(TIPO_VENTA_LOCAL, LETRA_VENTA)

                Do While SIGUE
                    If LETRA_VENTA.Trim.Length = 0 Or LETRA_VENTA = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_VENTA, "0000000000")
                    Else
                        If TIPO_VENTA_LOCAL = "F" Then
                            CVE_DOC = LETRA_VENTA & Format(FOLIO_VENTA, "0000000000")
                        Else
                            CVE_DOC = LETRA_VENTA & Format(FOLIO_VENTA, "0000000000")
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
            CONDICION = tCONDICION.Text : CVE_OBS = 0 : ACT_CXC = "S" : ACT_COI = "A" : ENLAZADO = "O"
            NUM_PAGOS = 1
            CTLPOL = 0 : ESCFD = "N" : AUTORIZA = 0 : AUTOANIO = "" : CONTADO = "S" : CVE_BITA = 0 : Bloq = "N"
            FORMAENVIO = "I" : DES_FIN_PORC = 0 : NUMCTAPAGO = "" : AUTORIZA = 1
            DAT_ENVIO = 0 : COM_TOT_PORC = 0 : IMPORTE = 0
            MAN_IEPS = "N" : APL_MAN_IMP = 1 : CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            TIPO_ELEM = "N" : ACT_INV = "S" : TIPO_PROD = "" : POLIT_APLI = "" : TIP_DOC = "V" : TIP_DOC_ANT = ""
            STATUS = "E" : COSTEADO = "S" : DESDE_INVE = "N" : SIGNO = -1 : TIP_CAM = 1 : E_LTPD = 0 : UUID = ""
            SUBTOTAL = 0 : SUBTOTAL2 = 0

            If TIPO_VENTA_LOCAL = "" Then
                If TIPO_VENTA_LOCAL = "V" Then
                    METODODEPAGO = "PUE" : USO_CFDI = "G03" : FORMADEPAGOSAT = "99"
                End If
            End If

            TIPCAMB = txTC.Value

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
                    CVE_ART = Fg(k, 4)
                    CVE_ESQIMPU = Fg(k, 28)

                    If Not IsNothing(Fg(k, 3)) Then
                        ALMACEN_FG = Fg(k, 3)
                        If ALMACEN_FG.Length > 1 Then
                            If IsNumeric(ALMACEN_FG.Substring(0, 2)) Then
                                NUM_ALM = ALMACEN_FG.Substring(0, 2)
                            Else
                                NUM_ALM = ALMACEN
                            End If
                        Else
                            NUM_ALM = ALMACEN
                        End If
                    Else
                        NUM_ALM = ALMACEN
                    End If

                Catch ex As Exception
                    CANT = 0 : NUM_ALM = 1 : CVE_ART = ""
                End Try

                Continua2 = False
                If CHCAMPOLIB_CUADRILLA = 0 Then
                    If CANT > 0 Then
                        Continua2 = True
                    End If
                Else
                    Continua2 = True
                End If

                If Continua2 And CVE_ART.Trim.Length > 0 Then

                    DOC_ANT = Fg(k, 20)
                    TIP_DOC_ANT = Fg(k, 21)
                    EXIST = 0
                    Try
                        If TIPO_VENTA_LOCAL = "V" Then
                            If CREDITO = "CREDITO" Then
                                CONTADO = "N"
                                METODODEPAGO = "PPD"
                            Else
                                CONTADO = "S"
                                METODODEPAGO = "PUE"
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

                    Try
                        If CVE_ESQIMPU > 0 Then
                            SQL = "SELECT COALESCE(P.IMPUESTO1,0) AS IMPU1, COALESCE(P.IMPUESTO2,0) AS IMPU2, COALESCE(P.IMPUESTO3,0) AS IMPU3,
                            COALESCE(P.IMPUESTO4,0) AS IMPU4, COALESCE(P.IMP1APLICA,0) AS IMP1APLA, COALESCE(P.IMP2APLICA,0) AS IMP2APLA,
                            COALESCE(P.IMP3APLICA,0) AS IMP3APLA, COALESCE(P.IMP4APLICA,0) AS IMP4APLA
                            FROM IMPU" & Empresa & " P 
                            WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        IMPU1 = dr2("IMPU1")
                                        IMPU2 = dr2("IMPU2")
                                        IMPU3 = dr2("IMPU3")
                                        IMPU4 = dr2("IMPU4")
                                        IMP1APLA = dr2("IMP1APLA")
                                        IMP2APLA = dr2("IMP2APLA")
                                        IMP3APLA = dr2("IMP3APLA")
                                        IMP4APLA = dr2("IMP4APLA")
                                    End If
                                End Using
                            End Using
                        End If
                    Catch ex As Exception
                        BITACORATPV("750. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    DESC1 = Fg(k, 8)

                    PRECIO = Fg(k, 13)
                    PREC = PRECIO
                    '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                    SUBTOTAL += (CANT * PREC)
                    ImporteConDes = (CANT * PREC) - (CANT * PREC * DESC1 / 100)

                    DES_TOT += (CANT * PREC * DESC1 / 100)
                    DES_TOT += (DES_TOT * DESC2 / 100)

                    cImpu1 = ImporteConDes * IMPU1 / 100
                    cImpu2 = ImporteConDes * IMPU2 / 100
                    cImpu3 = ImporteConDes * IMPU3 / 100

                    If IMPU1 > 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 > 0 Then
                        cImpu4 = (ImporteConDes + cImpu1) * IMPU4 / 100
                    Else
                        cImpu4 = ImporteConDes * IMPU4 / 100
                    End If
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
                        Debug.Print(DOC_ANT & ",'" & TIP_DOC_ANT)
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
            CVE_PEDI = ""
            CONDICION = ""
            PRIMERPAGO = IMPORTE
            RFC = LtRFC.Text
            CVE_OBS = 0
            Try
                If OBSER.Trim.Length > 0 Then
                    CVE_OBS = Val(LtRFC.Tag)
                    CVE_OBS = INSERT_UPDATE_OBS_FAC(CVE_OBS, OBSER)
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
                        SQL = "INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            Math.Round(IMP_TOT1, 6) & "','" & Math.Round(IMP_TOT2, 6) & "','" & Math.Round(DES_FIN, 6) & "','" & Math.Round(COM_TOT, 6) & "','" &
                            ACT_COI & "','" & NUM_MONED & "','" & TIPCAMB & "','" & Math.Round(IMP_TOT3, 6) & "','" & Math.Round(IMP_TOT4, 6) & "','" &
                            Math.Round(PRIMERPAGO, 6) & "','" & RFC & "','" & AUTORIZA & "','" & FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" &
                            ESCFD & "','" & ALMACEN & "','" & ACT_CXC & "','" & TIP_DOC & "','" & CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" &
                            CVE_VEND & "','" & Math.Round(DES_TOT, 6) & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" & DAT_ENVIO & "','" & CONTADO & "','" &
                            DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" & CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" &
                            TIP_DOC_E & "','" & FORMAENVIO & "','" & DES_FIN_PORC & "','" & Math.Round(DES_TOT_PORC, 6) & "','" & Math.Round(IMPORTE, 6) & "','" &
                            Math.Round(COM_TOT_PORC, 6) & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" & TIP_DOC_ANT & "','" & DOC_ANT & "','" &
                            CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',NEWID(), GETDATE())"
                    Else
                        SQL = "IF NOT EXISTS (SELECT CVE_DOC FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " WHERE CVE_DOC = '" & CVE_DOC & "')
                            INSERT INTO FACT" & TIPO_VENTA_LOCAL & Empresa & " (CVE_CLPV, CVE_PEDI, FECHA_DOC, FECHA_ENT, FECHA_VEN, IMP_TOT1, 
                            IMP_TOT2, DES_FIN, COM_TOT, ACT_COI, NUM_MONED, TIPCAMB, IMP_TOT3, IMP_TOT4, PRIMERPAGO, RFC, AUTORIZA, FOLIO, 
                            SERIE, AUTOANIO, ESCFD, NUM_ALMA, ACT_CXC, TIP_DOC, CVE_DOC, CAN_TOT, CVE_VEND, DES_TOT, ENLAZADO, NUM_PAGOS, DAT_ENVIO, 
                            CONTADO, DAT_MOSTR, CVE_BITA, BLOQ, FECHAELAB, CTLPOL, CVE_OBS, STATUS, TIP_DOC_E, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC,
                            IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, DOC_ANT, CONDICION, USO_CFDI, FORMADEPAGOSAT, UUID,
                            VERSION_SINC) VALUES ('" & CLIENTE & "','" & CVE_PEDI & "','" & FECHA_DOC & "','" & FECHA_ENT & "','" & FECHA_VEN & "','" &
                            Math.Round(IMP_TOT1, 6) & "','" & Math.Round(IMP_TOT2, 6) & "','" & Math.Round(DES_FIN, 6) & "','" & Math.Round(COM_TOT, 6) & "','" &
                            ACT_COI & "','" & NUM_MONED & "','" & TIPCAMB & "','" & Math.Round(IMP_TOT3, 6) & "','" & Math.Round(IMP_TOT4, 6) & "','" &
                            Math.Round(PRIMERPAGO, 6) & "','" & RFC & "','" & AUTORIZA & "','" & FOLIO & "','" & SERIE & "','" & AUTOANIO & "','" &
                            ESCFD & "','" & ALMACEN & "','" & ACT_CXC & "','" & TIP_DOC & "','" & CVE_DOC & "','" & Math.Round(CAN_TOT, 6) & "','" &
                            CVE_VEND & "','" & Math.Round(DES_TOT, 6) & "','" & ENLAZADO & "','" & NUM_PAGOS & "','" & DAT_ENVIO & "','" & CONTADO & "','" &
                            DAT_MOSTR & "','" & CVE_BITA & "','" & Bloq & "',GETDATE(),'" & CTLPOL & "','" & CVE_OBS & "','" & STATUS & "','" &
                            TIP_DOC_E & "','" & FORMAENVIO & "','" & Math.Round(DES_FIN_PORC, 6) & "','" & Math.Round(DES_TOT_PORC, 6) & "','" &
                            Math.Round(IMPORTE, 6) & "','" & Math.Round(COM_TOT_PORC, 6) & "','" & METODODEPAGO & "','" & NUMCTAPAGO & "','" &
                            TIP_DOC_ANT & "','" & DOC_ANT & "','" & CONDICION & "','" & USO_CFDI & "','" & FORMADEPAGOSAT & "',
                            NEWID(), GETDATE())"
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

                        If DOC_NEW Then
                            If DOC_ENLAZADO = "S" Then
                                SQL = "UPDATE FACTV" & Empresa & " 
                                    SET ENLAZADO = 'T', TIP_DOC_E = '" & TIPO_VENTA_LOCAL & "', 
                                    TIP_DOC_SIG = '" & TIPO_VENTA_LOCAL & "', DOC_SIG = '" & CVE_DOC & "' 
                                    WHERE CVE_DOC = '" & DOC_ANT & "'"
                                returnValue2 = EXECUTE_QUERY_NET(SQL)

                            End If
                        End If

                        If CHCAMPOLIB_CUADRILLA = 1 Then

                            If TIPO_VENTA_LOCAL = "R" Then
                                For j = 1 To 5
                                    SQL = "INSERT INTO GCCXC_COILSA_REM (CVE_DOC, CVE_DOC_PED, NUM_PAR, STATUS, IMPORTE, CAN_TOT, 
                                        IEPS, ISR, RET, IVA, FECHA, FECHAELAB, UUID)
	                                    VALUES(
                                        @CVE_DOC, @CVE_DOC_PED, ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCCXC_COILSA_REM),1), 'A', @IMPORTE, 
                                        @CAN_TOT, @IEPS, @ISR, @RET, @IVA, @FECHA, GETDATE(), NEWID())"
                                    Try
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                            cmd2.Parameters.Add("@CVE_DOC_PED", SqlDbType.VarChar).Value = LtDocAnt.Text
                                            cmd2.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                                            cmd2.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)
                                            cmd2.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                                            cmd2.Parameters.Add("@ISR", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                                            cmd2.Parameters.Add("@RET", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                                            cmd2.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                                            cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then

                                                End If
                                            End If

                                            Exit For
                                        End Using
                                    Catch ex As Exception
                                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Next

                            End If
                            If TIPO_VENTA_LOCAL = "P" Then

                                For j = 1 To 5
                                    SQL = "IF EXISTS (SELECT CVE_DOC FROM GCCXC_COILSA_PED WHERE CVE_DOC = '" & CVE_DOC & "')
                                    UPDATE GCCXC_COILSA_PED SET IMPORTE = @IMPORTE, CAN_TOT = @CAN_TOT, IEPS = @IEPS, ISR = @ISR, RET = @RET
                                    WHERE CVE_DOC = @CVE_DOC
                                 ELSE
                                    INSERT INTO GCCXC_COILSA_PED (CVE_DOC, STATUS, IMPORTE, CAN_TOT, IEPS, ISR, RET, IVA, FECHA, FECHAELAB, UUID)
	                                VALUES(
                                    @CVE_DOC, 'A', @IMPORTE, @CAN_TOT, @IEPS, @ISR, @RET, @IVA, @FECHA, GETDATE(), NEWID())"
                                    Try

                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                            cmd2.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                                            cmd2.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)
                                            cmd2.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                                            cmd2.Parameters.Add("@ISR", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                                            cmd2.Parameters.Add("@RET", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                                            cmd2.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                                            cmd2.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then

                                                End If
                                            End If
                                        End Using

                                        Exit For
                                    Catch ex As Exception
                                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                Next
                            End If

                        End If

                        Exit For
                    Catch ex As SqlException
                        ' Log the original exception here
                        For Each sqlError As SqlError In ex.Errors
                            Debug.Print(sqlError.Number & ", " & sqlError.ToString)
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
                        BITACORATPV("690. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If DETEC_ERROR_VIOLATION_KEY Then
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
                    End If
                Next

                '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                'CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   CUENTAS X COBRAR   

                Dim Continua As Boolean

                If DOC_ENLAZADO = "S" And TIPO_DOC_ENLAZADO = "V" Then
                    Continua = False
                Else
                    Continua = True
                End If

                '                            F                                  
                If (TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "F") And Continua Then
                    'CUEN M
                    CUEN_M(CVE_DOC, CLIENTE, IMPORTE, CVE_VEND, CVE_BITA, NUM_MONED, txTC.Value)

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
                                    CUEN_DET(CVE_DOC, CVE_DOC, CLIENTE, MONTO, NO_CPTO, CVE_VEND)
                                End If
                            Next
                        Catch ex As Exception
                            BITACORATPV("695. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("695. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            If Ldocu.Tag = "Digital" Then
                                SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", 
                                    FCH_ULTCOM = '" & FECHA_DOC & "', REG_FISC = '" & REG_FISC & "'
                                    WHERE CLAVE = '" & CLIENTE & "'"
                            Else
                                SQL = "UPDATE CLIE" & Empresa & " SET ULT_VENTAD = '" & CVE_DOC & "', ULT_COMPM = " & IMPORTE & ", 
                                    FCH_ULTCOM = '" & FECHA_DOC & "'
                                    WHERE CLAVE = '" & CLIENTE & "'"
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
                            BITACORATPV("700. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS
                        Try
                            If Ldocu.Tag = "Digital" Then
                                SQL = "UPDATE CLIE" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & IMPORTE & ", ULT_VENTAD = '" & CVE_DOC & "', 
                                    ULT_COMPM = " & IMPORTE & ", FCH_ULTCOM = '" & FECHA_DOC & "', REG_FISC = '" & REG_FISC & "'
                                    WHERE CLAVE = '" & CLIENTE & "'"
                            Else
                                SQL = "UPDATE CLIE" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & IMPORTE & ", ULT_VENTAD = '" & CVE_DOC & "', 
                                    ULT_COMPM = " & IMPORTE & ", FCH_ULTCOM = '" & FECHA_DOC & "' 
                                    WHERE CLAVE = '" & CLIENTE & "'"
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
                            BITACORATPV("705. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("705. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Else '          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS          CABEZAS

                    If TIPO_VENTA_LOCAL = "D" And Ldocu.Tag = "Digital" And DOC_NEW Then

                        Dim CVE_DOC_REL As String = ""

                        For k = 0 To aDATA.GetLength(0) - 1
                            If Not IsNothing(aDATA(k, 0)) And Not IsNothing(aDATA(k, 1)) Then
                                If aDATA(k, 0).ToString.Trim.Length > 0 And aDATA(k, 1).ToString.Trim.Length > 0 Then
                                    'SQL = "INSERT INTO CFDI_REL" & Empresa & " (UUID, TIP_REL, CVE_DOC, CVE_DOC_REL, TIP_DOC) 
                                    'VALUES('" & aDATA(k, 1) & "','" & PassData5 & "','" & FCVE_DOC & "','" & aDATA(k, 0) & "','" & FTIPO_DOC & "')"

                                    CVE_DOC_REL = aDATA(k, 0)

                                    Exit For
                                End If
                            End If
                        Next

                        If CVE_DOC_REL.Trim.Length > 0 Then
                            CUEN_DET(CVE_DOC_REL, CVE_DOC, CLIENTE, IMPORTE, NUM_CPTO_NC, CVE_VEND)
                        Else
                            Debug.Print("")
                        End If
                    Else
                        If TIPO_VENTA_LOCAL = "R" And DOC_NEW And DOC_ENLAZADO = "S" Then
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

                        If DOC_ENLAZADO = "S" Then
                            'SQL = "UPDATE FACTP" & Empresa & " SET ACT_COI = 'N', TIP_DOC_E = '" & TIPO_VENTA_LOCAL & "' WHERE CVE_DOC = '" & DOC_ANT & "'"
                            'Using cmd3 As SqlCommand = cnSAE.CreateCommand
                            'cmd3.CommandText = SQL
                            'returnValue = cmd3.ExecuteNonQuery().ToString
                            'If returnValue IsNot Nothing Then
                            'If returnValue = "1" Then
                            'End If
                            'End If
                            'End Using
                        End If
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
                CVE_ART = Fg(k, 4)
                CVE_ESQIMPU = Fg(k, 28)

                If Not IsNothing(Fg(k, 3)) Then
                    ALMACEN_FG = Fg(k, 3)
                    If ALMACEN_FG.Length > 1 Then
                        If IsNumeric(ALMACEN_FG.Substring(0, 2)) Then
                            NUM_ALM = ALMACEN_FG.Substring(0, 2)
                        Else
                            NUM_ALM = ALMACEN
                        End If
                    Else
                        NUM_ALM = ALMACEN
                    End If
                Else
                    NUM_ALM = ALMACEN
                End If

                's &= fCVE_DOC & vbTab '19
                's &= fTIPOC.ToUpper & vbTab '20
                Try 'NUM_PAR
                    If IsNothing(Fg(k, 19)) Then
                        NUM_PAR_ENLAZADO = 1
                    Else
                        If IsNumeric(Fg(k, 19)) Then
                            NUM_PAR_ENLAZADO = Fg(k, 19)
                        End If
                    End If
                    'CVE_DOC ENLAZADO
                    If IsNothing(Fg(k, 20)) Then
                        CVE_DOC_ENLAZADO = ""
                    Else
                        If IsNumeric(Fg(k, 20)) Then
                            CVE_DOC_ENLAZADO = Fg(k, 20)
                        End If
                    End If
                    'tip_doc_enlazado	
                    If IsNothing(Fg(k, 21)) Then
                        ENLACE_TIP_DOC = ""
                    Else
                        If IsNumeric(Fg(k, 21)) Then
                            ENLACE_TIP_DOC = Fg(k, 21)
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
            Continua2 = False
            If CHCAMPOLIB_CUADRILLA = 0 Then
                If CANT > 0 Then
                    Continua2 = True
                End If
            Else
                Continua2 = True
            End If

            If Continua2 And CVE_ART.Trim.Length > 0 Then
                Try
                    SQL = "SELECT UNI_MED, I.CVE_ESQIMPU, ISNULL(I.ULT_COSTO,0) AS ULTCOSTO, ISNULL(I.COSTO_PROM,0) AS COSTOPROM,
                        COALESCE(P.IMPUESTO1,0) AS IMPU1, COALESCE(P.IMPUESTO2,0) AS IMPU2, COALESCE(P.IMPUESTO3,0) AS IMPU3,
                        COALESCE(P.IMPUESTO4,0) AS IMPU4, COALESCE(P.IMP1APLICA,0) AS IMP1APLA, COALESCE(P.IMP2APLICA,0) AS IMP2APLA,
                        COALESCE(P.IMP3APLICA,0) AS IMP3APLA, COALESCE(P.IMP4APLICA,0) AS IMP4APLA, ISNULL(TIPO_ELE,'') AS TIP_ELE,
                        CVE_PRODSERV, CVE_UNIDAD
                        FROM INVE" & Empresa & " I
                        LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                        WHERE CVE_ART = '" & CVE_ART & "'"

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
                                        TIPO_ELEM = "S"
                                    Case "S"
                                        TIPO_PROD = "S"
                                        TIPO_ELEM = "N"
                                    Case Else
                                        TIPO_PROD = "P"
                                        TIPO_ELEM = "N"
                                End Select

                                CVE_PRODSERV = dr2.ReadNullAsEmptyString("CVE_PRODSERV")
                                CVE_UNIDAD = dr2.ReadNullAsEmptyString("CVE_UNIDAD")
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If CVE_ESQIMPU > 0 Then
                        SQL = "SELECT COALESCE(P.IMPUESTO1,0) AS IMPU1, COALESCE(P.IMPUESTO2,0) AS IMPU2, COALESCE(P.IMPUESTO3,0) AS IMPU3,
                            COALESCE(P.IMPUESTO4,0) AS IMPU4, COALESCE(P.IMP1APLICA,0) AS IMP1APLA, COALESCE(P.IMP2APLICA,0) AS IMP2APLA,
                            COALESCE(P.IMP3APLICA,0) AS IMP3APLA, COALESCE(P.IMP4APLICA,0) AS IMP4APLA
                            FROM IMPU" & Empresa & " P 
                            WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            cmd2.CommandText = SQL
                            Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                If dr2.Read Then
                                    IMPU1 = dr2("IMPU1")
                                    IMPU2 = dr2("IMPU2")
                                    IMPU3 = dr2("IMPU3")
                                    IMPU4 = dr2("IMPU4")
                                    IMP1APLA = dr2("IMP1APLA")
                                    IMP2APLA = dr2("IMP2APLA")
                                    IMP3APLA = dr2("IMP3APLA")
                                    IMP4APLA = dr2("IMP4APLA")
                                    CVE_ESQ = CVE_ESQIMPU
                                End If
                            End Using
                        End Using
                    End If
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
                    cImpu2 = ImporteConDes * IMPU2 / 100
                    cImpu3 = ImporteConDes * IMPU3 / 100

                    If IMPU1 > 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 > 0 Then
                        cImpu4 = (ImporteConDes + cImpu1) * IMPU4 / 100
                    Else
                        cImpu4 = ImporteConDes * IMPU4 / 100
                    End If

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
                    If Fg(k, 23).ToString.Trim.Length > 0 Then
                        CVE_OBS = INSERT_UPDATE_OBS_FAC(Val(Fg(k, 22)), Fg(k, 23))
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
                        MTO_CUOTA, DESCR_ART, CVE_ESQ, CVE_PRODSERV, CVE_UNIDAD, UUID) VALUES('" & CVE_DOC & "','" & NUM_PAR & "','" &
                        CVE_ART & "','" & Math.Round(CANT, 6) & "','" & Math.Round(CANT, 6) & "','" & Math.Round(PREC, 6) & "','" &
                        Math.Round(COST, 6) & "','" & IMPU1 & "','" & IMPU2 & "','" & IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" &
                        IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" & Math.Round(TOTIMP1, 6) & "','" & Math.Round(TOTIMP2, 6) & "','" &
                        Math.Round(TOTIMP3, 6) & "','" & Math.Round(TOTIMP4, 6) & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" &
                        COMI & "','" & APAR & "','" & ACT_INV & "','" & NUM_ALM & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_MED & "','" &
                        TIPO_PROD & "','" & CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','" & TIPO_ELEM & "','0','" & Math.Round(TOT_PARTIDA, 6) &
                        "','S',GETDATE(),'" & MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" &
                        MTO_CUOTA & "','" & CVE_DOC_ENLAZADO & "','" & CVE_ESQ & "','" & CVE_PRODSERV & "','" & CVE_UNIDAD & "',NEWID())"
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
                        GRABAR_CAMPLIB_PAR(CVE_DOC, NUM_PAR, CVE_DOC_ENLAZADO)
                    Catch ex As Exception
                        BITACORATPV("780. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    If TIPO_PROD = "K" And DOC_NEW Then
                        NUM_PAR += 1
                        NUM_PAR_KIT = NUM_PAR
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
                                         "MTO_PORC, MTO_CUOTA, UUID, CVE_PRODSERV, CVE_UNIDAD) VALUES('" & CVE_DOC & "','" & NUM_PAR_KIT & "','" & CVE_PROD & "','" &
                                         CANT_KIT & "','" & CANT_KIT & "','" & PRECIO_KIT & "','" & dr("ULTCOSTO") & "','" & IMPU1 & "','" & IMPU2 & "','" &
                                         IMPU3 & "','" & IMPU4 & "','" & IMP1APLA & "','" & IMP2APLA & "','" & IMP3APLA & "','" & IMP4APLA & "','" & TOTIMP1 & "','" &
                                         TOTIMP2 & "','" & TOTIMP3 & "','" & TOTIMP4 & "','" & DESC1 & "','" & DESC2 & "','" & DESC3 & "','" & COMI & "','" &
                                         APAR & "','" & ACT_INV & "','" & NUM_ALM & "','" & POLIT_APLI & "','" & TIP_CAM & "','" & UNI_VENTA & "','" & TIPO_PROD & "','" &
                                         CVE_OBS & "','" & REG_SERIE & "','" & E_LTPD & "','S','0','" & ImporteConDes & "','S',GETDATE(),'" &
                                         MAN_IEPS & "','" & APL_MAN_IMP & "','" & CUOTA_IEPS & "','" & APL_MAN_IEPS & "','" & MTO_PORC & "','" & MTO_CUOTA & "','" &
                                         CVE_PRODSERV & "','" & CVE_UNIDAD & "',NEWID())"

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


                                    Dim EXI_INI2 As Decimal = 0
                                    EXI_INI2 = OBTENER_EXISTENCIA(CVE_PROD, NUM_ALM)

                                    If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "R" Or TIPO_VENTA_LOCAL = "F" Then
                                        'AFECTANDO INVENTARIO MINVE Y INVE
                                        's &= fCVE_DOC & vbTab '19
                                        's &= fTIPOC.ToUpper & vbTab '20

                                        '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                                        Try
                                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                SQL = "UPDATE INVE" & Empresa & " Set EXIST = COALESCE(EXIST,0) - " & CANT_KIT &
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
                                                    " WHERE CVE_ART = '" & CVE_PROD & "' AND CVE_ALM = " & NUM_ALM
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
                                            CVE_PROD & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & NUM_ALM & ")
                                            INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL, 
                                            EXIINI, EXIFIN)
                                            VALUES ('" & CVE_PROD & "','" & NUM_ALM & "','" & NUM_MOV_KIT & "','" & CVE_CPTO & "','" & FECHA_DOC & "','" &
                                            TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" & CANT_KIT & "','" &
                                            CANT_KIT & "','" & PRECIO_KIT & "','" & COST & "','" & REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "'," &
                                            "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "')," 'EXIST_G
                                        If MULTIALMACEN = 1 Then
                                            SQL &= "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "' AND 
                                                CVE_ALM = " & NUM_ALM & "),0),'"   'EXISTENCIA
                                        Else
                                            SQL &= "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_PROD & "'),'"  'EXISTENCIA
                                        End If
                                        SQL &= TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " 
                                            WHERE ID_TABLA = 32),'" &
                                             SIGNO & "','" & COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" &
                                             MOV_ENLAZADO & "','" & COSTO_PROM_GRAL & "','" & EXI_INI2 & "','" & (EXI_INI2 - CANT) & "')"
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

                    If DOC_ENLAZADO = "S" Then
                        SIGUE = False
                    Else
                        SIGUE = True
                    End If

                    Dim EXI_INI As Decimal = 0
                    EXI_INI = OBTENER_EXISTENCIA(CVE_ART, NUM_ALM)

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
                                    SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) - " & CANT & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM
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
                            REFER = '" & CVE_DOC & "' AND CVE_ART = '" & CVE_ART & "' AND CVE_CPTO = " & CVE_CPTO & " AND ALMACEN = " & NUM_ALM & ")
                            INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL, 
                            EXIINI, EXIFIN)
                            VALUES('" &
                            CVE_ART & "','" & NUM_ALM & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" &
                            CVE_CPTO & "','" & FECHA_DOC & "','" & TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLIENTE & "','" & CVE_VEND & "','" &
                            Math.Round(CANT, 6) & "','" & Math.Round(CANT, 6) & "','" & Math.Round(PREC, 6) & "','" & Math.Round(COST, 6) & "','" &
                            REG_SERIE & "','" & UNI_MED & "','" & E_LTPD & "',(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                        If MULTIALMACEN = 1 Then
                            SQL &= "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & NUM_ALM & "),0),'"   'EXISTENCIA
                        Else
                            SQL &= "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                        End If
                        SQL &= TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                            SIGNO & "','" & COSTEADO & "','" & Math.Round(COSTO_PROM_INI, 6) & "','" & Math.Round(COSTO_PROM_FIN, 6) & "','" & DESDE_INVE & "','" &
                            MOV_ENLAZADO & "','" & Math.Round(COSTO_PROM_GRAL, 6) & "','" & EXI_INI & "','" & (EXI_INI - CANT) & "')"
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
                        'CON LOTE
                        If Fg(k, 23) = "S" Then

                            SQL = "UPDATE LTPD" & Empresa & " SET CANTIDAD = CANTIDAD - " & Math.Round(CANT, 4) & " 
                                 WHERE LOTE = '" & Fg(k, 24) & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        End If

                    Catch ex As Exception
                        BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try

                    Try
                        '===============================================================================================
                        'DOC ENLAZADO
                        If DOC_ENLAZADO = "S" And DOC_NEW Then
                            Try
                                CVE_DOC_ENLAZADO = Fg(k, 20)
                                NUM_PAR_ENLAZADO = Fg(k, 19)
                                ENLACE_TIP_DOC = Fg(k, 21)
                            Catch ex As Exception
                            End Try

                            If TIPO_PROD = "K" Then
                                NUM_PAR_KIT = NUM_PAR + 1
                                'KITS           KITS            KITS           KITS            KITS           KITS
                                'KITS           KITS            KITS           KITS            KITS           KITS
                                'KITS           KITS            KITS           KITS            KITS           KITS
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
                                                    'KITS           KITS            KITS           KITS            KITS           KITS
                                                    'KITS           KITS            KITS           KITS            KITS           KITS
                                                    'KITS           KITS            KITS           KITS            KITS           KITS
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
                                                'KITS           KITS            KITS           KITS            KITS           KITS
                                                'KITS           KITS            KITS           KITS            KITS           KITS
                                                'KITS           KITS            KITS           KITS            KITS           KITS
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
                                                'KITS           KITS            KITS           KITS            KITS           KITS
                                                'KITS           KITS            KITS           KITS            KITS           KITS
                                                'KITS           KITS            KITS           KITS            KITS           KITS
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
                                    'KITS           KITS            KITS           KITS            KITS           KITS
                                    'KITS           KITS            KITS           KITS            KITS           KITS
                                    'KITS           KITS            KITS           KITS            KITS           KITS
                                Catch ex As Exception
                                    BITACORATPV("860. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("860. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                                ' FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S    
                                ' FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S     FIN KITS'S    

                            Else
                                'ACTUALIZAR DOC SIG ENLAZADO NO KIT     NO KIT     NO KIT
                                ' NO KIT     NO KIT     NO KIT     NO KIT     NO KIT
                                Try
                                    ANT_SIG = "S"
                                    SQL = "INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E, CANT_E) 
                                        VALUES('" & ENLACE_TIP_DOC & " ','" & CVE_DOC_ENLAZADO & "','" & ANT_SIG & "','" & TIP_DOC & "','" & CVE_DOC & "','" &
                                        NUM_PAR_ENLAZADO & "','" & NUM_PAR & "','" & CANT & "')"
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
                                    SQL = "INSERT INTO DOCTOSIGF" & Empresa & " (TIP_DOC, CVE_DOC, ANT_SIG, TIP_DOC_E, CVE_DOC_E, PARTIDA, PART_E, CANT_E) 
                                        VALUES('" & TIP_DOC & "','" & CVE_DOC & "','" & ANT_SIG & "','" & ENLACE_TIP_DOC & "','" & CVE_DOC_ENLAZADO & "','" &
                                        NUM_PAR & "','" & NUM_PAR_ENLAZADO & "','" & CANT & "')"

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
                                        SQL = "UPDATE PAR_FACT" & TIP_DOC_ANT & Empresa & " SET PXS = PXS - " & CANT & " WHERE " &
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
                                End Try
                            End If
                        End If
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
                'ENLAZAR_CVE_DOC_UPDATE_DOC_SIG(TIP_DOC_ANT, CVE_DOC)
            End If
        End If

        Try
            'INICIO GRABADO DE CAMPOS LIBRES CABEZAS
            'aLIB1(k, 0) = Fg(k, 1) 'CAMPO
            'aLIB1(k, 1) = Fg(k, 3) 'DATO CAPTURADO
            '████████████████████████████████████████████████████████████ CAMPOS LIBRES ONBSERVACIONES ██████████████████████████████████████████████████████████████████████████
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
                GRABA_BITA(TCLIENTE.Text, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, MODO_EDIT & " cotización " & IIf(LtDocAnt.Text.Trim.Length > 0,
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

                Dim d1 As DateTime = F1.Value
                Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")

                If cbRegimenesFiscales.SelectedItem IsNot Nothing Then REG_FISC = (CType(cbRegimenesFiscales.SelectedItem, cRegimenFiscal)).RegimenFiscal
                USO_CFDI = cbUsoCfdi.Items(cbUsoCfdi.SelectedIndex).ToString.Substring(0, 3)

                MONEDA = CboMoneda.SelectedItem

                METODODEPAGO = (CType(cbMetodoPago.SelectedItem, cMetodoPago)).MetodoPago
                FORMAPAGO = (CType(cbFormaPago.SelectedItem, cFormaPago)).FormaPago

                TimbrarDigiBoxNC(CVE_DOC, DOC_ENLAZADO, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, IMPORTE, TCLIENTE.Text, LtNombre.Text, FECHA_CERT,
                                LtRFC.Text, LtCP.Text)
            End If

            PassData1 = "DEVOLUCION CFDI"
            Var4 = CVE_DOC
            Var5 = LtCorreo.Text  'CORREO
            Var18 = ""
            Var16 = ""

            IMPRIMIR_CFDI_DIRECTO(CVE_DOC, "PDF", PassData8, RFC)
            ' INICA PROCESO DE TIMBRAR 
            'FrmTimbrarCdeP.LtNombre.Text = LtNombre.Text
            'FrmTimbrarCdeP.LtRFC.Text = LtRFC.Text
            'FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
            'FrmTimbrarCdeP.LtRegimenReceptor.Text = REG_FISC
            'FrmTimbrarCdeP.LtCP.Text = LtCP.Text
            'FrmTimbrarCdeP.ShowDialog()
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
                'ENLAZADO ='T', TIP_DOC_E='F', TIP_DOG_SIG='F', DOC_SIG='F001'
                Dim DOCU As String

                If LtDocAnt.Text.Length > 20 Then
                    DOCU = LtDocAnt.Text.Substring(1, 20)
                Else
                    DOCU = LtDocAnt.Text
                End If

                SQL = "UPDATE FACT" & DOCUMENT_ENLAZADO & Empresa & " 
                    SET ENLAZADO = 'T', TIP_DOC_E = 'F', TIP_DOC_SIG = 'F', DOC_SIG = '" & CVE_DOC & "' 
                    WHERE CVE_DOC = '" & DOCU & "'"
                returnValue2 = EXECUTE_QUERY_NET(SQL)

                PassData1 = "FACTURA"
                GRABAR_CFDI_REL("F", CVE_DOC)


                '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
                ' INICA PROCESO DE TIMBRAR 
                'FrmTimbrarCdeP.LtNombre.Text = LtNombre.Text
                'FrmTimbrarCdeP.LtRFC.Text = LtRFC.Text
                'FrmTimbrarCdeP.LtUSO_CFDI.Text = USO_CFDI
                'FrmTimbrarCdeP.LtRegimenReceptor.Text = REG_FISC
                'FrmTimbrarCdeP.LtCP.Text = LtCP.Text

                'FrmTimbrarCdeP.ShowDialog()

                PassData8 = "FACTURA"

                IMPRIMIR_CFDI_DIRECTO(CVE_DOC, "PDF", PassData8, RFC)

                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)
                LIMPIAR()
                If Var18 = "SI" Then
                    FILE_PDF = Var16
                    If File.Exists(Var16) Then
                        FrmOPenPDFGrapecity.Show()
                    End If
                End If
            Else
                'FTIPO_DOC As String, FSERIE As String, FCVE_DOC As String, FPROC As String, FIMPORTE As Decimal, Optional NUM_LETRA As String = "")

                GEN_IMPRIMIR_TICKET(TIPO_VENTA_LOCAL, LETRA_VENTA, CVE_DOC, "FrmTPV", IMPORTE, "", COPIAS_TK_NV)

                'IMPRIMIR_VENTA(CVE_DOC)

                LtCVE_DOC.Text = SIGUIENTE_CVE_DOC_FACTURA(TIPO_VENTA_LOCAL, LETRA_VENTA)
                LIMPIAR()

            End If
        End If

        cnSAE.Close()

        If Not Valida_Conexion() Then
            Return
        End If


    End Sub
    Sub ENLAZAR_CVE_DOC_UPDATE_DOC_SIG(FTIP_DOC_SIG As String, FCVE_DOC As String)
        Try
            For k = 0 To UBound(aDOCS)
                If aDOCS(k).ToString.Length > 0 Then

                    SQL = "UPDATE FACT" & FTIP_DOC_SIG & Empresa & " SET ACT_COI = 'N', 
                          DOC_SIG = '" & FCVE_DOC & "', TIP_DOC_SIG = '" & TIPO_VENTA_LOCAL & "', ENLAZADO = 'T',
                          TIP_DOC_E = '" & TIPO_VENTA_LOCAL & "' WHERE CVE_DOC = '" & aDOCS(k) & "'"
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
                    End Try
                End If
            Next
        Catch ex As Exception
            'BITACORATPV("1990. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1990. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
                                    VALUES('" & aDATA(k, 1) & "','" & PassData5 & "','" & FCVE_DOC & "','" & aDATA(k, 0) & "','" & FTIPO_DOC & "')"

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
        Dim CADENA_PAR As String, j As Integer, CAEDENA As String, CVE_DOC_P As String, OBRA As String
        Try
            If DOC_NEW Then
                CVE_DOC_P = LUUID
            Else
                CVE_DOC_P = LtCVE_DOC.Text
            End If

            j = 2
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLIB_FACTP WHERE CLAVE_DOC = '" & CVE_DOC_P & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CADENA_PAR = "UPDATE FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " SET "
                            For k = 1 To dr.FieldCount - 2 Step 3

                                If dr.GetName(k) = "CAMPLIB2" Then
                                    OBRA = dr(dr.GetName(k))
                                    If OBRA.Length > 10 Then
                                        OBRA = OBRA.Substring(0, 20).Trim
                                    End If
                                Else
                                    OBRA = dr(dr.GetName(k))
                                End If
                                CADENA_PAR &= dr.GetName(k) & " = '" & OBRA & "', "

                                j += 3
                            Next
                            CADENA_PAR = CADENA_PAR.Substring(0, CADENA_PAR.Length - 2) & " WHERE CLAVE_DOC = '" & FCVE_DOC & "'"

                            CAEDENA = "INSERT INTO FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " (CLAVE_DOC"
                            For k = 1 To dr.FieldCount - 2 Step 3
                                CAEDENA &= ", " & dr.GetName(k)
                            Next

                            CAEDENA += ") VALUES ('" & FCVE_DOC
                            For k = 1 To dr.FieldCount - 2 Step 3

                                If dr.GetName(k) = "CAMPLIB2" Then
                                    OBRA = dr(dr.GetName(k))
                                    If OBRA.Length > 10 Then
                                        OBRA = OBRA.Substring(0, 20).Trim
                                    End If
                                Else
                                    OBRA = dr(dr.GetName(k))
                                End If
                                CAEDENA += "','" & OBRA

                            Next
                            CAEDENA += "')"

                            SQL = "SET ansi_warnings OFF 
                                 IF EXISTS (SELECT CLAVE_DOC FROM FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " WHERE CLAVE_DOC = '" & FCVE_DOC & "') " & vbNewLine &
                                CADENA_PAR & vbNewLine & "
                                ELSE" & vbNewLine &
                                    CAEDENA

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            BITACORATPV("175. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Sub GRABAR_CAMPLIB_PAR(FCVE_DOC As String, FNUM_PAR As Integer, FDOC_ENLAZADO As String)
        Dim CADENA_PAR As String, j As Integer, CAEDENA As String, CVE_DOC_P As String

        If DOC_NEW Then
            CVE_DOC_P = LUUID
        Else
            CVE_DOC_P = LtCVE_DOC.Text
        End If

        Try
            j = 2
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLIB_PAR_P WHERE CLAVE_DOC = '" & CVE_DOC_P & "' AND NUM_PART = " & FNUM_PAR & " ORDER BY NUM_PART"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Try
                            CADENA_PAR = "UPDATE PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " SET "

                            If EXIST_FIELD_SQL_SAE("PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa, dr.GetName(j)) Then
                                For k = 2 To dr.FieldCount - 3 Step 3
                                    CADENA_PAR &= dr.GetName(j) & " = '" & dr(dr.GetName(j)) & "', "
                                    j += 3
                                Next
                                CADENA_PAR = CADENA_PAR.Substring(0, CADENA_PAR.Length - 2) & " WHERE CLAVE_DOC = '" & FCVE_DOC & "' AND NUM_PART = " & FNUM_PAR

                                CAEDENA = "INSERT INTO PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " (CLAVE_DOC, NUM_PART"
                                For k = 2 To dr.FieldCount - 3 Step 3
                                    CAEDENA &= ", " & dr.GetName(k)
                                Next

                                CAEDENA += ") VALUES ('" & FCVE_DOC & "','" & dr("NUM_PART")

                                For k = 2 To dr.FieldCount - 3 Step 3
                                    CAEDENA += "','" & dr(dr.GetName(k))
                                Next
                                CAEDENA += "')"


                                SQL = "SET ansi_warnings OFF 
                                IF EXISTS (SELECT CLAVE_DOC FROM PAR_FACT" & TIPO_VENTA_LOCAL & "_CLIB" & Empresa & " WHERE CLAVE_DOC = '" & FCVE_DOC & "' AND NUM_PART = " & FNUM_PAR & ")" & vbNewLine &
                                       CADENA_PAR & vbNewLine & "
                                ELSE" & vbNewLine &
                                       CAEDENA

                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then

                                        End If
                                    End If
                                End Using
                            End If
                        Catch ex As Exception
                            BITACORATPV("175. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End While
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub TimbrarDigiBoxFactura(FCVE_DOC As String, FSERIE As String, FCLIENTE As String,
                                      FCAN_TOT As Decimal, FIMP_TOT3 As Decimal, FIMP_TOT4 As Decimal, FIMPORTE As Decimal)

        Dim d1 As DateTime = F1.Value
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")
        Dim aCORREOS(0) As String
        Dim RutaXML_NO_TIMBRADO As String = gRutaXML_NO_TIMBRADO & "\" & EMISORRFC & "_" & FCVE_DOC & ".xml"
        Dim RutaXML_TIMBRADO As String = gRutaXML_TIMBRADO & "\" & EMISORRFC & "_" & FCVE_DOC & ".xml"
        Dim rutaPFX As String = gRutaPFX
        Dim rutaCertificado As String = gRutaCertificado, USUARIO_TIMB As String, PASS_TIMB As String
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
            Dim c As New CfdiRelacionado()

            _c.CfdiRelacionados.TipoRelacion = "07"
            c.UUID = LtUUID.Text
            _c.CfdiRelacionados.CfdiRelacionado.Add(c)

        End If

        CFDI_XML_DIGIBOX = ""

        Dim xml As XmlDocument = GenerarXML.ObtenerXML(_c, rutaPFX, gContraPFX, rutaCertificado)
        xml.Save(RutaXML_NO_TIMBRADO)


        If Timbrar.TimbrarDIGIBOX(RutaXML_NO_TIMBRADO, RutaXML_TIMBRADO, USUARIO_TIMB, PASS_TIMB) Then


            CreaPDF.Generar(RutaXML_TIMBRADO, rutaPDF, Application.StartupPath & "\logo.jpg", False)

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
                        cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = "@"
                        cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = "@"
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

                    For Each SSS In SQLex.Errors
                        Sqlcadena += SSS.Message & vbNewLine
                    Next
                    BITACORASQL("685. Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
                Catch ex As Exception
                    BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            SQL = "UPDATE CLIE" & Empresa & " SET USO_CFDI = '" & USO_CFDI & "', REG_FISC = '" & REG_FISC & "', 
                FORMADEPAGOSAT = '" & FORMAPAGO & "', METODODEPAGO = '" & METODODEPAGO & "' WHERE CLAVE = '" & FCLIENTE & "'"
            EXECUTE_QUERY_NET(SQL)
        End If

    End Sub

    Sub CARGAR_CONCEPTOS_FACTURA(ByVal FCVE_DOC As String, FTIPO_DOC As String)

        Dim DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, IMPU4 As Decimal, CVE_PRODSERV As String
        Dim CVE_UNIDAD As String, DESCR As String, UNI_MED As String, ObjetoImp As String

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

                        If IMPU1 = 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 = 0 Then
                            ObjetoImp = "01"
                        Else
                            ObjetoImp = "02"
                        End If


                        Dim c As New Concepto With {
                                .Cantidad = dr("CANT"),
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = DESCR,
                                .Descuento = DESC1,
                                .Importe = dr("TOT_PARTIDA"),
                                .NoIdentificacion = dr("CVE_ART"),
                                .Unidad = UNI_MED,
                                .ValorUnitario = PRECIO,
                                .Impuestos = GetImpuestosConcepto(PRECIO, 1, DESC1, IMPU1, IMPU2, IMPU3, IMPU4),
                                .ObjetoImp = ObjetoImp}
                        _c.Conceptos.Concepto.Add(c)

                    End While
                End Using
            End Using

            CalculaTotales()

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTimbrarNC_Click(sender As Object, e As EventArgs) Handles BarTimbrarNC.Click
        Dim CLAVE As String, RFC As String
        Dim d1 As DateTime = F1.Value
        Dim FECHA_CERT As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT F.CAN_TOT, F.IMP_TOT1, F.IMP_TOT2, F.IMP_TOT3, F.IMP_TOT4, F.IMPORTE, CVE_CLPV, C.NOMBRE,
                    C.RFC, CODIGO, REG_FISC, M.CVE_MONED AS MONEDA, F.USO_CFDI, F.METODODEPAGO, F.FORMADEPAGOSAT AS FORMAPAGO
                    FROM FACTD" & Empresa & " F 
                    LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = F.CVE_CLPV
                    LEFT JOIN MONED" & Empresa & " M ON M.NUM_MONED = F.NUM_MONED
                    WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        CLAVE = dr("CVE_CLPV")
                        RFC = dr("RFC")
                        CP_ASEGURAMEDAMBIENTE = dr("CODIGO")
                        REG_FISC = dr("REG_FISC")
                        USO_CFDI = dr("USO_CFDI")
                        MONEDA = dr("MONEDA")
                        METODODEPAGO = dr("METODODEPAGO")
                        If METODODEPAGO = "PPD" Then
                            FORMAPAGO = "99"
                        Else
                            FORMAPAGO = dr("FORMAPAGO")
                        End If


                        TimbrarDigiBoxNC(LtCVE_DOC.Text, "", dr("CAN_TOT"), dr("IMP_TOT1"), dr("IMP_TOT2"), dr("IMP_TOT3"), dr("IMP_TOT4"),
                                         dr("IMPORTE"), CLAVE, dr("NOMBRE"), FECHA_CERT, RFC, dr("CODIGO"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub TimbrarDigiBoxNC(FCVE_DOC As String, FDOC_ENLAZADO As String, FCAN_TOT As Decimal, FIMP_TOT1 As Decimal,
                                 FIMP_TOT2 As Decimal, FIMP_TOT3 As Decimal, FIMP_TOT4 As Decimal, FIMPORTE As Decimal,
                                 FCLIENTE As String, FNOMBRE As String, BFECHA As String, BRFC_CTE As String, BCP_CTE As String)

        Dim USUAARIO_TIMB As String, PASS_TIMB As String, TimbreOK As Boolean = False
        Dim DETEC_ERROR_VIOLATION_KEY As Boolean, UUID_TIMBRADO As String
        Dim FECHA_T1 As DateTime
        Dim d1 As DateTime = F1.Value
        Dim FECHA_T2 As String = d1.ToString("yyyy/MM/ddTHH:mm:ss")

        Me.Cursor = Cursors.WaitCursor

        _c = New Comprobante()

        GET_PARAM_CFDI("E", BFECHA, LETRA_VENTA, FOLIO_VENTA, REG_FISC, USO_CFDI, MONEDA, METODODEPAGO, FORMAPAGO, FNOMBRE, BRFC_CTE, BCP_CTE)

        If Not CARGAR_CONCEPTOS_NC(FCVE_DOC) Then
            MsgBox("No se encontraron partidas verifique por favor")
            Return
        End If

        AGREGA_CFDIRELACIONADOS(FCVE_DOC)

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


                'Dim userDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                'Dim fullPath = Path.Combine(userDesktop, RutaXML_NO_TIMBRADO)

                If Not Directory.Exists(gRutaXML_TIMBRADO) Then
                    Directory.CreateDirectory(gRutaXML_TIMBRADO)
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
                TimbreOK = True

                Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = "" : Var12 = "" : Var13 = "" : Var14 = "" : Var15 = ""
                UUID_TIMBRADO = BUSCAR_CAMPOS_CFDI40(RutaXML_TIMBRADO)
                Try
                    Var7 = Var10.Substring(8, 2) & "/" & Var10.Substring(5, 2) & "/" & Var10.Substring(0, 4) & " " & Var10.Substring(11, Var10.Length - 11)
                    Var8 = Var10.Substring(0, 4) & Var10.Substring(5, 2) & Var10.Substring(8, 2) & " " & Var10.Substring(11, Var10.Length - 11)
                    Dim oDate1 As DateTime = DateTime.ParseExact(Var7, "dd/MM/yyyy HH:mm:ss", Nothing)

                    FECHA_T1 = oDate1
                    FECHA_T2 = Var8

                Catch ex As Exception
                    MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try

                If Var10.Trim.Length < 10 Then
                    FECHA_T2 = d1.ToString("yyyy/MM/ddTHH:mm:ss")
                End If
                'Var9 = NO_CERTIFICADO
                'Var10 = FECHA_TIMBRADO
                'Var11 = FECHA_EXP
                'Var12 = SELLO_SAT
                'Var13 = NO_CERTIFICADO_SAT
                'Var14 = SELLO_CFD
                'Var15 = RfcProvCertif

                SQL = "INSERT INTO CFDI (FACTURA, TDOC, DOCUMENT, DOCUMENT2, VERSION, SERIE, FECHA_CERT, XML, TIMBRADO, USUARIO, 
                        CLIENTE,SUBTOTAL, RETENCION, IVA, IMPORTE, USO_CFDI, MONEDA, METODODEPAGO, FORMADEPAGOSAT, FECHAELAB, UUID, 
                        NO_CERTIFICADO, SELLO_SAT, SELLO_CFD, NO_CERTIFICADO_SAT, RFCPROVCERTIF, UUID_CFDI, FECHA_TIMBRADO, FECHA_CFDI) 
                        VALUES (
                        @FACTURA, @TDOC, @DOCUMENT, @DOCUMENT2, @VERSION, @SERIE, @FECHA_CERT, @XML, @TIMBRADO, @USUARIO, @CLIENTE,
                        @SUBTOTAL, @RETENCION, @IVA, @IMPORTE, @USO_CFDI, @MONEDA, @METODODEPAGO, @FORMADEPAGOSAT, GETDATE(), NEWID(), 
                        @NO_CERTIFICADO, @SELLO_SAT, @SELLO_CFD, @NO_CERTIFICADO_SAT, @RFCPROVCERTIF, @UUID_CFDI, @FECHA_TIMBRADO, @FECHA_CFDI)"

                For k = 1 To 5
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = FCVE_DOC
                            cmd.Parameters.Add("@TDOC", SqlDbType.VarChar).Value = "D"
                            cmd.Parameters.Add("@DOCUMENT", SqlDbType.VarChar).Value = "@"
                            cmd.Parameters.Add("@DOCUMENT2", SqlDbType.VarChar).Value = "@"
                            cmd.Parameters.Add("@VERSION", SqlDbType.VarChar).Value = "4.0"
                            cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_VENTA
                            cmd.Parameters.Add("@FECHA_CERT", SqlDbType.VarChar).Value = Var10
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
                            cmd.Parameters.Add("@NO_CERTIFICADO", SqlDbType.VarChar).Value = Var9
                            cmd.Parameters.Add("@SELLO_SAT", SqlDbType.VarChar).Value = Var12
                            cmd.Parameters.Add("@SELLO_CFD", SqlDbType.VarChar).Value = Var14
                            cmd.Parameters.Add("@NO_CERTIFICADO_SAT", SqlDbType.VarChar).Value = Var13
                            cmd.Parameters.Add("@RFCPROVCERTIF", SqlDbType.VarChar).Value = Var15
                            cmd.Parameters.Add("@UUID_CFDI", SqlDbType.VarChar).Value = UUID_TIMBRADO
                            cmd.Parameters.Add("@FECHA_TIMBRADO", SqlDbType.VarChar).Value = Var10
                            cmd.Parameters.Add("@FECHA_CFDI", SqlDbType.DateTime).Value = FECHA_T1
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If

                        End Using
                    Catch ex As SqlException
                        ' Log the original exception here
                        For Each sqlError As SqlError In ex.Errors
                            Debug.Print(sqlError.Number & ", " & sqlError.ToString)
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
                        BITACORATPV("1740. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Next
                Var8 = ""

                MsgBox("Documento timbrado")

                PassData1 = "CFDI Nota de crédito"
                IMPRIMIR_CFDI_40(FCVE_DOC, "NOTA DE CREDITO")

            Else
                MsgBox("!!! Documento no timbrado !!!")
            End If
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
    Sub GET_PARAM_CFDI(FTIPO_COMPROBANTE As String, FECHA As String, FSERIE As String, FFOLIO As Long, FREGIMEN_FISCAL As String,
                       FUSO_CFDI As String, FMONEDA As String, FMETODODEPAGO As String, FFORMAPAGO As String,
                       FNOMBRE As String, FRFC As String, FCP As String)

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
                        gPASS_PAC = dr("PASS")
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

                        Try
                            If gRutaXML_TIMBRADO.Trim.Length = 0 Then
                                gRutaXML_TIMBRADO = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                            End If
                            If gRutaXML_NO_TIMBRADO.Trim.Length = 0 Then
                                gRutaXML_NO_TIMBRADO = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                            End If
                        Catch ex As Exception

                        End Try

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


            _c.TipoDeComprobante = FTIPO_COMPROBANTE
            _c.Moneda = FMONEDA
            _c.MetodoPago = FMETODODEPAGO
            _c.FormaPago = FFORMAPAGO

            _c.Exportacion = "01"

            _c.Receptor.Nombre = FNOMBRE
            _c.Receptor.Rfc = FRFC

            _c.Receptor.DomicilioFiscalReceptor = FCP
            _c.Receptor.RegimenFiscalReceptor = FREGIMEN_FISCAL
            _c.Receptor.UsoCFDI = USO_CFDI


        Catch ex As Exception
            BITACORATPV("1000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function CARGAR_CONCEPTOS_NC(ByVal FCVE_DOC As String) As Boolean

        Dim DESC1 As Decimal, PRECIO As Decimal, IMPU1 As Decimal, IMPU2 As Decimal, IMPU3 As Decimal
        Dim IMPU4 As Decimal, CVE_PRODSERV As String, CVE_UNIDAD As String, DESCR As String, UNI_MED As String
        Dim q As Integer = 0, ObjetoImp As String

        Try
            SQL = "SELECT P.CVE_ART, P.CANT, P.PREC, DESC1, ISNULL(DESCR,'') AS DES, UNI_MED, P.IMPU1, P.IMPU2, 
                P.IMPU3, P.IMPU4, P.TOT_PARTIDA, I.CVE_PRODSERV, I.CVE_UNIDAD
                FROM PAR_FACTD" & Empresa & " P
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

                        DESC1 = dr("DESC1")
                        PRECIO = dr("PREC")

                        If IMPU1 = 0 And IMPU2 = 0 And IMPU3 = 0 And IMPU4 = 0 Then
                            ObjetoImp = "01"
                        Else
                            ObjetoImp = "02"
                        End If

                        Dim c As New Concepto With {
                                .Cantidad = dr("CANT"),
                                .ClaveProdServ = CVE_PRODSERV,
                                .ClaveUnidad = CVE_UNIDAD,
                                .Descripcion = DESCR,
                                .Descuento = DESC1,
                                .Importe = dr("TOT_PARTIDA"),
                                .NoIdentificacion = dr("CVE_ART"),
                                .Unidad = UNI_MED,
                                .ValorUnitario = PRECIO,
                                .Impuestos = GetImpuestosConcepto(PRECIO, 1, DESC1, IMPU1, IMPU2, IMPU3, IMPU4),
                                .ObjetoImp = ObjetoImp}

                        _c.Conceptos.Concepto.Add(c)
                        q += 1
                    End While
                End Using
            End Using

            If q > 0 Then
                CalculaTotales()
            End If

        Catch ex As Exception
            MsgBox("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("1745. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If q = 0 Then
            Return False
        Else
            Return True
        End If

    End Function
    Private Function GetImpuestosConcepto(FPRECIO As Decimal, FCANT As Decimal, FDESC As Decimal,
                                          FIMPU1 As Decimal, FIMPU2 As Decimal, FIMPU3 As Decimal, FIMPU4 As Decimal) As ImpuestosC
        Dim impuesto As New ImpuestosC()
        Try
            If FIMPU1 > 0 Then
                FIMPU1 /= 100
                impuesto.Traslados.Add(New TrasladoC() With {.TasaOCuota = FIMPU1, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU1, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU2 < 0 Then
                FIMPU2 = Math.Abs(FIMPU2)
                FIMPU2 /= 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU2, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU2, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU3 < 0 Then
                FIMPU3 = Math.Abs(FIMPU3)
                FIMPU3 /= 100
                impuesto.Retenciones.Add(New RetencionC() With {.TasaOCuota = FIMPU3, .Base = (FPRECIO * FCANT) - FDESC, .Impuesto = "002", .Importe = Math.Round(((FPRECIO * FCANT) - FDESC) * FIMPU3, 2), .TipoFactor = "Tasa"})
            End If
            If FIMPU4 > 0 Then
                FIMPU4 /= 100
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
            subtotal += subtotal + c.Importe
            descuento = c.Descuento
        Next

        _c.SubTotal = subtotal
        _c.Descuento = descuento
        _c.Total = subtotal - _c.Impuestos.TotalImpuestosRetenidos + _c.Impuestos.TotalImpuestosTrasladados
        _c.TotalLetra = New Numalet().ToCustomString(_c.Total)

    End Sub
    Private Function GetImpuestos(ByVal conceptos As List(Of Concepto)) As Impuestos
        Dim index As Integer
        Dim traslado As New Traslado()
        Dim retencion As New Retencion()
        Dim traslados As New List(Of Traslado)()

        Dim retenciones As New List(Of Retencion)()
        Dim totalImpuestosRetenidos As Decimal = 0
        Dim totalImpuestosTrasladados As Decimal = 0
        Dim impuestos As New Impuestos()

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
                    retencion = New Retencion With {
                        .Importe = r.Importe,
                        .Impuesto = r.Impuesto
                    }

                    retenciones.Add(retencion)
                End If
            Next
        Next

        For Each r As Retencion In retenciones
            totalImpuestosRetenidos += r.Importe
        Next

        For Each t As Traslado In traslados
            totalImpuestosTrasladados += t.Importe
        Next

        impuestos.TotalImpuestosRetenidos = totalImpuestosRetenidos
        impuestos.TotalImpuestosTrasladados = totalImpuestosTrasladados
        impuestos.Traslados = traslados
        impuestos.Retenciones = retenciones
        Return impuestos
    End Function


    Sub CUEN_M(fCVE_DOC As String, fCLAVE As String, fIMPORTE As Decimal, fCVE_VEND As String, fCVE_BITA As Long, FNUM_MONED As Integer, FTIPO_CAMBIO As Decimal)

        Dim CVE_CLIE As String, REFER As String, NUM_CPTO As Integer, CVE_OBS As Long, NO_FACTURA As String, DOCTO As String, IMPORTE As Decimal
        Dim AFEC_COI As String, STRCVEVEND As String, IMPMON_EXT As Decimal, CVE_FOLIO As String
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
            NUM_CPTO = 2
            CVE_OBS = 0 : AFEC_COI = "S" : STRCVEVEND = fCVE_VEND
            CVE_FOLIO = "" : TIPO_MOV = "C" : ENTREGADA = "S"

            SQL = "IF NOT EXISTS(SELECT REFER FROM CUEN_M" & Empresa & " WHERE
                REFER = '" & REFER & "' AND CVE_CLIE = '" & CVE_CLIE & "' AND NUM_CPTO = " & NUM_CPTO & " AND NUM_CARGO = 1)
                INSERT INTO CUEN_M" & Empresa & " (CVE_CLIE, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO,
                TIPO_MOV, IMPORTE, FECHA_APLI, FECHA_VENC, AFEC_COI, STRCVEVEND, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, 
                CVE_BITA, SIGNO, USUARIO, ENTREGADA, FECHA_ENTREGA, STATUS, UUID, VERSION_SINC) 
                VALUES('" &
                CVE_CLIE & "','" & REFER & "','" & NUM_CPTO & "','1','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" &
                TIPO_MOV & "','" & Math.Round(fIMPORTE, 6) & "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" &
                STRCVEVEND & "','" & FNUM_MONED & "','" & FTIPO_CAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'" &
                fCVE_BITA & "','" & SIGNO & "','" & CLAVE_SAE & "','" & ENTREGADA &
                "',CONVERT(varchar, GETDATE(), 112),'A', NEWID(), GETDATE())"
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
    Sub CUEN_DET(FCVE_DOC As String, FDOCTO As String, FCLAVE As String, FIMPORTE As Decimal, FNUM_CPTO_PAGO As Integer, FCVE_VEND As String,
                 Optional FTIPO_VTA As String = "", Optional FNUM_MONED As Integer = 1, Optional FTIPO_CAMBIO As Decimal = 1)

        Dim CVE_CLIE As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim DOCTO As String, IMPORTE As Decimal, STRCVEVEND As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal, CVE_FOLIO As String
        Dim TIPO_MOV As String, SIGNO As Integer, NO_PARTIDA As Integer, AFEC_COI As String
        Dim cmd As New SqlCommand, dr As SqlDataReader, cmdT As New SqlCommand

        CVE_CLIE = FCLAVE

        REFER = FCVE_DOC
        NO_FACTURA = FDOCTO

        If FNUM_CPTO_PAGO = 0 Then
            NUM_CPTO = 10
        Else
            NUM_CPTO = FNUM_CPTO_PAGO
        End If

        If TIPO_VENTA_LOCAL = "F" Then
            ID_MOV = 1
        Else
            ID_MOV = 2
        End If

        If FTIPO_VTA.Trim.Length > 0 Then
            Select Case FTIPO_VTA
                Case "F"
                    ID_MOV = 1
                Case "V"
                    ID_MOV = 2
            End Select
        End If

        CVE_OBS = 0 : DOCTO = FDOCTO : AFEC_COI = "S"
        IMPORTE = FIMPORTE
        STRCVEVEND = FCVE_VEND
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
            NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(FIMPORTE, 6) &
            "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & STRCVEVEND & "','" & FNUM_MONED & "','" &
            FTIPO_CAMBIO & "','" & Math.Round(IMPMON_EXT, 6) & "',GETDATE(),'0','" & CVE_FOLIO & "','" & TIPO_MOV & "','" & SIGNO & "','0','" & CLAVE_SAE & "','" &
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
    Private Sub BarObserDoc_Click(sender As Object, e As EventArgs) Handles BarObserDoc.Click
        Try
            Dim CLAVE_OBRA As String

            If CHCAMPOLIB_CUADRILLA = 1 Then
                If TOBRA.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la obra")
                    Return
                End If
                CLAVE_OBRA = TOBRA.Text
                Var10 = CLAVE_OBRA '& " - " & LtObra.Text
                Var14 = CAMPLIB_OBRA

            End If

            Var4 = Obser
            Var5 = "NUEVO"
            Var6 = "FACTF_CLIB"
            Var7 = "FACT" & TIPO_VENTA & "_CLIB" & Empresa
            Var9 = "D"


            If DOC_NEW Then
                Var8 = LUUID
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
            Dim CANT As Decimal = 0

            If MsgBox("Realmente desea eliminar la partida " & Fg(Fg.Row, 4) & "?", vbYesNo) = vbYes Then
                If CHCAMPOLIB_CUADRILLA = 1 Then
                    SQL = "DELETE FROM GCLIB_PAR_P WHERE CLAVE_DOC = '" & DOC_ENLAZADO & "' AND NUM_PART = " & Fg.Row
                    EXECUTE_QUERY_NET(SQL)
                End If

                ENTRA = False

                Fg.FinishEditing()
                Fg.Col = 6

                CANT = Fg(Fg.Row, 2)
                '                      LINEA          CVE_ART         CANT 
                APLICAR_POLITICAS(Fg(Fg.Row, 31), Fg(Fg.Row, 4), Fg(Fg.Row, 2), CANT)

                Fg.RemoveItem(Fg.Row)

                CALCULAR_IMPORTES()

                ENTRA = True

                's &= dr("NUM_PAR") & vbTab '18

                If Fg.Rows.Count - 1 = 0 Then
                    Dim s As String

                    '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                    '   1            2            3            4            5            6            7            8            9           10
                    s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                    '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                    '    11           12           13           14           15           16           17           18           19           20           21
                    s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                    ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                    '    22          23           24           25           26           27           28           29           30          31
                    s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                    '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                    '     3 2          33         34          35
                    s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                    Fg.AddItem("" & vbTab & s)
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 2
                Else
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 2
                End If
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
                TCVE_PEDI.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2080. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2080. " & ex.Message & vbNewLine & ex.StackTrace)
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
            End If
        Catch ex As Exception
            BITACORATPV("2180. " & ex.Message & vbNewLine & ex.StackTrace)
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
    Private Sub BarLimpiar_Click(sender As Object, e As EventArgs) Handles BarLimpiar.Click
        Try
            LIMPIAR()
        Catch ex As Exception
        End Try
    End Sub
    Sub LIMPIAR()

        Try
            'cboTipoVenta.SelectedIndex = 0
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
            TCLIENTE.Text = CLIENTE_MOSTRADOR
            TCVE_PEDI.Text = ""
            DOC_ENLAZADO = "N"
            DOCUMENT_ENLAZADO = ""
            TIPO_DOC_ENLAZADO = ""
            DOC_NEW = True
            Obser = ""
            LtFormaPagoSat.Text = ""
            LtMetodoPago.Text = ""
            TCVE_VEND.Text = ""
            Try
                'tEsquema.Value = 1
                'tDesFin.Value = "0"
                LtTOTAL.Text = ""
                LtDocAnt.Text = ""

                TDESC.Value = 0

            Catch ex As Exception
            End Try
            tEntregarEn.Text = ""
            tEntregarEn.Tag = ""
            LtCVE_DOC.Tag = ""

            LtFAC_CVE_DOC.Text = ""
            LtUUID.Text = ""
            CboAlmacen.SelectedIndex = 0

            ENTRA = False

            Try
                Fg.Rows.Count = 1
                Dim s As String

                '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                '   1            2            3            4            5            6            7            8            9           10
                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                '    11           12           13           14           15           16           17           18           19           20           21
                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                '    22          23           24           25           26           27           28           29           30          31
                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                '     3 2          33         34          35
                s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                Fg.AddItem("" & vbTab & s)

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
                Var46 = ""

                Dim CAEDENA As String

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM GCLIB_PAR_P ORDER BY NUM_PART"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read

                            Try
                                CAEDENA = "UPDATE GCLIB_PAR_P SET "
                                For k = 3 To dr.FieldCount - 1 Step 2

                                    CAEDENA &= dr.GetName(k) & " = '" & dr(dr.GetName(k)) & "', "

                                Next
                                CAEDENA = CAEDENA.Substring(0, CAEDENA.Length - 2)

                                SQL = CAEDENA

                                ReturnBool = EXECUTE_QUERY_NET(SQL)
                            Catch ex As Exception
                                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End While
                    End Using
                End Using

            Catch ex As Exception
                BITACORATPV("2278. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If CLIENTE_MOSTRADOR.Trim.Length = 0 Then
                TCLIENTE.Focus()
            Else
                Fg.Row = 1
                Fg.Col = 2
                ENTRA = True

                Fg.StartEditing()
            End If

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
            TCVE_PEDI.Focus()
        End If
    End Sub
    Private Sub TCLIENTE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLIENTE.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then
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

        If Ldocu.Tag = "Digital" And TIPO_VENTA_LOCAL = "F" Then
            CANCELAR_CFDI()
        Else
            CANCELAR_DOCUMENTO()
        End If

    End Sub
    Sub CANCELAR_DOCUMENTO()
        Dim DOC_ANT As String = "", TIP_DOC_ANT As String = "", CVE_DOC As String, CADENA_CANC As String = ""
        Dim nCanc As Integer = 0, nNoCanc As Integer = 0
        'MOVSINV
        Dim CLAVE_CLPV As String = "", CVE_PEDI As String, ENLAZAZADA As String = ""
        Dim DOC_SIG As String = "", TIP_DOC_SIG As String
        Dim DoctoCancelado As String, SiOk As Boolean, CVE_BITA As Long, Sigue As Boolean, ENLAZADO As String = ""
        Dim DATO_REGRESADO As String, IMPORTE As Single, Status As String, FECHA_VENTA As String, CADENA As String = ""


        If Not Valida_Conexion() Then
            Return
        End If

        CVE_DOC = LtCVE_DOC.Text

        If CVE_DOC.Trim.Length = 0 Then
            MsgBox("No se encontró el documento a cancelar")
            Return
        End If

        If TIPO_VENTA_LOCAL <> "R" Then
            If TCVE_PEDI.Tag = "T" Then
                Select Case TIPO_VENTA_LOCAL
                    Case "C"
                        MsgBox("La cotización tiene un documento siguiente, no es posible realizar la cancelación")
                    Case "R"
                        MsgBox("La remisión tiene un documento siguiente, no es posible realizar la cancelación")
                    Case "V"
                        MsgBox("La nota de venta tiene un documento siguiente, no es posible realizar la cancelación")
                    Case "P"
                        MsgBox("El pedido tiene un documento siguiente, no es posible realizar la cancelación")
                    Case "D"
                        MsgBox("La devolución tiene un documento siguiente, no es posible realizar la cancelación")
                End Select
                Return
            End If
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
                    SQL = "SELECT CVE_CLPV, ISNULL(DOC_SIG,'') AS DOCSIG, FECHA_DOC, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG, ISNULL(R.ENLAZADO,'') AS ENLAZA,
                        ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(TIP_DOC_ANT,'') AS TIPDOCANT, ISNULL(STATUS,'') AS ST, ISNULL(CVE_PEDI,'') AS PEDI
                        FROM FACT" & TIPO_VENTA_LOCAL & Empresa & " R
                        WHERE CVE_DOC = '" & CVE_DOC & "'"
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

                If TIP_DOC_ANT.Trim.Length > 0 Then
                    Status = ""
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(STATUS,'') AS ST, ISNULL(ENLAZADO,'') AS ENLAZA FROM FACT" & TIP_DOC_ANT & Empresa & " WHERE CVE_DOC = '" & DOC_ANT & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                Status = dr("ST")
                                ENLAZAZADA = dr("ENLAZA")
                            End If
                        End Using
                    End Using

                    If Status <> "C" And ENLAZAZADA = "O" Then
                        MsgBox("El documento anterior " & DOC_ANT & " NO se encuentra cancelado, verifique por favor")
                        Exit Sub
                    End If
                End If

            Catch ex As Exception
                BITACORATPV("2710. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2710. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try


            Try
                If TIPO_VENTA_LOCAL = "F" Then
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
                Else
                    Sigue = True
                End If
            Catch ex As Exception
                BITACORATPV("2715. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("2715. " & ex.Message & vbNewLine & ex.StackTrace)
                Return
            End Try

            If ENLAZADO <> "O" And Sigue Then
                Try
                    If TIPO_VENTA_LOCAL <> "R" Then
                        CADENA_CANC = ""
                        TIP_DOC_SIG = "C"
                        If TIP_DOC_SIG = "F" Then CADENA_CANC = "La Factura"
                        If TIP_DOC_SIG = "V" Then CADENA_CANC = "La Nota"
                        If TIP_DOC_SIG = "R" Then CADENA_CANC = "La Remisión"
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
                    If TIPO_VENTA_LOCAL <> "R" Then
                        DATO_REGRESADO = ESTA_EL_TICKET_FACTURADO(CVE_DOC)

                        If DATO_REGRESADO.Trim.Length > 0 Then
                            CADENA_CANC = ""
                            If Var10 = "F" Then CADENA_CANC = "la Factura "
                            If Var10 = "V" Then CADENA_CANC = "la Nota "
                            If Var10 = "R" Then CADENA_CANC = "la Remisión "
                            If Var10 = "P" Then CADENA_CANC = "el Pedido "
                            If Var10 = "C" Then CADENA_CANC = "la Cotización "
                            If Var10 = "D" Then CADENA_CANC = "la Devolución "
                            MsgBox("El documento " & CVE_DOC & " se le generó " & CADENA_CANC & DATO_REGRESADO & ", no es posible realizar la cancelación")
                            Return
                        End If
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

                'INICIO MOVIMIENTOS AL INVENTARIO DE LA MERCANCIA CANCELADA

                If TIPO_VENTA_LOCAL = "V" Or TIPO_VENTA_LOCAL = "R" Or TIPO_VENTA_LOCAL = "F" Then


                    'MOVSINV
                    Dim CADENA_EXIST As String, CVE_CPTO As Integer = 2, CANT_COST As Decimal, AFEC_COI As String = "", CVE_OBS As Long = 0
                    Dim REG_SERIE As Integer = 0, COSTEADO As String = "S", SIGNO = 1, TIPO_DOC As String = "V", FACTOR_CON As Integer = 1
                    Dim E_LTPD As Integer = 0, CTLPOL As Integer = 0, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal
                    Dim DESDE_INVE As String = "S", MOV_ENLAZADO As Integer = 0, CVE_VEND As String = "", CVE_FOLIO As String = ""
                    Dim EXIST_G As String


                    SiOk = True
                    If TIP_DOC_ANT.Trim.Length = 0 Then
                        SiOk = True
                    Else
                        If TIP_DOC_ANT = "V" Then
                            SiOk = False
                        End If
                        If TIP_DOC_ANT = "R" Then
                            SiOk = False
                        End If
                    End If

                    If SiOk Then
                        Try
                            Dim EXI_INI As Decimal = 0

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT P.CVE_ART, P.CANT, I.TIPO_ELE, P.PREC, P.COST, P.NUM_ALM, P.UNI_VENTA 
                                FROM PAR_FACT" & TIPO_VENTA_LOCAL & Empresa & " P
                                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                                WHERE CVE_DOC = '" & CVE_DOC & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read
                                        If dr("TIPO_ELE") = "P" Then
                                            Try
                                                SQL = "UPDATE PAR_FACT" & TIP_DOC_ANT & Empresa & " SET PXS = CANT WHERE CVE_DOC = '" & DOC_ANT & "'"
                                                Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                                    cmd3.CommandText = SQL
                                                    returnValue = cmd3.ExecuteNonQuery().ToString
                                                    If returnValue IsNot Nothing Then
                                                        If returnValue = "1" Then
                                                        End If
                                                    End If
                                                End Using
                                            Catch ex As Exception
                                                MsgBox("2825. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try

                                            EXI_INI = OBTENER_EXISTENCIA(dr("CVE_ART"), dr("NUM_ALM"))
                                            SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & dr("CANT") & " 
                                            WHERE CVE_ART = '" & dr("CVE_ART") & "'"
                                            returnValue2 = EXECUTE_QUERY_NET(SQL)

                                            If MULTIALMACEN = 1 Then
                                                SQL = "UPDATE MULT" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & dr("CANT") & " 
                                                WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_ALM = " & dr("NUM_ALM")
                                                returnValue2 = EXECUTE_QUERY_NET(SQL)
                                            End If

                                            CANT_COST = dr("COST") * dr("CANT")
                                            COSTO_PROM_INI = CANT_COST
                                            COSTO_PROM_FIN = CANT_COST

                                            EXIST_G = "ISNULL((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "'),0)"

                                            If MULTIALMACEN = 1 Then
                                                'EXISTENCIA
                                                CADENA_EXIST = "COALESCE((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "' AND CVE_ALM = " & dr("NUM_ALM") & "),0)"
                                            Else
                                                'EXISTENCIA
                                                CADENA_EXIST = "COALESCE((SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & dr("CVE_ART") & "'),0)"
                                            End If

                                            SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV,
                                            VEND, CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON,
                                            FECHAELAB, CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, CVE_OBS, 
                                            COSTO_PROM_GRAL, EXIINI, EXIFIN)
                                            OUTPUT Inserted.NUM_MOV VALUES('" &
                                                dr("CVE_ART") & "','" & dr("NUM_ALM") & "',(SELECT COALESCE(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & CVE_CPTO &
                                                "',Convert(varchar, GETDATE(), 112),'" & TIPO_VENTA_LOCAL & "','" & CVE_DOC & "','" & CLAVE_CLPV & "','" &
                                                CVE_VEND & "','" & dr("CANT") & "','" & CANT_COST & "','" & dr("PREC") & "','" & dr("COST") & "','" & REG_SERIE & "','" &
                                                dr("UNI_VENTA") & "','" & E_LTPD & "'," & EXIST_G & "," & CADENA_EXIST & ",'" & dr("TIPO_ELE") & "','" & FACTOR_CON &
                                                "',GETDATE()" & ",(SELECT ULT_CVE FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" & SIGNO & "','" &
                                                COSTEADO & "','" & COSTO_PROM_INI & "','" & COSTO_PROM_FIN & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" &
                                                CVE_OBS & "','" & CANT_COST & "','" & EXI_INI & "','" & (EXI_INI + dr("CANT")) & "')"
                                            returnValue2 = EXECUTE_QUERY_NET(SQL)

                                        End If
                                    End While
                                End Using
                            End Using

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT * FROM DOCTOSIGF" & Empresa & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND CVE_DOC = '" & CVE_DOC & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        While dr.Read
                                            SQL = "UPDATE FACT" & dr("TIP_DOC_E") & Empresa & " 
                                             SET ENLAZADO = 'O', DOC_SIG = '', TIP_DOC_SIG = '', TIP_DOC_E = '' 
                                             WHERE CVE_DOC = '" & dr("CVE_DOC_E") & "'"
                                            ReturnBool = EXECUTE_QUERY_NET(SQL)

                                            SQL2 = "UPDATE PAR_FACT" & dr("TIP_DOC_E") & Empresa & " SET PXS = CANT
                                            WHERE CVE_DOC = '" & dr("CVE_DOC_E") & "' AND NUM_PAR = " & dr("PART_E")
                                            ReturnBool = EXECUTE_QUERY_NET(SQL2)
                                        End While
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                Using cmd As SqlCommand = cnSAE.CreateCommand
                                    SQL = "SELECT * FROM DOCTOSIGF" & Empresa & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND CVE_DOC = '" & CVE_DOC & "'"
                                    cmd.CommandText = SQL
                                    Using dr As SqlDataReader = cmd.ExecuteReader
                                        While dr.Read
                                            SQL = "DELETE FROM DOCTOSIGF" & Empresa & " WHERE 
                                             TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND CVE_DOC = '" & CVE_DOC & "' AND 
                                             TIP_DOC_E = '" & TIP_DOC_ANT & "' AND CVE_DOC_E = '" & DOC_ANT & "'"

                                            ReturnBool = EXECUTE_QUERY_NET(SQL)
                                        End While
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                        Catch ex As Exception
                            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End If

                End If

                CVE_BITA = GRABA_BITA(CLAVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, "Se cancelo " & CADENA_CANC)

                SQL = "UPDATE FACT" & TIPO_VENTA_LOCAL & Empresa & " SET
                      STATUS = 'C', FECHA_CANCELA = CONVERT(varchar, GETDATE(), 112), ENLAZADO = 'O', TIP_DOC_ANT = '', 
                      DOC_ANT = '', CVE_BITA = " & CVE_BITA & " WHERE CVE_DOC = '" & CVE_DOC & "'"
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

            If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "V" Then
                Try
                    SQL = "DELETE FROM CUEN_M" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                    ReturnBool = EXECUTE_QUERY_NET(SQL)

                    SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                    ReturnBool = EXECUTE_QUERY_NET(SQL)
                Catch ex As Exception
                    BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            End If

            If CHCAMPOLIB_CUADRILLA = 1 Then
                If TIPO_VENTA_LOCAL = "R" Then

                    SQL = "UPDATE GCCXC_COILSA_REM SET STATUS = 'C' WHERE CVE_DOC = '" & CVE_DOC & "'"
                    ReturnBool = EXECUTE_QUERY_NET(SQL)

                End If
            End If

            If TIP_DOC_ANT.Trim.Length > 0 Then
                If Valida_Conexion() Then
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT * FROM DOCTOSIGF" & Empresa & " WHERE TIP_DOC = '" & TIPO_VENTA_LOCAL & "' AND CVE_DOC = '" & CVE_DOC & "'"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                While dr.Read
                                    If TIPO_VENTA_LOCAL = "R" Then
                                        SQL = "UPDATE FACT" & dr("TIP_DOC_E") & Empresa & " 
                                             SET ENLAZADO = 'O', DOC_ANT = '', TIP_DOC_ANT = '', DOC_SIG = '', TIP_DOC_SIG = '', TIP_DOC_E = '' 
                                             WHERE CVE_DOC = '" & dr("CVE_DOC_E") & "'"
                                        ReturnBool = EXECUTE_QUERY_NET(SQL)
                                    Else
                                        SQL = "UPDATE FACT" & dr("TIP_DOC_E") & Empresa & " 
                                             SET ENLAZADO = 'O', DOC_SIG = '', TIP_DOC_SIG = '', TIP_DOC_E = '' 
                                             WHERE CVE_DOC = '" & dr("CVE_DOC_E") & "'"
                                        ReturnBool = EXECUTE_QUERY_NET(SQL)
                                    End If

                                    SQL2 = "UPDATE PAR_FACT" & dr("TIP_DOC_E") & Empresa & " SET PXS = CANT
                                         WHERE CVE_DOC = '" & dr("CVE_DOC_E") & "' AND NUM_PAR = " & dr("PART_E")
                                    ReturnBool = EXECUTE_QUERY_NET(SQL2)
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    If TIPO_VENTA_LOCAL = "R" Then
                        SQL = "UPDATE FACT" & TIPO_VENTA_LOCAL & Empresa & " 
                            SET ENLAZADO = 'O', DOC_ANT = '', TIP_DOC_ANT = '', DOC_SIG = '', TIP_DOC_SIG = '', TIP_DOC_E = '' 
                            WHERE CVE_DOC = '" & CVE_DOC & "'"
                        ReturnBool = EXECUTE_QUERY_NET(SQL)
                    End If

                    MsgBox("El documento se cancelo satisfactoriamente")

                    Return
                End If
                'PROCESO LIBERAR LOS DOCUMENTOS COTIZACIONES O PEDIDOS
            End If

            'ENVIO CORREO DE LA CANCELACION
            Try
                Dim aCorreo As New ArrayList From {""}
                Dim SALUDOS As String, MensaDia As DateTime = Now.ToLongDateString, MAIL_CANCFAC As String = ""
                Dim MAIL_CANCNV As String = "", MAIL_VTACREDITO As String = "", MAIL_VTADESCUENTO As String = ""
                aCorreo(0) = ""
                Try
                    Dim horaActual As String
                    horaActual = DateTime.Now.ToString("HH:mm")
                    If horaActual >= "24:00" And horaActual <= "12:00" Then
                        SALUDOS = "Buenos Días"
                    ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                        SALUDOS = "Buenas Tardes"
                    ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                        SALUDOS = "Buenas Noches"
                    End If

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT MAIL_CANCFAC, MAIL_CANCNV, MAIL_VTACREDITO, MAIL_VTADESCUENTO FROM GCDATOSEMPRESA"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                MAIL_CANCFAC = dr.ReadNullAsEmptyString("MAIL_CANCFAC")
                                MAIL_CANCNV = dr.ReadNullAsEmptyString("MAIL_CANCNV")
                                MAIL_VTACREDITO = dr.ReadNullAsEmptyString("MAIL_VTACREDITO")
                                MAIL_VTADESCUENTO = dr.ReadNullAsEmptyString("MAIL_VTADESCUENTO")
                            Else
                                MAIL_CANCFAC = ""
                                MAIL_CANCNV = ""
                                MAIL_VTACREDITO = ""
                                MAIL_VTADESCUENTO = ""
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                If MAIL_CANCFAC.Trim.Length > 0 Then

                    SendEmail(MAIL_CANCFAC, "Cancelación Nota de venta",
                                    MensaDia & vbCrLf & vbCrLf &
                                    "Documento " & CVE_DOC & vbCrLf &
                                    "Se cancelo el documento " & CVE_DOC & " por el usuario " & USER_GRUPOCE & vbCrLf & vbCrLf &
                                     LtNombre.Text, aCorreo, MAIL_CANCNV, MAIL_VTACREDITO, MAIL_VTADESCUENTO, MAIL_VTADESCUENTO)
                End If
            Catch ex As Exception
                BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
            'FIN ENVIO DE LA CANCELACION

            MsgBox("El documento se cancelo satisfactoriamente")

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

    Private Sub L4_DoubleClick(sender As Object, e As EventArgs) Handles LtMetodoPago.DoubleClick
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
                Var4 = Fg(Fg.Row, 23)
                Var5 = "NUEVO"
                Var6 = "PAR_FACT_CLIB"
                Var7 = "PAR_FACT" & TIPO_VENTA & "_CLIB" & Empresa
                Var9 = "P"
                Var20 = Fg.Row

                If DOC_NEW Then
                    Var8 = TOBRA.Tag
                Else
                    Var8 = LtCVE_DOC.Text
                End If

                If Var8.Trim.Length = 0 Then
                    If MODO_EDIT = "edit" Then
                        Var8 = LtCVE_DOC.Text
                    Else
                        If DOCUMENT_ENLAZADO.Trim.Length > 0 Then
                            Var8 = Fg(Fg.Row, 20)
                        Else
                            Var8 = LUUID
                        End If
                    End If
                End If


                FrmObserYCampLib.ShowDialog()

                Fg(Fg.Row, 23) = Var4

            End If

        Catch ex As Exception
            BITACORATPV("2940. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboPrecio.SelectedIndexChanged
        Try
            Dim c_ As Integer
            If Fg.Col = 1 Then
                c_ = 2
            Else
                c_ = Fg.Col
            End If
            Fg.Focus()
        Catch ex As Exception
            BITACORATPV("2945. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles CboPrecio.KeyDown
        If e.KeyCode = 13 Then
            If CboAlmacen.Enabled Then
                CboAlmacen.Focus()
            Else
                Try
                    Fg.Focus()
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 2
                    SendKeys.Send("{ENTER}")

                Catch ex As Exception
                    BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        End If
    End Sub
    Private Sub CboPrecio_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboPrecio.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then
                If CboAlmacen.Enabled Then
                    CboAlmacen.Focus()
                Else
                    Fg.Focus()
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 2
                    SendKeys.Send("{ENTER}")
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

    Private Sub BarKardex_Click(sender As Object, e As EventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 4)

                If Var4.Trim.Length = 0 Then
                    MsgBox("Por favor seleccione una partida que contenga la clave del articulo a consultar el kardex")
                    Return
                End If
                Var5 = Fg(Fg.Row, 6)

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
            New cRegimenFiscal(17, "626", "Régimen Simplificado de Confianza"),
            New cRegimenFiscal(18, "628", "Hidrocarburos"),
            New cRegimenFiscal(19, "607", "Régimen de Enajenación o Adquisición de Bienes"),
            New cRegimenFiscal(20, "629", "De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales"),
            New cRegimenFiscal(21, "630", "Enajenación de acciones en bolsa de valores"),
            New cRegimenFiscal(22, "615", "Régimen de los ingresos por obtención de premios")
        }
        cbRegimenesFiscales.ValueMember = "RegimenFiscal"
        cbRegimenesFiscales.DataSource = lista
    End Sub
    Private Sub CargarMonedas()
        Try
            'Me.Id = id
            'Me.MONEDA = MONEDA
            'Me.Descripcion = descripcion
            Dim lista As New List(Of cMoneda)()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED FROM MONED" & Empresa & " WHERE STATUS = 'A' ORDER BY NUM_MONED"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        lista.Add(New cMoneda(dr.ReadNullAsEmptyInteger("NUM_MONED"), dr.ReadNullAsEmptyString("CVE_MONED"), dr.ReadNullAsEmptyString("DESCR")))
                    End While
                End Using
                'cbMoneda.DataSource = lista
            End Using
        Catch SQLex As SqlException
            Dim SSS As SqlError, Sqlcadena As String = ""
            For Each SSS In SQLex.Errors
                Sqlcadena += SSS.Message & vbNewLine
            Next
            BITACORASQL("685. " & vbNewLine & "Num. error sql server:" & SQLex.Number & vbNewLine & Sqlcadena)
        Catch ex As Exception
            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
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

        Dim lista As List(Of cFormaPago) = New List(Of cFormaPago)()
        Dim z As Integer = 1
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT FORMADEPAGOSAT, DESCR FROM CONC" & Empresa & " WHERE STATUS = 'A' AND TIPO = 'A' AND ISNULL(FORMADEPAGOSAT,'') <> ''"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        lista.Add(New cFormaPago(z, dr.ReadNullAsEmptyString("FORMADEPAGOSAT"), dr.ReadNullAsEmptyString("DESCR")))
                        z += 1
                    End While
                    lista.Add(New cFormaPago(z, "99", "Por definir"))
                End Using
            End Using
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            BITACORATPV("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
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

    Private Sub BarCancelar2_Click(sender As Object, e As EventArgs) Handles BarCancelar2.Click

        Dim DOC_ANT As String = "", TIP_DOC_ANT As String = "", CVE_DOC As String, CADENA_CANC As String = "", CLAVE_CLPV As String = ""
        Dim CVE_PEDI As String, DOC_SIG As String, TIP_DOC_SIG As String, DoctoCancelado As String, CVE_BITA As Long
        Dim ENLAZADO As String, IMPORTE As Single, Status As String, FECHA_VENTA As String, CADENA As String = ""
        Dim SEGRABA_VENTA As Boolean = False, CVE_CPTO_CANC_ESPECIAL As Integer, SERIE_CE As String = "", FOLIO_CE As Long = 0

        If Not Valida_Conexion() Then
            Return
        End If

        CVE_DOC = LtCVE_DOC.Text

        If CVE_DOC.Trim.Length = 0 Then
            MsgBox("No se encontró el documento a cancelar")
            Return
        End If

        If TIPO_VENTA_LOCAL <> "V" Then
            MsgBox("La cancelación es solo sobre notas de venta")
            Return
        End If
        Try
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
            Try
                FECHA_VENTA = "" : Status = ""
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_CLPV, ISNULL(DOC_SIG,'') AS DOCSIG, FECHA_DOC, ISNULL(TIP_DOC_SIG,'') AS TIPDOCSIG, ISNULL(R.ENLAZADO,'') AS ENLAZA, " &
                        "ISNULL(DOC_ANT,'') AS DOCANT, ISNULL(TIP_DOC_ANT,'') AS TIPDOCANT, ISNULL(STATUS,'') AS ST, ISNULL(CVE_PEDI,'') AS PEDI " &
                        "FROM FACTV" & Empresa & " R " &
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


            If MsgBox("Realmente desea cancelar documento " & CVE_DOC & "?", vbYesNo) = vbNo Then
                Exit Sub
            End If

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT SERIE_CE, FOLIO_CE
                        FROM GCUSUARIOS_GEN 
                        WHERE UPPER(USUARIO) = '" & USER_GRUPOCE & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            SERIE_CE = dr.ReadNullAsEmptyString("SERIE_CE")
                            FOLIO_CE = dr.ReadNullAsEmptyLong("FOLIO_CE") + 1
                        End If
                    End Using
                End Using
            Catch ex As Exception
                BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            If SERIE_CE.Trim.Length = 0 Then
                MsgBox("Por favor capture la serie del sistema en usuarios")
                Return
            End If

            If Not Valida_Conexion() Then
                Return
            End If



            'INICIO MOVIMIENTOS AL INVENTARIO DE LA MERCANCIA CANCELADA

            If SEGRABA_VENTA Then
                Try
                    If TIPO_VENTA_LOCAL = "V" Then
                        'MOVSINV
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT P.CVE_ART, P.CANT, I.TIPO_ELE, P.PREC, P.COST, P.NUM_ALM, P.UNI_VENTA 
                                FROM PAR_FACTV" & Empresa & " P
                                LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART
                                WHERE CVE_DOC = '" & CVE_DOC & "'"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    While dr.Read

                                        If dr("TIPO_ELE") = "P" Then

                                            SQL = "UPDATE MINVE" & Empresa & " SET REFER2 = '" & SERIE_CE & Format(FOLIO_CE, "0000000000") & "', 
                                                CVE_CPTO = " & CVE_CPTO_CANC_ESPECIAL & " 
                                                WHERE REFER = '" & CVE_DOC & "'"
                                            returnValue = EXECUTE_QUERY_NET(SQL)

                                            SQL = "UPDATE GCUSUARIOS_GEN SET FOLIO_CE = " & FOLIO_CE & " WHERE UPPER(USUARIO) = '" & USER_GRUPOCE & "'"
                                            returnValue2 = EXECUTE_QUERY_NET(SQL)

                                        End If
                                    End While
                                End Using
                            End Using
                        Catch ex As Exception
                            BITACORATPV("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                    End If

                    SQL = "UPDATE FACTV" & Empresa & " SET
                      STATUS = 'C', FECHA_CANCELA = CONVERT(varchar, GETDATE(), 112), ENLAZADO = 'O', TIP_DOC_ANT = '', 
                      DOC_ANT = '', CVE_BITA = " & CVE_BITA & " WHERE CVE_DOC = '" & CVE_DOC & "'"
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

                If TIPO_VENTA_LOCAL = "F" Or TIPO_VENTA_LOCAL = "V" Then
                    Try
                        SQL = "DELETE FROM CUEN_M" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                        returnValue = EXECUTE_QUERY_NET(SQL)

                        SQL = "DELETE FROM CUEN_DET" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
                        returnValue2 = EXECUTE_QUERY_NET(SQL)
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

                        CVE_BITA = GRABA_BITA(CLAVE_CLPV, CVE_DOC, IMPORTE, TIPO_VENTA_LOCAL, "Se cancelo " & CADENA_CANC)
                    Catch ex As Exception
                        BITACORATPV("2825. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("2825. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                MsgBox("El documento se cancelo satisfactoriamente")
            Else
                MsgBox("Cancelación abortada")
            End If


            Me.Close()

        Catch ex As Exception
            BITACORATPV("2840. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2840. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnObra_Click(sender As Object, e As EventArgs) Handles BtnObra.Click
        Try
            Var2 = "Obra"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TOBRA.Text = Var4
                LtObra.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""

                Try
                    Fg.Row = 1
                    Fg.Col = 2
                    Dim c_ As Integer
                    If Fg.Col = 1 Then
                        c_ = 2
                    Else
                        c_ = Fg.Col
                    End If
                Catch ex As Exception
                    BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
        Catch ex As Exception
            BITACORATPV("2290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TOBRA_KeyDown(sender As Object, e As KeyEventArgs) Handles TOBRA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnObra_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            Try
                Fg.Row = 1
                Fg.Col = 2
                Dim c_ As Integer
                If Fg.Col = 1 Then
                    c_ = 2
                Else
                    c_ = Fg.Col
                End If
            Catch ex As Exception
                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub TOBRA_Validated(sender As Object, e As EventArgs) Handles TOBRA.Validated
        Try
            If TOBRA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var4 = ""
                Var5 = ""
                DESCR = BUSCA_CAT("Obra", TOBRA.Text.Trim)
                If DESCR <> "" Then
                    LtObra.Text = DESCR
                Else
                    MsgBox("Obra inexistente verifique por favor")
                    TOBRA.Text = ""
                    LtObra.Text = ""
                End If
            End If
        Catch ex As Exception
            BITACORATPV("150. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TOBRA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TOBRA.PreviewKeyDown
        If e.KeyCode = 9 Then
            Try
                Fg.Focus()
                Fg.Row = 1
                Fg.Col = 2

                SendKeys.Send("{ENTER}")
            Catch ex As Exception
                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub CboAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles CboAlmacen.KeyDown
        If e.KeyCode = 13 Then
            Fg.Focus()
            Fg.Row = 1
            Fg.Col = 2
            SendKeys.Send("{ENTER}")
        End If
    End Sub

    Private Sub CboAlmacen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboAlmacen.PreviewKeyDown
        If e.KeyCode = 9 Then
            Try
                Fg.Row = 1
                Fg.Col = 2
                SendKeys.Send("{ENTER}")
            Catch ex As Exception
                BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub BtnCampos_Click(sender As Object, e As EventArgs) Handles BtnCampos.Click
        Try
            Dim CAEDENA As String, TIPO_CAMPO As String, TIP_FIELD As String

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM PAR_FACTP_CLIB" & Empresa & " L WHERE CLAVE_DOC = '          0000000193'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        CAEDENA = "INSERT INTO GCLIB_PAR_P (CLAVE_DOC, NUM_PART "
                        For k = 2 To dr.FieldCount - 1
                            CAEDENA &= ", " & dr.GetName(k)
                        Next
                        CAEDENA += ") VALUES (CLAVE_DOC, NUM_PART "
                        For k = 2 To dr.FieldCount - 1

                            TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper

                            If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Then

                                TIP_FIELD = "N"
                            Else
                                TIP_FIELD = " "
                            End If

                            CAEDENA &= ", '" & dr(dr.GetName(k)) & "', '" & TIP_FIELD & "'"
                        Next
                        CAEDENA &= ")"
                    End While
                End Using
            End Using
        Catch ex As Exception
            BITACORATPV("2948. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCerrarPedido_Click(sender As Object, e As EventArgs) Handles BarCerrarPedido.Click
        Try
            SQL = "UPDATE FACTP" & Empresa & " SET BLOQUEAR = 'S' WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
                MsgBox("Entre nuevamente por favor")
                Me.Close()
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarReactivarPedido_Click(sender As Object, e As EventArgs) Handles BarReactivarPedido.Click
        Try
            SQL = "UPDATE FACTP" & Empresa & " SET BLOQUEAR = 'N' WHERE CVE_DOC = '" & LtCVE_DOC.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
                MsgBox("Debe de salir del modulo de ventas por favor")
                Me.Close()
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    '██████████████████████████████████████████████████████████████████████████████████████
    '██████████████████████████████████████████████████████████████████████████████████████
    '██████████████████████████████████████████████████████████████████████████████████████
    '██████████████████████████████████████████████████████████████████████████████████████
    '██████████████████████████████████████████████████████████████████████████████████████


    Private Sub TXTN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTN.KeyPress
    End Sub

    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Dim s As String
        Try
            Try
                Select Case e.KeyCode
                    Case Keys.F3
                        BarGrabar_Click(Nothing, Nothing)
                    Case Keys.F4
                        BarTotales_Click(Nothing, Nothing)
                    Case Keys.F5
                        BarEnlaceDocumento_Click(Nothing, Nothing)
                    Case Keys.F6
                        BarKardex_Click(Nothing, Nothing)
                    Case Keys.F7
                        BarImprimir_Click_1(Nothing, Nothing)
                    Case Keys.F8
                        BarEliminar_Click(Nothing, Nothing)
                    Case Keys.F9
                        BarSerie_Click(Nothing, Nothing)
                    Case Keys.F10
                        BarCancelar_Click(Nothing, Nothing)
                    Case Keys.F11
                        BarObserDoc_Click(Nothing, Nothing)
                    Case Keys.F12
                        BarObserPar_Click(Nothing, Nothing)
                End Select
            Catch ex As Exception
            End Try

            If e.KeyCode = Keys.Delete Then
                BarEliminar_Click(Nothing, Nothing)
                Return
            End If

            If ENTRA Then
                ENTRA = False
                If e.KeyCode = 13 Then
                    Select Case Fg.Col
                        Case 2 'CANTIDAD
                            If TXTN.Text.Length > 0 Then
                                TXTN.UpdateValueWithCurrentText()
                            End If
                            If TXTN.Text.Length > 0 AndAlso TXTN.Value > 0 Then
                                ENTRA = False
                                If ALMACEN_X_PARTIDA = 1 Then
                                    Fg.Col = 3
                                Else
                                    Fg.Col = 4
                                End If
                                ENTRA = True
                            Else
                                e.Handled = True
                                ENTRA = True
                                Return
                            End If
                            'SendKeys.Send("{ENTER}")
                        Case 8
                            If IMPUESTOS_X_PARTIDA = 1 Then
                                Fg.Col = 9
                            Else
                                Fg.Col = 13
                            End If
                            'SendKeys.Send("{ENTER}")
                        Case 9
                            Fg.Col = 10
                            'SendKeys.Send("{ENTER}")
                        Case 10
                            Fg.Col = 11
                            'SendKeys.Send("{ENTER}")
                        Case 11
                            Fg.Col = 12
                            'SendKeys.Send("{ENTER}")
                        Case 12
                            Fg.Col = 13
                            SendKeys.Send("{ENTER}")
                        Case 13
                            Var13 = "SOLOTOTAL"

                            ENTRA = False
                            Fg.FinishEditing()
                            ENTRA = True

                            tMagico2.Focus()
                            If CUADRILLA_SE_CANCELA Then
                                CUADRILLA_SE_CANCELA = False
                                Fg(Fg.Row, 13) = Fg(Fg.Row, 29)
                                Return
                            End If

                            If OBSER_X_PARTIDA = 1 Then
                                Var4 = Fg(Fg.Row, 23) 'OBSERVACIONES POR PARTIDA
                                Var5 = "NUEVO"
                                Var6 = "PAR_FACT_CLIB"
                                Var7 = "PAR_FACT" & TIPO_VENTA & "_CLIB" & Empresa
                                Var20 = Fg.Row

                                If DOC_NEW Then
                                    Var8 = TOBRA.Tag
                                Else
                                    Var8 = LtCVE_DOC.Text
                                End If

                                If Var8.Trim.Length = 0 Then
                                    If DOC_NEW Then
                                        Var8 = LtCVE_DOC.Text
                                    Else
                                        If Fg(Fg.Row, 20) IsNot Nothing AndAlso Fg(Fg.Row, 20).ToString.Trim.Length > 0 Then
                                            Var8 = Fg(Fg.Row, 20) 'CVE_DOC_ENLA
                                        Else
                                            Var8 = LtCVE_DOC.Text
                                        End If
                                    End If

                                    'Dim f As New FrmCuadrillaObra With {.MdiParent = MainRibbonForm.Owner, .TopLevel = True}
                                    'f.ShowDialog()
                                End If

                                Var9 = "P"
                                Var4 = Fg(Fg.Row, 23) 'OBSERVACIONES POR PARTIDA

                                FrmObserYCampLib.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    Fg(Fg.Row, 23) = Var4 ' OBSERVACIONES X PARTIDA
                                End If
                            End If

                            Dim CADENA_ALM As String = ""

                            SE_MODIFICA = True
                            If Fg(Fg.Row, 2) > 0 Then
                                If Fg.Row = Fg.Rows.Count - 1 Then

                                    If ALMACEN_X_PARTIDA = 1 Then
                                        If CboAlmacen.SelectedIndex > -1 Then
                                            CADENA_ALM = CboAlmacen.Text
                                        End If
                                    End If

                                    '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                    '   1            2            3            4            5            6            7            8            9           10
                                    s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                    '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                                    '    11           12           13           14           15           16           17           18           19           20           21
                                    s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                    ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                    '    22          23           24           25           26           27           28           29           30          31
                                    s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                                    '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                    '     32          33         34          35
                                    s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                                    ENTRA = False
                                    Fg.AddItem("" & vbTab & s)

                                    Fg.Row = Fg.Rows.Count - 1
                                    Fg(Fg.Row, 3) = CADENA_ALM
                                    'SendKeys.Send(" ")
                                Else
                                    Fg.Row = Fg.Rows.Count - 1
                                End If
                                Fg.Col = 2
                                ENTRA = False
                            Else
                                Fg.Row = Fg.Rows.Count - 1
                            End If
                            Fg.Focus()
                            Fg.Col = 1
                            Fg.Col = 2
                            Fg.StartEditing()
                            ENTRA = True

                            SE_MODIFICA = False
                            Return

                    End Select
                End If

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
                    If Fg.Col = 2 Then
                        If Fg(Fg.Row, 2) > 0 Then

                            Dim CADENA_ALM As String = ""

                            If Fg.Row = Fg.Rows.Count - 1 Then
                                If ALMACEN_X_PARTIDA = 1 Then
                                    If CboAlmacen.SelectedIndex > -1 Then
                                        CADENA_ALM = CboAlmacen.Text
                                    End If
                                End If

                                '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                '   1            2            3            4            5            6            7            8            9           10
                                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                                '    11           12           13           14           15           16           17           18           19           20           21
                                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                '    22          23           24           25           26           27           28           29           30          31
                                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                                '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                '     3 2          33         34          35
                                s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                                Fg.AddItem("" & vbTab & s)

                                Fg.Row = Fg.Rows.Count - 1
                                Fg(Fg.Row, 3) = CADENA_ALM
                            Else
                                Fg.Row += 1
                            End If

                            Fg.Col = 1
                            Fg.Col = 2
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Dim s As String
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If e.KeyCode = Keys.Tab Then
                    Select Case Fg.Col
                        Case 2
                            If ALMACEN_X_PARTIDA = 1 Then
                                Fg.Col = 3
                            Else
                                Fg.Col = 4
                            End If
                            SendKeys.Send("{ENTER}")
                        Case 3
                            Fg.Col = 4
                            SendKeys.Send("{ENTER}")
                            'Case 4
                            'Fg.Col = 8
                            'SendKeys.Send("{ENTER}")
                        Case 8
                            If IMPUESTOS_X_PARTIDA = 1 Then
                                Fg.Col = 9
                            Else
                                Fg.Col = 13
                            End If
                            'SendKeys.Send("{ENTER}")
                        Case 9
                            Fg.Col = 10
                            'SendKeys.Send("{ENTER}")
                        Case 10
                            Fg.Col = 11
                            'SendKeys.Send("{ENTER}")
                        Case 11
                            Fg.Col = 12
                            'SendKeys.Send("{ENTER}")
                        Case 12
                            Fg.Col = 13
                            SendKeys.Send("{ENTER}")
                        Case 13
                            If Fg(Fg.Row, 2) > 0 Then

                                Try
                                    Dim CANT_MONTO As Decimal = 0
                                    If TXTN.Text.Length = 0 Then
                                        CANT_MONTO = 0
                                    Else
                                        If IsNumeric(TXTN.Text.Replace(",", "")) = 0 Then
                                            CANT_MONTO = TXTN.Text.Replace(",", "")
                                        End If
                                    End If
                                    ENTRA = False
                                    If CANT_MONTO > 0 Then
                                        If Not IsNothing(Fg(Fg.Row, 2)) Then
                                            If IsNumeric(Fg(Fg.Row, 2)) Then
                                                Fg(Fg.Row, 15) = CANT_MONTO * Fg(Fg.Row, 2)
                                            End If
                                        End If
                                    Else
                                        Fg(Fg.Row, 15) = 0
                                    End If

                                    ENTRA = True
                                Catch ex As Exception
                                    ENTRA = True
                                    Bitacora("980. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                End Try

                                If Fg.Row = Fg.Rows.Count - 1 Then

                                    Dim CADENA_ALM As String = ""

                                    If ALMACEN_X_PARTIDA = 1 Then
                                        If CboAlmacen.SelectedIndex > -1 Then
                                            CADENA_ALM = CboAlmacen.Text
                                        End If
                                    End If

                                    '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                    '   1            2            3            4            5            6            7            8            9           10
                                    s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                    '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                                    '    11           12           13           14           15           16           17           18           19           20           21
                                    s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                    ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                    '    22          23           24           25           26           27           28           29           30          31
                                    s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                                    '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                    '     3 2          33         34          35
                                    s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                                    Fg.AddItem("" & vbTab & s)

                                    Fg.Row = Fg.Rows.Count - 1
                                    Fg(Fg.Row, 3) = CADENA_ALM
                                    'SendKeys.Send(" ")
                                Else
                                    Fg.Row += 1
                                End If
                                Fg.Col = 1
                                Fg.Col = 2
                            End If
                    End Select
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora(ex.Message & ex.StackTrace)
            MsgBox(ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_GotFocus(sender As Object, e As EventArgs) Handles TXTN.GotFocus
        TXTN.SelectAll()
    End Sub
    Private Sub TXTN_Validating(sender As Object, e As CancelEventArgs) Handles TXTN.Validating
        Try
            If Fg.Row > 0 And ENTRA Then
                If TXTN.Text.Length > 0 Then
                    TXTN.UpdateValueWithCurrentText()
                End If
                ENTRA = False
                If Fg.Col = 2 Then
                    If TXTN.Text.Length = 0 Then 'AndAlso TXTN.Value < 0 Then
                        TXTN.Value = 1
                        e.Cancel = True
                    End If
                End If
                If Fg.Col = 13 Then
                    If VALIDAR_EXIST_PED = 1 Then
                        If TXTN.Text.Length > 0 Then

                        End If
                    Else
                        If TXTN.Text <> "" AndAlso TXTN.Value < 0 Then
                            e.Cancel = True
                        End If
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("980. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXTN_Validated(sender As Object, e As EventArgs) Handles TXTN.Validated
        Try
            Dim CANT_MONTO As Decimal = 0, DESC1 As Decimal = 0, CANT As Decimal = 0, MONTO As Decimal = 0
            If Fg.Row > 0 Then
                ENTRA = False

                If Fg.Col = 2 Then
                    'PASO NO. 1           LINEA          CVE_ART         CANT
                    APLICAR_POLITICAS(Fg(Fg.Row, 31), Fg(Fg.Row, 4), Fg(Fg.Row, 2))

                    ENTRA = False
                    Var13 = "SOLOTOTAL"
                    CALCULAR_IMPORTES()
                    ENTRA = True
                End If
                If Fg.Col = 8 Then
                    'PASO NO. 2
                    ENTRA = False
                    Var13 = "SOLOTOTAL"
                    CALCULAR_IMPORTES()
                    ENTRA = True
                End If

                If Fg.Col = 13 Then
                    'MONTO_REMISIONADO & vbTab '28b
                    If CHCAMPOLIB_CUADRILLA = 1 And (TIPO_VENTA_LOCAL = "P" Or TIPO_VENTA_LOCAL = "R") Then
                        Dim IMPORTE_PED As Decimal, IMPORTE_REMISIONADO As Decimal = 0

                        If Not IsNothing(Fg(Fg.Row, 29)) Then
                            If IsNumeric(Fg(Fg.Row, 29)) Then
                                IMPORTE_REMISIONADO = Fg(Fg.Row, 29)
                            End If
                        End If

                        If IMPORTE_REMISIONADO > 0 Then
                            IMPORTE_PED = (CANT * CANT_MONTO) - (CANT * CANT_MONTO * DESC1 / 100)

                            If Fg(Fg.Row, 29) IsNot Nothing AndAlso IMPORTE_PED > Fg(Fg.Row, 29) Then
                                Fg.Col = 13
                                Fg.StartEditing()

                                MsgBox("El importe no puede ser mayor al monto disponible")

                                CUADRILLA_SE_CANCELA = True
                                Return
                            Else
                                Fg(Fg.Row, 15) = IMPORTE_PED
                                Var13 = "SOLOTOTAL"
                            End If
                        Else
                            Fg(Fg.Row, 15) = CANT_MONTO
                            Var13 = "SOLOTOTAL"
                        End If
                    End If

                    'PASO NO. 3
                    ENTRA = False
                    CALCULAR_IMPORTES()
                    ENTRA = True

                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("980. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓

    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Dim CVE_ART As String, RW_ As Integer, SIGUE As Boolean, NumPart As Integer = 0
        Try
            ENTRA = False
            If e.KeyCode = Keys.F8 Then
                BarEliminar_Click(Nothing, Nothing)
                ENTRA = True
                Return
            End If
            ENTRA = True

            If e.KeyCode = 13 And ENTRA Then

                ENTRA = False

                Select Case Fg.Col
                    Case 3 'ALMACEN
                        Fg.Col = 4
                    Case 4 'CVE_ART
                        ENTRA = True
                        If TXT.Text.Trim.Length > 0 Then

                            If EXIST_NOT Then
                                e.Handled = True
                                ENTRA = True
                                EXIST_NOT = False
                                Return
                            Else
                                If DESC_X_PARTIDA = 1 Then
                                    Fg.Col = 8
                                Else
                                    If IMPUESTOS_X_PARTIDA = 1 Then
                                        Fg.Col = 9 'IMPU1
                                    Else
                                        Fg.Col = 13 'PRECIO
                                    End If
                                End If
                                EXIST_NOT = False
                                e.Handled = True
                                ENTRA = True

                                If CVE_ART_P.Trim.Length > 0 Then
                                    Fg(Fg.Row, 4) = CVE_ART_P
                                End If

                                Return
                            End If
                        Else
                            e.Handled = True
                            ENTRA = True
                            Return
                        End If
                End Select
            End If
            If e.KeyCode = Keys.Left Then
                If TXT.SelectionStart = 0 Then
                    Fg.Col = 2
                End If
                If Fg.Col = 4 Then
                    Fg.Col = 2
                End If
            End If
            If e.KeyCode = Keys.F2 Then
                Try
                    If IsNothing(Fg(Fg.Row, 2)) Then
                        MsgBox("La cantidad no debe quedar vacía")
                        Fg.Col = 2
                        ENTRA = True
                        Return
                    End If
                    If Not IsNumeric(Fg(Fg.Row, 2)) Then
                        MsgBox("La cantidad debe SER UN VALOR NUMERICO")
                        Fg.Col = 2
                        ENTRA = True
                        Return
                    End If
                    If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                        MsgBox("La cantidad no debe quedar vacía")
                        Fg.Col = 2
                        ENTRA = True
                        Return
                    End If

                    If MULTIALMACEN = 1 Then
                        G_ALM = 1
                        Try
                            If Not IsNothing(Fg(Fg.Row, 3)) Then
                                If Fg(Fg.Row, 3).ToString.Trim.Length > 1 Then
                                    G_ALM = Fg(Fg.Row, 3).ToString.Substring(0, 2)
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("475. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    Var15 = "Busqueda"

                    Var4 = ""
                    Var2 = "Articulo"
                    Var5 = LINEA_EN_VENTAS

                    ENTRA = False
                    Fg.FinishEditing()
                    ENTRA = True

                    ReDim aDOCS(0)
                    aDOCS(0) = ""

                    FrmSelItem2.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Fg(Fg.Row, 4) = Var4 'CVE_ART
                        Fg(Fg.Row, 6) = Var5 'DESCR

                        CVE_ART = Var4
                        TXT.Text = Var4

                        'PEDIR_LOTE = False
                        SIGUE = True

                        Try
                            If Not IsNothing(aDOCS) Then
                                For k = 0 To aDOCS.Length - 1
                                    If Not IsNothing(aDOCS(k)) Then
                                        If aDOCS(k).Trim.Length > 0 Then
                                            If SIGUE Then
                                                SIGUE = False
                                                RW_ = Fg.Row
                                            Else
                                                RW_ = 0
                                            End If
                                            LLENAR_GRID_ARTICULO(aDOCS(k).Trim, RW_)
                                            NumPart += 1
                                        End If
                                    End If
                                Next
                            End If
                        Catch ex As Exception

                        End Try

                        CALCULAR_IMPORTES()
                        Var2 = "" : Var4 = "" : Var5 = ""

                        ENTRA = True

                        If NumPart > 1 Then
                            Dim s As String
                            '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                            '   1            2            3            4            5            6            7            8            9           10
                            s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                            '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                            '    11           12           13           14           15           16           17           18           19           20           21
                            s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                            ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                            '    22          23           24           25           26           27           28           29           30          31
                            s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                            '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                            '     3 2          33         34          35
                            s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                            Fg.AddItem("" & vbTab & s)
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 1
                            Fg.Col = 2
                        Else
                            LLENAR_GRID_ARTICULO(CVE_ART.Trim, Fg.Row)

                            If DESC_X_PARTIDA = 1 Then
                                Fg.Col = 8 'DESCUENTO
                            Else
                                If IMPUESTOS_X_PARTIDA = 1 Then
                                    Fg.Col = 9 'IMPU1
                                Else
                                    Fg.Col = 13 'PRECIO
                                End If
                            End If
                        End If

                        ENTRA = True
                        Fg.StartEditing()
                        TXTN.SelectAll()
                        Var2 = ""
                        Var4 = ""
                        Var5 = ""
                    Else
                        Fg.Col = 4
                    End If
                Catch ex As Exception
                    Bitacora("480. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("480. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

        Catch ex As Exception
            ENTRA = True
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub TXT_GotFocus(sender As Object, e As EventArgs) Handles TXT.GotFocus
        TXT.SelectAll()
    End Sub
    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try
            If e.KeyCode = 9 And ENTRA Then
                ENTRA = False
                If Fg.Row > 0 Then
                    If Fg.Col = 2 Then
                        Try
                            If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                                If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                                    Fg(Fg.Row, 15) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        ENTRA = True
                        Return
                    End If
                    If Fg.Col = 4 Then
                        If DESC_X_PARTIDA = 1 Then
                            Fg.Col = 8 'DESCUENTO
                        Else
                            If IMPUESTOS_X_PARTIDA = 1 Then
                                Fg.Col = 9 'IMPU1
                            Else
                                Fg.Col = 13 'PRECIO
                            End If
                        End If
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TXT_Validating(sender As Object, e As CancelEventArgs) Handles TXT.Validating
        Dim CVE_ART As String
        Try
            If Fg.Row > 0 And ENTRA Then

                ENTRA = False
                If Fg.Col = 4 Then
                    If TXT.Text.Trim.Length > 0 Then
                        CVE_ART = TXT.Text

                        CVE_ART = RemoveCharacter(CVE_ART)
                        CVE_ART = CVE_ART.Replace(vbTab, "")
                        CVE_ART = CVE_ART.Replace(vbCr, "")
                        CVE_ART = CVE_ART.Replace(vbCrLf, "")

                        If CVE_ART.Trim.Length > 0 Then
                            LLENAR_GRID_ARTICULO(CVE_ART, Fg.Row)

                            Fg(Fg.Row, 4) = CVE_ART_P
                            ENTRA = True
                        Else
                            ENTRA = True
                        End If
                    Else
                        'Lo quite x que no me dejaba seleccionar otro control ejemplo el los botones
                        'e.Cancel = True
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("940. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("940. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
        End Try

    End Sub
    Private Sub TXT_Validated(sender As Object, e As EventArgs) Handles TXT.Validated
        If Fg.Row > 0 And ENTRA Then
            If Fg.Col = 13 Then
                ENTRA = True
            End If

            Select Case Fg.Col
                Case 2
                    If TXT.Text.Trim.Length = 0 Then
                        Fg.Col = 4
                        tMagico2.Focus()
                        Fg.StartEditing()
                    End If
            End Select
        End If
    End Sub

    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓
    '▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 8
                        If BLOQ8 Then
                            e.Cancel = True
                        End If
                    Case 9
                        If BLOQ9 Then
                            e.Cancel = True
                        End If
                    Case 10
                        If BLOQ10 Then
                            e.Cancel = True
                        End If
                    Case 11
                        If BLOQ11 Then
                            e.Cancel = True
                        End If
                    Case 12
                        If BLOQ12 Then
                            e.Cancel = True
                        End If
                End Select

                If Fg.Row > 0 Then
                    If Fg.Col = 2 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or
                        Fg.Col = 9 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Then
                    Else
                        e.Cancel = True
                    End If
                End If
                ENTRA = True
            End If


        Catch ex As Exception
            ENTRA = True
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 8
                        Fg.Col = 9
                    Case 9
                        If Not BLOQ9 Then
                            Fg.Col = 10
                        End If
                    Case 10
                        If Not BLOQ10 Then
                            Fg.Col = 11
                        End If
                    Case 11
                        If Not BLOQ11 Then
                            Fg.Col = 12
                        End If
                    Case 12
                        If Not BLOQ12 Then
                            Fg.Col = 13
                        End If
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        If Not SE_MODIFICA Then
            Return
        End If
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 8 Then
                    If DESC_X_PARTIDA = 0 Then

                        ENTRA = False
                        Fg.FinishEditing()
                        ENTRA = True
                    End If
                End If
                If Fg.Col = 2 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 7 Or Fg.Col = 8 Or
                    Fg.Col = 9 Or Fg.Col = 10 Or Fg.Col = 11 Or Fg.Col = 12 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Then
                Else
                    ENTRA = False
                    Fg.FinishEditing()
                    ENTRA = True
                End If

                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Not SE_MODIFICA Then
                Return
            End If
            If ENTRA Then
                ENTRA = False
                If Fg.Col = 2 Or Fg.Col = 4 Or Fg.Col = 5 Or Fg.Col = 8 Or Fg.Col = 13 Or Fg.Col = 14 Or Fg.Col = 15 Then
                    'start editing the cell with the custom editor
                    Fg.StartEditing()
                End If
            End If
            ENTRA = True
        Catch ex As Exception
            BITACORATPV("2200. " & ex.Message & vbNewLine & ex.StackTrace)
            ENTRA = True
        End Try
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        If Not SE_MODIFICA Then
            Return
        End If

        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case e.Col
                    Case 5
                        Try
                            If IsNothing(Fg(Fg.Row, 2)) Then
                                MsgBox("La cantidad no debe quedar vacía")
                                Fg.Col = 2
                                ENTRA = True
                                Return
                            End If
                            If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                                MsgBox("La cantidad no debe quedar vacía")
                                Fg.Col = 2
                                ENTRA = True
                                Return
                            End If
                            Var15 = "Busqueda"

                            Var4 = ""
                            Var2 = "Articulo"
                            Var5 = LINEA_EN_VENTAS

                            ENTRA = False
                            Fg.FinishEditing()
                            ENTRA = True

                            ReDim aDOCS(0)

                            aDOCS(0) = ""

                            FrmSelItem2.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                Fg(Fg.Row, 4) = Var4 'CVE_ART
                                Fg(Fg.Row, 6) = Var5 'DESCR

                                Dim SIGUE As Boolean = True, RW_ As Integer, NumPart As Integer = 0, CVE_ART As String

                                CVE_ART = Var4
                                Try
                                    If Not IsNothing(aDOCS) Then
                                        For k = 0 To aDOCS.Length - 1
                                            If Not IsNothing(aDOCS(k)) Then
                                                If aDOCS(k).Length > 0 Then
                                                    If SIGUE Then
                                                        SIGUE = False
                                                        RW_ = Fg.Row
                                                    Else
                                                        RW_ = 0
                                                    End If
                                                    LLENAR_GRID_ARTICULO(aDOCS(k).Trim, RW_)
                                                    NumPart += 1
                                                End If
                                            End If
                                        Next
                                    End If
                                Catch ex As Exception
                                End Try

                                CALCULAR_IMPORTES()

                                Var2 = "" : Var4 = "" : Var5 = ""
                                ENTRA = True

                                ENTRA = True

                                If NumPart > 1 Then

                                    Dim s As String

                                    If Fg.Row > 0 Then
                                        If Fg(Fg.Row, 4).ToString.Trim.Length > 0 Then
                                            '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                            '   1            2            3            4            5            6            7            8            9           10
                                            s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                            '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                                            '    11           12           13           14           15           16           17           18           19           20           21
                                            s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                            ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                            '    22          23           24           25           26           27           28           29           30          31
                                            s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                                            '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                            '    32            33          34          35
                                            s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                                            Fg.AddItem("" & vbTab & s)
                                        End If
                                    End If

                                    Fg.Row = Fg.Rows.Count - 1
                                    Fg.Col = 1
                                    Fg.Col = 2
                                Else
                                    LLENAR_GRID_ARTICULO(CVE_ART.Trim, Fg.Row)

                                    If DESC_X_PARTIDA = 1 Then
                                        Fg.Col = 8 'DESCUENTO
                                    Else
                                        If IMPUESTOS_X_PARTIDA = 1 Then
                                            Fg.Col = 9 'IMPU1
                                        Else
                                            Fg.Col = 13 'PRECIO
                                        End If
                                    End If
                                End If

                                ENTRA = True
                                Fg.StartEditing()
                                TXTN.SelectAll()
                                Var2 = ""
                                Var4 = ""
                                Var5 = ""
                            End If

                        Catch ex As Exception
                            BITACORATPV("2090. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("2090. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Case 14

                        If Fg(Fg.Row, 4).ToString.Length = 0 Then
                            MsgBox("Por favor capture la clave del artículo")
                            Fg.Col = 4
                            Return
                        End If

                        Var17 = Fg(Fg.Row, 4)
                        Var22 = 0
                        frmSelPrecio.ShowDialog()
                        If Var22 > 0 Then
                            Fg(Fg.Row, 13) = Var22

                            If Fg.Row = Fg.Rows.Count - 1 Then
                                Dim s As String
                                '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                '   1            2            3            4            5            6            7            8            9           10
                                s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART      FAC_CIERRE  NO SE USA    NUM_PAR       DOC_ANT     TIP_DOC_ANTC    
                                '    11           12           13           14           15           16           17           18           19           20           21
                                s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab

                                ' CVE_OBS    CVE_OBS_PAR   CON LOTE      REG_LTPD    Unidad       NO SE USA     CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                '    22          23           24           25           26           27           28           29           30          31
                                s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab

                                '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                '     3 2          33         34          35
                                s &= " " & vbTab & 0 & vbTab & 0 & vbTab & 0

                                Fg.AddItem("" & vbTab & s)
                            End If
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 2

                        End If
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            BITACORATPV("2100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If e.KeyCode = Keys.F3 Then
                BarGrabar_Click(Nothing, Nothing)
                Return
            End If

        Catch ex As Exception
            Bitacora("445. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Sub LLENAR_GRID_ARTICULO(FCVE_ART As String, Optional FROW As Integer = 1)
        Try
            Dim SUM_CANT As Decimal = 0, CANT As Decimal, LINEA As String = "", s As String, ULT_COSTO As Single = 0, PRECIO As Single
            Dim EXIST_ART As Boolean = False, EXISTECI As Decimal = 0, TIPO_ELE As String = "", EXIS As Boolean = False
            Dim CON_LOTE As String = "", PEDIR_LOTE As Boolean = False, CONTINUA As Boolean, NOPASA As Boolean, CVE_ART As String = ""

            If FCVE_ART.Trim.Length = 0 Then
                Return
            End If

            Fg.Redraw = False
            Fg.BeginUpdate()

            ENTRA = False
            Fg.FinishEditing()
            ENTRA = True

            EXIST_NOT = False
            ENTRA = False

            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, 
                ISNULL(CON_LOTE,'') AS CONLOTE, EXIST, TIPO_ELE, ISNULL(LIN_PROD,'') AS LINEA, ISNULL(EXIST,0) AS EXIS,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 2),0) AS P2,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 3),0) AS P3,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 4),0) AS P4,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 5),0) AS P5,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 6),0) AS P6,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 7),0) AS P7,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 8),0) AS P8,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 9),0) AS P9,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 10),0) AS P10,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 11),0) AS P11,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 12),0) AS P12,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 13),0) AS P13,
                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 14),0) AS P14
                FROM INVE" & Empresa & " I
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                WHERE I.CVE_ART = '" & FCVE_ART & "' OR CVE_ALTER = '" & FCVE_ART & "'"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_ART = dr("CVE_ART")
                            TIPO_ELE = dr("TIPO_ELE")
                            LINEA = dr("LINEA")
                            EXISTECI = dr("EXIS")
                            EXIST_ART = True
                            NOPASA = True
                            CONTINUA = True
                            If (TIPO_VENTA = "V" Or TIPO_VENTA = "F") Or (VALIDAR_EXIST_PED = 1 And Fg(Fg.Row, 30) = "P") Then
                                If Fg(Fg.Row, 2) > EXISTECI And TIPO_ELE <> "S" Then
                                    MsgBox("Existencia insuficiente del producto " & FCVE_ART & " - " & dr("DESCR"))
                                    CONTINUA = False
                                    EXIST_NOT = True
                                End If
                            End If

                            If CONTINUA Then
                                If FROW = 0 Then
                                    '              cant          ALM        ARTICULO      BOTON       DESCR       UNI_MED       DESC1         IMP1         IMP2
                                    '   1            2            3            4            5            6            7            8            9           10
                                    s = "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                                    '   IMP3         IMP4        PRECIO     sel precio     SUBTOT       CVE_ART         1            2        NUM_PAR   CVE_DOC_ENLA    ENLA_TIP_DOC    
                                    '    11           12           13           14           15           16           17           18           19           20           21
                                    s &= "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab
                                    ' CVE_OBS    CVE_OBS_PAR   CON LOTE       LOTE        Unidad      REG_LTPD      CVE_ESQ    MONTO REM     TIPO_ELE     LINEA       
                                    '    22          23           24           25           26           27           28           29           30          31
                                    s &= 0 & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & 0 & vbTab & "" & vbTab
                                    '(P)POLITICA PREC PUBLIC=LISTA_PREC_VTA=CANT_POLIT                                  
                                    '   32           33          34           35
                                    s &= 0 & vbTab & "" & vbTab & "" & vbTab & ""
                                    Fg.AddItem("" & vbTab & s)
                                    FROW = Fg.Rows.Count - 1
                                    Fg.Col = 1
                                    Fg(FROW, 2) = 1
                                End If
                                CVE_ART_P = CVE_ART

                                If TXT.Text = CVE_ART Then
                                    CVE_ART_P = ""
                                Else
                                    CVE_ART_P = CVE_ART
                                End If

                                Fg(FROW, 4) = CVE_ART
                                Fg(FROW, 6) = dr("DESCR")
                                Fg(FROW, 7) = dr("UNI_MED")
                                Fg(FROW, 8) = TDESC.Text
                                Fg(FROW, 9) = dr("IMPUESTO1") 'IEPS
                                Fg(FROW, 10) = dr("IMPUESTO2") 'IMPU2
                                Fg(FROW, 11) = dr("IMPUESTO3") 'IMPU4
                                Fg(FROW, 12) = dr("IMPUESTO4") 'IVA
                                Fg(FROW, 23) = dr("CONLOTE") 'CON LOTE S/N
                                Fg(FROW, 28) = dr("CVE_ESQIMPU")
                                Fg(FROW, 30) = dr.ReadNullAsEmptyString("TIPO_ELE")
                                Fg(FROW, 31) = dr.ReadNullAsEmptyString("LINEA")

                                CANT = Fg(FROW, 2)
                                LINEA = Fg(FROW, 31)

                                If Fg(FROW, 16) <> FCVE_ART Then

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
                                    Fg(FROW, 13) = Math.Round(PRECIO, 4)
                                    Fg(FROW, 16) = CVE_ART
                                End If
                            Else
                                Fg.Col = 4
                                NOPASA = False
                            End If
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            '=================================================================================
            If EXIST_ART Then
                If NOPASA Then
                    Var4 = "" : Var3 = ""
                    Var5 = FCVE_ART

                    If CON_LOTE = "S" And PEDIR_LOTE Then
                        Var3 = ""
                        Var4 = ""
                        'FrmLoteSel.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            Fg(Fg.Rows.Count - 1, 24) = Var4 ' REGRESA EL LOTE
                            Fg(Fg.Rows.Count - 1, 25) = Var3 ' REG_LTPD
                        End If
                    End If
                    'POLITICAS ================================================================================================

                    APLICAR_POLITICAS(LINEA, CVE_ART, CANT, 0)
                Else
                    Fg.Col = 2
                    Fg(Fg.Row, 4) = "" 'CVE_ART
                    Fg(Fg.Row, 6) = "" 'DESCR
                    tMagico2.Focus()
                    Fg.StartEditing()
                End If
            Else
                Dim result = RJMessageBox.Show("Artículo inexistente", "Advertencia", MessageBoxButtons.OK)
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()
        ENTRA = True
    End Sub
    Sub APLICAR_POLITICAS(FLINEA As String, FCVE_ART As String, FCANT As Decimal, Optional CANT_ELIMINADA As Decimal = 0)
        'POLITICAS ================================================================================================

        Dim SUM_CANT As Decimal = 0, LISTA_PREC_PROMO As Decimal, DESC_PROMO As Decimal, CANT_POLIT As Decimal, NUM_PZAS_POLIT As Integer
        Dim LISTA_PREC_VTA As Decimal, DESC_VTA As Decimal, PREC_PUBLICO As Decimal, P_LISTA1 As Decimal, CANT_VTA As Decimal
        Dim CODIGO As String, CLASIFIC As String = "", PREC As Decimal, ART_O_LIN As Integer

        Fg.Redraw = False
        Fg.BeginUpdate()

        ENTRA = False
        Fg.FinishEditing()
        ENTRA = True

        TXTN.UpdateValueWithCurrentText()
        Try
            If Fg(Fg.Row, 4).ToString.Length = 0 Then
                'Return
            End If

            For z = 1 To Fg.Rows.Count - 1
                If FLINEA = Fg(z, 31) Then
                    SUM_CANT += Fg(z, 2)
                End If
            Next

            SUM_CANT -= CANT_ELIMINADA

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT ISNULL(ARTICULO_O_LINEA,0) AS ART_O_LIN 
                        FROM INVE" & Empresa & " WHERE CVE_ART = '" & FCVE_ART & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            ART_O_LIN = dr("ART_O_LIN")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try


            SUB_PROMOCIONES(FCVE_ART, FLINEA, ART_O_LIN, SUM_CANT, LISTA_PREC_PROMO, DESC_PROMO, CLASIFIC)
            'SUB_PROMOCIONES(FCVE_ART, FLINEA, ART_O_LIN, SUM_CANT, LISTA_PREC_PROMO, DESC_PROMO, CLASIFIC)
            If LISTA_PREC_PROMO > 0 Or DESC_PROMO > 0 Then

                If LISTA_PREC_PROMO > 0 Then
                    LISTA_PREC_VTA = LISTA_PREC_PROMO
                Else
                    If DESC_PROMO > 0 Then
                        DESC_VTA = DESC_PROMO
                    End If
                End If

                Try 'OBTIENE EL PRECIO DE LA POLITICA DEL ULTIMOO ARTICULO
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT 
                            ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                            ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1
                            FROM INVE" & Empresa & " I
                            LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                            WHERE (I.CVE_ART = '" & FCVE_ART & "' OR ISNULL(A.CVE_ALTER,'--') = '" & FCVE_ART & "')"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                PREC_PUBLICO = dr("P1")
                                P_LISTA1 = dr("PL1")
                                If PREC_PUBLICO = 0 Then
                                    PREC_PUBLICO = P_LISTA1
                                End If
                                PREC = PREC_PUBLICO
                            End If
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("2650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try 'OBTIEN LAS CANTIDADES EN LA POLITICA DE LA ULTIMA LINEA DEL PRODUCTO
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(RANGO11,0) AS R1, ISNULL(RANGO21,0) AS R2, ISNULL(RANGO31,0) AS R3, ISNULL(RANGO41,0) AS R4, 
                            ISNULL(RANGO51,0) AS R5, ISNULL(RANGO51,0) AS R6, ISNULL(RANGO51,0) AS R7, ISNULL(RANGO51,0) AS R8,
                            LP1, LP2, LP3, LP4, LP5, LP6, LP7, LP8 
                            FROM GCPROMOCIONES PM 
                            WHERE LINEA = '" & FLINEA & "'"
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            While dr.Read
                                If LISTA_PREC_VTA = dr("LP1") Then
                                    CANT_POLIT = dr("R1")
                                ElseIf LISTA_PREC_VTA = dr("LP2") Then
                                    CANT_POLIT = dr("R2")
                                ElseIf LISTA_PREC_VTA = dr("LP3") Then
                                    CANT_POLIT = dr("R3")
                                ElseIf LISTA_PREC_VTA = dr("LP4") Then
                                    CANT_POLIT = dr("R4")
                                ElseIf LISTA_PREC_VTA = dr("LP5") Then
                                    CANT_POLIT = dr("R5")
                                ElseIf LISTA_PREC_VTA = dr("LP6") Then
                                    CANT_POLIT = dr("R6")
                                ElseIf LISTA_PREC_VTA = dr("LP7") Then
                                    CANT_POLIT = dr("R7")
                                Else
                                    CANT_POLIT = dr("R8")
                                End If
                            End While
                        End Using
                    End Using
                Catch ex As Exception
                    Bitacora("2650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                For z = 1 To Fg.Rows.Count - 1
                    If FLINEA = Fg(z, 31) Then
                        CODIGO = Fg(z, 4)
                        CANT_VTA = Fg(z, 2)
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT I.CVE_ART, ULT_COSTO, 
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1
                                FROM INVE" & Empresa & " I
                                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                                WHERE (I.CVE_ART = '" & CODIGO & "' OR ISNULL(A.CVE_ALTER,'--') = '" & CODIGO & "')"
                            cmd.CommandText = SQL
                            Using dr As SqlDataReader = cmd.ExecuteReader
                                If dr.Read Then
                                    PREC_PUBLICO = dr("P1")
                                    P_LISTA1 = dr("PL1")
                                    If PREC_PUBLICO = 0 Then
                                        PREC_PUBLICO = P_LISTA1
                                    End If
                                    If Math.Round(PREC, 1) = Math.Round(PREC_PUBLICO, 1) Then
                                        NUM_PZAS_POLIT += CANT_VTA
                                        Fg(z, 32) = "P" 'POLITICA
                                        Fg(z, 33) = PREC_PUBLICO 'PRECIO
                                        Fg(z, 34) = LISTA_PREC_VTA 'LISTA DE PRECIOS
                                        Fg(z, 35) = CANT_POLIT 'PIEZAS
                                    Else
                                        Debug.Print("")
                                    End If
                                End If
                            End Using
                        End Using
                    End If
                Next

                If CANT_ELIMINADA > 0 Then
                    NUM_PZAS_POLIT -= CANT_ELIMINADA
                End If

                If NUM_PZAS_POLIT >= CANT_POLIT Then
                    For z = 1 To Fg.Rows.Count - 1

                        If FLINEA = Fg(z, 31) Then
                            CODIGO = Fg(z, 4)
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT I.CVE_ART, ULT_COSTO, 
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1
                                FROM INVE" & Empresa & " I
                                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                                WHERE (I.CVE_ART = '" & CODIGO & "' OR ISNULL(A.CVE_ALTER,'--') = '" & CODIGO & "')"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        PREC_PUBLICO = dr("P1")
                                        P_LISTA1 = dr("PL1")
                                        If PREC_PUBLICO = 0 Then
                                            PREC_PUBLICO = P_LISTA1
                                        End If
                                        If Math.Round(PREC, 1) = Math.Round(PREC_PUBLICO, 1) Then
                                            Fg(z, 0) = "P"
                                            'Fg(z, 9) = IMPU1
                                            Fg(z, 13) = PREC_PUBLICO
                                        End If
                                    End If
                                End Using
                            End Using
                        End If
                    Next
                Else
                    For z = 1 To Fg.Rows.Count - 1

                        If FLINEA = Fg(z, 31) Then
                            CODIGO = Fg(z, 4)
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT I.CVE_ART, ULT_COSTO, 
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1
                                FROM INVE" & Empresa & " I
                                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                                WHERE (I.CVE_ART = '" & CODIGO & "' OR ISNULL(A.CVE_ALTER,'--') = '" & CODIGO & "')"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        PREC_PUBLICO = dr("P1")
                                        P_LISTA1 = dr("PL1")
                                        If PREC_PUBLICO = 0 Then
                                            PREC_PUBLICO = P_LISTA1
                                        End If
                                        If Math.Round(PREC, 1) = Math.Round(PREC_PUBLICO, 1) Then
                                            Fg(z, 0) = ""
                                            'Fg(z, 9) = P_LISTA1
                                            Fg(z, 13) = P_LISTA1

                                            Fg(z, 32) = "" 'POLITICA
                                            Fg(z, 33) = 0 'PREC_PUBLICO 'PRECIO
                                            Fg(z, 34) = 0 'LISTA_PREC_VTA 'LISTA DE PRECIOS
                                            Fg(z, 35) = 0 'CANT_POLIT 'PIEZAS
                                        End If
                                    End If
                                End Using
                            End Using
                        End If
                    Next
                End If
            Else
                '██████████████████████████████████████████████████████████████████████████████████████████

                ' NO SE CUMPLIO LA POLITICA Y SE PROCEDE A QUITARLA
                If IsNothing(Fg(Fg.Row, 33)) AndAlso Not IsNumeric(Fg(Fg.Row, 33)) Then
                    PREC = 0
                Else
                    PREC = Fg(Fg.Row, 33)
                End If

                If IsNothing(Fg(Fg.Row, 34)) AndAlso Not IsNumeric(Fg(Fg.Row, 34)) Then
                    LISTA_PREC_VTA = 1
                Else
                    LISTA_PREC_VTA = Fg(Fg.Row, 34)
                End If

                If PREC > 0 Then
                    For z = 1 To Fg.Rows.Count - 1

                        If FLINEA = Fg(z, 31) Then
                            CODIGO = Fg(z, 4)

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                SQL = "SELECT I.CVE_ART, ULT_COSTO, 
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = " & LISTA_PREC_VTA & "),0) AS P1,
                                ISNULL((SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS PL1
                                FROM INVE" & Empresa & " I
                                LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART
                                WHERE (I.CVE_ART = '" & CODIGO & "' OR ISNULL(A.CVE_ALTER,'--') = '" & CODIGO & "')"
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        PREC_PUBLICO = dr("P1")
                                        P_LISTA1 = dr("PL1")
                                        If PREC_PUBLICO = 0 Then
                                            PREC_PUBLICO = P_LISTA1
                                        End If
                                        If Math.Round(PREC, 1) = Math.Round(PREC_PUBLICO, 1) Then
                                            Fg(z, 0) = ""
                                            'Fg(z, 9) = IMPU1
                                            Fg(z, 13) = P_LISTA1

                                            Fg(z, 32) = "" 'POLITICA
                                            Fg(z, 33) = 0 'PREC_PUBLICO 'PRECIO
                                            Fg(z, 34) = 0 'LISTA_PREC_VTA 'LISTA DE PRECIOS
                                            Fg(z, 35) = 0 'CANT_POLIT 'PIEZAS
                                        End If
                                    End If
                                End Using
                            End Using
                        End If
                    Next
                End If
            End If

            Var13 = "SOLOTOTAL"
            CALCULAR_IMPORTES()
            'FIN POLITICAS ============================================================================================
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Fg.Redraw = True
        Fg.EndUpdate()
    End Sub
    Private Sub SUB_PROMOCIONES(ByVal FCVE_ART As String, ByVal FLINEA As String, ByVal FARTICULO_O_LINEA As Integer, ByVal FCANT As Decimal,
                ByRef FLISTA_PREC As Integer, ByRef FPORC As Decimal, FCLIENTE As String)
        ''SUB_PROMOCIONES(FCVE_ART, FLINEA, ART_O_LIN, SUM_CANT, LISTA_PREC_PROMO, DESC_PROMO, CLASIFIC)
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CLASIFIC As String = "", CADENA As String

        FLISTA_PREC = 0 : FPORC = 0

        If FARTICULO_O_LINEA = 1 Then
            CADENA = "PM.CVE_ART = '" & FCVE_ART & "'"
        Else
            CADENA = "PM.LINEA = '" & FLINEA & "'"
        End If

        Try
            SQL = "SELECT ISNULL(PM.TIPO, -1) AS TIPO_PROM, ISNULL(PORC1,0) AS P1, ISNULL(PORC2,0) AS P2,
                ISNULL(PORC3,0) AS P3, ISNULL(PORC4,0) AS P4, ISNULL(PORC5,0) AS P5, ISNULL(LP1,0) AS L1,
                ISNULL(LP2,0) AS L2, ISNULL(LP3,0) AS L3, ISNULL(LP4,0) AS L4, ISNULL(LP5,0) AS L5, 
                CASE WHEN ISNULL(PM.TIPO, -1) = 1
                THEN
                    CASE 
                         WHEN " & FCANT & " >= ISNULL(RANGO81,0) AND ISNULL(RANGO81,0) > 0 THEN ISNULL(LP8,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO71,0) AND ISNULL(RANGO71,0) > 0 THEN ISNULL(LP7,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO61,0) AND ISNULL(RANGO61,0) > 0 THEN ISNULL(LP6,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO51,0) AND ISNULL(RANGO51,0) > 0 THEN ISNULL(LP5,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO41,0) AND ISNULL(RANGO41,0) > 0 THEN ISNULL(LP4,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO31,0) AND ISNULL(RANGO31,0) > 0 THEN ISNULL(LP3,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO21,0) AND ISNULL(RANGO21,0) > 0 THEN ISNULL(LP2,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO11,0) AND ISNULL(RANGO11,0) > 0 THEN ISNULL(LP1,0) ELSE 0 END
                ELSE
                    CASE 
                         WHEN " & FCANT & " >= ISNULL(RANGO81,0) AND ISNULL(RANGO81,0) > 0 THEN ISNULL(PORC8,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO71,0) AND ISNULL(RANGO71,0) > 0 THEN ISNULL(PORC7,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO61,0) AND ISNULL(RANGO61,0) > 0 THEN ISNULL(PORC6,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO51,0) AND ISNULL(RANGO51,0) > 0 THEN ISNULL(PORC5,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO41,0) AND ISNULL(RANGO41,0) > 0 THEN ISNULL(PORC4,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO31,0) AND ISNULL(RANGO31,0) > 0 THEN ISNULL(PORC3,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO21,0) AND ISNULL(RANGO21,0) > 0 THEN ISNULL(PORC2,0)
                         WHEN " & FCANT & " >= ISNULL(RANGO11,0) AND ISNULL(RANGO11,0) > 0 THEN ISNULL(PORC1,0) ELSE 0 END
                END AS RESULT
                FROM GCPROMOCIONES PM 
                WHERE " & CADENA & " AND 
                (ISNULL(RANGO11,0) > 0 OR ISNULL(RANGO21,0) > 0 OR ISNULL(RANGO31,0) > 0 OR ISNULL(RANGO41,0) > 0 OR ISNULL(RANGO51,0) > 0 OR 
                ISNULL(PM.TIPO, -1) = 0 OR ISNULL(PM.TIPO, -1) = 1)"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then

                        If dr("TIPO_PROM") = 1 Then
                            FLISTA_PREC = dr("RESULT")
                        Else
                            FPORC = dr("RESULT")
                        End If

                    End If
                End Using
            End Using

            If FCLIENTE.Trim.Length > 0 Then
                SQL = "SELECT CLASIFIC FROM CLIE" & Empresa & " WHERE CLAVE = '" & FCLIENTE & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CLASIFIC = dr.ReadNullAsEmptyString("CLASIFIC")
                        End If
                    End Using
                End Using
            End If

            If FLISTA_PREC > 0 Or FPORC > 0 Then
                If CLASIFIC <> "99999" Then
                End If
            End If
        Catch ex As SqlException
            ' Log the original exception here
            For Each sqlError As SqlError In ex.Errors

                BITACORADB(sqlError.Number & "," & sqlError.Message)

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
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboALmacenFG_DropDownClosed(sender As Object, e As C1.Win.C1Input.DropDownClosedEventArgs) Handles CboALmacenFG.DropDownClosed
        Try

        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboAlmacen_DropDownClosed(sender As Object, e As C1.Win.C1Input.DropDownClosedEventArgs) Handles CboAlmacen.DropDownClosed

        Try
            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 3) = CboAlmacen.Items(CboAlmacen.SelectedIndex)
            Next
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboALmacenFG_KeyDown(sender As Object, e As KeyEventArgs) Handles CboALmacenFG.KeyDown
        Try
            If e.KeyCode = 13 Then
                Fg.Col = 4
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmTPV_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F3
                    BarGrabar_Click(Nothing, Nothing)
                Case Keys.F4
                    BarTotales_Click(Nothing, Nothing)
                Case Keys.F5
                    BarEnlaceDocumento_Click(Nothing, Nothing)
                Case Keys.F6
                    BarKardex_Click(Nothing, Nothing)
                Case Keys.F7
                    BarImprimir_Click_1(Nothing, Nothing)
                Case Keys.F8
                    BarEliminar_Click(Nothing, Nothing)
                Case Keys.F9
                    BarSerie_Click(Nothing, Nothing)
                Case Keys.F10
                    BarCancelar_Click(Nothing, Nothing)
                Case Keys.F11
                    BarObserDoc_Click(Nothing, Nothing)
                Case Keys.F12
                    BarObserPar_Click(Nothing, Nothing)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        If e.Row >= Fg.Rows.Fixed And e.Col = Fg.Cols.Fixed - 1 Then
            Dim rowNumber As Integer = e.Row - Fg.Rows.Fixed + 1
            e.Text = rowNumber.ToString()
        End If
    End Sub


    Private Sub CboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMoneda.SelectedIndexChanged
        If CboMoneda.Text.Contains("MXN") Then
            txTC.Value = 1
            txTC.ReadOnly = True
        Else
            Try
                Dim NUM_MONEDA As Integer
                NUM_MONEDA = Convert.ToInt32(Split(CboMoneda.Text, "|")(0).Trim)
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = String.Format("SELECT NUM_MONED, DESCR, TCAMBIO, CVE_MONED FROM MONED" & Empresa & " WHERE STATUS = 'A' AND NUM_MONED = {0}", NUM_MONEDA)
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            txTC.Value = dr("TCAMBIO")
                            txTC.ReadOnly = False
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
        End If
    End Sub
End Class