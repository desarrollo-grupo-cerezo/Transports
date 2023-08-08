Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports System.IO
Public Class frmConciValesComEditViking
    Private FACTOR_IEPS As Single = 0
    Private NewVale As Boolean

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DTOS1()
        Me.ResumeLayout()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmConciValesComEditViking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FACTOR_IEPS = 0 Then
            MsgBox("El factor IEPS no ha sido capturado favor de capturarlo en configuración-TransportCG")
        End If

        Var48 = 0

        F1.Focus()
        F1.Select()
    End Sub

    Sub CARGAR_DTOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Try
            'FECHA.Value = Date.Today
            FECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.CustomFormat = "dd/MM/yyyy"
            FECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

            'F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"


            KeyPreview = True

            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0

            BtnGas.FlatStyle = FlatStyle.Flat
            BtnGas.FlatAppearance.BorderSize = 0

            BtnReset.FlatStyle = FlatStyle.Flat
            BtnReset.FlatAppearance.BorderSize = 0

            BtnViaje.FlatStyle = FlatStyle.Flat
            BtnViaje.FlatAppearance.BorderSize = 0
            BtnCancel.FlatStyle = FlatStyle.Flat
            BtnCancel.FlatAppearance.BorderSize = 0

        Catch ex As Exception
        End Try
        Try
            SQL = "SELECT * FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        FACTOR_IEPS = dr.ReadNullAsEmptyDecimal("FACTOR_IEPS")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        If PASS_GRUPOCE.ToUpper = "BUS" Or PASS_GRUPOCE.ToUpper = "BR3FRAJA" Then
            BarDisenoReporte.Visible = True
        Else
            BarDisenoReporte.Visible = False
        End If

        If Var3 = "Reasignar" Then
            BtnReset.Visible = True
        Else
            BtnReset.Visible = False
        End If

        Try
            If frmReseteo.Fg1.Rows.Count <= 2 Then
                btnAnterior.Visible = False
                btnFinal.Visible = False
                btnInicial.Visible = False
                btnSiguiente.Visible = False
            Else
                btnAnterior.Visible = True
                btnFinal.Visible = True
                btnInicial.Visible = True
                btnSiguiente.Visible = True
            End If
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        LtFactorIEPS.Text = FACTOR_IEPS
        LtReset.Text = Var7

        If Var1 = "Nuevo" Then
            NewVale = True
            F1.Value = PassData10
            CboStatus.SelectedIndex = 0
            TLTS_REALES.Value = Var49

            TCVE_OPER.Text = TFOLIO.Tag
            LOper.Text = Var6
        Else
            NewVale = False
            TFOLIO.Text = Var4
            TCVE_OPER.Text = Var5
            LOper.Text = Var6

            DESPLEGAR_VALE()
        End If

        CALCULO()
    End Sub
    Sub DESPLEGAR_VALE()
        Try
            Dim SiEncontro As Boolean = False, FOLIO As Long, GVFOLIO As String

            If TFOLIO.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture el folio a buscar")
                Return
            End If

            If IsNumeric(TFOLIO.Text) Then
                FOLIO = TFOLIO.Text
                '0000159869
                GVFOLIO = Format(FOLIO, "0000000000")
                TFOLIO.Text = GVFOLIO
            Else
                GVFOLIO = TFOLIO.Text
            End If

            SQL = "SELECT ISNULL(GV.CVE_VIAJE,'') AS VIAJE, ISNULL(GV.FOLIO,'') AS FOL_VALE, ISNULL(S.CVE_TRACTOR,'') AS UNIDAD, 
                ISNULL(GV.FECHA,'') AS F_VALE, ISNULL(GV.CVE_GAS,'') AS CVE_GAS_V, ISNULL(G.DESCR,'') AS GASOLINERA, ISNULL(GV.LITROS,0) AS LTS, 
                ISNULL(GV.LITROS_REALES,0) AS LTS_REALES, ISNULL(GV.P_X_LITRO,0) AS PRECIO_LTS, ISNULL(GV.ST_VALES,'EDICION') AS ST_VAL, 
                ISNULL(GV.OBS,'') AS OBSER, ISNULL(FACTURA,'') AS FACT, GV.FECHA_CARGA
                FROM GCASIGNACION_VIAJE_VALES GV
                LEFT JOIN GCASIGNACION_VIAJE S ON S.CVE_VIAJE = GV.CVE_VIAJE                
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                WHERE GV.FOLIO = '" & GVFOLIO & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LtViaje.Text = dr("VIAJE") 'GV.CVE_VIAJE
                        FECHA.Value = dr("F_VALE") 'GC.FECHA
                        TFACTURA.Text = dr("FACT")
                        F1.Value = dr("FECHA_CARGA")
                        TCVE_GAS.Text = dr("CVE_GAS_V") 'GV.CVE_GAS
                        LtGas.Text = dr("GASOLINERA") 'G.DESCR
                        LtLts_Inic.Text = Format(dr("LTS"), "###,###,##0.000") 'GC.LITROS

                        TLTS_REALES.Value = dr("LTS_REALES") 'GV.LITROS_REALES
                        TPRECIO_X_LTS.Value = dr("PRECIO_LTS") 'GV.P_X_LITRO

                        'CAPTURADO
                        'ACEPTADO

                        Select Case dr("ST_VAL")      'GV.ST_VALES
                            Case "CAPTURADO"
                                CboStatus.SelectedIndex = 0
                            Case "ACEPTADO"
                                CboStatus.SelectedIndex = 1
                            Case Else
                                CboStatus.SelectedIndex = 0
                        End Select
                        TObs.Text = dr("OBSER") 'GV.OBS
                        SiEncontro = True

                        If dr("ST_VAL") = "ACEPTADO" Then
                            HABILITAR_DESHABILITAR_CONTROLES(False)
                        Else
                            HABILITAR_DESHABILITAR_CONTROLES(True)
                        End If
                    Else
                        MessageBox.Show("Folio inexistente ó se encuentra aceptado, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        TFOLIO.Text = "" : LtFactorIEPS.Text = "" : LtViaje.Text = "" : FECHA.Value = "" : TCVE_GAS.Text = "" : LtGas.Text = ""
                        LtLts_Inic.Text = "" : TLTS_REALES.Value = "" : TPRECIO_X_LTS.Value = "" : LtIEPS.Text = ""
                        LtIVA.Text = "" : LtSubtotal.Text = "" : LtTotal.Text = "" : CboStatus.SelectedIndex = -1 : TObs.Text = ""
                    End If
                End Using
                If SiEncontro Then
                    CALCULO()
                End If

                TCVE_GAS.Focus()
            End Using

        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub HABILITAR_DESHABILITAR_CONTROLES(FEFECTO As Boolean)
        Try
            TCVE_GAS.Enabled = FEFECTO
            BtnGas.Enabled = FEFECTO
            F1.Enabled = FEFECTO
            TLTS_REALES.Enabled = FEFECTO
            TPRECIO_X_LTS.Enabled = FEFECTO
            CboStatus.Enabled = FEFECTO
            TObs.Enabled = FEFECTO
            BarGrabar.Enabled = FEFECTO
            BtnOper.Enabled = FEFECTO
            TCVE_OPER.Enabled = FEFECTO
            FECHA.Enabled = FEFECTO
            TFOLIO.Enabled = FEFECTO
            TFACTURA.Enabled = FEFECTO

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmConciValesComEditViking_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim P_X_LITRO As Single = 0, LITROS_REALES As Decimal = 0, SUBTOTAL As Single = 0, IVA As Single = 0, IEPS As Single = 0
        Dim IMPORTE As Single = 0, OBS As String = "", F1_NULL As Boolean = False, FOLIOV As Long
        Dim CVE_OPER As Int32

        CALCULO()

        Try
            If IsNumeric(TLTS_REALES.Text.Replace(",", "")) Then
                LITROS_REALES = TLTS_REALES.Text.Replace(",", "")
            End If
            If IsNumeric(TPRECIO_X_LTS.Text) Then
                P_X_LITRO = TPRECIO_X_LTS.Text
            End If
            If IsNumeric(LtSubtotal.Text.Replace(",", "")) Then
                SUBTOTAL = LtSubtotal.Text.Replace(",", "")
            End If
            If IsNumeric(LtIVA.Text.Replace(",", "")) Then
                IVA = LtIVA.Text.Replace(",", "")
            End If
            If IsNumeric(LtIEPS.Text.Replace(",", "")) Then
                IEPS = LtIEPS.Text.Replace(",", "")
            End If
            If IsNumeric(LtTotal.Text.Replace(",", "")) Then
                IMPORTE = LtTotal.Text.Replace(",", "")
            End If

            OBS = TObs.Text

            If IEPS = 0 Then
                IEPS = LITROS_REALES * FACTOR_IEPS
            End If

            FOLIOV = CLng(TFOLIO.Text)

            If IsNumeric(TFOLIO.Tag) Then
                CVE_OPER = TFOLIO.Tag
            Else
                CVE_OPER = 0
            End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If TCVE_GAS.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la gasolinera")
                TCVE_GAS.Select()
                Return
            End If
            If LITROS_REALES = 0 Then
                MsgBox("Por favor capture los litros reales")
                TLTS_REALES.Select()
                Return
            End If
            If P_X_LITRO <= 0 Then
                MsgBox("Por favor capture el precio x litro")
                TPRECIO_X_LTS.Select()
                Return
            End If

            If SUBTOTAL = 0 Or IVA = 0 Or IEPS = 0 Or IMPORTE = 0 Then
                MsgBox("Existe algun dato incorrecto verifique por favor")
                Return
            End If

            If IsDBNull(F1.Value) Then
                F1_NULL = True
            End If
            If IsNothing(F1.Value) Then
                F1_NULL = True
            End If

            If CboStatus.Text = "ACEPTADO" And F1_NULL Then
                'MsgBox("Por favor capture la fecha de carga")
                Dim dialog As DialogResult = MessageBox.Show("Por favor capture la fecha de carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If MsgBox("Realmente desea grabar el vale?", vbYesNo) = vbNo Then
            Return
        End If

        If Valida_Conexion() Then
        End If

        Try
            'SELECT LITROS_REALES FROM GCASIGNACION_VIAJE_VALES  CVE_RESET = 356
            SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET FECHA_CARGA = @FECHA_CARGA, CVE_GAS = @CVE_GAS, LITROS_REALES = @LITROS_REALES, 
                P_X_LITRO = @P_X_LITRO, SUBTOTAL = @SUBTOTAL, IVA = @IVA, IEPS = @IEPS, IMPORTE = @IMPORTE, ST_VALES = @ST_VALES, 
                OBS = @OBS, FACTURA = @FACTURA, CVE_OPER = @CVE_OPER, CVE_RESET = @CVE_RESET
                WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO
                IF @@ROWCOUNT = 0
                INSERT INTO GCASIGNACION_VIAJE_VALES (CVE_VIAJE, STATUS, CVE_OPER, FOLIO, CVE_RESET, FECHA, FECHA_TRASPASO, 
                FECHA_CARGA, CVE_GAS, LITROS_REALES, P_X_LITRO, SUBTOTAL, IVA, IEPS, IMPORTE, FACTURA, FECHAELAB, ST_VALES, 
                OBS, UUID) VALUES(
                @CVE_VIAJE, 'A', @CVE_OPER, @FOLIO, @CVE_RESET, @FECHA, @FECHA_TRASPASO, @FECHA_CARGA, @CVE_GAS, @LITROS_REALES, 
                @P_X_LITRO, @SUBTOTAL, @IVA, @IEPS, @IMPORTE, @FACTURA, GETDATE(), @ST_VALES, @OBS, NEWID())"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtViaje.Text
                cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                cmd.Parameters.Add("@CVE_RESET", SqlDbType.Int).Value = CONVERTIR_TO_INT(LtReset.Text)
                cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = Format(FOLIOV, "0000000000")
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@FECHA_TRASPASO", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = TCVE_GAS.Text
                cmd.Parameters.Add("@LITROS_REALES", SqlDbType.Float).Value = Math.Round(LITROS_REALES, 4)
                cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = Math.Round(P_X_LITRO, 4)
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL, 6)
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA, 6)
                cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(IEPS, 6)
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                cmd.Parameters.Add("@FACTURA", SqlDbType.VarChar).Value = TFACTURA.Text
                cmd.Parameters.Add("@ST_VALES", SqlDbType.VarChar).Value = CboStatus.Text
                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = OBS
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using

            Try
                Var48 = 0
                If LITROS_REALES > 0 Then
                    Dim SUM_LTS_REALES As Decimal = 0

                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        SQL = "SELECT ISNULL(SUM(LITROS_REALES),0) AS LTS_R 
                            FROM GCASIGNACION_VIAJE_VALES 
                            WHERE STATUS = 'A' AND CVE_RESET = " & CONVERTIR_TO_INT(LtReset.Text)
                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                SUM_LTS_REALES = dr("LTS_R")
                            End If
                        End Using
                    End Using

                    If SUM_LTS_REALES > 0 Then
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "UPDATE GCRESETEO SET LTS_VALES = " & SUM_LTS_REALES & " 
                                WHERE CVE_RES = " & CONVERTIR_TO_INT(LtReset.Text)
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                        'Var48 = SUM_LTS_REALES
                        If FORM_IS_OPEN("frmReseteoAE") Then
                            FrmReseteoAE.TLTS_VALES.Value = SUM_LTS_REALES
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            MsgBox("Los datos se grabaron satisfactoriamente")

            If NewVale Then
                TFOLIO.Text = GET_MAX_TRY("GCASIGNACION_VIAJE_VALES", "FOLIO")
                LIMPIAR()
                TFACTURA.Focus()
            Else
                Me.Close()
            End If

        Catch ex As Exception
            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            TFACTURA.Text = ""
            'LtReset.Text = ""
            'TCVE_OPER.Text = ""
            'LOper.Text = ""

            TCVE_GAS.Text = ""
            LtGas.Text = ""
            LtLts_Inic.Text = ""
            TLTS_REALES.Value = 0
            TPRECIO_X_LTS.Value = 0
            CboStatus.SelectedIndex = 0
            TObs.Text = ""
            LtSubtotal.Text = ""
            LtIVA.Text = ""
            LtIEPS.Text = ""
            LtTotal.Text = ""
            LtViaje.Text = ""
            'FECHA.Value = ""
            'F1.Value = ""
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TPRECIO_X_LTS_TabIndexChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LTS.TabIndexChanged
        CALCULO()
    End Sub
    Sub CALCULO()
        Dim PRECIO_SIN_IEPS As Decimal = 0, SUBTOTAL1 As Decimal, SUBTOTAL2 As Decimal, IEPS As Decimal, PRECIO As Decimal, LITROS As Single = 0
        Try
            Try
                LITROS = TLTS_REALES.Text
            Catch ex As Exception
            End Try
            Try
                PRECIO = TPRECIO_X_LTS.Text
            Catch ex As Exception
            End Try

            IEPS = LITROS * FACTOR_IEPS
            If PRECIO > 0 Then
                If LITROS > 0 Then
                    PRECIO_SIN_IEPS = PRECIO - (IEPS / LITROS)
                End If
            Else
                PRECIO_SIN_IEPS = 0
            End If

            SUBTOTAL1 = LITROS * PRECIO_SIN_IEPS
            SUBTOTAL2 = SUBTOTAL1 / 1.16

            LtSubtotal.Text = Format(SUBTOTAL2, "###,###,##0.0000")
            LtIVA.Text = Format(SUBTOTAL2 * 0.16, "###,###,##0.0000")
            LtIEPS.Text = Format(IEPS, "###,###,##0.0000")
            LtTotal.Text = Format(SUBTOTAL2 + IEPS + (SUBTOTAL2 * 0.16), "###,###,##0.0000")

        Catch ex As Exception
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnGas_Click(sender As Object, e As EventArgs) Handles BtnGas.Click
        Try
            Var2 = "Gasolinera"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_GAS.Text = Var4
                LtGas.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TLTS_REALES.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_GAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnGas_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_GAS_Validated(sender As Object, e As EventArgs) Handles TCVE_GAS.Validated
        Try
            Dim DESCR As String
            If TCVE_GAS.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", TCVE_GAS.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtGas.Text = DESCR
                Else
                    MsgBox("Gasolinera inexistente")
                    TCVE_GAS.Text = ""
                    LtGas.Text = ""
                End If
            Else
                TCVE_GAS.Text = ""
                LtGas.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub CboStatus_Enter(sender As Object, e As EventArgs) Handles CboStatus.Enter
        Try
            If TCVE_GAS.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la gasolinera")
                TCVE_GAS.Select()
                Return
            End If
            If Not IsNumeric(TLTS_REALES.Text) Then
                MsgBox("Por favor capture los litros reales")
                TLTS_REALES.Select()
                Return
            End If
            If CDec(TLTS_REALES.Text) <= 0 Then
                MsgBox("Por favor capture los litros reales")
                TLTS_REALES.Select()
                Return
            End If

            If Not IsNumeric(TPRECIO_X_LTS.Text) Then
                MsgBox("Por favor capture el precio x litro")
                TPRECIO_X_LTS.Select()
                Return
            End If
            If CDec(TPRECIO_X_LTS.Text) <= 0 Then
                MsgBox("Por favor capture el precio x litro")
                TPRECIO_X_LTS.Select()
                Return
            End If
            If TPRECIO_X_LTS.Focused Then
                CboStatus.SelectedIndex = 1
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPRECIO_X_LTS_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LTS.TextChanged
        CALCULO()
    End Sub

    Private Sub TLTS_REALES_TextChanged(sender As Object, e As EventArgs) Handles TLTS_REALES.TextChanged
        CALCULO()
    End Sub

    Private Sub FrmConciValesComEditViking_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Return) Then
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmConciValesComEditViking_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            BtnAnterior_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F9 Then
            BtnInicial_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.F11 Then
            BtnSiguiente_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F12 Then
            BtnFinal_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 27 Then
            TFOLIO.Focus()
        End If

    End Sub
    Private Sub CboStatus_GotFocus(sender As Object, e As EventArgs) Handles CboStatus.GotFocus
        CboStatus.BackColor = Color.Yellow

    End Sub

    Private Sub CboStatus_LostFocus(sender As Object, e As EventArgs) Handles CboStatus.LostFocus
        CboStatus.BackColor = Color.FromArgb(233, 241, 250)
    End Sub

    Private Sub TObs_KeyDown(sender As Object, e As KeyEventArgs) Handles TObs.KeyDown
        If e.KeyCode = 13 Then
            TCVE_GAS.Focus()
        End If
    End Sub

    Private Sub TObs_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TObs.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCVE_GAS.Focus()
        End If
    End Sub

    Private Sub BtnInicial_Click(sender As Object, e As EventArgs) Handles btnInicial.Click
        Try
            frmReseteo.Fg1.Row = 1
            TFOLIO.Text = frmReseteo.Fg1(frmReseteo.Fg1.Row, 2)
            DESPLEGAR_VALE()

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If frmReseteo.Fg1.Row - 1 > 0 Then
            frmReseteo.Fg1.Row = frmReseteo.Fg1.Row - 1
            TFOLIO.Text = frmReseteo.Fg1(frmReseteo.Fg1.Row, 2)
            DESPLEGAR_VALE()
        End If
    End Sub
    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If frmReseteo.Fg1.Row + 1 < frmReseteo.Fg1.Rows.Count - 1 Then
            frmReseteo.Fg1.Row = frmReseteo.Fg1.Row + 1
            TFOLIO.Text = frmReseteo.Fg1(frmReseteo.Fg1.Row, 2)
            DESPLEGAR_VALE()
        End If
    End Sub
    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        Try
            frmReseteo.Fg1.Row = frmReseteo.Fg1.Rows.Count - 1
            TFOLIO.Text = frmReseteo.Fg1(frmReseteo.Fg1.Row, 2)
            DESPLEGAR_VALE()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmConciValesComEditViking_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        F1.Focus()
    End Sub
    Private Sub TFOLIO_KeyDown(sender As Object, e As KeyEventArgs) Handles TFOLIO.KeyDown
        If e.KeyCode = 13 Then
            DESPLEGAR_VALE()
        End If
    End Sub
    Private Sub TFOLIO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TFOLIO.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCVE_GAS.Focus()
        End If
    End Sub
    Private Sub BtnOper_Click(sender As Object, e As EventArgs) Handles BtnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_OPER.Text = Var4
                LOper.Text = Var5  'NOMBRE
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_GAS.Focus()
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("110. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOper_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
            If TCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Operador", TCVE_OPER.Text)
                If DESCR <> "" Then
                    LOper.Text = DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    TCVE_GAS.Focus()
                Else
                    MsgBox("Operador inexistente")
                    LOper.Text = ""
                    TCVE_OPER.Text = ""
                    TCVE_OPER.Select()
                End If
            Else
                TCVE_OPER.Text = ""
                LOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Try
            Var2 = "Reseteo"
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                LtReset.Text = Var4
            End If
        Catch ex As Exception
            Bitacora("1460. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1460. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim j As Integer = 0

            BarImprimir.Enabled = False

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportConviValesVikingTK.mrt"
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
            StiReport1.Item("FOLIO") = TFOLIO.Text

            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        BarImprimir.Enabled = True
    End Sub
    Private Sub BarDisenoReporte_Click(sender As Object, e As ClickEventArgs) Handles BarDisenoReporte.Click
        PrinterMRT("ReportConviValesVikingTK")
    End Sub

    Private Sub BtnViaje_Click(sender As Object, e As EventArgs) Handles BtnViaje.Click
        Try
            Var10 = LtReset.Text
            Var11 = ""
            FrmTab2SelViaje.ShowDialog()
            If Var11.Trim.Length > 0 Then
                LtViaje.Text = Var11
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        LtViaje.Text = ""
    End Sub
End Class
