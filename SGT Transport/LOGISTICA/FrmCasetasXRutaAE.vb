Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmCasetasXRutaAE
    Private Sub FrmCasetasXRutaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim s As String

            Me.KeyPreview = True
            barMenu.BackColor = Color.FromArgb(164, 177, 202)

            Fg.Rows.Count = 1
            Fg.Redraw = False

            Fg.Rows(0).Height = 40

            BtnPlaza.FlatStyle = FlatStyle.Flat
            BtnPlaza.FlatAppearance.BorderSize = 0
            BtnCLAVE_REM.FlatStyle = FlatStyle.Flat
            BtnCLAVE_REM.FlatAppearance.BorderSize = 0
            BtnPlaza2.FlatStyle = FlatStyle.Flat
            BtnPlaza2.FlatAppearance.BorderSize = 0


            Me.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Me.Left = 15

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CAS, DESCR, CVE_PLAZA, CASE WHEN C.TIPO_PAGO = 'M' THEN 'Multitag' ELSE 'Efectivo' END AS TIPOPAGO, ISNULL(IMPORTE,0) AS T1,
                    ISNULL(IMPORTE2,0) AS T2,ISNULL(IMPORTE3,0) AS T3, ISNULL(IMPORTE4,0) AS T4, ISNULL(IMPORTE5,0) AS T5, ISNULL(IMPORTE6,0) AS T6,
                    ISNULL(IMPORTE7,0) AS T7, ISNULL(IMPORTE8,0) AS T8, CLAVE_OP, IAVE, ISNULL(CRUCE,1) AS CRUZE
                    FROM GCCASETAS C
                    WHERE C.STATUS = 'A'"

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read

                        s = "" & vbTab '1
                        s &= dr("CVE_CAS") & vbTab '2
                        s &= dr("DESCR") & vbTab '3
                        s &= dr("TIPOPAGO") & vbTab '4
                        s &= dr("CVE_PLAZA") & vbTab '5
                        s &= dr("CRUZE") & vbTab '6
                        s &= dr("T1") / dr("CRUZE") & vbTab '7
                        s &= dr("T1") & vbTab '8
                        s &= False & vbTab '9
                        s &= dr("T2") / dr("CRUZE") & vbTab '10
                        s &= dr("T2") & vbTab '11
                        s &= False & vbTab '12
                        s &= dr("T3") / dr("CRUZE") & vbTab '13
                        s &= dr("T3") & vbTab '14
                        s &= False & vbTab '15
                        s &= dr("T4") / dr("CRUZE") & vbTab '16
                        s &= dr("T4") & vbTab '17
                        s &= False & vbTab '18
                        s &= dr("T5") / dr("CRUZE") & vbTab '19
                        s &= dr("T5") & vbTab '20
                        s &= False & vbTab '21 
                        s &= dr("T6") / dr("CRUZE") & vbTab '22
                        s &= dr("T6") & vbTab '23
                        s &= False & vbTab '24
                        s &= dr("T7") / dr("CRUZE") & vbTab '25
                        s &= dr("T7") & vbTab '26
                        s &= False & vbTab '27
                        s &= dr("T8") / dr("CRUZE") & vbTab '28
                        s &= dr("T8") & vbTab '29
                        s &= False & vbTab '30
                        s &= dr("CLAVE_OP") & vbTab '31
                        s &= dr("IAVE") '32

                        Fg.AddItem("" & vbTab & s)
                        ' & vbTab & dr("NOMBRE") & vbTab & dr("IAVE")
                    End While
                    'Fg.AutoSizeCols()
                End Using
            End Using
            Fg.Redraw = True
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        tCVE_PLAZA.Tag = ""
        tCVE_PLAZA2.Tag = ""
        LtPlaza.Tag = ""
        LtPlaza2.Tag = ""

        If Var1 = "Nuevo" Then
            Try
                TCVE_CXR.Text = GET_MAX("GCCASETAS_X_RUTA", "CVE_CXR")
                TCVE_CXR.Enabled = False
                tCVE_PLAZA.Text = ""
                tCVE_PLAZA.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_CXR, C.STATUS, C.CVE_PLAZA, C.CVE_PLAZA2, P1.CIUDAD AS CIUDAD1, P2.CIUDAD AS CIUDAD2, 
                    ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, C.CLAVE_OP, C.IAVE, OP.NOMBRE, ISNULL(P1.STATUS,'A') AS ST_PLAZA, 
                    ISNULL(P2.STATUS,'A') AS ST_PLAZA2
                    FROM GCCASETAS_X_RUTA C 
                    LEFT JOIN GCCLIE_OP OP On OP.CLAVE = C.CLAVE_OP
                    LEFT JOIN GCPLAZAS P1 On P1.CLAVE = C.CVE_PLAZA 
                    LEFT JOIN GCPLAZAS P2 On P2.CLAVE = C.CVE_PLAZA2
                    WHERE CVE_CXR = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_CXR.Text = dr("CVE_CXR")

                    If dr.ReadNullAsEmptyInteger("CVE_PLAZA") = 0 Then
                        tCVE_PLAZA.Text = ""
                    Else
                        tCVE_PLAZA.Text = dr.ReadNullAsEmptyString("CVE_PLAZA")
                        tCVE_PLAZA.Tag = dr.ReadNullAsEmptyString("ST_PLAZA")
                    End If
                    If dr.ReadNullAsEmptyInteger("CVE_PLAZA2") = 0 Then
                        tCVE_PLAZA2.Text = ""
                    Else
                        tCVE_PLAZA2.Text = dr.ReadNullAsEmptyString("CVE_PLAZA2")
                        tCVE_PLAZA2.Tag = dr.ReadNullAsEmptyString("ST_PLAZA2")
                    End If
                    LtPlaza.Text = dr.ReadNullAsEmptyString("CIUDAD1")
                    LtPlaza.Tag = tCVE_PLAZA.Text
                    LtPlaza2.Text = dr.ReadNullAsEmptyString("CIUDAD2")
                    LtPlaza2.Tag = tCVE_PLAZA2.Text

                    LtImporte.Text = Format(dr("IMPORTE"), "###,###,##0.00")

                    tCLAVE_O.Text = dr.ReadNullAsEmptyString("CLAVE_OP")
                    LtNombre1.Text = dr.ReadNullAsEmptyString("NOMBRE")
                    TIAVE.Text = dr.ReadNullAsEmptyString("IAVE")
                Else
                    tCVE_PLAZA.Text = ""
                End If
                dr.Close()

                DESPLEGAR_PAR()

                TCVE_CXR.Enabled = False
                tCVE_PLAZA.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

        Me.CenterToScreen()

        Me.SplitContainer1.Panel1MinSize = 40
        Me.SplitContainer1.Panel2MinSize = 60

    End Sub
    Sub DESPLEGAR_PAR()
        Dim NewStyle1 As CellStyle
        NewStyle1 = Fg.Styles.Add("NewStyle1")
        NewStyle1.BackColor = Color.Yellow

        Try
            Dim SUMA As Decimal = 0, EJE As Integer, z As Integer

            If IsNumeric(TCVE_CXR.Text) Then
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    SQL = "SELECT CVE_CXR, CVE_CAS, ISNULL(CRUCE,0) AS CRUZE, EJE2, IMPORTE2, EJE3, IMPORTE3, EJE4, 
                        IMPORTE4, EJE5, IMPORTE5, EJE6, IMPORTE6, EJE7, IMPORTE7, EJE8, IMPORTE8, 
                        EJE9, IMPORTE9 
                        FROM GCCASETAS_X_RUTA_PAR 
                        WHERE CVE_CXR =  " & CInt(TCVE_CXR.Text)
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For row As Integer = 1 To Fg.Rows.Count - 1
                                z = 0
                                If Fg(row, 2) = dr("CVE_CAS") Then
                                    Fg(row, 1) = True
                                    EJE = dr("EJE2")
                                    If dr("EJE2") Then
                                        Fg(row, 9) = True
                                        SUMA += Fg(row, 8)
                                        Fg(row, 8) = dr("IMPORTE8")
                                        Fg(row, 7) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 9, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE3") Then
                                        Fg(row, 12) = True
                                        SUMA += Fg(row, 11)
                                        Fg(row, 11) = dr("IMPORTE8")
                                        Fg(row, 10) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 12, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE4") Then
                                        Fg(row, 15) = True
                                        SUMA += Fg(row, 14)
                                        Fg(row, 14) = dr("IMPORTE8")
                                        Fg(row, 13) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 15, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE5") Then
                                        Fg(row, 18) = True
                                        SUMA += Fg(row, 17)
                                        Fg(row, 17) = dr("IMPORTE8")
                                        Fg(row, 16) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 18, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE6") Then
                                        Fg(row, 21) = True
                                        SUMA += Fg(row, 20)
                                        Fg(row, 20) = dr("IMPORTE8")
                                        Fg(row, 19) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 21, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE7") Then
                                        Fg(row, 24) = True
                                        SUMA += Fg(row, 23)
                                        Fg(row, 23) = dr("IMPORTE8")
                                        Fg(row, 22) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 24, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE8") Then
                                        Fg(row, 27) = True
                                        SUMA += Fg(row, 26)
                                        Fg(row, 26) = dr("IMPORTE8")
                                        Fg(row, 25) = dr("IMPORTE8") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 23, NewStyle1)
                                        z += 1
                                    End If
                                    If dr("EJE9") Then
                                        Fg(row, 30) = True
                                        Fg(row, 29) = dr("IMPORTE9")
                                        Fg(row, 28) = dr("IMPORTE9") / dr.ReadNullAsEmptyInteger("CRUZE")
                                        SUMA += Fg(row, 29)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 26, NewStyle1)
                                        z += 1
                                    End If

                                    If z > 0 Then
                                        Fg.SetCellStyle(row, 0, NewStyle1)
                                    End If
                                End If
                            Next

                        End While
                        LtImporte.Text = Format(SUMA, "###,###,##0.00")
                    End Using
                End Using
            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCasetasXRutaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub btnPlaza_Click(sender As Object, e As EventArgs) Handles BtnPlaza.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCVE_PLAZA2.Focus()
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_PLAZA_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA.Validated
        Try
            If tCVE_PLAZA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                    'tCVE_PLAZA2.Focus()
                Else
                    If tCVE_PLAZA.Tag <> "B" And tCVE_PLAZA.Text <> LtPlaza.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA.Focus()
                        tCVE_PLAZA.Text = ""
                        LtPlaza.Text = ""
                    End If
                End If
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles BtnPlaza2.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_PLAZA2.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tCLAVE_O.Focus()
            End If
        Catch ex As Exception
            Bitacora("588. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("588. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_PLAZA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_PLAZA2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnPlaza2_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_PLAZA2_Validated(sender As Object, e As EventArgs) Handles tCVE_PLAZA2.Validated
        Try
            If tCVE_PLAZA2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tCVE_PLAZA2.Text)
                If DESCR <> "" Then
                    LtPlaza2.Text = DESCR
                    'tCLAVE_O.Focus()
                Else
                    If tCVE_PLAZA2.Tag <> "B" And tCVE_PLAZA2.Text <> LtPlaza2.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tCVE_PLAZA2.Focus()
                        tCVE_PLAZA2.Text = ""
                        LtPlaza2.Text = ""
                    End If
                End If
            Else
                LtPlaza2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("125. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("125. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim IMPORTE As Decimal = 0
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            If IsNumeric(LtImporte.Text.Replace(",", "")) Then
                IMPORTE = LtImporte.Text.Replace(",", "")
            Else
                IMPORTE = 0
            End If
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        '         
        SQL = "UPDATE GCCASETAS_X_RUTA SET CVE_PLAZA = @CVE_PLAZA, CVE_PLAZA2 = @CVE_PLAZA2, IMPORTE_CASETAS = @IMPORTE_CASETAS, 
            CLAVE_OP = @CLAVE_OP, IAVE = @IAVE
            WHERE CVE_CXR = @CVE_CXR
            IF @@ROWCOUNT = 0
            INSERT INTO GCCASETAS_X_RUTA (CVE_CXR, STATUS, CVE_PLAZA, CVE_PLAZA2, IMPORTE_CASETAS, CLAVE_OP, IAVE, UUID) VALUES (@CVE_CXR, 'A', 
            @CVE_PLAZA, @CVE_PLAZA2, @IMPORTE_CASETAS, @CLAVE_OP, @IAVE, NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_CXR", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_CXR.Text)
            cmd.Parameters.Add("@CVE_PLAZA", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PLAZA.Text)
            cmd.Parameters.Add("@CVE_PLAZA2", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_PLAZA2.Text)
            cmd.Parameters.Add("@IMPORTE_CASETAS", SqlDbType.Int).Value = IMPORTE
            cmd.Parameters.Add("@CLAVE_OP", SqlDbType.VarChar).Value = tCLAVE_O.Text
            cmd.Parameters.Add("@IAVE", SqlDbType.VarChar).Value = TIAVE.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    GRABAR_GASOLINERAS()
                    MsgBox("El registro se grabo satisfactoriamente")

                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_GASOLINERAS()
        Try
            SQL = "DELETE FROM GCCASETAS_X_RUTA_PAR WHERE CVE_CXR = '" & TCVE_CXR.Text & "'"
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using

            For row As Integer = 1 To Fg.Rows.Count - 1

                If Fg(row, 1) Then

                    SQL = "INSERT INTO GCCASETAS_X_RUTA_PAR (CVE_CXR, CVE_CAS, CRUCE, EJE2, IMPORTE2, EJE3, IMPORTE3, EJE4, IMPORTE4, EJE5, IMPORTE5, EJE6, 
                        IMPORTE6, EJE7, IMPORTE7, EJE8, IMPORTE8, EJE9, IMPORTE9, UUID) VALUES('" & TCVE_CXR.Text & "','" & Fg(row, 2) & "','" & Fg(row, 6) & "','" &
                        Fg(row, 9) & "','" & Fg(row, 8) & "','" & Fg(row, 12) & "','" & Fg(row, 11) & "','" & Fg(row, 15) & "','" & Fg(row, 14) & "','" &
                        Fg(row, 18) & "','" & Fg(row, 17) & "','" & Fg(row, 21) & "','" & Fg(row, 20) & "','" & Fg(row, 24) & "','" & Fg(row, 23) & "','" &
                        Fg(row, 27) & "','" & Fg(row, 26) & "','" & Fg(row, 30) & "','" & Fg(row, 29) & "',NEWID())"

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
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellChecked(sender As Object, e As RowColEventArgs) Handles Fg.CellChecked
        Try
            Dim SUMA As Decimal = 0

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1) Then
                    If Fg(k, 9) Then SUMA += Fg(k, 8) * Fg(k, 6)
                    If Fg(k, 12) Then SUMA += Fg(k, 11) * Fg(k, 6)
                    If Fg(k, 15) Then SUMA += Fg(k, 14) * Fg(k, 6)
                    If Fg(k, 18) Then SUMA += Fg(k, 17) * Fg(k, 6)
                    If Fg(k, 21) Then SUMA += Fg(k, 20) * Fg(k, 6)
                    If Fg(k, 24) Then SUMA += Fg(k, 23) * Fg(k, 6)
                    If Fg(k, 27) Then SUMA += Fg(k, 26) * Fg(k, 6)
                    If Fg(k, 30) Then SUMA += Fg(k, 29) * Fg(k, 6)
                End If
            Next
            LtImporte.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles BtnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            FrmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then

                tCLAVE_O.Text = Var4
                LtNombre1.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
                TIAVE.Focus()
            End If
        Catch ex As Exception
            Bitacora("58. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("58. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnCLAVE_REM_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCLAVE_O_Validated(sender As Object, e As EventArgs) Handles tCLAVE_O.Validated
        Try
            If tCLAVE_O.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Cliente operativo", tCLAVE_O.Text, False)
                If DESCR.Trim.Length > 0 Then
                    LtNombre1.Text = DESCR
                    'TIAVE.Focus()
                Else
                    MsgBox("Cliente operativo inexistente")
                    LtNombre1.Text = ""
                End If
            Else
                LtNombre1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TIAVE_KeyDown(sender As Object, e As KeyEventArgs) Handles TIAVE.KeyDown
        If e.KeyCode = 13 Then
            Fg.Focus()
        End If
    End Sub
    Private Sub TIAVE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TIAVE.PreviewKeyDown
        If e.KeyCode = 9 Then
            Fg.Select()
            Fg.Focus()
        End If
    End Sub

    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            Dim SUMA As Decimal = 0, SUMA_EJE As Decimal = 0

            If Fg.Row > 0 Then
                If Fg.Col = 6 Then

                    For k = 1 To Fg.Rows.Count - 1
                        If k <> Fg.Row Then
                            If Fg(k, 1) Then
                                If Fg(k, 9) Then SUMA += Fg(k, 8) * Fg(k, 6)
                                If Fg(k, 12) Then SUMA += Fg(k, 11) * Fg(k, 6)
                                If Fg(k, 15) Then SUMA += Fg(k, 14) * Fg(k, 6)
                                If Fg(k, 18) Then SUMA += Fg(k, 17) * Fg(k, 6)
                                If Fg(k, 21) Then SUMA += Fg(k, 20) * Fg(k, 6)
                                If Fg(k, 24) Then SUMA += Fg(k, 23) * Fg(k, 6)
                                If Fg(k, 27) Then SUMA += Fg(k, 26) * Fg(k, 6)
                                If Fg(k, 30) Then SUMA += Fg(k, 29) * Fg(k, 6)
                            End If
                        End If
                    Next
                    If IsNumeric(Fg.Editor.Text) Then
                        Fg(Fg.Row, 8) = Fg(Fg.Row, 7) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 11) = Fg(Fg.Row, 10) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 14) = Fg(Fg.Row, 13) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 17) = Fg(Fg.Row, 16) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 20) = Fg(Fg.Row, 19) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 23) = Fg(Fg.Row, 22) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 26) = Fg(Fg.Row, 25) * CDec(Fg.Editor.Text)
                        Fg(Fg.Row, 29) = Fg(Fg.Row, 28) * CDec(Fg.Editor.Text)


                        If Fg(Fg.Row, 9) Then SUMA += Fg(Fg.Row, 8) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 12) Then SUMA += Fg(Fg.Row, 11) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 15) Then SUMA += Fg(Fg.Row, 14) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 18) Then SUMA += Fg(Fg.Row, 17) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 21) Then SUMA += Fg(Fg.Row, 20) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 24) Then SUMA += Fg(Fg.Row, 23) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 27) Then SUMA += Fg(Fg.Row, 26) * CDec(Fg.Editor.Text)
                        If Fg(Fg.Row, 30) Then SUMA += Fg(Fg.Row, 29) * CDec(Fg.Editor.Text)

                    End If
                    LtImporte.Text = Format(SUMA, "###,###,##0.00")
                End If
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
