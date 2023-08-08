Imports System.Data.SqlClient
Public Class frmSiniestroAE
    Private Sub frmSiniestroAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        tFECHA.Value = Date.Today
        tFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.CustomFormat = "dd/MM/yyyy"
        tFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

        tHORA.Value = Date.Today
        tHORA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tHORA.CustomFormat = "HH:mm:ss"
        tHORA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tHORA.EditFormat.CustomFormat = "HH:mm:ss"

        'tFECHA_ATENCION.Value = Date.Today
        'tFECHA_ATENCION.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'tFECHA_ATENCION.CustomFormat = "dd/MM/yyyy"
        'tFECHA_ATENCION.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        'tFECHA_ATENCION.EditFormat.CustomFormat = "dd/MM/yyyy"

        tCVE_UNI.MaxLength = 10
        tUBICACION.MaxLength = 255
        'tDESCR.MaxLength = 255
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        tFOLIO.Text = ""
        tNUM_SIN.Text = ""
        tFECHA.Value = Now
        tHORA.Value = Now
        tCVE_UNI.Text = ""
        tCVE_OPER.Text = ""
        tUBICACION.Text = ""
        tLATITUD.Text = ""
        tLONGITUD.Text = ""
        tFECHA_ATENCION.Value = ""
        tDESCR.Text = ""
        LtPoliza.Text = ""
        LtVigenciaPoliza.Text = ""
        LtUnidad.Text = ""
        LtOper.Text = ""

        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tFOLIO.Text = GET_MAX("GCSINIESTRO", "FOLIO")
                tFOLIO.Enabled = False
                tNUM_SIN.Select()

            Catch ex As Exception
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT S.FOLIO, S.NUM_SIN, S.STATUS, S.FECHA, S.IDPOLIZA, P.INICIO, P.TERMINO, S.HORA, S.CVE_UNI, S.CVE_OPER, S.UBICACION, S.LATITUD, S.LONGITUD, " &
                    "S.FECHA_ATENCION, S.HORA_ATENCION, S.DESCR " &
                    "FROM GCSINIESTRO S " &
                    "LEFT JOIN GCPOLIZAS P ON P.IDPOLIZA = S.IDPOLIZA " &
                    "WHERE S.FOLIO = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tFOLIO.Text = dr("FOLIO").ToString
                    tNUM_SIN.Text = dr("NUM_SIN").ToString
                    tFECHA.value = dr("FECHA").ToString
                    tPOLIZA.Text = dr("IDPOLIZA").ToString
                    LtPoliza.Text = BUSCA_CAT("Poliza", tPOLIZA.Text)
                    LtVigenciaPoliza.Text = dr("INICIO") & " - " & dr("TERMINO")
                    tHORA.Value = dr("HORA").ToString
                    tCVE_UNI.Text = dr("CVE_UNI").ToString
                    LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Text)

                    tCVE_OPER.Text = dr("CVE_OPER").ToString
                    LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)

                    tUBICACION.text = dr("UBICACION").ToString
                    tLATITUD.text = dr("LATITUD").ToString
                    tLONGITUD.Text = dr("LONGITUD").ToString
                    tFECHA_ATENCION.Value = dr("FECHA_ATENCION").ToString
                    'tHORA_ATENCION.text = dr("HORA_ATENCION").ToString
                    tDESCR.text = dr("DESCR").ToString
                Else
                End If
                dr.Close()

                tFOLIO.Enabled = False
                tNUM_SIN.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub frmSiniestroAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Siniestros ")
        Me.Dispose()
    End Sub

    Private Sub frmSiniestroAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmSiniestroAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        SQL = "UPDATE GCSINIESTRO SET NUM_SIN = @NUM_SIN, FECHA = @FECHA, IDPOLIZA = @IDPOLIZA, HORA = @HORA, " &
            "CVE_UNI = @CVE_UNI, CVE_OPER = @CVE_OPER, UBICACION = @UBICACION, LATITUD = @LATITUD, LONGITUD = @LONGITUD, " &
            "FECHA_ATENCION = @FECHA_ATENCION, DESCR = @DESCR " &
            "WHERE FOLIO = @FOLIO " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCSINIESTRO (FOLIO, NUM_SIN, STATUS, FECHA, IDPOLIZA, HORA, CVE_UNI, CVE_OPER, UBICACION, LATITUD, LONGITUD, " &
            "FECHA_ATENCION, DESCR, GUID) VALUES(@FOLIO, @NUM_SIN, 'A', @FECHA, @IDPOLIZA, @HORA, @CVE_UNI, @CVE_OPER, @UBICACION, " &
            "@LATITUD, @LONGITUD, @FECHA_ATENCION, @DESCR, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@FOLIO", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_SIN.Text)
            cmd.Parameters.Add("@NUM_SIN", SqlDbType.Int).Value = CONVERTIR_TO_INT(tNUM_SIN.Text)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = tFECHA.Value
            cmd.Parameters.Add("@IDPOLIZA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tPOLIZA.Text)
            cmd.Parameters.Add("@HORA", SqlDbType.DateTime).Value = tHORA.Value
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_OPER.Text)
            cmd.Parameters.Add("@UBICACION", SqlDbType.VarChar).Value = tUBICACION.Text
            cmd.Parameters.Add("@LATITUD", SqlDbType.Int).Value = CONVERTIR_TO_INT(tLATITUD.Text)
            cmd.Parameters.Add("@LONGITUD", SqlDbType.Int).Value = CONVERTIR_TO_INT(tLONGITUD.Text)
            cmd.Parameters.Add("@FECHA_ATENCION", SqlDbType.DateTime).Value = tFECHA_ATENCION.Value
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = tDESCR.Text
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

    Private Sub btnTipoPol_Click(sender As Object, e As EventArgs) Handles btnTipoPol.Click
        Try
            Var2 = "GCPOLIZAS"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tPOLIZA.Text = Var4
                LtPoliza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_UNI.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnUnidad_Click(sender As Object, e As EventArgs) Handles btnUnidad.Click
        Try
            Var2 = "Unidades"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var4
                LtUnidad.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_OPER.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador"
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tUBICACION.Focus()
            End If
        Catch ex As Exception
            msgbox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19 " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
