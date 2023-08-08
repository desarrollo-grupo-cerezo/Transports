Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class frmEstatusOperCaptura
    Private Sub frmEstatusOperCaptura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT P.CLAVE, P.NOMBRE, P.CVE_ST_OPER, P.CVE_TRACTOR, P.CVE_TANQUE1, P.CVE_TANQUE2, P.CVE_OBS, O.DESCR AS STR_OBS
                    FROM GCOPERADOR P
                    LEFT JOIN GCOBS O ON O.CVE_OBS = P.CVE_OBS
                    WHERE CLAVE = " & Var44
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        LtClave.Text = dr.ReadNullAsEmptyString("CLAVE")
                        LtNombre.Text = dr.ReadNullAsEmptyString("NOMBRE")
                        tCVE_TRACTOR.Text = dr.ReadNullAsEmptyString("CVE_TRACTOR").ToString
                        LtTractor.Text = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)

                        tCVE_TANQUE1.Text = dr.ReadNullAsEmptyString("CVE_TANQUE1").ToString
                        LTanque1.Text = BUSCA_CAT("Unidad", tCVE_TANQUE1.Text)

                        tCVE_TANQUE2.Text = dr.ReadNullAsEmptyString("CVE_TANQUE2").ToString
                        LTanque2.Text = BUSCA_CAT("Unidad", tCVE_TANQUE2.Text)

                        tCVE_OBS.Text = dr.ReadNullAsEmptyString("STR_OBS")
                        tCVE_OBS.Tag = dr.ReadNullAsEmptyDecimal("CVE_OBS")
                    Else
                        tCVE_TRACTOR.Text = ""
                        tCVE_TANQUE1.Text = ""
                        tCVE_TANQUE2.Text = ""
                        tCVE_OBS.Text = ""
                        LtNombre.Text = ""
                        LtClave.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub frmEstatusOperCaptura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim CVE_OBS As Long = 0
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            If tCVE_OBS.Text.Trim.Length > 0 Then
                If IsNumeric(tCVE_OBS.Tag) Then
                    CVE_OBS = tCVE_OBS.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tCVE_OBS.Text & "')"
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteScalar.ToString
                    If returnValue IsNot Nothing Then
                        If CLng(returnValue) > 0 Then
                            CVE_OBS = returnValue
                        End If
                    End If
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tCVE_OBS.Text & "' WHERE CVE_OBS = " & CVE_OBS
                    cmd.Connection = cnSAE
                    cmd.CommandText = SQL
                    returnValue = cmd.ExecuteNonQuery.ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then

                        End If
                    End If
                End If
            End If
            tCVE_OBS.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("40. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("40. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            SQL = "UPDATE GCOPERADOR SET CVE_TRACTOR = @CVE_TRACTOR, CVE_TANQUE1 = @CVE_TANQUE1, CVE_TANQUE2 = @CVE_TANQUE2, CVE_OBS = @CVE_OBS
                WHERE CLAVE = @CLAVE "
            cmd.CommandText = SQL
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@CLAVE", SqlDbType.Int).Value = LtClave.Text
            cmd.Parameters.Add("@CVE_TRACTOR", SqlDbType.VarChar).Value = tCVE_TRACTOR.Text
            cmd.Parameters.Add("@CVE_TANQUE1", SqlDbType.VarChar).Value = tCVE_TANQUE1.Text
            cmd.Parameters.Add("@CVE_TANQUE2", SqlDbType.VarChar).Value = tCVE_TANQUE2.Text
            cmd.Parameters.Add("@CVE_OBS", SqlDbType.Int).Value = CVE_OBS
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("52. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("52. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub tCVE_TRACTOR_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TRACTOR.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTractor_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_TRACTOR_Validated(sender As Object, e As EventArgs) Handles tCVE_TRACTOR.Validated
        Try
            Dim DESCR As String
            If tCVE_TRACTOR.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TRACTOR.Text)
                If DESCR <> "" Then
                    If UNIDAD_ASIGNADA_A_OPERADOR(Var44, tCVE_TRACTOR.Text) Then
                        MsgBox("La unidad actualmente se encuentra asignada " & vbNewLine & Var3)
                        tCVE_TRACTOR.Text = ""
                        LtTractor.Text = ""
                        tCVE_TRACTOR.Select()
                        Return
                    End If
                    Var3 = ""
                    LtTractor.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TRACTOR.Text = ""
                    LtTractor.Text = ""
                    tCVE_TRACTOR.Select()
                End If
            Else
                tCVE_TANQUE1.Tag = ""
                LtTractor.Text = ""
            End If
        Catch ex As Exception
            Bitacora("250. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("250. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTractor_Click(sender As Object, e As EventArgs) Handles btnTractor.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "1" : Var5 = ""
            frmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If UNIDAD_ASIGNADA_A_OPERADOR(Var44, Var5) Then
                    MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                    tCVE_TRACTOR.Text = ""
                    tCVE_TRACTOR.Tag = ""
                    LtTractor.Text = ""
                    tCVE_TRACTOR.Select()
                    Return
                End If
                tCVE_TRACTOR.Text = Var5
                LtTractor.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                tCVE_TANQUE1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("320. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TANQUE1_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TANQUE1.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque1_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub tCVE_TANQUE1_Validated(sender As Object, e As EventArgs) Handles tCVE_TANQUE1.Validated
        Try
            Dim DESCR As String
            If tCVE_TANQUE1.Text.Length > 0 Then
                Var4 = ""
                Var3 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TANQUE1.Text)
                If DESCR <> "" Then
                    If tCVE_TANQUE2.Text = tCVE_TANQUE1.Text And tCVE_TANQUE2.Text.Trim.Length > 0 And tCVE_TANQUE1.Text.Trim.Length > 0 Then
                        MsgBox("La unidad actualmente se encuentra asignada en el " & tCVE_TANQUE2.Text)
                        tCVE_TANQUE1.Text = ""
                        LTanque1.Text = ""
                        tCVE_TANQUE1.Select()
                        Return
                    End If
                    If UNIDAD_ASIGNADA_A_OPERADOR(Var44, tCVE_TANQUE1.Text) Then
                        MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                        tCVE_TANQUE1.Text = ""
                        LTanque1.Text = ""
                        tCVE_TANQUE1.Select()
                        Return
                    End If
                    Var3 = ""
                    LTanque1.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TANQUE1.Text = ""
                    tCVE_TANQUE1.Tag = ""
                    LTanque1.Text = ""
                    tCVE_TANQUE1.Select()
                End If
            Else
                tCVE_TANQUE1.Tag = ""
                LTanque1.Text = ""
            End If
        Catch ex As Exception
            Bitacora("260. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("260. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTanque1_Click(sender As Object, e As EventArgs) Handles btnTanque1.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var3 = "" : Var5 = ""
            frmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If tCVE_TANQUE2.Text = tCVE_TANQUE1.Text And tCVE_TANQUE2.Text.Trim.Length > 0 And tCVE_TANQUE1.Text.Trim.Length > 0 Then
                    MsgBox("La unidad actualmente se encuentra asignada en el " & tCVE_TANQUE2.Text)
                    tCVE_TANQUE1.Text = ""
                    LTanque1.Text = ""
                    tCVE_TANQUE1.Select()
                    Return
                End If
                If UNIDAD_ASIGNADA_A_OPERADOR(Var44, Var5) Then
                    MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                    tCVE_TANQUE1.Text = ""
                    LTanque1.Text = ""
                    tCVE_TANQUE1.Select()
                    Return
                End If
                tCVE_TANQUE1.Text = Var5
                LTanque1.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = "" : Var5 = ""
                tCVE_TANQUE1.Focus()
            End If
        Catch Ex As Exception
            Bitacora("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("340. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_TANQUE2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_TANQUE2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnTanque2_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tCVE_TANQUE2_Validated(sender As Object, e As EventArgs) Handles tCVE_TANQUE2.Validated
        Try
            Dim DESCR As String
            If tCVE_TANQUE2.Text.Length > 0 Then
                Var4 = ""
                DESCR = BUSCA_CAT("Unidad", tCVE_TANQUE2.Text)
                If DESCR <> "" Then
                    If tCVE_TANQUE2.Text = tCVE_TANQUE1.Text And tCVE_TANQUE2.Text.Trim.Length > 0 And tCVE_TANQUE1.Text.Trim.Length > 0 Then
                        MsgBox("La unidad actualmente se encuentra asignada en el " & tCVE_TANQUE1.Text)
                        tCVE_TANQUE2.Text = ""
                        LTanque2.Text = ""
                        tCVE_TANQUE1.Select()
                        Return
                    End If
                    If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                        If UNIDAD_ASIGNADA_A_OPERADOR(Var44, tCVE_TANQUE2.Text) Then
                            MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                            tCVE_TANQUE2.Text = ""
                            LTanque2.Text = ""
                            tCVE_TANQUE2.Select()
                            Return
                        End If
                    End If

                    Var3 = ""
                    tCVE_TANQUE2.Tag = DESCR
                    LTanque2.Text = DESCR
                Else
                    MsgBox("Tanque inexistente")
                    tCVE_TANQUE2.Text = ""
                    tCVE_TANQUE2.Tag = ""
                    LTanque2.Text = ""
                End If
            Else
                tCVE_TANQUE2.Tag = ""
                LTanque2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("280. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("280. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnTanque2_Click(sender As Object, e As EventArgs) Handles btnTanque2.Click
        Try
            Var2 = "Unidades"
            Var3 = "" : Var4 = "2" : Var5 = ""
            frmSelItem2.ShowDialog()
            If Var5.Trim.Length > 0 Then
                If tCVE_TANQUE2.Text.Trim.Length > 0 Then
                    If tCVE_TANQUE2.Text = tCVE_TANQUE1.Text And tCVE_TANQUE2.Text.Trim.Length > 0 And tCVE_TANQUE1.Text.Trim.Length > 0 Then
                        MsgBox("La unidad actualmente se encuentra asignada en el " & tCVE_TANQUE1.Text)
                        tCVE_TANQUE2.Text = ""
                        LTanque2.Text = ""
                        tCVE_TANQUE2.Select()
                        Return
                    End If
                    If UNIDAD_ASIGNADA_A_OPERADOR(Var44, tCVE_TANQUE2.Text) Then
                        MsgBox("La unidad actualmente se encuentra asignada " & Var3)
                        tCVE_TANQUE2.Text = ""
                        LTanque2.Text = ""
                        tCVE_TANQUE2.Select()
                        Return
                    End If
                End If
                tCVE_TANQUE2.Text = Var5
                LTanque2.Text = Var6
                Var2 = "" : Var3 = "" : Var4 = ""
                Var5 = ""
            End If
        Catch Ex As Exception
            Bitacora("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("360. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
End Class
