Imports System.Data.SqlClient
Public Class frmDetallesRutasAE
    Private Sub frmDetallesRutasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        Try
            tCVE_RUTA.Text = ""
            tORIGEN.Text = ""
            tDESTINO.Text = ""
            tCOSTO_CASETAS.Value = 0
            tKM_RECORRIDOS.Value = 0
            tTIEMPO_TOTAL.Value = 0
            tDESCANSOS.Value = 0
            tEJES.Value = 0
            tPARADAS_TOTALES.Value = 0
            tGASOLINERAS.Value = 0
            tTRAMOS.Value = 0
            tALERTAS.Text = ""
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tCVE_RUTA.Text = GET_MAX("GCDETALLE_RUTAS", "CVE_RUTA")
                tCVE_RUTA.Enabled = False
                tORIGEN.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT ISNULL(D.CVE_RUTA,'') as CVERUTA, ISNULL(D.ORIGEN,'') AS ORI, ISNULL(D.DESTINO,'') AS DEST, ISNULL(CVE_PLA1,0) AS PLA1,
                    ISNULL(CVE_PLA2,0) AS PLA2, ISNULL(D.COSTO_CASETAS,0) AS COSTO, ISNULL(D.KM_RECORRIDOS,0) AS KM, ISNULL(D.TIEMPO_TOTAL,0) AS TR,
                    ISNULL(D.DESCANSOS,0) AS DES, ISNULL(D.EJES,0) AS EJE, ISNULL(D.PARADAS_TOTALES,0) AS PT, ISNULL(D.GASOLINERAS,0) AS GAS,
                    ISNULL(D.TRAMOS,0) AS TRA, ISNULL(D.ALERTAS,0) AS ALER, 
                    ISNULL(P1.CIUDAD,'') AS CIUDAD1, ISNULL(P1.STATUS,'A') AS ST_PLAZA1,
                    ISNULL(P2.CIUDAD,'') AS CIUDAD2, ISNULL(P2.STATUS,'A') AS ST_PLAZA2
                    FROM GCDETALLE_RUTAS D 
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLA1
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLA2
                    WHERE CVE_RUTA = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_RUTA.Text = dr("CVERUTA").ToString

                    If dr("PLA1").ToString = "0" Then
                        tORIGEN.Text = ""
                        LtPlaza1.Text = ""
                    Else
                        tORIGEN.Text = dr("PLA1").ToString
                        tORIGEN.Tag = dr("ST_PLAZA1").ToString
                        LtPlaza1.Text = dr("CIUDAD1").ToString
                        LtPlaza1.Tag = tORIGEN.Text
                    End If

                    If dr("PLA2").ToString = "0" Then
                        tDESTINO.Text = ""
                        LtPlaza2.Text = ""
                    Else
                        tDESTINO.Text = dr("PLA2").ToString
                        tDESTINO.Tag = dr("ST_PLAZA2").ToString
                        LtPlaza2.Text = dr("CIUDAD2").ToString
                        LtPlaza2.Tag = tDESTINO.Text
                    End If

                    tCOSTO_CASETAS.Value = dr("COSTO").ToString
                    LtCasetasSinIva.Text = Format(tCOSTO_CASETAS.Value / 1.16, "###,###,##0.00")

                    tKM_RECORRIDOS.Value = dr("KM").ToString
                    tTIEMPO_TOTAL.Value = dr("TR").ToString
                    tDESCANSOS.Value = dr("DES").ToString
                    tEJES.Value = dr("EJE").ToString
                    tPARADAS_TOTALES.Value = dr("PT").ToString
                    tGASOLINERAS.Value = dr("GAS").ToString
                    tTRAMOS.Value = dr("TRA").ToString
                    tALERTAS.Text = dr("ALER").ToString
                End If
                dr.Close()

                tCVE_RUTA.Enabled = False
                tORIGEN.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmDetallesRutasAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmDetallesRutasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        If tORIGEN.Text.Trim.Length = 0 Then
            MsgBox("El origen  no debe quedar vacia, verifique por favor")
            Return
        End If

        If tDESTINO.Text.Trim.Length = 0 Then
            MsgBox("El destino no debe quedar vacia, verifique por favor")
            Return
        End If

        If tORIGEN.Text = tDESTINO.Text Then
            MsgBox("El origen y el destino no puede ser iguales verifique por favor")
            Return
        End If

        SQL = "UPDATE GCDETALLE_RUTAS SET CVE_PLA1 = @CVE_PLA1, CVE_PLA2 = @CVE_PLA2 , " &
            "COSTO_CASETAS = @COSTO_CASETAS, KM_RECORRIDOS = @KM_RECORRIDOS, TIEMPO_TOTAL = @TIEMPO_TOTAL, DESCANSOS = @DESCANSOS, " &
            "EJES = @EJES, PARADAS_TOTALES = @PARADAS_TOTALES, GASOLINERAS = @GASOLINERAS, TRAMOS = @TRAMOS, ALERTAS = @ALERTAS " &
            "WHERE CVE_RUTA = @CVE_RUTA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCDETALLE_RUTAS (CVE_RUTA, STATUS, CVE_PLA1, CVE_PLA2, COSTO_CASETAS, KM_RECORRIDOS, TIEMPO_TOTAL, DESCANSOS, EJES, " &
            "PARADAS_TOTALES, GASOLINERAS, TRAMOS, ALERTAS) VALUES (@CVE_RUTA, 'A', @CVE_PLA1, @CVE_PLA2, @COSTO_CASETAS, @KM_RECORRIDOS, " &
            "@TIEMPO_TOTAL, @DESCANSOS, @EJES, @PARADAS_TOTALES, @GASOLINERAS, @TRAMOS, @ALERTAS)"

        cmd.CommandText = SQL


        Try
            cmd.Parameters.Add("@CVE_RUTA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_RUTA.Text)

            cmd.Parameters.Add("@CVE_PLA1", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(tORIGEN.Text)
            cmd.Parameters.Add("@CVE_PLA2", SqlDbType.VarChar).Value = CONVERTIR_TO_INT(tDESTINO.Text)
            cmd.Parameters.Add("@COSTO_CASETAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCOSTO_CASETAS.Text)
            cmd.Parameters.Add("@KM_RECORRIDOS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKM_RECORRIDOS.Text)
            cmd.Parameters.Add("@TIEMPO_TOTAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTIEMPO_TOTAL.Text)
            cmd.Parameters.Add("@DESCANSOS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tDESCANSOS.Text)
            cmd.Parameters.Add("@EJES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tEJES.Text)
            cmd.Parameters.Add("@PARADAS_TOTALES", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tPARADAS_TOTALES.Text)
            cmd.Parameters.Add("@GASOLINERAS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tGASOLINERAS.Text)
            cmd.Parameters.Add("@TRAMOS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tTRAMOS.Text)
            cmd.Parameters.Add("@ALERTAS", SqlDbType.VarChar).Value = tALERTAS.Text

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
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub tCOSTO_CASETAS_ValueChanged(sender As Object, e As EventArgs) Handles tCOSTO_CASETAS.ValueChanged
        Try
            LtCasetasSinIva.Text = Format(tCOSTO_CASETAS.Text / 1.16, "###,###,##0.00")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnPlaza1_Click(sender As Object, e As EventArgs) Handles btnPlaza1.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If Var4 = tDESTINO.Text Then
                    MsgBox("La plaza se encuentra actualmente asignada, verifique por favor")
                    Return
                End If
                tORIGEN.Text = Var4
                LtPlaza1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles btnPlaza2.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If Var4 = tORIGEN.Text Then
                    MsgBox("La plaza se encuentra actualmente asignada, verifique por favor")
                    Return
                End If
                tDESTINO.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tORIGEN_KeyDown(sender As Object, e As KeyEventArgs) Handles tORIGEN.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tORIGEN_Validated(sender As Object, e As EventArgs) Handles tORIGEN.Validated
        Try
            If tORIGEN.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tORIGEN.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    LtPlaza1.Text = DESCR
                Else
                    If tORIGEN.Tag <> "B" And tORIGEN.Text <> LtPlaza1.Tag Then
                        MsgBox("Plaza origen inexistente")
                        tORIGEN.Text = ""
                        tORIGEN.Select()
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tDESTINO_KeyDown(sender As Object, e As KeyEventArgs) Handles tDESTINO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tDESTINO_Validated(sender As Object, e As EventArgs) Handles tDESTINO.Validated
        Try
            If tDESTINO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tDESTINO.Text)
                If DESCR <> "" And DESCR <> "N" Then
                    LtPlaza2.Text = DESCR
                Else
                    If tDESTINO.Tag <> "B" And tDESTINO.Text <> LtPlaza2.Tag Then
                        MsgBox("Plaza destino inexistente")
                        tDESTINO.Text = ""
                        tDESTINO.Select()
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tORIGEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tORIGEN.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub tDESTINO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tDESTINO.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
