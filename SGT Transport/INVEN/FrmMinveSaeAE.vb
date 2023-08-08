Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMinveSaeAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private ALM_CONSIGNA As Integer
    Private CVE_CPTO_SAL_OPER As Integer = 0
    Private CVE_CPTO_OT_SAL As Integer = 0
    Private CVE_CPTO_SAL_UNIDAD As Integer = 0
    Private _myEditor As MyEditorMinve
    Private CPN As String

    Private Key_Pres As Integer
    Private Sub frmMinveSaeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG
        Catch ex As Exception
        End Try
        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")

        Me.CenterToScreen()
        Dim z As Integer

        Try
            If PASS_GRUPOCE.ToUpper = "TAIS920" Or PASS_GRUPOCE.ToUpper = "BUS" Then
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & k
                Next
            End If
            AssignValidation(tNUM_CPTO, ValidationType.Only_Numbers)
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(ALM_CONSIGNA,0) AS ALM_CON, CVE_CPTO_SAL_OPER, CVE_CPTO_OT_SAL, 
                CVE_CPTO_SAL_UNIDAD
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                ALM_CONSIGNA = dr("ALM_CON")

                CVE_CPTO_OT_SAL = dr.ReadNullAsEmptyInteger("CVE_CPTO_OT_SAL")
                CVE_CPTO_SAL_OPER = dr.ReadNullAsEmptyInteger("CVE_CPTO_SAL_OPER")
                CVE_CPTO_SAL_UNIDAD = dr.ReadNullAsEmptyInteger("CVE_CPTO_SAL_UNIDAD")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Key_Pres = 0
        REMOVE_ROW = 0

        ENTRA = False
        ENTRA_KEY = False
        ENTRA_BTN = False

        cboAlmacen.Items.Clear()
        tNUM_CPTO.Text = ""
        tREFER.Text = ""
        tCVE_PROV.Text = ""
        LtMec.Tag = ""
        Fg.Rows.Count = 1

        If MULTIALMACEN = 1 Then
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT * FROM ALMACENES" & Empresa & " WHERE CVE_ALM <> 1 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                z = 0
                Do While dr.Read
                    cboAlmacen.Items.Add(New ValueDescriptionPair(dr("CVE_ALM"), dr("CVE_ALM") & " " & dr("DESCR"), dr("CVE_ALM"), "", z))
                    z = z + 1
                Loop
                dr.Close()
                cboAlmacen.SelectedIndex = 0

            Catch ex As Exception
                Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            cboAlmacen.Visible = False
            Label10.Visible = False
            z = 0
            cboAlmacen.Items.Add(New ValueDescriptionPair(1, 1 & " ALMACEN", 1, "", z))
        End If

        Try
            Fg.Rows.Count = 1
            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
            Fg.Row = 1
            Fg.Col = 1
            ENTRA = True

        Catch ex As Exception
            Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            _myEditor = New MyEditorMinve(Fg, MULTIALMACEN)
            _myEditor.StartEditing(Fg.Row, 1)

            tNUM_CPTO.Select()
        Catch ex As Exception
            Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA = True
        ENTRA_KEY = True
        ENTRA_BTN = True

    End Sub

    Private Sub frmMinveSaeAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            Me.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If
        Dim CVE_DOC As String, CVE_ART As String, CVE_CLPV As String = "", CANT As Decimal, CVE_CPTO As Integer, TIPO_DOC As String, VEND As String
        Dim PREC As Single, COSTO As Single, FACTOR_CON As Single, SIGNO As Integer, COSTEADO As String, DESDE_INVE As String, MOV_ENLAZADO As Integer
        Dim E_LTPD As Long, UNI_VENTA As String, REG_SERIE As Long, TIPO_PROD As String, CVE_ALM As Integer, Exis As Boolean, j As Integer
        Dim CVE_OBS As Long, EXIST As Single, Enc_Error As Boolean = False, SIGUE As Boolean = False


        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If tNUM_CPTO.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un Concepto")
            Return
        End If

        If tREFER.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el documento")
            Return
        End If
        CVE_DOC = tREFER.Text

        If LMec.Text = "Unidad" Then
            CVE_CLPV = LtMec.Tag
        Else
            CVE_CLPV = tCVE_PROV.Text
        End If

        If MULTIALMACEN = 1 Then
            If MsgBox("¿Realmente desea generar el movimiento al inventario?", vbYesNo) = vbNo Then
                Return
            End If

        End If

        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Red
        NewStyle1.ForeColor = Color.White

        ENTRA = False

        CVE_ALM = 1 : TIPO_DOC = "M" : VEND = "" : UNI_VENTA = "" : TIPO_PROD = "P"
        COSTEADO = "S" : DESDE_INVE = "S" : FACTOR_CON = 1 : PREC = 0 : j = 0

        Try
            If MULTIALMACEN = 1 Then
                If cboAlmacen.SelectedIndex = -1 Then
                    CVE_ALM = 1
                Else
                    CVE_ALM = CType(cboAlmacen.SelectedItem, ValueDescriptionPair).ClavePair
                End If
            Else
                CVE_ALM = 1
            End If

        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Enc_Error = True
        End Try

        cmd.Connection = cnSAE

        Try
            Exis = False
            SQL = "SELECT SIGNO FROM CONM" & Empresa & " WHERE CVE_CPTO = " & tNUM_CPTO.Text
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                SIGNO = dr("SIGNO")
                Exis = True
            End If
            dr.Close()

            If Not Exis Then
                MsgBox("Concepto inexistente verifique por favor")
                ENTRA = True
                Return
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Enc_Error = True
        End Try

        Try
            Exis = False
            SQL = "SELECT REFER FROM MINVE" & Empresa & " WHERE REFER = '" & CVE_DOC & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                Exis = True
            End If
            dr.Close()

            If Exis Then
                MsgBox("Lo siento este documento existe, verifique por favor")
                ENTRA = True
                Return
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
            Enc_Error = True
        End Try

        If Enc_Error Then
            MsgBox("Problema detectado intentelo nuevamente")
            Return
        End If

        CVE_CPTO = tNUM_CPTO.Text
        Dim EXIST_OK As Boolean = False

        If SIGNO = -1 Then
            Try
                For k = 1 To Fg.Rows.Count - 1

                    CVE_ART = Fg(k, 2)
                    Try
                        If IsNumeric(Fg(k, 1)) Then
                            CANT = Fg(k, 1)
                        Else
                            CANT = 0
                        End If
                    Catch ex As Exception
                        CANT = 0
                    End Try
                    If Not Valida_Conexion() Then
                    End If

                    If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                        If MULTIALMACEN = 1 Then
                            Try
                                SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM  = " & CVE_ALM
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            EXIST = dr2("EXIST")
                                        End If
                                    End Using
                                End Using

                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Else
                            Try
                                SQL = "SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                        If dr2.Read Then
                                            EXIST = dr2("EXIST")
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If

                        If EXIST >= CANT Then
                            EXIST_OK = True
                        Else
                            Try
                                Fg(k, 0) = "EI"
                                Fg.Rows(k).Style = NewStyle1
                            Catch ex As Exception
                                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    Else
                        'NO SE ENCONTRAON PARTIDAS A PROCESAR
                    End If
                Next

                If Not EXIST_OK Then
                    MsgBox("En algunas partidas la existencia es insuficiente, verifique por favor")
                    ENTRA = True
                    Return
                End If
            Catch ex As Exception
                Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If


        For k = 1 To Fg.Rows.Count - 1
            Try
                CVE_ART = Fg(k, 2)
                COSTO = Fg(k, 5)
                UNI_VENTA = Fg(k, 7)

                Try
                    If IsNumeric(Fg(k, 1)) Then
                        CANT = Fg(k, 1)
                    Else
                        CANT = 0
                    End If
                Catch ex As Exception
                    CANT = 0
                End Try

                If CANT > 0 And CVE_ART.Trim.Length > 0 Then
                    If MULTIALMACEN = 1 Then
                        Try
                            SQL = "SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM  = " & CVE_ALM
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                    End If
                                End Using
                            End Using

                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    Else
                        Try
                            SQL = "SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr2 As SqlDataReader = cmd2.ExecuteReader
                                    If dr2.Read Then
                                        EXIST = dr2("EXIST")
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If

                    If SIGNO = -1 Then
                        If EXIST >= CANT Then
                            SIGUE = True
                        Else
                            SIGUE = False
                        End If
                    Else
                        SIGUE = True
                    End If

                    If SIGUE Then
                        EXIST_OK = True
                        j = j + 1
                        If Valida_Conexion() Then
                            Try
                                If MULTIALMACEN = 1 Then
                                    SQL = "UPDATE MULT" & Empresa & " SET EXIST = COALESCE(EXIST,0) + " & (CANT * SIGNO) &
                                        " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & CVE_ALM &
                                        " If @@ROWCOUNT = 0 " &
                                        "INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, " &
                                        "COMP_X_REC, UUID, VERSION_SINC) VALUES('" & CVE_ART & "','" & CVE_ALM & "','A','','" &
                                        (CANT * SIGNO) & "', 0, 0, 0, NEWID(), GETDATE())"

                                    cmd.CommandText = SQL
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                MsgBox("130. " & ex.Message & vbNewLine & ex.StackTrace)
                                Bitacora("130. " & ex.Message & vbNewLine & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                SQL = "UPDATE INVE" & Empresa & " SET EXIST = ISNULL(EXIST,0) + " & (CANT * SIGNO) & ", ULT_COSTO = " & COSTO & ", " & "
                                    COSTO_PROM = " & COSTO & " WHERE CVE_ART = '" & CVE_ART & "'"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                            Try
                                If Fg(k, 8).ToString.Trim.Length > 0 Then
                                    CVE_OBS = INSERT_OBS_MINVE(Fg(k, 8))
                                Else
                                    CVE_OBS = 0
                                End If

                                If IsNothing(F1.Value) Then
                                    F1.Value = Now
                                End If
                                If IsDBNull(F1.Value) Then
                                    F1.Value = Now
                                End If
                            Catch ex As Exception
                                Bitacora("140. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("140. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                SQL = "INSERT INTO MINVE" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, VEND,
                                   CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, CVE_OBS, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON, FECHAELAB,
                                   CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" &
                                   CVE_ART & "','" & CVE_ALM & "',(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM MINVE" & Empresa & "),'" & CVE_CPTO &
                                   "','" & FSQL(F1.Value) & "','" & TIPO_DOC & "','" & CVE_DOC & "','" & CVE_CLPV & "','" & VEND & "','" &
                                   CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & CVE_OBS & "','" & UNI_VENTA & "','" & E_LTPD & "',"
                                SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                                If MULTIALMACEN = 1 Then
                                    SQL = SQL & "ISNULL((SELECT EXIST FROM MULT" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & CVE_ALM & "),0),'"
                                Else
                                    SQL = SQL & "(SELECT EXIST FROM INVE" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                                End If
                                SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ISNULL(ULT_CVE,0) + 1  FROM TBLCONTROL" & Empresa & " WHERE ID_TABLA = 32),'" &
                                              SIGNO & "','" & COSTEADO & "','" & COSTO & "','" & COSTO & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO & "')"
                                cmd.CommandText = SQL
                                returnValue = cmd.ExecuteNonQuery.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("150. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("150. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    Else
                        EXIST_OK = False
                    End If
                End If
            Catch ex As Exception
                Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        If SIGNO = -1 Then
            If Not EXIST_OK Then
                MsgBox("En algunas partidas la existencia es insuficiente, verifique por favor")
            End If
        End If

        If j > 0 Then
            Try
                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                SQL = "UPDATE TBLCONTROL" & Empresa & " SET ULT_CVE = (SELECT ISNULL(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery.ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If

                ImprimirReporte(CVE_DOC)

                LIMPIAR()

            Catch ex As Exception
                Bitacora("705. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("170. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            MsgBox("---------- No se realizaron movimientos al inventario --------------")
        End If

        ENTRA = True
    End Sub
    Sub LIMPIAR()
        Try
            tNUM_CPTO.Text = ""
            L1.Text = ""
            tREFER.Text = ""
            tCVE_PROV.Text = ""
            LtMec.Text = ""
            L2.Text = ""
            Fg.Rows.Count = 1

            barAgregar_Click(Nothing, Nothing)

            tNUM_CPTO.Select()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub barAgregar_Click(sender As Object, e As EventArgs) Handles barAgregar.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 2).ToString.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
            End If
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            _myEditor.StartEditing(Fg.Row, 1)

        Catch ex As Exception
            MsgBox("180. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("180. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("¿Ralmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                    Fg.RemoveItem(Fg.Row)
                End If
            End If
        Catch ex As Exception
            Bitacora("190. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub barReimprimir_Click(sender As Object, e As EventArgs) Handles barReimprimir.Click
        Try
            ImprimirReporte(tREFER.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub
    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "CONM"
            Var4 = ""
            Var5 = ""
            CPN = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                CPN = Var6

                L1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                LMec.Visible = True
                LtMec.Visible = True
                tCVE_PROV.Visible = True
                Label9.Visible = True
                btnProv.Visible = True
                If CInt(tNUM_CPTO.Text) = CVE_CPTO_OT_SAL Then
                    LMec.Text = "Mecánico"
                Else
                    If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_OPER Then
                        LMec.Text = "Operador"
                    Else
                        If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_UNIDAD Then
                            LMec.Text = "Unidad"
                        Else
                            If CPN = "C" Then
                                LMec.Text = "Cliente"
                            Else
                                If CPN = "P" Then
                                    LMec.Text = "Proveedor"
                                Else
                                    LMec.Text = "Proveedor"
                                    LMec.Visible = False
                                    LtMec.Visible = False
                                    tCVE_PROV.Visible = False
                                    Label9.Visible = False
                                    btnProv.Visible = False
                                End If
                            End If
                        End If
                    End If
                End If

                tCVE_PROV.Text = ""
                LtMec.Text = ""

                tREFER.Select()
            End If

        Catch Ex As Exception
            MsgBox("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("200. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNumCpto_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            tREFER.Select()
        End If
    End Sub
    Private Sub tNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles tNUM_CPTO.Validated
        Try
            If tNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("CONM", tNUM_CPTO.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR

                    LMec.Visible = True
                    LtMec.Visible = True
                    tCVE_PROV.Visible = True
                    Label9.Visible = True
                    btnProv.Visible = True
                    If CInt(tNUM_CPTO.Text) = CVE_CPTO_OT_SAL Then
                        LMec.Text = "Mecánico"
                    Else
                        If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_OPER Then
                            LMec.Text = "Operador"
                        Else
                            If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_UNIDAD Then
                                LMec.Text = "Unidad"
                            Else
                                If CPN = "C" Then
                                    LMec.Text = "Cliente"
                                Else
                                    If CPN = "P" Then
                                        LMec.Text = "Proveedor"
                                    Else
                                        LMec.Text = "Proveedor"
                                        LMec.Visible = False
                                        LtMec.Visible = False
                                        tCVE_PROV.Visible = False
                                        Label9.Visible = False
                                        btnProv.Visible = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                    tCVE_PROV.Text = ""
                    LtMec.Text = ""
                Else
                    MsgBox("Concepto inexistente")
                    tCVE_PROV.Text = ""
                    LtMec.Text = ""
                    tNUM_CPTO.Text = ""
                    tNUM_CPTO.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox("220. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("220. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            If CInt(tNUM_CPTO.Text) = CVE_CPTO_OT_SAL Then
                Var2 = "Mecanicos"
            Else
                If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_OPER Then
                    Var2 = "Operador"
                Else
                    If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_UNIDAD Then
                        Var2 = "Unidad"
                    Else
                        If CPN = "C" Then
                            Var2 = "Clientes"
                        Else
                            If CPN = "P" Then
                                Var2 = "Prov"
                            End If
                        End If
                    End If
                End If
            End If
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                LtMec.Tag = Var3
                LtMec.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                barAgregar_Click(Nothing, Nothing)
            End If
        Catch Ex As Exception
            MsgBox("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("230. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If CInt(tNUM_CPTO.Text) = CVE_CPTO_OT_SAL Then
                    Var2 = "Mecanicos"
                    If Not IsNumeric(tCVE_PROV.Text) Then
                        MsgBox("Por favor la clave del mecanico debe ser numérica ó realice la busqueda con el boton buscar o con F2")
                        tCVE_PROV.Text = ""
                        Return
                    End If
                Else
                    If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_OPER Then
                        Var2 = "Operador"
                        If Not IsNumeric(tCVE_PROV.Text) Then
                            MsgBox("Por favor la clave del operador debe ser numérica ó realice la busqueda con el boton buscar o con F2")
                            tCVE_PROV.Text = ""
                            Return
                        End If
                    Else
                        If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_UNIDAD Then
                            Var2 = "Unidad"
                        Else
                            If CPN = "C" Then
                                Var2 = "Cliente"
                                If IsNumeric(tCVE_PROV.Text) Then
                                    tCVE_PROV.Text = Space(10 - tCVE_PROV.Text.Trim.Length) & tCVE_PROV.Text.Trim
                                End If
                            Else
                                If CPN = "P" Then
                                    Var2 = "Prov"
                                    If IsNumeric(tCVE_PROV.Text) Then
                                        tCVE_PROV.Text = Space(10 - tCVE_PROV.Text.Trim.Length) & tCVE_PROV.Text.Trim
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                DESCR = BUSCA_CAT(Var2, tCVE_PROV.Text)
                If DESCR <> "" Then
                    LtMec.Tag = Var4
                    LtMec.Text = DESCR
                Else
                    If CInt(tNUM_CPTO.Text) = CVE_CPTO_OT_SAL Then
                        MsgBox("Mecánico inexistente")
                    Else
                        If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_OPER Then
                            MsgBox("Operador inexistente")
                        Else
                            If CInt(tNUM_CPTO.Text) = CVE_CPTO_SAL_UNIDAD Then
                                MsgBox("Unidad inexistente")
                            Else
                                If CPN = "C" Then
                                    MsgBox("Cliente inexistente")
                                Else
                                    If CPN = "P" Then
                                        MsgBox("Proveedor inexistente")
                                    End If
                                End If
                            End If
                        End If
                    End If
                    tCVE_PROV.Text = ""
                    LtMec.Text = ""
                    tCVE_PROV.Select()
                End If
            Else
                LtMec.Text = ""
            End If
        Catch ex As Exception
            Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnProv_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            barAgregar_Click(Nothing, Nothing)
        End If
    End Sub
    Private Function GET_ULT_COSTO(fCVE_ART As String) As Single
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim COSTO As Single

            cmd.Connection = cnSAE
            cmd.CommandText = "SELECT ISNULL(ULT_COSTO,0) AS COSTO FROM INVE" & Empresa & " WHERE CVE_ART = '" & fCVE_ART & "'"
            dr = cmd.ExecuteReader
            COSTO = 0
            If dr.Read Then
                COSTO = dr("COSTO")
            End If
            dr.Close()
            Return COSTO
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            Return 0
        End Try
    End Function
    Sub ImprimirReporte(fREFER As String)
        Try
            Dim RUTA_FORMATOS As String, ARCHIVO_MRT As String
            RUTA_FORMATOS = GET_RUTA_FORMATOS()

            ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE" & Empresa & ".mrt"
            If Not File.Exists(ARCHIVO_MRT) Then
                ARCHIVO_MRT = RUTA_FORMATOS & "\ReportMinveSAE.mrt"
                If Not File.Exists(ARCHIVO_MRT) Then
                    MsgBox("No existe el reporte " & ARCHIVO_MRT & ", verifique por favor")
                    Return
                End If
            End If

            StiReport1.Load(ARCHIVO_MRT)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor
            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = fREFER
            StiReport1.Render()
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        '1 2 6
        Try
            If ENTRA Then
                If Fg.Col = 1 Or Fg.Col = 2 Or Fg.Col = 5 Then
                    Dim c_ As Integer
                    If Fg.Col = 3 Then
                        c_ = Fg.Col
                    Else
                        c_ = Fg.Col
                    End If
                    _myEditor.StartEditing(Fg.Row, c_)
                End If
            End If
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If ENTRA Then
                If Fg.Row > 0 Then
                    If Fg.Col = 1 Or Fg.Col = 2 Or Fg.Col = 5 Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try        '3 4 6
            If Fg.Row > 0 And ENTRA Then
                Dim c_ As Integer
                If Fg.Col <> 3 Then
                    c_ = Fg.Col
                Else
                    c_ = Fg.Col
                End If
                _myEditor.StartEditing(Fg.Row, c_)
            End If
        Catch ex As Exception
            Bitacora("390. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        ENTRA_KEY = False
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        ENTRA_KEY = True
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            ENTRA_BTN = False
            Var2 = "InveP"
            Var4 = ""
            Var5 = ""
            Fg.FinishEditing()

            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                Fg.FinishEditing()

                'Var4 = Fg(Fg.Row, 1) 'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                'Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM
                Dim DESC1 As Single = 0, PRECIO As Single = 0
                Try
                    DESC1 = Val(tCVE_PROV.Tag)
                    If DESC1 = 0 Then
                        PRECIO = Val(Var9) / 0.95
                    Else
                        PRECIO = Val(Var9) + (Val(Var9) * DESC1 / 100)
                    End If
                    PRECIO = Math.Round(PRECIO, 4)
                Catch ex As Exception
                    Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try

                Fg(Fg.Row, 2) = Var4  'CVE_ART
                Fg(Fg.Row, 4) = Var5  'DESCR
                Fg(Fg.Row, 5) = PRECIO 'precio

                Try
                    If Fg(Fg.Row, 5) = 0 Then
                        Fg(Fg.Row, 6) = PRECIO
                    Else
                        Fg(Fg.Row, 6) = Fg(Fg.Row, 5) * PRECIO
                    End If
                Catch ex As Exception
                    Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Var2 = "" : Var4 = "" : Var5 = ""
                ENTRA = True
                Fg.Col = 5
                _myEditor.StartEditing(e.Row, 5)
            Else
                Fg.Col = 1 'ARTICULO
                _myEditor.StartEditing(e.Row, 1)
            End If
            ENTRA_BTN = True
        Catch ex As Exception
            MsgBox("580. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("580. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Fg.KeyPress
        Try
            If ENTRA Then
                _myEditor.SetPendingKey(e.KeyChar)
            End If
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterScroll(sender As Object, e As RangeEventArgs) Handles Fg.AfterScroll
        If ENTRA Then
            If _myEditor.Visible Then
                _myEditor.UpdatePosition()
            End If
        End If
    End Sub

    Private Sub tBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles tBotonMagico.GotFocus
        Try
            Fg.Select()
            Dim c_ As Integer
            If Fg.Col = 3 Then
                c_ = 1
            Else
                c_ = Fg.Col
            End If
            _myEditor.StartEditing(Fg.Row, c_)
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TREFER_KeyDown(sender As Object, e As KeyEventArgs) Handles tREFER.KeyDown
        Try
            If e.KeyCode = 13 Then
                tCVE_PROV.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tNUM_CPTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tNUM_CPTO.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                'tREFER.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TREFER_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tREFER.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                'tCVE_PROV.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
    End Sub
    Private Sub tCVE_PROV_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles tCVE_PROV.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                barAgregar_Click(Nothing, Nothing)
                Fg.Select()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_PROV_GotFocus(sender As Object, e As EventArgs) Handles tCVE_PROV.GotFocus
        Try
            'tCVE_PROV.SelectAll()
            tCVE_PROV.Select(0, tCVE_PROV.Text.Length)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tNUM_CPTO_GotFocus(sender As Object, e As EventArgs) Handles tNUM_CPTO.GotFocus
        Try
            tNUM_CPTO.SelectAll()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarKardex_Click(sender As Object, e As EventArgs) Handles BarKardex.Click
        Try
            If Fg.Row > 0 Then
                Var4 = Fg(Fg.Row, 2)
                Try
                    Var5 = Fg(Fg.Row, 4)
                Catch ex As Exception
                End Try
                frmKardex.ShowDialog()
            End If
        Catch ex As Exception
            Bitacora("12. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("12. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarObser_Click(sender As Object, e As EventArgs) Handles BarObser.Click
        Try
            If Fg(Fg.Row, 1).ToString.Length > 0 And Fg(Fg.Row, 2).ToString.Length > 0 Then
                Var4 = Fg(Fg.Row, 8)
                frmObserMinve.ShowDialog()
                If Var4 <> "-99" Then
                    Fg(Fg.Row, 8) = Var4
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub F1_KeyDown(sender As Object, e As KeyEventArgs) Handles F1.KeyDown
        Try
            If e.KeyCode = 13 Then
                If tCVE_PROV.Visible Then
                    tCVE_PROV.Select()
                Else
                    cboAlmacen.Select()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub F1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles F1.PreviewKeyDown
        Try
            If e.KeyCode = Keys.Tab Then
                If tCVE_PROV.Visible Then
                    tCVE_PROV.Select()
                Else
                    'cboAlmacen.Select()
                    Fg.Select()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class


'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
'===========================================================================================================================================
Public Class MyEditorMinve
    Inherits System.Windows.Forms.TextBox

    Dim WithEvents _owner As C1FlexGrid
    Dim _row As Integer
    Dim _col As Integer
    Dim _pendingKey As Char
    Dim _cancel As Boolean
    'constructor: attach to owner grid
    'Constructor: adjuntar a la cuadrícula del propietario
    Public Sub New(ByVal owner As C1FlexGrid, MyAlmacen As Single)
        MyBase.New()
        Visible = False
        AutoSize = False
        BackColor = Color.Beige
        BorderStyle = BorderStyle.FixedSingle

        _pendingKey = Chr(0)
        _cancel = False
        _owner = owner
        _owner.Controls.Add(Me)
        _owner.Cols(5).EditMask = "999,999,999.99"
        '_owner.Cols(7).EditMask = "999,999,999.99"
    End Sub

    'comenzar a editar: mover a la celda y activar
    '
    Public Sub StartEditing(ByVal row As Integer, ByVal col As Integer, Optional ByVal keyRec As Integer = 0)
        Dim Sigue As Boolean

        'save coordinates of cell being edited        'guardar las coordenadas de la celda que se está editando
        If col = 1 And keyRec = 9 Then
            MyBase.Visible = True
            _owner.Select()
            _owner.StartEditing()
            Return
        End If
        If col = 1 And keyRec = 999 Then
            _owner.Col = 1
            MyBase.Visible = True
            _owner.Select(_row, 1)
            _owner.StartEditing()
            SendKeys.Send("{TAB}")
            Return
        End If
        Sigue = True

        If Sigue And (col = 1 Or col = 2 Or col = 5) Then
            If col = 99 Then
                _owner.Col = 1
                frmMinveSaeAE.tBotonMagico.Focus()
                MyBase.Visible = True
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If

            _row = row
            _col = col
            'assume we'll save the edits
            'supongamos que guardaremos las ediciones
            _cancel = False
            'move editor over the current cell
            'mover editor sobre la celda actual
            Dim rc As Rectangle = _owner.GetCellRect(row, col, True)
            rc.Width = rc.Width - 1
            rc.Height = rc.Height - 1

            MyBase.Bounds = rc
            'initialize control content
            'inicializar contenido de control
            If col = 131 Then
                'PRECIO
            End If
            MyBase.Text = ""
            If _pendingKey > " " Then
                MyBase.Text = _pendingKey.ToString()
            ElseIf Not _owner(row, col) Is Nothing Then
                MyBase.Text = _owner(row, col).ToString()
            End If
            MyBase.Select(Text.Length, 0)
            'make editor visible
            MyBase.Visible = True
            'and get the focus
            '_owner.Select(_row, 2)
            MyBase.Select()
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength

            If col = 1 And keyRec = 99 Then
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub
    Public Sub EndEdit(ByVal row As Integer, ByVal col As Integer)
        Try
            _owner.FinishEditing()
            _owner(row, col) = ""
            MyBase.Text = ""
        Catch ex As Exception
            Bitacora("4000. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Public Sub EnterCell(ByVal row As Integer, ByVal col As Integer)
        If col = 1 Or col = 2 Or col = 5 Then
            MyBase.Visible = True
        End If
    End Sub
    'guardar clave que inició el modo de edición
    Public Sub SetPendingKey(ByVal chr As Char)
        _pendingKey = chr
    End Sub

    'move editor after the grid has scrolled
    'mover editor después de que la cuadrícula se haya desplazado
    Public Sub UpdatePosition()
        'get cell rect now
        'obtener celular ahora
        Dim rcCell As Rectangle = _owner.GetCellRect(_row, _col, False)

        'intersect with scrollable part of the grid
        'intersectarse con parte desplazable de la cuadrícula
        Dim rcScroll As Rectangle = _owner.ClientRectangle
        rcScroll.X = _owner.Cols(_owner.Cols.Fixed).Left
        rcScroll.Y = _owner.Rows(_owner.Rows.Fixed).Top
        rcScroll.Width = rcScroll.Width - rcScroll.X
        rcScroll.Height = rcScroll.Height - rcScroll.Y
        rcCell = Rectangle.Intersect(rcCell, rcScroll)

        'y mueve el control
        If (rcCell.Width > 0) Then rcCell.Width = rcCell.Width - 1
        If (rcCell.Height > 0) Then rcCell.Height = rcCell.Height - 1
        MyBase.Bounds = rcCell
    End Sub
    'Foco perdido: ocultar el editor
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        If _col = 99 Then
            _owner.Col = 1
            frmMinveSaeAE.tBotonMagico.Focus()
            _owner.Select()
            _owner.Select(_row, 2)
            _owner.StartEditing()
            Return
        End If
        Try
            'aqui esta el error
            If _col = 22 Then
                If IsNothing(_owner(_row, 2)) Then
                    MyBase.Visible = True
                    '_owner.Select()
                    '_owner.Select(_row, 2)
                    _owner.StartEditing()
                    Return
                End If
                'If _owner(_row, _col) = "" Then
                MyBase.Visible = True
                '_owner.Select()
                '_owner.Select(_row, 2)
                _owner.StartEditing()
                Return
                'End If
            End If
            If _col = 5 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 1)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim CANT As Single
                                        Try
                                            CANT = Val(_owner(_row, 1))
                                        Catch ex As Exception
                                        End Try

                                        Dim C1 As Decimal
                                        C1 = MyBase.Text * CANT
                                        _owner(_row, 6) = C1
                                    Catch ex As Exception
                                        Bitacora("4050. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                    _owner.FinishEditing()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4100. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            If _col = 99 Then
                Try
                    If Not IsNothing(_owner(_row, _col)) Then
                        If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                            If IsNumeric(_owner(_row, 9)) Then
                                If IsNumeric(MyBase.Text) Then
                                    Try
                                        Dim C1 As Decimal
                                        C1 = _owner(_row, 10) * MyBase.Text
                                        _owner(_row, 11) = C1

                                    Catch ex As Exception
                                        _owner(_row, 11) = _owner(_row, 10) * MyBase.Text
                                    End Try
                                    CALCULAR_IMPORTES()
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    Bitacora("4150. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("4150. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            End If
            'procesamiento base
            MyBase.OnLeave(e)

            'copiar texto a la cuadrícula del propietario
            If Not _cancel Then
                _owner(_row, _col) = MyBase.Text
            End If

            'no más claves pendientes
            _pendingKey = Chr(0)

            'hecho por ahora, ocultar editor
            MyBase.Visible = False
        Catch ex As Exception
            Bitacora("4200. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("940. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    'manejaremos la tecla de tabulación nosotros mismos
    Protected Overrides Function IsInputkey(ByVal keydata As Keys) As Boolean
        If keydata = Keys.Tab Or keydata = Keys.Enter Then
            Return True
        End If
        Return MyBase.IsInputKey(keydata)
    End Function

    'algunas teclas finalizan la edición
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)

        If _col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmMinveSaeAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If

        Select Case e.KeyCode
            Case Keys.Escape
                _cancel = True
                _owner.Select()
                e.Handled = True
            Case Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown, Keys.Left, Keys.Right
                _owner.Select()
                e.Handled = True
                MoveCursor(e.KeyCode)
            Case Keys.F2
                If _col = 99 Then
                    Try
                        If Not IsNothing(_owner(_row, _col)) Then
                            If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                If IsNumeric(_owner(_row, 5)) Then
                                    If IsNumeric(MyBase.Text) Then
                                        Try
                                            Dim C1 As Decimal
                                            C1 = _owner(_row, 5) * MyBase.Text
                                            _owner(_row, 6) = C1
                                        Catch ex As Exception
                                            Bitacora("4250. " & ex.Message & vbNewLine & ex.StackTrace)
                                        End Try
                                    End If
                                End If
                            End If
                        End If
                        _owner.Col = 2
                        _owner.StartEditing()
                        Return
                    Catch ex As Exception
                        Bitacora("4280. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
                If _col = 2 Then
                    Try                    'ARTICULOS
                        Var2 = "InveP" : Var5 = "" : Var6 = "" : Var9 = ""
                        Var4 = ""
                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then
                            'Var4 = Fg(Fg.Row, 1) 'CLAVE
                            'Var5 = Fg(Fg.Row, 2).ToString 'DESCRIPCION
                            'Var7 = Fg(Fg.Row, 3).ToString 'PRECIOS
                            'Var6 = Fg(Fg.Row, 4).ToString 'ALTERNA
                            'Var8 = Fg(Fg.Row, 6).ToString 'TIPO PROD
                            'Var9 = Fg(Fg.Row, 7).ToString 'COSTO PROM

                            _owner(_row, 2) = Var4
                            _owner(_row, 4) = Var5

                            Dim PRECIO As Single = 0
                            Try
                                PRECIO = Val(Var9)
                                PRECIO = Math.Round(PRECIO, 4)
                            Catch ex As Exception
                            End Try
                            Try
                                Dim C1 As Decimal
                                _owner(_row, 5) = PRECIO
                                C1 = _owner(_row, 1) * PRECIO
                                _owner(_row, 6) = C1
                            Catch ex As Exception
                            End Try

                            _owner.Col = 5
                        End If
                        Return
                    Catch Ex As Exception
                        Bitacora("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                        MsgBox("4300. " & Ex.Message & vbNewLine & Ex.StackTrace)
                    End Try
                End If
                If _col = 5 Then
                End If
            Case Else
                MyBase.OnKeyDown(e)
        End Select
    End Sub

    'mover el cursor después de terminar la edición
    Protected Sub MoveCursor(ByVal key As Keys)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmMinveSaeAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 2)
                _owner.StartEditing()
                Return
            End If
        End If

        If col = 1 And key = Keys.Left Then
            frmMinveSaeAE.tBotonMagico.Focus()
            Return
        End If

        Select Case key
            Case Keys.Tab, Keys.Enter

            Case Keys.Up
                If _owner.Row = 1 Then
                    frmMinveSaeAE.tBotonMagico.Focus()
                    Return
                End If
                If IsNothing(_owner(_row, 1)) Then
                    If IsNothing(_owner(_row, 2)) Then
                        _owner.RemoveItem(_owner.Row)
                        row = _owner.Rows.Count - 1
                        Return
                    Else
                        If _owner(_row, 2).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                Else
                    If _owner(_row, 2).ToString.Trim.Length = 0 Then
                        If _owner(_row, 1).ToString.Length = 0 Then
                            _owner.RemoveItem(_owner.Row)
                            row = _owner.Rows.Count - 1
                            Return
                        End If
                    End If
                End If

                If row > 1 Then
                    row = row - 1
                    '_owner.Select()
                    _owner.Select(row, col)
                    '_owner.StartEditing()
                Else
                    _owner.Select()
                    _owner.Select(row, col)
                    _owner.StartEditing()
                End If
            Case Keys.Down
                If _owner.Rows.Count - 1 = row Then
                    Select Case col
                        Case 1
                            If IsNothing(_owner(_row, 1)) Then
                                frmMinveSaeAE.tBotonMagico.Focus()
                            Else
                                If _owner(_row, 1).ToString.Length > 0 And _owner(_row, 5).ToString.Length > 0 Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                                   "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                                   "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                Else
                                    frmMinveSaeAE.tBotonMagico.Focus()
                                End If
                            End If
                        Case 2
                            frmMinveSaeAE.tBotonMagico.Focus()
                        Case 5
                            frmMinveSaeAE.tBotonMagico.Focus()
                    End Select
                    Return
                Else
                    row = row + 1
                    _owner.Select()
                    _owner.Select(row, col)
                    '_owner.StartEditing()
                End If
            Case Keys.PageUp
                row -= 10
            Case Keys.PageUp
                row += 10
            Case Keys.Left
                If col > 1 Then
                    Select Case col
                        Case 1
                            Try
                                If IsNothing(_owner(_row, 1)) Then
                                    If IsNothing(_owner(_row, 3)) Then
                                        If _owner.Rows.Count - 1 <> 1 Then
                                            _owner.RemoveItem(_owner.Row)
                                            row = _owner.Rows.Count - 1
                                        End If
                                        Return
                                    Else
                                        If _owner(_row, 3).ToString.Length = 0 Then
                                            If _owner.Rows.Count - 1 <> 1 Then
                                                _owner.RemoveItem(_owner.Row)
                                                row = _owner.Rows.Count - 1
                                            End If
                                            Return
                                        End If
                                    End If
                                Else
                                    If IsNothing(_owner(_row, 3)) Then
                                        If _owner(_row, 1).ToString.Length = 0 Then
                                            If _owner.Rows.Count - 1 <> 1 Then
                                                _owner.RemoveItem(_owner.Row)
                                                row = _owner.Rows.Count - 1
                                            End If
                                            Return
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("4310. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try

                            Try
                                frmMinveSaeAE.tBotonMagico.Focus()
                                _owner.Select()
                                _owner.Select(row, col)
                                _owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4320. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 2
                            col = 1
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                        Case 5
                            col = 2
                            _owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                            'If row = 1 Then
                            'row = _owner.Rows.Count - 1
                            'Else
                            'row = row - 1
                            'End If
                            'col = 1
                    End Select
                    'col = col - 1
                    'If col = 2 Or col = 4 Then
                    'col = col - 1
                    'End If
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
                Return
            Case Keys.Right
                If col <= 8 Then
                    Select Case col
                        Case 1
                            'CORREGIR AQUI
                            If IsNothing(_owner(_row, 1)) Then
                                frmMinveSaeAE.tBotonMagico.Focus()
                                '_owner.Select()
                                '_owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            If MyBase.Text.ToString.Length = 0 Then
                                frmMinveSaeAE.tBotonMagico.Focus()
                                '_owner.Select()
                                _owner.Select(row, col)
                                '_owner.StartEditing()
                                Return
                            End If
                            col = 2
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            Return
                        Case 2
                            col = 5
                            _owner.Select(row, col)
                            Return
                        Case 5 'costo
                            col = 5
                            frmMinveSaeAE.tBotonMagico.Focus()
                            '_owner.Select()
                            _owner.Select(row, col)
                            '_owner.StartEditing()
                            return
                    End Select
                Else
                    col = 1
                End If
                _owner.Select()
                _owner.Select(row, col)
                _owner.StartEditing()
        End Select

        'validar nueva selección
        If (row < _owner.Rows.Fixed) Then row = _owner.Rows.Fixed
        If (col < _owner.Cols.Fixed) Then col = _owner.Cols.Fixed
        If (row > _owner.Rows.Count - 1) Then row = _owner.Rows.Count - 1
        If (col > _owner.Cols.Count - 1) Then col = _owner.Cols.Count - 1

        'aplicar nueva selección        7
        _owner.Select(_row, _col)

    End Sub
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim row As Integer = _owner.Row
        Dim col As Integer = _owner.Col
        Dim HayErr As Boolean

        If col = 99 Then
            If Not FgEdit Then
                _owner.Col = 1
                frmMinveSaeAE.tBotonMagico.Focus()
                _owner.Select()
                _owner.Select(_row, 1)
                _owner.StartEditing()
                Return
            End If
        End If
        Try
            Select Case e.KeyChar
                Case Chr(13), Chr(9)
                    Select Case _col
                        Case 1
                            If MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0" Then
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                frmMinveSaeAE.tBotonMagico.Focus()
                                MyBase.Visible = True
                                Return

                            End If
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 5)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = _owner(_row, 5) * MyBase.Text
                                                    _owner(_row, 6) = C1
                                                Catch ex As Exception
                                                    Bitacora("4350. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                                HayErr = False
                                _owner.Col = 2
                                '_owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4370. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4370. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        Case 2 'CVE_ART
                            Dim Descr As String

                            If MyBase.Text.Trim.Length = 0 Then
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                frmMinveSaeAE.tBotonMagico.Focus()
                                MyBase.Visible = True
                                Return
                            End If

                            Var9 = "" : Var22 = 0 : Var4 = ""
                            Descr = BUSCA_CAT("InveP", MyBase.Text)
                            If Descr.TrimEnd.Trim.Length = 0 Or Descr = "N" Then
                                MsgBox("Artículo inexistente ó el artículo es un servicio")
                                frmMinveSaeAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = ""
                                _owner.StartEditing()
                                Return
                            Else
                                Dim COSTO As Single
                                'Var6 = dr.ReadNullAsEmptyString("NUM_PARTE")
                                'Var7 = dr.ReadNullAsEmptyDecimal("P1")
                                'Var8 = dr.ReadNullAsEmptyString("T_ELE")
                                'Var9 = dr.ReadNullAsEmptyDecimal("C_PROM")
                                _owner(_row, 2) = MyBase.Text
                                _owner(_row, 4) = Descr
                                '_owner(_row, 5) = Var7
                                '_owner(_row, 6) = Var7
                                Try

                                    COSTO = Val(Var9)
                                    COSTO = Math.Round(COSTO, 4)
                                    _owner(_row, 5) = COSTO
                                    Dim C1 As Decimal
                                    If _owner(_row, 1) = 0 Then
                                        _owner(_row, 1) = 1
                                    End If
                                    C1 = _owner(_row, 1) * COSTO
                                    _owner(_row, 6) = C1
                                Catch ex As Exception
                                    _owner(_row, 5) = COSTO
                                End Try
                                _owner.Col = 5
                                Return
                            End If

                            'End If
                        Case 5 'costo
                            If (MyBase.Text.Trim.Length = 0 Or MyBase.Text.Trim = "0") And _col = 99 Then
                                MyBase.Visible = True
                                frmMinveSaeAE.tBotonMagico.Focus()
                                _owner.Select(_row, _col)
                                _owner(_row, _col) = "1"
                                '_owner.StartEditing()
                                Return
                            End If
                            Try
                                If Not IsNothing(_owner(_row, _col)) Then
                                    If Not String.IsNullOrEmpty(_owner(_row, _col)) Then
                                        If IsNumeric(_owner(_row, 1)) Then
                                            If IsNumeric(MyBase.Text) Then
                                                Try
                                                    Dim C1 As Decimal
                                                    C1 = _owner(_row, 1) * MyBase.Text
                                                    _owner(_row, 6) = C1
                                                Catch ex As Exception
                                                    Bitacora("4380. " & ex.Message & vbNewLine & ex.StackTrace)
                                                End Try
                                            End If
                                        End If
                                    End If
                                End If
                                Try
                                    Var4 = _owner(_row, 8)
                                    frmObserMinve.ShowDialog()
                                    If Var4 <> "-99" Then
                                        _owner(_row, 8) = Var4
                                    End If
                                Catch ex As Exception
                                End Try
                                HayErr = False
                                Try
                                    _owner.Select(row + 1, 1)
                                Catch ex As Exception
                                    HayErr = True
                                End Try

                                If HayErr Then
                                    'If FgEdit Then
                                    _owner.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "1" & vbTab & "0" & vbTab &
                                                   "0" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab &
                                                   "" & vbTab & " " & vbTab & " " & vbTab & 0 & vbTab & "")
                                    _owner.Select(row + 1, 1)
                                    'End If
                                Else
                                    'If _owner(row, 1) > 0 And _owner(row, 3).ToString.Trim.Length > 0 Then
                                    'End If
                                End If
                                _owner.Col = 1
                                '_owner.Select(_row, _col)
                                _owner(_row, _col) = "1"
                                '_owner.StartEditing()
                                Return
                            Catch ex As Exception
                                Bitacora("4390. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("4390. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                    End Select
                    e.Handled = True
                    _owner.Select()
                    Select Case col
                        Case 111
                            _owner.Select(row, col + 4)
                        Case 55
                            _owner.Select(row, col + 4)
                        Case 10
                    End Select

                    _owner.StartEditing()
                    'Return

                Case Else
                    If _col = 5 Then
                        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                            e.KeyChar = ""
                            Return
                        End If
                    End If
                    If _col = 1 Then
                        'e.KeyChar = e.KeyChar.ToString.ToUpper
                    End If
            End Select
            MyBase.OnKeyPress(e)
        Catch ex As Exception
            Bitacora("4400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub LLENAR_GRID_ARTICULO(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim ULT_COSTO As Single

            If fCVE_ART.Trim.Length = 0 Then
                Return
            End If

            ULT_COSTO = 0
            cmd.Connection = cnSAE
            cmd.CommandTimeout = 180

            SQL = "SELECT I.CVE_ART, DESCR, ULT_COSTO, UNI_MED, IMPUESTO1, IMPUESTO2, IMPUESTO3, IMPUESTO4, I.CVE_ESQIMPU, " &
                "ISNULL((SELECT TOP 1 PRECIO FROM PRECIO_X_PROD" & Empresa & " P WHERE P.CVE_ART = I.CVE_ART AND CVE_PRECIO = 1),0) AS P1 " &
                "FROM INVE" & Empresa & " I " &
                "LEFT JOIN CVES_ALTER" & Empresa & " A ON A.CVE_ART = I.CVE_ART " &
                "LEFT JOIN IMPU" & Empresa & " P ON P.CVE_ESQIMPU = I.CVE_ESQIMPU " &
                "WHERE I.CVE_ART = '" & fCVE_ART & "' OR A.CVE_ALTER = '" & fCVE_ART & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                _owner(_row, 1) = dr("CVE_ART")
                _owner(_row, 3) = dr("DESCR")
                Try
                    Dim C1 As Decimal
                    C1 = _owner(_row, 5) * _owner(_row, 6)
                    _owner(_row, 7) = C1
                Catch ex As Exception
                    _owner(_row, 7) = _owner(_row, 5) * _owner(_row, 6)
                End Try
                'frmTPV.CALCULAR_IMPORTES()
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("4450. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("4450. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CALCULAR_IMPORTES()
        Try
            Dim SUMA As Decimal = 0
            _owner.FinishEditing()

            For k = 1 To _owner.Rows.Count - 1
                If _owner(k, 1).ToString.Trim.Length > 0 And _owner(k, 1).ToString.Trim = "TOT" And _owner(k, 9).ToString.Trim = "Cancelada" Then
                    SUMA = SUMA + _owner(k, 7)
                End If
            Next
        Catch ex As Exception
            Bitacora("5000. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class


