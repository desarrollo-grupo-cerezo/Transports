Imports System.Data.SqlClient
Imports C1.Win.C1FlexGrid

Public Class FrmCasetasXRutaAE
    Private Sub FrmCasetasXRutaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.KeyPreview = True

            Fg.Rows.Count = 1
            Fg.Redraw = False

            Me.Width = Screen.PrimaryScreen.Bounds.Width - 25
            Me.Left = 15

            ', C.CLAVE_OP, C.IAVE, OP.NOMBRE
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CVE_CAS, DESCR, CVE_PLAZA, CASE WHEN C.TIPO_PAGO = 'M' THEN 'Multitag' ELSE 'Efectivo' END AS TIPOPAGO, ISNULL(IMPORTE,0) AS T1,
                    ISNULL(IMPORTE2,0) AS T2,ISNULL(IMPORTE3,0) AS T3, ISNULL(IMPORTE4,0) AS T4, ISNULL(IMPORTE5,0) AS T5, ISNULL(IMPORTE6,0) AS T6,
                    ISNULL(IMPORTE7,0) AS T7, ISNULL(IMPORTE8,0) AS T8, CLAVE_OP, IAVE
                    FROM GCCASETAS C
                    WHERE C.STATUS = 'A'" ' AND CVE_CAS "

                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & "" & vbTab & dr("CVE_CAS") & vbTab & dr("DESCR") & vbTab & dr("TIPOPAGO") & vbTab & dr("CVE_PLAZA") & vbTab &
                                   dr("T1") & vbTab & False & vbTab & dr("T2") & vbTab & False & vbTab & dr("T3") & vbTab & False & vbTab &
                                   dr("T4") & vbTab & False & vbTab & dr("T5") & vbTab & False & vbTab & dr("T6") & vbTab & False & vbTab &
                                   dr("T7") & vbTab & False & vbTab & dr("T8") & vbTab & False & vbTab & dr("CLAVE_OP") & vbTab & dr("IAVE"))
                        ' & vbTab & dr("NOMBRE") & vbTab & dr("IAVE")
                    End While
                    Fg.AutoSizeCols()
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
                    ISNULL(IMPORTE_CASETAS,0) AS IMPORTE, C.CLAVE_OP, C.IAVE, OP.NOMBRE, ISNULL(P1.STATUS,'A') AS ST_PLAZA, ISNULL(P2.STATUS,'A') AS ST_PLAZA2
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
                        tCVE_PLAZA.Text = dr("CVE_PLAZA")
                        tCVE_PLAZA.Tag = dr("ST_PLAZA")
                    End If
                    If dr.ReadNullAsEmptyInteger("CVE_PLAZA2") = 0 Then
                        tCVE_PLAZA2.Text = ""
                    Else
                        tCVE_PLAZA2.Text = dr("CVE_PLAZA2")
                        tCVE_PLAZA2.Tag = dr("ST_PLAZA2")
                    End If
                    LtPlaza.Text = dr.ReadNullAsEmptyString("CIUDAD1")
                    LtPlaza.Tag = tCVE_PLAZA.Text
                    LtPlaza2.Text = dr.ReadNullAsEmptyString("CIUDAD2")
                    LtPlaza2.Tag = tCVE_PLAZA2.Text

                    LtImporte.Text = Format(dr("IMPORTE"), "###,###,##0.00")

                    tCLAVE_O.Text = dr("CLAVE_OP")
                    LtNombre1.Text = dr("NOMBRE")
                    TIAVE.Text = dr("IAVE")
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
                    SQL = "SELECT * FROM GCCASETAS_X_RUTA_PAR WHERE CVE_CXR =  " & CInt(TCVE_CXR.Text)
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            For row As Integer = 1 To Fg.Rows.Count - 1
                                z = 0
                                If Fg(row, 2) = dr("CVE_CAS") Then
                                    Fg(row, 1) = True
                                    EJE = dr("EJE2")
                                    If dr("EJE2") Then
                                        Fg(row, 7) = True
                                        SUMA = SUMA + Fg(row, 6)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 7, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE3") Then
                                        Fg(row, 9) = True
                                        SUMA = SUMA + Fg(row, 8)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 9, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE4") Then
                                        Fg(row, 11) = True
                                        SUMA = SUMA + Fg(row, 10)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 11, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE5") Then
                                        Fg(row, 13) = True
                                        SUMA = SUMA + Fg(row, 12)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 13, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE6") Then
                                        Fg(row, 15) = True
                                        SUMA = SUMA + Fg(row, 14)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 15, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE7") Then
                                        Fg(row, 17) = True
                                        SUMA = SUMA + Fg(row, 16)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 17, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE8") Then
                                        Fg(row, 19) = True
                                        SUMA = SUMA + Fg(row, 18)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 19, NewStyle1)
                                        z = z + 1
                                    End If
                                    If dr("EJE9") Then
                                        Fg(row, 21) = True
                                        SUMA = SUMA + Fg(row, 20)
                                        Fg.SetCellStyle(row, 3, NewStyle1)
                                        Fg.SetCellStyle(row, 21, NewStyle1)
                                        z = z + 1
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

    Private Sub btnPlaza_Click(sender As Object, e As EventArgs) Handles btnPlaza.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
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
    Private Sub btnPlaza2_Click(sender As Object, e As EventArgs) Handles btnPlaza2.Click
        Try
            Var2 = "Plazas"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
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
                    SQL = "INSERT INTO GCCASETAS_X_RUTA_PAR (CVE_CXR, CVE_CAS, EJE2, IMPORTE2, EJE3, IMPORTE3, EJE4, IMPORTE4, EJE5, IMPORTE5, EJE6, 
                        IMPORTE6, EJE7, IMPORTE7, EJE8, IMPORTE8, EJE9, IMPORTE9, UUID) VALUES('" & TCVE_CXR.Text & "','" & Fg(row, 2) & "','" &
                        Fg(row, 7) & "','" & Fg(row, 6) & "','" & Fg(row, 9) & "','" & Fg(row, 8) & "','" & Fg(row, 11) & "','" & Fg(row, 10) & "','" &
                        Fg(row, 13) & "','" & Fg(row, 12) & "','" & Fg(row, 15) & "','" & Fg(row, 14) & "','" & Fg(row, 17) & "','" & Fg(row, 16) & "','" &
                        Fg(row, 19) & "','" & Fg(row, 18) & "','" & Fg(row, 21) & "','" & Fg(row, 20) & "',NEWID())"
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
                    If Fg(k, 7) Then SUMA = SUMA + Fg(k, 6)
                    If Fg(k, 9) Then SUMA = SUMA + Fg(k, 8)
                    If Fg(k, 11) Then SUMA = SUMA + Fg(k, 10)
                    If Fg(k, 13) Then SUMA = SUMA + Fg(k, 12)
                    If Fg(k, 15) Then SUMA = SUMA + Fg(k, 14)
                    If Fg(k, 17) Then SUMA = SUMA + Fg(k, 16)
                    If Fg(k, 19) Then SUMA = SUMA + Fg(k, 18)
                    If Fg(k, 21) Then SUMA = SUMA + Fg(k, 20)
                End If
            Next
            LtImporte.Text = Format(SUMA, "###,###,##0.00")
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnCLAVE_REM_Click(sender As Object, e As EventArgs) Handles btnCLAVE_REM.Click
        Try
            Var2 = "Cliente operativo" '       GCCLIE_OP
            Var4 = "" : Var5 = "" : Var6 = "" : Var7 = "" : Var8 = ""
            frmSelItem2.ShowDialog()
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
End Class
