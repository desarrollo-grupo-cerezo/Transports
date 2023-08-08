Imports System.IO
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1FlexGrid
Public Class frmProgServiciosAE
    Private ENTRA As Boolean
    Private ENTRA_KEY As Boolean
    Private row_ As Integer
    Private Sub frmProgServiciosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"

        F2.Value = Date.Today
        F2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        F2.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F2.EditFormat.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"

        Me.CenterToScreen()
        Me.KeyPreview = True
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        ENTRA = True
        ENTRA_KEY = True
        Fg.Rows.Count = 1
        Try
            tCVE_PROG.Text = ""
            tCVE_UNI.Text = ""
            F1.Value = Now
            tCVE_UNI.Text = ""
            LtUnidad.Text = ""
            tKM_ACTUAL.Value = 0
            tKM_PROX_SERVICIO.Value = 0
            F2.Value = Now
            tOBSER.Text = ""
            tOBSER.Tag = "0"
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                F3.Value = vbEmpty
                F4.Value = vbEmpty
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                Fg.Row = Fg.Rows.Count - 1

                BarFinalizado.Enabled = False
                BarCancelar.Enabled = False
                BarImprimir.Enabled = False

                tCVE_PROG.Text = GET_MAX("GCPROGAMACION_SERVICIOS", "CVE_PROG")
                tCVE_PROG.Enabled = False
                tCVE_UNI.Text = ""
                tCVE_UNI.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT P.CVE_PROG, P.STATUS, T.DESCR, P.FECHA_CREA, P.FECHA_PROG, P.FECHA_INI_SER, P.FECHA_FIN, P.CVE_UNI, " &
                    "P.KM_ACTUAL, P.KM_PROX_SERVICIO, CVE_ORD, ISNULL(P.CVE_OBS,0) AS OBS_CVE, OB.DESCR AS OBS_STR, ISNULL(CVE_SER,'') AS C_SER " &
                    "FROM GCPROGAMACION_SERVICIOS P " &
                    "LEFT JOIN GCUNIDADES U ON U.CLAVEMONTE = P.CVE_UNI " &
                    "LEFT JOIN GCTIPO_UNIDAD T ON T.CVE_UNI = U.CVE_TIPO_UNI " &
                    "LEFT JOIN GCOBS OB ON OB.CVE_OBS = P.CVE_OBS " &
                    "WHERE CVE_PROG = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    tCVE_PROG.Text = dr("CVE_PROG")

                    If IsDate(dr("FECHA_CREA")) Then
                        F1.Value = dr("FECHA_CREA")
                    Else
                        'F1.Value = Now
                    End If
                    If IsDate(dr("FECHA_PROG")) Then
                        F2.Value = dr("FECHA_PROG")
                    Else
                        'F2.Value = Now
                    End If
                    If IsDate(dr("FECHA_INI_SER")) Then
                        F3.Value = dr("FECHA_INI_SER")
                    Else
                        'F3.Value = Now
                    End If
                    If IsDate(dr("FECHA_FIN")) Then
                        F4.Value = dr("FECHA_FIN")
                    Else
                        'F4.Value = Now
                    End If
                    tCVE_UNI.Text = dr.ReadNullAsEmptyString("CVE_UNI")
                    LtUnidad.Text = dr.ReadNullAsEmptyString("DESCR") 'BUSCA_CAT("Unidades", tCVE_UNI.Text)
                    tKM_ACTUAL.Value = IIf(IsNumeric(dr("KM_ACTUAL")), dr("KM_ACTUAL"), 0)
                    tKM_PROX_SERVICIO.Value = IIf(IsNumeric(dr("KM_PROX_SERVICIO")), dr("KM_PROX_SERVICIO"), 0)

                    tOBSER.Text = dr("OBS_STR").ToString
                    tOBSER.Tag = dr("OBS_CVE").ToString

                    tCVE_SER.Text = dr("C_SER")
                    'ACTIVIDAD DE MANTENIMIENTO
                    'TABLA GCSERVICIOS_MANTE
                    LtActMante.Text = BUSCA_CAT("ServiciosOrdenes", tCVE_SER.Text)
                    CARGA_PROG_SERV_PART()
                Else
                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                    Fg.Row = Fg.Rows.Count - 1
                End If
                dr.Close()
                tCVE_PROG.Enabled = False
                tCVE_UNI.Select()
                Select Case Var4
                    Case "Cancelado", "Finalizado"
                        LtStatus.Text = Var4
                        BarGrabar.Enabled = False
                        BarFinalizado.Enabled = False
                        BarCancelar.Enabled = False
                        tKM_ACTUAL.Enabled = False
                        tKM_PROX_SERVICIO.Enabled = False
                        tCVE_UNI.Enabled = False
                        btnUnidad.Enabled = False
                        tCVE_SER.Enabled = False
                        BtnActManto.Enabled = False
                        tOBSER.Enabled = False
                        btnEliProd.Enabled = False
                        BtnActManto.Enabled = False
                        btnAltaProducto.Enabled = False
                        F1.Enabled = False
                        F2.Enabled = False
                        F3.Enabled = False
                        F4.Enabled = False
                        Fg.Enabled = False
                    Case Else
                        LtStatus.Text = Var4
                End Select
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CARGA_PROG_SERV_PART()
        Try
            ENTRA = False
            Fg.Rows.Count = 1
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT P.CVE_ART, DESCR FROM GCPROGAMACION_SERVICIOS_PAR P " &
                    "LEFT JOIN INVE" & Empresa & " I ON I.CVE_ART = P.CVE_ART " &
                    "WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & "" & vbTab & dr("DESCR"))
                    End While
                End Using
            End Using
            If Fg.Rows.Count = 1 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                Fg.Row = Fg.Rows.Count - 1
            End If
        Catch ex As Exception
            MsgBox("20. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("20. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        ENTRA = True
    End Sub
    Private Sub frmProgServiciosAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                Grabar()
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)
        End Select
    End Sub
    Private Sub frmProgServiciosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = ChrW(Keys.Return) And ENTRA_KEY Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub Grabar()
        Dim Cadena_cx As String = "", z As Integer = 0
        Dim CVE_OBS As Long

        If tCVE_UNI.Text.Trim.Length = 0 Then
            MsgBox("La unidad no debe quedar vacia, verifique por favor")
            Return
        End If
        Try
            If tOBSER.Text.Trim.Length > 0 Then
                If IsNumeric(tOBSER.Tag) Then
                    CVE_OBS = tOBSER.Tag
                Else
                    CVE_OBS = 0
                End If

                If CVE_OBS = 0 Then
                    SQL = "INSERT INTO GCOBS (CVE_OBS, DESCR) OUTPUT Inserted.CVE_OBS VALUES((SELECT ISNULL(MAX(CVE_OBS),0) + 1 FROM GCOBS),'" & tOBSER.Text & "')"
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteScalar.ToString
                        If returnValue IsNot Nothing Then
                            If CLng(returnValue) > 0 Then
                                CVE_OBS = returnValue
                            End If
                        End If
                    End Using
                Else
                    SQL = "UPDATE GCOBS SET DESCR = '" & tOBSER.Text & "' WHERE CVE_OBS = " & CVE_OBS
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
            tOBSER.Tag = CVE_OBS
        Catch ex As Exception
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        returnValue = 99
        For k = 1 To 3
            Try
                '28 FEB 20
                If Not Valida_Conexion() Then
                    Exit For
                End If
                SQL = "UPDATE GCPROGAMACION_SERVICIOS SET FECHA_CREA = @FECHA_CREA, FECHA_PROG = @FECHA_PROG, CVE_SER = @CVE_SER, " &
                    "CVE_UNI = @CVE_UNI, KM_ACTUAL = @KM_ACTUAL, KM_PROX_SERVICIO = @KM_PROX_SERVICIO, CVE_OBS = @CVE_OBS " &
                    "WHERE CVE_PROG = @CVE_PROG " &
                    "IF @@ROWCOUNT = 0 " &
                    "INSERT INTO GCPROGAMACION_SERVICIOS (CVE_PROG, STATUS, FECHA_CREA, FECHA_PROG, CVE_UNI, CVE_SER, KM_ACTUAL, " &
                    "KM_PROX_SERVICIO, FECHAELAB, CVE_OBS, UUID) VALUES (@CVE_PROG, '', GETDATE(), @FECHA_PROG, @CVE_UNI, @CVE_SER, " &
                    "@KM_ACTUAL, @KM_PROX_SERVICIO, GETDATE(), @CVE_OBS, NEWID())"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    cmd.Parameters.Add("@CVE_PROG", SqlDbType.VarChar).Value = tCVE_PROG.Text
                    cmd.Parameters.Add("@FECHA_CREA", SqlDbType.DateTime).Value = F1.Value
                    cmd.Parameters.Add("@FECHA_PROG", SqlDbType.DateTime).Value = F2.Value
                    cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
                    cmd.Parameters.Add("@CVE_SER", SqlDbType.VarChar).Value = tCVE_SER.Text
                    cmd.Parameters.Add("@KM_ACTUAL", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKM_ACTUAL.Text)
                    cmd.Parameters.Add("@KM_PROX_SERVICIO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(tKM_PROX_SERVICIO.Text)
                    cmd.Parameters.Add("@CVE_OBS", SqlDbType.VarChar).Value = CVE_OBS
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                            z = returnValue
                            GRABAR_PAR()
                            MsgBox("El registro se grabo satisfactoriamente")
                            Me.Close()
                        Else
                            MsgBox("No se logro grabar el registro")
                        End If
                    Else
                        MsgBox("No se logro grabar el registro")
                    End If
                End Using
            Catch ex As Exception
                'MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Cadena_cx = ex.Message & vbNewLine & ex.StackTrace
            End Try
            If z = 1 Then
                Exit For
            End If
        Next
        Try
            If returnValue = 99 Then
                MsgBox("10. " & Cadena_cx)
            End If
        Catch ex As Exception
        End Try

    End Sub
    Sub GRABAR_PAR()
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "DELETE FROM GCPROGAMACION_SERVICIOS_PAR WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
        Try
            Dim cmd As New SqlCommand
            cmd.Connection = cnSAE

            SQL = "INSERT INTO GCPROGAMACION_SERVICIOS_PAR (CVE_PROG, STATUS, CVE_ART, UUID) VALUES(@CVE_PROG, 'A', @CVE_ART, NEWID())"
            cmd.CommandText = SQL

            For k = 1 To Fg.Rows.Count - 1
                If Fg(k, 1).ToString.Trim.Length > 0 Then
                    Try
                        cmd.Parameters.Clear()
                        cmd.Parameters.Add("@CVE_PROG", SqlDbType.VarChar).Value = tCVE_PROG.Text
                        cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = Fg(k, 1)
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                End If
            Next
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
    Private Sub btnUnidad_Click(sender As Object, e As EventArgs) Handles btnUnidad.Click
        Try
            Var2 = "Unidades"
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'Var4 = Fg(Fg.Row, 1).ToString  'CLAVE
                'Var5 = Fg(Fg.Row, 2).ToString   'CLAVE MONTE
                'Var6 = Fg(Fg.Row, 3).ToString   'NOMBRE
                'Var7 = Fg(Fg.Row, 4).ToString   'TIPO UNI
                'Var8 = Fg(Fg.Row, 5).ToString   'PLACAS
                'Var9 = Fg(Fg.Row, 6).ToString   'tipo unidad
                tCVE_UNI.Text = Var5
                LtUnidad.Text = Var6
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_SER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub MenuHolder_CommandClick(sender As Object, e As CommandClickEventArgs) Handles MenuHolder.CommandClick
        Try
            Select Case e.Command.Text.Trim
                Case "Grabar"
                    Grabar()
                Case "Iniciar servicio"
                    INICIAR_PRO_SER()
                Case "Finalizar servicio"
                    FINALIZAR_PRO_SER()
                Case "Cancelar"
                    CANCELAR_PRO_SER()
                Case "Salir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub
    Sub CANCELAR_PRO_SER()
        Try
            If MsgBox("Realmente desea cancelar la progrmacion de servicio?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCPROGAMACION_SERVICIOS SET STATUS = 'C', FECHA_CAN = GETDATE() WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El registro se cancelo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub FINALIZAR_PRO_SER()
        Try
            If MsgBox("Realmente desea Finalizar la programación del servicio?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCPROGAMACION_SERVICIOS SET STATUS = 'F', FECHA_FIN = GETDATE() WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("La programación de servicio se Finalizo satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub INICIAR_PRO_SER()
        Try
            If MsgBox("Realmente desea iniciar la programación del servicio?", vbYesNo) = vbYes Then
                SQL = "UPDATE GCPROGAMACION_SERVICIOS SET STATUS = 'I', FECHA_INI_SER = GETDATE() WHERE CVE_PROG = '" & tCVE_PROG.Text & "'"
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("La programación de servicio se Inicio satisfactoriamente")
                        Me.Close()
                    Else
                        MsgBox("NO se logro eliminar el registro")
                    End If
                Else
                    MsgBox("!!NO se logro eliminar el registro!!")
                End If
            End If
        Catch ex As Exception
            MsgBox("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("12. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_BeforeEdit(sender As Object, e As RowColEventArgs) Handles Fg.BeforeEdit
        Try
            If e.Row > 0 And ENTRA Then
                ENTRA = False
                If e.Col = 3 Then
                    e.Cancel = True
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            MsgBox("127. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("127. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_CellButtonClick(sender As Object, e As RowColEventArgs) Handles Fg.CellButtonClick
        Try
            Var2 = "InvenRP"
            Var4 = "" : Var5 = ""
            Fg.FinishEditing()
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                ENTRA = False
                Fg.FinishEditing()
                row_ = Fg.Row
                If Existe_Servicio(Var4) Then
                    MsgBox("Articulo ya fue agregado")
                Else
                    Fg(Fg.Row, 1) = Var4  'CVE_ART
                    Fg(Fg.Row, 3) = Var5  'DESCR
                    Var2 = "" : Var4 = "" : Var5 = ""
                    If Fg(Fg.Row, 1).ToString.Trim.Length > 0 And Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then
                        If Fg.Row = Fg.Rows.Count - 1 Then
                            Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                            Fg.Row = Fg.Rows.Count - 1
                        Else
                            Fg.Row = Fg.Row + 1
                        End If
                    End If
                End If

                Fg.Col = 1
                Fg.StartEditing()
                ENTRA = True
                Return
            Else
                Fg.Col = 1
            End If
        Catch ex As Exception
            MsgBox("127. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("127. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_KeyDownEdit(sender As Object, e As KeyEditEventArgs) Handles Fg.KeyDownEdit
        Try
            If Not ENTRA Then
                Return
            End If

            If LtStatus.Text = "FINALIZADA" Then
                Return
            End If
            If e.KeyCode = 27 Then
                If Fg.Col = 1 Then
                    Try
                        If Fg(Fg.Row, 1).ToString.Trim.Length = 0 Or Fg(Fg.Row, 3).ToString.Trim.Length = 0 Then
                            Fg.RemoveItem(Fg.Row)
                            Return
                        End If
                    Catch ex As Exception
                        Fg.RemoveItem(Fg.Row)
                    End Try
                End If
                Return
            End If
            If Fg.Col = 1 And e.KeyCode = Keys.F2 Then
                Fg_CellButtonClick(Nothing, Nothing)
                Return
            End If
            If (e.KeyCode = 13 Or e.KeyCode = 9) And ENTRA Then
                ENTRA = False
                Select Case e.Col
                    Case 1, 2, 3
                        row_ = e.Row
                        If Existe_Servicio(Fg.Editor.Text) Then
                            MsgBox("Articulo ya fue agregado")
                            Fg.Editor.Text = ""

                            'Fg.StartEditing()
                            ENTRA = True
                            tBotonMagico.Focus()
                            Fg.Col = 1
                            Fg.StartEditing()
                        Else
                            If Fg(e.Row, 1).ToString.Trim.Length > 0 And Fg(e.Row, 3).ToString.Trim.Length > 0 Then
                                If Fg.Row = Fg.Rows.Count - 1 Then
                                    Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
                                    Fg.Row = Fg.Rows.Count - 1
                                Else
                                    Fg.Row = Fg.Row + 1
                                End If
                            End If
                            Fg.Col = 1
                            Fg.StartEditing()
                            ENTRA = True
                        End If
                        Return
                End Select
                ENTRA = True
                Return
            End If
        Catch ex As Exception
            ENTRA = True
            Bitacora("121. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("121. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_ValidateEdit(sender As Object, e As ValidateEditEventArgs) Handles Fg.ValidateEdit
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If Fg.Col = 1 Then
                    If Fg.Editor.Text.Trim.Length > 0 Then
                        Dim DESCR As String
                        row_ = Fg.Row
                        If Existe_Servicio(Fg.Editor.Text) Then
                            MsgBox("Articulo ya fue agregado")
                        Else
                            DESCR = BUSCA_CAT("InvenRP", Fg.Editor.Text)
                            If DESCR <> "" Then
                                Fg(Fg.Row, 1) = Fg.Editor.Text
                                Fg(Fg.Row, 3) = DESCR
                            Else
                                e.Cancel = True
                                MsgBox("Articulo inexistente")
                            End If
                        End If
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            MsgBox("118. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("118. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_EnterCell(sender As Object, e As EventArgs) Handles Fg.EnterCell
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If LtStatus.Text = "FINALIZADA" Then
                    Fg.FinishEditing()
                    ENTRA = True
                    Return
                End If
                If Fg.Col = 3 Then

                Else
                    Fg.StartEditing()
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            MsgBox("115. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("115. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_Click(sender As Object, e As EventArgs) Handles Fg.Click
        Try
            If Fg.Row > 0 And ENTRA Then
                ENTRA = False
                If LtStatus.Text = "FINALIZADA" Then
                Else
                    If Fg.Col = 1 Or Fg.Col = 2 Then
                        Fg.StartEditing()
                    End If
                End If
                ENTRA = True
            End If
        Catch ex As Exception
            MsgBox("124. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("124. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Function Existe_Servicio(fCVE_ART As String) As Boolean
        Try
            Dim ExistOk As Boolean = False
            For k = 1 To Fg.Rows.Count - 1
                If k <> row_ Then
                    If Fg(k, 1) = fCVE_ART Then
                        ExistOk = True
                        Exit For
                    End If
                End If
            Next
            Return ExistOk
        Catch ex As Exception
            MsgBox("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("300. " & ex.Message & vbNewLine & ex.StackTrace)
            Return False
        End Try
    End Function
    Private Sub tBotonMagico_GotFocus(sender As Object, e As EventArgs) Handles tBotonMagico.GotFocus
        Try
            Fg.Select()
            Fg.StartEditing(Fg.Row, 1)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAltaProducto_Click(sender As Object, e As EventArgs) Handles btnAltaProducto.Click
        Try
            If Fg(Fg.Rows.Count - 1, 1).ToString.Trim.Length > 0 And Fg(Fg.Rows.Count - 1, 3).ToString.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & "" & vbTab & "" & vbTab & "")
            End If
            Fg.Row = Fg.Rows.Count - 1
            Fg.Col = 1
            Fg.StartEditing()

        Catch ex As Exception
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub btnEliProd_Click(sender As Object, e As EventArgs) Handles btnEliProd.Click
        Try
            If Fg.Row > 0 Then
                Try
                    If Fg(Fg.Row, 1).ToString.Length = 0 Then
                        Fg.Col = 1
                        Fg.StartEditing()
                        Return
                    End If
                Catch ex As Exception
                End Try
                If MsgBox("Realmente desea eliminar la partida (artículo " & Fg(Fg.Row, 1) & ") ?", vbYesNo) = vbYes Then
                    Try
                        Fg.RemoveItem(Fg.Row)
                    Catch ex As Exception
                        Bitacora("105. " & ex.Message & vbNewLine & ex.StackTrace)
                        MsgBox("105. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try
                End If
            Else
                MsgBox("Por favor seleccione un servicio")
            End If
        Catch ex As Exception
            Bitacora("430. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("430. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub Fg_GotFocus(sender As Object, e As EventArgs) Handles Fg.GotFocus
        ENTRA_KEY = False
    End Sub
    Private Sub Fg_LostFocus(sender As Object, e As EventArgs) Handles Fg.LostFocus
        ENTRA_KEY = True
    End Sub
    Private Sub frmProgServiciosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BtnActManto_Click(sender As Object, e As EventArgs) Handles BtnActManto.Click
        Try
            Var2 = "ServiciosOrdenes"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_SER.Text = Var4
                LtActMante.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tOBSER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_SER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_SER.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                BtnActManto_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_SER_Validated(sender As Object, e As EventArgs) Handles tCVE_SER.Validated
        Try
            If tCVE_SER.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("ServiciosOrdenes", tCVE_SER.Text)
                If DESCR <> "" Then
                    LtActMante.Text = DESCR
                    tOBSER.Focus()
                Else
                    MsgBox("Act. mantenimiento inexistente")
                    tCVE_SER.Text = ""
                    LtActMante.Text = ""
                    tCVE_SER.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        Try
            If e.KeyCode = Keys.F2 Then
                btnUnidad_Click(Nothing, Nothing)
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Tipo unidad2", tCVE_UNI.Text)
                If DESCR <> "" Then
                    LtUnidad.Text = DESCR
                    tCVE_SER.Focus()
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    LtUnidad.Text = ""
                    tCVE_UNI.Select()
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarInicioService_Click(sender As Object, e As ClickEventArgs)

    End Sub

    Private Sub BarFinalizado_Click(sender As Object, e As ClickEventArgs) Handles BarFinalizado.Click

    End Sub

    Private Sub BarImprimir_Click(sender As Object, e As ClickEventArgs) Handles BarImprimir.Click
        Dim RUTA_FORMATOS As String = ""
        Try
            RUTA_FORMATOS = GET_RUTA_FORMATOS()
            If Not File.Exists(RUTA_FORMATOS & "\ReportProgServicios.mrt") Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\ReportProgServicios.mrt, verifique por favor")
                Return
            End If

            StiReport1.Load(RUTA_FORMATOS & "\ReportProgServicios.mrt")

            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("REFER") = tCVE_PROG.Text
            StiReport1.Render()
            'StiReport1.Print(True)
            StiReport1.Show()
        Catch ex As Exception
            Bitacora("420. " & ex.Message & vbNewLine & ex.StackTrace & vbNewLine & RUTA_FORMATOS)
            MsgBox("420. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
