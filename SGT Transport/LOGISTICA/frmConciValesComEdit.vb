Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class FrmConciValesComEdit
    Private FACTOR_IEPS As Single = 0
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub FrmConciValesComEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        If FACTOR_IEPS = 0 Then
            MsgBox("El factor IEPS no ha sido capturado favor de capturarlo en configuración-TransportCG")
        End If
        Try
            If FrmConciValesCombus.Fg1.Rows.Count <= 2 Then
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
        End Try
        LtFactorIEPS.Text = FACTOR_IEPS

        CALCULO()
        F1.Focus()
        F1.Select()
    End Sub
    Private Sub FrmConciValesComEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim P_X_LITRO As Single = 0, LITROS_REALES As Decimal = 0, SUBTOTAL As Single = 0, IVA As Single = 0, IEPS As Single = 0
        Dim IMPORTE As Single = 0, OBS As String = "", F1_NULL As Boolean = False


        If TFOLIO.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el folio")
            Return
        End If

        CALCULO()

        Try
            If IsNumeric(TLTS_REALES.Text) Then
                LITROS_REALES = TLTS_REALES.Text
            Else
                LITROS_REALES = 0
            End If
            If IsNumeric(TPRECIO_X_LTS.Text) Then
                P_X_LITRO = TPRECIO_X_LTS.Text
            Else
                P_X_LITRO = 0
            End If
            SUBTOTAL = LtSubtotal.Text.Replace(",", "")
            IVA = LtIVA.Text.Replace(",", "")
            IEPS = LtIEPS.Text.Replace(",", "")
            IMPORTE = LtTotal.Text.Replace(",", "")
            OBS = TObs.Text

            If IEPS = 0 Then
                IEPS = LITROS_REALES * FACTOR_IEPS
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
        Try
            SQL = "UPDATE GCASIGNACION_VIAJE_VALES SET FECHA_CARGA = @FECHA_CARGA, CVE_GAS = @CVE_GAS, LITROS_REALES = @LITROS_REALES, 
                P_X_LITRO = @P_X_LITRO, SUBTOTAL = @SUBTOTAL, IVA = @IVA, IEPS = @IEPS, IMPORTE = @IMPORTE, ST_VALES = @ST_VALES, OBS = @OBS
                WHERE CVE_VIAJE = @CVE_VIAJE AND FOLIO = @FOLIO"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = LtViaje.Text
                cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = TFOLIO.Text
                cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.Date).Value = F1.Value
                cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = TCVE_GAS.Text
                cmd.Parameters.Add("@LITROS_REALES", SqlDbType.Float).Value = Math.Round(LITROS_REALES, 4)
                cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = Math.Round(P_X_LITRO, 4)
                cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(SUBTOTAL, 6)
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(IVA, 6)
                cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(IEPS, 6)
                cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(IMPORTE, 6)
                cmd.Parameters.Add("@ST_VALES", SqlDbType.VarChar).Value = CboStatus.Text
                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = OBS
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
            MsgBox("Los datos se grabaron satisfactoriamente")

            LIMPIAR()

        Catch ex As Exception
            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
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
                CboStatus.SelectedIndex = 0
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

    Private Sub FrmConciValesComEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Return) Then
                SendKeys.Send("{TAB}")
                e.Handled = True
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmConciValesComEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F10 Then
            btnAnterior_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F9 Then
            btnInicial_Click(Nothing, Nothing)
        End If

        If e.KeyCode = Keys.F11 Then
            btnSiguiente_Click(Nothing, Nothing)
        End If
        If e.KeyCode = Keys.F12 Then
            btnFinal_Click(Nothing, Nothing)
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
            FrmConciValesCombus.Fg1.Row = 1
            TFOLIO.Text = FrmConciValesCombus.Fg1(FrmConciValesCombus.Fg1.Row, 2)
            DESPLEGAR_VALE()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        If FrmConciValesCombus.Fg1.Row - 1 > 0 Then
            FrmConciValesCombus.Fg1.Row = FrmConciValesCombus.Fg1.Row - 1
            TFOLIO.Text = FrmConciValesCombus.Fg1(FrmConciValesCombus.Fg1.Row, 2)
            DESPLEGAR_VALE()
        End If
    End Sub
    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        If FrmConciValesCombus.Fg1.Row + 1 < FrmConciValesCombus.Fg1.Rows.Count - 1 Then
            FrmConciValesCombus.Fg1.Row = FrmConciValesCombus.Fg1.Row + 1
            TFOLIO.Text = FrmConciValesCombus.Fg1(FrmConciValesCombus.Fg1.Row, 2)
            DESPLEGAR_VALE()
        End If
    End Sub
    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles btnFinal.Click
        Try
            FrmConciValesCombus.Fg1.Row = FrmConciValesCombus.Fg1.Rows.Count - 1
            TFOLIO.Text = FrmConciValesCombus.Fg1(FrmConciValesCombus.Fg1.Row, 2)
            DESPLEGAR_VALE()

        Catch ex As Exception
        End Try
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

            SQL = "SELECT TOP 500 ISNULL(GV.CVE_VIAJE,'') AS VIAJE, ISNULL(GV.FOLIO,'') AS FOL_VALE, ISNULL(S.CVE_TRACTOR,'') AS UNIDAD, 
                ISNULL(GV.FECHA,'') AS F_VALE, ISNULL(GV.CVE_GAS,'') AS CVE_GAS_V, ISNULL(G.DESCR,'') AS GASOLINERA, ISNULL(GV.LITROS,0) AS LTS, 
                ISNULL(GV.LITROS_REALES,0) AS LTS_REALES, ISNULL(GV.P_X_LITRO,0) AS PRECIO_LTS, ISNULL(GV.ST_VALES,'EDICION') AS ST_VAL, 
                ISNULL(GV.OBS,'') AS OBSER
                FROM GCASIGNACION_VIAJE_VALES GV
                LEFT JOIN GCASIGNACION_VIAJE S ON S.CVE_VIAJE = GV.CVE_VIAJE                
                LEFT JOIN GCGASOLINERAS G ON G.CVE_GAS = GV.CVE_GAS
                WHERE GV.FOLIO = '" & GVFOLIO & "' AND ISNULL(GV.ST_VALES,'') <> 'ACEPTADO'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LtViaje.Text = dr("VIAJE") 'GV.CVE_VIAJE
                        'LtFolio.Text = dr("") 'GV.FOLIO
                        Try
                            FECHA.Value = dr("F_VALE") 'GC.FECHA
                        Catch ex As Exception
                        End Try
                        TCVE_GAS.Text = dr("CVE_GAS_V") 'GV.CVE_GAS
                        LtGas.Text = dr("GASOLINERA") 'G.DESCR
                        Try
                            LtLts_Inic.Text = Format(dr("LTS"), "###,###,##0.000") 'GC.LITROS
                        Catch ex As Exception
                            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        TLTS_REALES.Value = dr("LTS_REALES") 'GV.LITROS_REALES
                        TPRECIO_X_LTS.Value = dr("PRECIO_LTS") 'GV.P_X_LITRO
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
                        CALCULO()

                        If dr("ST_VAL") = "CONCILIADO" Then
                            HABILITAR_DESHABILITAR_CONTROLES(False)
                        Else
                            HABILITAR_DESHABILITAR_CONTROLES(True)
                            TCVE_GAS.Focus()
                        End If

                    Else
                        'MsgBox("Folio inexistente ó se encuentra aceptado, verifique por favor")

                        MessageBox.Show("Folio inexistente ó se encuentra aceptado, verifique por favor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        LIMPIAR()
                    End If
                End Using
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
        Catch ex As Exception
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            TFOLIO.Text = ""
            LtFactorIEPS.Text = ""
            LtViaje.Text = ""
            FECHA.Value = ""
            TCVE_GAS.Text = ""
            LtGas.Text = ""
            LtLts_Inic.Text = ""
            TLTS_REALES.Value = ""
            TPRECIO_X_LTS.Value = ""
            LtIEPS.Text = ""
            LtIVA.Text = ""
            LtSubtotal.Text = ""
            LtTotal.Text = ""
            CboStatus.SelectedIndex = -1
            TObs.Text = ""
            TFOLIO.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmConciValesComEdit_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        F1.Focus()
    End Sub
    Private Sub TFOLIO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TFOLIO.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCVE_GAS.Focus()
        End If
    End Sub
    Private Sub TFOLIO_Validated(sender As Object, e As EventArgs) Handles TFOLIO.Validated
        DESPLEGAR_VALE()
    End Sub
End Class
