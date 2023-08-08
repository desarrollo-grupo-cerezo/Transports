Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmBConBanAE
    Private Sub FrmBConBanAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()
        Me.KeyPreview = True

        For Each tb As TextBox In Controls.OfType(Of TextBox)()
            AddHandler tb.GotFocus, AddressOf TextBox_GotFocus
            AddHandler tb.LostFocus, AddressOf TextBox_LostFocus
        Next

        BarGrabar.Shortcut = Shortcut.F3
        BarSalir.Shortcut = Shortcut.F5

        TCONCEP.Value = ""
        TCONCEPSAE.Value = 0
        TCTA_CONTAB.Value = ""
        TIVA.Value = 0
        TCLASIFICACION.Value = ""

        CboTipo.Items.Add("CARGO")
        CboTipo.Items.Add("ABONO")

        If Var1 = "Nuevo" Then
            Try
                TCVE_CONCEP.Text = ""
                TCVE_CONCEP.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        Else
            Try

                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT ISNULL(O.CVE_CONCEP,'') AS C_CONCEP, ISNULL(O.TIPO,'') AS TIP, ISNULL(O.CONCEP,'') AS DESCR, 
                    ISNULL(O.CONCEPSAE,0) AS CONSAE, ISNULL(O.CTA_CONTAB,'') AS C_CONTAB, ISNULL(O.IVA,0) AS IV, 
                    ISNULL(O.CLASIFICACION,'') AS CLASIFIC
                    FROM BCONCEP O 
                    WHERE CVE_CONCEP = '" & Var2 & "'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_CONCEP.Text = dr("C_CONCEP").ToString
                    If dr("TIP").ToString = "CARGO" Then
                        CboTipo.SelectedIndex = 0
                    Else
                        CboTipo.SelectedIndex = 1
                    End If
                    TCONCEP.Text = dr("DESCR").ToString
                    TCONCEPSAE.Text = dr("CONSAE").ToString
                    TCTA_CONTAB.Text = dr("C_CONTAB").ToString
                    TIVA.Text = dr("IV").ToString
                    TCLASIFICACION.Text = dr("CLASIFIC").ToString
                End If
                dr.Close()

                TCVE_CONCEP.Enabled = False
                TCONCEP.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If
    End Sub
    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.FromArgb(176, 240, 0)
        sender.bordercolor = Color.Red

        'PaleTurquoise
    End Sub
    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs)
        sender.BackColor = Color.White
    End Sub
    Private Sub FrmBConBanAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        If Not Valida_Conexion() Then
            Return
        End If

        Try
            TCONCEP.UpdateValueWithCurrentText()
            TCONCEPSAE.UpdateValueWithCurrentText()
            TCTA_CONTAB.UpdateValueWithCurrentText()
            TIVA.UpdateValueWithCurrentText()
            TCLASIFICACION.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        If CboTipo.SelectedIndex = -1 Then
            MsgBox("Por favor seleccione el tipo de CARGO/ABONO")
            Return
        End If
        If TCONCEP.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        'If TCTA_CONTAB.Text.Trim.Length = 0 Then
        'MsgBox("La cuenta contable no debe quedar vacia, verifique por favor")
        'Return
        'End If
        If TIVA.Text.Trim.Length = 0 Then
            MsgBox("El iva no debe quedar vacia, verifique por favor")
            Return
        End If
        'If TCLASIFICACION.Text.Trim.Length = 0 Then
        'MsgBox("La clasificación no debe quedar vacia, verifique por favor")
        'Return
        'End If

        SQL = "UPDATE BCONCEP SET TIPO = @TIPO, CONCEP = @CONCEP, CONCEPSAE = @CONCEPSAE, 
            CTA_CONTAB = @CTA_CONTAB, IVA = @IVA, CLASIFICACION = @CLASIFICACION 
            WHERE CVE_CONCEP = @CVE_CONCEP
            IF @@ROWCOUNT = 0
            INSERT INTO BCONCEP (CVE_CONCEP, TIPO, CONCEP, CONCEPSAE, CTA_CONTAB, 
            ESTADO, IVA, CLASIFICACION) VALUES(
            @CVE_CONCEP, @TIPO, @CONCEP, @CONCEPSAE, @CTA_CONTAB, 0, @IVA, @CLASIFICACION)"

        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.Parameters.Add("@CVE_CONCEP", SqlDbType.VarChar).Value = TCVE_CONCEP.Text
                cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = IIf(CboTipo.SelectedIndex = 0, "CARGO", "ABONO")
                cmd.Parameters.Add("@CONCEP", SqlDbType.VarChar).Value = TCONCEP.Text
                cmd.Parameters.Add("@CONCEPSAE", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCONCEPSAE.Value)
                cmd.Parameters.Add("@CTA_CONTAB", SqlDbType.VarChar).Value = TCTA_CONTAB.Text
                cmd.Parameters.Add("@IVA", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(TIVA.Text)
                cmd.Parameters.Add("@CLASIFICACION", SqlDbType.VarChar).Value = TCLASIFICACION.Text
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then

                    End If
                End If
            End Using
            MsgBox("El concepto se grabo correctamente")

            Me.Close()
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub TCLASIFICACION_KeyDown(sender As Object, e As KeyEventArgs) Handles TCLASIFICACION.KeyDown
        If e.KeyCode = 13 Then
            TCONCEP.Focus()
        End If
    End Sub
    Private Sub TCLASIFICACION_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles TCLASIFICACION.PreviewKeyDown
        If e.KeyCode = 9 Then
            TCONCEP.Focus()
        End If
    End Sub

    Private Sub FrmBConBanAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
End Class