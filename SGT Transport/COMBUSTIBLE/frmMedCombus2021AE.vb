Imports System.Data.SqlClient
Public Class frmMedCombus2021AE
    Private NewRecord As Boolean = False
    Private Sub frmMedCombus2021AE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
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
        F1.Value = Now

        AssignValidation(Me.tTAQ1_CM, ValidationType.Only_Numbers)
        AssignValidation(Me.tTAQ2_CM, ValidationType.Only_Numbers)

        If Var1 = "Nuevo" Then
            Try
                NewRecord = True
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
                    SQL = "SELECT M.CLAVE, M.CVE_UNI, M.CVE_OPER, M.CVE_NIVEL1, M.CVE_NIVEL2, M.CVE_NIVEL3, M.STATUS, M.TANQUE1_CM, M.TANQUE2_CM, " &
                        "M.TANQUE3_CM, M.TANQUE1_LT, M.TANQUE2_LT, M.TANQUE3_LT, N.ID_TABLA AS ID_TABLA1, N2.ID_TABLA AS ID_TABLA2, " &
                        "N3.ID_TABLA AS ID_TABLA3, ISNULL(M.LITROS,0) AS LITRO, ISNULL(TIPO_LITROS,-1) AS TIP_LIT, CVE_TAQ " &
                        "FROM GCMEDICIONCOMBUSTIBLE M " &
                        "LEFT JOIN GCNIVELCOMBUSTIBLE N ON N.CLAVE = M.CVE_NIVEL1 " &
                        "LEFT JOIN GCNIVELCOMBUSTIBLE N2 ON N2.CLAVE = M.CVE_NIVEL2 " &
                        "LEFT JOIN GCNIVELCOMBUSTIBLE N3 ON N3.CLAVE = M.CVE_NIVEL3 " &
                        "WHERE M.CLAVE = " & Var2
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader

                    If dr.Read Then
                        tCLAVE.Text = dr("CLAVE").ToString
                        If dr("TIP_LIT") = -1 Then
                        Else
                            Box3.Enabled = False
                            If dr("TIP_LIT") = 0 Then
                                radEntrada.Checked = True
                            Else
                                radSalida.Checked = True
                            End If
                        End If
                        If dr("CVE_UNI") <> 0 Then
                            tCVE_UNI.Tag = dr("CVE_UNI")
                            LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Tag)
                            tCVE_UNI.Text = Var4
                            'ID TABLA
                            tTanque1.Text = dr("ID_TABLA1").ToString
                            tTanque2.Text = dr("ID_TABLA2").ToString
                            'CLAVE GCNIVELCOMBUSTIBLE
                            tTanque1.Tag = dr("CVE_NIVEL1").ToString
                            tTanque2.Tag = dr("CVE_NIVEL2").ToString
                        End If
                        tCVE_OPER.Text = dr("CVE_OPER").ToString
                        LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
                        tCVE_TAQ.Text = dr.ReadNullAsEmptyInteger("CVE_TAQ")
                        LtTAQ_ANCHO.Text = BUSCA_CAT("Tanques", tCVE_TAQ.Text)

                        CARGAR_DATOS_TANQUES()
                        Try
                            'ALTURA
                            tTAQ1_CM.Text = Format(dr("TANQUE1_CM"), "###,###,##0.00")
                            tTAQ2_CM.Text = Format(dr("TANQUE2_CM"), "###,###,##0.00")
                        Catch ex As Exception
                            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        SUMA_LITROS()

                    End If
                    dr.Close()
                Catch ex As Exception
                    MsgBox("4. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("4. " & ex.Message & vbNewLine & ex.StackTrace)
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
            LtSuma.Text = CONVERTIR_TO_DECIMAL(LtTanque1.Text) + CONVERTIR_TO_DECIMAL(LtTanque2.Text)
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
                'tTanque1.Text = dr("ID_TABLA").ToString
                'tTanque2.Text = dr("ID_TABLA2").ToString

                'LtCm1.Text = dr("ALTURA").ToString
                'LtCm2.Text = dr("ALTURA2").ToString

                'LtTanque1.Text = dr("LITROS").ToString
                'LtTanque2.Text = dr("LITROS2").ToString
                SUMA_LITROS()
            Else
                'tTanque1.Text = ""
                'tTanque2.Text = ""

                'LtCm1.Text = ""
                'LtCm2.Text = ""

                'LtTanque1.Text = ""
                'LtTanque2.Text = ""
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmMedCombus2021AE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
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

        If NewRecord Then
            SQL = "INSERT INTO GCMEDICIONCOMBUSTIBLE (CLAVE, CVE_UNI, CVE_OPER, STATUS, FECHA, FECHAELAB, CVE_NIVEL1, CVE_NIVEL2, TANQUE1_CM, TANQUE2_CM, 
                TANQUE1_LT, TANQUE2_LT, SUMA, TIPO_LITROS, CVE_TAQ) VALUES(ISNULL((SELECT ISNULL(MAX(CLAVE),0) + 1 FROM GCMEDICIONCOMBUSTIBLE),1), 
                @CVE_UNI, @CVE_OPER, 'A', @FECHA, GETDATE(), @CVE_NIVEL1, @CVE_NIVEL2, @TANQUE1_CM, @TANQUE2_CM,
                @TANQUE1_LT, @TANQUE2_LT, @SUMA, @TIPO_LITROS, @CVE_TAQ)"
        Else
            SQL = "UPDATE GCMEDICIONCOMBUSTIBLE SET CVE_UNI = @CVE_UNI, CVE_OPER = @CVE_OPER, FECHA = @FECHA, 
                CVE_NIVEL1 = @CVE_NIVEL1, CVE_NIVEL2 = @CVE_NIVEL2, 
                TANQUE1_CM = @TANQUE1_CM, TANQUE2_CM = @TANQUE2_CM, 
                TANQUE1_LT = @TANQUE1_LT, TANQUE2_LT = @TANQUE2_LT, SUMA = @SUMA, 
                TIPO_LITROS = @TIPO_LITROS, CVE_TAQ = @CVE_TAQ 
                WHERE CLAVE = @CLAVE "
        End If

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
            'ALTURA
            cmd.Parameters.Add("@TANQUE1_CM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tTAQ1_CM.Text), 4)
            cmd.Parameters.Add("@TANQUE2_CM", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tTAQ2_CM.Text), 4)
            'LITROS
            cmd.Parameters.Add("@TANQUE1_LT", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTanque1.Text), 4)
            cmd.Parameters.Add("@TANQUE2_LT", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtTanque2.Text), 4)
            cmd.Parameters.Add("@SUMA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtSuma.Text), 4)
            cmd.Parameters.Add("@TIPO_LITROS", SqlDbType.SmallInt).Value = TIPO_LITRO
            cmd.Parameters.Add("@CVE_TAQ", SqlDbType.SmallInt).Value = tCVE_TAQ.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    Try
                        If IsNumeric(tCVE_TAQ.Text) Then
                            SQL = "UPDATE GCUNIDADES SET CVE_TAQ = " & tCVE_TAQ.Text & " WHERE CLAVEMONTE = '" & tCVE_UNI.Text & "'"
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
                        MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

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

    Private Sub frmMedCombus2021AE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub btnUni_Click(sender As Object, e As EventArgs) Handles btnUni.Click
        Try
            Var2 = "Unidades"
            Var4 = "1"
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'If tCVE_UNI.Tag <> Var4 Then
                tCVE_UNI.Tag = Var4
                tCVE_UNI.Text = Var5
                LtUnidad.Text = Var6
                'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                'Var3 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE
                'Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE
                'Var6 = Fg(Fg.Row, 3).ToString   'DESCR TIPO UNIDAD
                'Var7 = Fg(Fg.Row, 4).ToString   'PLAZAS
                'Var8 = Fg(Fg.Row, 5).ToString   'MARCA UNIDAD
                'Var9 = Fg(Fg.Row, 6).ToString   'CVE_TIPO UNI
                'Var10 = Fg(Fg.Row, 7).ToString   'CVE_TAQ
                tCVE_TAQ.Text = Var10
                CARGAR_DATOS_TANQUES()
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
                    If Var7.Trim.Length > 0 Then
                        tCVE_TAQ.Text = Var7
                        CARGAR_DATOS_TANQUES()
                    End If
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

    Private Sub BtnTAQ_Click(sender As Object, e As EventArgs) Handles BtnTAQ.Click
        Try
            Var2 = "TAQ"
            Var4 = ""
            Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            Var9 = "" : Var10 = "" : Var11 = "" : Var12 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                'Var5 = Fg(Fg.Row, 2) 'ANCHO
                'Var6 = Fg(Fg.Row, 3) 'ALTO
                'Var7 = Fg(Fg.Row, 4) 'PROFUNDIDAD
                'Var8 = Fg(Fg.Row, 5) 'LITROS
                'Var9 = Fg(Fg.Row, 6) 'ANCHO
                'Var10 = Fg(Fg.Row, 7) 'ALTO
                'Var11 = Fg(Fg.Row, 8) 'PROFUNDIDAD
                'Var12 = Fg(Fg.Row, 9) 'LITROS
                tCVE_TAQ.Text = Var4
                LtTAQ_ANCHO.Text = Var5
                LtTAQ_ALTO.Text = Var6
                'LtTAQ_PROFUNDIDAD.Text = Var7
                LtTAQ_CAPACIDAD.Text = Var8

                LtTAQ_ANCHO2.Text = Var9
                LtTAQ_ALTO2.Text = Var10
                'LtTAQ_PROFUNDIDAD2.Text = Var11
                LtTAQ_CAPACIDAD2.Text = Var12

                Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                Var9 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                tTanque1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TAQ_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TAQ.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTAQ_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_TAQ_Validated(sender As Object, e As EventArgs) Handles tCVE_TAQ.Validated
        Try
            If tCVE_TAQ.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tanques", tCVE_TAQ.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    'Var4 = dr("CVE_TAQ") 'CLAVE
                    'Var5 = dr("T1_ANCHO") 'ANCHO
                    'Var6 = dr("T1_ALTO") 'ALTO
                    'Var7 = dr("T1_PROFUNFIDAD") 'PROFUNDIDAD
                    'Var8 = dr("T1_LITROS") 'LITROS
                    'Var9 = dr("T2_ANCHO") 'ANCHO
                    'Var10 = dr("T2_ALTO") 'ALTO
                    'Var11 = dr("T2_PROFUNDIDAD") 'PROFUNDIDAD
                    'Var12 = dr("T2_LITROS") 'LITROS
                    LtTAQ_ANCHO.Text = Var5
                    LtTAQ_ALTO.Text = Var6
                    'LtTAQ_PROFUNDIDAD.Text = Var7
                    'LtTAQ_CAPACIDAD.Text = Var8

                    LtTAQ_ANCHO2.Text = Var9
                    LtTAQ_ALTO2.Text = Var10
                    'LtTAQ_PROFUNDIDAD2.Text = Var11
                    'LtTAQ_CAPACIDAD2.Text = Var12

                    Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                    Var9 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                    tTanque1.Focus()
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TAQ.Text = ""
                    LtTAQ_ANCHO.Text = ""
                    tCVE_TAQ.Select()
                End If
            Else
                LtTAQ_ANCHO.Text = ""
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
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
                'LtTanque1.Text = Var7   'LITROS
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
                tTanque2.Focus()
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
                    'LtTanque1.Text = Var6
                Else
                    MsgBox("Nivel de combustible inexistente")
                    tTanque1.Text = ""
                    tTanque1.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
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
                'LtTanque2.Text = Var7   'LITROS
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tTanque2_KeyDown(sender As Object, e As KeyEventArgs) Handles tTanque2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque2_Click(Nothing, Nothing)
            Return
        End If
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
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTanque3_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Nivel Combustible"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'CLAVE      var4
                'ID_TABLA   var5
                'ALTURA     var6
                'LITROS     var7
                SUMA_LITROS()
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            End If
        Catch Ex As Exception
            Bitacora("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("495. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tTanque3_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            btnTanque3_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tTAQ1_CM_TextChanged(sender As Object, e As EventArgs) Handles tTAQ1_CM.TextChanged
        Dim ANCHO As Decimal, RADIO As Decimal, DIAMETRO As Decimal, CAPACIDAD As Decimal
        Dim PI As Decimal = 3.14159265, C1 As Decimal, C2 As Decimal

        Try

            If tTAQ1_CM.Text.Trim.Length = 0 Then
                LtTanque1.Text = ""
                SUMA_LITROS()
                Return
            End If

            ANCHO = IIf(IsNumeric(LtTAQ_ANCHO.Text), LtTAQ_ANCHO.Text, 0)
            DIAMETRO = IIf(IsNumeric(LtTAQ_ALTO.Text), LtTAQ_ALTO.Text, 0)
            CAPACIDAD = IIf(IsNumeric(LtTAQ_CAPACIDAD.Text), LtTAQ_CAPACIDAD.Text, 0)

            If tTAQ1_CM.Text > 999 Then 'IAMETRO Then
                MsgBox("La altura capturada no puede ser mayor ")
                tTAQ1_CM.Text = ""
                LtTanque1.Text = ""
                SUMA_LITROS()
                Return
            End If
            If ANCHO = 999 Or DIAMETRO = 999 Then
                MsgBox("Por favor seleccione el tipo de tanque o verifique que el tanque tenga capturado su valores")
                tTAQ1_CM.Text = ""
                SUMA_LITROS()
                Return
            End If

            RADIO = DIAMETRO / 2
            RADIO = RADIO * RADIO
            C1 = (PI * RADIO * ANCHO)
            'C1 = 3.14.16 * 4225 * 141 = 1,871,525.28142125
            If IsNumeric(tTAQ1_CM.Text) Then
                RADIO = (tTAQ1_CM.Text / 2)
                RADIO = RADIO * RADIO
                C2 = PI * RADIO * ANCHO
                'C2 = 3.14.16 * 1056.25 * 141 = 467,881.320
                'PI * RADIO * ANCHO/C1 = (PI * RADIO * ANCHO)
                If C1 > 0 Then
                    LtTanque1.Text = Format((C2 / C1) * CAPACIDAD, "###,###,##0.0000")
                End If

                SUMA_LITROS()
            End If

        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tTAQ2_CM_TextChanged(sender As Object, e As EventArgs) Handles tTAQ2_CM.TextChanged
        Try
            Dim ANCHO As Decimal, RADIO As Decimal, DIAMETRO As Decimal, CAPACIDAD As Decimal
            Dim PI As Decimal = 3.14159265, C1 As Decimal, C2 As Decimal

            If tTAQ2_CM.Text.Trim.Length = 0 Then
                LtTanque2.Text = ""
                SUMA_LITROS()
                Return
            End If

            ANCHO = IIf(IsNumeric(LtTAQ_ANCHO2.Text), LtTAQ_ANCHO2.Text, 0)
            DIAMETRO = IIf(IsNumeric(LtTAQ_ALTO2.Text), LtTAQ_ALTO2.Text, 0)
            CAPACIDAD = IIf(IsNumeric(LtTAQ_CAPACIDAD2.Text), LtTAQ_CAPACIDAD2.Text, 0)
            If tTAQ2_CM.Text > 999 Then 'IAMETRO Then
                MsgBox("La altura capturada no puede ser mayor ")
                tTAQ2_CM.Text = ""
                LtTanque2.Text = ""
                SUMA_LITROS()
                Return
            End If
            If ANCHO = 999 Or DIAMETRO = 999 Then
                MsgBox("Por favor seleccione el tipo de tanque o verifique que el tanque tenga capturado su valores")
                tTAQ2_CM.Text = ""
                SUMA_LITROS()
                Return
            End If

            RADIO = (DIAMETRO / 2)
            RADIO = RADIO * RADIO
            C1 = (PI * RADIO * ANCHO)

            If IsNumeric(tTAQ2_CM.Text) Then
                RADIO = (tTAQ2_CM.Text / 2)
                RADIO = RADIO * RADIO
                C2 = PI * RADIO * ANCHO

                '= (PI * RADIO * ANCHO) / (PI * RADIO * ANCHO)
                If C1 > 0 Then
                    LtTanque2.Text = Format((C2 / C1) * CAPACIDAD, "###,###,##0.0000")
                End If

                SUMA_LITROS()

            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_DATOS_TANQUES()
        Try
            If tCVE_TAQ.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tanques", tCVE_TAQ.Text)
                If DESCR <> "N" And DESCR <> "" Then
                    LtTAQ_ANCHO.Text = Var5
                    LtTAQ_ALTO.Text = Var6
                    'LtTAQ_PROFUNDIDAD.Text = Var7
                    LtTAQ_CAPACIDAD.Text = Var8

                    LtTAQ_ANCHO2.Text = Var9
                    LtTAQ_ALTO2.Text = Var10
                    'LtTAQ_PROFUNDIDAD2.Text = Var11
                    LtTAQ_CAPACIDAD2.Text = Var12
                    Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                    Var9 = "" : Var10 = "" : Var11 = "" : Var12 = ""
                    tTanque1.Focus()
                End If
            End If
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCalcTaq1_Click(sender As Object, e As EventArgs) Handles BtnCalcTaq1.Click
        MsgBox(" Tanque1 = = (PI * RADIO * ANCHO) / (PI * RADIO * ANCHO)")
    End Sub

    Private Sub BtnCalcTaq2_Click(sender As Object, e As EventArgs) Handles BtnCalcTaq2.Click
        MsgBox("Tanque2 = (PI * RADIO * ANCHO) / (PI * RADIO * ANCHO)")
    End Sub

    Private Sub BtnSumCalcTanqs_Click(sender As Object, e As EventArgs) Handles BtnSumCalcTanqs.Click
        MsgBox("Suma = Tanque1 + Tanque2")
    End Sub
End Class
