Imports System.ComponentModel
Imports System.Data.SqlClient

Public Class FrmParamInvent
    Private Sub FrmParamInvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BtnLinea.FlatStyle = FlatStyle.Flat
        BtnLinea.FlatAppearance.BorderSize = 0
        BtnLinValDecla.FlatStyle = FlatStyle.Flat
        BtnLinValDecla.FlatAppearance.BorderSize = 0
        BarTarifa.FlatStyle = FlatStyle.Flat
        BarTarifa.FlatAppearance.BorderSize = 0
        BtnCVE_ART_NC.FlatStyle = FlatStyle.Flat
        BtnCVE_ART_NC.FlatAppearance.BorderSize = 0
        BtnArtRbado.FlatStyle = FlatStyle.Flat
        BtnArtRbado.FlatAppearance.BorderSize = 0
        BtnArtRep.FlatStyle = FlatStyle.Flat
        BtnArtRep.FlatAppearance.BorderSize = 0
    End Sub
    Private Sub FrmParamInvent_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.WindowState = FormWindowState.Maximized
        '20 FEB 20
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            CboALM_CONSIGNA.Items.Clear()
            For k = 1 To 99
                CboALM_CONSIGNA.Items.Add(Format(k, "0"))
            Next

        Catch ex As Exception
        End Try
        Lt1.Visible = False
        CboCampLibCte.Visible = False

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ALM_CONSIGNA As Integer, CVE_CPTO As Integer = 0, CVE_CPTO_SAL As Integer = 0, CVE_CPTO_SAL_OPER As Integer = 0
            Dim ALM_RNBDO As Integer = 0, CVE_ART_RNBDO As String = "", ACTIVAR_RENOVADO As Int16, CVE_DESDE_CAMPLIBCTE As String = ""
            Dim CVE_CPTO_RENOVADO As Integer = 0, CVE_ART_REPARA As String = "", CVE_CPTO_RENOVADO_ENT As Integer = 0
            Dim CVE_CPTO_SAL_UNIDAD As Integer = 0

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(ALM_CONSIGNA,0) AS ALM_CON, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV,
                ISNULL(CVE_ART_TOT,'') AS CVE_TOT, ISNULL(CVE_CPTO_OT,0) AS CVE_CPTOOT, ISNULL(CVE_CPTO_OT_SAL,0) AS CVE_CPTOOTSAL,
                CVE_CPTO_SAL_OPER, ISNULL(CVE_ALM_RNBDO, -1) AS ALM_RBDO, ISNULL(CVE_ART_RNBDO,'') AS ART_RBDO, isnull(ACTIVAR_RENOVADO,0) AS ACT_REN,
                ISNULL(CVE_ART_NUEVAS,'') AS CVE_ART_NEW, ISNULL(CVE_CPTO_RENOVADO,0) AS CPTO_REN, ISNULL(CVE_ART_REPARA,'') AS ART_REPARA, 
                ISNULL(CVE_CPTO_RENOVADO_ENT,0) AS CVE_CPTO_REN_ENT, ISNULL(LINEA_VALOR_DECLA,'') AS LINEA_VAL_DEC, CVE_CPTO_SAL_UNIDAD,
                ISNULL(CVE_ART_TARIFA,'') AS TARIFA, ISNULL(CVE_ART_NC,'') AS CVEARTNC, ISNULL(CVE_D_CAMPLIBCTE,0) AS C_D_CAMPLIBCTE,
                ISNULL(LIB_CLIENTE,'') AS L_CLIENTE, ISNULL(LINEA_TAB_RUTAS,'') AS LIN_TAB_RUT
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                Try
                    ChMULTIALMACEN.Value = dr("M_ULTIALMACEN")
                    ALM_CONSIGNA = dr("ALM_CON")
                    TLIN_PROD.Text = dr("CVE_TOT")

                    LtLinea.Text = BUSCA_CAT("Linea", TLIN_PROD.Text)
                    ChAfecTablaInve.Value = dr("AFE_TAB_INV")
                    CVE_CPTO = dr("CVE_CPTOOT")
                    CVE_CPTO_SAL = dr("CVE_CPTOOTSAL")
                    CVE_CPTO_SAL_OPER = dr.ReadNullAsEmptyInteger("CVE_CPTO_SAL_OPER")
                    CVE_CPTO_SAL_UNIDAD = dr.ReadNullAsEmptyInteger("CVE_CPTO_SAL_UNIDAD")

                    ALM_RNBDO = dr("ALM_RBDO")
                    CVE_ART_RNBDO = dr("ART_RBDO")
                    CVE_ART_REPARA = dr("ART_REPARA")

                    CVE_CPTO_RENOVADO = dr("CPTO_REN")
                    CVE_CPTO_RENOVADO_ENT = dr("CVE_CPTO_REN_ENT")

                    ACTIVAR_RENOVADO = dr("ACT_REN")
                    TLINEA_VALOR_DECLA.Text = dr("LINEA_VAL_DEC")

                    TCVE_ART_TARIFA.Text = dr("TARIFA")
                    LtTarifa.Text = BUSCA_CAT("Inven", TCVE_ART_TARIFA.Text)
                    TCVE_ART_NC.Text = dr("CVEARTNC")
                    LtArticuloNC.Text = BUSCA_CAT("Inven", TCVE_ART_NC.Text)
                    If dr("C_D_CAMPLIBCTE") = 1 Then
                        ChClaveDesdeCamLibCte.Checked = True
                        CVE_DESDE_CAMPLIBCTE = dr("L_CLIENTE")
                        Lt1.Visible = True
                        CboCampLibCte.Visible = True
                    Else
                        CVE_DESDE_CAMPLIBCTE = ""
                    End If
                    TLINEA_TAB_RUTAS.Text = dr("LIN_TAB_RUT")
                Catch ex As Exception
                    Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            dr.Close()


            Try
                SQL = "SELECT NUM_EMP, IDTABLA, CAMPO, ETIQUETA FROM dbo.PARAM_CAMPOSLIBRES" & Empresa & " WHERE IDTABLA = 'CLIE_CLIB'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                Do While dr.Read
                    CboCampLibCte.Items.Add(dr("CAMPO"))
                Loop
                dr.Close()
            Catch Ex As Exception
                Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
                MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            End Try

            If ChClaveDesdeCamLibCte.Checked Then
                If CVE_DESDE_CAMPLIBCTE.Trim.Length > 0 Then
                    For k = 0 To CboCampLibCte.Items.Count - 1
                        If CboCampLibCte.Items(k).ToString = CVE_DESDE_CAMPLIBCTE Then
                            CboCampLibCte.SelectedIndex = k
                            Exit For
                        End If
                    Next
                End If
            End If

            If CVE_ART_RNBDO.Trim.Length > 0 Then
                L3.Text = BUSCA_CAT("InveS", CVE_ART_RNBDO)
            End If

            If CVE_ART_RNBDO.Trim.Length > 0 Then
                L3.Text = BUSCA_CAT("InveS", CVE_ART_RNBDO)
            End If

            TCVE_ART_RNBDO.Text = CVE_ART_RNBDO
            TCVE_ART_REPARA.Text = CVE_ART_REPARA

            If CVE_ART_RNBDO.Trim.Length > 0 Then
                LtDescrRep.Text = BUSCA_CAT("InveS", CVE_ART_REPARA)
            End If

            For k = 0 To CboALM_CONSIGNA.Items.Count - 1
                If Val(CboALM_CONSIGNA.Items(k).ToString) = ALM_CONSIGNA Then
                    CboALM_CONSIGNA.SelectedIndex = k
                    Exit For
                End If
            Next

            CboCveCptoOT.Items.Clear()
            CboCveCptoOTSAL.Items.Clear()
            CboCveCptoOper.Items.Clear()
            CboCpto_renovado_salida.Items.Clear()
            CboCpto_renovado_entrada.Items.Clear()

            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CPTO, DESCR, CPN, CUEN_CONT, ISNULL(TIPO_MOV,'') AS T_MOV, STATUS, SIGNO FROM CONM" & Empresa & " WHERE STATUS = 'A'"
                cmd2.CommandText = SQL
                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                    While dr2.Read
                        If dr2("T_MOV") = "S" Then
                            CboCveCptoOTSAL.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                            CboCveCptoOper.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                            CboCpto_renovado_salida.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                            CboCVE_CPTO_SAL_UNIDAD.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                        Else
                            CboCveCptoOT.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                            CboCpto_renovado_entrada.Items.Add(dr2("CVE_CPTO") & " " & dr2("DESCR"))
                        End If
                    End While
                End Using
            End Using
            For k = 0 To CboCpto_renovado_salida.Items.Count - 1
                If Val(CboCpto_renovado_salida.Items(k).ToString.Substring(0, 2)) = CVE_CPTO_RENOVADO Then
                    CboCpto_renovado_salida.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboCpto_renovado_entrada.Items.Count - 1
                If Val(CboCpto_renovado_entrada.Items(k).ToString.Substring(0, 2)) = CVE_CPTO_RENOVADO_ENT Then
                    CboCpto_renovado_entrada.SelectedIndex = k
                    Exit For
                End If
            Next

            For k = 0 To CboCveCptoOT.Items.Count - 1
                If Val(CboCveCptoOT.Items(k).ToString.Substring(0, 2)) = CVE_CPTO Then
                    CboCveCptoOT.SelectedIndex = k
                    Exit For
                End If
            Next

            For k = 0 To CboCveCptoOTSAL.Items.Count - 1
                If Val(CboCveCptoOTSAL.Items(k).ToString.Substring(0, 2)) = CVE_CPTO_SAL Then
                    CboCveCptoOTSAL.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboCveCptoOper.Items.Count - 1
                If Val(CboCveCptoOper.Items(k).ToString.Substring(0, 2)) = CVE_CPTO_SAL_OPER Then
                    CboCveCptoOper.SelectedIndex = k
                    Exit For
                End If
            Next
            For k = 0 To CboCVE_CPTO_SAL_UNIDAD.Items.Count - 1
                If Val(CboCVE_CPTO_SAL_UNIDAD.Items(k).ToString.Substring(0, 2)) = CVE_CPTO_SAL_UNIDAD Then
                    CboCVE_CPTO_SAL_UNIDAD.SelectedIndex = k
                    Exit For
                End If
            Next
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            C1List1.ShowHeaderCheckBox = True
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE STATUS = 'A'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        C1List1.AddItem(dr("CVE_ALM") & ";" & dr("DESCR"))
                    End While
                End Using
            End Using
            C1List1.Splits(0).DisplayColumns(0).Width = 50

            For row As Integer = 0 To C1List1.ListCount - 1
                Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                SQL = "SELECT * FROM GCLLANTAS_ALMACENES WHERE NUM_ALM = " & cellValue & " AND TIPO_LLANTA = 'RENOVADO'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            C1List1.SetSelected(row, True)
                        End If
                    End Using
                End Using
            Next

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
        Try
            Dim ALM_CONS As Integer = 0, CVE_CPTO As Integer = 0, CVE_CPTO_SAL As Integer = 0, CVE_CPTO_SAL_OPER As Integer = 0, z As Integer
            Dim CVE_CPTO_RENOVADO As Integer, CVE_CPTO_RENOVADO_ENT As Integer, CVE_CPTO_SAL_UNIDAD As Integer, LIB_CLIENTE As String

            If ChClaveDesdeCamLibCte.Checked Then
                If CboCampLibCte.SelectedIndex = -1 Then
                    MsgBox("Por favor seleccione un campo libre")
                    Return
                End If
                LIB_CLIENTE = CboCampLibCte.Text
            Else
                LIB_CLIENTE = ""
            End If

            z = 0
            If TCVE_ART_RNBDO.Text.Trim.Length > 0 Then
                For row As Integer = 0 To C1List1.ListCount - 1
                    Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                    If C1List1.GetSelected(row) Then
                        z += 1
                    End If
                Next
                If z = 0 Then
                    MsgBox("Por favor seleccione el almacén(es) de llantas renovado")
                    Return
                End If
            End If
            Try
                If CboALM_CONSIGNA.SelectedIndex = -1 Then
                    ALM_CONS = 0
                Else
                    ALM_CONS = CboALM_CONSIGNA.Items(CboALM_CONSIGNA.SelectedIndex)
                End If
            Catch ex As Exception
                Bitacora("208. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboCveCptoOT.SelectedIndex = -1 Then
                    CVE_CPTO = 0
                Else
                    CVE_CPTO = Val(CboCveCptoOT.Items(CboCveCptoOT.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("209. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboCveCptoOTSAL.SelectedIndex = -1 Then
                    CVE_CPTO_SAL = 0
                Else
                    CVE_CPTO_SAL = Val(CboCveCptoOTSAL.Items(CboCveCptoOTSAL.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("210. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboCveCptoOper.SelectedIndex = -1 Then
                    CVE_CPTO_SAL_OPER = 0
                Else
                    CVE_CPTO_SAL_OPER = Val(CboCveCptoOper.Items(CboCveCptoOper.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("211. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboCpto_renovado_salida.SelectedIndex = -1 Then
                    CVE_CPTO_RENOVADO = 0
                Else
                    CVE_CPTO_RENOVADO = Val(CboCpto_renovado_salida.Items(CboCpto_renovado_salida.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("211. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            Try
                If CboCpto_renovado_entrada.SelectedIndex = -1 Then
                    CVE_CPTO_RENOVADO_ENT = 0
                Else
                    CVE_CPTO_RENOVADO_ENT = Val(CboCpto_renovado_entrada.Items(CboCpto_renovado_entrada.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("211. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                If CboCVE_CPTO_SAL_UNIDAD.SelectedIndex = -1 Then
                    CVE_CPTO_SAL_UNIDAD = 0
                Else
                    CVE_CPTO_SAL_UNIDAD = Val(CboCVE_CPTO_SAL_UNIDAD.Items(CboCVE_CPTO_SAL_UNIDAD.SelectedIndex).Substring(0, 2))
                End If
            Catch ex As Exception
                Bitacora("211. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            MULTIALMACEN = IIf(ChMULTIALMACEN.Value, 1, 0)
            AFEC_TABLA_INVE = IIf(ChAfecTablaInve.Checked, 1, 0)


            SQL = "UPDATE GCPARAMINVENT SET MULTIALMACEN = " & MULTIALMACEN & ", CVE_ART_TOT = '" & TLIN_PROD.Text & "', ALM_CONSIGNA = " & ALM_CONS & ", 
                AFEC_TABLA_INVE = " & AFEC_TABLA_INVE & ", CVE_CPTO_OT = " & CVE_CPTO & ", CVE_CPTO_OT_SAL = " & CVE_CPTO_SAL & ",
                CVE_CPTO_SAL_OPER =  " & CVE_CPTO_SAL_OPER & ", CVE_ART_RNBDO = '" & TCVE_ART_RNBDO.Text & "', CVE_ART_REPARA = '" & TCVE_ART_REPARA.Text & "', 
                CVE_CPTO_RENOVADO = " & CVE_CPTO_RENOVADO & ", CVE_CPTO_RENOVADO_ENT = " & CVE_CPTO_RENOVADO_ENT & ", 
                LINEA_VALOR_DECLA = '" & TLINEA_VALOR_DECLA.Text & "', CVE_CPTO_SAL_UNIDAD = " & CVE_CPTO_SAL_UNIDAD & ", 
                CVE_ART_TARIFA = '" & TCVE_ART_TARIFA.Text & "', CVE_ART_NC = '" & TCVE_ART_NC.Text & "',
                CVE_D_CAMPLIBCTE = " & IIf(ChClaveDesdeCamLibCte.Checked, 1, 0) & ", LIB_CLIENTE = '" & LIB_CLIENTE & "', 
                LINEA_TAB_RUTAS = '" & TLINEA_TAB_RUTAS.Text & "'"

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
                Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Try
                SQL = "TRUNCATE TABLE GCLLANTAS_ALMACENES"

                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using

                For row As Integer = 0 To C1List1.ListCount - 1
                    Dim cellValue As Object = C1List1.GetDisplayText(row, 0)
                    Dim cellValue1 As Object = C1List1.GetDisplayText(row, 1)

                    If C1List1.GetSelected(row) Then
                        SQL = "INSERT INTO GCLLANTAS_ALMACENES (TIPO_LLANTA, NUM_ALM, UUID) VALUES ('RENOVADO','" & cellValue & "',NEWID())"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    End If
                Next
            Catch ex As Exception
                Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            MsgBox("Los datos se grabaron satisfactoriamente")

            Me.Close()
        Catch ex As Exception
            Bitacora("207. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("207. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub FrmParamInvent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab2("Configuración inventario")
        Me.Dispose()
    End Sub

    Private Sub FrmParamInvent_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLIN_PROD.Text = Var4
                LtLinea.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                CboCveCptoOTSAL.Focus()
            End If

        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TLIN_PROD_KeyDown(sender As Object, e As KeyEventArgs) Handles TLIN_PROD.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnLinea_Click(Nothing, Nothing)
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
    Private Sub BtnArtRbado_Click(sender As Object, e As EventArgs) Handles BtnArtRbado.Click
        Try
            Var2 = "Servicios"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_RNBDO.Text = Var4
                L3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_RNBDO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_RNBDO.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArtRbado_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART_RNBDO_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_RNBDO.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("InveS", TCVE_ART_RNBDO.Text)
            If DESCR <> "" Then
                L3.Text = DESCR
            Else
                MsgBox("La clave del servicio no existe en el catálogo")
                TCVE_ART_RNBDO.SelectAll()
                TCVE_ART_RNBDO.Select()
                L3.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnArtRep_Click(sender As Object, e As EventArgs) Handles BtnArtRep.Click
        Try
            Var2 = "Servicios"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_REPARA.Text = Var4
                LtDescrRep.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_REPARA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_REPARA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnArtRbado_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART_REPARA_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_REPARA.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("InveS", TCVE_ART_REPARA.Text)
            If DESCR <> "" Then
                LtDescrRep.Text = DESCR
            Else
                MsgBox("La clave del servicio no existe en el catálogo")
                TCVE_ART_REPARA.SelectAll()
                TCVE_ART_REPARA.Select()
                LtDescrRep.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnLinValDecla_Click(sender As Object, e As EventArgs) Handles BtnLinValDecla.Click
        Try
            Var2 = "Lineas"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLINEA_VALOR_DECLA.Text = Var4
                LtLineaValDecla.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLINEA_VALOR_DECLA_KeyDown(sender As Object, e As KeyEventArgs) Handles TLINEA_VALOR_DECLA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnLinea_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLINEA_VALOR_DECLA_Validated(sender As Object, e As EventArgs) Handles TLINEA_VALOR_DECLA.Validated
        Try
            If TLINEA_VALOR_DECLA.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLINEA_VALOR_DECLA.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLINEA_VALOR_DECLA.Text = ""
                    TLINEA_VALOR_DECLA.Select()
                Else
                    LtLineaValDecla.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarTarifa_Click(sender As Object, e As EventArgs) Handles BarTarifa.Click
        Try
            Var2 = "Articulo"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_TARIFA.Text = Var4
                LtTarifa.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART_TARIFA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_TARIFA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BarTarifa_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCVE_ART_TARIFA_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_TARIFA.Validated
        Try
            Dim DESCR As String
            DESCR = BUSCA_CAT("Inven", TCVE_ART_TARIFA.Text)
            If DESCR <> "" Then
                LtTarifa.Text = DESCR
            Else
                MsgBox("La clave del articulo no existe en el catálogo")
                TCVE_ART_TARIFA.SelectAll()
                TCVE_ART_TARIFA.Select()
                LtTarifa.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnCVE_ART_NC_Click(sender As Object, e As EventArgs) Handles BtnCVE_ART_NC.Click
        Try
            Var2 = "Articulo"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ART_NC.Text = Var4
                LtArticuloNC.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ART_NC_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ART_NC.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCVE_ART_NC_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_ART_NC_Validated(sender As Object, e As EventArgs) Handles TCVE_ART_NC.Validated
        Try
            If TCVE_ART_NC.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Inven", TCVE_ART_NC.Text)
                If DESCR <> "" Then
                    LtArticuloNC.Text = DESCR
                Else
                    MsgBox("La clave del articulo no existe en el catálogo")
                    TCVE_ART_NC.SelectAll()
                    TCVE_ART_NC.Select()
                    LtArticuloNC.Text = ""
                End If
            Else
                LtArticuloNC.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MessageBox.Show("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ChClaveDesdeCamLibCte_CheckedChanged(sender As Object, e As EventArgs) Handles ChClaveDesdeCamLibCte.CheckedChanged
        Try
            If ChClaveDesdeCamLibCte.Checked Then
                Lt1.Visible = True
                CboCampLibCte.Visible = True
            Else
                Lt1.Visible = False
                CboCampLibCte.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnLineaTabRuta_Click(sender As Object, e As EventArgs) Handles BtnLineaTabRuta.Click
        Try
            Var2 = "Lineas"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLINEA_TAB_RUTAS.Text = Var4
                LtLineaTabRutas.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
            End If
        Catch ex As Exception
            MsgBox("190. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TLINEA_TAB_RUTAS_KeyDown(sender As Object, e As KeyEventArgs) Handles TLINEA_TAB_RUTAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnLinea_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TLINEA_TAB_RUTAS_Validated(sender As Object, e As EventArgs) Handles TLINEA_TAB_RUTAS.Validated
        Try
            If TLINEA_TAB_RUTAS.Text.Trim.Length > 0 Then
                Dim CADENA As String

                CADENA = BUSCA_CAT("Linea", TLINEA_TAB_RUTAS.Text)
                If CADENA = "" Or CADENA = "N" Then
                    MsgBox("Linea inexistente")
                    TLINEA_TAB_RUTAS.Text = ""
                    TLINEA_TAB_RUTAS.Select()
                Else
                    LtLineaTabRutas.Text = CADENA
                End If
            End If
        Catch ex As Exception
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
