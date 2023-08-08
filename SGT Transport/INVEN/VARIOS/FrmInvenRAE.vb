Imports C1.Win.C1Themes
Imports C1.Win.C1FlexGrid
Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FrmInvenRAE
    Private ART_NEW As Boolean = False
    Private ENTRA As Boolean
    Private ENTRA_FLEXI As Boolean


    Private Sub frmInvenRAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim COSTO As Single
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try


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

        FgL.Rows.Count = 1
        FgL.Cols.Fixed = 3

        FgA.Cols(2).ComboList = "N|C|P"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        MAX_LENGHT()

        Try
            cboAPL_MAN_IMP.Items.Clear()
            cboAPL_MAN_IMP.Items.Add("I.E.P.S.")
            cboAPL_MAN_IMP.Items.Add("Impuesto2")
            cboAPL_MAN_IMP.Items.Add("Impuesto3")
            cboAPL_MAN_IMP.Items.Add("I.V.A.")
        Catch ex As Exception
        End Try

        LIMPIAR()

        TAB1.SelectedIndex = 0
        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            ART_NEW = True
            Try
                tCVE_ART.Enabled = True
                CARGAR_PRECIOS2()
                CARGAR_CAMPLIB2()
                tCVE_ART.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT I.CVE_ART, I.DESCR, I.LIN_PROD, I.CON_SERIE, I.UNI_MED, I.UNI_EMP, I.CTRL_ALM, I.TIEM_SURT, I.STOCK_MIN, I.STOCK_MAX, " &
                    "I.TIP_COSTEO, I.NUM_MON, I.FCH_ULTCOM, I.FCH_ULTVTA, I.PEND_SURT, COMP_X_REC, I.EXIST, I.COSTO_PROM, I.ULT_COSTO, I.CVE_OBS, " &
                    "I.TIPO_ELE, I.UNI_ALT, I.FAC_CONV, I.APART, I.CON_LOTE, I.CON_PEDIMENTO, I.PESO, I.VOLUMEN, I.CVE_ESQIMPU, I.VTAS_ANL_C, " &
                    "I.VTAS_ANL_M, I.COMP_ANL_C, I.COMP_ANL_M, I.CUENT_CONT, I.CVE_IMAGEN, I.STATUS, I.MAN_IEPS, I.APL_MAN_IMP, " &
                    "I.CUOTA_IEPS, I.APL_MAN_IEPS, I.CVE_PRODSERV, I.CVE_UNIDAD, ISNULL(OB.DESCR,'') AS OBS_STR  " &
                    "FROM GCINVER I " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = I.CVE_OBS " &
                    "WHERE CVE_ART = '" & Var2 & "'"

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_ART.Text = dr("CVE_ART").ToString
                    tDESCR.Text = dr("DESCR").ToString
                    tDESCR.Tag = dr("STATUS").ToString
                    If tDESCR.Tag <> "A" And tDESCR.Tag <> "N" Then tDESCR.Tag = "A"

                    tLIN_PROD.Text = dr("LIN_PROD").ToString
                    LtLinea.Text = BUSCA_CAT("Linea", tLIN_PROD.Text)

                    chNUM_SERIE.Checked = IIf(dr("CON_SERIE").ToString = "S", True, False)
                    tUNI_MED.Text = dr("UNI_MED").ToString
                    tUNI_EMP.Value = dr("UNI_EMP").ToString
                    tCTRL_ALM.Text = dr("CTRL_ALM").ToString
                    tTIEM_SURT.Value = dr("TIEM_SURT").ToString
                    tSTOCK_MIN.Value = dr("STOCK_MIN").ToString
                    tSTOCK_MAX.Value = dr("STOCK_MAX").ToString
                    Select Case dr("TIP_COSTEO").ToString
                        Case "U"
                            radUEPS.Checked = True
                        Case "E"
                            radPEPS.Checked = True
                        Case "P"
                            radPROMEDIO.Checked = True
                        Case "S"
                            radESTANDAR.Checked = True
                        Case "I"
                            radIDENTIFICADO.Checked = True
                    End Select
                    tNUM_MON.Value = dr("NUM_MON").ToString
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
                    tPEND_SURT.Value = dr("PEND_SURT").ToString
                    tCOMP_X_REC.Value = dr("COMP_X_REC").ToString
                    tEXIST.Value = dr("EXIST").ToString

                    COSTO = dr("COSTO_PROM").ToString
                    COSTO = Math.Round(COSTO, 2)
                    tCOSTO_PROM.Value = COSTO

                    COSTO = dr("ULT_COSTO").ToString
                    COSTO = Math.Round(COSTO, 2)
                    tULT_COSTO.Value = COSTO


                    tCVE_OBS.Text = dr("OBS_STR")
                    tCVE_OBS.Tag = dr("CVE_OBS")

                    Select Case dr("TIPO_ELE").ToString
                        Case "P"
                            radProducto.Checked = True
                        Case "S"
                            radServicio.Checked = True
                        Case "K"
                            radKit.Checked = True
                        Case "G"
                            radGrupoProd.Checked = True
                    End Select
                    tUNI_ALT.Text = dr("UNI_ALT").ToString
                    tFAC_CONV.Value = dr("FAC_CONV").ToString
                    tAPART.Value = dr("APART").ToString
                    If dr("CON_LOTE").ToString = "SByte" Then
                        chCON_LOTE.Checked = True
                    Else
                        chCON_LOTE.Checked = False
                    End If
                    If dr("CON_PEDIMENTO").ToString = "SByte" Then
                        chCON_PEDIMENTO.Checked = True
                    Else
                        chCON_PEDIMENTO.Checked = False
                    End If
                    tPESO.Value = dr("PESO").ToString
                    tVOLUMEN.Value = dr("VOLUMEN").ToString
                    tCVE_ESQIMPU.Value = dr("CVE_ESQIMPU").ToString
                    LtEsquema.Text = BUSCA_CAT("Esquema", tCVE_ESQIMPU.Value)

                    tVTAS_ANL_C.Value = dr("VTAS_ANL_C").ToString
                    tVTAS_ANL_M.Value = dr("VTAS_ANL_M").ToString
                    tCOMP_ANL_C.Value = dr("COMP_ANL_C").ToString
                    tCOMP_ANL_M.Value = dr("COMP_ANL_M").ToString
                    tCUENT_CONT.Text = dr("CUENT_CONT").ToString
                    Pic.Tag = dr("CVE_IMAGEN").ToString

                    If Pic.Tag.ToString.Trim.Length > 0 Then
                        If IO.File.Exists(Application.StartupPath & "\IMAGENES\" & Pic.Tag) Then
                            Pic.Image = Image.FromFile(Application.StartupPath & "\IMAGENES\" & Pic.Tag)
                        Else
                            Pic.Image = PicFoto.Image
                        End If
                    Else
                        Pic.Image = PicFoto.Image
                    End If

                    If dr("MAN_IEPS").ToString = "S" Then
                        chMAN_IEPS.Checked = True
                        cboAPL_MAN_IMP.Enabled = True
                        tCUOTA_IEPS.Enabled = True
                        grpIEPS.Enabled = True
                        chMAN_IEPS.Checked = True
                        Select Case dr("APL_MAN_IMP").ToString
                            Case 1
                                cboAPL_MAN_IMP.SelectedIndex = 0
                            Case 2
                                cboAPL_MAN_IMP.SelectedIndex = 1
                            Case 3
                                cboAPL_MAN_IMP.SelectedIndex = 2
                            Case 4
                                cboAPL_MAN_IMP.SelectedIndex = 3
                        End Select
                        tCUOTA_IEPS.Value = dr("CUOTA_IEPS").ToString
                        Select Case dr("APL_MAN_IEPS").ToString
                            Case "C"
                                radUEPS2.Checked = True
                            Case "M"
                                radPEPS2.Checked = True
                            Case "A"
                                radPromedio2.Checked = True
                        End Select
                    Else
                        chMAN_IEPS.Checked = False
                        cboAPL_MAN_IMP.Enabled = False
                        tCUOTA_IEPS.Enabled = False
                        grpIEPS.Enabled = False
                    End If

                    tCVE_PRODSERV.Text = dr("CVE_PRODSERV").ToString
                    tCVE_UNIDAD.Text = dr("CVE_UNIDAD").ToString

                    CARGAR_ALTERNAS()
                    CARGAR_PRECIOS()
                    CARGAR_CAMPLIB()

                    tCVE_ART.Enabled = False
                    tDESCR.Select()
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If

        ENTRA = True

        ENTRA_FLEXI = True
    End Sub
    Sub MAX_LENGHT()
        tCVE_ART.MaxLength = 16
        tDESCR.MaxLength = 40
        tLIN_PROD.MaxLength = 5
        tUNI_MED.MaxLength = 10
        tCTRL_ALM.MaxLength = 10
        tUNI_ALT.MaxLength = 10
        tCUENT_CONT.MaxLength = 28
        tCVE_PRODSERV.MaxLength = 9
        tCVE_UNIDAD.MaxLength = 4
    End Sub
    Sub CARGAR_ALTERNAS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT CVE_ART, CVE_ALTER, TIPO, CVE_CLPV, ISNULL(C.NOMBRE,'') AS NOMCLIE, ISNULL(P.NOMBRE,'') AS NOMPROV " &
                "FROM GCCVES_ALTER A " &
                "LEFT JOIN CLIE" & Empresa & " C ON C.CLAVE = A.CVE_CLPV AND TIPO = 'C' " &
                "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = A.CVE_CLPV AND TIPO = 'P' " &
                "WHERE CVE_ART = '" & tCVE_ART.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            FgA.Rows.Count = 1

            Do While dr.Read
                FgA.AddItem("" & vbTab & dr("CVE_ALTER") & vbTab & dr("TIPO") & vbTab & dr("CVE_CLPV") & vbTab & dr("NOMCLIE") & dr("NOMPROV"))
            Loop
            dr.Close()

        Catch ex As Exception
            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_PRECIOS()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim TienePrecios As Boolean

            cmd.Connection = cnSAE

            SQL = "SELECT pxp.CVE_ART, DESCRIPCION, pxp.CVE_PRECIO, pxp.PRECIO " &
                "FROM GCPRECIO_X_PROD pxp " &
                "LEFT JOIN GCPRECIOS p ON p.CVE_PRECIO = pxp.CVE_PRECIO " &
                "WHERE pxp.CVE_ART = '" & tCVE_ART.Text & "'"

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

                SQL = "SELECT DESCRIPCION, CVE_PRECIO FROM GCPRECIOS ORDER BY CVE_PRECIO"

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
            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPLIB()
        Try
            Dim TIPO_CAMPO As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            FgL.Rows.Count = 1

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'INVE_CLIB'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", dr("CAMPO")) Then
                    FgL.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                End If
            Loop
            dr.Close()

            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", dr("CAMPO")) Then
                    Select Case dr("CAMPO")
                        Case "CAMPLIB1"
                            FgL(1, 1) = dr("CAMPO")
                            FgL(1, 2) = dr("ETIQUETA")
                        Case "CAMPLIB2"
                            FgL(2, 1) = dr("CAMPO")
                            FgL(2, 2) = dr("ETIQUETA")
                        Case "CAMPLIB3"
                            FgL(3, 1) = dr("CAMPO")
                            FgL(3, 2) = dr("ETIQUETA")
                        Case "CAMPLIB4"
                            FgL(4, 1) = dr("CAMPO")
                            FgL(4, 2) = dr("ETIQUETA")
                        Case "CAMPLIB5"
                            FgL(5, 1) = dr("CAMPO")
                            FgL(5, 2) = dr("ETIQUETA")
                        Case "CAMPLIB6"
                            FgL(6, 1) = dr("CAMPO")
                            FgL(6, 2) = dr("ETIQUETA")
                        Case "CAMPLIB7"
                            FgL(7, 1) = dr("CAMPO")
                            FgL(7, 2) = dr("ETIQUETA")
                        Case "CAMPLIB8"
                            FgL(8, 1) = dr("CAMPO")
                            FgL(8, 2) = dr("ETIQUETA")
                        Case "CAMPLIB9"
                            FgL(9, 1) = dr("CAMPO")
                            FgL(9, 2) = dr("ETIQUETA")
                        Case "CAMPLIB10"
                            FgL(10, 1) = dr("CAMPO")
                            FgL(10, 2) = dr("ETIQUETA")
                        Case "CAMPLIB11"
                            FgL(11, 1) = dr("CAMPO")
                            FgL(11, 2) = dr("ETIQUETA")
                        Case "CAMPLIB12"
                            FgL(12, 1) = dr("CAMPO")
                            FgL(12, 2) = dr("ETIQUETA")
                        Case "CAMPLIB13"
                            FgL(13, 1) = dr("CAMPO")
                            FgL(13, 2) = dr("ETIQUETA")
                        Case "CAMPLIB14"
                            FgL(14, 1) = dr("CAMPO")
                            FgL(14, 2) = dr("ETIQUETA")
                        Case "CAMPLIB15"
                            FgL(15, 1) = dr("CAMPO")
                            FgL(15, 2) = dr("ETIQUETA")
                        Case "CAMPLIB16"
                            FgL(16, 1) = dr("CAMPO")
                            FgL(16, 2) = dr("ETIQUETA")
                    End Select
                End If
            Loop
            dr.Close()

            SQL = "SELECT * FROM GCINVE_CLIB WHERE CVE_PROD = '" & tCVE_ART.Text & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB1") Then
                    FgL(1, 3) = dr("CAMPLIB1").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB1")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(1, 4) = "N"
                    Else
                        FgL(1, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB2") Then
                    FgL(2, 3) = dr("CAMPLIB2").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB2")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(2, 4) = "N"
                    Else
                        FgL(2, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB3") Then
                    FgL(3, 3) = dr("CAMPLIB3").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB3")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(3, 4) = "N"
                    Else
                        FgL(3, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB4") Then
                    FgL(4, 3) = dr("CAMPLIB4").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB4")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(4, 4) = "N"
                        If FgL(4, 3).ToString = "" Then
                            FgL(4, 3) = "0"
                        End If
                    Else
                        FgL(4, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB5") Then
                    FgL(5, 3) = dr("CAMPLIB5").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB5")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(5, 4) = "N"
                        If FgL(5, 3).ToString = "" Then
                            FgL(5, 3) = "0"
                        End If
                    Else
                        FgL(5, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB6") Then
                    FgL(6, 3) = dr("CAMPLIB6").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB6")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(6, 4) = "N"
                        If FgL(6, 3).ToString = "" Then
                            FgL(6, 3) = "0"
                        End If
                    Else
                        FgL(6, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB7") Then
                    FgL(7, 3) = dr("CAMPLIB7").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB7")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(7, 4) = "N"
                        If FgL(7, 3).ToString = "" Then
                            FgL(7, 3) = "0"
                        End If
                    Else
                        FgL(7, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB8") Then
                    FgL(8, 3) = dr("CAMPLIB8").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB8")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(8, 4) = "N"
                    Else
                        FgL(8, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB9") Then
                    FgL(9, 3) = dr("CAMPLIB9").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB9")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(9, 4) = "N"
                    Else
                        FgL(9, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB10") Then
                    FgL(10, 3) = dr("CAMPLIB10").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB10")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(10, 4) = "N"
                    Else
                        FgL(10, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB11") Then
                    FgL(11, 3) = dr("CAMPLIB11").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB11")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(11, 4) = "N"
                    Else
                        FgL(11, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB12") Then
                    FgL(12, 3) = dr("CAMPLIB12").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB12")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(12, 4) = "N"
                    Else
                        FgL(12, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB13") Then
                    FgL(13, 3) = dr("CAMPLIB13").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB13")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(13, 4) = "N"
                    Else
                        FgL(13, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB14") Then
                    FgL(14, 3) = dr("CAMPLIB14").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB14")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(14, 4) = "N"
                    Else
                        FgL(14, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB15") Then
                    FgL(15, 3) = dr("CAMPLIB15").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB15")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(15, 4) = "N"
                    Else
                        FgL(15, 4) = ""
                    End If
                End If
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", "CAMPLIB16") Then
                    FgL(16, 3) = dr("CAMPLIB16").ToString
                    TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB16")
                    If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                        FgL(16, 4) = "N"
                    Else
                        FgL(16, 4) = ""
                    End If
                End If
            End If
            dr.Close()
            Me.Refresh()

            Fg.FinishEditing()

        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_PRECIOS2()
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim TienePrecios As Boolean

            cmd.Connection = cnSAE

            SQL = "SELECT DESCRIPCION, CVE_PRECIO FROM GCPRECIOS ORDER BY CVE_PRECIO"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            TienePrecios = False
            Do While dr.Read
                TienePrecios = True
                Fg.AddItem("" & vbTab & dr("CVE_PRECIO") & vbTab & dr("DESCRIPCION") & vbTab & "0" & vbTab & "")
            Loop
            dr.Close()
        Catch ex As Exception
            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_CAMPLIB2()
        Try
            Dim TIPO_CAMPO As String

            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            FgL.Rows.Count = 1

            cmd.Connection = cnSAE
            SQL = "SELECT * FROM PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'INVE_CLIB'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", dr("CAMPO")) Then
                    FgL.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                End If
            Loop
            dr.Close()

            dr = cmd.ExecuteReader
            Do While dr.Read
                If EXIST_FIELD_SQL_SAE("GCINVE_CLIB", dr("CAMPO")) Then
                    Select Case dr("CAMPO")
                        Case "CAMPLIB1"
                            FgL(1, 1) = dr("CAMPO")
                            FgL(1, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB1")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(1, 4) = "N"
                                FgL(1, 3) = "0"
                            Else
                                FgL(1, 4) = ""
                            End If
                        Case "CAMPLIB2"
                            FgL(2, 1) = dr("CAMPO")
                            FgL(2, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB2")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                        TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(2, 4) = "N"
                                FgL(2, 3) = "0"
                            End If
                        Case "CAMPLIB3"
                            FgL(3, 1) = dr("CAMPO")
                            FgL(3, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB3")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(3, 4) = "N"
                                FgL(3, 3) = "0"
                            End If
                        Case "CAMPLIB4"
                            FgL(4, 1) = dr("CAMPO")
                            FgL(4, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB4")

                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                    TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(4, 4) = "N"
                                FgL(4, 3) = "0"
                            End If
                        Case "CAMPLIB5"
                            FgL(5, 1) = dr("CAMPO")
                            FgL(5, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB5")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(5, 4) = "N"
                                FgL(5, 3) = "0"
                            End If
                        Case "CAMPLIB6"
                            FgL(6, 1) = dr("CAMPO")
                            FgL(6, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB6")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(6, 4) = "N"
                                FgL(6, 3) = "0"
                            End If
                        Case "CAMPLIB7"
                            FgL(7, 1) = dr("CAMPO")
                            FgL(7, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB7")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(7, 4) = "N"
                                FgL(7, 3) = "0"
                            End If
                        Case "CAMPLIB8"
                            FgL(8, 1) = dr("CAMPO")
                            FgL(8, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB8")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(8, 4) = "N"
                                FgL(8, 3) = "0"
                            End If
                        Case "CAMPLIB9"
                            FgL(9, 1) = dr("CAMPO")
                            FgL(9, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB9")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(9, 4) = "N"
                                FgL(9, 3) = "0"
                            End If
                        Case "CAMPLIB10"
                            FgL(10, 1) = dr("CAMPO")
                            FgL(10, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB10")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(10, 4) = "N"
                                FgL(10, 3) = "0"
                            End If
                        Case "CAMPLIB11"
                            FgL(11, 1) = dr("CAMPO")
                            FgL(11, 2) = dr("ETIQUETA")
                            FgL(11, 3) = dr("CAMPLIB11").ToString
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB11")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(11, 4) = "N"
                                FgL(11, 3) = "0"
                            End If
                        Case "CAMPLIB12"
                            FgL(12, 1) = dr("CAMPO")
                            FgL(12, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB12")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(12, 4) = "N"
                                FgL(12, 3) = "0"
                            End If
                        Case "CAMPLIB13"
                            FgL(13, 1) = dr("CAMPO")
                            FgL(13, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB13")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(13, 4) = "N"
                                FgL(13, 3) = "0"
                            End If
                        Case "CAMPLIB14"
                            FgL(14, 1) = dr("CAMPO")
                            FgL(14, 2) = dr("ETIQUETA")
                            FgL(14, 3) = dr("CAMPLIB14").ToString
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB14")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(14, 4) = "N"
                                FgL(14, 3) = "0"
                            End If
                        Case "CAMPLIB15"
                            FgL(15, 1) = dr("CAMPO")
                            FgL(15, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB15")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(15, 4) = "N"
                                FgL(15, 3) = "0"
                            End If
                        Case "CAMPLIB16"
                            FgL(16, 1) = dr("CAMPO")
                            FgL(16, 2) = dr("ETIQUETA")
                            TIPO_CAMPO = GET_DATATYPE("GCINVE_CLIB", "CAMPLIB16")
                            If TIPO_CAMPO = "FLOAT" Or TIPO_CAMPO = "SMALLINT" Or TIPO_CAMPO = "INT" Or TIPO_CAMPO = "DOUBLE" Or
                                TIPO_CAMPO = "NUMERIC" Or TIPO_CAMPO = "TINYINT" Or TIPO_CAMPO = "BIT" Or TIPO_CAMPO = "REAL" Then
                                FgL(16, 4) = "N"
                                FgL(16, 3) = "0"
                            End If
                    End Select
                End If
            Loop
            dr.Close()

            Me.Refresh()

            Fg.FinishEditing()

        Catch ex As Exception
            MsgBox("18. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("18. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LIMPIAR()
        Try
            btnKit.Visible = False

            tCVE_ART.Text = ""
            tDESCR.Text = ""
            tDESCR.Tag = "A"
            tLIN_PROD.Text = ""
            chNUM_SERIE.Checked = False
            tUNI_MED.Text = ""
            tUNI_EMP.Value = 0
            tCTRL_ALM.Text = ""
            tTIEM_SURT.Value = 0
            tSTOCK_MIN.Value = 0
            tSTOCK_MAX.Value = 0
            radUEPS.Checked = False
            radPEPS.Checked = False
            radPROMEDIO.Checked = True
            radESTANDAR.Checked = False
            radIDENTIFICADO.Checked = False

            tCOMP_X_REC.Value = 0
            tPESO.Value = 0
            tVOLUMEN.Value = 0

            tNUM_MON.Value = 0
            F2.Value = Now
            F1.Value = Now
            tPEND_SURT.Value = 0
            tEXIST.Value = 0
            tCOSTO_PROM.Value = 0
            tULT_COSTO.Value = 0
            'tCVE_OBS.value = 0
            radProducto.Checked = True
            tUNI_ALT.Text = ""
            tFAC_CONV.Value = 0
            tAPART.Value = 0
            chCON_LOTE.Checked = False
            chCON_PEDIMENTO.Checked = False
            tPEND_SURT.Value = 0
            tCVE_ESQIMPU.Value = 1
            tVTAS_ANL_C.Value = 0
            tVTAS_ANL_M.Value = 0
            tCOMP_ANL_C.Value = 0
            tCOMP_ANL_M.Value = 0
            tCUENT_CONT.Text = ""
            Pic.Image = PicFoto.Image
            Pic.Tag = ""

            chMAN_IEPS.Checked = False
            grpIEPS.Enabled = False
            cboAPL_MAN_IMP.SelectedIndex = -1
            tCUOTA_IEPS.Value = 0
            radUEPS2.Checked = True
            tCVE_PRODSERV.Text = ""
            tCVE_UNIDAD.Text = ""
            FgA.Rows.Count = 1
            Fg.Rows.Count = 1
            FgL.Rows.Count = 1

        Catch ex As Exception
            MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmInvenRAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmInvenRAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim TIP_COSTEO As String
        Dim CVE_OBS As Long
        Dim TIPO_ELE As String
        Dim CVE_IMAGEN As String
        Dim APL_MAN_IEPS As String
        Dim file_ext As String
        Dim file_name As String
        Dim file_name_sin_ext As String

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        If tDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        Try
            If tCVE_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(tCVE_OBS.Tag) Then
                    CVE_OBS = tCVE_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tCVE_OBS.Text & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tCVE_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If

            tCVE_OBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        CVE_IMAGEN = ""
        Try
            tCVE_ESQIMPU.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

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
                FileCopy(Pic.Tag, Application.StartupPath & "\IMAGENES\" & CVE_IMAGEN)
            End If
        End If

        TIP_COSTEO = "P"
        If radUEPS.Checked = True Then TIP_COSTEO = "U"
        If radPEPS.Checked = True Then TIP_COSTEO = "E"
        If radPROMEDIO.Checked = True Then TIP_COSTEO = "P"
        If radESTANDAR.Checked = True Then TIP_COSTEO = "S"
        If radIDENTIFICADO.Checked = True Then TIP_COSTEO = "I"
        TIPO_ELE = "P"
        If radProducto.Checked Then TIPO_ELE = "P"
        If radServicio.Checked Then TIPO_ELE = "S"
        If radKit.Checked Then TIPO_ELE = "K"
        If radGrupoProd.Checked Then TIPO_ELE = "G"

        APL_MAN_IEPS = "C"
        If radUEPS2.Checked Then APL_MAN_IEPS = "C"
        radPEPS2.Checked = True
        radPromedio2.Checked = True

        Fg.FinishEditing()
        FgA.FinishEditing()
        FgL.FinishEditing()


        SQL = "UPDATE GCINVER SET CVE_ART = @CVE_ART, DESCR = @DESCR, LIN_PROD = @LIN_PROD, CON_SERIE = @CON_SERIE, UNI_MED = @UNI_MED, " &
            "UNI_EMP = @UNI_EMP, CTRL_ALM = @CTRL_ALM, TIEM_SURT = @TIEM_SURT, STOCK_MIN = @STOCK_MIN, STOCK_MAX = @STOCK_MAX, " &
            "TIP_COSTEO = @TIP_COSTEO, NUM_MON = @NUM_MON, FCH_ULTCOM = @FCH_ULTCOM, FCH_ULTVTA = @FCH_ULTVTA, " &
            "PEND_SURT = @PEND_SURT, COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO, CVE_OBS = @CVE_OBS, TIPO_ELE = @TIPO_ELE, " &
            "UNI_ALT = @UNI_ALT, FAC_CONV = @FAC_CONV, APART = @APART, CON_LOTE = @CON_LOTE, CON_PEDIMENTO = @CON_PEDIMENTO, " &
            "PESO = @PESO, VOLUMEN = @VOLUMEN, CVE_ESQIMPU = @CVE_ESQIMPU, VTAS_ANL_C = @VTAS_ANL_C, " &
            "VTAS_ANL_M = @VTAS_ANL_M, COMP_ANL_C = @COMP_ANL_C, COMP_ANL_M = @COMP_ANL_M, " &
            "CUENT_CONT = @CUENT_CONT, CVE_IMAGEN = @CVE_IMAGEN, " &
            "MAN_IEPS = @MAN_IEPS, APL_MAN_IMP = @APL_MAN_IMP, CUOTA_IEPS = @CUOTA_IEPS, APL_MAN_IEPS = @APL_MAN_IEPS, " &
            "CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD " &
            "WHERE CVE_ART = @CVE_ART " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCINVER (CVE_ART, DESCR, STATUS, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, TIEM_SURT, STOCK_MIN, STOCK_MAX, TIP_COSTEO, " &
            "NUM_MON, FCH_ULTCOM, FCH_ULTVTA, PEND_SURT, EXIST, COSTO_PROM, ULT_COSTO, CVE_OBS, TIPO_ELE, UNI_ALT, " &
            "FAC_CONV, APART, CON_LOTE, CON_PEDIMENTO, PESO, VOLUMEN, CVE_ESQIMPU, VTAS_ANL_C, VTAS_ANL_M, COMP_ANL_C, " &
            "COMP_ANL_M, CUENT_CONT, CVE_IMAGEN, MAN_IEPS, APL_MAN_IMP, CUOTA_IEPS, " &
            "APL_MAN_IEPS, CVE_PRODSERV, CVE_UNIDAD, UUID) VALUES(@CVE_ART, @DESCR, 'A', @LIN_PROD, @CON_SERIE, @UNI_MED, @UNI_EMP, @CTRL_ALM, @TIEM_SURT, " &
            "@STOCK_MIN, @STOCK_MAX, @TIP_COSTEO, @NUM_MON, @FCH_ULTCOM, @FCH_ULTVTA, @PEND_SURT, 0, @COSTO_PROM, @ULT_COSTO, " &
            "@CVE_OBS, @TIPO_ELE, @UNI_ALT, @FAC_CONV, @APART, @CON_LOTE, @CON_PEDIMENTO, @PESO, @VOLUMEN, @CVE_ESQIMPU, @VTAS_ANL_C, " &
            "@VTAS_ANL_M, @COMP_ANL_C, @COMP_ANL_M, @CUENT_CONT, @CVE_IMAGEN, @MAN_IEPS, " &
            "@APL_MAN_IMP, @CUOTA_IEPS, @APL_MAN_IEPS, @CVE_PRODSERV, @CVE_UNIDAD, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(tCVE_ART.Text)
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = RemoveCharacter(tDESCR.Text)
            cmd.Parameters.Add("@LIN_PROD", SqlDbType.VarChar).Value = RemoveCharacter(tLIN_PROD.Text)
            cmd.Parameters.Add("@CON_SERIE", SqlDbType.VarChar).Value = IIf(chNUM_SERIE.Checked, "S", "N")
            cmd.Parameters.Add("@UNI_MED", SqlDbType.VarChar).Value = tUNI_MED.Text
            cmd.Parameters.Add("@UNI_EMP", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tUNI_EMP.Text))
            cmd.Parameters.Add("@CTRL_ALM", SqlDbType.VarChar).Value = tCTRL_ALM.Text
            cmd.Parameters.Add("@TIEM_SURT", SqlDbType.Int).Value = CONVERTIR_TO_INT(CDec(tTIEM_SURT.Text))
            cmd.Parameters.Add("@STOCK_MIN", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tSTOCK_MIN.Text))
            cmd.Parameters.Add("@STOCK_MAX", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tSTOCK_MAX.Text))
            cmd.Parameters.Add("@TIP_COSTEO", SqlDbType.VarChar).Value = TIP_COSTEO
            cmd.Parameters.Add("@NUM_MON", SqlDbType.Int).Value = CONVERTIR_TO_INT(CDec(tNUM_MON.Text))
            cmd.Parameters.Add("@FCH_ULTCOM", SqlDbType.DateTime).Value = F2.Value
            cmd.Parameters.Add("@FCH_ULTVTA", SqlDbType.DateTime).Value = F1.Value
            cmd.Parameters.Add("@PEND_SURT", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tPEND_SURT.Text))
            cmd.Parameters.Add("@COSTO_PROM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tCOSTO_PROM.Text))
            cmd.Parameters.Add("@ULT_COSTO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tULT_COSTO.Text))
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            cmd.Parameters.Add("@TIPO_ELE", SqlDbType.VarChar).Value = TIPO_ELE
            cmd.Parameters.Add("@UNI_ALT", SqlDbType.VarChar).Value = tUNI_ALT.Text
            cmd.Parameters.Add("@FAC_CONV", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tFAC_CONV.Text))
            cmd.Parameters.Add("@APART", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tAPART.Text))
            cmd.Parameters.Add("@CON_LOTE", SqlDbType.VarChar).Value = IIf(chCON_LOTE.Checked, "S", "N")
            cmd.Parameters.Add("@CON_PEDIMENTO", SqlDbType.VarChar).Value = IIf(chCON_PEDIMENTO.Checked, "S", "S")
            cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tPESO.Text))
            cmd.Parameters.Add("@VOLUMEN", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tVOLUMEN.Text))
            cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.Int).Value = tCVE_ESQIMPU.Value
            cmd.Parameters.Add("@VTAS_ANL_C", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tVTAS_ANL_C.Text))
            cmd.Parameters.Add("@VTAS_ANL_M", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tVTAS_ANL_M.Text))
            cmd.Parameters.Add("@COMP_ANL_C", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tCOMP_ANL_C.Text))
            cmd.Parameters.Add("@COMP_ANL_M", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tCOMP_ANL_M.Text))
            cmd.Parameters.Add("@CUENT_CONT", SqlDbType.VarChar).Value = tCUENT_CONT.Text
            cmd.Parameters.Add("@CVE_IMAGEN", SqlDbType.VarChar).Value = CVE_IMAGEN
            cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = IIf(chMAN_IEPS.Checked, "S", "N")
            cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = cboAPL_MAN_IMP.SelectedIndex
            cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CDec(tCUOTA_IEPS.Text))
            cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = APL_MAN_IEPS
            cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = tCVE_PRODSERV.Text
            cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = tCVE_UNIDAD.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABAR_ALTERNAS()
                    GRABAR_PRECIOS()
                    GRABAR_CAMPLIB()

                    If ART_NEW Then
                        If MsgBox("¿Desea registrar el producto en multialmacén?", vbYesNo) = vbYes Then
                            Var25 = tCVE_ART.Text
                            frmAltaMultialmacenR.ShowDialog()
                        End If
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
            MsgBox("21. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("21. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_ALTERNAS()
        Try
            Dim cmd As New SqlCommand
            Dim CVE_ALTER As String
            Dim TIPO As String
            Dim CVE_CLPV As String

            cmd.Connection = cnSAE
            cmd.CommandText = "DELETE GCCVES_ALTER WHERE CVE_ART = '" & tCVE_ART.Text & "'"
            cmd.ExecuteNonQuery()

            For K = 1 To FgA.Rows.Count - 1

                CVE_ALTER = FgA(K, 1)
                TIPO = FgA(K, 2)
                CVE_CLPV = FgA(K, 3)

                SQL = "INSERT INTO GCCVES_ALTER (CVE_ART, CVE_ALTER, TIPO, CVE_CLPV) VALUES('" & tCVE_ART.Text & "','" &
                      CVE_ALTER & "','" & TIPO & "','" & CVE_CLPV & "')"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("22. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("22. " & ex.Message & vbNewLine & ex.StackTrace)
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
                    SQL = "UPDATE GCPRECIO_X_PROD SET PRECIO = " & PRECIO & " WHERE CVE_ART = '" & tCVE_ART.Text & "' AND " &
                        "CVE_PRECIO = " & CVE_PRECIO & " IF @@ROWCOUNT = 0 " &
                        "INSERT INTO GCPRECIO_X_PROD (CVE_ART, CVE_PRECIO, PRECIO) VALUES('" & tCVE_ART.Text & "','" &
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
            MsgBox("23. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("23. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CAMPLIB()
        Try
            Dim cmd As New SqlCommand
            Dim CAMPO As String
            Dim DESCR As String
            Dim TIPO As String
            Dim CAD As String

            cmd.Connection = cnSAE

            For K = 1 To FgL.Rows.Count - 1
                CAMPO = FgL(K, 1)
                DESCR = FgL(K, 3)
                TIPO = FgL(K, 4)
                If TIPO = "N" Then
                    CAD = ""
                Else
                    CAD = "'"
                End If
                If DESCR.Trim.Length > 0 Then
                    SQL = "UPDATE GCINVE_CLIB SET " & CAMPO & " = " & CAD & DESCR & CAD & " WHERE CVE_PROD = '" & tCVE_ART.Text & "' IF @@ROWCOUNT = 0 " &
                      "INSERT INTO GCINVE_CLIB (CVE_PROD, " & CAMPO & ") VALUES('" & tCVE_ART.Text & "','" & DESCR & "')"
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("24. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("24. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub btnLinea_Click(sender As Object, e As EventArgs) Handles btnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tLIN_PROD.Text = Var4
                LtLinea.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tTIEM_SURT.Focus()
                Me.Refresh()
            End If

        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEsquema_Click(sender As Object, e As EventArgs) Handles btnEsquema.Click
        Try
            Var2 = "Esquema"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_ESQIMPU.Text = Var4
                LtEsquema.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                chMAN_IEPS.Focus()
            End If

        Catch ex As Exception
            MsgBox("32. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnMoneda_Click(sender As Object, e As EventArgs) Handles btnMoneda.Click

        Try
            Var2 = "Meneda"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_MON.Text = Var4
                LtMoneda.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_ESQIMPU.Focus()
            End If

        Catch ex As Exception
            MsgBox("33. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("33. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub chMAN_IEPS_CheckedChanged(sender As Object, e As EventArgs) Handles chMAN_IEPS.CheckedChanged

        Try
            If chMAN_IEPS.Checked Then
                chMAN_IEPS.Checked = True
                cboAPL_MAN_IMP.Enabled = True
                tCUOTA_IEPS.Enabled = True
                grpIEPS.Enabled = True
            Else
                chMAN_IEPS.Checked = False
                cboAPL_MAN_IMP.Enabled = False
                tCUOTA_IEPS.Enabled = False
                grpIEPS.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("34. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("34. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgL_EnterCell(sender As Object, e As EventArgs) Handles FgL.EnterCell

        ENTRA = False

        Try
            If FgL.Row > 0 And ENTRA_FLEXI Then
                FgL.StartEditing()
            End If
        Catch ex As Exception
            MsgBox("35. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("35. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgL_LeaveCell(sender As Object, e As EventArgs) Handles FgL.LeaveCell
        Try
            If FgL.Row > 0 And ENTRA_FLEXI Then
                'FgL.FinishEditing()
            End If
        Catch ex As Exception
            MsgBox("99. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("99. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgL_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgL.ValidateEdit

        Try
            If e.Row > 0 And ENTRA_FLEXI Then
                If e.Col = 3 Then
                    If FgL(e.Row, 4) = "N" Then
                        If Not IsNumeric(FgL.Editor.Text()) Then
                            e.Cancel = True
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

    Private Sub tCUENT_CONT_KeyDown(sender As Object, e As KeyEventArgs) Handles tCUENT_CONT.KeyDown
        If e.KeyCode = Keys.Enter Then
            GroupBox8.Select()
        End If
    End Sub

    Private Sub tNUM_MON_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_MON.KeyDown
        If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then

            If Not EXISTE_DATA("MONED", tNUM_MON.Text) Then
                MsgBox("Moneda inexistente")
            End If
            GroupBox10.Select()
        End If
        If e.KeyCode = Keys.F2 Then
            btnMoneda_Click(Nothing, Nothing)

        End If
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus

        ENTRA = False

    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        ENTRA = True
    End Sub

    Private Sub Pic_Click(sender As Object, e As EventArgs) Handles Pic.Click

    End Sub

    Private Sub Pic_DoubleClick(sender As Object, e As EventArgs) Handles Pic.DoubleClick

        Try
            Dim ofd As OpenFileDialog = New OpenFileDialog
            ofd.DefaultExt = "jpg"
            ofd.FileName = ""
            'ofd.InitialDirectory = "c:\"
            ofd.Filter = "JPG|*.jpg|PNG|*.png|BMP|*.bmp|PNG|*.png"
            ofd.Title = "Select file"
            If ofd.ShowDialog() <> DialogResult.Cancel Then
                'MsgBox(ofd.FileName)
                Pic.Image = Image.FromFile(ofd.FileName)
                Pic.Tag = ofd.FileName
            End If
        Catch ex As Exception
            MsgBox("102. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("102. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnAltaAlter_Click(sender As Object, e As EventArgs) Handles btnAltaAlter.Click
        FgA.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
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
            MsgBox("104. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgA.ValidateEdit
        Try
            If e.Row > 0 Then
                Select Case e.Col
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
                                If CLAVE <> "N" Then
                                    FgA(e.Row, 4) = CLAVE
                                Else
                                    If FgA(e.Row, 2) = "C" Then
                                        MsgBox("Cliente inexistente")
                                    Else
                                        MsgBox("Proveedor inexistente")
                                    End If
                                End If
                            Else
                                FgA(e.Row, 4) = ""
                            End If
                        End If
                End Select
            End If
        Catch ex As Exception
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
            MsgBox("106. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgA_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles FgA.ComboCloseUp
        Try
            If e.Row > 0 Then
                If e.Col = 2 Then
                    If FgA.Editor.Text = "N" Then
                        FgA(e.Row, 3) = ""
                        FgA(e.Row, 4) = ""
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tLIN_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles tLIN_PROD.KeyDown
        If e.KeyCode = Keys.F2 Then

            btnLinea_Click(Nothing, Nothing)

        End If
    End Sub
    Private Sub FgA_GotFocus(sender As Object, e As EventArgs) Handles FgA.GotFocus
        Try
            If FgA.Rows.Count > 1 Then
                FgA.Row = 1
                FgA.Col = 1
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub tAPART_KeyDown(sender As Object, e As KeyEventArgs) Handles tAPART.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            FgA.Focus()

        End If
    End Sub

    Private Sub tCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_ESQIMPU.KeyDown
        If e.KeyCode = Keys.F2 Then

            btnEsquema_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_PRODSERV_TextChanged(sender As Object, e As EventArgs) Handles tCVE_PRODSERV.TextChanged

    End Sub
    Private Sub tCVE_PRODSERV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PRODSERV.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClaveSAT_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_UNIDAD_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNIDAD.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUnidadSAT_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tLIN_PROD_Validating(sender As Object, e As CancelEventArgs) Handles tLIN_PROD.Validating
        Try
            If tLIN_PROD.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", tLIN_PROD.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    tLIN_PROD.Text = ""
                    tLIN_PROD.Select()
                Else
                    LtLinea.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_MON_Validating(sender As Object, e As CancelEventArgs) Handles tNUM_MON.Validating
        Try
            If tNUM_MON.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Moneda", tNUM_MON.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Moneda inexistente")
                    tNUM_MON.Text = ""
                    tNUM_MON.Select()
                Else
                    tNUM_MON.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_ESQIMPU_Validating(sender As Object, e As CancelEventArgs) Handles tCVE_ESQIMPU.Validating
        Try
            If tCVE_ESQIMPU.Value > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Esquema", tCVE_ESQIMPU.Value)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Esquema inexistente")
                    tCVE_ESQIMPU.Value = 0
                    tCVE_ESQIMPU.Select()
                Else
                    LtEsquema.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("112. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnKit_Click(sender As Object, e As EventArgs) Handles btnKit.Click

        Try
            Var10 = tCVE_ART.Text
            Var11 = "InvenR"
            If Fg.Row > 0 Then
                If IsNumeric(Fg(Fg.Row, 3)) Then
                    Var12 = Fg(Fg.Row, 3)
                Else
                    Var12 = "0"
                End If
            End If

            frmKit.ShowDialog()
        Catch ex As Exception
            MsgBox("113. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("113. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub radProducto_CheckedChanged(sender As Object, e As EventArgs) Handles radProducto.CheckedChanged
        If radProducto.Checked Then
            btnKit.Visible = False
        End If
    End Sub
    Private Sub radServicio_CheckedChanged(sender As Object, e As EventArgs) Handles radServicio.CheckedChanged
        If radServicio.Checked Then
            btnKit.Visible = False
        End If
    End Sub
    Private Sub radKit_CheckedChanged(sender As Object, e As EventArgs) Handles radKit.CheckedChanged
        If radKit.Checked Then
            btnKit.Visible = True
        Else
            btnKit.Visible = False
        End If
    End Sub
    Private Sub radGrupoProd_CheckedChanged(sender As Object, e As EventArgs) Handles radGrupoProd.CheckedChanged
        If radGrupoProd.Checked Then
            btnKit.Visible = False
        End If
    End Sub

    Private Sub btnClaveSAT_Click(sender As Object, e As EventArgs) Handles btnClaveSAT.Click
        Prosec = "CATINV"
        frmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            tCVE_PRODSERV.Text = Var10
            Label38.Text = Var11
        End If
    End Sub

    Private Sub btnUnidadSAT_Click(sender As Object, e As EventArgs) Handles btnUnidadSAT.Click
        Prosec = "UNIMED"
        frmNewXCategoria.ShowDialog()
        If Var10.Trim.Length > 0 Then
            tCVE_UNIDAD.Text = Var10
            Label39.Text = Var11
        End If
    End Sub
End Class
