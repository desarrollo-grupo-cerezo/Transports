Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmLlantasAE
    Private NewLlanta As Boolean = False

    Private Sub FrmLlantasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
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

        BtnArt.FlatStyle = FlatStyle.Flat
        BtnArt.FlatAppearance.BorderSize = 0
        BtnMod.FlatStyle = FlatStyle.Flat
        BtnMod.FlatAppearance.BorderSize = 0
        BtnTipoLlanta.FlatStyle = FlatStyle.Flat
        BtnTipoLlanta.FlatAppearance.BorderSize = 0
        BtnModRen.FlatStyle = FlatStyle.Flat
        BtnModRen.FlatAppearance.BorderSize = 0
        BtnMarca.FlatStyle = FlatStyle.Flat
        BtnMarca.FlatAppearance.BorderSize = 0
        BtnMarcaRen.FlatStyle = FlatStyle.Flat
        BtnMarcaRen.FlatAppearance.BorderSize = 0
        btnOR.FlatStyle = FlatStyle.Flat
        btnOR.FlatAppearance.BorderSize = 0

        TKM.Value = 0
        TKMS_ACTUAL.Value = 0
        TKMS_MONTAR.Value = 0
        TKMS_DESMONTAR.Value = 0

        Fecha_Mon.Value = Date.Today
        Fecha_Mon.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Mon.CustomFormat = "dd/MM/yyyy"
        Fecha_Mon.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Mon.EditFormat.CustomFormat = "dd/MM/yyyy"

        Fecha_Dis_desde.Value = Date.Today
        Fecha_Dis_desde.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Dis_desde.CustomFormat = "dd/MM/yyyy"
        Fecha_Dis_desde.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Dis_desde.EditFormat.CustomFormat = "dd/MM/yyyy"

        Fecha_Reg.Value = Date.Today
        Fecha_Reg.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Reg.CustomFormat = "dd/MM/yyyy"
        Fecha_Reg.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Fecha_Reg.EditFormat.CustomFormat = "dd/MM/yyyy"
        Me.KeyPreview = True
        Pag.SelectedIndex = 0

        'RadNueva.Enabled = False
        'RadRenovada.Enabled = False

        RadRenovada.Checked = False

        AssignValidation(Me.TMEDIDA, ValidationType.Only_Numbers)
        AssignValidation(Me.TPROFUNDIDAD_ACTUAL, ValidationType.Only_Numbers)
        AssignValidation(Me.TCOSTO_LLANTA_MN, ValidationType.Only_Numbers)
        AssignValidation(Me.TPRESION_MINIMA, ValidationType.Only_Numbers)
        AssignValidation(Me.TPRESION_ORIGINAL, ValidationType.Only_Numbers)
        AssignValidation(Me.TPRESION_ACTUAL, ValidationType.Only_Numbers)
        AssignValidation(Me.TVIDA_UTIL, ValidationType.Only_Numbers)
        AssignValidation(Me.TCOSTO_LLANTA_DLS, ValidationType.Only_Numbers)
        AssignValidation(Me.TNO_RENOVADOS, ValidationType.Only_Numbers)
        AssignValidation(Me.TMARCA_RENO, ValidationType.Only_Numbers)
        AssignValidation(Me.TMARCA_RENO, ValidationType.Only_Numbers)

        If Var1 = "Nuevo" Then
            Try
                NewLlanta = True

                INICIALIZAR_CONTROLES()

                TCVE_LLANTA.Text = GET_MAX("GCLLANTAS", "CVE_LLANTA")
                TCVE_LLANTA.Enabled = False

                TNUM_ECONOMICO.Select()
            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                TNUM_ECONOMICO.ReadOnly = True

                BtnMax.Visible = False

                SQL = "SELECT L.CVE_LLANTA, L.POSICION, L.POSICION2, L.NUM_ECONOMICO, L.DISENO, L.O_R, L.FECHA_MON, L.MARCA, L.MARCA_RENOVADO, 
                    L.MODELO, L.MODELO_RENOVADO, ISNULL(L.KM,0) AS K_M, ISNULL(L.MEDIDA,'') AS MED, ISNULL(L.PROFUNDIDA_ORIGINAL,'0') AS PRO_ORI,
                    ISNULL(L.ROFUNDIDA_MINIMA,0) AS ROF_MIN, ISNULL(L.PROFUNDIDAD_ACTUAL,0) AS PRO_ACT, ISNULL(L.PROFUNDIDAD_ACTUAL2,0) AS PRO_ACT2, 
                    ISNULL(L.PROFUNDIDAD_ACTUAL3,0) AS PRO_ACT3, ISNULL(L.PROFUNDIDAD_ACTUAL4,0) AS PRO_ACT4, ISNULL(L.PRESION_MINIMA,0) AS PRE_MIN,
                    ISNULL(L.PRESION_ORIGINAL,0) AS PRE_ORI, ISNULL(L.PRESION_ACTUAL,0) AS PRE_ACT, L.TIPO_LLANTA, ISNULL(L.STATUS_LLANTA,'') AS ST_LLA,
                    ISNULL(L.DISPONIBLE_DESDE,'') AS DIS_DES, ISNULL(L.VIDA_UTIL,'') AS VID_UTI, ISNULL(L.COSTO_LLANTA_MN,0) AS COS_LLA_MN,
                    ISNULL(L.COSTO_LLANTA_DLS,0) AS COS_LLA_DLS, L.FECHA_REG, L.LLANTA1, L.EJES, ISNULL(L.CVE_OBS,0) AS CVE_OB, 
                    ISNULL(O.DESCR,'') AS DESCR_OBS, CUEN_CONT, KMS_MONTAR, KMS_DESMONTAR, L.CVE_ART, ISNULL(TIPO_NUEVA_RENO, 0) AS TIPO_NEW_REN,
                    ISNULL(NO_RENOVADOS,0) AS NO_RENO, KMS_ACTUAL, DOT, L.CVE_MARCA, M.DESCR AS DES_MARCA, L.CVE_PRE, P.DESCR AS DES_RENO
                    FROM GCLLANTAS L
                    LEFT JOIN GCOBS O ON O.CVE_OBS = L.CVE_OBS
                    LEFT JOIN GCMARCAS_RENOVADO M ON M.CVE_MARCA = L.CVE_MARCA
                    LEFT JOIN GCPROVRENOVADO P ON P.CVE_PRE = L.CVE_PRE
                    WHERE L.NUM_ECONOMICO = '" & Var2 & "' AND L.STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    Try
                        TCVE_LLANTA.Text = dr.ReadNullAsEmptyString("CVE_LLANTA")
                        If TCVE_LLANTA.Text.Trim.Length = 0 Then
                            TCVE_LLANTA.Text = GET_MAX("GCLLANTAS", "CVE_LLANTA")
                        End If

                        TNUM_ECONOMICO.Text = dr.ReadNullAsEmptyString("NUM_ECONOMICO")

                        TO_R.Text = dr.ReadNullAsEmptyString("O_R")
                        LtOR.Text = BUSCA_CAT("Tipo Llanta", TO_R.Text)

                        TMEDIDA.Text = Val(dr.ReadNullAsEmptyString("MED"))
                        If TMEDIDA.Text = "0" Then TMEDIDA.Text = ""

                        If TMEDIDA.Text <> "" Then
                            LtMarRen.Text = BUSCA_CAT("Medidas Llanta", TMEDIDA.Text)
                        End If

                        If dr("TIPO_NEW_REN") = 0 Then
                            RadNueva.Checked = True
                            RadRenovada.Checked = False
                        Else
                            RadRenovada.Checked = True
                            RadNueva.Checked = False
                        End If
                        TNO_RENOVADOS.Text = dr("NO_RENO")

                        TDOT.Text = dr.ReadNullAsEmptyString("DOT")

                        TMARCA_RENO.Text = dr.ReadNullAsEmptyString("CVE_MARCA")
                        LtMarca_Reno.Text = dr("DES_MARCA")
                        TPROV_RENO.Text = dr.ReadNullAsEmptyString("CVE_PRE")
                        LtProv_Reno.Text = dr("DES_RENO")

                    Catch ex As Exception
                        Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        Fecha_Mon.Value = dr.ReadNullAsEmptyString("FECHA_MON")
                        TMARCA.Text = dr.ReadNullAsEmptyString("MARCA")
                        LtMarca.Text = BUSCA_CAT("Marcas", TMARCA.Text)
                        TMODELO.Text = dr.ReadNullAsEmptyString("MODELO")
                        LtModelo.Text = BUSCA_CAT("Modelo llanta", TMODELO.Text)
                        TMODELO_RENOVADO.Text = dr.ReadNullAsEmptyString("MODELO_RENOVADO")
                        LtModRen.Text = BUSCA_CAT("Modelo llanta", TMODELO_RENOVADO.Text)

                    Catch ex As Exception
                        Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        TPROFUNDIDA_ORIGINAL.Text = dr.ReadNullAsEmptyString("PRO_ORI")
                        TROFUNDIDA_MINIMA.Text = dr.ReadNullAsEmptyString("ROF_MIN")
                        TPROFUNDIDAD_ACTUAL.Text = Math.Round(dr.ReadNullAsEmptyDecimal("PRO_ACT"), 2)
                        TPROFUNDIDAD_ACTUAL.Text = Math.Round(dr.ReadNullAsEmptyDecimal("PRO_ACT2"), 2)
                        TPROFUNDIDAD_ACTUAL.Text = Math.Round(dr.ReadNullAsEmptyDecimal("PRO_ACT3"), 2)
                        TPROFUNDIDAD_ACTUAL.Text = Math.Round(dr.ReadNullAsEmptyDecimal("PRO_ACT4"), 2)

                        TPRESION_MINIMA.Text = dr.ReadNullAsEmptyString("PRE_MIN").ToString
                        TPRESION_ORIGINAL.Text = dr.ReadNullAsEmptyString("PRE_ORI")
                        TPRESION_ACTUAL.Text = dr.ReadNullAsEmptyString("PRE_ACT")

                        TTIPO_LLANTA.Text = dr.ReadNullAsEmptyString("TIPO_LLANTA")
                        LtTipo.Text = BUSCA_CAT("Tipo Llanta", TTIPO_LLANTA.Text)
                    Catch ex As Exception
                        Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        Fecha_Dis_desde.Value = dr.ReadNullAsEmptyString("DIS_DES")
                        TVIDA_UTIL.Text = dr.ReadNullAsEmptyString("VID_UTI")
                        TCOSTO_LLANTA_MN.Text = dr.ReadNullAsEmptyString("COS_LLA_MN")
                        TCOSTO_LLANTA_MN.Tag = dr.ReadNullAsEmptyString("COS_LLA_MN")

                        TCOSTO_LLANTA_DLS.Text = dr.ReadNullAsEmptyString("COS_LLA_DLS")
                        Fecha_Reg.Value = dr.ReadNullAsEmptyString("FECHA_REG")
                        TObs.Text = dr.ReadNullAsEmptyString("DESCR_OBS")
                        TObs.Tag = dr.ReadNullAsEmptyString("CVE_OB")
                        TCUEN_CONT.Text = dr.ReadNullAsEmptyString("CUEN_CONT")

                        TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART")
                        L1.Text = BUSCA_CAT("ArticulosLlantas", TCVE_ART.Text)

                        TKMS_MONTAR.Value = dr.ReadNullAsEmptyDecimal("KMS_MONTAR")
                        TKMS_DESMONTAR.Value = dr.ReadNullAsEmptyDecimal("KMS_DESMONTAR")

                        TKM.Value = Math.Abs(TKMS_DESMONTAR.Value - TKMS_MONTAR.Value)

                        TKMS_ACTUAL.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                        Var6 = ""

                        LtPos.Text = dr.ReadNullAsEmptyString("POSICION")
                        LtTrack.Text = dr.ReadNullAsEmptyString("POSICION2").ToString

                        LtUnidad.Text = LLANTA_ASIGNADA(TCVE_LLANTA.Text)

                        LtTrack.Text = Var6
                        LtPos.Text = dr.ReadNullAsEmptyString("POSICION")


                    Catch ex As Exception
                        Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Else
                    INICIALIZAR_CONTROLES()
                End If
                dr.Close()

                TCVE_LLANTA.Enabled = False
                TNUM_ECONOMICO.Select()
            Catch ex As Exception
                MsgBox("115. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("115. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmLlantasAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Function LLANTA_ASIGNADA(fLLANTA As String) As String
        Dim UNIDAD As String = ""

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If fLLANTA.Trim.Length = 0 Then
                Return False
            End If

            Var6 = ""

            SQL = "Select CLAVE, CLAVEMONTE, CHLL1, CHLL2, CHLL3, CHLL4, CHLL5, CHLL6, CHLL7, CHLL8, CHLL9, CHLL10, CHLL11, CHLL11
                From GCUNIDADES WHERE ISNULL(STATUS, 'A') = 'A' AND (
                CHLL1 = '" & fLLANTA & "' OR CHLL2 = '" & fLLANTA & "' OR CHLL3 = '" & fLLANTA & "' OR CHLL4 = '" & fLLANTA & "' OR
                CHLL5 = '" & fLLANTA & "' OR CHLL6 = '" & fLLANTA & "' OR CHLL7 = '" & fLLANTA & "' OR CHLL8 = '" & fLLANTA & "' OR
                CHLL9 = '" & fLLANTA & "' OR CHLL10 = '" & fLLANTA & "' OR CHLL11 = '" & fLLANTA & "' OR CHLL12 = '" & fLLANTA & "')"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                UNIDAD = dr("CLAVEMONTE")
                If dr("CHLL1") = fLLANTA Then
                    Var6 = "1"
                ElseIf dr("CHLL2") = fLLANTA Then
                    Var6 = "2"
                ElseIf dr("CHLL3") = fLLANTA Then
                    Var6 = "3"
                ElseIf dr("CHLL4") = fLLANTA Then
                    Var6 = "4"
                ElseIf dr("CHLL5") = fLLANTA Then
                    Var6 = "5"
                ElseIf dr("CHLL6") = fLLANTA Then
                    Var6 = "6"
                ElseIf dr("CHLL7") = fLLANTA Then
                    Var6 = "7"
                ElseIf dr("CHLL8") = fLLANTA Then
                    Var6 = "8"
                ElseIf dr("CHLL9") = fLLANTA Then
                    Var6 = "9"
                ElseIf dr("CHLL10") = fLLANTA Then
                    Var6 = "10"
                ElseIf dr("CHLL11") = fLLANTA Then
                    Var6 = "11"
                ElseIf dr("CHLL2") = fLLANTA Then
                    Var6 = "12"
                Else
                    Var6 = ""
                End If
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("475. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("475. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return UNIDAD

    End Function

    Private Sub FrmLlantasAE_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
    End Sub
    Sub INICIALIZAR_CONTROLES()
        Try
            LtUnidad.Text = ""
            LtPos.Text = ""
            TNUM_ECONOMICO.Text = ""
            TO_R.Text = ""
            Fecha_Mon.Value = Now
            TMARCA.Text = ""
            TMODELO.Text = ""
            tMODELO_RENOVADO.Text = ""
            TKM.Value = 0
            TKMS_ACTUAL.Value = 0
            TKMS_MONTAR.Value = 0
            TKMS_DESMONTAR.Value = 0


            TMEDIDA.Text = ""
            TPROFUNDIDA_ORIGINAL.Text = ""
            TROFUNDIDA_MINIMA.Text = ""
            TPROFUNDIDAD_ACTUAL.Text = ""
            TPRESION_MINIMA.Text = ""
            TPRESION_ORIGINAL.Text = ""
            TPRESION_ACTUAL.Text = ""
            TTIPO_LLANTA.Text = ""
            'tSTATUS_LLANTA.Text = ""
            Fecha_Dis_desde.Value = Now
            TVIDA_UTIL.Text = ""
            TCOSTO_LLANTA_MN.Text = ""
            TCOSTO_LLANTA_DLS.Text = ""
            Fecha_Reg.Value = Now
            TObs.Text = ""
            TObs.Tag = "0"
            TCUEN_CONT.Text = ""
        Catch Ex As Exception
            Bitacora("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("120. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_OBS As Long, Exist As Boolean, CVE_LLANTA As String, PROFUNDIDAD As Decimal, COSTO As Decimal = 0, OBSER_BIT As String
        Dim CVE_DOC As String = "DLL" & Now.ToShortDateString.Replace("/", "") & Now.Hour & Now.Minute
        Dim CVE_UNIDAD As String

        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If TNUM_ECONOMICO.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el número económico")
            TCVE_ART.Focus()
            Return
        End If
        If TTIPO_LLANTA.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture tipo de llanta")
            TTIPO_LLANTA.Focus()
            Return
        End If

        If TCVE_LLANTA.Text.Trim.Length = 0 Then
            TCVE_LLANTA.Text = GET_MAX("GCLLANTAS", "CVE_LLANTA")
        End If

        If NewLlanta Then
            CVE_UNIDAD = EXIST_NUM_ECONOMICO(TNUM_ECONOMICO.Text)
            If CVE_UNIDAD.Trim.Length > 0 Then
                MsgBox("El número económico ya se encuentra asignado en la unidad (" & CVE_UNIDAD & "), verifique por favor")
                Return
            End If
        End If
        Try
            TKM.UpdateValueWithCurrentText()
            TKMS_ACTUAL.UpdateValueWithCurrentText()
            TKMS_MONTAR.UpdateValueWithCurrentText()
            TKMS_DESMONTAR.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If TCVE_ART.Text.Trim.Length > 0 Then
            Try
                Exist = False
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_ART, TIPO_ELE, ULT_COSTO FROM INVE" & Empresa & " WHERE CVE_ART = '" & TCVE_ART.Text.Trim & "'"
                    cmd2.CommandText = SQL
                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                        If dr2.Read Then
                            If dr2.ReadNullAsEmptyString("TIPO_ELE") = "P" Then
                                Exist = True
                                COSTO = dr2.ReadNullAsEmptyDecimal("ULT_COSTO")
                            End If
                        End If
                    End Using
                End Using
                If Not Exist Then
                    MsgBox("La clave del artículo no existe o no es un producto, verifique por favor")
                    Return
                End If
            Catch ex As Exception
                Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        Try
            If TNUM_ECONOMICO.Text.Trim.Length > 0 Then
                CVE_LLANTA = ""
                Dim dr As SqlDataReader

                SQL = "SELECT CVE_LLANTA, NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND 
                        CVE_LLANTA <> '" & TCVE_LLANTA.Text & "' AND NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
                Exist = False
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    CVE_LLANTA = dr("CVE_LLANTA")
                    Exist = True
                End If
                dr.Close()

                If Exist Then
                    MsgBox("El número económico actualmente se encuentra asignado a la llanta  " & CVE_LLANTA)
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("130. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If TObs.Text.Trim.Length > 0 Then

                CVE_OBS = TObs.Tag

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS), @OBS_STR)"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                        cmd.Parameters.Add("@OBS_STR", SqlDbType.VarChar).Value = TObs.Text
                        returnValue = cmd.ExecuteScalar.ToString
                        If returnValue IsNot Nothing Then
                            If CLng(returnValue) > 0 Then
                                If IsNumeric(returnValue.ToString) Then
                                    CVE_OBS = returnValue.ToString
                                Else
                                    CVE_OBS = 0
                                End If
                            Else
                                CVE_OBS = 0
                            End If
                        Else
                            CVE_OBS = 0
                        End If
                    Catch ex As Exception
                        Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            End If

            TKMS_ACTUAL.UpdateValueWithCurrentText()
            TKM.UpdateValueWithCurrentText()
            TKMS_MONTAR.UpdateValueWithCurrentText()
            TKMS_DESMONTAR.UpdateValueWithCurrentText()
        Catch ex As Exception
            CVE_OBS = 0
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        If IsNumeric(TPROFUNDIDAD_ACTUAL.Text) Then
            PROFUNDIDAD = TPROFUNDIDAD_ACTUAL.Text
        Else
            PROFUNDIDAD = 0
        End If
        'SET IDENTITY_INSERT GCLLANTAS OFF
        'SET IDENTITY_INSERT GCLLANTAS ON
        SQL = "
         IF EXISTS (SELECT CVE_LLANTA FROM GCLLANTAS WHERE NUM_ECONOMICO = @NUM_ECONOMICO)
            UPDATE GCLLANTAS SET CVE_LLANTA = @CVE_LLANTA, NUM_ECONOMICO = @NUM_ECONOMICO, POSICION = @POSICION, POSICION2 = @POSICION2, O_R = @O_R, FECHA_MON = @FECHA_MON, 
            MARCA = @MARCA, MODELO = @MODELO, MODELO_RENOVADO = @MODELO_RENOVADO, KM = @KM, MEDIDA = @MEDIDA, PROFUNDIDA_ORIGINAL = @PROFUNDIDA_ORIGINAL, 
            ROFUNDIDA_MINIMA = @ROFUNDIDA_MINIMA, PROFUNDIDAD_ACTUAL = @PROFUNDIDAD_ACTUAL, PRESION_MINIMA = @PRESION_MINIMA, 
            PRESION_ORIGINAL = @PRESION_ORIGINAL, PRESION_ACTUAL = @PRESION_ACTUAL, TIPO_LLANTA = @TIPO_LLANTA, DISPONIBLE_DESDE = @DISPONIBLE_DESDE, 
            VIDA_UTIL = @VIDA_UTIL, COSTO_LLANTA_MN = @COSTO_LLANTA_MN, COSTO_LLANTA_DLS = @COSTO_LLANTA_DLS, FECHA_REG = @FECHA_REG, CVE_OBS = @CVE_OBS, 
            CUEN_CONT = @CUEN_CONT, KMS_MONTAR = @KMS_MONTAR, KMS_DESMONTAR = @KMS_DESMONTAR, CVE_ART = @CVE_ART, TIPO_NUEVA_RENO = @TIPO_NUEVA_RENO,
            NO_RENOVADOS = @NO_RENOVADOS, KMS_ACTUAL = @KMS_ACTUAL, DOT = @DOT, CVE_MARCA = @CVE_MARCA, CVE_PRE = @CVE_PRE
            WHERE NUM_ECONOMICO = @NUM_ECONOMICO
        ELSE
            INSERT INTO GCLLANTAS (CVE_LLANTA, NUM_ECONOMICO, STATUS, TIPO_NUEVA_RENO, POSICION, POSICION2, O_R, FECHA_MON, MARCA, MODELO, MODELO_RENOVADO, 
            KM, MEDIDA, PROFUNDIDA_ORIGINAL, ROFUNDIDA_MINIMA, PROFUNDIDAD_ACTUAL, PRESION_MINIMA, PRESION_ORIGINAL, PRESION_ACTUAL, TIPO_LLANTA, 
            STATUS_LLANTA, DISPONIBLE_DESDE, VIDA_UTIL, COSTO_LLANTA_MN, COSTO_LLANTA_DLS, FECHA_REG, CVE_OBS, CUEN_CONT, KMS_MONTAR, KMS_DESMONTAR, 
            CVE_ART, FECHAELAB, NO_RENOVADOS, KMS_ACTUAL, DOT, CVE_MARCA, CVE_PRE)
            VALUES (
            @CVE_LLANTA, @NUM_ECONOMICO, 'A', 0, @POSICION, @POSICION2, @O_R, @FECHA_MON, @MARCA, @MODELO, @MODELO_RENOVADO, @KM, @MEDIDA, 
            @PROFUNDIDA_ORIGINAL, @ROFUNDIDA_MINIMA, @PROFUNDIDAD_ACTUAL, @PRESION_MINIMA, @PRESION_ORIGINAL, @PRESION_ACTUAL, @TIPO_LLANTA, '2',
            @DISPONIBLE_DESDE, @VIDA_UTIL, @COSTO_LLANTA_MN, @COSTO_LLANTA_DLS, @FECHA_REG, @CVE_OBS, @CUEN_CONT, @KMS_MONTAR, @KMS_DESMONTAR, 
            @CVE_ART, GETDATE(), @NO_RENOVADOS, @KMS_ACTUAL, @DOT, @CVE_MARCA, @CVE_PRE)"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CVE_LLANTA", SqlDbType.VarChar).Value = TCVE_LLANTA.Text
            cmd.Parameters.Add("@POSICION", SqlDbType.VarChar).Value = LtPos.Text
            cmd.Parameters.Add("@POSICION2", SqlDbType.VarChar).Value = LtTrack.Text
            cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TNUM_ECONOMICO.Text
            cmd.Parameters.Add("@O_R", SqlDbType.VarChar).Value = TO_R.Text
            cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Fecha_Mon.Value
            cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = TMARCA.Text
            cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = TMODELO.Text
            cmd.Parameters.Add("@MODELO_RENOVADO", SqlDbType.VarChar).Value = tMODELO_RENOVADO.Text
            cmd.Parameters.Add("@KM", SqlDbType.Float).Value = Math.Round(TKM.Value, 2)
            cmd.Parameters.Add("@MEDIDA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TMEDIDA.Text), 2)
            cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPROFUNDIDA_ORIGINAL.Text), 2)
            cmd.Parameters.Add("@ROFUNDIDA_MINIMA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TROFUNDIDA_MINIMA.Text), 2)
            cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = Math.Round(PROFUNDIDAD, 2)
            cmd.Parameters.Add("@PRESION_MINIMA", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRESION_MINIMA.Text), 2)
            cmd.Parameters.Add("@PRESION_ORIGINAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRESION_ORIGINAL.Text), 2)
            cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TPRESION_ACTUAL.Text), 2)
            cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA.Text
            cmd.Parameters.Add("@DISPONIBLE_DESDE", SqlDbType.Date).Value = Fecha_Dis_desde.Value
            cmd.Parameters.Add("@VIDA_UTIL", SqlDbType.VarChar).Value = TVIDA_UTIL.Text
            cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTO_LLANTA_MN.Text), 2)
            cmd.Parameters.Add("@COSTO_LLANTA_DLS", SqlDbType.Float).Value = Math.Round(CONVERTIR_TO_DECIMAL(TCOSTO_LLANTA_DLS.Text), 2)
            cmd.Parameters.Add("@FECHA_REG", SqlDbType.Date).Value = Fecha_Reg.Value
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = TCUEN_CONT.Text
            cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_MONTAR.Value
            cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = TKMS_DESMONTAR.Value
            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text.Trim
            cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.SmallInt).Value = IIf(RadNueva.Checked, 0, 1)
            cmd.Parameters.Add("@NO_RENOVADOS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TNO_RENOVADOS.Text)
            cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL.Value
            cmd.Parameters.Add("@DOT", SqlDbType.VarChar).Value = TDOT.Text
            cmd.Parameters.Add("@CVE_MARCA", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TMARCA_RENO.Text)
            cmd.Parameters.Add("@CVE_PRE", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TPROV_RENO.Text)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    Try
                        If CONVERTIR_TO_DECIMAL(TPROFUNDIDAD_ACTUAL.Text) > 0 Then
                            SQL = "IF NOT EXISTS (SELECT CVE_LLANTA FROM GCLLANTAS_DESGASTE WHERE CVE_LLANTA = '" & TCVE_LLANTA.Text & "' AND " &
                                "PROFUNDIDAD = " & TPROFUNDIDAD_ACTUAL.Text & ") " &
                                "INSERT INTO GCLLANTAS_DESGASTE (CVE_LLANTA, PROFUNDIDAD, STATUS, FECHAELAB, UUID) VALUES ('" & TCVE_LLANTA.Text & "','" &
                                CONVERTIR_TO_DECIMAL(TPROFUNDIDAD_ACTUAL.Text) & "','A',GETDATE(), NEWID())"
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
                        Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If NewLlanta Then
                            SQL = "INSERT INTO GCLLANTAS_MINVE (CVE_DOC, TIP_DOC, CVE_ART, NUM_PAR, NUM_MOV, TIPO_LLANTA, FECHA, CVE_UNI, NUM_ECONOMICO, 
                                COSTO, USUARIO, FECHAELAB, UUID) VALUES (@CVE_DOC, @TIP_DOC, @CVE_ART, 1, 0, 'N', CONVERT(varchar, GETDATE(), 112), 
                                @CVE_UNI, @NUM_ECONOMICO, @COSTO, @USUARIO, GETDATE(), NEWID())"
                            Try
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    cmd2.Parameters.Add("@CVE_DOC", SqlDbType.VarChar).Value = CVE_DOC
                                    cmd2.Parameters.Add("@TIP_DOC", SqlDbType.VarChar).Value = "M"
                                    cmd2.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text.Trim
                                    cmd2.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = TTIPO_LLANTA.Text
                                    cmd2.Parameters.Add("@NUM_MOV", SqlDbType.Int).Value = 0
                                    cmd2.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = ""
                                    cmd2.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TNUM_ECONOMICO.Text
                                    cmd2.Parameters.Add("@COSTO", SqlDbType.Float).Value = COSTO
                                    cmd2.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE
                                    returnValue = cmd2.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                    'CVE_DOC, TIP_DOC, NUM_ECONOMICO
                                End Using
                            Catch ex As Exception
                                MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        Else
                            FrmLlantas.Fg(r_, 1) = TCVE_LLANTA.Text
                            FrmLlantas.Fg(r_, 5) = TNUM_ECONOMICO.Text
                            FrmLlantas.Fg(r_, 7) = TO_R.Text
                            FrmLlantas.Fg(r_, 8) = Fecha_Mon.Value
                            FrmLlantas.Fg(r_, 9) = LtMarca.Text
                            FrmLlantas.Fg(r_, 10) = LtModelo.Text
                            FrmLlantas.Fg(r_, 11) = TTIPO_LLANTA.Text
                            FrmLlantas.Fg(r_, 12) = CONVERTIR_TO_DECIMAL(TCOSTO_LLANTA_MN.Text)
                            FrmLlantas.Fg(r_, 18) = TKMS_MONTAR.Value
                            FrmLlantas.Fg(r_, 21) = CONVERTIR_TO_DECIMAL(TNO_RENOVADOS.Text)
                        End If
                    Catch ex As Exception
                        MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If Not IsNumeric(TCOSTO_LLANTA_MN.Text) Then
                        TCOSTO_LLANTA_MN.Text = "0"
                    End If

                    If NewLlanta Then
                        OBSER_BIT = "Nueva llanta pos " & LtPos.Text & " " & LtTrack.Text & " COSTO " & TCOSTO_LLANTA_MN.Text
                    Else
                        OBSER_BIT = "Se modifico llanta pos " & LtPos.Text & " " & LtTrack.Text &
                            " costo nuevo " & TCOSTO_LLANTA_MN.Text & " costo anterior " & TCOSTO_LLANTA_MN.Tag
                    End If
                    'GRABA_BITA(tPROV.Text, CVE_DOC, COSTO, TIPO_COMPRA_LOCAL," Renovada llanta num. economico " & dr("NUM_ECONOMICO") & " Doc. ant. " & DOC_ENL)
                    GRABA_BITA(TCVE_LLANTA.Text, TNUM_ECONOMICO.Text, TCOSTO_LLANTA_MN.Text, "L", OBSER_BIT, "", "", "")

                    MsgBox("El registro se grabo satisfactoriamente")

                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If

        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMod_Click(sender As Object, e As EventArgs) Handles BtnMod.Click
        Try
            Var2 = "Modelo Llanta"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMODELO.Text = Var4
                LtModelo.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TTIPO_LLANTA.Select()

            End If
        Catch ex As Exception
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnModRen_Click(sender As Object, e As EventArgs) Handles BtnModRen.Click
        Try
            Var2 = "Modelo Renovado"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tMODELO_RENOVADO.Text = Var4
                LtModRen.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TMARCA.Select()
            End If
        Catch ex As Exception
            MsgBox("230. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMarca_Click(sender As Object, e As EventArgs) Handles BtnMarca.Click
        Try
            Var2 = "Marca"
            Var4 = ""
            Var5 = ""
            'tabla GCMARCAS
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMARCA.Text = Var4
                LtMarca.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TMEDIDA.Select()
            End If
        Catch ex As Exception
            MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnMarcaRen_Click(sender As Object, e As EventArgs) Handles BtnMarcaRen.Click
        Try
            Var2 = "Medidas Llanta"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMEDIDA.Text = Var4
                LtMarRen.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TO_R.Select()
            End If
        Catch ex As Exception
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnTipoLlanta_Click(sender As Object, e As EventArgs) Handles BtnTipoLlanta.Click
        Try
            Var2 = "Tipo Llanta"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TTIPO_LLANTA.Text = Var4
                LtTipo.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tMODELO_RENOVADO.Select()
            End If
        Catch ex As Exception
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnStatusLLanta_Click(sender As Object, e As EventArgs)
        Try
            'CLLANTA_STATUS"
            Var2 = "Status Llanta"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLANTA_ASIGNADA_UNIDADES(TCVE_LLANTA.Text) Then
                    MsgBox("La llanta se encuentra actualmente asignada no se puede cambiar el estatus")
                End If
                'tSTATUS_LLANTA.Text = Var4
                'LtStatus.Text = Var5
            End If
            Var2 = ""
            Var4 = ""
            Var5 = ""
        Catch ex As Exception
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnUnidad_Click(sender As Object, e As EventArgs)
        Try
            'CLLANTA_STATUS"
            Var2 = "Medidas Llanta"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var5.Trim.Length > 0 Then
                LtUnidad.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TMODELO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMODELO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMod_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMODELO_RENOVADO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMODELO_RENOVADO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnModRen_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMARCA_KeyDown(sender As Object, e As KeyEventArgs) Handles TMARCA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMarca_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TMARCA_RENOVADO_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            BtnMarcaRen_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TTIPO_LLANTA_KeyDown(sender As Object, e As KeyEventArgs) Handles TTIPO_LLANTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTipoLlanta_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TSTATUS_LLANTA_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            BtnStatusLLanta_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub BtnLlantaM10_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "10"
    End Sub

    Private Sub BtnLlantaM6_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "6"
    End Sub

    Private Sub BtnLlantaM1_Click(sender As Object, e As EventArgs)

        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "1"

    End Sub

    Private Sub BtnLlantaM2_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "2"
    End Sub

    Private Sub BtnLlantaM3_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "3"
    End Sub

    Private Sub BtnLlantaM4_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "4"
    End Sub

    Private Sub BtnLlantaM5_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "5"
    End Sub

    Private Sub BtnLlantaM7_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "7"
    End Sub

    Private Sub BtnLlantaM8_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "8"
    End Sub

    Private Sub BtnLlantaM9_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR M-102"
        LtPos.Text = "9"
    End Sub

    Private Sub BtnLlantaT1_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "1"
    End Sub

    Private Sub BtnLlantaT2_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "2"
    End Sub

    Private Sub BtnLlantaT3_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "3"
    End Sub

    Private Sub BtnLlantaT4_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "4"
    End Sub

    Private Sub BtnLlantaT5_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "5"
    End Sub

    Private Sub BtnLlantaT6_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "6"
    End Sub

    Private Sub BtnLlantaT7_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "7"
    End Sub

    Private Sub BtnLlantaT8_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "8"
    End Sub

    Private Sub BtnLlantaT9_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "9"
    End Sub

    Private Sub BtnLlantaT10_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "10"
    End Sub

    Private Sub BtnLlantaT11_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "11"
    End Sub

    Private Sub BtnLlantaT12_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TRACTOR T-120"
        LtPos.Text = "12"
    End Sub

    Private Sub BtnLlantaD1_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "13"
    End Sub

    Private Sub BtnLlantaD2_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "14"
    End Sub

    Private Sub BtnLlantaD3_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "15"
    End Sub

    Private Sub BtnLlantaD4_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "16"
    End Sub

    Private Sub BtnLlantaD5_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "17"
    End Sub

    Private Sub BtnLlantaD6_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "18"
    End Sub

    Private Sub BtnLlantaD7_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "19"
    End Sub

    Private Sub BtnLlantaD8_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "DOLLY D-002"
        LtPos.Text = "20"
    End Sub

    Private Sub BtnLlantaQ1_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "1"
    End Sub

    Private Sub BtnLlantaQ2_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "2"
    End Sub

    Private Sub BtnLlantaQ3_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "3"
    End Sub

    Private Sub BtnLlantaQ4_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "4"
    End Sub

    Private Sub BtnLlantaQ5_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "5"
    End Sub

    Private Sub BtnLlantaQ6_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "6"
    End Sub

    Private Sub BtnLlantaQ7_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "7"
    End Sub

    Private Sub BtnLlantaQ8_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "8"
    End Sub

    Private Sub BtnLlantaQ9_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "9"
    End Sub

    Private Sub BtnLlantaQ10_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "10"
    End Sub

    Private Sub BtnLlantaQ11_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "11"
    End Sub

    Private Sub BtnLlantaQ12_Click(sender As Object, e As EventArgs)
        LtTrack.Text = "TANQUE T-130"
        LtPos.Text = "12"
    End Sub

    Private Sub FrmLlantasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Movimientos Llantas")
            Me.Dispose()
            If FORM_IS_OPEN("frmLlantas") Then
                FrmLlantas.DESPLEGAR2()
            End If
        Catch ex As Exception
            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TNUM_ECONOMICO_Validated(sender As Object, e As EventArgs) Handles TNUM_ECONOMICO.Validated
        Try
            If TNUM_ECONOMICO.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_LLANTA FROM GCLLANTAS WHERE STATUS <> 'B' AND CVE_LLANTA <> '" & TCVE_LLANTA.Text & "' AND 
                        NUM_ECONOMICO = '" & TNUM_ECONOMICO.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("El número economico ya fue asignado a la llanta con clave " & dr("CVE_LLANTA"))
                            TNUM_ECONOMICO.Text = ""
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnOR_Click(sender As Object, e As EventArgs) Handles btnOR.Click
        Try
            Var2 = "Tipo Llanta"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TO_R.Text = Var4
                LtOR.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TKM.Select()
            End If
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TO_R_Validated(sender As Object, e As EventArgs) Handles TO_R.Validated
        Try
            If TO_R.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo Llanta", TO_R.Text)
                If DESCR <> "" Then
                    LtOR.Text = DESCR
                    TKM.Focus()
                Else
                    MsgBox("Tipo llanta inexistente")
                    TO_R.Text = ""
                    LtOR.Text = ""
                    TO_R.Select()
                End If
            Else
                LtOR.Text = ""
            End If
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TMEDIDA_KeyDown(sender As Object, e As KeyEventArgs) Handles TMEDIDA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMarcaRen_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TMEDIDA_Validated(sender As Object, e As EventArgs) Handles TMEDIDA.Validated
        Try
            If TMEDIDA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Medidas Llanta", TMEDIDA.Text)
                If DESCR <> "" Then
                    LtMarRen.Text = DESCR
                    TO_R.Focus()
                Else
                    MsgBox("Medidas Llanta inexistente")
                    LtMarRen.Text = ""
                    TMEDIDA.Text = ""
                    TMEDIDA.Select()
                End If
            Else
                LtMarRen.Text = ""
            End If
        Catch ex As Exception
            Bitacora("440. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("440. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProdundidad_Click(sender As Object, e As EventArgs) Handles BtnProdundidad.Click
        Try
            If TCVE_LLANTA.Text.Trim.Length > 0 Then
                Var10 = TCVE_LLANTA.Text
                FrmLLantasHistorialDesgaste.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TO_R_KeyDown(sender As Object, e As KeyEventArgs) Handles TO_R.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOR_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TMODELO_Validated(sender As Object, e As EventArgs) Handles TMODELO.Validated
        Try
            If TMODELO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Modelo llanta", TMODELO.Text)
                If DESCR <> "" Then
                    LtModelo.Text = DESCR
                    TTIPO_LLANTA.Focus()
                Else
                    MsgBox("Modelo inexistente")
                    LtModelo.Text = ""
                    TMODELO.Text = ""
                    TMODELO.Select()
                End If
            Else
                LtModelo.Text = ""
            End If
        Catch ex As Exception
            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TTIPO_LLANTA_Validated(sender As Object, e As EventArgs) Handles TTIPO_LLANTA.Validated
        Try
            If TTIPO_LLANTA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo Llanta", TTIPO_LLANTA.Text)
                If DESCR <> "" Then
                    LtTipo.Text = DESCR
                    tMODELO_RENOVADO.Focus()
                Else
                    MsgBox("Tipo Llanta inexistente")
                    LtTipo.Text = ""
                    TTIPO_LLANTA.Text = ""
                    TTIPO_LLANTA.Select()
                End If
            Else
                LtTipo.Text = ""
            End If
        Catch ex As Exception
            Bitacora("540. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("540. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TMODELO_RENOVADO_Validated(sender As Object, e As EventArgs) Handles tMODELO_RENOVADO.Validated
        Try
            If tMODELO_RENOVADO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Modelo Renovado", tMODELO_RENOVADO.Text)
                If DESCR <> "" Then
                    LtModRen.Text = DESCR
                    TMARCA.Focus()
                Else
                    MsgBox("Modelo renovado inexistente")
                    LtModRen.Text = ""
                    tMODELO_RENOVADO.Text = ""
                    tMODELO_RENOVADO.Select()
                End If
            Else
                LtModRen.Text = ""
            End If
        Catch ex As Exception
            Bitacora("560. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("560. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TMARCA_Validated(sender As Object, e As EventArgs) Handles TMARCA.Validated
        Try
            If TMARCA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Marca", TMARCA.Text)
                If DESCR <> "" Then
                    LtMarca.Text = DESCR
                    TMEDIDA.Focus()
                Else
                    MsgBox("Marca inexistente")
                    LtMarca.Text = ""
                    TMARCA.Text = ""
                    TMARCA.Select()
                End If
            Else
                LtMarca.Text = ""
            End If
        Catch ex As Exception
            Bitacora("900. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("900. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnArt_Click(sender As Object, e As EventArgs) Handles BtnArt.Click
        Try
            Var2 = "ArticulosLlantas"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                L1.Text = Var5
                TMODELO.Focus()
            Else
                TCVE_ART.Focus()
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArt_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ArticulosLlantas", TCVE_ART.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                    TMODELO.Focus()
                Else
                    MsgBox("Articulo inexistente o es un servicio")
                    L1.Text = ""
                    TCVE_ART.Text = ""
                    TCVE_ART.Select()
                End If
            Else
                L1.Text = ""
            End If
        Catch ex As Exception
            MsgBox("103. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("103. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnMax_Click(sender As Object, e As EventArgs) Handles BtnMax.Click
        Try
            TNUM_ECONOMICO.Text = GET_MAX("GCLLANTAS", "NUM_ECONOMICO")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnMarcaReno_Click(sender As Object, e As EventArgs) Handles BtnMarcaReno.Click
        Try
            Var2 = "Marca reno"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TMARCA_RENO.Text = Var4
                LtMarca_Reno.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TPROV_RENO.Focus()
            End If
        Catch Ex As Exception
            Bitacora("70. ex.Message: " & Ex.Message & vbNewLine & "ex.StackTrace:" & Ex.StackTrace)
            MsgBox("70. ex.Message: " & Ex.Message & vbNewLine & "ex.StackTrace:" & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TMARCA_RENO_KeyDown(sender As Object, e As KeyEventArgs) Handles TMARCA_RENO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnMarcaReno_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TMARCA_RENO_Validated(sender As Object, e As EventArgs) Handles TMARCA_RENO.Validated
        Try
            If TMARCA_RENO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT2("Marca reno", TMARCA_RENO.Text)
                If DESCR <> "" Then
                    LtMarca_Reno.Text = DESCR
                Else
                    MsgBox("Marca renovado inexistente")
                    TMARCA_RENO.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("62. ex.Message: " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
            MsgBox("62. ex.Message: " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnProvReno_Click(sender As Object, e As EventArgs) Handles BtnProvReno.Click
        Try
            Var2 = "Prov reno"
            Var4 = "" : Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TPROV_RENO.Text = Var4
                LtProv_Reno.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                Fecha_Mon.Focus()
            End If
        Catch Ex As Exception
            Bitacora("70. ex.Message: " & Ex.Message & vbNewLine & "ex.StackTrace:" & Ex.StackTrace)
            MsgBox("70. ex.Message: " & Ex.Message & vbNewLine & "ex.StackTrace:" & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TPROV_RENO_KeyDown(sender As Object, e As KeyEventArgs) Handles TPROV_RENO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProvReno_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TPROV_RENO_Validated(sender As Object, e As EventArgs) Handles TPROV_RENO.Validated
        Try
            If TPROV_RENO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT2("Prov reno", TPROV_RENO.Text)
                If DESCR <> "" Then
                    LtProv_Reno.Text = DESCR
                Else
                    MsgBox("Proveedor renovado inexistente")
                    TPROV_RENO.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("62. ex.Message: " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
            MsgBox("62. ex.Message: " & ex.Message & vbNewLine & "ex.StackTrace:" & ex.StackTrace)
        End Try
    End Sub
End Class
