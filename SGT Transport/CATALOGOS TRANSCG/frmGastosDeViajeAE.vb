Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class frmGastosDeViajeAE
    Private ENTRA As Boolean
    Private ENTRA2 As Boolean

    Private ENTRA_KEY As Boolean
    Private REMOVE_ROW As Integer
    Private ENTRA_BTN As Boolean
    Private Key_Pres As Integer
    Private Key_Pres2 As Integer
    Private ARTICULO As String

    Private SERIE_AG As String
    Private FOLIO_AG As Long

    Private SERIE_AV As String
    Private FOLIO_AV As Long

    Private Sub frmGastosDeViajeAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        SERIE_AG = "" : FOLIO_AG = 1
        SERIE_AV = "" : FOLIO_AV = 1
        ENTRA = True
        Using cmd As SqlCommand = cnSAE.CreateCommand
            SQL = "SELECT ISNULL(TIP_DOC,'') AS TIPO_DOC, ISNULL(SERIE,'') AS SERIE1, ISNULL(ULT_DOC,0) AS ULTDOC FROM GCFOLIOS " &
                "WHERE TIP_DOC = 'A' OR TIP_DOC = 'AG' OR TIP_DOC = 'AV'"
            cmd.CommandText = SQL
            Using dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Select Case dr("TIPO_DOC")
                        Case "AG"
                            SERIE_AG = dr("SERIE1")
                            FOLIO_AG = dr("ULTDOC") + 1
                        Case "AV"
                            SERIE_AV = dr("SERIE1")
                            FOLIO_AV = dr("ULTDOC") + 1
                    End Select
                Loop
            End Using
        End Using

        ENTRA_KEY = True
        ENTRA = True
        ENTRA2 = True
        Key_Pres = 0
        Key_Pres2 = 0
        ENTRA_BTN = True
        Label2.Refresh()
        Me.Top = 100

        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        C1SuperTooltip1.SetToolTip(btnNumCpto, "GCCONC_GASTOS")

        Me.CenterToScreen()
        Me.KeyPreview = True

        tFECHA.Value = Date.Today
        tFECHA.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.CustomFormat = "dd/MM/yyyy"
        tFECHA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        tFECHA.EditFormat.CustomFormat = "dd/MM/yyyy"

        tCVE_NUM.MaxLength = 10
        tCVE_OPER.MaxLength = 10
        tCVE_VIAJE.MaxLength = 10
        tCVE_UNI.MaxLength = 10
        tCVE_AUT.MaxLength = 10
        tCVE_UNI2.MaxLength = 10

        tCVE_NUM.Text = ""
        tCVE_OPER.Text = ""
        tCVE_VIAJE.Text = ""
        tCVE_UNI.Text = ""
        tFECHA.Value = Now
        tNUM_CPTO.Text = 0
        tCVE_AUT.Text = ""
        chGEN_PAS.Checked = False
        tLITROS.Value = 0
        tCVE_UNI2.Text = ""
        tTOTAL_COMB.Value = 0

        If Not Valida_Conexion() Then
            Return
        End If

        If Var1 = "Nuevo" Then
            Try
                tCVE_NUM.Text = GET_MAX("GCGASTOS_VIAJE", "CVE_NUM")
                tCVE_NUM.Enabled = False

                tNUM_CPTO.Select()
            Catch ex As Exception
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
                msgbox("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT G.CVE_NUM, G.CVE_OPER, G.CVE_VIAJE, G.CVE_UNI, G.FECHA, G.CVE_PROV, G.NUM_CPTO, G.CVE_AUT, G.GEN_PAS, " &
                    "G.LITROS, G.CVE_UNI2, G.TOTAL_COMB " &
                    "FROM GCGASTOS_VIAJE G " &
                    "WHERE CVE_NUM = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_NUM.Text = dr("CVE_NUM").ToString
                    tCVE_OPER.Text = dr("CVE_OPER").ToString
                    LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)

                    tCVE_VIAJE.Text = dr("CVE_VIAJE").ToString
                    LtViaje.Text = BUSCA_CAT("Viajes", tCVE_VIAJE.Text)

                    tCVE_UNI.Text = dr("CVE_UNI").ToString
                    LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Text)

                    tFECHA.Value = dr("FECHA").ToString

                    tNUM_CPTO.Text = dr("NUM_CPTO").ToString
                    LtNumCpto.Text = BUSCA_CAT("GCConc", tNUM_CPTO.Text)

                    tCVE_AUT.Text = dr("CVE_AUT").ToString
                    LtAutoriza.Text = BUSCA_CAT("Autoriza", tCVE_AUT.Text)

                    If dr("GEN_PAS") = 0 Then
                        chGEN_PAS.Checked = False
                    Else
                        chGEN_PAS.Checked = True
                    End If
                    tLITROS.Value = dr("LITROS").ToString
                    tCVE_UNI2.Text = dr("CVE_UNI2").ToString
                    LtUni2.Text = BUSCA_CAT("Unidades", tCVE_UNI2.Text)

                    tTOTAL_COMB.Value = dr("TOTAL_COMB").ToString

                End If
                dr.Close()

                CARGAR_FG()

                tCVE_NUM.Enabled = False
                tNUM_CPTO.Select()

            Catch ex As Exception
                msgbox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Sub CARGAR_FG()
        Try
            Fg.Rows.Count = 1
            ENTRA = False
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT A.FOLIO, A.FECHA, A.CVE_PROV, A.NUM_CPTO, A.IMPORTE, P.NOMBRE, C.DESCR " &
                     "FROM GCGASTOS_PAR A " &
                     "LEFT JOIN PROV" & Empresa & " P ON P.CLAVE = A.CVE_PROV " &
                     "LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = A.NUM_CPTO " &
                     "WHERE CVE_NUM = '" & Var2 & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("FOLIO") & vbTab & ("FECHA") & vbTab & dr("CVE_PROV") & vbTab & "" & vbTab &
                                   dr("NOMBRE") & vbTab & dr("NUM_CPTO") & vbTab & "" & vbTab & dr("DESCR") & vbTab & dr("IMPORTE") & vbTab & dr("FOLIO"))
                    End While
                End Using
                Fg.Row = Fg.Rows.Count - 1
                Fg.Col = 3
                Fg.StartEditing()
            End Using
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            msgbox("16. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("16. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            ENTRA2 = False
            FgA.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT A.FOLIO, ISNULL(AV.FECHA,'') AS FECH, ISNULL(AV.NUM_CPTO,0) AS CPTO, ISNULL(C.DESCR, '') AS DES , ISNULL(AV.IMPORTE,0) AS IMPORT " &
                     "FROM GCGASTOS_ANT A " &
                     "LEFT JOIN GCANTICIPOS_VIAJE AV ON AV.CVE_ANTVI = A.FOLIO " &
                     "LEFT JOIN GCCONC_GASTOS C ON C.CVE_GAS = AV.NUM_CPTO " &
                     "WHERE CVE_NUM = '" & Var2 & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        FgA.AddItem("" & vbTab & dr("FOLIO") & vbTab & dr("FECH") & vbTab & dr("CPTO") & vbTab & " " & vbTab & dr("DES") & vbTab & dr("IMPORT") & vbTab & dr("FOLIO"))
                    End While
                End Using
            End Using

            FgA.Row = FgA.Rows.Count - 1
            FgA.Col = 3
            FgA.StartEditing()
            ENTRA2 = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("17. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("17. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmGastosDeViajeAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub frmGastosDeViajeAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

        Try
            Dim z As Integer = 0
            For k = 1 To Fg.Rows.Count - 1
                If String.IsNullOrEmpty(Fg(k, 1)) Or String.IsNullOrEmpty(Fg(k, 2)) Or String.IsNullOrEmpty(Fg(k, 3)) Or
                    String.IsNullOrEmpty(Fg(k, 6)) Or String.IsNullOrEmpty(Fg(k, 9)) Then
                    z = z + 1
                End If
            Next
            If z > 0 Then
                If MsgBox("Las partidas de GASTOS que no se capturan complemtamente no se grabaran, Realmente desea continuar?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
            z = 0
            For k = 1 To FgA.Rows.Count - 1
                If String.IsNullOrEmpty(FgA(k, 1)) Or String.IsNullOrEmpty(FgA(k, 3)) Or String.IsNullOrEmpty(FgA(k, 5)) Then
                    z = z + 1
                End If
            Next
            If z > 0 Then
                If MsgBox("Las partidas de VALES que no se capturan complemtamente no se grabaran, Realmente desea continuar?", vbYesNo) = vbNo Then
                    Return
                End If
            End If
        Catch ex As Exception
        End Try

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE


        SQL = "UPDATE GCGASTOS_VIAJE Set CVE_NUM = @CVE_NUM, CVE_OPER = @CVE_OPER, CVE_VIAJE = @CVE_VIAJE, CVE_UNI = @CVE_UNI, FECHA = @FECHA, " &
            "NUM_CPTO = @NUM_CPTO, CVE_AUT = @CVE_AUT, GEN_PAS = @GEN_PAS, LITROS = @LITROS, " &
            "CVE_UNI2 = @CVE_UNI2, TOTAL_COMB = @TOTAL_COMB" &
            " WHERE CVE_NUM = @CVE_NUM " &
            "If @@ROWCOUNT = 0 " &
            "INSERT INTO GCGASTOS_VIAJE (CVE_NUM, STATUS, CVE_OPER, CVE_VIAJE, CVE_UNI, FECHA, FECHAELAB, NUM_CPTO, CVE_AUT, GEN_PAS, LITROS, " &
            "CVE_UNI2, TOTAL_COMB) " &
            "VALUES(@CVE_NUM, 'A', @CVE_OPER, @CVE_VIAJE, @CVE_UNI, @FECHA, GETDATE(), @NUM_CPTO, @CVE_AUT, @GEN_PAS, @LITROS, @CVE_UNI2, " &
            "@TOTAL_COMB)"
        cmd.CommandText = SQL

        Try
            cmd.Parameters.Add("@CVE_NUM", SqlDbType.VarChar).Value = tCVE_NUM.Text
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.VarChar).Value = tCVE_OPER.Text
            cmd.Parameters.Add("@CVE_VIAJE", SqlDbType.VarChar).Value = tCVE_VIAJE.Text
            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = tFECHA.Text
            cmd.Parameters.Add("@NUM_CPTO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(tNUM_CPTO.Text)
            cmd.Parameters.Add("@CVE_AUT", SqlDbType.VarChar).Value = tCVE_AUT.Text
            cmd.Parameters.Add("@GEN_PAS", SqlDbType.SmallInt).Value = IIf(chGEN_PAS.Checked, 1, 0)
            cmd.Parameters.Add("@LITROS", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tLITROS.Value)
            cmd.Parameters.Add("@CVE_UNI2", SqlDbType.VarChar).Value = tCVE_UNI2.Text
            cmd.Parameters.Add("@TOTAL_COMB", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tTOTAL_COMB.Value)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABAR_GASTOS()
                    GRABAR_ANTICIPOS()

                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_GASTOS()
        Try
            Dim z As Integer
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "DELETE FROM GCGASTOS_PAR WHERE CVE_NUM = '" & tCVE_NUM.Text & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            z = 0
            For k = 1 To Fg.Rows.Count - 1

                If Not String.IsNullOrEmpty(Fg(k, 1)) And Not String.IsNullOrEmpty(Fg(k, 2)) And Not String.IsNullOrEmpty(Fg(k, 3)) And
                    Not String.IsNullOrEmpty(Fg(k, 6)) And Not String.IsNullOrEmpty(Fg(k, 9)) Then

                    SQL = "INSERT INTO GCGASTOS_PAR (CVE_NUM, FOLIO, FECHA, CVE_PROV, NUM_CPTO, IMPORTE) VALUES (@CVE_NUM, @FOLIO, @FECHA, " &
                        "@CVE_PROV, @NUM_CPTO, @IMPORTE)"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_NUM", SqlDbType.VarChar).Value = tCVE_NUM.Text
                        cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = Fg(k, 1).ToString
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = Fg(k, 2).ToString
                        cmd.Parameters.Add("@CVE_PROV", SqlDbType.VarChar).Value = Fg(k, 3).ToString
                        cmd.Parameters.Add("@NUM_CPTO", SqlDbType.SmallInt).Value = Fg(k, 6).ToString
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 9).ToString)
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    If Fg(k, 10).ToString.Length = 0 Then
                                        z = z + 1
                                    End If
                                Catch ex As Exception
                                    Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("31. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("31. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            If z > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCFOLIOS SET ULT_DOC = ULT_DOC + " & z & " WHERE TIP_DOC = 'AG' AND SERIE = '" & IIf(SERIE_AG = "" Or SERIE_AG = "STAND.", "STAND.", SERIE_AG) & "'"
                    cmd2.CommandText = SQL
                    cmd2.ExecuteNonQuery()
                End Using
            End If
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("32. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("32. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_ANTICIPOS()
        Try
            Dim k As Integer
            Dim z As Integer
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "DELETE FROM GCGASTOS_ANT WHERE CVE_NUM = '" & tCVE_NUM.Text & "'"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                End If
            End If
            ENTRA = False
            z = 0
            For k = 1 To FgA.Rows.Count - 1
                If Not String.IsNullOrEmpty(FgA(k, 1)) And Not String.IsNullOrEmpty(FgA(k, 3)) And Not String.IsNullOrEmpty(FgA(k, 5)) Then
                    SQL = "INSERT INTO GCGASTOS_ANT (CVE_NUM, FOLIO, FECHA, NUM_CPTO, IMPORTE) VALUES (@CVE_NUM, @FOLIO, @FECHA, @NUM_CPTO, @IMPORTE)"
                    cmd.CommandText = SQL
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_NUM", SqlDbType.VarChar).Value = tCVE_NUM.Text
                        cmd.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = FgA(k, 1).ToString
                        cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = FgA(k, 2).ToString
                        cmd.Parameters.Add("@NUM_CPTO", SqlDbType.VarChar).Value = FgA(k, 3).ToString
                        cmd.Parameters.Add("@IMPORTE", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(FgA(k, 6).ToString)
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Try
                                    If FgA(k, 7).ToString.Length = 0 Then
                                        z = z + 1
                                    End If
                                Catch ex As Exception
                                    Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                                    MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        Bitacora("33. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("33. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Next
            If z > 0 Then
                Using cmd2 As SqlCommand = cnSAE.CreateCommand
                    SQL = "UPDATE GCFOLIOS SET ULT_DOC = ULT_DOC + " & z & " WHERE TIP_DOC = 'AV' AND SERIE = '" & IIf(SERIE_AV = "" Or SERIE_AV = "STAND.", "STAND.", SERIE_AV) & "'"
                    cmd2.CommandText = SQL
                    cmd2.ExecuteNonQuery()
                End Using
            End If
            ENTRA = True
        Catch ex As Exception
            ENTRA = True
            Bitacora("34. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("34. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_VIAJE.Focus()
            End If
        Catch ex As Exception
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNumCpto_Click(sender As Object, e As EventArgs) Handles btnNumCpto.Click
        Try
            Var2 = "GCConc" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tNUM_CPTO.Text = Var4
                LtNumCpto.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_AUT.Focus()
            End If
        Catch ex As Exception
            Bitacora("42. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("42. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAutoriza_Click(sender As Object, e As EventArgs) Handles btnAutoriza.Click
        Try
            Var2 = "Autoriza" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_AUT.Text = Var4
                LtAutoriza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_OPER.Focus()
            End If
        Catch ex As Exception
            Bitacora("43. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("43. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnViaje_Click(sender As Object, e As EventArgs) Handles btnViaje.Click
        Try
            Var2 = "Viajes" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_VIAJE.Text = Var4
                LtViaje.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_UNI.Focus()
            End If
        Catch ex As Exception
            Bitacora("44. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("44. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnUnidad_Click(sender As Object, e As EventArgs) Handles btnUnidad.Click
        Try
            Var2 = "Unidades" : Var4 = "" : Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var4
                LtUnidad.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLITROS.Focus()
            End If
        Catch ex As Exception
            Bitacora("45. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Sub Calcular()
        Dim SUMA As Decimal
        Dim k As Integer

        ENTRA = False
        Try
            SUMA = 0
            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 10) > 0 And Fg(k, 1).ToString.Length > 0 Then
                    SUMA = SUMA + Fg(k, 10)
                End If
            Next

            LtGastos.Text = Format(SUMA, "###,##0.00") 'PRECIOS REAL
        Catch ex As Exception
            Bitacora("107. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("107. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        ENTRA = True
    End Sub

    Private Function Existe_Fg(fCVE_AUT As String) As String
        Try
            ENTRA = False
            Dim Exist_M As Boolean
            Exist_M = False
            For k = 1 To Fg.Rows.Count - 1
                If k <> Fg.Row Then
                    If Fg(k, 1) = fCVE_AUT Then
                        Exist_M = True
                        Exit For
                    End If
                End If
            Next
            ENTRA = True
            Return Exist_M
        Catch ex As Exception
            ENTRA = True
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 2 Or Fg.Col = 3 Or Fg.Col = 4 Or Fg.Col = 6 Or Fg.Col = 7 Or Fg.Col = 9 Then
                    Fg.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("104. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("104. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                Select Case Fg.Col
                    Case 1, 5, 8

                    Case Else
                        If REMOVE_ROW > 0 Then
                            If Fg.Row > 0 Then
                                Fg.Row = REMOVE_ROW
                            End If
                            REMOVE_ROW = 0
                        End If
                        Fg.StartEditing(Fg.Row, Fg.Col)
                End Select
            End If
        Catch ex As Exception
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 1 Or Fg.Col = 5 Or Fg.Col = 8 Then
                    e.Cancel = True
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 Then
                    If Key_Pres = Keys.Right Or Key_Pres = Keys.Left Then
                        Key_Pres = 0
                        e.Cancel = True
                        Exit Sub
                    End If
                    If Fg.Editor.Text.Trim.Length > 0 Then
                        If Existe_Fg(Fg.Editor.Text) Then
                            MsgBox("El gasto se encuentra en el listado, verifique por favor")
                            e.Cancel = True
                            Fg.Editor.Text = ""
                            Return
                        End If
                        Var9 = BUSCA_CAT("Gastos", Fg.Editor.Text)
                        If Var9 <> "" Then
                            'Fg(Fg.Row, 3) = Var9
                        Else
                            e.Cancel = True
                            MsgBox("gasto inexistente")
                            ENTRA = False
                            Fg.Editor.Text = ""
                            ENTRA = True
                            Fg.Col = 3
                        End If

                        Exit Sub
                    Else

                        Select Case Key_Pres
                            Case Keys.Up '38
                            Case Keys.Down '40
                                If Fg.Editor.Text.Trim.Length = 0 Then
                                    e.Cancel = True
                                Else
                                    Key_Pres = 0
                                    e.Cancel = True
                                End If
                            Case 13, 9
                                Key_Pres = 0
                                e.Cancel = True
                            Case Else
                                If Key_Pres = Keys.Right Then
                                    If Fg.Editor.Text.Trim.Length = 0 Then
                                        e.Cancel = True
                                        Key_Pres = 0
                                    End If
                                Else
                                    Key_Pres = 0
                                End If

                        End Select
                        Exit Sub
                    End If
                    Return
                End If
                If e.Col = 3 Then
                    Select Case Key_Pres
                        Case 13, 9
                            'Fg.Select(e.Row, 4)
                    End Select
                    Return
                End If
                If e.Col = 4 Then
                    Select Case Key_Pres
                        Case 13, 9
                            'Fg.Select(e.Row, 6)
                    End Select
                    Return
                End If

                If e.Col = 10 Then
                    'Calcular()
                End If
            End If
        Catch ex As Exception
            Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("108. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        ENTRA_KEY = False
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        ENTRA_KEY = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar la partida?", vbYesNo) = vbYes Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                        Fg.RemoveItem(Fg.Row)
                        'Calcular()
                        ENTRA = False
                        Dim Sigue As Boolean
                        Sigue = False
                        For k = 1 To Fg.Rows.Count - 1
                            If Fg(k, 1).ToString.Trim.Length = 0 Then
                                Sigue = True
                            End If
                        Next
                        If Not Sigue Then
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.Col = 3
                            Fg.StartEditing()
                        End If
                        ENTRA = True
                    Else
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 3
                        Fg.StartEditing()
                    End If
                Else
                    Fg.Row = Fg.Rows.Count - 1
                    Fg.Col = 3
                    Fg.StartEditing()
                End If
            Else
                MsgBox("Por favor seleccione un servicio")
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If ENTRA Then
                If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = Keys.F2 Then
                    Select Case e.Col
                        Case 3
                            'btnProvFg_GotFocus(Nothing, Nothing)
                            SelItemFG(4)
                        Case 6
                            'btnConcFg_GotFocus(Nothing, Nothing)
                            SelItemFG(7)
                    End Select
                    Key_Pres = 0
                    Return
                End If          '38
                If e.KeyCode = Keys.Up And e.Row > 1 Then
                    Key_Pres = e.KeyCode
                    Return
                End If           '40
                If e.KeyCode = Keys.Down Then
                    Key_Pres = e.KeyCode
                    Return
                End If           '39                          37
                If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Then
                    Key_Pres = e.KeyCode
                    Return
                End If
                If e.KeyCode = 27 Then
                    Key_Pres = e.KeyCode
                    If Fg.Col = 1 Then
                        If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 3).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(Fg.Row)
                            REMOVE_ROW = Fg.Row
                            Return
                        End If
                    End If
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("112. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("112. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub Fg_KeyDown(sender As Object, e As KeyEventArgs) Handles Fg.KeyDown
        Try
            If Fg.Row > 0 And ENTRA Then
                If Fg.Col = 1 And e.KeyCode = 27 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Then
                        Fg.RemoveItem(Fg.Row)
                        REMOVE_ROW = Fg.Row
                        Return
                    End If
                    Return
                End If
                If Fg.Col = 1 And e.KeyCode = Keys.Down Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 Then
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.Col = 3
                        Fg.StartEditing()
                        Return
                    End If
                End If
                If Fg.Col = 10 Then
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 And Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then
                        Fg.Col = 3
                        Fg.Row = Fg.Rows.Count - 1
                        Fg.StartEditing()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("141. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("141. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Label2_Paint(sender As Object, e As PaintEventArgs) Handles Label2.Paint
        Dim NewFont As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Dim g As Graphics = e.Graphics

        g.TranslateTransform(0, 100)
        g.RotateTransform(-90)
        g.DrawString("GASTOS", NewFont, Brushes.White, 0, 0)
        g.ResetTransform()
    End Sub
    Private Sub Label7_Paint(sender As Object, e As PaintEventArgs) Handles Label7.Paint
        Dim NewFont As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Dim g As Graphics = e.Graphics

        g.TranslateTransform(0, 100)
        g.RotateTransform(-90)
        g.DrawString("ANTICIPOS", NewFont, Brushes.White, 0, 0)
        g.ResetTransform()

    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUnidad_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("Unidades", tCVE_UNI.Text)
            If Var9 = "N" Then
                MsgBox("Unidad inexistente")
            Else
                LtUnidad.Text = Var9
                chGEN_PAS.Focus()
            End If
        End If
    End Sub
    Private Sub tCVE_UNI2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUni2_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("Unidades", tCVE_UNI2.Text)
            If Var9 = "N" Then
                MsgBox("Unidad inexistente")
                Return
            Else
                LtUni2.Text = Var9
            End If
            Fg.Focus()
        End If
    End Sub
    Private Sub btnUni2_Click(sender As Object, e As EventArgs) Handles btnUni2.Click
        Try
            Var2 = "Unidades" : Var4 = "" : Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI2.Text = Var4
                LtUni2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tLITROS.Focus()
            End If
        Catch ex As Exception
            Bitacora("45. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("45. " & ex.Message & vbNewLine & ex.StackTrace)

        End Try
    End Sub
    Private Sub tNUM_CPTO_KeyDown(sender As Object, e As KeyEventArgs) Handles tNUM_CPTO.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNumCpto_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("GCConc", tNUM_CPTO.Text)
            If Var9 = "N" Then
                MsgBox("Concepto inexistente")
                Return
            Else
                LtNumCpto.Text = Var9
            End If
        End If
    End Sub

    Private Sub tCVE_AUT_TextChanged(sender As Object, e As EventArgs) Handles tCVE_AUT.TextChanged

    End Sub

    Private Sub tCVE_AUT_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_AUT.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnAutoriza_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("Autoriza", tCVE_AUT.Text)
            If Var9 = "N" Then
                MsgBox("Registro no inexistente")
                Return
            Else
                LtAutoriza.Text = Var9
            End If
        End If
    End Sub

    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("Operador", tCVE_OPER.Text)
            If Var9 = "N" Then
                MsgBox("Concepto inexistente")
                Return
            Else
                LtOper.Text = Var9
            End If
        End If
    End Sub
    Private Sub tCVE_VIAJE_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_VIAJE.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnViaje_Click(Nothing, Nothing)
            Return
        End If
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Var9 = BUSCA_CAT("Viajes", tCVE_VIAJE.Text)
            If Var9 = "N" Then
                MsgBox("Viaje inexistente")
                Return
            Else
                LtViaje.Text = Var9
            End If
        End If
    End Sub


    Private Sub Fg_AfterEdit(sender As Object, e As RowColEventArgs) Handles Fg.AfterEdit
        Try
            If e.Row > 0 And ENTRA Then
                If e.Col = 10 Then
                    If Fg(e.Row, 1).ToString.Trim.Length > 0 And Fg(e.Row, 3).ToString.Trim.Length > 0 Then
                        If Fg.Row = Fg.Rows.Count - 1 Then
                            Fg.Col = 3
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.StartEditing()
                            Return
                        End If
                    End If

                End If
                If e.Col = 1 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then
                            ENTRA = False
                            Fg.Col = 3
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.StartEditing()
                            ENTRA = True
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 4).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                Fg.Col = 3
                                Return
                            End If
                        Else
                            If Fg(e.Row, 1).ToString.Trim.Length > 0 Then
                                Fg.Select(e.Row, e.Col + 1)
                            End If
                        End If
                    End If
                    Return
                End If
                If e.Col = 3 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then
                            Fg.Col = 3
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.StartEditing()
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 4).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                Fg.Col = 3
                                Return
                            End If
                        Else
                            Key_Pres = 0
                            If Fg(e.Row, 3).ToString.Trim.Length > 0 Then
                                Fg.Select(e.Row, e.Col)
                            End If
                        End If
                    End If
                    Return
                End If
                If e.Col = 4 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then
                            Fg.Col = 3
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.StartEditing()
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 4).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                Fg.Col = 3
                                Return
                            End If
                        Else
                            Key_Pres = 0
                            If Fg(e.Row, 4).ToString.Trim.Length > 0 Then
                                Fg.Select(e.Row, e.Col + 2)
                            End If
                        End If
                    End If
                    Return
                End If
                If e.Col = 7 Then
                    If Key_Pres = Keys.Down Then
                        Key_Pres = 0
                        If e.Row = Fg.Rows.Count - 1 Then
                            Fg.Col = 3
                            Fg.Row = Fg.Rows.Count - 1
                            Fg.StartEditing()
                            Return
                        End If
                    Else
                        If Key_Pres = Keys.Up Then
                            If Fg(e.Row, 1).ToString.Trim.Length = 0 Or Fg(e.Row, 4).ToString.Trim.Length = 0 Then
                                Fg.RemoveItem(e.Row)
                                REMOVE_ROW = Fg.Row
                                Fg.Col = 3
                                Return
                            End If
                        Else
                            Key_Pres = 0
                            If Fg(e.Row, 7).ToString.Trim.Length > 0 Then
                                Fg.Select(e.Row, e.Col + 2)
                            End If
                        End If
                    End If
                    Return
                End If


            End If
        Catch ex As Exception
            MsgBox("109. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    '***********************************************************************************************************************
    '***********************************************************************************************************************
    '***********************************************************************************************************************
    '                    FG ANTICIPOS  FG ANTICIPOS  FG ANTICIPOS  FG ANTICIPOS  FG ANTICIPOS  FG ANTICIPOS  
    '***********************************************************************************************************************
    '***********************************************************************************************************************
    '***********************************************************************************************************************
    Private Sub FgA_AfterEdit(sender As Object, e As RowColEventArgs) Handles FgA.AfterEdit
        Try
            If e.Row > 0 Then
                If e.Col = 1 Then
                    If Key_Pres2 = Keys.Down Then
                        Key_Pres2 = 0
                        If e.Row = FgA.Rows.Count - 1 Then
                            FgA.Row = FgA.Rows.Count - 1
                            FgA.Col = 3
                            FgA.StartEditing()
                            Return
                        End If
                    Else
                        If Key_Pres2 = Keys.Up Then
                            Key_Pres2 = 0
                            If FgA(e.Row, 1).ToString.Trim.Length = 0 Or FgA(e.Row, 3).ToString.Trim.Length = 0 Then
                                FgA.RemoveItem(e.Row)
                                REMOVE_ROW = FgA.Row
                                Return
                            End If
                        Else
                            If FgA(e.Row, 1).ToString.Trim.Length > 0 Then
                                FgA.Select(e.Row, e.Col + 2)
                            End If
                        End If
                    End If
                    Return
                End If

            End If
        Catch ex As Exception
            MsgBox("109. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("109. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_BeforeEdit(sender As Object, e As RowColEventArgs) Handles FgA.BeforeEdit
        Try
            If FgA.Row > 0 And ENTRA2 Then
                If FgA.Col = 1 Or FgA.Col = 5 Then
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            MsgBox("106. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("106. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_EnterCell(sender As Object, e As EventArgs) Handles FgA.EnterCell
        Try
            If FgA.Row > 0 And ENTRA2 Then
                If FgA.Col = 1 Or FgA.Col = 5 Then
                Else
                    If REMOVE_ROW > 0 Then
                        If FgA.Row > 0 Then
                            FgA.Row = REMOVE_ROW
                        End If
                        REMOVE_ROW = 0
                    End If
                    FgA.StartEditing()
                End If
            End If
        Catch ex As Exception
            MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_GotFocus(sender As Object, e As EventArgs) Handles FgA.GotFocus
        ENTRA_KEY = False
    End Sub
    Private Sub FgA_LostFocus(sender As Object, e As EventArgs) Handles FgA.LostFocus
        ENTRA_KEY = True
    End Sub
    Private Sub FgA_KeyDown(sender As Object, e As KeyEventArgs) Handles FgA.KeyDown
        Try
            If FgA.Row > 0 Then
                If FgA.Col = 2 And e.KeyCode = 27 Then
                    If Fg(FgA.Row, 1).ToString.Trim.Length = 0 Or FgA(FgA.Row, 3).ToString.Trim.Length = 0 Then
                        FgA.RemoveItem(FgA.Row)
                        REMOVE_ROW = FgA.Row
                        Return
                    End If
                    Return
                End If
                If FgA.Col = 2 And e.KeyCode = Keys.Down Then
                    If FgA(FgA.Row, 1).ToString.Trim.Length > 0 And FgA(FgA.Row, 3).ToString.Trim.Length > 0 Then
                        FgA.Row = FgA.Rows.Count - 1
                        FgA.Col = 3
                        FgA.StartEditing()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles FgA.KeyDownEdit
        Try
            If e.KeyCode = Keys.Up And e.Row > 1 Then
                Key_Pres2 = e.KeyCode
                Return
            End If
            If e.KeyCode = Keys.Down Then
                Key_Pres2 = e.KeyCode
                Return
            End If
            If e.KeyCode = Keys.Right Or e.KeyCode = Keys.Left Then
                Key_Pres2 = e.KeyCode
                Return
            End If
            If e.KeyCode = 13 Or e.KeyCode = Keys.Tab Then
                Key_Pres2 = e.KeyCode
                Return
            End If
            If e.KeyCode = 27 Then
                Key_Pres2 = e.KeyCode
                If FgA.Col = 2 Then
                    If FgA(FgA.Row, 1).ToString.Trim.Length = 0 Or FgA(FgA.Row, 3).ToString.Trim.Length = 0 Then
                        FgA.RemoveItem(FgA.Row)
                        REMOVE_ROW = FgA.Row
                        Return
                    End If
                End If
                Return
            End If
        Catch ex As Exception
            MsgBox("111. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("111. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FgA_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles FgA.ValidateEdit
        Try
            If FgA.Row > 0 And ENTRA2 Then
                If FgA.Col = 3 Then
                    If Key_Pres2 = Keys.Right Or Key_Pres2 = Keys.Left Then
                        Key_Pres2 = 0
                        e.Cancel = True
                        Return
                    End If
                    If FgA.Editor.Text.Trim.Length > 0 Then
                        If Existe_FgA(FgA.Editor.Text) Then
                            MsgBox("El Anticipo ya fue agregado verifique por favor")
                            e.Cancel = True
                            FgA.Editor.Text = ""
                            FgA(FgA.Row, 3) = ""
                            Return
                        End If
                        BUSCA_ANTICIPOS_VIAJE(FgA.Editor.Text)

                        If Var8 = "NO" Then
                            e.Cancel = True
                            MsgBox("Anticipo inexistente")
                        Else
                            FgA(FgA.Row, 3) = Var8
                            FgA(FgA.Row, 4) = Var9
                            FgA(FgA.Row, 5) = Var10
                        End If
                        If Key_Pres2 = 13 Or Key_Pres2 = 9 Then
                            Key_Pres2 = 0
                            e.Cancel = True
                            If FgA(FgA.Row, 1).ToString.Trim.Length > 0 And FgA(FgA.Row, 3).ToString.Trim.Length > 0 Then
                                If FgA.Row = FgA.Rows.Count - 1 Then
                                    FgA.Row = FgA.Rows.Count - 1
                                    FgA.Col =
                                    FgA.StartEditing()
                                    Return
                                Else
                                    FgA.Row = FgA.Row + 1
                                End If
                            End If
                        End If
                    Else
                        Select Case Key_Pres2
                            Case Keys.Up '38
                            Case Keys.Down '40
                                If FgA.Editor.Text.Trim.Length = 0 Then
                                    e.Cancel = True
                                Else
                                    Key_Pres2 = 0
                                    e.Cancel = True
                                End If
                            Case 13, 9
                                Key_Pres2 = 0
                                e.Cancel = True
                            Case Else
                                If Key_Pres2 = Keys.Right Then
                                    If FgA.Editor.Text.Trim.Length = 0 Then
                                        e.Cancel = True
                                        Key_Pres2 = 0
                                    End If
                                Else
                                    Key_Pres2 = 0
                                End If

                        End Select
                    End If
                End If
            End If
        Catch ex As Exception
            Bitacora("108. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("108. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Function Existe_FgA(fCVE_AUT As String) As String
        Try
            ENTRA2 = False
            Dim Exist_M As Boolean
            Exist_M = False
            For k = 1 To FgA.Rows.Count - 1
                If k <> FgA.Row Then
                    If FgA(k, 3) = fCVE_AUT Then
                        Exist_M = True
                        Exit For
                    End If
                End If
            Next
            ENTRA2 = True
            Return Exist_M
        Catch ex As Exception
            ENTRA2 = True
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub frmGastosDeViajeAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        CloseTab("Gastos de Viaje")
        Me.Dispose()
    End Sub

    Private Sub btnAlta2_Click(sender As Object, e As EventArgs) Handles btnAlta2.Click
        Try
            Dim z As Integer

            If FgA(FgA.Rows.Count - 1, 2).ToString.Trim.Length = 0 Then
                Return
            End If
            z = 0
            For k = 1 To FgA.Rows.Count - 1
                z = z + 1
            Next
            FgA.AddItem("" & vbTab & (FOLIO_AV + z) & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
            FgA.Row = FgA.Rows.Count - 1
            FgA.Col = 3
            FgA.StartEditing()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Try
            Dim z As Integer

            If Fg(Fg.Rows.Count - 1, 3).ToString.Trim.Length = 0 Then
                Return
            End If
            z = 0
            For k = 1 To Fg.Rows.Count - 1
                z = z + 1
            Next
            Fg.AddItem("" & vbTab & (FOLIO_AG + z) & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "" & vbTab & "")
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 3
            Fg.StartEditing()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminar2_Click(sender As Object, e As EventArgs) Handles btnEliminar2.Click

    End Sub
    Private Sub btnProvFg_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Select Case e.Col
                Case 4
                    SelItemFG(4)
                Case 7
                    SelItemFG(7)
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Sub SelItemFG(fCol As Integer)
        Select Case fCol
            Case 4
                Try
                    Var2 = "Prov" : Var4 = "" : Var5 = ""
                    Fg.FinishEditing()
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Fg(Fg.Row, 3) = Var4
                        Fg(Fg.Row, 5) = Var5
                        Var2 = "" : Var4 = "" : Var5 = ""
                        Fg.Col = 6
                        Fg.StartEditing()
                    Else
                        Fg.Col = 3
                    End If
                Catch ex As Exception
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
            Case 7
                Try
                    Var2 = "GCConc"
                    Var4 = ""
                    Var5 = ""
                    Fg.FinishEditing()
                    frmSelItem.ShowDialog()
                    If Var4.Trim.Length > 0 Then
                        Fg(Fg.Row, 6) = Var4
                        Fg(Fg.Row, 8) = Var5
                        Var2 = ""
                        Var4 = ""
                        Var5 = ""
                        Fg.Select(Fg.Row, 9)
                    Else
                        Fg.Col = 6
                    End If
                Catch ex As Exception
                    Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
                    MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
                End Try
        End Select
    End Sub
    Private Sub FgA_CellButtonClick(sender As Object, e As RowColEventArgs) Handles FgA.CellButtonClick
        Try
            If e.Col = 4 Then
                Var4 = "" : Var5 = "" : Var6 = ""
                Var2 = "AnticipoCat"
                FgA.FinishEditing()
                frmSelItem.ShowDialog()
                If Var4.Trim.Length > 0 Then
                    If Existe_FgA(Var4) Then
                        MsgBox("El anticipo ya fue agregado verifique por favor")
                        FgA(FgA.Row, 1) = ""
                        FgA.Col = 3
                        FgA.StartEditing()
                        Return
                    End If
                    FgA(FgA.Row, 3) = Var4
                    FgA(FgA.Row, 5) = Var5
                    Var2 = "" : Var4 = "" : Var5 = "" : Var6 = ""
                    FgA.Row = FgA.Rows.Count - 1
                    FgA.Col = 3
                    FgA.StartEditing()
                Else
                    FgA.Col = 3
                    FgA.StartEditing()
                End If
            End If
        Catch ex As Exception
            Bitacora("110. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("110. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
