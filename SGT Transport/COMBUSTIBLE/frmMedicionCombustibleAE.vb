Imports System.Data.SqlClient
Public Class frmMedicionCombustibleAE
    Private Sub frmMedicionCombustibleAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        Me.KeyPreview = True
        tCVE_UNI.Text = ""
        LtTanque1.Text = ""
        LtTanque2.Text = ""
        LtTanque3.Text = ""
        tCVE_UNI.Tag = ""

        F1.Value = Now

        If Var1 = "Nuevo" Then
            Try
                tCLAVE.Text = GET_MAX("GCMEDICIONCOMBUSTIBLE", "CLAVE")
                tCLAVE.Enabled = False
                tCVE_UNI.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Try
                    SQL = "SELECT M.CLAVE, M.CVE_UNI, M.CVE_OPER, M.CVE_NIVEL1, M.CVE_NIVEL2, M.CVE_NIVEL3, M.STATUS, M.TANQUE1_CM, M.TANQUE2_CM,
                        M.TANQUE3_CM, M.TANQUE1_LT, M.TANQUE2_LT, M.TANQUE3_LT, N.ID_TABLA AS ID_TABLA1, N2.ID_TABLA AS ID_TABLA2,
                        N3.ID_TABLA AS ID_TABLA3, ISNULL(M.LITROS,0) AS LITRO, ISNULL(TIPO_LITROS,-1) AS TIP_LIT
                        FROM GCMEDICIONCOMBUSTIBLE M
                        LEFT JOIN GCNIVELCOMBUSTIBLE N ON N.ALTURA = M.TANQUE1_CM AND N.LITROS = M.TANQUE1_LT
                        LEFT JOIN GCNIVELCOMBUSTIBLE N2 ON N2.ALTURA = M.TANQUE2_CM AND N2.LITROS = M.TANQUE2_LT
                        LEFT JOIN GCNIVELCOMBUSTIBLE N3 ON N3.ALTURA = M.TANQUE3_CM AND N3.LITROS = M.TANQUE3_LT
                        WHERE M.CLAVE = " & Var2
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        tCLAVE.Text = dr("CLAVE").ToString
                        'CAMPO CLAVE NIVEL COMBUSTIBLE
                        'cmd.Parameters.Add("@CVE_NIVEL1", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque1.Tag)
                        'cmd.Parameters.Add("@CVE_NIVEL2", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque2.Tag)
                        'cmd.Parameters.Add("@CVE_NIVEL3", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque3.Tag)
                        'ALTURA
                        'cmd.Parameters.Add("@TANQUE1_CM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtCm1.Text)
                        'cmd.Parameters.Add("@TANQUE2_CM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtCm2.Text)
                        'cmd.Parameters.Add("@TANQUE3_CM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtCm3.Text)
                        'LITROS
                        'cmd.Parameters.Add("@TANQUE1_LT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtTanque1.Text)
                        'cmd.Parameters.Add("@TANQUE2_LT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtTanque2.Text)
                        'cmd.Parameters.Add("@TANQUE3_LT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(LtTanque3.Text)

                        'tLITROS.Text = dr("LITRO")
                        If dr("TIP_LIT") = -1 Then
                        Else
                            'tLITROS.Enabled = False
                            Box3.Enabled = False
                            If dr("TIP_LIT") = 0 Then
                                radEntrada.Checked = True
                            Else
                                radSalida.Checked = True
                            End If
                        End If
                        Try
                            'ALTURA
                            LtCm1.Text = Format(dr("TANQUE1_CM"), "###,###,##0.00")
                            LtCm2.Text = Format(dr("TANQUE2_CM"), "###,###,##0.00")
                            LtCm3.Text = Format(dr("TANQUE3_CM"), "###,###,##0.00")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try


                        If dr("CVE_UNI") <> 0 Then
                            tCVE_UNI.Tag = dr("CVE_UNI")
                            LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Tag)
                            tCVE_UNI.Text = Var4
                            'ID TABLA
                            tTanque1.Text = IIf(LtCm1.Text = "", "", dr("ID_TABLA1").ToString)
                            tTanque2.Text = dr("ID_TABLA2").ToString
                            tTanque3.Text = IIf(LtCm3.Text = "0.00", "", dr("ID_TABLA3").ToString)
                            'CLAVE GCNIVELCOMBUSTIBLE
                            tTanque1.Tag = dr("CVE_NIVEL1").ToString
                            tTanque2.Tag = dr("CVE_NIVEL2").ToString
                            tTanque3.Tag = dr("CVE_NIVEL3").ToString
                            Try
                                'LITROS
                                LtTanque1.Text = Format(dr.ReadNullAsEmptyDecimal("TANQUE1_LT"), "###,###,##0.00")
                                LtTanque2.Text = Format(dr.ReadNullAsEmptyDecimal("TANQUE2_LT"), "###,###,##0.00")
                                LtTanque3.Text = Format(dr.ReadNullAsEmptyDecimal("TANQUE3_LT"), "###,###,##0.00")
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            SUMA_LITROS()
                        End If
                        tCVE_OPER.Text = dr("CVE_OPER").ToString
                        LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
                    End If
                    dr.Close()
                Catch ex As Exception
                    MsgBox("4. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    'If tCVE_UNI.Text.Trim.Length > 0 Then
                    'BUSCAR_NIVEL_UNIDAD(tCVE_UNI.Tag)
                    'end If
                Catch ex As Exception
                    Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                tCLAVE.Enabled = False
                tCVE_UNI.Select()
            Catch ex As Exception
                MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub SUMA_LITROS()
        Try
            LtSuma.Text = CONVERTIR_TO_DECIMAL(LtTanque1.Text) + CONVERTIR_TO_DECIMAL(LtTanque2.Text) + CONVERTIR_TO_DECIMAL(LtTanque3.Text)
        Catch ex As Exception
        End Try
    End Sub
    Sub BUSCAR_NIVEL_UNIDAD(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT " &
                "U.NIVEL, N.ID_TABLA, N.ALTURA, N.LITROS, " &
                "U.NIVEL2, N2.ID_TABLA AS ID_TABLA2, ISNULL(N2.ALTURA,0) AS ALTURA2, ISNULL(N2.LITROS,0) AS LITROS2, " &
                "U.NIVEL3, N3.ID_TABLA AS ID_TABLA3, ISNULL(N3.ALTURA,0) AS ALTURA3, ISNULL(N3.LITROS,0) AS LITROS3 " &
                "FROM GCUNIDADES U " &
                "LEFT JOIN GCNIVELCOMBUSTIBLE N ON N.CLAVE = U.NIVEL " &
                "LEFT JOIN GCNIVELCOMBUSTIBLE N2 ON N2.CLAVE = U.NIVEL2 " &
                "LEFT JOIN GCNIVELCOMBUSTIBLE N3 ON N3.CLAVE = U.NIVEL3 " &
                "WHERE U.CLAVE = '" & tCVE_UNI.Tag & "' AND ISNULL(U.STATUS, 'A') = 'A'"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                LtNivel.Text = dr("NIVEL").ToString
                LtNivel2.Text = dr("NIVEL2").ToString
                LtNivel3.Text = dr("NIVEL3").ToString

                tTanque1.Text = dr("ID_TABLA").ToString
                tTanque2.Text = dr("ID_TABLA2").ToString
                tTanque3.Text = dr("ID_TABLA3").ToString

                LtCm1.Text = dr("ALTURA").ToString
                LtCm2.Text = dr("ALTURA2").ToString
                LtCm3.Text = dr("ALTURA3").ToString

                LtTanque1.Text = dr("LITROS").ToString
                LtTanque2.Text = dr("LITROS2").ToString
                LtTanque3.Text = dr("LITROS3").ToString
                SUMA_LITROS()
            Else
                LtNivel.Text = ""
                LtNivel2.Text = ""
                LtNivel3.Text = ""

                tTanque1.Text = ""
                tTanque2.Text = ""
                tTanque3.Text = ""

                LtCm1.Text = ""
                LtCm2.Text = ""
                LtCm3.Text = ""

                LtTanque1.Text = ""
                LtTanque2.Text = ""
                LtTanque3.Text = ""
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmMedicionCombustibleAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmMedicionCombustibleAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        If Not radEntrada.Checked And Not radSalida.Checked Then
            MsgBox("Por favor seleccione tipo de entrada o salida")
            Return
        End If

        Dim TIPO_LITRO As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If radEntrada.Checked Or radSalida.Checked Then
            If radEntrada.Checked Then
                TIPO_LITRO = 0
            Else
                TIPO_LITRO = 1
            End If
        Else
            TIPO_LITRO = -1
        End If

        SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_UNI = @CVE_UNI, CVE_OPER = @CVE_OPER, FECHA = @FECHA, 
            CVE_NIVEL1 = @CVE_NIVEL1, CVE_NIVEL2 = @CVE_NIVEL2, CVE_NIVEL3 = @CVE_NIVEL3, 
            TANQUE1_CM = @TANQUE1_CM, TANQUE2_CM = @TANQUE2_CM, TANQUE3_CM = @TANQUE3_CM, 
            TANQUE1_LT = @TANQUE1_LT, TANQUE2_LT = @TANQUE2_LT, TANQUE3_LT = @TANQUE3_LT, SUMA = @SUMA, TIPO_LITROS = @TIPO_LITROS 
            WHERE CLAVE = @CLAVE 
            IF @@ROWCOUNT = 0 
            INSERT INTO GCMEDICIONCOMBUSTIBLE (CLAVE, CVE_UNI, CVE_OPER, STATUS, FECHA, FECHAELAB, CVE_NIVEL1, CVE_NIVEL2, CVE_NIVEL3, 
            TANQUE1_CM, TANQUE2_CM, TANQUE3_CM, TANQUE1_LT, TANQUE2_LT, TANQUE3_LT, SUMA, TIPO_LITROS) VALUES(
            @CLAVE, @CVE_UNI, @CVE_OPER, 'A', @FECHA, GETDATE(), @CVE_NIVEL1, @CVE_NIVEL2, @CVE_NIVEL3, @TANQUE1_CM, @TANQUE2_CM, 
            @TANQUE3_CM, @TANQUE1_LT, @TANQUE2_LT, @TANQUE3_LT, @SUMA, @TIPO_LITROS)"
        cmd.CommandText = SQL
        Try
            'tTanque1.Text = Var5   'ID_TABLA
            'LtTanque1.Text = Var6   'LITROS
            'LtCm1.Text = Var7       'ALTURA
            cmd.Parameters.Add("@CLAVE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tCLAVE.Text)
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Tag
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = tCVE_OPER.Text
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
            'CAMPO CLAVE NIVEL COMBUSTIBLE
            cmd.Parameters.Add("@CVE_NIVEL1", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque1.Tag)
            cmd.Parameters.Add("@CVE_NIVEL2", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque2.Tag)
            cmd.Parameters.Add("@CVE_NIVEL3", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTanque3.Tag)
            'ALTURA
            cmd.Parameters.Add("@TANQUE1_CM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtCm1.Text), 4)
            cmd.Parameters.Add("@TANQUE2_CM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtCm2.Text), 4)
            cmd.Parameters.Add("@TANQUE3_CM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtCm3.Text), 4)
            'LITROS
            cmd.Parameters.Add("@TANQUE1_LT", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTanque1.Text), 4)
            cmd.Parameters.Add("@TANQUE2_LT", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTanque2.Text), 4)
            cmd.Parameters.Add("@TANQUE3_LT", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTanque3.Text), 4)
            cmd.Parameters.Add("@SUMA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtSuma.Text), 4)

            cmd.Parameters.Add("@TIPO_LITROS", SqlDbType.SmallInt).Value = TIPO_LITRO

            returnValue = cmd.ExecuteNonQuery().ToString
             If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    If TIPO_LITRO <> -1 Then

                    End If

                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub frmMedicionCombustibleAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btnUni_Click(sender As Object, e As EventArgs) Handles btnUni.Click
        Try
            Var2 = "Unidades"
            Var4 = "1"
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If tCVE_UNI.Tag <> Var4 Then
                    tCVE_UNI.Tag = Var4
                    tCVE_UNI.Text = Var5
                    LtUnidad.Text = Var6

                    BUSCAR_NIVEL_UNIDAD(tCVE_UNI.Tag)
                End If
            End If
        Catch Ex As Exception
            Bitacora("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("51. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub

    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUni_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                Var3 = "1"
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    LtUnidad.Text = DESCR
                    tCVE_UNI.Tag = Var4

                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    LtUnidad.Text = ""
                    tCVE_UNI.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "1"
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5

            End If
        Catch Ex As Exception
            Bitacora("31. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("31. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_OPER_Validated(sender As Object, e As EventArgs) Handles tCVE_OPER.Validated
        Try
            If tCVE_OPER.Text.Trim.Length > 0 And IsNumeric(tCVE_OPER.Text) Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR <> "" Then
                    LtOper.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                    tCVE_OPER.Select()
                End If
            Else
                LtOper.Text = ""
                tCVE_OPER.Text = ""
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnTanque1_Click(sender As Object, e As EventArgs) Handles btnTanque1.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'CLAVE      var4
                'ID_TABLA   var5
                'ALTURA     var6
                'LITROS     var7
                tTanque1.Tag = Var4   'ID_TABLA
                tTanque1.Text = Var5   'ID_TABLA
                LtCm1.Text = Var6       'ALTURA
                LtTanque1.Text = Var7   'LITROS
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tTanque2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnTanque2_Click(sender As Object, e As EventArgs) Handles btnTanque2.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'CLAVE      var4
                'ID_TABLA   var5
                'ALTURA     var6
                'LITROS     var7
                tTanque2.Tag = Var4   'ID_TABLA
                tTanque2.Text = Var5   'ID_TABLA
                LtCm2.Text = Var6       'ALTURA
                LtTanque2.Text = Var7   'LITROS
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tTanque3.Focus()
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnTanque3_Click(sender As Object, e As EventArgs) Handles btnTanque3.Click
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'CLAVE      var4
                'ID_TABLA   var5
                'ALTURA     var6
                'LITROS     var7
                tTanque3.Tag = Var4   'CLAVE NIVEL
                tTanque3.Text = Var5   'ID_TABLA
                LtCm3.Text = Var6       'ALTURA
                LtTanque3.Text = Var7   'LITROS
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tTanque1_KeyDown(sender As Object, e As KeyEventArgs) Handles tTanque1.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tTanque2_KeyDown(sender As Object, e As KeyEventArgs) Handles tTanque2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tTanque3_KeyDown(sender As Object, e As KeyEventArgs) Handles tTanque3.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque3_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tTanque1_Validated(sender As Object, e As EventArgs) Handles tTanque1.Validated
        Try
            If tTanque1.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tTanque1.Text)
                If DESCR <> "N" Then
                    'Var4 = dr("CLAVE").ToString
                    'Var5 = dr("ID_TABLA").ToString
                    'Var6 = dr("LITROS").ToString
                    tTanque1.Tag = Var4
                    LtCm1.Text = DESCR
                    LtTanque1.Text = Var6
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tTanque1.Text = ""
                    tTanque1.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tTanque2_Validated(sender As Object, e As EventArgs) Handles tTanque2.Validated
        Try
            If tTanque2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tTanque2.Text)
                If DESCR <> "N" Then
                    tTanque2.Tag = Var4
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tTanque2.Text = ""
                    tTanque2.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tTanque3_Validated(sender As Object, e As EventArgs) Handles tTanque3.Validated
        Try
            If tTanque3.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Nivel de combustible", tTanque2.Text)
                If DESCR <> "N" Then
                    tTanque2.Tag = Var4
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tTanque2.Text = ""
                    tTanque2.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            msgbox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
