Imports System.Xml
Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.C1Excel
Imports C1.Win.C1Input

Public Class FrmImportAsigLlantasExcel
    Private Sub FrmImportAsigLlantasExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            With Screen.PrimaryScreen.WorkingArea
                Me.SetBounds(.Left, .Top, .Width, .Height)
            End With
            Me.WindowState = FormWindowState.Maximized
            Fg.Width = Me.Width - 25
            Fg.Height = Me.Height - 100 - CboHojas.Top - CboHojas.Height

            Fg.Rows(0).Height = 50
            Fg.Rows.Count = 1
            CboColumna.Items.Clear()

            For k = 65 To 90
                CboColumna.Items.Add(Chr(k))
                CboPos.Items.Add(Chr(k))
                CboNumEcon.Items.Add(Chr(k))
            Next

            CboTipoUnidad.Items.Add("Tractor")
            CboTipoUnidad.Items.Add("Remolque")
            CboTipoUnidad.Items.Add("Dolly")

            'BarLlanta.Text = "Subir llantas" & vbNewLine & "al catálogo"
            'BarImportarUnidades.Text = "Subir Unidades" & vbNewLine & "al catálogo"
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmImportAsigLlantasExcel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnExcel_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        Try
            Dim openExcelFileDialog As New OpenFileDialog With {
                .Filter = "Excel files (*.xls or .xlsx)|*.xls;*.xlsx",
                .FilterIndex = 1,
                .RestoreDirectory = True
            }
            If openExcelFileDialog.ShowDialog() = DialogResult.OK Then
                TExcel.Text = openExcelFileDialog.FileName
                CARGAR_HOJAS()
            Else
                TExcel.Text = ""
            End If
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub CARGAR_HOJAS()
        Try
            C1XLBook1.Clear()
            C1XLBook1.Load(TExcel.Text)

            Dim source As XLSheet = C1XLBook1.Sheets(0)
            CboHojas.Items.Clear()
            For k = 0 To C1XLBook1.Sheets.Count - 1
                CboHojas.Items.Add(C1XLBook1.Sheets(k).Name)
            Next

            CboHojas.SelectedIndex = 0
            Fg.Rows.Count = 1

        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarCargarArchivoExcel_Click(sender As Object, e As EventArgs) Handles barCargarArchivoExcel.Click
        Dim row As Integer, z As Integer = 999, h As Integer, CADENA As String, Letra As String

        'CboHojas.Items.Add("Table")

        If TExcel.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un archivo de excel")
            Return
        End If
        If CboHojas.SelectedIndex = -1 Then
            MsgBox("Por favor una hoja")
            CboHojas.Select()

            Return
        End If

        Try
            Fg.Rows.Count = 1
            Fg.Cols.Count = 2
            Fg.Refresh()
            Application.DoEvents()
            If z = 999 Then
                Me.Cursor = Cursors.WaitCursor

                Fg.LoadExcel(TExcel.Text, CboHojas.Text, FileFlags.ExcludeEmptyRows + FileFlags.IncludeFixedCells)
                Me.Cursor = Cursors.Default
                Fg.Cols.Insert(0)
                h = 65
                Letra = ""
                For k = 1 To Fg.Cols.Count - 1
                    Fg(0, k) = Fg(0, k) & " " & Letra & Chr(h) & "" & " (" & k & ")"
                    h = h + 1
                    If h > 90 Then
                        h = 65
                        Letra = "A"
                    End If
                Next
                Fg.AutoSizeCols()

                Fg.Cols.Count = Fg.Cols.Count + 8

                MessageBox.Show("Proceso terminado")
                Return
            End If

            z = 1
            C1XLBook1.Clear()
            C1XLBook1.Load(TExcel.Text)
        Catch ex As Exception
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Dim source As XLSheet = C1XLBook1.Sheets(CboHojas.SelectedIndex)

        Me.Cursor = Cursors.WaitCursor
        Fg.Cursor = Cursors.WaitCursor

        Try
            Fg.Cols.Count = source.Columns.Count + 1

            For k = 0 To source.Columns.Count - 1
                Application.DoEvents()
                Try
                    If Not IsNothing(source(0, k).Value) Then
                        If source(0, k).Value.ToString.Trim.Length = 0 Then
                            h = k
                            Exit For
                        Else
                            Fg(0, k + 1) = source(0, k).Value
                        End If
                    Else
                        h = k
                        Exit For
                    End If
                Catch ex As Exception
                    Bitacora("170. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            h = 65
            Letra = ""
            For k = 1 To Fg.Cols.Count - 1
                Fg(0, k) = Fg(0, k) & " (" & Letra & Chr(h) & ")"
                h = h + 1
                If h > 90 Then
                    h = 65
                    Letra = "A"
                End If
            Next

            For row = 1 To source.Rows.Count - 1
                Application.DoEvents()
                CADENA = ""
                For k = 0 To source.Columns.Count - 1
                    Try
                        If Not IsNothing(source(row, k).Value) Then
                            CADENA = CADENA & source(row, k).Value & vbTab
                        Else
                            CADENA = CADENA & "" & vbTab
                        End If
                    Catch ex As Exception
                        CADENA = CADENA & "" & vbTab
                    End Try
                Next
                If CADENA.Trim.Length > 0 Then
                    Fg.AddItem(z & vbTab & CADENA)
                    Lt6.Text = "Llantas " & z
                    z = z + 1
                End If
            Next row

            Lt6.Text = "Partidas " & Fg.Rows.Count - 1

            Fg.AutoSizeCols()


        Catch ex As Exception
            Bitacora("200. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("200. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Me.Cursor = Cursors.Default
        Fg.Cursor = Cursors.Default
        MsgBox("Proceso terminado")

    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If Fg.Rows.Count = 1 Then
                MsgBox("Por favor primero cargue la hoja de excel")
                Return
            End If

            If CboColumna.SelectedIndex = -1 Then
                MsgBox("Por favor seleccioba la columna donde se encuentra la unidad")
                Return
            End If
            If CboPos.SelectedIndex = -1 Then
                MsgBox("Por favor seleccioba la columna donde se encuentra la posicion de la llanta")
                Return
            End If
            If CboNumEcon.SelectedIndex = -1 Then
                MsgBox("Por favor seleccioba la columna donde se encuentra en numero economico de la llanta")
                Return
            End If

            Dim rUni As Integer, rPos As Integer, rNumEco As Integer
            Dim CVE_UNI As String = "", POS As Integer, NUM_ECON As String = "", CADENA As String = "", CADENA2 As String = "", CVE_LLANTA As Integer

            Try
                SQL = "UPDATE GCUNIDADES SET CHLL1 = '',  CHLL2 = '',  CHLL3 = '',  CHLL4 = '',  CHLL5 = '',  CHLL6 = '',  CHLL7 = '',  CHLL8 = '',  CHLL9 = '',  CHLL10 = '',  CHLL11 = '',  CHLL12 = ''"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            Catch ex As Exception
                Bitacora("230. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("230. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            Fg.Cols(0).Width = 40
            Fg.Select()

            rUni = CboColumna.SelectedIndex + 1
            rPos = CboPos.SelectedIndex + 1
            rNumEco = CboNumEcon.SelectedIndex + 1

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                CADENA = ""
                Try
                    CVE_UNI = ""
                    Try
                        If Not IsNothing(Fg(k, rUni)) Then
                            CVE_UNI = Fg(k, rUni)
                        End If
                    Catch ex As Exception
                    End Try
                    POS = 0
                    Try
                        If Not IsNothing(Fg(k, rPos)) Then
                            POS = Fg(k, rPos)
                        End If

                    Catch ex As Exception
                        POS = 0
                    End Try
                    NUM_ECON = ""
                    Try
                        If Not IsNothing(Fg(k, rNumEco)) Then
                            NUM_ECON = Fg(k, rNumEco)
                        End If
                    Catch ex As Exception
                    End Try

                    CVE_LLANTA = 0
                    If NUM_ECON.Trim.Length > 0 And CVE_UNI.Trim.Length > 0 Then
                        Try
                            SQL = "SELECT ISNULL(CVE_LLANTA,0) AS CVE_LLA FROM GCLLANTAS WHERE STATUS <> 'B' AND NUM_ECONOMICO = '" & NUM_ECON & "'"

                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                Using dr As SqlDataReader = cmd.ExecuteReader
                                    If dr.Read Then
                                        CVE_LLANTA = dr("CVE_LLA").ToString.Trim
                                    End If
                                End Using
                            End Using

                            If CVE_LLANTA > 0 Then
                                Select Case POS
                                    Case 1
                                        CADENA = "CHLL1 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL1,'') = '' "
                                    Case 2
                                        CADENA = "CHLL2 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL2,'') = '' "
                                    Case 3
                                        CADENA = "CHLL3 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL3,'') = '' "
                                    Case 4
                                        CADENA = "CHLL4 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL4,'') = '' "
                                    Case 5
                                        CADENA = "CHLL5 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL5,'') = '' "
                                    Case 6
                                        CADENA = "CHLL6 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL6,'') = '' "
                                    Case 7
                                        CADENA = "CHLL7 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL7,'') = '' "
                                    Case 8
                                        CADENA = "CHLL8 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL8,'') = '' "
                                    Case 9
                                        CADENA = "CHLL9 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL9,'') = '' "
                                    Case 10
                                        CADENA = "CHLL10 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL10,'') = '' "
                                    Case 11
                                        CADENA = "CHLL11 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL11,'') = '' "
                                    Case 12
                                        CADENA = "CHLL12 = '" & CVE_LLANTA & "'"
                                        CADENA2 = " AND ISNULL(CHLL12,'') = '' "
                                End Select

                                If CADENA.Trim.Length > 0 Then
                                    Try
                                        SQL = "UPDATE GCUNIDADES SET " & CADENA & " WHERE CLAVEMONTE = '" & CVE_UNI & "'" & CADENA2
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                    Lt6.Text = "Llantas " & k
                                                Else
                                                    Fg(k, 0) = Fg(k, 0) & "<"
                                                End If
                                            Else
                                                Fg(k, 0) = Fg(k, 0) & ">"
                                            End If
                                        End Using
                                    Catch ex As Exception
                                        Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End If
                        Catch ex As Exception
                            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("270. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("270. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BarLlanta_Click(sender As Object, e As EventArgs)
        Dim UNI As String, ExistEconomico As Boolean

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            If Fg.Rows.Count = 1 Then
                MsgBox("Por favor primero cargue la hoja de excel")
                Return
            End If

            If MsgBox("Realmente desea importar las llantas?", vbYesNo) = vbNo Then
                Return
            End If

            If CboColumna.Items.Count = 1 Then
                MsgBox("Por favor seleccioba la columna donde se encuentra la unidad")
                Return
            End If

            Dim CVE_UNI As String = "", POS As Integer = 0, NUM_ECON As String = "", CADENA As String = "", CADENA2 As String = "", CVE_LLANTA As Integer = 0
            Dim MARCA As String = "", MEDIDA As String = "", DISENO As String = "", MM As String = "", O_R As String = "", KM As String = "", FECHA_MON As String = ""
            Dim OBS_STR As String = "", CVE_MED As Integer, CVE_MARCA As String = "", CVE_OBS As Long = 0, z As Long, ESTATUS As String = "", TIPO_LLANTA As String = ""
            Dim CVE_TIPO_LLAN As String = ""

            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE
            'Fg.Cols(0).Width = 40
            Fg.Select()
            z = 0
            For k = 2 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try

                    Try
                        NUM_ECON = ""
                        If Not IsNothing(Fg(k, 3)) Then
                            NUM_ECON = Fg(k, 3)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        MARCA = ""
                        If Not IsNothing(Fg(k, 5)) Then
                            MARCA = Fg(k, 5)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        MEDIDA = ""
                        If Not IsNothing(Fg(k, 7)) Then
                            MEDIDA = Fg(k, 7)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        DISENO = ""
                        If Not IsNothing(Fg(k, 6)) Then
                            DISENO = Fg(k, 6)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        MM = ""
                        If Not IsNothing(Fg(k, 8)) Then
                            MM = Fg(k, 8)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        FECHA_MON = ""
                        If Not IsNothing(Fg(k, 1)) Then
                            FECHA_MON = Fg(k, 1)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        CVE_UNI = ""
                        If Not IsNothing(Fg(k, 2)) Then
                            CVE_UNI = Fg(k, 2)
                            If CVE_UNI.Length > 10 Then
                                CVE_UNI = CVE_UNI.Substring(0, 10).Replace(" ", "")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        KM = ""
                        If Not IsNothing(Fg(k, 9)) Then
                            KM = Fg(k, 9)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        POS = 0
                        If Not IsNothing(Fg(k, 4)) Then
                            If IsNumeric(Fg(k, 4)) Then
                                POS = Fg(k, 4)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        ESTATUS = ""
                        'If Not IsNothing(Fg(k, 10)) Then
                        'ESTATUS = Fg(k, 10)
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        O_R = ""
                        'If Not IsNothing(Fg(k, 11)) Then
                        'O_R = Fg(k, 11)
                        'End If
                    Catch ex As Exception
                    End Try
                    Try
                        TIPO_LLANTA = ""
                        If Not IsNothing(Fg(k, 10)) Then
                            TIPO_LLANTA = Fg(k, 10)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        OBS_STR = ""
                        'If Not IsNothing(Fg(k, 23)) Then
                        'OBS_STR = Fg(k, 23)
                        'End If
                    Catch ex As Exception
                    End Try
                    If MEDIDA.Trim.Length > 0 Then
                        CVE_MED = GET_MEDIDA_LLANTA(MEDIDA)
                    End If
                    If MARCA.Trim.Length > 0 Then
                        CVE_MARCA = GET_MARCA_LLANTA(MARCA)
                    End If
                    If ESTATUS.Trim.Length > 0 Then
                        ESTATUS = GET_LLANTA_STATUS(ESTATUS)
                    End If
                    If TIPO_LLANTA.Trim.Length > 0 Then
                        CVE_TIPO_LLAN = GET_TIPO_LLANTA(TIPO_LLANTA)
                    End If
                    Try
                        If OBS_STR.Trim.Length > 0 Then

                            SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS), @OBS_STR)"
                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                                cmd.Parameters.Add("@OBS_STR", SqlDbType.VarChar).Value = OBS_STR
                                returnValue = cmd.ExecuteScalar.ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        If IsNumeric(returnValue.ToString) Then
                                            CVE_OBS = returnValue.ToString
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If
                    Catch ex As Exception
                        Bitacora("310. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    CVE_LLANTA = 0
                    If NUM_ECON.Trim.Length > 0 And MARCA.Trim.Length > 0 And MEDIDA.Trim.Length > 0 And DISENO.Trim.Length > 0 Then
                        Try
                            SQL = "SELECT ISNULL(CVE_LLANTA,0) AS CVE_LLA FROM GCLLANTAS WHERE STATUS <> 'B' AND NUM_ECONOMICO = '" & NUM_ECON & "'"

                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr As SqlDataReader = cmd2.ExecuteReader
                                    If dr.Read Then
                                        CVE_LLANTA = dr("CVE_LLA").ToString.Trim
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("320. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("320. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try

                        If NUM_ECON = "18749" Or NUM_ECON = "18750" Or NUM_ECON = "103" Then
                            NUM_ECON = NUM_ECON
                        End If

                        UNI = BUSCA_CAT("Unidades", CVE_UNI) = ""
                        If UNI = "" Then
                            CVE_UNI = ""
                        End If
                        If CVE_UNI = "0" Then
                            CVE_UNI = ""
                        End If

                        If CVE_LLANTA = 0 Then
                            CVE_LLANTA = GET_MAX("GCLLANTAS", "CVE_LLANTA")
                        End If

                        Try
                            ExistEconomico = False
                            SQL = "SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND NUM_ECONOMICO = '" & NUM_ECON & "' AND POSICION = " & POS
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                Using dr As SqlDataReader = cmd2.ExecuteReader
                                    If dr.Read Then
                                        ExistEconomico = True
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                        If Not ExistEconomico And CVE_UNI.Trim.Length > 0 And POS > 0 Then
                            Try
                                SQL = "SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE STATUS <> 'B' AND UNIDAD = '" & CVE_UNI & "' AND POSICION = " & POS
                                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                    cmd2.CommandText = SQL
                                    Using dr As SqlDataReader = cmd2.ExecuteReader
                                        If dr.Read Then
                                            ExistEconomico = True
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                Bitacora("325. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("325. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End If

                        If NUM_ECON = "18758" Then
                            NUM_ECON = NUM_ECON
                        End If

                        'If Not ExistEconomico And POS > 0 Then

                        SQL = "UPDATE GCLLANTAS SET UNIDAD = @UNIDAD, POSICION = @POSICION, NUM_ECONOMICO = @NUM_ECONOMICO, DISENO = @DISENO, O_R = @O_R, FECHA_MON = @FECHA_MON, " &
                                "MARCA = @MARCA, KM = @KM, STATUS_LLANTA = @STATUS_LLANTA, MEDIDA = @MEDIDA, PROFUNDIDAD_ACTUAL = @PROFUNDIDAD_ACTUAL, CVE_OBS = @CVE_OBS, " &
                                "TIPO_LLANTA = @TIPO_LLANTA " &
                                "WHERE NUM_ECONOMICO = @NUM_ECONOMICO " &
                                "IF @@ROWCOUNT = 0 " &
                                "INSERT INTO GCLLANTAS (CVE_LLANTA, STATUS, UNIDAD, POSICION, NUM_ECONOMICO, DISENO, O_R, FECHA_MON, MARCA, KM, STATUS_LLANTA, MEDIDA, " &
                                "PROFUNDIDAD_ACTUAL, CVE_OBS, TIPO_LLANTA) VALUES (@CVE_LLANTA, 'A', @UNIDAD, @POSICION, @NUM_ECONOMICO, @DISENO, @O_R, @FECHA_MON, @MARCA, " &
                                "@KM, @STATUS_LLANTA, @MEDIDA, @PROFUNDIDAD_ACTUAL, @CVE_OBS, @TIPO_LLANTA)"
                        cmd.CommandText = SQL
                        Try
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_LLANTA", SqlDbType.VarChar).Value = CVE_LLANTA
                            cmd.Parameters.Add("@UNIDAD", SqlDbType.VarChar).Value = CVE_UNI
                            cmd.Parameters.Add("@POSICION", SqlDbType.VarChar).Value = POS
                            cmd.Parameters.Add("@NUM_ECONOMICO", SqlDbType.VarChar).Value = NUM_ECON
                            cmd.Parameters.Add("@DISENO", SqlDbType.VarChar).Value = DISENO
                            cmd.Parameters.Add("@O_R", SqlDbType.VarChar).Value = O_R
                            If IsNothing(FECHA_MON) Then
                                cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = DBNull.Value
                            Else
                                If IsDate(FECHA_MON) Then
                                    cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = FECHA_MON
                                Else
                                    cmd.Parameters.Add("@FECHA_MON", SqlDbType.Date).Value = DBNull.Value
                                End If
                            End If
                            cmd.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = CVE_MARCA
                            cmd.Parameters.Add("@KM", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(KM)
                            cmd.Parameters.Add("@STATUS_LLANTA", SqlDbType.VarChar).Value = ESTATUS
                            cmd.Parameters.Add("@MEDIDA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(CVE_MED)
                            cmd.Parameters.Add("@PROFUNDIDAD_ACTUAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(MM)
                            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
                            cmd.Parameters.Add("@TIPO_LLANTA", SqlDbType.VarChar).Value = CVE_TIPO_LLAN

                            returnValue = cmd.ExecuteNonQuery().ToString
                            If returnValue IsNot Nothing Then
                                If returnValue = "1" Then
                                    z = z + 1
                                    Lt7.Text = "Altas " & z & " Número económico:" & NUM_ECON
                                End If
                            End If

                            If CVE_UNI.Trim.Length > 0 Then
                                Try
                                    CADENA = ""
                                    Select Case POS
                                        Case 1
                                            CADENA = "CHLL1 = '" & CVE_LLANTA & "'"
                                        Case 2
                                            CADENA = "CHLL2 = '" & CVE_LLANTA & "'"
                                        Case 3
                                            CADENA = "CHLL3 = '" & CVE_LLANTA & "'"
                                        Case 4
                                            CADENA = "CHLL4 = '" & CVE_LLANTA & "'"
                                        Case 5
                                            CADENA = "CHLL5 = '" & CVE_LLANTA & "'"
                                        Case 6
                                            CADENA = "CHLL6 = '" & CVE_LLANTA & "'"
                                        Case 7
                                            CADENA = "CHLL7 = '" & CVE_LLANTA & "'"
                                        Case 8
                                            CADENA = "CHLL8 = '" & CVE_LLANTA & "'"
                                        Case 9
                                            CADENA = "CHLL9 = '" & CVE_LLANTA & "'"
                                        Case 10
                                            CADENA = "CHLL10 = '" & CVE_LLANTA & "'"
                                        Case 11
                                            CADENA = "CHLL11 = '" & CVE_LLANTA & "'"
                                        Case 12
                                            CADENA = "CHLL12 = '" & CVE_LLANTA & "'"
                                    End Select
                                Catch ex As Exception
                                    Bitacora("330. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("330. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try

                                If CADENA.Trim.Length > 0 Then

                                    Try
                                        If NUM_ECON = "103" Then
                                            NUM_ECON = NUM_ECON
                                        End If

                                        SQL = "UPDATE GCUNIDADES SET " & CADENA & " WHERE CLAVEMONTE = '" & CVE_UNI & "'"
                                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                            cmd2.CommandText = SQL
                                            returnValue = cmd2.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                        If CVE_UNI = "TR-070" Then
                                            NUM_ECON = NUM_ECON
                                        End If
                                    Catch ex As Exception
                                        Bitacora("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                        MsgBox("240. " & ex.Message & vbNewLine & ex.StackTrace)
                                    End Try
                                End If
                            End If
                            Lt6.Text = k & " de " & Fg.Rows.Count - 1
                        Catch ex As Exception
                            Bitacora("340. " & ex.Message & vbNewLine & ex.StackTrace)
                            'MsgBox("340. " & ex.Message & vbNewLine & ex.StackTrace)
                            Fg(k, 12) = "1. Numero economico y posicion Duplicados"
                            Fg.TopRow = k
                        End Try
                        'Else
                        '   Fg(k, 12) = "2. Posicion mas de una vez"
                        '    Fg.TopRow = k
                        'End If
                    End If
                Catch ex As Exception
                    Bitacora("360. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("360. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
                'Exit For
            Next

            Lt6.Text = Fg.Rows.Count - 1 & " de " & Fg.Rows.Count - 1

            MsgBox("Proceso terminado")

        Catch ex As Exception
            Bitacora("370. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("370. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function GET_TIPO_LLANTA(fTIPO_LLANTA As String) As String
        Dim CVE_TIPO_LLANTA As String = ""
        Try
            SQL = "SELECT ISNULL(CVE_TIPO,'') AS CVE_TIPO_LLANTA FROM GCLLANTA_TIPO WHERE DESCR = '" & fTIPO_LLANTA & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_TIPO_LLANTA = dr("CVE_TIPO_LLANTA")
                    End If
                End Using
            End Using
            Return CVE_TIPO_LLANTA
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_TIPO_LLANTA
        End Try
    End Function
    Private Function GET_LLANTA_STATUS(fSTATUS As String) As String
        Dim CVE_ST As String = ""
        Try
            SQL = "SELECT ISNULL(CVE_STATUS,0) AS CVE_ST FROM GCLLANTA_STATUS WHERE DESCR = '" & fSTATUS & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_ST = dr("CVE_ST")
                    End If
                End Using
            End Using
            Return CVE_ST
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_ST
        End Try
    End Function
    Private Function GET_MEDIDA_LLANTA(fMEDIDA As String) As Integer
        Dim CVE_MED As Integer = 0
        Try
            SQL = "SELECT ISNULL(CVE_MED,0) AS CVE_ME FROM GCLLANTA_MEDIDA WHERE DESCR = '" & fMEDIDA & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MED = dr("CVE_ME")
                    End If
                End Using
            End Using
            Return CVE_MED
        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_MED
        End Try
    End Function
    Private Function GET_MARCA_LLANTA(fMARCA As String) As String
        Dim CVE_MARCA As String = ""
        Try
            SQL = "SELECT ISNULL(CVE_MARCA,'') AS CVE_MAR FROM GCMARCAS WHERE DESCR = '" & fMARCA & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MARCA = dr("CVE_MAR")
                    End If
                End Using
            End Using
            Return CVE_MARCA
        Catch ex As Exception
            Bitacora("500. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("500. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_MARCA
        End Try
    End Function

    Private Sub BarImportarUnidades_Click(sender As Object, e As EventArgs)
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar las unidades?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Dim CLAVEMONTE As String, CVE_MARCA As String, CVE_MODELO As String, NIV As String
            Dim CVE_TIPO_UNI As String
            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CLAVEMONTE = Fg(k, 1)
                            If CLAVEMONTE.Length > 10 Then
                                CLAVEMONTE = CLAVEMONTE.Substring(0, 10)
                            End If
                        Else
                            CLAVEMONTE = ""
                        End If
                    Catch ex As Exception
                        CLAVEMONTE = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 4)) Then
                            CVE_MARCA = GET_MARCA(Fg(k, 4))
                        Else
                            CVE_MARCA = ""
                        End If
                    Catch ex As Exception
                        CVE_MARCA = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 6)) Then
                            CVE_MODELO = GET_MODELO(Fg(k, 6))
                        Else
                            CVE_MODELO = ""
                        End If
                    Catch ex As Exception
                        CVE_MODELO = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 3)) Then
                            NIV = Fg(k, 3)
                        Else
                            NIV = ""
                        End If
                    Catch ex As Exception
                        NIV = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 7)) Then
                            CVE_TIPO_UNI = "" 'GET_TIPO_UNI(Fg(k, 7))
                        Else
                            CVE_TIPO_UNI = ""
                        End If
                    Catch ex As Exception
                        CVE_TIPO_UNI = ""
                    End Try
                    If CLAVEMONTE.Trim.Length > 0 Then
                        SQL = "IF NOT EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = @CLAVEMONTE) " &
                          "INSERT INTO GCUNIDADES (CLAVE, STATUS, CLAVEMONTE, CVE_MARCA, CVE_MODELO, NUM_SERIE_UNI, CVE_TIPO_UNI) " &
                          "VALUES (@CLAVE, 'A', @CLAVEMONTE, @CVE_MARCA, @CVE_MODELO, @NUM_SERIE_UNI, @CVE_TIPO_UNI)"
                        Try
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = GET_MAX("GCUNIDADES", "CLAVE")
                                cmd.Parameters.Add("@CLAVEMONTE", SqlDbType.VarChar).Value = CLAVEMONTE
                                cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = CVE_MARCA
                                cmd.Parameters.Add("@CVE_MODELO", SqlDbType.VarChar).Value = CVE_MODELO
                                cmd.Parameters.Add("@NUM_SERIE_UNI", SqlDbType.VarChar).Value = NIV
                                cmd.Parameters.Add("@CVE_TIPO_UNI", SqlDbType.VarChar).Value = CVE_TIPO_UNI
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z = z + 1
                                        Lt7.Text = "Altas " & z & " Clave:" & CLAVEMONTE
                                    End If
                                End If
                                Lt6.Text = k & " de " & Fg.Rows.Count - 1

                            End Using
                        Catch ex As Exception
                            Bitacora("520. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("520. " & ex.Message & vbNewLine & ex.StackTrace)
                        End Try
                    End If
                Catch ex As Exception
                    Bitacora("560. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            Lt6.Text = Fg.Rows.Count - 1 & " de " & Fg.Rows.Count - 1

            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("570. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("570. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function GET_TIPO_UNI(fCVE_TIPO_UNI As String) As String
        Dim CVE_TIPO_UNI As String = ""
        Try
            If fCVE_TIPO_UNI.Trim.Length > 0 Then
                SQL = "SELECT ISNULL(CVE_UNI,'') AS CVE_TIPO_UNI FROM GCTIPO_UNIDAD WHERE DESCR = '" & fCVE_TIPO_UNI & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_TIPO_UNI = dr("CVE_TIPO_UNI")
                        End If
                    End Using
                End Using
            End If
            Return CVE_TIPO_UNI
        Catch ex As Exception
            Bitacora("600. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("600. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_TIPO_UNI
        End Try
    End Function
    Private Function GET_MODELO(fMODELO As String) As String
        Dim CVE_MODELO As String = ""
        Try
            If fMODELO.Trim.Length > 0 Then
                SQL = "SELECT ISNULL(CVE_MOD,'') AS CVE_MODDELO FROM GCMODELO_UNIDAD WHERE DESCR = '" & fMODELO & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_MODELO = dr("CVE_MODDELO")
                        End If
                    End Using
                End Using
            End If
            Return CVE_MODELO
        Catch ex As Exception
            Bitacora("620. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("620. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_MODELO
        End Try
    End Function
    Private Function GET_MARCA(fMARCA As String) As String
        Dim CVE_MARCA As String = ""
        Try
            SQL = "SELECT ISNULL(CVE_MARCA,'') AS CVE_MAR FROM GCMARCAUNIDAD WHERE DESCR = '" & fMARCA & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MARCA = dr("CVE_MAR")
                    End If
                End Using
            End Using
            Return CVE_MARCA
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbNewLine & ex.StackTrace)
            Return CVE_MARCA
        End Try
    End Function
    Private Sub BarEliminar_Click(sender As Object, e As EventArgs) Handles BarEliminar.Click
        Try
            'If Fg.Row > 0 Then
            Fg.RemoveItem(Fg.Row)
            ' End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarInven_Click(sender As Object, e As EventArgs) Handles BarInven.Click

        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar inventario?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Dim CVE_ART As String, DESCR As String, LIN_PROD As String = "", UNI_MED As String, COSTO As Single, STOCK_MIN As Single, STOCK_MAX As Single
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_ART = Fg(k, 1)
                            If CVE_ART.Length > 16 Then
                                CVE_ART = CVE_ART.Substring(0, 16)
                            End If
                        Else
                            CVE_ART = ""
                        End If
                    Catch ex As Exception
                        CVE_ART = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            DESCR = Fg(k, 2)
                            If DESCR.Length > 40 Then
                                DESCR = CVE_ART.Substring(0, 16)
                            End If
                        Else
                            DESCR = ""
                        End If
                    Catch ex As Exception
                        DESCR = ""
                    End Try
                    Lt6.Text = k
                    Lt7.Text = CVE_ART

                    'clave	descripcion	Linea	Unidad de medida	costo sin impuestos	Stock minimo	Stock Maximo
                    Try
                        If Not IsNothing(Fg(k, 3)) Then
                            LIN_PROD = Fg(k, 3)
                        Else
                            LIN_PROD = ""
                        End If
                    Catch ex As Exception
                        UNI_MED = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 4)) Then
                            UNI_MED = Fg(k, 4)
                        Else
                            UNI_MED = ""
                        End If
                    Catch ex As Exception
                        UNI_MED = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 5)) Then
                            If IsNumeric(Fg(k, 5)) Then
                                COSTO = Fg(k, 5)
                            Else
                                COSTO = 0
                            End If
                        Else
                            COSTO = 0
                        End If
                    Catch ex As Exception
                        COSTO = 0
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 6)) Then
                            If IsNumeric(Fg(k, 6)) Then
                                STOCK_MIN = Fg(k, 6)
                            Else
                                STOCK_MIN = 0
                            End If
                        Else
                            STOCK_MIN = 0
                        End If
                    Catch ex As Exception
                        STOCK_MIN = 0
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 7)) Then
                            If IsNumeric(Fg(k, 7)) Then
                                STOCK_MAX = Fg(k, 7)
                            Else
                                STOCK_MAX = 0
                            End If
                        Else
                            STOCK_MAX = 0
                        End If
                    Catch ex As Exception
                        STOCK_MAX = 0
                    End Try

                    If CVE_ART.Trim.Length > 0 Then

                        SQL = "UPDATE INVE" & Empresa & " SET CVE_ART = @CVE_ART, DESCR = @DESCR, LIN_PROD = @LIN_PROD, CON_SERIE = @CON_SERIE, UNI_MED = @UNI_MED, " &
                            "UNI_EMP = @UNI_EMP, CTRL_ALM = @CTRL_ALM, TIEM_SURT = @TIEM_SURT, STOCK_MIN = @STOCK_MIN, STOCK_MAX = @STOCK_MAX, " &
                            "TIP_COSTEO = @TIP_COSTEO, NUM_MON = @NUM_MON, FCH_ULTCOM = @FCH_ULTCOM, FCH_ULTVTA = @FCH_ULTVTA, PEND_SURT = @PEND_SURT, " &
                            "COSTO_PROM = @COSTO_PROM, ULT_COSTO = @ULT_COSTO, CVE_OBS = @CVE_OBS, TIPO_ELE = @TIPO_ELE, UNI_ALT = @UNI_ALT, FAC_CONV = @FAC_CONV, " &
                            "APART = @APART, CON_LOTE = @CON_LOTE, CON_PEDIMENTO = @CON_PEDIMENTO, PESO = @PESO, VOLUMEN = @VOLUMEN, CVE_ESQIMPU = @CVE_ESQIMPU, " &
                            "VTAS_ANL_C = @VTAS_ANL_C, VTAS_ANL_M = @VTAS_ANL_M, COMP_ANL_C = @COMP_ANL_C, COMP_ANL_M = @COMP_ANL_M, CUENT_CONT = @CUENT_CONT, " &
                            "CVE_IMAGEN = @CVE_IMAGEN, MAN_IEPS = @MAN_IEPS, APL_MAN_IMP = @APL_MAN_IMP, CUOTA_IEPS = @CUOTA_IEPS, APL_MAN_IEPS = @APL_MAN_IEPS, " &
                            "CVE_PRODSERV = @CVE_PRODSERV, CVE_UNIDAD = @CVE_UNIDAD " &
                            "WHERE CVE_ART = @CVE_ART " &
                            "IF @@ROWCOUNT = 0 " &
                            "INSERT INTO INVE" & Empresa & " (CVE_ART, STATUS, DESCR, LIN_PROD, CON_SERIE, UNI_MED, UNI_EMP, CTRL_ALM, TIEM_SURT, STOCK_MIN, STOCK_MAX, " &
                            "TIP_COSTEO, NUM_MON, FCH_ULTCOM, FCH_ULTVTA, PEND_SURT, EXIST, COSTO_PROM, ULT_COSTO, CVE_OBS, TIPO_ELE, UNI_ALT, FAC_CONV, APART, CON_LOTE, " &
                            "CON_PEDIMENTO, PESO, VOLUMEN, CVE_ESQIMPU, VTAS_ANL_C, VTAS_ANL_M, COMP_ANL_C, COMP_ANL_M, CUENT_CONT, CVE_IMAGEN, MAN_IEPS, APL_MAN_IMP, " &
                            "CUOTA_IEPS, APL_MAN_IEPS, CVE_PRODSERV, CVE_UNIDAD, UUID, VERSION_SINC) VALUES(@CVE_ART, 'A', @DESCR, @LIN_PROD, @CON_SERIE, @UNI_MED, @UNI_EMP, @CTRL_ALM, " &
                            "@TIEM_SURT, @STOCK_MIN, @STOCK_MAX, @TIP_COSTEO, @NUM_MON, @FCH_ULTCOM, @FCH_ULTVTA, @PEND_SURT, 0, @COSTO_PROM, @ULT_COSTO, @CVE_OBS, " &
                            "@TIPO_ELE, @UNI_ALT, @FAC_CONV, @APART, @CON_LOTE, @CON_PEDIMENTO, @PESO, @VOLUMEN, @CVE_ESQIMPU, @VTAS_ANL_C, @VTAS_ANL_M, @COMP_ANL_C, " &
                            "@COMP_ANL_M, @CUENT_CONT, @CVE_IMAGEN, @MAN_IEPS, @APL_MAN_IMP, @CUOTA_IEPS, @APL_MAN_IEPS, @CVE_PRODSERV, @CVE_UNIDAD, NEWID(), GETDATE())"

                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            cmd.CommandText = SQL
                            cmd.CommandText = SQL
                            Try
                                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART
                                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = DESCR
                                cmd.Parameters.Add("@LIN_PROD", SqlDbType.VarChar).Value = LIN_PROD
                                cmd.Parameters.Add("@CON_SERIE", SqlDbType.VarChar).Value = "N"
                                cmd.Parameters.Add("@UNI_MED", SqlDbType.VarChar).Value = UNI_MED
                                cmd.Parameters.Add("@UNI_EMP", SqlDbType.Float).Value = 1
                                cmd.Parameters.Add("@CTRL_ALM", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@TIEM_SURT", SqlDbType.Int).Value = 0
                                cmd.Parameters.Add("@STOCK_MIN", SqlDbType.Float).Value = STOCK_MIN
                                cmd.Parameters.Add("@STOCK_MAX", SqlDbType.Float).Value = STOCK_MAX
                                cmd.Parameters.Add("@TIP_COSTEO", SqlDbType.VarChar).Value = "P"
                                cmd.Parameters.Add("@NUM_MON", SqlDbType.Int).Value = 1
                                cmd.Parameters.Add("@FCH_ULTCOM", SqlDbType.DateTime).Value = Now
                                cmd.Parameters.Add("@FCH_ULTVTA", SqlDbType.DateTime).Value = Now
                                cmd.Parameters.Add("@PEND_SURT", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@COSTO_PROM", SqlDbType.Float).Value = COSTO
                                cmd.Parameters.Add("@ULT_COSTO", SqlDbType.Float).Value = COSTO
                                cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = 0
                                cmd.Parameters.Add("@TIPO_ELE", SqlDbType.VarChar).Value = "P"
                                cmd.Parameters.Add("@UNI_ALT", SqlDbType.VarChar).Value = UNI_MED
                                cmd.Parameters.Add("@FAC_CONV", SqlDbType.Float).Value = 1
                                cmd.Parameters.Add("@APART", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@CON_LOTE", SqlDbType.VarChar).Value = "N"
                                cmd.Parameters.Add("@CON_PEDIMENTO", SqlDbType.VarChar).Value = "N"
                                cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@VOLUMEN", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.Int).Value = 1
                                cmd.Parameters.Add("@VTAS_ANL_C", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@VTAS_ANL_M", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@COMP_ANL_C", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@COMP_ANL_M", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@CUENT_CONT", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@CVE_IMAGEN", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@MAN_IEPS", SqlDbType.VarChar).Value = "N"
                                cmd.Parameters.Add("@APL_MAN_IMP", SqlDbType.Int).Value = 1
                                cmd.Parameters.Add("@CUOTA_IEPS", SqlDbType.Float).Value = 0
                                cmd.Parameters.Add("@APL_MAN_IEPS", SqlDbType.VarChar).Value = "C"
                                cmd.Parameters.Add("@CVE_PRODSERV", SqlDbType.VarChar).Value = ""
                                cmd.Parameters.Add("@CVE_UNIDAD", SqlDbType.VarChar).Value = ""
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        GRABAR_PRECIOS(CVE_ART)
                                        GRABAR_CAMPLIB(CVE_ART)
                                    End If

                                End If
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                                MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                            End Try
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_PRECIOS(fCVE_ART As String)
        Try
            Dim cmd As New SqlCommand
            Dim CVE_PRECIO As Integer
            Dim PRECIO As Single

            cmd.Connection = cnSAE

            For k = 1 To 3
                CVE_PRECIO = k
                PRECIO = 0

                SQL = "IF NOT EXISTS (SELECT PRECIO FROM PRECIO_X_PROD" & Empresa & " WHERE CVE_ART = '" & fCVE_ART & "' AND CVE_PRECIO = " & CVE_PRECIO & ") " &
                    "IF @@ROWCOUNT = 0 " &
                    "INSERT INTO PRECIO_X_PROD" & Empresa & " (CVE_ART, CVE_PRECIO, PRECIO) VALUES('" & fCVE_ART & "','" & CVE_PRECIO & "','" & PRECIO & "')"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox("165. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("165. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_CAMPLIB(fCVE_ART As String)
        Dim cmd As New SqlCommand
        Try
            cmd.Connection = cnSAE
            '(<CVE_PROD, varchar(16),>           ,<CAMPLIB1, varchar(15),>           ,<CAMPLIB2, varchar(20),>           ,<CAMPLIB3, varchar(25),>           ,<CAMPLIB4, int,>
            ',<CAMPLIB5, float,>           ,<CAMPLIB6, float,>           ,<CAMPLIB7, varchar(255),>           ,<CAMPLIB8, varchar(255),>           ,<CAMPLIB9, varchar(255),>
            ',<CAMPLIB10, varchar(255),>           ,<CAMPLIB11, varchar(255),>           ,<CAMPLIB12, varchar(255),>)
            Try
                SQL = "IF NOT EXISTS (SELECT * FROM INVE_CLIB" & Empresa & " WHERE CVE_PROD = '" & fCVE_ART & "') " &
                    "INSERT INTO INVE_CLIB" & Empresa & " (CVE_PROD, CAMPLIB1, CAMPLIB2, CAMPLIB3, CAMPLIB4, CAMPLIB5, CAMPLIB6, CAMPLIB7, CAMPLIB8, " &
                    "CAMPLIB9, CAMPLIB10, CAMPLIB11, CAMPLIB12) VALUES('" & fCVE_ART & "',' ',' ',' ','0','0','0',' ',' ',' ',' ',' ',' ')"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            Catch ex As Exception
                Bitacora("175. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Catch ex As Exception
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarMult_Click(sender As Object, e As EventArgs) Handles BarMult.Click
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea creal multialmacen?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Dim CVE_ART As String, DESCR As String, LIN_PROD As String, UNI_MED As String, COSTO As Single, STOCK_MIN As Single, STOCK_MAX As Single
            Dim z As Integer, CVE_ALM As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try
                    Try
                        If Not IsNothing(Fg(k, 1)) Then
                            CVE_ART = Fg(k, 1)
                            If CVE_ART.Length > 16 Then
                                CVE_ART = CVE_ART.Substring(0, 16)
                            End If
                        Else
                            CVE_ART = ""
                        End If
                    Catch ex As Exception
                        CVE_ART = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 2)) Then
                            DESCR = Fg(k, 2)
                            If DESCR.Length > 40 Then
                                DESCR = CVE_ART.Substring(0, 16)
                            End If
                        Else
                            DESCR = ""
                        End If
                    Catch ex As Exception
                        DESCR = ""
                    End Try
                    Lt6.Text = k
                    Lt7.Text = CVE_ART

                    'clave	descripcion	Linea	Unidad de medida	costo sin impuestos	Stock minimo	Stock Maximo
                    Try
                        If Not IsNothing(Fg(k, 3)) Then
                            LIN_PROD = Fg(k, 3)
                        Else
                            LIN_PROD = ""
                        End If
                    Catch ex As Exception
                        UNI_MED = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 4)) Then
                            UNI_MED = Fg(k, 4)
                        Else
                            UNI_MED = ""
                        End If
                    Catch ex As Exception
                        UNI_MED = ""
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 5)) Then
                            If IsNumeric(Fg(k, 5)) Then
                                COSTO = Fg(k, 5)
                            Else
                                COSTO = 0
                            End If
                        Else
                            COSTO = 0
                        End If
                    Catch ex As Exception
                        COSTO = 0
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 6)) Then
                            If IsNumeric(Fg(k, 6)) Then
                                STOCK_MIN = Fg(k, 6)
                            Else
                                STOCK_MIN = 0
                            End If
                        Else
                            STOCK_MIN = 0
                        End If
                    Catch ex As Exception
                        STOCK_MIN = 0
                    End Try
                    Try
                        If Not IsNothing(Fg(k, 7)) Then
                            If IsNumeric(Fg(k, 7)) Then
                                STOCK_MAX = Fg(k, 7)
                            Else
                                STOCK_MAX = 0
                            End If
                        Else
                            STOCK_MAX = 0
                        End If
                    Catch ex As Exception
                        STOCK_MAX = 0
                    End Try

                    If CVE_ART.Trim.Length > 0 Then
                        z = z + 1
                        Lt6.Text = z
                        Lt7.Text = CVE_ART

                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT * FROM ALMACENES" & Empresa & " ORDER BY CVE_ALM"
                            cmd2.CommandText = SQL
                            Using dr As SqlDataReader = cmd2.ExecuteReader
                                While dr.Read

                                    CVE_ALM = dr.ReadNullAsEmptyInteger("CVE_ALM")

                                    If CVE_ALM > 0 Then
                                        SQL = "UPDATE MULT" & Empresa & " SET CTRL_ALM = @CTRL_ALM, STOCK_MIN = @STOCK_MIN, STOCK_MAX = @STOCK_MAX, COMP_X_REC = @COMP_X_REC " &
                                        "WHERE CVE_ART = @CVE_ART AND CVE_ALM = @CVE_ALM " &
                                        "IF @@ROWCOUNT = 0 " &
                                        "INSERT INTO MULT" & Empresa & " (CVE_ART, CVE_ALM, STATUS, CTRL_ALM, EXIST, STOCK_MIN, STOCK_MAX, " &
                                        "COMP_X_REC, UUID, VERSION_SINC) VALUES(@CVE_ART, @CVE_ALM, 'A', @CTRL_ALM, '0', @STOCK_MIN, @STOCK_MAX, @COMP_X_REC, NEWID(), GETDATE())"

                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            cmd.CommandText = SQL
                                            Try
                                                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = CVE_ART
                                                cmd.Parameters.Add("@CVE_ALM", SqlDbType.Int).Value = CVE_ALM
                                                cmd.Parameters.Add("@CTRL_ALM", SqlDbType.VarChar).Value = ""
                                                cmd.Parameters.Add("@STOCK_MIN", SqlDbType.Float).Value = STOCK_MIN
                                                cmd.Parameters.Add("@STOCK_MAX", SqlDbType.Float).Value = STOCK_MAX
                                                cmd.Parameters.Add("@COMP_X_REC", SqlDbType.Float).Value = 0
                                                returnValue = cmd.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then

                                                    End If
                                                End If
                                            Catch ex As Exception
                                                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                                                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                                            End Try
                                            cmd.CommandText = SQL
                                            returnValue = cmd.ExecuteNonQuery().ToString
                                            If returnValue IsNot Nothing Then
                                                If returnValue = "1" Then
                                                End If
                                            End If
                                        End Using
                                    End If
                                End While
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Operadores()
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar los operadores?", vbYesNo) = vbNo Then
            Return
        End If

        Try
            Dim CLAVE As Long = 0, CLAVE_MONTE As String = "", NOMBRE As String = "", AP_PAT_ As String = "", AP_MAT_ As String = "", COLONIA As String = ""
            Dim COLONIA_CLAVE_SAT As String = "", CD_POBLAC As String = "", LOCALIDAD_CLAVE_SAT As String = "", ESTADO As String = ""
            Dim ESTADO_CLAVE_SAT As String = "", COD_POST As String = "", MUNICIPIO As String = "", MUNICIPIO_CLAVE_SAT As String = ""
            Dim TELEFONO As String = "", SEXO As String = "", FECH_NACIM As String = "", CURP As String = ""
            Dim EMAIL As String = "", TELEFONO2 As String = "", NOMBRE_OPER As String = ""
            Dim R_F_C As String = "", IMSS As String = "", FECH_ALTA As String = "", CALLE As String = ""


            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try
                    Try
                        CLAVE_MONTE = "" : NOMBRE = "" : AP_PAT_ = "" : AP_MAT_ = "" : COLONIA = "" : COLONIA_CLAVE_SAT = "" : CD_POBLAC = ""
                        LOCALIDAD_CLAVE_SAT = "" : ESTADO = "" : ESTADO_CLAVE_SAT = "" : COD_POST = "" : MUNICIPIO = "" : MUNICIPIO_CLAVE_SAT = ""
                        TELEFONO = "" : SEXO = "" : FECH_NACIM = "" : CURP = "" : EMAIL = "" : TELEFONO2 = "" : NOMBRE_OPER = ""
                        R_F_C = "" : IMSS = "" : FECH_ALTA = "" : CALLE = ""

                        If Not IsNothing(Fg(k, 1)) Then CLAVE_MONTE = Fg(k, 1)
                        If Not IsNothing(Fg(k, 2)) Then NOMBRE = Fg(k, 2).ToString.Trim
                        If Not IsNothing(Fg(k, 3)) Then AP_PAT_ = Fg(k, 3).ToString.Trim
                        If Not IsNothing(Fg(k, 4)) Then AP_MAT_ = Fg(k, 4).ToString.Trim
                        If Not IsNothing(Fg(k, 4)) Then R_F_C = Fg(k, 6).ToString.Trim
                        If Not IsNothing(Fg(k, 4)) Then IMSS = Fg(k, 7).ToString.Trim
                        If Not IsNothing(Fg(k, 4)) Then FECH_ALTA = Fg(k, 8).ToString.Trim
                        If Not IsNothing(Fg(k, 11)) Then CALLE = Fg(k, 10).ToString.Trim

                        If Not IsNothing(Fg(k, 11)) Then COLONIA = Fg(k, 11).ToString.Trim
                        If Not IsNothing(Fg(k, 12)) Then COLONIA_CLAVE_SAT = Fg(k, 12).ToString.Trim
                        If Not IsNothing(Fg(k, 13)) Then CD_POBLAC = Fg(k, 13).ToString.Trim
                        If Not IsNothing(Fg(k, 14)) Then LOCALIDAD_CLAVE_SAT = Fg(k, 14).ToString.Trim
                        If Not IsNothing(Fg(k, 15)) Then ESTADO = Fg(k, 15).ToString.Trim
                        If Not IsNothing(Fg(k, 16)) Then ESTADO_CLAVE_SAT = Fg(k, 16).ToString.Trim
                        If Not IsNothing(Fg(k, 17)) Then COD_POST = Fg(k, 17).ToString.Trim
                        If Not IsNothing(Fg(k, 18)) Then MUNICIPIO = Fg(k, 18).ToString.Trim
                        If Not IsNothing(Fg(k, 19)) Then MUNICIPIO_CLAVE_SAT = Fg(k, 19).ToString.Trim
                        If Not IsNothing(Fg(k, 20)) Then TELEFONO = Fg(k, 20).ToString.Trim
                        If Not IsNothing(Fg(k, 21)) Then SEXO = Fg(k, 21).ToString.Trim
                        If Not IsNothing(Fg(k, 22)) Then FECH_NACIM = Fg(k, 22).ToString.Trim
                        If Not IsNothing(Fg(k, 23)) Then CURP = Fg(k, 23).ToString.Trim
                        If Not IsNothing(Fg(k, 24)) Then EMAIL = Fg(k, 24).ToString.Trim
                        If Not IsNothing(Fg(k, 25)) Then TELEFONO2 = Fg(k, 25).ToString.Trim
                    Catch ex As Exception
                        Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try

                    Lt6.Text = k
                    NOMBRE_OPER = NOMBRE & " " & AP_PAT_ & " " & AP_MAT_
                    Lt7.Text = NOMBRE_OPER

                    If NOMBRE.Trim.Length > 0 And AP_PAT_.Trim.Length > 0 And AP_MAT_.Trim.Length > 0 Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SELECT CLAVE FROM GCOPERADOR WHERE NOMBRE = '" & NOMBRE_OPER & "' OR CURP = '" & CURP & "' OR RFC = '" & R_F_C & "'"
                            cmd2.CommandText = SQL
                            Using dr As SqlDataReader = cmd2.ExecuteReader
                                If dr.Read Then
                                    CLAVE = dr.ReadNullAsEmptyDecimal("CLAVE")
                                    '  1        2       3      4        5      6      7          8        10       11           12              13             14            15
                                    'CLAVE	NOMBRE	AP_PAT_	AP_MAT_	STATUS	R_F_C_	IMSS	FECH_ALTA	CALLE	COLONIA	COLONIA CLAVE SAT	CD_POBLAC	LOCALIDAD_CLAVE SAT	ESTADO	
                                    '       16               17          18                19           20        21           22     23      24        25 
                                    'ESTADO CLAVE SAT	COD_POST	MUNICIPIO	MUNICIPIO_CLAVE_SAT	TELEFONO	SEXO	FECH_NACIM	CURP	EMAIL	TELEFONO2

                                    If CLAVE > 0 Then
                                        SQL = "UPDATE GCOPERADOR SET CLAVE_MONTE = @CLAVE_MONTE, NOMBRE = @NOMBRE, CURP = @CURP, TELEFONO = @TELEFONO, 
                                            COLONIA = @COLONIA, CP = @CP, CIUDAD = @CIUDAD, CVE_ESTADO = @CVE_ESTADO, FECHANAC = @FECHANAC, CORREO = @CORREO, 
                                            NOMBRE_OPER = @NOMBRE_OPER, AP_PATERNO = @AP_PATERNO, AP_MATERNO = @AP_MATERNO, COLONIA_SAT = @COLONIA_SAT, 
                                            MUNICIPIO = @MUNICIPIO, MUNICIPIO_SAT = @MUNICIPIO_SAT, POBLACION_SAT = @POBLACION_SAT, ESTADO_SAT = @ESTADO_SAT, 
                                            PAIS = @PAIS, RFC = @RFC, IMSS = @IMSS, CALLE = @CALLE, PAIS_SAT = @PAIS_SAT
                                            WHERE CLAVE = @CLAVE"
                                        Using cmd As SqlCommand = cnSAE.CreateCommand
                                            Try
                                                cmd.CommandText = SQL
                                                cmd.Parameters.Clear()
                                                cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = CLAVE
                                                cmd.Parameters.Add("@CLAVE_MONTE", SqlDbType.VarChar).Value = CLAVE_MONTE
                                                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = NOMBRE_OPER
                                                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = R_F_C
                                                cmd.Parameters.Add("@IMSS", SqlDbType.VarChar).Value = IMSS
                                                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = CALLE

                                                cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = CURP
                                                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = TELEFONO
                                                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = COLONIA
                                                cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = COD_POST
                                                cmd.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = CD_POBLAC
                                                cmd.Parameters.Add("@CVE_ESTADO", SqlDbType.SmallInt).Value = 30
                                                cmd.Parameters.Add("@FECHANAC", SqlDbType.Date).Value = FECH_NACIM
                                                cmd.Parameters.Add("@CORREO", SqlDbType.VarChar).Value = EMAIL
                                                cmd.Parameters.Add("@NOMBRE_OPER", SqlDbType.VarChar).Value = NOMBRE
                                                cmd.Parameters.Add("@AP_PATERNO", SqlDbType.VarChar).Value = AP_PAT_
                                                cmd.Parameters.Add("@AP_MATERNO", SqlDbType.VarChar).Value = AP_MAT_
                                                cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = COLONIA_CLAVE_SAT
                                                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = MUNICIPIO
                                                cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = MUNICIPIO_CLAVE_SAT
                                                cmd.Parameters.Add("@POBLACION_SAT", SqlDbType.VarChar).Value = LOCALIDAD_CLAVE_SAT
                                                cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = ESTADO_CLAVE_SAT
                                                cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = "MEXICO"
                                                cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = "52"
                                                returnValue = cmd.ExecuteNonQuery().ToString
                                                If returnValue IsNot Nothing Then
                                                    If returnValue = "1" Then
                                                        z = z + 1
                                                        Lt6.Text = z & "/" & Fg.Rows.Count - 1
                                                    End If
                                                End If
                                            Catch ex As Exception
                                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                                MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                            End Try
                                        End Using

                                    End If
                                Else
                                    Fg(k, 0) = "N"
                                End If
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub ClientesOperativos()

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try

            Dim SUMA As Decimal = 0, J As Integer

            For J = 1 To Fg.Rows.Count - 1
                Fg(J, 6) = ""
                Fg(J, 7) = ""
                Fg(J, 9) = 0
                Fg(J, 10) = 0
            Next
            Try
                For k = 1 To Fg.Rows.Count - 1
                    For J = 1 To Fg.Rows.Count - 1
                        If Fg(k, 1) = Fg(J, 3) Then
                            Fg(k, 6) = "ok"
                            Fg(J, 6) = "ok2"
                        End If
                    Next
                Next

            Catch ex As Exception
                Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
            For k = 1 To Fg.Rows.Count - 1
                For J = 1 To Fg.Rows.Count - 1
                    Try
                        If Fg(k, 3) = Fg(J, 1) Then
                            Fg(J, 7) = "si"
                        End If
                    Catch ex As Exception
                        Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                Next
            Next

            'For k = 1 To Fg.Rows.Count - 1
            ' SUMA = Fg(k, 7)
            ' For j = 1 To Fg.Rows.Count - 1
            'If (Math.Truncate(CDec(Fg(k, 9))) + Math.Truncate(CDec(Fg(k, 10)))) = 0 Then
            'Fg(k, 11) = Math.Truncate(CDec(Fg(k, 8))) - Math.Truncate(CDec(Fg(k, 9)))
            'End If
            'Next
            'Next

            MsgBox("ok")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            Clipboard.Clear()
            Clipboard.SetText(Fg(Fg.Row, Fg.Col))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarClientes_Click(sender As Object, e As EventArgs) Handles BarClientes.Click
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar los clientes?", vbYesNo) = vbNo Then
            Return
        End If

        SQL = "TRUNCATE TABLE CLIE" & Empresa

        Using cmd As SqlCommand = cnSAE.CreateCommand
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                End If
            End If
        End Using

        Try
            Dim CLAVE As String = "", NOMBRE As String = "", DOMICILIO As String = "", DOMICILIO2 As String = "", PLANTA As String = "", NOTA As String = ""
            Dim COLONIA As String = "", COLONIA_SAT As String = "", MUNICIPIO As String = ""
            Dim MUNICIPIO_SAT As String = "", ESTADO As String = "", ESTADO_SAT As String = "", CP As String = "", CP_SAT As String = ""
            Dim PAIS As String = "", PAIS_SAT As String = "", RFC As String = "", LOCALIDAD As String = "", LOCALIDAD_SAT As String = ""


            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                Lt6.Text = k
                Lt7.Text = NOMBRE

                CLAVE = Space(10 - Convert.ToString(k).ToString.Length) & k
                NOMBRE = VD(Fg(k, 3), "S")

                If NOMBRE.Trim.Length > 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SET ansi_warnings OFF
                            INSERT INTO CLIE" & Empresa & " (CLAVE, STATUS, REFERDIR, NOMBRE, NOMBRECOMERCIAL, RFC, CURP, REG_FISC, DIASCRED, CAUSA_IVA, 
                            RETIENE_IVA, CUENTA_CONTABLE, METODODEPAGO, FORMADEPAGOSAT, USO_CFDI, APLICACION_PAGO_SAT, CATEGORIA, CRUZAMIENTOS, CRUZAMIENTOS2, 
                            CALLE, NUMEXT, CODIGO, COLONIA, COLONIA_SAT, LOCALIDAD_SAT, MUNICIPIO_SAT, ESTADO_SAT, CVE_PAIS_SAT) VALUES(
                            @CLAVE, 'A', @REFERDIR, @NOMBRE, @NOMBRECOMERCIAL, @RFC, @CURP, @REG_FISC, @DIASCRED, @CAUSA_IVA, @RETIENE_IVA, 
                            @CUENTA_CONTABLE, @METODODEPAGO, @FORMADEPAGOSAT, @USO_CFDI, @FORMADEPAGOSAT, @CATEGORIA, @CRUZAMIENTOS, @CRUZAMIENTOS2, 
                            @CALLE, @NUMEXT, @CODIGO, @COLONIA, @COLONIA_SAT, @LOCALIDAD_SAT, @MUNICIPIO_SAT, @ESTADO_SAT, @CVE_PAIS_SAT)"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            Try
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = CLAVE
                                cmd.Parameters.Add("@REFERDIR", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = VD(Fg(k, 3), "S")
                                cmd.Parameters.Add("@NOMBRECOMERCIAL", SqlDbType.VarChar).Value = VD(Fg(k, 4), "S")
                                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = VD(Fg(k, 5), "S")
                                cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = VD(Fg(k, 6), "S")
                                cmd.Parameters.Add("@REG_FISC", SqlDbType.VarChar).Value = VD(Fg(k, 7), "S")
                                cmd.Parameters.Add("@DIASCRED", SqlDbType.Float).Value = VD(Fg(k, 8), "N")
                                cmd.Parameters.Add("@CAUSA_IVA", SqlDbType.SmallInt).Value = VD(Fg(k, 9), "N")
                                cmd.Parameters.Add("@RETIENE_IVA", SqlDbType.SmallInt).Value = VD(Fg(k, 10), "N")
                                cmd.Parameters.Add("@CUENTA_CONTABLE", SqlDbType.VarChar).Value = VD(Fg(k, 11), "S")
                                cmd.Parameters.Add("@METODODEPAGO", SqlDbType.VarChar).Value = VD(Fg(k, 13), "S")
                                cmd.Parameters.Add("@FORMADEPAGOSAT", SqlDbType.VarChar).Value = VD(Fg(k, 12), "S")
                                cmd.Parameters.Add("@USO_CFDI", SqlDbType.VarChar).Value = VD(Fg(k, 14), "S")
                                cmd.Parameters.Add("@APLICACION_PAGO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                cmd.Parameters.Add("@CATEGORIA", SqlDbType.VarChar).Value = VD(Fg(k, 16), "S")
                                cmd.Parameters.Add("@CRUZAMIENTOS", SqlDbType.VarChar).Value = VD(Fg(k, 17), "S")
                                cmd.Parameters.Add("@CRUZAMIENTOS2", SqlDbType.VarChar).Value = VD(Fg(k, 18), "S")
                                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = VD(Fg(k, 19), "S")
                                cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = VD(Fg(k, 20), "S")
                                cmd.Parameters.Add("@POBLACION", SqlDbType.VarChar).Value = VD(Fg(k, 21), "S")
                                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = VD(Fg(k, 22), "S")
                                cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = VD(Fg(k, 23), "S")
                                cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 23), "S")
                                cmd.Parameters.Add("@LOCALIDAD_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 24), "S")
                                cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 25), "S")
                                cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 26), "S")
                                cmd.Parameters.Add("@CVE_PAIS_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 27), "S")
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z += 1
                                        Lt6.Text = z & "/" & Fg.Rows.Count - 1
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End Using
                    End Using
                End If
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function VD(FDATO As String, FTIPO As String) As String
        Dim DATO As String = ""
        Try
            If IsDBNull(FDATO) OrElse IsNothing(FDATO) Then
                Select Case FTIPO
                    Case "S"
                        DATO = ""
                    Case "N"
                        DATO = "0"
                    Case "D"
                        DATO = Now.ToShortDateString
                End Select
            Else
                Select Case FTIPO
                    Case "S"
                        DATO = FDATO.Replace("'", "")
                    Case "N"
                        If IsNumeric(FDATO) Then
                            DATO = FDATO
                        Else
                            DATO = "0"
                        End If
                    Case "D"
                        DATO = FDATO
                End Select
            End If
        Catch ex As Exception
        End Try

        Return DATO
    End Function

    Private Sub BarClie_OP_Click(sender As Object, e As EventArgs) Handles BarClie_OP.Click
        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar los clientes operativos?", vbYesNo) = vbNo Then
            Return
        End If

        SQL = "TRUNCATE TABLE CLIE" & Empresa

        Try
            Dim CLAVE As String = "", NOMBRE As String = "", DOMICILIO As String = "", DOMICILIO2 As String = "", PLANTA As String = "", NOTA As String = ""
            Dim COLONIA As String = "", COLONIA_SAT As String = "", MUNICIPIO As String = ""
            Dim MUNICIPIO_SAT As String = "", ESTADO As String = "", ESTADO_SAT As String = "", CP As String = "", CP_SAT As String = ""
            Dim PAIS As String = "", PAIS_SAT As String = "", RFC As String = "", LOCALIDAD As String = "", LOCALIDAD_SAT As String = ""


            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()
                Try

                    NOMBRE = VD(Fg(k, 3), "S")
                    Lt6.Text = k
                    Lt7.Text = NOMBRE

                    If NOMBRE.Trim.Length > 0 Then
                        Using cmd2 As SqlCommand = cnSAE.CreateCommand
                            SQL = "SET ansi_warnings OFF
                                INSERT INTO GCCLIE_OP (CLAVE, STATUS, NOTA, NOMBRE, DOMICILIO, DOMICILIO2, NUMEXT, COLONIA, RFC, CP, POBLACION, 
                                MUNICIPIO, ESTADO, PAIS, CP_SAT, COLONIA_SAT, POBLACION_SAT, MUNICIPIO_SAT, ESTADO_SAT, PAIS_SAT) VALUES(
                                @CLAVE, 'A', @NOTA, @NOMBRE, @DOMICILIO, @DOMICILIO2, @NUMEXT, @COLONIA, @RFC, @CP, @POBLACION, @MUNICIPIO, 
                                @ESTADO, @PAIS, @CP_SAT, @COLONIA_SAT, @POBLACION_SAT, @MUNICIPIO_SAT, @ESTADO_SAT, @PAIS_SAT)"
                            Using cmd As SqlCommand = cnSAE.CreateCommand
                                Try
                                    cmd.CommandText = SQL
                                    cmd.Parameters.Clear()
                                    cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TBOX.Text.Trim & VD(Fg(k, 1), "S")
                                    cmd.Parameters.Add("@NOTA", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                    cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = VD(Fg(k, 3), "S")
                                    cmd.Parameters.Add("@DOMICILIO", SqlDbType.VarChar).Value = VD(Fg(k, 5), "S")
                                    cmd.Parameters.Add("@DOMICILIO2", SqlDbType.VarChar).Value = VD(Fg(k, 6), "S")
                                    cmd.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = VD(Fg(k, 7), "S")
                                    cmd.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = VD(Fg(k, 8), "S")
                                    cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = VD(Fg(k, 4), "S")
                                    cmd.Parameters.Add("@CP", SqlDbType.VarChar).Value = VD(Fg(k, 10), "S")
                                    cmd.Parameters.Add("@POBLACION", SqlDbType.VarChar).Value = VD(Fg(k, 9), "S")
                                    cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = VD(Fg(k, 13), "S")
                                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = VD(Fg(k, 14), "S")
                                    cmd.Parameters.Add("@PAIS", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                    cmd.Parameters.Add("@CP_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 10), "S")
                                    cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 11), "S")
                                    cmd.Parameters.Add("@POBLACION_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 12), "S")
                                    cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 13), "S")
                                    cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 14), "S")
                                    cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                    returnValue = cmd.ExecuteNonQuery().ToString
                                    If returnValue IsNot Nothing Then
                                        If returnValue = "1" Then
                                            z += 1
                                            Lt6.Text = z & "/" & Fg.Rows.Count - 1
                                        End If
                                    End If
                                Catch ex As Exception
                                    Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                End Try
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub BarOperadores_Click(sender As Object, e As EventArgs) Handles BarOperadores.Click

        If Not Valida_Conexion() Then
            Return
        End If

        If MsgBox("Realmente desea importar los operadores?", vbYesNo) = vbNo Then
            Return
        End If

        SQL = "TRUNCATE TABLE GCOPERADOR"
        EXECUTE_QUERY_NET(SQL)
        SQL = "TRUNCATE TABLE GCGRUPO_SANGUINEO"
        EXECUTE_QUERY_NET(SQL)
        SQL = "TRUNCATE TABLE GCBANCOS"
        EXECUTE_QUERY_NET(SQL)

        Try
            Dim CLAVE As String = "", NOMBRE As String = ""
            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                Lt6.Text = k
                Lt7.Text = NOMBRE

                CLAVE = VD(Fg(k, 1), "S")
                NOMBRE = VD(Fg(k, 6), "S")

                If NOMBRE.Trim.Length > 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SET ansi_warnings OFF
                            INSERT INTO GCOPERADOR (CLAVE, STATUS, NOMBRE_OPER, AP_PATERNO, AP_MATERNO, NOMBRE, RFC, IMSS, LICENCIA, LICB, LICC, LICE, 
                            LIC_VENC, RESPONSABLE, CVE_BANCO, NUM_CUENTA, CVE_BANCO2, NUM_CUENTA2, CUEN_CONT, CVE_GRUSAN, ALERGIAS, FECHANAC, 
                            AVISAR_A, CURP, APODO, BENEFICIARIO, INE, DIRECCION1, DIRECCION2, CALLE, NUM_EXT, MUNICIPIO, CP_SAT, COLONIA_SAT, 
                            POBLACION_SAT, MUNICIPIO_SAT, ESTADO_SAT, PAIS_SAT, TELEFONO) VALUES (
                            @CLAVE, 'A', @NOMBRE_OPER, @AP_PATERNO, @AP_MATERNO, @NOMBRE, @RFC, @IMSS, @LICENCIA, @LICB, @LICC, @LICE, @LIC_VENC, 
                            @RESPONSABLE, @CVE_BANCO, @NUM_CUENTA, @CVE_BANCO2, @NUM_CUENTA2, @CUEN_CONT, @CVE_GRUSAN, @ALERGIAS, @FECHANAC, 
                            @AVISAR_A, @CURP, @APODO, @BENEFICIARIO, @INE, @DIRECCION1, @DIRECCION2, @CALLE, @NUM_EXT, @MUNICIPIO, @CP_SAT, 
                            @COLONIA_SAT, @POBLACION_SAT, @MUNICIPIO_SAT, @ESTADO_SAT, @PAIS_SAT, @TELEFONO)"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            Try
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()
                                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = CLAVE
                                cmd.Parameters.Add("@NOMBRE_OPER", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                cmd.Parameters.Add("@AP_PATERNO", SqlDbType.VarChar).Value = VD(Fg(k, 4), "S")
                                cmd.Parameters.Add("@AP_MATERNO", SqlDbType.VarChar).Value = VD(Fg(k, 5), "S")
                                cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = VD(Fg(k, 6), "S")
                                cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = VD(Fg(k, 7), "S")
                                cmd.Parameters.Add("@IMSS", SqlDbType.VarChar).Value = VD(Fg(k, 8), "S")
                                cmd.Parameters.Add("@LICENCIA", SqlDbType.VarChar).Value = VD(Fg(k, 9), "S")
                                cmd.Parameters.Add("@LICB", SqlDbType.SmallInt).Value = IIf(VD(Fg(k, 10), "S").ToString.IndexOf("B") > -1, 1, 0)
                                cmd.Parameters.Add("@LICC", SqlDbType.SmallInt).Value = IIf(VD(Fg(k, 10), "S").ToString.IndexOf("C") > -1, 1, 0)
                                cmd.Parameters.Add("@LICE", SqlDbType.SmallInt).Value = IIf(VD(Fg(k, 10), "S").ToString.IndexOf("E") > -1, 1, 0)
                                cmd.Parameters.Add("@LIC_VENC", SqlDbType.Date).Value = VD(Fg(k, 12), "D")
                                cmd.Parameters.Add("@RESPONSABLE", SqlDbType.VarChar).Value = VD(Fg(k, 13), "S")
                                cmd.Parameters.Add("@CVE_BANCO", SqlDbType.VarChar).Value = BUSCA_BANCO(VD(Fg(k, 14), "S"))
                                cmd.Parameters.Add("@NUM_CUENTA", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                cmd.Parameters.Add("@CVE_BANCO2", SqlDbType.VarChar).Value = BUSCA_BANCO(VD(Fg(k, 16), "S"))
                                cmd.Parameters.Add("@NUM_CUENTA2", SqlDbType.VarChar).Value = VD(Fg(k, 17), "S")
                                cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = VD(Fg(k, 18), "S")
                                cmd.Parameters.Add("@CVE_GRUSAN", SqlDbType.SmallInt).Value = BUSCA_GRUPO_SANGUINEO(VD(Fg(k, 19), "S"))
                                cmd.Parameters.Add("@ALERGIAS", SqlDbType.VarChar).Value = VD(Fg(k, 20), "S")
                                cmd.Parameters.Add("@FECHANAC", SqlDbType.Date).Value = VD(Fg(k, 21), "D")
                                cmd.Parameters.Add("@AVISAR_A", SqlDbType.VarChar).Value = VD(Fg(k, 22), "S")
                                cmd.Parameters.Add("@CURP", SqlDbType.VarChar).Value = VD(Fg(k, 23), "S")
                                cmd.Parameters.Add("@APODO", SqlDbType.VarChar).Value = VD(Fg(k, 24), "S")
                                cmd.Parameters.Add("@BENEFICIARIO", SqlDbType.VarChar).Value = VD(Fg(k, 25), "S")
                                cmd.Parameters.Add("@INE", SqlDbType.VarChar).Value = VD(Fg(k, 26), "S")
                                cmd.Parameters.Add("@DIRECCION1", SqlDbType.VarChar).Value = VD(Fg(k, 32), "S")
                                cmd.Parameters.Add("@DIRECCION2", SqlDbType.VarChar).Value = VD(Fg(k, 33), "S")
                                cmd.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = VD(Fg(k, 34), "S")
                                cmd.Parameters.Add("@NUM_EXT", SqlDbType.VarChar).Value = VD(Fg(k, 35), "S")
                                cmd.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = VD(Fg(k, 36), "S")
                                cmd.Parameters.Add("@CP_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 37), "S")
                                cmd.Parameters.Add("@COLONIA_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 38), "S")
                                cmd.Parameters.Add("@POBLACION_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 39), "S")
                                cmd.Parameters.Add("@MUNICIPIO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 40), "S")
                                cmd.Parameters.Add("@ESTADO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 41), "S")
                                cmd.Parameters.Add("@PAIS_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 42), "S")
                                cmd.Parameters.Add("@TELEFONO", SqlDbType.VarChar).Value = VD(Fg(k, 43), "S")
                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z += 1
                                        Lt6.Text = z & "/" & Fg.Rows.Count - 1
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                            End Try
                        End Using
                    End Using
                End If
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub
    Private Function BUSCA_BANCO(FBANCO As String) As Integer
        Dim BANCO As String = ""
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_BANCO, DESCR FROM GCBANCOS WHERE DESCR = '" & FBANCO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        BANCO = dr("CVE_BANCO")
                    Else
                        BANCO = GET_MAX_TRY("GCBANCOS", "CVE_BANCO")

                        SQL = "INSERT INTO GCBANCOS (CVE_BANCO, STATUS, DESCR) VALUES ('" & BANCO & "','A','" & FBANCO & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return BANCO
    End Function
    Private Function BUSCA_GRUPO_SANGUINEO(FGRUPO As String) As Integer
        Dim CVE_GRUSAN As Integer = 0
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_GRUSAN FROM GCGRUPO_SANGUINEO WHERE DESCR = '" & FGRUPO & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_GRUSAN = dr("CVE_GRUSAN")
                    Else
                        CVE_GRUSAN = GET_MAX("GCGRUPO_SANGUINEO", "CVE_GRUSAN")

                        SQL = "INSERT INTO GCGRUPO_SANGUINEO (CVE_GRUSAN, STATUS, DESCR) VALUES ('" & CVE_GRUSAN & "','A','" & FGRUPO & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CVE_GRUSAN

    End Function
    Private Sub BarUnidades_Click(sender As Object, e As EventArgs) Handles BarUnidades.Click

        If Not Valida_Conexion() Then
            Return
        End If

        If CboTipoUnidad.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione tipo de unidad")
            Return
        End If

        If MsgBox("Realmente desea importar unidades?", vbYesNo) = vbNo Then
            Return
        End If

        'SQL = "TRUNCATE TABLE GCUNIDADES"
        'EXECUTE_QUERY_NET(SQL)
        'SQL = "TRUNCATE TABLE GCMARCAS"
        'EXECUTE_QUERY_NET(SQL)
        'SQL = "TRUNCATE TABLE GCMODELO_UNIDAD"
        'EXECUTE_QUERY_NET(SQL)
        'SQL = "TRUNCATE TABLE GCTIPO_UNIDAD"
        'EXECUTE_QUERY_NET(SQL)
        'SQL = "TRUNCATE TABLE GCTIPO_COMBUSTIBLE"
        'EXECUTE_QUERY_NET(SQL)

        Try
            Dim CLAVE As String = "", NOMBRE As String = ""
            Dim z As Integer
            Lt6.Text = ""
            Lt7.Text = ""

            For k = 1 To Fg.Rows.Count - 1
                Application.DoEvents()

                Lt6.Text = k
                Lt7.Text = NOMBRE

                CLAVE = GET_MAX_TRY("GCUNIDADES", "CLAVE")
                NOMBRE = VD(Fg(k, 6), "S")

                If NOMBRE.Trim.Length > 0 Then
                    Using cmd2 As SqlCommand = cnSAE.CreateCommand
                        SQL = "SET ansi_warnings OFF
                            INSERT INTO GCUNIDADES (CLAVE, STATUS, CLAVEMONTE, DESCR, UNIDAD_PERMISI, NUM_SERIE_UNI, CVE_MARCA, ANO_MODELO, NUM_SERIE_MOT, 
                            TIPO_MOTOR, CVE_TIPO_UNI, CVE_TIPO_COM, NUM_EJES, PLACAS_MEX, NUM_TARJ_CIRCULACION, SE_ASEGURADORA, SE_VENC, ULTIMO_KM, 
                            ULTIMO_CAMBIO_ACEITE, KMCAMBIOACEITE, ULTCAMBIOACEITEDIF, KMCAMBIOACEITEDIF, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, 
                            FECHA_VERIFICACION, OD_TARJ_IAVE, CUEN_CONT, PESO, UNIDAD_PESO, LARGO, ID_UMLONGITUD, FECHACOMPRA, NUMFACTURA,
                            IMPORTECOMPRA, FECHALECTURAODOMETRO, TMC, FEC_ULT_SER, CUEN_CONT2, BASEOPERACION, CAPACIDAD, COLOR, CONFIG_AUTOTRANSPORTE_SAT, 
                            PERMISO_SCT, TIPO_PERMISO_SAT, NUMPOLIZASEGURO_DANOSAMBIENTALES, VENCIMIENTOSEGURO_DANOSAMBIENTALES, SUBTIPOREM, 
                            PARTETRANSPORTE) VALUES (
                            @CLAVE, 'A', @CLAVEMONTE, @DESCR, @UNIDAD_PERMISI, @NUM_SERIE_UNI, @CVE_MARCA, @ANO_MODELO, @NUM_SERIE_MOT, 
                            @TIPO_MOTOR, @CVE_TIPO_UNI, @CVE_TIPO_COM, @NUM_EJES, @PLACAS_MEX, @NUM_TARJ_CIRCULACION, @SE_ASEGURADORA, @SE_VENC, 
                            @ULTIMO_KM, @ULTIMO_CAMBIO_ACEITE, @KMCAMBIOACEITE, @ULTCAMBIOACEITEDIF, @KMCAMBIOACEITEDIF, @CVE_TANQUE1, @CVE_TANQUE2, 
                            @CVE_DOLLY, @FECHA_VERIFICACION, @OD_TARJ_IAVE, @CUEN_CONT, @PESO, @UNIDAD_PESO, @LARGO, @ID_UMLONGITUD, @FECHACOMPRA, 
                            @NUMFACTURA, @IMPORTECOMPRA, @FECHALECTURAODOMETRO, @TMC, @FEC_ULT_SER, @CUEN_CONT2, @BASEOPERACION, @CAPACIDAD, @COLOR, 
                            @CONFIG_AUTOTRANSPORTE_SAT, @PERMISO_SCT, @TIPO_PERMISO_SAT, @NUMPOLIZASEGURO_DANOSAMBIENTALES, 
                            @VENCIMIENTOSEGURO_DANOSAMBIENTALES, @SUBTIPOREM, @PARTETRANSPORTE)"
                        Using cmd As SqlCommand = cnSAE.CreateCommand
                            Try
                                cmd.CommandText = SQL
                                cmd.Parameters.Clear()

                                Select Case CboTipoUnidad.SelectedIndex
                                    Case 0
                                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = CLAVE
                                        cmd.Parameters.Add("@CLAVEMONTE", SqlDbType.VarChar).Value = TBOX.Text.Trim & VD(Fg(k, 1), "S")
                                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                        cmd.Parameters.Add("@UNIDAD_PERMISI", SqlDbType.VarChar).Value = VD(Fg(k, 4), "N")
                                        cmd.Parameters.Add("@NUM_SERIE_UNI", SqlDbType.VarChar).Value = VD(Fg(k, 5), "S")
                                        cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = BUSCA_MARCA(VD(Fg(k, 6), "S"))
                                        cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = VD(Fg(k, 7), "S")
                                        cmd.Parameters.Add("@NUM_SERIE_MOT", SqlDbType.VarChar).Value = VD(Fg(k, 8), "S")
                                        cmd.Parameters.Add("@TIPO_MOTOR", SqlDbType.VarChar).Value = BUSCA_BANCO(VD(Fg(k, 9), "S"))
                                        cmd.Parameters.Add("@CVE_TIPO_UNI", SqlDbType.SmallInt).Value = 1
                                        cmd.Parameters.Add("@CVE_TIPO_COM", SqlDbType.SmallInt).Value = BUSCA_TIPO_COMBUSTIBLE(VD(Fg(k, 11), "N"))
                                        cmd.Parameters.Add("@NUM_EJES", SqlDbType.SmallInt).Value = VD(Fg(k, 12), "N")
                                        cmd.Parameters.Add("@PLACAS_MEX", SqlDbType.VarChar).Value = VD(Fg(k, 13), "S").ToString.Replace(" ", "")
                                        cmd.Parameters.Add("@NUM_TARJ_CIRCULACION", SqlDbType.VarChar).Value = VD(Fg(k, 14), "S")
                                        cmd.Parameters.Add("@SE_ASEGURADORA", SqlDbType.VarChar).Value = "1"
                                        cmd.Parameters.Add("@SE_NO_SEG", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                        cmd.Parameters.Add("@SE_VENC", SqlDbType.Date).Value = VD(Fg(k, 16), "S")
                                        cmd.Parameters.Add("@SE_TEL", SqlDbType.VarChar).Value = VD(Fg(k, 17), "S")

                                        cmd.Parameters.Add("@ULTIMO_KM", SqlDbType.Float).Value = VD(Fg(k, 19), "N")
                                        cmd.Parameters.Add("@ULTIMO_CAMBIO_ACEITE", SqlDbType.Date).Value = VD(Fg(k, 20), "D")
                                        cmd.Parameters.Add("@KMCAMBIOACEITE", SqlDbType.Float).Value = VD(Fg(k, 21), "N")
                                        cmd.Parameters.Add("@ULTCAMBIOACEITEDIF", SqlDbType.Date).Value = VD(Fg(k, 22), "D")
                                        cmd.Parameters.Add("@KMCAMBIOACEITEDIF", SqlDbType.Float).Value = VD(Fg(k, 23), "N")
                                        cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = VD(Fg(k, 28), "S")
                                        cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = VD(Fg(k, 29), "S")
                                        cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = VD(Fg(k, 30), "S")
                                        cmd.Parameters.Add("@FECHA_VERIFICACION", SqlDbType.Date).Value = VD(Fg(k, 31), "S")
                                        cmd.Parameters.Add("@OD_TARJ_IAVE", SqlDbType.VarChar).Value = VD(Fg(k, 35), "S")
                                        cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = VD(Fg(k, 41), "S")
                                        cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = VD(Fg(k, 42), "N")
                                        cmd.Parameters.Add("@UNIDAD_PESO", SqlDbType.VarChar).Value = VD(Fg(k, 43), "S")
                                        cmd.Parameters.Add("@LARGO", SqlDbType.Float).Value = VD(Fg(k, 44), "N")
                                        cmd.Parameters.Add("@ID_UMLONGITUD", SqlDbType.VarChar).Value = VD(Fg(k, 45), "S")
                                        cmd.Parameters.Add("@FECHACOMPRA", SqlDbType.Date).Value = VD(Fg(k, 47), "D")
                                        cmd.Parameters.Add("@NUMFACTURA", SqlDbType.VarChar).Value = VD(Fg(k, 48), "S")
                                        cmd.Parameters.Add("@IMPORTECOMPRA", SqlDbType.Float).Value = VD(Fg(k, 49), "N")
                                        cmd.Parameters.Add("@FECHALECTURAODOMETRO", SqlDbType.Date).Value = VD(Fg(k, 52), "D")
                                        cmd.Parameters.Add("@TMC", SqlDbType.VarChar).Value = VD(Fg(k, 53), "S")
                                        cmd.Parameters.Add("@FEC_ULT_SER", SqlDbType.Date).Value = VD(Fg(k, 54), "D")
                                        cmd.Parameters.Add("@CUEN_CONT2", SqlDbType.VarChar).Value = VD(Fg(k, 55), "S")
                                        cmd.Parameters.Add("@BASEOPERACION", SqlDbType.VarChar).Value = VD(Fg(k, 56), "S")
                                        cmd.Parameters.Add("@CAPACIDAD", SqlDbType.Float).Value = VD(Fg(k, 63), "N")
                                        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = VD(Fg(k, 70), "S")
                                        cmd.Parameters.Add("@IAVE2", SqlDbType.VarChar).Value = VD(Fg(k, 75), "S")
                                        cmd.Parameters.Add("@CONFIG_AUTOTRANSPORTE_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 79), "S")
                                        cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = VD(Fg(k, 80), "S")
                                        cmd.Parameters.Add("@TIPO_PERMISO_SAT", SqlDbType.VarChar).Value = VD(Fg(k, 81), "S")

                                        cmd.Parameters.Add("@NUMPOLIZASEGURO_DANOSAMBIENTALES", SqlDbType.VarChar).Value = VD(Fg(k, 84), "S")
                                        cmd.Parameters.Add("@VENCIMIENTOSEGURO_DANOSAMBIENTALES", SqlDbType.Date).Value = VD(Fg(k, 85), "D")

                                        cmd.Parameters.Add("@SUBTIPOREM", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@PARTETRANSPORTE", SqlDbType.VarChar).Value = ""

                                    Case 1
                                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = CLAVE
                                        cmd.Parameters.Add("@CLAVEMONTE", SqlDbType.VarChar).Value = TBOX.Text.Trim & VD(Fg(k, 1), "S")
                                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                        cmd.Parameters.Add("@UNIDAD_PERMISI", SqlDbType.VarChar).Value = 0
                                        cmd.Parameters.Add("@NUM_SERIE_UNI", SqlDbType.VarChar).Value = VD(Fg(k, 5), "S")
                                        cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = BUSCA_MARCA(VD(Fg(k, 6), "S"))
                                        cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = VD(Fg(k, 7), "S")
                                        cmd.Parameters.Add("@NUM_SERIE_MOT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@TIPO_MOTOR", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_TIPO_UNI", SqlDbType.SmallInt).Value = 2
                                        cmd.Parameters.Add("@CVE_TIPO_COM", SqlDbType.SmallInt).Value = 0
                                        cmd.Parameters.Add("@NUM_EJES", SqlDbType.SmallInt).Value = VD(Fg(k, 13), "N")
                                        cmd.Parameters.Add("@PLACAS_MEX", SqlDbType.VarChar).Value = VD(Fg(k, 8), "S").ToString.Replace(" ", "")
                                        cmd.Parameters.Add("@NUM_TARJ_CIRCULACION", SqlDbType.VarChar).Value = VD(Fg(k, 15), "S")
                                        cmd.Parameters.Add("@SE_ASEGURADORA", SqlDbType.VarChar).Value = "1"
                                        cmd.Parameters.Add("@SE_NO_SEG", SqlDbType.VarChar).Value = VD(Fg(k, 16), "S")
                                        cmd.Parameters.Add("@SE_VENC", SqlDbType.Date).Value = VD(Fg(k, 17), "S")
                                        cmd.Parameters.Add("@SE_TEL", SqlDbType.VarChar).Value = ""

                                        cmd.Parameters.Add("@ULTIMO_KM", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@ULTIMO_CAMBIO_ACEITE", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@KMCAMBIOACEITE", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@ULTCAMBIOACEITEDIF", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@KMCAMBIOACEITEDIF", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@FECHA_VERIFICACION", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@OD_TARJ_IAVE", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = VD(Fg(k, 25), "S")
                                        cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = VD(Fg(k, 26), "N")
                                        cmd.Parameters.Add("@UNIDAD_PESO", SqlDbType.VarChar).Value = VD(Fg(k, 27), "S")
                                        cmd.Parameters.Add("@LARGO", SqlDbType.Float).Value = VD(Fg(k, 28), "N")
                                        cmd.Parameters.Add("@ID_UMLONGITUD", SqlDbType.VarChar).Value = VD(Fg(k, 29), "S")
                                        cmd.Parameters.Add("@FECHACOMPRA", SqlDbType.Date).Value = VD(Fg(k, 31), "D")
                                        cmd.Parameters.Add("@NUMFACTURA", SqlDbType.VarChar).Value = VD(Fg(k, 32), "S")
                                        cmd.Parameters.Add("@IMPORTECOMPRA", SqlDbType.Float).Value = VD(Fg(k, 33), "N")
                                        cmd.Parameters.Add("@FECHALECTURAODOMETRO", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@TMC", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@FEC_ULT_SER", SqlDbType.Date).Value = VD(Fg(k, 36), "D")
                                        cmd.Parameters.Add("@CUEN_CONT2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@BASEOPERACION", SqlDbType.VarChar).Value = VD(Fg(k, 37), "S")
                                        cmd.Parameters.Add("@CAPACIDAD", SqlDbType.Float).Value = VD(Fg(k, 11), "N")
                                        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@IAVE2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@SUBTIPOREM", SqlDbType.VarChar).Value = VD(Fg(k, 50), "S")

                                        cmd.Parameters.Add("@CONFIG_AUTOTRANSPORTE_SAT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = VD(Fg(k, 51), "S")
                                        cmd.Parameters.Add("@TIPO_PERMISO_SAT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@PARTETRANSPORTE", SqlDbType.VarChar).Value = VD(Fg(k, 52), "S")

                                        cmd.Parameters.Add("@NUMPOLIZASEGURO_DANOSAMBIENTALES", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@VENCIMIENTOSEGURO_DANOSAMBIENTALES", SqlDbType.Date).Value = Now
                                    Case 2
                                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = CLAVE
                                        cmd.Parameters.Add("@CLAVEMONTE", SqlDbType.VarChar).Value = TBOX.Text.Trim & VD(Fg(k, 1), "S")
                                        cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = VD(Fg(k, 2), "S")
                                        cmd.Parameters.Add("@UNIDAD_PERMISI", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@NUM_SERIE_UNI", SqlDbType.VarChar).Value = 0
                                        cmd.Parameters.Add("@CVE_MARCA", SqlDbType.VarChar).Value = BUSCA_MARCA(VD(Fg(k, 5), "S"))
                                        cmd.Parameters.Add("@ANO_MODELO", SqlDbType.VarChar).Value = VD(Fg(k, 6), "S")
                                        cmd.Parameters.Add("@NUM_SERIE_MOT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@TIPO_MOTOR", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_TIPO_UNI", SqlDbType.SmallInt).Value = 3
                                        cmd.Parameters.Add("@CVE_TIPO_COM", SqlDbType.SmallInt).Value = 0
                                        cmd.Parameters.Add("@NUM_EJES", SqlDbType.SmallInt).Value = VD(Fg(k, 11), "N")
                                        cmd.Parameters.Add("@PLACAS_MEX", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@NUM_TARJ_CIRCULACION", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@SE_ASEGURADORA", SqlDbType.VarChar).Value = "1"
                                        cmd.Parameters.Add("@SE_NO_SEG", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@SE_VENC", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@SE_TEL", SqlDbType.VarChar).Value = ""

                                        cmd.Parameters.Add("@ULTIMO_KM", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@ULTIMO_CAMBIO_ACEITE", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@KMCAMBIOACEITE", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@ULTCAMBIOACEITEDIF", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@KMCAMBIOACEITEDIF", SqlDbType.Float).Value = 0
                                        cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CVE_DOLLY", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@FECHA_VERIFICACION", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@OD_TARJ_IAVE", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@CUEN_CONT", SqlDbType.VarChar).Value = VD(Fg(k, 20), "S")
                                        cmd.Parameters.Add("@PESO", SqlDbType.Float).Value = VD(Fg(k, 21), "N")
                                        cmd.Parameters.Add("@UNIDAD_PESO", SqlDbType.VarChar).Value = VD(Fg(k, 22), "S")
                                        cmd.Parameters.Add("@LARGO", SqlDbType.Float).Value = VD(Fg(k, 23), "N")
                                        cmd.Parameters.Add("@ID_UMLONGITUD", SqlDbType.VarChar).Value = VD(Fg(k, 24), "S")
                                        cmd.Parameters.Add("@FECHACOMPRA", SqlDbType.Date).Value = VD(Fg(k, 26), "D")
                                        cmd.Parameters.Add("@NUMFACTURA", SqlDbType.VarChar).Value = VD(Fg(k, 27), "S")
                                        cmd.Parameters.Add("@IMPORTECOMPRA", SqlDbType.Float).Value = VD(Fg(k, 28), "N")
                                        cmd.Parameters.Add("@FECHALECTURAODOMETRO", SqlDbType.Date).Value = Now
                                        cmd.Parameters.Add("@TMC", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@FEC_ULT_SER", SqlDbType.Date).Value = VD(Fg(k, 31), "D")
                                        cmd.Parameters.Add("@CUEN_CONT2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@BASEOPERACION", SqlDbType.VarChar).Value = VD(Fg(k, 33), "S")
                                        cmd.Parameters.Add("@CAPACIDAD", SqlDbType.Float).Value = VD(Fg(k, 9), "N")
                                        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@IAVE2", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@SUBTIPOREM", SqlDbType.VarChar).Value = ""

                                        cmd.Parameters.Add("@CONFIG_AUTOTRANSPORTE_SAT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@PERMISO_SCT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@TIPO_PERMISO_SAT", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@PARTETRANSPORTE", SqlDbType.VarChar).Value = ""

                                        cmd.Parameters.Add("@NUMPOLIZASEGURO_DANOSAMBIENTALES", SqlDbType.VarChar).Value = ""
                                        cmd.Parameters.Add("@VENCIMIENTOSEGURO_DANOSAMBIENTALES", SqlDbType.Date).Value = Now
                                End Select



                                returnValue = cmd.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then
                                        z += 1
                                        Lt6.Text = z & "/" & Fg.Rows.Count - 1
                                    End If
                                End If
                            Catch ex As Exception
                                Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                                Exit For
                            End Try
                        End Using
                    End Using
                End If
            Next
            MsgBox("Proceso terminado")
        Catch ex As Exception
            Bitacora("185. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("185. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Function BUSCA_MARCA(FDESCR As String) As String
        Dim CVE_MARCA As String = ""
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_MARCA FROM GCMARCAS WHERE DESCR = '" & FDESCR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MARCA = dr("CVE_MARCA")


                    Else
                        CVE_MARCA = GET_MAX_TRY("GCMARCAS", "CVE_MARCA")

                        SQL = "INSERT INTO GCMARCAS (CVE_MARCA, STATUS, DESCR) VALUES ('" & CVE_MARCA & "','A','" & FDESCR & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CVE_MARCA

    End Function
    Private Function BUSCA_MODELO(FDESCR As String) As Integer
        Dim CVE_MOD As Integer = 0
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_MOD FROM GCMODELO_UNIDAD WHERE DESCR = '" & FDESCR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_MOD = dr("CVE_MOD")
                    Else
                        CVE_MOD = GET_MAX("GCMODELO_UNIDAD", "CVE_MOD")

                        SQL = "INSERT INTO GCMODELO_UNIDAD (CVE_MOD, STATUS, DESCR) VALUES ('" & CVE_MOD & "','A','" & FDESCR & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CVE_MOD

    End Function
    Private Function BUSCA_TIPO_UNIDAD(FDESCR As String) As String
        Dim CVE_UNI As String = ""
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_UNI FROM GCTIPO_UNIDAD WHERE DESCR = '" & FDESCR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_UNI = dr("CVE_UNI")
                    Else
                        CVE_UNI = GET_MAX_TRY("GCTIPO_UNIDAD", "CVE_UNI")

                        SQL = "INSERT INTO GCTIPO_UNIDAD (CVE_UNI, STATUS, DESCR) VALUES ('" & CVE_UNI & "','A','" & FDESCR & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CVE_UNI

    End Function
    Private Function BUSCA_TIPO_COMBUSTIBLE(FDESCR As String) As Integer
        Dim CVE_TIPO As Integer = 0
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_TIPO FROM GCTIPO_COMBUSTIBLE WHERE DESCR = '" & FDESCR & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        CVE_TIPO = dr("CVE_TIPO")
                    Else
                        CVE_TIPO = GET_MAX("GCTIPO_COMBUSTIBLE", "CVE_TIPO")

                        SQL = "INSERT INTO GCTIPO_COMBUSTIBLE (CVE_TIPO, STATUS, DESCR) VALUES ('" & CVE_TIPO & "','A','" & FDESCR & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return CVE_TIPO

    End Function

    Private Sub CboTipoUnidad_DropDownClosed(sender As Object, e As DropDownClosedEventArgs) Handles CboTipoUnidad.DropDownClosed

        Select Case CboTipoUnidad.SelectedIndex
            Case 0
            Case 1
                TBOX.Text = "R-"
            Case 2
                TBOX.Text = "D-"
        End Select
    End Sub

    Private Sub BarActCampSATclieOP_Click(sender As Object, e As EventArgs) Handles BarActCampSATclieOP.Click
        Dim LOCALIDAD As String = "", MUNICIPIO As String = "", ESTADO As String = "", PAIS As String = "", COLONIA As String = ""
        Dim doc As New XmlDocument()

        Me.Cursor = Cursors.WaitCursor
        Fg.Redraw = False
        Fg.Rows.Count = 1

        SQL = "SELECT C.CLAVE, C.NOMBRE, CP_SAT, COLONIA, C.COLONIA_SAT, C.POBLACION, C.POBLACION_SAT, C.MUNICIPIO, C.MUNICIPIO_SAT, 
            ESTADO, ESTADO_SAT, PAIS, PAIS_SAT
            FROM GCCLIE_OP C "
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        If dr("ESTADO_SAT").Trim.Length > 0 AndAlso dr("POBLACION_SAT").Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_LOCALIDAD.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & dr("ESTADO_SAT") & "' and @Clave='" & dr("POBLACION_SAT") & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            LOCALIDAD = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If
                        If dr("ESTADO_SAT").Trim.Length > 0 AndAlso dr("MUNICIPIO_SAT").Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_MUNICIPIO.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Estado='" & dr("ESTADO_SAT") & "' and @Clave='" & dr("MUNICIPIO_SAT") & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            MUNICIPIO = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If

                        If dr("ESTADO_SAT").Trim.Length > 0 Then
                            If IO.File.Exists(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml") Then
                                doc.Load(Application.StartupPath & "\CatalogosSat\CAT_ESTADOS.xml")

                                'Dim nodeList As XmlNodeList = doc.SelectNodes("/Catalogo/row[@c_Localidad='" & TLOCALIDAD.Text & "' or7 @c_Municipio='" & TMUNICIPIO.Text & "' or @c_Estado='" & TESTADO.Text & "']")

                                Dim nodeList2 As XmlNodeList = doc.SelectNodes("/Catalogo/row[@Clave='" & dr("ESTADO_SAT") & "']")
                                If nodeList2.Count > 0 Then
                                    For Each node As XmlNode In nodeList2
                                        If Not IsNothing(node.Attributes("Descripcion")) Then
                                            ESTADO = node.Attributes("Descripcion").Value
                                        End If
                                    Next
                                End If
                            End If
                        End If

                        SQL = "SELECT colonia, codigopostal, nombreasentamiento 
                            FROM tblcolonias WHERE colonia = '" & dr("COLONIA_SAT") & "' AND codigopostal = '" & dr("CP_SAT") & "'"
                        Try
                            Using cmd3 As SqlCommand = cnSAE.CreateCommand
                                cmd3.CommandText = SQL
                                Using dr3 As SqlDataReader = cmd3.ExecuteReader
                                    If dr3.Read Then
                                        COLONIA = dr3("nombreasentamiento")
                                    End If
                                End Using
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                        Try
                            SQL = "UPDATE GCCLIE_OP SET POBLACION = '" & LOCALIDAD & "', MUNICIPIO = '" & MUNICIPIO & "', 
                                ESTADO = '" & ESTADO & "', COLONIA = '" & COLONIA & "', PAIS = 'MEXICO' WHERE CLAVE = '" & dr("CLAVE") & "'"
                            Using cmd2 As SqlCommand = cnSAE.CreateCommand
                                cmd2.CommandText = SQL
                                returnValue = cmd2.ExecuteNonQuery().ToString
                                If returnValue IsNot Nothing Then
                                    If returnValue = "1" Then

                                    End If
                                End If
                            End Using
                        Catch ex As Exception
                            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
                            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try

                        Fg.AddItem("" & vbTab & dr("CLAVE") & vbTab & dr("NOMBRE") & vbTab & dr("POBLACION") & vbTab &
                                   dr("MUNICIPIO") & vbTab & dr("ESTADO") & vbTab & dr("COLONIA"))
                    End While
                End Using
            End Using
            Fg.AutoSizeCols()

        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
        Fg.Redraw = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click


    End Sub

End Class
