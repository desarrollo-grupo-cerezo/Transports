Imports C1.Win.C1Themes
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Input
Imports System.ComponentModel

Public Class FrmGastos

    Private ReadOnly ButtonList As New ArrayList()
    Private kk As Integer
    Private ENTRA_TXT As Boolean
    Private ENTRA As Boolean
    Private Obser As String = ""
    Private Obser_par As String = ""
    Private CAPTURA_PAGO_COMPRAS As Integer
    Private ALTA_PROVEEDORES As Integer
    Private ALTA_PRODUCTOS As Integer
    Private T_DOC_ENL As String = ""
    Private DOC_ENL As String = ""
    Private OBSER_X_DOCUMENTO As Integer = 0
    Private OBSER_X_PARTIDA As Integer = 0
    Private c_ As Integer
    Private idLlantasNuevas As String

    Private INDIRECTOS_X_PARTIDA As Integer
    Private C_IMPUESTOS As Integer
    Private C_ALMACEN As Integer
    Private COMPRA_TOT As String

    Private SERIE_GASTO As String = ""

    Private COMPRAS_NEW As Boolean = False
    Private CompEdit As Boolean = 0
    Private TIPO_COMPRA_LOCAL As String
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_CONTROLES1()
        CARGAR_CONTROLES2()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        If Var4 = "NO EXISTE" Then
            MsgBox("NO existe la serie de gastos verifique por favor en Parámetros-Compras boton 'Series'")
        End If
    End Sub
    Private Sub FrmGastos_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If TIPO_COMPRA_LOCAL.Trim.Length = 0 Then
            MsgBox("Por favor seleccione tipo de compra")
            Me.Close()
        End If
    End Sub
    Sub CARGAR_CONTROLES2()
        Try
            If Var11 = "edit" Then
                CompEdit = True
                LtCVE_DOC.Text = Var12

                BUSCAR_GASTO(TIPO_COMPRA_LOCAL, Var12, "edit")


                tDesc.Enabled = False
                tDesFin.Enabled = False

                CompEdit = False
                TRefProv.Enabled = False
                'NO SE PUEDE MODIFICAR
                TPROV.Enabled = False
                CboDepto.Enabled = False
                tEsquema.Enabled = False
                CboTipoCompra.Enabled = False
                BarGrabar.Enabled = False
                BarEliminar.Enabled = False
                BarSerie.Enabled = False
                BarAltaProv.Enabled = False
                BarAltaArticulo.Enabled = False
                'BarObserDoc.Enabled = False
                'BarObserPar.Enabled = False
                btnProv.Enabled = False
                BarGrabarXML.Visible = True
            Else
                COMPRAS_NEW = True
                CompEdit = False

                BarGrabarXML.Visible = False

                TPROV.Enabled = True
                TRefProv.Enabled = True
                tDesc.Enabled = True
                tDesFin.Enabled = True
                CboDepto.Enabled = True
                tEsquema.Enabled = True
                Fg.Enabled = True
                CboTipoCompra.Enabled = True
                F1.Enabled = True

                F2.Enabled = True

                BarGrabar.Enabled = True
                BarEliminar.Enabled = True
                BarObserDoc.Enabled = True
                BarObserPar.Visible = True
                BarSerie.Enabled = True

                If ALTA_PROVEEDORES Then
                    BarAltaProv.Enabled = True
                Else
                    BarAltaProv.Enabled = False
                End If
                If ALTA_PRODUCTOS Then
                    BarAltaArticulo.Enabled = True
                Else
                    BarAltaArticulo.Enabled = False
                End If
            End If
            Fg.Row = 1
            Fg.Col = 2

            TPROV.Focus()
            TPROV.Select()
        Catch ex As Exception
            Bitacora("27.11 " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("27.1 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        idLlantasNuevas = Guid.NewGuid().ToString
    End Sub
    Sub CARGAR_CONTROLES1()

        Try
            Dim ThemeLocal As String

            ThemeLocal = "VS2013Blue"
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeLocal, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try

            COMPRA_TOT = Var17
            If COMPRA_TOT = "" Then
                With Screen.PrimaryScreen.WorkingArea
                    Me.SetBounds(.Left, .Top, .Width, .Height)
                End With
                Me.WindowState = FormWindowState.Maximized

                Split1.SizeRatio = 20
                Split2.SizeRatio = 65
                Split3.SizeRatio = 15

                SplitM.SplitterWidth = 1

            Else
                Me.FormBorderStyle = FormBorderStyle.FixedSingle
                Me.WindowState = FormWindowState.Normal
                Me.CenterToScreen()

                Me.Width = Screen.PrimaryScreen.Bounds.Width - 25
                C_IMPUESTOS = (Screen.PrimaryScreen.Bounds.Height * 0.3)
                Me.Height = Screen.PrimaryScreen.Bounds.Height - C_IMPUESTOS

                Me.Top = C_IMPUESTOS / 2

                Label19.Visible = False
                CboTipoCompra.Visible = False
                BarSerie.Visible = False
                BarAltaArticulo.Visible = False
                BarImprimir.Visible = False
            End If

            TIPO_COMPRA_LOCAL = "g"
            CARGA_PARAM_COMPRAS()
            CARGA_PARAM_INVENT()

            Try
                'CVE_DEPTO, DESCR, STATUS FROM GCDEPTOS 
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_DEPTO, DESCR FROM GCDEPTOS WHERE ISNULL(STATUS,'A') = 'A' ORDER BY CVE_DEPTO"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            CboDepto.Items.Add(dr("CVE_DEPTO").ToString.PadLeft(2, "0") & " " & dr("DESCR"))
                        End While
                    End Using
                End Using
                CboDepto.SelectedIndex = -1

            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If ALTA_PROVEEDORES = 0 Then
                BarAltaProv.Visible = False
            Else
                BarAltaProv.Visible = True
            End If
            If ALTA_PRODUCTOS = 0 Then
                BarAltaArticulo.Visible = False
            Else
                BarAltaArticulo.Visible = True
            End If
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
            Fg.Cols(3).Visible = False 'ALMACEN
            Fg.Cols(7).Visible = False 'UNI MED

            Fg.Cols(15).Visible = False
            Fg.Cols(16).Visible = False
            Fg.Cols(17).Visible = False
            Fg.Cols(18).Visible = False
            Fg.Cols(19).Visible = False

            Fg.Cols(21).Visible = False
            Fg.Cols(22).Visible = False

            BarRutaXML.Visible = True

            SplitM.Dock = DockStyle.Fill

        Catch ex As Exception
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & k
                Next
            End If
            Fg.Cols(0).Width = 60
        Catch ex As Exception
        End Try

        Try
            Try
                F1.Value = Date.Today
                F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F1.CustomFormat = "dd/MM/yyyy"
                F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F1.EditFormat.CustomFormat = "dd/MM/yyyy"

                F2.Value = Date.Today
                F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F2.CustomFormat = "dd/MM/yyyy"
                F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F2.EditFormat.CustomFormat = "dd/MM/yyyy"

                F3.Value = Date.Today
                F3.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F3.CustomFormat = "dd/MM/yyyy"
                F3.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
                F3.EditFormat.CustomFormat = "dd/MM/yyyy"


                If TIPO_COMPRA_LOCAL <> "c" Then
                    F3.Visible = False
                    Label11.Visible = False
                End If
            Catch ex As Exception
            End Try

            tEsquema.Value = 0
            tDesc.Value = 0
            tDesFin.Value = 0
            LtRFC.Tag = "0"
            LtCVE_DOC.Tag = ""
            txt.Text = ""
            txtN.Value = 0

            Fg.Cols(5).Width = 25

            If Var11 = "edit" Then
                Fg.AllowEditing = False
                Fg.Cols(2).AllowEditing = False
                Fg.Cols(4).AllowEditing = False
                Fg.Cols(9).AllowEditing = False
                txt.Enabled = False
                txtN.Enabled = False

                BarImprimir.Visible = True
            Else
                For Each r As Row In Fg.Rows
                    If r.Index > 0 Then
                        'Set row number
                        r(0) = r.Index
                        'Create Button
                        Dim bt As New Button With {
                            .BackColor = SystemColors.Control,
                            .Image = My.Resources.lupa15,
                            .Text = "",
                            .Tag = r.Index 'Tag it so the button knows which row it's on
                            }
                        AddHandler bt.Click, AddressOf BtnSelArt_Click
                        ButtonList.Add(New HostedControl(Fg, bt, r.Index, 5))
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            CboTipoCompra.Items.Clear()
            Fg.Cols(23).Visible = False

            LETRA_GASTO = SERIE_GASTO
            LtCompras.Text = "GASTOS"
            CboTipoCompra.Items.Add("Directa")
            CboTipoCompra.Items.Add("Orden de compra")
            CboTipoCompra.Items.Add("Requisición")
            If MULTIALMACEN = 1 Then


            End If
            Fg.Cols(23).Visible = True
        Catch ex As Exception
            Bitacora("27.2 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27.2 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try

            If Var11 = "edit" Then
                'Var13 = Fg(Fg.Row, 23) 'DOCUMENTO SIGUIENTE
                'Var14 = Fg(Fg.Row, 20) 'DOCUMENTO ANTERIOR

                If Var14.Trim.Length > 0 Then
                    CboTipoCompra.SelectedIndex = 0
                Else
                    CboTipoCompra.SelectedIndex = 1
                End If
            Else
                CboTipoCompra.SelectedIndex = 0
            End If

            TIPO_COMPRA_LOCAL = "g"
            FOLIO_GASTO = SIGUIENTE_FOLIO_COMPRA(TIPO_COMPRA_LOCAL, LETRA_GASTO)

            If LETRA_GASTO.Trim.Length = 0 Or LETRA_GASTO = "STAND." Then
                LtCVE_DOC.Text = "          " & Format(FOLIO_GASTO, "0000000000")
            Else
                LtCVE_DOC.Text = LETRA_GASTO & Format(FOLIO_GASTO, "0000000000")
            End If

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 1) = ""
                Fg(k, 2) = ""
                Fg(k, 3) = ""
                Fg(k, 4) = ""
                Fg(k, 5) = ""
                Fg(k, 6) = ""
                Fg(k, 7) = ""
                Fg(k, 8) = ""
                Fg(k, 9) = ""
                Fg(k, 10) = ""
                Fg(k, 11) = ""
                Fg(k, 12) = ""
                Fg(k, 13) = ""
                Fg(k, 14) = ""
                Fg(k, 15) = ""
                Fg(k, 16) = "0"
                Fg(k, 17) = ""
                Fg(k, 18) = ""
                Fg(k, 19) = "0"
                Fg(k, 20) = " "
                Fg(k, 21) = " "
                Fg(k, 22) = " "
                Fg(k, 23) = " "
                Fg(k, 24) = " "
            Next

        Catch ex As Exception
            Bitacora("27.9 " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("27.9 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
        ENTRA_TXT = True
    End Sub
    Sub DERECHOS()
        Try
            BarAltaProv.Visible = False
            BarAltaArticulo.Visible = False
            BarSerie.Visible = False
            BarImprimir.Visible = False

        Catch ex As Exception
        End Try
        Try

            SQL = "SELECT CLAVE FROM GCDERECHOS WHERE USUARIO = '" & USER_GRUPOCE & "' AND CLAVE >= 70100 AND CLAVE < 80000"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr("CLAVE")
                            Case 70101

                            Case 70130

                            Case 70160

                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            Bitacora("13. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("13. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGA_PARAM_COMPRAS()
        Dim NO_ERROR As Boolean = True

        For k = 1 To 3
            Try

                SQL = "SELECT ISNULL(CAPTURA_PAGO_COMPRAS, 0) AS C_PAGO_COMPRAS, ISNULL(C_ALTA_PROVEEDORES, 0) AS ALTA_PROVEEDORES, 
                    ISNULL(C_ALTA_PRODUCTOS, 0) AS ALTA_PRODUCTOS, ISNULL(OBSER_X_DOCUMENTO, 0) AS OBSER_X_DOC, ISNULL(OBSER_X_PARTIDA, 0) AS OBSER_X_PAR, 
                    ISNULL(INDIRECTOS_X_PARTIDA, 0) AS INDIRECTOS_X_PARTIDA, ISNULL(IMPUESTOS, 0) AS C_IMPUESTOS, ISNULL(ALMACEN, 0) AS C_ALMACEN, 
                    ISNULL(SERIE_GASTO,'') AS SERIE_G
                    FROM GCPARAMCOMPRAS"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CAPTURA_PAGO_COMPRAS = dr("C_PAGO_COMPRAS")
                            ALTA_PROVEEDORES = dr("ALTA_PROVEEDORES")
                            ALTA_PRODUCTOS = dr("ALTA_PRODUCTOS")
                            OBSER_X_DOCUMENTO = dr("OBSER_X_DOC")
                            OBSER_X_PARTIDA = dr("OBSER_X_PAR")

                            INDIRECTOS_X_PARTIDA = dr("INDIRECTOS_X_PARTIDA")
                            C_IMPUESTOS = dr("C_IMPUESTOS")
                            C_ALMACEN = dr("C_ALMACEN")
                            SERIE_GASTO = dr("SERIE_G")
                            NO_ERROR = True
                        Else
                            NO_ERROR = False
                        End If
                    End Using
                End Using

            Catch ex As Exception
                NO_ERROR = False
                Bitacora("28. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("28. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If NO_ERROR Then
                Exit For
            Else
                Bitacora("FrmGastos CARGA_PARAM_COMPRAS  ERRROR AL ABRIR LA TABLA")
            End If
        Next
    End Sub
    Sub CARGA_PARAM_INVENT()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN 
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Friend Class HostedControl
        Friend _flex As C1FlexGrid
        Friend _ctl As Control
        Friend _row As Row
        Friend _col As Column

        Friend Sub New(ByVal flex As C1FlexGrid, ByVal hosted As Control, ByVal row As Integer, ByVal col As Integer)
            ' save info 
            _flex = flex
            _ctl = hosted
            _row = flex.Rows(row)
            _col = flex.Cols(col)

            ' insert hosted control into grid 
            _flex.Controls.Add(_ctl)
        End Sub
        Friend Function UpdatePosition() As Boolean
            ' get row/col indices 
            Dim r As Integer = _row.Index
            Dim c As Integer = _col.Index
            If r < 0 OrElse c < 0 Then
                Return False
            End If

            ' get cell rect 
            Dim rc As Rectangle = _flex.GetCellRect(r, c, False)

            ' hide control if out of range 
            If rc.Width <= 0 OrElse rc.Height <= 0 OrElse Not rc.IntersectsWith(_flex.ClientRectangle) Then
                _ctl.Visible = False
                Return True
            End If

            ' move the control and show it 
            _ctl.Bounds = rc
            _ctl.Visible = True

            ' done 
            Return True
        End Function
    End Class

    Private Sub FrmGastos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        Try
            CloseTab("Captura gastos")
            If FORM_IS_OPEN("FrmGastosDoc") Then
                FrmGastosDoc.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        If TPROV.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la clave del proveedor")
            Return
        End If

        If TIPO_COMPRA_LOCAL.Trim.Length = 0 Then
            MsgBox("Por favor seleccione tipo de compra")
            Return
        End If
        Dim nReg As Integer

        Try
            nReg = 0
            For k = 1 To Fg.Rows.Count - 14
                Try
                    If Not IsNothing(Fg(k, 2)) And Not IsNothing(Fg(k, 4)) Then
                        If IsNumeric(Fg(k, 2)) Then
                            If Fg(k, 2) > 0 And Fg(k, 4).ToString.Trim.Length > 0 Then
                                nReg += 1
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("32. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            If nReg = 0 Then
                MsgBox("No existen partidas verifique por favor")
                Return
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Return
        End Try
        Dim DIASCRED As Integer
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ExiProv As Boolean

            If TPROV.Text.Trim.Length > 0 Then
                ExiProv = False
                cmd.Connection = cnSAE
                SQL = "SELECT * FROM PROV" & Empresa & " WHERE CLAVE  = '" & TPROV.Text & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                DIASCRED = 0
                If dr.Read Then
                    ExiProv = True
                    DIASCRED = dr.ReadNullAsEmptyInteger("DIASCRED")
                End If
                dr.Close()

                If Not ExiProv Then
                    MsgBox("Proveedore inexistente")
                    Return
                End If
            Else
                DIASCRED = 0
            End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If OBSER_X_DOCUMENTO = 1 Then
            Var4 = Obser
            Var5 = IIf(CompEdit, "EDIT", "NUEVO")
            frmObserDocumento.ShowDialog()
            Obser = Var4
        End If

        Var7 = "GRABAR"
        CALCULAR_IMPORTES()
        FrmGastosTotales.ShowDialog()
        If Var8 = "GRABAR" Then
            GUARDAR()
        End If
    End Sub
    Sub GUARDAR()
        Dim Continua As Boolean

        Dim FOLIO_ASIGNADO As Boolean, CVE_DOC As String, DESCR As String, CANT As Decimal, CVE_ART As String, COSTO As Decimal

        Dim IMPORTE As Decimal, IMPU1 As Decimal, IMPU4 As Decimal, IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer
        Dim IMP4APLA As Integer, CVE_ESQIMPU As Integer = 1, UNI_MED As String, IMP_TOT1 As Decimal, IMP_TOT4 As Decimal, cIeps As Decimal, cImpu As Decimal
        Dim nClavesNoEncontradas As Integer, CVE_CLPV As String, PREC As Decimal, IMPU2 As Decimal, IMPU3 As Decimal, ACT_INV As String, TIP_CAM As Integer
        Dim TIPO_ELEM As String, TIPO_PROD As String, CVE_OBS As Integer, REG_SERIE As Integer, E_LTPD As Integer, FACTCONV As Decimal
        Dim MINDIRECTO As Integer, NUM_MOV As Long, MAN_IEPS As String, APL_MAN_IMP As Decimal, CUOTA_IEPS As Decimal, APL_MAN_IEPS As String
        Dim MTO_PORC As Decimal, MTO_CUOTA As Decimal, NUM_PAR As Integer, NUM_ALM As Integer, TOT_PARTIDA As Decimal, DESCU As Decimal, TOTIMP1 As Decimal
        Dim TOTIMP2 As Decimal, TOTIMP3 As Decimal, TOTIMP4 As Decimal, cImpu2 As Decimal, cImpu3 As Decimal, ImporteIeps As Decimal, ImporteImpu2 As Decimal
        Dim ImporteImpu3 As Decimal, ImporteIVA As Decimal, STATUS As String, TIP_DOC As String, IMP_TOT2 As Decimal, IMP_TOT3 As Decimal, TOT_IND As Decimal
        Dim OBS_COND As String, ACT_CXP As String, ACT_COI As String, NUM_MONED As Integer, TIPCAMB As Integer, ENLAZADO As String, TIP_DOC_E As String
        Dim CTLPOL As Integer, ESCFD As String, CONTADO As String, BLOQ As String, DES_FIN_PORC As Decimal, DES_TOT_PORC As Decimal, TIP_DOC_ANT As String
        Dim DOC_ANT As String, TIP_DOC_SIG As String, DOC_SIG As String, FORMAENVIO As String, SU_REFER As String, CAN_TOT As Decimal
        Dim DES_TOT As Decimal, DES_FIN As Decimal, UUID_XML As String
        Dim FOLIO As Long, ULT_DOC As Long
        'MOVSINV
        Dim COSTO_PROMEDIO As Decimal, CVE_CPTO As Integer, CLAVE_CLPV As String, Vend As String, CANT_COST As Decimal, UNI_VENTA As String
        Dim FACTOR_CON As Decimal, SIGNO As Integer, COSTEADO As String, COSTO_PROM_INI As Decimal, COSTO_PROM_FIN As Decimal, COSTO_PROM As Decimal
        Dim DESDE_INVE As String, MOV_ENLAZADO As Integer, NUM_CPTO As Integer, NUM_CARGO As Int16
        Dim AFEC_COI As String, TCAMBIO As Int16, CVE_FOLIO As String, TIPO_MOV As String, CVE_AUT As Integer, ENTREGADA As String, REF_SIST As String
        Dim FECHA_REC As String
        Dim Usuario2 As Integer
        Dim DESC1 As Decimal
        Dim CVE_DEPTO As String = "", Sigue As Boolean

        Dim cmdProv As New SqlCommand
        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader


        CVE_DOC = ""
        Try
            Fg.FinishEditing()
        Catch ex As Exception
        End Try
        If Not Valida_Conexion() Then
            Return
        End If

        If CompEdit Then
            CVE_DOC = LtCVE_DOC.Text
        Else
            Try
                Sigue = True
                FOLIO_ASIGNADO = False

                Do While Sigue

                    If LETRA_GASTO.Trim.Length = 0 Or LETRA_GASTO = "STAND." Then
                        CVE_DOC = Space(10) & Format(FOLIO_GASTO, "0000000000")
                    Else
                        CVE_DOC = LETRA_GASTO & Format(FOLIO_GASTO, "0000000000")
                    End If

                    If EXISTE_CVE_DOC_GASTO(TIPO_COMPRA_LOCAL, CVE_DOC) Then
                        FOLIO_GASTO += 1
                        FOLIO_ASIGNADO = True
                    Else
                        Sigue = False
                    End If
                Loop
                ULT_DOC = FOLIO_GASTO
            Catch ex As Exception
                Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        'PROV
        Try
            Dim dt As DateTime = F1.Value

            FECHA_REC = dt.Year & Format(dt.Month, "00") & Format(dt.Day, "00")

            If CboDepto.SelectedIndex = -1 Then
                MsgBox("Por favor seleccione un departamento")
                Return
            End If
            CVE_DEPTO = CboDepto.Text
            If CVE_DEPTO.Trim.Length > 2 Then
                CVE_DEPTO = CVE_DEPTO.Substring(0, 2)
                CVE_DEPTO = CVE_DEPTO.Trim.Replace("0", "")
            Else
                CVE_DEPTO = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try

        If MsgBox("Realmente desea grabar el gasto?", vbYesNo) = vbNo Then
            Exit Sub
        End If

        Try
            Fg.FinishEditing()
        Catch ex As Exception
        End Try
        cmd.Connection = cnSAE

        CVE_CLPV = TPROV.Text.Trim
        If IsNumeric(CVE_CLPV.Trim) Then
            CVE_CLPV = Space(10 - CVE_CLPV.Length) & CVE_CLPV
            TPROV.Text = CVE_CLPV
        End If
        SU_REFER = TRefProv.Text
        OBS_COND = ""

        Me.Cursor = Cursors.WaitCursor
        Try
            Dim cmdExist As New SqlCommand
            Sigue = True
            IMPORTE = 0 : nClavesNoEncontradas = 0 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0 : CAN_TOT = 0 : DESCR = ""
            If Not Valida_Conexion() Then
                Return
            End If

            For i As Integer = 1 To Fg.Rows.Count - 1

                If Not Valida_Conexion() Then
                End If

                Try
                    CVE_ART = Fg(i, 4)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                Catch ex As Exception
                    CVE_ART = ""
                End Try

                Try
                    If IsNothing(Fg(i, 2)) Then
                        CANT = 0
                    Else
                        If IsNumeric(Fg(i, 2)) Then
                            CANT = Fg(i, 2)
                        Else
                            CANT = 0
                        End If
                    End If

                    If CVE_ART.Length > 0 And CANT > 0 Then
                        Try
                            DESCR = Fg(i, 6)
                            DESCR = DESCR.Replace("'", "")

                            DESC1 = Fg(i, 8)

                        Catch ex As Exception
                            Bitacora("120. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            DESC1 = 0
                        End Try
                        Try
                            UNI_MED = Fg(i, 7)
                        Catch ex As Exception
                            Bitacora("125. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try

                        If Not Valida_Conexion() Then
                            Return
                        End If
                        Try
                            SQL = "SELECT * FROM GCCATGASTOS WHERE CVE_ART = '" & CVE_ART & "'"
                            CVE_ESQIMPU = 1
                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                Else
                                    Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ARTICULO " & CVE_ART & " FrmGastos " & SQL)
                                End If
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            MsgBox("139. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("139. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CDec(Reader("IMPUESTO1"))
                                IMPU2 = CDec(Reader("IMPUESTO2"))
                                IMPU3 = CDec(Reader("IMPUESTO3"))
                                IMPU4 = CDec(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            Else
                                Bitacora("1. PROBLEMA DETECTADO EN GUARDAR NO SE ENCONTRO EL ESQUEMA IMPUESTO FrmGastos " & SQL)
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            Bitacora("141. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("141. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            COSTO = CDec(Fg(i, 13))
                            COSTO = Math.Round(CDec(COSTO), 6)

                            DES_TOT += (COSTO - (COSTO * DESC1 / 100))
                            cIeps = COSTO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CDec((COSTO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CDec(COSTO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CDec((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CDec(COSTO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = COSTO * IMPU4 / 100
                            End If

                            ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                            ImporteIVA += ImporteIVA + (COSTO * CANT * IMPU4 / 100)

                            TOTIMP1 += (CANT * cIeps)
                            TOTIMP2 += (CANT * cImpu2)
                            TOTIMP3 += (CANT * cImpu3)
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (COSTO + cIeps + cImpu2 + cImpu3 + cImpu))

                            CAN_TOT += (CANT * COSTO)

                            DESCU = DES_TOT_PORC
                        Catch ex As Exception
                            MsgBox("142. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("142. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    MsgBox("143. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("143. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            If IMPORTE = 0 Then
                'MsgBox("No se encontraron partidas con claves validas a exportar ó el costo del producto es cero")
                'Me.Cursor = Cursors.Default
                'Exit Sub
            End If
            IMP_TOT1 = TOTIMP1
            IMP_TOT2 = TOTIMP2
            IMP_TOT3 = TOTIMP3
            IMP_TOT4 = TOTIMP4

            If IsNumeric(tDesc.Text) Then
                DES_TOT_PORC = CDec(tDesc.Text)
            Else
                DES_TOT_PORC = 0
            End If
            DES_TOT = 0

            If tDesc.Text = "" Or tDesc.Text.Trim.Length = 0 Then
                tDesc.Text = "0"
            End If

            CVE_OBS = 0 : DES_FIN = 0
            STATUS = "E" : TIP_DOC = TIPO_COMPRA_LOCAL : TOT_IND = 0 : ACT_CXP = "S" : ACT_COI = "N" : NUM_MONED = 1 : TIPCAMB = 1
            ENLAZADO = "O" : TIP_DOC_E = "O" : CTLPOL = 0 : ESCFD = "N" : CONTADO = "N" : BLOQ = "N" : DES_FIN_PORC = 0
            TIP_DOC_ANT = T_DOC_ENL : DOC_ANT = DOC_ENL : TIP_DOC_SIG = "" : DOC_SIG = "" : FORMAENVIO = "" : FOLIO = ULT_DOC
            PREC = 0 : IMPU2 = 0 : IMPU3 = 0 : ACT_INV = "S" : TIP_CAM = 1 : TIPO_ELEM = "N" : TIPO_PROD = "P"
            CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : FACTCONV = 1 : MINDIRECTO = 0 : NUM_MOV = 0 : MAN_IEPS = "N" : APL_MAN_IMP = 1
            CUOTA_IEPS = 0 : APL_MAN_IEPS = "C" : MTO_PORC = 0 : MTO_CUOTA = 0
            NUM_CARGO = 1 : AFEC_COI = "A" : NUM_MONED = 1 : TCAMBIO = 1 : CTLPOL = 0 : CVE_FOLIO = ""
            TIPO_MOV = "A" : CVE_AUT = 0 : Usuario2 = "0" : ENTREGADA = "S" : REF_SIST = ""


            NUM_CPTO = 1 'CXP
            CVE_CPTO = 1 'MOVS INV
            SIGNO = 1
            NUM_ALM = 1

            Try
                Obser = RemoveCharacter(Obser)
                If Obser.Trim.Length > 0 Then
                    If TIPO_OTI = 0 Then
                        INSERT_UPDATE_OBS_COMP_CLIB(CVE_DOC, TIPO_COMPRA_LOCAL.ToUpper, Obser)
                    Else
                        Try
                            If IsNumeric(LtRFC.Tag) Then
                                CVE_OBS = LtRFC.Tag
                            Else
                                CVE_OBS = 0
                            End If
                        Catch ex As Exception
                            Bitacora("144. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try

                        CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, Obser)
                    End If
                End If

            Catch ex As Exception
            End Try

            Dim FECHA_PAG As DateTime = F3.Value

            SQL = "UPDATE GCGASTOS SET CVE_CLPV = @CVE_CLPV, STATUS = @STATUS, SU_REFER = @SU_REFER, 
                CAN_TOT = @CAN_TOT, IMP_TOT1 = @IMP_TOT1, IMP_TOT2 = @IMP_TOT2, IMP_TOT3 = @IMP_TOT3, IMP_TOT4 = @IMP_TOT4, DES_TOT = @DES_TOT, 
                DES_FIN = @DES_FIN, TOT_IND = @TOT_IND, OBS_COND = @OBS_COND, CVE_OBS = @CVE_OBS, NUM_ALMA = @NUM_ALMA, ACT_CXP = @ACT_CXP, 
                ACT_COI = @ACT_COI, ENLAZADO = @ENLAZADO, TIP_DOC_E = @TIP_DOC_E, NUM_MONED = @NUM_MONED, TIPCAMB = @TIPCAMB, NUM_PAGOS = @NUM_PAGOS, 
                SERIE = @SERIE, FOLIO = @FOLIO, CTLPOL = @CTLPOL, ESCFD = @ESCFD, CONTADO = @CONTADO, BLOQ = @BLOQ, DES_FIN_PORC = @DES_FIN_PORC, 
                DES_TOT_PORC = @DES_TOT_PORC, IMPORTE = @IMPORTE, TIP_DOC_ANT = @TIP_DOC_ANT, DOC_ANT = @DOC_ANT, TIP_DOC_SIG = @TIP_DOC_SIG, 
                DOC_SIG = @DOC_SIG, FORMAENVIO = @FORMAENVIO, CVE_DEPTO = @CVE_DEPTO
                WHERE CVE_DOC = @CVE_DOC 
                IF @@ROWCOUNT = 0 
                INSERT INTO GCGASTOS (TIP_DOC, CVE_DOC, CVE_CLPV, STATUS, SU_REFER, FECHA_DOC, FECHA_REC, 
                FECHA_PAG, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, TOT_IND, OBS_COND, CVE_OBS, NUM_ALMA, ACT_CXP, 
                ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, FECHAELAB, SERIE, FOLIO, CTLPOL, ESCFD, CONTADO, BLOQ, DES_FIN_PORC, 
                DES_TOT_PORC, IMPORTE, TIP_DOC_ANT, DOC_ANT, TIP_DOC_SIG, DOC_SIG, FORMAENVIO, CVE_DEPTO) VALUES (@TIP_DOC, @CVE_DOC, @CVE_CLPV, @STATUS, 
                @SU_REFER, @FECHA_DOC, @FECHA_DOC, @FECHA_PAG, @CAN_TOT, @IMP_TOT1, @IMP_TOT2, @IMP_TOT3, @IMP_TOT4, @DES_TOT, @DES_FIN, @TOT_IND,  
                @OBS_COND, @CVE_OBS, @NUM_ALMA, @ACT_CXP, @ACT_COI, @ENLAZADO, @TIP_DOC_E, @NUM_MONED, @TIPCAMB, @NUM_PAGOS, GETDATE(), @SERIE, 
                @FOLIO, @CTLPOL, @ESCFD, @CONTADO, @BLOQ, @DES_FIN_PORC, @DES_TOT_PORC, @IMPORTE, @TIP_DOC_ANT, @DOC_ANT, @TIP_DOC_SIG, @DOC_SIG, 
                @FORMAENVIO, @CVE_DEPTO)"
            Try

                For k = 1 To 5
                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = TIP_DOC
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@CVE_CLPV", SqlDbType.VarChar).Value = CVE_CLPV
                        cmd.Parameters.Add("@STATUS", SqlDbType.VarChar).Value = "E"
                        cmd.Parameters.Add("@SU_REFER", SqlDbType.VarChar).Value = SU_REFER
                        cmd.Parameters.Add("@FECHA_DOC", SqlDbType.Date).Value = F1.Text
                        cmd.Parameters.Add("@FECHA_PAG", SqlDbType.Date).Value = FECHA_PAG
                        cmd.Parameters.Add("@CAN_TOT", SqlDbType.Float).Value = Math.Round(CAN_TOT, 6)
                        cmd.Parameters.Add("@IMP_TOT1", SqlDbType.Float).Value = Math.Round(IMP_TOT1, 6)
                        cmd.Parameters.Add("@IMP_TOT2", SqlDbType.Float).Value = Math.Round(IMP_TOT2, 6)
                        cmd.Parameters.Add("@IMP_TOT3", SqlDbType.Float).Value = Math.Round(IMP_TOT3, 6)
                        cmd.Parameters.Add("@IMP_TOT4", SqlDbType.Float).Value = Math.Round(IMP_TOT4, 6)
                        cmd.Parameters.Add("@DES_TOT", SqlDbType.Float).Value = DES_TOT
                        cmd.Parameters.Add("@DES_FIN", SqlDbType.Float).Value = DES_FIN
                        cmd.Parameters.Add("@TOT_IND", SqlDbType.Float).Value = TOT_IND
                        cmd.Parameters.Add("@OBS_COND", SqlDbType.VarChar).Value = OBS_COND
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@NUM_ALMA", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@ACT_CXP", SqlDbType.VarChar).Value = ACT_CXP
                        cmd.Parameters.Add("@ACT_COI", SqlDbType.VarChar).Value = ACT_COI
                        cmd.Parameters.Add("@ENLAZADO", SqlDbType.VarChar).Value = ENLAZADO
                        cmd.Parameters.Add("@TIP_DOC_E", SqlDbType.VarChar).Value = TIP_DOC_E
                        cmd.Parameters.Add("@NUM_MONED", SqlDbType.Int).Value = NUM_MONED
                        cmd.Parameters.Add("@TIPCAMB", SqlDbType.Float).Value = TIPCAMB
                        cmd.Parameters.Add("@NUM_PAGOS", SqlDbType.Int).Value = 1
                        cmd.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = LETRA_GASTO
                        cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = FOLIO
                        cmd.Parameters.Add("@CTLPOL", SqlDbType.Int).Value = CTLPOL
                        cmd.Parameters.Add("@ESCFD", SqlDbType.VarChar).Value = ESCFD
                        cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                        cmd.Parameters.Add("@BLOQ", SqlDbType.VarChar).Value = BLOQ
                        cmd.Parameters.Add("@DES_FIN_PORC", SqlDbType.Float).Value = DES_FIN_PORC
                        cmd.Parameters.Add("@DES_TOT_PORC", SqlDbType.Float).Value = DES_TOT_PORC
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                        cmd.Parameters.Add("@TIP_DOC_ANT", SqlDbType.VarChar).Value = TIP_DOC_ANT
                        cmd.Parameters.Add("@DOC_ANT", SqlDbType.VarChar).Value = DOC_ANT
                        cmd.Parameters.Add("@TIP_DOC_SIG", SqlDbType.VarChar).Value = TIP_DOC_SIG
                        cmd.Parameters.Add("@DOC_SIG", SqlDbType.VarChar).Value = DOC_SIG
                        cmd.Parameters.Add("@FORMAENVIO", SqlDbType.VarChar).Value = FORMAENVIO
                        cmd.Parameters.Add("@CVE_DEPTO", SqlDbType.VarChar).Value = CVE_DEPTO
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                        Exit For
                    Catch sqlEx As SqlException
                        If sqlEx.Number = 2627 Then
                        End If
                        Bitacora("53. " & sqlEx.Message & vbNewLine & sqlEx.StackTrace)
                    Catch ex As Exception
                        Bitacora("147. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("147. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        Sigue = True
                        FOLIO_ASIGNADO = False
                        Do While Sigue

                            If LETRA_GASTO.Trim.Length = 0 Or LETRA_GASTO = "STAND." Then
                                CVE_DOC = Space(10) & Format(FOLIO_GASTO, "0000000000")
                            Else
                                CVE_DOC = LETRA_GASTO & FOLIO_GASTO
                            End If

                            If EXISTE_CVE_DOC_GASTO(TIPO_COMPRA_LOCAL, CVE_DOC) Then
                                FOLIO_GASTO += 1
                                FOLIO_ASIGNADO = True
                            Else
                                Sigue = False
                            End If
                        Loop
                        ULT_DOC = FOLIO_GASTO
                        FOLIO = ULT_DOC
                    Catch ex As Exception
                        Bitacora("61. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("61. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next

                Try

                    SQL = "INSERT INTO PAGA_M" & Empresa & " (CVE_PROV, REFER, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE,
                        FECHA_APLI, FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, TIPO_MOV, SIGNO, USUARIO, ENTREGADA,
                        FECHA_ENTREGA, STATUS) VALUES('" & CVE_CLPV & "','" & CVE_DOC & "','" & NUM_CPTO & "','" & NUM_CARGO & "','" &
                        CVE_OBS & "','" & TRefProv.Text & "','" & CVE_DOC & "','" & Math.Round(IMPORTE, 6) & "','" & FSQL(F1.Value) & "','" &
                        FSQL(F3.Value) & "','" & AFEC_COI & "','" & NUM_MONED & "','" & TCAMBIO & "','" & Math.Round(IMPORTE, 6) &
                        "',GETDATE(),'" & TIPO_MOV & "','" & SIGNO & "','" & Usuario2 & "','" & ENTREGADA &
                        "','" & FSQL(F1.Value) & "','A')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("156. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    MsgBox("156. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                SQL = "UPDATE PROV" & Empresa & " SET SALDO = COALESCE(SALDO,0) + " & IMPORTE & ",
                     ULT_COMPD = '" & CVE_DOC & "', ULT_COMPM = '" & IMPORTE & "', ULT_COMPF = '" & FSQL(F1.Value) & "'
                     WHERE CLAVE = '" & CVE_CLPV & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                'FIN CUENTAS X PAGAR
            Catch ex As Exception
                MsgBox("157. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("157. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            MsgBox("158. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("158. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            Me.Cursor = Cursors.Default
            Return
        End Try
        '==========================================================================================================================================
        '==========================================================================================================================================
        '==========================================================================================================================================
        '               EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS                  EMPIEZA PARTIDAS   
        '==========================================================================================================================================
        '==========================================================================================================================================
        '==========================================================================================================================================
        Try
            Dim k As Integer
            k = 0
            NUM_PAR = 1 : TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To Fg.Rows.Count - 1

                If Not Valida_Conexion() Then
                End If

                k += 1
                Application.DoEvents()
                Try
                    CVE_ART = Fg(i, 4)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                    If IsNothing(Fg(i, 2)) Then
                        CANT = 0
                    Else
                        CANT = Fg(i, 2)
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                End Try

                If CVE_ART.Length > 0 And CANT > 0 Then

                    Try
                        DESCR = Fg(i, 6)
                        DESCR = DESCR.Replace("'", "")
                        If DESCR.Length > 40 Then DESCR = DESCR.Substring(0, 40)
                    Catch ex As Exception
                    End Try

                    CVE_ESQIMPU = 1

                    Try
                        SQL = "SELECT * FROM GCCATGASTOS WHERE CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                            End If
                        End If
                        Reader.Close()

                    Catch ex As Exception
                        MsgBox("159. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("159. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    UNI_MED = Fg(i, 7)
                    COSTO = CDec(Fg(i, 13))
                    COSTO = Math.Round(CDec(COSTO), 6)

                    Try
                        cmd.CommandText = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                        Reader = cmd.ExecuteReader
                        If Reader.HasRows Then
                            If Reader.Read Then
                                IMPU1 = CDec(Reader("IMPUESTO1"))
                                IMPU2 = CDec(Reader("IMPUESTO2"))
                                IMPU3 = CDec(Reader("IMPUESTO3"))
                                IMPU4 = CDec(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            End If
                        End If
                        Reader.Close()

                    Catch ex As Exception
                        MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("160. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        cIeps = COSTO * IMPU1 / 100
                        If IMP2APLA = 2 Or IMP2APLA = 1 Then
                            cImpu2 = CDec((COSTO + cIeps) * IMPU2 / 100)
                        Else
                            cImpu2 = CDec(COSTO * IMPU2 / 100)
                        End If

                        If IMP3APLA = 2 Or IMP3APLA = 1 Then
                            cImpu3 = CDec((COSTO + cIeps + cImpu2) * IMPU3 / 100)
                        Else
                            cImpu3 = CDec(COSTO * IMPU3 / 100)
                        End If

                        If IMP4APLA = 1 Or IMP4APLA = 2 Then
                            cImpu = (COSTO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                        Else
                            cImpu = COSTO * IMPU4 / 100
                        End If

                        ImporteIeps += (COSTO * CANT * IMPU1 / 100)
                        ImporteImpu2 += (COSTO * CANT * IMPU2 / 100)
                        ImporteImpu3 += (COSTO * CANT * IMPU3 / 100)
                        ImporteIVA += (COSTO * CANT * IMPU4 / 100)

                        DESCU = DES_TOT_PORC
                        TOTIMP1 = (CANT * cIeps)
                        TOTIMP2 = (CANT * cImpu2)
                        TOTIMP3 = (CANT * cImpu3)
                        TOTIMP4 = (CANT * cImpu)
                        TOT_PARTIDA = COSTO * CANT
                        '62.93
                        COSTO_PROMEDIO = CALCULA_COSTO_PROM(CVE_ART, COSTO_PROM, COSTO, CANT, 1)
                        'COSTO_PROMEDIO = Math.Round(COSTO_PROMEDIO, 3, MidpointRounding.AwayFromZero)
                        CLAVE_CLPV = CVE_CLPV
                        UNI_VENTA = UNI_MED

                        PREC = 0 : Vend = "" : CANT_COST = 0 : CVE_OBS = 0 : REG_SERIE = 0 : E_LTPD = 0 : TIPO_PROD = "P" : FACTOR_CON = 1 : CTLPOL = 0
                        COSTEADO = "S" : COSTO_PROM_INI = COSTO : COSTO_PROM_FIN = COSTO : DESDE_INVE = "N" : MOV_ENLAZADO = 0
                    Catch ex As Exception
                        MsgBox("161. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("161. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    '***************************************************************************************
                    '***************************************************************************************
                    ' ***********************           EMPIEZA PARTIDAS     *******************************
                    '***************************************************************************************
                    '***************************************************************************************
                    NUM_ALM = 1
                    Try
                        Obser_par = Fg(i, 18)
                        Obser_par = RemoveCharacter(Obser_par)
                    Catch ex As Exception
                    End Try
                    Try
                        CVE_OBS = 0
                        If Not IsNothing(Obser_par) Then
                            If Obser_par.ToString.Trim.Length > 0 Then
                                Try
                                    If IsNumeric(Fg(i, 19)) Then
                                        CVE_OBS = Fg(i, 19)
                                    Else
                                        CVE_OBS = 0
                                    End If
                                Catch ex As Exception
                                    CVE_OBS = 0
                                    Bitacora("163. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                                End Try
                                CVE_OBS = INSERT_UPDATE_OBS(CVE_OBS, Obser_par)
                            End If
                        End If

                        If CompEdit Then
                            NUM_PAR = Fg(i, 16)
                        End If
                    Catch ex As Exception
                        Bitacora("164. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                    End Try

                    SQL = "UPDATE GCGASTOS_PART Set CVE_ART = @CVE_ART, CANT = @CANT, PXR = @PXR, PREC = @PREC, 
                        COST = @COST, IMPU1 = @IMPU1, IMPU2 = @IMPU2, IMPU3 = @IMPU3, IMPU4 = @IMPU4, IMP1APLA = @IMP1APLA, IMP2APLA = @IMP2APLA, 
                        IMP3APLA = @IMP3APLA, IMP4APLA = @IMP4APLA, TOTIMP1 = @TOTIMP1, TOTIMP2 = @TOTIMP2, TOTIMP3 = @TOTIMP3, TOTIMP4 = @TOTIMP4, 
                        DESCU = @DESCU, ACT_INV = @ACT_INV, TIP_CAM = @TIP_CAM, UNI_VENTA = @UNI_VENTA, TIPO_ELEM = @TIPO_ELEM, TIPO_PROD = @TIPO_PROD, 
                        CVE_OBS = @CVE_OBS, REG_SERIE = @REG_SERIE, E_LTPD = @E_LTPD, FACTCONV = @FACTCONV, COST_DEV = @COST_DEV, NUM_ALM = @NUM_ALM, 
                        MINDIRECTO = @MINDIRECTO, NUM_MOV = @NUM_MOV, TOT_PARTIDA = @TOT_PARTIDA, MAN_IEPS = @MAN_IEPS, APL_MAN_IMP = @APL_MAN_IMP, 
                        CUOTA_IEPS = @CUOTA_IEPS, APL_MAN_IEPS = @APL_MAN_IEPS, MTO_PORC = @MTO_PORC, MTO_CUOTA = @MTO_CUOTA, CVE_ESQ = @CVE_ESQ, 
                        DESCR_ART = @DESCR_ART 
                        WHERE CVE_DOC = @CVE_DOC And NUM_PAR = @NUM_PAR 
                        If @@ROWCOUNT = 0 
                        INSERT INTO GCGASTOS_PART (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXR, PREC, COST, IMPU1,
                        IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESCU, ACT_INV, TIP_CAM,
                        UNI_VENTA, TIPO_ELEM, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, FACTCONV, COST_DEV, NUM_ALM, MINDIRECTO, NUM_MOV, TOT_PARTIDA,
                        MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, APL_MAN_IEPS, MTO_PORC, MTO_CUOTA, CVE_ESQ, DESCR_ART) VALUES(@CVE_DOC, @NUM_PAR, @CVE_ART, 
                        @CANT, @PXR, @PREC, @COST, @IMPU1, @IMPU2, @IMPU3, @IMPU4, @IMP1APLA, @IMP2APLA, @IMP3APLA, @IMP4APLA, @TOTIMP1, @TOTIMP2, 
                        @TOTIMP3, @TOTIMP4, @DESCU, @ACT_INV, @TIP_CAM, @UNI_VENTA, @TIPO_ELEM, @TIPO_PROD, @CVE_OBS, @REG_SERIE, @E_LTPD, @FACTCONV, 
                        @COST_DEV, @NUM_ALM, @MINDIRECTO, 0, @TOT_PARTIDA, @MAN_IEPS, @APL_MAN_IMP, @CUOTA_IEPS, @APL_MAN_IEPS, @MTO_PORC, @MTO_CUOTA, 
                        @CVE_ESQ, @DESCR_ART)"
                    Try
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                        cmd.Parameters.Add("@NUM_PAR", SqlDbType.Int).Value = NUM_PAR
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(CVE_ART)
                        cmd.Parameters.Add("@CANT", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PXR", SqlDbType.Float).Value = CANT
                        cmd.Parameters.Add("@PREC", SqlDbType.Float).Value = Math.Round(PREC, 6)
                        cmd.Parameters.Add("@COST", SqlDbType.Float).Value = Math.Round(COSTO, 6)
                        cmd.Parameters.Add("@IMPU1", SqlDbType.Float).Value = IMPU1
                        cmd.Parameters.Add("@IMPU2", SqlDbType.Float).Value = IMPU2
                        cmd.Parameters.Add("@IMPU3", SqlDbType.Float).Value = IMPU3
                        cmd.Parameters.Add("@IMPU4", SqlDbType.Float).Value = IMPU4
                        cmd.Parameters.Add("@IMP1APLA", SqlDbType.SmallInt).Value = IMP1APLA
                        cmd.Parameters.Add("@IMP2APLA", SqlDbType.SmallInt).Value = IMP2APLA
                        cmd.Parameters.Add("@IMP3APLA", SqlDbType.SmallInt).Value = IMP3APLA
                        cmd.Parameters.Add("@IMP4APLA", SqlDbType.SmallInt).Value = IMP4APLA
                        cmd.Parameters.Add("@TOTIMP1", SqlDbType.Float).Value = Math.Round(TOTIMP1, 6)
                        cmd.Parameters.Add("@TOTIMP2", SqlDbType.Float).Value = Math.Round(TOTIMP2, 6)
                        cmd.Parameters.Add("@TOTIMP3", SqlDbType.Float).Value = Math.Round(TOTIMP3, 6)
                        cmd.Parameters.Add("@TOTIMP4", SqlDbType.Float).Value = Math.Round(TOTIMP4, 6)
                        cmd.Parameters.Add("@DESCU", SqlDbType.Float).Value = DESCU
                        cmd.Parameters.Add("@ACT_INV", SqlDbType.VarChar).Value = ACT_INV
                        cmd.Parameters.Add("@TIP_CAM", SqlDbType.Float).Value = TIP_CAM
                        cmd.Parameters.Add("@UNI_VENTA", SqlDbType.VarChar).Value = UNI_MED
                        cmd.Parameters.Add("@TIPO_ELEM", SqlDbType.VarChar).Value = TIPO_ELEM
                        cmd.Parameters.Add("@TIPO_PROD", SqlDbType.VarChar).Value = "S"
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@REG_SERIE", SqlDbType.Int).Value = REG_SERIE
                        cmd.Parameters.Add("@E_LTPD", SqlDbType.Int).Value = E_LTPD
                        cmd.Parameters.Add("@FACTCONV", SqlDbType.Float).Value = FACTCONV
                        cmd.Parameters.Add("@COST_DEV", SqlDbType.Float).Value = 0
                        cmd.Parameters.Add("@NUM_ALM", SqlDbType.Int).Value = NUM_ALM
                        cmd.Parameters.Add("@MINDIRECTO", SqlDbType.Float).Value = MINDIRECTO
                        cmd.Parameters.Add("@NUM_MOV", SqlDbType.Int).Value = NUM_MOV
                        cmd.Parameters.Add("@TOT_PARTIDA", SqlDbType.Float).Value = Math.Round(TOT_PARTIDA, 6)
                        cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = MAN_IEPS
                        cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = APL_MAN_IMP
                        cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = CUOTA_IEPS
                        cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = APL_MAN_IEPS
                        cmd.Parameters.Add("@MTO_PORC", SqlDbType.Float).Value = MTO_PORC
                        cmd.Parameters.Add("@MTO_CUOTA", SqlDbType.Float).Value = MTO_CUOTA
                        cmd.Parameters.Add("@CVE_ESQ", SqlDbType.Int).Value = CVE_ESQIMPU
                        cmd.Parameters.Add("@DESCR_ART", SqlDbType.VarChar).Value = ""
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("170. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    ' ***********************   PARTIDAS *******************************

                    NUM_PAR += 1
                End If
            Next
            If Not Valida_Conexion() Then
            End If

            If Not CompEdit Then
                Try
                    If LETRA_GASTO = "" Or LETRA_GASTO = "STAND." Then
                        SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE LOWER(TIP_DOC) = '" & TIPO_COMPRA_LOCAL & "' AND SERIE = 'STAND.'"
                    Else
                        SQL = "UPDATE FOLIOSC" & Empresa & " SET ULT_DOC = " & FOLIO & " WHERE LOWER(TIP_DOC) = '" & TIPO_COMPRA_LOCAL.ToLower & "' AND SERIE = '" & LETRA_GASTO & "'"
                    End If
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("320. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            End If

            Me.Cursor = Cursors.Default
            Continua = False

            GRABA_BITA(TPROV.Text, CVE_DOC, IMPORTE, TIPO_COMPRA_LOCAL, " Nuevo gasto " & SU_REFER)

            Try
                'GRABANDO XML
                Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String

                RUTA_XML = OBTENER_RUTA_XML()
                If RUTA_XML.Trim.Length = 0 Then
                    RUTA_XML = Application.StartupPath
                End If
                ARCHIVO = LtCVE_DOC.Tag.ToString
                FILE_XML = Path.GetFileName(ARCHIVO)

                If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                    RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                    UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                    SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                        WHERE CVE_DOC = '" & CVE_DOC & "' AND TIPO_DOC = 'G' 
                        IF @@ROWCOUNT = 0 
                        INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) 
                        VALUES(
                        ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1),'G','" & CVE_DOC & "','GASTOS','" &
                        UUID_XML & "','" & FILE_XML & "',NEWID())"

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    If RUTA_XML.Trim.Length = 0 Then
                                        RUTA_XML = Application.StartupPath
                                    End If
                                    Dim newPath = ARCHIVO
                                    FileCopy(newPath, RUTA_XML & "\" & FILE_XML)
                                Catch ex As Exception
                                    Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                Else
                    MsgBox("Por favor seleccione el XML")
                End If
            Catch ex As Exception
                Bitacora("365. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("365. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            ImprimirGasto(CVE_DOC)

            LIMPIAR()

        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub PAGA_DET(FCVE_DOC As String, FIMPORTE As Decimal, FDOCTO As String)
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_PROV As String, REFER As String, ID_MOV As Integer, NUM_CPTO As Integer, NUM_CARGO As Integer, CVE_OBS As Long, NO_FACTURA As String
        Dim DOCTO As String, IMPORTE As Decimal, AFEC_COI As String, NUM_MONED As Integer, TCAMBIO As Decimal, IMPMON_EXT As Decimal
        Dim CTLPOL As Integer, CVE_FOLIO As String, TIPO_MOV As String, SIGNO As Integer, CVE_AUT As Integer, Usuario2 As Integer
        Dim REF_SIST As String, NO_PARTIDA As Integer = 1, CADENA_NO_PAR As String
        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        Try
            CVE_PROV = TPROV.Text

            NUM_CPTO = 1
            CADENA_NO_PAR = NO_PARTIDA
            ID_MOV = 1
            REFER = FCVE_DOC
            DOCTO = FDOCTO

            NO_FACTURA = TRefProv.Text
            IMPMON_EXT = IMPORTE
            IMPORTE = FIMPORTE
            NUM_CARGO = 1 : CVE_OBS = 0 : AFEC_COI = "" : NUM_MONED = 1 : TCAMBIO = 1
            CTLPOL = 0 : CVE_FOLIO = "" : TIPO_MOV = "A" : SIGNO = -1 : CVE_AUT = 0 : Usuario2 = 0 : REF_SIST = ""

            SQL = "INSERT INTO PAGA_DET" & Empresa & " (CVE_PROV, REFER, ID_MOV, NUM_CPTO, NUM_CARGO, CVE_OBS, NO_FACTURA, DOCTO, IMPORTE, " &
                  "FECHA_APLI, FECHA_VENC, AFEC_COI, NUM_MONED, TCAMBIO, IMPMON_EXT, FECHAELAB, CTLPOL, CVE_FOLIO, TIPO_MOV, SIGNO, " &
                  "CVE_AUT, USUARIO, REF_SIST, NO_PARTIDA) VALUES('" & CVE_PROV & "','" & REFER & "','" & ID_MOV & "','" & NUM_CPTO & "','" &
                  NUM_CARGO & "','" & CVE_OBS & "','" & NO_FACTURA & "','" & DOCTO & "','" & Math.Round(IMPORTE, 6) &
                  "',CONVERT(varchar, GETDATE(), 112),CONVERT(varchar, GETDATE(), 112),'" & AFEC_COI & "','" & NUM_MONED & "','" &
                  TCAMBIO & "','" & Math.Round(IMPORTE, 6) & "',GETDATE(),'" & CTLPOL & "','" & CVE_FOLIO & "','" & TIPO_MOV & "','" &
                  SIGNO & "','" & CVE_AUT & "','" & Usuario2 & "','" & REF_SIST & "'," & CADENA_NO_PAR & ")"

            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If

        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub Fg_OwnerDrawCell(sender As Object, e As OwnerDrawCellEventArgs) Handles Fg.OwnerDrawCell
        Try
            'Dim sStyleName As String
            'sStyleName = "RowStyle"
            'Dim cs As C1.Win.C1FlexGrid.CellStyle = Fg.Styles.Add(sStyleName)
            '-- Set Italics On or Off
            'cs.Font = New Font(ChrW(23655) & ChrW(23765), 10, FontStyle.Regular, GraphicsUnit.Point, 134)
            'Dim rg As C1.Win.C1FlexGrid.CellRange = Fg.GetCellRange(1, 1, 8, Fg.Cols.Count - 1)

            'rg.Style = Fg.Styles(sStyleName)
            'e.Handled = True
        Catch ex As Exception
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Paint(sender As Object, e As PaintEventArgs) Handles Fg.Paint
        Try
            For Each hosted As HostedControl In ButtonList
                hosted.UpdatePosition()
            Next
        Catch ex As Exception
        End Try

    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Dim col_ As Integer = Fg.Col

        Try
            If TPROV.Text.Trim.Length = 0 Then
                'tPROV.Focus()
                'Return
            End If
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 1, 2, 3, 4, 8, 13
                        If Fg.Col = 2 Then
                            Try
                                If IsNothing(Fg(Fg.Row, 2)) Then
                                    Fg(Fg.Row, 2) = "1"
                                Else
                                    If Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                                        Fg(Fg.Row, 2) = "1"
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                        Fg.StartEditing()
                    Case Else
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Dim col_ As Integer = e.Col
        Try
            If ENTRA Then
                ENTRA = False
                Select Case e.Col
                    Case 1, 2, 3, 4, 8, 13
                    Case Else
                        e.Cancel = True
                End Select
                ENTRA = True
            End If
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Dim col_ As Integer = e.Col
        Try
            If e.KeyCode = Keys.F3 Then
                BarGrabar_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = Keys.F2 Then
                BtnSelArt_Click(Nothing, Nothing)
                Return
            End If
            'If ENTRA_TXT Then
            If (e.KeyCode = 13 Or e.KeyCode = 9) And ENTRA Then
                ENTRA = False
                Select Case e.Col
                    Case 2 'cantidad
                    Case 33 'ALMACEN
                        ENTRA = False
                        c_ = 4
                        'tBotonMagico_GotFocus(Nothing, Nothing)
                        Fg.Col = 4
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    Case 4 'ARTICULO
                        If ENTRA Then
                            Fg.Col = 8
                            Fg.StartEditing()
                            'ENTRA_TXT = True
                            ENTRA = True
                            Return
                        End If
                    Case 88 'DESC
                        ENTRA = False
                        Fg.Col = 12
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    Case 133 'COSTO
                        If OBSER_X_PARTIDA = 1 Then
                            Var4 = Fg(Fg.Row, 20)
                            Var5 = IIf(CompEdit, "EDIT", "NUEVO")
                            frmObserDocumento.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                Fg(Fg.Row, 18) = Var4
                            End If
                        End If
                        Fg.Row = Fg.Row + 1
                        Fg.Col = 1
                        Fg.StartEditing()

                        Return
                End Select
                ENTRA = True
            End If
            'End If

        Catch ex As Exception
            Bitacora("445. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("317. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Dim col_ As Integer = e.Col

        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 2 'CANTIDAD
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            Try
                                If T_DOC_ENL.Trim.Length > 0 Then
                                    If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 25)) Then
                                        If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 25)) Then
                                            If CDec(Fg.Editor.Text) > Fg(Fg.Row, 25) Then
                                                ENTRA = True
                                                e.Cancel = True
                                                Fg(Fg.Row, 2) = Fg(Fg.Row, 25)
                                                txtN.Value = Fg(Fg.Row, 25)

                                                MsgBox("La cantidad no puede ser mayor a la cantidad orginal")
                                                Return
                                            End If
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("450. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                                    If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                                        Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("450. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            ENTRA = True
                            Return
                        End If
                    Case 44 'PRUDUCTO
                        'Fg.Col = 8
                        'Fg.StartEditing()
                        ENTRA = True
                        c_ = 13
                        TBotonMagico_GotFocus(Nothing, Nothing)
                        Return
                    Case 8
                        If Fg.Row > 0 Then
                            If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                                If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                                    If IsNumeric(Fg.Editor.Text) Then
                                        Fg(Fg.Row, 14) = ROW_CALC(Val(Fg(Fg.Row, 2)), Val(Fg(Fg.Row, 13)), Val(Fg.Editor.Text))
                                    End If
                                End If
                            End If
                        End If
                    Case 13
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            If IsNumeric(Fg.Editor.Text) Then
                                If Not IsNothing(Fg(Fg.Row, 2)) Then
                                    If IsNumeric(Fg(Fg.Row, 2)) Then
                                        Dim Desc1 As Decimal
                                        Try
                                            If IsNothing(Fg(Fg.Row, 8)) Then
                                                Desc1 = 0
                                            Else
                                                If Not IsNumeric(Fg(Fg.Row, 8)) Then
                                                    Desc1 = CDec(Fg(Fg.Row, 8))
                                                End If
                                            End If
                                        Catch ex As Exception
                                            Bitacora("455. " & ex.Message & vbNewLine & ex.StackTrace)
                                            MsgBox("455. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                        Fg(Fg.Row, 14) = ROW_CALC(CDec(Fg(Fg.Row, 2)), Fg.Editor.Text, Desc1)
                                    End If
                                End If
                            End If
                        End If
                End Select
            End If
            ENTRA = True
        Catch ex As Exception
            Bitacora("460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Function ROW_CALC(FCant As Decimal, FPrecio As Decimal, fDesc As Decimal)
        Try
            Dim CALCULO As Decimal

            CALCULO = (FCant * FPrecio) - (FCant * FPrecio * fDesc / 100)

            Return CALCULO
        Catch ex As Exception
            Bitacora("470. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("470. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function

    Private Sub BtnSelArt_Click(sender As Object, e As EventArgs) Handles btnSelArt.Click
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

            If MULTIALMACEN = 1 Then
                G_ALM = 1
                Try
                    If Fg(Fg.Row, 3).ToString.Trim.Length > 1 Then
                        G_ALM = Fg(Fg.Row, 3).ToString.Substring(0, 2)
                    End If
                Catch ex As Exception
                    Bitacora("475. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            End If

            Fg.FinishEditing()

            Var15 = "Busqueda"
            Var2 = "Gastos"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Dim CANT As Integer, IDRENOVADO As String = ""
                Try
                    CANT = Fg(Fg.Row, 2)
                    PassData3 = ""
                    PassData4 = ""
                Catch ex As Exception
                End Try
                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                'Var6 = Fg(Fg.Row, 3).ToString 'ALTERNA
                'Var7 = Fg(Fg.Row, 4).ToString 'EXIST
                'Var8 = Fg(Fg.Row, 5).ToString 'TIPO ELE

                Fg(Fg.Row, 4) = Var4
                Fg(Fg.Row, 6) = Var5
                LLENAR_GRID_ARTICULO(Var4)

                If TIPO_COMPRA_LOCAL = "o" Then
                    Fg.Col = 13
                    ENTRA = True
                Else
                    Fg.Col = 13
                    ENTRA = True
                End If

                Fg.StartEditing()
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
    End Sub
    Private Sub txtN_Validated(sender As Object, e As EventArgs) Handles txtN.Validated
        If Fg.Col = 2 Then
            Try
                If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                    If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                        Fg(Fg.Row, 14) = txtN.Value * Fg(Fg.Row, 13)
                    End If
                End If
            Catch ex As Exception
                Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Return
        End If

    End Sub
    Private Sub Txt_Validating(sender As Object, e As CancelEventArgs) Handles txt.Validating
        Dim CVE_ART As String

        If Fg.Col = 4 Then
            Try
                Dim CANT As Integer, IDRENOVADO As String = ""
                Try
                    CANT = Fg(Fg.Row, 2)
                    PassData3 = ""
                    PassData4 = ""
                Catch ex As Exception
                End Try

                If txt.Text.Trim.Length > 0 Then
                    CVE_ART = txt.Text

                    CVE_ART = RemoveCharacter(CVE_ART)
                    CVE_ART = CVE_ART.Replace(vbTab, "")
                    CVE_ART = CVE_ART.Replace(vbCr, "")
                    CVE_ART = CVE_ART.Replace(vbCrLf, "")
                    If CVE_ART.Trim.Length > 0 And Fg(Fg.Row, 20).ToString.Trim.Length = 0 Then

                        LLENAR_GRID_ARTICULO(CVE_ART)
                        If TIPO_COMPRA_LOCAL = "o" Then
                            Fg.Col = 13
                            ENTRA = True
                        Else
                            Fg.Col = 13
                            ENTRA = True
                        End If
                    Else
                        Fg.Col = 13
                        ENTRA = True
                    End If
                End If
            Catch ex As Exception
                Bitacora("940. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("940. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            End Try
            ENTRA = True
        End If
    End Sub

    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Decimal

            If MULTIALMACEN = 1 Then
                G_ALM = 1
                Try
                    If Fg(Fg.Row, 3).ToString.Trim.Length > 1 Then
                        G_ALM = Fg(Fg.Row, 3).ToString.Substring(0, 2)
                    End If
                Catch ex As Exception
                    Bitacora("475. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            End If

            ULT_COSTO = 0

            If G_ALM = 0 Then G_ALM = 1
            SQL = "SELECT DESCR, ISNULL(COSTO,0) AS COST, IMPUESTO1, IMPUESTO2, IMPUESTO3, 
                IMPUESTO4, I.CVE_ESQIMPU
                FROM GCCATGASTOS I
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                WHERE CVE_ART = '" & fCVE_ART & "'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                ULT_COSTO = dr("COST")
                Fg(Fg.Row, 6) = dr("DESCR")
                Fg(Fg.Row, 7) = "" 'dr("UNI_MED")
                Fg(Fg.Row, 9) = dr("IMPUESTO1") 'IEPS
                Fg(Fg.Row, 10) = dr("IMPUESTO2") 'IMPU2
                Fg(Fg.Row, 11) = dr("IMPUESTO3") 'IMPU4
                Fg(Fg.Row, 12) = dr("IMPUESTO4") 'IVA
                If Fg(Fg.Row, 15) <> fCVE_ART Then
                    Fg(Fg.Row, 13) = ULT_COSTO 'COSTO
                End If
                If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                    If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                        Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                    End If
                End If
                Fg(Fg.Row, 15) = fCVE_ART
                Fg(Fg.Row, 24) = "" 'dr("TIPOELE")
            Else
                MsgBox("Articulo inexistente")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("530. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("530. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            DialogOK = ""
            Try
                FrmSelItem2.ShowDialog()
            Catch ex As Exception
                Var5 = "99"
            End Try
            If Var5 = "99" Then
                DialogOK = "Show"
                frmSelItem.Show()
            Else
                If Var4.Trim.Length > 0 Then
                    TPROV.Text = Var4
                    LLENA_CAMPOS(Var4)

                    Var2 = "" : Var4 = "" : Var5 = ""
                End If
            End If
            Var5 = ""

        Catch ex As Exception
            Bitacora("485. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("485. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles btnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tEsquema.Value = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tDesc.Focus()
            End If
        Catch ex As Exception
            Bitacora("490. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("490. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub LLENA_CAMPOS(ByVal fCLAVE As String)
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ExistPorv As Boolean = False, DIASCRED As Integer = 0


            If fCLAVE.Trim.Length = 0 Then
                Return
            End If
            If IsNumeric(fCLAVE.Trim) Then
                fCLAVE = Space(10 - fCLAVE.Trim.Length) & fCLAVE.Trim
                TPROV.Text = fCLAVE
            End If

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM PROV" & Empresa & " WHERE CLAVE  = '" & fCLAVE & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                LtNombre.Text = dr("NOMBRE").ToString
                LtCalle.Text = dr("CALLE").ToString
                LtColonia.Text = dr("COLONIA").ToString
                LtNumInt.Text = dr("NUMINT").ToString
                LtNumExt.Text = dr("NUMEXT").ToString
                LtCP.Text = dr("CODIGO").ToString
                LtRFC.Text = dr("RFC").ToString
                LtPoblacion.Text = dr("MUNICIPIO").ToString
                LtEstado.Text = dr("ESTADO").ToString
                DIASCRED = dr.ReadNullAsEmptyInteger("DIASCRED")

                ExistPorv = True
            Else
                MsgBox("Proveedor inexistente")
            End If
            dr.Close()

            Dim dt As DateTime = Date.Today
            dt = dt.AddDays(DIASCRED)

            F3.Value = dt
        Catch ex As Exception
            Bitacora("495. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("495. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROV.KeyDown

        If e.KeyCode = Keys.F2 Then
            BtnProv_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Then
            If TPROV.Text.Trim.Length = 0 Then
                'tPROV.Select()
                Return
            End If

            LLENA_CAMPOS(TPROV.Text)
            TRefProv.Focus()
        End If
    End Sub
    Private Sub TPROV_Validated(sender As Object, e As EventArgs) Handles TPROV.Validated
        Try
            If TPROV.Text.Trim.Length = 0 Then
                'tPROV.Select()
                Return
            End If
            LLENA_CAMPOS(TPROV.Text)
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEsquema_KeyDown(sender As Object, e As KeyEventArgs) Handles tEsquema.KeyDown
        Try

            If e.KeyCode = Keys.F2 Then
                BtnEsquema_Click(Nothing, Nothing)
                Return
            End If
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                tDesc.Focus()
            End If
        Catch ex As Exception
            Bitacora("510. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("510. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEsquema_Validated(sender As Object, e As EventArgs) Handles tEsquema.Validated
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If tEsquema.Value <> 0 Then
                cmd.Connection = cnSAE
                SQL = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & tEsquema.Value
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If Not dr.Read Then
                    MsgBox("Esquema inexistente")
                End If
                dr.Close()
            End If

        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObserDoc_Click(sender As Object, e As EventArgs) Handles BarObserDoc.Click
        Try
            Var4 = Obser
            Var5 = IIf(CompEdit, "EDIT", "NUEVO")

            frmObserDocumento.ShowDialog()
            Obser = Var4
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSerie_Click(sender As Object, e As EventArgs) Handles BarSerie.Click
        Try
            TIPO_COMPRA = "G"

            frmSeriesCompras.ShowDialog()
            If LETRA_GASTO.Trim.Length = 0 Or LETRA_GASTO = "STAND." Then
                LtCVE_DOC.Text = "          " & Format(FOLIO_GASTO, "0000000000")
            Else
                LtCVE_DOC.Text = LETRA_GASTO & Format(FOLIO_GASTO, "0000000000")
            End If
        Catch ex As Exception
            Bitacora("550. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("550. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnAltaProv_Click(sender As Object, e As EventArgs)
        frmProvAE.ShowDialog()
    End Sub

    Private Sub BtnAltaArticulo_Click(sender As Object, e As EventArgs)
        frmInvenRAE.ShowDialog()
    End Sub
    Private Sub Fg_StartEdit(sender As Object, e As RowColEventArgs) Handles Fg.StartEdit
        Dim col_ As Integer = e.Col
        If ENTRA Then
            Try
                If e.Row > 0 Then
                    If e.Col = 2 Then
                        If IsNothing(Fg(e.Row, 2)) Then
                            Fg(e.Row, 2) = 1
                        Else
                            If Fg(e.Row, 2) = 0 Then
                                Fg(e.Row, 2) = 1
                            End If
                        End If
                    End If
                    If e.Col = 8 Then
                        If Not IsNothing(Fg(e.Row, 8)) Then
                            If Fg(e.Row, 8).ToString.Length = 0 Then
                                Fg(e.Row, 8) = "0"
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("560. " & ex.Message & vbNewLine & ex.StackTrace)
                'MsgBox("412. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Else
            If e.Col = 3 Then
                If Not CompEdit Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub
    Sub LIMPIAR()
        Try
            If T_DOC_ENL.Trim.Length = 0 Then
                CboTipoCompra.SelectedIndex = 0
            End If

            TRefProv.Text = ""
            LtDocEnlazado.Text = ""
            TPROV.Text = ""
            LtNombre.Text = ""
            LtCalle.Text = ""
            LtColonia.Text = ""
            LtNumInt.Text = ""
            LtNumExt.Text = ""
            LtCP.Text = ""
            LtRFC.Text = ""
            LtPoblacion.Text = ""
            LtEstado.Text = ""
            Obser = ""
            LtRFC.Tag = "0" 'CVE_OBS_DOC

            idLlantasNuevas = Guid.NewGuid().ToString

            CboDepto.SelectedIndex = -1

            TIPO_COMPRA_LOCAL = "g"
            FOLIO_GASTO = SIGUIENTE_FOLIO_COMPRA(TIPO_COMPRA_LOCAL, LETRA_GASTO)

            If LETRA_GASTO.Trim.Length = 0 Or LETRA_GASTO = "STAND." Then
                LtCVE_DOC.Text = "          " & Format(FOLIO_GASTO, "0000000000")
            Else
                LtCVE_DOC.Text = LETRA_GASTO & Format(FOLIO_GASTO, "0000000000")
            End If

            F1.Value = Date.Today
            F2.Value = Date.Today

            ENTRA = False
            TPROV.Select()

            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 1) = ""
                Fg(k, 2) = ""
                Fg(k, 3) = ""
                Fg(k, 4) = ""
                Fg(k, 5) = ""
                Fg(k, 6) = ""
                Fg(k, 7) = ""
                Fg(k, 8) = ""
                Fg(k, 9) = ""
                Fg(k, 10) = ""
                Fg(k, 11) = ""
                Fg(k, 12) = ""
                Fg(k, 13) = ""
                Fg(k, 14) = ""
                Fg(k, 15) = ""
                Fg(k, 16) = "0"
                Fg(k, 17) = ""
                Fg(k, 18) = ""
                Fg(k, 19) = "0"
                Fg(k, 20) = " "
                Fg(k, 21) = " "
                Fg(k, 22) = " "
                Fg(k, 23) = " "
                Fg(k, 24) = " "
            Next
            Fg.Row = 1
            Fg.Col = 1

            ENTRA = True
        Catch ex As Exception
            Bitacora("570. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboTipoCompra_GotFocus(sender As Object, e As EventArgs) Handles CboTipoCompra.GotFocus
        Try
            CboTipoCompra.BorderStyle = BorderStyle.Fixed3D
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CboTipoCompra_LostFocus(sender As Object, e As EventArgs) Handles CboTipoCompra.LostFocus
        Try
            CboTipoCompra.BorderStyle = BorderStyle.FixedSingle
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CboTipoCompra_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboTipoCompra.PreviewKeyDown
        Dim CVE_DOC As String
        Try
            idLlantasNuevas = Guid.NewGuid().ToString

            Var10 = "" : T_DOC_ENL = "" : DOC_ENL = ""
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                If CboTipoCompra.Text <> "Directa" Then
                    Try
                        Select Case CboTipoCompra.Text
                            Case "Orden de compra"
                                Var10 = "O"
                                Var9 = ""
                                T_DOC_ENL = ""
                                DOC_ENL = ""
                                frmEnlazarComprasNuevo.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    T_DOC_ENL = "o"
                                    DOC_ENL = Var10
                                End If
                                'Var4 = Fg(Fg.Row, 1) 'CVE_DOC
                                'Var5 = Fg(Fg.Row, 2) 'CLAVE
                                'Var6 = Fg(Fg.Row, 3) 'NOMBRE
                                'Var7 = Fg(Fg.Row, 4) 'FECHA
                                'Var8 = Fg(Fg.Row, 5) 'IMPORTE
                                'Var9 = Fg(Fg.Row, 6) 'doc sig
                                'Var10 = Fg(Fg.Row, 7) 'tip doc sig
                            Case "Requisición"
                                Var10 = "Q"
                                Var9 = ""
                                T_DOC_ENL = ""
                                frmEnlazarComprasNuevo.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    T_DOC_ENL = "q"
                                    DOC_ENL = Var4
                                End If
                        End Select

                        Try
                            If T_DOC_ENL.Trim.Length > 0 Then
                                If aDOCS.Length > 0 Then

                                    ENTRA = False

                                    LIMPIAR()
                                    LIMPIA_FG()
                                    kk = 0
                                    For k = 0 To aDOCS.Length - 1
                                        CVE_DOC = aDOCS(k)
                                        DOC_ENL = CVE_DOC

                                        If CVE_DOC.Trim.Length > 0 Then
                                            BUSCAR_GASTO(T_DOC_ENL, CVE_DOC, "")
                                        End If
                                    Next
                                    Fg.Row = kk + 1
                                    Fg.Col = 2
                                    ENTRA = True
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Catch ex As Exception
                        Bitacora("590. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("590. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If
            LtDocEnlazado.Text = "Documento enlazado " & DOC_ENL
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCAR_GASTO(fTIPOC As String, fCVE_DOC As String, fEDIT As String)
        If Not Valida_Conexion() Then
            Return
        End If

        Dim COSTO As Decimal, NUM_ALM As Integer, DESCR_ALM As String = "", IEPS As Decimal, IMPU As Decimal, cIEPS As Decimal, cIMPU As Decimal
        Dim DESCP As Decimal, DESCP2 As Decimal, PrecioVenta As Decimal, Sigue As Boolean, NO_PAR As Boolean = False, CANT As Decimal
        Dim DOCU As String, CVE_DEPTO As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        cmd.Connection = cnSAE
        ENTRA = False

        Try
            SQL = "SELECT P.CVE_ART, CANT, PXR, I.DESCR, P.DESCU, PREC, IMPU1, IMPU2, IMPU3, IMPU4, IMP4APLICA, IMP1APLICA, COST, UNI_VENTA, 
                NUM_PAR, ISNULL(PXR,0) AS P_X_R, P.CVE_DOC, 
                P.NUM_ALM, FECHA_DOC, ISNULL(F.CVE_CLPV,'') AS PROV, C.NOMBRE, C.RFC, C.CALLE, C.COLONIA, C.NUMINT, C.NUMEXT, C.CODIGO, 
                C.MUNICIPIO, C.ESTADO, SU_REFER, ISNULL(F.CVE_OBS,0) AS CVE_OBS_DOC, ISNULL(O.STR_OBS,'') AS OBS_DOC, 
                ISNULL(P.CVE_OBS,0) AS CVE_OBS_PAR, ISNULL(OP.STR_OBS,'') AS OBS_PAR, X.ARCHIVO_XML, F.DOC_ANT, F.DOC_SIG, 
                C.DIASCRED, ISNULL(F.CVE_DEPTO,'') AS CVE_DEP, ISNULL(D.DESCR,'') AS DESCR_DEPTO
                FROM GCGASTOS_PART P
                LEFT JOIN GCGASTOS F ON F.CVE_DOC = P.CVE_DOC 
                LEFT JOIN OBS_DOCC" & Empresa & " O ON O.CVE_OBS = F.CVE_OBS 
                LEFT JOIN OBS_DOCC" & Empresa & " OP ON OP.CVE_OBS = P.CVE_OBS 
                LEFT JOIN PROV" & Empresa & " C ON C.CLAVE = F.CVE_CLPV 
                LEFT JOIN GCCATGASTOS I On replace(replace(I.CVE_ART,CHAR(13),''),CHAR(10),'') =replace(replace(P.CVE_ART ,CHAR(13),''),CHAR(10),'')
                LEFT JOIN IMPU" & Empresa & " U On U.CVE_ESQIMPU = I.CVE_ESQIMPU 
                LEFT JOIN GCCOMPRAS X ON X.CVE_DOC = P.CVE_DOC 
                LEFT JOIN GCDEPTOS D ON D.CVE_DEPTO = F.CVE_DEPTO
                WHERE P.CVE_DOC = '" & fCVE_DOC & "'"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Sigue = True
            Obser = ""
            ENTRA = False

            Dim RUTA_XML As String

            RUTA_XML = OBTENER_RUTA_XML()
            If RUTA_XML.Trim.Length = 0 Then
                RUTA_XML = Application.StartupPath
            End If

            Do While dr.Read

                If Sigue Then
                    TPROV.Text = dr("PROV")
                    LtNombre.Text = dr("NOMBRE").ToString
                    LtCalle.Text = dr("CALLE").ToString
                    LtColonia.Text = dr("COLONIA").ToString
                    LtNumInt.Text = dr("NUMINT").ToString
                    LtNumExt.Text = dr("NUMEXT").ToString
                    LtCP.Text = dr("CODIGO").ToString
                    LtRFC.Text = dr("RFC").ToString
                    LtPoblacion.Text = dr("MUNICIPIO").ToString
                    LtEstado.Text = dr("ESTADO").ToString
                    TRefProv.Text = dr("SU_REFER")
                    LtCVE_DOC.Tag = RUTA_XML & "\" & dr.ReadNullAsEmptyString("ARCHIVO_XML")

                    Try
                        Dim dt As DateTime = Date.Today, DIASCRED As Integer
                        DIASCRED = dr.ReadNullAsEmptyInteger("DIASCRED")
                        dt = dt.AddDays(DIASCRED)
                        F3.Value = dt

                        CVE_DEPTO = dr("CVE_DEP").ToString

                        LtRFC.Tag = dr("CVE_OBS_DOC")
                        Obser = dr.ReadNullAsEmptyString("OBS_DOC")

                    Catch ex As Exception
                        Bitacora("620 " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Sigue = False
                End If

                NUM_ALM = 1
                Try
                    For z = 0 To CboDepto.Items.Count - 1
                        If CboDepto.Items(z).ToString.Substring(0, 2).Replace("0", "").Trim = CVE_DEPTO Then
                            CboDepto.SelectedIndex = z
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                COSTO = Math.Round(dr("COST"), 6)
                DESCP = COSTO * dr("DESCU") / 100
                IEPS = dr("IMPU1")
                cIEPS = (COSTO - DESCP - DESCP2) * IEPS / 100
                IMPU = dr("IMPU4")
                cIMPU = (COSTO - DESCP - DESCP2 + cIEPS) * IMPU / 100
                PrecioVenta = COSTO - DESCP - DESCP2
                kk += 1
                Fg(kk, 1) = ""

                If fEDIT = "edit" Then
                    CANT = dr.ReadNullAsEmptyDecimal("CANT")
                Else
                    CANT = dr("P_X_R")
                End If

                Fg(kk, 0) = kk 'dr.ReadNullAsEmptyInteger("NUM_PAR")
                Fg(kk, 2) = CANT

                Fg(kk, 3) = DESCR_ALM
                Fg(kk, 4) = dr.ReadNullAsEmptyString("CVE_ART")
                Fg(kk, 6) = dr("DESCR")
                Fg(kk, 7) = dr.ReadNullAsEmptyString("UNI_VENTA")
                Fg(kk, 8) = dr.ReadNullAsEmptyDecimal("DESCU")
                Fg(kk, 9) = dr.ReadNullAsEmptyDecimal("IMPU1")
                Fg(kk, 10) = dr.ReadNullAsEmptyDecimal("IMPU2")
                Fg(kk, 11) = dr.ReadNullAsEmptyDecimal("IMPU3")
                Fg(kk, 12) = dr.ReadNullAsEmptyDecimal("IMPU4")
                Fg(kk, 13) = COSTO
                Fg(kk, 14) = CANT * COSTO
                Fg(kk, 15) = dr.ReadNullAsEmptyString("CVE_ART")
                Fg(kk, 16) = dr.ReadNullAsEmptyInteger("NUM_PAR")

                DOCU = dr("DOC_ANT")

                Fg(kk, 20) = DOCU
                Fg(kk, 23) = ""
                Fg(kk, 24) = "S"
                Fg(kk, 25) = CANT

                NO_PAR = True
                Fg.Refresh()
                Fg.Col = 1
                Fg(kk, 2) = CANT
                Fg.Col = 1

                Try
                    Fg(kk, 18) = dr("OBS_PAR")
                    Fg(kk, 19) = dr("CVE_OBS_PAR")
                Catch ex As Exception
                    Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Loop

            Try
                Fg.Focus()
                Fg.Row = kk + 1
                Fg.Col = 2
            Catch ex As Exception
            End Try

            If Not NO_PAR Then
                Bitacora("PROBLEMA DETECTADO EN BUSCAR_COMPRA NO ENCONTRO LA COMPRA FrmGastos ")
                'Me.Close()
            End If
            ENTRA = True

            If fTIPOC.ToUpper = "C" Or fTIPOC.ToUpper = "R" Then
                Fg(0, 20) = "Doc. anterior"
            End If
        Catch ex As Exception
            Bitacora("670. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("670. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIA_FG()
        Try
            For k = 1 To Fg.Rows.Count - 1
                Fg(k, 1) = ""
                Fg(k, 2) = ""
                Fg(k, 3) = ""
                Fg(k, 4) = ""
                Fg(k, 5) = ""
                Fg(k, 6) = ""
                Fg(k, 7) = ""
                Fg(k, 8) = ""
                Fg(k, 9) = ""
                Fg(k, 10) = ""
                Fg(k, 11) = ""
                Fg(k, 12) = ""
                Fg(k, 13) = ""
                Fg(k, 14) = ""
                Fg(k, 15) = ""
                Fg(k, 16) = "0"
                Fg(k, 17) = ""
                Fg(k, 18) = ""
                Fg(k, 19) = "0"
                Fg(k, 20) = " "
                Fg(k, 21) = " "
                Fg(k, 22) = " "
                Fg(k, 23) = " "
                Fg(k, 24) = " "
            Next
            Fg.Row = 1
            Fg.Col = 1

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles tDesc.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                tDesFin.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TDesFin_KeyDown(sender As Object, e As KeyEventArgs) Handles tDesFin.KeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then

            End If
        Catch ex As Exception
            Bitacora("690. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("690. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEntregarEn_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Fg.Focus()
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Length = 0 Then
                        Fg.Row = k
                        Fg.Col = 2
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("700. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("700. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ImprimirGasto(FCVE_DOC As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String = ""
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportGastos" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportGastos.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = FCVE_DOC
            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click

        If COMPRAS_NEW Then
            MsgBox("Para poder re-imprimir por favor primero grabe el documento")
            Return
        End If
        Try
            If TPROV.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un cliente")
                Return
            End If

            Try
                Dim j As Integer
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 2)) Then
                        If Fg(k, 2).ToString.Trim.Length > 0 Then
                            j += 1
                        End If
                    End If
                Next
                If j = 0 Then
                    MsgBox("No existen partidas verifique por favor")
                    Return
                End If
            Catch ex As Exception
            End Try

            ImprimirGasto(LtCVE_DOC.Text)
        Catch ex As Exception
            Bitacora("710. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTotales_Click(sender As Object, e As EventArgs) Handles BarTotales.Click

        Var7 = "TOTALES"
        CALCULAR_IMPORTES()
        FrmGastosTotales.ShowDialog()

    End Sub
    Sub CALCULAR_IMPORTES()

        Dim cmd As New SqlCommand
        Dim Reader As SqlDataReader
        Dim IMPORTE As Decimal
        Dim DESCUENTO1 As Decimal
        Dim ImporteConDes As Decimal
        Dim DESC1 As Decimal

        Dim CVE_ESQIMPU As Integer = 1
        Dim CAN_TOT As Decimal
        Dim DES_TOT As Decimal
        Dim COSTO As Decimal
        Dim COSTO_NETO As Decimal

        Dim cIeps As Decimal
        Dim cImpu As Decimal
        Dim IMP1APLA As Integer, IMP2APLA As Integer, IMP3APLA As Integer, IMP4APLA As Integer
        Dim TOTIMP1 As Decimal
        Dim TOTIMP2 As Decimal
        Dim TOTIMP3 As Decimal
        Dim TOTIMP4 As Decimal
        Dim IMPU1 As Decimal
        Dim IMPU2 As Decimal
        Dim IMPU3 As Decimal
        Dim IMPU4 As Decimal
        Dim cImpu2 As Decimal
        Dim cImpu3 As Decimal
        Dim ImporteIeps As Decimal
        Dim ImporteImpu2 As Decimal
        Dim ImporteImpu3 As Decimal
        Dim ImporteIVA As Decimal
        Dim CANT As Decimal
        Dim CVE_ART As String

        cmd.Connection = cnSAE

        Try
            DES_TOT = 0
            TOTIMP1 = 0 : TOTIMP2 = 0 : TOTIMP3 = 0 : TOTIMP4 = 0
            For i As Integer = 1 To Fg.Rows.Count - 1

                Try
                    CVE_ART = Fg(i, 4)
                    CVE_ART = CVE_ART.Replace("'", "")
                    CVE_ART = RemoveCharacter(CVE_ART)
                Catch ex As Exception
                    CVE_ART = ""
                End Try

                Try
                    Try
                        If IsNumeric(Fg(i, 2)) Then
                            CANT = Fg(i, 2)
                        Else
                            CANT = 0
                        End If
                    Catch ex As Exception
                        CANT = 0
                    End Try

                    If CVE_ART.Length > 0 And CANT > 0 Then

                        Try
                            SQL = "SELECT * FROM GCCATGASTOS WHERE CVE_ART = '" & CVE_ART & "'"
                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.HasRows Then
                                If Reader.Read Then
                                    CVE_ESQIMPU = Reader("CVE_ESQIMPU")
                                Else
                                    Bitacora("1. PROBLEMA DETECTADO EN CALCULAR IMPORTES NO SE ENCONTRO EL ESQUEMA IMPUESTO FrmGastos ")
                                End If
                            End If
                            Reader.Close()

                        Catch ex As Exception
                            MsgBox("720. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("720. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            SQL = "SELECT * FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = " & CVE_ESQIMPU
                            cmd.CommandText = SQL
                            Reader = cmd.ExecuteReader
                            If Reader.Read Then
                                IMPU1 = CDec(Reader("IMPUESTO1"))
                                IMPU2 = CDec(Reader("IMPUESTO2"))
                                IMPU3 = CDec(Reader("IMPUESTO3"))
                                IMPU4 = CDec(Reader("IMPUESTO4"))
                                IMP1APLA = CInt(Reader("IMP1APLICA"))
                                IMP2APLA = CInt(Reader("IMP2APLICA"))
                                IMP3APLA = CInt(Reader("IMP3APLICA"))
                                IMP4APLA = CInt(Reader("IMP4APLICA"))
                            Else
                                Bitacora("PROBLEMA DETECTADO EN CALCULAR IMPORTES NO ENCONTRO EL IMPUESTO FrmGastos ")
                            End If
                            Reader.Close()
                        Catch ex As Exception
                            Bitacora("730. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            MsgBox("730. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            DESC1 = CDec(Fg(i, 8))
                            COSTO = CDec(Fg(i, 13))

                            COSTO = Math.Round(CDec(COSTO), 6)
                            COSTO_NETO = COSTO - (COSTO * DESC1 / 100)

                            DESCUENTO1 = (CANT * COSTO * DESC1 / 100)
                            ImporteConDes = (CANT * COSTO) - DESCUENTO1
                            ImporteConDes = Math.Round(CDec(ImporteConDes), 6)

                            DES_TOT += DESCUENTO1

                            cIeps = COSTO_NETO * IMPU1 / 100
                            If IMP2APLA = 2 Or IMP2APLA = 1 Then
                                cImpu2 = CDec((COSTO_NETO + cIeps) * IMPU2 / 100)
                            Else
                                cImpu2 = CDec(COSTO_NETO * IMPU2 / 100)
                            End If

                            If IMP3APLA = 2 Or IMP3APLA = 1 Then
                                cImpu3 = CDec((COSTO_NETO + cIeps + cImpu2) * IMPU3 / 100)
                            Else
                                cImpu3 = CDec(COSTO_NETO * IMPU3 / 100)
                            End If

                            If IMP4APLA = 1 Or IMP4APLA = 2 Then
                                cImpu = (COSTO_NETO + cIeps + cImpu2 + cImpu3) * IMPU4 / 100
                            Else
                                cImpu = COSTO_NETO * IMPU4 / 100
                            End If

                            ImporteIeps += (COSTO_NETO * CANT * IMPU1 / 100)
                            ImporteImpu2 += (COSTO_NETO * CANT * IMPU2 / 100)
                            ImporteImpu3 += (COSTO_NETO * CANT * IMPU3 / 100)
                            ImporteIVA += (COSTO_NETO * CANT * IMPU4 / 100)


                            TOTIMP1 += (CANT * cIeps)
                            TOTIMP2 += (CANT * cImpu2)
                            TOTIMP3 += (CANT * cImpu3)
                            TOTIMP4 += (CANT * cImpu)

                            IMPORTE += (CANT * (COSTO_NETO + cIeps + cImpu2 + cImpu3 + cImpu))
                            CAN_TOT += (CANT * COSTO)

                        Catch ex As Exception
                            MsgBox("740. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("740. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    MsgBox("750. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("750. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                End Try
            Next
            If TOTIMP2 < 0 Then
                FrmGastosTotales.Lt1.Text = "RET."
            End If
            If TOTIMP3 < 0 Then
                FrmGastosTotales.Lt2.Text = "RET."
            End If
            FrmGastosTotales.LtSubtotal.Text = Format(CAN_TOT, "###,##0.00")
            FrmGastosTotales.LtDesc.Text = Format(DES_TOT, "###,##0.00")
            FrmGastosTotales.LtIeps.Text = Format(TOTIMP1, "###,##0.00")
            FrmGastosTotales.LtImpu2.Text = Format(TOTIMP2, "###,##0.00")
            FrmGastosTotales.LtImpu3.Text = Format(TOTIMP3, "###,##0.00")
            FrmGastosTotales.LtIVA.Text = Format(TOTIMP4, "###,##0.00")
            FrmGastosTotales.LtTotal.Text = Format(CAN_TOT - DES_TOT + TOTIMP1 + TOTIMP2 + TOTIMP3 + TOTIMP4, "###,##0.00")
        Catch ex As Exception
            Bitacora("760. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea aliminar la partida seleccionada?", vbYesNo) = vbNo Then
                    Return
                End If

                Fg.Col = 1
                Fg(Fg.Row, 3) = ""
                Fg.RemoveItem(Fg.Row)
            Else
                MsgBox("Por favor seleccione una partida a eliminar")
            End If
        Catch ex As Exception
            Bitacora("760. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObserPar_Click(sender As Object, e As EventArgs) Handles BarObserPar.Click
        Try
            If Fg.Row > 0 Then
                Var4 = ""
                Try
                    If IsNothing(Fg(Fg.Row, 18)) Then
                        Var4 = ""
                    Else
                        Var4 = Fg(Fg.Row, 18)
                    End If
                Catch ex As Exception
                End Try
                Var5 = IIf(CompEdit, "EDIT", "NUEVO")
                frmObserDocumento.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    Fg(Fg.Row, 18) = Var4
                End If
            End If
        Catch ex As Exception
            Bitacora("770. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("409. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarRutaXML_Click(sender As Object, e As EventArgs) Handles BarRutaXML.Click
        Try
            Var25 = LtCVE_DOC.Tag
            frmAdjuntarXML.ShowDialog()
            LtCVE_DOC.Tag = Var25
        Catch ex As Exception
            Bitacora("780. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmGastos_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If DialogOK = "Show" Then
            If FORM_IS_OPEN("frmSelItem") Then
                frmSelItem.Show()
                Return
            End If
            Try
                frmSelItem.TopMost = False
            Catch ex As Exception
            End Try

            TPROV.Text = Var4
            LLENA_CAMPOS(Var4)

            Var2 = "" : Var4 = "" : Var5 = ""
        End If
        DialogOK = ""
    End Sub

    Private Sub TBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles tBotonMagico.GotFocus
        Try
            'Fg.ROW=  .Select(Fg.Row, c_)
            Fg.Col = c_
            Fg.StartEditing(Fg.Row, c_)
        Catch ex As Exception
            Bitacora("790. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txt.KeyDown
        Try
            If e.KeyCode = 13 And ENTRA Then
                ENTRA = False
                Select Case Fg.Col
                    Case 3
                        Fg.Col = 4
                        Fg.StartEditing()
                    Case 44
                        Fg.FinishEditing()
                        Fg.Col = 13
                        c_ = 3
                        TBotonMagico_GotFocus(Nothing, Nothing)
                        ENTRA = True
                        Return
                    Case 13
                        If OBSER_X_PARTIDA = 1 Then
                            Var4 = Fg(Fg.Row, 18)
                            Var5 = IIf(CompEdit, "EDIT", "NUEVO")
                            frmObserDocumento.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                Fg(Fg.Row, 18) = Var4
                            End If
                        End If
                        Fg.Row = Fg.Row + 1
                        Fg.Col = 1
                        Fg.StartEditing()
                        Return
                End Select

                ENTRA = True
            End If
        Catch ex As Exception
            Bitacora("800. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Txt_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles txt.PreviewKeyDown
        If e.KeyCode = 9 Then
            If Fg.Row > 0 Then
                If Fg.Col = 2 Then
                    Try
                        If Not IsNothing(Fg(Fg.Row, 2)) And Not IsNothing(Fg(Fg.Row, 13)) Then
                            If IsNumeric(Fg(Fg.Row, 2)) And IsNumeric(Fg(Fg.Row, 13)) Then
                                Fg(Fg.Row, 14) = Fg(Fg.Row, 2) * Fg(Fg.Row, 13)
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("810. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("810. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Return
                End If
                If Fg.Col = 13 Then
                    If OBSER_X_PARTIDA = 1 Then
                        Var4 = Fg(Fg.Row, 18)
                        Var5 = IIf(CompEdit, "EDIT", "NUEVO")
                        frmObserDocumento.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            Fg(Fg.Row, 18) = Var4
                        End If
                    End If
                    Fg.Row = Fg.Row + 1
                    Fg.Col = 2
                    Fg.StartEditing()
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub CboAlmacen_DropDownClosed(sender As Object, e As DropDownClosedEventArgs)
        Try
            If TPROV.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la clave del proveedor")
                TPROV.Select()
                TPROV.Focus()
                Return
            End If

            Fg.Select()
            Fg.Focus()
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Length = 0 Then
                    Fg.Row = k
                    Fg.Col = 2
                    Fg.StartEditing()
                    Exit For
                End If
            Next

        Catch ex As Exception
            Bitacora("820. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String = ""
        Dim strSerie As String
        Dim strFolio As String
        Dim strFechaEmision As String
        Dim strSello As String
        Dim strNoCertificado As String
        Dim strSubtotal As String
        Dim strTotal As String
        Dim strMoneda As String
        Dim strCondiciones As String
        Dim strFormaPago As String
        Dim strMetodoPago As String
        Dim strLugarExpedicion As String

        Dim strReceptorRfc As String

        Dim strEmisorRfc As String
        Dim strEmisorNombre As String

        Dim strUsoCFDI As String

        Dim strRegimen As String
        Dim strDescuento As String
        Dim strNumCtaPago As String
        Dim strVersion As String
        Dim NoCertificadoSAT As String
        Dim UUID As String = ""
        Dim UUIDR As String

        Dim FechaTimbrado As String
        Dim strVersionTimbre As String
        Dim NumOperacion As String
        Dim Monto As String
        Dim FormaDePagoP As String
        Dim FechaPago As String
        Dim Folio As String
        Dim Serie As String
        Dim ImpSaldoInsoluto As String
        Dim ImpPagado As String
        Dim ImpSaldoAnt As String
        Dim NumParcialidad As String
        Dim MetodoDePagoDR As String
        Dim concepto As XmlNodeList
        Dim Elemento As XmlNode
        Dim subnodo As XmlElement
        Dim IdDocumento As String

        Dim XML As String
        Dim xDoc As XmlDocument
        Dim xNodo As XmlNodeList
        Dim xAtt As XmlElement
        Dim Comprobante As XmlNode

        xDoc = New XmlDocument


        Try
            XML = fFILE_XML

            If Not File.Exists(fFILE_XML) Then
                MsgBox("Archivo o ruta inexistente " & vbNewLine & XML)
                Return ""
            End If
            If XML.Trim.Length > 0 Then
                Dim books = XDocument.Load(XML)

                xDoc.Load(XML)

                Comprobante = xDoc.Item("cfdi:Comprobante")
                xNodo = xDoc.GetElementsByTagName("cfdi:Comprobante")
                If xNodo.Count > 0 Then
                    For Each xAtt In xNodo
                        Application.DoEvents()
                        Try
                            strVersion = VarXml(xAtt, "Version")
                        Catch ex As Exception
                            strVersion = ""
                        End Try
                        Try
                            strTipoComprobante = VarXml(xAtt, "TipoDeComprobante")
                            strSerie = VarXml(xAtt, "Serie")
                            strFolio = VarXml(xAtt, "Folio")
                            strFechaEmision = VarXml(xAtt, "Fecha")
                            strSello = VarXml(xAtt, "sello")
                            strNoCertificado = VarXml(xAtt, "NoCertificado")
                            strSubtotal = VarXml(xAtt, "SubTotal")
                            strTotal = VarXml(xAtt, "Total")
                            strMoneda = VarXml(xAtt, "Moneda")
                            strCondiciones = VarXml(xAtt, "CondicionesDePago")
                            strFormaPago = VarXml(xAtt, "FormaPago")
                            strMetodoPago = VarXml(xAtt, "MetodoPago")
                            strNumCtaPago = VarXml(xAtt, "NumCtaPago").Trim
                            strLugarExpedicion = VarXml(xAtt, "LugarExpedicion")
                            strDescuento = VarXml(xAtt, "Descuento")

                            strRegimen = VarXml(xAtt, "NoCertificadoSAT")
                        Catch ex As Exception
                            Bitacora("830. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("830. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
                        End Try
                    Next '   EMISOR   EMISOR   EMISOR   EMISOR
                    Try
                        UUID = ""
                        concepto = xDoc.GetElementsByTagName("cfdi:Complemento")
                        For Each Elemento In concepto
                            For Each subnodo In Elemento
                                UUID = Trim(subnodo.GetAttribute("UUID"))
                            Next
                        Next
                    Catch ex As Exception
                        Bitacora("840. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    UUIDR = ""
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:CfdiRelacionados")
                        If xNodo.Count > 0 Then
                            If xNodo.Count > 0 Then
                                For Each xAtt In xNodo.Item(0)
                                    Application.DoEvents()
                                    Me.Refresh()
                                    If xAtt.LocalName Like "CfdiRelacionado" Then
                                        UUIDR = VarXml(xAtt, "UUID")
                                    End If
                                Next
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("850. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("860. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Receptor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strEmisorRfc = VarXml(xAtt, "Rfc")
                                strEmisorNombre = VarXml(xAtt, "Nombre")
                                strUsoCFDI = VarXml(xAtt, "UsoCFDI")
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("870. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Complemento")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo.Item(0)
                                Application.DoEvents()
                                Me.Refresh()
                                If xAtt.LocalName Like "TimbreFiscalDigital" Then
                                    NoCertificadoSAT = VarXml(xAtt, "NoCertificadoSAT")
                                    UUID = VarXml(xAtt, "UUID")
                                    FechaTimbrado = VarXml(xAtt, "FechaTimbrado")
                                    strVersionTimbre = VarXml(xAtt, "Version")
                                End If
                                If xAtt.LocalName Like "Pagos" Then
                                    NoCertificadoSAT = VarXml(xAtt, "Version")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("880. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If strTipoComprobante = "P" Then
                        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
                        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""
                        Try
                            concepto = xDoc.GetElementsByTagName("pago10:Pagos")
                            For Each Elemento In concepto
                                For Each subnodo In Elemento
                                    NumOperacion = Trim(subnodo.GetAttribute("NumOperacion"))
                                    Monto = Trim(subnodo.GetAttribute("Monto"))
                                    FormaDePagoP = Trim(subnodo.GetAttribute("FormaDePagoP"))
                                    FechaPago = Trim(subnodo.GetAttribute("FechaPago"))
                                Next
                            Next
                            If Val(Monto) > 0 Then strTotal = Val(Monto)
                            If FechaPago.Trim.Length > 0 Then FechaTimbrado = FechaPago
                            If FormaDePagoP.Trim.Length > 0 Then strFormaPago = FormaDePagoP
                        Catch ex As Exception
                            Bitacora("890. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        Try
                            MetodoDePagoDR = ""
                            concepto = xDoc.GetElementsByTagName("pago10:Pago")
                            For Each Elemento In concepto
                                'pago10:DoctoRelacionado
                                For Each subnodo In Elemento
                                    Folio = Trim(subnodo.GetAttribute("Folio"))
                                    Serie = Trim(subnodo.GetAttribute("Serie"))
                                    ImpSaldoInsoluto = Trim(subnodo.GetAttribute("ImpSaldoInsoluto"))
                                    ImpPagado = Trim(subnodo.GetAttribute("ImpPagado"))
                                    ImpSaldoAnt = Trim(subnodo.GetAttribute("ImpSaldoAnt"))
                                    NumParcialidad = Trim(subnodo.GetAttribute("NumParcialidad"))
                                    MetodoDePagoDR = Trim(subnodo.GetAttribute("MetodoDePagoDR"))
                                    IdDocumento = Trim(subnodo.GetAttribute("IdDocumento"))
                                Next
                            Next
                            If FormaDePagoP.Trim.Length > 0 Then
                                strMetodoPago = MetodoDePagoDR
                            End If
                        Catch ex As Exception
                            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                End If 'If xNodo.Count > 0 Then

                Try
                    ').Value = strSerie & strFolio
                    ').Value = BUSCA_CLIENTE(strEmisorRfc, strEmisorNombre)
                    ').Value = strEmisorNombre
                    ').Value = strEmisorRfc
                    ').Value = strUsoCFDI
                    ').Value = strTipoComprobante
                    ').Value = strVersionTimbre
                    ').Value = UUID
                    ').Value = NoCertificadoSAT
                    ').Value = FechaTimbrado
                    ').Value = strFormaPago
                    ').Value = strMetodoPago
                    ').Value = strTotal
                    ').Value = strSubtotal
                    ').Value = strSerie
                    ').Value = strFolio
                    ').Value = UUIDR
                    ').Value = FormaDePagoP
                    ').Value = Serie & Folio
                    ').Value = IdDocumento
                Catch ex As Exception
                    Bitacora("910. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If

            Return UUID

        Catch ex As Exception
            Bitacora("920. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("920. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function

    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        Try
            If e.KeyCode = 13 Or e.KeyCode = 9 Then
                Select Case Fg.Col
                    Case = 4
                        ENTRA_TXT = True
                End Select
            End If
        Catch ex As Exception
            Bitacora("950. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TRefProv_KeyDown(sender As Object, e As KeyEventArgs) Handles TRefProv.KeyDown
        Try
            If e.KeyCode = 13 Then

                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                CboDepto.Focus()

            End If
        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub TRefProv_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TRefProv.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then

                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                'CboDepto.Focus()

            End If
        Catch ex As Exception
            Bitacora("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboAlmacen_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = 13 Then
                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                Fg.Select()
                Fg.Focus()
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Length = 0 Then
                            Fg.Row = k
                            Fg.Col = 2
                            Try
                                If IsNothing(Fg(k, 2)) Then
                                    Fg(k, 2) = "1"
                                    txtN.Value = 1
                                Else
                                    If Fg(k, 2).ToString.Trim.Length = 0 Then
                                        Fg(k, 2) = "1"
                                        txtN.Value = 1
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Fg.StartEditing()
                            txtN.Focus()
                            Exit For
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboAlmacen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        Try
            If e.KeyCode = 9 Then

                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                Fg.Select()
                Fg.Focus()
                For k = 1 To Fg.Rows.Count - 1
                    If Not IsNothing(Fg(k, 1)) Then
                        If Fg(k, 1).ToString.Length = 0 Then
                            Fg.Row = k
                            Fg.Col = 2
                            Try
                                If IsNothing(Fg(k, 2)) Then
                                    Fg(k, 2) = "1"
                                    txtN.Value = 1
                                Else
                                    If Fg(k, 2).ToString.Trim.Length = 0 Then
                                        Fg(k, 2) = "1"
                                        txtN.Value = 1
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Fg.StartEditing()
                            txtN.Focus()
                            Exit For
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Bitacora("970. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F2_KeyDown(sender As Object, e As KeyEventArgs) Handles F2.KeyDown
        If e.KeyCode = 13 Then
            Fg.Select()
            Fg.Focus()
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Length = 0 Then
                    Fg.Row = k
                    Fg.Col = 2
                    Fg.StartEditing()
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub F2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles F2.PreviewKeyDown
        If e.KeyCode = 9 Then
            Fg.Select()
            Fg.Focus()
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Length = 0 Then
                    Fg.Row = k
                    Fg.Col = 2
                    Fg.StartEditing()
                    Exit For
                End If
            Next
        End If
    End Sub
    Private Sub BarKardex_Click(sender As Object, e As EventArgs)
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 4)

                If Var4.ToLower.Length = 0 Then
                    MsgBox("Por favor seleccione una partida donde exista la clave del artículo")
                    Return
                End If
                Var5 = ""
                Try
                    Var5 = Fg(Fg.Row, 6)
                Catch ex As Exception
                End Try
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub F1_GotFocus(sender As Object, e As EventArgs) Handles F1.GotFocus
        F1.BackColor = Color.Yellow
    End Sub
    Private Sub F3_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles F3.DropDownClosed
        Try
            If F3.Value < Date.Today Then
                MsgBox("La fecha de vencimiento no puede ser menor a la fecha actual")
                F3.Value = Date.Today
            End If
        Catch ex As Exception
            Bitacora("980. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub F3_GotFocus(sender As Object, e As EventArgs) Handles F3.GotFocus
        F3.BackColor = Color.Yellow
    End Sub

    Private Sub F3_LostFocus(sender As Object, e As EventArgs) Handles F3.LostFocus
        F3.BackColor = Color.FromArgb(233, 241, 250)
    End Sub

    Private Sub BarGrabarXML_Click(sender As Object, e As EventArgs) Handles BarGrabarXML.Click
        Try
            'GRABANDO XML
            Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String, UUID_XML As String

            If LtCVE_DOC.Tag.ToString.Length > 0 Then
                RUTA_XML = OBTENER_RUTA_XML()
                If RUTA_XML.Trim.Length = 0 Then
                    RUTA_XML = Application.StartupPath
                End If
                ARCHIVO = LtCVE_DOC.Tag.ToString
                FILE_XML = Path.GetFileName(ARCHIVO)

                If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                    RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                    UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                    SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                        WHERE CVE_DOC = '" & LtCVE_DOC.Text & "' AND TIPO_DOC = 'G' 
                        IF @@ROWCOUNT = 0 
                        INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) 
                        VALUES(
                        ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1),'G','" & LtCVE_DOC.Text & "','GASTOS','" &
                        UUID_XML & "','" & FILE_XML & "',NEWID())"
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    MsgBox("El archivo XML se grabo correctamente")
                                    If RUTA_XML.Trim.Length = 0 Then
                                        RUTA_XML = Application.StartupPath
                                    End If
                                    Dim newPath = ARCHIVO
                                    FileCopy(newPath, RUTA_XML & "\" & FILE_XML)

                                Catch ex As Exception
                                    Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                Else
                    MsgBox("Por favor seleccione el XML")
                End If
            Else
                MsgBox("Por favor seleccione el XML")
            End If

        Catch ex As Exception
            Bitacora("365. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("365. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboDepto_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboDepto.PreviewKeyDown
        Try
            If e.KeyCode = 9 Then

                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                Fg.Focus()
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Length = 0 Then
                        Fg.Row = k
                        Fg.Col = 2
                        Exit For
                    End If
                Next
                txtN.Focus()
            End If
        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboDepto_KeyDown(sender As Object, e As KeyEventArgs) Handles CboDepto.KeyDown
        Try
            If e.KeyCode = 13 Then

                If TPROV.Text.Trim.Length = 0 Then
                    MsgBox("Por favor capture la clave del proveedor")
                    TPROV.Focus()
                    Return
                End If

                Fg.Focus()
                For k = 1 To Fg.Rows.Count - 1
                    If Fg(k, 1).ToString.Length = 0 Then
                        Fg.Row = k
                        Fg.Col = 2
                        Exit For
                    End If
                Next
                txtN.Focus()
            End If
        Catch ex As Exception
            Bitacora("960. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("960. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboDepto_GotFocus(sender As Object, e As EventArgs) Handles CboDepto.GotFocus
        CboDepto.BackColor = Color.Cyan
    End Sub
    Private Sub CboDepto_LostFocus(sender As Object, e As EventArgs) Handles CboDepto.LostFocus
        CboDepto.BackColor = Color.FromArgb(233, 241, 250)
    End Sub

    Private Sub BarAltaProv_Click(sender As Object, e As EventArgs) Handles BarAltaProv.Click
        DialogOK = "Show"
        Var1 = "Nuevo"
        frmProvAE.ShowDialog()
    End Sub

    Private Sub BarAltaArticulo_Click(sender As Object, e As EventArgs) Handles BarAltaArticulo.Click
        Try
            Var1 = "Nuevo"
            FrmCatGastosAE.ShowDialog()
        Catch ex As Exception
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick

    End Sub

    Private Sub BarGrabar_CheckedChanged(sender As Object, e As EventArgs) Handles BarGrabar.CheckedChanged

    End Sub
End Class
