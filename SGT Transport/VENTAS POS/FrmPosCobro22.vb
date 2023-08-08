Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports System.Security.Cryptography

Public Class FrmPosCobro22
    Inherits System.Windows.Forms.Form

    Private FormIsLoaded As Boolean

    Private MONTOVENTA As Decimal
    Private CAMBIO_DINERO As Decimal = 0
    Private TCAMBIO As Decimal
    Private Cliente_pos As String

    Private OCULTAR_CRE_ENG As Integer
    Private OCULTAR_CREDITO As Integer
    Private NOVALIDAR_LIM_CRED As Integer
    Private HABILITAR_DESC As Integer
    Private PER_VEND_ABA_MIN As Integer
    Private PER_VEND_ABA_COST As Integer
    Private ACTIVAR_POLITICAS As Integer
    Private ACTIVAR_GAD As Integer
    Private ART_CON_IMP_INCLU As Integer
    Private VENDER_SIN_EXIST As Integer
    Private BLOQEAR_LISTA_PREC As Integer
    Private UTILIZAR_LECTOR_HUELLA As Integer
    Private ALTA_CTE_POS As Integer
    Private ALTA_PROD_POS As Integer
    Private CLIE_MOSTR As String
    Private SalirOK As Boolean = True
    Private LISTAPRECPRED As Integer
    Private ENTRA As Boolean = True
    Public Sub New(ByVal Parameter1 As Decimal, ByVal Param_Cliente As String)

        InitializeComponent()
        MONTOVENTA = Parameter1
        Cliente_pos = Param_Cliente

        FormIsLoaded = True

        Debug.Print("New " & FormIsLoaded & " ENTRA  " & ENTRA)
    End Sub
    Private Sub FrmPosCobro22_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Debug.Print("Load " & FORM_LOAD_KEY)

        Try
            Me.CenterToScreen()

            TEFECTIVO.Value = 0
            TTARJ_CREDITO.Value = 0
            TTARJ_DEBITO.Value = 0
            TTRANS.Value = 0
            TVALES.Value = 0
            TOBS.Value = ""
            TOBS.Text = ""

            LtTotal.Text = Format(MONTOVENTA, "###,###,##0.00")

            BtnGrabar.Enabled = False

            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TCAMBIO,0) AS TC FROM MONED" & Empresa & " WHERE NUM_MONED = 2"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        BtnDolar.Text = "Dolar ($" & dr("TC") & ")"
                        TCAMBIO = dr("TC")

                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(ALMACEN, 0) AS C_ALM, OCULTAR_CRE_ENG, OCULTAR_CREDITO, NOVALIDAR_LIM_CRED, HABILITAR_DESC, 
                PER_VEND_ABA_MIN, PER_VEND_ABA_COST, ACTIVAR_POLITICAS, ACTIVAR_GAD, ART_CON_IMP_INCLU, VENDER_SIN_EXIST, 
                BLOQEAR_LISTA_PREC, UTILIZAR_LECTOR_HUELLA, ALTA_CTE_POS, ALTA_PROD_POS, CLIE_MOSTR, LISTAPRECPRED
                FROM GCPARAMVENTAS"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    'NUEVAS OPCIONES POS DIC 20022
                    If dr.Read Then
                        OCULTAR_CRE_ENG = dr.ReadNullAsEmptyInteger("OCULTAR_CRE_ENG")
                        OCULTAR_CREDITO = dr.ReadNullAsEmptyInteger("OCULTAR_CREDITO")
                        NOVALIDAR_LIM_CRED = dr.ReadNullAsEmptyInteger("NOVALIDAR_LIM_CRED")
                        HABILITAR_DESC = dr.ReadNullAsEmptyInteger("HABILITAR_DESC")
                        PER_VEND_ABA_MIN = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_MIN")
                        PER_VEND_ABA_COST = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_COST")
                        ACTIVAR_POLITICAS = dr.ReadNullAsEmptyInteger("ACTIVAR_POLITICAS")
                        ACTIVAR_GAD = dr.ReadNullAsEmptyInteger("ACTIVAR_GAD")
                        ART_CON_IMP_INCLU = dr.ReadNullAsEmptyInteger("ART_CON_IMP_INCLU")
                        VENDER_SIN_EXIST = dr.ReadNullAsEmptyInteger("VENDER_SIN_EXIST")
                        BLOQEAR_LISTA_PREC = dr.ReadNullAsEmptyInteger("BLOQEAR_LISTA_PREC")
                        UTILIZAR_LECTOR_HUELLA = dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA")
                        ALTA_CTE_POS = dr.ReadNullAsEmptyInteger("ALTA_CTE_POS")
                        ALTA_PROD_POS = dr.ReadNullAsEmptyInteger("ALTA_PROD_POS")
                        CLIE_MOSTR = dr.ReadNullAsEmptyString("CLIE_MOSTR")

                        LISTAPRECPRED = dr.ReadNullAsEmptyInteger("LISTAPRECPRED")
                    End If
                End Using
            End Using

            If Cliente_pos.Trim.Length > 0 Then
                TCLIENTE.Text = Cliente_pos
                LtNombre.Text = BUSCA_CAT("Cliente", Cliente_pos)
            Else
                If CLIE_MOSTR.Trim.Length > 0 Then
                    TCLIENTE.Text = CLIE_MOSTR
                    LtNombre.Text = BUSCA_CAT("Cliente", TCLIENTE.Text)
                End If
            End If

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        ENTRA = False
    End Sub
    Private Sub FrmPosCobro22_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FORM_LOAD_KEY = False
        Debug.Print("Show " & FORM_LOAD_KEY)
        FormIsLoaded = False
        Timer1.Start()

    End Sub
    Private Sub FrmPosCobro22_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.KeyPreview = True
        Timer1.Enabled = False
        TEFECTIVO.Focus()
    End Sub
    Private Sub FrmPosCobro22_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub FrmPosCobro22_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If SalirOK Then
                If MsgBox("Realmente desea cancelar el pago?", vbYesNo) = vbNo Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmPosCobro22_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            If FormIsLoaded = False Then
                Select Case e.KeyCode
                    Case 27
                        Me.Close()
                    Case Keys.F1
                        SalirOK = False

                        BtnGrabar_Click(Nothing, Nothing)
                    Case Keys.F2
                        BtnTarjetaCredito_Click(Nothing, Nothing)
                    Case Keys.F3
                        BtnTarjetaDebito_Click(Nothing, Nothing)
                    Case Keys.F4
                        BtnTiempoAire_Click(Nothing, Nothing)
                    Case Keys.F5
                        'BtnDolar_Click(Nothing, Nothing)
                    Case Keys.F7
                        BtnClienteDatos_Click(Nothing, Nothing)
                End Select
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RadContado_CheckedChanged(sender As Object, e As EventArgs) Handles RadContado.CheckedChanged

        If FormIsLoaded Then
            Return
        End If

        Try
            If RadContado.Checked Then
                'BtnClienteDatos.Visible = False
                'TCLIENTE.Visible = False
                'BtnCliente.Visible = False
                'LtNombre.Visible = False

                TEFECTIVO.Enabled = True
                TTARJ_CREDITO.Enabled = True
                TTARJ_DEBITO.Enabled = True
                TTRANS.Enabled = True
                TVALES.Enabled = True
                TDOLARES.Enabled = True

                BtnTarjetaCredito.Enabled = True
                BtnTarjetaDebito.Enabled = True
                BtnDolar.Enabled = True
                BtnTiempoAire.Enabled = True
                ChFacturar.Checked = False
                ChFacturar.Enabled = True
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub RadCrédito_CheckedChanged(sender As Object, e As EventArgs) Handles RadCrédito.CheckedChanged

        If FormIsLoaded Then
            Return
        End If

        Try
            If RadCrédito.Checked Then
                'BtnClienteDatos.Visible = True
                'TCLIENTE.Visible = True
                'BtnCliente.Visible = True
                'LtNombre.Visible = True
                BtnGrabar.Enabled = True

                TEFECTIVO.Enabled = False
                TTARJ_CREDITO.Enabled = False
                TTARJ_DEBITO.Enabled = False
                TTRANS.Enabled = False
                TVALES.Enabled = False
                TDOLARES.Enabled = False

                TEFECTIVO.Value = 0
                TTARJ_CREDITO.Value = 0
                TTARJ_DEBITO.Value = 0
                TTRANS.Value = 0
                TVALES.Value = 0
                TDOLARES.Value = 0
                LTCAMBIO.Text = ""

                BtnTarjetaCredito.Enabled = False
                BtnTarjetaDebito.Enabled = False
                BtnDolar.Enabled = False
                BtnTiempoAire.Enabled = False
                ChFacturar.Checked = False
                ChFacturar.Enabled = False
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click

        Try
            TEFECTIVO.UpdateValueWithCurrentText()
            TTARJ_CREDITO.UpdateValueWithCurrentText()
            TTARJ_DEBITO.UpdateValueWithCurrentText()
            TTRANS.UpdateValueWithCurrentText()
            TVALES.UpdateValueWithCurrentText()
            TDOLARES.UpdateValueWithCurrentText()

            F1.Focus()
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SalirOK = False
        If IsNumeric(LTCAMBIO.Text.Replace(",", "")) Then
            CAMBIO_DINERO = Convert.ToDecimal(LTCAMBIO.Text.Replace(",", ""))
        Else
            CAMBIO_DINERO = 0
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub
    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub BtnTarjetaCredito_Click(sender As Object, e As EventArgs) Handles BtnTarjetaCredito.Click
        Dim PAGO As Decimal, SUMA As Decimal

        Try
            SUMA = TEFECTIVO.Value + TTARJ_CREDITO.Value + TTARJ_DEBITO.Value + TTRANS.Value + TVALES.Value + TDOLARES.Value

            If SUMA > MONTOVENTA Then
                MsgBox("El pago ya se realizo en su totalidad")
                Return
            End If

            If TTARJ_CREDITO.Value = 0 Then
                PAGO = MONTOVENTA - SUMA
                TTARJ_CREDITO.Value = PAGO
            Else
                PAGO = TTARJ_CREDITO.Value
            End If


            If PAGO = 0 Then

                Me.Cursor = Cursors.Default
                Dim msg As Object, Result As String

                msg = New VtlMessageBox(VisualStyle.Windows7)

                With msg
                    .MessageText = "Por favor capture el pago de la tarjeta de crédito"
                    .AddStandardButtons(MessageBoxButtons.OK)
                    .Caption = "Advertencia"
                    .Icon = MessageBoxIcon.Error
                    .MessageBoxPosition = FormStartPosition.CenterScreen
                    Result = .Show()

                    TTARJ_CREDITO.Focus()
                End With
                Return
            End If

            Using options = New FrmPagoElectronico(PAGO)
                If DialogResult.OK = options.ShowDialog() Then
                    SUMA = TEFECTIVO.Value + TTARJ_CREDITO.Value + TTARJ_DEBITO.Value + TTRANS.Value + TVALES.Value + TDOLARES.Value
                    TTARJ_CREDITO.Enabled = False
                    If SUMA >= MONTOVENTA Then
                        'DESHABILITAR_CONTROLES("TC")
                    End If
                Else
                    TTARJ_CREDITO.Value = 0
                End If
            End Using
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTarjetaDebito_Click(sender As Object, e As EventArgs) Handles BtnTarjetaDebito.Click
        Dim PAGO As Decimal, SUMA As Decimal

        Try
            SUMA = TEFECTIVO.Value + TTARJ_CREDITO.Value + TTARJ_DEBITO.Value + TTRANS.Value + TVALES.Value + TDOLARES.Value

            If SUMA > MONTOVENTA Then
                MsgBox("El pago ya se realizo en su totalidad")
                Return
            End If

            If TTARJ_DEBITO.Value = 0 Then
                PAGO = MONTOVENTA - SUMA
                TTARJ_DEBITO.Value = PAGO
            Else
                PAGO = TTARJ_DEBITO.Value
            End If

            If PAGO = 0 Then
                MsgBox("Por favor capture el pago de la tarjeta de débito")
                TTARJ_DEBITO.Focus()
                Return
            End If

            Using options = New FrmPagoElectronico(PAGO)
                If DialogResult.OK = options.ShowDialog() Then
                    TTARJ_DEBITO.Enabled = False
                    SUMA = TEFECTIVO.Value + TTARJ_CREDITO.Value + TTARJ_DEBITO.Value + TTRANS.Value + TVALES.Value + TDOLARES.Value
                    If SUMA >= MONTOVENTA Then
                        'DESHABILITAR_CONTROLES("TD")
                    End If
                Else
                    TTARJ_DEBITO.Value = 0
                End If
            End Using
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESHABILITAR_CONTROLES(FTPAGO As String)
        Try
            BtnTarjetaCredito.Enabled = False
            BtnTarjetaDebito.Enabled = False
            BtnDolar.Enabled = False

            Select Case FTPAGO
                Case "E"
                    'TTARJ_CREDITO.Enabled = False
                    'TTARJ_DEBITO.Enabled = False
                    'TTRANS.Enabled = False
                    'TVALES.Enabled = False
                    'TDOLARES.Enabled = False
                Case "TC"
                    'TEFECTIVO.Enabled = False
                    'TTARJ_DEBITO.Enabled = False
                    'TTRANS.Enabled = False
                    'TVALES.Enabled = False
                    'TDOLARES.Enabled = False
                Case "TD"
                    'TEFECTIVO.Enabled = False
                    'TTARJ_CREDITO.Enabled = False
                    'TTRANS.Enabled = False
                    'TVALES.Enabled = False
                    'TDOLARES.Enabled = False
                Case "T"
                    'TEFECTIVO.Enabled = False
                    'TTARJ_CREDITO.Enabled = False
                    'TTARJ_DEBITO.Enabled = False
                    'TVALES.Enabled = False
                    'TDOLARES.Enabled = False
                Case "V"
                    'TEFECTIVO.Enabled = False
                    'TTARJ_CREDITO.Enabled = False
                    'TTARJ_DEBITO.Enabled = False
                    'TTRANS.Enabled = False
                    'TDOLARES.Enabled = False
                Case "D"
                    'TEFECTIVO.Enabled = False
                    'TTARJ_CREDITO.Enabled = False
                    'TTARJ_DEBITO.Enabled = False
                    'TTRANS.Enabled = False
                    'TVALES.Enabled = False
            End Select
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTiempoAire_Click(sender As Object, e As EventArgs) Handles BtnTiempoAire.Click

    End Sub
    Sub CALCULA(FTIPO As String)
        Try
            Dim EFECTIVO As Decimal, TARJ_CREDITO As Decimal, TARJ_DEBITO As Decimal, TRANSFER As Decimal, VALES As Decimal
            Dim SUMA As Decimal, DOLARES As Decimal

            If FORM_LOAD_KEY Then
                Return
            End If

            Select Case FTIPO
                Case "E"
                    If IsNumeric(TEFECTIVO.Text) Then
                        EFECTIVO = Convert.ToDecimal(TEFECTIVO.Text)
                    Else
                        EFECTIVO = 0
                    End If
                    TARJ_CREDITO = TTARJ_CREDITO.Value
                    TARJ_DEBITO = TTARJ_DEBITO.Value
                    TRANSFER = TTRANS.Value
                    VALES = TVALES.Value
                Case "TC"
                    EFECTIVO = TEFECTIVO.Value
                    If IsNumeric(TTARJ_CREDITO.Text) Then
                        TARJ_CREDITO = Convert.ToDecimal(TTARJ_CREDITO.Text)
                    Else
                        TARJ_CREDITO = 0
                    End If
                    TARJ_DEBITO = TTARJ_DEBITO.Value
                    TRANSFER = TTRANS.Value
                    VALES = TVALES.Value
                Case "TD"
                    EFECTIVO = TEFECTIVO.Value
                    TARJ_CREDITO = TTARJ_CREDITO.Value
                    If IsNumeric(TTARJ_DEBITO.Text) Then
                        TARJ_DEBITO = Convert.ToDecimal(TTARJ_DEBITO.Text)
                    Else
                        TARJ_DEBITO = 0
                    End If
                    TRANSFER = TTRANS.Value
                    VALES = TVALES.Value
                Case "T"
                    EFECTIVO = TEFECTIVO.Value
                    TARJ_CREDITO = TTARJ_CREDITO.Value
                    TARJ_DEBITO = TTARJ_DEBITO.Value
                    If IsNumeric(TTRANS.Text) Then
                        TRANSFER = Convert.ToDecimal(TTRANS.Text)
                    Else
                        TRANSFER = 0
                    End If
                    VALES = TVALES.Value
                Case "V"
                    EFECTIVO = TEFECTIVO.Value
                    TARJ_CREDITO = TTARJ_CREDITO.Value
                    TARJ_DEBITO = TTARJ_DEBITO.Value
                    TRANSFER = TTRANS.Value
                    If IsNumeric(TVALES.Text) Then
                        VALES = Convert.ToDecimal(TVALES.Text)
                    Else
                        VALES = 0
                    End If
                Case "D"
                    EFECTIVO = TEFECTIVO.Value
                    TARJ_CREDITO = TTARJ_CREDITO.Value
                    TARJ_DEBITO = TTARJ_DEBITO.Value
                    TRANSFER = TTRANS.Value
                    VALES = Convert.ToDecimal(TVALES.Text)

                    If IsNumeric(TDOLARES.Text) Then
                        DOLARES = Convert.ToDecimal(TDOLARES.Text) * TCAMBIO
                    Else
                        DOLARES = 0
                    End If
            End Select

            SUMA = EFECTIVO + TARJ_CREDITO + TARJ_DEBITO + TRANSFER + VALES + DOLARES

            If SUMA >= MONTOVENTA Then
                BtnTarjetaCredito.Enabled = False
                BtnTarjetaDebito.Enabled = False
                BtnDolar.Enabled = False

                BtnGrabar.Enabled = True
            Else
                BtnTarjetaCredito.Enabled = True
                BtnTarjetaDebito.Enabled = True
                BtnDolar.Enabled = True

                BtnGrabar.Enabled = False
            End If

            Select Case FTIPO
                Case "E"
                    If SUMA >= MONTOVENTA Then
                        'TTARJ_CREDITO.Enabled = False
                        'TTARJ_DEBITO.Enabled = False
                        TTRANS.Enabled = False
                        TVALES.Enabled = False
                        TDOLARES.Enabled = False
                    Else
                        'TTARJ_CREDITO.Enabled = True
                        'TTARJ_DEBITO.Enabled = True
                        TTRANS.Enabled = True
                        TVALES.Enabled = True
                        TDOLARES.Enabled = True
                    End If
                Case "TC"
                    If SUMA >= MONTOVENTA Then
                        'TEFECTIVO.Enabled = False
                        'TTARJ_DEBITO.Enabled = False
                        TTRANS.Enabled = False
                        TVALES.Enabled = False
                        TDOLARES.Enabled = False
                    Else
                        'TEFECTIVO.Enabled = True
                        'TTARJ_DEBITO.Enabled = True
                        TTRANS.Enabled = True
                        TVALES.Enabled = True
                        TDOLARES.Enabled = True
                    End If
                Case "TD"
                    If SUMA >= MONTOVENTA Then
                        'TEFECTIVO.Enabled = False
                        'TTARJ_CREDITO.Enabled = False
                        TTRANS.Enabled = False
                        TVALES.Enabled = False
                        TDOLARES.Enabled = False
                    Else
                        'TEFECTIVO.Enabled = True
                        'TTARJ_CREDITO.Enabled = True
                        TTRANS.Enabled = True
                        TVALES.Enabled = True
                        TDOLARES.Enabled = True
                    End If
                Case "T"
                    If SUMA >= MONTOVENTA Then
                        'TEFECTIVO.Enabled = False
                        'TTARJ_CREDITO.Enabled = False
                        'TTARJ_DEBITO.Enabled = False
                        TVALES.Enabled = False
                        TDOLARES.Enabled = False
                    Else
                        'TEFECTIVO.Enabled = True
                        'TTARJ_CREDITO.Enabled = True
                        'TTARJ_DEBITO.Enabled = True
                        TVALES.Enabled = True
                        TDOLARES.Enabled = True
                    End If
                Case "V"
                    If SUMA >= MONTOVENTA Then
                        'TEFECTIVO.Enabled = False
                        'TTARJ_CREDITO.Enabled = False
                        'TTARJ_DEBITO.Enabled = False
                        TTRANS.Enabled = False
                        TDOLARES.Enabled = False
                    Else
                        'TEFECTIVO.Enabled = True
                        'TTARJ_CREDITO.Enabled = True
                        'TTARJ_DEBITO.Enabled = True
                        TTRANS.Enabled = True
                        TDOLARES.Enabled = True
                    End If
                Case "D"
                    If SUMA >= MONTOVENTA Then
                        'TEFECTIVO.Enabled = False
                        'TTARJ_CREDITO.Enabled = False
                        'TTARJ_DEBITO.Enabled = False
                        TTRANS.Enabled = False
                        TVALES.Enabled = False
                    Else
                        'TEFECTIVO.Enabled = True
                        'TTARJ_CREDITO.Enabled = True
                        'TTARJ_DEBITO.Enabled = True
                        TTRANS.Enabled = True
                        TVALES.Enabled = True
                    End If
            End Select

            LtImporte.Text = Format(SUMA, "###,###,##0.00")

            LTCAMBIO.Text = Format(SUMA - MONTOVENTA, "###,###,##0.00")

            If SUMA - MONTOVENTA >= 0 Then
                LTCAMBIO.BackColor = Color.Black
                LTCAMBIO.ForeColor = Color.White
            Else
                LTCAMBIO.BackColor = Color.Red
                LTCAMBIO.ForeColor = Color.White
            End If
        Catch ex As Exception
            BITACORATPV("2160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEFECTIVO_TextChanged(sender As Object, e As EventArgs) Handles TEFECTIVO.TextChanged
        CALCULA("E")
    End Sub
    Private Sub TTARJ_CREDITO_TextChanged(sender As Object, e As EventArgs) Handles TTARJ_CREDITO.TextChanged
        CALCULA("TC")
    End Sub
    Private Sub TTARJ_DEBITO_TextChanged(sender As Object, e As EventArgs) Handles TTARJ_DEBITO.TextChanged
        CALCULA("TD")
    End Sub
    Private Sub TTRANS_TextChanged(sender As Object, e As EventArgs) Handles TTRANS.TextChanged
        CALCULA("T")
    End Sub
    Private Sub TVALES_TextChanged(sender As Object, e As EventArgs) Handles TVALES.TextChanged
        CALCULA("V")
    End Sub
    Private Sub TDOLARES_TextChanged(sender As Object, e As EventArgs) Handles TDOLARES.TextChanged
        CALCULA("D")
    End Sub
    Private Sub TEFECTIVO_GotFocus(sender As Object, e As EventArgs) Handles TEFECTIVO.GotFocus
        TEFECTIVO.BorderColor = Color.Orange
    End Sub

    Private Sub TTARJ_CREDITO_GotFocus(sender As Object, e As EventArgs) Handles TTARJ_CREDITO.GotFocus
        TTARJ_CREDITO.BorderColor = Color.Orange
    End Sub

    Private Sub TTARJ_DEBITO_GotFocus(sender As Object, e As EventArgs) Handles TTARJ_DEBITO.GotFocus
        TTARJ_DEBITO.BorderColor = Color.Orange
    End Sub

    Private Sub TTRANS_GotFocus(sender As Object, e As EventArgs) Handles TTRANS.GotFocus
        TTRANS.BorderColor = Color.Orange
    End Sub

    Private Sub TVALES_GotFocus(sender As Object, e As EventArgs) Handles TVALES.GotFocus
        TVALES.BorderColor = Color.Orange
    End Sub

    Private Sub TEFECTIVO_LostFocus(sender As Object, e As EventArgs) Handles TEFECTIVO.LostFocus
        TEFECTIVO.BorderColor = Color.Silver
    End Sub

    Private Sub TTARJ_CREDITO_LostFocus(sender As Object, e As EventArgs) Handles TTARJ_CREDITO.LostFocus
        TTARJ_CREDITO.BorderColor = Color.Silver
    End Sub

    Private Sub TTARJ_DEBITO_LostFocus(sender As Object, e As EventArgs) Handles TTARJ_DEBITO.LostFocus
        TTARJ_DEBITO.BorderColor = Color.Silver
    End Sub
    Private Sub TTRANS_LostFocus(sender As Object, e As EventArgs) Handles TTRANS.LostFocus
        TTRANS.BorderColor = Color.Silver
    End Sub
    Private Sub TVALES_LostFocus(sender As Object, e As EventArgs) Handles TVALES.LostFocus
        TVALES.BorderColor = Color.Silver
    End Sub
    Private Sub BtnGrabar_GotFocus(sender As Object, e As EventArgs) Handles BtnGrabar.GotFocus
        BtnGrabar.FlatAppearance.BorderColor = Color.Orange
    End Sub
    Private Sub BtnGrabar_LostFocus(sender As Object, e As EventArgs) Handles BtnGrabar.LostFocus
        BtnGrabar.FlatAppearance.BorderColor = Color.Silver
    End Sub
    Private Sub BtnCancelar_GotFocus(sender As Object, e As EventArgs) Handles BtnCancelar.GotFocus
        BtnCancelar.FlatAppearance.BorderColor = Color.Orange
    End Sub
    Private Sub BtnCancelar_LostFocus(sender As Object, e As EventArgs) Handles BtnCancelar.LostFocus
        BtnCancelar.FlatAppearance.BorderColor = Color.Silver
    End Sub
    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "CTE_CREDITO"
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
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
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            Dim DATO As String = ""
            If TCLIENTE.Text.Trim.Length = 0 Then
                Return
            End If

            DATO = BUSCA_CAT("Cliente", TCLIENTE.Text)
            If DATO = "" Then
                MsgBox("Cliente inexistente", "1", "2")
            Else
                'TCLIENTE.Enabled = False
                'BtnCliente.Enabled = False
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEFECTIVO_KeyDown(sender As Object, e As KeyEventArgs) Handles TEFECTIVO.KeyDown
        Dim EFECTIVO As Decimal
        Dim SUMA As Decimal

        Select Case e.KeyCode
            Case Keys.Enter

                If IsNumeric(TEFECTIVO.Text) Then
                    EFECTIVO = TEFECTIVO.Text
                    SUMA = EFECTIVO + TTARJ_CREDITO.Value + TTARJ_DEBITO.Value + TTRANS.Value + TVALES.Value + TDOLARES.Value
                    If SUMA >= MONTOVENTA Then
                        PnlGrabar.Focus()
                    End If
                End If
            Case Keys.Up

            Case Keys.Down
                TTARJ_CREDITO.Focus()
        End Select
    End Sub
    Private Sub TTARJ_CREDITO_KeyDown(sender As Object, e As KeyEventArgs) Handles TTARJ_CREDITO.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                TEFECTIVO.Focus()
            Case Keys.Down
                TTARJ_DEBITO.Focus()
        End Select
    End Sub
    Private Sub TTARJ_DEBITO_KeyDown(sender As Object, e As KeyEventArgs) Handles TTARJ_DEBITO.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                TTARJ_CREDITO.Focus()
            Case Keys.Down
                TTRANS.Focus()
        End Select
    End Sub
    Private Sub TTRANS_KeyDown(sender As Object, e As KeyEventArgs) Handles TTRANS.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                TTARJ_DEBITO.Focus()
            Case Keys.Down
                TVALES.Focus()
        End Select
    End Sub
    Private Sub TVALES_KeyDown(sender As Object, e As KeyEventArgs) Handles TVALES.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                TTRANS.Focus()
            Case Keys.Down
                TDOLARES.Focus()
        End Select
    End Sub
    Private Sub TDOLARES_KeyDown(sender As Object, e As KeyEventArgs) Handles TDOLARES.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                TVALES.Focus()
            Case Keys.Down
        End Select
    End Sub
    Private Sub BtnClienteDatos_Click(sender As Object, e As EventArgs) Handles BtnClienteDatos.Click
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Var1 = "Consulta"
                Var2 = TCLIENTE.Text
                Using options = New FrmDatosCliente
                    If DialogResult.OK = options.ShowDialog() Then

                    End If
                End Using
            Else
                MsgBox("Para realizar la consulta por favor seleccione un cliente")
                TCLIENTE.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTARJ_CREDITO_Validating(sender As Object, e As CancelEventArgs) Handles TTARJ_CREDITO.Validating
        Try
            If TTARJ_CREDITO.Text > 0 Then
                BtnTarjetaCredito_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            BITACORATPV("2620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2620. " & ex.Message & vbNewLine & ex.StackTrace)
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
                BtnGrabar.Focus()
            End If
        Catch ex As Exception
            BITACORATPV("2290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_VEND_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VEND.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnVend_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            BtnGrabar.Focus()
        End If
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
                    MsgBox("Vendedor inexistente")
                    TCVE_VEND.Text = ""
                End If
            End If
        Catch ex As Exception
            BITACORATPV("2400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_VEND_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCVE_VEND.PreviewKeyDown
        If e.KeyCode = 9 Then
            BtnGrabar.Focus()
        End If
    End Sub

    Public ReadOnly Property MyFacturarVenta As Boolean
        Get
            Return Me.ChFacturar.Checked
        End Get
    End Property
    Public ReadOnly Property MyTipoVenta As Boolean
        Get
            Return Me.RadContado.Checked
        End Get
    End Property
    Public ReadOnly Property MyEfectivo As Decimal
        Get
            Return Me.TEFECTIVO.Value
        End Get
    End Property
    Public ReadOnly Property MyTarjcredito As Decimal
        Get
            Return Me.TTARJ_CREDITO.Value
        End Get
    End Property
    Public ReadOnly Property MyTarjdebito As Decimal
        Get
            Return Me.TTARJ_DEBITO.Value
        End Get
    End Property
    Public ReadOnly Property MyTrans As Decimal
        Get
            Return Me.TTRANS.Value
        End Get
    End Property
    Public ReadOnly Property MyVales As Decimal
        Get
            Return Me.TVALES.Value
        End Get
    End Property
    Public ReadOnly Property MyDolares As Decimal
        Get
            Return Me.TDOLARES.Value * TCAMBIO
        End Get
    End Property
    Public ReadOnly Property MyCambio As Decimal
        Get
            Return CAMBIO_DINERO
        End Get
    End Property
    Public ReadOnly Property MyObs As String
        Get
            Return Me.TOBS.Text
        End Get
    End Property


End Class


