Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports C1.Win.C1Input
Imports C1.Win.C1Command

Public Class FrmInvenAE
    Private PASA As Boolean = True
    Private ART_NEW As Boolean
    Private ENTRA As Boolean
    Private ENTRA_FLEXI As Boolean
    Private ARTICULO As String
    Private ENTRA_A As Boolean = True
    Private AllowedKeys As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789,._-/#@"

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Private Sub FrmInvenAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

    End Sub

    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try

        If DialogOK = "Show" Then
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            Me.CenterToScreen()
        End If

        If MULTIALMACEN = 1 Then
            BtnExistXAlm.Visible = True
        Else
            BtnExistXAlm.Visible = False
        End If

        ENTRA_FLEXI = False

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.CustomFormat = "dd/MM/yyyy"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.EditFormat.CustomFormat = "dd/MM/yyyy"
        Me.KeyPreview = True

        FgA.Dock = DockStyle.Fill

        TCANT_PROMO1.Value = 0
        TCANT_PROMO2.Value = 0
        TCANT_PROMO3.Value = 0
        TCANT_PROMO4.Value = 0
        TCANT_PROMO5.Value = 0
        TPORC_PROMO1.Value = 0
        TPORC_PROMO2.Value = 0
        TPORC_PROMO3.Value = 0
        TPORC_PROMO4.Value = 0
        TPORC_PROMO5.Value = 0
        TPRECIO_PROMO1.Value = 0
        TPRECIO_PROMO2.Value = 0
        TPRECIO_PROMO3.Value = 0
        TPRECIO_PROMO4.Value = 0
        TPRECIO_PROMO5.Value = 0

        BtnLinea.FlatStyle = FlatStyle.Flat
        BtnLinea.FlatAppearance.BorderSize = 0
        BtnMoneda.FlatStyle = FlatStyle.Flat
        BtnMoneda.FlatAppearance.BorderSize = 0
        BtnClaveSAT.FlatStyle = FlatStyle.Flat
        BtnClaveSAT.FlatAppearance.BorderSize = 0
        BtnUnidadSAT.FlatStyle = FlatStyle.Flat
        BtnUnidadSAT.FlatAppearance.BorderSize = 0
        BtnEsquema.FlatStyle = FlatStyle.Flat
        BtnEsquema.FlatAppearance.BorderSize = 0
        BtnUnidadPeso.FlatStyle = FlatStyle.Flat
        BtnUnidadPeso.FlatAppearance.BorderSize = 0
        BtnBienesTransp.FlatStyle = FlatStyle.Flat
        BtnBienesTransp.FlatAppearance.BorderSize = 0
        BtnCveMaterialPeligroso.FlatStyle = FlatStyle.Flat
        BtnCveMaterialPeligroso.FlatAppearance.BorderSize = 0
        BtnEmbalaje.FlatStyle = FlatStyle.Flat
        BtnEmbalaje.FlatAppearance.BorderSize = 0
        BtnFotDocA.FlatStyle = FlatStyle.Flat
        BtnFotDocA.FlatAppearance.BorderSize = 0
        BtnFotDocE.FlatStyle = FlatStyle.Flat
        BtnFotDocE.FlatAppearance.BorderSize = 0

        SplitM.Dock = DockStyle.Fill
        SplitM.BorderWidth = 1
        Split1.AutoScroll = True

        TAB1.Dock = DockStyle.Fill

        CboMatPeligroso.Items.Add("Sí")
        CboMatPeligroso.Items.Add("No")

        Fg.Cols(0).Width = 20
        FgL.Cols(0).Width = 10

        FgL.Rows.Count = 1
        FgL.Cols.Fixed = 3

        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.None


        Mycolor1 = Color.LightGreen
        Mycolor2 = Color.White

        If PASS_GRUPOCE.ToUpper = "BUS" Then
            For k = 1 To FgL.Cols.Count - 1
                FgL(0, k) = FgL(0, k) & k
            Next
        Else
            FgL.Cols(4).Visible = False
        End If
        FgA.Cols(2).ComboList = "N|C|P"
        MAX_LENGHT()
        Try
            CboAPL_MAN_IMP.Items.Clear()
            CboAPL_MAN_IMP.Items.Add("I.E.P.S.")
            CboAPL_MAN_IMP.Items.Add("Impuesto2")
            CboAPL_MAN_IMP.Items.Add("Impuesto3")
            CboAPL_MAN_IMP.Items.Add("I.V.A.")

            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM PRECIOS" & Empresa
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            CBOPREC_PROMO1.Items.Add(Format(dr("CVE_PRECIO"), "00") & "  " & dr("DESCRIPCION"))
                            CBOPREC_PROMO2.Items.Add(Format(dr("CVE_PRECIO"), "00") & "  " & dr("DESCRIPCION"))
                            CBOPREC_PROMO3.Items.Add(Format(dr("CVE_PRECIO"), "00") & "  " & dr("DESCRIPCION"))
                            CBOPREC_PROMO4.Items.Add(Format(dr("CVE_PRECIO"), "00") & "  " & dr("DESCRIPCION"))
                            CBOPREC_PROMO5.Items.Add(Format(dr("CVE_PRECIO"), "00") & "  " & dr("DESCRIPCION"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try
            RadPromoPrec.Checked = True
        Catch ex As Exception
            Bitacora("36. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        LIMPIAR()

        TAB1.SelectedIndex = 0
        ART_NEW = False
        If Var1 = "Nuevo" Then
            ART_NEW = True
            Try
                TCVE_ART.Select()

                CARGAR_PRECIOS()
                CARGAR_CAMPLIB()

            Catch ex As Exception
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            ARTICULO = Var2
            DESPLEGAR()

            Try
                If Var3 = "No" Then
                    BarGrabar.Visible = False
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo1)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo4)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo14)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo15)
                    SET_ALL_CONTROL_READ_AND_ENABLED(Gpo16)

                    Gpo4.Enabled = False
                    Gpo7.Enabled = False
                    Gpo8.Enabled = False
                    Gpo9.Enabled = False
                    Gpo10.Enabled = False
                    Gpo11.Enabled = False
                    Gpo12.Enabled = False
                End If
            Catch ex As Exception
                Bitacora("36. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        ENTRA = True
        ENTRA_FLEXI = True
    End Sub
    Sub DESPLEGAR()
        Try
            SQL = "SELECT I.CVE_ART, I.DESCR, I.LIN_PROD, I.CON_SERIE, I.UNI_MED, I.UNI_EMP, I.CTRL_ALM, I.TIEM_SURT, I.STOCK_MIN, I.STOCK_MAX,
                I.TIP_COSTEO, I.NUM_MON, I.COMP_X_REC, I.FCH_ULTCOM, I.FCH_ULTVTA, I.PEND_SURT, I.EXIST, I.COSTO_PROM, I.ULT_COSTO, I.CVE_OBS,
                I.TIPO_ELE, I.UNI_ALT, I.FAC_CONV, I.APART, I.CON_LOTE, I.CON_PEDIMENTO, I.PESO, I.VOLUMEN, I.VTAS_ANL_C, I.VTAS_ANL_M,
                I.COMP_ANL_C, I.COMP_ANL_M, I.CUENT_CONT, I.CVE_IMAGEN, I.STATUS, I.MAN_IEPS, I.APL_MAN_IMP, I.CUOTA_IEPS, I.APL_MAN_IEPS,
                I.CVE_PRODSERV, I.CVE_UNIDAD, ISNULL(OB.STR_OBS,'') AS OBS_STR, ISNULL(P.CVE_ESQIMPU,1) AS CVE_ESQ, ISNULL(DESCRIPESQ,'') AS DES_ESQ
                FROM INVE" & Empresa & " I
                LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU
                LEFT JOIN OINVE" & Empresa & " OB ON OB.CVE_OBS = I.CVE_OBS
                WHERE CVE_ART = '" & ARTICULO & "'"

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCVE_ART.Text = dr("CVE_ART").ToString
                        TDESCR.Text = dr("DESCR").ToString
                        TLIN_PROD.Text = dr("LIN_PROD").ToString
                        ChNUM_SERIE.Checked = IIf(dr("CON_SERIE").ToString = "S", True, False)
                        TUNI_MED.Text = dr.ReadNullAsEmptyString("UNI_MED").ToString
                        Try
                            TUNI_EMP.Value = dr("UNI_EMP").ToString
                        Catch ex As Exception
                            TUNI_EMP.Value = 1
                        End Try

                        TCTRL_ALM.Text = dr("CTRL_ALM").ToString
                        Try
                            TTIEM_SURT.Value = dr("TIEM_SURT").ToString
                        Catch ex As Exception
                            TTIEM_SURT.Value = 0
                        End Try
                        Try
                            TSTOCK_MIN.Value = dr("STOCK_MIN").ToString
                        Catch ex As Exception
                            TSTOCK_MIN.Value = 0
                        End Try
                        Try
                            TSTOCK_MAX.Value = dr("STOCK_MAX").ToString
                        Catch ex As Exception
                            TSTOCK_MAX.Value = 0
                        End Try

                        Select Case dr("TIP_COSTEO").ToString
                            Case "U"
                                RadUEPS.Checked = True
                            Case "E"
                                RadPEPS.Checked = True
                            Case "P"
                                RadPROMEDIO.Checked = True
                            Case "S"
                                RadESTANDAR.Checked = True
                            Case "I"
                                RadIDENTIFICADO.Checked = True
                        End Select
                        Try
                            TNUM_MON.Value = dr("NUM_MON").ToString
                            If TNUM_MON.Value = 0 Then
                                TNUM_MON.Value = 1
                            End If
                        Catch ex As Exception
                            TNUM_MON.Value = 1
                        End Try


                        If IsDate(dr("FCH_ULTCOM").ToString) Then
                            F2.Value = dr("FCH_ULTCOM").ToString
                        Else
                            F2.Value = Now
                        End If
                        If IsDate(dr("FCH_ULTVTA").ToString) Then
                            F1.Value = dr("FCH_ULTVTA").ToString
                        Else
                            F1.Value = Now
                        End If

                        Try
                            TPEND_SURT.Value = dr("PEND_SURT").ToString
                        Catch ex As Exception
                            TPEND_SURT.Value = 0
                        End Try

                        Try
                            TCOMP_X_REC.Value = dr("COMP_X_REC").ToString
                        Catch ex As Exception
                            TCOMP_X_REC.Value = 0
                        End Try

                        TEXIST.Text = dr("EXIST").ToString
                        Try
                            TCOSTO_PROM.Value = Math.Round(dr.ReadNullAsEmptyDecimal("COSTO_PROM"), 6)
                        Catch ex As Exception
                            TCOSTO_PROM.Value = 0
                        End Try
                        Try
                            TULT_COSTO.Value = Math.Round(dr.ReadNullAsEmptyDecimal("ULT_COSTO"), 6)
                        Catch ex As Exception
                            TULT_COSTO.Value = 0
                        End Try

                        'CVE OBS
                        TCVE_OBS.Text = dr("OBS_STR")
                        TCVE_OBS.Tag = dr("CVE_OBS")

                        Select Case dr("TIPO_ELE").ToString
                            Case "P"
                                RadProducto.Checked = True
                            Case "S"
                                RadServicio.Checked = True
                            Case "K"
                                RadKit.Checked = True
                            Case "G"
                                RadGrupoProd.Checked = True
                        End Select
                        TUNI_ALT.Text = dr("UNI_ALT").ToString

                        Try
                            TFAC_CONV.Value = dr("FAC_CONV").ToString
                            If TFAC_CONV.Value = 0 Then
                                TFAC_CONV.Value = 1
                            End If
                        Catch ex As Exception
                            TFAC_CONV.Value = 1
                        End Try
                        Try
                            TAPART.Value = dr("APART").ToString
                        Catch ex As Exception
                            TAPART.Value = 0
                        End Try

                        If dr("CON_LOTE").ToString = "SByte" Then
                            ChCON_LOTE.Checked = True
                        Else
                            ChCON_LOTE.Checked = False
                        End If
                        If dr("CON_PEDIMENTO").ToString = "SByte" Then
                            ChCON_PEDIMENTO.Checked = True
                        Else
                            ChCON_PEDIMENTO.Checked = False
                        End If
                        Try
                            TPESO.Value = dr("PESO").ToString
                            TVOLUMEN.Value = dr("VOLUMEN").ToString
                        Catch ex As Exception
                        End Try

                        TCVE_ESQIMPU.Text = dr.ReadNullAsEmptyInteger("CVE_ESQ")
                        TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                        LtEsquema.Text = dr("DES_ESQ")

                        Try
                            TVTAS_ANL_C.Value = dr("VTAS_ANL_C").ToString
                            TVTAS_ANL_M.Value = Math.Round(dr.ReadNullAsEmptyDecimal("VTAS_ANL_M"), 6)
                            TCOMP_ANL_C.Value = dr("COMP_ANL_C").ToString
                            TCOMP_ANL_M.Value = Math.Round(dr.ReadNullAsEmptyDecimal("COMP_ANL_M"), 6)
                        Catch ex As Exception
                        End Try

                        TCUENT_CONT.Text = dr.ReadNullAsEmptyString("CUENT_CONT").ToString
                        Pic.Tag = dr.ReadNullAsEmptyString("CVE_IMAGEN").ToString

                        If Pic.Tag.ToString.Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\IMAGENES\" & Pic.Tag) Then
                                Pic.Image = Image.FromFile(Application.StartupPath & "\IMAGENES\" & Pic.Tag)
                            Else
                                Pic.Image = PicFoto.Image
                            End If
                        Else
                            Pic.Image = PicFoto.Image
                        End If

                        If dr.ReadNullAsEmptyString("MAN_IEPS").ToString = "S" Then
                            ChMAN_IEPS.Checked = True
                            CboAPL_MAN_IMP.Enabled = True
                            TCUOTA_IEPS.Enabled = True
                            ChMAN_IEPS.Checked = True
                            Select Case dr.ReadNullAsEmptyInteger("APL_MAN_IMP").ToString
                                Case 1
                                    CboAPL_MAN_IMP.SelectedIndex = 0
                                Case 2
                                    CboAPL_MAN_IMP.SelectedIndex = 1
                                Case 3
                                    CboAPL_MAN_IMP.SelectedIndex = 2
                                Case 4
                                    CboAPL_MAN_IMP.SelectedIndex = 3
                            End Select
                            TCUOTA_IEPS.Value = dr.ReadNullAsEmptyInteger("CUOTA_IEPS").ToString
                            Select Case dr.ReadNullAsEmptyString("APL_MAN_IEPS").ToString
                                Case "C"
                                    RadUEPS2.Checked = True
                                Case "M"
                                    RadPEPS2.Checked = True
                                Case "A"
                                    RadPromedio2.Checked = True
                            End Select
                        Else
                            ChMAN_IEPS.Checked = False
                            CboAPL_MAN_IMP.Enabled = False
                            TCUOTA_IEPS.Enabled = False
                        End If

                        TCVE_PRODSERV.Text = dr.ReadNullAsEmptyString("CVE_PRODSERV").ToString
                        TCVE_UNIDAD.Text = dr.ReadNullAsEmptyString("CVE_UNIDAD").ToString

                        CARGAR_ALTERNAS()
                        CARGAR_PRECIOS()
                        CARGAR_CAMPLIB()
                        CARGAR_CARTA_PORTE_PROD()

                        Var10 = ""
                        CARGAR_PROMOCIONES()

                        If Var10 = "ERROR TABLA" Then
                            CREA_TABLAS_PROMOCIONES()
                        End If
                    End If
                End Using
            End Using

            TCVE_ART.Enabled = False
            TDESCR.Select()
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_PROMOCIONES()
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "Select ISNULL(P.TIPO,0) AS TIP, P.CVE_ART, P.RANGO11, P.RANGO12, P.RANGO21, P.RANGO22, P.RANGO31, P.RANGO32, P.RANGO41, 
                    P.RANGO42, P.RANGO51, P.RANGO52, P.PORC1, P.PORC2, P.PORC3, P.PORC4, P.PORC5, 
                    ISNULL(P.LP1,-1) AS P1, ISNULL(P.LP2,-1) AS P2, ISNULL(P.LP3,-1) AS P3, ISNULL(P.LP4,-1) AS P4, ISNULL(P.LP5,-1) AS P5
                    FROM GCPROMOCIONES P 
                    WHERE CVE_ART = '" & TCVE_ART.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr("TIP") = 1 Then
                            RadPromoPrec.Checked = True
                        Else
                            RadPromoPorc.Checked = True
                        End If
                        TCANT_PROMO1.Value = dr.ReadNullAsEmptyDecimal("RANGO11")
                        TCANT_PROMO2.Value = dr.ReadNullAsEmptyDecimal("RANGO21")
                        TCANT_PROMO3.Value = dr.ReadNullAsEmptyDecimal("RANGO31")
                        TCANT_PROMO4.Value = dr.ReadNullAsEmptyDecimal("RANGO41")
                        TCANT_PROMO5.Value = dr.ReadNullAsEmptyDecimal("RANGO51")

                        TPORC_PROMO1.Value = dr.ReadNullAsEmptyDecimal("PORC1")
                        TPORC_PROMO2.Value = dr.ReadNullAsEmptyDecimal("PORC2")
                        TPORC_PROMO3.Value = dr.ReadNullAsEmptyDecimal("PORC3")
                        TPORC_PROMO4.Value = dr.ReadNullAsEmptyDecimal("PORC4")
                        TPORC_PROMO5.Value = dr.ReadNullAsEmptyDecimal("PORC5")

                        If dr.ReadNullAsEmptyDecimal("PORC1") > 0 Then TPRECIO_PROMO1.Value = Fg(1, 3) - (Fg(1, 3) * dr.ReadNullAsEmptyDecimal("PORC1") / 100)
                        If dr.ReadNullAsEmptyDecimal("PORC2") > 0 Then TPRECIO_PROMO2.Value = Fg(1, 3) - (Fg(1, 3) * dr.ReadNullAsEmptyDecimal("PORC2") / 100)
                        If dr.ReadNullAsEmptyDecimal("PORC3") > 0 Then TPRECIO_PROMO3.Value = Fg(1, 3) - (Fg(1, 3) * dr.ReadNullAsEmptyDecimal("PORC3") / 100)
                        If dr.ReadNullAsEmptyDecimal("PORC4") > 0 Then TPRECIO_PROMO4.Value = Fg(1, 3) - (Fg(1, 3) * dr.ReadNullAsEmptyDecimal("PORC4") / 100)
                        If dr.ReadNullAsEmptyDecimal("PORC5") > 0 Then TPRECIO_PROMO5.Value = Fg(1, 3) - (Fg(1, 3) * dr.ReadNullAsEmptyDecimal("PORC5") / 100)

                        CBOPREC_PROMO1.SelectedIndex = IIf(dr.ReadNullAsEmptyDecimal("RANGO11") > 0, dr("P1"), -1)
                        CBOPREC_PROMO2.SelectedIndex = IIf(dr.ReadNullAsEmptyDecimal("RANGO21") > 0, dr("P2"), -1)
                        CBOPREC_PROMO3.SelectedIndex = IIf(dr.ReadNullAsEmptyDecimal("RANGO31") > 0, dr("P3"), -1)
                        CBOPREC_PROMO4.SelectedIndex = IIf(dr.ReadNullAsEmptyDecimal("RANGO41") > 0, dr("P4"), -1)
                        CBOPREC_PROMO5.SelectedIndex = IIf(dr.ReadNullAsEmptyDecimal("RANGO51") > 0, dr("P5"), -1)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            Var10 = "ERROR TABLA"
        End Try
    End Sub
    Sub CARGAR_CARTA_PORTE_PROD()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(MAT_PELIGROSO,1) AS MAT_PELI, ISNULL(CVE_MAT_PELIGROSO,'') AS CVE_MAT, 
                    EMBALAJE, UNIDADPESO, BIENESTRANSP
                    FROM INVE_CP 
                    WHERE CVE_ART = '" & TCVE_ART.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        If dr.ReadNullAsEmptyInteger("MAT_PELI") = 0 Then
                            CboMatPeligroso.SelectedIndex = 0
                            PanelMatPeligro.Visible = True
                        Else
                            PanelMatPeligro.Visible = False
                            CboMatPeligroso.SelectedIndex = 1
                        End If
                        TUnidadPeso.Text = dr.ReadNullAsEmptyString("UNIDADPESO")
                        TBienesTransp.Text = dr.ReadNullAsEmptyString("BIENESTRANSP")
                        COLOCA_BIENES_TRANSP()
                        TCveMaterialPeligroso.Text = dr.ReadNullAsEmptyString("CVE_MAT")
                        LTCveMaterialPeligroso.Text = GET_MAT_PELIGROSO(TCveMaterialPeligroso.Text)
                        TEmbalaje.Text = dr.ReadNullAsEmptyString("EMBALAJE")
                        LTEmbalaje.Text = GET_MAT_EMBALAJE(TEmbalaje.Text)
                    Else
                        CboMatPeligroso.SelectedIndex = 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub MAX_LENGHT()
        TCVE_ART.MaxLength = 16
        TDESCR.MaxLength = 40
        TLIN_PROD.MaxLength = 5
        TUNI_MED.MaxLength = 10
        TCTRL_ALM.MaxLength = 10
        TUNI_ALT.MaxLength = 10
        TCUENT_CONT.MaxLength = 28
        TCVE_PRODSERV.MaxLength = 9
        TCVE_UNIDAD.MaxLength = 4


    End Sub
    Sub CARGAR_ALTERNAS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CVE_ART, CVE_ALTER, TIPO, CVE_CLPV, ISNULL(C.NOMBRE,'') AS NOMCLIE, ISNULL(P.NOMBRE,'') AS NOMPROV " &
                "FROM CVES_ALTER" & Empresa & " A " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = A.CVE_CLPV AND TIPO = 'C' " &
                "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = A.CVE_CLPV AND TIPO = 'P' " &
                "WHERE CVE_ART = '" & TCVE_ART.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgA.Rows.Count = 1

            Do While dr.Read
                FgA.AddItem("" & vbTab & dr("CVE_ALTER") & vbTab & dr("TIPO") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMCLIE") & dr("NOMPROV"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("45. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_PRECIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim TienePrecios As Boolean

            cmd.Connection = cnSAE

            SQL = "SELECT pxp.CVE_ART, DESCRIPCION, pxp.CVE_PRECIO, pxp.PRECIO " &
                "FROM PRECIO_X_PROD" & Empresa & " pxp " &
                "LEFT JOIN PRECIOS" & Empresa & " p ON p.CVE_PRECIO = pxp.CVE_PRECIO " &
                "WHERE pxp.CVE_ART = '" & TCVE_ART.Text & "' ORDER BY CVE_PRECIO"

            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            TienePrecios = False
            Do While dr.Read
                TienePrecios = True
                Fg.AddItem("" & vbTab & dr("CVE_PRECIO") & vbTab & dr("DESCRIPCION") & vbTab & dr("PRECIO") & vbTab & "")
            Loop
            dr.Close()
            If Not TienePrecios Then

                SQL = "SELECT DESCRIPCION, CVE_PRECIO FROM PRECIOS" & Empresa & " ORDER BY CVE_PRECIO"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Fg.Rows.Count = 1
                TienePrecios = False
                Do While dr.Read
                    TienePrecios = True
                    Fg.AddItem("" & vbTab & dr("CVE_PRECIO") & vbTab & dr("DESCRIPCION") & vbTab & "0" & vbTab & "")
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            MsgBox("55. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("55. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPLIB()
        Try
            Dim TIPO_CAMPO As String, FIELD_NAME As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            'TAB1.SelectedIndex = 2
            FgL.Rows.Count = 1

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'INVE_CLIB'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE("INVE_CLIB" & Empresa, dr("CAMPO")) Then
                    FgL.AddItem("" & vbTab & dr.ReadNullAsEmptyString("CAMPO") & vbTab & dr.ReadNullAsEmptyString("ETIQUETA") & vbTab & " " & vbTab & " ")
                End If
            Loop
            dr.Close()
            SQL = "SELECT * FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = '" & TCVE_ART.Text & "'"
            cmd.CommandText = SQL               '1 nombre del campo FIELD
            dr = cmd.ExecuteReader              '2 LEYENDA    
            If dr.Read Then                     '3 contenido del campo
                For k = 0 To dr.FieldCount - 1  '4 TIPO NUMERICO O STRING
                    Try
                        '{BACKUPTXT("INVE_CLIB", dr.GetName(k).ToString & "," & dr.GetFieldType(k).ToString & "," & dr.GetDataTypeName(k).ToString & ",'" & dr.GetSchemaTable.Columns(k).MaxLength)
                        FIELD_NAME = dr.GetName(k).ToString
                        For j = 1 To FgL.Rows.Count - 1
                            If FgL(j, 1) = FIELD_NAME Then

                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper
                                Dim c As Column = FgL.Cols(3)
                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Then

                                    FgL(j, 3) = dr.ReadNullAsEmptyDecimal(FIELD_NAME)
                                    FgL(j, 4) = "N"
                                    c.DataType = GetType(Decimal)
                                Else
                                    FgL(j, 3) = dr.ReadNullAsEmptyString(FIELD_NAME)
                                    FgL(j, 4) = " "
                                    c.DataType = GetType(String)
                                End If

                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Else
                For k = 0 To dr.FieldCount - 1  '4 TIPO NUMERICO O STRING
                    Try
                        'BACKUPTXT("INVE_CLIB", dr.GetName(k).ToString & "," & dr.GetFieldType(k).ToString & "," & dr.GetDataTypeName(k).ToString & ",'" & dr.GetSchemaTable.Columns(k).MaxLength)
                        FIELD_NAME = dr.GetName(k).ToString
                        For j = 1 To FgL.Rows.Count - 1
                            If FgL(j, 1) = FIELD_NAME Then
                                TIPO_CAMPO = dr.GetDataTypeName(k).ToString.ToUpper
                                Dim c As Column = FgL.Cols(3)
                                If TIPO_CAMPO = "INT32" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or TIPO_CAMPO = "NUMERIC" Or
                                    TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Or TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "DECIMAL" Then

                                    FgL(j, 4) = "N"
                                    c.DataType = GetType(Decimal)
                                Else
                                    FgL(j, 4) = ""
                                    c.DataType = GetType(String)
                                End If
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            End If
            dr.Close()
            Me.Refresh()

            Fg.FinishEditing()

        Catch ex As Exception
            Bitacora("65. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("65. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub LIMPIAR()
        Try
            BtnKit.Visible = False
            TCVE_ART.Text = ""
            TDESCR.Text = ""
            TLIN_PROD.Text = ""
            ChNUM_SERIE.Checked = False
            TUNI_MED.Text = ""
            TUNI_EMP.Value = 1
            TCTRL_ALM.Text = ""
            TTIEM_SURT.Value = 0
            TSTOCK_MIN.Value = 0
            TSTOCK_MAX.Value = 0

            RadUEPS.Checked = False
            RadPEPS.Checked = False
            RadPROMEDIO.Checked = True
            RadESTANDAR.Checked = False
            RadIDENTIFICADO.Checked = False

            TCOMP_X_REC.Value = 0
            TPESO.Value = 0
            TVOLUMEN.Value = 0

            TNUM_MON.Value = 1
            F2.Value = Now
            F1.Value = Now
            TPEND_SURT.Value = 0
            TEXIST.Text = 0
            TCOSTO_PROM.Value = 0
            TULT_COSTO.Value = 0
            'tCVE_OBS.value = 0
            RadProducto.Checked = True
            TUNI_ALT.Text = ""
            TFAC_CONV.Value = 1
            TAPART.Value = 0
            ChCON_LOTE.Checked = False
            ChCON_PEDIMENTO.Checked = False
            TPEND_SURT.Value = 0

            TCVE_ESQIMPU.Text = 1
            LtEsquema.Text = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)

            TVTAS_ANL_C.Value = 0
            TVTAS_ANL_M.Value = 0
            TCOMP_ANL_C.Value = 0
            TCOMP_ANL_M.Value = 0
            TCUENT_CONT.Text = ""
            Pic.Image = PicFoto.Image
            Pic.Tag = ""
            FgA.Rows.Count = 1

            ChMAN_IEPS.Checked = False
            CboAPL_MAN_IMP.SelectedIndex = -1
            TCUOTA_IEPS.Value = 0
            RadUEPS2.Checked = True
            TCVE_PRODSERV.Text = ""
            TCVE_UNIDAD.Text = ""
            TCVE_ART.Select()

        Catch ex As Exception
            MsgBox("75. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("75. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmInvenAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                BarGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                BarSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub FrmInvenAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Dim TIP_COSTEO As String, CVE_OBS As Long, NUM_MON As Integer = 1, TIPO_ELE As String, CVE_IMAGEN As String, APL_MAN_IEPS As String
        Dim file_ext As String, file_name As String, file_name_sin_ext As String, FAC_CONV As Integer = 1, UNI_EMP As Single = 1

        Dim cmd As New SqlCommand With {.Connection = cnSAE}

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        Try
            Fg.FinishEditing()
            FgA.FinishEditing()
            FgL.FinishEditing()
            TCUENT_CONT.Focus()

        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If TCVE_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(TCVE_OBS.Tag) Then
                    CVE_OBS = TCVE_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO OINVE" & Empresa & " (CVE_OBS, STR_OBS) OUTPUT Inserted.CVE_OBS 
                        VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM OINVE" & Empresa & "),'" & RemoveCharacter(TCVE_OBS.Text) & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If Val(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE OINVE" & Empresa & " SET STR_OBS = '" & TCVE_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If

            TCVE_OBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("80. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("80. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        CVE_IMAGEN = ""
        If Pic.Tag.ToString.Trim.Length > 0 Then
            If IO.File.Exists(Pic.Tag) Then
                file_ext = IO.Path.GetExtension(Pic.Tag)
                file_name = IO.Path.GetFileName(Pic.Tag)
                file_name_sin_ext = IO.Path.GetFileNameWithoutExtension(Pic.Tag)

                If file_name_sin_ext.Trim.Length > 16 Then file_name_sin_ext = file_name_sin_ext.Substring(0, 16)

                CVE_IMAGEN = file_name_sin_ext & file_ext
                If Not IO.Directory.Exists(Application.StartupPath & "\IMAGENES") Then
                    IO.Directory.CreateDirectory(Application.StartupPath & "\IMAGENES")
                End If
                Try
                    FileCopy(Pic.Tag, Application.StartupPath & "\IMAGENES\" & CVE_IMAGEN)
                Catch ex As Exception
                End Try
            End If
        End If

        TIP_COSTEO = "P"
        If RadUEPS.Checked = True Then TIP_COSTEO = "U"
        If RadPEPS.Checked = True Then TIP_COSTEO = "E"
        If RadPROMEDIO.Checked = True Then TIP_COSTEO = "P"
        If RadESTANDAR.Checked = True Then TIP_COSTEO = "S"
        If RadIDENTIFICADO.Checked = True Then TIP_COSTEO = "I"
        TIPO_ELE = "P"
        If RadProducto.Checked Then TIPO_ELE = "P"
        If RadServicio.Checked Then TIPO_ELE = "S"
        If RadKit.Checked Then TIPO_ELE = "K"
        If RadGrupoProd.Checked Then TIPO_ELE = "G"
        Try
            NUM_MON = TNUM_MON.Text
            If NUM_MON = 0 Then NUM_MON = 1
            FAC_CONV = TFAC_CONV.Text
            If FAC_CONV = 0 Then FAC_CONV = 1
            UNI_EMP = TUNI_EMP.Text
            If UNI_EMP = 0 Then UNI_EMP = 1
        Catch ex As Exception
            Bitacora("68. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("68. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        APL_MAN_IEPS = "C"
        If RadUEPS2.Checked Then APL_MAN_IEPS = "C"
        RadPEPS2.Checked = True
        RadPromedio2.Checked = True

        SQL = "SET ansi_warnings OFF
            UPDATE INVE" & Empresa & " SET CVE_ART = @CVE_ART, DESCR = @DESCR, LIN_PROD = @LIN_PROD, CON_SERIE = @CON_SERIE, UNI_MED = @UNI_MED,
            UNI_EMP = @UNI_EMP, CTRL_ALM = @CTRL_ALM, TIEM_SURT = @TIEM_SURT, STOCK_MIN = @STOCK_MIN, STOCK_MAX = @STOCK_MAX,
            TIP_COSTEO = @TIP_COSTEO, NUM_MON = @NUM_MON, FCH_ULTCOM = @FCH_ULTCOM, FCH_ULTVTA = @FCH_ULTVTA, PEND_SURT = @PEND_SURT,
            COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO, CVE_OBS = @CVE_OBS, TIPO_ELE = @TIPO_ELE, UNI_ALT = @UNI_ALT, FAC_CONV = @FAC_CONV,
            APART = @APART, CON_LOTE = @CON_LOTE, CON_PEDIMENTO = @CON_PEDIMENTO, PESO = @PESO, VOLUMEN = @VOLUMEN, CVE_ESQIMPU = @CVE_ESQIMPU,
            VTAS_ANL_C = @VTAS_ANL_C, VTAS_ANL_M = @VTAS_ANL_M, COMP_ANL_C = @COMP_ANL_C, COMP_ANL_M = @COMP_ANL_M, CUENT_CONT = @CUENT_CONT,
            CVE_IMAGEN = @CVE_IMAGEN, MAN_IEPS = @MAN_IEPS, APL_MAN_IMP = @APL_MAN_IMP, CUOTA_IEPS = @CUOTA_IEPS, APL_MAN_IEPS = @APL_MAN_IEPS,
            CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD
            WHERE CVE_ART = @CVE_ART
            IF @@ROWCOUNT = 0
            INSERT INTO INVE" & Empresa & " (CVE_ART, STATUS, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, TIEM_SURT, STOCK_MIN, STOCK_MAX,
            TIP_COSTEO, NUM_MON, FCH_ULTCOM, FCH_ULTVTA, PEND_SURT, EXIST, COSTO_PROM, ULT_COSTO, CVE_OBS, TIPO_ELE, UNI_ALT, FAC_CONV, APART, CON_LOTE,
            CON_PEDIMENTO, PESO, VOLUMEN, CVE_ESQIMPU, VTAS_ANL_C, VTAS_ANL_M, COMP_ANL_C, COMP_ANL_M, CUENT_CONT, CVE_IMAGEN, MAN_IEPS, APL_MAN_IMP,
            CUOTA_IEPS, APL_MAN_IEPS, CVE_PRODSERV, CVE_UNIDAD, UUID) VALUES(@CVE_ART, 'A', @DESCR, @LIN_PROD, @CON_SERIE, @UNI_MED, @UNI_EMP, @CTRL_ALM,
            @TIEM_SURT, @STOCK_MIN, @STOCK_MAX, @TIP_COSTEO, @NUM_MON, @FCH_ULTCOM, @FCH_ULTVTA, @PEND_SURT, 0, @COSTO_PROM, @ULT_COSTO, @CVE_OBS,
            @TIPO_ELE, @UNI_ALT, @FAC_CONV, @APART, @CON_LOTE, @CON_PEDIMENTO, @PESO, @VOLUMEN, @CVE_ESQIMPU, @VTAS_ANL_C, @VTAS_ANL_M, @COMP_ANL_C,
            @COMP_ANL_M, @CUENT_CONT, @CVE_IMAGEN, @MAN_IEPS, @APL_MAN_IMP, @CUOTA_IEPS, @APL_MAN_IEPS, @CVE_PRODSERV, @CVE_UNIDAD, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(TCVE_ART.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = RemoveCharacter(TDESCR.Text)
            cmd.Parameters.Add("@LIN_PROD", SqlDbType.VarChar).Value = RemoveCharacter(TLIN_PROD.Text)
            cmd.Parameters.Add("@CON_SERIE", SqlDbType.VarChar).Value = IIf(ChNUM_SERIE.Checked, "S", "N")
            cmd.Parameters.Add("@UNI_MED", SqlDbType.VarChar).Value = TUNI_MED.Text
            cmd.Parameters.Add("@UNI_EMP", SqlDbType.Float).Value = UNI_EMP
            cmd.Parameters.Add("@CTRL_ALM", SqlDbType.VarChar).Value = TCTRL_ALM.Text
            cmd.Parameters.Add("@TIEM_SURT", SqlDbType.Int).Value = CONVERTIR_TO_INT(CDec(TTIEM_SURT.Text))
            cmd.Parameters.Add("@STOCK_MIN", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TSTOCK_MIN.Text))
            cmd.Parameters.Add("@STOCK_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TSTOCK_MAX.Text))
            cmd.Parameters.Add("@TIP_COSTEO", SqlDbType.VarChar).Value = TIP_COSTEO
            cmd.Parameters.Add("@NUM_MON", SqlDbType.Int).Value = NUM_MON
            cmd.Parameters.Add("@FCH_ULTCOM", SqlDbType.DateTime).Value = F2.Value
            cmd.Parameters.Add("@FCH_ULTVTA", SqlDbType.DateTime).Value = F1.Value
            cmd.Parameters.Add("@PEND_SURT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TPEND_SURT.Text))
            cmd.Parameters.Add("@COSTO_PROM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TCOSTO_PROM.Text))
            cmd.Parameters.Add("@ULT_COSTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TULT_COSTO.Text))
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@TIPO_ELE", SqlDbType.VarChar).Value = TIPO_ELE
            cmd.Parameters.Add("@UNI_ALT", SqlDbType.VarChar).Value = TUNI_ALT.Text
            cmd.Parameters.Add("@FAC_CONV", SqlDbType.Float).Value = FAC_CONV
            cmd.Parameters.Add("@APART", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TAPART.Text))
            cmd.Parameters.Add("@CON_LOTE", SqlDbType.VarChar).Value = IIf(ChCON_LOTE.Checked, "S", "N")
            cmd.Parameters.Add("@CON_PEDIMENTO", SqlDbType.VarChar).Value = IIf(ChCON_PEDIMENTO.Checked, "S", "S")
            cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TPESO.Text))
            cmd.Parameters.Add("@VOLUMEN", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TVOLUMEN.Text))
            cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_ESQIMPU.Text)
            cmd.Parameters.Add("@VTAS_ANL_C", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TVTAS_ANL_C.Text))
            cmd.Parameters.Add("@VTAS_ANL_M", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TVTAS_ANL_M.Text))
            cmd.Parameters.Add("@COMP_ANL_C", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TCOMP_ANL_C.Text))
            cmd.Parameters.Add("@COMP_ANL_M", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TCOMP_ANL_M.Text))
            cmd.Parameters.Add("@CUENT_CONT", SqlDbType.VarChar).Value = TCUENT_CONT.Text
            cmd.Parameters.Add("@CVE_IMAGEN", SqlDbType.VarChar).Value = CVE_IMAGEN
            cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = IIf(ChMAN_IEPS.Checked, "S", "N")
            cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = CboAPL_MAN_IMP.SelectedIndex
            cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(TCUOTA_IEPS.Text))
            cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = APL_MAN_IEPS
            cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = TCVE_PRODSERV.Text
            cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = TCVE_UNIDAD.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If

            GRABAR_ALTERNAS()
            GRABAR_PRECIOS()
            GRABAR_CAMPLIB()
            GRABAR_CARTA_PORTE()
            GRABAR_PROMOCIONES()

            If ART_NEW Then
                If MsgBox("¿Desea registrar el producto en multialmacén?", vbYesNo) = vbYes Then
                    Var25 = TCVE_ART.Text
                    frmAltaMultialmacen.ShowDialog()
                End If
            End If

            MsgBox("El Artículo se grabo satisfactoriamente")

            If ARTICULO = "Salir" Then
                Me.Close()
            End If

        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PROMOCIONES()

        SQL = "IF EXISTS (SELECT CVE_ART FROM GCPROMOCIONES WHERE CVE_ART = @CVE_ART)
                    UPDATE GCPROMOCIONES SET TIPO = @TIPO, RANGO11 = @RANGO11, RANGO12 = @RANGO12, RANGO21 = @RANGO21, RANGO22 = @RANGO22,      
                    RANGO31 = @RANGO31, RANGO32 = @RANGO32, RANGO41 = @RANGO41, RANGO42 = @RANGO42, RANGO51 = @RANGO51, RANGO52 = @RANGO52, 
                    PORC1 = @PORC1, PORC2 = @PORC2, PORC3 = @PORC3, PORC4 = @PORC4, PORC5 = @PORC5, LP1 = @LP1, LP2 = @LP2, LP3 = @LP3, 
                    LP4 = @LP4, LP5 = @LP5
                    WHERE CVE_ART = @CVE_ART      
                ELSE
                    INSERT INTO GCPROMOCIONES (TIPO, CVE_ART, RANGO11, RANGO12, RANGO21, RANGO22, RANGO31, RANGO32, RANGO41, RANGO42, RANGO51,
                    RANGO52, PORC1, PORC2, PORC3, PORC4, PORC5, LP1, LP2, LP3, LP4, LP5) VALUES(
                    @TIPO, @CVE_ART, @RANGO11, @RANGO12, @RANGO21, @RANGO22, @RANGO31, @RANGO32, @RANGO41, @RANGO42, @RANGO51, @RANGO52,
                    @PORC1, @PORC2, @PORC3, @PORC4, @PORC5, @LP1, @LP2, @LP3, @LP4, @LP5)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = IIf(RadPromoPrec.Checked, 1, 0)
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                cmd.Parameters.Add("@RANGO11", SqlDbType.SmallInt).Value = TCANT_PROMO1.Value
                cmd.Parameters.Add("@RANGO12", SqlDbType.SmallInt).Value = TPRECIO_PROMO1.Value
                cmd.Parameters.Add("@RANGO21", SqlDbType.SmallInt).Value = TCANT_PROMO2.Value
                cmd.Parameters.Add("@RANGO22", SqlDbType.SmallInt).Value = TPRECIO_PROMO2.Value
                cmd.Parameters.Add("@RANGO31", SqlDbType.SmallInt).Value = TCANT_PROMO3.Value
                cmd.Parameters.Add("@RANGO32", SqlDbType.SmallInt).Value = TPRECIO_PROMO3.Value
                cmd.Parameters.Add("@RANGO41", SqlDbType.SmallInt).Value = TCANT_PROMO4.Value
                cmd.Parameters.Add("@RANGO42", SqlDbType.SmallInt).Value = TPRECIO_PROMO4.Value
                cmd.Parameters.Add("@RANGO51", SqlDbType.SmallInt).Value = TCANT_PROMO5.Value
                cmd.Parameters.Add("@RANGO52", SqlDbType.SmallInt).Value = TPRECIO_PROMO5.Value
                cmd.Parameters.Add("@PORC1", SqlDbType.Float).Value = TPORC_PROMO1.Value
                cmd.Parameters.Add("@PORC2", SqlDbType.Float).Value = TPORC_PROMO2.Value
                cmd.Parameters.Add("@PORC3", SqlDbType.Float).Value = TPORC_PROMO3.Value
                cmd.Parameters.Add("@PORC4", SqlDbType.Float).Value = TPORC_PROMO4.Value
                cmd.Parameters.Add("@PORC5", SqlDbType.Float).Value = TPORC_PROMO5.Value
                cmd.Parameters.Add("@LP1", SqlDbType.SmallInt).Value = CBOPREC_PROMO1.SelectedIndex
                cmd.Parameters.Add("@LP2", SqlDbType.SmallInt).Value = CBOPREC_PROMO2.SelectedIndex
                cmd.Parameters.Add("@LP3", SqlDbType.SmallInt).Value = CBOPREC_PROMO3.SelectedIndex
                cmd.Parameters.Add("@LP4", SqlDbType.SmallInt).Value = CBOPREC_PROMO4.SelectedIndex
                cmd.Parameters.Add("@LP5", SqlDbType.SmallInt).Value = CBOPREC_PROMO5.SelectedIndex
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
        Catch ex As Exception
            'MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CARTA_PORTE()

        SQL = "UPDATE INVE_CP Set MAT_PELIGROSO = @MAT_PELIGROSO, CVE_MAT_PELIGROSO = @CVE_MAT_PELIGROSO, 
            EMBALAJE = @EMBALAJE, UNIDADPESO = @UNIDADPESO, BIENESTRANSP = @BIENESTRANSP
            WHERE CVE_ART = @CVE_ART
            IF @@ROWCOUNT = 0
            INSERT INTO INVE_CP (CVE_ART, MAT_PELIGROSO, CVE_MAT_PELIGROSO, EMBALAJE, UNIDADPESO, BIENESTRANSP)
            VALUES(@CVE_ART, @MAT_PELIGROSO, @CVE_MAT_PELIGROSO, @EMBALAJE, @UNIDADPESO, @BIENESTRANSP)"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text
                cmd.Parameters.Add("@MAT_PELIGROSO", SqlDbType.SmallInt).Value = CboMatPeligroso.SelectedIndex
                cmd.Parameters.Add("@CVE_MAT_PELIGROSO", SqlDbType.VarChar).Value = TCveMaterialPeligroso.Text
                cmd.Parameters.Add("@EMBALAJE", SqlDbType.VarChar).Value = TEmbalaje.Text
                cmd.Parameters.Add("@UNIDADPESO", SqlDbType.VarChar).Value = TUnidadPeso.Text
                cmd.Parameters.Add("@BIENESTRANSP", SqlDbType.VarChar).Value = TBienesTransp.Text
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("90. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("90. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_ALTERNAS()
        Try
            Dim cmd As New SqlCommand
            Dim CVE_ALTER As String
            Dim TIPO As String
            Dim CVE_CLPV As String

            cmd.Connection = cnSAE
            cmd.CommandText = "DELETE CVES_ALTER" & Empresa & "  WHERE CVE_ART = '" & TCVE_ART.Text & "'"
            cmd.ExecuteNonQuery()

            For k = 1 To FgA.Rows.Count - 1
                Try
                    If Not IsNothing(FgA(k, 1)) Then
                        CVE_ALTER = FgA(k, 1)
                        If CVE_ALTER.Trim.Length > 0 Then
                            TIPO = FgA(k, 2)
                            If TIPO = "" Then
                                TIPO = "N"
                                FgA(k, 2) = "N"
                            End If

                            If TIPO = "" Or TIPO = "N" Then
                                CVE_CLPV = ""
                            Else
                                CVE_CLPV = FgA(k, 3)
                            End If

                            SQL = "INSERT INTO CVES_ALTER" & Empresa & " (CVE_ART, CVE_ALTER, TIPO, CVE_CLPV) VALUES('" & TCVE_ART.Text & "','" &
                              CVE_ALTER & "','" & TIPO & "','" & CVE_CLPV & "')"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("150.1 " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PRECIOS()
        Try
            Dim cmd As New SqlCommand
            Dim CVE_PRECIO As Integer
            Dim PRECIO As Single

            cmd.Connection = cnSAE

            For K = 1 To Fg.Rows.Count - 1

                CVE_PRECIO = Fg(K, 1)
                PRECIO = Fg(K, 3)

                If PRECIO > 0 Then
                    SQL = "UPDATE PRECIO_X_PROD" & Empresa & " SET PRECIO = " & PRECIO & " WHERE CVE_ART = '" & TCVE_ART.Text & "' AND " &
                        "CVE_PRECIO = " & CVE_PRECIO & " IF @@ROWCOUNT = 0 " &
                        "INSERT INTO PRECIO_X_PROD" & Empresa & " (CVE_ART, CVE_PRECIO, PRECIO) VALUES('" & TCVE_ART.Text & "','" &
                        CVE_PRECIO & "','" & PRECIO & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CAMPLIB()
        Dim CAMPO As String, DESCR As String, TIPO As String, CAD As String, CONTINUA As Boolean
        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }
        Try
            For k = 1 To FgL.Rows.Count - 1
                CAMPO = FgL(k, 1)
                If Not IsNothing(FgL(k, 3)) Then
                    DESCR = FgL(k, 3)
                Else
                    DESCR = ""
                End If
                TIPO = FgL(k, 4)
                If TIPO = "N" Then
                    CAD = ""
                    If DESCR.Trim.Length > 0 Then
                        CONTINUA = True
                    Else
                        CONTINUA = False
                    End If
                Else
                    CAD = "'"
                    CONTINUA = True
                End If
                Try
                    If CONTINUA Then
                        SQL = "SET ansi_warnings OFF
                            UPDATE INVE_CLIB" & Empresa & " SET " & CAMPO & " = " & CAD & DESCR & CAD & " 
                            WHERE CVE_PROD = '" & TCVE_ART.Text & "' 
                            IF @@ROWCOUNT = 0
                            INSERT INTO INVE_CLIB" & Empresa & " (CVE_PROD, " & CAMPO & ") VALUES('" & TCVE_ART.Text & "','" & DESCR & "')"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_PROD.Text = Var4
                LtLinea.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TTIEM_SURT.Focus()
            End If

        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles BtnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESQIMPU.Text = Var4
                TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                LtEsquema.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                ChMAN_IEPS.Focus()
            End If
        Catch ex As Exception
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnMoneda_Click(sender As Object, e As EventArgs) Handles BtnMoneda.Click
        Try
            Var2 = "Moneda"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TNUM_MON.Text = Var4
                LtMoneda.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                TCVE_ESQIMPU.Focus()
            End If
        Catch ex As Exception
            MsgBox("210. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChMAN_IEPS_CheckedChanged(sender As Object, e As EventArgs) Handles ChMAN_IEPS.CheckedChanged
        Try
            If ChMAN_IEPS.Checked Then
                ChMAN_IEPS.Checked = True
                CboAPL_MAN_IMP.Enabled = True
                TCUOTA_IEPS.Enabled = True
            Else
                ChMAN_IEPS.Checked = False
                CboAPL_MAN_IMP.Enabled = False
                TCUOTA_IEPS.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgL_EnterCell(sender As Object, e As EventArgs) Handles FgL.EnterCell
        ENTRA = False
        Try
            If FgL.Row > 0 And ENTRA_FLEXI Then
                FgL.StartEditing()
            End If
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgL_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgL.ValidateEdit
        Try
            If e.Row > 0 And ENTRA_FLEXI Then
                If e.Col = 3 Then
                    If FgL(e.Row, 4) = "N" Then
                        If Not IsNumeric(FgL.Editor.Text()) Then
                            e.Cancel = True
                            FgL.Editor.Text = "0"
                            MsgBox("Solo valores numéricos")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgL_Leave(sender As Object, e As EventArgs) Handles FgL.Leave
        Try
            ENTRA = True
        Catch ex As Exception
            MsgBox("101. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("101. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCUENT_CONT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCUENT_CONT.KeyDown
        If e.KeyCode = Keys.Enter Then
            Gpo16.Select()
        End If
    End Sub

    Private Sub TNUM_MON_KeyDown(sender As Object, e As KeyEventArgs) Handles TNUM_MON.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
            If Not EXISTE_DATA("MONED", TNUM_MON.Text) Then
                MsgBox("Moneda inexistente")
            End If
            'Gpo4.Select()
        End If

        If e.KeyCode = Keys.F2 Then
            BtnMoneda_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub Pic_Click(sender As Object, e As EventArgs) Handles Pic.Click
        'ofd.InitialDirectory = "c:\"
        Dim ofd As New OpenFileDialog With {
            .DefaultExt = "jpg",
            .FileName = "",
            .Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp|PNG|*.png",
            .Title = "Select file"
        }
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            'MsgBox(ofd.FileName)
            PicFoto.Image = Image.FromFile(ofd.FileName)
            Pic.Tag = ofd.FileName
            Dim bmp As Bitmap
            bmp = New Bitmap(ofd.FileName)
            'Pic.SizeMode = PictureBoxSizeMode.AutoSize
            Pic.Image = bmp
        End If
    End Sub
    Private Sub TLIN_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_PROD.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLinea_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TLIN_PROD_Validating(sender As Object, e As CancelEventArgs) Handles TLIN_PROD.Validating
        Try
            If TLIN_PROD.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLIN_PROD.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLIN_PROD.Text = ""
                    TLIN_PROD.Select()
                Else
                    LtLinea.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TNUM_MON_Validating(sender As Object, e As CancelEventArgs) Handles TNUM_MON.Validating
        Try
            If TNUM_MON.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Moneda", TNUM_MON.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Moneda inexistente")
                    TNUM_MON.Value = 1
                    TNUM_MON.Select()
                Else
                    LtMoneda.Text = CADENA
                End If
            End If
        Catch ex As Exception
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnKit_Click(sender As Object, e As EventArgs) Handles BtnKit.Click
        Try
            Var10 = TCVE_ART.Text
            Var11 = "Inven"
            If Fg.Row > 0 Then
                If IsNumeric(Fg(Fg.Row, 3)) Then
                    Var12 = Fg(Fg.Row, 3)
                Else
                    Var12 = "0"
                End If
            End If

            frmKit.ShowDialog()
        Catch ex As Exception
            Bitacora("113. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub RadKit_CheckedChanged(sender As Object, e As EventArgs) Handles RadKit.CheckedChanged
        If RadKit.Checked Then
            BtnKit.Visible = True
        Else
            BtnKit.Visible = False
        End If
    End Sub
    Private Sub RadProducto_CheckedChanged(sender As Object, e As EventArgs) Handles RadProducto.CheckedChanged
        If RadProducto.Checked Then
            BtnKit.Visible = False
        End If
    End Sub
    Private Sub RadServicio_CheckedChanged(sender As Object, e As EventArgs) Handles RadServicio.CheckedChanged
        If RadServicio.Checked Then
            BtnKit.Visible = False
        End If
    End Sub
    Private Sub RadGrupoProd_CheckedChanged(sender As Object, e As EventArgs) Handles RadGrupoProd.CheckedChanged
        If RadGrupoProd.Checked Then
            BtnKit.Visible = False
        End If
    End Sub
    Private Sub BtnClaveSAT_Click(sender As Object, e As EventArgs) Handles BtnClaveSAT.Click
        Prosec = "CATINV"
        FrmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            TCVE_PRODSERV.Text = Var10
        End If
    End Sub
    Private Sub BtnUnidadSAT_Click(sender As Object, e As EventArgs) Handles BtnUnidadSAT.Click
        Try
            Prosec = "UNIMED"
            FrmNewXCategoria.ShowDialog()
            If Var10.Trim.Length > 0 Then
                TCVE_UNIDAD.Text = Var10
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmInvenAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            CloseTab("Inventario articulo")
            Me.Dispose()

            If FORM_IS_OPEN("frmInven") Then
                FrmInven.DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_ESQIMPU_Validated(sender As Object, e As EventArgs) Handles TCVE_ESQIMPU.Validated
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Esquema inexistente")
                    TCVE_ESQIMPU.Text = TCVE_ESQIMPU.Tag
                    TCVE_ESQIMPU.Select()
                Else
                    TCVE_ESQIMPU.Tag = TCVE_ESQIMPU.Text
                    LtEsquema.Text = CADENA
                End If
            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TUNI_EMP_Validating(sender As Object, e As CancelEventArgs) Handles TUNI_EMP.Validating
        Try
            If TUNI_EMP.Value = 0 Then
                TUNI_EMP.Value = 1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TFAC_CONV_Validating(sender As Object, e As CancelEventArgs) Handles TFAC_CONV.Validating
        Try
            If TFAC_CONV.Value = 0 Then
                TFAC_CONV.Value = 1
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnFotDocA_Click(sender As Object, e As EventArgs) Handles BtnFotDocA.Click
        Try
            FgA.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FgA_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgA.CellButtonClick
        Try
            If FgA.Row > 0 Then
                Select Case e.Col
                    Case 2 'tipo
                        If FgA(e.Row, 1).ToString.Length = 0 Then
                            MsgBox("2. por favor capture la clave alterna")
                            Return
                        End If

                    Case 3 'clienmte/prov
                        Try
                            If FgA(e.Row, 2) = "" Then
                                MsgBox("por favor seleccione el tipo de clave alterna")
                                Return
                            End If
                            If FgA(e.Row, 2) = "N" Then
                                e.Cancel = True
                                Return
                            End If
                            If FgA(e.Row, 2) = "C" Then
                                Var2 = "Clientes"
                            Else
                                Var2 = "Prov"
                            End If

                            Var4 = ""
                            Var5 = ""
                            frmSelItem.ShowDialog()
                            If Var4.Trim.Length > 0 Then
                                FgA(e.Row, 3) = Var4
                                FgA(e.Row, 4) = Var5
                                Var2 = ""
                                Var4 = ""
                                Var5 = ""
                            End If

                        Catch ex As Exception
                            MsgBox("103. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("103 " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                End Select
            End If
        Catch ex As Exception
            Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgA.ValidateEdit
        Try
            If e.Row > 0 And ENTRA_A Then
                ENTRA_A = False
                Select Case e.Col
                    Case 1
                        If FgA.Editor.Text.ToUpper = TCVE_ART.Text.ToUpper Then
                            MsgBox("La clave alterna no puede ser igual a la clave principal")
                            e.Cancel = True
                            FgA.Editor.Text = ""
                            ENTRA_A = True
                            Return
                        End If
                        For k = 1 To FgA.Rows.Count - 1
                            Try
                                If e.Row <> k Then
                                    If FgA(k, 1) = FgA.Editor.Text Then
                                        MsgBox("La clave alterna existe verifique por favor")
                                        e.Cancel = True
                                        FgA.Editor.Text = ""
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Next
                    Case 2 'TIPO
                    Case 3 'CLIENTE/PROV
                        Dim CLAVE As String
                        If FgA(e.Row, 2) = "N" Then
                            e.Cancel = True
                        Else
                            If FgA.Editor.Text.Length > 0 Then
                                CLAVE = FgA.Editor.Text
                                If IsNumeric(CLAVE.Trim) Then
                                    CLAVE = Space(10 - CLAVE.Trim.Length) & CLAVE.Trim
                                End If
                                CLAVE = BUSCA_CAT("Cliente", CLAVE)
                                If CLAVE <> "N" And CLAVE <> "" Then
                                    FgA(e.Row, 4) = CLAVE
                                Else
                                    If FgA(e.Row, 2) = "C" Then
                                        MsgBox("Cliente inexistente")
                                    Else
                                        MsgBox("Proveedor inexistente")
                                    End If
                                    FgA.Editor.Text = ""
                                End If
                            Else
                                FgA(e.Row, 4) = ""
                            End If
                        End If
                End Select
                ENTRA_A = True
            End If
        Catch ex As Exception
            ENTRA_A = True
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_ComboDropDown(sender As Object, e As RowColEventArgs) Handles FgA.ComboDropDown
        Try
            If FgA(e.Row, 1).ToString.Length = 0 Then
                MsgBox("por favor capture la clave alterna")
                e.Cancel = True
                FgA.FinishEditing()
                FgA.Col = 1
                Return
            End If
        Catch ex As Exception
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles FgA.ComboCloseUp
        Try
            If e.Row > 0 And ENTRA_A Then
                ENTRA_A = False
                If e.Col = 2 Then
                    If FgA.Editor.Text = "N" Then
                        FgA(e.Row, 3) = ""
                        FgA(e.Row, 4) = ""
                    End If
                End If
                ENTRA_A = True
            End If
        Catch ex As Exception
            ENTRA_A = True
            'MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgA.BeforeEdit
        Try
            If e.Row > 0 And ENTRA_A Then
                ENTRA_A = False

                If e.Col = 3 Then
                    If FgA(FgA.Row, 2) = "N" Then
                        e.Cancel = True
                    End If
                End If
                ENTRA_A = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TTIEM_SURT_TextChanged(sender As Object, e As EventArgs) Handles TTIEM_SURT.TextChanged
        Try
            If Not IsNothing(TTIEM_SURT.Value) Then
                TTIEM_SURT.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TFAC_CONV_TextChanged(sender As Object, e As EventArgs) Handles TFAC_CONV.TextChanged
        Try
            If Not IsNothing(TFAC_CONV.Value) Then
                TFAC_CONV.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TUNI_EMP_TextChanged(sender As Object, e As EventArgs) Handles TUNI_EMP.TextChanged
        Try
            If Not IsNothing(TUNI_EMP.Value) Then
                TUNI_EMP.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TSTOCK_MAX_TextChanged(sender As Object, e As EventArgs) Handles TSTOCK_MAX.TextChanged
        Try
            If Not IsNothing(TSTOCK_MAX.Value) Then
                TSTOCK_MAX.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TSTOCK_MIN_TextChanged(sender As Object, e As EventArgs) Handles TSTOCK_MIN.TextChanged
        Try
            If Not IsNothing(TSTOCK_MIN.Value) Then
                TSTOCK_MIN.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TAPART_TextChanged(sender As Object, e As EventArgs) Handles TAPART.TextChanged
        Try
            If Not IsNothing(TAPART.Value) Then
                TAPART.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TVOLUMEN_TextChanged(sender As Object, e As EventArgs) Handles TVOLUMEN.TextChanged
        Try
            If Not IsNothing(TVOLUMEN.Value) Then
                TVOLUMEN.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPESO_TextChanged(sender As Object, e As EventArgs) Handles TPESO.TextChanged
        Try
            If Not IsNothing(TPESO.Value) Then
                TPESO.UpdateValueWithCurrentText()
            End If
        Catch ex As Exception
            Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnInicial_Click(sender As Object, e As EventArgs) Handles BtnInicial.Click
        Try
            If FrmInven.Fg.Row > 0 Then
                ARTICULO = FrmInven.Fg(FrmInven.Fg.Row + 1, 1)
                FrmInven.Fg.Row = 1
                DESPLEGAR()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnAnterior_Click(sender As Object, e As EventArgs) Handles BtnAnterior.Click
        Try
            If FrmInven.Fg.Row > 1 Then
                ARTICULO = FrmInven.Fg(FrmInven.Fg.Row + 1, 1)
                FrmInven.Fg.Row = FrmInven.Fg.Row - 1
                DESPLEGAR()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As EventArgs) Handles BtnSiguiente.Click
        Try
            If FrmInven.Fg.Row > 0 Then
                If FrmInven.Fg.Row < FrmInven.Fg.Rows.Count - 1 Then
                    ARTICULO = FrmInven.Fg(FrmInven.Fg.Row + 1, 1)
                    FrmInven.Fg.Row = FrmInven.Fg.Row + 1
                    DESPLEGAR()
                End If
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles BtnFinal.Click
        Try
            If FrmInven.Fg.Row > 0 Then
                ARTICULO = FrmInven.Fg(FrmInven.Fg.Row + 1, 1)
                FrmInven.Fg.Row = FrmInven.Fg.Rows.Count - 1
                DESPLEGAR()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarGrabarSalir_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles BarGrabarSalir.Click
        Try
            ARTICULO = "Salir"
            BarGrabar_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If ART_NEW Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_ART FROM INVE" & Empresa & " WHERE CVE_ART = '" & TCVE_ART.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            MsgBox("La clave del artículo ya existe")
                            TCVE_ART.Text = ""
                            TCVE_ART.Select()
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgA_SetupEditor(sender As Object, e As RowColEventArgs) Handles FgA.SetupEditor
        Try
            If TypeOf FgA.Editor Is TextBox Then
                Dim ctl As TextBox = FgA.Editor
                If (e.Col = 1) Then
                    ctl.MaxLength = 16
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ESQIMPU.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEsquema_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_ART_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCVE_ART.KeyPress
        Select Case e.KeyChar

            Case Convert.ToChar(Keys.Enter) ' Enter is pressed
            ' Call method here...

            Case Convert.ToChar(Keys.Back) ' Backspace is pressed
                e.Handled = False ' Delete the character

            Case Convert.ToChar(Keys.Capital Or Keys.RButton) ' CTRL+V is pressed
                ' Paste clipboard content only if contains allowed keys
                'aqui bobo
                e.Handled = Not Clipboard.GetText().All(Function(c) AllowedKeys.Contains(c))

            Case Else ' Other key is pressed
                'aqui bobo
                e.Handled = Not AllowedKeys.Contains(e.KeyChar)

        End Select
    End Sub

    Private Sub BtnUnidadPeso_Click(sender As Object, e As EventArgs) Handles BtnUnidadPeso.Click
        Try
            Var2 = "tblcclaveunidadpeso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TUnidadPeso.Text = Var4
                LTUnidadPeso.Text = Var5
                TBienesTransp.Focus()
            End If
        Catch ex As Exception
            Bitacora("1280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TUnidadPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles TUnidadPeso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnUnidadPeso_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TUnidadPeso_Validated(sender As Object, e As EventArgs) Handles TUnidadPeso.Validated
        Try
            If TUnidadPeso.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcclaveunidadpeso WHERE clave = '" & TUnidadPeso.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTUnidadPeso.Text = dr("nombre")
                            TBienesTransp.Focus()
                        Else
                            MsgBox("Unidad de peso inexistente")
                            LTUnidadPeso.Text = ""
                        End If
                    End Using
                End Using
            Else
                LTUnidadPeso.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnBienesTransp_Click(sender As Object, e As EventArgs) Handles BtnBienesTransp.Click
        Try
            Var2 = "SAT_CLAVEPROD_SERVCP"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TBienesTransp.Text = Var4
                LTBienesTransp.Text = Var5
                CboMatPeligroso.Focus()
            End If
        Catch ex As Exception
            Bitacora("1320. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1320. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TBienesTransp_KeyDown(sender As Object, e As KeyEventArgs) Handles TBienesTransp.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBienesTransp_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TBienesTransp_Validated(sender As Object, e As EventArgs) Handles TBienesTransp.Validated
        Try
            If TBienesTransp.Text.Trim.Length > 0 Then
                COLOCA_BIENES_TRANSP()
            Else
                LTBienesTransp.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub COLOCA_BIENES_TRANSP()
        Try
            If TBienesTransp.Text.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT * FROM tblcclaveprodserv WHERE claveProdServ = '" & TBienesTransp.Text & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            LTBienesTransp.Text = dr("descripcion")
                            CboMatPeligroso.Focus()
                        Else
                            MsgBox("Bienes transporte inexistente")
                            LTBienesTransp.Text = ""
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Bitacora("1380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnCveMaterialPeligroso_Click(sender As Object, e As EventArgs) Handles BtnCveMaterialPeligroso.Click
        Try
            Var2 = "tblcmaterialpeligroso"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCveMaterialPeligroso.Text = Var4
                LTCveMaterialPeligroso.Text = Var5
                TEmbalaje.Focus()
            End If
        Catch ex As Exception
            Bitacora("1300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCveMaterialPeligroso_KeyDown(sender As Object, e As KeyEventArgs) Handles TCveMaterialPeligroso.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCveMaterialPeligroso_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCveMaterialPeligroso_Validated(sender As Object, e As EventArgs) Handles TCveMaterialPeligroso.Validated
        Try
            If TCveMaterialPeligroso.Text.Trim.Length > 0 Then
                LTCveMaterialPeligroso.Text = GET_MAT_PELIGROSO(TCveMaterialPeligroso.Text, "S")
            Else
                LTCveMaterialPeligroso.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnEmbalaje_Click(sender As Object, e As EventArgs) Handles BtnEmbalaje.Click
        Try
            Var2 = "tblctipoembalaje"
            Var4 = ""
            Var5 = ""
            FrmSelItemCFDI.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TEmbalaje.Text = Var4
                LTEmbalaje.Text = Var5
            End If
        Catch ex As Exception
            Bitacora("1290. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1290. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TEmbalaje_KeyDown(sender As Object, e As KeyEventArgs) Handles TEmbalaje.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnEmbalaje_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            TUnidadPeso.Focus()
        End If
    End Sub

    Private Sub TEmbalaje_Validated(sender As Object, e As EventArgs) Handles TEmbalaje.Validated
        Try
            If TEmbalaje.Text.Trim.Length > 0 Then
                LTEmbalaje.Text = GET_MAT_EMBALAJE(TEmbalaje.Text)
            Else
                LTEmbalaje.Text = ""
            End If
        Catch ex As Exception
            Bitacora("1400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub CboMatPeligroso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMatPeligroso.SelectedIndexChanged
        Try
            If CboMatPeligroso.SelectedIndex = 0 Then
                PanelMatPeligro.Visible = True
            Else
                PanelMatPeligro.Visible = False
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TEmbalaje_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TEmbalaje.PreviewKeyDown
        If e.KeyCode = 9 Then
            TUnidadPeso.Focus()
        End If
    End Sub
    Private Sub CboMatPeligroso_GotFocus(sender As Object, e As EventArgs) Handles CboMatPeligroso.GotFocus
        CboMatPeligroso.BackColor = Color.Yellow
    End Sub

    Private Sub CboMatPeligroso_LostFocus(sender As Object, e As EventArgs) Handles CboMatPeligroso.LostFocus
        '183, 183, 183
        CboMatPeligroso.BackColor = Color.FromArgb(183, 183, 183)
    End Sub

    Private Sub CboMatPeligroso_KeyDown(sender As Object, e As KeyEventArgs) Handles CboMatPeligroso.KeyDown
        If e.KeyCode = 13 Then
            TCveMaterialPeligroso.Focus()
        End If
    End Sub

    Private Sub CboMatPeligroso_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboMatPeligroso.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCveMaterialPeligroso.Focus()
        End If
    End Sub

    Private Sub CboMatPeligroso_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboMatPeligroso.DropDownClosed
        TCveMaterialPeligroso.Focus()
    End Sub

    Private Sub BtnExistXAlm_Click(sender As Object, e As EventArgs) Handles BtnExistXAlm.Click

        Var46 = TCVE_ART.Text
        Var47 = TDESCR.Text

        FrmExistXAlmacen.ShowDialog()

    End Sub

    Private Sub RadPromoPrec_CheckedChanged(sender As Object, e As EventArgs) Handles RadPromoPrec.CheckedChanged
        Try
            If RadPromoPrec.Checked Then
                TPORC_PROMO1.Visible = False
                TPORC_PROMO2.Visible = False
                TPORC_PROMO3.Visible = False
                TPORC_PROMO4.Visible = False
                TPORC_PROMO5.Visible = False
                TPRECIO_PROMO1.Visible = False
                TPRECIO_PROMO2.Visible = False
                TPRECIO_PROMO3.Visible = False
                TPRECIO_PROMO4.Visible = False
                TPRECIO_PROMO5.Visible = False
                CBOPREC_PROMO1.Visible = True
                CBOPREC_PROMO2.Visible = True
                CBOPREC_PROMO3.Visible = True
                CBOPREC_PROMO4.Visible = True
                CBOPREC_PROMO5.Visible = True

                CBOPREC_PROMO1.Left = TPORC_PROMO1.Left
                CBOPREC_PROMO2.Left = TPORC_PROMO2.Left
                CBOPREC_PROMO3.Left = TPORC_PROMO3.Left
                CBOPREC_PROMO4.Left = TPORC_PROMO4.Left
                CBOPREC_PROMO5.Left = TPORC_PROMO5.Left

                Label46.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadPromoPorc_CheckedChanged(sender As Object, e As EventArgs) Handles RadPromoPorc.CheckedChanged
        Try
            If RadPromoPorc.Checked Then
                TPORC_PROMO1.Visible = True
                TPORC_PROMO2.Visible = True
                TPORC_PROMO3.Visible = True
                TPORC_PROMO4.Visible = True
                TPORC_PROMO5.Visible = True
                TPRECIO_PROMO1.Visible = True
                TPRECIO_PROMO2.Visible = True
                TPRECIO_PROMO3.Visible = True
                TPRECIO_PROMO4.Visible = True
                TPRECIO_PROMO5.Visible = True
                CBOPREC_PROMO1.Visible = False
                CBOPREC_PROMO2.Visible = False
                CBOPREC_PROMO3.Visible = False
                CBOPREC_PROMO4.Visible = False
                CBOPREC_PROMO5.Visible = False
                Label46.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCANT_PROMO1_KeyDown(sender As Object, e As KeyEventArgs) Handles TCANT_PROMO1.KeyDown
        If e.KeyCode = 13 Then
            If TPORC_PROMO1.Visible Then
                'TPORC_PROMO1.Focus()
            Else
                'TCANT_PROMO2.Focus()
                CBOPREC_PROMO1.Focus()
            End If
        End If
    End Sub
    Private Sub TCANT_PROMO2_KeyDown(sender As Object, e As KeyEventArgs) Handles TCANT_PROMO2.KeyDown
        If e.KeyCode = 13 Then
            If TPORC_PROMO2.Visible Then
                'TPORC_PROMO2.Focus()
            Else
                CBOPREC_PROMO2.Focus()
            End If
        End If
    End Sub
    Private Sub TCANT_PROMO3_KeyDown(sender As Object, e As KeyEventArgs) Handles TCANT_PROMO3.KeyDown
        If e.KeyCode = 13 Then
            If TPORC_PROMO3.Visible Then
                'TPORC_PROMO3.Focus()
            Else
                CBOPREC_PROMO3.Focus()
            End If
        End If
    End Sub
    Private Sub TCANT_PROMO4_KeyDown(sender As Object, e As KeyEventArgs) Handles TCANT_PROMO4.KeyDown
        If e.KeyCode = 13 Then
            If TPORC_PROMO4.Visible Then
                'TPORC_PROMO4.Focus()
            Else
                CBOPREC_PROMO4.Focus()
            End If
        End If
    End Sub
    Private Sub TCANT_PROMO5_KeyDown(sender As Object, e As KeyEventArgs) Handles TCANT_PROMO5.KeyDown
        If e.KeyCode = 13 Then
            If TPORC_PROMO5.Visible Then
                'TPORC_PROMO5.Focus()
            Else
                CBOPREC_PROMO5.Focus()
            End If
        End If
    End Sub
    Private Sub TPORC_PROMO1_TextChanged(sender As Object, e As EventArgs) Handles TPORC_PROMO1.TextChanged
        Try
            If TPORC_PROMO1.Text > 0 And PASA Then
                TPRECIO_PROMO1.Value = Fg(1, 3) - (Fg(1, 3) * TPORC_PROMO1.Text / 100)
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_PROMO2_TextChanged(sender As Object, e As EventArgs) Handles TPORC_PROMO2.TextChanged
        Try
            If TPORC_PROMO2.Text > 0 Then
                TPRECIO_PROMO2.Value = Fg(1, 3) - (Fg(1, 3) * TPORC_PROMO2.Text / 100)
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_PROMO3_TextChanged(sender As Object, e As EventArgs) Handles TPORC_PROMO3.TextChanged
        Try
            If TPORC_PROMO3.Text > 0 Then
                TPRECIO_PROMO3.Value = Fg(1, 3) - (Fg(1, 3) * TPORC_PROMO3.Text / 100)
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_PROMO4_TextChanged(sender As Object, e As EventArgs) Handles TPORC_PROMO4.TextChanged
        Try
            If TPORC_PROMO4.Text > 0 Then
                TPRECIO_PROMO4.Value = Fg(1, 3) - (Fg(1, 3) * TPORC_PROMO4.Text / 100)
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPORC_PROMO5_TextChanged(sender As Object, e As EventArgs) Handles TPORC_PROMO5.TextChanged
        Try
            If TPORC_PROMO5.Text > 0 Then
                TPRECIO_PROMO5.Value = Fg(1, 3) - (Fg(1, 3) * TPORC_PROMO5.Text / 100)
            End If
        Catch ex As Exception
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPRECIO_PROMO1_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_PROMO1.TextChanged
        Try
            If TPRECIO_PROMO1.Text > 0 And PASA Then
                PASA = False
                TPORC_PROMO1.Value = Math.Round((1 - (TPRECIO_PROMO1.Text / Fg(1, 3))) * 100, 2)
                PASA = True
            End If
        Catch ex As Exception
            PASA = True
            Bitacora("1420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPRECIO_PROMO2_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_PROMO2.TextChanged

    End Sub
    Private Sub TPRECIO_PROMO3_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_PROMO3.TextChanged

    End Sub
    Private Sub TPRECIO_PROMO4_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_PROMO4.TextChanged

    End Sub
    Private Sub TPRECIO_PROMO5_TextChanged(sender As Object, e As EventArgs) Handles TPRECIO_PROMO5.TextChanged

    End Sub

    Private Sub TAPART_KeyDown(sender As Object, e As KeyEventArgs) Handles TAPART.KeyDown
        ENTRA = False
        If e.KeyCode = 13 Then
            e.Handled = True
            GpoFgA.Focus()
        End If
        ENTRA = True
    End Sub
    Private Sub TAPART_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TAPART.PreviewKeyDown
        ENTRA = False
        If e.KeyCode = 9 Then

            GpoFgA.Focus()
            e.IsInputKey = True
        End If
        ENTRA = True
    End Sub
    Private Sub FgA_GotFocus(sender As Object, e As EventArgs) Handles FgA.GotFocus
        FgA.BorderStyle = Util.BaseControls.BorderStyleEnum.Fixed3D
    End Sub
    Private Sub FgA_LostFocus(sender As Object, e As EventArgs) Handles FgA.LostFocus
        FgA.BorderStyle = Util.BaseControls.BorderStyleEnum.FixedSingle
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.Fixed3D
        ENTRA = False
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        Fg.BorderStyle = Util.BaseControls.BorderStyleEnum.FixedSingle
        ENTRA = True
    End Sub
    Private Sub BtnProv_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnProv.KeyDown
        If e.KeyCode = 13 Then
            TCUENT_CONT.Focus()
        End If
    End Sub
    Private Sub BtnProv_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles BtnProv.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCUENT_CONT.Focus()
        End If
    End Sub
    Private Sub F2_KeyDown(sender As Object, e As KeyEventArgs) Handles F2.KeyDown
        If e.KeyCode = 13 Then
            TDESCR.Focus()
        End If
    End Sub
    Private Sub F2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles F2.PreviewKeyDown
        If e.KeyCode = 9 Then
            TDESCR.Focus()
        End If
    End Sub
    Private Sub BtnExistXAlm_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnExistXAlm.KeyDown
        If e.KeyCode = 13 Then
            TSTOCK_MIN.Focus()
        End If
    End Sub
    Private Sub BtnExistXAlm_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles BtnExistXAlm.PreviewKeyDown
        If e.KeyCode = 9 Then
            TSTOCK_MIN.Focus()
        End If
    End Sub
    Private Sub FgA_KeyDown(sender As Object, e As KeyEventArgs) Handles FgA.KeyDown
        If e.KeyCode = 13 Then
            Fg.Focus()
        End If
    End Sub
    Private Sub FgA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles FgA.PreviewKeyDown
        If e.KeyCode = 9 Then
            Fg.Focus()
            Fg.Select()
        End If
    End Sub
    Private Sub RadUEPS2_KeyDown(sender As Object, e As KeyEventArgs) Handles RadUEPS2.KeyDown
        If e.KeyCode = 13 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub RadUEPS2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RadUEPS2.PreviewKeyDown
        If e.KeyCode = 9 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub RadPEPS2_KeyDown(sender As Object, e As KeyEventArgs) Handles RadPEPS2.KeyDown
        If e.KeyCode = 13 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub RadPEPS2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RadPEPS2.PreviewKeyDown
        If e.KeyCode = 9 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub RadPromedio2_KeyDown(sender As Object, e As KeyEventArgs) Handles RadPromedio2.KeyDown
        If e.KeyCode = 13 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub RadPromedio2_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles RadPromedio2.PreviewKeyDown
        If e.KeyCode = 9 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub TCUOTA_IEPS_KeyDown(sender As Object, e As KeyEventArgs) Handles TCUOTA_IEPS.KeyDown
        If e.KeyCode = 13 Then
            Gpo8.Focus()
        End If
    End Sub
    Private Sub TCUOTA_IEPS_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCUOTA_IEPS.PreviewKeyDown
        If e.KeyCode = 9 Then
            Gpo8.Focus()
        End If
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 Then
                If e.Col <> 3 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TCVE_PRODSERV_Click(sender As Object, e As EventArgs) Handles TCVE_PRODSERV.Click

    End Sub
End Class
