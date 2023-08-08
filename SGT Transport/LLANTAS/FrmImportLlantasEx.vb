Imports C1.Win.C1FlexGrid
Imports System.Data.SqlClient
Imports C1.C1Excel
Imports System.Configuration
Imports C1.Win
Imports System.IO

Public Class FrmImportLlantasEx
    Private Sub FrmImportLlantasEx_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            SplitM.BorderWidth = 1
            Split1.BorderWidth = 1
            Split2.BorderWidth = 1
            SplitM.Dock = DockStyle.Fill
            Fg.Dock = DockStyle.Fill

            Dim SPOR1 As Decimal

            SPOR1 = ((CboHojas.Top + CboHojas.Height) / Me.Height) * 100
            Split1.SizeRatio = SPOR1 + 5
            Split2.SizeRatio = 100 - Split1.SizeRatio - SPOR1

            TITULOS()
        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub FrmImportLlantasEx_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        CloseTab("Importar llantas")
    End Sub

    Private Sub BarCargarArchivoExcel_Click(sender As Object, e As EventArgs) Handles BarCargarArchivoExcel.Click

        If TExcel.Text.Trim.Length = 0 Then
            MsgBox("Por favor seleccione un archivo de excel")
            Return
        End If

        If CboHojas.SelectedIndex = -1 Then
            MsgBox("Por favor una hoja")
            CboHojas.Select()
            Return
        End If

        Fg.LoadExcel(TExcel.Text, CboHojas.Text, FileFlags.ExcludeEmptyRows + FileFlags.IncludeFixedCells)
        Fg.AutoSizeCols()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        Dim NUM_ECONOMICO As String, UNIDAD As String, POSICION As Integer
        Dim FECHA_MON As Date, MARCA As String, MARCA_RENOVADO As String, MODELO As String, MODELO_RENOVADO As String, KM As Decimal, MEDIDA As String
        Dim PROFUNDIDA_ORIGINAL As Decimal, ROFUNDIDA_MINIMA As Decimal, PROFUNDIDAD_ACTUAL As Decimal, CVE_TIPO_UNI As Integer
        Dim TIPO_LLANTA As String, STATUS_LLANTA As String, COSTO_LLANTA_MN As Decimal, nCol As Integer = 0, Z As Long
        Dim KMS_MONTAR As Decimal, TIPO_NUEVA_RENO As String, SEMAFORO As String, nReg As Long = 0, KMS_ACTUAL As Decimal, NO_RENOVADOS As Integer
        Dim TIP_NEW_RENO As Integer, MARCA_RENO As String, PROV_RENO As String

        If MsgBox("Realmente desea importar las llantas?", vbYesNo) = vbNo Then
            Return
        End If

        Lt2.Text = Now.ToShortTimeString

        'NUM_ECONOMICO, CVE_LLANTA, UNIDAD, POSICION, FECHA_MON, MARCA, MARCA_RENOVADO,
        'MODELO, MODELO_RENOVADO, KM, MEDIDA, PROFUNDIDA_ORIGINAL, ROFUNDIDA_MINIMA, PROFUNDIDAD_ACTUAL,
        'TIPO_LLANTA, STATUS_LLANTA, COSTO_LLANTA_MN, KMS_MONTAR,
        'TIPO_NUEVA_RENO, SEMAFORO, KMS_ACTUAL, NO_RENOVADOS

        If File.Exists(Application.StartupPath & "\IMPORTA_LLANTAS.sql") Then
            File.Delete(Application.StartupPath & "\IMPORTA_LLANTAS.sql")
        End If

        BarGrabar.Enabled = False
        Fg.Redraw = False
        Me.Cursor = Cursors.WaitCursor

        Fg.BeginUpdate()

        Try
            For k = 1 To Fg.Rows.Count - 1

                NUM_ECONOMICO = VALIDA_VALOR(Fg(k, 0), "S")

                'CVE_LLANTA = BUSCA_CVE_LLANTA(NUM_ECONOMICO)

                'If CVE_LLANTA.Trim.Length = 0 Then
                'CVE_LLANTA = GET_MAX_TRY("GCLLANTAS", "CVE_LLANTA")
                'End If

                UNIDAD = VALIDA_VALOR(Fg(k, 1), "S")
                UNIDAD = UNIDAD.Trim.ToUpper

                CVE_TIPO_UNI = BUSCA_TIPO_UNI(Fg(k, 2))

                POSICION = VALIDA_VALOR(Fg(k, 3), "N")

                If UNIDAD.Trim.Length > 0 And POSICION > 0 Then
                    'ASIGNAR_LLANTAS(UNIDAD, POSICION, CVE_LLANTA, CVE_TIPO_UNI)
                End If

                If IsDate(Fg(k, 4)) Then
                    FECHA_MON = Fg(k, 4)
                Else
                    FECHA_MON = Now.ToShortDateString
                End If

                MARCA = BUSCA_MARCA_DES(VALIDA_VALOR(Fg(k, 5), "S"))
                MARCA_RENOVADO = BUSCA_MARCA_DES(VALIDA_VALOR(Fg(k, 6), "S"))

                MODELO = BUSCA_MODELO_DES(VALIDA_VALOR(Fg(k, 7), "S"))
                MODELO_RENOVADO = BUSCA_MODELO_DES(VALIDA_VALOR(Fg(k, 8), "S"))

                KM = VALIDA_VALOR(Fg(k, 9), "N")

                MEDIDA = BUSCA_LLANTA_MEDIDA_DES(VALIDA_VALOR(Fg(k, 10), "S"))

                PROFUNDIDA_ORIGINAL = VALIDA_VALOR(Fg(k, 11), "N")
                ROFUNDIDA_MINIMA = VALIDA_VALOR(Fg(k, 12), "N")
                PROFUNDIDAD_ACTUAL = VALIDA_VALOR(Fg(k, 13), "N")
                TIPO_LLANTA = BUSCA_TIPO_LLANTA_DES(VALIDA_VALOR(Fg(k, 14), "S"))

                STATUS_LLANTA = BUSCA_STATUS_LLANTA(VALIDA_VALOR(Fg(k, 15), "S"))

                COSTO_LLANTA_MN = VALIDA_VALOR(Fg(k, 16), "N")
                KMS_MONTAR = VALIDA_VALOR(Fg(k, 17), "N")
                TIPO_NUEVA_RENO = VALIDA_VALOR(Fg(k, 18), "S")

                Select Case TIPO_NUEVA_RENO
                    Case "ORIGINAL"
                        TIP_NEW_RENO = 1
                    Case "RENOVADA"
                        TIP_NEW_RENO = 2
                    Case "ORIGINAL NUEVA"
                        TIP_NEW_RENO = 3
                    Case "ORIGINAL USO"
                        TIP_NEW_RENO = 4
                    Case "RENOVADA NUEVA"
                        TIP_NEW_RENO = 5
                    Case "RENOVADA USO"
                        TIP_NEW_RENO = 6
                    Case Else
                        TIP_NEW_RENO = 0
                End Select
                SEMAFORO = VALIDA_VALOR(Fg(k, 19), "S")
                KMS_ACTUAL = VALIDA_VALOR(Fg(k, 20), "N")
                NO_RENOVADOS = VALIDA_VALOR(Fg(k, 21), "N")

                MARCA_RENO = BUSCA_MARCA_RENO(VALIDA_VALOR(Fg(k, 22), "S"))
                PROV_RENO = BUSCA_PROV_RENO(VALIDA_VALOR(Fg(k, 23), "S"))


                If NUM_ECONOMICO.Trim.Length > 0 Then
                    SQL = "IF NOT EXISTS (SELECT NUM_ECONOMICO FROM GCLLANTAS WHERE NUM_ECONOMICO = '" & NUM_ECONOMICO & "')
                    INSERT INTO GCLLANTAS (NUM_ECONOMICO, STATUS, UNIDAD, POSICION, FECHA_MON, MARCA, 
                    MARCA_RENOVADO, MODELO, MODELO_RENOVADO, KM, MEDIDA, PROFUNDIDA_ORIGINAL, ROFUNDIDA_MINIMA, 
                    PROFUNDIDAD_ACTUAL, TIPO_LLANTA, STATUS_LLANTA, COSTO_LLANTA_MN, FECHA_REG, FECHAELAB, KMS_MONTAR, 
                    TIPO_NUEVA_RENO, SEMAFORO, KMS_ACTUAL, NO_RENOVADOS, CVE_MARCA, CVE_PRE) 
                    VALUES ('" &
                    NUM_ECONOMICO & "','A','" & UNIDAD & "','" & POSICION & "','" & FSQL(FECHA_MON) & "','" &
                    MARCA & "','" & MARCA_RENOVADO & "','" & MODELO & "','" & MODELO_RENOVADO & "','" & KM & "','" & MEDIDA & "','" &
                    PROFUNDIDA_ORIGINAL & "','" & ROFUNDIDA_MINIMA & "','" & PROFUNDIDAD_ACTUAL & "','" & TIPO_LLANTA & "','" &
                    STATUS_LLANTA & "','" & COSTO_LLANTA_MN & "',CONVERT(varchar, GETDATE(), 112),GETDATE(),'" & KMS_MONTAR & "','" &
                    TIP_NEW_RENO & "','" & SEMAFORO & "','" & KMS_ACTUAL & "','" & NO_RENOVADOS & "','" & MARCA_RENO & "','" & PROV_RENO & "')"

                    Lt1.Text = k & "/" & Fg.Rows.Count - 1

                    BACKUP_SQL("IMPORTA_LLANTAS", SQL)

                End If
            Next

            Try
                Dim Objread As New StreamReader(Application.StartupPath & "\IMPORTA_LLANTAS.sql")
                Dim cmd As New SqlCommand With {
                    .CommandType = CommandType.Text, .Connection = cnSAE, .CommandText = Objread.ReadToEnd(),
                    .CommandTimeout = 3600}
                Z = cmd.ExecuteNonQuery()
            Catch ex As Exception
                BITACORADB("1320. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        Finally
            Fg.EndUpdate()
        End Try

        BarGrabar.Enabled = True
        Fg.Redraw = True
        Me.Cursor = Cursors.Default

        Lt2.Text = Lt2.Text & "/" & Now.ToShortTimeString

        MsgBox("Proceso terminado, registros afectados " & Z)

    End Sub
    Private Function BUSCA_MARCA_RENO(FMARCA_RENO As String) As String
        Dim CVE_MARCA As String = "", ExistReg As Boolean = True
        Try
            If FMARCA_RENO.Trim.Length > 0 AndAlso Not IsNothing(FMARCA_RENO) Then
                If FMARCA_RENO <> "NULL" And FMARCA_RENO.Trim.Length > 0 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand

                        SQL = "SELECT CVE_MARCA FROM GCMARCAS_RENOVADO WHERE UPPER(DESCR) = '" & FMARCA_RENO.Trim.ToUpper & "'"

                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CVE_MARCA = dr.ReadNullAsEmptyString("CVE_MARCA ")
                                ExistReg = False
                            End If
                        End Using
                    End Using
                    If ExistReg Then
                        CVE_MARCA = GET_MAX_TRY("GCMARCAS_RENOVADO", "CVE_MARCA")
                        SQL = "INSERT INTO GCMARCAS_RENOVADO (CVE_MARCA, STATUS, DESCR) VALUES ('" &
                            CVE_MARCA & "','A','" & FMARCA_RENO.Trim.ToUpper & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_MARCA
    End Function
    Private Function BUSCA_PROV_RENO(FPROV_RENO As String) As String
        Dim CVE_PRE As String = "", ExistReg As Boolean = True
        Try
            If Not IsNothing(FPROV_RENO) Then
                If FPROV_RENO <> "NULL" And FPROV_RENO.Trim.Length > 0 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand

                        SQL = "SELECT CVE_PRE FROM GCPROVRENOVADO WHERE UPPER(DESCR) = '" & FPROV_RENO.Trim.ToUpper & "'"

                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CVE_PRE = dr.ReadNullAsEmptyString("CVE_PRE")
                                ExistReg = False
                            End If
                        End Using
                    End Using
                    If ExistReg Then
                        CVE_PRE = GET_MAX_TRY("GCPROVRENOVADO", "CVE_PRE")
                        SQL = "INSERT INTO GCPROVRENOVADO (CVE_PRE, STATUS, DESCR) VALUES ('" &
                            CVE_PRE & "','A','" & FPROV_RENO.Trim.ToUpper & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_PRE
    End Function
    Private Function BUSCA_TIPO_UNI(FTIPO_UNIDAD As String) As Integer
        Dim CVE_TIPO_UNI As Integer = 0, ExistReg As Boolean = True
        Try
            If Not IsNothing(FTIPO_UNIDAD) Then
                If FTIPO_UNIDAD <> "NULL" And FTIPO_UNIDAD.Trim.Length > 0 Then
                    Using cmd As SqlCommand = cnSAE.CreateCommand

                        SQL = "SELECT CVE_UNI FROM GCTIPO_UNIDAD WHERE UPPER(DESCR) = '" & FTIPO_UNIDAD.Trim.ToUpper & "'"

                        cmd.CommandText = SQL
                        Using dr As SqlDataReader = cmd.ExecuteReader
                            If dr.Read Then
                                CVE_TIPO_UNI = dr("CVE_UNI")
                                ExistReg = False
                            End If
                        End Using
                    End Using
                    If ExistReg Then
                        CVE_TIPO_UNI = GET_MAX_TRY("GCTIPO_UNIDAD", "CVE_UNI")
                        SQL = "INSERT INTO GCPROVRENOVADO (CVE_PRE, STATUS, DESCR) VALUES ('" &
                            CVE_TIPO_UNI & "','A','" & FTIPO_UNIDAD.Trim.ToUpper & "')"
                        EXECUTE_QUERY_NET(SQL)
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_TIPO_UNI

    End Function

    Sub ASIGNAR_LLANTAS(FUNIDAD As String, FPOS As Integer, FCVE_LLANTA As String, FCVE_TIPO_UNI As Integer)

        SQL = ""
        Try
            Select Case FPOS
                Case 1
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL1 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL1, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 2
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL2 = '" & FCVE_LLANTA & "',CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL2, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 3
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL3 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL3, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 4
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL4 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL4, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 5
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL5 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL5, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 6
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL6 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL6, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 7
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL7 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL7, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 8
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL8 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL8, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 9
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL9 = '" & FCVE_LLANTA & "', CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL9, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 10
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL10 = '" & FCVE_LLANTA & "',CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL10, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 11
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL11 = '" & FCVE_LLANTA & "',CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL11, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
                Case 12
                    SQL = "IF EXISTS (SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "')
                        UPDATE GCUNIDADES SET CHLL12 = '" & FCVE_LLANTA & "',CVE_TIPO_UNI = " & FCVE_TIPO_UNI & " WHERE CLAVEMONTE = '" & FUNIDAD.Trim.ToUpper & "'
                      ELSE
                        INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, CHLL12, CVE_TIPO_UNI) VALUES ('" & GET_MAX("GCUNIDADES", "CLAVE") & "','" &
                        FUNIDAD.Trim.ToUpper & "','A','" & FCVE_LLANTA & "','" & FCVE_TIPO_UNI & "')"
            End Select

            If SQL.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace & vbNewLine & "Unidad:" & FUNIDAD)
        End Try

    End Sub
    Private Function BUSCA_UNIDAD(FUNIDAD As String) As String
        Dim CLAVEMONTE As String = "", ExistReg As Boolean = True
        Try
            If FUNIDAD <> "NULL" And FUNIDAD.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CLAVEMONTE FROM GCUNIDADES WHERE CLAVEMONTE = '" & FUNIDAD & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CLAVEMONTE = dr("CLAVEMONTE")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    SQL = "INSERT INTO GCUNIDADES (CLAVE, CLAVEMONTE, STATUS, RENTADO, UNIDAD_PERMISI, DESCR, CVE_TIPO_UNI, CVE_SUC, CVE_OPER, CVE_MARCA, CVE_MODELO,
                        NUM_SERIE_UNI, COLOR, CVE_ART, CVE_TANQUE1, CVE_TANQUE2, CVE_DOLLY, CVE_GRUPO, IDENT_SAT, IDENT_CON, RENDIMIENTO, ULTIMO_KM, ULTIMO_DIS, 
                        FEC_ULT_RES, FEC_ULT_SER, FEC_PROX_RES, FCHULTLAVADA, DIAS_SERV, KM_SER, CVE_DOC, GARANTIA, ULT_DIST_RECR, FECHA_DOC, CVE_DOC_ASEG, 
                        CVE_OBSCOMP, CHLL1, CHLL2, CHLL3, CHLL4, CHLL5, CHLL6, CHLL7, CHLL8, CHLL9, CHLL10, CHLL11, CHLL12, PLACAS_MEX, FPLA_VENC, PLACAS_EU, 
                        FPLA_VENC_EU, PLACAS_DEF, PERMISO_SCT, VERIFICACION, FVENC_VER, CHTV, CHAC, CHWIFI, CHDISCAPA, VEL_PROM, NEUTRALIZADORES, FRE_BRUS, 
                        CAR_ACELE, ACC_PED_FRENO, VEL_MAX_MOTOR, PORC_ULT_CAMBIO, LARGO, ANCHO, ALTO, CAPACIDAD, NUM_EJES, NUM_LLANTAS, LLANTAS_REF, CVE_MARCA_LLA,
                        CVE_MODELO_LLA, CVE_MED, CVE_TIPO_LLA, TIPO_MOTOR, NUM_SERIE_MOT, TIPO_TRANS, CVE_OBSER_MOT, CVE_TIPO_COM, CAP_TANQUE_LT, CAP_TANQUE_MI, 
                        REN_CAR_KM, REN_CAR_MI, REN_VAC_KM, REN_VAC_MI, TARJ_COMB, TARJ_COMB2, TARJ_COMB3, OD_TARJ_IAVE, OD_TARJ_EPASS, OD_PORC, OD_ODOMETRO_KM,
                        OD_ODOMETRO_GPS_KM, OD_ODOMETRO_MI, OD_ODOMETRO_GPS_MI, OD_HOROMETRO, OD_HOROMETRO_MIN, CVE_PROP, SE_ASEGURADORA, SE_TEL, SE_NO_SEG, SE_VENC,
                        SE_AMPLIA, SE_LIMITADA, SE_SIN_COBERTURA, PARO_X_RALENTI, T_P_MOTOR_RELENTI, EJES, NIVEL, NIVEL2, NIVEL3, CVE_TAQ, CVE_MOT, CUEN_CONT, 
                        CUEN_CONT2, CUEN_CONT_VTA, SUBTIPOREM, ANO_MODELO, CVE_REND, CTA_CON_DIESEL, CTA_CON_DIESEL_SIVA, MOTIVO_BAJA) 
                        VALUES('" &
                        GET_MAX("GCUNIDADES", "CLAVE") & "','" & FUNIDAD & "','A','" & FUNIDAD & "',' @CVE_TIPO_UNI, @CVE_SUC, @CVE_OPER, @CVE_MARCA, @CVE_MODELO, @NUM_SERIE_UNI,
                        @COLOR, @CVE_ART, @CVE_TANQUE1, @CVE_TANQUE2, @CVE_DOLLY, @CVE_GRUPO, @IDENT_SAT, @IDENT_CON, @RENDIMIENTO, @ULTIMO_KM, @ULTIMO_DIS, 
                        @FEC_ULT_RES, @FEC_ULT_SER, @FEC_PROX_RES, @FCHULTLAVADA, @DIAS_SERV, @KM_SER, @CVE_DOC, @GARANTIA, @ULT_DIST_RECR, @FECHA_DOC, @CVE_DOC_ASEG,
                        @CVE_OBSCOMP, @CHLL1, @CHLL2, @CHLL3, @CHLL4, @CHLL5, @CHLL6, @CHLL7, @CHLL8, @CHLL9, @CHLL10, @CHLL11, @CHLL12, @PLACAS_MEX, @FPLA_VENC, 
                        @PLACAS_EU, @FPLA_VENC_EU, @PLACAS_DEF, @PERMISO_SCT, @VERIFICACION, @FVENC_VER, @CHTV, @CHAC, @CHWIFI, @CHDISCAPA, @VEL_PROM, @NEUTRALIZADORES,
                        @FRE_BRUS, @CAR_ACELE, @ACC_PED_FRENO, @VEL_MAX_MOTOR, @PORC_ULT_CAMBIO, @LARGO, @ANCHO, @ALTO, @CAPACIDAD, @NUM_EJES, @NUM_LLANTAS, 
                        @LLANTAS_REF, @CVE_MARCA_LLA, @CVE_MODELO_LLA, @CVE_MED, @CVE_TIPO_LLA, @TIPO_MOTOR, @NUM_SERIE_MOT, @TIPO_TRANS, @CVE_OBSER_MOT, @CVE_TIPO_COM,
                        @CAP_TANQUE_LT, @CAP_TANQUE_MI, @REN_CAR_KM, @REN_CAR_MI, @REN_VAC_KM, @REN_VAC_MI, @TARJ_COMB, @TARJ_COMB2, @TARJ_COMB3, @OD_TARJ_IAVE,
                        @OD_TARJ_EPASS, @OD_PORC, @OD_ODOMETRO_KM, @OD_ODOMETRO_GPS_KM, @OD_ODOMETRO_MI, @OD_ODOMETRO_GPS_MI, @OD_HOROMETRO, @OD_HOROMETRO_MIN, @CVE_PROP, 
                        @SE_ASEGURADORA, @SE_TEL, @SE_NO_SEG, @SE_VENC, @SE_AMPLIA, @SE_LIMITADA, @SE_SIN_COBERTURA, @PARO_X_RALENTI, @T_P_MOTOR_RELENTI, @EJES, 
                        @NIVEL, @NIVEL2, @NIVEL3, @CVE_TAQ, @CVE_MOT, @CUEN_CONT, @CUEN_CONT2, @CUEN_CONT_VTA, @SUBTIPOREM, @ANO_MODELO, @CVE_REND, 
                        @CTA_CON_DIESEL, @CTA_CON_DIESEL_SIVA, @MOTIVO_BAJA)"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CLAVEMONTE
    End Function
    Private Function BUSCA_STATUS_LLANTA(FSTATUS_LLANTA As String) As String
        Dim CVE_STATUS As String = "", ExistReg As Boolean = True
        Try
            If FSTATUS_LLANTA.Trim.ToUpper <> "NULL" And FSTATUS_LLANTA.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand

                    SQL = "SELECT CVE_STATUS FROM GCLLANTA_STATUS WHERE UPPER(DESCR) = '" & FSTATUS_LLANTA.Trim.ToUpper & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_STATUS = dr("CVE_STATUS")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    CVE_STATUS = GET_MAX_TRY("GCLLANTA_STATUS", "CVE_STATUS")
                    SQL = "INSERT INTO GCLLANTA_STATUS (CVE_STATUS, STATUS, DESCR) VALUES ('" & CVE_STATUS & "','A','" & FSTATUS_LLANTA.Trim.ToUpper & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_STATUS
    End Function
    Private Function BUSCA_LLANTA_MEDIDA_DES(FLLANTA_MEDIDA As String) As String
        Dim CVE_MED As Integer = 0, ExistReg As Boolean = True
        Try
            If FLLANTA_MEDIDA.Trim.ToUpper <> "NULL" And FLLANTA_MEDIDA.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand

                    SQL = "SELECT CVE_MED FROM GCLLANTA_MEDIDA WHERE UPPER(DESCR) = '" & FLLANTA_MEDIDA.Trim.ToUpper & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_MED = dr("CVE_MED")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    CVE_MED = GET_MAX("GCLLANTA_MEDIDA", "CVE_MED")
                    SQL = "INSERT INTO GCLLANTA_MEDIDA (CVE_MED, STATUS, DESCR) VALUES ('" & CVE_MED & "','A','" & FLLANTA_MEDIDA.Trim.ToUpper & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_MED
    End Function
    Private Function BUSCA_TIPO_LLANTA_DES(FLLANTA_TIPO As String) As String
        Dim CVE_TIPO As String = "", ExistReg As Boolean = True
        Try
            If FLLANTA_TIPO <> "NULL" And FLLANTA_TIPO.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand

                    SQL = "SELECT CVE_TIPO FROM GCLLANTA_TIPO WHERE UPPER(DESCR) = '" & FLLANTA_TIPO.Trim.ToUpper & "'"

                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_TIPO = dr("CVE_TIPO")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    CVE_TIPO = GET_MAX_TRY("GCLLANTA_TIPO", "CVE_TIPO")
                    SQL = "INSERT INTO GCLLANTA_TIPO (CVE_TIPO, STATUS, DESCR) VALUES ('" & CVE_TIPO & "','A','" & FLLANTA_TIPO.Trim.ToUpper & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_TIPO
    End Function
    Private Function BUSCA_MODELO_DES(FMODELO As String) As String
        Dim CVE_MODELO As String = "", ExistReg As Boolean = True
        Try
            If FMODELO.Trim.ToUpper <> "NULL" And FMODELO.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand

                    SQL = "SELECT CVE_MODELO FROM GCLLANTA_MODELO WHERE UPPER(DESCR) = '" & FMODELO.Trim.ToUpper & "'"

                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_MODELO = dr("CVE_MODELO")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    CVE_MODELO = GET_MAX_TRY("GCLLANTA_MODELO", "CVE_MODELO")
                    SQL = "INSERT INTO GCLLANTA_MODELO (CVE_MODELO, STATUS, DESCR) VALUES ('" & CVE_MODELO & "','A','" & FMODELO.Trim.ToUpper & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_MODELO
    End Function
    Private Function BUSCA_MARCA_DES(FMARCA As String) As String
        Dim CVE_MARCA As String = "", ExistReg As Boolean = True
        Try
            If FMARCA.Trim.ToUpper <> "NULL" And FMARCA.Trim.Length > 0 Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_MARCA FROM GCMARCAS WHERE UPPER(DESCR) = '" & FMARCA.Trim.ToUpper & "'"
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            CVE_MARCA = dr("CVE_MARCA")
                            ExistReg = False
                        End If
                    End Using
                End Using
                If ExistReg Then
                    CVE_MARCA = GET_MAX_TRY("GCMARCAS", "CVE_MARCA")
                    SQL = "INSERT INTO GCMARCAS (CVE_MARCA, STATUS, DESCR) VALUES ('" & CVE_MARCA & "','A','" & FMARCA.Trim.ToUpper & "')"
                    EXECUTE_QUERY_NET(SQL)
                End If
            End If
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

        Return CVE_MARCA
    End Function
    Private Function VALIDA_VALOR(FVALOR As String, FTIPO As String) As String
        Dim DATOREGRE As String = ""

        Try
            Select Case FTIPO
                Case "S"
                    If IsNothing(FVALOR) Then
                        DATOREGRE = ""
                    Else
                        If FVALOR = "NULL" Then
                            DATOREGRE = ""
                        Else
                            DATOREGRE = FVALOR
                        End If
                    End If
                Case "N"
                    If IsNothing(FVALOR) Then
                        DATOREGRE = "0"
                    Else
                        If IsNumeric(FVALOR) Then
                            DATOREGRE = FVALOR
                        Else
                            DATOREGRE = "0"
                        End If
                    End If
                Case "D"
                    If IsNothing(FVALOR) Then
                        DATOREGRE = Now.Year & Format(Now.Month, "00") & Format(Now.Day, "00")
                    Else
                        If IsDate(FVALOR) Then
                            DATOREGRE = FSQL(FVALOR)
                        Else
                            DATOREGRE = Now.Year & Format(Now.Month, "00") & Format(Now.Day, "00")
                        End If
                    End If
                Case Else
                    DATOREGRE = ""
            End Select

        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Return DATOREGRE

    End Function
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
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
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub TITULOS()
        Try
            Fg.Cols.Count = 43

            Dim cs1 As CellStyle
            cs1 = Fg.Styles.Add("cs1")
            cs1.BackColor = Color.LimeGreen

            Fg.SetCellStyle(0, 1, cs1)
            Fg.SetCellStyle(0, 8, cs1)
            Fg.SetCellStyle(0, 10, cs1)
            Fg.SetCellStyle(0, 11, cs1)
            Fg.SetCellStyle(0, 12, cs1)
            Fg.SetCellStyle(0, 13, cs1)
            Fg.SetCellStyle(0, 14, cs1)
            Fg.SetCellStyle(0, 15, cs1)
            Fg.SetCellStyle(0, 16, cs1)
            Fg.SetCellStyle(0, 17, cs1)
            Fg.SetCellStyle(0, 16, cs1)
            Fg.SetCellStyle(0, 22, cs1)
            Fg.SetCellStyle(0, 26, cs1)
            Fg.SetCellStyle(0, 36, cs1)
            Fg.SetCellStyle(0, 41, cs1)

            Fg(0, 1) = "NUM_ECONOMICO"
            Fg(0, 2) = "CVE_LLANTA"
            Fg(0, 3) = "STATUS"
            Fg(0, 4) = "UNIDAD"
            Fg(0, 5) = "POSICION"
            Fg(0, 6) = "POSICION2"
            Fg(0, 7) = "DISENO"
            Fg(0, 8) = "O_R"
            Fg(0, 9) = "FECHA_MON"
            Fg(0, 10) = "MARCA"
            Fg(0, 11) = "MARCA_RENOVADO"
            Fg(0, 12) = "MODELO"
            Fg(0, 13) = "MODELO_RENOVADO"
            Fg(0, 14) = "KM"
            Fg(0, 15) = "MEDIDA"
            Fg(0, 16) = "PROFUNDIDA_ORIGINAL"
            Fg(0, 17) = "ROFUNDIDA_MINIMA"
            Fg(0, 18) = "PROFUNDIDAD_ACTUAL"
            Fg(0, 19) = "PRESION_MINIMA"
            Fg(0, 20) = "PRESION_ORIGINAL"
            Fg(0, 21) = "PRESION_ACTUAL"
            Fg(0, 22) = "TIPO_LLANTA"
            Fg(0, 23) = "STATUS_LLANTA"
            Fg(0, 24) = "DISPONIBLE_DESDE"
            Fg(0, 25) = "VIDA_UTIL"
            Fg(0, 26) = "COSTO_LLANTA_MN"
            Fg(0, 27) = "COSTO_LLANTA_DLS"
            Fg(0, 28) = "FECHA_REG"
            Fg(0, 29) = "LLANTA1"
            Fg(0, 30) = "EJES"
            Fg(0, 31) = "CVE_OBS"
            Fg(0, 32) = "FECHA_MONTAJE"
            Fg(0, 33) = "FECHA_REGISTRO"
            Fg(0, 34) = "FECHAELAB"
            Fg(0, 35) = "CUEN_CONT"
            Fg(0, 36) = "KMS_MONTAR"
            Fg(0, 37) = "KMS_DESMONTAR"
            Fg(0, 38) = "USUARIO"
            Fg(0, 39) = "NUM_MOV"
            Fg(0, 40) = "CVE_ART"
            Fg(0, 41) = "TIPO_NUEVA_RENO"
            Fg(0, 42) = "SEMAFORO"

        Catch ex As Exception
            Bitacora("120. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("120. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class