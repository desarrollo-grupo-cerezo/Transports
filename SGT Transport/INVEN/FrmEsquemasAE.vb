Imports C1.Win.C1Themes
Imports System.Data.SqlClient
Imports C1.Win.C1Command

Public Class FrmEsquemasAE
    Private Sub FrmEsquemasAE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim theme As C1Theme = C1ThemeController.GetThemeByName(ThemeElekos, True)
            C1ThemeController.ApplyThemeToControlTree(Me, theme)
            Me.CenterToScreen()

        Catch ex As Exception
        End Try
        Me.KeyPreview = True

        TIMPUESTO1.Value = 0
        TIMPUESTO2.Value = 0
        TIMPUESTO3.Value = 0
        TIMPUESTO4.Value = 0

        CboIMP1APLICA.Items.Add("Precio base")
        CboIMP1APLICA.Items.Add("Excento")
        CboIMP1APLICA.Items.Add("No aplica")

        CboIMP2APLICA.Items.Add("Precio base")
        CboIMP2APLICA.Items.Add("Acumulado 1")
        CboIMP2APLICA.Items.Add("Excento")
        CboIMP2APLICA.Items.Add("No aplica")

        CboIMP3APLICA.Items.Add("Precio base")
        CboIMP3APLICA.Items.Add("Acumulado 1")
        CboIMP3APLICA.Items.Add("Acumulado 2")
        CboIMP3APLICA.Items.Add("Excento")
        CboIMP3APLICA.Items.Add("No aplica")

        CboIMP4APLICA.Items.Add("Precio base")
        CboIMP4APLICA.Items.Add("Acumulado 1")
        CboIMP4APLICA.Items.Add("Acumulado 2")
        CboIMP4APLICA.Items.Add("Acumulado 3")
        CboIMP4APLICA.Items.Add("Excento")
        CboIMP4APLICA.Items.Add("No aplica")

        CboIMP1APLICA.SelectedIndex = 0
        CboIMP2APLICA.SelectedIndex = 0
        CboIMP3APLICA.SelectedIndex = 0
        CboIMP4APLICA.SelectedIndex = 0

        If Var1 = "Nuevo" Then
            Try
                TCVE_ESQIMPU.Text = GET_MAX("IMPU" & Empresa, "CVE_ESQIMPU")
                TCVE_ESQIMPU.Enabled = False
                TDESCRIPESQ.Text = ""
                TDESCRIPESQ.Select()

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

                SQL = "SELECT P.CVE_ESQIMPU, P.DESCRIPESQ, P.IMPUESTO1, P.IMP1APLICA, P.IMPUESTO2, P.IMP2APLICA, P.IMPUESTO3, P.IMP3APLICA, 
                    P.IMPUESTO4, P.IMP4APLICA, P.STATUS, P.UUID, P.VERSION_SINC 
                    FROM IMPU" & Empresa & " P 
                    WHERE CVE_ESQIMPU = " & Var2
                cmd.CommandText = SQL
                dr = cmd.ExecuteReader
                If dr.Read Then
                    TCVE_ESQIMPU.Text = dr("CVE_ESQIMPU")
                    TDESCRIPESQ.Text = dr("DESCRIPESQ")
                    TIMPUESTO1.Text = dr("IMPUESTO1")
                    TIMPUESTO2.Text = dr("IMPUESTO2")
                    TIMPUESTO3.Text = dr("IMPUESTO3")
                    TIMPUESTO4.Text = dr("IMPUESTO4")

                    CboIMP1APLICA.Text = dr("IMP1APLICA")
                    CboIMP2APLICA.Text = dr("IMP2APLICA")
                    CboIMP3APLICA.Text = dr("IMP3APLICA")
                    CboIMP4APLICA.Text = dr("IMP4APLICA")

                    Select Case dr("IMP1APLICA")
                        Case 0
                            CboIMP1APLICA.SelectedIndex = 0
                        Case 4
                            CboIMP1APLICA.SelectedIndex = 1
                        Case 6
                            CboIMP1APLICA.SelectedIndex = 2
                    End Select

                    Select Case dr("IMP2APLICA")
                        Case 0
                            CboIMP2APLICA.SelectedIndex = 0
                        Case 1
                            CboIMP2APLICA.SelectedIndex = 1
                        Case 4
                            CboIMP2APLICA.SelectedIndex = 2
                        Case 6
                            CboIMP2APLICA.SelectedIndex = 3
                    End Select

                    Select Case dr("IMP3APLICA")
                        Case 0
                            CboIMP3APLICA.SelectedIndex = 0
                        Case 1
                            CboIMP3APLICA.SelectedIndex = 1
                        Case 2
                            CboIMP3APLICA.SelectedIndex = 2
                        Case 4
                            CboIMP3APLICA.SelectedIndex = 3
                        Case 6
                            CboIMP3APLICA.SelectedIndex = 4
                    End Select

                    Select Case dr("IMP4APLICA")
                        Case 0
                            CboIMP4APLICA.SelectedIndex = 0
                        Case 1
                            CboIMP4APLICA.SelectedIndex = 1
                        Case 2
                            CboIMP4APLICA.SelectedIndex = 2
                        Case 3
                            CboIMP4APLICA.SelectedIndex = 3
                        Case 4
                            CboIMP4APLICA.SelectedIndex = 4
                        Case 6
                            CboIMP4APLICA.SelectedIndex = 5
                    End Select
                Else
                    TCVE_ESQIMPU.Text = 0
                    TDESCRIPESQ.Text = ""
                    TIMPUESTO1.Value = 0
                    CboIMP1APLICA.SelectedIndex = 0
                    TIMPUESTO2.Value = 0
                    CboIMP2APLICA.SelectedIndex = 0
                    TIMPUESTO3.Value = 0
                    CboIMP3APLICA.SelectedIndex = 0
                    TIMPUESTO4.Value = 0
                    CboIMP4APLICA.SelectedIndex = 0
                End If
                dr.Close()

                TCVE_ESQIMPU.Enabled = False
                TDESCRIPESQ.Select()

            Catch ex As Exception
                MsgBox("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
                Bitacora("15. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            End Try
        End If

    End Sub

    Private Sub FrmEsquemasAE_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub BarGrabar_Click(sender As Object, e As ClickEventArgs) Handles BarGrabar.Click
        Dim APLICA1 As Integer, APLICA2 As Integer, APLICA3 As Integer, APLICA4 As Integer

        If TDESCRIPESQ.Text.Trim.Length = 0 Then
            MsgBox("La descripción no debe quedar vacia, verifique por favor")
            Return
        End If

        Try
            TIMPUESTO1.UpdateValueWithCurrentText()
            TIMPUESTO2.UpdateValueWithCurrentText()
            TIMPUESTO3.UpdateValueWithCurrentText()
            TIMPUESTO4.UpdateValueWithCurrentText()
        Catch ex As Exception
        End Try

        Select Case CboIMP1APLICA.SelectedIndex
            Case 0
                APLICA1 = 0
            Case 1
                APLICA1 = 4
            Case 2
                APLICA1 = 6
        End Select

        Select Case CboIMP2APLICA.SelectedIndex
            Case 0
                APLICA2 = 0
            Case 1
                APLICA2 = 1
            Case 2
                APLICA2 = 4
            Case 3
                APLICA2 = 6
        End Select

        Select Case CboIMP3APLICA.SelectedIndex
            Case 0
                APLICA3 = 0
            Case 1
                APLICA3 = 1
            Case 2
                APLICA3 = 2
            Case 3
                APLICA3 = 4
            Case 4
                APLICA3 = 6
        End Select

        Select Case CboIMP4APLICA.SelectedIndex
            Case 0
                APLICA4 = 0
            Case 1
                APLICA4 = 1
            Case 2
                APLICA4 = 2
            Case 3
                APLICA4 = 3
            Case 4
                APLICA4 = 4
            Case 5
                APLICA4 = 6
        End Select


        SQL = "IF EXISTS (SELECT CVE_ESQIMPU FROM IMPU" & Empresa & " WHERE CVE_ESQIMPU = @CVE_ESQIMPU)
                UPDATE IMPU" & Empresa & " SET DESCRIPESQ = @DESCRIPESQ, IMPUESTO1 = @IMPUESTO1, IMP1APLICA = @IMP1APLICA, IMPUESTO2 = @IMPUESTO2, 
                IMP2APLICA = @IMP2APLICA, IMPUESTO3 = @IMPUESTO3, IMP3APLICA = @IMP3APLICA, IMPUESTO4 = @IMPUESTO4, IMP4APLICA = @IMP4APLICA
                WHERE CVE_ESQIMPU = @CVE_ESQIMPU
               ELSE
                INSERT INTO IMPU" & Empresa & " (CVE_ESQIMPU, DESCRIPESQ, IMPUESTO1, IMP1APLICA, IMPUESTO2, IMP2APLICA, IMPUESTO3, IMP3APLICA, IMPUESTO4, 
                IMP4APLICA, STATUS, UUID, VERSION_SINC) VALUES(
                @CVE_ESQIMPU, @DESCRIPESQ, @IMPUESTO1, @IMP1APLICA, @IMPUESTO2, @IMP2APLICA, @IMPUESTO3, @IMP3APLICA, @IMPUESTO4, @IMP4APLICA, 
                'A', NEWID(), GETDATE())"
        Try
            Using cmd As SqlCommand = cnSAE.CreateCommand
                cmd.CommandText = SQL
                cmd.Parameters.Add("@CVE_ESQIMPU", SqlDbType.Int).Value = CONVERTIR_TO_INT(TCVE_ESQIMPU.Text)
                cmd.Parameters.Add("@DESCRIPESQ", SqlDbType.VarChar).Value = TDESCRIPESQ.Text
                cmd.Parameters.Add("@IMPUESTO1", SqlDbType.Float).Value = TIMPUESTO1.Value
                cmd.Parameters.Add("@IMP1APLICA", SqlDbType.Int).Value = APLICA1
                cmd.Parameters.Add("@IMPUESTO2", SqlDbType.Float).Value = TIMPUESTO2.Value
                cmd.Parameters.Add("@IMP2APLICA", SqlDbType.Int).Value = APLICA2
                cmd.Parameters.Add("@IMPUESTO3", SqlDbType.Float).Value = TIMPUESTO3.Value
                cmd.Parameters.Add("@IMP3APLICA", SqlDbType.Int).Value = APLICA3
                cmd.Parameters.Add("@IMPUESTO4", SqlDbType.Float).Value = TIMPUESTO4.Value
                cmd.Parameters.Add("@IMP4APLICA", SqlDbType.Int).Value = APLICA4
                returnValue = cmd.ExecuteNonQuery().ToString
                If returnValue IsNot Nothing Then
                    If returnValue = "1" Then
                    End If
                End If
                MsgBox("El esquema se grabo correctamente")
                Me.Close()
            End Using
        Catch ex As Exception
            MsgBox("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
            Bitacora("10. " & ex.Message & vbNewLine & "" & ex.StackTrace)
        End Try
    End Sub

    Private Sub BarSalir_Click(sender As Object, e As ClickEventArgs) Handles BarSalir.Click
        Me.Close()
    End Sub
End Class