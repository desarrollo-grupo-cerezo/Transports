Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmCatEvaluacionesAE
    Private NewRecord As Boolean = False
    Private Sub FrmCatEvaluacionesAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        AssignValidation(Me.TFACTOR_CARGA, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_FACTOR_CARGA, ValidationType.Only_Numbers)
        AssignValidation(Me.TPORC_USO_RALENTI, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_RALENTI, ValidationType.Only_Numbers)
        AssignValidation(Me.TPONDE_FC, ValidationType.Only_Numbers)
        AssignValidation(Me.TPONDE_RALENTI, ValidationType.Only_Numbers)

        AssignValidation(Me.TCALIF_GLOBAL1, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL2, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL3, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL4, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL5, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL6, ValidationType.Only_Numbers)
        AssignValidation(Me.TCALIF_GLOBAL7, ValidationType.Only_Numbers)

        AssignValidation(Me.TBONO1, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO2, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO3, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO4, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO5, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO6, ValidationType.Only_Numbers)
        AssignValidation(Me.TBONO7, ValidationType.Only_Numbers)

        Me.KeyPreview = True

        If Var1 = "Nuevo" Then
            Try
                NewRecord = True
                TCVE_EVA.Text = GET_MAX("GCCATEVA", "CVE_EVA")
                TCVE_EVA.Enabled = False
                TCVE_MOT.Text = ""
                TCVE_MOT.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_EVA, C.CVE_MOT, C.FACTOR_CARGA, C.CALIF_FACTOR_CARGA, C.PORC_USO_RALENTI, C.CALIF_RALENTI, 
                    C.BONO, PONDE_FC, PONDE_RALENTI, VEL_MAX, CALIF_VEL_MAX, PON_VEL_MAX, ISNULL(TIPO_VIAJE ,-1) AS TIP_VIA,
                    C.CALIF_GLOBAL, C.CALIF_GLOBAL2, C.CALIF_GLOBAL3, C.CALIF_GLOBAL4, C.CALIF_GLOBAL5, C.CALIF_GLOBAL6, C.CALIF_GLOBAL7, 
                    C.BONO, C.BONO2, C.BONO3, C.BONO4, C.BONO5, C.BONO6, C.BONO7, ISNULL(CALCULO_POSITIVO,0) AS CAL_POS,
                    ISNULL(C.RPM_MAX,0) AS R_MAX, ISNULL(C.PON_RPM_MAX,0) AS P_RPM_MAX, ISNULL(C.CALIF_RPM_MAX,0) AS C_RPM_MAX,
                    ISNULL(C.DESCR,'') AS DES
                    FROM GCCATEVA C 
                    WHERE CVE_EVA = " & Var2 & " AND C.STATUS <> 'B'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_EVA.Text = dr("CVE_EVA").ToString
                    TCVE_MOT.Text = dr("CVE_MOT").ToString
                    If TCVE_MOT.Text = "0" Then
                        TCVE_MOT.Text = ""
                    End If
                    LtMotor.Text = BUSCA_CAT("Motor", TCVE_MOT.Text)

                    TFACTOR_CARGA.Text = dr("FACTOR_CARGA").ToString
                    TCALIF_FACTOR_CARGA.Text = dr("CALIF_FACTOR_CARGA").ToString
                    TPORC_USO_RALENTI.Text = dr("PORC_USO_RALENTI").ToString
                    TCALIF_RALENTI.Text = dr("CALIF_RALENTI").ToString
                    TPONDE_FC.Text = dr.ReadNullAsEmptyDecimal("PONDE_FC").ToString
                    TPONDE_RALENTI.Text = dr.ReadNullAsEmptyDecimal("PONDE_RALENTI").ToString
                    TVEL_MAX.Text = dr("VEL_MAX").ToString
                    TCALIF_VEL_MAX.Text = dr("CALIF_VEL_MAX").ToString
                    TPON_VEL_MAX.Text = dr("PON_VEL_MAX").ToString

                    TCALIF_GLOBAL1.Text = dr("CALIF_GLOBAL").ToString
                    TCALIF_GLOBAL2.Text = dr("CALIF_GLOBAL2").ToString
                    TCALIF_GLOBAL3.Text = dr("CALIF_GLOBAL3").ToString
                    TCALIF_GLOBAL4.Text = dr("CALIF_GLOBAL4").ToString
                    TCALIF_GLOBAL5.Text = dr("CALIF_GLOBAL5").ToString
                    TCALIF_GLOBAL6.Text = dr("CALIF_GLOBAL6").ToString
                    TCALIF_GLOBAL7.Text = dr("CALIF_GLOBAL7").ToString

                    TBONO1.Text = dr("BONO").ToString
                    TBONO2.Text = dr("BONO2").ToString
                    TBONO3.Text = dr("BONO3").ToString
                    TBONO4.Text = dr("BONO4").ToString
                    TBONO5.Text = dr("BONO5").ToString
                    TBONO6.Text = dr("BONO6").ToString
                    TBONO7.Text = dr("BONO7").ToString

                    Select Case dr.ReadNullAsEmptyInteger("TIP_VIA")
                        Case 0
                            'RadFull.Checked = True
                            RadSencillo.Checked = True
                        Case 1
                            RadFull.Checked = True
                            'RadSencillo.Checked = True
                        Case 2
                            'RadFull.Checked = False
                            'RadSencillo.Checked = False
                            RadFull_Sencillo.Checked = True
                    End Select
                    If dr("CAL_POS") = 0 Then
                        ChCalculo_positivo.Checked = False
                    Else
                        ChCalculo_positivo.Checked = True
                    End If
                    TRPM_MAX.Text = dr("R_MAX")
                    TPON_RPM_MAX.Text = dr("P_RPM_MAX")
                    TCALIF_RPM_MAX.Text = dr("C_RPM_MAX")
                    TDESCR.Text = dr("DES")
                    If TDESCR.Text.Trim.Length = 0 Then
                        TDESCR.Text = LtMotor.Text
                    End If

                    If PASS_GRUPOCE <> "BUS" And PASS_GRUPOCE <> "BR3FRAJA" Then
                        If dr("DES") = "TABULADOR FULL" Or dr("DES") = "TABULADOR SENCILLO" Or dr("DES") = "TABULADOR FULL/SENCILLO" Then
                            SET_ALL_CONTROL_READ_AND_ENABLED(Me)
                        End If
                    End If
                Else
                    TCVE_EVA.Text = ""
                    TCVE_MOT.Text = ""
                    TFACTOR_CARGA.Text = ""
                    TCALIF_FACTOR_CARGA.Text = ""
                    TPORC_USO_RALENTI.Text = ""
                    TCALIF_RALENTI.Text = ""
                    TCALIF_GLOBAL1.Text = ""
                    TBONO1.Text = 0
                    TPONDE_FC.Text = ""
                    TPONDE_RALENTI.Text = ""
                End If
                dr.Close()

                TCVE_EVA.Enabled = False
                TCVE_MOT.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmCatEvaluacionesAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnMotor_Click(sender As Object, e As EventArgs) Handles BtnMotor.Click
        Try
            Var2 = "Motor"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_MOT.Text = Var4
                LtMotor.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TFACTOR_CARGA.Focus()
            End If
        Catch Ex As Exception
            Bitacora("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("350. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim cmd As New SqlCommand With {.Connection = cnSAE}
        Dim TIPO_VIAJE As Integer = -1

        'IIf(RadFull.Checked, 1, 0)
        If RadFull.Checked Then
            TIPO_VIAJE = 1
        ElseIf RadSencillo.Checked Then
            TIPO_VIAJE = 0
        ElseIf RadFull_Sencillo.Checked Then
            TIPO_VIAJE = 2
        End If

        If NewRecord Then
            SQL = "INSERT INTO GCCATEVA (CVE_EVA, STATUS, DESCR, CVE_MOT, FACTOR_CARGA, CALIF_FACTOR_CARGA, PORC_USO_RALENTI, CALIF_RALENTI, PONDE_FC, PONDE_RALENTI, 
                VEL_MAX, CALIF_VEL_MAX, PON_VEL_MAX, TIPO_VIAJE, CALIF_GLOBAL, CALIF_GLOBAL2, CALIF_GLOBAL3, CALIF_GLOBAL4, CALIF_GLOBAL5, CALIF_GLOBAL6, 
                CALIF_GLOBAL7, BONO, BONO2, BONO3, BONO4, BONO5, BONO6, BONO7, CALCULO_POSITIVO, RPM_MAX, PON_RPM_MAX, CALIF_RPM_MAX,
                UUID) OUTPUT Inserted.CVE_EVA VALUES(
                ISNULL((SELECT ISNULL(MAX(CVE_EVA),0) + 1 FROM GCCATEVA),1), 'A', @DESCR, @CVE_MOT, @FACTOR_CARGA, @CALIF_FACTOR_CARGA, @PORC_USO_RALENTI, 
                @CALIF_RALENTI, @PONDE_FC, @PONDE_RALENTI, @VEL_MAX, @CALIF_VEL_MAX, @PON_VEL_MAX, @TIPO_VIAJE, @CALIF_GLOBAL, @CALIF_GLOBAL2, 
                @CALIF_GLOBAL3, @CALIF_GLOBAL4, @CALIF_GLOBAL5, @CALIF_GLOBAL6, @CALIF_GLOBAL7, @BONO, @BONO2, @BONO3, @BONO4, @BONO5, @BONO6, @BONO7, 
                @CALCULO_POSITIVO, @RPM_MAX, @PON_RPM_MAX, @CALIF_RPM_MAX, NEWID())"
        Else
            SQL = "UPDATE GCCATEVA SET CVE_MOT = @CVE_MOT, FACTOR_CARGA = @FACTOR_CARGA, CALIF_FACTOR_CARGA = @CALIF_FACTOR_CARGA, 
                PORC_USO_RALENTI = @PORC_USO_RALENTI, CALIF_RALENTI = @CALIF_RALENTI, PONDE_FC = @PONDE_FC, PONDE_RALENTI = @PONDE_RALENTI, 
                VEL_MAX = @VEL_MAX, CALIF_VEL_MAX = @CALIF_VEL_MAX, CALIF_GLOBAL = @CALIF_GLOBAL, CALIF_GLOBAL2 = @CALIF_GLOBAL2, 
                CALIF_GLOBAL3 = @CALIF_GLOBAL3, CALIF_GLOBAL4 = @CALIF_GLOBAL4, CALIF_GLOBAL5 = @CALIF_GLOBAL5, CALIF_GLOBAL6 = @CALIF_GLOBAL6, 
                CALIF_GLOBAL7 = @CALIF_GLOBAL7, BONO = @BONO, BONO2 = @BONO2, BONO3 = @BONO3, BONO4 = @BONO4, BONO5 = @BONO5, BONO6 = @BONO6, 
                BONO7 = @BONO7, PON_VEL_MAX = @PON_VEL_MAX, TIPO_VIAJE = @TIPO_VIAJE, CALCULO_POSITIVO = @CALCULO_POSITIVO, 
                RPM_MAX = @RPM_MAX, PON_RPM_MAX = @PON_RPM_MAX, CALIF_RPM_MAX = @CALIF_RPM_MAX, DESCR = @DESCR
                WHERE CVE_EVA = @CVE_EVA"
        End If
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_EVA", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_EVA.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
            cmd.Parameters.Add("@CVE_MOT", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_MOT.Text)
            cmd.Parameters.Add("@FACTOR_CARGA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TFACTOR_CARGA.Text)
            cmd.Parameters.Add("@CALIF_FACTOR_CARGA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_FACTOR_CARGA.Text)
            cmd.Parameters.Add("@PORC_USO_RALENTI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TPORC_USO_RALENTI.Text)
            cmd.Parameters.Add("@CALIF_RALENTI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_RALENTI.Text)
            cmd.Parameters.Add("@PONDE_FC", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TPONDE_FC.Text)
            cmd.Parameters.Add("@PONDE_RALENTI", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TPONDE_RALENTI.Text)
            cmd.Parameters.Add("@VEL_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TVEL_MAX.Text)
            cmd.Parameters.Add("@CALIF_VEL_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_VEL_MAX.Text)
            cmd.Parameters.Add("@PON_VEL_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TPON_VEL_MAX.Text)
            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.SmallInt).Value = TIPO_VIAJE

            cmd.Parameters.Add("@CALIF_GLOBAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL1.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL2", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL2.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL3", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL3.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL4", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL4.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL5", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL5.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL6", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL6.Text)
            cmd.Parameters.Add("@CALIF_GLOBAL7", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_GLOBAL7.Text)
            cmd.Parameters.Add("@BONO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO1.Text)
            cmd.Parameters.Add("@BONO2", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO2.Text)
            cmd.Parameters.Add("@BONO3", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO3.Text)
            cmd.Parameters.Add("@BONO4", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO4.Text)
            cmd.Parameters.Add("@BONO5", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO5.Text)
            cmd.Parameters.Add("@BONO6", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO6.Text)
            cmd.Parameters.Add("@BONO7", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TBONO7.Text)
            cmd.Parameters.Add("@CALCULO_POSITIVO", SqlDbType.SmallInt).Value = IIf(ChCalculo_positivo.Checked, 1, 0)

            cmd.Parameters.Add("@RPM_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TRPM_MAX.Text)
            cmd.Parameters.Add("@PON_RPM_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TPON_RPM_MAX.Text)
            cmd.Parameters.Add("@CALIF_RPM_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TCALIF_RPM_MAX.Text)
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
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub TCVE_MOT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_MOT.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMotor_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_MOT_Validated(sender As Object, e As EventArgs) Handles TCVE_MOT.Validated
        Try
            If TCVE_MOT.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Motor", TCVE_MOT.Text)
                If DESCR <> "" Then
                    LtMotor.Text = DESCR
                Else
                    MsgBox("Motor inexistente")
                    TCVE_MOT.Text = ""
                    LtMotor.Text = ""
                    TFACTOR_CARGA.Select()
                End If
            Else
                LtMotor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmCatEvaluacionesAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub TBONO7_KeyDown(sender As Object, e As KeyEventArgs) Handles TBONO7.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                TCVE_MOT.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TBONO7_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TBONO7.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                TCVE_MOT.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
