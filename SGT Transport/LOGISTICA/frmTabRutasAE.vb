Imports System.Data.SqlClient
Imports C1.Win.C1Input

Public Class frmTabRutasAE
    Private Sub frmTabRutasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        LtCOSTO_CASETAS.Text = 0
        tFLETE.Value = 0
        tSUELDO_OPER.Value = 0
        tRENDIMIENTO.Value = 0
        tP_X_LITRO.Value = 0
        tLITROS_RUTA.Text = ""
        tCOSTO_DISEL.Text = ""
        tCVE_PLAZA.Tag = ""
        LtPlaza.Tag = ""
        tCVE_PLAZA2.Tag = ""
        LtPlaza2.Tag = ""

        If Var1 = "Nuevo" Then
            Try
                tCVE_TAB.Text = GET_MAX("GCTAB_RUTAS", "CVE_TAB")
                tCVE_TAB.Enabled = False
                tCLIENTE.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                '"LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA " &
                '"LEFT JOIN GCPLAZAS P1 On P1.CLAVE = D.CVE_PLA1 " &
                '"LEFT JOIN GCPLAZAS P2 On P2.CLAVE = D.CVE_PLA2 " &

                SQL = "SELECT T.CVE_TAB, T.FECHA, T.TIPO_UNI, D.CVE_RUTA, T.ORIGEN, T.DESTINO, P1.CIUDAD AS ORIG, P2.CIUDAD AS DEST, T.CLIENTE, 
                    ISNULL(T.KM_RECO, 0) AS K_RECO, ISNULL(T.COSTO_CASETAS, 0) AS C_CASETAS, ISNULL(T.FLETE,0) AS FLET, ISNULL(T.SUELDO_OPER,0) AS S_OPER,    
                    ISNULL(T.RENDIMIENTO,0) AS RENDI, ISNULL(T.P_X_LITRO,'0') AS P_X_L, ISNULL(T.LITROS_RUTA,0) AS L_RUTA, ISNULL(T.COSTO_DISEL,0) AS C_DISEL,
                    ISNULL(T.TIPO_VIAJE,0) AS T_VIAJE, ISNULL(T.EJES,0) AS EJE, ISNULL(P1.STATUS,'A') AS ST_PLAZA, ISNULL(P2.STATUS,'A') AS ST_PLAZA2,
                    ISNULL(T.OBSER,'') AS OBS
                    FROM GCTAB_RUTAS T
                    LEFT JOIN GCDETALLE_RUTAS D ON D.CVE_RUTA = T.CVE_RUTA
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = T.ORIGEN
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = T.DESTINO
                    WHERE CVE_TAB = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_TAB.Text = dr("CVE_TAB").ToString
                    F1.Value = dr("FECHA").ToString
                    If dr("TIPO_UNI").ToString = "1" Then
                        radFull.Checked = True
                    Else
                        radSencillo.Checked = True
                    End If

                    tCVE_PLAZA.Text = dr("ORIGEN").ToString
                    tCVE_PLAZA.Tag = dr("ST_PLAZA").ToString
                    LtPlaza.Text = dr("ORIG").ToString
                    LtPlaza.Tag = tCVE_PLAZA.Text

                    tCVE_PLAZA2.Text = dr("DESTINO").ToString
                    tCVE_PLAZA2.Tag = dr("ST_PLAZA2").ToString
                    LtPlaza2.Text = dr("DEST").ToString 'Var4
                    LtPlaza2.Tag = tCVE_PLAZA2.Text

                    tCLIENTE.Text = dr("CLIENTE").ToString
                    LtCliente.Text = BUSCA_CAT("Cliente operativo", tCLIENTE.Text)

                    tKM_RECORRIDOS.Text = Format(Val(dr("K_RECO")), "###,###,##0.00")
                    LtCOSTO_CASETAS.Text = Format(Val(dr("C_CASETAS")), "###,###,##0.00")
                    tCOSTO_CASETAS.Text = Format(Val(dr("C_CASETAS")), "###,###,##0.00")

                    tFLETE.Value = dr("FLET").ToString
                    tSUELDO_OPER.Value = dr("S_OPER").ToString
                    tRENDIMIENTO.Value = dr("RENDI").ToString
                    tP_X_LITRO.Value = dr("P_X_L").ToString
                    tLITROS_RUTA.Text = dr("L_RUTA").ToString
                    tCOSTO_DISEL.Text = dr("C_DISEL").ToString
                    TEJES.Text = dr("EJE").ToString
                    If dr("T_VIAJE").ToString Then
                        radCargado.Checked = True
                    Else
                        radVacio.Checked = True
                    End If
                    Try
                        tCOSTO_DISEL.Text = Format(tLITROS_RUTA.Text * tP_X_LITRO.Value, "###,###,##0.00")
                        TOBSER.Text = dr("OBS")
                    Catch ex As Exception
                    End Try
                End If
                dr.Close()

                tCVE_TAB.Enabled = False
                tCLIENTE.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmTabRutasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmTabRutasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCTAB_RUTAS SET TIPO_UNI = @TIPO_UNI, CLIENTE = @CLIENTE,  KM_RECO = @KM_RECO, COSTO_CASETAS = @COSTO_CASETAS, 
            FLETE = @FLETE, SUELDO_OPER = @SUELDO_OPER, RENDIMIENTO = @RENDIMIENTO, P_X_LITRO = @P_X_LITRO, LITROS_RUTA = @LITROS_RUTA, 
            COSTO_DISEL = @COSTO_DISEL, TIPO_VIAJE = @TIPO_VIAJE, EJES = @EJES, ORIGEN = @ORIGEN, DESTINO = @DESTINO, OBSER = @OBSER
            WHERE CVE_TAB = @CVE_TAB 
            IF @@ROWCOUNT = 0 
            INSERT INTO GCTAB_RUTAS (CVE_TAB, STATUS, FECHA, TIPO_UNI, CLIENTE, ORIGEN, DESTINO, KM_RECO, COSTO_CASETAS, FLETE, SUELDO_OPER, RENDIMIENTO, 
            P_X_LITRO, LITROS_RUTA, COSTO_DISEL, TIPO_VIAJE, OBSER, UUID) VALUES(@CVE_TAB, 'A', @FECHA, @TIPO_UNI, @CLIENTE, @ORIGEN, @DESTINO, @KM_RECO,
            @COSTO_CASETAS, @FLETE, @SUELDO_OPER, @RENDIMIENTO, @P_X_LITRO, @LITROS_RUTA, @COSTO_DISEL, @TIPO_VIAJE, @OBSER, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_TAB.Text)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now
            cmd.Parameters.Add("@TIPO_UNI", SqlDbType.Int).Value = IIf(radFull.Checked, 1, 0)
            cmd.Parameters.Add("@ORIGEN", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PLAZA.Text)
            cmd.Parameters.Add("@DESTINO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PLAZA2.Text)
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = tCLIENTE.Text
            cmd.Parameters.Add("@KM_RECO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tKM_RECORRIDOS.Text), 4)
            cmd.Parameters.Add("@COSTO_CASETAS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(LtCOSTO_CASETAS.Text), 4)
            cmd.Parameters.Add("@FLETE", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tFLETE.Text), 4)
            cmd.Parameters.Add("@SUELDO_OPER", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tSUELDO_OPER.Text), 4)
            cmd.Parameters.Add("@RENDIMIENTO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tRENDIMIENTO.Text), 4)
            cmd.Parameters.Add("@P_X_LITRO", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tP_X_LITRO.Text), 4)
            cmd.Parameters.Add("@LITROS_RUTA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tLITROS_RUTA.Text), 4)
            cmd.Parameters.Add("@COSTO_DISEL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(tCOSTO_DISEL.Text), 4)
            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Int).Value = IIf(radCargado.Checked, 1, 0)
            cmd.Parameters.Add("@EJES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TEJES.Text)
            cmd.Parameters.Add("@OBSER", SqlDbType.VarChar).Value = TOBSER.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub tCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLIENTE.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnCliente_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
            Bitacora("69. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("69. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCLIENTE_Validated(sender As Object, e As EventArgs) Handles tCLIENTE.Validated
        Try
            If tCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String

                DESCR = BUSCA_CAT("Cliente operativo", tCLIENTE.Text, False)
                If DESCR <> "" Then
                    LtCliente.Text = DESCR
                    tCVE_PLAZA.Select()
                Else
                    MsgBox("Cliente inexistente")
                    tCLIENTE.Text = ""
                    LtCliente.Text = ""
                    tCLIENTE.Select()
                End If
            Else
                LtCliente.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Try
            'Var2 = "Clientes"
            Var2 = "Cliente operativo"
            Var4 = "" : Var5 = ""

            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLIENTE.Text = Var4
                LtCliente.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_PLAZA.Focus()
            End If
        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmCostoCasetas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    '*********************************************************************************
    '*********************************************************************************
    Private Sub tCVE_ORIGEN_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            btnOrigen_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_ORIGEN_Validated(sender As Object, e As EventArgs)
        Try
            'If tCVE_RUTA.Text.Trim.Length > 0 Then
            'Dim DESCR As String
            'DESCR = BUSCA_CAT("Detalle Rutas", tCVE_RUTA.Text)
            'If DESCR <> "" Then
            '"Var4 = dr("ORIGEN").ToString
            'Var5 = dr("DESTINO").ToString
            'Var6 = dr("COSTO_CAS").ToString
            'Var7 = dr("KM").ToString
            'LtOrigen.Text = DESCR
            'LtDestino.Text = Var5
            'tKM_RECO.Text = Format(Val(Var7), "###,###,##0.00")
            'tCOSTO_CASETAS.Text = Format(Val(Var6), "###,###,##0.00")
            'Else
            'MsgBox("Ruta inexistente")
            'tCVE_RUTA.Text = ""
            'LtOrigen.Text = ""
            'LtDestino.Text = ""
            'tKM_RECO.Text = 0
            'tCOSTO_CASETAS.Text = 0
            'tCVE_RUTA.Select()
            'End If
            'Else
            'LtOrigen.Text = ""
            'LtDestino.Text = ""
            'tKM_RECO.Text = 0
            'tCOSTO_CASETAS.Text = 0
            'End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnOrigen_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Detalle Rutas"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1)          'CVE_RUTA
                'Var5 = Fg(Fg.Row, 2).ToString 'origen
                'Var6 = Fg(Fg.Row, 3).ToString 'destino
                'Var7 = Fg(Fg.Row, 4).ToString 'KM RECORRIDOS
                'Var8 = Fg(Fg.Row, 5).ToString 'COSTO_CASETAS
                'Var9 = Fg(Fg.Row, 6).ToString 'EJES
                'tCVE_RUTA.Text = Var4
                'LtOrigen.Text = Var5
                'LtDestino.Text = Var6
                'tKM_RECO.Text = Format(Val(Var7), "###,###,##0.00")
                If Not IsDBNull(Var8) Then
                    LtCOSTO_CASETAS.Text = Format(Val(Var8) / 1.16, "###,###,##0.00")
                End If

                'LtEjes.Text = Var9
                Try
                    If tRENDIMIENTO.Value > 0 Then
                        'tLITROS_RUTA.Text = Format(tKM_RECO.Text / tRENDIMIENTO.Value, "###,###,##0.00")
                    End If
                Catch ex As Exception
                End Try
                Try
                    tCOSTO_DISEL.Text = Format(tLITROS_RUTA.Text * tP_X_LITRO.Value, "###,###,##0.00")
                Catch ex As Exception
                End Try
                Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                tFLETE.Focus()
            End If
        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tRENDIMIENTO_ValueChanged(sender As Object, e As EventArgs) Handles tRENDIMIENTO.ValueChanged
        Try
            If tRENDIMIENTO.Text > 0 Then
                If IsNumeric(tKM_RECORRIDOS.Value) Then
                    tLITROS_RUTA.Text = Format(CDec(tKM_RECORRIDOS.Value) / tRENDIMIENTO.Text, "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tP_X_LITRO_TextChanged(sender As Object, e As EventArgs) Handles tP_X_LITRO.TextChanged
        Try
            Dim LITROS_RUTA As Decimal, P_X_LITRO As Decimal

            LITROS_RUTA = Val(tLITROS_RUTA.Text)
            P_X_LITRO = Val(tP_X_LITRO.Text)

            tCOSTO_DISEL.Text = Format(LITROS_RUTA * P_X_LITRO, "###,###,##0.00")
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tKM_RECO_TextChanged(sender As Object, e As EventArgs)
        Try
            If tRENDIMIENTO.Text > 0 Then
                'tLITROS_RUTA.Text = Format(tKM_RECO.Text / tRENDIMIENTO.Value, "###,###,##0.00")
            Else
                tLITROS_RUTA.Text = 0
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tRENDIMIENTO_TextChanged(sender As Object, e As EventArgs) Handles tRENDIMIENTO.TextChanged
        Try
            If tRENDIMIENTO.Text > 0 Then
                'tLITROS_RUTA.Text = Format(tKM_RECO.Text / tRENDIMIENTO.Text, "###,###,##0.00")
            Else
                tLITROS_RUTA.Text = 0
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tP_X_LITRO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tP_X_LITRO.PreviewKeyDown
        Try
            If e.KeyCode = 13 Then
                TOBSER.Focus()
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnPlaza_Click(sender As Object, e As EventArgs) Handles btnPlaza.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_PLAZA2.Focus()
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        Try
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                    tCVE_PLAZA2.Focus()
                Else
                    If tCVE_PLAZA.Tag <> "B" And tCVE_PLAZA.Text <> LtPlaza.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA.Focus()
                        tCVE_PLAZA.Text = ""
                        LtPlaza.Text = ""
                    End If
                End If
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles btnPlaza2.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TEJES.Focus()
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_PLAZA2_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA2.Validated
        Try
            If tCVE_PLAZA2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA2.Text)
                If DESCR <> "" Then
                    LtPlaza2.Text = DESCR
                    TEJES.Focus()
                Else
                    If tCVE_PLAZA2.Tag <> "B" And tCVE_PLAZA2.Text <> LtPlaza2.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA2.Focus()
                        tCVE_PLAZA2.Text = ""
                        LtPlaza2.Text = ""
                    End If
                End If
            Else
                LtPlaza2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tKM_RECORRIDOS_TextChanged(sender As Object, e As EventArgs) Handles tKM_RECORRIDOS.TextChanged
        Try
            If IsNumeric(tKM_RECORRIDOS.Text) Then
                If IsNumeric(tRENDIMIENTO.Value) And tRENDIMIENTO.Value > 0 Then
                    tLITROS_RUTA.Text = Format(CDec(tKM_RECORRIDOS.Text) / tRENDIMIENTO.Value, "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCOSTO_CASETAS_TextChanged(sender As Object, e As EventArgs) Handles tCOSTO_CASETAS.TextChanged
        Try
            If IsNumeric(tCOSTO_CASETAS.Text) And CDec(tCOSTO_CASETAS.Text) > 0 Then
                LtCOSTO_CASETAS.Text = Format(CDec(tCOSTO_CASETAS.Text) / 1.16, "###,###,##0.00")
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tP_X_LITRO_ValueChanged(sender As Object, e As EventArgs) Handles tP_X_LITRO.ValueChanged

    End Sub

    Private Sub frmTabRutasAE_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub TOBSER_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOBSER.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Tab) Then
                e.Handled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
