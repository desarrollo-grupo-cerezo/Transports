Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class frmServiciosManteAE
    Private Sub frmServiciosManteAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        BarraMenu.BackColor = Color.FromArgb(164, 177, 202)

        TCVE_SER.Text = ""

        TDESCR.Text = ""
        TCVE_CLAS.Text = ""
        TCVE_UNI.Text = ""
        tCOSTO_MO.Value = 0
        tTIEMPO_SERVICIO.Value = 0
        tDIAS.Value = 0
        tHORAS.Value = 0
        tKM.Value = 0
        RadPreventivo.Checked = True
        LtClass.Text = ""
        LtUnidad.Text = ""


        If Var1 = "Nuevo" Then
            Try

                TCVE_SER.Text = GET_MAX("GCSERVICIOS", "CVE_SER")
                TCVE_SER.Enabled = False
                TDESCR.Text = ""
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT S.CVE_SER, S.STATUS, S.DESCR, S.CVE_CLAS, S.CVE_UNI, S.COSTO_MO, S.TIEMPO_SERVICIO, S.DIAS, S.HORAS, S.KM, " &
                    "S.TIPO_SERVICIO " &
                    "FROM GCSERVICIOS S " &
                    "WHERE CVE_SER= '" & Var2 & "' AND STATUS = 'A'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_SER.Text = dr("CVE_SER")

                    TDESCR.Text = dr("DESCR")
                    TCVE_UNI.Text = dr("CVE_UNI")
                    LtUnidad.Text = BUSCA_CAT("Tipo unidad", TCVE_UNI.Text)

                    TCVE_CLAS.Text = dr("CVE_CLAS")
                    LtClass.Text = BUSCA_CAT("Clasificacion", TCVE_CLAS.Text)

                    tCOSTO_MO.Value = IIf(IsNumeric(dr("COSTO_MO")), dr("COSTO_MO"), 0)
                    tTIEMPO_SERVICIO.Value = IIf(IsNumeric(dr("TIEMPO_SERVICIO")), dr("TIEMPO_SERVICIO"), 0)
                    tDIAS.Value = IIf(IsNumeric(("DIAS")), dr("DIAS"), 0)
                    tHORAS.Value = IIf(IsNumeric(dr("HORAS")), dr("HORAS"), 0)
                    tKM.Value = IIf(IsNumeric(dr("KM")), dr("KM"), 0)
                    If dr("TIPO_SERVICIO") = 0 Then
                        RadPreventivo.Checked = True
                        RadCorrectivo.Checked = False
                    Else
                        RadPreventivo.Checked = False
                        RadCorrectivo.Checked = True
                    End If
                End If
                dr.Close()

                TCVE_SER.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        End If
    End Sub

    Private Sub frmServiciosManteAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmServiciosManteAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim TIPO_SERVICIO As Integer
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If



        If RadPreventivo.Checked Then
            TIPO_SERVICIO = 0
        Else
            TIPO_SERVICIO = 1
        End If

        SQL = "UPDATE GCSERVICIOS SET DESCR = @DESCR, CVE_CLAS = @CVE_CLAS, CVE_UNI = @CVE_UNI, COSTO_MO = @COSTO_MO, " &
            "TIEMPO_SERVICIO = @TIEMPO_SERVICIO, DIAS = @DIAS, HORAS = @HORAS, KM = @KM, TIPO_SERVICIO = @TIPO_SERVICIO " &
            "WHERE CVE_SER = @CVE_SER " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCSERVICIOS (CVE_SER, STATUS, DESCR, CVE_CLAS, CVE_UNI, COSTO_MO, TIEMPO_SERVICIO, DIAS, HORAS, KM, TIPO_SERVICIO) " &
            "VALUES(@CVE_SER, 'A', @DESCR, @CVE_CLAS, @CVE_UNI, @COSTO_MO, @TIEMPO_SERVICIO, @DIAS, @HORAS, @KM, @TIPO_SERVICIO)"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_SER", SqlDbType.VarChar).Value = TCVE_SER.Text

            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
            cmd.Parameters.Add("@CVE_CLAS", SqlDbType.VarChar).Value = TCVE_CLAS.Text
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_UNI.Text
            cmd.Parameters.Add("@COSTO_MO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tCOSTO_MO.Value)
            cmd.Parameters.Add("@TIEMPO_SERVICIO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTIEMPO_SERVICIO.Value)
            cmd.Parameters.Add("@DIAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tDIAS.Value)
            cmd.Parameters.Add("@HORAS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tHORAS.Value)
            cmd.Parameters.Add("@KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKM.Value)
            cmd.Parameters.Add("@TIPO_SERVICIO", SqlDbType.SmallInt).Value = TIPO_SERVICIO

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

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub btnClasific_Click(sender As Object, e As EventArgs) Handles BtnClasific.Click

        Try

            Var2 = "Clasificacion"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_CLAS.Text = Var4
                LtClass.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCVE_UNI.Focus()
            End If


        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub

    Private Sub btnTipoUnidad_Click(sender As Object, e As EventArgs) Handles BtnTipoUnidad.Click
        Try

            Var2 = "Tipo Unidad"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var5
                LtUnidad.Text = Var6
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCOSTO_MO.Focus()
            End If


        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_CLAS_TextChanged(sender As Object, e As EventArgs) Handles TCVE_CLAS.TextChanged

    End Sub
End Class
