Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command
Imports C1.Win.C1Input

Public Class FrmBBenefAE
    Private Sub FrmBBenefAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        CboTipo.Items.Add("CARGO")
        CboTipo.Items.Add("ABONO")
        CboTipo.Items.Add("AMBOS")

        TCLABE.Enabled = False

        Try
            Me.CenterToScreen()
            Me.KeyPreview = True

            BtnBanco.FlatStyle = FlatStyle.Flat
            BtnBanco.FlatAppearance.BorderSize = 0

            For Each tb As TextBox In Controls.OfType(Of TextBox)()
                AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
                AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
            Next

            TNUM_REG.Value = ""
            TNOMBRE.Value = ""
            TRFC.Value = ""
            TCTA_CONTAB.Value = ""
            TREFERENCIA.Value = ""
            TCUENTA.Value = ""
            TCLABE.Value = ""
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try

        If Var1 = "Nuevo" Then
            Try
                TNUM_REG.Value = GET_MAX_TRY("BBENEF", "CLAVE")
                TNUM_REG.Enabled = False
                TNOMBRE.Value = ""
                TNOMBRE.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                SQL = "SELECT E.CLAVE, E.NOMBRE, E.RFC, E.CTA_CONTAB, E.TIPO, E.REFERENCIA, E.CUENTA, C.CLABE
                    FROM BBENEF E 
                    LEFT JOIN CUENTA_BENEF" & Empresa & " C ON C.CUENTA_BANCARIA = E.CUENTA
                    WHERE E.CLAVE = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TNUM_REG.Value = dr("CLAVE").ToString
                    TNOMBRE.Value = dr("NOMBRE").ToString
                    TRFC.Value = dr("RFC").ToString
                    TCTA_CONTAB.Value = dr("CTA_CONTAB").ToString

                    Select Case dr("TIPO").ToString
                        Case "CARGO"
                            CboTipo.SelectedIndex = 0
                        Case "ABONO"
                            CboTipo.SelectedIndex = 1
                        Case "AMBOS"
                            CboTipo.SelectedIndex = 2
                    End Select
                    TREFERENCIA.Value = dr("REFERENCIA").ToString
                    TCUENTA.Value = dr("CUENTA").ToString
                    BUSCA_CUENTA_ORD(TCUENTA.Value)
                End If
                dr.Close()

                TNUM_REG.Enabled = False
                TNOMBRE.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub FrmBBenefAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        Try
            sender.BackColor = Color.FromArgb(176, 240, 0)
            sender.bordercolor = Color.Red
            'PaleTurquoise
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub
    Private Sub FrmBBenefAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If
        Dim TIPO_MOV As String = ""

        If CboTipo.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione tipo de movimiento")
            CboTipo.Focus()
            Return
        End If
        Try
            TNUM_REG.UpdateValueWithCurrentText()
            TNOMBRE.UpdateValueWithCurrentText()
            TRFC.UpdateValueWithCurrentText()
            TCTA_CONTAB.UpdateValueWithCurrentText()
            TREFERENCIA.UpdateValueWithCurrentText()
            TCUENTA.UpdateValueWithCurrentText()
            TCLABE.UpdateValueWithCurrentText()

            Select Case CboTipo.SelectedIndex
                Case 0
                    TIPO_MOV = "CARGO"
                Case 1
                    TIPO_MOV = "ABONO"
                Case 2
                    TIPO_MOV = "AMBOS"
            End Select

        Catch ex As Exception
        End Try

        SQL = "UPDATE BBENEF SET NOMBRE = @NOMBRE, RFC = @RFC, CTA_CONTAB = @CTA_CONTAB, TIPO = @TIPO, 
            REFERENCIA = @REFERENCIA, CUENTA = @CUENTA
            WHERE CLAVE = @CLAVE
            IF @@ROWCOUNT = 0
            INSERT INTO BBENEF (CLAVE, STATUS, NOMBRE, RFC, CTA_CONTAB, TIPO, REFERENCIA, CUENTA) VALUES (
            @CLAVE, 'A', @NOMBRE, @RFC, @CTA_CONTAB, @TIPO, @REFERENCIA, @CUENTA)"
        Try
            For k = 1 To 5
                Try
                    Using cmd As SqlCommand = cnSAE.CreateCommand
                        cmd.Parameters.Add("@CLAVE", SqlDbType.VarChar).Value = TNUM_REG.Value
                        cmd.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = TNOMBRE.Value
                        cmd.Parameters.Add("@RFC", SqlDbType.VarChar).Value = TRFC.Value
                        cmd.Parameters.Add("@CTA_CONTAB", SqlDbType.VarChar).Value = TCTA_CONTAB.Value
                        cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = TIPO_MOV
                        cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = TREFERENCIA.Value
                        cmd.Parameters.Add("@CUENTA", SqlDbType.VarChar).Value = TCUENTA.Value
                        cmd.CommandText = SQL
                        returnValue = cmd.ExecuteNonQuery().ToString
                        If returnValue IsNot Nothing Then
                            If returnValue = "1" Then
                                Exit For
                            End If
                        End If
                    End Using
                Catch sqlEx As SqlException
                    If sqlEx.Number = 2627 Then
                    End If
                    Bitacora("53. " & sqlEx.Message & vbNewLine & sqlEx.StackTrace)
                Catch ex As Exception
                    Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                End Try
            Next

            MsgBox("El beneficiario se grabo correctamente")
            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
    Private Sub BtnBanco_Click(sender As Object, e As EventArgs) Handles BtnBanco.Click
        Var2 = "CuentaOrdenante"
        Var4 = "" : Var5 = "" : Var6 = "" : Var7 = ""
        frmSelItem.ShowDialog()
        If Var4.Trim.Length > 0 Then
            'Var4 = Fg(Fg.Row, 1) 'CUENTA BANCARIA
            'Var5 = Fg(Fg.Row, 2) 'RFC 
            'Var6 = Fg(Fg.Row, 3) 'NOMBRE BANCO
            'Var7 = Fg(Fg.Row, 4) 'CVE_BANCO
            'Var8 = Fg(Fg.Row, 5) 'CLABE
            TCUENTA.Text = Var4
            TCLABE.Text = Var8
            Var2 = "" : Var4 = "" : Var5 = ""
            TCUENTA.Select()
        End If
    End Sub
    Private Sub TCUENTA_KeyDown(sender As Object, e As KeyEventArgs) Handles TCUENTA.KeyDown
        If e.KeyCode = Keys.F2 Then
            BtnBanco_Click(Nothing, Nothing)
        End If
        If e.KeyCode = 13 Then
            TNOMBRE.Focus()
        End If
    End Sub

    Private Sub TCUENTA_Validated(sender As Object, e As EventArgs) Handles TCUENTA.Validated
        Try
            If TCUENTA.Text.Trim.Length > 0 Then
                BUSCA_CUENTA_ORD(TCUENTA.Text)
            Else
                MsgBox("Cuenta beneficiario inexistente")
            End If
        Catch ex As Exception
            MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub
    Sub BUSCA_CUENTA_ORD(FCUENTA As String)
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                SQL = "SELECT CUENTA_BANCARIA, RFC_BANCO, NOMBRE_BANCO, CLABE FROM CUENTA_ORD" & Empresa & " 
                     WHERE CUENTA_BANCARIA = '" & FCUENTA & "' ORDER BY NOMBRE_BANCO"
                cmd.CommandText = SQL
                Using dr As SqlDataReader = cmd.ExecuteReader
                    If dr.Read Then
                        TCLABE.Text = dr.ReadNullAsEmptyString("CLABE")
                    End If
                End Using
            End Using
        Catch ex As Exception
            Bitacora("650. " & ex.Message & vbNewLine & ex.StackTrace)
            MsgBox("650. " & ex.Message & vbCrLf & ex.StackTrace)
        End Try

    End Sub
    Private Sub TCLABE_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLABE.KeyDown
        If e.KeyCode = 13 Then
            TNOMBRE.Focus()
        End If
    End Sub
    Private Sub TCLABE_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLABE.PreviewKeyDown
        If e.KeyCode = 9 Then
            TNOMBRE.Focus()
        End If
    End Sub

    Private Sub TTIPO_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = 13 Then
            TREFERENCIA.Focus()
        End If
    End Sub

    Private Sub TCUENTA_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCUENTA.PreviewKeyDown
        If e.KeyCode = 9 Then
            TNOMBRE.Focus()
        End If
    End Sub
End Class