Imports System.Data.SqlClient
Public Class frmSueldoOperadoresAE
    Private NewRuta As Boolean = False
    Private Sub frmSueldoOperadoresAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Me.CenterToScreen()
        Me.KeyPreview = True
        tSUELDO.Value = 0
        TSUELDO_SENC.Value = 0
        tPLAZA_O.Tag = ""
        LtPlaza.Tag = ""

        TCVE_TAB.Tag = ""
        tCLAVE_O.Tag = ""
        tPLAZA_O.Tag = ""
        tPLAZA_D.Tag = ""
        tSUELDO.Tag = 0
        TSUELDO_SENC.Tag = 0
        TOBSER.Tag = ""

        If Var1 = "Nuevo" Then
            Try
                NewRuta = True

                tCVE_SUOP.Text = GET_MAX("GCSUELDO_OPER", "CVE_SUOP")
                tCVE_SUOP.Enabled = False
                tSUELDO.Value = 0
                tCLAVE_O.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT S.CVE_SUOP, S.SUELDO, S.SUELDO_SENC, S.CLAVE_O, ISNULL(C.NOMBRE,'') AS ORIGEN, S.PLAZA_O, ISNULL(P1.CIUDAD,'') AS PLAZA1, 
                    S.PLAZA_D, ISNULL(P2.CIUDAD,'') AS PLAZA2, S.TIPO_FULL_SENCILLO, S.TIPO_CARGADO_VACIO, ISNULL(OBSER,'') AS STR_OBS, 
                    ISNULL(P1.STATUS,'A') AS ST_PLAZA, ISNULL(P2.STATUS,'A') AS ST_PLAZA2
                    FROM GCSUELDO_OPER S 
                    LEFT JOIN GCCLIE_OP C ON C.CLAVE = S.CLAVE_O
                    LEFT JOIN GCPLAZAS P1 ON P1.CLAVE = S.PLAZA_O
                    LEFT JOIN GCPLAZAS P2 ON P2.CLAVE = S.PLAZA_D
                    WHERE CVE_SUOP = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    tCVE_SUOP.Text = dr("CVE_SUOP").ToString
                    tSUELDO.Value = dr.ReadNullAsEmptyDecimal("SUELDO")
                    TSUELDO_SENC.Value = dr.ReadNullAsEmptyDecimal("SUELDO_SENC")
                    tCLAVE_O.Text = dr.ReadNullAsEmptyString("CLAVE_O").ToString
                    LtOrigen.Text = dr.ReadNullAsEmptyString("ORIGEN")


                    tPLAZA_O.Text = dr.ReadNullAsEmptyInteger("PLAZA_O")
                    tPLAZA_O.Tag = dr.ReadNullAsEmptyString("ST_PLAZA")
                    LtPlaza.Text = dr.ReadNullAsEmptyString("PLAZA1")
                    LtPlaza.Tag = tPLAZA_O.Text

                    tPLAZA_D.Text = dr.ReadNullAsEmptyInteger("PLAZA_D")
                    tPLAZA_D.Tag = dr.ReadNullAsEmptyString("ST_PLAZA2")
                    LtPlaza2.Text = dr.ReadNullAsEmptyString("PLAZA2")
                    LtPlaza2.Tag = tPLAZA_D.Text

                    If dr("TIPO_FULL_SENCILLO") = 0 Then
                        RadFull.Checked = True
                        RadSencillo.Checked = False
                    Else
                        RadFull.Checked = False
                        RadSencillo.Checked = True
                    End If
                    If dr("TIPO_CARGADO_VACIO") = 0 Then
                        RadCargado.Checked = True
                        RadVacio.Checked = False
                    Else
                        RadCargado.Checked = False
                        RadVacio.Checked = True
                    End If
                    TOBSER.Text = dr("STR_OBS")

                    Try
                        TCVE_TAB.Tag = TCVE_TAB.Text
                        tCLAVE_O.Tag = tCLAVE_O.Text
                        tPLAZA_O.Tag = tPLAZA_O.Text
                        tPLAZA_D.Tag = tPLAZA_D.Text
                        tSUELDO.Tag = tSUELDO.Value
                        TSUELDO_SENC.Tag = TSUELDO_SENC.Value
                        TOBSER.Tag = TOBSER.Text
                    Catch ex As Exception
                        Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                    End Try
                Else
                    tSUELDO.Value = 0
                    tCLAVE_O.Text = ""

                    RadFull.Checked = False
                    RadSencillo.Checked = False
                    RadCargado.Checked = False
                    RadVacio.Checked = False
                End If
                dr.Close()

                tCVE_SUOP.Enabled = False
                tCLAVE_O.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub frmSueldoOperadoresAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try
            tSUELDO.UpdateValueWithCurrentText()
            TSUELDO_SENC.UpdateValueWithCurrentText()
            TOBSER.Focus()
        Catch ex As Exception
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        'If tSUELDO.Value = "0" Then
        'MsgBox("Por favor capture el sueldo full")
        'Return
        'End If
        'If TSUELDO_SENC.Value = "0" Then
        'MsgBox("Por favor capture el sueldo sencillo")
        'Return
        'End If

        SQL = "UPDATE GCSUELDO_OPER SET CLAVE_O = @CLAVE_O, CVE_TAB = @CVE_TAB, PLAZA_O = @PLAZA_O, PLAZA_D = @PLAZA_D, TIPO_FULL_SENCILLO = @TIPO_FULL_SENCILLO, 
            TIPO_CARGADO_VACIO = @TIPO_CARGADO_VACIO, SUELDO = @SUELDO, SUELDO_SENC = @SUELDO_SENC, OBSER = @OBSER
            WHERE CVE_SUOP = @CVE_SUOP
            IF @@ROWCOUNT = 0 
            INSERT INTO GCSUELDO_OPER (CVE_SUOP, CVE_TAB, STATUS, SUELDO, SUELDO_SENC, CLAVE_O, PLAZA_O, PLAZA_D, TIPO_FULL_SENCILLO, TIPO_CARGADO_VACIO, OBSER, FECHAELAB, UUID)
            VALUES(@CVE_SUOP, @CVE_TAB, 'A', @SUELDO, @SUELDO_SENC, @CLAVE_O, @PLAZA_O, @PLAZA_D, @TIPO_FULL_SENCILLO, @TIPO_CARGADO_VACIO, @OBSER, GETDATE(), NEWID())"
        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_SUOP", SqlDbType.Int).Value = CONVERTIR_TO_INT(tCVE_SUOP.Text)
            cmd.Parameters.Add("@CVE_TAB", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_TAB.Text)
            cmd.Parameters.Add("@SUELDO", SqlDbType.Float).Value = tSUELDO.Value
            cmd.Parameters.Add("@SUELDO_SENC", SqlDbType.Float).Value = TSUELDO_SENC.Value
            cmd.Parameters.Add("@CLAVE_O", SqlDbType.VarChar).Value = tCLAVE_O.Text
            cmd.Parameters.Add("@PLAZA_O", SqlDbType.VarChar).Value = tPLAZA_O.Text
            cmd.Parameters.Add("@PLAZA_D", SqlDbType.VarChar).Value = tPLAZA_D.Text
            cmd.Parameters.Add("@TIPO_FULL_SENCILLO", SqlDbType.SmallInt).Value = IIf(RadFull.Checked, 0, 1)
            cmd.Parameters.Add("@TIPO_CARGADO_VACIO", SqlDbType.SmallInt).Value = IIf(RadCargado.Checked, 0, 1)
            cmd.Parameters.Add("@OBSER", SqlDbType.VarChar).Value = TOBSER.Text
            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then

                    If Not NewRuta Then
                        Try
                            If TCVE_TAB.Tag <> TCVE_TAB.Text Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio tabulador de rutas " & TCVE_TAB.Tag & " por " & TCVE_TAB.Text, TCVE_TAB.Text)
                            If tCLAVE_O.Tag <> tCLAVE_O.Text Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio cliente " & tCLAVE_O.Tag & " por " & tCLAVE_O.Text, TCVE_TAB.Text)
                            If tPLAZA_O.Tag <> tPLAZA_O.Text Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio plaz origen " & tPLAZA_O.Tag & " por " & tPLAZA_O.Text, TCVE_TAB.Text)
                            If tPLAZA_D.Tag <> tPLAZA_D.Text Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio plaza destino " & tPLAZA_D.Tag & " por " & tPLAZA_D.Text, TCVE_TAB.Text)
                            If tSUELDO.Tag <> tSUELDO.Value Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio sueldo full " & tSUELDO.Tag & " por " & tSUELDO.Text, TCVE_TAB.Text)
                            If TSUELDO_SENC.Tag <> TSUELDO_SENC.Value Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio sueldo sencillo " & TSUELDO_SENC.Tag & " por " & TSUELDO_SENC.Text, TCVE_TAB.Text)
                            If TOBSER.Tag <> TOBSER.Text Then GRABA_BITA(tCVE_SUOP.Text, tCVE_SUOP.Text, 0, "A",
                               "Se Cambio observaciones " & TOBSER.Tag & " por " & TOBSER.Text, TCVE_TAB.Text)
                        Catch ex As Exception
                            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                        End Try
                    End If
                    MsgBox("El registro se grabo satisfactoriamente")
                    Me.Close()
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
    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnOrigen_Click(sender As Object, e As EventArgs) Handles btnOrigen.Click
        Try
            Var2 = "Cliente operativo" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tCLAVE_O.Text = Var4
                LtOrigen.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tPLAZA_O.Select()
            Else
                LtOrigen.Text = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLAVE_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tCLAVE_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnOrigen_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TCLAVE_O_Validated(sender As Object, e As EventArgs) Handles tCLAVE_O.Validated
        Try
            If tCLAVE_O.Text.Trim.Length > 0 Then
                DESPLEGAR_CLIENTE_OPER(tCLAVE_O.Text)
                tPLAZA_O.Select()
            Else
                LtOrigen.Text = ""
            End If
        Catch ex As Exception
            Bitacora("162. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("162. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Sub DESPLEGAR_CLIENTE_OPER(fCVE_OPER As String)
        Try

            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT * FROM GCCLIE_OP WHERE CLAVE = '" & fCVE_OPER & "'"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        tCLAVE_O.Text = dr("CLAVE").ToString
                        LtOrigen.Text = dr("NOMBRE").ToString
                        'LtPlaza.Text = dr("CVE_PLAZA").ToString
                        'CVE_PLAZA.Text = dr("CVE_PLAZA").ToString
                        'LtDom.Text = dr("DOMICILIO").ToString
                        'LtDomi.Text = dr("DOMICILIO2").ToString
                        'LtPlanta.Text = dr("PLANTA").ToString
                        'LtNota.Text = dr("NOTA").ToString
                        'LtRFC.Text = dr("RFC").ToString
                    Else
                        tCLAVE_O.Text = ""
                        'LtNombre1.Text = ""
                        LtOrigen.Text = ""
                        'LtPlaza.Text = ""
                        'LtDom.Text = ""
                        'LtDomi.Text = ""
                        'LtPlanta.Text = ""
                        'LtNota.Text = ""
                        'LtRFC.Text = ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("160. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("160. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnPlazaD_Click(sender As Object, e As EventArgs) Handles BtnPlazaD.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tPLAZA_D.Text = Var4
                LtPlaza2.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tSUELDO.Select()
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TPLAZA_O_KeyDown(sender As Object, e As KeyEventArgs) Handles tPLAZA_O.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlazaO_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TPLAZA_O_Validated(sender As Object, e As EventArgs) Handles tPLAZA_O.Validated
        Try
            If tPLAZA_O.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tPLAZA_O.Text)
                If DESCR <> "" Then
                    LtPlaza.Text = DESCR
                    tPLAZA_D.Select()
                Else
                    If tPLAZA_O.Tag <> "B" And tPLAZA_O.Text <> LtPlaza.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tPLAZA_O.Focus()
                        tPLAZA_O.Text = ""
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

    Private Sub TPLAZA_D_KeyDown(sender As Object, e As KeyEventArgs) Handles tPLAZA_D.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnPlazaD_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub TPLAZA_D_Validated(sender As Object, e As EventArgs) Handles tPLAZA_D.Validated
        Try
            If tPLAZA_D.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Plazas", tPLAZA_D.Text)
                If DESCR <> "" Then
                    LtPlaza2.Text = DESCR
                    tSUELDO.Select()
                Else
                    If tPLAZA_D.Tag <> "B" And tPLAZA_D.Text <> LtPlaza2.Tag Then
                        MessageBox.Show("Plaza inexistente")
                        tPLAZA_D.Focus()
                        tPLAZA_D.Text = ""
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

    Private Sub BtnPlazaO_Click(sender As Object, e As EventArgs) Handles BtnPlazaO.Click
        Try
            Var2 = "Plazas" 'GCPLAZAS
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                tPLAZA_O.Text = Var4
                LtPlaza.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                tPLAZA_D.Select()
            Else
                LtPlaza.Text = ""
            End If
        Catch ex As Exception
            Bitacora("380. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("380. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub BtnTabRuta_Click(sender As Object, e As EventArgs) Handles BtnTabRuta.Click
        Try
            Var2 = "RUTAS FLORES"
            Var4 = "" : Var5 = "" : Var6 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_TAB.Text = Var4
                Var2 = "" : Var4 = "" : Var5 = ""
                tCLAVE_O.Focus()
            End If
        Catch ex As Exception
            Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_TAB_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_TAB.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnTabRuta_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCVE_TAB_Validated(sender As Object, e As EventArgs) Handles TCVE_TAB.Validated
        If TCVE_TAB.Text.Length > 0 Then
            Try
                SQL = "SELECT T.CVE_TAB
                    FROM GCTAB_RUTAS_F T
                    WHERE CVE_TAB = '" & TCVE_TAB.Text & "'"
                Using cmd As SqlCommand = cnSAE.CreateCommand
                    cmd.CommandText = SQL
                    Using dr As SqlDataReader = cmd.ExecuteReader
                        If dr.Read Then
                            tCLAVE_O.Focus()
                        Else
                            MsgBox("tabulador de viaje inexistente, verifique por favor")
                            TCVE_TAB.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                Bitacora("38. " & ex.Message & vbNewLine & ex.StackTrace)
                MsgBox("38. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub
End Class
