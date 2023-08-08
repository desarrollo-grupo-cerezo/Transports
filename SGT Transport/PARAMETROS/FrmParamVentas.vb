Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports System.IO
Public Class FrmParamVentas
    Private TIPO_D As String
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Me.SuspendLayout()
        CARGAR_DATOS1()
        Me.ResumeLayout()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Private Sub FrmParamVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim SPOR1 As Decimal

        SPOR1 = (BarraMenu.Height / Me.Height) * 100
        Split1.SizeRatio = SPOR1 + 1

        Split2.SizeRatio = 100 - Split1.SizeRatio

    End Sub
    Sub CARGAR_DATOS1()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

        Catch ex As Exception
        End Try

        Me.WindowState = FormWindowState.Maximized
        Dim SERIE_PEDIDOS As String = "", SERIE_PROGPEDIDOS As String = "", SERIE_REMISION As String = ""
        Dim SERIE_REMISION_EXT As String = ""
        Dim SERIE_CARTA_PORTE As String = "", SERIE_CAP_FACTURA As String = ""
        Try
            BarraMenuFolios.BackColor = Color.FromArgb(207, 221, 238)

            SplitM1.Dock = DockStyle.Fill
            SplitM1.BorderWidth = 1
            SplitM1.SplitterWidth = 1
            SplitM1.FixedLineWidth = 1
            SplitM1.HeaderLineWidth = 1

            Tab1.Dock = DockStyle.Fill
            Tab2.Left = 0
            Tab2.Width = Me.Width - 5
            'Tab2.Height = 73
            Tab2.ItemSize = New Size(140, 30)

            BtnArtFG.FlatStyle = FlatStyle.Flat
            BtnArtFG.FlatAppearance.BorderSize = 0
            BtnCliente.FlatStyle = FlatStyle.Flat
            BtnCliente.FlatAppearance.BorderSize = 0

            LSerieDoc.Text = ""

            Fg.Rows.Count = 1
            Fg.Cols(0).Width = 30

            CboPeriodicidad.Items.Add("")

            Dim dt As DataTable
            dt = New DataTable()
            dt.Columns.Add("Periodicidad", GetType(System.String))
            dt.Columns.Add("Descripción", GetType(System.String))
            'dt.Columns.Add("BANCO", GetType(System.String))

            CboPeriodicidad.Items.Clear()
            dt.Rows.Add("01", "Diario")
            dt.Rows.Add("02", "Semanal")
            dt.Rows.Add("03", "Quincenal")
            dt.Rows.Add("04", "Mensual")

            CboPeriodicidad.TextDetached = True
            CboPeriodicidad.ItemsDataSource = dt.DefaultView
            CboPeriodicidad.ItemsDisplayMember = "Descripción"
            CboPeriodicidad.ItemsValueMember = "Periodicidad"
            CboPeriodicidad.ItemMode = C1.Win.C1Input.ComboItemMode.HtmlPattern
            CboPeriodicidad.HtmlPattern = "<table><tr><td width=30>{Periodicidad}</td><td width=100>{Descripción}</td></td><td width=220></tr></table>"

            SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(ULT_DOC,0) AS ULTDOC, ISNULL(SERIE,'') AS LETRA
                FROM FOLIOSF" & Empresa & "
                WHERE TIP_DOC = 'F' or  TIP_DOC = 'R' or  TIP_DOC = 'P'"
            CboSeriePedidos.Items.Clear()
            CboSerieCartaPorte.Items.Clear()

            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Select Case dr("TI_DOC")
                            Case "F"
                                'CboSeriesPorDoc.Items.Add(dr("LETRA"))
                                CboSerieFacGlobal.Items.Add(dr("LETRA"))
                                CboSerieFactura.Items.Add(dr("LETRA"))
                            Case "R"
                                CboSerieRemision.Items.Add(dr("LETRA"))
                                CboSerieRemisionExt.Items.Add(dr("LETRA"))
                                CboSerieCartaPorte.Items.Add(dr("LETRA"))
                                CboSerieCAPFactura.Items.Add(dr("LETRA"))
                            Case "P"
                                CboSeriePedidos.Items.Add(dr("LETRA"))
                                CboSerieProgPedidos.Items.Add(dr("LETRA"))
                        End Select
                    End While
                End Using
            End Using

            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_LIN, DESC_LIN FROM CLIN" & Empresa & " WHERE ISNULL(STATUS, 'A') = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_LIN") & ";" & dr("DESC_LIN") & Space(20))
                    End While
                End Using
            End Using
            Me.C1List1.Splits(0).DisplayColumns(0).Width = 50

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(LINEA,'') AS LIN FROM GCPARAMVENTAS_LIN_FAC ORDER BY LINEA"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        For row As Integer = 0 To C1List1.ListCount - 1
                            Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                            Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                            If cellValue = dr("LIN") Then
                                C1List1.SetSelected(row, True)
                            End If
                        Next
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM PRECIOS" & Empresa & " ORDER BY CVE_PRECIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboListaPrecPred.Items.Add(dr("CVE_PRECIO").ToString.PadLeft(2, " ") & " " & dr("DESCRIPCION"))
                    End While
                End Using
            End Using

            FgC.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_CPTO, DESCR FROM CONC" & Empresa & " 
                    WHERE ISNULL(STATUS, 'A') = 'A' AND TIPO = 'A' AND CON_REFER = 'S'
                    ORDER BY NUM_CPTO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgC.AddItem("" & vbTab & dr("NUM_CPTO") & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT NUM_CPTO, DESCR FROM GCPARAMVENTAS_CPTO ORDER BY NUM_CPTO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        For k = 1 To FgC.Rows.Count - 1
                            If FgC(k, 1) = dr("NUM_CPTO") Then
                                FgC(k, 3) = True
                                Exit For
                            End If
                        Next
                    End While
                End Using
            End Using

        Catch ex As Exception
            Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "SELECT ISNULL(C_ALTA_PROVEEDORES,0) AS ALTA_PROV, ISNULL(C_ALTA_PRODUCTOS,0) AS ALTA_PROD, ISNULL(INDIRECTOS_X_PARTIDA, 0) AS IND_X_PAR,
                ISNULL(OBSER_X_DOC, 0) AS OBS_X_DOC, ISNULL(OBSER_X_PARTIDA, 0) AS OBS_X_PAR, ISNULL(BLOQUEAR_PRECIO_PV,0) AS BLO_PREC,
                ISNULL(IMPUESTOS, 0) AS C_IMP, ISNULL(ALMACEN, 0) AS C_ALM, ISNULL(SERIE_PEDIDOS,'') AS S_REC, ISNULL(SERIE_PROGPEDIDOS,'') AS S_PROGPED, 
                ISNULL(SERIE_REMISION,'') AS S_REM, ISNULL(SERIE_REMISION_EXT,'') AS S_REM_EXT, SERIE_CARTA_PORTE, CVE_ART_CP, SERIE_CAP_FACTURA,
                ISNULL(LINEA_EN_VENTAS,'') AS LINEA_VTA, ISNULL(LIN_FAC_CFDI,'') AS L_FAC_CFDI, OCULTAR_CRE_ENG, OCULTAR_CREDITO, NOVALIDAR_LIM_CRED, 
                HABILITAR_DESC, PER_VEND_ABA_MIN, PER_VEND_ABA_COST, ACTIVAR_POLITICAS, ACTIVAR_GAD, ART_CON_IMP_INCLU, VENDER_SIN_EXIST, 
                BLOQEAR_LISTA_PREC, UTILIZAR_LECTOR_HUELLA, ALTA_CTE_POS, ALTA_PROD_POS, CLIE_MOSTR, LISTAPRECPRED, SERIE_FACTURA_GLOBAL, 
                ISNULL(PERIODICIDAD,-1) AS PERIODICID, CVE_ART_FG, CVE_PRODSERV, CVE_UNIDAD, ISNULL(SERIE_FAC_BUENO,'') AS SER_FAC_BUE
                FROM GCPARAMVENTAS"
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    ChOCULTAR_CRE_ENG.Value = dr("ALTA_PROV")
                    ChOCULTAR_CREDITO.Value = dr("ALTA_PROD")
                    ChObser_x_doc.Value = dr("OBS_X_DOC")
                    ChOBSER_X_PARTIDA.Value = dr("OBS_X_PAR")
                    ChINDIRECTOS_X_PARTIDA.Value = dr("IND_X_PAR")
                    ChIMPUESTOS.Value = dr("C_IMP")
                    ChALMACEN.Value = dr("C_ALM")
                    SERIE_PEDIDOS = dr("S_REC")
                    SERIE_PROGPEDIDOS = dr("S_PROGPED")
                    SERIE_REMISION = dr("S_REM")
                    SERIE_REMISION_EXT = dr("S_REM_EXT")
                    ChBLOQEAR_LISTA_PREC.Value = dr("BLO_PREC")
                    '28 JULIO 2021
                    SERIE_CARTA_PORTE = dr.ReadNullAsEmptyString("SERIE_CARTA_PORTE")
                    TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART_CP")

                    SERIE_CAP_FACTURA = dr.ReadNullAsEmptyString("SERIE_CAP_FACTURA")
                    TLIN_VENTAS.Text = dr("LINEA_VTA")
                    TLIN_FAC_CFDI.Text = dr("L_FAC_CFDI")
                    'NUEVAS OPCIONES POS DIC 20022
                    ChOCULTAR_CRE_ENG.Checked = dr.ReadNullAsEmptyInteger("OCULTAR_CRE_ENG")
                    ChOCULTAR_CREDITO.Checked = dr.ReadNullAsEmptyInteger("OCULTAR_CREDITO")
                    ChNOVALIDAR_LIM_CRED.Checked = dr.ReadNullAsEmptyInteger("NOVALIDAR_LIM_CRED")
                    ChHABILITAR_DESC.Checked = dr.ReadNullAsEmptyInteger("HABILITAR_DESC")
                    ChPER_VEND_ABA_MIN.Checked = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_MIN")
                    ChPER_VEND_ABA_COST.Checked = dr.ReadNullAsEmptyInteger("PER_VEND_ABA_COST")
                    ChACTIVAR_POLITICAS.Checked = dr.ReadNullAsEmptyInteger("ACTIVAR_POLITICAS")
                    ChACTIVAR_GAD.Checked = dr.ReadNullAsEmptyInteger("ACTIVAR_GAD")
                    ChART_CON_IMP_INCLU.Checked = dr.ReadNullAsEmptyInteger("ART_CON_IMP_INCLU")
                    ChVENDER_SIN_EXIST.Checked = dr.ReadNullAsEmptyInteger("VENDER_SIN_EXIST")
                    ChBLOQEAR_LISTA_PREC.Checked = dr.ReadNullAsEmptyInteger("BLOQEAR_LISTA_PREC")
                    ChUTILIZAR_LECTOR_HUELLA.Checked = dr.ReadNullAsEmptyInteger("UTILIZAR_LECTOR_HUELLA")
                    ChALTA_CTE_POS.Checked = dr.ReadNullAsEmptyInteger("ALTA_CTE_POS")
                    ChALTA_PROD_POS.Checked = dr.ReadNullAsEmptyInteger("ALTA_PROD_POS")
                    TCLIE_MOSTR.Text = dr.ReadNullAsEmptyString("CLIE_MOSTR")

                    For k = 0 To CboListaPrecPred.Items.Count - 1
                        If Convert.ToInt16(CboListaPrecPred.Items(k).ToString.Substring(0, 2).Trim) = dr.ReadNullAsEmptyInteger("LISTAPRECPRED") Then
                            CboListaPrecPred.SelectedIndex = k
                            Exit For
                        End If
                    Next
                    If dr.ReadNullAsEmptyString("SERIE_FACTURA_GLOBAL").ToString.Trim.Length > 0 Then
                        For k = 0 To CboSerieFacGlobal.Items.Count - 1
                            If CboSerieFacGlobal.Items(k) = dr.ReadNullAsEmptyString("SERIE_FACTURA_GLOBAL") Then
                                CboSerieFacGlobal.SelectedIndex = k
                                Exit For
                            End If
                        Next
                    End If
                    CboPeriodicidad.SelectedIndex = dr("PERIODICID")

                    TCVE_ART_FG.Text = dr.ReadNullAsEmptyString("CVE_ART_FG")

                    TCVE_PRODSERV.Text = dr.ReadNullAsEmptyString("CVE_PRODSERV")
                    TCVE_UNIDAD.Text = dr.ReadNullAsEmptyString("CVE_UNIDAD")

                    For k = 0 To CboSerieFactura.Items.Count - 1
                        If CboSerieFactura.Items(k) = dr.ReadNullAsEmptyString("SER_FAC_BUE") Then
                            CboSerieFactura.SelectedIndex = k
                            Exit For
                        End If
                    Next

                End If
                dr.Close()
            Catch ex As Exception
                Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If SERIE_CAP_FACTURA.Trim.Length > 0 Then
                For k = 0 To CboSerieCAPFactura.Items.Count - 1
                    If CboSerieCAPFactura.Items(k) = SERIE_CAP_FACTURA Then
                        CboSerieCAPFactura.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            If SERIE_CARTA_PORTE.Trim.Length > 0 Then
                For k = 0 To CboSerieCartaPorte.Items.Count - 1
                    If CboSerieCartaPorte.Items(k) = SERIE_CARTA_PORTE Then
                        CboSerieCartaPorte.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            If SERIE_PEDIDOS.Trim.Length > 0 Then
                For k = 0 To CboSeriePedidos.Items.Count - 1
                    If CboSeriePedidos.Items(k) = SERIE_PEDIDOS Then
                        CboSeriePedidos.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_PROGPEDIDOS.Trim.Length > 0 Then
                For k = 0 To CboSerieProgPedidos.Items.Count - 1
                    If CboSerieProgPedidos.Items(k) = SERIE_PROGPEDIDOS Then
                        CboSerieProgPedidos.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            If SERIE_REMISION.Trim.Length > 0 Then
                For k = 0 To CboSerieRemision.Items.Count - 1
                    If CboSerieRemision.Items(k) = SERIE_REMISION Then
                        CboSerieRemision.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            If SERIE_REMISION_EXT.Trim.Length > 0 Then
                For k = 0 To CboSerieRemisionExt.Items.Count - 1
                    If CboSerieRemisionExt.Items(k) = SERIE_REMISION_EXT Then
                        CboSerieRemisionExt.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

            BtnLineaEnVentas.FlatStyle = FlatStyle.Flat
            BtnLineaEnVentas.FlatAppearance.BorderSize = 0
            BtnProducto.FlatStyle = FlatStyle.Flat
            BtnProducto.FlatAppearance.BorderSize = 0
            BtnLinea.FlatStyle = FlatStyle.Flat
            BtnLinea.FlatAppearance.BorderSize = 0

        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim LISTA_PREC_PRED As Integer

        If CboListaPrecPred.SelectedIndex = -1 Then
            LISTA_PREC_PRED = 0
        Else
            LISTA_PREC_PRED = Convert.ToInt16(CboListaPrecPred.Items(CboListaPrecPred.SelectedIndex).ToString.Substring(0, 2).Trim)
        End If

        Try
            SQL = "UPDATE GCPARAMVENTAS SET C_ALTA_PROVEEDORES = " & IIf(ChOCULTAR_CRE_ENG.Value, 1, 0) & ", 
                C_ALTA_PRODUCTOS = " & IIf(ChOCULTAR_CREDITO.Value, 1, 0) & ",
                OBSER_X_DOC = " & IIf(ChObser_x_doc.Value, 1, 0) & ", OBSER_X_PARTIDA = " & IIf(ChOBSER_X_PARTIDA.Value, 1, 0) & ",
                INDIRECTOS_X_PARTIDA = " & IIf(ChINDIRECTOS_X_PARTIDA.Value, 1, 0) & ", IMPUESTOS = " & IIf(ChIMPUESTOS.Value, 1, 0) & ",
                ALMACEN = " & IIf(ChALMACEN.Value, 1, 0) & ", SERIE_PEDIDOS = '" & CboSeriePedidos.Text & "', 
                SERIE_PROGPEDIDOS = '" & CboSerieProgPedidos.Text & "', 
                SERIE_REMISION = '" & CboSerieRemision.Text & "', BLOQUEAR_PRECIO_PV = " & IIf(ChBLOQEAR_LISTA_PREC.Checked, 1, 0) & ", 
                SERIE_REMISION_EXT = '" & CboSerieRemisionExt.Text & "', SERIE_CARTA_PORTE = '" & CboSerieCartaPorte.Text & "', 
                CVE_ART_CP = '" & TCVE_ART.Text & "', SERIE_CAP_FACTURA = '" & CboSerieCAPFactura.Text & "',
                LINEA_EN_VENTAS = '" & TLIN_VENTAS.Text & "', LIN_FAC_CFDI = '" & TLIN_FAC_CFDI.Text & "', 
                OCULTAR_CRE_ENG = " & IIf(ChOCULTAR_CRE_ENG.Checked, 1, 0) & ", OCULTAR_CREDITO = " & IIf(ChOCULTAR_CREDITO.Checked, 1, 0) & ", 
                NOVALIDAR_LIM_CRED = " & IIf(ChNOVALIDAR_LIM_CRED.Checked, 1, 0) & ", HABILITAR_DESC = " & IIf(ChHABILITAR_DESC.Checked, 1, 0) & ", 
                PER_VEND_ABA_MIN = " & IIf(ChPER_VEND_ABA_MIN.Checked, 1, 0) & ", PER_VEND_ABA_COST = " & IIf(ChPER_VEND_ABA_COST.Checked, 1, 0) & ", 
                ACTIVAR_POLITICAS = " & IIf(ChACTIVAR_POLITICAS.Checked, 1, 0) & ", ACTIVAR_GAD = " & IIf(ChACTIVAR_GAD.Checked, 1, 0) & ", 
                ART_CON_IMP_INCLU = " & IIf(ChART_CON_IMP_INCLU.Checked, 1, 0) & ", VENDER_SIN_EXIST = " & IIf(ChVENDER_SIN_EXIST.Checked, 1, 0) & ", 
                BLOQEAR_LISTA_PREC = " & IIf(ChBLOQEAR_LISTA_PREC.Checked, 1, 0) & ", 
                ALTA_CTE_POS = " & IIf(ChALTA_CTE_POS.Checked, 1, 0) & ", ALTA_PROD_POS = " & IIf(ChALTA_PROD_POS.Checked, 1, 0) & ", 
                CLIE_MOSTR = '" & TCLIE_MOSTR.Text & "', LISTAPRECPRED = " & LISTA_PREC_PRED & ", SERIE_FACTURA_GLOBAL = '" & CboSerieFacGlobal.Text & "',
                PERIODICIDAD = " & CboPeriodicidad.SelectedIndex & ", CVE_ART_FG = '" & TCVE_ART_FG.Text & "', 
                CVE_PRODSERV = '" & TCVE_PRODSERV.Text & "', CVE_UNIDAD = '" & TCVE_UNIDAD.Text & "', SERIE_FAC_BUENO = '" & CboSerieFactura.Text & "'"
            Try
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try


            Try
                EXECUTE_QUERY_NET("DELETE FROM GCPARAMVENTAS_LIN_FAC")

                For row As Integer = 0 To C1List1.ListCount - 1
                    Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                    Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                    If C1List1.GetSelected(row) Then
                        SQL = "INSERT INTO GCPARAMVENTAS_LIN_FAC (LINEA) VALUES ('" & cellValue & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                Next
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Try
                EXECUTE_QUERY_NET("DELETE FROM GCPARAMVENTAS_CPTO")

                For k = 1 To FgC.Rows.Count - 1
                    If FgC(k, 3) Then
                        SQL = "INSERT INTO GCPARAMVENTAS_CPTO (NUM_CPTO, DESCR) VALUES ('" & FgC(k, 1) & "','" & FgC(k, 2) & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                Next
            Catch ex As Exception
                Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
            End Try

            MsgBox("Los datos se grabaron satisfactoriamente")

        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Close()
    End Sub
    Private Sub FrmParamVentas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab2("Configuración ventas")
    End Sub

    Private Sub BtnSeries_Click(sender As Object, e As EventArgs)
        frmFOLIOSF.ShowDialog()
    End Sub


    Private Sub BtnProducto_Click(sender As Object, e As EventArgs) Handles BtnProducto.Click
        Try
            Var2 = "Servicios"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnProducto_Click(Nothing, Nothing)
        End If

    End Sub
    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("InveS", TCVE_ART.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Servicio inexistente")
                    TCVE_ART.Text = ""
                    TCVE_ART.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLineaEnVentas_Click(sender As Object, e As EventArgs) Handles BtnLineaEnVentas.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_VENTAS.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
                CboSeriePedidos.Focus()
            End If
        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLIN_VENTAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_VENTAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLineaEnVentas_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLIN_VENTAS_Validated(sender As Object, e As EventArgs) Handles TLIN_VENTAS.Validated
        Try
            If TLIN_VENTAS.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLIN_VENTAS.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLIN_VENTAS.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_FAC_CFDI.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLIN_FAC_CFDI_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_FAC_CFDI.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLinea_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TLIN_FAC_CFDI_Validated(sender As Object, e As EventArgs) Handles TLIN_FAC_CFDI.Validated
        Try
            If TLIN_FAC_CFDI.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLIN_FAC_CFDI.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLIN_FAC_CFDI.Text = ""
                    TLIN_FAC_CFDI.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Tab2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab2.SelectedIndexChanged
        Try
            Dim SerPorDoc As String = ""

            Select Case Tab2.SelectedIndex
                Case 0
                    SerPorDoc = "F"
                Case 1
                    SerPorDoc = "V"
                Case 2
                    SerPorDoc = "R"
                Case 3
                    SerPorDoc = "P"
                Case 4
                    SerPorDoc = "C"
                Case 5
                    SerPorDoc = "D"
                Case 6
                    SerPorDoc = "E"
                Case 7
                    SerPorDoc = "G"
                Case 8
                    SerPorDoc = "T"
            End Select

            LSerieDoc.Tag = SerPorDoc

            SQL = "SELECT ISNULL(TIP_DOC,'') AS TI_DOC, ISNULL(SERIE,'') AS LETRA
                FROM FOLIOSF" & Empresa & "
                WHERE TIP_DOC = '" & SerPorDoc & "' ORDER BY TIP_DOC"

            CboSeriesPorDoc.Items.Clear()
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboSeriesPorDoc.Items.Add(dr("LETRA"))
                    End While
                End Using
            End Using
            If CboSeriesPorDoc.Items.Count > 0 Then
                CboSeriesPorDoc.SelectedIndex = 0
            End If

        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnSeriesPorDoc_Click(sender As Object, e As EventArgs) Handles BtnSeriesPorDoc.Click

        Try
            BACKUPTXT("XTAB_CAPTION", "FrmParamDocumentos")

            Var11 = LSerieDoc.Tag
            FrmParamSeries.ShowDialog()

        Catch ex As Exception
        End Try
    End Sub
    Sub DESPLEGAR(fTIPO As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT ISNULL(TIP_DOC,'') AS T_DOC, ISNULL(FOLIODESDE,0) AS DESDE, ISNULL(FOLIOHASTA,0) AS HASTA,
                    ISNULL(SERIE,'') AS SER, ISNULL(ULT_DOC,0) AS U_DOC, ISNULL(TIPO,'') AS TIP
                    FROM FOLIOSF" & Empresa & " WHERE TIP_DOC = '" & fTIPO & "' ORDER BY SERIE"
                cmd.CommandText = SQL
                Fg.Rows.Count = 1
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("T_DOC") & vbTab & dr("DESDE") & vbTab & dr("HASTA") & vbTab & dr("SER") & vbTab &
                                   dr("U_DOC") & vbTab & IIf(dr("TIP") = "I", "Impresión", "Digital"))
                    End While
                End Using
            End Using
            TIPO_D = fTIPO
            'Fg.AutoSizeCols()

            AJUSTA_COLUMNAS_FG4(Me, Fg, 0)

        Catch ex As Exception
            Bitacora("9. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("9. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarNuevo_Click(sender As Object, e As EventArgs) Handles BarNuevo.Click
        Var1 = "Nuevo"

        If IsNothing(TIPO_D) Then
            MsgBox("Por favor seleccione tipo de documento")
            Return
        ElseIf TIPO_D.Trim.Length = 0 Then
            MsgBox("Por favor seleccione tipo de documento")
            Return
        End If

        Var5 = TIPO_D
        frmFoliosfAE.ShowDialog()
        DESPLEGAR(TIPO_D)
    End Sub
    Private Sub BarEdit_Click(sender As Object, e As EventArgs) Handles BarEdit.Click
        If Fg.Row > 0 Then
            Var1 = "Edit"

            If IsNothing(TIPO_D) Then
                MsgBox("Por favor seleccione tipo de documento")
                Return
            ElseIf TIPO_D.Trim.Length = 0 Then
                MsgBox("Por favor seleccione tipo de documento")
                Return
            End If

            Var5 = TIPO_D
            Var6 = Fg(Fg.Row, 4)
            frmFoliosfAE.ShowDialog()
            DESPLEGAR(TIPO_D)
        End If
    End Sub
    Private Sub BarFacturas_Click(sender As Object, e As EventArgs) Handles BarFacturas.Click

        LtDocus.Text = "FACTURAS"
        DESPLEGAR("F")
    End Sub
    Private Sub BarNotas_Click(sender As Object, e As EventArgs) Handles BarNotas.Click
        LtDocus.Text = "NOTAS DE VENTA"
        DESPLEGAR("V")
    End Sub
    Private Sub BarRemisiones_Click(sender As Object, e As EventArgs) Handles BarRemisiones.Click
        LtDocus.Text = "REMISIONES"
        DESPLEGAR("R")
    End Sub
    Private Sub BarPedidos_Click(sender As Object, e As EventArgs) Handles BarPedidos.Click
        LtDocus.Text = "PEDIDOS"
        DESPLEGAR("P")
    End Sub
    Private Sub BarCotizaciones_Click(sender As Object, e As EventArgs) Handles BarCotizaciones.Click
        LtDocus.Text = "COTIZACIONES"
        DESPLEGAR("C")
    End Sub
    Private Sub BarDevoluciones_Click(sender As Object, e As EventArgs) Handles BarDevoluciones.Click
        LtDocus.Text = "DEVOLUCIONES"
        DESPLEGAR("D")
    End Sub
    Private Sub BarPagoComplemento_Click(sender As Object, e As EventArgs) Handles BarPagoComplemento.Click
        LtDocus.Text = "COMPLEMENTO DE PAGO"
        DESPLEGAR("G")
    End Sub
    Private Sub BarCartaPorteTras_Click(sender As Object, e As EventArgs) Handles BarCartaPorteTras.Click
        LtDocus.Text = "CARTA PORTE TRASLADO"
        DESPLEGAR("T")
    End Sub

    Private Sub Tab1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tab1.SelectedIndexChanged

        Select Case Tab1.SelectedIndex
            Case 0
            Case 1
            Case 2
                Tab2.SelectedIndex = 0
                'BarFacturas_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "CLIE"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIE_MOSTR.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch Ex As Exception
            MsgBox("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("100. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIE_MOSTR_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIE_MOSTR.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnCliente_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCLIE_MOSTR_Validated(sender As Object, e As EventArgs) Handles TCLIE_MOSTR.Validated
        Try
            If TCLIE_MOSTR.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIE_MOSTR.Text.Trim) Then
                    DESCR = TCLIE_MOSTR.Text.Trim
                    DESCR = Space(10 - DESCR.Length) & DESCR
                    TCLIE_MOSTR.Text = DESCR
                End If
                DESCR = BUSCA_CAT("Cliente", TCLIE_MOSTR.Text)
                If DESCR = "" Then
                    MsgBox("Cliente inexistente")
                End If
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FgC_BeforeEdit(sender As Object, e As C1.Win.C1FlexGrid.RowColEventArgs) Handles FgC.BeforeEdit
        If e.Row > 0 Then
            If e.Col <> 3 Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub BtnArtFG_Click(sender As Object, e As EventArgs) Handles BtnArtFG.Click
        Try
            Var2 = "Articulo"
            Var4 = "" : Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_FG.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            Bitacora("64. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("64. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_FG_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_FG.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArtFG_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCVE_ART_FG_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_FG.Validated
        Try
            If TCVE_ART_FG.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Inven", TCVE_ART_FG.Text)
                If DESCR <> "" Then
                Else
                    MsgBox("Servicio inexistente")
                    TCVE_ART_FG.Text = ""
                    TCVE_ART_FG.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
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
End Class
