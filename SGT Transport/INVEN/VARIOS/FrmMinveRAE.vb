Imports C1.Win.C1Themes
Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmMinveRAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean

    Private ALM_CONSIGNA As Integer

    Private Key_Pres As Integer
    Private Sub frmMinveRAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True
        Dim z As Integer

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE

            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(ALM_CONSIGNA,0) AS ALM_CON FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                MULTIALMACEN = dr("M_ULTIALMACEN")
                ALM_CONSIGNA = dr("ALM_CON")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA = True
        ENTRA_KEY = True
        Key_Pres = 0
        REMOVE_ROW = 0
        ENTRA_BTN = True

        cboAlmacen.Items.Clear()
        tNUM_CPTO.Text = ""
        tREFER.Text = ""
        tCVE_PROV.Text = ""
        Fg.Rows.Count = 1


        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
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

        End Try

        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
        Fg.Rows(Fg.Rows.Count - 1).Height = 30

        Fg.SetCellImage(Fg.Rows.Count - 1, 3, My.Resources.LUPA4)

        Fg.Row = 1
        Fg.Col = 1
        ENTRA = True

        tNUM_CPTO.Select()

    End Sub

    Private Sub frmMinveRAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()

    End Sub

    Private Sub frmMinveRAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmMinveRAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And ENTRA_KEY Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim CVE_DOC As String
        Dim CVE_ART As String
        Dim CVE_CLPV As String
        Dim CANT As Decimal
        Dim CVE_CPTO As Integer
        Dim TIPO_DOC As String
        Dim VEND As String
        Dim PREC As Single

        Dim COSTO As Single
        Dim FACTOR_CON As Single
        Dim SIGNO As Integer
        Dim COSTEADO As String
        Dim DESDE_INVE As String
        Dim MOV_ENLAZADO As Integer
        Dim E_LTPD As Long
        Dim UNI_VENTA As String
        Dim REG_SERIE As Long
        Dim TIPO_PROD As String
        Dim CVE_ALM As Integer
        Dim Exis As Boolean
        Dim j As Integer
        Dim CVE_OBS As Long

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

        CVE_ALM = 1
        TIPO_DOC = "M"
        CVE_CLPV = ""
        VEND = ""
        UNI_VENTA = ""
        TIPO_PROD = "P"
        COSTEADO = "S"
        DESDE_INVE = "S"
        FACTOR_CON = 1
        CVE_DOC = tREFER.Text
        PREC = 0
        Exis = False
        j = 0
        Try
            If cboAlmacen.SelectedIndex = -1 Then
                CVE_ALM = 1
            Else
                CVE_ALM = CType(cboAlmacen.SelectedItem, ValueDescriptionPair).ClavePair
            End If
        Catch ex As Exception
            MsgBox("19. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("19. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        cmd.Connection = cnSAE

        Try
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
                Return
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        CVE_CPTO = tNUM_CPTO.Text

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

                If CANT > 0 Then

                    CVE_OBS = GRABA_OBSER(Fg(k, 8).ToString)

                    j = j + 1
                    Try
                        SQL = "UPDATE GCINVER SET EXIST = ISNULL(EXIST,0) + " & (CANT * SIGNO) & ", ULT_COSTO = " & COSTO & ", COSTO_PROM = " & COSTO &
                        " WHERE CVE_ART = '" & CVE_ART & "'"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("101. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("101. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    Try
                        SQL = "INSERT INTO GCMINVER" & Empresa & " (CVE_ART, ALMACEN, NUM_MOV, CVE_CPTO, FECHA_DOCU, TIPO_DOC, REFER, CLAVE_CLPV, VEND, " &
                           "CANT, CANT_COST, PRECIO, COSTO, REG_SERIE, CVE_OBS, UNI_VENTA, E_LTPD, EXIST_G, EXISTENCIA, TIPO_PROD, FACTOR_CON, FECHAELAB, " &
                           "CVE_FOLIO, SIGNO, COSTEADO, COSTO_PROM_INI, COSTO_PROM_FIN, DESDE_INVE, MOV_ENLAZADO, COSTO_PROM_GRAL) VALUES('" &
                           CVE_ART & "','" & CVE_ALM & "',(SELECT ISNULL(MAX(NUM_MOV),0) + 1 FROM GCMINVER" & Empresa & "),'" & CVE_CPTO &
                           "',CONVERT(varchar, GETDATE(), 112),'" & TIPO_DOC & "','" & CVE_DOC & "','" & CVE_CLPV & "','" & VEND & "','" &
                           CANT & "','" & CANT & "','" & PREC & "','" & COSTO & "','" & REG_SERIE & "','" & CVE_OBS & "','" & UNI_VENTA & "','" & E_LTPD & "',"
                        SQL = SQL & "(SELECT EXIST FROM GCINVER WHERE CVE_ART = '" & CVE_ART & "')," 'EXIST_G
                        If MULTIALMACEN = 1 Then
                            SQL = SQL & "ISNULL((SELECT EXIST FROM GCMULTR" & Empresa & " WHERE CVE_ART = '" & CVE_ART & "' AND CVE_ALM = " & CVE_ALM & "),0),'"   'EXISTENCIA
                        Else
                            SQL = SQL & "(SELECT EXIST FROM GCINVER WHERE CVE_ART = '" & CVE_ART & "'),'"  'EXISTENCIA
                        End If
                        SQL = SQL & TIPO_PROD & "','" & FACTOR_CON & "',GETDATE(),(SELECT ISNULL(ULT_CVE,0) + 1  FROM GCTBLCONTROL WHERE ID_TABLA = 32),'" &
                                  SIGNO & "','" & COSTEADO & "','" & COSTO & "','" & COSTO & "','" & DESDE_INVE & "','" & MOV_ENLAZADO & "','" & COSTO & "')"
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then

                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("102. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("102. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Catch ex As Exception
                Bitacora("103. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("103. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        If j > 0 Then
            SQL = "UPDATE GCTBLCONTROL SET ULT_CVE = (SELECT ISNULL(MAX(CAST(REPLACE(CVE_FOLIO,',','') AS INT)),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 32"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery.ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If

            SQL = "UPDATE GCTBLCONTROL SET ULT_CVE = (SELECT ISNULL(MAX(NUM_MOV),0) FROM MINVE" & Empresa & ") WHERE ID_TABLA = 44"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery.ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If
            ImprimirReporte(CVE_DOC)

            MsgBox("El movimiento al inventario se grabo satisfactoriamente")
            Me.Close()
        Else
            MsgBox("---------- No se realizaron movimientos al inventario --------------")
        End If


    End Sub

    Private Sub barAgregar_Click(sender As Object, e As EventArgs) Handles barAgregar.Click
        Try
            If Fg.Row > 0 Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub barEliminar_Click(sender As Object, e As EventArgs) Handles barEliminar.Click

    End Sub

    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()

    End Sub

    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 1 Or Fg.Col = 2 Or Fg.Col = 6 Then
                    Fg.StartEditing()
                Else
                    If Fg.Col = 3 Then
                        btnSel_GotFocus(Nothing, Nothing)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnProv_Click(sender As Object, e As EventArgs) Handles btnProv.Click
        Try
            Var2 = "Prov"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PROV.Text = Var4
                L1.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                cboAlmacen.Focus()
            End If

        Catch Ex As Exception
            MsgBox("101. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("101. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "CONM"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                L1.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                cboAlmacen.Focus()
            End If

        Catch Ex As Exception
            MsgBox("103. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("103. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit
        Try
            If e.Row > 0 And ENTRA Then
                ENTRA = False
                If e.Col = 5 Then
                    Try
                        If IsNumeric(Fg(e.Row, 1)) And IsNumeric(Fg(e.Row, 1)) Then
                            Fg(e.Row, 6) = Fg(e.Row, 1) * Fg(e.Row, 5)
                        End If


                        If Fg(e.Row, 1).ToString.Trim.Length > 0 And Fg(e.Row, 2).ToString.Trim.Length > 0 Then
                            If Fg.Row = Fg.Rows.Count - 1 Then
                                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
                                Fg.Rows(Fg.Rows.Count - 1).Height = 30

                                If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                                    Fg.SetCellImage(Fg.Rows.Count - 1, 3, My.Resources.LUPA4)
                                End If

                                Fg.Row = Fg.Rows.Count - 1
                                ENTRA = True
                                Fg.Select(Fg.Row, 0)
                                Fg.StartEditing()
                                Return
                            Else
                                Fg.Row = Fg.Rows.Count - 1
                                ENTRA = True
                                Fg.Select(Fg.Row, 0)
                                Fg.StartEditing()
                            End If
                        End If
                    Catch ex As Exception
                        ENTRA = True
                        MsgBox("104. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                End If
                If e.Col = 1 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then

                            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
                            Fg.Rows(Fg.Rows.Count - 1).Height = 30
                            If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                                Fg.SetCellImage(Fg.Rows.Count - 1, 3, My.Resources.LUPA4)
                            End If
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 1
                            ENTRA = True
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            Key_Pres = 0
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 2).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                ENTRA = True
                                Return
                            End If
                        Else
                            If Fg(e.Row, 1).ToString.Trim.Length > 0 Then
                            End If
                        End If
                    End If
                    Return
                End If
                If e.Col = 2 Then
                    Fg.Select(Fg.Row, 4)
                    Fg.StartEditing()
                End If


                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("109. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 3 Then
                    e.Cancel = True
                End If
                If Fg.Col = 4 Then
                    e.Cancel = True
                End If
                If Fg.Col = 6 Then
                    e.Cancel = True
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("106. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            ENTRA = True

            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 6 Then
                Else
                    If REMOVE_ROW > 0 Then
                        If Fg.Row > 0 Then
                            Fg.Row = REMOVE_ROW
                        End If
                        REMOVE_ROW = 0
                    End If
                    Fg.StartEditing()
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        ENTRA_KEY = False
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 1 And e.KeyCode = 27 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                        Fg.RemoveItem(Fg.Row)
                        REMOVE_ROW = Fg.Row
                        ENTRA = True
                        Return
                    End If
                    Return
                End If
                If Fg.Col = 1 And e.KeyCode = Keys.Down Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 And Fg(Fg.Row, 2).ToString.Trim.Length > 0 Then

                        Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "0" & vbTab & "0" & vbTab & "" & vbTab & "")
                        Fg.Rows(Fg.Rows.Count - 1).Height = 30
                        If File.Exists(Application.StartupPath & "\LUPA4.jpg") Then
                            Fg.SetCellImage(Fg.Rows.Count - 1, 3, My.Resources.LUPA4)
                        End If

                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 1
                        ENTRA = True
                        Return
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If ENTRA Then
                ENTRA = False
                If e.KeyCode = Keys.F2 Then

                    btnSel_GotFocus(Nothing, Nothing)
                    ENTRA = True
                    Return
                End If

                If e.KeyCode = Keys.Up And e.Row > 1 Then

                    Key_Pres = e.KeyCode
                    ENTRA = True
                    Return
                End If
                If e.KeyCode = Keys.Down Then

                    Key_Pres = e.KeyCode
                    ENTRA = True
                    Return
                End If
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Then

                    Key_Pres = e.KeyCode
                    ENTRA = True
                    Return
                End If
                If e.KeyCode = 27 Then
                    Key_Pres = e.KeyCode
                    If Fg.Col = 1 Then
                        If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 2).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(Fg.Row)
                            REMOVE_ROW = Fg.Row

                            ENTRA = True
                            Return
                        End If
                    End If
                    Return
                End If
                If e.KeyCode = Keys.Tab Or e.KeyCode = Keys.Enter Then
                    If Fg.Row > 0 Then
                        'ENTRA = False
                        If Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 6 Then
                        Else
                            If Fg.Col = 2 Then
                                Fg.Col = 4
                                Fg.StartEditing()
                                Return
                            End If

                            If Fg.Col = 5 Then
                                Var4 = Fg(e.Row, 8)
                                frmObserMinve.ShowDialog()
                                If Var4.Trim.Length > 0 Then
                                    Fg(e.Row, 8) = Var4
                                End If
                            End If

                        End If

                        'ENTRA = True
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus

        ENTRA_KEY = True
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 2 Then
                    If Fg.Editor.Text.Trim.Length > 0 Then

                        Dim DESCR As String
                        DESCR = BUSCA_CAT("InvenR", Fg.Editor.Text)
                        If DESCR <> "" Then
                            Fg(Fg.Row, 4) = DESCR

                            Dim cmd As New SqlCommand
                            Dim dr As SqlDataReader

                            SQL = "SELECT ULT_COSTO, COSTO_PROM, UNI_MED FROM GCINVER WHERE CVE_ART = '" & Fg.Editor.Text & "'"
                            cmd.Connection = cnSAE
                            cmd.CommandText = SQL
                            dr = cmd.ExecuteReader

                            ENTRA = False
                            If dr.Read Then
                                Fg(Fg.Row, 5) = dr("ULT_COSTO")
                                Fg(Fg.Row, 7) = dr("UNI_MED")
                            End If
                            dr.Close()
                        Else
                            e.Cancel = True

                            MsgBox("Articulo inexistente")
                        End If
                    Else
                        If Fg.Editor.Text.Trim.Length = 0 Then
                            'e.Cancel = True
                            'Return

                        End If
                        Select Case Key_Pres
                            Case Keys.Up '38


                            Case Keys.Down '40

                                If Fg.Editor.Text.Trim.Length = 0 Then

                                    e.Cancel = True
                                Else
                                    Key_Pres = 0
                                    e.Cancel = True

                                End If
                            Case Else
                                'e.Cancel = True
                                If Key_Pres = Keys.Right Then

                                Else

                                    Key_Pres = 0
                                End If

                        End Select
                    End If
                End If
                If Fg.Col = 4 Then
                    If Fg.Editor.Text.Trim.Length = 0 Then
                        e.Cancel = True
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            ENTRA = True
            MsgBox("108. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSel_GotFocus(sender As Object, e As EventArgs) Handles btnSel.GotFocus
        Try
            If Key_Pres = Keys.Right Or Key_Pres = Keys.Left Then
                Key_Pres = 0
                Fg.Col = 1
                Return
            End If
            If ENTRA_BTN Then

                ENTRA_BTN = False
                Var2 = "GCINVER"
                Var4 = ""
                Var5 = ""
                Fg.FinishEditing()

                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then

                    Fg(Fg.Row, 2) = Var4
                    Fg(Fg.Row, 4) = Var5

                    Dim cmd As New SqlCommand
                    Dim dr As SqlDataReader

                    SQL = "SELECT ULT_COSTO, COSTO_PROM, UNI_MED FROM GCINVER WHERE CVE_ART = '" & Var4 & "'"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    dr = cmd.ExecuteReader

                    ENTRA = False
                    If dr.Read Then
                        Fg(Fg.Row, 5) = dr("ULT_COSTO")
                        Fg(Fg.Row, 7) = dr("UNI_MED")
                    End If
                    dr.Close()

                    Var2 = ""
                    Var4 = ""
                    Var5 = ""
                    Fg.Col = 5
                Else
                    Fg.Col = 1
                End If
                ENTRA_BTN = True
            End If
        Catch ex As Exception
            MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyUpEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyUpEdit
        Try
            If e.Row > 0 Then
                If e.Col = 2 And e.KeyValue = Keys.F2 Then
                    If ENTRA_BTN Then

                        ENTRA_BTN = False
                        Var2 = "InveR"
                        Var4 = ""
                        Var5 = ""
                        Fg.FinishEditing()

                        frmSelItem.ShowDialog()
                        If Var4.Trim.Length > 0 Then

                            Dim cmd As New SqlCommand
                            Dim dr As SqlDataReader

                            SQL = "SELECT ULT_COSTO, COSTO_PROM, UNI_MED FROM GCINVER WHERE CVE_ART = '" & Var4 & "'"
                            cmd.Connection = cnSAE
                            cmd.CommandText = SQL
                            dr = cmd.ExecuteReader

                            ENTRA = False
                            If dr.Read Then
                                Fg(Fg.Row, 5) = dr("ULT_COSTO")
                                Fg(Fg.Row, 7) = dr("UNI_MED")
                            End If
                            dr.Close()
                            ENTRA = True
                            Fg(Fg.Row, 2) = Var4
                            Fg(Fg.Row, 4) = Var5
                            Var2 = ""
                            Var4 = ""
                            Var5 = ""
                            Fg.Col = 5
                        Else
                            Fg.Col = 1
                        End If

                        ENTRA_BTN = True
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("127. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("127. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown

        If e.KeyCode = Keys.F2 Then
            btnNumCpto_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tNUM_CPTO_Validated(sender As Object, e As EventArgs) Handles tNUM_CPTO.Validated
        Try

            If tNUM_CPTO.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("CONM", tNUM_CPTO.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                Else
                    MsgBox("Concepto inexistente")
                    tNUM_CPTO.Text = ""
                    tNUM_CPTO.Select()
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_PROV_Validated(sender As Object, e As EventArgs) Handles tCVE_PROV.Validated
        Try
            If tCVE_PROV.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Prov", tCVE_PROV.Text)
                If DESCR <> "" Then
                    L1.Text = DESCR
                Else
                    MsgBox("Proveedor inexistente")
                    tCVE_PROV.Text = ""
                    tCVE_PROV.Select()
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub tCVE_PROV_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PROV.KeyDown

        If e.KeyCode = Keys.F2 Then
            btnProv_Click(Nothing, Nothing)
        End If

    End Sub
    Private Function GET_ULT_COSTO(fCVE_ART As String) As Single
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim COSTO As Single

            cmd.Connection = cnSAE
            cmd.CommandText = "SELECT ISNULL(ULT_COSTO,0) AS COSTO FROM GCINVER WHERE CVE_ART = '" & fCVE_ART & "'"
            dr = cmd.ExecuteReader
            COSTO = 0
            If dr.Read Then
                COSTO = dr("COSTO")
            End If
            dr.Close()
            Return COSTO
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Sub ImprimirReporte(fREFER As String)

        Try
            Dim RUTA_FORMATOS As String

            RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinve" & Empresa & ".mrt"

            If Not File.Exists(RUTA_FORMATOS) Then
                RUTA_FORMATOS = GET_RUTA_FORMATOS() & "\ReportMinve.mrt"
                If Not File.Exists(RUTA_FORMATOS) Then
                    MsgBox("No existe el reporte " & RUTA_FORMATOS & ", verifique por favor")
                    Return
                End If
            End If
            StiReport1.Load(RUTA_FORMATOS)

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("OLE DB", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()
            StiReport1.ReportName = Me.Text
            StiReport1.Item("REFER") = fREFER
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub barReimprimir_Click(sender As Object, e As EventArgs) Handles barReimprimir.Click

    End Sub

    Private Sub Fg_AfterDragRow(sender As Object, e As DragRowColEventArgs) Handles Fg.AfterDragRow

    End Sub
End Class
