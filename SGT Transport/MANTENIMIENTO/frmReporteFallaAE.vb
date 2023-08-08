Imports System.IO
Imports System.Data.SqlClient

Public Class frmReporteFallaAE
    Dim RUTA_DOC As String
    Dim RUTA_IMAGEN As String

    Private Sub frmReporteFallaAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        F1.Value = Date.Today
        F1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.CustomFormat = "dd/MM/yyyy"
        F1.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        F1.EditFormat.CustomFormat = "dd/MM/yyyy"

        C1SuperTooltip1.SetToolTip(barGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(mnuSalir, "F5 - Salir")
        Me.CenterToScreen()
        Me.KeyPreview = True

        AssignValidation(tCVE_SUC, ValidationType.Only_Numbers)
        AssignValidation(tCVE_OPER, ValidationType.Only_Numbers)

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            SQL = "SELECT * FROM GCPARAMGENERALES"
            cmd.Connection = cnSAE
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            If dr.Read Then
                RUTA_DOC = dr("RUTA_DOC").ToString
                RUTA_IMAGEN = dr("RUTA_IMAGEN").ToString
            Else
                RUTA_DOC = ""
                RUTA_IMAGEN = ""
            End If
            dr.Close()

        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            Fg.Rows.Count = 1
            tCVE_FALLA.Text = ""
            tCVE_SUC.Text = ""
            F1.Value = Now
            tCVE_UNI.Text = ""
            tCVE_OPER.Text = ""
            tCVE_CLAS.Text = ""
            tDESCR_FALLA.Text = ""
            LtClas.Text = ""
            LtOper.Text = ""
            LtUnidad.Text = ""
            LtSuc.Text = ""
            tKMS.Value = 0
            Fg.Rows.Count = 1
            Fg2.Rows.Count = 1
            Fg3.Rows.Count = 1
            Fg4.Rows.Count = 1
        Catch ex As Exception
        End Try

        If Var1 = "Nuevo" Then
            Try
                tCVE_FALLA.Text = GET_MAX("GCREPORTE_FALLAS", "CVE_FALLA")
                tCVE_FALLA.Enabled = False
                tDESCR_FALLA.Text = ""
                tCVE_SUC.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE


                SQL = "SELECT R.CVE_FALLA, R.STATUS, R.CVE_SUC, R.FECHA, R.CVE_OPER, KMS, TIPO_VIAJE, ESTATUS 
                      FROM GCREPORTE_FALLAS R WHERE CVE_FALLA = '" & Var2 & "' AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_FALLA.Text = dr("CVE_FALLA")
                    tCVE_SUC.Text = dr("CVE_SUC")
                    If tCVE_SUC.Text = "0" Then
                        tCVE_SUC.Text = ""
                    End If
                    If tCVE_SUC.Text.Trim.Length > 0 Then
                        LtSuc.Text = BUSCA_CAT("Sucursal", tCVE_SUC.Text)
                    End If

                    If IsDate(dr("FECHA")) Then
                        F1.Value = dr("FECHA")
                    Else
                        F1.Value = Now
                    End If
                    tCVE_OPER.Text = dr("CVE_OPER")
                    If tCVE_OPER.Text = "0" Then
                        tCVE_OPER.Text = ""
                    End If
                    If tCVE_OPER.Text.Trim.Length > 0 Then
                        LtOper.Text = BUSCA_CAT("Operador", tCVE_OPER.Text)
                    End If

                    tKMS.Text = dr.ReadNullAsEmptyDecimal("KMS")

                    Try
                        If dr.ReadNullAsEmptyInteger("TIPO_VIAJE") = 0 Then
                            radCargado.Checked = True
                            radVacio.Checked = False
                        Else
                            radCargado.Checked = False
                            radVacio.Checked = True
                        End If
                        If dr.ReadNullAsEmptyString("ESTATUS").ToString.Trim.Length = 0 Then
                            LtEstatus.Text = "Captura"
                        Else
                            LtEstatus.Text = dr.ReadNullAsEmptyString("ESTATUS")
                        End If

                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                    End Try

                    DOC_FOTOS(tCVE_FALLA.Text)
                    CARGAR_FALLAS(tCVE_FALLA.Text)

                End If
                dr.Close()

                tCVE_FALLA.Enabled = False
                tCVE_SUC.Select()
            Catch ex As Exception
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub CARGAR_FALLAS(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT CVE_UNI, CVE_CLAS, DESCR_FALLA, ISNULL(FALLA,0) AS F1, ISNULL(NO_PARTIDA,0) AS NO_PAR 
                 FROM GCREPORTE_FALLAS_PAR 
                 WHERE CVE_FALLA = '" & fCLAVE & "' "
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Do While dr.Read
                Select Case dr("NO_PAR")
                    Case 1
                        tCVE_UNI.Text = dr("CVE_UNI")
                        LtUnidad.Text = BUSCA_CAT("Unidad", tCVE_UNI.Text)

                        tCVE_CLAS.Text = dr("CVE_CLAS")
                        tDESCR_FALLA.Text = dr("DESCR_FALLA")
                        LtClas.Text = BUSCA_CAT("Clasificacion", tCVE_CLAS.Text)
                        If dr("F1") = 1 Then
                            radFallaU.Checked = True
                            radFallaU2.Checked = False
                        Else
                            radFallaU.Checked = False
                            radFallaU2.Checked = True
                        End If
                    Case 2
                        tCVE_UNI2.Text = dr("CVE_UNI")
                        LtUnidad2.Text = BUSCA_CAT("Unidad", tCVE_UNI2.Text)

                        tCVE_CLAS2.Text = dr("CVE_CLAS")
                        tDESCR_FALLA2.Text = dr("DESCR_FALLA")
                        LtClas2.Text = BUSCA_CAT("Clasificacion", tCVE_CLAS2.Text)
                        If dr("F1") = 1 Then
                            radTanque1.Checked = True
                            radTanque12.Checked = False
                        Else
                            radTanque1.Checked = False
                            radTanque12.Checked = True
                        End If
                    Case 3
                        tCVE_UNI3.Text = dr("CVE_UNI")
                        LtUnidad3.Text = BUSCA_CAT("Unidad", tCVE_UNI3.Text)

                        tCVE_CLAS3.Text = dr("CVE_CLAS")
                        tDESCR_FALLA3.Text = dr("DESCR_FALLA")
                        LtClas3.Text = BUSCA_CAT("Clasificacion", tCVE_CLAS3.Text)
                        If dr("F1") = 1 Then
                            radTanque2.Checked = True
                            radTanque22.Checked = False
                        Else
                            radTanque2.Checked = False
                            radTanque22.Checked = True
                        End If
                    Case 4
                        tCVE_UNI4.Text = dr("CVE_UNI")
                        LtUnidad4.Text = BUSCA_CAT("Unidad", tCVE_UNI4.Text)

                        tCVE_CLAS4.Text = dr("CVE_CLAS")
                        tDESCR_FALLA4.Text = dr("DESCR_FALLA")
                        LtClas4.Text = BUSCA_CAT("Clasificacion", tCVE_CLAS4.Text)
                        If dr("F1") = 1 Then
                            radDolly.Checked = True
                            radDolly2.Checked = False
                        Else
                            radDolly.Checked = False
                            radDolly2.Checked = True
                        End If
                End Select
            Loop
            dr.Close()

        Catch ex As Exception
            Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DOC_FOTOS(fCLAVE As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'F' AND CVE_FOTDOC = 0"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg.Rows.Count = 1
            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & "")
            Loop
            dr.Close()

            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'F' AND CVE_FOTDOC = 1"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg2.Rows.Count = 1
            Do While dr.Read
                Fg2.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & "")
            Loop
            dr.Close()

            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'F' AND CVE_FOTDOC = 2"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg3.Rows.Count = 1
            Do While dr.Read
                Fg3.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & vbTab & "")
            Loop
            dr.Close()

            SQL = "SELECT CLAVE, ISNULL(CVE_FOTDOC,0) AS CVE_FOT, DESCR, DOCUMENTO, CVE_OBS " &
                 "FROM GCFOTDOC F " &
                 "WHERE CLAVE = '" & fCLAVE & "' AND TIPO_DOC = 'F' AND CVE_FOTDOC = 3"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader
            Fg4.Rows.Count = 1
            Do While dr.Read
                Fg4.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & "")
            Loop
            dr.Close()

        Catch Ex As Exception
            Bitacora("15. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("15. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub frmReporteFallaAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub

    Private Sub frmReporteFallaAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim DESCR As String, KMS As Decimal

        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR = "" Then
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    LtUnidad.Text = ""
                    tCVE_UNI.Select()
                    Return
                End If
            End If
            If tCVE_UNI2.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI2.Text)
                If DESCR = "" Then
                    MsgBox("Unidad inexistente")
                    tCVE_UNI2.Text = ""
                    LtUnidad2.Text = ""
                    tCVE_UNI2.Select()
                    Return
                End If
            End If
            If tCVE_UNI3.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI3.Text)
                If DESCR = "" Then
                    MsgBox("Unidad inexistente")
                    tCVE_UNI3.Text = ""
                    LtUnidad3.Text = ""
                    tCVE_UNI3.Select()
                    Return
                End If
            End If
            If tCVE_UNI4.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI4.Text)
                If DESCR = "" Then
                    MsgBox("Unidad inexistente")
                    tCVE_UNI4.Text = ""
                    LtUnidad4.Text = ""
                    tCVE_UNI4.Select()
                    Return 
                End If
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

        Try
            If tCVE_OPER.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR = "" Then
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                    LtOper.Text = ""
                    tCVE_OPER.Select()
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("126. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try
            If tCVE_SUC.Text.Trim.Length > 0 Then
                DESCR = BUSCA_CAT("Sucursal", tCVE_SUC.Text)
                If DESCR = "" Then
                    MsgBox("Sucursal inexistente")
                    tCVE_SUC.Text = ""
                    LtSuc.Text = ""
                    tCVE_SUC.Select()
                    Return
                End If
            End If
        Catch ex As Exception
            Bitacora("126. " & ex.Message & vbNewLine & ex.StackTrace)
            'MsgBox("126. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
        Try

            If IsNumeric(tKMS.Text) Then
                KMS = CDec(tKMS.Text)
            Else
                KMS = 0
            End If
        Catch ex As Exception
            KMS = 0
        End Try

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        SQL = "UPDATE GCREPORTE_FALLAS SET CVE_SUC = @CVE_SUC, FECHA = @FECHA, CVE_OPER = @CVE_OPER, KMS = @KMS, TIPO_VIAJE = @TIPO_VIAJE " &
            "WHERE CVE_FALLA = @CVE_FALLA " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCREPORTE_FALLAS (CVE_FALLA, STATUS, CVE_SUC, FECHA, CVE_OPER, KMS, TIPO_VIAJE, FECHAELAB, GUID) VALUES(@CVE_FALLA, 'A', " &
            "@CVE_SUC, @FECHA, @CVE_OPER, @KMS, @TIPO_VIAJE, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = tCVE_FALLA.Text
            cmd.Parameters.Add("@CVE_SUC", SqlDbType.VarChar).Value = CONVERTIR_TO_LONG(tCVE_SUC.Text)
            cmd.Parameters.Add("@FECHA", SqlDbType.Date).Value = F1.Value
            cmd.Parameters.Add("@CVE_OPER", SqlDbType.Int).Value = CONVERTIR_TO_LONG(tCVE_OPER.Text)
            cmd.Parameters.Add("@KMS", SqlDbType.Float).Value = KMS
            cmd.Parameters.Add("@TIPO_VIAJE", SqlDbType.Float).Value = IIf(radCargado.Checked, 0, 1)
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABA_FOTOS_DOC()
                    GRABAR_FALLAS_X_UNIDAD()
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
                Else
                    MsgBox("No se logro grabar el registro")
                End If
            Else
                MsgBox("No se logro grabar el registro")
            End If
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub GRABAR_FALLAS_X_UNIDAD()
        Dim Sigue As Boolean

        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        For k = 1 To 4
            SQL = "UPDATE GCREPORTE_FALLAS_PAR SET CVE_UNI = @CVE_UNI, CVE_CLAS = @CVE_CLAS, DESCR_FALLA = @DESCR_FALLA, " &
                "FALLA = @FALLA " &
                "WHERE CVE_FALLA = @CVE_FALLA AND NO_PARTIDA = @NO_PARTIDA " &
                "IF @@ROWCOUNT = 0 " &
                "INSERT INTO GCREPORTE_FALLAS_PAR (CVE_FALLA, CVE_UNI, CVE_CLAS, DESCR_FALLA, FALLA, NO_PARTIDA, CVE_ORD, UUID) " &
                "VALUES(@CVE_FALLA, @CVE_UNI, @CVE_CLAS, @DESCR_FALLA, @FALLA, @NO_PARTIDA, '', NEWID())"
            cmd.CommandText = SQL
            Try
                Select Case k
                    Case 1
                        'If tCVE_UNI.Text.Trim.Length > 0 Then
                        Sigue = True
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = tCVE_FALLA.Text

                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text
                            cmd.Parameters.Add("@CVE_CLAS", SqlDbType.VarChar).Value = tCVE_CLAS.Text
                            cmd.Parameters.Add("@DESCR_FALLA", SqlDbType.VarChar).Value = tDESCR_FALLA.Text
                            cmd.Parameters.Add("@FALLA", SqlDbType.SmallInt).Value = IIf(radFallaU.Checked, 1, 0)
                            cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.SmallInt).Value = k
                        'Else
                        'Sigue = False
                        'End If
                    Case 2
                        'If tCVE_UNI2.Text.Trim.Length > 0 Then
                        Sigue = True
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = tCVE_FALLA.Text

                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI2.Text
                            cmd.Parameters.Add("@CVE_CLAS", SqlDbType.VarChar).Value = tCVE_CLAS2.Text
                            cmd.Parameters.Add("@DESCR_FALLA", SqlDbType.VarChar).Value = tDESCR_FALLA2.Text
                            cmd.Parameters.Add("@FALLA", SqlDbType.SmallInt).Value = IIf(radTanque1.Checked, 1, 0)
                            cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.SmallInt).Value = k
                        'Else
                        'Sigue = False
                        'End If
                    Case 3
                        'If tCVE_UNI3.Text.Trim.Length > 0 Then
                        Sigue = True
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = tCVE_FALLA.Text

                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI3.Text
                            cmd.Parameters.Add("@CVE_CLAS", SqlDbType.VarChar).Value = tCVE_CLAS3.Text
                            cmd.Parameters.Add("@DESCR_FALLA", SqlDbType.VarChar).Value = tDESCR_FALLA3.Text
                            cmd.Parameters.Add("@FALLA", SqlDbType.SmallInt).Value = IIf(radTanque2.Checked, 1, 0)
                            cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.SmallInt).Value = k
                        'Else
                        'Sigue = False
                        'End If
                    Case 4
                        'If tCVE_UNI4.Text.Trim.Length > 0 Then
                        Sigue = True
                            cmd.Parameters.Clear()
                            cmd.Parameters.Add("@CVE_FALLA", SqlDbType.VarChar).Value = tCVE_FALLA.Text

                            cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI4.Text
                            cmd.Parameters.Add("@CVE_CLAS", SqlDbType.VarChar).Value = tCVE_CLAS4.Text
                            cmd.Parameters.Add("@DESCR_FALLA", SqlDbType.VarChar).Value = tDESCR_FALLA4.Text
                            cmd.Parameters.Add("@FALLA", SqlDbType.SmallInt).Value = IIf(radDolly.Checked, 1, 0)
                            cmd.Parameters.Add("@NO_PARTIDA", SqlDbType.SmallInt).Value = k
                        'Else
                        'Sigue = False
                        'End If
                End Select
                If Sigue Then
                    returnValue = cmd.ExecuteNonQuery().ToString
                    If returnValue IsNot Nothing Then
                        If returnValue = "1" Then
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Sub GRABA_FOTOS_DOC()

        Dim DESCR As String
        Dim DOC As String
        Dim Ruta As String

        Dim cmd As New SqlCommand

        cmd.Connection = cnSAE
        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_FALLA.Text & "' AND TIPO_DOC = 'F' AND ISNULL(CVE_FOTDOC,0) = 0"
            cmd.CommandText = SQL
            returnValue = cmd.ExecuteNonQuery().ToString
        Catch ex As Exception
        End Try 'fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))
        For k = 1 To Fg.Rows.Count - 1
            Try
                DESCR = Fg(k, 1)
                DOC = Fg(k, 2).ToString
                Ruta = Fg(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_FALLA.Text & "','0','" & DESCR & "','" & DOC & "','F')"

                cmd.CommandText = SQL

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If Ruta.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(DOC)
                            Dim newPath = Path.Combine(Ruta, DOC)
                            File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_FALLA.Text & "' AND TIPO_DOC = 'F' AND ISNULL(CVE_FOTDOC,0) = 1"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try 'fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))

        For k = 1 To Fg2.Rows.Count - 1
            Try
                DESCR = Fg2(k, 1)
                DOC = Fg2(k, 2).ToString
                Ruta = Fg2(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_FALLA.Text & "','1','" & DESCR & "','" & DOC & "','F')"

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If Ruta.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(DOC)
                            Dim newPath = Path.Combine(Ruta, DOC)
                            File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_FALLA.Text & "' AND TIPO_DOC = 'F' AND ISNULL(CVE_FOTDOC,0) = 2"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try 'fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))
        For k = 1 To Fg3.Rows.Count - 1
            Try
                DESCR = Fg3(k, 1)
                DOC = Fg3(k, 2).ToString
                Ruta = Fg3(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_FALLA.Text & "','2','" & DESCR & "','" & DOC & "','F')"

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If Ruta.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(DOC)
                            Dim newPath = Path.Combine(Ruta, DOC)
                            File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next

        Try
            SQL = "DELETE FROM GCFOTDOC WHERE CLAVE = '" & tCVE_FALLA.Text & "' AND TIPO_DOC = 'F' AND ISNULL(CVE_FOTDOC,0) = 3"
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try 'fg.AddItem("" & vbTab & dr("DESCR") & vbTab & dr("DOCUMENTO") & vbTab & dr("CVE_FOT"))
        For k = 1 To Fg4.Rows.Count - 1
            Try
                DESCR = Fg4(k, 1)
                DOC = Fg4(k, 2).ToString
                Ruta = Fg4(k, 3).ToString

                SQL = "INSERT INTO GCFOTDOC (CLAVE, CVE_FOTDOC, DESCR, DOCUMENTO, TIPO_DOC) VALUES ('" & tCVE_FALLA.Text & "','3','" & DESCR & "','" & DOC & "','F')"

                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        If Ruta.Trim.Length > 0 Then
                            Dim copyToDir = Path.GetDirectoryName(DOC)
                            Dim newPath = Path.Combine(Ruta, DOC)
                            File.Copy(newPath, RUTA_DOC & "\" & DOC, True)
                        End If
                    End If
                End If
            Catch ex As Exception
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Next
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        'OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Todos los archivos|*.*"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Do things here, the path is stored in openFileDialog1.Filename
            'If no files were selected, openFileDialog1.Filename is ""  
            Dim ruta As String
            ruta = Path.GetDirectoryName(OpenFileDialog1.FileName)
            LtFotoDoc.Text = Path.GetFileName(OpenFileDialog1.FileName)
            LtFotoDoc.Tag = ruta
        End If

    End Sub

    Private Sub btnFotDocA_Click(sender As Object, e As EventArgs) Handles btnFotDocA.Click
        Try

            If tDescrFotDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor la descripcion del documento")
                Fg.Focus()
                Return
            End If
            If LtFotoDoc.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            Fg.AddItem("" & vbTab & tDescrFotDoc.Text & vbTab & LtFotoDoc.Text & vbTab & LtFotoDoc.Tag & vbTab & "1")

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub

    Private Sub btnFotDocE_Click(sender As Object, e As EventArgs) Handles btnFotDocE.Click
        Try

            If Fg.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    Fg.RemoveItem(Fg.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSuc_Click(sender As Object, e As EventArgs) Handles btnSuc.Click
        Try

            Var2 = "Sucursal"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_SUC.Text = Var4
                LtSuc.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_UNI.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnUni_Click(sender As Object, e As EventArgs) Handles btnUni.Click
        Try

            Var2 = "Unidades2"
            Var4 = "1"
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI.Text = Var5
                tCVE_UNI.Tag = Var4
                LtUnidad.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_OPER.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnOper_Click(sender As Object, e As EventArgs) Handles btnOper.Click
        Try
            Var2 = "Operador"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_OPER.Text = Var4
                LtOper.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_CLAS.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClas_Click(sender As Object, e As EventArgs) Handles btnClas.Click
        Try

            Var2 = "Clasificacion"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CLAS.Text = Var4
                LtClas.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tDESCR_FALLA.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_SUC_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_SUC.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnSuc_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUni_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_OPER_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_OPER.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnOper_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_CLAS_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_CLAS.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClas_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Fg_DoubleClick(sender As Object, e As EventArgs) Handles Fg.DoubleClick
        Try
            If Fg.Row > 0 Then
                Dim Ruta As String

                If Fg(Fg.Row, 3).ToString.Trim.Length > 0 Then
                    Ruta = Fg(Fg.Row, 3) & "\" & Fg(Fg.Row, 2)
                Else
                    Ruta = RUTA_DOC & "\" & Fg(Fg.Row, 2)
                End If

                If File.Exists(Ruta) Then
                    Process.Start(Ruta)
                End If
            End If
        Catch ex As Exception
            Bitacora("14. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("14. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmReporteFallaAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Try
            CloseTab("Captura Fallas")
            Me.Dispose()

            If FORM_IS_OPEN("frmReporteFalla") Then
                frmReporteFalla.DESPLEGAR()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnUni2_Click(sender As Object, e As EventArgs) Handles btnUni2.Click
        Try

            Var2 = "Unidades"
            Var4 = "2"
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI2.Text = Var5
                tCVE_UNI2.Tag = Var4
                LtUnidad2.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_CLAS2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnUni3_Click(sender As Object, e As EventArgs) Handles btnUni3.Click
        Try

            Var2 = "Unidades"
            Var4 = "2"
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI3.Text = Var5
                tCVE_UNI3.Tag = Var4
                LtUnidad3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_CLAS3.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnUni4_Click(sender As Object, e As EventArgs) Handles btnUni4.Click
        Try
            Var2 = "Unidades"
            Var4 = "3"
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_UNI4.Text = Var5
                tCVE_UNI4.Tag = Var4
                LtUnidad4.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tCVE_CLAS4.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClas2_Click(sender As Object, e As EventArgs) Handles btnClas2.Click
        Try
            Var2 = "Clasificacion"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CLAS2.Text = Var4
                LtClas2.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tDESCR_FALLA2.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClas3_Click(sender As Object, e As EventArgs) Handles btnClas3.Click
        Try

            Var2 = "Clasificacion"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CLAS3.Text = Var4
                LtClas3.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tDESCR_FALLA3.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnClas4_Click(sender As Object, e As EventArgs) Handles btnClas4.Click
        Try

            Var2 = "Clasificacion"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCVE_CLAS4.Text = Var4
                LtClas4.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                tDESCR_FALLA4.Focus()
            End If
        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDoc2_Click(sender As Object, e As EventArgs) Handles btnDoc2.Click
        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        'OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Todos los archivos|*.*"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Do things here, the path is stored in openFileDialog1.Filename
            'If no files were selected, openFileDialog1.Filename is ""  
            Dim ruta As String
            ruta = Path.GetDirectoryName(OpenFileDialog1.FileName)
            LtFotoDoc2.Text = Path.GetFileName(OpenFileDialog1.FileName)
            LtFotoDoc2.Tag = ruta
        End If
    End Sub

    Private Sub btnDoc3_Click(sender As Object, e As EventArgs) Handles btnDoc3.Click
        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        'OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Todos los archivos|*.*"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Do things here, the path is stored in openFileDialog1.Filename
            'If no files were selected, openFileDialog1.Filename is ""  
            Dim ruta As String
            ruta = Path.GetDirectoryName(OpenFileDialog1.FileName)
            LtFotoDoc3.Text = Path.GetFileName(OpenFileDialog1.FileName)
            LtFotoDoc3.Tag = ruta
        End If
    End Sub

    Private Sub btnDoc4_Click(sender As Object, e As EventArgs) Handles btnDoc4.Click
        OpenFileDialog1.Title = "Por favor seleccione un archivo"
        'OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Todos los archivos|*.*"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'Do things here, the path is stored in openFileDialog1.Filename
            'If no files were selected, openFileDialog1.Filename is ""  
            Dim ruta As String
            ruta = Path.GetDirectoryName(OpenFileDialog1.FileName)
            LtFotoDoc4.Text = Path.GetFileName(OpenFileDialog1.FileName)
            LtFotoDoc4.Tag = ruta
        End If
    End Sub

    Private Sub btnFotDocA2_Click(sender As Object, e As EventArgs) Handles btnFotDocA2.Click
        Try

            If tDescrFotDoc2.Text.Trim.Length = 0 Then
                MsgBox("Por favor la descripcion del documento")
                Fg.Focus()
                Return
            End If
            If LtFotoDoc2.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            Fg2.AddItem("" & vbTab & tDescrFotDoc2.Text & vbTab & LtFotoDoc2.Text & vbTab & LtFotoDoc2.Tag)

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocA3_Click(sender As Object, e As EventArgs) Handles btnFotDocA3.Click
        Try

            If tDescrFotDoc3.Text.Trim.Length = 0 Then
                MsgBox("Por favor la descripcion del documento")
                Fg.Focus()
                Return
            End If
            If LtFotoDoc3.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            Fg3.AddItem("" & vbTab & tDescrFotDoc3.Text & vbTab & LtFotoDoc3.Text & vbTab & LtFotoDoc3.Tag)

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocA4_Click(sender As Object, e As EventArgs) Handles btnFotDocA4.Click
        Try

            If tDescrFotDoc4.Text.Trim.Length = 0 Then
                MsgBox("Por favor la descripcion del documento")
                Fg.Focus()
                Return
            End If
            If LtFotoDoc4.Text.Trim.Length = 0 Then
                MsgBox("Por favor seleccione un documento")
                Return
            End If

            Fg4.AddItem("" & vbTab & tDescrFotDoc4.Text & vbTab & LtFotoDoc4.Text & vbTab & LtFotoDoc4.Tag)

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub btnFotDocE2_Click(sender As Object, e As EventArgs) Handles btnFotDocE2.Click
        Try
            If Fg2.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    Fg2.RemoveItem(Fg.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocE3_Click(sender As Object, e As EventArgs) Handles btnFotDocE3.Click
        Try

            If Fg3.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    Fg3.RemoveItem(Fg.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnFotDocE4_Click(sender As Object, e As EventArgs) Handles btnFotDocE4.Click
        Try

            If Fg4.Row > 0 Then
                If MsgBox("Realmente desea eliminar el foto/documento seleccionado?", vbYesNo) = vbYes Then
                    Fg4.RemoveItem(Fg.Row)
                End If
            End If

        Catch Ex As Exception
            Bitacora("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("10. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_UNI_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI.Validated
        Try
            If tCVE_UNI.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI.Text)
                If DESCR <> "" Then
                    LtUnidad.Text = DESCR
                    tCVE_UNI.Tag = Var4
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI.Text = ""
                    LtUnidad.Text = ""
                    tCVE_UNI.Select()
                End If
            Else
                LtUnidad.Text = ""
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_UNI2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI2.KeyDown

        If e.KeyCode = Keys.F2 Then
            btnUni2_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub tCVE_UNI3_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI3.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUni3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_UNI4_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_UNI4.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnUni4_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_UNI2_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI2.Validated
        Try
            If tCVE_UNI2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI2.Text)
                If DESCR <> "" Then
                    LtUnidad2.Text = DESCR
                    tCVE_UNI2.Tag = Var4
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI2.Text = ""
                    LtUnidad2.Text = ""
                    tCVE_UNI2.Select()
                End If
            Else
                LtUnidad2.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_UNI3_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI3.Validated
        Try
            If tCVE_UNI3.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI3.Text)
                If DESCR <> "" Then
                    LtUnidad3.Text = DESCR
                    tCVE_UNI3.Tag = Var4
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI3.Text = ""
                    LtUnidad3.Text = ""
                    tCVE_UNI3.Select()
                End If
            Else
                LtUnidad3.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_UNI4_Validated(sender As Object, e As EventArgs) Handles tCVE_UNI4.Validated
        Try
            If tCVE_UNI4.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Unidad", tCVE_UNI4.Text)
                If DESCR <> "" Then
                    LtUnidad4.Text = DESCR
                    tCVE_UNI4.Tag = Var4
                Else
                    MsgBox("Unidad inexistente")
                    tCVE_UNI4.Text = ""
                    LtUnidad4.Text = ""
                    tCVE_UNI4.Select()
                End If
            Else
                LtUnidad4.Text = ""
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub tCVE_CLAS_Validated(sender As Object, e As EventArgs) Handles tCVE_CLAS.Validated
        Try
            If tCVE_CLAS.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Clasificacion", tCVE_CLAS.Text)
                If DESCR <> "" Then
                    LtClas.Text = DESCR
                Else
                    MsgBox("Clasificación inexistente")
                    tCVE_CLAS.Text = ""
                    LtClas.Text = ""
                    tCVE_CLAS.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try

    End Sub

    Private Sub tCVE_CLAS2_Validated(sender As Object, e As EventArgs) Handles tCVE_CLAS2.Validated
        Try
            If tCVE_CLAS2.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Clasificacion", tCVE_CLAS2.Text)
                If DESCR <> "" Then
                    LtClas2.Text = DESCR
                Else
                    MsgBox("Clasificación inexistente")
                    tCVE_CLAS2.Text = ""
                    LtClas2.Text = ""
                    tCVE_CLAS2.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_CLAS3_Validated(sender As Object, e As EventArgs) Handles tCVE_CLAS3.Validated
        Try
            If tCVE_CLAS3.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Clasificacion", tCVE_CLAS3.Text)
                If DESCR <> "" Then
                    LtClas3.Text = DESCR
                Else
                    MsgBox("Clasificación inexistente")
                    tCVE_CLAS3.Text = ""
                    LtClas3.Text = ""
                    tCVE_CLAS3.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_CLAS4_Validated(sender As Object, e As EventArgs) Handles tCVE_CLAS4.Validated
        Try
            If tCVE_CLAS4.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Clasificacion", tCVE_CLAS4.Text)
                If DESCR <> "" Then
                    LtClas4.Text = DESCR
                Else
                    MsgBox("Clasificación inexistente")
                    tCVE_CLAS4.Text = ""
                    LtClas4.Text = ""
                    tCVE_CLAS4.Select()
                End If
            End If

        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_CLAS2_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_CLAS2.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClas2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_CLAS3_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_CLAS3.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClas3_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub tCVE_CLAS4_KeyDown(sender As Object, e As KeyEventArgs) Handles tCVE_CLAS4.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnClas4_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tDESCR_FALLA_KeyDown(sender As Object, e As KeyEventArgs) Handles tDESCR_FALLA.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tDESCR_FALLA2_KeyDown(sender As Object, e As KeyEventArgs) Handles tDESCR_FALLA2.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tDESCR_FALLA3_KeyDown(sender As Object, e As KeyEventArgs) Handles tDESCR_FALLA3.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tDESCR_FALLA4_KeyDown(sender As Object, e As KeyEventArgs) Handles tDESCR_FALLA4.KeyDown
        Try
            If e.KeyCode = 13 Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BarImprimir_Click(sender As Object, e As EventArgs) Handles BarImprimir.Click
        Imprimir(tCVE_FALLA.Text)
    End Sub

    Private Sub Imprimir(fCVE_FALLA As String)
        Dim Rreporte_MRT As String = ""
        Dim RUTA_FORMATOS As String
        RUTA_FORMATOS = GET_RUTA_FORMATOS()
        Try
            Rreporte_MRT = "ReportReporteFallas.mrt"
            If Not File.Exists(RUTA_FORMATOS & "\" & Rreporte_MRT) Then
                MsgBox("No existe el reporte " & RUTA_FORMATOS & "\" & Rreporte_MRT & ", verifique por favor")
                Return
            End If
            StiReport1.Load(RUTA_FORMATOS & "\" & Rreporte_MRT)
            Dim ConexString As String = "Provider=SQLOLEDB.1;Password=" & Pass & ";Persist Security Info=True;User ID=" &
                    Usuario & ";Initial Catalog=" & Base & ";Data Source=" & Servidor

            StiReport1.Dictionary.Databases.Clear()
            StiReport1.Dictionary.Databases.Add(New Stimulsoft.Report.Dictionary.StiOleDbDatabase("PREREP", ConexString))

            StiReport1.Compile()
            StiReport1.Dictionary.Synchronize()

            StiReport1.Item("CVE_FALL") = fCVE_FALLA
            StiReport1.Item("CVE_FALLA2") = fCVE_FALLA

            StiReport1.Render()

            StiReport1.Show()

        Catch ex As Exception
            Bitacora("400. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("400. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarEstatus_Click(sender As Object, e As EventArgs) Handles BarEstatus.Click
        If MsgBox("Realmente desea enviar a proceso el reporte de fallas?", vbYesNo) = vbYes Then
            Try
                Dim cmd As New SqlCommand
                cmd.Connection = cnSAE
                SQL = "UPDATE GCREPORTE_FALLAS SET ESTATUS = 'EN PROCESO' WHERE CVE_FALLA = '" & tCVE_FALLA.Text & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        MsgBox("El cambio de estatus se realizo satisfactoriamente")
                    End If
                End If
            Catch ex As Exception
                Bitacora("410. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("410. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Private Sub tCVE_OPER_Validated(sender As Object, e As EventArgs) Handles tCVE_OPER.Validated
        Try
            If tCVE_OPER.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Operador", tCVE_OPER.Text)
                If DESCR <> "" Then
                    LtOper.Text = DESCR
                Else
                    MsgBox("Operador inexistente")
                    tCVE_OPER.Text = ""
                    LtOper.Text = ""
                    tCVE_OPER.Select()
                End If
            Else
                LtOper.Text = ""
            End If

        Catch ex As Exception
            Bitacora("126. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("126. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub tCVE_SUC_Validated(sender As Object, e As EventArgs) Handles tCVE_SUC.Validated
        Try
            If tCVE_SUC.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Sucursal", tCVE_SUC.Text)
                If DESCR = "" Then
                    MsgBox("Operador inexistente")
                    tCVE_SUC.Text = ""
                    LtSuc.Text = ""
                    tCVE_SUC.Select()
                End If
            Else
                LtSuc.Text = ""
            End If

        Catch ex As Exception
            Bitacora("126. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("126. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
End Class
