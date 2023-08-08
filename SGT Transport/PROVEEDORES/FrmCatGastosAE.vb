Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class FrmCatGastosAE
    Private Sub FrmCatGastosAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)

            BtnLinea.FlatStyle = FlatStyle.Flat
            BtnLinea.FlatAppearance.BorderSize = 0
            BtnEsquema.FlatStyle = FlatStyle.Flat
            BtnEsquema.FlatAppearance.BorderSize = 0
            Me.KeyPreview = True
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

        If Var1 = "Nuevo" Then
            Try
                TCOSTO.Value = 0
                TDESCR.Text = ""
                'TCVE_ESQIMPU.Text = "1"
                'LtEsquema.Text = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)

                TCVE_ART.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT C.CVE_ART, C.STATUS, C.DESCR, C.CVE_ESQIMPU, C.LINEA, DESC_LIN, ISNULL(DESCRIPESQ,'') AS DES_ESQ,
                    ISNULL(COSTO,0) AS COST, ISNULL(CUENTA_CONT,'') AS CUENTA_CONTA
                    FROM GCCATGASTOS C 
                    LEFT JOIN CLIN" & Empresa & " L ON L.CVE_LIN = C.LINEA
                    LEFT JOIN IMPU" & Empresa & " I ON I.CVE_ESQIMPU = C.CVE_ESQIMPU
                    WHERE CVE_ART = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_ART.Text = dr.ReadNullAsEmptyString("CVE_ART")
                    TDESCR.Text = dr.ReadNullAsEmptyString("DESCR")
                    TLINEA.Text = dr.ReadNullAsEmptyString("LINEA")
                    LtLinea.Text = dr.ReadNullAsEmptyString("DESC_LIN")
                    TCVE_ESQIMPU.Text = dr("CVE_ESQIMPU")
                    LtEsquema.Text = dr("DES_ESQ")
                    TCOSTO.Value = dr("COST")
                    TCUENTA_CONT.Text = dr("CUENTA_CONTA")
                Else
                    TCVE_ART.Text = ""
                    TDESCR.Text = ""
                    TLINEA.Text = ""
                    TCOSTO.Value = 0
                End If
                dr.Close()

                TCVE_ART.Enabled = False
                TDESCR.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub FrmCatGastosAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click

        If TCVE_ART.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la clave del gasto")
            Return
        End If
        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture la descripción")
            Return
        End If
        If TCVE_ESQIMPU.Text.Trim.Length = 0 Then
            MsgBox("Por favor capture el esquema de impuestos")
            Return
        End If
        If BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text.Trim) = "" Then
            MsgBox("Por favor capture el esquema de impuesto")
            Return
        End If

        Try
            TCOSTO.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        SQL = "IF EXISTS (SELECT CVE_ART FROM GCCATGASTOS WHERE CVE_ART = @CVE_ART)
                    UPDATE GCCATGASTOS SET DESCR = @DESCR, LINEA = @LINEA, CVE_ESQIMPU = @CVE_ESQIMPU, COSTO = @COSTO, CUENTA_CONT = @CUENTA_CONT
                    WHERE CVE_ART = @CVE_ART
                ELSE
                    INSERT INTO GCCATGASTOS (CVE_ART, STATUS, DESCR, LINEA, CVE_ESQIMPU, COSTO, CUENTA_CONT, UUID)
                    VALUES (@CVE_ART, 'A', @DESCR, @LINEA, @CVE_ESQIMPU, @COSTO, @CUENTA_CONT, NEWID())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = TCVE_ART.Text.Trim
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text.Trim
                cmd.Parameters.Add("@LINEA", SqlDbType.VarChar).Value = TLINEA.Text
                cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.VarChar).Value = TCVE_ESQIMPU.Text
                cmd.Parameters.Add("@COSTO", SqlDbType.Float).Value = TCOSTO.Value
                cmd.Parameters.Add("@CUENTA_CONT", SqlDbType.VarChar).Value = TCUENTA_CONT.Text
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
            End Using

        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnLinea_Click(sender As Object, e As EventArgs) Handles BtnLinea.Click
        Try
            Var2 = "Lineas"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TLINEA.Text = Var4
                LtLinea.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCVE_ESQIMPU.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub TLINEA_KeyDown(sender As Object, e As KeyEventArgs) Handles TLINEA.KeyDown
        If e.KeyValue = Keys.F2 Then
            BtnLinea_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TLINEA_Validated(sender As Object, e As EventArgs) Handles TLINEA.Validated
        Try
            If TLINEA.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Linea", TLINEA.Text)
                If DESCR <> "" Then
                    LtLinea.Text = DESCR
                    'TDESCR.Focus()
                Else
                    MsgBox("Articulo inexistente")
                    LtLinea.Text = ""
                    TLINEA.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCatGastosAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub TCOSTO_KeyDown(sender As Object, e As KeyEventArgs) Handles TCOSTO.KeyDown
        If e.KeyValue = 13 Then
            'TCUENTA_CONT.Focus()
        End If
    End Sub
    Private Sub TCOSTO_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCOSTO.PreviewKeyDown
        If e.KeyValue = 9 Then
            'TCUENTA_CONT.Focus()
        End If
    End Sub
    Private Sub TCUENTA_CONT_KeyDown(sender As Object, e As KeyEventArgs) Handles TCUENTA_CONT.KeyDown
        If e.KeyValue = 13 Then
            TDESCR.Focus()
        End If
    End Sub
    Private Sub TCUENTA_CONT_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCUENTA_CONT.PreviewKeyDown
        If e.KeyValue = 9 Then
            TDESCR.Focus()
        End If
    End Sub
    Private Sub BtnEsquema_Click(sender As Object, e As EventArgs) Handles BtnEsquema.Click
        Try
            Var2 = "Esquema"
            Var3 = "" : Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCVE_ESQIMPU.Text = Var4
                LtEsquema.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TCOSTO.Focus()
            End If
        Catch Ex As Exception
            MsgBox("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("108. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCVE_ESQIMPU_KeyDown(sender As Object, e As KeyEventArgs) Handles TCVE_ESQIMPU.KeyDown
        If e.KeyValue = Keys.F2 Then
            BtnEsquema_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TCVE_ESQIMPU_Validated(sender As Object, e As EventArgs) Handles TCVE_ESQIMPU.Validated
        Try
            If TCVE_ESQIMPU.Text.Trim.Length > 0 Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("Esquema", TCVE_ESQIMPU.Text)
                If DESCR <> "" Then
                    LtEsquema.Text = DESCR
                    'TDESCR.Focus()
                Else
                    MsgBox("Esquema inexistente")
                    LtEsquema.Text = ""
                    TCVE_ESQIMPU.Text = ""
                End If
            End If
        Catch ex As Exception
            Bitacora("223. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("223. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCVE_ART_Validated(sender As Object, e As EventArgs) Handles TCVE_ART.Validated
        Try
            If TCVE_ART.Text.Trim.Length = 0 Then
                MsgBox("La clave del gasto no debe quedar vacia")
                TCVE_ART.Select()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class