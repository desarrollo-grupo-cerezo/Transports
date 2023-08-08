Imports System.Xml
Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class FrmConciValesUtilitario
    Private SERIE_U As String = ""
    Private FOLIO_U As Long = 1
    Private IsNew As Boolean = False

    Private SERIE_CFDI As String = ""
    Private FOLIO_CFDI As Long = 0
    Private FACTOR_IEPS As Decimal = 0
    Private IEPS_MAGNA As Decimal = 0
    Private IEPS_PREMIUN As Decimal = 0
    Private IEPS_DIESEL As Decimal = 0
    Private EJECUTA_CALCULO As Boolean = False

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmConciValesUtilitario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()
        Try
            FECHA.Value = Date.Today
            FECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.CustomFormat = "dd/MM/yyyy"
            FECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            FECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

            'F1.Value = Date.Today
            F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.CustomFormat = "dd/MM/yyyy"
            F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
            F1.EditFormat.CustomFormat = "dd/MM/yyyy"
            Me.KeyPreview = True

            BtnUnidad.FlatStyle = FlatStyle.Flat
            BtnUnidad.FlatAppearance.BorderSize = 0
            BtnOper.FlatStyle = FlatStyle.Flat
            BtnOper.FlatAppearance.BorderSize = 0
            btnGas.FlatStyle = FlatStyle.Flat
            btnGas.FlatAppearance.BorderSize = 0


        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            TFactor.Value = 0
            SQL = "SELECT * FROM GCPARAMTRANSCG"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        'TFactor.Value = dr.ReadNullAsEmptyDecimal("FACTOR_IEPS")
                        FACTOR_IEPS = dr.ReadNullAsEmptyDecimal("FACTOR_IEPS")
                        IEPS_MAGNA = dr.ReadNullAsEmptyDecimal("IEPS_MAGNA")
                        IEPS_PREMIUN = dr.ReadNullAsEmptyDecimal("IEPS_PREMIUN")
                        IEPS_DIESEL = dr.ReadNullAsEmptyDecimal("IEPS_DIESEL")

                        SERIE_U = dr.ReadNullAsEmptyString("SERIE_UTILITARIOS")
                        FOLIO_U = dr.ReadNullAsEmptyLong("FOLIO_UTILITARIOS") + 1

                    End If
                End Using
            End Using
            TCVE_OPER.Text = ""

            'F1.Clear()
            'FECHA.Clear()
            CboTipoGasolina.Items.Clear()
            CboTipoGasolina.Items.Add("Magna")
            CboTipoGasolina.Items.Add("Premiun")
            CboTipoGasolina.Items.Add("Diesel")

            tCVE_GAS.Text = ""
            LtSubtotal.Text = 0
            LtIVA.Text = 0
            LtIEPS.Text = 0
            LtTotal.Text = 0
            TKM.Value = 0
            'TFACTURA.Text = ""
            tObs.Text = ""
            cboStatus.SelectedIndex = -1

            'LITROS = tLTS_REALES.Value
            'PRECIO = tPRECIO_X_LTS.Value
            'FACTOR_IEPS = TFactor.Value
            'TFactor.Value = 0

        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        LtFolio.Tag = ""

        If Var1 = "Nuevo" Then
            Try
                IsNew = True
                LtFolio.Text = SERIE_U & Format(FOLIO_U, "000000000")
                cboStatus.SelectedIndex = 0
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                LtFolio.Text = Var2

                SQL = "SELECT A.FOLIO, A.CVE_LIQ, ISNULL(A.CVE_TRACTOR,'') AS UNI, A.STATUS, ISNULL(A.CVE_OPER, 0) AS C_OPER, 
                    ISNULL(A.FECHA,'') AS FECH, ISNULL(A.ST_VALES,'') AS STA_VAL, ISNULL(A.CVE_GAS,'') AS C_GAS, ISNULL(A.LTS_INICIALES,0) AS LTS_INI, 
                    ISNULL(A.LITROS_REALES,0) AS LTS_REAL, ISNULL(A.P_X_LITRO,0) AS P_X_LTR, ISNULL(A.SUBTOTAL,0) AS SUBTOT, ISNULL(A.IVA,0) AS IV, 
                    ISNULL(A.IEPS,0) AS IEP, ISNULL(A.IMPORTE,0) AS IMPORT, ISNULL(A.FACTURA,'') AS FAC, ISNULL(A.FACTURA_CFDI,'') AS FAC_CFDI, 
                    ISNULL(A.OBS,'') AS OB, ISNULL(A.FECHA_CARGA,'') AS FEC_CAR, ISNULL(CVE_TIPO_GAS,-1) AS CVETIPOGAS, ISNULL(FACTOR_IEPS,0) AS FAC_IEPS, 
                    ISNULL(XML,'') AS XMLU, ISNULL(A.FECHA_CFDI, '') AS FECH_CFDI, ISNULL(KM,0) As KMS
                    FROM GCASIGNACION_VALES_UTIL A 
                    WHERE A.FOLIO = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then

                    LtFolio.Tag = dr("XMLU")

                    If dr("XMLU").ToString.Trim.Length > 0 Then
                        LtXML.Text = Path.GetFileName(dr("XMLU"))
                    End If

                    tCVE_TRACTOR.Text = dr("UNI")
                    LtTractor.Text = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)
                    TCVE_OPER.Text = dr("C_OPER").ToString
                    If TCVE_OPER.Text = "0" Then
                        TCVE_OPER.Text = ""
                    End If
                    LtOper.Text = BUSCA_CAT("Operador", TCVE_OPER.Text)

                    If IsDate(dr("FECH")) Then
                        FECHA.Value = dr("FECH")
                    Else
                        FECHA.Clear()
                    End If


                    tCVE_GAS.Text = dr("C_GAS").ToString
                    LtGas.Text = BUSCA_CAT("Gasolinera", tCVE_GAS.Text)

                    TFactor.Value = dr("FAC_IEPS")
                    Try
                        If TFactor.Value = 0 Then
                            TFactor.Value = FACTOR_IEPS
                        End If
                    Catch ex As Exception
                    End Try
                    tLTS_INICIALES.Value = dr.ReadNullAsEmptyDecimal("LTS_INI")
                    TPRECIO_X_LTS.Value = dr.ReadNullAsEmptyDecimal("P_X_LTR")

                    tLTS_REALES.Value = dr.ReadNullAsEmptyDecimal("LTS_REAL")
                    LtSubtotal.Text = Format(dr.ReadNullAsEmptyDecimal("SUBTOT"), "###,###,##0.00")
                    LtIVA.Text = Format(dr.ReadNullAsEmptyDecimal("IV"), "###,###,##0.00")
                    LtIEPS.Text = Format(dr.ReadNullAsEmptyDecimal("IEP"), "###,###,##0.00")
                    LtTotal.Text = Format(dr.ReadNullAsEmptyDecimal("IMPORT"), "###,###,##0.00")

                    Try
                        'TFACTURA.Text = dr("FAC")
                        LtFAC_CFDI.Text = dr("FAC_CFDI")

                        LtFECHA_CFDI.Text = Format(CDate(dr("FECH_CFDI")), "dd/MM/yyyy")

                        If LtFECHA_CFDI.Text = "01/01/1900" Then
                            LtFECHA_CFDI.Text = ""
                        Else
                            LtFECHA_CFDI.Text = dr("FECH_CFDI")
                        End If

                        TKM.Value = dr("KMS")
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    tObs.Text = dr("OB")

                    F1.Value = dr("FEC_CAR")

                    Select Case dr("STA_VAL")
                        Case "EDICION"
                            cboStatus.SelectedIndex = 0
                        Case "CAPTURADO"
                            cboStatus.SelectedIndex = 1
                        Case "ACEPTADO"
                            cboStatus.SelectedIndex = 2
                        Case Else
                            cboStatus.SelectedIndex = 0
                    End Select
                    If dr("STA_VAL") = "CONCILIADO" Then
                        Lt1.Text = "CONCILIADO"
                        Lt1.Visible = True
                        cboStatus.Visible = False
                        Lt2.Visible = False
                    End If
                    Select Case dr("CVETIPOGAS")
                        Case 0
                            CboTipoGasolina.SelectedIndex = 0
                        Case 1
                            CboTipoGasolina.SelectedIndex = 1
                        Case 2
                            CboTipoGasolina.SelectedIndex = 2
                    End Select
                End If
                dr.Close()

                If cboStatus.SelectedIndex = 1 Or cboStatus.SelectedIndex = 2 Then
                    SET_ALL_CONTROL_READ_AND_ENABLED(Me)
                    'TFACTURA.Enabled = True
                End If
                If Var24 = "CONCILIADO" Then
                    SET_ALL_CONTROL_READ_AND_ENABLED(Me)
                    BarGrabar.Enabled = False
                End If

                CALCULO()


            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        EJECUTA_CALCULO = True

        'TFACTURA.Select()
    End Sub
    Private Sub FrmConciValesUtilitario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim LITROS As Single = 0, P_X_LITRO As Single = 0, LITROS_REALES As Decimal, SUBTOTAL As Single = 0, IVA As Single = 0, IEPS As Single = 0
        Dim IMPORTE As Single = 0, OBS As String = "", XML As String, UUID_XML As String, FECHA_CFDI As Date
        Dim CVE_UTIL As String = ""

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If tCVE_GAS.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la gasolinera")
                tCVE_GAS.Select()
                Return
            End If

            If IsNothing(TFactor.Value) Then
                TFactor.Value = 0
            End If

            XML = LtFolio.Tag
            If XML.Length > 255 Then
                XML = XML.Substring(0, 255)
            End If
            TFactor.UpdateValueWithCurrentText()
            TKM.UpdateValueWithCurrentText()
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            LITROS_REALES = tLTS_REALES.Text
            P_X_LITRO = TPRECIO_X_LTS.Text
            SUBTOTAL = LtSubtotal.Text.Replace(",", "")
            IVA = LtIVA.Text.Replace(",", "")
            IEPS = LtIEPS.Text.Replace(",", "")
            IMPORTE = LtTotal.Text.Replace(",", "")
            OBS = tObs.Text

            If IsNothing(F1.Value) Then
                F1.Value = "01/01/1900"
            End If
            If IsDBNull(F1.Value) Then
                F1.Value = "01/01/1900"
            End If
            FECHA_CFDI = F1.Value
            If LtFECHA_CFDI.Text.Trim.Length > 0 Then
                If IsDate(LtFECHA_CFDI.Text) Then
                    FECHA_CFDI = LtFECHA_CFDI.Text
                End If
            End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try

            If IsNew Then

                Try
                    Dim SIGUE As Boolean = True

                    Do While SIGUE
                        CVE_UTIL = SERIE_U & Format(FOLIO_U, "000000000")

                        If EXIST_VALE_UTILITARIOS(CVE_UTIL) Then
                            FOLIO_U = FOLIO_U + 1
                        Else
                            SIGUE = False
                        End If
                    Loop
                Catch ex As Exception
                    BITACORACFDI("410. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
                    Return
                End Try

                SQL = "INSERT INTO GCASIGNACION_VALES_UTIL (FOLIO, CVE_TRACTOR, CVE_OPER, FECHA, ST_VALES, CVE_GAS, LTS_INICIALES, 
                    LITROS_REALES, P_X_LITRO, SUBTOTAL, IVA, IEPS, IMPORTE, FACTURA_CFDI, FECHA_CFDI, OBS, FECHA_CARGA, CVE_TIPO_GAS, 
                    FACTOR_IEPS, XML, KM, FECHAELAB, UUID) VALUES (@FOLIO, @CVE_TRACTOR, @CVE_OPER,  @FECHA, @ST_VALES, @CVE_GAS, 
                    @LTS_INICIALES, @LITROS_REALES, @P_X_LITRO, @SUBTOTAL, @IVA, @IEPS, @IMPORTE, @FACTURA_CFDI, @FECHA_CFDI, 
                    @OBS, @FECHA_CARGA, @CVE_TIPO_GAS, @FACTOR_IEPS, @XML, @KM, GETDATE(), NEWID())"
            Else

                CVE_UTIL = LtFolio.Text
                
                SQL = "UPDATE GCASIGNACION_VALES_UTIL SET CVE_OPER = @CVE_OPER, CVE_TRACTOR = @CVE_TRACTOR, FECHA = @FECHA, ST_VALES = @ST_VALES, 
                    CVE_GAS = @CVE_GAS, LTS_INICIALES = @LTS_INICIALES, LITROS_REALES = @LITROS_REALES, P_X_LITRO = @P_X_LITRO, SUBTOTAL = @SUBTOTAL, 
                    IVA = @IVA, IEPS = @IEPS, IMPORTE = @IMPORTE, FACTURA_CFDI = @FACTURA_CFDI, OBS = @OBS, FECHA_CARGA = @FECHA_CARGA,
                    CVE_TIPO_GAS = @CVE_TIPO_GAS, FACTOR_IEPS = @FACTOR_IEPS, XML = @XML, FECHA_CFDI = @FECHA_CFDI, KM = @KM
                    WHERE FOLIO = @FOLIO"
            End If

            For k = 1 To 5
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = CVE_UTIL
                        cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = tCVE_TRACTOR.Text
                        cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_OPER.Text)
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FECHA.Value
                        cmd.Parameters.Add("@ST_VALES", SqlDbType.VarChar).Value = cboStatus.Text
                        cmd.Parameters.Add("@CVE_GAS", SqlDbType.VarChar).Value = tCVE_GAS.Text
                        cmd.Parameters.Add("@LTS_INICIALES", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tLTS_INICIALES.Text), 4)
                        cmd.Parameters.Add("@LITROS_REALES", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tLTS_REALES.Text), 4)
                        cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRECIO_X_LTS.Text), 4)
                        cmd.Parameters.Add("@SUBTOTAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtSubtotal.Text), 4)
                        cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtIVA.Text), 4)
                        cmd.Parameters.Add("@IEPS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtIEPS.Text), 4)
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTotal.Text), 4)
                        cmd.Parameters.Add("@FACTURA_CFDI", SqlDbType.VarChar).Value = LtFAC_CFDI.Text
                        cmd.Parameters.Add("@FECHA_CFDI", SqlDbType.DateTime).Value = FECHA_CFDI
                        cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = tObs.Text
                        cmd.Parameters.Add("@FECHA_CARGA", SqlDbType.Date).Value = F1.Value
                        cmd.Parameters.Add("@CVE_TIPO_GAS", SqlDbType.SmallInt).Value = CboTipoGasolina.SelectedIndex
                        cmd.Parameters.Add("@FACTOR_IEPS", SqlDbType.Float).Value = TFactor.Value
                        cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = LtFolio.Tag
                        cmd.Parameters.Add("@KM", SqlDbType.Float).Value = TKM.Value
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Exit For
                            End If
                        End If
                    End Using
                Catch ex As Exception
                    Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                If Not Valida_Conexion() Then
                    Return
                End If
                FOLIO_U += 1
                CVE_UTIL = SERIE_U & Format(FOLIO_U, "000000000")
            Next

            Try
                If IsNew Then
                    Try
                        SQL = "UPDATE GCPARAMTRANSCG SET FOLIO_UTILITARIOS = " & FOLIO_U
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                'GRABANDO XML
                Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String

                ARCHIVO = LtFolio.Tag.ToString
                FILE_XML = Path.GetFileName(ARCHIVO)

                If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                    RUTA_XML = OBTENER_RUTA_XML()
                    If RUTA_XML.Trim.Length = 0 Then
                        RUTA_XML = Application.StartupPath
                    End If

                    RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                    UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                    SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                        WHERE TIPO_DOC = 'VH' AND CVE_DOC = '" & LtFolio.Text & "'
                        IF @@ROWCOUNT = 0
                        INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) 
                        VALUES(
                        ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1),'VH','" & LtFolio.Text & "','" &
                        "CONCI. VALES UTILITARIOS','" & UUID_XML & "','" & FILE_XML & "',NEWID())"

                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    FileCopy(ARCHIVO, RUTA_XML & "\" & FILE_XML)
                                Catch ex As Exception
                                    Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    End Using
                Else
                    MsgBox("Por favor seleccione el XML")
                End If
            Catch ex As Exception
                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MsgBox("Los datos se grabaron satisfactoriamente")
            Me.Close()
        Catch ex As Exception
            Bitacora("53. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("53. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnUnidad_Click(sender As Object, e As EventArgs) Handles BtnUnidad.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = "1"
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                tCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                TCVE_OPER.Focus()
            End If

        Catch Ex As Exception
            Bitacora("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("160. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidad_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = Keys.Up Then
            tObs.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            TCVE_OPER.Focus()
        End If
        If e.KeyCode = 13 Then
            TCVE_OPER.Focus()
        End If
    End Sub
    Private Sub tCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles tCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If tCVE_TRACTOR.Text.Length > 0 Then
                Var4 = "" : Var3 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Unidad utilitaria inexistente")
                    LtTractor.Text = ""
                End If
            Else
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("95. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
                tCVE_GAS.Focus()
            Else
                TCVE_OPER.Text = ""
                LtOper.Text = ""
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
        If e.KeyCode = 13 Then
            tCVE_GAS.Focus()
        End If
    End Sub
    Private Sub TCVE_OPER_Validated(sender As Object, e As EventArgs) Handles TCVE_OPER.Validated
        Try
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
                    tCVE_GAS.Select()
                End If
            Else
                LtOper.Text = ""
            End If
        Catch ex As Exception
            Bitacora("82. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("82. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnGas_Click(sender As Object, e As EventArgs) Handles btnGas.Click
        Try
            Var2 = "Gasolinera"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_GAS.Text = Var4
                LtGas.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                CboTipoGasolina.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_GAS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_GAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnGas_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            TFactor.Focus()
        End If
    End Sub
    Private Sub tCVE_GAS_Validated(sender As Object, e As EventArgs) Handles tCVE_GAS.Validated
        Try
            Dim DESCR As String
            If tCVE_GAS.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Gasolinera", tCVE_GAS.Text)
                If DESCR <> "" Then
                    Var3 = ""
                    LtGas.Text = DESCR
                Else
                    MsgBox("Gasolinera inexistente")
                    tCVE_GAS.Text = ""
                    LtGas.Text = ""
                End If
            Else
                tCVE_GAS.Text = ""
                LtGas.Text = ""
            End If
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tPRECIO_X_LTS_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_X_LTS.TextChanged
        CALCULO()
    End Sub
    Private Sub tLTS_REALES_TextChanged(sender As Object, e As EventArgs) Handles tLTS_REALES.TextChanged
        CALCULO()
    End Sub
    Sub CALCULO()
        Dim PRECIO_SIN_IEPS As Decimal = 0, SUBTOTAL1 As Decimal, IEPS As Decimal = 0, PRECIO As Decimal, LITROS As Single = 0
        Dim IVA As Decimal = 0, FACTOR_IEPS As Decimal

        If EJECUTA_CALCULO Then
            Try
                If Not IsNothing(tLTS_REALES.Text) Then
                    If IsDBNull((tLTS_REALES.Text)) Then
                        LITROS = 0
                    Else
                        If IsNumeric(tLTS_REALES.Text) Then
                            LITROS = tLTS_REALES.Text
                        End If
                    End If
                Else
                    LITROS = 0
                End If

                If Not IsNothing(TPRECIO_X_LTS.Text) Then
                    If IsNumeric(TPRECIO_X_LTS.Text) Then
                        PRECIO = TPRECIO_X_LTS.Text
                    End If
                Else
                    PRECIO = 0
                End If

                If Not IsNothing(TFactor.Text) Then
                    If IsNumeric(TFactor.Text) Then
                        FACTOR_IEPS = TFactor.Text
                    End If
                End If

                IEPS = LITROS * FACTOR_IEPS

                IVA = (((PRECIO * LITROS) - (LITROS * FACTOR_IEPS)) / 1.16) * 0.16
                SUBTOTAL1 = (((PRECIO * LITROS) - (LITROS * FACTOR_IEPS)) / 1.16)

                LtSubtotal.Text = Format(SUBTOTAL1, "###,###,##0.00")
                LtIVA.Text = Format(IVA, "###,###,##0.00")
                LtIEPS.Text = Format(IEPS, "###,###,##0.00")
                LtTotal.Text = Format(SUBTOTAL1 + IEPS + IVA, "###,###,##0.00")

                PRECIO = 0
            Catch ex As Exception
                Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

    End Sub
    Private Sub cboStatus_Enter(sender As Object, e As EventArgs) Handles cboStatus.Enter, C1ComboBox1.Enter
        Try
            If tCVE_GAS.Text.Trim.Length = 0 Then
                MsgBox("Por favor capture la gasolinera")
                tCVE_GAS.Select()
                Return
            End If
            If Not IsNumeric(tLTS_REALES.Text) Then
                MsgBox("Por favor capture los litros reales")
                tLTS_REALES.Select()
                Return
            End If
            If CDec(tLTS_REALES.Text) <= 0 Then
                MsgBox("Por favor capture los litros reales")
                tLTS_REALES.Select()
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
        Catch ex As Exception
            Bitacora("505. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("505. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TFACTURA_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            tObs.Focus()
        End If
    End Sub

    Private Sub tLTS_INICIALES_KeyDown(sender As Object, e As KeyEventArgs) Handles tLTS_INICIALES.KeyDown
        If e.KeyCode = 13 Then
            tLTS_REALES.Focus()
        End If
    End Sub

    Private Sub tLTS_REALES_KeyDown(sender As Object, e As KeyEventArgs) Handles tLTS_REALES.KeyDown
        If e.KeyCode = 13 Then
            TPRECIO_X_LTS.Focus()
        End If
    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Try
            Dim RUTA_FORMATOS As String
            Dim FOLIO As String

            FOLIO = LtFolio.Text

            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportValesUtilitarios.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportValesUtilitarios.mrt, verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS & "\ReportValesUtilitarios.mrt")
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("FOLIO") = FOLIO
            StiReport1.Render()
            StiReport1.Show()

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_GAS_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_GAS.PreviewKeyDown
        If e.KeyCode = 9 Then
            TFactor.Focus()
        End If
    End Sub

    Private Sub CboTipoGasolina_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboTipoGasolina.DropDownClosed
        Try
            Select Case CboTipoGasolina.SelectedIndex
                Case 0
                    TFactor.Value = IEPS_MAGNA
                Case 1
                    TFactor.Value = IEPS_PREMIUN
                Case 2
                    TFactor.Value = IEPS_DIESEL
            End Select

            TFactor.Focus()
        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboTipoGasolina_KeyDown(sender As Object, e As KeyEventArgs) Handles CboTipoGasolina.KeyDown
        Try
            TFactor.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TFactor_KeyDown(sender As Object, e As KeyEventArgs) Handles TFactor.KeyDown
        Try
            If e.KeyCode = 13 Then
                tLTS_INICIALES.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub CboTipoGasolina_SelectedItemChanged(sender As Object, e As EventArgs) Handles CboTipoGasolina.SelectedItemChanged
        Try

        Catch ex As Exception
            Bitacora("630. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("630. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarAjuntarXML_Click(sender As Object, e As ClickEventArgs) 
        Try
            Var2 = ""
            Var3 = ""
            Var25 = LtFolio.Tag
            frmAdjuntarXML.ShowDialog()

            LtFolio.Tag = Var25 'RUTA Y NOMBRE XML
            LtXML.Text = Var25
            SERIE_CFDI = Var2
            LtFAC_CFDI.Text = Var2 & Var3
            LtFECHA_CFDI.Text = Var4

            If IsNumeric(Var3) Then
                FOLIO_CFDI = Var3
            Else
                FOLIO_CFDI = 0
            End If

        Catch ex As Exception
            Bitacora("409. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function OBTENER_UUID_XML(fFILE_XML As String) As String
        Dim strTipoComprobante As String
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
        Dim strEmisorCalle As String
        Dim strEmisorNoExterior As String
        Dim strEmisorNoInterior As String
        Dim strEmisorColonia As String
        Dim strEmisorMunicipio As String
        Dim strEmisorEstado As String
        Dim strUsoCFDI As String

        Dim strRegimen As String
        Dim strDescuento As String
        Dim strNumCtaPago As String
        Dim strVersion As String
        Dim NoCertificadoSAT As String
        Dim UUID As String
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

        strEmisorNombre = "" : strFechaEmision = "" : strEmisorCalle = "" : strEmisorMunicipio = "" : strEmisorEstado = ""
        strEmisorNoExterior = "" : strEmisorNoInterior = "" : strEmisorColonia = "" : strFormaPago = "" : strMetodoPago = ""
        strSubtotal = "" : strTotal = "" : strEmisorRfc = "" : strFolio = "" : strDescuento = "0" : strNumCtaPago = ""
        strSerie = "" : strVersionTimbre = "" : UUID = "" : FechaTimbrado = "" : NoCertificadoSAT = "" : strTipoComprobante = "" : strUsoCFDI = ""
        strReceptorRfc = "" : UUIDR = ""

        NumOperacion = "" : Monto = "" : FormaDePagoP = "" : FechaPago = ""
        Folio = "" : Serie = "" : ImpSaldoInsoluto = "" : ImpPagado = "" : ImpSaldoAnt = "" : NumParcialidad = "" : MetodoDePagoDR = "" : IdDocumento = ""

        xDoc = New XmlDocument

        Try
            XML = fFILE_XML

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
                            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("90. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
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
                        Bitacora("91. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        Bitacora("92. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        xNodo = xDoc.GetElementsByTagName("cfdi:Emisor")
                        If xNodo.Count > 0 Then
                            For Each xAtt In xNodo
                                strReceptorRfc = VarXml(xAtt, "Rfc")
                                'LtRFC.Text = strReceptorRfc
                            Next
                        End If
                    Catch ex As Exception
                        Bitacora("93. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        Bitacora("94. " & ex.Message & vbNewLine & ex.StackTrace)
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
                        Bitacora("95. " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("96.x " & ex.Message & vbNewLine & ex.StackTrace)
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
                            Bitacora("97.x " & ex.Message & vbNewLine & ex.StackTrace)
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
                    Bitacora("99. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            Return UUID
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & "ex.StackTrace: " & ex.StackTrace)
            Return UUID
        End Try
    End Function
    Private Function VarXml(ByRef xAtt As XmlElement, ByVal strVar As String) As String
        VarXml = xAtt.GetAttribute(strVar)
        If VarXml = Nothing Then VarXml = ""
    End Function

    Private Sub TPRECIO_X_LTS_KeyDown(sender As Object, e As KeyEventArgs) Handles TPRECIO_X_LTS.KeyDown
        If e.KeyCode = 13 Then
            tObs.Focus()
        End If
    End Sub

    Private Sub BarGrabarXML_Click(sender As Object, e As ClickEventArgs) 

        Try
            SQL = "UPDATE GCASIGNACION_VALES_UTIL SET XML = @XML, FACTURA_CFDI = @FACTURA_CFDI WHERE FOLIO = @FOLIO"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = LtFolio.Text
                    cmd.Parameters.Add("@FACTURA_CFDI", SqlDbType.VarChar).Value = LtFAC_CFDI.Text
                    cmd.Parameters.Add("@XML", SqlDbType.VarChar).Value = LtXML.Text
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using

            Catch ex As Exception
                Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            '==================================================================================
            'GRABANDO XML
            Dim RUTA_XML As String, ARCHIVO As String, RUTA_ACTUAL As String, FILE_XML As String, UUID_XML As String

            ARCHIVO = LtXML.Text
            FILE_XML = Path.GetFileName(ARCHIVO)

            If ARCHIVO.Trim.Length > 0 And FILE_XML.Trim.Length > 0 Then

                RUTA_XML = OBTENER_RUTA_XML()
                If RUTA_XML.Trim.Length = 0 Then
                    RUTA_XML = Application.StartupPath
                End If

                RUTA_ACTUAL = Path.GetDirectoryName(ARCHIVO)
                UUID_XML = OBTENER_UUID_XML(ARCHIVO)

                SQL = "UPDATE GCCOMPRAS SET UUID_XML = '" & UUID_XML & "', ARCHIVO_XML = '" & FILE_XML & "' 
                    WHERE TIPO_DOC = 'VH' AND CVE_DOC = '" & LtFolio.Text & "'
                    IF @@ROWCOUNT = 0
                    INSERT INTO GCCOMPRAS (NUM_REG, TIPO_DOC, CVE_DOC, MODULO, UUID_XML, ARCHIVO_XML, UUID) 
                    VALUES(
                    ISNULL((SELECT MAX(NUM_REG) + 1 FROM GCCOMPRAS),1), 'VH','" & LtFolio.Text & "','" &
                    "CONCI. VALES UTILITARIOS','" & UUID_XML & "','" & FILE_XML & "',NEWID())"

                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            Try
                                FileCopy(ARCHIVO, RUTA_XML & "\" & FILE_XML)

                                MsgBox("El xml se grabo correctamente")
                            Catch ex As Exception
                                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    End If
                End Using

            Else
                MsgBox("Por favor seleccione el archivo XML")
            End If
        Catch ex As Exception
            Bitacora("235. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
            MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
