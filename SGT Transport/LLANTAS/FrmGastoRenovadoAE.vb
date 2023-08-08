Imports C1.Win.C1FlexGrid
Imports C1.Win.C1Themes
Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class FrmGastoRenovadoAE
    Private CVE_ALM_RNBDO As Integer
    Private CVE_ART_RNBDO As String
    Private ENTRA As Boolean = True
    Private cl As Integer = 0

    Private Sub FrmGastoRenovadoAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Fg.Styles.EmptyArea.BackColor = ColoFondoFG

            BarraMenu.BackColor = Color.FromArgb(207, 221, 238)

        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        CARGA_PARAM_INVENT()

        'Fg.Cols(8).Visible = False
        Fg.Cols(9).Visible = False
        Fg.Cols(10).Visible = False

        If MULTIALMACEN = 1 Then
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim CADENA_ALM As String = ""

                cmd.Connection = cnSAE
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE CVE_ALM <> 1 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.HasRows Then
                    Do While dr.Read
                        CboAlmacen.Items.Add(Format(dr("CVE_ALM"), "00") & " " & dr("DESCR"))
                        CADENA_ALM = CADENA_ALM & Format(dr("CVE_ALM"), "00") & " " & dr("DESCR") & "|"
                    Loop
                End If
                dr.Close()
                'Fg.Cols(4).ComboList = CADENA_ALM
                'Fg.Cols(4).Width = 200
                CboAlmacen.SelectedIndex = 0
            Catch ex As Exception
                Bitacora("30. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("30. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
        TCVE_GASTO.Tag = "0"
        TCVE_UNI.Tag = ""

        If Var1 = "Nuevo" Then
            Try
                TCVE_GASTO.Text = GET_MAX("GCGASTOS_RENOVADO", "CVE_GASTO")
                TCVE_GASTO.Enabled = False
                TCVE_UNI.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                Dim UnaVez As Boolean = True, z As Integer = 0
                cmd.Connection = cnSAE

                SQL = "SELECT CVE_GASTO, CVE_ART, CVE_UNI, NUM_ALM, COSTO, ISNULL(O1.DESCR,'') AS DES_DOC, ISNULL(O2.DESCR,'') AS DES_PAR,
                    CVE_OBS_DOC, CVE_OBS_PAR, UUID
                    FROM GCGASTOS_RENOVADO G
                    LEFT JOIN GCOBS O1 ON O1.CVE_OBS = G.CVE_OBS_DOC
                    LEFT JOIN GCOBS O2 ON O2.CVE_OBS = G.CVE_OBS_PAR
                    WHERE CVE_GASTO = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                While dr.Read
                    If UnaVez Then
                        UnaVez = False
                        TCVE_GASTO.Text = dr("CVE_GASTO").ToString
                        TCVE_UNI.Text = dr("CVE_UNI").ToString
                        L2.Text = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                        TCVE_GASTO.Tag = dr.ReadNullAsEmptyLong("CVE_OBS_DOC")
                        TCVE_UNI.Tag = dr.ReadNullAsEmptyString("DES_DOC")
                        LtObs.Text = dr.ReadNullAsEmptyString("DES_DOC")
                    End If
                    z += 1
                    Fg(z, 1) = dr("CVE_ART")
                    Fg(z, 3) = BUSCA_CAT("InveS", dr("CVE_ART"))
                    Fg(z, 4) = BUSCA_ALMACEN(dr("NUM_ALM"))
                    Fg(z, 5) = dr("COSTO")
                    Fg(z, 6) = dr("COSTO") * 0.16
                    Fg(z, 7) = dr("COSTO") * 1.16
                    Fg(z, 8) = dr("DES_PAR")
                    Fg(z, 9) = dr("CVE_OBS_PAR")
                    Fg(z, 10) = dr("UUID")
                End While
                dr.Close()

                BarGrabar.Enabled = False
                BarEliminarPart.Enabled = False

                TCVE_GASTO.Enabled = False
                TCVE_UNI.Select()

                SET_ALL_CONTROL_READ_AND_ENABLED(Me)

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Function BUSCA_ALMACEN() As String
        Dim CADENA_ALM As String = ""
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_ALM, DESCR FROM ALMACENES" & Empresa & " WHERE CVE_ALM <> 1 ORDER BY CVE_ALM"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CADENA_ALM = Format(dr("CVE_ALM"), "00") & " " & dr("DESCR")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Return CADENA_ALM
    End Function
    Sub CARGA_PARAM_INVENT()
        If Not Valida_Conexion() Then
            Return
        End If
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT ISNULL(MULTIALMACEN,0) AS M_ULTIALMACEN, ISNULL(AFEC_TABLA_INVE,0) AS AFE_TAB_INV, ISNULL(CVE_ALM_RNBDO, -1) AS ALM_RBDO, 
                ISNULL(CVE_ART_RNBDO,'') AS ART_RBDO, ISNULL(CVE_ART_REPARA,'') AS ART_REPARA, ISNULL(CVE_ART_NUEVAS,'') AS CVE_ART_NEW, 
                ISNULL(CVE_CPTO_RENOVADO,0) AS CVE_CPTO_REN, ISNULL(CVE_CPTO_RENOVADO_ENT,0) AS CVE_CPTO_REN_ENT
                FROM GCPARAMINVENT"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                CVE_ALM_RNBDO = dr("ALM_RBDO")
                CVE_ART_RNBDO = dr("ART_RBDO")
            End If
            dr.Close()
        Catch ex As Exception
            Bitacora("29. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("29. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Sub FrmGastoRenovadoAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BtnUnidades_Click(sender As Object, e As EventArgs) Handles BtnUnidades.Click
        Try
            Var2 = "Unidades"
            Var3 = ""
            Var4 = ""
            Var5 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_UNI.Text = Var3
                L2.Text = Var6
                L2.Tag = Var9
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = "" : Var9 = ""
                Fg.Focus()
                Fg.Row = 1
                Fg.Col = 1
                Fg.StartEditing()
            End If
        Catch Ex As Exception
            MsgBox("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("290. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnUnidades_Click(Nothing, Nothing)
                Return
            End If
            Try
                If e.KeyCode = 13 Then
                    Fg.Focus()
                    Fg.Row = 1
                    Fg.Col = 1
                    Fg.StartEditing()
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCVE_UNI_Validated(sender As Object, e As EventArgs) Handles TCVE_UNI.Validated
        Try
            If TCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", TCVE_UNI.Text)
                If DESCR <> "" Then
                    L2.Text = DESCR
                    L2.Tag = Var5
                Else
                    MsgBox("Unidad inexistente")
                    TCVE_UNI.Text = ""
                    TCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        If Fg.Row > 0 Then
            Try
                If ENTRA Then
                    ENTRA = False

                    If Fg.Col = 3 Or Fg.Col = 6 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 9 Then
                        Fg.FinishEditing()
                    Else
                        Fg.StartEditing()
                    End If
                End If
                ENTRA = True
            Catch ex As Exception
                Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        If Fg.Row > 0 Then
            Try
                If ENTRA Then
                    ENTRA = False
                    If Fg.Col = 3 Or Fg.Col = 6 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 9 Then
                        e.Cancel = True
                    End If
                    ENTRA = True
                End If
            Catch ex As Exception
                Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        If Fg.Row > 0 Then
            Try
                If ENTRA Then
                    ENTRA = False
                    If Fg.Col = 3 Or Fg.Col = 6 Or Fg.Col = 7 Or Fg.Col = 8 Or Fg.Col = 9 Then
                        Fg.FinishEditing()
                    Else
                        Fg.StartEditing()
                    End If
                    ENTRA = True
                End If
            Catch ex As Exception
                Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub Fg_ComboCloseUp(sender As Object, e As RowColEventArgs) Handles Fg.ComboCloseUp
        Try

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        If Fg.Row > 0 Then
            If Fg.Col = 4 Then
                If e.KeyCode = Keys.Down Then
                    e.Handled = True
                End If
                If e.KeyCode = 13 Then
                    Fg.Col = 5
                    Fg.StartEditing()
                    Return
                End If
            End If
            If Fg.Col = 5 Then
                ENTRA = False
                Fg.Row += 1
                Fg.Col = 1
                ENTRA = True
                e.Handled = True
                Return
            End If
        End If
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 44 And ENTRA Then
                    ENTRA = False
                    If e.KeyCode = 13 Then
                        Fg.Col = 5
                        Fg.StartEditing()
                    End If
                    ENTRA = True
                    'e.Handled = True
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Fg.PreviewKeyDown
        If Fg.Row > 0 Then
            If e.KeyCode = 9 Then
                If Fg.Col = 4 Then
                    'Fg.Col = 5
                    'Fg.StartEditing()
                    cl = 5
                    TMAGICO.Focus()
                    'Fg.StartEditing()
                End If
            End If
            If e.KeyCode = 13 Then
                If Fg.Col = 4 Then
                    'Fg.Col = 5
                    'Fg.StartEditing()
                End If
            End If
        End If
    End Sub
    Private Sub TXT_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = Keys.F2 Then
                    Return
                End If
                If e.KeyCode = Keys.Right Then
                    If Fg.Col = 1 Then
                        ENTRA = False
                        Dim DESCR As String
                        DESCR = ""
                        If DESCR = "N" Or DESCR = "" Then

                            cl = 1
                            TMAGICO.Focus()
                            Fg.StartEditing()
                        Else
                            Fg(Fg.Row, 3) = DESCR
                        End If
                        ENTRA = True
                    End If
                End If
                If e.KeyCode = 13 And ENTRA Then
                    ENTRA = False
                    'e.Handled = True
                    If Fg.Col = 1 Then
                        ENTRA = True
                        Fg.Col = 4
                        Fg.FinishEditing()
                        'Fg_Click(Nothing, Nothing)
                        Return
                    End If
                    If Fg.Col = 4 Then
                        Fg.Col = 5
                        Fg.StartEditing()
                        ENTRA = True
                        Return
                    End If
                    ENTRA = True
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXT.PreviewKeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 9 Then
                    If Fg.Col = 1 Then
                        Fg.Col = 4
                        Return
                    End If
                    If Fg.Col = 4 Then
                        Fg.Col = 5
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXT_Validating(sender As Object, e As CancelEventArgs) Handles TXT.Validating
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 1 And ENTRA Then
                    If Fg.Editor.Text.Trim.Length > 0 Then
                        ENTRA = False
                        If CVE_ART_RNBDO = Fg.Editor.Text.Trim Then
                            Fg(Fg.Row, 3) = BUSCA_CAT("InveS", Fg.Editor.Text)
                        Else
                            MsgBox("Clave incorrecta")
                            cl = 1
                            TMAGICO.Focus()
                            Fg.StartEditing()
                            e.Cancel = True
                        End If
                        ENTRA = True
                    End If

                    ENTRA = True
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTN.KeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 13 Then
                    If Fg.Col = 5 Then

                        Var4 = Fg(Fg.Row, 8)
                        TIPO_COMPRA = "o"
                        FrmObserDocumento.ShowDialog()
                        Fg(Fg.Row, 8) = Var4


                        ENTRA = False
                        Fg.Row += 1
                        Fg.Col = 1
                        ENTRA = True
                        e.Handled = True

                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TXTN.PreviewKeyDown
        Try
            If Fg.Row > 0 Then
                If e.KeyCode = 9 Then
                    If Fg.Col = 5 Then
                        Fg.Row += 1
                        Fg.Col = 1
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TXTN_Validating(sender As Object, e As CancelEventArgs) Handles TXTN.Validating
        Try
            If Fg.Row > 0 Then
                If Fg.Col = 5 Then
                    If Not IsNothing(Fg.Editor) Then
                        If Fg.Editor.Text.Trim.Length > 0 Then
                            If IsNumeric(Fg.Editor.Text) Then
                                Fg(Fg.Row, 6) = CDec(Fg.Editor.Text) * 0.16
                                Fg(Fg.Row, 7) = CDec(Fg.Editor.Text) * 1.16
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim CVE_ART As String, NUM_ALM As Integer = 1, COSTO As Decimal, CVE_OBS_DOC As Long = 0, CVE_OBS_PAR As Long = 0, DES_PAR As String = ""
        Dim ISALM As Boolean = False, ISCOST As Boolean = False, UUID As String = ""

        If TCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        Try
            For k = 1 To Fg.Rows.Count - 1
                CVE_ART = ""
                Try
                    If Not IsNothing(Fg(k, 1)) Then
                        CVE_ART = Fg(k, 1)
                    End If
                Catch ex As Exception
                    CVE_ART = ""
                    Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                Try
                    If Not IsNothing(Fg(k, 4)) Then
                        NUM_ALM = Fg(k, 4).ToString.Substring(0, 2)
                    End If
                Catch ex As Exception
                    Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                COSTO = 0
                Try
                    If Not IsNothing(Fg(k, 5)) Then
                        COSTO = Fg(k, 5)
                    End If
                Catch ex As Exception
                    Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                If CVE_ART.Trim.Length > 0 Then
                    If NUM_ALM = 0 Then
                        ISALM = True
                    End If
                    If COSTO = 0 Then
                        ISCOST = True
                    End If
                End If
            Next
            If ISALM Then
                MsgBox("Almcen incorrectro verfique por favor ")
                Return
            End If
            If ISCOST Then
                MsgBox("El costo no pueden ser cero, verifique por favor")
                Return
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        Var4 = TCVE_UNI.Tag
        FrmObserDocumento.ShowDialog()
        TCVE_UNI.Tag = Var4
        LtObs.Text = Var4

        Try
            'tCVE_GASTO.Tag = dr.ReadNullAsEmptyLong("CVE_OBS_DOC")
            'tCVE_UNI.Tag = dr.ReadNullAsEmptyString("DES_DOC")
            If TCVE_UNI.Tag.Trim.Length > 0 Then
                If IsNumeric(TCVE_GASTO.Tag) Then
                    CVE_OBS_DOC = TCVE_GASTO.Tag
                Else
                    CVE_OBS_DOC = 0
                End If
                If CVE_OBS_DOC = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & TCVE_UNI.Tag & "')"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteScalar.ToString
                        If returnValue IsNot Nothing Then
                            If CLng(returnValue) > 0 Then
                                CVE_OBS_DOC = returnValue
                                TCVE_GASTO.Tag = returnValue
                            End If
                        End If
                    End Using
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & TCVE_UNI.Tag & "' WHERE CVE_OBS = " & CVE_OBS_DOC
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery.ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    End Using
                End If
            End If
        Catch ex As Exception
            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        SQL = "UPDATE GCGASTOS_RENOVADO SET CVE_ART = @CVE_ART, CVE_UNI = @CVE_UNI, NUM_ALM = @NUM_ALM, CVE_OBS_DOC = @CVE_OBS_DOC, CVE_OBS_PAR = @CVE_OBS_PAR,    
            COSTO = @COSTO
            WHERE CVE_GASTO = @CVE_GASTO AND UUID = @UUID
            IF @@ROWCOUNT = 0
            INSERT INTO GCGASTOS_RENOVADO (CVE_GASTO, STATUS, CVE_ART, CVE_UNI, NUM_ALM, FECHA, CVE_OBS_DOC, CVE_OBS_PAR, COSTO, FECHAELAB, UUID)
            VALUES (@CVE_GASTO, 'A', @CVE_ART, @CVE_UNI, @NUM_ALM, @FECHA, @CVE_OBS_DOC, @CVE_OBS_PAR, @COSTO, GETDATE(), NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                For k = 1 To Fg.Rows.Count - 1
                    CVE_ART = ""
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_ART = Fg(k, 1)
                        End If
                    Catch ex As Exception
                        CVE_ART = ""
                        Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 4)) Then
                            NUM_ALM = Fg(k, 4).ToString.Substring(0, 2)
                        End If
                    Catch ex As Exception
                        Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                    COSTO = 0
                    Try
                        If Not IsNothing(Fg(k, 5)) Then
                            COSTO = Fg(k, 5)
                        End If
                    Catch ex As Exception
                        Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    If CVE_ART.Trim.Length > 0 And Fg.Rows(k).IsVisible Then
                        Try
                            'Fg(z, 8) = dr("DES_PAR")
                            'Fg(z, 9) = dr("CVE_OBS_PAR")
                            If Not IsNothing(Fg(k, 9)) Then
                                If IsNumeric(Fg(k, 9)) Then
                                    CVE_OBS_PAR = Fg(k, 9)
                                End If
                            End If
                            If Not IsNothing(Fg(k, 8)) Then
                                DES_PAR = Fg(k, 8)
                            End If

                            If DES_PAR.Trim.Length > 0 Then
                                If CVE_OBS_PAR = 0 Then
                                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & DES_PAR & "')"
                                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                        cmd2.CommandText = SQL
                                        returnValue = cmd2.ExecuteScalar.ToString
                                        If returnValue IsNot Nothing Then
                                            If CLng(returnValue) > 0 Then
                                                CVE_OBS_PAR = returnValue
                                                Fg(k, 9) = CVE_OBS_PAR
                                            End If
                                        End If
                                    End Using
                                Else
                                    SQL = "UPDATE GCOBS SET DESCR = '" & DES_PAR & "' WHERE CVE_OBS = " & CVE_OBS_PAR
                                    Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                        cmd3.CommandText = SQL
                                        returnValue = cmd3.ExecuteNonQuery.ToString
                                        If returnValue IsNot Nothing Then
                                            If returnValue = "1" Then
                                            End If
                                        End If
                                    End Using
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        Try
                            If IsNothing(Fg(k, 10)) Then
                                UUID = ""
                            Else
                                UUID = Fg(k, 10)
                            End If
                        Catch ex As Exception
                        End Try
                        Try
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_GASTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(TCVE_GASTO.Text)
                            cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART
                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = TCVE_UNI.Text
                            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
                            cmd.Parameters.Add("@NUM_ALM", SqlDbType.SmallInt).Value = NUM_ALM
                            cmd.Parameters.Add("@CVE_OBS_DOC", SqlDbType.Int).Value = CVE_OBS_DOC
                            cmd.Parameters.Add("@CVE_OBS_PAR", SqlDbType.Int).Value = CVE_OBS_PAR
                            cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = COSTO
                            cmd.Parameters.Add("@UUID", SqlDbType.VarChar).Value = UUID
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then

                                End If
                            End If
                        Catch ex As Exception
                            MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Next
            End Using

            For k = 1 To Fg.Rows.Count - 1
                If Not Fg.Rows(k).IsVisible Then
                    Try
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            SQL = "DELETE FROM GCGASTOS_RENOVADO WHERE UUID = '" & Fg(k, 10) & "'"
                            cmd.CommandText = SQL
                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                End If
                            End If
                        End Using
                    Catch ex As Exception
                        MsgBox("16. " & ex.Message & vbNewLine & ex.StackTrace)
                        Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next

            MsgBox("Proceso terminado")

            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub CboAlmacen_KeyDown(sender As Object, e As KeyEventArgs) Handles CboAlmacen.KeyDown
        If e.KeyCode = 13 Then
            cl = 5
            TMAGICO.Focus()

            Fg.StartEditing()
        End If
    End Sub
    Private Sub TMAGICO_GotFocus(sender As Object, e As EventArgs) Handles TMAGICO.GotFocus
        Try
            Fg.Focus()
            Fg.Col = cl
            'TXT.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CboAlmacen_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles CboAlmacen.PreviewKeyDown
        If Fg.Row > 0 Then
            If e.KeyCode = 9 Then
                Fg.Col = 5
                Fg.StartEditing()
            End If
            If e.KeyCode = 13 Then
                Fg.Col = 5
            End If
        End If
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BarEliminarPart.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                    Fg.Rows(Fg.Row).Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarXls_Click(sender As Object, e As EventArgs) Handles BarXls.Click
        Try
            EXPORTAR_EXCEL_TRANSPORT(Fg, "Gastos de venta")
        Catch ex As Exception
        End Try
    End Sub
End Class
