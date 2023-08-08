Imports C1.Win.C1Command
Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmEstacionTrabAE
    Private Sub FrmEstacionTrabAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.KeyPreview = True
        Catch ex As Exception
        End Try
        Dim LISTA_PREC As Integer
        TDECIMALES.Value = 6

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM PRECIOS" & Empresa & " ORDER BY CVE_PRECIO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        CboListaPrecPred.Items.Add(dr("CVE_PRECIO").ToString.PadLeft(2, " ") & " " & dr("DESCRIPCION"))
                    End While
                End Using
            End Using

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCESTACIONES ORDER BY ESTACION"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                    End While
                End Using
            End Using

            Lt1.Text = "Environment.MachineName:" & Environment.MachineName
            Lt2.Text = "getMacAddress:" & GetMacAddress()
            Lt3.Text = "GetMotherBoardID:" & GetMotherBoardID()

            If Var1 = "Nuevo" Then

                TESTACION.Text = Environment.MachineName
                TESTACION.Enabled = False

            Else
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT E.LECTORHUELLA, E.IMP_NOTA, E.CVE_VEND, E.PROMOCIONES, E.FLUJO, E.MONEDERO, E.VENDER_SIN_EXIST, 
                    E.DECIMALES, E.PRECIOS, E.PERMITE_DESC, E.CLIENTE, E.AGREGAR_PROD, E.LISTA_PREC, E.PAGOS_PARCIALES, 
                    E.COLUMNA_DESCUENTO, E.TIEMPO_AIRE, E.SOLECCIONAR_SERIES, E.OCULTAR_CRE_ENG, E.OCULTAR_CREDITO, 
                    E.NOVALIDAR_LIM_CRED, E.PER_VEND_ABA_COST, E.PER_VEND_ABA_MIN, E.ART_CON_IMP_INCLU, E.REIMPRIMIR_TICKET,
                    E.AGREGAR_CLIENTE, MACADDRESS, NOMBRE_PC, MOTHERBOARDID
                    FROM GCESTACIONES E WHERE ESTACION = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TESTACION.Text = dr("NOMBRE_PC")
                    ChLECTORHUELLA.Checked = IIf(dr("LECTORHUELLA") = 1, True, False)
                    ChIMP_NOTA.Checked = IIf(dr("IMP_NOTA") = 1, True, False)
                    ChPROMOCIONES.Checked = IIf(dr("PROMOCIONES") = 1, True, False)
                    ChFLUJO.Checked = IIf(dr("FLUJO") = 1, True, False)
                    ChMONEDERO.Checked = IIf(dr("MONEDERO") = 1, True, False)
                    ChVENDER_SIN_EXIST.Checked = IIf(dr("VENDER_SIN_EXIST") = 1, True, False)
                    ChPERMITE_DESC.Checked = IIf(dr("PERMITE_DESC") = 1, True, False)
                    ChAGREGAR_PROD.Checked = IIf(dr("AGREGAR_PROD") = 1, True, False)
                    ChAGREGAR_CLIENTE.Checked = IIf(dr("AGREGAR_CLIENTE") = 1, True, False)

                    ChPAGOS_PARCIALES.Checked = IIf(dr("PAGOS_PARCIALES") = 1, True, False)
                    ChCOLUMNA_DESCUENTO.Checked = IIf(dr("COLUMNA_DESCUENTO") = 1, True, False)
                    ChSOLECCIONAR_SERIES.Checked = IIf(dr("SOLECCIONAR_SERIES") = 1, True, False)
                    ChTIEMPO_AIRE.Checked = IIf(dr("TIEMPO_AIRE") = 1, True, False)
                    ChPRECIOS.Checked = IIf(dr("PRECIOS") = 1, True, False)

                    ChOCULTAR_CRE_ENG.Checked = IIf(dr("OCULTAR_CRE_ENG") = 1, True, False)
                    ChOCULTAR_CREDITO.Checked = IIf(dr("OCULTAR_CREDITO") = 1, True, False)
                    ChNOVALIDAR_LIM_CRED.Checked = IIf(dr("NOVALIDAR_LIM_CRED") = 1, True, False)
                    ChPER_VEND_ABA_COST.Checked = IIf(dr("PER_VEND_ABA_COST") = 1, True, False)
                    ChPER_VEND_ABA_MIN.Checked = IIf(dr("PER_VEND_ABA_MIN") = 1, True, False)
                    ChART_CON_IMP_INCLU.Checked = IIf(dr("ART_CON_IMP_INCLU") = 1, True, False)
                    ChREIMPRIMIR_TICKET.Checked = IIf(dr("REIMPRIMIR_TICKET") = 1, True, False)

                    TCVE_VEND.Text = dr("CVE_VEND")
                    TDECIMALES.Value = dr("DECIMALES")
                    LISTA_PREC = dr("LISTA_PREC")
                    TCLIE_MOSTR.Text = dr("CLIENTE")

                End If
                dr.Close()

                For k = 0 To CboListaPrecPred.Items.Count - 1
                    If Convert.ToInt16(CboListaPrecPred.Items(k).ToString.Substring(0, 2)) = LISTA_PREC Then
                        CboListaPrecPred.SelectedIndex = k
                        Exit For
                    End If
                Next

                TESTACION.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmEstacionTrabAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
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

    Private Sub BtnVend_Click(sender As Object, e As EventArgs) Handles BtnVend.Click
        Try
            Var2 = "Vend"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_VEND.Text = Var4
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_VEND_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_VEND.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnVend_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_VEND_Validated(sender As Object, e As EventArgs) Handles TCVE_VEND.Validated
        Try
            If TCVE_VEND.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Vend", TCVE_VEND.Text)
                If DESCR <> "N" And DESCR <> "" Then
                Else
                    MsgBox("Vendedor inexistente")
                    TCVE_VEND.Text = ""
                    TCVE_VEND.SelectAll()
                    TCVE_VEND.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click

        SQL = "IF EXISTS (SELECT ESTACION FROM GCESTACIONES WHERE ESTACION = @ESTACION)
            UPDATE GCESTACIONES SET LECTORHUELLA = @LECTORHUELLA, IMP_NOTA = @IMP_NOTA, CVE_VEND = @CVE_VEND, PROMOCIONES = @PROMOCIONES,
            FLUJO = @FLUJO, MONEDERO = @MONEDERO, VENDER_SIN_EXIST = @VENDER_SIN_EXIST, DECIMALES = @DECIMALES,
            PRECIOS = @PRECIOS, PERMITE_DESC = @PERMITE_DESC, CLIENTE = @CLIENTE, AGREGAR_PROD = @AGREGAR_PROD, LISTA_PREC = @LISTA_PREC, 
            PAGOS_PARCIALES = @PAGOS_PARCIALES, COLUMNA_DESCUENTO = @COLUMNA_DESCUENTO, TIEMPO_AIRE = @TIEMPO_AIRE,
            OCULTAR_CRE_ENG = @OCULTAR_CRE_ENG, OCULTAR_CREDITO = @OCULTAR_CREDITO, NOVALIDAR_LIM_CRED = @NOVALIDAR_LIM_CRED, 
            PER_VEND_ABA_COST = @PER_VEND_ABA_COST, PER_VEND_ABA_MIN = @PER_VEND_ABA_MIN, ART_CON_IMP_INCLU = @ART_CON_IMP_INCLU,
            REIMPRIMIR_TICKET = @REIMPRIMIR_TICKET, AGREGAR_CLIENTE = @AGREGAR_CLIENTE
            WHERE ESTACION = @ESTACION
        ELSE
            INSERT INTO GCESTACIONES (ESTACION, LECTORHUELLA, IMP_NOTA, CVE_VEND, PROMOCIONES, FLUJO, MONEDERO, VENDER_SIN_EXIST, 
            DECIMALES, PRECIOS, PERMITE_DESC, CLIENTE, AGREGAR_PROD, LISTA_PREC, PAGOS_PARCIALES, COLUMNA_DESCUENTO, SOLECCIONAR_SERIES, 
            TIEMPO_AIRE, OCULTAR_CRE_ENG, OCULTAR_CREDITO, NOVALIDAR_LIM_CRED, PER_VEND_ABA_COST, PER_VEND_ABA_MIN, ART_CON_IMP_INCLU, 
            REIMPRIMIR_TICKET, AGREGAR_CLIENTE)
            VALUES(
            @ESTACION, @LECTORHUELLA, @IMP_NOTA, @CVE_VEND, @PROMOCIONES, @FLUJO, @MONEDERO, @VENDER_SIN_EXIST, @DECIMALES, 
            @PRECIOS, @PERMITE_DESC, @CLIENTE, @AGREGAR_PROD, @LISTA_PREC, @PAGOS_PARCIALES, @COLUMNA_DESCUENTO, @SOLECCIONAR_SERIES, 
            @TIEMPO_AIRE, @OCULTAR_CRE_ENG, @OCULTAR_CREDITO, @NOVALIDAR_LIM_CRED, @PER_VEND_ABA_COST, @PER_VEND_ABA_MIN, 
            @ART_CON_IMP_INCLU, @REIMPRIMIR_TICKET, @AGREGAR_CLIENTE)"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@ESTACION", SqlDbType.VarChar).Value = TESTACION.Text
                cmd.Parameters.Add("@LECTORHUELLA", SqlDbType.SmallInt).Value = IIf(ChLECTORHUELLA.Checked, 1, 0)
                cmd.Parameters.Add("@IMP_NOTA", SqlDbType.VarChar).Value = IIf(ChIMP_NOTA.Checked, 1, 0)
                cmd.Parameters.Add("@CVE_VEND", SqlDbType.VarChar).Value = TCVE_VEND.Text
                cmd.Parameters.Add("@PROMOCIONES", SqlDbType.SmallInt).Value = IIf(ChPROMOCIONES.Checked, 1, 0)
                cmd.Parameters.Add("@FLUJO", SqlDbType.SmallInt).Value = IIf(ChFLUJO.Checked, 1, 0)
                cmd.Parameters.Add("@MONEDERO", SqlDbType.SmallInt).Value = IIf(ChMONEDERO.Checked, 1, 0)
                cmd.Parameters.Add("@VENDER_SIN_EXIST", SqlDbType.SmallInt).Value = IIf(ChVENDER_SIN_EXIST.Checked, 1, 0)
                cmd.Parameters.Add("@DECIMALES", SqlDbType.SmallInt).Value = TDECIMALES.Value
                cmd.Parameters.Add("@PRECIOS", SqlDbType.SmallInt).Value = IIf(ChPRECIOS.Checked, 1, 0)
                cmd.Parameters.Add("@PERMITE_DESC", SqlDbType.SmallInt).Value = IIf(ChPERMITE_DESC.Checked, 1, 0)
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = TCLIE_MOSTR.Text
                cmd.Parameters.Add("@AGREGAR_PROD", SqlDbType.SmallInt).Value = IIf(ChAGREGAR_PROD.Checked, 1, 0)
                cmd.Parameters.Add("@LISTA_PREC", SqlDbType.SmallInt).Value = IIf(CboListaPrecPred.SelectedIndex = -1, 1, CboListaPrecPred.SelectedIndex + 1)
                cmd.Parameters.Add("@PAGOS_PARCIALES", SqlDbType.SmallInt).Value = IIf(ChPAGOS_PARCIALES.Checked, 1, 0)
                cmd.Parameters.Add("@COLUMNA_DESCUENTO", SqlDbType.SmallInt).Value = IIf(ChCOLUMNA_DESCUENTO.Checked, 1, 0)
                cmd.Parameters.Add("@SOLECCIONAR_SERIES", SqlDbType.SmallInt).Value = IIf(ChSOLECCIONAR_SERIES.Checked, 1, 0)
                cmd.Parameters.Add("@TIEMPO_AIRE", SqlDbType.SmallInt).Value = IIf(ChTIEMPO_AIRE.Checked, 1, 0)
                cmd.Parameters.Add("@OCULTAR_CRE_ENG", SqlDbType.SmallInt).Value = IIf(ChOCULTAR_CRE_ENG.Checked, 1, 0)
                cmd.Parameters.Add("@OCULTAR_CREDITO", SqlDbType.SmallInt).Value = IIf(ChOCULTAR_CREDITO.Checked, 1, 0)
                cmd.Parameters.Add("@NOVALIDAR_LIM_CRED", SqlDbType.SmallInt).Value = IIf(ChNOVALIDAR_LIM_CRED.Checked, 1, 0)
                cmd.Parameters.Add("@PER_VEND_ABA_COST", SqlDbType.SmallInt).Value = IIf(ChPER_VEND_ABA_COST.Checked, 1, 0)
                cmd.Parameters.Add("@PER_VEND_ABA_MIN", SqlDbType.SmallInt).Value = IIf(ChPER_VEND_ABA_MIN.Checked, 1, 0)
                cmd.Parameters.Add("@ART_CON_IMP_INCLU", SqlDbType.SmallInt).Value = IIf(ChART_CON_IMP_INCLU.Checked, 1, 0)
                cmd.Parameters.Add("@REIMPRIMIR_TICKET", SqlDbType.SmallInt).Value = IIf(ChREIMPRIMIR_TICKET.Checked, 1, 0)
                cmd.Parameters.Add("@AGREGAR_CLIENTE", SqlDbType.SmallInt).Value = IIf(ChAGREGAR_CLIENTE.Checked, 1, 0)

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("Los parámetros de la estación se grabaron correctamente")

                        Me.Close()
                    End If
                End If
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class