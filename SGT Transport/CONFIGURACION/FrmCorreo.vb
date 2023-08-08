Imports C1.Win.C1Themes
Imports C1.Win.C1Command

Public Class FrmCorreo
    Private Sub FrmCorreo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Var4 = "NO"
        LtNombre.Text = Var6
        TCORREO_CTE.Text = Var9

        'Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
        'Var3 = EMISOR_NOMBRE
        'Var4 = EMISOR_RFC
        'Var5 = Fg(Fg.Row, 4) 'RFC RECEPTOR
        'Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

        'Var7 = FILE_XML
        'Var8 = RUTA_PDF

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()

    End Sub

    Private Sub FrmCorreo_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
    Private Sub BarCorreo_Click(sender As Object, e As ClickEventArgs) Handles BarCorreo.Click
        If TCORREO1.Text.Trim.Length > 0 Then
            If TCORREO1.Text.IndexOf("@") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
            If TCORREO1.Text.IndexOf(".") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
        End If
        If TCORREO2.Text.Trim.Length > 0 Then
            If TCORREO2.Text.IndexOf("@") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
            If TCORREO2.Text.IndexOf(".") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
        End If
        If TCORREO3.Text.Trim.Length > 0 Then
            If TCORREO3.Text.IndexOf("@") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
            If TCORREO3.Text.IndexOf(".") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
        End If
        If TCORREO4.Text.Trim.Length > 0 Then
            If TCORREO4.Text.IndexOf("@") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
            If TCORREO4.Text.IndexOf(".") = -1 Then
                MsgBox("Correo incorrecto verifique por favor")
                Return
            End If
        End If

        Var4 = "SI"

        'Var2 = Fg(Fg.Row, 1) 'DOCUMENTO
        'Var3 = EMISOR_NOMBRE
        'Var4 = EMISOR_RFC
        'Var5 = Fg(Fg.Row, 4) 'RFC RECEPTOR
        'Var6 = Fg(Fg.Row, 3) 'NOMBRE RECEPTOR

        'Var7 = FILE_XML
        'Var8 = RUTA_PDF




        Try
            Dim MensaDia As String = "", BuenDia As String = ""

            Dim aCorreo As New ArrayList From {Var7, Var8}
            Try
                Dim horaActual As String
                horaActual = DateTime.Now.ToString("HH:mm")
                If horaActual >= "24:00" And horaActual <= "12:00" Then
                    BuenDia = "Buenos Días"
                ElseIf horaActual >= "12:01" And horaActual <= "19:00" Then
                    BuenDia = "Buenas Tardes"
                ElseIf horaActual >= "19:01" And horaActual <= "23:59" Then
                    BuenDia = "Buenas Noches"
                End If
                MensaDia = horaActual
            Catch ex As Exception
                BITACORACFDI("960. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            If TCORREO_CTE.Text.Length > 0 Or TCORREO1.Text.Length > 0 Or TCORREO2.Text.Length > 0 Or TCORREO3.Text.Length > 0 Then

                SendEmail(TCORREO_CTE.Text, "Comprobamte CFDI",
                            MensaDia & vbCrLf & vbCrLf &
                            "Documento " & Var2 & vbCrLf &
                            "Ajunto se envia representacion CFDI en formato PDF" & vbCrLf & vbCrLf &
                             Var3, aCorreo, TCORREO_CTE.Text, TCORREO1.Text, TCORREO2.Text, TCORREO3.Text)
            End If
        Catch ex As Exception
            BITACORACFDI("10. ex.Message " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try


        Me.Close()

    End Sub
    Private Sub TCORREO1_Leave(sender As Object, e As EventArgs) Handles TCORREO1.Leave
        Try
            If validar_Mail(LCase(TCORREO1.Text)) = False Then
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TCORREO1.Focus()
                TCORREO1.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCORREO2_Leave(sender As Object, e As EventArgs) Handles TCORREO2.Leave
        Try
            If validar_Mail(LCase(TCORREO2.Text)) = False Then
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                    por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TCORREO2.Focus()
                TCORREO2.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TCORREO3_Leave(sender As Object, e As EventArgs) Handles TCORREO3.Leave
        Try
            If validar_Mail(LCase(TCORREO3.Text)) = False Then
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                    por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TCORREO3.Focus()
                TCORREO3.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TCORREO4_Leave(sender As Object, e As EventArgs) Handles TCORREO4.Leave
        Try
            If validar_Mail(LCase(TCORREO4.Text)) = False Then
                MessageBox.Show("Dirección de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, 
                    por favor seleccione un correo valido", "Validación de correo electronico", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TCORREO4.Focus()
                TCORREO4.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class
