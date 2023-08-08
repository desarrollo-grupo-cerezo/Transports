Imports C1.Win.C1Themes
Imports System.Data.SqlClient

Public Class frmActividadesManteAE
    Private Sub frmActividadesManteAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Valida_Conexion() Then
            Me.Close()
            Return
        End If
        Dim Existe As Boolean
        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
        Catch ex As Exception
        End Try

        Me.CenterToScreen()
        Me.KeyPreview = True

        BarraMenu.BackColor = Color.FromArgb(164, 177, 202)

        C1SuperTooltip1.SetToolTip(BarGrabar, "F3 - Grabar")
        C1SuperTooltip1.SetToolTip(BarSalir, "F5 - Salir")

        Fg.Rows.Count = 1
        TCVE_SER.Text = ""
        TDESCR.Text = ""
        Existe = False
        If Var1 = "Nuevo" Then
            Try
                TCVE_SER.Text = GET_MAX("GCSERVICIOS_MANTE", "CVE_SER")
                TCVE_SER.Enabled = False
                TDESCR.Text = ""
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("2. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("2. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        Else
            Try
                Dim cmd As New SqlCommand
                Dim dr As SqlDataReader
                cmd.Connection = cnSAE

                Me.KeyPreview = True

                SQL = "SELECT S.CVE_SER, S.STATUS, S.DESCR, S.CVE_TIPO, S.CVE_UNI " &
                    "FROM GCSERVICIOS_MANTE S WHERE CVE_SER = '" & Var2 & "'  AND STATUS = 'A'"
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader

                If dr.Read Then
                    TCVE_SER.Text = dr("CVE_SER")
                    TDESCR.Text = dr("DESCR")
                    'tCVE_TIPO.Text = dr("CVE_TIPO")
                    'tCVE_UNI.Text = dr("CVE_UNI")
                    'LtTipoServicio.Text = BUSCA_CAT("Servicios", tCVE_TIPO.Text)
                    'LtUnidad.Text = BUSCA_CAT("Unidades", tCVE_UNI.Text)
                    Existe = True
                End If
                dr.Close()

                If Existe Then
                    DESPLEGAR_PAR()
                End If

                TCVE_SER.Enabled = False
                TDESCR.Select()
            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try
        End If
    End Sub

    Sub DESPLEGAR_PAR()

        If Not Valida_Conexion() Then
            Return
        End If

        Try
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            cmd.Connection = cnSAE
            cmd.CommandText = "SELECT * FROM GCSERVICIOS_MANTE_PAR WHERE CVE_SER = '" & TCVE_SER.Text & "'"
            dr = cmd.ExecuteReader

            Do While dr.Read
                Fg.AddItem("" & vbTab & dr("CVE_ART") & vbTab & dr("DESCR") & vbTab & dr("TIEMPO") & vbTab & dr("TIPO"))
            Loop
            dr.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmActividadesManteAE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F3
                barGrabar_Click(Nothing, Nothing)
            Case Keys.F5
                mnuSalir_Click(Nothing, Nothing)

        End Select
    End Sub
    Private Sub frmActividadesManteAE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub
    Private Sub barGrabar_Click(sender As Object, e As EventArgs) Handles BarGrabar.Click
        '20 FEB 20
        If Not Valida_Conexion() Then
            Return
        End If

        Dim cmd As New SqlCommand With {
            .Connection = cnSAE
        }

        If TDESCR.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If
        Dim z As Integer
        Dim Horas As Single

        z = 0
        Fg.FinishEditing()

        For K = 1 To Fg.Rows.Count - 1
            If Fg(K, 1).ToString.Trim.Length > 0 And Fg(K, 1) = "1" Then
                If IsNumeric(Fg(K, 3)) Then
                    Horas = Fg(K, 3)
                Else
                    Horas = 0
                End If
                If Horas = 0 Then
                    z = z + 1
                End If
            End If
        Next

        If z > 0 Then
            MsgBox("Algunas partidas no se les capturo el tiempo de servicio, verifique por favor")
            Return
        End If

        SQL = "UPDATE GCSERVICIOS_MANTE SET CVE_SER = @CVE_SER, DESCR = @DESCR  " &
            " WHERE CVE_SER = @CVE_SER " &
            "IF @@ROWCOUNT = 0 " &
            "INSERT INTO GCSERVICIOS_MANTE (CVE_SER, STATUS, DESCR) " &
            "VALUES(@CVE_SER, 'A', @DESCR)"

        cmd.CommandText = SQL
        Try
            cmd.Parameters.Add("@CVE_SER", SqlDbType.VarChar).Value = TCVE_SER.Text
            cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = TDESCR.Text
            'cmd.P'arameters.Add("@CVE_TIPO", SqlDbType.VarChar).Value = tCVE_TIPO.Text
            'cmd.Parameters.Add("@CVE_UNI", SqlDbType.VarChar).Value = tCVE_UNI.Text

            returnValue = cmd.ExecuteNonQuery().ToString
            If returnValue IsNot Nothing Then
                If returnValue = "1" Then
                    GRABA_PAR()
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

    Sub GRABA_PAR()
        Dim cmd As New SqlCommand
        cmd.Connection = cnSAE

        Try

            Try
                SQL = "DELETE FROM GCSERVICIOS_MANTE_PAR WHERE CVE_SER = '" & TCVE_SER.Text & "'"
                cmd.CommandText = SQL
                returnValue = cmd.ExecuteNonQuery().ToString
            Catch ex As Exception
                MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
                Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
            End Try

            SQL = "INSERT INTO GCSERVICIOS_MANTE_PAR (CVE_SER, CVE_ART, NUM_PAR, DESCR, TIEMPO, TIPO) VALUES (
                @CVE_SER, @CVE_ART, ISNULL((SELECT MAX(NUM_PAR) + 1 FROM GCSERVICIOS_MANTE_PAR WHERE CVE_SER = @CVE_SER),1), 
                @DESCR, @TIEMPO, @TIPO)"
            For k = 1 To Fg.Rows.Count - 1
                cmd.CommandText = SQL
                cmd.Parameters.Clear()
                cmd.Parameters.Add("@CVE_SER", SqlDbType.VarChar).Value = TCVE_SER.Text
                cmd.Parameters.Add("@CVE_ART", SqlDbType.VarChar).Value = RemoveCharacter(Fg(k, 1))
                cmd.Parameters.Add("@DESCR", SqlDbType.VarChar).Value = RemoveCharacter(Fg(k, 2))
                cmd.Parameters.Add("@TIEMPO", SqlDbType.Float).Value = CONVERTIR_TO_DECIMAL(Fg(k, 3))
                cmd.Parameters.Add("@TIPO", SqlDbType.SmallInt).Value = CONVERTIR_TO_INT(Fg(k, 4))

                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                        'MsgBox("El registro se grabo satisfactoriamente")
                        Me.Close()
                    Else
                        'MsgBox("No se logro grabar el registro")
                    End If
                Else
                    'MsgBox("No se logro grabar el registro")
                End If
            Next
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub mnuSalir_Click(sender As Object, e As EventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub

    Private Sub btnTipoSer_Click(sender As Object, e As EventArgs)

        Try

            Var2 = "Servicios"
            Var4 = ""
            Var5 = ""
            frmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'tCVE_TIPO.Text = Var4
                'LtTipoServicio.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                'tCVE_UNI.Focus()
            End If
        Catch Ex As Exception
            MsgBox("1. " & Ex.Message & vbNewLine & Ex.StackTrace)
            Bitacora("1. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try

    End Sub

    Private Sub btnTipoUnidad_Click(sender As Object, e As EventArgs)
        Try
            Var2 = "Unidades"
            Var4 = ""
            Var5 = ""
            frmSelItem2.ShowDialog()
            If Var4.Trim.Length > 0 Then
                'tCVE_UNI.Text = Var4
                'LtUnidad.Text = Var5
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
            End If
        Catch Ex As Exception
            Bitacora("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
            MsgBox("20. " & Ex.Message & vbNewLine & Ex.StackTrace)
        End Try
    End Sub

    Private Sub btnArticulo_Click(sender As Object, e As EventArgs) Handles BtnArticulo.Click
        Try
            Var2 = "InveR"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & Var4 & vbTab & Var5 & vbTab & "0" & vbTab & "0")
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
            End If
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnServicios_Click(sender As Object, e As EventArgs) Handles BtnServicios.Click
        Try
            Var2 = "Servicios2"
            Var4 = ""
            Var5 = ""
            FrmSelItem.ShowDialog()
            If Var4.Trim.Length > 0 Then
                Fg.AddItem("" & vbTab & Var4 & vbTab & Var5 & vbTab & "0" & vbTab & "1")
                Var2 = ""
                Var4 = ""
                Var5 = ""
                Fg.Focus()
            End If
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Try
            If Fg.Row > 0 Then
                If MsgBox("Realmenteb desea eliminar la partida seleccionada?", vbYesNo) = vbYes Then
                    Fg.RemoveItem(Fg.Row)
                End If
            End If
        Catch ex As Exception
            MsgBox("1. " & ex.Message & vbNewLine & ex.StackTrace)
            Bitacora("1. " & ex.Message & vbNewLine & ex.StackTrace)
        End Try
    End Sub
    Private Sub tCVE_TIPO_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            btnTipoSer_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub tCVE_UNI_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            btnTipoUnidad_Click(Nothing, Nothing)
        End If
    End Sub
End Class
