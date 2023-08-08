Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Public Class FrmCtaBanOrdAE
    Private Sub FrmCtaBanOrdAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        If Var1 = "XXX" Then
            BtnCtaBan.Visible = True
        End If

        If Var1 = "Nuevo" Then
            Try
                TCTA_BANCARIA.Text = ""
                TCTA_BANCARIA.Select()

            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            If Var1 = "XXX" Then
                TCTA_BANCARIA.Select()
            Else
                BUSCA_CTA(Var2)
                TCTA_BANCARIA.Enabled = False
                TNOMBRE.Select()
            End If

            Try
                If Var1 = "XXX" Then
                    TCTA_BANCARIA.Select()
                Else
                    BUSCA_CTA(Var2)
                    TCTA_BANCARIA.Enabled = False
                    TNOMBRE.Select()
                End If

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Sub BUSCA_CTA(FCTA_BAN As String)
        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            cmd.Connection = cnSAE

            Me.KeyPreview = True

            SQL = "SELECT E.CUENTA_BANCARIA, E.RFC_BANCO, E.NOMBRE_BANCO, E.CLAVE, E.CLABE
                    FROM CUENTA_ORD" & Empresa & " E WHERE  CUENTA_BANCARIA = '" & Var2 & "'"
            cmd.CommandText = SQL
            dr = cmd.ExecuteReader

            If dr.Read Then
                TCTA_BANCARIA.Text = dr("CUENTA_BANCARIA").ToString
                TRFC.Text = dr("RFC_BANCO").ToString
                TNOMBRE.Text = dr("NOMBRE_BANCO").ToString
                TCLIENTE.Text = dr("CLAVE").ToString
                LtNombre.Text = BUSCA_CAT("Cliente", TCLIENTE.Text)
                TCLABE.Text = dr.ReadNullAsEmptyString("CLABE").ToString
            Else
                TCTA_BANCARIA.Text = ""
                TRFC.Text = ""
                TNOMBRE.Text = ""
                TCLIENTE.Text = ""
                TCLABE.TEXT = ""
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub FrmCtaBanOrdAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As EventArgs) Handles barGrabar.Click

        SQL = "UPDATE CUENTA_ORD" & Empresa & " SET RFC_BANCO = @RFC_BANCO, NOMBRE_BANCO = @NOMBRE_BANCO, 
            CLAVE = @CLAVE, CLABE = @CLABE
            WHERE CUENTA_BANCARIA = @CUENTA_BANCARIA
            If @@ROWCOUNT = 0
            INSERT INTO CUENTA_ORD" & Empresa & " (CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLAVE, CLABE)
            VALUES (@CUENTA_BANCARIA, @RFC_BANCO, @NOMBRE_BANCO, @CLAVE, @CLABE)"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CUENTA_BANCARIA", SqlDbType.VarChar).Value = TCTA_BANCARIA.Text
                cmd.Parameters.Add("@RFC_BANCO", SqlDbType.VarChar).Value = TRFC.Text
                cmd.Parameters.Add("@NOMBRE_BANCO", SqlDbType.VarChar).Value = TNOMBRE.Text
                cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TCLIENTE.Text
                cmd.Parameters.Add("@CLABE", SqlDbType.VarChar).Value = TCLABE.Text
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

    Private Sub MnuSalir_Click(sender As Object, e As EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnCtaBan_Click(sender As Object, e As EventArgs) Handles BtnCtaBan.Click
        Var2 = "CuentaOrdenante"
        Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
        frmSelItem.ShowDialog()
        If Var4.Trim.Length > 0 Then
            'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
            'Var5 = Fg(Fg.Row, 2) 'RFC 
            'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
            TCTA_BANCARIA.Text = Var4
            TNOMBRE.Text = Var6
            TRFC.Text = Var5
            TCLIENTE.Text = Var7
            Var2 = "" : Var4 = "" : Var5 = ""
            TNOMBRE.Select()
        End If
    End Sub

    Private Sub TCTA_BANCARIA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCTA_BANCARIA.KeyDown
        If e.KeyCode = Keys.F2 And Var2 = "XXX" Then
            BtnCtaBan_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TCTA_BANCARIA_Validated(sender As Object, e As EventArgs) Handles TCTA_BANCARIA.Validated
        Try
            If TCTA_BANCARIA.Text.Trim.Length > 0 And Var2 = "XXX" Then
                Dim DESCR As String
                DESCR = BUSCA_CAT("CuentaOrdenante", TCTA_BANCARIA.Text)
                If DESCR <> "" Then
                    BUSCA_CTA(TCTA_BANCARIA.Text)
                    TNOMBRE.Select()
                Else
                    MsgBox("Cuenta beneficiario inexistente")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCliente_Click(sender As Object, e As EventArgs) Handles BtnCliente.Click
        Try
            Var2 = "Clientes"
            Var4 = "" : Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                TCLIENTE.Text = Var4
                LtNombre.Text = Var5
                Var2 = "" : Var4 = "" : Var5 = ""
                TNOMBRE.Focus()
            End If
        Catch Ex As Exception
            Bitacora("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("780. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub
    Private Sub TCLIENTE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLIENTE.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnCliente_Click(Nothing, Nothing)
            Return
        End If
    End Sub
    Private Sub TCLIENTE_Validated(sender As Object, e As EventArgs) Handles TCLIENTE.Validated
        Try
            If TCLIENTE.Text.Trim.Length > 0 Then
                Dim DESCR As String
                If IsNumeric(TCLIENTE.Text.Trim) Then
                    DESCR = Space(10 - TCLIENTE.Text.Trim.Length) & TCLIENTE.Text.Trim
                    TCLIENTE.Text = DESCR
                End If

                DESCR = BUSCA_CAT("Cliente", TCLIENTE.Text)
                If DESCR <> "" Then
                    LtNombre.Text = DESCR
                Else
                    MsgBox("Cliente inexistente")
                    TCLIENTE.Text = ""
                    LtNombre.Text = ""
                    TNOMBRE.Focus()
                End If
            Else
                LtNombre.Text = ""
            End If
        Catch ex As Exception
            Bitacora("100. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("100. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub TCLIENTE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLIENTE.PreviewKeyDown
        If e.KeyCode = 9 Then
            TNOMBRE.Focus()
        End If
    End Sub
End Class
