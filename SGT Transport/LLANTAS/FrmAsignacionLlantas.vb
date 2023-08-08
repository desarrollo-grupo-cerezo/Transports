Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmAsignacionLlantas
    Private NO_UPDATE As Boolean = False
    Private PTIPO_LLANTA As Integer
    Private Boton As Integer
    Private Sub frmAsignacionLlantas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

            BtnUnidades.FlatStyle = FlatStyle.Flat
            BtnUnidades.FlatAppearance.BorderSize = 0

            For Each button In GroupBox2.Controls

                If button.GetType.ToString = "C1.Win.C1Input.C1Button" Then
                    button.FlatStyle = FlatStyle.Flat
                    button.FlatAppearance.BorderSize = 0
                End If
                Debug.Print(button.GetType.ToString)
            Next

            TKMS_ACTUAL1.Value = 0
            TKMS_ACTUAL2.Value = 0
            TKMS_ACTUAL3.Value = 0
            TKMS_ACTUAL4.Value = 0
            TKMS_ACTUAL5.Value = 0
            TKMS_ACTUAL6.Value = 0
            TKMS_ACTUAL7.Value = 0
            TKMS_ACTUAL8.Value = 0
            TKMS_ACTUAL9.Value = 0
            TKMS_ACTUAL10.Value = 0
            TKMS_ACTUAL11.Value = 0
            TKMS_ACTUAL12.Value = 0

            AssignValidation(Me.TPROFUNDIDAD_ACTUAL1, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL2, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL3, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL4, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL5, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL6, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL7, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL8, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL9, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL10, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL11, ValidationType.Only_Numbers)
            AssignValidation(Me.TPROFUNDIDAD_ACTUAL12, ValidationType.Only_Numbers)

        Catch ex As Exception
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Me.KeyPreview = True

            'Var15 = "1" ASIGNAR LLANTAS
            'Var15 = "2" DESASIGNAR LLANTAS

            PTIPO_LLANTA = CInt(Var15)

            LL1.Tag = "" : LL2.Tag = "" : LL3.Tag = "" : LL4.Tag = "" : LL5.Tag = "" : LL6.Tag = ""
            LL7.Tag = "" : LL8.Tag = "" : LL9.Tag = "" : LL10.Tag = "" : LL11.Tag = "" : LL12.Tag = ""

            TLL1.Tag = "" : TLL2.Tag = "" : TLL3.Tag = "" : TLL4.Tag = "" : TLL5.Tag = "" : TLL6.Tag = ""
            TLL7.Tag = "" : TLL8.Tag = "" : TLL9.Tag = "" : TLL10.Tag = "" : TLL11.Tag = "" : TLL12.Tag = ""

            Ls1.Tag = "" : Ls2.Tag = "" : Ls3.Tag = "" : Ls4.Tag = "" : Ls5.Tag = "" : Ls6.Tag = ""
            Ls7.Tag = "" : Ls8.Tag = "" : Ls9.Tag = "" : Ls10.Tag = "" : Ls11.Tag = "" : Ls12.Tag = ""

            If PTIPO_LLANTA = 1 Then
                Me.Text = "Asignación llantas"
                Lt1.Text = "Asignación llantas"
                ChDesT.Visible = False
                ChDes1.Visible = False : ChDes2.Visible = False : ChDes3.Visible = False : ChDes4.Visible = False : ChDes5.Visible = False : ChDes6.Visible = False
                ChDes7.Visible = False : ChDes8.Visible = False : ChDes9.Visible = False : ChDes10.Visible = False : ChDes11.Visible = False : ChDes12.Visible = False

                Ls1.Visible = True : Ls2.Visible = True : Ls3.Visible = True : Ls4.Visible = True : Ls5.Visible = True : Ls6.Visible = True
                Ls7.Visible = True : Ls8.Visible = True : Ls9.Visible = True : Ls10.Visible = True : Ls11.Visible = True : Ls12.Visible = True

                CboStatusLlanta1.Visible = False : CboStatusLlanta2.Visible = False : CboStatusLlanta3.Visible = False : CboStatusLlanta4.Visible = False : CboStatusLlanta5.Visible = False : CboStatusLlanta6.Visible = False
                CboStatusLlanta7.Visible = False : CboStatusLlanta8.Visible = False : CboStatusLlanta9.Visible = False : CboStatusLlanta10.Visible = False : CboStatusLlanta11.Visible = False : CboStatusLlanta12.Visible = False
            Else
                Me.Text = "Desasignación llantas"
                Lt1.Text = "Desasignación llantas"
                ChDesT.Visible = True
                Btn1.Visible = False : Btn2.Visible = False : Btn3.Visible = False : Btn4.Visible = False : Btn5.Visible = False : Btn6.Visible = False
                Btn7.Visible = False : Btn8.Visible = False : Btn9.Visible = False : Btn10.Visible = False : Btn11.Visible = False : Btn12.Visible = False
                ChDes1.Left = Btn1.Left : ChDes2.Left = Btn2.Left : ChDes3.Left = Btn3.Left : ChDes4.Left = Btn4.Left : ChDes5.Left = Btn5.Left : ChDes6.Left = Btn6.Left
                ChDes7.Left = Btn7.Left : ChDes8.Left = Btn8.Left : ChDes9.Left = Btn9.Left : ChDes10.Left = Btn10.Left : ChDes11.Left = Btn11.Left : ChDes12.Left = Btn12.Left
                TLL1.ReadOnly = True : TLL2.ReadOnly = True : TLL3.ReadOnly = True : TLL4.ReadOnly = True : TLL5.ReadOnly = True : TLL6.ReadOnly = True
                TLL7.ReadOnly = True : TLL8.ReadOnly = True : TLL9.ReadOnly = True : TLL10.ReadOnly = True : TLL11.ReadOnly = True : TLL12.ReadOnly = True
                ChDesT.Left = Btn7.Left

                Ls1.Visible = False : Ls2.Visible = False : Ls3.Visible = False : Ls4.Visible = False : Ls5.Visible = False : Ls6.Visible = False
                Ls7.Visible = False : Ls8.Visible = False : Ls9.Visible = False : Ls10.Visible = False : Ls11.Visible = False : Ls12.Visible = False

                LLENAR_COMBOS_STATUS_LLANTAS()

            End If

            LL1.Tag = "" : LL2.Tag = "" : LL3.Tag = "" : LL4.Tag = "" : LL5.Tag = "" : LL6.Tag = ""
            LL7.Tag = "" : LL8.Tag = "" : LL9.Tag = "" : LL10.Tag = "" : LL11.Tag = "" : LL12.Tag = ""
            TCVE_UNI.Select()

            Var14 = "" : Var15 = ""
        Catch ex As Exception
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_COMBOS_STATUS_LLANTAS()
        Try
            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Clave", GetType(System.String))
            dt.Columns.Add("Descripcion", GetType(System.String))

            CboStatusLlanta1.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCLLANTA_STATUS ORDER BY TRY_PARSE(CVE_STATUS AS INT)"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        dt.Rows.Add(dr("CVE_STATUS"), dr("DESCR"))
                    End While
                End Using
            End Using

            CboStatusLlanta1.TextDetached = True
            CboStatusLlanta1.ItemsDataSource = dt.DefaultView
            CboStatusLlanta1.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta1.ItemsValueMember = "Clave"
            CboStatusLlanta1.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta1.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta2.TextDetached = True
            CboStatusLlanta2.ItemsDataSource = dt.DefaultView
            CboStatusLlanta2.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta2.ItemsValueMember = "Clave"
            CboStatusLlanta2.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta2.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta3.TextDetached = True
            CboStatusLlanta3.ItemsDataSource = dt.DefaultView
            CboStatusLlanta3.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta3.ItemsValueMember = "Clave"
            CboStatusLlanta3.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta3.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta4.TextDetached = True
            CboStatusLlanta4.ItemsDataSource = dt.DefaultView
            CboStatusLlanta4.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta4.ItemsValueMember = "Clave"
            CboStatusLlanta4.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta4.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta5.TextDetached = True
            CboStatusLlanta5.ItemsDataSource = dt.DefaultView
            CboStatusLlanta5.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta5.ItemsValueMember = "Clave"
            CboStatusLlanta5.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta5.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta6.TextDetached = True
            CboStatusLlanta6.ItemsDataSource = dt.DefaultView
            CboStatusLlanta6.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta6.ItemsValueMember = "Clave"
            CboStatusLlanta6.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta6.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta7.TextDetached = True
            CboStatusLlanta7.ItemsDataSource = dt.DefaultView
            CboStatusLlanta7.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta7.ItemsValueMember = "Clave"
            CboStatusLlanta7.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta7.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta8.TextDetached = True
            CboStatusLlanta8.ItemsDataSource = dt.DefaultView
            CboStatusLlanta8.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta8.ItemsValueMember = "Clave"
            CboStatusLlanta8.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta8.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta9.TextDetached = True
            CboStatusLlanta9.ItemsDataSource = dt.DefaultView
            CboStatusLlanta9.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta9.ItemsValueMember = "Clave"
            CboStatusLlanta9.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta9.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta10.TextDetached = True
            CboStatusLlanta10.ItemsDataSource = dt.DefaultView
            CboStatusLlanta10.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta10.ItemsValueMember = "Clave"
            CboStatusLlanta10.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta10.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta11.TextDetached = True
            CboStatusLlanta11.ItemsDataSource = dt.DefaultView
            CboStatusLlanta11.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta11.ItemsValueMember = "Clave"
            CboStatusLlanta11.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta11.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

            CboStatusLlanta12.TextDetached = True
            CboStatusLlanta12.ItemsDataSource = dt.DefaultView
            CboStatusLlanta12.ItemsDisplayMember = "Descripcion"
            CboStatusLlanta12.ItemsValueMember = "Clave"
            CboStatusLlanta12.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboStatusLlanta12.HtmlPattern = "<table><tr><td width=30>{Clave}</td><td width=150>{Descripcion}</td><td width=220></tr></table>"

        Catch ex As Exception
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLANTAS_ASIGNADAS()
        Dim SEL_UNI As String
        Dim Tipo_Uni As String = ""


        LL1.Text = "" : LL2.Text = "" : LL3.Text = "" : LL4.Text = "" : LL5.Text = "" : LL6.Text = ""
        LL7.Text = "" : LL8.Text = "" : LL9.Text = "" : LL10.Text = "" : LL11.Text = "" : LL12.Text = ""

        LL1.Tag = "" : LL2.Tag = "" : LL3.Tag = "" : LL4.Tag = "" : LL5.Tag = "" : LL6.Tag = ""
        LL7.Tag = "" : LL8.Tag = "" : LL9.Tag = "" : LL10.Tag = "" : LL11.Tag = "" : LL12.Tag = ""

        TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
        TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT U.CLAVE, U.CLAVEMONTE, U.CVE_TIPO_UNI, ISNULL(U.CVE_TANQUE1,'') AS C_TANQUE1, ISNULL(U.CVE_TANQUE2,'') AS C_TANQUE2,
                ISNULL(U.CVE_DOLLY,'') AS C_DOLLY, U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12,
                ISNULL(U.NUM_LLANTAS,0) AS N_LLANTAS, ISNULL(U.LLANTAS_REF,'') AS LL_REF, U.CVE_MARCA_LLA, U.CVE_MODELO_LLA, U.CVE_MED, U.CVE_TIPO_LLA,
                ISNULL(HLL9,0) AS HL9, ISNULL(HLL10,0) AS HL10, ISNULL(HLL11,0) AS HL11, ISNULL(HLL12,0) AS HL12 
                FROM GCUNIDADES U
                LEFT JOIN GCOBS OB ON OB.CVE_OBS = U.CVE_OBSCOMP
                WHERE CLAVEMONTE = '" & TCVE_UNI.Text & "' AND ISNULL(STATUS, 'A') = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    TCVE_UNI.Tag = dr("CLAVE")
                    Tipo_Uni = dr("CVE_TIPO_UNI")
                    L2.Tag = Tipo_Uni

                    TNUM_LLANTAS.Text = dr("N_LLANTAS") 'OK
                    TLLANTAS_REF.Text = dr("LL_REF") 'OK

                    'HLL9", SqlDbType.SmallInt).Value = IIf(BtnTT9.Visible, 0, 1)
                    If dr("HL9") = 1 Then BtnTT9.Visible = False
                    If dr("HL10") = 1 Then BtnTT10.Visible = False
                    If dr("HL11") = 1 Then BtnTT11.Visible = False
                    If dr("HL12") = 1 Then BtnTT12.Visible = False
                Catch ex As Exception
                    Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try                    'OK
                    For Each vdp As ValueDescriptionPair In CboMarcaLlanta.Items
                        If vdp.ValuePair = dr("CVE_MARCA_LLA") Then
                            CboMarcaLlanta.SelectedIndex = vdp.cboIndex
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try 'OK
                    For Each vdp As ValueDescriptionPair In CboModeloLlanta.Items
                        If vdp.ValuePair = dr("CVE_MODELO_LLA") Then
                            CboModeloLlanta.SelectedIndex = vdp.cboIndex
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try 'OK
                    For Each vdp As ValueDescriptionPair In cboMedidaLlanta.Items
                        If vdp.ValuePair = dr("CVE_MED") Then
                            cboMedidaLlanta.SelectedIndex = vdp.cboIndex
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try 'OK
                    For Each vdp As ValueDescriptionPair In cboTipoLlanta.Items
                        If vdp.ValuePair = dr("CVE_TIPO_LLA") Then
                            cboTipoLlanta.SelectedIndex = vdp.cboIndex
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                SEL_UNI = "0"

                Select Case Tipo_Uni
                    Case "9"    'TRACTOR    1
                        SEL_UNI = "1"
                        LtTractor.Text = dr("CLAVEMONTE")
                        If Tipo_Uni.Trim.Length > 0 Then
                            GTra.Visible = True
                        Else
                            GTra.Visible = False
                        End If
                        If dr("C_TANQUE1").ToString.Trim.Length > 0 And dr("C_TANQUE1").ToString <> "0" Then
                            LtTanque1.Text = dr("C_TANQUE1")
                            GTa1.Visible = True
                        Else
                            GTa1.Visible = False
                        End If
                        If dr("C_TANQUE2").ToString.Trim.Length > 0 And dr("C_TANQUE2").ToString <> "0" Then
                            LtTanque2.Text = dr("C_TANQUE2")
                            GTa2.Visible = True
                        Else
                            GTa2.Visible = False
                        End If
                        If dr("C_DOLLY").ToString.Trim.Length > 0 And dr("C_DOLLY").ToString <> "0" Then
                            LtDolly.Text = dr("C_DOLLY")
                            GDol.Visible = True
                        Else
                            GDol.Visible = False
                        End If

                        Et9.Visible = True : TLL9.Visible = True : LL9.Visible = True : Btn9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True : LL10.Visible = True : Btn10.Visible = True

                        Et11.Visible = False : TLL11.Visible = False : LL11.Visible = False : Btn11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False : LL12.Visible = False : Btn12.Visible = False
                        Ls9.Visible = True : Ls10.Visible = True : Ls11.Visible = False : Ls12.Visible = False

                        TKMS_ACTUAL9.Visible = True : TKMS_ACTUAL10.Visible = True : TKMS_ACTUAL11.Visible = False : TKMS_ACTUAL12.Visible = False
                        TPROFUNDIDAD_ACTUAL9.Visible = True : TPROFUNDIDAD_ACTUAL10.Visible = True : TPROFUNDIDAD_ACTUAL11.Visible = False : TPROFUNDIDAD_ACTUAL12.Visible = False

                        If PTIPO_LLANTA = 2 Then
                            ChDes9.Visible = True : ChDes10.Visible = True : ChDes11.Visible = False : ChDes12.Visible = False
                        End If
                    Case "3"    'DOLLY      3
                        If dr("C_TANQUE1").ToString.Trim.Length > 0 And dr("C_TANQUE1").ToString <> "0" Then
                            GTa1.Visible = True
                        Else
                            GTa1.Visible = False
                        End If
                        If dr("C_TANQUE2").ToString.Trim.Length > 0 And dr("C_TANQUE2").ToString <> "0" Then
                            GTa2.Visible = True
                            GTa1.Visible = False
                        Else
                            GTa2.Visible = False
                            GTa1.Visible = True
                        End If
                        GTra.Visible = False
                        GDol.Visible = True
                        SEL_UNI = "4"
                        If dr("C_DOLLY").ToString.Trim.Length > 0 And dr("C_DOLLY").ToString <> "0" Then
                            LtDolly.Text = dr("C_DOLLY")
                        Else
                            LtDolly.Text = dr("CLAVEMONTE")
                        End If

                        Et9.Visible = False : TLL9.Visible = False : LL9.Visible = False : Btn9.Visible = False
                        Et10.Visible = False : TLL10.Visible = False : LL10.Visible = False : Btn10.Visible = False
                        Et11.Visible = False : TLL11.Visible = False : LL11.Visible = False : Btn11.Visible = False
                        Et12.Visible = False : TLL12.Visible = False : LL12.Visible = False : Btn12.Visible = False
                        Ls9.Visible = False : Ls10.Visible = False : Ls11.Visible = False : Ls12.Visible = False
                        TKMS_ACTUAL9.Visible = False : TKMS_ACTUAL10.Visible = False : TKMS_ACTUAL11.Visible = False : TKMS_ACTUAL12.Visible = False
                        TPROFUNDIDAD_ACTUAL9.Visible = False : TPROFUNDIDAD_ACTUAL10.Visible = False : TPROFUNDIDAD_ACTUAL11.Visible = False : TPROFUNDIDAD_ACTUAL12.Visible = False
                        If PTIPO_LLANTA = 2 Then
                            ChDes9.Visible = False : ChDes10.Visible = False : ChDes11.Visible = False : ChDes12.Visible = False
                        End If

                    Case Else
                        LtTanque2.Text = dr("C_TANQUE2")
                        GTa1.Visible = False
                        GTa2.Visible = False
                        LtTanque2.Text = dr("CLAVEMONTE")
                        GDol.Visible = False

                        Et9.Visible = True : TLL9.Visible = True : LL9.Visible = True : Btn9.Visible = True
                        Et10.Visible = True : TLL10.Visible = True : LL10.Visible = True : Btn10.Visible = True
                        Et11.Visible = True : TLL11.Visible = True : LL11.Visible = True : Btn11.Visible = True
                        Et12.Visible = True : TLL12.Visible = True : LL12.Visible = True : Btn12.Visible = True
                        Ls9.Visible = True : Ls10.Visible = True : Ls11.Visible = True : Ls12.Visible = True

                        TKMS_ACTUAL9.Visible = True : TKMS_ACTUAL10.Visible = True : TKMS_ACTUAL11.Visible = True : TKMS_ACTUAL12.Visible = True
                        TPROFUNDIDAD_ACTUAL9.Visible = True : TPROFUNDIDAD_ACTUAL10.Visible = True : TPROFUNDIDAD_ACTUAL11.Visible = True : TPROFUNDIDAD_ACTUAL12.Visible = True

                        If PTIPO_LLANTA = 2 Then
                            ChDes9.Visible = True : ChDes10.Visible = True : ChDes11.Visible = True : ChDes12.Visible = True
                        End If
                End Select

                Try

                    If Tipo_Uni = "1" Then
                        If dr("C_TANQUE1").ToString.Trim.Length > 0 And dr("C_TANQUE1").ToString <> "0" Then
                            'ASIGNAR_LLANTAS_TANQUES_DOLLY(dr("C_TANQUE1"), 2)
                        End If
                        If dr("C_TANQUE2").ToString.Trim.Length > 0 And dr("C_TANQUE2").ToString <> "0" Then
                            'ASIGNAR_LLANTAS_TANQUES_DOLLY(dr("C_TANQUE2"), 3)
                        End If
                    Else
                        'ASIGNAR_LLANTAS_TANQUES_DOLLY(dr("C_TANQUE1"), 1)
                    End If

                    If dr("C_DOLLY").ToString.Trim.Length > 0 And dr("C_DOLLY").ToString <> "0" Then
                        'ASIGNAR_LLANTAS_TANQUES_DOLLY(dr("C_DOLLY").ToString, 4)
                    End If


                Catch ex As Exception
                    'MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dr.Close()

            TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
            TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""

            TLL1.Tag = "" : TLL2.Tag = "" : TLL3.Tag = "" : TLL4.Tag = "" : TLL5.Tag = "" : TLL6.Tag = ""
            TLL7.Tag = "" : TLL8.Tag = "" : TLL9.Tag = "" : TLL10.Tag = "" : TLL11.Tag = "" : TLL12.Tag = ""

            LL1.Tag = "" : LL2.Tag = "" : LL3.Tag = "" : LL4.Tag = "" : LL5.Tag = "" : LL6.Tag = ""
            LL7.Tag = "" : LL8.Tag = "" : LL9.Tag = "" : LL10.Tag = "" : LL11.Tag = "" : LL12.Tag = ""

            If TCVE_UNI.Text.Trim.Length > 0 Then

                SQL = "SELECT CVE_LLANTA, ISNULL(NUM_ECONOMICO,'') AS NUM_ECO, ISNULL(POSICION,0) AS POS, KMS_ACTUAL, PROFUNDIDAD_ACTUAL
                    FROM GCLLANTAS WHERE UNIDAD = '" & TCVE_UNI.Text & "'
                    ORDER BY FECHAELAB DESC"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    While dr.Read

                        Select Case dr("POS")
                            Case 1
                                If TLL1.Text.Trim.Length = 0 Then
                                    TLL1.Text = dr("NUM_ECO")
                                    If TLL1.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL1.Tag = TLL1.Text
                                        'CVE_LLANTA
                                        LL1.Text = dr("CVE_LLANTA").ToString
                                        LL1.Tag = LL1.Text

                                        TKMS_ACTUAL1.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL1.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))
                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL1.Text)

                                        Btn1.Enabled = False
                                        LL1.Enabled = False
                                        TLL1.Enabled = False
                                    Else
                                        Btn1.Enabled = True
                                        LL1.Enabled = True
                                        TLL1.Enabled = True
                                    End If
                                End If
                            Case 2
                                If TLL2.Text.Trim.Length = 0 Then
                                    TLL2.Text = dr("NUM_ECO")
                                    If TLL2.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL2.Tag = TLL2.Text
                                        'CVE_LLANTA
                                        LL2.Text = dr("CVE_LLANTA").ToString
                                        LL2.Tag = LL2.Text
                                        TKMS_ACTUAL2.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL2.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))
                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL2.Text)

                                        Btn2.Enabled = False
                                        LL2.Enabled = False
                                        TLL2.Enabled = False
                                    Else
                                        Btn2.Enabled = True
                                        LL2.Enabled = True
                                        TLL2.Enabled = True
                                    End If
                                End If
                            Case 3
                                If TLL3.Text.Trim.Length = 0 Then
                                    TLL3.Text = dr("NUM_ECO")
                                    If TLL3.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL3.Tag = TLL3.Text
                                        'CVE_LLANTA
                                        LL3.Text = dr("CVE_LLANTA").ToString
                                        LL3.Tag = LL3.Text
                                        TKMS_ACTUAL3.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL3.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))
                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL3.Text)

                                        Btn3.Enabled = False
                                        LL3.Enabled = False
                                        TLL3.Enabled = False
                                    Else
                                        Btn3.Enabled = True
                                        LL3.Enabled = True
                                        TLL3.Enabled = True
                                    End If
                                End If
                            Case 4
                                If TLL4.Text.Trim.Length = 0 Then
                                    TLL4.Text = dr("NUM_ECO")
                                    If TLL4.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL4.Tag = TLL4.Text
                                        'CVE_LLANTA
                                        LL4.Text = dr("CVE_LLANTA").ToString
                                        LL4.Tag = LL4.Text
                                        TKMS_ACTUAL4.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL4.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))
                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL4.Text)

                                        Btn4.Enabled = False
                                        LL4.Enabled = False
                                        TLL4.Enabled = False
                                    Else
                                        Btn4.Enabled = True
                                        LL4.Enabled = True
                                        TLL4.Enabled = True
                                    End If
                                End If
                            Case 5
                                If TLL5.Text.Trim.Length = 0 Then
                                    TLL5.Text = dr("NUM_ECO")
                                    If TLL5.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL5.Tag = TLL5.Text
                                        'CVE_LLANTA
                                        LL5.Text = dr("CVE_LLANTA").ToString
                                        LL5.Tag = LL5.Text
                                        TKMS_ACTUAL5.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL5.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL5.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn5.Enabled = False
                                        LL5.Enabled = False
                                        TLL5.Enabled = False
                                    Else
                                        Btn5.Enabled = True
                                        LL5.Enabled = True
                                        TLL5.Enabled = True
                                    End If
                                End If
                            Case 6
                                If TLL6.Text.Trim.Length = 0 Then
                                    TLL6.Text = dr("NUM_ECO")
                                    If TLL6.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL6.Tag = TLL6.Text
                                        'CVE_LLANTA
                                        LL6.Text = dr("CVE_LLANTA").ToString
                                        LL6.Tag = LL6.Text
                                        TKMS_ACTUAL6.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL6.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL6.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn6.Enabled = False
                                        LL6.Enabled = False
                                        TLL6.Enabled = False
                                    Else
                                        Btn6.Enabled = True
                                        LL6.Enabled = True
                                        TLL6.Enabled = True
                                    End If
                                End If
                            Case 7
                                If TLL7.Text.Trim.Length = 0 Then
                                    TLL7.Text = dr("NUM_ECO")
                                    If TLL7.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL7.Tag = TLL7.Text
                                        'CVE_LLANTA
                                        LL7.Text = dr("CVE_LLANTA").ToString
                                        LL7.Tag = LL7.Text
                                        TKMS_ACTUAL7.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL7.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL7.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn7.Enabled = False
                                        LL7.Enabled = False
                                        TLL7.Enabled = False
                                    Else
                                        Btn7.Enabled = True
                                        LL7.Enabled = True
                                        TLL7.Enabled = True
                                    End If
                                End If
                            Case 8
                                If TLL8.Text.Trim.Length = 0 Then
                                    TLL8.Text = dr("NUM_ECO")
                                    If TLL8.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL8.Tag = TLL8.Text
                                        'CVE_LLANTA
                                        LL8.Text = dr("CVE_LLANTA").ToString
                                        LL8.Tag = LL8.Text
                                        TKMS_ACTUAL8.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL8.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL1.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn8.Enabled = False
                                        LL8.Enabled = False
                                        TLL8.Enabled = False
                                    Else
                                        Btn8.Enabled = True
                                        LL8.Enabled = True
                                        TLL8.Enabled = True
                                    End If
                                End If
                            Case 9
                                If TLL9.Text.Trim.Length = 0 Then
                                    TLL9.Text = dr("NUM_ECO")
                                    If TLL9.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL9.Tag = TLL9.Text
                                        'CVE_LLANTA
                                        LL9.Text = dr("CVE_LLANTA").ToString
                                        LL9.Tag = LL9.Text
                                        TKMS_ACTUAL9.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL9.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL9.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn9.Enabled = False
                                        LL9.Enabled = False
                                        TLL9.Enabled = False
                                    Else
                                        Btn9.Enabled = True
                                        LL9.Enabled = True
                                        TLL9.Enabled = True
                                    End If
                                End If
                            Case 10
                                If TLL10.Text.Trim.Length = 0 Then
                                    TLL10.Text = dr("NUM_ECO")
                                    If TLL10.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL10.Tag = TLL10.Text
                                        'CVE_LLANTA
                                        LL10.Text = dr("CVE_LLANTA").ToString
                                        LL10.Tag = LL10.Text
                                        TKMS_ACTUAL10.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL10.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL10.Text)
                                        IMAGEN_LLANTA(Tipo_Uni, dr("POS"))

                                        Btn10.Enabled = False
                                        LL10.Enabled = False
                                        TLL10.Enabled = False
                                    Else
                                        Btn10.Enabled = True
                                        LL10.Enabled = True
                                        TLL10.Enabled = True
                                    End If
                                End If
                            Case 11
                                If TLL11.Text.Trim.Length = 0 Then
                                    TLL11.Text = dr("NUM_ECO")
                                    If TLL11.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL11.Tag = TLL11.Text
                                        'CVE_LLANTA
                                        LL11.Text = dr("CVE_LLANTA").ToString
                                        LL11.Tag = LL11.Text
                                        TKMS_ACTUAL11.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL11.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL11.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn11.Enabled = False
                                        LL11.Enabled = False
                                        TLL11.Enabled = False
                                    Else
                                        Btn11.Enabled = True
                                        LL11.Enabled = True
                                        TLL11.Enabled = True
                                    End If
                                End If
                            Case 12
                                If TLL12.Text.Trim.Length = 0 Then
                                    TLL12.Text = dr("NUM_ECO")
                                    If TLL12.Text.Trim.Length > 0 Then
                                        'NUM_ECONOMICO
                                        TLL12.Tag = TLL12.Text
                                        'CVE_LLANTA
                                        LL12.Text = dr("CVE_LLANTA").ToString
                                        LL12.Tag = LL12.Text
                                        TKMS_ACTUAL12.Value = dr.ReadNullAsEmptyDecimal("KMS_ACTUAL")
                                        TPROFUNDIDAD_ACTUAL12.Text = dr.ReadNullAsEmptyDecimal("PROFUNDIDAD_ACTUAL")

                                        ASIGNAR_LLANTAS_AL_BOTON(Tipo_Uni, dr("POS"), TLL12.Text)
                                        IMAGEN_LLANTA(TCVE_UNI.Text, dr("POS"))

                                        Btn12.Enabled = False
                                        LL12.Enabled = False
                                        TLL12.Enabled = False
                                    Else
                                        Btn12.Enabled = True
                                        LL12.Enabled = True
                                        TLL12.Enabled = True
                                    End If
                                End If
                        End Select
                    End While
                Else
                    Btn1.Enabled = True : LL1.Enabled = True : TLL1.Enabled = True
                    Btn2.Enabled = True : LL2.Enabled = True : TLL2.Enabled = True
                    Btn3.Enabled = True : LL3.Enabled = True : TLL3.Enabled = True
                    Btn4.Enabled = True : LL4.Enabled = True : TLL4.Enabled = True
                    Btn5.Enabled = True : LL5.Enabled = True : TLL5.Enabled = True
                    Btn6.Enabled = True : LL6.Enabled = True : TLL6.Enabled = True
                    Btn7.Enabled = True : LL7.Enabled = True : TLL7.Enabled = True
                    Btn8.Enabled = True : LL8.Enabled = True : TLL8.Enabled = True
                    Btn9.Enabled = True : LL9.Enabled = True : TLL9.Enabled = True
                    Btn10.Enabled = True : LL10.Enabled = True : TLL10.Enabled = True
                    Btn11.Enabled = True : LL11.Enabled = True : TLL11.Enabled = True
                    Btn12.Enabled = True : LL12.Enabled = True : TLL12.Enabled = True

                End If
                dr.Close()

                Try
                    Dim DESCR As String
                    If TLL1.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL1.Text)
                        Ls1.Text = Var7
                        Ls1.Tag = Var7
                    Else
                        Ls1.Text = ""
                        Ls1.Tag = ""
                    End If
                    If TLL2.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL2.Text)
                        Ls2.Text = Var7
                        Ls2.Tag = Var7
                    Else
                        Ls2.Text = ""
                        Ls2.Tag = ""
                    End If
                    If TLL3.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL3.Text)
                        Ls3.Text = Var7
                        Ls3.Tag = Var7
                    Else
                        Ls3.Text = ""
                        Ls3.Tag = ""
                    End If
                    If TLL4.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL4.Text)
                        Ls4.Text = Var7
                        Ls4.Tag = Var7
                    Else
                        Ls4.Text = ""
                        Ls4.Tag = ""
                    End If
                    If TLL5.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL5.Text)
                        Ls5.Text = Var7
                        Ls5.Tag = Var7
                    Else
                        Ls5.Text = ""
                        Ls5.Tag = ""
                    End If
                    If TLL6.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL6.Text)
                        Ls6.Text = Var7
                        Ls6.Tag = Var7
                    End If
                    If TLL7.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL7.Text)
                        Ls7.Text = Var7
                        Ls7.Tag = Var7
                    Else
                        Ls7.Text = ""
                        Ls7.Tag = ""
                    End If
                    If TLL8.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL8.Text)
                        Ls8.Text = Var7
                        Ls8.Tag = Var7
                    Else
                        Ls8.Text = ""
                        Ls8.Tag = ""
                    End If
                    If TLL9.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL9.Text)
                        Ls9.Text = Var7
                        Ls9.Tag = Var7
                    Else
                        Ls9.Text = ""
                        Ls9.Tag = ""
                    End If
                    If TLL10.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL10.Text)
                        Ls10.Text = Var7
                        Ls10.Tag = Var7
                    Else
                        Ls10.Text = ""
                        Ls10.Tag = ""
                    End If
                    If TLL11.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL11.Text)
                        Ls11.Text = Var7
                        Ls11.Tag = Var7
                    Else
                        Ls11.Text = ""
                        Ls11.Tag = ""
                    End If
                    If TLL12.Text.Trim.Length > 0 Then
                        DESCR = BUSCA_CAT("LlantasNE", TLL12.Text)
                        Ls12.Text = Var7
                        Ls12.Tag = Var7
                    Else
                        Ls12.Text = ""
                        Ls12.Tag = ""
                    End If
                Catch ex As Exception
                End Try
            End If


            TNUM_LLANTAS.Select()

        Catch ex As Exception
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function BUSCA_NUM_ECONOMICO(fCVE_LLANTA As String) As String
        Dim NUM_ECO As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND CVE_LLANTA = '" & fCVE_LLANTA & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        NUM_ECO = dr.ReadNullAsEmptyString("NUM_ECONOMICO")

                    End If
                End Using
            End Using
            Return NUM_ECO
        Catch ex As Exception
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
            Return NUM_ECO
        End Try
    End Function
    Sub IMAGEN_LLANTA(fDESCR As String, fNUM As Integer)
        Dim NUM As Integer
        Select Case fNUM
            Case 1  'IMAGEN 1
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT1.ImageIndex = 1
                                Else
                                    BtnT1.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD1.ImageIndex = 1
                                BtnD1.ForeColor = Color.Black
                            Case "M"
                                BtnM1.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL1.Tag.ToString.Length >= 4 Then
                            Select Case TLL1.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT1.ImageIndex = 0
                                    Else
                                        BtnT1.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD1.ImageIndex = 0
                                    BtnD1.ForeColor = Color.Black
                                Case "M"
                                    BtnM1.ImageIndex = 0
                                Case Else
                            End Select
                        End If

                    Catch ex As Exception
                    End Try
                End If
            Case 2
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT2.ImageIndex = 1
                                Else
                                    BtnT2.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD2.ImageIndex = 1
                                BtnD2.ForeColor = Color.Black
                            Case "M"
                                BtnM2.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL2.Tag.ToString.Length >= 4 Then
                            Select Case TLL2.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT2.ImageIndex = 0
                                    Else
                                        BtnT2.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD2.ImageIndex = 0
                                    BtnD2.ForeColor = Color.Black
                                Case "M"
                                    BtnM2.ImageIndex = 0
                                Case Else
                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 3
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT3.ImageIndex = 1
                                Else
                                    BtnT3.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD3.ImageIndex = 1
                                BtnD3.ForeColor = Color.Black
                            Case "M"
                                BtnM3.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL3.Tag.ToString.Length >= 4 Then
                            Select Case TLL3.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT3.ImageIndex = 0
                                    Else
                                        BtnT3.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD3.ImageIndex = 0
                                    BtnD3.ForeColor = Color.Black
                                Case "M"
                                    BtnM3.ImageIndex = 0
                                Case Else
                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 4
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT2.ImageIndex = 1
                                Else
                                    BtnT2.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD4.ImageIndex = 1
                                BtnD4.ForeColor = Color.Black
                            Case "M"
                                BtnM4.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL4.Tag.ToString.Length >= 4 Then
                            Select Case TLL4.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT4.ImageIndex = 0
                                    Else
                                        BtnT4.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD4.ImageIndex = 0
                                    BtnD4.ForeColor = Color.Black
                                Case "M"
                                    BtnM4.ImageIndex = 0
                                Case Else
                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 5
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT5.ImageIndex = 1
                                Else
                                    BtnT5.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD5.ImageIndex = 1
                                BtnD5.ForeColor = Color.Black
                            Case "M"
                                BtnM5.ImageIndex = 1
                            Case Else
                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL5.Tag.ToString.Length >= 4 Then
                            Select Case TLL5.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT5.ImageIndex = 0
                                    Else
                                        BtnT5.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD5.ImageIndex = 0
                                    BtnD5.ForeColor = Color.Black
                                Case "M"
                                    BtnM5.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 6
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT6.ImageIndex = 1
                                Else
                                    BtnT6.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD6.ImageIndex = 1
                                BtnD6.ForeColor = Color.Black
                            Case "M"
                                BtnM6.ImageIndex = 1
                            Case Else

                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL6.Tag.ToString.Length >= 4 Then
                            Select Case TLL6.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT6.ImageIndex = 0
                                    Else
                                        BtnT6.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD6.ImageIndex = 0
                                    BtnD6.ForeColor = Color.Black
                                Case "M"
                                    BtnM6.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 7
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT7.ImageIndex = 1
                                Else
                                    BtnT7.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD7.ImageIndex = 1
                                BtnD7.ForeColor = Color.Black
                            Case "M"
                                BtnM7.ImageIndex = 1
                            Case Else

                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL7.Tag.ToString.Length >= 4 Then
                            Select Case TLL7.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT2.ImageIndex = 0
                                    Else
                                        BtnT2.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD7.ImageIndex = 0
                                    BtnD7.ForeColor = Color.Black
                                Case "M"
                                    BtnM7.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 8
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT8.ImageIndex = 1
                                Else
                                    BtnT8.ImageIndex = 1
                                End If
                            Case "D"
                                BtnD8.ImageIndex = 1
                                BtnD8.ForeColor = Color.Black
                            Case "M"
                                BtnM8.ImageIndex = 1
                            Case Else

                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL8.Tag.ToString.Length >= 4 Then
                            Select Case TLL8.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT8.ImageIndex = 0
                                    Else
                                        BtnT8.ImageIndex = 0
                                    End If
                                Case "D"
                                    BtnD8.ImageIndex = 0
                                    BtnD8.ForeColor = Color.Black
                                Case "M"
                                    BtnM8.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 9
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT9.ImageIndex = 1
                                Else
                                    BtnT9.ImageIndex = 1
                                End If
                            Case "D"

                            Case "M"
                                BtnM9.ImageIndex = 1
                            Case Else

                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL9.Tag.ToString.Length >= 4 Then
                            Select Case TLL9.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT9.ImageIndex = 0
                                    Else
                                        BtnT9.ImageIndex = 0
                                    End If
                                Case "D"
                                Case "M"
                                    BtnM9.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Case 10
                If fDESCR.Trim.Length >= 4 Then
                    Try
                        Select Case fDESCR.Substring(0, 1)
                            Case "T"
                                NUM = fDESCR.Substring(2, 3)
                                If NUM <= 120 Then
                                    BtnTT10.ImageIndex = 1
                                Else
                                    BtnT10.ImageIndex = 1
                                End If
                            Case "D"
                                'BtnD2.ImageIndex = 1
                                'BtnD2.ForeColor = Color.Black 
                            Case "M"
                                BtnM10.ImageIndex = 1
                            Case Else

                        End Select
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        If TLL10.Tag.ToString.Length >= 4 Then
                            Select Case TLL10.Tag.Substring(0, 1)
                                Case "T"
                                    NUM = fDESCR.Substring(2, 3)
                                    If NUM <= 120 Then
                                        BtnTT10.ImageIndex = 0
                                    Else
                                        BtnT10.ImageIndex = 0
                                    End If
                                Case "D"
                                    'BtnD2.ImageIndex = 0
                                    'BtnD2.ForeColor = Color.Black
                                Case "M"
                                    BtnM10.ImageIndex = 0
                                Case Else

                            End Select
                        End If
                    Catch ex As Exception
                    End Try
                End If
        End Select
    End Sub
    Sub ASIGNAR_LLANTAS_TANQUES_DOLLY(fUNIDAD As String, fTIPO_UNI As Integer)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If fTIPO_UNI = 2 Then
                SQL = SQL
            End If
            cmd.Connection = cnSAE
            SQL = "SELECT U.CVE_TIPO_UNI, U.CHLL1, U.CHLL2, U.CHLL3, U.CHLL4, U.CHLL5, U.CHLL6, U.CHLL7, U.CHLL8, " &
                  "U.CHLL9, U.CHLL10, U.CHLL11, U.CHLL12 " &
                  "FROM GCUNIDADES U " &
                  "WHERE CLAVEMONTE = '" & fUNIDAD & "' AND ISNULL(STATUS, 'A') = 'A'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Try
                    If dr("CHLL1").ToString <> "0" And dr("CHLL1").ToString.Trim.Length > 0 Then
                        '            TANQUE 1 2 DOLLY          LLANTA REGRESA NO_ECONOMICO 
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 1, BUSCA_CAT("Llantas", dr("CHLL1").ToString))
                    End If
                    If dr("CHLL2").ToString <> "0" And dr("CHLL2").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 2, BUSCA_CAT("Llantas", dr("CHLL2").ToString))
                    End If
                    If dr("CHLL3").ToString <> "0" And dr("CHLL3").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 3, BUSCA_CAT("Llantas", dr("CHLL3").ToString))
                    End If
                    If dr("CHLL4").ToString <> "0" And dr("CHLL4").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 4, BUSCA_CAT("Llantas", dr("CHLL4").ToString))
                    End If
                    If dr("CHLL5").ToString <> "0" And dr("CHLL5").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 5, BUSCA_CAT("Llantas", dr("CHLL5").ToString))
                    End If
                    If dr("CHLL6").ToString <> "0" And dr("CHLL6").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 6, BUSCA_CAT("Llantas", dr("CHLL6").ToString))
                    End If
                    If dr("CHLL7").ToString <> "0" And dr("CHLL7").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 7, BUSCA_CAT("Llantas", dr("CHLL7").ToString))
                    End If
                    If dr("CHLL8").ToString <> "0" And dr("CHLL8").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 8, BUSCA_CAT("Llantas", dr("CHLL8").ToString))
                    End If
                    If dr("CHLL9").ToString <> "0" And dr("CHLL9").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 9, BUSCA_CAT("Llantas", dr("CHLL9").ToString))
                    End If
                    If dr("CHLL10").ToString <> "0" And dr("CHLL10").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 10, BUSCA_CAT("Llantas", dr("CHLL10").ToString))
                    End If
                    If dr("CHLL11").ToString <> "0" And dr("CHLL11").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 11, BUSCA_CAT("Llantas", dr("CHLL11").ToString))
                    End If
                    If dr("CHLL12").ToString <> "0" And dr("CHLL12").ToString.Trim.Length > 0 Then
                        ASIGNAR_LLANTAS_AL_BOTON(fTIPO_UNI, 12, BUSCA_CAT("Llantas", dr("CHLL12").ToString))
                    End If
                Catch ex As Exception
                    MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
                    Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("25. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("25. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub ASIGNAR_LLANTAS_AL_BOTON(fUNI As String, fLLANTA As Integer, fNUM_ECONOMICO As String)
        Try
            Select Case fUNI
                Case "1" 'TRACTOR
                    'TRACTOR
                    Select Case fLLANTA
                        Case 1
                            BtnM1.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnM2.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnM3.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnM4.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnM5.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnM6.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnM7.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnM8.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM8.Text = fNUM_ECONOMICO
                        Case 9
                            BtnM9.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM9.Text = fNUM_ECONOMICO
                        Case 10
                            BtnM10.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnM10.Text = fNUM_ECONOMICO
                    End Select
                Case "2"
                    'GTa2 TANQUE 2
                    Select Case fLLANTA
                        Case 1
                            BtnTT1.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnTT2.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnTT3.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnTT4.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnTT5.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnTT6.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnTT7.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnTT8.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT8.Text = fNUM_ECONOMICO
                        Case 9
                            BtnTT9.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT9.Text = fNUM_ECONOMICO
                        Case 10
                            BtnTT10.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT10.Text = fNUM_ECONOMICO
                        Case 11
                            BtnTT11.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT11.Text = fNUM_ECONOMICO
                        Case 12
                            BtnTT12.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnTT12.Text = fNUM_ECONOMICO
                    End Select
                Case "3"
                    Select Case fLLANTA
                        Case 1
                            BtnD1.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD1.Text = fNUM_ECONOMICO
                        Case 2
                            BtnD2.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD2.Text = fNUM_ECONOMICO
                        Case 3
                            BtnD3.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD3.Text = fNUM_ECONOMICO
                        Case 4
                            BtnD4.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD4.Text = fNUM_ECONOMICO
                        Case 5
                            BtnD5.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD5.Text = fNUM_ECONOMICO
                        Case 6
                            BtnD6.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD6.Text = fNUM_ECONOMICO
                        Case 7
                            BtnD7.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD7.Text = fNUM_ECONOMICO
                        Case 8
                            BtnD8.Font = New Font("Arial", 12, FontStyle.Bold)
                            BtnD8.Text = fNUM_ECONOMICO
                    End Select
            End Select
        Catch ex As Exception
            MsgBox("26. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("26. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmAsignacionLlantas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_MARCA_LLA As Integer, CVE_MODELO_LLA As Integer, CVE_MED As Integer, CVE_TIPO_LLA As Integer, CVE_TIPO_COM As Integer, z As Integer = 0
        Dim cmd As New SqlCommand, ST_LLANTA As Integer

        SendKeys.Send("{TAB}")
        Btn1.Focus()
        Btn10.Focus()

        If TCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la unidad")
            Return
        End If

        If PTIPO_LLANTA = 2 Then
            Try
                If ChDes1.Checked Then
                    z += 1
                    If CboStatusLlanta1.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes2.Checked Then
                    z += 1
                    If CboStatusLlanta2.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes3.Checked Then
                    z += 1
                    If CboStatusLlanta3.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes4.Checked Then
                    z += 1
                    If CboStatusLlanta4.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes5.Checked Then
                    z += 1
                    If CboStatusLlanta5.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes6.Checked Then
                    z += 1
                    If CboStatusLlanta6.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes7.Checked Then
                    z += 1
                    If CboStatusLlanta7.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes8.Checked Then
                    z += 1
                    If CboStatusLlanta8.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes9.Checked Then
                    z += 1
                    If CboStatusLlanta9.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes10.Checked Then
                    z += 1
                    If CboStatusLlanta10.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes11.Checked Then
                    z += 1
                    If CboStatusLlanta11.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
                If ChDes12.Checked Then
                    z += 1
                    If CboStatusLlanta12.SelectedIndex = -1 Then
                        MsgBox("Por favor seleccione el estatus de la llanta")
                        Return
                    End If
                End If
            Catch ex As Exception
            End Try
            If z = 0 Then
                MsgBox("Por favor seleccione la o las llantas a desasignar")
                Return
            End If
        End If

        If MsgBox("Realmente desea grabar la asignación de llantas?", vbYesNo) = vbNo Then
            Return
        End If
        Try
            If LLantaAsignada(TLL1.Text, 1) Then
                TLL1.Text = ""
                Return
            End If
            If LLantaAsignada(TLL2.Text, 2) Then
                TLL2.Text = ""
                Return
            End If
            If LLantaAsignada(TLL3.Text, 3) Then
                TLL3.Text = ""
                Return
            End If
            If LLantaAsignada(TLL4.Text, 4) Then
                TLL4.Text = ""
                Return
            End If
            If LLantaAsignada(TLL5.Text, 5) Then
                TLL5.Text = ""
                Return
            End If
            If LLantaAsignada(TLL6.Text, 6) Then
                TLL6.Text = ""
                Return
            End If
            If LLantaAsignada(TLL7.Text, 7) Then
                TLL7.Text = ""
                Return
            End If
            If LLantaAsignada(TLL8.Text, 8) Then
                TLL8.Text = ""
                Return
            End If
            If LLantaAsignada(TLL9.Text, 9) Then
                TLL9.Text = ""
                Return
            End If
            If LLantaAsignada(TLL10.Text, 10) Then
                TLL10.Text = ""
                Return
            End If
            If LLantaAsignada(TLL11.Text, 11) Then
                TLL11.Text = ""
                Return
            End If
            If LLantaAsignada(TLL12.Text, 12) Then
                TLL12.Text = ""
                Return
            End If
            If TLL1.Text = "" Then LL1.Text = ""
            If TLL2.Text = "" Then LL2.Text = ""
            If TLL3.Text = "" Then LL3.Text = ""
            If TLL4.Text = "" Then LL4.Text = ""
            If TLL5.Text = "" Then LL5.Text = ""
            If TLL6.Text = "" Then LL6.Text = ""
            If TLL7.Text = "" Then LL7.Text = ""
            If TLL8.Text = "" Then LL8.Text = ""
            If TLL9.Text = "" Then LL9.Text = ""
            If TLL10.Text = "" Then LL10.Text = ""
            If TLL11.Text = "" Then LL11.Text = ""
            If TLL12.Text = "" Then LL12.Text = ""
        Catch ex As Exception
        End Try
        Try
            If CboMarcaLlanta.SelectedIndex = -1 Then
                CVE_MARCA_LLA = 0
            Else
                CVE_MARCA_LLA = CType(CboMarcaLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            Bitacora("49. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("49. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If CboModeloLlanta.SelectedIndex = -1 Then
                CVE_MODELO_LLA = 0
            Else
                CVE_MODELO_LLA = CType(CboModeloLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            Bitacora("50. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("50. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If cboMedidaLlanta.SelectedIndex = -1 Then
                CVE_MED = 0
            Else
                CVE_MED = CType(cboMedidaLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            Bitacora("51. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("51. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If cboTipoLlanta.SelectedIndex = -1 Then
                CVE_TIPO_LLA = 0
            Else
                CVE_TIPO_LLA = CType(cboTipoLlanta.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try


        SQL = "UPDATE GCUNIDADES SET CHLL1 = @CHLL1, CHLL2 = @CHLL2, CHLL3 = @CHLL3, CHLL4 = @CHLL4, CHLL5 = @CHLL5, CHLL6 = @CHLL6, CHLL7 = @CHLL7, 
            CHLL8 = @CHLL8, CHLL9 = @CHLL9, CHLL10 = @CHLL10, CHLL11 = @CHLL11, CHLL12 = @CHLL12, NUM_LLANTAS = @NUM_LLANTAS, LLANTAS_REF = @LLANTAS_REF, 
            CVE_MARCA_LLA = @CVE_MARCA_LLA, CVE_MODELO_LLA = @CVE_MODELO_LLA, CVE_MED = @CVE_MED, CVE_TIPO_LLA = @CVE_TIPO_LLA, USUARIO = @USUARIO, 
            HLL9 = @HLL9, HLL10 = @HLL10, HLL11 = @HLL11, HLL12 = @HLL12 
            WHERE CLAVE = @CLAVE "
        cmd.Connection = cnSAE
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCVE_UNI.Tag
            cmd.Parameters.Add("@CHLL1", SqlDbType.VarChar).Value = IIf(ChDes1.Visible And ChDes1.Checked, "", LL1.Text)
            cmd.Parameters.Add("@CHLL2", SqlDbType.VarChar).Value = IIf(ChDes2.Visible And ChDes2.Checked, "", LL2.Text)
            cmd.Parameters.Add("@CHLL3", SqlDbType.VarChar).Value = IIf(ChDes3.Visible And ChDes3.Checked, "", LL3.Text)
            cmd.Parameters.Add("@CHLL4", SqlDbType.VarChar).Value = IIf(ChDes4.Visible And ChDes4.Checked, "", LL4.Text)
            cmd.Parameters.Add("@CHLL5", SqlDbType.VarChar).Value = IIf(ChDes5.Visible And ChDes5.Checked, "", LL5.Text)
            cmd.Parameters.Add("@CHLL6", SqlDbType.VarChar).Value = IIf(ChDes6.Visible And ChDes6.Checked, "", LL6.Text)
            cmd.Parameters.Add("@CHLL7", SqlDbType.VarChar).Value = IIf(ChDes7.Visible And ChDes7.Checked, "", LL7.Text)
            cmd.Parameters.Add("@CHLL8", SqlDbType.VarChar).Value = IIf(ChDes8.Visible And ChDes8.Checked, "", LL8.Text)
            cmd.Parameters.Add("@CHLL9", SqlDbType.VarChar).Value = IIf(ChDes9.Visible And ChDes9.Checked, "", LL9.Text)
            cmd.Parameters.Add("@CHLL10", SqlDbType.VarChar).Value = IIf(ChDes10.Visible And ChDes10.Checked, "", LL10.Text)
            cmd.Parameters.Add("@CHLL11", SqlDbType.VarChar).Value = IIf(ChDes11.Visible And ChDes11.Checked, "", LL11.Text)
            cmd.Parameters.Add("@CHLL12", SqlDbType.VarChar).Value = IIf(ChDes12.Visible And ChDes12.Checked, "", LL12.Text)
            cmd.Parameters.Add("@NUM_LLANTAS", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TNUM_LLANTAS.Text)
            cmd.Parameters.Add("@LLANTAS_REF", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TLLANTAS_REF.Text)
            cmd.Parameters.Add("@CVE_MARCA_LLA", SqlDbType.SmallInt).Value = CVE_MARCA_LLA
            cmd.Parameters.Add("@CVE_MODELO_LLA", SqlDbType.SmallInt).Value = CVE_MODELO_LLA
            cmd.Parameters.Add("@CVE_MED", SqlDbType.SmallInt).Value = CVE_MED
            cmd.Parameters.Add("@CVE_TIPO_LLA", SqlDbType.SmallInt).Value = CVE_TIPO_LLA
            cmd.Parameters.Add("@CVE_TIPO_COM", SqlDbType.SmallInt).Value = CVE_TIPO_COM
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = USER_GRUPOCE

            cmd.Parameters.Add("@HLL9", SqlDbType.SmallInt).Value = IIf(BtnTT9.Visible, 0, 1)
            cmd.Parameters.Add("@HLL10", SqlDbType.SmallInt).Value = IIf(BtnTT10.Visible, 0, 1)
            cmd.Parameters.Add("@HLL11", SqlDbType.SmallInt).Value = IIf(BtnTT11.Visible, 0, 1)
            cmd.Parameters.Add("@HLL12", SqlDbType.SmallInt).Value = IIf(BtnTT12.Visible, 0, 1)

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            Try
                If Not Valida_Conexion() Then
                End If

                SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = 2 WHERE UNIDAD = '" & TCVE_UNI.Text & "'"

                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    cmd2.CommandText = SQL
                    returnValue = cmd2.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            'GCLLANTAS_MINVE
            Try
                If TLL1.Text.ToString.Trim.Length > 0 Then
                    If ChDes1.Visible And ChDes1.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta1.Items(CboStatusLlanta1.SelectedIndex))

                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL1.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 1, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL1.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL1.Text.Trim), TPROFUNDIDAD_ACTUAL1.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL1.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using

                    If PTIPO_LLANTA = 1 Then
                        If TLL1.Text <> TLL1.Tag Then
                            'MONTAR
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL1.Text, LL1.Text, 1, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes1.Visible And ChDes1.Checked Then
                            'DESMONTAR    
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL1.Text, LL1.Text, 1, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL2.Text.ToString.Trim.Length > 0 Then
                    If ChDes2.Visible And ChDes2.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta2.Items(CboStatusLlanta2.SelectedIndex))

                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL2.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 2, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL2.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL2.Text.Trim), TPROFUNDIDAD_ACTUAL2.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL2.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    'STATUS_LLANTA 
                    '1   ASIGNADA	A
                    '2   PENDIENTE POR ASIGNAR	A
                    '3   REPARACION	A
                    '4   PARA RENOVAR	A
                    '5   FIN DE VIDA UTIL	A
                    '6   DESECHO	A
                    If PTIPO_LLANTA = 1 Then
                        If TLL2.Text <> TLL2.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL2.Text, LL2.Text, 2, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes2.Visible And ChDes2.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL2.Text, LL2.Text, 2, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL3.Text.ToString.Trim.Length > 0 Then

                    If ChDes3.Visible And ChDes3.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta3.Items(CboStatusLlanta3.SelectedIndex))

                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL3.Text & "'"
                    Else

                        SQL = "UPDATE GCLLANTAS SET POSICION = 3, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL3.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL3.Text.Trim), TPROFUNDIDAD_ACTUAL3.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL3.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL3.Text <> TLL3.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL3.Text, LL3.Text, 3, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes3.Visible And ChDes3.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL3.Text, LL3.Text, 3, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL4.Text.ToString.Trim.Length > 0 Then
                    If ChDes4.Visible And ChDes4.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta4.Items(CboStatusLlanta4.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL4.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 4, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL4.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL4.Text.Trim), TPROFUNDIDAD_ACTUAL4.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL4.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL4.Text <> TLL4.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL4.Text, LL4.Text, 4, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes4.Visible And ChDes4.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL4.Text, LL4.Text, 4, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL5.Text.ToString.Trim.Length > 0 Then
                    If ChDes5.Visible And ChDes5.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta5.Items(CboStatusLlanta5.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL5.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 5, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL5.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL5.Text.Trim), TPROFUNDIDAD_ACTUAL5.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL5.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL5.Text <> TLL5.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL5.Text, LL5.Text, 5, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes5.Visible And ChDes5.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL5.Text, LL5.Text, 5, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL6.Text.ToString.Trim.Length > 0 Then
                    If ChDes6.Visible And ChDes6.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta6.Items(CboStatusLlanta6.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL6.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 6, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL6.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL6.Text.Trim), TPROFUNDIDAD_ACTUAL6.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL6.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL6.Text <> TLL6.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL6.Text, LL6.Text, 6, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes6.Visible And ChDes6.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL6.Text, LL6.Text, 6, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL7.Text.ToString.Trim.Length > 0 Then
                    If ChDes7.Visible And ChDes7.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta7.Items(CboStatusLlanta7.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL7.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 7, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL7.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL7.Text.Trim), TPROFUNDIDAD_ACTUAL7.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL7.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL7.Text <> TLL7.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL7.Text, LL7.Text, 7, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes7.Visible And ChDes7.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL7.Text, LL7.Text, 7, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL8.Text.ToString.Trim.Length > 0 Then
                    If ChDes8.Visible And ChDes8.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta8.Items(CboStatusLlanta8.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL8.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 8, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL8.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL8.Text.Trim), TPROFUNDIDAD_ACTUAL8.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL8.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL8.Text <> TLL8.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL8.Text, LL8.Text, 8, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes8.Visible And ChDes8.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL8.Text, LL8.Text, 8, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL9.Text.ToString.Trim.Length > 0 Then
                    If ChDes9.Visible And ChDes9.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta9.Items(CboStatusLlanta9.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL9.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 9, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL9.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL9.Text.Trim), TPROFUNDIDAD_ACTUAL9.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL9.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL9.Text <> TLL9.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL9.Text, LL9.Text, 9, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes9.Visible And ChDes9.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL9.Text, LL9.Text, 9, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If

            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL10.Text.ToString.Trim.Length > 0 Then
                    If ChDes10.Visible And ChDes10.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta10.Items(CboStatusLlanta10.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL10.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 10, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL10.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL10.Text.Trim), TPROFUNDIDAD_ACTUAL10.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL10.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL10.Text <> TLL10.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL10.Text, LL10.Text, 10, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes10.Visible And ChDes10.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL10.Text, LL10.Text, 10, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL11.Text.ToString.Trim.Length > 0 Then
                    If ChDes11.Visible And ChDes11.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta11.Items(CboStatusLlanta11.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL11.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 11, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL11.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL11.Text.Trim), TPROFUNDIDAD_ACTUAL11.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL11.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                    If PTIPO_LLANTA = 1 Then
                        If TLL11.Text <> TLL11.Tag Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL11.Text, LL11.Text, 11, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    Else
                        If ChDes11.Visible And ChDes11.Checked Then
                            '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                            GRABA_ASIG_LLANTA(TLL11.Text, LL11.Text, 11, PTIPO_LLANTA, TCVE_UNI.Text)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If TLL12.Text.ToString.Trim.Length > 0 Then
                    If ChDes12.Visible And ChDes12.Checked Then
                        ST_LLANTA = CInt(CboStatusLlanta12.Items(CboStatusLlanta12.SelectedIndex))
                        SQL = "UPDATE GCLLANTAS SET POSICION = 0, UNIDAD = '', STATUS_LLANTA = " & ST_LLANTA & " WHERE NUM_ECONOMICO = '" & TLL12.Text & "'"
                    Else
                        SQL = "UPDATE GCLLANTAS SET POSICION = 12, STATUS_LLANTA = 1, UNIDAD = '" & TCVE_UNI.Text & "', 
                            KMS_ACTUAL = " & TKMS_ACTUAL12.Value & ", PROFUNDIDAD_ACTUAL = " & IIf(IsNumeric(TPROFUNDIDAD_ACTUAL12.Text.Trim), TPROFUNDIDAD_ACTUAL12.Text.Trim, 0) & "
                            WHERE NUM_ECONOMICO = '" & TLL12.Text & "'"
                    End If
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        cmd2.CommandText = SQL
                        returnValue = cmd2.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                        If PTIPO_LLANTA = 1 Then
                            If TLL12.Text <> TLL12.Tag Then
                                '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                                GRABA_ASIG_LLANTA(TLL12.Text, LL12.Text, 12, PTIPO_LLANTA, TCVE_UNI.Text)
                            End If
                        Else
                            If ChDes12.Visible And ChDes12.Checked Then
                                '                 NUM_ECO   CVE_LLANTA  ASIGNADA-DESASIGNADA
                                GRABA_ASIG_LLANTA(TLL12.Text, LL12.Text, 12, PTIPO_LLANTA, TCVE_UNI.Text)
                            End If
                        End If
                    End Using
                End If
            Catch ex As Exception
                Bitacora("60. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("60. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MsgBox("El registro se grabo satisfactoriamente")

        Catch ex As Exception
            Bitacora("56. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("56. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Var14 = ""
        Me.Close()
    End Sub

    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = "" : Var9 = "" : Var10 = "" : Var11 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var5
                L2.Text = Var8
                LtTipoUni.Text = Var9 & " " & Var11
                'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE unidad
                'Var3 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                'Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE NUM ECONOMICO
                'Var6 = Fg(Fg.Row, 3).ToString   'DESCR TIPO UNIDAD
                'Var7 = Fg(Fg.Row, 4).ToString   'PLACAS
                'Var8 = Fg(Fg.Row, 5).ToString   'MARCA UNIDAD
                'Var9 = Fg(Fg.Row, 6).ToString   'CVE_TIPO UNI
                'Var11 = Fg(Fg.Row, 8).ToString   'descr CVE_TIPO UNI
                'If Not IsNothing(Fg(Fg.Row, 7)) Then
                'Var10 = Fg(Fg.Row, 7).ToString   'CVE_TAQ
                'End If

                Var2 = ""
                Var4 = ""
                Var5 = ""

                LLANTAS_ASIGNADAS()

                TNUM_LLANTAS.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub


    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidades_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub LIMPIA_LLANTAS()
        Try
            L2.Text = ""
            LL1.Text = "" : LL2.Text = "" : LL3.Text = "" : LL4.Text = "" : LL5.Text = "" : LL6.Text = ""
            LL7.Text = "" : LL8.Text = "" : LL9.Text = "" : LL10.Text = "" : LL11.Text = "" : LL12.Text = ""

            TLL1.Text = "" : TLL2.Text = "" : TLL3.Text = "" : TLL4.Text = "" : TLL5.Text = "" : TLL6.Text = ""
            TLL7.Text = "" : TLL8.Text = "" : TLL9.Text = "" : TLL10.Text = "" : TLL11.Text = "" : TLL12.Text = ""
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR

                    LLANTAS_ASIGNADAS()
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_UNI.Text = ""
                    LIMPIA_LLANTAS()
                    TCVE_UNI.Select()
                End If
            Else
                LIMPIA_LLANTAS()
            End If
        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub ASIGNA_ST_EN_COMBO(FPOS As Integer, FSTATUS_LLANTA As String)
        Try

            Select Case FPOS
                Case 1
                    For k = 0 To CboStatusLlanta1.Items.Count - 1
                        If CInt(CboStatusLlanta1.Items(k)) = FSTATUS_LLANTA Then
                            CboStatusLlanta1.SelectedIndex = k
                            Exit For
                        End If
                    Next
                Case 2

                Case 3

                Case 4

                Case 5

                Case 6

                Case 7

                Case 8

                Case 9

                Case 10

                Case 11

                Case 12

            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        Try
            If LL1.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL1.Select()
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
            Var2 = "LlantasStatusPendiente_2"
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 1) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 1, Var5)
                LL1.Text = Var4 'CVE_LLANTA
                LL1.Tag = Var4 'CVE_LLANTA

                TLL1.Text = Var5 'NUM_ECONOMICO
                'tLL1.Tag = Var5 'NUM_ECONOMICO

                Ls1.Text = Var7

                'Var10 = Fg(Fg.Row, 9).ToString 'STATUS_LLANTA 

                ASIGNA_ST_EN_COMBO(1, Var10)

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL2.Focus()
            End If
        Catch ex As Exception
            Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("175. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        Try
            If LL2.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL2.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 2) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 2, Var5)
                LL2.Text = Var4 'ID LLANTA
                LL2.Tag = Var4 'NUM_ECONOMICO

                TLL2.Text = Var5 'NUM_ECONOMICO

                Ls2.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL3.Focus()
            End If
        Catch ex As Exception
            Bitacora("195. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("195. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        Try
            If LL3.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL3.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 3) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 3, Var5)
                LL3.Text = Var4 'ID LLANTA
                LL3.Tag = Var4 'NUM_ECONOMICO

                TLL3.Text = Var5 'NUM_ECONOMICO
                'tLL3.Tag = Var5 'NUM_ECONOMICO

                Ls3.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL4.Focus()
            End If
        Catch ex As Exception
            Bitacora("206. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("206. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Try
            If LL4.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL4.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 4) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 4, Var5)
                LL4.Text = Var4 'ID LLANTA
                LL4.Tag = Var4 'NUM_ECONOMICO

                TLL4.Text = Var5 'NUM_ECONOMICO
                'tLL4.Tag = Var5 'NUM_ECONOMICO

                Ls4.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL5.Focus()
            End If
        Catch ex As Exception
            Bitacora("235. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("235. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        Try
            If LL5.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL5.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 5) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 5, Var5)
                LL5.Text = Var4 'CVE_LLANTA
                LL5.Tag = Var4 'CVE_LLANTA

                TLL5.Text = Var5 'NUM_ECONOMICO
                'tLL5.Tag = Var5 'NUM_ECONOMICO

                Ls5.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL6.Focus()
            End If
        Catch ex As Exception
            Bitacora("255. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("255. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        Try
            If LL6.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL6.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 6) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 6, Var5)
                LL6.Text = Var4 'CVE_LLANTA
                LL6.Tag = Var4 'CVE_LLANTA

                TLL6.Text = Var5 'NUM_ECONOMICO
                'tLL6.Tag = Var5 'NUM_ECONOMICO

                Ls6.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL7.Focus()
            End If
        Catch ex As Exception
            Bitacora("275. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("275. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        Try
            If LL7.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL7.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 7) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 7, Var5)
                LL7.Text = Var4 'CVE_LLANTA
                LL7.Tag = Var4 'CVE_LLANTA

                TLL7.Text = Var5 'NUM_ECONOMICO
                'tLL7''NUM_ECONOMICO

                Ls7.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL8.Focus()
            End If
        Catch ex As Exception
            Bitacora("295. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("295. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        Try
            If LL8.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL8.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 8) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 8, Var5)
                LL8.Text = Var4 'CVE_LLANTA
                LL8.Tag = Var4 'CVE_LLANTA

                TLL8.Text = Var5 'NUM_ECONOMICO
                'tLL8.Tag = Var5 'NUM_ECONOMICO

                Ls8.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL9.Focus()
            End If
        Catch ex As Exception
            Bitacora("326. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("326. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        Try
            If LL9.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL9.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 9) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 9, Var5)
                LL9.Text = Var4 'CVE_LLANTA
                LL9.Tag = Var4 'CVE_LLANTA

                TLL9.Text = Var5 'NUM_ECONOMICO
                'tLL9''NUM_ECONOMICO

                Ls9.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL10.Focus()
            End If
        Catch ex As Exception
            Bitacora("335. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("335. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn10_Click(sender As Object, e As EventArgs) Handles Btn10.Click
        Try
            If LL10.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL10.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 10) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 10, Var5)
                LL10.Text = Var4 'CVE_LLANTA
                LL10.Tag = Var4 'CVE_LLANTA

                TLL10.Text = Var5 'NUM_ECONOMICO
                'tLL10.Tag = Var5 'NUM_ECONOMICO

                Ls10.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL11.Focus()
            End If
        Catch ex As Exception
            Bitacora("355. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("355. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn11_Click(sender As Object, e As EventArgs) Handles Btn11.Click
        Try
            If LL11.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL11.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 11) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 11, Var5)
                LL11.Text = Var4 'CVE_LLANTA
                LL11.Tag = Var4 'CVE_LLANTA

                TLL11.Text = Var5 'NUM_ECONOMICO
                'tLL11''NUM_ECONOMICO

                Ls11.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                TLL12.Focus()
            End If
        Catch ex As Exception
            Bitacora("425. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("425. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Btn12_Click(sender As Object, e As EventArgs) Handles Btn12.Click
        Try
            If LL12.Text.Trim.Length > 0 Then
                MsgBox("Por favor primero desasigne la llanta")
                Return
            End If

            TLL12.Select()
            Var2 = "LlantasStatusPendiente_2"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                If LLantaAsignada(Var5, 12) Then
                    Return
                End If
                ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 12, Var5)
                LL12.Text = Var4 'CVE_LLANTA
                LL12.Tag = Var4 'CVE_LLANTA

                TLL12.Text = Var5 'NUM_ECONOMICO
                'tLL12.Tag = Var5 'NUM_ECONOMICO

                Ls12.Text = Var7

                Var2 = "" : Var4 = "" : Var5 = ""
                'tLL2.Focus()
            End If
        Catch ex As Exception
            Bitacora("435. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("435. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function LLantaAsignada(fNO_ECONOMICO As String, fLlanta As Integer) As Boolean
        Try
            Dim Regresa As Boolean
            Regresa = False

            If fNO_ECONOMICO.Trim.Length = 0 Then
                Return False
            End If
            Select Case fLlanta
                Case 1
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or TLL6.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 2
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or TLL6.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 3
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or TLL6.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 4
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or TLL6.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 5
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL6.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 6
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 7
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 8
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL7.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 9
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 10
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 11
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Or
                        TLL12.Text = fNO_ECONOMICO Then
                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
                Case 12
                    If fNO_ECONOMICO.Trim.Length > 0 Then
                        If TLL1.Text = fNO_ECONOMICO Or TLL2.Text = fNO_ECONOMICO Or TLL3.Text = fNO_ECONOMICO Or TLL4.Text = fNO_ECONOMICO Or TLL5.Text = fNO_ECONOMICO Or
                        TLL6.Text = fNO_ECONOMICO Or TLL7.Text = fNO_ECONOMICO Or TLL8.Text = fNO_ECONOMICO Or TLL9.Text = fNO_ECONOMICO Or TLL10.Text = fNO_ECONOMICO Or
                        TLL11.Text = fNO_ECONOMICO Then

                            MsgBox("La llanta " & fNO_ECONOMICO & " ya se encuentra asignada en esta unidad")
                            Regresa = True
                        End If
                    End If
            End Select
            Return Regresa
        Catch ex As Exception
            Bitacora("375. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("375. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function

    Private Sub TLL1_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL1.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn1_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL2_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL2.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL3_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL3.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn3_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL4_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL4.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn4_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL5_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL5.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn5_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL6_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL6.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn6_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL7_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL7.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn7_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL8_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL8.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn8_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL9_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL9.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn8_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL10_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL10.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn10_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL11_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL11.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn11_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TLL12_KeyDown(sender As Object, e As KeyEventArgs) Handles TLL12.KeyDown
        If e.KeyCode = Keys.F2 Then
            Btn12_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TLL1_Validated(sender As Object, e As EventArgs) Handles TLL1.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL1.Text, 1) Then
                TLL1.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            DESCR = BUSCA_CAT("LlantasCveLlanta", TLL1.Text)
            If IsNumeric(DESCR) Then

                CVE_LLANTA = Convert.ToInt64(DESCR)

                If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                    MsgBox("La llanta se encuentra asignada a la  unidad " & Var6)
                    TLL1.Text = ""
                    LL1.Text = ""
                    Ls1.Text = ""
                    Return
                End If
            End If

            If TLL1.Text.Trim.Length > 0 Then
                Var6 = ""
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL1.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    IMAGEN_LLANTA(TCVE_UNI.Text, 1)
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 1, TLL1.Text)

                    'tLL1.Tag = tLL1.Text
                    LL1.Text = Var6
                    LL1.Tag = Var6
                    Ls1.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    TLL1.Tag = "" : LL1.Text = "" : LL1.Tag = "" : Ls1.Text = ""
                End If
            Else
                TLL1.Tag = "" : LL1.Text = "" : LL1.Tag = "" : Ls1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL2_Validated(sender As Object, e As EventArgs) Handles TLL2.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL2.Text, 2) Then
                TLL2.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL2.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL2.Text)
                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)
                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL2.Text = ""
                        LL2.Text = ""
                        Ls2.Text = ""
                        Return
                    End If
                End If
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL2.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 2, TLL2.Text)

                    LL2.Text = Var6 'CVE_LLANTA
                    LL2.Tag = Var6 'CVE_LLANTA
                    Ls2.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL2.Text = ""
                    TLL2.Text = ""
                    TLL2.Tag = ""
                End If
            Else
                LL2.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL3_Validated(sender As Object, e As EventArgs) Handles TLL3.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL3.Text, 3) Then
                TLL2.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL3.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL3.Text)
                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)
                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL3.Text = ""
                        LL3.Text = ""
                        Ls3.Text = ""
                        Return
                    End If
                End If
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL3.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 3, TLL3.Text)

                    'tLL3.Tag = tLL3.Text

                    LL3.Text = Var6
                    LL3.Tag = Var6

                    Ls3.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL3.Text = ""
                    TLL3.Text = ""
                    TLL3.Tag = ""
                End If
            Else
                LL3.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL4_Validated(sender As Object, e As EventArgs) Handles TLL4.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL4.Text, 4) Then
                TLL4.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL4.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL4.Text)

                If IsNumeric(DESCR) Then

                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL4.Text = ""
                        LL4.Text = ""
                        Ls4.Text = ""
                        Return
                    End If
                End If


                DESCR = BUSCA_CAT("LlantasNE", TLL4.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 4, TLL4.Text)

                    'tLL4.Tag = tLL4.Text

                    LL4.Text = Var6
                    LL4.Tag = Var6

                    Ls4.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL4.Text = ""
                    TLL4.Text = ""
                    TLL4.Tag = ""
                End If
            Else
                LL4.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL5_Validated(sender As Object, e As EventArgs) Handles TLL5.Validated
        Try
            Dim DESCR As String

            If LLantaAsignada(TLL5.Text, 5) Then
                TLL5.Text = ""
                Return
            End If

            Dim CVE_LLANTA As Long

            If TLL5.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL5.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL5.Text = ""
                        LL5.Text = ""
                        Ls5.Text = ""
                        Return
                    End If

                End If

                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL5.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 5, TLL5.Text)

                    'tLL5.Tag = tLL5.Text

                    LL5.Text = Var6
                    LL5.Tag = Var6

                    Ls5.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL5.Text = ""
                    TLL5.Text = ""
                    TLL5.Tag = ""
                End If
            Else
                LL5.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL6_Validated(sender As Object, e As EventArgs) Handles TLL6.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL6.Text, 6) Then
                TLL6.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL6.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL6.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL6.Text = ""
                        LL6.Text = ""
                        Ls6.Text = ""
                        Return
                    End If
                End If

                'BUSCA X NUM_ECONOMICO
                DESCR = BUSCA_CAT("LlantasNE", TLL6.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 6, TLL6.Text)

                    'tLL6.Tag = tLL6.Text

                    LL6.Text = Var6
                    LL6.Tag = Var6

                    Ls6.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL6.Text = ""
                    TLL6.Text = ""
                    TLL6.Tag = ""
                End If
            Else
                LL6.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL7_Validated(sender As Object, e As EventArgs) Handles TLL7.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL7.Text, 7) Then
                TLL7.Text = ""
                Return
            End If

            Dim CVE_LLANTA As Long

            If TLL7.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL7.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL7.Text = ""
                        LL7.Text = ""
                        Ls7.Text = ""
                        Return
                    End If
                End If

                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL7.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 7, TLL7.Text)

                    'tLL7.Tag = tLL7.Text

                    LL7.Text = Var6
                    LL7.Tag = Var6

                    Ls7.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL7.Text = ""
                    TLL7.Text = ""
                    TLL7.Tag = ""
                End If
            Else
                LL7.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL8_Validated(sender As Object, e As EventArgs) Handles TLL8.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL8.Text, 8) Then
                TLL8.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL8.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL8.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL8.Text = ""
                        LL8.Text = ""
                        Ls8.Text = ""
                        Return
                    End If
                End If

                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL8.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 8, TLL8.Text)

                    'tLL8.Tag = tLL8.Text

                    LL8.Text = Var6
                    LL8.Tag = Var6

                    Ls8.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL8.Text = ""
                    TLL8.Text = ""
                    TLL8.Tag = ""
                End If
            Else
                LL8.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL9_Validated(sender As Object, e As EventArgs) Handles TLL9.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL9.Text, 9) Then
                TLL9.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL9.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL9.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la unidad " & Var6)
                        TLL9.Text = ""
                        LL9.Text = ""
                        Ls9.Text = ""
                        Return
                    End If
                End If
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL9.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 9, TLL9.Text)

                    'tLL9.Tag = tLL9.Text

                    LL9.Text = Var6
                    LL9.Tag = Var6

                    Ls9.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL9.Text = ""
                    TLL9.Text = ""
                    TLL9.Tag = ""
                End If
            Else
                LL9.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL10_Validated(sender As Object, e As EventArgs) Handles TLL10.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL10.Text, 10) Then
                TLL10.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL10.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL10.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL10.Text = ""
                        LL10.Text = ""
                        Ls10.Text = ""
                        Return
                    End If
                End If

                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL10.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 10, TLL10.Text)

                    'tLL10.Tag = tLL10.Text

                    LL10.Text = Var6
                    LL10.Tag = Var6

                    Ls10.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL10.Text = ""
                    TLL10.Text = ""
                    TLL10.Tag = ""
                End If
            Else
                LL10.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL11_Validated(sender As Object, e As EventArgs) Handles TLL11.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL11.Text, 11) Then
                TLL11.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL11.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL11.Text)

                If IsNumeric(DESCR) Then
                    CVE_LLANTA = Convert.ToInt64(DESCR)
                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada a la  unidad " & Var6)
                        TLL11.Text = ""
                        LL11.Text = ""
                        Ls11.Text = ""
                        Return
                    End If
                End If
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL11.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 11, TLL11.Text)

                    LL11.Text = Var6
                    LL11.Tag = Var6

                    Ls11.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL11.Text = ""
                    TLL11.Text = ""
                    TLL11.Tag = ""
                End If
            Else
                LL11.Text = ""
            End If

        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLL12_Validated(sender As Object, e As EventArgs) Handles TLL12.Validated
        Try
            Dim DESCR As String
            If LLantaAsignada(TLL12.Text, 12) Then
                TLL12.Text = ""
                Return
            End If
            Dim CVE_LLANTA As Long

            If TLL12.Text.Trim.Length > 0 Then

                DESCR = BUSCA_CAT("LlantasCveLlanta", TLL12.Text)

                If IsNumeric(DESCR) Then

                    CVE_LLANTA = Convert.ToInt64(DESCR)

                    If LLANTA_ASIGNADA(TCVE_UNI.Text, CVE_LLANTA) Then
                        MsgBox("La llanta ya fue asignada en otra unidad")
                        TLL12.Text = ""
                        LL12.Text = ""
                        Ls12.Text = ""
                        Return
                    End If
                End If
                'BUSCA X NUM ECONOMICO Y REGRESA CVE_LLANTA
                DESCR = BUSCA_CAT("LlantasNE", TLL12.Text)
                If DESCR <> "" Then
                    'Var6 = dr.ReadNullAsEmptyString("CVE_LLANTA")
                    'Var7 = dr.ReadNullAsEmptyString("ST_LLANTA")
                    ASIGNAR_LLANTAS_AL_BOTON(L2.Tag, 12, TLL12.Text)

                    'tLL12.Tag = tLL12.Text

                    LL12.Text = Var6
                    LL12.Tag = Var6

                    Ls12.Text = Var7
                Else
                    MsgBox("Llanta inexistente")
                    LL12.Text = ""
                    TLL12.Text = ""
                    TLL12.Tag = ""
                End If
            Else
                LL12.Text = ""
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmAsignacionLlantas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub TCVE_UNI_TextChanged(sender As Object, e As EventArgs) Handles TCVE_UNI.TextChanged
        Try
            If TCVE_UNI.Text.Length = 5 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR

                    LLANTAS_ASIGNADAS()
                Else
                    LIMPIA_LLANTAS()
                End If
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChDes1_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes1.CheckedChanged

        Try
            If TLL1.Tag.Trim.Length = 0 Then
                ChDes1.Checked = False
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub ChDes2_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes2.CheckedChanged
        If TLL2.Tag.Trim.Length = 0 Then
            ChDes2.Checked = False
        End If
    End Sub
    Private Sub ChDes3_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes3.CheckedChanged
        If TLL3.Tag.Trim.Length = 0 Then
            ChDes3.Checked = False
        End If
    End Sub
    Private Sub ChDes4_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes4.CheckedChanged
        If TLL4.Tag.Trim.Length = 0 Then
            ChDes4.Checked = False
        End If
    End Sub
    Private Sub ChDes5_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes5.CheckedChanged
        If TLL5.Tag.Trim.Length = 0 Then
            ChDes5.Checked = False
        End If
    End Sub
    Private Sub ChDes6_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes6.CheckedChanged
        If TLL6.Tag.Trim.Length = 0 Then
            ChDes6.Checked = False
        End If
    End Sub
    Private Sub ChDes7_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes7.CheckedChanged
        If TLL7.Tag.Trim.Length = 0 Then
            ChDes7.Checked = False
        End If
    End Sub
    Private Sub ChDes8_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes8.CheckedChanged
        If TLL8.Tag.Trim.Length = 0 Then
            ChDes8.Checked = False
        End If
    End Sub
    Private Sub ChDes9_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes9.CheckedChanged
        Try
            If TLL9.Tag.Trim.Length = 0 Then
                ChDes9.Checked = False
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChDes10_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes10.CheckedChanged
        Try
            If TLL10.Tag.Trim.Length = 0 Then
                ChDes10.Checked = False
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChDes11_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes11.CheckedChanged
        Try
            If TLL11.Tag.Trim.Length = 0 Then
                ChDes11.Checked = False
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChDes12_CheckedChanged(sender As Object, e As EventArgs) Handles ChDes12.CheckedChanged
        Try
            If TLL12.Tag.Trim.Length = 0 Then
                ChDes12.Checked = False
            End If
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChDesT_CheckedChanged(sender As Object, e As EventArgs) Handles ChDesT.CheckedChanged
        Try
            Dim CheckOk As Boolean

            If ChDesT.Checked Then
                CheckOk = True
            Else
                CheckOk = False
            End If

            If TLL1.Text.Trim.Length > 0 Then ChDes1.Checked = CheckOk
            If TLL2.Text.Trim.Length > 0 Then ChDes2.Checked = CheckOk
            If TLL3.Text.Trim.Length > 0 Then ChDes3.Checked = CheckOk
            If TLL4.Text.Trim.Length > 0 Then ChDes4.Checked = CheckOk
            If TLL5.Text.Trim.Length > 0 Then ChDes5.Checked = CheckOk
            If TLL6.Text.Trim.Length > 0 Then ChDes6.Checked = CheckOk
            If TLL7.Text.Trim.Length > 0 Then ChDes7.Checked = CheckOk
            If TLL8.Text.Trim.Length > 0 Then ChDes8.Checked = CheckOk
            If TLL9.Text.Trim.Length > 0 Then ChDes9.Checked = CheckOk
            If TLL10.Tag.Trim.Length > 0 Then ChDes10.Checked = CheckOk
            If TLL11.Tag.Trim.Length > 0 Then ChDes11.Checked = CheckOk
            If TLL12.Tag.Trim.Length > 0 Then ChDes12.Checked = CheckOk
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTT9_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnTT9.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Boton = 9
            MnuSeleccione.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub
    Private Sub BtnTT10_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnTT10.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Boton = 10
            MnuSeleccione.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub
    Private Sub BtnTT11_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnTT11.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Boton = 11
            MnuSeleccione.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub
    Private Sub BtnTT12_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnTT12.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Boton = 12
            MnuSeleccione.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub
    Private Sub MnuOcultarLLanta_Click(sender As Object, e As EventArgs) Handles MnuOcultarLLanta.Click
        Select Case Boton
            Case 9
                BtnTT9.Visible = False
            Case 10
                BtnTT10.Visible = False
            Case 11
                BtnTT11.Visible = False
            Case 12
                BtnTT12.Visible = False
        End Select
        Boton = 0
    End Sub

    Private Sub LtTanque2_DoubleClick(sender As Object, e As EventArgs) Handles LtTanque2.DoubleClick
        BtnTT9.Visible = True
        BtnTT10.Visible = True
        BtnTT11.Visible = True
        BtnTT12.Visible = True
    End Sub

    Private Sub BtnCreaInspec_Click(sender As Object, e As EventArgs) Handles BtnCreaInspec.Click
        Dim CVE_INS As Long

        If MsgBox("Realmente desea generar las inspecciones?", vbYesNo) = vbNo Then
            Return
        End If

        CVE_INS = GET_MAX("GCINSPEC_LLANTAS", "CVE_INS")

        Try
            TKMS_ACTUAL1.UpdateValueWithCurrentText()
            TKMS_ACTUAL2.UpdateValueWithCurrentText()
            TKMS_ACTUAL3.UpdateValueWithCurrentText()
            TKMS_ACTUAL5.UpdateValueWithCurrentText()
            TKMS_ACTUAL6.UpdateValueWithCurrentText()
            TKMS_ACTUAL7.UpdateValueWithCurrentText()
            TKMS_ACTUAL8.UpdateValueWithCurrentText()
            TKMS_ACTUAL9.UpdateValueWithCurrentText()
            TKMS_ACTUAL10.UpdateValueWithCurrentText()
            TKMS_ACTUAL11.UpdateValueWithCurrentText()
            TKMS_ACTUAL12.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        SQL = "INSERT INTO GCINSPEC_LLANTAS (CVE_INS, UNIDAD, NUM_ECONOMICO, FECHA, STATUS, MARCA, MODELO, TIPO_LLANTA, TIPO_NUEVA_RENO, FECHA_MON, 
                COSTO_LLANTA_MN, KMS_MONTAR, KMS_DESMONTAR, KMS_RECORRIDOS, PROFUNDIDAD_ACTUAL, PROFUNDIDAD_ACTUAL2, PROFUNDIDAD_ACTUAL3, PROFUNDIDAD_ACTUAL4, 
                PRESION_ACTUAL, PROFUNDIDA_ORIGINAL, POSICION, DESGASTE, OBS, FECHAELAB, UUID, KMS_ACTUAL, TIPO_RIN) 
                VALUES(
                @CVE_INS, @UNIDAD, @NUM_ECONOMICO, @FECHA, 'E', @MARCA, @MODELO, @TIPO_LLANTA, @TIPO_NUEVA_RENO, @FECHA_MON, @COSTO_LLANTA_MN, @KMS_MONTAR, 
                @KMS_DESMONTAR, @KMS_RECORRIDOS, @PROFUNDIDAD_ACTUAL, @PROFUNDIDAD_ACTUAL2, @PROFUNDIDAD_ACTUAL3, @PROFUNDIDAD_ACTUAL4, @PRESION_ACTUAL, 
                @PROFUNDIDA_ORIGINAL, @POSICION, @DESGASTE, @OBS, GETDATE(), NEWID(), @KMS_ACTUAL, @TIPO_RIN)"
        Try
            For k = 1 To 12
                Select Case k
                    Case 1
                        If TLL1.Text.Trim.Length > 0 Then

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL1.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL1.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 1
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL1.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 2
                        If TLL2.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL2.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0

                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL2.Text

                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 2
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL2.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 3
                        If TLL3.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL3.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL3.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL3.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 3
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL3.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 4
                        If TLL4.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL4.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL4.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL4.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 4
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL4.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 5
                        If TLL5.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL5.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL5.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL5.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 5
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL5.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 6
                        If TLL6.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL6.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL6.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL6.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 6
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL6.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 7
                        If TLL7.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL7.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL7.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL7.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 7
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL7.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 8
                        If TLL8.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL8.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL8.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL8.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 8
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL8.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 9
                        If TLL9.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL9.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL9.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL9.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 9
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL9.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 10
                        If TLL10.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL10.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL10.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL10.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 10
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL10.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 11
                        If TLL11.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL11.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL11.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL11.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 11
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL11.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                    Case 12
                        If TLL12.Text.Trim.Length > 0 Then
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_INS", SqlDbType.VarChar).Value = CVE_INS
                                cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = TCVE_UNI.Text
                                cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = TLL12.Text
                                cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MODELO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIPO_NUEVA_RENO", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = Now.Date
                                cmd.Parameters.Add("@COSTO_LLANTA_MN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_MONTAR", SqlDbType.Float).Value = TKMS_ACTUAL12.Value
                                cmd.Parameters.Add("@PROFUNDIDA_ORIGINAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_DESMONTAR", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@KMS_RECORRIDOS", SqlDbType.Float).Value = 9
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = TPROFUNDIDAD_ACTUAL12.Text
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL2", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL3", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL4", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@PRESION_ACTUAL", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@POSICION", SqlDbType.SmallInt).Value = 12
                                cmd.Parameters.Add("@DESGASTE", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@KMS_ACTUAL", SqlDbType.Float).Value = TKMS_ACTUAL12.Value
                                cmd.Parameters.Add("@TIPO_RIN", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            End Using
                        End If
                End Select
            Next

            Dim result = RJMessageBox.Show("Las inspecciones se grabaron correctamente", "", MessageBoxButtons.OK)
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
End Class